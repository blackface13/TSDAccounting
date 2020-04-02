using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TSD.AccountingSoft.BusinessComponents.Facade.Cash;
using TSD.AccountingSoft.BusinessComponents.Facade.Deposit;
using TSD.AccountingSoft.BusinessComponents.Messages.Cash;
using TSD.AccountingSoft.BusinessComponents.Messages.Deposit;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessComponents.Messages.Salary;
using TSD.AccountingSoft.BusinessEntities.Business;
using TSD.AccountingSoft.BusinessEntities.Business.Cash;
using TSD.AccountingSoft.BusinessEntities.Business.Deposit;
using TSD.AccountingSoft.BusinessEntities.Dictionary;
using TSD.AccountingSoft.DataAccess.IEntitiesDao;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Cash;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Deposit;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Salary;

namespace TSD.AccountingSoft.BusinessComponents.Facade.Salary
{
    public class SalaryFacade
    {
        private static readonly IJournalEntryAccountDao JournalEntryAccountDao = DataAccess.DataAccess.JournalEntryAccountDao;
        private static readonly IAccountBalanceDao AccountBalanceDao = DataAccess.DataAccess.AccountBalanceDao;
        private static readonly ISalaryDao SalaryDao = DataAccess.DataAccess.SalaryDao;
        private static readonly IDepositDao DepositDao = DataAccess.DataAccess.DepositDao;
        private static readonly IDepositDetailDao DepositDetailDao = DataAccess.DataAccess.DepositDetailDao;
        private static readonly ICashDao CashDao = DataAccess.DataAccess.CashDao;
        private static readonly ICashDetailDao CashDetailDao = DataAccess.DataAccess.CashDetailDao;
        private static readonly IPayItemDao PayItemDao = DataAccess.DataAccess.PayItemDao;
        private static readonly IEmployeeDao EmployeeDao = DataAccess.DataAccess.EmployeeDao;
        private static readonly IEmployeePayItemDao EmployeePayItemDao = DataAccess.DataAccess.EmployeePayItemDao;

        /// <summary>
        /// The automatic number DAO
        /// </summary>
        private static readonly IAutoNumberDao AutoNumberDao = DataAccess.DataAccess.AutoNumberDao;

        /// <summary>
        /// Gets the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>SalaryResponse.</returns>
        public SalaryResponse GetSalaries(SalaryRequest request)
        {
            var response = new SalaryResponse();

            if (request.LoadOptions.Contains("GetRefNoSalary"))
            {
                var autoNumber = AutoNumberDao.GetAutoNumberByRefTypeSalary(600,request.CurrDate);
                if (request.CurrencyCode=="USD")
                response.Message = autoNumber.Prefix + autoNumber.Suffix + autoNumber.Value;
                else
                    response.Message = autoNumber.Prefix + autoNumber.Suffix + autoNumber.ValueLocalCurency; 

            }
            if (request.LoadOptions.Contains("GetSalaryByMoth"))
            {
                var salaries = SalaryDao.GetSalaryByMoth();
                response.Salaries = salaries;
            }
            if (request.LoadOptions.Contains("GetRefNoEmployeePayroll"))
            {
                var lstEmployeePayroll = SalaryDao.GetSalaryByDayDate(request.CurrDate);
                if (lstEmployeePayroll.Count>0) 
                 response.Message = lstEmployeePayroll[0].RefNo;
            }

            if (request.LoadOptions.Contains("SalaryExistRefNoInDay"))
            {
                var lstEmployeePayroll = SalaryDao.GetSalaryExistRefNoInDay(request.CurrDate, request.RefNo);
                if (lstEmployeePayroll.Count>0) 
                 response.Message = lstEmployeePayroll[0].RefNo;
            }
            return response;
        }

        /// <summary>
        /// Set the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>SalaryResponse.</returns>
        public SalaryResponse SetSalaries(SalaryRequest request)
        {
            var response = new SalaryResponse();
            var obJourentryAccount = new JournalEntryAccountEntity();
            IList<JournalEntryAccountEntity> listJournalEntryAccountEntity = new List<JournalEntryAccountEntity>();
            IList<AccountBalanceEntity> listAccountBalanceEntity = new List<AccountBalanceEntity>();
            var mapper = request.Salary;
            if (request.Action != PersistType.Delete)
            {
                if (!mapper.Validate())
                {
                    foreach (string error in mapper.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
            }
            try
            {
                if (request.LoadOptions.Contains("CalSalary"))
                {
                    var lstDeposit = SalaryDao.GetSalaryByRefNo(mapper.RefNo);
                    if (lstDeposit.Count > 0)
                    {
                        response.Message = "Đã tồn tại số chứng từ " + mapper.RefNo + " !";
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }
                    foreach (var employees in mapper.Employees)
                    {
                        mapper.EmployeeId = employees.EmployeeId;
                        response.SalaryId = SalaryDao.CalSalary(mapper);
                    }
                    var autoNumber = AutoNumberDao.GetAutoNumberByRefType(600);
                    //------------------------------------------------------------------
                    //LinhMC 29/11/2014
                    //Lưu giá trị số tự động tăng theo loại tiền
                    //---------------------------------------------------------------
                    if (request.Salary.CurrencyCode == "USD")
                        autoNumber.Value += 1;
                    else autoNumber.ValueLocalCurency += 1;


                    response.Message = AutoNumberDao.UpdateAutoNumber(autoNumber);
                }

                if (request.LoadOptions.Contains("SavePostedSalary"))
                {

                    /* Danh sách các khoản lương
                     * Nhân viên liên kết Danh sách các khoản lương
                     * Lưu Chứng từ lương:  Nhân viên lấy từ lấy các khoản lương theo nhân viên==> tổng số tiền lương
                     * ==> Đồng thời lưu vào chứng từ Phiếu chi hoặc Giấy báo Nợ đặt mặc định RefType=600 vs Số chứng từ (RefNo) và ngày chứng từ lương
                     * ==> Khi lưu chứng từ Phiếu Chi hoặc Giấy báo Có được lưu dựa trên cách lưu của Phiếu Chi hoặc Giấy Báo Có
                     * ==> Để xác định chứng từ là Phiếu Chi hay Giấy báo Nợ phải dựa báo TK có trên Danh mục khoản lương
                     */
                    var depositEntity = new DepositEntity()
                    {
                        RefId = 0,
                        RefTypeId = mapper.RefTypeId,// 
                        RefDate = mapper.RefDate,
                        RefNo = mapper.RefNo,
                        PostedDate = mapper.PostedDate,
                        AccountingObjectType = 0,
                        AccountingObjectId = null,
                        Trader = "",
                        CustomerId = null,
                        VendorId = null,
                        EmployeeId = null,// mapper.EmployeeId,
                        BankAccountCode = "112",
                        CurrencyCode = mapper.CurrencyCode,
                        ExchangeRate = mapper.ExchangeRate,
                        TotalAmountOc = 0,// employeePayItem.Amount,
                        TotalAmountExchange = 0,// employeePayItem.Amount,
                        JournalMemo = "Chứng từ lương tháng " + mapper.RefDate.Month + "/" + mapper.RefDate.Year,
                    };
                    depositEntity.DepositDetails = new List<DepositDetailEntity>();
                    var cashEntity = new CashEntity
                    {
                        RefId = 0,
                        RefTypeId = mapper.RefTypeId,//
                        RefNo = mapper.RefNo,
                        RefDate = mapper.RefDate,
                        PostedDate = mapper.PostedDate,
                        AccountingObjectId = null,
                        CustomerId = null,
                        VendorId = null,
                        Trader = "",
                        CurrencyCode = mapper.CurrencyCode,
                        ExchangeRate = mapper.ExchangeRate,

                        TotalAmount = 0,
                        TotalAmountExchange = 0,
                        AccountNumber = "",

                        JournalMemo = "Chứng từ lương tháng " + mapper.RefDate.Month + "/" + mapper.RefDate.Year,
                        DocumentInclude = "",
                        AccountingObjectType = 2,
                        //     CashDetails = cashDetails;
                        EmployeeId = null,
                    };
                    cashEntity.CashDetails = new List<CashDetailEntity>();

                    // var lstDeposit = SalaryDao.GetSalaryByRefNo(mapper.RefNo);
                    //if (lstDeposit.Count > 0)
                    //{
                    //    response.Message = "Đã tồn tại số chứng từ " + mapper.RefNo + " !";
                    //    response.Acknowledge = AcknowledgeType.Failure;
                    //    return response;
                    //}
                    //  var Cash
                    mapper.Employees = EmployeeDao.GetEmployeesForSalary(mapper.RefDate, mapper.RefNo);
                    foreach (var employee in mapper.Employees)
                    {
                        //Tính lại lương cho nhân viên trước khi ghi sổ
                        mapper.EmployeeId = employee.EmployeeId;
                        response.SalaryId = SalaryDao.CalSalary(mapper);

                        //Từng nhân viên - từng khoảng lương - tiền tương ứng. 
                        IList<EmployeePayItemEntity> listPayItems = EmployeePayItemDao.GetEmployeeForViewtEmployeePayItem(employee.EmployeeId, mapper.RefDate, mapper.ExchangeRate);
                        // mapper.EmployeePayItemId = EmployeePayItemDao.GetEmployeePayItemsByEmployeeId(employee.EmployeeId);
                        foreach (var employeePayItemEntity in listPayItems)
                        {
                            mapper.EmployeePayItemId = employeePayItemEntity.EmployeePayItemId;
                            var payItems = PayItemDao.GetPayItem(employeePayItemEntity.PayItemId);
                            //Chi 
                            if (payItems.CreditAccountCode.Substring(0, 3).Contains("111"))
                            {
                                // khởi tạo phieu chi chi tiết
                                CashDetailEntity cashDetailEntity = new CashDetailEntity()
                                {
                                    RefDetailId = 0,
                                    RefId = 0,
                                    AccountNumber = payItems.DebitAccountCode,
                                    CorrespondingAccountNumber = payItems.CreditAccountCode,
                                    Description = payItems.PayItemName + " tháng " + mapper.RefDate.Month + "/" + mapper.RefDate.Year,
                                    AmountOc = employeePayItemEntity.Amount * mapper.ExchangeRate,
                                    AmountExchange = employeePayItemEntity.Amount,
                                    VoucherTypeId = null,
                                    BudgetSourceCode = payItems.BudgetSourceCode,
                                    BudgetItemCode = payItems.BudgetItemCode,
                                    AccountingObjectId = null,
                                    MergerFundId = null
                                };
                                bool flag = false;
                                for (int i = 0; i < cashEntity.CashDetails.Count; i++)
                                {
                                    if (cashEntity.CashDetails[i].CorrespondingAccountNumber == cashDetailEntity.CorrespondingAccountNumber && cashEntity.CashDetails[i].AccountNumber == cashDetailEntity.AccountNumber && cashEntity.CashDetails[i].BudgetItemCode == cashDetailEntity.BudgetItemCode && cashEntity.CashDetails[i].BudgetSourceCode == cashDetailEntity.BudgetSourceCode)
                                    {
                                        cashEntity.CashDetails[i].AmountOc = cashEntity.CashDetails[i].AmountOc + cashDetailEntity.AmountOc;
                                        cashEntity.CashDetails[i].AmountExchange = cashEntity.CashDetails[i].AmountExchange + cashDetailEntity.AmountExchange;
                                        flag = true;
                                    }
                                }
                                if (flag == false)
                                {
                                    if (cashDetailEntity.AmountOc>0)
                                    {
                                        cashEntity.CashDetails.Add(cashDetailEntity);
                                    }

                                }
                                //Tính lại TotalAmountOc - TotalAmountExchange
                                cashEntity.TotalAmount = cashEntity.TotalAmount + cashDetailEntity.AmountOc;
                                cashEntity.TotalAmountExchange = cashEntity.TotalAmountExchange + cashDetailEntity.AmountExchange;
                                //Get Bank Acount
                                cashEntity.AccountNumber = payItems.CreditAccountCode;
                            }
                            //Nợ
                            if (payItems.CreditAccountCode.Substring(0, 3).Contains("112") == true)
                            {
                                DepositDetailEntity depositDetailEntity = new DepositDetailEntity()
                                {
                                    RefDetailId = mapper.RefTypeId,
                                    RefId = 0,
                                    Description = payItems.PayItemName + " tháng " + mapper.RefDate.Month + "/" + mapper.RefDate.Year,
                                    AccountNumber = payItems.DebitAccountCode,
                                    CorrespondingAccountNumber = payItems.CreditAccountCode,
                                    AmountOc = employeePayItemEntity.Amount * mapper.ExchangeRate,
                                    AmountExchange = employeePayItemEntity.Amount,
                                    VoucherTypeId = 1,
                                    BudgetSourceCode = payItems.BudgetSourceCode,
                                    AccountingObjectId = null,
                                    BudgetItemCode = payItems.BudgetItemCode,
                                    //DepartmentId = mapper.DepartmentId,
                                    MergerFundId = null
                                };
                                bool flag = false;
                                for (int i = 0; i < depositEntity.DepositDetails.Count; i++)
                                {
                                    if (depositEntity.DepositDetails[i].CorrespondingAccountNumber == depositDetailEntity.CorrespondingAccountNumber && depositEntity.DepositDetails[i].BudgetItemCode == depositDetailEntity.BudgetItemCode && depositEntity.DepositDetails[i].BudgetSourceCode == depositDetailEntity.BudgetSourceCode)
                                    {
                                        depositEntity.DepositDetails[i].AmountOc = depositEntity.DepositDetails[i].AmountOc + depositDetailEntity.AmountOc;
                                        depositEntity.DepositDetails[i].AmountExchange = depositEntity.DepositDetails[i].AmountExchange + depositDetailEntity.AmountExchange;
                                        flag = true;
                                    }
                                }
                                if (flag == false)
                                {
                                    if (depositDetailEntity.AmountOc>0)
                                    depositEntity.DepositDetails.Add(depositDetailEntity);
                                }
                                //Tính lại TotalAmountOc - TotalAmountExchange
                                depositEntity.TotalAmountOc = depositEntity.TotalAmountOc + depositDetailEntity.AmountOc;
                                depositEntity.TotalAmountExchange = depositEntity.TotalAmountExchange + depositDetailEntity.AmountExchange;
                                //Get bank Acount
                                depositEntity.BankAccountCode = payItems.CreditAccountCode;
                            }
                        }
                    }
                    var autoNumber = AutoNumberDao.GetAutoNumberByRefType(600);
                    //------------------------------------------------------------------
                    //LinhMC 29/11/2014
                    //Lưu giá trị số tự động tăng theo loại tiền
                    //---------------------------------------------------------------
                    if (request.Salary.CurrencyCode == "USD")
                        autoNumber.Value += 1;
                    else autoNumber.ValueLocalCurency += 1;

                    response.Message = AutoNumberDao.UpdateAutoNumber(autoNumber);
                    // insert or update giấy báo nợ   

                    {
                        var checkDepositEntity = DepositDao.GetDepositByRefdateAndReftype(depositEntity);
                        if (checkDepositEntity == null)
                        {
                            if (depositEntity.DepositDetails.Count > 0)
                            {
                                var depositRequest = new DepositRequest();
                                var oDepositFacade = new DepositFacade();
                                depositRequest.Action = PersistType.Insert;
                                depositRequest.Deposit = depositEntity;
                                oDepositFacade.SetDeposits(depositRequest);
                            }
                        }
                        //Sẽ không còn trường hợp này nữa
                        //else
                        //{
                        //    //Update CheckDepositEntity with amuont depositEntity,..                          
                        //    checkDepositEntity.DepositDetails = new List<DepositDetailEntity>();
                        //    checkDepositEntity.RefDate = depositEntity.RefDate;
                        //    checkDepositEntity.RefNo = depositEntity.RefNo;
                        //    checkDepositEntity.ExchangeRate = depositEntity.ExchangeRate;
                        //    checkDepositEntity.CurrencyCode = depositEntity.CurrencyCode;
                        //    checkDepositEntity.ExchangeRate = depositEntity.ExchangeRate;
                        //    checkDepositEntity.TotalAmountOc = depositEntity.TotalAmountOc;
                        //    checkDepositEntity.TotalAmountExchange = depositEntity.TotalAmountExchange;
                        //    checkDepositEntity.BankAccountCode = depositEntity.BankAccountCode;
                        //    //Thêm các details mới+
                        //    foreach (var depositDetail in depositEntity.DepositDetails)
                        //    {
                        //        if (!depositDetail.Validate())
                        //        {
                        //            foreach (string error in depositDetail.ValidationErrors)
                        //                response.Message += error + Environment.NewLine;
                        //            response.Acknowledge = AcknowledgeType.Failure;
                        //            return response;
                        //        }
                        //        depositDetail.RefId = checkDepositEntity.RefId;
                        //        checkDepositEntity.DepositDetails.Add(depositDetail);
                        //    }
                        //    var depositRequest = new DepositRequest();
                        //    var oDepositFacade = new DepositFacade();
                        //    depositRequest.Action = PersistType.Update;
                        //    depositRequest.Deposit = checkDepositEntity;
                        //    oDepositFacade.SetDeposits(depositRequest);
                        //}
                    }
                    // Insert phieu chi
                    //if (cashEntity.CashDetails.Count > 0)
                    //{
                    var checkCashEntity = CashDao.GetCashByRefdateAndReftype(cashEntity);
                    if (checkCashEntity == null)
                    {
                        if (cashEntity.CashDetails.Count > 0)
                        {


                            var cashRequest = new CashRequest();
                            var oCashFacade = new CashFacade();
                            cashRequest.Action = PersistType.Insert;
                            cashRequest.CashEntity = cashEntity;
                            oCashFacade.SetCashes(cashRequest);
                        }
                    }
                    //Sẽ không có trường hợp này nữa
                    //else
                    //{
                    //    //Update
                    //    checkCashEntity.CashDetails = new List<CashDetailEntity>();
                    //    checkCashEntity.RefDate = cashEntity.RefDate;
                    //    checkCashEntity.RefNo = cashEntity.RefNo;
                    //    checkCashEntity.ExchangeRate = cashEntity.ExchangeRate;
                    //    checkCashEntity.CurrencyCode = cashEntity.CurrencyCode;
                    //    checkCashEntity.ExchangeRate = cashEntity.ExchangeRate;
                    //    checkCashEntity.TotalAmount = cashEntity.TotalAmount;
                    //    checkCashEntity.TotalAmountExchange = cashEntity.TotalAmountExchange;
                    //    checkCashEntity.AccountNumber = cashEntity.AccountNumber;
                    //    //Thêm các details mới+
                    //    foreach (var cashDetail in cashEntity.CashDetails)
                    //    {
                    //        if (!cashDetail.Validate())
                    //        {
                    //            foreach (string error in cashDetail.ValidationErrors)
                    //                response.Message += error + Environment.NewLine;
                    //            response.Acknowledge = AcknowledgeType.Failure;
                    //            return response;
                    //        }
                    //        cashDetail.RefId = checkCashEntity.RefId;
                    //        checkCashEntity.CashDetails.Add(cashDetail);
                    //    }
                    //    var cashRequest = new CashRequest();
                    //    var oCashFacade = new CashFacade();
                    //    cashRequest.Action = PersistType.Update;
                    //    cashRequest.CashEntity = checkCashEntity;
                    //    oCashFacade.SetCashes(cashRequest);
                    //}
                }

                if (request.LoadOptions.Contains("CheckCalSalaryState"))
                {
                    var salaries = SalaryDao.GetSalaryByRefDateAndEmployId(mapper.RefDate, mapper.EmployeeId);
                    if (salaries.Count > 0)
                    {
                        response.Acknowledge = AcknowledgeType.Success;
                        response.Message = @"Nhân viên đã được tính lương !";
                        response.Salary = salaries[0];
                        return response;
                    }
                    response.Message = null;
                }

                if (request.LoadOptions.Contains("CheckCalSalaryPostedState"))
                {
                    var salaries = SalaryDao.GetSalaryPostedByRefDateAndEmployId(mapper.RefDate, mapper.EmployeeId);
                    if (salaries.Count > 0)
                    {
                        response.Acknowledge = AcknowledgeType.Success;
                        response.Message = @"Nhân viên đã được tính lương !";
                        response.Salary = salaries[0];
                        return response;
                    }
                    response.Message = null;
                }
                
                if (request.LoadOptions.Contains("DeleteCalSalary"))
                {
                    //foreach (var employee in mapper.Employees) 
                    //{
                    //    mapper.EmployeeId = employee.EmployeeId;
                    //    response.SalaryId = SalaryDao.DeleteCalSalary(mapper);
                    //}

                    var depositEntity = new DepositEntity()
                    {
                        RefId = 0,
                        RefTypeId = mapper.RefTypeId,// 
                        RefDate = mapper.RefDate,
                        RefNo = mapper.RefNo,
                        PostedDate = mapper.PostedDate,
                        AccountingObjectType = 0,
                        AccountingObjectId = null,
                        Trader = "",
                        CustomerId = null,
                        VendorId = null,
                        EmployeeId = null,// mapper.EmployeeId,
                        BankAccountCode = "112",
                        CurrencyCode = mapper.CurrencyCode,
                        ExchangeRate = mapper.ExchangeRate,
                        TotalAmountOc = 0,// employeePayItem.Amount,
                        TotalAmountExchange = 0,// employeePayItem.Amount,
                        JournalMemo = "Chứng từ lương tháng " + mapper.RefDate.Month + "/" + mapper.RefDate.Year,
                    };
                    depositEntity.DepositDetails = new List<DepositDetailEntity>();
                    var cashEntity = new CashEntity()
                    {
                        RefId = 0,
                        RefTypeId = mapper.RefTypeId,//
                        RefNo = mapper.RefNo,
                        RefDate = mapper.RefDate,
                        PostedDate = mapper.PostedDate,
                        AccountingObjectId = null,
                        CustomerId = null,
                        VendorId = null,
                        Trader = "",
                        CurrencyCode = mapper.CurrencyCode,
                        ExchangeRate = mapper.ExchangeRate,

                        TotalAmount = 0,
                        TotalAmountExchange = 0,
                        AccountNumber = "",

                        JournalMemo = "Chứng từ lương tháng " + mapper.RefDate.Month + "/" + mapper.RefDate.Year,
                        DocumentInclude = "",
                        AccountingObjectType = 2,
                        //     CashDetails = cashDetails;
                        EmployeeId = null,
                    };
                    cashEntity.CashDetails = new List<CashDetailEntity>();

                    //  var Cash
                    foreach (var employee in mapper.Employees)
                    {
                        //Xóa EmployeePayroll
                        mapper.EmployeeId = employee.EmployeeId;
                        response.SalaryId = SalaryDao.DeleteCalSalary(mapper);
                        //End Xóa EmployeePayroll
                        //Từng nhân viên - từng khoảng lương - tiền tương ứng. 
                        IList<EmployeePayItemEntity> listPayItems = EmployeePayItemDao.GetEmployeePayItemsByEmployeeId(employee.EmployeeId);
                        foreach (var employeePayItemEntity in listPayItems)
                        {
                            mapper.EmployeePayItemId = employeePayItemEntity.EmployeePayItemId;
                            var payItems = PayItemDao.GetPayItem(employeePayItemEntity.PayItemId);
                            //Chi
                            if (payItems.CreditAccountCode.Substring(0, 3).Contains("111"))
                            {
                                // khởi tạo phieu chi chi tiết
                                var cashDetailEntity = new CashDetailEntity()
                                {
                                    RefDetailId = 0,
                                    RefId = 0,
                                    AccountNumber = payItems.DebitAccountCode,
                                    CorrespondingAccountNumber = payItems.CreditAccountCode,
                                    Description = payItems.PayItemName + " tháng " + mapper.RefDate.Month + "/" + mapper.RefDate.Year,
                                    AmountOc = employeePayItemEntity.Amount,
                                    AmountExchange = employeePayItemEntity.Amount / mapper.ExchangeRate,
                                    VoucherTypeId = null,
                                    BudgetSourceCode = payItems.BudgetSourceCode,
                                    BudgetItemCode = payItems.BudgetItemCode,
                                    AccountingObjectId = null,
                                    MergerFundId = null
                                };
                                bool flag = false;
                                for (int i = 0; i < cashEntity.CashDetails.Count; i++)
                                {
                                    if (cashEntity.CashDetails[i].CorrespondingAccountNumber == cashDetailEntity.CorrespondingAccountNumber 
                                        && cashEntity.CashDetails[i].AccountNumber == cashDetailEntity.AccountNumber 
                                        && cashEntity.CashDetails[i].BudgetItemCode == cashDetailEntity.BudgetItemCode 
                                        && cashEntity.CashDetails[i].BudgetSourceCode == cashDetailEntity.BudgetSourceCode)
                                    {
                                        cashEntity.CashDetails[i].AmountOc = cashEntity.CashDetails[i].AmountOc + cashDetailEntity.AmountOc;
                                        cashEntity.CashDetails[i].AmountExchange = cashEntity.CashDetails[i].AmountExchange + cashDetailEntity.AmountExchange;
                                        flag = true;
                                        //   break;
                                    }
                                }

                                if (flag == false)
                                {
                                    cashEntity.CashDetails.Add(cashDetailEntity);
                                }

                                //Tính lại TotalAmountOc - TotalAmountExchange
                                cashEntity.TotalAmount = cashEntity.TotalAmount + cashDetailEntity.AmountOc;
                                cashEntity.TotalAmountExchange = cashEntity.TotalAmountExchange + cashDetailEntity.AmountExchange;
                                //Get Bank Acount
                                cashEntity.AccountNumber = payItems.CreditAccountCode;
                            }
                            //Nợ
                            if (payItems.CreditAccountCode.Substring(0, 3).Contains("112"))
                            {
                                var depositDetailEntity = new DepositDetailEntity()
                                {
                                    RefDetailId = mapper.RefTypeId,
                                    RefId = 0,
                                    Description = payItems.PayItemName + " tháng " + mapper.RefDate.Month + "/" + mapper.RefDate.Year,
                                    AccountNumber = payItems.DebitAccountCode,
                                    CorrespondingAccountNumber = payItems.CreditAccountCode,
                                    AmountOc = employeePayItemEntity.Amount,
                                    AmountExchange = employeePayItemEntity.Amount / mapper.ExchangeRate,
                                    VoucherTypeId = 1,
                                    BudgetSourceCode = payItems.BudgetSourceCode,
                                    AccountingObjectId = null,
                                    BudgetItemCode = payItems.BudgetItemCode,
                                    //    DepartmentId = mapper.DepartmentId,
                                    MergerFundId = null
                                };
                                bool flag = false;
                                for (int i = 0; i < depositEntity.DepositDetails.Count; i++)
                                {
                                    if (depositEntity.DepositDetails[i].CorrespondingAccountNumber == depositDetailEntity.CorrespondingAccountNumber 
                                        && depositEntity.DepositDetails[i].BudgetItemCode == depositDetailEntity.BudgetItemCode 
                                        && depositEntity.DepositDetails[i].BudgetSourceCode == depositDetailEntity.BudgetSourceCode)
                                    {
                                        depositEntity.DepositDetails[i].AmountOc = depositEntity.DepositDetails[i].AmountOc + depositDetailEntity.AmountOc;
                                        depositEntity.DepositDetails[i].AmountExchange = depositEntity.DepositDetails[i].AmountExchange + depositDetailEntity.AmountExchange;
                                        flag = true;
                                        //  break;
                                    }
                                }

                                if (flag == false)
                                {
                                    depositEntity.DepositDetails.Add(depositDetailEntity);
                                }
                                //Tính lại TotalAmountOc - TotalAmountExchange
                                depositEntity.TotalAmountOc = depositEntity.TotalAmountOc + depositDetailEntity.AmountOc;
                                depositEntity.TotalAmountExchange = depositEntity.TotalAmountExchange +
                                                                    depositDetailEntity.AmountExchange;
                                //Get bank Acount
                                depositEntity.BankAccountCode = payItems.CreditAccountCode;
                            }
                        }
                    }
                    var cashRequest = new CashRequest();
                    var oCashFacade = new CashFacade();
                    cashRequest.Action = PersistType.Delete;
                    var cashForDelete = CashDao.GetCashByRefdateAndReftype(cashEntity);
                    if (cashForDelete != null)
                    {
                        cashRequest.RefId = cashForDelete.RefId;
                        cashRequest.RefTypeId = cashForDelete.RefTypeId;
                        //    cashRequest.CashEntity = cashEntity;
                        oCashFacade.SetCashes(cashRequest);
                    }

                    var depositRequest = new DepositRequest();
                    var oDepositFacade = new DepositFacade();
                    depositRequest.Action = PersistType.Delete;
                    var depositForDelete = DepositDao.GetDepositByRefdateAndReftype(depositEntity);
                    if (depositForDelete != null)
                    {
                        depositRequest.RefId = depositForDelete.RefId;
                        depositRequest.RefType = depositForDelete.RefTypeId;
                        //    depositRequest.Deposit = depositEntity;
                        oDepositFacade.SetDeposits(depositRequest);
                    }
                }
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
            response.Acknowledge = response.Message != null ? AcknowledgeType.Failure : AcknowledgeType.Success;
            return response;
        }
    }
}

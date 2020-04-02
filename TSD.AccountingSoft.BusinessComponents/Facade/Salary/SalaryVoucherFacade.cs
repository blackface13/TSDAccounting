/***********************************************************************
 * <copyright file="CashFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   thangNK
 * Email:    thangNK@buca.vn
 * Website:
 * Create Date: Tuesday, March 18, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 

 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using TSD.AccountingSoft.BusinessComponents.Messages.Salary;
using TSD.AccountingSoft.BusinessEntities.Business.Cash;
using TSD.AccountingSoft.BusinessEntities.Business.Deposit;
using TSD.AccountingSoft.BusinessEntities.Dictionary;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Cash;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Deposit;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Salary;

using TSD.AccountingSoft.BusinessComponents.Facade.Cash;
using TSD.AccountingSoft.BusinessComponents.Facade.Deposit;
using TSD.AccountingSoft.BusinessComponents.Messages.Cash;
using TSD.AccountingSoft.BusinessComponents.Messages.Deposit;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;


namespace TSD.AccountingSoft.BusinessComponents.Facade.Salary
{
    public class SalaryVoucherFacade
    {
        private static readonly ISalaryVoucherDao SalaryVoucherDao = DataAccess.DataAccess.SalaryVoucherDao;
        private static readonly IPayItemDao PayItemDao = DataAccess.DataAccess.PayItemDao;
        private static readonly IEmployeeDao EmployeeDao = DataAccess.DataAccess.EmployeeDao;
        private static readonly IEmployeePayItemDao EmployeePayItemDao = DataAccess.DataAccess.EmployeePayItemDao;
        private static readonly ICashDao CashDao = DataAccess.DataAccess.CashDao;
        private static readonly ICashDetailDao CashDetailDao = DataAccess.DataAccess.CashDetailDao;

        private static readonly IDepositDao DepositDao = DataAccess.DataAccess.DepositDao;
        private static readonly IDepositDetailDao DepositDetailDao = DataAccess.DataAccess.DepositDetailDao;
        private static readonly IVoucherTypeDao VoucherTypeDao = DataAccess.DataAccess.VoucherTypeDao;

        public SalaryVoucherResponse GetSalaryVouchers(SalaryVoucherRequest request)
        {
            string currencyCode = "";
            var response = new SalaryVoucherResponse();
            if (request.LoadOptions.Contains("PostedDate"))
            {
                response.SalaryVouchers = SalaryVoucherDao.GetSalaryVoucherMonthDate(request.PostedDate);
            }

            if (request.LoadOptions.Contains("IsPostedDate"))
            {
                response.SalaryVouchers = SalaryVoucherDao.GetSalaryVoucherMonthDateIsPostedDate(request.PostedDate);
            }

            if (request.LoadOptions.Contains("SalaryVoucherByCash"))
            {
                var obj = SalaryVoucherDao.GetSalaryVoucherMonthDateIsPostedDate(request.PostedDate).FirstOrDefault();
                if (obj != null)
                {
                    currencyCode = obj.CurrencyCode;
                }

                var objCash = CashDao.GetCashBySalary(request.ReftypeId, request.PostedDate, request.RefNo, currencyCode);
                if (objCash != null)
                    response.Message = objCash.RefId.ToString();
                else
                    response.Message = "0";
            }

            if (request.LoadOptions.Contains("SalaryVoucherByDeposit"))
            {
                var obj = SalaryVoucherDao.GetSalaryVoucherMonthDateIsPostedDate(request.PostedDate).FirstOrDefault();// thuc ra phai lay dung chung tu, loai tien
                if (obj != null) 
                    currencyCode = obj.CurrencyCode;

                var objDeposit = DepositDao.GetDepositsBySalary(request.ReftypeId, request.PostedDate, request.RefNo, currencyCode);
                if (objDeposit != null)
                    response.Message = objDeposit.RefId.ToString();
                else
                    response.Message = "0";
            }

            if (request.LoadOptions.Contains("SalaryVoucherByIsRetail"))
            {
                response.SalaryVouchers = SalaryVoucherDao.GetSalaryVoucherIsRetail(request.PostedDate, request.IsRetail, request.ReftypeId);
            }
            return response;
        }

        public SalaryVoucherResponse SetSalaryVouchers(SalaryVoucherRequest request)
        {
            var response = new SalaryVoucherResponse();
                string currencyCode = "";
                decimal exchangeRate = 1;


            #region Ghi sổ

            if (request.LoadOptions.Contains("SaveSalaryVoucher"))
            {
                // Lấy voucherType là thực chi
                var voucherType = VoucherTypeDao.GetVoucherTypeByCode("SalaryVoucher") ?? new VoucherTypeEntity();
                // Lấy tất cả các loại khoản lương nhân viên
                List<EmployeeEntity> employees = EmployeeDao.GetEmployeesForSalaryInMonthAndRefNo(request.PostedDate, request.RefNo);

                var obj = SalaryVoucherDao.GetSalaryVoucherMonthDate(request.PostedDate).FirstOrDefault();
                if (obj != null)
                {
                    currencyCode = obj.CurrencyCode;
                    exchangeRate = obj.ExchangeRate;
                }

                //string[] words = request.PostedDate.Split('/');//Chuyển lại ngày tháng cho hợp lý trên C# # SQL
                DateTime postedDate = Convert.ToDateTime(request.PostedDate);

                var depositEntity = new DepositEntity()
                {
                    RefId = 0,
                    RefTypeId = request.ReftypeId, // 
                    RefDate = postedDate, //DateTime.Parse(words[1] + "/" + words[0] + "/" + words[2]),
                    RefNo = request.RefNo,
                    PostedDate = postedDate, //DateTime.Parse(words[1] + "/" + words[0] + "/" + words[2]),
                    AccountingObjectType = 1,
                    AccountingObjectId = null,
                    Trader = "",
                    CustomerId = null,
                    VendorId = null,
                    EmployeeId = null, // mapper.EmployeeId,
                    BankAccountCode = "112",
                    CurrencyCode = currencyCode,
                    ExchangeRate = exchangeRate,
                    TotalAmountOc = 0, // employeePayItem.Amount,
                    TotalAmountExchange = 0, // employeePayItem.Amount,
                    JournalMemo =
                        "Chứng từ lương tháng " + postedDate.Month + "/" + postedDate.Year,
                };
                depositEntity.DepositDetails = new List<DepositDetailEntity>();
                var cashEntity = new CashEntity
                {
                    RefId = 0,
                    RefTypeId = request.ReftypeId, //
                    RefNo = request.RefNo,
                    RefDate = postedDate,//DateTime.Parse(words[1] + "/" + words[0] + "/" + words[2]),
                    PostedDate = postedDate,//DateTime.Parse(words[1] + "/" + words[0] + "/" + words[2]),
                    AccountingObjectId = null,
                    CustomerId = null,
                    VendorId = null,
                    Trader = "",
                    CurrencyCode = currencyCode,
                    ExchangeRate = exchangeRate,
                    TotalAmount = 0,
                    TotalAmountExchange = 0,
                    AccountNumber = "",
                    JournalMemo =
                        "Chứng từ lương tháng " + postedDate.Month + "/" + postedDate.Year,
                    DocumentInclude = "",
                    AccountingObjectType = 1,
                    EmployeeId = null,
                };
                cashEntity.CashDetails = new List<CashDetailEntity>();

                foreach (var employee in employees)
                {
                    //Từng nhân viên - từng khoảng lương - tiền tương ứng. 
                    IList<EmployeePayItemEntity> listPayItems = EmployeePayItemDao.GetEmployeeForViewtEmployeePayItem(employee.EmployeeId, postedDate, exchangeRate);
                    foreach (var employeePayItemEntity in listPayItems)
                    {
                        var payItems = PayItemDao.GetPayItem(employeePayItemEntity.PayItemId);
                        //Chi 
                        if (payItems != null && (payItems.CreditAccountCode ?? "").StartsWith("111"))
                        {
                            // khởi tạo phieu chi chi tiết
                            CashDetailEntity cashDetailEntity = new CashDetailEntity()
                            {
                                RefDetailId = 0,
                                RefId = 0,
                                AccountNumber = payItems.DebitAccountCode,
                                CorrespondingAccountNumber = payItems.CreditAccountCode,
                                Description = payItems.PayItemName + " tháng " + postedDate.Month + "/" + postedDate.Year,
                                AmountOc = employeePayItemEntity.Amount,
                                AmountExchange = employeePayItemEntity.AmountExchange ,
                                VoucherTypeId = null, //voucherType.VoucherTypeId,
                                BudgetSourceCode = payItems.BudgetSourceCode,
                                BudgetItemCode = payItems.BudgetItemCode,
                                AccountingObjectId = null,
                                // dùng tạm MergerFundId để lưu payitemid
                                MergerFundId = payItems.PayItemId
                            };
                            bool flag = false;
                            for (int i = 0; i < cashEntity.CashDetails.Count; i++)
                            {
                                if (cashEntity.CashDetails[i].MergerFundId == cashDetailEntity.MergerFundId && cashEntity.CashDetails[i].CorrespondingAccountNumber == cashDetailEntity.CorrespondingAccountNumber && cashEntity.CashDetails[i].AccountNumber == cashDetailEntity.AccountNumber && cashEntity.CashDetails[i].BudgetItemCode == cashDetailEntity.BudgetItemCode && cashEntity.CashDetails[i].BudgetSourceCode == cashDetailEntity.BudgetSourceCode)
                                {
                                    cashEntity.CashDetails[i].AmountOc = cashEntity.CashDetails[i].AmountOc + cashDetailEntity.AmountOc;
                                    cashEntity.CashDetails[i].AmountExchange = cashEntity.CashDetails[i].AmountExchange + cashDetailEntity.AmountExchange;
                                    flag = true;
                                }
                            }
                            if (flag == false)
                            {
                                if (cashDetailEntity.AmountOc > 0)
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
                        if (payItems != null && (payItems.CreditAccountCode ?? "").StartsWith("112"))
                        {
                            DepositDetailEntity depositDetailEntity = new DepositDetailEntity()
                            {
                                RefDetailId = request.ReftypeId,
                                RefId = 0,
                                Description = payItems.PayItemName + " tháng " + postedDate.Month + "/" + postedDate.Year,

                                AccountNumber = payItems.DebitAccountCode,
                                CorrespondingAccountNumber = payItems.CreditAccountCode,
                                AmountOc = employeePayItemEntity.Amount,
                                AmountExchange = employeePayItemEntity.AmountExchange,
                                VoucherTypeId = null, //voucherType.VoucherTypeId,
                                BudgetSourceCode = payItems.BudgetSourceCode,
                                AccountingObjectId = null,
                                BudgetItemCode = payItems.BudgetItemCode,
                                // dùng tạm MergerFundId để lưu payitemid
                                MergerFundId = payItems.PayItemId
                            };
                            bool flag = false;
                            for (int i = 0; i < depositEntity.DepositDetails.Count; i++)
                            {
                                // old
                                //if (depositEntity.DepositDetails[i].CorrespondingAccountNumber == depositDetailEntity.CorrespondingAccountNumber && depositEntity.DepositDetails[i].BudgetItemCode == depositDetailEntity.BudgetItemCode && depositEntity.DepositDetails[i].BudgetSourceCode == depositDetailEntity.BudgetSourceCode)
                                //{
                                //    depositEntity.DepositDetails[i].AmountOc = depositEntity.DepositDetails[i].AmountOc + depositDetailEntity.AmountOc;
                                //    depositEntity.DepositDetails[i].AmountExchange = depositEntity.DepositDetails[i].AmountExchange + depositDetailEntity.AmountExchange;
                                //    flag = true;
                                //}

                                if (depositEntity.DepositDetails[i].MergerFundId == depositDetailEntity.MergerFundId && depositEntity.DepositDetails[i].CorrespondingAccountNumber == depositDetailEntity.CorrespondingAccountNumber && depositEntity.DepositDetails[i].BudgetItemCode == depositDetailEntity.BudgetItemCode && depositEntity.DepositDetails[i].BudgetSourceCode == depositDetailEntity.BudgetSourceCode)
                                {
                                    depositEntity.DepositDetails[i].AmountOc = depositEntity.DepositDetails[i].AmountOc + depositDetailEntity.AmountOc;
                                    depositEntity.DepositDetails[i].AmountExchange = depositEntity.DepositDetails[i].AmountExchange + depositDetailEntity.AmountExchange;
                                    flag = true;
                                }
                            }
                            if (flag == false)
                            {
                                if (depositDetailEntity.AmountOc > 0)
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

                // xóa MergerFundId đi không thì lưu nó lỗi á
                cashEntity.CashDetails.Select(c => { c.MergerFundId = null; return c; }).ToList();
                depositEntity.DepositDetails.Select(c => { c.MergerFundId = null; return c; }).ToList();

                long? cashId = null;
                long? depositId = null;
                //Insert chứng từ phiếu chi
                var cashRequest = new CashRequest();
                var oCashFacade = new CashFacade();
                cashRequest.Action = PersistType.Insert;
                cashRequest.CashEntity = cashEntity;
                // sinh định khoản đồng thời
                cashRequest.isAutoGenerateParallel = true;
                if (cashRequest.CashEntity.TotalAmount>0)
                {
                    var cashResponse = oCashFacade.SetCashes(cashRequest);
                    cashId = cashResponse.RefId;
                }

                //Insert chứng từ giấy báo nợ
                var depositRequest = new DepositRequest();
                var oDepositFacade = new DepositFacade();
                depositRequest.Action = PersistType.Insert;
                depositRequest.Deposit = depositEntity;
                if (depositRequest.Deposit.TotalAmountOc>0)
                {
                    var depositRespone = oDepositFacade.SetDeposits(depositRequest, true);
                    depositId = depositRespone.RefId;
                }

                // update id phiếu chi, thu tiền gửi vào bảng
                string updateEmployeePayroll = SalaryVoucherDao.Update_EmployeePayroll_Voucher(request.RefNo, cashId, depositId);
            }


            #endregion

            #region Hủy tính ghi sổ + tính lương

            if (request.LoadOptions.Contains("CancelSalaryVoucher"))
            {

                var obj = SalaryVoucherDao.GetSalaryVoucherMonthDateIsPostedDate(request.PostedDate).FirstOrDefault();
                if (obj != null)
                {
                    currencyCode = obj.CurrencyCode;
                }


                
                var cashRequest = new CashRequest();
                var oCashFacade = new CashFacade();
                cashRequest.Action = PersistType.Delete;
                cashRequest.CashEntity = CashDao.GetCash(SalaryVoucherDao.GetEmployeePayroll_VoucherID(request.RefNo, 201)); //CashDao.GetCashBySalary(request.ReftypeId, request.PostedDate, request.RefNo, currencyCode);

                var depositRequest = new DepositRequest();
                var oDepositFacade = new DepositFacade();
                depositRequest.Action = PersistType.Delete;
                depositRequest.Deposit = DepositDao.GetDeposit(SalaryVoucherDao.GetEmployeePayroll_VoucherID(request.RefNo, 301)); //DepositDao.GetDepositsBySalary(request.ReftypeId, request.PostedDate, request.RefNo, currencyCode);

                //Xóa chứng từ lương ở phiểu chi
                if (cashRequest.CashEntity!= null)
                {
                    cashRequest.RefId = cashRequest.CashEntity.RefId;
                     cashRequest.CashEntity.CashDetails = CashDetailDao.GetCashDetailsByCash(cashRequest.CashEntity.RefId);
                     if (cashRequest.CashEntity.CashDetails!= null)
                     {
                         oCashFacade.SetCashes(cashRequest);
                         response.Message = CashDao.DeleteEmployeePayroll(cashRequest.CashEntity.RefNo,
                        cashRequest.CashEntity.PostedDate.Month + "/" + cashRequest.CashEntity.PostedDate.Day + "/" + cashRequest.CashEntity.PostedDate.Year);

                     }
                }

                //Xóa chứng từ lương ở giấy báo nợ
                if (depositRequest.Deposit!= null)
                {
                    depositRequest.RefId = depositRequest.Deposit.RefId;
                    depositRequest.Deposit.DepositDetails = DepositDetailDao.GetDepositDetailsByDeposit(depositRequest.Deposit.RefId);
                    if (depositRequest.Deposit.DepositDetails!=null)
                    {
                        oDepositFacade.SetDeposits(depositRequest);
                        response.Message = DepositDao.DeleteEmployeePayroll(depositRequest.Deposit.RefNo,
                        depositRequest.Deposit.PostedDate.Value.Month + "/" + depositRequest.Deposit.PostedDate.Value.Day + "/" + depositRequest.Deposit.PostedDate.Value.Year);
                    }
                }
            }

            #endregion

            #region  Hủy tính lương

            if (request.LoadOptions.Contains("CancelCalc"))
            {
               response.Message = SalaryVoucherDao.CanclCalc(request.PostedDate, request.RefNo);
            }

            #endregion

            return response;
        }

        public long GetEmployeePayroll_VoucherID(string refNo, int refTypeId)
        {
            return SalaryVoucherDao.GetEmployeePayroll_VoucherID(refNo, refTypeId);
        }
    }
}




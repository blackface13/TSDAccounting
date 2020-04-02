/***********************************************************************
 * <copyright file="DepositFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   THODD
 * Email:    thodd@buca.vn
 * Website:
 * Create Date: Thursday, March 18, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  07/03/2014       Author    Tudt           Description: Coding standard
 * 25/9/2014    LinhMC  Them dieu kien kiem tra trung so chung tu: neu la chuyen doi du lieu thi khong check
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Transactions;
using TSD.AccountingSoft.BusinessComponents.Facade.General;
using TSD.AccountingSoft.BusinessComponents.Messages.Deposit;
using TSD.AccountingSoft.BusinessComponents.Messages.General;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Business;
using TSD.AccountingSoft.BusinessEntities.Business.Deposit;
using TSD.AccountingSoft.BusinessEntities.Business.General;
using TSD.AccountingSoft.DataAccess.IEntitiesDao;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Deposit;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.General;
using TSD.Enum;

namespace TSD.AccountingSoft.BusinessComponents.Facade.Deposit
{
    /// <summary>
    /// DepositFacade
    /// </summary>
    public class DepositFacade
    {
        private static readonly IDepositDao DepositDao = DataAccess.DataAccess.DepositDao;
        private static readonly IDepositDetailDao DepositDetailDao = DataAccess.DataAccess.DepositDetailDao;
        private static readonly IAutoNumberDao AutoNumberDao = DataAccess.DataAccess.AutoNumberDao;
        private static readonly IJournalEntryAccountDao JournalEntryAccountDao = DataAccess.DataAccess.JournalEntryAccountDao;
        private static readonly IAccountBalanceDao AccountBalanceDao = DataAccess.DataAccess.AccountBalanceDao;
        private static readonly IDepositDetailParallelDao DepositDetailParallelDao = DataAccess.DataAccess.DepositDetailParallelDao;
        private static readonly IAutoBusinessParallelDao AutoBusinessParallelDao = DataAccess.DataAccess.AutoBusinessParallelDao;
        private static readonly IBudgetSourceDao BudgetSourceDao = DataAccess.DataAccess.BudgetSourceDao;
        private static readonly IBudgetItemDao BudgetItemDao = DataAccess.DataAccess.BudgetItemDao;
        private static readonly GeneralFacade GeneralFacede = new GeneralFacade();

        public DepositResponse GetDeposits(DepositRequest request)
        {
            var response = new DepositResponse();
            if (request.LoadOptions.Contains("Deposits"))
            {

                //response.Deposits = request.LoadOptions.Contains("RefType")
                //                        ? DepositDao.GetDepositsByRefTypeId(request.RefType)
                //                        : DepositDao.GetDeposits();
                if (request.LoadOptions.Contains("RefType"))
                    response.Deposits = DepositDao.GetDepositsByRefTypeId(request.RefType);
                else if (request.LoadOptions.Contains("RefDate"))
                    response.Deposits = DepositDao.GetDepositsByYearOfRefDate(request.RefType, (short)DateTime.Parse(request.RefDate).Year);
                else response.Deposits = DepositDao.GetDeposits();
            }
            if (request.LoadOptions.Contains("Deposit"))
            {
                if (request.LoadOptions.Contains("RefNo"))
                {
                    var deposit = DepositDao.GetDepositByRefNo(request.RefNo);
                    if (request.LoadOptions.Contains("IncludeDetail"))
                    {
                        deposit = deposit ?? new DepositEntity();
                        deposit.DepositDetails = DepositDetailDao.GetDepositDetailsByDeposit(deposit.RefId);
                        deposit.DepositDetailParallels = DepositDetailParallelDao.GetDepositDetailParallelByRefId(deposit.RefId);
                    }
                    response.Deposit = deposit;
                }
                else if (request.LoadOptions.Contains("DateMonth"))
                {
                    var deposit = DepositDao.GetDepositBySalary(request.DateMonth);
                    response.Deposit = deposit;
                }
                else
                {
                    var deposit = DepositDao.GetDeposit(request.RefId);
                    if (request.LoadOptions.Contains("IncludeDetail"))
                    {
                        deposit = deposit ?? new DepositEntity();
                        deposit.DepositDetails = DepositDetailDao.GetDepositDetailsByDeposit(deposit.RefId);
                        deposit.DepositDetailParallels = DepositDetailParallelDao.GetDepositDetailParallelByRefId(deposit.RefId);
                    }
                    response.Deposit = deposit;
                }
            }

            return response;

        }

        public DepositResponse SetDeposits(DepositRequest request, bool isAutoGenerateParallel = false)
        {
            var response = new DepositResponse();
            var obJourentryAccount = new JournalEntryAccountEntity();
            IList<JournalEntryAccountEntity> listJournalEntryAccountEntity = new List<JournalEntryAccountEntity>();
            IList<AccountBalanceEntity> listAccountBalanceEntity = new List<AccountBalanceEntity>();

            var depositEntity = request.Deposit;
            if (request.Deposit != null)
            {
                listJournalEntryAccountEntity = GetListJournalEntryAccount(request);
                listAccountBalanceEntity = GetListAccountBalance(request);
            }
            var i = 0;
            if (request.Action != PersistType.Delete)
            {
                if (!depositEntity.Validate())
                {
                    foreach (string error in depositEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
            }
            try
            {
                if (request.Action == PersistType.Insert)
                {
                    using (var scope = new TransactionScope())
                    {
                        #region Kiểm tra có sự tồn tại số chứng từ trong ngày

                        var lstDeposit = DepositDao.GetDepositsByRefNoAndRefDate(depositEntity.RefTypeId, depositEntity.RefNo, depositEntity.RefDate.Value, depositEntity.CurrencyCode).ToList();
                        if (lstDeposit.Count > 0)
                        {
                            if (request.IsConvertData == false)
                            {
                                response.Message = @"Chứng từ: " + depositEntity.RefNo + @" đã tồn tại trong ngày " + depositEntity.RefDate;
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }
                            var rd = new Random();
                            depositEntity.RefNo = depositEntity.RefNo + "_buca" + rd.Next(1, 1000);
                        }

                        #endregion

                        depositEntity.RefId = DepositDao.InsertDeposit(depositEntity);

                        foreach (var depositDetail in depositEntity.DepositDetails)
                        {
                            if (!depositDetail.Validate())
                            {
                                foreach (string error in depositDetail.ValidationErrors)
                                    response.Message += error + Environment.NewLine;
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }
                            // insert bang detail
                            depositDetail.RefId = depositEntity.RefId;
                            var iDepositDetailId = DepositDetailDao.InsertDepositDetail(depositDetail);
                            //LinhMC thêm đoạn kiểm tra việc InsertDepositDetail có thành công hay không? 
                            //Yêu cầu phải có để đảm bảo toàn vẹn dữ liệu
                            if (iDepositDetailId == 0)
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }

                            // insert bang JourentryAccount
                            obJourentryAccount = listJournalEntryAccountEntity[i];
                            obJourentryAccount.RefId = depositDetail.RefId;
                            obJourentryAccount.RefDetailId = iDepositDetailId;

                            #region obJourentryAccount: thay đổi thông tin theo đối tượng Master

                            int accountingObjectType = int.Parse(depositEntity.AccountingObjectType?.ToString(CultureInfo.InvariantCulture));
                            switch (accountingObjectType)
                            {
                                case 0:
                                    obJourentryAccount.VendorId = depositEntity.VendorId;
                                    break;
                                case 1:
                                    obJourentryAccount.EmployeeId = depositEntity.EmployeeId;
                                    break;
                                case 2:
                                    obJourentryAccount.AccountingObjectId = depositEntity.AccountingObjectId;
                                    break;
                                case 3:
                                    obJourentryAccount.CustomerId = depositEntity.CustomerId;
                                    break;
                            }

                            //LinhMC bổ sung trường hợp người dùng chọn đối tượng khác ở phần chi tiết mà không chọn ở phần thông tin chung.
                            if (obJourentryAccount.AccountingObjectId == null)
                            {
                                obJourentryAccount.AccountingObjectId = depositDetail.AccountingObjectId;
                            }

                            #endregion

                            if (!obJourentryAccount.Validate())
                            {
                                foreach (string error in obJourentryAccount.ValidationErrors)
                                    response.Message += error + Environment.NewLine;
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }
                            JournalEntryAccountDao.InsertDoubleJournalEntryAccount(obJourentryAccount);
                            i = i + 1;
                        }

                        // Kiểm tra đã tồn tại trong bảng Account Balance
                        foreach (var accountBe in listAccountBalanceEntity)
                        {
                            var obAccountBe = AccountBalanceDao.GetExitsAccountBalance(accountBe);
                            if (obAccountBe != null)
                            {
                                // cập nhật bên TK nợ
                                if (accountBe.MovementCreditAmountOC == 0)
                                {
                                    obAccountBe.ExchangeRate = accountBe.ExchangeRate;
                                    obAccountBe.MovementDebitAmountExchange = obAccountBe.MovementDebitAmountExchange + accountBe.MovementDebitAmountExchange;
                                    obAccountBe.MovementDebitAmountOC = obAccountBe.MovementDebitAmountOC + accountBe.MovementDebitAmountOC;
                                    AccountBalanceDao.UpdateAccountBalance(obAccountBe);
                                }
                                else
                                {
                                    obAccountBe.ExchangeRate = accountBe.ExchangeRate;
                                    obAccountBe.MovementCreditAmountExchange = obAccountBe.MovementCreditAmountExchange + accountBe.MovementCreditAmountExchange;
                                    obAccountBe.MovementCreditAmountOC = obAccountBe.MovementCreditAmountOC + accountBe.MovementCreditAmountOC;
                                    AccountBalanceDao.UpdateAccountBalance(obAccountBe);
                                }
                            }
                            else
                            {
                                AccountBalanceDao.InsertAccountBalance(accountBe);
                            }
                        }

                        #region Sinh dinh khoan dong thoi

                        if (!isAutoGenerateParallel)
                        {
                            if (depositEntity.DepositDetailParallels != null && depositEntity.DepositDetailParallels.Count > 0)
                            {
                                foreach (var depositDetailParallel in depositEntity.DepositDetailParallels)
                                {
                                    #region Insert DepositDetailParallels

                                    depositDetailParallel.RefId = depositEntity.RefId;
                                    //depositDetailParallel.AmountExchange = depositDetailParallel.AmountOc * depositDetailParallel.AmountExchange;

                                    if (!depositDetailParallel.Validate())
                                    {
                                        foreach (var error in depositDetailParallel.ValidationErrors)
                                            response.Message += error + Environment.NewLine;
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        return response;
                                    }

                                    var depositDetailParallelId = DepositDetailParallelDao.InsertDepositDetailParallel(depositDetailParallel);
                                    if (depositDetailParallelId < 1)
                                    {
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        return response;
                                    }

                                    #region Insert JourentryAccount

                                    var journalEntry = MakeJournalEntryAccount(depositEntity, depositDetailParallel);

                                    journalEntry.JournalEntryId = JournalEntryAccountDao.InsertDoubleJournalEntryAccount(journalEntry);

                                    if (journalEntry.JournalEntryId < 1)
                                    {
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        return response;
                                    }

                                    #endregion

                                    #endregion
                                }
                            }
                        }
                        else
                        {
                            //truong hop sinh tu dong se sinh theo chung tu chi tiet
                            if (depositEntity.DepositDetails != null && depositEntity.DepositDetails.Count > 0)
                            {
                                foreach (var depositDetail in depositEntity.DepositDetails)
                                {
                                    var budgetSourceId = BudgetSourceDao.GetBudgetSourceByBudgetSourceCode(depositDetail.BudgetSourceCode);
                                    var budgetItemId = BudgetItemDao.GetBudgetItemsByCode(depositDetail.BudgetItemCode);

                                    //insert dl moi
                                    var autoBusinessParallelEntitys = AutoBusinessParallelDao.GetAutoBusinessParallelsByAutoBussinessInformations(depositDetail.AccountNumber, depositDetail.CorrespondingAccountNumber, budgetSourceId == null ? 0 : budgetSourceId.BudgetSourceId, (budgetItemId == null || budgetItemId.Count == 0) ? 0 : budgetItemId.FirstOrDefault().BudgetItemId, 0, depositDetail.VoucherTypeId == null ? 0 : (int)depositDetail.VoucherTypeId);

                                    if (autoBusinessParallelEntitys != null)
                                    {
                                        foreach (var autoBusinessParallelEntity in autoBusinessParallelEntitys)
                                        {
                                            #region DepositDetailParallel

                                            var depositDetailParallel = new DepositDetailParallelEntity()
                                            {
                                                RefId = depositEntity.RefId,
                                                Description = depositDetail.Description,
                                                AccountNumber = autoBusinessParallelEntity.DebitAccountParallel,
                                                CorrespondingAccountNumber = autoBusinessParallelEntity.CreditAccountParallel,
                                                AmountExchange = (autoBusinessParallelEntity.IsNegative == true ? depositDetail.AmountOc * -1 : depositDetail.AmountOc) / depositEntity.ExchangeRate,
                                                AmountOc = autoBusinessParallelEntity.IsNegative == true ? depositDetail.AmountOc * -1 : depositDetail.AmountOc,
                                                BudgetSourceCode = depositDetail.BudgetSourceCode,
                                                BudgetItemCode = depositDetail.BudgetItemCode,
                                                AccountingObjectId = depositDetail.AccountingObjectId,
                                                VoucherTypeId = depositDetail.VoucherTypeId,
                                                ProjectId = depositDetail.ProjectId,
                                                MergerFundId = depositDetail.MergerFundId,
                                                DepartmentId = depositDetail.DepartmentId,
                                                CustomerId = depositEntity.CustomerId,
                                                EmployeeId = depositEntity.EmployeeId,
                                                VendorId = depositEntity.VendorId,
                                            };

                                            if (!depositDetailParallel.Validate())
                                            {
                                                foreach (var error in depositDetailParallel.ValidationErrors)
                                                    response.Message += error + Environment.NewLine;
                                                response.Acknowledge = AcknowledgeType.Failure;
                                                return response;
                                            }

                                            depositDetailParallel.RefDetailId = DepositDetailParallelDao.InsertDepositDetailParallel(depositDetailParallel);
                                            if (depositDetailParallel.RefDetailId == 0)
                                            {
                                                response.Acknowledge = AcknowledgeType.Failure;
                                                return response;
                                            }

                                            #endregion

                                            #region Insert JournalEntryAccount

                                            var journalEntry = MakeJournalEntryAccount(depositEntity, depositDetailParallel);

                                            journalEntry.JournalEntryId = JournalEntryAccountDao.InsertDoubleJournalEntryAccount(journalEntry);

                                            if (journalEntry.JournalEntryId < 1)
                                            {
                                                response.Acknowledge = AcknowledgeType.Failure;
                                                return response;
                                            }

                                            #endregion
                                        }
                                    }
                                }
                            }
                        }

                        #endregion

                        // get autoNumer
                        var autoNumber = AutoNumberDao.GetAutoNumberByRefType(depositEntity.RefTypeId);
                        //------------------------------------------------------------------
                        //LinhMC 29/11/2014
                        //Lưu giá trị số tự động tăng theo loại tiền
                        //---------------------------------------------------------------
                        if (depositEntity.CurrencyCode == "USD")
                            autoNumber.Value += 1;
                        else autoNumber.ValueLocalCurency += 1;
                        if (depositEntity.RefTypeId != 600) // Khac chung tu luong
                        {
                            response.Message = AutoNumberDao.UpdateAutoNumber(autoNumber);
                        }

                        if (response.Message != null)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return response;
                        }
                        scope.Complete();
                    }
                }
                else if (request.Action == PersistType.Update)
                {
                    using (var scope = new TransactionScope())
                    {
                        #region Kiểm tra sự tồn tại số chứng từ trong này
                        List<DepositEntity> lstDeposit = DepositDao.GetDepositsByRefNoAndRefDate(depositEntity.RefTypeId, depositEntity.RefNo, depositEntity.RefDate.Value, depositEntity.CurrencyCode).ToList();
                        DepositEntity deposit = DepositDao.GetDeposit(depositEntity.RefId);

                        if (lstDeposit.Count > 0)
                        {
                            if (deposit.RefId != lstDeposit[0].RefId)
                            {
                                response.Message = @"Chứng từ: " + depositEntity.RefNo + @" đã tồn tại trong ngày " + depositEntity.RefDate;
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }
                        }
                        #endregion
                        // Trừ số tiền khi mà update xử lý Bảng cân đối tài khoản////////////////////////////////////
                        listAccountBalanceEntity.Clear();
                        listAccountBalanceEntity = GetListAccountBalanceOlder(depositEntity.RefId);

                        foreach (var accountBe in listAccountBalanceEntity)
                        {
                            var obAccountBe = AccountBalanceDao.GetExitsAccountBalance(accountBe);
                            if (obAccountBe != null)
                            {
                                // cập nhật bên TK nợ
                                if (accountBe.MovementCreditAmountOC == 0)
                                {
                                    obAccountBe.ExchangeRate = accountBe.ExchangeRate;
                                    obAccountBe.MovementDebitAmountExchange = obAccountBe.MovementDebitAmountExchange - accountBe.MovementDebitAmountExchange;
                                    obAccountBe.MovementDebitAmountOC = obAccountBe.MovementDebitAmountOC - accountBe.MovementDebitAmountOC;
                                    AccountBalanceDao.UpdateAccountBalance(obAccountBe);
                                }
                                else
                                {
                                    obAccountBe.ExchangeRate = accountBe.ExchangeRate;
                                    obAccountBe.MovementCreditAmountExchange = obAccountBe.MovementCreditAmountExchange - accountBe.MovementCreditAmountExchange;
                                    obAccountBe.MovementCreditAmountOC = obAccountBe.MovementCreditAmountOC - obAccountBe.MovementCreditAmountOC;
                                    AccountBalanceDao.UpdateAccountBalance(obAccountBe);
                                }
                            }

                        }
                        // Cập nhật lại dữ liệu vào bảng cân đối tài khoản
                        listAccountBalanceEntity.Clear();
                        listAccountBalanceEntity = GetListAccountBalance(request);
                        foreach (var accountBe in listAccountBalanceEntity)
                        {
                            var ojectAb = AccountBalanceDao.GetExitsAccountBalance(accountBe);
                            if (ojectAb != null)
                            {
                                // cập nhật bên TK nợ
                                if (accountBe.MovementCreditAmountOC == 0)
                                {
                                    ojectAb.ExchangeRate = accountBe.ExchangeRate;
                                    ojectAb.MovementDebitAmountExchange = ojectAb.MovementDebitAmountExchange + accountBe.MovementDebitAmountExchange;
                                    ojectAb.MovementDebitAmountOC = ojectAb.MovementDebitAmountOC + accountBe.MovementDebitAmountOC;
                                    AccountBalanceDao.UpdateAccountBalance(ojectAb);
                                }
                                else
                                {
                                    ojectAb.ExchangeRate = accountBe.ExchangeRate;
                                    ojectAb.MovementCreditAmountExchange = ojectAb.MovementCreditAmountExchange + accountBe.MovementCreditAmountExchange;
                                    ojectAb.MovementCreditAmountOC = ojectAb.MovementCreditAmountOC + accountBe.MovementCreditAmountOC;
                                    AccountBalanceDao.UpdateAccountBalance(ojectAb);
                                }
                            }
                            else
                            {
                                AccountBalanceDao.InsertAccountBalance(accountBe);
                            }
                        }
                        // Xóa dữ liệu trống trong bảng Cân đối tài khoản
                        AccountBalanceDao.DeleteAccountBalance();
                        ////////////////////END BANG CAN DOI TAI KHOAN///////////////////////////////////////////////
                        if (depositEntity.RefTypeId == 600)
                        {
                            //Update Lại các mục Khoản lương
                            //Lấy lại số chứng từ cũ thay the số chứng từ mới
                            var objDeposit = DepositDao.GetDeposit(depositEntity.RefId);
                            response.Message = DepositDao.UpdateEmployeePayroll(objDeposit.RefNo, depositEntity.RefNo, depositEntity.PostedDate.Value.Month + "/" + depositEntity.PostedDate.Value.Day + "/" + depositEntity.PostedDate.Value.Year);
                        }

                        response.Message = DepositDao.UpdateDeposit(depositEntity);
                        if (response.Message != null)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return response;
                        }

                        response.Message = DepositDetailDao.DeleteDepositDetailByDepositId(depositEntity.RefId);
                        if (response.Message != null)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return response;
                        }

                        response.Message = DepositDetailParallelDao.DeleteDepositDetailParallelById(depositEntity.RefId);
                        if (response.Message != null)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return response;
                        }

                        obJourentryAccount = listJournalEntryAccountEntity[0];
                        response.Message = JournalEntryAccountDao.DeleteJournalEntryAccount(obJourentryAccount);
                        if (response.Message != null)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return response;
                        }
                        foreach (var depositDetail in depositEntity.DepositDetails)
                        {
                            if (!depositDetail.Validate())
                            {
                                foreach (string error in depositDetail.ValidationErrors)
                                    response.Message += error + Environment.NewLine;
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }
                            depositDetail.RefId = depositEntity.RefId;
                            depositDetail.RefDetailId = DepositDetailDao.InsertDepositDetail(depositDetail);
                            // Insert into JourentryAcocunt
                            obJourentryAccount = listJournalEntryAccountEntity[i];
                            obJourentryAccount.RefId = depositDetail.RefId;
                            obJourentryAccount.RefDetailId = depositDetail.RefDetailId;

                            #region " obJourentryAccount: thay đổi thông tin theo đối tượng Master"
                            int accountingObjectType = int.Parse(depositEntity.AccountingObjectType?.ToString(CultureInfo.InvariantCulture));
                            switch (accountingObjectType)
                            {
                                case 0:
                                    obJourentryAccount.VendorId = depositEntity.VendorId;
                                    break;
                                case 1:
                                    obJourentryAccount.EmployeeId = depositEntity.EmployeeId;
                                    break;
                                case 2:
                                    obJourentryAccount.AccountingObjectId = depositEntity.AccountingObjectId;
                                    break;
                                case 3:
                                    obJourentryAccount.CustomerId = depositEntity.CustomerId;
                                    break;
                            }
                            #endregion

                            if (!obJourentryAccount.Validate())
                            {
                                foreach (string error in obJourentryAccount.ValidationErrors)
                                    response.Message += error + Environment.NewLine;
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }
                            JournalEntryAccountDao.InsertDoubleJournalEntryAccount(obJourentryAccount);
                            i = i + 1;
                        }

                        #region Sinh dinh khoan dong thoi

                        //neu khong tu dong sinh dinh khoan dong thoi -> lay theo grid dinh khoan dong thoi
                        if (!isAutoGenerateParallel)
                        {
                            #region CAReceiptDetailParallel

                            if (depositEntity.DepositDetailParallels != null)
                            {
                                //insert dl moi
                                foreach (var depositDetailParallel in depositEntity.DepositDetailParallels)
                                {
                                    #region Insert Receipt Detail Parallel

                                    depositDetailParallel.RefId = depositEntity.RefId;
                                    //depositDetailParallel.RefDetailId = Guid.NewGuid().ToString();
                                    depositDetailParallel.AmountExchange = depositDetailParallel.AmountOc * depositEntity.ExchangeRate;

                                    if (!depositDetailParallel.Validate())
                                    {
                                        foreach (var error in depositDetailParallel.ValidationErrors)
                                            response.Message += error + Environment.NewLine;
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        return response;
                                    }

                                    var depositDetailParallelId = DepositDetailParallelDao.InsertDepositDetailParallel(depositDetailParallel);
                                    if (depositDetailParallelId == 0)
                                    {
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        return response;
                                    }

                                    #endregion

                                    #region JournalEntryAccount
                                    var journalEntry = MakeJournalEntryAccount(depositEntity, depositDetailParallel);

                                    journalEntry.JournalEntryId = JournalEntryAccountDao.InsertDoubleJournalEntryAccount(journalEntry);

                                    if (journalEntry.JournalEntryId < 1)
                                    {
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        return response;
                                    }

                                    #endregion
                                }
                            }

                            #endregion
                        }
                        else
                        {
                            //truong hop sinh tu dong se sinh theo chung tu chi tiet
                            foreach (var depositDetail in depositEntity.DepositDetails)
                            {
                                var budgetSourceId = BudgetSourceDao.GetBudgetSourceByBudgetSourceCode(depositDetail.BudgetSourceCode);
                                var budgetItemId = BudgetItemDao.GetBudgetItemsByCode(depositDetail.BudgetItemCode);

                                //insert dl moi
                                var autoBusinessParallelEntitys = AutoBusinessParallelDao.GetAutoBusinessParallelsByAutoBussinessInformations(depositDetail.AccountNumber, depositDetail.CorrespondingAccountNumber, budgetSourceId == null ? 0 : budgetSourceId.BudgetSourceId, (budgetItemId == null || budgetItemId.Count == 0) ? 0 : budgetItemId.FirstOrDefault().BudgetItemId, 0, depositDetail.VoucherTypeId == null ? 0 : (int)depositDetail.VoucherTypeId);

                                if (autoBusinessParallelEntitys != null)
                                {
                                    foreach (var autoBusinessParallelEntity in autoBusinessParallelEntitys)
                                    {
                                        #region DepositDetailParallel

                                        var depositDetailParallel = new DepositDetailParallelEntity()
                                        {
                                            RefId = depositEntity.RefId,
                                            Description = depositDetail.Description,
                                            AccountNumber = autoBusinessParallelEntity.DebitAccountParallel,
                                            CorrespondingAccountNumber = autoBusinessParallelEntity.CreditAccountParallel,
                                            AmountExchange = autoBusinessParallelEntity.IsNegative == true ? depositDetail.AmountExchange * -1 : depositDetail.AmountExchange,//(autoBusinessParallelEntity.IsNegative == true ? depositDetail.AmountOc * -1 : depositDetail.AmountOc) / depositEntity.ExchangeRate,
                                            AmountOc = autoBusinessParallelEntity.IsNegative == true ? depositDetail.AmountOc * -1 : depositDetail.AmountOc,
                                            BudgetSourceCode = depositDetail.BudgetSourceCode,
                                            BudgetItemCode = depositDetail.BudgetItemCode,
                                            AccountingObjectId = depositDetail.AccountingObjectId,
                                            VoucherTypeId = depositDetail.VoucherTypeId,
                                            ProjectId = depositDetail.ProjectId,
                                            MergerFundId = depositDetail.MergerFundId,
                                            DepartmentId = depositDetail.DepartmentId,
                                            CustomerId = depositEntity.CustomerId,
                                            EmployeeId = depositEntity.EmployeeId,
                                            VendorId = depositEntity.VendorId,
                                        };
                                        if (!depositDetailParallel.Validate())
                                        {
                                            foreach (var error in depositDetailParallel.ValidationErrors)
                                                response.Message += error + Environment.NewLine;
                                            response.Acknowledge = AcknowledgeType.Failure;
                                            return response;
                                        }

                                        depositDetailParallel.RefDetailId = DepositDetailParallelDao.InsertDepositDetailParallel(depositDetailParallel);
                                        if (depositDetailParallel.RefDetailId == 0)
                                        {
                                            response.Acknowledge = AcknowledgeType.Failure;
                                            return response;
                                        }

                                        #endregion

                                        #region Insert JournalEntryAccount

                                        var journalEntry = MakeJournalEntryAccount(depositEntity, depositDetailParallel);

                                        journalEntry.JournalEntryId = JournalEntryAccountDao.InsertDoubleJournalEntryAccount(journalEntry);

                                        if (journalEntry.JournalEntryId < 1)
                                        {
                                            response.Acknowledge = AcknowledgeType.Failure;
                                            return response;
                                        }

                                        #endregion
                                    }
                                }
                            }
                        }

                        #endregion

                        scope.Complete();
                    }
                }
                //////////////////////////////Xóa chứng từ///////////////////////////////////////////////////////
                else
                {
                    var generalVoucher = new GeneralEntity();
                    using (var scope = new TransactionScope())
                    {
                        
                        var depositVoucherEntityForDelete = DepositDao.GetDeposit(request.RefId);
                        var details = DepositDetailDao.GetDepositDetailsByDeposit(request.RefId);
                        generalVoucher = GeneralFacede.GetGeneralVoucher(depositVoucherEntityForDelete.RefTypeId, depositVoucherEntityForDelete.RefId);
                        //// Có phải là chứng từ lương không?
                        //if (receiptVoucherEntityForDelete.RefTypeId == 600)
                        //{
                        //    response.Acknowledge = AcknowledgeType.Failure;
                        //    response.Message = @"Bạn không xóa chứng từ lương tại đây, bạn phải hủy tính lương";
                        //    return response;
                        //}
                        response.Message = DepositDao.DeleteDeposit(depositVoucherEntityForDelete);

                        // Xóa bảng JourentryAccount
                        obJourentryAccount.RefId = depositVoucherEntityForDelete.RefId;
                        obJourentryAccount.RefTypeId = depositVoucherEntityForDelete.RefTypeId;
                        obJourentryAccount.RefNo = depositVoucherEntityForDelete.RefNo;
                        response.Message = JournalEntryAccountDao.DeleteJournalEntryAccount(obJourentryAccount);
                        // Cập nhật lại dữ liệu vào bảng cân đối tài khoản
                        listAccountBalanceEntity.Clear();
                        request.Deposit = depositVoucherEntityForDelete;
                        request.Deposit.DepositDetails = details;
                        listAccountBalanceEntity = GetListAccountBalance(request);
                        foreach (var accountBe in listAccountBalanceEntity)
                        {
                            var ojectAb = AccountBalanceDao.GetExitsAccountBalance(accountBe);
                            if (ojectAb != null)
                            {
                                // cập nhật bên TK nợ
                                if (accountBe.MovementCreditAmountOC == 0)
                                {
                                    ojectAb.ExchangeRate = accountBe.ExchangeRate;
                                    ojectAb.MovementDebitAmountExchange = ojectAb.MovementDebitAmountExchange - accountBe.MovementDebitAmountExchange;
                                    ojectAb.MovementDebitAmountOC = ojectAb.MovementDebitAmountOC - accountBe.MovementDebitAmountOC;
                                    AccountBalanceDao.UpdateAccountBalance(ojectAb);
                                }
                                else
                                {
                                    ojectAb.ExchangeRate = accountBe.ExchangeRate;
                                    ojectAb.MovementCreditAmountExchange = ojectAb.MovementCreditAmountExchange - accountBe.MovementCreditAmountExchange;
                                    ojectAb.MovementCreditAmountOC = ojectAb.MovementCreditAmountOC - accountBe.MovementCreditAmountOC;
                                    AccountBalanceDao.UpdateAccountBalance(ojectAb);
                                }
                            }
                        }
                        // Xóa dữ liệu trống trong bảng Cân đối tài khoản
                        AccountBalanceDao.DeleteAccountBalance();
                        // Xóa thông tin lương nhân viên đã tính
                        //if (receiptVoucherEntityForDelete.RefTypeId == 600)
                        //{
                        //    response.Message = DepositDao.DeleteEmployeePayroll(receiptVoucherEntityForDelete.RefNo,
                        //       receiptVoucherEntityForDelete.PostedDate.Month + "/" + receiptVoucherEntityForDelete.PostedDate.Day + "/" + receiptVoucherEntityForDelete.PostedDate.Year);
                        //}

                        response.Message = DepositDetailParallelDao.DeleteDepositDetailParallelById(request.RefId);
                        if (response.Message != null)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return response;
                        }

                        scope.Complete();
                    }

                    if (response.Acknowledge == AcknowledgeType.Success && generalVoucher != null)
                    {
                        // Xóa bảng GeneralVoucher
                        var generalVoucherRequest = new GeneralRequest();
                        generalVoucherRequest.Action = PersistType.Delete;
                        generalVoucherRequest.RefId = generalVoucher.RefId;
                        response.Message = GeneralFacede.SetGenerals(generalVoucherRequest).Message;
                    }
                }
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }

            response.RefId = depositEntity != null ? depositEntity.RefId : 0;
            response.Acknowledge = response.Message != null ? AcknowledgeType.Failure : AcknowledgeType.Success;
            return response;
        }

        public IList<JournalEntryAccountEntity> GetListJournalEntryAccount(DepositRequest request)
        {
            var depositEntity = request.Deposit;
            // var obJourentryAccount = new JournalEntryAccountEntity();
            IList<JournalEntryAccountEntity> obListJournalEntryAccountEntity = new List<JournalEntryAccountEntity>();
            foreach (var depositDetail in depositEntity.DepositDetails)
            {
                var iDepositDetailId = depositDetail.RefDetailId;
                var obJourentryAccount = new JournalEntryAccountEntity
                {
                    RefId = depositEntity.RefId,
                    RefTypeId = depositEntity.RefTypeId,
                    RefNo = depositEntity.RefNo,
                    RefDate = depositEntity.RefDate.Value,
                    PostedDate = depositEntity.PostedDate.Value,
                    JournalMemo = depositEntity.JournalMemo,
                    CurrencyCode = depositEntity.CurrencyCode,
                    ExchangeRate = depositEntity.ExchangeRate,
                    BankAccount = depositEntity.BankAccountCode,
                    RefDetailId = iDepositDetailId,
                    BankId = depositEntity.BankId,
                    AccountNumber = depositDetail.AccountNumber,
                    CorrespondingAccountNumber = depositDetail.CorrespondingAccountNumber,
                    AmountOc = depositDetail.AmountOc,
                    Description = depositDetail.Description,
                    AmountExchange = depositDetail.AmountExchange,
                    BudgetSourceCode = depositDetail.BudgetSourceCode,
                    BudgetItemCode = depositDetail.BudgetItemCode,
                    AccountingObjectId = depositDetail.AccountingObjectId,
                    MergerFundId = depositDetail.MergerFundId,
                    VoucherTypeId = depositDetail.VoucherTypeId,
                    ProjectId = depositDetail.ProjectId
                };
                // Chèn dữ liệu phần Details

                obListJournalEntryAccountEntity.Add(obJourentryAccount);
            }


            return obListJournalEntryAccountEntity;
        }

        public IList<AccountBalanceEntity> GetListAccountBalance(DepositRequest request)
        {
            var depositEntity = request.Deposit;
            IList<AccountBalanceEntity> obListAccountBalanceEntity = new List<AccountBalanceEntity>();
            foreach (var depositDetail in depositEntity.DepositDetails)
            {
                var obAccountBalanceEntity = new AccountBalanceEntity
                {
                    BalanceDate = depositEntity.PostedDate.Value,
                    CurrencyCode = depositEntity.CurrencyCode,
                    ExchangeRate = depositEntity.ExchangeRate,
                    AccountNumber = depositDetail.AccountNumber,
                    MovementDebitAmountOC = depositDetail.AmountOc,
                    MovementDebitAmountExchange = depositDetail.AmountExchange,
                    BudgetSourceCode = depositDetail.BudgetSourceCode,
                    BudgetItemCode = depositDetail.BudgetItemCode,
                    ProjectId = depositDetail.ProjectId,
                    MovementCreditAmountOC = 0,
                    MovementCreditAmountExchange = 0
                };
                //Dòng tài khoản nợ
                obListAccountBalanceEntity.Add(obAccountBalanceEntity);
                // Dòng tài khoản có
                var obAccountBalanceEntity1 = new AccountBalanceEntity
                {
                    BalanceDate = depositEntity.PostedDate.Value,
                    CurrencyCode = depositEntity.CurrencyCode,
                    ExchangeRate = depositEntity.ExchangeRate,
                    AccountNumber = depositDetail.CorrespondingAccountNumber,
                    MovementCreditAmountOC = depositDetail.AmountOc,
                    MovementCreditAmountExchange = depositDetail.AmountExchange,
                    BudgetSourceCode = depositDetail.BudgetSourceCode,
                    BudgetItemCode = depositDetail.BudgetItemCode,
                    ProjectId = depositDetail.ProjectId,
                    MovementDebitAmountOC = 0,
                    MovementDebitAmountExchange = 0
                };

                obListAccountBalanceEntity.Add(obAccountBalanceEntity1);
            }

            return obListAccountBalanceEntity;
        }

        public IList<AccountBalanceEntity> GetListAccountBalanceOlder(long refId)
        {
            var depositEntity = DepositDao.GetDeposit(refId);
            depositEntity.DepositDetails = DepositDetailDao.GetDepositDetailsByDeposit(refId);
            IList<AccountBalanceEntity> obListAccountBalanceEntity = new List<AccountBalanceEntity>();
            foreach (var depositDetail in depositEntity.DepositDetails)
            {
                var obAccountBalanceEntity = new AccountBalanceEntity
                {
                    BalanceDate = depositEntity.PostedDate.Value,
                    CurrencyCode = depositEntity.CurrencyCode,
                    ExchangeRate = depositEntity.ExchangeRate,
                    AccountNumber = depositDetail.AccountNumber,
                    MovementDebitAmountOC = depositDetail.AmountOc,
                    MovementDebitAmountExchange = depositDetail.AmountExchange,
                    BudgetSourceCode = depositDetail.BudgetSourceCode,
                    BudgetItemCode = depositDetail.BudgetItemCode,
                    ProjectId = depositDetail.ProjectId,
                    MovementCreditAmountOC = 0,
                    MovementCreditAmountExchange = 0
                };
                //Dòng tài khoản nợ
                obListAccountBalanceEntity.Add(obAccountBalanceEntity);
                // Dòng tài khoản có
                var obAccountBalanceEntity1 = new AccountBalanceEntity
                {
                    BalanceDate = depositEntity.PostedDate.Value,
                    CurrencyCode = depositEntity.CurrencyCode,
                    ExchangeRate = depositEntity.ExchangeRate,
                    AccountNumber = depositDetail.CorrespondingAccountNumber,
                    MovementCreditAmountOC = depositDetail.AmountOc,
                    MovementCreditAmountExchange = depositDetail.AmountExchange,
                    BudgetSourceCode = depositDetail.BudgetSourceCode,
                    BudgetItemCode = depositDetail.BudgetItemCode,
                    ProjectId = depositDetail.ProjectId,
                    MovementDebitAmountOC = 0,
                    MovementDebitAmountExchange = 0
                };

                obListAccountBalanceEntity.Add(obAccountBalanceEntity1);
            }

            return obListAccountBalanceEntity;
        }


        public JournalEntryAccountEntity MakeJournalEntryAccount(DepositEntity deposit, DepositDetailParallelEntity depositParallelDetail)
        {
            var journalEntryAccount = new JournalEntryAccountEntity();
            if (depositParallelDetail != null)
            {
                journalEntryAccount.RefDetailId = depositParallelDetail.RefDetailId;
                journalEntryAccount.RefId = depositParallelDetail.RefId;
                journalEntryAccount.RefTypeId = deposit.RefTypeId;
                journalEntryAccount.RefNo = deposit.RefNo;
                journalEntryAccount.RefDate = deposit.RefDate.Value;
                journalEntryAccount.PostedDate = deposit.PostedDate.Value;
                journalEntryAccount.Description = depositParallelDetail.Description;
                journalEntryAccount.JournalMemo = deposit.JournalMemo;
                journalEntryAccount.CurrencyCode = deposit.CurrencyCode;
                journalEntryAccount.ExchangeRate = deposit.ExchangeRate;
                journalEntryAccount.AccountNumber = depositParallelDetail.AccountNumber;
                journalEntryAccount.CorrespondingAccountNumber = depositParallelDetail.CorrespondingAccountNumber;
                //journalEntryAccount.Quantity = cashParallelDetail.Quan;
                //journalEntryAccount.JournalType = 
                journalEntryAccount.AmountOc = depositParallelDetail.AmountOc;
                journalEntryAccount.AmountExchange = depositParallelDetail.AmountExchange;
                journalEntryAccount.BudgetSourceCode = depositParallelDetail.BudgetSourceCode;
                journalEntryAccount.BudgetItemCode = depositParallelDetail.BudgetItemCode;
                journalEntryAccount.CustomerId = deposit.CustomerId;
                journalEntryAccount.VendorId = deposit.VendorId;
                journalEntryAccount.EmployeeId = deposit.EmployeeId;
                journalEntryAccount.AccountingObjectId = deposit.AccountingObjectId;
                journalEntryAccount.VoucherTypeId = depositParallelDetail.VoucherTypeId;
                journalEntryAccount.MergerFundId = depositParallelDetail.MergerFundId;
                journalEntryAccount.ProjectId = depositParallelDetail.ProjectId;
                //journalEntryAccount.InventoryItemId = cashParallelDetail.InventoryItemId;
                //journalEntryAccount.BankId = cashParallelDetail.BankId;
                //journalEntryAccount.BankAccount 
            }
            return journalEntryAccount;
        }
        public JournalEntryAccountEntity MakeJournalEntryAccount(DepositEntity deposit, DepositDetailEntity depositDetail)
        {
            var journalEntryAccount = new JournalEntryAccountEntity();
            if (depositDetail != null)
            {
                journalEntryAccount.RefDetailId = depositDetail.RefDetailId;
                journalEntryAccount.RefId = depositDetail.RefId;
                journalEntryAccount.RefTypeId = deposit.RefTypeId;
                journalEntryAccount.RefNo = deposit.RefNo;
                journalEntryAccount.RefDate = deposit.RefDate.Value;
                journalEntryAccount.PostedDate = deposit.PostedDate.Value;
                journalEntryAccount.Description = depositDetail.Description;
                journalEntryAccount.JournalMemo = deposit.JournalMemo;
                journalEntryAccount.CurrencyCode = deposit.CurrencyCode;
                journalEntryAccount.ExchangeRate = deposit.ExchangeRate;
                journalEntryAccount.AccountNumber = depositDetail.AccountNumber;
                journalEntryAccount.CorrespondingAccountNumber = depositDetail.CorrespondingAccountNumber;
                //journalEntryAccount.Quantity = cashParallelDetail.Quan;
                //journalEntryAccount.JournalType = 
                journalEntryAccount.AmountOc = depositDetail.AmountOc;
                journalEntryAccount.AmountExchange = depositDetail.AmountExchange;
                journalEntryAccount.BudgetSourceCode = depositDetail.BudgetSourceCode;
                journalEntryAccount.BudgetItemCode = depositDetail.BudgetItemCode;
                journalEntryAccount.CustomerId = deposit.CustomerId;
                journalEntryAccount.VendorId = deposit.VendorId;
                journalEntryAccount.EmployeeId = deposit.EmployeeId;
                journalEntryAccount.AccountingObjectId = deposit.AccountingObjectId;
                journalEntryAccount.VoucherTypeId = depositDetail.VoucherTypeId;
                journalEntryAccount.MergerFundId = depositDetail.MergerFundId;
                journalEntryAccount.ProjectId = depositDetail.ProjectId;
                //journalEntryAccount.InventoryItemId = cashParallelDetail.InventoryItemId;
                //journalEntryAccount.BankId = cashParallelDetail.BankId;
                //journalEntryAccount.BankAccount 
            }
            return journalEntryAccount;
        }
    }
}

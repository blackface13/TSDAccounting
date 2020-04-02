/***********************************************************************
 * <copyright file="CashFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Hoàng Bích Sơn
 * Email:    sonhb@buca.vn
 * Website:
 * Create Date: Tuesday, March 18, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 25/9/2014    LinhMC  Them dieu kien kiem tra trung so chung tu: neu la chuyen doi du lieu thi khong check
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using TSD.AccountingSoft.BusinessComponents.Facade.General;
using TSD.AccountingSoft.BusinessComponents.Messages.Cash;
using TSD.AccountingSoft.BusinessComponents.Messages.General;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Business;
using TSD.AccountingSoft.BusinessEntities.Business.Cash;
using TSD.AccountingSoft.BusinessEntities.Business.General;
using TSD.AccountingSoft.BusinessEntities.Dictionary;
using TSD.AccountingSoft.DataAccess.IEntitiesDao;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Cash;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary;
using TSD.Enum;

namespace TSD.AccountingSoft.BusinessComponents.Facade.Cash
{
    /// <summary>
    /// CashFacade class
    /// </summary>
    public class CashFacade
    {
        private static readonly ICashDao CashDao = DataAccess.DataAccess.CashDao;
        private static readonly ICashDetailDao CashDetailDao = DataAccess.DataAccess.CashDetailDao;
        private static readonly IAutoNumberDao AutoNumberDao = DataAccess.DataAccess.AutoNumberDao;
        private static readonly IJournalEntryAccountDao JournalEntryAccountDao = DataAccess.DataAccess.JournalEntryAccountDao;
        private static readonly IAccountBalanceDao AccountBalanceDao = DataAccess.DataAccess.AccountBalanceDao;
        private static readonly IAutoBusinessParallelDao AutoBusinessParallelDao = DataAccess.DataAccess.AutoBusinessParallelDao;
        private static readonly IBudgetSourceDao BudgetSourceDao = DataAccess.DataAccess.BudgetSourceDao;
        private static readonly IBudgetItemDao BudgetItemDao = DataAccess.DataAccess.BudgetItemDao;
        private static readonly GeneralFacade GeneralFacede = new GeneralFacade();

        /// <summary>
        /// Gets the cashess.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public CashResponse GetCashes(CashRequest request)
        {
            var response = new CashResponse();
            if (request.LoadOptions.Contains("Cashes"))
            {
                response.Cashes = CashDao.GetCashesByRefTypeId(request.RefTypeId, request.Year);
            }

            if (request.LoadOptions.Contains("Cash"))
            {
                if (request.LoadOptions.Contains("RefNo"))
                {
                    var cash = CashDao.GetCashForSalaryByRefNo(request.RefNo);
                    response.Cash = cash;
                }
                else if (request.LoadOptions.Contains("DateMonth"))
                {
                    var cash = CashDao.GetCashForSalaryByDateMonth(request.DateMonth);
                    response.Cash = cash;
                }
                else
                {
                    var cash = CashDao.GetCash(request.RefId);
                    if (request.LoadOptions.Contains("IncludeDetail"))
                    {
                        cash = cash ?? new CashEntity();
                        cash.CashDetails = CashDetailDao.GetCashDetailsByCash(cash.RefId);
                        cash.CashParalellDetails = CashDetailDao.GetReceiptDetailsParalellbyCash(cash.RefId);
                    }
                    response.Cash = cash;
                }

            }
            return response;
        }

        /// <summary>
        /// Sets the estimates.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public CashResponse SetCashes(CashRequest request)
        {
            var response = new CashResponse();
            var cashEntity = request.CashEntity;
            var obJourentryAccount = new JournalEntryAccountEntity();
            IList<JournalEntryAccountEntity> listJournalEntryAccountEntity = new List<JournalEntryAccountEntity>();
            IList<AccountBalanceEntity> listAccountBalanceEntity = new List<AccountBalanceEntity>();
            if (request.CashEntity != null)
            {
                listJournalEntryAccountEntity = GetListJournalEntryAccount(request);
                listAccountBalanceEntity = GetListAccountBalance(request);
            }
            var i = 0;
            if (request.Action != PersistType.Delete)
            {
                if (!cashEntity.Validate())
                {
                    foreach (string error in cashEntity.ValidationErrors)
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
                        #region Kiểm tra sự tồn tại chứng từ trong ngày

                        List<JournalEntryAccountEntity> lstJournalEntry = JournalEntryAccountDao.GetJournalEntryAccountByRefNoRefDate(cashEntity.RefNo, cashEntity.RefDate)
                                                  .ToList();
                        if (lstJournalEntry.Count > 0)
                        {
                            if (request.IsConvertData == false)
                            {
                                response.Message = @"Chứng từ: " + cashEntity.RefNo + @" đã tồn tại trong ngày " + cashEntity.RefDate.ToShortDateString();
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }
                            var rd = new Random();
                            cashEntity.RefNo = cashEntity.RefNo + "_buca" + rd.Next(1, 1000);
                        }

                        #endregion

                        cashEntity.RefId = CashDao.InsertCash(cashEntity);
                        foreach (var cashDetail in cashEntity.CashDetails)
                        {
                            if (!cashDetail.Validate())
                            {
                                foreach (string error in cashDetail.ValidationErrors)
                                    response.Message += error + Environment.NewLine;
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }
                            cashDetail.RefId = cashEntity.RefId;
                            if (!cashEntity.IsIncludeCharge)
                            {
                                cashDetail.Charge = 0;
                                cashDetail.ChargeExchange = 0;
                            }
                            var iCashDetailId = CashDetailDao.InsertCashDetail(cashDetail);
                            //------------------------------------------------------------------
                            //LinhMC thêm đoạn kiểm tra việc InsertCashDetail có thành công hay không? 
                            //Yêu cầu phải có để đảm bảo toàn vẹn dữ liệu
                            if (iCashDetailId == 0)
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }
                            // insert bang JourentryAccount
                            obJourentryAccount = listJournalEntryAccountEntity[i];
                            obJourentryAccount.RefId = cashDetail.RefId;
                            obJourentryAccount.RefDetailId = iCashDetailId;
                            #region " obJourentryAccount: thay đổi thông tin theo đối tượng Master"
                            int accountingObjectType = cashEntity.AccountingObjectType == null ? 0 : int.Parse(cashEntity.AccountingObjectType.ToString());
                            switch (accountingObjectType)
                            {
                                case 0:
                                    obJourentryAccount.VendorId = cashEntity.VendorId;
                                    break;
                                case 1:
                                    obJourentryAccount.EmployeeId = cashEntity.EmployeeId;
                                    break;
                                case 2:
                                    obJourentryAccount.AccountingObjectId = cashEntity.AccountingObjectId;
                                    break;
                                case 3:
                                    obJourentryAccount.CustomerId = cashEntity.CustomerId;
                                    break;
                            }

                            //LinhMC bổ sung trường hợp người dùng chọn đối tượng khác ở phần chi tiết mà không chọn ở phần thông tin chung.
                            if (obJourentryAccount.AccountingObjectId == null)
                            {
                                obJourentryAccount.AccountingObjectId = cashDetail.AccountingObjectId;
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
                        foreach (var accountBalanceEntity in listAccountBalanceEntity)
                        {
                            var obAccoutBalanceExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceEntity);
                            if (obAccoutBalanceExit != null)
                            {
                                // cập nhật bên TK nợ
                                if (accountBalanceEntity.MovementCreditAmountOC == 0)
                                {
                                    obAccoutBalanceExit.ExchangeRate = accountBalanceEntity.ExchangeRate;
                                    obAccoutBalanceExit.MovementDebitAmountExchange =
                                        obAccoutBalanceExit.MovementDebitAmountExchange +
                                        accountBalanceEntity.MovementDebitAmountExchange;
                                    obAccoutBalanceExit.MovementDebitAmountOC =
                                        obAccoutBalanceExit.MovementDebitAmountOC +
                                        accountBalanceEntity.MovementDebitAmountOC;
                                    AccountBalanceDao.UpdateAccountBalance(obAccoutBalanceExit);
                                }
                                else
                                {
                                    obAccoutBalanceExit.ExchangeRate = accountBalanceEntity.ExchangeRate;
                                    obAccoutBalanceExit.MovementCreditAmountExchange =
                                        obAccoutBalanceExit.MovementCreditAmountExchange +
                                        accountBalanceEntity.MovementCreditAmountExchange;
                                    obAccoutBalanceExit.MovementCreditAmountOC =
                                        obAccoutBalanceExit.MovementCreditAmountOC +
                                        accountBalanceEntity.MovementCreditAmountOC;
                                    AccountBalanceDao.UpdateAccountBalance(obAccoutBalanceExit);
                                }
                            }
                            else
                            {
                                AccountBalanceDao.InsertAccountBalance(accountBalanceEntity);
                            }
                        }
                        var autoNumber = AutoNumberDao.GetAutoNumberByRefType(cashEntity.RefTypeId);
                        //------------------------------------------------------------------
                        //LinhMC 29/11/2014
                        //Lưu giá trị số tự động tăng theo loại tiền
                        //---------------------------------------------------------------
                        if (cashEntity.CurrencyCode == "USD")
                            autoNumber.Value += 1;
                        else autoNumber.ValueLocalCurency += 1;
                        if (cashEntity.RefTypeId != 600)//Khong cap nhat khi la chung tu luong
                        {
                            response.Message = AutoNumberDao.UpdateAutoNumber(autoNumber);
                        }

                        #region Sinh dinh khoan dong thoi

                        i = 0;
                        if (!request.isAutoGenerateParallel) //trường hợp k sinh định khoản tự động 
                        {
                            foreach (var cashParalellDetail in cashEntity.CashParalellDetails)
                            {
                                #region Insert detail parallel

                                if (!cashParalellDetail.Validate())
                                {
                                    foreach (string error in cashParalellDetail.ValidationErrors)
                                        response.Message += error + Environment.NewLine;
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }
                                cashParalellDetail.RefId = cashEntity.RefId;
                                cashParalellDetail.RefDetailId = CashDetailDao.InsertReceiptDetailParalell(cashParalellDetail);
                                if (cashParalellDetail.RefDetailId == 0)
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }

                                #endregion

                                #region Insert journalEntryAccount

                                var journalEntryAccount = MakeJournalEntryAccount(cashEntity, cashParalellDetail);
                                if (!journalEntryAccount.Validate())
                                {
                                    foreach (string error in journalEntryAccount.ValidationErrors)
                                        response.Message += error + Environment.NewLine;
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }
                                JournalEntryAccountDao.InsertDoubleJournalEntryAccount(journalEntryAccount);

                                #endregion

                                i = i + 1;
                            }

                        }
                        else //sinh định khoản tự động 
                        {
                            foreach (var cashDetail in cashEntity.CashDetails)
                            {
                                if (!cashDetail.Validate())
                                {
                                    foreach (string error in cashDetail.ValidationErrors)
                                        response.Message += error + Environment.NewLine;
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }

                                var budgetSource = BudgetSourceDao.GetBudgetSourceByBudgetSourceCode(cashDetail.BudgetSourceCode);
                                var budgetItem = BudgetItemDao.GetBudgetItemsByCode(cashDetail.BudgetItemCode);
                                var autoBusinessParallelEntities = AutoBusinessParallelDao.GetAutoBusinessParallelsByAutoBussinessInformations(
                                       cashDetail.AccountNumber,
                                       cashDetail.CorrespondingAccountNumber,
                                       (cashDetail.BudgetSourceCode == null || budgetSource == null) ? 0 : budgetSource.BudgetSourceId,
                                       budgetItem.Count == 0 ? 0 : budgetItem.FirstOrDefault().BudgetItemId,
                                       0,
                                       cashDetail.VoucherTypeId == null ? 0 : (int)cashDetail.VoucherTypeId);
                                foreach (var autoBusinessParallelEntity in autoBusinessParallelEntities)
                                {
                                    #region Insert detail Parallel

                                    var budgetItemsParalell = BudgetItemDao.GetBudgetItem(autoBusinessParallelEntity.BudgetItemId) == null ? null : BudgetItemDao.GetBudgetItem(autoBusinessParallelEntity.BudgetItemId).BudgetItemCode;
                                    var budgetSoucreParalell = BudgetSourceDao.GetBudgetSource(autoBusinessParallelEntity.BudgetSourceId) == null ? null : BudgetSourceDao.GetBudgetSource(autoBusinessParallelEntity.BudgetSourceId).BudgetSourceCode;
                                    var cashParalellDetail = new CashParalellDetailEntity();

                                    cashParalellDetail.RefId = cashEntity.RefId;
                                    cashParalellDetail.AccountNumber = autoBusinessParallelEntity.DebitAccountParallel;
                                    cashParalellDetail.CorrespondingAccountNumber = autoBusinessParallelEntity.CreditAccountParallel;
                                    cashParalellDetail.AmountOc = autoBusinessParallelEntity.IsNegative == true ? cashDetail.AmountOc * (-1) : cashDetail.AmountOc;
                                    cashParalellDetail.AmountExchange = autoBusinessParallelEntity.IsNegative == true ? cashDetail.AmountExchange * (-1) : cashDetail.AmountExchange;
                                    cashParalellDetail.Description = cashDetail.Description;
                                    cashParalellDetail.AutoBusinessId = cashDetail.AutoBusinessId;
                                    cashParalellDetail.AccountingObjectId = cashDetail.AccountingObjectId;
                                    cashParalellDetail.MergerFundId = cashDetail.MergerFundId;
                                    cashParalellDetail.ProjectId = cashDetail.ProjectId;
                                    cashParalellDetail.IsInserted = cashDetail.IsInserted;
                                    cashParalellDetail.VoucherTypeId = autoBusinessParallelEntity.VoucherTypeId == null ? cashDetail.VoucherTypeId : (int)autoBusinessParallelEntity.VoucherTypeIdParallel;
                                    cashParalellDetail.BudgetSourceCode = budgetSoucreParalell ?? cashDetail.BudgetSourceCode;
                                    cashParalellDetail.BudgetItemCode = budgetItemsParalell ?? cashDetail.BudgetItemCode;
                                    cashParalellDetail.VoucherTypeId = cashDetail.VoucherTypeId ?? cashDetail.VoucherTypeId;

                                    cashParalellDetail.RefDetailId = CashDetailDao.InsertReceiptDetailParalell(cashParalellDetail);

                                    if (cashParalellDetail.RefDetailId == 0)
                                    {
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        return response;
                                    }

                                    #endregion

                                    #region Insert journalEntryAccount

                                    var journalEntryAccount = MakeJournalEntryAccount(cashEntity, cashParalellDetail);
                                    if (!journalEntryAccount.Validate())
                                    {
                                        foreach (string error in journalEntryAccount.ValidationErrors)
                                            response.Message += error + Environment.NewLine;
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        return response;
                                    }
                                    JournalEntryAccountDao.InsertDoubleJournalEntryAccount(journalEntryAccount);

                                    #endregion
                                }
                                i = i + 1;
                            }
                        }

                        #endregion


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

                        #region Kiểm tra sự tồn tại chứng từ trong ngày

                        List<JournalEntryAccountEntity> lstJournalEntry = JournalEntryAccountDao.GetJournalEntryAccountByRefNoRefDate(cashEntity.RefNo, cashEntity.RefDate)
                                                  .ToList();
                        if (lstJournalEntry.Count > 0)
                        {
                            if (cashEntity.RefId != lstJournalEntry[0].RefId)
                            {
                                response.Message = @"Chứng từ: " + cashEntity.RefNo + @" đã tồn tại trong ngày " + cashEntity.RefDate.ToShortDateString();
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }
                        }

                        #endregion



                        // Trừ số tiền khi mà update xử lý Bảng cân đối tài khoản////////////////////////////////////
                        listAccountBalanceEntity.Clear();
                        listAccountBalanceEntity = GetListAccountBalanceOlder(cashEntity.RefId);
                        foreach (var accountBalanceEntity in listAccountBalanceEntity)
                        {
                            var obAccoutBalanceExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceEntity);
                            if (obAccoutBalanceExit != null)
                            {
                                obAccoutBalanceExit.CurrencyCode = accountBalanceEntity.CurrencyCode;

                                // cập nhật bên TK nợ
                                if (accountBalanceEntity.MovementCreditAmountOC == 0)
                                {
                                    obAccoutBalanceExit.ExchangeRate = accountBalanceEntity.ExchangeRate;
                                    obAccoutBalanceExit.MovementDebitAmountExchange =
                                        obAccoutBalanceExit.MovementDebitAmountExchange - accountBalanceEntity.MovementDebitAmountExchange;
                                    obAccoutBalanceExit.MovementDebitAmountOC =
                                        obAccoutBalanceExit.MovementDebitAmountOC - accountBalanceEntity.MovementDebitAmountOC;
                                    AccountBalanceDao.UpdateAccountBalance(obAccoutBalanceExit);
                                }
                                else
                                {
                                    obAccoutBalanceExit.ExchangeRate = accountBalanceEntity.ExchangeRate;
                                    obAccoutBalanceExit.MovementCreditAmountExchange =
                                        obAccoutBalanceExit.MovementCreditAmountExchange - accountBalanceEntity.MovementCreditAmountExchange;
                                    obAccoutBalanceExit.MovementCreditAmountOC =
                                        obAccoutBalanceExit.MovementCreditAmountOC - accountBalanceEntity.MovementCreditAmountOC;
                                    AccountBalanceDao.UpdateAccountBalance(obAccoutBalanceExit);
                                }
                            }

                        }
                        // Cập nhật lại dữ liệu vào bảng cân đối tài khoản
                        listAccountBalanceEntity.Clear();
                        listAccountBalanceEntity = GetListAccountBalance(request);
                        foreach (var accountBalanceEntity in listAccountBalanceEntity)
                        {
                            var obAccoutBalanceExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceEntity);
                            if (obAccoutBalanceExit != null)
                            {
                                obAccoutBalanceExit.CurrencyCode = accountBalanceEntity.CurrencyCode;

                                // cập nhật bên TK nợ
                                if (accountBalanceEntity.MovementCreditAmountOC == 0)
                                {
                                    obAccoutBalanceExit.ExchangeRate = accountBalanceEntity.ExchangeRate;
                                    obAccoutBalanceExit.MovementDebitAmountExchange =
                                        obAccoutBalanceExit.MovementDebitAmountExchange + accountBalanceEntity.MovementDebitAmountExchange;
                                    obAccoutBalanceExit.MovementDebitAmountOC =
                                        obAccoutBalanceExit.MovementDebitAmountOC + accountBalanceEntity.MovementDebitAmountOC;
                                    AccountBalanceDao.UpdateAccountBalance(obAccoutBalanceExit);
                                }
                                else
                                {
                                    obAccoutBalanceExit.ExchangeRate = accountBalanceEntity.ExchangeRate;
                                    obAccoutBalanceExit.MovementCreditAmountExchange =
                                        obAccoutBalanceExit.MovementCreditAmountExchange + accountBalanceEntity.MovementCreditAmountExchange;
                                    obAccoutBalanceExit.MovementCreditAmountOC =
                                        obAccoutBalanceExit.MovementCreditAmountOC + accountBalanceEntity.MovementCreditAmountOC;
                                    AccountBalanceDao.UpdateAccountBalance(obAccoutBalanceExit);
                                }
                            }
                            else
                            {
                                AccountBalanceDao.InsertAccountBalance(accountBalanceEntity);
                            }
                        }
                        // Xóa dữ liệu trống trong bảng Cân đối tài khoản
                        AccountBalanceDao.DeleteAccountBalance();

                        response.Message = CashDetailDao.DeleteCashDetailByCash(cashEntity.RefId);

                        if (response.Message != null)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return response;
                        }

                        response.Message = CashDetailDao.DeleteReceipDetailParalellByCash(cashEntity.RefId);
                        if (response.Message != null)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return response;
                        }

                        if (cashEntity.RefTypeId == 600)
                        {
                            //Update Lại các mục Khoản lương
                            //Lấy lại số chứng từ cũ thay the số chứng từ mới
                            var objCash = CashDao.GetCash(cashEntity.RefId);
                            response.Message = CashDao.UpdateEmployeePayroll(objCash.RefNo, cashEntity.RefNo, cashEntity.PostedDate.Month + "/" + cashEntity.PostedDate.Day + "/" + cashEntity.PostedDate.Year);
                        }
                        response.Message = CashDao.UpdateCash(cashEntity);
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
                        foreach (var cashDetail in cashEntity.CashDetails)
                        {
                            if (!cashDetail.Validate())
                            {
                                foreach (string error in cashDetail.ValidationErrors)
                                    response.Message += error + Environment.NewLine;
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }
                            cashDetail.RefId = cashEntity.RefId;
                            if (!cashEntity.IsIncludeCharge)
                            {
                                cashDetail.Charge = 0;
                                cashDetail.ChargeExchange = 0;
                            }
                            var iRefDetailId = CashDetailDao.InsertCashDetail(cashDetail);
                            cashDetail.RefDetailId = iRefDetailId;
                            // Insert into JourentryAcocunt
                            obJourentryAccount = listJournalEntryAccountEntity[i];
                            obJourentryAccount.RefId = cashDetail.RefId;
                            obJourentryAccount.RefDetailId = cashDetail.RefDetailId;
                            #region " obJourentryAccount: thay đổi thông tin theo đối tượng Master"
                            int accountingObjectType = cashEntity.AccountingObjectType == null ? 0 : int.Parse(cashEntity.AccountingObjectType.ToString());
                            switch (accountingObjectType)
                            {
                                case 0:
                                    obJourentryAccount.VendorId = cashEntity.VendorId;
                                    break;
                                case 1:
                                    obJourentryAccount.EmployeeId = cashEntity.EmployeeId;
                                    break;
                                case 2:
                                    obJourentryAccount.AccountingObjectId = cashEntity.AccountingObjectId;
                                    break;
                                case 3:
                                    obJourentryAccount.CustomerId = cashEntity.CustomerId;
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

                        //sinh định khoản đồng thời 

                        #region Sinh dinh khoan dong thoi

                        i = 0;
                        if (!request.isAutoGenerateParallel) //trường hợp k sinh định khoản tự động 
                        {
                            foreach (var cashParalellDetail in cashEntity.CashParalellDetails)
                            {
                                #region Insert detailParallel

                                if (!cashParalellDetail.Validate())
                                {
                                    foreach (string error in cashParalellDetail.ValidationErrors)
                                        response.Message += error + Environment.NewLine;
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }
                                cashParalellDetail.RefId = cashEntity.RefId;
                                cashParalellDetail.RefDetailId = CashDetailDao.InsertReceiptDetailParalell(cashParalellDetail);
                                //------------------------------------------------------------------
                                //LinhMC thêm đoạn kiểm tra việc InsertCashDetail có thành công hay không? 
                                //Yêu cầu phải có để đảm bảo toàn vẹn dữ liệu
                                if (cashParalellDetail.RefDetailId == 0)
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }

                                #endregion

                                #region Insert journalEntryAccount

                                var journalEntryAccount = MakeJournalEntryAccount(cashEntity, cashParalellDetail);
                                if (!journalEntryAccount.Validate())
                                {
                                    foreach (string error in journalEntryAccount.ValidationErrors)
                                        response.Message += error + Environment.NewLine;
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }
                                JournalEntryAccountDao.InsertDoubleJournalEntryAccount(journalEntryAccount);

                                #endregion
                                i = i + 1;
                            }

                        }
                        else //sinh định khoản tự động 
                        {
                            foreach (var cashDetail in cashEntity.CashDetails)
                            {
                                if (!cashDetail.Validate())
                                {
                                    foreach (string error in cashDetail.ValidationErrors)
                                        response.Message += error + Environment.NewLine;
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }

                                var budgetSource = BudgetSourceDao.GetBudgetSourceByBudgetSourceCode(cashDetail.BudgetSourceCode);
                                var budgetItem = BudgetItemDao.GetBudgetItemsByCode(cashDetail.BudgetItemCode);
                                var autoBusinessParallelEntities = AutoBusinessParallelDao.GetAutoBusinessParallelsByAutoBussinessInformations(
                                       cashDetail.AccountNumber,
                                       cashDetail.CorrespondingAccountNumber,
                                       (cashDetail.BudgetSourceCode == null || budgetSource == null) ? 0 : budgetSource.BudgetSourceId,
                                       budgetItem.Count == 0 ? 0 : budgetItem.FirstOrDefault().BudgetItemId,
                                       0,
                                       cashDetail.VoucherTypeId == null ? 0 : (int)cashDetail.VoucherTypeId);
                                foreach (var autoBusinessParallelEntity in autoBusinessParallelEntities)
                                {
                                    #region Insert detailParallel

                                    var budgetItemsParalell = BudgetItemDao.GetBudgetItem(autoBusinessParallelEntity.BudgetItemId) == null ? null : BudgetItemDao.GetBudgetItem(autoBusinessParallelEntity.BudgetItemId).BudgetItemCode;
                                    var budgetSoucreParalell = BudgetSourceDao.GetBudgetSource(autoBusinessParallelEntity.BudgetSourceId) == null ? null : BudgetSourceDao.GetBudgetSource(autoBusinessParallelEntity.BudgetSourceId).BudgetSourceCode;
                                    var cashParalellDetail = new CashParalellDetailEntity();

                                    cashParalellDetail.RefId = cashEntity.RefId;
                                    cashParalellDetail.AccountNumber = autoBusinessParallelEntity.DebitAccountParallel;
                                    cashParalellDetail.CorrespondingAccountNumber = autoBusinessParallelEntity.CreditAccountParallel;
                                    cashParalellDetail.AmountOc = autoBusinessParallelEntity.IsNegative == true ? cashDetail.AmountOc * (-1) : cashDetail.AmountOc;
                                    cashParalellDetail.AmountExchange = autoBusinessParallelEntity.IsNegative == true ? cashDetail.AmountExchange * (-1) : cashDetail.AmountExchange;
                                    cashParalellDetail.Description = cashDetail.Description;
                                    cashParalellDetail.AutoBusinessId = cashDetail.AutoBusinessId;
                                    cashParalellDetail.AccountingObjectId = cashDetail.AccountingObjectId;
                                    cashParalellDetail.MergerFundId = cashDetail.MergerFundId;
                                    cashParalellDetail.ProjectId = cashDetail.ProjectId;
                                    cashParalellDetail.IsInserted = cashDetail.IsInserted;
                                    cashParalellDetail.VoucherTypeId = autoBusinessParallelEntity.VoucherTypeId == null ? cashDetail.VoucherTypeId : (int)autoBusinessParallelEntity.VoucherTypeIdParallel;
                                    cashParalellDetail.BudgetSourceCode = budgetSoucreParalell ?? cashDetail.BudgetSourceCode;
                                    cashParalellDetail.BudgetItemCode = budgetItemsParalell ?? cashDetail.BudgetItemCode;
                                    cashParalellDetail.VoucherTypeId = cashDetail.VoucherTypeId ?? cashDetail.VoucherTypeId;

                                    cashParalellDetail.RefDetailId = CashDetailDao.InsertReceiptDetailParalell(cashParalellDetail);
                                    //------------------------------------------------------------------
                                    //LinhMC thêm đoạn kiểm tra việc InsertCashDetail có thành công hay không? 
                                    //Yêu cầu phải có để đảm bảo toàn vẹn dữ liệu
                                    if (cashParalellDetail.RefDetailId == 0)
                                    {
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        return response;
                                    }

                                    #endregion

                                    #region Insert journalEntryAccount

                                    var journalEntryAccount = MakeJournalEntryAccount(cashEntity, cashParalellDetail);
                                    if (!journalEntryAccount.Validate())
                                    {
                                        foreach (string error in journalEntryAccount.ValidationErrors)
                                            response.Message += error + Environment.NewLine;
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        return response;
                                    }
                                    JournalEntryAccountDao.InsertDoubleJournalEntryAccount(journalEntryAccount);

                                    #endregion
                                }

                                i = i + 1;
                            }



                        }

                        #endregion


                        scope.Complete();
                    }
                }
                else
                {
                    var generalVoucher = new GeneralEntity();
                    using (var scope = new TransactionScope())
                    {
                        var cashEntityForDelete = CashDao.GetCash(request.RefId);
                        var details = CashDetailDao.GetCashDetailsByCash(request.RefId);
                        generalVoucher = GeneralFacede.GetGeneralVoucher(cashEntityForDelete.RefTypeId, cashEntityForDelete.RefId);
                        response.Message = CashDao.DeleteCash(cashEntityForDelete);
                        // Xóa bảng JourentryAccount
                        obJourentryAccount.RefId = cashEntityForDelete.RefId;
                        obJourentryAccount.RefTypeId = cashEntityForDelete.RefTypeId;
                        obJourentryAccount.RefNo = cashEntityForDelete.RefNo;
                        response.Message = JournalEntryAccountDao.DeleteJournalEntryAccount(obJourentryAccount);
                        // Cập nhật lại dữ liệu vào bảng cân đối tài khoản
                        listAccountBalanceEntity.Clear();
                        request.CashEntity = cashEntityForDelete;
                        request.CashEntity.CashDetails = details;
                        listAccountBalanceEntity = GetListAccountBalance(request);
                        foreach (var accountBalanceEntity in listAccountBalanceEntity)
                        {
                            var obAccoutBalanceExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceEntity);
                            if (obAccoutBalanceExit != null)
                            {
                                obAccoutBalanceExit.CurrencyCode = accountBalanceEntity.CurrencyCode;
                                // cập nhật bên TK nợ
                                if (accountBalanceEntity.MovementCreditAmountOC == 0)
                                {
                                    obAccoutBalanceExit.ExchangeRate = accountBalanceEntity.ExchangeRate;
                                    obAccoutBalanceExit.MovementDebitAmountExchange =
                                        obAccoutBalanceExit.MovementDebitAmountExchange - accountBalanceEntity.MovementDebitAmountExchange;
                                    obAccoutBalanceExit.MovementDebitAmountOC =
                                        obAccoutBalanceExit.MovementDebitAmountOC - accountBalanceEntity.MovementDebitAmountOC;
                                    AccountBalanceDao.UpdateAccountBalance(obAccoutBalanceExit);
                                }
                                else
                                {
                                    obAccoutBalanceExit.ExchangeRate = accountBalanceEntity.ExchangeRate;
                                    obAccoutBalanceExit.MovementCreditAmountExchange =
                                        obAccoutBalanceExit.MovementCreditAmountExchange - accountBalanceEntity.MovementCreditAmountExchange;
                                    obAccoutBalanceExit.MovementCreditAmountOC =
                                        obAccoutBalanceExit.MovementCreditAmountOC - accountBalanceEntity.MovementCreditAmountOC;
                                    AccountBalanceDao.UpdateAccountBalance(obAccoutBalanceExit);
                                }
                            }
                        }
                        // Xóa dữ liệu trống trong bảng Cân đối tài khoản
                        AccountBalanceDao.DeleteAccountBalance();
                        // Xóa thông tin lương nhân viên đã tính
                        //if (cashEntityForDelete.RefTypeId == 600)
                        //{
                        //    response.Message = CashDao.DeleteEmployeePayroll(cashEntityForDelete.RefNo,
                        //       cashEntityForDelete.PostedDate.Month + "/" + cashEntityForDelete.PostedDate.Day + "/" + cashEntityForDelete.PostedDate.Year);
                        //}

                        scope.Complete();
                        scope.Dispose();
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

            response.RefId = cashEntity != null ? cashEntity.RefId : 0;
            response.Acknowledge = response.Message != null ? AcknowledgeType.Failure : AcknowledgeType.Success;
            return response;
        }

        /// <summary>
        /// Gets the list journal entry account entity.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public IList<JournalEntryAccountEntity> GetListJournalEntryAccount(CashRequest request)
        {
            var cashEntity = request.CashEntity;
            return (from cashDetail in cashEntity.CashDetails
                    let iDepositDetailId = cashDetail.RefDetailId
                    select new JournalEntryAccountEntity
                    {
                        RefId = cashEntity.RefId,
                        RefTypeId = cashEntity.RefTypeId,
                        RefNo = cashEntity.RefNo,
                        RefDate = cashEntity.RefDate,
                        PostedDate = cashEntity.PostedDate,
                        JournalMemo = cashEntity.JournalMemo,
                        CurrencyCode = cashEntity.CurrencyCode,
                        ExchangeRate = cashEntity.ExchangeRate,
                        BankAccount = cashEntity.BankAccount,
                        BankId = cashEntity.BankId,
                        RefDetailId = iDepositDetailId,
                        AccountNumber = cashDetail.AccountNumber,
                        CorrespondingAccountNumber = cashDetail.CorrespondingAccountNumber,
                        AmountOc = cashDetail.AmountOc,
                        Description = cashDetail.Description,
                        AmountExchange = cashDetail.AmountExchange,
                        BudgetSourceCode = cashDetail.BudgetSourceCode,
                        BudgetItemCode = cashDetail.BudgetItemCode,
                        AccountingObjectId = cashDetail.AccountingObjectId,
                        MergerFundId = cashDetail.MergerFundId,
                        VoucherTypeId = cashDetail.VoucherTypeId,
                        ProjectId = cashDetail.ProjectId
                    }).ToList();
        }

        /// <summary>
        /// Gets the list account balance.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public IList<AccountBalanceEntity> GetListAccountBalance(CashRequest request)
        {
            var cashEntity = request.CashEntity;
            IList<AccountBalanceEntity> obListAccountBalanceEntity = new List<AccountBalanceEntity>();
            foreach (var cashDetail in cashEntity.CashDetails)
            {
                var obAccountBalanceEntity = new AccountBalanceEntity
                {
                    BalanceDate = cashEntity.PostedDate,
                    CurrencyCode = cashEntity.CurrencyCode,
                    ExchangeRate = cashEntity.ExchangeRate,
                    AccountNumber = cashDetail.AccountNumber,
                    MovementDebitAmountOC = cashDetail.AmountOc,
                    MovementDebitAmountExchange = cashDetail.AmountExchange,
                    BudgetSourceCode = cashDetail.BudgetSourceCode,
                    BudgetItemCode = cashDetail.BudgetItemCode,
                    MovementCreditAmountOC = 0,
                    MovementCreditAmountExchange = 0,
                    ProjectId = cashDetail.ProjectId == 0 ? null : cashDetail.ProjectId
                };
                //Dòng tài khoản nợ
                obListAccountBalanceEntity.Add(obAccountBalanceEntity);
                // Dòng tài khoản có
                var obAccountBalanceEntity1 = new AccountBalanceEntity
                {
                    BalanceDate = cashEntity.PostedDate,
                    CurrencyCode = cashEntity.CurrencyCode,
                    ExchangeRate = cashEntity.ExchangeRate,
                    AccountNumber = cashDetail.CorrespondingAccountNumber,
                    MovementCreditAmountOC = cashDetail.AmountOc,
                    MovementCreditAmountExchange = cashDetail.AmountExchange,
                    BudgetSourceCode = cashDetail.BudgetSourceCode,
                    BudgetItemCode = cashDetail.BudgetItemCode,
                    MovementDebitAmountOC = 0,
                    MovementDebitAmountExchange = 0,
                    ProjectId = cashDetail.ProjectId == 0 ? null : cashDetail.ProjectId
                };

                obListAccountBalanceEntity.Add(obAccountBalanceEntity1);
            }

            return obListAccountBalanceEntity;
        }

        /// <summary>
        /// Gets the list account balance older.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        public IList<AccountBalanceEntity> GetListAccountBalanceOlder(long refId)
        {
            var cashEntity = CashDao.GetCash(refId);
            cashEntity.CashDetails = CashDetailDao.GetCashDetailsByCash(refId);
            IList<AccountBalanceEntity> obListAccountBalanceEntity = new List<AccountBalanceEntity>();
            foreach (var cashDetail in cashEntity.CashDetails)
            {
                var obAccountBalanceEntity = new AccountBalanceEntity
                {
                    BalanceDate = cashEntity.PostedDate,
                    CurrencyCode = cashEntity.CurrencyCode,
                    ExchangeRate = cashEntity.ExchangeRate,
                    AccountNumber = cashDetail.AccountNumber,
                    MovementDebitAmountOC = cashDetail.AmountOc,
                    MovementDebitAmountExchange = cashDetail.AmountExchange,
                    BudgetSourceCode = cashDetail.BudgetSourceCode,
                    BudgetItemCode = cashDetail.BudgetItemCode,
                    MovementCreditAmountOC = 0,
                    MovementCreditAmountExchange = 0,
                    ProjectId = cashDetail.ProjectId == 0 ? null : cashDetail.ProjectId
                };
                //Dòng tài khoản nợ
                obListAccountBalanceEntity.Add(obAccountBalanceEntity);
                // Dòng tài khoản có
                var obAccountBalanceEntity1 = new AccountBalanceEntity
                {
                    BalanceDate = cashEntity.PostedDate,
                    CurrencyCode = cashEntity.CurrencyCode,
                    ExchangeRate = cashEntity.ExchangeRate,
                    AccountNumber = cashDetail.CorrespondingAccountNumber,
                    MovementCreditAmountOC = cashDetail.AmountOc,
                    MovementCreditAmountExchange = cashDetail.AmountExchange,
                    BudgetSourceCode = cashDetail.BudgetSourceCode,
                    BudgetItemCode = cashDetail.BudgetItemCode,
                    MovementDebitAmountOC = 0,
                    MovementDebitAmountExchange = 0,
                    ProjectId = cashDetail.ProjectId == 0 ? null : cashDetail.ProjectId
                };

                obListAccountBalanceEntity.Add(obAccountBalanceEntity1);
            }

            return obListAccountBalanceEntity;
        }

        public JournalEntryAccountEntity MakeJournalEntryAccount(CashEntity cash, CashParalellDetailEntity cashParallelDetail)
        {
            var journalEntryAccount = new JournalEntryAccountEntity();
            if (cashParallelDetail != null)
            {
                journalEntryAccount.RefDetailId = cashParallelDetail.RefDetailId;
                journalEntryAccount.RefId = cashParallelDetail.RefId;
                journalEntryAccount.RefTypeId = cash.RefTypeId;
                journalEntryAccount.RefNo = cash.RefNo;
                journalEntryAccount.RefDate = cash.RefDate;
                journalEntryAccount.PostedDate = cash.PostedDate;
                journalEntryAccount.Description = cashParallelDetail.Description;
                journalEntryAccount.JournalMemo = cash.JournalMemo;
                journalEntryAccount.CurrencyCode = cash.CurrencyCode;
                journalEntryAccount.ExchangeRate = cash.ExchangeRate;
                journalEntryAccount.AccountNumber = cashParallelDetail.AccountNumber;
                journalEntryAccount.CorrespondingAccountNumber = cashParallelDetail.CorrespondingAccountNumber;
                //journalEntryAccount.Quantity = cashParallelDetail.Quan;
                //journalEntryAccount.JournalType = 
                journalEntryAccount.AmountOc = cashParallelDetail.AmountOc;
                journalEntryAccount.AmountExchange = cashParallelDetail.AmountExchange;
                journalEntryAccount.BudgetSourceCode = cashParallelDetail.BudgetSourceCode;
                journalEntryAccount.BudgetItemCode = cashParallelDetail.BudgetItemCode;
                journalEntryAccount.CustomerId = cash.CustomerId;
                journalEntryAccount.VendorId = cash.VendorId;
                journalEntryAccount.EmployeeId = cash.EmployeeId;
                journalEntryAccount.AccountingObjectId = cash.AccountingObjectId;
                journalEntryAccount.VoucherTypeId = cashParallelDetail.VoucherTypeId;
                journalEntryAccount.MergerFundId = cashParallelDetail.MergerFundId;
                journalEntryAccount.ProjectId = cashParallelDetail.ProjectId;
                //journalEntryAccount.InventoryItemId = cashParallelDetail.InventoryItemId;
                journalEntryAccount.BankId = cash.BankId;
                journalEntryAccount.BankAccount = cash.BankAccount;
            }
            return journalEntryAccount;
        }
    }
}

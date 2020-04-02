/***********************************************************************
 * <copyright file="FAIncrementFacade.cs" company="BUCA JSC">
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
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using TSD.AccountingSoft.BusinessComponents.Messages.FixedAsset;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Business;
using TSD.AccountingSoft.BusinessEntities.Business.FixedAssetIncrement;
using TSD.AccountingSoft.BusinessEntities.Dictionary;
using TSD.AccountingSoft.DataAccess.IEntitiesDao;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.FixedAsset;


namespace TSD.AccountingSoft.BusinessComponents.Facade.FixedAsset
{
    /// <summary>
    /// FAIncrementFacade
    /// </summary>
    public class FAIncrementFacade
    {
        private static readonly IFixedAssetIncrementDao FixedAssetIncrementDao = DataAccess.DataAccess.FixedAssetIncrementDao;
        private static readonly IFixedAssetIncrementDetailDao FixedAssetIncrementDetailDao = DataAccess.DataAccess.FixedAssetIncrementDetailDao;
        private static readonly IFixedAssetIncrementDetailParallelDao FixedAssetIncrementDetailParallelDao = DataAccess.DataAccess.FixedAssetIncrementDetailParallelDao;
        private static readonly IAutoNumberDao AutoNumberDao = DataAccess.DataAccess.AutoNumberDao;
        private static readonly IAudittingLogDao AudittingLogDao = DataAccess.DataAccess.AudittingLogDao;
        private static readonly IFixedAssetLedgerDao FixedAssetLedgerDao = DataAccess.DataAccess.FixedAssetLedgerDao;
        private static readonly IJournalEntryAccountDao JournalEntryAccountDao = DataAccess.DataAccess.JournalEntryAccountDao;
        private static readonly IAccountBalanceDao AccountBalanceDao = DataAccess.DataAccess.AccountBalanceDao;
        private static readonly IAutoBusinessParallelDao AutoBusinessParallelDao = DataAccess.DataAccess.AutoBusinessParallelDao;
        private static readonly IBudgetSourceDao BudgetSourceDao = DataAccess.DataAccess.BudgetSourceDao;
        private static readonly IBudgetItemDao BudgetItemDao = DataAccess.DataAccess.BudgetItemDao;

        public FAIncrementResponse GetFAIncrements(FAIncrementRequest request)
        {
            var response = new FAIncrementResponse();
            if (request.LoadOptions.Contains("FAIncrements"))
            {
                if (request.LoadOptions.Contains("RefType"))
                    response.FAIncrements = FixedAssetIncrementDao.GetFAIncrementesByRefTypeId(request.RefType);
                else if (request.LoadOptions.Contains("RefDate"))
                    response.FAIncrements = FixedAssetIncrementDao.GetFAIncrementsByYearOfRefDate(request.RefType, (short)DateTime.Parse(request.RefDate).Year);
                else response.FAIncrements = FixedAssetIncrementDao.GetFAIncrementes();
            }
            if (request.LoadOptions.Contains("FAIncrement"))
            {
                if (request.LoadOptions.Contains("RefNo"))
                {
                    var faIncrement = FixedAssetIncrementDao.GetFAIncrementByRefNo(request.RefNo);
                    if (request.LoadOptions.Contains("IncludeDetail"))
                    {
                        faIncrement = faIncrement ?? new FAIncrementEntity();
                        faIncrement.FAIncrementDetails = FixedAssetIncrementDetailDao.GetFAIncrementDetailByFAIncrement(faIncrement.RefId);
                        faIncrement.FAIncrementDetailParallels = FixedAssetIncrementDetailParallelDao.GetFixedAssetIncrementDetailParallelByRefId(faIncrement.RefId);
                    }
                    response.FAIncrement = faIncrement;
                }
                else
                {
                    var faIncrement = FixedAssetIncrementDao.GetFAIncrement(request.RefId);
                    if (request.LoadOptions.Contains("IncludeDetail"))
                    {
                        faIncrement = faIncrement ?? new FAIncrementEntity();
                        faIncrement.FAIncrementDetails = FixedAssetIncrementDetailDao.GetFAIncrementDetailByFAIncrement(faIncrement.RefId);
                        faIncrement.FAIncrementDetailParallels = FixedAssetIncrementDetailParallelDao.GetFixedAssetIncrementDetailParallelByRefId(faIncrement.RefId);
                    }
                    response.FAIncrement = faIncrement;
                }

                //var faIncrement = FixedAssetIncrementDao.GetFAIncrement(request.RefId);
                //if (request.LoadOptions.Contains("IncludeDetail"))
                //{
                //    faIncrement = faIncrement ?? new FAIncrementEntity();
                //    faIncrement.FAIncrementDetails = FixedAssetIncrementDetailDao.GetFAIncrementDetailByFAIncrement(faIncrement.RefId);
                //}
                //response.FAIncrement = faIncrement;
            }
            return response;
        }

        public FAIncrementResponse SetFAIncrements(FAIncrementRequest request)
        {
            var response = new FAIncrementResponse();
            var jourentryAccount = new JournalEntryAccountEntity();
            IList<JournalEntryAccountEntity> journalEntryAccountEntity = new List<JournalEntryAccountEntity>();
            IList<AccountBalanceEntity> accountBalanceEntity = new List<AccountBalanceEntity>();
            var faIncrementEntity = request.FAIncrement;
            //var auditingLog = new AudittingLogEntity { ComponentName = "GHI TANG TSCD", EventAction = (int)request.Action };
            var i = 0;
            if (request.Action != PersistType.Delete)
            {
                if (faIncrementEntity != null)
                {
                    if (!faIncrementEntity.Validate())
                    {
                        foreach (string error in faIncrementEntity.ValidationErrors)
                            response.Message += error + Environment.NewLine;
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }
                }
            }
            if (request.FAIncrement != null)
            {
                journalEntryAccountEntity = AddJurnalEntryAccount(request.FAIncrement);
                accountBalanceEntity = AddAccountBalance(request.FAIncrement);
            }
            try
            {
                if (request.Action == PersistType.Insert)
                {
                    if (request.FAIncrements == null)
                    {
                        using (var scope = new TransactionScope())
                        {
                            response = InsertFAIncrement(request.FAIncrement, jourentryAccount, journalEntryAccountEntity.ToList(), accountBalanceEntity.ToList());
                            if (response.Acknowledge == AcknowledgeType.Failure)
                                scope.Dispose();
                            else
                            {
                                // get autoNumer
                                if (faIncrementEntity != null)
                                {
                                    var autoNumber = AutoNumberDao.GetAutoNumberByRefType(faIncrementEntity.RefTypeId);
                                    //------------------------------------------------------------------
                                    //LinhMC 29/11/2014
                                    //Lưu giá trị số tự động tăng theo loại tiền
                                    //---------------------------------------------------------------
                                    if (faIncrementEntity.CurrencyCode == "USD")
                                        autoNumber.Value += 1;
                                    else autoNumber.ValueLocalCurency += 1;

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
                    }

                    else
                    {
                        using (var scope = new TransactionScope())
                        {
                            foreach (var faIncrement in request.FAIncrements)
                            {
                                if (faIncrement != null)
                                {
                                    journalEntryAccountEntity = AddJurnalEntryAccount(faIncrement);
                                    accountBalanceEntity = AddAccountBalance(faIncrement);
                                }
                                response = InsertFAIncrement(faIncrement, jourentryAccount, journalEntryAccountEntity.ToList(), accountBalanceEntity.ToList());
                                if (response.Acknowledge == AcknowledgeType.Failure)
                                    scope.Dispose();
                                // get autoNumer
                                if (faIncrement != null)
                                {
                                    var autoNumber = AutoNumberDao.GetAutoNumberByRefType(faIncrement.RefTypeId);

                                    //------------------------------------------------------------------
                                    //LinhMC 29/11/2014
                                    //Lưu giá trị số tự động tăng theo loại tiền
                                    //---------------------------------------------------------------
                                    if (faIncrement != null && faIncrement.CurrencyCode == "USD")
                                        autoNumber.Value += 1;
                                    else autoNumber.ValueLocalCurency += 1;

                                    response.Message = AutoNumberDao.UpdateAutoNumber(autoNumber);
                                }
                                if (response.Message != null)
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    scope.Dispose();
                                    return response;
                                }
                            }
                            if (response.Message == null)
                                scope.Complete();
                        }
                    }
                }
                else if (request.Action == PersistType.Update)
                {
                    using (var scope = new TransactionScope())
                    {
                        // Trừ số tiền khi mà update xử lý Bảng cân đối tài khoản////////////////////////////////////
                        accountBalanceEntity.Clear();
                        if (faIncrementEntity != null)
                            accountBalanceEntity = AddAccountBalanceOlder(faIncrementEntity.RefId);
                        foreach (var accountBalance in accountBalanceEntity)
                        {
                            var accountBalances = AccountBalanceDao.GetExitsAccountBalance(accountBalance);
                            if (accountBalances != null)
                            {
                                // cập nhật bên TK nợ
                                if (accountBalance.MovementCreditAmountOC == 0)
                                {
                                    accountBalances.ExchangeRate = accountBalance.ExchangeRate;
                                    accountBalances.MovementDebitAmountExchange = accountBalances.MovementDebitAmountExchange - accountBalance.MovementDebitAmountExchange;
                                    accountBalances.MovementDebitAmountOC = accountBalances.MovementDebitAmountOC - accountBalance.MovementDebitAmountOC;
                                    AccountBalanceDao.UpdateAccountBalance(accountBalances);
                                }
                                else
                                {
                                    accountBalances.ExchangeRate = accountBalance.ExchangeRate;
                                    accountBalances.MovementCreditAmountExchange = accountBalances.MovementCreditAmountExchange - accountBalance.MovementCreditAmountExchange;
                                    accountBalances.MovementCreditAmountOC = accountBalances.MovementCreditAmountOC - accountBalances.MovementCreditAmountOC;
                                    AccountBalanceDao.UpdateAccountBalance(accountBalances);
                                }
                            }

                        }
                        // Cập nhật lại dữ liệu vào bảng cân đối tài khoản
                        accountBalanceEntity.Clear();
                        accountBalanceEntity = AddAccountBalance(faIncrementEntity);
                        foreach (var accountBalance in accountBalanceEntity)
                        {
                            var accountBalances = AccountBalanceDao.GetExitsAccountBalance(accountBalance);
                            if (accountBalances != null)
                            {
                                // cập nhật bên TK nợ
                                if (accountBalance.MovementCreditAmountOC == 0)
                                {
                                    accountBalances.ExchangeRate = accountBalance.ExchangeRate;
                                    accountBalances.MovementDebitAmountExchange = accountBalances.MovementDebitAmountExchange + accountBalance.MovementDebitAmountExchange;
                                    accountBalances.MovementDebitAmountOC = accountBalances.MovementDebitAmountOC + accountBalance.MovementDebitAmountOC;
                                    AccountBalanceDao.UpdateAccountBalance(accountBalances);
                                }
                                else
                                {
                                    accountBalances.ExchangeRate = accountBalance.ExchangeRate;
                                    accountBalances.MovementCreditAmountExchange = accountBalances.MovementCreditAmountExchange + accountBalance.MovementCreditAmountExchange;
                                    accountBalances.MovementCreditAmountOC = accountBalances.MovementCreditAmountOC + accountBalance.MovementCreditAmountOC;
                                    AccountBalanceDao.UpdateAccountBalance(accountBalances);
                                }
                            }
                            else
                            {
                                AccountBalanceDao.InsertAccountBalance(accountBalance);
                            }
                        }
                        // Xóa dữ liệu trống trong bảng Cân đối tài khoản
                        AccountBalanceDao.DeleteAccountBalance();
                        ////////////////////END BANG CAN DOI TAI KHOAN///////////////////////////////////////////////
                        response.Message = FixedAssetIncrementDao.UpdateFAIncrement(faIncrementEntity);
                        if (response.Message != null)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return response;
                        }

                        //delete detail
                        response.Message = FixedAssetIncrementDetailDao.DeleteFAIncrementDetailByFAIncrement(faIncrementEntity.RefId);
                        if (response.Message != null)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return response;
                        }
                        jourentryAccount = journalEntryAccountEntity[0];
                        response.Message = JournalEntryAccountDao.DeleteJournalEntryAccount(jourentryAccount);
                        if (response.Message != null)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return response;
                        }
                        foreach (var faIncrementDetail in faIncrementEntity.FAIncrementDetails)
                        {
                            if (!faIncrementDetail.Validate())
                            {
                                foreach (string error in faIncrementDetail.ValidationErrors)
                                    response.Message += error + Environment.NewLine;
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }
                            if (faIncrementDetail.FixedAssetId == 0)
                                faIncrementDetail.FixedAssetId = null;
                            faIncrementDetail.RefId = faIncrementEntity.RefId;
                            faIncrementDetail.RefDetailId = FixedAssetIncrementDetailDao.InsertFAIncrementDetail(faIncrementDetail);
                            // Insert into JourentryAcocunt
                            jourentryAccount = journalEntryAccountEntity[i];
                            jourentryAccount.RefId = faIncrementDetail.RefId;
                            jourentryAccount.RefDetailId = faIncrementDetail.RefDetailId;
                            if (!jourentryAccount.Validate())
                            {
                                foreach (string error in jourentryAccount.ValidationErrors)
                                    response.Message += error + Environment.NewLine;
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }
                            JournalEntryAccountDao.InsertDoubleJournalEntryAccount(jourentryAccount);
                            i = i + 1;
                        }
                        //insert FixedAssetLedger
                        response.Message = FixedAssetLedgerDao.DeleteFixedAssetLedgerByRefId(faIncrementEntity.RefId, faIncrementEntity.RefTypeId);
                        if (response.Message != null)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return response;
                        }
                        var fixedAssetLedgers = InitFixedAssetLedgers(faIncrementEntity);
                        foreach (var fixedAssetLedgerEntity in fixedAssetLedgers)
                        {
                            if (fixedAssetLedgerEntity.FixedAssetId !=0)
                            fixedAssetLedgerEntity.FixedAssetLedgerId = FixedAssetLedgerDao.InsertFixedAssetLedger(fixedAssetLedgerEntity);
                            if (fixedAssetLedgerEntity.FixedAssetLedgerId != 0) continue;
                            response.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return response;
                        }
                        //insert log
                        //auditingLog.Reference = "GHI TANG TSCD" + faIncrementEntity.RefNo;
                        //auditingLog.Amount = faIncrementEntity.TotalAmountOC;
                        //AudittingLogDao.InsertAudittingLog(auditingLog);
                        response.RefId = faIncrementEntity.RefId;
                        scope.Complete();
                    }
                }
                else
                {
                    using (var scope = new TransactionScope())
                    {
                        var details = FixedAssetIncrementDetailDao.GetFAIncrementDetailByFAIncrement(request.RefId);
                        var fAIncrementForDelete = FixedAssetIncrementDao.GetFAIncrement(request.RefId);
                        response.Message = FixedAssetIncrementDao.DeleteFAIncrement(fAIncrementForDelete);
                        // Xóa bảng JourentryAccount
                        jourentryAccount.RefId = fAIncrementForDelete.RefId;
                        jourentryAccount.RefTypeId = fAIncrementForDelete.RefTypeId;
                        jourentryAccount.RefNo = fAIncrementForDelete.RefNo;
                        response.Message = JournalEntryAccountDao.DeleteJournalEntryAccount(jourentryAccount);
                        // Cập nhật lại dữ liệu vào bảng cân đối tài khoản
                        accountBalanceEntity.Clear();
                        request.FAIncrement = fAIncrementForDelete;
                        request.FAIncrement.FAIncrementDetails = details;
                        accountBalanceEntity = AddAccountBalance(fAIncrementForDelete);
                        foreach (var accountBalance in accountBalanceEntity)
                        {
                            var accountBalances = AccountBalanceDao.GetExitsAccountBalance(accountBalance);
                            if (accountBalances != null)
                            {
                                // cập nhật bên TK nợ
                                if (accountBalance.MovementCreditAmountOC == 0)
                                {
                                    accountBalances.ExchangeRate = accountBalance.ExchangeRate;
                                    accountBalances.MovementDebitAmountExchange = accountBalances.MovementDebitAmountExchange - accountBalance.MovementDebitAmountExchange;
                                    accountBalances.MovementDebitAmountOC = accountBalances.MovementDebitAmountOC - accountBalance.MovementDebitAmountOC;
                                    AccountBalanceDao.UpdateAccountBalance(accountBalances);
                                }
                                else
                                {
                                    accountBalances.ExchangeRate = accountBalance.ExchangeRate;
                                    accountBalances.MovementCreditAmountExchange = accountBalances.MovementCreditAmountExchange - accountBalance.MovementCreditAmountExchange;
                                    accountBalances.MovementCreditAmountOC = accountBalances.MovementCreditAmountOC - accountBalance.MovementCreditAmountOC;
                                    AccountBalanceDao.UpdateAccountBalance(accountBalances);
                                }
                            }
                        }
                        // Xóa dữ liệu trống trong bảng Cân đối tài khoản
                        AccountBalanceDao.DeleteAccountBalance();
                        if (response.Message != null)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return response;
                        }

                        // Xóa dữ liệu bảng FixedAssetLedger
                        response.Message = FixedAssetLedgerDao.DeleteFixedAssetLedgerByRefId(fAIncrementForDelete.RefId,
                            fAIncrementForDelete.RefTypeId);
                        if (response.Message != null)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return response;
                        }

                        //insert log
                        //auditingLog.Reference = "Xóa CT ghi tăng " + fAIncrementForDelete.RefNo;
                        //auditingLog.Amount = 0;
                        //AudittingLogDao.InsertAudittingLog(auditingLog);
                        response.RefId = fAIncrementForDelete.RefId;
                        scope.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                throw;
            }
            response.Acknowledge = response.Message != null ? AcknowledgeType.Failure : AcknowledgeType.Success;
            return response;
        }

        private IEnumerable<FixedAssetLedgerEntity> InitFixedAssetLedgers(FAIncrementEntity faIncrementEntity)
        {
            var fixedAssetLedgers = new List<FixedAssetLedgerEntity>();
            foreach (var faIncrementDetail in faIncrementEntity.FAIncrementDetails)
            {
                var fixedAssetLedger = new FixedAssetLedgerEntity
                {
                    RefId = faIncrementDetail.RefId,
                    RefTypeId = faIncrementEntity.RefTypeId,
                    RefNo = faIncrementEntity.RefNo,
                    RefDate = faIncrementEntity.RefDate,
                    PostedDate = faIncrementEntity.PostedDate,
                    FixedAssetId = faIncrementDetail.FixedAssetId,
                    DepartmentId = faIncrementDetail.DepartmentId,
                    CurrencyCode = faIncrementEntity.CurrencyCode,
                    OrgPriceAccount = "",
                    OrgPriceDebitAmount = 0,
                    OrgPriceCreditAmount = 0,
                    OrgPriceDebitAmountExchange = 0,
                    AnnualDepreciationAmount = 0,
                    OrgPriceCreditAmountExchange = 0,
                    DepreciationAccount = "",
                    DepreciationDebitAmount = 0,
                    DepreciationCreditAmount = 0,
                    DepreciationDebitAmountExchange = 0,
                    DepreciationCreditAmountExchange = 0,
                    BudgetSourceAccount = "",
                    BudgetSourcelDebitAmount = 0,
                    BudgetSourceCreditAmount = 0,
                    BudgetSourcelDebitAmountExchange = 0,
                    BudgetSourceCreditAmountExchange = 0,
                    JournalMemo = faIncrementEntity.JournalMemo,
                    Description = faIncrementDetail.Description,
                    ExchangeRate = faIncrementEntity.ExchangeRate,
                    Quantity = faIncrementDetail.Quantity

                };
                if (fixedAssetLedger.FixedAssetId != 0)
                {
                    if (fixedAssetLedgers.Count == 0 || (from item in fixedAssetLedgers
                                                         where (item.FixedAssetId == faIncrementDetail.FixedAssetId)
                                                         select item).FirstOrDefault() == null)
                    {
                        fixedAssetLedger = AddFixedAssetLedgerEntity(faIncrementDetail, fixedAssetLedger, faIncrementEntity.CurrencyCode);
                        fixedAssetLedgers.Add(fixedAssetLedger);
                    }
                    else
                    {
                        fixedAssetLedger = (from item in fixedAssetLedgers
                                            where (item.FixedAssetId == faIncrementDetail.FixedAssetId)
                                            select item).First();
                        fixedAssetLedgers.Remove(fixedAssetLedger);
                        fixedAssetLedgers.Add(AddFixedAssetLedgerEntity(faIncrementDetail, fixedAssetLedger, faIncrementEntity.CurrencyCode));
                    }
                }
                
            }
            return fixedAssetLedgers;
        }

        private static FixedAssetLedgerEntity AddFixedAssetLedgerEntity(FAIncrementDetailEntity faIncrementDetail, FixedAssetLedgerEntity fixedAssetLedger, string currencyCode)
        {
            if (faIncrementDetail.AccountNumber.Contains("211"))
            {
                fixedAssetLedger.OrgPriceAccount = faIncrementDetail.AccountNumber;
                if (currencyCode == "USD")
                {
                    fixedAssetLedger.OrgPriceDebitAmount += faIncrementDetail.AmountOC;
                    fixedAssetLedger.OrgPriceDebitAmountExchange += faIncrementDetail.AmountOC;
                }
                    
                else
                {
                    fixedAssetLedger.OrgPriceDebitAmount += faIncrementDetail.AmountOC;
                    fixedAssetLedger.OrgPriceDebitAmountExchange += faIncrementDetail.AmountExchange;
                }
            }

            if (faIncrementDetail.CorrespondingAccountNumber.Contains("366"))
            {
                fixedAssetLedger.BudgetSourceAccount = faIncrementDetail.CorrespondingAccountNumber;
                if (currencyCode == "USD")
                {
                    fixedAssetLedger.BudgetSourceCreditAmount += faIncrementDetail.AmountOC;
                    fixedAssetLedger.BudgetSourceCreditAmountExchange += faIncrementDetail.AmountOC;
                }
                else
                {
                    fixedAssetLedger.BudgetSourceCreditAmount += faIncrementDetail.AmountOC;
                    fixedAssetLedger.BudgetSourceCreditAmountExchange += faIncrementDetail.AmountExchange;
                }
            }
            if (faIncrementDetail.CorrespondingAccountNumber.Contains("214"))
            {
                fixedAssetLedger.DepreciationAccount = faIncrementDetail.CorrespondingAccountNumber;
                if (currencyCode == "USD")
                {
                    fixedAssetLedger.DepreciationCreditAmount += faIncrementDetail.AmountOC;
                    fixedAssetLedger.DepreciationCreditAmountExchange += faIncrementDetail.AmountOC;
                }
                    
                else
                {
                    fixedAssetLedger.DepreciationCreditAmount += faIncrementDetail.AmountOC;
                    fixedAssetLedger.DepreciationCreditAmountExchange += faIncrementDetail.AmountExchange;
                }
                fixedAssetLedger.AnnualDepreciationAmount = faIncrementDetail.AmountOC;
            }
            if (faIncrementDetail.AccountNumber.Contains("213"))
            {
                fixedAssetLedger.OrgPriceAccount = faIncrementDetail.AccountNumber;
                if (currencyCode == "USD")
                {
                    fixedAssetLedger.OrgPriceDebitAmount += faIncrementDetail.AmountOC;
                    fixedAssetLedger.OrgPriceDebitAmountExchange += faIncrementDetail.AmountOC;
                }
                    
                else
                {
                    fixedAssetLedger.OrgPriceDebitAmount += faIncrementDetail.AmountOC;
                    fixedAssetLedger.OrgPriceDebitAmountExchange += faIncrementDetail.AmountExchange;
                }
            }
            return fixedAssetLedger;
        }

        public IList<JournalEntryAccountEntity> AddJurnalEntryAccount(FAIncrementEntity faIncrementEntity)
        {
            return (from faIncrementDetail in faIncrementEntity.FAIncrementDetails
                    let iIncrementDetailId = faIncrementDetail.RefDetailId
                    select new JournalEntryAccountEntity
                    {
                        RefId = faIncrementEntity.RefId,
                        RefTypeId = faIncrementEntity.RefTypeId,
                        RefNo = faIncrementEntity.RefNo,
                        RefDate = faIncrementEntity.RefDate,
                        PostedDate = faIncrementEntity.PostedDate,
                        JournalMemo = faIncrementEntity.JournalMemo,
                        CurrencyCode = faIncrementEntity.CurrencyCode,
                        ExchangeRate = faIncrementEntity.ExchangeRate,
                        BankAccount = "",
                        RefDetailId = iIncrementDetailId,
                        AccountNumber = faIncrementDetail.AccountNumber,
                        CorrespondingAccountNumber = faIncrementDetail.CorrespondingAccountNumber,
                        AmountOc = faIncrementDetail.AmountOC,
                        Description = faIncrementDetail.Description,
                        AmountExchange = faIncrementDetail.AmountExchange,
                        BudgetSourceCode = faIncrementDetail.BudgetSourceCode,
                        BudgetItemCode = faIncrementDetail.BudgetItemCode,
                        MergerFundId = null,
                        VoucherTypeId = faIncrementDetail.VoucherTypeId,
                        ProjectId = faIncrementDetail.ProjectId,
                        CustomerId = faIncrementEntity.CustomerId,
                        VendorId = faIncrementEntity.VendorId,
                        EmployeeId = faIncrementEntity.EmployeeId,
                        AccountingObjectId = faIncrementEntity.AccountingObjectId,
                        BankId = faIncrementEntity.BankId
                    }).ToList();
        }

        public IList<AccountBalanceEntity> AddAccountBalance(FAIncrementEntity faIncrementEntity)
        {
            IList<AccountBalanceEntity> obListAccountBalanceEntity = new List<AccountBalanceEntity>();
            foreach (var faIncrementDetail in faIncrementEntity.FAIncrementDetails)
            {
                var obAccountBalanceEntity = new AccountBalanceEntity
                {
                    BalanceDate = faIncrementEntity.PostedDate,
                    CurrencyCode = faIncrementEntity.CurrencyCode,
                    ExchangeRate = faIncrementEntity.ExchangeRate,
                    AccountNumber = faIncrementDetail.AccountNumber,
                    MovementDebitAmountOC = faIncrementDetail.AmountOC,
                    MovementDebitAmountExchange = faIncrementDetail.AmountExchange,
                    BudgetSourceCode = faIncrementDetail.BudgetSourceCode,
                    BudgetItemCode = faIncrementDetail.BudgetItemCode,
                    ProjectId = faIncrementDetail.ProjectId,
                    MovementCreditAmountOC = 0,
                    MovementCreditAmountExchange = 0,
                    CustomerId = faIncrementEntity.CustomerId,
                    VendorId = faIncrementEntity.VendorId,
                    EmployeeId = faIncrementEntity.EmployeeId,
                    AccountingObjectId = faIncrementEntity.AccountingObjectId
                };
                //Dòng tài khoản nợ
                obListAccountBalanceEntity.Add(obAccountBalanceEntity);
                // Dòng tài khoản có
                var obAccountBalanceEntity1 = new AccountBalanceEntity
                {
                    BalanceDate = faIncrementEntity.PostedDate,
                    CurrencyCode = faIncrementEntity.CurrencyCode,
                    ExchangeRate = faIncrementEntity.ExchangeRate,
                    AccountNumber = faIncrementDetail.CorrespondingAccountNumber,
                    MovementCreditAmountOC = faIncrementDetail.AmountOC,
                    MovementCreditAmountExchange = faIncrementDetail.AmountExchange,
                    BudgetSourceCode = faIncrementDetail.BudgetSourceCode,
                    BudgetItemCode = faIncrementDetail.BudgetItemCode,
                    ProjectId = faIncrementDetail.ProjectId,
                    MovementDebitAmountOC = 0,
                    MovementDebitAmountExchange = 0,
                    CustomerId = faIncrementEntity.CustomerId,
                    VendorId = faIncrementEntity.VendorId,
                    EmployeeId = faIncrementEntity.EmployeeId,
                    AccountingObjectId = faIncrementEntity.AccountingObjectId
                };

                obListAccountBalanceEntity.Add(obAccountBalanceEntity1);
            }

            return obListAccountBalanceEntity;
        }

        public IList<AccountBalanceEntity> AddAccountBalanceOlder(long refId)
        {
            var faIncrementEntity = FixedAssetIncrementDao.GetFAIncrement(refId);
            faIncrementEntity.FAIncrementDetails = FixedAssetIncrementDetailDao.GetFAIncrementDetailByFAIncrement(refId);
            IList<AccountBalanceEntity> obListAccountBalanceEntity = new List<AccountBalanceEntity>();
            foreach (var faIncrementDetail in faIncrementEntity.FAIncrementDetails)
            {
                var obAccountBalanceEntity = new AccountBalanceEntity
                {
                    BalanceDate = faIncrementEntity.PostedDate,
                    CurrencyCode = faIncrementEntity.CurrencyCode,
                    ExchangeRate = faIncrementEntity.ExchangeRate,
                    AccountNumber = faIncrementDetail.AccountNumber,
                    MovementDebitAmountOC = faIncrementDetail.AmountOC,
                    MovementDebitAmountExchange = faIncrementDetail.AmountExchange,
                    BudgetSourceCode = faIncrementDetail.BudgetSourceCode,
                    BudgetItemCode = faIncrementDetail.BudgetItemCode,
                    ProjectId = faIncrementDetail.ProjectId,
                    MovementCreditAmountOC = 0,
                    MovementCreditAmountExchange = 0,
                    CustomerId = faIncrementEntity.CustomerId,
                    VendorId = faIncrementEntity.VendorId,
                    EmployeeId = faIncrementEntity.EmployeeId,
                    AccountingObjectId = faIncrementEntity.AccountingObjectId
                };
                //Dòng tài khoản nợ
                obListAccountBalanceEntity.Add(obAccountBalanceEntity);
                // Dòng tài khoản có
                var obAccountBalanceEntity1 = new AccountBalanceEntity
                {
                    BalanceDate = faIncrementEntity.PostedDate,
                    CurrencyCode = faIncrementEntity.CurrencyCode,
                    ExchangeRate = faIncrementEntity.ExchangeRate,
                    AccountNumber = faIncrementDetail.CorrespondingAccountNumber,
                    MovementCreditAmountOC = faIncrementDetail.AmountOC,
                    MovementCreditAmountExchange = faIncrementDetail.AmountExchange,
                    BudgetSourceCode = faIncrementDetail.BudgetSourceCode,
                    BudgetItemCode = faIncrementDetail.BudgetItemCode,
                    ProjectId = faIncrementDetail.ProjectId,
                    MovementDebitAmountOC = 0,
                    MovementDebitAmountExchange = 0,
                    CustomerId = faIncrementEntity.CustomerId,
                    VendorId = faIncrementEntity.VendorId,
                    EmployeeId = faIncrementEntity.EmployeeId,
                    AccountingObjectId = faIncrementEntity.AccountingObjectId
                };

                obListAccountBalanceEntity.Add(obAccountBalanceEntity1);
            }

            return obListAccountBalanceEntity;
        }

        public FAIncrementResponse InsertFAIncrement(FAIncrementEntity faIncrementEntity, JournalEntryAccountEntity jourentryAccount, List<JournalEntryAccountEntity> journalEntryAccountEntity, List<AccountBalanceEntity> accountBalanceEntity)
        {
            var i = 0;
            if (jourentryAccount == null) throw new ArgumentNullException("jourentryAccount");
            var response = new FAIncrementResponse();

            // insert object Increment
            faIncrementEntity.RefId = FixedAssetIncrementDao.InsertFAIncrement(faIncrementEntity);
            foreach (var faIncrementDetail in faIncrementEntity.FAIncrementDetails) // code sai
            {
                response.RefId = faIncrementEntity.RefId;
                if (!faIncrementDetail.Validate())
                {
                    foreach (string error in faIncrementDetail.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                // insert bang detail
                faIncrementDetail.RefId = faIncrementEntity.RefId;
                //faIncrementDetail.RefDetailId = FixedAssetIncrementDetailDao.InsertFAIncrementDetail(faIncrementDetail);
                var faIncrementDetailId = FixedAssetIncrementDetailDao.InsertFAIncrementDetail(faIncrementDetail);
                // insert bang JourentryAccount
                jourentryAccount = journalEntryAccountEntity[i];
                jourentryAccount.RefId = faIncrementDetail.RefId;
                jourentryAccount.RefDetailId = faIncrementDetailId;

                if (!jourentryAccount.Validate())
                {
                    foreach (string error in jourentryAccount.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                JournalEntryAccountDao.InsertDoubleJournalEntryAccount(jourentryAccount);
                i = i + 1;
            }
            // Kiểm tra đã tồn tại trong bảng Account Balance
            foreach (var accountBalance in accountBalanceEntity)
            {
                var accountBalances = AccountBalanceDao.GetExitsAccountBalance(accountBalance);
                if (accountBalances != null)
                {
                    // cập nhật bên TK nợ
                    if (accountBalance.MovementCreditAmountOC == 0)
                    {
                        accountBalances.ExchangeRate = accountBalance.ExchangeRate;
                        accountBalances.MovementDebitAmountExchange = accountBalances.MovementDebitAmountExchange + accountBalance.MovementDebitAmountExchange;
                        accountBalances.MovementDebitAmountOC = accountBalances.MovementDebitAmountOC + accountBalance.MovementDebitAmountOC;
                        AccountBalanceDao.UpdateAccountBalance(accountBalances);
                    }
                    else
                    {
                        accountBalances.ExchangeRate = accountBalance.ExchangeRate;
                        accountBalances.MovementCreditAmountExchange = accountBalances.MovementCreditAmountExchange + accountBalance.MovementCreditAmountExchange;
                        accountBalances.MovementCreditAmountOC = accountBalances.MovementCreditAmountOC + accountBalance.MovementCreditAmountOC;
                        AccountBalanceDao.UpdateAccountBalance(accountBalances);
                    }
                }
                else
                {
                    AccountBalanceDao.InsertAccountBalance(accountBalance);
                }
            }
            //insert fixedasset ledger
            var fixedAssetLedgers = InitFixedAssetLedgers(faIncrementEntity);
            foreach (var fixedAssetLedgerEntity in fixedAssetLedgers)
            {
                fixedAssetLedgerEntity.FixedAssetLedgerId = FixedAssetLedgerDao.InsertFixedAssetLedger(fixedAssetLedgerEntity);
                if (fixedAssetLedgerEntity.FixedAssetLedgerId != 0) continue;
                response.Acknowledge = AcknowledgeType.Failure;
                return response;
            }
            return response;
        }

        public FAIncrementResponse InsertFAIncrement(FAIncrementEntity faIncrementEntity, bool isAutoGenerateParallel)
        {
            var response = new FAIncrementResponse();
            IList<AccountBalanceEntity> accountBalanceEntity = new List<AccountBalanceEntity>();

            var i = 0;
            if (faIncrementEntity != null)
            {
                if (!faIncrementEntity.Validate())
                {
                    foreach (string error in faIncrementEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                accountBalanceEntity = AddAccountBalance(faIncrementEntity);
            }

            try
            {
                using (var scope = new TransactionScope())
                {
                    faIncrementEntity.RefId = FixedAssetIncrementDao.InsertFAIncrement(faIncrementEntity);
                    if(faIncrementEntity.RefId < 1)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return response;
                    }
                    response.RefId = faIncrementEntity.RefId;

                    #region Insert detail and journalEntryAccount

                    foreach (var faIncrementDetail in faIncrementEntity.FAIncrementDetails)
                    {
                        faIncrementDetail.RefId = faIncrementEntity.RefId;
                        if (!faIncrementDetail.Validate())
                        {
                            foreach (string error in faIncrementDetail.ValidationErrors)
                                response.Message += error + Environment.NewLine;
                            response.Acknowledge = AcknowledgeType.Failure;
                            return response;
                        }
                        faIncrementDetail.RefDetailId = FixedAssetIncrementDetailDao.InsertFAIncrementDetail(faIncrementDetail);
                        if(faIncrementDetail.RefDetailId < 1)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return response;
                        }
                        
                        var journalEntryAccount = MakeJournalEntryAccount(faIncrementEntity, faIncrementDetail);
                        if (!journalEntryAccount.Validate())
                        {
                            foreach (string error in journalEntryAccount.ValidationErrors)
                                response.Message += error + Environment.NewLine;
                            response.Acknowledge = AcknowledgeType.Failure;
                            return response;
                        }
                        JournalEntryAccountDao.InsertDoubleJournalEntryAccount(journalEntryAccount);
                    }

                    #endregion

                    #region Insert accountBalance

                    foreach (var accountBalance in accountBalanceEntity)
                    {
                        var accountBalances = AccountBalanceDao.GetExitsAccountBalance(accountBalance);
                        if (accountBalances != null)
                        {
                            // cập nhật bên TK nợ
                            if (accountBalance.MovementCreditAmountOC == 0)
                            {
                                accountBalances.ExchangeRate = accountBalance.ExchangeRate;
                                accountBalances.MovementDebitAmountExchange = accountBalances.MovementDebitAmountExchange + accountBalance.MovementDebitAmountExchange;
                                accountBalances.MovementDebitAmountOC = accountBalances.MovementDebitAmountOC + accountBalance.MovementDebitAmountOC;
                                AccountBalanceDao.UpdateAccountBalance(accountBalances);
                            }
                            else
                            {
                                accountBalances.ExchangeRate = accountBalance.ExchangeRate;
                                accountBalances.MovementCreditAmountExchange = accountBalances.MovementCreditAmountExchange + accountBalance.MovementCreditAmountExchange;
                                accountBalances.MovementCreditAmountOC = accountBalances.MovementCreditAmountOC + accountBalance.MovementCreditAmountOC;
                                AccountBalanceDao.UpdateAccountBalance(accountBalances);
                            }
                        }
                        else
                        {
                            AccountBalanceDao.InsertAccountBalance(accountBalance);
                        }
                    }

                    #endregion

                    #region Insert fixedassetLedger

                    var fixedAssetLedgers = InitFixedAssetLedgers(faIncrementEntity);
                    foreach (var fixedAssetLedgerEntity in fixedAssetLedgers)
                    {
                        fixedAssetLedgerEntity.FixedAssetLedgerId = FixedAssetLedgerDao.InsertFixedAssetLedger(fixedAssetLedgerEntity);
                        if (fixedAssetLedgerEntity.FixedAssetLedgerId != 0) continue;
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }

                    #endregion

                    #region Insert detailParallel

                    if (!isAutoGenerateParallel)
                    {
                        // nếu không tự sinh định khoản --> lấy định khoản trong grid định khoản
                        if (faIncrementEntity.FAIncrementDetailParallels != null && faIncrementEntity.FAIncrementDetailParallels.Count > 0)
                        {
                            foreach (var faIncrementDetailParallel in faIncrementEntity.FAIncrementDetailParallels)
                            {
                                #region Insert detailParallel

                                faIncrementDetailParallel.RefId = faIncrementEntity.RefId;
                                faIncrementDetailParallel.RefTypeId = faIncrementEntity.RefTypeId;
                                faIncrementDetailParallel.AccountingObjectId = faIncrementEntity.AccountingObjectId;
                                faIncrementDetailParallel.CustomerId = faIncrementEntity.CustomerId;
                                faIncrementDetailParallel.EmployeeId = faIncrementEntity.EmployeeId;
                                faIncrementDetailParallel.VendorId = faIncrementEntity.VendorId;
                                if (!faIncrementDetailParallel.Validate())
                                {
                                    foreach (var error in faIncrementDetailParallel.ValidationErrors)
                                        response.Message += error + Environment.NewLine;
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    scope.Dispose();
                                    return response;
                                }

                                faIncrementDetailParallel.RefDetailId = FixedAssetIncrementDetailParallelDao.InsertFixedAssetIncrementDetailParallel(faIncrementDetailParallel);
                                if (faIncrementDetailParallel.RefDetailId < 1)
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    scope.Dispose();
                                    return response;
                                }

                                #endregion

                                #region Insert JourentryAccount

                                var journalEntryAccount = MakeJournalEntryAccount(faIncrementEntity, faIncrementDetailParallel);
                                journalEntryAccount.JournalEntryId = JournalEntryAccountDao.InsertDoubleJournalEntryAccount(journalEntryAccount);
                                if (journalEntryAccount.JournalEntryId < 1)
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    scope.Dispose();
                                    return response;
                                }

                                #endregion
                            }
                        }
                    }
                    else
                    {
                        //truong hop sinh tu dong se sinh theo chung tu chi tiet
                        if (faIncrementEntity.FAIncrementDetails != null && faIncrementEntity.FAIncrementDetails.Count > 0)
                        {
                            foreach (var faIncrementDetail in faIncrementEntity.FAIncrementDetails)
                            {
                                var budgetSourceId = BudgetSourceDao.GetBudgetSourceByBudgetSourceCode(faIncrementDetail.BudgetSourceCode);
                                var budgetItemId = BudgetItemDao.GetBudgetItemsByCode(faIncrementDetail.BudgetItemCode);
                                //insert dl moi
                                var autoBusinessParallelEntitys = AutoBusinessParallelDao.GetAutoBusinessParallelsByAutoBussinessInformations(
                                    faIncrementDetail.AccountNumber
                                    , faIncrementDetail.CorrespondingAccountNumber
                                    , budgetSourceId == null ? 0 : budgetSourceId.BudgetSourceId
                                    , (budgetItemId == null || budgetItemId.Count == 0) ? 0 : budgetItemId.FirstOrDefault().BudgetItemId
                                    , 0
                                    , faIncrementDetail.VoucherTypeId == null ? 0 : (int)faIncrementDetail.VoucherTypeId);

                                if (autoBusinessParallelEntitys != null)
                                {
                                    foreach (var autoBusinessParallelEntity in autoBusinessParallelEntitys)
                                    {
                                        #region Insert DetailParallel

                                        var faIncrementDetailParallel = MakeFAIncrementDetailParallel(faIncrementEntity, faIncrementDetail, autoBusinessParallelEntity);
                                        faIncrementDetailParallel.RefDetailId = 0;
                                        if (!faIncrementDetailParallel.Validate())
                                        {
                                            foreach (var error in faIncrementDetailParallel.ValidationErrors)
                                                response.Message += error + Environment.NewLine;
                                            response.Acknowledge = AcknowledgeType.Failure;
                                            scope.Dispose();
                                            return response;
                                        }

                                        faIncrementDetailParallel.RefDetailId = FixedAssetIncrementDetailParallelDao.InsertFixedAssetIncrementDetailParallel(faIncrementDetailParallel);
                                        if (faIncrementDetailParallel.RefDetailId < 1)
                                        {
                                            response.Acknowledge = AcknowledgeType.Failure;
                                            scope.Dispose();
                                            return response;
                                        }

                                        #endregion

                                        #region Insert JournalEntryAccount

                                        var journalEntryAccount = MakeJournalEntryAccount(faIncrementEntity, faIncrementDetailParallel);
                                        journalEntryAccount.JournalEntryId = JournalEntryAccountDao.InsertDoubleJournalEntryAccount(journalEntryAccount);
                                        if (journalEntryAccount.JournalEntryId < 1)
                                        {
                                            response.Acknowledge = AcknowledgeType.Failure;
                                            scope.Dispose();
                                            return response;
                                        }

                                        #endregion
                                    }
                                }
                            }
                        }
                    }

                    #endregion

                    #region Insert autoNumber

                    if (response.Acknowledge == AcknowledgeType.Failure)
                        scope.Dispose();
                    else
                    {
                        if (faIncrementEntity != null)
                        {
                            var autoNumber = AutoNumberDao.GetAutoNumberByRefType(faIncrementEntity.RefTypeId);

                            if (faIncrementEntity.CurrencyCode == "USD")
                                autoNumber.Value += 1;
                            else autoNumber.ValueLocalCurency += 1;

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

                    #endregion
                }
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                throw;
            }
            response.Acknowledge = response.Message != null ? AcknowledgeType.Failure : AcknowledgeType.Success;
            return response;
        }

        public FAIncrementResponse InsertFAIncrement(IList<FAIncrementEntity> faIncrementEntities, bool isAutoGenerateParallel)
        {
            var response = new FAIncrementResponse();
            try
            {
                using (var scope = new TransactionScope())
                {
                    foreach (var faIncrement in faIncrementEntities)
                    {
                        response = InsertFAIncrement(faIncrement, isAutoGenerateParallel);
                        if (response.Acknowledge == AcknowledgeType.Failure)
                        {
                            scope.Dispose();
                            return response;
                        }
                    }
                    if (response.Message == null)
                        scope.Complete();
                }
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                throw;
            }
            response.Acknowledge = response.Message != null ? AcknowledgeType.Failure : AcknowledgeType.Success;
            return response;
        }

        public FAIncrementResponse UpdateFAIncrement(FAIncrementEntity faIncrementEntity, bool isAutoGenerateParallel)
        {
            var response = new FAIncrementResponse();
            IList<AccountBalanceEntity> accountBalanceEntity = new List<AccountBalanceEntity>();

            var i = 0;
            if (faIncrementEntity != null)
            {
                if (!faIncrementEntity.Validate())
                {
                    foreach (string error in faIncrementEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                accountBalanceEntity = AddAccountBalance(faIncrementEntity);
            }

            try
            {
                using (var scope = new TransactionScope())
                {
                    response.Message = FixedAssetIncrementDao.UpdateFAIncrement(faIncrementEntity);
                    if (response.Message != null)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return response;
                    }

                    #region Cân đối tài khoản

                    accountBalanceEntity.Clear();
                    if (faIncrementEntity != null) accountBalanceEntity = AddAccountBalanceOlder(faIncrementEntity.RefId);
                    foreach (var accountBalance in accountBalanceEntity)
                    {
                        var accountBalances = AccountBalanceDao.GetExitsAccountBalance(accountBalance);
                        if (accountBalances != null)
                        {
                            // cập nhật bên TK nợ
                            if (accountBalance.MovementCreditAmountOC == 0)
                            {
                                accountBalances.ExchangeRate = accountBalance.ExchangeRate;
                                accountBalances.MovementDebitAmountExchange = accountBalances.MovementDebitAmountExchange - accountBalance.MovementDebitAmountExchange;
                                accountBalances.MovementDebitAmountOC = accountBalances.MovementDebitAmountOC - accountBalance.MovementDebitAmountOC;
                                AccountBalanceDao.UpdateAccountBalance(accountBalances);
                            }
                            else
                            {
                                accountBalances.ExchangeRate = accountBalance.ExchangeRate;
                                accountBalances.MovementCreditAmountExchange = accountBalances.MovementCreditAmountExchange - accountBalance.MovementCreditAmountExchange;
                                accountBalances.MovementCreditAmountOC = accountBalances.MovementCreditAmountOC - accountBalances.MovementCreditAmountOC;
                                AccountBalanceDao.UpdateAccountBalance(accountBalances);
                            }
                        }

                    }
                    // Cập nhật lại dữ liệu vào bảng cân đối tài khoản
                    accountBalanceEntity.Clear();
                    accountBalanceEntity = AddAccountBalance(faIncrementEntity);
                    foreach (var accountBalance in accountBalanceEntity)
                    {
                        var accountBalances = AccountBalanceDao.GetExitsAccountBalance(accountBalance);
                        if (accountBalances != null)
                        {
                            // cập nhật bên TK nợ
                            if (accountBalance.MovementCreditAmountOC == 0)
                            {
                                accountBalances.ExchangeRate = accountBalance.ExchangeRate;
                                accountBalances.MovementDebitAmountExchange = accountBalances.MovementDebitAmountExchange + accountBalance.MovementDebitAmountExchange;
                                accountBalances.MovementDebitAmountOC = accountBalances.MovementDebitAmountOC + accountBalance.MovementDebitAmountOC;
                                AccountBalanceDao.UpdateAccountBalance(accountBalances);
                            }
                            else
                            {
                                accountBalances.ExchangeRate = accountBalance.ExchangeRate;
                                accountBalances.MovementCreditAmountExchange = accountBalances.MovementCreditAmountExchange + accountBalance.MovementCreditAmountExchange;
                                accountBalances.MovementCreditAmountOC = accountBalances.MovementCreditAmountOC + accountBalance.MovementCreditAmountOC;
                                AccountBalanceDao.UpdateAccountBalance(accountBalances);
                            }
                        }
                        else
                        {
                            AccountBalanceDao.InsertAccountBalance(accountBalance);
                        }
                    }
                    // Xóa dữ liệu trống trong bảng Cân đối tài khoản
                    AccountBalanceDao.DeleteAccountBalance();

                    #endregion

                    #region Delete and insert detail, joournalentryAccount

                    response.Message = FixedAssetIncrementDetailDao.DeleteFAIncrementDetailByFAIncrement(faIncrementEntity.RefId);
                    if (response.Message != null)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return response;
                    }
                    response.Message = JournalEntryAccountDao.DeleteJournalEntryAccount(new JournalEntryAccountEntity()
                    {
                        RefId = faIncrementEntity.RefId,
                        RefTypeId = faIncrementEntity.RefTypeId
                    });
                    if (response.Message != null)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return response;
                    }

                    foreach (var faIncrementDetail in faIncrementEntity.FAIncrementDetails)
                    {
                        if (!faIncrementDetail.Validate())
                        {
                            foreach (string error in faIncrementDetail.ValidationErrors)
                                response.Message += error + Environment.NewLine;
                            response.Acknowledge = AcknowledgeType.Failure;
                            return response;
                        }
                        if (faIncrementDetail.FixedAssetId == 0)
                            faIncrementDetail.FixedAssetId = null;
                        faIncrementDetail.RefId = faIncrementEntity.RefId;
                        faIncrementDetail.RefDetailId = FixedAssetIncrementDetailDao.InsertFAIncrementDetail(faIncrementDetail);
                        if (faIncrementDetail.RefDetailId < 1)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return response;
                        }

                        var journalEntryAccount = MakeJournalEntryAccount(faIncrementEntity, faIncrementDetail);
                        if (!journalEntryAccount.Validate())
                        {
                            foreach (string error in journalEntryAccount.ValidationErrors)
                                response.Message += error + Environment.NewLine;
                            response.Acknowledge = AcknowledgeType.Failure;
                            return response;
                        }
                        JournalEntryAccountDao.InsertDoubleJournalEntryAccount(journalEntryAccount);
                    }

                    #endregion

                    #region Insert FixedAssetLedger

                    response.Message = FixedAssetLedgerDao.DeleteFixedAssetLedgerByRefId(faIncrementEntity.RefId, faIncrementEntity.RefTypeId);
                    if (response.Message != null)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return response;
                    }
                    var fixedAssetLedgers = InitFixedAssetLedgers(faIncrementEntity);
                    foreach (var fixedAssetLedgerEntity in fixedAssetLedgers)
                    {
                        if (fixedAssetLedgerEntity.FixedAssetId != 0)
                            fixedAssetLedgerEntity.FixedAssetLedgerId = FixedAssetLedgerDao.InsertFixedAssetLedger(fixedAssetLedgerEntity);
                        if (fixedAssetLedgerEntity.FixedAssetLedgerId != 0) continue;
                        response.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return response;
                    }

                    #endregion

                    #region Insert detailParallel

                    // xóa dữ liệu cũ (journal entry account đã xóa cùng với mục details)
                    response.Message = FixedAssetIncrementDetailParallelDao.DeleteFixedAssetIncrementDetailParallelById(faIncrementEntity.RefId);
                    if (response.Message != null)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return response;
                    }

                    // thêm dữ liệu mới
                    if (!isAutoGenerateParallel)
                    {
                        //neu khong tu dong sinh dinh khoan dong thoi -> lay theo grid dinh khoan dong thoi
                        if (faIncrementEntity.FAIncrementDetailParallels != null && faIncrementEntity.FAIncrementDetailParallels.Count > 0)
                        {
                            foreach (var faIncrementDetailParallel in faIncrementEntity.FAIncrementDetailParallels)
                            {
                                #region Insert DetailParallel

                                faIncrementDetailParallel.RefId = faIncrementEntity.RefId;
                                faIncrementDetailParallel.RefTypeId = faIncrementEntity.RefTypeId;
                                faIncrementDetailParallel.AccountingObjectId = faIncrementEntity.AccountingObjectId;
                                faIncrementDetailParallel.CustomerId = faIncrementEntity.CustomerId;
                                faIncrementDetailParallel.EmployeeId = faIncrementEntity.EmployeeId;
                                faIncrementDetailParallel.VendorId = faIncrementEntity.VendorId;
                                if (!faIncrementDetailParallel.Validate())
                                {
                                    foreach (var error in faIncrementDetailParallel.ValidationErrors)
                                        response.Message += error + Environment.NewLine;
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    scope.Dispose();
                                    return response;
                                }

                                faIncrementDetailParallel.RefDetailId = FixedAssetIncrementDetailParallelDao.InsertFixedAssetIncrementDetailParallel(faIncrementDetailParallel);
                                if (faIncrementDetailParallel.RefDetailId < 1)
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    scope.Dispose();
                                    return response;
                                }

                                #endregion

                                #region Insert JournalEntryAccount

                                var journalEntryAccount = MakeJournalEntryAccount(faIncrementEntity, faIncrementDetailParallel);
                                journalEntryAccount.JournalEntryId = JournalEntryAccountDao.InsertDoubleJournalEntryAccount(journalEntryAccount);
                                if (journalEntryAccount.JournalEntryId < 1)
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    scope.Dispose();
                                    return response;
                                }

                                #endregion
                            }
                        }
                    }
                    else
                    {
                        //truong hop sinh tu dong se sinh theo chung tu chi tiet
                        foreach (var faIncrementDetail in faIncrementEntity.FAIncrementDetails)
                        {
                            var budgetSourceId = BudgetSourceDao.GetBudgetSourceByBudgetSourceCode(faIncrementDetail.BudgetSourceCode);
                            var budgetItemId = BudgetItemDao.GetBudgetItemsByCode(faIncrementDetail.BudgetItemCode);

                            var autoBusinessParallelEntitys = AutoBusinessParallelDao.GetAutoBusinessParallelsByAutoBussinessInformations(
                                faIncrementDetail.AccountNumber
                                , faIncrementDetail.CorrespondingAccountNumber
                                , budgetSourceId == null ? 0 : budgetSourceId.BudgetSourceId
                                , (budgetItemId == null || budgetItemId.Count == 0) ? 0 : budgetItemId.FirstOrDefault().BudgetItemId
                                , 0
                                , faIncrementDetail.VoucherTypeId == null ? 0 : (int)faIncrementDetail.VoucherTypeId);

                            if (autoBusinessParallelEntitys != null)
                            {
                                foreach (var autoBusinessParallelEntity in autoBusinessParallelEntitys)
                                {
                                    #region Insert ItemTransactionDetailParallel

                                    var faIncrementDetailParallel = MakeFAIncrementDetailParallel(faIncrementEntity, faIncrementDetail, autoBusinessParallelEntity);
                                    if (!faIncrementDetailParallel.Validate())
                                    {
                                        foreach (var error in faIncrementDetailParallel.ValidationErrors)
                                            response.Message += error + Environment.NewLine;
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        scope.Dispose();
                                        return response;
                                    }

                                    faIncrementDetailParallel.RefDetailId = FixedAssetIncrementDetailParallelDao.InsertFixedAssetIncrementDetailParallel(faIncrementDetailParallel);
                                    if (faIncrementDetailParallel.RefDetailId < 1)
                                    {
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        scope.Dispose();
                                        return response;
                                    }

                                    #endregion

                                    #region Insert JournalEntryAccount

                                    var journalEntryAccount = MakeJournalEntryAccount(faIncrementEntity, faIncrementDetailParallel);
                                    journalEntryAccount.JournalEntryId = JournalEntryAccountDao.InsertDoubleJournalEntryAccount(journalEntryAccount);
                                    if (journalEntryAccount.JournalEntryId < 1)
                                    {
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        scope.Dispose();
                                        return response;
                                    }

                                    #endregion
                                }
                            }
                        }
                    }

                    #endregion

                    response.RefId = faIncrementEntity.RefId;
                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                throw;
            }
            response.Acknowledge = response.Message != null ? AcknowledgeType.Failure : AcknowledgeType.Success;
            return response;
        }

        public FAIncrementResponse DeleteFAIncrement(long refId)
        {
            var response = new FAIncrementResponse();
            IList<AccountBalanceEntity> accountBalanceEntity = new List<AccountBalanceEntity>();
            try
            {
                using (var scope = new TransactionScope())
                {
                    var details = FixedAssetIncrementDetailDao.GetFAIncrementDetailByFAIncrement(refId);
                    var fAIncrementForDelete = FixedAssetIncrementDao.GetFAIncrement(refId);
                    response.Message = FixedAssetIncrementDao.DeleteFAIncrement(fAIncrementForDelete);
                    if (response.Message != null)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return response;
                    }

                    #region Delete from journalEntryAccount

                    response.Message = JournalEntryAccountDao.DeleteJournalEntryAccount(new JournalEntryAccountEntity()
                    {
                        RefId = fAIncrementForDelete.RefId,
                        RefNo = fAIncrementForDelete.RefNo,
                        RefTypeId = fAIncrementForDelete.RefTypeId
                    });
                    if (response.Message != null)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return response;
                    }

                    #endregion

                    #region Cập nhật lại dữ liệu vào bảng cân đối tài khoản

                    accountBalanceEntity.Clear();
                    accountBalanceEntity = AddAccountBalance(fAIncrementForDelete);
                    foreach (var accountBalance in accountBalanceEntity)
                    {
                        var accountBalances = AccountBalanceDao.GetExitsAccountBalance(accountBalance);
                        if (accountBalances != null)
                        {
                            // cập nhật bên TK nợ
                            if (accountBalance.MovementCreditAmountOC == 0)
                            {
                                accountBalances.ExchangeRate = accountBalance.ExchangeRate;
                                accountBalances.MovementDebitAmountExchange = accountBalances.MovementDebitAmountExchange - accountBalance.MovementDebitAmountExchange;
                                accountBalances.MovementDebitAmountOC = accountBalances.MovementDebitAmountOC - accountBalance.MovementDebitAmountOC;
                                AccountBalanceDao.UpdateAccountBalance(accountBalances);
                            }
                            else
                            {
                                accountBalances.ExchangeRate = accountBalance.ExchangeRate;
                                accountBalances.MovementCreditAmountExchange = accountBalances.MovementCreditAmountExchange - accountBalance.MovementCreditAmountExchange;
                                accountBalances.MovementCreditAmountOC = accountBalances.MovementCreditAmountOC - accountBalance.MovementCreditAmountOC;
                                AccountBalanceDao.UpdateAccountBalance(accountBalances);
                            }
                        }
                    }
                    // Xóa dữ liệu trống trong bảng Cân đối tài khoản
                    AccountBalanceDao.DeleteAccountBalance();
                    if (response.Message != null)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return response;
                    }

                    #endregion

                    #region Delete from fixedAssetLedger

                    response.Message = FixedAssetLedgerDao.DeleteFixedAssetLedgerByRefId(fAIncrementForDelete.RefId,
                        fAIncrementForDelete.RefTypeId);
                    if (response.Message != null)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return response;
                    }

                    #endregion

                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                throw;
            }
            response.Acknowledge = response.Message != null ? AcknowledgeType.Failure : AcknowledgeType.Success;
            return response;
        }

        #region Make object

        public JournalEntryAccountEntity MakeJournalEntryAccount(FAIncrementEntity fAIncrement, FAIncrementDetailEntity fAIncrementDetail)
        {
            var result = new JournalEntryAccountEntity();
            result.RefId = fAIncrement.RefId;
            result.RefTypeId = fAIncrement.RefTypeId;
            result.RefNo = fAIncrement.RefNo;
            result.RefDate = fAIncrement.RefDate;
            result.PostedDate = fAIncrement.PostedDate;
            result.JournalMemo = fAIncrement.JournalMemo;
            result.CurrencyCode = fAIncrement.CurrencyCode;
            result.ExchangeRate = fAIncrement.ExchangeRate;
            result.BankAccount = "";
            result.RefDetailId = fAIncrementDetail.RefDetailId;
            result.AccountNumber = fAIncrementDetail.AccountNumber;
            result.CorrespondingAccountNumber = fAIncrementDetail.CorrespondingAccountNumber;
            result.AmountOc = fAIncrementDetail.AmountOC;
            result.Description = fAIncrementDetail.Description;
            result.AmountExchange = fAIncrementDetail.AmountExchange;
            result.BudgetSourceCode = fAIncrementDetail.BudgetSourceCode;
            result.BudgetItemCode = fAIncrementDetail.BudgetItemCode;
            result.MergerFundId = null;
            result.VoucherTypeId = fAIncrementDetail.VoucherTypeId;
            result.ProjectId = fAIncrementDetail.ProjectId;
            result.CustomerId = fAIncrement.CustomerId;
            result.VendorId = fAIncrement.VendorId;
            result.EmployeeId = fAIncrement.EmployeeId;
            result.AccountingObjectId = fAIncrement.AccountingObjectId;
            result.BankId = fAIncrement.BankId;
            result.Quantity = fAIncrementDetail.Quantity;
            return result;
        }

        public JournalEntryAccountEntity MakeJournalEntryAccount(FAIncrementEntity faIncrement, FAIncrementDetailParallelEntity faIncrementDetailParallel)
        {
            var journalEntryAccount = new JournalEntryAccountEntity();
            if (faIncrementDetailParallel != null)
            {
                journalEntryAccount.RefDetailId = faIncrementDetailParallel.RefDetailId;
                journalEntryAccount.RefId = faIncrementDetailParallel.RefId;
                journalEntryAccount.RefTypeId = faIncrementDetailParallel.RefTypeId;
                journalEntryAccount.RefNo = faIncrement.RefNo;
                journalEntryAccount.RefDate = faIncrement.RefDate;
                journalEntryAccount.PostedDate = faIncrement.PostedDate;
                journalEntryAccount.Description = faIncrementDetailParallel.Description;
                journalEntryAccount.JournalMemo = faIncrement.JournalMemo;
                journalEntryAccount.CurrencyCode = faIncrement.CurrencyCode;
                journalEntryAccount.ExchangeRate = faIncrement.ExchangeRate;
                journalEntryAccount.AccountNumber = faIncrementDetailParallel.AccountNumber;
                journalEntryAccount.CorrespondingAccountNumber = faIncrementDetailParallel.CorrespondingAccountNumber;
                journalEntryAccount.Quantity = faIncrementDetailParallel.Quantity;
                //journalEntryAccount.JournalType = 
                journalEntryAccount.AmountOc = faIncrementDetailParallel.AmountOc;
                journalEntryAccount.AmountExchange = faIncrementDetailParallel.AmountExchange;
                journalEntryAccount.BudgetSourceCode = faIncrementDetailParallel.BudgetSourceCode;
                journalEntryAccount.BudgetItemCode = faIncrementDetailParallel.BudgetItemCode;
                journalEntryAccount.CustomerId = faIncrement.CustomerId;
                journalEntryAccount.VendorId = faIncrement.VendorId;
                journalEntryAccount.EmployeeId = faIncrement.EmployeeId;
                journalEntryAccount.AccountingObjectId = faIncrement.AccountingObjectId;
                journalEntryAccount.VoucherTypeId = faIncrementDetailParallel.VoucherTypeId;
                journalEntryAccount.MergerFundId = faIncrementDetailParallel.MergerFundId;
                journalEntryAccount.ProjectId = faIncrementDetailParallel.ProjectId;
                journalEntryAccount.InventoryItemId = faIncrementDetailParallel.InventoryItemId;
                journalEntryAccount.BankId = faIncrement.BankId;
                //journalEntryAccount.BankAccount 
            }
            return journalEntryAccount;
        }

        public FAIncrementDetailParallelEntity MakeFAIncrementDetailParallel(FAIncrementEntity faIncrement, FAIncrementDetailEntity faIncrementDetail, AutoBusinessParallelEntity autoBusinessParallel)
        {
            var faDecrementDetailParallel = new FAIncrementDetailParallelEntity();
            faDecrementDetailParallel.RefDetailId = faIncrementDetail.RefDetailId;
            faDecrementDetailParallel.RefId = faIncrementDetail.RefId;
            faDecrementDetailParallel.RefTypeId = faIncrement.RefTypeId;
            faDecrementDetailParallel.Description = faIncrementDetail.Description;
            faDecrementDetailParallel.AccountNumber = autoBusinessParallel.DebitAccountParallel;//faDecrementDetail.AccountNumber;
            faDecrementDetailParallel.CorrespondingAccountNumber = autoBusinessParallel.CreditAccountParallel;//faDecrementDetail.CorrespondingAccountNumber;
            faDecrementDetailParallel.Quantity = faIncrementDetail.Quantity;
            if (autoBusinessParallel.IsNegative)
            {
                faDecrementDetailParallel.Price = -1 * faIncrementDetail.UnitPriceOC;
                faDecrementDetailParallel.PriceExchange = -1 * faIncrementDetail.UnitPriceExchange;
                faDecrementDetailParallel.AmountOc = -1 * faIncrementDetail.AmountOC;
                faDecrementDetailParallel.AmountExchange = -1 * faIncrementDetail.AmountExchange;
            }
            else
            {
                faDecrementDetailParallel.Price = faIncrementDetail.UnitPriceOC;
                faDecrementDetailParallel.PriceExchange = faIncrementDetail.UnitPriceExchange;
                faDecrementDetailParallel.AmountOc = faIncrementDetail.AmountOC;
                faDecrementDetailParallel.AmountExchange = faIncrementDetail.AmountExchange;
            }
            faDecrementDetailParallel.BudgetSourceCode = autoBusinessParallel.BudgetSourceIdParallel == 0 ? faIncrementDetail.BudgetSourceCode : (BudgetSourceDao.GetBudgetSource(autoBusinessParallel.BudgetSourceIdParallel)?.BudgetSourceCode ?? null);
            faDecrementDetailParallel.BudgetItemCode = autoBusinessParallel.BudgetItemIdParallel == 0 ? faIncrementDetail.BudgetItemCode : (BudgetItemDao.GetBudgetItem(autoBusinessParallel.BudgetItemIdParallel)?.BudgetItemCode ?? null);
            faDecrementDetailParallel.VoucherTypeId = autoBusinessParallel.VoucherTypeIdParallel == 0 ? faIncrementDetail.VoucherTypeId : autoBusinessParallel.VoucherTypeIdParallel;
            faDecrementDetailParallel.DepartmentId = faIncrementDetail.DepartmentId;
            faDecrementDetailParallel.ProjectId = faIncrementDetail.ProjectId;
            faDecrementDetailParallel.FixedAssetId = faIncrementDetail.FixedAssetId;
            faDecrementDetailParallel.InventoryItemId = null;
            faDecrementDetailParallel.MergerFundId = null;
            faDecrementDetailParallel.AccountingObjectId = faIncrement.AccountingObjectId;
            faDecrementDetailParallel.EmployeeId = faIncrement.EmployeeId;
            faDecrementDetailParallel.CustomerId = faIncrement.CustomerId;
            faDecrementDetailParallel.VendorId = faIncrement.VendorId;

            return faDecrementDetailParallel;
        }

        #endregion

    }
}
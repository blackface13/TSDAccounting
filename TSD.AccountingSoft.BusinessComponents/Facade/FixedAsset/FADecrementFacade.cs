/***********************************************************************
 * <copyright file="FADecrementFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Thursday, April 10, 2014
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
using TSD.AccountingSoft.BusinessEntities.Business.FixedAssetDecrement;
using TSD.AccountingSoft.BusinessEntities.Dictionary;
using TSD.AccountingSoft.DataAccess.IEntitiesDao;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.FixedAsset;


namespace TSD.AccountingSoft.BusinessComponents.Facade.FixedAsset
{
    /// <summary>
    /// class FADecrementFacade
    /// </summary>
    public class FADecrementFacade
    {
        private static readonly IFixedAssetDecrementDao FixedAssetDecrementDao = DataAccess.DataAccess.FixedAssetDecrementDao;
        private static readonly IFixedAssetDecrementDetailDao FixedAssetDecrementDetailDao = DataAccess.DataAccess.FixedAssetDecrementDetailDao;
        private static readonly IFixedAssetDecrementDetailParallelDao FixedAssetDecrementDetailParallelDao = DataAccess.DataAccess.FixedAssetDecrementDetailParallelDao;
        private static readonly IAutoNumberDao AutoNumberDao = DataAccess.DataAccess.AutoNumberDao;
        private static readonly IAudittingLogDao AudittingLogDao = DataAccess.DataAccess.AudittingLogDao;
        private static readonly IFixedAssetLedgerDao FixedAssetLedgerDao = DataAccess.DataAccess.FixedAssetLedgerDao;
        private static readonly IJournalEntryAccountDao JournalEntryAccountDao = DataAccess.DataAccess.JournalEntryAccountDao;
        private static readonly IAccountBalanceDao AccountBalanceDao = DataAccess.DataAccess.AccountBalanceDao;
        private static readonly IAutoBusinessParallelDao AutoBusinessParallelDao = DataAccess.DataAccess.AutoBusinessParallelDao;
        private static readonly IBudgetSourceDao BudgetSourceDao = DataAccess.DataAccess.BudgetSourceDao;
        private static readonly IBudgetItemDao BudgetItemDao = DataAccess.DataAccess.BudgetItemDao;

        /// <summary>
        /// Gets the fa decrements.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public FADecrementResponse GetFADecrements(FADecrementRequest request)
        {
            var response = new FADecrementResponse();
            if (request.LoadOptions.Contains("FADecrements"))
            {
                if (request.LoadOptions.Contains("RefType"))
                    response.FADecrements = FixedAssetDecrementDao.GetFADecrementesByRefTypeId(request.RefType);
                else if (request.LoadOptions.Contains("RefDate"))
                    response.FADecrements = FixedAssetDecrementDao.GetFADecrementsByYearOfRefDate((short)DateTime.Parse(request.RefDate).Year);
                else response.FADecrements = FixedAssetDecrementDao.GetFADecrementes();
            }

            if (request.LoadOptions.Contains("FADecrement"))
            {
                var faDecrement = FixedAssetDecrementDao.GetFADecrement(request.RefId);
                if (request.LoadOptions.Contains("IncludeDetail"))
                {
                    faDecrement = faDecrement ?? new FADecrementEntity();
                    faDecrement.FADecrementDetails = FixedAssetDecrementDetailDao.GetFADecresementDetailByFADecresement(faDecrement.RefId);
                    faDecrement.FADecrementDetailParallels = FixedAssetDecrementDetailParallelDao.GetFixedAssetDecrementDetailParallelByRefId(faDecrement.RefId);
                }


                response.FADecrement = faDecrement;
            }

            if (request.LoadOptions.Contains("FADecrementCheck"))
            {
                //var faDecrement = FixedAssetDecrementDao.GetFADecrement(request.RefId);
                //if (request.LoadOptions.Contains("IncludeDetail"))
                //{
                //    faDecrement = faDecrement ?? new FADecrementEntity();
                //    faDecrement.FADecrementDetails = FixedAssetDecrementDetailDao.GetFADecrementByFAIncrement(faDecrement.RefId);
                //}
                var a = FixedAssetDecrementDetailDao.GetFADecrementByFAIncrement(request.RefId);
                response.FADecrementDetails = a;
            }


            return response;
        }

        /// <summary>
        /// Sets the fa decrements.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public FADecrementResponse SetFADecrements(FADecrementRequest request)
        {
            var response = new FADecrementResponse();

            var faDecrementEntity = request.FADecrement;
            //var auditingLog = new AudittingLogEntity { ComponentName = "GHI GIAM TSCD", EventAction = (int)request.Action };
            if (request.Action != PersistType.Delete)
            {
                if (faDecrementEntity != null)
                {
                    if (!faDecrementEntity.Validate())
                    {
                        foreach (string error in faDecrementEntity.ValidationErrors)
                            response.Message += error + Environment.NewLine;
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }
                }
            }
            try
            {
                if (request.Action == PersistType.Insert)
                {
                    if (request.FADecrements == null)
                    {
                        using (var scope = new TransactionScope())
                        {
                            // Kiểm tra mã chứng từ trùng trong ngày
                            if (faDecrementEntity != null)
                            {
                                var fixedAssetByCode = FixedAssetDecrementDao.GetFADecrementesByRefRefNoAndRefDate(faDecrementEntity.CurrencyCode, faDecrementEntity.RefNo, faDecrementEntity.RefDate);
                                if (fixedAssetByCode.Count != 0)
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    response.Message = @"Mã chứng từ " + faDecrementEntity.RefNo + " trong ngày " + faDecrementEntity.RefDate.ToShortDateString() + @" đã tồn tại !";
                                    return response;
                                }
                            }

                            if (faDecrementEntity != null)
                            {
                                faDecrementEntity.RefId = FixedAssetDecrementDao.InsertFADecrement(faDecrementEntity);
                                foreach (var faDecrementDetail in faDecrementEntity.FADecrementDetails)
                                {
                                    if (!faDecrementDetail.Validate())
                                    {
                                        foreach (string error in faDecrementDetail.ValidationErrors)
                                            response.Message += error + Environment.NewLine;
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        return response;
                                    }
                                    faDecrementDetail.RefId = faDecrementEntity.RefId;
                                    faDecrementDetail.RefDetailId =
                                        FixedAssetDecrementDetailDao.InsertFADecreasementDetail(faDecrementDetail);

                                    if (faDecrementDetail.RefDetailId == 0)
                                    {
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        scope.Dispose();
                                        return response;
                                    }

                                    //insert jounaral entry
                                    var journalEntryAccount = AddJournalEntryAccount(faDecrementEntity,
                                        faDecrementDetail);
                                    if (!journalEntryAccount.Validate())
                                    {
                                        foreach (var error in journalEntryAccount.ValidationErrors)
                                            response.Message += error + Environment.NewLine;
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        return response;
                                    }
                                    JournalEntryAccountDao.InsertDoubleJournalEntryAccount(journalEntryAccount);

                                    //insert AccountBalance
                                    InsertAccountBalance(faDecrementEntity, faDecrementDetail);
                                }

                                //insert fixedasset ledger
                                var fixedAssetLedgers = InitFixedAssetLedgers(faDecrementEntity);
                                foreach (var fixedAssetLedgerEntity in fixedAssetLedgers)
                                {
                                    fixedAssetLedgerEntity.FixedAssetLedgerId =
                                        FixedAssetLedgerDao.InsertFixedAssetLedger(fixedAssetLedgerEntity);
                                    if (fixedAssetLedgerEntity.FixedAssetLedgerId != 0) continue;
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    scope.Dispose();
                                    return response;
                                }

                                //insert auto number
                                var autoNumber = AutoNumberDao.GetAutoNumberByRefType(faDecrementEntity.RefTypeId);
                                //------------------------------------------------------------------
                                //LinhMC 29/11/2014
                                //Lưu giá trị số tự động tăng theo loại tiền
                                //---------------------------------------------------------------
                                if (faDecrementEntity.CurrencyCode == "USD")
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

                            //insert log
                            //auditingLog.Reference = "Thêm mới chứng từ ghi giảm TSCĐ " + faDecrementEntity.RefNo;
                            //auditingLog.Amount = 0;
                            //AudittingLogDao.InsertAudittingLog(auditingLog);

                            scope.Complete();
                        }
                    }
                    else
                    {
                        using (var scope = new TransactionScope())
                        {
                            foreach (var faDecrement in request.FADecrements)
                            {
                                // Kiểm tra mã chứng từ trùng trong ngày
                                var fixedAssetByCode = FixedAssetDecrementDao.GetFADecrementesByRefRefNoAndRefDate(faDecrement.CurrencyCode, faDecrement.RefNo, faDecrement.RefDate);
                                if (fixedAssetByCode.Count != 0)
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    response.Message = @"Mã chứng từ " + faDecrement.RefNo + " trong ngày " + faDecrement.RefDate.ToShortDateString() + @" đã tồn tại !";
                                    return response;
                                }

                                faDecrement.RefId = FixedAssetDecrementDao.InsertFADecrement(faDecrement);
                                foreach (var faDecrementDetail in faDecrement.FADecrementDetails)
                                {
                                    if (!faDecrementDetail.Validate())
                                    {
                                        foreach (string error in faDecrementDetail.ValidationErrors)
                                            response.Message += error + Environment.NewLine;
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        return response;
                                    }
                                    faDecrementDetail.RefId = faDecrement.RefId;
                                    faDecrementDetail.RefDetailId =
                                        FixedAssetDecrementDetailDao.InsertFADecreasementDetail(faDecrementDetail);

                                    if (faDecrementDetail.RefDetailId == 0)
                                    {
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        scope.Dispose();
                                        return response;
                                    }

                                    //insert jounaral entry
                                    var journalEntryAccount = AddJournalEntryAccount(faDecrement,
                                                                                     faDecrementDetail);
                                    if (!journalEntryAccount.Validate())
                                    {
                                        foreach (var error in journalEntryAccount.ValidationErrors)
                                            response.Message += error + Environment.NewLine;
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        return response;
                                    }
                                    JournalEntryAccountDao.InsertDoubleJournalEntryAccount(journalEntryAccount);

                                    //insert AccountBalance
                                    InsertAccountBalance(faDecrement, faDecrementDetail);
                                }

                                //insert fixedasset ledger
                                var fixedAssetLedgers = InitFixedAssetLedgers(faDecrement);
                                foreach (var fixedAssetLedgerEntity in fixedAssetLedgers)
                                {
                                    fixedAssetLedgerEntity.FixedAssetLedgerId =
                                        FixedAssetLedgerDao.InsertFixedAssetLedger(fixedAssetLedgerEntity);
                                    if (fixedAssetLedgerEntity.FixedAssetLedgerId != 0) continue;
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    scope.Dispose();
                                    return response;
                                }

                                //insert auto number
                                var autoNumber = AutoNumberDao.GetAutoNumberByRefType(faDecrement.RefTypeId);

                                if (faDecrement.CurrencyCode == "USD")
                                    autoNumber.Value += 1;
                                else autoNumber.ValueLocalCurency += 1;

                                response.Message = AutoNumberDao.UpdateAutoNumber(autoNumber);

                                if (response.Message != null)
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    scope.Dispose();
                                    return response;
                                }

                                //insert log
                                //auditingLog.Reference = "Thêm mới chứng từ ghi giảm TSCĐ " + faDecrement.RefNo;
                                //auditingLog.Amount = 0;
                                //AudittingLogDao.InsertAudittingLog(auditingLog);

                                response.RefId = faDecrement.RefId;
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
                        response.Message = FixedAssetDecrementDao.UpdateFADecrement(faDecrementEntity);
                        if (response.Message != null)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return response;
                        }

                        //update account balance
                        response.Message = UpdateAccountBalance(faDecrementEntity);
                        if (response.Message != null)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return response;
                        }

                        //delete JournalEntryAccount
                        if (faDecrementEntity != null)
                        {
                            response.Message = JournalEntryAccountDao.DeleteJournalEntryAccount(faDecrementEntity.RefId,
                                faDecrementEntity.RefTypeId);
                            if (response.Message != null)
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                scope.Dispose();
                                return response;
                            }

                            //delete detail
                            response.Message =
                                FixedAssetDecrementDetailDao.DeleteFADecreasementDetailByFADecreasement(
                                    faDecrementEntity.RefId);
                            if (response.Message != null)
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                scope.Dispose();
                                return response;
                            }
                            foreach (var faDecrementDetail in faDecrementEntity.FADecrementDetails)
                            {
                                if (!faDecrementDetail.Validate())
                                {
                                    foreach (string error in faDecrementDetail.ValidationErrors)
                                        response.Message += error + Environment.NewLine;
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }
                                faDecrementDetail.RefId = faDecrementEntity.RefId;
                                faDecrementDetail.RefDetailId =
                                    FixedAssetDecrementDetailDao.InsertFADecreasementDetail(faDecrementDetail);
                                if (faDecrementDetail.RefDetailId == 0)
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    scope.Dispose();
                                    return response;
                                }

                                //insert jounaral entry
                                var journalEntryAccount = AddJournalEntryAccount(faDecrementEntity, faDecrementDetail);
                                if (!journalEntryAccount.Validate())
                                {
                                    foreach (var error in journalEntryAccount.ValidationErrors)
                                        response.Message += error + Environment.NewLine;
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }
                                JournalEntryAccountDao.InsertDoubleJournalEntryAccount(journalEntryAccount);

                                //insert AccountBalance
                                InsertAccountBalance(faDecrementEntity, faDecrementDetail);
                            }

                            //delete ledger
                            response.Message = FixedAssetLedgerDao.DeleteFixedAssetLedgerByRefId(faDecrementEntity.RefId,
                                faDecrementEntity.RefTypeId);
                            if (response.Message != null)
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                scope.Dispose();
                                return response;
                            }

                            //insert ledger
                            var fixedAssetLedgers = InitFixedAssetLedgers(faDecrementEntity);
                            foreach (var fixedAssetLedgerEntity in fixedAssetLedgers)
                            {
                                fixedAssetLedgerEntity.FixedAssetLedgerId =
                                    FixedAssetLedgerDao.InsertFixedAssetLedger(fixedAssetLedgerEntity);
                                if (fixedAssetLedgerEntity.FixedAssetLedgerId != 0) continue;
                                response.Acknowledge = AcknowledgeType.Failure;
                                scope.Dispose();
                                return response;
                            }
                        }

                        //insert log
                        //auditingLog.Reference = "Cập nhật chứng từ ghi giảm TSCĐ " + faDecrementEntity.RefNo;
                        //auditingLog.Amount = 0;
                        //AudittingLogDao.InsertAudittingLog(auditingLog);

                        scope.Complete();
                    }
                }
                else
                {
                    using (var scope = new TransactionScope())
                    {
                        var faDecrementEntityForDelete = FixedAssetDecrementDao.GetFADecrement(request.RefId);

                        //update account balance
                        response.Message = UpdateAccountBalance(faDecrementEntityForDelete);
                        if (response.Message != null)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return response;
                        }

                        //delete JournalEntryAccount
                        response.Message =
                            JournalEntryAccountDao.DeleteJournalEntryAccount(faDecrementEntityForDelete.RefId,
                                                                             faDecrementEntityForDelete.RefTypeId);
                        if (response.Message != null)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return response;
                        }

                        //delete master
                        response.Message = FixedAssetDecrementDao.DeleteFADecrement(faDecrementEntityForDelete);
                        if (response.Message != null)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return response;
                        }

                        //delete fixedAsset ledger
                        response.Message =
                            FixedAssetLedgerDao.DeleteFixedAssetLedgerByRefId(faDecrementEntityForDelete.RefId,
                                                                              faDecrementEntityForDelete.RefTypeId);
                        if (response.Message != null)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return response;
                        }
                        //insert log
                        //auditingLog.Reference = "Xóa chứng từ ghi giảm TSCĐ " + faDecrementEntityForDelete.RefNo;
                        //auditingLog.Amount = 0;
                        //AudittingLogDao.InsertAudittingLog(auditingLog);

                        scope.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }

            if (request.FADecrements == null)
                response.RefId = faDecrementEntity != null ? faDecrementEntity.RefId : 0;
            response.Acknowledge = response.Message != null ? AcknowledgeType.Failure : AcknowledgeType.Success;
            return response;
        }

        public FADecrementResponse InsertFADecrement(FADecrementEntity faDecrementEntity, bool isAutoGenerateParallel)
        {
            var response = new FADecrementResponse();
            if (faDecrementEntity != null)
            {
                if (!faDecrementEntity.Validate())
                {
                    foreach (string error in faDecrementEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
            }
            try
            {
                using (var scope = new TransactionScope())
                {
                    // Kiểm tra mã chứng từ trùng trong ngày
                    if (faDecrementEntity != null)
                    {
                        var fixedAssetByCode = FixedAssetDecrementDao.GetFADecrementesByRefRefNoAndRefDate(faDecrementEntity.CurrencyCode, faDecrementEntity.RefNo, faDecrementEntity.RefDate);
                        if (fixedAssetByCode.Count != 0)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            response.Message = @"Mã chứng từ " + faDecrementEntity.RefNo + " trong ngày " + faDecrementEntity.RefDate.ToShortDateString() + @" đã tồn tại !";
                            return response;
                        }
                    }

                    if (faDecrementEntity != null)
                    {
                        faDecrementEntity.RefId = FixedAssetDecrementDao.InsertFADecrement(faDecrementEntity);
                        if (faDecrementEntity.RefId < 1)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return response;
                        }

                        #region Insert detail

                        foreach (var faDecrementDetail in faDecrementEntity.FADecrementDetails)
                        {
                            if (!faDecrementDetail.Validate())
                            {
                                foreach (string error in faDecrementDetail.ValidationErrors)
                                    response.Message += error + Environment.NewLine;
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }
                            faDecrementDetail.RefId = faDecrementEntity.RefId;
                            faDecrementDetail.RefDetailId =
                                FixedAssetDecrementDetailDao.InsertFADecreasementDetail(faDecrementDetail);

                            if (faDecrementDetail.RefDetailId == 0)
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                scope.Dispose();
                                return response;
                            }

                            //insert jounaral entry
                            var journalEntryAccount = AddJournalEntryAccount(faDecrementEntity, faDecrementDetail);
                            if (!journalEntryAccount.Validate())
                            {
                                foreach (var error in journalEntryAccount.ValidationErrors)
                                    response.Message += error + Environment.NewLine;
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }
                            JournalEntryAccountDao.InsertDoubleJournalEntryAccount(journalEntryAccount);

                            //insert AccountBalance
                            InsertAccountBalance(faDecrementEntity, faDecrementDetail);
                        }

                        #endregion

                        #region  Insert fixedasset ledger

                        var fixedAssetLedgers = InitFixedAssetLedgers(faDecrementEntity);
                        foreach (var fixedAssetLedgerEntity in fixedAssetLedgers)
                        {
                            fixedAssetLedgerEntity.FixedAssetLedgerId =
                                FixedAssetLedgerDao.InsertFixedAssetLedger(fixedAssetLedgerEntity);
                            if (fixedAssetLedgerEntity.FixedAssetLedgerId != 0) continue;
                            response.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return response;
                        }

                        #endregion

                        #region Insert detail parallel

                        if (!isAutoGenerateParallel)
                        {
                            // nếu không tự sinh định khoản --> lấy định khoản trong grid định khoản
                            if (faDecrementEntity.FADecrementDetailParallels != null && faDecrementEntity.FADecrementDetailParallels.Count > 0)
                            {
                                foreach (var faDecrementDetailParallel in faDecrementEntity.FADecrementDetailParallels)
                                {
                                    #region Insert ItemTransactionDetailParallel

                                    faDecrementDetailParallel.RefId = faDecrementEntity.RefId;
                                    faDecrementDetailParallel.RefTypeId = faDecrementEntity.RefTypeId;
                                    faDecrementDetailParallel.AccountingObjectId = faDecrementEntity.AccountingObjectId;
                                    faDecrementDetailParallel.CustomerId = faDecrementEntity.CustomerId;
                                    faDecrementDetailParallel.EmployeeId = faDecrementEntity.EmployeeId;
                                    faDecrementDetailParallel.VendorId = faDecrementEntity.VendorId;
                                    if (!faDecrementDetailParallel.Validate())
                                    {
                                        foreach (var error in faDecrementDetailParallel.ValidationErrors)
                                            response.Message += error + Environment.NewLine;
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        scope.Dispose();
                                        return response;
                                    }

                                    faDecrementDetailParallel.RefDetailId = FixedAssetDecrementDetailParallelDao.InsertFixedAssetDecrementDetailParallel(faDecrementDetailParallel);
                                    if (faDecrementDetailParallel.RefDetailId < 1)
                                    {
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        scope.Dispose();
                                        return response;
                                    }

                                    #endregion

                                    #region Insert JourentryAccount

                                    var journalEntryAccount = MakeJournalEntryAccount(faDecrementEntity, faDecrementDetailParallel);
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
                            if (faDecrementEntity.FADecrementDetails != null && faDecrementEntity.FADecrementDetails.Count > 0)
                            {
                                foreach (var faDecrementDetail in faDecrementEntity.FADecrementDetails)
                                {
                                    var budgetSourceId = BudgetSourceDao.GetBudgetSourceByBudgetSourceCode(faDecrementDetail.BudgetSourceCode);
                                    var budgetItemId = BudgetItemDao.GetBudgetItemsByCode(faDecrementDetail.BudgetItemCode);
                                    //insert dl moi
                                    var autoBusinessParallelEntitys = AutoBusinessParallelDao.GetAutoBusinessParallelsByAutoBussinessInformations(
                                        faDecrementDetail.AccountNumber
                                        , faDecrementDetail.CorrespondingAccountNumber
                                        , budgetSourceId == null ? 0 : budgetSourceId.BudgetSourceId
                                        , (budgetItemId == null || budgetItemId.Count == 0) ? 0 : budgetItemId.FirstOrDefault().BudgetItemId
                                        , 0
                                        , faDecrementDetail.VoucherTypeId == null ? 0 : (int)faDecrementDetail.VoucherTypeId);

                                    if (autoBusinessParallelEntitys != null)
                                    {
                                        foreach (var autoBusinessParallelEntity in autoBusinessParallelEntitys)
                                        {
                                            #region Insert ItemTransactionDetailParallel

                                            var faDecrementDetailParallel = MakeFADecrementDetailParallel(faDecrementEntity, faDecrementDetail, autoBusinessParallelEntity);
                                            faDecrementDetailParallel.RefDetailId = 0;
                                            if (!faDecrementDetailParallel.Validate())
                                            {
                                                foreach (var error in faDecrementDetailParallel.ValidationErrors)
                                                    response.Message += error + Environment.NewLine;
                                                response.Acknowledge = AcknowledgeType.Failure;
                                                scope.Dispose();
                                                return response;
                                            }

                                            faDecrementDetailParallel.RefDetailId = FixedAssetDecrementDetailParallelDao.InsertFixedAssetDecrementDetailParallel(faDecrementDetailParallel);
                                            if (faDecrementDetailParallel.RefDetailId < 1)
                                            {
                                                response.Acknowledge = AcknowledgeType.Failure;
                                                scope.Dispose();
                                                return response;
                                            }

                                            #endregion

                                            #region Insert JournalEntryAccount

                                            var journalEntryAccount = MakeJournalEntryAccount(faDecrementEntity, faDecrementDetailParallel);
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

                        #region Insert auto number

                        var autoNumber = AutoNumberDao.GetAutoNumberByRefType(faDecrementEntity.RefTypeId);
                        //------------------------------------------------------------------
                        //LinhMC 29/11/2014
                        //Lưu giá trị số tự động tăng theo loại tiền
                        //---------------------------------------------------------------
                        if (faDecrementEntity.CurrencyCode == "USD")
                            autoNumber.Value += 1;
                        else autoNumber.ValueLocalCurency += 1;

                        response.Message = AutoNumberDao.UpdateAutoNumber(autoNumber);

                        #endregion
                    }
                    if (response.Message != null)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return response;
                    }

                    //insert log
                    //auditingLog.Reference = "Thêm mới chứng từ ghi giảm TSCĐ " + faDecrementEntity.RefNo;
                    //auditingLog.Amount = 0;
                    //AudittingLogDao.InsertAudittingLog(auditingLog);

                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Acknowledge = AcknowledgeType.Failure;
            }

            response.Acknowledge = response.Message != null ? AcknowledgeType.Failure : AcknowledgeType.Success;
            response.RefId = faDecrementEntity.RefId;
            return response;
        }

        public FADecrementResponse InsertFADecrement(IList<FADecrementEntity> faDecrementEntities, bool isAutoGenerateParallel)
        {
            var response = new FADecrementResponse();
            try
            {
                using (var scope = new TransactionScope())
                {
                    foreach (var faDecrement in faDecrementEntities)
                    {
                        // Kiểm tra mã chứng từ trùng trong ngày
                        var fixedAssetByCode = FixedAssetDecrementDao.GetFADecrementesByRefRefNoAndRefDate(faDecrement.CurrencyCode, faDecrement.RefNo, faDecrement.RefDate);
                        if (fixedAssetByCode.Count != 0)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            response.Message = @"Mã chứng từ " + faDecrement.RefNo + " trong ngày " + faDecrement.RefDate.ToShortDateString() + @" đã tồn tại !";
                            return response;
                        }

                        faDecrement.RefId = FixedAssetDecrementDao.InsertFADecrement(faDecrement);
                        if (faDecrement.RefId < 1)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return response;
                        }

                        #region Insert detail

                        foreach (var faDecrementDetail in faDecrement.FADecrementDetails)
                        {
                            

                            if (!faDecrementDetail.Validate())
                            {
                                foreach (string error in faDecrementDetail.ValidationErrors)
                                    response.Message += error + Environment.NewLine;
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }
                            faDecrementDetail.RefId = faDecrement.RefId;
                            faDecrementDetail.RefDetailId = FixedAssetDecrementDetailDao.InsertFADecreasementDetail(faDecrementDetail);
                            if (faDecrementDetail.RefDetailId == 0)
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                scope.Dispose();
                                return response;
                            }

                            var journalEntryAccount = AddJournalEntryAccount(faDecrement, faDecrementDetail);
                            if (!journalEntryAccount.Validate())
                            {
                                foreach (var error in journalEntryAccount.ValidationErrors)
                                    response.Message += error + Environment.NewLine;
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }
                            JournalEntryAccountDao.InsertDoubleJournalEntryAccount(journalEntryAccount);

                            //insert AccountBalance
                            InsertAccountBalance(faDecrement, faDecrementDetail);
                        }

                        #endregion

                        #region Insert fixedasset ledger

                        var fixedAssetLedgers = InitFixedAssetLedgers(faDecrement);
                        foreach (var fixedAssetLedgerEntity in fixedAssetLedgers)
                        {
                            fixedAssetLedgerEntity.FixedAssetLedgerId =
                                FixedAssetLedgerDao.InsertFixedAssetLedger(fixedAssetLedgerEntity);
                            if (fixedAssetLedgerEntity.FixedAssetLedgerId != 0) continue;
                            response.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return response;
                        }

                        #endregion

                        #region Insert detail parallel

                        if (!isAutoGenerateParallel)
                        {
                            // nếu không tự sinh định khoản --> lấy định khoản trong grid định khoản
                            if (faDecrement.FADecrementDetailParallels != null && faDecrement.FADecrementDetailParallels.Count > 0)
                            {
                                foreach (var faDecrementDetailParallel in faDecrement.FADecrementDetailParallels)
                                {
                                    #region Insert ItemTransactionDetailParallel

                                    faDecrementDetailParallel.RefId = faDecrement.RefId;
                                    faDecrementDetailParallel.RefTypeId = faDecrement.RefTypeId;
                                    faDecrementDetailParallel.AccountingObjectId = faDecrement.AccountingObjectId;
                                    faDecrementDetailParallel.CustomerId = faDecrement.CustomerId;
                                    faDecrementDetailParallel.EmployeeId = faDecrement.EmployeeId;
                                    faDecrementDetailParallel.VendorId = faDecrement.VendorId;
                                    if (!faDecrementDetailParallel.Validate())
                                    {
                                        foreach (var error in faDecrementDetailParallel.ValidationErrors)
                                            response.Message += error + Environment.NewLine;
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        scope.Dispose();
                                        return response;
                                    }

                                    faDecrementDetailParallel.RefDetailId = FixedAssetDecrementDetailParallelDao.InsertFixedAssetDecrementDetailParallel(faDecrementDetailParallel);
                                    if (faDecrementDetailParallel.RefDetailId < 1)
                                    {
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        scope.Dispose();
                                        return response;
                                    }

                                    #endregion

                                    #region Insert JourentryAccount

                                    var journalEntryAccount = MakeJournalEntryAccount(faDecrement, faDecrementDetailParallel);
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
                            if (faDecrement.FADecrementDetails != null && faDecrement.FADecrementDetails.Count > 0)
                            {
                                foreach (var faDecrementDetail in faDecrement.FADecrementDetails)
                                {
                                    var budgetSourceId = BudgetSourceDao.GetBudgetSourceByBudgetSourceCode(faDecrementDetail.BudgetSourceCode);
                                    var budgetItemId = BudgetItemDao.GetBudgetItemsByCode(faDecrementDetail.BudgetItemCode);
                                    //insert dl moi
                                    var autoBusinessParallelEntitys = AutoBusinessParallelDao.GetAutoBusinessParallelsByAutoBussinessInformations(
                                        faDecrementDetail.AccountNumber
                                        , faDecrementDetail.CorrespondingAccountNumber
                                        , budgetSourceId == null ? 0 : budgetSourceId.BudgetSourceId
                                        , (budgetItemId == null || budgetItemId.Count == 0) ? 0 : budgetItemId.FirstOrDefault().BudgetItemId
                                        , 0
                                        , faDecrementDetail.VoucherTypeId == null ? 0 : (int)faDecrementDetail.VoucherTypeId);

                                    if (autoBusinessParallelEntitys != null)
                                    {
                                        foreach (var autoBusinessParallelEntity in autoBusinessParallelEntitys)
                                        {
                                            #region Insert ItemTransactionDetailParallel

                                            var faDecrementDetailParallel = MakeFADecrementDetailParallel(faDecrement, faDecrementDetail, autoBusinessParallelEntity);
                                            faDecrementDetailParallel.RefDetailId = 0;
                                            if (!faDecrementDetailParallel.Validate())
                                            {
                                                foreach (var error in faDecrementDetailParallel.ValidationErrors)
                                                    response.Message += error + Environment.NewLine;
                                                response.Acknowledge = AcknowledgeType.Failure;
                                                scope.Dispose();
                                                return response;
                                            }

                                            faDecrementDetailParallel.RefDetailId = FixedAssetDecrementDetailParallelDao.InsertFixedAssetDecrementDetailParallel(faDecrementDetailParallel);
                                            if (faDecrementDetailParallel.RefDetailId < 1)
                                            {
                                                response.Acknowledge = AcknowledgeType.Failure;
                                                scope.Dispose();
                                                return response;
                                            }

                                            #endregion

                                            #region Insert JournalEntryAccount

                                            var journalEntryAccount = MakeJournalEntryAccount(faDecrement, faDecrementDetailParallel);
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

                        #region Insert auto number

                        var autoNumber = AutoNumberDao.GetAutoNumberByRefType(faDecrement.RefTypeId);

                        if (faDecrement.CurrencyCode == "USD")
                            autoNumber.Value += 1;
                        else autoNumber.ValueLocalCurency += 1;

                        response.Message = AutoNumberDao.UpdateAutoNumber(autoNumber);

                        if (response.Message != null)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return response;
                        }

                        #endregion

                        //insert log
                        //auditingLog.Reference = "Thêm mới chứng từ ghi giảm TSCĐ " + faDecrement.RefNo;
                        //auditingLog.Amount = 0;
                        //AudittingLogDao.InsertAudittingLog(auditingLog);

                        response.RefId = faDecrement.RefId;
                    }
                    if (response.Message != null)
                        scope.Dispose();
                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Acknowledge = AcknowledgeType.Failure;
            }
            response.Acknowledge = response.Message != null ? AcknowledgeType.Failure : AcknowledgeType.Success;
            return response;
        }

        public FADecrementResponse UpdateFADecrement(FADecrementEntity faDecrementEntity, bool isAutoGenerateParallel)
        {
            var response = new FADecrementResponse();
            if (faDecrementEntity != null)
            {
                if (!faDecrementEntity.Validate())
                {
                    foreach (string error in faDecrementEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
            }
            try
            {
                using (var scope = new TransactionScope())
                {
                    response.Message = FixedAssetDecrementDao.UpdateFADecrement(faDecrementEntity);
                    if (response.Message != null)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return response;
                    }

                    #region Update account balance

                    response.Message = UpdateAccountBalance(faDecrementEntity);
                    if (response.Message != null)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return response;
                    }

                    #endregion

                    #region Update Detail And JournalEntryAccount

                    response.Message = JournalEntryAccountDao.DeleteJournalEntryAccount(faDecrementEntity.RefId, faDecrementEntity.RefTypeId);
                    if (response.Message != null)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return response;
                    }

                    response.Message = FixedAssetDecrementDetailDao.DeleteFADecreasementDetailByFADecreasement(faDecrementEntity.RefId);
                    if (response.Message != null)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return response;
                    }

                    foreach (var faDecrementDetail in faDecrementEntity.FADecrementDetails)
                    {
                        if (!faDecrementDetail.Validate())
                        {
                            foreach (string error in faDecrementDetail.ValidationErrors)
                                response.Message += error + Environment.NewLine;
                            response.Acknowledge = AcknowledgeType.Failure;
                            return response;
                        }
                        faDecrementDetail.RefId = faDecrementEntity.RefId;
                        faDecrementDetail.RefDetailId =
                            FixedAssetDecrementDetailDao.InsertFADecreasementDetail(faDecrementDetail);
                        if (faDecrementDetail.RefDetailId == 0)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return response;
                        }

                        //insert jounaral entry
                        var journalEntryAccount = AddJournalEntryAccount(faDecrementEntity, faDecrementDetail);
                        if (!journalEntryAccount.Validate())
                        {
                            foreach (var error in journalEntryAccount.ValidationErrors)
                                response.Message += error + Environment.NewLine;
                            response.Acknowledge = AcknowledgeType.Failure;
                            return response;
                        }
                        JournalEntryAccountDao.InsertDoubleJournalEntryAccount(journalEntryAccount);

                        //insert AccountBalance
                        InsertAccountBalance(faDecrementEntity, faDecrementDetail);
                    }

                    #endregion

                    #region Update ledger

                    response.Message = FixedAssetLedgerDao.DeleteFixedAssetLedgerByRefId(faDecrementEntity.RefId, faDecrementEntity.RefTypeId);
                    if (response.Message != null)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return response;
                    }

                    var fixedAssetLedgers = InitFixedAssetLedgers(faDecrementEntity);
                    foreach (var fixedAssetLedgerEntity in fixedAssetLedgers)
                    {
                        fixedAssetLedgerEntity.FixedAssetLedgerId =
                            FixedAssetLedgerDao.InsertFixedAssetLedger(fixedAssetLedgerEntity);
                        if (fixedAssetLedgerEntity.FixedAssetLedgerId != 0) continue;
                        response.Acknowledge = AcknowledgeType.Failure;
                        scope.Dispose();
                        return response;
                    }

                    #endregion

                    #region Update DetailParallel And JournalEntryAccount

                    // xóa dữ liệu cũ (journal entry account đã xóa cùng với mục details)
                    response.Message = FixedAssetDecrementDetailParallelDao.DeleteFixedAssetDecrementDetailParallelById(faDecrementEntity.RefId);
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
                        if (faDecrementEntity.FADecrementDetailParallels != null && faDecrementEntity.FADecrementDetailParallels.Count > 0)
                        {
                            foreach (var faDecrementDetailParallel in faDecrementEntity.FADecrementDetailParallels)
                            {
                                #region Insert ItemTransactionDetailParallel

                                faDecrementDetailParallel.RefId = faDecrementEntity.RefId;
                                faDecrementDetailParallel.RefTypeId = faDecrementEntity.RefTypeId;
                                faDecrementDetailParallel.AccountingObjectId = faDecrementEntity.AccountingObjectId;
                                faDecrementDetailParallel.CustomerId = faDecrementEntity.CustomerId;
                                faDecrementDetailParallel.EmployeeId = faDecrementEntity.EmployeeId;
                                faDecrementDetailParallel.VendorId = faDecrementEntity.VendorId;
                                if (!faDecrementDetailParallel.Validate())
                                {
                                    foreach (var error in faDecrementDetailParallel.ValidationErrors)
                                        response.Message += error + Environment.NewLine;
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    scope.Dispose();
                                    return response;
                                }

                                faDecrementDetailParallel.RefDetailId = FixedAssetDecrementDetailParallelDao.InsertFixedAssetDecrementDetailParallel(faDecrementDetailParallel);
                                if (faDecrementDetailParallel.RefDetailId < 1)
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    scope.Dispose();
                                    return response;
                                }

                                #endregion

                                #region Insert JournalEntryAccount

                                var journalEntryAccount = MakeJournalEntryAccount(faDecrementEntity, faDecrementDetailParallel);
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
                        foreach (var faDecrementDetail in faDecrementEntity.FADecrementDetails)
                        {
                            var budgetSourceId = BudgetSourceDao.GetBudgetSourceByBudgetSourceCode(faDecrementDetail.BudgetSourceCode);
                            var budgetItemId = BudgetItemDao.GetBudgetItemsByCode(faDecrementDetail.BudgetItemCode);

                            var autoBusinessParallelEntitys = AutoBusinessParallelDao.GetAutoBusinessParallelsByAutoBussinessInformations(
                                faDecrementDetail.AccountNumber
                                , faDecrementDetail.CorrespondingAccountNumber
                                , budgetSourceId == null ? 0 : budgetSourceId.BudgetSourceId
                                , (budgetItemId == null || budgetItemId.Count == 0) ? 0 : budgetItemId.FirstOrDefault().BudgetItemId
                                , 0
                                , faDecrementDetail.VoucherTypeId == null ? 0 : (int)faDecrementDetail.VoucherTypeId);

                            if (autoBusinessParallelEntitys != null)
                            {
                                foreach (var autoBusinessParallelEntity in autoBusinessParallelEntitys)
                                {
                                    #region Insert ItemTransactionDetailParallel

                                    var faDecrementDetailParallel = MakeFADecrementDetailParallel(faDecrementEntity, faDecrementDetail, autoBusinessParallelEntity);
                                    if (!faDecrementDetailParallel.Validate())
                                    {
                                        foreach (var error in faDecrementDetailParallel.ValidationErrors)
                                            response.Message += error + Environment.NewLine;
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        scope.Dispose();
                                        return response;
                                    }

                                    faDecrementDetailParallel.RefDetailId = FixedAssetDecrementDetailParallelDao.InsertFixedAssetDecrementDetailParallel(faDecrementDetailParallel);
                                    if (faDecrementDetailParallel.RefDetailId < 1)
                                    {
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        scope.Dispose();
                                        return response;
                                    }

                                    #endregion

                                    #region Insert JournalEntryAccount

                                    var journalEntryAccount = MakeJournalEntryAccount(faDecrementEntity, faDecrementDetailParallel);
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

                    //insert log
                    //auditingLog.Reference = "Cập nhật chứng từ ghi giảm TSCĐ " + faDecrementEntity.RefNo;
                    //auditingLog.Amount = 0;
                    //AudittingLogDao.InsertAudittingLog(auditingLog);

                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Acknowledge = AcknowledgeType.Failure;
            }
            response.Acknowledge = response.Message != null ? AcknowledgeType.Failure : AcknowledgeType.Success;
            response.RefId = faDecrementEntity.RefId;
            return response;
        }

        public FADecrementResponse DeleteFADecrement(long refId)
        {
            var response = new FADecrementResponse();
            try
            {
                    using (var scope = new TransactionScope())
                    {
                        var faDecrementEntityForDelete = FixedAssetDecrementDao.GetFADecrement(refId);

                        //update account balance
                        response.Message = UpdateAccountBalance(faDecrementEntityForDelete);
                        if (response.Message != null)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return response;
                        }

                        //delete JournalEntryAccount
                        response.Message = JournalEntryAccountDao.DeleteJournalEntryAccount(faDecrementEntityForDelete.RefId, faDecrementEntityForDelete.RefTypeId);
                        if (response.Message != null)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return response;
                        }

                        //delete master
                        response.Message = FixedAssetDecrementDao.DeleteFADecrement(faDecrementEntityForDelete);
                        if (response.Message != null)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return response;
                        }

                        //delete fixedAsset ledger
                        response.Message = FixedAssetLedgerDao.DeleteFixedAssetLedgerByRefId(faDecrementEntityForDelete.RefId, faDecrementEntityForDelete.RefTypeId);
                        if (response.Message != null)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return response;
                        }
                        //insert log
                        //auditingLog.Reference = "Xóa chứng từ ghi giảm TSCĐ " + faDecrementEntityForDelete.RefNo;
                        //auditingLog.Amount = 0;
                        //AudittingLogDao.InsertAudittingLog(auditingLog);

                        scope.Complete();
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

        /// <summary>
        /// Initializes the fixed asset ledgers.
        /// </summary>
        /// <param name="faDecrementEntity">The fa decrement entity.</param>
        /// <returns></returns>
        private IEnumerable<FixedAssetLedgerEntity> InitFixedAssetLedgers(FADecrementEntity faDecrementEntity)
        {
            var fixedAssetLedgers = new List<FixedAssetLedgerEntity>();
            foreach (var faDecrementDetail in faDecrementEntity.FADecrementDetails)
            {
                var fixedAssetLedger = new FixedAssetLedgerEntity
                {
                    RefId = faDecrementDetail.RefId,
                    RefTypeId = faDecrementEntity.RefTypeId,
                    RefNo = faDecrementEntity.RefNo,
                    RefDate = faDecrementEntity.RefDate,
                    PostedDate = faDecrementEntity.PostedDate,
                    FixedAssetId = faDecrementDetail.FixedAssetId,
                    DepartmentId = faDecrementDetail.DepartmentId,
                    CurrencyCode = faDecrementEntity.CurrencyCode,
                    OrgPriceAccount = "",
                    OrgPriceDebitAmount = 0,
                    OrgPriceCreditAmount = 0,
                    OrgPriceDebitAmountExchange = 0,
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
                    JournalMemo = faDecrementEntity.JournalMemo,
                    Description = faDecrementDetail.Description,
                    ExchangeRate = faDecrementEntity.ExchangeRate,
                    Quantity = faDecrementDetail.Quantity
                };
                if (fixedAssetLedgers.Count == 0 || (from item in fixedAssetLedgers
                                                     where (item.FixedAssetId == faDecrementDetail.FixedAssetId)
                                                     select item).FirstOrDefault() == null)
                {
                    fixedAssetLedger = AddFixedAssetLedgerEntity(faDecrementDetail, fixedAssetLedger, faDecrementEntity.CurrencyCode);
                    fixedAssetLedgers.Add(fixedAssetLedger);
                }
                else
                {
                    fixedAssetLedger = (from item in fixedAssetLedgers
                                        where (item.FixedAssetId == faDecrementDetail.FixedAssetId)
                                        select item).First();
                    fixedAssetLedgers.Remove(fixedAssetLedger);
                    fixedAssetLedgers.Add(AddFixedAssetLedgerEntity(faDecrementDetail, fixedAssetLedger, faDecrementEntity.CurrencyCode));
                }
            }
            return fixedAssetLedgers;
        }

        /// <summary>
        /// Adds the fixed asset ledger entity.
        /// </summary>
        /// <param name="faDecrementDetail">The f a armortization detail.</param>
        /// <param name="fixedAssetLedger">The fixed asset ledger.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns></returns>
        private static FixedAssetLedgerEntity AddFixedAssetLedgerEntity(FADecrementDetailEntity faDecrementDetail, FixedAssetLedgerEntity fixedAssetLedger, string currencyCode)
        {
            if (faDecrementDetail.AccountNumber.Contains("466"))
            {
                fixedAssetLedger.BudgetSourceAccount = faDecrementDetail.AccountNumber;
                if (currencyCode == "USD")
                {
                    fixedAssetLedger.BudgetSourcelDebitAmount += faDecrementDetail.AmountOC;
                    fixedAssetLedger.BudgetSourcelDebitAmountExchange += faDecrementDetail.AmountOC;
                }
                else
                {
                    fixedAssetLedger.BudgetSourcelDebitAmount += faDecrementDetail.AmountOC;
                    fixedAssetLedger.BudgetSourcelDebitAmountExchange += faDecrementDetail.AmountExchange;
                }
            }
            if (faDecrementDetail.AccountNumber.Contains("214"))
            {
                fixedAssetLedger.DepreciationAccount = faDecrementDetail.AccountNumber;
                if (currencyCode == "USD")
                {
                    fixedAssetLedger.DepreciationDebitAmount += faDecrementDetail.AmountOC;
                    fixedAssetLedger.DepreciationDebitAmountExchange += faDecrementDetail.AmountOC;
                }
                else
                {
                    fixedAssetLedger.DepreciationDebitAmount += faDecrementDetail.AmountOC;
                    fixedAssetLedger.DepreciationDebitAmountExchange += faDecrementDetail.AmountExchange;
                }
            }
            if (faDecrementDetail.CorrespondingAccountNumber.Contains("211") || faDecrementDetail.CorrespondingAccountNumber.Contains("213"))
            {
                fixedAssetLedger.OrgPriceAccount = faDecrementDetail.CorrespondingAccountNumber;
                if (currencyCode == "USD")
                {
                    fixedAssetLedger.OrgPriceCreditAmount += faDecrementDetail.AmountOC;
                    fixedAssetLedger.OrgPriceCreditAmountExchange += faDecrementDetail.AmountOC;
                }
                else
                {
                    fixedAssetLedger.OrgPriceCreditAmount += faDecrementDetail.AmountOC;
                    fixedAssetLedger.OrgPriceCreditAmountExchange += faDecrementDetail.AmountExchange;
                }
            }
            return fixedAssetLedger;
        }

        /// <summary>
        /// Adds the journal entry account.
        /// </summary>
        /// <param name="faDecrementEntity">The fa armortization entity.</param>
        /// <param name="faDecrementDetailEntity">The fa armortization detail entity.</param>
        /// <returns></returns>
        public JournalEntryAccountEntity AddJournalEntryAccount(FADecrementEntity faDecrementEntity, FADecrementDetailEntity faDecrementDetailEntity)
        {
            return new JournalEntryAccountEntity
            {
                RefId = faDecrementEntity.RefId,
                RefTypeId = faDecrementEntity.RefTypeId,
                RefNo = faDecrementEntity.RefNo,
                RefDate = faDecrementEntity.RefDate,
                PostedDate = faDecrementEntity.PostedDate,
                JournalMemo = faDecrementEntity.JournalMemo,
                CurrencyCode = faDecrementEntity.CurrencyCode,
                ExchangeRate = faDecrementEntity.ExchangeRate,
                BankAccount = null,
                RefDetailId = faDecrementDetailEntity.RefDetailId,
                AccountNumber = faDecrementDetailEntity.AccountNumber,
                CorrespondingAccountNumber = faDecrementDetailEntity.CorrespondingAccountNumber,
                AmountOc = faDecrementDetailEntity.AmountOC,
                Description = faDecrementDetailEntity.Description,
                AmountExchange = faDecrementDetailEntity.AmountExchange,
                BudgetSourceCode = faDecrementDetailEntity.BudgetSourceCode,
                BudgetItemCode = faDecrementDetailEntity.BudgetItemCode,
                MergerFundId = null,
                VoucherTypeId = faDecrementDetailEntity.VoucherTypeId,
                ProjectId = faDecrementDetailEntity.ProjectId,
                CustomerId = faDecrementEntity.CustomerId,
                VendorId = faDecrementEntity.VendorId,
                EmployeeId = faDecrementEntity.EmployeeId,
                AccountingObjectId = faDecrementEntity.AccountingObjectId,
                BankId = faDecrementEntity.BankId,
                Quantity = faDecrementDetailEntity.Quantity
            };
        }

        /// <summary>
        /// Adds the account balance for debit.
        /// </summary>
        /// <param name="faDecrementEntity">The fa armortization entity.</param>
        /// <param name="faDecrementDetailEntity">The fa armortization detail entity.</param>
        /// <returns></returns>
        public AccountBalanceEntity AddAccountBalanceForDebit(FADecrementEntity faDecrementEntity, FADecrementDetailEntity faDecrementDetailEntity)
        {
            return new AccountBalanceEntity
            {
                BalanceDate = faDecrementEntity.PostedDate,
                CurrencyCode = faDecrementEntity.CurrencyCode,
                ExchangeRate = faDecrementEntity.ExchangeRate,
                AccountNumber = faDecrementDetailEntity.AccountNumber,
                MovementDebitAmountOC = faDecrementDetailEntity.AmountOC,
                MovementDebitAmountExchange = faDecrementDetailEntity.AmountExchange,
                BudgetSourceCode = faDecrementDetailEntity.BudgetSourceCode,
                BudgetItemCode = faDecrementDetailEntity.BudgetItemCode,
                ProjectId = faDecrementDetailEntity.ProjectId,
                MovementCreditAmountOC = 0,
                MovementCreditAmountExchange = 0,
                CustomerId = faDecrementEntity.CustomerId,
                VendorId = faDecrementEntity.VendorId,
                EmployeeId = faDecrementEntity.EmployeeId,
                AccountingObjectId = faDecrementEntity.AccountingObjectId
            };
        }

        /// <summary>
        /// Adds the account balance for credit.
        /// </summary>
        /// <param name="faDecrementEntity">The fa armortization entity.</param>
        /// <param name="faDecrementDetailEntity">The fa armortization detail entity.</param>
        /// <returns></returns>
        public AccountBalanceEntity AddAccountBalanceForCredit(FADecrementEntity faDecrementEntity, FADecrementDetailEntity faDecrementDetailEntity)
        {
            //credit account
            return new AccountBalanceEntity
            {
                BalanceDate = faDecrementEntity.PostedDate,
                CurrencyCode = faDecrementEntity.CurrencyCode,
                ExchangeRate = faDecrementEntity.ExchangeRate,
                AccountNumber = faDecrementDetailEntity.CorrespondingAccountNumber,
                MovementCreditAmountOC = faDecrementDetailEntity.AmountOC,
                MovementCreditAmountExchange = faDecrementDetailEntity.AmountExchange,
                BudgetSourceCode = faDecrementDetailEntity.BudgetSourceCode,
                BudgetItemCode = faDecrementDetailEntity.BudgetItemCode,
                ProjectId = faDecrementDetailEntity.ProjectId,
                MovementDebitAmountOC = 0,
                MovementDebitAmountExchange = 0,
                CustomerId = faDecrementEntity.CustomerId,
                VendorId = faDecrementEntity.VendorId,
                EmployeeId = faDecrementEntity.EmployeeId,
                AccountingObjectId = faDecrementEntity.AccountingObjectId
            };
        }

        /// <summary>
        /// Updates the account balance.
        /// </summary>
        /// <param name="accountBalanceEntity">The account balance entity.</param>
        /// <param name="movementAmount">The movement amount.</param>
        /// <param name="movementAmountExchange">The movement amount exchange.</param>
        /// <param name="isMovementAmount">if set to <c>true</c> [is movement amount].</param>
        /// <param name="balanceSide">The balance side.</param>
        /// <returns></returns>
        public string UpdateAccountBalance(AccountBalanceEntity accountBalanceEntity, decimal movementAmount, decimal movementAmountExchange, bool isMovementAmount, int balanceSide)
        {
            string message;
            // cập nhật bên TK nợ
            if (balanceSide == 1)
            {
                accountBalanceEntity.ExchangeRate = accountBalanceEntity.ExchangeRate;
                if (isMovementAmount)
                {
                    accountBalanceEntity.MovementDebitAmountExchange = accountBalanceEntity.MovementDebitAmountExchange + movementAmountExchange;
                    accountBalanceEntity.MovementDebitAmountOC = accountBalanceEntity.MovementDebitAmountOC + movementAmount;
                }
                else
                {
                    accountBalanceEntity.MovementDebitAmountExchange = accountBalanceEntity.MovementDebitAmountExchange - movementAmountExchange;
                    accountBalanceEntity.MovementDebitAmountOC = accountBalanceEntity.MovementDebitAmountOC - movementAmount;
                }
                message = AccountBalanceDao.UpdateAccountBalance(accountBalanceEntity);
                if (message != null) return message;
            }
            else
            {
                accountBalanceEntity.ExchangeRate = accountBalanceEntity.ExchangeRate;
                if (isMovementAmount)
                {
                    accountBalanceEntity.MovementCreditAmountExchange = accountBalanceEntity.MovementCreditAmountExchange + movementAmountExchange;
                    accountBalanceEntity.MovementCreditAmountOC = accountBalanceEntity.MovementCreditAmountOC + movementAmount;
                }
                else
                {
                    accountBalanceEntity.MovementCreditAmountExchange = accountBalanceEntity.MovementCreditAmountExchange - movementAmountExchange;
                    accountBalanceEntity.MovementCreditAmountOC = accountBalanceEntity.MovementCreditAmountOC - movementAmount;
                }
                message = AccountBalanceDao.UpdateAccountBalance(accountBalanceEntity);
                if (message != null) return message;
            }
            return null;
        }

        /// <summary>
        /// Updates the account balance.
        /// </summary>
        /// <param name="faDecrementEntity">The fa armortization entity.</param>
        public string UpdateAccountBalance(FADecrementEntity faDecrementEntity)
        {
            var fixedDecrementDetails = FixedAssetDecrementDetailDao.GetFADecresementDetailByFADecresement(faDecrementEntity.RefId);
            foreach (var fixedDecrementDetail in fixedDecrementDetails)
            {
                string message;
                var accountBalanceForDebit = AddAccountBalanceForDebit(faDecrementEntity, fixedDecrementDetail);
                var accountBalanceForDebitExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceForDebit);
                if (accountBalanceForDebitExit != null)
                {
                    message = UpdateAccountBalance(accountBalanceForDebitExit, accountBalanceForDebit.MovementDebitAmountOC,
                        accountBalanceForDebit.MovementDebitAmountExchange, false, 1);
                    if (message != null) return message;
                }

                var accountBalanceForCredit = AddAccountBalanceForCredit(faDecrementEntity, fixedDecrementDetail);
                var accountBalanceForCreditExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceForCredit);
                if (accountBalanceForCreditExit != null)
                {
                    message = UpdateAccountBalance(accountBalanceForCreditExit, accountBalanceForCredit.MovementCreditAmountOC,
                        accountBalanceForCredit.MovementCreditAmountExchange, false, 2);
                    if (message != null) return message;
                }
            }
            return null;
        }

        /// <summary>
        /// Inserts the account balance.
        /// </summary>
        /// <param name="faDecrementEntity">The fa armortization entity.</param>
        /// <param name="faDecrementDetailEntity">The fa armortization detail entity.</param>
        public void InsertAccountBalance(FADecrementEntity faDecrementEntity, FADecrementDetailEntity faDecrementDetailEntity)
        {
            //insert AccountBalance for debit account
            var accountBalanceForDebit = AddAccountBalanceForDebit(faDecrementEntity, faDecrementDetailEntity);
            var accountBalanceForDebitExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceForDebit);
            if (accountBalanceForDebitExit != null)
                UpdateAccountBalance(accountBalanceForDebitExit, accountBalanceForDebit.MovementDebitAmountOC,
                    accountBalanceForDebit.MovementDebitAmountExchange, true, 1);
            else
                AccountBalanceDao.InsertAccountBalance(accountBalanceForDebit);

            //insert AccountBalance for credit account
            var accountBalanceForCredit = AddAccountBalanceForCredit(faDecrementEntity, faDecrementDetailEntity);
            var accountBalanceForCreditExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceForCredit);
            if (accountBalanceForCreditExit != null)
                UpdateAccountBalance(accountBalanceForCreditExit, accountBalanceForCredit.MovementCreditAmountOC,
                    accountBalanceForCredit.MovementCreditAmountExchange, true, 2);
            else
                AccountBalanceDao.InsertAccountBalance(accountBalanceForCredit);
        }


        #region Make object

        public JournalEntryAccountEntity MakeJournalEntryAccount(FADecrementEntity faDecrement, FADecrementDetailParallelEntity faDecrementDetailParallel)
        {
            var journalEntryAccount = new JournalEntryAccountEntity();
            if (faDecrementDetailParallel != null)
            {
                journalEntryAccount.RefDetailId = faDecrementDetailParallel.RefDetailId;
                journalEntryAccount.RefId = faDecrementDetailParallel.RefId;
                journalEntryAccount.RefTypeId = faDecrementDetailParallel.RefTypeId;
                journalEntryAccount.RefNo = faDecrement.RefNo;
                journalEntryAccount.RefDate = faDecrement.RefDate;
                journalEntryAccount.PostedDate = faDecrement.PostedDate;
                journalEntryAccount.Description = faDecrementDetailParallel.Description;
                journalEntryAccount.JournalMemo = faDecrement.JournalMemo;
                journalEntryAccount.CurrencyCode = faDecrement.CurrencyCode;
                journalEntryAccount.ExchangeRate = faDecrement.ExchangeRate;
                journalEntryAccount.AccountNumber = faDecrementDetailParallel.AccountNumber;
                journalEntryAccount.CorrespondingAccountNumber = faDecrementDetailParallel.CorrespondingAccountNumber;
                journalEntryAccount.Quantity = faDecrementDetailParallel.Quantity;
                //journalEntryAccount.JournalType = 
                journalEntryAccount.AmountOc = faDecrementDetailParallel.AmountOc;
                journalEntryAccount.AmountExchange = faDecrementDetailParallel.AmountExchange;
                journalEntryAccount.BudgetSourceCode = faDecrementDetailParallel.BudgetSourceCode;
                journalEntryAccount.BudgetItemCode = faDecrementDetailParallel.BudgetItemCode;
                journalEntryAccount.CustomerId = faDecrement.CustomerId;
                journalEntryAccount.VendorId = faDecrement.VendorId;
                journalEntryAccount.EmployeeId = faDecrement.EmployeeId;
                journalEntryAccount.AccountingObjectId = faDecrement.AccountingObjectId;
                journalEntryAccount.VoucherTypeId = faDecrementDetailParallel.VoucherTypeId;
                journalEntryAccount.MergerFundId = faDecrementDetailParallel.MergerFundId;
                journalEntryAccount.ProjectId = faDecrementDetailParallel.ProjectId;
                journalEntryAccount.InventoryItemId = faDecrementDetailParallel.InventoryItemId;
                journalEntryAccount.BankId = faDecrement.BankId;
                //journalEntryAccount.BankAccount 
            }
            return journalEntryAccount;
        }

        public FADecrementDetailParallelEntity MakeFADecrementDetailParallel(FADecrementEntity faDecrement, FADecrementDetailEntity faDecrementDetail, AutoBusinessParallelEntity autoBusinessParallel)
        {
            var faDecrementDetailParallel = new FADecrementDetailParallelEntity();
            faDecrementDetailParallel.RefDetailId = faDecrementDetail.RefDetailId;
            faDecrementDetailParallel.RefId = faDecrementDetail.RefId;
            faDecrementDetailParallel.RefTypeId = faDecrement.RefTypeId;
            faDecrementDetailParallel.Description = faDecrementDetail.Description;
            faDecrementDetailParallel.AccountNumber = autoBusinessParallel.DebitAccountParallel;//faDecrementDetail.AccountNumber;
            faDecrementDetailParallel.CorrespondingAccountNumber = autoBusinessParallel.CreditAccountParallel;//faDecrementDetail.CorrespondingAccountNumber;
            faDecrementDetailParallel.Quantity = faDecrementDetail.Quantity;
            if (autoBusinessParallel.IsNegative)
            {
                faDecrementDetailParallel.Price = -1 * faDecrementDetail.UnitPriceOC;
                faDecrementDetailParallel.PriceExchange = -1 * faDecrementDetail.UnitPriceExchange;
                faDecrementDetailParallel.AmountOc = -1 * faDecrementDetail.AmountOC;
                faDecrementDetailParallel.AmountExchange = -1 * faDecrementDetail.AmountExchange;
            }
            else
            {
                faDecrementDetailParallel.Price = faDecrementDetail.UnitPriceOC;
                faDecrementDetailParallel.PriceExchange = faDecrementDetail.UnitPriceExchange;
                faDecrementDetailParallel.AmountOc = faDecrementDetail.AmountOC;
                faDecrementDetailParallel.AmountExchange = faDecrementDetail.AmountExchange;
            }
            faDecrementDetailParallel.BudgetSourceCode = autoBusinessParallel.BudgetSourceIdParallel == 0 ? faDecrementDetail.BudgetSourceCode : (BudgetSourceDao.GetBudgetSource(autoBusinessParallel.BudgetSourceIdParallel)?.BudgetSourceCode ?? null);
            faDecrementDetailParallel.BudgetItemCode = autoBusinessParallel.BudgetItemIdParallel == 0 ? faDecrementDetail.BudgetItemCode : (BudgetItemDao.GetBudgetItem(autoBusinessParallel.BudgetItemIdParallel)?.BudgetItemCode ?? null);
            faDecrementDetailParallel.VoucherTypeId = autoBusinessParallel.VoucherTypeIdParallel == 0 ? faDecrementDetail.VoucherTypeId : autoBusinessParallel.VoucherTypeIdParallel;
            faDecrementDetailParallel.DepartmentId = faDecrementDetail.DepartmentId;
            faDecrementDetailParallel.ProjectId = faDecrementDetail.ProjectId;
            faDecrementDetailParallel.FixedAssetId = faDecrementDetail.FixedAssetId;
            faDecrementDetailParallel.InventoryItemId = null;
            faDecrementDetailParallel.MergerFundId = null;
            faDecrementDetailParallel.AccountingObjectId = faDecrement.AccountingObjectId;
            faDecrementDetailParallel.EmployeeId = faDecrement.EmployeeId;
            faDecrementDetailParallel.CustomerId = faDecrement.CustomerId;
            faDecrementDetailParallel.VendorId = faDecrement.VendorId;

            return faDecrementDetailParallel;
        }

        #endregion
    }
}


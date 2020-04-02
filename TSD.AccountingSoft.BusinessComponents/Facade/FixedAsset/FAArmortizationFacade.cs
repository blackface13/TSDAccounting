/***********************************************************************
 * <copyright file="FAArmortizationFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 10 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using TSD.AccountingSoft.BusinessComponents.Messages.FixedAsset;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Business;
using TSD.AccountingSoft.BusinessEntities.Business.FixedAssetArmortization;
using TSD.AccountingSoft.BusinessEntities.Dictionary;
using TSD.AccountingSoft.DataAccess.IEntitiesDao;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.FixedAsset;


namespace TSD.AccountingSoft.BusinessComponents.Facade.FixedAsset
{
    /// <summary>
    /// class FAArmortizationFacade
    /// </summary>
    public class FAArmortizationFacade
    {
        private static readonly IFixedAssetArmortizationDao FAArmortizationDao = DataAccess.DataAccess.FixedAssetArmortizationDao;
        private static readonly IFixedAssetArmortizationDetailDao FAArmortizationDetailDao = DataAccess.DataAccess.FixedAssetArmortizationDetailDao;
        private static readonly IAutoNumberDao AutoNumberDao = DataAccess.DataAccess.AutoNumberDao;
        private static readonly IAudittingLogDao AudittingLogDao = DataAccess.DataAccess.AudittingLogDao;
        private static readonly IFixedAssetLedgerDao FixedAssetLedgerDao = DataAccess.DataAccess.FixedAssetLedgerDao;
        private static readonly IJournalEntryAccountDao JournalEntryAccountDao = DataAccess.DataAccess.JournalEntryAccountDao;
        private static readonly IAccountBalanceDao AccountBalanceDao = DataAccess.DataAccess.AccountBalanceDao;

        /// <summary>
        /// Gets the fAArmortizations.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>FAArmortizationResponse.</returns>
        public FAArmortizationResponse GetFAArmortizations(FAArmortizationRequest request)
        {
            var response = new FAArmortizationResponse();
            if (request.LoadOptions.Contains("FixedAssetArmortizations"))
            {
                if (request.LoadOptions.Contains("RefType"))
                    response.FAArmortizations = FAArmortizationDao.GetFAArmortizationsByRefTypeId(request.RefType);
                else if (request.LoadOptions.Contains("RefDate"))
                {
                    if (request.LoadOptions.Contains("CurrencyCode"))
                        response.FAArmortizations = FAArmortizationDao.GetFAArmortizationsByRefDate(DateTime.Parse(request.RefDate), request.CurrencyCode);
                    else
                        response.FAArmortizations = FAArmortizationDao.GetFAArmortizationsByRefDate(DateTime.Parse(request.RefDate));
                }
                else
                    response.FAArmortizations = FAArmortizationDao.GetFAArmortizations();

                if (request.LoadOptions.Contains("IncludeDetail"))
                {
                    foreach (var fAArmortization in response.FAArmortizations)
                    {
                        fAArmortization.FAArmortizationDetails = FAArmortizationDetailDao.GetFAArmortizationDetailsByFAArmortization(fAArmortization.RefId);
                    }
                }
            }

            if (request.LoadOptions.Contains("FixedAssetArmortization"))
            {
                var fAArmortization = FAArmortizationDao.GetFAArmortization(request.RefId);
                if (request.LoadOptions.Contains("IncludeDetail"))
                {
                    if (request.LoadOptions.Contains("AutoGenerate"))
                    {
                        fAArmortization = fAArmortization ?? new FAArmortizationEntity();
                        fAArmortization.FAArmortizationDetails = FAArmortizationDetailDao.GetAutoFAArmortizationDetailsByCurrencyCode(request.CurrencyCode, request.YearOfDeprecation);
                    }
                    else
                    {
                        fAArmortization = fAArmortization ?? new FAArmortizationEntity();
                        fAArmortization.FAArmortizationDetails = FAArmortizationDetailDao.GetFAArmortizationDetailsByFAArmortization(fAArmortization.RefId);
                    }
                }
                response.FAArmortization = fAArmortization;
            }

            if (request.LoadOptions.Contains("FAArmortizationCheck"))
            {
                var a = FAArmortizationDetailDao.GetFAArmortizationByFAIncrement(request.RefId);
                response.FADecrementDetails = a;
            }
            return response;
        }

        /// <summary>
        /// Sets the fAArmortizations.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>FAArmortizationResponse.</returns>
        public FAArmortizationResponse SetFAArmortizations(FAArmortizationRequest request)
        {
            var response = new FAArmortizationResponse();

            var fAArmortizationEntity = request.FAArmortization;
            //var auditingLog = new AudittingLogEntity { ComponentName = "KHAU HAO TSCD", EventAction = (int)request.Action };
            if (request.Action != PersistType.Delete)
            {
                if (!fAArmortizationEntity.Validate())
                {
                    foreach (var error in fAArmortizationEntity.ValidationErrors)
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
                        var getFAArmortizationsByRefDate = FAArmortizationDao.GetFAArmortizationsByRefDate(fAArmortizationEntity.RefDate, fAArmortizationEntity.CurrencyCode);

                        if (getFAArmortizationsByRefDate != null && getFAArmortizationsByRefDate.Count > 0)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            response.Message = "Chứng từ tiền " + fAArmortizationEntity.CurrencyCode + " đã tồn tại trong năm !";
                            scope.Dispose();
                            return response;
                        }

                        foreach (var fAArmortizationDetail in fAArmortizationEntity.FAArmortizationDetails)
                        {
                            fAArmortizationEntity.TotalAmountOC = fAArmortizationEntity.TotalAmountOC + fAArmortizationDetail.AmountOC;
                            fAArmortizationEntity.TotalAmountExchange = fAArmortizationEntity.TotalAmountExchange + fAArmortizationDetail.AmountExchange;
                        }

                        fAArmortizationEntity.RefId = FAArmortizationDao.InsertFAArmortization(fAArmortizationEntity);
                        if (fAArmortizationEntity.RefId == 0)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return response;
                        }

                        //insert detail
                        foreach (var fAArmortizationDetail in fAArmortizationEntity.FAArmortizationDetails)
                        {
                            if (!fAArmortizationDetail.Validate())
                            {
                                foreach (string error in fAArmortizationDetail.ValidationErrors)
                                    response.Message += error + Environment.NewLine;
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }
                            fAArmortizationDetail.RefId = fAArmortizationEntity.RefId;
                            fAArmortizationDetail.RefDetailId = FAArmortizationDetailDao.InsertFAArmortizationDetail(fAArmortizationDetail);
                            if (fAArmortizationDetail.RefDetailId == 0)
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                scope.Dispose();
                                return response;
                            }

                            //insert jounaral entry
                            var journalEntryAccount = AddJournalEntryAccount(fAArmortizationEntity, fAArmortizationDetail);
                            if (!journalEntryAccount.Validate())
                            {
                                foreach (var error in journalEntryAccount.ValidationErrors)
                                    response.Message += error + Environment.NewLine;
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }
                            JournalEntryAccountDao.InsertDoubleJournalEntryAccount(journalEntryAccount);

                            //insert AccountBalance
                            InsertAccountBalance(fAArmortizationEntity, fAArmortizationDetail);
                        }

                        //insert fixedasset ledger
                        var fixedAssetLedgers = InitFixedAssetLedgers(fAArmortizationEntity);
                        foreach (var fixedAssetLedgerEntity in fixedAssetLedgers)
                        {
                            fixedAssetLedgerEntity.FixedAssetLedgerId = FixedAssetLedgerDao.InsertFixedAssetLedger(fixedAssetLedgerEntity);
                            if (fixedAssetLedgerEntity.FixedAssetLedgerId != 0) continue;
                            response.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return response;
                        }

                        //insert auto number
                        var autoNumber = AutoNumberDao.GetAutoNumberByRefType(fAArmortizationEntity.RefTypeId);
                        //------------------------------------------------------------------
                        //LinhMC 29/11/2014
                        //Lưu giá trị số tự động tăng theo loại tiền
                        //---------------------------------------------------------------
                        if (fAArmortizationEntity.CurrencyCode == "USD")
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
                        //auditingLog.Reference = "Thêm mới CT khấu hao " + fAArmortizationEntity.RefNo;
                        //auditingLog.Amount = 0;
                        //AudittingLogDao.InsertAudittingLog(auditingLog);

                        scope.Complete();
                    }
                }
                else if (request.Action == PersistType.Update)
                {
                    using (var scope = new TransactionScope())
                    {
                        foreach (var fAArmortizationDetail in fAArmortizationEntity.FAArmortizationDetails)
                        {
                            fAArmortizationEntity.TotalAmountOC = fAArmortizationEntity.TotalAmountOC + fAArmortizationDetail.AmountOC;
                            fAArmortizationEntity.TotalAmountExchange = fAArmortizationEntity.TotalAmountExchange + fAArmortizationDetail.AmountExchange;
                        }
                        response.Message = FAArmortizationDao.UpdateFAArmortization(fAArmortizationEntity);
                        if (response.Message != null)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return response;
                        }
                        //update account balance
                        response.Message = UpdateAccountBalance(fAArmortizationEntity);
                        if (response.Message != null)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return response;
                        }

                        //delete JournalEntryAccount
                        response.Message = JournalEntryAccountDao.DeleteJournalEntryAccount(fAArmortizationEntity.RefId, fAArmortizationEntity.RefTypeId);
                        if (response.Message != null)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return response;
                        }

                        //delete detail
                        response.Message = FAArmortizationDetailDao.DeleteFAArmortizationDetailByFAArmortizationId(fAArmortizationEntity.RefId);
                        if (response.Message != null)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return response;
                        }

                        //insert detail
                        foreach (var fAArmortizationDetail in fAArmortizationEntity.FAArmortizationDetails)
                        {
                            if (!fAArmortizationDetail.Validate())
                            {
                                foreach (var error in fAArmortizationDetail.ValidationErrors)
                                    response.Message += error + Environment.NewLine;
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }
                            fAArmortizationDetail.RefId = fAArmortizationEntity.RefId;
                            fAArmortizationDetail.RefDetailId = FAArmortizationDetailDao.InsertFAArmortizationDetail(fAArmortizationDetail);
                            if (fAArmortizationDetail.RefDetailId == 0)
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                scope.Dispose();
                                return response;
                            }

                            //insert jounaral entry
                            var journalEntryAccount = AddJournalEntryAccount(fAArmortizationEntity, fAArmortizationDetail);
                            if (!journalEntryAccount.Validate())
                            {
                                foreach (var error in journalEntryAccount.ValidationErrors)
                                    response.Message += error + Environment.NewLine;
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }
                            JournalEntryAccountDao.InsertDoubleJournalEntryAccount(journalEntryAccount);

                            //insert AccountBalance
                            InsertAccountBalance(fAArmortizationEntity, fAArmortizationDetail);
                        }

                        //delete ledger
                        response.Message = FixedAssetLedgerDao.DeleteFixedAssetLedgerByRefId(fAArmortizationEntity.RefId, fAArmortizationEntity.RefTypeId);
                        if (response.Message != null)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return response;
                        }

                        //insert ledger
                        var fixedAssetLedgers = InitFixedAssetLedgers(fAArmortizationEntity);
                        foreach (var fixedAssetLedgerEntity in fixedAssetLedgers)
                        {
                            fixedAssetLedgerEntity.FixedAssetLedgerId = FixedAssetLedgerDao.InsertFixedAssetLedger(fixedAssetLedgerEntity);
                            if (fixedAssetLedgerEntity.FixedAssetLedgerId != 0) continue;
                            response.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return response;
                        }

                        //insert log
                        //auditingLog.Reference = "Cập nhật CT khấu hao " + fAArmortizationEntity.RefNo;
                        //auditingLog.Amount = 0;
                        //AudittingLogDao.InsertAudittingLog(auditingLog);

                        scope.Complete();
                    }
                }
                else
                {
                    using (var scope = new TransactionScope())
                    {
                        var fAArmortizationrEntityForDelete = FAArmortizationDao.GetFAArmortization(request.RefId);

                        //update account balance
                        response.Message = UpdateAccountBalance(fAArmortizationrEntityForDelete);
                        if (response.Message != null)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return response;
                        }

                        //delete JournalEntryAccount
                        response.Message = JournalEntryAccountDao.DeleteJournalEntryAccount(fAArmortizationrEntityForDelete.RefId, fAArmortizationrEntityForDelete.RefTypeId);
                        if (response.Message != null)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return response;
                        }

                        //insert master
                        response.Message = FAArmortizationDao.DeleteFAArmortization(fAArmortizationrEntityForDelete);
                        if (response.Message != null)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return response;
                        }

                        //delete fixed asset ledger
                        response.Message = FixedAssetLedgerDao.DeleteFixedAssetLedgerByRefId(fAArmortizationrEntityForDelete.RefId,
                            fAArmortizationrEntityForDelete.RefTypeId);
                        if (response.Message != null)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return response;
                        }

                        //insert log
                        //auditingLog.Reference = "Xóa CT khấu hao " + fAArmortizationrEntityForDelete.RefNo;
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

            response.RefId = fAArmortizationEntity != null ? fAArmortizationEntity.RefId : 0;
            response.Acknowledge = response.Message != null ? AcknowledgeType.Failure : AcknowledgeType.Success;
            return response;
        }

        #region private function

        /// <summary>
        /// Initializes the fixed asset ledgers.
        /// </summary>
        /// <param name="fAArmortizationEntity">The f a armortization entity.</param>
        /// <returns></returns>
        private static IEnumerable<FixedAssetLedgerEntity> InitFixedAssetLedgers(FAArmortizationEntity fAArmortizationEntity)
        {
            var fixedAssetLedgers = new List<FixedAssetLedgerEntity>();
            foreach (var fAArmortizationDetail in fAArmortizationEntity.FAArmortizationDetails)
            {
                var fixedAssetLedger = new FixedAssetLedgerEntity
                {
                    RefId = fAArmortizationEntity.RefId,
                    RefTypeId = fAArmortizationEntity.RefTypeId,
                    RefNo = fAArmortizationEntity.RefNo,
                    RefDate = fAArmortizationEntity.RefDate,
                    PostedDate = fAArmortizationEntity.PostedDate,
                    FixedAssetId = fAArmortizationDetail.FixedAssetId,
                    DepartmentId = fAArmortizationDetail.DepartmentId,
                    CurrencyCode = fAArmortizationDetail.CurrencyCode,
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
                    JournalMemo = fAArmortizationEntity.JournalMemo,
                    Description = fAArmortizationDetail.Description,
                    Quantity = fAArmortizationDetail.Quantity
                };
                if (fixedAssetLedgers.Count == 0 || (from item in fixedAssetLedgers
                                                     where (item.FixedAssetId == fAArmortizationDetail.FixedAssetId)
                                                     select item).FirstOrDefault() == null)
                {
                    fixedAssetLedger = AddFixedAssetLedgerEntity(fAArmortizationDetail, fixedAssetLedger);
                    fixedAssetLedgers.Add(fixedAssetLedger);
                }
                else
                {
                    fixedAssetLedger = (from item in fixedAssetLedgers
                                        where (item.FixedAssetId == fAArmortizationDetail.FixedAssetId)
                                        select item).First();
                    fixedAssetLedgers.Remove(fixedAssetLedger);
                    fixedAssetLedgers.Add(AddFixedAssetLedgerEntity(fAArmortizationDetail, fixedAssetLedger));
                }
            }
            return fixedAssetLedgers;
        }

        /// <summary>
        /// Adds the fixed asset ledger entity.
        /// </summary>
        /// <param name="fAArmortizationDetail">The f a armortization detail.</param>
        /// <param name="fixedAssetLedger">The fixed asset ledger.</param>
        /// <returns></returns>
        private static FixedAssetLedgerEntity AddFixedAssetLedgerEntity(FAArmortizationDetailEntity fAArmortizationDetail, FixedAssetLedgerEntity fixedAssetLedger)
        {
            if (fAArmortizationDetail.AccountNumber.Contains("366"))
            {
                fixedAssetLedger.BudgetSourceAccount = fAArmortizationDetail.AccountNumber;
                fixedAssetLedger.ExchangeRate = (decimal)fAArmortizationDetail.ExchangeRate;
                if (fAArmortizationDetail.CurrencyCode.Equals("USD"))
                {
                    fixedAssetLedger.BudgetSourcelDebitAmount += fAArmortizationDetail.AmountOC;
                    fixedAssetLedger.BudgetSourcelDebitAmountExchange += fAArmortizationDetail.AmountOC;
                }
                else
                {
                    fixedAssetLedger.BudgetSourcelDebitAmount += fAArmortizationDetail.AmountOC;
                    fixedAssetLedger.BudgetSourcelDebitAmountExchange += fAArmortizationDetail.AmountExchange;
                }
            }
            //if (fAArmortizationDetail.CorrespondingAccountNumber.Contains("2141") || fAArmortizationDetail.CorrespondingAccountNumber.Contains("2143"))
            if (fAArmortizationDetail.CorrespondingAccountNumber.Contains("2141") || fAArmortizationDetail.CorrespondingAccountNumber.Contains("2142")) // thông tư mới lấy đầu 2141 và 2142
            {
                fixedAssetLedger.DepreciationAccount = fAArmortizationDetail.CorrespondingAccountNumber;
                if (fAArmortizationDetail.CurrencyCode.Equals("USD"))
                {
                    fixedAssetLedger.DepreciationCreditAmount += fAArmortizationDetail.AmountOC;
                    fixedAssetLedger.DepreciationCreditAmountExchange += fAArmortizationDetail.AmountOC;
                }
                else
                {
                    fixedAssetLedger.DepreciationCreditAmount += fAArmortizationDetail.AmountOC;
                    fixedAssetLedger.DepreciationCreditAmountExchange += fAArmortizationDetail.AmountExchange;
                }
            }
            return fixedAssetLedger;
        }

        /// <summary>
        /// Adds the journal entry account.
        /// </summary>
        /// <param name="faArmortizationEntity">The fa armortization entity.</param>
        /// <param name="faArmortizationDetailEntity">The fa armortization detail entity.</param>
        /// <returns></returns>
        public JournalEntryAccountEntity AddJournalEntryAccount(FAArmortizationEntity faArmortizationEntity, FAArmortizationDetailEntity faArmortizationDetailEntity)
        {
            return new JournalEntryAccountEntity
            {
                RefId = faArmortizationEntity.RefId,
                RefTypeId = faArmortizationEntity.RefTypeId,
                RefNo = faArmortizationEntity.RefNo,
                RefDate = faArmortizationEntity.RefDate,
                PostedDate = faArmortizationEntity.PostedDate,
                JournalMemo = faArmortizationEntity.JournalMemo,
                CurrencyCode = faArmortizationDetailEntity.CurrencyCode,
                ExchangeRate = (decimal)faArmortizationDetailEntity.ExchangeRate,
                BankAccount = null,
                RefDetailId = faArmortizationDetailEntity.RefDetailId,
                AccountNumber = faArmortizationDetailEntity.AccountNumber,
                CorrespondingAccountNumber = faArmortizationDetailEntity.CorrespondingAccountNumber,
                AmountOc = faArmortizationDetailEntity.AmountOC,
                Description = faArmortizationDetailEntity.Description,
                AmountExchange = faArmortizationDetailEntity.AmountExchange,
                BudgetSourceCode = faArmortizationDetailEntity.BudgetSourceCode,
                BudgetItemCode = faArmortizationDetailEntity.BudgetItemCode,
                AccountingObjectId = null,
                MergerFundId = null,
                VoucherTypeId = faArmortizationDetailEntity.VoucherTypeId,
                ProjectId = faArmortizationDetailEntity.ProjectId
            };
        }

        /// <summary>
        /// Adds the account balance for debit.
        /// </summary>
        /// <param name="faArmortizationEntity">The fa armortization entity.</param>
        /// <param name="faArmortizationDetailEntity">The fa armortization detail entity.</param>
        /// <returns></returns>
        public AccountBalanceEntity AddAccountBalanceForDebit(FAArmortizationEntity faArmortizationEntity, FAArmortizationDetailEntity faArmortizationDetailEntity)
        {
            return new AccountBalanceEntity
            {
                BalanceDate = faArmortizationEntity.PostedDate,
                CurrencyCode = faArmortizationDetailEntity.CurrencyCode,
                ExchangeRate = (decimal)faArmortizationDetailEntity.ExchangeRate,
                AccountNumber = faArmortizationDetailEntity.AccountNumber,
                MovementDebitAmountOC = faArmortizationDetailEntity.AmountOC,
                MovementDebitAmountExchange = faArmortizationDetailEntity.AmountExchange,
                BudgetSourceCode = faArmortizationDetailEntity.BudgetSourceCode,
                BudgetItemCode = faArmortizationDetailEntity.BudgetItemCode,
                ProjectId = faArmortizationDetailEntity.ProjectId,
                MovementCreditAmountOC = 0,
                MovementCreditAmountExchange = 0
            };
        }

        /// <summary>
        /// Adds the account balance for credit.
        /// </summary>
        /// <param name="faArmortizationEntity">The fa armortization entity.</param>
        /// <param name="faArmortizationDetailEntity">The fa armortization detail entity.</param>
        /// <returns></returns>
        public AccountBalanceEntity AddAccountBalanceForCredit(FAArmortizationEntity faArmortizationEntity, FAArmortizationDetailEntity faArmortizationDetailEntity)
        {
            //credit account
            return new AccountBalanceEntity
            {
                BalanceDate = faArmortizationEntity.PostedDate,
                CurrencyCode = faArmortizationDetailEntity.CurrencyCode,
                ExchangeRate = (decimal)faArmortizationDetailEntity.ExchangeRate,
                AccountNumber = faArmortizationDetailEntity.CorrespondingAccountNumber,
                MovementCreditAmountOC = faArmortizationDetailEntity.AmountOC,
                MovementCreditAmountExchange = faArmortizationDetailEntity.AmountExchange,
                BudgetSourceCode = faArmortizationDetailEntity.BudgetSourceCode,
                BudgetItemCode = faArmortizationDetailEntity.BudgetItemCode,
                ProjectId = faArmortizationDetailEntity.ProjectId,
                MovementDebitAmountOC = 0,
                MovementDebitAmountExchange = 0
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
        public string UpdateAccountBalance(AccountBalanceEntity accountBalanceEntity, decimal movementAmount, decimal movementAmountExchange,
            bool isMovementAmount, int balanceSide)
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
                if (message != null)
                    return message;
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
                if (message != null)
                    return message;
            }
            return null;
        }

        /// <summary>
        /// Updates the account balance.
        /// </summary>
        /// <param name="faArmortizationEntity">The fa armortization entity.</param>
        public string UpdateAccountBalance(FAArmortizationEntity faArmortizationEntity)
        {
            var fixedAssetArmortizationDetails = FAArmortizationDetailDao.GetFAArmortizationDetailsByFAArmortization(faArmortizationEntity.RefId);
            foreach (var fixedAssetArmortizationDetail in fixedAssetArmortizationDetails)
            {
                string message;
                var accountBalanceForDebit = AddAccountBalanceForDebit(faArmortizationEntity, fixedAssetArmortizationDetail);
                var accountBalanceForDebitExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceForDebit);
                if (accountBalanceForDebitExit != null)
                {
                    message = UpdateAccountBalance(accountBalanceForDebitExit, accountBalanceForDebit.MovementDebitAmountOC,
                        accountBalanceForDebit.MovementDebitAmountExchange, false, 1);
                    if (message != null) return message;
                }

                var accountBalanceForCredit = AddAccountBalanceForCredit(faArmortizationEntity, fixedAssetArmortizationDetail);
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
        /// <param name="faArmortizationEntity">The fa armortization entity.</param>
        /// <param name="faArmortizationDetailEntity">The fa armortization detail entity.</param>
        public void InsertAccountBalance(FAArmortizationEntity faArmortizationEntity, FAArmortizationDetailEntity faArmortizationDetailEntity)
        {
            //insert AccountBalance for debit account
            var accountBalanceForDebit = AddAccountBalanceForDebit(faArmortizationEntity, faArmortizationDetailEntity);
            var accountBalanceForDebitExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceForDebit);
            if (accountBalanceForDebitExit != null)
                UpdateAccountBalance(accountBalanceForDebitExit, accountBalanceForDebit.MovementDebitAmountOC,
                    accountBalanceForDebit.MovementDebitAmountExchange, true, 1);
            else
                AccountBalanceDao.InsertAccountBalance(accountBalanceForDebit);

            //insert AccountBalance for credit account
            var accountBalanceForCredit = AddAccountBalanceForCredit(faArmortizationEntity, faArmortizationDetailEntity);
            var accountBalanceForCreditExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceForCredit);
            if (accountBalanceForCreditExit != null)
                UpdateAccountBalance(accountBalanceForCreditExit, accountBalanceForCredit.MovementCreditAmountOC,
                    accountBalanceForCredit.MovementCreditAmountExchange, true, 2);
            else
                AccountBalanceDao.InsertAccountBalance(accountBalanceForCredit);
        }

        #endregion
    }
}
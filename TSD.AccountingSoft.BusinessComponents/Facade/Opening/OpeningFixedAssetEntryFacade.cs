using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessComponents.Messages.Opening;
using TSD.AccountingSoft.BusinessEntities.Business;
using TSD.AccountingSoft.BusinessEntities.Business.Opening;
using TSD.AccountingSoft.BusinessEntities.Dictionary;
using TSD.AccountingSoft.DataAccess.IEntitiesDao;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.FixedAsset;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Opening;


namespace TSD.AccountingSoft.BusinessComponents.Facade.Opening
{
    /// <summary>
    /// class OpeningFixedAssetEntryFacade
    /// </summary>
    public class OpeningFixedAssetEntryFacade
    {
        //private static readonly IOpeningAccountEntryDetailDao OpeningAccountEntryDetailDao = DataAccess.DataAccess.OpeningAccountEntryDetailDao;
        private static readonly IOpeningAccountEntryDao OpeningAccountEntryDao = DataAccess.DataAccess.OpeningAccountEntryDao;
        private static readonly IOpeningFixedAssetEntryDao OpeningFixedAssetEntryDao = DataAccess.DataAccess.OpeningFixedAssetEntryDao;
        private static readonly IFixedAssetLedgerDao FixedAssetLedgerDao = DataAccess.DataAccess.FixedAssetLedgerDao;
        private static readonly IJournalEntryAccountDao JournalEntryAccountDao = DataAccess.DataAccess.JournalEntryAccountDao;
        private static readonly IAutoNumberDao AutoNumberDao = DataAccess.DataAccess.AutoNumberDao;
        private static readonly IAudittingLogDao AudittingLogDao = DataAccess.DataAccess.AudittingLogDao;


        /// <summary>
        /// Gets the opening account entries.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public OpeningFixedAssetEntryResponse GetOpeningFixedAssetEntries(OpeningFixedAssetEntryRequest request)
        {
            var response = new OpeningFixedAssetEntryResponse();
            if (request.LoadOptions.Contains("OpeningFixedAssetEntries"))
                response.OpeningFixedAssetEntries = OpeningFixedAssetEntryDao.GetOpeningAccountEntries();
            if (request.LoadOptions.Contains("OpeningFixedAssetEntry"))
            {
                var openingAccountEntry = OpeningFixedAssetEntryDao.GetOpeningFixedAssetEntryEntityByAccountCode(request.AccountNumber);
                response.OpeningFixedAssetEntries = openingAccountEntry;
            }
            return response;
        }

        /// <summary>
        /// Sets the openingFixedAssetEntrys.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>OpeningFixedAssetEntryResponse.</returns>
        public OpeningFixedAssetEntryResponse SetOpeningFixedAssetEntries(OpeningFixedAssetEntryRequest request)
        {
            var response = new OpeningFixedAssetEntryResponse();
            var jourentryAccount = new JournalEntryAccountEntity();
            if (jourentryAccount == null) throw new ArgumentNullException("jourentryAccount");
            var openingFixedAssetEntryEntity = request.OpeningFixedAssetEntry;
            //var auditingLog = new AudittingLogEntity { ComponentName = "DU DAU KY TAI SAN", EventAction = (int)request.Action };

            try
            {
                if (request.Action == PersistType.Insert)
                {
                    //insert OpeningFixedAssetEntries
                    using (var scope = new TransactionScope())
                    {
                        foreach (var openingFixedAssetEntry in request.OpeningFixedAssetEntries)
                        {
                            openingFixedAssetEntry.RefId = OpeningFixedAssetEntryDao.InsertOpeningFixedAssetEntry(openingFixedAssetEntry);
                            var autoNumber = AutoNumberDao.GetAutoNumberByRefType(openingFixedAssetEntry.RefTypeId);
                            //------------------------------------------------------------------
                            //LinhMC 29/11/2014
                            //Lưu giá trị số tự động tăng theo loại tiền
                            //---------------------------------------------------------------
                            if (openingFixedAssetEntry.CurrencyCode == "USD")
                                autoNumber.Value += 1;
                            else autoNumber.ValueLocalCurency += 1;

                            response.Message = AutoNumberDao.UpdateAutoNumber(autoNumber);
                            if (response.Message != null)
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                scope.Dispose();
                                return response;
                            }

                            //insert JourentryAccount
                            var jourentryAccounts = AddJurnalEntryAccounts(openingFixedAssetEntry);
                            foreach (var jourentryAccountEntity in jourentryAccounts)
                            {
                                jourentryAccountEntity.JournalEntryId = JournalEntryAccountDao.InsertJournalEntryAccount(jourentryAccountEntity);
                                if (jourentryAccountEntity.JournalEntryId != 0) continue;
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }

                            //insert FixedAssetLedger
                            var fixedAssetLedgers = InitFixedAssetLedgers(openingFixedAssetEntry);
                            foreach (var fixedAssetLedgerEntity in fixedAssetLedgers)
                            {
                                fixedAssetLedgerEntity.FixedAssetLedgerId = FixedAssetLedgerDao.InsertFixedAssetLedger(fixedAssetLedgerEntity);
                                if (fixedAssetLedgerEntity.FixedAssetLedgerId != 0) continue;
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }

                            var openingAccountEntryForUpdate = OpeningAccountEntryDao.GetOpeningAccountEntryEntityByAccountCode(openingFixedAssetEntry.OrgPriceAccount);
                            var depreciationAccountForUpdate = OpeningAccountEntryDao.GetOpeningAccountEntryEntityByAccountCode(openingFixedAssetEntry.DepreciationAccount);
                            var capitalAccountForUpdate = OpeningAccountEntryDao.GetOpeningAccountEntryEntityByAccountCode(openingFixedAssetEntry.CapitalAccount);
                            if (openingAccountEntryForUpdate == null)
                            {
                                var openingAccountOrgPrices = AddOpeningAccountOrgPrices(openingFixedAssetEntry);

                                foreach (var openingAccountEntryEntity in openingAccountOrgPrices)
                                {
                                    openingAccountEntryEntity.RefId = OpeningAccountEntryDao.InsertOpeningAccountEntry(openingAccountEntryEntity);
                                }

                            }
                            if (depreciationAccountForUpdate == null)
                            {
                                var openingAccountDepreciations = AddOpeningAccountDepreciations(openingFixedAssetEntry);

                                foreach (var openingAccountEntryEntity in openingAccountDepreciations)
                                {
                                    openingAccountEntryEntity.RefId = OpeningAccountEntryDao.InsertOpeningAccountEntry(openingAccountEntryEntity);
                                    //foreach (var openingAccountEntryDetailEntity in openingAccountDepreciationDetails)
                                    //{
                                    //    openingAccountEntryDetailEntity.RefId = openingAccountEntryEntity.RefId;

                                    //    openingAccountEntryDetailEntity.RefDetailId
                                    //        = OpeningAccountEntryDetailDao.InsertOpeningAccountEntryDetail(openingAccountEntryDetailEntity);
                                    //}
                                }
                            }

                            if (capitalAccountForUpdate == null)
                            {
                                var openingAccountCapitals = AddOpeningAccountCapitals(openingFixedAssetEntry);

                                foreach (var openingAccountEntryEntity in openingAccountCapitals)
                                {

                                    openingAccountEntryEntity.RefId = OpeningAccountEntryDao.InsertOpeningAccountEntry(openingAccountEntryEntity);
                                    //foreach (var openingAccountEntryDetailEntity in openingAccountCapitalDetails)
                                    //{
                                    //    openingAccountEntryDetailEntity.RefId = openingAccountEntryEntity.RefId;
                                    //    openingAccountEntryDetailEntity.RefDetailId
                                    //        = OpeningAccountEntryDetailDao.InsertOpeningAccountEntryDetail(openingAccountEntryDetailEntity);
                                    //}
                                }
                            }



                            if (openingAccountEntryForUpdate != null)
                            {
                                openingAccountEntryForUpdate.TotalDebitAmountOC += openingFixedAssetEntry.OrgPriceDebitAmount;
                                openingAccountEntryForUpdate.TotalDebitAmountExchange += openingFixedAssetEntry.OrgPriceDebitAmountUSD;
                                response.Message = OpeningAccountEntryDao.UpdateOpeningAccountEntry(openingAccountEntryForUpdate);
                                if (response.Message != null)
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    scope.Dispose();
                                    return response;
                                }
                            }

                            if (depreciationAccountForUpdate != null)
                            {

                                //openingAccountEntryDetailEntity.RefId = depreciationAccountForUpdate.RefId;
                                //openingAccountEntryDetailEntity.RefDetailId
                                //    = OpeningAccountEntryDetailDao.InsertOpeningAccountEntryDetail(openingAccountEntryDetailEntity);
                                depreciationAccountForUpdate.TotalCreditAmountOC += openingFixedAssetEntry.DepreciationCreditAmount;
                                depreciationAccountForUpdate.TotalCreditAmountExchange += openingFixedAssetEntry.DepreciationCreditAmountUSD;
                                response.Message = OpeningAccountEntryDao.UpdateOpeningAccountEntry(depreciationAccountForUpdate);


                                if (response.Message != null)
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    scope.Dispose();
                                    return response;
                                }
                            }

                            if (capitalAccountForUpdate != null)
                            {
                                capitalAccountForUpdate.TotalCreditAmountOC += openingFixedAssetEntry.CapitalCreditAmount;
                                capitalAccountForUpdate.TotalCreditAmountExchange += openingFixedAssetEntry.CapitalCreditAmountUSD;
                                response.Message = OpeningAccountEntryDao.UpdateOpeningAccountEntry(capitalAccountForUpdate);

                                if (response.Message != null)
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    scope.Dispose();
                                    return response;
                                }
                            }

                            ////insert OpeningAccountEntry
                            //var openingAccountEntryEnties = AddOpeningAccountEntries(openingFixedAssetEntry);
                            //foreach (var openingAccountEntryEntity in openingAccountEntryEnties)
                            //{
                            //    openingAccountEntryEntity.RefId = OpeningAccountEntryDao.InsertOpeningAccountEntry(openingAccountEntryEntity);
                            //    if (openingAccountEntryEntity.RefId != 0) continue;
                            //    response.Acknowledge = AcknowledgeType.Failure;
                            //    return response;
                            //}

                            //insert log
                            //auditingLog.Reference = "Thêm mới số dư đầu kỳ TSCĐ " + openingFixedAssetEntry.RefNo;
                            //AudittingLogDao.InsertAudittingLog(auditingLog);

                        }

                        scope.Complete();
                    }
                }
                else if (request.Action == PersistType.Update)
                {
                    using (var scope = new TransactionScope())
                    {

                        var openingFixedAssetForUpdate = OpeningFixedAssetEntryDao.GetOpeningFixedAssetEntry(request.FixedAssetId);
                        //delete JournalEntryAccount, FixedAssetLedger, OpeningFixedAssetEntry
                        JournalEntryAccountDao.DeleteJournalEntryAccountByFixedAssetId(request.FixedAssetId, 702);
                        FixedAssetLedgerDao.DeleteFixedAssetLedgerByFixedAssetId(request.FixedAssetId, 702);
                        response.Message =
                            OpeningFixedAssetEntryDao.DeleteOpeningFixedAssetEntryByRefFixedAssetId(request.FixedAssetId);

                        foreach (var openingFixedAssetEntry in request.OpeningFixedAssetEntries)
                        {
                            //insert OpeningFixedAssetEntry
                            openingFixedAssetEntry.RefId = OpeningFixedAssetEntryDao.InsertOpeningFixedAssetEntry(openingFixedAssetEntry);
                            var autoNumber = AutoNumberDao.GetAutoNumberByRefType(openingFixedAssetEntry.RefTypeId);
                            //------------------------------------------------------------------
                            //LinhMC 29/11/2014
                            //Lưu giá trị số tự động tăng theo loại tiền
                            //---------------------------------------------------------------
                            if (openingFixedAssetEntry.CurrencyCode == "USD")
                                autoNumber.Value += 1;
                            else autoNumber.ValueLocalCurency += 1;

                            response.Message = AutoNumberDao.UpdateAutoNumber(autoNumber);
                            if (response.Message != null)
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                scope.Dispose();
                                return response;
                            }

                            //insert JourentryAccount
                            var jourentryAccounts = AddJurnalEntryAccounts(openingFixedAssetEntry);
                            foreach (var jourentryAccountEntity in jourentryAccounts)
                            {
                                jourentryAccountEntity.JournalEntryId = JournalEntryAccountDao.InsertJournalEntryAccount(jourentryAccountEntity);
                                if (jourentryAccountEntity.JournalEntryId != 0) continue;
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }

                            //insert FixedAssetLedger
                            var fixedAssetLedgers = InitFixedAssetLedgers(openingFixedAssetEntry);
                            foreach (var fixedAssetLedgerEntity in fixedAssetLedgers)
                            {
                                fixedAssetLedgerEntity.FixedAssetLedgerId = FixedAssetLedgerDao.InsertFixedAssetLedger(fixedAssetLedgerEntity);
                                if (fixedAssetLedgerEntity.FixedAssetLedgerId != 0) continue;
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }

                            //insert OpeningAccountEntry

                            var openingAccountEntryForUpdate = OpeningAccountEntryDao.GetOpeningAccountEntryEntityByAccountCode(openingFixedAssetEntry.OrgPriceAccount);
                            var depreciationAccountForUpdate = OpeningAccountEntryDao.GetOpeningAccountEntryEntityByAccountCode(openingFixedAssetEntry.DepreciationAccount);
                            var capitalAccountForUpdate = OpeningAccountEntryDao.GetOpeningAccountEntryEntityByAccountCode(openingFixedAssetEntry.CapitalAccount);

                            //var openingAccountEntryDetailForUpdate = OpeningAccountEntryDetailDao.GetOpeningAccountEntryDetailsByRefId(openingAccountEntryForUpdate.RefId);
                            if (openingAccountEntryForUpdate != null)
                            {
                                if (openingFixedAssetForUpdate != null)
                                {


                                    //OpeningAccountEntryDetailDao.DeleteOpeningAccountEntryDetailByAccountCode(openingAccountEntryForUpdate.AccountCode);

                                    //var openingAccountEntryDetails = AddOpeningAccountEntryOrgPriceDetails(openingFixedAssetEntry);
                                    //foreach (var openingAccountEntryDetailEntity in openingAccountEntryDetails)
                                    //{
                                    //    openingAccountEntryDetailEntity.RefId = openingAccountEntryForUpdate.RefId;
                                    //    openingAccountEntryDetailEntity.RefDetailId
                                    //        = OpeningAccountEntryDetailDao.InsertOpeningAccountEntryDetail(openingAccountEntryDetailEntity);
                                    //    openingAccountEntryForUpdate.TotalDebitAmountOC += openingAccountEntryDetailEntity.DebitAmountOC;
                                    //    openingAccountEntryForUpdate.TotalDebitAmountExchange += openingAccountEntryDetailEntity.DebitAmountExchange;
                                    //    response.Message = OpeningAccountEntryDao.UpdateOpeningAccountEntry(openingAccountEntryForUpdate);
                                    //}

                                    //if (response.Message != null)
                                    //{
                                    //    response.Acknowledge = AcknowledgeType.Failure;
                                    //    scope.Dispose();
                                    //    return response;
                                    //}

                                    openingAccountEntryForUpdate.TotalDebitAmountOC = openingAccountEntryForUpdate.TotalDebitAmountOC - openingFixedAssetForUpdate.OrgPriceDebitAmount + openingFixedAssetEntry.OrgPriceDebitAmount;
                                    openingAccountEntryForUpdate.TotalDebitAmountExchange =
                                        openingAccountEntryForUpdate.TotalDebitAmountExchange -
                                        openingFixedAssetForUpdate.OrgPriceDebitAmountUSD +
                                        openingFixedAssetEntry.OrgPriceDebitAmountUSD;
                                }
                                else
                                {
                                    openingAccountEntryForUpdate.TotalDebitAmountOC += openingFixedAssetEntry.OrgPriceDebitAmount;
                                    openingAccountEntryForUpdate.TotalDebitAmountExchange += openingFixedAssetEntry.OrgPriceDebitAmountUSD;
                                    response.Message = OpeningAccountEntryDao.UpdateOpeningAccountEntry(openingAccountEntryForUpdate);
                                }
                                response.Message = OpeningAccountEntryDao.UpdateOpeningAccountEntry(openingAccountEntryForUpdate);

                                if (response.Message != null)
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    scope.Dispose();
                                    return response;
                                }

                            }
                            if (depreciationAccountForUpdate != null)
                            {

                                if (openingFixedAssetForUpdate != null)
                                {
                                    depreciationAccountForUpdate.TotalCreditAmountOC = depreciationAccountForUpdate.TotalCreditAmountOC - openingFixedAssetForUpdate.DepreciationCreditAmount + openingFixedAssetEntry.DepreciationCreditAmount;
                                    depreciationAccountForUpdate.TotalCreditAmountExchange =
                                        depreciationAccountForUpdate.TotalCreditAmountExchange -
                                        openingFixedAssetForUpdate.DepreciationCreditAmountUSD +
                                        openingFixedAssetEntry.DepreciationCreditAmountUSD;

                                }
                                else
                                {
                                    depreciationAccountForUpdate.TotalCreditAmountOC += openingFixedAssetEntry.DepreciationCreditAmount;
                                    depreciationAccountForUpdate.TotalCreditAmountExchange += openingFixedAssetEntry.DepreciationCreditAmountUSD;
                                }
                                response.Message = OpeningAccountEntryDao.UpdateOpeningAccountEntry(depreciationAccountForUpdate);
                                if (response.Message != null)
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    scope.Dispose();
                                    return response;
                                }
                            }
                            if (capitalAccountForUpdate != null)
                            {

                                if (openingFixedAssetForUpdate != null)
                                {
                                    //capitalAccountForUpdate.TotalCreditAmountOC = capitalAccountForUpdate.TotalDebitAmountOC - openingFixedAssetForUpdate.OrgPriceDebitAmount + openingFixedAssetEntry.OrgPriceDebitAmount;
                                    //capitalAccountForUpdate.TotalCreditAmountExchange = capitalAccountForUpdate.TotalDebitAmountExchange - openingFixedAssetForUpdate.CapitalCreditAmountUSD + openingFixedAssetEntry.CapitalCreditAmountUSD;
                                    capitalAccountForUpdate.TotalCreditAmountOC = capitalAccountForUpdate.TotalCreditAmountOC - openingFixedAssetForUpdate.CapitalCreditAmount + openingFixedAssetEntry.CapitalCreditAmount;
                                    capitalAccountForUpdate.TotalCreditAmountExchange = capitalAccountForUpdate.TotalCreditAmountExchange - openingFixedAssetForUpdate.CapitalCreditAmountUSD + openingFixedAssetEntry.CapitalCreditAmountUSD;
                                }
                                else
                                {
                                    capitalAccountForUpdate.TotalCreditAmountOC += openingFixedAssetEntry.CapitalCreditAmount;
                                    capitalAccountForUpdate.TotalCreditAmountExchange += openingFixedAssetEntry.CapitalCreditAmountUSD;
                                }
                                response.Message = OpeningAccountEntryDao.UpdateOpeningAccountEntry(capitalAccountForUpdate);
                                if (response.Message != null)
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    scope.Dispose();
                                    return response;
                                }
                            }
                        }
                        scope.Complete();
                    }
                }
                else
                {
                    using (var scope = new TransactionScope())
                    {
                        JournalEntryAccountDao.DeleteJournalEntryAccountByFixedAssetId(request.FixedAssetId, 702);
                        FixedAssetLedgerDao.DeleteFixedAssetLedgerByFixedAssetId(request.FixedAssetId, 702);
                        var openingFixedAssetForUpdate = OpeningFixedAssetEntryDao.GetOpeningFixedAssetEntry(request.FixedAssetId);
                        if (openingFixedAssetForUpdate != null)
                        {
                            var openingAccountEntryForUpdate = OpeningAccountEntryDao.GetOpeningAccountEntryEntityByAccountCode(openingFixedAssetForUpdate.OrgPriceAccount);
                            if (openingAccountEntryForUpdate != null)
                            {
                                openingAccountEntryForUpdate.TotalDebitAmountOC -= openingFixedAssetForUpdate.OrgPriceDebitAmount;
                                openingAccountEntryForUpdate.TotalDebitAmountExchange -= openingFixedAssetForUpdate.OrgPriceDebitAmountUSD;
                                response.Message = OpeningAccountEntryDao.UpdateOpeningAccountEntry(openingAccountEntryForUpdate);
                                if (response.Message != null)
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    scope.Dispose();
                                    return response;
                                }
                            }

                            var depreciationAccountForUpdate = OpeningAccountEntryDao.GetOpeningAccountEntryEntityByAccountCode(openingFixedAssetForUpdate.DepreciationAccount);
                            var capitalAccountForUpdate = OpeningAccountEntryDao.GetOpeningAccountEntryEntityByAccountCode(openingFixedAssetForUpdate.CapitalAccount);


                            if (depreciationAccountForUpdate != null)
                            {
                                depreciationAccountForUpdate.TotalCreditAmountOC -= openingFixedAssetForUpdate.DepreciationCreditAmount;
                                depreciationAccountForUpdate.TotalCreditAmountExchange -= openingFixedAssetForUpdate.DepreciationCreditAmountUSD;
                                response.Message = OpeningAccountEntryDao.UpdateOpeningAccountEntry(depreciationAccountForUpdate);
                                if (response.Message != null)
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    scope.Dispose();
                                    return response;
                                }
                            }

                            if (capitalAccountForUpdate != null)
                            {
                                capitalAccountForUpdate.TotalCreditAmountOC -= openingFixedAssetForUpdate.CapitalCreditAmount;
                                capitalAccountForUpdate.TotalCreditAmountExchange -= openingFixedAssetForUpdate.CapitalCreditAmountUSD;
                                response.Message = OpeningAccountEntryDao.UpdateOpeningAccountEntry(capitalAccountForUpdate);
                                if (response.Message != null)
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    scope.Dispose();
                                    return response;
                                }
                            }

                            response.Message =
                                OpeningFixedAssetEntryDao.DeleteOpeningFixedAssetEntryByRefFixedAssetId(request.FixedAssetId);

                        }


                        if (response.Message != null)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return response;
                        }
                        //insert log
                        //auditingLog.Reference = "Xóa CT dự toán " + openingFixedAssetEntryrEntityForDelete.;
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

            response.RefId = openingFixedAssetEntryEntity != null ? openingFixedAssetEntryEntity.RefId : 0;
            response.Acknowledge = response.Message != null ? AcknowledgeType.Failure : AcknowledgeType.Success;
            return response;
        }

        /// <summary>
        /// Initializes the fixed asset ledgers.
        /// </summary>
        /// <param name="openingFixedAssetEntryEntity">The fa decrement entity.</param>
        /// <returns></returns>
        private IEnumerable<FixedAssetLedgerEntity> InitFixedAssetLedgers(OpeningFixedAssetEntryEntity openingFixedAssetEntryEntity)
        {

            var fixedAssetLedgers = new List<FixedAssetLedgerEntity>();

            var fixedAssetLedger = new FixedAssetLedgerEntity
            {
                RefId = openingFixedAssetEntryEntity.RefId,
                RefTypeId = openingFixedAssetEntryEntity.RefTypeId,
                RefNo = openingFixedAssetEntryEntity.RefNo,
                RefDate = openingFixedAssetEntryEntity.IncrementDate,
                PostedDate = openingFixedAssetEntryEntity.PostedDate,
                FixedAssetId = openingFixedAssetEntryEntity.FixedAssetId,
                DepartmentId = openingFixedAssetEntryEntity.DepartmentId,
                CurrencyCode = openingFixedAssetEntryEntity.CurrencyCode,
                LifeTime = openingFixedAssetEntryEntity.LifeTime,
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
                JournalMemo = openingFixedAssetEntryEntity.Description,
                Description = openingFixedAssetEntryEntity.Description,
                ExchangeRate = openingFixedAssetEntryEntity.ExchangeRate,
                Quantity = openingFixedAssetEntryEntity.Quantity,


            };
            if (fixedAssetLedgers.Count == 0 || (from item in fixedAssetLedgers
                                                 where (item.FixedAssetId == openingFixedAssetEntryEntity.FixedAssetId)
                                                 select item).FirstOrDefault() == null)
            {
                fixedAssetLedger = AddFixedAssetLedgerEntity(openingFixedAssetEntryEntity, fixedAssetLedger, openingFixedAssetEntryEntity.CurrencyCode);
                fixedAssetLedgers.Add(fixedAssetLedger);
            }
            else
            {
                fixedAssetLedger = (from item in fixedAssetLedgers
                                    where (item.FixedAssetId == openingFixedAssetEntryEntity.FixedAssetId)
                                    select item).First();
                //fixedAssetLedgers.Remove(fixedAssetLedger);

                fixedAssetLedgers.Add(AddFixedAssetLedgerEntity(openingFixedAssetEntryEntity, fixedAssetLedger, openingFixedAssetEntryEntity.CurrencyCode));

            }

            return fixedAssetLedgers;
        }

        private static FixedAssetLedgerEntity AddFixedAssetLedgerEntity(OpeningFixedAssetEntryEntity openingFixedAssetEntryEntity, FixedAssetLedgerEntity fixedAssetLedger, string currencyCode)
        {
            fixedAssetLedger.OrgPriceAccount = openingFixedAssetEntryEntity.OrgPriceAccount;
            fixedAssetLedger.BudgetSourceAccount = openingFixedAssetEntryEntity.CapitalAccount;
            fixedAssetLedger.DepreciationAccount = openingFixedAssetEntryEntity.DepreciationAccount;
            if (currencyCode == "USD")
            {
                fixedAssetLedger.OrgPriceDebitAmount = openingFixedAssetEntryEntity.OrgPriceDebitAmount;
                fixedAssetLedger.BudgetSourceCreditAmount = openingFixedAssetEntryEntity.CapitalCreditAmount;
                fixedAssetLedger.DepreciationCreditAmount = openingFixedAssetEntryEntity.DepreciationCreditAmount;
                fixedAssetLedger.OrgPriceDebitAmountExchange = openingFixedAssetEntryEntity.OrgPriceDebitAmount;
                fixedAssetLedger.BudgetSourceCreditAmountExchange = openingFixedAssetEntryEntity.CapitalCreditAmount;
                fixedAssetLedger.DepreciationCreditAmountExchange = openingFixedAssetEntryEntity.DepreciationCreditAmount;
            }
            else
            {
                fixedAssetLedger.OrgPriceDebitAmount = openingFixedAssetEntryEntity.OrgPriceDebitAmount;
                fixedAssetLedger.OrgPriceDebitAmountExchange = openingFixedAssetEntryEntity.OrgPriceDebitAmountUSD;
                fixedAssetLedger.BudgetSourceCreditAmount = openingFixedAssetEntryEntity.CapitalCreditAmount;
                fixedAssetLedger.BudgetSourceCreditAmountExchange = openingFixedAssetEntryEntity.CapitalCreditAmountUSD;
                fixedAssetLedger.DepreciationCreditAmount = openingFixedAssetEntryEntity.DepreciationCreditAmount;
                fixedAssetLedger.DepreciationCreditAmountExchange = openingFixedAssetEntryEntity.DepreciationCreditAmountUSD;
            }
            return fixedAssetLedger;
        }

        /// <summary>
        /// Addoes the jurnal entry account.
        /// </summary>
        /// <param name="openingFixedAssetEntryEntity">The fa increment entity.</param>
        /// <returns></returns>
        public IEnumerable<JournalEntryAccountEntity> AddJurnalEntryAccounts(OpeningFixedAssetEntryEntity openingFixedAssetEntryEntity)
        {
            var journalEntryAccountEnties = new List<JournalEntryAccountEntity>();
            var journalEntryAccountEntity1 = new JournalEntryAccountEntity
            {
                RefId = openingFixedAssetEntryEntity.RefId,
                RefTypeId = openingFixedAssetEntryEntity.RefTypeId,
                RefNo = openingFixedAssetEntryEntity.RefNo,
                RefDate = openingFixedAssetEntryEntity.IncrementDate,
                PostedDate = openingFixedAssetEntryEntity.PostedDate,
                JournalMemo = openingFixedAssetEntryEntity.Description,
                CurrencyCode = openingFixedAssetEntryEntity.CurrencyCode,
                ExchangeRate = openingFixedAssetEntryEntity.ExchangeRate,
                BankAccount = "",
                RefDetailId = 0,
                AccountNumber = "",
                CorrespondingAccountNumber = "",
                AmountOc = openingFixedAssetEntryEntity.OrgPriceDebitAmount,
                Description = openingFixedAssetEntryEntity.Description,
                AmountExchange = 0,
                BudgetSourceCode = openingFixedAssetEntryEntity.BudgetSourceCode,
                BudgetItemCode = "",
                MergerFundId = null,
                VoucherTypeId = null,
                ProjectId = null,
                CustomerId = null,
                VendorId = null,
                EmployeeId = null,
                AccountingObjectId = null,
                Quantity = openingFixedAssetEntryEntity.Quantity
            };
            journalEntryAccountEnties.Remove(journalEntryAccountEntity1);

            var journalEntryAccountEntity2 = new JournalEntryAccountEntity
            {
                RefId = openingFixedAssetEntryEntity.RefId,
                RefTypeId = openingFixedAssetEntryEntity.RefTypeId,
                RefNo = openingFixedAssetEntryEntity.RefNo,
                RefDate = openingFixedAssetEntryEntity.IncrementDate,
                PostedDate = openingFixedAssetEntryEntity.PostedDate,
                JournalMemo = openingFixedAssetEntryEntity.Description,
                CurrencyCode = openingFixedAssetEntryEntity.CurrencyCode,
                ExchangeRate = openingFixedAssetEntryEntity.ExchangeRate,
                BankAccount = "",
                RefDetailId = 0,
                AccountNumber = "",
                CorrespondingAccountNumber = "",
                AmountOc = 0,
                Description = openingFixedAssetEntryEntity.Description,
                AmountExchange = 0,
                BudgetSourceCode = openingFixedAssetEntryEntity.BudgetSourceCode,
                BudgetItemCode = "",
                MergerFundId = null,
                VoucherTypeId = null,
                ProjectId = null,
                CustomerId = null,
                VendorId = null,
                EmployeeId = null,
                AccountingObjectId = null,
                Quantity = openingFixedAssetEntryEntity.Quantity
            };
            journalEntryAccountEnties.Remove(journalEntryAccountEntity2);

            var journalEntryAccountEntity3 = new JournalEntryAccountEntity
            {
                RefId = openingFixedAssetEntryEntity.RefId,
                RefTypeId = openingFixedAssetEntryEntity.RefTypeId,
                RefNo = openingFixedAssetEntryEntity.RefNo,
                RefDate = openingFixedAssetEntryEntity.IncrementDate,
                PostedDate = openingFixedAssetEntryEntity.PostedDate,
                JournalMemo = openingFixedAssetEntryEntity.Description,
                CurrencyCode = openingFixedAssetEntryEntity.CurrencyCode,
                ExchangeRate = openingFixedAssetEntryEntity.ExchangeRate,
                BankAccount = "",
                RefDetailId = 0,
                AccountNumber = "",
                CorrespondingAccountNumber = "",
                AmountOc = 0,
                Description = openingFixedAssetEntryEntity.Description,
                AmountExchange = 0,
                BudgetSourceCode = openingFixedAssetEntryEntity.BudgetSourceCode,
                BudgetItemCode = "",
                MergerFundId = null,
                VoucherTypeId = null,
                ProjectId = null,
                CustomerId = null,
                VendorId = null,
                EmployeeId = null,
                AccountingObjectId = null,
                Quantity = openingFixedAssetEntryEntity.Quantity
            };

            journalEntryAccountEnties.Remove(journalEntryAccountEntity3);

            journalEntryAccountEnties.Add(AddJournalEntryAccountEntity1(openingFixedAssetEntryEntity, journalEntryAccountEntity1, openingFixedAssetEntryEntity.CurrencyCode));
            journalEntryAccountEnties.Add(AddJournalEntryAccountEntity2(openingFixedAssetEntryEntity, journalEntryAccountEntity2, openingFixedAssetEntryEntity.CurrencyCode));
            journalEntryAccountEnties.Add(AddJournalEntryAccountEntity3(openingFixedAssetEntryEntity, journalEntryAccountEntity3, openingFixedAssetEntryEntity.CurrencyCode));
            return journalEntryAccountEnties;

        }

        private static JournalEntryAccountEntity AddJournalEntryAccountEntity1(OpeningFixedAssetEntryEntity openingFixedAssetEntryEntity, JournalEntryAccountEntity journalEntryAccountEntity, string currencyCode)
        {
            journalEntryAccountEntity.AccountNumber = openingFixedAssetEntryEntity.OrgPriceAccount;
            journalEntryAccountEntity.JournalType = 1;
            //journalEntryAccountEntity.CorrespondingAccountNumber = "";
            if (currencyCode == "USD")
            {
                journalEntryAccountEntity.AmountOc = openingFixedAssetEntryEntity.OrgPriceDebitAmount;
                journalEntryAccountEntity.AmountExchange = openingFixedAssetEntryEntity.OrgPriceDebitAmount;
            }
            else
            {
                journalEntryAccountEntity.AmountOc = openingFixedAssetEntryEntity.OrgPriceDebitAmount;
                journalEntryAccountEntity.AmountExchange = openingFixedAssetEntryEntity.OrgPriceDebitAmountUSD;
            }
            return journalEntryAccountEntity;
        }

        private static JournalEntryAccountEntity AddJournalEntryAccountEntity2(OpeningFixedAssetEntryEntity openingFixedAssetEntryEntity, JournalEntryAccountEntity journalEntryAccountEntity, string currencyCode)
        {
            //journalEntryAccountEntity.AccountNumber = openingFixedAssetEntryEntity.OrgPriceAccount;
            //journalEntryAccountEntity.CorrespondingAccountNumber = openingFixedAssetEntryEntity.DepreciationAccount ;
            journalEntryAccountEntity.AccountNumber = openingFixedAssetEntryEntity.DepreciationAccount;
            journalEntryAccountEntity.JournalType = 2;
            if (currencyCode == "USD")
            {
                journalEntryAccountEntity.AmountOc = openingFixedAssetEntryEntity.DepreciationCreditAmount * (-1);
                journalEntryAccountEntity.AmountExchange = openingFixedAssetEntryEntity.DepreciationCreditAmount * (-1);
            }
            else
            {
                journalEntryAccountEntity.AmountOc = openingFixedAssetEntryEntity.DepreciationCreditAmount * (-1);
                journalEntryAccountEntity.AmountExchange = openingFixedAssetEntryEntity.DepreciationCreditAmountUSD * (-1);
            }
            return journalEntryAccountEntity;
        }

        private static JournalEntryAccountEntity AddJournalEntryAccountEntity3(OpeningFixedAssetEntryEntity openingFixedAssetEntryEntity, JournalEntryAccountEntity journalEntryAccountEntity, string currencyCode)
        {
            //journalEntryAccountEntity.AccountNumber = openingFixedAssetEntryEntity.OrgPriceAccount;
            //journalEntryAccountEntity.CorrespondingAccountNumber = openingFixedAssetEntryEntity.CapitalAccount;
            journalEntryAccountEntity.AccountNumber = openingFixedAssetEntryEntity.CapitalAccount;
            journalEntryAccountEntity.JournalType = 2;
            if (currencyCode == "USD")
            {
                journalEntryAccountEntity.AmountOc = openingFixedAssetEntryEntity.RemainingAmount * (-1);
                journalEntryAccountEntity.AmountExchange = openingFixedAssetEntryEntity.RemainingAmount * (-1);
            }
            else
            {
                journalEntryAccountEntity.AmountOc = openingFixedAssetEntryEntity.RemainingAmount * (-1);
                journalEntryAccountEntity.AmountExchange = openingFixedAssetEntryEntity.RemainingAmountUSD * (-1);
            }
            return journalEntryAccountEntity;
        }

        public IEnumerable<OpeningAccountEntryEntity> AddOpeningAccountOrgPrices(OpeningFixedAssetEntryEntity openingFixedAssetEntryEntity)
        {
            var openingAccountEntryEnties = new List<OpeningAccountEntryEntity>();
            var openingAccountEntryOrgPrice = new OpeningAccountEntryEntity
            {
                RefId = openingFixedAssetEntryEntity.RefId,
                RefTypeId = openingFixedAssetEntryEntity.RefTypeId,
                RefNo = openingFixedAssetEntryEntity.RefNo,
                PostedDate = openingFixedAssetEntryEntity.PostedDate,
                AccountCode = "",
                AccountName = "",
                AccountId = null,
                ParentId = null,
                TotalAccountBeginningDebitAmountOC = 0,
                TotalAccountBeginningCreditAmountOC = 0,
                TotalDebitAmountOC = 0,
                TotalCreditAmountOC = 0,
                TotalAccountBeginningDebitAmountExchange = 0,
                TotalAccountBeginningCreditAmountExchange = 0,
                TotalDebitAmountExchange = 0,
                TotalCreditAmountExchange = 0,

            };
            openingAccountEntryEnties.Remove(openingAccountEntryOrgPrice);
            openingAccountEntryEnties.Add(AddOpeningAccountOrgPrice(openingFixedAssetEntryEntity, openingAccountEntryOrgPrice, openingFixedAssetEntryEntity.CurrencyCode));
            return openingAccountEntryEnties;
        }

        public IEnumerable<OpeningAccountEntryEntity> AddOpeningAccountDepreciations(OpeningFixedAssetEntryEntity openingFixedAssetEntryEntity)
        {
            var openingAccountEntryEnties = new List<OpeningAccountEntryEntity>();
            var openingAccountEntryDepreciation = new OpeningAccountEntryEntity
            {
                RefId = openingFixedAssetEntryEntity.RefId,
                RefTypeId = openingFixedAssetEntryEntity.RefTypeId,
                RefNo = openingFixedAssetEntryEntity.RefNo,
                PostedDate = openingFixedAssetEntryEntity.PostedDate,
                AccountCode = "",
                AccountName = "",
                AccountId = null,
                ParentId = null,
                TotalAccountBeginningDebitAmountOC = 0,
                TotalAccountBeginningCreditAmountOC = 0,
                TotalDebitAmountOC = 0,
                TotalCreditAmountOC = 0,
                TotalAccountBeginningDebitAmountExchange = 0,
                TotalAccountBeginningCreditAmountExchange = 0,
                TotalDebitAmountExchange = 0,
                TotalCreditAmountExchange = 0,

            };
            openingAccountEntryEnties.Remove(openingAccountEntryDepreciation);
            openingAccountEntryEnties.Add(AddOpeningAccountDepreciation(openingFixedAssetEntryEntity, openingAccountEntryDepreciation, openingFixedAssetEntryEntity.CurrencyCode));

            return openingAccountEntryEnties;
        }

        public IEnumerable<OpeningAccountEntryEntity> AddOpeningAccountCapitals(OpeningFixedAssetEntryEntity openingFixedAssetEntryEntity)
        {
            var openingAccountEntryEnties = new List<OpeningAccountEntryEntity>();
            var openingAccountEntryCapital = new OpeningAccountEntryEntity
            {
                RefId = openingFixedAssetEntryEntity.RefId,
                RefTypeId = openingFixedAssetEntryEntity.RefTypeId,
                RefNo = openingFixedAssetEntryEntity.RefNo,
                PostedDate = openingFixedAssetEntryEntity.PostedDate,
                AccountCode = "",
                AccountName = "",
                AccountId = null,
                ParentId = null,
                TotalAccountBeginningDebitAmountOC = 0,
                TotalAccountBeginningCreditAmountOC = 0,
                TotalDebitAmountOC = 0,
                TotalCreditAmountOC = 0,
                TotalAccountBeginningDebitAmountExchange = 0,
                TotalAccountBeginningCreditAmountExchange = 0,
                TotalDebitAmountExchange = 0,
                TotalCreditAmountExchange = 0,

            };
            openingAccountEntryEnties.Remove(openingAccountEntryCapital);
            openingAccountEntryEnties.Add(AddOpeningAccountCapital(openingFixedAssetEntryEntity, openingAccountEntryCapital, openingFixedAssetEntryEntity.CurrencyCode));
            return openingAccountEntryEnties;

        }

        private static OpeningAccountEntryEntity AddOpeningAccountOrgPrice(OpeningFixedAssetEntryEntity openingFixedAssetEntryEntity, OpeningAccountEntryEntity openingAccountEntryEntity, string currencyCode)
        {
            openingAccountEntryEntity.TotalDebitAmountOC += openingFixedAssetEntryEntity.OrgPriceDebitAmount;
            openingAccountEntryEntity.TotalDebitAmountExchange += openingFixedAssetEntryEntity.OrgPriceDebitAmountUSD;
            openingAccountEntryEntity.AccountCode = openingFixedAssetEntryEntity.OrgPriceAccount;
            openingAccountEntryEntity.AccountName = openingFixedAssetEntryEntity.OrgPriceAccount;
            return openingAccountEntryEntity;
        }

        private static OpeningAccountEntryEntity AddOpeningAccountDepreciation(OpeningFixedAssetEntryEntity openingFixedAssetEntryEntity, OpeningAccountEntryEntity openingAccountEntryEntity, string currencyCode)
        {

            openingAccountEntryEntity.TotalCreditAmountOC += openingFixedAssetEntryEntity.DepreciationCreditAmount;
            openingAccountEntryEntity.TotalCreditAmountExchange += openingFixedAssetEntryEntity.DepreciationCreditAmountUSD;
            openingAccountEntryEntity.AccountCode = openingFixedAssetEntryEntity.DepreciationAccount;
            openingAccountEntryEntity.AccountName = openingFixedAssetEntryEntity.DepreciationAccount;
            return openingAccountEntryEntity;
        }

        private static OpeningAccountEntryEntity AddOpeningAccountCapital(OpeningFixedAssetEntryEntity openingFixedAssetEntryEntity, OpeningAccountEntryEntity openingAccountEntryEntity, string currencyCode)
        {
            openingAccountEntryEntity.TotalCreditAmountExchange += openingFixedAssetEntryEntity.CapitalCreditAmount;
            openingAccountEntryEntity.TotalCreditAmountOC += openingFixedAssetEntryEntity.CapitalCreditAmountUSD;
            openingAccountEntryEntity.AccountCode = openingFixedAssetEntryEntity.CapitalAccount;
            openingAccountEntryEntity.AccountName = openingFixedAssetEntryEntity.CapitalAccount;
            return openingAccountEntryEntity;
        }
    }
}

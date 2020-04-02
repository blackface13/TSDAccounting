/***********************************************************************
 * <copyright file="OpeningInventoryEntryFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 24 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessComponents.Messages.Opening;
using TSD.AccountingSoft.BusinessEntities.Business;
using TSD.AccountingSoft.BusinessEntities.Business.Opening;
using TSD.AccountingSoft.BusinessEntities.Dictionary;
using TSD.AccountingSoft.DataAccess.IEntitiesDao;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Opening;
using System;
using System.Linq;
using System.Transactions;


namespace TSD.AccountingSoft.BusinessComponents.Facade.Opening
{
    /// <summary>
    /// OpeningInventoryEntryFacade
    /// </summary>
    public class OpeningInventoryEntryFacade
    {
        private static readonly IOpeningAccountEntryDao OpeningAccountEntryDao = DataAccess.DataAccess.OpeningAccountEntryDao;
        private static readonly IOpeningInventoryEntryDao OpeningInventoryEntryDao = DataAccess.DataAccess.OpeningInventoryEntryDao;
      //  private static readonly IOpeningInventoryEntryDetailDao OpeningInventoryEntryDetailDao = DataAccess.DataAccess.OpeningInventoryEntryDetailDao;
        private static readonly IAudittingLogDao AudittingLogDao = DataAccess.DataAccess.AudittingLogDao;
        private static readonly IJournalEntryAccountDao JournalEntryAccountDao = DataAccess.DataAccess.JournalEntryAccountDao;
        private static readonly IAccountDao AccountDao = DataAccess.DataAccess.AccountDao;

        /// <summary>
        /// Gets the opening account entries.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public OpeningInventoryEntryResponse GetOpeningInventoryEntries(OpeningInventoryEntryRequest request) 
        {
            var response = new OpeningInventoryEntryResponse();
            if (request.LoadOptions.Contains("OpeningInventoryEntries"))
                response.OpeningInventoryEntries = OpeningInventoryEntryDao.GetOpeningInventoryEntries();
            if (request.LoadOptions.Contains("OpeningInventoryEntry"))
            {
                var openingAccountEntry = OpeningInventoryEntryDao.GetOpeningInventoryEntryEntityByAccountCode(request.AccountNumber) ;//?? new OpeningInventoryEntryEntity();
           //     if (request.LoadOptions.Contains("IncludeDetail"))
           //         openingAccountEntry.OpeningInventoryEntryDetails = OpeningInventoryEntryDetailDao.GetOpeningInventoryEntryDetailsByRefId(openingAccountEntry.RefId);
                response.OpeningInventoryEntries = openingAccountEntry;
            }
            return response;
        }

        /// <summary>
        /// Sets the opening account entries.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public OpeningInventoryEntryResponse SetOpeningInventoryEntries(OpeningInventoryEntryRequest request)
        {
            OpeningInventoryEntryEntity inventoryEntryEntity = new OpeningInventoryEntryEntity(); 
            var response = new OpeningInventoryEntryResponse();
            string accountNumber = ""; 
            var openingInventoryEntries = request.OpeningInventoryEntries;  
            //var auditingLog = new AudittingLogEntity { ComponentName = "SO DU DAU KY CCDC", EventAction = (int)request.Action };
            if (request.Action != PersistType.Delete)
            {
                foreach (var openingInventoryEntryEntity in openingInventoryEntries)
                {
                    inventoryEntryEntity = openingInventoryEntryEntity;
                    accountNumber = openingInventoryEntryEntity.AccountNumber;
                    if (!openingInventoryEntryEntity.Validate())
                    {
                        foreach (var error in openingInventoryEntryEntity.ValidationErrors)
                            response.Message += error + Environment.NewLine;
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }
                }
               
            }
            try
            {
                switch (request.Action)
                {
                    case PersistType.Insert:
                        break;
                    case PersistType.Update:
                        using (var scope = new TransactionScope())
                        {
                            if (openingInventoryEntries[0].RefTypeId!=8888)
                            {

                                response.Message =
                                JournalEntryAccountDao.DeleteJournalEntryAccountByPostedDateAndRefType(
                                openingInventoryEntries[0].PostedDate, openingInventoryEntries[0].RefTypeId);
                                if (response.Message != null)
                                {
                                response.Acknowledge = AcknowledgeType.Failure;
                                scope.Dispose();
                                return response;
                                }




                              //  var dtPostedDate = openingInventoryEntries[0].PostedDate;
                                //Delete trong bảng JourentryAccount

                            //insert or update master openingAccountEntry
                            var account = AccountDao.GetAccountByAccountCode(accountNumber);
                            var openingAccountEntryForUpdate = OpeningAccountEntryDao.GetOpeningAccountEntryEntityByAccountCode(account.AccountCode);
                            #region
                            if (openingAccountEntryForUpdate != null)
                            {
                                openingAccountEntryForUpdate.TotalAccountBeginningDebitAmountOC = 0;
                                openingAccountEntryForUpdate.TotalAccountBeginningCreditAmountOC = 0;
                                openingAccountEntryForUpdate.TotalDebitAmountOC = 0;
                                openingAccountEntryForUpdate.TotalCreditAmountOC = 0;
                                openingAccountEntryForUpdate.TotalAccountBeginningDebitAmountExchange = 0;
                                openingAccountEntryForUpdate.TotalAccountBeginningCreditAmountExchange = 0;
                                openingAccountEntryForUpdate.TotalDebitAmountExchange = 0;
                                openingAccountEntryForUpdate.TotalCreditAmountExchange = 0;

                                foreach (var openingInventoryEntryEntity in openingInventoryEntries)//var openingAccountEntryDetailEntity in openingAccountEntry.OpeningAccountEntryDetails)
                                {
                                    openingAccountEntryForUpdate.TotalDebitAmountOC += openingInventoryEntryEntity.AmountOc;
                                    openingAccountEntryForUpdate.TotalDebitAmountExchange += openingInventoryEntryEntity.AmountExchange;
                                }
                                response.Message = OpeningAccountEntryDao.UpdateOpeningAccountEntry(openingAccountEntryForUpdate);
                                if (response.Message != null)
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    scope.Dispose();
                                    return response;
                                }
                                //    openingAccountEntry.RefId = openingAccountEntryForUpdate.RefId;
                            }
                            else
                            {
                                OpeningAccountEntryEntity openingAccountEntry = new OpeningAccountEntryEntity()
                                {
                                    AccountCode = accountNumber,
                                    AccountId = inventoryEntryEntity.AccountId,
                                    AccountName = inventoryEntryEntity.AccountName,
                                    ParentId = inventoryEntryEntity.ParentId,
                                    PostedDate = inventoryEntryEntity.PostedDate,
                                    RefId = 0,
                                    RefNo = inventoryEntryEntity.RefNo,
                                    RefTypeId = 700,

                                };
                                foreach (var openingInventoryEntryEntity in openingInventoryEntries)//var openingAccountEntryDetailEntity in openingAccountEntry.OpeningAccountEntryDetails)
                                {
                                    openingAccountEntry.TotalDebitAmountOC += openingInventoryEntryEntity.AmountOc;
                                    openingAccountEntry.TotalDebitAmountExchange += openingInventoryEntryEntity.AmountExchange;
                                }
                                openingAccountEntry.RefId = OpeningAccountEntryDao.InsertOpeningAccountEntry(openingAccountEntry);
                                if (openingAccountEntry.RefId == 0)
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    scope.Dispose();
                                    return response;
                                }
                            }
                            #endregion


                            //Xoa het 
                            foreach (var openingInventoryEntryEntity in openingInventoryEntries)
                            {
                                  var openingInventoryEntryForUpdate = OpeningInventoryEntryDao.GetOpeningInventoryEntryEntityByAccountCodeForMaster(openingInventoryEntryEntity.AccountNumber);
                                if (openingInventoryEntryForUpdate != null)
                                {
                                    response.Message = OpeningInventoryEntryDao.DeleteOpeningInventoryEntryByAccountCode(openingInventoryEntryForUpdate);
                                    response.Message = JournalEntryAccountDao.DeleteJournalEntryAccount(openingInventoryEntryForUpdate.RefId, openingInventoryEntryForUpdate.RefTypeId);
                     
                                }
                            }

                                foreach (var openingInventoryEntryEntity in openingInventoryEntries)
                                {
                                    //insert or update master
                                    var openingInventoryEntryForUpdate =
                                        OpeningInventoryEntryDao.GetOpeningInventoryEntryEntityByAccountCodeForMaster(
                                            openingInventoryEntryEntity.AccountNumber);
                                    if (openingInventoryEntryForUpdate != null)
                                    {
                                        
                                        openingInventoryEntryEntity.RefId =
                                            OpeningInventoryEntryDao.InsertOpeningInventoryEntry(
                                                openingInventoryEntryEntity);
                                        if (openingInventoryEntryEntity.RefId == 0)
                                        {
                                            response.Acknowledge = AcknowledgeType.Failure;
                                            scope.Dispose();
                                            return response;
                                        }
                                    }
                                    else
                                    {
                                        
                                        openingInventoryEntryEntity.RefId =
                                            OpeningInventoryEntryDao.InsertOpeningInventoryEntry(
                                                openingInventoryEntryEntity);
                                        if (openingInventoryEntryEntity.RefId == 0)
                                        {
                                            response.Acknowledge = AcknowledgeType.Failure;
                                            scope.Dispose();
                                            return response;
                                        }
                                    }
                                    response.RefId = openingInventoryEntryEntity.RefId;

                                    //insert JournalEntryAccount
                                    var journalEntryAccount = AddJournalEntryAccount(openingInventoryEntryEntity);
                                    if (!journalEntryAccount.Validate())
                                    {
                                        foreach (var error in journalEntryAccount.ValidationErrors)
                                            response.Message += error + Environment.NewLine;
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        return response;
                                    }
                                    journalEntryAccount.RefId =
                                        JournalEntryAccountDao.InsertJournalEntryAccount(journalEntryAccount);
                                    if (journalEntryAccount.RefId != 0) continue;
                                    else
                                    {
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        scope.Dispose();
                                        return response;
                                    }

                                    //}
                                    //insert log
                                    //auditingLog.Reference = "Cập nhật CT số dư đầu kỳ cho tài khoản vật tư";
                                    //auditingLog.Amount = 0;
                                    //AudittingLogDao.InsertAudittingLog(auditingLog);
                                }
                            }
                            else
                            {

                                //insert or update master openingAccountEntry
                                var account = AccountDao.GetAccountByAccountCode(accountNumber);
                                var openingAccountEntryForUpdate = OpeningAccountEntryDao.GetOpeningAccountEntryEntityByAccountCode(account.AccountCode);
                                if (openingAccountEntryForUpdate != null)
                                {
                                    openingAccountEntryForUpdate.TotalAccountBeginningDebitAmountOC = 0;
                                    openingAccountEntryForUpdate.TotalAccountBeginningCreditAmountOC = 0;
                                    openingAccountEntryForUpdate.TotalDebitAmountOC = 0;
                                    openingAccountEntryForUpdate.TotalCreditAmountOC = 0;
                                    openingAccountEntryForUpdate.TotalAccountBeginningDebitAmountExchange = 0;
                                    openingAccountEntryForUpdate.TotalAccountBeginningCreditAmountExchange = 0;
                                    openingAccountEntryForUpdate.TotalDebitAmountExchange = 0;
                                    openingAccountEntryForUpdate.TotalCreditAmountExchange = 0;                                   
                                    response.Message = OpeningAccountEntryDao.UpdateOpeningAccountEntry(openingAccountEntryForUpdate);
                                    if (response.Message != null)
                                    {
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        scope.Dispose();
                                        return response;
                                    }
                                    else
                                    {
                                        response.RefId = 1;//Success SaveData
                                    }
                                    //    openingAccountEntry.RefId = openingAccountEntryForUpdate.RefId;
                                }
                                else
                                {
                                    OpeningAccountEntryEntity openingAccountEntry = new OpeningAccountEntryEntity()
                                    {
                                        AccountCode = accountNumber,
                                        AccountId = inventoryEntryEntity.AccountId,
                                        AccountName = inventoryEntryEntity.AccountName,
                                        ParentId = inventoryEntryEntity.ParentId,
                                        PostedDate = inventoryEntryEntity.PostedDate,
                                        RefId = 0,
                                        RefNo = inventoryEntryEntity.RefNo,
                                        RefTypeId = 700,

                                    };                           
                                    openingAccountEntry.RefId = OpeningAccountEntryDao.InsertOpeningAccountEntry(openingAccountEntry);
                                    if (openingAccountEntry.RefId == 0)
                                    {
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        scope.Dispose();
                                        return response;
                                    }
                                }

                                //Xoa het 
                                foreach (var openingInventoryEntryEntity in openingInventoryEntries)
                                {
                                    var openingInventoryEntryForUpdate = OpeningInventoryEntryDao.GetOpeningInventoryEntryEntityByAccountCodeForMaster(openingInventoryEntryEntity.AccountNumber);
                                    if (openingInventoryEntryForUpdate != null)
                                    {
                                        response.Message = OpeningInventoryEntryDao.DeleteOpeningInventoryEntryByAccountCode(openingInventoryEntryForUpdate);
                                        response.Message = JournalEntryAccountDao.DeleteJournalEntryAccountByAcountNumber(openingInventoryEntryEntity.AccountNumber, 701);
                                        if (response.Message != null)
                                        {
                                            response.Acknowledge = AcknowledgeType.Failure;
                                            scope.Dispose();
                                            return response;
                                        }
                                        else
                                        {
                                            response.RefId = 1;//Success SaveData
                                        }
                                    }
                                    else
                                    {
                                        response.RefId = 1;//Success SaveData
                                    }
                                }
                                
                            }
                              scope.Complete();
                        }
                        break;
                    default:
                        using (var scope = new TransactionScope())
                        {

                            //insert log
                            //auditingLog.Reference = "Xóa CT số dư đầu kỳ cho tài khoản vật tư";
                            //auditingLog.Amount = 0;
                            //AudittingLogDao.InsertAudittingLog(auditingLog);

                            scope.Complete();
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }

         //   response.RefId = openingAccountEntry.RefId;
            response.Acknowledge = response.Message != null ? AcknowledgeType.Failure : AcknowledgeType.Success;
            return response;
        }

        #region private function

        /// <summary>
        /// Adds the journal entry account.
        /// </summary>
        /// <param name="openingAccountEntryEntity">The opening account entry entity.</param>
        /// <param name="openingAccountEntryDetailEntity">The opening account entry detail entity.</param>
        /// <returns></returns>
        public JournalEntryAccountEntity AddJournalEntryAccount(OpeningInventoryEntryEntity openingInventoryEntryEntity)
        {
            var account = AccountDao.GetAccountByAccountCode(openingInventoryEntryEntity.AccountNumber);
            decimal amountOC;
            decimal amountExchange;
            //switch (account.BalanceSide)
            //{
            //    case 0:
            //        amountOC = openingInventoryEntryEntity.AmountOc;
            //        amountExchange = openingInventoryEntryEntity.AmountExchange;
            //        break;
            //    case 1:
            //        amountOC = openingInventoryEntryEntity.AmountOc;
            //        amountExchange = openingInventoryEntryEntity.AmountExchange;
            //        break;
            //    default:
            //        amountOC = Math.Abs(openingAccountEntryDetailEntity.DebitAmountOC - openingAccountEntryDetailEntity.CreditAmountOC);
            //        amountExchange = Math.Abs(openingAccountEntryDetailEntity.DebitAmountExchange - openingAccountEntryDetailEntity.CreditAmountExchange);
            //        break;
            //}
            //Đầu 1 -> Dư Nợ
            amountOC = openingInventoryEntryEntity.AmountOc;
            amountExchange = openingInventoryEntryEntity.AmountExchange;
            return new JournalEntryAccountEntity
            {
                RefId = openingInventoryEntryEntity.RefId,
                RefTypeId = openingInventoryEntryEntity.RefTypeId,
                RefNo = "OPN",
                RefDate = openingInventoryEntryEntity.PostedDate,
                PostedDate = openingInventoryEntryEntity.PostedDate,
                JournalMemo = null,
                CurrencyCode = openingInventoryEntryEntity.CurrencyCode,
                ExchangeRate = (decimal)openingInventoryEntryEntity.ExchangeRate,
                BankAccount = null,
                RefDetailId = openingInventoryEntryEntity.RefId, //Lấy RefMaster
                AccountNumber = openingInventoryEntryEntity.AccountNumber,
                CorrespondingAccountNumber = null,
                AmountOc = amountOC,
                Description = null,
                JournalType = 1,
                AmountExchange = amountExchange,
                BudgetSourceCode = null,
                BudgetItemCode = null,
                AccountingObjectId = null,
                EmployeeId = null,
                CustomerId = null,
                VendorId = null,
                MergerFundId = null,
                VoucherTypeId = null,
                ProjectId =null,
            };
        }

        #endregion
    }
}
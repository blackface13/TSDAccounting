/***********************************************************************
 * <copyright file="OpeningAccountEntryFacade.cs" company="BUCA JSC">
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
    /// OpeningAccountEntryFacade
    /// </summary>
    public class OpeningAccountEntryFacade
    {
        private static readonly IOpeningAccountEntryDao OpeningAccountEntryDao = DataAccess.DataAccess.OpeningAccountEntryDao;
        private static readonly IOpeningAccountEntryDetailDao OpeningAccountEntryDetailDao = DataAccess.DataAccess.OpeningAccountEntryDetailDao;
        private static readonly IAudittingLogDao AudittingLogDao = DataAccess.DataAccess.AudittingLogDao;
        private static readonly IJournalEntryAccountDao JournalEntryAccountDao = DataAccess.DataAccess.JournalEntryAccountDao;
        private static readonly IAccountDao AccountDao = DataAccess.DataAccess.AccountDao;
        private static readonly IAccountBalanceDao AccountBalanceDao = DataAccess.DataAccess.AccountBalanceDao;

        /// <summary>
        /// Gets the opening account entries.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public OpeningAccountEntryResponse GetOpeningAccountEntries(OpeningAccountEntryRequest request)
        {
            var response = new OpeningAccountEntryResponse();
            if (request.LoadOptions.Contains("OpeningAccountEntries"))
                response.OpeningAccountEntries = OpeningAccountEntryDao.GetOpeningAccountEntries();
            if (request.LoadOptions.Contains("OpeningAccountEntry"))
            {
                var openingAccountEntry = OpeningAccountEntryDao.GetOpeningAccountEntryEntityByAccountCode(request.AccountCode) ?? new OpeningAccountEntryEntity();
                if (request.LoadOptions.Contains("IncludeDetail"))
                    openingAccountEntry.OpeningAccountEntryDetails = OpeningAccountEntryDetailDao.GetOpeningAccountEntryDetailsByRefId(openingAccountEntry.RefId);
                response.OpeningAccountEntry = openingAccountEntry;
            }
            return response;
        }

        /// <summary>
        /// Sets the opening account entries.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public OpeningAccountEntryResponse SetOpeningAccountEntries(OpeningAccountEntryRequest request)
        {
            var response = new OpeningAccountEntryResponse();

            var openingAccountEntry = request.OpeningAccountEntry;
            //var auditingLog = new AudittingLogEntity { ComponentName = "SO DU DAU KY TSCD", EventAction = (int)request.Action };
            if (request.Action != PersistType.Delete)
            {
                if (!openingAccountEntry.Validate())
                {
                    foreach (var error in openingAccountEntry.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
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
                            //insert or update master
                            var account = AccountDao.GetAccountByAccountCode(openingAccountEntry.AccountCode);
                            var openingAccountEntryForUpdate = OpeningAccountEntryDao.GetOpeningAccountEntryEntityByAccountCode(openingAccountEntry.AccountCode);
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

                                foreach (var openingAccountEntryDetailEntity in openingAccountEntry.OpeningAccountEntryDetails)
                                {
                                    openingAccountEntryForUpdate.TotalAccountBeginningDebitAmountOC += openingAccountEntryDetailEntity.AccountBeginningDebitAmountOC;
                                    openingAccountEntryForUpdate.TotalAccountBeginningCreditAmountOC += openingAccountEntryDetailEntity.AccountBeginningCreditAmountOC;
                                    openingAccountEntryForUpdate.TotalDebitAmountOC += openingAccountEntryDetailEntity.DebitAmountOC;
                                    openingAccountEntryForUpdate.TotalCreditAmountOC += openingAccountEntryDetailEntity.CreditAmountOC;
                                    openingAccountEntryForUpdate.TotalAccountBeginningDebitAmountExchange += openingAccountEntryDetailEntity.AccountBeginningDebitAmountExchange;
                                    openingAccountEntryForUpdate.TotalAccountBeginningCreditAmountExchange += openingAccountEntryDetailEntity.AccountBeginningCreditAmountExchange;
                                    openingAccountEntryForUpdate.TotalDebitAmountExchange += openingAccountEntryDetailEntity.DebitAmountExchange;
                                    openingAccountEntryForUpdate.TotalCreditAmountExchange += openingAccountEntryDetailEntity.CreditAmountExchange;
                                }
                                response.Message = OpeningAccountEntryDao.UpdateOpeningAccountEntry(openingAccountEntryForUpdate);
                                if (response.Message != null)
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    scope.Dispose();
                                    return response;
                                }
                                openingAccountEntry.RefId = openingAccountEntryForUpdate.RefId;
                            }
                            else
                            {
                                foreach (var openingAccountEntryDetailEntity in openingAccountEntry.OpeningAccountEntryDetails)
                                {
                                    openingAccountEntry.TotalAccountBeginningDebitAmountOC += openingAccountEntryDetailEntity.AccountBeginningDebitAmountOC;
                                    openingAccountEntry.TotalAccountBeginningCreditAmountOC += openingAccountEntryDetailEntity.AccountBeginningCreditAmountOC;
                                    openingAccountEntry.TotalDebitAmountOC += openingAccountEntryDetailEntity.DebitAmountOC;
                                    openingAccountEntry.TotalCreditAmountOC += openingAccountEntryDetailEntity.CreditAmountOC;
                                    openingAccountEntry.TotalAccountBeginningDebitAmountExchange += openingAccountEntryDetailEntity.AccountBeginningDebitAmountExchange;
                                    openingAccountEntry.TotalAccountBeginningCreditAmountExchange += openingAccountEntryDetailEntity.AccountBeginningCreditAmountExchange;
                                    openingAccountEntry.TotalDebitAmountExchange += openingAccountEntryDetailEntity.DebitAmountExchange;
                                    openingAccountEntry.TotalCreditAmountExchange += openingAccountEntryDetailEntity.CreditAmountExchange;
                                }
                                openingAccountEntry.RefId = OpeningAccountEntryDao.InsertOpeningAccountEntry(openingAccountEntry);
                                if (openingAccountEntry.RefId == 0)
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    scope.Dispose();
                                    return response;
                                }
                            }

                            //delete JournalEntryAccount
                            response.Message = JournalEntryAccountDao.DeleteJournalEntryAccount(openingAccountEntry.RefId, openingAccountEntry.RefTypeId);
                            if (response.Message != null)
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                scope.Dispose();
                                return response;
                            }

                            //delete & insert detail
                            response.Message = OpeningAccountEntryDetailDao.DeleteOpeningAccountEntryDetailByRefId(openingAccountEntry.RefId);
                            if (response.Message != null)
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                scope.Dispose();
                                return response;
                            }
                            foreach (var openingAccountEntryDetailEntity in openingAccountEntry.OpeningAccountEntryDetails)
                            {
                                openingAccountEntryDetailEntity.RefId = openingAccountEntry.RefId;
                                openingAccountEntryDetailEntity.RefDetailId = OpeningAccountEntryDetailDao.InsertOpeningAccountEntryDetail(openingAccountEntryDetailEntity);
                                if (openingAccountEntryDetailEntity.RefDetailId == 0)
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    scope.Dispose();
                                    return response;
                                }
                                //insert JournalEntryAccount
                                var journalEntryAccount = AddJournalEntryAccount(openingAccountEntry, openingAccountEntryDetailEntity, account.BalanceSide);
                                if (!journalEntryAccount.Validate())
                                {
                                    foreach (var error in journalEntryAccount.ValidationErrors)
                                        response.Message += error + Environment.NewLine;
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }
                                journalEntryAccount.RefId = JournalEntryAccountDao.InsertJournalEntryAccount(journalEntryAccount);
                                if (journalEntryAccount.RefId == 0)
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    scope.Dispose();
                                    return response;
                                }

                                //insert AccountBalance
                                //InsertAccountBalance(openingAccountEntry, openingAccountEntryDetailEntity, account.BalanceSide);
                            }
                            //insert log
                            //auditingLog.Reference = "Cập nhật CT số dư đầu kỳ cho tài khoản";
                            //auditingLog.Amount = 0;
                            //AudittingLogDao.InsertAudittingLog(auditingLog);

                            scope.Complete();
                        }
                        break;
                    default:
                        using (var scope = new TransactionScope())
                        {

                            //insert log
                            //auditingLog.Reference = "Xóa CT số dư đầu kỳ cho tài khoản ";
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

            response.RefId = openingAccountEntry.RefId;
            response.Acknowledge = response.Message != null ? AcknowledgeType.Failure : AcknowledgeType.Success;
            return response;
        }

        #region private function

        /// <summary>
        /// Adds the journal entry account.
        /// </summary>
        /// <param name="openingAccountEntryEntity">The opening account entry entity.</param>
        /// <param name="openingAccountEntryDetailEntity">The opening account entry detail entity.</param>
        /// <param name="balanceSide">The balance side.</param>
        /// <returns></returns>
        public JournalEntryAccountEntity AddJournalEntryAccount(OpeningAccountEntryEntity openingAccountEntryEntity,
            OpeningAccountEntryDetailEntity openingAccountEntryDetailEntity, int balanceSide)
        {
            decimal amountOC;
            decimal amountExchange;
            int journalType;
            switch (balanceSide)
            {
                case 0:
                    amountOC = openingAccountEntryDetailEntity.DebitAmountOC;
                    amountExchange = openingAccountEntryDetailEntity.DebitAmountExchange;
                    journalType = 1;
                    break;
                case 1:
                    amountOC = openingAccountEntryDetailEntity.CreditAmountOC * (-1);
                    amountExchange = openingAccountEntryDetailEntity.CreditAmountExchange  * (-1);
                    journalType = 2;
                    break;
                default:
                    if (openingAccountEntryDetailEntity.DebitAmountOC > openingAccountEntryDetailEntity.CreditAmountOC)
                    {
                        amountOC = Math.Abs(openingAccountEntryDetailEntity.DebitAmountOC - openingAccountEntryDetailEntity.CreditAmountOC);
                        amountExchange = Math.Abs(openingAccountEntryDetailEntity.DebitAmountExchange - openingAccountEntryDetailEntity.CreditAmountExchange);
                        journalType = 1;
                    }
                    else
                    {
                        amountOC = openingAccountEntryDetailEntity.DebitAmountOC - openingAccountEntryDetailEntity.CreditAmountOC;
                        amountExchange = openingAccountEntryDetailEntity.DebitAmountExchange - openingAccountEntryDetailEntity.CreditAmountExchange;
                        journalType = 2;
                    }
                    break;
            }
            return new JournalEntryAccountEntity
            {
                RefId = openingAccountEntryEntity.RefId,
                RefTypeId = openingAccountEntryEntity.RefTypeId,
                RefNo = "OPN",
                RefDate = openingAccountEntryEntity.PostedDate,
                PostedDate = openingAccountEntryEntity.PostedDate,
                JournalMemo = null,
                CurrencyCode = openingAccountEntryDetailEntity.CurrencyCode,
                ExchangeRate = (decimal)openingAccountEntryDetailEntity.ExchangeRate,
                BankAccount = null,
                RefDetailId = openingAccountEntryDetailEntity.RefDetailId,
                AccountNumber = openingAccountEntryEntity.AccountCode,
                CorrespondingAccountNumber = null,
                AmountOc = amountOC,
                BankId = openingAccountEntryDetailEntity.BankId,
                Description = null,
                JournalType = journalType,
                AmountExchange = amountExchange,
                BudgetSourceCode = openingAccountEntryDetailEntity.BudgetSourceCode,
                BudgetItemCode = openingAccountEntryDetailEntity.BudgetItemCode,
                AccountingObjectId = openingAccountEntryDetailEntity.AccountingObjectId,
                EmployeeId = openingAccountEntryDetailEntity.EmployeeId,
                CustomerId = openingAccountEntryDetailEntity.CustomerId,
                VendorId = openingAccountEntryDetailEntity.VendorId,
                MergerFundId = openingAccountEntryDetailEntity.MergerFundId,
                VoucherTypeId = null,
                ProjectId = openingAccountEntryDetailEntity.ProjectId
            };
        }

        /// <summary>
        /// Inserts the account balance.
        /// </summary>
        /// <param name="openingAccountEntryEntity">The opening account entry entity.</param>
        /// <param name="openingAccountEntryDetailEntity">The opening account entry detail entity.</param>
        /// <param name="balanceSide">The balance side.</param>
        public void InsertAccountBalance(OpeningAccountEntryEntity openingAccountEntryEntity, OpeningAccountEntryDetailEntity openingAccountEntryDetailEntity,
            int balanceSide)
        {
            //check balance side

            switch (balanceSide)
            {
                case 0: //ben no
                    var accountBalanceForDebit = AddAccountBalanceForDebit(openingAccountEntryEntity, openingAccountEntryDetailEntity);
                    var accountBalanceForDebitExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceForDebit);
                    if (accountBalanceForDebitExit != null)
                        UpdateAccountBalance(accountBalanceForDebitExit, accountBalanceForDebit.MovementDebitAmountOC,
                            accountBalanceForDebit.MovementDebitAmountExchange, true, 1);
                    else
                        AccountBalanceDao.InsertAccountBalance(accountBalanceForDebit);
                    break;
                case 1: //ben co
                    var accountBalanceForCredit = AddAccountBalanceForCredit(openingAccountEntryEntity, openingAccountEntryDetailEntity);
                    var accountBalanceForCreditExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceForCredit);
                    if (accountBalanceForCreditExit != null)
                        UpdateAccountBalance(accountBalanceForCreditExit, accountBalanceForCredit.MovementCreditAmountOC,
                            accountBalanceForCredit.MovementCreditAmountExchange, true, 2);
                    else
                        AccountBalanceDao.InsertAccountBalance(accountBalanceForCredit);
                    break;
                case 2:
                    if (openingAccountEntryDetailEntity.DebitAmountOC == 0)
                    {
                        accountBalanceForCredit = AddAccountBalanceForCredit(openingAccountEntryEntity, openingAccountEntryDetailEntity);
                        accountBalanceForCreditExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceForCredit);
                        if (accountBalanceForCreditExit != null)
                            UpdateAccountBalance(accountBalanceForCreditExit, accountBalanceForCredit.MovementCreditAmountOC,
                                accountBalanceForCredit.MovementCreditAmountExchange, true, 2);
                        else
                            AccountBalanceDao.InsertAccountBalance(accountBalanceForCredit);
                    }
                    else
                    {
                        accountBalanceForDebit = AddAccountBalanceForDebit(openingAccountEntryEntity, openingAccountEntryDetailEntity);
                        accountBalanceForDebitExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceForDebit);
                        if (accountBalanceForDebitExit != null)
                            UpdateAccountBalance(accountBalanceForDebitExit, accountBalanceForDebit.MovementDebitAmountOC,
                                accountBalanceForDebit.MovementDebitAmountExchange, true, 1);
                        else
                            AccountBalanceDao.InsertAccountBalance(accountBalanceForDebit);
                    }
                    break; //luong tinh
            }
        }

        /// <summary>
        /// Updates the account balance.
        /// </summary>
        /// <param name="openingAccountEntryEntity">The opening account entry entity.</param>
        /// <param name="balanceSide">The balance side.</param>
        /// <returns></returns>
        public string UpdateAccountBalance(OpeningAccountEntryEntity openingAccountEntryEntity, int balanceSide)
        {
            var openingAccountEntryDetails = OpeningAccountEntryDetailDao.GetOpeningAccountEntryDetailsByRefId(openingAccountEntryEntity.RefId);
            foreach (var openingAccountEntryDetail in openingAccountEntryDetails)
            {
                string message;
                switch (balanceSide)
                {
                    case 0:
                        var accountBalanceForDebit = AddAccountBalanceForDebit(openingAccountEntryEntity, openingAccountEntryDetail);
                        var accountBalanceForDebitExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceForDebit);
                        if (accountBalanceForDebitExit != null)
                        {
                            message = UpdateAccountBalance(accountBalanceForDebitExit, accountBalanceForDebit.MovementDebitAmountOC,
                                accountBalanceForDebit.MovementDebitAmountExchange, false, 1);
                            if (message != null) return message;
                        }
                        break;
                    case 1:
                        var accountBalanceForCredit = AddAccountBalanceForCredit(openingAccountEntryEntity, openingAccountEntryDetail);
                        var accountBalanceForCreditExit = AccountBalanceDao.GetExitsAccountBalance(accountBalanceForCredit);
                        if (accountBalanceForCreditExit != null)
                        {
                            message = UpdateAccountBalance(accountBalanceForCreditExit, accountBalanceForCredit.MovementCreditAmountOC,
                                accountBalanceForCredit.MovementCreditAmountExchange, false, 2);
                            if (message != null) return message;
                        }
                        break;
                    case 2:
                        break;
                }
            }
            return null;
        }

        /// <summary>
        /// Adds the account balance for debit.
        /// </summary>
        /// <param name="openingAccountEntryEntity">The opening account entry entity.</param>
        /// <param name="openingAccountEntryDetailEntity">The opening account entry detail entity.</param>
        /// <returns></returns>
        public AccountBalanceEntity AddAccountBalanceForDebit(OpeningAccountEntryEntity openingAccountEntryEntity,
            OpeningAccountEntryDetailEntity openingAccountEntryDetailEntity)
        {
            return new AccountBalanceEntity
            {
                BalanceDate = openingAccountEntryEntity.PostedDate,
                CurrencyCode = openingAccountEntryDetailEntity.CurrencyCode,
                ExchangeRate = (decimal)openingAccountEntryDetailEntity.ExchangeRate,
                AccountNumber = openingAccountEntryEntity.AccountCode,
                MovementDebitAmountOC = openingAccountEntryDetailEntity.DebitAmountOC,
                MovementDebitAmountExchange = openingAccountEntryDetailEntity.DebitAmountExchange,
                BudgetSourceCode = openingAccountEntryDetailEntity.BudgetSourceCode,
                BudgetItemCode = openingAccountEntryDetailEntity.BudgetItemCode,
                CustomerId = openingAccountEntryDetailEntity.CustomerId,
                VendorId = openingAccountEntryDetailEntity.VendorId,
                EmployeeId = openingAccountEntryDetailEntity.EmployeeId,
                AccountingObjectId = openingAccountEntryDetailEntity.AccountingObjectId,
                MergerFundId = openingAccountEntryDetailEntity.MergerFundId,
                BankId = openingAccountEntryDetailEntity.BankId,
                ProjectId = openingAccountEntryDetailEntity.ProjectId,
                //InventoryItemId = openingAccountEntryDetailEntityy.InventoryItemId,
                MovementCreditAmountOC = 0,
                MovementCreditAmountExchange = 0
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
        /// Adds the account balance for credit.
        /// </summary>
        /// <param name="openingAccountEntryEntity">The opening account entry entity.</param>
        /// <param name="openingAccountEntryDetailEntityy">The opening account entry detail entityy.</param>
        /// <returns></returns>
        public AccountBalanceEntity AddAccountBalanceForCredit(OpeningAccountEntryEntity openingAccountEntryEntity,
            OpeningAccountEntryDetailEntity openingAccountEntryDetailEntityy)
        {
            //credit account
            return new AccountBalanceEntity
            {
                BalanceDate = openingAccountEntryEntity.PostedDate,
                CurrencyCode = openingAccountEntryDetailEntityy.CurrencyCode,
                ExchangeRate = (decimal)openingAccountEntryDetailEntityy.ExchangeRate,
                AccountNumber = openingAccountEntryEntity.AccountCode,
                MovementCreditAmountOC = openingAccountEntryDetailEntityy.CreditAmountOC,
                MovementCreditAmountExchange = openingAccountEntryDetailEntityy.CreditAmountExchange,
                BudgetSourceCode = openingAccountEntryDetailEntityy.BudgetSourceCode,
                BudgetItemCode = openingAccountEntryDetailEntityy.BudgetItemCode,
                CustomerId = openingAccountEntryDetailEntityy.CustomerId,
                VendorId = openingAccountEntryDetailEntityy.VendorId,
                EmployeeId = openingAccountEntryDetailEntityy.EmployeeId,
                AccountingObjectId = openingAccountEntryDetailEntityy.AccountingObjectId,
                MergerFundId = openingAccountEntryDetailEntityy.MergerFundId,
                BankId = openingAccountEntryDetailEntityy.BankId,
                ProjectId = openingAccountEntryDetailEntityy.ProjectId,
                //InventoryItemId = openingAccountEntryDetailEntityy.InventoryItemId,
                MovementDebitAmountOC = 0,
                MovementDebitAmountExchange = 0
            };
        }

        #endregion
    }
}
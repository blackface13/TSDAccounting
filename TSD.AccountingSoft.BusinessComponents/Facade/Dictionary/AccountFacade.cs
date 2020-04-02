/***********************************************************************
 * <copyright file="AccountFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   BangNC
 * Email:    BangNC@buca.vn
 * Website:
 * Create Date: Thursday, March 13, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Linq;
using TSD.AccountingSoft.BusinessComponents.Messages.Dictionary;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary;


namespace TSD.AccountingSoft.BusinessComponents.Facade.Dictionary
{
    /// <summary>
    /// Class AccountFacade.
    /// </summary>
    public class AccountFacade
    {
        /// <summary>
        /// The account DAO
        /// </summary>
        private static readonly IAccountDao AccountDao = DataAccess.DataAccess.AccountDao;

        /// <summary>
        /// Gets the accounts.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public AccountResponse GetAccounts(AccountRequest request)
        {
            var response = new AccountResponse();

            if (request.LoadOptions.Contains("Accounts"))
            {
                if (request.LoadOptions.Contains("IsActive"))
                {
                    response.Accounts = request.LoadOptions.Contains("ForComboTree") ? AccountDao.GetAccountsForComboTree(request.AccountId) : AccountDao.GetAccountsActive();
                }
                else if (request.LoadOptions.Contains("IsDetail"))
                    response.Accounts = AccountDao.GetAccountsIsDetail(request.IsDetail);
                else response.Accounts = AccountDao.GetAccounts();
            }
            if (request.LoadOptions.Contains("InventoryItem"))
            {
                response.Accounts = AccountDao.GetAccountsForIsInventoryItem();
            }
            if (request.LoadOptions.Contains("Account"))
                response.Account = AccountDao.GetAccount(request.AccountId);
            if (request.LoadOptions.Contains("AccountCode"))
                response.Account = AccountDao.GetAccountCode(request.AccountCode);
            return response;
        }

        /// <summary>
        /// Sets the accounts.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public AccountResponse SetAccounts(AccountRequest request)
        {
            var response = new AccountResponse();

            var accountEntity = request.Account;
            if (request.Action != PersistType.Delete)
            {
                if (!accountEntity.Validate())
                {
                    foreach (string error in accountEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
            }
            try
            {
                if (request.Action == PersistType.Insert)
                {
                    accountEntity.AccountId = AccountDao.InsertAccount(accountEntity);
                    response.Message = null;
                }
                else if (request.Action == PersistType.Update) response.Message = AccountDao.UpdateAccount(accountEntity);
                else
                {
                    var accountEntityForDelete = AccountDao.GetAccount(request.AccountId);
                    response.Message = AccountDao.DeleteAccount(accountEntityForDelete);
                }
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
            response.AccountId = accountEntity != null ? accountEntity.AccountId : 0;
            response.Acknowledge = response.Message != null ? AcknowledgeType.Failure : AcknowledgeType.Success;
            return response;
        }
    }
}

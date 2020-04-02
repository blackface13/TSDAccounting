/***********************************************************************
 * <copyright file="IAccountDao.cs" company="BUCA JSC">
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

using System.Collections.Generic;
using TSD.AccountingSoft.BusinessEntities.Dictionary;


namespace TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary
{
    public interface IAccountDao
    {
        AccountEntity GetAccountCode(string accountCode);
        /// <summary>
        /// Gets the account.
        /// </summary>
        /// <param name="accountId">The account identifier.</param>
        /// <returns>AccountEntity.</returns>
        AccountEntity GetAccount(int accountId);

        /// <summary>
        /// Gets the account by account code.
        /// </summary>
        /// <param name="accountCode">The account code.</param>
        /// <returns></returns>
        AccountEntity GetAccountByAccountCode(string accountCode);

        /// <summary>
        /// Gets the accounts.
        /// </summary>
        /// <returns>List{AccountEntity}.</returns>
        List<AccountEntity> GetAccounts();

        /// <summary>
        /// Gets the accounts for combo tree.
        /// </summary>
        /// <param name="accountId">The account identifier.</param>
        /// <returns>List{AccountEntity}.</returns>
        List<AccountEntity> GetAccountsForComboTree(int accountId);

        /// <summary>
        /// Gets the accounts for is inventory item.
        /// </summary>
        /// <returns>List{AccountEntity}.</returns>
        List<AccountEntity> GetAccountsForIsInventoryItem();

        /// <summary>
        /// Gets the accounts active.
        /// </summary>
        /// <returns>List{AccountEntity}.</returns>
        List<AccountEntity> GetAccountsActive();

        /// <summary>
        /// Gets the accounts is detail.
        /// </summary>
        /// <param name="isDetail">if set to <c>true</c> [is detail].</param>
        /// <returns></returns>
        List<AccountEntity> GetAccountsIsDetail(bool isDetail);

        /// <summary>
        /// Inserts the account.
        /// </summary>
        /// <param name="account">The account.</param>
        /// <returns>System.Int32.</returns>
        int InsertAccount(AccountEntity account);

        /// <summary>
        /// Updates the account.
        /// </summary>
        /// <param name="account">The account.</param>
        /// <returns>System.String.</returns>
        string UpdateAccount(AccountEntity account);

        /// <summary>
        /// Deletes the account.
        /// </summary>
        /// <param name="account">The account.</param>
        /// <returns>System.String.</returns>
        string DeleteAccount(AccountEntity account);
    }
}
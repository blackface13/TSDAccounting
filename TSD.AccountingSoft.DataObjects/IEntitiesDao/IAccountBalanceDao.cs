/***********************************************************************
 * <copyright file="IAccountBalanceDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 27 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using TSD.AccountingSoft.BusinessEntities.Business;

namespace TSD.AccountingSoft.DataAccess.IEntitiesDao
{
    /// <summary>
    /// IAccountBalanceDao
    /// </summary>
    public interface IAccountBalanceDao
    {
        /// <summary>
        /// Gets the accountBalance.
        /// </summary>
        /// <param name="accountBalanceId">The accountBalance identifier.</param>
        /// <returns></returns>
        AccountBalanceEntity GetAccountBalance(int accountBalanceId);

        /// <summary>
        /// Gets the account balance by account number.
        /// </summary>
        /// <param name="accountNumber">The account number.</param>
        /// <returns></returns>
        AccountBalanceEntity GetAccountBalanceByAccountNumber(string accountNumber);

        /// <summary>
        /// Gets the exits account balance.
        /// </summary>
        /// <param name="accountBalance">The account balance.</param>
        /// <returns></returns>
        AccountBalanceEntity GetExitsAccountBalance(AccountBalanceEntity accountBalance);

        /// <summary>
        /// Inserts the account balance.
        /// </summary>
        /// <param name="accountBalance">The account balance.</param>
        /// <returns></returns>
        int InsertAccountBalance(AccountBalanceEntity accountBalance);

        /// <summary>
        /// Updates the account balance.
        /// </summary>
        /// <param name="accountBalance">The journal entry account.</param>
        /// <returns></returns>
        string UpdateAccountBalance(AccountBalanceEntity accountBalance);

        /// <summary>
        /// Deletes the account balance.
        /// </summary>
        /// <param name="accountBalance">The journal entry account.</param>
        /// <returns></returns>
        string DeleteAccountBalance(AccountBalanceEntity accountBalance);

        /// <summary>
        /// Deletes the account balance.
        /// </summary>
        /// <returns></returns>
        string DeleteAccountBalance();
    }
}

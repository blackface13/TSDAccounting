/***********************************************************************
 * <copyright file="IAccountTranferDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 07 March 2014
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
    /// <summary>
    /// IAccountTranferDao
    /// </summary>
    public interface IAccountTranferDao
    {
        /// <summary>
        /// Gets the account tranfer.
        /// </summary>
        /// <param name="accountTranferId">The account tranfer identifier.</param>
        /// <returns></returns>
        AccountTranferEntity GetAccountTranfer(int accountTranferId);

        /// <summary>
        /// Gets the account tranfers.
        /// </summary>
        /// <returns></returns>
        List<AccountTranferEntity> GetAccountTranfers();

        /// <summary>
        /// Gets the account tranfers by active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        List<AccountTranferEntity> GetAccountTranfersByActive(bool isActive);

        /// <summary>
        /// Gets the account tranfers by account tranfer code.
        /// </summary>
        /// <param name="accountTranferCode">The account tranfer code.</param>
        /// <returns></returns>
        List<AccountTranferEntity> GetAccountTranfersByAccountTranferCode(string accountTranferCode);

        /// <summary>
        /// Inserts the account tranfer.
        /// </summary>
        /// <param name="accountTranfer">The account tranfer.</param>
        /// <returns></returns>
        int InsertAccountTranfer(AccountTranferEntity accountTranfer);

        /// <summary>
        /// Updates the account tranfer.
        /// </summary>
        /// <param name="accountTranfer">The account tranfer.</param>
        /// <returns></returns>
        string UpdateAccountTranfer(AccountTranferEntity accountTranfer);

        /// <summary>
        /// Deletes the account tranfer.
        /// </summary>
        /// <param name="accountTranfer">The account tranfer.</param>
        /// <returns></returns>
        string DeleteAccountTranfer(AccountTranferEntity accountTranfer);
    }
}

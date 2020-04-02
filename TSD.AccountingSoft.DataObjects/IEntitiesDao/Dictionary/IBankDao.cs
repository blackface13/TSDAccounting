/***********************************************************************
 * <copyright file="IBankDao.cs" company="BUCA JSC">
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
    /// IBankDao
    /// </summary>
    public interface IBankDao
    {
        /// <summary>
        /// Gets the bank.
        /// </summary>
        /// <param name="bankId">The bank identifier.</param>
        /// <returns></returns>
        BankEntity GetBank(int bankId);

        /// <summary>
        /// Gets the banks.
        /// </summary>
        /// <returns></returns>
        List<BankEntity> GetBanks();

        /// <summary>
        /// Gets the banks by bank account.
        /// </summary>
        /// <param name="bankAccount">The bank account.</param>
        /// <returns></returns>
        List<BankEntity> GetBanksByBankAccount(string bankAccount);

        /// <summary>
        /// Gets the banks by active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        List<BankEntity> GetBanksByActive(bool isActive);

        /// <summary>
        /// Inserts the bank.
        /// </summary>
        /// <param name="bank">The bank.</param>
        /// <returns></returns>
        int InsertBank(BankEntity bank);

        /// <summary>
        /// Updates the bank.
        /// </summary>
        /// <param name="bank">The bank.</param>
        /// <returns></returns>
        string UpdateBank(BankEntity bank);

        /// <summary>
        /// Deletes the bank.
        /// </summary>
        /// <param name="bank">The bank.</param>
        /// <returns></returns>
        string DeleteBank(BankEntity bank);
    }
}

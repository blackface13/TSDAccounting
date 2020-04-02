/***********************************************************************
 * <copyright file="IJournalEntryAccountDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 20 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/
using System;
using System.Collections.Generic;
using TSD.AccountingSoft.BusinessEntities.Business;


namespace TSD.AccountingSoft.DataAccess.IEntitiesDao
{
    /// <summary>
    /// IJournalEntryAccountDao
    /// </summary>
    public interface IJournalEntryAccountDao
    {
        string DeleteJournalEntryAccountByAcountNumber(string accountNumber, int refTypeId);
        /// <summary>
        /// Inserts the journal entry account.
        /// </summary>
        /// <param name="journalEntryAccount">The journal entry account.</param>
        /// <returns></returns>
        int InsertJournalEntryAccount(JournalEntryAccountEntity journalEntryAccount);

        /// <summary>
        /// Inserts the double journal entry account.
        /// </summary>
        /// <param name="journalEntryAccount">The journal entry account.</param>
        /// <returns></returns>
        int InsertDoubleJournalEntryAccount(JournalEntryAccountEntity journalEntryAccount);

        /// <summary>
        /// Deletes the journal entry account.
        /// </summary>
        /// <param name="journalEntryAccount">The journal entry account.</param>
        /// <returns></returns>
        string DeleteJournalEntryAccount(JournalEntryAccountEntity journalEntryAccount);

        /// <summary>
        /// Deletes the journal entry account.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        string DeleteJournalEntryAccount(long refId, int refTypeId);

        /// <summary>
        /// Deletes the type of the journal entry account by posted date and reference.
        /// </summary>
        /// <param name="posdate">The posdate.</param>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        string DeleteJournalEntryAccountByPostedDateAndRefType(DateTime posdate, int refTypeId);

        /// <summary>
        /// Deletes the journal entry account by fixed asset identifier.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        string DeleteJournalEntryAccountByFixedAssetId(int fixedAssetId, long refTypeId);

        /// <summary>
        /// Gets the journal entry account for capital allocate.
        /// </summary>
        /// <param name="journalEntryAccount">The journal entry account.</param>
        /// <returns></returns>
        List<JournalEntryAccountEntity> GetJournalEntryAccountForCapitalAllocate(JournalEntryAccountEntity journalEntryAccount);

        /// <summary>
        /// Gets the journal entry account by reference no reference date.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <param name="refDate">The reference date.</param>
        /// <returns></returns>
        List<JournalEntryAccountEntity> GetJournalEntryAccountByRefNoRefDate(string refNo, DateTime refDate);

        /// <summary>
        /// Gets the journal entry accounts.
        /// </summary>
        /// <param name="exportType">Type of the export.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns></returns>
        List<JournalEntryAccountEntity> GetJournalEntryAccounts(int exportType, DateTime fromDate, DateTime toDate);
        }
}

/***********************************************************************
 * <copyright file="IOpeningAccountEntryDetailDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 25 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using TSD.AccountingSoft.BusinessEntities.Business.Opening;


namespace TSD.AccountingSoft.DataAccess.IEntitiesDao.Opening
{
    public interface IOpeningAccountEntryDetailDao
    {
        /// <summary>
        /// Gets the opening account entry details by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        IList<OpeningAccountEntryDetailEntity> GetOpeningAccountEntryDetailsByRefId(long refId);

        /// <summary>
        /// Inserts the opening account entry detail.
        /// </summary>
        /// <param name="openingAccountEntryDetail">The opening account entry detail.</param>
        /// <returns></returns>
        int InsertOpeningAccountEntryDetail(OpeningAccountEntryDetailEntity openingAccountEntryDetail);

        /// <summary>
        /// Deletes the opening account entry detail by account code.
        /// </summary>
        /// <param name="accountCode">The account code.</param>
        /// <returns></returns>
        string DeleteOpeningAccountEntryDetailByAccountCode(string accountCode);

        /// <summary>
        /// Deletes the opening account entry detail by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        string DeleteOpeningAccountEntryDetailByRefId(long refId);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TSD.AccountingSoft.BusinessEntities.Business.Opening;

namespace TSD.AccountingSoft.DataAccess.IEntitiesDao.Opening
{
    public interface IOpeningFixedAssetEntryDao
    {
        /// <summary>
        /// Gets the opening account entries.
        /// </summary>
        /// <returns></returns>
        List<OpeningFixedAssetEntryEntity> GetOpeningAccountEntries();

        /// <summary>
        /// Gets the opening account entry entity by account code.
        /// </summary>
        /// <param name="accountCode">The account code.</param>
        /// <param name="refId"> </param>
        /// <returns></returns>
        List<OpeningFixedAssetEntryEntity> GetOpeningFixedAssetEntryEntityByAccountCode(string accountCode);

        OpeningFixedAssetEntryEntity GetOpeningFixedAssetEntry(long refId);
        /// <summary>
        /// Inserts the opening account entry.
        /// </summary>
        /// <param name="openingFixedAssetEntryEntity">The opening account entry entity.</param>
        /// <returns></returns>
        long InsertOpeningFixedAssetEntry(OpeningFixedAssetEntryEntity openingFixedAssetEntryEntity);

        /// <summary>
        /// Updates the opening account entry.
        /// </summary>
        /// <param name="openingFixedAssetEntryEntity">The opening account entry entity.</param>
        /// <returns></returns>
        string UpdateOpeningFixedAssetEntry(OpeningFixedAssetEntryEntity openingFixedAssetEntryEntity);

        /// <summary>
        /// Updates the opening account entry.
        /// </summary>
        /// <param name="openingFixedAssetEntryEntity">The opening account entry entity.</param>
        /// <returns></returns>
        string DeleteOpeningFixedAssetEntry(OpeningFixedAssetEntryEntity openingFixedAssetEntryEntity);

        string DeleteOpeningFixedAssetEntryByRefFixedAssetId(long fixedAssetId);

        
        /// <summary>
        /// Deletes the opening account entry detail by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        string DeleteOpeningFixedAssetEntryByRefId(long refId);
    }
}

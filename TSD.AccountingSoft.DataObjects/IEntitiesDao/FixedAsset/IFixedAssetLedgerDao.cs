/***********************************************************************
 * <copyright file="IFixedAssetLedgerDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 14 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using TSD.AccountingSoft.BusinessEntities.Business;


namespace TSD.AccountingSoft.DataAccess.IEntitiesDao.FixedAsset
{
    /// <summary>
    /// IFixedAssetLedgerDao
    /// </summary>
    public interface IFixedAssetLedgerDao
    {
        /// <summary>
        /// Gets the fixed asset ledger by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        FixedAssetLedgerEntity GetFixedAssetLedgerByRefId(long refId, int refTypeId);

        /// <summary>
        /// Gets the fixed asset ledger by reference identifier.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        FixedAssetLedgerEntity GetFixedAssetLedgerByFixedAssetId(int fixedAssetId, int refTypeId);

        /// <summary>
        /// Gets the fixed asset ledger by fixed asset identifier.
        /// </summary>
        /// <param name="FixedAssetId">The fixed asset identifier.</param>
        /// <returns></returns>
        List<FixedAssetLedgerEntity> GetFixedAssetLedgerByFixedAssetId(int FixedAssetId);
        /// <summary>
        /// Inserts the fixed asset ledger.
        /// </summary>
        /// <param name="fixedAssetLedger">The fixed asset ledger.</param>
        /// <returns></returns>
        int InsertFixedAssetLedger(FixedAssetLedgerEntity fixedAssetLedger);

        /// <summary>
        /// Deletes the fixed asset ledger by reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        string DeleteFixedAssetLedgerByRefId(long refId, int refTypeId);

        string DeleteFixedAssetLedgerByFixedAssetId(int FixedAssetId, int refTypeId);
    }
}

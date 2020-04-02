/***********************************************************************
 * <copyright file="IFixedAssetCurrencyDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 23 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using TSD.AccountingSoft.BusinessEntities.Dictionary;
using System.Collections.Generic;


namespace TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary
{
    /// <summary>
    /// IFixedAssetCurrencyDao
    /// </summary>
    public interface IFixedAssetCurrencyDao
    {
        /// <summary>
        /// Gets the fixed asset currencys by fixed asset identifier.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <returns></returns>
        IList<FixedAssetCurrencyEntity> GetFixedAssetCurrencysByFixedAssetId(int fixedAssetId);

        /// <summary>
        /// Gets the fixed asset currency by fixed asset currency identifier.
        /// </summary>
        /// <param name="fixedAssetCurrencyId">The fixed asset currency identifier.</param>
        /// <returns></returns>
        FixedAssetCurrencyEntity GetFixedAssetCurrencyByFixedAssetCurrencyId(int fixedAssetCurrencyId);

        /// <summary>
        /// Inserts the fixed asset currency.
        /// </summary>
        /// <param name="payItemEntity">The pay item entity.</param>
        /// <returns></returns>
        int InsertFixedAssetCurrency(FixedAssetCurrencyEntity payItemEntity);

        /// <summary>
        /// Deletes the fixed asset currency by fixed asset identifier.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <returns></returns>
        string DeleteFixedAssetCurrencyByFixedAssetId(int fixedAssetId);
    }
}

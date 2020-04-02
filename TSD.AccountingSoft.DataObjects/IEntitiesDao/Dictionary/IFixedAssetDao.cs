/***********************************************************************
 * <copyright file="IFixedAsset.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Thursday, February 27, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using TSD.AccountingSoft.BusinessEntities.Dictionary;


namespace TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary
{
    public interface IFixedAssetDao
    {
        /// <summary>
        /// Gets the fixed asset on fixed asset increment.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <returns></returns>
        FixedAssetEntity GetFixedAssetOnFixedAssetIncrement(int fixedAssetId);

        /// <summary>
        /// Gets the fixed asset by code.
        /// </summary>
        /// <param name="fixedAssetCode">The fixed asset code.</param>
        /// <returns></returns>
        FixedAssetEntity GetFixedAssetByCode(string fixedAssetCode);

        List<FixedAssetEntity> GetFixedAssetsByCode(string fixedAssetCode);



        List<FixedAssetEntity> GetFixedAssetsByFixedAssetCategoryCode(string fixedAssetCategoryCode);

        List<FixedAssetEntity> GetFixedAssetsByFixedAssetTMDT(int yearPosted);



        /// <summary>
        /// Gets the fixed asset decrement.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        FixedAssetEntity GetFixedAssetDecrement(int fixedAssetId, int refTypeId);

        /// <summary>
        /// Gets the fixed asset decrement.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <returns></returns>
        FixedAssetEntity GetFixedAssetOpening(int fixedAssetId);

        /// <summary>
        /// Gets the fixed asset decrement.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="postedDate">The posted date.</param>
        /// <returns></returns>
        FixedAssetEntity GetFixedAssetDecrement(int fixedAssetId, string currencyCode, DateTime postedDate);

        /// <summary>
        /// Gets the fixed asset decrement.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        FixedAssetEntity GetFixedAssetDecrement(int fixedAssetId, string currencyCode, int refTypeId);

        /// <summary>
        /// Gets the fixed asset.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <returns></returns>
        FixedAssetEntity GetFixedAsset(int fixedAssetId);

        /// <summary>
        /// Gets the fixed asset.
        /// </summary>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <returns></returns>
        FixedAssetEntity GetFixedAssetRemainingQuantity(int fixedAssetId);

        /// <summary>
        /// Gets all fixed assets with store produre.
        /// </summary>
        /// <param name="storeProdure">The store produre.</param>
        /// <returns></returns>
        List<FixedAssetEntity> GetAllFixedAssetsWithStoreProdure(string storeProdure);

        /// <summary>
        /// Gets the fixed asset.
        /// </summary>
        /// <returns></returns>
        List<FixedAssetEntity> GetFixedAssets();

        /// <summary>
        /// Gets the fixed asset.
        /// </summary>
        /// <returns></returns>
        List<FixedAssetEntity> GetFixedAssetsByActive(bool isActive);

        /// <summary>
        /// Gets the fixed assets by fixed asset category identifier.
        /// </summary>
        /// <param name="fixedAssetCategoryId">The fixed asset category identifier.</param>
        /// <returns></returns>
        List<FixedAssetEntity> GetFixedAssetsByFixedAssetCategoryId(int fixedAssetCategoryId);

        /// <summary>
        /// Inserts the fixed asset category.
        /// </summary>
        /// <param name="fixedAsset">The fixed asset category.</param>
        /// <returns></returns>
        int InsertFixedAsset(FixedAssetEntity fixedAsset);

        /// <summary>
        /// Updates the fixed asset.
        /// </summary>
        /// <param name="fixedAsset">The fixed asset.</param>
        /// <returns></returns>
        string UpdateFixedAsset(FixedAssetEntity fixedAsset);

        /// <summary>
        /// Deletes the fixed asset.
        /// </summary>
        /// <param name="fixedAsset">The fixed asset.</param>
        /// <returns></returns>
        string DeleteFixedAsset(FixedAssetEntity fixedAsset);
    }
}

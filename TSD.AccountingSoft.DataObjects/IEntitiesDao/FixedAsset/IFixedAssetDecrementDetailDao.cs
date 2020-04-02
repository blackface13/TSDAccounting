/***********************************************************************
 * <copyright file="IFixedAssetDecrementDetailDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Thursday, April 10, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  07/03/2014       Author    Tudt           Description: Coding standard
 * 
 * ************************************************************************/

using System.Collections.Generic;
using TSD.AccountingSoft.BusinessEntities.Business.FixedAssetDecrement;


namespace TSD.AccountingSoft.DataAccess.IEntitiesDao.FixedAsset
{
    /// <summary>
    /// interface IFixedAssetDecrementDetailDao
    /// </summary>
    public interface IFixedAssetDecrementDetailDao
    {
        /// <summary>
        /// Gets the receipt voucher details by master.
        /// </summary>
        /// <param name="refId">The cash identifier.</param>
        /// <returns></returns>
        List<FADecrementDetailEntity> GetFADecresementDetailByFADecresement(long refId);

        /// <summary>
        /// Gets the receipt voucher details by master.
        /// </summary>
        /// <param name="refId">The cash identifier.</param>
        /// <returns></returns>
        List<FADecrementDetailEntity> GetFADecrementByFAIncrement(long refId);

        /// <summary>
        /// Inserts the receipt voucher detail.
        /// </summary>
        /// <param name="faDecreasementDetail">The cash detail.</param>
        /// <returns></returns>
        int InsertFADecreasementDetail(FADecrementDetailEntity faDecreasementDetail);

        /// <summary>
        /// Deletes the receipt voucher detail by master.
        /// </summary>
        /// <param name="refId">The cash identifier.</param>
        /// <returns></returns>
        string DeleteFADecreasementDetailByFADecreasement(long refId);
    }
}

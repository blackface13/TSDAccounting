/***********************************************************************
 * <copyright file="IFixedAssetIncrementDetailDao.cs" company="BUCA JSC">
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
using TSD.AccountingSoft.BusinessEntities.Business.FixedAssetIncrement;


namespace TSD.AccountingSoft.DataAccess.IEntitiesDao.FixedAsset
{
    /// <summary>
    /// interface IFixedAssetIncrementDetailDao
    /// </summary>
    public interface IFixedAssetIncrementDetailDao
    {
        /// <summary>
        /// Gets the receipt voucher details by master.
        /// </summary>
        /// <param name="refId">The cash identifier.</param>
        /// <returns></returns>
        List<FAIncrementDetailEntity> GetFAIncrementDetailByFAIncrement(long refId);

        /// <summary>
        /// Inserts the receipt voucher detail.
        /// </summary>
        /// <param name="faIncrementDetail">The cash detail.</param>
        /// <returns></returns>
        int InsertFAIncrementDetail(FAIncrementDetailEntity faIncrementDetail);

        /// <summary>
        /// Deletes the receipt voucher detail by master.
        /// </summary>
        /// <param name="refId">The cash identifier.</param>
        /// <returns></returns>
        string DeleteFAIncrementDetailByFAIncrement(long refId);
    }
}

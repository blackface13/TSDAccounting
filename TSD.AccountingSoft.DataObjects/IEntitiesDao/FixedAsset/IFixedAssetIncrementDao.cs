/***********************************************************************
 * <copyright file="IFixedAssetIncrementDao.cs" company="BUCA JSC">
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
    /// interface IFixedAssetIncrementDao
    /// </summary>
    public interface IFixedAssetIncrementDao
    {
        /// <summary>
        /// Gets the FAIncrement.
        /// </summary>
        /// <param name="refId">The FAIncrement identifier.</param>
        /// <returns></returns>
        FAIncrementEntity GetFAIncrement(long refId);

        ///// <summary>
        ///// Gets the FAIncrement by reference no.
        ///// </summary>
        ///// <param name="refNo">The reference no.</param>
        ///// <returns></returns>
        //List<FAIncrementEntity> GetFAIncrementByRefNo(string refNo);

        /// <summary>
        /// Gets the FAIncrements.
        /// </summary>
        /// <returns></returns>
        List<FAIncrementEntity> GetFAIncrementes();

        /// <summary>
        /// Gets the FAIncrementes by reference type identifier.
        /// </summary>
        /// <returns></returns>
        List<FAIncrementEntity> GetFAIncrementesByRefTypeId(int refTypeId);
        /// <summary>
        /// Gets the FAIncrementes by reference type identifier.
        /// </summary>
        /// <returns></returns>
        List<FAIncrementEntity> GetFAIncrementsByYearOfRefDate(int refTypeId, short yearOfRefDate);

        /// <summary>
        /// Inserts the FAIncrement.
        /// </summary>
        /// <param name="FAIncrement">The FAIncrement.</param>
        /// <returns></returns>
        int InsertFAIncrement(FAIncrementEntity FAIncrement);

        /// <summary>
        /// Updates the FAIncrement entity.
        /// </summary>
        /// <param name="FAIncrement">The FAIncrement.</param>
        /// <returns></returns>
        string UpdateFAIncrement(FAIncrementEntity FAIncrement);

        /// <summary>
        /// Deletes the FAIncrement entity.
        /// </summary>
        /// <param name="FAIncrement">The FAIncrement.</param>
        /// <returns></returns>
        string DeleteFAIncrement(FAIncrementEntity FAIncrement);
        /// <summary>
        /// Gets the Deposit by reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <returns></returns>
        FAIncrementEntity GetFAIncrementByRefNo(string refNo);

    }
}

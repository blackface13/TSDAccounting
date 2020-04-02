/***********************************************************************
 * <copyright file="IFixedAssetDecrementDao.cs" company="BUCA JSC">
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

using System;
using System.Collections.Generic;
using TSD.AccountingSoft.BusinessEntities.Business.FixedAssetDecrement;


namespace TSD.AccountingSoft.DataAccess.IEntitiesDao.FixedAsset
{
    /// <summary>
    /// interface IFixedAssetDecrementDao
    /// </summary>
    public interface IFixedAssetDecrementDao
    {
        /// <summary>
        /// Gets the FADecrement.
        /// </summary>
        /// <param name="refId">The FADecrement identifier.</param>
        /// <returns></returns>
        FADecrementEntity GetFADecrement(long refId);
        
        /// <summary>
        /// Gets the FADecrement by reference no.
        /// </summary>
        /// <param name="refNo">The reference no.</param>
        /// <returns></returns>
        List<FADecrementEntity> GetFADecrementByRefNo(string refNo);

        /// <summary>
        /// Gets the FADecrements.
        /// </summary>
        /// <returns></returns>
        List<FADecrementEntity> GetFADecrementes();

        /// <summary>
        /// Gets the FADecrementes by reference type identifier.
        /// </summary>
        /// <returns></returns>
        List<FADecrementEntity> GetFADecrementsByYearOfRefDate(short yearOfRefDate);

        /// <summary>
        /// Gets the FADecrementes by reference type identifier.
        /// </summary>
        /// <returns></returns>
        List<FADecrementEntity> GetFADecrementesByRefTypeId(int refTypeId);

        /// <summary>
        /// Gets the fa decrementes by reference reference no and reference date.
        /// </summary>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="refNo">The reference no.</param>
        /// <param name="refDate">The reference date.</param>
        /// <returns></returns>
        List<FADecrementEntity> GetFADecrementesByRefRefNoAndRefDate(string currencyCode, string refNo, DateTime refDate);

        /// <summary>
        /// Inserts the FADecrement.
        /// </summary>
        /// <param name="faDecrement">The FADecrement.</param>
        /// <returns></returns>
        int InsertFADecrement(FADecrementEntity faDecrement);

        /// <summary>
        /// Updates the FADecrement entity.
        /// </summary>
        /// <param name="faDecrement">The FADecrement.</param>
        /// <returns></returns>
        string UpdateFADecrement(FADecrementEntity faDecrement);

        /// <summary>
        /// Deletes the FADecrement entity.
        /// </summary>
        /// <param name="faDecrement">The FADecrement.</param>
        /// <returns></returns>
        string DeleteFADecrement(FADecrementEntity faDecrement);
    }
}

/***********************************************************************
 * <copyright file="IFixedAssetArmortizationDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 10 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using TSD.AccountingSoft.BusinessEntities.Business.FixedAssetArmortization;


namespace TSD.AccountingSoft.DataAccess.IEntitiesDao.FixedAsset
{
    /// <summary>
    /// IFixedAssetArmortizationDao
    /// </summary>
    public interface IFixedAssetArmortizationDao
    {
        /// <summary>
        /// Gets the fa armortization.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        FAArmortizationEntity GetFAArmortization(long refId);

        /// <summary>
        /// Gets the fa armortizations by reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        List<FAArmortizationEntity> GetFAArmortizationsByRefTypeId(int refTypeId);

        /// <summary>
        /// Gets the fa armortizations.
        /// </summary>
        /// <returns></returns>
        List<FAArmortizationEntity> GetFAArmortizations();

        /// <summary>
        /// Gets the fa armortizations by reference date.
        /// </summary>
        /// <param name="refDate">The reference date.</param>
        /// <returns></returns>
        List<FAArmortizationEntity> GetFAArmortizationsByRefDate(DateTime refDate);

        /// <summary>
        /// Gets the fa armortizations by reference date.
        /// </summary>
        /// <param name="refDate">The reference date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns></returns>
        List<FAArmortizationEntity> GetFAArmortizationsByRefDate(DateTime refDate, string currencyCode);

        /// <summary>
        /// Inserts the fa armortization.
        /// </summary>
        /// <param name="fAArmortization">The f a armortization.</param>
        /// <returns></returns>
        int InsertFAArmortization(FAArmortizationEntity fAArmortization);

        /// <summary>
        /// Updates the fa armortization.
        /// </summary>
        /// <param name="fAArmortization">The f a armortization.</param>
        /// <returns></returns>
        string UpdateFAArmortization(FAArmortizationEntity fAArmortization);

        /// <summary>
        /// Deletes the fa armortization.
        /// </summary>
        /// <param name="fAArmortization">The f a armortization.</param>
        /// <returns></returns>
        string DeleteFAArmortization(FAArmortizationEntity fAArmortization);
    }
}

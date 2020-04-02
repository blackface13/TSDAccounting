/***********************************************************************
 * <copyright file="IFixedAssetArmortizationDetailDao.cs" company="BUCA JSC">
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

using TSD.AccountingSoft.BusinessEntities.Business.FixedAssetArmortization;
using System.Collections.Generic;


namespace TSD.AccountingSoft.DataAccess.IEntitiesDao.FixedAsset
{
    /// <summary>
    /// IFixedAssetArmortizationDetailDao
    /// </summary>
    public interface IFixedAssetArmortizationDetailDao
    {
        /// <summary>
        /// Gets the fa armortization details by fa armortization.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        List<FAArmortizationDetailEntity> GetFAArmortizationDetailsByFAArmortization(long refId);

        /// <summary>
        /// Gets the fa decrement by fa increment.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        List<FAArmortizationDetailEntity> GetFAArmortizationByFAIncrement(long refId);
        /// <summary>
        /// Gets the automatic fa armortization details by currency code.
        /// </summary>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="yearOfDeprecation">The year of deprecation.</param>
        /// <returns></returns>
        List<FAArmortizationDetailEntity> GetAutoFAArmortizationDetailsByCurrencyCode(string currencyCode, int yearOfDeprecation);

        /// <summary>
        /// Inserts the fa armortization detail.
        /// </summary>
        /// <param name="fAArmortizationDetail">The f a armortization detail.</param>
        /// <returns></returns>
        int InsertFAArmortizationDetail(FAArmortizationDetailEntity fAArmortizationDetail);

        /// <summary>
        /// Deletes the fa armortization detail by fa armortization identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        string DeleteFAArmortizationDetailByFAArmortizationId(long refId);
    }
}

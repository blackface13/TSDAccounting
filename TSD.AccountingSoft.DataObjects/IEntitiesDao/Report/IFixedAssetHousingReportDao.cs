/***********************************************************************
 * <copyright file="IFixedAssetHousingReportDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Thursday, March 13, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/
using System.Collections.Generic;
using TSD.AccountingSoft.BusinessEntities.Report;
namespace TSD.AccountingSoft.DataAccess.IEntitiesDao.Report
{
    /// <summary>
    /// IFixedAssetHousingReportDao
    /// </summary>
    public interface IFixedAssetHousingReportDao
    {
        /// <summary>
        /// Gets the fixed asset housing report.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>
        /// FixedAssetHousingReportEntity.
        /// </returns>
        FixedAssetHousingReportEntity GetFixedAssetHousingReport(bool isActive);

        /// <summary>
        /// Gets the fixed asset housing reports.
        /// </summary>
        /// <returns>
        /// List{FixedAssetHousingReportEntity}.
        /// </returns>
        List<FixedAssetHousingReportEntity> GetFixedAssetHousingReports();

        /// <summary>
        /// Gets the fixed asset housing reports by active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>
        /// List{FixedAssetHousingReportEntity}.
        /// </returns>
        List<FixedAssetHousingReportEntity> GetFixedAssetHousingReportsByActive(bool isActive);

        /// <summary>
        /// Inserts the fixed asset housing report.
        /// </summary>
        /// <param name="fixedAssetHousingReport">The budget chapter.</param>
        /// <returns>
        /// System.Int32.
        /// </returns>
        int InsertFixedAssetHousingReport(FixedAssetHousingReportEntity fixedAssetHousingReport);

        /// <summary>
        /// Updates the fixed asset housing report.
        /// </summary>
        /// <param name="fixedAssetHousingReport">The budget chapter.</param>
        /// <returns>
        /// System.String.
        /// </returns>
        string UpdateFixedAssetHousingReport(FixedAssetHousingReportEntity fixedAssetHousingReport);

        /// <summary>
        /// Deletes the fixed asset housing report.
        /// </summary>
        /// <param name="fixedAssetHousingReport">The budget chapter.</param>
        /// <returns>
        /// System.String.
        /// </returns>
        string DeleteFixedAssetHousingReport(FixedAssetHousingReportEntity fixedAssetHousingReport);

        /// <summary>
        /// Gets the fixed asset housing reports by fixed asset housing report code.
        /// </summary>
        /// <param name="fixedAssetHousingReportCode">The budget chapter code.</param>
        /// <returns>
        /// List{FixedAssetHousingReportEntity}.
        /// </returns>
        List<FixedAssetHousingReportEntity> GetFixedAssetHousingReportsByFixedAssetHousingReportCode(string fixedAssetHousingReportCode);

    }
}

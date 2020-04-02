/***********************************************************************
 * <copyright file="SqlServerEstimateDetailStatementFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TUDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: 19 June 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using TSD.AccountingSoft.BusinessEntities.Report.Estimate;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Estimate;
using TSD.AccountingSoft.DataHelpers;

namespace TSD.AccountingSoft.DataAccess.SqlServer.Estimate
{
    /// <summary>
    /// class SqlServerEstimateDetailStatementFixedAssetDao
    /// </summary>
    public class SqlServerEstimateDetailStatementFixedAssetDao : IEstimateDetailStatementFixedAssetDao
    {
        /// <summary>
        /// Gets the budgetSourceCategories.
        /// </summary>
        /// <returns></returns>
        public List<EstimateDetailStatementFixedAssetEntity> GetEstimateDetailStatementFixedAssets()
        {
            const string procedures = @"uspGet_All_EstimateDetailStatementFixedAsset";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Inserts the estimateDetailStatement.
        /// </summary>
        /// <param name="estimateDetailStatement">The estimateDetailStatement.</param>
        /// <returns></returns>
        public int InsertEstimateDetailStatementFixedAsset(EstimateDetailStatementFixedAssetEntity estimateDetailStatement)
        {
            const string sql = @"uspInsert_EstimateDetailStatementFixedAsset";
            return Db.Insert(sql, true, Take(estimateDetailStatement));
        }

        /// <summary>
        /// Updates the estimate detail statement.
        /// </summary>
        /// <param name="EstimateDetailStatementFixedAsset">The estimate detail statement part b.</param>
        /// <returns></returns>
        public string UpdateEstimateDetailStatementFixedAsset(EstimateDetailStatementFixedAssetEntity EstimateDetailStatementFixedAsset)
        {
            const string sql = @"uspUpdate_EstimateDetailStatementFixedAsset";
            return Db.Update(sql, true, Take(EstimateDetailStatementFixedAsset));
        }

        /// <summary>
        /// Deletes the estimateDetailStatement.
        /// </summary>
        /// <returns></returns>
        public string DeleteEstimateDetailStatementFixedAsset()
        {
            const string sql = @"uspDelete_EstimateDetailStatementFixedAsset";
            return Db.Delete(sql, true);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, EstimateDetailStatementFixedAssetEntity> Make = reader =>
             new EstimateDetailStatementFixedAssetEntity
             {
                 EstimateDetailStatementFixedAssetId = reader["EstimateDetailStatementFixedAssetId"].AsInt(),
                 OrderNumber = reader["OrderNumber"].AsInt(),
                 PurchasedYear = reader["PurchasedYear"].AsInt(),
                 OrgPriceUsd = reader["OrgPriceUSD"].AsDecimal(),
                 PurchasedOrgPriceUsd = reader["PurchasedOrgPriceUSD"].AsDecimal(),
                 Department = reader["Department"].AsString(),
                 ReplacementReason = reader["ReplacementReason"].AsString(),
                 PostedYear = reader["ReplacementReason"].AsInt(),
                 IsActive = reader["IsActive"].AsBool()
             };

        /// <summary>
        /// Takes the specified budgetSourceCategory.
        /// </summary>
        /// <param name="estimateDetailStatementFixedAsset">The estimate detail statement part b.</param>
        /// <returns></returns>
        private static object[] Take(EstimateDetailStatementFixedAssetEntity estimateDetailStatementFixedAsset)
        {
            return new object[]  
            {
                "@EstimateDetailStatementFixedAssetID", estimateDetailStatementFixedAsset.EstimateDetailStatementFixedAssetId,
                "@OrderNumber", estimateDetailStatementFixedAsset.OrderNumber,
                "@PurchasedYear", estimateDetailStatementFixedAsset.PurchasedYear,
                "@OrgPriceUSD", estimateDetailStatementFixedAsset.OrgPriceUsd,
                "@PurchasedOrgPriceUSD", estimateDetailStatementFixedAsset.PurchasedOrgPriceUsd,
                "@Department", estimateDetailStatementFixedAsset.Department,
                "@ReplacementReason", estimateDetailStatementFixedAsset.ReplacementReason,
                "@IsActive",estimateDetailStatementFixedAsset.IsActive
            };
        }
    }
}

/***********************************************************************
 * <copyright file="SqlServerEstimateDetailStatementDao.cs" company="BUCA JSC">
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
    /// class SqlServerEstimateDetailStatementDao
    /// </summary>
    public class SqlServerEstimateDetailStatementDao : IEstimateDetailStatementDao
    {
        /// <summary>
        /// Gets the estimateDetailStatement.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        public EstimateDetailStatementInfoEntity GetEstimateDetailStatement(bool isActive)
        {
            const string sql = @"uspGet_EstimateDetailStatementPartC_ByIsActive";
            return Db.Read(sql, true, Make);
        }


        public EstimateDetailStatementInfoEntity GetCompanyProfileInfo(bool isActive)
        {
            const string sql = @"uspGet_CompanyProfilePartC_ByIsActive";

            return Db.Read(sql, true, Make);
        }

        /// <summary>
        /// Gets the budgetSourceCategories.
        /// </summary>
        /// <returns></returns>
        public List<EstimateDetailStatementInfoEntity> GetEstimateDetailStatements()
        {
            const string procedures = @"uspGet_All_EstimateDetailStatementPartC";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Inserts the estimateDetailStatement.
        /// </summary>
        /// <param name="estimateDetailStatement">The estimateDetailStatement.</param>
        /// <returns></returns>
        public int InsertEstimateDetailStatement(EstimateDetailStatementInfoEntity estimateDetailStatement)
        {
            const string sql = @"uspInsert_EstimateDetailStatementPartC";
            return Db.Insert(sql, true, Take(estimateDetailStatement));
        }

        /// <summary>
        /// Updates the estimateDetailStatement.
        /// </summary>
        /// <param name="estimateDetailStatement">The estimateDetailStatement.</param>
        /// <returns></returns>
        public string UpdateEstimateDetailStatement(EstimateDetailStatementInfoEntity estimateDetailStatement)
        {
            const string sql = @"uspUpdate_EstimateDetailStatementPartC";
            return Db.Update(sql, true, Take(estimateDetailStatement));
        }

        /// <summary>
        /// Deletes the estimateDetailStatement.
        /// </summary>
        /// <param name="estimateDetailStatement">The estimateDetailStatement.</param>
        /// <returns></returns>
        public string DeleteEstimateDetailStatement(EstimateDetailStatementInfoEntity estimateDetailStatement)
        {
            const string sql = @"uspDelete_EstimateDetailStatementPartC";

            object[] parms = { "@EstimateDetailStatementID", estimateDetailStatement.EstimateDetailStatementId };
            return Db.Delete(sql, true, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, EstimateDetailStatementInfoEntity> Make = reader =>
            new EstimateDetailStatementInfoEntity
            {
                EstimateDetailStatementId = reader["EstimateDetailStatementId"].AsInt(),
                YearOfEstimate = reader["YearOfEstimate"].AsShort(),
                GeneralDescription = reader["GeneralDescription"].AsString(),
                EmployeeContractDescription = reader["EmployeeContractDescription"].AsString(),
                EmployeeLeasingDescription = reader["EmployeeLeasingDescription"].AsString(),
                BuildingOfFixedAssetDescription = reader["BuildingOfFixedAssetDescription"].AsString(),
                CarDescription = reader["CarDescription"].AsString(),
                DescriptionForBuilding = reader["DescriptionForBuilding"].AsString(),
                InventoryDescription = reader["InventoryDescription"].AsString(),
                PartC = reader["PartC"].AsString(),
                PartC1 = reader["PartC1"].AsString(),
                IsActive = reader["IsActive"].AsBool(),
                Type = reader["Type"].AsBool(),
            };

        /// <summary>
        /// Takes the specified budgetSourceCategory.
        /// </summary>
        /// <param name="estimateDetailStatement">The estimate detail statement.</param>
        /// <returns></returns>
        private static object[] Take(EstimateDetailStatementInfoEntity estimateDetailStatement)
        {
            return new object[]  
            {
                "@EstimateDetailStatementId", estimateDetailStatement.EstimateDetailStatementId,
                "@YearOfEstimate", estimateDetailStatement.YearOfEstimate,
                "@EmployeeContractDescription", estimateDetailStatement.EmployeeContractDescription,
                "@EmployeeLeasingDescription", estimateDetailStatement.EmployeeLeasingDescription,
                "@GeneralDescription", estimateDetailStatement.GeneralDescription,
                "@BuildingOfFixedAssetDescription", estimateDetailStatement.BuildingOfFixedAssetDescription,
                "@CarDescription", estimateDetailStatement.CarDescription,
                "@DescriptionForBuilding", estimateDetailStatement.DescriptionForBuilding,
                "@InventoryDescription", estimateDetailStatement.InventoryDescription,
                "@PartC", estimateDetailStatement.PartC,
                "@PartC1", estimateDetailStatement.PartC1,
                "@IsActive",estimateDetailStatement.IsActive,
                "@Type",estimateDetailStatement.Type
            };
        }
    }
}


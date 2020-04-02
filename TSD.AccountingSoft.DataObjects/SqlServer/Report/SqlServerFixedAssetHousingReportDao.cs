/***********************************************************************
 * <copyright file="SqlServerFixedAssetHousingReportDao.cs" company="BUCA JSC">
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
using System;
using System.Collections.Generic;
using System.Data;
using TSD.AccountingSoft.BusinessEntities.Report;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Report;
using TSD.AccountingSoft.DataHelpers;

namespace TSD.AccountingSoft.DataAccess.SqlServer.Report
{
    /// <summary>
    /// SqlServer Report Group Dao
    /// </summary>
    public class SqlServerFixedAssetHousingReportDao : IFixedAssetHousingReportDao
    {

        /// <summary>
        /// Gets the budget chapter.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>
        /// FixedAssetHousingReportEntity.
        /// </returns>
        public FixedAssetHousingReportEntity GetFixedAssetHousingReport(bool isActive)
        {
            string sql = isActive ? @"uspGet_FixedAssetHousingReport_ByID" : @"uspGet_FixedAssetHousingReport_B01";
            return Db.Read(sql, true, Make);
        }

        /// <summary>
        /// Gets the budget chapters.
        /// </summary>
        /// <returns>List{FixedAssetHousingReportEntity}.</returns>
        public List<FixedAssetHousingReportEntity> GetFixedAssetHousingReports()
        {
            const string procedures = @"uspGet_All_FixedAssetHousingReport";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Gets the budget chapters by active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>List{FixedAssetHousingReportEntity}.</returns>
        public List<FixedAssetHousingReportEntity> GetFixedAssetHousingReportsByActive(bool isActive)
        {
            const string sql = @"uspGet_FixedAssetHousingReport_IsActive";

            object[] parms = { "@IsActive", isActive };
            return Db.ReadList(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the fixedAssetHousingReports by fixedAssetHousingReport code.
        /// </summary>
        /// <param name="fixedAssetHousingReportCode">The fixedAssetHousingReport code.</param>
        /// <returns>List{FixedAssetHousingReportEntity}.</returns>
        public List<FixedAssetHousingReportEntity> GetFixedAssetHousingReportsByFixedAssetHousingReportCode(string fixedAssetHousingReportCode)
        {
            const string sql = @"uspGet_FixedAssetHousingReport_ByFixedAssetHousingReportCode";

            object[] parms = { "@FixedAssetHousingReportCode", fixedAssetHousingReportCode };
            return Db.ReadList(sql, true, Make, parms);
        }

        /// <summary>
        /// Inserts the budget chapter.
        /// </summary>
        /// <param name="fixedAssetHousingReport">The budget chapter.</param>
        /// <returns>System.Int32.</returns>
        public int InsertFixedAssetHousingReport(FixedAssetHousingReportEntity fixedAssetHousingReport)
        {
            const string sql = "uspInsert_FixedAssetHousingReport";
            return Db.Insert(sql, true, Take(fixedAssetHousingReport));
        }


        /// <summary>
        /// Updates the budget chapter.
        /// </summary>
        /// <param name="fixedAssetHousingReport">The budget chapter.</param>
        /// <returns>System.String.</returns>
        public string UpdateFixedAssetHousingReport(FixedAssetHousingReportEntity fixedAssetHousingReport)
        {
            const string sql = "uspUpdate_FixedAssetHousingReport";
            return Db.Update(sql, true, Take(fixedAssetHousingReport));
        }

        /// <summary>
        /// Deletes the budget chapter.
        /// </summary>
        /// <param name="fixedAssetHousingReport">The budget chapter.</param>
        /// <returns>System.String.</returns>
        public string DeleteFixedAssetHousingReport(FixedAssetHousingReportEntity fixedAssetHousingReport)
        {
            const string sql = @"uspDelete_FixedAssetHousingReport";

            object[] parms = { "@FixedAssetHousingReportID", fixedAssetHousingReport.FixedAssetHousingReportId };
            return Db.Delete(sql, true, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, FixedAssetHousingReportEntity> Make = reader =>
            new FixedAssetHousingReportEntity
            {
                FixedAssetHousingReportId = reader["FixedAssetHousingReportID"].AsInt(),
                AreaOfBuilding = reader["AreaOfBuilding"].AsDecimal(),
                WorkingArea = reader["WorkingArea"].AsDecimal(),
                HousingArea = reader["HousingArea"].AsDecimal(),
                GuestHouseArea = reader["GuestHouseArea"].AsDecimal(),
                OccupiedArea = reader["OccupiedArea"].AsDecimal(),
                OtherArea = reader["OtherArea"].AsDecimal(),
                AccountingValue = reader["AccountingValue"].AsDecimal(),
                Attachments = reader["Attachments"].AsString()
            };


        /// <summary>
        /// Takes the specified budget chapter.
        /// </summary>
        /// <param name="fixedAssetHousingReport">The budget chapter.</param>
        /// <returns>System.Object[][].</returns>
        private object[] Take(FixedAssetHousingReportEntity fixedAssetHousingReport)
        {
            return new object[]  
            {
                "@FixedAssetHousingReportID", fixedAssetHousingReport.FixedAssetHousingReportId,
                "@AreaOfBuilding", fixedAssetHousingReport.AreaOfBuilding,
                "@WorkingArea", fixedAssetHousingReport.WorkingArea,
                "@HousingArea", fixedAssetHousingReport.HousingArea,
                "@GuestHouseArea", fixedAssetHousingReport.GuestHouseArea,
                "@OccupiedArea", fixedAssetHousingReport.OccupiedArea,
                "@OtherArea", fixedAssetHousingReport.OtherArea,
                "@AccountingValue", fixedAssetHousingReport.AccountingValue,
                "@Attachments", fixedAssetHousingReport.Attachments
            };
        }
    }
}

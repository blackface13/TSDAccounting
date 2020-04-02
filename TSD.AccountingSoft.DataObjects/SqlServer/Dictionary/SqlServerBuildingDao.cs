/***********************************************************************
 * <copyright file="SqlServerBuildingDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 10 June 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using TSD.AccountingSoft.BusinessEntities.Dictionary;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary;
using TSD.AccountingSoft.DataHelpers;


namespace TSD.AccountingSoft.DataAccess.SqlServer.Dictionary
{
    public class SqlServerBuildingDao : IBuildingDao
    {
        /// <summary>
        /// Gets the building.
        /// </summary>
        /// <param name="buildingId">The building identifier.</param>
        /// <returns></returns>
        public BuildingEntity GetBuilding(int buildingId)
        {
            const string sql = @"uspGet_Building_ByID";

            object[] parms = { "@BuildingID", buildingId };
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the buildings.
        /// </summary>
        /// <returns></returns>
        public List<BuildingEntity> GetBuildings()
        {
            const string procedures = @"uspGet_All_Building";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Gets the employee leasings.
        /// </summary>
        /// <param name="isLeasing">if set to <c>true</c> [is leasing].</param>
        /// <returns></returns>
        public List<BuildingEntity> GetBuildings(bool isLeasing)
        {
            const string procedures = @"uspGet_Building_ByIsLeasing";

            object[] parms = { "@IsLeasing", isLeasing };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the buildings by building code.
        /// </summary>
        /// <param name="buildingCode">The building code.</param>
        /// <returns></returns>
        public List<BuildingEntity> GetBuildingsByBuildingCode(string buildingCode)
        {
            const string sql = @"uspGet_Building_ByBuildingCode";

            object[] parms = { "@BuildingCode", buildingCode };
            return Db.ReadList(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the buildings by active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        public List<BuildingEntity> GetBuildingsByActive(bool isActive)
        {
            const string sql = @"uspGet_Building_IsActive";

            object[] parms = { "@IsActive", isActive };
            return Db.ReadList(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the buildings for estimate report.
        /// </summary>
        /// <returns></returns>
        public List<BuildingEntity> GetBuildingsForEstimateReport(bool isCompanyProfile)
        {
            string sql = isCompanyProfile ? @"uspGet_Building_ForEstimateReport" : @"uspGet_Building_ForEstimateReportByCompanyProfile";
            return Db.ReadList(sql, true, MakeForEstimateReport);
        }

        /// <summary>
        /// Inserts the building.
        /// </summary>
        /// <param name="building">The building.</param>
        /// <returns></returns>
        public int InsertBuilding(BuildingEntity building)
        {
            const string sql = @"uspInsert_Building";
            return Db.Insert(sql, true, Take(building));
        }

        /// <summary>
        /// Updates the building.
        /// </summary>
        /// <param name="building">The building.</param>
        /// <returns></returns>
        public string UpdateBuilding(BuildingEntity building)
        {
            const string sql = @"uspUpdate_Building";
            return Db.Update(sql, true, Take(building));
        }

        /// <summary>
        /// Deletes the building.
        /// </summary>
        /// <param name="building">The building.</param>
        /// <returns></returns>
        public string DeleteBuilding(BuildingEntity building)
        {
            const string sql = @"uspDelete_Building";

            object[] parms = { "@BuildingId", building.BuildingId };
            return Db.Delete(sql, true, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, BuildingEntity> Make = reader =>
            new BuildingEntity
            {
                BuildingId = reader["BuildingID"].AsInt(),
                BuildingCode = reader["BuildingCode"].AsString(),
                BuildingName = reader["BuildingName"].AsString(),
                JobCandidate = reader["JobCandidate"].AsString(),
                Address = reader["Address"].AsString(),
                Area = reader["Area"].AsFloat(),
                UnitPrice = reader["UnitPrice"].AsDecimal(),
                StartDate = reader["StartDate"].AsDateTime(),
                EndDate = reader["EndDate"].AsDateTime(),
                Description = reader["Description"].AsString(),
                IsActive = reader["IsActive"].AsBool()
            };

        /// <summary>
        /// The make for estimate report
        /// </summary>
        private static readonly Func<IDataReader, BuildingEntity> MakeForEstimateReport = reader =>
            new BuildingEntity
            {
                OrderNumber = reader["ID"].AsInt(),
                BuildingId = reader["BuildingID"].AsInt(),
                BuildingCode = reader["BuildingCode"].AsString(),
                BuildingName = reader["BuildingName"].AsString(),
                JobCandidate = reader["JobCandidate"].AsString(),
                Address = reader["Address"].AsString(),
                Area = reader["Area"].AsFloat(),
                UnitPrice = reader["UnitPrice"].AsDecimal(),
                StartDate = reader["StartDate"].AsDateTime(),
                EndDate = reader["EndDate"].AsDateTime(),
                Description = reader["Description"].AsString(),
                IsActive = reader["IsActive"].AsBool()
            };

        /// <summary>
        /// Takes the specified employee leasing.
        /// </summary>
        /// <param name="building">The employee leasing.</param>
        /// <returns></returns>
        private static object[] Take(BuildingEntity building)
        {
            return new object[]  
            {
                "@BuildingID", building.BuildingId,
                "@BuildingCode", building.BuildingCode,
                "@BuildingName", building.BuildingName,
                "@JobCandidate", building.JobCandidate,
                "@Address", building.Address,
                "@Area", building.Area,
                "@UnitPrice", building.UnitPrice,
                "@StartDate", building.StartDate,
                "@EndDate", building.EndDate,
                "@Description", building.Description,
                "@IsActive", building.IsActive
            };
        }
    }
}

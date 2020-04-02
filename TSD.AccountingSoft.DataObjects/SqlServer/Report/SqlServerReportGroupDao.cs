/***********************************************************************
 * <copyright file="SqlServerReportGroupDao.cs" company="BUCA JSC">
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
    public class SqlServerReportGroupDao : IReportGroupDao
    {
        #region IReportGroupDao Members

        /// <summary>
        /// Gets the report lists.
        /// </summary>
        /// <returns></returns>
        public List<ReportGroupEntity> GetReportGroups()
        {
            const string procedures = @"uspGet_All_ReportGroup";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Gets the report group by identifier.
        /// </summary>
        /// <param name="reportGroupID">The report group identifier.</param>
        /// <returns></returns>
        public ReportGroupEntity GetReportGroupByID(int reportGroupID)
        {
            const string sql = @"uspGet_ReportGroup_ByID";

            object[] parms = { "@ReportGroupID", reportGroupID };
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, ReportGroupEntity> Make = reader =>
            new ReportGroupEntity
            {
                ReportGroupId = reader["ReportGroupID"].AsInt(),
                ReportGroupName = reader["ReportGroupName"].AsString(),
                Description = reader["Description"].AsString(),
                IsActive = reader["IsActive"].AsBool(),
                IsVoucher = reader["IsVoucher"].AsBool()
            };
        #endregion
    }
}

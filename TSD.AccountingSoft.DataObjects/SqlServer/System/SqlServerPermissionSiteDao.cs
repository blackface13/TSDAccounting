/***********************************************************************
 * <copyright file="SqlServerPermissionSiteDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 26 May 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using TSD.AccountingSoft.BusinessEntities.System;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.System;
using TSD.AccountingSoft.DataHelpers;


namespace TSD.AccountingSoft.DataAccess.SqlServer.System
{
    /// <summary>
    /// class SqlServerPermissionSiteDao
    /// </summary>
    public class SqlServerPermissionSiteDao : IPermissionSiteDao
    {
        /// <summary>
        /// Gets the permission sites by site identifier.
        /// </summary>
        /// <param name="siteId">The site identifier.</param>
        /// <returns></returns>
        public List<PermissionSiteEntity> GetPermissionSitesBySiteId(int siteId)
        {
            const string procedures = @"uspGet_PermissionSite_BySiteID";

            object[] parms = { "@SiteID", siteId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Inserts the estimate detail.
        /// </summary>
        /// <param name="permissionSite">The estimate detail.</param>
        /// <returns></returns>
        public int InsertPermissionSite(PermissionSiteEntity permissionSite)
        {
            const string sql = @"uspInsert_PermissionSite";
            return Db.Insert(sql, true, Take(permissionSite));
        }

        /// <summary>
        /// Deletes the permission site by site identifier.
        /// </summary>
        /// <param name="siteId">The site identifier.</param>
        /// <returns></returns>
        public string DeletePermissionSiteBySiteId(int siteId)
        {
            const string procedures = @"uspDelete_PermissionSite_By_SiteID";

            object[] parms = { "@SiteID", siteId };
            return Db.Delete(procedures, true, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, PermissionSiteEntity> Make = reader =>
            new PermissionSiteEntity
            {
                PermissionId = reader["PermissionID"].AsInt(),
                PermissionSiteId = reader["PermissionSiteID"].AsInt(),
                SiteId = reader["SiteID"].AsInt()
            };

        /// <summary>
        /// Takes the specified permission site.
        /// </summary>
        /// <param name="permissionSite">The permission site.</param>
        /// <returns></returns>
        private static object[] Take(PermissionSiteEntity permissionSite)
        {
            return new object[]  
            {
                @"PermissionSiteID", permissionSite.PermissionSiteId,
                @"PermissionID", permissionSite.PermissionId,
                @"SiteID", permissionSite.SiteId
            };
        }
    }
}

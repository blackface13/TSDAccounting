/***********************************************************************
 * <copyright file="SqlServerSiteDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 22 May 2014
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
    ///  class SqlServerSiteDao
    /// </summary>
    public class SqlServerSiteDao : ISiteDao
    {
        /// <summary>
        /// Gets the sites.
        /// </summary>
        /// <returns></returns>
        public List<SiteEntity> GetSites()
        {
            const string procedures = @"uspGet_All_Site";

            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Gets the sites.
        /// </summary>
        /// <param name="isActive"></param>
        /// <returns></returns>
        public List<SiteEntity> GetSites(bool isActive)
        {
            const string procedures = @"uspGet_Site_ByIsActive";

            object[] parms = { "@IsActive", isActive };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the site.
        /// </summary>
        /// <param name="siteId">The site identifier.</param>
        /// <returns></returns>
        public SiteEntity GetSite(int siteId)
        {
            const string procedures = @"uspGet_Site_ByID";

            object[] parms = { "@SiteID", siteId };
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        /// Inserts the site.
        /// </summary>
        /// <param name="site">The site.</param>
        /// <returns></returns>
        public int InsertSite(SiteEntity site)
        {
            const string sql = @"uspInsert_Site";
            return Db.Insert(sql, true, Take(site));
        }

        /// <summary>
        /// Updates the site.
        /// </summary>
        /// <param name="site">The site.</param>
        /// <returns></returns>
        public string UpdateSite(SiteEntity site)
        {
            const string sql = @"uspUpdate_Site";
            return Db.Update(sql, true, Take(site));
        }

        /// <summary>
        /// Deletes the site.
        /// </summary>
        /// <param name="site">The site.</param>
        /// <returns></returns>
        public string DeleteSite(SiteEntity site)
        {
            const string sql = @"uspDelete_Site";

            object[] parms = { "@SiteID", site.SiteId };
            return Db.Delete(sql, true, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, SiteEntity> Make = reader =>
            new SiteEntity
            {
                SiteId = reader["SiteID"].AsInt(),
                SiteCode = reader["SiteCode"].AsString(),
                SiteName = reader["SiteName"].AsString(),
                Description = reader["Description"].AsString(),
                ParentId = reader["ParentID"].AsString().AsIntForNull(),
                Order = reader["Order"].AsInt(),
                IsActive = reader["IsActive"].AsBool()
            };

        /// <summary>
        /// Takes the specified site.
        /// </summary>
        /// <param name="site">The site.</param>
        /// <returns></returns>
        private object[] Take(SiteEntity site)
        {
            return new object[]  
            {
                @"SiteID", site.SiteId,
                @"SiteCode", site.SiteCode,
                @"SiteName", site.SiteName,
                @"Description", site.Description,
                @"ParentID", site.ParentId,
                @"Order", site.Order,
                @"IsActive", site.IsActive
            };
        }
    }
}

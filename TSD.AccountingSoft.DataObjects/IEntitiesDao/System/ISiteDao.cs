/***********************************************************************
 * <copyright file="ISiteDao.cs" company="BUCA JSC">
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

using System.Collections.Generic;
using TSD.AccountingSoft.BusinessEntities.System;
namespace TSD.AccountingSoft.DataAccess.IEntitiesDao.System
{
    /// <summary>
    /// ISiteDao
    /// </summary>
    public interface ISiteDao
    {
        /// <summary>
        /// Gets the sites.
        /// </summary>
        /// <returns></returns>
        List<SiteEntity> GetSites();

        /// <summary>
        /// Gets the sites.
        /// </summary>
        /// <returns></returns>
        List<SiteEntity> GetSites(bool isActive);

        /// <summary>
        /// Gets the site.
        /// </summary>
        /// <param name="siteId">The site identifier.</param>
        /// <returns></returns>
        SiteEntity GetSite(int siteId);

        /// <summary>
        /// Inserts the site.
        /// </summary>
        /// <param name="site">The site.</param>
        /// <returns></returns>
        int InsertSite(SiteEntity site);

        /// <summary>
        /// Updates the site.
        /// </summary>
        /// <param name="site">The site.</param>
        /// <returns></returns>
        string UpdateSite(SiteEntity site);

        /// <summary>
        /// Deletes the site.
        /// </summary>
        /// <param name="site">The site.</param>
        /// <returns></returns>
        string DeleteSite(SiteEntity site);
    }
}

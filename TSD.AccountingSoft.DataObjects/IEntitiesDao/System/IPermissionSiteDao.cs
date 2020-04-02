/***********************************************************************
 * <copyright file="IPermissionSiteDao.cs" company="BUCA JSC">
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

using System.Collections.Generic;
using TSD.AccountingSoft.BusinessEntities.System;


namespace TSD.AccountingSoft.DataAccess.IEntitiesDao.System
{
    /// <summary>
    /// IPermissionSiteDao
    /// </summary>
    public interface IPermissionSiteDao
    {
        /// <summary>
        /// Gets the permission sites by site identifier.
        /// </summary>
        /// <param name="siteId">The site identifier.</param>
        /// <returns></returns>
        List<PermissionSiteEntity> GetPermissionSitesBySiteId(int siteId);

        /// <summary>
        /// Inserts the estimate detail.
        /// </summary>
        /// <param name="permissionSite">The estimate detail.</param>
        /// <returns></returns>
        int InsertPermissionSite(PermissionSiteEntity permissionSite);

        /// <summary>
        /// Deletes the permission site by site identifier.
        /// </summary>
        /// <param name="siteId">The site identifier.</param>
        /// <returns></returns>
        string DeletePermissionSiteBySiteId(int siteId);
    }
}

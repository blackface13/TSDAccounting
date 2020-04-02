/***********************************************************************
 * <copyright file="IPermissionDao.cs" company="BUCA JSC">
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
    /// IPermissionDao
    /// </summary>
    public interface IPermissionDao
    {
        /// <summary>
        /// Gets the permissions.
        /// </summary>
        /// <returns></returns>
        List<PermissionEntity> GetPermissions();

        /// <summary>
        /// Gets the permissions.
        /// </summary>
        /// <returns></returns>
        List<PermissionEntity> GetPermissions(bool isActive);

        /// <summary>
        /// Gets the permission.
        /// </summary>
        /// <param name="permissionId">The permission identifier.</param>
        /// <returns></returns>
        PermissionEntity GetPermission(int permissionId);

        /// <summary>
        /// Inserts the permission.
        /// </summary>
        /// <param name="permission">The permission.</param>
        /// <returns></returns>
        int InsertPermission(PermissionEntity permission);

        /// <summary>
        /// Updates the permission.
        /// </summary>
        /// <param name="permission">The permission.</param>
        /// <returns></returns>
        string UpdatePermission(PermissionEntity permission);

        /// <summary>
        /// Deletes the permission.
        /// </summary>
        /// <param name="permission">The permission.</param>
        /// <returns></returns>
        string DeletePermission(PermissionEntity permission);
    }
}
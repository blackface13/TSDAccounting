/***********************************************************************
 * <copyright file="GeneralPaymentDetailEstimateEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 10 May 2014
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
    /// IRoleDao
    /// </summary>
    public interface IRoleDao
    {
        /// <summary>
        /// Gets the roles.
        /// </summary>
        /// <returns></returns>
        List<RoleEntity> GetRoles();

        /// <summary>
        /// Gets the roles.
        /// </summary>
        /// <returns></returns>
        List<RoleEntity> GetRoles(bool isActive);

        /// <summary>
        /// Gets the role.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <returns></returns>
        RoleEntity GetRole(int roleId);

        /// <summary>
        /// Inserts the role.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns></returns>
        int InsertRole(RoleEntity role);

        /// <summary>
        /// Updates the role.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns></returns>
        string UpdateRole(RoleEntity role);

        /// <summary>
        /// Deletes the role.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns></returns>
        string DeleteRole(RoleEntity role);
    }
}

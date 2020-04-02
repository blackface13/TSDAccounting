/***********************************************************************
 * <copyright file="IRoleSiteDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 27 May 2014
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
    /// IRoleSiteDao
    /// </summary>
    public interface IRoleSiteDao 
    {
        /// <summary>
        /// Gets the role site by role identifier.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <returns></returns>
        List<RoleSiteEntity> GetRoleSiteByRoleId(int roleId);

        /// <summary>
        /// Inserts the role site.
        /// </summary>
        /// <param name="roleSiteEntity">The role site entity.</param>
        /// <returns></returns>
        int InsertRoleSite(RoleSiteEntity roleSiteEntity);

        /// <summary>
        /// Deletes the role site.
        /// </summary>
        /// <param name="roleSiteEntity">The role site entity.</param>
        /// <returns></returns>
        string DeleteRoleSite(RoleSiteEntity roleSiteEntity);

        /// <summary>
        /// Deletes the role site by role identifier.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <returns></returns>
        string DeleteRoleSiteByRoleId(int roleId);
    }
}

/***********************************************************************
 * <copyright file="SqlServerRoleSiteDao.cs" company="BUCA JSC">
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

using System;
using System.Collections.Generic;
using System.Data;
using TSD.AccountingSoft.BusinessEntities.System;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.System;
using TSD.AccountingSoft.DataHelpers;


namespace TSD.AccountingSoft.DataAccess.SqlServer.System
{
    /// <summary>
    /// SqlServerRoleSiteDao
    /// </summary>
    public class SqlServerRoleSiteDao : IRoleSiteDao
    {
        /// <summary>
        /// Gets the role site by role identifier.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <returns></returns>
        public List<RoleSiteEntity> GetRoleSiteByRoleId(int roleId)
        {
            const string procedures = @"uspGet_RoleSite_ByRoleID";

            object[] parms = { "@RoleID", roleId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Inserts the role site.
        /// </summary>
        /// <param name="roleSiteEntity">The role site entity.</param>
        /// <returns></returns>
        public int InsertRoleSite(RoleSiteEntity roleSiteEntity)
        {
            const string sql = @"uspInsert_RoleSite";
            return Db.Insert(sql, true, Take(roleSiteEntity));
        }

        /// <summary>
        /// Deletes the role site.
        /// </summary>
        /// <param name="roleSiteEntity">The role site entity.</param>
        /// <returns></returns>
        public string DeleteRoleSite(RoleSiteEntity roleSiteEntity)
        {
            const string sql = @"uspDelete_RoleSite";

            object[] parms = { "@RoleSiteID", roleSiteEntity.RoleSiteId };
            return Db.Delete(sql, true, parms);
        }

        /// <summary>
        /// Deletes the role site by role identifier.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <returns></returns>
        public string DeleteRoleSiteByRoleId(int roleId)
        {
            const string sql = @"uspDelete_RoleSite_ByRoleID";

            object[] parms = { "@RoleID", roleId };
            return Db.Delete(sql, true, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, RoleSiteEntity> Make = reader =>
            new RoleSiteEntity
            {
                RoleSiteId = reader["RoleSiteID"].AsInt(),
                RoleId = reader["RoleID"].AsInt(),
                SiteId = reader["SiteID"].AsInt(),
                PermissionId = reader["PermissionID"].AsString().AsIntForNull()
            };

        /// <summary>
        /// Takes the specified role site entity.
        /// </summary>
        /// <param name="roleSiteEntity">The role site entity.</param>
        /// <returns></returns>
        private static object[] Take(RoleSiteEntity roleSiteEntity)
        {
            return new object[]  
            {
                @"RoleSiteID", roleSiteEntity.RoleSiteId,
                @"RoleID", roleSiteEntity.RoleId,
                @"SiteID", roleSiteEntity.SiteId,
                @"PermissionID", roleSiteEntity.PermissionId
            };
        }
    }
}

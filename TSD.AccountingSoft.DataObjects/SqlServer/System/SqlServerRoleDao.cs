/***********************************************************************
 * <copyright file="SqlServerRoleDao.cs" company="BUCA JSC">
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
    /// class SqlServerRoleDao
    /// </summary>
    public class SqlServerRoleDao : IRoleDao
    {
        /// <summary>
        /// Gets the roles.
        /// </summary>
        /// <returns></returns>
        public List<RoleEntity> GetRoles()
        {
            const string procedures = @"uspGet_All_Role";

            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Gets the roles.
        /// </summary>
        /// <param name="isActive"></param>
        /// <returns></returns>
        public List<RoleEntity> GetRoles(bool isActive)
        {
            const string procedures = @"uspGet_Role_ByIsActive";

            object[] parms = { "@IsActive", isActive };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the role.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <returns></returns>
        public RoleEntity GetRole(int roleId)
        {
            const string procedures = @"uspGet_Role_ByID";

            object[] parms = { "@RoleID", roleId };
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        /// Inserts the role.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns></returns>
        public int InsertRole(RoleEntity role)
        {
            const string sql = @"uspInsert_Role";
            return Db.Insert(sql, true, Take(role));
        }

        /// <summary>
        /// Updates the role.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns></returns>
        public string UpdateRole(RoleEntity role)
        {
            const string sql = @"uspUpdate_Role";
            return Db.Update(sql, true, Take(role));
        }

        /// <summary>
        /// Deletes the role.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns></returns>
        public string DeleteRole(RoleEntity role)
        {
            const string sql = @"uspDelete_Role";

            object[] parms = { "@RoleID", role.RoleId };
            return Db.Delete(sql, true, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, RoleEntity> Make = reader =>
            new RoleEntity
            {
                RoleId = reader["RoleID"].AsInt(),
                RoleName = reader["RoleName"].AsString(),
                Description = reader["Description"].AsString(),
                IsActive = reader["IsActive"].AsBool()
            };

        /// <summary>
        /// Takes the specified role.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns></returns>
        private object[] Take(RoleEntity role)
        {
            return new object[]  
            {
                @"RoleID", role.RoleId,
                @"RoleName", role.RoleName,
                @"Description", role.Description,
                @"IsActive", role.IsActive
            };
        }
    }
}

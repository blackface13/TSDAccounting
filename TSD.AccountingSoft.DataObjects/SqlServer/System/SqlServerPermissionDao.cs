/***********************************************************************
 * <copyright file="SqlServerPermissionDao.cs" company="BUCA JSC">
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
    /// class SqlServerPermissionDao
    /// </summary>
    public class SqlServerPermissionDao : IPermissionDao
    {
        /// <summary>
        /// Gets the permissions.
        /// </summary>
        /// <returns></returns>
        public List<PermissionEntity> GetPermissions()
        {
            const string procedures = @"uspGet_All_Permission";

            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Gets the permissions.
        /// </summary>
        /// <param name="isActive"></param>
        /// <returns></returns>
        public List<PermissionEntity> GetPermissions(bool isActive)
        {
            const string procedures = @"uspGet_Permission_ByIsActive";

            object[] parms = { "@IsActive", isActive };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the permission.
        /// </summary>
        /// <param name="permissionId">The permission identifier.</param>
        /// <returns></returns>
        public PermissionEntity GetPermission(int permissionId)
        {
            const string procedures = @"uspGet_Permission_ByID";

            object[] parms = { "@PermissionID", permissionId };
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        /// Inserts the permission.
        /// </summary>
        /// <param name="permission">The permission.</param>
        /// <returns></returns>
        public int InsertPermission(PermissionEntity permission)
        {
            const string sql = @"uspInsert_Permission";
            return Db.Insert(sql, true, Take(permission));
        }

        /// <summary>
        /// Updates the permission.
        /// </summary>
        /// <param name="permission">The permission.</param>
        /// <returns></returns>
        public string UpdatePermission(PermissionEntity permission)
        {
            const string sql = @"uspUpdate_Permission";
            return Db.Update(sql, true, Take(permission));
        }

        /// <summary>
        /// Deletes the permission.
        /// </summary>
        /// <param name="permission">The permission.</param>
        /// <returns></returns>
        public string DeletePermission(PermissionEntity permission)
        {
            const string sql = @"uspDelete_Permission";

            object[] parms = { "@PermissionID", permission.PermissionId };
            return Db.Delete(sql, true, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, PermissionEntity> Make = reader =>
            new PermissionEntity
            {
                PermissionId = reader["PermissionID"].AsInt(),
                PermissionCode = reader["PermissionCode"].AsString(),
                PermissionName = reader["PermissionName"].AsString(),
                Description = reader["Description"].AsString(),
                IsActive = reader["IsActive"].AsBool()
            };

        /// <summary>
        /// Takes the specified permission.
        /// </summary>
        /// <param name="permission">The permission.</param>
        /// <returns></returns>
        private object[] Take(PermissionEntity permission)
        {
            return new object[]  
            {
                @"PermissionID", permission.PermissionId,
                @"PermissionCode", permission.PermissionCode,
                @"PermissionName", permission.PermissionName,
                @"Description", permission.Description,
                @"IsActive", permission.IsActive
            };
        }
    }
}
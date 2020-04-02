/***********************************************************************
 * <copyright file="SqlServerDepartmentDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 07 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using TSD.AccountingSoft.BusinessEntities.Dictionary;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary;
using TSD.AccountingSoft.DataHelpers;


namespace TSD.AccountingSoft.DataAccess.SqlServer.Dictionary
{
    /// <summary>
    /// SqlServerDepartmentDao
    /// </summary>
    public class SqlServerDepartmentDao : IDepartmentDao
    {
        /// <summary>
        /// Gets the department.
        /// </summary>
        /// <param name="departmentId">The department identifier.</param>
        /// <returns></returns>
        public DepartmentEntity GetDepartment(int departmentId)
        {
            const string sql = @"uspGet_Department_ByID";

            object[] parms = { "@DepartmentID", departmentId };
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the departments.
        /// </summary>
        /// <returns></returns>
        public List<DepartmentEntity> GetDepartments()
        {
            const string procedures = @"uspGet_All_Department";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Gets the departments by department code.
        /// </summary>
        /// <param name="departmentCode">The department code.</param>
        /// <returns></returns>
        public List<DepartmentEntity> GetDepartmentsByDepartmentCode(string departmentCode)
        {
            const string sql = @"uspGet_Department_ByDepartmentCode";

            object[] parms = { "@DepartmentCode", departmentCode };
            return Db.ReadList(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the departments by active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        public List<DepartmentEntity> GetDepartmentsByActive(bool isActive)
        {
            const string sql = @"uspGet_Department_IsActive";

            object[] parms = { "@IsActive", isActive };
            return Db.ReadList(sql, true, Make, parms);
        }

        /// <summary>
        /// Inserts the department.
        /// </summary>
        /// <param name="department">The department.</param>
        /// <returns></returns>
        public int InsertDepartment(DepartmentEntity department)
        {
            const string sql = @"uspInsert_Department";
            return Db.Insert(sql, true, Take(department));
        }

        /// <summary>
        /// Updates the department.
        /// </summary>
        /// <param name="department">The department.</param>
        /// <returns></returns>
        public string UpdateDepartment(DepartmentEntity department)
        {
            const string sql = @"uspUpdate_Department";
            return Db.Update(sql, true, Take(department));
        }

        /// <summary>
        /// Deletes the department.
        /// </summary>
        /// <param name="department">The department.</param>
        /// <returns></returns>
        public string DeleteDepartment(DepartmentEntity department)
        {
            const string sql = @"uspDelete_Department";

            object[] parms = { "@DepartmentId", department.DepartmentId };
            return Db.Delete(sql, true, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, DepartmentEntity> Make = reader =>
            new DepartmentEntity
            {
                DepartmentId = reader["DepartmentID"].AsInt(),
                DepartmentCode = reader["DepartmentCode"].AsString(),
                DepartmentName = reader["DepartmentName"].AsString(),
                Description = reader["Description"].AsString(),
                ParentId = reader["ParentID"].AsString().AsIntForNull(),
                IsActive = reader["IsActive"].AsBool()
            };

        /// <summary>
        /// Takes the specified department.
        /// </summary>
        /// <param name="department">The department.</param>
        /// <returns></returns>
        private static object[] Take(DepartmentEntity department)
        {
            return new object[]  
            {
                "@DepartmentID", department.DepartmentId,
                "@DepartmentCode", department.DepartmentCode,
                "@DepartmentName", department.DepartmentName,
                "@Description", department.Description,
                "@ParentID", department.ParentId,
                "@IsActive", department.IsActive
            };
        }
    }
}
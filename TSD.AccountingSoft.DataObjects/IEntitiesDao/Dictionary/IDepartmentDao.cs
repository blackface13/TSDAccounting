/***********************************************************************
 * <copyright file="IDepartmentDao.cs" company="BUCA JSC">
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

using System.Collections.Generic;
using TSD.AccountingSoft.BusinessEntities.Dictionary;


namespace TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary
{
    /// <summary>
    /// IDepartmentDao
    /// </summary>
    public interface IDepartmentDao
    {
        /// <summary>
        /// Gets the department.
        /// </summary>
        /// <param name="departmentId">The department identifier.</param>
        /// <returns></returns>
        DepartmentEntity GetDepartment(int departmentId);

        /// <summary>
        /// Gets the departments.
        /// </summary>
        /// <returns></returns>
        List<DepartmentEntity> GetDepartments();

        /// <summary>
        /// Gets the departments by department code.
        /// </summary>
        /// <param name="departmentCode">The department code.</param>
        /// <returns></returns>
        List<DepartmentEntity> GetDepartmentsByDepartmentCode(string departmentCode);

        /// <summary>
        /// Gets the departments by active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        List<DepartmentEntity> GetDepartmentsByActive(bool isActive);

        /// <summary>
        /// Inserts the department.
        /// </summary>
        /// <param name="department">The department.</param>
        /// <returns></returns>
        int InsertDepartment(DepartmentEntity department);

        /// <summary>
        /// Updates the department.
        /// </summary>
        /// <param name="department">The department.</param>
        /// <returns></returns>
        string UpdateDepartment(DepartmentEntity department);

        /// <summary>
        /// Deletes the department.
        /// </summary>
        /// <param name="department">The department.</param>
        /// <returns></returns>
        string DeleteDepartment(DepartmentEntity department);
    }
}
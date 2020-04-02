/***********************************************************************
 * <copyright file="IEmployeeLeasingDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 09 June 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using TSD.AccountingSoft.BusinessEntities.Dictionary;
using System.Collections.Generic;


namespace TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary
{
    /// <summary>
    /// IEmployeeLeasingDao
    /// </summary>
    public interface IEmployeeLeasingDao
    {
        /// <summary>
        /// Gets the employeeLeasing.
        /// </summary>
        /// <param name="employeeLeasingId">The employeeLeasing identifier.</param>
        /// <returns></returns>
        EmployeeLeasingEntity GetEmployeeLeasing(int employeeLeasingId);

        /// <summary>
        /// Gets the employeeLeasings.
        /// </summary>
        /// <returns></returns>
        List<EmployeeLeasingEntity> GetEmployeeLeasings();

        /// <summary>
        /// Gets the employee leasings.
        /// </summary>
        /// <param name="isLeasing">if set to <c>true</c> [is leasing].</param>
        /// <returns></returns>
        List<EmployeeLeasingEntity> GetEmployeeLeasings(bool isLeasing);

        /// <summary>
        /// Gets the employeeLeasings by employeeLeasing code.
        /// </summary>
        /// <param name="employeeLeasingCode">The employeeLeasing code.</param>
        /// <returns></returns>
        List<EmployeeLeasingEntity> GetEmployeeLeasingsByEmployeeLeasingCode(string employeeLeasingCode);

        /// <summary>
        /// Gets the employeeLeasings by active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        List<EmployeeLeasingEntity> GetEmployeeLeasingsByActive(bool isActive);

        /// <summary>
        /// Gets the employee leasings by active.
        /// </summary>
        /// <param name="isLeasing">if set to <c>true</c> [is leasing].</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        List<EmployeeLeasingEntity> GetEmployeeLeasingsByActive(bool isLeasing, bool isActive);

        /// <summary>
        /// Gets the employee leasings for estimate report.
        /// </summary>
        /// <param name="isLeasing">if set to <c>true</c> [is leasing].</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <param name="isCompanyProfile">if set to <c>true</c> [is company profile].</param>
        /// <returns></returns>
        List<EmployeeLeasingEntity> GetEmployeeLeasingsForEstimateReport(bool isLeasing, bool isActive, bool isCompanyProfile);

        /// <summary>
        /// Inserts the employeeLeasing.
        /// </summary>
        /// <param name="employeeLeasing">The employeeLeasing.</param>
        /// <returns></returns>
        int InsertEmployeeLeasing(EmployeeLeasingEntity employeeLeasing);

        /// <summary>
        /// Updates the employeeLeasing.
        /// </summary>
        /// <param name="employeeLeasing">The employeeLeasing.</param>
        /// <returns></returns>
        string UpdateEmployeeLeasing(EmployeeLeasingEntity employeeLeasing);

        /// <summary>
        /// Deletes the employeeLeasing.
        /// </summary>
        /// <param name="employeeLeasing">The employeeLeasing.</param>
        /// <returns></returns>
        string DeleteEmployeeLeasing(EmployeeLeasingEntity employeeLeasing);
    }
}

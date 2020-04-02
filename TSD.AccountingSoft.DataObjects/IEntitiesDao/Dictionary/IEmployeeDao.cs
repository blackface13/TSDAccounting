/***********************************************************************
 * <copyright file="IEmployeeDao.cs" company="BUCA JSC">
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
using TSD.AccountingSoft.BusinessEntities.Dictionary;


namespace TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary
{
    /// <summary>
    /// IEmployeeDao
    /// </summary> 
    public interface IEmployeeDao
    {
        /// <summary>
        /// Gets the employees by department identifier.
        /// </summary>
        /// <param name="isListDepartment">if set to <c>true</c> [is list department].</param>
        /// <param name="departmentId">The department identifier.</param>
        /// <returns></returns>
        IList<EmployeeEntity> GetEmployeesByRefdateSalary(DateTime refdate);
        /// <summary>
        /// Gets the employee.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        EmployeeEntity GetEmployee(int employeeId);

        List<EmployeeEntity> GetEmployeesForSalary(DateTime refDate,string refNo);

        List<EmployeeEntity> GetEmployeesForSalaryInMonthAndRefNo(string refDate, string refNo);

        List<EmployeeEntity> GetEmployeesIsRetail(string monthDate,bool isRetail); 

        /// <summary>
        /// Gets the employees.
        /// </summary>
        /// <returns></returns>
        List<EmployeeEntity> GetEmployees();

        /// <summary>
        /// Gets the employees by department identifier.
        /// </summary>
        /// <param name="departmentId">The department identifier.</param>
        /// <returns></returns>
        List<EmployeeEntity> GetEmployeesByDepartmentId(int departmentId);

        /// <summary>
        /// Gets the active employees by department identifier.
        /// </summary>
        /// <param name="departmentId">The department identifier.</param>
        /// <returns></returns>
        List<EmployeeEntity> GetActiveEmployeesByDepartmentId(int departmentId);

        /// <summary>
        /// Gets the employees by department identifier.
        /// </summary>
        /// <param name="isListDepartment">if set to <c>true</c> [is list department].</param>
        /// <param name="departmentId">The department identifier.</param>
        /// <returns></returns>
        List<EmployeeEntity> GetEmployeesByDepartmentId(bool isListDepartment, string departmentId);


        List<EmployeeEntity> GetEmployeesByDepartmentIdAndMonth(bool isListDepartment, string departmentId,string strDate,int optionType,int calcType);


        /// <summary>
        /// Gets the employees by employee code.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        List<EmployeeEntity> GetEmployeesByEmployeeCode(string employeeId);

        /// <summary>
        /// Gets the employees by active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        List<EmployeeEntity> GetEmployeesByActive(bool isActive);

        /// <summary>
        /// Inserts the employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <returns></returns>
        int InsertEmployee(EmployeeEntity employee);

        /// <summary>
        /// Updates the employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <returns></returns>
        string UpdateEmployee(EmployeeEntity employee);

        /// <summary>
        /// Deletes the employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <returns></returns>
        string DeleteEmployee(EmployeeEntity employee);
    }
}
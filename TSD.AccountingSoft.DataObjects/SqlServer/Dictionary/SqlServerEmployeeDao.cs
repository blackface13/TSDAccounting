/***********************************************************************
 * <copyright file="SqlServerEmployeeDao.cs" company="BUCA JSC">
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
    /// SqlServerEmployeeDao
    /// </summary>
    public class SqlServerEmployeeDao : IEmployeeDao
    {
        /// <summary>
        /// Gets the employee.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        public EmployeeEntity GetEmployee(int employeeId)
        {
            const string sql = @"uspGet_Employee_ByID";

            object[] parms = { "@EmployeeID", employeeId };
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the employees.
        /// </summary>
        /// <returns></returns>
        public List<EmployeeEntity> GetEmployees()
        {
            const string procedures = @"uspGet_All_Employee";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Gets the employees by department identifier.
        /// </summary>
        /// <param name="departmentId">The department identifier.</param>
        /// <returns></returns>
        public List<EmployeeEntity> GetEmployeesByDepartmentId(int departmentId)
        {
            const string procedures = @"uspGet_Employee_ByDeparmentID";

            object[] parms = { "@DepartmentID", departmentId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the employees by department identifier.
        /// </summary>
        /// <param name="departmentId">The department identifier.</param>
        /// <returns></returns>
        public List<EmployeeEntity> GetActiveEmployeesByDepartmentId(int departmentId)
        {
            const string procedures = @"uspGet_Employee_ByIsActiveAndDeparmentID";

            object[] parms = { "@DepartmentID", departmentId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the employees by department identifier.
        /// </summary>
        /// <param name="isListDepartment">if set to <c>true</c> [is list department].</param>
        /// <param name="departmentId">The department identifier.</param>
        /// <returns></returns>
        public List<EmployeeEntity> GetEmployeesByDepartmentId(bool isListDepartment, string departmentId)
        {
            const string procedures = @"uspGet_Employee_ByListDeparmentID";

            object[] parms = { "@DepartmentID", departmentId };
            return Db.ReadList(procedures, true, Make, parms);
        }


        public List<EmployeeEntity> GetEmployeesByDepartmentIdAndMonth(bool isListDepartment, string departmentId, string strDate, int optionType, int calcType)
        {
            const string procedures = @"uspGet_Employee_ByListDeparmentIDAndMonthDate";

            object[] parms = { "@DepartmentID", departmentId, "@MonthDate", strDate, "@OptionType", optionType, "@CalcType", calcType };
            return Db.ReadList(procedures, true, Make, parms);
        }



        /// <summary>
        /// Gets the employees by employee code.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        public List<EmployeeEntity> GetEmployeesByEmployeeCode(string employeeId)
        {
            const string procedures = @"uspGet_Employee_ByEmployeeCode";

            object[] parms = { "@EmployeeCode", employeeId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the employees by active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        public List<EmployeeEntity> GetEmployeesByActive(bool isActive)
        {
            const string procedures = @"uspGet_Employee_IsActive";

            object[] parms = { "@IsActive", isActive };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the employees for salary.
        /// </summary>
        /// <param name="refDate">The reference date.</param>
        /// <returns></returns>
        public List<EmployeeEntity> GetEmployeesForSalary(DateTime refDate, string refNo)
        {
            const string procedures = @"uspGet_Employee_ByEmployeePayroll";

            object[] parms = { "@RefDate", refDate, "@RefNo", refNo };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Inserts the employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <returns></returns>
        public int InsertEmployee(EmployeeEntity employee)
        {
            const string sql = @"uspInsert_Employee";
            return Db.Insert(sql, true, Take(employee));
        }

        /// <summary>
        /// Updates the employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <returns></returns>
        public string UpdateEmployee(EmployeeEntity employee)
        {
            const string sql = @"uspUpdate_Employee";
            return Db.Update(sql, true, Take(employee));
        }

        /// <summary>
        /// Deletes the employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <returns></returns>
        public string DeleteEmployee(EmployeeEntity employee)
        {
            const string sql = @"uspDelete_Employee";

            object[] parms = { "@EmployeeID", employee.EmployeeId };
            return Db.Delete(sql, true, parms);
        }

        public List<EmployeeEntity> GetEmployeesForSalaryInMonthAndRefNo(string refDate, string refNo)
        {
            const string procedures = @"uspGet_Employee_ByEmployeePayrollAndRefNoMonthDate";
            object[] parms = { "@RefDate", Convert.ToDateTime(refDate), "@RefNo", refNo };
            return Db.ReadList(procedures, true, Make, parms);
        }

        public List<EmployeeEntity> GetEmployeesIsRetail(string monthDate, bool isRetail)
        {
            const string procedures = @"uspGet_Employee_ByEmployeePayrollIsRetail";
            object[] parms = { "@PostedDate", monthDate, "@IsRetail", isRetail };
            return Db.ReadList(procedures, true, Make, parms);
        }


        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, EmployeeEntity> Make = reader =>
        {
            var employee = new EmployeeEntity();
            employee.EmployeeId = reader["EmployeeID"].AsInt();
            employee.EmployeeCode = reader["EmployeeCode"].AsString();
            employee.EmployeeName = reader["EmployeeName"].AsString();
            employee.JobCandidateName = reader["JobCandidateName"].AsString();
            employee.SortOrder = reader["SortOrder"].AsInt();
            employee.BirthDate = reader["BirthDate"].AsString().AsDateTimeForNull();
            employee.TypeOfSalary = reader["TypeOfSalary"].AsInt();
            employee.Sex = reader["Sex"].AsBool();
            employee.LevelOfSalary = reader["LevelOfSalary"].AsString();
            employee.DepartmentId = reader["DepartmentID"].AsString().AsIntForNull();
            employee.CurrencyCode = reader["CurrencyCode"].AsString();
            employee.IdentityNo = reader["IdentityNo"].AsString();
            employee.IssueDate = reader["IssueDate"].AsString().AsDateTimeForNull();
            employee.IssueBy = reader["IssueBy"].AsString();
            employee.IsActive = reader["IsActive"].AsBool();
            employee.Description = reader["Description"].AsString();
            employee.PhoneNumber = reader["PhoneNumber"].AsString();
            employee.Address = reader["Address"].AsString();
            employee.IsOffice = reader["IsOffice"].AsBool();
            employee.RetiredDate = reader["RetiredDate"].AsString().AsDateTimeForNull();
            employee.StartingDate = reader["StartingDate"].AsString().AsDateTimeForNull();

            return employee;
        };

        /// <summary>
        /// Takes the specified employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <returns></returns>
        private static object[] Take(EmployeeEntity employee)
        {
            return new object[]
            {
                "@EmployeeID", employee.EmployeeId,
                "@EmployeeCode", employee.EmployeeCode,
                "@EmployeeName", employee.EmployeeName,
                "@JobCandidateName", employee.JobCandidateName,
                "@SortOrder", employee.SortOrder,
                "@BirthDate", employee.BirthDate,
                "@TypeOfSalary", employee.TypeOfSalary,
                "@Sex", employee.Sex,
                "@LevelOfSalary", employee.LevelOfSalary,
                "@DepartmentID", employee.DepartmentId,
                "@CurrencyCode", employee.CurrencyCode,
                "@IdentityNo", employee.IdentityNo,
                "@IssueDate", employee.IssueDate,
                "@IssueBy", employee.IssueBy,
                "@IsActive", employee.IsActive,
                "@Description", employee.Description,
                "@PhoneNumber", employee.PhoneNumber,
                "@Address", employee.Address,
                "@StartingDate", employee.StartingDate,
                "@RetiredDate", employee.RetiredDate,
                "@IsOffice", employee.IsOffice
            };
        }

        public IList<EmployeeEntity> GetEmployeesByRefdateSalary(DateTime refdate)
        {
            throw new NotImplementedException();
        }





    }
}
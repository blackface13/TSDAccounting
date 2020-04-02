/***********************************************************************
 * <copyright file="SqlServerEmployeeLeasingDao.cs" company="BUCA JSC">
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

using System;
using System.Collections.Generic;
using System.Data;
using TSD.AccountingSoft.BusinessEntities.Dictionary;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary;
using TSD.AccountingSoft.DataHelpers;


namespace TSD.AccountingSoft.DataAccess.SqlServer.Dictionary
{
    /// <summary>
    /// SqlServerEmployeeLeasingDao
    /// </summary>
    public class SqlServerEmployeeLeasingDao : IEmployeeLeasingDao
    {
        /// <summary>
        /// Gets the employeeLeasing.
        /// </summary>
        /// <param name="employeeLeasingId">The employeeLeasing identifier.</param>
        /// <returns></returns>
        public EmployeeLeasingEntity GetEmployeeLeasing(int employeeLeasingId)
        {
            const string sql = @"uspGet_EmployeeLeasing_ByID";

            object[] parms = { "@EmployeeLeasingID", employeeLeasingId };
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the employeeLeasings.
        /// </summary>
        /// <returns></returns>
        public List<EmployeeLeasingEntity> GetEmployeeLeasings()
        {
            const string procedures = @"uspGet_All_EmployeeLeasing";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Gets the employee leasings.
        /// </summary>
        /// <param name="isLeasing">if set to <c>true</c> [is leasing].</param>
        /// <returns></returns>
        public List<EmployeeLeasingEntity> GetEmployeeLeasings(bool isLeasing)
        {
            const string procedures = @"uspGet_EmployeeLeasing_ByIsLeasing";

            object[] parms = { "@IsLeasing", isLeasing };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the employeeLeasings by employeeLeasing code.
        /// </summary>
        /// <param name="employeeLeasingCode">The employeeLeasing code.</param>
        /// <returns></returns>
        public List<EmployeeLeasingEntity> GetEmployeeLeasingsByEmployeeLeasingCode(string employeeLeasingCode)
        {
            const string sql = @"uspGet_EmployeeLeasing_ByEmployeeLeasingCode";

            object[] parms = { "@EmployeeLeasingCode", employeeLeasingCode };
            return Db.ReadList(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the employeeLeasings by active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        public List<EmployeeLeasingEntity> GetEmployeeLeasingsByActive(bool isActive)
        {
            const string sql = @"uspGet_EmployeeLeasing_IsActive";

            object[] parms = { "@IsActive", isActive };
            return Db.ReadList(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the employee leasings by active.
        /// </summary>
        /// <param name="isLeasing">if set to <c>true</c> [is leasing].</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        public List<EmployeeLeasingEntity> GetEmployeeLeasingsByActive(bool isLeasing, bool isActive)
        {
            const string sql = @"uspGet_EmployeeLeasing_ByIsLeasingAndIsActive";

            object[] parms = { "@IsLeasing", isLeasing, "@IsActive", isActive };
            return Db.ReadList(sql, true, Make, parms);
        }

        /// <summary>
        /// Gets the employee leasings by active.
        /// </summary>
        /// <param name="isLeasing">if set to <c>true</c> [is leasing].</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <param name="isCompanyProfile">if set to <c>true</c> [is company profile].</param>
        /// <returns></returns>
        public List<EmployeeLeasingEntity> GetEmployeeLeasingsForEstimateReport(bool isLeasing, bool isActive, bool isCompanyProfile)
        {
            string sql;
            if (isCompanyProfile)
            {
                sql = @"uspGet_EmployeeLeasing_ForEstimateReportByCompanyProfile";
            }
            else
            {
                 sql = @"uspGet_EmployeeLeasing_ForEstimateReport";
            }
            
            object[] parms = { "@IsLeasing", isLeasing, "@IsActive", isActive };
            return Db.ReadList(sql, true, MakeForEstimateReport, parms);
        }

        /// <summary>
        /// Inserts the employeeLeasing.
        /// </summary>
        /// <param name="employeeLeasing">The employeeLeasing.</param>
        /// <returns></returns>
        public int InsertEmployeeLeasing(EmployeeLeasingEntity employeeLeasing)
        {
            const string sql = @"uspInsert_EmployeeLeasing";
            return Db.Insert(sql, true, Take(employeeLeasing));
        }

        /// <summary>
        /// Updates the employeeLeasing.
        /// </summary>
        /// <param name="employeeLeasing">The employeeLeasing.</param>
        /// <returns></returns>
        public string UpdateEmployeeLeasing(EmployeeLeasingEntity employeeLeasing)
        {
            const string sql = @"uspUpdate_EmployeeLeasing";
            return Db.Update(sql, true, Take(employeeLeasing));
        }

        /// <summary>
        /// Deletes the employeeLeasing.
        /// </summary>
        /// <param name="employeeLeasing">The employeeLeasing.</param>
        /// <returns></returns>
        public string DeleteEmployeeLeasing(EmployeeLeasingEntity employeeLeasing)
        {
            const string sql = @"uspDelete_EmployeeLeasing";

            object[] parms = { "@EmployeeLeasingId", employeeLeasing.EmployeeLeasingId };
            return Db.Delete(sql, true, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, EmployeeLeasingEntity> Make = reader =>
            new EmployeeLeasingEntity
            {
                EmployeeLeasingId = reader["EmployeeLeasingID"].AsInt(),
                EmployeeLeasingCode = reader["EmployeeLeasingCode"].AsString(),
                EmployeeLeasingName = reader["EmployeeLeasingName"].AsString(),
                JobCandidate = reader["JobCandidate"].AsString(),
                Description = reader["Description"].AsString(),
                StartDate = reader["StartDate"].AsDateTime(),
                EndDate = reader["EndDate"].AsDateTime(),
                IsActive = reader["IsActive"].AsBool(),
                IsLeasing = reader["IsLeasing"].AsBool(),
                SalaryPrice = reader["SalaryPrice"].AsDecimal(),
                InsurancePrice = reader["InsurancePrice"].AsDecimal(),
                UniformPrice = reader["UniformPrice"].AsDecimal()
            };

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, EmployeeLeasingEntity> MakeForEstimateReport = reader =>
            new EmployeeLeasingEntity
            {
                OrderNumber = reader["ID"].AsInt(),
                EmployeeLeasingId = reader["EmployeeLeasingID"].AsInt(),
                EmployeeLeasingCode = reader["EmployeeLeasingCode"].AsString(),
                EmployeeLeasingName = reader["EmployeeLeasingName"].AsString(),
                JobCandidate = reader["JobCandidate"].AsString(),
                Description = reader["Description"].AsString(),
                StartDate = reader["StartDate"].AsDateTime(),
                EndDate = reader["EndDate"].AsDateTime(),
                IsActive = reader["IsActive"].AsBool(),
                IsLeasing = reader["IsLeasing"].AsBool(),
                SalaryPrice = reader["SalaryPrice"].AsDecimal(),
                InsurancePrice = reader["InsurancePrice"].AsDecimal(),
                UniformPrice = reader["UniformPrice"].AsDecimal()
            };

        /// <summary>
        /// Takes the specified employee leasing.
        /// </summary>
        /// <param name="employeeLeasing">The employee leasing.</param>
        /// <returns></returns>
        private static object[] Take(EmployeeLeasingEntity employeeLeasing)
        {
            return new object[]  
            {
                "@EmployeeLeasingID", employeeLeasing.EmployeeLeasingId,
                "@EmployeeLeasingCode", employeeLeasing.EmployeeLeasingCode,
                "@EmployeeLeasingName", employeeLeasing.EmployeeLeasingName,
                "@Description", employeeLeasing.Description,
                "@JobCandidate", employeeLeasing.JobCandidate,
                "@StartDate", employeeLeasing.StartDate,
                "@EndDate", employeeLeasing.EndDate,
                "@IsActive", employeeLeasing.IsActive,
                "@IsLeasing", employeeLeasing.IsLeasing,
                "@SalaryPrice", employeeLeasing.SalaryPrice,
                "@InsurancePrice", employeeLeasing.InsurancePrice,
                "@UniformPrice", employeeLeasing.UniformPrice
            };
        }
    }
}

/***********************************************************************
 * <copyright file="EmployeeFacade.cs" company="BUCA JSC">
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
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Transactions;
using TSD.AccountingSoft.BusinessComponents.Messages.Dictionary;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary;
using TSD.AccountingSoft.BusinessEntities.Dictionary;


namespace TSD.AccountingSoft.BusinessComponents.Facade.Dictionary
{
    /// <summary>
    /// EmployeeFacade
    /// </summary>
    public class EmployeeFacade
    {
        private static readonly IEmployeeDao EmployeeDao = DataAccess.DataAccess.EmployeeDao;
        private static readonly IEmployeePayItemDao EmployeePayItemDao = DataAccess.DataAccess.EmployeePayItemDao;
        private static readonly IAutoNumberListDao AutoNumberListDao = DataAccess.DataAccess.AutoNumberListDao;

        /// <summary>
        /// Gets the employees.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public EmployeeResponse GetEmployees(EmployeeRequest request)
        {
            var response = new EmployeeResponse();

            if (request.LoadOptions.Contains("Employees"))
            {
                if (request.LoadOptions.Contains("Department"))
                {
                    if (request.LoadOptions.Contains("ListId"))
                    {
                        if (request.LoadOptions.Contains("MonthDate"))
                        {
                            string[] stringSeparators = new string[] { "," };
                            string[] lstDepartment = request.ListDepartmentId.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                            List<EmployeeEntity> lstEmployee = new List<EmployeeEntity>();
                            foreach (string department in lstDepartment)
                            {
                                List<EmployeeEntity> lstgetEmployee = EmployeeDao.GetEmployeesByDepartmentIdAndMonth(true, department,request.MonthDate,request.OptionType,request.CalceType);
                                 if (lstgetEmployee.Count>0)
                                 {
                                     foreach(var it in lstgetEmployee )
                                     {
                                         lstEmployee.Add(it);
                                     }
                                 }
                            }

                            response.Employees = lstEmployee;
                        }
                        else
                             response.Employees = EmployeeDao.GetEmployeesByDepartmentId(true, request.ListDepartmentId);
                    }
                    else
                    {
                        if (request.LoadOptions.Contains("IsActive"))
                            response.Employees = EmployeeDao.GetActiveEmployeesByDepartmentId(request.DepartmentId);
                        else
                            response.Employees = EmployeeDao.GetEmployeesByDepartmentId(request.DepartmentId);
                    }
                }
                else
                {
                    if (request.LoadOptions.Contains("RefdateSalary"))
                    {
                        response.Employees = EmployeeDao.GetEmployeesForSalary(request.RefdateSalary, request.RefNo);
                    }
                    else
                    {
                        if (request.LoadOptions.Contains("IsActive"))
                            response.Employees = EmployeeDao.GetEmployeesByActive(true);
                        else
                            response.Employees = EmployeeDao.GetEmployees();
                    }
                    if (request.LoadOptions.Contains("RefNoAndMonthDate"))//Lấy các nhân viên theo số chứng từ lương
                    {
                        response.Employees = EmployeeDao.GetEmployeesForSalaryInMonthAndRefNo(request.MonthDate, request.RefNo);
                    }

                    if (request.LoadOptions.Contains("IsRetailEmployeePayroll"))//Lấy các nhân viên theo số chứng từ lương
                    {
                        response.Employees = EmployeeDao.GetEmployeesIsRetail(request.MonthDate, request.IsRetail);
                    }


                }

                
            }
            if (request.LoadOptions.Contains("Employee"))
            {
                response.Employee = EmployeeDao.GetEmployee(request.EmployeeId);
                if (request.LoadOptions.Contains("EmployeePayItem"))
                    response.Employee.EmployeePayItems = EmployeePayItemDao.GetEmployeePayItemsByEmployeeId(request.EmployeeId);

                if (request.LoadOptions.Contains("EmployeeForEditPayItem"))
                    response.Employee.EmployeePayItems = EmployeePayItemDao.GetEmployeeForEditPayItemsByEmployeeId(request.EmployeeId);

                if (request.LoadOptions.Contains("ViewSalaryEmployeePayItem"))
                    response.Employee.EmployeePayItems = EmployeePayItemDao.GetEmployeeForViewtEmployeePayItem(request.EmployeeId, request.RefdateSalary, request.ExchangeRate);
            }

            return response;
        }

        /// <summary>
        /// Sets the employees.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public EmployeeResponse SetEmployees(EmployeeRequest request)
        {
            var response = new EmployeeResponse();

            var employeeEntity = request.Employee;
            if (request.Action != PersistType.Delete)
            {
                if (!employeeEntity.Validate())
                {
                    foreach (string error in employeeEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
            }
            try
            {
                if (request.Action == PersistType.Insert)
                {
                    using (var scope = new TransactionScope())
                    {
                        var employees = EmployeeDao.GetEmployeesByEmployeeCode(employeeEntity.EmployeeCode);
                        if (employees.Count > 0)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            response.Message = @"Mã nhân viên " + employeeEntity.EmployeeCode + @" đã tồn tại !";
                            return response;
                        }
                        AutoNumberListDao.UpdateIncreateAutoNumberListByValue("Employee");
                        employeeEntity.EmployeeId = EmployeeDao.InsertEmployee(employeeEntity);
                        if (employeeEntity.EmployeeId == 0)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            return response;
                        }
                        if (employeeEntity.EmployeePayItems.Count > 0)
                        {
                            foreach (var employeePayItem in employeeEntity.EmployeePayItems)
                            {
                                employeePayItem.EmployeeId = employeeEntity.EmployeeId;
                                var employeePayItemId = EmployeePayItemDao.InsertEmployeePayItem(employeePayItem);
                                if (employeePayItemId != 0) continue;
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }
                        }
                        response.Message = null;
                        scope.Complete();
                    }
                }
                else if (request.Action == PersistType.Update)
                {
                    using (var scope = new TransactionScope())
                    {
                        var message = EmployeeDao.UpdateEmployee(employeeEntity);
                        if (message != null)
                        {
                            response.Message = message;
                            response.Acknowledge = AcknowledgeType.Failure;
                            return response;
                        }
                        //message = EmployeePayItemDao.DeleteEmployeePayItemByEmployeeId(employeeEntity.EmployeeId);
                        //if (message != null)
                        //{
                        //    response.Message = message;
                        //    response.Acknowledge = AcknowledgeType.Failure;
                        //    return response;
                        //}


                        message = EmployeePayItemDao.DeleteEditEmployeePayItemByEmployeeId(employeeEntity.EmployeeId);
                        if (message != null)
                        {
                            response.Message = message;
                            response.Acknowledge = AcknowledgeType.Failure;
                            return response;
                        }

                        if (employeeEntity.EmployeePayItems.Count > 0)
                        {
                            foreach (var employeePayItem in employeeEntity.EmployeePayItems)
                            {
                                employeePayItem.EmployeeId = employeeEntity.EmployeeId;
                                var employeePayItemId = EmployeePayItemDao.InsertEmployeePayItem(employeePayItem);
                                if (employeePayItemId != 0) continue;
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }
                        }
                        scope.Complete();
                    }
                }
                else
                {
                    var employeeForUpdate = EmployeeDao.GetEmployee(request.EmployeeId);
                    response.Message = EmployeeDao.DeleteEmployee(employeeForUpdate);
                }
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
            response.EmployeeId = employeeEntity != null ? employeeEntity.EmployeeId : 0;
            if (response.Message == null)
            {
                response.Acknowledge = AcknowledgeType.Success;
                response.RowsAffected = 1;
            }
            else
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.RowsAffected = 0;
            }

            return response;
        }
    }
}
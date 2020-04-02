/***********************************************************************
 * <copyright file="EmployeePresenter.cs" company="BUCA JSC">
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

using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.View.Dictionary;
using System;


namespace TSD.AccountingSoft.Presenter.Dictionary.Employee
{
    /// <summary>
    /// EmployeePresenter
    /// </summary>
    public class EmployeePresenter : Presenter<IEmployeeView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeePresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public EmployeePresenter(IEmployeeView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays the specified employee identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        public void Display(string employeeId)
        {
            if (employeeId == null) { View.EmployeeId = 0; return; }

            var employee = Model.GetEmployee(int.Parse(employeeId));

            View.EmployeeId = employee.EmployeeId;
            View.EmployeeCode = employee.EmployeeCode;
            View.EmployeeName = employee.EmployeeName;
            View.JobCandidateName = employee.JobCandidateName;
            View.SortOrder = employee.SortOrder;
            View.BirthDate = employee.BirthDate;
            View.TypeOfSalary = employee.TypeOfSalary;
            View.Sex = employee.Sex;
            View.LevelOfSalary = employee.LevelOfSalary;
            View.DepartmentId = employee.DepartmentId;
            View.CurrencyCode = employee.CurrencyCode;
            View.IdentityNo = employee.IdentityNo;
            View.IssueDate = employee.IssueDate;
            View.IssueBy = employee.IssueBy;
            View.IsActive = employee.IsActive;
            View.Description = employee.Description;
            View.PhoneNumber = employee.PhoneNumber;
            View.Address = employee.Address;
            View.RetiredDate = employee.RetiredDate;
            View.StartingDate = employee.StartingDate;
            View.IsOffice = employee.IsOffice;
            View.EmployeePayItems = employee.EmployeePayItems;
        }


        public void DisplayEdit(string employeeId)
        {
            if (employeeId == null) { View.EmployeeId = 0; return; }

            var employee = Model.GetEmployeeForEdit(int.Parse(employeeId));
            View.EmployeeId = employee.EmployeeId;
            View.EmployeeCode = employee.EmployeeCode;
            View.EmployeeName = employee.EmployeeName;
            View.JobCandidateName = employee.JobCandidateName;
            View.SortOrder = employee.SortOrder;
            View.BirthDate = employee.BirthDate;
            View.TypeOfSalary = employee.TypeOfSalary;
            View.Sex = employee.Sex;
            View.LevelOfSalary = employee.LevelOfSalary;
            View.DepartmentId = employee.DepartmentId;
            View.CurrencyCode = employee.CurrencyCode;
            View.IdentityNo = employee.IdentityNo;
            View.IssueDate = employee.IssueDate;
            View.IssueBy = employee.IssueBy;
            View.IsActive = employee.IsActive;
            View.Description = employee.Description;
            View.PhoneNumber = employee.PhoneNumber;
            View.Address = employee.Address;
            View.RetiredDate = employee.RetiredDate;
            View.StartingDate = employee.StartingDate;
            View.EmployeePayItems = employee.EmployeePayItems;
            View.IsOffice = employee.IsOffice;
        }


        /// <summary>
        /// Hiện thi danh mục các khoản lương trên sinh hoạt phí
        /// </summary>
        /// <param name="employeeId">nhân viên</param>
        /// <param name="refDate">ngày tính lương</param>

        public void Display(string employeeId, DateTime refDate, decimal exchangeRate)
        {
            if (employeeId == null) { View.EmployeeId = 0; return; }

            var employee = Model.GetEmployeeForViewSalary(int.Parse(employeeId), refDate, exchangeRate);
            View.EmployeeId = employee.EmployeeId;
            View.EmployeeCode = employee.EmployeeCode;
            View.EmployeeName = employee.EmployeeName;
            View.JobCandidateName = employee.JobCandidateName;
            View.SortOrder = employee.SortOrder;
            View.BirthDate = employee.BirthDate;
            View.TypeOfSalary = employee.TypeOfSalary;
            View.Sex = employee.Sex;
            View.LevelOfSalary = employee.LevelOfSalary;
            View.DepartmentId = employee.DepartmentId;
            View.CurrencyCode = employee.CurrencyCode;
            View.IdentityNo = employee.IdentityNo;
            View.IssueDate = employee.IssueDate;
            View.IssueBy = employee.IssueBy;
            View.IsActive = employee.IsActive;
            View.Description = employee.Description;
            View.PhoneNumber = employee.PhoneNumber;
            View.Address = employee.Address;
            View.RetiredDate = employee.RetiredDate;
            View.StartingDate = employee.StartingDate;
            View.EmployeePayItems = employee.EmployeePayItems;

        }










        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        public int Save()
        {
            var employee = new EmployeeModel
            {
                EmployeeId = View.EmployeeId,
                EmployeeCode = View.EmployeeCode,
                EmployeeName = View.EmployeeName,
                JobCandidateName = View.JobCandidateName,
                SortOrder = View.SortOrder,
                BirthDate = View.BirthDate,
                TypeOfSalary = View.TypeOfSalary,
                Sex = View.Sex,
                LevelOfSalary = View.LevelOfSalary,
                DepartmentId = View.DepartmentId,
                CurrencyCode = View.CurrencyCode,
                IdentityNo = View.IdentityNo,
                IssueDate = View.IssueDate,
                IssueBy = View.IssueBy,
                IsActive = View.IsActive,
                Description = View.Description,
                Address = View.Address,
                PhoneNumber = View.PhoneNumber,
                RetiredDate = View.RetiredDate,
                StartingDate = View.StartingDate,
                IsOffice = View.IsOffice,
                EmployeePayItems = View.EmployeePayItems
            };

            return View.EmployeeId == 0 ? Model.AddEmployee(employee) : Model.UpdateEmployee(employee);
        }

        /// <summary>
        /// Deletes the specified account identifier.
        /// </summary>
        /// <param name="accountId">The account identifier.</param>
        /// <returns></returns>
        public int Delete(int accountId)
        {
            return Model.DeleteEmployee(accountId);
        }
    }
}

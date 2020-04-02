/***********************************************************************
 * <copyright file="IEmployeeView.cs" company="BUCA JSC">
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
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;


namespace TSD.AccountingSoft.View.Dictionary
{
    /// <summary>
    /// IEmployeeView
    /// </summary>
    public interface IEmployeeView : IView
    {
        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>
        /// The employee identifier.
        /// </value>
        int EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets the employee code.
        /// </summary>
        /// <value>
        /// The employee code.
        /// </value>
        string EmployeeCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the employee.
        /// </summary>
        /// <value>
        /// The name of the employee.
        /// </value>
        string EmployeeName { get; set; }

        /// <summary>
        /// Gets or sets the name of the job candidate.
        /// </summary>
        /// <value>
        /// The name of the job candidate.
        /// </value>
        string JobCandidateName { get; set; }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        /// <value>
        /// The sort order.
        /// </value>
        int SortOrder { get; set; }

        /// <summary>
        /// Gets or sets the birth date.
        /// </summary>
        /// <value>
        /// The birth date.
        /// </value>
        string BirthDate { get; set; }

        /// <summary>
        /// Gets or sets the type of salary.
        /// </summary>
        /// <value>
        /// The type of salary.
        /// </value>
        int TypeOfSalary { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [sex].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [sex]; otherwise, <c>false</c>.
        /// </value>
        bool Sex { get; set; }

        /// <summary>
        /// Gets or sets the level of salary.
        /// </summary>
        /// <value>
        /// The level of salary.
        /// </value>
        string LevelOfSalary { get; set; }

        /// <summary>
        /// Gets or sets the department identifier.
        /// </summary>
        /// <value>
        /// The department identifier.
        /// </value>
        int? DepartmentId { get; set; }

        /// <summary>
        /// Gets or sets the currency code.
        /// </summary>
        /// <value>
        /// The currency code.
        /// </value>
        string CurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets the identity no.
        /// </summary>
        /// <value>
        /// The identity no.
        /// </value>
        string IdentityNo { get; set; }

        /// <summary>
        /// Gets or sets the issue date.
        /// </summary>
        /// <value>
        /// The issue date.
        /// </value>
        string IssueDate { get; set; }

        /// <summary>
        /// Gets or sets the issue by.
        /// </summary>
        /// <value>
        /// The issue by.
        /// </value>
        string IssueBy { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is active].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is active]; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        string Description { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        string Address { get; set; }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        /// <value>
        /// The phone number.
        /// </value>
        string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the retired date.
        /// </summary>
        /// <value>
        /// The retired date.
        /// </value>
        string RetiredDate { get; set; }

        /// <summary>
        /// Gets or sets the starting date.
        /// </summary>
        /// <value>
        /// The starting date.
        /// </value>
        string StartingDate { get; set; }

        /// <summary>
        /// Gets or sets the employee pay items.
        /// </summary>
        /// <value>
        /// The employee pay items.
        /// </value>

        bool IsOffice { get; set; }

        IList<EmployeePayItemModel> EmployeePayItems { get; set; }
    }
}
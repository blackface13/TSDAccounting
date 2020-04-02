/***********************************************************************
 * <copyright file="EmployeeModel.cs" company="BUCA JSC">
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


namespace TSD.AccountingSoft.Model.BusinessObjects.Dictionary
{
    /// <summary>
    /// EmployeeModel
    /// </summary>
    public class EmployeeModel
    {
        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>
        /// The employee identifier.
        /// </value>
        public int EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets the employee code.
        /// </summary>
        /// <value>
        /// The employee code.
        /// </value>
        public string EmployeeCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the employee.
        /// </summary>
        /// <value>
        /// The name of the employee.
        /// </value>
        public string EmployeeName { get; set; }

        /// <summary>
        /// Gets or sets the name of the job candidate.
        /// </summary>
        /// <value>
        /// The name of the job candidate.
        /// </value>
        public string JobCandidateName { get; set; }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        /// <value>
        /// The sort order.
        /// </value>
        public int SortOrder { get; set; }

        /// <summary>
        /// Gets or sets the birth date.
        /// </summary>
        /// <value>
        /// The birth date.
        /// </value>
        public string BirthDate { get; set; }

        /// <summary>
        /// Gets or sets the type of salary.
        /// </summary>
        /// <value>
        /// The type of salary.
        /// </value>
        public int TypeOfSalary { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [sex].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [sex]; otherwise, <c>false</c>.
        /// </value>
        public bool Sex { get; set; }

        /// <summary>
        /// Gets or sets the level of salary.
        /// </summary>
        /// <value>
        /// The level of salary.
        /// </value>
        public string LevelOfSalary { get; set; }

        /// <summary>
        /// Gets or sets the department identifier.
        /// </summary>
        /// <value>
        /// The department identifier.
        /// </value>
        public int? DepartmentId { get; set; }

        /// <summary>
        /// Gets or sets the currency code.
        /// </summary>
        /// <value>
        /// The currency code.
        /// </value>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets the identity no.
        /// </summary>
        /// <value>
        /// The identity no.
        /// </value>
        public string IdentityNo { get; set; }

        /// <summary>
        /// Gets or sets the issue date.
        /// </summary>
        /// <value>
        /// The issue date.
        /// </value>
        public string IssueDate { get; set; }

        /// <summary>
        /// Gets or sets the issue by.
        /// </summary>
        /// <value>
        /// The issue by.
        /// </value>
        public string IssueBy { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is active].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is active]; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        /// <value>
        /// The phone number.
        /// </value>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the retired date.
        /// </summary>
        /// <value>
        /// The retired date.
        /// </value>
        public string RetiredDate { get; set; }

        /// <summary>
        /// Gets or sets the starting date.
        /// </summary>
        /// <value>
        /// The starting date.
        /// </value>
        public string StartingDate { get; set; }

        /// <summary>
        /// Gets or sets the employee pay items.
        /// </summary>
        /// <value>
        /// The employee pay items.
        /// </value>
        public bool IsOffice { get; set; }
        public IList<EmployeePayItemModel> EmployeePayItems { get; set; }
    }
}
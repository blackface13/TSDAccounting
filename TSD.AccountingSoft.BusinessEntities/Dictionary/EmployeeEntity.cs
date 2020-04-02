/***********************************************************************
 * <copyright file="EmployeeEntity.cs" company="BUCA JSC">
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
using TSD.AccountingSoft.BusinessEntities.BusinessRules;
using System;


namespace TSD.AccountingSoft.BusinessEntities.Dictionary
{
    /// <summary>
    /// EmployeeEntity
    /// </summary>
    public class EmployeeEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeEntity"/> class.
        /// </summary>
        public EmployeeEntity()
        {
            AddRule(new ValidateRequired("EmployeeCode"));
            AddRule(new ValidateRequired("EmployeeName"));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeEntity"/> class.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="employeeCode">The employee code.</param>
        /// <param name="employeeName">Name of the employee.</param>
        /// <param name="jobCandidateName">Name of the job candidate.</param>
        /// <param name="sortOrder">The sort order.</param>
        /// <param name="birthDate">The birth date.</param>
        /// <param name="typeOfSalary">The type of salary.</param>
        /// <param name="sex">if set to <c>true</c> [sex].</param>
        /// <param name="levelOfSalary">The level of salary.</param>
        /// <param name="departmentId">The department identifier.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="identityNo">The identity no.</param>
        /// <param name="issueDate">The issue date.</param>
        /// <param name="issueBy">The issue by.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <param name="description">The description.</param>
        /// <param name="phoneNumber">The phone number.</param>
        /// <param name="address">The address.</param>
        /// <param name="retireDate">The retire date.</param>
        /// <param name="startingDate">The starting date.</param>
        public EmployeeEntity(int employeeId, string employeeCode, string employeeName, string jobCandidateName, int sortOrder, DateTime birthDate, int typeOfSalary, bool sex,
            string levelOfSalary, int departmentId, string currencyCode, string identityNo, DateTime issueDate, string issueBy, bool isActive, string description, string phoneNumber,
            string address, DateTime? retireDate, DateTime? startingDate)
            : this()
        {
            EmployeeId = employeeId;
            EmployeeCode = employeeCode;
            EmployeeName = employeeName;
            JobCandidateName = jobCandidateName;
            SortOrder = sortOrder;
            BirthDate = birthDate;
            TypeOfSalary = typeOfSalary;
            Sex = sex;
            LevelOfSalary = levelOfSalary;
            DepartmentId = departmentId;
            CurrencyCode = currencyCode;
            IdentityNo = identityNo;
            IssueDate = issueDate;
            IssueBy = issueBy;
            IsActive = isActive;
            Description = description;
            PhoneNumber = phoneNumber;
            Address = address;
            RetiredDate = retireDate;
            StartingDate = startingDate;
        }

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
        public DateTime? BirthDate { get; set; }

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
        /// Gets or sets the currency identifier.
        /// </summary>
        /// <value>
        /// The currency identifier.
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
        public DateTime? IssueDate { get; set; }

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
        public DateTime? RetiredDate { get; set; }

        /// <summary>
        /// Gets or sets the starting date.
        /// </summary>
        /// <value>
        /// The starting date.
        /// </value>
        public DateTime? StartingDate { get; set; }

        /// <summary>
        /// Gets or sets the employee pay items.
        /// </summary>
        /// <value>
        /// The employee pay items.
        /// </value>
        public bool IsOffice { get; set; }
        public IList<EmployeePayItemEntity> EmployeePayItems { get; set; }
    }
}

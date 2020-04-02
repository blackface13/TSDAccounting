/***********************************************************************
 * <copyright file="EmployeeLeasing.cs" company="BUCA JSC">
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
using TSD.AccountingSoft.BusinessEntities.BusinessRules;

namespace TSD.AccountingSoft.BusinessEntities.Dictionary
{
    /// <summary>
    /// EmployeeLeasing
    /// </summary>
    public class EmployeeLeasingEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeLeasingEntity"/> class.
        /// </summary>
        public EmployeeLeasingEntity()
        {
            AddRule(new ValidateRequired("EmployeeLeasingName"));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeLeasingEntity"/> class.
        /// </summary>
        /// <param name="orderNumber">The order number.</param>
        /// <param name="empDloyeeLeasingId">The emp dloyee leasing identifier.</param>
        /// <param name="employeeLeasingCode">The employee leasing code.</param>
        /// <param name="employeeLeasingName">Name of the employee leasing.</param>
        /// <param name="jobCandidate">The job candidate.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <param name="description">The description.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <param name="isLeasing">if set to <c>true</c> [is leasing].</param>
        /// <param name="salaryPrice">The salary price.</param>
        /// <param name="insurancePrice">The insurance price.</param>
        /// <param name="uniformPrice">The uniform price.</param>
        public EmployeeLeasingEntity(int orderNumber, int empDloyeeLeasingId, string employeeLeasingCode, string employeeLeasingName, string jobCandidate, 
            DateTime startDate, DateTime endDate, string description, bool isActive, bool isLeasing, decimal salaryPrice, decimal insurancePrice, decimal uniformPrice)
            : this()
        {
            OrderNumber = orderNumber;
            EmployeeLeasingId = empDloyeeLeasingId;
            EmployeeLeasingCode = employeeLeasingCode;
            EmployeeLeasingName = employeeLeasingName;
            JobCandidate = jobCandidate;
            StartDate = startDate;
            EndDate = endDate;
            Description = description;
            IsActive = isActive;
            IsLeasing = isLeasing;
            SalaryPrice = salaryPrice;
            InsurancePrice = insurancePrice;
            UniformPrice = uniformPrice;
        }

        /// <summary>
        /// Gets or sets the order number.
        /// </summary>
        /// <value>
        /// The order number.
        /// </value>
        public int OrderNumber { get; set; }

        /// <summary>
        /// Gets or sets the employee leasing identifier.
        /// </summary>
        /// <value>
        /// The employee leasing identifier.
        /// </value>
        public int EmployeeLeasingId { get; set; }

        /// <summary>
        /// Gets or sets the employee leasing code.
        /// </summary>
        /// <value>
        /// The employee leasing code.
        /// </value>
        public string EmployeeLeasingCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the employee leasing.
        /// </summary>
        /// <value>
        /// The name of the employee leasing.
        /// </value>
        public string EmployeeLeasingName { get; set; }

        /// <summary>
        /// Gets or sets the job candidate.
        /// </summary>
        /// <value>
        /// The job candidate.
        /// </value>
        public string JobCandidate { get; set; }

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>
        /// The start date.
        /// </value>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        /// <value>
        /// The end date.
        /// </value>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is active].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is active]; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is leasing].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is leasing]; otherwise, <c>false</c>.
        /// </value>
        public bool IsLeasing { get; set; }

        /// <summary>
        /// Gets or sets the salary price.
        /// </summary>
        /// <value>
        /// The salary price.
        /// </value>
        public decimal SalaryPrice { get; set; }

        /// <summary>
        /// Gets or sets the insurance price.
        /// </summary>
        /// <value>
        /// The insurance price.
        /// </value>
        public decimal InsurancePrice { get; set; }

        /// <summary>
        /// Gets or sets the uniform price.
        /// </summary>
        /// <value>
        /// The uniform price.
        /// </value>
        public decimal UniformPrice { get; set; }
    }
}

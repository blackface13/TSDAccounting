/***********************************************************************
 * <copyright file="EmployeeLeasingModel.cs" company="BUCA JSC">
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


namespace TSD.AccountingSoft.Model.BusinessObjects.Dictionary
{
    /// <summary>
    /// EmployeeLeasingModel
    /// </summary>
    public class EmployeeLeasingModel
    {
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

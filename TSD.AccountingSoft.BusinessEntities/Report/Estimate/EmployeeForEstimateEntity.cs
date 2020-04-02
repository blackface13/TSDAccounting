/***********************************************************************
 * <copyright file="EmployeeForEstimate.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 11 June 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;

namespace TSD.AccountingSoft.BusinessEntities.Report.Estimate
{
    /// <summary>
    /// EmployeeForEstimate
    /// </summary>
    public class EmployeeForEstimateEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeForEstimateEntity"/> class.
        /// </summary>
        public EmployeeForEstimateEntity()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeForEstimateEntity"/> class.
        /// </summary>
        /// <param name="orderNumber">The order number.</param>
        /// <param name="employeeName">Name of the employee.</param>
        /// <param name="jobCandidateName">Name of the job candidate.</param>
        /// <param name="subsitenceFee">The subsitence fee.</param>
        /// <param name="womenAllowance">The women allowance.</param>
        /// <param name="pluralityAllowance">The plurality allowance.</param>
        /// <param name="startedDate">The started date.</param>
        /// <param name="finishedDate">The finished date.</param>
        /// <param name="description">The description.</param>
        public EmployeeForEstimateEntity(int orderNumber, string employeeName, string jobCandidateName, float subsitenceFee, float womenAllowance, float pluralityAllowance, DateTime startedDate,
            DateTime finishedDate, string description)
            : this()
        {
            OrderNumber = orderNumber;
            EmployeeName = employeeName;
            JobCandidateName = jobCandidateName;
            SubsitenceFee = subsitenceFee;
            WomenAllowance = womenAllowance;
            PluralityAllowance = pluralityAllowance;
            StartedDate = startedDate;
            FinishedDate = finishedDate;
            Description = description;
        }

        /// <summary>
        /// Gets the order number.
        /// </summary>
        /// <value>
        /// The order number.
        /// </value>
        public int OrderNumber { get; set; }

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
        /// Gets or sets the subsitence fee.
        /// </summary>
        /// <value>
        /// The subsitence fee.
        /// </value>
        public float SubsitenceFee { get; set; }

        /// <summary>
        /// Gets or sets the women allowance.
        /// </summary>
        /// <value>
        /// The women allowance.
        /// </value>
        public float WomenAllowance { get; set; }

        /// <summary>
        /// Gets or sets the plurality allowance.
        /// </summary>
        /// <value>
        /// The plurality allowance.
        /// </value>
        public float PluralityAllowance { get; set; }

        /// <summary>
        /// Gets or sets the started date.
        /// </summary>
        /// <value>
        /// The started date.
        /// </value>
        public DateTime StartedDate { get; set; }

        /// <summary>
        /// Gets or sets the finished date.
        /// </summary>
        /// <value>
        /// The finished date.
        /// </value>
        public DateTime FinishedDate { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }
    }
}

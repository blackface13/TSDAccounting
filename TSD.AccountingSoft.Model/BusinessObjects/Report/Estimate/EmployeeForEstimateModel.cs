/***********************************************************************
 * <copyright file="EmployeeForEstimateModel.cs" company="BUCA JSC">
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


namespace TSD.AccountingSoft.Model.BusinessObjects.Report.Estimate
{
    /// <summary>
    /// class EmployeeForEstimateModel
    /// </summary>
    public class EmployeeForEstimateModel
    {
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

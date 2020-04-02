/***********************************************************************
 * <copyright file="FixedAssetForEstimateEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 12 June 2014
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
    /// FixedAssetForEstimateEntity
    /// </summary>
    public class FixedAssetForEstimateEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FixedAssetForEstimateEntity"/> class.
        /// </summary>
        public FixedAssetForEstimateEntity()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FixedAssetForEstimateEntity"/> class.
        /// </summary>
        /// <param name="orderNumber">The order number.</param>
        /// <param name="employeeName">Name of the employee.</param>
        /// <param name="jobCandidate">The job candidate.</param>
        /// <param name="address">The address.</param>
        /// <param name="usingOfArea">The using of area.</param>
        /// <param name="description">The description.</param>
        public FixedAssetForEstimateEntity(int orderNumber, string employeeName, string jobCandidate, string address, float usingOfArea,
            string description)
            : this()
        {
            OrderNumber = orderNumber;
            EmployeeName = employeeName;
            JobCandidateName = jobCandidate;
            Address = address;
            UsingOfArea = usingOfArea;
            Description = description;
        }

        /// <summary>
        /// Gets or sets the order number.
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
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the using of area.
        /// </summary>
        /// <value>
        /// The using of area.
        /// </value>
        public float UsingOfArea { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the purchased date.
        /// </summary>
        /// <value>
        /// The purchased date.
        /// </value>
        public DateTime PurchasedDate { get; set; }
    }
}

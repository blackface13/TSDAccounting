/***********************************************************************
 * <copyright file="BuildingEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 10 June 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;

namespace TSD.AccountingSoft.BusinessEntities.Dictionary
{
    /// <summary>
    /// BuildingEntity
    /// </summary>
    public class BuildingEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BuildingEntity"/> class.
        /// </summary>
        public BuildingEntity()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BuildingEntity"/> class.
        /// </summary>
        /// <param name="buildingId">The building identifier.</param>
        /// <param name="buildingCode">The building code.</param>
        /// <param name="buildingName">Name of the building.</param>
        /// <param name="jobCandidate">The job candidate.</param>
        /// <param name="address">The address.</param>
        /// <param name="area">The area.</param>
        /// <param name="unitPrice">The unit price.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <param name="description">The description.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        public BuildingEntity(int buildingId, string buildingCode, string buildingName, string jobCandidate, string address, float area,
            decimal unitPrice, DateTime startDate, DateTime endDate, string description, bool isActive)
            : this()
        {
            BuildingId = buildingId;
            BuildingCode = buildingCode;
            BuildingName = buildingName;
            JobCandidate = jobCandidate;
            Address = address;
            Area = area;
            UnitPrice = unitPrice;
            StartDate = startDate;
            EndDate = endDate;
            Description = description;
            IsActive = isActive;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BuildingEntity"/> class.
        /// </summary>
        /// <param name="orderNumber">The order number.</param>
        /// <param name="buildingId">The building identifier.</param>
        /// <param name="buildingCode">The building code.</param>
        /// <param name="buildingName">Name of the building.</param>
        /// <param name="jobCandidate">The job candidate.</param>
        /// <param name="address">The address.</param>
        /// <param name="area">The area.</param>
        /// <param name="unitPrice">The unit price.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <param name="description">The description.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        public BuildingEntity(int orderNumber, int buildingId, string buildingCode, string buildingName, string jobCandidate, string address, float area,
            decimal unitPrice, DateTime startDate, DateTime endDate, string description, bool isActive)
            : this()
        {
            OrderNumber = orderNumber;
            BuildingId = buildingId;
            BuildingCode = buildingCode;
            BuildingName = buildingName;
            JobCandidate = jobCandidate;
            Address = address;
            Area = area;
            UnitPrice = unitPrice;
            StartDate = startDate;
            EndDate = endDate;
            Description = description;
            IsActive = isActive;
        }

        /// <summary>
        /// Gets or sets the order number.
        /// </summary>
        /// <value>
        /// The order number.
        /// </value>
        public int OrderNumber { get; set; }

        /// <summary>
        /// Gets or sets the building identifier.
        /// </summary>
        /// <value>
        /// The building identifier.
        /// </value>
        public int BuildingId { get; set; }

        /// <summary>
        /// Gets or sets the building code.
        /// </summary>
        /// <value>
        /// The building code.
        /// </value>
        public string BuildingCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the building.
        /// </summary>
        /// <value>
        /// The name of the building.
        /// </value>
        public string BuildingName { get; set; }

        /// <summary>
        /// Gets or sets the job candidate.
        /// </summary>
        /// <value>
        /// The job candidate.
        /// </value>
        public string JobCandidate { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the area.
        /// </summary>
        /// <value>
        /// The area.
        /// </value>
        public float Area { get; set; }

        /// <summary>
        /// Gets the unit price.
        /// </summary>
        /// <value>
        /// The unit price.
        /// </value>
        public decimal UnitPrice { get; set; }

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
    }
}

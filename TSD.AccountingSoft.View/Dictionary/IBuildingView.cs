/***********************************************************************
 * <copyright file="IBuildingView.cs" company="BUCA JSC">
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


namespace TSD.AccountingSoft.View.Dictionary
{
    /// <summary>
    /// IBuildingView
    /// </summary>
    public interface IBuildingView : IView
    {
        /// <summary>
        /// Gets or sets the building identifier.
        /// </summary>
        /// <value>
        /// The building identifier.
        /// </value>
        int BuildingId { get; set; }

        /// <summary>
        /// Gets or sets the building code.
        /// </summary>
        /// <value>
        /// The building code.
        /// </value>
        string BuildingCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the building.
        /// </summary>
        /// <value>
        /// The name of the building.
        /// </value>
        string BuildingName { get; set; }

        /// <summary>
        /// Gets or sets the job candidate.
        /// </summary>
        /// <value>
        /// The job candidate.
        /// </value>
        string JobCandidate { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        string Address { get; set; }

        /// <summary>
        /// Gets or sets the area.
        /// </summary>
        /// <value>
        /// The area.
        /// </value>
        float Area { get; set; }

        /// <summary>
        /// Gets the unit price.
        /// </summary>
        /// <value>
        /// The unit price.
        /// </value>
        decimal UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>
        /// The start date.
        /// </value>
        DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        /// <value>
        /// The end date.
        /// </value>
        DateTime EndDate { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is active].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is active]; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; set; }
    }
}

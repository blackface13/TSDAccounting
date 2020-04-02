/***********************************************************************
 * <copyright file="IFixedAssetHousingReportView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   THODD
 * Email:    thodd@buca.vn
 * Website:
 * Create Date: 07 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

namespace TSD.AccountingSoft.View.Report
{
    /// <summary>
    /// Interface IFixedAssetHousingReportView
    /// </summary>
    public interface IFixedAssetHousingReportView : IView
    {
        /// <summary>
        /// Gets or sets the fixed asset housing report identifier.
        /// </summary>
        /// <value>
        /// The fixed asset housing report identifier.
        /// </value>
        int FixedAssetHousingReportId { get; set; }

        /// <summary>
        /// Gets or sets the area of building.
        /// </summary>
        /// <value>
        /// The area of building.
        /// </value>
        decimal AreaOfBuilding { get; set; }

        /// <summary>
        /// Gets or sets the working area.
        /// </summary>
        /// <value>
        /// The working area.
        /// </value>
        decimal WorkingArea { get; set; }

        /// <summary>
        /// Gets or sets the housing area.
        /// </summary>
        /// <value>
        /// The housing area.
        /// </value>
        decimal HousingArea { get; set; }

        /// <summary>
        /// Gets or sets the guest house area.
        /// </summary>
        /// <value>
        /// The guest house area.
        /// </value>
        decimal GuestHouseArea { get; set; }

        /// <summary>
        /// Gets or sets the occupied area.
        /// </summary>
        /// <value>
        /// The occupied area.
        /// </value>
        decimal OccupiedArea { get; set; }

        /// <summary>
        /// Gets or sets the other area.
        /// </summary>
        /// <value>
        /// The other area.
        /// </value>
        decimal OtherArea { get; set; }

        /// <summary>
        /// Gets or sets the accounting value.
        /// </summary>
        /// <value>
        /// The accounting value.
        /// </value>
        decimal AccountingValue { get; set; }

        /// <summary>
        /// Gets or sets the attachments.
        /// </summary>
        /// <value>
        /// The attachments.
        /// </value>
        string Attachments { get; set; }
    }
}

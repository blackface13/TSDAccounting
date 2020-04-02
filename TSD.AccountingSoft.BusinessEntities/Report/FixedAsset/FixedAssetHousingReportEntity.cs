/***********************************************************************
 * <copyright file="FixedAssetHousingReportEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Thursday, March 13, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/
using TSD.AccountingSoft.BusinessEntities.BusinessRules;

namespace TSD.AccountingSoft.BusinessEntities.Report
{
    /// <summary>
    /// Report Group Entity
    /// </summary>
    public class FixedAssetHousingReportEntity : BusinessEntities
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="FixedAssetHousingReportEntity" /> class.
        /// </summary>
        public FixedAssetHousingReportEntity()
        {
            AddRule(new ValidateRequired("FixedAssetHousingReportID"));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FixedAssetHousingReportEntity" /> class.
        /// </summary>
        /// <param name="fixedAssetHousingReportId">The report group identifier.</param>
        /// <param name="areaOfBuilding">The area of building.</param>
        /// <param name="guestHouseArea">The guest house area.</param>
        /// <param name="occupiedArea">The occupied area.</param>
        /// <param name="workingArea">The working area.</param>
        /// <param name="housingArea">The housing area.</param>
        /// <param name="otherArea">The other area.</param>
        /// <param name="accountingValue">The accounting value.</param>
        /// <param name="attachments">The attachments.</param>
        public FixedAssetHousingReportEntity(int fixedAssetHousingReportId, decimal areaOfBuilding, decimal guestHouseArea, decimal occupiedArea,
            decimal workingArea, decimal housingArea, decimal otherArea, decimal accountingValue, string attachments)
            : this()
        {
            FixedAssetHousingReportId = fixedAssetHousingReportId;
            AreaOfBuilding = areaOfBuilding;
            WorkingArea = workingArea;
            HousingArea = housingArea;
            GuestHouseArea = guestHouseArea;
            OccupiedArea = occupiedArea;
            OtherArea = otherArea;
            AccountingValue = accountingValue;
            Attachments = attachments;
        }

        /// <summary>
        /// Gets or sets the fixed asset housing report identifier.
        /// </summary>
        /// <value>
        /// The fixed asset housing report identifier.
        /// </value>
        public int FixedAssetHousingReportId { get; set; }

        /// <summary>
        /// Gets or sets the area of building.
        /// </summary>
        /// <value>
        /// The area of building.
        /// </value>
        public decimal AreaOfBuilding { get; set; }

        /// <summary>
        /// Gets or sets the working area.
        /// </summary>
        /// <value>
        /// The working area.
        /// </value>
        public decimal WorkingArea { get; set; }

        /// <summary>
        /// Gets or sets the housing area.
        /// </summary>
        /// <value>
        /// The housing area.
        /// </value>
        public decimal HousingArea { get; set; }

        /// <summary>
        /// Gets or sets the guest house area.
        /// </summary>
        /// <value>
        /// The guest house area.
        /// </value>
        public decimal GuestHouseArea { get; set; }

        /// <summary>
        /// Gets or sets the occupied area.
        /// </summary>
        /// <value>
        /// The occupied area.
        /// </value>
        public decimal OccupiedArea { get; set; }

        /// <summary>
        /// Gets or sets the other area.
        /// </summary>
        /// <value>
        /// The other area.
        /// </value>
        public decimal OtherArea { get; set; }

        /// <summary>
        /// Gets or sets the accounting value.
        /// </summary>
        /// <value>
        /// The accounting value.
        /// </value>
        public decimal AccountingValue { get; set; }

        /// <summary>
        /// Gets or sets the attachments.
        /// </summary>
        /// <value>
        /// The attachments.
        /// </value>
        public string Attachments { get; set; }
    }
}

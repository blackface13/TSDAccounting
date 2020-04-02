
namespace TSD.AccountingSoft.Model.BusinessObjects.Report.FixedAsset
{
    public class FixedAssetHousingReportModel
    {
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

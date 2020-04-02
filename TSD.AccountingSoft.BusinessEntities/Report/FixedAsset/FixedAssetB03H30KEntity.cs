namespace TSD.AccountingSoft.BusinessEntities.Report.FixedAsset
{
    /// <summary>
    /// 
    /// </summary>
    public class FixedAssetB03H30KEntity : BusinessEntities
    {

        /// <summary>
        /// Gets or sets the fixed asset category identifier.
        /// </summary>
        /// <value>
        /// The fixed asset category identifier.
        /// </value>
        public int FixedAssetId { get; set; }

        /// <summary>
        /// Gets or sets the fixed asset category code.
        /// </summary>
        /// <value>
        /// The fixed asset category code.
        /// </value>
        public string FixedAssetCategoryCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the fixed asset.
        /// </summary>
        /// <value>
        /// The name of the fixed asset.
        /// </value>
        public string FixedAssetName { get; set; }

        /// <summary>
        /// Gets or sets the fixed asset code.
        /// </summary>
        /// <value>
        /// The fixed asset code.
        /// </value>
        public string FixedAssetCode { get; set; }

        /// <summary>
        /// Gets or sets the type of the fixed asset.
        /// </summary>
        /// <value>
        /// The type of the fixed asset.
        /// </value>
        public string FixedAssetType { get; set; }

        /// <summary>
        /// Gets or sets the quantity opening.
        /// </summary>
        /// <value>
        /// The quantity opening.
        /// </value>
        public int QuantityOpening { get; set; }

        /// <summary>
        /// Gets or sets the area opening.
        /// </summary>
        /// <value>
        /// The area opening.
        /// </value>
        public decimal AreaOpening { get; set; }

        /// <summary>
        /// Gets or sets the org price opening.
        /// </summary>
        /// <value>
        /// The org price opening.
        /// </value>
        public decimal OrgPriceOpening { get; set; }

        /// <summary>
        /// Gets or sets the org price opening difference.
        /// </summary>
        /// <value>
        /// The org price opening difference.
        /// </value>
        public decimal OrgPriceOpeningDifference { get; set; }

        /// <summary>
        /// Gets or sets the quantity increment.
        /// </summary>
        /// <value>
        /// The quantity increment.
        /// </value>
        public int QuantityIncrement { get; set; }

        /// <summary>
        /// Gets or sets the area increment.
        /// </summary>
        /// <value>
        /// The area increment.
        /// </value>
        public decimal AreaIncrement { get; set; }

        /// <summary>
        /// Gets or sets the org price increment.
        /// </summary>
        /// <value>
        /// The org price increment.
        /// </value>
        public decimal OrgPriceIncrement { get; set; }

        /// <summary>
        /// Gets or sets the org price increment difference.
        /// </summary>
        /// <value>
        /// The org price increment difference.
        /// </value>
        public decimal OrgPriceIncrementDifference { get; set; }

        /// <summary>
        /// Gets or sets the quantity decrement.
        /// </summary>
        /// <value>
        /// The quantity decrement.
        /// </value>
        public int QuantityDecrement { get; set; }

        /// <summary>
        /// Gets or sets the area decrement.
        /// </summary>
        /// <value>
        /// The area decrement.
        /// </value>
        public decimal AreaDecrement { get; set; }

        /// <summary>
        /// Gets or sets the org price decrement.
        /// </summary>
        /// <value>
        /// The org price decrement.
        /// </value>
        public decimal OrgPriceDecrement { get; set; }

        /// <summary>
        /// Gets or sets the org price decrement difference.
        /// </summary>
        /// <value>
        /// The org price decrement difference.
        /// </value>
        public decimal OrgPriceDecrementDifference { get; set; }

        /// <summary>
        /// Gets or sets the quantity closing.
        /// </summary>
        /// <value>
        /// The quantity closing.
        /// </value>
        public int QuantityClosing { get; set; }

        /// <summary>
        /// Gets or sets the area closing.
        /// </summary>
        /// <value>
        /// The area closing.
        /// </value>
        public decimal AreaClosing { get; set; }

        /// <summary>
        /// Gets or sets the org price closing.
        /// </summary>
        /// <value>
        /// The org price closing.
        /// </value>
        public decimal OrgPriceClosing { get; set; }

        /// <summary>
        /// Gets or sets the org price closing difference.
        /// </summary>
        /// <value>
        /// The org price closing difference.
        /// </value>
        public decimal OrgPriceClosingDifference { get; set; }

        /// <summary>
        /// Gets or sets the grade.
        /// </summary>
        /// <value>
        /// The grade.
        /// </value>
        public int Grade { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }
    }
}
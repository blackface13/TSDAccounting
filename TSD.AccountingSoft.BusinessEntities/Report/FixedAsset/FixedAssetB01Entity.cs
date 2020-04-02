namespace TSD.AccountingSoft.BusinessEntities.Report.FixedAsset
{
    /// <summary>
    ///     FixedAssetB01Entity
    /// </summary>
    public class FixedAssetB01Entity : BusinessEntities
    {
        /// <summary>
        ///     Gets or sets the order number.
        /// </summary>
        /// <value>
        ///     The order number.
        /// </value>
        public int OrderNumber { get; set; }

        /// <summary>
        ///     Gets or sets the fixed asset identifier.
        /// </summary>
        /// <value>
        ///     The fixed asset identifier.
        /// </value>
        public int FixedAssetId { get; set; }

        /// <summary>
        ///     Gets or sets the fixed asset category code.
        /// </summary>
        /// <value>
        ///     The fixed asset category code.
        /// </value>
        public string FixedAssetCategoryCode { get; set; }

        /// <summary>
        ///     Gets or sets the serial number.
        /// </summary>
        /// <value>
        ///     The serial number.
        /// </value>
        public string FixedAssetCategoryName { get; set; }

        /// <summary>
        ///     Gets or sets the fixed asset code.
        /// </summary>
        /// <value>
        ///     The fixed asset code.
        /// </value>
        public string FixedAssetCode { get; set; }

        /// <summary>
        ///     Gets or sets the name of the fixed asset.
        /// </summary>
        /// <value>
        ///     The name of the fixed asset.
        /// </value>
        public string FixedAssetName { get; set; }

        /// <summary>
        ///     Gets or sets the parent identifier.
        /// </summary>
        /// <value>
        ///     The parent identifier.
        /// </value>
        public int ParentId { get; set; }

        /// <summary>
        ///     Gets or sets the fixed asset code.
        /// </summary>
        /// <value>
        ///     The fixed asset code.
        /// </value>
        public string Unit { get; set; }

        public decimal DepreciationRate { get; set; }        /// <summary>
        ///     Gets or sets the serial number.
        /// </summary>
        /// <value>
        ///     The serial number.
        /// </value>
        public string SerialNumber { get; set; }

        public string AddressUsing { get; set; }

        /// <summary>
        ///     Gets or sets the year of using.
        /// </summary>
        /// <value>
        ///     The year of using.
        /// </value>
        public int YearOfUsing { get; set; }

        /// <summary>
        ///     Gets or sets the org price.
        /// </summary>
        /// <value>
        ///     The org price.
        /// </value>
        public decimal OrgPrice { get; set; }


        /// <summary>
        ///     Gets or sets the quantity.
        /// </summary>
        /// <value>
        ///     The quantity.
        /// </value>
        public int QuantityDecrement { get; set; }

        /// <summary>
        ///     Gets or sets the org price currency usd.
        /// </summary>
        /// <value>
        ///     The org price currency usd.
        /// </value>
        public decimal OrgPriceDecrement { get; set; }

        /// <summary>
        ///     Gets or sets the org price decrement usd.
        /// </summary>
        /// <value>
        ///     The org price decrement usd.
        /// </value>
        public decimal OrgPriceDecrementUSD { get; set; }

        /// <summary>
        ///     Gets or sets the org price decrement currency usd.
        /// </summary>
        /// <value>
        ///     The org price decrement currency usd.
        /// </value>
        public decimal OrgPriceDecrementCurrencyUSD { get; set; }

        /// <summary>
        ///     Gets or sets the total org price decrement usd.
        /// </summary>
        /// <value>
        ///     The total org price decrement usd.
        /// </value>
        public decimal TotalOrgPriceDecrementUSD { get; set; }

        /// <summary>
        /// Gets or sets the quantity annual depreciation.
        /// </summary>
        /// <value>
        /// The quantity annual depreciation.
        /// </value>
        public int QuantityAnnualDepreciation { get; set; }
        
        /// <summary>
        ///     Gets or sets the total org price usd.
        /// </summary>
        /// <value>
        ///     The total org price usd.
        /// </value>
        public decimal AnnualDepreciationAmount { get; set; }

        /// <summary>
        ///     Gets or sets the annual depreciation amount usd.
        /// </summary>
        /// <value>
        ///     The annual depreciation amount usd.
        /// </value>
        public decimal AnnualDepreciationAmountUSD { get; set; }

        /// <summary>
        ///     Gets or sets the annual depreciation amount currency usd.
        /// </summary>
        /// <value>
        ///     The annual depreciation amount currency usd.
        /// </value>
        public decimal AnnualDepreciationAmountCurrencyUSD { get; set; }

        /// <summary>
        ///     Gets or sets the total annual depreciation amount usd.
        /// </summary>
        /// <value>
        ///     The total annual depreciation amount usd.
        /// </value>
        public decimal TotalAnnualDepreciationAmountUSD { get; set; }

        /// <summary>
        /// Gets or sets the quantity remaining decrement.
        /// </summary>
        /// <value>
        /// The quantity remaining decrement.
        /// </value>
        public int QuantityRemainingDecrement { get; set; }

        /// <summary>
        ///     Gets or sets the total org price usd.
        /// </summary>
        /// <value>
        ///     The total org price usd.
        /// </value>
        public decimal RemainingAmountDecrement { get; set; }

        /// <summary>
        ///     Gets or sets the remaining amount decrement usd.
        /// </summary>
        /// <value>
        ///     The remaining amount decrement usd.
        /// </value>
        public decimal RemainingAmountDecrementUSD { get; set; }

        /// <summary>
        ///     Gets or sets the remaining amount decrement currency usd.
        /// </summary>
        /// <value>
        ///     The remaining amount decrement currency usd.
        /// </value>
        public decimal RemainingAmountDecrementCurrencyUSD { get; set; }

        /// <summary>
        ///     Gets or sets the total remaining amount decrement usd.
        /// </summary>
        /// <value>
        ///     The total remaining amount decrement usd.
        /// </value>
        public decimal TotalRemainingAmountDecrementUSD { get; set; }

        /// <summary>
        ///     Gets or sets the grade.
        /// </summary>
        /// <value>
        ///     The grade.
        /// </value>
        public int Grade { get; set; }

        /// <summary>
        ///     Gets or sets the sort.
        /// </summary>
        /// <value>
        ///     The sort.
        /// </value>
        public string Sort { get; set; }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        /// <value>
        ///     The description.
        /// </value>
        public string Description { get; set; }
    }
}
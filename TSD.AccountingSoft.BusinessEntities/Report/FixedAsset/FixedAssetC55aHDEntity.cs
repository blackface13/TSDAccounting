namespace TSD.AccountingSoft.BusinessEntities.Report.FixedAsset
{
    /// <summary>
    /// </summary>
    public class FixedAssetC55aHDEntity : BusinessEntities
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
        ///     Gets or sets the name of the fixed asset.
        /// </summary>
        /// <value>
        ///     The name of the fixed asset.
        /// </value>
        public string FixedAssetName { get; set; }

        /// <summary>
        ///     Gets or sets the fixed asset category code.
        /// </summary>
        /// <value>
        ///     The fixed asset category code.
        /// </value>
        public string FixedAssetCategoryCode { get; set; }

        /// <summary>
        ///     Gets or sets the name of the fixed asset category.
        /// </summary>
        /// <value>
        ///     The name of the fixed asset category.
        /// </value>
        public string FixedAssetCategoryName { get; set; }

        /// <summary>
        ///     Gets or sets the year of using.
        /// </summary>
        /// <value>
        ///     The year of using.
        /// </value>
        public int YearOfUsing { get; set; }

        /// <summary>
        ///     <summary>
        ///         Gets or sets the serial number.
        ///     </summary>
        ///     <value>
        ///         The serial number.
        ///     </value>
        public string SerialNumber { get; set; }

        /// <summary>
        ///     Gets or sets the address using.
        /// </summary>
        /// <value>
        ///     The address using.
        /// </value>
        public string AddressUsing { get; set; }

        /// <summary>
        ///     Gets or sets the address using.
        /// </summary>
        /// <value>
        ///     The address using.
        /// </value>
        public string Unit { get; set; }

        /// <summary>
        /// Gets or sets the quantity org price.
        /// </summary>
        /// <value>
        /// The quantity org price.
        /// </value>
        public int QuantityOrgPrice { get; set; }

        /// <summary>
        ///     Gets or sets the org price.
        /// </summary>
        /// <value>
        ///     The org price.
        /// </value>
        public decimal OrgPrice { get; set; }

        /// <summary>
        ///     Gets or sets the org price usd.
        /// </summary>
        /// <value>
        ///     The org price usd.
        /// </value>
        public decimal OrgPriceUSD { get; set; }

        /// <summary>
        ///     Gets or sets the org price currency usd.
        /// </summary>
        /// <value>
        ///     The org price currency usd.
        /// </value>
        public decimal OrgPriceCurrencyUSD { get; set; }

        /// <summary>
        ///     Gets or sets the total org price usd.
        /// </summary>
        /// <value>
        ///     The total org price usd.
        /// </value>
        public decimal TotalOrgPriceUSD { get; set; }

        /// <summary>
        ///     Gets or sets the annual depreciation amount.
        /// </summary>
        /// <value>
        ///     The annual depreciation amount.
        /// </value>
        public decimal AnnualDepreciationAmount { get; set; }

        /// <summary>
        ///     Gets or sets the remainig amount.
        /// </summary>
        /// <value>
        ///     The remainig amount.
        /// </value>
        public decimal RemainigAmount { get; set; }

        /// <summary>
        ///     Gets or sets the life time.
        /// </summary>
        /// <value>
        ///     The life time.
        /// </value>
        public int LifeTime { get; set; }

        /// <summary>
        ///     Gets or sets the annual depreciation rate.
        /// </summary>
        /// <value>
        ///     The annual depreciation rate.
        /// </value>
        public decimal AnnualDepreciationRate { get; set; }

        /// <summary>
        /// Gets or sets the quantity depreciation.
        /// </summary>
        /// <value>
        /// The quantity depreciation.
        /// </value>
        public int QuantityDepreciation { get; set; }

        /// <summary>
        ///     Gets or sets the depreciation year.
        /// </summary>
        /// <value>
        ///     The depreciation year.
        /// </value>
        public decimal DepreciationYearAmount { get; set; }

        /// <summary>
        ///     Gets or sets the depreciation year amount usd.
        /// </summary>
        /// <value>
        ///     The depreciation year amount usd.
        /// </value>
        public decimal DepreciationYearAmountUSD { get; set; }

        /// <summary>
        ///     Gets or sets the depreciation year amount currency usd.
        /// </summary>
        /// <value>
        ///     The depreciation year amount currency usd.
        /// </value>
        public decimal DepreciationYearAmountCurrencyUSD { get; set; }

        /// <summary>
        ///     Gets or sets the total depreciation year amount usd.
        /// </summary>
        /// <value>
        ///     The total depreciation year amount usd.
        /// </value>
        public decimal TotalDepreciationYearAmountUSD { get; set; }
    }
}
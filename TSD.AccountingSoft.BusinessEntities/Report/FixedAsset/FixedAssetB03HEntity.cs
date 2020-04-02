namespace TSD.AccountingSoft.BusinessEntities.Report.FixedAsset
{
    /// <summary>
    /// </summary>
    public class FixedAssetB03HEntity : BusinessEntities
    {
        /// <summary>
        ///     Gets or sets the name of the budget item.
        /// </summary>
        /// <value>
        ///     The name of the budget item.
        /// </value>
        public int FixedAssetCategoryId { get; set; }

        /// <summary>
        ///     Gets or sets the previous year of total estimate amount.
        /// </summary>
        /// <value>
        ///     The previous year of total estimate amount.
        /// </value>
        public string FixedAssetCategoryCode { get; set; }

        /// <summary>
        ///     Gets or sets the previous year of total estimate amount.
        /// </summary>
        /// <value>
        ///     The previous year of total estimate amount.
        /// </value>
        public string FixedAssetCategoryName { get; set; }

        /// <summary>
        ///     Gets or sets the year of estimate amount.
        /// </summary>
        /// <value>
        ///     The year of estimate amount.
        /// </value>
        public int ParentId { get; set; }

        /// <summary>
        ///     Gets or sets the next year of estimate amount.
        /// </summary>
        /// <value>
        ///     The next year of estimate amount.
        /// </value>
        public string Unit { get; set; }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        /// <value>
        ///     The description.
        /// </value>
        public int QuantityOpening { get; set; }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        /// <value>
        ///     The description.
        /// </value>
        public int QuantityIncrement { get; set; }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        /// <value>
        ///     The description.
        /// </value>
        public int QuantityDecrement { get; set; }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        /// <value>
        ///     The description.
        /// </value>
        public int QuantityClosing { get; set; }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        /// <value>
        ///     The description.
        /// </value>
        public decimal OrgPriceOpening { get; set; }

        /// <summary>
        ///     Gets or sets the org price opening usd.
        /// </summary>
        /// <value>
        ///     The org price opening usd.
        /// </value>
        public decimal OrgPriceOpeningUSD { get; set; }

        /// <summary>
        ///     Gets or sets the org price opening currency usd.
        /// </summary>
        /// <value>
        ///     The org price opening currency usd.
        /// </value>
        public decimal OrgPriceOpeningCurrencyUSD { get; set; }

        /// <summary>
        ///     Gets or sets the total org price opening usd.
        /// </summary>
        /// <value>
        ///     The total org price opening usd.
        /// </value>
        public decimal TotalOrgPriceOpeningUSD { get; set; }


        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        /// <value>
        ///     The description.
        /// </value>
        public decimal OrgPriceIncrement { get; set; }

        /// <summary>
        ///     Gets or sets the org price increment usd.
        /// </summary>
        /// <value>
        ///     The org price increment usd.
        /// </value>
        public decimal OrgPriceIncrementUSD { get; set; }

        /// <summary>
        ///     Gets or sets the org price increment currency usd.
        /// </summary>
        /// <value>
        ///     The org price increment currency usd.
        /// </value>
        public decimal OrgPriceIncrementCurrencyUSD { get; set; }

        /// <summary>
        ///     Gets or sets the total org price increment usd.
        /// </summary>
        /// <value>
        ///     The total org price increment usd.
        /// </value>
        public decimal TotalOrgPriceIncrementUSD { get; set; }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        /// <value>
        ///     The description.
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
        ///     Gets or sets the description.
        /// </summary>
        /// <value>
        ///     The description.
        /// </value>
        public decimal OrgPriceClosing { get; set; }

        /// <summary>
        ///     Gets or sets the org price closing usd.
        /// </summary>
        /// <value>
        ///     The org price closing usd.
        /// </value>
        public decimal OrgPriceClosingUSD { get; set; }

        /// <summary>
        ///     Gets or sets the org price closing currency usd.
        /// </summary>
        /// <value>
        ///     The org price closing currency usd.
        /// </value>
        public decimal OrgPriceClosingCurrencyUSD { get; set; }

        /// <summary>
        ///     Gets or sets the total org price closing usd.
        /// </summary>
        /// <value>
        ///     The total org price closing usd.
        /// </value>
        public decimal TotalOrgPriceClosingUSD { get; set; }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        /// <value>
        ///     The description.
        /// </value>
        public int Grade { get; set; }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        /// <value>
        ///     The description.
        /// </value>
        public string Sort { get; set; }
    }
}
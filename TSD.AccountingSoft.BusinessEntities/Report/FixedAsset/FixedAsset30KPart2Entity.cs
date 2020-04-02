using System;

namespace TSD.AccountingSoft.BusinessEntities.Report.FixedAsset
{
    /// <summary>
    /// 
    /// </summary>
    public class FixedAsset30KPart2Entity : BusinessEntities
    {
        /// <summary>
        /// Gets or sets the order number.
        /// </summary>
        /// <value>
        /// The order number.
        /// </value>
        public int OrderNumber { get; set; }

        /// <summary>
        /// Gets or sets the fixed asset identifier.
        /// </summary>
        /// <value>
        /// The fixed asset identifier.
        /// </value>
        public int FixedAssetId { get; set; }

        /// <summary>
        /// Gets or sets the name of the fixed asset.
        /// </summary>
        /// <value>
        /// The name of the fixed asset.
        /// </value>
        public string FixedAssetName { get; set; }

        /// <summary>
        /// Gets or sets the fixed asset category code.
        /// </summary>
        /// <value>
        /// The fixed asset category code.
        /// </value>
        public string FixedAssetCategoryCode { get; set; }

        /// <summary>
        /// Gets or sets the fixed asset code.
        /// </summary>
        /// <value>
        /// The fixed asset code.
        /// </value>
        public string FixedAssetCode { get; set; }

        /// <summary>
        /// Gets or sets the country production.
        /// </summary>
        /// <value>
        /// The country production.
        /// </value>
        public string CountryProduction { get; set; }

        /// <summary>
        /// Gets or sets the production year.
        /// </summary>
        /// <value>
        /// The production year.
        /// </value>
        public int ProductionYear { get; set; }

        /// <summary>
        /// Gets or sets the date of using.
        /// </summary>
        /// <value>
        /// The date of using.
        /// </value>
        public DateTime DateOfUsing { get; set; }

        /// <summary>
        /// Gets or sets the org price.
        /// </summary>
        /// <value>
        /// The org price.
        /// </value>
        public decimal OrgPrice { get; set; }

        /// <summary>
        /// Gets or sets the org price difference.
        /// </summary>
        /// <value>
        /// The org price difference.
        /// </value>
        public decimal OrgPriceDifference { get; set; }

        /// <summary>
        /// Gets or sets the remaining amount.
        /// </summary>
        /// <value>
        /// The remaining amount.
        /// </value>
        public decimal RemainingAmount { get; set; }

        /// <summary>
        /// Gets or sets the state management.
        /// </summary>
        /// <value>
        /// The state management.
        /// </value>
        public string StateManagement { get; set; }

        /// <summary>
        /// Gets or sets the bussiness.
        /// </summary>
        /// <value>
        /// The bussiness.
        /// </value>
        public string Bussiness { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

    }
}
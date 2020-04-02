using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.Model.BusinessObjects.Report.FixedAsset
{
    public class FixedAssetFAInventoryModel
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
        /// Gets or sets the fixed asset category code.
        /// </summary>
        /// <value>
        /// The fixed asset category code.
        /// </value>
        public string FixedAssetCategoryCode { get; set; }

        /// <summary>
        /// Gets or sets the parent identifier.
        /// </summary>
        /// <value>
        /// The parent identifier.
        /// </value>
        public int ParentId { get; set; }

        /// <summary>
        /// Gets or sets the name of the fixed asset.
        /// </summary>
        /// <value>
        /// The name of the fixed asset.
        /// </value>
        public string FixedAssetName { get; set; }

        /// <summary>
        /// Gets or sets the year of using.
        /// </summary>
        /// <value>
        /// The year of using.
        /// </value>
        public int YearOfUsing { get; set; }

        /// <summary>
        /// Gets or sets the fixed asset code.
        /// </summary>
        /// <value>
        /// The fixed asset code.
        /// </value>
        public string FixedAssetCode { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the fixed asset code.
        /// </summary>
        /// <value>
        /// The fixed asset code.
        /// </value>
        public string Unit { get; set; }

        /// <summary>
        /// Gets or sets the org price.
        /// </summary>
        /// <value>
        /// The org price.
        /// </value>
        public decimal DepreciationRate { get; set; }

        /// <summary>
        /// Gets or sets the serial number.
        /// </summary>
        /// <value>
        /// The serial number.
        /// </value>
        public string SerialNumber { get; set; }

        /// <summary>
        /// Gets or sets the country production.
        /// </summary>
        /// <value>
        /// The country production.
        /// </value>
        public string CountryProduction { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>
        /// The quantity.
        /// </value>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the org price.
        /// </summary>
        /// <value>
        /// The org price.
        /// </value>
        public decimal OrgPrice { get; set; }

        /// <summary>
        /// Gets or sets the org price usd.
        /// </summary>
        /// <value>
        /// The org price usd.
        /// </value>
        public decimal OrgPriceUsd { get; set; }

        /// <summary>
        /// Gets or sets the org price currency usd.
        /// </summary>
        /// <value>
        /// The org price currency usd.
        /// </value>
        public decimal OrgPriceCurrencyUsd { get; set; }

        /// <summary>
        /// Gets or sets the total org price usd.
        /// </summary>
        /// <value>
        /// The total org price usd.
        /// </value>
        public decimal TotalOrgPriceUsd { get; set; }

        /// <summary>
        /// Gets or sets the quantity invetory.
        /// </summary>
        /// <value>
        /// The quantity invetory.
        /// </value>
        public int QuantityInvetory { get; set; }

        /// <summary>
        /// Gets or sets the org price invetory.
        /// </summary>
        /// <value>
        /// The org price invetory.
        /// </value>
        public decimal OrgPriceInvetory { get; set; }

        /// <summary>
        /// Gets or sets the org price currency invetory usd.
        /// </summary>
        /// <value>
        /// The org price currency invetory usd.
        /// </value>
        public decimal OrgPriceCurrencyInvetoryUsd { get; set; }

        /// <summary>
        /// Gets or sets the org price invetory usd.
        /// </summary>
        /// <value>
        /// The org price invetory usd.
        /// </value>
        public decimal OrgPriceInvetoryUsd { get; set; }

        /// <summary>
        /// Gets or sets the total org price invetory usd.
        /// </summary>
        /// <value>
        /// The total org price invetory usd.
        /// </value>
        public decimal TotalOrgPriceInvetoryUsd { get; set; }

        /// <summary>
        /// Gets or sets the quantity difference.
        /// </summary>
        /// <value>
        /// The quantity difference.
        /// </value>
        public int QuantityDifference { get; set; }

        /// <summary>
        /// Gets or sets the org price difference.
        /// </summary>
        /// <value>
        /// The org price difference.
        /// </value>
        public decimal OrgPriceDifference { get; set; }

        /// <summary>
        /// Gets or sets the org price currency difference usd.
        /// </summary>
        /// <value>
        /// The org price currency difference usd.
        /// </value>
        public decimal OrgPriceCurrencyDifferenceUsd { get; set; }

        /// <summary>
        /// Gets or sets the org price difference usd.
        /// </summary>
        /// <value>
        /// The org price difference usd.
        /// </value>
        public decimal OrgPriceDifferenceUsd { get; set; }

        /// <summary>
        /// Gets or sets the total org price difference usd.
        /// </summary>
        /// <value>
        /// The total org price difference usd.
        /// </value>
        public decimal TotalOrgPriceDifferenceUsd { get; set; }

        /// <summary>
        /// Gets or sets the grade.
        /// </summary>
        /// <value>
        /// The grade.
        /// </value>
        public int Grade { get; set; }

        /// <summary>
        /// Gets or sets the sort.
        /// </summary>
        /// <value>
        /// The sort.
        /// </value>
        public string Sort { get; set; }

        public bool IsParent { get; set; }
    }
}

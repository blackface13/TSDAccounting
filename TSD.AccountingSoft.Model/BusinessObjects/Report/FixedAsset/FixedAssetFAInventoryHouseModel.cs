
using System;

namespace TSD.AccountingSoft.Model.BusinessObjects.Report.FixedAsset
{
    public class FixedAssetFAInventoryHouseModel
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
        /// Gets or sets the name of the fixed asset.
        /// </summary>
        /// <value>
        /// The name of the fixed asset.
        /// </value>
        public string GradeHouse { get; set; }

        /// <summary>
        /// Gets or sets the fixed asset code.
        /// </summary>
        /// <value>
        /// The fixed asset code.
        /// </value>
        public string FixedAssetCode { get; set; }

        /// <summary>
        /// Gets or sets the year of using.
        /// </summary>
        /// <value>
        /// The year of using.
        /// </value>
        public DateTime UsedDate { get; set; }

        /// <summary>
        /// Gets or sets the fixed asset identifier.
        /// </summary>
        /// <value>
        /// The fixed asset identifier.
        /// </value>
        public int ProductionYear { get; set; }

        /// <summary>
        /// Gets or sets the fixed asset code.
        /// </summary>
        /// <value>
        /// The fixed asset code.
        /// </value>
        public int NumberOfFloor { get; set; }

        /// <summary>
        /// Gets or sets the org price.
        /// </summary>
        /// <value>
        /// The org price.
        /// </value>
        public decimal AreaOfBuilding { get; set; }

        /// <summary>
        /// Gets or sets the org price.
        /// </summary>
        /// <value>
        /// The org price.
        /// </value>
        public decimal WorkingArea { get; set; }

        /// <summary>
        /// Gets or sets the org price usd.
        /// </summary>
        /// <value>
        /// The org price usd.
        /// </value>
        public decimal AreaOfFloor { get; set; }

        /// <summary>
        /// Gets or sets the org price.
        /// </summary>
        /// <value>
        /// The org price.
        /// </value>
        public decimal GuestHouseArea { get; set; }

        /// <summary>
        /// Gets or sets the org price.
        /// </summary>
        /// <value>
        /// The org price.
        /// </value>
        public decimal HousingArea { get; set; }

        /// <summary>
        /// Gets or sets the org price usd.
        /// </summary>
        /// <value>
        /// The org price usd.
        /// </value>
        public decimal OtherArea { get; set; }

        /// <summary>
        /// Gets or sets the org price currency usd.
        /// </summary>
        /// <value>
        /// The org price currency usd.
        /// </value>
        public decimal RemainingAmount { get; set; }

        /// <summary>
        /// Gets or sets the org price currency usd.
        /// </summary>
        /// <value>
        /// The org price currency usd.
        /// </value>
        public decimal OrgPrice { get; set; }

        /// <summary>
        /// Gets or sets the total org price usd.
        /// </summary>
        /// <value>
        /// The total org price usd.
        /// </value>
        public decimal OrgPriceUsd { get; set; }


        /// <summary>
        /// Gets or sets the quantity invetory.
        /// </summary>
        /// <value>
        /// The quantity invetory.
        /// </value>
        public decimal OrgPriceCurrencyUsd { get; set; }

        /// <summary>
        /// Gets or sets the org price invetory.
        /// </summary>
        /// <value>
        /// The org price invetory.
        /// </value>
        public decimal OrgPriceDifference { get; set; }

        /// <summary>
        /// Gets or sets the org price currency invetory usd.
        /// </summary>
        /// <value>
        /// The org price currency invetory usd.
        /// </value>
        public decimal OrgPriceDifferenceUsd { get; set; }

        /// <summary>
        /// Gets or sets the org price invetory usd.
        /// </summary>
        /// <value>
        /// The org price invetory usd.
        /// </value>
        public decimal OrgPriceCurrencyDifferenceUsd { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }
    }
}

/***********************************************************************
 * <copyright file="FixedAssetFAInventoryCarModel.cs.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   THODD
 * Email:    thodd@buca.vn
 * Website:
 * Create Date: 09 December 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;

namespace TSD.AccountingSoft.Model.BusinessObjects.Report.FixedAsset
{
    public class FixedAssetFAInventoryCarModel
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
        /// Gets or sets the fixed asset code.
        /// </summary>
        /// <value>
        /// The fixed asset code.
        /// </value>
        public string FixedAssetCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the fixed asset.
        /// </summary>
        /// <value>
        /// The name of the fixed asset.
        /// </value>
        public string CountryProduction { get; set; }

        /// <summary>
        /// Gets or sets the fixed asset code.
        /// </summary>
        /// <value>
        /// The fixed asset code.
        /// </value>
        public string SerialNumber { get; set; }

        /// <summary>
        /// Gets or sets the brand.
        /// </summary>
        /// <value>
        /// The brand.
        /// </value>
        public string Brand { get; set; }

        /// <summary>
        /// Gets or sets the org price.
        /// </summary>
        /// <value>
        /// The org price.
        /// </value>
        public string ControlPlate { get; set; }


        /// <summary>
        /// Gets or sets the fixed asset code.
        /// </summary>
        /// <value>
        /// The fixed asset code.
        /// </value>
        public int NumberOfSeat { get; set; }

        /// <summary>
        /// Gets or sets the org price.
        /// </summary>
        /// <value>
        /// The org price.
        /// </value>
        public int ProductionYear { get; set; }

        /// <summary>
        /// Gets or sets the year of using.
        /// </summary>
        /// <value>
        /// The year of using.
        /// </value>
        public DateTime UsedDate { get; set; }

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
        /// Gets or sets the org price currency difference usd.
        /// </summary>
        /// <value>
        /// The org price currency difference usd.
        /// </value>
        public decimal OrgPriceCurrencyDifferenceUsd { get; set; }

        /// <summary>
        /// Gets or sets the remaining amount.
        /// </summary>
        /// <value>
        /// The remaining amount.
        /// </value>
        public decimal RemainingAmount { get; set; }

        /// <summary>
        /// Gets or sets the car1.
        /// </summary>
        /// <value>
        /// The car1.
        /// </value>
        public string Car1 { get; set; }

        /// <summary>
        /// Gets or sets the car2.
        /// </summary>
        /// <value>
        /// The car2.
        /// </value>
        public string Car2 { get; set; }

        /// <summary>
        /// Gets or sets the car.
        /// </summary>
        /// <value>
        /// The car.
        /// </value>
        public string Car { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }
    }
}

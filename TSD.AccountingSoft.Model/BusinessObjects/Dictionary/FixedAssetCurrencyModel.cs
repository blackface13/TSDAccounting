/***********************************************************************
 * <copyright file="FixedAssetCurrencyModel.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 23 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

namespace TSD.AccountingSoft.Model.BusinessObjects.Dictionary
{
    /// <summary>
    /// FixedAssetCurrencyModel
    /// </summary>
    public class FixedAssetCurrencyModel
    {
        /// <summary>
        /// Gets or sets the fixed asset currency identifier.
        /// </summary>
        /// <value>
        /// The fixed asset currency identifier.
        /// </value>
        public int FixedAssetCurrencyId { get; set; }

        /// <summary>
        /// Gets or sets the fixed asset identifier.
        /// </summary>
        /// <value>
        /// The fixed asset identifier.
        /// </value>
        public int FixedAssetId { get; set; }

        /// <summary>
        /// Gets or sets the currency code.
        /// </summary>
        /// <value>
        /// The currency code.
        /// </value>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets the exchange rate.
        /// </summary>
        /// <value>
        /// The exchange rate.
        /// </value>
        public float ExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets the unit price.
        /// </summary>
        /// <value>
        /// The unit price.
        /// </value>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets the org price.
        /// </summary>
        /// <value>
        /// The org price.
        /// </value>
        public decimal OrgPrice { get; set; }

        /// <summary>
        /// Gets or sets the accum depreciation amount.
        /// </summary>
        /// <value>
        /// The accum depreciation amount.
        /// </value>
        public decimal AccumDepreciationAmount { get; set; }

        /// <summary>
        /// Gets or sets the remaining amount.
        /// </summary>
        /// <value>
        /// The remaining amount.
        /// </value>
        public decimal RemainingAmount { get; set; }

        /// <summary>
        /// Gets or sets the annual depreciation amount.
        /// </summary>
        /// <value>
        /// The annual depreciation amount.
        /// </value>
        public decimal AnnualDepreciationAmount { get; set; }

        /// <summary>
        /// Gets or sets the unit price usd.
        /// </summary>
        /// <value>
        /// The unit price usd.
        /// </value>
        public decimal UnitPriceUSD { get; set; }

        /// <summary>
        /// Gets or sets the org price usd.
        /// </summary>
        /// <value>
        /// The org price usd.
        /// </value>
        public decimal OrgPriceUSD { get; set; }

        /// <summary>
        /// Gets or sets the accum depreciation amount usd.
        /// </summary>
        /// <value>
        /// The accum depreciation amount usd.
        /// </value>
        public decimal AccumDepreciationAmountUSD { get; set; }

        /// <summary>
        /// Gets or sets the remaining amount usd.
        /// </summary>
        /// <value>
        /// The remaining amount usd.
        /// </value>
        public decimal RemainingAmountUSD { get; set; }

        /// <summary>
        /// Gets or sets the annual depreciation amount usd.
        /// </summary>
        /// <value>
        /// The annual depreciation amount usd.
        /// </value>
        public decimal AnnualDepreciationAmountUSD { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }
    }
}

/***********************************************************************
 * <copyright file="FixedAssetVoucherModel.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 10 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/


namespace TSD.AccountingSoft.Model.BusinessObjects.FixedAsset
{
    /// <summary>
    /// class FixedAssetVoucherModel
    /// </summary>
    public class FixedAssetVoucherModel
    {
        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>
        /// The reference identifier.
        /// </value>
        public long RefId { get; set; }

        /// <summary>
        /// Gets or sets the reference type identifier.
        /// </summary>
        /// <value>
        /// The reference type identifier.
        /// </value>
        public int RefTypeId { get; set; }

        /// <summary>
        /// Gets or sets the reference no.
        /// </summary>
        /// <value>
        /// The reference no.
        /// </value>
        public string RefNo { get; set; }

        /// <summary>
        /// Gets or sets the posted date.
        /// </summary>
        /// <value>
        /// The posted date.
        /// </value>
        public string PostedDate { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the account number.
        /// </summary>
        /// <value>
        /// The account number.
        /// </value>
        public string AccountNumber { get; set; }

        /// <summary>
        /// Gets or sets the corresponding account number.
        /// </summary>
        /// <value>
        /// The corresponding account number.
        /// </value>
        public string CorrespondingAccountNumber { get; set; }

        /// <summary>
        /// Gets or sets the amount oc.
        /// </summary>
        /// <value>
        /// The amount oc.
        /// </value>
        public decimal AmountOC { get; set; }

        /// <summary>
        /// Gets or sets the amount exchange.
        /// </summary>
        /// <value>
        /// The amount exchange.
        /// </value>
        public decimal AmountExchange { get; set; }

        /// <summary>
        /// Gets or sets the accum depreciation amount.
        /// </summary>
        /// <value>
        /// The accum depreciation amount.
        /// </value>
        public decimal AccumDepreciationAmount { get; set; }

        /// <summary>
        /// Gets or sets the accum depreciation amount usd.
        /// </summary>
        /// <value>
        /// The accum depreciation amount usd.
        /// </value>
        public decimal AccumDepreciationAmountUSD { get; set; }

        /// <summary>
        /// Gets or sets the remaining amount.
        /// </summary>
        /// <value>
        /// The remaining amount.
        /// </value>
        public decimal RemainingAmount { get; set; }

        /// <summary>
        /// Gets or sets the remaining amount usd.
        /// </summary>
        /// <value>
        /// The remaining amount usd.
        /// </value>
        public decimal RemainingAmountUSD { get; set; }

        /// <summary>
        /// Gets or sets the annual depreciation amount.
        /// </summary>
        /// <value>
        /// The annual depreciation amount.
        /// </value>
        public decimal AnnualDepreciationAmount { get; set; }

        /// <summary>
        /// Gets or sets the annual depreciation amount usd.
        /// </summary>
        /// <value>
        /// The annual depreciation amount usd.
        /// </value>
        public decimal AnnualDepreciationAmountUSD { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.View.FixedAsset
{
    interface IFixedAssetVoucherView : IView
    {
        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>
        /// The reference identifier.
        /// </value>
        long RefId { get; set; }

        /// <summary>
        /// Gets or sets the reference type identifier.
        /// </summary>
        /// <value>
        /// The reference type identifier.
        /// </value>
        int RefTypeId { get; set; }

        /// <summary>
        /// Gets or sets the reference no.
        /// </summary>
        /// <value>
        /// The reference no.
        /// </value>
        string RefNo { get; set; }

        /// <summary>
        /// Gets or sets the posted date.
        /// </summary>
        /// <value>
        /// The posted date.
        /// </value>
        string PostedDate { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        string Description { get; set; }

        /// <summary>
        /// Gets or sets the account number.
        /// </summary>
        /// <value>
        /// The account number.
        /// </value>
        string AccountNumber { get; set; }

        /// <summary>
        /// Gets or sets the corresponding account number.
        /// </summary>
        /// <value>
        /// The corresponding account number.
        /// </value>
        string CorrespondingAccountNumber { get; set; }

        /// <summary>
        /// Gets or sets the amount oc.
        /// </summary>
        /// <value>
        /// The amount oc.
        /// </value>
        decimal AmountOC { get; set; }

        /// <summary>
        /// Gets or sets the amount exchange.
        /// </summary>
        /// <value>
        /// The amount exchange.
        /// </value>
        decimal AmountExchange { get; set; }

        /// <summary>
        /// Gets or sets the accum depreciation amount.
        /// </summary>
        /// <value>
        /// The accum depreciation amount.
        /// </value>
        decimal AccumDepreciationAmount { get; set; }

        /// <summary>
        /// Gets or sets the accum depreciation amount usd.
        /// </summary>
        /// <value>
        /// The accum depreciation amount usd.
        /// </value>
        decimal AccumDepreciationAmountUSD { get; set; }

        /// <summary>
        /// Gets or sets the remaining amount.
        /// </summary>
        /// <value>
        /// The remaining amount.
        /// </value>
        decimal RemainingAmount { get; set; }

        /// <summary>
        /// Gets or sets the remaining amount usd.
        /// </summary>
        /// <value>
        /// The remaining amount usd.
        /// </value>
        decimal RemainingAmountUSD { get; set; }

        /// <summary>
        /// Gets or sets the annual depreciation amount.
        /// </summary>
        /// <value>
        /// The annual depreciation amount.
        /// </value>
        decimal AnnualDepreciationAmount { get; set; }

        /// <summary>
        /// Gets or sets the annual depreciation amount usd.
        /// </summary>
        /// <value>
        /// The annual depreciation amount usd.
        /// </value>
        decimal AnnualDepreciationAmountUSD { get; set; }
    }
}

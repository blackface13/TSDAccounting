/***********************************************************************
 * <copyright file="IFixedAssetDecrementView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Thursday, April 10, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  07/03/2014       Author    Tudt           Description: Coding standard
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using TSD.AccountingSoft.Model.BusinessObjects.FixedAsset;


namespace TSD.AccountingSoft.View.FixedAsset
{
    /// <summary>
    /// interface IFixedAssetDecrementView
    /// </summary>
    public interface IFixedAssetDecrementView : IView
    {
        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>The reference identifier.</value>
        long RefId { get; set; }

        /// <summary>
        /// Gets or sets the type of the reference.
        /// </summary>
        /// <value>The type of the reference.</value>
        int RefTypeId { get; set; }

        /// <summary>
        /// Gets or sets the reference date.
        /// </summary>
        /// <value>The reference date.</value>
        string RefDate { get; set; }

        /// <summary>
        /// Gets or sets the posted date.
        /// </summary>
        /// <value>The posted date.</value>
        string PostedDate { get; set; }

        /// <summary>
        /// Gets or sets the reference no.
        /// </summary>
        /// <value>The reference no.</value>
        string RefNo { get; set; }

        /// <summary>
        /// Gets or sets the type of the accounting object.
        /// </summary>
        /// <value>The type of the accounting object.</value>
        int? AccountingObjectType { get; set; }

        /// <summary>
        /// Gets or sets the accounting object identifier.
        /// </summary>
        /// <value>The accounting object identifier.</value>
        int? AccountingObjectId { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>The customer identifier.</value>
        int? CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the vendor identifier.
        /// </summary>
        /// <value>The vendor identifier.</value>
        int? VendorId { get; set; }

        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>The employee identifier.</value>
        int? EmployeeId { get; set; }

        int? BankId { get; set; }

        /// <summary>
        /// Gets or sets the currency code.
        /// </summary>
        /// <value>The currency code.</value>
        string CurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets the exchange rate.
        /// </summary>
        /// <value>The exchange rate.</value>
        decimal ExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets the total amount oc.
        /// </summary>
        /// <value>The total amount oc.</value>
        decimal TotalAmountOc { get; set; }

        /// <summary>
        /// Gets or sets the total amount exchange.
        /// </summary>
        /// <value>The total amount exchange.</value>
        decimal TotalAmountExchange { get; set; }

        /// <summary>
        /// Gets or sets the journal memo.
        /// </summary>
        /// <value>The journal memo.</value>
        string JournalMemo { get; set; }

        /// <summary>
        /// Gets or sets the document include.
        /// </summary>
        /// <value>
        /// The document include.
        /// </value>
        string DocumentInclude { get; set; }

        /// <summary>
        /// Gets or sets the trader.
        /// </summary>
        /// <value>
        /// The trader.
        /// </value>
        string Trader { get; set; }

        /// <summary>
        /// Gets or sets the estimate details.
        /// </summary>
        /// <value>
        /// The deposit details.
        /// </value>
        IList<FixedAssetDecrementDetailModel> FixedAssetDecrementDetails { get; set; }

        IList<FixedAssetDecrementDetailParallelModel> FixedAssetDecrementDetailParallels { get; set; }
    }
}

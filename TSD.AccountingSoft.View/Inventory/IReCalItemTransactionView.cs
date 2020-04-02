/***********************************************************************
 * <copyright file="IReCalItemTransactionView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:  TuanMH
 * Email:    TuanMH@buca.vn
 * Website:
 * Create Date: 23 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;


namespace TSD.AccountingSoft.View.Inventory
{
    /// <summary>
    /// IReCalItemTransactionView
    /// </summary>
    public interface IReCalItemTransactionView
    {
        /// <summary>
        /// Gets or sets from date.
        /// </summary>
        /// <value>
        /// From date.
        /// </value>
        string FromDate { get; set; }

        /// <summary>
        /// Gets or sets the reference date.
        /// </summary>
        /// <value>
        /// The reference date.
        /// </value>
        string ToDate { get; set; }

        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>
        /// The employee identifier.
        /// </value>
        List<int> StockId { get; }

        /// <summary>
        /// Gets or sets the currency code.
        /// </summary>
        /// <value>
        /// The currency code.
        /// </value>
        string CurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets the currency Decimal Digit.
        /// </summary>
        /// <value>
        /// The currency Decimal Digit.
        /// </value>
        int currencyDecimalDigits { get; set; }
    }
}

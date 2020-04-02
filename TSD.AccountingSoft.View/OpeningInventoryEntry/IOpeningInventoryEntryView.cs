/***********************************************************************
 * <copyright file="IOpeningAccountEntryView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 28 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using TSD.AccountingSoft.Model.BusinessObjects.Opening;

namespace TSD.AccountingSoft.View.OpeningInventoryEntry
{
    /// <summary>
    /// interface IOpeningAccountEntryView
    /// </summary>
    public interface IOpeningInventoryEntryView : IView
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
        DateTime PostedDate { get; set; }

        /// <summary>
        /// Gets or sets the account code.
        /// </summary>
        /// <value>
        /// The account code.
        /// </value>
        string AccountNumber { get; set; }

        /// <summary>
        /// Gets or sets the name of the account.
        /// </summary>
        /// <value>
        /// The name of the account.
        /// </value>
        decimal UnitPriceOc { get; set; }

        /// <summary>
        /// Gets or sets the account identifier.
        /// </summary>
        /// <value>
        /// The account identifier.
        /// </value>
        decimal UnitPriceExchange { get; set; }

        /// <summary>
        /// Gets or sets the parent identifier.
        /// </summary>
        /// <value>
        /// The parent identifier.
        /// </value>
        decimal AmountOc { get; set; }

        /// <summary>
        /// Gets or sets the total account beginning debit amount oc.
        /// </summary>
        /// <value>
        /// The total account beginning debit amount oc.
        /// </value>
        decimal AmountExchange { get; set; }

        /// <summary>
        /// Gets or sets the total account beginning credit amount oc.
        /// </summary>
        /// <value>
        /// The total account beginning credit amount oc.
        /// </value>
        decimal ExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets the total debit amount oc.
        /// </summary>
        /// <value>
        /// The total debit amount oc.
        /// </value>
        int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the total credit amount oc.
        /// </summary>
        /// <value>
        /// The total credit amount oc.
        /// </value>
        string CurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets the total account beginning debit amount exchange.
        /// </summary>
        /// <value>
        /// The total account beginning debit amount exchange.
        /// </value>
        int StockId { get; set; }

        /// <summary>
        /// Gets or sets the total account beginning credit amount exchange.
        /// </summary>
        /// <value>
        /// The total account beginning credit amount exchange.
        /// </value>
        int InventoryItemId { get; set; }

        /// <summary>
        /// Gets or sets the opening inventory entries.
        /// </summary>
        /// <value>
        /// The opening inventory entries.
        /// </value>
        IList<OpeningInventoryEntryModel> OpeningInventoryEntries { get; set; }
    }
}

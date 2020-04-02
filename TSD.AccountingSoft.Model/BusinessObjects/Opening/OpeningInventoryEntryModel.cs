/***********************************************************************
 * <copyright file="OpeningAccountEntryEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 24 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;


namespace TSD.AccountingSoft.Model.BusinessObjects.Opening
{
    /// <summary>
    /// 
    /// </summary>
    public class OpeningInventoryEntryModel
    {
        /// <summary>
        /// Gets or sets the account identifier.
        /// </summary>
        /// <value>
        /// The account identifier.
        /// </value>
        public int? AccountId { get; set; }

        /// <summary>
        /// Gets or sets the parent identifier.
        /// </summary>
        /// <value>
        /// The parent identifier.
        /// </value>
        public int? ParentId { get; set; }

        /// <summary>
        /// Gets or sets the name of the account.
        /// </summary>
        /// <value>
        /// The name of the account.
        /// </value>
        public string AccountName { get; set; }

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
        public DateTime PostedDate { get; set; }

        /// <summary>
        /// Gets or sets the account code.
        /// </summary>
        /// <value>
        /// The account code.
        /// </value>
        public string AccountNumber { get; set; }

        /// <summary>
        /// Gets or sets the total account beginning debit amount exchange.
        /// </summary>
        /// <value>
        /// The total account beginning debit amount exchange.
        /// </value>
        public int StockId { get; set; }

        /// <summary>
        /// Gets or sets the total account beginning credit amount exchange.
        /// </summary>
        /// <value>
        /// The total account beginning credit amount exchange.
        /// </value>
        public int InventoryItemId { get; set; }

        /// <summary>
        /// Gets or sets the name of the account.
        /// </summary>
        /// <value>
        /// The name of the account.
        /// </value>
        public decimal UnitPriceOc { get; set; }

        /// <summary>
        /// Gets or sets the account identifier.
        /// </summary>
        /// <value>
        /// The account identifier.
        /// </value>
        public decimal UnitPriceExchange { get; set; }

        /// <summary>
        /// Gets or sets the parent identifier.
        /// </summary>
        /// <value>
        /// The parent identifier.
        /// </value>
        public decimal AmountOc { get; set; }

        /// <summary>
        /// Gets or sets the total account beginning debit amount oc.
        /// </summary>
        /// <value>
        /// The total account beginning debit amount oc.
        /// </value>
        public decimal AmountExchange { get; set; }

        /// <summary>
        /// Gets or sets the total account beginning credit amount oc.
        /// </summary>
        /// <value>
        /// The total account beginning credit amount oc.
        /// </value>
        public decimal ExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets the total debit amount oc.
        /// </summary>
        /// <value>
        /// The total debit amount oc.
        /// </value>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the total credit amount oc.
        /// </summary>
        /// <value>
        /// The total credit amount oc.
        /// </value>
        public string CurrencyCode { get; set; }
    }
}
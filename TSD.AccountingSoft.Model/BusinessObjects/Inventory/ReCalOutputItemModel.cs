using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TSD.AccountingSoft.BusinessEntities.Business.Inventory;

namespace TSD.AccountingSoft.Model.BusinessObjects.Inventory
{
    public class ItemTransactionModel
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
        /// Gets or sets the reference date.
        /// </summary>
        /// <value>
        /// The reference date.
        /// </value>
        public string RefDate { get; set; }

        /// <summary>
        /// Gets or sets the posted date.
        /// </summary>
        /// <value>
        /// The posted date.
        /// </value>
        public string PostedDate { get; set; }

        /// <summary>
        /// Gets or sets the accounting object identifier.
        /// </summary>
        /// <value>
        /// The accounting object identifier.
        /// </value>
        public int? AccountingObjectId { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>
        /// The customer identifier.
        /// </value>
        public int? CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the vendor identifier.
        /// </summary>
        /// <value>
        /// The vendor identifier.
        /// </value>
        public int? VendorId { get; set; }

        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>
        /// The employee identifier.
        /// </value>
        public int? EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets the trader.
        /// </summary>
        /// <value>
        /// The trader.
        /// </value>
        public string Trader { get; set; }

        /// <summary>
        /// Gets or sets the StockId.
        /// </summary>
        /// <value>
        /// The StockId.
        /// </value>
        public int StockId { get; set; } //ColumnPosition ???

        /// <summary>
        /// Gets or sets the currency code.
        /// </summary>
        /// <value>
        /// The currency code.
        /// </value>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public Decimal TotalAmount { get; set; }

        /// <summary>
        /// Gets or sets the exchange rate.
        /// </summary>
        /// <value>
        /// The exchange rate.
        /// </value>
        public decimal ExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets the amount exchange.
        /// </summary>
        /// <value>
        /// The amount exchange.
        /// </value>
        public decimal TotalAmountExchange { get; set; }

        /// <summary>
        /// Gets or sets the journal memo.
        /// </summary>
        /// <value>
        /// The journal memo.
        /// </value>
        public string JournalMemo { get; set; }

        /// <summary>
        /// Gets or sets the document include.
        /// </summary>
        /// <value>
        /// The document include.
        /// </value>
        public string DocumentInclude { get; set; }

        /// <summary>
        /// Gets or sets the object identifier.
        /// </summary>
        /// <value>
        /// The object identifier.
        /// </value>
        public int? ObjectId { get; set; }

        /// <summary>
        /// Gets or sets the cash detail.
        /// </summary>
        /// <value>
        /// The cash detail.
        /// </value>
        /// 
        public string TaxCode { get; set; } 

        public IList<ItemTransactionDetailModel> ItemTransactionDetails { get; set; }
    }
}

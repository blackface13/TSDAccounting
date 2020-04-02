/***********************************************************************
 * <copyright file="C30BBEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: 13 June 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/


namespace TSD.AccountingSoft.BusinessEntities.Report.Voucher
{

    /// <summary>
    /// C30BBEntity
    /// </summary>
    public class C30BBEntity : BusinessEntities 
    {

        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>
        /// The reference identifier.
        /// </value>
        public int RefId { get; set; }
        /// <summary>
        /// Gets or sets the reference no.
        /// </summary>
        /// <value>
        /// The reference no.
        /// </value>
        public string RefNo { get; set; }
        /// <summary>
        /// Gets or sets the corresponding acount number.
        /// </summary>
        /// <value>
        /// The corresponding acount number.
        /// </value>
        public string CorrespondingAccountNumber { get; set; }
        /// <summary>
        /// Gets or sets the account number.
        /// </summary>
        /// <value>
        /// The account number.
        /// </value>
        public string AccountNumber { get; set; }
        /// <summary>
        /// Gets or sets the posted date.
        /// </summary>
        /// <value>
        /// The posted date.
        /// </value>
        public string PostedDate { get; set; }
        public string RefDate { get; set; }
        /// <summary>
        /// Gets or sets the trader.
        /// </summary>
        /// <value>
        /// The trader.
        /// </value>
        public string Trader { get; set; }

        /// <summary>
        /// Gets or sets the Contact Name.
        /// </summary>
        /// <value>
        /// The Contact Name.
        /// </value>
        public string ContactName { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        public string Address { get; set; }
        /// <summary>
        /// Gets or sets the journal memo.
        /// </summary>
        /// <value>
        /// The journal memo.
        /// </value>
        public string JournalMemo { get; set; }
        /// <summary>
        /// Gets or sets the total amount.
        /// </summary>
        /// <value>
        /// The total amount.
        /// </value>
        public decimal TotalAmount { get; set; }
        /// <summary>
        /// Gets or sets the total amount exchange.
        /// </summary>
        /// <value>
        /// The total amount exchange.
        /// </value>
        public decimal TotalAmountExchange { get; set; }
        /// <summary>
        /// Gets or sets the exchange rate.
        /// </summary>
        /// <value>
        /// The exchange rate.
        /// </value>
        public decimal ExchangeRate { get; set; }
        /// <summary>
        /// Gets or sets the document include.
        /// </summary>
        /// <value>
        /// The document include.
        /// </value>
        public string DocumentInclude { get; set; }

        public string CurrencyCode { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is select.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is select; otherwise, <c>false</c>.
        /// </value>
        public bool  IsSelect { get; set; }
    }
}

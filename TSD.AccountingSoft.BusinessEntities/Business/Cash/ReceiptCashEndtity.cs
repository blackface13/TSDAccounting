/***********************************************************************
 * <copyright file="ReceiptCashEndtity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Hoàng Bích Sơn
 * Email:    sonhb@buca.vn
 * Website:
 * Create Date: Tuesday, March 18, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using TSD.AccountingSoft.BusinessEntities.BusinessRules;


namespace TSD.AccountingSoft.BusinessEntities.Business.Cash
{

    /// <summary>
    /// ReceiptCashEndtity class
    /// </summary>
    public class ReceiptCashEntity: BusinessEntities
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ReceiptCashEntity"/> class.
        /// </summary>
        public ReceiptCashEntity()
        {
            AddRule(new ValidateId("RefId"));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReceiptCashEntity" /> class.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="refNo">The reference no.</param>
        /// <param name="refDate">The reference date.</param>
        /// <param name="postedDate">The posted date.</param>
        /// <param name="accountingObjectId">The accounting object identifier.</param>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="vendorId">The vendor identifier.</param>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="trader">The trader.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="totalAmount">The total amount.</param>
        /// <param name="exchangeRate">The exchange rate.</param>
        /// <param name="totalAmountExchange">The total amount exchange.</param>
        /// <param name="journalMemo">The journal memo.</param>
        /// <param name="documentInclude">The document include.</param>
        /// <param name="objectId">The object identifier.</param>
        public ReceiptCashEntity(long refId, int refTypeId, string refNo, DateTime refDate, DateTime postedDate, int accountingObjectId, int customerId, int vendorId, int employeeId, string trader, string currencyCode, string accountNumber, string totalAmount, string exchangeRate, string totalAmountExchange, string journalMemo, string documentInclude, int objectId)
        {
            RefId = refId;
            RefTypeId = refTypeId;
            RefNo = refNo;
            RefDate = refDate;
            PostedDate = postedDate;
            AccountingObjectId = accountingObjectId;
            CustomerId = customerId;
            VendorId = vendorId;
            EmployeeId = employeeId;
            Trader = trader;
            CurrencyCode = currencyCode;
            AccountNumber = accountNumber;
            TotalAmount = totalAmount;
            ExchangeRate = exchangeRate;
            TotalAmountExchange = totalAmountExchange;
            JournalMemo = journalMemo;
            DocumentInclude = documentInclude;
            ObjectId = objectId;
        }

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
        public DateTime RefDate { get; set; }

        /// <summary>
        /// Gets or sets the posted date.
        /// </summary>
        /// <value>
        /// The posted date.
        /// </value>
        public DateTime PostedDate { get; set; }

        /// <summary>
        /// Gets or sets the accounting object identifier.
        /// </summary>
        /// <value>
        /// The accounting object identifier.
        /// </value>
        public int AccountingObjectId { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>
        /// The customer identifier.
        /// </value>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the vendor identifier.
        /// </summary>
        /// <value>
        /// The vendor identifier.
        /// </value>
        public int VendorId { get; set; }

        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>
        /// The employee identifier.
        /// </value>
        public int EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets the trader.
        /// </summary>
        /// <value>
        /// The trader.
        /// </value>
        public string Trader { get; set; }

        /// <summary>
        /// Gets or sets the currency code.
        /// </summary>
        /// <value>
        /// The currency code.
        /// </value>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets the account number.
        /// </summary>
        /// <value>
        /// The account number.
        /// </value>
        public string AccountNumber { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public string TotalAmount { get; set; }

        /// <summary>
        /// Gets or sets the exchange rate.
        /// </summary>
        /// <value>
        /// The exchange rate.
        /// </value>
        public string ExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets the amount exchange.
        /// </summary>
        /// <value>
        /// The amount exchange.
        /// </value>
        public string TotalAmountExchange { get; set; }

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
        public int ObjectId { get; set; }
    }
}

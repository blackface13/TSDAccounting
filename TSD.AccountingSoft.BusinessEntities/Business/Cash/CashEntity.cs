/***********************************************************************
 * <copyright file="CashEntity.cs" company="BUCA JSC">
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
using System.Collections.Generic;
using TSD.AccountingSoft.BusinessEntities.BusinessRules;


namespace TSD.AccountingSoft.BusinessEntities.Business.Cash
{
    /// <summary>
    /// PaymentCashEntity class
    /// </summary>
    public class CashEntity : BusinessEntities
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="CashEntity"/> class.
        /// </summary>
        public CashEntity()
        {
            AddRule(new ValidateId("RefId"));

            CashParalellDetails = new List<CashParalellDetailEntity>();
        }

        public CashEntity(long refId, int refTypeId, string refNo, DateTime refDate, DateTime postedDate, int? accountingObjectId, int? customerId, int? vendorId, string trader, string currencyCode, string accountNumber, decimal totalAmount, decimal exchangeRate, decimal totalAmountExchange, string journalMemo, string documentInclude, int accountingObjectType, List<CashDetailEntity> cashDetails, int? employeeId,int? bankId)
        {
            RefId = refId;
            RefTypeId = refTypeId;
            RefNo = refNo;
            RefDate = refDate;
            PostedDate = postedDate;
            AccountingObjectId = accountingObjectId;
            CustomerId = customerId;
            VendorId = vendorId;
            Trader = trader;
            CurrencyCode = currencyCode;
            AccountNumber = accountNumber;
            TotalAmount = totalAmount;
            ExchangeRate = exchangeRate;
            TotalAmountExchange = totalAmountExchange;
            JournalMemo = journalMemo;
            DocumentInclude = documentInclude;
            AccountingObjectType = accountingObjectType;
            CashDetails = cashDetails;
            EmployeeId = employeeId;
            BankId = bankId;
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

        public int? BankId { get; set; }

        public string BankAccount { get; set; }

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
        public int? AccountingObjectType { get; set; }

        public bool IsIncludeCharge { get; set; }

        /// <summary>
        /// Gets or sets the cash detail.
        /// </summary>
        /// <value>
        /// The cash detail.
        /// </value>
        public List<CashDetailEntity> CashDetails { get; set; }

        public List<CashParalellDetailEntity> CashParalellDetails { get; set; }
    }
}

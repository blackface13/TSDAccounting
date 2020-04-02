/***********************************************************************
 * <copyright file="FADecreasementEntity.cs" company="BUCA JSC">
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
using TSD.AccountingSoft.BusinessEntities.BusinessRules;


namespace TSD.AccountingSoft.BusinessEntities.Business.FixedAssetDecrement
{
    /// <summary>
    /// class FADecreasementEntity
    /// </summary>
    public class FADecrementEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FADecrementEntity"/> class.
        /// </summary>
        public FADecrementEntity()
        {
            AddRule(new ValidateRequired("RefNo"));
            AddRule(new ValidateRequired("RefDate"));
            AddRule(new ValidateRequired("PostedDate"));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FADecrementEntity"/> class.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="refDate">The reference date.</param>
        /// <param name="postedDate">The posted date.</param>
        /// <param name="refNo">The reference no.</param>
        /// <param name="accountingObjectType">Type of the accounting object.</param>
        /// <param name="accountingObjectId">The accounting object identifier.</param>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="vendorId">The vendor identifier.</param>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="exchangeRate">The exchange rate.</param>
        /// <param name="totalAmountOC">The total amount oc.</param>
        /// <param name="totalAmountExchange">The total amount exchange.</param>
        /// <param name="journalMemo">The journal memo.</param>
        public FADecrementEntity(long refId, int refTypeId, DateTime refDate, DateTime postedDate, string refNo,
                             int? accountingObjectType, int? accountingObjectId,
                             int? customerId, int? vendorId, int? employeeId,
                             string currencyCode, decimal exchangeRate, decimal totalAmountOC,
                             decimal totalAmountExchange, string journalMemo,int? bankId)
            : this()
        {
            RefId = refId;
            RefTypeId = refTypeId;
            RefDate = refDate;
            PostedDate = postedDate;
            RefNo = refNo;
            AccountingObjectType = accountingObjectType;
            AccountingObjectId = accountingObjectId;
            CustomerId = customerId;
            VendorId = vendorId;
            EmployeeId = employeeId;
            CurrencyCode = currencyCode;
            ExchangeRate = exchangeRate;
            TotalAmountOC = totalAmountOC;
            TotalAmountExchange = totalAmountExchange;
            JournalMemo = journalMemo;
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
        /// Gets or sets the type of the reference.
        /// </summary>
        /// <value>
        /// The type of the reference.
        /// </value>
        public int RefTypeId { get; set; }

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
        /// Gets or sets the reference no.
        /// </summary>
        /// <value>
        /// The reference no.
        /// </value>
        public string RefNo { get; set; }

        /// <summary>
        /// Gets or sets the type of the accounting object.
        /// </summary>
        /// <value>
        /// The type of the accounting object.
        /// </value>
        public int? AccountingObjectType { get; set; }

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

        public int? BankId { get; set; }
       
        /// <summary>
        /// Gets or sets the currency code.
        /// </summary>
        /// <value>
        /// The currency code.
        /// </value>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets the exchange rate.
        /// </summary>
        /// <value>
        /// The exchange rate.
        /// </value>
        public decimal ExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets the total amount oc.
        /// </summary>
        /// <value>
        /// The total amount oc.
        /// </value>
        public decimal TotalAmountOC { get; set; }

        /// <summary>
        /// Gets or sets the total amount exchange.
        /// </summary>
        /// <value>
        /// The total amount exchange.
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
        /// Gets or sets the trader.
        /// </summary>
        /// <value>
        /// The trader.
        /// </value>
        public string Trader { get; set; }

        /// <summary>
        /// Gets or sets the estimate details.
        /// </summary>
        /// <value>
        /// The deposit details.
        /// </value>
        public IList<FADecrementDetailEntity> FADecrementDetails { get; set; }
        public IList<FADecrementDetailParallelEntity> FADecrementDetailParallels { get; set; }
    }
}

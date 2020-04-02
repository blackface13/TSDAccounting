/***********************************************************************
 * <copyright file="OpeningAccountEntryDetailModel.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 25 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;


namespace TSD.AccountingSoft.Model.BusinessObjects.Opening
{
    /// <summary>
    /// OpeningAccountEntryDetailModel
    /// </summary>
    public class OpeningAccountEntryDetailModel
    {
        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>
        /// The reference identifier.
        /// </value>
        public long RefDetailId { get; set; }

        /// <summary>
        /// Gets or sets the reference type identifier.
        /// </summary>
        /// <value>
        /// The reference type identifier.
        /// </value>
        public int RefTypeId { get; set; }

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
        public string AccountCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the account.
        /// </summary>
        /// <value>
        /// The name of the account.
        /// </value>
        public string AccountName { get; set; }

        /// <summary>
        /// Gets or sets the account identifier.
        /// </summary>
        /// <value>
        /// The account identifier.
        /// </value>
        public int AccountId { get; set; }

        /// <summary>
        /// Gets or sets the parent identifier.
        /// </summary>
        /// <value>
        /// The parent identifier.
        /// </value>
        public int ParentId { get; set; }

        /// <summary>
        /// Gets or sets the account beginning debit amount oc.
        /// </summary>
        /// <value>
        /// The account beginning debit amount oc.
        /// </value>
        public decimal AccountBeginningDebitAmountOC { get; set; }

        /// <summary>
        /// Gets or sets the account beginning credit amount oc.
        /// </summary>
        /// <value>
        /// The account beginning credit amount oc.
        /// </value>
        public decimal AccountBeginningCreditAmountOC { get; set; }

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
        public float ExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets the debit amount oc.
        /// </summary>
        /// <value>
        /// The debit amount oc.
        /// </value>
        public decimal DebitAmountOC { get; set; }

        /// <summary>
        /// Gets or sets the credit amount oc.
        /// </summary>
        /// <value>
        /// The credit amount oc.
        /// </value>
        public decimal CreditAmountOC { get; set; }

        /// <summary>
        /// Gets or sets the account beginning debit amount exchange.
        /// </summary>
        /// <value>
        /// The account beginning debit amount exchange.
        /// </value>
        public decimal AccountBeginningDebitAmountExchange { get; set; }

        /// <summary>
        /// Gets or sets the account beginning credit amount exchange.
        /// </summary>
        /// <value>
        /// The account beginning credit amount exchange.
        /// </value>
        public decimal AccountBeginningCreditAmountExchange { get; set; }

        /// <summary>
        /// Gets or sets the debit amount exchange.
        /// </summary>
        /// <value>
        /// The debit amount exchange.
        /// </value>
        public decimal DebitAmountExchange { get; set; }

        /// <summary>
        /// Gets or sets the credit amount exchange.
        /// </summary>
        /// <value>
        /// The credit amount exchange.
        /// </value>
        public decimal CreditAmountExchange { get; set; }

        /// <summary>
        /// Gets or sets the budget source code.
        /// </summary>
        /// <value>
        /// The budget source code.
        /// </value>
        public string BudgetSourceCode { get; set; }

        /// <summary>
        /// Gets or sets the budget chapter code.
        /// </summary>
        /// <value>
        /// The budget chapter code.
        /// </value>
        public string BudgetChapterCode { get; set; }

        /// <summary>
        /// Gets or sets the budget category code.
        /// </summary>
        /// <value>
        /// The budget category code.
        /// </value>
        public string BudgetCategoryCode { get; set; }

        /// <summary>
        /// Gets or sets the budget group item code.
        /// </summary>
        /// <value>
        /// The budget group item code.
        /// </value>
        public string BudgetGroupItemCode { get; set; }

        /// <summary>
        /// Gets or sets the budget item code.
        /// </summary>
        /// <value>
        /// The budget item code.
        /// </value>
        public string BudgetItemCode { get; set; }

        /// <summary>
        /// Gets or sets the merger fund identifier.
        /// </summary>
        /// <value>
        /// The merger fund identifier.
        /// </value>
        public int? MergerFundId { get; set; }

        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>
        /// The employee identifier.
        /// </value>
        public int? EmployeeId { get; set; }

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
        /// Gets or sets the accounting object identifier.
        /// </summary>
        /// <value>
        /// The accounting object identifier.
        /// </value>
        public int? AccountingObjectId { get; set; }

        /// <summary>
        /// Gets or sets the project identifier.
        /// </summary>
        /// <value>
        /// The project identifier.
        /// </value>
        public int? ProjectId { get; set; }

        /// <summary>
        /// Gets or sets the bank identifier.
        /// </summary>
        /// <value>
        /// The bank identifier.
        /// </value>
        public int? BankId { get; set; }

        /// <summary>
        /// Gets or sets the account.
        /// </summary>
        /// <value>
        /// The account.
        /// </value>
        public AccountModel Account { get; set; }
    }
}
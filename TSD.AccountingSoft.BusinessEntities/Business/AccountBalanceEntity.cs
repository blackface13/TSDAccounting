/***********************************************************************
 * <copyright file="AccountBalanceEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 13 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using TSD.AccountingSoft.BusinessEntities.BusinessRules;


namespace TSD.AccountingSoft.BusinessEntities.Business
{
    /// <summary>
    /// AccountBalanceEntity
    /// </summary>
    public class AccountBalanceEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountBalanceEntity"/> class.
        /// </summary>
        public AccountBalanceEntity()
        {
            AddRule(new ValidateRequired("BalanceDate"));
            AddRule(new ValidateRequired("CurrencyCode"));
            AddRule(new ValidateRequired("AccountNumber"));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountBalanceEntity"/> class.
        /// </summary>
        /// <param name="accountBalanceId">The account balance identifier.</param>
        /// <param name="balanceDate">The balance date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="exchangeRate">The exchange rate.</param>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="movementDebitAmountOC">The movement debit amount oc.</param>
        /// <param name="movementDebitAmountExchange">The movement debit amount exchange.</param>
        /// <param name="movementCreditAmountOC">The movement credit amount oc.</param>
        /// <param name="movementCreditAmountExchange">The movement credit amount exchange.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="budgetCategoryCode">The budget category code.</param>
        /// <param name="budgetSourceCode">The budget source code.</param>
        /// <param name="budgetItemCode">The budget item code.</param>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="vendorId">The vendor identifier.</param>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="accountingObjectId">The accounting object identifier.</param>
        /// <param name="mergerFundId">The merger fund identifier.</param>
        /// <param name="bankId">The bank identifier.</param>
        /// <param name="projectId">The project identifier.</param>
        /// <param name="inventoryItemId">The inventory item identifier.</param>
        public AccountBalanceEntity(int accountBalanceId, DateTime balanceDate, string currencyCode, decimal exchangeRate, string accountNumber, decimal movementDebitAmountOC,
            decimal movementDebitAmountExchange, decimal movementCreditAmountOC, decimal movementCreditAmountExchange, string budgetChapterCode, string budgetCategoryCode,
            string budgetSourceCode, string budgetItemCode, int? customerId, int? vendorId, int? employeeId, int? accountingObjectId, int? mergerFundId, int? bankId, int? projectId, int? inventoryItemId)
            : this()
        {
            AccountBalanceId = accountBalanceId;
            BalanceDate = balanceDate;
            CurrencyCode = currencyCode;
            ExchangeRate = exchangeRate;
            AccountNumber = accountNumber;
            MovementCreditAmountExchange = movementCreditAmountExchange;
            MovementCreditAmountOC = movementCreditAmountOC;
            MovementDebitAmountExchange = movementDebitAmountExchange;
            MovementDebitAmountOC = movementDebitAmountOC;
            BudgetChapterCode = budgetChapterCode;
            BudgetCategoryCode = budgetCategoryCode;
            BudgetSourceCode = budgetSourceCode;
            BudgetItemCode = budgetItemCode;
            CustomerId = customerId;
            VendorId = vendorId;
            EmployeeId = employeeId;
            AccountingObjectId = accountingObjectId;
            MergerFundId = mergerFundId;
            BankId = bankId;
            ProjectId = projectId;
            InventoryItemId = inventoryItemId;
        }

        /// <summary>
        /// Gets or sets the account balance identifier.
        /// </summary>
        /// <value>
        /// The account balance identifier.
        /// </value>
        public int AccountBalanceId { get; set; }

        /// <summary>
        /// Gets or sets the balance date.
        /// </summary>
        /// <value>
        /// The balance date.
        /// </value>
        public DateTime BalanceDate { get; set; }

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
        /// Gets or sets the account number.
        /// </summary>
        /// <value>
        /// The account number.
        /// </value>
        public string AccountNumber { get; set; }

        /// <summary>
        /// Gets or sets the movement debit amount oc.
        /// </summary>
        /// <value>
        /// The movement debit amount oc.
        /// </value>
        public decimal MovementDebitAmountOC { get; set; }

        /// <summary>
        /// Gets or sets the movement debit amount exchange.
        /// </summary>
        /// <value>
        /// The movement debit amount exchange.
        /// </value>
        public decimal MovementDebitAmountExchange { get; set; }

        /// <summary>
        /// Gets or sets the movement credit amount oc.
        /// </summary>
        /// <value>
        /// The movement credit amount oc.
        /// </value>
        public decimal MovementCreditAmountOC { get; set; }

        /// <summary>
        /// Gets or sets the movement credit amount exchange.
        /// </summary>
        /// <value>
        /// The movement credit amount exchange.
        /// </value>
        public decimal MovementCreditAmountExchange { get; set; }

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
        /// Gets or sets the budget source code.
        /// </summary>
        /// <value>
        /// The budget source code.
        /// </value>
        public string BudgetSourceCode { get; set; }

        /// <summary>
        /// Gets or sets the budget item code.
        /// </summary>
        /// <value>
        /// The budget item code.
        /// </value>
        public string BudgetItemCode { get; set; }

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
        /// Gets or sets the accounting object identifier.
        /// </summary>
        /// <value>
        /// The accounting object identifier.
        /// </value>
        public int? AccountingObjectId { get; set; }

        /// <summary>
        /// Gets or sets the merger fund identifier.
        /// </summary>
        /// <value>
        /// The merger fund identifier.
        /// </value>
        public int? MergerFundId { get; set; }

        /// <summary>
        /// Gets or sets the bank identifier.
        /// </summary>
        /// <value>
        /// The bank identifier.
        /// </value>
        public int? BankId { get; set; }

        /// <summary>
        /// Gets or sets the project identifier.
        /// </summary>
        /// <value>
        /// The project identifier.
        /// </value>
        public int? ProjectId { get; set; }


        public int? InventoryItemId { get; set; }



    }
}

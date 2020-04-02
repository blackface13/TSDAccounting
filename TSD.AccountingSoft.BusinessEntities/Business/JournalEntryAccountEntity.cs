/***********************************************************************
 * <copyright file="JournalEntryAccount.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 20 March 2014
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
    /// 
    /// </summary>
    public class JournalEntryAccountEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JournalEntryAccountEntity"/> class.
        /// </summary>
        public JournalEntryAccountEntity()
        {
            AddRule(new ValidateRequired("RefId"));
            AddRule(new ValidateRequired("RefDetailId"));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JournalEntryAccountEntity" /> class.
        /// </summary>
        /// <param name="journalEntryId">The journal entry identifier.</param>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="refDetailId">The reference detail identifier.</param>
        /// <param name="refNo">The reference no.</param>
        /// <param name="refDate">The reference date.</param>
        /// <param name="postedDate">The posted date.</param>
        /// <param name="description">The description.</param>
        /// <param name="journalMemo">The journal memo.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="exchangeRate">The exchange rate.</param>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="correspondingAccountNumber">The corresponding account number.</param>
        /// <param name="quantity">The quantity.</param>
        /// <param name="journalType">Type of the journal.</param>
        /// <param name="amountOc">The amount oc.</param>
        /// <param name="amountExchange">The amount exchange.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="budgetCategoryCode">The budget category code.</param>
        /// <param name="budgetSourceCode">The budget source code.</param>
        /// <param name="budgetItemCode">The budget item code.</param>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="vendorId">The vendor identifier.</param>
        /// <param name="voucherTypeId">The voucher type identifier.</param>
        /// <param name="bankAccount">The bank account.</param>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="accountingObjectId">The accounting object identifier.</param>
        /// <param name="mergerFundId">The merger fund identifier.</param>
        /// <param name="projectId">The project identifier.</param>
        /// <param name="inventoryItemId">The inventory item identifier.</param>
        /// <param name="bankId">The bank identifier.</param>
        /// <param name="movementDebitAmountOC">The movement debit amount oc.</param>
        /// <param name="movementDebitAmountExchange">The movement debit amount exchange.</param>
        /// <param name="movementCreditAmountOC">The movement credit amount oc.</param>
        /// <param name="movementCreditAmountExchange">The movement credit amount exchange.</param>
        public JournalEntryAccountEntity(long journalEntryId, long refId, long refDetailId, string refNo, DateTime refDate, DateTime postedDate, string description, string journalMemo,
              string currencyCode, decimal exchangeRate, string accountNumber, string correspondingAccountNumber, int quantity, int journalType, decimal amountOc, decimal amountExchange,
              string budgetChapterCode, string budgetCategoryCode, string budgetSourceCode, string budgetItemCode, int? customerId, int? vendorId, int? voucherTypeId, string bankAccount,
              int? employeeId, int? accountingObjectId, int? mergerFundId, int? projectId, int? inventoryItemId, int? bankId, decimal movementDebitAmountOC, decimal movementDebitAmountExchange,
            decimal movementCreditAmountOC, decimal movementCreditAmountExchange)
            : this()
        {
            JournalEntryId = journalEntryId;
            RefId = refId;
            RefDetailId = refDetailId;
            RefTypeId = RefTypeId;
            RefNo = refNo;
            RefDate = refDate;
            PostedDate = postedDate;
            Description = description;
            JournalMemo = journalMemo;
            CurrencyCode = currencyCode;
            ExchangeRate = exchangeRate;
            AccountNumber = accountNumber;
            CorrespondingAccountNumber = correspondingAccountNumber;
            Quantity = quantity;
            JournalType = journalType;
            AmountOc = amountOc;
            AmountExchange = amountExchange;
            BudgetChapterCode = budgetChapterCode;
            BudgetCategoryCode = budgetCategoryCode;
            BudgetSourceCode = budgetSourceCode;
            BudgetItemCode = budgetItemCode;
            CustomerId = customerId;
            VendorId = vendorId;
            VoucherTypeId = voucherTypeId;
            BankAccount = bankAccount;
            EmployeeId = employeeId;
            AccountingObjectId = accountingObjectId;
            MergerFundId = mergerFundId;
            ProjectId = projectId;
            InventoryItemId = inventoryItemId;
            BankId = bankId;
            MovementDebitAmountOC = movementDebitAmountOC;
            MovementDebitAmountExchange = movementDebitAmountExchange;
            MovementCreditAmountOC = movementCreditAmountOC;
            MovementCreditAmountExchange = movementCreditAmountExchange;
        }

        /// <summary>
        /// Gets or sets the journal entry identifier.
        /// </summary>
        /// <value>
        /// The journal entry identifier.
        /// </value>
        public long JournalEntryId { get; set; }

        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>
        /// The reference identifier.
        /// </value>
        public long RefId { get; set; }

        /// <summary>
        /// Gets or sets the reference detail identifier.
        /// </summary>
        /// <value>
        /// The reference detail identifier.
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
        /// Gets or sets the post date.
        /// </summary>
        /// <value>
        /// The post date.
        /// </value>
        public DateTime PostedDate { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the journal memo.
        /// </summary>
        /// <value>
        /// The journal memo.
        /// </value>
        public string JournalMemo { get; set; }

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
        /// Gets or sets the corresponding account number.
        /// </summary>
        /// <value>
        /// The corresponding account number.
        /// </value>
        public string CorrespondingAccountNumber { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>
        /// The quantity.
        /// </value>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the type of the journal.
        /// </summary>
        /// <value>
        /// The type of the journal.
        /// </value>
        public int JournalType { get; set; }

        /// <summary>
        /// Gets or sets the amount oc.
        /// </summary>
        /// <value>
        /// The amount oc.
        /// </value>
        public decimal AmountOc { get; set; }

        /// <summary>
        /// Gets or sets the amount exchange.
        /// </summary>
        /// <value>
        /// The amount exchange.
        /// </value>
        public decimal AmountExchange { get; set; }

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
        /// Gets or sets the voucher type identifier.
        /// </summary>
        /// <value>
        /// The voucher type identifier.
        /// </value>
        public int? VoucherTypeId { get; set; }

        /// <summary>
        /// Gets or sets the bank account.
        /// </summary>
        /// <value>
        /// The bank account.
        /// </value>
        public string BankAccount { get; set; }

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
        /// Gets or sets the project identifier.
        /// </summary>
        /// <value>
        /// The project identifier.
        /// </value>
        public int? ProjectId { get; set; }

        /// <summary>
        /// Gets or sets the inventory item identifier.
        /// </summary>
        /// <value>
        /// The inventory item identifier.
        /// </value>
        public int? InventoryItemId { get; set; }

        /// <summary>
        /// Gets or sets the bank identifier.
        /// </summary>
        /// <value>
        /// The bank identifier.
        /// </value>
        public int? BankId { get; set; }

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
        /// To the list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public global::System.Collections.Generic.IList<JournalEntryAccountEntity> ToList()
        {
            throw new NotImplementedException();
        }
    }
}
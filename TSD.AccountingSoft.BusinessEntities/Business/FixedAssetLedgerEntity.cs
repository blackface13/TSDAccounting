/***********************************************************************
 * <copyright file="FixedAssetLedger.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 14 April 2014
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
    /// FixedAssetLedger
    /// </summary>
    public class FixedAssetLedgerEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FixedAssetLedgerEntity"/> class.
        /// </summary>
        public FixedAssetLedgerEntity()
        {
            AddRule(new ValidateRequired("RefId"));
            AddRule(new ValidateRequired("RefTypeId"));
            AddRule(new ValidateRequired("RefNo"));
            AddRule(new ValidateRequired("RefDate"));
            AddRule(new ValidateRequired("PostedDate"));
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="FixedAssetLedgerEntity" /> class.
        /// </summary>
        /// <param name="fixedAssetLedgerId">The fixed asset ledger identifier.</param>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="refNo">The reference no.</param>
        /// <param name="refDate">The reference date.</param>
        /// <param name="postedDate">The posted date.</param>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <param name="departmentId">The department identifier.</param>
        /// <param name="lifeTime">The life time.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="annualDepreciationRate">The annual depreciation rate.</param>
        /// <param name="annualDepreciationAmount">The annual depreciation amount.</param>
        /// <param name="orgPriceAccount">The org price account.</param>
        /// <param name="orgPriceDebitAmount">The org price debit amount.</param>
        /// <param name="exchangeRate">The exchange rate.</param>
        /// <param name="orgPriceDebitAmountExchange">The org price debit amount exchange.</param>
        /// <param name="orgPriceCreditAmount">The org price credit amount.</param>
        /// <param name="orgPriceCreditAmountExchange">The org price credit amount exchange.</param>
        /// <param name="depreciationAccount">The depreciation account.</param>
        /// <param name="depreciationDebitAmount">The depreciation debit amount.</param>
        /// <param name="depreciationDebitAmountExchange">The depreciation debit amount exchange.</param>
        /// <param name="depreciationCreditAmount">The depreciation credit amount.</param>
        /// <param name="depreciationCreditAmountExchange">The depreciation credit amount exchange.</param>
        /// <param name="budgetSourceAccount">The budget source account.</param>
        /// <param name="budgetSourcelDebitAmount">The budget sourcel debit amount.</param>
        /// <param name="budgetSourcelDebitAmountExchange">The budget sourcel debit amount exchange.</param>
        /// <param name="budgetSourceCreditAmount">The budget source credit amount.</param>
        /// <param name="budgetSourceCreditAmountExchange">The budget source credit amount exchange.</param>
        /// <param name="journalMemo">The journal memo.</param>
        /// <param name="description">The description.</param>
        /// <param name="quantity">The quantity.</param>
        public FixedAssetLedgerEntity(long fixedAssetLedgerId, long refId, int refTypeId, string refNo, DateTime refDate, DateTime postedDate, int fixedAssetId, int departmentId,
            float lifeTime, string currencyCode, float annualDepreciationRate, decimal annualDepreciationAmount, string orgPriceAccount, decimal orgPriceDebitAmount, decimal exchangeRate,
            decimal orgPriceDebitAmountExchange, decimal orgPriceCreditAmount, decimal orgPriceCreditAmountExchange, string depreciationAccount, decimal depreciationDebitAmount, 
            decimal depreciationDebitAmountExchange, decimal depreciationCreditAmount, decimal depreciationCreditAmountExchange, string budgetSourceAccount, decimal budgetSourcelDebitAmount, 
            decimal budgetSourcelDebitAmountExchange, decimal budgetSourceCreditAmount, decimal budgetSourceCreditAmountExchange, string journalMemo, string description, int quantity)
            : this()
        {
            FixedAssetLedgerId = fixedAssetLedgerId;
            RefId = refId;
            RefTypeId = refTypeId;
            RefNo = refNo;
            RefDate = refDate;
            PostedDate = postedDate;
            FixedAssetId = fixedAssetId;
            DepartmentId = departmentId;
            LifeTime = lifeTime;
            CurrencyCode = currencyCode;
            AnnualDepreciationRate = annualDepreciationRate;
            AnnualDepreciationAmount = annualDepreciationAmount;
            ExchangeRate = exchangeRate;
            OrgPriceAccount = orgPriceAccount;
            OrgPriceDebitAmount = orgPriceDebitAmount;
            OrgPriceCreditAmount = orgPriceCreditAmount;
            OrgPriceDebitAmountExchange = orgPriceDebitAmountExchange;
            OrgPriceCreditAmountExchange = orgPriceCreditAmountExchange;
            DepreciationAccount = depreciationAccount;
            DepreciationDebitAmount = depreciationDebitAmount;
            DepreciationCreditAmount = depreciationCreditAmount;
            DepreciationDebitAmountExchange = depreciationDebitAmountExchange;
            DepreciationCreditAmountExchange = depreciationCreditAmountExchange;
            BudgetSourceAccount = budgetSourceAccount;
            BudgetSourcelDebitAmount = budgetSourcelDebitAmount;
            BudgetSourceCreditAmount = budgetSourceCreditAmount;
            BudgetSourcelDebitAmountExchange = budgetSourcelDebitAmountExchange;
            BudgetSourceCreditAmountExchange = budgetSourceCreditAmountExchange;
            JournalMemo = journalMemo;
            Description = description;
            Quantity = quantity;
        }

        /// <summary>
        /// Gets or sets the fixed asset ledger identifier.
        /// </summary>
        /// <value>
        /// The fixed asset ledger identifier.
        /// </value>
        public long FixedAssetLedgerId { get; set; }

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
        /// Gets or sets the fixed asset identifier.
        /// </summary>
        /// <value>
        /// The fixed asset identifier.
        /// </value>
        public int? FixedAssetId { get; set; }

        /// <summary>
        /// Gets or sets the department identifier.
        /// </summary>
        /// <value>
        /// The department identifier.
        /// </value>
        public int? DepartmentId { get; set; }

        /// <summary>
        /// Gets or sets the life time.
        /// </summary>
        /// <value>
        /// The life time.
        /// </value>
        public float LifeTime { get; set; }

        /// <summary>
        /// Gets or sets the currency code.
        /// </summary>
        /// <value>
        /// The currency code.
        /// </value>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets the annual depreciation rate.
        /// </summary>
        /// <value>
        /// The annual depreciation rate.
        /// </value>
        public float AnnualDepreciationRate { get; set; }

        /// <summary>
        /// Gets or sets the annual depreciation amount.
        /// </summary>
        /// <value>
        /// The annual depreciation amount.
        /// </value>
        public decimal AnnualDepreciationAmount { get; set; }

        /// <summary>
        /// Gets or sets the exchange rate.
        /// </summary>
        /// <value>
        /// The exchange rate.
        /// </value>
        public decimal ExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets the org price account.
        /// </summary>
        /// <value>
        /// The org price account.
        /// </value>
        public string OrgPriceAccount { get; set; }

        /// <summary>
        /// Gets or sets the org price debit amount.
        /// </summary>
        /// <value>
        /// The org price debit amount.
        /// </value>
        public decimal OrgPriceDebitAmount { get; set; }

        /// <summary>
        /// Gets or sets the org price credit amount.
        /// </summary>
        /// <value>
        /// The org price credit amount.
        /// </value>
        public decimal OrgPriceCreditAmount { get; set; }

        /// <summary>
        /// Gets or sets the org price debit amount exchange.
        /// </summary>
        /// <value>
        /// The org price debit amount exchange.
        /// </value>
        public decimal OrgPriceDebitAmountExchange { get; set; }

        /// <summary>
        /// Gets or sets the org price credit amount exchange.
        /// </summary>
        /// <value>
        /// The org price credit amount exchange.
        /// </value>
        public decimal OrgPriceCreditAmountExchange { get; set; }

        /// <summary>
        /// Gets or sets the depreciation account.
        /// </summary>
        /// <value>
        /// The depreciation account.
        /// </value>
        public string DepreciationAccount { get; set; }

        /// <summary>
        /// Gets or sets the depreciation debit amount.
        /// </summary>
        /// <value>
        /// The depreciation debit amount.
        /// </value>
        public decimal DepreciationDebitAmount { get; set; }

        /// <summary>
        /// Gets or sets the depreciation debit amount exchange.
        /// </summary>
        /// <value>
        /// The depreciation debit amount exchange.
        /// </value>
        public decimal DepreciationDebitAmountExchange { get; set; }

        /// <summary>
        /// Gets or sets the depreciation credit amount.
        /// </summary>
        /// <value>
        /// The depreciation credit amount.
        /// </value>
        public decimal DepreciationCreditAmount { get; set; }

        /// <summary>
        /// Gets or sets the depreciation credit amount exchange.
        /// </summary>
        /// <value>
        /// The depreciation credit amount exchange.
        /// </value>
        public decimal DepreciationCreditAmountExchange { get; set; }

        /// <summary>
        /// Gets or sets the budget source account.
        /// </summary>
        /// <value>
        /// The budget source account.
        /// </value>
        public string BudgetSourceAccount { get; set; }

        /// <summary>
        /// Gets or sets the budget sourcel debit amount.
        /// </summary>
        /// <value>
        /// The budget sourcel debit amount.
        /// </value>
        public decimal BudgetSourcelDebitAmount { get; set; }

        /// <summary>
        /// Gets or sets the budget sourcel debit amount exchange.
        /// </summary>
        /// <value>
        /// The budget sourcel debit amount exchange.
        /// </value>
        public decimal BudgetSourcelDebitAmountExchange { get; set; }

        /// <summary>
        /// Gets or sets the budget source credit amount.
        /// </summary>
        /// <value>
        /// The budget source credit amount.
        /// </value>
        public decimal BudgetSourceCreditAmount { get; set; }

        /// <summary>
        /// Gets or sets the budget source credit amount exchange.
        /// </summary>
        /// <value>
        /// The budget source credit amount exchange.
        /// </value>
        public decimal BudgetSourceCreditAmountExchange { get; set; }

        /// <summary>
        /// Gets or sets the journal memo.
        /// </summary>
        /// <value>
        /// The journal memo.
        /// </value>
        public string JournalMemo { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>
        /// The quantity.
        /// </value>
        public int Quantity { get; set; }
    }
}
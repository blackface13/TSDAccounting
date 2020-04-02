/***********************************************************************
 * <copyright file="FixedAssetLedgerModel.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 10 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;


namespace TSD.AccountingSoft.Model.BusinessObjects.FixedAsset
{
    /// <summary>
    /// class FixedAssetLedgerModel
    /// </summary>
    public class FixedAssetLedgerModel
    {
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

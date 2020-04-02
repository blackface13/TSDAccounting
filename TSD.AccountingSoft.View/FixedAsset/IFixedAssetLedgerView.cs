using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.View.FixedAsset
{
    /// <summary>
    /// interface IFixedAssetLedgerView
    /// </summary>
   public interface IFixedAssetLedgerView : IView
    {
        /// <summary>
        /// Gets or sets the fixed asset ledger identifier.
        /// </summary>
        /// <value>
        /// The fixed asset ledger identifier.
        /// </value>
        long FixedAssetLedgerId { get; set; }

        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>
        /// The reference identifier.
        /// </value>
        long RefId { get; set; }

        /// <summary>
        /// Gets or sets the reference type identifier.
        /// </summary>
        /// <value>
        /// The reference type identifier.
        /// </value>
        int RefTypeId { get; set; }

        /// <summary>
        /// Gets or sets the reference no.
        /// </summary>
        /// <value>
        /// The reference no.
        /// </value>
        string RefNo { get; set; }

        /// <summary>
        /// Gets or sets the reference date.
        /// </summary>
        /// <value>
        /// The reference date.
        /// </value>
        DateTime RefDate { get; set; }

        /// <summary>
        /// Gets or sets the posted date.
        /// </summary>
        /// <value>
        /// The posted date.
        /// </value>
        DateTime PostedDate { get; set; }

        /// <summary>
        /// Gets or sets the fixed asset identifier.
        /// </summary>
        /// <value>
        /// The fixed asset identifier.
        /// </value>
        int FixedAssetId { get; set; }

        /// <summary>
        /// Gets or sets the department identifier.
        /// </summary>
        /// <value>
        /// The department identifier.
        /// </value>
        int? DepartmentId { get; set; }

        /// <summary>
        /// Gets or sets the life time.
        /// </summary>
        /// <value>
        /// The life time.
        /// </value>
        float LifeTime { get; set; }

        /// <summary>
        /// Gets or sets the currency code.
        /// </summary>
        /// <value>
        /// The currency code.
        /// </value>
        string CurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets the annual depreciation rate.
        /// </summary>
        /// <value>
        /// The annual depreciation rate.
        /// </value>
        float AnnualDepreciationRate { get; set; }

        /// <summary>
        /// Gets or sets the annual depreciation amount.
        /// </summary>
        /// <value>
        /// The annual depreciation amount.
        /// </value>
        decimal AnnualDepreciationAmount { get; set; }

        /// <summary>
        /// Gets or sets the exchange rate.
        /// </summary>
        /// <value>
        /// The exchange rate.
        /// </value>
        decimal ExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets the org price account.
        /// </summary>
        /// <value>
        /// The org price account.
        /// </value>
        string OrgPriceAccount { get; set; }

        /// <summary>
        /// Gets or sets the org price debit amount.
        /// </summary>
        /// <value>
        /// The org price debit amount.
        /// </value>
        decimal OrgPriceDebitAmount { get; set; }

        /// <summary>
        /// Gets or sets the org price credit amount.
        /// </summary>
        /// <value>
        /// The org price credit amount.
        /// </value>
        decimal OrgPriceCreditAmount { get; set; }

        /// <summary>
        /// Gets or sets the org price debit amount exchange.
        /// </summary>
        /// <value>
        /// The org price debit amount exchange.
        /// </value>
        decimal OrgPriceDebitAmountExchange { get; set; }

        /// <summary>
        /// Gets or sets the org price credit amount exchange.
        /// </summary>
        /// <value>
        /// The org price credit amount exchange.
        /// </value>
        decimal OrgPriceCreditAmountExchange { get; set; }

        /// <summary>
        /// Gets or sets the depreciation account.
        /// </summary>
        /// <value>
        /// The depreciation account.
        /// </value>
        string DepreciationAccount { get; set; }

        /// <summary>
        /// Gets or sets the depreciation debit amount.
        /// </summary>
        /// <value>
        /// The depreciation debit amount.
        /// </value>
        decimal DepreciationDebitAmount { get; set; }

        /// <summary>
        /// Gets or sets the depreciation debit amount exchange.
        /// </summary>
        /// <value>
        /// The depreciation debit amount exchange.
        /// </value>
        decimal DepreciationDebitAmountExchange { get; set; }

        /// <summary>
        /// Gets or sets the depreciation credit amount.
        /// </summary>
        /// <value>
        /// The depreciation credit amount.
        /// </value>
        decimal DepreciationCreditAmount { get; set; }

        /// <summary>
        /// Gets or sets the depreciation credit amount exchange.
        /// </summary>
        /// <value>
        /// The depreciation credit amount exchange.
        /// </value>
        decimal DepreciationCreditAmountExchange { get; set; }

        /// <summary>
        /// Gets or sets the budget source account.
        /// </summary>
        /// <value>
        /// The budget source account.
        /// </value>
        string BudgetSourceAccount { get; set; }

        /// <summary>
        /// Gets or sets the budget sourcel debit amount.
        /// </summary>
        /// <value>
        /// The budget sourcel debit amount.
        /// </value>
        decimal BudgetSourcelDebitAmount { get; set; }

        /// <summary>
        /// Gets or sets the budget sourcel debit amount exchange.
        /// </summary>
        /// <value>
        /// The budget sourcel debit amount exchange.
        /// </value>
        decimal BudgetSourcelDebitAmountExchange { get; set; }

        /// <summary>
        /// Gets or sets the budget source credit amount.
        /// </summary>
        /// <value>
        /// The budget source credit amount.
        /// </value>
        decimal BudgetSourceCreditAmount { get; set; }

        /// <summary>
        /// Gets or sets the budget source credit amount exchange.
        /// </summary>
        /// <value>
        /// The budget source credit amount exchange.
        /// </value>
        decimal BudgetSourceCreditAmountExchange { get; set; }

        /// <summary>
        /// Gets or sets the journal memo.
        /// </summary>
        /// <value>
        /// The journal memo.
        /// </value>
        string JournalMemo { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        string Description { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>
        /// The quantity.
        /// </value>
        int Quantity { get; set; }
    }
}

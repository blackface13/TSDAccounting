using System;

namespace TSD.AccountingSoft.Model.BusinessObjects.Opening
{
    /// <summary>
    /// class OpeningFixedAssetEntryModel
    /// </summary>
    public class OpeningFixedAssetEntryModel
    {
        /// <summary>
        /// Gets or sets the account identifier.
        /// </summary>
        /// <value>
        /// The account identifier.
        /// </value>
        public int? AccountId { get; set; }

        /// <summary>
        /// Gets or sets the parent identifier.
        /// </summary>
        /// <value>
        /// The parent identifier.
        /// </value>
        public int? ParentId { get; set; }

        /// <summary>
        /// Gets or sets the name of the account.
        /// </summary>
        /// <value>
        /// The name of the account.
        /// </value>
        public string AccountNumber { get; set; }

        /// <summary>
        /// Gets or sets the name of the account.
        /// </summary>
        /// <value>
        /// The name of the account.
        /// </value>
        public string AccountName { get; set; }

        /// <summary>
        /// Gets or sets the org price debit amount.
        /// </summary>
        /// <value>
        /// The org price debit amount.
        /// </value>
        public decimal AmountOc { get; set; }

        /// <summary>
        /// Gets or sets the org price debit amount usd.
        /// </summary>
        /// <value>
        /// The org price debit amount usd.
        /// </value>
        public decimal AmountExchange { get; set; }

        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>
        /// The reference identifier.
        /// </value>
        public long RefId { get; set; }

        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>
        /// The reference identifier.
        /// </value>
        public string RefNo { get; set; }
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
        /// Gets or sets the fixed asset identifier.
        /// </summary>
        /// <value>
        /// The fixed asset identifier.
        /// </value>
        public int FixedAssetId { get; set; }

        /// <summary>
        /// Gets or sets the department identifier.
        /// </summary>
        /// <value>
        /// The department identifier.
        /// </value>
        public int DepartmentId { get; set; }

        /// <summary>
        /// Gets or sets the life time.
        /// </summary>
        /// <value>
        /// The life time.
        /// </value>
        public int LifeTime { get; set; }

        /// <summary>
        /// Gets or sets the increment date.
        /// </summary>
        /// <value>
        /// The increment date.
        /// </value>
        public DateTime IncrementDate { get; set; }

        /// <summary>
        /// Gets or sets the unit.
        /// </summary>
        /// <value>
        /// The unit.
        /// </value>
        public string Unit { get; set; }

        /// <summary>
        /// Gets or sets the used date.
        /// </summary>
        /// <value>
        /// The used date.
        /// </value>
        public DateTime UsedDate { get; set; }

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
        /// Gets or sets the org price debit amount usd.
        /// </summary>
        /// <value>
        /// The org price debit amount usd.
        /// </value>
        public decimal OrgPriceDebitAmountUSD { get; set; }

        /// <summary>
        /// Gets or sets the depreciation account.
        /// </summary>
        /// <value>
        /// The depreciation account.
        /// </value>
        public string DepreciationAccount { get; set; }

        /// <summary>
        /// Gets or sets the depreciation credit amount.
        /// </summary>
        /// <value>
        /// The depreciation credit amount.
        /// </value>
        public decimal DepreciationCreditAmount { get; set; }

        /// <summary>
        /// Gets or sets the depreciation credit amount usd.
        /// </summary>
        /// <value>
        /// The depreciation credit amount usd.
        /// </value>
        public decimal DepreciationCreditAmountUSD { get; set; }

        /// <summary>
        /// Gets or sets the capital account.
        /// </summary>
        /// <value>
        /// The capital account.
        /// </value>
        public string CapitalAccount { get; set; }

        /// <summary>
        /// Gets or sets the capital credit amount.
        /// </summary>
        /// <value>
        /// The capital credit amount.
        /// </value>
        public decimal CapitalCreditAmount { get; set; }

        /// <summary>
        /// Gets or sets the capital credit amount usd.
        /// </summary>
        /// <value>
        /// The capital credit amount usd.
        /// </value>
        public decimal CapitalCreditAmountUSD { get; set; }

        /// <summary>
        /// Gets or sets the remaining amount.
        /// </summary>
        /// <value>
        /// The remaining amount.
        /// </value>
        public decimal RemainingAmount { get; set; }

        /// <summary>
        /// Gets or sets the remaining amount usd.
        /// </summary>
        /// <value>
        /// The remaining amount usd.
        /// </value>
        public decimal RemainingAmountUSD { get; set; }

        /// <summary>
        /// Gets or sets the budget chapter code.
        /// </summary>
        /// <value>
        /// The budget chapter code.
        /// </value>
        public string BudgetChapterCode { get; set; }

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

        /// <summary>
        /// Gets or sets the budget source code.
        /// </summary>
        /// <value>
        /// The budget source code.
        /// </value>
        public string BudgetSourceCode { get; set; }
    }
}

/***********************************************************************
 * <copyright file="IOpeningFixedAssetEntryView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: 12 December 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using TSD.AccountingSoft.Model.BusinessObjects.Opening;

namespace TSD.AccountingSoft.View.OpeningFixedAssetEntry
{
    /// <summary>
    /// interface IOpeningFixedAssetEntryView
    /// </summary>
    public interface IOpeningFixedAssetEntryView : IView
    {
        /// <summary>
        ///     Gets or sets the reference identifier.
        /// </summary>
        /// <value>
        ///     The reference identifier.
        /// </value>
        long RefId { get; set; }

        /// <summary>
        ///     Gets or sets the reference identifier.
        /// </summary>
        /// <value>
        ///     The reference identifier.
        /// </value>
        string RefNo { get; set; }

        /// <summary>
        ///     Gets or sets the reference type identifier.
        /// </summary>
        /// <value>
        ///     The reference type identifier.
        /// </value>
        int RefTypeId { get; set; }

        /// <summary>
        ///     Gets or sets the posted date.
        /// </summary>
        /// <value>
        ///     The posted date.
        /// </value>
        DateTime PostedDate { get; set; }

        /// <summary>
        ///     Gets or sets the fixed asset identifier.
        /// </summary>
        /// <value>
        ///     The fixed asset identifier.
        /// </value>
        int FixedAssetId { get; set; }

        /// <summary>
        ///     Gets or sets the department identifier.
        /// </summary>
        /// <value>
        ///     The department identifier.
        /// </value>
        int DepartmentId { get; set; }

        /// <summary>
        ///     Gets or sets the life time.
        /// </summary>
        /// <value>
        ///     The life time.
        /// </value>
        int LifeTime { get; set; }

        /// <summary>
        ///     Gets or sets the increment date.
        /// </summary>
        /// <value>
        ///     The increment date.
        /// </value>
        DateTime IncrementDate { get; set; }

        /// <summary>
        ///     Gets or sets the unit.
        /// </summary>
        /// <value>
        ///     The unit.
        /// </value>
        string Unit { get; set; }

        /// <summary>
        ///     Gets or sets the used date.
        /// </summary>
        /// <value>
        ///     The used date.
        /// </value>
        DateTime UsedDate { get; set; }

        /// <summary>
        ///     Gets or sets the currency code.
        /// </summary>
        /// <value>
        ///     The currency code.
        /// </value>
        string CurrencyCode { get; set; }

        /// <summary>
        ///     Gets or sets the exchange rate.
        /// </summary>
        /// <value>
        ///     The exchange rate.
        /// </value>
        decimal ExchangeRate { get; set; }

        /// <summary>
        ///     Gets or sets the org price account.
        /// </summary>
        /// <value>
        ///     The org price account.
        /// </value>
        string OrgPriceAccount { get; set; }

        /// <summary>
        ///     Gets or sets the org price debit amount.
        /// </summary>
        /// <value>
        ///     The org price debit amount.
        /// </value>
        decimal OrgPriceDebitAmount { get; set; }

        /// <summary>
        ///     Gets or sets the org price debit amount usd.
        /// </summary>
        /// <value>
        ///     The org price debit amount usd.
        /// </value>
        decimal OrgPriceDebitAmountUSD { get; set; }

        /// <summary>
        ///     Gets or sets the depreciation account.
        /// </summary>
        /// <value>
        ///     The depreciation account.
        /// </value>
        string DepreciationAccount { get; set; }

        /// <summary>
        ///     Gets or sets the depreciation credit amount.
        /// </summary>
        /// <value>
        ///     The depreciation credit amount.
        /// </value>
        decimal DepreciationCreditAmount { get; set; }

        /// <summary>
        ///     Gets or sets the depreciation credit amount usd.
        /// </summary>
        /// <value>
        ///     The depreciation credit amount usd.
        /// </value>
        decimal DepreciationCreditAmountUSD { get; set; }

        /// <summary>
        ///     Gets or sets the capital account.
        /// </summary>
        /// <value>
        ///     The capital account.
        /// </value>
        string CapitalAccount { get; set; }

        /// <summary>
        ///     Gets or sets the capital credit amount.
        /// </summary>
        /// <value>
        ///     The capital credit amount.
        /// </value>
        decimal CapitalCreditAmount { get; set; }

        /// <summary>
        ///     Gets or sets the capital credit amount usd.
        /// </summary>
        /// <value>
        ///     The capital credit amount usd.
        /// </value>
        decimal CapitalCreditAmountUSD { get; set; }

        /// <summary>
        ///     Gets or sets the remaining amount.
        /// </summary>
        /// <value>
        ///     The remaining amount.
        /// </value>
        decimal RemainingAmount { get; set; }

        /// <summary>
        ///     Gets or sets the remaining amount usd.
        /// </summary>
        /// <value>
        ///     The remaining amount usd.
        /// </value>
        decimal RemainingAmountUSD { get; set; }

        /// <summary>
        ///     Gets or sets the budget chapter code.
        /// </summary>
        /// <value>
        ///     The budget chapter code.
        /// </value>
        string BudgetChapterCode { get; set; }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        /// <value>
        ///     The description.
        /// </value>
        string Description { get; set; }

        /// <summary>
        ///     Gets or sets the quantity.
        /// </summary>
        /// <value>
        ///     The quantity.
        /// </value>
        int Quantity { get; set; }

        /// <summary>
        ///     Gets or sets the opening fixed asset entries.
        /// </summary>
        /// <value>
        ///     The opening fixed asset entries.
        /// </value>
        IList<OpeningFixedAssetEntryModel> OpeningFixedAssetEntries { get; set; }

        /// <summary>
        ///     Gets or sets the budget source code.
        /// </summary>
        /// <value>
        ///     The budget source code.
        /// </value>
        string BudgetSourceCode { get; set; }
    }
}
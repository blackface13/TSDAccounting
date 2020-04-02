/***********************************************************************
 * <copyright file="IOpeningAccountEntryView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 28 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using TSD.AccountingSoft.Model.BusinessObjects.Opening;


namespace TSD.AccountingSoft.View.OpeningAccountEntry
{
    /// <summary>
    /// interface IOpeningAccountEntryView
    /// </summary>
    public interface IOpeningAccountEntryView : IView
    {
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
        /// Gets or sets the posted date.
        /// </summary>
        /// <value>
        /// The posted date.
        /// </value>
        DateTime PostedDate { get; set; }

        /// <summary>
        /// Gets or sets the account code.
        /// </summary>
        /// <value>
        /// The account code.
        /// </value>
        string AccountCode { get; set; }

        /// <summary>
        /// Gets or sets the account identifier.
        /// </summary>
        /// <value>
        /// The account identifier.
        /// </value>
        int AccountId { get; set; }

        /// <summary>
        /// Gets or sets the parent identifier.
        /// </summary>
        /// <value>
        /// The parent identifier.
        /// </value>
        int ParentId { get; set; }

        /// <summary>
        /// Gets or sets the name of the account.
        /// </summary>
        /// <value>
        /// The name of the account.
        /// </value>
        string AccountName { get; set; }

        /// <summary>
        /// Gets or sets the total account beginning debit amount oc.
        /// </summary>
        /// <value>
        /// The total account beginning debit amount oc.
        /// </value>
        decimal TotalAccountBeginningDebitAmountOC { get; set; }

        /// <summary>
        /// Gets or sets the total account beginning credit amount oc.
        /// </summary>
        /// <value>
        /// The total account beginning credit amount oc.
        /// </value>
        decimal TotalAccountBeginningCreditAmountOC { get; set; }

        /// <summary>
        /// Gets or sets the total debit amount oc.
        /// </summary>
        /// <value>
        /// The total debit amount oc.
        /// </value>
        decimal TotalDebitAmountOC { get; set; }

        /// <summary>
        /// Gets or sets the total credit amount oc.
        /// </summary>
        /// <value>
        /// The total credit amount oc.
        /// </value>
        decimal TotalCreditAmountOC { get; set; }

        /// <summary>
        /// Gets or sets the total account beginning debit amount exchange.
        /// </summary>
        /// <value>
        /// The total account beginning debit amount exchange.
        /// </value>
        decimal TotalAccountBeginningDebitAmountExchange { get; set; }

        /// <summary>
        /// Gets or sets the total account beginning credit amount exchange.
        /// </summary>
        /// <value>
        /// The total account beginning credit amount exchange.
        /// </value>
        decimal TotalAccountBeginningCreditAmountExchange { get; set; }

        /// <summary>
        /// Gets or sets the total debit amount exchange.
        /// </summary>
        /// <value>
        /// The total debit amount exchange.
        /// </value>
        decimal TotalDebitAmountExchange { get; set; }

        /// <summary>
        /// Gets or sets the total credit amount exchange.
        /// </summary>
        /// <value>
        /// The total credit amount exchange.
        /// </value>
        decimal TotalCreditAmountExchange { get; set; }

        /// <summary>
        /// Gets or sets the opening account entry details.
        /// </summary>
        /// <value>
        /// The opening account entry details.
        /// </value>
        IList<OpeningAccountEntryDetailModel> OpeningAccountEntryDetails { get; set; }
    }
}

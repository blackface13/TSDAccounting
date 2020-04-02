/***********************************************************************
 * <copyright file="ExchangeRateModel.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Tuesday, August 18, 2015
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/
using System;

namespace TSD.AccountingSoft.Model.BusinessObjects.Dictionary
{
    /// <summary>
    /// Store exchange rate follow fromdate and todate and budgetsource
    /// </summary>
    public class ExchangeRateModel
    {
        /// <summary>
        /// Gets or sets the exchange rate identifier.
        /// </summary>
        /// <value>
        /// The exchange rate identifier.
        /// </value>
        public int ExchangeRateId { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets from date.
        /// </summary>
        /// <value>
        /// From date.
        /// </value>
        public DateTime FromDate { get; set; }

        /// <summary>
        /// Gets or sets to date.
        /// </summary>
        /// <value>
        /// To date.
        /// </value>
        public DateTime ToDate { get; set; }

        /// <summary>
        /// Gets or sets the budget source code.
        /// </summary>
        /// <value>
        /// The budget source code.
        /// </value>
        public string BudgetSourceCode { get; set; }

        /// <summary>
        /// Gets or sets the exchange rate.
        /// </summary>
        /// <value>
        /// The exchange rate.
        /// </value>
        public decimal ExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ExchangeRateModel" /> is inactive.
        /// </summary>
        /// <value>
        ///   <c>true</c> if inactive; otherwise, <c>false</c>.
        /// </value>
        public bool Inactive { get; set; }
    }
}

/***********************************************************************
 * <copyright file="GeneralEstimateModel.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 10 May 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

namespace TSD.AccountingSoft.Model.BusinessObjects.Report.Estimate
{
    /// <summary>
    /// GeneralEstimateModel
    /// </summary>
    public class GeneralEstimateModel
    {
        /// <summary>
        /// Gets or sets the name of the budget item.
        /// </summary>
        /// <value>
        /// The name of the budget item.
        /// </value>
        public string BudgetItemName { get; set; }

        /// <summary>
        /// Gets or sets the previous year of total estimate amount.
        /// </summary>
        /// <value>
        /// The previous year of total estimate amount.
        /// </value>
        public decimal PreviousYearOfTotalEstimateAmount { get; set; }

        /// <summary>
        /// Gets or sets the year of estimate amount.
        /// </summary>
        /// <value>
        /// The year of estimate amount.
        /// </value>
        public decimal YearOfEstimateAmount { get; set; }

        /// <summary>
        /// Gets or sets the next year of estimate amount.
        /// </summary>
        /// <value>
        /// The next year of estimate amount.
        /// </value>
        public decimal NextYearOfEstimateAmount { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }
    }
}

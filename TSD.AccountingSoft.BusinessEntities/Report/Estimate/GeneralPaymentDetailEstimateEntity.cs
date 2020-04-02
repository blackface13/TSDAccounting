/***********************************************************************
 * <copyright file="GeneralPaymentDetailEstimateEntity.cs" company="BUCA JSC">
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

namespace TSD.AccountingSoft.BusinessEntities.Report.Estimate
{
    /// <summary>
    /// GeneralPaymentDetailEstimateEntity
    /// </summary>
    public class GeneralPaymentDetailEstimateEntity
    {
        /// <summary>
        /// Gets or sets the budget item identifier.
        /// </summary>
        /// <value>
        /// The budget item identifier.
        /// </value>
        public int BudgetItemId { get; set; }

        /// <summary>
        /// Gets or sets the budget item code.
        /// </summary>
        /// <value>
        /// The budget item code.
        /// </value>
        public string BudgetItemCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the budget item.
        /// </summary>
        /// <value>
        /// The name of the budget item.
        /// </value>
        public string BudgetItemName { get; set; }

        /// <summary>
        /// Gets or sets the name of the budget sub item.
        /// </summary>
        /// <value>
        /// The name of the budget sub item.
        /// </value>
        public string BudgetSubItemCode { get; set; }

        /// <summary>
        /// Gets or sets the parent identifier.
        /// </summary>
        /// <value>
        /// The parent identifier.
        /// </value>
        public int? ParentId { get; set; }

        /// <summary>
        /// Gets or sets the grade.
        /// </summary>
        /// <value>
        /// The grade.
        /// </value>
        public short Grade { get; set; }

        /// <summary>
        /// Gets or sets the total estimate amount usd.
        /// </summary>
        /// <value>
        /// The total estimate amount usd.
        /// </value>
        public decimal TotalEstimateAmountUSD { get; set; }

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
        /// Gets or sets the autonomy budget.
        /// </summary>
        /// <value>
        /// The autonomy budget.
        /// </value>
        public decimal AutonomyBudget { get; set; }

        /// <summary>
        /// Gets or sets the non autonomy budget.
        /// </summary>
        /// <value>
        /// The non autonomy budget.
        /// </value>
        public decimal NonAutonomyBudget { get; set; }

        /// <summary>
        /// Gets or sets the total next year of estimate amount.
        /// </summary>
        /// <value>
        /// The total next year of estimate amount.
        /// </value>
        public decimal TotalNextYearOfEstimateAmount { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the name of the budget source category.
        /// </summary>
        /// <value>
        /// The name of the budget source category.
        /// </value>
        public string BudgetSourceCategoryName { get; set; }
    }
}

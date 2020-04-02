/***********************************************************************
 * <copyright file="SqlServerFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Thursday, March 19, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  07/03/2014       Author    Tudt           Description: Coding standard
 * 
 * ************************************************************************/

namespace TSD.AccountingSoft.View.Estimate
{
    /// <summary>
    /// Class IPaymentEstimateDetailView.
    /// </summary>
    public interface IPaymentEstimateDetailView
    {
        /// <summary>
        /// Gets or sets the reference detail identifier.
        /// </summary>
        /// <value>The reference detail identifier.</value>
        long RefDetailId { get; set; }

        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>The reference identifier.</value>
        long RefId { get; set; }

        /// <summary>
        /// Gets or sets the reference no.
        /// </summary>
        /// <value>The reference no.</value>
        string BudgetItemCode { get; set; }

        /// <summary>
        /// Gets or sets the total estimate amount.
        /// </summary>
        /// <value>The total estimate amount.</value>
        decimal PreviousYearOfEstimateAmount { get; set; }

        /// <summary>
        /// Gets or sets the next year of total estimate amount.
        /// </summary>
        /// <value>The next year of total estimate amount.</value>
        decimal PreviousYearOfEstimateAmountUSD { get; set; }

        /// <summary>
        /// Gets or sets the next year of total estimate amount.
        /// </summary>
        /// <value>The next year of total estimate amount.</value>
        decimal TotalEstimateAmountUSD { get; set; }

        /// <summary>
        /// Gets or sets the next year of total estimate amount.
        /// </summary>
        /// <value>The next year of total estimate amount.</value>
        decimal YearOfEstimateAmount { get; set; }

        /// <summary>
        /// Gets or sets the next year of total estimate amount.
        /// </summary>
        /// <value>The next year of total estimate amount.</value>
        decimal NextYearOfEstimateAmount { get; set; }

        /// <summary>
        /// Gets or sets the next year of total estimate amount.
        /// </summary>
        /// <value>The next year of total estimate amount.</value>
        decimal AutonomyBudget { get; set; }

        /// <summary>
        /// Gets or sets the next year of total estimate amount.
        /// </summary>
        /// <value>The next year of total estimate amount.</value>
        decimal NonAutonomyBudget { get; set; }

        /// <summary>
        /// Gets or sets the total next year of estimate amount.
        /// </summary>
        /// <value>
        /// The total next year of estimate amount.
        /// </value>
        decimal TotalNextYearOfEstimateAmount { get; set; }

        /// <summary>
        /// Gets or sets the journal memo.
        /// </summary>
        /// <value>The journal memo.</value>
        string Description { get; set; }

        /// <summary>
        /// Gets or sets the previous year of autonomy budget.
        /// </summary>
        /// <value>
        /// The previous year of autonomy budget.
        /// </value>
        decimal PreviousYearOfAutonomyBudget { get; set; }

        /// <summary>
        /// Gets or sets the previous year of non autonomy budget.
        /// </summary>
        /// <value>
        /// The previous year of non autonomy budget.
        /// </value>
        decimal PreviousYearOfNonAutonomyBudget { get; set; }

        /// <summary>
        /// Gets or sets the year of autonomy budget.
        /// </summary>
        /// <value>
        /// The year of autonomy budget.
        /// </value>
        decimal YearOfAutonomyBudget { get; set; }

        /// <summary>
        /// Gets or sets the year of non autonomy budget.
        /// </summary>
        /// <value>
        /// The year of non autonomy budget.
        /// </value>
        decimal YearOfNonAutonomyBudget { get; set; }

        /// <summary>
        /// Gets or sets the next year of autonomy budget.
        /// </summary>
        /// <value>
        /// The next year of autonomy budget.
        /// </value>
        decimal SixMonthBeginingAutonomyBudget { get; set; }

        /// <summary>
        /// Gets or sets the next year of non autonomy budget.
        /// </summary>
        /// <value>
        /// The next year of non autonomy budget.
        /// </value>
        decimal SixMonthBeginingNonAutonomyBudget { get; set; }

        /// <summary>
        /// Gets or sets the next year of autonomy budget.
        /// </summary>
        /// <value>
        /// The next year of autonomy budget.
        /// </value>
        decimal TotalAmountSixMonthBegining { get; set; }

        /// <summary>
        /// Gets or sets the next year of non autonomy budget.
        /// </summary>
        /// <value>
        /// The next year of non autonomy budget.
        /// </value>
        decimal SixMonthEndingNonAutonomyBudget { get; set; }

        /// <summary>
        /// Gets or sets the next year of autonomy budget.
        /// </summary>
        /// <value>
        /// The next year of autonomy budget.
        /// </value>
        decimal SixMonthEndingAutonomyBudget { get; set; }

        /// <summary>
        /// Gets or sets the next year of non autonomy budget.
        /// </summary>
        /// <value>
        /// The next year of non autonomy budget.
        /// </value>
        decimal TotalAmountSixMonthEnding { get; set; }

        /// <summary>
        /// Gets or sets the budget source category identifier.
        /// </summary>
        /// <value>
        /// The budget source category identifier.
        /// </value>
        int? BudgetSourceCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the previous yea of autonomy budget balance.
        /// </summary>
        /// <value>
        /// The previous yea of autonomy budget balance.
        /// </value>
        decimal PreviousYeaOfAutonomyBudgetBalance { get; set; }

        /// <summary>
        /// Gets or sets the previous yea of non autonomy budget balance.
        /// </summary>
        /// <value>
        /// The previous yea of non autonomy budget balance.
        /// </value>
        decimal PreviousYeaOfNonAutonomyBudgetBalance { get; set; }

        /// <summary>
        /// Gets or sets the total previous year balance.
        /// </summary>
        /// <value>
        /// The total previous year balance.
        /// </value>
        decimal TotalPreviousYearBalance { get; set; }

        /// <summary>
        /// Gets or sets the total previous year balance.
        /// </summary>
        /// <value>
        /// The total previous year balance.
        /// </value>
        decimal ThisYearOfAutonomyBudget { get; set; }

        /// <summary>
        /// Gets or sets the total amount this year.
        /// </summary>
        /// <value>
        /// The total amount this year.
        /// </value>
        decimal ThisYearOfNonAutonomyBudget { get; set; }

        /// <summary>
        /// Gets or sets the total amount this year.
        /// </summary>
        /// <value>
        /// The total amount this year.
        /// </value>
        decimal TotalAmountThisYear { get; set; }
    }
}

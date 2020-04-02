/***********************************************************************
 * <copyright file="FundStuationModel.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 13 June 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

namespace TSD.AccountingSoft.Model.BusinessObjects.Report.Estimate
{
    /// <summary>
    /// class FundStuationModel
    /// </summary>
    public class FundStuationModel
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
        /// Gets or sets the budget sub item code.
        /// </summary>
        /// <value>
        /// The budget sub item code.
        /// </value>
        public string BudgetSubItemCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the budget item.
        /// </summary>
        /// <value>
        /// The name of the budget item.
        /// </value>
        public string BudgetItemName { get; set; }

        /// <summary>
        /// Gets or sets the parent identifier.
        /// </summary>
        /// <value>
        /// The parent identifier.
        /// </value>
        public int ParentId { get; set; }

        /// <summary>
        /// Gets or sets the grade.
        /// </summary>
        /// <value>
        /// The grade.
        /// </value>
        public short Grade { get; set; }

        /// <summary>
        /// Gets or sets the sort.
        /// </summary>
        /// <value>
        /// The sort.
        /// </value>
        public string Sort { get; set; }

        /// <summary>
        /// Gets or sets the type of the budget item.
        /// </summary>
        /// <value>
        /// The type of the budget item.
        /// </value>
        public short BudgetItemType { get; set; }

        /// <summary>
        /// Gets or sets the previous year of autonomy budget.
        /// </summary>
        /// <value>
        /// The previous year of autonomy budget.
        /// </value>
        public decimal PreviousYearOfAutonomyBudget { get; set; }

        /// <summary>
        /// Gets or sets the previous year of non autonomy budget.
        /// </summary>
        /// <value>
        /// The previous year of non autonomy budget.
        /// </value>
        public decimal PreviousYearOfNonAutonomyBudget { get; set; }

        /// <summary>
        /// Gets or sets the total estimate amount usd.
        /// </summary>
        /// <value>
        /// The total estimate amount usd.
        /// </value>
        public decimal TotalEstimateAmountUSD { get; set; }

        /// <summary>
        /// Gets or sets the year of autonomy budget.
        /// </summary>
        /// <value>
        /// The year of autonomy budget.
        /// </value>
        public decimal YearOfAutonomyBudget { get; set; }

        /// <summary>
        /// Gets or sets the year of non autonomy budget.
        /// </summary>
        /// <value>
        /// The year of non autonomy budget.
        /// </value>
        public decimal YearOfNonAutonomyBudget { get; set; }

        /// <summary>
        /// Gets or sets the year of estimate amount.
        /// </summary>
        /// <value>
        /// The year of estimate amount.
        /// </value>
        public decimal YearOfEstimateAmount { get; set; }

        /// <summary>
        /// Gets or sets the six month begining autonomy budget.
        /// </summary>
        /// <value>
        /// The six month begining autonomy budget.
        /// </value>
        public decimal SixMonthBeginingAutonomyBudget { get; set; }

        /// <summary>
        /// Gets or sets the six month begining non autonomy budget.
        /// </summary>
        /// <value>
        /// The six month begining non autonomy budget.
        /// </value>
        public decimal SixMonthBeginingNonAutonomyBudget { get; set; }

        /// <summary>
        /// Gets or sets the total amount six month begining.
        /// </summary>
        /// <value>
        /// The total amount six month begining.
        /// </value>
        public decimal TotalAmountSixMonthBegining { get; set; }

        /// <summary>
        /// Gets or sets the six month ending autonomy budget.
        /// </summary>
        /// <value>
        /// The six month ending autonomy budget.
        /// </value>
        public decimal SixMonthEndingAutonomyBudget { get; set; }

        /// <summary>
        /// Gets or sets the six month ending non autonomy budget.
        /// </summary>
        /// <value>
        /// The six month ending non autonomy budget.
        /// </value>
        public decimal SixMonthEndingNonAutonomyBudget { get; set; }

        /// <summary>
        /// Gets or sets the total amount six month ending.
        /// </summary>
        /// <value>
        /// The total amount six month ending.
        /// </value>
        public decimal TotalAmountSixMonthEnding { get; set; }

        /// <summary>
        /// Gets or sets the year of amount autonomy budget.
        /// </summary>
        /// <value>
        /// The year of amount autonomy budget.
        /// </value>
        public decimal YearOfAmountAutonomyBudget { get; set; }

        /// <summary>
        /// Gets or sets the year of amount non autonomy budget.
        /// </summary>
        /// <value>
        /// The year of amount non autonomy budget.
        /// </value>
        public decimal YearOfAmountNonAutonomyBudget { get; set; }

        /// <summary>
        /// Gets or sets the year of total amount.
        /// </summary>
        /// <value>
        /// The year of total amount.
        /// </value>
        public decimal YearOfTotalAmount { get; set; }

        /// <summary>
        /// Gets or sets the year of difference amount autonomy budget.
        /// </summary>
        /// <value>
        /// The year of difference amount autonomy budget.
        /// </value>
        public decimal YearOfDifferenceAmountAutonomyBudget { get; set; }

        /// <summary>
        /// Gets or sets the year of difference amount non autonomy budget.
        /// </summary>
        /// <value>
        /// The year of difference amount non autonomy budget.
        /// </value>
        public decimal YearOfDifferenceAmountNonAutonomyBudget { get; set; }

        /// <summary>
        /// Gets or sets the year of difference total amount.
        /// </summary>
        /// <value>
        /// The year of difference total amount.
        /// </value>
        public decimal YearOfDifferenceTotalAmount { get; set; }

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

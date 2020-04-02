/***********************************************************************
 * <copyright file="SqlServerFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Thursday, March 18, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  07/03/2014       Author    Tudt           Description: Coding standard
 * 
 * ************************************************************************/

namespace TSD.AccountingSoft.Model.BusinessObjects.Estimate
{
    /// <summary>
    /// Class ReceiptEstimateDetailModel.
    /// </summary>
    public class EstimateDetailModel
    {
        /// <summary>
        /// Gets or sets the reference detail identifier.
        /// </summary>
        /// <value>The reference detail identifier.</value>
        public long RefDetailId { get; set; }

        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>The reference identifier.</value>
        public long RefId { get; set; }

        /// <summary>
        /// Gets or sets the reference no.
        /// </summary>
        /// <value>The reference no.</value>
        public string BudgetItemCode { get; set; }
        
        /// <summary>
        /// Gets or sets the budget item name.
        /// </summary>
        /// <value>The budget item name.</value>
        public string BudgetItemName { get; set; }

        /// <summary>
        /// Gets or sets the total estimate amount.
        /// </summary>
        /// <value>The total estimate amount.</value>
        public decimal PreviousYearOfEstimateAmount { get; set; }

        /// <summary>
        /// Gets or sets the next year of total estimate amount.
        /// </summary>
        /// <value>The next year of total estimate amount.</value>
        public decimal PreviousYearOfEstimateAmountUSD { get; set; }

        /// <summary>
        /// Gets or sets the next year of total estimate amount.
        /// </summary>
        /// <value>The next year of total estimate amount.</value>
        public decimal TotalEstimateAmountUSD { get; set; }

        /// <summary>
        /// Gets or sets the next year of total estimate amount.
        /// </summary>
        /// <value>The next year of total estimate amount.</value>
        public decimal YearOfEstimateAmount { get; set; }

        /// <summary>
        /// Gets or sets the next year of total estimate amount.
        /// </summary>
        /// <value>The next year of total estimate amount.</value>
        public decimal NextYearOfEstimateAmount { get; set; }

        /// <summary>
        /// Gets or sets the next year of total estimate amount.
        /// </summary>
        /// <value>The next year of total estimate amount.</value>
        public decimal AutonomyBudget { get; set; }

        /// <summary>
        /// Gets or sets the next year of total estimate amount.
        /// </summary>
        /// <value>The next year of total estimate amount.</value>
        public decimal NonAutonomyBudget { get; set; }

        /// <summary>
        /// Gets or sets the total next year of estimate amount.
        /// </summary>
        /// <value>
        /// The total next year of estimate amount.
        /// </value>
        public decimal TotalNextYearOfEstimateAmount { get; set; }

        /// <summary>
        /// Gets or sets the journal memo.
        /// </summary>
        /// <value>The journal memo.</value>
        public string Description { get; set; }

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
        /// Gets or sets the next year of autonomy budget.
        /// </summary>
        /// <value>
        /// The next year of autonomy budget.
        /// </value>
        public decimal SixMonthBeginingAutonomyBudget { get; set; }

        /// <summary>
        /// Gets or sets the next year of non autonomy budget.
        /// </summary>
        /// <value>
        /// The next year of non autonomy budget.
        /// </value>
        public decimal SixMonthBeginingNonAutonomyBudget { get; set; }

        /// <summary>
        /// Gets or sets the next year of autonomy budget.
        /// </summary>
        /// <value>
        /// The next year of autonomy budget.
        /// </value>
        public decimal TotalAmountSixMonthBegining { get; set; }

        /// <summary>
        /// Gets or sets the next year of non autonomy budget.
        /// </summary>
        /// <value>
        /// The next year of non autonomy budget.
        /// </value>
        public decimal SixMonthEndingNonAutonomyBudget { get; set; }

        /// <summary>
        /// Gets or sets the next year of autonomy budget.
        /// </summary>
        /// <value>
        /// The next year of autonomy budget.
        /// </value>
        public decimal SixMonthEndingAutonomyBudget { get; set; }

        /// <summary>
        /// Gets or sets the next year of non autonomy budget.
        /// </summary>
        /// <value>
        /// The next year of non autonomy budget.
        /// </value>
        public decimal TotalAmountSixMonthEnding { get; set; }

        /// <summary>
        /// Gets or sets the previous yea of autonomy budget balance.
        /// </summary>
        /// <value>
        /// The previous yea of autonomy budget balance.
        /// </value>
        public decimal PreviousYeaOfAutonomyBudgetBalance { get; set; }

        /// <summary>
        /// Gets or sets the previous yea of non autonomy budget balance.
        /// </summary>
        /// <value>
        /// The previous yea of non autonomy budget balance.
        /// </value>
        public decimal PreviousYeaOfNonAutonomyBudgetBalance { get; set; }

        /// <summary>
        /// Gets or sets the total previous year balance.
        /// </summary>
        /// <value>
        /// The total previous year balance.
        /// </value>
        public decimal TotalPreviousYearBalance { get; set; }

        /// <summary>
        /// Gets or sets the total previous year balance.
        /// </summary>
        /// <value>
        /// The total previous year balance.
        /// </value>
        public decimal ThisYearOfAutonomyBudget { get; set; }

        /// <summary>
        /// Gets or sets the total amount this year.
        /// </summary>
        /// <value>
        /// The total amount this year.
        /// </value>
        public decimal ThisYearOfNonAutonomyBudget { get; set; }

        /// <summary>
        /// Gets or sets the total amount this year.
        /// </summary>
        /// <value>
        /// The total amount this year.
        /// </value>
        public decimal TotalAmountThisYear { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is insert.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is insert; otherwise, <c>false</c>.
        /// </value>
        public bool IsInserted { get; set; }

        /// <summary>
        /// Gets or sets the item code list.
        /// </summary>
        /// <value>
        /// The item code list.
        /// </value>
        public string ItemCodeList { get; set; }

        /// <summary>
        /// Gets or sets the number order.
        /// </summary>
        /// <value>
        /// The number order.
        /// </value>
        public string NumberOrder { get; set; }

        /// <summary>
        /// Gets or sets the font style.
        /// </summary>
        /// <value>
        /// The font style.
        /// </value>
        public string FontStyle { get; set; }
    }
}

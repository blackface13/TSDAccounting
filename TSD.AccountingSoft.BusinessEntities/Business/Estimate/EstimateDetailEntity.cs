/***********************************************************************
 * <copyright file="PaymentEstimateDetailEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 18 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using TSD.AccountingSoft.BusinessEntities.BusinessRules;


namespace TSD.AccountingSoft.BusinessEntities.Business.Estimate
{
    /// <summary>
    /// EstimateDetailEntity
    /// </summary>
    public class EstimateDetailEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EstimateDetailEntity"/> class.
        /// </summary>
        public EstimateDetailEntity()
        {
            AddRule(new ValidateRequired("RefId"));
            AddRule(new ValidateRequired("BudgetItemCode"));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EstimateDetailEntity" /> class.
        /// </summary>
        /// <param name="refDetailId">The reference detail identifier.</param>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="budgetItemCode">The budget item code.</param>
        /// <param name="previousYearOfEstimateAmount">The previous year of estimate amount.</param>
        /// <param name="previousYearOfEstimateAmountUSD">The previous year of estimate amount usd.</param>
        /// <param name="totalEstimateAmountUSD">The total estimate amount usd.</param>
        /// <param name="yearOfEstimateAmount">The year of estimate amount.</param>
        /// <param name="nextYearOfEstimateAmount">The next year of estimate amount.</param>
        /// <param name="autonomyBudget">The autonomy budget.</param>
        /// <param name="nonAutonomyBudget">The non autonomy budget.</param>
        /// <param name="description">The description.</param>
        /// <param name="budgetItemName">Name of the budget item.</param>
        /// <param name="totalNextYearOfEstimateAmount">The total next year of estimate amount.</param>
        /// <param name="thisYearOfAutonomyBudget">The this year of autonomy budget.</param>
        /// <param name="thisYearOfNonAutonomyBudget">The this year of non autonomy budget.</param>
        /// <param name="itemCodeList">The item code list.</param>
        /// <param name="numberOrder">The number order.</param>
        /// <summary>
        /// Initializes a new instance of the <see cref="EstimateDetailEntity"/> class.
        /// </summary>
        /// <param name="refDetailId">The reference detail identifier.</param>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="budgetItemCode">The budget item code.</param>
        /// <param name="previousYearOfEstimateAmount">The previous year of estimate amount.</param>
        /// <param name="previousYearOfEstimateAmountUSD">The previous year of estimate amount usd.</param>
        /// <param name="totalEstimateAmountUSD">The total estimate amount usd.</param>
        /// <param name="yearOfEstimateAmount">The year of estimate amount.</param>
        /// <param name="nextYearOfEstimateAmount">The next year of estimate amount.</param>
        /// <param name="autonomyBudget">The autonomy budget.</param>
        /// <param name="nonAutonomyBudget">The non autonomy budget.</param>
        /// <param name="description">The description.</param>
        /// <param name="budgetItemName">Name of the budget item.</param>
        /// <param name="totalNextYearOfEstimateAmount">The total next year of estimate amount.</param>
        /// <param name="thisYearOfAutonomyBudget">The this year of autonomy budget.</param>
        /// <param name="thisYearOfNonAutonomyBudget">The this year of non autonomy budget.</param>
        /// <param name="itemCodeList">The item code list.</param>
        /// <param name="numberOrder">The number order.</param>
        /// <param name="fontStyle">The font style.</param>
        public EstimateDetailEntity(long refDetailId, long refId, string budgetItemCode, decimal previousYearOfEstimateAmount,
            decimal previousYearOfEstimateAmountUSD, decimal totalEstimateAmountUSD, decimal yearOfEstimateAmount,
            decimal nextYearOfEstimateAmount, decimal autonomyBudget, decimal nonAutonomyBudget, string description,
            string budgetItemName, decimal totalNextYearOfEstimateAmount, decimal thisYearOfAutonomyBudget, decimal thisYearOfNonAutonomyBudget,
            string itemCodeList, string numberOrder, string fontStyle )
            : this()
        {
            RefDetailId = refDetailId;
            RefId = refId;
            BudgetItemCode = budgetItemCode;
            PreviousYearOfEstimateAmount = previousYearOfEstimateAmount;
            PreviousYearOfEstimateAmountUSD = previousYearOfEstimateAmountUSD;
            TotalEstimateAmountUSD = totalEstimateAmountUSD;
            YearOfEstimateAmount = yearOfEstimateAmount;
            NextYearOfEstimateAmount = nextYearOfEstimateAmount;
            AutonomyBudget = autonomyBudget;
            NonAutonomyBudget = nonAutonomyBudget;
            TotalNextYearOfEstimateAmount = totalNextYearOfEstimateAmount;
            Description = description;
            BudgetItemName = budgetItemName;
            ThisYearOfAutonomyBudget = thisYearOfAutonomyBudget;
            ThisYearOfNonAutonomyBudget = thisYearOfNonAutonomyBudget;
            ItemCodeList = itemCodeList;
            NumberOrder = numberOrder;
            FontStyle = fontStyle;
        }

        /// <summary>
        /// Gets or sets the reference detail identifier.
        /// </summary>
        /// <value>
        /// The reference detail identifier.
        /// </value>
        public long RefDetailId { get; set; }

        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>
        /// The reference identifier.
        /// </value>
        public long RefId { get; set; }

        /// <summary>
        /// Gets or sets the budget item code.
        /// </summary>
        /// <value>
        /// The budget item code.
        /// </value>
        public string BudgetItemCode { get; set; }

        /// <summary>
        /// Gets or sets the previous year of estimate amount.
        /// </summary>
        /// <value>
        /// The previous year of estimate amount.
        /// </value>
        public decimal PreviousYearOfEstimateAmount { get; set; }

        /// <summary>
        /// Gets or sets the previous year of estimate amount usd.
        /// </summary>
        /// <value>
        /// The previous year of estimate amount usd.
        /// </value>
        public decimal PreviousYearOfEstimateAmountUSD { get; set; }

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
        /// Gets or sets the budget item name.
        /// </summary>
        /// <value>
        /// The budget item name.
        /// </value>
        public string BudgetItemName { get; set; }

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
        /// Gets or sets the total amount this year.
        /// </summary>
        /// <value>
        /// The total amount this year.
        /// </value>
        public decimal TotalAmountThisYear { get; set; }

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
        public string NumberOrder { get; set;}

        /// <summary>
        /// Gets or sets the font style.
        /// </summary>
        /// <value>
        /// The font style.
        /// </value>
        public string FontStyle { get; set; }
    }
}

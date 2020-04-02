/***********************************************************************
 * <copyright file="SqlServerFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Thursday, February 28, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  07/03/2014       Author    Tudt           Description: Coding standard
 * 
 * ************************************************************************/

using TSD.AccountingSoft.BusinessEntities.BusinessRules;


namespace TSD.AccountingSoft.BusinessEntities.Dictionary
{
    /// <summary>
    /// Class PlanTemplateItemEntity.
    /// </summary>
    public class PlanTemplateItemEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlanTemplateItemEntity"/> class.
        /// </summary>
        public PlanTemplateItemEntity()
        {
            AddRule(new ValidateRequired("PlanTemplateItemId"));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlanTemplateItemEntity"/> class.
        /// </summary>
        /// <param name="planTemplateItemId">The plan template item identifier.</param>
        /// <param name="planTemplateListId">The plan template list identifier.</param>
        /// <param name="budgetItemCode">The budget item identifier.</param>
        /// <param name="budgetItemName">Name of the budget item.</param>
        /// <param name="previousYearOfEstimateAmount">Name of the budget item.</param>
        /// <param name="previousYearOfEstimateAmountUSD">Name of the budget item.</param>
        /// <param name="previousYearOfAutonomyBudget">The previous year of autonomy budget.</param>
        /// <param name="previousYearOfNonAutonomyBudget">The previous year of non autonomy budget.</param>
        /// <param name="sixMonthBeginingAutonomyBudget">The six month begining autonomy budget.</param>
        /// <param name="sixMonthBeginingNonAutonomyBudget">The six month begining non autonomy budget.</param>
        /// <param name="totalAmountSixMonthBegining">The total amount six month begining.</param>
        public PlanTemplateItemEntity(int planTemplateItemId, int planTemplateListId, string budgetItemCode,
            string budgetItemName, decimal previousYearOfEstimateAmount, decimal previousYearOfEstimateAmountUSD,
            decimal previousYearOfAutonomyBudget, decimal previousYearOfNonAutonomyBudget, decimal sixMonthBeginingAutonomyBudget,
            decimal sixMonthBeginingNonAutonomyBudget, decimal totalAmountSixMonthBegining, string itemCodeList, string numberOrder, string fontStyle)
            : this()
        {
            PlanTemplateItemId = planTemplateItemId;
            PlanTemplateListId = planTemplateListId;
            BudgetItemCode = budgetItemCode;
            BudgetItemName = budgetItemName;
            PreviousYearOfEstimateAmount = previousYearOfEstimateAmount;
            PreviousYearOfEstimateAmountUSD = previousYearOfEstimateAmountUSD;
            PreviousYearOfAutonomyBudget = previousYearOfAutonomyBudget;
            PreviousYearOfNonAutonomyBudget = previousYearOfNonAutonomyBudget;
            SixMonthBeginingAutonomyBudget = sixMonthBeginingAutonomyBudget;
            SixMonthBeginingNonAutonomyBudget = sixMonthBeginingNonAutonomyBudget;
            TotalAmountSixMonthBegining = totalAmountSixMonthBegining;
            ItemCodeList = itemCodeList;
            NumberOrder = numberOrder;
            FontStyle = fontStyle;
        }

        /// <summary>
        /// Gets or sets the plan template item identifier.
        /// </summary>
        /// <value>The plan template item identifier.</value>
        public int PlanTemplateItemId { get; set; }

        /// <summary>
        /// Gets or sets the plan template list identifier.
        /// </summary>
        /// <value>The plan template list identifier.</value>
        public int PlanTemplateListId { get; set; }

        /// <summary>
        /// Gets or sets the budget item identifier.
        /// </summary>
        /// <value>The budget item identifier.</value>
        public string BudgetItemCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the budget item.
        /// </summary>
        /// <value>The name of the budget item.</value>
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
        /// Gets or sets the total amount this year.
        /// </summary>
        /// <value>
        /// The total amount this year.
        /// </value>
        public decimal TotalAmountThisYear { get; set; }

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

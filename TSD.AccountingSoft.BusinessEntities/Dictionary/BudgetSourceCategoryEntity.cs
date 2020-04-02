/***********************************************************************
 * <copyright file="BudgetSourceCategoryEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 19 June 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using TSD.AccountingSoft.BusinessEntities.BusinessRules;


namespace TSD.AccountingSoft.BusinessEntities.Dictionary
{
    /// <summary>
    /// BudgetSourceCategoryEntity
    /// </summary>
    public class BudgetSourceCategoryEntity : BusinessEntities
    {
        public BudgetSourceCategoryEntity()
        {
            AddRule(new ValidateRequired("BudgetSourceCategoryCode"));
            AddRule(new ValidateRequired("BudgetSourceCategoryName"));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BudgetSourceCategoryEntity"/> class.
        /// </summary>
        /// <param name="budgetSourceCategoryId">The budget source category identifier.</param>
        /// <param name="budgetSourceCategoryCode">The budget source category code.</param>
        /// <param name="budgetSourceCategoryName">Name of the budget source category.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <param name="description">The description.</param>
        /// <param name="foreignName">Name of the foreign.</param>
        /// <param name="isSummaryEstimateReport">if set to <c>true</c> [is summary estimate report].</param>
        public BudgetSourceCategoryEntity(int budgetSourceCategoryId, string budgetSourceCategoryCode, string budgetSourceCategoryName,
            bool isActive, string description, string foreignName, bool isSummaryEstimateReport)
            : this()
        {
            BudgetSourceCategoryId = budgetSourceCategoryId;
            BudgetSourceCategoryCode = budgetSourceCategoryCode;
            BudgetSourceCategoryName = budgetSourceCategoryName;
            IsActive = isActive;
            Description = description;
            ForeignName = foreignName;
            IsSummaryEstimateReport = isSummaryEstimateReport;
        }

        /// <summary>
        /// Gets or sets the budget source category identifier.
        /// </summary>
        /// <value>
        /// The budget source category identifier.
        /// </value>
        public int BudgetSourceCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the budget source category code.
        /// </summary>
        /// <value>
        /// The budget source category code.
        /// </value>
        public string BudgetSourceCategoryCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the budget source category.
        /// </summary>
        /// <value>
        /// The name of the budget source category.
        /// </value>
        public string BudgetSourceCategoryName { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the name of the foreign.
        /// </summary>
        /// <value>
        /// The name of the foreign.
        /// </value>
        public string ForeignName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is active].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is active]; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is summary estimate report].
        /// </summary>
        /// <value>
        /// <c>true</c> if [is summary estimate report]; otherwise, <c>false</c>.
        /// </value>
        public bool IsSummaryEstimateReport { get; set; }
    }
}

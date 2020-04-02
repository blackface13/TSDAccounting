/***********************************************************************
 * <copyright file="BudgetSourceEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   THODD
 * Email:    thodd@buca.vn
 * Website:
 * Create Date: 07 March 2014
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
    /// Class BudgetSourceEntity.
    /// </summary>
    public class BudgetSourceEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BudgetSourceEntity"/> class.
        /// </summary>
        public BudgetSourceEntity()
        {
            AddRule(new ValidateRequired("BudgetSourceCode"));
            AddRule(new ValidateRequired("BudgetSourceName"));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BudgetSourceEntity" /> class.
        /// </summary>
        /// <param name="budgetSourceId">The budget source identifier.</param>
        /// <param name="budgetSourceCode">The budget source code.</param>
        /// <param name="budgetSourceName">Name of the budget source.</param>
        /// <param name="foreignName">Name of the foreign.</param>
        /// <param name="parentId">The parent identifier.</param>
        /// <param name="description">The description.</param>
        /// <param name="grade">The grade.</param>
        /// <param name="isParent">if set to <c>true</c> [is parent].</param>
        /// <param name="type">The type.</param>
        /// <param name="allocation">The allocation.</param>
        /// <param name="budgetItemCode">The budget item identifier.</param>
        /// <param name="isSystem">if set to <c>true</c> [is system].</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <param name="isFund">if set to <c>true</c> [is fund].</param>
        /// <param name="isExpense">if set to <c>true</c> [is expense].</param>
        /// <param name="accountCode">The account identifier.</param>
        /// <param name="autonomyBudgetType">Type of the autonomy budget.</param>
        public BudgetSourceEntity(int budgetSourceId, string budgetSourceCode, string budgetSourceName, string foreignName, int parentId, string description, int grade,
            bool isParent, int type, int allocation, string budgetItemCode, bool isSystem, bool isActive, bool isFund, bool isExpense, string accountCode, short? autonomyBudgetType, int budgetCode)
            : this()
        {
            BudgetSourceId = budgetSourceId;
            BudgetSourceCode = budgetSourceCode;
            BudgetSourceName = budgetSourceName;
            ForeignName = foreignName;
            ParentId = parentId;
            Description = description;
            Grade = grade;
            IsParent = isParent;
            Type = type;
            IsSystem = isSystem;
            IsActive = isActive;
            Allocation = allocation;
            BudgetItemCode = budgetItemCode;
            IsFund = isFund;
            IsExpense = isExpense;
            AccountCode = accountCode;
            AutonomyBudgetType = autonomyBudgetType;
            BudgetCode = budgetCode;
        }

        /// <summary>
        /// Gets or sets the budget source identifier.
        /// </summary>
        /// <value>The budget source identifier.</value>
        public int BudgetSourceId { get; set; }

        /// <summary>
        /// Gets or sets the name of the budget source.
        /// </summary>
        /// <value>The name of the budget source.</value>
        public string BudgetSourceName { get; set; }

        /// <summary>
        /// Gets or sets the name of the foreign.
        /// </summary>
        /// <value>The name of the foreign.</value>
        public string ForeignName { get; set; }

        /// <summary>
        /// Gets or sets the budget source code.
        /// </summary>
        /// <value>The budget source code.</value>
        public string BudgetSourceCode { get; set; }

        /// <summary>
        /// Gets or sets the parent identifier.
        /// </summary>
        /// <value>The parent identifier.</value>
        public int? ParentId { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the grade.
        /// </summary>
        /// <value>The grade.</value>
        public int Grade { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is parent.
        /// </summary>
        /// <value><c>true</c> if this instance is parent; otherwise, <c>false</c>.</value>
        public bool IsParent { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public int Type { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is system.
        /// </summary>
        /// <value><c>true</c> if this instance is system; otherwise, <c>false</c>.</value>
        public bool IsSystem { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the allocation.
        /// </summary>
        /// <value>The allocation.</value>
        public int Allocation { get; set; }

        /// <summary>
        /// Gets or sets the budget item identifier.
        /// </summary>
        /// <value>The budget item identifier.</value>
        public string BudgetItemCode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is fund.
        /// </summary>
        /// <value><c>true</c> if this instance is fund; otherwise, <c>false</c>.</value>
        public bool IsFund { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is expense.
        /// </summary>
        /// <value><c>true</c> if this instance is expense; otherwise, <c>false</c>.</value>
        public bool IsExpense { get; set; }

        /// <summary>
        /// Gets or sets the account identifier.
        /// </summary>
        /// <value>The account identifier.</value>
        public string AccountCode { get; set; }

        /// <summary>
        /// Gets or sets the type of the autonomy budget.
        /// </summary>
        /// <value>
        /// The type of the autonomy budget.
        /// </value>
        public short? AutonomyBudgetType { get; set; }

        public int BudgetCode { get; set; }
    }
}

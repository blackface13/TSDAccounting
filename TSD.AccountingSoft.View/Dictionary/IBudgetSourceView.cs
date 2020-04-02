/***********************************************************************
 * <copyright file="IBudgetSourceView.cs" company="BUCA JSC">
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

namespace TSD.AccountingSoft.View.Dictionary
{
    /// <summary>
    /// Interface IBudgetSourceView
    /// </summary>
    public interface IBudgetSourceView : IView
    {
        /// <summary>
        /// Gets or sets the budget source identifier.
        /// </summary>
        /// <value>The budget source identifier.</value>
        int BudgetSourceId { get; set; }

        /// <summary>
        /// Gets or sets the name of the budget source.
        /// </summary>
        /// <value>The name of the budget source.</value>
        string BudgetSourceName { get; set; }

        /// <summary>
        /// Gets or sets the name of the foreign.
        /// </summary>
        /// <value>The name of the foreign.</value>
        string ForeignName { get; set; }

        /// <summary>
        /// Gets or sets the budget source code.
        /// </summary>
        /// <value>The budget source code.</value>
        string BudgetSourceCode { get; set; }

        /// <summary>
        /// Gets or sets the parent identifier.
        /// </summary>
        /// <value>The parent identifier.</value>
        int? ParentId { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        string Description { get; set; }

        /// <summary>
        /// Gets or sets the grade.
        /// </summary>
        /// <value>The grade.</value>
        int Grade { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is parent.
        /// </summary>
        /// <value><c>true</c> if this instance is parent; otherwise, <c>false</c>.</value>
        bool IsParent { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        int Type { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is system.
        /// </summary>
        /// <value><c>true</c> if this instance is system; otherwise, <c>false</c>.</value>
        bool IsSystem { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the allocation.
        /// </summary>
        /// <value>The allocation.</value>
        int Allocation { get; set; }

        /// <summary>
        /// Gets or sets the budget item identifier.
        /// </summary>
        /// <value>The budget item identifier.</value>
        string BudgetItemCode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is fund.
        /// </summary>
        /// <value><c>true</c> if this instance is fund; otherwise, <c>false</c>.</value>
        bool IsFund { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is expense.
        /// </summary>
        /// <value><c>true</c> if this instance is expense; otherwise, <c>false</c>.</value>
        bool IsExpense { get; set; }

        /// <summary>
        /// Gets or sets the account identifier.
        /// </summary>
        /// <value>The account identifier.</value>
        string AccountCode { get; set; }

        /// <summary>
        /// Gets or sets the type of the autonomy budget.
        /// </summary>
        /// <value>
        /// The type of the autonomy budget.
        /// </value>
        short? AutonomyBudgetType { get; set; }

        int BudgetCode { get; set; }
    }
}

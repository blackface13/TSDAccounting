/***********************************************************************
 * <copyright file="IBudgetCategoryView.cs" company="BUCA JSC">
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
    /// Interface IBudgetCategoryView
    /// </summary>
    public interface IBudgetCategoryView : IView
    {
        /// <summary>
        /// Gets or sets the budget category identifier.
        /// </summary>
        /// <value>The budget category identifier.</value>
        int BudgetCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the name of the budget category.
        /// </summary>
        /// <value>The name of the budget category.</value>
        string BudgetCategoryName { get; set; }

        /// <summary>
        /// Gets or sets the budget category code.
        /// </summary>
        /// <value>The budget category code.</value>
        string BudgetCategoryCode { get; set; }

        /// <summary>
        /// Gets or sets the parent identifier.
        /// </summary>
        /// <value>The parent identifier.</value>
        int? ParentId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is system.
        /// </summary>
        /// <value><c>true</c> if this instance is system; otherwise, <c>false</c>.</value>
        bool IsParent { get; set; }
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
        /// Gets or sets the name of the foreign.
        /// </summary>
        /// <value>The name of the foreign.</value>
        string ForeignName { get; set; }
    }
}

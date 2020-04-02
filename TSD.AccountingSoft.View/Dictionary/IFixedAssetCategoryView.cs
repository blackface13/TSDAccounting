/***********************************************************************
 * <copyright file="IFixedAssetCategoryView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Wednesday, February 26, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

namespace TSD.AccountingSoft.View.Dictionary
{
    /// <summary>
    /// FixedAssetCategory View Interface
    /// </summary>
    public interface IFixedAssetCategoryView : IView
    {
        /// <summary>
        /// Gets or sets the fixed asset category identifier.
        /// </summary>
        /// <value>
        /// The fixed asset category identifier.
        /// </value>
        int FixedAssetCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the parent identifier.
        /// </summary>
        /// <value>
        /// The parent identifier.
        /// </value>
        int? ParentId { get; set; }

        /// <summary>
        /// Gets or sets the fixed asset category code.
        /// </summary>
        /// <value>
        /// The fixed asset category code.
        /// </value>
        string FixedAssetCategoryCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the fixed asset category.
        /// </summary>
        /// <value>
        /// The name of the fixed asset category.
        /// </value>
        string FixedAssetCategoryName { get; set; }

        /// <summary>
        /// Gets or sets the fixed asset category name en.
        /// </summary>
        /// <value>
        /// The fixed asset category name en.
        /// </value>
        string FixedAssetCategoryForeignName { get; set; }

        /// <summary>
        /// Gets or sets the depreciation rate.
        /// </summary>
        /// <value>
        /// The depreciation rate.
        /// </value>
        decimal DepreciationRate { get; set; }

        /// <summary>
        /// Gets or sets the life time.
        /// </summary>
        /// <value>
        /// The life time.
        /// </value>
        decimal LifeTime { get; set; }

        /// <summary>
        /// Gets or sets the grade.
        /// </summary>
        /// <value>
        /// The grade.
        /// </value>
        int Grade { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is parent].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is parent]; otherwise, <c>false</c>.
        /// </value>
        bool IsParent { get; set; }

        /// <summary>
        /// Gets or sets the org price account.
        /// </summary>
        /// <value>
        /// The org price account.
        /// </value>
        string OrgPriceAccountCode { get; set; }

        /// <summary>
        /// Gets or sets the depreciation account.
        /// </summary>
        /// <value>
        /// The depreciation account.
        /// </value>
        string DepreciationAccountCode { get; set; }

        /// <summary>
        /// Gets or sets the capital account.
        /// </summary>
        /// <value>
        /// The capital account.
        /// </value>
        string CapitalAccountCode { get; set; }

        /// <summary>
        /// Gets or sets the chapter code.
        /// </summary>
        /// <value>
        /// The chapter code.
        /// </value>
        string BudgetChapterCode { get; set; }

        /// <summary>
        /// Gets or sets the budget category code.
        /// </summary>
        /// <value>
        /// The budget category code.
        /// </value>
        string BudgetCategoryCode { get; set; }

        /// <summary>
        /// Gets or sets the budget group code.
        /// </summary>
        /// <value>
        /// The budget group code.
        /// </value>
        string BudgetGroupCode { get; set; }

        /// <summary>
        /// Gets or sets the budget item code.
        /// </summary>
        /// <value>
        /// The budget item code.
        /// </value>
        string BudgetItemCode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [in active].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [in active]; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; set; }

        string Unit { get; set; }
    }
}

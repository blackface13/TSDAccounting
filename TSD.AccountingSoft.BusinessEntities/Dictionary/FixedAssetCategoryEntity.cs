/***********************************************************************
 * <copyright file="FixedAssetCategoryEntity.cs" company="BUCA JSC">
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

using TSD.AccountingSoft.BusinessEntities.BusinessRules;


namespace TSD.AccountingSoft.BusinessEntities.Dictionary
{
    /// <summary>
    /// FixedAssetCategory Entity
    /// </summary>
    public class FixedAssetCategoryEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FixedAssetCategoryEntity"/> class.
        /// </summary>
        public FixedAssetCategoryEntity()
        {
            AddRule(new ValidateRequired("FixedAssetCategoryCode"));
            AddRule(new ValidateRequired("FixedAssetCategoryName"));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FixedAssetCategoryEntity"/> class.
        /// </summary>
        /// <param name="fixedAssetCategoryId">The fixed asset category identifier.</param>
        /// <param name="parentId">The parent identifier.</param>
        /// <param name="fixedAssetCategoryCode">The fixed asset category code.</param>
        /// <param name="fixedAssetCategoryName">Name of the fixed asset category.</param>
        /// <param name="fixedAssetCategoryForeignName">The fixed asset category name en.</param>
        /// <param name="depreciationRate">The depreciation rate.</param>
        /// <param name="lifeTime">The life time.</param>
        /// <param name="grade">The grade.</param>
        /// <param name="isParent">if set to <c>true</c> [is parent].</param>
        /// <param name="orgPriceAccount">The org price account.</param>
        /// <param name="depreciationAccount">The depreciation account.</param>
        /// <param name="capitalAccount">The capital account.</param>
        /// <param name="budgetChapterCode">The chapter code.</param>
        /// <param name="budgetCategoryCode">The budget category code.</param>
        /// <param name="budgetGroupCode">The budget group code.</param>
        /// <param name="budgetItemCode">The budget item code.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        public FixedAssetCategoryEntity(int fixedAssetCategoryId, int parentId, string fixedAssetCategoryCode, string fixedAssetCategoryName, string fixedAssetCategoryForeignName, decimal depreciationRate,
                                        decimal lifeTime, int grade, bool isParent, string orgPriceAccount, string depreciationAccount, string capitalAccount,
                                        string budgetChapterCode, string budgetCategoryCode, string budgetGroupCode, string budgetItemCode, bool isActive,string unit)
            : this()
        {
            FixedAssetCategoryId = fixedAssetCategoryId;
            ParentId = parentId;
            FixedAssetCategoryCode = fixedAssetCategoryCode;
            FixedAssetCategoryName = fixedAssetCategoryName;
            FixedAssetCategoryForeignName = fixedAssetCategoryForeignName;
            DepreciationRate = depreciationRate;
            LifeTime = lifeTime;
            Grade = grade;
            IsParent = isParent;
            OrgPriceAccountCode = orgPriceAccount;
            DepreciationAccountCode = depreciationAccount;
            CapitalAccountCode = capitalAccount;
            BudgetChapterCode = budgetChapterCode;
            BudgetCategoryCode = budgetCategoryCode;
            BudgetGroupCode = budgetGroupCode;
            BudgetItemCode = budgetItemCode;
            IsActive = isActive;
            Unit = unit;
        }

        /// <summary>
        /// Gets or sets the fixed asset category identifier.
        /// </summary>
        /// <value>
        /// The fixed asset category identifier.
        /// </value>
        public int FixedAssetCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the parent identifier.
        /// </summary>
        /// <value>
        /// The parent identifier.
        /// </value>
        public int? ParentId { get; set; }

        /// <summary>
        /// Gets or sets the fixed asset category code.
        /// </summary>
        /// <value>
        /// The fixed asset category code.
        /// </value>
        public string FixedAssetCategoryCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the fixed asset category.
        /// </summary>
        /// <value>
        /// The name of the fixed asset category.
        /// </value>
        public string FixedAssetCategoryName { get; set; }

        /// <summary>
        /// Gets or sets the fixed asset category name en.
        /// </summary>
        /// <value>
        /// The fixed asset category name en.
        /// </value>
        public string FixedAssetCategoryForeignName { get; set; }

        /// <summary>
        /// Gets or sets the depreciation rate.
        /// </summary>
        /// <value>
        /// The depreciation rate.
        /// </value>
        public decimal DepreciationRate { get; set; }

        /// <summary>
        /// Gets or sets the life time.
        /// </summary>
        /// <value>
        /// The life time.
        /// </value>
        public decimal LifeTime { get; set; }

        /// <summary>
        /// Gets or sets the grade.
        /// </summary>
        /// <value>
        /// The grade.
        /// </value>
        public int Grade { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is parent].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is parent]; otherwise, <c>false</c>.
        /// </value>
        public bool IsParent { get; set; }

        /// <summary>
        /// Gets or sets the org price account.
        /// </summary>
        /// <value>
        /// The org price account.
        /// </value>
        public string OrgPriceAccountCode { get; set; }

        /// <summary>
        /// Gets or sets the depreciation account.
        /// </summary>
        /// <value>
        /// The depreciation account.
        /// </value>
        public string DepreciationAccountCode { get; set; }

        /// <summary>
        /// Gets or sets the capital account.
        /// </summary>
        /// <value>
        /// The capital account.
        /// </value>
        public string CapitalAccountCode { get; set; }

        /// <summary>
        /// Gets or sets the chapter code.
        /// </summary>
        /// <value>
        /// The chapter code.
        /// </value>
        public string BudgetChapterCode { get; set; }

        /// <summary>
        /// Gets or sets the budget category code.
        /// </summary>
        /// <value>
        /// The budget category code.
        /// </value>
        public string BudgetCategoryCode { get; set; }

        /// <summary>
        /// Gets or sets the budget group code.
        /// </summary>
        /// <value>
        /// The budget group code.
        /// </value>
        public string BudgetGroupCode { get; set; }

        /// <summary>
        /// Gets or sets the budget item code.
        /// </summary>
        /// <value>
        /// The budget item code.
        /// </value>
        public string BudgetItemCode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is active].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is active]; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }

        public string Unit { get; set; }
    }
}

/***********************************************************************
 * <copyright file="FixedAssetCategoryPresenter.cs" company="BUCA JSC">
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

using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.View.Dictionary;


namespace TSD.AccountingSoft.Presenter.Dictionary.FixedAsset
{
    /// <summary>
    /// FixedAsset Category Presenter
    /// </summary>
    public class FixedAssetCategoryPresenter : Presenter<IFixedAssetCategoryView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FixedAssetCategoryPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public FixedAssetCategoryPresenter(IFixedAssetCategoryView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays the specified fixed asset category identifier.
        /// </summary>
        /// <param name="fixedAssetCategoryId">The fixed asset category identifier.</param>
        public void Display(string fixedAssetCategoryId)
        {
            if (fixedAssetCategoryId == null) { View.FixedAssetCategoryId = 0; return; }

            var fixedAssetCategory = Model.GetFixedAssetCategoryById(int.Parse(fixedAssetCategoryId));
            View.FixedAssetCategoryId = fixedAssetCategory.FixedAssetCategoryId;
            View.ParentId = fixedAssetCategory.ParentId;
            View.FixedAssetCategoryCode = fixedAssetCategory.FixedAssetCategoryCode;
            View.FixedAssetCategoryName = fixedAssetCategory.FixedAssetCategoryName;
            View.FixedAssetCategoryForeignName = fixedAssetCategory.FixedAssetCategoryForeignName;
            View.DepreciationRate = fixedAssetCategory.DepreciationRate;
            View.LifeTime = fixedAssetCategory.LifeTime;
            View.Grade = fixedAssetCategory.Grade;
            View.IsParent = fixedAssetCategory.IsParent;
            View.OrgPriceAccountCode = fixedAssetCategory.OrgPriceAccountCode;
            View.DepreciationAccountCode = fixedAssetCategory.DepreciationAccountCode;
            View.CapitalAccountCode = fixedAssetCategory.CapitalAccountCode;
            View.BudgetChapterCode = fixedAssetCategory.BudgetChapterCode;
            View.BudgetCategoryCode = fixedAssetCategory.BudgetCategoryCode;
            View.BudgetGroupCode = fixedAssetCategory.BudgetGroupCode;
            View.BudgetItemCode = fixedAssetCategory.BudgetItemCode;
            View.IsActive = fixedAssetCategory.IsActive;
            View.Unit = fixedAssetCategory.Unit;
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        public int Save()
        {
            var fixedAssetCategory = new FixedAssetCategoryModel
            {
                FixedAssetCategoryId = View.FixedAssetCategoryId,
                ParentId = View.ParentId,
                FixedAssetCategoryCode = View.FixedAssetCategoryCode,
                FixedAssetCategoryName = View.FixedAssetCategoryName,
                FixedAssetCategoryForeignName = View.FixedAssetCategoryForeignName,
                DepreciationRate = View.DepreciationRate,
                LifeTime = View.LifeTime,
                Grade = View.Grade,
                IsParent = View.IsParent,
                OrgPriceAccountCode = View.OrgPriceAccountCode,
                DepreciationAccountCode = View.DepreciationAccountCode,
                CapitalAccountCode = View.CapitalAccountCode,
                BudgetChapterCode = View.BudgetChapterCode,
                BudgetCategoryCode = View.BudgetCategoryCode,
                BudgetGroupCode = View.BudgetGroupCode,
                BudgetItemCode = View.BudgetItemCode,
                IsActive = View.IsActive,
                Unit = View.Unit
            };

            if (View.FixedAssetCategoryId == 0)
                return Model.AddFixedAssetCategory(fixedAssetCategory);
            return Model.UpdateFixedAssetCategory(fixedAssetCategory);
        }

        /// <summary>
        /// Deletes the specified fixed asset category identifier.
        /// </summary>
        /// <param name="fixedAssetCategoryId">The fixed asset category identifier.</param>
        /// <returns></returns>
        public int Delete(int fixedAssetCategoryId)
        {
            return Model.DeleteFixedAssetCategory(fixedAssetCategoryId);
        }
    }
}

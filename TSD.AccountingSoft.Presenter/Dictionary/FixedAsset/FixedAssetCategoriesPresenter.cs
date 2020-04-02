/***********************************************************************
 * <copyright file="FixedAssetCategorysPresenter.cs" company="BUCA JSC">
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

using System.Collections.Generic;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.View.Dictionary;

namespace TSD.AccountingSoft.Presenter.Dictionary.FixedAsset
{
    /// <summary>
    /// class FixedAssetCategoriesPresenter 
    /// </summary>
    public class FixedAssetCategoriesPresenter : Presenter<IFixedAssetCategoriesView>
    {
        public FixedAssetCategoriesPresenter(IFixedAssetCategoriesView view)
            : base(view)
        {
        }
        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            View.FixedAssetCategories = Model.GetFixedAssetCategories();
        }

        public void DisplayComboCheck()
        {
            View.FixedAssetCategories = Model.GetFixedAssetCategoriesComboCheck();
        }

        /// <summary>
        /// Displays the active.
        /// </summary>
        public void DisplayActive()
        {
            View.FixedAssetCategories = Model.GetFixedAssetCategoriesActive();
        }

        /// <summary>
        /// Displays for combo tree.
        /// </summary>
        /// <param name="fixedAssetCategoryId">The fixed asset category identifier.</param>
        public void DisplayForComboTree(int fixedAssetCategoryId)
        {
            View.FixedAssetCategories = Model.GetFixedAssetCategoriesForComboTree(fixedAssetCategoryId);
        }

        /// <summary>
        /// Get all fixedassetcategories
        /// </summary>
        public IList<FixedAssetCategoryModel> GetAllFixedAssetCategories()
        {
            return Model.GetFixedAssetCategories();
        }
    }
}

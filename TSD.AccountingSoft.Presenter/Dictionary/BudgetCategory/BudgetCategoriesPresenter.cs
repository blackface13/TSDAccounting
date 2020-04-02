/***********************************************************************
 * <copyright file="FrmXtraFixedAssetCategoryTreeDetail.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   THODD
 * Email:    thodd@buca.vn
 * Website:
 * Create Date: Wednesday, February 26, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using TSD.AccountingSoft.View.Dictionary;


namespace TSD.AccountingSoft.Presenter.Dictionary.BudgetCategory
{
    /// <summary>
    /// Class BudgetCategoriesPresenter.
    /// </summary>
    public class BudgetCategoriesPresenter : Presenter<IBudgetCategoriesView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BudgetCategoriesPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public BudgetCategoriesPresenter(IBudgetCategoriesView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            View.BudgetCategories = Model.GetBudgetCategories();
        }

        /// <summary>
        /// Get List BudgetCategories by Active
        /// </summary>
        /// <returns></returns>
        public IList<Model.BusinessObjects.Dictionary.BudgetCategoryModel> GetBudgetCategories()
        {
            return Model.GetBudgetCategories();
        }

        /// <summary>
        /// Displays the active.
        /// </summary>
        public void DisplayActive()
        {
            View.BudgetCategories = Model.GetBudgetCategoriesActive();
        }

        /// <summary>
        /// Displays for combo tree.
        /// </summary>
        /// <param name="budgetCategoryId">The account identifier.</param>
        public void DisplayForComboTree(int budgetCategoryId)
        {
            View.BudgetCategories = Model.GetBudgetCategoriesForComboTree(budgetCategoryId);
        }
    }
}
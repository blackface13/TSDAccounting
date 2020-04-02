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

using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.View.Dictionary;


namespace TSD.AccountingSoft.Presenter.Dictionary.BudgetCategory
{
    /// <summary>
    /// Class BudgetCategoryPresenter.
    /// </summary>
    public class BudgetCategoryPresenter : Presenter<IBudgetCategoryView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BudgetCategoryPresenter" /> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public BudgetCategoryPresenter(IBudgetCategoryView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays the specified budgetCategory identifier.
        /// </summary>
        /// <param name="budgetCategoryId">The budgetCategory identifier.</param>
        public void Display(string budgetCategoryId)
        {
            if (budgetCategoryId == null) { View.BudgetCategoryId = 0; return; }

            var budgetCategory = Model.GetBudgetCategory(int.Parse(budgetCategoryId));

            View.BudgetCategoryId = budgetCategory.BudgetCategoryId;
            View.BudgetCategoryCode = budgetCategory.BudgetCategoryCode;
            View.BudgetCategoryName = budgetCategory.BudgetCategoryName;
            View.ParentId = budgetCategory.ParentId;
            View.IsParent = budgetCategory.IsParent;
            View.Description = budgetCategory.Description;
            View.IsActive = budgetCategory.IsActive;
            View.IsSystem = budgetCategory.IsSystem;
            View.Grade = budgetCategory.Grade;
            View.ForeignName = budgetCategory.ForeignName;
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int Save()
        {
            var budgetCategory = new BudgetCategoryModel
            {
                BudgetCategoryId = View.BudgetCategoryId,
                BudgetCategoryCode = View.BudgetCategoryCode,
                BudgetCategoryName = View.BudgetCategoryName,
                ParentId = View.ParentId,
                IsParent = View.IsParent,
                Description = View.Description,
                IsActive = View.IsActive,
                IsSystem = View.IsSystem,
                Grade = View.Grade,
                ForeignName = View.ForeignName
            };

            if (View.BudgetCategoryId == 0)
                return Model.AddBudgetCategory(budgetCategory);
            return Model.UpdateBudgetCategory(budgetCategory);
        }

        /// <summary>
        /// Deletes the specified budget category identifier.
        /// </summary>
        /// <param name="budgetCategoryId">The budget category identifier.</param>
        /// <returns>System.Int32.</returns>
        public int Delete(int budgetCategoryId)
        {
            return Model.DeleteBudgetCategory(budgetCategoryId);
        }
    }
}
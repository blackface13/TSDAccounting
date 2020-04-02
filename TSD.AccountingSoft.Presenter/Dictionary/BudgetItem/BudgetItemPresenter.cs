/***********************************************************************
 * <copyright file="SqlServerFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Thursday, February 26, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  07/03/2014       Author    Tudt           Description: Coding standard
 * 
 * ************************************************************************/

using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.View.Dictionary;


namespace TSD.AccountingSoft.Presenter.Dictionary.BudgetItem
{
    /// <summary>
    /// Class BudgetItemPresenter.
    /// </summary>
    public class BudgetItemPresenter : Presenter<IBudgetItemView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BudgetItemPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public BudgetItemPresenter(IBudgetItemView view)
            : base(view)
        {
        }

        public void Display(string budgetItemId)
        {
            if (budgetItemId == null) { View.BudgetItemId = 0; return; }

            var budgetitem = Model.GetBudgetItem(int.Parse(budgetItemId));
            View.BudgetItemId = budgetitem.BudgetItemId;
            View.BudgetGroupId = budgetitem.BudgetGroupId;
            View.BudgetItemName = budgetitem.BudgetItemName;
            View.ForeignName = budgetitem.ForeignName;
            View.ParentId = budgetitem.ParentId;
            View.BudgetItemCode = budgetitem.BudgetItemCode;
            View.IsParent = budgetitem.IsParent;
            View.IsFixedItem = budgetitem.IsFixedItem;
            View.IsExpandItem = budgetitem.IsExpandItem;
            View.IsNoAllocate = budgetitem.IsNoAllocate;
            View.IsOrganItem = budgetitem.IsOrganItem;
            View.IsActive = budgetitem.IsActive;
            View.IsReceipt = budgetitem.IsReceipt;
            View.BudgetItemType = budgetitem.BudgetItemType;
            View.Rate = budgetitem.Rate;
            View.IsShowOnVoucher = budgetitem.IsShowOnVoucher;
        }

        public int Save()
        {
            var budgetItem = new BudgetItemModel();
            budgetItem.BudgetGroupId = View.BudgetGroupId;
            budgetItem.BudgetItemId = View.BudgetItemId;
            budgetItem.BudgetItemName = View.BudgetItemName;
            budgetItem.BudgetItemCode = View.BudgetItemCode;
            budgetItem.ForeignName = View.ForeignName;
            budgetItem.BudgetItemType = View.BudgetItemType;
            budgetItem.ParentId = View.ParentId;
            budgetItem.IsReceipt = View.IsReceipt;
            budgetItem.IsFixedItem = View.IsFixedItem;
            budgetItem.IsExpandItem = View.IsExpandItem;
            budgetItem.IsNoAllocate = View.IsNoAllocate;
            budgetItem.IsOrganItem = View.IsOrganItem;
            budgetItem.IsActive = View.IsActive;
            budgetItem.Rate = View.Rate;
            budgetItem.IsShowOnVoucher = View.IsShowOnVoucher;

            return View.BudgetItemId == 0 ? Model.AddBudgetItem(budgetItem) : Model.UpdateBudgetItem(budgetItem);
        }

        /// <summary>
        /// Deletes the specified budget item identifier.
        /// </summary>
        /// <param name="budgetItemId">The budget item identifier.</param>
        /// <returns>System.Int32.</returns>
        public int Delete(int budgetItemId)
        {
            return Model.DeleteBudgetItem(budgetItemId);
        }
    }
}

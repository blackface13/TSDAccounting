/***********************************************************************
 * <copyright file="SqlServerFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Tuesday, June 13, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  13/06/2017       Author    Tudt           Description: Coding standard
 * 
 * ************************************************************************/

using TSD.AccountingSoft.View.Dictionary;

namespace TSD.AccountingSoft.Presenter.Dictionary.PlanReceiptTempateItem
{
    public class PlanReceiptTempateItemPresenter : Presenter<IPlanReceiptTempateItemView>
    {
        public PlanReceiptTempateItemPresenter(IPlanReceiptTempateItemView view)
            : base(view)
        {
        }
        public void Display(string planReceiptTempateItemId)
        {
            if (planReceiptTempateItemId == null) { View.PlanReceiptTempateItemId = 0; return; }

            //var planReceiptTempateItem = Model.GetBudgetItem(int.Parse(budgetItemId));
            //View.BudgetItemId = budgetitem.BudgetItemId;
            //View.BudgetGroupId = budgetitem.BudgetGroupId;
            //View.BudgetItemName = budgetitem.BudgetItemName;
            //View.ForeignName = budgetitem.ForeignName;
            //View.ParentId = budgetitem.ParentId;
            //View.BudgetItemCode = budgetitem.BudgetItemCode;
            //View.IsParent = budgetitem.IsParent;
            //View.IsFixedItem = budgetitem.IsFixedItem;
            //View.IsExpandItem = budgetitem.IsExpandItem;
            //View.IsNoAllocate = budgetitem.IsNoAllocate;
            //View.IsOrganItem = budgetitem.IsOrganItem;
            //View.IsActive = budgetitem.IsActive;
            //View.IsReceipt = budgetitem.IsReceipt;
            //View.BudgetItemType = budgetitem.BudgetItemType;
            //View.Rate = budgetitem.Rate;
        }
    }
}

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

using TSD.AccountingSoft.View.Dictionary;


namespace TSD.AccountingSoft.Presenter.Dictionary.BudgetItem
{
    /// <summary>
    /// Class BudgetItemsPresenter.
    /// </summary>
    public class BudgetItemsPresenter : Presenter<IBudgetItemsView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BudgetItemsPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public BudgetItemsPresenter(IBudgetItemsView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            View.BudgetItems = Model.GetBudgetItems();
        }

        /// <summary>
        /// Displays the active.
        /// </summary>
        public void DisplayActive()
        {
            View.BudgetItems = Model.GetBudgetItems();
        }

        public void Display(int budgetItemType, bool isActive)
        {
            View.BudgetItems = Model.GetBudgetItemAndSubItem(budgetItemType, isActive);
        }

        /// <summary>
        /// Displays the active.
        /// </summary>
        public void DisplayIsReceipt()
        {
            View.BudgetItems = Model.GetBudgetItemsByReceipt();
        }

        public void DisplayIsCapitalAllocate()
        {
            View.BudgetItems = Model.GetBudgetItemsCapitalAllocate();
        }



        public void DisplayIsReceiptForEstimate()
        {
            View.BudgetItems = Model.GetBudgetItemsByReceiptForEstimate();
        }

        /// <summary>
        /// Displays the active.
        /// </summary>
        public void DisplayIsPayment()
        {
            View.BudgetItems = Model.GetBudgetItemsByPayment();
        }

        public void DisplayPaymentVoucher()
        {
            View.BudgetItems = Model.GetBudgetItemsPayVoucher();
        }
        public void DisplayIsPaymentForEstimate()
        {
            View.BudgetItems = Model.GetBudgetItemsByPaymentForEstimate();
        }
    }
}

/***********************************************************************
 * <copyright file="CapitalAllocatePresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuanHM
 * Email:    Tuanhm@buca.vn
 * Website:
 * Create Date: Friday, March 7, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Presenter.Dictionary.Account;
using TSD.AccountingSoft.View.Dictionary;


namespace TSD.AccountingSoft.Presenter.Dictionary.CapitalAllocate
{
    /// <summary>
    /// Class CapitalAllocatePresenter.
    /// </summary>
    public class CapitalAllocatePresenter : Presenter<ICapitalAllocateView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountPresenter" /> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public CapitalAllocatePresenter(ICapitalAllocateView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays the specified capitalAllocate identifier.
        /// </summary>
        /// <param name="capitalAllocateId">The capital allocate identifier.</param>
        public void Display(string capitalAllocateId)
        {
            if (capitalAllocateId == null) { View.CapitalAllocateId = 0; return; }
            var capitalAllocate = Model.GetCapitalAllocate(int.Parse(capitalAllocateId));
            View.CapitalAllocateId = capitalAllocate.CapitalAllocateId;
            View.BudgetItemCode = capitalAllocate.BudgetItemCode;
            View.BudgetSourceCode = capitalAllocate.BudgetSourceCode;
            View.ActivityId = capitalAllocate.ActivityId;
            View.AllocatePercent = capitalAllocate.AllocatePercent;
            View.AllocateType = capitalAllocate.AllocateType;
            View.DeterminedDate = capitalAllocate.DeterminedDate;
            View.CapitalAccountCode = capitalAllocate.CapitalAccountCode;
            View.RevenueAccountCode = capitalAllocate.RevenueAccountCode;
            View.ExpenseAccountCode = capitalAllocate.ExpenseAccountCode;
            View.Description = capitalAllocate.Description;
            View.IsActive = capitalAllocate.IsActive;
            View.WaitBudgetSourceCode = capitalAllocate.WaitBudgetSourceCode;
            View.CapitalAllocateCode = capitalAllocate.CapitalAllocateCode;
            View.ToDate = DateTime.Parse(capitalAllocate.ToDate);
            View.FromDate = DateTime.Parse(capitalAllocate.FromDate);
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int Save()
        {
            var capitalAllocate = new CapitalAllocateModel();
            capitalAllocate.CapitalAllocateId = View.CapitalAllocateId;
            capitalAllocate.BudgetItemCode = View.BudgetItemCode;
            capitalAllocate.BudgetSourceCode = View.BudgetSourceCode;
            capitalAllocate.ActivityId = View.ActivityId;
            capitalAllocate.AllocatePercent = View.AllocatePercent;
            capitalAllocate.AllocateType = View.AllocateType;
            capitalAllocate.DeterminedDate = View.DeterminedDate;
            capitalAllocate.CapitalAccountCode = View.CapitalAccountCode;
            capitalAllocate.RevenueAccountCode = View.RevenueAccountCode;
            capitalAllocate.ExpenseAccountCode = View.ExpenseAccountCode;
            capitalAllocate.Description = View.Description;
            capitalAllocate.IsActive = View.IsActive;
            capitalAllocate.WaitBudgetSourceCode = View.WaitBudgetSourceCode;
            capitalAllocate.CapitalAllocateCode = View.CapitalAllocateCode;
            capitalAllocate.FromDate = View.FromDate.ToShortDateString();
            capitalAllocate.ToDate = View.ToDate.ToShortDateString();

            if (View.CapitalAllocateId == 0)
                return Model.AddCapitalAllocate(capitalAllocate);
            return Model.UpdateCapitalAllocate(capitalAllocate);
        }

        /// <summary>
        /// Deletes the specified capitalAllocate identifier.
        /// </summary>
        /// <param name="capitalAllocateId">The capitalAllocate identifier.</param>
        /// <returns>System.Int32.</returns>
        public int Delete(int capitalAllocateId)
        {
            return Model.DeleteCapitalAllocate(capitalAllocateId);
        }
    }
}

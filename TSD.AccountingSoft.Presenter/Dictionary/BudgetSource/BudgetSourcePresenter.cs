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


namespace TSD.AccountingSoft.Presenter.Dictionary.BudgetSource
{
    /// <summary>
    /// Class BudgetSourcePresenter.
    /// </summary>
    public class BudgetSourcePresenter : Presenter<IBudgetSourceView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BudgetSourcePresenter" /> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public BudgetSourcePresenter(IBudgetSourceView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays the specified budgetSource identifier.
        /// </summary>
        /// <param name="budgetSourceId">The budgetSource identifier.</param>
        public void Display(string budgetSourceId)
        {
            if (budgetSourceId == null) { View.BudgetSourceId = 0; return; }
            var budgetSource = Model.GetBudgetSource(int.Parse(budgetSourceId));
            View.BudgetSourceId = budgetSource.BudgetSourceId;
            View.BudgetSourceCode = budgetSource.BudgetSourceCode;
            View.BudgetSourceName = budgetSource.BudgetSourceName;
            View.ForeignName = budgetSource.ForeignName;
            View.ParentId = budgetSource.ParentId;
            View.Description = budgetSource.Description;
            View.Grade = budgetSource.Grade;
            View.IsParent = budgetSource.IsParent;
            View.Type = budgetSource.Type;
            View.IsSystem = budgetSource.IsSystem;
            View.IsActive = budgetSource.IsActive;
            View.Allocation = budgetSource.Allocation;
            View.BudgetItemCode = budgetSource.BudgetItemCode;
            View.IsFund = budgetSource.IsFund;
            View.IsExpense = budgetSource.IsExpense;
            View.AccountCode = budgetSource.AccountCode;
            View.AutonomyBudgetType = budgetSource.AutonomyBudgetType;
            View.BudgetCode = budgetSource.BudgetCode;
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int Save()
        {
            var budgetSource = new BudgetSourceModel
            {
                BudgetSourceId = View.BudgetSourceId,
                BudgetSourceCode = View.BudgetSourceCode,
                BudgetSourceName = View.BudgetSourceName,
                ForeignName = View.ForeignName,
                ParentId = View.ParentId,
                Description = View.Description,
                Grade = View.Grade,
                IsParent = View.IsParent,
                Type = View.Type,
                IsSystem = View.IsSystem,
                IsActive = View.IsActive,
                Allocation = View.Allocation,
                BudgetItemCode = View.BudgetItemCode,
                IsFund = View.IsFund,
                IsExpense = View.IsExpense,
                AccountCode = View.AccountCode,
                AutonomyBudgetType = View.AutonomyBudgetType,
                BudgetCode = View.BudgetCode
            };

            if (View.BudgetSourceId == 0)
                return Model.AddBudgetSource(budgetSource);
            return Model.UpdateBudgetSource(budgetSource);
        }

        /// <summary>
        /// Deletes the specified budget source identifier.
        /// </summary>
        /// <param name="budgetSourceId">The budget source identifier.</param>
        /// <returns>System.Int32.</returns>
        public int Delete(int budgetSourceId)
        {
            return Model.DeleteBudgetSource(budgetSourceId);
        }
    }
}
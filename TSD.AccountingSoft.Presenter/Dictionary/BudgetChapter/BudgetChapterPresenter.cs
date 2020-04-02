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


namespace TSD.AccountingSoft.Presenter.Dictionary.BudgetChapter
{
    /// <summary>
    /// Class BudgetChapterPresenter.
    /// </summary>
    public class BudgetChapterPresenter : Presenter<IBudgetChapterView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BudgetChapterPresenter" /> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public BudgetChapterPresenter(IBudgetChapterView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays the specified budget chapter identifier.
        /// </summary>
        /// <param name="budgetChapterId">The budget chapter identifier.</param>
        public void Display(string budgetChapterId)
        {
            if (budgetChapterId == null) { View.BudgetChapterId = 0; return; }
            var budgetChapter = Model.GetBudgetChapter(int.Parse(budgetChapterId));
            View.BudgetChapterId = budgetChapter.BudgetChapterId;
            View.BudgetChapterCode = budgetChapter.BudgetChapterCode;
            View.BudgetChapterName = budgetChapter.BudgetChapterName;
            View.Description = budgetChapter.Description;
            View.IsActive = budgetChapter.IsActive;
            View.IsSystem = budgetChapter.IsSystem;
            View.ForeignName = budgetChapter.ForeignName;
        }

        /// <summary>
        /// Deletes the specified budget chapter identifier.
        /// </summary>
        /// <param name="budgetChapterId">The budget chapter identifier.</param>
        /// <returns>System.Int32.</returns>
        public int Delete(int budgetChapterId)
        {
            return Model.DeleteBudgetChapter(budgetChapterId);
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int Save()
        {
            var budgetChapter = new BudgetChapterModel
            {
                BudgetChapterId = View.BudgetChapterId,
                BudgetChapterCode = View.BudgetChapterCode,
                BudgetChapterName = View.BudgetChapterName,
                Description = View.Description,
                IsSystem = View.IsSystem,
                IsActive = View.IsActive,
                ForeignName = View.ForeignName
            };

            if (View.BudgetChapterId == 0)
                return Model.AddBudgetChapter(budgetChapter);
            return Model.UpdateBudgetChapter(budgetChapter);
        }
    }
}

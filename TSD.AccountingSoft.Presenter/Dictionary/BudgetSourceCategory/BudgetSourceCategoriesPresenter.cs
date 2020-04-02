/***********************************************************************
 * <copyright file="BudgetSourceCategoriesPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 19 June 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using TSD.AccountingSoft.View.Dictionary;


namespace TSD.AccountingSoft.Presenter.Dictionary.BudgetSourceCategory
{
    /// <summary>
    /// class BudgetSourceCategoriesPresente
    /// </summary>
    public class BudgetSourceCategoriesPresenter : Presenter<IBudgetSourceCategoriesView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BudgetSourceCategoriesPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public BudgetSourceCategoriesPresenter(IBudgetSourceCategoriesView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displaies this instance.
        /// </summary>
        public void Display()
        {
            View.BudgetSourceCategories = Model.GetBudgetSourceCategories();
        }

        /// <summary>
        /// Displaies the active.
        /// </summary>
        public void DisplayActive()
        {
            View.BudgetSourceCategories = Model.GetBudgetSourceCategoriesActive();
        }
    }
}

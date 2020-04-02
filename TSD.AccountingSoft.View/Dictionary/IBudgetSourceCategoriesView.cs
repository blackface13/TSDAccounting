/***********************************************************************
 * <copyright file="IBudgetSourceCategoriesView.cs" company="BUCA JSC">
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

using System.Collections.Generic;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;


namespace TSD.AccountingSoft.View.Dictionary
{
    /// <summary>
    /// IBudgetSourceCategoriesView
    /// </summary>
    public interface IBudgetSourceCategoriesView : IView
    {
        /// <summary>
        /// Sets the budget source categories.
        /// </summary>
        /// <value>
        /// The budget source categories.
        /// </value>
        IList<BudgetSourceCategoryModel> BudgetSourceCategories { set; }
    }
}

/***********************************************************************
 * <copyright file="IBudgetCategoriesView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   THODD
 * Email:    thodd@buca.vn
 * Website:
 * Create Date: 07 March 2014
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
    /// Interface IBudgetCategoriesView
    /// </summary>
    public interface IBudgetCategoriesView:IView
    {
        /// <summary>
        /// Sets the budget categories.
        /// </summary>
        /// <value>The budget categories.</value>
        IList<BudgetCategoryModel> BudgetCategories { set; }
    }
}

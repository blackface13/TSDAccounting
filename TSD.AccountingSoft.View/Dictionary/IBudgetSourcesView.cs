/***********************************************************************
 * <copyright file="IBudgetSourcesView.cs" company="BUCA JSC">
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
    /// Interface IBudgetSourcesView
    /// </summary>
    public interface IBudgetSourcesView : IView
    {
        /// <summary>
        /// Sets the budget sources.
        /// </summary>
        /// <value>The budget sources.</value>
        IList<BudgetSourceModel> BudgetSources { set; }
    }
}

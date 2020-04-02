/***********************************************************************
 * <copyright file="IAccountCategoriesView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   BangNC
 * Email:    BangNC@buca.vn
 * Website:
 * Create Date: Thursday, March 13, 2014
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
    /// Interface IAccountCategoriesView
    /// </summary>
    public interface IAccountCategoriesView : IView
    {
        /// <summary>
        /// Sets the account categories.
        /// </summary>
        /// <value>The account categories.</value>
        IList<AccountCategoryModel> AccountCategories { set; }
    }
}

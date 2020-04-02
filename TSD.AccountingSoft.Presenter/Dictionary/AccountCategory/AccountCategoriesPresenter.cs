/***********************************************************************
 * <copyright file="AccountCategoriesPresenter.cs" company="BUCA JSC">
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
using TSD.AccountingSoft.View.Dictionary;


namespace TSD.AccountingSoft.Presenter.Dictionary.AccountCategory
{

    /// <summary>
    /// class AccountCategoriesPresenter 
    /// </summary>
    public class AccountCategoriesPresenter : Presenter<IAccountCategoriesView>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountCategoriesPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public AccountCategoriesPresenter(IAccountCategoriesView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            View.AccountCategories = Model.GetAccountCategories();
        }

        /// <summary>
        /// Get list Account Category
        /// </summary>
        /// <returns>IList{Model.BusinessObjects.Dictionary.AccountCategoryModel}.</returns>
        public IList<Model.BusinessObjects.Dictionary.AccountCategoryModel> GetAccountCategories()
        {
            return Model.GetAccountCategories();
        }

        /// <summary>
        /// Displays the active.
        /// </summary>
        public void DisplayActive()
        {
            View.AccountCategories = Model.GetAccountCategoriesActive();
        }

        /// <summary>
        /// Displays for combo tree.
        /// </summary>
        /// <param name="accountCategoryId">The account category identifier.</param>
        public void DisplayForComboTree(int accountCategoryId)
        {
            View.AccountCategories = Model.GetAccountCategoriesForComboTree(accountCategoryId);
        }
    }
}

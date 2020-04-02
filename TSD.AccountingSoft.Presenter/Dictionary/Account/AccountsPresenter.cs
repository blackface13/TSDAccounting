/***********************************************************************
 * <copyright file="AccountsPresenter.cs" company="BUCA JSC">
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
using TSD.AccountingSoft.View.Dictionary;


namespace TSD.AccountingSoft.Presenter.Dictionary.Account
{
    /// <summary>
    /// class AccountsPresenter
    /// </summary>
    public class AccountsPresenter : Presenter<IAccountsView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountsPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public AccountsPresenter(IAccountsView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            View.Accounts = Model.GetAccounts();
        }

        /// <summary>
        /// Displays the specified is detail.
        /// </summary>
        /// <param name="isDetail">if set to <c>true</c> [is detail].</param>
        public void Display(bool isDetail)
        {
            View.Accounts = Model.GetAccounts(isDetail);
        }
        public IList<Model.BusinessObjects.Dictionary.AccountModel> GetAccounts()
        {
            return Model.GetAccounts();
        }
        /// <summary>
        /// Displays the specified account identifier.
        /// </summary>
        /// <param name="accountCode">The account code.</param>
        /// <returns></returns>
        public AccountModel GetAcount(string accountCode) 
        {
            if (accountCode == null)
                return null;
            var account = Model.GetAccountByCode(accountCode);
            return account;
        }

        /// <summary>
        /// Displays the active.
        /// </summary>
        public void DisplayActive()
        {
            View.Accounts = Model.GetAccountsActive();
        }

        /// <summary>
        /// Get List Accounts by Active
        /// </summary>
        /// <returns></returns>
        public IList<AccountModel> GetAccountsActive()
        {
            return Model.GetAccountsActive();
        }

        /// <summary>
        /// Displays the active.
        /// </summary>
        public void DisplayInventoryItem()
        {
            View.Accounts = Model.GetAccountsInventoryItem();
        }

        /// <summary>
        /// Displays for combo tree.
        /// </summary>
        /// <param name="accountId">The account identifier.</param>
        public void DisplayForComboTree(int accountId)
        {
            View.Accounts = Model.GetAccountsForComboTree(accountId);
        }
    }
}

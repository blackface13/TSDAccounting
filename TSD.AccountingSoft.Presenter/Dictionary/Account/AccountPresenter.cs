/***********************************************************************
 * <copyright file="AccountPresenter.cs" company="BUCA JSC">
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

using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.View.Dictionary;


namespace TSD.AccountingSoft.Presenter.Dictionary.Account
{
    /// <summary>
    /// class AccountPresenter 
    /// </summary>
    public class AccountPresenter : Presenter<IAccountView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public AccountPresenter(IAccountView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays the specified account identifier.
        /// </summary>
        /// <param name="accountId">The account identifier.</param>
        public void Display(string accountId)
        {
            if (accountId == null)
            {
                View.AccountId = 0; 
                return;
            }

            var account = Model.GetAccount(int.Parse(accountId));
            View.AccountId = account.AccountId;
            View.AccountCategoryId = account.AccountCategoryId;
            View.AccountCode = account.AccountCode;
            View.AccountName = account.AccountName;
            View.ForeignName = account.ForeignName;
            View.ParentId = account.ParentId;
            View.Grade = account.Grade;
            View.IsDetail = account.IsDetail;
            View.Description = account.Description;
            View.BalanceSide = account.BalanceSide;
            View.ConcomitantAccount = account.ConcomitantAccount;
            View.BankId = account.BankId;
            View.CurrencyCode = account.CurrencyCode;
            View.IsChapter = account.IsChapter;
            View.IsBudgetCategory = account.IsBudgetCategory;
            View.IsBudgetItem = account.IsBudgetItem;
            View.IsBudgetGroup = account.IsBudgetGroup;
            View.IsBudgetSource = account.IsBudgetSource;
            View.IsActivity = account.IsActivity;
            View.IsCurrency = account.IsCurrency;
            View.IsCustomer = account.IsCustomer;
            View.IsVendor = account.IsVendor;
            View.IsEmployee = account.IsEmployee;
            View.IsAccountingObject = account.IsAccountingObject;
            View.IsInventoryItem = account.IsInventoryItem;
            View.IsFixedAsset = account.IsFixedAsset;
            View.IsCapitalAllocate = account.IsCapitalAllocate;
            View.IsActive = account.IsActive;
            View.IsSystem = account.IsSystem;
            View.IsProject = account.IsProject;
            View.IsAllowinputcts = account.IsAllowinputcts;
            View.IsBank = account.IsBank;
            View.IsBudgetSubItem = account.IsBudgetSubItem;
        }

        /// <summary>
        /// Displays the by account code.
        /// </summary>
        /// <param name="accountCode">The account code.</param>
        public void DisplayByAccountCode(string accountCode)
        {
            if (accountCode == null)
            {
                View.AccountId = 0; 
                return;
            }

            var account = Model.GetAccountByCode(accountCode);
            View.AccountId = account.AccountId;
            View.AccountCategoryId = account.AccountCategoryId;
            View.AccountCode = account.AccountCode;
            View.AccountName = account.AccountName;
            View.ForeignName = account.ForeignName;
            View.ParentId = account.ParentId;
            View.Grade = account.Grade;
            View.IsDetail = account.IsDetail;
            View.Description = account.Description;
            View.BalanceSide = account.BalanceSide;
            View.ConcomitantAccount = account.ConcomitantAccount;
            View.BankId = account.BankId;
            View.CurrencyCode = account.CurrencyCode;
            View.IsChapter = account.IsChapter;
            View.IsBudgetCategory = account.IsBudgetCategory;
            View.IsBudgetItem = account.IsBudgetItem;
            View.IsBudgetGroup = account.IsBudgetGroup;
            View.IsBudgetSource = account.IsBudgetSource;
            View.IsActivity = account.IsActivity;
            View.IsCurrency = account.IsCurrency;
            View.IsCustomer = account.IsCustomer;
            View.IsVendor = account.IsVendor;
            View.IsEmployee = account.IsEmployee;
            View.IsAccountingObject = account.IsAccountingObject;
            View.IsInventoryItem = account.IsInventoryItem;
            View.IsFixedAsset = account.IsFixedAsset;
            View.IsCapitalAllocate = account.IsCapitalAllocate;
            View.IsActive = account.IsActive;
            View.IsSystem = account.IsSystem;
            View.IsProject = account.IsProject;
            View.IsAllowinputcts = account.IsAllowinputcts;
            View.IsBank = account.IsBank;
            View.IsBudgetSubItem = account.IsBudgetSubItem;
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        public int Save()
        {
            var account = new AccountModel
            {
                AccountId = View.AccountId,
                AccountCategoryId = View.AccountCategoryId,
                AccountCode = View.AccountCode,
                AccountName = View.AccountName,
                ForeignName = View.ForeignName,
                ParentId = View.ParentId,
                Grade = View.Grade,
                IsDetail = View.IsDetail,
                Description = View.Description,
                BalanceSide = View.BalanceSide,
                ConcomitantAccount = View.ConcomitantAccount,
                BankId = View.BankId,
                CurrencyCode = View.CurrencyCode ,
                IsChapter = View.IsChapter,
                IsBudgetCategory = View.IsBudgetCategory,
                IsBudgetGroup = View.IsBudgetGroup,
                IsBudgetItem = View.IsBudgetItem,
                IsBudgetSource = View.IsBudgetSource,
                IsActivity = View.IsActivity,
                IsCurrency = View.IsCurrency,
                IsCustomer = View.IsCustomer,
                IsVendor = View.IsVendor,
                IsEmployee = View.IsEmployee,
                IsAccountingObject = View.IsAccountingObject,
                IsInventoryItem = View.IsInventoryItem,
                IsFixedAsset = View.IsFixedAsset,
                IsCapitalAllocate = View.IsCapitalAllocate,
                IsActive = View.IsActive,
                IsSystem = View.IsSystem,
                IsAllowinputcts = View.IsAllowinputcts ,
                IsProject = View.IsProject, 
                IsBank = View.IsBank,
                IsBudgetSubItem = View.IsBudgetSubItem
            };

            return View.AccountId == 0 ? Model.AddAccount(account) : Model.UpdateAccount(account);
        }

        /// <summary>
        /// Deletes the specified accont identifier.
        /// </summary>
        /// <param name="accountId">The accont identifier.</param>
        /// <returns></returns>
        public int Delete(int accountId)
        {
            return Model.DeleteAccount(accountId);
        }
    }
}

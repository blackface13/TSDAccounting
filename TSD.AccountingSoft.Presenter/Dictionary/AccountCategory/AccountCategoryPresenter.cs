/***********************************************************************
 * <copyright file="AccountCategoryPresenter.cs" company="BUCA JSC">
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


namespace TSD.AccountingSoft.Presenter.Dictionary.AccountCategory
{
    /// <summary>
    /// Class AccountCategoryPresenter.
    /// </summary>
    public class AccountCategoryPresenter : Presenter<IAccountCategoryView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountCategoryPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public AccountCategoryPresenter(IAccountCategoryView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays the specified account category identifier.
        /// </summary>
        /// <param name="accountCategoryId">The account category identifier.</param>
        public void Display(string accountCategoryId)
        {
            if (accountCategoryId == null)
            {
                View.AccountCategoryId = 0;
                return;
            }

            var accountCategory = Model.GetAccountCategory(int.Parse(accountCategoryId));

            View.AccountCategoryId = accountCategory.AccountCategoryId;
            View.AccountCategoryCode = accountCategory.AccountCategoryCode;
            View.AccountCategoryName = accountCategory.AccountCategoryName;
            View.ForeignName = accountCategory.ForeignName;
            View.ParentId = accountCategory.ParentId;
            View.Grade = accountCategory.Grade;
            View.IsDetail = accountCategory.IsDetail;
            View.IsActive = accountCategory.IsActive;
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int Save()
        {
            var accountCategory = new AccountCategoryModel
                {
                    AccountCategoryId = View.AccountCategoryId,
                    AccountCategoryCode = View.AccountCategoryCode,
                    AccountCategoryName = View.AccountCategoryName,
                    ForeignName = View.ForeignName,
                    ParentId = View.ParentId,
                    Grade = View.Grade,
                    IsDetail = View.IsDetail,
                    IsActive = View.IsActive
                };

            if (View.AccountCategoryId == 0)
                return Model.AddAccountCategory(accountCategory);
            return Model.UpdateAccountCategory(accountCategory);
        }

        /// <summary>
        /// Deletes the specified account category identifier.
        /// </summary>
        /// <param name="accountCategoryId">The account category identifier.</param>
        /// <returns>System.Int32.</returns>
        public int Delete(int accountCategoryId)
        {
            return Model.DeleteAccountCategory(accountCategoryId);
        }
    }
}

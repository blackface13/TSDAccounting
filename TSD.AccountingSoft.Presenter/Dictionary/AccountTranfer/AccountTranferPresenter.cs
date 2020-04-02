/***********************************************************************
 * <copyright file="AccountTranferPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 07 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.View.Dictionary;


namespace TSD.AccountingSoft.Presenter.Dictionary.AccountTranfer
{
    /// <summary>
    /// AccountTranferPresenter
    /// </summary>
    public class AccountTranferPresenter : Presenter<IAccountTranferView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountTranferPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public AccountTranferPresenter(IAccountTranferView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays the specified account tranfer identifier.
        /// </summary>
        /// <param name="accountTranferId">The account tranfer identifier.</param>
        public void Display(string accountTranferId)
        {
            if (accountTranferId == null) { View.AccountTranferId = 0; return; }

            var accountTranfer = Model.GetAccountTranfer(int.Parse(accountTranferId));

            View.AccountTranferId = accountTranfer.AccountTranferId;
            View.AccountTranferCode = accountTranfer.AccountTranferCode;
            View.SortOrder = accountTranfer.SortOrder;
            View.AccountSourceCode = accountTranfer.AccountSourceCode;
            View.AccountDestinationCode = accountTranfer.AccountDestinationCode;
            View.ReferentAccount = accountTranfer.ReferentAccount;
            View.BudgetSourceId = accountTranfer.BudgetSourceId;
            View.SideOfTranfer = accountTranfer.SideOfTranfer;
            View.Type = accountTranfer.Type;
            View.Description = accountTranfer.Description;
            View.IsActive = accountTranfer.IsActive;
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        public int Save()
        {
            var accountTranfer = new AccountTranferModel
            {
                AccountTranferId = View.AccountTranferId,
                AccountTranferCode = View.AccountTranferCode,
                SortOrder = View.SortOrder,
                AccountSourceCode = View.AccountSourceCode,
                AccountDestinationCode = View.AccountDestinationCode,
                ReferentAccount = View.ReferentAccount,
                BudgetSourceId = View.BudgetSourceId,
                SideOfTranfer = View.SideOfTranfer,
                Type = View.Type,
                Description = View.Description,
                IsActive = View.IsActive
            };

            return View.AccountTranferId == 0 ? Model.AddAccountTranfer(accountTranfer) : Model.UpdateAccountTranfer(accountTranfer);
        }

        /// <summary>
        /// Deletes the specified account tranfer identifier.
        /// </summary>
        /// <param name="accountTranferId">The account tranfer identifier.</param>
        /// <returns></returns>
        public int Delete(int accountTranferId)
        {
            return Model.DeleteAccountTranfer(accountTranferId);
        }
    }
}

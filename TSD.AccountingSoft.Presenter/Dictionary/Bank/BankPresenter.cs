/***********************************************************************
 * <copyright file="BankPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 08 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.View.Dictionary;


namespace TSD.AccountingSoft.Presenter.Dictionary.Bank
{
    /// <summary>
    /// BankPresenter
    /// </summary>
    public class BankPresenter : Presenter<IBankView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BankPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public BankPresenter(IBankView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays the specified bank identifier.
        /// </summary>
        /// <param name="bankId">The bank identifier.</param>
        public void Display(string bankId)
        {
            if (bankId == null) { View.BankId = 0; return; }

            var bank = Model.GetBank(int.Parse(bankId));

            View.BankId = bank.BankId;
            View.BankAccount = bank.BankAccount;
            View.BankAddress = bank.BankAddress;
            View.BankName = bank.BankName;
            View.Description = bank.Description;
            View.IsActive = bank.IsActive;
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        public int Save()
        {
            var bank = new BankModel
            {
                BankId = View.BankId,
                BankAccount = View.BankAccount,
                BankAddress = View.BankAddress,
                BankName = View.BankName,
                Description = View.Description,
                IsActive = View.IsActive
            };

            return View.BankId == 0 ? Model.AddBank(bank) : Model.UpdateBank(bank);
        }

        /// <summary>
        /// Deletes the specified bank identifier.
        /// </summary>
        /// <param name="bankId">The bank identifier.</param>
        /// <returns></returns>
        public int Delete(int bankId)
        {
            return Model.DeleteBank(bankId);
        }
    }
}

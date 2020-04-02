/***********************************************************************
 * <copyright file="CurrencyPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuanHM
 * Email:    Tuanhm@buca.vn
 * Website:
 * Create Date: Friday, March 7, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Presenter.Dictionary.Account;
using TSD.AccountingSoft.View.Dictionary;


namespace TSD.AccountingSoft.Presenter.Dictionary.Currency  
{
    /// <summary>
    /// Class CurrencyPresenter.
    /// </summary>
    public class CurrencyPresenter : Presenter<ICurrencyView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountPresenter" /> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public CurrencyPresenter(ICurrencyView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays the specified currency identifier.
        /// </summary>
        /// <param name="currencyId">The currency identifier.</param>
        public void Display(string currencyId) 
        {
            if (currencyId == null) { View.CurrencyId = 0; return; }
            var currency = Model.GetCurrency(int.Parse(currencyId));
            View.CurrencyId = currency.CurrencyId;
            View.CurrencyCode = currency.CurrencyCode;
            View.CurrencyName = currency.CurrencyName;
            View.Prefix = currency.Prefix;
            View.Suffix = currency.Suffix;
            View.IsMain = currency.IsMain;
            View.IsActive = currency.IsActive;
        }

        public void DisplayByCurrencyCode(string currencyCode)
        {
            if (currencyCode == null)
            {
                View.CurrencyId = 0; 
                return;
            }
            var currency = Model.GetCurrencyByCurrencyCode(currencyCode);
            View.CurrencyId = currency.CurrencyId;
            View.CurrencyCode = currency.CurrencyCode;
            View.CurrencyName = currency.CurrencyName;
            View.Prefix = currency.Prefix;
            View.Suffix = currency.Suffix;
            View.IsMain = currency.IsMain;
            View.IsActive = currency.IsActive;
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int Save()
        {
            var currency = new CurrencyModel  
            {
                CurrencyId = View.CurrencyId,
                CurrencyCode = View.CurrencyCode,
                CurrencyName = View.CurrencyName,
                Prefix = View.Prefix,
                Suffix = View.Suffix,
                IsMain = View.IsMain,
                IsActive = View.IsActive 
            };

            if (View.CurrencyId == 0)
                return Model.AddCurrency(currency);
            return Model.UpdateCurrency(currency);
        }

        /// <summary>
        /// Deletes the specified currency identifier.
        /// </summary>
        /// <param name="currencyId">The currency identifier.</param>
        /// <returns>System.Int32.</returns>
        public int Delete(int currencyId) 
        {
            return Model.DeleteCurrency(currencyId);
        }
    }
}

/***********************************************************************
 * <copyright file="CurrenciesPresenter.cs" company="BUCA JSC">
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

using TSD.AccountingSoft.View.Dictionary;


namespace TSD.AccountingSoft.Presenter.Dictionary.Currency 
{
    /// <summary>
    /// Class CurrenciesPresenter.
    /// </summary>
    public class CurrenciesPresenter : Presenter<ICurrenciesView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CurrenciesPresenter" /> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public CurrenciesPresenter(ICurrenciesView view) 
            : base(view)
        {
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            View.Currencies = Model.GetCurrencies();
        }

        /// <summary>
        /// DisplayIsMain this instance.
        /// </summary>
        public void DisplayIsMain() 
        {
            View.Currencies = Model.GetCurrenciesIsMain();
        }
        /// <summary>
        /// Displays the active.
        /// </summary>
        public void DisplayActive()
        {
            View.Currencies = Model.GetCurrenciesActive();
        }
 
    }
}

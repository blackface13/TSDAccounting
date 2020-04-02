/***********************************************************************
 * <copyright file="ExchangeRatesPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Tuesday, August 18, 2015
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using TSD.AccountingSoft.Presenter.Dictionary.Bank;
using TSD.AccountingSoft.View.Dictionary;

namespace TSD.AccountingSoft.Presenter.Dictionary.ExchangeRate
{
    /// <summary>
    /// BanksPresenter
    /// </summary>
    public class ExchangeRatesPresenter : Presenter<IExchangeRatesView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BanksPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public ExchangeRatesPresenter(IExchangeRatesView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            View.ExchangeRateModels = Model.GetExchangeRates();
        }

        /// <summary>
        /// Displays the active.
        /// </summary>
        public void DisplayActive()
        {
            View.ExchangeRateModels = Model.GetExchangeRatesByActive(false);
        }
    }
}

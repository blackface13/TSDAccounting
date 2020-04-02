/***********************************************************************
 * <copyright file="ExchangeRatePresenter.cs" company="BUCA JSC">
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

using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Presenter.Dictionary.Bank;
using TSD.AccountingSoft.View.Dictionary;

namespace TSD.AccountingSoft.Presenter.Dictionary.ExchangeRate
{
    /// <summary>
    /// BankPresenter
    /// </summary>
    public class ExchangeRatePresenter : Presenter<IExchangeRateView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BankPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public ExchangeRatePresenter(IExchangeRateView view)
            : base(view)
        {
        }

        public void Display(int exchangeRateId)
        {
            var exchangeRate = Model.GetExchangeRate(exchangeRateId);

            View.ExchangeRateId = exchangeRate.ExchangeRateId;
            View.Description = exchangeRate.Description;
            View.FromDate = exchangeRate.FromDate;
            View.ToDate = exchangeRate.ToDate;
            View.ExchangeRate = exchangeRate.ExchangeRate;
            View.BudgetSourceCode = exchangeRate.BudgetSourceCode;
            View.Inactive = exchangeRate.Inactive;
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        public int Save()
        {
            var exchangeRate = new ExchangeRateModel
            {
                ExchangeRateId = View.ExchangeRateId,
                Description = View.Description,
                FromDate = View.FromDate,
                ToDate = View.ToDate,
                ExchangeRate = View.ExchangeRate,
                BudgetSourceCode = View.BudgetSourceCode,
                Inactive = View.Inactive
            };

            return View.ExchangeRateId == 0 ? Model.AddExchangeRate(exchangeRate) : Model.UpdateExchangeRate(exchangeRate);
        }

        /// <summary>
        /// Deletes the specified exchange rate identifier.
        /// </summary>
        /// <param name="exchangeRateId">The exchange rate identifier.</param>
        /// <returns></returns>
        public int Delete(int exchangeRateId)
        {
            return Model.DeleteExchangeRate(exchangeRateId);
        }
    }
}

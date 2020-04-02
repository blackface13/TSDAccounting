/***********************************************************************
 * <copyright file="StocksPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: Wednesday, March 12, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using TSD.AccountingSoft.View.Dictionary;


namespace TSD.AccountingSoft.Presenter.Dictionary.Stock
{
    public class StocksPresenter:Presenter<IStocksView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StocksPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public StocksPresenter(IStocksView view)
            : base(view)
        { 
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            View.Stocks = Model.GetStocks();
        }

        /// <summary>
        /// Displays the active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        public void DisplayActive(bool isActive)
        {
            View.Stocks = Model.GetStockByActives(isActive);
        } 

    }
}

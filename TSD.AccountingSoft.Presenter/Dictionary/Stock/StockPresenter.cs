/***********************************************************************
 * <copyright file="StockPresenter.cs" company="BUCA JSC">
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

using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.View.Dictionary;


namespace TSD.AccountingSoft.Presenter.Dictionary.Stock
{
    public class StockPresenter : Presenter<IStockView>
    {
        public StockPresenter(IStockView view)
            : base(view)
        {

        }

        /// <summary>
        /// Displays the specified stock identifier.
        /// </summary>
        /// <param name="stockId">The stock identifier.</param>
        public void Display(string stockId)
        {
            if (stockId == null) { View.StockId = 0; return; }
            var obj = Model.GetStock(int.Parse(stockId));
            View.StockId = obj.StockId;
            View.StockCode = obj.StockCode;
            View.StockName = obj.StockName;
            View.Description = obj.Description;
            View.IsActive = obj.IsActive;
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int Save()
        {
            var obj = new StockModel
                {
                    StockId = View.StockId,
                    StockCode = View.StockCode,
                    StockName = View.StockName,
                    Description = View.Description,
                    IsActive = View.IsActive
                };
            return View.StockId == 0 ? Model.InsertStock(obj) : Model.UpdateStock(obj);
        }

        /// <summary>
        /// Deletes the specified stock identifier.
        /// </summary>
        /// <param name="stockId">The stock identifier.</param>
        /// <returns>System.Int32.</returns>
        public int Delete(int stockId)
        {
            return Model.DeleteStock(stockId);
        }
    }
}

/***********************************************************************
 * <copyright file="IStockDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: Friday, March 14, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using TSD.AccountingSoft.BusinessEntities.Dictionary;


namespace TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary
{
    /// <summary>
    /// Interface IStockDao
    /// </summary>
  public  interface IStockDao
    {
        /// <summary>
        /// Gets the stock.
        /// </summary>
        /// <param name="stockId">The stock identifier.</param>
        /// <returns></returns>
        StockEntity GetStock(int stockId);

        /// <summary>
        /// Gets the stocks.
        /// </summary>
        /// <returns></returns>
        List<StockEntity> GetStocks();

        /// <summary>
        /// Inserts the stock.
        /// </summary>
        /// <param name="stock">The stock.</param>
        /// <returns></returns>
        int InsertStock(StockEntity stock);

        /// <summary>
        /// Updates the stock.
        /// </summary>
        /// <param name="stock">The stock.</param>
        /// <returns></returns>
        string UpdateStock(StockEntity stock);

        /// <summary>
        /// Deletes the stock.
        /// </summary>
        /// <param name="stockId">The stock identifier.</param>
        /// <returns></returns>
        string DeleteStock(int stockId);

        /// <summary>
        /// Gets the stocks by active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        List<StockEntity> GetStocksByActive(bool isActive);

        /// <summary>
        /// Lấy danh sách các kho theo mã
        /// </summary>
        /// <param name="stockCode"></param>
        /// <returns></returns>
        List<StockEntity> GetStocksByStockCode(string stockCode);


    }
}

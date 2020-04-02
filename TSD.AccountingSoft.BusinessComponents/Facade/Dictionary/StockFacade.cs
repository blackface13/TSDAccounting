/***********************************************************************
 * <copyright file="StockFacade.cs" company="BUCA JSC">
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
using System;
using System.Linq;
using TSD.AccountingSoft.BusinessComponents.Messages.Dictionary;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary;


namespace TSD.AccountingSoft.BusinessComponents.Facade.Dictionary
{
    /// <summary>
    /// Class StockFacade.
    /// </summary>
  public class StockFacade
    {
        /// <summary>
        /// The stock DAO
        /// </summary>
        private static readonly IStockDao StockDao = DataAccess.DataAccess.StockDao;
        private static readonly IAutoNumberListDao AutoNumberListDao = DataAccess.DataAccess.AutoNumberListDao;

        /// <summary>
        /// Getses the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>StockResponse.</returns>
        public StockResponse Gets(StockRequest request)
        {
            var response = new StockResponse();
            if (request.LoadOptions.Contains("Stocks"))
            {
                if (request.LoadOptions.Contains("IsActive"))
                    response.Stocks = StockDao.GetStocksByActive(true);
                else response.Stocks = StockDao.GetStocks();
            }
            if (request.LoadOptions.Contains("Stock")) response.Stock = StockDao.GetStock(request.StockId);
                return response;
        }

        /// <summary>
        /// Setses the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>StockResponse.</returns>
        public StockResponse Sets(StockRequest request)
        {
            var response = new StockResponse();
            var stockEntity = request.Stock;
            if (request.Action != PersistType.Delete)
            {
                if (!stockEntity.Validate())
                {
                    foreach (string error in stockEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
            }
            try
            {
                if (request.Action == PersistType.Insert)
                {
                    var lstStocks = StockDao.GetStocksByStockCode(stockEntity.StockCode);
                    if (lstStocks.Count > 0) 
                        response.Message = "Mã kho " + stockEntity.StockCode + " đã tồn tại!";
                    else
                    {
                        AutoNumberListDao.UpdateIncreateAutoNumberListByValue("Stock");
                        stockEntity.StockId = StockDao.InsertStock(stockEntity);
                        response.Message = null;
                    }
                }
                else if (request.Action == PersistType.Update)

                {
                    var objStocks = StockDao.GetStocksByStockCode(stockEntity.StockCode).FirstOrDefault();
                    if (objStocks == null)
                        response.Message = StockDao.UpdateStock(stockEntity);
                    else
                    {
                        if (objStocks.StockId == stockEntity.StockId)
                            response.Message = StockDao.UpdateStock(stockEntity);
                        else
                            response.Message = "Mã kho " + stockEntity.StockCode + " đã tồn tại!";
                    }
                }

                else  
                    response.Message = StockDao.DeleteStock(request.StockId);

            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }

            response.StockId = stockEntity != null ? stockEntity.StockId : 0;
            response.Acknowledge = response.Message != null ? AcknowledgeType.Failure : AcknowledgeType.Success;
            return response;
        }

    }
}

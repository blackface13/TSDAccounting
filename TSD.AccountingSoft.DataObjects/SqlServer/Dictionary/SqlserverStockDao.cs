/***********************************************************************
 * <copyright file="SqlserverStockDao.cs" company="BUCA JSC">
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
using System.Collections.Generic;
using System.Data;
using TSD.AccountingSoft.BusinessEntities.Dictionary;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary;
using TSD.AccountingSoft.DataHelpers;


namespace TSD.AccountingSoft.DataAccess.SqlServer.Dictionary
{
    /// <summary>
    /// Class SqlserverStockDao.
    /// </summary>
    public class SqlserverStockDao : IStockDao
    {
        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, StockEntity> Make = reader =>
             new StockEntity
                 {
                     StockId = reader["StockId"].AsId(),
                     StockCode = reader["StockCode"].AsString(),
                     StockName = reader["StockName"].AsString(),
                     Description = reader["Description"].AsString(),
                     IsActive = reader["IsActive"].AsBool()
                 };

        /// <summary>
        /// Takes the specified stock.
        /// </summary>
        /// <param name="stock">The stock.</param>
        /// <returns></returns>
        private object[] Take(StockEntity stock)
        {
            return new object[]  
            {
                "@StockID" , stock.StockId,
                "@StockCode" , stock.StockCode,
                "@StockName" , stock.StockName,
                "@Description" , stock.Description,
                "@IsActive" , stock.IsActive
            };
        }

        /// <summary>
        /// Lấy kho theo stockId
        /// </summary>
        /// <param name="stockId">The identifier.</param>
        /// <returns>StockEntity.</returns>
        public StockEntity GetStock(int stockId)
        {
            const string sql = @"uspGet_Stock_ByID";
            object[] parms = { "@StockID", stockId };
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        /// Lấy danh sách các kho
        /// </summary>
        /// <returns>List{StockEntity}.</returns>
        public List<StockEntity> GetStocks()
        {
            const string sql = @"uspGet_All_Stock";
            return Db.ReadList(sql, true, Make);

        }

        /// <summary>
        /// Inserts the stock.
        /// </summary>
        /// <param name="stock">The stock.</param>
        /// <returns></returns>
        public int InsertStock(StockEntity stock)
        {

            const string sql = @"uspInsert_Stock";
            return Db.Insert(sql, true, Take(stock));

        }

        /// <summary>
        /// Updates the stock.
        /// </summary>
        /// <param name="stock">The stock.</param>
        /// <returns></returns>
        public string UpdateStock(StockEntity stock)
        {

            const string sql = @"uspUpdate_Stock";
            return Db.Update(sql, true, Take(stock));

        }

        /// <summary>
        /// Deletes the stock.
        /// </summary>
        /// <param name="stockId">The stock identifier.</param>
        /// <returns></returns>
        public string DeleteStock(int stockId)
        {
            const string sql = @"uspDelete_Stock";
            object[] parms = { "@StockID", stockId };
            return Db.Delete(sql, true, parms);
        }

        /// <summary>
        ///  Lấy danh sách Kho được hoạt động.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>List{StockEntity}.</returns>
        public List<StockEntity> GetStocksByActive(bool isActive)
        {
            const string sql = @"uspGet_Stock_ByIsActive";
            object[] parms = { "@IsActive", isActive };
            return Db.ReadList(sql, true, Make, parms);
        }
        /// <summary>
        /// Lấy danh sách kho theo mã
        /// </summary>
        /// <param name="stockCode"></param>
        /// <returns></returns>

        public List<StockEntity> GetStocksByStockCode(string stockCode)
        {
            const string sql = @"uspGet_Stock_ByStockCode";
            object[] parms = { "@StockCode", stockCode };
            return Db.ReadList(sql, true, Make, parms);
        }
    }
}

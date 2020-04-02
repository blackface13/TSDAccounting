/***********************************************************************
 * <copyright file="SqlServerInventoryItemDao.cs" company="BUCA JSC">
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
    /// Class SqlServerInventoryItemDao.
    /// </summary>
    public class SqlServerInventoryItemDao : DaoBase, IInventoryItemDao
    {
        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, InventoryItemEntity> Make = reader =>
        new InventoryItemEntity
        {
            InventoryItemId = reader["InventoryItemID"].AsId(),
            InventoryItemCode = reader["InventoryItemCode"].AsString(),
            InventoryItemName = reader["InventoryItemName"].AsString(),
            AccountCode = reader["AccountCode"].AsString(),
            Unit = reader["Unit"].AsString(),
            CurrencyCode = reader["CurrencyCode"].AsString(),
            CostMethod = reader["CostMethod"].AsInt(),
            IsActive = reader["IsActive"].AsBool(),
            StockId = reader["StockID"].AsInt(),
            ExpenseAccountCode = reader["ExpenseAccountCode"].AsString(),
            InventoryItemType = reader["InventoryItemType"].AsIntForNull(),
            DepartmentId = reader["DepartmentID"].AsIntForNull(),
        };

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, InventoryItemEntity> MakeForListInventory = reader =>
        new InventoryItemEntity
        {
            InventoryItemId = reader["InventoryItemID"].AsId(),
            InventoryItemCode = reader["InventoryItemCode"].AsString(),
            InventoryItemName = reader["InventoryItemName"].AsString(),
            AccountCode = reader["AccountCode"].AsString(),
            Unit = reader["Unit"].AsString(),
            CurrencyCode = reader["CurrencyCode"].AsString(),
            CostMethod = reader["CostMethod"].AsInt(),
            IsActive = reader["IsActive"].AsBool(),
            StockId = reader["StockID"].AsInt(),
            StockCode = reader["StockCode"].AsString(),
            ExpenseAccountCode = reader["ExpenseAccountCode"].AsString(),
            InventoryItemType = reader["InventoryItemType"].AsIntForNull(),
        };


        /// <summary>
        /// Takes the specified inventory item.
        /// </summary>
        /// <param name="inventoryItem">The inventory item.</param>
        /// <returns>System.Object[][].</returns>
        private object[] Take(InventoryItemEntity inventoryItem)
        {
            return new object[]
            {
                "@InventoryItemID" , inventoryItem.InventoryItemId
                ,"@InventoryItemCode" , inventoryItem.InventoryItemCode
                ,"@InventoryItemName" , inventoryItem.InventoryItemName
                //,"@CostMethod" , inventoryItem.CostMethod
                ,"@Unit" , inventoryItem.Unit
                //,"@CurrencyCode" , inventoryItem.CurrencyCode
                //,"@AccountCode" , inventoryItem.AccountCode
                ,"@isActive" , inventoryItem.IsActive
                //,"@StockID",inventoryItem.StockId
                //,"@StockCode",inventoryItem.StockCode
                //,"@ExpenseAccountCode",inventoryItem.ExpenseAccountCode
                ,"@InventoryItemType",inventoryItem.InventoryItemType
                ,"@DepartmentID",inventoryItem.DepartmentId
            };
        }

        /// <summary>
        /// Lấy Kho theo Id
        /// </summary>
        /// <param name="inventoryItemId">The identifier.</param>
        /// <returns>InventoryItemEntity.</returns>
        public InventoryItemEntity GetInventoryItem(int inventoryItemId)
        {
            const string sql = @"uspGet_InventoryItem_ByID";
            object[] parms = { "@InventoryItemID", inventoryItemId };
            return Db.Read(sql, true, Make, parms);
        }

        /// <summary>
        /// Lấy danh sách các Vật tư
        /// </summary>
        /// <returns>List{InventoryItemEntity}.</returns>
        public List<InventoryItemEntity> GetInventoryItemList()
        {
            const string sql = @"uspGet_All_InventoryItem";
            return Db.ReadList(sql, true, MakeForListInventory);
        }
        /// <summary>
        /// Gets the inventory item list by stock.
        /// BangNC
        /// </summary>
        /// <param name="itemStock">The item stock.</param>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="postDate">The post date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns>List&lt;InventoryItemEntity&gt;.</returns>
        public List<InventoryItemEntity> GetInventoryItemListByStock(int itemStock, long refId, DateTime postDate, string currencyCode)
        {
            const string sql = @"uspGet_All_InventoryItemByStockID";
            object[] parms = { "@StockID", itemStock, "@RefID", refId, "@PostDate", postDate, "@Currency", currencyCode };
            return Db.ReadList(sql, true, Make, parms);
        }
        /// <summary>
        /// Inserts the inventory item.
        /// </summary>
        /// <param name="inventoryItem">The inventory item.</param>
        /// <returns>System.Int32.</returns>
        public int InsertInventoryItem(InventoryItemEntity inventoryItem)
        {
            const string sql = @"uspInsert_InventoryItem";
            return Db.Insert(sql, true, Take(inventoryItem));
        }

        /// <summary>
        /// Updates the inventory item.
        /// </summary>
        /// <param name="inventoryItem">The inventory item.</param>
        /// <returns>System.String.</returns>
        public string UpdateInventoryItem(InventoryItemEntity inventoryItem)
        {

            const string sql = @"uspUpdate_InventoryItem";
            return Db.Update(sql, true, Take(inventoryItem));

        }

        /// <summary>
        /// Xóa vật tư theo Id
        /// </summary>
        /// <param name="inventoryItemId">The inventory item identifier.</param>
        /// <returns>System.String.</returns>
        public string DeleteInventoryItem(int inventoryItemId)
        {

            const string sql = @"uspDelete_InventoryItem";
            object[] parms = { "@inventoryItemID", inventoryItemId };
            return Db.Delete(sql, true, parms);
        }

        /// <summary>
        /// Xóa vật tư theo mã
        /// </summary>
        /// <param name="inventoryItemCode">The inventory item code.</param>
        /// <returns>System.String.</returns>
        public string DeleteInventoryItemByCode(string inventoryItemCode)
        {
            const string sql = @"uspDelete_Inventory";
            object[] parms = { "@inventoryItemCode", inventoryItemCode };
            return Db.Delete(sql, true, parms);
        }

        /// <summary>
        /// Lấy danh sách Vật tư theo mã
        /// </summary>
        /// <param name="inventoryItemCode">The inventory item code.</param>
        /// <returns>List&lt;InventoryItemEntity&gt;.</returns>
        public List<InventoryItemEntity> GetInventoryItemByCode(string inventoryItemCode)
        {
            object[] parms = { "@InventoryItemCode", inventoryItemCode };
            const string sql = @"uspGet_InventoryItem_ByInventoryCode";
            return Db.ReadList(sql, true, Make, parms);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isStock"></param>
        /// <param name="isActive"></param>
        /// <param name="inventoryCategoryCode"></param>
        /// <returns></returns>
        public List<InventoryItemEntity> GetInventoryItemsByIsStockAndIsActiveAndCategoryCode(bool isStock, bool isActive, string inventoryCategoryCode)
        {
            const string sql = @"uspGet_InventoryItem_ByIsToolAndIsActiveAndInventoryCategoryCode";
            object[] parms = { "@IsStock", isStock, "@IsActive", isActive, "@InventoryCategoryCode", inventoryCategoryCode };
            return Db.ReadList(sql, true, Make<InventoryItemEntity>, parms);
        }

        /// <summary>
        /// Gets the inventory item list by stock.
        /// by BangNC
        /// </summary>
        /// <param name="itemStock">The item stock.</param>
        /// <returns>List&lt;InventoryItemEntity&gt;.</returns>
        public List<InventoryItemEntity> GetInventoryItemListByStock(int itemStock)
        {
            const string sql = @"uspGet_InventoryItemByStockID";
            object[] parms = { "@StockID", itemStock };
            return Db.ReadList(sql, true, Make, parms);
        }
    }
}

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

using System;
using System.Collections.Generic;
using TSD.AccountingSoft.BusinessEntities.Dictionary;


namespace TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary
{
    /// <summary>
    /// Interface IInventoryItemDao
    /// </summary>
    public interface IInventoryItemDao
    {
        /// <summary>
        /// Lấy kho theo Id
        /// </summary>
        /// <param name="stockId">The stock identifier.</param>
        /// <returns>InventoryItemEntity.</returns>
        InventoryItemEntity GetInventoryItem(int stockId);

        /// <summary>
        /// Lấy danh sách các vật tư
        /// </summary>
        /// <returns>List&lt;InventoryItemEntity&gt;.</returns>
        List<InventoryItemEntity> GetInventoryItemList();


        /// <summary>
        /// Gets the inventory item list by stock.
        /// by BangNC
        /// </summary>
        /// <param name="itemStock">The item stock.</param>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="postDate">The post date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns>List&lt;InventoryItemEntity&gt;.</returns>
        List<InventoryItemEntity> GetInventoryItemListByStock(int itemStock, long refId, DateTime postDate, string currencyCode);

        /// <summary>
        /// Gets the inventory item list by stock.
        /// by BangNC
        /// </summary>
        /// <param name="itemStock">The item stock.</param>
        /// <returns>List&lt;InventoryItemEntity&gt;.</returns>
        List<InventoryItemEntity> GetInventoryItemListByStock(int itemStock);
        /// <summary>
        /// Thêm dữ liệu vật tư theo đối tượng
        /// </summary>
        /// <param name="objInventoryItem">The object inventory item.</param>
        /// <returns>System.Int32.</returns>
        int InsertInventoryItem(InventoryItemEntity objInventoryItem);

        /// <summary>
        /// Cập nhật vật tư dữ liệu theo đối tượng
        /// </summary>
        /// <param name="objInventoryItem">The object inventory item.</param>
        /// <returns>System.String.</returns>
        string UpdateInventoryItem(InventoryItemEntity objInventoryItem);

        /// <summary>
        /// Xóa vật tư theo inventoryItemId
        /// </summary>
        /// <param name="inventoryItemId">The inventory item identifier.</param>
        /// <returns>System.String.</returns>
        string DeleteInventoryItem(int inventoryItemId);

        /// <summary>
        /// Xóa vật tư theo mã
        /// </summary>
        /// <param name="inventoryItemCode">The inventory item code.</param>
        /// <returns>System.String.</returns>
        string DeleteInventoryItemByCode(string inventoryItemCode);
        //GetInventoryItemByCode
        /// <summary>
        /// Lấy danh sách vật tư theo mã
        /// </summary>
        /// <param name="inventoryItemCode">The inventory item code.</param>
        /// <returns>List&lt;InventoryItemEntity&gt;.</returns>
        List<InventoryItemEntity> GetInventoryItemByCode(string inventoryItemCode);

        List<InventoryItemEntity> GetInventoryItemsByIsStockAndIsActiveAndCategoryCode(bool isStock, bool isActive, string inventoryCategoryCode);
    }
}

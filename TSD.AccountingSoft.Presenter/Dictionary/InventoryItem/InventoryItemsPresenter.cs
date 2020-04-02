/***********************************************************************
 * <copyright file="InventoryItemsPresenter.cs" company="BUCA JSC">
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
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.View.Dictionary;


namespace TSD.AccountingSoft.Presenter.Dictionary.InventoryItem
{
    /// <summary>
    /// Class InventoryItemsPresenter.
    /// </summary>
    public class InventoryItemsPresenter : Presenter<IInventoryItemsView>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryItemsPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public InventoryItemsPresenter(IInventoryItemsView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            View.InventoryItems = Model.GetInventoryItems();
        }
        public void DisplayByStock(int itemStockId, long refId, string postDate, string currencyCode)
        {
            var postDateCurrent = DateTime.Parse(postDate) + new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            View.InventoryItems = Model.GetInventoryItemsByStock(itemStockId, refId, postDateCurrent, currencyCode);
        }

        public void DisplayByStock(int itemStockId)
        {
            View.InventoryItems = Model.GetInventoryItemsByStock(itemStockId);
        }

        public IList<InventoryItemModel> GetInventoryItemsByStock(int itemStockId) 
        {
            return Model.GetInventoryItemsByStock(itemStockId);
        }

        public IList<InventoryItemModel> GetInventoryItemsByStock(int itemStockId, int refId, string postDate, string currencyCode) 
        {
            var postDateCurrent = DateTime.Parse(postDate) + new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            return Model.GetInventoryItemsByStock(itemStockId, refId, postDateCurrent, currencyCode);
        }

        /// <summary>
        /// Danh sách CCDC và hàng hóa qua kho, sử dụng, mã nhóm
        /// </summary>
        /// <param name="isTool"></param>
        /// <param name="isActive"></param>
        /// <param name="inventoryCategoryCod"></param>
        public void DisplayByIsStockAndIsActiveAndCategoryCode(bool isStock, bool isActive, string inventoryCategoryCode)
        {
            View.InventoryItems = Model.GetInventoryItemsByIsStockAndIsActiveAndCategoryCode(isStock, isActive, inventoryCategoryCode);
        }
    }
}
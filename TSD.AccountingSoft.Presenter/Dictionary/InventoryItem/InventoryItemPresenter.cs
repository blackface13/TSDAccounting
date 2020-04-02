/***********************************************************************
 * <copyright file="InventoryItemPresenter.cs" company="BUCA JSC">
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


namespace TSD.AccountingSoft.Presenter.Dictionary.InventoryItem
{
    /// <summary>
    /// Class InventoryItemPresenter.
    /// </summary>
    public class InventoryItemPresenter : Presenter<IInventoryItemView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryItemPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public InventoryItemPresenter(IInventoryItemView view) : base(view)
        {

        }

        /// <summary>
        /// Displays the specified inventory item identifier.
        /// </summary>
        /// <param name="inventoryItemId">The inventory item identifier.</param>
        public void Display(string inventoryItemId)
        {
            if (inventoryItemId == null) { View.InventoryItemId = 0; return; }
            var inventoryItem = Model.GetInventoryItem(int.Parse(inventoryItemId));
            View.InventoryItemId = inventoryItem.InventoryItemId;
            //View.CurrencyCode = inventoryItem.CurrencyCode;
            View.CostMethod = inventoryItem.CostMethod;
            //View.AccountCode = inventoryItem.AccountCode;
            View.InventoryItemCode = inventoryItem.InventoryItemCode;
            View.InventoryItemName = inventoryItem.InventoryItemName;
            View.IsActive = inventoryItem.IsActive;
            View.Unit = inventoryItem.Unit;
            //View.StockId = inventoryItem.StockId;
            //View.ExpenseAccountCode = inventoryItem.ExpenseAccountCode;
            //View.InventoryItemType = inventoryItem.InventoryItemType;
            View.DepartmentId = inventoryItem.DepartmentId;
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int Save()
        {
            var obj = new InventoryItemModel
            {

                //CurrencyCode = View.CurrencyCode,
                InventoryItemCode = View.InventoryItemCode,
                InventoryItemId = View.InventoryItemId,
                InventoryItemName = View.InventoryItemName,
                //AccountCode = View.AccountCode,
                //CostMethod = View.CostMethod,
                IsActive = View.IsActive,
                Unit = View.Unit,
                //StockId = View.StockId,
                //ExpenseAccountCode = View.ExpenseAccountCode,
                InventoryItemType = View.InventoryItemType,
                DepartmentId = View.DepartmentId
            };
            return View.InventoryItemId == 0 ? Model.InsertInventoryItem(obj) : Model.UpdateInventoryItem(obj);
        }

        /// <summary>
        /// Deletes the specified inventory item identifier.
        /// </summary>
        /// <param name="inventoryItemId">The inventory item identifier.</param>
        /// <returns>System.Int32.</returns>
        public int Delete(int inventoryItemId)
        {
            return Model.Delete(inventoryItemId);
        }
    }
}

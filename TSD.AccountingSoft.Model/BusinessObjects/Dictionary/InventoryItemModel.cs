/***********************************************************************
 * <copyright file="InventoryItemModel.cs" company="BUCA JSC">
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

namespace TSD.AccountingSoft.Model.BusinessObjects.Dictionary
{
    /// <summary>
    /// Class InventoryItemModel.
    /// </summary>
    public class InventoryItemModel
    {

        /// <summary>
        /// Gets or sets the InventoryItemId identifier.
        /// </summary>
        /// <value>The InventoryItemId.</value>
        public int InventoryItemId { get; set; }

        /// <summary>
        /// Gets or sets the inventory item code.
        /// </summary>
        /// <value>The inventory item code.</value>
        public string InventoryItemCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the inventory item.
        /// </summary>
        /// <value>The InventoryItem Name .</value>
        public string InventoryItemName { get; set; }

        /// <summary>
        /// Gets or sets the account code.
        /// </summary>
        /// <value>The account code.</value>
        public string AccountCode { get; set; }

        /// <summary>
        /// Gets or sets the unit.
        /// </summary>
        /// <value>The unit.</value>
        public string Unit { get; set; }

        /// <summary>
        /// Gets or sets the cost method.
        /// </summary>
        /// <value>The cost method.</value>
        public int CostMethod { get; set; }

        /// <summary>
        /// Gets or sets the currency identifier.
        /// </summary>
        /// <value>The currency identifier.</value>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Id kho
        /// </summary>
        public int StockId { get; set; }

        /// <summary>
        /// Mã kho
        /// </summary>
        public string StockCode { get; set; }

        /// <summary>
        /// Tài khoản chi phí cho xuất kho
        /// </summary>
        public string ExpenseAccountCode { get; set; }

        public int? InventoryItemType { get; set; }

        /// <summary>
        /// Gets or sets the department identifier.
        /// </summary>
        /// <value>The department identifier.</value>
        public int? DepartmentId { get; set; }
    }
}

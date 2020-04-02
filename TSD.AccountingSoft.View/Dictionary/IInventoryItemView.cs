/***********************************************************************
 * <copyright file="IInventoryItemView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: Thursday, March 13, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

namespace TSD.AccountingSoft.View.Dictionary
{
    /// <summary>
    /// Interface IInventoryItemView
    /// </summary>
    public interface IInventoryItemView : IView
    {
        /// <summary>
        /// Gets or sets the inventory item identifier.
        /// </summary>
        /// <value>The inventory item identifier.</value>
        int InventoryItemId { get; set; }

        /// <summary>
        /// Gets or sets the inventory item code.
        /// </summary>
        /// <value>The inventory item code.</value>
        string InventoryItemCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the inventory item.
        /// </summary>
        /// <value>The name of the inventory item.</value>
        string InventoryItemName { get; set; }

        /// <summary>
        /// Gets or sets the account code.
        /// </summary>
        /// <value>The account code.</value>
        string AccountCode { get; set; }

        /// <summary>
        /// Gets or sets the unit.
        /// </summary>
        /// <value>The unit.</value>
        string Unit { get; set; }

        /// <summary>
        /// Gets or sets the currency identifier.
        /// </summary>
        /// <value>The currency identifier.</value>
        string CurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets the cost method.
        /// </summary>
        /// <value>The cost method.</value>
        int CostMethod { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is Stock Id.
        /// </summary>
        /// <value>The Stock Id identifier.</value>
        /// 
        int StockId { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is Expense Account Code.
        /// </summary>
        /// <value>The Expense Account Code identifier.</value>
        string ExpenseAccountCode { get; set; }

        int? InventoryItemType { get; set; }
        int? DepartmentId { get; set; }
    }
}

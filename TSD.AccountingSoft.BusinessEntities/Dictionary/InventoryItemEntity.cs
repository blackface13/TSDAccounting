/***********************************************************************
 * <copyright file="InventoryItemEntity.cs" company="BUCA JSC">
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

using TSD.AccountingSoft.BusinessEntities.BusinessRules;


namespace TSD.AccountingSoft.BusinessEntities.Dictionary
{
    /// <summary>
    /// Class InventoryItemEntity.
    /// </summary>
    public class InventoryItemEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryItemEntity" /> class.
        /// </summary>
        public InventoryItemEntity()
        {
            AddRule(new ValidateId("InventoryItemId"));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryItemEntity"/> class.
        /// </summary>
        /// <param name="inventoryItemId">The inventory item identifier.</param>
        /// <param name="inventoryItemCode">The inventory item code.</param>
        /// <param name="inventoryItemName">Name of the inventory item.</param>
        /// <param name="costMethod">The cost method.</param>
        /// <param name="accountCode">The account code.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="unit">The unit.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <param name="stockId">The stock identifier.</param>
        /// <param name="stockCode">The stock code.</param>
        /// <param name="expenseAccountCode">The expense Account Code.</param>
        public InventoryItemEntity(int inventoryItemId, string inventoryItemCode, string inventoryItemName, int costMethod, string accountCode, string currencyCode, string unit, bool isActive, int stockId, string stockCode, string expenseAccountCode, int? inventoryItemType)
            : this()
        {
            InventoryItemId = inventoryItemId;
            InventoryItemCode = inventoryItemCode;
            InventoryItemName = inventoryItemName;
            AccountCode = accountCode;
            Unit = unit;
            CurrencyCode = currencyCode;
            CostMethod = costMethod;
            IsActive = isActive;
            StockId = stockId;
            StockCode = stockCode;
            ExpenseAccountCode = expenseAccountCode;
            this.InventoryItemType = inventoryItemType;
        }

        /// <summary>
        /// Gets or sets the inventory item identifier.
        /// </summary>
        /// <value>The inventory item identifier.</value>
        public int InventoryItemId { get; set; }

        /// <summary>
        /// Gets or sets the inventory item code.
        /// </summary>
        /// <value>The inventory item code.</value>
        public string InventoryItemCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the inventory item.
        /// </summary>
        /// <value>The name of the inventory item.</value>
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
        /// Gets or sets the currency identifier.
        /// </summary>
        /// <value>The currency identifier.</value>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets the cost method.
        /// </summary>
        /// <value>The cost method.</value>
        public int CostMethod { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the stock identifier.
        /// </summary>
        /// <value>The stock identifier.</value>
        public int StockId { get; set; }

        /// <summary>
        /// Gets or sets the stock code.
        /// </summary>
        /// <value>The stock code.</value>
        public string StockCode { get; set; }

        /// <summary>
        /// Gets or sets the Expense Account Code.
        /// </summary>
        /// <value>The Expense Account Code.</value>
        public string ExpenseAccountCode { get; set; }

        public int? InventoryItemType { get; set; }
        public int? DepartmentId { get; set; }
    }
}

/***********************************************************************
 * <copyright file="ItemTransactionDetailEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuanMH
 * Email:    TuanMH@buca.vn
 * Website:
 * Create Date: 11 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using TSD.AccountingSoft.BusinessEntities.BusinessRules;


namespace TSD.AccountingSoft.BusinessEntities.Business.Inventory
{
    /// <summary>
    /// ItemTransactionDetailEntity
    /// </summary>
    public class ItemTransactionDetailEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ItemTransactionDetailEntity"/> class.
        /// </summary>
        public ItemTransactionDetailEntity()
        {
            AddRule(new ValidateId("RefDetailId"));
        }

      
        public ItemTransactionDetailEntity(long refDetailId, int inventoryItemId, string accountNumber, string correspondingAccountNumber, string description, decimal amountOc, decimal amountExchange, int voucherTypeId, string budgetSourceCode, string budgetItemCode, int? accountingObjectId, int? mergerFundId, long refId, int quantity, decimal price, decimal priceExchange,int cancelQuantity,int totalQuantity,int freeQuantity)
        {
            RefDetailId = refDetailId;
            InventoryItemId = inventoryItemId;
            AccountNumber = accountNumber;
            CorrespondingAccountNumber = correspondingAccountNumber;
            Description = description;
            AmountOc = amountOc;
            AmountExchange = amountExchange;
            VoucherTypeId = voucherTypeId;
            BudgetSourceCode = budgetSourceCode;
            BudgetItemCode = budgetItemCode;
            AccountingObjectId = accountingObjectId;
            MergerFundId = mergerFundId;
            RefId = refId;
            Quantity = quantity;
            Price = price;
            PriceExchange = priceExchange;
            CancelQuantity = cancelQuantity;
            TotalQuantity=totalQuantity;
            FreeQuantity = freeQuantity;
        }

        /// <summary>
        /// Gets or sets the cash detail identifier.
        /// </summary>
        /// <value>
        /// The cash detail identifier.
        /// </value>
        public long RefDetailId { get; set; }

        /// <summary>
        /// Gets or sets the cash detail identifier.
        /// </summary>
        /// <value>
        /// The cash detail identifier.
        /// </value>
        public int InventoryItemId { get; set; }

        /// <summary>
        /// Gets or sets the account number.
        /// </summary>
        /// <value>
        /// The account number.
        /// </value>
        public string AccountNumber { get; set; }

        /// <summary>
        /// Gets or sets the corresponding account number.
        /// </summary>
        /// <value>
        /// The corresponding account number.
        /// </value>
        public string CorrespondingAccountNumber { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the amount oc.
        /// </summary>
        /// <value>
        /// The amount oc.
        /// </value>
        public decimal AmountOc { get; set; }

        /// <summary>
        /// Gets or sets the amount exchange.
        /// </summary>
        /// <value>
        /// The amount exchange.
        /// </value>
        public decimal AmountExchange { get; set; }

        /// <summary>
        /// Gets or sets the bussiness.
        /// </summary>
        /// <value>
        /// The bussiness.
        /// </value>
        public int? VoucherTypeId { get; set; }

        /// <summary>
        /// Gets or sets the budget source code.
        /// </summary>
        /// <value>
        /// The budget source code.
        /// </value>
        public string BudgetSourceCode { get; set; }

        /// <summary>
        /// Gets or sets the budget item code.
        /// </summary>
        /// <value>
        /// The budget item code.
        /// </value>
        public string BudgetItemCode { get; set; }

        /// <summary>
        /// Gets or sets the accounting object identifier.
        /// </summary>
        /// <value>
        /// The accounting object identifier.
        /// </value>
        public int? AccountingObjectId { get; set; }

        /// <summary>
        /// Gets or sets the merger fund identifier.
        /// </summary>
        /// <value>
        /// The merger fund identifier.
        /// </value>
        public int? MergerFundId { get; set; }

        /// <summary>
        /// Gets or sets the project identifier.
        /// </summary>
        /// <value>
        /// The project identifier.
        /// </value>
        public int? ProjectId { get; set; }

        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>
        /// The reference identifier.
        /// </value>
        public long RefId { get; set; }

        /// <summary>
        /// Gets or sets the cash detail identifier.
        /// </summary>
        /// <value>
        /// The cash detail identifier.
        /// </value>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the cash detail identifier.
        /// </summary>
        /// <value>
        /// The cash detail identifier.
        /// </value>
        public decimal Price { get; set; }

        public decimal PriceExchange { get; set; }

        public decimal ExchangeRate { get; set; }

        public int FreeQuantity { get; set; }
        public int CancelQuantity { get; set; }
        public int TotalQuantity { get; set; }
        public int? DepartmentId { get; set; }
    }
}

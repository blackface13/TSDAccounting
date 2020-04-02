/***********************************************************************
 * <copyright file="FixedAssetEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Wednesday, February 26, 2014
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
    /// Class BudgetItemEntity.
    /// </summary>
    public class BudgetItemEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BudgetItemEntity"/> class.
        /// </summary>
        public BudgetItemEntity()
        {
            AddRule(new ValidateRequired("BudgetItemCode"));
            AddRule(new ValidateRequired("BudgetItemName"));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BudgetItemEntity" /> class.
        /// </summary>
        /// <param name="budgetItemId">The budget item identifier.</param>
        /// <param name="budgetGroupId">The budget group identifier.</param>
        /// <param name="budgetItemCode">The budget itemcode.</param>
        /// <param name="budgetItemName">The budget itemname.</param>
        /// <param name="foreignName">Name of the foreign.</param>
        /// <param name="parentId">The parent identifier.</param>
        /// <param name="grade">The grade.</param>
        /// <param name="isParent">if set to <c>true</c> [is detail].</param>
        /// <param name="isFixedItem">if set to <c>true</c> [is fixed item].</param>
        /// <param name="isExpandItem">if set to <c>true</c> [is expand item].</param>
        /// <param name="isNoAllocate">if set to <c>true</c> [is no allocate].</param>
        /// <param name="isOrganItem">if set to <c>true</c> [is organ item].</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <param name="isSystem">if set to <c>true</c> [is system].</param>
        /// <param name="isReceipt">if set to <c>true</c> [is receipt].</param>
        /// <param name="budgetItemType">Type of the budget item.</param>
        /// <param name="rate">The rate.</param>
        /// <param name="numberOrder">The number order.</param>
        public BudgetItemEntity(int budgetItemId, int? budgetGroupId, string budgetItemCode, string budgetItemName,
            string foreignName, int? parentId, short grade, bool isParent, bool isFixedItem, bool isExpandItem, 
            bool isNoAllocate, bool isOrganItem, bool isActive, bool isSystem, bool isReceipt, int budgetItemType, decimal rate, string numberOrder)
            : this()
        {
            BudgetItemId = budgetItemId;
            BudgetGroupId = budgetGroupId;
            BudgetItemCode = budgetItemCode;
            BudgetItemName = budgetItemName;
            ForeignName = foreignName;
            ParentId = parentId;
            Grade = grade;
            IsParent = isParent;
            IsFixedItem = isFixedItem;
            IsExpandItem = isExpandItem;
            IsNoAllocate = isNoAllocate;
            IsOrganItem = isOrganItem;
            IsActive = isActive;
            IsSystem = isSystem;
            IsReceipt = isReceipt;
            BudgetItemType = budgetItemType;
            Rate = rate;
            NumberOrder = numberOrder;
        }

        /// <summary>
        /// Gets or sets the budget item identifier.
        /// </summary>
        /// <value>The budget item identifier.</value>
        public int BudgetItemId { get; set; }

        /// <summary>
        /// Gets or sets the budget group identifier.
        /// </summary>
        /// <value>The budget group identifier.</value>
        public int? BudgetGroupId { get; set; }

        /// <summary>
        /// Gets or sets the budget item code.
        /// </summary>
        /// <value>The budget item code.</value>
        public string BudgetItemCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the budget item.
        /// </summary>
        /// <value>The name of the budget item.</value>
        public string BudgetItemName { get; set; }

        /// <summary>
        /// Gets or sets the name of the foreign.
        /// </summary>
        /// <value>The name of the foreign.</value>
        public string ForeignName { get; set; }

        /// <summary>
        /// Gets or sets the parent identifier.
        /// </summary>
        /// <value>The parent identifier.</value>
        public int? ParentId { get; set; }

        /// <summary>
        /// Gets or sets the grade.
        /// </summary>
        /// <value>The grade.</value>
        public int Grade { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is detail.
        /// </summary>
        /// <value><c>true</c> if this instance is detail; otherwise, <c>false</c>.</value>
        public bool IsParent { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is fixed item.
        /// </summary>
        /// <value><c>true</c> if this instance is fixed item; otherwise, <c>false</c>.</value>
        public bool IsFixedItem { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is expand item.
        /// </summary>
        /// <value><c>true</c> if this instance is expand item; otherwise, <c>false</c>.</value>
        public bool IsExpandItem { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is no allocate.
        /// </summary>
        /// <value><c>true</c> if this instance is no allocate; otherwise, <c>false</c>.</value>
        public bool IsNoAllocate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is organ item.
        /// </summary>
        /// <value><c>true</c> if this instance is organ item; otherwise, <c>false</c>.</value>
        public bool IsOrganItem { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is system.
        /// </summary>
        /// <value><c>true</c> if this instance is system; otherwise, <c>false</c>.</value>
        public bool IsSystem { get; set; }

        /// <summary>
        /// Gets or sets the type of the budget item.
        /// </summary>
        /// <value>The type of the budget item.</value>
        public int BudgetItemType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is receipt.
        /// </summary>
        /// <value><c>true</c> if this instance is receipt; otherwise, <c>false</c>.</value>
        public bool IsReceipt { get; set; }

        /// <summary>
        /// Gets or sets the rate.
        /// </summary>
        /// <value>
        /// The rate.
        /// </value>
        public decimal Rate { get; set; }

        /// <summary>
        /// Gets or sets the number order.
        /// </summary>
        /// <value>
        /// The number order.
        /// </value>
        public string NumberOrder { get; set; }

        public bool IsShowOnVoucher { get; set; }
    }
}

/***********************************************************************
 * <copyright file="PayItemEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 07 March 2014
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
    /// PayItemEntity
    /// </summary>
    public class PayItemEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PayItemEntity"/> class.
        /// </summary>
        public PayItemEntity()
        {
            AddRule(new ValidateRequired("PayItemCode"));
            AddRule(new ValidateRequired("PayItemName"));
            AddRule(new ValidateRequired("Type"));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PayItemEntity"/> class.
        /// </summary>
        /// <param name="payItemId">The pay item identifier.</param>
        /// <param name="payItemCode">The pay item code.</param>
        /// <param name="payItemName">Name of the pay item.</param>
        /// <param name="type">The type.</param>
        /// <param name="isCalculateRatio">if set to <c>true</c> [is calculate ratio].</param>
        /// <param name="isSocialInsurance">if set to <c>true</c> [is social insurance].</param>
        /// <param name="isCareInsurance">if set to <c>true</c> [is care insurance].</param>
        /// <param name="isTradeUnionFee">if set to <c>true</c> [is trade union fee].</param>
        /// <param name="description">The description.</param>
        /// <param name="debitAccountCode">The debit account code.</param>
        /// <param name="creaditAccountCode">The creadit account code.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="isDefault">if set to <c>true</c> [is default].</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <param name="budgetSourceCode">The budget source code.</param>
        /// <param name="budgetCategoryCode">The budget category code.</param>
        /// <param name="budgetGroupCode">The budget group code.</param>
        /// <param name="budgetItemCode">The budget item code.</param>
        public PayItemEntity(int payItemId, string payItemCode, string payItemName, int type, bool isCalculateRatio, bool isSocialInsurance, bool isCareInsurance, 
            bool isTradeUnionFee, string description, string debitAccountCode, string creaditAccountCode, string budgetChapterCode, bool isDefault, bool isActive, string budgetSourceCode, 
            string budgetCategoryCode, string budgetGroupCode, string budgetItemCode)
            : this()
        {
            PayItemId = payItemId;
            PayItemCode = payItemCode;
            PayItemName = payItemName;
            Type = type;
            IsCalculateRatio = isCalculateRatio;
            IsSocialInsurance = isSocialInsurance;
            IsCareInsurance = isCareInsurance;
            IsTradeUnionFee = isTradeUnionFee;
            Description = description;
            DebitAccountCode = debitAccountCode;
            CreditAccountCode = creaditAccountCode;
            BudgetChapterCode = budgetChapterCode;
            IsDefault = isDefault;
            IsActive = isActive;
            BudgetSourceCode = budgetSourceCode;
            BudgetCategoryCode = budgetCategoryCode;
            BudgetGroupCode = budgetGroupCode;
            BudgetItemCode = budgetItemCode;
        }

        /// <summary>
        /// Gets or sets the pay item identifier.
        /// </summary>
        /// <value>
        /// The pay item identifier.
        /// </value>
        public int PayItemId { get; set; }

        /// <summary>
        /// Gets or sets the pay item code.
        /// </summary>
        /// <value>
        /// The pay item code.
        /// </value>
        public string PayItemCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the pay item.
        /// </summary>
        /// <value>
        /// The name of the pay item.
        /// </value>
        public string PayItemName { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public int Type { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is calculate ratio].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is calculate ratio]; otherwise, <c>false</c>.
        /// </value>
        public bool IsCalculateRatio { get; set; }

        /// <summary>
        /// Gets or sets the is social insurance.
        /// </summary>
        /// <value>
        /// The is social insurance.
        /// </value>
        public bool? IsSocialInsurance { get; set; }

        /// <summary>
        /// Gets or sets the is care insurance.
        /// </summary>
        /// <value>
        /// The is care insurance.
        /// </value>
        public bool? IsCareInsurance { get; set; }

        /// <summary>
        /// Gets or sets the is trade union fee.
        /// </summary>
        /// <value>
        /// The is trade union fee.
        /// </value>
        public bool? IsTradeUnionFee { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the debit account code.
        /// </summary>
        /// <value>
        /// The debit account code.
        /// </value>
        public string DebitAccountCode { get; set; }

        /// <summary>
        /// Gets or sets the credit account code.
        /// </summary>
        /// <value>
        /// The credit account code.
        /// </value>
        public string CreditAccountCode { get; set; }

        /// <summary>
        /// Gets or sets the budget chapter code.
        /// </summary>
        /// <value>
        /// The budget chapter code.
        /// </value>
        public string BudgetChapterCode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is default].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is default]; otherwise, <c>false</c>.
        /// </value>
        public bool IsDefault { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is active].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is active]; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the budget source code.
        /// </summary>
        /// <value>
        /// The budget source code.
        /// </value>
        public string BudgetSourceCode { get; set; }

        /// <summary>
        /// Gets or sets the budget category code.
        /// </summary>
        /// <value>
        /// The budget category code.
        /// </value>
        public string BudgetCategoryCode { get; set; }

        /// <summary>
        /// Gets or sets the budget group code.
        /// </summary>
        /// <value>
        /// The budget group code.
        /// </value>
        public string BudgetGroupCode { get; set; }

        /// <summary>
        /// Gets or sets the budget item code.
        /// </summary>
        /// <value>
        /// The budget item code.
        /// </value>
        public string BudgetItemCode { get; set; }
    }
}
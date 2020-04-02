/***********************************************************************
 * <copyright file="PayItemModel.cs" company="BUCA JSC">
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

namespace TSD.AccountingSoft.Model.BusinessObjects.Dictionary
{
    /// <summary>
    /// PayItemModel
    /// </summary>
    public class PayItemModel
    {
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

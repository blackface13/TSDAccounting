/***********************************************************************
 * <copyright file="IPayItemView.cs" company="BUCA JSC">
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

namespace TSD.AccountingSoft.View.Dictionary
{
    /// <summary>
    /// IPayItemView
    /// </summary>
    public interface IPayItemView : IView
    {
        /// <summary>
        /// Gets or sets the pay item identifier.
        /// </summary>
        /// <value>
        /// The pay item identifier.
        /// </value>
        int PayItemId { get; set; }

        /// <summary>
        /// Gets or sets the pay item code.
        /// </summary>
        /// <value>
        /// The pay item code.
        /// </value>
        string PayItemCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the pay item.
        /// </summary>
        /// <value>
        /// The name of the pay item.
        /// </value>
        string PayItemName { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        int Type { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is calculate ratio].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is calculate ratio]; otherwise, <c>false</c>.
        /// </value>
        bool IsCalculateRatio { get; set; }

        /// <summary>
        /// Gets or sets the is social insurance.
        /// </summary>
        /// <value>
        /// The is social insurance.
        /// </value>
        bool? IsSocialInsurance { get; set; }

        /// <summary>
        /// Gets or sets the is care insurance.
        /// </summary>
        /// <value>
        /// The is care insurance.
        /// </value>
        bool? IsCareInsurance { get; set; }

        /// <summary>
        /// Gets or sets the is trade union fee.
        /// </summary>
        /// <value>
        /// The is trade union fee.
        /// </value>
        bool? IsTradeUnionFee { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        string Description { get; set; }

        /// <summary>
        /// Gets or sets the debit account code.
        /// </summary>
        /// <value>
        /// The debit account code.
        /// </value>
        string DebitAccountCode { get; set; }

        /// <summary>
        /// Gets or sets the credit account code.
        /// </summary>
        /// <value>
        /// The credit account code.
        /// </value>
        string CreditAccountCode { get; set; }

        /// <summary>
        /// Gets or sets the budget chapter code.
        /// </summary>
        /// <value>
        /// The budget chapter code.
        /// </value>
        string BudgetChapterCode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is default].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is default]; otherwise, <c>false</c>.
        /// </value>
        bool IsDefault { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is active].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is active]; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the budget source code.
        /// </summary>
        /// <value>
        /// The budget source code.
        /// </value>
        string BudgetSourceCode { get; set; }

        /// <summary>
        /// Gets or sets the budget category code.
        /// </summary>
        /// <value>
        /// The budget category code.
        /// </value>
        string BudgetCategoryCode { get; set; }

        /// <summary>
        /// Gets or sets the budget group code.
        /// </summary>
        /// <value>
        /// The budget group code.
        /// </value>
        string BudgetGroupCode { get; set; }

        /// <summary>
        /// Gets or sets the budget item code.
        /// </summary>
        /// <value>
        /// The budget item code.
        /// </value>
        string BudgetItemCode { get; set; }
    }
}

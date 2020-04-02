/***********************************************************************
 * <copyright file="AccountModel.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   BangNC
 * Email:    BangNC@buca.vn
 * Website:
 * Create Date: Thursday, March 13, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

namespace TSD.AccountingSoft.Model.BusinessObjects.Dictionary
{
    /// <summary>
    /// Class AccountModel.
    /// </summary>
    public class AccountModel
    {
        /// <summary>
        /// Gets or sets the account identifier.
        /// </summary>
        /// <value>The account identifier.</value>
        public int AccountId { get; set; }

        /// <summary>
        /// Gets or sets the account category identifier.
        /// </summary>
        /// <value>The account category identifier.</value>
        public int? AccountCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the account code.
        /// </summary>
        /// <value>The account code.</value>
        public string AccountCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the account.
        /// </summary>
        /// <value>The name of the account.</value>
        public string AccountName { get; set; }

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
        public bool IsDetail { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the balanceside.
        /// </summary>
        /// <value>The balanceside.</value>
        public int BalanceSide { get; set; }

        /// <summary>
        /// Gets or sets the currency code.
        /// </summary>
        /// <value>
        /// The currency code.
        /// </value>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets the concomitant account.
        /// </summary>
        /// <value>The concomitant account.</value>
        public string ConcomitantAccount { get; set; }

        /// <summary>
        /// Gets or sets the bank identifier.
        /// </summary>
        /// <value>The bank identifier.</value>
        public int? BankId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is chapter.
        /// </summary>
        /// <value><c>true</c> if this instance is chapter; otherwise, <c>false</c>.</value>
        public bool IsChapter { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is budget category.
        /// </summary>
        /// <value><c>true</c> if this instance is budget category; otherwise, <c>false</c>.</value>
        public bool IsBudgetCategory { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is budget item.
        /// </summary>
        /// <value><c>true</c> if this instance is budget item; otherwise, <c>false</c>.</value>
        public bool IsBudgetItem { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is budget group.
        /// </summary>
        /// <value><c>true</c> if this instance is budget group; otherwise, <c>false</c>.</value>
        public bool IsBudgetGroup { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is budget source.
        /// </summary>
        /// <value><c>true</c> if this instance is budget source; otherwise, <c>false</c>.</value>
        public bool IsBudgetSource { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is activity.
        /// </summary>
        /// <value><c>true</c> if this instance is activity; otherwise, <c>false</c>.</value>
        public bool IsActivity { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is currency.
        /// </summary>
        /// <value><c>true</c> if this instance is currency; otherwise, <c>false</c>.</value>
        public bool IsCurrency { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is customer.
        /// </summary>
        /// <value><c>true</c> if this instance is customer; otherwise, <c>false</c>.</value>
        public bool IsCustomer { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is vendor.
        /// </summary>
        /// <value><c>true</c> if this instance is vendor; otherwise, <c>false</c>.</value>
        public bool IsVendor { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is employee.
        /// </summary>
        /// <value><c>true</c> if this instance is employee; otherwise, <c>false</c>.</value>
        public bool IsEmployee { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is accounting object.
        /// </summary>
        /// <value><c>true</c> if this instance is accounting object; otherwise, <c>false</c>.</value>
        public bool IsAccountingObject { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is inventory item.
        /// </summary>
        /// <value><c>true</c> if this instance is inventory item; otherwise, <c>false</c>.</value>
        public bool IsInventoryItem { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is fixedasset.
        /// </summary>
        /// <value><c>true</c> if this instance is fixedasset; otherwise, <c>false</c>.</value>
        public bool IsFixedAsset { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is capital allocate.
        /// </summary>
        /// <value><c>true</c> if this instance is capital allocate; otherwise, <c>false</c>.</value>
        public bool IsCapitalAllocate { get; set; }

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
        /// Gets or sets a value indicating whether [is allowinputcts].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is allowinputcts]; otherwise, <c>false</c>.
        /// </value>
        public bool IsAllowinputcts { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is project].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is project]; otherwise, <c>false</c>.
        /// </value>
        public bool IsProject { get; set; }

        public bool IsBudgetSubItem { get; set; }
        public bool IsBank { get; set; }
    }
}

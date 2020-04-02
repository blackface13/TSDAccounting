/***********************************************************************
 * <copyright file="AccountEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   BangNC
 * Email:    BangNC@buca.vn
 * Website:
 * Create Date: Friday, March 14, 2014
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
    /// class AccountEntity
    /// </summary>
    public class AccountEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountEntity"/> class.
        /// </summary>
        public AccountEntity()
        {
            AddRule(new ValidateRequired("AccountCode"));
            AddRule(new ValidateRequired("AccountName"));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountEntity"/> class.
        /// </summary>
        /// <param name="accountId">The account identifier.</param>
        /// <param name="accountCategoryId">The account category identifier.</param>
        /// <param name="accountCode">The account code.</param>
        /// <param name="accountName">Name of the account.</param>
        /// <param name="foreignName">Name of the foreign.</param>
        /// <param name="parentId">The parent identifier.</param>
        /// <param name="grade">The grade.</param>
        /// <param name="detail">if set to <c>true</c> [detail].</param>
        /// <param name="description">The description.</param>
        /// <param name="balanceSide">The balance side.</param>
        /// <param name="concomitantAccount">The concomitant account.</param>
        /// <param name="bankId">The bank identifier.</param>
        /// <param name="isChapter">if set to <c>true</c> [is chapter].</param>
        /// <param name="isBudgetCategory">if set to <c>true</c> [is budget category].</param>
        /// <param name="isBudgetItem">if set to <c>true</c> [is budget item].</param>
        /// <param name="isBudgetGroup">if set to <c>true</c> [is budget group].</param>
        /// <param name="isBudgetSource">if set to <c>true</c> [is budget source].</param>
        /// <param name="isActivity">if set to <c>true</c> [is activity].</param>
        /// <param name="isCurrency">if set to <c>true</c> [is currency].</param>
        /// <param name="isCustomer">if set to <c>true</c> [is customer].</param>
        /// <param name="isVendor">if set to <c>true</c> [is vendor].</param>
        /// <param name="isEmployee">if set to <c>true</c> [is employee].</param>
        /// <param name="isAccountingObject">if set to <c>true</c> [is accounting object].</param>
        /// <param name="isInventoryItem">if set to <c>true</c> [is inventory item].</param>
        /// <param name="isFixedAsset">if set to <c>true</c> [is fixed asset].</param>
        /// <param name="isCapitalAllocate">if set to <c>true</c> [is capital allocate].</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <param name="isSystem">if set to <c>true</c> [is system].</param>
        /// <param name="isProject">if set to <c>true</c> [is project].</param>
        /// <param name="isAllowinputcts">if set to <c>true</c> [is allowinputcts].</param>
        public AccountEntity(int accountId, int? accountCategoryId, string accountCode, string accountName, string foreignName, int? parentId, int grade, bool detail, 
            string description, int balanceSide, string concomitantAccount, int? bankId, bool isChapter, bool isBudgetCategory, bool isBudgetItem, bool isBudgetGroup, 
            bool isBudgetSource, bool isActivity, bool isCurrency, bool isCustomer, bool isVendor, bool isEmployee, bool isAccountingObject, bool isInventoryItem,
            bool isFixedAsset, bool isCapitalAllocate, bool isActive, bool isSystem, bool isProject, bool isAllowinputcts)
            : this()
        {
            AccountId = accountId;
            AccountCategoryId = accountCategoryId;
            AccountCode = accountCode;
            AccountName = accountName;
            ForeignName = foreignName;
            ParentId = parentId;
            Grade = grade;
            IsDetail = detail;
            Description = description;
            BalanceSide = balanceSide;
            ConcomitantAccount = concomitantAccount;
            BankId = bankId;
            IsChapter = isChapter;
            IsBudgetCategory = isBudgetCategory;
            IsBudgetItem = isBudgetItem;
            IsBudgetGroup = isBudgetGroup;
            IsBudgetSource = isBudgetSource;
            IsActivity = isActivity;
            IsCurrency = isCurrency;
            IsCustomer = isCustomer;
            IsVendor = isVendor;
            IsEmployee = isEmployee;
            IsAccountingObject = isAccountingObject;
            IsInventoryItem = isInventoryItem;
            IsFixedAsset = isFixedAsset;
            IsCapitalAllocate = isCapitalAllocate;
            IsActive = isActive;
            IsSystem = isSystem;
            IsProject = isProject;
            IsAllowinputcts = isAllowinputcts;
        }

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
        /// Gets or sets a value indicating whether [is allowinputcts].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is allowinputcts]; otherwise, <c>false</c>.
        /// </value>
        public bool IsAllowinputcts { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the currency code.
        /// </summary>
        /// <value>
        /// The currency code.
        /// </value>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets the balanceside.
        /// </summary>
        /// <value>The balanceside.</value>
        public int BalanceSide { get; set; }

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

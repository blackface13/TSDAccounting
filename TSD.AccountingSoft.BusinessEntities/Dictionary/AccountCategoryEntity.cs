/***********************************************************************
 * <copyright file="AccountCategoryEntity.cs" company="BUCA JSC">
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
    /// class AccountCategoryEntity
    /// </summary>
    public class AccountCategoryEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountCategoryEntity"/> class.
        /// </summary>
        public AccountCategoryEntity()
        {
            AddRule(new ValidateRequired("AccountCategoryCode"));
            AddRule(new ValidateRequired("AccountCategoryName"));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountCategoryEntity"/> class.
        /// </summary>
        /// <param name="accountCategoryId">The account category identifier.</param>
        /// <param name="accountCategoryCode">The account category code.</param>
        /// <param name="accountCategoryName">Name of the account category.</param>
        /// <param name="foreignName">Name of the foreign.</param>
        /// <param name="parentId">The parent identifier.</param>
        /// <param name="grade">The grade.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        public AccountCategoryEntity(int accountCategoryId, string accountCategoryCode, string accountCategoryName, string foreignName, int parentId, int grade, bool isActive)
            : this()
        {
            AccountCategoryId = accountCategoryId;
            AccountCategoryName = accountCategoryName;
            AccountCategoryCode = accountCategoryCode;
            ForeignName = foreignName;
            ParentId = parentId;
            Grade = grade;
            IsDetail = IsDetail;
            IsActive = isActive;
        }

        /// <summary>
        /// Gets or sets the account category identifier.
        /// </summary>
        /// <value>The account category identifier.</value>
        public int AccountCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the account category code.
        /// </summary>
        /// <value>The account category code.</value>
        public string AccountCategoryCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the account category.
        /// </summary>
        /// <value>The name of the account category.</value>
        public string AccountCategoryName { get; set; }

        /// <summary>
        /// Gets or sets the name of the foreign.
        /// </summary>
        /// <value>The name of the foreign.</value>
        public string ForeignName { get; set; }

        /// <summary>
        /// Gets or sets the parent identifier.
        /// </summary>
        /// <value>The parent identifier.</value>
        public int ParentId { get; set; }

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
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        public bool IsActive { get; set; }
    }
}

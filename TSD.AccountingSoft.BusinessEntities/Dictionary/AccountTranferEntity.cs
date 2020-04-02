/***********************************************************************
 * <copyright file="AccountTranferEntity.cs" company="BUCA JSC">
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
    /// AccountTranferEntity
    /// </summary>
    public class AccountTranferEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountTranferEntity"/> class.
        /// </summary>
        public AccountTranferEntity()
        {
            AddRule(new ValidateRequired("AccountTranferCode"));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountTranferEntity"/> class.
        /// </summary>
        /// <param name="accountTranferId">The account tranfer identifier.</param>
        /// <param name="accountTranferCode">The account tranfer code.</param>
        /// <param name="sortOrder">The sort order.</param>
        /// <param name="accountDestinationCode">The account destination code.</param>
        /// <param name="accountSourceCode">The account source code.</param>
        /// <param name="sideOfTranfer">The side of tranfer.</param>
        /// <param name="type">The type.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <param name="description">The description.</param>
        public AccountTranferEntity(int accountTranferId, string accountTranferCode, int sortOrder, string accountDestinationCode, int? budgetSourceId, string referentAccount, string accountSourceCode, int sideOfTranfer, int type, bool isActive, string description)
            : this()
        {
            this.AccountTranferId = accountTranferId;
            this.AccountTranferCode = accountTranferCode;
            this.SortOrder = sortOrder;
            this.AccountSourceCode = accountSourceCode;
            this.AccountDestinationCode = accountDestinationCode;
            this.SideOfTranfer = sideOfTranfer;
            this.Type = type;
            this.IsActive = isActive;
            this.Description = description;
            this.BudgetSourceId = budgetSourceId;
            this.ReferentAccount = referentAccount;
        }

        /// <summary>
        /// Gets or sets the account tranfer identifier.
        /// </summary>
        /// <value>
        /// The account tranfer identifier.
        /// </value>
        public int AccountTranferId { get; set; }

        /// <summary>
        /// Gets or sets the account tranfer code.
        /// </summary>
        /// <value>
        /// The account tranfer code.
        /// </value>
        public string AccountTranferCode { get; set; }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        /// <value>
        /// The sort order.
        /// </value>
        public int SortOrder { get; set; }

        /// <summary>
        /// Gets or sets the account source code.
        /// </summary>
        /// <value>
        /// The account source code.
        /// </value>
        public string AccountSourceCode { get; set; }

        public int? BudgetSourceId { get; set; }

        public string ReferentAccount { get; set; }

        /// <summary>
        /// Gets or sets the account destination code.
        /// </summary>
        /// <value>
        /// The account destination code.
        /// </value>
        public string AccountDestinationCode { get; set; }

        /// <summary>
        /// Gets or sets the side of tranfer.
        /// </summary>
        /// <value>
        /// The side of tranfer.
        /// </value>
        public int SideOfTranfer { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public int Type { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is active].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is active]; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }
    }
}

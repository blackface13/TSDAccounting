/***********************************************************************
 * <copyright file="CalculateClosingEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: Tuesday, December 23, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

namespace TSD.AccountingSoft.BusinessEntities.Dictionary
{
    /// <summary>
    /// CalculateClosingEntity
    /// </summary>
    public class CalculateClosingEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CalculateClosingEntity" /> class.
        /// </summary>
        public CalculateClosingEntity()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CalculateClosingEntity"/> class.
        /// </summary>
        /// <param name="accountId">The account identifier.</param>
        /// <param name="accountName">Name of the account.</param>
        /// <param name="accountCode">The account code.</param>
        /// <param name="parentId">The parent identifier.</param>
        /// <param name="closingAmounts">The closing amounts.</param>
        public CalculateClosingEntity(int accountId, string accountName, string accountCode, int parentId, decimal closingAmounts)
            : this()
        {
            AccountId = accountId;
            AccountName = accountName;
            AccountCode = accountCode;
            ParentId = parentId;
            ClosingAmounts = closingAmounts;
        }

        /// <summary>
        /// Gets or sets the reference type Account Id.
        /// </summary>
        /// <value>
        /// The reference Account Id.
        /// </value>
        public int AccountId { get; set; }

        /// <summary>
        /// Gets or sets the Account Name.
        /// </summary>
        /// <value>
        /// The Account Name.
        /// </value>
        public string AccountName { get; set; }

        /// <summary>
        /// Gets or sets the Account Code.
        /// </summary>
        /// <value>
        /// The Account Code.
        /// </value>
        public string AccountCode { get; set; }

        /// <summary>
        /// Gets or sets the Parent Id.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public int ParentId { get; set; }

        /// <summary>
        /// Gets or sets the Closing Amounts.
        /// </summary>
        /// <value>
        /// The value Closing Amounts.
        /// </value>
        public decimal ClosingAmounts { get; set; }

    }
}

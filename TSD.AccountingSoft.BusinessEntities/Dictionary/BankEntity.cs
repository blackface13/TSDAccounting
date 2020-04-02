/***********************************************************************
 * <copyright file="BankEntity.cs" company="BUCA JSC">
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
    /// BankEntity
    /// </summary>
    public class BankEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BankEntity"/> class.
        /// </summary>
        public BankEntity()
        {
            AddRule(new ValidateRequired("BankAccount"));
            AddRule(new ValidateRequired("BankName"));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BankEntity"/> class.
        /// </summary>
        /// <param name="bankId">The bank identifier.</param>
        /// <param name="bankAccount">The bank account.</param>
        /// <param name="bankName">Name of the bank.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <param name="description">The description.</param>
        /// <param name="bankAddress">The bank address.</param>
        public BankEntity(int bankId, string bankAccount, string bankName, bool isActive, string description, string bankAddress)
            : this()
        {
            BankId = bankId;
            BankAccount = bankAccount;
            BankName = bankName;
            BankAddress = bankAddress;
            IsActive = isActive;
            Description = description;
        }

        /// <summary>
        /// Gets or sets the bank identifier.
        /// </summary>
        /// <value>
        /// The bank identifier.
        /// </value>
        public int BankId { get; set; }

        /// <summary>
        /// Gets or sets the bank account.
        /// </summary>
        /// <value>
        /// The bank account.
        /// </value>
        public string BankAccount { get; set; }

        /// <summary>
        /// Gets or sets the name of the bank.
        /// </summary>
        /// <value>
        /// The name of the bank.
        /// </value>
        public string BankName { get; set; }

        /// <summary>
        /// Gets or sets the bank address.
        /// </summary>
        /// <value>
        /// The bank address.
        /// </value>
        public string BankAddress { get; set; }

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

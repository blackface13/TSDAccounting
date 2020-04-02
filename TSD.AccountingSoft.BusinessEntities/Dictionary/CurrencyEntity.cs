/***********************************************************************
 * <copyright file="CurrencyEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuanHM
 * Email:    Tuanhm@buca.vn
 * Website:
 * Create Date: Friday, March 7, 2014
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
    /// Class CurrencyEntity.
    /// </summary>
    public class CurrencyEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyEntity"/> class.
        /// </summary>
        public CurrencyEntity()
        {
            AddRule(new ValidateId("CurrencyId"));
            AddRule(new ValidateRequired("CurrencyCode"));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyEntity"/> class.
        /// </summary>
        /// <param name="currencyId">The currency identifier.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="currencyName">Name of the currency.</param>
        /// <param name="prefix">The prefix.</param>
        /// <param name="suffix">The suffix.</param>
        /// <param name="isMain">if set to <c>true</c> [is main].</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        public CurrencyEntity(int currencyId, string currencyCode, string currencyName, string prefix, string suffix, bool isMain, bool isActive)
            : this()
        {
            CurrencyId = currencyId;
            CurrencyCode = currencyCode;
            CurrencyName = currencyName;
            Prefix = prefix;
            Suffix = suffix;
            IsMain = isMain;
            IsActive = isActive;
        }

        /// <summary>
        /// Gets or sets the currency identifier.
        /// </summary>
        /// <value>
        /// The currency identifier.
        /// </value>
        public int CurrencyId { get; set; }

        /// <summary>
        /// Gets or sets the currency code.
        /// </summary>
        /// <value>
        /// The currency code.
        /// </value>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the currency.
        /// </summary>
        /// <value>
        /// The name of the currency.
        /// </value>
        public string CurrencyName { get; set; }

        /// <summary>
        /// Gets or sets the prefix.
        /// </summary>
        /// <value>
        /// The prefix.
        /// </value>
        public string Prefix { get; set; }

        /// <summary>
        /// Gets or sets the suffix.
        /// </summary>
        /// <value>
        /// The suffix.
        /// </value>
        public string Suffix { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is main].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is main]; otherwise, <c>false</c>.
        /// </value>
        public bool IsMain { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is active].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is active]; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }
    }
}

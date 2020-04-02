/***********************************************************************
 * <copyright file="ValidateRegex.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 13 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Text.RegularExpressions;


namespace TSD.AccountingSoft.BusinessEntities.BusinessRules
{
    /// <summary>
    /// Base class for regex based validation rules.
    /// </summary>
    public class ValidateRegex : BusinessRule
    {
        protected string Pattern { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidateRegex"/> class.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="pattern">The pattern.</param>
        public ValidateRegex(string propertyName, string pattern)
            : base(propertyName)
        {
            Pattern = pattern;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidateRegex"/> class.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="pattern">The pattern.</param>
        public ValidateRegex(string propertyName, string errorMessage, string pattern)
            : this(propertyName, pattern)
        {
            ErrorMessage = errorMessage;
        }

        /// <summary>
        /// Validates the specified business entities.
        /// </summary>
        /// <param name="businessEntities">The business entities.</param>
        /// <returns></returns>
        public override bool Validate(BusinessEntities  businessEntities )
        {
            return Regex.Match(GetPropertyValue(businessEntities ).ToString(), Pattern).Success;
        }
    }
}

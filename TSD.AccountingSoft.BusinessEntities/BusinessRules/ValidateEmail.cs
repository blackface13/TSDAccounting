/***********************************************************************
 * <copyright file="ValidateEmail.cs" company="BUCA JSC">
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

namespace TSD.AccountingSoft.BusinessEntities.BusinessRules
{
    /// <summary>
    /// Email validation rule.
    /// </summary>
    public class ValidateEmail : ValidateRegex
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidateEmail"/> class.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        public ValidateEmail(string propertyName) :
            base(propertyName, @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")
        {
            ErrorMessage = propertyName + " is not a valid email address";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidateEmail"/> class.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="errorMessage">The error message.</param>
        public ValidateEmail(string propertyName, string errorMessage) :
            this(propertyName)
        {
            ErrorMessage = errorMessage;
        }
    }
}

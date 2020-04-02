/***********************************************************************
 * <copyright file="ValidateIPAddress.cs" company="BUCA JSC">
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
    /// class ValidateIPAddress
    /// </summary>
    public class ValidateIPAddress : ValidateRegex
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidateIPAddress"/> class.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        public ValidateIPAddress(string propertyName) :
            base(propertyName, @"^([0-2]?[0-5]?[0-5]\.){3}[0-2]?[0-5]?[0-5]$")
        {
            ErrorMessage = propertyName + " is not a valid IP Address";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidateIPAddress"/> class.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="errorMessage">The error message.</param>
        public ValidateIPAddress(string propertyName, string errorMessage) :
            this(propertyName)
        {
            ErrorMessage = errorMessage;
        }
    }
}

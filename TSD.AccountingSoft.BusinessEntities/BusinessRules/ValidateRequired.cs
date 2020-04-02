/***********************************************************************
 * <copyright file="ValidateRequired.cs" company="BUCA JSC">
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
    /// Represents a validation rules that states that a value is required.
    /// </summary>
    public class ValidateRequired : BusinessRule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidateRequired"/> class.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        public ValidateRequired(string propertyName)
            : base(propertyName)
        {
            ErrorMessage = propertyName + " is a required field.";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidateRequired"/> class.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="errorMessage">The error message.</param>
        public ValidateRequired(string propertyName, string errorMessage)
            : base(propertyName)
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
            try
            {
                return GetPropertyValue(businessEntities ).ToString().Length > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}

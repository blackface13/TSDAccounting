/***********************************************************************
 * <copyright file="ValidateId.cs" company="BUCA JSC">
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
    /// Identity validation rule. 
    /// Value must be integer and greater than zero.
    /// </summary>
    public class ValidateId : BusinessRule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidateId"/> class.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        public ValidateId(string propertyName)
            : base(propertyName)
        {
            ErrorMessage = propertyName + " is an invalid identifier";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidateId"/> class.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="errorMessage">The error message.</param>
        public ValidateId(string propertyName, string errorMessage)
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
                int id = int.Parse(GetPropertyValue(businessEntities ).ToString());
                return id >= 0;
            }
            catch
            {
                return false;
            }
        }
    }
}

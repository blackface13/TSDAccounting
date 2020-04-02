/***********************************************************************
 * <copyright file="ValidateLength.cs" company="BUCA JSC">
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
    ///  Length validation rule. 
    ///  Length must be between given min and max values.
    /// </summary>
    public class ValidateLength : BusinessRule
    {
        private readonly int _min;
        private readonly int _max;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidateLength"/> class.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        public ValidateLength(string propertyName, int min, int max)
            : base(propertyName)
        {
            _min = min;
            _max = max;

            ErrorMessage = propertyName + " must be between " + _min + " and " + _max + " characters long.";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidateLength"/> class.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        public ValidateLength(string propertyName, string errorMessage, int min, int max)
            : this(propertyName, min, max)
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
            int length = GetPropertyValue(businessEntities ).ToString().Length;
            return length >= _min && length <= _max;
        }
    }
}

/***********************************************************************
 * <copyright file="ValidateRange.cs" company="BUCA JSC">
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

using System;


namespace TSD.AccountingSoft.BusinessEntities.BusinessRules
{
    /// <summary>
    /// Validates a range (min and max) for a given data type.
    /// </summary>
    public class ValidateRange : BusinessRule
    {
        /// <summary>
        /// Gets or sets the type of the data.
        /// </summary>
        /// <value>
        /// The type of the data.
        /// </value>
        private ValidationDataType DataType { get; set; }
        /// <summary>
        /// Gets or sets the operator.
        /// </summary>
        /// <value>
        /// The operator.
        /// </value>
        private ValidationOperator Operator { get; set; }

        /// <summary>
        /// Gets or sets the minimum.
        /// </summary>
        /// <value>
        /// The minimum.
        /// </value>
        private object Min { get; set; }
        /// <summary>
        /// Gets or sets the maximum.
        /// </summary>
        /// <value>
        /// The maximum.
        /// </value>
        private object Max { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidateRange" /> class.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        /// <param name="operator">The operator.</param>
        /// <param name="dataType">Type of the data.</param>
        public ValidateRange(string propertyName, object min, object max,
            ValidationOperator @operator, ValidationDataType dataType)
            : base(propertyName)
        {
            Min = min;
            Max = max;

            Operator = @operator;
            DataType = dataType;

            ErrorMessage = propertyName + " must be between " + Min + " and " + Max;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidateRange" /> class.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        /// <param name="operator">The operator.</param>
        /// <param name="dataType">Type of the data.</param>
        public ValidateRange(string propertyName, string errorMessage, object min, object max,
            ValidationOperator @operator, ValidationDataType dataType)
            : this(propertyName, min, max, @operator, dataType)
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
                string value = GetPropertyValue(businessEntities ).ToString();

                switch (DataType)
                {
                    case ValidationDataType.Integer:

                        int imin = int.Parse(Min.ToString());
                        int imax = int.Parse(Max.ToString());
                        int ival = int.Parse(value);

                        return (ival >= imin && ival <= imax);

                    case ValidationDataType.Double:
                        double dmin = double.Parse(Min.ToString());
                        double dmax = double.Parse(Max.ToString());
                        double dval = double.Parse(value);

                        return (dval >= dmin && dval <= dmax);

                    case ValidationDataType.Decimal:
                        decimal cmin = decimal.Parse(Min.ToString());
                        decimal cmax = decimal.Parse(Max.ToString());
                        decimal cval = decimal.Parse(value);

                        return (cval >= cmin && cval <= cmax);

                    case ValidationDataType.Date:
                        DateTime tmin = DateTime.Parse(Min.ToString());
                        DateTime tmax = DateTime.Parse(Max.ToString());
                        DateTime tval = DateTime.Parse(value);

                        return (tval >= tmin && tval <= tmax);

                    case ValidationDataType.String:

                        string smin = Min.ToString();
                        string smax = Max.ToString();

                        int result1 = String.CompareOrdinal(smin, value);
                        int result2 = String.CompareOrdinal(value, smax);

                        return result1 >= 0 && result2 <= 0;
                }
                return false;
            }
            catch { return false; }
        }
    }
}

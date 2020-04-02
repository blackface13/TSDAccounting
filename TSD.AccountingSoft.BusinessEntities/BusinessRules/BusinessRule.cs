/***********************************************************************
 * <copyright file="BusinessRule.cs" company="BUCA JSC">
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
    public abstract class BusinessRule
    {
        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }

        protected BusinessRule(string propertyName)
        {
            PropertyName = propertyName;
            ErrorMessage = propertyName + " is not valid";
        }

        protected BusinessRule(string propertyName, string errorMessage)
            : this(propertyName)
        {
            ErrorMessage = errorMessage;
        }

        public abstract bool Validate(BusinessEntities businessEntities);

        protected object GetPropertyValue(BusinessEntities businessEntities)
        {
            return businessEntities.GetType().GetProperty(PropertyName).GetValue(businessEntities, null);
        }
    }
}

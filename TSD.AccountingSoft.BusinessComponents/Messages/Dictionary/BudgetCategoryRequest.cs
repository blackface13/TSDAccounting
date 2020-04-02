/***********************************************************************
 * <copyright file="BudgetCategoryRequest.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   THODD
 * Email:    thodd@buca.vn
 * Website:
 * Create Date: 07 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Dictionary;


namespace TSD.AccountingSoft.BusinessComponents.Messages.Dictionary
{
    /// <summary>
    /// Class BudgetCategoryRequest.
    /// </summary>
    public class BudgetCategoryRequest : RequestBase
    {
        /// <summary>
        /// Gets or sets the budget category identifier.
        /// </summary>
        /// <value>The budget category identifier.</value>
        public int BudgetCategoryId { get; set; }

        /// <summary>
        /// The budget category
        /// </summary>
        public BudgetCategoryEntity BudgetCategory;
    }
}

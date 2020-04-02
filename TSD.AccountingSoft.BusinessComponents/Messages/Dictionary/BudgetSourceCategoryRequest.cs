/***********************************************************************
 * <copyright file="BudgetSourceCategoryRequest.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 19 June 2014
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
    /// class BudgetSourceCategoryRequest
    /// </summary>
    public class BudgetSourceCategoryRequest : RequestBase
    {
        /// <summary>
        /// Gets or sets the budgetSourceCategory identifier.
        /// </summary>
        /// <value>
        /// The budgetSourceCategory identifier.
        /// </value>
        public int BudgetSourceCategoryId { get; set; }

        /// <summary>
        /// The budgetSourceCategory
        /// </summary>
        public BudgetSourceCategoryEntity BudgetSourceCategory;
    }
}

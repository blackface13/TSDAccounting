/***********************************************************************
 * <copyright file="BudgetSourceCategoryResponse.cs" company="BUCA JSC">
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

using System.Collections.Generic;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Dictionary;


namespace TSD.AccountingSoft.BusinessComponents.Messages.Dictionary
{
    /// <summary>
    /// class BudgetSourceCategoryResponse
    /// </summary>
    public class BudgetSourceCategoryResponse : ResponseBase
    {
        /// <summary>
        /// The budgetSourceCategorys
        /// </summary>
        public IList<BudgetSourceCategoryEntity> BudgetSourceCategories;

        /// <summary>
        /// The budgetSourceCategory
        /// </summary>
        public BudgetSourceCategoryEntity BudgetSourceCategory;

        /// <summary>
        /// Gets or sets the budgetSourceCategory identifier.
        /// </summary>
        /// <value>
        /// The budgetSourceCategory identifier.
        /// </value>
        public int BudgetSourceCategoryId { get; set; }
    }
}

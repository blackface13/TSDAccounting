/***********************************************************************
 * <copyright file="BudgetCategoryResponse.cs" company="BUCA JSC">
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

using System.Collections.Generic;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Dictionary;


namespace TSD.AccountingSoft.BusinessComponents.Messages.Dictionary
{
    /// <summary>
    /// Class BudgetCategoryResponse.
    /// </summary>
    public class BudgetCategoryResponse : ResponseBase
    {
        /// <summary>
        /// The budget categories
        /// </summary>
        public IList<BudgetCategoryEntity> BudgetCategories;

        /// <summary>
        /// The budget category
        /// </summary>
        public BudgetCategoryEntity BudgetCategory;

        /// <summary>
        /// The budget category identifier
        /// </summary>
        public int BudgetCategoryId;
    }
}

/***********************************************************************
 * <copyright file="IBudgetSourceCategoryDao.cs" company="BUCA JSC">
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

using TSD.AccountingSoft.BusinessEntities.Dictionary;
using System.Collections.Generic;


namespace TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary
{
    /// <summary>
    /// IBudgetSourceCategoryDao
    /// </summary>
    public interface IBudgetSourceCategoryDao
    {
        /// <summary>
        /// Gets the budgetSourceCategory.
        /// </summary>
        /// <param name="budgetSourceCategoryId">The budgetSourceCategory identifier.</param>
        /// <returns></returns>
        BudgetSourceCategoryEntity GetBudgetSourceCategory(int budgetSourceCategoryId);

        /// <summary>
        /// Gets the budgetSourceCategories.
        /// </summary>
        /// <returns></returns>
        List<BudgetSourceCategoryEntity> GetBudgetSourceCategories();

        /// <summary>
        /// Gets the budgetSourceCategories by budgetSourceCategory code.
        /// </summary>
        /// <param name="budgetSourceCategoryCode">The budgetSourceCategory code.</param>
        /// <returns></returns>
        List<BudgetSourceCategoryEntity> GetBudgetSourceCategoriesByBudgetSourceCategoryCode(string budgetSourceCategoryCode);

        /// <summary>
        /// Gets the budgetSourceCategories by active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        List<BudgetSourceCategoryEntity> GetBudgetSourceCategoriesByActive(bool isActive);

        /// <summary>
        /// Inserts the budgetSourceCategory.
        /// </summary>
        /// <param name="budgetSourceCategory">The budgetSourceCategory.</param>
        /// <returns></returns>
        int InsertBudgetSourceCategory(BudgetSourceCategoryEntity budgetSourceCategory);

        /// <summary>
        /// Updates the budgetSourceCategory.
        /// </summary>
        /// <param name="budgetSourceCategory">The budgetSourceCategory.</param>
        /// <returns></returns>
        string UpdateBudgetSourceCategory(BudgetSourceCategoryEntity budgetSourceCategory);

        /// <summary>
        /// Deletes the budgetSourceCategory.
        /// </summary>
        /// <param name="budgetSourceCategory">The budgetSourceCategory.</param>
        /// <returns></returns>
        string DeleteBudgetSourceCategory(BudgetSourceCategoryEntity budgetSourceCategory);
    }
}

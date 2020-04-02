/***********************************************************************
 * <copyright file="IBudgetCategoryDao.cs" company="BUCA JSC">
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
using TSD.AccountingSoft.BusinessEntities.Dictionary;


namespace TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary
{
    /// <summary>
    /// Interface IBudgetCategoryDao
    /// </summary>
    public interface IBudgetCategoryDao
    {
        /// <summary>
        /// Gets the budgetCategory.
        /// </summary>
        /// <param name="budgetCategoryId">The budgetCategory identifier.</param>
        /// <returns></returns>
        BudgetCategoryEntity GetBudgetCategory(int budgetCategoryId);

        /// <summary>
        /// Gets the budgetCategorys.
        /// </summary>
        /// <returns></returns>
        List<BudgetCategoryEntity> GetBudgetCategories();

        /// <summary>
        /// Gets the budgetCategorys for combo tree.
        /// </summary>
        /// <param name="budgetCategoryId">The budgetCategory identifier.</param>
        /// <returns></returns>
        List<BudgetCategoryEntity> GetBudgetCategoriesForComboTree(int budgetCategoryId);

        /// <summary>
        /// Gets the budget categories active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        List<BudgetCategoryEntity> GetBudgetCategoriesByActive(bool isActive);

        /// <summary>
        /// Inserts the budgetCategory.
        /// </summary>
        /// <param name="budgetCategory">The budgetCategory.</param>
        /// <returns></returns>
        int InsertBudgetCategory(BudgetCategoryEntity budgetCategory);

        /// <summary>
        /// Updates the budgetCategory.
        /// </summary>
        /// <param name="budgetCategory">The budgetCategory.</param>
        /// <returns></returns>
        string UpdateBudgetCategory(BudgetCategoryEntity budgetCategory);

        /// <summary>
        /// Deletes the budgetCategory.
        /// </summary>
        /// <param name="budgetCategory">The budgetCategory.</param>
        /// <returns></returns>
        string DeleteBudgetCategory(BudgetCategoryEntity budgetCategory);
    }
}
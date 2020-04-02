/***********************************************************************
 * <copyright file="IBudgetSourceDao.cs" company="BUCA JSC">
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
    /// 
    /// </summary>
    public interface IBudgetSourceDao
    {
        /// <summary>
        /// Gets the budgetSource.
        /// </summary>
        /// <param name="budgetSourceId">The budgetSource identifier.</param>
        /// <returns></returns>
        BudgetSourceEntity GetBudgetSource(int budgetSourceId);

        BudgetSourceEntity GetBudgetSourceByBudgetSourceCode(string budgetSourceCode);

        /// <summary>
        /// Gets the budgetSources.
        /// </summary>
        /// <returns></returns>
        List<BudgetSourceEntity> GetBudgetSources();

        /// <summary>
        /// Gets the budgetSources.
        /// </summary>
        /// <returns></returns>
        List<BudgetSourceEntity> GetBudgetSourcesByFund();

        /// <summary>
        /// Gets the budgetSources for combo tree.
        /// </summary>
        /// <param name="budgetSourceId">The budgetSource identifier.</param>
        /// <returns></returns>
        List<BudgetSourceEntity> GetBudgetSourcesForComboTree(int budgetSourceId);

        /// <summary>
        /// Gets the budgetSources active.
        /// </summary>
        /// <returns></returns>
        List<BudgetSourceEntity> GetBudgetSourcesActive();

        /// <summary>
        /// Gets the budget sources is parent.
        /// </summary>
        /// <param name="isParent">if set to <c>true</c> [is parent].</param>
        /// <returns></returns>
        List<BudgetSourceEntity> GetBudgetSourcesIsParent(bool isParent);

        /// <summary>
        /// Inserts the budgetSource.
        /// </summary>
        /// <param name="budgetSource">The budgetSource.</param>
        /// <returns></returns>
        int InsertBudgetSource(BudgetSourceEntity budgetSource);

        /// <summary>
        /// Updates the budgetSource.
        /// </summary>
        /// <param name="budgetSource">The budgetSource.</param>
        /// <returns></returns>
        string UpdateBudgetSource(BudgetSourceEntity budgetSource);

        /// <summary>
        /// Deletes the budgetSource.
        /// </summary>
        /// <param name="budgetSource">The budgetSource.</param>
        /// <returns></returns>
        string DeleteBudgetSource(BudgetSourceEntity budgetSource);
    }
}
/***********************************************************************
 * <copyright file="IBudgetChapterDao.cs" company="BUCA JSC">
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
    /// Interface IBudgetChapterDao
    /// </summary>
    public interface IBudgetChapterDao
    {
        /// <summary>
        /// Gets the budget chapter.
        /// </summary>
        /// <param name="budgetChapterId">The budget chapter identifier.</param>
        /// <returns>BudgetChapterEntity.</returns>
        BudgetChapterEntity GetBudgetChapter(int budgetChapterId);

        /// <summary>
        /// Gets the budget chapters.
        /// </summary>
        /// <returns>List{BudgetChapterEntity}.</returns>
        List<BudgetChapterEntity> GetBudgetChapters();

        /// <summary>
        /// Gets the budget chapters by active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns>List{BudgetChapterEntity}.</returns>
        List<BudgetChapterEntity> GetBudgetChaptersByActive(bool isActive);

        /// <summary>
        /// Inserts the budget chapter.
        /// </summary>
        /// <param name="budgetChapter">The budget chapter.</param>
        /// <returns>System.Int32.</returns>
        int InsertBudgetChapter(BudgetChapterEntity budgetChapter);

        /// <summary>
        /// Updates the budget chapter.
        /// </summary>
        /// <param name="budgetChapter">The budget chapter.</param>
        /// <returns>System.String.</returns>
        string UpdateBudgetChapter(BudgetChapterEntity budgetChapter);

        /// <summary>
        /// Deletes the budget chapter.
        /// </summary>
        /// <param name="budgetChapter">The budget chapter.</param>
        /// <returns>System.String.</returns>
        string DeleteBudgetChapter(BudgetChapterEntity budgetChapter);

        /// <summary>
        /// Gets the budget chapters by budget chapter code.
        /// </summary>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <returns>List{BudgetChapterEntity}.</returns>
        List<BudgetChapterEntity> GetBudgetChaptersByBudgetChapterCode(string budgetChapterCode);
    }
}

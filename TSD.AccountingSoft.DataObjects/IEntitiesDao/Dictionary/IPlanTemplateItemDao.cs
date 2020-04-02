/***********************************************************************
 * <copyright file="SqlServerFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Thursday, February 28, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  07/03/2014       Author    Tudt           Description: Coding standard
 * 
 * ************************************************************************/

using System.Collections.Generic;
using TSD.AccountingSoft.BusinessEntities.Dictionary;


namespace TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary
{
    /// <summary>
    /// interface IPlanTemplateItemDao
    /// </summary>
    public interface IPlanTemplateItemDao
    {
        /// <summary>
        /// Gets the PlanTemplateItem.
        /// </summary>
        /// <param name="planTemplateItemId">The PlanTemplateItem identifier.</param>
        /// <returns></returns>
        PlanTemplateItemEntity GetPlanTemplateItem(int planTemplateItemId);

        /// <summary>
        /// Gets the PlanTemplateItem.
        /// </summary>
        /// <param name="planTemplateListId">The PlanTemplateItem identifier.</param>
        /// <returns></returns>
        IList<PlanTemplateItemEntity> GetPlanTemplateItemByPlanTemplateList(int planTemplateListId);


        IList<PlanTemplateItemEntity> GetPlanTemplateItemByPlanTemplateListForEstimate(int planTemplateListId, short planYear, int budgetSourceCategoryId);

        IList<PlanTemplateItemEntity> GetPlanTemplateItemByPlanTemplateListForEstimateUpdate(int planTemplateListId, short planYear, int budgetSourceCategoryId, int option);

        /// <summary>
        /// Gets the PlanTemplateItems.
        /// </summary>
        /// <returns></returns>
        List<PlanTemplateItemEntity> GetPlanTemplateItems();

        /// <summary>
        /// Inserts the PlanTemplateItem.
        /// </summary>
        /// <param name="planTemplateItem">The PlanTemplateItem.</param>
        /// <returns></returns>
        int InsertPlanTemplateItem(PlanTemplateItemEntity planTemplateItem);

        /// <summary>
        /// Updates the PlanTemplateItem.
        /// </summary>
        /// <param name="planTemplateItem">The PlanTemplateItem.</param>
        /// <returns></returns>
        string UpdatePlanTemplateItem(PlanTemplateItemEntity planTemplateItem);

        /// <summary>
        /// Deletes the PlanTemplateItem.
        /// </summary>
        /// <param name="planTemplateItem">The PlanTemplateItem.</param>
        /// <returns></returns>
        string DeletePlanTemplateItem(PlanTemplateItemEntity planTemplateItem);

        /// <summary>
        /// Deletes the PlanTemplateItem.
        /// </summary>
        /// <param name="planTemplateListId">The PlanTemplateItem.</param>
        /// <returns></returns>
        string DeletePlanTemplateItemByPlanTemplateListId(int planTemplateListId);
    }
}

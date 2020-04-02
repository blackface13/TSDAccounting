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
    /// Interface IPlanTemplateListDao
    /// </summary>
    public interface IPlanTemplateListDao
    {
        /// <summary>
        /// Gets the PlanTemplateList.
        /// </summary>
        /// <param name="planTemplateListId">The PlanTemplateList identifier.</param>
        /// <returns>PlanTemplateListEntity.</returns>
        PlanTemplateListEntity GetPlanTemplateList(int planTemplateListId);

        /// <summary>
        /// Gets the PlanTemplateLists.
        /// </summary>
        /// <returns>List{PlanTemplateListEntity}.</returns>
        List<PlanTemplateListEntity> GetPlanTemplateLists();

        /// <summary>
        /// Gets the PlanTemplateLists.
        /// </summary>
        /// <param name="isReceipt">The is receipt.</param>
        /// <returns>List{PlanTemplateListEntity}.</returns>
        List<PlanTemplateListEntity> GetPlanTemplateLists(int isReceipt);

        /// <summary>
        /// Gets the plan template lists by code.
        /// </summary>
        /// <param name="planTemplateListCode">The plan template list code.</param>
        /// <returns>List{PlanTemplateListEntity}.</returns>
        List<PlanTemplateListEntity> GetPlanTemplateListsByCode(string planTemplateListCode);

        /// <summary>
        /// Inserts the PlanTemplateList.
        /// </summary>
        /// <param name="planTemplateList">The PlanTemplateList.</param>
        /// <returns>System.Int32.</returns>
        int InsertPlanTemplateList(PlanTemplateListEntity planTemplateList);

        /// <summary>
        /// Updates the PlanTemplateList.
        /// </summary>
        /// <param name="planTemplateList">The PlanTemplateList.</param>
        /// <returns>System.String.</returns>
        string UpdatePlanTemplateList(PlanTemplateListEntity planTemplateList);

        /// <summary>
        /// Deletes the PlanTemplateList.
        /// </summary>
        /// <param name="planTemplateList">The PlanTemplateList.</param>
        /// <returns>System.String.</returns>
        string DeletePlanTemplateList(PlanTemplateListEntity planTemplateList);
    }
}

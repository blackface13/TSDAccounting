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

using System.Linq;
using TSD.AccountingSoft.BusinessComponents.Messages.Dictionary;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary;


namespace TSD.AccountingSoft.BusinessComponents.Facade.Dictionary
{
    /// <summary>
    /// Class PlanTemplateItemFacade.
    /// </summary>
    public class PlanTemplateItemFacade
    {
        /// <summary>
        /// The plan template item DAO
        /// </summary>
        private static readonly IPlanTemplateItemDao PlanTemplateItemDao = DataAccess.DataAccess.PlanTemplateItemDao;

        /// <summary>
        /// Gets the accounts.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>PlanTemplateItemResponse.</returns>
        public PlanTemplateItemResponse GetPlanTemplateItems(PlanTemplateItemRequest request)
        {
            var response = new PlanTemplateItemResponse();
            if (request.LoadOptions.Contains("PlanTemplateItems"))
            {
                if (request.LoadOptions.Contains("PlanTemplateListId"))
                    response.PlanTemplateItems = PlanTemplateItemDao.GetPlanTemplateItemByPlanTemplateList(request.PlanTemplateListId);
                else if (request.LoadOptions.Contains("Estimate"))
                    response.PlanTemplateItems=PlanTemplateItemDao.GetPlanTemplateItemByPlanTemplateListForEstimate(request.PlanTemplateListId, request.PlanYear,request.BudgetSourceCategoryId);
                else if (request.LoadOptions.Contains("Option"))
                    response.PlanTemplateItems = PlanTemplateItemDao.GetPlanTemplateItemByPlanTemplateListForEstimateUpdate(request.PlanTemplateListId, request.PlanYear, request.BudgetSourceCategoryId,request.Option);
                else
                    response.PlanTemplateItems =  PlanTemplateItemDao.GetPlanTemplateItems();
            }
            if (request.LoadOptions.Contains("PlanTemplateItem"))
                response.PlanTemplateItem = PlanTemplateItemDao.GetPlanTemplateItem(request.PlanTemplateItemId);
            return response;
        }
    }
}

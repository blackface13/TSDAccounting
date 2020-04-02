/***********************************************************************
 * <copyright file="SqlServerFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Tuesday, June 13, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  13/06/2017       Author    Tudt           Description: Coding standard
 * 
 * ************************************************************************/

using System.Linq;
using TSD.AccountingSoft.BusinessComponents.Messages.Dictionary;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary;

namespace TSD.AccountingSoft.BusinessComponents.Facade.Dictionary
{
    public class PlanReceiptTempateItemFacade
    {
        private static readonly IPlanReceiptTempateItemDao PlanReceiptTempateItemDao = DataAccess.DataAccess.PlanReceiptTempateItemDao;

        public PlanReceiptTempateItemResponse GetPlanReceiptTempateItems(PlanReceiptTempateItemRequest request)
        {
            var response = new PlanReceiptTempateItemResponse();
            //if (request.LoadOptions.Contains("PlanTemplateItems"))
            //{
            //    if (request.LoadOptions.Contains("PlanTemplateListId"))
            //        response.PlanTemplateItems = PlanTemplateItemDao.GetPlanTemplateItemByPlanTemplateList(request.PlanTemplateListId);
            //    else if (request.LoadOptions.Contains("Estimate"))
            //        response.PlanTemplateItems = PlanTemplateItemDao.GetPlanTemplateItemByPlanTemplateListForEstimate(request.PlanTemplateListId, request.PlanYear, request.BudgetSourceCategoryId);
            //    else if (request.LoadOptions.Contains("Option"))
            //        response.PlanTemplateItems = PlanTemplateItemDao.GetPlanTemplateItemByPlanTemplateListForEstimateUpdate(request.PlanTemplateListId, request.PlanYear, request.BudgetSourceCategoryId, request.Option);
            //    else
            //        response.PlanTemplateItems = PlanTemplateItemDao.GetPlanTemplateItems();
            //}
            if (request.LoadOptions.Contains("PlanReceiptTempateItems"))
                response.PlanReceiptTempateItems = PlanReceiptTempateItemDao.GetPlanReceiptTempateItems();
            return response;
        }
    }
}

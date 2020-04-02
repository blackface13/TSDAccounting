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

using System;
using System.Linq;
using System.Transactions;
using TSD.AccountingSoft.BusinessComponents.Messages.Dictionary;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Estimate;


namespace TSD.AccountingSoft.BusinessComponents.Facade.Dictionary
{
    /// <summary>
    /// Class PlanTemplateListFacade.
    /// </summary>
    public class PlanTemplateListFacade
    {
        /// <summary>
        /// The plan template list DAO
        /// </summary>
        private static readonly IPlanTemplateListDao PlanTemplateListDao = DataAccess.DataAccess.PlanTemplateListDao;

        /// <summary>
        /// The plan template item DAO
        /// </summary>
        private static readonly IPlanTemplateItemDao PlanTemplateItemDao = DataAccess.DataAccess.PlanTemplateItemDao;

        private static readonly IEstimateDao EstimateDao = DataAccess.DataAccess.EstimateDao;

        /// <summary>
        /// Gets the accounts.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>PlanTemplateListResponse.</returns>
        public PlanTemplateListResponse GetPlanTemplateLists(PlanTemplateListRequest request)
        {
            var response = new PlanTemplateListResponse();

            if (request.LoadOptions.Contains("PlanTemplateLists"))
            {
                if (request.LoadOptions.Contains("IsReceipt"))
                    response.PlanTemplateLists = PlanTemplateListDao.GetPlanTemplateLists(request.IsReceipt);
                else if (request.LoadOptions.Contains("IsPayment"))
                    response.PlanTemplateLists = PlanTemplateListDao.GetPlanTemplateLists(request.IsReceipt);
                else
                    response.PlanTemplateLists = PlanTemplateListDao.GetPlanTemplateLists();
            }
            if (request.LoadOptions.Contains("PlanTemplateList"))
            {
                response.PlanTemplateList = PlanTemplateListDao.GetPlanTemplateList(request.PlanTemplateListId);
                if (request.LoadOptions.Contains("PlanTemplateItems"))
                    response.PlanTemplateList.PlanTemplateItems = PlanTemplateItemDao.GetPlanTemplateItemByPlanTemplateList(request.PlanTemplateListId);
                if (request.LoadOptions.Contains("Constraint"))
                {
                    var estimate = EstimateDao.CheckConstraintPlanTemplateList(request.PlanTemplateListId);
                    if (estimate != null)
                    {
                        response.PlanTemplateListId = estimate.PlanTemplateListId;
                    }
                    else
                    {
                        response.PlanTemplateListId = -1;
                    }
                }
            }
            return response;
        }

        /// <summary>
        /// Sets the accounts.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>PlanTemplateListResponse.</returns>
        public PlanTemplateListResponse SetPlanTemplateLists(PlanTemplateListRequest request)
        {
            var response = new PlanTemplateListResponse();

            var planTemplateListEntity = request.PlanTemplateList;
            if (request.Action != PersistType.Delete)
            {
                if (!planTemplateListEntity.Validate())
                {
                    foreach (string error in planTemplateListEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
            }
            try
            {
                if (request.Action == PersistType.Insert)
                {
                    using (var scope = new TransactionScope())
                    {
                        var planTemplateLists = PlanTemplateListDao.GetPlanTemplateListsByCode(planTemplateListEntity.PlanTemplateListCode);
                        if (planTemplateLists.Count > 0)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            response.Message = @"Mã mẫu dự toán " + planTemplateListEntity.PlanTemplateListCode + @" đã tồn tại !";
                            return response;
                        }
                        planTemplateListEntity.PlanTemplateListId = PlanTemplateListDao.InsertPlanTemplateList(planTemplateListEntity);
                        if (planTemplateListEntity.PlanTemplateListId == 0)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            return response;
                        }
                        if (planTemplateListEntity.PlanTemplateItems.Count > 0)
                        {
                            foreach (var planTemplateItem in planTemplateListEntity.PlanTemplateItems)
                            {
                                planTemplateItem.PlanTemplateListId = planTemplateListEntity.PlanTemplateListId;
                                var planTemplateItemId = PlanTemplateItemDao.InsertPlanTemplateItem(planTemplateItem);
                                if (planTemplateItemId != 0) continue;
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }
                        }
                        response.Message = null;
                        scope.Complete();
                    }
                }
                else if (request.Action == PersistType.Update)
                {
                    using (var scope = new TransactionScope())
                    {
                        //LINHMC them doan kiem tra danh sach mau du toan da duoc su dung thi ko cho cap nhat 
                        //chi tim nhung muc duoc danh dau la them moi de insert
                        var checkExisted = EstimateDao.CheckConstraintPlanTemplateList(planTemplateListEntity.PlanTemplateListId);
                        if (checkExisted != null) // co ton tai 
                        {
                            var planTemplateItems = planTemplateListEntity.PlanTemplateItems.Where(p => p.IsInserted).ToList();
                            if (planTemplateItems.Count > 0)
                            {
                                foreach (var item in planTemplateItems)
                                {
                                    item.PlanTemplateListId = planTemplateListEntity.PlanTemplateListId;
                                    var planTemplateItemId = PlanTemplateItemDao.InsertPlanTemplateItem(item);
                                    if (planTemplateItemId != 0) continue;
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }
                            }
                        }
                        else
                        {
                            var message = PlanTemplateListDao.UpdatePlanTemplateList(planTemplateListEntity);
                            if (message != null)
                            {
                                response.Message = message;
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }
                            message = PlanTemplateItemDao.DeletePlanTemplateItemByPlanTemplateListId(planTemplateListEntity.PlanTemplateListId);
                            if (message != null)
                            {
                                response.Message = message;
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }
                            if (planTemplateListEntity.PlanTemplateItems.Count > 0)
                            {
                                foreach (var planTemplateItem in planTemplateListEntity.PlanTemplateItems)
                                {
                                    planTemplateItem.PlanTemplateListId = planTemplateListEntity.PlanTemplateListId;
                                    var planTemplateItemId = PlanTemplateItemDao.InsertPlanTemplateItem(planTemplateItem);
                                    if (planTemplateItemId != 0) continue;
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }
                            }
                        }
                        
                        scope.Complete();
                    }
                }
                else
                {
                    var accountEntityForDelete = PlanTemplateListDao.GetPlanTemplateList(request.PlanTemplateListId);
                    response.Message = PlanTemplateListDao.DeletePlanTemplateList(accountEntityForDelete);
                }
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }

            response.PlanTemplateListId = planTemplateListEntity != null ? planTemplateListEntity.PlanTemplateListId : 0;
            response.Acknowledge = response.Message != null ? AcknowledgeType.Failure : AcknowledgeType.Success;
            return response;
        }
    }
}

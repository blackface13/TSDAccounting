/***********************************************************************
 * <copyright file="BudgetSourceFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   THODD
 * Email:    thodd@buca.vn
 * Website:
 * Create Date: Wednesday, February 26, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Linq;
using TSD.AccountingSoft.BusinessComponents.Messages.Dictionary;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary;


namespace TSD.AccountingSoft.BusinessComponents.Facade.Dictionary
{
    /// <summary>
    /// Class BudgetSourceFacade.
    /// </summary>
    public class BudgetSourceFacade
    {
        /// <summary>
        /// The budget source DAO
        /// </summary>
        private static readonly IBudgetSourceDao BudgetSourceDao = DataAccess.DataAccess.BudgetSourceDao;

        /// <summary>
        /// Gets the budget sources.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>BudgetSourceResponse.</returns>
        public BudgetSourceResponse GetBudgetSources(BudgetSourceRequest request)
        {
            var response = new BudgetSourceResponse();
            if (request.LoadOptions.Contains("BudgetSources"))
            {
                if (request.LoadOptions.Contains("IsActive"))
                    response.BudgetSources = request.LoadOptions.Contains("ForComboTree") ? BudgetSourceDao.GetBudgetSourcesForComboTree(request.BudgetSourceId) : BudgetSourceDao.GetBudgetSourcesActive();
                else if (request.LoadOptions.Contains("Fund"))
                    response.BudgetSources = BudgetSourceDao.GetBudgetSourcesByFund();
                else if (request.LoadOptions.Contains("IsParent"))
                    response.BudgetSources = BudgetSourceDao.GetBudgetSourcesIsParent(request.IsParent);
                else response.BudgetSources = BudgetSourceDao.GetBudgetSources();
            }
            if (!request.LoadOptions.Contains("BudgetSource")) return response;
            response.BudgetSource = BudgetSourceDao.GetBudgetSource(request.BudgetSourceId);
            return response;
        }

        /// <summary>
        /// Sets the budget sources.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>BudgetSourceResponse.</returns>
        public BudgetSourceResponse SetBudgetSources(BudgetSourceRequest request)
        {
            var response = new BudgetSourceResponse();

            var budgetSourceEntity = request.BudgetSource;
            if (request.Action != PersistType.Delete)
            {
                if (!budgetSourceEntity.Validate())
                {
                    foreach (string error in budgetSourceEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
            }
            try
            {
                if (request.Action == PersistType.Insert)
                {
                    budgetSourceEntity.BudgetSourceId = BudgetSourceDao.InsertBudgetSource(budgetSourceEntity);
                    response.Message = null;
                }
                else if (request.Action == PersistType.Update) 
                    response.Message = BudgetSourceDao.UpdateBudgetSource(budgetSourceEntity);
                else
                {
                    var budgetSourceEntityForDelete = BudgetSourceDao.GetBudgetSource(request.BudgetSourceId);
                    response.Message = BudgetSourceDao.DeleteBudgetSource(budgetSourceEntityForDelete);
                }
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
            response.BudgetSourceId = budgetSourceEntity != null ? budgetSourceEntity.BudgetSourceId : 0;
            response.Acknowledge = response.Message != null ? AcknowledgeType.Failure : AcknowledgeType.Success;
            return response;
        }
    }
}

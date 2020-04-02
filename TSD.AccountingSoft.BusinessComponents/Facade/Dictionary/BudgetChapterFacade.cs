/***********************************************************************
 * <copyright file="BudgetChapterFacade.cs" company="BUCA JSC">
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

using System;
using System.Linq;
using TSD.AccountingSoft.BusinessComponents.Messages.Dictionary;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary;

namespace TSD.AccountingSoft.BusinessComponents.Facade.Dictionary
{
    /// <summary>
    /// Class BudgetChapterFacade.
    /// </summary>
    public class BudgetChapterFacade
    {
        /// <summary>
        /// The budget chapter DAO
        /// </summary>
        private static readonly IBudgetChapterDao BudgetChapterDao = DataAccess.DataAccess.BudgetChapterDao;

        /// <summary>
        /// Gets the budget chapters.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>BudgetChapterResponse.</returns>
        public BudgetChapterResponse GetBudgetChapters(BudgetChapterRequest request)
        {
            var response = new BudgetChapterResponse();
            if (request.LoadOptions.Contains("BudgetChapters"))
                response.BudgetChapters = request.LoadOptions.Contains("IsActive") ? BudgetChapterDao.GetBudgetChaptersByActive(true) : BudgetChapterDao.GetBudgetChapters();
            if (request.LoadOptions.Contains("BudgetChapter"))
                response.BudgetChapter = BudgetChapterDao.GetBudgetChapter(request.BudgetChapterId);
            return response;
        }

        /// <summary>
        /// Sets the budget chapters.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>BudgetChapterResponse.</returns>
        public BudgetChapterResponse SetBudgetChapters(BudgetChapterRequest request)
        {
            var response = new BudgetChapterResponse();
            var budgetChapterEntity = request.BudgetChapter;
            if (request.Action != PersistType.Delete)
            {
                if (!budgetChapterEntity.Validate())
                {
                    foreach (string error in budgetChapterEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
            }
            try
            {
                if (request.Action == PersistType.Insert)
                {
                    var budgetChapters = BudgetChapterDao.GetBudgetChaptersByBudgetChapterCode(budgetChapterEntity.BudgetChapterCode);
                    if (budgetChapters.Count > 0)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        response.Message = @"Mã chương " + budgetChapterEntity.BudgetChapterCode + @" đã tồn tại !";
                        return response;
                    }
                    budgetChapterEntity.BudgetChapterId = BudgetChapterDao.InsertBudgetChapter(budgetChapterEntity);
                    response.Message = null;
                }
                else if (request.Action == PersistType.Update) 
                    response.Message = BudgetChapterDao.UpdateBudgetChapter(budgetChapterEntity);
                else
                {
                    var budgetChapterForUpdate = BudgetChapterDao.GetBudgetChapter(request.BudgetChapterId);
                    response.Message = BudgetChapterDao.DeleteBudgetChapter(budgetChapterForUpdate);
                }
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
            response.BudgetChapterId = budgetChapterEntity != null ? budgetChapterEntity.BudgetChapterId : 0;
            response.Acknowledge = response.Message != null ? AcknowledgeType.Failure : AcknowledgeType.Success;
            return response;
        }
    }
}

/***********************************************************************
 * <copyright file="BudgetSourceCategoryFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 19 June 2014
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
    /// BudgetSourceCategoryFacade
    /// </summary>
    public class BudgetSourceCategoryFacade
    {
        private static readonly IBudgetSourceCategoryDao BudgetSourceCategoryDao = DataAccess.DataAccess.BudgetSourceCategoryDao;

        /// <summary>
        /// Gets the budgetSouceCategories.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public BudgetSourceCategoryResponse GetBudgetSourceCategories(BudgetSourceCategoryRequest request)
        {
            var response = new BudgetSourceCategoryResponse();

            if (request.LoadOptions.Contains("BudgetSourceCategories"))
            {
                response.BudgetSourceCategories = request.LoadOptions.Contains("IsActive") ? BudgetSourceCategoryDao.GetBudgetSourceCategoriesByActive(true) : 
                    BudgetSourceCategoryDao.GetBudgetSourceCategories();
            }
            if (request.LoadOptions.Contains("BudgetSourceCategory"))
                response.BudgetSourceCategory = BudgetSourceCategoryDao.GetBudgetSourceCategory(request.BudgetSourceCategoryId);

            return response;
        }

        /// <summary>
        /// Sets the budgetSouceCategories.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public BudgetSourceCategoryResponse SetBudgetSourceCategories(BudgetSourceCategoryRequest request)
        {
            var response = new BudgetSourceCategoryResponse();

            var budgetSouceCategoryEntity = request.BudgetSourceCategory;
            if (request.Action != PersistType.Delete)
            {
                if (!budgetSouceCategoryEntity.Validate())
                {
                    foreach (string error in budgetSouceCategoryEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
            }
            try
            {
                if (request.Action == PersistType.Insert)
                {
                    var budgetSouceCategories = BudgetSourceCategoryDao.GetBudgetSourceCategoriesByBudgetSourceCategoryCode(budgetSouceCategoryEntity.BudgetSourceCategoryCode);
                    if (budgetSouceCategories.Count > 0)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        response.Message = @"Mã loại nguồn " + budgetSouceCategoryEntity.BudgetSourceCategoryCode + @" đã tồn tại !";
                        return response;
                    }
                    budgetSouceCategoryEntity.BudgetSourceCategoryId = BudgetSourceCategoryDao.InsertBudgetSourceCategory(budgetSouceCategoryEntity);
                    response.Message = null;
                }
                else if (request.Action == PersistType.Update)
                    response.Message = BudgetSourceCategoryDao.UpdateBudgetSourceCategory(budgetSouceCategoryEntity);
                else
                {
                    var budgetSouceCategoryForUpdate = BudgetSourceCategoryDao.GetBudgetSourceCategory(request.BudgetSourceCategoryId);
                    response.Message = BudgetSourceCategoryDao.DeleteBudgetSourceCategory(budgetSouceCategoryForUpdate);
                }
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
            response.BudgetSourceCategoryId = budgetSouceCategoryEntity != null ? budgetSouceCategoryEntity.BudgetSourceCategoryId : 0;
            if (response.Message == null)
            {
                response.Acknowledge = AcknowledgeType.Success;
                response.RowsAffected = 1;
            }
            else
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.RowsAffected = 0;
            }

            return response;
        }
    }
}

/***********************************************************************
 * <copyright file="BudgetCategoryFacade.cs" company="BUCA JSC">
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
    /// Class BudgetCategoryFacade.
    /// </summary>
    public class BudgetCategoryFacade
    {
        /// <summary>
        /// The budget category DAO
        /// </summary>
        private static readonly IBudgetCategoryDao BudgetCategoryDao = DataAccess.DataAccess.BudgetCategoryDao;

        /// <summary>
        /// Gets the budget categories.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>BudgetCategoryResponse.</returns>
        public BudgetCategoryResponse GetBudgetCategories(BudgetCategoryRequest request)
        {
            var response = new BudgetCategoryResponse();

            if (request.LoadOptions.Contains("BudgetCategories"))
                if (request.LoadOptions.Contains("IsActive"))
                    response.BudgetCategories = BudgetCategoryDao.GetBudgetCategoriesByActive(true);
                else if (request.LoadOptions.Contains("NonActive"))
                    response.BudgetCategories = BudgetCategoryDao.GetBudgetCategoriesByActive(false);
                else response.BudgetCategories = BudgetCategoryDao.GetBudgetCategories();
            if (request.LoadOptions.Contains("BudgetCategory")) 
                response.BudgetCategory = BudgetCategoryDao.GetBudgetCategory(request.BudgetCategoryId);
            return response;
        }

        /// <summary>
        /// Sets the budget categories.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>BudgetCategoryResponse.</returns>
        public BudgetCategoryResponse SetBudgetCategories(BudgetCategoryRequest request)
        {
            var response = new BudgetCategoryResponse();
            var budgetCategoryEntity = request.BudgetCategory;
            if (request.Action != PersistType.Delete)
            {
                if (!budgetCategoryEntity.Validate())
                {
                    foreach (string error in budgetCategoryEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
            }
            try
            {
                if (request.Action == PersistType.Insert)
                {
                    budgetCategoryEntity.BudgetCategoryId = BudgetCategoryDao.InsertBudgetCategory(budgetCategoryEntity);
                    response.Message = null;
                }
                else if (request.Action == PersistType.Update) 
                    response.Message = BudgetCategoryDao.UpdateBudgetCategory(budgetCategoryEntity);
                else
                {
                    var budgetCategoryEntityForDelete = BudgetCategoryDao.GetBudgetCategory(request.BudgetCategoryId);
                    response.Message = BudgetCategoryDao.DeleteBudgetCategory(budgetCategoryEntityForDelete);
                }
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
            response.BudgetCategoryId = budgetCategoryEntity != null ? budgetCategoryEntity.BudgetCategoryId : 0;
            response.Acknowledge = response.Message != null ? AcknowledgeType.Failure : AcknowledgeType.Success;
            return response;
        }
    }
}

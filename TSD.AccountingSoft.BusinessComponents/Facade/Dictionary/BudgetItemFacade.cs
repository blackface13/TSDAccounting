/***********************************************************************
 * <copyright file="SqlServerFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Thursday, February 26, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  07/03/2014       Author    Tudt           Description: Coding standard
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
    /// Class BudgetItemFacade.
    /// </summary>
    public class BudgetItemFacade
    {
        /// <summary>
        /// The budget item DAO
        /// </summary>
        private static readonly IBudgetItemDao BudgetItemDao = DataAccess.DataAccess.BudgetItemDao;

        /// <summary>
        /// Gets the accounts.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>BudgetItemResponse.</returns>
        public BudgetItemResponse GetBudgetItems(BudgetItemRequest request)
        {
            var response = new BudgetItemResponse();

            if (request.LoadOptions.Contains("BudgetItems"))
            {
                if (request.LoadOptions.Contains("IsActive"))
                    if (request.LoadOptions.Contains("ItemAndSubItem"))
                        response.BudgetItems = BudgetItemDao.GetBudgetItemAndSubItems(request.BudgetItemType,request.IsActive);
                    else
                        response.BudgetItems = BudgetItemDao.GetBudgetItemsActive();
                else if (request.LoadOptions.Contains("Detail")) 
                    response.BudgetItems = BudgetItemDao.GetBudgetItems(request.BudgetItemType);
                else if (request.LoadOptions.Contains("Receipt")) 
                    response.BudgetItems = BudgetItemDao.GetBudgetItemsByIsReceipt(request.IsReceipt);
                else if (request.LoadOptions.Contains("ReceiptForEstimate"))
                    response.BudgetItems = BudgetItemDao.GetBudgetItemsByIsReceiptForEstimate(request.IsReceipt);
                else if (request.LoadOptions.Contains("PayVoucher"))
                    response.BudgetItems = BudgetItemDao.GetBudgetItemsByPayVoucher();
                else if (request.LoadOptions.Contains("CapitalAllocate"))
                    response.BudgetItems = BudgetItemDao.GetBudgetItemsByCapitalAllocate(); 
                else 
                    response.BudgetItems = BudgetItemDao.GetBudgetItems();
            }
            if (request.LoadOptions.Contains("BudgetItem")) 
                response.BudgetItem = BudgetItemDao.GetBudgetItem(request.BudgetItemId);
            return response;
        }

        /// <summary>
        /// Sets the accounts.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>BudgetItemResponse.</returns>
        public BudgetItemResponse SetBudgetItems(BudgetItemRequest request)
        {
            var response = new BudgetItemResponse();

            var budgetItemEntity = request.BudgetItem;
            if (request.Action != PersistType.Delete)
            {
                if (!budgetItemEntity.Validate())
                {
                    foreach (string error in budgetItemEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
            }
            try
            {
                if (request.Action == PersistType.Insert)
                {
                    var budgetitems = BudgetItemDao.GetBudgetItemsByCode(budgetItemEntity.BudgetItemCode);
                    if (budgetitems.Count > 0)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        response.Message = @"Mã mục lục ngân sách " + budgetItemEntity.BudgetItemCode + @" đã tồn tại !";
                        return response;
                    }
                    budgetItemEntity.BudgetItemId = BudgetItemDao.InsertBudgetItem(budgetItemEntity);
                    response.Message = null;
                }
                else if (request.Action == PersistType.Update)
                {
                    response.Message = BudgetItemDao.UpdateBudgetItem(budgetItemEntity);
                }
                else
                {
                    var budgetItemEntityForDelete = BudgetItemDao.GetBudgetItem(request.BudgetItemId);
                    response.Message = BudgetItemDao.DeleteBudgetItem(budgetItemEntityForDelete);
                }
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }

            response.BudgetItemId = budgetItemEntity != null ? budgetItemEntity.BudgetItemId : 0;
            response.Acknowledge = response.Message != null ? AcknowledgeType.Failure : AcknowledgeType.Success;
            return response;
        }
    }
}


/***********************************************************************
 * <copyright file="InventoryItemFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: Wednesday, March 12, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using TSD.AccountingSoft.BusinessComponents.Messages.Dictionary;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Dictionary;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary;


namespace TSD.AccountingSoft.BusinessComponents.Facade.Dictionary
{

    /// <summary>
    /// Class InventoryItemFacade.
    /// </summary>
    public class InventoryItemFacade
    {
        /// <summary>
        /// The inventory item DAO
        /// </summary>
        private static readonly IInventoryItemDao InventoryItemDao = DataAccess.DataAccess.InventoryItemDao;
        private static readonly IAutoNumberListDao AutoNumberListDao = DataAccess.DataAccess.AutoNumberListDao;

        /// <summary>
        /// Getses the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>InventoryItemResponse.</returns>
        public InventoryItemResponse GetInventoryItems(InventoryItemRequest request)
        {
            var response = new InventoryItemResponse();
            if (request.LoadOptions.Contains("InventoryItems"))
                response.InventoryItems = InventoryItemDao.GetInventoryItemList();
            if (request.LoadOptions.Contains("InventoryItem")) 
                response.InventoryItem = InventoryItemDao.GetInventoryItem(request.InventoryItemId);
             //dành cho phần vật tư
            if (request.LoadOptions.Contains("ItemStock"))
                response.InventoryItems = InventoryItemDao.GetInventoryItemListByStock(request.ItemStockId, request.RefId,request.PostDate,request.CurrencyCode);
        
            if (request.LoadOptions.Contains("ItemStockInput"))
                response.InventoryItems = InventoryItemDao.GetInventoryItemListByStock(request.ItemStockId);

            return response;
        }

        /// <summary>
        /// Setses the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>InventoryItemResponse.</returns>
        public InventoryItemResponse SetInventoryItems(InventoryItemRequest request)
        {
            var response = new InventoryItemResponse();
            var mapper = request.InventoryItem;
            if (request.Action != PersistType.Delete)
            {
                if (!mapper.Validate())
                {
                    foreach (string error in mapper.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
            }
            try
            {
                if (request.Action == PersistType.Insert)
                {
                    var lstInventoryItem = InventoryItemDao.GetInventoryItemByCode(mapper.InventoryItemCode);
                    if (lstInventoryItem.Count > 0)
                    {
                        response.Message = "Bạn nhập mã đã tồn tại " + mapper.InventoryItemCode + "!";
                    }
                    else
                    {
                        AutoNumberListDao.UpdateIncreateAutoNumberListByValue("InventoryItem");
                        mapper.InventoryItemId = InventoryItemDao.InsertInventoryItem(mapper);
                        response.Message = null; 
                    }
                }
                else if (request.Action == PersistType.Update)
                {
                    var objInventoryItem = InventoryItemDao.GetInventoryItemByCode(mapper.InventoryItemCode).FirstOrDefault();
                    if (objInventoryItem == null)
                    {
                        response.Message = InventoryItemDao.UpdateInventoryItem(mapper);
                        
                    }
                    else
                    {
                         if (objInventoryItem.InventoryItemId == mapper.InventoryItemId)
                             response.Message = InventoryItemDao.UpdateInventoryItem(mapper); 
                         else
                             response.Message = "Bạn nhập mã đã tồn tại " + mapper.InventoryItemCode + "!"; 
                        
                    }
                       
                    
                }

                else
                {
                    response.Message = InventoryItemDao.DeleteInventoryItem(request.InventoryItemId);
                }
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }

            response.InventoryItemId = mapper != null ? mapper.InventoryItemId : 0;
            response.Acknowledge = response.Message != null ? AcknowledgeType.Failure : AcknowledgeType.Success;
            return response;
        }


        public List<InventoryItemEntity> GetInventoryItemsByIsStockAndIsActiveAndCategoryCode(bool isStock, bool isActive, string inventoryCategoryCode)
        {
            return InventoryItemDao.GetInventoryItemsByIsStockAndIsActiveAndCategoryCode(isStock, isActive, inventoryCategoryCode);
        }
    }
}

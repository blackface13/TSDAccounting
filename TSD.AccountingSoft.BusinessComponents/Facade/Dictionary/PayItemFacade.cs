/***********************************************************************
 * <copyright file="PayItemFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
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
    /// PayItemFacade
    /// </summary>
    public class PayItemFacade
    {
        private static readonly IPayItemDao PayItemDao = DataAccess.DataAccess.PayItemDao;

        /// <summary>
        /// Gets the pay items.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public PayItemResponse GetPayItems(PayItemRequest request)
        {
            var response = new PayItemResponse();

            if (request.LoadOptions.Contains("PayItems"))
            {
                if (request.LoadOptions.Contains("IsActive"))
                    response.PayItems = PayItemDao.GetPayItemsIsActive(true);
                else
                    response.PayItems = PayItemDao.GetPayItems();
            }
            if (request.LoadOptions.Contains("PayItem"))
                response.PayItem = PayItemDao.GetPayItem(request.PayItemId);

            return response;
        }

        /// <summary>
        /// Sets the pay items.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public PayItemResponse SetPayItems(PayItemRequest request)
        {
            var response = new PayItemResponse();

            var payItemEntity = request.PayItem;
            if (request.Action != PersistType.Delete)
            {
                if (!payItemEntity.Validate())
                {
                    foreach (string error in payItemEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
            }
            try
            {
                if (request.Action == PersistType.Insert)
                {
                    var payItems = PayItemDao.GetPayItemsByPayItemCode(payItemEntity.PayItemCode);
                    if (payItems.Count > 0)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        response.Message = @"Mã khoản lương " + payItemEntity.PayItemCode + @" đã tồn tại !";
                        return response;
                    }
                    payItemEntity.PayItemId = PayItemDao.InsertPayItem(payItemEntity);
                    response.Message = payItemEntity.PayItemId == 0 ? @"Thêm mới có lỗi" : null;
                }
                else if (request.Action == PersistType.Update)
                    response.Message = PayItemDao.UpdatePayItem(payItemEntity);
                else
                {
                    var payItemEntityForUpdate = PayItemDao.GetPayItem(request.PayItemId);
                    response.Message = PayItemDao.DeletePayItem(payItemEntityForUpdate);
                }
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
            response.PayItemId = payItemEntity != null ? payItemEntity.PayItemId : 0;
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
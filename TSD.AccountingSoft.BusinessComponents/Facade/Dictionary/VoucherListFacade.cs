/***********************************************************************
 * <copyright file="VoucherListFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Hoàng Bích Sơn
 * Email:    sonhb@buca.vn
 * Website:
 * Create Date: Wednesday, March 5, 2014
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
    /// VoucherListFacade class
    /// </summary>
    public class VoucherListFacade
    {
        /// <summary>
        /// The voucher list DAO
        /// </summary>
        private static readonly IVoucherListDao VoucherListDao = DataAccess.DataAccess.VoucherListDao;

        /// <summary>
        /// Gets the voucher lists.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public VoucherListResponse GetVoucherLists(VoucherListRequest request)
        {
            var response = new VoucherListResponse();

            if (request.LoadOptions.Contains("VoucherLists"))
                response.VoucherLists = VoucherListDao.GetVoucherLists();
            if (request.LoadOptions.Contains("VoucherList")) 
                response.VoucherList = VoucherListDao.GetVoucherListById(request.VoucherListId);

            return response;
        }

        /// <summary>
        /// Sets the voucher lists.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public VoucherListResponse SetVoucherLists(VoucherListRequest request)
        {
            var response = new VoucherListResponse();
            var voucherListEntity = request.VoucherList;
            if (request.Action != PersistType.Delete)
            {
                if (!voucherListEntity.Validate())
                {
                    foreach (string error in voucherListEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
            }
            try
            {
                if (request.Action == PersistType.Insert)
                {
                    voucherListEntity.VoucherListId = VoucherListDao.InsertVoucherList(voucherListEntity);
                    response.Message = null;
                }
                else
                    if (request.Action == PersistType.Update)
                        response.Message = VoucherListDao.UpdateVoucherList(voucherListEntity);
                    else
                    {
                        var voucherListForDelete = VoucherListDao.GetVoucherListById(request.VoucherListId);
                        response.Message = VoucherListDao.DeleteVoucherList(voucherListForDelete);
                    }
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }

            response.VoucherListId = voucherListEntity != null ? voucherListEntity.VoucherListId : 0;
            response.Acknowledge = response.Message != null ? AcknowledgeType.Failure : AcknowledgeType.Success;
            return response;
        }
    }
}

/***********************************************************************
 * <copyright file="VendorFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Hoàng Bích Sơn
 * Email:    sonhb@buca.vn
 * Website:
 * Create Date: Friday, March 7, 2014
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
    /// VendorFacade class
    /// </summary>
    public class VendorFacade
    {
        /// <summary>
        /// The vendor DAO
        /// </summary>
        private static readonly IVendorDao VendorDao = DataAccess.DataAccess.VendorDao;
        private static readonly IAutoNumberListDao AutoNumberListDao = DataAccess.DataAccess.AutoNumberListDao;

        /// <summary>
        /// Gets the vendors.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public VendorResponse GetVendors(VendorRequest request)
        {
            var response = new VendorResponse();

            if (request.LoadOptions.Contains("Vendors"))
            {
                response.Vendors = request.LoadOptions.Contains("IsActive") ? VendorDao.GetVendorByActives(request.IsActive) : VendorDao.GetVendors();
            }
            if (request.LoadOptions.Contains("Vendor"))
                response.Vendor = VendorDao.GetVendorById(request.VendorId);

            return response;
        }

        /// <summary>
        /// Sets the vendors.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public VendorResponse SetVendors(VendorRequest request)
        {
            var response = new VendorResponse();
            var vendorEntity = request.Vendor;
            if (request.Action != PersistType.Delete)
            {
                if (!vendorEntity.Validate())
                {
                    foreach (string error in vendorEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
            }
            try
            {
                if (request.Action == PersistType.Insert)
                {
                    var vendorByCode = VendorDao.GetVendorByCode(vendorEntity.VendorCode);
                    if (vendorByCode != null)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        response.Message = @"Mã nhà cung cấp " + vendorByCode.VendorCode + @" đã tồn tại !";
                        return response;
                    }
                    AutoNumberListDao.UpdateIncreateAutoNumberListByValue("Vendor");
                    vendorEntity.VendorId = VendorDao.InsertVendor(vendorEntity);
                    response.Message = null;
                }
                else if (request.Action == PersistType.Update)
                {
                    var vendorByCode = VendorDao.GetVendorByCode(vendorEntity.VendorCode);
                    if (vendorByCode != null)
                    {
                        if (vendorByCode.VendorId != vendorEntity.VendorId)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            response.Message = @"Mã nhà cung cấp " + vendorByCode.VendorCode + @" đã tồn tại !";
                            return response;
                        }
                    }
                    response.Message = VendorDao.UpdateVendor(vendorEntity);
                }
                else
                {
                    var vendorForUpdate = VendorDao.GetVendorById(request.VendorId);
                    response.Message = VendorDao.DeleteVendor(vendorForUpdate);
                }
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }

            response.VendorId = vendorEntity != null ? vendorEntity.VendorId : 0;
            response.Acknowledge = response.Message != null ? AcknowledgeType.Failure : AcknowledgeType.Success;
            return response;
        }
    }
}

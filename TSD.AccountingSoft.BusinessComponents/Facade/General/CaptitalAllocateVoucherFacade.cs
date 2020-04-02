/***********************************************************************
 * <copyright file="CaptitalAllocateVoucherFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: 19 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Linq;
using TSD.AccountingSoft.BusinessComponents.Messages.General;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.General;


namespace TSD.AccountingSoft.BusinessComponents.Facade.General
{
    /// <summary>
    /// Class CaptitalAllocateVoucherFacade.
    /// </summary>
  public  class CaptitalAllocateVoucherFacade
  {

      /// <summary>
      /// The captital allocate voucher DAO
      /// </summary>
      private static readonly ICaptitalAllocateVoucherDao CaptitalAllocateVoucherDao = DataAccess.DataAccess.CaptitalAllocateVoucherDao;

      /// <summary>
      /// Gets the captital allocate voucher.
      /// </summary>
      /// <param name="request">The request.</param>
      /// <returns>CaptitalAllocateVoucherReponse.</returns>
      public CaptitalAllocateVoucherReponse GetCaptitalAllocateVoucher(CaptitalAllocateVoucherRequest request)
        {
            var response = new CaptitalAllocateVoucherReponse();
            if (request.LoadOptions.Contains("CaptitalAllocateVouchers"))
            {
                response.GetCaptitalAllocateVouchers = CaptitalAllocateVoucherDao.GetCaptitalAllocateVoucherForUpdateOrInsert();
            }
            return response;
        }

      /// <summary>
      /// Sets the captital allocate vouchers.
      /// </summary>
      /// <param name="request">The request.</param>
      /// <returns>CaptitalAllocateVoucherReponse.</returns>
      public CaptitalAllocateVoucherReponse SetCaptitalAllocateVouchers(CaptitalAllocateVoucherRequest request)
        {
            var response = new CaptitalAllocateVoucherReponse();
            var captitalAllocateVoucherEntity = request.CaptitalAllocateVoucherEntity;
             if (request.Action != PersistType.Delete)
            {
                if (!captitalAllocateVoucherEntity.Validate())
                {
                    foreach (string error in captitalAllocateVoucherEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
            }

            try
            {
                if (request.Action == PersistType.Insert)
                {

                    captitalAllocateVoucherEntity.RefDetailId = CaptitalAllocateVoucherDao.InsertCaptitalAllocateVoucher(captitalAllocateVoucherEntity);
                    response.Message = null;
                }
                else if (request.Action == PersistType.Update)
                {
                    response.Message = CaptitalAllocateVoucherDao.DeleteCaptitalAllocateVoucher(captitalAllocateVoucherEntity.RefId);
                    captitalAllocateVoucherEntity.RefDetailId = CaptitalAllocateVoucherDao.InsertCaptitalAllocateVoucher(captitalAllocateVoucherEntity);
                    response.Message = null;
                }

                else
                    response.Message =
                        CaptitalAllocateVoucherDao.DeleteCaptitalAllocateVoucher(request.RefId);

            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }

            response.CaptitalAllocateVoucherId = captitalAllocateVoucherEntity != null ? Convert.ToInt32(captitalAllocateVoucherEntity.RefDetailId) : 0;
            response.Acknowledge = response.Message != null ? AcknowledgeType.Failure : AcknowledgeType.Success;
            return response;
             
        }


      /// <summary>
      /// Gets the captital allocate vouchers from date to to date.
      /// </summary>
      /// <param name="request">The request.</param>
      /// <returns>CaptitalAllocateVoucherReponse.</returns>
      public CaptitalAllocateVoucherReponse GetCaptitalAllocateVouchersFromDateToToDate(CaptitalAllocateVoucherRequest request)
      {
          var response = new CaptitalAllocateVoucherReponse();
          if (request.LoadOptions.Contains("CaptitalAllocateVouchers"))
          {
              response.GetCaptitalAllocateVouchers = CaptitalAllocateVoucherDao.GetCaptitalAllocateVouchersFromDateToToDate(request.FromDate, request.ToDate,request.ActivityId, request.CurrencyCode);
          }
          return response;
      }

      /// <summary>
      /// Gets the captital allocate vouchers from date to to date for update.
      /// </summary>
      /// <param name="request">The request.</param>
      /// <returns>CaptitalAllocateVoucherReponse.</returns>
      public CaptitalAllocateVoucherReponse GetCaptitalAllocateVouchersFromDateToToDateForUpdate(CaptitalAllocateVoucherRequest request)
      {
          var response = new CaptitalAllocateVoucherReponse();
          if (request.LoadOptions.Contains("CaptitalAllocateVouchers"))
          {
              response.GetCaptitalAllocateVouchers = CaptitalAllocateVoucherDao.GetCaptitalAllocateVouchersFromDateToToDateForUpdate(request.FromDate, request.ToDate, request.CurrencyCode,request.ActivityId,request.RefTypeId, request.RefId);
          }
          return response;
      }


      /// <summary>
      /// Gets the captital allocate vouchers by reference identifier.
      /// </summary>
      /// <param name="request">The request.</param>
      /// <returns>CaptitalAllocateVoucherReponse.</returns>
      public CaptitalAllocateVoucherReponse GetCaptitalAllocateVouchersByRefId(CaptitalAllocateVoucherRequest request)
      {
          var response = new CaptitalAllocateVoucherReponse();
          if (request.LoadOptions.Contains("CaptitalAllocateVouchers"))
          {
              response.GetCaptitalAllocateVouchers = CaptitalAllocateVoucherDao.GetCaptitalAllocateVouchersByRefId(request.RefId);
          }
          return response;
      }

    }
}

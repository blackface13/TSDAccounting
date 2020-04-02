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
    /// AccountTranferVoucherFacade
    /// </summary>
    public class AccountTranferVoucherFacade
  {

      /// <summary>
      /// The account tranfer vourcher DAO
      /// </summary>
        private static readonly IAccountTranferVourcherDao AccountTranferVourcherDao = DataAccess.DataAccess.AccountTranferVourcherDao;

        /// <summary>
        /// Gets the captital allocate voucher.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
      public AccountTranferVourcherReponse GetCaptitalAllocateVoucher(AccountTranferVourcherRequest request)
        {
            var response = new AccountTranferVourcherReponse();
            if (request.LoadOptions.Contains("AccountTranferVourchers"))
            {
                response.GetAccountTranferVourchers = AccountTranferVourcherDao.GetAccountTranferVourchersByRefId(request.RefId);
            }
            return response;
        }

      /// <summary>
      /// Sets the account tranfer vouchers.
      /// </summary>
      /// <param name="request">The request.</param>
      /// <returns></returns>
      public AccountTranferVourcherReponse SetAccountTranferVouchers(AccountTranferVourcherRequest request)
        {
            var response = new AccountTranferVourcherReponse();
            var accountTranferVourcherEntity = request.AccountTranferVourcherEntity;
             if (request.Action != PersistType.Delete)
            {
                if (!accountTranferVourcherEntity.Validate())
                {
                    foreach (string error in accountTranferVourcherEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
            }

            try
            {
                if (request.Action == PersistType.Insert)
                {

                    accountTranferVourcherEntity.RefDetailId = AccountTranferVourcherDao.InserAccountTranferVourcher(accountTranferVourcherEntity);
                    response.Message = null;
                }
                else if (request.Action == PersistType.Update)
                {
                    response.Message = AccountTranferVourcherDao.DeleteAccountTranferDetailVourchers(request.RefId);
                    accountTranferVourcherEntity.RefDetailId = AccountTranferVourcherDao.InserAccountTranferVourcher(accountTranferVourcherEntity);
                    response.Message = null;
                }

                else
                    response.Message =
                        AccountTranferVourcherDao.DeleteAccountTranferDetailVourchers(request.RefId);

            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }

            response.RefDetailId = accountTranferVourcherEntity != null ? Convert.ToInt32(accountTranferVourcherEntity.RefDetailId) : 0;
            response.Acknowledge = response.Message != null ? AcknowledgeType.Failure : AcknowledgeType.Success;
            return response;
             
        }


      /// <summary>
      /// Gets the account tranfer vourchers by posted date and currency code.
      /// </summary>
      /// <param name="request">The request.</param>
      /// <returns></returns>
      public AccountTranferVourcherReponse GetAccountTranferVourchersByPostedDateAndCurrencyCode(AccountTranferVourcherRequest request)
      {
          var response = new AccountTranferVourcherReponse();
          if (request.LoadOptions.Contains("AccountTranferVourchers"))
          {
              response.GetAccountTranferVourchers = AccountTranferVourcherDao.GetAccountTranferVourchersByPostedDateAndCurrencyCode(request.PostedDate,request.CurrencyCode);
          }
          return response;
      }


      public AccountTranferVourcherReponse GetAccountTranferVourchersByEdit(AccountTranferVourcherRequest request)
      {
          var response = new AccountTranferVourcherReponse();
          if (request.LoadOptions.Contains("AccountTranferVourchers"))
          {
              response.GetAccountTranferVourchers = AccountTranferVourcherDao.GetAccountTranferVourchersByEdit(request.PostedDate, request.CurrencyCode,request.RefTypeId);
          }
          return response;
      }


      /// <summary>
      /// Gets the captital allocate vouchers by reference identifier.
      /// </summary>
      /// <param name="request">The request.</param>
      /// <returns></returns>
      public AccountTranferVourcherReponse GetAccountTranferVourchersByRefId(AccountTranferVourcherRequest request)
      {
          var response = new AccountTranferVourcherReponse();
          if (request.LoadOptions.Contains("AccountTranferVourchers"))
          {
              response.GetAccountTranferVourchers = AccountTranferVourcherDao.GetAccountTranferVourchersByRefId(request.RefId);
          }
          return response;
      }

    }
}

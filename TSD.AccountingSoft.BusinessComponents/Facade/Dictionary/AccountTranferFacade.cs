/***********************************************************************
 * <copyright file="AccountTranferFacade.cs" company="BUCA JSC">
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
    /// AccountTranferFacade
    /// </summary>
    public class AccountTranferFacade
    {
        private static readonly IAccountTranferDao AccountTranferDao = DataAccess.DataAccess.AccountTranferDao;

        /// <summary>
        /// Gets the account tranfers.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public AccountTranferResponse GetAccountTranfers(AccountTranferRequest request)
        {
            var response = new AccountTranferResponse();

            if (request.LoadOptions.Contains("AccountTranfers"))
            {
                if (request.LoadOptions.Contains("IsActive")) 
                    response.AccountTranfers = AccountTranferDao.GetAccountTranfersByActive(true);
                else 
                    response.AccountTranfers = AccountTranferDao.GetAccountTranfers();
            }
            if (request.LoadOptions.Contains("AccountTranfer")) 
                response.AccountTranfer = AccountTranferDao.GetAccountTranfer(request.AccountTranferId);

            return response;
        }

        /// <summary>
        /// Sets the account tranfers.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public AccountTranferResponse SetAccountTranfers(AccountTranferRequest request)
        {
            var response = new AccountTranferResponse();

            var accountTranferEntity = request.AccountTranfer;
            if (request.Action != PersistType.Delete)
            {
                if (!accountTranferEntity.Validate())
                {
                    foreach (string error in accountTranferEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
            }
            try
            {
                if (request.Action == PersistType.Insert)
                {
                    var accountTranfers = AccountTranferDao.GetAccountTranfersByAccountTranferCode(accountTranferEntity.AccountTranferCode);
                    if (accountTranfers.Count > 0)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        response.Message = @"Mã tài khoản kết chuyển " + accountTranferEntity.AccountTranferCode + @" đã tồn tại !";
                        return response;
                    }
                    accountTranferEntity.AccountTranferId = AccountTranferDao.InsertAccountTranfer(accountTranferEntity);
                    response.Message = null;
                }
                else if (request.Action == PersistType.Update) 
                    response.Message = AccountTranferDao.UpdateAccountTranfer(accountTranferEntity);
                else
                {
                    var accountTranferForUpdate = AccountTranferDao.GetAccountTranfer(request.AccountTranferId);
                    response.Message = AccountTranferDao.DeleteAccountTranfer(accountTranferForUpdate);
                }
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
            response.AccountTranferId = accountTranferEntity != null ? accountTranferEntity.AccountTranferId : 0;
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

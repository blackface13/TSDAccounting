/***********************************************************************
 * <copyright file="BankFacade.cs" company="BUCA JSC">
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
    /// BankFacade
    /// </summary>
    public class BankFacade
    {
        private static readonly IBankDao BankDao = DataAccess.DataAccess.BankDao;
        private static readonly IAutoNumberListDao AutoNumberListDao = DataAccess.DataAccess.AutoNumberListDao;

        /// <summary>
        /// Gets the banks.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public BankResponse GetBanks(BankRequest request)
        {
            var response = new BankResponse();

            if (request.LoadOptions.Contains("Banks"))
            {
                if (request.LoadOptions.Contains("IsActive")) 
                    response.Banks = BankDao.GetBanksByActive(true);
                else 
                    response.Banks = BankDao.GetBanks();
            }
            if (request.LoadOptions.Contains("Bank")) 
                response.Bank = BankDao.GetBank(request.BankId);

            return response;
        }

        /// <summary>
        /// Sets the banks.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public BankResponse SetBanks(BankRequest request)
        {
            var response = new BankResponse();

            var bankEntity = request.Bank;
            if (request.Action != PersistType.Delete)
            {
                if (!bankEntity.Validate())
                {
                    foreach (var error in bankEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
            }
            try
            {
                if (request.Action == PersistType.Insert)
                {
                    var banks = BankDao.GetBanksByBankAccount(bankEntity.BankAccount);
                    if (banks.Count > 0)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        response.Message = @"Mã số tài khoản ngân hàng " + bankEntity.BankAccount + @" đã tồn tại !";
                        return response;
                    }

                    AutoNumberListDao.UpdateIncreateAutoNumberListByValue("Bank");

                    bankEntity.BankId = BankDao.InsertBank(bankEntity);
                    response.Message = null;
                }
                else if (request.Action == PersistType.Update) 
                    response.Message = BankDao.UpdateBank(bankEntity);
                else
                {
                    var bankForUpdate = BankDao.GetBank(request.BankId);
                    response.Message = BankDao.DeleteBank(bankForUpdate);
                }
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
            response.BankId = bankEntity != null ? bankEntity.BankId : 0;
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

/***********************************************************************
 * <copyright file="AccountingObjectFacade.cs" company="BUCA JSC">
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
    /// AccountingObjectFacade class
    /// </summary>
    public class AccountingObjectFacade
    {

        /// <summary>
        /// The accounting object DAO
        /// </summary>
        private static readonly IAccountingObjectDao AccountingObjectDao = DataAccess.DataAccess.AccountingObjectDao;
        private static readonly IAutoNumberListDao AutoNumberListDao = DataAccess.DataAccess.AutoNumberListDao;

        public AccountingObjectResponse GetAccountingObjects(AccountingObjectRequest request)
        {
            var response = new AccountingObjectResponse();

            if (request.LoadOptions.Contains("AccountingObjects"))
            {
                if (request.LoadOptions.Contains("IsActive"))
                {
                    response.AccountingObjects = AccountingObjectDao.GetAccountingObjectByActives(request.IsActive);
                }
                else if (request.LoadOptions.Contains("ForList"))
                {
                    response.AccountingObjects = AccountingObjectDao.GetAccountingObjectsForList();
                }
                else
                    response.AccountingObjects = AccountingObjectDao.GetAccountingObjects();
            }
            if (request.LoadOptions.Contains("AccountingObject")) response.AccountingObject = AccountingObjectDao.GetAccountingObjectById(request.AccountingObjectId);

            return response;
        }

        public AccountingObjectResponse SetAccountingObjects(AccountingObjectRequest request)
        {
            var response = new AccountingObjectResponse();
            var accountingObjectEntity = request.AccountingObject;
            if (request.Action != PersistType.Delete)
            {
                if (!accountingObjectEntity.Validate())
                {
                    foreach (string error in accountingObjectEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
            }
            try
            {
                if (request.Action == PersistType.Insert)
                {
                    var accountingObject = AccountingObjectDao.GetAccountingObjectByCodes(accountingObjectEntity.AccountingObjectCode);
                    if (accountingObject != null && accountingObject.Count > 0)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        response.Message = @"Mã đối tượng " + accountingObjectEntity.AccountingObjectCode + @" đã tồn tại !";
                        return response;
                    }
                    AutoNumberListDao.UpdateIncreateAutoNumberListByValue("AccountingObject");
                    accountingObjectEntity.AccountingObjectId = AccountingObjectDao.InsertAccountingObject(accountingObjectEntity);
                    response.Message = null;
                }
                else if (request.Action == PersistType.Update)
                {
                    var accountingObject = AccountingObjectDao.GetAccountingObjectByCodes(accountingObjectEntity.AccountingObjectCode);
                    if (accountingObject != null && accountingObject.Count > 0)
                    {
                        if (accountingObject.Where(w=>w.AccountingObjectId != accountingObjectEntity.AccountingObjectId).Count() > 0)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            response.Message = @"Mã đối tượng " + accountingObjectEntity.AccountingObjectCode + @" đã tồn tại !";
                            return response;
                        }
                    }
                    response.Message = AccountingObjectDao.UpdateAccountingObject(accountingObjectEntity);
                }
                else
                {
                    var accountEntityForDelete = AccountingObjectDao.GetAccountingObjectById(request.AccountingObjectId);
                    response.Message = AccountingObjectDao.DeleteAccountingObject(accountEntityForDelete);
                }
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }

            response.AccountingObjectId = accountingObjectEntity != null ? accountingObjectEntity.AccountingObjectId : 0;
            response.Acknowledge = response.Message != null ? AcknowledgeType.Failure : AcknowledgeType.Success;
            return response;
        }
    }
}

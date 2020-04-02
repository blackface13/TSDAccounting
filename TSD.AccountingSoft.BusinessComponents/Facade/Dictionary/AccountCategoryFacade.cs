/***********************************************************************
 * <copyright file="AccountCategoryFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   BangNC
 * Email:    BangNC@buca.vn
 * Website:
 * Create Date: Thursday, March 13, 2014
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
    /// Class AccountCategoryFacade.
    /// </summary>
    public class AccountCategoryFacade
    {
        /// <summary>
        /// The account category DAO
        /// </summary>
        private static readonly IAccountCategoryDao AccountCategoryDao = DataAccess.DataAccess.AccountCategoryDao;

        /// <summary>
        /// Gets the accounts.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public AccountCategoryResponse GetAccountCategories(AccountCategoryRequest request)
        {
            var response = new AccountCategoryResponse();

            if (request.LoadOptions.Contains("AccountCategories"))
            {
                if (request.LoadOptions.Contains("IsActive"))
                {
                    response.AccountCategories = request.LoadOptions.Contains("ForComboTree") ? AccountCategoryDao.GetAccountsForComboTree(request.AccountCategoryId) : AccountCategoryDao.GetAccountCategories();
                }
                else response.AccountCategories = AccountCategoryDao.GetAccountCategories();
            }
            if (request.LoadOptions.Contains("AccountCategory")) response.AccountCategory = AccountCategoryDao.GetAccountCategory(request.AccountCategoryId);

            return response;
        }

        /// <summary>
        /// Sets the account categories.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>AccountCategoryResponse.</returns>
        public AccountCategoryResponse SetAccountCategories(AccountCategoryRequest request)
        {
            var response = new AccountCategoryResponse();

            var accountCategoryEntity = request.AccountCategory;
            if (request.Action != PersistType.Delete)
            {
                if (!accountCategoryEntity.Validate())
                {
                    foreach (string error in accountCategoryEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
            }
            try
            {
                if (request.Action == PersistType.Insert)
                {
                    accountCategoryEntity.AccountCategoryId = AccountCategoryDao.InsertAccountCategory(accountCategoryEntity);
                    response.Message = null;
                }
                else if (request.Action == PersistType.Update) response.Message = AccountCategoryDao.UpdateAccountCategory(accountCategoryEntity);
                else
                {
                    var accountEntityForDelete = AccountCategoryDao.GetAccountCategory(request.AccountCategoryId);
                    response.Message = AccountCategoryDao.DeleteAccountCategory(accountEntityForDelete);
                }
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }

            response.AccountCategoryId = accountCategoryEntity != null ? accountCategoryEntity.AccountCategoryId : 0;
            response.Acknowledge = response.Message != null ? AcknowledgeType.Failure : AcknowledgeType.Success;
            return response;
        }
    }
}


/***********************************************************************
 * <copyright file="RefTypeFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 25 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Linq;
using System.Transactions;
using TSD.AccountingSoft.BusinessComponents.Messages.Dictionary;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Dictionary;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary;


namespace TSD.AccountingSoft.BusinessComponents.Facade.Dictionary
{
    /// <summary>
    /// RefTypeFacade
    /// </summary>
    public class RefTypeFacade
    {
        private static readonly IRefTypeDao RefTypeDao = DataAccess.DataAccess.RefTypeDao;

        /// <summary>
        /// Gets the reference types.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public RefTypeResponse GetRefTypes(RefTypeRequest request)
        {
            var response = new RefTypeResponse();

            if (request.LoadOptions.Contains("RefTypes"))
            {
                response.RefTypes = RefTypeDao.GetRefTypes();
            }

            if (request.LoadOptions.Contains("RefTypeSearch"))
            {
                response.RefTypes = RefTypeDao.GetRefTypeSearch();
            }
            return response;
        }
        public RefTypeEntity GetRefType(int refTypeId)
        {
            return RefTypeDao.GetRefType(refTypeId);
        }

        public RefTypeResponse UpdateRefType(RefTypeEntity refTypeEntity)
        {
            var response = new RefTypeResponse { Acknowledge = AcknowledgeType.Success };
            try
            {
                if (!refTypeEntity.Validate())
                {
                    foreach (var error in refTypeEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
                using (var scope = new TransactionScope())
                {
                    response.Message = RefTypeDao.UpdateRefType(refTypeEntity);
                    if (!string.IsNullOrEmpty(response.Message))
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        return response;
                    }
                    scope.Complete();
                }
                response.RefTypeId = refTypeEntity.RefTypeId;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                return response;
            }
        }
    }
}

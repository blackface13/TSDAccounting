/***********************************************************************
 * <copyright file="DBOptionFacade.cs" company="BUCA JSC">
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
using System.Transactions;
using TSD.AccountingSoft.BusinessComponents.Messages.Dictionary;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary;


namespace TSD.AccountingSoft.BusinessComponents.Facade.Dictionary
{
    /// <summary>
    /// DBOptionFacade
    /// </summary>
    public class DBOptionFacade
    {
        private static readonly IDBOptionDao DBOptionDao = DataAccess.DataAccess.DBOptionDao;

        /// <summary>
        /// Gets the database options.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public DBOptionResponse GetDBOptions(DBOptionRequest request)
        {
            var response = new DBOptionResponse();

            if (request.LoadOptions.Contains("DBOptions"))
            {
                if (request.LoadOptions.Contains("ValueType"))
                    response.DBOptions = DBOptionDao.GetDBOptionsByValueType(request.ValueType);
                else if (request.LoadOptions.Contains("IsSystem"))
                    response.DBOptions = DBOptionDao.GetDBOptionsBySystem(true);
                else
                    response.DBOptions = DBOptionDao.GetDBOptions();
            }
            if (request.LoadOptions.Contains("DBOption"))
                response.DBOption = DBOptionDao.GetDBOption(request.DBOptionId);

            return response;
        }

        public DBOptionResponse SetDBOptions(DBOptionRequest request)
        {
            var response = new DBOptionResponse();

            var dbOptionEntities = request.DBOptions;
            try
            {
                
                
                if (request.Action == PersistType.Update)
                {
                    if (request.DBOptions != null)
                    {
                        using (var scope = new TransactionScope())
                        {
                            foreach (var dbOption in dbOptionEntities)
                            {
                                if (!dbOption.Validate())
                                {
                                    foreach (var error in dbOption.ValidationErrors)
                                        response.Message += error + Environment.NewLine;
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    return response;
                                }
                                response.Message = DBOptionDao.UpdateDBOption(dbOption);
                                if (response.Message == null) continue;
                                response.Acknowledge = AcknowledgeType.Failure;
                                scope.Dispose();
                                return response;
                            }
                            scope.Complete();
                        }
                    }
                    else
                    {
                        var dbOptionEntity = request.DBOption;
                        if (!dbOptionEntity.Validate())
                        {
                            foreach (var error in dbOptionEntity.ValidationErrors)
                                response.Message += error + Environment.NewLine;
                            response.Acknowledge = AcknowledgeType.Failure;
                            return response;
                        }
                        response.Message = DBOptionDao.UpdateDBOption(dbOptionEntity);
                    }
                }
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }

            response.Acknowledge = response.Message != null ? AcknowledgeType.Failure : AcknowledgeType.Success;
            return response;
        }
    }
}

/***********************************************************************
 * <copyright file="AutoNumberFacade.cs" company="BUCA JSC">
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
    /// AutoNumberFacade
    /// </summary>
    public class AutoNumberFacade
    {
        private static readonly IAutoNumberDao AutoNumberDao = DataAccess.DataAccess.AutoNumberDao;

        /// <summary>
        /// Gets the automatic numbers.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public AutoNumberResponse GetAutoNumbers(AutoNumberRequest request)
        {
            var response = new AutoNumberResponse();

            if (request.LoadOptions.Contains("AutoNumber"))
            {
                if (request.LoadOptions.Contains("RefType"))
                    response.AutoNumber = AutoNumberDao.GetAutoNumberByRefType(request.RefTypeId);
            }
            if (request.LoadOptions.Contains("AutoNumbers"))
                response.AutoNumbers = AutoNumberDao.GetAutoNumbers();

            return response;
        }

        /// <summary>
        /// Sets the automatic businesses.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public AutoNumberResponse SetAutoNumbers(AutoNumberRequest request)
        {
            var response = new AutoNumberResponse();

            var autoNumberEntity = request.AutoNumber;
            if (request.Action != PersistType.Delete && autoNumberEntity != null)
            {
                if (!autoNumberEntity.Validate())
                {
                    foreach (var error in autoNumberEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
            }
            try
            {
                if (request.Action == PersistType.Update)
                {
                    if (request.AutoNumbers != null && request.AutoNumbers.Count > 0)
                    {
                        foreach (var autoNumber in request.AutoNumbers)
                        {
                            if (!autoNumber.Validate())
                            {
                                foreach (var error in autoNumber.ValidationErrors)
                                    response.Message += error + Environment.NewLine;
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }
                            response.Message = AutoNumberDao.UpdateAutoNumber(autoNumber);
                            if (response.Message == null) continue;
                            response.Acknowledge = AcknowledgeType.Failure;
                            return response;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }

            return response;
        }
    }
}

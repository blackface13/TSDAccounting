/***********************************************************************
 * <copyright file="AudittingLogFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 12 March 2014
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
    /// AudittingLogFacade
    /// </summary>
    public class AudittingLogFacade
    {
        private static readonly IAudittingLogDao AudittingLogDao = DataAccess.DataAccess.AudittingLogDao;

        /// <summary>
        /// Gets the auditting logs.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public AudittingLogResponse GetAudittingLogs(AudittingLogRequest request)
        {
            var response = new AudittingLogResponse();

            if (request.LoadOptions.Contains("AudittingLogs"))
                response.AudittingLogs = AudittingLogDao.GetAudittingLogs();

            return response;
        }

        public AudittingLogResponse SetAudittingLogs(AudittingLogRequest request)
        {
            var response = new AudittingLogResponse();

            var audittingLogEntity = request.AudittingLog;
            if (request.Action != PersistType.Delete)
            {
                if (!audittingLogEntity.Validate())
                {
                    foreach (var error in audittingLogEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
            }
            try
            {
                if (request.Action == PersistType.Insert)
                {
                    audittingLogEntity.EventId = AudittingLogDao.InsertAudittingLog(audittingLogEntity);
                    response.Message = null;
                }
                else if (request.Action == PersistType.Delete)
                {
                    var audittingLogForUpdate = AudittingLogDao.GetAudittingLog(request.EventId);
                    response.Message = AudittingLogDao.DeleteAudittingLog(audittingLogForUpdate);
                }
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
            response.EventId = audittingLogEntity != null ? audittingLogEntity.EventId : 0;
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
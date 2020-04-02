/***********************************************************************
 * <copyright file="FixedAssetHousingReportFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
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
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessComponents.Messages.Report;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Report;

namespace TSD.AccountingSoft.BusinessComponents.Facade.Report
{
    public class FixedAssetHousingReportFacade
    {
        /// <summary>
        /// The budget chapter DAO
        /// </summary>
        private static readonly IFixedAssetHousingReportDao FixedAssetHousingReportDao = DataAccess.DataAccess.FixedAssetHousingReportDao;

        /// <summary>
        /// Gets the budget chapters.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>FixedAssetHousingReportResponse.</returns>
        public FixedAssetHousingReportResponse GetFixedAssetHousingReports(FixedAssetHousingReportRequest request)
        {
            var response = new FixedAssetHousingReportResponse();
            if (request.LoadOptions.Contains("FixedAssetHousingReports"))
                response.FixedAssetHousingReports = request.LoadOptions.Contains("IsActive") ? FixedAssetHousingReportDao.GetFixedAssetHousingReportsByActive(true) : FixedAssetHousingReportDao.GetFixedAssetHousingReports();
            if (request.LoadOptions.Contains("FixedAssetHousingReport"))
                response.FixedAssetHousingReport = FixedAssetHousingReportDao.GetFixedAssetHousingReport(request.IsActive);
            return response;
        }

        /// <summary>
        /// Sets the budget chapters.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>FixedAssetHousingReportResponse.</returns>
        public FixedAssetHousingReportResponse SetFixedAssetHousingReports(FixedAssetHousingReportRequest request)
        {
            var response = new FixedAssetHousingReportResponse();
            var fixedAssetHousingReportEntity = request.FixedAssetHousingReport;
            
            try
            {
                if (request.Action == PersistType.Insert)
                {
                    fixedAssetHousingReportEntity.FixedAssetHousingReportId = FixedAssetHousingReportDao.InsertFixedAssetHousingReport(fixedAssetHousingReportEntity);
                    response.Message = null;
                }
                else if (request.Action == PersistType.Update)
                    response.Message = FixedAssetHousingReportDao.UpdateFixedAssetHousingReport(fixedAssetHousingReportEntity);
                else
                {
                    var fixedAssetHousingReportForUpdate = FixedAssetHousingReportDao.GetFixedAssetHousingReport(request.IsActive);
                    response.Message = FixedAssetHousingReportDao.DeleteFixedAssetHousingReport(fixedAssetHousingReportForUpdate);
                }
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
            response.FixedAssetHousingReportId = fixedAssetHousingReportEntity != null ? fixedAssetHousingReportEntity.FixedAssetHousingReportId : 0;
            response.Acknowledge = response.Message != null ? AcknowledgeType.Failure : AcknowledgeType.Success;
            return response;
        }
    }
}

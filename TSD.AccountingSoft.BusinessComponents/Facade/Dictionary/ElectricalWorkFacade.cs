/***********************************************************************
 * <copyright file="StockFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: Wednesday, March 12, 2014
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
    /// Class StockFacade.
    /// </summary>
    public class ElectricalWorkFacade
    {
        /// <summary>
        /// The stock DAO
        /// </summary>
        private static readonly IElectricalWorkDao ElectricalWorkDao = DataAccess.DataAccess.ElectricalWorkDao ;

        public ElectrialWorkResponse Gets(ElectrialWorkRequest request)
        {
            var response = new ElectrialWorkResponse();
            if (request.LoadOptions.Contains("ElectricalWork"))
            {
                response.ElectricalWorkEntity = ElectricalWorkDao.GetElectricalWork(request.PostedDate);
            }

           return response;
        }

        public ElectrialWorkResponse Sets(ElectrialWorkRequest request)
        {
            var response = new ElectrialWorkResponse();
            var electricalWorkEntity = request.ElectricalWorkEntity;
            if (request.Action != PersistType.Delete)
            {
                if (!electricalWorkEntity.Validate())
                {
                    foreach (string error in electricalWorkEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
            }
            try
             {
                response.Message = ElectricalWorkDao.UpdateInsertElectricalWork(electricalWorkEntity);
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

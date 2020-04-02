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
  public  class AutoNumberListFacade
    {
        private static readonly IAutoNumberListDao AutoNumberListDao = DataAccess.DataAccess.AutoNumberListDao;

        /// <summary>
        /// Gets the automatic numbers.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public AutoNumberListResponse GetAutoNumberLists(AutoNumberListRequest request)
        {
            var response = new AutoNumberListResponse();

            if (request.LoadOptions.Contains("AutoNumberList"))
            {
                    response.AutoNumberList = AutoNumberListDao.GetAutoNumberList(request.TableCode);
            }
            if (request.LoadOptions.Contains("AutoNumberLists"))
                response.AutoNumberLists = AutoNumberListDao.GetAutoNumberLists();

            return response;
        }

        /// <summary>
        /// Sets the automatic businesses.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public AutoNumberListResponse SetAutoNumberLists(AutoNumberListRequest request)
        {
            var response = new AutoNumberListResponse();

            var autoNumberEntity = request.AutoNumberList;
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
                    if (request.AutoNumberLists != null && request.AutoNumberLists.Count > 0)
                    {
                        foreach (var autoNumber in request.AutoNumberLists)
                        {
                            if (!autoNumber.Validate())
                            {
                                foreach (var error in autoNumber.ValidationErrors)
                                    response.Message += error + Environment.NewLine;
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }
                            response.Message = AutoNumberListDao.UpdateAutoNumberList(autoNumber);
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

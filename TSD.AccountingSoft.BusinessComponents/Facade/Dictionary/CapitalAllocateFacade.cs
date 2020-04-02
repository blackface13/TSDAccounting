/***********************************************************************
 * <copyright file="CapitalAllocateFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuanHM
 * Email:    Tuanhm@buca.vn
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
    /// Class CapitalAllocateFacade.
    /// </summary>
    public class CapitalAllocateFacade  
    {
        /// <summary>
        /// The capital allocate DAO
        /// </summary>
        private static readonly ICapitalAllocateDao CapitalAllocateDao = DataAccess.DataAccess.CapitalAllocateDao;

        /// <summary>
        /// Gets the capital allocates.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>CapitalAllocateResponse.</returns>
        public CapitalAllocateResponse GetCapitalAllocates(CapitalAllocateRequest request) 
        {
            var response = new CapitalAllocateResponse();

            if (request.LoadOptions.Contains("CapitalAllocates"))
            {
                if (request.LoadOptions.Contains("IsActive"))
                {
                    response.CapitalAllocates = CapitalAllocateDao.GetCapitalAllocatesByActive();
                }
                else 
                    response.CapitalAllocates = CapitalAllocateDao.GetCapitalAllocates(); 
            }
             if (request.LoadOptions.Contains("CapitalAllocateByDate"))
                  response.CapitalAllocates = CapitalAllocateDao.GetCapitalAllocatesByDate(request.FromDate,request.ToDate);
            
            if (request.LoadOptions.Contains("CapitalAllocate")) 
                response.CapitalAllocate = CapitalAllocateDao.GetCapitalAllocate(request.CapitalAllocateId);

            return response;
        }

        /// <summary>
        /// Sets the capital allocates.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>CapitalAllocateResponse.</returns>
        public CapitalAllocateResponse SetCapitalAllocates(CapitalAllocateRequest request) 
        {
            var response = new CapitalAllocateResponse();
            var capitalAllocateEntity = request.CapitalAllocate;
            if (request.Action != PersistType.Delete)
            {
                if (!capitalAllocateEntity.Validate())
                {
                    foreach (string error in capitalAllocateEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
            }
            try
            {
                if (request.Action == PersistType.Insert)
                {
                    var capitalAllocates = CapitalAllocateDao.GetCapitalAllocatesByCapitalAllocateCode(capitalAllocateEntity.CapitalAllocateCode);
                    if (capitalAllocates.Count > 0)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        response.Message = @"Mã phân bổ quỹ " + capitalAllocateEntity.CapitalAllocateCode + @" đã tồn tại !";
                        return response;
                    }
                    capitalAllocateEntity.CapitalAllocateId = CapitalAllocateDao.InsertCapitalAllocate(capitalAllocateEntity);
                    response.Message = null;
                }
                else if (request.Action == PersistType.Update) 
                    response.Message = CapitalAllocateDao.UpdateCapitalAllocate(capitalAllocateEntity);
                else
                {
                    var capitalAllocateForDelete = CapitalAllocateDao.GetCapitalAllocate(request.CapitalAllocateId);
                    response.Message = CapitalAllocateDao.DeleteCapitalAllocate(capitalAllocateForDelete);
                }
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
            response.CapitalAllocateId = capitalAllocateEntity != null ? capitalAllocateEntity.CapitalAllocateId : 0;
            response.Acknowledge = response.Message != null ? AcknowledgeType.Failure : AcknowledgeType.Success;
            return response;
        }
    }
}

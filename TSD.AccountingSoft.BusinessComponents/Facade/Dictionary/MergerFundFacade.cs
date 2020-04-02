/***********************************************************************
 * <copyright file="MergerFundFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   THODD
 * Email:    thodd@buca.vn
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
    /// Class MergerFundFacade.
    /// </summary>
    public class MergerFundFacade
    {
        /// <summary>
        /// The merger fund DAO
        /// </summary>
        private static readonly IMergerFundDao MergerFundDao = DataAccess.DataAccess.MergerFundDao;

        /// <summary>
        /// Gets the merger funds.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>MergerFundResponse.</returns>
        public MergerFundResponse GetMergerFunds(MergerFundRequest request)
        {
            var response = new MergerFundResponse();
            if (request.LoadOptions.Contains("MergerFunds"))
            {
                if (request.LoadOptions.Contains("IsActive"))
                    response.MergerFunds = MergerFundDao.GetMergerFundsByActive(true);
                else if (request.LoadOptions.Contains("NonActive"))
                    response.MergerFunds = MergerFundDao.GetMergerFundsByActive(false);
                else
                    response.MergerFunds = MergerFundDao.GetMergerFunds();
            }
            if (!request.LoadOptions.Contains("MergerFund"))
                return response;
            response.MergerFund = MergerFundDao.GetMergerFund(request.MergerFundId);

            return response;
        }

        /// <summary>
        /// Sets the merger funds.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>MergerFundResponse.</returns>
        public MergerFundResponse SetMergerFunds(MergerFundRequest request)
        {
            var response = new MergerFundResponse();
            var mergerFundEntity = request.MergerFund;
            if (request.Action != PersistType.Delete)
            {
                if (!mergerFundEntity.Validate())
                {
                    foreach (string error in mergerFundEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
            }
            try
            {
                if (request.Action == PersistType.Insert)
                {
                    mergerFundEntity.MergerFundId = MergerFundDao.InsertMergerFund(mergerFundEntity);
                    response.Message = null;
                }
                else if (request.Action == PersistType.Update)
                    response.Message = MergerFundDao.UpdateMergerFund(mergerFundEntity);
                else
                {
                    var mergerFundEntityForDelete = MergerFundDao.GetMergerFund(request.MergerFundId);
                    response.Message = MergerFundDao.DeleteMergerFund(mergerFundEntityForDelete);
                }
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
            response.MergerFundId = mergerFundEntity != null ? mergerFundEntity.MergerFundId : 0;
            response.Acknowledge = response.Message != null ? AcknowledgeType.Failure : AcknowledgeType.Success;
            return response;
        }
    }
}

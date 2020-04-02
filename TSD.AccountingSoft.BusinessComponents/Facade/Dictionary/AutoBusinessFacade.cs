/***********************************************************************
 * <copyright file="AutoBusinessFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 24 March 2014
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
    /// AutoBusinessFacade
    /// </summary>
    public class AutoBusinessFacade
    {
        private static readonly IAutoBusinessDao AutoBusinessDao = DataAccess.DataAccess.AutoBusinessDao;

        /// <summary>
        /// Gets the automatic businesses.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public AutoBusinessResponse GetAutoBusinesses(AutoBusinessRequest request)
        {
            var response = new AutoBusinessResponse();

            if (request.LoadOptions.Contains("AutoBusinesss"))
            {
                if (request.LoadOptions.Contains("IsActive"))
                    response.AutoBusinesses = AutoBusinessDao.GetAutoBusinesssByActive(true);
                else if (request.LoadOptions.Contains("RefType"))
                    response.AutoBusinesses = AutoBusinessDao.GetAutoBusinessByRefType(request.RefTypeId,request.IsActive);
                else response.AutoBusinesses = AutoBusinessDao.GetAutoBusinesss();

                response.AutoBusinesses = response.AutoBusinesses.OrderBy(o => o.AutoBusinessCode).ToList();
            }
            if (request.LoadOptions.Contains("AutoBusiness"))
                response.AutoBusiness = AutoBusinessDao.GetAutoBusiness(request.AutoBusinessId);

            return response;
        }

        /// <summary>
        /// Sets the automatic businesses.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public AutoBusinessResponse SetAutoBusinesses(AutoBusinessRequest request)
        {
            var response = new AutoBusinessResponse();

            var autoBusinessEntity = request.AutoBusiness;
            if (request.Action != PersistType.Delete)
            {
                if (!autoBusinessEntity.Validate())
                {
                    foreach (var error in autoBusinessEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
            }
            try
            {
                if (request.Action == PersistType.Insert)
                {
                    // đóng vào theo ý BA 
                    //var autoBusinesss = AutoBusinessDao.GetAutoBusinesssByAutoBusinessAccount(autoBusinessEntity.AutoBusinessCode);
                    //if (autoBusinesss.Count > 0)
                    //{
                    //    response.Acknowledge = AcknowledgeType.Failure;
                    //    response.Message = @"Mã số định khoản tự động " + autoBusinessEntity.AutoBusinessCode + @" đã tồn tại !";
                    //    return response;
                    //}
                    autoBusinessEntity.AutoBusinessId = AutoBusinessDao.InsertAutoBusiness(autoBusinessEntity);
                    response.Message = null;
                }
                else if (request.Action == PersistType.Update)
                    response.Message = AutoBusinessDao.UpdateAutoBusiness(autoBusinessEntity);
                else
                {
                    var autoBusinessForUpdate = AutoBusinessDao.GetAutoBusiness(request.AutoBusinessId);
                    response.Message = AutoBusinessDao.DeleteAutoBusiness(autoBusinessForUpdate);
                }
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
            response.AutoBusinessId = autoBusinessEntity != null ? autoBusinessEntity.AutoBusinessId : 0;
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

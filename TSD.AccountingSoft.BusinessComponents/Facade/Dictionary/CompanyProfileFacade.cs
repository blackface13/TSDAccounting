/***********************************************************************
 * <copyright file="CompanyProfileFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Thursday, September 4, 2014
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
    /// CompanyProfileFacade
    /// </summary>
    public class CompanyProfileFacade
    {
        private static readonly ICompanyProfileDao CompanyProfileDao = DataAccess.DataAccess.CompanyProfileDao;

        /// <summary>
        /// Gets the companyProfiles.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public CompanyProfileResponse GetCompanyProfiles(CompanyProfileRequest request)
        {
            var response = new CompanyProfileResponse();

            if (request.LoadOptions.Contains("CompanyProfiles"))
            {
                response.CompanyProfiles = request.LoadOptions.Contains("IsActive") ? CompanyProfileDao.GetCompanyProfilesByActive(true) : CompanyProfileDao.GetCompanyProfiles();
            }
            if (request.LoadOptions.Contains("CompanyProfile")) 
                response.CompanyProfile = CompanyProfileDao.GetCompanyProfile(request.CompanyProfileId);

            return response;
        }

        /// <summary>
        /// Sets the companyProfiles.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public CompanyProfileResponse SetCompanyProfiles(CompanyProfileRequest request)
        {
            var response = new CompanyProfileResponse();

            var companyProfileEntity = request.CompanyProfile;
            if (request.Action != PersistType.Delete)
            {
                if (!companyProfileEntity.Validate())
                {
                    foreach (var error in companyProfileEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
            }
            try
            {
                if (request.Action == PersistType.Insert)
                {
                    companyProfileEntity.LineId = CompanyProfileDao.InsertCompanyProfile(companyProfileEntity);
                    response.Message = null;
                }
                else if (request.Action == PersistType.Update) 
                    response.Message = CompanyProfileDao.UpdateCompanyProfile(companyProfileEntity);
                else
                {
                    var companyProfileForUpdate = CompanyProfileDao.GetCompanyProfile(request.CompanyProfileId);
                    response.Message = CompanyProfileDao.DeleteCompanyProfile(companyProfileForUpdate);
                }
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
            response.CompanyProfileId = companyProfileEntity != null ? 1 : 0;
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

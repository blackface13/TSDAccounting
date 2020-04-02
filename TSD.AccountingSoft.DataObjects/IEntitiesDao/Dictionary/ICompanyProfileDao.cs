/***********************************************************************
 * <copyright file="ICompanyProfileDao.cs" company="BUCA JSC">
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
using System.Collections.Generic;
using TSD.AccountingSoft.BusinessEntities.Dictionary;


namespace TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary
{
    /// <summary>
    /// ICompanyProfileDao
    /// </summary>
    public interface ICompanyProfileDao
    {
        /// <summary>
        /// Gets the companyProfile.
        /// </summary>
        /// <param name="companyProfileId">The companyProfile identifier.</param>
        /// <returns></returns>
        CompanyProfileEntity GetCompanyProfile(int companyProfileId);

        /// <summary>
        /// Gets the companyProfiles.
        /// </summary>
        /// <returns></returns>
        List<CompanyProfileEntity> GetCompanyProfiles();

        /// <summary>
        /// Gets the companyProfiles by active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <returns></returns>
        List<CompanyProfileEntity> GetCompanyProfilesByActive(bool isActive);

        /// <summary>
        /// Inserts the companyProfile.
        /// </summary>
        /// <param name="companyProfile">The companyProfile.</param>
        /// <returns></returns>
        int InsertCompanyProfile(CompanyProfileEntity companyProfile);

        /// <summary>
        /// Updates the companyProfile.
        /// </summary>
        /// <param name="companyProfile">The companyProfile.</param>
        /// <returns></returns>
        string UpdateCompanyProfile(CompanyProfileEntity companyProfile);

        /// <summary>
        /// Deletes the companyProfile.
        /// </summary>
        /// <param name="companyProfile">The companyProfile.</param>
        /// <returns></returns>
        string DeleteCompanyProfile(CompanyProfileEntity companyProfile);
    }
}

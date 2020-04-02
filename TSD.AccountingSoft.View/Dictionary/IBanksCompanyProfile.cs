/***********************************************************************
 * <copyright file="IBanksCompanyProfile.cs" company="BUCA JSC">
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
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using System.Collections.Generic;


namespace TSD.AccountingSoft.View.Dictionary
{
    /// <summary>
    /// ICompanyProfilesView
    /// </summary>
    public interface ICompanyProfilesView : IView
    {
        /// <summary>
        /// Sets the companyProfiles.
        /// </summary>
        /// <value>
        /// The companyProfiles.
        /// </value>
        IList<CompanyProfileModel> CompanyProfiles { set; }
    }
}
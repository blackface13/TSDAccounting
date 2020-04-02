/***********************************************************************
 * <copyright file="CompanyProfileResponse.cs" company="BUCA JSC">
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
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Dictionary;


namespace TSD.AccountingSoft.BusinessComponents.Messages.Dictionary
{
    /// <summary>
    /// BankResponse
    /// </summary>
    public class CompanyProfileResponse : ResponseBase
    {
        /// <summary>
        /// The banks
        /// </summary>
        public IList<CompanyProfileEntity> CompanyProfiles;

        /// <summary>
        /// The bank
        /// </summary>
        public CompanyProfileEntity CompanyProfile;

        /// <summary>
        /// Gets or sets the bank identifier.
        /// </summary>
        /// <value>
        /// The bank identifier.
        /// </value>
        public int CompanyProfileId { get; set; }
    }
}

/***********************************************************************
 * <copyright file="UserProfileResponse.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 30 May 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.System;


namespace TSD.AccountingSoft.BusinessComponents.Messages.System
{
    /// <summary>
    /// UserProfileResponse
    /// </summary>
    public class UserProfileResponse : ResponseBase
    {
        /// <summary>
        /// The roles
        /// </summary>
        public IList<UserProfileEntity> UserProfiles;

        /// <summary>
        /// The role
        /// </summary>
        public UserProfileEntity UserProfile;

        /// <summary>
        /// Gets or sets the role identifier.
        /// </summary>
        /// <value>
        /// The role identifier.
        /// </value>
        public int UserProfileId { get; set; }
    }
}

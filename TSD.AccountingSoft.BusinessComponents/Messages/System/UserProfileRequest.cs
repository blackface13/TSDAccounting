/***********************************************************************
 * <copyright file="UserProfileRequest.cs" company="BUCA JSC">
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

using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.System;


namespace TSD.AccountingSoft.BusinessComponents.Messages.System
{
    /// <summary>
    /// UserProfileRequest
    /// </summary>
    public class UserProfileRequest : RequestBase
    {
        /// <summary>
        /// Gets or sets the userProfile identifier.
        /// </summary>
        /// <value>
        /// The userProfile identifier.
        /// </value>
        public int UserProfileId { get; set; }

        /// <summary>
        /// Gets or sets the name of the user profile.
        /// </summary>
        /// <value>
        /// The name of the user profile.
        /// </value>
        public string UserProfileName { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the old password.
        /// </summary>
        /// <value>
        /// The old password.
        /// </value>
        public string OldPassword { get; set; }

        /// <summary>
        /// The userProfile
        /// </summary>
        public UserProfileEntity UserProfile;

        /// <summary>
        /// Gets or sets a value indicating whether [is active].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is active]; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }
    }
}

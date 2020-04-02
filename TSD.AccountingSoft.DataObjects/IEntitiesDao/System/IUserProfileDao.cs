/***********************************************************************
 * <copyright file="IUserProfileDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 28 May 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using TSD.AccountingSoft.BusinessEntities.System;


namespace TSD.AccountingSoft.DataAccess.IEntitiesDao.System
{
    /// <summary>
    /// IUserProfileDao
    /// </summary>
    public interface IUserProfileDao
    {
        /// <summary>
        /// Gets the userProfiles.
        /// </summary>
        /// <returns></returns>
        List<UserProfileEntity> GetUserProfiles();

        /// <summary>
        /// Gets the userProfiles.
        /// </summary>
        /// <returns></returns>
        List<UserProfileEntity> GetUserProfiles(bool isActive);

        /// <summary>
        /// Gets the userProfile.
        /// </summary>
        /// <param name="userProfileId">The userProfile identifier.</param>
        /// <returns></returns>
        UserProfileEntity GetUserProfile(int userProfileId);

        /// <summary>
        /// Gets the name of the user profile by user profile.
        /// </summary>
        /// <param name="userProfileName">Name of the user profile.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        UserProfileEntity GetUserProfileByUserProfileName(string userProfileName, string password);

        /// <summary>
        /// Inserts the userProfile.
        /// </summary>
        /// <param name="userProfile">The userProfile.</param>
        /// <returns></returns>
        int InsertUserProfile(UserProfileEntity userProfile);

        /// <summary>
        /// Updates the userProfile.
        /// </summary>
        /// <param name="userProfile">The userProfile.</param>
        /// <returns></returns>
        string UpdateUserProfile(UserProfileEntity userProfile);

        /// <summary>
        /// Deletes the userProfile.
        /// </summary>
        /// <param name="userProfile">The userProfile.</param>
        /// <returns></returns>
        string DeleteUserProfile(UserProfileEntity userProfile);
    }
}

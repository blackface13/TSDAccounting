/***********************************************************************
 * <copyright file="SqlServerUserProfileDao.cs" company="BUCA JSC">
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

using System;
using System.Collections.Generic;
using System.Data;
using TSD.AccountingSoft.BusinessEntities.System;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.System;
using TSD.AccountingSoft.DataHelpers;
using TSD.AccountingSoft.DataHelpers.Encryption;


namespace TSD.AccountingSoft.DataAccess.SqlServer.System
{
    /// <summary>
    /// SqlServerUserProfileDao
    /// </summary>
    public class SqlServerUserProfileDao : IUserProfileDao
    {
        /// <summary>
        /// Gets the userProfiles.
        /// </summary>
        /// <returns></returns>
        public List<UserProfileEntity> GetUserProfiles()
        {
            const string procedures = @"uspGet_All_UserProfile";

            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Gets the userProfiles.
        /// </summary>
        /// <param name="isActive"></param>
        /// <returns></returns>
        public List<UserProfileEntity> GetUserProfiles(bool isActive)
        {
            const string procedures = @"uspGet_UserProfile_ByIsActive";

            object[] parms = { "@IsActive", isActive };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the userProfile.
        /// </summary>
        /// <param name="userProfileId">The userProfile identifier.</param>
        /// <returns></returns>
        public UserProfileEntity GetUserProfile(int userProfileId)
        {
            const string procedures = @"uspGet_UserProfile_ByID";

            object[] parms = { "@UserProfileID", userProfileId };
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        /// Gets the name of the user profile by user profile.
        /// </summary>
        /// <param name="userProfileName">Name of the user profile.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public UserProfileEntity GetUserProfileByUserProfileName(string userProfileName, string password)
        {
            const string procedures = @"uspGet_UserProfile_ByUserProfileName";

            object[] parms = { "@UserProfileName", userProfileName, "@Password", password == null ? null : MD5Helper.GetMd5Hash(password) };
            return Db.Read(procedures, true, Make, parms);
        }

        /// <summary>
        /// Inserts the userProfile.
        /// </summary>
        /// <param name="userProfile">The userProfile.</param>
        /// <returns></returns>
        public int InsertUserProfile(UserProfileEntity userProfile)
        {
            const string sql = @"uspInsert_UserProfile";
            return Db.Insert(sql, true, Take(userProfile));
        }

        /// <summary>
        /// Updates the userProfile.
        /// </summary>
        /// <param name="userProfile">The userProfile.</param>
        /// <returns></returns>
        public string UpdateUserProfile(UserProfileEntity userProfile)
        {
            const string sql = @"uspUpdate_UserProfile";
            return Db.Update(sql, true, Take(userProfile));
        }

        /// <summary>
        /// Deletes the userProfile.
        /// </summary>
        /// <param name="userProfile">The userProfile.</param>
        /// <returns></returns>
        public string DeleteUserProfile(UserProfileEntity userProfile)
        {
            const string sql = @"uspDelete_UserProfile";

            object[] parms = { "@UserProfileID", userProfile.UserProfileId };
            return Db.Delete(sql, true, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, UserProfileEntity> Make = reader =>
            new UserProfileEntity
            {
                UserProfileId = reader["UserProfileID"].AsInt(),
                UserProfileName = reader["UserProfileName"].AsString(),
                FullName = reader["FullName"].AsString(),
                Password = reader["Password"].AsString(),
                Email = reader["Email"].AsString(),
                CreateDate = reader["CreateDate"].AsDateTime(),
                IsActive = reader["IsActive"].AsBool(),
                Description = reader["Description"].AsString()
            };

        /// <summary>
        /// Takes the specified userProfile.
        /// </summary>
        /// <param name="userProfile">The userProfile.</param>
        /// <returns></returns>
        private object[] Take(UserProfileEntity userProfile)
        {
            return new object[]  
            {
                @"UserProfileID", userProfile.UserProfileId,
                @"UserProfileName", userProfile.UserProfileName,
                @"FullName", userProfile.FullName,
                @"Password", userProfile.Password == null ? null :  MD5Helper.GetMd5Hash(userProfile.Password),
                @"Email", userProfile.Email,
                @"CreateDate", userProfile.CreateDate,
                @"Description", userProfile.Description,
                @"IsActive", userProfile.IsActive
            };
        }
    }
}

/***********************************************************************
 * <copyright file="UserProfilePresenter.cs" company="BUCA JSC">
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

using TSD.AccountingSoft.Model.BusinessObjects.System;
using TSD.AccountingSoft.View.System;


namespace TSD.AccountingSoft.Presenter.System.UserProfile
{
    /// <summary>
    /// class UserProfilePresenter
    /// </summary>
    public class UserProfilePresenter : Presenter<IUserProfileView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserProfilePresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public UserProfilePresenter(IUserProfileView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays the specified userProfile identifier.
        /// </summary>
        /// <param name="userProfileId">The userProfile identifier.</param>
        public void Display(string userProfileId)
        {
            if (userProfileId == null) { View.UserProfileId = 0; return; }

            var userProfile = Model.GetUserProfile(int.Parse(userProfileId));

            View.UserProfileId = userProfile.UserProfileId;
            View.UserProfileName = userProfile.UserProfileName;
            View.FullName = userProfile.FullName;
            View.Password = userProfile.Password;
            View.IsActive = userProfile.IsActive;
            View.Email = userProfile.Email;
            View.CreateDate = userProfile.CreateDate;
            View.Description = userProfile.Description;
        }

        /// <summary>
        /// Displays the name of the by user profile.
        /// </summary>
        /// <param name="userProfileName">Name of the user profile.</param>
        /// <param name="password">The password.</param>
        public void DisplayByUserProfileName(string userProfileName, string password)
        {
            if (userProfileName == null)
                return;

            var userProfile = Model.GetUserProfileByUserProfileName(userProfileName, password);

            View.UserProfileId = userProfile.UserProfileId;
            View.UserProfileName = userProfile.UserProfileName;
            View.FullName = userProfile.FullName;
            View.Password = userProfile.Password;
            View.IsActive = userProfile.IsActive;
            View.Email = userProfile.Email;
            View.CreateDate = userProfile.CreateDate;
            View.Description = userProfile.Description;
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        public int Save()
        {
            var userProfile = new UserProfileModel
            {
                UserProfileId = View.UserProfileId,
                UserProfileName = View.UserProfileName,
                FullName = View.FullName,
                Password = View.Password,
                IsActive = View.IsActive,
                Email = View.Email,
                CreateDate = View.CreateDate,
                Description = View.Description
            };

            return View.UserProfileId == 0 ? Model.AddUserProfile(userProfile) : Model.UpdateUserProfile(userProfile);
        }

        /// <summary>
        /// Deletes the specified userProfile identifier.
        /// </summary>
        /// <param name="userProfileId">The userProfile identifier.</param>
        /// <returns></returns>
        public int Delete(int userProfileId)
        {
            return Model.DeleteUserProfile(userProfileId);
        }

        /// <summary>
        /// Changes the password.
        /// </summary>
        /// <param name="userProfileName">Name of the user profile.</param>
        /// <param name="oldPasword">The old pasword.</param>
        /// <param name="newPassword">The new password.</param>
        /// <returns></returns>
        public int ChangePassword(string userProfileName, string oldPasword, string newPassword)
        {
            return Model.ChangePassword(userProfileName, oldPasword, newPassword);
        }
    }
}

/***********************************************************************
 * <copyright file="UserProfilesPresenter.cs" company="BUCA JSC">
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

using TSD.AccountingSoft.View.System;


namespace TSD.AccountingSoft.Presenter.System.UserProfile
{
    /// <summary>
    /// UserProfilesPresenter
    /// </summary>
    public class UserProfilesPresenter: Presenter<IUserProfilesView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserProfilesPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public UserProfilesPresenter(IUserProfilesView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            View.UserProfiles = Model.GetUserProfiles();
        }

        /// <summary>
        /// Displays the active.
        /// </summary>
        public void Display(bool isActive)
        {
            View.UserProfiles = Model.GetUserProfiles(isActive);
        }
    }
}

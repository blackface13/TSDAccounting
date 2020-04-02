/***********************************************************************
 * <copyright file="PermissionsPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 26 May 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using TSD.AccountingSoft.View.System;


namespace TSD.AccountingSoft.Presenter.System.Permission
{
    /// <summary>
    /// class PermissionsPresenter
    /// </summary>
    public class PermissionsPresenter : Presenter<IPermissionsView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PermissionsPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public PermissionsPresenter(IPermissionsView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            View.Permissions = Model.GetPermissions();
        }

        /// <summary>
        /// Displays the active.
        /// </summary>
        public void Display(bool isActive)
        {
            View.Permissions = Model.GetPermissions(isActive);
        }
    }
}
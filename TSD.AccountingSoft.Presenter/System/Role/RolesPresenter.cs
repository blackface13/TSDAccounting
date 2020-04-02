/***********************************************************************
 * <copyright file="RolesPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 22 May 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using TSD.AccountingSoft.View.System;


namespace TSD.AccountingSoft.Presenter.System.Role
{
    /// <summary>
    /// class RolesPresenter
    /// </summary>
    public class RolesPresenter : Presenter<IRolesView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RolesPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public RolesPresenter(IRolesView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            View.Roles = Model.GetRoles();
        }

        /// <summary>
        /// Displays the active.
        /// </summary>
        public void Display(bool isActive)
        {
            View.Roles = Model.GetRoles(isActive);
        }
    }
}

/***********************************************************************
 * <copyright file="RolePresenter.cs" company="BUCA JSC">
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

using TSD.AccountingSoft.Model.BusinessObjects.System;
using TSD.AccountingSoft.View.System;


namespace TSD.AccountingSoft.Presenter.System.Role
{
    /// <summary>
    /// class RolePresenter
    /// </summary>
    public class RolePresenter : Presenter<IRoleView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RolePresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public RolePresenter(IRoleView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays the specified role identifier.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        public void Display(string roleId)
        {
            if (roleId == null) { View.RoleId = 0; return; }

            var role = Model.GetRole(int.Parse(roleId));

            View.RoleId = role.RoleId;
            View.RoleName = role.RoleName;
            View.Description = role.Description;
            View.IsActive = role.IsActive;
            View.RoleSiteModels = role.RoleSiteModels;
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        public int Save()
        {
            var role = new RoleModel
            {
                RoleId = View.RoleId,
                RoleName = View.RoleName,
                Description = View.Description,
                IsActive = View.IsActive,
                RoleSiteModels = View.RoleSiteModels
            };

            return View.RoleId == 0 ? Model.AddRole(role) : Model.UpdateRole(role);
        }

        /// <summary>
        /// Deletes the specified role identifier.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <returns></returns>
        public int Delete(int roleId)
        {
            return Model.DeleteRole(roleId);
        }
    }
}

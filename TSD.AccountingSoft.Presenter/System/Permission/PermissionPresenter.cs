/***********************************************************************
 * <copyright file="PermissionPresenter.cs" company="BUCA JSC">
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

using TSD.AccountingSoft.Model.BusinessObjects.System;
using TSD.AccountingSoft.View.System;


namespace TSD.AccountingSoft.Presenter.System.Permission
{
    /// <summary>
    /// class PermissionPresenter
    /// </summary>
    public class PermissionPresenter : Presenter<IPermissionView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PermissionPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public PermissionPresenter(IPermissionView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays the specified permission identifier.
        /// </summary>
        /// <param name="permissionId">The permission identifier.</param>
        public void Display(string permissionId)
        {
            if (permissionId == null) { View.PermissionId = 0; return; }

            var permission = Model.GetPermission(int.Parse(permissionId));

            View.PermissionId = permission.PermissionId;
            View.PermissionCode = permission.PermissionCode;
            View.PermissionName = permission.PermissionName;
            View.Description = permission.Description;
            View.IsActive = permission.IsActive;
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        public int Save()
        {
            var permission = new PermissionModel
            {
                PermissionId = View.PermissionId,
                PermissionCode = View.PermissionCode,
                PermissionName = View.PermissionName,
                Description = View.Description,
                IsActive = View.IsActive
            };

            return View.PermissionId == 0 ? Model.AddPermission(permission) : Model.UpdatePermission(permission);
        }

        /// <summary>
        /// Deletes the specified permission identifier.
        /// </summary>
        /// <param name="permissionId">The permission identifier.</param>
        /// <returns></returns>
        public int Delete(int permissionId)
        {
            return Model.DeletePermission(permissionId);
        }
    }
}

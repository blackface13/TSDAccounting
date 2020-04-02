/***********************************************************************
 * <copyright file="IPermissionView.cs" company="BUCA JSC">
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

namespace TSD.AccountingSoft.View.System
{
    /// <summary>
    /// IPermissionView
    /// </summary>
    public interface IPermissionView : IView
    {
        /// <summary>
        /// Gets or sets the permission identifier.
        /// </summary>
        /// <value>
        /// The permission identifier.
        /// </value>
        int PermissionId { get; set; }

        /// <summary>
        /// Gets or sets the permission code.
        /// </summary>
        /// <value>
        /// The permission code.
        /// </value>
        string PermissionCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the permission.
        /// </summary>
        /// <value>
        /// The name of the permission.
        /// </value>
        string PermissionName { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is active].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is active]; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; set; }
    }
}

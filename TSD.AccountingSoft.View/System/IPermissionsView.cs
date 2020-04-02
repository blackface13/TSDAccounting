/***********************************************************************
 * <copyright file="IPermissionsView.cs" company="BUCA JSC">
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

using System.Collections.Generic;
using TSD.AccountingSoft.Model.BusinessObjects.System;


namespace TSD.AccountingSoft.View.System
{
    /// <summary>
    /// IPermissionsView
    /// </summary>
    public interface IPermissionsView : IView
    {
        /// <summary>
        /// Sets the permissions.
        /// </summary>
        /// <value>
        /// The permissions.
        /// </value>
        IList<PermissionModel> Permissions { set; }
    }
}

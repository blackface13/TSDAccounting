/***********************************************************************
 * <copyright file="IRolesView.cs" company="BUCA JSC">
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

using System.Collections.Generic;
using TSD.AccountingSoft.Model.BusinessObjects.System;


namespace TSD.AccountingSoft.View.System
{
    /// <summary>
    /// IRolesView
    /// </summary>
    public interface IRolesView : IView
    {
        /// <summary>
        /// Sets the roles.
        /// </summary>
        /// <value>
        /// The roles.
        /// </value>
        IList<RoleModel> Roles { set; }
    }
}

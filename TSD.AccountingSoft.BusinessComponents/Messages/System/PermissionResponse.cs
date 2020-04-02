/***********************************************************************
 * <copyright file="PermissionResponse.cs" company="BUCA JSC">
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
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.System;


namespace TSD.AccountingSoft.BusinessComponents.Messages.System
{
    /// <summary>
    /// class PermissionResponse
    /// </summary>
    public class PermissionResponse : ResponseBase
    {
        /// <summary>
        /// The permissions
        /// </summary>
        public IList<PermissionEntity> Permissions;

        /// <summary>
        /// The permission
        /// </summary>
        public PermissionEntity Permission;

        /// <summary>
        /// Gets or sets the permission identifier.
        /// </summary>
        /// <value>
        /// The permission identifier.
        /// </value>
        public int PermissionId { get; set; }
    }
}

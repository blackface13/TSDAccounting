/***********************************************************************
 * <copyright file="PermissionSiteModel.cs" company="BUCA JSC">
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

namespace TSD.AccountingSoft.Model.BusinessObjects.System
{
    /// <summary>
    /// PermissionSiteModel
    /// </summary>
    public class PermissionSiteModel
    {
        /// <summary>
        /// Gets or sets the permission site identifier.
        /// </summary>
        /// <value>
        /// The permission site identifier.
        /// </value>
        public int PermissionSiteId { get; set; }

        /// <summary>
        /// Gets or sets the site identifier.
        /// </summary>
        /// <value>
        /// The site identifier.
        /// </value>
        public int SiteId { get; set; }

        /// <summary>
        /// Gets or sets the permission identifier.
        /// </summary>
        /// <value>
        /// The permission identifier.
        /// </value>
        public int PermissionId { get; set; }
    }
}

/***********************************************************************
 * <copyright file="RoleSiteEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 27 May 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

namespace TSD.AccountingSoft.BusinessEntities.System
{
    /// <summary>
    /// RoleSiteEntity
    /// </summary>
    public class RoleSiteEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoleSiteEntity"/> class.
        /// </summary>
        public RoleSiteEntity()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleSiteEntity"/> class.
        /// </summary>
        /// <param name="roleSiteId">The role site identifier.</param>
        /// <param name="roleId">The role identifier.</param>
        /// <param name="siteId">The site identifier.</param>
        /// <param name="permissionId">The permission identifier.</param>
        public RoleSiteEntity(int roleSiteId, int roleId, int siteId, int? permissionId)
        {
            RoleSiteId = roleSiteId;
            RoleId = roleId;
            SiteId = siteId;
            PermissionId = permissionId;
        }

        /// <summary>
        /// Gets or sets the role site identifier.
        /// </summary>
        /// <value>
        /// The role site identifier.
        /// </value>
        public int RoleSiteId { get; set; }

        /// <summary>
        /// Gets or sets the role identifier.
        /// </summary>
        /// <value>
        /// The role identifier.
        /// </value>
        public int RoleId { get; set; }

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
        public int? PermissionId { get; set; }
    }
}

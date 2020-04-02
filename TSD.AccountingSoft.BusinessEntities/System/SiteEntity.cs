/***********************************************************************
 * <copyright file="SiteEntity.cs" company="BUCA JSC">
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
using TSD.AccountingSoft.BusinessEntities.BusinessRules;


namespace TSD.AccountingSoft.BusinessEntities.System
{
    /// <summary>
    /// SiteEntity
    /// </summary>
    public class SiteEntity : BusinessEntities
    {
        public SiteEntity()
        {
            AddRule(new ValidateRequired("SiteCode"));
            AddRule(new ValidateRequired("SiteName"));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SiteEntity"/> class.
        /// </summary>
        /// <param name="siteId">The site identifier.</param>
        /// <param name="siteCode">The site code.</param>
        /// <param name="siteName">Name of the site.</param>
        /// <param name="description">The description.</param>
        /// <param name="parentId">The parent identifier.</param>
        /// <param name="order">The order.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        public SiteEntity(int siteId, string siteCode, string siteName, string description, int? parentId, int order,
            bool isActive)
            : this()
        {
            SiteId = siteId;
            SiteCode = siteCode;
            SiteName = siteName;
            Description = description;
            ParentId = parentId;
            Order = order;
            IsActive = isActive;
        }

        /// <summary>
        /// Gets or sets the site identifier.
        /// </summary>
        /// <value>
        /// The site identifier.
        /// </value>
        public int SiteId { get; set; }

        /// <summary>
        /// Gets or sets the site code.
        /// </summary>
        /// <value>
        /// The site code.
        /// </value>
        public string SiteCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the site.
        /// </summary>
        /// <value>
        /// The name of the site.
        /// </value>
        public string SiteName { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the parent identifier.
        /// </summary>
        /// <value>
        /// The parent identifier.
        /// </value>
        public int? ParentId { get; set; }

        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        /// <value>
        /// The order.
        /// </value>
        public int Order { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is active].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is active]; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the permission site entities.
        /// </summary>
        /// <value>
        /// The permission site entities.
        /// </value>
        public IList<PermissionSiteEntity> PermissionSiteEntities { get; set; }
    }
}

/***********************************************************************
 * <copyright file="PermissionEntity.cs" company="BUCA JSC">
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

using TSD.AccountingSoft.BusinessEntities.BusinessRules;


namespace TSD.AccountingSoft.BusinessEntities.System
{
    /// <summary>
    /// PermissionEntity
    /// </summary>
    public class PermissionEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PermissionEntity"/> class.
        /// </summary>
        public PermissionEntity()
        {
            AddRule(new ValidateRequired("PermissionCode"));
            AddRule(new ValidateRequired("PermissionName"));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PermissionEntity"/> class.
        /// </summary>
        /// <param name="permissionId">The permission identifier.</param>
        /// <param name="permissionCode">The permission code.</param>
        /// <param name="permissionName">Name of the permission.</param>
        /// <param name="description">The description.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        public PermissionEntity(int permissionId, string permissionCode, string permissionName, string description, bool isActive)
            : this()
        {
            PermissionId = permissionId;
            PermissionCode = permissionCode;
            PermissionName = permissionName;
            Description = description;
            IsActive = isActive;
        }

        /// <summary>
        /// Gets or sets the permission identifier.
        /// </summary>
        /// <value>
        /// The permission identifier.
        /// </value>
        public int PermissionId { get; set; }

        /// <summary>
        /// Gets or sets the permission code.
        /// </summary>
        /// <value>
        /// The permission code.
        /// </value>
        public string PermissionCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the permission.
        /// </summary>
        /// <value>
        /// The name of the permission.
        /// </value>
        public string PermissionName { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is active].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is active]; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }
    }
}

/***********************************************************************
 * <copyright file="GeneralPaymentDetailEstimateEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 10 May 2014
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
    /// RoleEntity
    /// </summary>
    public class RoleEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoleEntity"/> class.
        /// </summary>
        public RoleEntity()
        {
            AddRule(new ValidateRequired("RoleName"));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleEntity"/> class.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <param name="roleName">Name of the role.</param>
        /// <param name="description">The description.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        public RoleEntity(int roleId, string roleName, string description, bool isActive)
        {
            RoleId = roleId;
            RoleName = roleName;
            Description = description;
            IsActive = isActive;
        }

        /// <summary>
        /// Gets or sets the role identifier.
        /// </summary>
        /// <value>
        /// The role identifier.
        /// </value>
        public int RoleId { get; set; }

        /// <summary>
        /// Gets or sets the name of the role.
        /// </summary>
        /// <value>
        /// The name of the role.
        /// </value>
        public string RoleName { get; set; }

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

        /// <summary>
        /// Gets or sets the role site entities.
        /// </summary>
        /// <value>
        /// The role site entities.
        /// </value>
        public IList<RoleSiteEntity> RoleSiteEntities { get; set; }
    }
}
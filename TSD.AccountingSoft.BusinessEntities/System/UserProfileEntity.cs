/***********************************************************************
 * <copyright file="UserProfileEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 28 May 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using TSD.AccountingSoft.BusinessEntities.BusinessRules;


namespace TSD.AccountingSoft.BusinessEntities.System
{
    /// <summary>
    /// UserProfileEntity
    /// </summary>
    public class UserProfileEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserProfileEntity"/> class.
        /// </summary>
        public UserProfileEntity()
        {
            AddRule(new ValidateRequired("UserProfileName"));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserProfileEntity"/> class.
        /// </summary>
        /// <param name="userProfileId">The user profile identifier.</param>
        /// <param name="userProfileName">Name of the user profile.</param>
        /// <param name="fullName">The full name.</param>
        /// <param name="password">The password.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <param name="email">The email.</param>
        /// <param name="createDate">The create date.</param>
        /// <param name="description">The description.</param>
        public UserProfileEntity(int userProfileId, string userProfileName, string fullName, string password, bool isActive, string email, DateTime? createDate, string description)
        {
            UserProfileId = userProfileId;
            UserProfileName = userProfileName;
            FullName = fullName;
            Password = password;
            IsActive = isActive;
            Email = email;
            CreateDate = createDate;
            Description = description;
        }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public int UserProfileId { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public string UserProfileName { get; set; }

        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        /// <value>
        /// The full name.
        /// </value>
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is active].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is active]; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the create date.
        /// </summary>
        /// <value>
        /// The create date.
        /// </value>
        public DateTime? CreateDate { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }
    }
}

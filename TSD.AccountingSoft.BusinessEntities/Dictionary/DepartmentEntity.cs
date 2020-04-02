/***********************************************************************
 * <copyright file="DepartmentEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 07 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using TSD.AccountingSoft.BusinessEntities.BusinessRules;


namespace TSD.AccountingSoft.BusinessEntities.Dictionary
{
    /// <summary>
    /// DepartmentEntity
    /// </summary>
    public class DepartmentEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DepartmentEntity"/> class.
        /// </summary>
        public DepartmentEntity()
        {
            AddRule(new ValidateRequired("DepartmentCode"));
            AddRule(new ValidateRequired("DepartmentName"));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DepartmentEntity"/> class.
        /// </summary>
        /// <param name="departmentId">The department identifier.</param>
        /// <param name="departmentCode">The department code.</param>
        /// <param name="departmentName">Name of the department.</param>
        /// <param name="parentId">The parent identifier.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <param name="description">The description.</param>
        public DepartmentEntity(int departmentId, string departmentCode, string departmentName, int parentId, bool isActive, string description)
            : this()
        {
            DepartmentId = departmentId;
            DepartmentCode = departmentCode;
            DepartmentName = departmentName;
            ParentId = parentId;
            IsActive = isActive;
            Description = description;
        }

        /// <summary>
        /// Gets or sets the department identifier.
        /// </summary>
        /// <value>
        /// The department identifier.
        /// </value>
        public int DepartmentId { get; set; }

        /// <summary>
        /// Gets or sets the department code.
        /// </summary>
        /// <value>
        /// The department code.
        /// </value>
        public string DepartmentCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the department.
        /// </summary>
        /// <value>
        /// The name of the department.
        /// </value>
        public string DepartmentName { get; set; }

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
        /// Gets or sets the parent identifier.
        /// </summary>
        /// <value>
        /// The parent identifier.
        /// </value>
        public int? ParentId { get; set; }
    }
}
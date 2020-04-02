/***********************************************************************
 * <copyright file="BudgetCategoryEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TUDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: 27 March 2014
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
    /// class ProjectEntity
    /// </summary>
    public class ProjectEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectEntity"/> class.
        /// </summary>
        public ProjectEntity()
        {
            AddRule(new ValidateRequired("ProjectCode"));
            AddRule(new ValidateRequired("ProjectName"));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectEntity"/> class.
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// <param name="projectCode">The project code.</param>
        /// <param name="projectName">Name of the project.</param>
        /// <param name="parentId">The parent identifier.</param>
        /// <param name="isParent">if set to <c>true</c> [is parent].</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <param name="description">The description.</param>
        /// <param name="grade">The grade.</param>
        /// <param name="foreignName">Name of the foreign.</param>
        public ProjectEntity(int projectId, string projectCode, string projectName, int? parentId, bool isParent,
            bool isActive, string description, int grade, string foreignName)
            : this()
        {
            ProjectId = projectId;
            ProjectCode = projectCode;
            ProjectName = projectName;
            ParentId = parentId;
            IsParent = isParent;
            IsActive = isActive;
            Description = description;
            Grade = grade;
            ForeignName = foreignName;
        }

        /// <summary>
        /// Gets or sets the project identifier.
        /// </summary>
        /// <value>
        /// The project identifier.
        /// </value>
        public int ProjectId { get; set; }

        /// <summary>
        /// Gets or sets the project code.
        /// </summary>
        /// <value>
        /// The project code.
        /// </value>
        public string ProjectCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the project.
        /// </summary>
        /// <value>
        /// The name of the project.
        /// </value>
        public string ProjectName { get; set; }

        /// <summary>
        /// Gets or sets the name of the foreign.
        /// </summary>
        /// <value>
        /// The name of the foreign.
        /// </value>
        public string ForeignName { get; set; }

        /// <summary>
        /// Gets or sets the parent identifier.
        /// </summary>
        /// <value>
        /// The parent identifier.
        /// </value>
        public int? ParentId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is parent].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is parent]; otherwise, <c>false</c>.
        /// </value>
        public bool IsParent { get; set; }

        /// <summary>
        /// Gets or sets the grade.
        /// </summary>
        /// <value>
        /// The grade.
        /// </value>
        public int Grade { get; set; }

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

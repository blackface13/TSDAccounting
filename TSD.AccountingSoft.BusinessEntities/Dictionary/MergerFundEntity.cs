/***********************************************************************
 * <copyright file="MergerFundEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   THODD
 * Email:    thodd@buca.vn
 * Website:
 * Create Date: 14 March 2014
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
    /// Class MergerFundEntity.
    /// </summary>
    public class MergerFundEntity : BusinessEntities
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="MergerFundEntity"/> class.
        /// </summary>
        public MergerFundEntity()
        {
            AddRule(new ValidateRequired("MergerFundCode"));
            AddRule(new ValidateRequired("MergerFundName"));

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MergerFundEntity"/> class.
        /// </summary>
        /// <param name="mergerFundId">The budget category identifier.</param>
        /// <param name="mergerFundCode">The budget category code.</param>
        /// <param name="mergerFundName">Name of the budget category.</param>
        /// <param name="parentId">The parent identifier.</param>
        /// <param name="isSystem">if set to <c>true</c> [is system].</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <param name="description">The description.</param>
        /// <param name="grade">The grade.</param>
        /// <param name="foreignName">Name of the foreign.</param>
        public MergerFundEntity(int mergerFundId, string mergerFundCode, string mergerFundName, int? parentId, bool isSystem, bool isActive, string description, 
            int grade, string foreignName)
            : this()
        {
            MergerFundId = mergerFundId;
            MergerFundCode = mergerFundCode;
            MergerFundName = mergerFundName;
            IsSystem = isSystem;
            ParentId = parentId;
            IsActive = isActive;
            Description = description;
            Grade = grade;
            ForeignName = foreignName;
        }

        /// <summary>
        /// Gets or sets the merger fund identifier.
        /// </summary>
        /// <value>The merger fund identifier.</value>
        public int MergerFundId { get; set; }

        /// <summary>
        /// Gets or sets the name of the merger fund.
        /// </summary>
        /// <value>The name of the merger fund.</value>
        public string MergerFundName { get; set; }

        /// <summary>
        /// Gets or sets the merger fund code.
        /// </summary>
        /// <value>The merger fund code.</value>
        public string MergerFundCode { get; set; }

        /// <summary>
        /// Gets or sets the parent identifier.
        /// </summary>
        /// <value>The parent identifier.</value>
        public int? ParentId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is system.
        /// </summary>
        /// <value><c>true</c> if this instance is system; otherwise, <c>false</c>.</value>
        public bool IsSystem { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the grade.
        /// </summary>
        /// <value>The grade.</value>
        public int Grade { get; set; }

        /// <summary>
        /// Gets or sets the name of the foreign.
        /// </summary>
        /// <value>The name of the foreign.</value>
        public string ForeignName { get; set; }
    }
}

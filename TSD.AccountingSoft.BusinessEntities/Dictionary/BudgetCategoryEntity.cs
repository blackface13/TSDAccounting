/***********************************************************************
 * <copyright file="BudgetCategoryEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   THODD
 * Email:    thodd@buca.vn
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
    /// Class BudgetCategoryEntity.
    /// </summary>
    public class BudgetCategoryEntity : BusinessEntities
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="BudgetCategoryEntity"/> class.
        /// </summary>
        public BudgetCategoryEntity()
        {
            AddRule(new ValidateRequired("BudgetCategoryCode"));
            AddRule(new ValidateRequired("BudgetCategoryName"));
        
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BudgetCategoryEntity"/> class.
        /// </summary>
        /// <param name="budgetCategoryId">The budget category identifier.</param>
        /// <param name="budgetCategoryCode">The budget category code.</param>
        /// <param name="budgetCategoryName">Name of the budget category.</param>
        /// <param name="parentId">The parent identifier.</param>
        /// <param name="isParent"></param>
        /// <param name="isSystem">if set to <c>true</c> [is system].</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <param name="description">The description.</param>
        /// <param name="grade">The grade.</param>
        /// <param name="foreignName">Name of the foreign.</param>
        public BudgetCategoryEntity(int budgetCategoryId, string budgetCategoryCode, string budgetCategoryName, int? parentId, bool isParent, bool isSystem, 
            bool isActive, string description, int grade, string foreignName)
            : this()
        {
            BudgetCategoryId = budgetCategoryId;
            BudgetCategoryCode = budgetCategoryCode;
            BudgetCategoryName = budgetCategoryName;
            IsSystem = isSystem;
            ParentId = parentId;
            IsParent = isParent;
            IsActive = isActive;
            Description = description;
            Grade = grade;
            ForeignName = foreignName;
        }

        /// <summary>
        /// Gets or sets the budget category identifier.
        /// </summary>
        /// <value>The budget category identifier.</value>
        public int BudgetCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the name of the budget category.
        /// </summary>
        /// <value>The name of the budget category.</value>
        public string BudgetCategoryName { get; set; }

        /// <summary>
        /// Gets or sets the budget category code.
        /// </summary>
        /// <value>The budget category code.</value>
        public string BudgetCategoryCode { get; set; }

        /// <summary>
        /// Gets or sets the parent identifier.
        /// </summary>
        /// <value>The parent identifier.</value>
        public int? ParentId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is system.
        /// </summary>
        /// <value><c>true</c> if this instance is system; otherwise, <c>false</c>.</value>
        public bool IsParent { get; set; }

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

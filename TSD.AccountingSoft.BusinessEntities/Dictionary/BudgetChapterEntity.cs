/***********************************************************************
 * <copyright file="BudgetChapterEntity.cs" company="BUCA JSC">
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
    /// Class BudgetChapterEntity.
    /// </summary>
    public class BudgetChapterEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BudgetChapterEntity"/> class.
        /// </summary>
        public BudgetChapterEntity()
        {
            AddRule(new ValidateRequired("BudgetChapterCode"));
            AddRule(new ValidateRequired("BudgetChapterName"));
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="BudgetChapterEntity"/> class.
        /// </summary>
        /// <param name="budgetChapterId">The budget chapter identifier.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="budgetChapterName">Name of the budget chapter.</param>
        /// <param name="isSystem">if set to <c>true</c> [is system].</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <param name="description">The description.</param>
        /// <param name="foreignName">Name of the foreign.</param>
        public BudgetChapterEntity(int budgetChapterId, string budgetChapterCode, string budgetChapterName, bool isSystem, bool isActive, string description, string foreignName)
            : this()
        {
            BudgetChapterId = budgetChapterId;
            BudgetChapterCode = budgetChapterCode;
            BudgetChapterName = budgetChapterName;
            IsSystem = isSystem;
            IsActive = isActive;
            Description = description;
            ForeignName = foreignName;
        }
        
        /// <summary>
        /// Gets or sets the budget chapter identifier.
        /// </summary>
        /// <value>The budget chapter identifier.</value>
        public int BudgetChapterId { get; set; }
        
        /// <summary>
        /// Gets or sets the budget chapter code.
        /// </summary>
        /// <value>The budget chapter code.</value>
        public string BudgetChapterCode { get; set; }
        
        /// <summary>
        /// Gets or sets the name of the budget chapter.
        /// </summary>
        /// <value>The name of the budget chapter.</value>
        public string BudgetChapterName { get; set; }
        
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }
        
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        public bool IsActive { get; set; }
        
        /// <summary>
        /// Gets or sets a value indicating whether this instance is system.
        /// </summary>
        /// <value><c>true</c> if this instance is system; otherwise, <c>false</c>.</value>
        public bool IsSystem { get; set; }
        
        /// <summary>
        /// Gets or sets the name of the foreign.
        /// </summary>
        /// <value>The name of the foreign.</value>
        public string ForeignName { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TSD.AccountingSoft.BusinessEntities.BusinessRules;

namespace TSD.AccountingSoft.BusinessEntities.Dictionary
{
    public class BudgetSourcePropertyEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BudgetSourcePropertyEntity"/> class.
        /// </summary>
        public BudgetSourcePropertyEntity()
        {
            AddRule(new ValidateRequired("BudgetSourcePropertyCode"));
            AddRule(new ValidateRequired("BudgetSourcePropertyName"));
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="BudgetSourcePropertyEntity"/> class.
        /// </summary>
        /// <param name="budgetSourcePropertyID">The budget source property identifier.</param>
        /// <param name="budgetSourcePropertyCode">The budget source property code.</param>
        /// <param name="budgetSourcePropertyName">Name of the budget source property.</param>
        /// <param name="isSystem">if set to <c>true</c> [is system].</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <param name="description">The description.</param>
        public BudgetSourcePropertyEntity(int budgetSourcePropertyID, string budgetSourcePropertyCode, string budgetSourcePropertyName,
                                                    bool isSystem, bool isActive, string description)
            : this()
        {
            BudgetSourcePropertyID = budgetSourcePropertyID;
            BudgetSourcePropertyCode = budgetSourcePropertyCode;
            BudgetSourcePropertyName = budgetSourcePropertyName;
            IsSystem = isSystem;
            IsActive = isActive;
            Description = description;
        }
        /// <summary>
        /// Gets or sets the budget source property identifier.
        /// </summary>
        /// <value>
        /// The budget source property identifier.
        /// </value>
        public int BudgetSourcePropertyID { get; set; }
        /// <summary>
        /// Gets or sets the budget source property code.
        /// </summary>
        /// <value>
        /// The budget source property code.
        /// </value>
        public string BudgetSourcePropertyCode { get; set; }
        /// <summary>
        /// Gets or sets the name of the budget source property.
        /// </summary>
        /// <value>
        /// The name of the budget source property.
        /// </value>
        public string BudgetSourcePropertyName { get; set; }
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
        /// Gets or sets a value indicating whether [is system].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is system]; otherwise, <c>false</c>.
        /// </value>
        public bool IsSystem { get; set; }
    }
}

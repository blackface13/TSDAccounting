using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.Model.BusinessObjects.Dictionary
{
    public class BudgetSourcePropertyModel
    {
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

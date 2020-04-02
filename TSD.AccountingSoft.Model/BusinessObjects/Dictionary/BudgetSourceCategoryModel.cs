/***********************************************************************
 * <copyright file="BudgetSourceCategoryModel.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 19 June 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

namespace TSD.AccountingSoft.Model.BusinessObjects.Dictionary
{
    /// <summary>
    /// class BudgetSourceCategoryModel
    /// </summary>
    public class BudgetSourceCategoryModel
    {
        /// <summary>
        /// Gets or sets the budget source category identifier.
        /// </summary>
        /// <value>
        /// The budget source category identifier.
        /// </value>
        public int BudgetSourceCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the budget source category code.
        /// </summary>
        /// <value>
        /// The budget source category code.
        /// </value>
        public string BudgetSourceCategoryCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the budget source category.
        /// </summary>
        /// <value>
        /// The name of the budget source category.
        /// </value>
        public string BudgetSourceCategoryName { get; set; }

        /// <summary>
        /// Gets or sets the name of the foreign.
        /// </summary>
        /// <value>
        /// The name of the foreign.
        /// </value>
        public string ForeignName { get; set; }

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
        /// Gets or sets a value indicating whether [is summary estimate report].
        /// </summary>
        /// <value>
        /// <c>true</c> if [is summary estimate report]; otherwise, <c>false</c>.
        /// </value>
        public bool IsSummaryEstimateReport { get; set; }
    }
}

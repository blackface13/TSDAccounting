/***********************************************************************
 * <copyright file="CapitalAllocateModel.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuanHM
 * Email:    Tuanhm@buca.vn
 * Website:
 * Create Date: Friday, March 7, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

namespace TSD.AccountingSoft.Model.BusinessObjects.Dictionary
{
    /// <summary>
    /// Class CapitalAllocateModel.
    /// </summary>
    public class CapitalAllocateModel 
    {
        /// <summary>
        /// Gets or sets the budget item identifier.
        /// </summary>
        /// <value>The budget item identifier.</value>
        public string FromDate { get; set; }

        /// <summary>
        /// Gets or sets the budget item identifier.
        /// </summary>
        /// <value>The budget item identifier.</value>
        public string ToDate { get; set; } 

        /// <summary>
        /// Gets or sets the capital allocate identifier.
        /// </summary>
        /// <value>The capital allocate identifier.</value>
        public int CapitalAllocateId { get; set; }

        /// <summary>
        /// Gets or sets the budget item identifier.
        /// </summary>
        /// <value>The budget item identifier.</value>
        public string BudgetItemCode { get; set; }

        /// <summary>
        /// Gets or sets the budget source identifier.
        /// </summary>
        /// <value>The budget source identifier.</value>
        public string BudgetSourceCode { get; set; }

        /// <summary>
        /// Gets or sets the activityId.
        /// </summary>
        /// <value>The activityId.</value> 
        public int ActivityId { get; set; }

        /// <summary>
        /// Gets or sets the allocate percent.
        /// </summary>
        /// <value>The allocate percent.</value>
        public short AllocatePercent { get; set; }

        /// <summary>
        /// Gets or sets the type of the allocate.
        /// </summary>
        /// <value>The type of the allocate.</value>
        public short AllocateType { get; set; }

        /// <summary>
        /// Gets or sets the determined date.
        /// </summary>
        /// <value>The determined date.</value>
        public string DeterminedDate { get; set; }

        /// <summary>
        /// Gets or sets the capital account.
        /// </summary>
        /// <value>The capital account.</value>
        public string CapitalAccountCode { get; set; }

        /// <summary>
        /// Gets or sets the revenue account.
        /// </summary>
        /// <value>The revenue account.</value>
        public string RevenueAccountCode { get; set; }

        /// <summary>
        /// Gets or sets the expense account.
        /// </summary>
        /// <value>The expense account.</value>
        public string ExpenseAccountCode { get; set; }

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
        /// Gets or sets the wait budget source identifier.
        /// </summary>
        /// <value>The wait budget source identifier.</value>
        public string WaitBudgetSourceCode { get; set; }

        /// <summary>
        /// Gets or sets the capital allocate code.
        /// </summary>
        /// <value>The capital allocate code.</value>
        public string CapitalAllocateCode { get; set; }
    }
}

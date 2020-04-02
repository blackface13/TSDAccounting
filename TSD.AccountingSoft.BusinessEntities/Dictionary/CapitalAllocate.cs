/***********************************************************************
 * <copyright file="CapitalAllocate.cs" company="BUCA JSC">
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

using System;
using TSD.AccountingSoft.BusinessEntities.BusinessRules;

namespace TSD.AccountingSoft.BusinessEntities.Dictionary
{
    /// <summary>
    /// Class CapitalAllocateEntity.
    /// </summary>
    public class CapitalAllocateEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CapitalAllocateEntity"/> class.
        /// </summary>
        public CapitalAllocateEntity()
        {
            AddRule(new ValidateId("CapitalAllocateId"));
            AddRule(new ValidateRequired("CapitalAllocateCode"));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CapitalAllocateEntity"/> class.
        /// </summary>
        /// <param name="capitalAllocateId">The capital allocate identifier.</param>
        /// <param name="budgetItemId">The budget item identifier.</param>
        /// <param name="budgetSourceId">The budget source identifier.</param>
        /// <param name="activityid">The activityid.</param>
        /// <param name="allocatePercent">The allocate percent.</param>
        /// <param name="allocateType">Type of the allocate.</param>
        /// <param name="determinedDate">The determined date.</param>
        /// <param name="capitalAccount">The capital account.</param>
        /// <param name="revenueAccount">The revenue account.</param>
        /// <param name="expenseAccount">The expense account.</param>
        /// <param name="description">The description.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <param name="waitBudgetSourceId">The wait budget source identifier.</param>
        /// <param name="capitalAllocateCode">The capital allocate code.</param>
        public CapitalAllocateEntity(int capitalAllocateId, string budgetItemId, string budgetSourceId, int activityid, short allocatePercent, short allocateType,
            DateTime determinedDate, string capitalAccount, string revenueAccount, string expenseAccount, string description, bool isActive, string waitBudgetSourceId, 
            string capitalAllocateCode)
            : this()
        {
            CapitalAllocateId = capitalAllocateId;
            BudgetItemCode = budgetItemId;
            BudgetSourceCode = budgetSourceId;
            Activityid = activityid;
            AllocatePercent = allocatePercent;
            AllocateType = allocateType;
            DeterminedDate = determinedDate;
            CapitalAccountCode = capitalAccount;
            RevenueAccountCode = revenueAccount;
            ExpenseAccountCode = expenseAccount;
            Description = description;
            IsActive = isActive;
            WaitBudgetSourceCode = waitBudgetSourceId;
            CapitalAllocateCode = capitalAllocateCode;
        }

        /// <summary>
        /// Gets or sets the determined date.
        /// </summary>
        /// <value>The determined date.</value>
        public DateTime FromDate { get; set; } 

        /// <summary>
        /// Gets or sets the determined date.
        /// </summary>
        /// <value>The determined date.</value>
        public DateTime ToDate { get; set; }
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
        /// Gets or sets the activityid.
        /// </summary>
        /// <value>The activityid.</value>
        public int Activityid { get; set; }
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
        public DateTime? DeterminedDate { get; set; }
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

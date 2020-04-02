/***********************************************************************
 * <copyright file="ICapitalAllocateView.cs" company="BUCA JSC">
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

namespace TSD.AccountingSoft.View.Dictionary
{
    /// <summary>
    /// Interface ICapitalAllocateView
    /// </summary>
    public interface ICapitalAllocateView : IView  
    {
        /// <summary>
        /// Gets or sets the capital allocate identifier.
        /// </summary>
        /// <value>The capital allocate identifier.</value>
         int CapitalAllocateId { get; set; }

         /// <summary>
         /// Gets or sets the budget item identifier.
         /// </summary>
         /// <value>The budget item identifier.</value>
         string  BudgetItemCode { get; set; }

         /// <summary>
         /// Gets or sets the budget item identifier.
         /// </summary>
         /// <value>The budget item identifier.</value>
         DateTime FromDate { get; set; } 

         /// <summary>
         /// Gets or sets the budget item identifier.
         /// </summary>
         /// <value>The budget item identifier.</value>
         DateTime ToDate { get; set; } 

         /// <summary>
         /// Gets or sets the budget source identifier.
         /// </summary>
         /// <value>The budget source identifier.</value>
         string BudgetSourceCode { get; set; } 

         /// <summary>
         /// Gets or sets the ActivityId.
         /// </summary>
         /// <value>The ActivityId.</value>
         int ActivityId { get; set; }  

         /// <summary>
         /// Gets or sets the allocate percent.
         /// </summary>
         /// <value>The allocate percent.</value>
         short AllocatePercent { get; set; }

         /// <summary>
         /// Gets or sets the type of the allocate.
         /// </summary>
         /// <value>The type of the allocate.</value>
         short AllocateType { get; set; }

         /// <summary>
         /// Gets or sets the determined date.
         /// </summary>
         /// <value>The determined date.</value>
         string DeterminedDate { get; set; }

         /// <summary>
         /// Gets or sets the capital account.
         /// </summary>
         /// <value>The capital account.</value>
         string CapitalAccountCode { get; set; }

         /// <summary>
         /// Gets or sets the revenue account.
         /// </summary>
         /// <value>The revenue account.</value>
         string RevenueAccountCode { get; set; }

         /// <summary>
         /// Gets or sets the expense account.
         /// </summary>
         /// <value>The expense account.</value>
         string ExpenseAccountCode { get; set; }

         /// <summary>
         /// Gets or sets the description.
         /// </summary>
         /// <value>The description.</value>
         string Description { get; set; }

         /// <summary>
         /// Gets or sets a value indicating whether this instance is active.
         /// </summary>
         /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
         bool IsActive { get; set; }

         /// <summary>
         /// Gets or sets the wait budget source identifier.
         /// </summary>
         /// <value>The wait budget source identifier.</value>
         string WaitBudgetSourceCode { get; set; } 

         /// <summary>
         /// Gets or sets the capital allocate code.
         /// </summary>
         /// <value>The capital allocate code.</value>
         string CapitalAllocateCode { get; set; }
    }
}

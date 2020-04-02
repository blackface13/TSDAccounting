/***********************************************************************
 * <copyright file="GeneralEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: 11 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using TSD.AccountingSoft.BusinessEntities.BusinessRules;


namespace TSD.AccountingSoft.BusinessEntities.Business.General
{
    /// <summary>
    /// Class CaptitalAllocateVoucherEntity.
    /// </summary>
 public   class CaptitalAllocateVoucherEntity:BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CaptitalAllocateVoucherEntity" /> class.
        /// </summary>
       public CaptitalAllocateVoucherEntity()
        {
            AddRule(new ValidateId("RefDetailId"));
        }

       /// <summary>
       /// Initializes a new instance of the <see cref="CaptitalAllocateVoucherEntity" /> class.
       /// </summary>
       /// <param name="refDetailId">The reference detail identifier.</param>
       /// <param name="budgetItemCode">The budget item code.</param>
       /// <param name="budgetSourceCode">The budget source code.</param>
       /// <param name="budgetSourceName">Name of the budget source.</param>
       /// <param name="activityId">The activity identifier.</param>
       /// <param name="allocateType">Type of the allocate.</param>
       /// <param name="allocatePercent">The allocate percent.</param>
       /// <param name="determinedDate">The determined date.</param>
       /// <param name="capitalAccountCode">The capital account code.</param>
       /// <param name="revenueAccountCode">The revenue account code.</param>
       /// <param name="expenseAccountCode">The expense account code.</param>
       /// <param name="description">The description.</param>
       /// <param name="isActive">if set to <c>true</c> [is active].</param>
       /// <param name="waitBudgetSourceCode">The wait budget source code.</param>
       /// <param name="capitalAllocateCode">The capital allocate code.</param>
       /// <param name="totalAmount">The total amount.</param>
       /// <param name="amount">The amount.</param>
       /// <param name="expenseAmount">The expense amount.</param>
       /// <param name="toDate">To date.</param>
       /// <param name="fromDate">From date.</param>
       /// <param name="refId">The reference identifier.</param>
       public CaptitalAllocateVoucherEntity(long refDetailId, string budgetItemCode, string budgetSourceCode, string budgetSourceName, string activityId,
	              int allocateType ,
	              decimal allocatePercent ,
	              DateTime determinedDate  ,
	              string capitalAccountCode  ,
	              string revenueAccountCode  ,
	              string expenseAccountCode  ,
	              string description   ,
	              bool isActive   ,
	              string waitBudgetSourceCode   ,
	              string capitalAllocateCode  ,
	              decimal totalAmount ,
	              decimal amount ,
	              decimal expenseAmount  ,
             DateTime toDate,
             DateTime fromDate,
                 long refId)
         {

            RefDetailId =refDetailId;
            BudgetItemCode  =budgetItemCode;
            BudgetSourceCode = budgetSourceCode;
            ActivityId  =activityId;
            AllocateType =allocateType;
            AllocatePercent =allocatePercent;
            DeterminedDate  =determinedDate;
            CapitalAccountCode  =capitalAccountCode;
            RevenueAccountCode  =revenueAccountCode;
            ExpenseAccountCode  =expenseAccountCode;
            Description   =description;
            IsActive   =isActive;
            WaitBudgetSourceCode   =waitBudgetSourceCode;
            CapitalAllocateCode  =capitalAllocateCode;
            TotalAmount =totalAmount;
            Amount =amount;
            ExpenseAmount  =expenseAmount;
            ToDate = toDate;
            FromDate = fromDate;
            RefId = refId;
            BudgetSourceName = budgetSourceName;
         }

       /// <summary>
       /// Gets or sets the capital allocate voucher identifier.
       /// </summary>
       /// <value>The capital allocate voucher identifier.</value>
            public  long RefDetailId { get; set; }

            /// <summary>
            /// Gets or sets the budget item code.
            /// </summary>
            /// <value>The budget item code.</value>
            public  string BudgetItemCode  { get; set; }

            /// <summary>
            /// Gets or sets the budget soucre code.
            /// </summary>
            /// <value>The budget soucre code.</value>
            public  string BudgetSourceCode  { get; set; }

            /// <summary>
            /// Gets or sets the name of the budget source.
            /// </summary>
            /// <value>The name of the budget source.</value>
            public string BudgetSourceName { get; set; }

            /// <summary>
            /// Gets or sets the activity identifier.
            /// </summary>
            /// <value>The activity identifier.</value>
            public  string  ActivityId  { get; set; }

            /// <summary>
            /// Gets or sets the type of the allocate.
            /// </summary>
            /// <value>The type of the allocate.</value>
            public  int AllocateType { get; set; }

            /// <summary>
            /// Gets or sets the allocate percent.
            /// </summary>
            /// <value>The allocate percent.</value>
            public  decimal AllocatePercent { get; set; }

            /// <summary>
            /// Gets or sets the determined date.
            /// </summary>
            /// <value>The determined date.</value>
            public  DateTime? DeterminedDate  { get; set; }

            /// <summary>
            /// Gets or sets the capital account code.
            /// </summary>
            /// <value>The capital account code.</value>
            public  string CapitalAccountCode  { get; set; }

            /// <summary>
            /// Gets or sets the revenue account code.
            /// </summary>
            /// <value>The revenue account code.</value>
            public  string RevenueAccountCode  { get; set; }

            /// <summary>
            /// Gets or sets the expense account code.
            /// </summary>
            /// <value>The expense account code.</value>
            public  string ExpenseAccountCode  { get; set; }

            /// <summary>
            /// Gets or sets the description.
            /// </summary>
            /// <value>The description.</value>
            public  string Description   { get; set; }

            /// <summary>
            /// Gets or sets a value indicating whether this instance is active.
            /// </summary>
            /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
            public  bool IsActive   { get; set; }

            /// <summary>
            /// Gets or sets the wait budget source code.
            /// </summary>
            /// <value>The wait budget source code.</value>
            public  string WaitBudgetSourceCode   { get; set; }

            /// <summary>
            /// Gets or sets the captital allocate code.
            /// </summary>
            /// <value>The captital allocate code.</value>
            public  string CapitalAllocateCode  { get; set; }

            /// <summary>
            /// Gets or sets the total amount.
            /// </summary>
            /// <value>The total amount.</value>
            public  decimal TotalAmount { get; set; }

            /// <summary>
            /// Gets or sets the amount.
            /// </summary>
            /// <value>The amount.</value>
            public  decimal Amount { get; set; }

            /// <summary>
            /// Gets or sets the expense amount.
            /// </summary>
            /// <value>The expense amount.</value>
            public  decimal ExpenseAmount  { get; set; }

            /// <summary>
            /// Gets or sets the reference identifier.
            /// </summary>
            /// <value>The reference identifier.</value>
            public long RefId { get; set; }


            /// <summary>
            /// Gets or sets to date.
            /// </summary>
            /// <value>To date.</value>
            public DateTime ToDate { get; set; }

            /// <summary>
            /// Gets or sets from date.
            /// </summary>
            /// <value>From date.</value>
            public DateTime FromDate { get; set; }

            /// <summary>
            /// Gets or sets the currency code.
            /// </summary>
            /// <value>The currency code.</value>
            public string CurrencyCode { get; set; }

            /// <summary>
            /// Gets or sets the exchange rate.
            /// </summary>
            /// <value>The exchange rate.</value>
            public decimal ExchangeRate { get; set; }
            
     
    
    }
}

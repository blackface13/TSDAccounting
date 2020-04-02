/***********************************************************************
 * <copyright file="GeneralCapitalAllocate.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: 17 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;

namespace TSD.AccountingSoft.Model.BusinessObjects.General
{
    /// <summary>
    /// 
    /// </summary>
  public class CaptitalAllocateVoucherModel
    {

        /// <summary>
        /// Gets or sets the capital allocate voucher identifier.
        /// </summary>
        /// <value>
        /// The capital allocate voucher identifier.
        /// </value>
        public long RefDetailId { get; set; }

        /// <summary>
        /// Gets or sets the budget item code.
        /// </summary>
        /// <value>
        /// The budget item code.
        /// </value>
        public string BudgetItemCode { get; set; }

        /// <summary>
        /// Gets or sets the budget soucre code.
        /// </summary>
        /// <value>
        /// The budget soucre code.
        /// </value>
        public string BudgetSourceCode { get; set; }


        /// <summary>
        /// Gets or sets the name of the budget source.
        /// </summary>
        /// <value>
        /// The name of the budget source.
        /// </value>
        public string BudgetSourceName { get; set; }


        /// <summary>
        /// Gets or sets the activity identifier.
        /// </summary>
        /// <value>
        /// The activity identifier.
        /// </value>
        public string ActivityId { get; set; }

        /// <summary>
        /// Gets or sets the type of the allocate.
        /// </summary>
        /// <value>
        /// The type of the allocate.
        /// </value>
        public int AllocateType { get; set; }

        /// <summary>
        /// Gets or sets the allocate percent.
        /// </summary>
        /// <value>
        /// The allocate percent.
        /// </value>
        public decimal AllocatePercent { get; set; }

        /// <summary>
        /// Gets or sets the determined date.
        /// </summary>
        /// <value>
        /// The determined date.
        /// </value>
        public DateTime? DeterminedDate { get; set; }

        /// <summary>
        /// Gets or sets the capital account code.
        /// </summary>
        /// <value>
        /// The capital account code.
        /// </value>
        public string CapitalAccountCode { get; set; }

        /// <summary>
        /// Gets or sets the revenue account code.
        /// </summary>
        /// <value>
        /// The revenue account code.
        /// </value>
        public string RevenueAccountCode { get; set; }

        /// <summary>
        /// Gets or sets the expense account code.
        /// </summary>
        /// <value>
        /// The expense account code.
        /// </value>
        public string ExpenseAccountCode { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the wait budget source code.
        /// </summary>
        /// <value>
        /// The wait budget source code.
        /// </value>
        public string WaitBudgetSourceCode { get; set; }

        /// <summary>
        /// Gets or sets the captital allocate code.
        /// </summary>
        /// <value>
        /// The captital allocate code.
        /// </value>
        public string CapitalAllocateCode { get; set; }

        /// <summary>
        /// Gets or sets the total amount.
        /// </summary>
        /// <value>
        /// The total amount.
        /// </value>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the expense amount.
        /// </summary>
        /// <value>
        /// The expense amount.
        /// </value>
        public decimal ExpenseAmount { get; set; }

        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>
        /// The reference identifier.
        /// </value>
        public long RefId { get; set; }

        /// <summary>
        /// Gets or sets the currency code.
        /// </summary>
        /// <value>
        /// The currency code.
        /// </value>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets from date.
        /// </summary>
        /// <value>
        /// From date.
        /// </value>
        public DateTime FromDate { get; set; }

        /// <summary>
        /// Gets or sets to date.
        /// </summary>
        /// <value>
        /// To date.
        /// </value>
        public DateTime ToDate { get; set; }

        /// <summary>
        /// Gets or sets the exchange rate.
        /// </summary>
        /// <value>
        /// The exchange rate.
        /// </value>
        public Decimal ExchangeRate { get; set; }


    }
}

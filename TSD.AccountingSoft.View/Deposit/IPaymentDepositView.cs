/***********************************************************************
 * <copyright file="IReceiptDepositView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   BangNC
 * Email:    BangNC@buca.vn
 * Website:
 * Create Date: 18 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using TSD.AccountingSoft.Model.BusinessObjects.Deposit;


namespace TSD.AccountingSoft.View.Deposit
{
    /// <summary>
    /// Interface IReceiptDepositView
    /// </summary>
    public interface IPaymentDepositView : IView
    {
        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>The reference identifier.</value>
        long RefId { get; set; }

        /// <summary>
        /// Gets or sets the type of the reference.
        /// </summary>
        /// <value>The type of the reference.</value>
        int RefTypeId { get; set; }

        /// <summary>
        /// Gets or sets the reference date.
        /// </summary>
        /// <value>The reference date.</value>
        DateTime? RefDate { get; set; }

        /// <summary>
        /// Gets or sets the posted date.
        /// </summary>
        /// <value>The posted date.</value>
        DateTime? PostedDate { get; set; }

        /// <summary>
        /// Gets or sets the reference no.
        /// </summary>
        /// <value>The reference no.</value>
        string RefNo { get; set; }

        /// <summary>
        /// Gets or sets the type of the accounting object.
        /// </summary>
        /// <value>The type of the accounting object.</value>
        int? AccountingObjectType { get; set; }

        /// <summary>
        /// Gets or sets the accounting object identifier.
        /// </summary>
        /// <value>The accounting object identifier.</value>
        int? AccountingObjectId { get; set; }

        /// <summary>
        /// Gets or sets the trader.
        /// </summary>
        /// <value>The trader.</value>
        string Trader { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>The customer identifier.</value>
        int? CustomerId { get; set; }

        int? BankId { get; set; }

        /// <summary>
        /// Gets or sets the vendor identifier.
        /// </summary>
        /// <value>The vendor identifier.</value>
        int? VendorId { get; set; }

        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>The employee identifier.</value>
        int? EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets the bank account code.
        /// </summary>
        /// <value>The bank account code.</value>
        string BankAccountCode { get; set; }

        /// <summary>
        /// Gets or sets the currency code.
        /// </summary>
        /// <value>The currency code.</value>
        string CurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets the exchange rate.
        /// </summary>
        /// <value>The exchange rate.</value>
        decimal ExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets the total amount oc.
        /// </summary>
        /// <value>The total amount oc.</value>
        decimal TotalAmountOc { get; set; }

        /// <summary>
        /// Gets or sets the total amount exchange.
        /// </summary>
        /// <value>The total amount exchange.</value>
        decimal TotalAmountExchange { get; set; }

        /// <summary>
        /// Gets or sets the journal memo.
        /// </summary>
        /// <value>The journal memo.</value>
        string JournalMemo { get; set; }

        /// <summary>
        /// Gets or sets the estimate details.
        /// </summary>
        /// <value>The deposit details.</value>
        IList<DepositDetailModel> DepositDetails { get; set; }

        IList<DepositDetailParallelModel> DepositDetailParallels { get; set; }
    }
}

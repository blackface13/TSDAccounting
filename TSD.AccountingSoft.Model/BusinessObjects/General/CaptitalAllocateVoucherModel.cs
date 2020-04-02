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
  public class AccountTranferVourcherModel
    {
        /// <summary>
        /// Gets or sets the reference detail identifier.
        /// </summary>
        /// <value>
        /// The reference detail identifier.
        /// </value>
        public long RefDetailId { get; set; }
        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>
        /// The reference identifier.
        /// </value>
        public long RefId { get; set; }
        /// <summary>
        /// Gets or sets the account number.
        /// </summary>
        /// <value>
        /// The account number.
        /// </value>
        public string AccountNumber { get; set; }
        /// <summary>
        /// Gets or sets the corresponding account number.
        /// </summary>
        /// <value>
        /// The corresponding account number.
        /// </value>
        public string CorrespondingAccountNumber { get; set; }
        /// <summary>
        /// Gets or sets the amount oc.
        /// </summary>
        /// <value>
        /// The amount oc.
        /// </value>
        public decimal AmountOc { get; set; }
        /// <summary>
        /// Gets or sets the amount exchange.
        /// </summary>
        /// <value>
        /// The amount exchange.
        /// </value>
        public decimal AmountExchange { get; set; }
        /// <summary>
        /// Gets or sets the currency code.
        /// </summary>
        /// <value>
        /// The currency code.
        /// </value>
        public string CurrencyCode { get; set; }
        /// <summary>
        /// Gets or sets the exchange rate.
        /// </summary>
        /// <value>
        /// The exchange rate.
        /// </value>
        public decimal ExchangeRate { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the budget source code.
        /// </summary>
        /// <value>
        /// The budget source code.
        /// </value>
        public string BudgetSourceCode { get; set; }

        /// <summary>
        /// Gets or sets the posted date.
        /// </summary>
        /// <value>
        /// The posted date.
        /// </value>
        public DateTime PostedDate { get; set; } 
        /// <summary>
        /// nghiệp vụ
        /// </summary>
        public int? VoucherTypeId { get; set; }
    }
}

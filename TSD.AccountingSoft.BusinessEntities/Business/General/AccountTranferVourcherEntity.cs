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
    /// Class AccountTranferVourcherEntity.
    /// </summary>
    public class AccountTranferVourcherEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountTranferVourcherEntity" /> class.
        /// </summary>
        public AccountTranferVourcherEntity()
        {
            AddRule(new ValidateId("RefDetailId"));
        }



        /// <summary>
        /// Initializes a new instance of the <see cref="AccountTranferVourcherEntity" /> class.
        /// </summary>
        /// <param name="refDetailId">The reference detail identifier.</param>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="correspondingAccountNumber">The corresponding account number.</param>
        /// <param name="amountOc">The amount oc.</param>
        /// <param name="amountExchange">The amount exchange.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="exchangeRate">The exchange rate.</param>
        /// <param name="description">The description.</param>
        /// <param name="budgetSourceCode">The budget source code.</param>
        /// <param name="postedDate">The posted date.</param>
        public AccountTranferVourcherEntity(long refDetailId, long refId, string accountNumber, string correspondingAccountNumber, decimal amountOc, decimal amountExchange, string currencyCode, decimal exchangeRate, string description, string budgetSourceCode, DateTime postedDate)
        {

            RefDetailId = refDetailId;
            RefId = refId;
            AccountNumber = accountNumber;
            CorrespondingAccountNumber = correspondingAccountNumber;
            AmountOc = amountOc;
            AmountExchange = amountExchange;
            CurrencyCode = currencyCode;
            ExchangeRate = exchangeRate;
            Description = description;
            BudgetSourceCode = budgetSourceCode;
            PostedDate = postedDate;
        }


        /// <summary>
        /// Gets or sets the reference detail identifier.
        /// </summary>
        /// <value>The reference detail identifier.</value>
        public long RefDetailId { get; set; }
        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>The reference identifier.</value>
        public long RefId { get; set; }
        /// <summary>
        /// Gets or sets the account number.
        /// </summary>
        /// <value>The account number.</value>
        public string AccountNumber { get; set; }
        /// <summary>
        /// Gets or sets the corresponding account number.
        /// </summary>
        /// <value>The corresponding account number.</value>
        public string CorrespondingAccountNumber { get; set; }
        /// <summary>
        /// Gets or sets the amount oc.
        /// </summary>
        /// <value>The amount oc.</value>
        public decimal AmountOc { get; set; }
        /// <summary>
        /// Gets or sets the amount exchange.
        /// </summary>
        /// <value>The amount exchange.</value>
        public decimal AmountExchange { get; set; }
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
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the budget source code.
        /// </summary>
        /// <value>The budget source code.</value>
        public string BudgetSourceCode { get; set; }

        /// <summary>
        /// Gets or sets the posted date.
        /// </summary>
        /// <value>The posted date.</value>
        public DateTime PostedDate { get; set; }

        public int? VoucherTypeId { get; set; }
    }
}

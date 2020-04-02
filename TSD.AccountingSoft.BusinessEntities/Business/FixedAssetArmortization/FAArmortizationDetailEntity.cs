/***********************************************************************
 * <copyright file="FAArmortizationDetailEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 10 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using TSD.AccountingSoft.BusinessEntities.BusinessRules;


namespace TSD.AccountingSoft.BusinessEntities.Business.FixedAssetArmortization
{
    /// <summary>
    /// FAArmortizationDetailEntity
    /// </summary>
    public class FAArmortizationDetailEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FAArmortizationDetailEntity"/> class.
        /// </summary>
        public FAArmortizationDetailEntity()
        {
            AddRule(new ValidateRequired("RefId"));
            AddRule(new ValidateRequired("FixedAssetId"));
            AddRule(new ValidateRequired("AccountNumber"));
            AddRule(new ValidateRequired("CorrespondingAccountNumber"));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FAArmortizationDetailEntity"/> class.
        /// </summary>
        /// <param name="refDetailId">The reference detail identifier.</param>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="fixedAssetId">The fixed asset identifier.</param>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="correspondingAccountNumber">The corresponding account number.</param>
        /// <param name="description">The description.</param>
        /// <param name="quantity">The quantity.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="exchangeRate">The exchange rate.</param>
        /// <param name="amountOC">The amount oc.</param>
        /// <param name="amountExchange">The amount exchange.</param>
        /// <param name="voucherTypeId">The voucher type identifier.</param>
        /// <param name="budgetSourceCode">The budget source code.</param>
        /// <param name="budgetItemCode">The budget item code.</param>
        /// <param name="budgetChapterCode">The budget chapter code.</param>
        /// <param name="budgetCategoryCode">The budget category code.</param>
        /// <param name="departmentId">The department identifier.</param>
        /// <param name="projectId">The project identifier.</param>
        public FAArmortizationDetailEntity(long refDetailId, long refId, int fixedAssetId, string accountNumber, string correspondingAccountNumber, string description,
            int quantity, string currencyCode, double exchangeRate, decimal amountOC, decimal amountExchange, int? voucherTypeId, string budgetSourceCode, string budgetItemCode,
            string budgetChapterCode, string budgetCategoryCode, int? departmentId, int? projectId, int? autoBusinessId)
            : this()
        {
            RefDetailId = refDetailId;
            RefId = refId;
            FixedAssetId = fixedAssetId;
            AccountNumber = accountNumber;
            CorrespondingAccountNumber = correspondingAccountNumber;
            Quantity = quantity;
            CurrencyCode = currencyCode;
            ExchangeRate = exchangeRate;
            AmountOC = amountOC;
            AmountExchange = amountExchange;
            VoucherTypeId = voucherTypeId;
            BudgetSourceCode = budgetSourceCode;
            BudgetItemCode = budgetItemCode;
            BudgetCategoryCode = budgetCategoryCode;
            BudgetChapterCode = budgetChapterCode;
            Description = description;
            DepartmentId = departmentId;
            ProjectId = projectId;
            AutoBusinessId = autoBusinessId;
        }

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
        /// Gets or sets the fixed asset identifier.
        /// </summary>
        /// <value>
        /// The fixed asset identifier.
        /// </value>
        public int FixedAssetId { get; set; }

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
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>
        /// The quantity.
        /// </value>
        public int Quantity { get; set; }

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
        public double ExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets the amount oc.
        /// </summary>
        /// <value>
        /// The amount oc.
        /// </value>
        public decimal AmountOC { get; set; }

        /// <summary>
        /// Gets or sets the amount exchange.
        /// </summary>
        /// <value>
        /// The amount exchange.
        /// </value>
        public decimal AmountExchange { get; set; }

        /// <summary>
        /// Gets or sets the voucher type identifier.
        /// </summary>
        /// <value>
        /// The voucher type identifier.
        /// </value>
        public int? VoucherTypeId { get; set; }

        /// <summary>
        /// Gets or sets the budget source code.
        /// </summary>
        /// <value>
        /// The budget source code.
        /// </value>
        public string BudgetSourceCode { get; set; }

        /// <summary>
        /// Gets or sets the budget item code.
        /// </summary>
        /// <value>
        /// The budget item code.
        /// </value>
        public string BudgetItemCode { get; set; }

        /// <summary>
        /// Gets or sets the budget chapter code.
        /// </summary>
        /// <value>
        /// The budget chapter code.
        /// </value>
        public string BudgetChapterCode { get; set; }

        /// <summary>
        /// Gets or sets the budget category code.
        /// </summary>
        /// <value>
        /// The budget category code.
        /// </value>
        public string BudgetCategoryCode { get; set; }

        /// <summary>
        /// Gets or sets the department identifier.
        /// </summary>
        /// <value>
        /// The department identifier.
        /// </value>
        public int? DepartmentId { get; set; }

        /// <summary>
        /// Gets or sets the project identifier.
        /// </summary>
        /// <value>
        /// The project identifier.
        /// </value>
        public int? ProjectId { get; set; }

        public int? AutoBusinessId { get; set; }
    }
}
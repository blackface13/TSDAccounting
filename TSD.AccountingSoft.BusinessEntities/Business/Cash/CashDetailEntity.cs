/***********************************************************************
 * <copyright file="CashDetailEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Hoàng Bích Sơn
 * Email:    sonhb@buca.vn
 * Website:
 * Create Date: Tuesday, March 18, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using TSD.AccountingSoft.BusinessEntities.BusinessRules;


namespace TSD.AccountingSoft.BusinessEntities.Business.Cash
{
    /// <summary>
    /// class CashDetailEntity
    /// </summary>
    public class CashDetailEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CashDetailEntity"/> class.
        /// </summary>
        public CashDetailEntity()
        {
            AddRule(new ValidateId("RefDetailId"));
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="CashDetailEntity"/> class.
        /// </summary>
        /// <param name="cashDetailId">The cash detail identifier.</param>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="correspondingAccountNumber">The corresponding account number.</param>
        /// <param name="description">The description.</param>
        /// <param name="amountOc">The amount oc.</param>
        /// <param name="amountExchange">The amount exchange.</param>
        /// <param name="voucherTypeId">The voucher type identifier.</param>
        /// <param name="budgetSourceCode">The budget source code.</param>
        /// <param name="budgetItemCode">The budget item code.</param>
        /// <param name="accountingObjectId">The accounting object identifier.</param>
        /// <param name="mergerFundId">The merger fund identifier.</param>
        /// <param name="refId">The reference identifier.</param>
        public CashDetailEntity(long cashDetailId, string accountNumber, string correspondingAccountNumber, string description, decimal amountOc, decimal amountExchange, int voucherTypeId, string budgetSourceCode, string budgetItemCode, int? accountingObjectId, int? mergerFundId, long refId)
        {
            RefDetailId = cashDetailId;
            AccountNumber = accountNumber;
            CorrespondingAccountNumber = correspondingAccountNumber;
            Description = description;
            AmountOc = amountOc;
            AmountExchange = amountExchange;
            VoucherTypeId = voucherTypeId;
            BudgetSourceCode = budgetSourceCode;
            BudgetItemCode = budgetItemCode;
            AccountingObjectId = accountingObjectId;
            MergerFundId = mergerFundId;
            RefId = refId;
        }

        /// <summary>
        /// Gets or sets the cash detail identifier.
        /// </summary>
        /// <value>
        /// The cash detail identifier.
        /// </value>
        public long RefDetailId { get; set; }

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

        public decimal Charge { get; set; }

        public decimal ChargeExchange { get; set; }

        /// <summary>
        /// Gets or sets the bussiness.
        /// </summary>
        /// <value>
        /// The bussiness.
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
        /// Gets or sets the accounting object identifier.
        /// </summary>
        /// <value>
        /// The accounting object identifier.
        /// </value>
        public int? AccountingObjectId { get; set; }

        /// <summary>
        /// Gets or sets the merger fund identifier.
        /// </summary>
        /// <value>
        /// The merger fund identifier.
        /// </value>
        public int? MergerFundId { get; set; }

        /// <summary>
        /// Gets or sets the project identifier.
        /// </summary>
        /// <value>
        /// The project identifier.
        /// </value>
        public int? ProjectId { get; set; }

        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>
        /// The reference identifier.
        /// </value>
        public long RefId { get; set; }
        public int? AutoBusinessId { get; set; }
    }
}

/***********************************************************************
 * <copyright file="ReceiptCashDetailEntity.cs" company="BUCA JSC">
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
    /// ReceiptCashDetailEntity class
    /// </summary>
    public class ReceiptCashDetailEntity: BusinessEntities
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ReceiptCashDetailEntity"/> class.
        /// </summary>
        public ReceiptCashDetailEntity()
        {
            AddRule(new ValidateId("cashDetailId"));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReceiptCashDetailEntity"/> class.
        /// </summary>
        /// <param name="cashDetailId">The cash detail identifier.</param>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="correspondingAccountNumber">The corresponding account number.</param>
        /// <param name="description">The description.</param>
        /// <param name="amountOc">The amount oc.</param>
        /// <param name="amountExchange">The amount exchange.</param>
        /// <param name="bussiness">The bussiness.</param>
        /// <param name="budgetSourceCode">The budget source code.</param>
        /// <param name="budgetItemCode">The budget item code.</param>
        /// <param name="accountingObjectId">The accounting object identifier.</param>
        /// <param name="mergerFundId">The merger fund identifier.</param>
        /// <param name="refId">The reference identifier.</param>
        public ReceiptCashDetailEntity(long cashDetailId, string accountNumber, string correspondingAccountNumber, string description, string amountOc, string amountExchange, string bussiness, string budgetSourceCode, string budgetItemCode, int accountingObjectId, int mergerFundId, long refId)
        {
            CashDetailId = cashDetailId;
            AccountNumber = accountNumber;
            CorrespondingAccountNumber = correspondingAccountNumber;
            Description = description;
            AmountOc = amountOc;
            AmountExchange = amountExchange;
            Bussiness = bussiness;
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
        public long CashDetailId { get; set; }

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
        public string AmountOc { get; set; }

        /// <summary>
        /// Gets or sets the amount exchange.
        /// </summary>
        /// <value>
        /// The amount exchange.
        /// </value>
        public string AmountExchange { get; set; }

        /// <summary>
        /// Gets or sets the bussiness.
        /// </summary>
        /// <value>
        /// The bussiness.
        /// </value>
        public string Bussiness { get; set; }

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
        public int AccountingObjectId { get; set; }

        /// <summary>
        /// Gets or sets the merger fund identifier.
        /// </summary>
        /// <value>
        /// The merger fund identifier.
        /// </value>
        public int MergerFundId { get; set; }

        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>
        /// The reference identifier.
        /// </value>
        public long RefId { get; set; }
    }
}

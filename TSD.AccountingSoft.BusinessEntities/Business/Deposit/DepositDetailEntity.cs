/***********************************************************************
 * <copyright file="DepositDetailEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   THODD
 * Email:    thodd@buca.vn
 * Website:
 * Create Date: 18 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using TSD.AccountingSoft.BusinessEntities.BusinessRules;


namespace TSD.AccountingSoft.BusinessEntities.Business.Deposit
{
    /// <summary>
    /// Class DepositDetailEntity.
    /// </summary>
    public class DepositDetailEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DepositDetailEntity"/> class.
        /// </summary>
        public DepositDetailEntity()
        {
            AddRule(new ValidateRequired("RefId"));
           // AddRule(new ValidateRequired("BudgetItemCode"));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DepositDetailEntity"/> class.
        /// </summary>
        /// <param name="refDetailId">The reference detail identifier.</param>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="description">The description.</param>
        /// <param name="accountNumber">The account number.</param>
        /// <param name="correspondingAccountNumber">The corresponding account number.</param>
        /// <param name="amountOc">The amount oc.</param>
        /// <param name="amountExchange">The amount exchange.</param>
        /// <param name="voucherTypeId">The voucher type identifier.</param>
        /// <param name="budgetSourceCode">The budget source code.</param>
        /// <param name="accountingObjectId">The accounting object identifier.</param>
        /// <param name="budgetItemCode">The budget item code.</param>
        /// <param name="departmentId">The department identifier.</param>
        /// <param name="mergerFundId">The merger fund identifier.</param>
        /// <param name="projectId"> </param>
        /// <param name="autoBusinessId"> </param>
        public DepositDetailEntity(long refDetailId, long refId, string description, string accountNumber, string correspondingAccountNumber,
            decimal amountOc, decimal amountExchange, int? voucherTypeId, string budgetSourceCode, int? accountingObjectId, string budgetItemCode,
            int? departmentId, int? mergerFundId, int? projectId, int? autoBusinessId)
            : this()
        {
            RefDetailId = refDetailId;
            RefId = refId;
            Description = description;
            AccountNumber = accountNumber;
            CorrespondingAccountNumber = correspondingAccountNumber;
            AmountOc = amountOc;
            AmountExchange = amountExchange;
            VoucherTypeId = voucherTypeId;
            BudgetSourceCode = budgetSourceCode;
            AccountingObjectId = accountingObjectId;
            BudgetItemCode = budgetItemCode;
            DepartmentId = departmentId;
            MergerFundId = mergerFundId;
            ProjectId = projectId;
            AutoBusinessId = autoBusinessId;
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
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

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
        public decimal Charge { get; set; }
        public decimal ChargeExchange { get; set; }

        /// <summary>
        /// Gets or sets the voucher type identifier.
        /// </summary>
        /// <value>The voucher type identifier.</value>
        public int? VoucherTypeId { get; set; }

        /// <summary>
        /// Gets or sets the budget source code.
        /// </summary>
        /// <value>The budget source code.</value>
        public string BudgetSourceCode { get; set; }

        /// <summary>
        /// Gets or sets the accounting object identifier.
        /// </summary>
        /// <value>The accounting object identifier.</value>
        public int? AccountingObjectId { get; set; }

        /// <summary>
        /// Gets or sets the budget item code.
        /// </summary>
        /// <value>The budget item code.</value>
        public string BudgetItemCode { get; set; }

        /// <summary>
        /// Gets or sets the department identifier.
        /// </summary>
        /// <value>The department identifier.</value>
        public int? DepartmentId { get; set; }

        /// <summary>
        /// Gets or sets the merger fund identifier.
        /// </summary>
        /// <value>The merger fund identifier.</value>
        public int? MergerFundId { get; set; }
        /// <summary>
        /// Gets or sets the department identifier.
        /// </summary>
        /// <value>The department identifier.</value>
        public int? ProjectId { get; set; }

        /// <summary>
        /// Gets or sets the merger fund identifier.
        /// </summary>
        /// <value>The merger fund identifier.</value>
        public int? AutoBusinessId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.BusinessEntities.Business.Cash
{
    public class ReceiptVoucherDetailParalellEntity:BusinessEntities
    {
        public string RefDetailId { get; set; }

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
        /// Gets or sets the debit account.
        /// </summary>
        /// <value>The debit account.</value>
        public string DebitAccount { get; set; }

        /// <summary>
        /// Gets or sets the credit account.
        /// </summary>
        /// <value>The credit account.</value>
        public string CreditAccount { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>The amount.</value>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the amount oc.
        /// </summary>
        /// <value>The amount oc.</value>
        public decimal AmountOC { get; set; }

        /// <summary>
        /// Gets or sets the budget source identifier.
        /// </summary>
        /// <value>The budget source identifier.</value>
        public int BudgetSourceId { get; set; }

   
        public int BudgetItemCode { get; set; }

        public int BudgetSubItemCode { get; set; }

        /// <summary>
        /// Gets or sets the budget detail item code.
        /// </summary>
        /// <value>The budget detail item code.</value>
        public string BudgetDetailItemCode { get; set; }

        /// <summary>
        /// Gets or sets the method distribute identifier.
        /// </summary>
        /// <value>The method distribute identifier.</value>
        public int? MethodDistributeId { get; set; }

        /// <summary>
        /// Gets or sets the cash withdraw type identifier.
        /// </summary>
        /// <value>The cash withdraw type identifier.</value>
        public int? CashWithdrawTypeId { get; set; }

        /// <summary>
        /// Gets or sets the accounting object identifier.
        /// </summary>
        /// <value>The accounting object identifier.</value>
        public string AccountingObjectId { get; set; }

        /// <summary>
        /// Gets or sets the activity identifier.
        /// </summary>
        /// <value>The activity identifier.</value>
        public string ActivityId { get; set; }

        /// <summary>
        /// Gets or sets the project identifier.
        /// </summary>
        /// <value>The project identifier.</value>
        public string ProjectId { get; set; }

        /// <summary>
        /// Gets or sets the task identifier.
        /// </summary>
        /// <value>The task identifier.</value>
        public string TaskId { get; set; }

        /// <summary>
        /// Gets or sets the list item identifier.
        /// </summary>
        /// <value>The list item identifier.</value>
        public string ListItemId { get; set; }

        /// <summary>
        /// Gets or sets the approved.
        /// </summary>
        /// <value>The approved.</value>
        public bool Approved { get; set; }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        /// <value>The sort order.</value>
        public int? SortOrder { get; set; }

        /// <summary>
        /// Gets or sets the org reference no.
        /// </summary>
        /// <value>The org reference no.</value>
        public string OrgRefNo { get; set; }

        /// <summary>
        /// Gets or sets the org reference date.
        /// </summary>
        /// <value>The org reference date.</value>
        public DateTime? OrgRefDate { get; set; }

        /// <summary>
        /// Gets or sets the fund structure identifier.
        /// </summary>
        /// <value>The fund structure identifier.</value>
        public string FundStructureId { get; set; }

        /// <summary>
        /// Gets or sets the bank identifier.
        /// </summary>
        /// <value>The bank identifier.</value>
        public string BankId { get; set; }

        /// <summary>
        /// Gets or sets the budget expense identifier.
        /// </summary>
        /// <value>The budget expense identifier.</value>
        public string BudgetExpenseId { get; set; }

        /// <summary>
        /// Gets or sets the budget provide code.
        /// </summary>
        /// <value>The budget provide code.</value>
        public string BudgetProvideCode { get; set; }

        public int? VoucherTypeId { get; set; }

    }
}

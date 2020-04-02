using System;
using System.Collections.Generic;
using TSD.AccountingSoft.BusinessEntities.BusinessRules;
using TSD.AccountingSoft.BusinessEntities.Dictionary;

namespace TSD.AccountingSoft.BusinessEntities.Business.Cash
{
    public class ReceiptVoucherEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountEntity"/> class.
        /// </summary>
        public ReceiptVoucherEntity()
        {
            AddRule(new ValidateRequired("ReceiptVoucherID"));
            AddRule(new ValidateRequired("Code"));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReceiptVoucherEntity"/> class.
        /// </summary>
        /// <param name="receiptVoucherID">The receipt voucher identifier.</param>
        /// <param name="code">The code.</param>
        /// <param name="refDate">The reference date.</param>
        /// <param name="createBy">The create by.</param>
        /// <param name="description">The description.</param>
        /// <param name="totalAmount">The total amount.</param>
        public ReceiptVoucherEntity(int receiptVoucherID, string code, DateTime refDate, string createBy, string description, decimal totalAmount)
            : this()
        {
            ReceiptVoucherID = receiptVoucherID;
            Code = code;
            RefDate = refDate;
            CreateBy = createBy;
            Description = description;
            TotalAmount = totalAmount;
        }
        /// <summary>
        /// Gets or sets the account identifier.
        /// </summary>
        /// <value>
        /// The account identifier.
        /// </value>
        public int ReceiptVoucherID { get; set; }
        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        public string Code { get; set; }
        /// <summary>
        /// Gets or sets the reference date.
        /// </summary>
        /// <value>
        /// The reference date.
        /// </value>
        public DateTime RefDate { get; set; }
        /// <summary>
        /// Gets or sets the create by.
        /// </summary>
        /// <value>
        /// The create by.
        /// </value>
        public string CreateBy { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the total amount.
        /// </summary>
        /// <value>
        /// The total amount.
        /// </value>
        public decimal TotalAmount { get; set; }
        /// <summary>
        /// Gets or sets the receipt voucher details.
        /// </summary>
        /// <value>
        /// The receipt voucher details.
        /// </value>
        public IList<ReceiptVoucherDetailEntity> ReceiptVoucherDetails { get; set; }

        public IList<ReceiptVoucherDetailParalellEntity> ReceiptVoucherDetailParalellDetails { get; set; }
    }
}

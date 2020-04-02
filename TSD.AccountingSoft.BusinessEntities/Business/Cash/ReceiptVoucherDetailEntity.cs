using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TSD.AccountingSoft.BusinessEntities.BusinessRules;

namespace TSD.AccountingSoft.BusinessEntities.Business.Cash
{
    public class ReceiptVoucherDetailEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReceiptVoucherDetailEntity"/> class.
        /// </summary>
        public ReceiptVoucherDetailEntity()
        {
            AddRule(new ValidateRequired("ReceiptVoucherID"));
            AddRule(new ValidateRequired("ItemName"));
        }
        public ReceiptVoucherDetailEntity(int receiptVoucherDetailID, int receiptVoucherID, string itemName, int quantity, decimal amount)
            : this()
        {
            ReceiptVoucherDetailID = receiptVoucherDetailID;
            ReceiptVoucherID = receiptVoucherID;
            ItemName = itemName;
            Quantity = quantity;
            Amount = amount;
        }
        /// <summary>
        /// Gets or sets the receipt voucher detail identifier.
        /// </summary>
        /// <value>
        /// The receipt voucher detail identifier.
        /// </value>
        public int ReceiptVoucherDetailID { get; set; }
        /// <summary>
        /// Gets or sets the receipt voucher identifier.
        /// </summary>
        /// <value>
        /// The receipt voucher identifier.
        /// </value>
        public int ReceiptVoucherID { get; set; }
        /// <summary>
        /// Gets or sets the name of the item.
        /// </summary>
        /// <value>
        /// The name of the item.
        /// </value>
        public string ItemName { get; set; }
        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>
        /// The quantity.
        /// </value>
        public int Quantity { get; set; }
        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public decimal Amount { get; set; }
    }
}

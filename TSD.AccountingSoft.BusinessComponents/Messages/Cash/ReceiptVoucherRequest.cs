using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Business.Cash;

namespace TSD.AccountingSoft.BusinessComponents.Messages.Cash
{
    /// <summary>
    /// 
    /// </summary>
    public class ReceiptVoucherRequest : RequestBase
    {
        /// <summary>
        /// Gets or sets the receipt voucher identifier.
        /// </summary>
        /// <value>
        /// The receipt voucher identifier.
        /// </value>
        public int ReceiptVoucherID { get; set; }
        /// <summary>
        /// Gets or sets the receipt voucher.
        /// </summary>
        /// <value>
        /// The receipt voucher.
        /// </value>
        public ReceiptVoucherEntity ReceiptVoucher { get; set; }
    }
}

using System.Collections.Generic;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Business.Cash;

namespace TSD.AccountingSoft.BusinessComponents.Messages.Cash
{
    /// <summary>
    /// 
    /// </summary>
    public class ReceiptVoucherResponse : ResponseBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReceiptVoucherResponse"/> class.
        /// </summary>
        public ReceiptVoucherResponse() { }
        /// <summary>
        /// The receipt vouchers
        /// </summary>
        public IList<ReceiptVoucherEntity> ReceiptVouchers;
        /// <summary>
        /// The receipt voucher
        /// </summary>
        public ReceiptVoucherEntity ReceiptVoucher;
        /// <summary>
        /// The receipt voucher identifier
        /// </summary>
        public int ReceiptVoucherID;
    }
}

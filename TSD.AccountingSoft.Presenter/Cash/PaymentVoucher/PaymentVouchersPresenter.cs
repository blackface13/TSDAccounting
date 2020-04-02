/***********************************************************************
 * <copyright file="PaymentVouchersPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Hoàng Bích Sơn
 * Email:    sonhb@buca.vn
 * Website:
 * Create Date: Wednesday, March 19, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using TSD.AccountingSoft.View.Cash;


namespace TSD.AccountingSoft.Presenter.Cash.PaymentVoucher
{

    /// <summary>
    /// PaymentVouchersPresenter class
    /// </summary>
    public class PaymentVouchersPresenter: Presenter<IPaymentVouchersView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentVouchersPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public PaymentVouchersPresenter(IPaymentVouchersView view) : base(view)
        {
        }

        /// <summary>
        /// Displays the specified reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        public void Display(int refTypeId)
        {
            View.PaymentVouchers = Model.GetPaymentVoucherByRefTypeId(refTypeId);
        }

        /// <summary>
        /// Displays the voucher detail.
        /// LinhMC add 30.9.2016
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        public void DisplayVoucherDetail(long refId)
        {
            var voucher = Model.GetPaymentVoucher(refId);
            if (voucher != null)
            {
                View.PaymentVoucherDetails = voucher.CashDetails;
            }
        }
    }
}

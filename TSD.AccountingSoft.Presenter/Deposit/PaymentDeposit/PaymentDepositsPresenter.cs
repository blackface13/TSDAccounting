/***********************************************************************
 * <copyright file="PaymentDepositsPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   BangNC
 * Email:    BangNC@buca.vn
 * Website:
 * Create Date: Wednesday, March 19, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using TSD.AccountingSoft.View.Deposit;


namespace TSD.AccountingSoft.Presenter.Deposit.PaymentDeposit
{

    /// <summary>
    /// Class PaymentDepositsPresenter.
    /// </summary>
    public class PaymentDepositsPresenter : Presenter<IPaymentDepositsView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentDepositsPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public PaymentDepositsPresenter(IPaymentDepositsView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays the specified reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        public void Display(int refTypeId)
        {
            View.PaymentDeposits = Model.GetDepositsByRefTypeId(refTypeId);
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            View.PaymentDeposits = Model.GetDeposits();
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void DisplayByDate(int refTypeId, string refDate)
        {
            View.PaymentDeposits = Model.GetDepositsByYearOfPostDate(refTypeId, refDate);
        }

        /// <summary>
        /// Displays the voucher detail.
        /// LinhMC add 30.9.2016
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        public void DisplayVoucherDetail(long refId)
        {
            var voucher = Model.GetDeposit(refId);
            if (voucher != null)
            {
                View.PaymentDepositDetails = voucher.DepositDetails;
            }
        }
    }
}

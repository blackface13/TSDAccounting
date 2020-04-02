using TSD.AccountingSoft.Model.BusinessObjects.Deposit;
using TSD.AccountingSoft.View.Deposit;
using System.Collections.Generic;

namespace TSD.AccountingSoft.Presenter.Deposit.ReceiptDeposit
{
    /// <summary>
    /// Class ReceiptDepositsPresenter.
    /// </summary>
    public class ReceiptDepositsPresenter : Presenter<IReceiptDepositsView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReceiptDepositsPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public ReceiptDepositsPresenter(IReceiptDepositsView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display(int refTypeId)
        {

            View.ReceiptDeposits = Model.GetDepositsByRefTypeId(refTypeId);
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void DisplayByDate(int refTypeId, string refDate)
        {
            View.ReceiptDeposits = Model.GetDepositsByYearOfPostDate(refTypeId, refDate);
        }

        /// <summary>
        /// Displays the voucher detail.
        /// LinhMC add 30.9.2016
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        public void DisplayVoucherDetail(long refId)
        {
            var voucher = Model.GetDeposit(refId) ?? new DepositModel() { DepositDetails = new List<DepositDetailModel>() };
            if (voucher != null)
            {
                View.ReceiptDepositDetails = voucher.DepositDetails;
            }
        }
    }
}

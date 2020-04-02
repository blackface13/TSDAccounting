/***********************************************************************
 * <copyright file="InputInventoriesPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuanMH
 * Email:    TuanMH@buca.vn
 * Website:
 * Create Date: 23 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using TSD.AccountingSoft.Presenter.Cash.PaymentVoucher;
using TSD.AccountingSoft.View.Inventory;


namespace TSD.AccountingSoft.Presenter.Inventory.InputInventory
{
    /// <summary>
    /// InputInventoriesPresenter
    /// </summary>
    public class InputInventoriesPresenter : Presenter<IItemTransactionsView>
    {
          /// <summary>
        /// Initializes a new instance of the <see cref="PaymentVouchersPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
       public InputInventoriesPresenter(IItemTransactionsView view)
           : base(view)
        {
        }

        /// <summary>
        /// Displays the specified reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        public void Display(int refTypeId)
        {
            View.ItemTransactions = Model.GetItemTransactionVoucherByRefTypeId(refTypeId);
        }

        /// <summary>
        /// Displays the voucher detail.
        /// LinhMC add 30.9.2016
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        public void DisplayVoucherDetail(long refId)
        {
            var voucher = Model.GetItemTransactionVoucher(refId);
            if (voucher != null)
            {
                View.ItemTransactionDetails = voucher.ItemTransactionDetails;
            }
        }
    }
}

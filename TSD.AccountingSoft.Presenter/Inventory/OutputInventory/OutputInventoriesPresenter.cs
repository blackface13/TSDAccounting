/***********************************************************************
 * <copyright file="OutputInventoriesPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   BangNC
 * Email:    BangNC@buca.vn
 * Website:
 * Create Date: 11 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using TSD.AccountingSoft.Presenter.Cash.PaymentVoucher;
using TSD.AccountingSoft.View.Inventory;
using System;

namespace TSD.AccountingSoft.Presenter.Inventory.OutputInventory
{
    /// <summary>
    /// InputInventoriesPresenter
    /// </summary>
    public class OutputInventoriesPresenter : Presenter<IItemTransactionsView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentVouchersPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public OutputInventoriesPresenter(IItemTransactionsView view)
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

/***********************************************************************
 * <copyright file="GenveralVouchersPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: 11 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using TSD.AccountingSoft.Model.BusinessObjects.General;
using TSD.AccountingSoft.View.General;

namespace TSD.AccountingSoft.Presenter.General
{
    public class GenveralVouchersPresenter : Presenter<IGeneralVouchersView>
    {
        public GenveralVouchersPresenter(IGeneralVouchersView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays the specified reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        public void Display(int refTypeId)
        {
            View.GeneralVouchers = Model.GetGenverVoucherByRefTypeId(refTypeId);
        }


        public void Display()
        {
            View.GeneralVouchers = Model.GetGenverVoucherByIsCapitalAllocate();
        }

        /// <summary>
        /// Displays the voucher detail.
        /// LinhMC
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        public void DisplayVoucherDetail(long refId)
        {
            var voucher = Model.GetGeneralVoucher(refId);
            if (voucher != null)
            {
                View.GeneralVoucherDetails = voucher.GeneralVoucherDetails;
            }

        }

        /// <summary>
        /// Deletes the specified reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        public long Delete(long refId)
        {
            return Model.DeleteGeneralVoucher(refId);
        }

    }
}

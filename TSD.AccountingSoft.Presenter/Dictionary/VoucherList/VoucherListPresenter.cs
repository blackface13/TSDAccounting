/***********************************************************************
 * <copyright file="VoucherListPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Hoàng Bích Sơn
 * Email:    sonhb@buca.vn
 * Website:
 * Create Date: Saturday, March 8, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.View.Dictionary;


namespace TSD.AccountingSoft.Presenter.Dictionary.VoucherList
{

    /// <summary>
    /// VoucherListPresenter class
    /// </summary>
    public class VoucherListPresenter : Presenter<IVoucherListView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VoucherListPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public VoucherListPresenter(IVoucherListView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays the specified voucher identifier.
        /// </summary>
        /// <param name="voucherId">The voucher identifier.</param>
        public void Display(string voucherId)
        {
            if (voucherId == null) { View.VoucherListId = 0; return; }
            var voucher = Model.GetVoucherList(int.Parse(voucherId));
            View.VoucherListId = voucher.VoucherListId;
            View.VoucherListCode = voucher.VoucherListCode;
            View.VoucherDate = voucher.VoucherDate;
            View.PostDate = voucher.PostDate;
            View.Description = voucher.Description;
            View.DocAttach = voucher.DocAttach;
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        public int Save()
        {
            var voucher = new VoucherListModel
                {
                    VoucherListId = View.VoucherListId,
                    VoucherListCode = View.VoucherListCode,
                    VoucherDate = View.VoucherDate,
                    PostDate = View.PostDate,
                    Description = View.Description,
                    DocAttach = View.DocAttach,
                };
            return View.VoucherListId == 0 ? Model.InsertVoucherList(voucher) : Model.UpdateVoucherList(voucher);
        }

        /// <summary>
        /// Deletes the specified accont identifier.
        /// </summary>
        /// <param name="voucherListId">The voucher list identifier.</param>
        /// <returns></returns>
        public int Delete(int voucherListId)
        {
            return Model.DeleteVoucherList(voucherListId);
        }
    }
}

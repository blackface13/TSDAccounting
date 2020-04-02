/***********************************************************************
 * <copyright file="GenveralVoucherPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: 28 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using TSD.AccountingSoft.Model.BusinessObjects.General;
using TSD.AccountingSoft.View.General;

namespace TSD.AccountingSoft.Presenter.General
{
   public class GenveralVoucherPresenter:Presenter<IGeneralVoucherView>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="GenveralVoucherPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
       public GenveralVoucherPresenter(IGeneralVoucherView view)
            : base(view)
        {
        }

       /// <summary>
       /// Saves this instance.
       /// </summary>
       /// <returns></returns>
       public long Save(bool isGenerateParalell=false)
       {
            var voucher = new GeneralVocherModel
            {
                RefId = View.RefId,
                RefTypeId = View.RefTypeId,
                RefNo = View.RefNo,
                RefDate = View.RefDate,
                JournalMemo = View.JournalMemo,
                GeneralVoucherDetails = View.GeneralDetails,
                PostedDate = View.PostedDate,
                TotalAmountExchange = View.TotalAmountExchange,
                TotalAmountOc = View.TotalAmountOc,
                DepositId = View.DepositId,
                CashId = View.CashId,
               GeneralParalellDetails = View.GeneralParalellDetails
           };
           return View.RefId == 0 ? Model.AddGeneralVoucher(voucher, isGenerateParalell) : Model.UpdateGeneralVoucher(voucher, isGenerateParalell);
       }

        /// <summary>
        /// Displays the specified reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        public void Display(long refId)
        {
            var voucher = Model.GetGeneralVoucher(refId);
            View.RefId = voucher.RefId;
            View.RefTypeId = voucher.RefTypeId;
            View.RefNo = voucher.RefNo;
            View.PostedDate = voucher.PostedDate;
            View.RefDate = voucher.RefDate;
            View.JournalMemo = voucher.JournalMemo;
            View.TotalAmountExchange = voucher.TotalAmountExchange;
            View.TotalAmountOc = voucher.TotalAmountOc;
            View.GeneralDetails = voucher.GeneralVoucherDetails;
            View.GeneralParalellDetails = voucher.GeneralParalellDetails;
            View.DepositId = voucher.DepositId;
            View.CashId = voucher.CashId;
        }

        public void Display(GeneralVocherModel voucher)
        {
            View.RefId = voucher.RefId;
            View.RefTypeId = voucher.RefTypeId;
            View.RefNo = voucher.RefNo;
            View.RefDate = voucher.RefDate;
            View.PostedDate = voucher.PostedDate;
            View.JournalMemo = voucher.JournalMemo;
            View.TotalAmountExchange = voucher.TotalAmountExchange;
            View.TotalAmountOc = voucher.TotalAmountOc;
            View.DepositId = voucher.DepositId;
            View.GeneralDetails = voucher.GeneralVoucherDetails;
            View.GeneralParalellDetails = voucher.GeneralParalellDetails;
            View.CashId = voucher.CashId;
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

        public GeneralVocherModel GetGeneralVocher(int refType, long refForeignId)
        {
            return Model.GetGeneralVoucher(refType, refForeignId);
        }


    }
}

/***********************************************************************
 * <copyright file="PaymentVoucherPresenter.cs" company="BUCA JSC">
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

using TSD.AccountingSoft.Model.BusinessObjects.Cash;
using TSD.AccountingSoft.View.Cash;


namespace TSD.AccountingSoft.Presenter.Cash.PaymentVoucher
{

    /// <summary>
    /// PaymentVoucherPresenter class
    /// </summary>
    public class PaymentVoucherPresenter : Presenter<IPaymentVoucherView>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentVoucherPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public PaymentVoucherPresenter(IPaymentVoucherView view)
            : base(view)
        {
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        public long Save(bool isGenerateParalell)
        {            
            var voucher = new CashModel
            {
                CashDetails = View.PaymentVoucherDetails,
                CashParalellDetails = View.CashParalellDetails,
                RefId = View.RefId,
                RefTypeId = View.RefTypeId,
                RefNo = View.RefNo,
                PostedDate = View.PostedDate,
                RefDate = View.RefDate,
                AccountingObjectId = View.AccountingObjectId,
                CustomerId = View.CustomerId,
                VendorId = View.VendorId,
                EmployeeId = View.EmployeeId,
                Trader = View.Trader,
                CurrencyCode = View.CurrencyCode,
                AccountNumber = View.AccountNumber,
                TotalAmount = View.TotalAmount,
                ExchangeRate = View.ExchangeRate,
                TotalAmountExchange = View.TotalAmountExchange,
                JournalMemo = View.JournalMemo,
                DocumentInclude = View.DocumentInclude,
                AccountingObjectType = View.AccountingObjectType,
                BankId = View.BankId,
                BankAccount = View.BankAccount
            };
            return View.RefId == 0 ? Model.AddPaymentVoucher(voucher,isGenerateParalell) : Model.UpdatePaymentVoucher(voucher,isGenerateParalell);
        }

        /// <summary>
        /// Displays the specified reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        public void Display(long refId)
        {
            var voucher = Model.GetPaymentVoucher(refId);
            
            View.RefId = voucher.RefId;
            View.RefTypeId = voucher.RefTypeId;
            View.RefNo = voucher.RefNo;
            View.PostedDate = voucher.PostedDate;
            View.RefDate = voucher.RefDate;
            View.AccountingObjectType = voucher.AccountingObjectType;
            View.AccountingObjectId = voucher.AccountingObjectId == 0 ? null : voucher.AccountingObjectId;
            View.CustomerId = voucher.CustomerId == 0 ? null : voucher.CustomerId;
            View.VendorId = voucher.VendorId == 0 ? null : voucher.VendorId;            
            View.EmployeeId = voucher.EmployeeId == 0 ? null : voucher.EmployeeId;
            View.Trader = voucher.Trader;
            View.CurrencyCode = voucher.CurrencyCode;
            View.AccountNumber = voucher.AccountNumber;
            View.TotalAmount = voucher.TotalAmount;
            View.ExchangeRate = voucher.ExchangeRate;
            View.TotalAmountExchange = voucher.TotalAmountExchange;
            View.JournalMemo = voucher.JournalMemo;
            View.DocumentInclude = voucher.DocumentInclude;
            View.BankId = voucher.BankId;
            View.BankAccount = voucher.BankAccount;
            View.PaymentVoucherDetails = voucher.CashDetails;
            View.CashParalellDetails = voucher.CashParalellDetails;
        }

        /// <summary>
        /// Deletes the specified reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        public long Delete(long refId)
        {
            return Model.DeletePaymentVoucher(refId);
        }

        /// <summary>
        /// Gets the payment voucher by identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        public CashModel GetPaymentVoucherById(long refId)
        {
            return Model.GetPaymentVoucher(refId);
        }
    }
}

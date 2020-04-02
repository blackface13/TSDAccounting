/***********************************************************************
 * <copyright file="ReceiptVoucherPresenter.cs" company="BUCA JSC">
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

using System;
using TSD.AccountingSoft.Model.BusinessObjects.Cash;
using TSD.AccountingSoft.View.Cash;


namespace TSD.AccountingSoft.Presenter.Cash.ReceiptVoucher
{

    /// <summary>
    /// ReceiptVoucherPresenter
    /// </summary>
 public   class ReceiptVoucherPresenter : Presenter<IReceiptVoucherView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReceiptVoucherPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public ReceiptVoucherPresenter(IReceiptVoucherView view)
            : base(view)
        {
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        public long Save(bool isAutoGenerateParallel)
        {
            var voucher = new ReceiptVoucherModel
            {
                ReceiptVoucherDetails = View.ReceiptVoucherDetails,
                ReceiptVoucherDetailParalells = View.ReceiptVoucherDetailParalells,
                AccountingObjectType = View.AccountingObjectType,
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
                BankId = View.BankId,
                BankAccount = View.BankAccount,
                DocumentInclude = View.DocumentInclude,
                IsIncludeCharge = View.IsIncludeCharge
            };
            return View.RefId == 0 ? Model.AddReceiptVoucher(voucher,isAutoGenerateParallel) : Model.UpdateReceiptVoucher(voucher,isAutoGenerateParallel);
        }

        /// <summary>
        /// Displays the specified reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        public void Display(long refId)
        {
            var voucher = Model.GetReceiptVoucher(refId);
            View.RefId = voucher.RefId;
            View.RefTypeId = voucher.RefTypeId;
            View.RefNo =  voucher.RefNo;
            View.PostedDate = voucher.PostedDate;
            View.RefDate =  voucher.RefDate;
            View.AccountingObjectType = voucher.AccountingObjectType;
            try
            {
                View.AccountingObjectId = voucher.AccountingObjectId == 0 ? null : voucher.AccountingObjectId;
                View.CustomerId = voucher.CustomerId == 0 ? null : voucher.CustomerId;
                View.VendorId = voucher.VendorId == 0 ? null : voucher.VendorId;
                View.EmployeeId = voucher.EmployeeId == 0 ? null : voucher.EmployeeId;
            }
            catch
            {
                View.AccountingObjectId = View.AccountingObjectId;
                View.CustomerId = View.CustomerId;
                View.VendorId = View.VendorId;
                View.EmployeeId = View.EmployeeId;

            }
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
            View.IsIncludeCharge = voucher.IsIncludeCharge;
            View.ReceiptVoucherDetails = voucher.ReceiptVoucherDetails;
            View.ReceiptVoucherDetailParalells = voucher.ReceiptVoucherDetailParalells;
        }

        /// <summary>
        /// Deletes the specified reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        public long Delete(long refId)
        {
            return Model.DeleteReceiptVoucher(refId);
        }


        /// <summary>
        /// Gets the receipt voucher by identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        public ReceiptVoucherModel GetReceiptVoucherById(long refId)
        {
            return Model.GetReceiptVoucher(refId);
        }


    }
}

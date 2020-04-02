/***********************************************************************
 * <copyright file="PaymentDepositPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   BangNC
 * Email:    BangNC@buca.vn
 * Website:
 * Create Date: Friday, March 21, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using TSD.AccountingSoft.View.Deposit;
using TSD.AccountingSoft.Model.BusinessObjects.Deposit;


namespace TSD.AccountingSoft.Presenter.Deposit.PaymentDeposit
{
    /// <summary>
    /// PaymentDepositPresenter
    /// </summary>
    public class PaymentDepositPresenter : Presenter<IPaymentDepositView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentDepositPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public PaymentDepositPresenter(IPaymentDepositView view)
            : base(view)
        {
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        public long Save()
        {
            var deposit = new DepositModel
            {
                DepositDetails = View.DepositDetails,
                RefId = View.RefId,
                RefTypeId = View.RefTypeId,
                PostedDate = View.PostedDate,
                RefDate = View.RefDate,
                RefNo = View.RefNo,
                AccountingObjectType = View.AccountingObjectType,
                AccountingObjectId = View.AccountingObjectId,
                Trader = View.Trader,
                CustomerId = View.CustomerId,
                VendorId = View.VendorId,
                EmployeeId = View.EmployeeId,
                BankAccountCode = View.BankAccountCode,
                CurrencyCode = View.CurrencyCode,
                ExchangeRate = View.ExchangeRate,
                TotalAmountOc = View.TotalAmountOc,
                TotalAmountExchange = View.TotalAmountExchange,
                JournalMemo = View.JournalMemo,
                BankId = View.BankId,
                DepositDetailParallels = View.DepositDetailParallels
            };
            if (View.RefId == 0)
                return Model.AddDeposit(deposit);
            return Model.UpdateDeposit(deposit);
        }

        public long Save(bool isAutoGenerateParallel)
        {
            var deposit = new DepositModel
            {
                DepositDetails = View.DepositDetails,
                RefId = View.RefId,
                RefTypeId = View.RefTypeId,
                PostedDate = View.PostedDate,
                RefDate = View.RefDate,
                RefNo = View.RefNo,
                AccountingObjectType = View.AccountingObjectType,
                AccountingObjectId = View.AccountingObjectId,
                Trader = View.Trader,
                CustomerId = View.CustomerId,
                VendorId = View.VendorId,
                EmployeeId = View.EmployeeId,
                BankAccountCode = View.BankAccountCode,
                CurrencyCode = View.CurrencyCode,
                ExchangeRate = View.ExchangeRate,
                TotalAmountOc = View.TotalAmountOc,
                TotalAmountExchange = View.TotalAmountExchange,
                JournalMemo = View.JournalMemo,
                BankId = View.BankId,
                DepositDetailParallels = View.DepositDetailParallels
            };
            if (View.RefId == 0)
                return Model.AddDeposit(deposit, isAutoGenerateParallel);
            return Model.UpdateDeposit(deposit, isAutoGenerateParallel);
        }

        /// <summary>
        /// Displays the specified reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        public void Display(long refId)
        {
            var deposit = Model.GetDeposit(refId);

            View.RefId = deposit.RefId;
            View.RefTypeId = deposit.RefTypeId;
            View.PostedDate = deposit.PostedDate;
            View.RefDate = deposit.RefDate;
            View.RefNo = deposit.RefNo;
            View.CurrencyCode = deposit.CurrencyCode;
            View.Trader = deposit.Trader;
            View.AccountingObjectType = deposit.AccountingObjectType;
            View.AccountingObjectId = deposit.AccountingObjectId;
            View.CustomerId = deposit.CustomerId;
            View.VendorId = deposit.VendorId;
            View.EmployeeId = deposit.EmployeeId;
            View.BankAccountCode = deposit.BankAccountCode;
            View.CurrencyCode = deposit.CurrencyCode;
            View.ExchangeRate = deposit.ExchangeRate;
            View.TotalAmountOc = deposit.TotalAmountOc;
            View.TotalAmountExchange = deposit.TotalAmountExchange;
            View.JournalMemo = deposit.JournalMemo;
            View.BankId = deposit.BankId;
            View.DepositDetails = deposit.DepositDetails;
            View.DepositDetailParallels = deposit.DepositDetailParallels;
        }

        /// <summary>
        /// Deletes the specified reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        public long Delete(long refId)
        {
            return Model.DeleteDeposit(refId);
        }
    }
}

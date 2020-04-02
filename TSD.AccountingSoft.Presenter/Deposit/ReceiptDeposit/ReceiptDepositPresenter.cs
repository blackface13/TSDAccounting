using System;
using TSD.AccountingSoft.View.Deposit;
using TSD.AccountingSoft.Model.BusinessObjects.Deposit;

namespace TSD.AccountingSoft.Presenter.Deposit.ReceiptDeposit
{
    public class ReceiptDepositPresenter : Presenter<IReceiptDepositView>
    {
        public ReceiptDepositPresenter(IReceiptDepositView view)
            : base(view)
        {
        }

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
                //AccountingObjectId = View.AccountingObjectId,
                Trader = View.Trader,
                //CustomerId = View.CustomerId == 0 ? null : View.CustomerId,
                //VendorId = View.VendorId == 0 ? null : View.VendorId,
                //EmployeeId = View.EmployeeId == 0 ? null : View.EmployeeId,
                AccountingObjectId =  View.AccountingObjectId,
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
                IsIncludeCharge = View.IsIncludeCharge
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
                //AccountingObjectId = View.AccountingObjectId,
                Trader = View.Trader,
                //CustomerId = View.CustomerId == 0 ? null : View.CustomerId,
                //VendorId = View.VendorId == 0 ? null : View.VendorId,
                //EmployeeId = View.EmployeeId == 0 ? null : View.EmployeeId,
                AccountingObjectId = View.AccountingObjectId,
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
                IsIncludeCharge = View.IsIncludeCharge,
                DepositDetailParallels = View.DepositDetailParallels
            };
            if (View.RefId == 0)
                return Model.AddDeposit(deposit, isAutoGenerateParallel);
            return Model.UpdateDeposit(deposit, isAutoGenerateParallel);
        }

        public void Display(long refId)
        {
            var deposit = Model.GetDeposit(refId);

            View.RefId = deposit.RefId;
            View.RefTypeId = deposit.RefTypeId;
            View.PostedDate = deposit.PostedDate;
            View.RefDate = deposit.RefDate;
            View.RefNo = deposit.RefNo;
            View.AccountingObjectType = deposit.AccountingObjectType;
            View.CurrencyCode = deposit.CurrencyCode;
            View.Trader = deposit.Trader;
            View.JournalMemo = deposit.JournalMemo;
            View.CustomerId = deposit.CustomerId == 0 ? null : deposit.CustomerId;
            View.AccountingObjectId = deposit.AccountingObjectId == 0 ? null : deposit.AccountingObjectId;
            View.VendorId = deposit.VendorId == 0 ? null : deposit.VendorId;
            View.EmployeeId = deposit.EmployeeId == 0 ? null : deposit.EmployeeId;
            View.BankAccountCode = deposit.BankAccountCode;
            View.ExchangeRate = deposit.ExchangeRate;
            View.TotalAmountOc = deposit.TotalAmountOc;
            View.TotalAmountExchange = deposit.TotalAmountExchange;
            View.BankId = deposit.BankId;
            View.DepositDetails = deposit.DepositDetails;
            View.IsIncludeCharge = deposit.IsIncludeCharge;
            View.DepositDetailParallels = deposit.DepositDetailParallels;
        }

        public long Delete(long refId)
        {
            return Model.DeleteDeposit(refId);
        }

        public DepositModel GetById(long depositId)
        {
            return Model.GetDeposit(depositId);
        }
    }
}

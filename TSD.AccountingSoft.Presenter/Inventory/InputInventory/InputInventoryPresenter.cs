/***********************************************************************
 * <copyright file="InputInventoryPresenter.cs" company="BUCA JSC">
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

using TSD.AccountingSoft.Model.BusinessObjects.Inventory;
using TSD.AccountingSoft.View.Inventory;


namespace TSD.AccountingSoft.Presenter.Inventory.InputInventory
{
    public class InputInventoryPresenter : Presenter<IItemTransactionView>    
    {
       public InputInventoryPresenter(IItemTransactionView view)
            : base(view)
        {
        }

        public long Save(bool isAutoGenerateParallel)
        {
            var voucher = new ItemTransactionModel
            {
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
                StockId = View.StockId,
                TotalAmount = View.TotalAmount,
                ExchangeRate = View.ExchangeRate,
                TotalAmountExchange = View.TotalAmountExchange,
                JournalMemo = View.JournalMemo,
                DocumentInclude = View.DocumentInclude,
                AccountingObjectType = View.AccountingObjectType,
                TaxCode = View.TaxCode,
                BankId = View.BankId,
                ItemTransactionDetails = View.ItemTransactionDetails,
                ItemTransactionDetailParallels = View.ItemTransactionDetailParallels
            };
            return View.RefId == 0 ? Model.AddItemTransactionVoucher(voucher, isAutoGenerateParallel) : Model.UpdateItemTransactionVoucher(voucher, isAutoGenerateParallel);
        }

        public void Display(long refId)
        {
            var voucher = Model.GetItemTransactionVoucher(refId);
            
            View.RefId = voucher.RefId;
            View.RefTypeId = voucher.RefTypeId;
            View.RefNo = voucher.RefNo;
            View.PostedDate = voucher.PostedDate;
            View.RefDate = voucher.RefDate;
            View.AccountingObjectType = voucher.AccountingObjectType;
            if (voucher.AccountingObjectId == 0)
            {
                View.AccountingObjectId = null;
            }
            else
            {
                View.AccountingObjectId = voucher.AccountingObjectId;
            }
         //   View.AccountingObjectId = voucher.AccountingObjectId == 0 ? null : voucher.AccountingObjectId;
            View.CustomerId = voucher.CustomerId == 0 ? null : voucher.CustomerId;
            View.VendorId = voucher.VendorId == 0 ? null : voucher.VendorId;            
            View.EmployeeId = voucher.EmployeeId == 0 ? null : voucher.EmployeeId;
            View.Trader = voucher.Trader;
            View.CurrencyCode = voucher.CurrencyCode;
            View.StockId = voucher.StockId;
            View.TotalAmount = voucher.TotalAmount;
            View.ExchangeRate = voucher.ExchangeRate;
            View.TotalAmountExchange = voucher.TotalAmountExchange;
            View.JournalMemo = voucher.JournalMemo;
            View.DocumentInclude = voucher.DocumentInclude;
            View.TaxCode = voucher.TaxCode;
            View.BankId = voucher.BankId;
            View.ItemTransactionDetails = voucher.ItemTransactionDetails;
            View.ItemTransactionDetailParallels = voucher.ItemTransactionDetailParallels;
        }

        public long Delete(long refId)
        {
            return Model.DeleteItemTransactionVoucher(refId);
        }

        public ItemTransactionModel GetItemTransactionById(long refId)
        {
            return Model.GetItemTransactionVoucher(refId);
        }
    }
}

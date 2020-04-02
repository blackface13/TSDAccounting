/***********************************************************************
 * <copyright file="OutputInventoryPresenter.cs" company="BUCA JSC">
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

using TSD.AccountingSoft.Model.BusinessObjects.Inventory;
using TSD.AccountingSoft.View.Inventory;
using System;

namespace TSD.AccountingSoft.Presenter.Inventory.OutputInventory
{
    /// <summary>
    /// OutputInventoryPresenter
    /// </summary>
    public class OutputInventoryPresenter : Presenter<IItemTransactionView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OutputInventoryPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public OutputInventoryPresenter(IItemTransactionView view)
            : base(view)
        {
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
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
                BankId = View.BankId,
                ItemTransactionDetails = View.ItemTransactionDetails,
                ItemTransactionDetailParallels = View.ItemTransactionDetailParallels
            };
            return View.RefId == 0 ? Model.AddItemTransactionVoucher(voucher, isAutoGenerateParallel) : Model.UpdateItemTransactionVoucher(voucher, isAutoGenerateParallel);
        }

        /// <summary>
        /// Displays the specified reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        public void Display(long refId)
        {
            var voucher = Model.GetItemTransactionVoucher(refId);

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
            View.StockId = voucher.StockId;
            View.TotalAmount = voucher.TotalAmount;
            View.ExchangeRate = voucher.ExchangeRate;
            View.TotalAmountExchange = voucher.TotalAmountExchange;
            View.JournalMemo = voucher.JournalMemo;
            View.DocumentInclude = voucher.DocumentInclude;
            View.BankId = voucher.BankId;
            View.ItemTransactionDetails = voucher.ItemTransactionDetails;
            View.ItemTransactionDetailParallels = voucher.ItemTransactionDetailParallels;
        }

        /// <summary>
        /// Deletes the specified reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        public long Delete(long refId)
        {
            return Model.DeleteItemTransactionVoucher(refId);
        }

        public decimal GetQuantityOfInventory(int inventoryItemId, int stockId, DateTime postDate, long refID, string currencyCode)
        {
            return Model.GetQuantityOfInventory(inventoryItemId, stockId, postDate, refID, currencyCode);
        }

        /// <summary>
        /// Gets the payment voucher by identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        public ItemTransactionModel GetItemTransactionById(long refId)
        {
            return Model.GetItemTransactionVoucher(refId);
        }
    }
}

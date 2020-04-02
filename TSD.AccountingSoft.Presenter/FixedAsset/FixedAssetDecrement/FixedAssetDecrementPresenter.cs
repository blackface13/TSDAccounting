/***********************************************************************
 * <copyright file="FixedAssetDecrementPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Thursday, April 10, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  07/03/2014       Author    Tudt           Description: Coding standard
 * 
 * ************************************************************************/

using TSD.AccountingSoft.View.FixedAsset;
using TSD.AccountingSoft.Model.BusinessObjects.FixedAsset;


namespace TSD.AccountingSoft.Presenter.FixedAsset.FixedAssetDecrement
{
    /// <summary>
    /// class FixedAssetDecrementPresenter
    /// </summary>
    public class FixedAssetDecrementPresenter : Presenter<IFixedAssetDecrementView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FixedAssetDecrementPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public FixedAssetDecrementPresenter(IFixedAssetDecrementView view)
            : base(view)
        {
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        public long Save(bool isAutoGenerateParallel)
        {
            var fixedAssetDecrement = new FixedAssetDecrementModel
            {
                FixedAssetDecrementDetails = View.FixedAssetDecrementDetails,
                RefId = View.RefId,
                RefTypeId = View.RefTypeId,
                PostedDate = View.PostedDate,
                RefDate = View.RefDate,
                RefNo = View.RefNo,
                AccountingObjectType = View.AccountingObjectType,
                AccountingObjectId = View.AccountingObjectId,
                CustomerId = View.CustomerId,
                VendorId = View.VendorId,
                EmployeeId = View.EmployeeId,
                CurrencyCode = View.CurrencyCode,
                ExchangeRate = View.ExchangeRate,
                TotalAmountOC = View.TotalAmountOc,
                TotalAmountExchange = View.TotalAmountExchange,
                JournalMemo = View.JournalMemo,
                DocumentInclude = View.DocumentInclude,
                Trader = View.Trader,
                BankId = View.BankId,
                FixedAssetDecrementDetailParallels = View.FixedAssetDecrementDetailParallels
            };
            return View.RefId == 0 ? Model.AddFixedAssetDecrement(fixedAssetDecrement, isAutoGenerateParallel) : Model.UpdateFixedAssetDecrement(fixedAssetDecrement, isAutoGenerateParallel);
        }

        /// <summary>
        /// Displays the specified reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        public void Display(long refId)
        {
            var faDecrement = Model.GetFixedAssetDecrement(refId);

            View.RefId = faDecrement.RefId;
            View.RefTypeId = faDecrement.RefTypeId;
            View.PostedDate = faDecrement.PostedDate;
            View.RefDate = faDecrement.RefDate;
            View.RefNo = faDecrement.RefNo;
            View.AccountingObjectType = faDecrement.AccountingObjectType; 
            View.CurrencyCode = faDecrement.CurrencyCode;
            View.CustomerId = faDecrement.CustomerId == 0 ? null : faDecrement.CustomerId;
            View.AccountingObjectId = faDecrement.AccountingObjectId == 0 ? null : faDecrement.AccountingObjectId;
            View.VendorId = faDecrement.VendorId == 0 ? null : faDecrement.VendorId;
            View.EmployeeId = faDecrement.EmployeeId == 0 ? null : faDecrement.EmployeeId;
            View.ExchangeRate = faDecrement.ExchangeRate;
            View.TotalAmountOc = faDecrement.TotalAmountOC;
            View.TotalAmountExchange = faDecrement.TotalAmountExchange;
            View.JournalMemo = faDecrement.JournalMemo;
            View.FixedAssetDecrementDetails = faDecrement.FixedAssetDecrementDetails;
            View.DocumentInclude = faDecrement.DocumentInclude;
            View.Trader = faDecrement.Trader;
            View.BankId = faDecrement.BankId;
            View.FixedAssetDecrementDetailParallels = faDecrement.FixedAssetDecrementDetailParallels;
        }

        /// <summary>
        /// Deletes the specified reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        public long Delete(long refId)
        {
            return Model.DeleteFixedAssetDecrement(refId);
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        public FixedAssetDecrementModel GetFixedAssetDecrement(long refId)
        {
            return Model.GetFixedAssetDecrement(refId);

        }

        
    }
}

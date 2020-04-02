using System.Collections.Generic;
using TSD.AccountingSoft.View.FixedAsset;
using TSD.AccountingSoft.Model.BusinessObjects.FixedAsset;

namespace TSD.AccountingSoft.Presenter.FixedAsset.FixedAssetIncrement
{
    public class FixedAssetIncrementPresenter : Presenter<IFixedAssetIncrementView>
    {
        public FixedAssetIncrementPresenter(IFixedAssetIncrementView view)
            : base(view)
        {
        }

        public long Save(bool isGenerateParalell)
        {
            var fAIncrement = new FixedAssetIncrementModel();
            fAIncrement.FixedAssetIncrementDetails = View.FixedAssetIncrementDetails;
            fAIncrement.FixedAssetIncrementDetailParallels = View.FixedAssetIncrementDetailParallels;
            fAIncrement.RefId = View.RefId;
            fAIncrement.RefTypeId = View.RefTypeId;
            fAIncrement.PostedDate = View.PostedDate;
            fAIncrement.RefDate = View.RefDate;
            fAIncrement.RefNo = View.RefNo;
            fAIncrement.AccountingObjectType = View.AccountingObjectType;
            fAIncrement.AccountingObjectId = View.AccountingObjectId;
            fAIncrement.CustomerId = View.CustomerId;
            fAIncrement.VendorId = View.VendorId;
            fAIncrement.EmployeeId = View.EmployeeId;
            fAIncrement.Trader = View.Trader;
            fAIncrement.DocumentInclude = View.DocumentInclude;
            fAIncrement.CurrencyCode = View.CurrencyCode;
            fAIncrement.ExchangeRate = View.ExchangeRate;
            fAIncrement.TotalAmountOC = View.TotalAmountOC;
            fAIncrement.TotalAmountExchange = View.TotalAmountExchange;
            fAIncrement.JournalMemo = View.JournalMemo;
            fAIncrement.BankId = View.BankId;

            if (View.RefId == 0)
                return Model.AddFixedAssetIncrement(fAIncrement, isGenerateParalell);
            return Model.UpdateFixedAssetIncrement(fAIncrement, isGenerateParalell);
        }

        public void Display(long refId)
        {
            var fAIncrement = Model.GetFixedAssetIncrement(refId) ?? new FixedAssetIncrementModel()
            {
                FixedAssetIncrementDetailParallels = new List<FixedAssetIncrementDetailParallelModel>(),
                FixedAssetIncrementDetails = new List<FixedAssetIncrementDetailModel>()
            };

            View.RefId = fAIncrement.RefId;
            View.RefTypeId = fAIncrement.RefTypeId;
            View.PostedDate = fAIncrement.PostedDate;
            View.RefDate = fAIncrement.RefDate;
            View.RefNo = fAIncrement.RefNo;
            View.AccountingObjectType = fAIncrement.AccountingObjectType;
            View.CurrencyCode = fAIncrement.CurrencyCode;
            View.CustomerId = fAIncrement.CustomerId == 0 ? null : fAIncrement.CustomerId;
            View.AccountingObjectId = fAIncrement.AccountingObjectId == 0 ? null : fAIncrement.AccountingObjectId;
            View.VendorId = fAIncrement.VendorId == 0 ? null : fAIncrement.VendorId;
            View.EmployeeId = fAIncrement.EmployeeId == 0 ? null : fAIncrement.EmployeeId;
            View.Trader = fAIncrement.Trader;
            View.DocumentInclude = fAIncrement.DocumentInclude;
            View.ExchangeRate = fAIncrement.ExchangeRate;
            View.TotalAmountOC = fAIncrement.TotalAmountOC;
            View.TotalAmountExchange = fAIncrement.TotalAmountExchange;
            View.JournalMemo = fAIncrement.JournalMemo;
            View.BankId = fAIncrement.BankId;
            View.FixedAssetIncrementDetails = fAIncrement.FixedAssetIncrementDetails;
            View.FixedAssetIncrementDetailParallels = fAIncrement.FixedAssetIncrementDetailParallels;
        }

        public long Delete(long refId)
        {
            return Model.DeleteFixedAssetIncrement(refId);
        }

        public FixedAssetIncrementModel GetById(long refId)
        {
            return Model.GetFixedAssetIncrement(refId);
        }
    }
}

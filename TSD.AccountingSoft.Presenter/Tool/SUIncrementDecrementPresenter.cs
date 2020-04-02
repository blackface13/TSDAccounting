using TSD.AccountingSoft.Model.BusinessObjects.Tool;
using TSD.AccountingSoft.View.Tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.Presenter.Tool
{
    public class SUIncrementDecrementPresenter : Presenter<ISUIncrementDecrementView>
    {
        public SUIncrementDecrementPresenter(ISUIncrementDecrementView view) : base(view)
        {
        }

        public void Display(long refId, bool hasDetail)
        {
            var sUIncrementDecrement = Model.GetSUIncrementDecrement(refId, hasDetail) ?? new SUIncrementDecrementModel();

            View.RefId = sUIncrementDecrement.RefId;
            View.RefType = sUIncrementDecrement.RefType;
            View.PostedDate = sUIncrementDecrement.PostedDate;
            View.RefDate = sUIncrementDecrement.RefDate;
            View.RefNo = sUIncrementDecrement.RefNo;
            View.JournalMemo = sUIncrementDecrement.JournalMemo;
            View.CurrencyCode = sUIncrementDecrement.CurrencyCode;
            View.ExchangeRate = sUIncrementDecrement.ExchangeRate;
            View.TotalAmountOc = sUIncrementDecrement.TotalAmountOc;
            View.TotalAmountExchange = sUIncrementDecrement.TotalAmountExchange;
            View.SUIncrementDecrementDetails = sUIncrementDecrement.SUIncrementDecrementDetails;
        }

        public long Save()
        {
            var sUIncrementDecrement = new SUIncrementDecrementModel
            {
                RefId = View.RefId,
                RefType = View.RefType,
                RefDate = View.RefDate,
                PostedDate = View.PostedDate,
                RefNo = View.RefNo,
                JournalMemo = View.JournalMemo,
                CurrencyCode = View.CurrencyCode,
                ExchangeRate = View.ExchangeRate,
                TotalAmountOc = View.TotalAmountOc,
                TotalAmountExchange = View.TotalAmountExchange,
                SUIncrementDecrementDetails = View.SUIncrementDecrementDetails
            };
            if (View.RefId == 0)
                return Model.AddSUIncrementDecrement(sUIncrementDecrement);
            return Model.UpdateSUIncrementDecrement(sUIncrementDecrement);
        }

        public long Delete(long refId)
        {
            return Model.DeleteSUIncrementDecrement(refId);
        }

        public decimal GetQuantity(int inventoryItemId, int departmentId)
        {
            string currencyCode = View.CurrencyCode;
            long refId = View.RefId;
            DateTime postedDate = View.PostedDate;
            return Model.GetSUIncrementDecrementQuantity(currencyCode, inventoryItemId, departmentId, refId, postedDate);
        }
    }
}

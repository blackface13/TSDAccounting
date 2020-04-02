/***********************************************************************
 * <copyright file="ReceiptEstimatePresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 19 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using TSD.AccountingSoft.View.Estimate;
using TSD.AccountingSoft.Model.BusinessObjects.Estimate;


namespace TSD.AccountingSoft.Presenter.Estimate.ReceiptEstimate
{
    /// <summary>
    /// class ReceiptEstimatePresenter
    /// </summary>
    public class ReceiptEstimatePresenter : Presenter<IReceiptEstimateView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReceiptEstimatePresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public ReceiptEstimatePresenter(IReceiptEstimateView view)
            : base(view)
        {
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        public long Save()
        {
            var estimate = new EstimateModel
                {
                    RefId = View.RefId,
                    RefNo = View.RefNo,
                    RefDate = View.RefDate,
                    PostedDate = View.PostedDate,
                    RefTypeId = View.RefTypeId,
                    PlanTemplateListId = View.PlanTemplateListId,
                    CurrencyCode = View.CurrencyCode,
                    ExchangeRate = View.ExchangeRate,
                    YearOfPlaning = View.YearOfPlaning,
                    JournalMemo = View.JournalMemo,
                    EstimateDetails = View.ReceiptEstimateDetails,
                    NextYearOfTotalEstimateAmount = View.NextYearOfTotalEstimateAmount,
                    TotalEstimateAmount = View.TotalEstimateAmount
                };
            return View.RefId == 0 ? Model.AddEstimate(estimate) : Model.UpdateEstimate(estimate);
        }

        /// <summary>
        /// Displays the specified reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        public void Display(long refId)
        {
            var estimate = Model.GetEstimate(refId);

            View.RefId = estimate.RefId;
            View.RefNo = estimate.RefNo;
            View.PostedDate = estimate.PostedDate;
            View.RefDate = estimate.RefDate;
            View.RefTypeId = estimate.RefTypeId;
            View.PlanTemplateListId = estimate.PlanTemplateListId;
            View.CurrencyCode = estimate.CurrencyCode;
            View.ExchangeRate = estimate.ExchangeRate;
            View.YearOfPlaning = estimate.YearOfPlaning;
            View.NextYearOfTotalEstimateAmount = estimate.NextYearOfTotalEstimateAmount;
            View.TotalEstimateAmount = estimate.TotalEstimateAmount;
            View.JournalMemo = estimate.JournalMemo;
            View.ReceiptEstimateDetails = estimate.EstimateDetails;
        }

        /// <summary>
        /// Deletes the specified reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        public long Delete(long refId)
        {
            return Model.DeleteEstimate(refId);
        }
    }
}

/***********************************************************************
 * <copyright file="SqlServerFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Thursday, March 18, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  07/03/2014       Author    Tudt           Description: Coding standard
 * 
 * ************************************************************************/

using TSD.AccountingSoft.View.Estimate;
using TSD.AccountingSoft.Model.BusinessObjects.Estimate;

namespace TSD.AccountingSoft.Presenter.Estimate.PaymentEstimate
{
    /// <summary>
    /// class PaymentEstimatePresenter
    /// </summary>
    public class PaymentEstimatePresenter : Presenter<IPaymentEstimateView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentEstimatePresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public PaymentEstimatePresenter(IPaymentEstimateView view)
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
                PostedDate = View.PostedDate,
                RefDate = View.RefDate,
                RefTypeId = View.RefTypeId,
                PlanTemplateListId = View.PlanTemplateListId,
                CurrencyCode = View.CurrencyCode,
                ExchangeRate = View.ExchangeRate,
                YearOfPlaning = View.YearOfPlaning,
                NextYearOfTotalEstimateAmount = View.NextYearOfTotalEstimateAmount,
                TotalEstimateAmount = View.TotalEstimateAmount,
                JournalMemo = View.JournalMemo,
                EstimateDetails = View.PaymentEstimateDetails,
                BudgetSourceCategoryId = View.BudgetSourceCategoryId,
                ExchangeRateLastYear = View.ExchangeRateLastYear,
                ExchangeRateThisYear = View.ExchangeRateThisYear
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
            View.PaymentEstimateDetails = estimate.EstimateDetails;
            View.BudgetSourceCategoryId = estimate.BudgetSourceCategoryId;
            View.ExchangeRateLastYear = estimate.ExchangeRateLastYear;
            View.ExchangeRateThisYear = estimate.ExchangeRateThisYear;
        }


        public void DisplayOption(long refId, int option, int budgetSourceCategoryId, int yearOfPlaning)
        {
            var estimate = Model.GetEstimateOption(refId, option, budgetSourceCategoryId, yearOfPlaning);

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
            View.PaymentEstimateDetails = estimate.EstimateDetails;
            View.BudgetSourceCategoryId = estimate.BudgetSourceCategoryId;
        }

        public void DisplayOption(int planTemplateListId, int yearOfPlaning)
        {
            var estimate = Model.GetEstimateOption(planTemplateListId, yearOfPlaning);

            View.ExchangeRateLastYear = estimate.ExchangeRateLastYear;
            View.ExchangeRateThisYear = estimate.ExchangeRateThisYear;
            View.PaymentEstimateDetails = estimate.EstimateDetails;
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

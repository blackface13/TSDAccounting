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

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using TSD.AccountingSoft.Model.BusinessObjects.Estimate;
using TSD.AccountingSoft.Model.BusinessObjects.Report.Finacial;
using TSD.AccountingSoft.View.Estimate;


namespace TSD.AccountingSoft.Presenter.Estimate.PaymentEstimate
{
    /// <summary>
    /// Class PaymentEstimatesPresenter.
    /// </summary>
    public class PaymentEstimatesPresenter : Presenter<IPaymentEstimatesView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentEstimatesPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public PaymentEstimatesPresenter(IPaymentEstimatesView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display(int refTypeId)
        {
            View.PaymentEstimates = Model.GetEstimatesByRefTypeId(refTypeId);
        }

        /// <summary>
        /// Displays the specified reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="yearOfEstimate">The year of estimate.</param>
        /// <param name="budgetSourceCategoryId">The budget source category identifier.</param>
        public void Display(int refTypeId, short yearOfEstimate, int budgetSourceCategoryId)
        {
            View.PaymentEstimates = Model.GetEstimatesByYearOfEstimate(refTypeId, yearOfEstimate, budgetSourceCategoryId);
        }

        public void Display(int refTypeId, short yearOfEstimate)
        {
            View.PaymentEstimates = Model.GetEstimatesByYearOfEstimateNoBudget(refTypeId, yearOfEstimate);
        }

        /// <summary>
        /// Displays the by year.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="refDate">The post date.</param>
        public void DisplayByYear(int refTypeId, string refDate)
        {
            View.PaymentEstimates = Model.GetEstimatesByYearOfPostDate(refTypeId, refDate);
        }

        /// <summary>
        /// Gets the content.
        /// </summary>
        /// <param name="yearOfPlaning">The year of planing.</param>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="companyCode">The company code.</param>
        /// <param name="budgetSourceCategoryId">The budget source category identifier.</param>
        /// <returns></returns>
        private string GetContent(int yearOfPlaning, int refTypeId, string companyCode, int budgetSourceCategoryId)
        {
            string content = "";
            content = content + @"<CompanyCode>" + companyCode + "</CompanyCode>";
            List<EstimateModel> receiptEstimates = Model.GetEstimatesByRefTypeId(refTypeId).Where(c => c.YearOfPlaning == yearOfPlaning).ToList();
            foreach (var receiptEstimate in receiptEstimates)
            {
                if (receiptEstimate.BudgetSourceCategoryId == budgetSourceCategoryId)
                {
                    var budgetSourceCategoryCode = "";
                    if (receiptEstimate.BudgetSourceCategoryId != null)
                    {
                        var budgetSourceCategory = Model.GetBudgetSourceCategory((int)receiptEstimate.BudgetSourceCategoryId);
                        budgetSourceCategoryCode = budgetSourceCategory.BudgetSourceCategoryCode;
                    }
                    content = content + @"<BudgetSourceCategoryCode>" + budgetSourceCategoryCode +
                            "</BudgetSourceCategoryCode>";
                    content = content + @"<Estimate>" +
                              "<RefID>" + receiptEstimate.RefId + "</RefID>" +
                              "<RefTypeID>" + receiptEstimate.RefTypeId + "</RefTypeID>" +
                              "<RefNo>" + receiptEstimate.RefNo + "</RefNo>" +
                              "<RefDate>" + receiptEstimate.RefDate + "</RefDate>" +

                              "<PostedDate>" + receiptEstimate.PostedDate + "</PostedDate>" +
                              "<PlanTemplateListID>" + receiptEstimate.PlanTemplateListId + "</PlanTemplateListID>" +
                              "<YearOfPlaning>" + receiptEstimate.YearOfPlaning + "</YearOfPlaning>" +
                              "<CurrencyCode>" + receiptEstimate.CurrencyCode + "</CurrencyCode>" +

                              "<ExchangeRate>" + receiptEstimate.ExchangeRate + "</ExchangeRate>" +
                              "<TotalEstimateAmount>" + receiptEstimate.TotalEstimateAmount + "</TotalEstimateAmount>" +
                              "<NextYearOfTotalEstimateAmount>" + receiptEstimate.NextYearOfTotalEstimateAmount +
                              "</NextYearOfTotalEstimateAmount>" +
                              "<JournalMemo>" + receiptEstimate.JournalMemo + "</JournalMemo>" +
                              "<BudgetSourceCategoryCode>" + budgetSourceCategoryCode +
                              "</BudgetSourceCategoryCode>";
                    var estimateModel = Model.GetEstimate(receiptEstimate.RefId);
                    foreach (var estimateDetail in estimateModel.EstimateDetails.ToList())
                    {
                        if (estimateDetail.Description != null && estimateDetail.Description.Contains("&"))
                        {
                            estimateDetail.Description = estimateDetail.Description.Replace("&", " ");
                        }
                        content = content + @"<EstimateDetail>" +
                                  "<RefId>" + estimateDetail.RefId + "</RefId>" +
                                  "<RefDetailId>" + estimateDetail.RefDetailId + "</RefDetailId>" +
                                  "<BudgetItemCode>" + estimateDetail.BudgetItemCode + "</BudgetItemCode>" +
                                  "<BudgetItemName>" + estimateDetail.BudgetItemName + "</BudgetItemName>" +
                                  "<PreviousYearOfEstimateAmount>" + estimateDetail.PreviousYearOfEstimateAmount +
                                  "</PreviousYearOfEstimateAmount>" +

                                  "<PreviousYearOfEstimateAmountUSD>" + estimateDetail.PreviousYearOfEstimateAmountUSD +
                                  "</PreviousYearOfEstimateAmountUSD>" +
                                  "<TotalEstimateAmountUSD>" + estimateDetail.TotalEstimateAmountUSD +
                                  "</TotalEstimateAmountUSD>" +
                                  "<YearOfEstimateAmount>" + estimateDetail.YearOfEstimateAmount +
                                  "</YearOfEstimateAmount>" +
                                  "<NextYearOfEstimateAmount>" + estimateDetail.NextYearOfEstimateAmount +
                                  "</NextYearOfEstimateAmount>" +

                                  "<AutonomyBudget>" + estimateDetail.AutonomyBudget + "</AutonomyBudget>" +
                                  "<NonAutonomyBudget>" + estimateDetail.NonAutonomyBudget + "</NonAutonomyBudget>" +
                                  "<TotalNextYearOfEstimateAmount>" + estimateDetail.TotalNextYearOfEstimateAmount +
                                  "</TotalNextYearOfEstimateAmount>" +
                                  "<Description>" + estimateDetail.Description + "</Description>" +
                            
                                  "<PreviousYearOfAutonomyBudget>" + estimateDetail.PreviousYearOfAutonomyBudget +
                                  "</PreviousYearOfAutonomyBudget>" +
                                  "<PreviousYearOfNonAutonomyBudget>" + estimateDetail.PreviousYearOfNonAutonomyBudget +
                                  "</PreviousYearOfNonAutonomyBudget>" +
                                  "<YearOfAutonomyBudget>" + estimateDetail.YearOfAutonomyBudget +
                                  "</YearOfAutonomyBudget>" +
                                  "<YearOfNonAutonomyBudget>" + estimateDetail.YearOfNonAutonomyBudget +
                                  "</YearOfNonAutonomyBudget>" +

                                  "<SixMonthBeginingAutonomyBudget>" + estimateDetail.SixMonthBeginingAutonomyBudget +
                                  "</SixMonthBeginingAutonomyBudget>" +
                                  "<SixMonthBeginingNonAutonomyBudget>" +
                                  estimateDetail.SixMonthBeginingNonAutonomyBudget +
                                  "</SixMonthBeginingNonAutonomyBudget>" +
                                  "<TotalAmountSixMonthBegining>" + estimateDetail.TotalAmountSixMonthBegining +
                                  "</TotalAmountSixMonthBegining>" +
                                  "<SixMonthEndingNonAutonomyBudget>" + estimateDetail.SixMonthEndingNonAutonomyBudget +
                                  "</SixMonthEndingNonAutonomyBudget>" +

                                  "<SixMonthEndingAutonomyBudget>" + estimateDetail.SixMonthEndingAutonomyBudget +
                                  "</SixMonthEndingAutonomyBudget>" +
                                  "<TotalAmountSixMonthEnding>" + estimateDetail.TotalAmountSixMonthEnding +
                                  "</TotalAmountSixMonthEnding>" +
                                  "<PreviousYeaOfAutonomyBudgetBalance>" +
                                  estimateDetail.PreviousYeaOfAutonomyBudgetBalance +
                                  "</PreviousYeaOfAutonomyBudgetBalance>" +
                                  "<PreviousYeaOfNonAutonomyBudgetBalance>" +
                                  estimateDetail.PreviousYeaOfNonAutonomyBudgetBalance +
                                  "</PreviousYeaOfNonAutonomyBudgetBalance>" +

                                  "<TotalPreviousYearBalance>" + estimateDetail.TotalPreviousYearBalance +
                                  "</TotalPreviousYearBalance>" +
                                  "<ThisYearOfAutonomyBudget>" + estimateDetail.ThisYearOfAutonomyBudget +
                                  "</ThisYearOfAutonomyBudget>" +
                                  "<ThisYearOfNonAutonomyBudget>" + estimateDetail.ThisYearOfNonAutonomyBudget +
                                  "</ThisYearOfNonAutonomyBudget>" +
                                  "<TotalAmountThisYear>" + estimateDetail.TotalAmountThisYear +
                                  "</TotalAmountThisYear>"
                                  + "</EstimateDetail>";
                    }
                    content = content + @"</Estimate>";
                }
            }
            return content;
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void CreateXmlReceiptEstimatesData(int yearOfPlaning, int refTypeId, string tempFolderPath, string fileName, string companyCode)
        {
            List<EstimateModel> receiptEstimates = Model.GetEstimatesByRefTypeId(refTypeId).Where(c=>c.YearOfPlaning == yearOfPlaning).ToList();
            foreach (var receiptEstimate in receiptEstimates)
            {
                if (receiptEstimate.BudgetSourceCategoryId != null)
                {
                    string content = GetContent(yearOfPlaning,refTypeId, companyCode, (int)receiptEstimate.BudgetSourceCategoryId);
                    var head = @"<?xml version='1.0' encoding='utf-8'?>";
                    head = head + @"<BUCAEstimate>";
                    head = head + content;
                    head = head + "</BUCAEstimate>";
                    if (!Directory.Exists(tempFolderPath))
                    {
                        Directory.CreateDirectory(tempFolderPath);
                    }
                    TextWriter tw =
                        new StreamWriter(tempFolderPath + @"\" + fileName + "_" + receiptEstimate.YearOfPlaning + "_" + receiptEstimate.BudgetSourceCategoryId + ".xml");
                    tw.Write(head);
                    tw.Close();
                    DataSet dt = new DataSet();
                    dt.ReadXml(tempFolderPath + @"\" + fileName + "_" + receiptEstimate.YearOfPlaning + "_" + receiptEstimate.BudgetSourceCategoryId + ".xml");

                }
            }
        }

        /// <summary>
        /// LINHMC added
        /// Gets the F03 bn g_ for estimate.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns></returns>
        public IList<F03BNGModel> GetF03BNG_ForEstimate(DateTime fromDate, DateTime toDate)
        {
            return Model.GetReportF03BNGs("uspReport_F03BNG_ForEstimate", 1, "USD",fromDate, toDate) as List<F03BNGModel>;
        }

        /// <summary>
        /// Displays the voucher detail.
        /// LinhMC add 30.9.2016
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        public void DisplayVoucherDetail(long refId)
        {
            var voucher = Model.GetEstimate(refId);
            if (voucher != null)
            {
                View.PaymentEstimateDetails = voucher.EstimateDetails;
            }
        }
    }
}

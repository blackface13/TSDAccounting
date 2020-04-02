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

using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using TSD.AccountingSoft.Model.BusinessObjects.Estimate;
using TSD.AccountingSoft.View.Estimate;

namespace TSD.AccountingSoft.Presenter.Estimate.ReceiptEstimate
{
    /// <summary>
    /// Class ReceiptEstimatesPresenter.
    /// </summary>
    public class ReceiptEstimatesPresenter : Presenter<IReceiptEstimatesView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReceiptEstimatesPresenter" /> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public ReceiptEstimatesPresenter(IReceiptEstimatesView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        public void Display(int refTypeId)
        {
            View.ReceiptEstimates = Model.GetEstimatesByRefTypeId(refTypeId);
        }

        /// <summary>
        /// The year of planing
        /// </summary>
        public string YearOfPlaning;

        /// <summary>
        /// Gets the content.
        /// </summary>
        /// <param name="yearOfPlaning">The year of planing.</param>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns></returns>
        string GetContent(int yearOfPlaning, int refTypeId, string companyCode)
        {
            string content = "";
            content = content + @"<CompanyCode>" + companyCode + "</CompanyCode>";
            List<EstimateModel> receiptEstimates = Model.GetEstimatesByRefTypeId(refTypeId).Where(c => c.YearOfPlaning == yearOfPlaning).ToList();
            foreach (var receiptEstimate in receiptEstimates)
            {
                var budgetSourceCategoryCode = "";
                if (receiptEstimate.BudgetSourceCategoryId != null)
                {
                    var budgetSourceCategory = Model.GetBudgetSourceCategory((int)receiptEstimate.BudgetSourceCategoryId);
                    budgetSourceCategoryCode = budgetSourceCategory.BudgetSourceCategoryCode;
                }
                YearOfPlaning = receiptEstimate.YearOfPlaning.ToString();
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
                              "<YearOfEstimateAmount>" + estimateDetail.YearOfEstimateAmount + "</YearOfEstimateAmount>" +
                              "<NextYearOfEstimateAmount>" + estimateDetail.NextYearOfEstimateAmount +
                              "</NextYearOfEstimateAmount>" +

                              "<AutonomyBudget>" + estimateDetail.AutonomyBudget + "</AutonomyBudget>" +
                              "<NonAutonomyBudget>" + estimateDetail.NonAutonomyBudget + "</NonAutonomyBudget>" +
                              "<TotalNextYearOfEstimateAmount>" + estimateDetail.TotalNextYearOfEstimateAmount +
                              "</TotalNextYearOfEstimateAmount>" +
                              "<Description>" + estimateDetail.Description + "</Description>" +
                        //  "<Description>" + "" + "</Description>" +

                              "<PreviousYearOfAutonomyBudget>" + estimateDetail.PreviousYearOfAutonomyBudget +
                              "</PreviousYearOfAutonomyBudget>" +
                              "<PreviousYearOfNonAutonomyBudget>" + estimateDetail.PreviousYearOfNonAutonomyBudget +
                              "</PreviousYearOfNonAutonomyBudget>" +
                              "<YearOfAutonomyBudget>" + estimateDetail.YearOfAutonomyBudget + "</YearOfAutonomyBudget>" +
                              "<YearOfNonAutonomyBudget>" + estimateDetail.YearOfNonAutonomyBudget +
                              "</YearOfNonAutonomyBudget>" +

                              "<SixMonthBeginingAutonomyBudget>" + estimateDetail.SixMonthBeginingAutonomyBudget +
                              "</SixMonthBeginingAutonomyBudget>" +
                              "<SixMonthBeginingNonAutonomyBudget>" + estimateDetail.SixMonthBeginingNonAutonomyBudget +
                              "</SixMonthBeginingNonAutonomyBudget>" +
                              "<TotalAmountSixMonthBegining>" + estimateDetail.TotalAmountSixMonthBegining +
                              "</TotalAmountSixMonthBegining>" +
                              "<SixMonthEndingNonAutonomyBudget>" + estimateDetail.SixMonthEndingNonAutonomyBudget +
                              "</SixMonthEndingNonAutonomyBudget>" +

                              "<SixMonthEndingAutonomyBudget>" + estimateDetail.SixMonthEndingAutonomyBudget +
                              "</SixMonthEndingAutonomyBudget>" +
                              "<TotalAmountSixMonthEnding>" + estimateDetail.TotalAmountSixMonthEnding +
                              "</TotalAmountSixMonthEnding>" +
                              "<PreviousYeaOfAutonomyBudgetBalance>" + estimateDetail.PreviousYeaOfAutonomyBudgetBalance +
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
                              "<TotalAmountThisYear>" + estimateDetail.TotalAmountThisYear + "</TotalAmountThisYear>" +
                              "<ItemCodeList>" + estimateDetail.ItemCodeList + "</ItemCodeList>"
                              + "</EstimateDetail>";
                }
                content = content + @"</Estimate>";
            }
            return content;
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        /// <param name="yearOfPaning">The year of paning.</param>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="tempFolderPath">The temporary folder path.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="companyCode">The company code.</param>
        public void CreateXmlReceiptEstimatesData(int yearOfPaning, int refTypeId, string tempFolderPath, string fileName, string companyCode)
        {
            string content = GetContent(yearOfPaning, refTypeId, companyCode);
            var head = @"<?xml version='1.0' encoding='utf-8'?>";
            head = head + @"<BUCAEstimate>";
            head = head + content;
            head = head + "</BUCAEstimate>";
            if (!Directory.Exists(tempFolderPath))
            {
                Directory.CreateDirectory(tempFolderPath);
            }
            TextWriter tw = new StreamWriter(tempFolderPath + @"\" + fileName + "_" + yearOfPaning + ".xml");
            tw.Write(head);
            tw.Close();

            var dt = new DataSet();
            dt.ReadXml(tempFolderPath + @"\" + fileName + "_" + yearOfPaning + ".xml");
        }

        /// <summary>
        /// Displays the specified reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="yearOfEstimate">The year of estimate.</param>
        /// <param name="budgetSourceCategoryId">The budget source category identifier.</param>
        public void Display(int refTypeId, short yearOfEstimate, int budgetSourceCategoryId)
        {
            View.ReceiptEstimates = Model.GetEstimatesByYearOfEstimate(refTypeId, yearOfEstimate, budgetSourceCategoryId);
        }

        /// <summary>
        /// Displays the specified reference type identifier.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="yearOfEstimate">The year of estimate.</param>
        public void Display(int refTypeId, short yearOfEstimate)
        {
            View.ReceiptEstimates = Model.GetEstimatesByYearOfEstimate(refTypeId, yearOfEstimate);
        }

        /// <summary>
        /// Displays the by year.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="refDate">The post date.</param>
        public void DisplayByYear(int refTypeId, string refDate)
        {
            View.ReceiptEstimates = Model.GetEstimatesByYearOfPostDate(refTypeId, refDate);
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
                View.ReceiptEstimateDetails = voucher.EstimateDetails;
            }
        }
    }
}

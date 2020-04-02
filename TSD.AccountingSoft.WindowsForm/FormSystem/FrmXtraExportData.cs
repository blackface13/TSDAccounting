using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TSD.AccountingSoft.Session;
using TSD.AccountingSoft.Model;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Model.BusinessObjects.General;
using DateTimeRangeBlockDev.Helper;
using DevExpress.XtraEditors;
using TSD.AccountingSoft.Model.BusinessObjects.Report.Finacial;
using DevExpress.XtraEditors.Controls;

namespace TSD.AccountingSoft.WindowsForm.FormSystem
{
    public partial class FrmXtraExportData : XtraForm
    {
        public GlobalVariable CommonVariable { get; set; }
        private IModel model;

        public FrmXtraExportData()
        {
            InitializeComponent();
            CommonVariable = new GlobalVariable();
            model = new Model.Model();
        }

        private void FrmXtraExportData_Load(object sender, EventArgs e)
        {
            yearPicker.EditValue = DateTime.Parse(CommonVariable.PostedDate);
            txtCompanyCode.Text = GlobalVariable.CompanyCode;
            txtCompanyName.Text = GlobalVariable.CompanyName;
            txtAuditPerson.Text = CommonVariable.CompanyDirector;
            txtPathXML.Text = CommonVariable.XMLPath;
        }

        public string FromDate
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Gets or sets the reference date.
        /// </summary>
        /// <value>
        /// The reference date.
        /// </value>
        public string ToDate
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the receive finalization.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns></returns>

        /// <summary>
        /// Gets the expense finalization.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns></returns>
        private string GetExpenseFinalization(DateTime fromDate, DateTime toDate, string companyCode)
        {
            string content = @"";
            content = content + @"<CompanyCode>" + companyCode + "</CompanyCode>"
                                + @"<CompanyName>" + GlobalVariable.CompanyName + "</CompanyName>"
                                + @"<PeriodID>" + 1 + "</PeriodID>"
                               + @"<RefType>" + 201 + "</RefType>"; ;
            IList<JournalEntryAccountModel> journalEntryAccounts = model.GetJournalEntryAccounts(2, fromDate, toDate);
            if (journalEntryAccounts != null)
            {
                var totalAmount = journalEntryAccounts.Select(c => c.AmountOc).Sum();
                content = content + @"<ExpenseFinalization>" +
                            "<CompanyCode>" + GlobalVariable.CompanyCode + "</CompanyCode>" +
                            "<CompanyName>" + GlobalVariable.CompanyName + "</CompanyName>" +
                            "<PeriodID>" + 1 + "</PeriodID>" +
                            "<FromDate>" + fromDate + "</FromDate>" +
                            "<ToDate>" + toDate + "</ToDate>" +
                            "<RefType>" + 201 + "</RefType>" +
                            "<TotalAmount>" + totalAmount + "</TotalAmount>" +
                            "<Comment>" + "" + "</Comment>";
                foreach (var journalEntryAccount in journalEntryAccounts)
                {
                    content = content + @"<ExpenseFinalizationDetail>" +
                            "<CompanyCode>" + GlobalVariable.CompanyCode + "</CompanyCode>" +
                            "<CurrencyCode>" + journalEntryAccount.CurrencyCode + "</CurrencyCode>" +
                            "<BudgetSourceCode>" + journalEntryAccount.BudgetSourceCode + "</BudgetSourceCode>" +
                            "<BudgetItemCode>" + journalEntryAccount.BudgetItemCode + "</BudgetItemCode>" +
                            "<Amount>" + journalEntryAccount.AmountOc + "</Amount>" +
                            "<AmountExchange>" + journalEntryAccount.AmountExchange + "</AmountExchange>" +
                            "<AccountCode>" + journalEntryAccount.AccountNumber + "</AccountCode>" +
                            "<Description>" + journalEntryAccount.Description + "</Description>" +
                            "</ExpenseFinalizationDetail>";
                }
                content = content + @"</ExpenseFinalization>";
            }

            return content;
        }

        /// <summary>
        /// Gets the balance sheet.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="companyCode">The company code.</param>
        /// <returns></returns>
        private string GetBalanceSheet(DateTime fromDate, DateTime toDate, string companyCode)
        {
            string content = @"";
            content = content + @"<CompanyCode>" + companyCode + "</CompanyCode>"
                                + @"<CompanyName>" + GlobalVariable.CompanyName + "</CompanyName>"
                                + @"<PeriodID>" + 1 + "</PeriodID>"
                                + @"<RefType>" + 0 + "</RefType>";
            IList<JournalEntryAccountModel> journalEntryAccounts = model.GetJournalEntryAccounts(3, fromDate, toDate);
            if (journalEntryAccounts != null)
            {
                var totalDebitAmount = journalEntryAccounts.Select(c => c.MovementDebitAmountOC).Sum();
                var totalCreditAmount = journalEntryAccounts.Select(c => c.MovementCreditAmountOC).Sum();
                content = content + @"<AccountBalance>" +
                            "<CompanyCode>" + GlobalVariable.CompanyCode + "</CompanyCode>" +
                            "<CompanyName>" + GlobalVariable.CompanyName + "</CompanyName>" +
                            "<PeriodID>" + 1 + "</PeriodID>" +
                            "<FromDate>" + fromDate + "</FromDate>" +
                            "<ToDate>" + toDate + "</ToDate>" +
                            "<RefType>" + 0 + "</RefType>" +
                            "<TotalDebitAmount>" + totalDebitAmount + "</TotalDebitAmount>" +
                            "<TotalCreditAmount>" + totalCreditAmount + "</TotalCreditAmount>" +
                            "<Comment>" + "" + "</Comment>";
                foreach (var journalEntryAccount in journalEntryAccounts)
                {
                    content = content + @"<AccountBalanceDetail>" +
                            "<CompanyCode>" + GlobalVariable.CompanyCode + "</CompanyCode>" +
                            "<CurrencyCode>" + journalEntryAccount.CurrencyCode + "</CurrencyCode>" +
                            "<AccountCode>" + journalEntryAccount.AccountNumber + "</AccountCode>" +
                            "<BudgetSourceCode>" + journalEntryAccount.BudgetSourceCode + "</BudgetSourceCode>" +
                            "<MovementDebitAmount>" + journalEntryAccount.MovementDebitAmountOC + "</MovementDebitAmount>" +
                            "<MovementDebitAmountExchange>" + journalEntryAccount.MovementDebitAmountExchange + "</MovementDebitAmountExchange   >" +
                            "<MovementCreditAmount>" + journalEntryAccount.MovementCreditAmountOC + "</MovementCreditAmount>" +
                            "<MovementCreditAmountExchange>" + journalEntryAccount.MovementCreditAmountExchange + "</MovementCreditAmountExchange>" +
                            "</AccountBalanceDetail>";
                }
                content = content + @"</AccountBalance>";
            }

            return content;
        }
        private string GetBO1_I(DateTime fromDate, DateTime toDate)
        {
            string content = @"<BO1_I>";

            IList<ReportB01CIModel> lstResults = new List<ReportB01CIModel>();
            lstResults = model.GetB01CIWithStoreProdure("uspReport_B01CI", fromDate, toDate);
            content = content + @"<ExchangeRate>" + "1,00" + "</ExchangeRate>";
            foreach (var result in lstResults)
            {
                content = content + @"<BO1_IDetail>" +
                          "<OrderNumber>" + result.OrderNumber + "</OrderNumber>" +
                          "<OrderCode>" + result.OrderCode + "</OrderCode>" +
                          "<Content>" + result.Content + "</Content>" +
                          "<Col01>" + result.Col01 + "</Col01>" +
                          "<Col02>" + result.Col02 + "</Col02>" +
                          "<Col03>" + result.Col03 + "</Col03>" +
                          "<Col04>" + result.Col04 + "</Col04>" +
                          "<Col05>" + result.Col05 + "</Col05>" +
                          "<Col06>" + result.Col06 + "</Col06>" +
                          "<Col07>" + result.Col07 + "</Col07>" +
                          "<Col08>" + result.Col08 + "</Col08>" +
                          "<Col09>" + result.Col09 + "</Col09>" +
                          "<Col10>" + result.Col10 + "</Col10>" +
                          "<Col11>" + result.Col11 + "</Col11>" +
                          "<Col12>" + result.Col12 + "</Col12>" +
                          "<Col13>" + result.Col13 + "</Col13>" +
                          "<Col14>" + result.Col14 + "</Col14>" +
                          "<Col15>" + result.Col15 + "</Col15>" +
                          "<Col16>" + result.Col16 + "</Col16>" +
                          "<Col17>" + result.Col17 + "</Col17>" +
                          "<Col18>" + result.Col18 + "</Col18>" +
                          "<Col19>" + result.Col19 + "</Col19>" +
                          "<Col20>" + result.Col20 + "</Col20>" +
                          "<Col21>" + result.Col21 + "</Col21>" +
                          "<Col22>" + result.Col22 + "</Col22>" +
                          "<Col23>" + result.Col23 + "</Col23>" +
                          "<Col24>" + result.Col24 + "</Col24>" +
                          "<Col25>" + result.Col25 + "</Col25>" +
                          "<Col26>" + result.Col26 + "</Col26>" +
                          "<Col27>" + result.Col27 + "</Col27>" +
                          "<Col28>" + result.Col28 + "</Col28>" +
                          "<ExchangeRateLastYear>" + result.ExchangeRateLastYear + "</ExchangeRateLastYear>" +
                          "<ExchangeRateThisYear>" + result.ExchangeRateThisYear + "</ExchangeRateThisYear>" +
                          "</BO1_IDetail>";
            }

            content = content + @"</BO1_I>";
            return content;
        }
        private string GetBO1_II(DateTime fromDate, DateTime toDate)
        {
            string content = @"<BO1_II>";

            IList<ReportB01CIIModel> lstResults = new List<ReportB01CIIModel>();
            lstResults = model.GetB01CIIWithStoreProdure("uspReport_01CII", fromDate.ToShortDateString(), toDate.ToShortDateString());
            content = content + @"<ExchangeRate>" + "1,00" + "</ExchangeRate>";
            foreach (var result in lstResults)
            {
                if (result.Grade == 0) continue;
                content = content + @"<BO1_IIDetail>" +
                              //"<BudgetItemCode>" + result.BudgetItemCode + "</BudgetItemCode>" +
                              //"<BudgetItemName>" + result.BudgetItemName + "</BudgetItemName>" +
                              //"<FontStyle>" + result.FontStyle + "</FontStyle>" +
                              "<BudgetItemCode>" + result.BudgetItemCode + "</BudgetItemCode>" +
                              "<BudgetItemName>" + result.BudgetItemName + "</BudgetItemName>" +
                              "<Col01>" + result.Column1 + "</Col01>" +
                              "<Col02>" + result.Column2 + "</Col02>" +
                              "<Col03>" + result.Column3 + "</Col03>" +
                              "<Col04>" + result.Column4 + "</Col04>" +
                              "<Col05>" + result.Column5 + "</Col05>" +
                              "<Col06>" + result.Column6 + "</Col06>" +
                              "<Col07>" + result.Column7 + "</Col07>" +
                              "<Col08>" + result.Column8 + "</Col08>" +
                              "<Col09>" + result.Column9 + "</Col09>" +
                              "<Col10>" + result.Column10 + "</Col10>" +
                              "<Col11>" + result.Column11 + "</Col11>" +
                              "<Col12>" + result.Column12 + "</Col12>" +
                              "<Col13>" + result.Column13 + "</Col13>" +
                              "<Col14>" + result.Column14 + "</Col14>" +
                              "<Col15>" + result.Column15 + "</Col15>" +
                              "<Col16>" + result.Column16 + "</Col16>" +
                              "<Col17>" + result.Column17 + "</Col17>" +
                              "<Col18>" + result.Column18 + "</Col18>" +
                              "<Col19>" + result.Column19 + "</Col19>" +
                              "<Col20>" + result.Column20 + "</Col20>" +
                              "<Col21>" + result.Column21 + "</Col21>" +
                              "<Col22>" + result.Column22 + "</Col22>" +
                              "<Col23>" + result.Column23 + "</Col23>" +
                              "<Col24>" + result.Column24 + "</Col24>" +
                              "<Col25>" + result.Column25 + "</Col25>" +
                              "<Col26>" + result.Column26 + "</Col26>" +
                              "<Col27>" + result.Column27 + "</Col27>" +
                              "<Col28>" + result.Column28 + "</Col28>" +
                              "<ExchangeRateLastYear>" + result.ExchangeRateLastYear + "</ExchangeRateLastYear>" +
                              "<ExchangeRateThisYear>" + result.ExchangeRateThisYear + "</ExchangeRateThisYear>" +
                              "</BO1_IIDetail>";
            }
            content = content + @"</BO1_II>";
            return content;
        }

        private string GetB03bBCTC(DateTime fromDate, DateTime toDate)
        {
            string content = @"<BO3b>";
            var amountType = GlobalVariable.AmountTypeViewReport;
            var currencyCode = GlobalVariable.CurrencyViewReport;
            IList<ReportB03bBCTCModel> lstResults = new List<ReportB03bBCTCModel>();
            lstResults = model.GetB03bBCTC("uspReport_B03bBCTC", fromDate.ToShortDateString(), toDate.ToShortDateString(), currencyCode, amountType);

            foreach (var result in lstResults)
            {
                content = content + @"<BO3b_IDetail>" +

                           "<RefDetailCode>" + result.ItemCode + "</RefDetailCode>" +
                           "<RefDetailName>" + result.ItemName + "</RefDetailName>" +
                           "<OrderNumber>" + result.Index + "</OrderNumber>" +
                           "<Note>" + result.Present + "</Note>" +
                           "<LastYearAmount>" + result.LastYearAmount + "</LastYearAmount>" +
                           "<ThisYearAmount>" + result.ThisYearAmount + "</ThisYearAmount>" +
                           "<SortOrder>" + result.SortOrder + "</SortOrder>" +
                           "</BO3b_IDetail>";
            }


            content = content + @"</BO3b>";
            return content;

        }


        private string GetB01BCTC(DateTime fromDate, DateTime toDate)
        {
            string content = @"<BO1BCTC>";
            var amountType = GlobalVariable.AmountTypeViewReport;
            var currencyCode = GlobalVariable.CurrencyViewReport;
            IList<ReportB01BCTCModel> lstResults = new List<ReportB01BCTCModel>();
            lstResults = model.GetB01BCTC("uspReport_B01BCTC", fromDate.ToShortDateString(), toDate.ToShortDateString(), currencyCode, amountType);

            foreach (var result in lstResults)
            {
                content = content + @"<BO1BCTC_IDetail>" +
                                     "<Part>" +        result.Part + "</Part>" +
                                     "<ItemIndex>" +   result.Index + "</ItemIndex>" +
                                     "<ItemCode>" +    result.ItemCode + "</ItemCode>" +
                                     "<ItemName>" +    result.ItemName + "</ItemName>" +
                                     "<BeginAmount>" + result.BeginAmount + "</BeginAmount>" +
                                     "<EndAmount>" +   result.EndAmount + "</EndAmount>" +
                                     "<IsBold>" +      result.IsBold + "</IsBold>" +
                                     "<IsItalic>" +    result.IsItalic + "</IsItalic>" +
                                     "<SortOrder>" +   result.SortOrder + "</SortOrder>" +
                                     "</BO1BCTC_IDetail>";
            }
            content = content + @"</BO1BCTC>";
            return content;
        }
        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Handles the Click event of the btnExportData control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnExportData_Click(object sender, EventArgs e)
        {
            try
            {
                var isError = ValidData();
                if (!isError)
                    return;
                var fromDate = DateTime.Parse("1/1/" + yearPicker.Text); //DateTime.Now; //dateTimeRangeV.FromDate.Date;
                var toDate = DateTime.Parse("31/12/" + yearPicker.Text); //DateTime.Now; //dateTimeRangeV.ToDate.Date;
                string tempFolderPath = txtPathXML.Text;//System.Windows.Forms.Application.StartupPath + @"\Export";
                string contentXML = @"";
                string profile = @"<Profile>" +
                                 "<Year>" + yearPicker.Text + "</Year>" +
                                 "<CompanyCode>" + txtCompanyCode.Text + "</CompanyCode>" +
                                 "<CompanyName>" + txtCompanyName.Text + "</CompanyName>" +
                                 "<PersonAudit>" + txtAuditPerson.Text + "</PersonAudit>" +
                                  @"</Profile>"
                ;
                foreach (CheckedListBoxItem checkData in cboCheckData.Properties.Items)
                {
                    if (checkData.CheckState == CheckState.Checked)
                    {
                        if (int.Parse(checkData.Value.ToString()) == 1)
                        {
                            contentXML = contentXML + GetBO1_I(fromDate, toDate);
                        }
                        if (int.Parse(checkData.Value.ToString()) == 2)
                        {
                            contentXML = contentXML + GetBO1_II(fromDate, toDate);
                        }
                        if (int.Parse(checkData.Value.ToString()) == 3)
                        {
                            contentXML = contentXML + GetB03bBCTC(fromDate, toDate);
                        }
                        if (int.Parse(checkData.Value.ToString()) == 4)
                        {
                            contentXML = contentXML + GetB01BCTC(fromDate, toDate);
                        }
                    }

                }
                string fileName = GlobalVariable.CompanyName;
                var head = @"<?xml version='1.0' encoding='utf-8'?>";
                head = head + @"<BUCAFinalization>";
                head = head + profile + contentXML;
                head = head + "</BUCAFinalization>";
                if (!Directory.Exists(tempFolderPath))
                {
                    Directory.CreateDirectory(tempFolderPath);
                }
                TextWriter tw = new StreamWriter(tempFolderPath + @"\" + fileName + "_" + yearPicker.Text + "_" + DateTime.Now.ToShortDateString().Replace(@"/", "") + ".xml");
                tw.Write(head);
                tw.Close();

                var dt = new DataSet();
                dt.ReadXml(tempFolderPath + @"\" + fileName + "_" + yearPicker.Text + "_" + DateTime.Now.ToShortDateString().Replace(@"/", "") + ".xml");

                XtraMessageBox.Show("Xuất khẩu dữ liệu thành công!",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
                Process.Start(tempFolderPath);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Xuất khẩu dữ liệu không thành công!",
                                     "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool ValidData()
        {
            if (string.IsNullOrEmpty(cboCheckData.Properties.GetCheckedItems().ToString()))//(!chkReceiveFinalization.Checked && !chkExpenseFinalization.Checked && !chkCompanyProfile.Checked && !chkBalanceSheet.Checked)
            {
                XtraMessageBox.Show("Bạn chưa chọn loại dữ liệu cần xuất khẩu!",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (string.IsNullOrEmpty(txtAuditPerson.Text))
            {
                XtraMessageBox.Show("Bạn chưa nhập thông tin Cán bộ kiểm soát!",
                                   "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAuditPerson.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtCompanyCode.Text))
            {
                XtraMessageBox.Show("Bạn chưa nhập thông tin Mã đơn vị!",
                                   "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCompanyCode.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtCompanyName.Text))
            {
                XtraMessageBox.Show("Bạn chưa nhập thông tin Tên đơn vị!",
                                   "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCompanyName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(yearPicker.Text))
            {
                XtraMessageBox.Show("Bạn chưa nhập Năm xuất khẩu dữ liệu!",
                                   "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                yearPicker.Focus();
                return false;
            }

            return true;
        }



        private void txtPathXML_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                using (var folderBrowserDialog = new FolderBrowserDialog())
                {
                    var dialogResult = folderBrowserDialog.ShowDialog();
                    if (dialogResult == DialogResult.OK)
                    {
                        txtPathXML.Text = folderBrowserDialog.SelectedPath;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}

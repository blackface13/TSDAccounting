/***********************************************************************
 * <copyright file="FrmS12AH.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    ThangNK@buca.vn
 * Website:
 * Create Date: Thursday, September 11, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/
using System;
using System.ComponentModel;
using System.Data;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TSD.AccountingSoft.Report.BaseParameterForm;
using TSD.AccountingSoft.Report.CommonClass;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Presenter.Dictionary.Account;
using TSD.AccountingSoft.Presenter.Dictionary.Bank;
using TSD.AccountingSoft.Session;
using TSD.AccountingSoft.View.Dictionary;
using DateTimeRangeBlockDev.Helper;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace TSD.AccountingSoft.Report.ParameterReportForm
{
    /// <summary>
    /// FrmS12AH
    /// </summary>
    public partial class FrmS12AH : FrmXtraBaseParameter, IAccountsView,IBanksView
    {
        /// <summary>
        /// The _DB option helper
        /// </summary>
        private GlobalVariable _dbOptionHelper;
        /// <summary>
        /// The _accounts presenter
        /// </summary>
        private readonly AccountsPresenter _accountsPresenter;

        private readonly BanksPresenter _banksPresenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmS12AH"/> class.
        /// </summary>
        public FrmS12AH()
        {
            InitializeComponent();
            _dbOptionHelper = new GlobalVariable();
            _accountsPresenter = new AccountsPresenter(this);
            _banksPresenter = new BanksPresenter(this);
            dateTimeRangeV1.DateRangePeriodMode = DateRangeMode.Reduce;
            dateTimeRangeV1.InitSelectedIndex = GlobalVariable.DateRangeSelectedIndex;

            #region BudgetItem
            var rpsAccountNumberView = new GridView();
            rpsAccountNumberView.OptionsView.ColumnAutoWidth = false;
            var rpsAccountNumber = new RepositoryItemGridLookUpEdit
            {
                NullText = "",
                View = rpsAccountNumberView,
                TextEditStyle = TextEditStyles.Standard,
                PopupResizeMode = ResizeMode.FrameResize,
                PopupFormSize = new Size(500, 200),
                ShowFooter = false
            };
            rpsAccountNumber.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
            rpsAccountNumber.View.BestFitColumns();
            rpsAccountNumber.View.OptionsView.ShowIndicator = false;
            #endregion

        }

        /// <summary>
        /// Gets the account code.
        /// </summary>
        /// <value>
        /// The account code.
        /// </value>
        public string AccountCode
        {
            get
            {
                return grdLookUpAccount.EditValue.ToString();
            }
        }

        public int? BankId { get; set; }

        public string BankName { get; set; }

        public bool IsBank
        {

            get { return chkBank.Checked; }

            set { chkBank.Checked = value; }
        }

        /// <summary>
        /// Gets the corresponding account number.
        /// </summary>
        /// <value>
        /// The corresponding account number.
        /// </value>
        public string CorrespondingAccountNumber
        {
            get
            {
                return grdLookUpCorrespondingAccount.EditValue.ToString();
            }
        }

        /// <summary>
        /// Gets or sets the currency code.
        /// </summary>
        /// <value>
        /// The currency code.
        /// </value>
        public string CurrencyCode { get; set; }


        /// <summary>
        /// Gets or sets the name of the account.
        /// </summary>
        /// <value>
        /// The name of the account.
        /// </value>
        public string AccountName { get; set; }

        /// <summary>
        /// Gets or sets the type of the amount.
        /// </summary>
        /// <value>
        /// The type of the amount.
        /// </value>
        public int AmountType { get; set; }

        /// <summary>
        /// Gets or sets from date.
        /// </summary>
        /// <value>
        /// From date.
        /// </value>
        public string FromDate
        {
            get
            {
                return dateTimeRangeV1.FromDate.ToShortDateString();
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
                return dateTimeRangeV1.ToDate.ToShortDateString();
            }
        }

        public bool IsTotalBandInNewPage
        {
            get { return chkMoveTotalInNewPage.Checked; }
            set { chkMoveTotalInNewPage.Checked = value; }
        }


        /// <summary>
        /// Sets the accounts.
        /// </summary>
        /// <value>
        /// The accounts.
        /// </value>
        public IList<AccountModel> Accounts
        {
            set
            {
                string currencyCode = GlobalVariable.CurrencyViewReport ?? "";
                grdLookUpAccount.Properties.DataSource = value.Where(x => x.AccountCode.IndexOf("112", StringComparison.Ordinal) == 0 && (x.IsCurrency && x.CurrencyCode == currencyCode)).ToList();
                grdLookUpAccount.Properties.PopulateColumns();
                grdLookUpCorrespondingAccount.Properties.DataSource = value;
                grdLookUpCorrespondingAccount.Properties.PopulateColumns();

                var gridColumnsCollection = new List<XtraColumn>
                    {
                       new XtraColumn { ColumnName = "AccountId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "AccountCode", ColumnCaption = "Mã tài khoản", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 100 },
                        new XtraColumn { ColumnName = "AccountCategoryId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "AccountName", ColumnCaption = "Tên tài khoản", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 400 },
                        new XtraColumn { ColumnName = "Description", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsActive", ColumnVisible = false },
                        new XtraColumn { ColumnName = "ForeignName", ColumnVisible = false },
                        new XtraColumn { ColumnName = "Grade", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsDetail", ColumnVisible = false },
                        new XtraColumn { ColumnName = "BalanceSide", ColumnVisible = false }, //  Balanceside
                        new XtraColumn { ColumnName = "ConcomitantAccount", ColumnVisible = false },
                        new XtraColumn { ColumnName = "BankId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsChapter", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsBudgetCategory", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsBudgetItem", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsBudgetGroup", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsBudgetSource", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsActivity", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsCurrency", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsCustomer", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsVendor", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsEmployee", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsAccountingObject", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsInventoryItem", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsFixedAsset", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsCapitalAllocate", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsProject", ColumnVisible = false },
                        new XtraColumn { ColumnName = "CurrencyCode", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsAllowinputcts", ColumnVisible = false },
                        new XtraColumn { ColumnName = "ParentId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsBudgetSubItem", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsBank", ColumnVisible = false },
                    };

                foreach (var column in gridColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        grdLookUpAccount.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        grdLookUpAccount.Properties.SortColumnIndex = column.ColumnPosition;
                        grdLookUpAccount.Properties.Columns[column.ColumnName].Width = column.ColumnWith;

                        grdLookUpCorrespondingAccount.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        grdLookUpCorrespondingAccount.Properties.SortColumnIndex = column.ColumnPosition;
                        grdLookUpCorrespondingAccount.Properties.Columns[column.ColumnName].Width = column.ColumnWith;

                    }
                    else
                    {
                        grdLookUpAccount.Properties.Columns[column.ColumnName].Visible = false;
                        grdLookUpCorrespondingAccount.Properties.Columns[column.ColumnName].Visible = false;

                    }
                }
                grdLookUpAccount.Properties.DisplayMember = "AccountCode";
                grdLookUpAccount.Properties.ValueMember = "AccountCode";
                grdLookUpAccount.Properties.ShowFooter = false;
                grdLookUpAccount.Properties.TextEditStyle = TextEditStyles.Standard;
                //grdLookUpAccount.Properties.PopupFormMinSize = new System.Drawing.Size(500, 200);

                grdLookUpCorrespondingAccount.Properties.DisplayMember = "AccountCode";
                grdLookUpCorrespondingAccount.Properties.ValueMember = "AccountCode";
                grdLookUpCorrespondingAccount.Properties.ShowFooter = false;
                grdLookUpCorrespondingAccount.Properties.TextEditStyle = TextEditStyles.Standard;
                grdLookUpCorrespondingAccount.Properties.PopupFormMinSize = new System.Drawing.Size(500, 200);


            }

        }

        /// <summary>
        /// Gets the data table.
        /// </summary>
        /// <param name="accounts">The accounts.</param>
        /// <returns></returns>
        private DataTable GetDataTable(IEnumerable<AccountModel> accounts)
        {
            var table = new DataTable();
            table.Columns.Add("AccountCode", typeof(string));
            table.Columns.Add("Information", typeof(string));

            foreach (var itemaccount in accounts)
            {
                string st = itemaccount.AccountCode + "          ";
                st = st.Substring(0, 10) + itemaccount.AccountName;
                table.Rows.Add(itemaccount.AccountCode, st);

            }

            return table;
        }

        /// <summary>
        /// Handles the Load event of the FrmS12AH control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void FrmS12AH_Load(object sender, System.EventArgs e)
        {
            _accountsPresenter.Display();
            _banksPresenter.DisplayActive();
            var currencyCode = GlobalVariable.CurrencyViewReport;
            grdLookUpAccount.EditValue = currencyCode == "USD" ? "11221" : "11222";

        }

        /// <summary>
        /// Handles the Click event of the sbok control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void sbok_Click(object sender, EventArgs e)
        {
            if (grdLookUpAccount.EditValue.ToString() == "")
            {
                XtraMessageBox.Show("Bạn chưa chọn tài khoản", "Lỗi");
                grdLookUpAccount.Focus();
                return;
            }


            if (chkBank.Checked)
            {
                if (cboBank.EditValue == null)
                {
                    XtraMessageBox.Show("Bạn chưa chọn tài khoản ngân hàng", "Lỗi");
                    return ;
                }
                BankId = int.Parse(cboBank.EditValue.ToString());
                var obj = (BankModel)cboBank.GetSelectedDataRow();
                BankName = obj.BankAccount + "-" + obj.BankName;
            }



            var lstAccount = (List<AccountModel>)grdLookUpAccount.Properties.DataSource;
            lstAccount = lstAccount.Where(x => x.AccountCode == grdLookUpAccount.EditValue.ToString()).ToList();
            AccountName = lstAccount[0].AccountName;
            DialogResult = DialogResult.OK;
            GlobalVariable.DateRangeSelectedIndex = dateTimeRangeV1.cboDateRange.SelectedIndex;
        }

        /// <summary>
        /// Handles the QueryPopUp event of the FormatCombo control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="CancelEventArgs"/> instance containing the event data.</param>
        private void FormatCombo_QueryPopUp(object sender, CancelEventArgs e)
        {
            var edit = sender as LookUpEdit;
            if (edit != null) edit.Properties.PopupFormMinSize = new Size(500, 200);
        }


        /// <summary>
        /// Handles the Click event of the sbcancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void sbcancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public IList<BankModel> Banks
        {
            set
            {
                cboBank.Properties.DataSource = value;
                cboBankView.PopulateColumns(value);

                var columnCollection = new List<XtraColumn>
                                           {
                                                   new XtraColumn
                                                   {
                                                       ColumnName = "BankId",
                                                       ColumnVisible = false
                                                   },

                                               new XtraColumn
                                                   {
                                                       ColumnName = "BankAccount",
                                                       ColumnCaption = "Số TK",
                                                       ColumnPosition = 1,
                                                       ColumnVisible = true,
                                                       ColumnWith = 100
                                                   },
                                                  new XtraColumn
                                                   {
                                                       ColumnName = "BankName",
                                                       ColumnCaption = "Số TK",
                                                       ColumnPosition = 2,
                                                       ColumnVisible = true,
                                                       ColumnWith = 100
                                                   },

                                                    new XtraColumn
                                                   {
                                                       ColumnName = "BankAddress",
                                                       ColumnCaption = "Địa chỉ",
                                                       ColumnVisible = false
                                                   },

                                                   new XtraColumn
                                                   {
                                                       ColumnName = "Description",
                                                       ColumnCaption = "Địa chỉ",
                                                       ColumnVisible = false
                                                   },
                                                    new XtraColumn
                                                   {
                                                       ColumnName = "IsActive",
                                                       ColumnVisible = false
                                                   }
                                                   
                                                   
                                           };
                foreach (var column in columnCollection)
                {
                    if (column.ColumnVisible)
                    {
                        cboBank.Properties.View.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboBank.Properties.View.Columns[column.ColumnName].Width = column.ColumnWith;
                    }
                    else cboBank.Properties.View.Columns[column.ColumnName].Visible = false;

                }
                cboBank.Properties.View.OptionsView.ShowIndicator = false;
                cboBank.Properties.ValueMember = "BankId";
                cboBank.Properties.DisplayMember = "BankName";
                cboBank.Properties.ShowFooter = false;

            }
        }

        private void chkBank_CheckedChanged(object sender, EventArgs e)
        {
            cboBank.Enabled = chkBank.Checked;
        }
    }
}
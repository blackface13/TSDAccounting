/***********************************************************************
 * <copyright file="FrmS11AH.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    ThangNK@buca.vn
 * Website:
 * Create Date: Friday, September 12, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using TSD.AccountingSoft.Report.BaseParameterForm;
using TSD.AccountingSoft.Report.CommonClass;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Presenter.Dictionary.Account;
using TSD.AccountingSoft.Session;
using TSD.AccountingSoft.View.Dictionary;
using DateTimeRangeBlockDev.Helper;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System.Linq;
using TSD.AccountingSoft.Presenter.Dictionary.Bank;

namespace TSD.AccountingSoft.Report.ParameterReportForm
{
    public partial class FrmS11AH : FrmXtraBaseParameter, IAccountsView
    {
        private readonly GlobalVariable _dbOptionHelper;
        private readonly AccountsPresenter _accountsPresenter;

        public FrmS11AH()
        {
            InitializeComponent();
            _dbOptionHelper = new GlobalVariable();
            _accountsPresenter = new AccountsPresenter(this);
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

        public string AccountCode
        {
            get
            {
                return grdLookUpAccount.EditValue.ToString();
            }
        }

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
        public string CurrencyCode
        {
            get;
            set;
        }

        public string AccountName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the type of the amount.
        /// </summary>
        /// <value>
        /// The type of the amount.
        /// </value>
        public int AmountType
        {
            get;
            set;
        }

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

        public IList<AccountModel> Accounts
        {
            set
            {
                string currencyCode = GlobalVariable.CurrencyViewReport ?? "";
                grdLookUpAccount.Properties.DataSource = value.Where(x => x.AccountCode.IndexOf("111", StringComparison.Ordinal) == 0 && (x.IsCurrency && x.CurrencyCode == currencyCode)).ToList();
                grdLookUpAccount.Properties.PopulateColumns();

                grdLookUpCorrespondingAccount.Properties.DataSource = value;
                grdLookUpCorrespondingAccount.Properties.PopulateColumns();

                var gridColumnsCollection = new List<XtraColumn>
                    {
                       new XtraColumn { ColumnName = "AccountId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "AccountCode", ColumnCaption = "Mã tài khoản", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 100 },
                        new XtraColumn { ColumnName = "AccountCategoryId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "AccountName", ColumnCaption = "Tên tài khoản", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 300 },
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
                        new XtraColumn { ColumnName = "CurrencyCode", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsProject", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsCapitalAllocate", ColumnVisible = false },
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

        private void FormatCombo_QueryPopUp(object sender, CancelEventArgs e)
        {
            var edit = sender as LookUpEdit;
            if (edit != null) edit.Properties.PopupFormMinSize = new Size(500, 200);
        }

        private void FrmS11H_Load(object sender, EventArgs e)
        {
            _accountsPresenter.Display();
            CurrencyCode = _dbOptionHelper.CurrencyAccounting;
            var currencyCode = GlobalVariable.CurrencyViewReport;
            grdLookUpAccount.EditValue = currencyCode == "USD" ? "11121" : "11122";
        }

        protected override bool ValidData()
        {
            if (grdLookUpAccount.EditValue.ToString() == "")
            {
                XtraMessageBox.Show("Bạn chưa chọn tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                grdLookUpAccount.Focus();
                return false;
            }


            var lstAccount = (List<AccountModel>)grdLookUpAccount.Properties.DataSource;
            lstAccount = lstAccount.Where(x => x.AccountCode == grdLookUpAccount.EditValue.ToString()).ToList();
            AccountName = lstAccount[0].AccountName;
            return true;
        }


    }
}
/***********************************************************************
 * <copyright file="FrmS03BH.cs" company="BUCA JSC">
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
using System.Linq;
using System.Collections.Generic;
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
using DevExpress.Utils;

namespace TSD.AccountingSoft.Report.ParameterReportForm
{
    public partial class FrmS03BH : FrmXtraBaseParameter, IAccountsView
    {
        private readonly GlobalVariable _dbOptionHelper;
        private readonly AccountsPresenter _accountsPresenter;

        public FrmS03BH()
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

        public string AccountName { set; get; }

        public IList<AccountModel> Accounts
        {
            set
            {
                var gridColumnsCollection = new List<XtraColumn>
                {
                    new XtraColumn{ColumnName = "AccountCode",ColumnCaption = "Mã tài khoản",ColumnPosition = 1,ColumnVisible = true, ColumnWith = 25,Alignment = HorzAlignment.Center },
                    new XtraColumn { ColumnName = "AccountName",ColumnCaption = "Tên tài khoản",ColumnVisible = true,ColumnPosition = 2,ColumnWith = 75,Alignment = HorzAlignment.Center }
                };

                GridLookUpItem.HideVisibleColumn(value, gridColumnsCollection, grdLookUpAccount, grdLookUpAccountView, "AccountCode", "AccountCode");
                GridLookUpItem.HideVisibleColumn(value, gridColumnsCollection, grdLookUpCorrespondingAccount, grdLookUpCorrespondingAccountView, "AccountCode", "AccountCode");

                grdLookUpAccount.Enter += gridLookUpEdit_Enter;
                grdLookUpCorrespondingAccount.Enter += gridLookUpEdit_Enter;
            }

        }

        private void FrmS03BH_Load(object sender, EventArgs e)
        {
            _accountsPresenter.Display();
            CurrencyCode = _dbOptionHelper.CurrencyAccounting;
        }

        private void sbok_Click(object sender, EventArgs e)
        {
            if (grdLookUpAccount.EditValue.ToString() == "")
            {
                XtraMessageBox.Show("Bạn chưa chọn tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                grdLookUpAccount.Focus();
                return;
            }
            var lstAccount = (List<AccountModel>)grdLookUpAccount.Properties.DataSource;
            lstAccount = lstAccount.Where(x => x.AccountCode == grdLookUpAccount.EditValue.ToString()).ToList();
            AccountName = lstAccount[0].AccountName;
            DialogResult = DialogResult.OK;
            GlobalVariable.DateRangeSelectedIndex = dateTimeRangeV1.cboDateRange.SelectedIndex;
        }

        private void FormatCombo_QueryPopUp(object sender, CancelEventArgs e)
        {
            var edit = sender as LookUpEdit;
            if (edit != null) edit.Properties.PopupFormMinSize = new Size(500, 400);
        }


        private void sbcancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
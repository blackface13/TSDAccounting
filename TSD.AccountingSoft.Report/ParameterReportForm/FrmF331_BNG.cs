/***********************************************************************
 * <copyright file="FrmF331_BNG.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Wednesday, September 24, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Presenter.Dictionary.Account;
using TSD.AccountingSoft.Report.BaseParameterForm;
using TSD.AccountingSoft.Session;
using TSD.AccountingSoft.View.Dictionary;
using DateTimeRangeBlockDev.Helper;
using DevExpress.XtraEditors;

namespace TSD.AccountingSoft.Report.ParameterReportForm
{
    /// <summary>
    /// Tham so bao cao quy tam giu 33189
    /// </summary>
    public partial class FrmF331BNG : FrmXtraBaseParameter, IAccountsView
    {
        /// <summary>
        /// The _accounts presenter
        /// </summary>
        private readonly AccountsPresenter _accountsPresenter;

        private IList<AccountModel> _accountModels;

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
                return dateTimeRange.FromDate.ToShortDateString();
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
                return dateTimeRange.ToDate.ToShortDateString();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is total band in new page.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is total band in new page; otherwise, <c>false</c>.
        /// </value>
        public bool IsTotalBandInNewPage
        {
            get { return chkMoveTotalInNewPage.Checked; }
            set { chkMoveTotalInNewPage.Checked = value; }
        }

        /// <summary>
        /// Gets the account list.
        /// </summary>
        /// <value>
        /// The account list.
        /// </value>
        public string AccountList
        {
            get
            {
                var list = cboAccount.Properties.GetItems().GetCheckedValues();
                string listKey = list.Aggregate("", (current, key) => current + "," + key);
                listKey = listKey.Remove(0, 1);
                return listKey;
            }

        }

        /// <summary>
        /// Gets the name of the account.
        /// </summary>
        /// <value>
        /// The name of the account.
        /// </value>
        public string AccountName
        {
            get
            {
                if (AccountList.Contains(","))
                {
                    return "Tổng hợp - Quỹ tạm giữ khác";
                }
                var accountModel = _accountModels.Single(x => x.AccountCode == AccountList);
                return  accountModel.AccountName+ " - " + AccountList;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmF331BNG"/> class.
        /// </summary>
        public FrmF331BNG()
        {
            InitializeComponent();
            _accountsPresenter = new AccountsPresenter(this);
            dateTimeRange.DateRangePeriodMode = DateRangeMode.Reduce;
            dateTimeRange.InitSelectedIndex = GlobalVariable.DateRangeSelectedIndex;
        }

        /// <summary>
        /// Handles the Load event of the FrmF331BNG control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FrmF331BNG_Load(object sender, EventArgs e)
        {
            _accountsPresenter.DisplayActive();
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
                cboAccount.Properties.DataSource = value.Where(x => x.AccountCode != "33189" && x.AccountCode.IndexOf("33189", StringComparison.Ordinal) == 0).ToList();
                _accountModels = value;
                cboAccount.Properties.DisplayMember = "AccountCode";
                cboAccount.Properties.ValueMember = "AccountCode";
            }
        }

        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns></returns>
        protected override bool ValidData()
        {
            if (cboAccount.Text.Length <= 0)
            {
                XtraMessageBox.Show("Bạn chưa chọn tài khoản cần xem. Vui lòng chọn lại!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboAccount.Focus();
                return false;
            }
            return true;
        }
    }
}
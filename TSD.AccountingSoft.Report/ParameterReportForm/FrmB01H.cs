/***********************************************************************
 * <copyright file="FrmB01H.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuanHM
 * Email:    tuanhm@buca.vn
 * Website:
 * Create Date: Thursday, July 11, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/
using System;
using System.Globalization;
using System.Windows.Forms;
using TSD.AccountingSoft.Report.BaseParameterForm;
using TSD.AccountingSoft.Session;
using DateTimeRangeBlockDev.Helper;
using DevExpress.XtraEditors;

namespace TSD.AccountingSoft.Report.ParameterReportForm
{
    public partial class FrmB01H : FrmXtraBaseParameter
    {
        private readonly GlobalVariable _dbOptionHelper;
        protected string CurrencyAccounting;
        protected string CurrencyAccountingUSD = "USD";
        public FrmB01H()
        {
            InitializeComponent();
            _dbOptionHelper = new GlobalVariable();
            dateTimeRangeV1.DateRangePeriodMode = DateRangeMode.Reduce;
            dateTimeRangeV1.InitSelectedIndex = GlobalVariable.DateRangeSelectedIndex;
            grdLookUpAccount.SelectedIndex = 0;
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

        public int AccountType
        {
            get { return grdLookUpAccount.SelectedIndex; }
            set { grdLookUpAccount.SelectedIndex = value; }
        }

        private void FrmB14Q_Load(object sender, EventArgs e)
        {
            CurrencyAccounting = _dbOptionHelper.CurrencyAccounting;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (dateTimeRangeV1.FromDate.ToString(CultureInfo.InvariantCulture) == "")
            {
                XtraMessageBox.Show("Bạn chưa chọn ngày tính giá", "Thông báo");
                return;
            }
            if (dateTimeRangeV1.ToDate.ToString(CultureInfo.InvariantCulture) == "")
            {
                XtraMessageBox.Show("Bạn chưa chọn ngày tính giá", "Thông báo");
                return;
            }
            if (GlobalVariable.CurrencyViewReport == "" && GlobalVariable.AmountTypeViewReport == 2)
            {
                XtraMessageBox.Show("Bạn chưa chọn loại tiền", "Thông báo");
                return;
            }
            DialogResult = DialogResult.OK;
            GlobalVariable.DateRangeSelectedIndex = dateTimeRangeV1.cboDateRange.SelectedIndex;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
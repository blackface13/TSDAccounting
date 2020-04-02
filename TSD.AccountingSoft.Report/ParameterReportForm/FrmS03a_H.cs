/***********************************************************************
 * <copyright file="FrmS03a_H.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    ThangNK@buca.vn
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
    public partial class FrmS03a_H : FrmXtraBaseParameter
    {
        protected string CurrencyAccounting;
        protected string CurrencyAccountingUSD = "USD";
        private readonly GlobalVariable _dbOptionHelper;
        public bool CheckValidate = false;
        public FrmS03a_H()
        {
            InitializeComponent();
            _dbOptionHelper = new GlobalVariable();
            dateTimeRangeV1.DateRangePeriodMode = DateRangeMode.Reduce;
            dateTimeRangeV1.InitSelectedIndex = GlobalVariable.DateRangeSelectedIndex;

        }

        /// <summary>
        /// Gets or sets the repor date.
        /// </summary>
        /// <value>
        /// The repor date.
        /// </value>
        public string ReporDate
        {
            get; set; }

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
        /// Gets or sets the currency code.
        /// </summary>
        /// <value>
        /// The currency code.
        /// </value>
        public string CurrencyCode
        {
            get
            {
                return GlobalVariable.CurrencyViewReport;//.EditValue;
            }
        }

        public bool IsTotalBandInNewPage
        {
            get { return chkMoveTotalInNewPage.Checked; }
            set { chkMoveTotalInNewPage.Checked = value; }
        }

        private void FrmS03a_H_Load(object sender, EventArgs e)
        {
            CurrencyAccounting = _dbOptionHelper.CurrencyAccounting;
            InitDefaultCurrencies();
        }

        protected void InitDefaultCurrencies()
        {
           // cboCurrencyCode.Properties.Items.Add(CurrencyAccounting);
           // cboCurrencyCode.Properties.Items.Add(CurrencyAccountingUSD);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

            if (dateTimeRangeV1.FromDate.ToString(CultureInfo.InvariantCulture) == "")
            {
                XtraMessageBox.Show("Bạn chưa chọn ngày tính giá", "Lỗi");
                return;
            }
            if (dateTimeRangeV1.ToDate.ToString(CultureInfo.InvariantCulture) == "")
            {
                XtraMessageBox.Show("Bạn chưa chọn ngày tính giá", "Lỗi");
                return;
            }
            if (GlobalVariable.CurrencyViewReport == "" && GlobalVariable.AmountTypeViewReport==2)
            {
                XtraMessageBox.Show("Bạn chưa chọn tiền", "Lỗi");
                return;
            }
            DialogResult = DialogResult.OK;
            GlobalVariable.DateRangeSelectedIndex = dateTimeRangeV1.cboDateRange.SelectedIndex;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
        }
    }
}
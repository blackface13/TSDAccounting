/***********************************************************************
 * <copyright file="FrmXtraFixedAssetFAInventory.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThoDD
 * Email:    ThoDD@buca.vn
 * Website:
 * Create Date: Friday, September 12, 2014
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
    public partial class FrmXtraFixedAssetFAInventory : FrmXtraBaseParameter
    {
        protected string CurrencyAccounting;
        protected string CurrencyAccountingUSD = "USD";
        private readonly GlobalVariable _dbOptionHelper;
        public bool CheckValidate = false;
        public FrmXtraFixedAssetFAInventory()
        {
            InitializeComponent();
            _dbOptionHelper = new GlobalVariable();
            dateTimeRangeV1.DateRangePeriodMode = DateRangeMode.Reduce;
            dateTimeRangeV1.InitSelectedIndex = GlobalVariable.DateRangeSelectedIndex;
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

        private void FrmXtraFixedAssetFAInventory_Load(object sender, EventArgs e)
        {
            CurrencyAccounting = _dbOptionHelper.CurrencyAccounting;
        }

        protected override bool ValidData()
        {
            if (dateTimeRangeV1.FromDate.ToString(CultureInfo.InvariantCulture) == "")
            {
                XtraMessageBox.Show("Bạn chưa chọn ngày tính giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (dateTimeRangeV1.ToDate.ToString(CultureInfo.InvariantCulture) == "")
            {
                XtraMessageBox.Show("Bạn chưa chọn ngày tính giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            
            DialogResult = DialogResult.OK;
            GlobalVariable.DateRangeSelectedIndex = dateTimeRangeV1.cboDateRange.SelectedIndex;
            return true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}

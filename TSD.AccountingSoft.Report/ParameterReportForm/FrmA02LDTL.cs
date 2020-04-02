/***********************************************************************
 * <copyright file="FrmA02LDTL.cs" company="BUCA JSC">
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
    /// <summary>
    /// 
    /// </summary>
    public partial class FrmA02LDTL : FrmXtraBaseParameter
    {

        public FrmA02LDTL()
        {
            InitializeComponent();
            dateTimeRangeV1.DateRangePeriodMode = DateRangeMode.Reduce;
            dateTimeRangeV1.InitSelectedIndex = GlobalVariable.DateRangeSelectedIndex;
        }

        /// <summary>
        /// Gets or sets the repor date.
        /// </summary>
        /// <value>
        /// The repor date.
        /// </value>
        public string ReporDate { get; set; }

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
            get
            {
                return chkMoveTotalInNewPage.Checked;
            }
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
          
            DialogResult = DialogResult.OK;
            GlobalVariable.DateRangeSelectedIndex = dateTimeRangeV1.cboDateRange.SelectedIndex;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
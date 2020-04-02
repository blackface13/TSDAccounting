/***********************************************************************
 * <copyright file="FrmF03_BNG.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Saturday, August 23, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Windows.Forms;
using TSD.AccountingSoft.Report.BaseParameterForm;
using TSD.AccountingSoft.Session;
using DateTimeRangeBlockDev.Helper;
using DevExpress.XtraEditors;

namespace TSD.AccountingSoft.Report.ParameterReportForm
{
    public partial class FrmF09Bng : FrmXtraBaseParameter
    {
        /// <summary>
        /// Gets or sets from date.
        /// </summary>
        /// <value>
        /// From date.
        /// </value>
        public string FromDate
        {
            get { return dateTimeRange.FromDate.ToShortDateString(); }
            set { dateTimeRange.FromDate = DateTime.Parse(value); }
        }

        /// <summary>
        /// Gets or sets the reference date.
        /// </summary>
        /// <value>
        /// The reference date.
        /// </value>
        public string ToDate
        {
            get { return dateTimeRange.ToDate.ToShortDateString(); }
            set { dateTimeRange.ToDate = DateTime.Parse(value); }
        }

        public FrmF09Bng()
        {
            InitializeComponent();
            var globalVariable = new GlobalVariable();

            dateTimeRange.DateRangePeriodMode = DateRangeMode.Quarter;
            dateTimeRange.InitSelectedIndex = GlobalVariable.DateRangeSelectedIndex;
            dateTimeRange.InitData(DateTime.Parse(globalVariable.PostedDate));
        }

        protected override bool ValidData()
        {

            if (dateTimeRange.cboDateRange.SelectedIndex != 0 &&
                dateTimeRange.cboDateRange.SelectedIndex != 1 && dateTimeRange.cboDateRange.SelectedIndex != 2 &&
                dateTimeRange.cboDateRange.SelectedIndex != 3)
            {
                XtraMessageBox.Show("Kỳ báo cáo phải chọn là Quý, vui lòng kiểm tra lại!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private void FrmF03Bng_Load(object sender, EventArgs e)
        {
            var globalVariable = new GlobalVariable();

            var currentMonth = DateTime.Parse(globalVariable.PostedDate).Month;
            switch (currentMonth)
            {
                case 1:
                case 2:
                case 3:
                    dateTimeRange.SetComboIndex(0);
                    break;
                case 4:
                case 5:
                case 6:
                    dateTimeRange.SetComboIndex(1);
                    break;
                case 7:
                case 8:
                case 9:
                    dateTimeRange.SetComboIndex(2);
                    break;
                case 10:
                case 11:
                case 12:
                    dateTimeRange.SetComboIndex(3);
                    break;
            }
        }
    }
}
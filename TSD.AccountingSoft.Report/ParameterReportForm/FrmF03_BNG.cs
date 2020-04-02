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
using System.Drawing;
using TSD.AccountingSoft.Report.BaseParameterForm;
using TSD.AccountingSoft.Session;
using DateTimeRangeBlockDev.Helper;

namespace TSD.AccountingSoft.Report.ParameterReportForm
{
    public partial class FrmF03Bng : FrmXtraBaseParameter
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
        /// Gets or sets a value indicating whether this instance is detail to usd.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is detail to usd; otherwise, <c>false</c>.
        /// </value>
        public bool IsDetailToUSD
        {
            get { return chkDetailToUSD.Checked; }
            set { chkDetailToUSD.Checked = value; }
        }

        public FrmF03Bng()
        {
            InitializeComponent();
            var globalVariable = new GlobalVariable();

            dateTimeRange.DateRangePeriodMode = DateRangeMode.Reduce;
            dateTimeRange.InitSelectedIndex = GlobalVariable.DateRangeSelectedIndex;
            dateTimeRange.InitData(DateTime.Parse(globalVariable.PostedDate));
        }

        protected override bool ValidData()
        {
            return true;
        }

        private void FrmF03Bng_Load(object sender, EventArgs e)
        {
            labelControl1.Visible = false;
            Size = new Size(337, 231);
            chkMoveTotalInNewPage.Location = new Point(5, 120);
            dateTimeRange.SetComboIndex(GlobalVariable.DateRangeSelectedIndex);
        }

        private void chkDetailToUSD_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDetailToUSD.Checked)
            {
                labelControl1.Visible = true;
                Size = new Size(337, 295);
                chkMoveTotalInNewPage.Location = new Point(5, 198);
            }
            else
            {
                labelControl1.Visible = false;
                Size = new Size(337, 231);
                chkMoveTotalInNewPage.Location = new Point(5, 120);
            }
        }
    }
}
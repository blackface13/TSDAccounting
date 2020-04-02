/***********************************************************************
 * <copyright file="FrmB03BNG.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 19 May 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using TSD.AccountingSoft.Report.BaseParameterForm;
using TSD.AccountingSoft.Session;
using DateTimeRangeBlockDev.Helper;


namespace TSD.AccountingSoft.Report.ParameterReportForm
{
    /// <summary>
    /// FrmB03BNG
    /// </summary>
    public partial class FrmB03BNG : FrmXtraBaseParameter
    {
        /// <summary>
        /// Gets or sets from date.
        /// </summary>
        /// <value>
        /// From date.
        /// </value>
        public string FromDate
        {
            get { return dateTimeRanger.FromDate.ToShortDateString(); }
            set { dateTimeRanger.FromDate = DateTime.Parse(value); }
        }

        /// <summary>
        /// Gets or sets the reference date.
        /// </summary>
        /// <value>
        /// The reference date.
        /// </value>
        public string ToDate
        {
            get { return dateTimeRanger.ToDate.ToShortDateString(); }
            set { dateTimeRanger.ToDate = DateTime.Parse(value); }
        }

        /// <summary>
        /// Gets the repor date.
        /// </summary>
        /// <value>
        /// The repor date.
        /// </value>
        public string ReporDate { get; set; }

        public bool IsTotalBandInNewPage
        {
            get { return chkMoveTotalInNewPage.Checked; }
            set { chkMoveTotalInNewPage.Checked = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmB03BNG"/> class.
        /// </summary>
        public FrmB03BNG()
        {
            InitializeComponent();
            dateTimeRanger.DateRangePeriodMode = DateRangeMode.Reduce;
            dateTimeRanger.InitSelectedIndex = GlobalVariable.DateRangeSelectedIndex;
        }

        /// <summary>
        /// Handles the Load event of the FrmB03BNG control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FrmB03BNG_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Handles the Click event of the btnExit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

        }
    }
}
/***********************************************************************
 * <copyright file="FrmXtraGeneralPaymentEstimate.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 09 May 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using TSD.AccountingSoft.Report.BaseParameterForm;
using TSD.AccountingSoft.Session;

namespace TSD.AccountingSoft.Report.ParameterReportForm
{
    /// <summary>
    /// FrmXtraGeneralPaymentEstimate
    /// </summary>
    public partial class FrmXtraGeneralPaymentEstimate : FrmXtraBaseParameter
    {
        private readonly GlobalVariable _dbOptionHelper;

        /// <summary>
        /// Gets the year of estimate.
        /// </summary>
        /// <value>
        /// The year of estimate.
        /// </value>
        public short YearOfEstimate
        {
            get { return short.Parse(spinYearOfPlaning.Text); }

        }

        /// <summary>
        /// Gets the repor date.
        /// </summary>
        /// <value>
        /// The repor date.
        /// </value>
        public string ReporDate
        {
            get { return ((DateTime)dtReportDate.EditValue).ToShortDateString(); }
            set { dtReportDate.EditValue = DateTime.Parse(value); }
        }

        /// <summary>
        /// Gets the currency code.
        /// </summary>
        /// <value>
        /// The currency code.
        /// </value>
        public string CurrencyCode
        {
            get { return (string)cboCurrencyCode.EditValue; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmXtraGeneralPaymentEstimate"/> class.
        /// </summary>
        public FrmXtraGeneralPaymentEstimate()
        {
            InitializeComponent();
            _dbOptionHelper = new GlobalVariable();
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

        private void FrmXtraGeneralPaymentEstimate_Load(object sender, EventArgs e)
        {
            spinYearOfPlaning.EditValue = DateTime.Parse(_dbOptionHelper.PostedDate).Year;
        }
    }
}
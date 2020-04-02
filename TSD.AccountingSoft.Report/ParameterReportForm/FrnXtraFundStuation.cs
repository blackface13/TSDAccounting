/***********************************************************************
 * <copyright file="FrnXtraFundStuation.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 14 June 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using TSD.AccountingSoft.Report.BaseParameterForm;
using TSD.AccountingSoft.Session;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.Presenter.Dictionary.ElectricalWork;


namespace TSD.AccountingSoft.Report.ParameterReportForm
{
    /// <summary>
    /// FrnXtraFundStuation
    /// </summary>
    public partial class FrnXtraFundStuation : FrmXtraBaseParameter,IElectricalWorkView
    {
        private readonly GlobalVariable _dbOptionHelper;
        private ElectricalWorkPresenter _electricalWorkPresenter;

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

        public string Approval
        {
            get { return memoApproval.Text.ToString(); }

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FrnXtraFundStuation"/> class.
        /// </summary>
        public FrnXtraFundStuation()
        {
            InitializeComponent();
            _dbOptionHelper = new GlobalVariable();
            _electricalWorkPresenter = new ElectricalWorkPresenter(this);

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

        private void FrnXtraFundStuation_Load(object sender, EventArgs e)
        {
            spinYearOfPlaning.EditValue = DateTime.Parse(_dbOptionHelper.PostedDate).Year;
            _electricalWorkPresenter.Display(DateTime.Parse(_dbOptionHelper.PostedDate).Year);

        }


        public int ElectricalWorkId
        {
            get;
            set;
        }

        public int PostedDate
        {
            get {return int.Parse(spinYearOfPlaning.EditValue.ToString());}
            set { spinYearOfPlaning.EditValue=value; }
        }

        public string ElectricalWorName
        {
            get { return memoApproval.Text;}
            set{ memoApproval.Text = value;}
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _electricalWorkPresenter.Save();
        }
    }
}
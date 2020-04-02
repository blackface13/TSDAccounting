/***********************************************************************
 * <copyright file="FrmXtraEmployeeLeasingsDetail.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 09 June 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Windows.Forms;
using TSD.AccountingSoft.Presenter.Dictionary.EmployeeLeasing;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.Resources;
using DevExpress.XtraEditors;


namespace TSD.AccountingSoft.WindowsForm.FormDictionary
{
    /// <summary>
    /// FrmXtraEmployeeLeasingsDetail
    /// </summary>
    public partial class FrmXtraEmployeeLeasingDetail : FrmXtraBaseCategoryDetail, IEmployeeLeasingView
    {
        private readonly EmployeeLeasingPresenter _employeeLeasingPresenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmXtraEmployeeLeasingDetail"/> class.
        /// </summary>
        public FrmXtraEmployeeLeasingDetail()
        {
            InitializeComponent();
            _employeeLeasingPresenter = new EmployeeLeasingPresenter(this);
        }

        #region Function Overrides

        /// <summary>
        /// Initializes the data.
        /// </summary>
        protected override void InitData()
        {
            if (KeyValue != null)
                _employeeLeasingPresenter.Display(KeyValue);
            else txtEmployeeLeasingCode.Text = GetAutoNumber();
        }

        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns></returns>
        protected override bool ValidData()
        {
            if (string.IsNullOrEmpty(EmployeeLeasingCode))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResEmployeeLeasingCode"),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmployeeLeasingCode.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(EmployeeLeasingName))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("EmployeeLeasingName"),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmployeeLeasingName.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// Saves the data.
        /// </summary>
        /// <returns></returns>
        protected override int SaveData()
        {
            IsLeasing = false;
            return _employeeLeasingPresenter.Save();
        }

        #endregion

        #region EmployeeLeasing

        /// <summary>
        /// Gets or sets the employee leasing identifier.
        /// </summary>
        /// <value>
        /// The employee leasing identifier.
        /// </value>
        public int EmployeeLeasingId { get; set; }

        /// <summary>
        /// Gets or sets the employee leasing code.
        /// </summary>
        /// <value>
        /// The employee leasing code.
        /// </value>
        public string EmployeeLeasingCode
        {
            get { return txtEmployeeLeasingCode.Text; }
            set { txtEmployeeLeasingCode.Text = value; }
        }

        /// <summary>
        /// Gets or sets the name of the employee leasing.
        /// </summary>
        /// <value>
        /// The name of the employee leasing.
        /// </value>
        public string EmployeeLeasingName
        {
            get { return txtEmployeeLeasingName.Text; }
            set { txtEmployeeLeasingName.Text = value; }
        }

        /// <summary>
        /// Gets or sets the job candidate.
        /// </summary>
        /// <value>
        /// The job candidate.
        /// </value>
        public string JobCandidate
        {
            get { return txtJobCandidate.Text; }
            set { txtJobCandidate.Text = value; }
        }

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>
        /// The start date.
        /// </value>
        public DateTime StartDate
        {
            get { return (DateTime)dtStartDate.EditValue; }
            set { dtStartDate.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        /// <value>
        /// The end date.
        /// </value>
        public DateTime EndDate
        {
            get { return (DateTime)dtEndDate.EditValue; }
            set { dtEndDate.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description
        {
            get { return memoDescription.Text; }
            set { memoDescription.Text = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [is active].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is active]; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive
        {
            get { return chkIsActive.Checked; }
            set { chkIsActive.Checked = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [is leasing].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is leasing]; otherwise, <c>false</c>.
        /// </value>
        public bool IsLeasing { get; set; }

        /// <summary>
        /// Gets or sets the salary price.
        /// </summary>
        /// <value>
        /// The salary price.
        /// </value>
        public decimal SalaryPrice { get; set; }

        /// <summary>
        /// Gets or sets the insurance price.
        /// </summary>
        /// <value>
        /// The insurance price.
        /// </value>
        public decimal InsurancePrice { get; set; }

        /// <summary>
        /// Gets or sets the uniform price.
        /// </summary>
        /// <value>
        /// The uniform price.
        /// </value>
        public decimal UniformPrice { get; set; }

        #endregion
    }
}
/***********************************************************************
 * <copyright file="FrmXtraBuildingDetail.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 10 June 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/
using System;
using System.Windows.Forms;
using TSD.AccountingSoft.Presenter.Dictionary.Building;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.Resources;
using DevExpress.XtraEditors;


namespace TSD.AccountingSoft.WindowsForm.FormDictionary
{
    /// <summary>
    /// FrmXtraBuildingDetail
    /// </summary>
    public partial class FrmXtraBuildingDetail : FrmXtraBaseCategoryDetail, IBuildingView
    {
        private readonly BuildingPresenter _buildingPresenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmXtraBuildingDetail"/> class.
        /// </summary>
        public FrmXtraBuildingDetail()
        {
            InitializeComponent();
            _buildingPresenter = new BuildingPresenter(this);
        }

        #region Function Overrides

        /// <summary>
        /// Initializes the data.
        /// </summary>
        protected override void InitData()
        {
            if (KeyValue != null)
                _buildingPresenter.Display(KeyValue);
            else txtBuildingCode.Text = GetAutoNumber();
        }

        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns></returns>
        protected override bool ValidData()
        {
            if (string.IsNullOrEmpty(BuildingCode))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ReBuildingName"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBuildingName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(BuildingName))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ReBuildingName"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBuildingName.Focus();
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
            return _buildingPresenter.Save();
        }

        #endregion

        #region Building Members

        /// <summary>
        /// Gets or sets the building identifier.
        /// </summary>
        /// <value>
        /// The building identifier.
        /// </value>
        public int BuildingId { get; set; }

        /// <summary>
        /// Gets or sets the building code.
        /// </summary>
        /// <value>
        /// The building code.
        /// </value>
        public string BuildingCode
        {
            get { return txtBuildingCode.Text; }
            set { txtBuildingCode.Text = value; }
        }

        /// <summary>
        /// Gets or sets the name of the building.
        /// </summary>
        /// <value>
        /// The name of the building.
        /// </value>
        public string BuildingName
        {
            get { return txtBuildingName.Text; }
            set { txtBuildingName.Text = value; }
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
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        public string Address
        {
            get { return txtAddress.Text; }
            set { txtAddress.Text = value; }
        }

        /// <summary>
        /// Gets or sets the area.
        /// </summary>
        /// <value>
        /// The area.
        /// </value>
        public float Area
        {
            get { return float.Parse(spinArea.EditValue.ToString()); }
            set { spinArea.EditValue = value; }
        }

        /// <summary>
        /// Gets the unit price.
        /// </summary>
        /// <value>
        /// The unit price.
        /// </value>
        public decimal UnitPrice
        {
            get { return (decimal)spinUnitPrice.EditValue; }
            set { spinUnitPrice.EditValue = value; }
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
        /// </value>spinUniformPrice
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

        #endregion
    }
}
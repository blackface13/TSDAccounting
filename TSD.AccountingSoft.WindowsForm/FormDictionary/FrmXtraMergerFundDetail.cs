/***********************************************************************
 * <copyright file="FrmXtraMergerFundDetail.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   THODD
 * Email:    thodd@buca.vn
 * Website:
 * Create Date: Tuesday, February 11, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using System.Windows.Forms;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Presenter.Dictionary.MergerFund;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.WindowsForm.CommonClass;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.Resources;
using TSD.Enum;
using DevExpress.XtraEditors;


namespace TSD.AccountingSoft.WindowsForm.FormDictionary
{
    /// <summary>
    /// Class FrmXtraMergerFundDetail.
    /// </summary>
    public partial class FrmXtraMergerFundDetail : FrmXtraBaseTreeDetail, IMergerFundView, IMergerFundsView
    {
        /// <summary>
        /// The _merger fund presenter
        /// </summary>
        private readonly MergerFundPresenter _mergerFundPresenter;

        /// <summary>
        /// The _merger funds presenter
        /// </summary>
        private readonly MergerFundsPresenter _mergerFundsPresenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmXtraMergerFundDetail"/> class.
        /// </summary>
        public FrmXtraMergerFundDetail()
        {
            InitializeComponent();
            _mergerFundPresenter = new MergerFundPresenter(this);
            _mergerFundsPresenter = new MergerFundsPresenter(this);
        }

        #region IMergerFundsView Members

        /// <summary>
        /// Sets the merger funds.
        /// </summary>
        /// <value>The merger funds.</value>
        public IList<MergerFundModel> MergerFunds
        {
            set
            {
                GridLookUpItem.MergerFund(value ?? new List<MergerFundModel>(), grdLockUpParentID, grdLockUpParentIDView, "MergerFundCode", KeyFieldName);
            }
        }

        #endregion

        #region IMergerFundView Members

        /// <summary>
        /// Gets or sets the mergerFund identifier.
        /// </summary>
        /// <value>The mergerFund identifier.</value>
        public int MergerFundId { get; set; }

        /// <summary>
        /// Gets or sets the mergerFund code.
        /// </summary>
        /// <value>The mergerFund code.</value>
        public string MergerFundCode
        {
            get { return txtMergerFundCode.Text; }
            set { txtMergerFundCode.Text = value; }
        }

        /// <summary>
        /// Gets or sets the name of the mergerFund.
        /// </summary>
        /// <value>The name of the mergerFund.</value>
        public string MergerFundName
        {
            get { return txtMergerFundName.Text; }
            set { txtMergerFundName.Text = value; }
        }

        /// <summary>
        /// Gets or sets the parent identifier.
        /// </summary>
        /// <value>The parent identifier.</value>
        public int? ParentId
        {
            get
            {
                return grdLockUpParentID.EditValue == null
                           ? null
                           : (int?)grdLockUpParentID.EditValue;//.GetColumnValue(KeyFieldName);
            }
            set
            {
                grdLockUpParentID.EditValue = value;
            }
        }

        /// <summary>
        /// Gets or sets the is system.
        /// </summary>
        /// <value>The is system.</value>
        public bool IsSystem { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is active].
        /// </summary>
        /// <value><c>true</c> if [is active]; otherwise, <c>false</c>.</value>
        public bool IsActive
        {
            get { return chkIsActive.Checked; }
            set { chkIsActive.Checked = value; }
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description
        {
            get { return memoDescription.Text; }
            set { memoDescription.Text = value; }
        }

        /// <summary>
        /// Gets or sets the grade.
        /// </summary>
        /// <value>The grade.</value>
        public int Grade { get; set; }

        /// <summary>
        /// Gets or sets the name of the foreign.
        /// </summary>
        /// <value>The name of the foreign.</value>
        public string ForeignName { get; set; }

        #endregion

        /// <summary>
        /// Initializes the data.
        /// </summary>
        protected override void InitData()
        {
            _mergerFundsPresenter.Display();
            if (KeyValue == null)
                return;
            _mergerFundPresenter.Display(KeyValue);
        }

        /// <summary>
        /// Focuses the control.
        /// </summary>
        protected override void InitControls()
        {
            txtMergerFundCode.Focus();
            grdLockUpParentID.Properties.ReadOnly = (ActionMode == ActionModeEnum.Edit) && HasChildren;
        }

        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        protected override bool ValidData()
        {
            if (string.IsNullOrEmpty(MergerFundCode))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResMergerFundCode"),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMergerFundCode.Focus();
                return false;
            }
            var mergerFunds = _mergerFundsPresenter.GetMergerFunds();
            foreach (var mergerFund in mergerFunds)
            {
                // option Edit
                if (MergerFundId > 0)
                {
                    if (mergerFund.MergerFundId == MergerFundId) continue;
                    if (mergerFund.MergerFundCode != MergerFundCode) continue;
                    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResCheckMergerFundsCode"),
                                        ResourceHelper.GetResourceValueByName("ResDetailContent"),
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMergerFundCode.Focus();
                    return false;
                }
                if (mergerFund.MergerFundCode != MergerFundCode) continue;
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResCheckMergerFundsCode"),
                                    ResourceHelper.GetResourceValueByName("ResDetailContent"),
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMergerFundCode.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(MergerFundName))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResMergerFundName"),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMergerFundName.Focus();
                return false;
            }
            if (MergerFundCode == grdLockUpParentID.Text)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResCodeSameAsParentError"),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                grdLockUpParentID.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// Saves the data.
        /// </summary>
        /// <returns>System.Int32.</returns>
        protected override int SaveData()
        {
            return _mergerFundPresenter.Save();
        }
    }
}

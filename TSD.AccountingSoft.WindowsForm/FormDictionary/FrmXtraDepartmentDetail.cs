/***********************************************************************
 * <copyright file="FrmXtraDepartmentDetail.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 07 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using System.Windows.Forms;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Presenter.Dictionary.Department;
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
    /// class FrmXtraDepartmentDetail
    /// </summary>
    public partial class FrmXtraDepartmentDetail : FrmXtraBaseTreeDetail, IDepartmentView, IDepartmentsView
    {
        private readonly DepartmentPresenter _departmentPresenter;
        private readonly DepartmentsPresenter _departmentsPresenter;

        public FrmXtraDepartmentDetail()
        {
            InitializeComponent();
            _departmentPresenter = new DepartmentPresenter(this);
            _departmentsPresenter = new DepartmentsPresenter(this);
        }

        #region IDepartmentsView Members

        public IList<DepartmentModel> Departments
        {
            set
            {
                GridLookUpItem.Department(value, grdLockUpParentId, grdLockUpParentView, "DepartmentName", KeyFieldName);
            }
        }

        #endregion

        #region IDepartmentView Members

        /// <summary>
        /// Gets or sets the department identifier.
        /// </summary>
        /// <value>
        /// The department identifier.
        /// </value>
        public int DepartmentId { get; set; }

        /// <summary>
        /// Gets or sets the department code.
        /// </summary>
        /// <value>
        /// The department code.
        /// </value>
        public string DepartmentCode
        {
            get { return txtDepartmentCode.Text; }
            set { txtDepartmentCode.Text = value; }
        }

        /// <summary>
        /// Gets or sets the name of the department.
        /// </summary>
        /// <value>
        /// The name of the department.
        /// </value>
        public string DepartmentName
        {
            get { return txtDepartmentName.Text; }
            set { txtDepartmentName.Text = value; }
        }

        /// <summary>
        /// Gets or sets the parent identifier.
        /// </summary>
        /// <value>
        /// The parent identifier.
        /// </value>
        public int? ParentId
        {
            get
            {
                var department = (DepartmentModel)grdLockUpParentId.GetSelectedDataRow();
                if (department != null)
                    return department.DepartmentId;
                else
                    return null;
            }
            set
            {
                grdLockUpParentId.EditValue = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [is system].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is system]; otherwise, <c>false</c>.
        /// </value>
        public bool IsSystem { get; set; }

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

        #endregion

        /// <summary>
        /// Initializes the data.
        /// </summary>
        protected override void InitData()
        {
            _departmentsPresenter.Display();
            if (KeyValue != null) { _departmentPresenter.Display(KeyValue); }
            else
            {
                txtDepartmentCode.Text = GetAutoNumber();
                //txtDepartmentCode.Text = ((DepartmentModel)CurrentNode).DepartmentCode;
                txtDepartmentName.Text = @"Phòng ban mới";
                if (CurrentNode != null)
                {
                    grdLockUpParentId.EditValue = ((DepartmentModel)CurrentNode).DepartmentId;
                }
            }
        }

        /// <summary>
        /// Focuses the control.
        /// </summary>
        protected override void InitControls()
        {
            grdLockUpParentId.Properties.Enabled = (ActionMode != ActionModeEnum.Edit) || !HasChildren;
        }

        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns></returns>
        protected override bool ValidData()
        {
            if (string.IsNullOrEmpty(DepartmentCode))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDepartmentCode"),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDepartmentCode.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(DepartmentName))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDepartmentName"),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDepartmentName.Focus();
                return false;
            }
            //if (ActionMode == ActionModeEnum.Edit)
            //{
            //    if (DepartmentName == grdLockUpParentId.Text)
            //    {
            //        XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDepartmentNameSameAsParentError"),
            //                        ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        grdLockUpParentId.Focus();
            //        return false;
            //    }
            //}
            return true;
        }

        /// <summary>
        /// Saves the data.
        /// </summary>
        /// <returns></returns>
        protected override int SaveData()
        {
            return _departmentPresenter.Save();
        }

        /// <summary>
        /// Handles the KeyDown event of the grdLockUpParentId control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void grdLockUpParentId_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdLockUpParentId.SelectionLength == grdLockUpParentId.Text.Length && (e.KeyData == Keys.Back || e.KeyData == Keys.Delete))
            {
                grdLockUpParentId.EditValue = null;
                e.Handled = true;
            }
        }
    }
}
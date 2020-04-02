/***********************************************************************
 * <copyright file="FrmXtraProjectDetail.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 27 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Presenter.Dictionary.Project;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.WindowsForm.CommonClass;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.Resources;
using TSD.Enum;
using DevExpress.XtraEditors;


namespace TSD.AccountingSoft.WindowsForm.FormDictionary
{
    public partial class FrmXtraProjectDetail : FrmXtraBaseTreeDetail, IProjectView, IProjectsView
    {
        private readonly ProjectPresenter _projectPresenter;
        private readonly ProjectsPresenter _projectsPresenter;

        public FrmXtraProjectDetail()
        {
            InitializeComponent();
            _projectPresenter = new ProjectPresenter(this);
            _projectsPresenter = new ProjectsPresenter(this);
        }

        #region Combobox

        public IList<ProjectModel> Projects
        {
            set
            {
                GridLookUpItem.Project(value ?? new List<ProjectModel>(), grdLockUpParentId, grdLockUpParentIdView, "ProjectName", KeyFieldName);
            }
        }

        #endregion

        #region Properties

        public int ProjectId { get; set; }

        public string ProjectCode
        {
            get { return txtProjectCode.Text; }
            set { txtProjectCode.Text = value; }
        }

        public string ProjectName
        {
            get { return txtProjectName.Text; }
            set { txtProjectName.Text = value; }
        }

        public string ForeignName
        {
            get { return txtForeignName.Text; }
            set { txtForeignName.Text = value; }
        }

        public int? ParentId
        {
            get
            {
                if (grdLockUpParentId.EditValue == null) return null;
                return (int?)grdLockUpParentId.EditValue;
            }
            set
            {
                grdLockUpParentId.EditValue = value;
            }
        }

        public bool IsParent { get; set; }

        public int Grade { get; set; }

        public bool IsSystem { get; set; }

        public bool IsActive
        {
            get { return chkIsActive.Checked; }
            set { chkIsActive.Checked = value; }
        }

        public string Description
        {
            get { return memoDescription.Text; }
            set { memoDescription.Text = value; }
        }

        #endregion

        #region Override Funtions

        protected override void InitData()
        {
            _projectsPresenter.Display();
            if (KeyValue != null) { _projectPresenter.Display(KeyValue); }
            else
            {
                txtProjectCode.Text = GetAutoNumber();
            }
        }

        protected override void InitControls()
        {
            grdLockUpParentId.Properties.Enabled = (ActionMode != ActionModeEnum.Edit) || !HasChildren;
        }

        protected override bool ValidData()
        {
            if (string.IsNullOrEmpty(ProjectCode))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResProjectCode"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProjectCode.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(ProjectName))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResProjectName"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProjectName.Focus();
                return false;
            }
            //if (ActionMode == ActionModeEnum.Edit)
            //{
            //    if (ProjectName == grdLockUpParentId.Text)
            //    {
            //        XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResProjectNameSameAsParentError"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        grdLockUpParentId.Focus();
            //        return false;
            //    }
            //}
            return true;
        }

        protected override int SaveData()
        {
            return _projectPresenter.Save();
        }

        #endregion

        #region Events

        private void grdLockUpParentId_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdLockUpParentId.SelectionLength == grdLockUpParentId.Text.Length && (e.KeyData == Keys.Back || e.KeyData == Keys.Delete))
            {
                grdLockUpParentId.EditValue = null;
                e.Handled = true;
            }
        }

        private void grdLockUpParentId_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)
            {
                using (var frmDetail = new FrmXtraProjectDetail())
                {
                    frmDetail.ActionMode = ActionModeEnum.AddNew;
                    if (frmDetail.ShowDialog() == DialogResult.OK)
                    {
                        _projectsPresenter.DisplayActive();
                        var lstDetails = grdLockUpParentId.Properties.DataSource as List<ProjectModel>;
                        if (lstDetails != null)
                        {
                            grdLockUpParentId.EditValue = lstDetails.OrderByDescending(o => o.ProjectId).FirstOrDefault().ProjectId;
                        }
                    }
                }
            }
        }

        #endregion
    }
}
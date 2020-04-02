using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Presenter.Dictionary.Activity;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.WindowsForm.CommonClass;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.Resources;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TSD.AccountingSoft.WindowsForm.FormDictionary
{
    public partial class FrmXtraActivityDetail : FrmXtraBaseCategoryDetail, IActivityView, IActivitysView
    {
        private readonly ActivitysPresenter _activitysPresenter;
        private readonly ActivityPresenter _activityPresenter;

        #region Properties

        public int ActivityId { get; set; }
        public string ActivityCode
        {
            get
            {
                return txtActivityCode.Text;
            }
            set
            {
                txtActivityCode.Text = value;
            }
        }
        public string ActivityName
        {
            get
            {
                return txtActivityName.Text;
            }
            set
            {
                txtActivityName.Text = value;
            }
        }
        public int? ParentID
        {
            get
            {
                return (int?)gridParentID.EditValue;
            }
            set
            {
                gridParentID.EditValue = value;
            }
        }
        public bool IsActive
        {
            get { return chkActive.Checked; }
            set { chkActive.Checked = value; }
        }
        public bool IsParent { get; set; }
        public bool IsSystem { get; set; }
        public int Grade { get; set; }
        public IList<ActivityModel> Activitys
        {
            set
            {
                if (value == null) value = new List<ActivityModel>();
                else if (KeyValue != null)
                    value = value.Where(w => w.ActivityId != Convert.ToInt32(KeyValue)).ToList();
                GridLookUpItem.Activity(value, gridParentID, gridParentIDView, "ActivityCode", "ActivityId");
            }
        }

        #endregion

        public FrmXtraActivityDetail()
        {
            InitializeComponent();

            _activitysPresenter = new ActivitysPresenter(this);
            _activityPresenter = new ActivityPresenter(this);
        }

        #region Overrides 

        protected override void InitData()
        {
            _activitysPresenter.DisplayActive(true);
            IsActive = true;

            if (KeyValue != null)
                _activityPresenter.Display(Convert.ToInt32(KeyValue));
        }

        protected override bool ValidData()
        {
            if (string.IsNullOrEmpty(ActivityCode))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResEmptyActivityCode"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtActivityCode.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(ActivityName))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResEmptyActivityName"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtActivityName.Focus();
                return false;
            }
            return true;
        }

        protected override int SaveData()
        {
            return _activityPresenter.Save();
        }

        /// <summary>
        /// Focuses the control.
        /// </summary>
        protected override void InitControls()
        {
            txtActivityCode.Focus();
        }

        #endregion
    }
}

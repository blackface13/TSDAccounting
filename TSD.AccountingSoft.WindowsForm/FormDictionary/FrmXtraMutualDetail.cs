using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TSD.AccountingSoft.Presenter.Dictionary.Mutual;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.WindowsForm.CommonClass;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.Resources;
using DevExpress.XtraEditors;

namespace TSD.AccountingSoft.WindowsForm.FormDictionary
{
    public partial class FrmXtraMutualDetail : FrmXtraBaseCategoryDetail, IMutualView
    {

        private readonly MutualPresenter _mutualPresenter;
        public FrmXtraMutualDetail()
        {
            InitializeComponent();
            _mutualPresenter = new MutualPresenter(this);
        }

        #region Function Overrides

        protected override void InitData()
        {
            Rates = new ObjectGeneral().GetMutualStates();
            if (KeyValue != null)
                _mutualPresenter.Display(KeyValue);
            else txtMutualCode.Text = GetAutoNumber();

        }

        protected override bool ValidData()
        {
            if (string.IsNullOrEmpty(MutualName))
            {
                XtraMessageBox.Show(@"Tên nhà hỗ tương bổ trống",
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMutualName.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(MutualCode))
            {
                XtraMessageBox.Show(@"Mã nhà hỗ tương không được để trống",
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMutualName.Focus();
                return false;
            }

            return true;
        }

        protected override int SaveData()
        {
            return _mutualPresenter.Save();
        }

        #endregion

        #region Properties
        public int MutualId
        {
            get;
            set;

        }

        public string MutualCode
        {
            get { return txtMutualCode.Text; }
            set { txtMutualCode.Text = value; }
        }

        public string MutualName
        {
            get { return txtMutualName.Text; }
            set { txtMutualName.Text = value; }
        }

        public string JobCandidate
        {
            get { return txtJobCandidate.Text; }
            set { txtJobCandidate.Text = value; }
        }

        public string Address
        {
            get { return txtAddress.Text; }
            set { txtAddress.Text = value; }
        }

        public decimal Area
        {
            get { return decimal.Parse(spinArea.EditValue.ToString()); }
            set { spinArea.EditValue = value; }
        }

        public int State
        {
            get { return Convert.ToInt32(cboState.EditValue); }
            set { cboState.EditValue = value; }
        }

        public int TotalFloor
        {
            get { return int.Parse(spinTotalFloor.EditValue.ToString()); }
            set { spinTotalFloor.EditValue = value; }
        }

        public DateTime UseDate
        {
            get { return (DateTime)dtUseDate.EditValue; }
            set { dtUseDate.EditValue = value; }
        }

        public string Description
        {
            get { return memoDescription.Text; }
            set { memoDescription.Text = value; }
        }

        public bool IsActive
        {
            get { return chkIsActive.Checked; }
            set { chkIsActive.Checked = value; }
        }
        #endregion

        #region Combobox

        public IList<ObjectGeneral> Rates
        {
            set
            {
                GridLookUpItem.ObjectGeneral(value, cboState, cboStateView);
            }
        }

        #endregion
    }
}

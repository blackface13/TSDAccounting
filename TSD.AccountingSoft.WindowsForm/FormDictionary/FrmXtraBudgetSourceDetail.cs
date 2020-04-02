/***********************************************************************
 * <copyright file="FrmXtraBudgetSourceDetail.cs" company="BUCA JSC">
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
using System.Linq;
using System.Windows.Forms;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Presenter.Dictionary.Account;
using TSD.AccountingSoft.Presenter.Dictionary.BudgetItem;
using TSD.AccountingSoft.Presenter.Dictionary.BudgetSource;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.WindowsForm.CommonClass;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.Resources;
using TSD.Enum;
using DevExpress.Utils;
using DevExpress.XtraEditors;


namespace TSD.AccountingSoft.WindowsForm.FormDictionary
{
    public partial class FrmXtraBudgetSourceDetail : FrmXtraBaseTreeDetail, IBudgetSourceView, IBudgetSourcesView, IAccountsView, IBudgetItemsView
    {
        private readonly BudgetSourcePresenter _budgetSourcePresenter;
        private readonly BudgetSourcesPresenter _budgetSourcesPresenter;
        private readonly AccountsPresenter _accountsPresenter;
        private readonly BudgetItemsPresenter _budgetItemsPresenter;

        public FrmXtraBudgetSourceDetail()
        {
            InitializeComponent();
            _budgetSourcePresenter = new BudgetSourcePresenter(this);
            _budgetSourcesPresenter = new BudgetSourcesPresenter(this);
            _accountsPresenter = new AccountsPresenter(this);
            _budgetItemsPresenter = new BudgetItemsPresenter(this);
        }

        #region IBudgetSourcesView Members

        public IList<BudgetSourceModel> BudgetSources
        {
            set
            {
                GridLookUpItem.BudgetSource(value, grdLockUpParentID, grdLockUpParentView, "BudgetSourceCode", KeyFieldName);
            }
        }

        public IList<AccountModel> Accounts
        {
            set
            {
                GridLookUpItem.Account(value, grdLockUpAccountID, grdLockUpAccountView, "AccountCode", "AccountCode");
            }
        }

        public IList<BudgetItemModel> BudgetItems
        {
            set
            {
                GridLookUpItem.BudgetItem(value == null ? new List<BudgetItemModel>() : value.Where(c => (c.IsReceipt)).ToList(), grdLockUpBudgetItemID, grdLockUpBudgetItemView, "BudgetItemCode", "BudgetItemCode");
            }
        }

        #endregion

        #region IBudgetSourceView Members

        public int BudgetSourceId { get; set; }

        public string BudgetSourceCode
        {
            get { return txtBudgetSourceCode.Text; }
            set { txtBudgetSourceCode.Text = value; }
        }

        public string BudgetSourceName
        {
            get { return txtBudgetSourceName.Text; }
            set { txtBudgetSourceName.Text = value; }
        }

        public int? ParentId
        {
            get
            {
                var parent = (BudgetSourceModel)grdLockUpParentID.GetSelectedDataRow();
                if (parent != null)
                    return parent.BudgetSourceId;
                else
                    return null;
            }
            set
            {
                grdLockUpParentID.EditValue = value;
            }
        }

        public string Description { get; set; }

        public int Type
        {
            get { return cboType.SelectedIndex; }
            set { cboType.SelectedIndex = value; }
        }

        public bool IsSystem { get; set; }

        public bool IsActive
        {
            get { return chkIsActive.Checked; }
            set { chkIsActive.Checked = value; }
        }

        public int Allocation
        {
            get { return cboAllocation.SelectedIndex; }
            set { cboAllocation.SelectedIndex = value; }
        }

        public string BudgetItemCode
        {
            get
            {
                var budgetItemCode = (BudgetItemModel)grdLockUpBudgetItemID.GetSelectedDataRow();
                if (budgetItemCode != null)
                    return budgetItemCode.BudgetItemCode;
                else
                    return "";
            }
            set
            {
                grdLockUpBudgetItemID.EditValue = value;
            }
        }

        public bool IsFund
        {

            get { return (bool)rndIsFund.EditValue; }
            set { rndIsFund.EditValue = value; }
        }

        public bool IsExpense
        {
            get { return chkIsExpense.Checked; }
            set { chkIsExpense.Checked = value; }
        }

        public string AccountCode
        {
            get
            {
                var accountCode = (AccountModel)grdLockUpAccountID.GetSelectedDataRow();
                if (accountCode != null)
                    return accountCode.AccountCode;
                else
                    return "";
            }
            set
            {
                grdLockUpAccountID.EditValue = value;
            }
        }

        public int Grade { get; set; }

        public bool IsParent { get; set; }

        public string ForeignName { get; set; }

        public short? AutonomyBudgetType
        {
            get { return (short?)cboAutonomyBudgetType.SelectedIndex; }
            set
            {
                cboAutonomyBudgetType.SelectedIndex = value == null ? -1 : int.Parse(value.ToString());
            }
        }

        public int BudgetCode
        {
            get  { return cbbBudgetCode.SelectedIndex; }
            set  { cbbBudgetCode.SelectedIndex = value; }
        }

        #endregion

        protected override void InitData()
        {
            _accountsPresenter.DisplayActive();
            _budgetItemsPresenter.DisplayActive();
            _budgetSourcesPresenter.Display();

            if (KeyValue == null) return;
            _budgetSourcePresenter.Display(KeyValue);
        }

        protected override void InitControls()
        {
            txtBudgetSourceCode.Focus();
            grdLockUpParentID.Properties.ReadOnly = (ActionMode == ActionModeEnum.Edit) && HasChildren;
        }

        protected override bool ValidData()
        {
            if (string.IsNullOrEmpty(BudgetSourceCode))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResBudgetSourceCode"),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBudgetSourceCode.Focus();
                return false;
            }
            var listBudgetSource = _budgetSourcesPresenter.GetBudgetSources();
            foreach (var budgetSourceModel in listBudgetSource)
            {
                // option Edit
                if (BudgetSourceId > 0)
                {
                    if (budgetSourceModel.BudgetSourceId == BudgetSourceId) continue;
                    if (budgetSourceModel.BudgetSourceCode != BudgetSourceCode) continue;
                    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResCheckBudgetSourcesCode"),
                                        ResourceHelper.GetResourceValueByName("ResDetailContent"),
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtBudgetSourceCode.Focus();
                    return false;
                }
                if (budgetSourceModel.BudgetSourceCode != BudgetSourceCode) continue;
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResCheckBudgetSourcesCode"),
                                    ResourceHelper.GetResourceValueByName("ResDetailContent"),
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBudgetSourceCode.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(BudgetSourceName))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResBudgetSourceName"),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBudgetSourceName.Focus();
                return false;
            }
            if (BudgetSourceCode == grdLockUpParentID.Text)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResCodeSameAsParentError"),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                grdLockUpParentID.Focus();
                return false;
            }
            return true;
        }

        protected override int SaveData()
        {
            return _budgetSourcePresenter.Save();
        }

        private void grdLockUpParentID_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdLockUpParentID.SelectionLength != grdLockUpParentID.Text.Length ||
                (e.KeyData != Keys.Back && e.KeyData != Keys.Delete)) return;
            grdLockUpParentID.EditValue = null;
            e.Handled = true;
        }

        private void FrmXtraBudgetSourceDetail_Load(object sender, System.EventArgs e)
        {
            if (rndIsFund.SelectedIndex == 0)
            {
                grdLockUpAccountID.Enabled = false;
                grdLockUpAccountID.EditValue = null;
            }
            else
            {
                grdLockUpAccountID.Enabled = true;
                AccountCode = "3378";
            }

        }

        private void grdLockUpBudgetItemID_EditValueChanged(object sender, System.EventArgs e)
        {
            cboAllocation.EditValue = null;
        }

        private void grdLockUpBudgetItemID_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdLockUpBudgetItemID.SelectionLength == grdLockUpBudgetItemID.Text.Length && (e.KeyData == Keys.Back || e.KeyData == Keys.Delete))
            {
                grdLockUpBudgetItemID.EditValue = null;
                e.Handled = true;
            }
        }

        private void grdLockUpAccountID_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdLockUpAccountID.SelectionLength == grdLockUpAccountID.Text.Length && (e.KeyData == Keys.Back || e.KeyData == Keys.Delete))
            {
                grdLockUpAccountID.EditValue = null;
                e.Handled = true;
            }
        }

        private void grdLockUpBudgetItemID_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)
            {
                using (var frmBudgetItem = new FrmxtraBudgetItemDetail())
                {
                    frmBudgetItem.ActionMode = ActionModeEnum.AddNew;

                    if (frmBudgetItem.ShowDialog() == DialogResult.OK)
                    {
                        if (frmBudgetItem.DialogResult == DialogResult.OK)
                        {
                            _budgetItemsPresenter.DisplayActive();

                            var lstBudgetItem = (List<BudgetItemModel>)grdLockUpBudgetItemID.Properties.DataSource;
                            if (lstBudgetItem != null && lstBudgetItem.Count > 0)
                                BudgetItemCode = lstBudgetItem.OrderByDescending(o => o.BudgetItemId).FirstOrDefault().BudgetItemCode;
                        }
                    }
                }
            }
        }

        private void grdLockUpAccountID_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)
            {
                using (var frmAccount = new FrmXtraAccountDetail())
                {
                    frmAccount.ActionMode = ActionModeEnum.AddNew;

                    if (frmAccount.ShowDialog() == DialogResult.OK)
                    {
                        if (frmAccount.DialogResult == DialogResult.OK)
                        {
                            _accountsPresenter.DisplayActive();

                            var lstAccount = (List<AccountModel>)grdLockUpAccountID.Properties.DataSource;
                            if (lstAccount != null && lstAccount.Count > 0)
                                AccountCode = lstAccount.OrderByDescending(o => o.AccountId).FirstOrDefault().AccountCode;
                        }
                    }
                }
            }
        }

        private void rndIsFund_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (rndIsFund.SelectedIndex == 0)
            {
                grdLockUpAccountID.Enabled = false;
                grdLockUpAccountID.EditValue = null;
            }
            else
            {
                grdLockUpAccountID.Enabled = true;
                AccountCode = "3378";
            }
        }
    }
}

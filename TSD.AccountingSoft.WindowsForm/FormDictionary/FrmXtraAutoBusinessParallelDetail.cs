using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Presenter.Dictionary.Account;
using TSD.AccountingSoft.Presenter.Dictionary.AutoBusinessParallel;
using TSD.AccountingSoft.Presenter.Dictionary.BudgetItem;
using TSD.AccountingSoft.Presenter.Dictionary.BudgetSource;
using TSD.AccountingSoft.Presenter.Dictionary.VoucherType;
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
    public partial class FrmXtraAutoBusinessParallelDetail : FrmXtraBaseCategoryDetail, IAutoBusinessParallelView, IAccountsView, IBudgetSourcesView, IBudgetItemsView, IVoucherTypesView
    {
        #region Declare parameter
        private readonly AutoBusinessParallelPresenter _autoBusinessParallelPresenter;
        private readonly AccountsPresenter _accountsPresenter;
        private readonly BudgetSourcesPresenter _budgetSourcesPresenter;
        private readonly BudgetItemsPresenter _budgetItemsPresenter;
        private readonly VoucherTypesPresenter _voucherTypesPresenter;
        #endregion

        public FrmXtraAutoBusinessParallelDetail()
        {
            InitializeComponent();
            _autoBusinessParallelPresenter = new AutoBusinessParallelPresenter(this);
            _accountsPresenter = new AccountsPresenter(this);
            _budgetSourcesPresenter = new BudgetSourcesPresenter(this);
            _budgetItemsPresenter = new BudgetItemsPresenter(this);
            _voucherTypesPresenter = new VoucherTypesPresenter(this);
        }

        #region Properties

        public int AutoBusinessParallelId { get; set; }
        public string AutoBusinessCode
        {
            get { return txtAutoBusinessCode.Text.Trim(); }
            set { txtAutoBusinessCode.Text = value; }
        }
        public string AutoBusinessName
        {
            get { return txtAutoBusinessName.Text.Trim(); }
            set { txtAutoBusinessName.Text = value; }
        }
        public string Description
        {
            get { return memoDescription.Text.Trim(); }
            set { memoDescription.Text = value; }
        }
        public bool IsActive
        {
            get { return chkIsActive.Checked; }
            set { chkIsActive.Checked = value; }
        }
        public string DebitAccount
        {
            get { return string.IsNullOrEmpty(grdLookUpEditDebitAccount.Text) ? null : (string)grdLookUpEditDebitAccount.EditValue; ; }
            set { grdLookUpEditDebitAccount.EditValue = value; }
        }
        public string CreditAccount
        {
            get { return string.IsNullOrEmpty(grdLookUpEditCreditAccount.Text) ? null : (string)grdLookUpEditCreditAccount.EditValue; }
            set { grdLookUpEditCreditAccount.EditValue = value; }
        }
        public int BudgetSourceId
        {
            get { return grdLookUpEditBudgetSource.EditValue == null ? 0 : (int)grdLookUpEditBudgetSource.EditValue; }
            set { grdLookUpEditBudgetSource.EditValue = value; }
        }
        public int BudgetItemId
        {
            get { return grdLookUpEditBudgetItem.EditValue == null ? 0 : (int)grdLookUpEditBudgetItem.EditValue; }
            set { grdLookUpEditBudgetItem.EditValue = value; }
        }
        public int BudgetSubItemId
        {
            get { return grdLookUpEditBudgetSubItem.EditValue == null ? 0 : (int)grdLookUpEditBudgetSubItem.EditValue; }
            set { grdLookUpEditBudgetSubItem.EditValue = value; }
        }
        public int VoucherTypeId
        {
            get { return grdLookUpEditVoucherType.EditValue == null ? 0 : (int)grdLookUpEditVoucherType.EditValue; }
            set { grdLookUpEditVoucherType.EditValue = value; }
        }
        public string DebitAccountParallel
        {
            get { return string.IsNullOrEmpty(grdLookUpEditDebitAccountParallel.Text) ? null : (string)grdLookUpEditDebitAccountParallel.EditValue; }
            set { grdLookUpEditDebitAccountParallel.EditValue = value; }
        }
        public string CreditAccountParallel
        {
            get { return string.IsNullOrEmpty(grdLookUpEditCreditAccountParallel.Text) ? null : (string)grdLookUpEditCreditAccountParallel.EditValue; }
            set { grdLookUpEditCreditAccountParallel.EditValue = value; }
        }
        public int BudgetSourceIdParallel
        {
            get { return grdLookUpEditBudgetSourceParallel.EditValue == null ? 0 : (int)grdLookUpEditBudgetSourceParallel.EditValue; }
            set { grdLookUpEditBudgetSourceParallel.EditValue = value; }
        }
        public int BudgetItemIdParallel
        {
            get { return grdLookUpEditBudgetItemParallrel.EditValue == null ? 0 : (int)grdLookUpEditBudgetItemParallrel.EditValue; }
            set { grdLookUpEditBudgetItemParallrel.EditValue = value; }
        }
        public int BudgetSubItemIdParallel
        {
            get { return grdLookUpEditBudgetSubItemParallrel.EditValue == null ? 0 : (int)grdLookUpEditBudgetSubItemParallrel.EditValue; }
            set { grdLookUpEditBudgetSubItemParallrel.EditValue = value; }
        }
        public int VoucherTypeIdParallel
        {
            get { return grdLookUpEditVoucherTypeParallrel.EditValue == null ? 0 : (int)grdLookUpEditVoucherTypeParallrel.EditValue; }
            set { grdLookUpEditVoucherTypeParallrel.EditValue = value; }
        }

        public int SortOrder { get; set; }

        public bool IsNegative { get { return checkNegative.Checked; } set { checkNegative.Checked = value; } }

        #endregion

        #region Combobox

        /// <summary>
        /// Tài khoản
        /// </summary>
        public IList<AccountModel> Accounts
        {
            set
            {
                GridLookUpItem.Account(value == null ? new List<AccountModel>() : value.Where(v => !v.AccountCode.StartsWith("0")).ToList(), grdLookUpEditDebitAccount, grdLookUpEditDebitAccountView, "AccountCode", "AccountCode");
                GridLookUpItem.Account(value == null ? new List<AccountModel>() : value.Where(v => !v.AccountCode.StartsWith("0")).ToList(), grdLookUpEditCreditAccount, grdLookUpEditCreditAccountView, "AccountCode", "AccountCode");
                GridLookUpItem.Account(value == null ? new List<AccountModel>() : value, grdLookUpEditDebitAccountParallel, grdLookUpEditDebitAccountParallelView, "AccountCode", "AccountCode");
                GridLookUpItem.Account(value == null ? new List<AccountModel>() : value, grdLookUpEditCreditAccountParallel, grdLookUpEditCreditAccountParallelView, "AccountCode", "AccountCode");
            }
        }

        /// <summary>
        /// Nguồn vốn
        /// </summary>
        public IList<BudgetSourceModel> BudgetSources
        {
            set
            {
                if (value == null)
                    value = new List<BudgetSourceModel>();
                else
                    value = value.Where(w => w.IsParent == false).ToList();
                GridLookUpItem.BudgetSource(value == null ? new List<BudgetSourceModel>() : value, grdLookUpEditBudgetSource, grdLookUpEditBudgetSourceView, "BudgetSourceCode", "BudgetSourceId");
                GridLookUpItem.BudgetSource(value == null ? new List<BudgetSourceModel>() : value, grdLookUpEditBudgetSourceParallel, grdLookUpEditBudgetSourceParallelView, "BudgetSourceCode", "BudgetSourceId");
            }
        }

        /// <summary>
        /// Mục - tiểu mục
        /// </summary>
        public IList<BudgetItemModel> BudgetItems
        {
            set
            {
                var budgetItem = value.Where(c => c.IsActive && (c.BudgetItemType == 4 || (c.BudgetItemType == 3 && c.IsShowOnVoucher))).ToList();
                if (budgetItem == null) 
                    budgetItem = new List<BudgetItemModel>();

                GridLookUpItem.BudgetItem(value == null ? new List<BudgetItemModel>() : budgetItem, grdLookUpEditBudgetItem, grdLookUpEditBudgetItemView, "BudgetItemCode", "BudgetItemId");
                GridLookUpItem.BudgetItem(value == null ? new List<BudgetItemModel>() : budgetItem, grdLookUpEditBudgetItemParallrel, grdLookUpEditBudgetItemParallrelView, "BudgetItemCode", "BudgetItemId");
            }
        }

        /// <summary>
        /// Nghiệp vụ
        /// </summary>
        public IList<VoucherTypeModel> VoucherTypes
        {
            set
            {
                GridLookUpItem.VoucherType(value == null ? new List<VoucherTypeModel>() : value, grdLookUpEditVoucherType, grdLookUpEditVoucherTypeView, "VoucherTypeName", "VoucherTypeId");
                GridLookUpItem.VoucherType(value == null ? new List<VoucherTypeModel>() : value, grdLookUpEditVoucherTypeParallrel, grdLookUpEditVoucherTypeParallrelView, "VoucherTypeName", "VoucherTypeId");
            }
        }

        #endregion

        #region Overrides 

        protected override void InitData()
        {
            _accountsPresenter.DisplayActive();
            _budgetSourcesPresenter.DisplayActive();
            _budgetItemsPresenter.DisplayActive();
            _voucherTypesPresenter.DisplayActive();

            if (KeyValue != null)
                _autoBusinessParallelPresenter.Display(Convert.ToInt32(KeyValue));
        }

        protected override bool ValidData()
        {
            if (string.IsNullOrEmpty(AutoBusinessCode))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResEmptyAutoBusinessParallelCode"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAutoBusinessCode.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(AutoBusinessName))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResEmptyAutoBusinessParallelName"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAutoBusinessName.Focus();
                return false;
            }
            return true;
        }

        protected override int SaveData()
        {
            return _autoBusinessParallelPresenter.Save();
        }

        protected override void InitControls()
        {
            txtAutoBusinessCode.Focus();
        }

        #endregion

        #region Events

        private void grdLookUpEditBudgetSubItem_EditValueChanged(object sender, System.EventArgs e)
        {
            //var row = (BudgetItemModel)grdLookUpEditBudgetSubItem.GetSelectedDataRow();
            //if (row == null) return;
            //{
            //    var lstBudgetItems = grdLookUpEditBudgetItem.Properties.DataSource as List<BudgetItemModel>;
            //    if (lstBudgetItems == null) return;
            //    BudgetItemModel budgetItem = lstBudgetItems.Where(w => w.BudgetItemId == row.ParentId)?.First() ?? null;
            //    if (budgetItem != null)
            //    {
            //        grdLookUpEditBudgetItem.EditValue = budgetItem.BudgetItemId;
            //    }
            //    else
            //        grdLookUpEditBudgetItem.EditValue = null;
            //}
        }

        private void grdLookUpEditBudgetSubItemParallrel_EditValueChanged(object sender, System.EventArgs e)
        {
            //var row = (BudgetItemModel)grdLookUpEditBudgetSubItemParallrel.GetSelectedDataRow();
            //if (row == null) return;
            //{
            //    var lstBudgetItems = grdLookUpEditBudgetItemParallrel.Properties.DataSource as List<BudgetItemModel>;
            //    if (lstBudgetItems == null) return;
            //    BudgetItemModel budgetItem = lstBudgetItems.Where(w => w.BudgetItemId == row.ParentId)?.First() ?? null;
            //    if (budgetItem != null)
            //    {
            //        grdLookUpEditBudgetItemParallrel.EditValue = budgetItem.BudgetItemId;
            //    }
            //    else
            //        grdLookUpEditBudgetItemParallrel.EditValue = null;
            //}
        }

        private void grdLookUpEditDebitAccount_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index.Equals(1))
            {
                var frmDetail = new FrmXtraAccountDetail();
                frmDetail.ActionMode = TSD.Enum.ActionModeEnum.AddNew;
                if (frmDetail.ShowDialog() == DialogResult.OK)
                {
                    _accountsPresenter.DisplayActive();

                    var lstAccounts = grdLookUpEditDebitAccount.Properties.DataSource as List<AccountModel>;
                    if (lstAccounts != null)
                    {
                        grdLookUpEditDebitAccount.EditValue = lstAccounts.OrderByDescending(o => o.AccountId).First().AccountCode;
                    }
                }
            }
        }

        private void grdLookUpEditCreditAccount_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index.Equals(1))
            {
                var frmDetail = new FrmXtraAccountDetail();
                frmDetail.ActionMode = TSD.Enum.ActionModeEnum.AddNew;
                if (frmDetail.ShowDialog() == DialogResult.OK)
                {
                    _accountsPresenter.DisplayActive();

                    var lstAccounts = grdLookUpEditCreditAccount.Properties.DataSource as List<AccountModel>;
                    if (lstAccounts != null)
                    {
                        grdLookUpEditCreditAccount.EditValue = lstAccounts.OrderByDescending(o => o.AccountId).First().AccountCode;
                    }
                }
            }
        }

        private void grdLookUpEditBudgetSource_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index.Equals(1))
            {
                using (var frmDetail = new FrmXtraBudgetSourceDetail())
                {
                    frmDetail.ActionMode = TSD.Enum.ActionModeEnum.AddNew;
                    if (frmDetail.ShowDialog() == DialogResult.OK)
                    {
                        _accountsPresenter.DisplayActive();

                        var lstAccounts = grdLookUpEditBudgetSource.Properties.DataSource as List<BudgetSourceModel>;
                        if (lstAccounts != null)
                        {
                            grdLookUpEditBudgetSource.EditValue = lstAccounts.OrderByDescending(o => o.BudgetSourceId).First().BudgetSourceId;
                        }
                    }
                }
            }
        }

        private void grdLookUpEditBudgetSubItem_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index.Equals(1))
            {
                var frmDetail = new FrmxtraBudgetItemDetail();
                frmDetail.ActionMode = TSD.Enum.ActionModeEnum.AddNew;
                if (frmDetail.ShowDialog() == DialogResult.OK)
                {
                    _accountsPresenter.DisplayActive();

                    var lstAccounts = grdLookUpEditBudgetSubItem.Properties.DataSource as List<BudgetItemModel>;
                    if (lstAccounts != null)
                    {
                        grdLookUpEditBudgetSubItem.EditValue = lstAccounts.OrderByDescending(o => o.BudgetItemId).First().BudgetItemId;
                    }
                }
            }
        }

        private void grdLookUpEditBudgetItem_EditValueChanged(object sender, EventArgs e)
        {
            //_budgetItemsPresenter.DisplayActive();
        }

        private void grdLookUpEditBudgetItemParallrel_EditValueChanged(object sender, EventArgs e)
        {
            //_budgetItemsPresenter.DisplayActive();
        }

        private void grdLookUpEditDebitAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdLookUpEditDebitAccount.SelectionLength == grdLookUpEditDebitAccount.Text.Length && (e.KeyData == Keys.Back || e.KeyData == Keys.Delete))
            {
                DebitAccount = null;
                //grdLookUpEditDebitAccount.EditValue = null;
                e.Handled = true;
            }
        }

        #endregion
    }
}

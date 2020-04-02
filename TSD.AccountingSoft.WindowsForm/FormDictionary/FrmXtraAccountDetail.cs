/***********************************************************************
 * <copyright file="FrmXtraAccountDetail.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   BangNC
 * Email:    BangNC@buca.vn
 * Website:
 * Create Date: Friday, March 14, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using System.Windows.Forms;
using TSD.AccountingSoft.Session;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Presenter.Dictionary.Account;
using TSD.AccountingSoft.Presenter.Dictionary.AccountCategory;
using TSD.AccountingSoft.Presenter.Dictionary.Bank;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.Resources;
using TSD.Enum;
using DevExpress.XtraEditors;
using TSD.AccountingSoft.WindowsForm.CommonClass;
using System.Linq;

namespace TSD.AccountingSoft.WindowsForm.FormDictionary
{
    public partial class FrmXtraAccountDetail : FrmXtraBaseTreeDetail, IAccountView, IAccountsView, IAccountCategoriesView, IBanksView
    {
        private readonly AccountPresenter _accountPresenter;
        private readonly AccountsPresenter _accountsPresenter;
        private readonly AccountCategoriesPresenter _accountCategoriesPresenter;
        private readonly BanksPresenter _banksPresenter;
        private readonly GlobalVariable _globalVariable;
        private readonly GlobalVariable _dbOptionHelper;
        protected new string CurrencyAccounting;
        protected new string CurrencyLocal;

        public FrmXtraAccountDetail()
        {
            InitializeComponent();
            cboCurrencyCode.Visible = false;
            _accountPresenter = new AccountPresenter(this);
            _accountsPresenter = new AccountsPresenter(this);
            _accountCategoriesPresenter = new AccountCategoriesPresenter(this);
            _banksPresenter = new BanksPresenter(this);
            _globalVariable = new GlobalVariable();
            _dbOptionHelper = new GlobalVariable();
            CurrencyAccounting = _dbOptionHelper.CurrencyAccounting;
            CurrencyLocal = _dbOptionHelper.CurrencyLocal;
        }

        #region Combobox

        public IList<AccountModel> Accounts
        {
            set
            {
                GridLookUpItem.Account(value ?? new List<AccountModel>(), grdLockUpParentID, grdLockUpParentIDView, "AccountCode", KeyFieldName);
            }
        }

        public IList<AccountCategoryModel> AccountCategories
        {
            set
            {
                GridLookUpItem.AccountCategory(value ?? new List<AccountCategoryModel>(), grdLockUpCategoryID, grdLockUpCategoryIDView, "AccountCategoryCode", "AccountCategoryId");
            }
        }

        public IList<BankModel> Banks
        {
            set
            {
                GridLookUpItem.Bank(value, grdLockUpBankID, grdLockUpBankIDView, "BankAccount", "BankId");
            }
        }

        #endregion

        #region Override functions

        protected override void InitData()
        {
            if (KeyValue != null)
            {
                _accountPresenter.Display(KeyValue);
                _accountsPresenter.DisplayForComboTree(int.Parse(KeyValue));
                _accountCategoriesPresenter.DisplayActive();
                _banksPresenter.DisplayActive();
                if (AccountCode == "11122" || AccountCode == "11222")
                {
                    cboCurrencyCode.Properties.Items.Add(_globalVariable.CurrencyLocal);
                }
                else
                {
                    if (AccountCode == "11121" || AccountCode == "11221")
                    {
                        cboCurrencyCode.Properties.Items.Add(_globalVariable.CurrencyAccounting);
                    }
                    else
                    {
                        cboCurrencyCode.Properties.Items.Add(_globalVariable.CurrencyLocal);
                        if (_globalVariable.CurrencyLocal != _globalVariable.CurrencyAccounting)
                            cboCurrencyCode.Properties.Items.Add(_globalVariable.CurrencyAccounting);
                    }
                }
            }
            else
            {
                _accountsPresenter.DisplayActive();
                _accountCategoriesPresenter.DisplayActive();
                _banksPresenter.DisplayActive();
                chkIsActive.Checked = true;
                cboCurrencyCode.Properties.Items.Add(_globalVariable.CurrencyLocal);
                if (_globalVariable.CurrencyLocal != _globalVariable.CurrencyAccounting)
                    cboCurrencyCode.Properties.Items.Add(_globalVariable.CurrencyAccounting);
                cboCurrencyCode.Visible = false;

            }
            cboCurrencyCode.Visible = chkIsCurrency.Checked;
        }

        protected override void InitControls()
        {
            txtAccountCode.Focus();
            grdLockUpParentID.Properties.Enabled = (ActionMode != ActionModeEnum.Edit) || !HasChildren;
        }

        protected override bool ValidData()
        {
            if (string.IsNullOrEmpty(AccountCode))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResAccountCode"),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAccountCode.Focus();
                return false;
            }
            var listAccount = _accountsPresenter.GetAccountsActive();
            foreach (var accountModel in listAccount)
            {
                // option Edit
                if (AccountId > 0)
                {
                    if (accountModel.AccountId != AccountId)
                    {
                        if (accountModel.AccountCode == AccountCode)
                        {
                            XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResCheckAccountsCode"),
                                                ResourceHelper.GetResourceValueByName("ResDetailContent"),
                                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtAccountCode.Focus();
                            return false;
                        }
                    }
                }
                // option Add New
                else
                {
                    if (accountModel.AccountCode == AccountCode)
                    {
                        XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResCheckAccountsCode"),
                                            ResourceHelper.GetResourceValueByName("ResDetailContent"),
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtAccountCode.Focus();
                        return false;
                    }
                }

            }
            // Kiểm tra khi có tài khoản tiết con thì mã của Cha chứa mã con
            if (!AccountCode.Contains(grdLockUpParentID.Text))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResContainCodesParentError"),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAccountCode.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(AccountName))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResAccountName"),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAccountName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(grdLockUpCategoryID.Text))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResAccountCategory"),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                grdLockUpCategoryID.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(cboBalance.Text))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResBalanceSide"),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboBalance.Focus();
                return false;
            }
            if (AccountCode == grdLockUpParentID.Text)
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
            return _accountPresenter.Save();
        }

        #endregion

        #region Properties

        public int AccountId { get; set; }
        public int? AccountCategoryId
        {
            get
            {
                var accountCategory = (AccountCategoryModel)grdLockUpCategoryID.GetSelectedDataRow();
                if (accountCategory != null)
                    return accountCategory.AccountCategoryId;
                else
                    return null;
            }
            set
            {
                grdLockUpCategoryID.EditValue = value;
            }
        }
        public string AccountCode
        {
            get { return txtAccountCode.Text; }
            set { txtAccountCode.Text = value; }
        }
        public string CurrencyCode
        {
            get
            {
                if (cboCurrencyCode.EditValue == null) return null;
                return (string)cboCurrencyCode.EditValue;
            }
            set
            {
                cboCurrencyCode.EditValue = value;
            }
        }
        public string AccountName
        {
            get { return txtAccountName.Text; }
            set { txtAccountName.Text = value; }
        }
        public int? ParentId
        {
            get
            {
                var account = (AccountModel)grdLockUpParentID.GetSelectedDataRow();
                if (account != null)
                    return account.AccountId;
                else
                    return null;
            }
            set
            {
                grdLockUpParentID.EditValue = value;
            }
        }
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
        public string ForeignName
        {
            get;
            set;
        }
        public int Grade
        {
            get;
            set;
        }
        public bool IsDetail
        {
            get;
            set;
        }
        public int BalanceSide
        {
            get { return cboBalance.SelectedIndex; }
            set { cboBalance.SelectedIndex = value; }
        }
        public string ConcomitantAccount
        {
            get;
            set;
        }
        public int? BankId
        {
            get
            {
                var bank = (BankModel)grdLockUpBankID.GetSelectedDataRow();
                if (bank != null)
                    return bank.BankId;
                else
                    return null;
            }
            set
            {
                grdLockUpBankID.EditValue = value;
            }
        }
        public bool IsChapter
        {
            get { return chkIsChapter.Checked; }
            set { chkIsChapter.Checked = value; }
        }
        public bool IsBudgetCategory
        {
            get { return chkIsBudgetCategory.Checked; }
            set { chkIsBudgetCategory.Checked = value; }
        }
        public bool IsBudgetItem
        {
            get { return chkIsBudgetItem.Checked; }
            set { chkIsBudgetItem.Checked = value; }
        }
        public bool IsBudgetGroup
        {
            get { return chkIsBudgetGroup.Checked; }
            set { chkIsBudgetGroup.Checked = value; }
        }
        public bool IsBudgetSource
        {
            get { return chkIsBudgetSource.Checked; }
            set { chkIsBudgetSource.Checked = value; }
        }
        public bool IsActivity
        {
            get;
            set;
        }
        public bool IsCurrency
        {
            get
            {
                return chkIsCurrency.Checked;
            }
            set
            {
                cboCurrencyCode.Visible = value;
                chkIsCurrency.Checked = value;
            }
        }
        public bool IsCustomer
        {
            get { return chkIsCustomer.Checked; }
            set { chkIsCustomer.Checked = value; }
        }
        public bool IsVendor
        {
            get { return chkIsVendor.Checked; }
            set { chkIsVendor.Checked = value; }
        }
        public bool IsProject
        {
            get { return chkIsProject.Checked; }
            set { chkIsProject.Checked = value; }
        }
        public bool IsEmployee
        {
            get { return chkIsEmployee.Checked; }
            set { chkIsEmployee.Checked = value; }
        }
        public bool IsAccountingObject
        {
            get { return chkIsAccountingObject.Checked; }
            set { chkIsAccountingObject.Checked = value; }
        }
        public bool IsInventoryItem
        {
            get { return chkIsInventoryItem.Checked; }
            set { chkIsInventoryItem.Checked = value; }
        }
        public bool IsFixedAsset
        {
            get { return chkIsFixedasset.Checked; }
            set { chkIsFixedasset.Checked = value; }
        }
        public bool IsBank { get { return chkIsBank.Checked; } set { chkIsBank.Checked = value; } }
        public bool IsBudgetSubItem { get { return chkIsBudgetSubItem.Checked; } set { chkIsBudgetSubItem.Checked = value; } }
        public bool IsCapitalAllocate
        {
            get { return chkIsCapitalAllocate.Checked; }
            set { chkIsCapitalAllocate.Checked = value; }
        }
        public bool IsAllowinputcts
        {
            get { return chkIsAllowinputcts.Checked; }
            set { chkIsAllowinputcts.Checked = value; }
        }

        #endregion

        #region Events

        private void cboBalance_SelectedIndexChanged(object sender, System.EventArgs e)
        {
        }

        private void grdLockUpParentID_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdLockUpParentID.SelectionLength == grdLockUpParentID.Text.Length && (e.KeyData == Keys.Back || e.KeyData == Keys.Delete))
            {
                grdLockUpParentID.EditValue = null;
                e.Handled = true;
            }
        }

        private void grdLockUpCategoryID_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdLockUpCategoryID.SelectionLength == grdLockUpCategoryID.Text.Length && (e.KeyData == Keys.Back || e.KeyData == Keys.Delete))
            {
                grdLockUpCategoryID.EditValue = null;
                e.Handled = true;
            }
        }

        private void grdLockUpBankID_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdLockUpBankID.SelectionLength == grdLockUpBankID.Text.Length && (e.KeyData == Keys.Back || e.KeyData == Keys.Delete))
            {
                grdLockUpBankID.EditValue = null;
                e.Handled = true;
            }
        }

        private void FrmXtraAccountDetail_Load(object sender, System.EventArgs e)
        {

        }

        private void chkIsCurrency_CheckedChanged(object sender, System.EventArgs e)
        {
            cboCurrencyCode.Visible = chkIsCurrency.Checked;
        }

        private void grdLockUpBankID_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)
            {
                using (var frmBank = new FrmXtraBankDetail())
                {
                    frmBank.ActionMode = ActionModeEnum.AddNew;

                    if (frmBank.ShowDialog() == DialogResult.OK)
                    {
                        if (frmBank.DialogResult == DialogResult.OK)
                        {
                            _banksPresenter.Display();

                            var lstBank = (List<BankModel>)grdLockUpBankID.Properties.DataSource;
                            if (lstBank != null && lstBank.Count > 0)
                                BankId = lstBank.Max(m => m.BankId);
                        }
                    }
                }
            }
        }

        #endregion
    }
}

/***********************************************************************
 * <copyright file="FrmXtraPayItemDetail.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 10 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TSD.Enum;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Presenter.Dictionary.BudgetItem;
using TSD.AccountingSoft.Presenter.Dictionary.BudgetSource;
using TSD.AccountingSoft.Presenter.Dictionary.PayItem;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.Resources;
using DevExpress.XtraEditors;
using TSD.AccountingSoft.Presenter.Dictionary.Account;
using TSD.AccountingSoft.Session;
using TSD.AccountingSoft.WindowsForm.CommonClass;
using System;

namespace TSD.AccountingSoft.WindowsForm.FormDictionary
{
    /// <summary>
    /// class FrmXtraPayItemDetail
    /// </summary>
    public partial class FrmXtraPayItemDetail : FrmXtraBaseCategoryDetail, IPayItemView, IAccountsView, IBudgetItemsView, IBudgetSourcesView
    {
        private readonly PayItemPresenter _payItemPresenter;
        private readonly AccountsPresenter _accountsPresenter;
        private readonly BudgetItemsPresenter _budgetItemsPresenter;
        private readonly BudgetSourcesPresenter _budgetSourcesPresenter;
        private GlobalVariable _globalVariable;

        #region Properties

        public int PayItemId { get; set; }
        public string PayItemCode
        {
            get
            {
                return lookUpPayItemCode.EditValue == null ? null : lookUpPayItemCode.EditValue.ToString();
            }
            set
            {
                lookUpPayItemCode.EditValue = value;
            }
        }
        public string PayItemName
        {
            get { return txtPayItemName.Text; }
            set { txtPayItemName.Text = value; }
        }
        public int Type
        {
            get { return Convert.ToInt32(cboType.EditValue); }
            set { cboType.EditValue = value; }
        }
        public bool IsCalculateRatio
        {
            get { return chkIsCalculateRatio.Checked; }
            set { chkIsCalculateRatio.Checked = value; }
        }
        public bool? IsSocialInsurance
        {
            get { return Type == 2 ? chkIsSocialInsurance.Checked : (bool?)null; }
            set
            {
                if (value == null) return;
                chkIsSocialInsurance.Checked = (bool)value;
            }
        }
        public bool? IsCareInsurance
        {
            get { return Type == 2 ? chkIsCareInsurance.Checked : (bool?)null; }
            set
            {
                if (value == null) return;
                chkIsCareInsurance.Checked = (bool)value;
            }
        }
        public bool? IsTradeUnionFee
        {
            get { return Type == 2 ? chkIsTradeUnionFee.Checked : (bool?)null; }
            set
            {
                if (value == null) return;
                chkIsTradeUnionFee.Checked = (bool)value;
            }
        }
        public string Description
        {
            get { return memoDescription.Text; }
            set { memoDescription.Text = value; }
        }
        public string DebitAccountCode
        {
            get { return grdLockUpDebitAccountCode.EditValue == null ? null : grdLockUpDebitAccountCode.EditValue.ToString(); }//.GetColumnValue("AccountCode").ToString(); }
            set { grdLockUpDebitAccountCode.EditValue = value; }
        }
        public string CreditAccountCode
        {
            get { return grdLockUpCreditAccountCode.EditValue == null ? null : grdLockUpCreditAccountCode.EditValue.ToString(); }//.GetColumnValue("AccountCode").ToString(); }
            set { grdLockUpCreditAccountCode.EditValue = value; }
        }
        public string BudgetChapterCode
        {
            get { return grdLockUpBudgetChapterCode.EditValue == null ? null : grdLockUpBudgetChapterCode.GetColumnValue("BudgetChapterCode").ToString(); }
            set { grdLockUpBudgetChapterCode.EditValue = value; }
        }
        public bool IsDefault
        {
            get { return chkIsDefault.Checked; }
            set { chkIsDefault.Checked = value; }
        }
        public bool IsActive
        {
            get { return chkIsActive.Checked; }
            set { chkIsActive.Checked = value; }
        }
        public string BudgetSourceCode
        {
            get { return grdLockUpBudgetSourceCode.EditValue == null ? null : grdLockUpBudgetSourceCode.EditValue.ToString(); }//.GetColumnValue("BudgetSourceCode").ToString(); }
            set { grdLockUpBudgetSourceCode.EditValue = value; }
        }
        public string BudgetCategoryCode
        {
            get { return grdLockUpBudgetCategoryCode.EditValue == null ? null : grdLockUpBudgetCategoryCode.GetColumnValue("BudgetCategoryCode").ToString(); }
            set { grdLockUpBudgetCategoryCode.EditValue = value; }
        }
        public string BudgetGroupCode
        {
            get { return grdLockUpBudgetGroupCode.EditValue == null ? null : grdLockUpBudgetGroupCode.EditValue.ToString(); }//.GetColumnValue("BudgetItemCode").ToString(); }
            set { grdLockUpBudgetGroupCode.EditValue = value; }
        }
        public string BudgetItemCode
        {
            get { return grdLockUpBudgetItemCode.EditValue == null ? null : grdLockUpBudgetItemCode.EditValue.ToString(); }//.GetColumnValue("BudgetItemCode").ToString(); }
            set { grdLockUpBudgetItemCode.EditValue = value; }
        }

        #endregion

        #region Combobox
        public IList<AccountModel> Accounts
        {
            set
            {
                if (value == null) value = new List<AccountModel>();
                var debitAccounts = value.Where(w => w.AccountCode.StartsWith("6")).ToList() ?? new List<AccountModel>();
                var creditAccounts = value.Where(w => 
                    w.AccountCode == "11121" 
                || w.AccountCode == "11122"
                || w.AccountCode == "11221"
                || w.AccountCode == "11222").ToList() ?? new List<AccountModel>();
                GridLookUpItem.Account(debitAccounts, grdLockUpDebitAccountCode, grdLockUpDebitAccountCodeView, "AccountCode", "AccountCode");
                GridLookUpItem.Account(creditAccounts, grdLockUpCreditAccountCode, grdLockUpCreditAccountCodeView, "AccountCode", "AccountCode");
            }
        }

        public IList<BudgetItemModel> BudgetItems
        {
            set
            {
                var lstBudgetGroups = value == null ? new List<BudgetItemModel>() : value.Where(c => (c.BudgetItemType == 1 || c.BudgetItemType == 2)).ToList();
                var lstBudgetItems = value == null ? new List<BudgetItemModel>() : value.Where(c => (c.BudgetItemType == 3 || c.BudgetItemType == 4)).ToList();

                GridLookUpItem.BudgetItem(lstBudgetGroups, grdLockUpBudgetGroupCode, grdLockUpBudgetGroupCodeView, "BudgetItemCode", "BudgetItemCode");
                GridLookUpItem.BudgetItem(lstBudgetItems, grdLockUpBudgetItemCode, grdLockUpBudgetItemCodeView, "BudgetItemCode", "BudgetItemCode");
            }
        }

        public IList<BudgetSourceModel> BudgetSources
        {
            set
            {
                GridLookUpItem.BudgetSource(value ?? new List<BudgetSourceModel>(), grdLockUpBudgetSourceCode, grdLockUpBudgetSourceCodeView, "BudgetSourceCode", "BudgetSourceCode");
            }
        }

        public IList<ObjectGeneral> Types
        {
            set
            {
                GridLookUpItem.ObjectGeneral(value, cboType, cboTypeView);
            }
        }

        public IList<ObjectGeneral> PayItemCodes
        {
            set
            {
                GridLookUpItem.ObjectGeneralPayItem(value, lookUpPayItemCode, lookUpPayItemCodeView, "ObjectGeneralCode", "ObjectGeneralCode");
            }
        }

        #endregion

        #region Override Functions

        protected override void InitData()
        {
            var objectGeneral = new ObjectGeneral();
            PayItemCodes = objectGeneral.GetPayItemCodes();
            Types = objectGeneral.GetPayItemTypes();

            _globalVariable = new GlobalVariable();
            _accountsPresenter.DisplayActive();
            _budgetItemsPresenter.DisplayActive();
            _budgetSourcesPresenter.DisplayActive();
            if (KeyValue != null)
                _payItemPresenter.Display(KeyValue);
            else
                CreditAccountCode = _globalVariable.CurrencyCodeOfSalary == @"USD" ? @"11121" : "11122";
            if (ActionMode == ActionModeEnum.Edit)
            {
                lookUpPayItemCode.Enabled = false;
            }

            memoDescription.Enabled = false;
        }

        protected override void InitControls()
        {
            lookUpPayItemCode.Focus();
        }

        protected override bool ValidData()
        {
            if (string.IsNullOrEmpty(PayItemCode))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResPayItemCode"),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                lookUpPayItemCode.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(PayItemName))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResPayItemName"),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPayItemName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(Description))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResPayItemDescription"),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                memoDescription.Focus();
                return false;
            }
            if (Type == -1)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResPayItemType"),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboType.Focus();
                return false;
            }
            if (Type == 2 && chkIsSocialInsurance.Checked == false && chkIsCareInsurance.Checked == false && chkIsTradeUnionFee.Checked == false)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResPayItemPayBySelf"),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboType.Focus();
                return false;
            }
            return true;
        }

        protected override int SaveData()
        {
            return _payItemPresenter.Save();
        }

        #endregion

        #region Events

        public FrmXtraPayItemDetail()
        {
            InitializeComponent();
            _payItemPresenter = new PayItemPresenter(this);
            _accountsPresenter = new AccountsPresenter(this);
            _budgetItemsPresenter = new BudgetItemsPresenter(this);
            _budgetSourcesPresenter = new BudgetSourcesPresenter(this);
            grdLockUpDebitAccountCode.EditValue = 61111;
        }

        private void cboType_EditValueChanged(object sender, System.EventArgs e)
        {
            if (Type == 2)
            {
                chkIsSocialInsurance.Enabled = true;
                chkIsCareInsurance.Enabled = true;
                chkIsTradeUnionFee.Enabled = true;
            }
            else
            {
                chkIsSocialInsurance.Enabled = false;
                chkIsCareInsurance.Enabled = false;
                chkIsTradeUnionFee.Enabled = false;
                chkIsSocialInsurance.Checked = false;
                chkIsCareInsurance.Checked = false;
                chkIsTradeUnionFee.Checked = false;
            }
        }

        private void grdLockUpDebitAccountCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdLockUpDebitAccountCode.SelectionLength == grdLockUpDebitAccountCode.Text.Length && (e.KeyData == Keys.Back || e.KeyData == Keys.Delete))
            {
                grdLockUpDebitAccountCode.EditValue = null;
                e.Handled = true;
            }
        }

        private void grdLockUpCreditAccountCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdLockUpCreditAccountCode.SelectionLength == grdLockUpCreditAccountCode.Text.Length && (e.KeyData == Keys.Back || e.KeyData == Keys.Delete))
            {
                grdLockUpCreditAccountCode.EditValue = null;
                e.Handled = true;
            }
        }

        private void grdLockUpBudgetSourceCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdLockUpBudgetSourceCode.SelectionLength == grdLockUpBudgetSourceCode.Text.Length && (e.KeyData == Keys.Back || e.KeyData == Keys.Delete))
            {
                grdLockUpBudgetSourceCode.EditValue = null;
                e.Handled = true;
            }
        }

        private void grdLockUpBudgetChapterCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdLockUpBudgetChapterCode.SelectionLength == grdLockUpBudgetChapterCode.Text.Length && (e.KeyData == Keys.Back || e.KeyData == Keys.Delete))
            {
                grdLockUpBudgetChapterCode.EditValue = null;
                e.Handled = true;
            }
        }

        private void grdLockUpBudgetCategoryCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdLockUpBudgetCategoryCode.SelectionLength == grdLockUpBudgetCategoryCode.Text.Length && (e.KeyData == Keys.Back || e.KeyData == Keys.Delete))
            {
                grdLockUpBudgetCategoryCode.EditValue = null;
                e.Handled = true;
            }
        }

        private void grdLockUpBudgetGroupCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdLockUpBudgetGroupCode.SelectionLength == grdLockUpBudgetGroupCode.Text.Length && (e.KeyData == Keys.Back || e.KeyData == Keys.Delete))
            {
                grdLockUpBudgetGroupCode.EditValue = null;
                e.Handled = true;
            }
        }

        private void grdLockUpBudgetItemCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdLockUpBudgetItemCode.SelectionLength == grdLockUpBudgetItemCode.Text.Length && (e.KeyData == Keys.Back || e.KeyData == Keys.Delete))
            {
                grdLockUpBudgetItemCode.EditValue = null;
                e.Handled = true;
            }
        }

        private void lookUpPayItemCode_EditValueChanged(object sender, System.EventArgs e)
        {
            var lstPayItems = lookUpPayItemCode.Properties.DataSource as List<ObjectGeneral>;
            if (lstPayItems != null)
            {
                txtPayItemName.Text = lstPayItems.Where(w => w.ObjectGeneralCode == lookUpPayItemCode.EditValue.ToString())?.First().ObjectGeneralName ?? "";
            }
        }

        #endregion
    }
}
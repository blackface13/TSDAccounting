using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Presenter.Dictionary.Account;
using TSD.AccountingSoft.Presenter.Dictionary.AutoBusiness;
using TSD.AccountingSoft.Presenter.Dictionary.BudgetItem;
using TSD.AccountingSoft.Presenter.Dictionary.BudgetSource;
using TSD.AccountingSoft.Presenter.Dictionary.Currency;
using TSD.AccountingSoft.Presenter.Dictionary.RefType;
using TSD.AccountingSoft.Presenter.Dictionary.VoucherType;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.WindowsForm.CommonClass;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.Resources;
using TSD.Enum;
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
    public partial class FrmXtraAutoBusinessDetails : FrmXtraBaseCategoryDetail, IAutoBusinessView, IAccountsView, IVoucherTypesView, IRefTypesView, IBudgetSourcesView, IBudgetItemsView, ICurrenciesView
    {
        public FrmXtraAutoBusinessDetails()
        {
            InitializeComponent();

            _autoBusinessPresenter = new AutoBusinessPresenter(this);
            _accountsPresenter = new AccountsPresenter(this);
            _voucherTypesPresenter = new VoucherTypesPresenter(this);
            _refTypesPresenter = new RefTypesPresenter(this);
            _budgetSourcesPresenter = new BudgetSourcesPresenter(this);
            _budgetItemsPresenter = new BudgetItemsPresenter(this);
            _currencyPresenter = new CurrenciesPresenter(this);
        }

        private readonly AutoBusinessPresenter _autoBusinessPresenter;
        private readonly AccountsPresenter _accountsPresenter;
        private readonly BudgetSourcesPresenter _budgetSourcesPresenter;
        private readonly BudgetItemsPresenter _budgetItemsPresenter;
        private readonly VoucherTypesPresenter _voucherTypesPresenter;
        private readonly RefTypesPresenter _refTypesPresenter;
        private readonly CurrenciesPresenter _currencyPresenter;

        #region IAutoBusinessView Members

        public int AutoBusinessId { get; set; }

        public string AutoBusinessCode
        {
            get { return txtAutoBusinessCode.Text; }
            set { txtAutoBusinessCode.Text = value; }
        }

        public string AutoBusinessName
        {
            get { return txtAutoBusinessName.Text; }
            set { txtAutoBusinessName.Text = value; }
        }

        public int RefTypeId
        {
            get
            {
                var refType = (RefTypeModel)grdLockUpRefTypeId.GetSelectedDataRow();
                return refType == null ? 0 : refType.RefTypeId;
            }
            set
            {
                grdLockUpRefTypeId.EditValue = value;
            }
        }

        public int? VoucherTypeId
        {
            get
            {
                if (grdLockUpVoucherTypeId.EditValue == null)
                    return null;
                return (int?)grdLockUpVoucherTypeId.EditValue;
            }
            set
            {
                grdLockUpVoucherTypeId.EditValue = value;
            }
        }

        public string DebitAccountNumber
        {
            get
            {
                if (ReferenceEquals(grdLookUpDebitAccountNumber.EditValue, "")) return null;
                return (string)grdLookUpDebitAccountNumber.EditValue;
            }
            set { grdLookUpDebitAccountNumber.EditValue = value; }
        }

        public string CreditAccountNumber
        {
            get
            {
                if (ReferenceEquals(grdLookUpCreditAccountNumber.EditValue, "")) return null;
                return (string)grdLookUpCreditAccountNumber.EditValue;
            }
            set { grdLookUpCreditAccountNumber.EditValue = value; }
        }

        public string BudgetSourceCode
        {
            get
            {
                if (ReferenceEquals(grdLookUpBudgetSourceCode.EditValue, "")) return null;
                return (string)grdLookUpBudgetSourceCode.EditValue;
            }
            set { grdLookUpBudgetSourceCode.EditValue = value; }
        }

        public string BudgetItemCode
        {
            get
            {
                var budgetItem = (BudgetItemModel)grdLookUpBudgetItemCode.GetSelectedDataRow();
                return budgetItem == null ? null : budgetItem.BudgetItemCode;
            }
            set { grdLookUpBudgetItemCode.EditValue = value; }
        }

        public string Description
        {
            get { return memoDescription.Text; }
            set { memoDescription.Text = value; }
        }

        public string CurrencyCode
        {
            get
            {
                var currentcy = (CurrencyModel)grdLockUpCurrency.GetSelectedDataRow();
                return currentcy == null ? null : currentcy.CurrencyCode;
            }
            set { grdLockUpCurrency.EditValue = value; }
        }

        public bool IsActive
        {
            get { return chkIsActive.Checked; }
            set { chkIsActive.Checked = value; }
        }

        #endregion

        #region Combobox

        public IList<AccountModel> Accounts
        {
            set
            {
                GridLookUpItem.Account(value, grdLookUpDebitAccountNumber, grdLookUpDebitAccountNumberView, "AccountCode", "AccountCode");
                GridLookUpItem.Account(value, grdLookUpCreditAccountNumber, grdLookUpCreditAccountNumberView, "AccountCode", "AccountCode");
            }
        }

        public IList<VoucherTypeModel> VoucherTypes
        {
            set
            {
                GridLookUpItem.VoucherType(value, grdLockUpVoucherTypeId, grdLockUpVoucherTypeIdView, "VoucherTypeName", "VoucherTypeId");
            }
        }

        public IList<RefTypeModel> RefTypes
        {
            set
            {
                GridLookUpItem.RefType(value, grdLockUpRefTypeId, grdLockUpRefTypeIdView, "RefTypeName", "RefTypeId");
            }
        }

        public IList<BudgetSourceModel> BudgetSources
        {
            set
            {
                if (value == null)
                    value = new List<BudgetSourceModel>();
                else
                    value = value.Where(w => w.IsParent == false).ToList();
                GridLookUpItem.BudgetSource(value, grdLookUpBudgetSourceCode, grdLookUpBudgetSourceCodeView, "BudgetSourceCode", "BudgetSourceCode");
            }
        }

        public IList<BudgetItemModel> BudgetItems
        {
            set
            {
                var budgetItem = value.Where(c => c.IsActive && (c.BudgetItemType == 4 || (c.BudgetItemType == 3 && c.IsShowOnVoucher))).ToList();
                if (budgetItem == null)
                    budgetItem = new List<BudgetItemModel>();

                GridLookUpItem.BudgetItem(budgetItem, grdLookUpBudgetItemCode, grdLookUpBudgetItemCodeView, "BudgetItemCode", "BudgetItemCode");
            }
        }

        public IList<CurrencyModel> Currencies
        {
            set
            {
                GridLookUpItem.Currency(value, grdLockUpCurrency, grdLockUpCurrencyView, "CurrencyCode", "CurrencyCode");
            }
        }

        #endregion

        protected override void InitData()
        {
            _accountsPresenter.DisplayActive();
            _voucherTypesPresenter.DisplayActive();
            _refTypesPresenter.Display();
            _budgetSourcesPresenter.DisplayActive();
            _budgetItemsPresenter.DisplayActive();
            _currencyPresenter.DisplayActive();
            if (KeyValue != null) { _autoBusinessPresenter.Display(KeyValue); }
        }

        protected override void InitControls()
        {

        }

        protected override bool ValidData()
        {
            if (string.IsNullOrEmpty(AutoBusinessCode))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResAutoBusinessCode"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAutoBusinessCode.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(AutoBusinessName))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResAutoBusinessName"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAutoBusinessName.Focus();
                return false;
            }

            if (RefTypeId == 0)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResRefTypeId"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                grdLockUpRefTypeId.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(DebitAccountNumber))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ReceiptVoucheraccountNumberEmpty"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                grdLookUpDebitAccountNumber.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(CreditAccountNumber))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ReceiptVoucherChildCorrespondingAccountNumberEmpty"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                grdLookUpCreditAccountNumber.Focus();
                return false;
            }

            //if (string.IsNullOrEmpty(BudgetSourceCode))
            //{
            //    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResBudgetSourceCode"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    grdLookUpBudgetSourceCode.Focus();
            //    return false;
            //}

            //if (string.IsNullOrEmpty(BudgetItemCode))
            //{
            //    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResBudgetItemCode"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    grdLookUpBudgetItemCode.Focus();
            //    return false;
            //}

            return true;
        }

        protected override int SaveData()
        {
            return _autoBusinessPresenter.Save();
        }

        private void grdLookUpDebitAccountNumber_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
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

                            var lstAccount = (List<AccountModel>)grdLookUpDebitAccountNumber.Properties.DataSource;
                            if (lstAccount != null && lstAccount.Count > 0)
                                DebitAccountNumber = lstAccount.OrderByDescending(o => o.AccountId).FirstOrDefault().AccountCode;
                        }
                    }
                }
            }
        }

        private void grdLookUpCreditAccountNumber_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
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

                            var lstAccount = (List<AccountModel>)grdLookUpCreditAccountNumber.Properties.DataSource;
                            if (lstAccount != null && lstAccount.Count > 0)
                                CreditAccountNumber = lstAccount.OrderByDescending(o => o.AccountId).FirstOrDefault().AccountCode;
                        }
                    }
                }
            }
        }

        private void grdLookUpBudgetSourceCode_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)
            {
                using (var frmBudgetSource = new FrmXtraBudgetSourceDetail())
                {
                    frmBudgetSource.ActionMode = ActionModeEnum.AddNew;

                    if (frmBudgetSource.ShowDialog() == DialogResult.OK)
                    {
                        if (frmBudgetSource.DialogResult == DialogResult.OK)
                        {
                            _budgetSourcesPresenter.DisplayActive();

                            var lstBudgetSource = (List<BudgetSourceModel>)grdLookUpBudgetSourceCode.Properties.DataSource;
                            if (lstBudgetSource != null && lstBudgetSource.Count > 0)
                                BudgetSourceCode = lstBudgetSource.OrderByDescending(o => o.BudgetSourceId).FirstOrDefault().BudgetSourceCode;
                        }
                    }
                }
            }
        }

        private void grdLookUpBudgetItemCode_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
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

                            var lstBudgetItem = (List<BudgetItemModel>)grdLookUpBudgetItemCode.Properties.DataSource;
                            if (lstBudgetItem != null && lstBudgetItem.Count > 0)
                                BudgetItemCode = lstBudgetItem.OrderByDescending(o => o.BudgetItemId).FirstOrDefault().BudgetItemCode;
                        }
                    }
                }
            }
        }
    }
}

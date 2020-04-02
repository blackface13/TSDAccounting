using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Presenter.Dictionary.Account;
using TSD.AccountingSoft.Presenter.Dictionary.RefType;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormDictionary;
using TSD.AccountingSoft.WindowsForm.Resources;
using TSD.AccountingSoft.WindowsForm.UserControl.Dictionary;
using TSD.AccountingSoft.Report.BaseParameterForm;
using TSD.AccountingSoft.Report.CommonClass;
using TSD.Enum;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace TSD.AccountingSoft.WindowsForm.FormCategories.RefType
{
    public partial class FrmRefTypeDetail : FrmXtraBaseCategoryDetail, IRefTypeView, IAccountsView
    {
        private readonly AccountsPresenter _accountsPresenter;
        private readonly RefTypePresenter _refTypePresenter;

        public FrmRefTypeDetail()
        {
            InitializeComponent();
            _refTypePresenter = new RefTypePresenter(this);
            _accountsPresenter = new AccountsPresenter(this);
        }

        /// <summary>
        ///     Sets the accounts.
        /// </summary>
        /// <value>
        ///     The accounts.
        /// </value>
        public IList<AccountModel> Accounts
        {
            set
            {
                cboDefaultTaxAccountId.Properties.DataSource = value.Where(x => x.IsActive).ToList();
                cboDefaultTaxAccountId.Properties.PopulateColumns();

                cboDefaultCreditAccountId.Properties.DataSource = value.Where(x => x.IsActive).ToList();
                cboDefaultCreditAccountId.Properties.PopulateColumns();

                cboDefaultDebitAccountId.Properties.DataSource = value.Where(x => x.IsActive).ToList();
                cboDefaultDebitAccountId.Properties.PopulateColumns();

                var treeColumnsCollection = new List<XtraColumn>
                {
                    new XtraColumn {ColumnName = "AccountId", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "AccountCode",
                        ColumnVisible = true,
                        ColumnWith = 50,
                        ColumnCaption = "Tài khoản"
                    },
                    new XtraColumn {ColumnName = "AccountCategoryId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ParentId", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "AccountName",
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnCaption = "Tên tài khoản"
                    },
                    new XtraColumn {ColumnName = "Description", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsActive", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ForeignName", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Grade", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsDetail", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BalanceSide", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ConcomitantAccount", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BankId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsChapter", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsBudgetCategory", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsBudgetItem", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsBudgetGroup", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsBudgetSource", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsActivity", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsCurrency", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsCustomer", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsVendor", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsEmployee", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsProject", ColumnVisible = false},
                    new XtraColumn {ColumnName = "CurrencyCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsAllowinputcts", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsAccountingObject", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsInventoryItem", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsFixedAsset", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ParentId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsCapitalAllocate", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsBudgetSubItem", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsBank", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsSystem", ColumnVisible = false}
                };

                foreach (var column in treeColumnsCollection)
                    if (column.ColumnVisible)
                    {
                        cboDefaultTaxAccountId.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboDefaultTaxAccountId.Properties.SortColumnIndex = column.ColumnPosition;

                        cboDefaultCreditAccountId.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboDefaultCreditAccountId.Properties.SortColumnIndex = column.ColumnPosition;

                        cboDefaultDebitAccountId.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        cboDefaultDebitAccountId.Properties.SortColumnIndex = column.ColumnPosition;
                    }
                    else
                    {
                        cboDefaultTaxAccountId.Properties.Columns[column.ColumnName].Visible = false;

                        cboDefaultCreditAccountId.Properties.Columns[column.ColumnName].Visible = false;

                        cboDefaultDebitAccountId.Properties.Columns[column.ColumnName].Visible = false;
                    }
                cboDefaultTaxAccountId.Properties.DisplayMember = "AccountCode";
                cboDefaultTaxAccountId.Properties.ValueMember = "AccountCode";
                cboDefaultTaxAccountId.Properties.NullText = string.Empty;
                cboDefaultTaxAccountId.Properties.ShowFooter = false;

                cboDefaultCreditAccountId.Properties.DisplayMember = "AccountCode";
                cboDefaultCreditAccountId.Properties.ValueMember = "AccountCode";
                cboDefaultCreditAccountId.Properties.NullText = string.Empty;
                cboDefaultCreditAccountId.Properties.ShowFooter = false;

                cboDefaultDebitAccountId.Properties.DisplayMember = "AccountCode";
                cboDefaultDebitAccountId.Properties.ValueMember = "AccountCode";
                cboDefaultDebitAccountId.Properties.NullText = string.Empty;
                cboDefaultDebitAccountId.Properties.ShowFooter = false;
            }
        }

        /// <summary>
        /// Handles the ButtonClick event of the cboDefaultCreditAccountId control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ButtonPressedEventArgs"/> instance containing the event data.</param>
        private void cboDefaultCreditAccountId_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
                ShowAccountDetail();
        }

        /// <summary>
        /// Gets the account detail.
        /// </summary>
        /// <returns></returns>
        private FrmXtraBaseTreeDetail GetAccountDetail()
        {
            return new FrmXtraAccountDetail();
        }

        private FrmXtraBaseParameter GetAccounts(string parameter, TextEdit txtTextEdit)
        {
            return new FrmAccountList(parameter, txtTextEdit);
            //return null;
        }

        /// <summary>
        /// Shows the account detail.
        /// </summary>
        private void ShowAccountDetail()
        {
            try
            {
                using (var frmDetail = GetAccountDetail())
                {
                    frmDetail.KeyFieldName = "AccountId";
                    frmDetail.ActionMode = ActionModeEnum.AddNew;
                    frmDetail.HelpTopicId = HelpTopicId;
                    frmDetail.KeyValue = null;
                    if (frmDetail.ShowDialog() == DialogResult.OK) { }
                }
            }
            catch (Exception ex) { XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }


        /// <summary>
        /// Shows the account detail.
        /// </summary>
        private void ShowAccounts(string parameter, TextEdit txtTextEdit)
        {
            try
            {
                using (var frmDetail = GetAccounts(parameter, txtTextEdit))
                {
                    if (frmDetail.ShowDialog() == DialogResult.OK) { }
                }
            }
            catch (Exception ex) { XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnDefaultDebitAccountCategoryId_Click(object sender, EventArgs e)
        {
            ShowAccounts(DefaultDebitAccountCategoryId, txtDefaultDebitAccountCategoryId);
        }

        private void btnDefaultCreditAccountCategoryId_Click(object sender, EventArgs e)
        {
            ShowAccounts(DefaultCreditAccountCategoryId, txtDefaultCreditAccountCategoryId);
        }

        private void btnDefaultTaxAccountCategoryId_Click(object sender, EventArgs e)
        {
            ShowAccounts(DefaultTaxAccountCategoryId, txtDefaultTaxAccountCategoryId);
        }

        #region Overide

        /// <summary>
        ///     Focuses the control.
        /// </summary>
        protected override void InitControls()
        {
            txtDefaultDebitAccountCategoryId.Focus();
            cboDefaultTaxAccountId.Properties.NullText = "";

            cboDefaultCreditAccountId.Properties.NullText = "";

            cboDefaultDebitAccountId.Properties.NullText = "";
        }

        /// <summary>
        /// Loads the look up edit.
        /// </summary>
        public void LoadLookUpEdit()
        {
            _accountsPresenter.Display();
        }

        /// <summary>
        ///     Initializes the data.
        /// </summary>
        protected override void InitData()
        {
            _accountsPresenter.Display();
            if (KeyValue != null)
                _refTypePresenter.Display(int.Parse(KeyValue));
        }

        /// <summary>
        ///     Saves the data.
        /// </summary>
        /// <returns>
        ///     System.Int32.
        /// </returns>
        protected override int SaveData()
        {
            return _refTypePresenter.Save();
        }

        #endregion

        #region Property

        /// <summary>
        ///     Gets or sets the reference type identifier.
        /// </summary>
        /// <value>
        ///     The reference type identifier.
        /// </value>
        public int RefTypeId { get; set; }

        /// <summary>
        ///     Gets or sets the name of the reference type.
        /// </summary>
        /// <value>
        ///     The name of the reference type.
        /// </value>
        public string RefTypeName
        {
            get { return txtRefTypeName.Text; }
            set
            {
                txtRefTypeName.Text = value;
            }
        }

        /// <summary>
        ///     Gets or sets the default debit account category Identifier.
        /// </summary>
        /// <value>
        ///     The default debit account category Identifier.
        /// </value>
        public string DefaultDebitAccountCategoryId
        {
            get { return txtDefaultDebitAccountCategoryId.Text; }
            set
            {
                txtDefaultDebitAccountCategoryId.Text = value;
            }
        }

        /// <summary>
        ///     Gets or sets the default debit account Identifier.
        /// </summary>
        /// <value>
        ///     The default debit account Identifier.
        /// </value>
        public string DefaultDebitAccountId
        {
            get { return cboDefaultDebitAccountId.EditValue == null ? null : cboDefaultDebitAccountId.EditValue.ToString(); }
            set
            {
                if (string.IsNullOrEmpty(txtDefaultDebitAccountCategoryId.EditValue.ToString()))
                    cboDefaultDebitAccountId.EditValue = "";
                else
                    cboDefaultDebitAccountId.EditValue = value;
            }
        }

        /// <summary>
        ///     Gets or sets the default credit account category Identifier.
        /// </summary>
        /// <value>
        ///     The default credit account category Identifier.
        /// </value>
        public string DefaultCreditAccountCategoryId
        {
            get { return txtDefaultCreditAccountCategoryId.Text; }
            set { txtDefaultCreditAccountCategoryId.Text = value; }
        }

        /// <summary>
        ///     Gets or sets the default credit account Identifier.
        /// </summary>
        /// <value>
        ///     The default credit account Identifier.
        /// </value>
        public string DefaultCreditAccountId
        {
            get { return cboDefaultCreditAccountId.EditValue == null ? null : cboDefaultCreditAccountId.EditValue.ToString(); }
            set
            {
                if (string.IsNullOrEmpty(txtDefaultCreditAccountCategoryId.EditValue.ToString()))
                    cboDefaultCreditAccountId.EditValue = "";
                else
                    cboDefaultCreditAccountId.EditValue = value;
            }
        }

        /// <summary>
        ///     Gets or sets the default tax account category Identifier.
        /// </summary>
        /// <value>
        ///     The default tax account category Identifier.
        /// </value>
        public string DefaultTaxAccountCategoryId
        {
            get { return txtDefaultTaxAccountCategoryId.Text; }
            set
            {
                txtDefaultTaxAccountCategoryId.Text = value;
            }
        }

        /// <summary>
        ///     Gets or sets the default tax account Identifier.
        /// </summary>
        /// <value>
        ///     The default tax account Identifier.
        /// </value>
        public string DefaultTaxAccountId
        {
            get { return cboDefaultTaxAccountId.EditValue == null ? null : cboDefaultTaxAccountId.EditValue.ToString(); }
            set
            {
                if (string.IsNullOrEmpty(txtDefaultTaxAccountCategoryId.EditValue.ToString()))
                    cboDefaultTaxAccountId.EditValue = "";
                else
                    cboDefaultTaxAccountId.EditValue = value;
            }
        }

        #endregion

        private void cboDefaultDebitAccountId_QueryPopUp(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Control button = sender as Control;
            var name = button.Name;
            var list = new List<string>();
            switch (name)
            {
                case "cboDefaultTaxAccountId":
                    list = new List<string>();
                    if (!string.IsNullOrEmpty(DefaultTaxAccountCategoryId))
                    {
                        list = DefaultTaxAccountCategoryId.Split(';').ToList();
                    }
                    cboDefaultTaxAccountId.Properties.DataSource = new AccountsPresenter(null).GetAccounts().Where(x => x.IsActive && (list.Contains(x.AccountCode) || list.Contains(x.AccountCategoryId.ToString())));
                    break;
                case "cboDefaultCreditAccountId":
                    list = new List<string>();
                    if (!string.IsNullOrEmpty(DefaultCreditAccountCategoryId))
                    {
                        list = DefaultCreditAccountCategoryId.Split(';').ToList();
                    }
                    cboDefaultCreditAccountId.Properties.DataSource = new AccountsPresenter(null).GetAccounts().Where(x => x.IsActive && (list.Contains(x.AccountCode) || list.Contains(x.AccountCategoryId.ToString())));
                    break;
                case "cboDefaultDebitAccountId":
                    list = new List<string>();
                    if (!string.IsNullOrEmpty(DefaultDebitAccountCategoryId))
                    {
                        list = DefaultDebitAccountCategoryId.Split(';').ToList();
                    }
                    cboDefaultDebitAccountId.Properties.DataSource = new AccountsPresenter(null).GetAccounts().Where(x => x.IsActive && (list.Contains(x.AccountCode) ||list.Contains(x.AccountCategoryId.ToString())));
                    break;
            }
        }

        /// <summary>
        /// Handles the EditValueChanged event of the txtDefaultDebitAccountCategoryId control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void txtDefaultDebitAccountCategoryId_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDefaultDebitAccountCategoryId.EditValue.ToString()))
                cboDefaultDebitAccountId.EditValue = "";
        }

        /// <summary>
        /// Handles the EditValueChanged event of the txtDefaultCreditAccountCategoryId control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void txtDefaultCreditAccountCategoryId_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDefaultCreditAccountCategoryId.EditValue.ToString()))
                cboDefaultCreditAccountId.EditValue = "";
        }

        /// <summary>
        /// Handles the EditValueChanged event of the txtDefaultTaxAccountCategoryId control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void txtDefaultTaxAccountCategoryId_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDefaultTaxAccountCategoryId.EditValue.ToString()))
                cboDefaultTaxAccountId.EditValue = "";
        }
    }
}
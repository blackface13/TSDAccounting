/***********************************************************************
 * <copyright file="FrmXtraAccountTranferDetail.cs" company="BUCA JSC">
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
using System.Linq;
using System.Windows.Forms;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Presenter.Dictionary.Account;
using TSD.AccountingSoft.Presenter.Dictionary.AccountTranfer;
using TSD.AccountingSoft.Presenter.Dictionary.BudgetSource;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.WindowsForm.CommonClass;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.Resources;
using TSD.Enum;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraGrid.Views.Grid;

namespace TSD.AccountingSoft.WindowsForm.FormDictionary
{
    /// <summary>
    /// class FrmXtraAccountTranferDetail
    /// </summary>
    public partial class FrmXtraAccountTranferDetail : FrmXtraBaseCategoryDetail, IAccountTranferView, IAccountsView, IBudgetSourcesView
    {
        private readonly AccountsPresenter _accountsPresenter;
        private readonly AccountTranferPresenter _accountTranferPresenter;
        private readonly BudgetSourcesPresenter _budgetSourcesPresenter;

        #region AccountTranfer

        /// <summary>
        /// Gets or sets the account tranfer identifier.
        /// </summary>
        /// <value>
        /// The account tranfer identifier.
        /// </value>
        public int AccountTranferId { get; set; }

        /// <summary>
        /// Gets or sets the account tranfer code.
        /// </summary>
        /// <value>
        /// The account tranfer code.
        /// </value>
        public string AccountTranferCode
        {
            get { return txtAccountTranferCode.Text; }
            set { txtAccountTranferCode.Text = value; }
        }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        /// <value>
        /// The sort order.
        /// </value>
        public int SortOrder
        {
            get { return (int)spinSortOrder.Value; }
            set { spinSortOrder.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the account source code.
        /// </summary>
        /// <value>
        /// The account source code.
        /// </value>
        public string AccountSourceCode
        {
            get { return grdLookUpEditAccountSourceCode.EditValue == null ? null : grdLookUpEditAccountSourceCode.EditValue.ToString(); }
            set { grdLookUpEditAccountSourceCode.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the account destination code.
        /// </summary>
        /// <value>
        /// The account destination code.
        /// </value>
        public string AccountDestinationCode
        {
            get { return grdLookUpEditAccountDestinationCode.EditValue == null ? null : grdLookUpEditAccountDestinationCode.EditValue.ToString(); }
            set { grdLookUpEditAccountDestinationCode.Text = value; }
        }

        public int? BudgetSourceId
        {
            get
            {
                var budgetSource = (BudgetSourceModel)grdLookUpBudgetSource.GetSelectedDataRow();
                if (budgetSource != null)
                    return budgetSource.BudgetSourceId;
                else
                    return null;
            }
            set { grdLookUpBudgetSource.EditValue = value; }
        }

        public string ReferentAccount
        {
            get
            {
                var account = (AccountModel)grdLookUpReferentAccount.GetSelectedDataRow();
                return account == null ? null : account.AccountCode;
            }
            set { grdLookUpReferentAccount.EditValue = value; }
        }


        /// <summary>
        /// Gets or sets the side of tranfer.
        /// </summary>
        /// <value>
        /// The side of tranfer.
        /// </value>
        public int SideOfTranfer
        {
            get { return cboSideOfTranfer.SelectedIndex; }
            set { cboSideOfTranfer.SelectedIndex = value; }
        }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public int Type
        {
            get { return cboType.SelectedIndex; }
            set { cboType.SelectedIndex = value; }
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

        #endregion

        #region Combobox

        /// <summary>
        /// Sets the accounts.
        /// </summary>
        /// <value>
        /// The accounts.
        /// </value>
        public IList<AccountModel> Accounts
        {
            set
            {
                GridLookUpItem.Account(value ?? new List<AccountModel>(), grdLookUpEditAccountSourceCode, grdLookUpEditAccountSourceCodeView, "AccountCode", "AccountCode");
                GridLookUpItem.Account(value ?? new List<AccountModel>(), grdLookUpEditAccountDestinationCode, grdLookUpEditAccountDestinationCodeView, "AccountCode", "AccountCode");
                GridLookUpItem.Account(value ?? new List<AccountModel>(), grdLookUpReferentAccount, grdLookUpReferentAccountView, "AccountCode", "AccountCode");
            }
        }

        public IList<BudgetSourceModel> BudgetSources
        {
            set
            {
                GridLookUpItem.BudgetSource(value ?? new List<BudgetSourceModel>(), grdLookUpBudgetSource, grdLookUpBudgetSourceView, "BudgetSourceCode", "BudgetSourceId");
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmXtraAccountTranferDetail"/> class.
        /// </summary>
        public FrmXtraAccountTranferDetail()
        {
            InitializeComponent();
            _accountsPresenter = new AccountsPresenter(this);
            _accountTranferPresenter = new AccountTranferPresenter(this);
            _budgetSourcesPresenter = new BudgetSourcesPresenter(this);
        }

        /// <summary>
        /// Initializes the data.
        /// </summary>
        protected override void InitData()
        {
            _budgetSourcesPresenter.DisplayActive();
            _accountsPresenter.DisplayActive();
            if (KeyValue != null)
                _accountTranferPresenter.Display(KeyValue);
        }

        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns></returns>
        protected override bool ValidData()
        {
            if (string.IsNullOrEmpty(AccountTranferCode))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResAccountTranferCode"),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAccountTranferCode.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(AccountSourceCode))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResAccountSourceCode"),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                grdLookUpEditAccountSourceCode.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(AccountDestinationCode))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResAccountDestinationCode"),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                grdLookUpEditAccountDestinationCode.Focus();
                return false;
            }
            if (AccountSourceCode == AccountDestinationCode && Type == 0)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResAccountSourceCodeSameAccountDestinationCode"),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                grdLookUpEditAccountSourceCode.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// Saves the data.
        /// </summary>
        /// <returns></returns>
        protected override int SaveData()
        {
            return _accountTranferPresenter.Save();
        }

        /// <summary>
        /// Handles the KeyDown event of the grdLookUpEditAccountSourceCode control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void grdLookUpEditAccountSourceCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdLookUpEditAccountSourceCode.SelectionLength == grdLookUpEditAccountSourceCode.Text.Length && (e.KeyData == Keys.Back || e.KeyData == Keys.Delete))
            {
                grdLookUpEditAccountSourceCode.EditValue = null;
                e.Handled = true;
            }
        }

        /// <summary>
        /// Handles the KeyDown event of the grdLookUpEditAccountDestinationCode control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void grdLookUpEditAccountDestinationCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdLookUpEditAccountDestinationCode.SelectionLength == grdLookUpEditAccountDestinationCode.Text.Length && (e.KeyData == Keys.Back || e.KeyData == Keys.Delete))
            {
                grdLookUpEditAccountDestinationCode.EditValue = null;
                e.Handled = true;
            }
        }

        private void grdLookUpEditAccountSourceCode_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
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

                            var lstAccount = (List<AccountModel>)grdLookUpEditAccountSourceCode.Properties.DataSource;
                            if (lstAccount != null && lstAccount.Count > 0)
                                AccountSourceCode = lstAccount.OrderByDescending(o => o.AccountId).FirstOrDefault().AccountCode;
                        }
                    }
                }
            }
        }

        private void grdLookUpEditAccountDestinationCode_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
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

                            var lstAccount = (List<AccountModel>)grdLookUpEditAccountDestinationCode.Properties.DataSource;
                            if (lstAccount != null && lstAccount.Count > 0)
                                AccountDestinationCode = lstAccount.OrderByDescending(o => o.AccountId).FirstOrDefault().AccountCode;
                        }
                    }
                }
            }
        }

        private void grdLookUpBudgetSource_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
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

                            var lstAccount = (List<BudgetSourceModel>)grdLookUpBudgetSource.Properties.DataSource;
                            if (lstAccount != null && lstAccount.Count > 0)
                                BudgetSourceId = lstAccount.OrderByDescending(o => o.BudgetSourceId).FirstOrDefault().BudgetSourceId;
                        }
                    }
                }
            }
        }
    }

    #endregion
}
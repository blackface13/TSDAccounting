/***********************************************************************
 * <copyright file="FrmXtraCapitalAllocateDetail.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuanHM
 * Email:    Tuanhm@buca.vn
 * Website:
 * Create Date: Tuesday, March 11, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Presenter.Dictionary.Account;
using TSD.AccountingSoft.Presenter.Dictionary.BudgetItem;
using TSD.AccountingSoft.Presenter.Dictionary.BudgetSource;
using TSD.AccountingSoft.Presenter.Dictionary.CapitalAllocate;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.WindowsForm.CommonClass;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.Resources;
using TSD.Enum;
using DevExpress.XtraEditors;


namespace TSD.AccountingSoft.WindowsForm.FormDictionary
{
    /// <summary>
    /// Class FrmXtraCapitalAllocateDetail.
    /// </summary>
    public partial class FrmXtraCapitalAllocateDetail : FrmXtraBaseCategoryDetail, ICapitalAllocateView, IAccountsView, IBudgetItemsView, IBudgetSourcesView
    {
        private readonly CapitalAllocatePresenter _capitalAllocatePresenter;
        private readonly AccountsPresenter _accountsPresenter;
        private readonly BudgetItemsPresenter _budgetItemsPresenter;
        private readonly BudgetSourcesPresenter _budgetSourcesPresenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmXtraCapitalAllocateDetail"/> class.
        /// </summary>
        public FrmXtraCapitalAllocateDetail()
        {
            InitializeComponent();
            _capitalAllocatePresenter = new CapitalAllocatePresenter(this);

            _accountsPresenter = new AccountsPresenter(this);
            _budgetItemsPresenter = new BudgetItemsPresenter(this);
            _budgetSourcesPresenter = new BudgetSourcesPresenter(this);
        }

        /// <summary>
        /// Initializes the data.
        /// </summary>
        protected override void InitData()
        {
            cboActivityID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            cboAllocateType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            _budgetItemsPresenter.DisplayActive();
            _budgetSourcesPresenter.DisplayActive();
            _accountsPresenter.DisplayActive();

            if (KeyValue != null)
                _capitalAllocatePresenter.Display(KeyValue);
            else
            {
                SetStateControl();
                cboAllocateType.SelectedIndex = 0;//.GetDataSourceValue(grdLookUpBudgetItemID.Properties.ValueMember, 0);
                txtAllocatePercent.Text = @"0";
                //grdLookUpBudgetSourceID.EditValue = grdLookUpBudgetSourceID.Properties.GetRowByKeyValue(grdLookUpBudgetSourceID.Properties.ValueMember, 0);
                //grdLookUpCapitalAccount.EditValue = grdLookUpCapitalAccount.Properties.GetDataSourceValue(grdLookUpCapitalAccount.Properties.ValueMember, 0);
                //grdLookUpExpenseAccount.EditValue = grdLookUpExpenseAccount.Properties.GetDataSourceValue(grdLookUpExpenseAccount.Properties.ValueMember, 0);
                //grdLookUpRevenueAccount.EditValue = grdLookUpRevenueAccount.Properties.GetDataSourceValue(grdLookUpRevenueAccount.Properties.ValueMember, 0);
                //grdLookUpBudgetItemID.EditValue = grdLookUpBudgetItemID.Properties.GetDataSourceValue(grdLookUpBudgetItemID.Properties.ValueMember, 0);

                grdLookUpBudgetSourceID.EditValue = grdLookUpBudgetSourceID.Properties.GetKeyValue(0);
                grdLookUpCapitalAccount.EditValue = grdLookUpCapitalAccount.Properties.GetKeyValue(0);
                grdLookUpExpenseAccount.EditValue = grdLookUpExpenseAccount.Properties.GetKeyValue(0);
                grdLookUpRevenueAccount.EditValue = grdLookUpRevenueAccount.Properties.GetKeyValue(0);
                grdLookUpBudgetItemID.EditValue = grdLookUpBudgetItemID.Properties.GetKeyValue(0);

                chkIsActive.Checked = true;
            }
        }

        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns></returns>
        protected override bool ValidData()
        {
            //if (cboActivityID.SelectedIndex == 1)
            //{
            //  //  grdLookUpBudgetItemID.Enabled = false;
            //    if ( grdLookUpWaitBudgetSourceID.EditValue == null)
            //    {

            //        XtraMessageBox.Show("Ban chua chon khoan thu",
            //                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        grdLookUpWaitBudgetSourceID.Focus();
            //        return false;
            //    }

            //}
            //if (cboActivityID.SelectedIndex == 2)
            //{
            //    if (grdLookUpWaitBudgetSourceID.EditValue == null)
            //    {
            //        XtraMessageBox.Show("Ban chua chon quy ",
            //               ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        grdLookUpWaitBudgetSourceID.Focus();
            //        return false;
            //    }
            //}
            if (string.IsNullOrEmpty(CapitalAllocateCode))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResEmptyCapitalAllocateCode"),
                             ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCapitalAllocateCode.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(BudgetSourceCode))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResEmptyCapitalAllocateByBudgetSourceCode"),
                             ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                grdLookUpBudgetSourceID.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(FromDate.ToString()))
            {
                XtraMessageBox.Show("Bạn chưa nhập ngày bắt đầu áp dụng chỉ tiêu", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtFromDate.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(ToDate.ToString()))
            {
                XtraMessageBox.Show("Bạn chưa nhập ngày kết thúc áp dụng chỉ tiêu", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtToDate.Focus();

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
            return _capitalAllocatePresenter.Save();
        }

        /// <summary>
        /// Focuses the control.
        /// </summary>
        protected override void InitControls()
        {
            txtCapitalAllocateCode.Focus();
        }

        /// <summary>
        /// Gets or sets the capital allocate identifier.
        /// </summary>
        /// <value>The capital allocate identifier.</value>
        public int CapitalAllocateId { get; set; }

        /// <summary>
        /// Gets or sets the budget item identifier.
        /// </summary>
        /// <value>The budget item identifier.</value>
        public string BudgetItemCode
        {
            get
            {
                var budgetItem = (BudgetItemModel)grdLookUpBudgetItemID.GetSelectedDataRow();
                return budgetItem == null ? null : budgetItem.BudgetItemCode;
            }
            set
            {
                grdLookUpBudgetItemID.EditValue = value;
            }
        }

        /// <summary>
        /// Gets or sets the budget source identifier.
        /// </summary>
        /// <value>The budget source identifier.</value>
        public string BudgetSourceCode
        {
            get
            {
                var budgetSource = (BudgetSourceModel)grdLookUpBudgetSourceID.GetSelectedDataRow();
                return budgetSource == null ? null : budgetSource.BudgetSourceCode;
            }
            set
            {
                grdLookUpBudgetSourceID.EditValue = value;
            }
        }

        /// <summary>
        /// Gets or sets the ActivityId.
        /// </summary>
        /// <value>The ActivityId.</value>
        public int ActivityId
        {
            get { return cboActivityID.SelectedIndex; }
            set { cboActivityID.SelectedIndex = value; }
        }

        /// <summary>
        /// Gets or sets the allocate percent.
        /// </summary>
        /// <value>The allocate percent.</value>
        public short AllocatePercent
        {
            get { return short.Parse(txtAllocatePercent.Text); }
            set { txtAllocatePercent.Text = value.ToString(CultureInfo.InvariantCulture); }
        }

        /// <summary>
        /// Gets or sets the type of the allocate.
        /// </summary>
        /// <value>The type of the allocate.</value>
        public short AllocateType
        {
            get
            { //thứ tự 1 - 2 - 3
                return (short)(cboAllocateType.SelectedIndex + 1);
            }
            set
            {
                cboAllocateType.SelectedIndex = value - 1;
            }
        }

        /// <summary>
        /// Gets or sets the determined date.
        /// </summary>
        /// <value>The determined date.</value>
        public string DeterminedDate
        {
            get { return dateDetermine.EditValue == null ? null : dateDetermine.EditValue.ToString(); }
            set { dateDetermine.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the capital account.
        /// </summary>
        /// <value>The capital account.</value>
        public string CapitalAccountCode
        {
            get
            {
                var account = (AccountModel)grdLookUpCapitalAccount.GetSelectedDataRow();
                return account == null ? null : account.AccountCode;
            }
            set
            {
                grdLookUpCapitalAccount.EditValue = value;
            }
        }

        /// <summary>
        /// Gets or sets the revenue account.
        /// </summary>
        /// <value>The revenue account.</value>
        public string RevenueAccountCode
        {
            get
            {
                var account = (AccountModel)grdLookUpRevenueAccount.GetSelectedDataRow();
                return account == null ? null : account.AccountCode;
            }
            set
            {
                grdLookUpRevenueAccount.EditValue = value;
            }
        }

        /// <summary>
        /// Gets or sets the expense account.
        /// </summary>
        /// <value>The expense account.</value>
        public string ExpenseAccountCode
        {
            get
            {
                var account = (AccountModel)grdLookUpExpenseAccount.GetSelectedDataRow();
                return account == null ? null : account.AccountCode;
            }
            set
            {
                grdLookUpExpenseAccount.EditValue = value;
            }
        }

        /// <summary> 
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description
        {
            get { return txtDescription.Text; }
            set { txtDescription.Text = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        public bool IsActive
        {
            get { return chkIsActive.Checked; }
            set { chkIsActive.Checked = value; }
        }

        /// <summary>
        /// Gets or sets the wait budget source identifier.
        /// </summary>
        /// <value>The wait budget source identifier.</value>
        public string WaitBudgetSourceCode
        {
            get
            {
                var budgetSource = (BudgetSourceModel)grdLookUpWaitBudgetSourceID.GetSelectedDataRow();
                return budgetSource == null ? null : budgetSource.BudgetSourceCode;
            }
            set
            {
                grdLookUpWaitBudgetSourceID.EditValue = value;
            }
        }

        /// <summary>
        /// Gets or sets the capital allocate code.
        /// </summary>
        /// <value>The capital allocate code.</value>
        public string CapitalAllocateCode
        {
            get { return txtCapitalAllocateCode.Text; }
            set { txtCapitalAllocateCode.Text = value; }
        }

        /// <summary>
        /// Sets the accounts.
        /// </summary>
        /// <value>The accounts.</value>
        public IList<Model.BusinessObjects.Dictionary.AccountModel> Accounts
        {
            set
            {
                GridLookUpItem.Account(value, grdLookUpCapitalAccount, grdLookUpCapitalAccountView, "AccountCode", "AccountCode");
                GridLookUpItem.Account(value, grdLookUpRevenueAccount, grdLookUpRevenueAccountView, "AccountCode", "AccountCode");
                GridLookUpItem.Account(value, grdLookUpExpenseAccount, grdLookUpExpenseAccountView, "AccountCode", "AccountCode");

                //grdLookUpCapitalAccount.Properties.DataSource = value;
                //grdLookUpRevenueAccount.Properties.DataSource = value;
                //grdLookUpCapitalAccount.Properties.PopulateColumns();
                //grdLookUpRevenueAccount.Properties.PopulateColumns();

                //grdLookUpExpenseAccount.Properties.DataSource = value;
                //grdLookUpExpenseAccount.Properties.PopulateColumns();
                //var gridColumnsCollection = new List<XtraColumn>
                //    {
                //       new XtraColumn { ColumnName = "AccountId", ColumnVisible = false },
                //        new XtraColumn { ColumnName = "AccountCode", ColumnCaption = "Mã tài khoản", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 100 },
                //        new XtraColumn { ColumnName = "AccountCategoryId", ColumnVisible = false },
                //        new XtraColumn { ColumnName = "AccountName", ColumnCaption = "Tên tài khoản", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 300 },
                //        new XtraColumn { ColumnName = "Description", ColumnVisible = false },
                //        new XtraColumn { ColumnName = "IsActive", ColumnVisible = false },
                //        new XtraColumn { ColumnName = "ForeignName", ColumnVisible = false },
                //        new XtraColumn { ColumnName = "Grade", ColumnVisible = false },
                //        new XtraColumn { ColumnName = "IsDetail", ColumnVisible = false },
                //        new XtraColumn { ColumnName = "BalanceSide", ColumnVisible = false }, //  Balanceside
                //        new XtraColumn { ColumnName = "ConcomitantAccount", ColumnVisible = false },
                //        new XtraColumn { ColumnName = "BankId", ColumnVisible = false },
                //        new XtraColumn { ColumnName = "IsChapter", ColumnVisible = false },
                //        new XtraColumn { ColumnName = "IsBudgetCategory", ColumnVisible = false },
                //        new XtraColumn { ColumnName = "IsBudgetItem", ColumnVisible = false },
                //        new XtraColumn { ColumnName = "IsBudgetGroup", ColumnVisible = false },
                //        new XtraColumn { ColumnName = "IsBudgetSource", ColumnVisible = false },
                //        new XtraColumn { ColumnName = "IsActivity", ColumnVisible = false },
                //        new XtraColumn { ColumnName = "IsCurrency", ColumnVisible = false },
                //        new XtraColumn { ColumnName = "IsCustomer", ColumnVisible = false },
                //        new XtraColumn { ColumnName = "IsVendor", ColumnVisible = false },
                //        new XtraColumn { ColumnName = "IsEmployee", ColumnVisible = false },
                //        new XtraColumn { ColumnName = "IsAccountingObject", ColumnVisible = false },
                //        new XtraColumn { ColumnName = "IsInventoryItem", ColumnVisible = false },
                //        new XtraColumn { ColumnName = "IsFixedAsset", ColumnVisible = false },
                //        new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false },
                //        new XtraColumn { ColumnName = "IsCapitalAllocate", ColumnVisible = false },
                //        new XtraColumn { ColumnName = "IsAllowinputcts", ColumnVisible = false },
                //        new XtraColumn { ColumnName = "CurrencyCode", ColumnVisible = false },
                //        new XtraColumn { ColumnName = "IsProject", ColumnVisible = false },

                //        new XtraColumn { ColumnName = "ParentId", ColumnVisible = false }
                //    };

                //foreach (var column in gridColumnsCollection)
                //{
                //    if (column.ColumnVisible)
                //    {
                //        grdLookUpCapitalAccount.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                //        grdLookUpCapitalAccount.Properties.SortColumnIndex = column.ColumnPosition;
                //        grdLookUpCapitalAccount.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                //        grdLookUpRevenueAccount.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                //        grdLookUpRevenueAccount.Properties.SortColumnIndex = column.ColumnPosition;
                //        grdLookUpRevenueAccount.Properties.Columns[column.ColumnName].Width = column.ColumnWith;

                //        grdLookUpExpenseAccount.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                //        grdLookUpExpenseAccount.Properties.SortColumnIndex = column.ColumnPosition;
                //        grdLookUpExpenseAccount.Properties.Columns[column.ColumnName].Width = column.ColumnWith;
                //    }
                //    else
                //    {
                //        grdLookUpCapitalAccount.Properties.Columns[column.ColumnName].Visible = false;
                //        grdLookUpRevenueAccount.Properties.Columns[column.ColumnName].Visible = false;
                //        grdLookUpExpenseAccount.Properties.Columns[column.ColumnName].Visible = false;
                //    }
                //}
                //grdLookUpCapitalAccount.Properties.DisplayMember = "AccountCode";
                //grdLookUpCapitalAccount.Properties.ValueMember = "AccountCode";
                //grdLookUpRevenueAccount.Properties.DisplayMember = "AccountCode";
                //grdLookUpRevenueAccount.Properties.ValueMember = "AccountCode";

                //grdLookUpExpenseAccount.Properties.DisplayMember = "AccountCode";
                //grdLookUpExpenseAccount.Properties.ValueMember = "AccountCode";


            }
        }

        /// <summary>
        /// Sets the BudgetItems.
        /// </summary>
        /// <value>The BudgetItems.</value>
        public IList<Model.BusinessObjects.Dictionary.BudgetItemModel> BudgetItems
        {
            set
            {
                //var budgetGroupId = value == null ? null : value.Where(c => (c.BudgetItemType == 1 || c.BudgetItemType == 2)).ToList();
                var budgetItemId = value == null ? null : value.Where(c => (c.BudgetItemType == 3 || c.BudgetItemType == 4)).ToList();

                //GridLookUpItem.BudgetItem(budgetGroupId, grdLookUpBudgetItemID, grdLookUpBudgetItemView, "BudgetItemCode", "BudgetItemId");
                GridLookUpItem.BudgetItem(budgetItemId, grdLookUpBudgetItemID, grdLookUpBudgetItemView, "BudgetItemCode", "BudgetItemCode");
            }
        }

        /// <summary>
        /// Sets the budget sources.
        /// </summary>
        /// <value>The budget sources.</value>
        public IList<Model.BusinessObjects.Dictionary.BudgetSourceModel> BudgetSources
        {
            set
            {
                if (value == null) return;

                GridLookUpItem.BudgetSource(value, grdLookUpBudgetSourceID, grdLookUpBudgetSourceView, "BudgetSourceCode", "BudgetSourceCode");
                GridLookUpItem.BudgetSource(value, grdLookUpWaitBudgetSourceID, grdLookUpWaitBudgetSourceView, "BudgetSourceCode", "BudgetSourceCode");
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cboActivityId control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void cboActivityId_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetStateControl();
        }

        /// <summary>
        /// Sets the state control.
        /// </summary>
        private void SetStateControl()
        {
            if (cboActivityID.SelectedIndex == 1)
            {
                grdLookUpBudgetItemID.Enabled = false;
                grdLookUpWaitBudgetSourceID.Enabled = true;
                //grdLookUpWaitBudgetSourceID.EditValue = grdLookUpWaitBudgetSourceID.Properties.GetDataSourceValue(grdLookUpWaitBudgetSourceID.Properties.ValueMember, 0);
                grdLookUpWaitBudgetSourceID.EditValue = grdLookUpWaitBudgetSourceID.Properties.GetKeyValue(0);
                grdLookUpBudgetItemID.EditValue = null;

            }
            else
            {
                grdLookUpBudgetItemID.Enabled = true;
                //grdLookUpBudgetItemID.EditValue = grdLookUpBudgetItemID.Properties.GetDataSourceValue(grdLookUpBudgetItemID.Properties.ValueMember, 0);
                grdLookUpBudgetItemID.EditValue = grdLookUpBudgetItemID.Properties.GetKeyValue(0);
                grdLookUpWaitBudgetSourceID.Enabled = false;
                grdLookUpWaitBudgetSourceID.EditValue = null;

            }
        }

        public DateTime FromDate
        {
            get { return (DateTime)dtFromDate.EditValue; } // == null ? null : (DateTime)dtFromDate.EditValue); }
            set { dtFromDate.EditValue = value; }
        }

        public DateTime ToDate
        {
            get { return (DateTime)dtToDate.EditValue; }// == null ? null :
            //  dtToDate.EditValue; }
            set { dtToDate.EditValue = value; }
        }

        private void grdLookUpExpenseAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdLookUpExpenseAccount.SelectionLength == grdLookUpExpenseAccount.Text.Length && (e.KeyData == Keys.Back || e.KeyData == Keys.Delete))
            {
                grdLookUpExpenseAccount.EditValue = null;
                e.Handled = true;
            }
        }

        private void grdLookUpCapitalAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdLookUpCapitalAccount.SelectionLength == grdLookUpCapitalAccount.Text.Length && (e.KeyData == Keys.Back || e.KeyData == Keys.Delete))
            {
                grdLookUpCapitalAccount.EditValue = null;
                e.Handled = true;
            }
        }

        private void grdLookUpRevenueAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdLookUpRevenueAccount.SelectionLength == grdLookUpRevenueAccount.Text.Length && (e.KeyData == Keys.Back || e.KeyData == Keys.Delete))
            {
                grdLookUpRevenueAccount.EditValue = null;
                e.Handled = true;
            }
        }

        private void grdLookUpWaitBudgetSourceID_KeyDown(object sender, KeyEventArgs e)
        {
            //if (grdLookUpWaitBudgetSourceID.SelectionLength == grdLookUpWaitBudgetSourceID.Text.Length && (e.KeyData == Keys.Back || e.KeyData == Keys.Delete))
            //{
            //    grdLookUpWaitBudgetSourceID.EditValue = null;
            //    e.Handled = true;
            //}
        }

        private void grdLookUpBudgetItemID_KeyDown(object sender, KeyEventArgs e)
        {
            //    if (grdLookUpBudgetItemID.SelectionLength == grdLookUpBudgetItemID.Text.Length && (e.KeyData == Keys.Back || e.KeyData == Keys.Delete))
            //    {
            //        grdLookUpBudgetItemID.EditValue = null;
            //        e.Handled = true;
            //    } 

        }

        private void grdLookUpBudgetSourceID_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdLookUpBudgetSourceID.SelectionLength == grdLookUpBudgetSourceID.Text.Length && (e.KeyData == Keys.Back || e.KeyData == Keys.Delete))
            {
                grdLookUpBudgetSourceID.EditValue = null;
                e.Handled = true;
            }
        }

        private void grdLookUpBudgetItemID_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
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

                            var lstBudgetItem = (List<BudgetItemModel>)grdLookUpBudgetItemID.Properties.DataSource;
                            if (lstBudgetItem != null && lstBudgetItem.Count > 0)
                                BudgetItemCode = lstBudgetItem.OrderByDescending(o => o.BudgetItemId).FirstOrDefault().BudgetItemCode;
                        }
                    }
                }
            }
        }

        private void grdLookUpWaitBudgetSourceID_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
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

                            var lstBudgetSource = (List<BudgetSourceModel>)grdLookUpWaitBudgetSourceID.Properties.DataSource;
                            if (lstBudgetSource != null && lstBudgetSource.Count > 0)
                                WaitBudgetSourceCode = lstBudgetSource.OrderByDescending(o => o.BudgetSourceId).FirstOrDefault().BudgetSourceCode;
                        }
                    }
                }
            }
        }

        private void grdLookUpBudgetSourceID_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
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

                            var lstBudgetSource = (List<BudgetSourceModel>)grdLookUpBudgetSourceID.Properties.DataSource;
                            if (lstBudgetSource != null && lstBudgetSource.Count > 0)
                                BudgetSourceCode = lstBudgetSource.OrderByDescending(o => o.BudgetSourceId).FirstOrDefault().BudgetSourceCode;
                        }
                    }
                }
            }
        }
    }
}
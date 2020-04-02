/***********************************************************************
 * <copyright file="FrmXtraFixedAssetCategoryTreeDetail.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Wednesday, February 26, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Presenter.Dictionary.Account;
using TSD.AccountingSoft.Presenter.Dictionary.FixedAsset;
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
    /// <summary>
    /// FixedAsset Category detail form
    /// </summary>
    public partial class FrmXtraFixedAssetCategoryTreeDetail : FrmXtraBaseTreeDetail, IFixedAssetCategoryView, IFixedAssetCategoriesView, IAccountsView
    {
        /// <summary>
        /// The _fixed asset category presenter
        /// </summary>
        private readonly FixedAssetCategoryPresenter _fixedAssetCategoryPresenter;

        /// <summary>
        /// The _fixed asset categories presenter
        /// </summary>
        private readonly FixedAssetCategoriesPresenter _fixedAssetCategoriesPresenter;

        /// <summary>
        /// The _accounts presenter
        /// </summary>
        private readonly AccountsPresenter _accountsPresenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmXtraFixedAssetCategoryTreeDetail" /> class.
        /// </summary>
        public FrmXtraFixedAssetCategoryTreeDetail()
        {
            InitializeComponent();
            _fixedAssetCategoryPresenter = new FixedAssetCategoryPresenter(this);
            _fixedAssetCategoriesPresenter = new FixedAssetCategoriesPresenter(this);
            _accountsPresenter = new AccountsPresenter(this);
        }

        #region IFixedAssetCategoryView Members

        /// <summary>
        /// Gets or sets the fixed asset category identifier.
        /// </summary>
        /// <value>
        /// The fixed asset category identifier.
        /// </value>
        public int FixedAssetCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the parent identifier.
        /// </summary>
        /// <value>
        /// The parent identifier.
        /// </value>
        public int? ParentId
        {
            get
            {
                if (grdLookUpFixedAssetCategory.EditValue == null) return null;
                return (int)grdLookUpFixedAssetCategory.EditValue;
            }
            set
            {
                grdLookUpFixedAssetCategory.EditValue = value;
            }
        }

        /// <summary>
        /// Gets or sets the fixed asset category code.
        /// </summary>
        /// <value>
        /// The fixed asset category code.
        /// </value>
        public string FixedAssetCategoryCode
        {
            get { return txtFixedAssetCategoryCode.Text; }
            set { txtFixedAssetCategoryCode.Text = value; }
        }

        /// <summary>
        /// Gets or sets the name of the fixed asset category.
        /// </summary>
        /// <value>
        /// The name of the fixed asset category.
        /// </value>
        public string FixedAssetCategoryName
        {
            get
            {
                return txtFixedAssetCategoryName.Text;
            }
            set
            {
                txtFixedAssetCategoryName.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets the fixed asset category name en.
        /// </summary>
        /// <value>
        /// The fixed asset category name en.
        /// </value>
        public string FixedAssetCategoryForeignName { get; set; }

        /// <summary>
        /// Gets or sets the depreciation rate.
        /// </summary>
        /// <value>
        /// The depreciation rate.
        /// </value>
        public decimal DepreciationRate
        {
            get
            {
                return txtDepreciationRate.Value;
            }
            set
            {
                txtDepreciationRate.Value = value;
            }
        }

        /// <summary>
        /// Gets or sets the life time.
        /// </summary>
        /// <value>
        /// The life time.
        /// </value>
        public decimal LifeTime
        {
            get
            {
                return txtLifeTime.Value;
            }
            set
            {
                txtLifeTime.Value = value;
            }
        }

        /// <summary>
        /// Gets or sets the grade.
        /// </summary>
        /// <value>
        /// The grade.
        /// </value>
        public int Grade { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is parent].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is parent]; otherwise, <c>false</c>.
        /// </value>
        public bool IsParent { get; set; }

        /// <summary>
        /// Gets or sets the org price account.
        /// </summary>
        /// <value>
        /// The org price account.
        /// </value>
        public string OrgPriceAccountCode
        {
            get
            {
                if (grdLookUpOrgPriceAccount.EditValue == null) return null;
                return (string)grdLookUpOrgPriceAccount.EditValue;//.GetColumnValue("AccountCode");
            }
            set
            {
                grdLookUpOrgPriceAccount.EditValue = value;
            }
        }

        /// <summary>
        /// Gets or sets the depreciation account.
        /// </summary>
        /// <value>
        /// The depreciation account.
        /// </value>
        public string DepreciationAccountCode
        {
            get
            {
                if (grdLookUpDepreciationAccount.EditValue == null) return null;
                return (string)grdLookUpDepreciationAccount.EditValue;// GetColumnValue("AccountCode");
            }
            set
            {
                grdLookUpDepreciationAccount.EditValue = value;
            }
        }

        /// <summary>
        /// Gets or sets the capital account.
        /// </summary>
        /// <value>
        /// The capital account.
        /// </value>
        public string CapitalAccountCode
        {
            get
            {
                if (grdLookUpCapitalAccount.EditValue == null) return null;
                return (string)grdLookUpCapitalAccount.EditValue;// GetColumnValue("AccountCode");
            }
            set
            {
                grdLookUpCapitalAccount.EditValue = value;
            }
        }

        /// <summary>
        /// Gets or sets the chapter code.
        /// </summary>
        /// <value>
        /// The chapter code.
        /// </value>
        public string BudgetChapterCode { get; set; }

        /// <summary>
        /// Gets or sets the budget category code.
        /// </summary>
        /// <value>
        /// The budget category code.
        /// </value>
        public string BudgetCategoryCode { get; set; }

        /// <summary>
        /// Gets or sets the budget group code.
        /// </summary>
        /// <value>
        /// The budget group code.
        /// </value>
        public string BudgetGroupCode { get; set; }

        /// <summary>
        /// Gets or sets the budget item code.
        /// </summary>
        /// <value>
        /// The budget item code.
        /// </value>
        public string BudgetItemCode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [in active].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [in active]; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive
        {
            get
            {
                return chkInactive.Checked;
            }
            set
            {
                chkInactive.Checked = value;
            }
        }

        public string Unit
        {
            get
            {
                return txtUnit.Text;
            }
            set
            {
                txtUnit.EditValue = value;
            }
        }


        #endregion

        #region Combobox

        /// <summary>
        /// Sets the fixed asset categorys.
        /// </summary>
        /// <value>
        /// The fixed asset categorys.
        /// </value>
        public IList<FixedAssetCategoryModel> FixedAssetCategories
        {
            set
            {
                GridLookUpItem.FixedAssetCategory(value ?? new List<FixedAssetCategoryModel>(), grdLookUpFixedAssetCategory, grdLookUpFixedAssetCategoryView, "FixedAssetCategoryCode", KeyFieldName);
            }
        }

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
                GridLookUpItem.Account(value == null ? new List<AccountModel>() : value.Where(c => c.AccountCode == "36611" || c.AccountCode == "36631").ToList(), grdLookUpCapitalAccount, grdLookUpCapitalAccountView, "AccountCode", "AccountCode");
                GridLookUpItem.Account(value == null ? new List<AccountModel>() : value.Where(c => c.AccountCode.StartsWith("214")).ToList(), grdLookUpDepreciationAccount, grdLookUpDepreciationAccountView, "AccountCode", "AccountCode");
                GridLookUpItem.Account(value == null ? new List<AccountModel>() : value.Where(c => c.AccountCode.StartsWith("211") || c.AccountCode.StartsWith("213")).ToList(), grdLookUpOrgPriceAccount, grdLookUpOrgPriceAccountView, "AccountCode", "AccountCode");
            }
        }

        #endregion

        #region Override Methods

        /// <summary>
        /// Initializes the data.
        /// </summary>
        protected override void InitData()
        {
            _fixedAssetCategoriesPresenter.DisplayActive();
            _accountsPresenter.DisplayActive();
            if (KeyValue != null)
            {
                _fixedAssetCategoryPresenter.Display(KeyValue);
            }
            else
            {
                _fixedAssetCategoriesPresenter.DisplayActive();
                if (CurrentNode != null)
                {
                    txtFixedAssetCategoryCode.Text = ((FixedAssetCategoryModel)CurrentNode).FixedAssetCategoryCode;
                    txtFixedAssetCategoryName.Text = ((FixedAssetCategoryModel)CurrentNode).FixedAssetCategoryName;
                    grdLookUpFixedAssetCategory.EditValue = ((FixedAssetCategoryModel)CurrentNode).FixedAssetCategoryId;
                }
                CapitalAccountCode = "36611";
            }
        }

        /// <summary>
        /// Focuses the control.
        /// </summary>
        protected override void InitControls()
        {
            txtFixedAssetCategoryCode.Focus();
            if ((ActionMode == ActionModeEnum.Edit) && HasChildren) grdLookUpFixedAssetCategory.Properties.ReadOnly = true;
            else grdLookUpFixedAssetCategory.Properties.ReadOnly = false;
        }

        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns></returns>
        protected override bool ValidData()
        {
            if (string.IsNullOrEmpty(FixedAssetCategoryCode))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResAccountCode"),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFixedAssetCategoryCode.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(FixedAssetCategoryName))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResAccountName"),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFixedAssetCategoryName.Focus();
                return false;
            }
            if (grdLookUpFixedAssetCategory.Text == txtFixedAssetCategoryCode.Text)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResCodeSameAsParentError"),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                grdLookUpFixedAssetCategory.Focus();
                return false;
            }

            if (ActionMode == ActionModeEnum.AddNew && CheckCodeExisted())
            {
                XtraMessageBox.Show(string.Format(ResourceHelper.GetResourceValueByName("ResFixedAssetCategoryAlreadyExists"), FixedAssetCategoryCode), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFixedAssetCategoryCode.Focus();
                return false;
            }
            
            return true;
        }

        /// <summary>
        /// Checks the code existed.
        /// </summary>
        /// <returns></returns>
        private bool CheckCodeExisted()
        {
            var listFixedAssetCategories = _fixedAssetCategoriesPresenter.GetAllFixedAssetCategories();
            if (listFixedAssetCategories.Count>0)
            {
                foreach (var fixedAssetCategoryModel in listFixedAssetCategories)
                {
                    if (fixedAssetCategoryModel.FixedAssetCategoryCode == FixedAssetCategoryCode)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Saves the data.
        /// </summary>
        /// <returns></returns>
        protected override int SaveData()
        {
            int i;
            try
            {
                i = _fixedAssetCategoryPresenter.Save();
            }
            catch (Exception ex)
            {
                i = 0;
                if (ex.Message.Contains("IX_FixedAssetCategory_FixedAssetCategoryCode"))
                {
                    XtraMessageBox.Show(string.Format(ResourceHelper.GetResourceValueByName("ResFixedAssetCategoryAlreadyExists"), FixedAssetCategoryCode), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtFixedAssetCategoryCode.Focus();
                }
                else
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return i;
        }

        #endregion

        /// <summary>
        /// Handles the KeyDown event of the grdLookUpFixedAssetCategory control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void grdLookUpFixedAssetCategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdLookUpFixedAssetCategory.SelectionLength == grdLookUpFixedAssetCategory.Text.Length && (e.KeyData == Keys.Back || e.KeyData == Keys.Delete))
            {
                grdLookUpFixedAssetCategory.EditValue = null;
                e.Handled = true;
            }
        }

        private void grdLookUpOrgPriceAccount_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

            if(e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)
            {
                using (var frmDetail = new FrmXtraAccountDetail())
                {
                    frmDetail.ActionMode = ActionModeEnum.AddNew;
                    if(frmDetail.ShowDialog() == DialogResult.OK)
                    {
                        _accountsPresenter.DisplayActive();

                        var lstDetails = grdLookUpOrgPriceAccount.Properties.DataSource as List<AccountModel>;
                        if(lstDetails != null)
                        {
                            grdLookUpOrgPriceAccount.EditValue = lstDetails.OrderByDescending(o => o.AccountId).FirstOrDefault().AccountCode;
                        }
                    }
                }
            }
        }

        private void grdLookUpDepreciationAccount_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)
            {
                using (var frmDetail = new FrmXtraAccountDetail())
                {
                    frmDetail.ActionMode = ActionModeEnum.AddNew;
                    if (frmDetail.ShowDialog() == DialogResult.OK)
                    {
                        _accountsPresenter.DisplayActive();

                        var lstDetails = grdLookUpDepreciationAccount.Properties.DataSource as List<AccountModel>;
                        if (lstDetails != null)
                        {
                            grdLookUpDepreciationAccount.EditValue = lstDetails.OrderByDescending(o => o.AccountId).FirstOrDefault().AccountCode;
                        }
                    }
                }
            }
        }

        private void grdLookUpCapitalAccount_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)
            {
                using (var frmDetail = new FrmXtraAccountDetail())
                {
                    frmDetail.ActionMode = ActionModeEnum.AddNew;
                    if (frmDetail.ShowDialog() == DialogResult.OK)
                    {
                        _accountsPresenter.DisplayActive();

                        var lstDetails = grdLookUpCapitalAccount.Properties.DataSource as List<AccountModel>;
                        if (lstDetails != null)
                        {
                            grdLookUpCapitalAccount.EditValue = lstDetails.OrderByDescending(o => o.AccountId).FirstOrDefault().AccountCode;
                        }
                    }
                }
            }
        }
    }
}
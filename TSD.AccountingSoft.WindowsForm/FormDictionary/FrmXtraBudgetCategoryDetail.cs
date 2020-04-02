/***********************************************************************
 * <copyright file="FrmXtraBudgetCategoryDetail.cs" company="BUCA JSC">
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
using System.Windows.Forms;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Presenter.Dictionary.BudgetCategory;
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
    /// Class FrmXtraBudgetCategoryDetail.
    /// </summary>
    public partial class FrmXtraBudgetCategoryDetail : FrmXtraBaseTreeDetail, IBudgetCategoryView, IBudgetCategoriesView
    {
        /// <summary>
        /// The _budget category presenter
        /// </summary>
        private readonly BudgetCategoryPresenter _budgetCategoryPresenter;

        /// <summary>
        /// The _budget categorys presenter
        /// </summary>
        private readonly BudgetCategoriesPresenter _budgetCategoriesPresenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmXtraBudgetCategoryDetail"/> class.
        /// </summary>
        public FrmXtraBudgetCategoryDetail()
        {
            InitializeComponent();
            _budgetCategoryPresenter = new BudgetCategoryPresenter(this);
            _budgetCategoriesPresenter = new BudgetCategoriesPresenter(this);
        }

        #region IBudgetCategoriesView Members

        /// <summary>
        /// Sets the budget categories.
        /// </summary>
        /// <value>The budget categories.</value>
        public IList<BudgetCategoryModel> BudgetCategories
        {
            set
            {
                GridLookUpItem.BudgetCategory(value, grdLockUpParentID, grdLockUpParentView, "BudgetCategoryCode", "BudgetCategoryId");
            }
        }

        #endregion

        #region IBudgetCategoryView Members

        /// <summary>
        /// Gets or sets the budgetCategory identifier.
        /// </summary>
        /// <value>The budgetCategory identifier.</value>
        public int BudgetCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the budgetCategory code.
        /// </summary>
        /// <value>The budgetCategory code.</value>
        public string BudgetCategoryCode
        {
            get { return txtBudgetCategoryCode.Text; }
            set { txtBudgetCategoryCode.Text = value; }
        }

        /// <summary>
        /// Gets or sets the name of the budgetCategory.
        /// </summary>
        /// <value>The name of the budgetCategory.</value>
        public string BudgetCategoryName
        {
            get { return txtBudgetCategoryName.Text; }
            set { txtBudgetCategoryName.Text = value; }
        }

        /// <summary>
        /// Gets or sets the parent identifier.
        /// </summary>
        /// <value>The parent identifier.</value>
        public int? ParentId
        {
            get
            {
                var parent = (BudgetCategoryModel)grdLockUpParentID.GetSelectedDataRow();
                return parent == null ? null : parent.ParentId;
            }
            set
            {
                grdLockUpParentID.EditValue = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is system.
        /// </summary>
        /// <value><c>true</c> if this instance is system; otherwise, <c>false</c>.</value>
        public bool IsParent { get; set; }

        /// <summary>
        /// Gets or sets the is system.
        /// </summary>
        /// <value>The is system.</value>
        public bool IsSystem { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is active].
        /// </summary>
        /// <value><c>true</c> if [is active]; otherwise, <c>false</c>.</value>
        public bool IsActive
        {
            get { return chkIsActive.Checked; }
            set { chkIsActive.Checked = value; }
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description
        {
            get { return memoDescription.Text; }
            set { memoDescription.Text = value; }
        }

        /// <summary>
        /// Gets or sets the grade.
        /// </summary>
        /// <value>The grade.</value>
        public int Grade { get; set; }

        /// <summary>
        /// Gets or sets the name of the foreign.
        /// </summary>
        /// <value>The name of the foreign.</value>
        public string ForeignName { get; set; }

        #endregion

        /// <summary>
        /// Initializes the data.
        /// </summary>
        protected override void InitData()
        {
            _budgetCategoriesPresenter.Display();
            if (KeyValue == null) return;
            _budgetCategoryPresenter.Display(KeyValue);
        }

        /// <summary>
        /// Focuses the control.
        /// </summary>
        protected override void InitControls()
        {
            txtBudgetCategoryCode.Focus();
            grdLockUpParentID.Properties.ReadOnly = (ActionMode == ActionModeEnum.Edit) && HasChildren;
        }

        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        protected override bool ValidData()
        {
            var listBudgetCategory = _budgetCategoriesPresenter.GetBudgetCategories();
            foreach (var budgetCategoryModel in listBudgetCategory)
            {
                // option Edit
                if (BudgetCategoryId > 0)
                {
                    if (budgetCategoryModel.BudgetCategoryId == BudgetCategoryId) continue;
                    if (budgetCategoryModel.BudgetCategoryCode != BudgetCategoryCode) continue;
                    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResCheckBudgetCategoriesCode"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtBudgetCategoryCode.Focus();
                    return false;
                }
                if (budgetCategoryModel.BudgetCategoryCode != BudgetCategoryCode) continue;
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResCheckBudgetCategoriesCode"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBudgetCategoryCode.Focus();
                return false;
            }
            if (!string.IsNullOrEmpty(BudgetCategoryCode))
            {
                if (string.IsNullOrEmpty(BudgetCategoryName))
                {
                    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResBudgetCategoryName"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtBudgetCategoryName.Focus();
                    return false;
                }
                if (BudgetCategoryCode == grdLockUpParentID.Text)
                {
                    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResCodeSameAsParentError"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    grdLockUpParentID.Focus();
                    return false;
                }
                return true;
            }
            XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResBudgetCategoryCode"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            txtBudgetCategoryCode.Focus();
            return false;
        }

        /// <summary>
        /// Saves the data.
        /// </summary>
        /// <returns>System.Int32.</returns>
        protected override int SaveData()
        {
            return _budgetCategoryPresenter.Save();
        }

        /// <summary>
        /// Handles the KeyDown event of the grdLockUpParentID control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void grdLockUpParentID_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdLockUpParentID.SelectionLength != grdLockUpParentID.Text.Length ||
                (e.KeyData != Keys.Back && e.KeyData != Keys.Delete)) return;
            grdLockUpParentID.EditValue = null;
            e.Handled = true;
        }
    }
}

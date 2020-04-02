/***********************************************************************
 * <copyright file="FrmXtraAccountCategoryDetail.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   BangNC
 * Email:    BangNC@buca.vn
 * Website:
 * Create Date: Thursday, March 13, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using System.Windows.Forms;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.Enum;
using DevExpress.XtraEditors;
using TSD.AccountingSoft.Presenter.Dictionary.AccountCategory;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.Resources;


namespace TSD.AccountingSoft.WindowsForm.FormDictionary
{
    /// <summary>
    /// Class FrmXtraAccountCategoryDetail.
    /// </summary>
    public partial class FrmXtraAccountCategoryDetail : FrmXtraBaseTreeDetail, IAccountCategoriesView,
                                                        IAccountCategoryView
    {
        private readonly AccountCategoryPresenter _accountCategoryPresenter;
        private readonly AccountCategoriesPresenter _accountCategoriesPresenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmXtraAccountCategoryDetail"/> class.
        /// </summary>
        public FrmXtraAccountCategoryDetail()
        {
            InitializeComponent();
            _accountCategoryPresenter = new AccountCategoryPresenter(this);
            _accountCategoriesPresenter = new AccountCategoriesPresenter(this);

        }

        #region IAccountCategorysView Members

        /// <summary>
        /// Sets the AccountCategories.
        /// </summary>
        /// <value>The AccountCategories.</value>
        public IList<AccountCategoryModel> AccountCategories
        {
            set
            {
                grdLockUpParentID.Properties.DataSource = value;
                grdLockUpParentID.Properties.PopulateColumns();
                var treeColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn
                            {
                                ColumnName = "AccountCategoryId",
                                ColumnCaption = "Mã nhóm tài khoản",
                                ColumnVisible = false
                            },
                        new XtraColumn
                            {
                                ColumnName = "AccountCategoryCode",
                                ColumnCaption = "Mã nhóm TK",
                                ColumnPosition = 1,
                                ColumnVisible = true
                            },
                        new XtraColumn
                            {
                                ColumnName = "AccountCategoryName",
                                ColumnCaption = "Tên nhóm TK",
                                ColumnPosition = 2,
                                ColumnVisible = true
                            },
                        new XtraColumn
                            {
                                ColumnName = "ForeignName",
                                ColumnCaption = "Tên nhóm tài khoản",
                                ColumnVisible = false
                            },
                        new XtraColumn
                            {
                                ColumnName = "ParentId",
                                ColumnCaption = "Nhóm tài khoản cha",
                                ColumnVisible = false
                            },
                        new XtraColumn
                            {
                                ColumnName = "Grade",
                                ColumnCaption = "",
                                ColumnVisible = false
                            },
                        new XtraColumn
                            {
                                ColumnName = "IsDetail",
                                ColumnCaption = "Chi tiết",
                                ColumnVisible = false
                            },

                        new XtraColumn
                            {
                                ColumnName = "IsActive",
                                ColumnPosition = 3,
                                ColumnCaption = "Được sử dụng",
                                ColumnVisible = false
                            }
                    };

                foreach (var column in treeColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        grdLockUpParentID.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        grdLockUpParentID.Properties.SortColumnIndex = column.ColumnPosition;
                    }
                    else
                        grdLockUpParentID.Properties.Columns[column.ColumnName].Visible = false;
                }
                grdLockUpParentID.Properties.DisplayMember = "AccountCategoryCode";
                grdLockUpParentID.Properties.ValueMember = KeyFieldName;
            }
        }

        #endregion

        #region IAccountCategoryView Members

        /// <summary>
        /// Gets or sets the account category identifier.
        /// </summary>
        /// <value>The account category identifier.</value>
        public int AccountCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the account category code.
        /// </summary>
        /// <value>The account category code.</value>
        public string AccountCategoryCode
        {
            get { return txtAccountCode.Text; }
            set { txtAccountCode.Text = value; }
        }

        /// <summary>
        /// Gets or sets the name of the account category.
        /// </summary>
        /// <value>The name of the account category.</value>
        public string AccountCategoryName
        {
            get { return txtAccountName.Text; }
            set { txtAccountName.Text = value; }
        }

        /// <summary>
        /// Gets or sets the name of the foreign.
        /// </summary>
        /// <value>The name of the foreign.</value>
        public string ForeignName { get; set; }

        /// <summary>
        /// Gets or sets the parent identifier.
        /// </summary>
        /// <value>The parent identifier.</value>
        public int ParentId
        {
            get
            {
                if (grdLockUpParentID.EditValue == null) return -1;
                return (int)grdLockUpParentID.GetColumnValue(KeyFieldName);
            }
            set { grdLockUpParentID.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the grade.
        /// </summary>
        /// <value>The grade.</value>
        public int Grade { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is detail.
        /// </summary>
        /// <value><c>true</c> if this instance is detail; otherwise, <c>false</c>.</value>
        public bool IsDetail { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        public bool IsActive
        {
            get { return chkIsActive.Checked; }
            set { chkIsActive.Checked = value; }
        }

        #endregion

        /// <summary>
        /// Initializes the data.
        /// </summary>
        protected override void InitData()
        {
            _accountCategoriesPresenter.DisplayActive();
            if (KeyValue != null)
            {
                _accountCategoryPresenter.Display(KeyValue);
                _accountCategoriesPresenter.DisplayForComboTree(int.Parse(KeyValue));

            }
        }

        /// <summary>
        /// Focuses the control.
        /// </summary>
        protected override void InitControls()
        {
            txtAccountCode.Focus();
            if ((ActionMode == ActionModeEnum.Edit) && HasChildren) 
                grdLockUpParentID.Properties.ReadOnly = true;
            else 
                grdLockUpParentID.Properties.ReadOnly = false;
        }

        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        protected override bool ValidData()
        {
            if (string.IsNullOrEmpty(AccountCategoryCode))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResAccountCode"),
                                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                txtAccountCode.Focus();
                return false;
            }
            IList<AccountCategoryModel> listAccountCategory = _accountCategoriesPresenter.GetAccountCategories();
            foreach (var accountCategoryModel in listAccountCategory)
            {
                // option Edit
                if (AccountCategoryId > 0)
                {
                    if (accountCategoryModel.AccountCategoryId != AccountCategoryId)
                    {
                        if (accountCategoryModel.AccountCategoryCode == AccountCategoryCode)
                        {
                            XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResCheckAccountCode"),
                                                ResourceHelper.GetResourceValueByName("ResDetailContent"),
                                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtAccountName.Focus();
                            return false;
                        }
                    }
                } // option Add New
                else
                {
                    if (accountCategoryModel.AccountCategoryCode == AccountCategoryCode)
                    {
                        XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResCheckAccountCode"),
                                            ResourceHelper.GetResourceValueByName("ResDetailContent"),
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtAccountName.Focus();
                        return false;
                    }
                }
            }
            if (string.IsNullOrEmpty(Name))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResAccountName"),
                                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                txtAccountName.Focus();
                return false;
            }
            if (AccountCategoryCode == grdLockUpParentID.Text)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResCodeSameAsParentError"),
                                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                grdLockUpParentID.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// Saves the data.
        /// </summary>
        /// <returns>System.Int32.</returns>
        protected override int SaveData()
        {
            return _accountCategoryPresenter.Save();
        }

        /// <summary>
        /// Handles the KeyDown event of the grdLockUpParentID control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
        private void grdLockUpParentID_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdLockUpParentID.SelectionLength == grdLockUpParentID.Text.Length &&
                (e.KeyData == Keys.Back || e.KeyData == Keys.Delete))
            {
                grdLockUpParentID.EditValue = null;
                e.Handled = true;
            }
        }
    }

}
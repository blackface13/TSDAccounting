/***********************************************************************
 * <copyright file="UserControlAccountList.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Bangnc
 * Email:    bangnc@buca.vn
 * Website:
 * Create Date: Tuesday, February 11, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Drawing;
using TSD.AccountingSoft.Presenter.Dictionary.Account;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.WindowsForm.BaseUserControls;
using TSD.AccountingSoft.WindowsForm.CommonClass;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.FormDictionary;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;


namespace TSD.AccountingSoft.WindowsForm.UserControl.Dictionary
{
    /// <summary>
    /// class UserControlAccountList
    /// </summary>
    public partial class UserControlAccountList : BaseTreeListUserControl, IAccountsView
    {
        private readonly AccountsPresenter _accountsPresenter;
        private readonly RepositoryItemLookUpEdit _rsBalanceSide;
        /// <summary>
        /// Initializes a new instance of the <see cref="UserControlAccountList"/> class.
        /// </summary>
        public UserControlAccountList()
        {
            InitializeComponent();
            _accountsPresenter = new AccountsPresenter(this);
            _rsBalanceSide = new RepositoryItemLookUpEdit {ShowDropDown = ShowDropDown.Never};
            _rsBalanceSide.Buttons[0].Visible = false;
            // hide button
            VisibleButtonAddNew = false;
            VisibleButtonDelete = false;
        }

        #region IAccountsView Members

        /// <summary>
        /// Sets the accounts.
        /// </summary>
        /// <value>The accounts.</value>
        public IList<Model.BusinessObjects.Dictionary.AccountModel> Accounts
        {
            set
            {
                treeList.DataSource = value;
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountCode", ColumnCaption = "Mã tài khoản", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 100 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountCategoryId", ColumnCaption = "Mã tài khoản", ColumnPosition = 1, ColumnVisible = false, ColumnWith = 100 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountName", ColumnCaption = "Tên tài khoản", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 400 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BalanceSide", ColumnCaption = "Tính chất", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 80, RepositoryControl = _rsBalanceSide, ColumnType = DevExpress.Data.UnboundColumnType.String });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnCaption = "Được sử dụng", ColumnVisible = true, ColumnPosition = 4 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ForeignName", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsDetail", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ConcomitantAccount", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BankId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsChapter", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsBudgetCategory", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsBudgetItem", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsBudgetGroup", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsBudgetSource", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsActivity", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsCurrency", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsCustomer", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsVendor", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsEmployee", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsAccountingObject", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsInventoryItem", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsFixedAsset", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsCapitalAllocate", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CurrencyCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsAllowinputcts", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsProject", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsBank", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsBudgetSubItem", ColumnVisible = false });
            }
        }

        /// <summary>
        /// Loads the data into tree.
        /// </summary>
        protected override void LoadDataIntoTree()
        {
            IList<BalanceSide> dataSource = new List<BalanceSide>();
            dataSource.Add(new BalanceSide(0,"Dư Nợ"));
            dataSource.Add(new BalanceSide(1, "Dư Có"));
            dataSource.Add(new BalanceSide(2, "Lưỡng tính"));
            _rsBalanceSide.DataSource = dataSource;
            _rsBalanceSide.NullText = "";
            _rsBalanceSide.DisplayMember = "Name";
            _rsBalanceSide.ValueMember = "Id";
            _accountsPresenter.Display();
        }

        protected override void RefreshToolbar()
        {
            base.RefreshToolbar();
        }


        /// <summary>
        /// Deletes the tree.
        /// </summary>
        protected override void DeleteTree()
        {
            new AccountPresenter(null).Delete(int.Parse(PrimaryKeyValue));
        }
        #endregion

        /// <summary>
        /// Handles the NodeCellStyle event of the treeList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs"/> instance containing the event data.</param>
        private void treeList_NodeCellStyle(object sender, DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs e)
        {
            e.Appearance.Font = Convert.ToBoolean(e.Node["IsDetail"])
                                  ? new Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, FontStyle.Regular)
                                  : new Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, FontStyle.Bold);
        }

        /// <summary>
        /// Gets the form detail.
        /// </summary>
        /// <returns></returns>
        protected override FrmXtraBaseTreeDetail GetFormDetail()
        {
            return new FrmXtraAccountDetail();
        }
    }
}

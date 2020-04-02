/***********************************************************************
 * <copyright file="UserControlOpeningInventoryEntryList.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 24 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TSD.AccountingSoft.Session;
using TSD.AccountingSoft.Model.BusinessObjects.Opening;
using TSD.AccountingSoft.Presenter.OpeningInventory;
using TSD.AccountingSoft.View.OpeningInventoryEntry;
using TSD.AccountingSoft.WindowsForm.BaseUserControls;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.FormBusiness;
using TSD.AccountingSoft.WindowsForm.Resources;
using DevExpress.Data;
using DevExpress.XtraEditors;


namespace TSD.AccountingSoft.WindowsForm.UserControl.Voucher
{
    /// <summary>
    /// class UserControlOpeningInventoryEntryList 
    /// </summary>
    public partial class UserControlOpeningInventoryList : BaseTreeListUserControl, IOpeningInventoryEntriesView 
    {
        /// <summary>
        /// The _opening account entries presenter
        /// </summary>
        private readonly OpeningInventoryEntriesPresenter _openingInventoryEntriesPresenter;

        /// <summary>
        /// Sets the opening account entries.
        /// </summary>
        /// <value>
        /// The opening account entries.
        /// </value>
        /// <exception cref="System.NotImplementedException"></exception>
        public IList<OpeningInventoryEntryModel> OpeningInventoryEntries  
        {
            set
            {
                treeList.DataSource = value;
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountNumber", ColumnCaption = "Mã tài khoản", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 100 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountName", ColumnCaption = "Tên tài khoản", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 200 });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "AmountOc",
                    ColumnCaption = "Tổng tiền",
                    ColumnPosition = 3,
                    ColumnVisible = true,
                    ColumnWith = 100,
                    ColumnType = UnboundColumnType.Decimal
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "AmountExchange",
                    ColumnCaption = "Tổng tiền quy đổi",
                    ColumnPosition = 4,
                    ColumnVisible = true,
                    ColumnWith = 100,
                    ColumnType = UnboundColumnType.Decimal
                });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefTypeId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "PostedDate", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefNo", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "StockId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "InventoryItemId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "UnitPriceOc", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "UnitPriceExchange", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ExchangeRate", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Quantity", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CurrencyCode", ColumnVisible = false });
            }
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserControlOpeningInventoryList" /> class.
        /// </summary>
        public UserControlOpeningInventoryList()
        {
            InitializeComponent();
            _openingInventoryEntriesPresenter = new OpeningInventoryEntriesPresenter(this);
        }

        /// <summary>
        /// Loads the data into grid.
        /// </summary>
        protected override void LoadDataIntoTree()
        {
            _openingInventoryEntriesPresenter.Display();
        }

        /// <summary>
        /// Shows the form detail.
        /// </summary>
        protected override void ShowFormDetail()
        {
            try
            {
                using (var frmDetail = GetFormDetail())
                {
                    frmDetail.KeyFieldName = TablePrimaryKey;
                    frmDetail.ParentName = ParentFieldName;
                    frmDetail.ActionMode = ActionMode;
                    frmDetail.KeyValue = PrimaryKeyValue;
                    frmDetail.HasChildren = PrimaryKeyValue != null && treeList.FindNodeByKeyID(int.Parse(PrimaryKeyValue)).HasChildren;
                    frmDetail.CurrentNode = treeList.Nodes.Count > 0 ? ActiveNode : null;
                    frmDetail.PostKeyValue += FrmDetail_PostKey;
                    if (frmDetail.ShowDialog() == DialogResult.OK)
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Gets the form detail.
        /// </summary>
        /// <returns></returns>
        protected override FrmXtraBaseTreeDetail GetFormDetail()
        {
            try
            {
                return new FrmXtraOpeningInventoryEntryDetail();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Valids the edit.
        /// </summary>
        /// <returns></returns>
        protected override bool ValidEdit()
        {
            if (!GlobalVariable.IsPostToParentAccount)
            {
                if (treeList.FindNodeByKeyID(int.Parse(PrimaryKeyValue)).HasChildren)
                {
                    XtraMessageBox.Show("Hệ thống không cho phép nhập số dư đầu kỳ lên tài khoản tổng hợp",
                                    ResourceHelper.GetResourceValueByName("ResDeleteCaption"),
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

            }
            return true;
        }

        /// <summary>
        /// Gets the row value selected.
        /// </summary>
        protected override void GetRowValueSelected()
        {
            try
            {
                PrimaryKeyValue = treeList.Nodes.Count > 0 ? treeList.FocusedNode[treeList.KeyFieldName].ToString() : null;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"));
            }
        }

        /// <summary>
        /// Handles the NodeCellStyle event of the treeList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs"/> instance containing the event data.</param>
        private void treeList_NodeCellStyle(object sender, DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs e)
        {
            e.Appearance.Font = e.Node["ParentId"] == null ? 
                new Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, FontStyle.Bold) : 
                new Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, FontStyle.Regular);
        }
    }
}

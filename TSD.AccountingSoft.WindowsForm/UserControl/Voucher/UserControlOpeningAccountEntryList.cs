/***********************************************************************
 * <copyright file="UserControlOpeningAccountEntryList.cs" company="BUCA JSC">
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
using System.Reflection;
using System.Windows.Forms;
using TSD.AccountingSoft.Session;
using TSD.AccountingSoft.Model.BusinessObjects.Opening;
using TSD.AccountingSoft.Presenter.Dictionary.Account;
using TSD.AccountingSoft.Presenter.Opening;
using TSD.AccountingSoft.Presenter.System.Lock;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.View.OpeningAccountEntry;
using TSD.AccountingSoft.View.System;
using TSD.AccountingSoft.WindowsForm.BaseUserControls;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.FormBusiness;
using TSD.AccountingSoft.WindowsForm.Resources;
using DevExpress.Data;
using DevExpress.XtraEditors;
using System.Linq;

namespace TSD.AccountingSoft.WindowsForm.UserControl.Voucher
{
    /// <summary>
    /// class UserControlOpeningAccountEntryList 
    /// </summary>
    public partial class UserControlOpeningAccountEntryList : BaseTreeListUserControl, IOpeningAccountEntriesView, IAccountView
    {
        #region Account Members

        public int AccountId { get; set; }
        public int? AccountCategoryId { get; set; }
        public string AccountCode { get; set; }
        public string AccountName { get; set; }
        public string ForeignName { get; set; }
        public int? ParentId { get; set; }
        public int Grade { get; set; }
        public bool IsDetail { get; set; }
        public string Description { get; set; }
        public int BalanceSide { get; set; }
        public string ConcomitantAccount { get; set; }
        public string CurrencyCode { get; set; }
        public int? BankId { get; set; }
        public bool IsChapter { get; set; }
        public bool IsBudgetCategory { get; set; }
        public bool IsBudgetItem { get; set; }
        public bool IsBudgetGroup { get; set; }
        public bool IsBudgetSource { get; set; }
        public bool IsActivity { get; set; }
        public bool IsCurrency { get; set; }
        public bool IsCustomer { get; set; }
        public bool IsVendor { get; set; }
        public bool IsEmployee { get; set; }
        public bool IsAccountingObject { get; set; }
        public bool IsInventoryItem { get; set; }
        public bool IsFixedAsset { get; set; }
        public bool IsCapitalAllocate { get; set; }
        public bool IsActive { get; set; }
        public bool IsAllowinputcts { get; set; }
        public bool IsSystem { get; set; }
        public bool IsProject { get; set; }
        public bool IsBank { get; set; }
        public bool IsBudgetSubItem { get; set; }

        #endregion

        private readonly OpeningAccountEntriesPresenter _openingAccountEntriesPresenter;
        private readonly AccountPresenter _accountPresenter;

        private List<OpeningAccountEntryModel> lstOpenningAccountEntries;

        /// <summary>
        /// Sets the opening account entries.
        /// </summary>
        /// <value>
        /// The opening account entries.
        /// </value>
        /// <exception cref="System.NotImplementedException"></exception>
        public IList<OpeningAccountEntryModel> OpeningAccountEntries
        {
            set
            {
                if (value == null)
                    lstOpenningAccountEntries = new List<OpeningAccountEntryModel>();
                else
                    lstOpenningAccountEntries = value.OrderBy(o => o.AccountCode).ToList();
                treeList.DataSource = lstOpenningAccountEntries;
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountCode", ColumnCaption = "Mã tài khoản", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 100 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountName", ColumnCaption = "Tên tài khoản", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 200 });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "TotalDebitAmountOC",
                    ColumnCaption = "Nợ đầu kỳ",
                    ColumnPosition = 3,
                    ColumnVisible = true,
                    ColumnWith = 100,
                    ColumnType = UnboundColumnType.Decimal
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "TotalCreditAmountOC",
                    ColumnCaption = "Có đầu kỳ",
                    ColumnPosition = 4,
                    ColumnVisible = true,
                    ColumnWith = 100,
                    ColumnType = UnboundColumnType.Decimal
                });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefTypeId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "PostedDate", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalAccountBeginningDebitAmountOC", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalAccountBeginningCreditAmountOC", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalAccountBeginningDebitAmountExchange", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalAccountBeginningCreditAmountExchange", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalDebitAmountExchange", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalCreditAmountExchange", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "OpeningAccountEntryDetails", ColumnVisible = false });
            }
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserControlOpeningAccountEntryList" /> class.
        /// </summary>
        public UserControlOpeningAccountEntryList()
        {
            InitializeComponent();
            lstOpenningAccountEntries = new List<OpeningAccountEntryModel>();

            _openingAccountEntriesPresenter = new OpeningAccountEntriesPresenter(this);
            _accountPresenter = new AccountPresenter(this);
   
        }

        /// <summary>
        /// Loads the data into grid.
        /// </summary>
        protected override void LoadDataIntoTree()
        {
            _openingAccountEntriesPresenter.Display();
        }

        /// <summary>
        /// Shows the form detail.
        /// </summary>
        protected override void ShowFormDetail()
        {
            try
            {
                if (_lockPresenter.CheckLockDate(1, 100, DateTime.Parse("01/01/1980")))//ThangNK, '01/01/1980': tham số giả để kiểm tra có khóa sổ không
                {
                    XtraMessageBox.Show("Hiện đang khóa sổ bạn không thể nhập dư đầu kỳ, bạn phải mở sổ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

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
                _accountPresenter.Display(PrimaryKeyValue);

                //LinhMC comment ---21.06.2014
                //FormDetail = IsInventoryItem ? "FrmXtraOpeningInventoryEntryDetail" : "FrmXtraOpeningAccountEntryDetail";
                //var typeOfForm = Assembly.GetExecutingAssembly().GetType(NamespaceForm + "." + FormDetail);
                //return typeOfForm != null ? (FrmXtraBaseTreeDetail)Activator.CreateInstance(typeOfForm) : null;

                if (IsInventoryItem)
                    return new FrmXtraOpeningInventoryEntryDetail();
                if (IsFixedAsset)
                {
                    XtraMessageBox.Show(string.Format(ResourceHelper.GetResourceValueByName("ResAccountOpenFixedAsset"), AccountCode), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return new FrmXtraOpeningFixedAssetEntryDetail();
                }
                   
                return new FrmXtraOpeningAccountEntryDetail();
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
            try
            {
                if (!GlobalVariable.IsPostToParentAccount)
                {
                    PrimaryKeyValue = treeList.Nodes.Count > 0 ? treeList.FocusedNode[treeList.KeyFieldName].ToString() : null;
                    if (PrimaryKeyValue != null && treeList.FindNodeByKeyID(int.Parse(PrimaryKeyValue)).HasChildren)
                    {
                        XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResOpeningAccountEntryListIsPostToParentAccount"),
                                        ResourceHelper.GetResourceValueByName("ResDeleteCaption"),
                                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }

                }
                return true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResDeleteCaption"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        /// <summary>
        /// Handles the NodeCellStyle event of the treeList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs"/> instance containing the event data.</param>
        private void treeList_NodeCellStyle(object sender, DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs e)
        {
            e.Appearance.Font = e.Node.HasChildren ? //e.Node["ParentId"] == null ?
                new Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, FontStyle.Bold) :
                new Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, FontStyle.Regular);
        }
    }
}
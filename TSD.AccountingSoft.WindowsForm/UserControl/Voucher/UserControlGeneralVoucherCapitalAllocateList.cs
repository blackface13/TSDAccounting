/***********************************************************************
 * <copyright file="UserControlGeneralVoucherCapitalAllocateList.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 *
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: 18 April 2014
 * Usage:
 *
 * RevisionHistory:
 * Date         Author               Description
 *
 * ************************************************************************/

using TSD.AccountingSoft.Model.BusinessObjects.General;
using TSD.AccountingSoft.Presenter.General;
using TSD.AccountingSoft.View.General;
using TSD.AccountingSoft.WindowsForm.BaseUserControls;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.FormBusiness;
using TSD.AccountingSoft.WindowsForm.Resources;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TSD.AccountingSoft.WindowsForm.UserControl.Voucher
{
    /// <summary>
    /// UserControlGeneralVoucherCapitalAllocateList
    /// </summary>
    public partial class UserControlGeneralVoucherCapitalAllocateList : BaseVoucherListUserControl, IGeneralVouchersView
    {
        /// <summary>
        /// The _genveral vouchers presenter
        /// </summary>
        private readonly GenveralVouchersPresenter _genveralVouchersPresenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserControlGeneralVoucherCapitalAllocateList" /> class.
        /// </summary>
        public UserControlGeneralVoucherCapitalAllocateList()
        {
            InitializeComponent();
            // DBOptionHelper=new GlobalVariable();
            _genveralVouchersPresenter = new GenveralVouchersPresenter(this);
            barEditItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

        /// <summary>
        /// Loads the data into grid.
        /// </summary>
        protected override void LoadDataIntoGrid()
        {
            _genveralVouchersPresenter.Display((int)RefTypeId);
        }

        /// <summary>
        /// Loads the data into grid detail.
        /// LinhMC
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        protected override void LoadDataIntoGridDetail(long refId)
        {
            _genveralVouchersPresenter.DisplayVoucherDetail(refId);
        }

        /// <summary>
        /// Deletes the grid.
        /// </summary>
        protected override void DeleteGrid()
        {
            // new CapitalAllocateVouchersPresenter(null).Delete(long.Parse(PrimaryKeyValue));
            new GenveralVouchersPresenter(null).Delete(long.Parse(PrimaryKeyValue));
        }

        /// <summary>
        /// Gets the form detail.
        /// </summary>
        /// <returns>FrmXtraBaseVoucherDetail.</returns>
        protected override FrmXtraBaseVoucherDetail GetFormDetail()
        {
            return new FrmXtraGenvervoucherCapitalAllocateDetail();
        }

        /// <summary>
        /// Sets the general vouchers.
        /// </summary>
        /// <value>The general vouchers.</value>
        IList<GeneralVocherModel> IGeneralVouchersView.GeneralVouchers
        {
            set
            {
               
                bindingSource.DataSource = value;
                gridView.PopulateColumns(value);
                ColumnsCollection.Clear();
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefTypeId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "PostedDate", ColumnVisible = true, ColumnCaption = "Ngày HT ", ColumnPosition = 1, ColumnType = UnboundColumnType.DateTime, Alignment = HorzAlignment.Center, ColumnWith = 70, ToolTip = "Ngày hạch toán" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefNo", ColumnCaption = "Số CT", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 70, ColumnType = UnboundColumnType.String, Alignment = HorzAlignment.Near, ToolTip = "Số chứng từ" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefDate", ColumnCaption = "Ngày CT", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 70, ColumnType = UnboundColumnType.DateTime, Alignment = HorzAlignment.Center, ToolTip = "Ngày chứng từ" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "JournalMemo", ColumnCaption = "Diễn giải", ColumnVisible = true, ColumnPosition = 4, Alignment = HorzAlignment.Near, ColumnWith = 300 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalAmountOc", ColumnCaption = "Số tiền", ColumnVisible = true, ColumnPosition = 5, ColumnWith = 100, Alignment = HorzAlignment.Far, ToolTip = "Số tiền", ColumnType = UnboundColumnType.Decimal });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalAmountExchange", ColumnCaption = "Số tiền quy đổi", ColumnVisible = false, ColumnPosition = 6, ColumnWith = 100, Alignment = HorzAlignment.Far, ToolTip = "Số tiền quy đổi", ColumnType = UnboundColumnType.Decimal });
                foreach (var column in ColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        gridView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        gridView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                        gridView.Columns[column.ColumnName].ToolTip = column.ToolTip;
                    }
                    else gridView.Columns[column.ColumnName].Visible = false;
                    SetNumericFormatControl(gridView, true);
                }
            }
        }

        /// <summary>
        /// Edits the data.
        /// </summary>
        protected override void EditData()
        {
            DialogResult yesno = XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResReCaptitalAllocateVoucher"),
                               ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (yesno == DialogResult.No)
            {
                return;
            }
            base.EditData();
        }

        public IList<GeneralDetailModel> GeneralVoucherDetails
        {
            set
            {
                bindingSourceDetail.DataSource = value;
                gridViewDetail.PopulateColumns(value);
                ColumnsCollection.Clear();

                ColumnsCollection.Add(new XtraColumn { ColumnName = "AutoBusiness", ColumnCaption = "ĐK tự động", ColumnPosition = 1, ColumnVisible = false, ColumnWith = 80, AllowEdit = true, ToolTip = "Định khoản tự động" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefDetailId", ColumnVisible = false, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountNumber", ColumnCaption = "TK nợ", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 60, ToolTip = "Tài khoản nợ" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CorrespondingAccountNumber", ColumnCaption = "TK có", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 60, ToolTip = "Tài khoản có" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnCaption = "Diễn giải", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 300, ToolTip = "Diễn giải", IsSummaryText = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AmountOc", ColumnCaption = "Số tiền", ColumnPosition = 6, ColumnType = UnboundColumnType.Decimal, ColumnVisible = true, ColumnWith = 100, ToolTip = "Số tiền" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CurrencyCode", ColumnCaption = "Tiền tệ", ColumnPosition = 5, ColumnVisible = true, ColumnWith = 50, ToolTip = "Tiền tệ" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ExchangeRate", ColumnCaption = "Tỷ giá", ColumnPosition = 7, ColumnVisible = true, ColumnWith = 80, ToolTip = "tỷ giá" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AmountExchange", ColumnCaption = "Số tiền QĐ", ColumnPosition = 8, ColumnType = UnboundColumnType.Decimal, ColumnVisible = true, ColumnWith = 100, ToolTip = "Số tiền quy đổi" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceCode", ColumnCaption = "Nguồn vốn", ColumnPosition = 9, ColumnVisible = true, ColumnWith = 100, ToolTip = "Nguồn vốn" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemCode", ColumnCaption = "Mục/TM", ColumnPosition = 10, ColumnVisible = true, ColumnWith = 100, ToolTip = "Mục/Tiểu mục" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "VoucherTypeId", ColumnCaption = "Nghiệp vụ", ColumnPosition = 11, ColumnVisible = false, ColumnWith = 100, ToolTip = "Nghiệp vụ" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DepartmentId", ColumnCaption = "Phòng ban", ColumnPosition = 12, ColumnVisible = false, ColumnWith = 100, ToolTip = "Phòng ban" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CustomerId", ColumnCaption = "Khách hàng", ColumnPosition = 13, ColumnVisible = false, ColumnWith = 100, ToolTip = "Khách hàng " });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "VendorId", ColumnCaption = "Nhà cung cấp", ColumnPosition = 14, ColumnVisible = false, ColumnWith = 100, ToolTip = "Nhà cung cấp" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "EmployeeId", ColumnCaption = "Nhân viên", ColumnPosition = 15, ColumnVisible = false, ColumnWith = 100, ToolTip = "Nhân viên" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectId", ColumnCaption = "Đối tượng khác", ColumnPosition = 16, ColumnVisible = false, ColumnWith = 100, ToolTip = "Đối tượng khác" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectId", ColumnCaption = "Dự án", ColumnPosition = 17, ColumnVisible = false, ColumnWith = 150, ToolTip = "Dự án" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CapitalAllocateCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BankId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "InventoryItemId", ColumnCaption = "Vật tư/ CCDC", ColumnPosition = 17, ColumnVisible = false, ColumnWith = 150, ToolTip = "Vật tư- công cụ dụng cụ" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DetailBy", ColumnVisible = false });
                foreach (var column in ColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        gridViewDetail.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        gridViewDetail.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                        gridViewDetail.Columns[column.ColumnName].Width = column.ColumnWith;
                        gridViewDetail.Columns[column.ColumnName].Fixed = column.FixedColumn;
                        gridViewDetail.Columns[column.ColumnName].ToolTip = column.ToolTip;
                        gridViewDetail.Columns[column.ColumnName].UnboundType = column.ColumnType;
                    }
                    else gridViewDetail.Columns[column.ColumnName].Visible = false;
                }
                SetNumericFormatControl(gridViewDetail, true);
            }
        }
    }
}
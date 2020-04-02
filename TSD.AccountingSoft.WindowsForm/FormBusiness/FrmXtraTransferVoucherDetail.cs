/***********************************************************************
 * <copyright file="FrmXtraGeneralVoucherDetail.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: 16 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using TSD.AccountingSoft.Session;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Model.BusinessObjects.General;
using TSD.AccountingSoft.Presenter.Dictionary.AutoBusiness;
using TSD.AccountingSoft.Presenter.Dictionary.Project;
using TSD.AccountingSoft.Presenter.Dictionary.VoucherType;
using TSD.AccountingSoft.Presenter.Dictionary.Department;
using TSD.AccountingSoft.WindowsForm.CommonClass;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.Presenter.Dictionary.Customer;
using TSD.AccountingSoft.Presenter.Dictionary.Currency;
using TSD.AccountingSoft.Presenter.Dictionary.Account;
using TSD.AccountingSoft.Presenter.Dictionary.Vendor;
using TSD.AccountingSoft.Presenter.Dictionary.BudgetItem;
using TSD.AccountingSoft.Presenter.Dictionary.BudgetSource;
using TSD.AccountingSoft.Presenter.Dictionary.AccountingObject;
using TSD.AccountingSoft.Presenter.Dictionary.Employee;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.View.General;
using TSD.Enum;
using DevExpress.Utils;
using DevExpress.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using TSD.AccountingSoft.Presenter.General;
using TSD.AccountingSoft.WindowsForm.Resources;
using System.Threading;
using DevExpress.XtraEditors.Mask;


namespace TSD.AccountingSoft.WindowsForm.FormBusiness
{
    /// <summary>
    /// Class FrmXtraTransferVoucherDetail.
    /// </summary>
    public partial class FrmXtraTransferVoucherDetail : FrmXtraBaseVoucherDetail,IGeneralVoucherView
    {
        private RepositoryItemCalcEdit _rpsSpinEdit;

        #region Presenters

        private readonly GenveralVoucherPresenter _generalVoucherPresenter;
     
        #endregion

        #region Events

        public FrmXtraTransferVoucherDetail()
        {
            InitializeComponent();
            _generalVoucherPresenter=new GenveralVoucherPresenter(this);
            dtPostDate.DateTime = DateTime.Parse(new GlobalVariable().FinancialEndOfDate);
        }

        private void dtPostDate_EditValueChanged(object sender, EventArgs e)
        {
            dtRefDate.DateTime = dtPostDate.DateTime;
        }

        private void gridViewDetail_RowUpdated(object sender, RowObjectEventArgs e)
        {

        }

        private void gridViewDetail_ValidateRow(object sender, ValidateRowEventArgs e)
        {

            try
            {
                //Khai báo cột thông tin kiểm tra
                var accountNumberCol = gridViewDetail.Columns["AccountNumber"];//Nợ
                var correspondingAccountNumberCol = gridViewDetail.Columns["CorrespondingAccountNumber"];//Có
                var budgetSourceCodeCol = gridViewDetail.Columns["BudgetSourceCode"];
                var budgetItemCodeCol = gridViewDetail.Columns["BudgetItemCode"];
                var accountingObjectIdCol = gridViewDetail.Columns["AccountingObjectId"];
                var employeeIdCol = gridViewDetail.Columns["EmployeeId"];
                var vendorIdCol = gridViewDetail.Columns["VendorId"];
                //var projectIdCol = gridViewDetail.Columns["ProjectId"];
                var customerIdCol = gridViewDetail.Columns["CustomerId"];
                var currencyCodeCol = gridViewDetail.Columns["CurrencyCode"];

                //Giá trị cột thông tin kiểm tra
                var accountNumber = (string)gridViewDetail.GetRowCellValue(e.RowHandle, accountNumberCol);
                var correspondingAccountNumber = (string)gridViewDetail.GetRowCellValue(e.RowHandle, correspondingAccountNumberCol);
                var budgetSourceCode = (string)gridViewDetail.GetRowCellValue(e.RowHandle, budgetSourceCodeCol);
                var budgetItemCode = (string)gridViewDetail.GetRowCellValue(e.RowHandle, budgetItemCodeCol);
                var straccountingObjectId = (int?)gridViewDetail.GetRowCellValue(e.RowHandle, accountingObjectIdCol);
                var employeeId = (int?)gridViewDetail.GetRowCellValue(e.RowHandle, employeeIdCol);
                var vendorId = (int?)gridViewDetail.GetRowCellValue(e.RowHandle, vendorIdCol);
                // var projectId = (int?)gridViewDetail.GetRowCellValue(e.RowHandle, projectIdCol);
                var currencyCode = (string)gridViewDetail.GetRowCellValue(e.RowHandle, currencyCodeCol);
                var customerId = (int?)gridViewDetail.GetRowCellValue(e.RowHandle, customerIdCol);

                // Chưa chon TK Nợ
                if (accountNumber == null || accountNumber == "")
                {
                    e.Valid = false;
                    gridViewDetail.SetColumnError(accountNumberCol, ResourceHelper.GetResourceValueByName("ResReceiptVoucherAccountNumberEmpty"));
                    return;
                }
                // Chưa chon tài khoản Có
                if (correspondingAccountNumber == null || correspondingAccountNumber == "")
                {
                    e.Valid = false;
                    gridViewDetail.SetColumnError(correspondingAccountNumberCol, ResourceHelper.GetResourceValueByName("ResReceiptVoucherCorrespondingAccountNumberEmpty"));
                    return;
                }

                var rowValue = (AccountModel)_rpsAccountNumber.GetRowByKeyValue(accountNumber);
                //Kiểm tra tài khoản Nợ chi tiết
                if (rowValue.IsDetail != true)
                {
                    e.Valid = false;
                    gridViewDetail.SetColumnError(accountNumberCol, ResourceHelper.GetResourceValueByName("ReceiptVoucherChildaccountNumber"));


                }
                //Kiểm tra tài khoản Có chi tiết
                rowValue = (AccountModel)_rpsAccountNumber.GetRowByKeyValue(correspondingAccountNumber);
                if (rowValue.IsDetail != true)
                {
                    e.Valid = false;
                    gridViewDetail.SetColumnError(correspondingAccountNumberCol, ResourceHelper.GetResourceValueByName("ResReceiptVoucherChildCorrespondingAccountNumber"));

                }

                // TK Nợ/có Trùng nhau
                if (accountNumber == correspondingAccountNumber)
                {
                    e.Valid = false;
                    gridViewDetail.SetColumnError(correspondingAccountNumberCol, ResourceHelper.GetResourceValueByName("ResAccountAndCorrespondingAccountNumber"));
                }

                //Kiểm tra tài khoản theo nguồn vốn
                rowValue = (AccountModel)_rpsAccountNumber.GetRowByKeyValue(accountNumber);
                if (rowValue.IsBudgetSource && budgetSourceCode == null)
                {
                    e.Valid = false;
                    gridViewDetail.SetColumnError(budgetSourceCodeCol, ResourceHelper.GetResourceValueByName("ResReceiptVoucherbudgetSource"));
                }

                rowValue = (AccountModel)_rpsAccountNumber.GetRowByKeyValue(correspondingAccountNumber);
                if (rowValue == null)
                {
                    e.Valid = false;
                    gridViewDetail.SetColumnError(budgetSourceCodeCol, ResourceHelper.GetResourceValueByName("ResReceiptVoucherbudgetSource"));
                }
                else
                {
                    if (rowValue.IsBudgetSource && budgetSourceCode == null)
                    {
                        e.Valid = false;
                        gridViewDetail.SetColumnError(budgetSourceCodeCol, ResourceHelper.GetResourceValueByName("ResReceiptVoucherbudgetSource"));
                    }
                }

                if (currencyCode == null || currencyCode == "")
                {
                    e.Valid = false;
                    gridViewDetail.SetColumnError(currencyCodeCol, "Bạn chưa chọn tiền tệ");
                }

                //Kiểm tra tài khoản theo mục/tiểu mục
                rowValue = (AccountModel)_rpsAccountNumber.GetRowByKeyValue(accountNumber);
                if (rowValue.IsBudgetItem && budgetItemCode == null)
                {
                    e.Valid = false;
                    gridViewDetail.SetColumnError(budgetItemCodeCol, ResourceHelper.GetResourceValueByName("ResReceiptVoucherbudgetItem"));
                }

                rowValue = (AccountModel)_rpsAccountNumber.GetRowByKeyValue(correspondingAccountNumber);
                if (rowValue == null)
                {
                    e.Valid = false;
                    gridViewDetail.SetColumnError(budgetItemCodeCol, ResourceHelper.GetResourceValueByName("ResReceiptVoucherbudgetItem"));
                }
                else
                {
                    if (rowValue.IsBudgetItem && budgetItemCode == null)
                    {
                        e.Valid = false;
                        gridViewDetail.SetColumnError(budgetItemCodeCol, ResourceHelper.GetResourceValueByName("ResReceiptVoucherbudgetItem"));
                    }
                }
                //Kiểm tra tài khoản theo đối tượng khác
                rowValue = (AccountModel)_rpsAccountNumber.GetRowByKeyValue(accountNumber);

                if (rowValue.IsAccountingObject && straccountingObjectId == null)
                {
                    e.Valid = false;
                    gridViewDetail.SetColumnError(accountingObjectIdCol, ResourceHelper.GetResourceValueByName("ResReceiptVoucheraccountingObject"));
                }

                rowValue = (AccountModel)_rpsAccountNumber.GetRowByKeyValue(correspondingAccountNumber);
                if (rowValue == null)
                {
                    e.Valid = false;
                    gridViewDetail.SetColumnError(accountingObjectIdCol, ResourceHelper.GetResourceValueByName("ResReceiptVoucheraccountingObject"));
                }
                else
                {
                    if (rowValue.IsAccountingObject && straccountingObjectId == null)
                    {
                        e.Valid = false;
                        gridViewDetail.SetColumnError(accountingObjectIdCol, ResourceHelper.GetResourceValueByName("ResReceiptVoucheraccountingObject"));
                    }
                }

                // Kiểm tra tài khoản theo khách hàng=====================================
                rowValue = (AccountModel)_rpsAccountNumber.GetRowByKeyValue(accountNumber);
                if (rowValue.IsCustomer && customerId == null)
                {
                    e.Valid = false;
                    gridViewDetail.SetColumnError(customerIdCol, "Bạn chưa chọn khách hàng theo tài khoản đã chọn");
                }

                rowValue = (AccountModel)_rpsAccountNumber.GetRowByKeyValue(correspondingAccountNumber);
                if (rowValue.IsCustomer && customerId == null)
                {
                    e.Valid = false;
                    gridViewDetail.SetColumnError(customerIdCol, "Bạn chưa chọn khách hàng theo tài khoản đã chọn");
                }


                // Kiểm tra tài khoản theo nhân viên =======================================
                rowValue = (AccountModel)_rpsAccountNumber.GetRowByKeyValue(accountNumber);
                if (rowValue.IsEmployee && employeeId == null)
                {
                    e.Valid = false;
                    gridViewDetail.SetColumnError(customerIdCol, "Bạn chưa chọn nhân viên  theo tài khoản đã chọn");
                }

                rowValue = (AccountModel)_rpsAccountNumber.GetRowByKeyValue(correspondingAccountNumber);
                if (rowValue.IsEmployee && employeeId == null)
                {
                    e.Valid = false;
                    gridViewDetail.SetColumnError(customerIdCol, "Bạn chưa chọn nhân viên theo tài khoản đã chọn");
                }


                // Kiểm tra tài khoản theo nhà cung cấp ==================================
                rowValue = (AccountModel)_rpsAccountNumber.GetRowByKeyValue(accountNumber);
                if (rowValue.IsVendor && vendorId == null)
                {
                    e.Valid = false;
                    gridViewDetail.SetColumnError(customerIdCol, "Bạn chưa chọn nhà cung cấp theo tài khoản đã chọn");
                }

                rowValue = (AccountModel)_rpsAccountNumber.GetRowByKeyValue(correspondingAccountNumber);
                if (rowValue.IsVendor && vendorId == null)
                {
                    e.Valid = false;
                    gridViewDetail.SetColumnError(customerIdCol, "Bạn chưa nhà cung cấp theo tài khoản đã chọn");
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(),
                    ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public override void gridViewDetail_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName.Equals("AmountExchange") || e.Column.FieldName.Equals("ExchangeRate") ||
                e.Column.FieldName.Equals("AmountOc") || e.Column.FieldName.Equals("AutoBusiness"))
            {
                gridViewDetail.PostEditor();
                var exchange = (decimal)gridViewDetail.GetRowCellValue(e.RowHandle, "ExchangeRate");
                var amountOc = (decimal)gridViewDetail.GetRowCellValue(e.RowHandle, "AmountOc");
                var amountEx = (decimal)gridViewDetail.GetRowCellValue(e.RowHandle, "AmountExchange");
                if (e.Column.FieldName.Equals("AmountOc"))
                {
                    if (exchange > 0)
                    {
                        if (amountEx * exchange != amountOc)
                        {
                            var rowHandle = gridViewDetail.FocusedRowHandle;
                            gridViewDetail.SetRowCellValue(rowHandle, "AmountExchange", Math.Round(amountOc / exchange, int.Parse(DBOptionHelper.CurrencyDecimalDigits)));
                        }
                    }
                }
                //ThangNK comment lại
                //if (e.Column.FieldName.Equals("AmountExchange"))
                //{
                //    if (exchange > 0)
                //    {
                //        if (amountOc / exchange != amountEx)
                //        {
                //            var rowHandle = gridViewDetail.FocusedRowHandle;
                //            gridViewDetail.SetRowCellValue(rowHandle, "AmountOc", amountEx * exchange);
                //        }
                //    }
                //}

                if (e.Column.FieldName.Equals("ExchangeRate"))
                {

                    if (exchange > 0)
                    {
                        if (amountOc / exchange != amountEx)
                        {
                            var rowHandle = gridViewDetail.FocusedRowHandle;
                            gridViewDetail.SetRowCellValue(rowHandle, "AmountExchange", Math.Round(amountOc / exchange, int.Parse(DBOptionHelper.CurrencyDecimalDigits)));
                        }
                    }
                }

                if (e.Column.FieldName == "AutoBusiness")
                {
                    var rowHandle = gridViewDetail.FocusedRowHandle;
                    var autoBusinessId = (int)gridViewDetail.GetRowCellValue(rowHandle, "AutoBusiness");
                    var autoBusiness = (AutoBusinessModel)_rpsAutoBusiness.GetRowByKeyValue(autoBusinessId);
                    gridViewDetail.SetRowCellValue(rowHandle, "AccountNumber", autoBusiness.DebitAccountNumber);
                    gridViewDetail.SetRowCellValue(rowHandle, "CorrespondingAccountNumber", autoBusiness.CreditAccountNumber);
                    gridViewDetail.SetRowCellValue(rowHandle, "VoucherTypeId", autoBusiness.VoucherTypeId);
                    gridViewDetail.SetRowCellValue(rowHandle, "Description", autoBusiness.Description);
                }
            }


        }

        private void FrmXtraTransferVoucherDetail_Load(object sender, EventArgs e)
        {
            AdjustControlSize(false, true);
        }

        private void FrmXtraTransferVoucherDetail_Resize(object sender, EventArgs e)
        {
            AdjustControlSize(false, true);
        }

        private void dtRefDate_EditValueChanged(object sender, EventArgs e)
        {

        }

        #endregion

        #region Override functions

        protected override void InitRefInfo()
        {
            if (ActionMode != ActionModeVoucherEnum.AddNew) return;
            dtPostDate.EditValue = DateTime.Parse(new GlobalVariable().FinancialEndOfDate);
            dtRefDate.EditValue = dtPostDate.EditValue;
        }

        protected override void InitData()
        {
            base.InitData();
            //_accountsPresenter.DisplayActive();
            //_currenciesPresenter.DisplayActive();
          
            var generalVoucherDetailId = ((GeneralVocherModel)MasterBindingSource.Current).RefId;
            KeyValue = generalVoucherDetailId.ToString(CultureInfo.InvariantCulture);
            if (long.Parse(KeyValue) != 0)
            {
                _generalVoucherPresenter.Display(long.Parse(KeyValue));
            }
            else
            {
                GeneralDetails = new List<GeneralDetailModel>();
            }
            if (ActionMode == ActionModeVoucherEnum.None)
            {
                txtGenveralDescription.Properties.ReadOnly = true;
            }
            else
            {
                txtGenveralDescription.Properties.ReadOnly = false;
            }
            
        }

        protected override void InitControls()
        {
            _rpsSpinEdit = new RepositoryItemCalcEdit { AllowMouseWheel = false };
            _rpsSpinEdit.Mask.MaskType = MaskType.Numeric;
            _rpsSpinEdit.Mask.EditMask = @"c" + DBOptionHelper.ExchangeRateDecimalDigits;
            _rpsSpinEdit.Mask.Culture = Thread.CurrentThread.CurrentCulture;
            _rpsSpinEdit.Mask.UseMaskAsDisplayFormat = true;
        }

        protected override long SaveData()
        {
            if (ActionMode == ActionModeVoucherEnum.Edit)
                RefId = (_keyForSend == null || long.Parse(_keyForSend) == 0) ? RefId : long.Parse(_keyForSend);

            var result = new DialogResult();
            if (GeneralParalellDetails.Count > 0)
            {
                result = XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResAutoGenerateParallelUpdateQuestion"), ResourceHelper.GetResourceValueByName("ResAutoGenerateParallelCaption"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }
            else
            {
                result = XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResAutoGenerateParallelInsertQuestion"), ResourceHelper.GetResourceValueByName("ResAutoGenerateParallelCaption"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }
            return result == DialogResult.OK ? _generalVoucherPresenter.Save(true) : _generalVoucherPresenter.Save(false);
            //return _generalVoucherPresenter.Save();
        }

        protected override void EditVoucher()
        {
            txtGenveralDescription.Properties.ReadOnly = false;
            base.EditVoucher();
        }

        protected override void AddNewVoucher()
        {
            txtGenveralDescription.Text = "";
            base.AddNewVoucher();
        }

        protected override void DeleteVoucher()
        {
            var refId = RefId > 0 ? RefId : long.Parse(_keyForSend);
            new GenveralVoucherPresenter(null).Delete(refId);
        }

        protected override bool ValidData()
        {

            if (string.IsNullOrEmpty(txtRefNo.Text))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResReceiptRefNo"),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRefNo.Focus();
                return false;
            }

            if (RefNo.Length == 0)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResRefNo"),
                       ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                txtRefNo.Focus();
                return false;
            }
            //if (dtRefDate.DateTime < DateTime.Parse(GlobalVariable.StartedDate))
            //{
            //    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResRefDate"),
            //           ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
            //           MessageBoxIcon.Error);
            //    dtRefDate.Focus();
            //    return false;
            //}


            for (var i = 0; i < gridViewDetail.RowCount; i++)
            {

                if (gridViewDetail.GetRow(i) != null)
                {
                    var strAccountNumberDetail = (string)gridViewDetail.GetRowCellValue(i, "AccountNumber");
                    var strCorrespondingAccountNumberDetail = (string)gridViewDetail.GetRowCellValue(i, "CorrespondingAccountNumber");
                    if (string.IsNullOrEmpty(strCorrespondingAccountNumberDetail))
                    {
                        XtraMessageBox.Show("Tài khoản có để trống tại dòng: " + (i + 1),
                        ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    if (string.IsNullOrEmpty(strAccountNumberDetail))
                    {
                        XtraMessageBox.Show("Tài khoản nợ để trống tại dòng: " + (i + 1),
                        ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }

            return true;
        }

        #endregion

        #region Properties

        public long RefId
        {
            get;
            set;
        }
        public string RefNo
        {
            get { return txtRefNo.Text; }
            set { txtRefNo.Text = value; }
        }
        public DateTime RefDate
        {
            get
            {
                var refDate = (DateTime)dtRefDate.EditValue;
                var now = DateTime.Now;
                var newDate = new DateTime(refDate.Year, refDate.Month, refDate.Day, now.Hour, now.Minute, now.Second);
                return newDate;
            }
            set
            {
                dtRefDate.EditValue = value;
            }
        }
        public DateTime PostedDate
        {
            get
            {
                var refDate = (DateTime)dtPostDate.EditValue;
                var now = DateTime.Now;
                var newDate = new DateTime(refDate.Year, refDate.Month, refDate.Day, now.Hour, now.Minute, now.Second);
                return newDate;
            }
            set
            {
                dtPostDate.EditValue = value;
            }
        }
        public int RefTypeId
        {
            get { return (int)BaseRefTypeId; }
            set { BaseRefTypeId = (RefType)value; }
        }
        public bool IsCapitalAllocate
        {
            get { return false; }
        }
        public string JournalMemo
        {
            get { return txtGenveralDescription.Text; }
            set { txtGenveralDescription.Text = value; }
        }
        public decimal TotalAmountOc { get; set; }
        public decimal TotalAmountExchange { get; set; }
        public long? DepositId { get; set; }
        public long? CashId { get; set; }
        public IList<GeneralDetailModel> GeneralDetails
        {
            get
            {
                var generalVoucherDetail = new List<GeneralDetailModel>();
                if (gridViewDetail.DataSource != null && gridViewDetail.RowCount > 0)
                {
                    for (var i = 0; i < gridViewDetail.RowCount; i++)
                    {
                        var rowVoucherDetailData = (GeneralDetailModel)gridViewDetail.GetRow(i);
                        if (rowVoucherDetailData != null)
                        {
                           var item = new GeneralDetailModel
                           {
                                AccountNumber = rowVoucherDetailData.AccountNumber,
                                CorrespondingAccountNumber = rowVoucherDetailData.CorrespondingAccountNumber,
                                Description = rowVoucherDetailData.Description,
                                AmountOc = rowVoucherDetailData.AmountOc,
                                AmountExchange = rowVoucherDetailData.AmountExchange,
                                VoucherTypeId = rowVoucherDetailData.VoucherTypeId == 0 ? null : rowVoucherDetailData.VoucherTypeId,
                                BudgetSourceCode = rowVoucherDetailData.BudgetSourceCode,
                                BudgetItemCode = rowVoucherDetailData.BudgetItemCode,
                                AccountingObjectId = rowVoucherDetailData.AccountingObjectId == 0 ? null : rowVoucherDetailData.AccountingObjectId,
                                //ProjectId = rowVoucherDetailData.ProjectId == 0 ? null : rowVoucherDetailData.ProjectId,
                                CurrencyCode = rowVoucherDetailData.CurrencyCode,
                                CustomerId = rowVoucherDetailData.CustomerId == 0 ? null : rowVoucherDetailData.CustomerId,
                                DepartmentId = rowVoucherDetailData.DepartmentId == 0 ? null : rowVoucherDetailData.DepartmentId,
                                EmployeeId = rowVoucherDetailData.EmployeeId == 0 ? null : rowVoucherDetailData.EmployeeId,
                                ExchangeRate = rowVoucherDetailData.ExchangeRate,
                                RefId = rowVoucherDetailData.RefId,
                                VendorId = rowVoucherDetailData.VendorId == 0 ? null : rowVoucherDetailData.VendorId

                            };
                           generalVoucherDetail.Add(item);

                        }
                    }

                }
                return generalVoucherDetail.ToList();
            }
            set
            {
                ColumnsCollection.Clear();
                bindingSourceDetail.DataSource = value.Count == 0 ? new List<GeneralDetailModel> { new GeneralDetailModel { AmountOc = 0, ExchangeRate = 1,CurrencyCode = "USD"} } : value;
               // bindingSourceDetail.DataSource = value ?? new List<GeneralDetailModel>();
                gridViewDetail.PopulateColumns(value);
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AutoBusiness", ColumnCaption = "ĐK tự động", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Định khoản tự động" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "GeneralVoucherDetailId", ColumnVisible = false, FixedColumn = FixedStyle.Left, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountNumber", ColumnCaption = "TK nợ", FixedColumn = FixedStyle.Left, ColumnPosition = 2, ColumnVisible = true, ColumnWith = 100, ToolTip = "Tài khoản nợ" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CorrespondingAccountNumber", ColumnCaption = "TK có", FixedColumn = FixedStyle.Left, ColumnPosition = 3, ColumnVisible = true, ColumnWith = 100, ToolTip = "Tài khoản có" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnCaption = "Diễn giải", FixedColumn = FixedStyle.None, ColumnPosition = 4, ColumnVisible = true, ColumnWith = 300 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AmountOc", ColumnCaption = "Số tiền", ColumnPosition = 5, ColumnType = UnboundColumnType.Decimal, FixedColumn = FixedStyle.None, ColumnVisible = true, ColumnWith = 100 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CurrencyCode", ColumnCaption = "Tiền tệ", ColumnPosition = 6, FixedColumn = FixedStyle.None, ColumnVisible = true, ColumnWith = 100, ToolTip = "Tiền tệ" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ExchangeRate", ColumnCaption = "Tỷ giá", ColumnPosition = 7, ColumnType = UnboundColumnType.Decimal, FixedColumn = FixedStyle.None, ColumnVisible = true, ColumnWith = 100, ToolTip = "tỷ giá" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AmountExchange", ColumnCaption = "Quy đổi", ColumnPosition = 8, ColumnType = UnboundColumnType.Decimal, FixedColumn = FixedStyle.None, ColumnVisible = true, ColumnWith = 100 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Bussiness", ColumnCaption = "Nghiệp vụ", ColumnPosition = 9, FixedColumn = FixedStyle.None, ColumnVisible = true, ColumnWith = 100});
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceCode", ColumnCaption = "Nguồn vốn", ColumnPosition =10, FixedColumn = FixedStyle.None, ColumnVisible = true, ColumnWith = 100 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemCode", ColumnCaption = "Mục/TM", ColumnPosition = 11, FixedColumn = FixedStyle.None, ColumnVisible = true, ColumnWith = 100, ToolTip = "Mục/Tiểu mục" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DepartmentId", ColumnCaption = "Phòng ban", ColumnPosition = 12, FixedColumn = FixedStyle.None, ColumnVisible = true, ColumnWith = 100, ToolTip = "Phòng ban" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CustomerId", ColumnCaption = "Khách hàng", ColumnPosition = 13, FixedColumn = FixedStyle.None, ColumnVisible = true, ColumnWith = 100, ToolTip = "Khách hàng " });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "VendorId", ColumnCaption = "Nhà cung cấp", ColumnPosition = 14, FixedColumn = FixedStyle.None, ColumnVisible = true, ColumnWith = 100, ToolTip = "Nhà cung cấp" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "EmployeeId", ColumnCaption = "Nhân viên", ColumnPosition = 15, FixedColumn = FixedStyle.None, ColumnVisible = true, ColumnWith = 100, ToolTip = "Nhân viên" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectId", ColumnCaption = "Đối tượng khác", ColumnPosition = 16, FixedColumn = FixedStyle.None, ColumnVisible = true, ColumnWith = 100, ToolTip = "Đối tượng khác" });
                //ColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectId", ColumnCaption = "Dự án", FixedColumn = FixedStyle.None, ColumnPosition = 17, ColumnVisible = true, ColumnWith = 150 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BankId", ColumnVisible = false });

                foreach (GridColumn grdColumn in gridViewDetail.Columns)
                {
                    grdColumn.Visible = false;
                }

                foreach (var column in ColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        gridViewDetail.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        gridViewDetail.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                        gridViewDetail.Columns[column.ColumnName].Width = column.ColumnWith;
                        gridViewDetail.Columns[column.ColumnName].Fixed = column.FixedColumn;
                        gridViewDetail.Columns[column.ColumnName].ToolTip = column.ToolTip;
                        switch (column.ColumnName)
                        {
                            case "AccountNumber":
                                gridViewDetail.Columns[column.ColumnName].ColumnEdit = _rpsAccountNumber;
                                break;
                            case "CorrespondingAccountNumber":
                                gridViewDetail.Columns[column.ColumnName].ColumnEdit = _rpsAccountNumber;
                                break;
                            case "BudgetSourceCode":
                                gridViewDetail.Columns[column.ColumnName].ColumnEdit = _rpsBudgetSource;
                                break;
                            case "BudgetItemCode":
                                gridViewDetail.Columns[column.ColumnName].ColumnEdit = _rpsBudgetItem;
                                break;
                            case "AccountingObjectId":
                                gridViewDetail.Columns[column.ColumnName].ColumnEdit = _rpsAccountingObject;
                                break;
                            case "VendorId":
                                gridViewDetail.Columns[column.ColumnName].ColumnEdit = _rpsVendor;
                                break;
                            case "EmployeeId":
                                gridViewDetail.Columns[column.ColumnName].ColumnEdit = _rpsEmployees;
                                break;
                            case "CustomerId":
                                gridViewDetail.Columns[column.ColumnName].ColumnEdit = _rpsCustomer;
                                break;
                            case "DepartmentId":
                                gridViewDetail.Columns[column.ColumnName].ColumnEdit = _rpsDepartment;
                                break;
                            //case "ProjectId":
                            //    gridViewDetail.Columns[column.ColumnName].ColumnEdit = _rpsProject;
                            //    break;
                            case "AutoBusiness":
                                gridViewDetail.Columns[column.ColumnName].ColumnEdit = _rpsAutoBusiness;
                                break;
                            case "CurrencyCode":
                                gridViewDetail.Columns[column.ColumnName].ColumnEdit = _rpsCurrency;
                                break;
                            case "ExchangeRate":
                                gridViewDetail.Columns[column.ColumnName].ColumnEdit = _rpsSpinEdit;
                                break;
                            case "Bussiness":
                                gridViewDetail.Columns[column.ColumnName].ColumnEdit = _rpsVoucherTypeId;
                                break;
                        }
                    }
                    else gridViewDetail.Columns[column.ColumnName].Visible = false;
                    SetNumericFormatControl(gridViewDetail, true);
                }
            }
        }

        public IList<GeneralParalellDetailModel> GeneralParalellDetails { get; set; }

        #endregion
    }
}
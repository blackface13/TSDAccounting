/***********************************************************************
 * <copyright file="FrmXtraReceiptDepositDetail.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThoDD
 * Email:    thodd@buca.vn
 * Website:
 * Create Date: 04 June 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 26/8/2015 LINHMC xóa hàm override CopyAndPasteRowItem vì gây ra nhiều lỗi, đã sửa lại hàm base ok
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using TSD.AccountingSoft.Session;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Model.BusinessObjects.Deposit;
using TSD.AccountingSoft.Presenter.Dictionary.Account;
using TSD.AccountingSoft.Presenter.Dictionary.AccountingObject;
using TSD.AccountingSoft.Presenter.Dictionary.AutoBusiness;
using TSD.AccountingSoft.Presenter.Dictionary.BudgetItem;
using TSD.AccountingSoft.Presenter.Dictionary.BudgetSource;
using TSD.AccountingSoft.Presenter.Dictionary.Currency;
using TSD.AccountingSoft.Presenter.Dictionary.Customer;
using TSD.AccountingSoft.Presenter.Dictionary.Department;
using TSD.AccountingSoft.Presenter.Dictionary.Employee;
using TSD.AccountingSoft.Presenter.Dictionary.MergerFund;
using TSD.AccountingSoft.Presenter.Deposit.ReceiptDeposit;
using TSD.AccountingSoft.Presenter.Dictionary.Project;
using TSD.AccountingSoft.Presenter.Dictionary.Vendor;
using TSD.AccountingSoft.Presenter.Dictionary.VoucherType;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.View.Deposit;
using TSD.AccountingSoft.WindowsForm.CommonClass;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.Resources;
using TSD.Enum;
using DevExpress.Utils;
using DevExpress.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System.Threading;
using TSD.AccountingSoft.Presenter.Dictionary.Bank;
using DevExpress.XtraEditors.Mask;
using System.Data;
using TSD.AccountingSoft.Presenter.General;
using TSD.AccountingSoft.Model.BusinessObjects.General;

namespace TSD.AccountingSoft.WindowsForm.FormBusiness
{
    public partial class FrmXtraReceiptDepositDetail : FrmXtraBaseVoucherDetail, IReceiptDepositView
    {
        #region Variable 

        private readonly ReceiptDepositPresenter _receiptDepositPresenter;
        private RepositoryItemCalcEdit _rpsSpinEdit = new RepositoryItemCalcEdit();
        private List<AccountModel> lstAccountNumbers;

        #endregion

        #region Properties

        public long RefId { get; set; }
        public int RefTypeId
        {
            get { return (int)BaseRefTypeId; }
            set { BaseRefTypeId = ActionMode == ActionModeVoucherEnum.Edit ? (RefType)value : BaseRefTypeId; }
        }
        public System.DateTime? RefDate
        {
            get
            {
                if (dtRefDate.EditValue == null)
                    return null;
                return Convert.ToDateTime(dtRefDate.DateTime.ToShortDateString());
            }
            set
            {
                dtRefDate.EditValue = value;
            }
        }
        public System.DateTime? PostedDate
        {
            get
            {
                if (dtPostDate.EditValue == null)
                    return null;
                return Convert.ToDateTime(dtPostDate.DateTime.ToShortDateString());
            }
            set { dtPostDate.EditValue = value; }
        }
        public string RefNo
        {
            get { return txtRefNo.Text; }
            set { txtRefNo.EditValue = value; }
        }
        public int? BankId
        {
            get
            {
                var objBank = (BankModel)cboBank.GetSelectedDataRow();
                if (objBank != null)
                    return objBank.BankId;
                return null;
            }
            set
            {
                if (value != null)
                    cboBank.EditValue = value;
            }
        }
        public string Trader
        {
            get { return txtContactName.Text; }
            set { txtContactName.Text = value; }
        }
        public string BankAccountCode { get; set; }
        public string CurrencyCode
        {
            get
            {
                return (cboCurrency.EditValue ?? "").ToString();
            }
            set
            {
                cboCurrency.EditValue = value;
                if (value == CurrencyAccounting)
                    cboExchangRate.Enabled = false;
            }
        }
        public decimal ExchangeRate
        {
            get
            {
                return Convert.ToDecimal(cboExchangRate.EditValue ?? 0);
            }
            set
            {
                cboExchangRate.EditValue = value;
            }
        }
        public decimal TotalAmountOc
        {
            get
            {
                var depositDetail = (List<DepositDetailModel>)bindingSourceDetail.DataSource;
                var depositDetailParallel = (List<DepositDetailParallelModel>)bindingSourceDetailParallel.DataSource;

                return ((depositDetail != null && depositDetail.Count > 0) ? depositDetail.Sum(s => s.AmountOc) : 0);
                //return ((depositDetail != null && depositDetail.Count > 0) ? depositDetail.Sum(s => s.AmountOc) : 0) + ((depositDetailParallel != null && depositDetailParallel.Count > 0) ? depositDetailParallel.Sum(s => s.AmountOc) : 0);
            }
            set { }
        }
        public decimal TotalAmountExchange
        {
            get
            {
                var depositDetail = (List<DepositDetailModel>)bindingSourceDetail.DataSource;
                var depositDetailParallel = (List<DepositDetailParallelModel>)bindingSourceDetailParallel.DataSource;

                return ((depositDetail != null && depositDetail.Count > 0) ? depositDetail.Sum(s => s.AmountExchange) : 0);

                //return ((depositDetail != null && depositDetail.Count > 0) ? depositDetail.Sum(s => s.AmountExchange) : 0) + ((depositDetailParallel != null && depositDetailParallel.Count > 0) ? depositDetailParallel.Sum(s => s.AmountExchange) : 0);
            }
            set { }
        }
        public string JournalMemo
        {
            get { return txtDescription.Text; }
            set { txtDescription.Text = value; }
        }
        public bool IsIncludeCharge
        {
            get { return chkIncludeCharge.Checked; }
            set { chkIncludeCharge.Checked = value; }
        }

        public IList<DepositDetailModel> DepositDetails
        {
            get
            {
                grdDetail.RefreshDataSource();
                return bindingSourceDetail.DataSource as List<DepositDetailModel> ?? new List<DepositDetailModel>();
            }
            set
            {
                if (value.Count > 0)
                {
                    bindingSourceDetail.DataSource = value;
                }
                else
                {
                    var refType = RefTypes.Where(w => w.RefTypeId == (int)RefType.ReceiptDeposite)?.FirstOrDefault() ?? null;
                    if (refType != null)
                        bindingSourceDetail.DataSource = new List<DepositDetailModel> { new DepositDetailModel() { AccountNumber = refType.DefaultDebitAccountId, CorrespondingAccountNumber = refType.DefaultCreditAccountId } };
                    else
                        bindingSourceDetail.DataSource = new List<DepositDetailModel> { new DepositDetailModel() };
                }

                ColumnsCollection.Clear();
                //bindingSourceDetail.DataSource = value.Count == 0 ? new List<DepositDetailModel> { new DepositDetailModel { CorrespondingAccountNumber = "11221" } } : value;
                gridViewDetail.PopulateColumns(value);
                ColumnsCollection.Clear();
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefDetailId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DetailBy", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AutoBusinessId", ColumnCaption = "ĐK tự động", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 80, ToolTip = "Định khoản tự động", FixedColumn = FixedStyle.Left, AllowEdit = true, RepositoryControl = _rpsAutoBusiness });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountNumber", ColumnCaption = "TK Nợ", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 60, ToolTip = "Tài khoản nợ", FixedColumn = FixedStyle.Left, AllowEdit = true, RepositoryControl = _rpsAccountNumber });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CorrespondingAccountNumber", ColumnCaption = "TK Có", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 60, ToolTip = "Tài khoản có", FixedColumn = FixedStyle.Left, AllowEdit = true, RepositoryControl = _rpsCorrespondingAccountNumber });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnCaption = "Diễn giải", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 250, FixedColumn = FixedStyle.Left, AllowEdit = true, IsSummaryText = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AmountOc", ColumnCaption = "Số tiền", ColumnPosition = 5, ColumnVisible = true, ColumnWith = 150, FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Decimal, AllowEdit = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AmountExchange", ColumnCaption = "Quy đổi", ColumnPosition = 6, ColumnVisible = true, ColumnWith = 150, FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Decimal, AllowEdit = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Charge", ColumnCaption = "Phí NH", ColumnPosition = 7, ColumnVisible = IsIncludeCharge, ColumnWith = 150, FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Decimal, AllowEdit = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ChargeExchange", ColumnCaption = "Phí NH quy đổi", ColumnPosition = 8, ColumnVisible = IsIncludeCharge, ColumnWith = 150, FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Decimal, AllowEdit = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceCode", ColumnCaption = "Nguồn vốn", ColumnPosition = 9, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.None, AllowEdit = true, RepositoryControl = _rpsBudgetSource });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemCode", ColumnCaption = "Mục/TM", ColumnPosition = 10, ColumnVisible = true, ColumnWith = 100, ToolTip = "Mục/Tiểu mục", FixedColumn = FixedStyle.None, AllowEdit = true, RepositoryControl = _rpsBudgetItem });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "VoucherTypeId", ColumnCaption = "Nghiệp vụ", ColumnPosition = 11, ColumnVisible = true, ColumnWith = 130, FixedColumn = FixedStyle.None, AllowEdit = true, RepositoryControl = _rpsVoucherTypeId });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DepartmentId", ColumnCaption = "Phòng ban", ColumnPosition = 12, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.None, AllowEdit = true, RepositoryControl = _rpsDepartment });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectId", ColumnCaption = "Đối tượng khác", ColumnPosition = 13, ColumnVisible = false, ColumnWith = 100, FixedColumn = FixedStyle.None, AllowEdit = true, RepositoryControl = _rpsAccountingObject });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "MergerFundId", ColumnCaption = "Quỹ sát nhập", ColumnPosition = 14, ColumnVisible = false, ColumnWith = 100, FixedColumn = FixedStyle.None, AllowEdit = true, RepositoryControl = _rpsMergerFund });
                //ColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectId", ColumnCaption = "Dự án", ColumnPosition = 15, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.None, AllowEdit = true, RepositoryControl = _rpsProject });
                gridViewDetail = InitGridLayout(ColumnsCollection, gridViewDetail);
                SetNumericFormatControl(gridViewDetail, true);
            }
        }

        public IList<DepositDetailParallelModel> DepositDetailParallels
        {
            get
            {
                //gridAccountingParallel.RefreshDataSource();
                gridViewAccountingPararell.CloseEditor();
                return (List<DepositDetailParallelModel>)bindingSourceDetailParallel.DataSource ?? new List<DepositDetailParallelModel>();
            }
            set
            {
                var depositDetailParallel = value == null ? new List<DepositDetailParallelModel>() : value;
                bindingSourceDetailParallel.DataSource = depositDetailParallel;
                gridViewAccountingPararell.PopulateColumns(depositDetailParallel);

                var columnsCollection = new List<XtraColumn>()
                {
                    new XtraColumn() { ColumnName = "RefDetailId", ColumnVisible = false },
                    new XtraColumn() { ColumnName = "RefId", ColumnVisible = false },
                    new XtraColumn() { ColumnName = "AccountNumber", ColumnVisible = true, ColumnWith = 100, ColumnCaption = "TK Nợ", ColumnPosition = 1, AllowEdit = true, RepositoryControl = _rpsAccountNumberParalell },
                    new XtraColumn() { ColumnName = "CorrespondingAccountNumber", ColumnVisible = true, ColumnWith = 100, ColumnCaption = "TK Có", ColumnPosition = 2, AllowEdit = true, RepositoryControl = _rpsCorrespondingAccountNumberParalell},
                    new XtraColumn() { ColumnName = "Description", ColumnVisible = true, ColumnWith = 350, ColumnCaption = "Diễn giải", ColumnPosition = 3, AllowEdit = true, IsSummaryText = true },
                    new XtraColumn() { ColumnName = "AmountOc", ColumnVisible = true, ColumnWith = 100, ColumnCaption = "Số tiền", ColumnPosition = 4, AllowEdit = true, IsSummnary = true, ColumnType = UnboundColumnType.Decimal },
                    new XtraColumn() { ColumnName = "AmountExchange", ColumnVisible = true, ColumnWith = 100, ColumnCaption = "Quy đổi", ColumnPosition = 5, AllowEdit = true , IsSummnary = true, ColumnType = UnboundColumnType.Decimal },
                    new XtraColumn() { ColumnName = "BudgetSourceCode", ColumnVisible = true, ColumnWith = 100, ColumnCaption = "Nguồn vốn", ColumnPosition = 6, AllowEdit = true, RepositoryControl = _rpsBudgetSourceParalell },
                    new XtraColumn() { ColumnName = "AccountingObjectId", ColumnVisible = false, ColumnWith = 100, ColumnCaption = "Đối tượng khác", ColumnPosition = 7, AllowEdit = true, RepositoryControl = _rpsAccountingObjectParalell },
                    new XtraColumn() { ColumnName = "BudgetItemCode", ColumnVisible = true, ColumnWith = 100, ColumnCaption = "Mục/TM", ColumnPosition = 8, AllowEdit = true, RepositoryControl = _rpsBudgetItemParalell },
                    new XtraColumn() { ColumnName = "VoucherTypeId", ColumnVisible = true, ColumnWith = 100, ColumnCaption = "Nghiệp vụ", ColumnPosition = 9, AllowEdit = true, RepositoryControl = _rpsVoucherTypeIdParalell },
                    new XtraColumn() { ColumnName = "DepartmentId", ColumnVisible = true, ColumnWith = 100, ColumnCaption = "Phòng ban", ColumnPosition = 10, AllowEdit = true, RepositoryControl = _rpsDepartmentParalell },
                    new XtraColumn() { ColumnName = "MergerFundId", ColumnVisible = false, ColumnWith = 100, ColumnCaption = "", ColumnPosition = 11, AllowEdit = true },
                    //new XtraColumn() { ColumnName = "ProjectId", ColumnVisible = true, ColumnWith = 100, ColumnCaption = "Dự án", ColumnPosition = 12, AllowEdit = true, RepositoryControl = _rpsProjectParalell },
                    new XtraColumn() { ColumnName = "FixedAssetId", ColumnVisible = false, ColumnWith = 100, ColumnCaption = "CCDC", ColumnPosition = 13, AllowEdit = true, RepositoryControl = _rpsFixedAssetParalell },
                    new XtraColumn() { ColumnName = "InventoryItemId", ColumnVisible = false, ColumnWith = 100, ColumnCaption = "Vật tư", ColumnPosition = 14, AllowEdit = true, RepositoryControl = _rpsInventoryItemParalell },
                    new XtraColumn() { ColumnName = "EmployeeId", ColumnVisible = false, ColumnWith = 100, ColumnCaption = "Cán bộ", ColumnPosition = 15, AllowEdit = true, RepositoryControl = _rpsEmployeesParalell },
                    new XtraColumn() { ColumnName = "CustomerId", ColumnVisible = false, ColumnWith = 100, ColumnCaption = "Khác hàng", ColumnPosition = 15, AllowEdit = true, RepositoryControl = _rpsCustomerParalell },
                    new XtraColumn() { ColumnName = "VendorId", ColumnVisible = false, ColumnWith = 100, ColumnCaption = "NCC", ColumnPosition = 17, AllowEdit = true, RepositoryControl = _rpsVendorParalell },
                };

                gridViewAccountingPararell = InitGridLayout(columnsCollection, gridViewAccountingPararell);
                SetNumericFormatControl(gridViewAccountingPararell, true);
            }
        }

        public override IList<AccountModel> Accounts
        {
            set
            {
                if (value == null)
                    value = new List<AccountModel>();
                AccountLists = value;
                if (_rpsMasterAccountNumber == null)
                    _rpsMasterAccountNumber = new RepositoryItemGridLookUpEdit();
                _rpsMasterAccountNumber.KeyDown += repositoryItemGridLookUpEdit_KeyDown;
                if (_rpsAccountNumber == null)
                    _rpsAccountNumber = new RepositoryItemGridLookUpEdit();
                _rpsAccountNumber.KeyDown += repositoryItemGridLookUpEdit_KeyDown;
                if (_rpsCorrespondingAccountNumber == null)
                    _rpsCorrespondingAccountNumber = new RepositoryItemGridLookUpEdit();
                _rpsCorrespondingAccountNumber.KeyDown += repositoryItemGridLookUpEdit_KeyDown;

                if (_rpsMasterAccountNumberParalell == null)
                    _rpsMasterAccountNumberParalell = new RepositoryItemGridLookUpEdit();
                _rpsMasterAccountNumberParalell.KeyDown += repositoryItemGridLookUpEdit_KeyDown;

                if (_rpsAccountNumberParalell == null)
                    _rpsAccountNumberParalell = new RepositoryItemGridLookUpEdit();
                _rpsAccountNumber.KeyDown += repositoryItemGridLookUpEdit_KeyDown;
                GridLookUpItem.Account(value, _rpsAccountNumberParalell, "AccountCode", "AccountCode");

                if (_rpsCorrespondingAccountNumberParalell == null)
                    _rpsCorrespondingAccountNumberParalell = new RepositoryItemGridLookUpEdit();
                _rpsCorrespondingAccountNumberParalell.KeyDown += repositoryItemGridLookUpEdit_KeyDown;
                GridLookUpItem.Account(value, _rpsCorrespondingAccountNumberParalell, "AccountCode", "AccountCode");

                RefTypeModel refType = RefTypes.Where(w => w.RefTypeId == (int)BaseRefTypeId)?.FirstOrDefault() ?? null;
                if (refType != null)
                {
                    var lstAccounts = refType.DefaultDebitAccountCategoryId == null ? new List<string>() : refType.DefaultDebitAccountCategoryId.Split(new char[] { ';' }).ToList();
                    lstAccountNumbers = value.Where(w => lstAccounts.Contains(w.AccountCode) && ((CurrencyCode != null && w.CurrencyCode == CurrencyCode && w.IsCurrency == true) || w.IsCurrency == false || string.IsNullOrEmpty(w.CurrencyCode))).ToList() ?? new List<AccountModel>();
                    GridLookUpItem.Account(lstAccountNumbers, _rpsAccountNumber, "AccountCode", "AccountCode");
                    lstAccounts = refType.DefaultCreditAccountCategoryId == null ? new List<string>() : refType.DefaultCreditAccountCategoryId.Split(new char[] { ';' }).ToList();
                    GridLookUpItem.Account(value.Where(w => lstAccounts.Contains(w.AccountCode) && ((CurrencyCode != null && w.CurrencyCode == CurrencyCode && w.IsCurrency == true) || w.IsCurrency == false || string.IsNullOrEmpty(w.CurrencyCode))).ToList() ?? new List<AccountModel>(), _rpsCorrespondingAccountNumber, "AccountCode", "AccountCode");

                    if (!IsParentAccount)
                    {
                        GridLookUpItem.Account(value.Where(x => x.IsDetail).ToList(), _rpsMasterAccountNumber, "AccountCode", "AccountCode");
                    }
                    else
                    {
                        GridLookUpItem.Account(value.Where(x => x.AccountCode.IndexOf("111", StringComparison.Ordinal) == 0).ToList(), _rpsMasterAccountNumber, "AccountCode", "AccountCode");
                    }
                }
                else
                {
                    if (!IsParentAccount)
                    {
                        GridLookUpItem.Account(value.Where(x => x.AccountCode.IndexOf("111", StringComparison.Ordinal) == 0 && x.IsDetail).ToList(), _rpsAccountNumber, "AccountCode", "AccountCode");
                        GridLookUpItem.Account(value.Where(x => x.IsDetail).ToList(), _rpsMasterAccountNumber, "AccountCode", "AccountCode");
                        GridLookUpItem.Account(value.Where(x => x.IsDetail).ToList(), _rpsAccountNumberParalell, "AccountCode", "AccountCode");
                        GridLookUpItem.Account(value.Where(x => x.IsDetail).ToList(), _rpsMasterAccountNumberParalell, "AccountCode", "AccountCode");
                    }
                    else
                    {
                        GridLookUpItem.Account(value, _rpsAccountNumber, "AccountCode", "AccountCode");
                        GridLookUpItem.Account(value, _rpsMasterAccountNumberParalell, "AccountCode", "AccountCode");
                    }
                    GridLookUpItem.Account(value, _rpsCorrespondingAccountNumberParalell, "AccountCode", "AccountCode");
                }
            }
        }

        #endregion

        #region Override functions

        protected override void InitControls()
        {
            gridViewDetail.CellValueChanged += gridViewDetail_CellValueChanged;
        }
        protected override void InitData()
        {
            base.InitData();

            //_budgetItemsPrensenter.DisplayIsReceipt();

            if (MasterBindingSource.Current != null)
            {
                var receiptDepositId = ((DepositModel)MasterBindingSource.Current).RefId;
                KeyValue = receiptDepositId.ToString(CultureInfo.InvariantCulture);
                _keyForSend = KeyValue;
                RefId = long.Parse(KeyValue);
            }

            if (int.Parse(KeyValue) != 0)
            {
                _receiptDepositPresenter.Display(long.Parse(KeyValue));
            }
            else
            {
                RefId = 0;
                KeyValue = null;
                DepositDetails = new List<DepositDetailModel>();
                DepositDetailParallels = new List<DepositDetailParallelModel>();
                cboObjectCode.EditValue = null;
                //CurrencyCode = CurrencyAccounting;
                ExchangeRate = 1;
            }

            if (ActionMode == ActionModeVoucherEnum.AddNew)
            {
                AccountingObjectType = null;
                //cboObjectCode.Enabled = false;
            }
            if (ActionMode == ActionModeVoucherEnum.Edit)
            {
                if (IsIncludeCharge)
                    chkIncludeCharge.Enabled = false;
                else
                    chkIncludeCharge.Enabled = true;
            }
            cboObjectCategory.Focus();
            cboObjectCode.Focus();
            grdDetail.DataSource = bindingSourceDetail;
        }
        protected override long SaveData()
        {
            if (ActionMode == ActionModeVoucherEnum.Edit)
                RefId = (_keyForSend == null || long.Parse(_keyForSend) == 0) ? RefId : long.Parse(_keyForSend);
            if (ActionMode == ActionModeVoucherEnum.AddNew || ActionMode == ActionModeVoucherEnum.DuplicateVoucher)
                RefId = 0;

            var dialogResult= new DialogResult();
            if (DepositDetailParallels.Count > 0)
            {
                dialogResult = XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResAutoGenerateParallelUpdateQuestion"), ResourceHelper.GetResourceValueByName("ResAutoGenerateParallelCaption"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }
            else
            {
                dialogResult = XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResAutoGenerateParallelInsertQuestion"), ResourceHelper.GetResourceValueByName("ResAutoGenerateParallelCaption"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }

            var result = dialogResult == DialogResult.OK ? _receiptDepositPresenter.Save(true) : _receiptDepositPresenter.Save(false);
            if (result > 0)
            {
                _receiptDepositPresenter.Display(result);

                if (DepositDetails.Sum(s => s.Charge) == 0)
                {
                    var generalVoucher = new GenveralVoucherPresenter(null).GetGeneralVocher((int)RefType.ReceiptCash, result);
                    if (generalVoucher != null)
                    {
                        dialogResult = XtraMessageBox.Show(string.Format(ResourceHelper.GetResourceValueByName("ResGeneralVoucherDeleteQuestion"), EnumHelper.GetDescription(BaseRefTypeId))
                            , ResourceHelper.GetResourceValueByName("ResSuccessfullCaption"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.OK)
                        {
                            var deleteGeneralVoucher = new GenveralVoucherPresenter(null).Delete(generalVoucher.RefId);
                            if (deleteGeneralVoucher == 0)
                            {
                                XtraMessageBox.Show("Xóa không thành công. Vui lòng kiểm tra lại!", ResourceHelper.GetResourceValueByName("ResExceptionCaption"));
                            }
                        }
                    }
                }
                // sinh chứng từ chung
                if (IsIncludeCharge && (DepositDetails.Sum(s=>s.Charge) > 0 || DepositDetails.Sum(s=>s.ChargeExchange) > 0))
                {
                    dialogResult = new DialogResult();
                    var generalVoucher = new GenveralVoucherPresenter(null).GetGeneralVocher((int)RefType.ReceiptDeposite, result);
                    if (generalVoucher == null)
                    {
                        dialogResult = XtraMessageBox.Show(string.Format(ResourceHelper.GetResourceValueByName("ResGeneralVoucherInsertQuestion"), EnumHelper.GetDescription(BaseRefTypeId))
                            , ResourceHelper.GetResourceValueByName("ResSuccessfullCaption"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    }
                    else
                    {
                        dialogResult = XtraMessageBox.Show(string.Format(ResourceHelper.GetResourceValueByName("ResGeneralVoucherUpdateQuestion"), EnumHelper.GetDescription(BaseRefTypeId))
                            , ResourceHelper.GetResourceValueByName("ResSuccessfullCaption"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    }
                    if (dialogResult == DialogResult.OK)
                    {
                        var frmGeneralVoucher = new FrmXtraGeneralVoucherDetail();
                        frmGeneralVoucher.BaseRefTypeId = RefType.GeneralVoucher;
                        frmGeneralVoucher.ActionMode = generalVoucher == null ? ActionModeVoucherEnum.AddNew : ActionModeVoucherEnum.Edit;
                        frmGeneralVoucher.KeyValue = (generalVoucher?.RefId ?? 0).ToString();
                        frmGeneralVoucher.GeneralVocher = MakeGeneralVoucher(generalVoucher);
                        frmGeneralVoucher.GeneralVocher.DepositId = result;
                        frmGeneralVoucher.ShowDialog();
                    }
                }
                
            }
            return result;
        }
        protected override void RefreshNavigationButton()
        {
            base.RefreshNavigationButton();
        }
        protected override bool ValidData()
        {
            gridViewDetail.CloseEditor();
            gridViewDetail.UpdateCurrentRow();

            //if (cboObjectCategory.EditValue == null || cboObjectCategory.ToString() == "" || cboObjectCategory.EditValue.ToString() == "-1")
            //{
            //    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResReceiptOjectCategory"),
            //        ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
            //        MessageBoxIcon.Error);
            //    cboObjectCategory.Focus();
            //    return false;
            //}
            //if (AccountingObjectType == null)
            //{
            //    cboObjectCode.Enabled = false;
            //}
            //else
            //{
            //    if (ReferenceEquals(cboObjectCode.EditValue, null) || ReferenceEquals(cboObjectCode.EditValue, ""))
            //    {
            //        switch (AccountingObjectType)
            //        {
            //            case 0: //Nhà cung c?p
            //                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResReceiptVoucherVender"), ResourceHelper.GetResourceValueByName("ResReceiptVoucherVender"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                cboObjectCode.Focus();
            //                return false;
            //            case 1: // Nhân viên
            //                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResReceiptVoucherEmployee"), ResourceHelper.GetResourceValueByName("ResReceiptVoucherEmployee"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                cboObjectCode.Focus();
            //                return false;
            //            case 2: // Ð?i tu?ng khác
            //                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResReceiptVoucherAccountingOject"), ResourceHelper.GetResourceValueByName("ResReceiptVoucherAccountingOject"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                cboObjectCode.Focus();
            //                return false;
            //            case 3: //Khác hàng
            //                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResReceiptVoucherCustomer"), ResourceHelper.GetResourceValueByName("ResReceiptVoucherCustomer"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                cboObjectCode.Focus();
            //                return false;
            //        }
            //    }

            //    if (RefNo.Length == 0)
            //    {
            //        XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResRefNo"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        txtRefNo.Focus();
            //        return false;
            //    }
            //}

            if (dtRefDate.DateTime < DateTime.Parse(GlobalVariable.SystemDate))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResRefDate"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtRefDate.Focus();
                return false;
            }

            if (dtPostDate.DateTime < DateTime.Parse(GlobalVariable.SystemDate))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResPostDate"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtPostDate.Focus();
                return false;
            }

            if (DepositDetails.Count > 0)
            {
                int i = 0;
                var lstRowAmounts = new List<string>();
                foreach (var deposit in DepositDetails)
                {
                    deposit.AccountNumber = deposit.AccountNumber ?? "";
                    deposit.CorrespondingAccountNumber = deposit.CorrespondingAccountNumber ?? "";
                    // bắt lỗi thiếu thông tin trong tài khoản
                    if (!ValidAccountDetail(deposit))
                    {
                        //XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDetaiVoucherNotValid"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    if (deposit.AmountOc == 0)
                        lstRowAmounts.Add((i + 1).ToString());
                    var mdAccount = (AccountModel)_rpsCorrespondingAccountNumber.GetRowByKeyValue(deposit.AccountNumber);
                    var mdAccountCor = (AccountModel)_rpsCorrespondingAccountNumber.GetRowByKeyValue(deposit.CorrespondingAccountNumber);

                    if (i == 0)
                    {
                        BankAccountCode = deposit.AccountNumber;
                    }

                    if (deposit.AccountNumber == null)
                    {
                        XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResAccountNumber"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    if (deposit.CorrespondingAccountNumber == null)
                    {
                        XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ReceiptVoucherChildCorrespondingAccountNumberEmpty"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    if ((mdAccount?.IsCurrency ?? null) == true && (mdAccount?.CurrencyCode ?? "") != CurrencyCode && mdAccountCor?.CurrencyCode != null)
                    {
                        XtraMessageBox.Show("Bạn đang chọn tài khoản có theo tiền địa phương, bạn phải chọn lại !.", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    // Kiểm tra tài khoản chi tiết theo đối tượng nhà cung cấp và nhân viên
                    IList<AccountModel> aListAccount = new List<AccountModel>();
                    if (deposit.AccountNumber != null)
                    {
                        aListAccount.Add(mdAccount);
                    }
                    if (deposit.CorrespondingAccountNumber != null)
                    {
                        aListAccount.Add(mdAccountCor);
                    }
                    foreach (var strAccount in aListAccount)
                    {
                        if (strAccount.IsVendor && AccountingObjectType != 0)
                        {
                            XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResVendorId"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            cboObjectCode.Focus();
                            return false;
                        }
                        if (strAccount.IsEmployee && AccountingObjectType != 1)
                        {
                            XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResEmployeeId"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            cboObjectCode.Focus();
                            return false;
                        }
                        if (strAccount.IsAccountingObject && AccountingObjectType != 2)
                        {
                            XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResAccountingObjectId"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            cboObjectCode.Focus();
                            return false;
                        }
                        if (strAccount.IsCustomer && AccountingObjectType != 3)
                        {
                            XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResCustomerId"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            cboObjectCode.Focus();
                            return false;
                        }
                        //if (strAccount.IsProject && deposit.ProjectId == null)
                        //{
                        //    XtraMessageBox.Show("Bạn chưa nhập dự án tại dòng : " + (i + 1).ToString(), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //    return false;
                        //}
                    }
                    //Add by LinhMC
                    var isDetailValid = true;
                    if (deposit.DetailBy != null)
                    {
                        var detailFieldNames = deposit.DetailBy.Split(';');
                        detailFieldNames = detailFieldNames.Where(w => !w.Contains("ProjectId")).ToArray();
                        //Mã đối tượng từ phần master vào detail nên không cần kiểm tra chi tiết theo đối tượng
                        if (detailFieldNames.Any(t => deposit.GetType().GetProperty(t) != null && deposit.GetType().GetProperty(t).Name != "AccountingObjectId" && deposit[t] != null))
                        {
                            isDetailValid = false;
                        }
                        if (!isDetailValid)
                        {
                            XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDetaiVoucherNotValid"),
                                "Thống báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return false;
                        }
                    }

                    #region  TUDT:Kiểm tra tổng số tiền chi không vượt quá số tiền tồn quỹ

                    string budgetSourceCode = deposit.BudgetSourceCode;
                    decimal totalAmount; // tổng tiền chi tiền mặt( tiền quỹ)

                    // kiểm tra chi tiền khi số dư tiền mặt âm
                    if (deposit.CorrespondingAccountNumber.StartsWith("111"))
                    {
                        if (!DBOptionHelper.IsPaymentNegativeFund)
                        {
                            totalAmount = DepositDetails.Where(x =>
                                x.CorrespondingAccountNumber.StartsWith("111"))
                                .Sum(x => x.AmountOc);
                            GetCalculateCashBalance(deposit.CorrespondingAccountNumber,
                                ((DateTime)dtPostDate.EditValue).Month + "/" + ((DateTime)dtPostDate.EditValue).Day +
                                "/" + ((DateTime)dtPostDate.EditValue).Year); // thực thi để lây tiền cho phép chi

                            if (totalAmount > ClosingAmount)
                            {
                                XtraMessageBox.Show(
                                    "Số chi vượt quá số tồn tiền mặt, vui lòng kiểm tra lại!.", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                        }
                    }

                    // kiểm tra chi tiền khi số dư tiền gửi âm
                    if (deposit.CorrespondingAccountNumber.StartsWith("112"))
                    {
                        if (!DBOptionHelper.IsDepositeNegavtiveFund)
                        {
                            totalAmount = DepositDetails.Where(x => x.CorrespondingAccountNumber.StartsWith("112")).Sum(x => x.AmountOc);
                            GetCalculateDepositBalance(deposit.CorrespondingAccountNumber, ((DateTime)dtPostDate.EditValue).Month + "/" + ((DateTime)dtPostDate.EditValue).Day + "/" + ((DateTime)dtPostDate.EditValue).Year); // thực thi để lây tiền cho phép chi

                            if (totalAmount > ClosingAmount)
                            {
                                XtraMessageBox.Show("Số chi vượt quá số tồn quỹ, vui lòng kiểm tra lại. Số tồn quỹ hiện tại là: " + ClosingAmount + ' ' + CurrencyCode, ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                        }
                    }

                    // kiểm tra chi tiền khi nguồn âm
                    if (deposit.AccountNumber.StartsWith("461") || deposit.AccountNumber.StartsWith("661"))
                    {
                        if (!DBOptionHelper.IsPaymentNegativeBudgetSource)
                        {
                            // Số dư Có TK 4612
                            GetCalculateCapitalBalance("4612", budgetSourceCode, ((DateTime)dtPostDate.EditValue).Month + "/" + ((DateTime)dtPostDate.EditValue).Day + "/" + ((DateTime)dtPostDate.EditValue).Year); // thực thi để lây tiền cho phép chi
                            decimal accountBalance = ClosingAmount;

                            // Số dư Nợ TK 4612
                            GetCalculateCapitalBalance("6612", budgetSourceCode,
                                ((DateTime)dtPostDate.EditValue).Month + "/" + ((DateTime)dtPostDate.EditValue).Day +
                                "/" + ((DateTime)dtPostDate.EditValue).Year); // thực thi để lây tiền cho phép chi
                            accountBalance = accountBalance - ClosingAmount;

                            totalAmount = DepositDetails.Where(x => x.BudgetSourceCode == budgetSourceCode && (x.AccountNumber.StartsWith("461") || x.AccountNumber.StartsWith("661"))).Sum(x => x.AmountOc);
                            if (totalAmount > accountBalance)
                            {
                                XtraMessageBox.Show("Số chi vượt quá số tồn của nguồn, vui lòng kiểm tra lại. Số tồn hiện tại là: " + accountBalance + ' ' + CurrencyCode + " theo nguồn " + budgetSourceCode, ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                        }
                    }

                    #endregion

                    i = i + 1;
                }
                if (lstRowAmounts.Count > 0)
                    if (DialogResult.No == XtraMessageBox.Show("Số tiền bằng 0 tại dòng " + string.Join(", ", lstRowAmounts.ToArray()) + ". Bạn có muốn lưu chứng từ không?",
                            ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        return false;
                    }
            }

            

            switch (DepositDetails.Count)
            {
                case 0:
                    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResBalanceSide"),
                     ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                default:
                    return true;
            }
        }
        protected override void DeleteVoucher()
        {
            long refId = RefId > 0 ? RefId : long.Parse(_keyForSend);
            new ReceiptDepositPresenter(null).Delete(refId);
        }
        protected override void EditVoucher()
        {
            base.EditVoucher();
            InitData();
            cboCurrency_EditValueChanged(null, null);
        }

        #endregion

        #region Event

        public FrmXtraReceiptDepositDetail()
        {
            InitializeComponent();
            _receiptDepositPresenter = new ReceiptDepositPresenter(this);
        }

        private void FrmXtraReceiptDepositDetail_Load(object sender, EventArgs e)
        {
            AdjustControlSize(true, true);
        }

        private void FrmXtraReceiptDepositDetail_Resize(object sender, EventArgs e)
        {
            AdjustControlSize(true, true);
        }

        public override void gridViewDetail_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            base.gridViewDetail_CellValueChanged(sender, e);
            if (e.Column.FieldName == "Description")
            {
                var description = (string)gridViewDetail.GetFocusedRowCellValue("Description");
                txtDescription.Text = description;
            }

            gridViewDetail.PostEditor();
            var exchange = ExchangeRate;
            var amountOc = Convert.ToDecimal(gridViewDetail.GetRowCellValue(e.RowHandle, "AmountOc"));
            var amountEx = Convert.ToDecimal(gridViewDetail.GetRowCellValue(e.RowHandle, "AmountExchange"));
            var charge = Convert.ToDecimal(gridViewDetail.GetRowCellValue(e.RowHandle, "Charge"));
            var chargeExchange = Convert.ToDecimal(gridViewDetail.GetRowCellValue(e.RowHandle, "ChargeExchange"));
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

            if (e.Column.FieldName.Equals("Charge"))
            {
                if (exchange > 0)
                {
                    if (chargeExchange * exchange != charge)
                    {
                        var rowHandle = gridViewDetail.FocusedRowHandle;
                        gridViewDetail.SetRowCellValue(rowHandle, "ChargeExchange", Math.Round(charge / exchange, int.Parse(DBOptionHelper.CurrencyDecimalDigits)));
                    }
                }
            }

            if (e.Column.FieldName.Equals("AccountNumber"))
            {
                BankAccountCode = (gridViewDetail.GetRowCellValue(e.RowHandle, "AccountNumber") ?? "").ToString();
            }
            /*LinhMC comment Theo yêu cầu của Tư vấn khi muốn ép số tiền quy đổi, do bị lệch khi chia tỷ giá
             *Thay vào đó sửa thành nếu là tiền USD thì cho quy đổi ngược lại vì tỷ giá = 1 */
            //ThangNK comment lại: vì không cho phép tính ngược nguyên giá khi sửa tiền quy đổi
            //if (e.Column.FieldName.Equals("AmountExchange") && CurrencyCode != CurrencyLocal)
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
            //--------LinhMC: valid detail by account in Griddetail voucher---------// 
            if (!e.Column.FieldName.Equals("DetailBy"))
            {
                var accountNumber = gridViewDetail.GetFocusedRowCellValue("AccountNumber");
                var accountNumberDetailBy = "";
                if (accountNumber != null)
                {
                    accountNumberDetailBy = GetAccountDetailBy(accountNumber.ToString());
                }
                var correspondingAccountNumber = gridViewDetail.GetFocusedRowCellValue("CorrespondingAccountNumber");
                var correspondingAccountNumberDetailBy = "";
                if (correspondingAccountNumber != null)
                {
                    correspondingAccountNumberDetailBy = GetAccountDetailBy(correspondingAccountNumber.ToString());
                }

                accountNumberDetailBy = string.IsNullOrEmpty(accountNumberDetailBy)
                    ? correspondingAccountNumberDetailBy
                    : accountNumberDetailBy + ";" + correspondingAccountNumberDetailBy;

                var detailByArray = accountNumberDetailBy.Split(';').Distinct().ToArray();
                var detail = string.Join(";", detailByArray);
                gridViewDetail.SetRowCellValue(e.RowHandle, "DetailBy", detail);
            }

            //if (e.Column.FieldName == "BudgetItemCode")
            //{
            //    int rowHandle = gridViewDetail.FocusedRowHandle;
            //    if (gridViewDetail.GetRowCellValue(rowHandle, "BudgetItemCode") != null)
            //    {
            //        var budgetItemId = gridViewDetail.GetRowCellValue(rowHandle, "BudgetItemCode");
            //        var budgetItem = (BudgetItemModel)_rpsBudgetItem.GetRowByKeyValue(budgetItemId);
            //        if (budgetItem.BudgetItemCode == "494902")
            //        {
            //            gridViewDetail.SetRowCellValue(rowHandle, "VoucherTypeId", 2);
            //        }
            //        else if (budgetItem.BudgetItemCode == "779902")
            //        {
            //            gridViewDetail.SetRowCellValue(rowHandle, "VoucherTypeId", 3);
            //        }
            //        else
            //            gridViewDetail.SetRowCellValue(rowHandle, "VoucherTypeId", null);
            //    }
            //}

        }

        private void gridViewDetail_RowUpdated(object sender, RowObjectEventArgs e)
        {

        }

        protected override void cboCurrency_EditValueChanged(object sender, EventArgs e)
        {
            base.cboCurrency_EditValueChanged(sender, e);
            CurrencyCurrent = CurrencyCode;

            _accountsPresenter.DisplayActive();

            if (lstAccountNumbers != null && lstAccountNumbers.Count > 0)
            {
                var accountNumber = lstAccountNumbers.First()?.AccountCode ?? "";
                for (int i = 0; i < DepositDetails.Count; i++)
                {
                    gridViewDetail.SetRowCellValue(i, "AccountNumber", accountNumber);
                }
            }

        }

        //protected override void cboExchangRate_EditValueChanged(object sender, EventArgs e)
        //{
        //    base.cboExchangRate_EditValueChanged(sender, e);
        //    if (gridViewDetail.Columns["AmountOc"] != null && gridViewDetail.Columns["AmountExchange"] != null)
        //        for (var i = 0; i < gridViewDetail.RowCount; i++)
        //        {
        //            decimal amount = Convert.ToDecimal(gridViewDetail.GetRowCellValue(i, "AmountOc") ?? 0);
        //            if (ExchangeRate != 0)
        //                gridViewDetail.SetRowCellValue(i, "AmountExchange", Math.Round(amount / ExchangeRate, int.Parse(DBOptionHelper.CurrencyDecimalDigits)));
        //        }
        //}

        private void chkIncludeCharge_CheckedChanged(object sender, EventArgs e)
        {
            DepositDetails = DepositDetails;
        }

        #endregion

        #region Functions

        public GeneralVocherModel MakeGeneralVoucher(GeneralVocherModel generalVocher)
        {
            var result = new GeneralVocherModel();
            result.RefId = generalVocher?.RefId ?? 0;
            result.RefNo = generalVocher?.RefNo ?? "";
            result.JournalMemo = "Phí ngân hàng"; //this.JournalMemo;
            result.RefDate = this.RefDate.Value;
            result.PostedDate = this.PostedDate.Value;
            result.RefTypeId = (int)RefType.GeneralVoucher;
            // lấy nghiệp vụ thực chi
            var voucherType = new VoucherTypePresenter(null).GetVoucherTypeByCode("SalaryVoucher");
            foreach (var depositDetail in DepositDetails)
            {
                var generalDetail = new GeneralDetailModel();
                if(depositDetail.BudgetSourceCode != null)
                {
                    if(depositDetail.BudgetSourceCode.StartsWith("12") || depositDetail.BudgetSourceCode.StartsWith("15.2"))
                        generalDetail.AccountNumber = "6112";
                    if (depositDetail.BudgetSourceCode.StartsWith("13") || depositDetail.BudgetSourceCode.StartsWith("15.1"))
                        generalDetail.AccountNumber = "6111";
                }
                else
                {
                    generalDetail.AccountNumber = "6111";
                }
                //generalDetail.AccountNumber = "61118"; // depositDetail.AccountNumber;
                generalDetail.CorrespondingAccountNumber = "3371"; // depositDetail.CorrespondingAccountNumber;
                generalDetail.Description = depositDetail.Description;
                generalDetail.AmountOc = depositDetail.Charge;
                generalDetail.AmountExchange = depositDetail.ChargeExchange;
                generalDetail.CurrencyCode = this.CurrencyCode;
                generalDetail.ExchangeRate = this.ExchangeRate;
                generalDetail.VoucherTypeId = voucherType?.VoucherTypeId ?? null; // depositDetail.VoucherTypeId;
                generalDetail.BankId = this.BankId;
                generalDetail.BudgetItemCode = "7756"; // depositDetail.BudgetItemCode;
                generalDetail.BudgetSourceCode = depositDetail.BudgetSourceCode;
                generalDetail.DepartmentId = depositDetail.DepartmentId;
                generalDetail.AccountingObjectId = this.AccountingObjectId;
                generalDetail.CustomerId = this.CustomerId;
                generalDetail.VendorId = this.VendorId;
                generalDetail.EmployeeId = this.EmployeeId;
                //generalDetail.ProjectId = depositDetail.ProjectId;

                result.GeneralVoucherDetails.Add(generalDetail);
            }
            return result;
        }

        #endregion
    }
}
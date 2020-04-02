/***********************************************************************
 * <copyright file="FrmXtraFormPaymentVoucherDetail.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Hoàng Bích Sơn, thangnk modify
 * Email:    sonhb@buca.vn
 * Website:
 * Create Date: Wednesday, March 19, 2014
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
using TSD.AccountingSoft.Model.BusinessObjects.Cash;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Presenter.Cash.PaymentVoucher;
using TSD.AccountingSoft.View.Cash;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.Resources;
using TSD.Enum;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using TSD.AccountingSoft.Session;
using TSD.AccountingSoft.Presenter.Dictionary.Bank;
using TSD.AccountingSoft.WindowsForm.CommonClass;

namespace TSD.AccountingSoft.WindowsForm.FormBusiness
{

    /// <summary>
    /// FrmXtraFormPaymentVoucherDetail class
    /// </summary>
    public partial class FrmXtraFormPaymentVoucherDetail : FrmXtraBaseVoucherDetail, IPaymentVoucherView
    {
        #region Variable

        private readonly PaymentVoucherPresenter _paymentVoucherPresenter;

        private List<AccountModel> lstCorrespondingAccountNumbers;

        #endregion

        #region Properties

        public long RefId { get; set; }
        public int RefTypeId
        {
            get { return (int)BaseRefTypeId; }
            set { BaseRefTypeId = (RefType)value; }
        }
        public string RefNo
        {
            get { return txtRefNo.Text; }
            set { txtRefNo.Text = value; }
        }
        public string RefDate
        {
            get
            {
                return dtRefDate.DateTime.ToShortDateString();
            }
            set
            {
                dtRefDate.EditValue = DateTime.Parse(value);
            }
        }
        public string PostedDate
        {
            get
            {
                return dtPostDate.DateTime.ToShortDateString();
            }
            set
            {
                dtPostDate.EditValue = DateTime.Parse(value);
            }
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
        public string BankAccount
        {
            get
            {
                var objBank = (BankModel)cboBank.GetSelectedDataRow();
                if (objBank != null)
                    return objBank.BankAccount;
                return null;
            }
            set
            {

            }
        }
        public string Trader
        {
            get { return txtContactName.Text; }
            set { txtContactName.Text = value; }
        }
        public string CurrencyCode
        {
            get
            {
                if (cboCurrency.EditValue == null)
                    return null;
                else
                    return cboCurrency.EditValue.ToString();
            }
            set
            {
                cboCurrency.EditValue = value;
                if (value == CurrencyAccounting)
                    cboExchangRate.Enabled = false;
            }
        }
        public string AccountNumber { get; set; }
        public decimal TotalAmount
        {
            get { return (decimal)gridViewDetail.Columns["AmountOc"].SummaryItem.SummaryValue; }
            set { }
        }
        public decimal ExchangeRate
        {
            get
            {
                if (cboExchangRate.EditValue == null)
                    return 0;
                else
                    return Convert.ToDecimal(cboExchangRate.EditValue);
            }
            set
            {

                cboExchangRate.EditValue = value;
            }
        }
        public decimal TotalAmountExchange
        {
            get { return (decimal)gridViewDetail.Columns["AmountExchange"].SummaryItem.SummaryValue; }
            set { }
        }
        public string JournalMemo
        {
            get { return txtDescription.Text; }
            set { txtDescription.Text = value; }
        }
        public string DocumentInclude
        {
            get { return txtDocumentInclude.Text; }
            set { txtDocumentInclude.Text = value; }
        }

        public IList<CashDetailModel> PaymentVoucherDetails
        {
            get
            {
                var paymentVoucherDetail = new List<CashDetailModel>();
                if (gridViewDetail.RowCount > 0)
                {
                    //decimal totalAmount = 0;
                    //decimal totalAmountExchange = 0;
                    for (var i = 0; i < gridViewDetail.RowCount; i++)
                    {
                        var rowVoucherDetailData = (CashDetailModel)gridViewDetail.GetRow(i);
                        if (rowVoucherDetailData != null)
                        {
                            var item = new CashDetailModel
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
                                MergerFundId = rowVoucherDetailData.MergerFundId == 0 ? null : rowVoucherDetailData.MergerFundId,
                                //ProjectId = rowVoucherDetailData.ProjectId == 0 ? null : rowVoucherDetailData.ProjectId,
                                DetailBy = rowVoucherDetailData.DetailBy,
                                AutoBusinessId = rowVoucherDetailData.AutoBusinessId
                            };
                            paymentVoucherDetail.Add(item);
                        }
                    }

                }
                return paymentVoucherDetail;
            }
            set
            {
                if (value.Count > 0)
                {
                    bindingSourceDetail.DataSource = value;
                }
                else
                {
                    var refType = RefTypes.Where(w => w.RefTypeId == (int)RefType.PaymentCash)?.First() ?? null;
                    if (refType != null)
                    {
                        bindingSourceDetail.DataSource = new List<CashDetailModel> { new CashDetailModel() { AccountNumber = refType.DefaultDebitAccountId, CorrespondingAccountNumber = refType.DefaultCreditAccountId } };
                        AccountNumber = refType.DefaultCreditAccountId;
                    }
                    else
                        bindingSourceDetail.DataSource = new List<CashDetailModel> { new CashDetailModel() };
                }

                ColumnsCollection.Clear();
                gridViewDetail.PopulateColumns(value);
                grdDetail.ForceInitialize();

                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefDetailId", ColumnVisible = false, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AutoBusinessId", ColumnCaption = "ĐK tự động", ToolTip = "Định khoản tự động", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 80, FixedColumn = FixedStyle.Left, AllowEdit = true, RepositoryControl = _rpsAutoBusiness });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountNumber", FixedColumn = FixedStyle.Left, ColumnCaption = "TK Nợ", ToolTip = "Tài khoản nợ", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 60, RepositoryControl = _rpsAccountNumber });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CorrespondingAccountNumber", FixedColumn = FixedStyle.Left, ColumnCaption = "TK Có", ToolTip = "Tài khoản có", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 60, RepositoryControl = _rpsCorrespondingAccountNumber });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", FixedColumn = FixedStyle.None, ColumnCaption = "Diễn giải", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 210, IsSummaryText = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AmountOc", FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Decimal, ColumnCaption = "Số tiền", ColumnPosition = 5, ColumnVisible = true, ColumnWith = 120 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AmountExchange", FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Decimal, ColumnCaption = "Quy đổi", ColumnPosition = 6, ColumnVisible = true, ColumnWith = 120 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceCode", FixedColumn = FixedStyle.None, ColumnCaption = "Nguồn vốn", ColumnPosition = 7, ColumnVisible = true, ColumnWith = 80, RepositoryControl = _rpsBudgetSource });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemCode", FixedColumn = FixedStyle.None, ColumnCaption = "Mục/TM", ToolTip = "Mục tiểu mục", ColumnPosition = 8, ColumnVisible = true, ColumnWith = 80, RepositoryControl = _rpsBudgetItem });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "VoucherTypeId", FixedColumn = FixedStyle.None, ColumnCaption = "Nghiệp vụ", ColumnPosition = 9, ColumnVisible = true, ColumnWith = 100, RepositoryControl = _rpsVoucherTypeId });
                //ColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectId", FixedColumn = FixedStyle.None, ColumnCaption = "Dự án", ColumnVisible = true, ColumnPosition = 10, ColumnWith = 100, RepositoryControl = _rpsProject });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectId", FixedColumn = FixedStyle.None, ColumnCaption = "Đối tượng khác", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "MergerFundId", FixedColumn = FixedStyle.None, ColumnCaption = "Quỹ sát nhập", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DetailBy", ColumnVisible = false });
                gridViewDetail = InitGridLayout(ColumnsCollection, gridViewDetail);
                SetNumericFormatControl(gridViewDetail, true);
            }
        }

        public IList<CashParalellDetailModel> CashParalellDetails
        {
            get
            {
                var paymentVoucherParalellDetail = new List<CashParalellDetailModel>();
                if (gridViewAccountingPararell.RowCount > 0)
                {
                    //decimal totalAmount = 0;
                    //decimal totalAmountExchange = 0;
                    for (var i = 0; i < gridViewAccountingPararell.RowCount; i++)
                    {
                        var rowVoucherDetailData = (CashParalellDetailModel)gridViewAccountingPararell.GetRow(i);
                        if (rowVoucherDetailData != null)
                        {
                            var item = new CashParalellDetailModel
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
                                MergerFundId = rowVoucherDetailData.MergerFundId == 0 ? null : rowVoucherDetailData.MergerFundId,
                                //ProjectId = rowVoucherDetailData.ProjectId == 0 ? null : rowVoucherDetailData.ProjectId,
                                DetailBy = rowVoucherDetailData.DetailBy
                            };
                            paymentVoucherParalellDetail.Add(item);
                        }
                    }

                }
                return paymentVoucherParalellDetail;
            }
            set
            {

                bindingSourceDetailParallel.DataSource = value;
                ColumnsCollectionParalell.Clear();
                gridViewAccountingPararell.PopulateColumns(value);
                gridAccountingParallel.ForceInitialize();

                ColumnsCollectionParalell.Add(new XtraColumn { ColumnName = "RefDetailId", ColumnVisible = false, Alignment = HorzAlignment.Center });
                ColumnsCollectionParalell.Add(new XtraColumn { ColumnName = "AutoBusinessId", ColumnCaption = "ĐK tự động", ToolTip = "Định khoản tự động", ColumnPosition = 1, ColumnVisible = false, ColumnWith = 80, FixedColumn = FixedStyle.Left, AllowEdit = true, RepositoryControl = _rpsAutoBusinessParalell });
                ColumnsCollectionParalell.Add(new XtraColumn
                {
                    ColumnName = "AccountNumber",
                    FixedColumn = FixedStyle.Left,
                    ColumnCaption = "TK Nợ",
                    ToolTip = "Tài khoản nợ",
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 60,
                    RepositoryControl = _rpsAccountNumberParalell
                });
                ColumnsCollectionParalell.Add(new XtraColumn
                {
                    ColumnName = "CorrespondingAccountNumber",
                    FixedColumn = FixedStyle.Left,
                    ColumnCaption = "TK Có",
                    ToolTip = "Tài khoản có",
                    ColumnPosition = 3,
                    ColumnVisible = true,
                    ColumnWith = 60,
                    RepositoryControl = _rpsCorrespondingAccountNumberParalell,
                    AllowEdit = true
                });
                ColumnsCollectionParalell.Add(new XtraColumn { ColumnName = "Description", FixedColumn = FixedStyle.None, ColumnCaption = "Diễn giải", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 210, IsSummaryText = true });
                ColumnsCollectionParalell.Add(new XtraColumn { ColumnName = "AmountOc", FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Decimal, ColumnCaption = "Số tiền", ColumnPosition = 5, ColumnVisible = true, ColumnWith = 120 });
                ColumnsCollectionParalell.Add(new XtraColumn { ColumnName = "AmountExchange", FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Decimal, ColumnCaption = "Quy đổi", ColumnPosition = 6, ColumnVisible = true, ColumnWith = 120 });
                ColumnsCollectionParalell.Add(new XtraColumn { ColumnName = "BudgetSourceCode", FixedColumn = FixedStyle.None, ColumnCaption = "Nguồn vốn", ColumnPosition = 7, ColumnVisible = true, ColumnWith = 80, RepositoryControl = _rpsBudgetSourceParalell });
                ColumnsCollectionParalell.Add(new XtraColumn { ColumnName = "BudgetItemCode", FixedColumn = FixedStyle.None, ColumnCaption = "Mục/TM", ToolTip = "Mục tiểu mục", ColumnPosition = 8, ColumnVisible = true, ColumnWith = 80, RepositoryControl = _rpsBudgetItemParalell });
                ColumnsCollectionParalell.Add(new XtraColumn { ColumnName = "VoucherTypeId", FixedColumn = FixedStyle.None, ColumnCaption = "Nghiệp vụ", ColumnPosition = 9, ColumnVisible = true, ColumnWith = 100, RepositoryControl = _rpsVoucherTypeIdParalell });
                //ColumnsCollectionParalell.Add(new XtraColumn { ColumnName = "ProjectId", FixedColumn = FixedStyle.None, ColumnCaption = "Dự án", ColumnVisible = true, ColumnPosition = 10, ColumnWith = 100, RepositoryControl = _rpsProjectParalell });
                ColumnsCollectionParalell.Add(new XtraColumn { ColumnName = "AccountingObjectId", FixedColumn = FixedStyle.None, ColumnCaption = "Đối tượng khác", ColumnVisible = false });
                ColumnsCollectionParalell.Add(new XtraColumn { ColumnName = "MergerFundId", FixedColumn = FixedStyle.None, ColumnCaption = "Quỹ sát nhập", ColumnVisible = false });
                ColumnsCollectionParalell.Add(new XtraColumn { ColumnName = "RefId", ColumnVisible = false });
                ColumnsCollectionParalell.Add(new XtraColumn { ColumnName = "DetailBy", ColumnVisible = false });
                gridViewAccountingPararell = InitGridLayout(ColumnsCollectionParalell, gridViewAccountingPararell);
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
                _rpsAccountNumberParalell.KeyDown += repositoryItemGridLookUpEdit_KeyDown;

                if (_rpsCorrespondingAccountNumberParalell == null)
                    _rpsCorrespondingAccountNumberParalell = new RepositoryItemGridLookUpEdit();
                _rpsCorrespondingAccountNumberParalell.KeyDown += repositoryItemGridLookUpEdit_KeyDown;

                GridLookUpItem.Account(value, _rpsAccountNumberParalell, "AccountCode", "AccountCode");
                GridLookUpItem.Account(value, _rpsCorrespondingAccountNumberParalell, "AccountCode", "AccountCode");

                RefTypeModel refType = RefTypes.Where(w => w.RefTypeId == (int)BaseRefTypeId)?.FirstOrDefault() ?? null;
                if (refType != null)
                {
                    var lstAccounts = refType.DefaultDebitAccountCategoryId == null ? new List<string>() : refType.DefaultDebitAccountCategoryId.Split(new char[] { ';' }).ToList();
                    GridLookUpItem.Account(value.Where(w => lstAccounts.Contains(w.AccountCode) && ((CurrencyCode != null && w.CurrencyCode == CurrencyCode && w.IsCurrency == true) || w.IsCurrency == false || string.IsNullOrEmpty(w.CurrencyCode))).ToList() ?? new List<AccountModel>(), _rpsAccountNumber, "AccountCode", "AccountCode");
                    lstAccounts = refType.DefaultCreditAccountCategoryId == null ? new List<string>() : refType.DefaultCreditAccountCategoryId.Split(new char[] { ';' }).ToList();
                    lstCorrespondingAccountNumbers = value.Where(w => lstAccounts.Contains(w.AccountCode) && ((CurrencyCode != null && w.CurrencyCode == CurrencyCode && w.IsCurrency == true) || w.IsCurrency == false || string.IsNullOrEmpty(w.CurrencyCode))).ToList() ?? new List<AccountModel>();
                    GridLookUpItem.Account(lstCorrespondingAccountNumbers, _rpsCorrespondingAccountNumber, "AccountCode", "AccountCode");

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

        protected override void RefreshNavigationButton()
        {
            string strCurrencyCode = (string)gridViewMaster.GetRowCellValue(0, "CurrencyCode");
            string strAccountNumber = (string)gridViewMaster.GetRowCellValue(0, "AccountNumber");
            ShowBarAmountExist(strAccountNumber, strCurrencyCode);
            base.RefreshNavigationButton();
        }

        protected override void EditVoucher()
        {
            var objectId = (int)cboObjectCategory.EditValue;
            LoadComboObjectCode(objectId);
            base.EditVoucher();
        }

        protected override void ReFreshControl()
        {
            //txtDocumentInclude.Text = "";
        }

        protected override void InitControls()
        {
            cboObjectCode.Properties.TextEditStyle = TextEditStyles.Standard;
            txtTaxCode.Visible = false;
        }

        protected override void InitData()
        {
            base.InitData();
            if (ActionMode == ActionModeVoucherEnum.None)
            {
                if (MasterBindingSource.Current != null)
                {
                    var paymentVoucherId = ((CashModel)MasterBindingSource.Current).RefId;
                    KeyValue = paymentVoucherId.ToString(CultureInfo.InvariantCulture);
                    //bổ sung
                    _keyForSend = KeyValue;
                    RefId = long.Parse(KeyValue);
                }
            }

            if (KeyValue == null)
            {
                PaymentVoucherDetails = new List<CashDetailModel>();
                CashParalellDetails = new List<CashParalellDetailModel>();
                var obj = _paymentVoucherPresenter.GetPaymentVoucherById(RefId);
                if (obj.AccountingObjectType != null)
                    LoadComboObjectCode((int)obj.AccountingObjectType);
                else
                {
                    AccountingObjectType = -1;
                    LoadComboObjectCode(-1);
                }
                cboObjectCode.Text = "";
                cboObjectCode.Enabled = true;
            }
            if (KeyValue != null)
            {
                _paymentVoucherPresenter.Display(int.Parse(KeyValue));
                if (AccountingObjectType != null)
                    LoadComboObjectCode((int)AccountingObjectType);
                if (ActionMode == ActionModeVoucherEnum.AddNew)
                {
                    PaymentVoucherDetails = new List<CashDetailModel>();
                    CashParalellDetails = new List<CashParalellDetailModel>();
                    SetObjectInfo(null, null, null, null);
                    KeyValue = null;
                    RefId = 0;
                    AccountingObjectType = 1;
                    LoadComboObjectCode(1);
                    cboObjectCode.Text = "";
                    cboObjectCode.Enabled = true;
                    txtDocumentInclude.Text = "";
                    txtDescription.Text = "";
                }
            }


            var strCurrencyCode = (string)gridViewMaster.GetRowCellValue(0, "CurrencyCode");
            var strAccountNumber = (string)gridViewMaster.GetRowCellValue(0, "AccountNumber");
            ShowBarAmountExist(strAccountNumber, strCurrencyCode);
        }

        protected override bool ValidData()
        {
            if (cboObjectCategory.EditValue == null || cboObjectCategory.ToString() == "" || cboObjectCategory.EditValue.ToString() == "-1")
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResReceiptOjectCategory"),
                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                cboObjectCategory.Focus();
                return false;
            }
            switch (AccountingObjectType)
            {
                case 0:
                    if (VendorId == null)
                    {
                        XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResReceiptVoucherVender"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cboObjectCode.Focus();
                        return false;
                    }
                    break;
                case 1:
                    if (EmployeeId == null)
                    {
                        XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResReceiptVoucherEmployee"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cboObjectCode.Focus();
                        return false;
                    }
                    break;
                case 2:
                    if (AccountingObjectId == null)
                    {
                        XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResReceiptVoucherAccountingOject"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cboObjectCode.Focus();
                        return false;
                    }
                    break;
                case 3:
                    if (CustomerId == null)
                    {
                        XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResReceiptVoucherCustomer"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cboObjectCode.Focus();
                        return false;
                    }
                    break;
            }
            if (RefNo.Length == 0)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResRefNo"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRefNo.Focus();
                return false;
            }

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

            var paymentVoucherDetails = PaymentVoucherDetails;
            if (paymentVoucherDetails.Count == 0)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResTotalAmount"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (paymentVoucherDetails.Count > 0)
            {
                int i = 0;
                var lstRowAmounts = new List<string>();
                foreach (var voucher in paymentVoucherDetails)
                {
                    voucher.AccountNumber = voucher.AccountNumber ?? "";
                    voucher.CorrespondingAccountNumber = voucher.CorrespondingAccountNumber ?? "";
                    // bắt lỗi thiếu thông tin trong tài khoản
                    if (!ValidAccountDetail(voucher, i + 1))
                    {
                        //XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDetaiVoucherNotValid"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    if (voucher.AmountOc == 0)
                        lstRowAmounts.Add((i + 1).ToString());
                    var strAccountNumberDetail = (string)gridViewDetail.GetRowCellValue(i, "AccountNumber");

                    //if (voucher.CorrespondingAccountNumber != AccountNumber)
                    //{
                    //    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResCorrespondingAccountNumberCompareMaster"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    return false;
                    //}
                    if (voucher.AccountNumber == null)
                    {
                        XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResAccountNumber"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    var strCurrency = CurrencyCode;

                    var rowValue = (AccountModel)_rpsAccountNumber.GetRowByKeyValue(strAccountNumberDetail);
                    if (rowValue.IsCurrency && rowValue.CurrencyCode != strCurrency && rowValue.CurrencyCode != null)
                    {
                        XtraMessageBox.Show("Bạn đang chọn tài khoản nợ theo loại tiền tệ sai, bạn phải chọn lại tại dòng: " + (i + 1), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    // bẫy lỗi ,0-nhà cung cấp,1-nhân viên, 2-đối tượng khác

                    rowValue = (AccountModel)_rpsAccountNumber.GetRowByKeyValue(strAccountNumberDetail);
                    int obj = int.Parse(cboObjectCategory.EditValue.ToString());
                    if (rowValue.IsVendor && obj != 0) //Nhà cung cấp
                    {
                        XtraMessageBox.Show("Bạn chưa chọn nhà cung cấp theo tài khoản " + strAccountNumberDetail + " tại dòng: " + (i + 1), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    if (rowValue.IsVendor && obj == 0)
                    {
                        gridViewDetail.SetRowCellValue(i, gridViewDetail.Columns["VendorId"], (int)cboObjectCode.EditValue);
                    }
                    if (rowValue.IsEmployee && obj != 1) //Nhân viên
                    {
                        XtraMessageBox.Show("Bạn chưa chọn nhân viên theo tài khoản " + strAccountNumberDetail + " tại dòng: " + (i + 1), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    if (rowValue.IsEmployee && obj == 1)
                    {
                        gridViewDetail.SetRowCellValue(i, gridViewDetail.Columns["EmployeeId"], (int)cboObjectCode.EditValue);
                    }
                    if (rowValue.IsAccountingObject && obj != 2) //Đối tượng khác
                    {
                        XtraMessageBox.Show("Bạn chưa chọn đối tượng khác theo tài khoản " + strAccountNumberDetail + " tại dòng: " + (i + 1), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    if (rowValue.IsAccountingObject && obj == 2)
                    {
                        gridViewDetail.SetRowCellValue(i, gridViewDetail.Columns["AccountingObjectId"], (int)cboObjectCode.EditValue);
                    }

                    if (voucher.AccountNumber.StartsWith("111") || voucher.CorrespondingAccountNumber.StartsWith("111"))
                    {
                        if (string.IsNullOrEmpty(DocumentInclude))
                        {
                            XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResReceiptDocumentInclude"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtDocumentInclude.Focus();
                            return false;
                        }
                    }

                    #region  TUDT:Kiểm tra tổng số tiền chi không vượt quá số tiền tồn quỹ

                    CurrencyCurrent = strCurrency; // Tiền hạch toán
                    string budgetSourceCode = voucher.BudgetSourceCode;
                    decimal totalAmount; // tổng tiền chi tiền mặt( tiền quỹ)

                    // kiểm tra chi tiền khi số dư tiền mặt âm
                    if (voucher.CorrespondingAccountNumber.StartsWith("111"))
                    {
                        if (string.IsNullOrEmpty(txtDocumentInclude.Text))
                        {
                            XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResReceiptDocumentInclude"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtDocumentInclude.Focus();
                            return false;
                        }
                        if (!DBOptionHelper.IsPaymentNegativeFund)
                        {
                            totalAmount = PaymentVoucherDetails.Where(x => x.CorrespondingAccountNumber.StartsWith("111")).Sum(x => x.AmountOc);
                            GetCalculateCashBalance(voucher.CorrespondingAccountNumber, ((DateTime)dtPostDate.EditValue).Month + "/" + ((DateTime)dtPostDate.EditValue).Day + "/" + ((DateTime)dtPostDate.EditValue).Year); // thực thi để lây tiền cho phép chi

                            if (totalAmount > ClosingAmount)
                            {
                                XtraMessageBox.Show("Số chi vượt quá số tồn tiền mặt, vui lòng kiểm tra lại!.", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                        }
                    }

                    // kiểm tra chi tiền khi số dư tiền gửi âm
                    if (voucher.CorrespondingAccountNumber.StartsWith("112"))
                    {
                        if (!DBOptionHelper.IsDepositeNegavtiveFund)
                        {
                            totalAmount = PaymentVoucherDetails.Where(x =>
                                x.CorrespondingAccountNumber.StartsWith("112"))
                                .Sum(x => x.AmountOc);
                            GetCalculateDepositBalance(voucher.CorrespondingAccountNumber,
                                ((DateTime)dtPostDate.EditValue).Month + "/" + ((DateTime)dtPostDate.EditValue).Day +
                                "/" + ((DateTime)dtPostDate.EditValue).Year); // thực thi để lây tiền cho phép chi

                            if (totalAmount > ClosingAmount)
                            {
                                XtraMessageBox.Show("Số chi vượt quá số tồn quỹ, vui lòng kiểm tra lại!.", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                        }
                    }

                    // kiểm tra chi tiền khi nguồn âm
                    if (voucher.AccountNumber.StartsWith("461") || voucher.AccountNumber.StartsWith("661"))
                    {
                        if (!DBOptionHelper.IsPaymentNegativeBudgetSource)
                        {
                            // Số dư Có TK 4612
                            GetCalculateCapitalBalance("4612", budgetSourceCode,
                                ((DateTime)dtPostDate.EditValue).Month + "/" + ((DateTime)dtPostDate.EditValue).Day +
                                "/" + ((DateTime)dtPostDate.EditValue).Year); // thực thi để lây tiền cho phép chi
                            decimal accountBalance = ClosingAmount;

                            // Số dư Nợ TK 4612
                            GetCalculateCapitalBalance("6612", budgetSourceCode,
                                ((DateTime)dtPostDate.EditValue).Month + "/" + ((DateTime)dtPostDate.EditValue).Day +
                                "/" + ((DateTime)dtPostDate.EditValue).Year); // thực thi để lây tiền cho phép chi
                            accountBalance = accountBalance - ClosingAmount;

                            totalAmount = PaymentVoucherDetails.Where(x =>
                                x.BudgetSourceCode == budgetSourceCode &&
                                (x.AccountNumber.StartsWith("461") || x.AccountNumber.StartsWith("661")))
                                .Sum(x => x.AmountOc);
                            if (totalAmount > accountBalance)
                            {
                                XtraMessageBox.Show(
                                    "Số chi vượt quá số tồn của nguồn, vui lòng kiểm tra lại!",
                                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                                return false;
                            }
                        }
                    }

                    #endregion

                    // bắt lỗi các cột trên gridDetail
                    bool isDetailValid = true;
                    if (voucher.DetailBy != null)
                    {
                        string[] detailFieldNames = voucher.DetailBy.Split(';');
                        detailFieldNames = detailFieldNames.Where(w => !w.Contains("ProjectId")).ToArray();
                        //Mã đối tượng từ phần master vào detail nên không cần kiểm tra chi tiết theo đối tượng
                        if (
                            detailFieldNames.Any(
                                t =>
                                    voucher.GetType().GetProperty(t) != null &&
                                    voucher.GetType().GetProperty(t).Name != "AccountingObjectId" && voucher[t] != null))
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
                    i = i + 1;
                }
                if (lstRowAmounts.Count > 0)
                    if (DialogResult.No == XtraMessageBox.Show("Số tiền bằng 0 tại dòng " + string.Join(", ", lstRowAmounts.ToArray()) + ". Bạn có muốn lưu chứng từ không?",
                            ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        return false;
                    }
            }
            return true;
        }

        protected override long SaveData()
        {
            if (ActionMode == ActionModeVoucherEnum.Edit)
                RefId = _keyForSend == null ? RefId : long.Parse(_keyForSend);
            if (ActionMode == ActionModeVoucherEnum.AddNew || ActionMode == ActionModeVoucherEnum.DuplicateVoucher)
                RefId = 0;
            cboObjectCode.Focus();

            var result = new DialogResult();


            result = XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResAutoGenerateParallelInsertQuestion"), ResourceHelper.GetResourceValueByName("ResAutoGenerateParallelCaption"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            return result == DialogResult.Yes ? _paymentVoucherPresenter.Save(true) : _paymentVoucherPresenter.Save(false);

            //return _paymentVoucherPresenter.Save();
        }

        protected override void DeleteVoucher()
        {
            try
            {
                var refId = RefId > 0 ? RefId : long.Parse(_keyForSend);
                _paymentVoucherPresenter.Delete(refId);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.StackTrace);
            }

        }

        protected override void InitCompareData()
        {
            //_paymentVoucherPresenter.Initialize();
        }

        #endregion

        #region Events

        public FrmXtraFormPaymentVoucherDetail()
        {
            InitializeComponent();
            _paymentVoucherPresenter = new PaymentVoucherPresenter(this);
        }

        private void FrmXtraFormPaymentVoucherDetail_Load(object sender, EventArgs e)
        {
            AdjustControlSize(true, true);
        }

        private void FrmXtraFormPaymentVoucherDetail_Resize(object sender, EventArgs e)
        {
            AdjustControlSize(true, true);
        }

        private void SetObjectInfo(string objectName, string trader, string address, string taxCode)
        {
            cboObjectName.Text = objectName;
            txtContactName.Text = trader;
            txtAddress.Text = address;
            txtTaxCode.Text = taxCode;
        }

        private void dtPostDate_Closed(object sender, ClosedEventArgs e)
        {
            dtRefDate.DateTime = dtPostDate.DateTime;
        }

        public override void gridViewDetail_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            base.gridViewDetail_CellValueChanged(sender, e);
            try
            {
                gridViewDetail.PostEditor();


                if (e.Column.FieldName == "Description")
                {
                    var description = (string)gridViewDetail.GetRowCellValue(e.RowHandle, "Description");
                    txtDescription.Text = description;
                }

                if (!e.Column.FieldName.Equals("CorrespondingAccountNumber"))
                {
                    AccountNumber = (gridViewDetail.GetFocusedRowCellValue("CorrespondingAccountNumber") ?? "").ToString();
                }

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

                if (e.Column.FieldName == "BudgetItemCode")
                {
                    int rowHandle = gridViewDetail.FocusedRowHandle;
                    if (gridViewDetail.GetRowCellValue(rowHandle, "BudgetItemCode") != null)
                    {
                        var budgetItemId = gridViewDetail.GetRowCellValue(rowHandle, "BudgetItemCode");
                        var budgetItem = (BudgetItemModel)_rpsBudgetItem.GetRowByKeyValue(budgetItemId);
                        if (budgetItem.BudgetItemCode == "494902")
                        {
                            gridViewDetail.SetRowCellValue(rowHandle, "VoucherTypeId", 2);
                        }
                        else if (budgetItem.BudgetItemCode == "779902")
                        {
                            gridViewDetail.SetRowCellValue(rowHandle, "VoucherTypeId", 3);
                        }
                        //else
                        //    gridViewDetail.SetRowCellValue(rowHandle, "VoucherTypeId", null);
                    }
                }
            }
            catch (Exception ex)
            {

                XtraMessageBox.Show(ex.ToString(),
                    ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void cboCurrency_EditValueChanged(object sender, EventArgs e)
        {
            base.cboCurrency_EditValueChanged(sender, e);

            _accountsPresenter.DisplayActive();

            if (lstCorrespondingAccountNumbers != null && lstCorrespondingAccountNumbers.Count > 0)
            {
                var accountNumber = lstCorrespondingAccountNumbers.First()?.AccountCode ?? "";
                for (int i = 0; i < PaymentVoucherDetails.Count; i++)
                {
                    gridViewDetail.SetRowCellValue(i, "CorrespondingAccountNumber", accountNumber);
                }
            }
        }

        #endregion
    }
}
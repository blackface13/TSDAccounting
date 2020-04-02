/***********************************************************************
 * <copyright file="FrmXtraPaymentDepositDetail.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   BangNC
 * Email:    BangNC@buca.vn
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
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using TSD.AccountingSoft.Model.BusinessObjects.Deposit;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Presenter.Deposit.PaymentDeposit;
using TSD.AccountingSoft.Session;
using TSD.AccountingSoft.View.Deposit;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.Resources;
using TSD.Enum;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using TSD.AccountingSoft.WindowsForm.CommonClass;

namespace TSD.AccountingSoft.WindowsForm.FormBusiness
{
    /// <summary>
    ///     FrmXtraPaymentDepositDetail
    /// </summary>
    public partial class FrmXtraPaymentDepositDetail : FrmXtraBaseVoucherDetail, IPaymentDepositView
    {
        #region Presenters

        private readonly PaymentDepositPresenter _paymentDepositPresenter;

        #endregion

        #region Variable

        private readonly RepositoryItemCalcEdit _rpsSpinEdit = new RepositoryItemCalcEdit();
        private List<AccountModel> lstCorrespondingAccountNumbers;

        #endregion

        #region Properties

        public long RefId { get; set; }

        public int RefTypeId
        {
            get { return (int)BaseRefTypeId; }
            set { BaseRefTypeId = (RefType)value; }
            // set { BaseRefTypeId = ActionMode == ActionModeVoucherEnum.Edit ? (RefType) value : BaseRefTypeId; }
        }

        public DateTime? RefDate
        {
            get
            {
                if (dtRefDate.EditValue == null)
                    return null;
                return Convert.ToDateTime(dtRefDate.DateTime.ToShortDateString());
            }
            set { dtRefDate.EditValue = value; }
        }

        public DateTime? PostedDate
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
                if (cboCurrency.EditValue == null)
                    return "";
                return cboCurrency.EditValue.ToString();
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

        public decimal TotalAmountOc { get; set; }

        public decimal TotalAmountExchange { get; set; }

        public string JournalMemo
        {
            get { return txtDescription.Text; }
            set { txtDescription.Text = value; }
        }

        public IList<DepositDetailModel> DepositDetails
        {
            get
            {
                var result = bindingSourceDetail.DataSource as List<DepositDetailModel> ?? new List<DepositDetailModel>();
                TotalAmountOc = result.Sum(s => s.AmountOc);
                TotalAmountExchange = result.Sum(s => s.AmountExchange);
                return result;
            }
            set
            {
                if (value.Count > 0)
                {
                    bindingSourceDetail.DataSource = value;
                }
                else
                {
                    var refType = RefTypes.Where(w => w.RefTypeId == (int)RefType.PaymentDeposite)?.First() ?? null;
                    if (refType != null)
                        bindingSourceDetail.DataSource = new List<DepositDetailModel> { new DepositDetailModel() { AccountNumber = refType.DefaultDebitAccountId, CorrespondingAccountNumber = refType.DefaultCreditAccountId } };
                    else
                        bindingSourceDetail.DataSource = new List<DepositDetailModel> { new DepositDetailModel() };
                }

                gridViewDetail.PopulateColumns(value);
                gridViewDetail.Appearance.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Center;
                ColumnsCollection.Clear();
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefDetailId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DetailBy", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "AutoBusinessId",
                    ColumnVisible = true,
                    ColumnCaption = "ĐK Tự động",
                    ColumnPosition = 1,
                    ColumnWith = 80,
                    FixedColumn = FixedStyle.Left,
                    AllowEdit = true,
                    ToolTip = "Định khoản tự động",
                    Alignment = HorzAlignment.Center,
                    RepositoryControl = _rpsAutoBusiness
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "AccountNumber",
                    ColumnCaption = "TK Nợ",
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 60,
                    FixedColumn = FixedStyle.Left,
                    AllowEdit = true,
                    ToolTip = "Tài khoản nợ",
                    Alignment = HorzAlignment.Center,
                    RepositoryControl = _rpsAccountNumber
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "CorrespondingAccountNumber",
                    ColumnCaption = "TK Có",
                    ColumnPosition = 3,
                    ColumnVisible = true,
                    ColumnWith = 60,
                    FixedColumn = FixedStyle.Left,
                    ToolTip = "Tài khoản có",
                    AllowEdit = true,
                    RepositoryControl = _rpsCorrespondingAccountNumber
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "Description",
                    ColumnCaption = "Diễn giải",
                    ColumnPosition = 4,
                    ColumnVisible = true,
                    ColumnWith = 250,
                    FixedColumn = FixedStyle.Left,
                    AllowEdit = true,
                    IsSummaryText = true
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "AmountOc",
                    ColumnCaption = "Số tiền",
                    ColumnPosition = 5,
                    ColumnVisible = true,
                    ColumnWith = 140,
                    FixedColumn = FixedStyle.None,
                    ColumnType = UnboundColumnType.Decimal,
                    AllowEdit = true
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "AmountExchange",
                    ColumnCaption = "Quy đổi",
                    ColumnPosition = 6,
                    ColumnVisible = true,
                    ColumnWith = 140,
                    FixedColumn = FixedStyle.None,
                    ColumnType = UnboundColumnType.Decimal,
                    AllowEdit = true
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetSourceCode",
                    ColumnCaption = "Nguồn vốn",
                    ColumnPosition = 7,
                    ColumnVisible = true,
                    ColumnWith = 80,
                    FixedColumn = FixedStyle.None,
                    AllowEdit = true,
                    RepositoryControl = _rpsBudgetSource
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetItemCode",
                    ColumnCaption = "Mục/TM",
                    ColumnPosition = 8,
                    ColumnVisible = true,
                    ColumnWith = 75,
                    FixedColumn = FixedStyle.None,
                    ToolTip = "Mục/Tiểu mục",
                    AllowEdit = true,
                    RepositoryControl = _rpsBudgetItem
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "VoucherTypeId",
                    ColumnCaption = "Nghiệp vụ",
                    ColumnPosition = 9,
                    ColumnVisible = true,
                    ColumnWith = 130,
                    FixedColumn = FixedStyle.None,
                    AllowEdit = true,
                    RepositoryControl = _rpsVoucherTypeId
                });
                //ColumnsCollection.Add(new XtraColumn
                //{
                //    ColumnName = "ProjectId",
                //    ColumnCaption = "Dự án",
                //    ColumnVisible = true,
                //    ColumnPosition = 10,
                //    ColumnWith = 80,
                //    FixedColumn = FixedStyle.None,
                //    AllowEdit = true,
                //    RepositoryControl = _rpsProject
                //});
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "DepartmentId",
                    ColumnCaption = "Phòng ban",
                    ColumnVisible = true,
                    ColumnPosition = 11,
                    ColumnWith = 80,
                    AllowEdit = true,
                    ToolTip = "Phòng ban",
                    Alignment = HorzAlignment.Center,
                    RepositoryControl = _rpsDepartment
                });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectId", ColumnCaption = "ĐT Khác", ColumnVisible = false, AllowEdit = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "MergerFundId", ColumnCaption = "Quỹ sát nhập", ColumnVisible = false, AllowEdit = true });

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
                    new XtraColumn() { ColumnName = "Description", ColumnVisible = true, ColumnWith = 350, ColumnCaption = "Diễn giải", ColumnPosition = 3, AllowEdit = true },
                    new XtraColumn() { ColumnName = "AmountOc", ColumnVisible = true, ColumnWith = 100, ColumnCaption = "Số tiền", ColumnPosition = 4, AllowEdit = true, IsSummnary = true, ColumnType = UnboundColumnType.Decimal },
                    new XtraColumn() { ColumnName = "AmountExchange", ColumnVisible = true, ColumnWith = 100, ColumnCaption = "Quy đổi", ColumnPosition = 5, AllowEdit = true, IsSummnary = true, ColumnType = UnboundColumnType.Decimal },
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

        protected override bool ValidData()
        {
            gridViewDetail.CloseEditor();
            gridViewDetail.UpdateCurrentRow();

            // Object
            //if (cboObjectCategory.EditValue == null || cboObjectCategory.ToString() == "" || cboObjectCategory.EditValue.ToString() == "-1")
            //{
            //    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResReceiptOjectCategory"),
            //        ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
            //        MessageBoxIcon.Error);
            //    cboObjectCategory.Focus();
            //    return false;
            //}
            //bool flag = true;
            //switch (AccountingObjectType)
            //{
            //    case 0: // nhà cung cấp
            //        if (VendorId == null)
            //        {
            //            XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResVendorId"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            cboObjectCode.Focus();
            //            flag = false;
            //        }
            //        break;
            //    case 1: // Nhân viên
            //        if (EmployeeId == null)
            //        {
            //            XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResEmployeeId"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            cboObjectCode.Focus();
            //            flag = false;
            //        }
            //        break;
            //    case 2: // Ðối tượng khác
            //        if (AccountingObjectId == null)
            //        {
            //            XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResAccountingObjectId"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            cboObjectCode.Focus();
            //            flag = false;
            //        }
            //        break;
            //    case 3: //Khác hàng
            //        if (CustomerId == null)
            //        {
            //            XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResCustomerId"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            cboObjectCode.Focus();
            //            flag = false;
            //        }
            //        break;
            //    default:
            //        if (AccountingObjectType == null)
            //        {
            //            XtraMessageBox.Show("Bạn chưa chọn loại đối tượng!", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            cboObjectCategory.Focus();
            //            flag = false;
            //        }
            //        break;
            //}
            //if (!flag)
            //{
            //    return false;
            //}

            // Ref No
            if (string.IsNullOrEmpty(RefNo))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResRefNo"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRefNo.Focus();
                return false;
            }

            // Ref Date
            if (dtRefDate.DateTime < DateTime.Parse(GlobalVariable.SystemDate))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResRefDate"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtRefDate.Focus();
                return false;
            }

            // Posted Date
            if (dtPostDate.DateTime < DateTime.Parse(GlobalVariable.SystemDate))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResPostDate"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtPostDate.Focus();
                return false;
            }

            // Deposit Detail
            if (DepositDetails.Count > 0)
            {
                int i = 0;
                var lstRowAmounts = new List<string>();
                foreach (DepositDetailModel voucher in DepositDetails)
                {
                    voucher.AccountNumber = voucher.AccountNumber ?? "";
                    voucher.CorrespondingAccountNumber = voucher.CorrespondingAccountNumber ?? "";
                    // bắt lỗi thiếu thông tin trong tài khoản
                    if (!ValidAccountDetail(voucher))
                    {
                        //XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDetaiVoucherNotValid"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    if (voucher.AmountOc == 0)
                        lstRowAmounts.Add((i + 1).ToString());
                    var mdAccount = (AccountModel)_rpsAccountNumber.GetRowByKeyValue(voucher.AccountNumber);
                    var mdAccountCor = (AccountModel)_rpsCorrespondingAccountNumber.GetRowByKeyValue(voucher.CorrespondingAccountNumber);
                    if (i == 0)
                        BankAccountCode = voucher.CorrespondingAccountNumber;

                    if (voucher.AccountNumber == null)
                    {
                        XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResAccountNumber"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    if (mdAccountCor.IsCurrency && mdAccountCor.CurrencyCode != CurrencyCode && mdAccountCor.CurrencyCode != null)
                    {
                        XtraMessageBox.Show("Bạn đang chọn tài khoản có theo loại tiền chưa đúng tại dòng " + (i + 1).ToString() + ". Vui lòng chọn lại !.", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    if (mdAccount.IsCurrency && mdAccount.CurrencyCode != CurrencyCode && mdAccount.CurrencyCode != null)
                    {
                        XtraMessageBox.Show("Bạn đang chọn tài khoản nợ theo loại tiền chưa đúng tại dòng " + (i + 1).ToString() + ". Vui lòng chọn lại !.", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    // Kiểm tra tài khoản chi tiết theo đối tượng nhà cung cấp và nhân viên
                    IList<AccountModel> aListAccount = new List<AccountModel>();
                    if (voucher.AccountNumber != null)
                    {
                        aListAccount.Add(mdAccount);
                    }
                    if (voucher.CorrespondingAccountNumber != null)
                    {
                        aListAccount.Add(mdAccountCor);
                    }

                    // Project
                    //var projectId = (int?)gridViewDetail.GetRowCellValue(i, "ProjectId");
                    //if (mdAccount.IsProject && projectId == null)
                    //{
                    //    XtraMessageBox.Show("Bạn chưa nhập dự án tại dòng : " + (i + 1).ToString(), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    return false;
                    //}

                    // Vendor
                    if (mdAccount.IsVendor)
                    {
                        if (AccountingObjectType != 0)
                        {
                            XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResVendorId"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            cboObjectCode.Focus();
                            return false;
                        }
                        gridViewDetail.SetRowCellValue(i, gridViewDetail.Columns["VendorId"], (int)cboObjectCode.EditValue);
                    }
                    else
                    {
                        gridViewDetail.SetRowCellValue(i, gridViewDetail.Columns["VendorId"], null);
                    }

                    // Employee
                    if (mdAccount.IsEmployee)
                    {
                        if (AccountingObjectType != 1)
                        {
                            XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResEmployeeId"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            cboObjectCode.Focus();
                            return false;
                        }
                        gridViewDetail.SetRowCellValue(i, gridViewDetail.Columns["EmployeeId"],
                            (int)cboObjectCode.EditValue);
                    }
                    else
                    {
                        gridViewDetail.SetRowCellValue(i, gridViewDetail.Columns["EmployeeId"], null);
                    }

                    // Accounting Object
                    if (mdAccount.IsAccountingObject)
                    {
                        if (AccountingObjectType != 2)
                        {
                            XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResAccountingObjectId"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            cboObjectCode.Focus();
                            return false;
                        }
                        gridViewDetail.SetRowCellValue(i, gridViewDetail.Columns["AccountingObjectId"], (int)cboObjectCode.EditValue);
                    }
                    else
                    {
                        gridViewDetail.SetRowCellValue(i, gridViewDetail.Columns["AccountingObjectId"], null);
                    }

                    bool isDetailValid = true;
                    if (voucher.DetailBy != null)
                    {
                        string[] detailFieldNames = voucher.DetailBy.Split(';');
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
                            XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDetaiVoucherNotValid"), "Thống báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return false;
                        }
                    }

                    #region  TUDT:Kiểm tra tổng số tiền chi không vượt quá số tiền tồn quỹ

                    CurrencyCurrent = CurrencyCode; // Tiền hạch toán
                    string budgetSourceCode = voucher.BudgetSourceCode;
                    decimal totalAmount; // tổng tiền chi tiền mặt( tiền quỹ)

                    // kiểm tra chi tiền khi số dư tiền mặt âm
                    if ((voucher.CorrespondingAccountNumber ?? "").StartsWith("111"))
                    {
                        if (!DBOptionHelper.IsPaymentNegativeFund)
                        {
                            totalAmount = DepositDetails.Where(x => x.CorrespondingAccountNumber.StartsWith("111")).Sum(x => x.AmountOc);
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
                            totalAmount = DepositDetails.Where(x =>
                                x.CorrespondingAccountNumber.StartsWith("112"))
                                .Sum(x => x.AmountOc);
                            GetCalculateDepositBalance(voucher.CorrespondingAccountNumber,
                                ((DateTime)dtPostDate.EditValue).Month + "/" + ((DateTime)dtPostDate.EditValue).Day +
                                "/" + ((DateTime)dtPostDate.EditValue).Year); // thực thi để lây tiền cho phép chi

                            if (totalAmount > ClosingAmount)
                            {
                                XtraMessageBox.Show(
                                    "Số chi vượt quá số tồn quỹ, vui lòng kiểm tra lại!.",
                                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
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

                            totalAmount = DepositDetails.Where(x =>
                                x.BudgetSourceCode == budgetSourceCode &&
                                (x.AccountNumber.StartsWith("461") || x.AccountNumber.StartsWith("661")))
                                .Sum(x => x.AmountOc);
                            if (totalAmount > accountBalance)
                            {
                                XtraMessageBox.Show(
                                    "Số chi vượt quá số tồn của nguồn, vui lòng kiểm tra lại!.",
                                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
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
            return true;
        }

        protected override void RefreshNavigationButton()
        {
            string strCurrencyCode = (string)gridViewMaster.GetRowCellValue(0, "CurrencyCode");
            string strAccountNumber = (string)gridViewMaster.GetRowCellValue(0, "BankAccountCode");
            ShowBarAmountExist(strAccountNumber, strCurrencyCode);
            base.RefreshNavigationButton();
        }

        protected override void InitData()
        {
            base.InitData();

            if (MasterBindingSource.Current != null)
            {
                long paymentDepositId = ((DepositModel)MasterBindingSource.Current).RefId;
                KeyValue = paymentDepositId.ToString(CultureInfo.InvariantCulture);

                _keyForSend = KeyValue;
                RefId = long.Parse(KeyValue);
            }
            if (int.Parse(KeyValue) != 0)
                _paymentDepositPresenter.Display(long.Parse(KeyValue));
            else
            {
                RefId = 0;
                KeyValue = null;
                //ExchangeRate = 1;
                //CurrencyCode = "USD";
                DepositDetails = new List<DepositDetailModel>();
                DepositDetailParallels = new List<DepositDetailParallelModel>();
                cboObjectCode.EditValue = null;
                cboObjectCategory.EditValue = -1;
                txtDescription.Text = "";
                txtContactName.Text = "";
            }
            cboObjectCategory.Focus();
            cboObjectCode.Focus();
            grdDetail.DataSource = bindingSourceDetail;
        }

        protected override void InitControls()
        {
        }

        protected override long SaveData()
        {
            if (ActionMode == ActionModeVoucherEnum.Edit)
                RefId = (_keyForSend == null || long.Parse(_keyForSend) == 0) ? RefId : long.Parse(_keyForSend);
            if (ActionMode == ActionModeVoucherEnum.AddNew || ActionMode == ActionModeVoucherEnum.DuplicateVoucher)
                RefId = 0;

            var dialogResultDepositDetailParallel = new DialogResult();
            if (DepositDetailParallels.Count > 0)
            {
                dialogResultDepositDetailParallel = XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResAutoGenerateParallelUpdateQuestion"), ResourceHelper.GetResourceValueByName("ResAutoGenerateParallelCaption"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }
            else
            {
                dialogResultDepositDetailParallel = XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResAutoGenerateParallelInsertQuestion"), ResourceHelper.GetResourceValueByName("ResAutoGenerateParallelCaption"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }

            var result = dialogResultDepositDetailParallel == DialogResult.OK ? _paymentDepositPresenter.Save(true) : _paymentDepositPresenter.Save(false);
            if (result > 0)
                _paymentDepositPresenter.Display(result);

            return result;
        }

        protected override void EditVoucher()
        {
            _paymentDepositPresenter.Display(long.Parse(KeyValue));
            base.EditVoucher();
        }

        protected override void DeleteVoucher()
        {
            long refId = RefId > 0 ? RefId : long.Parse(_keyForSend);
            new PaymentDepositPresenter(null).Delete(refId);
        }

        #endregion

        #region Events

        public FrmXtraPaymentDepositDetail()
        {
            InitializeComponent();
            _paymentDepositPresenter = new PaymentDepositPresenter(this);
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
            var exchange = ExchangeRate;//(decimal)gridViewMaster.GetFocusedRowCellValue("ExchangeRate");
            var amountOc = Convert.ToDecimal(gridViewDetail.GetRowCellValue(e.RowHandle, "AmountOc"));
            var amountEx = Convert.ToDecimal(gridViewDetail.GetRowCellValue(e.RowHandle, "AmountExchange"));
            if (e.Column.FieldName.Equals("AmountOc"))
            {
                if (exchange > 0)
                {
                    if (amountEx * exchange != amountOc)
                    {
                        amountEx = Math.Round(amountOc / exchange, int.Parse(DBOptionHelper.CurrencyDecimalDigits));
                        int rowHandle = gridViewDetail.FocusedRowHandle;
                        gridViewDetail.SetRowCellValue(rowHandle, "AmountExchange", amountEx);
                    }
                }
            }
            if (e.Column.FieldName.Equals("CorrespondingAccountNumber"))
            {
                BankAccountCode = (gridViewDetail.GetRowCellValue(e.RowHandle, "CorrespondingAccountNumber") ?? "").ToString();
            }
            /*LinhMC comment Theo yêu cầu của Tư vấn khi muốn ép số tiền quy đổi, do bị lệch khi chia tỷ giá
            * Thay vào đó sửa thành nếu là tiền USD thì cho quy đổi ngược lại vì tỷ giá = 1 */
            //ThangNK comment lại không tính lại tiền nguyên giá khi sửa tiền quy đổi
            //if (e.Column.FieldName.Equals("AmountExchange") && CurrencyCode != CurrencyLocal)
            //{
            //    if (exchange > 0)
            //    {
            //        if (amountOc/exchange != amountEx)
            //        {
            //            int rowHandle = gridViewDetail.FocusedRowHandle;
            //            gridViewDetail.SetRowCellValue(rowHandle, "AmountOc", amountEx*exchange);
            //        }
            //    }
            //}
            //--------LinhMC: valid detail by account in Griddetail voucher---------// 
            if (!e.Column.FieldName.Equals("DetailBy"))
            {
                object accountNumber = gridViewDetail.GetFocusedRowCellValue("AccountNumber");
                string accountNumberDetailBy = "";
                if (accountNumber != null)
                {
                    accountNumberDetailBy = GetAccountDetailBy(accountNumber.ToString());
                }
                object correspondingAccountNumber = gridViewDetail.GetFocusedRowCellValue("CorrespondingAccountNumber");
                string correspondingAccountNumberDetailBy = "";
                if (correspondingAccountNumber != null)
                {
                    correspondingAccountNumberDetailBy = GetAccountDetailBy(correspondingAccountNumber.ToString());
                }

                accountNumberDetailBy = string.IsNullOrEmpty(accountNumberDetailBy)
                    ? correspondingAccountNumberDetailBy
                    : accountNumberDetailBy + ";" + correspondingAccountNumberDetailBy;

                string[] detailByArray = accountNumberDetailBy.Split(';').Distinct().ToArray();
                detailByArray = detailByArray.Where(w => !w.Contains("ProjectId")).ToArray();
                string detail = string.Join(";", detailByArray);
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

        private void dtPostDate_EditValueChanged(object sender, EventArgs e)
        {
            dtRefDate.EditValue = dtPostDate.EditValue;
        }

        private void FrmXtraPaymentDepositDetail_Load(object sender, EventArgs e)
        {
            AdjustControlSize(true, true);
        }

        private void FrmXtraPaymentDepositDetail_Resize(object sender, EventArgs e)
        {
            AdjustControlSize(true, true);
        }

        private void dtRefDate_EditValueChanged(object sender, EventArgs e)
        {

        }

        protected override void cboCurrency_EditValueChanged(object sender, EventArgs e)
        {
            base.cboCurrency_EditValueChanged(sender, e);

            _accountsPresenter.DisplayActive();

            DepositDetails = DepositDetails;

            if (lstCorrespondingAccountNumbers != null && lstCorrespondingAccountNumbers.Count > 0)
            {
                var accountNumber = lstCorrespondingAccountNumbers.First()?.AccountCode ?? "";
                for (int i = 0; i < DepositDetails.Count; i++)
                {
                    gridViewDetail.SetRowCellValue(i, "CorrespondingAccountNumber", accountNumber);
                }
            }
        }

        #endregion
    }
}
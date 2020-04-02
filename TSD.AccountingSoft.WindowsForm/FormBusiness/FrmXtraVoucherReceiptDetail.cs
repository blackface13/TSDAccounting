/***********************************************************************
 * <copyright file="FrmXtraVoucherReceiptDetail.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: Wednesday, March 19, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 26/8/2015 LINHMC xóa hàm override CopyAndPasteRowItem vì gây ra nhiều lỗi, đã sửa lại hàm base ok
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using TSD.AccountingSoft.Model.BusinessObjects.Cash;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Presenter.Cash.ReceiptVoucher;
using TSD.AccountingSoft.Session;
using TSD.AccountingSoft.View.Cash;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.Resources;
using TSD.Enum;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using TSD.AccountingSoft.WindowsForm.CommonClass;
using TSD.AccountingSoft.Presenter.General;
using TSD.AccountingSoft.Model.BusinessObjects.General;
using TSD.AccountingSoft.Presenter.Dictionary.VoucherType;

namespace TSD.AccountingSoft.WindowsForm.FormBusiness
{
    public partial class FrmXtraVoucherReceiptDetail : FrmXtraBaseVoucherDetail, IReceiptVoucherView
    {
        #region Repository

        private RepositoryItemCalcEdit _rpsSpinEdit;

        #endregion

        #region Presenter

        private readonly ReceiptVoucherPresenter _receiptVoucherPresenter;

        private List<AccountModel> lstAccountNumbers;

        #endregion

        #region Events

        public FrmXtraVoucherReceiptDetail()
        {
            InitializeComponent();
            _receiptVoucherPresenter = new ReceiptVoucherPresenter(this);
        }

        public override void gridViewDetail_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            base.gridViewDetail_CellValueChanged(sender, e);

            var exchange = ExchangeRate;
            var charge = Convert.ToDecimal(gridViewDetail.GetRowCellValue(e.RowHandle, "Charge"));
            var chargeExchange = Convert.ToDecimal(gridViewDetail.GetRowCellValue(e.RowHandle, "ChargeExchange"));

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
                AccountNumber = (gridViewDetail.GetRowCellValue(e.RowHandle, "AccountNumber") ?? "").ToString();

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
        }

        private void dtPostDate_EditValueChanged(object sender, EventArgs e)
        {
            dtRefDate.DateTime = dtPostDate.DateTime;
        }

        private void FrmXtraVoucherReceiptDetail_Load(object sender, EventArgs e)
        {
           // txtTaxCode.Visible = false;
            AdjustControlSize(true, true);

        }

        private void cboBank_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Back && e.KeyData != Keys.Delete) return;
            cboBank.EditValue = null;
            e.Handled = true;
        }

        private void FrmXtraVoucherReceiptDetail_Resize(object sender, EventArgs e)
        {
            AdjustControlSize(true, true);
        }

        private void txtDocumentInclude_EditValueChanged(object sender, EventArgs e)
        {

        }

        protected override void cboCurrency_EditValueChanged(object sender, EventArgs e)
        {
            base.cboCurrency_EditValueChanged(sender, e);

            _accountsPresenter.DisplayActive();

            if (lstAccountNumbers != null && lstAccountNumbers.Count > 0)
            {
                var accountNumber = lstAccountNumbers.First()?.AccountCode ?? "";
                for (int i = 0; i < ReceiptVoucherDetails.Count; i++)
                {
                    gridViewDetail.SetRowCellValue(i, "AccountNumber", accountNumber);
                }
            }
        }

        private void chkIncludeCharge_CheckedChanged(object sender, EventArgs e)
        {
            ReceiptVoucherDetails = ReceiptVoucherDetails;
        }

        #endregion

        #region Override functions

        protected override void InitControls()
        {
            _rpsSpinEdit = new RepositoryItemCalcEdit { AllowMouseWheel = false };
        }

        protected override void InitData()
        {
            base.InitData();

            if (MasterBindingSource.Current != null)
            {
                long receiptVoucherId = ((ReceiptVoucherModel)MasterBindingSource.Current).RefId;
                KeyValue = receiptVoucherId.ToString(CultureInfo.InvariantCulture);
                _keyForSend = KeyValue;
                RefId = long.Parse(KeyValue);
            }

            if (long.Parse(KeyValue) != 0)
            {
                ReceiptVoucherModel obj = _receiptVoucherPresenter.GetReceiptVoucherById(long.Parse(KeyValue));
                _receiptVoucherPresenter.Display(long.Parse(KeyValue));
                if (obj.AccountingObjectType != null)
                    LoadComboObjectCode((int)obj.AccountingObjectType);
            }
            else
            {
                ReceiptVoucherDetails = new List<ReceiptVoucherDetailModel>();
                ReceiptVoucherDetailParalells = new List<ReceiptVoucherParalellDetailModel>();
                
                SetObjectInfo(null, null, null, null);
                txtDescription.Text = "";
                txtDocumentInclude.Text = "";
                //txtTaxCode.Text = "";
                cboObjectCode.Enabled = false;
            }

            if (ActionMode == ActionModeVoucherEnum.AddNew)
            {
                cboObjectCode.Enabled = true;
                // Thêm khi đang view
                ReceiptVoucherModel obj = _receiptVoucherPresenter.GetReceiptVoucherById(RefId);
                if (obj.AccountingObjectType != null)
                    LoadComboObjectCode((int)obj.AccountingObjectType);
                else
                {
                    AccountingObjectType = -1;
                    LoadComboObjectCode(-1);
                }
                //txtTaxCode.Properties.ReadOnly = false;
                txtDocumentInclude.Properties.ReadOnly = false;
            }
            if (ActionMode == ActionModeVoucherEnum.DuplicateVoucher)
            {
                //txtTaxCode.Properties.ReadOnly = false;
                txtDocumentInclude.Properties.ReadOnly = false;
            }
            if (ActionMode == ActionModeVoucherEnum.None)
            {
                //txtTaxCode.Properties.ReadOnly = true;
                txtDocumentInclude.Properties.ReadOnly = true;
                ReceiptVoucherModel obj = _receiptVoucherPresenter.GetReceiptVoucherById(RefId);

                if (obj.AccountingObjectType != null)
                    SetcboObjectCategory((int)obj.AccountingObjectType);
                else SetObjectInfo(null, null, null, null);
            }
            if (ActionMode == ActionModeVoucherEnum.Edit)
            {
                if (IsIncludeCharge)
                    chkIncludeCharge.Enabled = false;
                else
                    chkIncludeCharge.Enabled = true;
            }
            //InitDefaultCurrencies();
            grdDetail.DataSource = bindingSourceDetail;
            gridAccountingParallel.DataSource = bindingSourceDetailParallel;
            ShowBarAmountExist(AccountNumber, CurrencyCode);
        }

        protected override void EditVoucher()
        {
            base.EditVoucher();
            ActionMode = ActionModeVoucherEnum.Edit;
           // txtTaxCode.Properties.ReadOnly = false;
            txtDocumentInclude.Properties.ReadOnly = false;
            InitData();
            var objectId = (int)cboObjectCategory.EditValue;
            LoadComboObjectCode(objectId);
            LoadGridDetailLayout();
            if (gridAccountingParallel.Visible == true)
            {
                LoadGridParalellDetailLayout();
            }
        }

        protected override void CancelVoucher()
        {
           // txtTaxCode.Properties.ReadOnly = true;
            txtDocumentInclude.Properties.ReadOnly = true;
            base.CancelVoucher();
        }

        protected override long SaveData()
        {
            if (ActionMode == ActionModeVoucherEnum.Edit)
                RefId = (_keyForSend == null || long.Parse(_keyForSend) == 0) ? RefId : long.Parse(_keyForSend);
            if (ActionMode == ActionModeVoucherEnum.AddNew || ActionMode == ActionModeVoucherEnum.DuplicateVoucher)
                RefId = 0;
            txtDocumentInclude.Properties.ReadOnly = true;
           // txtTaxCode.Properties.ReadOnly = true;
            var dialogResult = new DialogResult();
            dialogResult = XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResAutoGenerateParallelInsertQuestion"), ResourceHelper.GetResourceValueByName("ResAutoGenerateParallelCaption"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            var result = dialogResult == DialogResult.Yes ? _receiptVoucherPresenter.Save(true) : _receiptVoucherPresenter.Save(false);
            if (result > 0)
            {
                _receiptVoucherPresenter.Display(result);

                if (ReceiptVoucherDetails.Sum(s => s.Charge) == 0)
                {
                    var generalVoucher = new GenveralVoucherPresenter(null).GetGeneralVocher((int)RefType.ReceiptCash, result);
                    if(generalVoucher != null)
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
                if (IsIncludeCharge && (ReceiptVoucherDetails.Sum(s=>s.Charge) > 0 || ReceiptVoucherDetails.Sum(s=>s.ChargeExchange) > 0))
                {
                    dialogResult = new DialogResult();
                    var generalVoucher = new GenveralVoucherPresenter(null).GetGeneralVocher((int)RefType.ReceiptCash, result);
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
                        frmGeneralVoucher.GeneralVocher.CashId = result;
                        frmGeneralVoucher.ShowDialog();
                    }
                }
            }
            return result;
        }

        protected override void RefreshNavigationButton()
        {
            ShowBarAmountExist(AccountNumber, CurrencyCode);
            base.RefreshNavigationButton();
        }

        protected override void DeleteVoucher()
        {

            try
            {
                var refId = RefId > 0 ? RefId : long.Parse(_keyForSend);
                new ReceiptVouchersPresenter(null).Delete(refId);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.StackTrace);
            }
        }

        protected override bool ValidData()
        {
            gridViewDetail.CloseEditor();
            gridViewDetail.UpdateCurrentRow();

            if (cboObjectCategory.EditValue == null || cboObjectCategory.ToString() == "" ||
                cboObjectCategory.EditValue.ToString() == "-1")
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
                        XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResReceiptVoucherVender"),
                            ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        cboObjectCode.Focus();
                        return false;
                    }
                    break;
                case 1:
                    if (EmployeeId == null)
                    {
                        XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResReceiptVoucherEmployee"),
                            ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        cboObjectCode.Focus();
                        return false;
                    }

                    break;
                case 2:
                    if (AccountingObjectId == null)
                    {
                        XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResReceiptVoucherAccountingOject"),
                            ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        cboObjectCode.Focus();
                        return false;
                    }
                    break;
                case 3:
                    if (CustomerId == null)
                    {
                        XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResReceiptVoucherCustomer"),
                            ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        cboObjectCode.Focus();
                        return false;
                    }
                    break;
            }

            if (dtRefDate.DateTime < DateTime.Parse(GlobalVariable.SystemDate))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResRefDate"),
                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                dtRefDate.Focus();
                return false;
            }
            if (dtPostDate.DateTime < DateTime.Parse(GlobalVariable.SystemDate))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResPostDate"),
                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                dtPostDate.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtRefNo.Text))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResReceiptRefNo"),
                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtRefNo.Focus();
                return false;
            }

            //if (string.IsNullOrEmpty(txtDocumentInclude.Text) && ReceiptVoucherDetails.Where(x=>(x?.CorrespondingAccountNumber ?? "").Contains("111")).Count() > 0)
            //{
            //    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResReceiptDocumentInclude"),
            //        ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
            //        MessageBoxIcon.Error);
            //    txtDocumentInclude.Focus();
            //    return false;
            //}


            if (RefNo.Length == 0)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResRefNo"),
                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtRefNo.Focus();
                return false;
            }
            if (dtRefDate.DateTime < DateTime.Parse(GlobalVariable.SystemDate))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResRefDate"),
                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                dtRefDate.Focus();
                return false;
            }
            //-----Kiểm tra chi tiết chứng từ -------//
            List<ReceiptVoucherDetailModel> receiptVoucherDetails = ReceiptVoucherDetails;
            if (receiptVoucherDetails.Count == 0)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResTotalAmount"),
                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (receiptVoucherDetails.Count > 0)
            {
                int i = 0;
                var currencyCode = CurrencyCode;
                var lstRowAmounts = new List<string>();
                foreach (ReceiptVoucherDetailModel voucher in receiptVoucherDetails)
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
                    var strCorrespondingAccountNumberDetail = (string)gridViewDetail.GetRowCellValue(i, "CorrespondingAccountNumber");

                    if (string.IsNullOrEmpty(AccountNumber))
                        AccountNumber = voucher.AccountNumber;
                    else if (voucher.AccountNumber != AccountNumber)
                    {
                        XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResAccountNumberCompareMaster"),
                            ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return false;
                    }
                    if (voucher.CorrespondingAccountNumber == null)
                    {
                        XtraMessageBox.Show("Tài khoản có không được để trống tại dòng: " + (i + 1),
                            ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return false;
                    }

                    if (voucher.AccountNumber == voucher.CorrespondingAccountNumber)
                    {
                        XtraMessageBox.Show("Tài khoản nợ và tài khoản có không được trùng nhau tại dòng: " + (i + 1),
                            ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return false;
                    }
                    var rowValue = (AccountModel)_rpsCorrespondingAccountNumber.GetRowByKeyValue(strCorrespondingAccountNumberDetail);
                    if (rowValue.IsCurrency && rowValue.CurrencyCode != CurrencyCode && rowValue.CurrencyCode != null)
                    {
                        XtraMessageBox.Show("Bạn đang chọn tài khoản có theo tiền chưa đúng, bạn phải chọn lại tại dòng: " + (i + 1), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    // bẫy lỗi ,0-nhà cung cấp,1-nhân viên, 2-đối tượng khác
                    int obj = int.Parse(cboObjectCategory.EditValue.ToString());

                    if (rowValue.IsVendor && obj != 0) //Nhà cung cấp
                    {
                        XtraMessageBox.Show( "Bạn chưa chọn nhà cung cấp theo theo tài khoản:" + strCorrespondingAccountNumberDetail + " tại dòng: " + (i + 1), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    // Gán từ Master xuống Detail
                    if (rowValue.IsVendor && obj == 0)
                    {
                        gridViewDetail.SetRowCellValue(i, gridViewDetail.Columns["VendorId"], (int)cboObjectCode.EditValue);
                    }

                    if (rowValue.IsEmployee && obj != 1) //Nhân viên
                    {
                        XtraMessageBox.Show("Bạn chưa chọn cán bộ theo tài khoản " + strCorrespondingAccountNumberDetail + " tại dòng: " + (i + 1), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    // Gán từ Master xuống Detail
                    if (rowValue.IsVendor && obj == 1)
                    {
                        gridViewDetail.SetRowCellValue(i, gridViewDetail.Columns["EmployeeId"], (int)cboObjectCode.EditValue);
                    }
                    if (rowValue.IsAccountingObject && obj != 2) //Đối tượng khác
                    {
                        XtraMessageBox.Show(
                            "Bạn chưa chọn đối tượng khác theo tài khoản " + strCorrespondingAccountNumberDetail +
                            " theo đối tượng khác tại dòng : " + (i + 1),
                            ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return false;
                    }
                    //var projectId = (int?)gridViewDetail.GetRowCellValue(i, "ProjectId");
                    //if (rowValue.IsProject && projectId == null)
                    //{
                    //    XtraMessageBox.Show("Bạn chưa nhập dự án tại dòng : " + (i + 1).ToString(),
                    //                    ResourceHelper.GetResourceValueByName("ResDetailContent"),
                    //                    MessageBoxButtons.OK,
                    //                    MessageBoxIcon.Error);
                    //    return false;
                    //}

                    // bắt lỗi các cột trên gridDetail
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
                            XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDetaiVoucherNotValid"),
                                "Thống báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return false;
                        }
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

                    CurrencyCurrent = currencyCode; // Tiền hạch toán
                    string budgetSourceCode = voucher.BudgetSourceCode;
                    decimal totalAmount; // tổng tiền chi tiền mặt( tiền quỹ)

                    // kiểm tra chi tiền khi số dư tiền mặt âm
                    if (voucher.CorrespondingAccountNumber.StartsWith("111"))
                    {
                        if (!DBOptionHelper.IsPaymentNegativeFund)
                        {
                            totalAmount = ReceiptVoucherDetails.Where(x => x.CorrespondingAccountNumber.StartsWith("111")).Sum(x => x.AmountOc);
                            GetCalculateCashBalance(voucher.CorrespondingAccountNumber,
                                ((DateTime)dtPostDate.EditValue).Month + "/" + ((DateTime)dtPostDate.EditValue).Day +
                                "/" + ((DateTime)dtPostDate.EditValue).Year); // thực thi để lây tiền cho phép chi

                            if (totalAmount > ClosingAmount)
                            {
                                XtraMessageBox.Show(
                                    "Số chi vượt quá số tồn tiền mặt, vui lòng kiểm tra lại!.",
                                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                                return false;
                            }
                        }
                    }

                    // kiểm tra chi tiền khi số dư tiền gửi âm
                    if (voucher.CorrespondingAccountNumber.StartsWith("112"))
                    {
                        if (!DBOptionHelper.IsDepositeNegavtiveFund)
                        {
                            totalAmount = ReceiptVoucherDetails.Where(x =>
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

                            // Số dư Nợ TK 6612
                            GetCalculateCapitalBalance("6612", budgetSourceCode,
                                ((DateTime)dtPostDate.EditValue).Month + "/" + ((DateTime)dtPostDate.EditValue).Day +
                                "/" + ((DateTime)dtPostDate.EditValue).Year); // thực thi để lây tiền cho phép chi
                            accountBalance = accountBalance - ClosingAmount;

                            totalAmount = ReceiptVoucherDetails.Where(x =>
                                x.BudgetSourceCode == budgetSourceCode && (x.AccountNumber.StartsWith("466") || x.AccountNumber.StartsWith("661")))
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

        protected override void ReFreshControl()
        {
            txtDocumentInclude.Properties.ReadOnly = false;
           // txtTaxCode.Properties.ReadOnly = false;
        }

        protected override void SetObjectInfo(string objectName = "", string trader = "", string address = "", string description = "", string taxCode = "")
        {
            base.SetObjectInfo(objectName, trader, address, taxCode);
            //txtTaxCode.Text = taxCode;
        }

        #endregion

        #region Property

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
        public DateTime RefDate
        {
            get
            {
                return Convert.ToDateTime(dtRefDate.DateTime.ToShortDateString());
            }
            set { dtRefDate.EditValue = value; }
        }
        public DateTime PostedDate
        {
            get
            {
                return Convert.ToDateTime(dtPostDate.DateTime.ToShortDateString());
            }
            set { dtPostDate.EditValue = value; }
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
                return (cboCurrency.EditValue ?? "").ToString();
            }
            set
            {
                cboCurrency.EditValue = value;
                if (value == CurrencyAccounting)
                    cboExchangRate.Enabled = false;
            }
        }
        public string AccountNumber { get; set; }
        public decimal TotalAmount { get; set; }
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
        public decimal TotalAmountExchange { get; set; }
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
        public bool IsIncludeCharge
        {
            get
            {
                return chkIncludeCharge.Checked;
            }
            set
            {
                chkIncludeCharge.Checked = value;
            }
        }
        public List<ReceiptVoucherDetailModel> ReceiptVoucherDetails
        {
            get
            {
                var result = bindingSourceDetail.DataSource as List<ReceiptVoucherDetailModel> ?? new List<ReceiptVoucherDetailModel>();
                TotalAmount = result.Sum(s=>s.AmountOc);
                TotalAmountExchange = result.Sum(s=>s.AmountExchange);
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
                    var refType = RefTypes.Where(w => w.RefTypeId == (int)RefType.ReceiptCash)?.FirstOrDefault() ?? null;
                    if (refType != null)
                        bindingSourceDetail.DataSource = new List<ReceiptVoucherDetailModel> { new ReceiptVoucherDetailModel() { AccountNumber = refType.DefaultDebitAccountId, CorrespondingAccountNumber = refType.DefaultCreditAccountId } };
                    else
                        bindingSourceDetail.DataSource = new List<ReceiptVoucherDetailModel> { new ReceiptVoucherDetailModel() };
                }

                ColumnsCollection.Clear();
                gridViewDetail.PopulateColumns(value);
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "RefDetailId",
                    ColumnVisible = false,
                    FixedColumn = FixedStyle.Left,
                    Alignment = HorzAlignment.Center
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "AutoBusinessId",
                    ColumnCaption = "ĐK tự động",
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 80,
                    FixedColumn = FixedStyle.Left,
                    AllowEdit = true,
                    ToolTip = "Định khoản tự động",
                    RepositoryControl = _rpsAutoBusiness

                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "AccountNumber",
                    ColumnCaption = "TK Nợ",
                    FixedColumn = FixedStyle.Left,
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 60,
                    ToolTip = "Tài khoản nợ",
                    RepositoryControl = _rpsAccountNumber
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "CorrespondingAccountNumber",
                    ColumnCaption = "TK Có",
                    FixedColumn = FixedStyle.Left,
                    ColumnPosition = 3,
                    ColumnVisible = true,
                    ColumnWith = 60,
                    ToolTip = "Tài khoản có",
                    RepositoryControl = _rpsCorrespondingAccountNumber
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "Description",
                    ColumnCaption = "Diễn giải",
                    FixedColumn = FixedStyle.None,
                    ColumnPosition = 4,
                    ColumnVisible = true,
                    ColumnWith = 230,
                    IsSummaryText = true
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "AmountOc",
                    ColumnType = UnboundColumnType.Decimal,
                    FixedColumn = FixedStyle.None,
                    ColumnCaption = "Số tiền",
                    ColumnPosition = 5,
                    ColumnVisible = true,
                    ColumnWith = 100
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "AmountExchange",
                    ColumnType = UnboundColumnType.Decimal,
                    FixedColumn = FixedStyle.None,
                    ColumnCaption = "Quy đổi",
                    ColumnPosition = 6,
                    ColumnVisible = true,
                    ColumnWith = 100
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "Charge",
                    ColumnType = UnboundColumnType.Decimal,
                    FixedColumn = FixedStyle.None,
                    ColumnCaption = "Phí NH",
                    ColumnPosition = 7,
                    ColumnVisible = IsIncludeCharge,
                    ColumnWith = 100
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "ChargeExchange",
                    ColumnType = UnboundColumnType.Decimal,
                    FixedColumn = FixedStyle.None,
                    ColumnCaption = "Phí NH quy đổi",
                    ColumnPosition = 8,
                    ColumnVisible = IsIncludeCharge,
                    ColumnWith = 100
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetSourceCode",
                    ColumnCaption = "Nguồn vốn",
                    FixedColumn = FixedStyle.None,
                    ColumnPosition = 9,
                    ColumnVisible = true,
                    ColumnWith = 80,
                    RepositoryControl = _rpsBudgetSource
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetItemCode",
                    ColumnCaption = "Mục/TM",
                    ColumnPosition = 10,
                    FixedColumn = FixedStyle.None,
                    ColumnVisible = true,
                    ColumnWith = 80,
                    ToolTip = "Mục/Tiểu mục",
                    RepositoryControl = _rpsBudgetItem

                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "VoucherTypeId",
                    ColumnCaption = "Nghiệp vụ",
                    FixedColumn = FixedStyle.None,
                    ColumnVisible = true,
                    ColumnWith = 100,
                    ColumnPosition = 11,
                    RepositoryControl = _rpsVoucherTypeId
                });
                //ColumnsCollection.Add(new XtraColumn
                //{
                //    ColumnName = "ProjectId",
                //    FixedColumn = FixedStyle.None,
                //    ColumnCaption = "Dự án",
                //    ColumnPosition = 12,
                //    ColumnVisible = true,
                //    ColumnWith = 100,
                //    RepositoryControl = _rpsProject
                //});
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "AccountingObjectId",
                    ColumnCaption = "Đối tượng khác",
                    ColumnVisible = false,
                    ColumnPosition = 13,
                    RepositoryControl = _rpsAccountingObject


                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "MergerFundId",
                    ColumnCaption = "Quỹ sát nhập",
                    ColumnVisible = false,

                });

                gridViewDetail = InitGridLayout(ColumnsCollection, gridViewDetail);
                SetNumericFormatControl(gridViewDetail, true);
            }
        }

        public List<ReceiptVoucherParalellDetailModel> ReceiptVoucherDetailParalells
        {
            get
            {
                var result = bindingSourceDetailParallel.DataSource as List<ReceiptVoucherParalellDetailModel> ?? new List<ReceiptVoucherParalellDetailModel>();
                return result;
            }
            set
            {
               
                bindingSourceDetailParallel.DataSource = value;
                ColumnsCollectionParalell.Clear();
                gridViewAccountingPararell.PopulateColumns(value);
                ColumnsCollectionParalell.Add(new XtraColumn
                {
                    ColumnName = "RefDetailId",
                    ColumnVisible = false,
                    FixedColumn = FixedStyle.Left,
                    Alignment = HorzAlignment.Center
                });
                ColumnsCollectionParalell.Add(new XtraColumn
                {
                    ColumnName = "AutoBusinessId",
                    ColumnCaption = "ĐK tự động",
                    ColumnPosition = 1,
                    ColumnVisible = false,
                    ColumnWith = 80,
                    FixedColumn = FixedStyle.Left,
                    AllowEdit = true,
                    ToolTip = "Định khoản tự động",
                    RepositoryControl = _rpsAutoBusinessParalell

                });
                ColumnsCollectionParalell.Add(new XtraColumn
                {
                    ColumnName = "AccountNumber",
                    ColumnCaption = "TK Nợ",
                    FixedColumn = FixedStyle.Left,
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 60,
                    ToolTip = "Tài khoản nợ",
                    RepositoryControl = _rpsAccountNumberParalell
                });
                ColumnsCollectionParalell.Add(new XtraColumn
                {
                    ColumnName = "CorrespondingAccountNumber",
                    ColumnCaption = "TK Có",
                    FixedColumn = FixedStyle.Left,
                    ColumnPosition = 3,
                    ColumnVisible = true,
                    ColumnWith = 60,
                    ToolTip = "Tài khoản có",
                    RepositoryControl = _rpsCorrespondingAccountNumberParalell
                });
                ColumnsCollectionParalell.Add(new XtraColumn
                {
                    ColumnName = "Description",
                    ColumnCaption = "Diễn giải",
                    FixedColumn = FixedStyle.None,
                    ColumnPosition = 4,
                    ColumnVisible = true,
                    ColumnWith = 230,
                    IsSummaryText = true
                });
                ColumnsCollectionParalell.Add(new XtraColumn
                {
                    ColumnName = "AmountOc",
                    ColumnType = UnboundColumnType.Decimal,
                    FixedColumn = FixedStyle.None,
                    ColumnCaption = "Số tiền",
                    ColumnPosition = 5,
                    ColumnVisible = true,
                    ColumnWith = 100
                });
                ColumnsCollectionParalell.Add(new XtraColumn
                {
                    ColumnName = "AmountExchange",
                    ColumnType = UnboundColumnType.Decimal,
                    FixedColumn = FixedStyle.None,
                    ColumnCaption = "Quy đổi",
                    ColumnPosition = 6,
                    ColumnVisible = true,
                    ColumnWith = 100
                });
                ColumnsCollectionParalell.Add(new XtraColumn
                {
                    ColumnName = "BudgetSourceCode",
                    ColumnCaption = "Nguồn vốn",
                    FixedColumn = FixedStyle.None,
                    ColumnPosition = 7,
                    ColumnVisible = true,
                    ColumnWith = 80,
                    RepositoryControl = _rpsBudgetSourceParalell
                });
                ColumnsCollectionParalell.Add(new XtraColumn
                {
                    ColumnName = "BudgetItemCode",
                    ColumnCaption = "Mục/TM",
                    ColumnPosition = 8,
                    FixedColumn = FixedStyle.None,
                    ColumnVisible = true,
                    ColumnWith = 80,
                    ToolTip = "Mục/Tiểu mục",
                    RepositoryControl = _rpsBudgetItemParalell

                });
                ColumnsCollectionParalell.Add(new XtraColumn
                {
                    ColumnName = "VoucherTypeId",
                    ColumnCaption = "Nghiệp vụ",
                    FixedColumn = FixedStyle.None,
                    ColumnVisible = true,
                    ColumnWith = 100,
                    ColumnPosition = 9,
                    RepositoryControl = _rpsVoucherTypeIdParalell
                });
                //ColumnsCollectionParalell.Add(new XtraColumn
                //{
                //    ColumnName = "ProjectId",
                //    FixedColumn = FixedStyle.None,
                //    ColumnCaption = "Dự án",
                //    ColumnPosition = 10,
                //    ColumnVisible = true,
                //    ColumnWith = 100,
                //    RepositoryControl = _rpsProjectParalell
                //});
                ColumnsCollectionParalell.Add(new XtraColumn
                {
                    ColumnName = "AccountingObjectId",
                    ColumnCaption = "Đối tượng khác",
                    ColumnVisible = false,
                    ColumnPosition = 11,
                    RepositoryControl = _rpsAccountingObjectParalell
                });
                ColumnsCollectionParalell.Add(new XtraColumn
                {
                    ColumnName = "MergerFundId",
                    ColumnCaption = "Quỹ sát nhập",
                    ColumnVisible = false,
                });

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
                        //GridLookUpItem.Account(value.Where(x => x.IsDetail).ToList(), _rpsAccountNumberParalell, "AccountCode", "AccountCode");
                        GridLookUpItem.Account(value.Where(x => x.IsDetail).ToList(), _rpsMasterAccountNumberParalell, "AccountCode", "AccountCode");
                    }
                    else
                    {
                        GridLookUpItem.Account(value, _rpsAccountNumber, "AccountCode", "AccountCode");
                        GridLookUpItem.Account(value, _rpsMasterAccountNumberParalell, "AccountCode", "AccountCode");
                    }
                    //GridLookUpItem.Account(value, _rpsCorrespondingAccountNumberParalell, "AccountCode", "AccountCode");
                }
            }
        }

        #endregion

        #region Functions

        public GeneralVocherModel MakeGeneralVoucher(GeneralVocherModel generalVocher)
        {
            var result = new GeneralVocherModel();
            result.RefId = generalVocher?.RefId ?? 0;
            result.RefNo = generalVocher?.RefNo ?? "";
            result.JournalMemo = "Phí ngân hàng"; //this.JournalMemo;
            result.RefDate = this.RefDate;
            result.PostedDate = this.PostedDate;
            result.RefTypeId = (int)RefType.GeneralVoucher;
            // lấy nghiệp vụ thực chi
            var voucherType = new VoucherTypePresenter(null).GetVoucherTypeByCode("SalaryVoucher");
            foreach (var receiptDetail in ReceiptVoucherDetails)
            {
                var generalDetail = new GeneralDetailModel();
                if (receiptDetail.BudgetSourceCode != null)
                {
                    if (receiptDetail.BudgetSourceCode.StartsWith("12") || receiptDetail.BudgetSourceCode.StartsWith("15.2"))
                        generalDetail.AccountNumber = "6112";
                    if (receiptDetail.BudgetSourceCode.StartsWith("13") || receiptDetail.BudgetSourceCode.StartsWith("15.1"))
                        generalDetail.AccountNumber = "6111";
                }
                else
                {
                    generalDetail.AccountNumber = "6111";
                }
                //generalDetail.AccountNumber = "61118"; // depositDetail.AccountNumber;
                generalDetail.CorrespondingAccountNumber = "3371"; // depositDetail.CorrespondingAccountNumber;
                generalDetail.Description = receiptDetail.Description;
                generalDetail.AmountOc = receiptDetail.Charge;
                generalDetail.AmountExchange = receiptDetail.ChargeExchange;
                generalDetail.CurrencyCode = this.CurrencyCode;
                generalDetail.ExchangeRate = this.ExchangeRate;
                generalDetail.VoucherTypeId = voucherType?.VoucherTypeId ?? null;
                generalDetail.BankId = this.BankId;
                generalDetail.BudgetItemCode = "7756";//receiptDetail.BudgetItemCode;
                generalDetail.BudgetSourceCode = receiptDetail.BudgetSourceCode;
                generalDetail.DepartmentId = null;
                generalDetail.AccountingObjectId = this.AccountingObjectId;
                generalDetail.CustomerId = this.CustomerId;
                generalDetail.VendorId = this.VendorId;
                generalDetail.EmployeeId = this.EmployeeId;
                //generalDetail.ProjectId = receiptDetail.ProjectId;

                result.GeneralVoucherDetails.Add(generalDetail);
            }
            return result;
        }

        #endregion
    }
}
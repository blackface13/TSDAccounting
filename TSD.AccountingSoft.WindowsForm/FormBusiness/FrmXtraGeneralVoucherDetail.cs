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
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using TSD.AccountingSoft.Session;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Model.BusinessObjects.General;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.View.General;
using TSD.Enum;
using DevExpress.Utils;
using DevExpress.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
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
    /// FrmXtraGeneralVoucherDetail
    /// </summary>
    public partial class FrmXtraGeneralVoucherDetail : FrmXtraBaseVoucherDetail, IGeneralVoucherView
    {
        private RepositoryItemCalcEdit _rpsSpinEdit;

        private readonly GlobalVariable _globalVariable;

        private readonly GenveralVoucherPresenter _generalVoucherPresenter;

        public FrmXtraGeneralVoucherDetail()
        {
            InitializeComponent();
            _globalVariable = new GlobalVariable();

            _generalVoucherPresenter = new GenveralVoucherPresenter(this);
        }

        #region Override

        protected override void InitData()
        {
            base.InitData();

            if (MasterBindingSource != null && MasterBindingSource.Current != null)
            {
                var generalVoucherDetailId = ((GeneralVocherModel)MasterBindingSource.Current).RefId;
                KeyValue = generalVoucherDetailId.ToString(CultureInfo.InvariantCulture);

                _keyForSend = KeyValue;
                RefId = long.Parse(KeyValue);
            }
            else
            {
                _keyForSend = RefID.ToString();
            }

            if (GeneralVocher != null)
            {
                _generalVoucherPresenter.Display(GeneralVocher);
                // chuyển về null để sau khi thao tác nó sẽ ko còn gọi vào đây nữa
                GeneralVocher = null;
            }
            else if (long.Parse(KeyValue) != 0)
            {
                _generalVoucherPresenter.Display(long.Parse(KeyValue));
            }
            else
            {
                GeneralDetails = new List<GeneralDetailModel>();
                GeneralParalellDetails = new List<GeneralParalellDetailModel>();
            }
            if (ActionMode == ActionModeVoucherEnum.None)
            {
                txtDescription.Properties.ReadOnly = true;
            }
            else
            {
                txtDescription.Properties.ReadOnly = false;
            }
            grdDetail.DataSource = bindingSourceDetail;

        }

        protected override void InitControls()
        {
            _rpsSpinEdit = new RepositoryItemCalcEdit();
            _rpsSpinEdit.Mask.MaskType = MaskType.Numeric;
            _rpsSpinEdit.Mask.EditMask = @"c" + _globalVariable.ExchangeRateDecimalDigits;
            _rpsSpinEdit.Mask.Culture = Thread.CurrentThread.CurrentCulture;
            _rpsSpinEdit.Mask.UseMaskAsDisplayFormat = true;
        }

        protected override long SaveData()
        {
            // txtAddress.Focus();//Thất bại trong việc bẫy nhập chứng từ đơn
            if (ActionMode == ActionModeVoucherEnum.Edit)
                RefId = (_keyForSend == null || long.Parse(_keyForSend) == 0) ? RefId : long.Parse(_keyForSend);
            if (ActionMode == ActionModeVoucherEnum.AddNew || ActionMode == ActionModeVoucherEnum.DuplicateVoucher)
                RefId = 0;

            var result = new DialogResult();
            result = XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResAutoGenerateParallelInsertQuestion"), ResourceHelper.GetResourceValueByName("ResAutoGenerateParallelCaption"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return result == DialogResult.Yes ? _generalVoucherPresenter.Save(true) : _generalVoucherPresenter.Save(false);

            //return _generalVoucherPresenter.Save();
        }

        protected override void EditVoucher()
        {
            txtDescription.Properties.ReadOnly = false;
            base.EditVoucher();
        }

        protected override void AddNewVoucher()
        {
            txtDescription.Text = "";
            base.AddNewVoucher();
        }

        protected override void DeleteVoucher()
        {
            var refId = RefId > 0 ? RefId : long.Parse(_keyForSend);
            new GenveralVoucherPresenter(null).Delete(refId);
        }

        protected override bool ValidData()
        {
            gridViewDetail.CloseEditor();
            gridViewDetail.UpdateCurrentRow();

            if (string.IsNullOrEmpty(txtRefNo.Text))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResReceiptRefNo"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRefNo.Focus();
                return false;
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
            bool kt = false;
            bool checkAcountVourchers = false;

            var lst = GeneralDetails;

            for (var i = 0; i < gridViewDetail.RowCount; i++)
            {
                if (gridViewDetail.GetRow(i) != null)
                {
                    kt = true;
                    var strAccountNumberDetail = (string)gridViewDetail.GetRowCellValue(i, "AccountNumber") == "" ? null : (string)gridViewDetail.GetRowCellValue(i, "AccountNumber");
                    var strCorrespondingAccountNumberDetail = (string)gridViewDetail.GetRowCellValue(i, "CorrespondingAccountNumber") == "" ? null : (string)gridViewDetail.GetRowCellValue(i, "CorrespondingAccountNumber");
                    var currencyCode = (string)gridViewDetail.GetRowCellValue(i, "CurrencyCode");
                    var totalAmount = (decimal)gridViewDetail.GetRowCellValue(i, "AmountOc");
                    var budgetSourceCode = (string)gridViewDetail.GetRowCellValue(i, "BudgetSourceCode");

                    var rowValue = (AccountModel)_rpsAccountNumber.GetRowByKeyValue("11121");// dữ liệu đệm để làm biến
                    if (strCorrespondingAccountNumberDetail != null)
                    {
                        rowValue = (AccountModel)_rpsCorrespondingAccountNumber.GetRowByKeyValue(strCorrespondingAccountNumberDetail);
                        if (rowValue.IsCurrency == true && rowValue.CurrencyCode != currencyCode && rowValue.CurrencyCode != null)
                        {
                            XtraMessageBox.Show("Bạn đang chọn tài khoản nợ và tài khoản có không cùng một loại tiền tệ. Bạn phải chọn lại!.", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    if (strAccountNumberDetail != null)
                    {
                        rowValue = (AccountModel)_rpsAccountNumber.GetRowByKeyValue(strAccountNumberDetail);
                        if (rowValue.IsCurrency == true && rowValue.CurrencyCode != currencyCode && rowValue.CurrencyCode != null)
                        {
                            XtraMessageBox.Show("Bạn đang chọn tài khoản nợ và tài khoản có không cùng một loại tiền tệ. Bạn phải chọn lại!.", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }

                    //Định khoản đơn Nợ/Có Không bằng nhau
                    decimal TongNo = 0;
                    decimal TongCo = 0;

                    if (strAccountNumberDetail != null && strCorrespondingAccountNumberDetail == null)
                    {
                        TongNo = lst.Where(x => x.CorrespondingAccountNumber != null && x.AccountNumber == null && x.CurrencyCode == currencyCode).Sum(x => x.AmountOc);
                        TongCo = lst.Where(x => x.AccountNumber != null && x.CorrespondingAccountNumber == null && x.CurrencyCode == currencyCode).Sum(x => x.AmountOc);
                        if (TongNo != TongCo)
                        {
                            XtraMessageBox.Show("Tổng số tiền Nợ/Có không bằng nhau theo tài khoản " + strAccountNumberDetail + " tại dòng: " + (i + 1), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }

                    if (strCorrespondingAccountNumberDetail != null && strAccountNumberDetail == null)
                    {
                        TongNo = lst.Where(x => x.CorrespondingAccountNumber != null && x.AccountNumber == null && x.CurrencyCode == currencyCode).Sum(x => x.AmountOc);
                        TongCo = lst.Where(x => x.AccountNumber != null && x.CorrespondingAccountNumber == null && x.CurrencyCode == currencyCode).Sum(x => x.AmountOc);
                        if (TongNo != TongCo)
                        {
                            XtraMessageBox.Show("Tổng số tiền Nợ/Có không bằng nhau theo tài khoản " + strCorrespondingAccountNumberDetail + " tại dòng: " + (i + 1), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }

                    if (checkAcountVourchers == false)
                    {
                        if (strAccountNumberDetail != null)
                        {
                            if (strAccountNumberDetail.Substring(0, 2) == "11")
                            {
                                if (strAccountNumberDetail.Substring(0, 3) == "111")
                                {
                                    DialogResult result = XtraMessageBox.Show("Bạn đang định khoản TK Nợ " + strAccountNumberDetail + " liên quan đến tiền tại dòng: " + (i + 1) + ".\n Bạn có thể nhập ở phiếu Thu.\n Bạn có muốn nhập ở đây không? ", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (result == DialogResult.Yes)
                                        checkAcountVourchers = true;
                                    else
                                        return false;
                                }
                                else
                                {
                                    DialogResult result = XtraMessageBox.Show(@"Bạn đang định khoản TK Nợ " + strAccountNumberDetail + " liên quan đến tiền tại dòng: " + (i + 1) + ".\n Bạn có thể nhập ở giấy báo có.\n Bạn có muốn nhập ở đây không? ", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (result == DialogResult.Yes)
                                        checkAcountVourchers = true;
                                    else
                                        return false;
                                }
                            }
                        }

                        if (strCorrespondingAccountNumberDetail != null)
                        {
                            if (strCorrespondingAccountNumberDetail.Substring(0, 2) == "11")
                            {
                                if (strCorrespondingAccountNumberDetail.Substring(0, 3) == "111")
                                {
                                    DialogResult result = XtraMessageBox.Show(@"Bạn đang định khoản TK Có " + strCorrespondingAccountNumberDetail + " liên quan đến tiền tại dòng: " + (i + 1) + ".\n Bạn có thể nhập ở phiếu chi.\n Bạn có muốn nhập ở đây không? ", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (result == DialogResult.Yes)
                                        checkAcountVourchers = true;
                                    else
                                        return false;
                                }
                                else
                                {
                                    DialogResult result = XtraMessageBox.Show(@"Bạn đang định khoản TK Có " + strCorrespondingAccountNumberDetail + " liên quan đến tiền tại dòng: " + (i + 1) + ".\n Bạn có thể nhập ở giấy báo nợ.\n Bạn có muốn nhập ở đây không? ", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (result == DialogResult.Yes)
                                        checkAcountVourchers = true;
                                    else
                                        return false;
                                }

                                #region "Kiểm tra chi vượt quá lượng tồn"

                                string strCurrentCurrencyCode = (string)gridViewDetail.GetRowCellValue(i, "CurrencyCode");
                                this.CurrencyCurrent = strCurrentCurrencyCode;//Gán loại tiền đang sử dụng trên chứng từ
                                string strBudgetSourceCode = (string)gridViewDetail.GetRowCellValue(i, "BudgetSourceCode"); // Lấy mục nguồn vốn
                                string strCorreAccountNumberDetail = (string)gridViewDetail.GetRowCellValue(i, "CorrespondingAccountNumber"); // tài khoản tiền quỹ (11221,11222)
                                decimal dcTotalAmount = 0;// tổng tiền chi tiền mặt( tiền quỹ)

                                if (strBudgetSourceCode == null)
                                    dcTotalAmount = GeneralDetails.Where(x => x.BudgetSourceCode == strCurrentCurrencyCode && x.CurrencyCode == strCurrentCurrencyCode).Sum(x => x.AmountOc);
                                else
                                    dcTotalAmount = GeneralDetails.Where(x => x.CurrencyCode == strCurrentCurrencyCode).Sum(x => x.AmountOc);

                                this.GetCalculateAmountPayment(strCorreAccountNumberDetail, strBudgetSourceCode, ((DateTime)dtPostDate.EditValue).Month.ToString() + "/" + ((DateTime)dtPostDate.EditValue).Day.ToString() + "/" + ((DateTime)dtPostDate.EditValue).Year.ToString());// thực thi để lây tiền cho phép chi
                                if (dcTotalAmount > this.ClosingAmount)
                                {
                                    if (strBudgetSourceCode != null && strBudgetSourceCode != "")
                                    {
                                        XtraMessageBox.Show("Số chi vượt quá số tồn quỹ, vui lòng kiểm tra lại. Tổng quỹ có thể chi: " + this.ClosingAmount.ToString() + strCurrentCurrencyCode + " theo nguồn " + strBudgetSourceCode,
                                        ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return false;
                                    }
                                    else
                                    {
                                        XtraMessageBox.Show("Số chi vượt quá tồn quỹ, vui lòng kiểm tra lại. Tổng quỹ có thể chi: " + this.ClosingAmount.ToString() + strCurrentCurrencyCode,
                                        ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return false;
                                    }
                                }
                                #endregion
                            }
                        }

                        if (strCorrespondingAccountNumberDetail != null && strAccountNumberDetail != null)
                        {
                            #region Kiem tra khi nguon am

                            // kiểm tra chi tiền khi số dư tiền mặt âm
                            if (strCorrespondingAccountNumberDetail.Substring(0, 3) == "111")
                            {
                                if (!DBOptionHelper.IsPaymentNegativeFund)
                                {
                                    totalAmount = GeneralDetails.Where(x =>
                                                x.CorrespondingAccountNumber.Substring(0, 3) == "111").Sum(x => x.AmountOc);
                                    GetCalculateCashBalance(strAccountNumberDetail, ((DateTime)dtPostDate.EditValue).Month + "/" + ((DateTime)dtPostDate.EditValue).Day + "/" + ((DateTime)dtPostDate.EditValue).Year);// thực thi để lây tiền cho phép chi

                                    if (totalAmount > ClosingAmount)
                                    {
                                        XtraMessageBox.Show("Số chi vượt quá số tồn quỹ, vui lòng kiểm tra lại!",
                                            ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return false;
                                    }
                                }
                            }

                            // kiểm tra chi tiền khi số dư tiền gửi âm
                            if (strCorrespondingAccountNumberDetail.Substring(0, 3) == "112")
                            {
                                if (!DBOptionHelper.IsDepositeNegavtiveFund)
                                {
                                    totalAmount = GeneralDetails.Where(x =>
                                        x.CorrespondingAccountNumber.Substring(0, 3) == "112")
                                        .Sum(x => x.AmountOc);
                                    GetCalculateDepositBalance(strCorrespondingAccountNumberDetail,
                                        ((DateTime)dtPostDate.EditValue).Month + "/" + ((DateTime)dtPostDate.EditValue).Day +
                                        "/" + ((DateTime)dtPostDate.EditValue).Year); // thực thi để lây tiền cho phép chi

                                    if (totalAmount > ClosingAmount)
                                    {
                                        XtraMessageBox.Show(
                                            "Số chi vượt quá số tồn quỹ, vui lòng kiểm tra lại!",
                                            ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                                            MessageBoxIcon.Warning);
                                        return false;
                                    }
                                }
                            }

                            // kiểm tra chi tiền khi nguồn âm
                            if (strAccountNumberDetail.Substring(0, 3) == "461" ||
                                strAccountNumberDetail.Substring(0, 3) == "661")
                            {
                                if (!DBOptionHelper.IsPaymentNegativeBudgetSource)
                                {
                                    // Số dư Có TK 4612
                                    GetCalculateCapitalBalance("4612", budgetSourceCode,
                                        ((DateTime)dtPostDate.EditValue).Month + "/" + ((DateTime)dtPostDate.EditValue).Day +
                                        "/" + ((DateTime)dtPostDate.EditValue).Year); // thực thi để lây tiền cho phép chi
                                    var accountBalance = ClosingAmount;

                                    // Số dư Nợ TK 6612
                                    GetCalculateCapitalBalance("6612", budgetSourceCode,
                                        ((DateTime)dtPostDate.EditValue).Month + "/" + ((DateTime)dtPostDate.EditValue).Day +
                                        "/" + ((DateTime)dtPostDate.EditValue).Year); // thực thi để lây tiền cho phép chi

                                    accountBalance = accountBalance - ClosingAmount;

                                    totalAmount = GeneralDetails.Where(x =>
                                        x.BudgetSourceCode == budgetSourceCode &&
                                        (x.AccountNumber.Substring(0, 3) == "461" || x.AccountNumber.Substring(0, 3) == "661"))
                                        .Sum(x => x.AmountOc);
                                    if (totalAmount > accountBalance)
                                    {
                                        XtraMessageBox.Show(
                                            "Số chi vượt quá số tồn của nguồn, vui lòng kiểm tra lại!",
                                            ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                                            MessageBoxIcon.Warning);
                                        return false;
                                    }
                                }
                            }
                            #endregion
                        }
                    }
                }
            }

            if (kt != true)
            {
                XtraMessageBox.Show(@"Bạn chưa nhập chi tiết chứng từ", @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (GeneralDetails.Count > 0)
            {
                int i = 0;
                var lstRowAmounts = new List<string>();
                foreach (var voucher in GeneralDetails)
                {
                    // bắt lỗi thiếu thông tin trong tài khoản
                    if (!ValidAccountDetail(voucher))
                    {
                        //XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDetaiVoucherNotValid"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    if (voucher.AmountOc == 0)
                        lstRowAmounts.Add((i + 1).ToString());
                    var isDetailValid = true;
                    if (voucher.DetailBy != null)
                    {
                        var detailFieldNames = voucher.DetailBy.Split(';');
                        detailFieldNames = detailFieldNames.Where(w => !w.Contains("ProjectId")).ToArray();
                        if (detailFieldNames.Any(t => voucher.GetType().GetProperty(t) != null && voucher[t] != null))
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
                    i++;
                }
                if (lstRowAmounts.Count > 0)
                    if (DialogResult.No == XtraMessageBox.Show("Thành tiền bằng 0 tại dòng " + string.Join(", ", lstRowAmounts.ToArray()) + ". Bạn có muốn lưu chứng từ không?",
                            ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        return false;
                    }
            }

            return true;
        }

        protected override void InitRefInfo()
        {
            if (GeneralVocher != null || ActionMode != ActionModeVoucherEnum.AddNew) return;
            dtPostDate.EditValue = BasePostedDate;
            dtRefDate.EditValue = dtPostDate.EditValue;
        }

        #endregion

        #region Event

        public override void gridViewDetail_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName.Equals("AmountExchange") || e.Column.FieldName.Equals("ExchangeRate") || e.Column.FieldName.Equals("AmountOc") || e.Column.FieldName.Equals("AutoBusiness") || e.Column.FieldName.Equals("CurrencyCode") || e.Column.FieldName.Equals("AccountNumber") || e.Column.FieldName.Equals("CorrespondingAccountNumber") || e.Column.FieldName.Equals("Description"))
            {
                gridViewDetail.PostEditor();
                var rowHandle = gridViewDetail.FocusedRowHandle;

                var exchange = (decimal)gridViewDetail.GetRowCellValue(e.RowHandle, "ExchangeRate");
                var amountOc = (decimal)gridViewDetail.GetRowCellValue(e.RowHandle, "AmountOc");
                var amountEx = (decimal)gridViewDetail.GetRowCellValue(e.RowHandle, "AmountExchange");
                var currencyCode = (string)gridViewDetail.GetRowCellValue(e.RowHandle, "CurrencyCode");
                var accountNumber = (string)gridViewDetail.GetRowCellValue(e.RowHandle, "AccountNumber");
                var correspondingAccountNumber = (string)gridViewDetail.GetRowCellValue(e.RowHandle, "CorrespondingAccountNumber");

                if (e.Column.FieldName.Equals("CurrencyCode"))
                {
                    exchange = 1;
                    if (amountEx * exchange != amountOc)
                    {
                        if (currencyCode == "USD")
                        {
                            gridViewDetail.SetRowCellValue(rowHandle, "ExchangeRate", 1);
                            gridViewDetail.SetRowCellValue(rowHandle, "Amount", amountOc);
                            gridViewDetail.SetRowCellValue(rowHandle, "AmountExchange", amountOc);
                        }
                    }
                    if (currencyCode == CurrencyAccounting)
                    {
                        gridViewDetail.SetRowCellValue(gridViewDetail.FocusedRowHandle, "ExchangeRate", 1);
                        gridViewDetail.Columns["ExchangeRate"].OptionsColumn.AllowEdit = false;
                        gridViewDetail.Columns["AmountExchange"].OptionsColumn.AllowEdit = false;
                    }
                    else
                    {
                        gridViewDetail.Columns["ExchangeRate"].OptionsColumn.AllowEdit = true;
                        gridViewDetail.Columns["AmountExchange"].OptionsColumn.AllowEdit = true;
                    }
                }

                if (e.Column.FieldName.Equals("AmountOc"))
                {
                    if (exchange > 0)
                    {
                        if (amountEx != amountOc / exchange)
                        {
                            gridViewDetail.SetRowCellValue(rowHandle, "AmountExchange", Math.Round(amountOc / exchange, int.Parse(_globalVariable.CurrencyDecimalDigits)));
                        }
                    }
                }

                if (e.Column.FieldName.Equals("ExchangeRate"))
                {
                    if (exchange > 0)
                    {
                        if (amountOc / exchange != amountEx)
                        {
                            if (currencyCode == "USD")
                            {
                                gridViewDetail.SetRowCellValue(rowHandle, "AmountExchange", amountOc);
                                gridViewDetail.SetRowCellValue(rowHandle, "Amount", amountOc);
                                gridViewDetail.SetRowCellValue(rowHandle, "ExchangeRate", 1);
                            }
                            else
                            {
                                gridViewDetail.SetRowCellValue(rowHandle, "AmountExchange", amountOc / exchange);
                            }
                        }
                    }
                    else
                    {
                        gridViewDetail.SetRowCellValue(rowHandle, "ExchangeRate", 1);
                    }
                }

                if (e.Column.FieldName.Equals("AutoBusiness"))
                {
                    var autoBusinessId = (int?)gridViewDetail.GetRowCellValue(rowHandle, "AutoBusiness");
                    if (autoBusinessId != 0)
                    {
                        var autoBusiness = (AutoBusinessModel)_rpsAutoBusiness.GetRowByKeyValue(autoBusinessId);
                        gridViewDetail.SetRowCellValue(rowHandle, "AccountNumber", autoBusiness.DebitAccountNumber);
                        gridViewDetail.SetRowCellValue(rowHandle, "CorrespondingAccountNumber", autoBusiness.CreditAccountNumber);
                        gridViewDetail.SetRowCellValue(rowHandle, "VoucherTypeId", autoBusiness.VoucherTypeId);
                        gridViewDetail.SetRowCellValue(rowHandle, "Description", autoBusiness.Description);
                        gridViewDetail.SetRowCellValue(rowHandle, "BudgetSourceCode", autoBusiness.BudgetSourceCode);
                        gridViewDetail.SetRowCellValue(rowHandle, "BudgetItemCode", autoBusiness.BudgetItemCode);
                    }
                }

                if (e.Column.FieldName.Equals("AccountNumber"))
                {
                    if (accountNumber != null)
                    {
                        if (accountNumber == "11121" || accountNumber == "11221")
                        {
                            gridViewDetail.SetRowCellValue(e.RowHandle, "CurrencyCode", CurrencyAccounting);
                            gridViewDetail.SetRowCellValue(e.RowHandle, "ExchangeRate", 1);
                        }
                        if (accountNumber == "11122" || accountNumber == "11222")
                        {
                            gridViewDetail.SetRowCellValue(e.RowHandle, "CurrencyCode", CurrencyLocal);
                        }
                    }
                }

                if (e.Column.FieldName.Equals("CorrespondingAccountNumber"))
                {
                    if (correspondingAccountNumber != null)
                    {
                        if (correspondingAccountNumber == "11121" || correspondingAccountNumber == "11221")
                        {
                            gridViewDetail.SetRowCellValue(e.RowHandle, "CurrencyCode", CurrencyAccounting);
                            gridViewDetail.SetRowCellValue(e.RowHandle, "ExchangeRate", 1);
                        }
                        if (correspondingAccountNumber == "11122" || correspondingAccountNumber == "11222")
                        {
                            gridViewDetail.SetRowCellValue(e.RowHandle, "CurrencyCode", CurrencyLocal);
                        }
                    }
                }

                // Lấy dòng đầu tiên
                if (e.Column.FieldName.Equals("Description"))
                {
                    txtDescription.Text = (string)gridViewDetail.GetRowCellValue(0, "Description");
                }

                // valid detail by account in Griddetail voucher---------// 
                if (!e.Column.FieldName.Equals("DetailBy"))
                {
                    var accountNumberDetailBy = "";
                    if (accountNumber != null)
                    {
                        accountNumberDetailBy = GetAccountDetailBy(accountNumber);
                    }
                    var correspondingAccountNumberDetailBy = "";
                    if (correspondingAccountNumber != null)
                    {
                        correspondingAccountNumberDetailBy = GetAccountDetailBy(correspondingAccountNumber);
                    }

                    accountNumberDetailBy = string.IsNullOrEmpty(accountNumberDetailBy) ? correspondingAccountNumberDetailBy : accountNumberDetailBy + ";" + correspondingAccountNumberDetailBy;

                    var detailByArray = accountNumberDetailBy.Split(';').Distinct().ToArray();
                    var detail = string.Join(";", detailByArray);

                    //Bổ sung thêm 2 trường Quantity và ExchangeRate
                    detail = !string.IsNullOrEmpty(detail) ? detail + ";Quantity;ExchangeRate" : detail + "Quantity;ExchangeRate";
                    gridViewDetail.SetRowCellValue(e.RowHandle, "DetailBy", detail);
                }
            }

            //if (e.Column.FieldName == "BudgetItemCode")
            //{
            //    int rowHandle = gridViewDetail.FocusedRowHandle;
            //    if (gridViewDetail.GetRowCellValue(rowHandle, "BudgetItemCode") != null)
            //    {
            //        var budgetItemCode = gridViewDetail.GetRowCellValue(rowHandle, "BudgetItemCode");
            //        var budgetItem = (BudgetItemModel)_rpsBudgetItem.GetRowByKeyValue(budgetItemCode);
            //        if (budgetItem != null)
            //        {
            //            if (budgetItem.BudgetItemCode == "494902")
            //            {
            //                gridViewDetail.SetRowCellValue(rowHandle, "VoucherTypeId", 2);
            //            }
            //            else if (budgetItem.BudgetItemCode == "779902")
            //            {
            //                gridViewDetail.SetRowCellValue(rowHandle, "VoucherTypeId", 3);
            //            }
            //            else
            //                gridViewDetail.SetRowCellValue(rowHandle, "VoucherTypeId", null);
            //        }
            //    }
            //}
        }

        private void FrmXtraGeneralVoucherDetail_Load(object sender, EventArgs e)
        {
            AdjustControlSize(true, true);
        }

        private void dtPostDate_EditValueChanged(object sender, EventArgs e)
        {
            dtRefDate.DateTime = dtPostDate.DateTime;
        }

        private void FrmXtraGeneralVoucherDetail_Resize(object sender, EventArgs e)
        {
            AdjustControlSize(true, true);
        }

        #endregion

        #region Property

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
                //var refDate = (DateTime)dtRefDate.EditValue;
                //var now = DateTime.Now;
                //var newDate = new DateTime(refDate.Year, refDate.Month, refDate.Day, now.Hour, now.Minute, now.Second);
                //return newDate;
                return Convert.ToDateTime(dtRefDate.DateTime.ToShortDateString());
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
                //var refDate = (DateTime)dtPostDate.EditValue;
                //var now = DateTime.Now;
                //var newDate = new DateTime(refDate.Year, refDate.Month, refDate.Day, now.Hour, now.Minute, now.Second);
                //return newDate;
                return Convert.ToDateTime(dtPostDate.DateTime.ToShortDateString());
            }
            set
            {
                dtPostDate.EditValue = value;
            }
        }

        public string JournalMemo
        {
            get { return txtDescription.Text; }
            set { txtDescription.Text = value; }
        }

        public decimal TotalAmountOc { get; set; }

        public decimal TotalAmountExchange { get; set; }

        public int RefTypeId
        {
            get { return (int)BaseRefTypeId; }
            set { BaseRefTypeId = (RefType)value; }
        }

        public long? DepositId { get; set; }

        public long? CashId { get; set; }

        /// <summary>
        /// Nhiệm vụ duy nhất là để chứa dữ liệu khi các chứng từ khác muốn sinh chứng từ chung.
        /// </summary>
        public GeneralVocherModel GeneralVocher { get; set; }

        public IList<GeneralDetailModel> GeneralDetails
        {
            get
            {
                var generalVoucherDetail = new List<GeneralDetailModel>();
                decimal deTotalAmount = 0;
                decimal deTotalAmountExchage = 0;
                if (gridViewDetail.DataSource != null && gridViewDetail.RowCount > 0)
                {
                    for (var i = 0; i < gridViewDetail.RowCount; i++)
                    {
                        var rowVoucherDetailData = (GeneralDetailModel)gridViewDetail.GetRow(i);
                        if (rowVoucherDetailData != null)
                        {
                            var item = new GeneralDetailModel
                            {
                                AccountNumber = rowVoucherDetailData.AccountNumber == "" ? null : rowVoucherDetailData.AccountNumber,
                                CorrespondingAccountNumber = rowVoucherDetailData.CorrespondingAccountNumber == "" ? null : rowVoucherDetailData.CorrespondingAccountNumber,
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
                                BankId = rowVoucherDetailData.BankId,
                                VendorId = rowVoucherDetailData.VendorId == 0 ? null : rowVoucherDetailData.VendorId,
                                InventoryItemId = rowVoucherDetailData.InventoryItemId,
                                DetailBy = rowVoucherDetailData.DetailBy,
                                AutoBusiness = rowVoucherDetailData.AutoBusiness,

                            };
                            generalVoucherDetail.Add(item);
                            deTotalAmount = deTotalAmount + item.AmountOc;
                            deTotalAmountExchage = deTotalAmountExchage + item.AmountExchange;
                        }
                    }
                    TotalAmountExchange = deTotalAmountExchage;
                    TotalAmountOc = deTotalAmount;
                }

                return generalVoucherDetail.ToList();
            }
            set
            {
                if (value == null) value = new List<GeneralDetailModel>();
                if (value.Count > 0)
                {
                    bindingSourceDetail.DataSource = value;
                }
                else
                {
                    var refType = RefTypes.Where(w => w.RefTypeId == (int)RefType.GeneralVoucher)?.First() ?? null;
                    if (refType != null)
                        bindingSourceDetail.DataSource = new List<GeneralDetailModel> { new GeneralDetailModel() { AccountNumber = refType.DefaultDebitAccountId, CorrespondingAccountNumber = refType.DefaultCreditAccountId, AmountOc = 0, ExchangeRate = 1, CurrencyCode = "USD" } };
                    else
                        bindingSourceDetail.DataSource = new List<GeneralDetailModel> { new GeneralDetailModel() { AmountOc = 0, ExchangeRate = 1, CurrencyCode = "USD" } };
                }

                bindingSourceDetail.DataSource = value;
                ColumnsCollection.Clear();
                gridViewDetail.PopulateColumns(value);
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AutoBusiness", ColumnCaption = "ĐK tự động", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 80, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Định khoản tự động", RepositoryControl = _rpsAutoBusiness });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefDetailId", ColumnVisible = false, FixedColumn = FixedStyle.Left, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountNumber", ColumnCaption = "TK nợ", FixedColumn = FixedStyle.Left, ColumnPosition = 2, ColumnVisible = true, ColumnWith = 60, ToolTip = "Tài khoản nợ", RepositoryControl = _rpsAccountNumber });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CorrespondingAccountNumber", ColumnCaption = "TK có", FixedColumn = FixedStyle.Left, ColumnPosition = 3, ColumnVisible = true, ColumnWith = 60, ToolTip = "Tài khoản có", RepositoryControl = _rpsCorrespondingAccountNumber });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnCaption = "Diễn giải", FixedColumn = FixedStyle.None, ColumnPosition = 4, ColumnVisible = true, ColumnWith = 300, ToolTip = "Diễn giải", IsSummaryText = true });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "CurrencyCode", ColumnCaption = "Tiền tệ", ColumnPosition = 5, FixedColumn = FixedStyle.None, ColumnVisible = true, ColumnWith = 50, ToolTip = "Tiền tệ", RepositoryControl = _rpsCurrency });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ExchangeRate", ColumnCaption = "Tỷ giá", ColumnPosition = 6, FixedColumn = FixedStyle.None, ColumnVisible = true, ColumnWith = 80, ToolTip = "tỷ giá", RepositoryControl = _rpsSpinEdit });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AmountOc", ColumnCaption = "Số tiền", ColumnPosition = 7, ColumnType = UnboundColumnType.Decimal, FixedColumn = FixedStyle.None, ColumnVisible = true, ColumnWith = 100, ToolTip = "Số tiền" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AmountExchange", ColumnCaption = "Số tiền QĐ", ColumnPosition = 8, ColumnType = UnboundColumnType.Decimal, FixedColumn = FixedStyle.None, ColumnVisible = true, ColumnWith = 100, ToolTip = "Số tiền quy đổi" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceCode", ColumnCaption = "Nguồn vốn", ColumnPosition = 9, FixedColumn = FixedStyle.None, ColumnVisible = true, ColumnWith = 100, ToolTip = "Nguồn vốn", RepositoryControl = _rpsBudgetSource });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemCode", ColumnCaption = "Mục/TM", ColumnPosition = 10, FixedColumn = FixedStyle.None, ColumnVisible = true, ColumnWith = 100, ToolTip = "Mục/Tiểu mục", RepositoryControl = _rpsBudgetItem });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "VoucherTypeId", ColumnCaption = "Nghiệp vụ", ColumnPosition = 11, FixedColumn = FixedStyle.None, ColumnVisible = true, ColumnWith = 100, ToolTip = "Nghiệp vụ", RepositoryControl = _rpsVoucherTypeId });
                //ColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectId", ColumnCaption = "Dự án", FixedColumn = FixedStyle.None, ColumnPosition = 12, ColumnVisible = true, ColumnWith = 150, ToolTip = "Dự án", RepositoryControl = _rpsProject });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CustomerId", ColumnCaption = "Khách hàng", ColumnPosition = 16, FixedColumn = FixedStyle.None, ColumnVisible = true, ColumnWith = 100, ToolTip = "Khách hàng ", RepositoryControl = _rpsCustomer });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "VendorId", ColumnCaption = "Nhà cung cấp", ColumnPosition = 14, FixedColumn = FixedStyle.None, ColumnVisible = true, ColumnWith = 100, ToolTip = "Nhà cung cấp", RepositoryControl = _rpsVendor });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "EmployeeId", ColumnCaption = "Cán bộ", ColumnPosition = 17, FixedColumn = FixedStyle.None, ColumnVisible = true, ColumnWith = 100, ToolTip = "Nhân viên", RepositoryControl = _rpsEmployees });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectId", ColumnCaption = "Đối tượng khác", ColumnPosition = 15, FixedColumn = FixedStyle.None, ColumnVisible = true, ColumnWith = 100, ToolTip = "Đối tượng khác", RepositoryControl = _rpsAccountingObject });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DepartmentId", ColumnCaption = "Phòng ban", ColumnPosition = 17, FixedColumn = FixedStyle.None, ColumnVisible = true, ColumnWith = 100, ToolTip = "Phòng ban", RepositoryControl = _rpsDepartment });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BankId", ColumnCaption = "TK Ngân hàng", FixedColumn = FixedStyle.None, ColumnPosition = 18, ColumnVisible = true, ColumnWith = 150, ToolTip = "Ngân hàng", RepositoryControl = _rpsBank });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CapitalAllocateCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "InventoryItemId", ColumnCaption = "Vật tư/ CCDC", FixedColumn = FixedStyle.None, ColumnPosition = 19, ColumnVisible = false, ColumnWith = 150, ToolTip = "Vật tư- công cụ dụng cụ" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DetailBy", ColumnVisible = false });
                gridViewDetail = InitGridLayout(ColumnsCollection, gridViewDetail);
                SetNumericFormatControl(gridViewDetail, true);
            }
        }

        public IList<GeneralParalellDetailModel> GeneralParalellDetails
        {
            get
            {
                var generalVoucherDetail = new List<GeneralParalellDetailModel>();
                decimal deTotalAmount = 0;
                decimal deTotalAmountExchage = 0;
                if (gridViewAccountingPararell.DataSource != null && gridViewAccountingPararell.RowCount > 0)
                {
                    for (var i = 0; i < gridViewAccountingPararell.RowCount; i++)
                    {
                        var rowVoucherDetailData = (GeneralParalellDetailModel)gridViewAccountingPararell.GetRow(i);
                        if (rowVoucherDetailData != null)
                        {
                            var item = new GeneralParalellDetailModel
                            {
                                AccountNumber = rowVoucherDetailData.AccountNumber == "" ? null : rowVoucherDetailData.AccountNumber,
                                CorrespondingAccountNumber = rowVoucherDetailData.CorrespondingAccountNumber == "" ? null : rowVoucherDetailData.CorrespondingAccountNumber,
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
                                BankId = rowVoucherDetailData.BankId,
                                VendorId = rowVoucherDetailData.VendorId == 0 ? null : rowVoucherDetailData.VendorId,
                                InventoryItemId = rowVoucherDetailData.InventoryItemId,
                                DetailBy = rowVoucherDetailData.DetailBy,
                                AutoBusiness = rowVoucherDetailData.AutoBusiness
                            };
                            generalVoucherDetail.Add(item);
                            deTotalAmount = deTotalAmount + item.AmountOc;
                            deTotalAmountExchage = deTotalAmountExchage + item.AmountExchange;
                        }
                    }
                    TotalAmountExchange = deTotalAmountExchage;
                    TotalAmountOc = deTotalAmount;
                }

                return generalVoucherDetail.ToList();
            }
            set
            {
                if (value == null) value = new List<GeneralParalellDetailModel>();
                bindingSourceDetailParallel.DataSource = value;
                ColumnsCollectionParalell.Clear();
                gridViewAccountingPararell.PopulateColumns(value);
                ColumnsCollectionParalell.Add(new XtraColumn { ColumnName = "AutoBusiness", ColumnCaption = "ĐK tự động", ColumnPosition = 1, ColumnVisible = false, ColumnWith = 80, FixedColumn = FixedStyle.Left, AllowEdit = true, ToolTip = "Định khoản tự động", RepositoryControl = _rpsAutoBusinessParalell });
                ColumnsCollectionParalell.Add(new XtraColumn { ColumnName = "RefDetailId", ColumnVisible = false, FixedColumn = FixedStyle.Left, Alignment = HorzAlignment.Center });
                ColumnsCollectionParalell.Add(new XtraColumn { ColumnName = "AccountNumber", ColumnCaption = "TK nợ", FixedColumn = FixedStyle.Left, ColumnPosition = 2, ColumnVisible = true, ColumnWith = 60, ToolTip = "Tài khoản nợ", RepositoryControl = _rpsAccountNumberParalell });
                ColumnsCollectionParalell.Add(new XtraColumn { ColumnName = "CorrespondingAccountNumber", ColumnCaption = "TK có", FixedColumn = FixedStyle.Left, ColumnPosition = 3, ColumnVisible = true, ColumnWith = 60, ToolTip = "Tài khoản có", RepositoryControl = _rpsCorrespondingAccountNumberParalell });
                ColumnsCollectionParalell.Add(new XtraColumn { ColumnName = "Description", ColumnCaption = "Diễn giải", FixedColumn = FixedStyle.None, ColumnPosition = 4, ColumnVisible = true, ColumnWith = 300, ToolTip = "Diễn giải", IsSummaryText = true });

                ColumnsCollectionParalell.Add(new XtraColumn { ColumnName = "CurrencyCode", ColumnCaption = "Tiền tệ", ColumnPosition = 5, FixedColumn = FixedStyle.None, ColumnVisible = true, ColumnWith = 50, ToolTip = "Tiền tệ", RepositoryControl = _rpsCurrencyParalell });
                ColumnsCollectionParalell.Add(new XtraColumn { ColumnName = "ExchangeRate", ColumnCaption = "Tỷ giá", ColumnPosition = 6, FixedColumn = FixedStyle.None, ColumnVisible = true, ColumnWith = 80, ToolTip = "Tỷ giá" });
                ColumnsCollectionParalell.Add(new XtraColumn { ColumnName = "AmountOc", ColumnCaption = "Số tiền", ColumnPosition = 7, ColumnType = UnboundColumnType.Decimal, FixedColumn = FixedStyle.None, ColumnVisible = true, ColumnWith = 100, ToolTip = "Số tiền" });
                ColumnsCollectionParalell.Add(new XtraColumn { ColumnName = "AmountExchange", ColumnCaption = "Số tiền QĐ", ColumnPosition = 8, ColumnType = UnboundColumnType.Decimal, FixedColumn = FixedStyle.None, ColumnVisible = true, ColumnWith = 100, ToolTip = "Số tiền quy đổi" });
                ColumnsCollectionParalell.Add(new XtraColumn { ColumnName = "BudgetSourceCode", ColumnCaption = "Nguồn vốn", ColumnPosition = 9, FixedColumn = FixedStyle.None, ColumnVisible = true, ColumnWith = 100, ToolTip = "Nguồn vốn", RepositoryControl = _rpsBudgetSourceParalell });
                ColumnsCollectionParalell.Add(new XtraColumn { ColumnName = "BudgetItemCode", ColumnCaption = "Mục/TM", ColumnPosition = 10, FixedColumn = FixedStyle.None, ColumnVisible = true, ColumnWith = 100, ToolTip = "Mục/Tiểu mục", RepositoryControl = _rpsBudgetItemParalell });
                ColumnsCollectionParalell.Add(new XtraColumn { ColumnName = "VoucherTypeId", ColumnCaption = "Nghiệp vụ", ColumnPosition = 11, FixedColumn = FixedStyle.None, ColumnVisible = true, ColumnWith = 100, ToolTip = "Nghiệp vụ", RepositoryControl = _rpsVoucherTypeIdParalell });
                //ColumnsCollectionParalell.Add(new XtraColumn { ColumnName = "ProjectId", ColumnCaption = "Dự án", FixedColumn = FixedStyle.None, ColumnPosition = 12, ColumnVisible = true, ColumnWith = 150, ToolTip = "Dự án",RepositoryControl =_rpsProjectParalell });
                ColumnsCollectionParalell.Add(new XtraColumn { ColumnName = "CustomerId", ColumnCaption = "Khách hàng", ColumnPosition = 16, FixedColumn = FixedStyle.None, ColumnVisible = true, ColumnWith = 100, ToolTip = "Khách hàng ", RepositoryControl = _rpsCustomerParalell });
                ColumnsCollectionParalell.Add(new XtraColumn { ColumnName = "VendorId", ColumnCaption = "Nhà cung cấp", ColumnPosition = 14, FixedColumn = FixedStyle.None, ColumnVisible = true, ColumnWith = 100, ToolTip = "Nhà cung cấp", RepositoryControl = _rpsVendorParalell });
                ColumnsCollectionParalell.Add(new XtraColumn { ColumnName = "EmployeeId", ColumnCaption = "Cán bộ", ColumnPosition = 17, FixedColumn = FixedStyle.None, ColumnVisible = true, ColumnWith = 100, ToolTip = "Nhân viên", RepositoryControl = _rpsEmployeesParalell });
                ColumnsCollectionParalell.Add(new XtraColumn { ColumnName = "AccountingObjectId", ColumnCaption = "Đối tượng khác", ColumnPosition = 15, FixedColumn = FixedStyle.None, ColumnVisible = true, ColumnWith = 100, ToolTip = "Đối tượng khác", RepositoryControl = _rpsAccountingObjectParalell });
                ColumnsCollectionParalell.Add(new XtraColumn { ColumnName = "DepartmentId", ColumnCaption = "Phòng ban", ColumnPosition = 17, FixedColumn = FixedStyle.None, ColumnVisible = true, ColumnWith = 100, ToolTip = "Phòng ban", RepositoryControl = _rpsDepartmentParalell });
                ColumnsCollectionParalell.Add(new XtraColumn { ColumnName = "BankId", ColumnCaption = "TK Ngân hàng", FixedColumn = FixedStyle.None, ColumnPosition = 18, ColumnVisible = true, ColumnWith = 150, ToolTip = "Ngân hàng", RepositoryControl = _rpsBankParalell });
                ColumnsCollectionParalell.Add(new XtraColumn { ColumnName = "CapitalAllocateCode", ColumnVisible = false });
                ColumnsCollectionParalell.Add(new XtraColumn { ColumnName = "InventoryItemId", ColumnCaption = "Vật tư/ CCDC", FixedColumn = FixedStyle.None, ColumnPosition = 19, ColumnVisible = false, ColumnWith = 150, ToolTip = "Vật tư- công cụ dụng cụ" });
                ColumnsCollectionParalell.Add(new XtraColumn { ColumnName = "RefId", ColumnVisible = false });
                ColumnsCollectionParalell.Add(new XtraColumn { ColumnName = "DetailBy", ColumnVisible = false });
                gridViewAccountingPararell = InitGridLayout(ColumnsCollectionParalell, gridViewAccountingPararell);
                SetNumericFormatControl(gridViewAccountingPararell, true);
            }
        }

        #endregion
    }
}
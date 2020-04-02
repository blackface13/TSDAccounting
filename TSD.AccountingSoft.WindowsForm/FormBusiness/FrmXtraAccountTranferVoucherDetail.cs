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
using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;
using TSD.AccountingSoft.Session;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Model.BusinessObjects.General;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.View.General;
using TSD.AccountingSoft.WindowsForm.Resources;
using TSD.Enum;
using DevExpress.Utils;
using DevExpress.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using TSD.AccountingSoft.Presenter.General;
using System.Threading;
using DevExpress.XtraEditors.Mask;



namespace TSD.AccountingSoft.WindowsForm.FormBusiness
{
    public partial class FrmXtraAccountTranferVoucherDetail : FrmXtraBaseVoucherDetail, IGeneralVoucherView, IAccountTranferVouchersView
    {
        #region Declare

        private RepositoryItemCalcEdit _rpsSpinEdit;
        private readonly GenveralVoucherPresenter _generalVoucherPresenter;
        private AccountTranferVouchersPresenter _accountTranferVouchersPresenter;

        #endregion

        #region Override functions

        protected override void InitData()
        {
            DateTime postedDate = Convert.ToDateTime(DBOptionHelper.PostedDate);
            dtPostDate.EditValue =  new DateTime(postedDate.Year, 12, 31);
            dtRefDate.EditValue = dtPostDate.DateTime;
            base.InitData();
            if (MasterBindingSource.Current != null)
            {
                var generalVoucherDetailId = ((GeneralVocherModel)MasterBindingSource.Current).RefId;
                KeyValue = generalVoucherDetailId.ToString(CultureInfo.InvariantCulture);
            }
            if (long.Parse(KeyValue) != 0)
            {
                _generalVoucherPresenter.Display(long.Parse(KeyValue));
                _accountTranferVouchersPresenter.Display(long.Parse(KeyValue));
                var obj = (string)grdViewAccountTranfer.GetRowCellValue(0, "CurrencyCode");
                cboCurrency.EditValue = obj;
            }
            else
            {
                GeneralDetails = new List<GeneralDetailModel>();
                GetAccountTranferVourchersUpdateOrInsert = new List<AccountTranferVourcherModel>();
            }

            if (ActionMode == ActionModeVoucherEnum.Edit)
            {
                IsAccountTranfer = false;

                //DialogResult yesno = MessageBox.Show(@"Bạn có muốn kết chuyển lại không?", @"Thông báo", MessageBoxButtons.YesNo);
                //if (yesno == DialogResult.No)
                //    IsAccountTranfer = false;
                //else //Phân bổ lại
                //{
                //    IsAccountTranfer = true;
                //    _accountTranferVouchersPresenter.Display(PostedDate, CurrencyCode, RefTypeId);
                //}

            }
            if(ActionMode == ActionModeVoucherEnum.AddNew)
            {
                CurrencyCode = null;
            }
            if (ActionMode == ActionModeVoucherEnum.None)
            {
                txtAccountTranferDescription.Enabled = false;
                cboCurrency.Enabled = false;
            }
            else
            {
                txtAccountTranferDescription.Enabled = true;
                cboCurrency.Enabled = true;
            }
            BindGridDetail();
            grdDetail.DataSource = bindingSourceDetail;
            // gridViewDetail.OptionsBehavior.AllowAddRows = DefaultBoolean.False;
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
            if (ActionMode == ActionModeVoucherEnum.AddNew || ActionMode == ActionModeVoucherEnum.DuplicateVoucher)
                RefId = 0;

            #region Lưu chi tiết chứng từ chung

            IList<AccountTranferVourcherModel> lstAccountTranferVourchers = new List<AccountTranferVourcherModel>();
            if (grdViewAccountTranfer.RowCount > 0)
            {
                for (int i = 0; i < grdViewAccountTranfer.RowCount; i++)
                {
                    var rowAccountTranfer = (AccountTranferVourcherModel)grdViewAccountTranfer.GetRow(i);
                    lstAccountTranferVourchers.Add(rowAccountTranfer);
                }
            }
            long lnRefId = _generalVoucherPresenter.Save(); // Cập nhật chứng từ chung

            #endregion


            #region chứng từ kết chuyển

            foreach (var it in lstAccountTranferVourchers)
            {
                it.RefId = lnRefId;
            }
            GetAccountTranferVourchersUpdateOrInsert = lstAccountTranferVourchers.ToList();

            #endregion

            _accountTranferVouchersPresenter.Save(lstAccountTranferVourchers, long.Parse(KeyValue));

            return lnRefId;
        }

        protected override void AddNewVoucher()
        {
            txtAccountTranferDescription.Text = "";
            base.AddNewVoucher();
        }

        protected override void EditVoucher()
        {
            base.EditVoucher();

            //ActionMode = ActionModeVoucherEnum.Edit;
            //DialogResult yesno = MessageBox.Show(ResourceHelper.GetResourceValueByName("ResReAccountTranfer"),
            //ResourceHelper.GetResourceValueByName("ResDetailContent"),
            //MessageBoxButtons.YesNo);

            //if (yesno == DialogResult.No)
            //    IsAccountTranfer = false;
            //else //Phân bổ lại
            //{
            //    IsAccountTranfer = true;
            //    _accountTranferVouchersPresenter.Display(PostedDate, CurrencyCode, RefTypeId);
            //}
            //// _accountTranferVouchersPresenter.Display(PostedDate, CurrencyCode, RefTypeId);
            //BindGridDetail();
            //cboCurrency.Enabled = true;
            txtAccountTranferDescription.Enabled = true;
        }

        protected override void DeleteVoucher()
        {
            var refId = RefId > 0 ? RefId : long.Parse(_keyForSend);
            new GenveralVoucherPresenter(null).Delete(refId);
            cboCurrency.Enabled = false;
            txtAccountTranferDescription.Enabled = false;
            _accountTranferVouchersPresenter.Display(long.Parse(KeyValue));
        }

        protected override void MoveFirstVoucher()
        {
            base.MoveFirstVoucher();
            _accountTranferVouchersPresenter.Display(long.Parse(KeyValue));
        }

        protected override void MoveLastVoucher()
        {
            base.MoveLastVoucher();
            _accountTranferVouchersPresenter.Display(long.Parse(KeyValue));
        }

        protected override void MovePreviousVoucher()
        {
            base.MovePreviousVoucher();
            _accountTranferVouchersPresenter.Display(long.Parse(KeyValue));
        }

        protected override void MoveNextVoucher()
        {
            base.MoveNextVoucher();
            _accountTranferVouchersPresenter.Display(long.Parse(KeyValue));
        }

        protected override bool ValidData()
        {
            if (string.IsNullOrEmpty(txtRefNo.Text))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResReceiptRefNo"),ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRefNo.Focus();
                return false;
            }

            if (RefNo.Length == 0)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResRefNo"),ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,MessageBoxIcon.Error);
                txtRefNo.Focus();
                return false;
            }

            bool kt = false;
            var lstRowAmounts = new List<string>();
            bool checkAcountVourchers = false;
            for (var i = 0; i < gridViewDetail.RowCount; i++)
            {
                if (gridViewDetail.GetRow(i) != null)
                {
                    if ((decimal)gridViewDetail.GetRowCellValue(i, "AmountOc") == 0)
                        lstRowAmounts.Add((i + 1).ToString());
                    kt = true;
                    string strAccountNumberDetail = (string)gridViewDetail.GetRowCellValue(i, "AccountNumber") ?? "";
                    string strCorrespondingAccountNumberDetail = (string)gridViewDetail.GetRowCellValue(i, "CorrespondingAccountNumber") ?? "";

                    if (strAccountNumberDetail == null && strCorrespondingAccountNumberDetail == null)
                    {
                        XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResVoucherDetail"),
                        ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    if (checkAcountVourchers == false && strAccountNumberDetail != null)
                    {
                        if (strAccountNumberDetail.StartsWith("11"))
                        {
                            if (strAccountNumberDetail.StartsWith("111"))
                            {
                                DialogResult result = XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResSetAccountNumber") + strAccountNumberDetail + ResourceHelper.GetResourceValueByName(" RetNoticeReceiptVoucher"),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (result == DialogResult.Yes)
                                    checkAcountVourchers = true;
                                else
                                    return false;
                            }
                            else
                            {
                                DialogResult result = XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResSetAccountNumber") + strAccountNumberDetail + ResourceHelper.GetResourceValueByName(" ResNoticeReceiptEstimate"),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (result == DialogResult.Yes)
                                    checkAcountVourchers = true;
                                else
                                    return false;
                            }
                        }
                        if (strCorrespondingAccountNumberDetail.StartsWith("11"))
                        {

                            if (strCorrespondingAccountNumberDetail.StartsWith("111"))
                            {
                                DialogResult result = XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResSetCorrespondingAccountNumber") + strCorrespondingAccountNumberDetail + ResourceHelper.GetResourceValueByName("RetNoticePayVoucher"),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (result == DialogResult.Yes)
                                    checkAcountVourchers = true;
                                else
                                    return false;

                            }
                            else
                            {
                                DialogResult result = XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResSetCorrespondingAccountNumber") + strCorrespondingAccountNumberDetail + ResourceHelper.GetResourceValueByName("RetNoticeReceiptDeposit"),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (result == DialogResult.Yes)
                                    checkAcountVourchers = true;
                                else
                                    return false;
                            }

                        }
                    }
                }
            }

            if (kt != true)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResNoticeNotRecords"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (lstRowAmounts.Count > 0)
                if (DialogResult.No == XtraMessageBox.Show("Thành tiền bằng 0 tại dòng " + string.Join(", ", lstRowAmounts.ToArray()) + ". Bạn có muốn lưu chứng từ không?",
                        ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    return false;
                }

            #region lấy tổng tin kết chuyển
            if ((ActionMode == ActionModeVoucherEnum.Edit && IsAccountTranfer) || ActionMode == ActionModeVoucherEnum.AddNew)
            {
                IList<AccountTranferVourcherModel> lst = new List<AccountTranferVourcherModel>();
                if (grdViewAccountTranfer.RowCount > 0)
                {
                    for (int i = 0; i < grdViewAccountTranfer.RowCount; i++)
                    {
                        var rowAccountTranfer = (AccountTranferVourcherModel)grdViewAccountTranfer.GetRow(i);
                        lst.Add(rowAccountTranfer);
                    }
                }

                //IList<GeneralDetailModel> lstGeneralDetail = GeneralDetails.ToList();
                //foreach (var item in lst)
                //{
                //    decimal totalSum = lstGeneralDetail.Where(x => x.BudgetSourceCode == item.BudgetSourceCode && x.VoucherTypeId == 9 && x.AccountNumber == item.AccountNumber).Sum(x => x.AmountOc);
                //    if (totalSum != item.AmountOc)
                //    {
                //        XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResTotalAmountAccountTranfer") + item.AccountNumber + ResourceHelper.GetResourceValueByName("NotEqual") + item.AmountOc + ResourceHelper.GetResourceValueByName("ResFollowBudgetSource") + item.BudgetSourceCode,
                //        ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                //        MessageBoxIcon.Error);
                //        return false;
                //    }
                //}
            }

            #endregion

            return true;
        }

        protected override void InitRefInfo()
        {
            if (ActionMode != ActionModeVoucherEnum.AddNew) return;
            dtPostDate.EditValue = DateTime.Parse(new GlobalVariable().FinancialEndOfDate);
            dtRefDate.EditValue = dtPostDate.EditValue;
        }

        #endregion

        #region Events 

        public FrmXtraAccountTranferVoucherDetail()
        {
            InitializeComponent();
            _generalVoucherPresenter = new GenveralVoucherPresenter(this);
            _accountTranferVouchersPresenter = new AccountTranferVouchersPresenter(this);
        }

        private void lookUpCurrencyCode_EditValueChanged(object sender, EventArgs e)
        {
            if (ActionMode == ActionModeVoucherEnum.AddNew)
            {
                string str = dtPostDate.DateTime.ToShortDateString();
                if (!str.Contains("31/12"))
                {
                    XtraMessageBox.Show("Bạn Phải chọn hạch toán là ngày: 31/12", "Thông báo", MessageBoxButtons.OK);
                    dtPostDate.Focus();
                    return;
                }
                // Load lại lưới
                _accountTranferVouchersPresenter.Display(PostedDate, CurrencyCode);
                BindGridDetail();
                GeneratedBaseRefNo();
            }

        }

        private void FrmXtraAccountTranferVoucherDetail_Load(object sender, EventArgs e)
        {
            AdjustControlSize(false, false);
        }

        private void FrmXtraAccountTranferVoucherDetail_Resize(object sender, EventArgs e)
        {
            AdjustControlSize(false, false);
        }

        private void dtPostDate_Validated(object sender, EventArgs e)
        {

            if (dtPostDate.DateTime.ToShortDateString().Contains("31/12"))
            {
                _accountTranferVouchersPresenter.Display(PostedDate, CurrencyCode);
                BindGridDetail();
                txtAccountTranferDescription.Text = @"Kết chuyển tài khoản ngày " +
                                                    dtPostDate.DateTime.ToShortDateString();
            }
            else
            {
                XtraMessageBox.Show("Bạn Phải chọn hạch toán là ngày: 31/12",
                "Thông báo", MessageBoxButtons.OK);
                _accountTranferVouchersPresenter.Display(PostedDate, "");
                BindGridDetail();
                dtPostDate.Focus();
            }
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
                var exchangeRateCol = gridViewDetail.Columns["ExchangeRate"];
                var customerIdCol = gridViewDetail.Columns["CustomerId"];
                var currencyCodeCol = gridViewDetail.Columns["CurrencyCode"];
                var inventoryItemCodeCol = gridViewDetail.Columns["InventoryItemId"];
                var voucherTypeIdCol = gridViewDetail.Columns["VoucherTypeId"];
                //var projectCol = gridViewDetail.Columns["ProjectId"];
                //Giá trị cột thông tin kiểm tra
                var accountNumber = (string)gridViewDetail.GetRowCellValue(e.RowHandle, accountNumberCol);
                var correspondingAccountNumber = (string)gridViewDetail.GetRowCellValue(e.RowHandle, correspondingAccountNumberCol);
                var budgetSourceCode = (string)gridViewDetail.GetRowCellValue(e.RowHandle, budgetSourceCodeCol);
                var budgetItemCode = (string)gridViewDetail.GetRowCellValue(e.RowHandle, budgetItemCodeCol);
                var straccountingObjectId = (int?)gridViewDetail.GetRowCellValue(e.RowHandle, accountingObjectIdCol);
                var employeeId = (int?)gridViewDetail.GetRowCellValue(e.RowHandle, employeeIdCol);
                var vendorId = (int?)gridViewDetail.GetRowCellValue(e.RowHandle, vendorIdCol);
                var exchangeRate = (decimal)gridViewDetail.GetRowCellValue(e.RowHandle, exchangeRateCol);
                var currencyCode = (string)gridViewDetail.GetRowCellValue(e.RowHandle, currencyCodeCol);
                var customerId = (int?)gridViewDetail.GetRowCellValue(e.RowHandle, customerIdCol);
                var inventoryItemId = (int?)gridViewDetail.GetRowCellValue(e.RowHandle, inventoryItemCodeCol);
                var voucherTypeId = (int?)gridViewDetail.GetRowCellValue(e.RowHandle, voucherTypeIdCol);
                //var projectId = (int?)gridViewDetail.GetRowCellValue(e.RowHandle, projectCol);

                //if (accountNumber == null && correspondingAccountNumber == null)
                //{
                //    e.Valid = false;
                //    gridViewDetail.SetColumnError(accountNumberCol, "Bạn phải chọn ít nhất TK nợ hoặc tài khoản có");
                //}

                if (accountNumber == null)
                {
                    e.Valid = false;
                    gridViewDetail.SetColumnError(accountNumberCol, @"Bạn đang chưa nhập tài khoản nợ!");
                }
                if (correspondingAccountNumber == null)
                {
                    e.Valid = false;
                    gridViewDetail.SetColumnError(correspondingAccountNumberCol, @"Bạn đang chưa nhập tài khoản có!");
                    //return false;
                }
                var rowValue = (AccountModel)_rpsAccountNumber.GetRowByKeyValue(accountNumber);
                if (accountNumber != null)
                {
                    //Kiểm tra tài khoản Nợ chi tiết
                    if (!GlobalVariable.IsPostToParentAccount)
                    {
                        if (rowValue.IsDetail != true)
                        {
                            e.Valid = false;
                            gridViewDetail.SetColumnError(accountNumberCol, @"Bạn phải nhập tài khoản nợ chi tiết hơn!");
                        }
                    }

                }
                //Kiểm tra tài khoản Có chi tiết
                rowValue = (AccountModel)_rpsAccountNumber.GetRowByKeyValue(correspondingAccountNumber);
                if (correspondingAccountNumber != null)
                {
                    if (!GlobalVariable.IsPostToParentAccount)
                    {
                        if (rowValue.IsDetail != true)
                        {
                            e.Valid = false;
                            gridViewDetail.SetColumnError(correspondingAccountNumberCol, @"Bạn phải nhập tài khoản có chi tiết hơn!");
                        }
                    }
                }
                // TK Nợ/có Trùng nhau
                if (accountNumber == correspondingAccountNumber)
                {
                    e.Valid = false;
                    gridViewDetail.SetColumnError(correspondingAccountNumberCol, ResourceHelper.GetResourceValueByName("ResAccountAndCorrespondingAccountNumber"));
                }
                //=== Tỷ giả <=0
                if (exchangeRate <= 0)
                {
                    e.Valid = false;
                    gridViewDetail.SetColumnError(exchangeRateCol, @"Bạn phải nhập tỷ giả >=0!");
                }


                if (voucherTypeId != 9) //Nếu là kết chuyển không cần kiểm tra
                {

                    //Kiểm tra tài khoản theo nguồn vốn
                    rowValue = (AccountModel)_rpsAccountNumber.GetRowByKeyValue(accountNumber);
                    if (accountNumber != null)
                    {
                        if (rowValue.IsBudgetSource && budgetSourceCode == null)
                        {
                            e.Valid = false;
                            gridViewDetail.SetColumnError(budgetSourceCodeCol, ResourceHelper.GetResourceValueByName("ResReceiptVoucherbudgetSource"));
                        }
                    }


                    rowValue = (AccountModel)_rpsAccountNumber.GetRowByKeyValue(correspondingAccountNumber);
                    if (correspondingAccountNumber != null)
                    {

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
                    }


                    if (currencyCode == null || currencyCode == "")
                    {
                        e.Valid = false;
                        gridViewDetail.SetColumnError(currencyCodeCol, "Bạn chưa chọn tiền tệ");
                    }

                    //Kiểm tra tài khoản theo mục/tiểu mục
                    rowValue = (AccountModel)_rpsAccountNumber.GetRowByKeyValue(accountNumber);

                    if (accountNumber != null)
                    {
                        if (rowValue.IsBudgetItem && budgetItemCode == null)
                        {
                            e.Valid = false;
                            gridViewDetail.SetColumnError(budgetItemCodeCol, ResourceHelper.GetResourceValueByName("ResReceiptVoucherbudgetItem"));
                        }

                    }

                    rowValue = (AccountModel)_rpsAccountNumber.GetRowByKeyValue(correspondingAccountNumber);
                    if (correspondingAccountNumber != null)
                    {
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

                    }

                    //Kiểm tra tài khoản theo đối tượng khác
                    rowValue = (AccountModel)_rpsAccountNumber.GetRowByKeyValue(accountNumber);

                    if (accountNumber != null)
                    {
                        if (rowValue.IsAccountingObject && straccountingObjectId == null)
                        {
                            e.Valid = false;
                            gridViewDetail.SetColumnError(accountingObjectIdCol, ResourceHelper.GetResourceValueByName("ResReceiptVoucheraccountingObject"));
                        }
                    }

                    rowValue = (AccountModel)_rpsAccountNumber.GetRowByKeyValue(correspondingAccountNumber);

                    if (correspondingAccountNumber != null)
                    {

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
                    }

                    // Kiểm tra tài khoản theo khách hàng=====================================
                    rowValue = (AccountModel)_rpsAccountNumber.GetRowByKeyValue(accountNumber);

                    if (accountNumber != null)
                    {
                        if (rowValue.IsCustomer && customerId == null)
                        {
                            e.Valid = false;
                            gridViewDetail.SetColumnError(customerIdCol, @"Bạn chưa chọn khách hàng theo tài khoản đã chọn");
                        }


                    }

                    rowValue = (AccountModel)_rpsAccountNumber.GetRowByKeyValue(correspondingAccountNumber);

                    if (correspondingAccountNumber != null)
                    {
                        if (rowValue.IsCustomer && customerId == null)
                        {
                            e.Valid = false;
                            gridViewDetail.SetColumnError(customerIdCol, @"Bạn chưa chọn khách hàng theo tài khoản đã chọn");
                        }

                    }

                    // Kiểm tra tài khoản theo nhân viên =======================================
                    rowValue = (AccountModel)_rpsAccountNumber.GetRowByKeyValue(accountNumber);
                    if (accountNumber != null)
                    {
                        if (rowValue.IsEmployee && employeeId == null)
                        {
                            e.Valid = false;
                            gridViewDetail.SetColumnError(customerIdCol, @"Bạn chưa chọn cán bộ theo tài khoản đã chọn");
                        }

                    }

                    rowValue = (AccountModel)_rpsAccountNumber.GetRowByKeyValue(correspondingAccountNumber);
                    if (correspondingAccountNumber != null)
                    {
                        if (rowValue.IsEmployee && employeeId == null)
                        {
                            e.Valid = false;
                            gridViewDetail.SetColumnError(customerIdCol, @"Bạn chưa chọn cán bộ theo tài khoản đã chọn");
                        }
                    }



                    // Kiểm tra tài khoản theo nhà cung cấp ==================================
                    rowValue = (AccountModel)_rpsAccountNumber.GetRowByKeyValue(accountNumber);
                    if (accountNumber != null)
                    {
                        if (rowValue.IsVendor && vendorId == null)
                        {
                            e.Valid = false;
                            gridViewDetail.SetColumnError(customerIdCol, @"Bạn chưa chọn nhà cung cấp theo tài khoản đã chọn");
                        }


                    }
                    rowValue = (AccountModel)_rpsAccountNumber.GetRowByKeyValue(correspondingAccountNumber);
                    if (correspondingAccountNumber != null)
                    {
                        if (rowValue.IsVendor && vendorId == null)
                        {
                            e.Valid = false;
                            gridViewDetail.SetColumnError(customerIdCol, @"Bạn chưa nhà cung cấp theo tài khoản đã chọn");
                        }

                    }

                    // Kiểm tra tài khoản theo vật tư/CCDC ==================================
                    rowValue = (AccountModel)_rpsAccountNumber.GetRowByKeyValue(accountNumber);
                    if (accountNumber != null)
                    {
                        if (rowValue.IsInventoryItem && (inventoryItemId == null))
                        {
                            e.Valid = false;
                            gridViewDetail.SetColumnError(inventoryItemCodeCol, @"Bạn chưa chọn vật tư - công cụ dụng cụ theo tài khoản đã chọn");
                        }


                    }
                    rowValue = (AccountModel)_rpsAccountNumber.GetRowByKeyValue(correspondingAccountNumber);
                    if (correspondingAccountNumber != null)
                    {
                        if (rowValue.IsInventoryItem && (inventoryItemId == null))
                        {
                            e.Valid = false;
                            gridViewDetail.SetColumnError(inventoryItemCodeCol, @"Bạn chưa Bạn chưa chọn vật tư - công cụ dụng cụ theo tài khoản đã chọn");
                        }

                    }

                    // Kiểm tra tài khoản theo dự án ==================================
                    //rowValue = (AccountModel)_rpsAccountNumber.GetRowByKeyValue(accountNumber);
                    //if (accountNumber != null)
                    //{
                    //    if (rowValue.IsProject && (projectId == null))
                    //    {
                    //        e.Valid = false;
                    //        gridViewDetail.SetColumnError(projectCol, ResourceHelper.GetResourceValueByName("ResProjectFollowAccount"));
                    //    }
                    //}
                    //rowValue = (AccountModel)_rpsAccountNumber.GetRowByKeyValue(correspondingAccountNumber);
                    //if (correspondingAccountNumber != null)
                    //{
                    //    if (rowValue.IsProject && (projectId == null))
                    //    {
                    //        e.Valid = false;
                    //        gridViewDetail.SetColumnError(projectCol, ResourceHelper.GetResourceValueByName("ResProjectFollowAccount"));

                    //    }

                    //}
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
            if (e.Column.FieldName.Equals("AmountExchange") || e.Column.FieldName.Equals("ExchangeRate") || e.Column.FieldName.Equals("AmountOc") || e.Column.FieldName.Equals("AutoBusiness") || e.Column.FieldName.Equals("CurrencyCode"))
            {
                gridViewDetail.PostEditor();
                var exchange = (decimal)gridViewDetail.GetRowCellValue(e.RowHandle, "ExchangeRate");
                var amountOc = (decimal)gridViewDetail.GetRowCellValue(e.RowHandle, "AmountOc");
                var amountEx = (decimal)gridViewDetail.GetRowCellValue(e.RowHandle, "AmountExchange");
                var currencyCode = (string)gridViewDetail.GetRowCellValue(e.RowHandle, "CurrencyCode");

                if (e.Column.FieldName.Equals("CurrencyCode"))
                {
                    if (currencyCode == "USD")
                    {
                        exchange = 1;
                        if (amountEx * exchange != amountOc)
                        {
                            var rowHandle = gridViewDetail.FocusedRowHandle;
                            gridViewDetail.SetRowCellValue(rowHandle, "ExchangeRate", 1);
                            gridViewDetail.SetRowCellValue(rowHandle, "Amount", amountOc);
                            gridViewDetail.SetRowCellValue(rowHandle, "AmountExchange", amountOc);
                        }
                    }
                }

                if (e.Column.FieldName.Equals("AmountOc"))
                {
                    if (exchange > 0)
                    {
                        if (amountEx * exchange != amountOc)
                        {
                            amountEx = Math.Round(amountOc / exchange, int.Parse(DBOptionHelper.CurrencyDecimalDigits));
                            var rowHandle = gridViewDetail.FocusedRowHandle;
                            gridViewDetail.SetRowCellValue(rowHandle, "AmountExchange", amountEx);
                        }
                    }
                }
                if (e.Column.FieldName.Equals("AmountExchange"))
                {
                    if (exchange > 0)
                    {
                        if (amountOc / exchange != amountEx)
                        {
                            var rowHandle = gridViewDetail.FocusedRowHandle;
                            gridViewDetail.SetRowCellValue(rowHandle, "AmountOc", amountEx * exchange);
                        }
                    }
                }

                if (e.Column.FieldName.Equals("ExchangeRate"))
                {

                    if (exchange > 0)
                    {
                        if (amountOc / exchange != amountEx)
                        {
                            var rowHandle = gridViewDetail.FocusedRowHandle;
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
                        var rowHandle = gridViewDetail.FocusedRowHandle;
                        gridViewDetail.SetRowCellValue(rowHandle, "ExchangeRate", 1);
                    }
                }

                if (e.Column.FieldName == "AutoBusiness")
                {
                    var rowHandle = gridViewDetail.FocusedRowHandle;

                    var autoBusinessId = (int?)gridViewDetail.GetRowCellValue(rowHandle, "AutoBusiness");
                    if (autoBusinessId != 0)
                    {
                        var autoBusiness = (AutoBusinessModel)_rpsAutoBusiness.GetRowByKeyValue(autoBusinessId);
                        gridViewDetail.SetRowCellValue(rowHandle, "AccountNumber", autoBusiness.DebitAccountNumber);
                        gridViewDetail.SetRowCellValue(rowHandle, "CorrespondingAccountNumber", autoBusiness.CreditAccountNumber);
                        gridViewDetail.SetRowCellValue(rowHandle, "VoucherTypeId", autoBusiness.VoucherTypeId);
                        gridViewDetail.SetRowCellValue(rowHandle, "Description", autoBusiness.Description);
                    }

                }
            }


        }

        protected override void cboCurrency_EditValueChanged(object sender, EventArgs e)
        {
            if (ActionMode == ActionModeVoucherEnum.AddNew)
            {
                string str = dtPostDate.DateTime.ToShortDateString();
                if (!str.Contains("31/12"))
                {
                    XtraMessageBox.Show("Bạn Phải chọn hạch toán là ngày: 31/12", "Thông báo", MessageBoxButtons.OK);
                    dtPostDate.Focus();
                    return;
                }
                // Load lại lưới
                _accountTranferVouchersPresenter.Display(PostedDate, CurrencyCode);
                BindGridDetail();
                GeneratedBaseRefNo();
            }

        }

        #endregion

        #region Property

        public bool IsAccountTranfer
        {
            get;
            set;
        }
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
                //var now = DateTime.Now;
                //var newDate = new DateTime(refDate.Year, refDate.Month, refDate.Day, now.Hour, now.Minute, now.Second);
                var newDate = new DateTime(refDate.Year, refDate.Month, refDate.Day);
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
                //var now = DateTime.Now;
                //var newDate = new DateTime(refDate.Year, refDate.Month, refDate.Day, now.Hour, now.Minute, now.Second);
                var newDate = new DateTime(refDate.Year, refDate.Month, refDate.Day);
                return newDate;
            }
            set
            {
                dtPostDate.EditValue = value;
            }
        }
        public string JournalMemo
        {
            get { return txtAccountTranferDescription.Text; }
            set { txtAccountTranferDescription.Text = value; }
        }
        public decimal TotalAmountOc { get; set; }
        public decimal TotalAmountExchange { get; set; }
        public int RefTypeId
        {
            get { return (int)BaseRefTypeId; }
            set { BaseRefTypeId = (RefType)value; }
        }
        public bool IsCapitalAllocate
        {
            get { return false; }
        }
        public string CurrencyCode
        {
            get
            {
                if (cboCurrency.EditValue == null) return null;
                return cboCurrency.EditValue.ToString();
            }
            set { cboCurrency.EditValue = value; }
        }
        public int? BankId
        {
            get; set;
        }
        public long? DepositId { get; set; }
        public long? CashId { get; set; }

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
                                VendorId = rowVoucherDetailData.VendorId == 0 ? null : rowVoucherDetailData.VendorId,
                                InventoryItemId = rowVoucherDetailData.InventoryItemId
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
                ColumnsCollection.Clear();
                bindingSourceDetail.DataSource = value;
                gridViewDetail.PopulateColumns(value);
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AutoBusiness", ColumnCaption = "ĐK tự động", ColumnPosition = 1, ColumnVisible = false, ColumnWith = 80, FixedColumn = FixedStyle.Left, AllowEdit = false, ToolTip = "Định khoản tự động" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefDetailId", ColumnVisible = false, FixedColumn = FixedStyle.Left, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountNumber", ColumnCaption = "TK nợ", FixedColumn = FixedStyle.Left, ColumnPosition = 2, ColumnVisible = true, ColumnWith = 60, ToolTip = "Tài khoản nợ" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CorrespondingAccountNumber", ColumnCaption = "TK có", FixedColumn = FixedStyle.Left, ColumnPosition = 3, ColumnVisible = true, ColumnWith = 60, ToolTip = "Tài khoản có" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnCaption = "Diễn giải", FixedColumn = FixedStyle.None, ColumnPosition = 4, ColumnVisible = true, ColumnWith = 300, ToolTip = "Diễn giải" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AmountOc", ColumnCaption = "Số tiền", ColumnPosition = 5, ColumnType = UnboundColumnType.Decimal, FixedColumn = FixedStyle.None, ColumnVisible = true, ColumnWith = 100, ToolTip = "Số tiền" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CurrencyCode", ColumnCaption = "Tiền tệ", ColumnPosition = 6, FixedColumn = FixedStyle.None, ColumnVisible = true, ColumnWith = 100, ToolTip = "Tiền tệ" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ExchangeRate", ColumnCaption = "Tỷ giá", ColumnPosition = 7, ColumnType = UnboundColumnType.Decimal, FixedColumn = FixedStyle.None, ColumnVisible = true, ColumnWith = 100, ToolTip = "tỷ giá" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AmountExchange", ColumnCaption = "Số tiền QĐ", ColumnPosition = 8, ColumnType = UnboundColumnType.Decimal, FixedColumn = FixedStyle.None, ColumnVisible = true, ColumnWith = 100, ToolTip = "Số tiền quy đổi" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceCode", ColumnCaption = "Nguồn vốn", ColumnPosition = 9, FixedColumn = FixedStyle.None, ColumnVisible = true, ColumnWith = 100, ToolTip = "Nguồn vốn" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemCode", ColumnCaption = "Mục/TM", ColumnPosition = 10, FixedColumn = FixedStyle.None, ColumnVisible = false, ColumnWith = 100, ToolTip = "Mục/Tiểu mục" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "VoucherTypeId", ColumnCaption = "Nghiệp vụ", ColumnPosition = 11, FixedColumn = FixedStyle.None, ColumnVisible = true, ColumnWith = 100, ToolTip = "Nghiệp vụ" });
                //ColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectId", ColumnCaption = "Dự án", FixedColumn = FixedStyle.None, ColumnPosition = 12, ColumnVisible = false, ColumnWith = 150, ToolTip = "Dự án" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DepartmentId", ColumnCaption = "Phòng ban", ColumnPosition = 13, FixedColumn = FixedStyle.None, ColumnVisible = false, ColumnWith = 100, ToolTip = "Phòng ban" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "VendorId", ColumnCaption = "Nhà cung cấp", ColumnPosition = 14, FixedColumn = FixedStyle.None, ColumnVisible = false, ColumnWith = 100, ToolTip = "Nhà cung cấp" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "EmployeeId", ColumnCaption = "Cán bộ", ColumnPosition = 15, FixedColumn = FixedStyle.None, ColumnVisible = false, ColumnWith = 100, ToolTip = "Cán bộ" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectId", ColumnCaption = "Đối tượng khác", ColumnPosition = 16, FixedColumn = FixedStyle.None, ColumnVisible = false, ColumnWith = 100, ToolTip = "Đối tượng khác" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CustomerId", ColumnCaption = "Khách hàng", ColumnPosition = 17, FixedColumn = FixedStyle.None, ColumnVisible = false, ColumnWith = 100, ToolTip = "Khách hàng " });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "CapitalAllocateCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BankId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "InventoryItemId", ColumnCaption = "Vật tư", FixedColumn = FixedStyle.None, ColumnPosition = 17, ColumnVisible = false, ColumnWith = 150, ToolTip = "Vật tư- công cụ dụng cụ" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DetailBy", ColumnCaption = "", FixedColumn = FixedStyle.None, ColumnPosition = 17, ColumnVisible = false, ColumnWith = 150, ToolTip = "Vật tư- công cụ dụng cụ" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefId", ColumnVisible = false });

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
                            case "VoucherTypeId":
                                gridViewDetail.Columns[column.ColumnName].ColumnEdit = _rpsVoucherTypeId;
                                break;
                            case "InventoryItemId":
                                gridViewDetail.Columns[column.ColumnName].ColumnEdit = _rpsInventoryItem;
                                break;
                        }
                    }
                    else gridViewDetail.Columns[column.ColumnName].Visible = false;
                    SetNumericFormatControl(gridViewDetail, true);
                }
            }
        }
        public IList<AccountTranferVourcherModel> GetAccountTranferVourchersUpdateOrInsert
        {
            set
            {
                grdAccountTranfer.DataSource = value;
                grdViewAccountTranfer.PopulateColumns(value);

                var columnCollection = new List<XtraColumn>
                {
                    new XtraColumn {ColumnName = "RefDetailId",ColumnCaption = "",ColumnPosition = 1,ColumnVisible = false,AllowEdit = false},
                    new XtraColumn {ColumnName = "RefId",ColumnCaption = "",ColumnPosition = 2,ColumnVisible = false,AllowEdit = false},
                    new XtraColumn {ColumnName = "AccountNumber",ColumnCaption = "TK nợ",ColumnPosition = 3,ColumnVisible = true,ColumnWith = 50,AllowEdit = false,ToolTip = "Tài khoản nợ"},
                    new XtraColumn {ColumnName = "CorrespondingAccountNumber",ColumnCaption = "TK có",ColumnPosition = 4,ColumnVisible = true,ColumnWith = 50,AllowEdit = false,ToolTip = "Tài khoản có"},
                    new XtraColumn {ColumnName = "Description",ColumnCaption = "Diễn tả",ColumnPosition = 4,ColumnVisible = true,ColumnWith = 200,AllowEdit = false,ToolTip = "Diễn giải"},
                    new XtraColumn {ColumnName = "AmountOc",ColumnCaption = "Số tiền",ColumnPosition = 5,ColumnVisible = true,ColumnWith = 100,AllowEdit = false, ColumnType = UnboundColumnType.Decimal,ToolTip = "Số tiền"},
                    new XtraColumn {ColumnName = "ExchangeRate",ColumnCaption = "Tỷ giá",ColumnPosition = 6,ColumnVisible = true,ColumnWith = 50,AllowEdit = false,ColumnType = UnboundColumnType.Decimal,ToolTip = "Tỷ giá"},
                    new XtraColumn {ColumnName = "AmountExchange",ColumnCaption = "Số tiền quy đổi",ColumnPosition = 7,ColumnVisible = true,ColumnWith = 100,AllowEdit = false, ColumnType = UnboundColumnType.Decimal,ToolTip = "Số tiền quy đổi"},
                    new XtraColumn {ColumnName = "CurrencyCode",ColumnCaption = "Loại tiền",ColumnPosition = 8,ColumnVisible = true,ColumnWith = 50,AllowEdit = false,ToolTip = "Loại tiền"},
                    new XtraColumn {ColumnName = "BudgetSourceCode",ColumnCaption = "Nguồn vốn",ColumnPosition = 9,ColumnVisible = true,ColumnWith = 50,AllowEdit = false,ToolTip = "Nguồn vốn"},
                    new XtraColumn {ColumnName = "PostedDate",ColumnCaption = "Ngày hạch toán",ColumnPosition = 10,ColumnVisible = false,ColumnWith = 70,AllowEdit = false,ToolTip = "Ngày hạch toán"},
                    new XtraColumn {ColumnName = "VoucherTypeId",ColumnCaption = "Nghiệp vụ",ColumnPosition = 11,ColumnVisible = true,ColumnWith = 50,AllowEdit = false,ToolTip = "Nghiệp vụ"}
                };

                foreach (var column in columnCollection)
                {
                    if (column.ColumnVisible)
                    {
                        grdViewAccountTranfer.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        grdViewAccountTranfer.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                        grdViewAccountTranfer.Columns[column.ColumnName].Width = column.ColumnWith;
                        grdViewAccountTranfer.Columns[column.ColumnName].Fixed = column.FixedColumn;
                        grdViewAccountTranfer.Columns[column.ColumnName].ToolTip = column.ToolTip;
                        grdViewAccountTranfer.Columns[column.ColumnName].UnboundType = column.ColumnType;
                        grdViewAccountTranfer.Columns[column.ColumnName].OptionsColumn.AllowEdit = column.AllowEdit;
                        grdViewAccountTranfer.ScrollStyle = ScrollStyleFlags.LiveVertScroll;
                        grdViewAccountTranfer.OptionsSelection.EnableAppearanceFocusedCell = true;

                        switch (column.ColumnName)
                        {
                            case "AccountNumber":
                                grdViewAccountTranfer.Columns[column.ColumnName].ColumnEdit = _rpsAccountNumber;
                                break;
                            case "CorrespondingAccountNumber":
                                grdViewAccountTranfer.Columns[column.ColumnName].ColumnEdit = _rpsCorrespondingAccountNumber;
                                break;
                            case "BudgetSourceCode":
                                grdViewAccountTranfer.Columns[column.ColumnName].ColumnEdit = _rpsBudgetSource;
                                break;
                            case "BudgetItemCode":
                                grdViewAccountTranfer.Columns[column.ColumnName].ColumnEdit = _rpsBudgetItem;
                                break;
                            case "AccountingObjectId":
                                grdViewAccountTranfer.Columns[column.ColumnName].ColumnEdit = _rpsAccountingObject;
                                break;
                            case "VendorId":
                                grdViewAccountTranfer.Columns[column.ColumnName].ColumnEdit = _rpsVendor;
                                break;
                            case "EmployeeId":
                                grdViewAccountTranfer.Columns[column.ColumnName].ColumnEdit = _rpsEmployees;
                                break;
                            case "CustomerId":
                                grdViewAccountTranfer.Columns[column.ColumnName].ColumnEdit = _rpsCustomer;
                                break;
                            case "DepartmentId":
                                grdViewAccountTranfer.Columns[column.ColumnName].ColumnEdit = _rpsDepartment;
                                break;
                            //case "ProjectId":
                            //    grdViewAccountTranfer.Columns[column.ColumnName].ColumnEdit = _rpsProject;
                            //    break;
                            case "AutoBusiness":
                                grdViewAccountTranfer.Columns[column.ColumnName].ColumnEdit = _rpsAutoBusiness;
                                break;
                            case "CurrencyCode":
                                grdViewAccountTranfer.Columns[column.ColumnName].ColumnEdit = _rpsCurrency;
                                break;
                            case "ExchangeRate":
                                grdViewAccountTranfer.Columns[column.ColumnName].ColumnEdit = _rpsSpinEdit;
                                break;
                            case "VoucherTypeId":
                                grdViewAccountTranfer.Columns[column.ColumnName].ColumnEdit = _rpsVoucherTypeId;
                                break;
                            case "InventoryItemId":
                                grdViewAccountTranfer.Columns[column.ColumnName].ColumnEdit = _rpsInventoryItem;
                                break;
                        }

                    }
                    else grdViewAccountTranfer.Columns[column.ColumnName].Visible = false;
                }

                SetNumericFormatControl(grdViewAccountTranfer, true);

            }
        }
        public IList<GeneralParalellDetailModel> GeneralParalellDetails { get; set; }

        #endregion

        #region Functions

        public void BindGridDetail()
        {
            if (ActionMode == ActionModeVoucherEnum.AddNew || ActionMode == ActionModeVoucherEnum.Edit)
            {
                if (IsAccountTranfer == false && ActionMode == ActionModeVoucherEnum.Edit) return;

                if (grdViewAccountTranfer.RowCount > 0)
                {
                    List<GeneralDetailModel> lst = new List<GeneralDetailModel>();

                    for (int i = 0; i < grdViewAccountTranfer.RowCount; i++)
                    {
                        AccountTranferVourcherModel it = (AccountTranferVourcherModel)grdViewAccountTranfer.GetRow(i);
                        if (it != null)
                        {
                            var itGeneralDetail = new GeneralDetailModel
                            {
                                AccountNumber = it.AccountNumber,
                                AccountingObjectId = null,
                                AmountOc = it.AmountOc,
                                AmountExchange = it.AmountExchange,
                                BudgetItemCode = "",
                                BudgetSourceCode = it.BudgetSourceCode,
                                CorrespondingAccountNumber = it.CorrespondingAccountNumber,
                                CurrencyCode = cboCurrency.EditValue.ToString(),
                                CustomerId = null,
                                DepartmentId = null,
                                Description = it.Description,
                                EmployeeId = null,
                                ExchangeRate = it.ExchangeRate,
                                ProjectId = null,
                                VendorId = null,
                                VoucherTypeId = it.VoucherTypeId,
                                RefDetailId = (int)it.RefDetailId,
                                CapitalAllocateCode = ""
                            };
                            lst.Add(itGeneralDetail);
                        }

                    }
                    bindingSourceDetail.DataSource = lst;
                }
            }
        }

        #endregion
    }
}
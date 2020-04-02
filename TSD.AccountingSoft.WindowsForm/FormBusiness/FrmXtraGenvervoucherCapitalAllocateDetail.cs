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
using System.Data;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using TSD.AccountingSoft.Session;

using TSD.AccountingSoft.Model.BusinessObjects.General;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.View.General;
using TSD.AccountingSoft.WindowsForm.Resources;
using TSD.Enum;
using DateTimeRangeBlockDev.Helper;
using DevExpress.Utils;
using DevExpress.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using TSD.AccountingSoft.Presenter.General;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System.Threading;
using DevExpress.XtraEditors.Mask;

// tesstsatstastasdrfs
namespace TSD.AccountingSoft.WindowsForm.FormBusiness
{
    /// <summary>
    /// class FrmXtraGenvervoucherCapitalAllocateDetail 
    /// </summary>
    public partial class FrmXtraGenvervoucherCapitalAllocateDetail : FrmXtraBaseVoucherDetail, IGeneralVoucherView, ICaptitalAllocateVouchersView
    {
        #region Paramester

        private readonly GenveralVoucherPresenter _generalVoucherPresenter;
        private CapitalAllocateVouchersPresenter _capitalAllocateVouchersPresenter;
        private RepositoryItemCalcEdit _rpsSpinEdit;
        private GlobalVariable _globalVariable;

        #endregion

        #region "Function overrite"

        protected override void InitData()
        {
            base.InitData();

            if (MasterBindingSource.Current != null)
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

            if (long.Parse(KeyValue) != 0)
            {
                _generalVoucherPresenter.Display(long.Parse(KeyValue));
            }
            else
            {
                GeneralDetails = new List<GeneralDetailModel>();
                cboCurrency.EditValue = "USD";
                cboExchangRate.EditValue = 1;
            }
        }

        protected override long SaveData()
        {

            if (ActionMode == ActionModeVoucherEnum.Edit)
                RefId = (_keyForSend == null || long.Parse(_keyForSend) == 0) ? RefId : long.Parse(_keyForSend);
            if (ActionMode == ActionModeVoucherEnum.AddNew || ActionMode == ActionModeVoucherEnum.DuplicateVoucher)
                RefId = 0;

            #region Lưu chứng chi tiết chứng từ phân bổ

            //Lấy lại danh sách trên lưới chứng từ===============================================================
            IList<GeneralDetailModel> lstTempGeneralVoucherDetail = new List<GeneralDetailModel>();
            for (int i = 0; i < gridViewDetail.RowCount; i++)
            {
                var itemVoucherDetailData = (GeneralDetailModel)gridViewDetail.GetRow(i);
                lstTempGeneralVoucherDetail.Add(itemVoucherDetailData);
            }
            //===================================================================================================

            IList<GeneralDetailModel> lstGeneralVoucherDetail = new List<GeneralDetailModel>();
            IList<CaptitalAllocateVoucherModel> lstTemp = new List<CaptitalAllocateVoucherModel>();
            if (grdViewCapitalAllocate.RowCount > 0)
            {
                for (int i = 0; i < grdViewCapitalAllocate.RowCount; i++)
                {
                    var rowVoucherDetailData = (CaptitalAllocateVoucherModel)grdViewCapitalAllocate.GetRow(i);
                    var rowVoucherGeneralDetail = lstTempGeneralVoucherDetail.Where(x => x.CapitalAllocateCode == rowVoucherDetailData.CapitalAllocateCode).First();
                    var itGeneralDetail = new GeneralDetailModel
                    {
                        AccountNumber = rowVoucherGeneralDetail.AccountNumber,
                        AmountExchange = rowVoucherDetailData.Amount * rowVoucherGeneralDetail.ExchangeRate,
                        AccountingObjectId = rowVoucherGeneralDetail.AccountingObjectId == 0 ? null : rowVoucherGeneralDetail.AccountingObjectId,
                        AmountOc = rowVoucherDetailData.Amount,
                        BudgetItemCode = rowVoucherGeneralDetail.BudgetItemCode,
                        BudgetSourceCode = rowVoucherGeneralDetail.BudgetSourceCode,
                        CorrespondingAccountNumber = rowVoucherGeneralDetail.CorrespondingAccountNumber,
                        CurrencyCode = lookUpCurrencyCode.EditValue.ToString(),
                        CustomerId = rowVoucherGeneralDetail.CustomerId == 0 ? null : rowVoucherGeneralDetail.CustomerId,
                        DepartmentId = rowVoucherGeneralDetail.DepartmentId == 0 ? null : rowVoucherGeneralDetail.DepartmentId,
                        Description = rowVoucherGeneralDetail.Description,
                        EmployeeId = rowVoucherGeneralDetail.EmployeeId == 0 ? null : rowVoucherGeneralDetail.EmployeeId,
                        ExchangeRate = rowVoucherGeneralDetail.ExchangeRate,
                        //ProjectId = rowVoucherGeneralDetail.ProjectId == 0 ? null : rowVoucherGeneralDetail.ProjectId,
                        VendorId = rowVoucherGeneralDetail.VendorId == 0 ? null : rowVoucherGeneralDetail.VendorId,
                        VoucherTypeId = rowVoucherGeneralDetail.VoucherTypeId == 0 ? null : rowVoucherGeneralDetail.VoucherTypeId,
                        RefDetailId = rowVoucherGeneralDetail.RefDetailId,
                        CapitalAllocateCode = rowVoucherGeneralDetail.CapitalAllocateCode
                    };
                    lstGeneralVoucherDetail.Add(itGeneralDetail);
                    lstTemp.Add(rowVoucherDetailData);
                }
            }

            foreach (var itCaptitalAllocate in lstTemp)
            {
                var obj =
                    lstTempGeneralVoucherDetail.Where(
                        x => x.CapitalAllocateCode == (itCaptitalAllocate.CapitalAllocateCode + "0$0$0")).FirstOrDefault();
                if (obj != null)
                {
                    lstGeneralVoucherDetail.Add(obj);
                }
            }

            GeneralDetails = lstGeneralVoucherDetail.ToList();

            #endregion

            long lnRefId = _generalVoucherPresenter.Save(); // Cập nhật chứng từ chung

            #region "lấy danh mục phân bổ quỹ"
            for (int i = 0; i < lstTemp.Count; i++)
            {
                lstTemp[i].RefId = lnRefId;
            }
            _capitalAllocateVouchersPresenter.Save(lstTemp, long.Parse(KeyValue));

            #endregion

            if (lnRefId > 0)
            {
                SetEnableGird(false);
                ActionMode = ActionModeVoucherEnum.None;
                KeyValue = lnRefId.ToString(CultureInfo.InvariantCulture);
            }

            else
            {
                SetEnableGird(true);

            }
            return lnRefId;
        }

        protected override void DeleteVoucher()
        {
            if (RefId == 0) return;
            var refId = RefId > 0 ? RefId : long.Parse(_keyForSend);
            new GenveralVoucherPresenter(null).Delete(refId);
            IsNone = true;
            cboDropDown_SelectedIndexChanged();
            ActionMode = ActionModeVoucherEnum.None;
            base.RefreshToolbar();
        }

        protected override void InitControls()
        {
            _rpsSpinEdit = new RepositoryItemCalcEdit { AllowMouseWheel = false };
            _rpsSpinEdit.Mask.MaskType = MaskType.Numeric;
            _rpsSpinEdit.Mask.EditMask = @"c" + _globalVariable.ExchangeRateDecimalDigits;
            _rpsSpinEdit.Mask.Culture = Thread.CurrentThread.CurrentCulture;
            _rpsSpinEdit.Mask.UseMaskAsDisplayFormat = true;

            #region _rpsInventoryItemView

            _rpsInventoryItemView = new GridView();
            _rpsInventoryItem = new RepositoryItemGridLookUpEdit
            {
                NullText = "",
                View = _rpsInventoryItemView,
                TextEditStyle = TextEditStyles.Standard,
                PopupResizeMode = ResizeMode.FrameResize,
                PopupFormSize = new Size(500, 200),
                ShowFooter = false
            };
            _rpsInventoryItem.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
            _rpsInventoryItem.View.OptionsView.ShowIndicator = false;

            #endregion
        }

        protected override void EditVoucher()
        {
            DialogResult yesno = MessageBox.Show(@"Bạn có chắc chắn cập nhật lại chứng từ không?", @"Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (yesno == DialogResult.No)
            {
                CancelVoucher();
                return;
            }


            txtGeneralDescription.Properties.ReadOnly = false;
            ActionMode = ActionModeVoucherEnum.Edit;
            cboDropDown_SelectedIndexChanged();
            //  base.EditVoucher();
            cboCurrency_EditValueChanged(null, null);
        }

        public override void Refresh()
        {
            cboDropDown_SelectedIndexChanged();
        }

        protected override void MoveFirstVoucher()
        {
            base.MoveFirstVoucher();
            cboDropDown_SelectedIndexChanged();
        }

        protected override void MoveNextVoucher()
        {
            base.MoveNextVoucher();
            cboDropDown_SelectedIndexChanged();
        }

        protected override void MoveLastVoucher()
        {

            base.MoveLastVoucher();
            cboDropDown_SelectedIndexChanged();
        }

        protected override void MovePreviousVoucher()
        {
            base.MovePreviousVoucher();
            cboDropDown_SelectedIndexChanged();
        }

        /// <summary>
        /// Set kỳ kế toán là tháng của ngày hạch toán
        /// </summary>
        protected override void AddNewVoucher()
        {
            ActionMode = ActionModeVoucherEnum.AddNew;
            dateTimeRangeV.cboDateRange.Text = vi_Vn.ResMonthText + Convert.ToDateTime(new GlobalVariable().PostedDate).Month;
            //dateTimeRangeV.SetComboIndex(GlobalVariable.DateRangeSelectedIndex);
            cboDropDown_SelectedIndexChanged();
            base.AddNewVoucher();
        }

        protected override void CancelVoucher()
        {
            txtGeneralDescription.Properties.ReadOnly = true;
            ActionMode = ActionModeVoucherEnum.None;
            cboDropDown_SelectedIndexChanged();
            base.CancelVoucher();
        }

        protected override bool ValidData()
        {
            if (dateTimeRangeV.ToDate.ToShortDateString() == "01/01/0001" ||
                dateTimeRangeV.FromDate.ToShortDateString() == "01/01/0001")
            {
                XtraMessageBox.Show("Bạn chưa chọn kỳ cần phân bổ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateTimeRangeV.Focus();
                return false;

            }

            if (lookUpCurrencyCode.EditValue.ToString() == "")
            {
                XtraMessageBox.Show("Vui lòng chọn loại tiền tệ cần phân bổ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lookUpCurrencyCode.Focus();
                return false;
            }

            if (grdViewCapitalAllocate.RowCount <= 0)
            {
                XtraMessageBox.Show("Kỳ phân bổ đã tồn tại hoặc không có thu/chi phát sinh trong kỳ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (ActionMode != ActionModeVoucherEnum.Edit)
            {
                if (dtPostDate.DateTime > dateTimeRangeV.ToDate || dtPostDate.DateTime < dateTimeRangeV.FromDate)
                {
                    XtraMessageBox.Show("Bạn phải nhập ngày phân bổ nằm trong ngày kỳ phân bổ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            //Xử lý khá phức tạp tại đây

            #region "Lấy danh sách các mục phân bổ quỹ"

            IList<CaptitalAllocateVoucherModel> lstCapitalAllocate = new List<CaptitalAllocateVoucherModel>();
            if (grdViewCapitalAllocate.RowCount > 0)
            {
                for (int i = 0; i < grdViewCapitalAllocate.RowCount; i++)
                {
                    var rowVoucherDetailData = (CaptitalAllocateVoucherModel)grdViewCapitalAllocate.GetRow(i);
                    var it = new CaptitalAllocateVoucherModel
                    {
                        RefDetailId = rowVoucherDetailData.RefDetailId,
                        ActivityId = rowVoucherDetailData.ActivityId,
                        AllocatePercent = rowVoucherDetailData.AllocatePercent,
                        AllocateType = rowVoucherDetailData.AllocateType,
                        Amount = rowVoucherDetailData.Amount,
                        BudgetItemCode = rowVoucherDetailData.BudgetItemCode,
                        BudgetSourceCode = rowVoucherDetailData.BudgetSourceCode,
                        CapitalAccountCode = rowVoucherDetailData.CapitalAccountCode,
                        CurrencyCode = lookUpCurrencyCode.EditValue.ToString(),
                        Description = rowVoucherDetailData.Description,
                        DeterminedDate = rowVoucherDetailData.DeterminedDate,
                        ExpenseAccountCode = rowVoucherDetailData.ExpenseAccountCode,
                        ExpenseAmount = rowVoucherDetailData.ExpenseAmount,
                        IsActive = rowVoucherDetailData.IsActive,
                        RefId = 0,
                        RevenueAccountCode = rowVoucherDetailData.RevenueAccountCode,
                        TotalAmount = rowVoucherDetailData.TotalAmount,
                        WaitBudgetSourceCode = rowVoucherDetailData.WaitBudgetSourceCode == null ? "" : rowVoucherDetailData.WaitBudgetSourceCode,
                        FromDate = dateTimeRangeV.FromDate,
                        ToDate = dateTimeRangeV.ToDate,
                        CapitalAllocateCode = rowVoucherDetailData.CapitalAllocateCode
                    };

                    lstCapitalAllocate.Add(it);
                }
            }

            #endregion

            var lstCaptitalAllocateVoucherForCheck = lstCapitalAllocate;

            //Kiểm tra tổng số phần % các khoản phân bổ đã hợp lí chưa?
            foreach (var it in lstCaptitalAllocateVoucherForCheck)
            {
                if (it.AllocateType != 1 && it.AllocateType != 2 && it.AllocateType != 3) continue;
                var totalSum = lstCapitalAllocate.Where(x => x.BudgetItemCode == it.BudgetItemCode).Sum(x => x.Amount);

                if (lstCapitalAllocate.Any(x => x.BudgetItemCode == it.BudgetItemCode && x.AllocateType == 2))
                {
                    if (totalSum == it.TotalAmount - it.ExpenseAmount) continue;
                    XtraMessageBox.Show("Bạn nhập số tiền của khoản " + it.BudgetItemCode + @" không bằng tổng số tiền cần phân bổ: " + it.TotalAmount, "Thông báo", MessageBoxButtons.OK);
                    return false;
                }
                if (totalSum == it.TotalAmount - it.ExpenseAmount) continue;
                XtraMessageBox.Show("Bạn nhập số tiền của khoản " + it.BudgetItemCode + @" không bằng tổng số tiền cần phân bổ: " + it.TotalAmount, "Thông báo", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }

        protected override void AdjustControlSize(bool isGridParallel, bool isGrdMaster)
        {
            grdMaster.Visible = isGrdMaster;
            gridAccountingParallel.Visible = isGridParallel;

            if (!isGrdMaster && !isGridParallel)
            {
                grdDetail.Location = new Point(grdCapitalAllocate.Location.X, grdCapitalAllocate.Location.Y + grdCapitalAllocate.Height + 7);
                grdDetail.Height = this.Height - (grdCapitalAllocate.Location.Y + grdCapitalAllocate.Height + 7) - 70;
                grdDetail.Width = grdCapitalAllocate.Width;
                grdDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Bottom));
            }
        }

        #endregion

        #region event

        public FrmXtraGenvervoucherCapitalAllocateDetail()
        {
            InitializeComponent();
            _globalVariable = new GlobalVariable();

            _generalVoucherPresenter = new GenveralVoucherPresenter(this);
            _capitalAllocateVouchersPresenter = new CapitalAllocateVouchersPresenter(this);
            grdMaster.Visible = false;
            groupObject.Visible = false;
            groupVoucher.Visible = true;
            gridViewDetail.OptionsBehavior.AllowAddRows = DefaultBoolean.False;

            dateTimeRangeV.DateRangePeriodMode = DateRangeMode.MonthAndQuarter;
            dateTimeRangeV.InitSelectedIndex = 0;
            dateTimeRangeV.InitData(DateTime.Parse(new GlobalVariable().PostedDate));

            grdViewCapitalAllocate.OptionsView.ColumnAutoWidth = false;
        }

        private void FrmXtraGenvervoucherCapitalAllocateDetail_Load(object sender, EventArgs e)
        {


            dateTimeRangeV.DateTimeRangeSelectedIndexEvent += cboDropDown_SelectedIndexChanged;

            #region load Tiền tệ

            var table = new DataTable();
            table.Columns.Add("CurrencyCode", typeof(string));
            table.Rows.Add(CurrencyAccounting);
            if (CurrencyAccounting != CurrencyLocal)
            {
                table.Rows.Add(CurrencyLocal);
            }
            lookUpCurrencyCode.Properties.DataSource = table;
            lookUpCurrencyCode.Properties.ValueMember = "CurrencyCode";
            lookUpCurrencyCode.Properties.DisplayMember = "CurrencyCode";
            lookUpCurrencyCode.Properties.ShowHeader = false;
            lookUpCurrencyCode.Properties.ShowFooter = false;
            #endregion

            cboDropDown_SelectedIndexChanged();
            grdViewCapitalAllocate.HorzScrollVisibility = ScrollVisibility.Always;
            IsInVisiblePopupMenuGrid = true;

            AdjustControlSize(false, false);
        }

        private void lookUpCurrencyCode_EditValueChanged(object sender, EventArgs e)
        {
            GeneratedBaseRefNo();
            if (dateTimeRangeV.ToDate.ToShortDateString() == "01/01/0001" || dateTimeRangeV.FromDate.ToShortDateString() == "01/01/0001")
                return;
            cboDropDown_SelectedIndexChanged();
        }

        private void cboDropDown_SelectedIndexChanged()
        {
            if (dateTimeRangeV.ToDate.ToShortDateString() == "01/01/0001")
            {
                dateTimeRangeV.SetComboIndex(0);
            }
            GetCaptitalAllocateVouchersForUpdateOrInsert = new List<CaptitalAllocateVoucherModel>();
            txtGeneralDescription.Text = @"Phân bổ các quỹ cuối kỳ, ngày " + dateTimeRangeV.ToDate.ToShortDateString();

            if (ActionMode == ActionModeVoucherEnum.None || ActionMode == ActionModeVoucherEnum.Delete ||
                ActionMode == ActionModeVoucherEnum.DuplicateVoucher)
            {

                _capitalAllocateVouchersPresenter.Display(long.Parse(KeyValue));

                if (grdViewCapitalAllocate.RowCount > 0)
                {
                    var rowVoucherDetailData = (CaptitalAllocateVoucherModel)grdViewCapitalAllocate.GetRow(0);
                    CurrencyCode = rowVoucherDetailData.CurrencyCode;
                    //LinhMC comment -- 31/12/2014
                    //DateTimeRangeBlockDev.Helper.DateTimeHelper.SetDateRangeIndex(rowVoucherDetailData.FromDate,
                    //                                                              rowVoucherDetailData.ToDate,
                    //                                                              DateTime.Parse(
                    //                                                                  GlobalVariable.SystemDate),
                    //                                                              ref dateTimeRangeV.cboDateRange);

                    DateTimeRangeBlockDev.Helper.DateTimeHelper.SetMonthAndQuarterDateRangeIndex(rowVoucherDetailData.FromDate, rowVoucherDetailData.ToDate, DateTime.Parse(GlobalVariable.SystemDate), ref dateTimeRangeV.cboDateRange);

                    FromDate = rowVoucherDetailData.FromDate;
                    ToDate = rowVoucherDetailData.ToDate;
                }

                if (ActionMode != ActionModeVoucherEnum.DuplicateVoucher)
                {
                    txtGeneralDescription.Properties.ReadOnly = true;
                }
                txtGeneralDescription.Text = @"Phân bổ các quỹ cuối kỳ, ngày " + dateTimeRangeV.ToDate.ToShortDateString();
            }
            else
            {
                //sửa
                if (ActionMode == ActionModeVoucherEnum.Edit)
                {
                    _capitalAllocateVouchersPresenter.Display(long.Parse(KeyValue));
                    if (grdViewCapitalAllocate.RowCount > 0)
                    {
                        var rowVoucherDetailData = (CaptitalAllocateVoucherModel)grdViewCapitalAllocate.GetRow(0);
                        CurrencyCode = rowVoucherDetailData.CurrencyCode;
                        FromDate = rowVoucherDetailData.FromDate;
                        ToDate = rowVoucherDetailData.ToDate;
                        //LinhMC comment -- 31/12/2014
                        //DateTimeRangeBlockDev.Helper.DateTimeHelper.SetDateRangeIndex(rowVoucherDetailData.FromDate,
                        //                                                              rowVoucherDetailData.ToDate,
                        //                                                              DateTime.Parse(
                        //                                                                  GlobalVariable.SystemDate),
                        //                                                              ref dateTimeRangeV.cboDateRange);
                        DateTimeRangeBlockDev.Helper.DateTimeHelper.SetMonthAndQuarterDateRangeIndex(rowVoucherDetailData.FromDate, rowVoucherDetailData.ToDate, DateTime.Parse(GlobalVariable.SystemDate), ref dateTimeRangeV.cboDateRange);
                    }
                    _capitalAllocateVouchersPresenter.Display(FromDate, ToDate, lookUpCurrencyCode.EditValue.ToString(), ActivityId, RefTypeId, long.Parse(KeyValue));
                    txtGeneralDescription.Text = @"Phân bổ các quỹ cuối kỳ, ngày " + dateTimeRangeV.ToDate.ToShortDateString();

                    #region Load xuống lại lưới
                    var lstGenvervoucherCapitalAllocate = new List<GeneralDetailModel>();
                    var lstCaptitalAllocateVoucher = new List<CaptitalAllocateVoucherModel>();
                    if (grdViewCapitalAllocate.RowCount > 0)
                    {

                        for (int i = 0; i < grdViewCapitalAllocate.RowCount; i++)
                        {
                            var rowVoucherDetailData = (CaptitalAllocateVoucherModel)grdViewCapitalAllocate.GetRow(i);

                            var objGeneralVoucherDetailModel = new GeneralDetailModel
                            {
                                AccountNumber = rowVoucherDetailData.RevenueAccountCode,
                                CorrespondingAccountNumber = rowVoucherDetailData.CapitalAccountCode,
                                Description = txtGeneralDescription.Text,
                                AmountOc = rowVoucherDetailData.Amount,
                                AmountExchange = Math.Round(rowVoucherDetailData.Amount / rowVoucherDetailData.ExchangeRate, int.Parse(_globalVariable.CurrencyDecimalDigits)),
                                VoucherTypeId = null,
                                BudgetSourceCode = rowVoucherDetailData.BudgetSourceCode,
                                BudgetItemCode = rowVoucherDetailData.BudgetItemCode,
                                AccountingObjectId = null,
                                ProjectId = null,
                                CurrencyCode = lookUpCurrencyCode.EditValue.ToString(),
                                CustomerId = null,
                                DepartmentId = null,
                                EmployeeId = null,
                                ExchangeRate = rowVoucherDetailData.ExchangeRate,
                                RefId = rowVoucherDetailData.RefId,
                                VendorId = null,
                                CapitalAllocateCode = rowVoucherDetailData.CapitalAllocateCode,

                            };
                            lstGenvervoucherCapitalAllocate.Add(objGeneralVoucherDetailModel);
                            lstCaptitalAllocateVoucher.Add(rowVoucherDetailData);
                        }
                    }

                    // bổ sung thêm định khoản chi phí lãnh sự
                    var lstTemp = lstCaptitalAllocateVoucher.Where(x => x.AllocateType == 1 || x.AllocateType == 2).GroupBy(x => x.BudgetItemCode).Select(y => y.First()).ToList();
                    //var lstTemp = lstCaptitalAllocateVoucher.Where(x => x.AllocateType == 1).GroupBy(x => x.BudgetItemCode).Select(y => y.First()).ToList();
                    foreach (var itCaptitalAllocate in lstTemp)
                    {
                        // co phat sinh chi phi lanh su hay khong?
                        if (itCaptitalAllocate.ExpenseAmount > 0)
                        {
                            var objGeneralVoucherDetailModel = new GeneralDetailModel
                            {
                                AccountNumber = itCaptitalAllocate.RevenueAccountCode,
                                CorrespondingAccountNumber = itCaptitalAllocate.ExpenseAccountCode,
                                Description = txtGeneralDescription.Text,
                                AmountOc = itCaptitalAllocate.ExpenseAmount,
                                AmountExchange = itCaptitalAllocate.ExpenseAmount,
                                VoucherTypeId = null,
                                BudgetSourceCode = itCaptitalAllocate.BudgetSourceCode,
                                BudgetItemCode = itCaptitalAllocate.BudgetItemCode,
                                AccountingObjectId = null,
                                ProjectId = null,
                                CurrencyCode = lookUpCurrencyCode.EditValue.ToString(),
                                CustomerId = null,
                                DepartmentId = null,
                                EmployeeId = null,
                                ExchangeRate = itCaptitalAllocate.ExchangeRate,
                                RefId = itCaptitalAllocate.RefId,
                                VendorId = null,
                                CapitalAllocateCode = itCaptitalAllocate.CapitalAllocateCode + "0$0$0"
                            };
                            lstGenvervoucherCapitalAllocate.Add(objGeneralVoucherDetailModel);
                        }
                    }

                    GeneralDetails = lstGenvervoucherCapitalAllocate.OrderBy(x => x.BudgetItemCode).ToList();

                    #endregion
                }
                else //Add new
                {
                    if (lookUpCurrencyCode.EditValue.ToString() == "") return;
                    txtGeneralDescription.Text = @"Phân bổ các quỹ cuối kỳ, ngày " +
                                                 dateTimeRangeV.ToDate.ToShortDateString();
                    _capitalAllocateVouchersPresenter.Display(dateTimeRangeV.FromDate, dateTimeRangeV.ToDate, ActivityId,
                                                              lookUpCurrencyCode.EditValue.ToString());
                    dtPostDate.DateTime = dateTimeRangeV.ToDate;
                    dtRefDate.DateTime = dateTimeRangeV.ToDate;

                    #region Load xuống lại lưới
                    var lstGenvervoucherCapitalAllocate = new List<GeneralDetailModel>();
                    var lstCaptitalAllocateVoucher = new List<CaptitalAllocateVoucherModel>();
                    if (grdViewCapitalAllocate.RowCount > 0)
                    {

                        for (int i = 0; i < grdViewCapitalAllocate.RowCount; i++)
                        {
                            var rowVoucherDetailData = (CaptitalAllocateVoucherModel)grdViewCapitalAllocate.GetRow(i);
                            var objGeneralVoucherDetailModel = new GeneralDetailModel
                            {
                                AccountNumber = rowVoucherDetailData.RevenueAccountCode,
                                CorrespondingAccountNumber = rowVoucherDetailData.CapitalAccountCode,
                                Description = txtGeneralDescription.Text,
                                AmountOc = rowVoucherDetailData.Amount,
                                AmountExchange = rowVoucherDetailData.Amount / rowVoucherDetailData.ExchangeRate,
                                VoucherTypeId = null,
                                BudgetSourceCode = rowVoucherDetailData.BudgetSourceCode,
                                BudgetItemCode = rowVoucherDetailData.BudgetItemCode,
                                AccountingObjectId = null,
                                ProjectId = null,
                                CurrencyCode = lookUpCurrencyCode.EditValue.ToString(),
                                CustomerId = null,
                                DepartmentId = null,
                                EmployeeId = null,
                                ExchangeRate = rowVoucherDetailData.ExchangeRate,
                                RefId = rowVoucherDetailData.RefId,
                                VendorId = null,
                                CapitalAllocateCode = rowVoucherDetailData.CapitalAllocateCode
                            };
                            lstGenvervoucherCapitalAllocate.Add(objGeneralVoucherDetailModel);
                            lstCaptitalAllocateVoucher.Add(rowVoucherDetailData);
                        }
                    }

                    // bổ sung thêm định khoản chi phí lãnh sự
                    var lstTemp = lstCaptitalAllocateVoucher.Where(x => x.AllocateType == 1 || x.AllocateType == 2).GroupBy(x => x.BudgetItemCode).Select(y => y.First()).ToList();
                    foreach (var itCaptitalAllocate in lstTemp)
                    {
                        // Co phat sinh chi phi lanh su khong?
                        if (itCaptitalAllocate.ExpenseAmount > 0)
                        {
                            var objGeneralVoucherDetailModel = new GeneralDetailModel
                            {
                                AccountNumber = itCaptitalAllocate.RevenueAccountCode,
                                CorrespondingAccountNumber = itCaptitalAllocate.ExpenseAccountCode,
                                Description = txtGeneralDescription.Text,
                                AmountOc = itCaptitalAllocate.ExpenseAmount,
                                AmountExchange = itCaptitalAllocate.ExpenseAmount,
                                VoucherTypeId = null,
                                BudgetSourceCode = itCaptitalAllocate.BudgetSourceCode,
                                BudgetItemCode = itCaptitalAllocate.BudgetItemCode,
                                AccountingObjectId = null,
                                ProjectId = null,
                                CurrencyCode = lookUpCurrencyCode.EditValue.ToString(),
                                CustomerId = null,
                                DepartmentId = null,
                                EmployeeId = null,
                                ExchangeRate = itCaptitalAllocate.ExchangeRate,
                                RefId = itCaptitalAllocate.RefId,
                                VendorId = null,
                                CapitalAllocateCode = itCaptitalAllocate.CapitalAllocateCode + "0$0$0"
                            };
                            lstGenvervoucherCapitalAllocate.Add(objGeneralVoucherDetailModel);
                        }


                    }
                    GeneralDetails = lstGenvervoucherCapitalAllocate.OrderBy(x => x.BudgetItemCode).ToList();

                    #endregion
                }
            }
            if (ActionMode == ActionModeVoucherEnum.DuplicateVoucher || ActionMode == ActionModeVoucherEnum.AddNew || ActionMode == ActionModeVoucherEnum.Edit)
            {
                SetEnableGird(true);
                chkActivityId.Enabled = true;
            }
            else
            {
                SetEnableGird(false);
                chkActivityId.Enabled = false;
            }

        }

        protected override void cboCurrency_EditValueChanged(object sender, EventArgs e)
        {
            base.cboCurrency_EditValueChanged(sender, e);
            if (CurrencyCode.Trim().ToUpper() == "USD")
            {
                cboExchangRate.Enabled = false;
                cboExchangRate.EditValue = 1;
            }
            else
            {
                cboExchangRate.Enabled = true;
            }
        }

        #endregion

        #region Property

        public long RefId { get; set; }

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
            set { dtRefDate.EditValue = value; }
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
            set { dtPostDate.EditValue = value; }
        }

        public string Description
        {
            get { return txtGeneralDescription.Text; }
            set { txtGeneralDescription.Text = value; }
        }

        public int RefTypeId
        {
            get { return (int)BaseRefTypeId; }
            set { BaseRefTypeId = (RefType)value; }
        }

        public bool IsCapitalAllocate
        {
            get { return true; }
        }

        public string CurrencyCode
        {
            get { return lookUpCurrencyCode.EditValue.ToString(); }
            set { lookUpCurrencyCode.EditValue = value; }
        }

        public int ActivityId
        {
            get { return chkActivityId.Checked ? 1 : 0; }
            set { chkActivityId.Checked = (value == 0); }
        }

        public bool IsNone { get; set; }

        public DateTime FromDate
        {
            get { return dateTimeRangeV.FromDate; }
            set { dateTimeRangeV.FromDate = value; }
        }

        public DateTime ToDate
        {
            get { return dateTimeRangeV.ToDate; }
            set { dateTimeRangeV.ToDate = value; }
        }

        public string JournalMemo
        {
            get { return txtGeneralDescription.Text; }
            set { txtGeneralDescription.Text = value; }
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
                    decimal totalAmount = 0;
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
                            };
                            totalAmount = totalAmount + rowVoucherDetailData.AmountOc;
                            generalVoucherDetail.Add(item);
                        }
                    }
                    TotalAmountOc = totalAmount;
                    TotalAmountExchange = totalAmount;
                }
                return generalVoucherDetail.ToList();
            }
            set
            {
                ColumnsCollection.Clear();

                //grdDetail.DataSource = value.Count == 0 ? new List<GeneralVoucherDetailModel> { new GeneralVoucherDetailModel { AmountOc = 0, ExchangeRate = 1, CurrencyCode = "USD" } } : value.OrderBy(x => x.BudgetItemCode).ToList();

                if (value.Count > 0)
                {
                    bindingSourceDetail.DataSource = value;
                }
                else
                {
                    var refType = RefTypes.Where(w => w.RefTypeId == (int)RefType.FixedAssetIncrement)?.First() ?? null;
                    if (refType != null)
                        bindingSourceDetail.DataSource = new List<GeneralDetailModel> { new GeneralDetailModel() { AccountNumber = refType.DefaultDebitAccountId, CorrespondingAccountNumber = refType.DefaultCreditAccountId, AmountOc = 0, ExchangeRate = 1, CurrencyCode = "USD" } };
                    else
                        bindingSourceDetail.DataSource = new List<GeneralDetailModel> { new GeneralDetailModel() { AmountOc = 0, ExchangeRate = 1, CurrencyCode = "USD" } };
                }

                gridViewDetail.PopulateColumns(value);
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "AutoBusiness",
                    ColumnCaption = "ĐK tự động",
                    ColumnPosition = 1,
                    ColumnVisible = false,
                    ColumnWith = 100,
                    FixedColumn = FixedStyle.Left,
                    AllowEdit = true,
                    ToolTip = "Định khoản tự động"
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "RefDetailId",
                    ColumnVisible = false,
                    FixedColumn = FixedStyle.Left,
                    Alignment = HorzAlignment.Center
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "DetailBy",
                    ColumnVisible = false,
                    FixedColumn = FixedStyle.Left,
                    Alignment = HorzAlignment.Center
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "AccountNumber",
                    ColumnCaption = "TK nợ",
                    FixedColumn = FixedStyle.Left,
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 60,
                    ToolTip = "Tài khoản nợ",
                    AllowEdit = true,
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "CorrespondingAccountNumber",
                    ColumnCaption = "TK có",
                    FixedColumn = FixedStyle.Left,
                    ColumnPosition = 3,
                    ColumnVisible = true,
                    ColumnWith = 60,
                    ToolTip = "Tài khoản có",
                    AllowEdit = true
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "Description",
                    ColumnCaption = "Diễn giải",
                    FixedColumn = FixedStyle.Left,
                    ColumnPosition = 4,
                    ColumnVisible = true,
                    ColumnWith = 300,
                    AllowEdit = true
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "AmountOc",
                    ColumnCaption = "Số tiền",
                    ColumnPosition = 5,
                    ColumnType = UnboundColumnType.Decimal,
                    FixedColumn = FixedStyle.None,
                    ColumnVisible = true,
                    ColumnWith = 100,
                    AllowEdit = false
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "CurrencyCode",
                    ColumnCaption = "Tiền tệ",
                    ColumnPosition = 6,
                    FixedColumn = FixedStyle.None,
                    ColumnVisible = false,
                    ColumnWith = 100,
                    ToolTip = "Tiền tệ",
                    AllowEdit = false
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "ExchangeRate",
                    ColumnCaption = "Tỷ giá",
                    ColumnPosition = 7,
                    FixedColumn = FixedStyle.None,
                    ColumnVisible = true,
                    ColumnWith = 80,
                    ToolTip = "tỷ giá",
                    AllowEdit = true

                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "AmountExchange",
                    ColumnCaption = "Quy đổi",
                    ColumnPosition = 8,
                    ColumnType = UnboundColumnType.Decimal,
                    FixedColumn = FixedStyle.None,
                    ColumnVisible = true,
                    ColumnWith = 80,
                    AllowEdit = false
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BudgetSourceCode",
                    ColumnCaption = "Nguồn vốn",
                    ColumnPosition = 9,
                    FixedColumn = FixedStyle.None,
                    ColumnVisible = true,
                    ColumnWith = 80,
                    AllowEdit = true
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
                    AllowEdit = true
                });


                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "VoucherTypeId",
                    ColumnCaption = "Nghiệp vụ",
                    ColumnPosition = 11,
                    FixedColumn = FixedStyle.None,
                    ColumnVisible = true,
                    ColumnWith = 100,
                    AllowEdit = true
                });

                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "DepartmentId",
                    ColumnCaption = "Phòng ban",
                    ColumnPosition = 12,
                    FixedColumn = FixedStyle.None,
                    ColumnVisible = true,
                    ColumnWith = 100,
                    ToolTip = "Phòng ban",
                    AllowEdit = true
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "CustomerId",
                    ColumnCaption = "Khách hàng",
                    ColumnPosition = 13,
                    FixedColumn = FixedStyle.None,
                    ColumnVisible = false,
                    ColumnWith = 100,
                    ToolTip = "Khách hàng ",
                    AllowEdit = true
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "VendorId",
                    ColumnCaption = "Nhà cung cấp",
                    ColumnPosition = 14,
                    FixedColumn = FixedStyle.None,
                    ColumnVisible = true,
                    ColumnWith = 100,
                    ToolTip = "Nhà cung cấp",
                    AllowEdit = true
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "EmployeeId",
                    ColumnCaption = "Nhân viên",
                    ColumnPosition = 15,
                    FixedColumn = FixedStyle.None,
                    ColumnVisible = true,
                    ColumnWith = 100,
                    ToolTip = "Nhân viên",
                    AllowEdit = true
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "AccountingObjectId",
                    ColumnCaption = "Đối tượng khác",
                    ColumnPosition = 16,
                    FixedColumn = FixedStyle.None,
                    ColumnVisible = true,
                    ColumnWith = 100,
                    ToolTip = "Đối tượng khác",
                    AllowEdit = true
                });
                //ColumnsCollection.Add(new XtraColumn
                //{
                //    ColumnName = "ProjectId",
                //    ColumnCaption = "Dự án",
                //    FixedColumn = FixedStyle.None,
                //    ColumnPosition = 17,
                //    ColumnVisible = true,
                //    ColumnWith = 150,
                //    AllowEdit = true
                //});

                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "InventoryItemId",
                    ColumnCaption = "Vật tư",
                    FixedColumn = FixedStyle.None,
                    ColumnPosition = 17,
                    ColumnVisible = false,
                    ColumnWith = 150,
                    ToolTip = "Vật tư",
                    AllowEdit = false
                });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "CapitalAllocateCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BankId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefId", ColumnVisible = false });
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
                        gridViewDetail.Columns[column.ColumnName].OptionsColumn.AllowEdit = column.AllowEdit;
                        switch (column.ColumnName)
                        {
                            case "AccountNumber":
                                gridViewDetail.Columns[column.ColumnName].ColumnEdit = _rpsAccountNumber;
                                break;
                            case "CorrespondingAccountNumber":
                                gridViewDetail.Columns[column.ColumnName].ColumnEdit = _rpsCorrespondingAccountNumber;
                                break;
                            case "BudgetItemCode":
                                gridViewDetail.Columns[column.ColumnName].ColumnEdit = _rpsBudgetItem;
                                break;
                            case "BudgetSourceCode":
                                gridViewDetail.Columns[column.ColumnName].ColumnEdit = _rpsBudgetSource;
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
                            //break;
                            case "VoucherTypeId":
                                gridViewDetail.Columns[column.ColumnName].ColumnEdit = _rpsVoucherTypeId;
                                break;
                            case "ExchangeRate":
                                gridViewDetail.Columns[column.ColumnName].ColumnEdit = _rpsSpinEdit;
                                break;
                            case "InventoryItemId":
                                gridViewDetail.Columns[column.ColumnName].ColumnEdit = _rpsInventoryItem;
                                break;
                        }
                    }
                    else gridViewDetail.Columns[column.ColumnName].Visible = false;
                    SetNumericFormatControl(gridViewDetail, true);
                }

                gridViewDetail.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                gridViewDetail.OptionsBehavior.AllowAddRows = DefaultBoolean.False;
            }
        }

        public IList<CaptitalAllocateVoucherModel> GetCaptitalAllocateVouchersForUpdateOrInsert
        {
            set
            {
                grdCapitalAllocate.DataSource = value;
                grdViewCapitalAllocate.PopulateColumns(value);
                var columnCollection = new List<XtraColumn>
                    {
                        new XtraColumn
                            {
                                ColumnName = "RefDetailId",
                                ColumnCaption = "",
                                ColumnPosition = 1,
                                ColumnVisible = false,
                                ColumnWith = 70,
                                AllowEdit = false,
                                FixedColumn = FixedStyle.Left
                            },
                        new XtraColumn
                            {
                                ColumnName = "BudgetItemCode",
                                ColumnCaption = "Khoản thu",
                                ColumnPosition = 2,
                                ColumnVisible = true,
                                ColumnWith = 100,
                                AllowEdit = false,
                                ToolTip = "Khoản thu",
                               FixedColumn = FixedStyle.Left
                            },
                        new XtraColumn
                            {
                                ColumnName = "CapitalAllocateCode",
                                ColumnCaption = "Mã phân bổ",
                                ColumnPosition = 3,
                                ColumnVisible = false,
                                ColumnWith = 100,
                                AllowEdit = false,
                                ToolTip = "Mã phân bổ",
                                FixedColumn = FixedStyle.Left,


                            },

                        new XtraColumn
                            {
                                ColumnName = "Description",
                                ColumnCaption = "Diễn giải",
                                ColumnPosition = 4,
                                ColumnVisible = true,
                                ColumnWith = 300,
                                AllowEdit = false,
                                ToolTip = "Diễn giải",
                                FixedColumn = FixedStyle.Left,
                            },
                        new XtraColumn
                            {
                                ColumnName = "CurrencyCode",
                                ColumnVisible = false,
                                ColumnPosition = 5,
                                ColumnWith = 70,
                                AllowEdit = false,
                                ToolTip = "Loại tiền",
                                FixedColumn = FixedStyle.None
                            },

                        new XtraColumn
                            {
                                ColumnName = "TotalAmount",
                                ColumnCaption = "Tổng tiền",
                                ColumnPosition = 6,
                                ColumnVisible = true,
                                ColumnWith = 150,
                                AllowEdit = false,
                                ToolTip = "Tổng tiền",
                                ColumnType = UnboundColumnType.Decimal,
                                FixedColumn = FixedStyle.None
                            },
                        new XtraColumn
                            {
                                ColumnName = "ExpenseAmount",
                                ColumnCaption = "Chi phí lãnh sự",
                                ColumnPosition = 7,
                                ColumnVisible = true,
                                ColumnWith = 150,
                                AllowEdit = false,
                                ToolTip = "Chi phí lãnh sự",
                                ColumnType = UnboundColumnType.Decimal,
                                FixedColumn = FixedStyle.None
                            },

                        new XtraColumn
                            {
                                ColumnName = "BudgetSourceCode",
                                ColumnCaption = "Quỹ",
                                ColumnPosition = 8,
                                ColumnVisible = true,
                                ColumnWith = 70,
                                AllowEdit = false,
                                ToolTip = "Quỹ",
                                FixedColumn = FixedStyle.None
                                //FixedColumn = FixedStyle.Left
                            },
                        new XtraColumn
                            {
                                ColumnName = "BudgetSourceName",
                                ColumnCaption = "Tên quỹ",
                                ColumnPosition = 9,
                                ColumnVisible = true,
                                ColumnWith = 200,
                                AllowEdit = false,
                                ToolTip = "Tên quỹ",
                                FixedColumn = FixedStyle.None
                                //FixedColumn = FixedStyle.Left
                            },
                        new XtraColumn
                            {
                                ColumnName = "AllocatePercent",
                                ColumnCaption = "Tỷ lệ % ",
                                ColumnPosition = 10,
                                ColumnVisible = true,
                                ColumnWith = 100,
                                AllowEdit = true,
                                ToolTip = "Tỷ lệ % ",
                                ColumnType = UnboundColumnType.Decimal,
                                FixedColumn = FixedStyle.None
                                //FixedColumn = FixedStyle.Left
                            },
                        new XtraColumn
                            {
                                ColumnName = "Amount",
                                ColumnCaption = "Số tiền",
                                ColumnPosition = 11,
                                ColumnVisible = true,
                                ColumnWith = 150,
                                AllowEdit = true,
                                ToolTip = "Số tiền",
                                ColumnType = UnboundColumnType.Decimal,
                                FixedColumn = FixedStyle.None
                                //FixedColumn = FixedStyle.Left
                            },

                        new XtraColumn {ColumnName = "ActivityId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsActive", ColumnVisible = false},
                        new XtraColumn {ColumnName = "WaitBudgetSourceCode", ColumnVisible = false},
                        new XtraColumn {ColumnName = "CapitalAccountCode", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ExpenseAccountCode", ColumnVisible = false},
                        new XtraColumn {ColumnName = "RevenueAccountCode", ColumnVisible = false},
                        new XtraColumn {ColumnName = "DeterminedDate", ColumnVisible = false},
                        new XtraColumn {ColumnName = "AllocateType", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ActivityId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "RefId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "FromDate", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ToDate", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ExchangeRate", ColumnVisible = false}
                    };

                foreach (var column in columnCollection)
                {
                    if (column.ColumnVisible)
                    {
                        grdViewCapitalAllocate.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        grdViewCapitalAllocate.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                        grdViewCapitalAllocate.Columns[column.ColumnName].Width = column.ColumnWith;
                        grdViewCapitalAllocate.Columns[column.ColumnName].Fixed = column.FixedColumn;
                        grdViewCapitalAllocate.Columns[column.ColumnName].ToolTip = column.ToolTip;
                        grdViewCapitalAllocate.Columns[column.ColumnName].UnboundType = column.ColumnType;
                        grdViewCapitalAllocate.Columns[column.ColumnName].OptionsColumn.AllowEdit = (ActionMode != ActionModeVoucherEnum.None && column
                            .AllowEdit);

                        grdViewCapitalAllocate.ScrollStyle = ScrollStyleFlags.LiveVertScroll;
                        grdViewCapitalAllocate.OptionsSelection.EnableAppearanceFocusedCell = true;
                    }
                    else grdViewCapitalAllocate.Columns[column.ColumnName].Visible = false;
                }
                SetNumericFormatControl(grdViewCapitalAllocate, true);

            }
        }

        public IList<GeneralParalellDetailModel> GeneralParalellDetails { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        #endregion

        private void grdViewCapitalAllocate_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName.Equals("AllocatePercent"))
            {
                grdViewCapitalAllocate.PostEditor();
                var allocateType = (int)grdViewCapitalAllocate.GetRowCellValue(e.RowHandle, "AllocateType");
                var totalAmount = (decimal)grdViewCapitalAllocate.GetRowCellValue(e.RowHandle, "TotalAmount");
                var expenseAmount = (decimal)grdViewCapitalAllocate.GetRowCellValue(e.RowHandle, "ExpenseAmount");
                var allocatePercent = (decimal)grdViewCapitalAllocate.GetRowCellValue(e.RowHandle, "AllocatePercent");
                if (allocateType == 1)
                {
                    grdViewCapitalAllocate.SetRowCellValue(e.RowHandle, "Amount", totalAmount * allocatePercent / 100);
                }
                else
                {
                    grdViewCapitalAllocate.SetRowCellValue(e.RowHandle, "Amount", (totalAmount - expenseAmount) * allocatePercent / 100);
                }
            }
        }

        private void SetEnableGird(bool isEnable)
        {
            grdViewCapitalAllocate.OptionsBehavior.Editable = isEnable;
        }

        public override void gridViewDetail_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            base.gridViewDetail_CellValueChanged(sender, e);
        }

        private void gridViewDetail_RowUpdated(object sender, RowObjectEventArgs e)
        {
            var delExchangeRate = (decimal)gridViewDetail.GetRowCellValue(e.RowHandle, "ExchangeRate");
            for (var i = 0; i < gridViewDetail.RowCount; i++)
            {
                if (gridViewDetail.GetRow(i) != null)
                {
                    gridViewDetail.SetRowCellValue(i, gridViewDetail.Columns["ExchangeRate"], delExchangeRate);
                }
            }
        }

        private void txtGeneralDescription_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}

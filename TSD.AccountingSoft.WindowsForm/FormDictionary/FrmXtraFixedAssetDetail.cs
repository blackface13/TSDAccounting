/***********************************************************************
 * <copyright file="FrmXtraFixedAssetDetail.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Wednesday, February 26, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date 23/04/2014    Author ThangND        Description Edit FixedAssetCurrency
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Model.BusinessObjects.FixedAsset;
using TSD.AccountingSoft.Model.BusinessObjects.Opening;
using TSD.AccountingSoft.Model.BusinessObjects.Report;
using TSD.AccountingSoft.Presenter.Dictionary.Account;
using TSD.AccountingSoft.Presenter.Dictionary.AutoNumber;
using TSD.AccountingSoft.Presenter.Dictionary.BudgetSource;
using TSD.AccountingSoft.Presenter.Dictionary.Currency;
using TSD.AccountingSoft.Presenter.Dictionary.Department;
using TSD.AccountingSoft.Presenter.Dictionary.Employee;
using TSD.AccountingSoft.Presenter.Dictionary.FixedAsset;
using TSD.AccountingSoft.Presenter.FixedAsset.FixedAssetVoucher;
using TSD.AccountingSoft.Presenter.Report;
using TSD.AccountingSoft.Presenter.System.Lock;
using TSD.AccountingSoft.Session;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.View.FixedAsset;
using TSD.AccountingSoft.View.Report;
using TSD.AccountingSoft.View.System;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.FormBusiness;
using TSD.AccountingSoft.WindowsForm.Resources;
using TSD.AccountingSoft.Report.ReportClass;
using TSD.Enum;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraVerticalGrid.Events;
using DevExpress.XtraVerticalGrid.Rows;
using CellValueChangedEventArgs = DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs;
using FixedStyle = DevExpress.XtraVerticalGrid.Rows.FixedStyle;
using PopupMenuShowingEventArgs = DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs;
using TSD.AccountingSoft.WindowsForm.CommonClass;
using TSD.AccountingSoft.Presenter.Dictionary.BudgetItem;

namespace TSD.AccountingSoft.WindowsForm.FormDictionary
{
    public partial class FrmXtraFixedAssetDetail : FrmXtraBaseCategoryDetail, IFixedAssetView, IFixedAssetCategoriesView,
        IDepartmentsView, ICurrenciesView, IFixedAssetVouchersView, IAccountsView, IEmployeesView,
        IAutoNumberView, IBudgetSourcesView, IReportView, ILockView, IBudgetItemsView
    {
        private readonly ReportListPresenter _reportListPresenter;
        private readonly LockPresenter _lockPresenter;
        private List<ReportListModel> _reportList;
        private List<AccountModel> _lstCapitalAccounts;

        public string ReportID { get; set; }

        #region Declare paramters

        private readonly GlobalVariable _dbOptionHelper;
        private MultiEditorRow _accumulatedDepreciationAmountRow;
        private MultiEditorRow _annualDepreciationAmountRow;
        private int _cellIndex;
        private MultiEditorRow _orgPriceRow;

        private MultiEditorRowProperties _propAccumulatedDepreciationAmount;
        private MultiEditorRowProperties _propAccumulatedDepreciationAmountExchange;

        private MultiEditorRowProperties _propAnnualDepreciationAmount;
        private MultiEditorRowProperties _propAnnualDepreciationAmountExchange;
        private MultiEditorRowProperties _propOrgPrice;
        private MultiEditorRowProperties _propOrgPriceExchange;
        private MultiEditorRowProperties _propRemainingAmount;
        private MultiEditorRowProperties _propRemainingAmountExchange;
        private MultiEditorRowProperties _propUnitPrice;
        private MultiEditorRowProperties _propUnitPriceExchange;

        private int _recordIndex;
        private MultiEditorRow _remainingAmountRow;
        private string _rowName;
        private MultiEditorRow _unitPriceRow;

        #endregion

        #region Declare Variable

        private const int RefTypeId = 500;
        private const int RefOpenTypeId = 702;
        private const int DecrementRefTypeId = 501;
        private readonly AccountsPresenter _accountsPresenter;
        private readonly BudgetSourcesPresenter _budgetSourcesPresenter;
        private readonly CurrenciesPresenter _currenciesPresenter;
        private readonly DepartmentsPresenter _departmentsPresenter;
        private readonly EmployeesPresenter _employeesPresenter;
        private readonly FixedAssetCategoriesPresenter _fixedAssetCategoriesPresenter;
        private readonly FixedAssetPresenter _fixedAssetPresenter;
        private readonly FixedAssetVouchersPresenter _fixedAssetVouchersPresenter;
        //private readonly FixedAssetDecrementsPresenter _fixedAssetDecrementsPresenter;
        private AutoNumberPresenter _autoNumberPresenter;
        private readonly BudgetItemsPresenter _budgetItemsPresenter;

        private RepositoryItemCalcEdit _calcEditExchangeRate;
        private RepositoryItemComboBox _cboCurrencyCode;
        private int _quantityOnHand;

        private string _refNo;
        private string _refNoUSD;
        public string BaseRefNo { get; set; }

        private RepositoryItemCalcEdit _repositoryCurrencyCalcEdit;

        private RepositoryItemCalcEdit _repositoryCurrencyExchangeRateCalcEdit;

        private RepositoryItemGridLookUpEdit _repositoryItemGridLookUpCurrency;

        #endregion

        #region IFixedAssetView Members

        public int FixedAssetId { get; set; }

        public string FixedAssetCode
        {
            get { return txtFixedAssetCode.Text; }
            set { txtFixedAssetCode.Text = value; }
        }

        public string FixedAssetName
        {
            get { return txtFixedAssetName.Text; }
            set { txtFixedAssetName.Text = value; }
        }

        public string FixedAssetForeignName { get; set; }

        public int FixedAssetCategoryId
        {
            get
            {
                if (grdLookUpFixedAssetCategory.EditValue == null) return 0;
                return (int)grdLookUpFixedAssetCategory.EditValue;
            }
            set { grdLookUpFixedAssetCategory.EditValue = value; }
        }

        public int State
        {
            get { return cboState.SelectedIndex; }
            set { cboState.SelectedIndex = value; }
        }

        public string Description
        {
            get { return txtDescription.Text; }
            set { txtDescription.Text = value; }
        }

        public int ProductionYear
        {
            get { return (int)txtProductYear.Value; }
            set { txtProductYear.Value = value; }
        }

        public string MadeIn
        {
            get { return txtMadeIn.Text; }
            set { txtMadeIn.Text = value; }
        }

        public DateTime PurchasedDate
        {
            get { return dtPurchasedDate.DateTime; }
            set
            {
                dtPurchasedDate.DateTime = value == DateTime.MinValue
                    ? DateTime.Parse(new GlobalVariable().PostedDate)
                    : value;
            }
        }

        public DateTime UsedDate
        {
            get { return dtUsedDate.DateTime; }
            set
            {
                dtUsedDate.DateTime = value == DateTime.MinValue
                    ? DateTime.Parse(new GlobalVariable().PostedDate)
                    : value;
            }
        }

        public DateTime DepreciationDate
        {
            get { return dtDepreciationDate.DateTime; }
            set
            {
                dtDepreciationDate.DateTime = value == DateTime.MinValue
                    ? DateTime.Parse(new GlobalVariable().PostedDate)
                    : value;
            }
        }

        public DateTime IncrementDate
        {
            get { return DateTime.Parse(new GlobalVariable().PostedDate); }
            set { }
        }

        public DateTime DisposedDate
        {
            get { return DateTime.Parse(new GlobalVariable().PostedDate); }
            set { }
        }

        public string Unit
        {
            get { return txtUnit.Text; }
            set { txtUnit.Text = value; }
        }

        public string SerialNumber
        {
            get { return txtSerialNumber.Text; }
            set { txtSerialNumber.Text = value; }
        }

        public string Accessories
        {
            get { return txtReasonSuspension.Text; }
            set { txtReasonSuspension.Text = value; }
        }

        public int Quantity
        {
            get { return (int)txtQuantity.Value; }
            set { txtQuantity.Value = value == 0 ? 1 : value; }
        }

        public decimal UnitPrice
        {
            get { return txtUnitPrice.Value; }
            set { txtUnitPrice.Value = value; }


        }

        public decimal OrgPrice
        {
            get { return txtOrgPrice.Value; }
            set { txtOrgPrice.Value = value; }
        }

        public decimal AccumDepreciationAmount
        {
            get { return txtAccumDepreciationAmount.Value; }
            set { txtAccumDepreciationAmount.Value = value; }
        }

        public decimal RemainingAmount
        {
            get { return txtRemainingAmount.Value; }
            set { txtRemainingAmount.Value = value; }
        }

        public string CurrencyCode
        {
            get
            {
                if (grdLookUpCurrency.EditValue == null) return null;
                return (string)grdLookUpCurrency.GetColumnValue("CurrencyCode");
            }
            set { grdLookUpCurrency.EditValue = value; }
        }

        public decimal ExchangeRate
        {
            get { return txtExchangeRate.Value; }
            set { txtExchangeRate.Value = value; }
        }

        public decimal UnitPriceUSD
        {
            get { return txtUnitPriceUSD.Value; }
            set
            {
                txtUnitPriceUSD.Value = value;
            }

        }

        public decimal OrgPriceUSD
        {
            get { return txtOrgPriceUSD.Value; }
            set { txtOrgPriceUSD.Value = value; }
        }

        public decimal AccumDepreciationAmountUSD
        {
            get { return txtAccumDepreciationAmountUSD.Value; }
            set { txtAccumDepreciationAmountUSD.Value = value; }
        }

        public decimal RemainingAmountUSD
        {
            get { return txtRemainingAmountUSD.Value; }
            set { txtRemainingAmountUSD.Value = value; }
        }

        public decimal AnnualDepreciationAmount
        {
            get { return txtAnnualDepreciationAmount.Value; }
            set { txtAnnualDepreciationAmount.Value = value; }
        }

        public decimal AnnualDepreciationAmountUSD
        {
            get { return txtAnnualDepreciationAmountUSD.Value; }
            set { txtAnnualDepreciationAmountUSD.Value = value; }
        }

        public decimal LifeTime
        {
            get { return txtLifeTime.Value; }
            set { txtLifeTime.Value = value; }
        }

        public decimal DepreciationRate
        {
            get { return txtDepreciationRate.Value; }
            set { txtDepreciationRate.Value = value; }
        }

        public string OrgPriceAccountCode
        {
            get
            {
                var account = (AccountModel)grdLookUpOrgPriceAccount.GetSelectedDataRow();
                return account == null ? null : account.AccountCode;
            }
            set { grdLookUpOrgPriceAccount.EditValue = value; }
        }

        public string DepreciationAccountCode
        {
            get
            {
                var account = (AccountModel)grdLookUpDepreciationAccount.GetSelectedDataRow();
                return account == null ? null : account.AccountCode;
            }
            set { grdLookUpDepreciationAccount.EditValue = value; }
        }

        public string CapitalAccountCode
        {
            get
            {
                var account = (AccountModel)grdLookUpCapitalAccount.GetSelectedDataRow();
                return account == null ? null : account.AccountCode;
            }
            set { grdLookUpCapitalAccount.EditValue = value; }
        }

        public int DepartmentId
        {
            get
            {
                var department = (DepartmentModel)grdLookUpDepartment.GetSelectedDataRow();
                if (department != null)
                    return department.DepartmentId;
                else
                    return 0;
            }
            set
            {
                grdLookUpDepartment.EditValue = value;
                _employeesPresenter.DisplayActiveByDepartment(value);
            }
        }

        public int? EmployeeId
        {
            get
            {
                var employee = (EmployeeModel)grdlookUpEmployee.GetSelectedDataRow();
                if (employee != null)
                    return employee.EmployeeId;
                else
                    return null;
            }
            set { grdlookUpEmployee.EditValue = value; }
        }

        public bool IsActive
        {
            get { return chkInactive.Checked; }
            set { chkInactive.Checked = value; }
        }

        public short NumberOfFloor
        {
            get { return (short)txtNumberOfFloor.EditValue; }
            set { txtNumberOfFloor.EditValue = value; }
        }

        public decimal AreaOfBuilding
        {
            get { return (decimal)txtAreaOfBuilding.EditValue; }
            set { txtAreaOfBuilding.EditValue = value; }
        }

        public decimal AreaOfFloor
        {
            get { return (decimal)txtAreaOfFloor.EditValue; }
            set { txtAreaOfFloor.EditValue = value; }
        }

        public decimal WorkingArea
        {
            get { return (decimal)txtWorkingArea.EditValue; }
            set { txtWorkingArea.EditValue = value; }
        }

        public decimal AdministrationArea
        {
            get { return (decimal)txtAdministrationArea.EditValue; }
            set { txtAdministrationArea.EditValue = value; }
        }

        public decimal HousingArea
        {
            get { return (decimal)txtHousingArea.EditValue; }
            set { txtHousingArea.EditValue = value; }
        }

        public decimal VacancyArea
        {
            get { return (decimal)txtVacancyArea.EditValue; }
            set { txtVacancyArea.EditValue = value; }
        }

        public decimal OccupiedArea
        {
            get { return (decimal)txtOccupiedArea.EditValue; }
            set { txtOccupiedArea.EditValue = value; }
        }

        public decimal LeasingArea
        {
            get { return (decimal)txtLeasingArea.EditValue; }
            set { txtLeasingArea.EditValue = value; }
        }

        public decimal GuestHouseArea
        {
            get { return (decimal)txtGuestHouseArea.EditValue; }
            set { txtGuestHouseArea.EditValue = value; }
        }

        public decimal OtherArea
        {
            get { return (decimal)txtOtherArea.EditValue; }
            set { txtOtherArea.EditValue = value; }
        }

        public short NumberOfSeat
        {
            get { return (short)txtNumberOfSeat.EditValue; }
            set { txtNumberOfSeat.EditValue = value; }
        }

        public string Brand
        {
            get { return txtBrand.Text; }
            set { txtBrand.Text = value; }
        }

        public string ControlPlate
        {
            get { return txtControlPlate.Text; }
            set { txtControlPlate.Text = value; }
        }

        public bool IsStateManagement
        {
            get { return chkIsStateManagement.Checked; }
            set { chkIsStateManagement.Checked = value; }
        }

        public bool IsBussiness
        {
            get { return chkIsBussiness.Checked; }
            set { chkIsBussiness.Checked = value; }
        }

        public string Address
        {
            get { return txtAddress.Text; }
            set { txtAddress.Text = value; }
        }

        public string BudgetSourceCode
        {
            get
            {
                var budgetSource = (BudgetSourceModel)grdLookUpBudgetSource.GetSelectedDataRow();
                return budgetSource == null ? null : budgetSource.BudgetSourceCode;
            }
            set { grdLookUpBudgetSource.EditValue = value; }
        }

        public string ArmortizationAccount
        {
            get
            {
                var armortizationAccount = (AccountModel)gridLookUpArmortizationAccount.GetSelectedDataRow();
                return armortizationAccount == null ? null : armortizationAccount.AccountCode;
            }
            set { gridLookUpArmortizationAccount.EditValue = value; }
        }

        public string BudgetItemCode
        {
            get
            {
                var budgetItem = (BudgetItemModel)gridLookUpBudgetItem.GetSelectedDataRow();
                return budgetItem == null ? null : budgetItem.BudgetItemCode;
            }
            set
            {
                gridLookUpBudgetItem.EditValue = value;
            }
        }

        public int ManagementCar
        {
            get { return cboManagementCar.SelectedIndex; }
            set { cboManagementCar.SelectedIndex = value; }
        }

        public bool IsEstimateEmployee
        {
            get { return chkIsEstimateEmployee.Checked; }
            set { chkIsEstimateEmployee.Checked = value; }
        }

        public DateTime? DateSuspension
        {
            get { return dateEditDateSuspension.EditValue == null ? (DateTime?)null : Convert.ToDateTime(dateEditDateSuspension.EditValue); }
            set { dateEditDateSuspension.EditValue = value; }
        }

        public string ReasonSuspension
        {
            get { return txtReasonSuspension.EditValue == null ? null : txtReasonSuspension.EditValue.ToString(); }
            set { txtReasonSuspension.EditValue = value; }
        }

        public IList<FixedAssetCurrencyModel> FixedAssetCurrencies
        {
            get
            {
                var fixedAssetCurrencies = new List<FixedAssetCurrencyModel>();
                if (grdFixedAssetCurrency.DataSource != null && grdFixedAssetCurrencyView.RowCount > 0)
                {
                    for (int i = 0; i < grdFixedAssetCurrencyView.RowCount; i++)
                    {
                        if (grdFixedAssetCurrencyView.GetRow(i) != null)
                        {
                            fixedAssetCurrencies.Add(new FixedAssetCurrencyModel
                            {
                                CurrencyCode = (string)grdFixedAssetCurrencyView.GetRowCellValue(i, "CurrencyCode"),
                                ExchangeRate = (float)grdFixedAssetCurrencyView.GetRowCellValue(i, "ExchangeRate"),
                                UnitPrice = (decimal)grdFixedAssetCurrencyView.GetRowCellValue(i, "UnitPrice"),
                                UnitPriceUSD = (decimal)grdFixedAssetCurrencyView.GetRowCellValue(i, "UnitPriceUSD"),
                                OrgPrice = (decimal)grdFixedAssetCurrencyView.GetRowCellValue(i, "OrgPrice"),
                                OrgPriceUSD = (decimal)grdFixedAssetCurrencyView.GetRowCellValue(i, "OrgPriceUSD"),
                                AccumDepreciationAmount =
                                    (decimal)grdFixedAssetCurrencyView.GetRowCellValue(i, "AccumDepreciationAmount"),
                                AccumDepreciationAmountUSD =
                                    (decimal)grdFixedAssetCurrencyView.GetRowCellValue(i, "AccumDepreciationAmountUSD"),
                                RemainingAmount =
                                    (decimal)grdFixedAssetCurrencyView.GetRowCellValue(i, "RemainingAmount"),
                                RemainingAmountUSD =
                                    (decimal)grdFixedAssetCurrencyView.GetRowCellValue(i, "RemainingAmountUSD"),
                                AnnualDepreciationAmount =
                                    (decimal)grdFixedAssetCurrencyView.GetRowCellValue(i, "AnnualDepreciationAmount"),
                                AnnualDepreciationAmountUSD =
                                    (decimal)
                                        grdFixedAssetCurrencyView.GetRowCellValue(i, "AnnualDepreciationAmountUSD"),
                            });
                        }
                    }
                }


                //var currency = vGridControl1.GetCellValue(vGridControl1.Rows.GetRowByFieldName("CurrencyCode"),
                //   vGridControl1.FocusedRecord);

                //if (vGridControl1.DataSource != null && vGridControl1.RecordCount > 0)
                //{

                //    for (int i = 0; i < vGridControl1.Rows.Count; i++)
                //    {
                //        if (vGridControl1.Rows[i] is CategoryRow)
                //            vGridControl1.Rows[i].Expanded = false;
                //        else
                //        {
                //            fixedAssetCurrencies.Add(new FixedAssetCurrencyModel
                //            {
                //                CurrencyCode = (string)grdFixedAssetCurrencyView.GetRowCellValue(i, "CurrencyCode"),
                //                ExchangeRate = (float)grdFixedAssetCurrencyView.GetRowCellValue(i, "ExchangeRate"),
                //                UnitPrice = (decimal)grdFixedAssetCurrencyView.GetRowCellValue(i, "UnitPrice"),
                //                UnitPriceUSD = (decimal)grdFixedAssetCurrencyView.GetRowCellValue(i, "UnitPriceUSD"),
                //                OrgPrice = (decimal)grdFixedAssetCurrencyView.GetRowCellValue(i, "OrgPrice"),
                //                OrgPriceUSD = (decimal)grdFixedAssetCurrencyView.GetRowCellValue(i, "OrgPriceUSD"),
                //                AccumDepreciationAmount = (decimal)grdFixedAssetCurrencyView.GetRowCellValue(i, "AccumDepreciationAmount"),
                //                AccumDepreciationAmountUSD = (decimal)grdFixedAssetCurrencyView.GetRowCellValue(i, "AccumDepreciationAmountUSD"),
                //                RemainingAmount = (decimal)grdFixedAssetCurrencyView.GetRowCellValue(i, "RemainingAmount"),
                //                RemainingAmountUSD = (decimal)grdFixedAssetCurrencyView.GetRowCellValue(i, "RemainingAmountUSD"),
                //                AnnualDepreciationAmount = (decimal)grdFixedAssetCurrencyView.GetRowCellValue(i, "AnnualDepreciationAmount"),
                //                AnnualDepreciationAmountUSD = (decimal)grdFixedAssetCurrencyView.GetRowCellValue(i, "AnnualDepreciationAmountUSD"),
                //            });
                //        }
                //    }
                //}

                return fixedAssetCurrencies.ToList();
            }
            set
            {
                List<string> lstCurrenciCodes = new List<string>();

                _repositoryCurrencyExchangeRateCalcEdit = new RepositoryItemCalcEdit();
                _repositoryCurrencyExchangeRateCalcEdit.Mask.MaskType = MaskType.Numeric;
                _repositoryCurrencyExchangeRateCalcEdit.Mask.EditMask = @"c" + _dbOptionHelper.ExchangeRateDecimalDigits;
                _repositoryCurrencyExchangeRateCalcEdit.Mask.Culture = Thread.CurrentThread.CurrentCulture;
                _repositoryCurrencyExchangeRateCalcEdit.Precision = int.Parse(_dbOptionHelper.ExchangeRateDecimalDigits);
                _repositoryCurrencyExchangeRateCalcEdit.Mask.UseMaskAsDisplayFormat = true;

                _repositoryCurrencyCalcEdit = new RepositoryItemCalcEdit();
                _repositoryCurrencyCalcEdit.Mask.MaskType = MaskType.Numeric;
                _repositoryCurrencyCalcEdit.Mask.EditMask = @"c" + _dbOptionHelper.CurrencyDecimalDigits;
                _repositoryCurrencyCalcEdit.Mask.Culture = Thread.CurrentThread.CurrentCulture;
                _repositoryCurrencyCalcEdit.Precision = int.Parse(_dbOptionHelper.CurrencyDecimalDigits);
                _repositoryCurrencyCalcEdit.Mask.UseMaskAsDisplayFormat = true;

                bindingSourceFixedAssetCurrency.DataSource = value ?? new List<FixedAssetCurrencyModel>();
                grdFixedAssetCurrencyView.PopulateColumns(value);
                if (ActionMode == ActionModeEnum.AddNew)
                {
                    vGridControl1.BeginUpdate();
                    var fixedAssetCurrencyModel = new FixedAssetCurrencyModel { ExchangeRate = 1, CurrencyCode = "USD" };
                    bindingSourceFixedAssetCurrency.Add(fixedAssetCurrencyModel);
                    vGridControl1.EndUpdate();

                    lstCurrenciCodes.Add("USD");
                }
                else if (value != null)
                {
                    lstCurrenciCodes.AddRange(value.Select(s => s.CurrencyCode));
                }
                // lọc tài khoản theo loại tiền
                DisplayAccountByCurrency(lstCurrenciCodes);

                vGridControl1.Rows["rowFixedAssetCurrencyId"].Visible = false;
                vGridControl1.Rows["rowFixedAssetId"].Visible = false;

                //Ẩn đi nếu muốn hiển thị hết
                vGridControl1.Rows["rowDescription"].Visible = false;
                vGridControl1.Rows["rowUnitPrice"].Visible = false;
                vGridControl1.Rows["rowOrgPrice"].Visible = false;
                vGridControl1.Rows["rowAccumDepreciationAmount"].Visible = false;
                vGridControl1.Rows["rowRemainingAmount"].Visible = false;
                vGridControl1.Rows["rowAnnualDepreciationAmount"].Visible = false;

                vGridControl1.Rows["rowUnitPriceUSD"].Visible = false;
                vGridControl1.Rows["rowOrgPriceUSD"].Visible = false;
                vGridControl1.Rows["rowAccumDepreciationAmountUSD"].Visible = false;
                vGridControl1.Rows["rowRemainingAmountUSD"].Visible = false;
                vGridControl1.Rows["rowAnnualDepreciationAmountUSD"].Visible = false;
                //End Ẩn đi nếu muốn hiển thị hết

                //Hiển thị caption tiếng việt
                vGridControl1.Rows["rowCurrencyCode"].Properties.Caption = @"Loại tiền";
                vGridControl1.Rows["rowCurrencyCode"].Properties.RowEdit = _cboCurrencyCode;
                vGridControl1.Rows["rowCurrencyCode"].Fixed = FixedStyle.Top;

                vGridControl1.Rows["rowExchangeRate"].Properties.UnboundType = UnboundColumnType.Decimal;
                vGridControl1.Rows["rowExchangeRate"].Properties.Caption = @"Tỷ giá";
                vGridControl1.Rows["rowExchangeRate"].Properties.RowEdit = _repositoryCurrencyExchangeRateCalcEdit;
                vGridControl1.Rows["rowExchangeRate"].Fixed = FixedStyle.Top;

                vGridControl1.Rows["rowUnitPrice"].Properties.Caption = @"Đơn giá";
                vGridControl1.Rows["rowOrgPrice"].Properties.Caption = @"Nguyên giá";
                vGridControl1.Rows["rowAccumDepreciationAmount"].Properties.Caption = @"Hao mòn LK";
                vGridControl1.Rows["rowRemainingAmount"].Properties.Caption = @"Giá trị còn lại";
                vGridControl1.Rows["rowAnnualDepreciationAmount"].Properties.Caption = @"HM hằng năm";
                vGridControl1.Rows["rowUnitPriceUSD"].Properties.Caption = @"Đơn giá Quy đổi";
                vGridControl1.Rows["rowOrgPriceUSD"].Properties.Caption = @"Nguyên giá Quy đổi";
                vGridControl1.Rows["rowAccumDepreciationAmountUSD"].Properties.Caption = @"Hao mòn LK Quy đổi";
                vGridControl1.Rows["rowRemainingAmountUSD"].Properties.Caption = @"Giá trị còn lại Quy đổi";
                vGridControl1.Rows["rowAnnualDepreciationAmountUSD"].Properties.Caption = @"HM hằng năm Quy đổi";
                //End hiển thị tiếng Việt

                //Set Visible index
                vGridControl1.Rows["rowCurrencyCode"].Index = 0;
                vGridControl1.Rows["rowExchangeRate"].Index = 1;

                vGridControl1.Rows["rowUnitPrice"].Index = 2;
                vGridControl1.Rows["rowUnitPriceUSD"].Index = 3;

                vGridControl1.Rows["rowOrgPrice"].Index = 4;
                vGridControl1.Rows["rowOrgPriceUSD"].Index = 5;

                vGridControl1.Rows["rowAccumDepreciationAmount"].Index = 6;
                vGridControl1.Rows["rowAccumDepreciationAmountUSD"].Index = 7;

                vGridControl1.Rows["rowRemainingAmount"].Index = 8;
                vGridControl1.Rows["rowRemainingAmountUSD"].Index = 9;

                vGridControl1.Rows["rowAnnualDepreciationAmount"].Index = 10;
                vGridControl1.Rows["rowAnnualDepreciationAmountUSD"].Index = 11;

                //---------------------------------------------------

                vGridControl1.RowHeaderWidth = 250;
                vGridControl1.RecordWidth = 250;

                //Cách 2
                //Định dạng đơn giá
                _unitPriceRow = new MultiEditorRow { Name = @"UnitPriceRow" };
                _propUnitPrice = _unitPriceRow.PropertiesCollection.Add();
                _propUnitPrice.RowEdit = _repositoryCurrencyCalcEdit;
                _propUnitPrice.Caption = @"Đơn giá";
                _propUnitPrice.FieldName = "UnitPrice";
                //Định dạng đơn giá quy đổi
                _propUnitPriceExchange = _unitPriceRow.PropertiesCollection.Add();
                _propUnitPriceExchange.RowEdit = _repositoryCurrencyCalcEdit;
                _propUnitPriceExchange.Caption = @"Quy đổi";
                _propUnitPriceExchange.FieldName = "UnitPriceUSD";
                vGridControl1.Rows.Add(_unitPriceRow);

                // Định dạng nguyên giá
                _orgPriceRow = new MultiEditorRow { Name = @"OrgPriceRow" };
                _propOrgPrice = _orgPriceRow.PropertiesCollection.Add();
                _propOrgPrice.RowEdit = _repositoryCurrencyCalcEdit;
                _propOrgPrice.Caption = @"Nguyên giá";
                _propOrgPrice.FieldName = "OrgPrice";
                // định dạng nguyên giá quy đổi
                _propOrgPriceExchange = _orgPriceRow.PropertiesCollection.Add();
                _propOrgPriceExchange.RowEdit = _repositoryCurrencyCalcEdit;
                _propOrgPriceExchange.Caption = @"Quy đổi";
                _propOrgPriceExchange.FieldName = "OrgPriceUSD";
                vGridControl1.Rows.Add(_orgPriceRow);

                // Định dạng hao mòn đầu kỳ
                _accumulatedDepreciationAmountRow = new MultiEditorRow { Name = @"AccumulatedDepreciationAmountRow" };
                _propAccumulatedDepreciationAmount = _accumulatedDepreciationAmountRow.PropertiesCollection.Add();
                _propAccumulatedDepreciationAmount.RowEdit = _repositoryCurrencyCalcEdit;
                _propAccumulatedDepreciationAmount.Caption = @"HMLK";
                _propAccumulatedDepreciationAmount.FieldName = "AccumDepreciationAmount";
                // Định dạng hao mòn đầu kỳ quy đổi
                _propAccumulatedDepreciationAmountExchange =
                    _accumulatedDepreciationAmountRow.PropertiesCollection.Add();
                _propAccumulatedDepreciationAmountExchange.RowEdit = _repositoryCurrencyCalcEdit;
                _propAccumulatedDepreciationAmountExchange.Caption = @"Quy đổi";
                _propAccumulatedDepreciationAmountExchange.FieldName = "AccumDepreciationAmountUSD";
                vGridControl1.Rows.Add(_accumulatedDepreciationAmountRow);

                //Định dạng giá trị còn lại
                _remainingAmountRow = new MultiEditorRow { Name = @"RemainingAmountRow" };
                _propRemainingAmount = _remainingAmountRow.PropertiesCollection.Add();
                _propRemainingAmount.RowEdit = _repositoryCurrencyCalcEdit;
                _propRemainingAmount.Caption = @"GTCL";
                _propRemainingAmount.FieldName = "RemainingAmount";
                // Định dạng giá trị còn lại quy đổi
                _propRemainingAmountExchange = _remainingAmountRow.PropertiesCollection.Add();
                _propRemainingAmountExchange.RowEdit = _repositoryCurrencyCalcEdit;
                _propRemainingAmountExchange.Caption = @"Quy đổi";
                _propRemainingAmountExchange.FieldName = "RemainingAmountUSD";
                vGridControl1.Rows.Add(_remainingAmountRow);

                // Định dang hao mòn hàng năm
                _annualDepreciationAmountRow = new MultiEditorRow { Name = @"AnnualDepreciationAmountRow" };
                _propAnnualDepreciationAmount = _annualDepreciationAmountRow.PropertiesCollection.Add();
                _propAnnualDepreciationAmount.RowEdit = _repositoryCurrencyCalcEdit;
                _propAnnualDepreciationAmount.Caption = @"HM hàng năm";
                _propAnnualDepreciationAmount.FieldName = "AnnualDepreciationAmount";
                //Định dạng hao mòn hàng năm quy đổi
                _propAnnualDepreciationAmountExchange = _annualDepreciationAmountRow.PropertiesCollection.Add();
                _propAnnualDepreciationAmountExchange.RowEdit = _repositoryCurrencyCalcEdit;
                _propAnnualDepreciationAmountExchange.Caption = @"Quy đổi";
                _propAnnualDepreciationAmountExchange.FieldName = "AnnualDepreciationAmountUSD";
                vGridControl1.Rows.Add(_annualDepreciationAmountRow);

                /*End LinhMC test with Vertical Grid*/
                var gridColumnsCollection = new List<XtraColumn>
                {
                    new XtraColumn {ColumnName = "FixedAssetCurrencyId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "FixedAssetId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Description", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "CurrencyCode",
                        ColumnCaption = "Loại tiền",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 70,
                        FixedColumn = DevExpress.XtraGrid.Columns.FixedStyle.Left,
                        RepositoryControl = _cboCurrencyCode
                    },
                    new XtraColumn
                    {
                        ColumnName = "ExchangeRate",
                        ColumnCaption = "Tỷ giá",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 70,
                        FixedColumn = DevExpress.XtraGrid.Columns.FixedStyle.Left,
                        RepositoryControl = _calcEditExchangeRate,
                    },
                    new XtraColumn
                    {
                        ColumnName = "UnitPrice",
                        ColumnCaption = "Đơn giá",
                        ColumnPosition = 3,
                        ColumnVisible = true,
                        ColumnWith = 80,
                        ColumnType = UnboundColumnType.Decimal,
                        ToolTip = "Đơn giá sử dụng tiền địa phương"
                    },
                    new XtraColumn
                    {
                        ColumnName = "OrgPrice",
                        ColumnCaption = "Nguyên giá",
                        ColumnPosition = 4,
                        ColumnVisible = true,
                        ColumnWith = 80,
                        ColumnType = UnboundColumnType.Decimal,
                        ToolTip = "Nguyên giá sử dụng tiền địa phương"
                    },
                    new XtraColumn
                    {
                        ColumnName = "AccumDepreciationAmount",
                        ColumnCaption = "Hao mòn LK",
                        ColumnPosition = 5,
                        ColumnVisible = true,
                        ColumnWith = 80,
                        ColumnType = UnboundColumnType.Decimal,
                        ToolTip = "Hao mòn lũy kế sử dụng tiền địa phương"
                    },
                    new XtraColumn
                    {
                        ColumnName = "RemainingAmount",
                        ColumnCaption = "Giá trị còn lại",
                        ColumnPosition = 6,
                        ColumnVisible = true,
                        ColumnWith = 80,
                        ColumnType = UnboundColumnType.Decimal,
                        ToolTip = "Giá trị còn lại sử dụng tiền địa phương"
                    },
                    new XtraColumn
                    {
                        ColumnName = "AnnualDepreciationAmount",
                        ColumnCaption = "HM hằng năm",
                        ColumnPosition = 7,
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnType = UnboundColumnType.Decimal,
                        ToolTip = "Hao mòn hằng năm lại sử dụng tiền địa phương"
                    },
                    new XtraColumn
                    {
                        ColumnName = "UnitPriceUSD",
                        ColumnCaption = "Đơn giá QĐ",
                        ColumnPosition = 8,
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnType = UnboundColumnType.Decimal,
                        ToolTip = "Đơn giá quy đổi"
                    },
                    new XtraColumn
                    {
                        ColumnName = "OrgPriceUSD",
                        ColumnCaption = "Nguyên giá QĐ",
                        ColumnPosition = 9,
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnType = UnboundColumnType.Decimal,
                        ToolTip = "Nguyên giá quy đổi"
                    },
                    new XtraColumn
                    {
                        ColumnName = "AccumDepreciationAmountUSD",
                        ColumnCaption = "Hao mòn LK QĐ",
                        ColumnPosition = 10,
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnType = UnboundColumnType.Decimal,
                        ToolTip = "Hao mòn lũy kế quy đổi"
                    },
                    new XtraColumn
                    {
                        ColumnName = "RemainingAmountUSD",
                        ColumnCaption = "GTCL QĐ",
                        ColumnPosition = 11,
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnType = UnboundColumnType.Decimal,
                        ToolTip = "Giá trị còn lại quy đổi"
                    },
                    new XtraColumn
                    {
                        ColumnName = "AnnualDepreciationAmountUSD",
                        ColumnCaption = "HM hằng năm QĐ",
                        ColumnPosition = 12,
                        ColumnVisible = true,
                        ColumnWith = 120,
                        ColumnType = UnboundColumnType.Decimal,
                        ToolTip = "Hao mòn hằng năm quy đổi"
                    },
                };

                foreach (XtraColumn column in gridColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        grdFixedAssetCurrencyView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        grdFixedAssetCurrencyView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                        grdFixedAssetCurrencyView.Columns[column.ColumnName].Width = column.ColumnWith;
                        grdFixedAssetCurrencyView.Columns[column.ColumnName].ToolTip = column.ToolTip;
                        grdFixedAssetCurrencyView.Columns[column.ColumnName].Fixed = column.FixedColumn;
                        grdFixedAssetCurrencyView.Columns[column.ColumnName].ColumnEdit = column.RepositoryControl;
                        grdFixedAssetCurrencyView.Columns[column.ColumnName].UnboundType = column.ColumnType;
                    }
                    else
                        grdFixedAssetCurrencyView.Columns[column.ColumnName].Visible = false;
                }
                SetNumericFormatControl(grdFixedAssetCurrencyView, true);
            }
        }

        public IList<FixedAssetVoucherModel> FixedAssetVouchers
        {
            get { return null; }
            set
            {
                if (value == null)
                    value = new List<FixedAssetVoucherModel>();
                else
                    value = value.OrderByDescending(o => o.AccountNumber).ToList();

                bindingSourceFixedAssetVoucher.DataSource = value;
                gridView.PopulateColumns(value);

                var gridColumnsCollection = new List<XtraColumn>
                {
                    new XtraColumn {ColumnName = "RefId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "RefTypeId", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "RefNo",
                        ColumnCaption = "Mã CT",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 70,
                        FixedColumn = DevExpress.XtraGrid.Columns.FixedStyle.Left
                    },
                    new XtraColumn
                    {
                        ColumnName = "PostedDate",
                        ColumnCaption = "Ngày CT",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 70,
                        FixedColumn = DevExpress.XtraGrid.Columns.FixedStyle.Left
                    },
                    new XtraColumn
                    {
                        ColumnName = "Description",
                        ColumnCaption = "Diễn giải",
                        ColumnPosition = 3,
                        ColumnVisible = true,
                        ColumnWith = 250
                    },
                    new XtraColumn
                    {
                        ColumnName = "AccountNumber",
                        ColumnCaption = "TK Nợ",
                        ColumnPosition = 4,
                        ColumnVisible = true,
                        ColumnWith = 70
                    },
                    new XtraColumn
                    {
                        ColumnName = "CorrespondingAccountNumber",
                        ColumnCaption = "TK Có",
                        ColumnPosition = 5,
                        ColumnVisible = true,
                        ColumnWith = 70
                    },
                    new XtraColumn
                    {
                        ColumnName = "AmountOC",
                        ColumnCaption = "Số tiền",
                        ColumnPosition = 6,
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnType = UnboundColumnType.Decimal
                    },
                    new XtraColumn
                    {
                        ColumnName = "AmountExchange",
                        ColumnCaption = "Tiền quy đổi",
                        ColumnPosition = 7,
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnType = UnboundColumnType.Decimal
                    },
                    new XtraColumn
                    {
                        ColumnName = "AccumDepreciationAmount",
                        ColumnCaption = "Giá trị HM",
                        ColumnPosition = 8,
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnType = UnboundColumnType.Decimal
                    },
                    new XtraColumn
                    {
                        ColumnName = "AccumDepreciationAmountUSD",
                        ColumnCaption = "Giá trị HM quy đổi",
                        ColumnPosition = 9,
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnType = UnboundColumnType.Decimal
                    },
                    new XtraColumn
                    {
                        ColumnName = "RemainingAmount",
                        ColumnCaption = "Giá trị còn lại",
                        ColumnPosition = 10,
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnType = UnboundColumnType.Decimal
                    },
                    new XtraColumn
                    {
                        ColumnName = "RemainingAmountUSD",
                        ColumnCaption = "GTCL quy đổi",
                        ColumnPosition = 11,
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnType = UnboundColumnType.Decimal
                    },
                    new XtraColumn
                    {
                        ColumnName = "AnnualDepreciationAmount",
                        ColumnCaption = "HM lũy kế",
                        ColumnPosition = 12,
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnType = UnboundColumnType.Decimal
                    },
                    new XtraColumn
                    {
                        ColumnName = "AnnualDepreciationAmountUSD",
                        ColumnCaption = "HMLK quy đổi",
                        ColumnPosition = 13,
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnType = UnboundColumnType.Decimal
                    }
                };

                foreach (XtraColumn column in gridColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        gridView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        gridView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                        gridView.Columns[column.ColumnName].Width = column.ColumnWith;
                        gridView.Columns[column.ColumnName].ToolTip = column.ToolTip;
                        gridView.Columns[column.ColumnName].Fixed = column.FixedColumn;
                        gridView.Columns[column.ColumnName].ColumnEdit = column.RepositoryControl;
                        gridView.Columns[column.ColumnName].UnboundType = column.ColumnType;
                    }
                    else
                        gridView.Columns[column.ColumnName].Visible = false;
                }
                gridView.Columns["PostedDate"].SortOrder = ColumnSortOrder.Descending;
                SetNumericFormatControl(gridView, false);
            }
        }

        public IList<FixedAssetAccessaryModel> FixedAssetAccessarys
        {
            get
            {
                return (List<FixedAssetAccessaryModel>)bindingSourceFixedAssetAccessary.DataSource;
            }
            set
            {
                if (value == null)
                    value = new List<FixedAssetAccessaryModel>();

                bindingSourceFixedAssetAccessary.DataSource = value;
                gridAccessaryView.PopulateColumns(value);

                var gridColumnsCollection = new List<XtraColumn>
                {
                    new XtraColumn {ColumnName = "FixedAssetAccessaryId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "FixedAssetId", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "FixedAssetAccessaryName",
                        ColumnCaption = "Tên, quy cách dụng cụ, phụ tùng",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 300,
                    },
                    new XtraColumn
                    {
                        ColumnName = "Quantity",
                        ColumnCaption = "Số lượng",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnType = UnboundColumnType.Integer,
                    },
                    new XtraColumn
                    {
                        ColumnName = "Unit",
                        ColumnCaption = "Đợn vị tính",
                        ColumnPosition = 3,
                        ColumnVisible = true,
                        ColumnWith = 100,
                    },
                    new XtraColumn
                    {
                        ColumnName = "CurrencyCode",
                        ColumnCaption = "Loại tiền",
                        ColumnPosition = 4,
                        ColumnVisible = true,
                        ColumnWith = 100,
                        RepositoryControl = _repositoryItemGridLookUpCurrency
                    },
                    new XtraColumn
                    {
                        ColumnName = "ExchangeRate",
                        ColumnCaption = "Tỷ giá",
                        ColumnPosition = 5,
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnType = UnboundColumnType.Decimal
                    },
                    new XtraColumn
                    {
                        ColumnName = "AmountOc",
                        ColumnCaption = "Giá trị",
                        ColumnPosition = 6,
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnType = UnboundColumnType.Decimal
                    },
                    new XtraColumn
                    {
                        ColumnName = "AmountEx",
                        ColumnCaption = "Giá trị quy đổi",
                        ColumnPosition = 7,
                        ColumnVisible = true,
                        ColumnWith = 150,
                        ColumnType = UnboundColumnType.Decimal
                    },
                };

                foreach (XtraColumn column in gridColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        gridAccessaryView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        gridAccessaryView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                        gridAccessaryView.Columns[column.ColumnName].Width = column.ColumnWith;
                        gridAccessaryView.Columns[column.ColumnName].ToolTip = column.ToolTip;
                        gridAccessaryView.Columns[column.ColumnName].Fixed = column.FixedColumn;
                        gridAccessaryView.Columns[column.ColumnName].ColumnEdit = column.RepositoryControl;
                        gridAccessaryView.Columns[column.ColumnName].UnboundType = column.ColumnType;

                        if (column.ColumnName == "AmountEx")
                        {
                            gridAccessaryView.Columns[column.ColumnName].OptionsColumn.AllowEdit = false;
                        }
                    }
                    else
                        gridAccessaryView.Columns[column.ColumnName].Visible = false;
                }
                SetNumericFormatControl(gridAccessaryView, false);
            }
        }


        #endregion

        #region AutoNumber properties

        public string Prefix { private get; set; }

        public string Suffix { private get; set; }

        public int Value { private get; set; }

        public int ValueLocalCurency { get; set; }

        public int LengthOfValue { private get; set; }

        #endregion

        #region Override Methods

        public FrmXtraFixedAssetDetail()
        {
            InitializeComponent();
            _dbOptionHelper = new GlobalVariable();
            _fixedAssetPresenter = new FixedAssetPresenter(this);
            _fixedAssetCategoriesPresenter = new FixedAssetCategoriesPresenter(this);
            _departmentsPresenter = new DepartmentsPresenter(this);
            _currenciesPresenter = new CurrenciesPresenter(this);
            _budgetSourcesPresenter = new BudgetSourcesPresenter(this);
            _accountsPresenter = new AccountsPresenter(this);
            _employeesPresenter = new EmployeesPresenter(this);
            _fixedAssetVouchersPresenter = new FixedAssetVouchersPresenter(this);
            _autoNumberPresenter = new AutoNumberPresenter(this);
            _reportListPresenter = new ReportListPresenter(this);
            _budgetItemsPresenter = new BudgetItemsPresenter(this);
            _lockPresenter = new LockPresenter(this);

            _repositoryItemGridLookUpCurrency = new RepositoryItemGridLookUpEdit();
            this.gridAccessaryView.CellValueChanged += GridAccessaryView_CellValueChanged;
        }

        private void GridAccessaryView_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "AmountOc")
                {
                    decimal amountOc = gridAccessaryView.GetFocusedRowCellValue("AmountOc") == null ? 0 : Convert.ToDecimal(gridAccessaryView.GetFocusedRowCellValue("AmountOc"));
                    decimal exchange = gridAccessaryView.GetFocusedRowCellValue("ExchangeRate") == null ? 0 : Convert.ToDecimal(gridAccessaryView.GetFocusedRowCellValue("ExchangeRate"));
                    gridAccessaryView.SetRowCellValue(e.RowHandle, "AmountEx", amountOc / (exchange == 0 ? 1 : exchange));
                }

                if (e.Column.FieldName == "ExchangeRate")
                {
                    decimal amountOc = gridAccessaryView.GetFocusedRowCellValue("AmountOc") == null ? 0 : Convert.ToDecimal(gridAccessaryView.GetFocusedRowCellValue("AmountOc"));
                    decimal exchange = gridAccessaryView.GetFocusedRowCellValue("ExchangeRate") == null ? 0 : Convert.ToDecimal(gridAccessaryView.GetFocusedRowCellValue("ExchangeRate"));
                    gridAccessaryView.SetRowCellValue(e.RowHandle, "AmountEx", amountOc / (exchange == 0 ? 1 : exchange));
                }

                if (e.Column.FieldName == "CurrencyCode")
                {
                    var currencyCode = gridAccessaryView.GetRowCellValue(e.RowHandle, "CurrencyCode") == null ? "" : gridAccessaryView.GetRowCellValue(e.RowHandle, "CurrencyCode").ToString();
                    if (currencyCode.Trim().ToUpper() == "USD")
                    {
                        gridAccessaryView.SetRowCellValue(e.RowHandle, "ExchangeRate", 1);
                        gridAccessaryView.Columns["ExchangeRate"].OptionsColumn.AllowEdit = false;
                    }
                    else
                    {
                        gridAccessaryView.Columns["ExchangeRate"].OptionsColumn.AllowEdit = true;
                    }
                }
            }
            catch (Exception) { }
        }

        protected override void InitData()
        {
            _budgetItemsPresenter.DisplayActive();
            _fixedAssetCategoriesPresenter.DisplayActive();
            _departmentsPresenter.DisplayActive();
            _currenciesPresenter.DisplayActive();
            _budgetSourcesPresenter.DisplayActive();
            _accountsPresenter.DisplayActive();
            _fixedAssetVouchersPresenter.Display(KeyValue ?? "0");
            _cboCurrencyCode.Items.Add(CurrencyAccounting);
            _cboCurrencyCode.Items.Add(CurrencyLocal);
            _fixedAssetPresenter.Display(KeyValue ?? "0");

            if (ActionMode == ActionModeEnum.AddNew)
            {
                cboState.SelectedIndex = 1;
                GeneratedBaseRefNo();
                dtDepreciationDate.DateTime = DateTime.Parse(dtPurchasedDate.DateTime.Year + "/1/1");
                ArmortizationAccount = "61113";
            }
        }

        protected override bool ValidData()
        {
            object currencyCode = vGridControl1.GetCellValue(vGridControl1.Rows.GetRowByFieldName("CurrencyCode"), vGridControl1.FocusedRecord);

            object exchangeRate = vGridControl1.GetCellValue(vGridControl1.Rows.GetRowByFieldName("ExchangeRate"), vGridControl1.FocusedRecord);

            object orgPrice = vGridControl1.GetCellValue(vGridControl1.Rows.GetRowByFieldName("OrgPrice"), vGridControl1.FocusedRecord);

            if (!Convert.ToString(currencyCode).Equals("USD"))
            {
                if (Convert.ToDecimal(exchangeRate).Equals(1))
                {
                    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResFixedAssetCurrencyExchangeRateLessOne"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return false;
                }
                if (currencyCode == null)
                {
                    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResFixedAssetCurrency"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            else if (Convert.ToString(currencyCode).Equals("USD"))
            {
                if (!Convert.ToDecimal(exchangeRate).Equals(1))
                {
                    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResFixedAssetCurrencyExchangeRateLessOne"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }


            if (exchangeRate == null)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResCheckExchangeRate0"),
                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }



            if (Convert.ToDecimal(exchangeRate) == 0)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResCheckExchangeRate0"),
                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (Convert.ToDecimal(orgPrice) == 0)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResCheckOrgPrice0"),
                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (ReferenceEquals(grdlookUpEmployee.EditValue, null) || ReferenceEquals(grdlookUpEmployee.EditValue, ""))
            {
                XtraMessageBox.Show("Người sử dụng không được để trống!",
                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }


            if (string.IsNullOrEmpty(SerialNumber))
            {
                XtraMessageBox.Show("Thông số kỹ thuật không được để trống!",
                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (ProductionYear == 0)
            {
                XtraMessageBox.Show("Năm sản xuất không được để trống!",
                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(Unit))
            {
                XtraMessageBox.Show("Đơn vị tính không được để trống!",
                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(FixedAssetCode))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResEmptyFixedAssetCode"),
                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtFixedAssetCode.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(MadeIn))
            {
                XtraMessageBox.Show("Nơi sản xuất không được để trống!",
                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(FixedAssetName))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResEmptyFixedAssetName"),
                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtFixedAssetName.Focus();
                return false;
            }
            if (ReferenceEquals(grdLookUpFixedAssetCategory.EditValue, "") ||
                ReferenceEquals(grdLookUpFixedAssetCategory.EditValue, null))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResEmptyFixedAssetCategoryID"),
                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                grdLookUpFixedAssetCategory.Focus();
                return false;
            }
            if (ReferenceEquals(cboState.EditValue, "") || ReferenceEquals(cboState.EditValue, null))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResEmptyFixedAssetState"),
                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                cboState.Focus();
                return false;
            }
            if (ReferenceEquals(grdLookUpDepartment.EditValue, null) || ReferenceEquals(grdLookUpDepartment.EditValue, ""))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResEmptyDepartmentID"),
                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                tabControl.SelectedTabPage = tabGeneralInfo;
                grdLookUpDepartment.Focus();
                return false;
            }

            if (FixedAssetCurrencies.Count <= 0)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResEmptyFixedAssetCurrenciesNull"),
                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                grdFixedAssetCurrency.Focus();
                return false;
            }

            if (FixedAssetCurrencies.Count > 2)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResFixedAssetCurrenciesFalse"),
                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                grdFixedAssetCurrency.Focus();
                return false;
            }

            if (ReferenceEquals(dtPurchasedDate.EditValue, null))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResEmptyPurchasedDate"),
                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                tabControl.SelectedTabPage = tabAmountInfo;
                dtPurchasedDate.Focus();
                return false;
            }
            if (ReferenceEquals(dtUsedDate.EditValue, null))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResEmptyUsedDate"),
                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                tabControl.SelectedTabPage = tabAmountInfo;
                dtUsedDate.Focus();
                return false;
            }
            if (ReferenceEquals(dtDepreciationDate.EditValue, null))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResEmptyDepreciationDate"),
                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                tabControl.SelectedTabPage = tabAmountInfo;
                dtDepreciationDate.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(OrgPriceAccountCode))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResEmptyOrgPriceAccount"),
                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                tabControl.SelectedTabPage = tabAmountInfo;
                grdLookUpOrgPriceAccount.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(CapitalAccountCode))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResEmptyCapitalAccount"),
                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                tabControl.SelectedTabPage = tabAmountInfo;
                grdLookUpCapitalAccount.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(DepreciationAccountCode))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResEmptyDepreciationAccount"),
                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                tabControl.SelectedTabPage = tabAmountInfo;
                grdLookUpDepreciationAccount.Focus();
                return false;
            }

            object fixedAssetCategory6 = ((FixedAssetCategoryModel)grdLookUpFixedAssetCategory.GetSelectedDataRow()).FixedAssetCategoryCode;
            if (fixedAssetCategory6 != null)
            {
                if (LifeTime == 0)
                {
                    if (fixedAssetCategory6.ToString().Substring(0, 2) != "11")
                    {
                        XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResEmptyLifeTime"),
                            ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        tabControl.SelectedTabPage = tabAmountInfo;
                        txtLifeTime.Focus();
                        return false;
                    }
                }
                if (DepreciationRate == 0)
                {
                    if (fixedAssetCategory6.ToString().Substring(0, 2) != "11")
                    {
                        XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResEmptyDepreciationRate"),
                            ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        tabControl.SelectedTabPage = tabAmountInfo;
                        txtDepreciationRate.Focus();
                        return false;
                    }
                }
            }


            if (txtQuantity.Value <= 0)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResFixedAssetQuantityNotValid"),
                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                tabControl.SelectedTabPage = tabAmountInfo;
                txtQuantity.Focus();
                return false;
            }
            if (FixedAssetCurrencies.Count > 1 && txtQuantity.Value != 1)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResFixedAssetQuantityDefault"),
                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                tabControl.SelectedTabPage = tabAmountInfo;
                txtQuantity.Focus();
                return false;
            }

            if (FixedAssetCurrencies.Count > 1 && txtQuantity.Value != 1)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResFixedAssetQuantityDefault"),
                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                tabControl.SelectedTabPage = tabAmountInfo;
                txtQuantity.Focus();
                return false;
            }
            if (FixedAssetCurrencies.Count >= 0)
            {
                decimal totalOrgCost = 0;
                foreach (FixedAssetCurrencyModel fixedAssetCurrency in FixedAssetCurrencies)
                {
                    totalOrgCost = totalOrgCost + fixedAssetCurrency.UnitPriceUSD;
                }
                if ((totalOrgCost < 300 && cboState.SelectedIndex != 3) && dtPurchasedDate.DateTime.Year < 2015)
                {
                    if (totalOrgCost < 300 && cboState.SelectedIndex != 5 && dtPurchasedDate.DateTime.Year < 2015)
                    {
                        XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResFixedAssetOrgUSD"),
                        ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                        tabControl.SelectedTabPage = tabAmountInfo;
                        txtQuantity.Focus();
                        return false;
                    }
                }
                else if ((totalOrgCost < 250 && cboState.SelectedIndex != 3) && dtPurchasedDate.DateTime.Year >= 2015)
                {
                    if (totalOrgCost < 250 && cboState.SelectedIndex != 5 && dtPurchasedDate.DateTime.Year >= 2015)
                    {
                        XtraMessageBox.Show(" Nguyên giá tài sản cố định phải lớn hơn 250 USD !", "", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                        tabControl.SelectedTabPage = tabAmountInfo;
                        txtQuantity.Focus();
                        return false;
                    }
                }
            }

            //object fixedAssetCategory = grdLookUpFixedAssetCategoryView.GetFocusedRowCellValue("FixedAssetCategoryCode");
            //object fixedAssetCategory = grdLookUpFixedAssetCategoryView.GetFocusedRowCellValue("FixedAssetCategoryCode");

            var a = _fixedAssetCategoriesPresenter.GetAllFixedAssetCategories().Where(c => c.FixedAssetCategoryId.Equals(FixedAssetCategoryId)).ToList().FirstOrDefault();
            if (a != null)
            {
                object fixedAssetCategory = a.FixedAssetCategoryCode;
                if (fixedAssetCategory != null)
                {

                    if (ReferenceEquals(grdLookUpBudgetSource.EditValue, null) ||
                        ReferenceEquals(grdLookUpBudgetSource.EditValue, ""))
                    {
                        XtraMessageBox.Show("Bạn chưa nhập nguồn vốn!",
                            ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return false;
                    }

                }
                if (fixedAssetCategory != null)
                {
                    if (fixedAssetCategory.ToString().Substring(0, 2) == "01" & NumberOfFloor <= 0)
                    {
                        XtraMessageBox.Show("Số tầng của nhà phải khác 0!",
                            ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return false;
                    }
                }

                if (fixedAssetCategory != null && (fixedAssetCategory.ToString().Substring(0, 2) == "01" || fixedAssetCategory.ToString().Substring(0, 2) == "1104"))
                {
                    if (txtAddress.Text == "")
                    {
                        XtraMessageBox.Show("Địa chỉ nhà không được để trống",
                            ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return false;
                    }
                }


                if (fixedAssetCategory != null)
                {
                    if (fixedAssetCategory.ToString().Substring(0, 2) == "01" & AreaOfBuilding <= 0)
                    {
                        XtraMessageBox.Show("Diện tích xây dựng phải khác 0!",
                            ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return false;
                    }
                }

                if (fixedAssetCategory != null)
                {
                    if (fixedAssetCategory.ToString().Substring(0, 2) == "01" & AreaOfFloor <= 0)
                    {
                        XtraMessageBox.Show("Diện tích mặt sàn phải khác 0!",
                            ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return false;
                    }
                }

                if (fixedAssetCategory.ToString().Substring(0, 2) == "03")
                {
                    if (fixedAssetCategory != null)
                    {
                        if (fixedAssetCategory != null && fixedAssetCategory.ToString().Length > 3 && fixedAssetCategory.ToString().Substring(0, 3) == "031" && NumberOfSeat <= 0)
                        {
                            XtraMessageBox.Show("Số chỗ ngồi phải lớn hơn 0!", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }

                    if (fixedAssetCategory != null)
                    {
                        if (fixedAssetCategory != null && fixedAssetCategory.ToString().Length > 3 && fixedAssetCategory.ToString().Substring(0, 3) == "031" && ControlPlate == "")
                        {
                            XtraMessageBox.Show("Biển kiểm soát không được để trống!", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }

                    if (fixedAssetCategory != null)
                    {
                        if (fixedAssetCategory != null && fixedAssetCategory.ToString().Length > 3 && fixedAssetCategory.ToString().Substring(0, 3) == "031" && Brand == "")
                        {
                            XtraMessageBox.Show("Nhãn hiệu không được để trống!", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                }
            }

            if (spnReplication.Value >= 10)
            {
                XtraMessageBox.Show("Số lượng nhân bản phải nhỏ hơn 10!", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (ActionMode == ActionModeEnum.Edit)
            {
                bool checkFAOpening = CheckFixedAssetOpening();
                bool checkFAIncrement = CheckFixedAsset();

                if (!checkFAIncrement && !checkFAOpening)
                {
                    if (dtPurchasedDate.DateTime >= DateTime.Parse(GlobalVariable.SystemDate))
                    {
                        if (lookUpCapitalAccount.EditValue == null)
                        {
                            XtraMessageBox.Show("Bạn chưa chọn tài khoản tiền nguồn",
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            return false;
                        }
                    }

                    //if (grdLookupExpenseAccount.EditValue == null)
                    //{
                    //    XtraMessageBox.Show("Bạn chưa chọn tài khoản chi phí",
                    //        ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                    //        MessageBoxIcon.Error);
                    //    return false;
                    //}
                }
            }
            else
            {
                if (dtPurchasedDate.DateTime >= DateTime.Parse(GlobalVariable.SystemDate))
                {
                    if (lookUpCapitalAccount.EditValue == null)
                    {
                        XtraMessageBox.Show("Bạn chưa chọn tài khoản tiền nguồn",
                            ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return false;
                    }
                }
            }

            if (BudgetItemCode == null || BudgetItemCode == "")
            {
                XtraMessageBox.Show("Bạn chưa chọn Mục - Tiểu mục",
                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (ArmortizationAccount == null || ArmortizationAccount == "")
            {
                XtraMessageBox.Show("Bạn chưa chọn tài khoản tinh hao mòn",
                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            int i = 1;
            var fixedAssetAccessarys = FixedAssetAccessarys;
            if (fixedAssetAccessarys != null && fixedAssetAccessarys.Count > 0)
            {
                foreach (var item in fixedAssetAccessarys)
                {
                    if (item.CurrencyCode != "USD" && (item.ExchangeRate == 0 || item.ExchangeRate == 1))
                    {
                        MessageBox.Show("Tỷ giá theo tiền địa phương phải khác 0 hoặc khác 1 tại dòng " + i, ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return false;
                    }
                }
            }

            return true;
        }

        protected override int SaveData()
        {
            try
            {
                //for (int i = 0; i <= spnReplication.Value - 1; i++)
                // {
                //   FixedAssetCode = txtFixedAssetCode.EditValue + "_" +Convert.ToString(i);
                //_keyForSend = _fixedAssetPresenter.Save().ToString(CultureInfo.InvariantCulture);

                //}
                _keyForSend = _fixedAssetPresenter.Save(Convert.ToInt32(spnReplication.Value)).ToString(CultureInfo.InvariantCulture);
                long refId = 0;

                if (long.Parse(_keyForSend) > 0 && dtPurchasedDate.DateTime >= DateTime.Parse(GlobalVariable.SystemDate) && cboState.SelectedIndex == 1)
                {
                    if (ActionMode == ActionModeEnum.AddNew)
                    {
                        DialogResult dialogResult = XtraMessageBox.Show("Bạn có muốn ghi tăng TSCĐ không", "Ghi tăng tự động", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.OK && cboState.SelectedIndex == 1 && dtUsedDate.DateTime >= DateTime.Parse(GlobalVariable.SystemDate))
                        {
                            if (CheckBookLock(dtUsedDate.DateTime, "Bạn không thể ghi tăng tài sản trong ngày khóa sổ"))
                                return Int32.MaxValue;

                            refId = PostToGeneralLedger();
                            var frm = new FrmXtraFormFAIncrementDetail
                            {
                                RefId = refId,
                                KeyValue = refId.ToString(CultureInfo.InvariantCulture),
                                ActionMode = ActionModeVoucherEnum.Edit,
                                MasterBindingSource = new BindingSource(),
                                CurrentPosition = 1,
                            };
                            frm.ShowDialog();
                            Close();
                            //if (refId <= 0)
                            //{
                            //    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResSaveIcrementDataError"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //}
                            //else
                            //{
                            //    XtraMessageBox.Show(string.Format(ResourceHelper.GetResourceValueByName("ResFixedAssetIncrement"), _refNo), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //}
                        }

                        if (refId <= 0)
                        {
                            XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResSaveIcrementDataError"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            XtraMessageBox.Show(string.Format(ResourceHelper.GetResourceValueByName("ResFixedAssetIncrement"), _refNo), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else if (ActionMode == ActionModeEnum.Edit)
                    {
                        bool checkFAOpening = CheckFixedAssetOpening();
                        bool checkFADecrement = CheckFixedAssetDecrement();
                        bool checkFAIncrement = CheckFixedAsset();

                        if (checkFAOpening && !checkFADecrement)
                        {
                            _fixedAssetPresenter.DeleteOpeningFixedAssetEntry(int.Parse(_keyForSend));
                            DialogResult dialogResult = XtraMessageBox.Show("Bạn có muốn ghi tăng TSCĐ không", "Ghi tăng tự động", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.OK && cboState.SelectedIndex == 1 && dtUsedDate.DateTime >= DateTime.Parse(GlobalVariable.SystemDate))
                            {
                                if (CheckBookLock(dtUsedDate.DateTime, "Bạn không thể ghi tăng tài sản trong ngày khóa sổ"))
                                    return Int32.MaxValue;

                                refId = PostToGeneralLedger();
                                var frm = new FrmXtraFormFAIncrementDetail
                                {
                                    RefId = refId,
                                    KeyValue = refId.ToString(CultureInfo.InvariantCulture),
                                    ActionMode = ActionModeVoucherEnum.Edit,
                                    MasterBindingSource = new BindingSource(),
                                    CurrentPosition = 1
                                };
                                frm.ShowDialog();
                                Close();
                            }

                            if (refId <= 0)
                            {
                                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResSaveIcrementDataError"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                XtraMessageBox.Show(string.Format(ResourceHelper.GetResourceValueByName("ResFixedAssetIncrement"), _refNo), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }

                        else if (!checkFAOpening && !checkFADecrement && !checkFAIncrement)
                        {
                            DialogResult dialogResult = XtraMessageBox.Show("Bạn có muốn ghi tăng TSCĐ không", "Ghi tăng tự động", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.OK && cboState.SelectedIndex == 1 && dtUsedDate.DateTime >= DateTime.Parse(GlobalVariable.SystemDate))
                            {
                                if (CheckBookLock(dtUsedDate.DateTime, "Bạn không thể ghi tăng tài sản trong ngày khóa sổ"))
                                    return Int32.MaxValue;

                                refId = PostToGeneralLedger();
                                var frm = new FrmXtraFormFAIncrementDetail
                                {
                                    RefId = refId,
                                    KeyValue = refId.ToString(CultureInfo.InvariantCulture),
                                    ActionMode = ActionModeVoucherEnum.Edit,
                                    MasterBindingSource = new BindingSource(),
                                    CurrentPosition = 1
                                };
                                frm.ShowDialog();
                                Close();
                            }

                            if (refId <= 0)
                            {
                                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResSaveIcrementDataError"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                XtraMessageBox.Show(string.Format(ResourceHelper.GetResourceValueByName("ResFixedAssetIncrement"), _refNo), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }

                    }
                }

                else if (dtPurchasedDate.DateTime < DateTime.Parse(GlobalVariable.SystemDate))
                {
                    if (ActionMode == ActionModeEnum.AddNew)
                    {
                        DialogResult dialogResult = XtraMessageBox.Show("Bạn có muốn ghi số dư đầu kỳ",
                            "Ghi số dư đầu kỳ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.OK)
                        {
                            if (CheckBookLock(dtUsedDate.DateTime, "Bạn không thể ghi dư đầu kỳ khi khóa sổ"))
                                return Int32.MaxValue;

                            PostOpeningFixedAssetEntry();
                            XtraMessageBox.Show(
                                string.Format(ResourceHelper.GetResourceValueByName("ResOpenFixedAssetNew")),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            Close();
                        }
                    }

                    else if (ActionMode == ActionModeEnum.Edit)
                    {
                        DialogResult dialogResult =
                        XtraMessageBox.Show("Bạn có muốn thay đổi thông tin số dư đầu kỳ tài sản này không",
                            "Ghi số dư đầu kỳ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.OK)
                        {
                            if (CheckBookLock(dtUsedDate.DateTime, "Bạn không thể ghi dư đầu kỳ khi khóa sổ"))
                                return Int32.MaxValue;

                            PostOpeningFixedAssetEntry();
                            XtraMessageBox.Show(
                                string.Format(ResourceHelper.GetResourceValueByName("ResOpenFixedAssetEdit")),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            Close();
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("IX_FixedAsset_FixedAssetCode"))
                {
                    XtraMessageBox.Show(
                        string.Format(ResourceHelper.GetResourceValueByName("ResFixedAssetAlreadyExists"),
                            FixedAssetCode), ResourceHelper.GetResourceValueByName("ResDetailContent"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtFixedAssetCode.Focus();
                }
                else
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResDetailContent"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return int.Parse(_keyForSend);
        }

        protected override void InitControls()
        {
            grdFixedAssetCurrency.ForceInitialize();
            txtFixedAssetCode.Focus();
            _calcEditExchangeRate = new RepositoryItemCalcEdit();
            _calcEditExchangeRate.Mask.MaskType = MaskType.Numeric;
            _calcEditExchangeRate.Mask.EditMask = @"F" + _dbOptionHelper.ExchangeRateDecimalDigits;
            _calcEditExchangeRate.Mask.Culture = Thread.CurrentThread.CurrentCulture;
            _calcEditExchangeRate.Mask.UseMaskAsDisplayFormat = true;
            _calcEditExchangeRate.ReadOnly = true;
            _cboCurrencyCode = new RepositoryItemComboBox();
            if (ActionMode == ActionModeEnum.AddNew)
                cboState.SelectedIndex = 1;
            grdLookupExpenseAccount.Visible = false;
        }

        #endregion

        #region Functions

        private void CalculateDepreciation(DateTime startDateTimeDb)
        {
            try
            {
                int depreciationMonth = dtDepreciationDate.DateTime.Month;
                int depreciationYear = dtDepreciationDate.DateTime.Year;
                decimal ogrPrice = txtOrgPrice.Value;
                decimal depreciationRate = txtDepreciationRate.Value;

                int usingYear = startDateTimeDb.Year - depreciationYear;
                int usingMonth = (12 - (depreciationMonth - 1)) + (usingYear - 1) * 12;

                decimal accumDepreciationAmount;
                decimal remainingAmount;
                if (usingYear <= 0)
                {
                    accumDepreciationAmount = 0;
                    remainingAmount = ogrPrice;
                }
                else
                {
                    if (usingYear >= txtLifeTime.Value)
                    {
                        accumDepreciationAmount = ogrPrice;
                        remainingAmount = 0;
                    }
                    else
                    {
                        accumDepreciationAmount = Math.Round((ogrPrice * depreciationRate / 100) / 12 * usingMonth, 2);
                        remainingAmount = ogrPrice - accumDepreciationAmount;
                    }
                }
                txtAccumDepreciationAmount.Value = accumDepreciationAmount;
                txtRemainingAmount.Value = remainingAmount;
                txtAnnualDepreciationAmount.Value = Math.Round((ogrPrice * depreciationRate / 100), 2);
                if (txtExchangeRate.Value <= 0) return;

                txtAccumDepreciationAmountUSD.Value = Math.Round(txtAccumDepreciationAmount.Value / txtExchangeRate.Value, 2);
                txtAnnualDepreciationAmountUSD.Value = Math.Round(txtAnnualDepreciationAmount.Value / txtExchangeRate.Value, 2);
                txtRemainingAmountUSD.Value = Math.Round(txtRemainingAmount.Value / txtExchangeRate.Value, 2);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculateOrgPrice()
        {
            try
            {
                txtOrgPrice.Value = txtUnitPrice.Value * txtQuantity.Value;
                if (txtExchangeRate.Value <= 0) return;
                txtOrgPriceUSD.Value = Math.Round(txtOrgPrice.Value / txtExchangeRate.Value, 2);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculateExchangeAmount()
        {
            if (txtExchangeRate.Value <= 0) return;
            txtUnitPriceUSD.Value = Math.Round(txtUnitPrice.Value / txtExchangeRate.Value, 2);
            txtAccumDepreciationAmountUSD.Value = Math.Round(txtAccumDepreciationAmount.Value / txtExchangeRate.Value, 2);
            txtAnnualDepreciationAmountUSD.Value = Math.Round(txtAnnualDepreciationAmount.Value / txtExchangeRate.Value, 2);
            txtOrgPriceUSD.Value = Math.Round(txtOrgPrice.Value / txtExchangeRate.Value, 2);
            txtRemainingAmountUSD.Value = Math.Round(txtRemainingAmount.Value / txtExchangeRate.Value, 2);
        }

        private bool CheckFixedAsset()
        {
            FixedAssetModel fixedAsset = _fixedAssetPresenter.DisplayInFaIncreamnet(KeyValue);
            if (fixedAsset == null) return false;
            return true;
        }

        private string GeneratedBaseRefNo(int refTypeId, string currencyCode)
        {
            //lay ra ma so voucher theo reftype
            string refNo = "";
            _autoNumberPresenter.DisplayByRefType(refTypeId);
            if (!String.IsNullOrEmpty(Prefix))
                refNo += Prefix;
            if (currencyCode == GlobalVariable.CurrencyMain)
            {
                if (Value >= 0)
                {
                    for (int i = 0; i < (LengthOfValue - Value.ToString(CultureInfo.InvariantCulture).Length); i++)
                        refNo += "0";
                    refNo += (Value); //(Value + 1);
                }
            }
            else
            {
                if (ValueLocalCurency >= 0)
                {
                    for (int i = 0; i < (LengthOfValue - ValueLocalCurency.ToString(CultureInfo.InvariantCulture).Length); i++)
                        refNo += "0";
                    refNo += (ValueLocalCurency); //(ValueLocalCurency + 1);
                }
            }
            if (!String.IsNullOrEmpty(Suffix))
                refNo += Suffix;
            return refNo + "-" + currencyCode;
        }

        private void GeneratedBaseRefNo()
        {
            //lay ra ma so voucher theo reftype
            BaseRefNo = "";
            int refTypeId = 10;
            if (!DesignMode)
            {
                if (ActionMode == ActionModeEnum.AddNew)
                {
                    _autoNumberPresenter.DisplayByRefType(refTypeId);

                    if (!String.IsNullOrEmpty(Prefix))
                    {
                        BaseRefNo += Prefix;
                    }
                    if (Value >= 0)
                    {
                        for (int i = 0; i < (LengthOfValue - Value.ToString(CultureInfo.InvariantCulture).Length); i++)
                            BaseRefNo += "0";
                        BaseRefNo += (Value);
                    }
                    if (!String.IsNullOrEmpty(Suffix)) BaseRefNo += Suffix;
                    if (!String.IsNullOrEmpty(BaseRefNo)) txtFixedAssetCode.Text = BaseRefNo;
                }
            }
        }

        private void DisplayAccountByCurrency(List<string> lstCurrencyCodes)
        {
            if (lstCurrencyCodes == null || lstCurrencyCodes.Count == 0) return;

            var lstAccounts = _lstCapitalAccounts.Where(w => string.IsNullOrEmpty(w.CurrencyCode) || lstCurrencyCodes.Contains(w.CurrencyCode))?.ToList() ?? new List<AccountModel>();
            GridLookUpItem.Account(lstAccounts, lookUpCapitalAccount, lookUpCapitalAccountView, "AccountCode", "AccountCode");
        }

        #endregion

        #region Combobox Members

        public IList<AccountModel> Accounts
        {
            set
            {
                _lstCapitalAccounts = value.Where(c => (c.AccountCode == "11121" || c.AccountCode == "11122" || c.AccountCode == "11221" || c.AccountCode == "11222" || c.AccountCode == "141" || c.AccountCode == "3371") && c.IsDetail.Equals(true)).ToList();

                var capitalAccount = value.Where(c => c.AccountCode == "36611" || c.AccountCode == "36631").ToList();
                var depreciationAccount = value.Where(c => c.AccountCode.StartsWith("214")).ToList();
                var orgPriceAccount = value.Where(c => c.AccountCode.StartsWith("211") || c.AccountCode.StartsWith("213")).ToList();
                var expenseAccount = value.Where(c => c.AccountCode == "61113" || c.AccountCode == "61123").ToList();
                var capitalAccounts = value.Where(c => (c.AccountCode == "11121" || c.AccountCode == "11122" || c.AccountCode == "11221" || c.AccountCode == "11222" || c.AccountCode == "141" || c.AccountCode == "3371") && c.IsDetail.Equals(true)).ToList();
                var armortizationAccount = value.Where(w => w.AccountCode == "6111" || w.AccountCode == "6112").ToList();

                GridLookUpItem.Account(capitalAccount, grdLookUpCapitalAccount, grdLookUpCapitalAccountView, "AccountCode", "AccountCode");
                GridLookUpItem.Account(depreciationAccount, grdLookUpDepreciationAccount, grdLookUpDepreciationAccountView, "AccountCode", "AccountCode");
                GridLookUpItem.Account(orgPriceAccount, grdLookUpOrgPriceAccount, grdLookUpOrgPriceAccountView, "AccountCode", "AccountCode");
                GridLookUpItem.Account(expenseAccount, grdLookupExpenseAccount, grdLookupExpenseAccountView, "AccountCode", "AccountCode");
                GridLookUpItem.Account(capitalAccounts, lookUpCapitalAccount, lookUpCapitalAccountView, "AccountCode", "AccountCode");
                GridLookUpItem.Account(armortizationAccount, gridLookUpArmortizationAccount, gridLookUpArmortizationAccountView, "AccountCode", "AccountCode");
            }
        }

        public IList<BudgetSourceModel> BudgetSources
        {
            set
            {
                if (value == null)
                    value = new List<BudgetSourceModel>();
                else
                    value = value.Where(x => x.IsFund == true && x.IsParent == false).ToList() ?? new List<BudgetSourceModel>();
                GridLookUpItem.BudgetSource(value, grdLookUpBudgetSource, grdLookUpBudgetSourceView, "BudgetSourceCode", "BudgetSourceCode");
            }
        }

        public IList<CurrencyModel> Currencies
        {
            set
            {
                grdLookUpCurrency.Properties.DataSource = value;
                grdLookUpCurrency.Properties.ForceInitialize();
                grdLookUpCurrency.Properties.PopulateColumns();

                var treeColumnsCollection = new List<XtraColumn>
                {
                    new XtraColumn {ColumnName = "CurrencyId", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "CurrencyCode",
                        ColumnCaption = "Mã tiền tệ",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 70,
                        Alignment = HorzAlignment.Center
                    },
                    new XtraColumn
                    {
                        ColumnName = "CurrencyName",
                        ColumnCaption = "Tên tiền tệ",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 350
                    },
                    new XtraColumn {ColumnName = "Prefix", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Suffix", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsMain", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsActive", ColumnVisible = false}
                };

                foreach (XtraColumn column in treeColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        grdLookUpCurrency.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        grdLookUpCurrency.Properties.SortColumnIndex = column.ColumnPosition;
                    }
                    else grdLookUpCurrency.Properties.Columns[column.ColumnName].Visible = false;
                }
                grdLookUpCurrency.Properties.DisplayMember = "CurrencyCode";
                grdLookUpCurrency.Properties.ValueMember = "CurrencyCode";


                _repositoryItemGridLookUpCurrency.DataSource = value;// value;
                _repositoryItemGridLookUpCurrency.PopulateViewColumns();
                var colColection = new List<XtraColumn>()
                {
                    new XtraColumn { ColumnName = "CurrencyId", ColumnVisible = false },
                    new XtraColumn
                    {
                        ColumnName = "CurrencyCode",
                        ColumnCaption = "Mã tiền tệ",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 70,
                        Alignment = HorzAlignment.Center
                    },
                    new XtraColumn
                    {
                        ColumnName = "CurrencyName",
                        ColumnCaption = "Tên tiền tệ",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 350
                    },
                    new XtraColumn { ColumnName = "Prefix", ColumnVisible = false },
                    new XtraColumn { ColumnName = "Suffix", ColumnVisible = false },
                    new XtraColumn { ColumnName = "IsMain", ColumnVisible = false },
                    new XtraColumn { ColumnName = "IsActive", ColumnVisible = false }
                };

                foreach (var column in colColection)
                {
                    if (column.ColumnVisible)
                    {
                        _repositoryItemGridLookUpCurrency.View.Columns[column.ColumnName].ToolTip = column.ToolTip;
                        _repositoryItemGridLookUpCurrency.View.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        _repositoryItemGridLookUpCurrency.View.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                        _repositoryItemGridLookUpCurrency.View.Columns[column.ColumnName].Width = column.ColumnWith;
                    }
                    else
                        _repositoryItemGridLookUpCurrency.View.Columns[column.ColumnName].Visible = false;
                }
                _repositoryItemGridLookUpCurrency.View.OptionsView.ShowIndicator = false;
                _repositoryItemGridLookUpCurrency.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                _repositoryItemGridLookUpCurrency.DisplayMember = "CurrencyCode";
                _repositoryItemGridLookUpCurrency.ValueMember = "CurrencyCode";
                _repositoryItemGridLookUpCurrency.NullText = string.Empty;
            }
        }

        public IList<DepartmentModel> Departments
        {
            set
            {
                GridLookUpItem.Department(value, grdLookUpDepartment, grdLookUpDepartmentView, "DepartmentName", "DepartmentId");
            }
        }

        public IList<EmployeeModel> Employees
        {
            set
            {
                GridLookUpItem.Employee(value, grdlookUpEmployee, grdlookUpEmployeeView, "EmployeeName", "EmployeeId");
            }
        }

        public IList<BudgetItemModel> BudgetItems
        {
            set
            {
                GridLookUpItem.BudgetItem(value.Where(w => (w.BudgetItemType == 4 || (w.BudgetItemType == 3 && w.IsShowOnVoucher == true)) && w.IsReceipt == false && w.IsActive == true).ToList(), gridLookUpBudgetItem, gridLookUpBudgetItemView, "BudgetItemCode", "BudgetItemCode");
            }
        }

        // LinhMC: 4/1/2016: bỏ đi 2 dòng Vô hình và hữu hình
        public IList<FixedAssetCategoryModel> FixedAssetCategories
        {
            set
            {
                GridLookUpItem.FixedAssetCategory(value, grdLookUpFixedAssetCategory, grdLookUpFixedAssetCategoryView, "FixedAssetCategoryCode", "FixedAssetCategoryId");
            }
        }

        #endregion

        #region Events

        private void FrmXtraFixedAssetDetail_Load(object sender, EventArgs e)
        {
            _autoNumberPresenter = new AutoNumberPresenter(this);

            if (ActionMode == ActionModeEnum.AddNew)
            {
                btnIncrement.Visible = false;
            }
            else if (ActionMode == ActionModeEnum.Edit)
            {
                bool a = CheckFixedAsset();
                if (a)
                {
                    btnIncrement.Visible = false;
                }
                else if (dtPurchasedDate.DateTime >= DateTime.Parse(GlobalVariable.SystemDate) &&
                         cboState.SelectedIndex == 1)
                {
                    btnIncrement.Visible = true;
                }
                else
                {
                    groupControl3.Visible = true;
                }
                EnableDecresementButton();
            }
            VisibleIncrementButton(_quantityOnHand);

            var fixedAssetCategories = _fixedAssetCategoriesPresenter.GetAllFixedAssetCategories().Where(c => c.FixedAssetCategoryId.Equals(FixedAssetCategoryId)).ToList().FirstOrDefault();
            if (fixedAssetCategories != null)
            {
                object fixedAssetCategory = fixedAssetCategories.FixedAssetCategoryCode;
                var fixedAsset = _fixedAssetPresenter.GetFixedAssetById(KeyValue);
                foreach (var fa in fixedAsset.FixedAssetCurrencies)
                {
                    if (fixedAssetCategory.Equals("10"))
                    {
                        chkIsBussiness.Visible = false;
                        chkIsStateManagement.Visible = false;
                    }

                    else
                    {
                        if (fa.UnitPriceUSD >= 30000 || ((fixedAssetCategory != null && fixedAssetCategory.ToString().Length > 3) ? fixedAssetCategory.ToString().Substring(0, 3) == "031" : 1 == 0))
                        {
                            chkIsBussiness.Visible = true;
                            chkIsStateManagement.Visible = true;
                        }
                        else
                        {
                            chkIsBussiness.Visible = false;
                            chkIsStateManagement.Visible = false;
                        }
                    }
                }
            }
        }

        private void grdFixedAssetCurrencyView_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                GridColumn currencyCodeCol = grdFixedAssetCurrencyView.Columns["CurrencyCode"];
                GridColumn exchangeRateCol = grdFixedAssetCurrencyView.Columns["ExchangeRate"];
                GridColumn unitPriceCol = grdFixedAssetCurrencyView.Columns["UnitPrice"];
                GridColumn unitPriceUSDCol = grdFixedAssetCurrencyView.Columns["UnitPriceUSD"];
                GridColumn orgPriceCol = grdFixedAssetCurrencyView.Columns["OrgPrice"];
                GridColumn orgPriceUSDCol = grdFixedAssetCurrencyView.Columns["OrgPriceUSD"];
                GridColumn accumDepreciationAmountCol = grdFixedAssetCurrencyView.Columns["AccumDepreciationAmount"];
                GridColumn accumDepreciationAmountUSDCol = grdFixedAssetCurrencyView.Columns["AccumDepreciationAmountUSD"];
                GridColumn remainingAmountCol = grdFixedAssetCurrencyView.Columns["RemainingAmount"];
                GridColumn remainingAmountUSDCol = grdFixedAssetCurrencyView.Columns["RemainingAmountUSD"];
                GridColumn annualDepreciationAmountCol = grdFixedAssetCurrencyView.Columns["AnnualDepreciationAmount"];
                GridColumn annualDepreciationAmountUSDCol =
                    grdFixedAssetCurrencyView.Columns["AnnualDepreciationAmountUSD"];

                switch (e.Column.FieldName)
                {
                    case "CurrencyCode":
                        var currencyCode = (string)grdFixedAssetCurrencyView.GetRowCellValue(e.RowHandle, currencyCodeCol);
                        if (currencyCode.Equals("USD"))
                        {
                            grdFixedAssetCurrencyView.SetRowCellValue(e.RowHandle, exchangeRateCol, 1);
                        }
                        break;
                    case "ExchangeRate": //ti le 
                        //quy doi
                        grdFixedAssetCurrencyView.SetRowCellValue(e.RowHandle, unitPriceUSDCol, decimal.Parse(grdFixedAssetCurrencyView.GetRowCellValue(e.RowHandle, unitPriceCol).ToString()) / decimal.Parse(e.Value.ToString()));
                        grdFixedAssetCurrencyView.SetRowCellValue(e.RowHandle, orgPriceUSDCol, decimal.Parse(grdFixedAssetCurrencyView.GetRowCellValue(e.RowHandle, orgPriceCol).ToString()) / decimal.Parse(e.Value.ToString()));
                        grdFixedAssetCurrencyView.SetRowCellValue(e.RowHandle, accumDepreciationAmountUSDCol, decimal.Parse(grdFixedAssetCurrencyView.GetRowCellValue(e.RowHandle, accumDepreciationAmountCol).ToString()) / decimal.Parse(e.Value.ToString()));
                        grdFixedAssetCurrencyView.SetRowCellValue(e.RowHandle, annualDepreciationAmountUSDCol, decimal.Parse(grdFixedAssetCurrencyView.GetRowCellValue(e.RowHandle, annualDepreciationAmountCol).ToString()) / decimal.Parse(e.Value.ToString()));
                        break;
                    case "UnitPrice": //don gia
                        grdFixedAssetCurrencyView.SetRowCellValue(e.RowHandle, orgPriceCol, (decimal)e.Value * (decimal)txtQuantity.EditValue);

                        //quy doi
                        grdFixedAssetCurrencyView.SetRowCellValue(e.RowHandle, unitPriceUSDCol, (decimal)e.Value / decimal.Parse(grdFixedAssetCurrencyView.GetRowCellValue(e.RowHandle, exchangeRateCol).ToString()));
                        break;
                    case "OrgPrice": //nguyen gia
                        int depreciationMonth = dtDepreciationDate.DateTime.Month;
                        int depreciationYear = dtDepreciationDate.DateTime.Year;
                        decimal ogrPrice = decimal.Parse(grdFixedAssetCurrencyView.GetRowCellValue(e.RowHandle, orgPriceCol).ToString());
                        decimal depreciationRate = txtDepreciationRate.Value;

                        int usingYear = DateTime.Parse(GlobalVariable.StartedDate).Year - depreciationYear;
                        int usingMonth = (12 - (depreciationMonth - 1)) + (usingYear - 1) * 12;

                        decimal accumDepreciationAmount;
                        if (usingYear <= 0)
                            accumDepreciationAmount = 0;

                        else
                            accumDepreciationAmount = usingYear >= txtLifeTime.Value ? ogrPrice : Math.Round((ogrPrice * depreciationRate / 100) / 12 * usingMonth, 2);
                        grdFixedAssetCurrencyView.SetRowCellValue(e.RowHandle, accumDepreciationAmountCol, accumDepreciationAmount);
                        grdFixedAssetCurrencyView.SetRowCellValue(e.RowHandle, remainingAmountCol, (decimal)e.Value - decimal.Parse(grdFixedAssetCurrencyView.GetRowCellValue(e.RowHandle, accumDepreciationAmountCol).ToString()));
                        grdFixedAssetCurrencyView.SetRowCellValue(e.RowHandle, annualDepreciationAmountCol, (decimal)e.Value * decimal.Parse(txtDepreciationRate.EditValue.ToString()) / 100);

                        //quy doi
                        grdFixedAssetCurrencyView.SetRowCellValue(e.RowHandle, orgPriceUSDCol, (decimal)e.Value / decimal.Parse(grdFixedAssetCurrencyView.GetRowCellValue(e.RowHandle, exchangeRateCol).ToString()));
                        break;
                    case "AccumDepreciationAmount": //khau hao luy ke
                        //var ogrPrice1 = decimal.Parse(grdFixedAssetCurrencyView.GetRowCellValue(e.RowHandle, orgPriceCol).ToString());
                        //var remainingAmount1 = decimal.Parse(grdFixedAssetCurrencyView.GetRowCellValue(e.RowHandle, remainingAmountCol).ToString());
                        //decimal accumDepreciationAmount1 = ogrPrice1 - remainingAmount1;
                        //grdFixedAssetCurrencyView.SetRowCellValue(e.RowHandle, accumDepreciationAmountCol, accumDepreciationAmount1);


                        grdFixedAssetCurrencyView.SetRowCellValue(e.RowHandle, remainingAmountCol, decimal.Parse(grdFixedAssetCurrencyView.GetRowCellValue(e.RowHandle, orgPriceCol).ToString()) - (decimal)e.Value);
                        //quy doi 
                        grdFixedAssetCurrencyView.SetRowCellValue(e.RowHandle, accumDepreciationAmountUSDCol, (decimal)e.Value / decimal.Parse(grdFixedAssetCurrencyView.GetRowCellValue(e.RowHandle, exchangeRateCol).ToString()));
                        break;
                    case "RemainingAmount": //gia tri con lai
                        //grdFixedAssetCurrencyView.SetRowCellValue(e.RowHandle, accumDepreciationAmountCol,
                        //    decimal.Parse(grdFixedAssetCurrencyView.GetRowCellValue(e.RowHandle, orgPriceCol).ToString()) - (decimal)e.Value);

                        //quy doi
                        grdFixedAssetCurrencyView.SetRowCellValue(e.RowHandle, remainingAmountUSDCol, (decimal)e.Value / decimal.Parse(grdFixedAssetCurrencyView.GetRowCellValue(e.RowHandle, exchangeRateCol).ToString()));

                        if (dtPurchasedDate.DateTime >= DateTime.Parse(GlobalVariable.SystemDate) && cboState.SelectedIndex == 2)
                        {
                            btnIncrement.Visible = true;
                        }
                        break;
                    case "AnnualDepreciationAmount": //hao mon hang nam
                        //quy doi
                        grdFixedAssetCurrencyView.SetRowCellValue(e.RowHandle, annualDepreciationAmountUSDCol, (decimal)e.Value / decimal.Parse(grdFixedAssetCurrencyView.GetRowCellValue(e.RowHandle, exchangeRateCol).ToString()));
                        break;
                    case "UnitPriceUSD": //Đơn giá quy đổi

                        grdFixedAssetCurrencyView.SetRowCellValue(e.RowHandle, orgPriceUSDCol, (decimal)e.Value * (decimal)txtQuantity.EditValue);
                        break;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grdFixedAssetCurrencyView_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            try
            {
                GridColumn currencyCodeCol = grdFixedAssetCurrencyView.Columns["CurrencyCode"];
                GridColumn exchangeRateCol = grdFixedAssetCurrencyView.Columns["ExchangeRate"];
                GridColumn unitPriceCol = grdFixedAssetCurrencyView.Columns["UnitPrice"];

                var currencyCode = (string)grdFixedAssetCurrencyView.GetRowCellValue(e.RowHandle, currencyCodeCol);
                var exchangeRate = (float)grdFixedAssetCurrencyView.GetRowCellValue(e.RowHandle, exchangeRateCol);
                var unitPrice = (decimal)grdFixedAssetCurrencyView.GetRowCellValue(e.RowHandle, unitPriceCol);
                if (string.IsNullOrEmpty(currencyCode))
                {
                    e.Valid = false;
                    grdFixedAssetCurrencyView.SetColumnError(currencyCodeCol, ResourceHelper.GetResourceValueByName("ResFixedAssetCurrencyFixedAssetCurrency"));
                }
                else
                {
                    if (!currencyCode.Equals("USD"))
                    {
                        if (exchangeRate.Equals(1))
                        {
                            e.Valid = false;
                            grdFixedAssetCurrencyView.SetColumnError(exchangeRateCol, ResourceHelper.GetResourceValueByName("ResFixedAssetCurrencyExchangeRateLessOne"));
                        }
                    }
                    else if (currencyCode.Equals("USD"))
                    {
                        if (!exchangeRate.Equals(1))
                        {
                            e.Valid = false;
                            grdFixedAssetCurrencyView.SetColumnError(exchangeRateCol, ResourceHelper.GetResourceValueByName("ResFixedAssetCurrencyExchangeRateLessOne"));
                        }
                    }
                }
                if (unitPrice <= 0)
                {
                    e.Valid = false;
                    grdFixedAssetCurrencyView.SetColumnError(currencyCodeCol, ResourceHelper.GetResourceValueByName("ResFixedAssetCurrencyUnitPrice"));
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grdFixedAssetCurrencyView_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void cboState_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ActionMode == ActionModeEnum.AddNew)
            {
                btnIncrement.Visible = false;
            }
            else
            {
                bool a = CheckFixedAsset();
                if (a)
                    btnIncrement.Visible = false;
                else if (dtPurchasedDate.DateTime >= DateTime.Parse(GlobalVariable.SystemDate) && cboState.SelectedIndex == 1)
                    btnIncrement.Visible = true;
                else
                    btnIncrement.Visible = false;
            }
            EnableDecresementButton();
            VisibleIncrementButton(_quantityOnHand);
        }

        private void txtDepreciationRate_EditValueChanged(object sender, EventArgs e)
        {
            CalculateDepreciation(DateTime.Parse(GlobalVariable.StartedDate));
        }

        private void txtLifeTime_EditValueChanged(object sender, EventArgs e)
        {
            CalculateDepreciation(DateTime.Parse(GlobalVariable.StartedDate));
        }

        private void txtQuantity_EditValueChanged(object sender, EventArgs e)
        {
            //CalculateOrgPrice();
            GridColumn unitPriceCol = grdFixedAssetCurrencyView.Columns["UnitPrice"];
            GridColumn orgPriceCol = grdFixedAssetCurrencyView.Columns["OrgPrice"];
            if (grdFixedAssetCurrency.DataSource == null || grdFixedAssetCurrencyView.RowCount <= 0) return;
            for (int i = 0; i < grdFixedAssetCurrencyView.RowCount; i++)
            {
                if (grdFixedAssetCurrencyView.GetRow(i) == null) continue;
                grdFixedAssetCurrencyView.SetRowCellValue(i, orgPriceCol, (decimal)txtQuantity.EditValue * decimal.Parse(grdFixedAssetCurrencyView.GetRowCellValue(i, unitPriceCol).ToString()));
            }
            vGridControl1.GetCellValue(vGridControl1.Rows.GetRowByFieldName("ExchangeRate"), vGridControl1.FocusedRecord);
        }

        private void txtExchangeRate_EditValueChanged(object sender, EventArgs e)
        {
            CalculateExchangeAmount();
        }

        private void txtUnitPrice_EditValueChanged(object sender, EventArgs e)
        {
            if (txtExchangeRate.Value > 0)
            {
                txtUnitPriceUSD.Value = Math.Round(txtUnitPrice.Value / txtExchangeRate.Value, 2);
            }
            CalculateOrgPrice();
            CalculateDepreciation(DateTime.Parse(GlobalVariable.StartedDate));
        }

        private void txtOrgPrice_EditValueChanged(object sender, EventArgs e)
        {
            if (txtExchangeRate.Value <= 0) return;
            txtOrgPriceUSD.Value = Math.Round(txtOrgPrice.Value / txtExchangeRate.Value, 2);
            CalculateDepreciation(DateTime.Parse(GlobalVariable.StartedDate));
        }

        private void txtAccumDepreciationAmount_EditValueChanged(object sender, EventArgs e)
        {
            if (txtExchangeRate.Value <= 0) return;
            txtAccumDepreciationAmountUSD.Value = Math.Round(txtAccumDepreciationAmount.Value / txtExchangeRate.Value, 2);
            txtRemainingAmount.Value = txtOrgPrice.Value - txtAccumDepreciationAmount.Value;
            txtRemainingAmountUSD.Value = txtOrgPriceUSD.Value - txtAccumDepreciationAmountUSD.Value;
        }

        private void txtRemainingAmount_EditValueChanged(object sender, EventArgs e)
        {
            if (txtExchangeRate.Value <= 0) return;
            txtRemainingAmountUSD.Value = Math.Round(txtRemainingAmount.Value / txtExchangeRate.Value, 2);
            txtAccumDepreciationAmount.Value = txtOrgPrice.Value - txtRemainingAmount.Value;
            txtAccumDepreciationAmountUSD.Value = txtOrgPriceUSD.Value - txtRemainingAmountUSD.Value;
        }

        private void txtAnnualDepreciationAmount_EditValueChanged(object sender, EventArgs e)
        {
            if (txtExchangeRate.Value <= 0) return;
            txtAnnualDepreciationAmountUSD.Value = Math.Round(txtAnnualDepreciationAmount.Value / txtExchangeRate.Value, 2);
        }

        private void grdLookUpDepartment_EditValueChanged(object sender, EventArgs e)
        {
            _employeesPresenter.DisplayActiveByDepartment(DepartmentId);
        }

        private void dtPurchasedDate_EditValueChanged(object sender, EventArgs e)
        {
            if (ActionMode == ActionModeEnum.AddNew)
            {
                btnIncrement.Visible = false;
            }
            else
            {
                bool a = CheckFixedAsset();
                if (a)
                    btnIncrement.Visible = false;
                else if (dtPurchasedDate.DateTime >= DateTime.Parse(GlobalVariable.SystemDate) && cboState.SelectedIndex == 1)
                    btnIncrement.Visible = true;
                else
                    btnIncrement.Visible = false;
            }
            dtUsedDate.DateTime = dtPurchasedDate.DateTime;

            if (dtPurchasedDate.DateTime.Year >= 2013)
            {
                dtDepreciationDate.DateTime = DateTime.Parse(dtPurchasedDate.DateTime.Year + "/1/1");
            }
            else
            {
                dtDepreciationDate.DateTime = DateTime.Parse(dtPurchasedDate.DateTime.Year + 1 + "/1/1");
            }
            VisibleIncrementButton(_quantityOnHand);
        }

        private void dtDepreciationDate_EditValueChanged(object sender, EventArgs e)
        {
            //CalculateDepreciation(DateTime.Parse(GlobalVariable.StartedDate));
            int depreciationMonth = dtDepreciationDate.DateTime.Month;
            int depreciationYear = dtDepreciationDate.DateTime.Year;
            decimal depreciationRate = txtDepreciationRate.Value;
            int usingYear = DateTime.Parse(GlobalVariable.StartedDate).Year - depreciationYear;
            int usingMonth = (12 - (depreciationMonth - 1)) + (usingYear - 1) * 12;
            GridColumn accumDepreciationAmountCol = grdFixedAssetCurrencyView.Columns["AccumDepreciationAmount"];
            GridColumn orgPriceCol = grdFixedAssetCurrencyView.Columns["OrgPrice"];

            if (grdFixedAssetCurrency.DataSource == null || grdFixedAssetCurrencyView.RowCount <= 0) return;
            for (int i = 0; i < grdFixedAssetCurrencyView.RowCount; i++)
            {
                if (grdFixedAssetCurrencyView.GetRow(i) == null) continue;
                decimal accumDepreciationAmount;
                decimal ogrPrice = decimal.Parse(grdFixedAssetCurrencyView.GetRowCellValue(i, orgPriceCol).ToString());
                if (usingYear <= 0)
                    accumDepreciationAmount = 0;
                else
                    accumDepreciationAmount = usingYear >= txtLifeTime.Value
                        ? ogrPrice
                        : Math.Round((ogrPrice * depreciationRate / 100) / 12 * usingMonth, 2);
                grdFixedAssetCurrencyView.SetRowCellValue(i, accumDepreciationAmountCol, accumDepreciationAmount);
            }
        }

        private void grdLookUpFixedAssetCategory_EditValueChanged(object sender, EventArgs e)
        {
            var fixedAssetCategory = (FixedAssetCategoryModel)grdLookUpFixedAssetCategory.GetSelectedDataRow();
            if (fixedAssetCategory != null)
            {
                txtLifeTime.Value = fixedAssetCategory.LifeTime;
                txtDepreciationRate.Value = fixedAssetCategory.DepreciationRate;
                grdLookUpDepreciationAccount.EditValue = fixedAssetCategory.DepreciationAccountCode;
                grdLookUpCapitalAccount.EditValue = fixedAssetCategory.CapitalAccountCode;
                grdLookUpOrgPriceAccount.EditValue = fixedAssetCategory.OrgPriceAccountCode;
                Unit = fixedAssetCategory.Unit;
            }
            else
            {
                txtLifeTime.Value = 0;
                txtDepreciationRate.Value = 0;
                grdLookUpDepreciationAccount.EditValue = "";
                grdLookUpCapitalAccount.EditValue = "";
                grdLookUpOrgPriceAccount.EditValue = "";
                Unit = "";
            }

            string fixedAssetCategoryCode = grdLookUpFixedAssetCategory.Text;
            if (String.IsNullOrEmpty(fixedAssetCategoryCode)) return;
            if (fixedAssetCategoryCode.Length == 2)
            {
                tabRegisterInfo.TabControl.TabPages[3].PageVisible = false;
                chkIsStateManagement.Visible = false;
                chkIsBussiness.Visible = false;
            }
            else
            {
                if (fixedAssetCategoryCode.Length >= 3 && fixedAssetCategoryCode.StartsWith("03"))//AnhNT: fix theo yêu cầu BA, tài sản là xe, thì show tab 4
                {
                    tabRegisterInfo.TabControl.TabPages[3].PageVisible = true;
                    chkIsStateManagement.Visible = true;
                    chkIsBussiness.Visible = true;
                    groupControl4.Enabled = false;
                    groupControl5.Enabled = true;
                }
                else if (fixedAssetCategoryCode.Length >= 3 && fixedAssetCategoryCode.StartsWith("01"))
                {
                    tabRegisterInfo.TabControl.TabPages[3].PageVisible = true;
                    chkIsStateManagement.Visible = true;
                    chkIsBussiness.Visible = true;
                    groupControl4.Enabled = true;
                    groupControl5.Enabled = false;
                }

                //else if (fixedAssetCategoryCode.Substring(0, 2) != "11" || (fixedAssetCategoryCode.Length >= 4 && fixedAssetCategoryCode.Substring(0, 4) == "1104"))
                //{
                //    if (fixedAssetCategoryCode.Length >= 4 && fixedAssetCategoryCode.Substring(0, 2) != "01" && fixedAssetCategoryCode.Substring(0, 3) != "031" && fixedAssetCategoryCode.Substring(0, 4) != "1104")
                //    {
                //        tabRegisterInfo.TabControl.TabPages[3].PageVisible = false;
                //        chkIsStateManagement.Visible = false;
                //        chkIsBussiness.Visible = false;
                //    }

                //    else
                //    {
                //        tabRegisterInfo.TabControl.TabPages[3].PageVisible = true;
                //        if (fixedAssetCategoryCode.Length >= 4 && fixedAssetCategoryCode.Substring(0, 2) != "01" && fixedAssetCategoryCode.Substring(0, 4) != "1104")
                //        {
                //            groupControl4.Enabled = false;
                //            groupControl5.Enabled = true;
                //            chkIsStateManagement.Visible = true;
                //            chkIsBussiness.Visible = true;
                //        }
                //        else
                //        {
                //            groupControl4.Enabled = true;
                //            groupControl5.Enabled = false;
                //            chkIsStateManagement.Visible = false;
                //            chkIsBussiness.Visible = false;
                //        }
                //    }
                //}
                else
                {
                    tabRegisterInfo.TabControl.TabPages[3].PageVisible = false;
                }
            }
        }

        private void grdLookUpFixedAssetCategoryView_MouseDown(object sender, MouseEventArgs e)
        {
            var view = sender as GridView;
            if (view != null)
            {
                GridHitInfo hitInfo = view.CalcHitInfo(e.Location);
                bool isParent = false;
                if ((FixedAssetCategoryModel)grdLookUpFixedAssetCategory.GetSelectedDataRow() != null)
                {
                    isParent = ((FixedAssetCategoryModel)grdLookUpFixedAssetCategory.GetSelectedDataRow()).IsParent;
                }

                if (hitInfo.InRow && isParent)
                    ((DXMouseEventArgs)(e)).Handled = true;
            }
        }

        private void grdLookUpCurrency_EditValueChanged(object sender, EventArgs e)
        {
            if (grdLookUpCurrency.Text == GlobalVariable.CurrencyMain)
            {
                txtExchangeRate.Value = 1;
            }
        }

        private void grdFixedAssetCurrencyView_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            var view = sender as GridView;
            if (view != null)
            {
                GridHitInfo hitInfo = view.CalcHitInfo(e.Point);
                if (hitInfo.InRow)
                {
                    view.FocusedRowHandle = hitInfo.RowHandle;
                    popupMenu1.ShowPopup(grdFixedAssetCurrency.PointToScreen(e.Point));
                }
            }
        }

        protected virtual void DeleteRowItem()
        {
            grdFixedAssetCurrencyView.DeleteSelectedRows();
        }

        private void barButtonDeleteRowItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            DeleteRowItem();
        }

        private void grdlookUpEmployee_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdlookUpEmployee.SelectionLength == grdlookUpEmployee.Text.Length &&
                (e.KeyData == Keys.Back || e.KeyData == Keys.Delete))
            {
                grdlookUpEmployee.EditValue = null;
                e.Handled = true;
            }
        }

        private void vGridControl1_CellValueChanging(object sender, DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs e)
        {
            _cellIndex = e.CellIndex;
            _recordIndex = e.RecordIndex;
            _rowName = e.Row.Name;
        }

        private void vGridControl1_CellValueChanged(object sender, DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs e)
        {
            // Do chỉ còn 1loaij tiền nên sử dụng luôn như này.
            // Nếu có 2 loại tiền thì phải xử lý khác
            object currencyCode = vGridControl1.GetCellValue(vGridControl1.Rows.GetRowByFieldName("CurrencyCode"), e.RecordIndex);
            if (currencyCode != null)
                DisplayAccountByCurrency(new List<string>() { currencyCode.ToString() });
        }

        private void vGridControl1_KeyUp(object sender, KeyEventArgs e)
        {
            object exchangeRate = vGridControl1.GetCellValue(vGridControl1.Rows.GetRowByFieldName("ExchangeRate"), vGridControl1.FocusedRecord);
            short quantity = Convert.ToInt16(txtQuantity.Value);

            // Khai báo biến tính hao mòn đầu kỳ
            int depreciationMonth = dtDepreciationDate.DateTime.Month;
            int depreciationYear = dtDepreciationDate.DateTime.Year;
            decimal depreciationRate = txtDepreciationRate.Value;
            int usingYear = DateTime.Parse(GlobalVariable.SystemDate).Year - depreciationYear;
            int usingMonth = (12 - (depreciationMonth - 1)) + (usingYear - 1) * 12;

            if (Convert.ToDecimal(exchangeRate) != 0)
            {
                decimal accumDepreciationAmount;
                if (_rowName == "UnitPriceRow")
                {
                    if (_cellIndex > 0) return;
                    // Tính nguyên giá và nguyên giá quy đổi theo đơn giá
                    object propVal = vGridControl1.GetCellValue(_propUnitPrice, _recordIndex);

                    decimal propValExchange = Math.Round((decimal)propVal / Convert.ToDecimal(exchangeRate), int.Parse(_dbOptionHelper.ExchangeRateDecimalDigits));
                    if (propValExchange >= 30000)
                    {
                        chkIsStateManagement.Visible = true;
                        chkIsBussiness.Visible = true;
                    }
                    else
                    {
                        chkIsStateManagement.Visible = false;
                        chkIsBussiness.Visible = false;
                    }
                    decimal orgPrice = (decimal)propVal * Convert.ToDecimal(quantity);
                    decimal orgPriceUSD = Math.Round((decimal)propVal * Convert.ToDecimal(quantity) / Convert.ToDecimal(exchangeRate), int.Parse(_dbOptionHelper.CurrencyDecimalDigits));
                    vGridControl1.SetCellValue(_propUnitPriceExchange, _recordIndex, propValExchange);
                    vGridControl1.SetCellValue(_propOrgPrice, _recordIndex, orgPrice);
                    vGridControl1.SetCellValue(_propOrgPriceExchange, _recordIndex, orgPriceUSD);

                    // Set giá trị hao mòn và GT hao mòn quy đổi theo đơn giá
                    if (usingYear <= 0)
                        accumDepreciationAmount = 0;
                    else
                        accumDepreciationAmount = usingYear >= txtLifeTime.Value ? (decimal)propVal : Math.Round((orgPrice * depreciationRate / 100) / 12 * usingMonth, 2);

                    // Set hao mòn lũy kế đầu kỳ quy đổi theo nguyên giá
                    vGridControl1.SetCellValue(_propAccumulatedDepreciationAmount, _recordIndex, accumDepreciationAmount);
                    vGridControl1.SetCellValue(_propAccumulatedDepreciationAmountExchange, _recordIndex, Math.Round(accumDepreciationAmount / Convert.ToDecimal(exchangeRate), int.Parse(_dbOptionHelper.CurrencyDecimalDigits)));

                    // Set GTCL theo hao mòn lũy kế đầu kỳ vào nguyên giá
                    vGridControl1.SetCellValue(_propRemainingAmount, _recordIndex, orgPrice - accumDepreciationAmount);
                    vGridControl1.SetCellValue(_propRemainingAmountExchange, _recordIndex, Math.Round((orgPrice - accumDepreciationAmount) / Convert.ToDecimal(exchangeRate), int.Parse(_dbOptionHelper.CurrencyDecimalDigits)));
                    // Set hao mòn hàng năm
                    vGridControl1.SetCellValue(_propAnnualDepreciationAmount, _recordIndex, (orgPrice * decimal.Parse(txtDepreciationRate.EditValue.ToString()) / 100));

                    vGridControl1.SetCellValue(_propAnnualDepreciationAmountExchange, _recordIndex, Math.Round((orgPrice * decimal.Parse(txtDepreciationRate.EditValue.ToString()) / 100) / Convert.ToDecimal(exchangeRate), int.Parse(_dbOptionHelper.CurrencyDecimalDigits)));
                }

                if (_rowName == "OrgPriceRow")
                {
                    if (_cellIndex > 0) return;
                    object propVal = vGridControl1.GetCellValue(_propOrgPrice, _recordIndex);
                    decimal propValExchange = Math.Round((decimal)propVal / Convert.ToDecimal(exchangeRate), int.Parse(_dbOptionHelper.CurrencyDecimalDigits));
                    vGridControl1.SetCellValue(_propOrgPriceExchange, _recordIndex, propValExchange);
                    vGridControl1.SetCellValue(_propUnitPrice, _recordIndex, Math.Round((decimal)propVal / Convert.ToDecimal(quantity), int.Parse(_dbOptionHelper.CurrencyDecimalDigits)));

                    // Tính giá trị hao mòn lũy kế đầu kỳ khi thay đổi nguyên giá
                    if (usingYear <= 0)
                        accumDepreciationAmount = 0;
                    else
                        accumDepreciationAmount = usingYear >= txtLifeTime.Value ? (decimal)propVal : Math.Round(((decimal)propVal * depreciationRate / 100) / 12 * usingMonth, int.Parse(_dbOptionHelper.CurrencyDecimalDigits));

                    // Set hao mòn lũy kế đầu kỳ quy đổi theo nguyên giá
                    vGridControl1.SetCellValue(_propAccumulatedDepreciationAmount, _recordIndex, accumDepreciationAmount);

                    // Set GTCL theo hao mòn lũy kế đầu kỳ vào nguyên giá
                    vGridControl1.SetCellValue(_propRemainingAmount, _recordIndex, Math.Round((decimal)propVal - accumDepreciationAmount, int.Parse(_dbOptionHelper.CurrencyDecimalDigits))); vGridControl1.SetCellValue(_propRemainingAmountExchange, _recordIndex, Math.Round(((decimal)propVal - accumDepreciationAmount) / Convert.ToDecimal(exchangeRate), int.Parse(_dbOptionHelper.CurrencyDecimalDigits)));

                    // Set hao mòn hàng năm
                    vGridControl1.SetCellValue(_propAnnualDepreciationAmount, _recordIndex, Math.Round(((decimal)propVal * decimal.Parse(txtDepreciationRate.EditValue.ToString()) / 100), int.Parse(_dbOptionHelper.CurrencyDecimalDigits)));

                    vGridControl1.SetCellValue(_propAnnualDepreciationAmountExchange, _recordIndex, Math.Round(((decimal)propVal * decimal.Parse(txtDepreciationRate.EditValue.ToString()) / 100) / Convert.ToDecimal(exchangeRate), int.Parse(_dbOptionHelper.CurrencyDecimalDigits)));
                }

                if (_rowName == "AccumulatedDepreciationAmountRow")
                {
                    if (_cellIndex > 0) return;
                    object propVal = vGridControl1.GetCellValue(_propAccumulatedDepreciationAmount, _recordIndex);
                    object propOrgPriceVal = vGridControl1.GetCellValue(_propOrgPrice, _recordIndex);
                    decimal propValExchange = Math.Round((decimal)propVal / Convert.ToDecimal(exchangeRate), int.Parse(_dbOptionHelper.CurrencyDecimalDigits));
                    vGridControl1.SetCellValue(_propAccumulatedDepreciationAmountExchange, _recordIndex, propValExchange);
                    vGridControl1.SetCellValue(_propRemainingAmount, _recordIndex, Math.Round((decimal)propOrgPriceVal - (decimal)propVal, int.Parse(_dbOptionHelper.CurrencyDecimalDigits)));
                }

                if (_rowName == "RemainingAmountRow")
                {
                    if (_cellIndex > 0) return;
                    object propVal = vGridControl1.GetCellValue(_propRemainingAmount, _recordIndex);
                    object propOrgPriceVal = vGridControl1.GetCellValue(_propOrgPrice, _recordIndex);
                    decimal propValExchange = Math.Round((decimal)propVal / Convert.ToDecimal(exchangeRate), int.Parse(_dbOptionHelper.CurrencyDecimalDigits));
                    vGridControl1.SetCellValue(_propRemainingAmountExchange, _recordIndex, propValExchange);
                    vGridControl1.SetCellValue(_propAccumulatedDepreciationAmount, _recordIndex, Math.Round((decimal)propOrgPriceVal - (decimal)propVal, int.Parse(_dbOptionHelper.CurrencyDecimalDigits)));
                }

                if (_rowName == "AnnualDepreciationAmountRow")
                {
                    if (_cellIndex > 0) return;
                    object propVal = vGridControl1.GetCellValue(_propAnnualDepreciationAmount, _recordIndex);
                    decimal propValExchange = Math.Round((decimal)propVal / Convert.ToDecimal(exchangeRate), int.Parse(_dbOptionHelper.CurrencyDecimalDigits));
                    vGridControl1.SetCellValue(_propAnnualDepreciationAmountExchange, _recordIndex, propValExchange);
                }

                if (vGridControl1.Rows["rowExchangeRate"].Properties.FieldName == "ExchangeRate")
                {
                    if (_cellIndex > 0) return;
                    object propVal = vGridControl1.GetCellValue(_propUnitPrice, _recordIndex);
                    object annualDepreciationAmountVal = vGridControl1.GetCellValue(_propAnnualDepreciationAmount, _recordIndex);
                    object accumulatedDepreciationAmountVal = vGridControl1.GetCellValue(_propAccumulatedDepreciationAmount, _recordIndex);
                    object remainingAmountVal = vGridControl1.GetCellValue(_propRemainingAmount, _recordIndex);
                    decimal propValExchange = Math.Round((decimal)propVal / Convert.ToDecimal(exchangeRate), int.Parse(_dbOptionHelper.CurrencyDecimalDigits));
                    decimal orgPriceUSD = Math.Round((decimal)propVal * Convert.ToDecimal(quantity) / Convert.ToDecimal(exchangeRate), int.Parse(_dbOptionHelper.CurrencyDecimalDigits));
                    // Set đơn giá, nguyên giá theo tỷ giá
                    vGridControl1.SetCellValue(_propUnitPriceExchange, _recordIndex, propValExchange);
                    //vGridControl1.SetCellValue(_propOrgPrice, _recordIndex, orgPrice);
                    vGridControl1.SetCellValue(_propOrgPriceExchange, _recordIndex, orgPriceUSD);

                    // Set hao mòn hằng năm, hao mòn đầu kỳ, giá trị còn lại theo tỷ giá
                    vGridControl1.SetCellValue(_propAccumulatedDepreciationAmountExchange, _recordIndex, Math.Round((decimal)accumulatedDepreciationAmountVal / Convert.ToDecimal(exchangeRate), int.Parse(_dbOptionHelper.CurrencyDecimalDigits)));
                    vGridControl1.SetCellValue(_propRemainingAmountExchange, _recordIndex, Math.Round((decimal)remainingAmountVal / Convert.ToDecimal(exchangeRate), int.Parse(_dbOptionHelper.CurrencyDecimalDigits)));
                    vGridControl1.SetCellValue(_propAnnualDepreciationAmountExchange, _recordIndex, Math.Round((decimal)annualDepreciationAmountVal / Convert.ToDecimal(exchangeRate), int.Parse(_dbOptionHelper.CurrencyDecimalDigits)));
                }
            }
        }

        private void vGridControl1_InvalidRecordException(object sender, InvalidRecordExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void mnuAddnewRecord_Click(object sender, EventArgs e)
        {
            vGridControl1.BeginUpdate();
            var fixedAssetCurrencyModel = new FixedAssetCurrencyModel();
            fixedAssetCurrencyModel.ExchangeRate = 1;
            fixedAssetCurrencyModel.CurrencyCode = "USD";
            bindingSourceFixedAssetCurrency.Add(fixedAssetCurrencyModel);
            vGridControl1.EndUpdate();
        }

        private void mnuDeleteRecord_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = XtraMessageBox.Show("Bạn có xóa dòng này không!", "Ghi tăng tự động", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.OK && cboState.SelectedIndex == 1) //  Đang xem xét && dtUsedDate.DateTime >= DateTime.Parse(GlobalVariable.SystemDate)
            {
                vGridControl1.DeleteRecord(_recordIndex);
            }
        }

        private void vGridControl1_FocusedRecordChanged(object sender, IndexChangedEventArgs e)
        {
            _recordIndex = e.NewIndex;
        }

        private void cboCurrencyCode_EditValueChanged(object sender, EventArgs e)
        {
            if (cboCurrencyCode.SelectedIndex == 0)
            {
                vGridControl1.BeginUpdate();
                vGridControl1.DeleteRecord(_recordIndex);

                var fixedAssetCurrencyModel = new FixedAssetCurrencyModel();
                fixedAssetCurrencyModel.ExchangeRate = 1;
                fixedAssetCurrencyModel.CurrencyCode = "USD";
                bindingSourceFixedAssetCurrency.Add(fixedAssetCurrencyModel);
                vGridControl1.EndUpdate();
            }

            if (cboCurrencyCode.SelectedIndex == 1)
            {
                vGridControl1.BeginUpdate();
                vGridControl1.DeleteRecord(_recordIndex);
                bindingSourceFixedAssetCurrency.Clear();

                var fixedAssetCurrencyModel = new FixedAssetCurrencyModel();
                fixedAssetCurrencyModel.ExchangeRate = 1;
                fixedAssetCurrencyModel.CurrencyCode = "USD";
                bindingSourceFixedAssetCurrency.Add(fixedAssetCurrencyModel);

                var fixedAssetCurrencyModel2 = new FixedAssetCurrencyModel();
                fixedAssetCurrencyModel2.ExchangeRate = 1;
                fixedAssetCurrencyModel2.CurrencyCode = GlobalVariable.CurrencyMain;


                bindingSourceFixedAssetCurrency.Add(fixedAssetCurrencyModel2);
                vGridControl1.EndUpdate();
            }
        }

        private void tabControl_Click(object sender, EventArgs e)
        {
            if (ActionMode == ActionModeEnum.Edit)
            {
                string fixedAssetCategory = ((FixedAssetCategoryModel)grdLookUpFixedAssetCategory.GetSelectedDataRow()).FixedAssetCategoryCode;

                if (fixedAssetCategory != null)
                {
                    if (fixedAssetCategory.ToString().Length == 2)
                    {
                        tabRegisterInfo.TabControl.TabPages[3].PageVisible = false;
                        chkIsStateManagement.Visible = false;
                        chkIsBussiness.Visible = false;
                    }
                    else
                    {
                        //if (fixedAssetCategory != null && fixedAssetCategory.ToString().Length >= 4 && fixedAssetCategory.ToString().Substring(0, 2) != "01" && fixedAssetCategory.ToString().Substring(0, 3) != "031" && fixedAssetCategory.ToString().Substring(0, 4) != "1104")
                        //{
                        //    grdLookUpBudgetSource.Visible = true;
                        //    tabRegisterInfo.TabControl.TabPages[3].PageVisible = false;
                        //}

                        //else
                        //{
                        //    tabRegisterInfo.TabControl.TabPages[3].PageVisible = true;
                        //    if (fixedAssetCategory != null && fixedAssetCategory.ToString().Length >= 2 && fixedAssetCategory.ToString().Substring(0, 2) != "01")
                        //    {
                        //        if (fixedAssetCategory != null && fixedAssetCategory.ToString().Length >= 4 && fixedAssetCategory.ToString().Substring(0, 4) != "1104")
                        //        {
                        //            groupControl4.Enabled = false;
                        //            groupControl5.Enabled = true;
                        //        }
                        //    }
                        //    else
                        //    {
                        //        groupControl4.Enabled = true;
                        //        groupControl5.Enabled = false;
                        //    }
                        //}

                        if (fixedAssetCategory.Length >= 3 && fixedAssetCategory.StartsWith("03"))//AnhNT: fix theo yêu cầu BA, tài sản là xe, thì show tab 4
                        {
                            tabRegisterInfo.TabControl.TabPages[3].PageVisible = true;
                            chkIsStateManagement.Visible = true;
                            chkIsBussiness.Visible = true;
                            groupControl4.Enabled = false;
                            groupControl5.Enabled = true;
                        }
                        else if (fixedAssetCategory.Length >= 3 && fixedAssetCategory.StartsWith("01"))
                        {
                            tabRegisterInfo.TabControl.TabPages[3].PageVisible = true;
                            chkIsStateManagement.Visible = true;
                            chkIsBussiness.Visible = true;
                            groupControl4.Enabled = true;
                            groupControl5.Enabled = false;
                        }
                        else
                            tabRegisterInfo.TabControl.TabPages[3].PageVisible = false;
                    }
                }
            }
        }

        private void grdLookUpBudgetSource_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (BudgetSourceCode != null && BudgetSourceCode != "")
                {
                    if (BudgetSourceCode == "13" || BudgetSourceCode == "15.1")
                    {
                        ArmortizationAccount = "6111";
                    }
                    else if (BudgetSourceCode == "12" || BudgetSourceCode == "15.2")
                    {
                        ArmortizationAccount = "6112";
                    }
                }
            }
            catch (Exception) { }
        }

        #endregion

        #region  Ghi tăng TSCĐ

        private void btnIncrement_Click(object sender, EventArgs e)
        {
            if (ActionMode == ActionModeEnum.Edit)
            {
                bool isValid = ValidDataBeforeIncrement();
                if (isValid)
                {
                    bool checkFAOpening = CheckFixedAssetOpening();
                    if (checkFAOpening)
                    {
                        long refId = PostToGeneralLedger();
                        var frm = new FrmXtraFormFAIncrementDetail
                        {
                            RefId = refId,
                            KeyValue = refId.ToString(CultureInfo.InvariantCulture),
                            ActionMode = ActionModeVoucherEnum.Edit,
                            MasterBindingSource = new BindingSource(),
                            CurrentPosition = 1
                        };
                        frm.ShowDialog();
                        if (refId <= 0)
                            XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResSaveDataError"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                        {
                            XtraMessageBox.Show(string.Format(ResourceHelper.GetResourceValueByName("ResFixedAssetIncrement"), _refNo), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Close();
                        }
                        //_keyForSend = _fixedAssetPresenter.Save(Convert.ToInt32(spnReplication.Value));
                        _keyForSend = _fixedAssetPresenter.Save(Convert.ToInt32(spnReplication.Value)).ToString(CultureInfo.InvariantCulture);
                        _fixedAssetPresenter.DeleteOpeningFixedAssetEntry(int.Parse(_keyForSend));
                    }
                    else
                    {
                        long refId = PostToGeneralLedger();
                        var frm = new FrmXtraFormFAIncrementDetail
                        {
                            RefId = refId,
                            KeyValue = refId.ToString(CultureInfo.InvariantCulture),
                            ActionMode = ActionModeVoucherEnum.Edit,
                            MasterBindingSource = new BindingSource(),
                            CurrentPosition = 1
                        };
                        frm.ShowDialog();
                        if (refId <= 0)
                            XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResSaveDataError"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                        {
                            XtraMessageBox.Show(string.Format(ResourceHelper.GetResourceValueByName("ResFixedAssetIncrement"), _refNo), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Close();
                        }
                        _fixedAssetPresenter.Save(Convert.ToInt32(spnReplication.Value));
                    }
                }
            }
        }

        // Sử dụng insert nghiệp vụ tự động
        private long PostToGeneralLedger()
        {
            var fixedAssetIncrementModels = new List<FixedAssetIncrementModel>();
            //object expenseAccount = grdLookupExpenseAccountView.GetFocusedRowCellValue("AccountCode");
            string expenseAccount = (AccountModel)grdLookupExpenseAccount.GetSelectedDataRow() == null ? null : ((AccountModel)grdLookupExpenseAccount.GetSelectedDataRow()).AccountCode;

            //string orgPriceAccount = grdLookUpOrgPriceAccountView.GetFocusedRowCellValue("AccountCode").ToString();
            string orgPriceAccount = (AccountModel)grdLookUpOrgPriceAccount.GetSelectedDataRow() == null ? null : ((AccountModel)grdLookUpOrgPriceAccount.GetSelectedDataRow()).AccountCode;

            //string depreciationAccount = grdLookUpDepreciationAccountView.GetFocusedRowCellValue("AccountCode").ToString();
            string depreciationAccount = (AccountModel)grdLookUpDepreciationAccount.GetSelectedDataRow() == null ? null : ((AccountModel)grdLookUpDepreciationAccount.GetSelectedDataRow()).AccountCode;

            //string capitalAccount = grdLookUpCapitalAccountView.GetFocusedRowCellValue("AccountCode").ToString();
            string capitalAccount = (AccountModel)grdLookUpCapitalAccount.GetSelectedDataRow() == null ? null : ((AccountModel)grdLookUpCapitalAccount.GetSelectedDataRow()).AccountCode;

            //object lookCapitalAccount = lookUpCapitalAccountView.GetFocusedRowCellValue("AccountCode");
            string lookCapitalAccount = (AccountModel)lookUpCapitalAccount.GetSelectedDataRow() == null ? null : ((AccountModel)lookUpCapitalAccount.GetSelectedDataRow()).AccountCode;

            string armortizationAccount = (AccountModel)gridLookUpArmortizationAccount.GetSelectedDataRow() == null ? null : ((AccountModel)gridLookUpArmortizationAccount.GetSelectedDataRow()).AccountCode;

            foreach (FixedAssetCurrencyModel fixedAssetCurrencyModel in FixedAssetCurrencies)
            {
                if (fixedAssetCurrencyModel.CurrencyCode.Equals("USD"))
                {
                    //if (fixedAssetCurrencyModel.AccumDepreciationAmountUSD.Equals(0))
                    //{
                    //    // Với TK chi phí được chọn
                    //    if (expenseAccount != null)
                    //    {
                    //        if (lookCapitalAccount == null)
                    //        {
                    //            XtraMessageBox.Show(string.Format(ResourceHelper.GetResourceValueByName("ResLookCapitalAccount"), FixedAssetCode), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //            lookUpCapitalAccount.Focus();
                    //        }
                    //        else
                    //        {
                    //            fixedAssetIncrementModels.Add(AddDoubleIncrementDetail(fixedAssetCurrencyModel, orgPriceAccount, lookCapitalAccount.ToString(), expenseAccount.ToString(), capitalAccount, fixedAssetCurrencyModel.OrgPrice, fixedAssetCurrencyModel.OrgPriceUSD, fixedAssetCurrencyModel.OrgPrice, fixedAssetCurrencyModel.OrgPriceUSD));
                    //        }
                    //    }

                    //    else
                    //    {
                    //        fixedAssetIncrementModels.Add(AddRowIncrementDetail(fixedAssetCurrencyModel, orgPriceAccount, capitalAccount));
                    //    }

                    //}
                    //else if (fixedAssetCurrencyModel.RemainingAmountUSD.Equals(0))
                    //{
                    //    fixedAssetIncrementModels.Add(AddRowIncrementDetail(fixedAssetCurrencyModel, orgPriceAccount, depreciationAccount));
                    //}
                    //else
                    //{
                    //    fixedAssetIncrementModels.Add(AddDoubleIncrementDetail(fixedAssetCurrencyModel, orgPriceAccount, depreciationAccount, orgPriceAccount, capitalAccount, fixedAssetCurrencyModel.AccumDepreciationAmount, fixedAssetCurrencyModel.AccumDepreciationAmountUSD, fixedAssetCurrencyModel.RemainingAmount, fixedAssetCurrencyModel.RemainingAmountUSD));
                    //}

                    if (fixedAssetCurrencyModel.AccumDepreciationAmount > 0 && PurchasedDate >= Convert.ToDateTime(GlobalVariable.StartedDate))
                    {
                        fixedAssetIncrementModels.Add(AddDoubleIncrementDetail(fixedAssetCurrencyModel, orgPriceAccount, capitalAccount, orgPriceAccount, depreciationAccount,
                            fixedAssetCurrencyModel.OrgPrice, fixedAssetCurrencyModel.OrgPriceUSD,
                            fixedAssetCurrencyModel.AccumDepreciationAmount, fixedAssetCurrencyModel.AccumDepreciationAmountUSD));
                    }
                    else
                    {
                        fixedAssetIncrementModels.Add(AddDoubleIncrementDetail(fixedAssetCurrencyModel, orgPriceAccount, lookCapitalAccount, "3371", capitalAccount,
                            fixedAssetCurrencyModel.OrgPrice, fixedAssetCurrencyModel.OrgPriceUSD));
                    }
                }
                else
                {
                    //if (fixedAssetCurrencyModel.AccumDepreciationAmountUSD.Equals(0))
                    //{
                    //    // Với TK chi phí được chọn
                    //    if (expenseAccount != null)
                    //    {
                    //        if (lookCapitalAccount == null)
                    //        {
                    //            XtraMessageBox.Show(string.Format(ResourceHelper.GetResourceValueByName("ResLookCapitalAccount"), FixedAssetCode), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //            lookUpCapitalAccount.Focus();
                    //        }
                    //        else
                    //        {
                    //            fixedAssetIncrementModels.Add(AddDoubleIncrementDetail(fixedAssetCurrencyModel, orgPriceAccount, lookCapitalAccount.ToString(), expenseAccount.ToString(), capitalAccount, fixedAssetCurrencyModel.OrgPrice, fixedAssetCurrencyModel.OrgPriceUSD, fixedAssetCurrencyModel.OrgPrice, fixedAssetCurrencyModel.OrgPriceUSD));
                    //        }
                    //    }
                    //    else
                    //    {
                    //        fixedAssetIncrementModels.Add(AddRowIncrementDetail(fixedAssetCurrencyModel, orgPriceAccount, capitalAccount));
                    //    }
                    //}
                    //else if (fixedAssetCurrencyModel.RemainingAmount.Equals(0))
                    //{
                    //    fixedAssetIncrementModels.Add(AddRowIncrementDetail(fixedAssetCurrencyModel, orgPriceAccount, depreciationAccount));
                    //}
                    //else
                    //{
                    //    fixedAssetIncrementModels.Add(AddDoubleIncrementDetail(fixedAssetCurrencyModel, orgPriceAccount, depreciationAccount, orgPriceAccount, capitalAccount, fixedAssetCurrencyModel.AccumDepreciationAmount, fixedAssetCurrencyModel.AccumDepreciationAmountUSD, fixedAssetCurrencyModel.RemainingAmount, fixedAssetCurrencyModel.RemainingAmountUSD));
                    //}

                    if (fixedAssetCurrencyModel.AccumDepreciationAmount > 0 && PurchasedDate >= Convert.ToDateTime(GlobalVariable.StartedDate))
                    {
                        fixedAssetIncrementModels.Add(AddDoubleIncrementDetail(fixedAssetCurrencyModel, orgPriceAccount, capitalAccount, orgPriceAccount, depreciationAccount,
                            fixedAssetCurrencyModel.OrgPrice, fixedAssetCurrencyModel.OrgPriceUSD,
                            fixedAssetCurrencyModel.AccumDepreciationAmount, fixedAssetCurrencyModel.AccumDepreciationAmountUSD));
                    }
                    else
                    {
                        fixedAssetIncrementModels.Add(AddDoubleIncrementDetail(fixedAssetCurrencyModel, orgPriceAccount, lookCapitalAccount, "3371", capitalAccount,
                                fixedAssetCurrencyModel.OrgPrice, fixedAssetCurrencyModel.OrgPriceUSD));
                    }
                }
            }
            return _fixedAssetPresenter.SaveFixedAssetIncrements(fixedAssetIncrementModels);
        }

        private void PostOpeningFixedAssetEntry()
        {
            var openingFixedAssetEntryModels = new List<OpeningFixedAssetEntryModel>();
            foreach (FixedAssetCurrencyModel fixedAssetCurrencyModel in FixedAssetCurrencies)
            {
                openingFixedAssetEntryModels.Add(AddOpeningFixedAssetEntry(fixedAssetCurrencyModel));
            }
            _fixedAssetPresenter.SaveOpeningFixedAssetEntry(openingFixedAssetEntryModels);
        }

        private OpeningFixedAssetEntryModel AddOpeningFixedAssetEntry(FixedAssetCurrencyModel fixedAssetCurrencyModel)
        {
            var openingFixedAssetEntryModel = new OpeningFixedAssetEntryModel
            {
                RefNo = GeneratedBaseRefNo(RefOpenTypeId, fixedAssetCurrencyModel.CurrencyCode),
                RefTypeId = RefOpenTypeId,
                PostedDate = DateTime.Parse(GlobalVariable.SystemDate).Date.AddDays(-1),
                FixedAssetId = ActionMode == ActionModeEnum.Edit ? Int32.Parse(KeyValue) : Int32.Parse(_keyForSend),
                IncrementDate = dtPurchasedDate.DateTime,
                DepartmentId = (DepartmentModel)grdLookUpDepartment.GetSelectedDataRow() == null ? 0 : ((DepartmentModel)grdLookUpDepartment.GetSelectedDataRow()).DepartmentId,
                LifeTime = (int)txtLifeTime.Value,
                Unit = txtUnit.Text,
                UsedDate = dtUsedDate.DateTime,
                CurrencyCode = fixedAssetCurrencyModel.CurrencyCode,
                ExchangeRate = (decimal)fixedAssetCurrencyModel.ExchangeRate,
                OrgPriceAccount = (AccountModel)grdLookUpOrgPriceAccount.GetSelectedDataRow() == null ? null : ((AccountModel)grdLookUpOrgPriceAccount.GetSelectedDataRow()).AccountCode,
                OrgPriceDebitAmount = fixedAssetCurrencyModel.OrgPrice,
                OrgPriceDebitAmountUSD = fixedAssetCurrencyModel.OrgPriceUSD,
                DepreciationAccount = (AccountModel)grdLookUpDepreciationAccount.GetSelectedDataRow() == null ? null : ((AccountModel)grdLookUpDepreciationAccount.GetSelectedDataRow()).AccountCode,
                DepreciationCreditAmount = fixedAssetCurrencyModel.AccumDepreciationAmount,
                DepreciationCreditAmountUSD = fixedAssetCurrencyModel.AccumDepreciationAmountUSD,
                CapitalAccount = (AccountModel)grdLookUpCapitalAccount.GetSelectedDataRow() == null ? null : ((AccountModel)grdLookUpCapitalAccount.GetSelectedDataRow()).AccountCode,
                CapitalCreditAmount = fixedAssetCurrencyModel.RemainingAmount,
                CapitalCreditAmountUSD = fixedAssetCurrencyModel.RemainingAmountUSD,
                RemainingAmount = fixedAssetCurrencyModel.RemainingAmount,
                RemainingAmountUSD = fixedAssetCurrencyModel.RemainingAmountUSD,
                Quantity = (int)txtQuantity.Value,
                Description = "Số dư đầu kỳ " + txtFixedAssetName.Text,
                BudgetSourceCode = (BudgetSourceModel)grdLookUpBudgetSource.GetSelectedDataRow() == null ? null : ((BudgetSourceModel)grdLookUpBudgetSource.GetSelectedDataRow()).BudgetSourceCode
            };
            _refNo = openingFixedAssetEntryModel.RefNo;
            return openingFixedAssetEntryModel;
        }

        private FixedAssetIncrementModel AddDoubleIncrementDetail(FixedAssetCurrencyModel fixedAssetCurrencyModel, string accountNumber, string correspondingAccountNumber, string butgetSourceAccountNumber, string butgetSourceCorrespondingAccount, decimal amountRow1, decimal amountRow1USD, decimal amountRow2, decimal amountRow2USD)
        {
            decimal totalAmount = 0;
            decimal totalAmountExchange = 0;
            var fixedAssetIncrementModel = new FixedAssetIncrementModel
            {
                PostedDate = dtUsedDate.DateTime.ToShortDateString(),
                RefDate = dtUsedDate.DateTime.ToShortDateString(), //GlobalVariable.SystemDate,
                RefNo = GeneratedBaseRefNo(RefTypeId, fixedAssetCurrencyModel.CurrencyCode),
                RefTypeId = RefTypeId,
                ExchangeRate = (decimal)fixedAssetCurrencyModel.ExchangeRate,
                CurrencyCode = fixedAssetCurrencyModel.CurrencyCode,
                JournalMemo = "Ghi tăng tài sản cố định " + txtFixedAssetName.Text,
                FixedAssetIncrementDetails = new List<FixedAssetIncrementDetailModel>(),
                AccountingObjectType = 1,
                EmployeeId = (EmployeeModel)grdlookUpEmployee.GetSelectedDataRow() == null ? (int?)null : ((EmployeeModel)grdlookUpEmployee.GetSelectedDataRow()).EmployeeId,
                Trader = (EmployeeModel)grdlookUpEmployee.GetSelectedDataRow() == null ? null : ((EmployeeModel)grdlookUpEmployee.GetSelectedDataRow()).EmployeeName
            };

            for (int i = 0; i < 2; i++)
            {
                var fixedAssetIncrementDetail = new FixedAssetIncrementDetailModel();

                if (i == 0)
                {
                    fixedAssetIncrementDetail.FixedAssetId = ActionMode == ActionModeEnum.Edit ? Int32.Parse(KeyValue) : Int32.Parse(_keyForSend);
                    fixedAssetIncrementDetail.AccountNumber = accountNumber;
                    fixedAssetIncrementDetail.CorrespondingAccountNumber = correspondingAccountNumber;
                    fixedAssetIncrementDetail.Description = "Ghi tăng tài sản cố định " + txtFixedAssetName.Text;
                    fixedAssetIncrementDetail.Quantity = (int)txtQuantity.Value;
                    fixedAssetIncrementDetail.UnitPriceOC = (amountRow1 - amountRow2) / (int)txtQuantity.Value;
                    fixedAssetIncrementDetail.UnitPriceExchange = (amountRow1USD - amountRow2USD) / (int)txtQuantity.Value;
                    //fixedAssetIncrementDetail.AmountOC = amountRow1; //fixedAssetCurrencyModel.OrgPrice;
                    //fixedAssetIncrementDetail.AmountExchange = amountRow1USD; //fixedAssetCurrencyModel.OrgPriceUSD;
                    fixedAssetIncrementDetail.AmountOC = amountRow1 - amountRow2;
                    fixedAssetIncrementDetail.AmountExchange = amountRow1USD - amountRow2USD;
                    fixedAssetIncrementDetail.DepartmentId = (DepartmentModel)grdLookUpDepartment.GetSelectedDataRow() == null ? (int?)null : ((DepartmentModel)grdLookUpDepartment.GetSelectedDataRow()).DepartmentId;
                    fixedAssetIncrementDetail.BudgetSourceCode = (BudgetSourceModel)grdLookUpBudgetSource.GetSelectedDataRow() == null ? null : ((BudgetSourceModel)grdLookUpBudgetSource.GetSelectedDataRow()).BudgetSourceCode;
                    fixedAssetIncrementDetail.BudgetItemCode = (BudgetItemModel)gridLookUpBudgetItem.GetSelectedDataRow() == null ? null : ((BudgetItemModel)gridLookUpBudgetItem.GetSelectedDataRow()).BudgetItemCode;
                }
                else
                {
                    fixedAssetIncrementDetail.FixedAssetId = ActionMode == ActionModeEnum.Edit ? Int32.Parse(KeyValue) : Int32.Parse(_keyForSend);
                    fixedAssetIncrementDetail.AccountNumber = butgetSourceAccountNumber;
                    fixedAssetIncrementDetail.CorrespondingAccountNumber = butgetSourceCorrespondingAccount;
                    fixedAssetIncrementDetail.Description = "Ghi tăng tài sản cố định " + txtFixedAssetName.Text;
                    fixedAssetIncrementDetail.Quantity = (int)txtQuantity.Value;
                    //fixedAssetIncrementDetail.UnitPriceOC = amountRow2 / (int)txtQuantity.Value;
                    //fixedAssetIncrementDetail.UnitPriceExchange = amountRow2USD / (int)txtQuantity.Value;
                    //fixedAssetIncrementDetail.AmountOC = amountRow2; //fixedAssetCurrencyModel.OrgPrice;
                    //fixedAssetIncrementDetail.AmountExchange = amountRow2USD; //fixedAssetCurrencyModel.OrgPriceUSD;
                    fixedAssetIncrementDetail.UnitPriceOC = amountRow2 / (int)txtQuantity.Value;
                    fixedAssetIncrementDetail.UnitPriceExchange = amountRow2USD / (int)txtQuantity.Value;
                    fixedAssetIncrementDetail.AmountOC = amountRow2;
                    fixedAssetIncrementDetail.AmountExchange = amountRow2USD;
                    fixedAssetIncrementDetail.DepartmentId = (DepartmentModel)grdLookUpDepartment.GetSelectedDataRow() == null ? (int?)null : ((DepartmentModel)grdLookUpDepartment.GetSelectedDataRow()).DepartmentId;
                    fixedAssetIncrementDetail.BudgetSourceCode = (BudgetSourceModel)grdLookUpBudgetSource.GetSelectedDataRow() == null ? null : ((BudgetSourceModel)grdLookUpBudgetSource.GetSelectedDataRow()).BudgetSourceCode;
                    fixedAssetIncrementDetail.BudgetItemCode = (BudgetItemModel)gridLookUpBudgetItem.GetSelectedDataRow() == null ? null : ((BudgetItemModel)gridLookUpBudgetItem.GetSelectedDataRow()).BudgetItemCode;
                }
                totalAmount += fixedAssetIncrementDetail.AmountOC;
                totalAmountExchange += fixedAssetIncrementDetail.AmountExchange;
                fixedAssetIncrementModel.FixedAssetIncrementDetails.Add(fixedAssetIncrementDetail);
            }
            fixedAssetIncrementModel.TotalAmountOC = totalAmount;
            fixedAssetIncrementModel.TotalAmountExchange = totalAmountExchange;
            _refNo = fixedAssetIncrementModel.RefNo;
            return fixedAssetIncrementModel;
        }

        private FixedAssetIncrementModel AddDoubleIncrementDetail(FixedAssetCurrencyModel fixedAssetCurrencyModel, string accountNumber, string correspondingAccountNumber, string butgetSourceAccountNumber, string butgetSourceCorrespondingAccount, decimal amount, decimal amountEx)
        {
            decimal totalAmount = 0;
            decimal totalAmountExchange = 0;
            var fixedAssetIncrementModel = new FixedAssetIncrementModel
            {
                PostedDate = dtUsedDate.DateTime.ToShortDateString(),
                RefDate = dtUsedDate.DateTime.ToShortDateString(), //GlobalVariable.SystemDate,
                RefNo = GeneratedBaseRefNo(RefTypeId, fixedAssetCurrencyModel.CurrencyCode),
                RefTypeId = RefTypeId,
                ExchangeRate = (decimal)fixedAssetCurrencyModel.ExchangeRate,
                CurrencyCode = fixedAssetCurrencyModel.CurrencyCode,
                JournalMemo = "Ghi tăng tài sản cố định " + txtFixedAssetName.Text,
                FixedAssetIncrementDetails = new List<FixedAssetIncrementDetailModel>(),
                AccountingObjectType = 1,
                EmployeeId = (EmployeeModel)grdlookUpEmployee.GetSelectedDataRow() == null ? (int?)null : ((EmployeeModel)grdlookUpEmployee.GetSelectedDataRow()).EmployeeId,
                Trader = (EmployeeModel)grdlookUpEmployee.GetSelectedDataRow() == null ? null : ((EmployeeModel)grdlookUpEmployee.GetSelectedDataRow()).EmployeeName
            };

            for (int i = 0; i < 2; i++)
            {
                var fixedAssetIncrementDetail = new FixedAssetIncrementDetailModel();

                if (i == 0)
                {
                    fixedAssetIncrementDetail.FixedAssetId = ActionMode == ActionModeEnum.Edit ? Int32.Parse(KeyValue) : Int32.Parse(_keyForSend);
                    fixedAssetIncrementDetail.AccountNumber = accountNumber;
                    fixedAssetIncrementDetail.CorrespondingAccountNumber = correspondingAccountNumber;
                    fixedAssetIncrementDetail.Description = "Ghi tăng tài sản cố định " + txtFixedAssetName.Text;
                    fixedAssetIncrementDetail.Quantity = (int)txtQuantity.Value;
                    fixedAssetIncrementDetail.UnitPriceOC = amount / (int)txtQuantity.Value;
                    fixedAssetIncrementDetail.UnitPriceExchange = amountEx / (int)txtQuantity.Value;
                    fixedAssetIncrementDetail.AmountOC = amount;
                    fixedAssetIncrementDetail.AmountExchange = amountEx;
                    fixedAssetIncrementDetail.DepartmentId = (DepartmentModel)grdLookUpDepartment.GetSelectedDataRow() == null ? (int?)null : ((DepartmentModel)grdLookUpDepartment.GetSelectedDataRow()).DepartmentId;
                    fixedAssetIncrementDetail.BudgetSourceCode = (BudgetSourceModel)grdLookUpBudgetSource.GetSelectedDataRow() == null ? null : ((BudgetSourceModel)grdLookUpBudgetSource.GetSelectedDataRow()).BudgetSourceCode;
                    fixedAssetIncrementDetail.BudgetItemCode = (BudgetItemModel)gridLookUpBudgetItem.GetSelectedDataRow() == null ? null : ((BudgetItemModel)gridLookUpBudgetItem.GetSelectedDataRow()).BudgetItemCode;
                }
                else
                {
                    fixedAssetIncrementDetail.FixedAssetId = ActionMode == ActionModeEnum.Edit ? Int32.Parse(KeyValue) : Int32.Parse(_keyForSend);
                    fixedAssetIncrementDetail.AccountNumber = butgetSourceAccountNumber;
                    fixedAssetIncrementDetail.CorrespondingAccountNumber = butgetSourceCorrespondingAccount;
                    fixedAssetIncrementDetail.Description = "Ghi tăng tài sản cố định " + txtFixedAssetName.Text;
                    fixedAssetIncrementDetail.Quantity = (int)txtQuantity.Value;
                    fixedAssetIncrementDetail.UnitPriceOC = amount / (int)txtQuantity.Value;
                    fixedAssetIncrementDetail.UnitPriceExchange = amountEx / (int)txtQuantity.Value;
                    fixedAssetIncrementDetail.AmountOC = amount;
                    fixedAssetIncrementDetail.AmountExchange = amountEx;
                    fixedAssetIncrementDetail.DepartmentId = (DepartmentModel)grdLookUpDepartment.GetSelectedDataRow() == null ? (int?)null : ((DepartmentModel)grdLookUpDepartment.GetSelectedDataRow()).DepartmentId;
                    fixedAssetIncrementDetail.BudgetSourceCode = (BudgetSourceModel)grdLookUpBudgetSource.GetSelectedDataRow() == null ? null : ((BudgetSourceModel)grdLookUpBudgetSource.GetSelectedDataRow()).BudgetSourceCode;
                    fixedAssetIncrementDetail.BudgetItemCode = (BudgetItemModel)gridLookUpBudgetItem.GetSelectedDataRow() == null ? null : ((BudgetItemModel)gridLookUpBudgetItem.GetSelectedDataRow()).BudgetItemCode;
                }
                totalAmount += fixedAssetIncrementDetail.AmountOC;
                totalAmountExchange += fixedAssetIncrementDetail.AmountExchange;
                fixedAssetIncrementModel.FixedAssetIncrementDetails.Add(fixedAssetIncrementDetail);
            }
            fixedAssetIncrementModel.TotalAmountOC = totalAmount;
            fixedAssetIncrementModel.TotalAmountExchange = totalAmountExchange;
            _refNo = fixedAssetIncrementModel.RefNo;
            return fixedAssetIncrementModel;
        }

        private FixedAssetIncrementModel AddRowIncrementDetail(FixedAssetCurrencyModel fixedAssetCurrencyModel, string accountNumber, string correspondingAccountNumber)
        {
            decimal totalAmount = 0;
            decimal totalAmountExchange = 0;
            var fixedAssetIncrementModel = new FixedAssetIncrementModel
            {
                PostedDate = dtUsedDate.DateTime.ToShortDateString(),
                RefDate = dtUsedDate.DateTime.ToShortDateString(),
                RefNo = GeneratedBaseRefNo(RefTypeId, fixedAssetCurrencyModel.CurrencyCode),
                RefTypeId = RefTypeId,
                ExchangeRate = (decimal)fixedAssetCurrencyModel.ExchangeRate,
                CurrencyCode = fixedAssetCurrencyModel.CurrencyCode,
                JournalMemo = "Ghi tăng tài sản cố định " + txtFixedAssetName.Text,
                FixedAssetIncrementDetails = new List<FixedAssetIncrementDetailModel>(),
                AccountingObjectType = 1,
                EmployeeId = (EmployeeModel)grdlookUpEmployee.GetSelectedDataRow() == null ? (int?)null : ((EmployeeModel)grdlookUpEmployee.GetSelectedDataRow()).EmployeeId,
                Trader = (EmployeeModel)grdlookUpEmployee.GetSelectedDataRow() == null ? null : ((EmployeeModel)grdlookUpEmployee.GetSelectedDataRow()).EmployeeName
            };

            var fixedAssetIncrementDetail = new FixedAssetIncrementDetailModel
            {
                FixedAssetId = ActionMode == ActionModeEnum.Edit ? Int32.Parse(KeyValue) : Int32.Parse(_keyForSend),
                AccountNumber = accountNumber,
                CorrespondingAccountNumber = correspondingAccountNumber,
                Description = "Ghi tăng tài sản cố định " + txtFixedAssetName.Text,
                Quantity = (int)txtQuantity.Value,
                UnitPriceOC = fixedAssetCurrencyModel.UnitPrice,
                UnitPriceExchange = fixedAssetCurrencyModel.UnitPriceUSD,
                AmountOC = fixedAssetCurrencyModel.OrgPrice,
                AmountExchange = fixedAssetCurrencyModel.OrgPriceUSD,
                DepartmentId = (DepartmentModel)grdLookUpDepartment.GetSelectedDataRow() == null ? (int?)null : ((DepartmentModel)grdLookUpDepartment.GetSelectedDataRow()).DepartmentId,
                BudgetSourceCode = (BudgetSourceModel)grdLookUpBudgetSource.GetSelectedDataRow() == null ? null : ((BudgetSourceModel)grdLookUpBudgetSource.GetSelectedDataRow()).BudgetSourceCode,
                BudgetItemCode = (BudgetItemModel)gridLookUpBudgetItem.GetSelectedDataRow() == null ? null : ((BudgetItemModel)gridLookUpBudgetItem.GetSelectedDataRow()).BudgetItemCode
            };
            totalAmount += fixedAssetIncrementDetail.AmountOC;
            totalAmountExchange += fixedAssetIncrementDetail.AmountExchange;
            fixedAssetIncrementModel.FixedAssetIncrementDetails.Add(fixedAssetIncrementDetail);
            fixedAssetIncrementModel.TotalAmountOC = totalAmount;
            fixedAssetIncrementModel.TotalAmountExchange = totalAmountExchange;
            _refNo = fixedAssetIncrementModel.RefNo;
            return fixedAssetIncrementModel;
        }

        private void VisibleIncrementButton(int quantityOnHand)
        {
            //tabControl.SelectedTabPage = tabVoucherInfo;
            //tabControl.SelectedTabPage = tabRegisterInfo;
            //tabControl.SelectedTabPage = tabAmountInfo;
            //tabControl.SelectedTabPage = tabAccessaryInfo;
            //tabControl.SelectedTabPage = tabGeneralInfo;
            if (ActionMode == ActionModeEnum.AddNew)
            {
                if ((dtPurchasedDate.DateTime < DateTime.Parse(GlobalVariable.SystemDate) && cboState.SelectedIndex == 1) || cboState.SelectedIndex != 1)
                {
                    groupControl3.Visible = false;
                    labelControl34.Visible = false;
                    //labelControl35.Visible = false;
                    lookUpCapitalAccount.Visible = false;
                    //grdLookupExpenseAccount.Visible = false;
                    grdFixedAssetLedger.Height = 205;
                    grdFixedAssetLedger.Height = grdFixedAssetLedger.Height + groupControl3.Height + 5;
                    btnIncrement.Visible = false;
                }
                else
                {
                    groupControl3.Visible = true;
                    labelControl34.Visible = true;
                    //labelControl35.Visible = true;
                    lookUpCapitalAccount.Visible = true;
                    //grdLookupExpenseAccount.Visible = true;
                    grdFixedAssetLedger.Height = 205;
                    groupControl3.Top = 224;
                    //btnIncrement.Visible = true;
                }
            }
            else
            {
                bool checkFAOpening = CheckFixedAssetOpening();
                bool checkFAIncrement = CheckFixedAsset();
                bool checkFADecrement = CheckFixedAssetDecrement();
                if (((checkFAOpening && checkFAIncrement) && cboState.SelectedIndex == 1) ||
                    (checkFADecrement && cboState.SelectedIndex == 3))
                {
                    groupControl3.Visible = false;
                    labelControl34.Visible = false;
                    //labelControl35.Visible = false;
                    lookUpCapitalAccount.Visible = false;
                    //grdLookupExpenseAccount.Visible = false;
                    grdFixedAssetLedger.Height = 205;
                    bool incrementVisible = btnIncrement.Visible;
                    bool decrementVisible = btnDecrement.Visible;
                    if (incrementVisible == false && decrementVisible == false)
                        grdFixedAssetLedger.Height = grdFixedAssetLedger.Height + groupControl3.Height + 5;
                    else
                        grdFixedAssetLedger.Height = grdFixedAssetLedger.Height + groupControl3.Height;
                }
                else if (!checkFAIncrement && !checkFADecrement
                    && cboState.SelectedIndex == 1 && dtPurchasedDate.DateTime >= DateTime.Parse(GlobalVariable.SystemDate))
                {
                    groupControl3.Visible = true;
                    labelControl34.Visible = true;
                    //labelControl35.Visible = true;
                    lookUpCapitalAccount.Visible = true;
                    //grdLookupExpenseAccount.Visible = true;
                    grdFixedAssetLedger.Height = 205;
                    btnIncrement.Visible = true;
                }
                //else if (checkFAOpening && !checkFAIncrement && !checkFADecrement 
                //    && cboState.SelectedIndex == 1 && dtPurchasedDate.DateTime > DateTime.Parse(GlobalVariable.SystemDate))
                //{
                //    groupControl3.Visible = true;
                //    labelControl34.Visible = true;
                //    labelControl35.Visible = true;
                //    lookUpCapitalAccount.Visible = true;
                //    grdLookupExpenseAccount.Visible = true;
                //    grdFixedAssetLedger.Height = 209;
                //    btnIncrement.Visible = true;
                //}
                else
                {
                    if (cboState.SelectedIndex == 5 && (checkFAOpening || checkFAIncrement))
                    {
                        if (quantityOnHand > 0)
                        {
                            groupControl3.Visible = true;
                            labelControl34.Visible = false;
                            //labelControl35.Visible = false;
                            lookUpCapitalAccount.Visible = false;
                            //grdLookupExpenseAccount.Visible = false;
                            grdFixedAssetLedger.Height = 202;
                            groupControl3.Top = 224;
                        }
                        else
                        {
                            groupControl3.Visible = false;
                            labelControl34.Visible = false;
                            //labelControl35.Visible = false;
                            lookUpCapitalAccount.Visible = false;
                            //grdLookupExpenseAccount.Visible = false;
                            grdFixedAssetLedger.Height = 202;
                            groupControl3.Top = 224;
                            grdFixedAssetLedger.Height = grdFixedAssetLedger.Height + groupControl3.Height - 7;
                        }
                    }
                    else if (cboState.SelectedIndex == 5 && (!checkFAOpening && !checkFAIncrement))
                    {
                        groupControl3.Visible = true;
                        labelControl34.Visible = false;
                        //labelControl35.Visible = false;
                        lookUpCapitalAccount.Visible = false;
                        //grdLookupExpenseAccount.Visible = false;
                        grdFixedAssetLedger.Height = 202;
                        groupControl3.Top = 224;
                        grdFixedAssetLedger.Height = grdFixedAssetLedger.Height + groupControl3.Height - 7;
                    }
                    else
                    {
                        if (cboState.SelectedIndex == 3 && checkFADecrement)
                        {
                            groupControl3.Visible = false;
                            labelControl34.Visible = false;
                            //labelControl35.Visible = false;
                            lookUpCapitalAccount.Visible = false;
                            //grdLookupExpenseAccount.Visible = false;
                            grdFixedAssetLedger.Height = 202;
                            groupControl3.Top = 224;
                            grdFixedAssetLedger.Height = grdFixedAssetLedger.Height + groupControl3.Height - 7;
                        }
                        else if (cboState.SelectedIndex == 3 && !checkFADecrement)
                        {
                            groupControl3.Visible = true;
                            labelControl34.Visible = false;
                            //labelControl35.Visible = false;
                            lookUpCapitalAccount.Visible = false;
                            //grdLookupExpenseAccount.Visible = false;
                            grdFixedAssetLedger.Height = 202;
                            groupControl3.Top = 224;
                        }
                        else
                        {
                            groupControl3.Visible = false;
                            labelControl34.Visible = false;
                            //labelControl35.Visible = false;
                            lookUpCapitalAccount.Visible = false;
                            //grdLookupExpenseAccount.Visible = false;
                            grdFixedAssetLedger.Height = 202;
                            grdFixedAssetLedger.Height = grdFixedAssetLedger.Height + groupControl3.Height - 7;
                        }
                    }
                }
            }
        }

        #endregion

        #region Ghi giảm TSCĐ

        private void btnDecrement_Click(object sender, EventArgs e)
        {
            if (ActionMode == ActionModeEnum.Edit)
            {
                if (ValidData())
                {
                    bool checkFixedAsset = CheckFixedAsset();
                    bool checkOpeningFixedAsset = CheckFixedAssetOpening();
                    string currencyCode = "";
                    int remainingQuantity;
                    foreach (FixedAssetCurrencyModel fixedAssetCurrency in FixedAssetCurrencies)
                    {
                        currencyCode = fixedAssetCurrency.CurrencyCode;
                    }
                    FixedAssetModel fixedAsetDecrement = _fixedAssetPresenter.GetFADecrement(KeyValue, currencyCode, DecrementRefTypeId);
                    if (fixedAsetDecrement == null)
                        remainingQuantity = (int)txtQuantity.Value;
                    else
                        remainingQuantity = (int)txtQuantity.Value - fixedAsetDecrement.Quantity;
                    if (checkFixedAsset == false && checkOpeningFixedAsset == false)
                    {
                        XtraMessageBox.Show(string.Format(ResourceHelper.GetResourceValueByName("ResNoFixedAssetIncrement"), txtFixedAssetCode.EditValue), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (remainingQuantity < txtDescreaseQuantity.Value)
                        {
                            XtraMessageBox.Show(string.Format(ResourceHelper.GetResourceValueByName("ResCheckFixedAssetDecrementQuantity"), txtFixedAssetCode.EditValue, remainingQuantity), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            if (txtDescreaseQuantity.Value <= 0 && cboState.SelectedIndex == 5)
                            {
                                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResCheckZeroDecrementQuantity"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                long refId = PostToFADecrementVoucher(remainingQuantity);
                                var bindingSource = new BindingSource();
                                bindingSource.DataSource = new List<FixedAssetDecrementModel>();
                                var frm = new FrmXtraFormFADecrementDetail()
                                {
                                    KeyValue = refId.ToString(CultureInfo.InvariantCulture),
                                    ActionMode = ActionModeVoucherEnum.None,
                                    RefId = refId,
                                    MasterBindingSource = bindingSource,
                                    CurrentPosition = 1
                                };

                                if (refId <= 0)
                                    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResSaveDataError"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                else
                                {
                                    if (!string.IsNullOrEmpty(_refNo) && !string.IsNullOrEmpty(_refNoUSD))
                                    {
                                        XtraMessageBox.Show(string.Format(ResourceHelper.GetResourceValueByName("ResDoubleFixedAssetDecrement"), _refNo), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                _fixedAssetPresenter.Save(Convert.ToInt32(spnReplication.Value));
                                Close();
                                frm.ShowDialog();
                            }
                        }
                    }
                }
            }
        }

        private FixedAssetDecrementModel AddDoubleDecrementDetail(FixedAssetCurrencyModel fixedAssetCurrencyModel, string accountNumber, string correspondingAccountNumber, string butgetSourceAccountNumber, string butgetSourceCorrespondingAccount, decimal amountRow1, decimal amountRow1USD, decimal amountRow2, decimal amountRow2USD, int quantity)
        {
            decimal totalAmount = 0;
            decimal totalAmountExchange = 0;

            var fixedAssetDecrementModel = new FixedAssetDecrementModel
            {
                PostedDate = new GlobalVariable().PostedDate,
                RefDate = new GlobalVariable().PostedDate, //GlobalVariable.SystemDate,
                RefNo = GeneratedBaseRefNo(DecrementRefTypeId, fixedAssetCurrencyModel.CurrencyCode),
                RefTypeId = DecrementRefTypeId,
                ExchangeRate = (decimal)fixedAssetCurrencyModel.ExchangeRate,
                CurrencyCode = fixedAssetCurrencyModel.CurrencyCode,
                JournalMemo = "Giảm do thanh lý",
                FixedAssetDecrementDetails = new List<FixedAssetDecrementDetailModel>(),
                AccountingObjectType = 1,
                EmployeeId = (EmployeeModel)grdlookUpEmployee.GetSelectedDataRow() == null ? (int?)null : ((EmployeeModel)grdlookUpEmployee.GetSelectedDataRow()).EmployeeId,
                Trader = (EmployeeModel)grdlookUpEmployee.GetSelectedDataRow() == null ? null : ((EmployeeModel)grdlookUpEmployee.GetSelectedDataRow()).EmployeeName
            };

            for (int i = 0; i < 2; i++)
            {
                var fixedAssetDecrementDetail = new FixedAssetDecrementDetailModel();

                if (i == 0)
                {
                    fixedAssetDecrementDetail.FixedAssetId = ActionMode == ActionModeEnum.Edit ? Int32.Parse(KeyValue) : Int32.Parse(_keyForSend);
                    fixedAssetDecrementDetail.AccountNumber = accountNumber;
                    fixedAssetDecrementDetail.CorrespondingAccountNumber = correspondingAccountNumber;
                    fixedAssetDecrementDetail.Description = "Ghi giảm tài sản cố định " + txtFixedAssetName.Text;
                    fixedAssetDecrementDetail.Quantity = quantity;
                    fixedAssetDecrementDetail.UnitPriceOC = amountRow1 / quantity;
                    fixedAssetDecrementDetail.UnitPriceExchange = amountRow1USD / (quantity * (decimal)fixedAssetCurrencyModel.ExchangeRate);
                    fixedAssetDecrementDetail.AmountOC = amountRow1;
                    fixedAssetDecrementDetail.AmountExchange = amountRow1USD / (decimal)fixedAssetCurrencyModel.ExchangeRate;
                    fixedAssetDecrementDetail.DepartmentId = (DepartmentModel)grdLookUpDepartment.GetSelectedDataRow() == null ? (int?)null : ((DepartmentModel)grdLookUpDepartment.GetSelectedDataRow()).DepartmentId;
                    fixedAssetDecrementDetail.BudgetSourceCode = (BudgetSourceModel)grdLookUpBudgetSource.GetSelectedDataRow() == null ? null : ((BudgetSourceModel)grdLookUpBudgetSource.GetSelectedDataRow()).BudgetSourceCode;
                    fixedAssetDecrementDetail.BudgetItemCode = (BudgetItemModel)gridLookUpBudgetItem.GetSelectedDataRow() == null ? null : ((BudgetItemModel)gridLookUpBudgetItem.GetSelectedDataRow()).BudgetItemCode;
                }
                else
                {
                    fixedAssetDecrementDetail.FixedAssetId = ActionMode == ActionModeEnum.Edit ? Int32.Parse(KeyValue) : Int32.Parse(_keyForSend);
                    fixedAssetDecrementDetail.AccountNumber = butgetSourceAccountNumber;
                    fixedAssetDecrementDetail.CorrespondingAccountNumber = butgetSourceCorrespondingAccount;
                    fixedAssetDecrementDetail.Description = "Ghi giảm tài sản cố định " + txtFixedAssetName.Text;
                    fixedAssetDecrementDetail.Quantity = quantity;
                    fixedAssetDecrementDetail.UnitPriceOC = amountRow2 / quantity;
                    fixedAssetDecrementDetail.UnitPriceExchange = amountRow2USD / (quantity * (decimal)fixedAssetCurrencyModel.ExchangeRate);
                    fixedAssetDecrementDetail.AmountOC = amountRow2;
                    fixedAssetDecrementDetail.AmountExchange = amountRow2USD / (decimal)fixedAssetCurrencyModel.ExchangeRate;
                    fixedAssetDecrementDetail.DepartmentId = (DepartmentModel)grdLookUpDepartment.GetSelectedDataRow() == null ? (int?)null : ((DepartmentModel)grdLookUpDepartment.GetSelectedDataRow()).DepartmentId;
                    fixedAssetDecrementDetail.BudgetSourceCode = (BudgetSourceModel)grdLookUpBudgetSource.GetSelectedDataRow() == null ? null : ((BudgetSourceModel)grdLookUpBudgetSource.GetSelectedDataRow()).BudgetSourceCode;
                    fixedAssetDecrementDetail.BudgetItemCode = (BudgetItemModel)gridLookUpBudgetItem.GetSelectedDataRow() == null ? null : ((BudgetItemModel)gridLookUpBudgetItem.GetSelectedDataRow()).BudgetItemCode;
                }
                totalAmount += fixedAssetDecrementDetail.AmountOC;
                totalAmountExchange += fixedAssetDecrementDetail.AmountExchange;
                fixedAssetDecrementModel.FixedAssetDecrementDetails.Add(fixedAssetDecrementDetail);
            }
            fixedAssetDecrementModel.TotalAmountOC = totalAmount;
            fixedAssetDecrementModel.TotalAmountExchange = totalAmountExchange;
            if (fixedAssetCurrencyModel.CurrencyCode == "USD")
                _refNoUSD = fixedAssetDecrementModel.RefNo;
            else
                _refNo = fixedAssetDecrementModel.RefNo;
            return fixedAssetDecrementModel;
        }

        private FixedAssetDecrementModel AddRowDecrementDetail(FixedAssetCurrencyModel fixedAssetCurrencyModel, string accountNumber, string correspondingAccountNumber, decimal depreciation, decimal depreciationUSD, int quantity)
        {
            decimal totalAmount = 0;
            decimal totalAmountExchange = 0;
            var fixedAssetDecrementModel = new FixedAssetDecrementModel
            {
                PostedDate = new GlobalVariable().PostedDate,
                RefDate = new GlobalVariable().PostedDate,
                RefNo = GeneratedBaseRefNo(DecrementRefTypeId, fixedAssetCurrencyModel.CurrencyCode),
                RefTypeId = DecrementRefTypeId,
                ExchangeRate = (decimal)fixedAssetCurrencyModel.ExchangeRate,
                CurrencyCode = fixedAssetCurrencyModel.CurrencyCode,
                JournalMemo = "Giảm do thanh lý",
                FixedAssetDecrementDetails = new List<FixedAssetDecrementDetailModel>(),
                AccountingObjectType = 1,
                EmployeeId = (EmployeeModel)grdlookUpEmployee.GetSelectedDataRow() == null ? (int?)null : ((EmployeeModel)grdlookUpEmployee.GetSelectedDataRow()).EmployeeId,
                Trader = (EmployeeModel)grdlookUpEmployee.GetSelectedDataRow() == null ? null : ((EmployeeModel)grdlookUpEmployee.GetSelectedDataRow()).EmployeeName,
            };

            var fixedAssetDecrementDetail = new FixedAssetDecrementDetailModel
            {
                FixedAssetId = ActionMode == ActionModeEnum.Edit ? Int32.Parse(KeyValue) : Int32.Parse(_keyForSend),
                AccountNumber = accountNumber,
                CorrespondingAccountNumber = correspondingAccountNumber,
                Description = "Ghi giảm tài sản cố định " + txtFixedAssetName.Text,
                Quantity = quantity,
                UnitPriceOC = depreciation / quantity,
                UnitPriceExchange = depreciationUSD / (quantity * (decimal)fixedAssetCurrencyModel.ExchangeRate),
                AmountOC = depreciation,
                AmountExchange = depreciationUSD / (decimal)fixedAssetCurrencyModel.ExchangeRate,
                DepartmentId = (DepartmentModel)grdLookUpDepartment.GetSelectedDataRow() == null ? (int?)null : ((DepartmentModel)grdLookUpDepartment.GetSelectedDataRow()).DepartmentId,
                BudgetSourceCode = (BudgetSourceModel)grdLookUpBudgetSource.GetSelectedDataRow() == null ? null : ((BudgetSourceModel)grdLookUpBudgetSource.GetSelectedDataRow()).BudgetSourceCode,
                BudgetItemCode = (BudgetItemModel)gridLookUpBudgetItem.GetSelectedDataRow() == null ? null : ((BudgetItemModel)gridLookUpBudgetItem.GetSelectedDataRow()).BudgetItemCode
            };
            totalAmount += fixedAssetDecrementDetail.AmountOC;
            totalAmountExchange += fixedAssetDecrementDetail.AmountExchange;
            fixedAssetDecrementModel.FixedAssetDecrementDetails.Add(fixedAssetDecrementDetail);
            fixedAssetDecrementModel.TotalAmountOC = totalAmount;
            fixedAssetDecrementModel.TotalAmountExchange = totalAmountExchange;
            if (fixedAssetCurrencyModel.CurrencyCode == "USD")
                _refNoUSD = fixedAssetDecrementModel.RefNo;
            else
                _refNo = fixedAssetDecrementModel.RefNo;
            return fixedAssetDecrementModel;
        }

        private long PostToFADecrementVoucher(int remainingQuantity)
        {
            var fixedAssetDecrementModels = new List<FixedAssetDecrementModel>();
            string expenseAccount = (AccountModel)grdLookUpCapitalAccount.GetSelectedDataRow() == null ? "" : ((AccountModel)grdLookUpCapitalAccount.GetSelectedDataRow()).AccountCode;
            string orgPriceAccount = (AccountModel)grdLookUpOrgPriceAccount.GetSelectedDataRow() == null ? "" : ((AccountModel)grdLookUpOrgPriceAccount.GetSelectedDataRow()).AccountCode;
            string depreciationAccount = (AccountModel)grdLookUpDepreciationAccount.GetSelectedDataRow() == null ? "" : ((AccountModel)grdLookUpDepreciationAccount.GetSelectedDataRow()).AccountCode;
            int quantity;
            if (FixedAssetCurrencies.Count == 1 && (int)txtDescreaseQuantity.Value > 0)
                quantity = (int)txtDescreaseQuantity.Value;
            else if (FixedAssetCurrencies.Count == 1 && cboState.SelectedIndex == 3)
                quantity = (int)txtQuantity.Value;
            else
                quantity = 1;
            foreach (FixedAssetCurrencyModel fixedAssetCurrencyModel in FixedAssetCurrencies)
            {
                // Nếu là USD
                decimal depreciationUSD;
                decimal orgPrice;
                decimal orgPriceUSD;
                decimal depreciation;
                decimal remainingValue;
                decimal remainingUSDValue;

                if (fixedAssetCurrencyModel.CurrencyCode.Equals("USD"))
                {
                    // Tính số tiền hao mòn, giá trị còn lại theo tiền USD
                    FixedAssetModel fixedAsset = _fixedAssetPresenter.GetFADecrement(KeyValue,
                        fixedAssetCurrencyModel.CurrencyCode, new GlobalVariable().PostedDate);
                    if (fixedAsset != null)
                    {
                        if (remainingQuantity - (int)txtDescreaseQuantity.Value == 0)
                        {
                            orgPrice = fixedAsset.RemainingOrgPrice;
                            orgPriceUSD = fixedAsset.RemainingOrgPrice;
                            depreciation = fixedAsset.AccumDepreciationAmount;
                            depreciationUSD = fixedAsset.AccumDepreciationAmount;
                            remainingValue = orgPrice - depreciation;
                            remainingUSDValue = orgPriceUSD - depreciationUSD;
                        }
                        else
                        {
                            orgPrice = fixedAsset.RemainingOrgPrice;
                            orgPriceUSD = fixedAsset.RemainingOrgPrice;
                            depreciation = (fixedAsset.AccumDepreciationAmount / remainingQuantity) * quantity;
                            depreciationUSD = (fixedAsset.AccumDepreciationAmount / remainingQuantity) * quantity;
                            remainingValue = (orgPrice * quantity / remainingQuantity) - depreciation;
                            remainingUSDValue = (orgPriceUSD * quantity / remainingQuantity) - depreciationUSD;
                        }
                        if (orgPrice == depreciation)
                        {
                            fixedAssetDecrementModels.Add(AddRowDecrementDetail(fixedAssetCurrencyModel, depreciationAccount, orgPriceAccount, depreciation, depreciationUSD, quantity));
                        }
                        else
                        {
                            if (depreciation == 0)
                                fixedAssetDecrementModels.Add(AddRowDecrementDetail(fixedAssetCurrencyModel, expenseAccount, orgPriceAccount, remainingValue, remainingUSDValue, quantity));
                            else if (remainingValue == 0)
                                fixedAssetDecrementModels.Add(AddRowDecrementDetail(fixedAssetCurrencyModel, depreciationAccount, orgPriceAccount, depreciation, depreciationUSD, quantity));
                            else
                                fixedAssetDecrementModels.Add(AddDoubleDecrementDetail(fixedAssetCurrencyModel, expenseAccount, orgPriceAccount, depreciationAccount, orgPriceAccount, remainingValue, remainingUSDValue, depreciation, depreciationUSD, quantity));
                        }
                    }
                }
                else
                {
                    // Tính số tiền hao mòn, giá trị còn lại theo tiền ĐP
                    FixedAssetModel fixedAsset = _fixedAssetPresenter.GetFADecrement(KeyValue, fixedAssetCurrencyModel.CurrencyCode, new GlobalVariable().PostedDate);
                    if (fixedAsset != null)
                    {
                        if (remainingQuantity - (int)txtDescreaseQuantity.Value == 0)
                        {
                            orgPrice = fixedAsset.RemainingOrgPrice / (decimal)fixedAssetCurrencyModel.ExchangeRate;
                            orgPriceUSD = fixedAsset.RemainingOrgPriceUSD;
                            depreciation = fixedAsset.AccumDepreciationAmount / (decimal)fixedAssetCurrencyModel.ExchangeRate;
                            depreciationUSD = fixedAsset.AccumDepreciationAmountUSD;
                            remainingValue = (orgPrice - depreciation) / (decimal)fixedAssetCurrencyModel.ExchangeRate;
                            remainingUSDValue = (orgPriceUSD - depreciationUSD);
                        }
                        else
                        {
                            orgPrice = fixedAsset.RemainingOrgPrice;
                            orgPriceUSD = fixedAsset.RemainingOrgPrice;
                            depreciation = ((fixedAsset.AccumDepreciationAmount / remainingQuantity) * quantity);
                            depreciationUSD = ((fixedAsset.AccumDepreciationAmount / remainingQuantity) * quantity);
                            remainingValue = ((orgPrice * quantity / remainingQuantity) - depreciation);
                            remainingUSDValue = ((orgPriceUSD * quantity / remainingQuantity) - depreciationUSD);
                        }
                        if (orgPrice == depreciation)
                        {
                            fixedAssetDecrementModels.Add(AddRowDecrementDetail(fixedAssetCurrencyModel, depreciationAccount, orgPriceAccount, depreciation, depreciationUSD, quantity));
                        }
                        else
                        {
                            if (depreciation == 0)
                                fixedAssetDecrementModels.Add(AddRowDecrementDetail(fixedAssetCurrencyModel, expenseAccount, orgPriceAccount, remainingValue, remainingUSDValue, quantity));
                            else
                                fixedAssetDecrementModels.Add(AddDoubleDecrementDetail(fixedAssetCurrencyModel, expenseAccount, orgPriceAccount, depreciationAccount, orgPriceAccount, remainingValue, remainingUSDValue, depreciation, depreciationUSD, quantity));
                        }
                    }
                }
            }
            return _fixedAssetPresenter.SaveFixedAssetDecrements(fixedAssetDecrementModels);
        }

        private void EnableDecresementButton()
        {
            if (ActionMode == ActionModeEnum.Edit)
            {
                string currencyCode = "";
                int remainingQuantity;
                foreach (FixedAssetCurrencyModel fixedAssetCurrency in FixedAssetCurrencies)
                {
                    currencyCode = fixedAssetCurrency.CurrencyCode;
                }
                FixedAssetModel fixedAsetDecrement = _fixedAssetPresenter.GetFADecrement(KeyValue, currencyCode, DecrementRefTypeId);
                if (fixedAsetDecrement == null)
                    remainingQuantity = Quantity;
                else
                    remainingQuantity = Quantity - fixedAsetDecrement.Quantity;
                _quantityOnHand = remainingQuantity;
                bool checkFAIncrement = CheckFixedAsset();
                bool checkFAOpening = CheckFixedAssetOpening();
                if (remainingQuantity <= 0)
                {
                    lblDecreseQuantity.Visible = false;
                    txtDescreaseQuantity.Visible = false;
                    btnDecrement.Visible = false;
                }
                else
                {
                    if ((cboState.SelectedIndex == 3 || cboState.SelectedIndex == 5) && (checkFAIncrement || checkFAOpening))
                    {
                        if (cboState.SelectedIndex == 5)
                        {
                            if (remainingQuantity > 0)
                            {
                                if (FixedAssetCurrencies.Count == 1)
                                {
                                    lblDecreseQuantity.Visible = true;
                                    txtDescreaseQuantity.Visible = true;
                                    btnDecrement.Visible = true;
                                }
                                else
                                {
                                    lblDecreseQuantity.Visible = false;
                                    txtDescreaseQuantity.Visible = false;
                                    btnDecrement.Visible = false;
                                }
                            }
                        }
                        else
                        {
                            lblDecreseQuantity.Visible = false;
                            txtDescreaseQuantity.Visible = false;
                            btnDecrement.Visible = true;
                        }
                    }
                    else
                    {
                        lblDecreseQuantity.Visible = false;
                        txtDescreaseQuantity.Visible = false;
                        btnDecrement.Visible = false;
                    }
                }
            }
        }

        private bool CheckFixedAssetDecrement()
        {
            FixedAssetModel fixedAsset = _fixedAssetPresenter.GetFADecrement(KeyValue, DecrementRefTypeId);
            if (fixedAsset == null) return false;
            return true;
        }

        private bool CheckFixedAssetOpening()
        {
            FixedAssetModel fixedAsset = _fixedAssetPresenter.GetFAOpening(KeyValue);
            if (fixedAsset == null) return false;
            return true;
        }

        #endregion

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintData();
        }

        protected virtual void PrintData()
        {
            try
            {
                ActionMode = ActionModeEnum.None;
                Cursor.Current = Cursors.WaitCursor;
                var reportHelper = new ReportHelper();
                _reportList = _reportListPresenter.GetAllReportList();
                reportHelper.ReportLists = _reportList;

                using (var frmXtraPrintVoucherByLot = new FrmXtraPrintVoucherByLot())
                {
                    frmXtraPrintVoucherByLot.RefType = RefType.FixedAssetDictionary;
                    IList<ReportListModel> reportLists = _reportList.FindAll(item => item.ReportID.Contains("ReportFixedAsset"));
                    frmXtraPrintVoucherByLot.InitComboData(reportLists);
                    frmXtraPrintVoucherByLot.RefID = int.Parse(KeyValue);
                    if (frmXtraPrintVoucherByLot.ShowDialog() == DialogResult.OK)
                    {
                        var refIds = frmXtraPrintVoucherByLot.SelectedFa;
                        var reportVoucherID = frmXtraPrintVoucherByLot.ReportID;
                        reportHelper.CommonVariable = new GlobalVariable
                        {
                            RefIdList = refIds
                        };

                        if (reportVoucherID != null)
                        {
                            reportHelper.PrintPreviewReport(null, reportVoucherID, false);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        public bool CheckBookLock(DateTime refdate, string strNotice)
        {
            if (_lockPresenter.CheckLockDate(-1, 70, refdate))
            {
                XtraMessageBox.Show(strNotice + ". Bạn phải bỏ khóa sổ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }

            return false;
        }

        protected bool ValidDataBeforeIncrement()
        {
            if (lookUpCapitalAccount.EditValue == null)
            {
                XtraMessageBox.Show("Bạn chưa chọn tài khoản tiền nguồn", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //if (grdLookupExpenseAccount.EditValue == null)
            //{
            //    XtraMessageBox.Show("Bạn chưa chọn tài khoản chi phí", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return false;
            //}

            if (gridLookUpArmortizationAccount.EditValue == null)
            {
                XtraMessageBox.Show("Bạn chưa chọn tài khoản hao mòn", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        public List<ReportListModel> ReportLists
        {
            get
            {
                return _reportList;
            }
            set
            {
                _reportList = value;
            }
        }

        #region LockDate

        public string Content { get; set; }

        public DateTime LockDate { get; set; }

        public bool IsLock { get; set; }

        #endregion

        private void gridAccessaryView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                GridView gridView = sender as GridView;
                if (gridView != null)
                {
                    var currencyCode = gridAccessaryView.GetRowCellValue(e.FocusedRowHandle, "CurrencyCode") == null ? "" : gridAccessaryView.GetRowCellValue(e.FocusedRowHandle, "CurrencyCode").ToString();
                    if (currencyCode.Trim().ToUpper() == "USD")
                    {
                        gridAccessaryView.SetRowCellValue(e.FocusedRowHandle, "ExchangeRate", 1);
                        gridAccessaryView.Columns["ExchangeRate"].OptionsColumn.AllowEdit = false;
                    }
                    else
                    {
                        gridAccessaryView.Columns["ExchangeRate"].OptionsColumn.AllowEdit = true;
                    }
                }
            }
            catch (Exception) { }
        }
    }
}
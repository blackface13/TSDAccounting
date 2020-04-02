/***********************************************************************
 * <copyright file="FrmS33H.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK <Sổ Chi tiết các tài khoản>
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: 19 August 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using TSD.AccountingSoft.Report.BaseParameterForm;
using TSD.AccountingSoft.Report.CommonClass;
using TSD.AccountingSoft.Session;
using TSD.AccountingSoft.Presenter.Dictionary.Account;
using TSD.AccountingSoft.Presenter.Dictionary.AccountingObject;
using TSD.AccountingSoft.Presenter.Dictionary.BudgetCategory;
using TSD.AccountingSoft.Presenter.Dictionary.BudgetChapter;
using TSD.AccountingSoft.Presenter.Dictionary.BudgetItem;
using TSD.AccountingSoft.Presenter.Dictionary.BudgetSource;
using TSD.AccountingSoft.Presenter.Dictionary.Customer;
using TSD.AccountingSoft.Presenter.Dictionary.Department;
using TSD.AccountingSoft.Presenter.Dictionary.Employee;
using TSD.AccountingSoft.Presenter.Dictionary.FixedAsset;
using TSD.AccountingSoft.Presenter.Dictionary.InventoryItem;
using TSD.AccountingSoft.Presenter.Dictionary.MergerFund;
using TSD.AccountingSoft.Presenter.Dictionary.Project;
using TSD.AccountingSoft.Presenter.Dictionary.Vendor;
using TSD.AccountingSoft.Presenter.Dictionary.VoucherType;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.View.Dictionary;
using DateTimeRangeBlockDev.Helper;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using System.Linq;
using TSD.AccountingSoft.Presenter.Dictionary.Bank;


namespace TSD.AccountingSoft.Report.ParameterReportForm
{
    /// <summary>
    /// Class FrmS33H.
    /// </summary>
    public partial class FrmS33H : FrmXtraBaseParameter, IAccountsView, IVendorsView, IBudgetSourcesView, IBudgetItemsView,
        ICapitalAllocatesView, ICurrenciesView, IEmployeesView, IFixedAssetsView, IInventoryItemsView,
        IProjectsView, IVoucherTypesView,
        IAccountingObjectsView, IDepartmentsView, IBanksView
    {
        private readonly VendorsPresenter _vendorsPresenter;
        private readonly AccountsPresenter _accountsPresenter;
        private readonly InventoryItemsPresenter _inventoryItemsPresenter;
        private readonly FixedAssetsPresenter _fixedAssetsPresenter;
        private readonly DepartmentsPresenter _departmentsPresenter;
        private readonly EmployeesPresenter _employeesPresenter;
        private readonly BudgetSourcesPresenter _budgetSourcesPresenter;
        private readonly BudgetItemsPresenter _budgetItemsPresenter;
        private readonly VoucherTypesPresenter _voucherTypesPresenter;
        private readonly ProjectsPresenter _projectsPresenter;
        private readonly BanksPresenter _banksPresenter;
        private readonly GlobalVariable _dbOptionHelper;
        private readonly AccountingObjectsPresenter _accountingObjectsPresenter;

        protected string CurrencyAccounting;

        public FrmS33H()
        {
            InitializeComponent();

            dateTimeRangeV1.DateRangePeriodMode = DateRangeMode.Reduce;
            dateTimeRangeV1.InitSelectedIndex = GlobalVariable.DateRangeSelectedIndex;

            _dbOptionHelper = new GlobalVariable();
            CurrencyAccounting = _dbOptionHelper.CurrencyAccounting;
            _accountsPresenter = new AccountsPresenter(this);
            _banksPresenter = new BanksPresenter(this);
            _vendorsPresenter = new VendorsPresenter(this);
            _fixedAssetsPresenter = new FixedAssetsPresenter(this);
            _vendorsPresenter = new VendorsPresenter(this);
            _employeesPresenter = new EmployeesPresenter(this);
            _accountingObjectsPresenter = new AccountingObjectsPresenter(this);
            _accountsPresenter = new AccountsPresenter(this);
            _budgetSourcesPresenter = new BudgetSourcesPresenter(this);
            _budgetItemsPresenter = new BudgetItemsPresenter(this);
            _voucherTypesPresenter = new VoucherTypesPresenter(this);
            _projectsPresenter = new ProjectsPresenter(this);
            _inventoryItemsPresenter = new InventoryItemsPresenter(this);
            _departmentsPresenter = new DepartmentsPresenter(this);
        }

        #region Override functions

        protected override bool ValidData()
        {
            if (dateTimeRangeV1.FromDate.ToString(CultureInfo.InvariantCulture) == "")
            {
                XtraMessageBox.Show("Bạn chưa chọn ngày tính giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (dateTimeRangeV1.ToDate.ToString(CultureInfo.InvariantCulture) == "")
            {
                XtraMessageBox.Show("Bạn chưa chọn ngày tính giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (grdLookUpAccount.Text == "")
            {
                XtraMessageBox.Show("Bạn chưa chọn tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                grdLookUpAccount.Focus();
                return false;
            }
            GlobalVariable.DateRangeSelectedIndex = dateTimeRangeV1.cboDateRange.SelectedIndex;
            return true;
        }

        #endregion

        #region Events

        private void btnOk_Click(object sender, EventArgs e)
        {
            ObjectName = "";
            if (chkAccountingObject.Checked)
            {
                List<AccountingObjectModel> lstAccountingObject = (List<AccountingObjectModel>)cboAccountingObject.Properties.DataSource;
                lstAccountingObject = lstAccountingObject.Where(x => x.AccountingObjectId == int.Parse(cboAccountingObject.EditValue.ToString())).ToList();
                ObjectName = "Đối tượng khác - Đối tượng khác: " + cboAccountingObject.Text.ToString() + " - " + lstAccountingObject[0].FullName;
            }

            if (chkEmployee.Checked)
            {

                List<EmployeeModel> lstmEmployee = (List<EmployeeModel>)cboEmployee.Properties.DataSource;
                lstmEmployee = lstmEmployee.Where(x => x.EmployeeId == int.Parse(cboEmployee.EditValue.ToString())).ToList();
                ObjectName = "Đối tượng khác - Nhân viên: " + cboEmployee.Text.ToString() + " - " + lstmEmployee[0].EmployeeName;
            }

            if (chkVendor.Checked)
            {

                List<VendorModel> lstmVendor = (List<VendorModel>)cboVendor.Properties.DataSource;
                lstmVendor = lstmVendor.Where(x => x.VendorId == int.Parse(cboVendor.EditValue.ToString())).ToList();
                ObjectName = "Đối tượng khác - Nhà cung cấp: " + cboVendor.Text.ToString() + " - " + lstmVendor[0].VendorName;
            }

            if (chkBank.Checked)
            {
                var objBank = (BankModel)cboBank.GetSelectedDataRow();
                if (objBank != null)
                    ObjectName = string.Format("Ngân hàng:{0} - Số tài khoản: {1}", objBank.BankName, objBank.BankAccount);
            }


        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void FrmS33H_Load(object sender, EventArgs e)
        {
            _vendorsPresenter.Display();
            _accountsPresenter.Display();
            _inventoryItemsPresenter.Display();
            _budgetSourcesPresenter.Display();
            _budgetItemsPresenter.Display();
            _accountingObjectsPresenter.Display();
            _voucherTypesPresenter.Display();
            _projectsPresenter.Display();
            _employeesPresenter.Display();
            _accountingObjectsPresenter.Display();
            _voucherTypesPresenter.Display();
            _departmentsPresenter.Display();
            _fixedAssetsPresenter.Display();
            _banksPresenter.DisplayActive();
            InitDefaultCurrencies();
            chkCurrency.Checked = false;

            // Ẩn theo nghiệp vụ mới từ BA
            chkCurrency.Enabled = false;
            chkProject.Enabled = false;
            chkInventoryItem.Enabled = false;
            chkVendor.Enabled = false;
        }
        private void FormatCombo_QueryPopUp(object sender, CancelEventArgs e)
        {
            var edit = sender as LookUpEdit;
            if (edit != null) edit.Properties.PopupFormMinSize = new Size(500, 400);
        }

        #endregion

        #region Functions

        protected void InitDefaultCurrencies()
        {
            var lstCurrencies = new List<CurrencyModel>();
            lstCurrencies = CurrencyAccounting != _dbOptionHelper.CurrencyLocal
                ? new List<CurrencyModel>
                {
                    new CurrencyModel(){ CurrencyCode =  _dbOptionHelper.CurrencyLocal, CurrencyName = _dbOptionHelper.CurrencyLocal },
                    new CurrencyModel(){ CurrencyCode =  CurrencyAccounting, CurrencyName = CurrencyAccounting }
                }
                : new List<CurrencyModel>
                {
                    new CurrencyModel() { CurrencyCode = CurrencyAccounting, CurrencyName = CurrencyAccounting }
                };

            Currencies = lstCurrencies;

            // Ẩn tiền tệ theo nghiệp vụ mới từ BA
            //cboCurrency.EditValue = CurrencyAccounting;

        }
        private string GetWhereClause()
        {
            string whereClause = "";
            if (grdLookUpCorrespondingAccount.Text != "")
            {
                whereClause = whereClause + " CorrespondingAccountNumber = " + "'" + grdLookUpCorrespondingAccount.Text + "'" + " AND ";
            }

            if (cboVendor.Text != "")
            {
                whereClause = whereClause + " VendorId = " + Convert.ToString(cboVendor.EditValue) + " AND ";

            }

            if (cboEmployee.Text != "")
            {
                whereClause = whereClause + " EmployeeId = " + Convert.ToString(cboEmployee.EditValue) + " AND ";

            }

            if (cboAccountingObject.Text != "")
            {
                whereClause = whereClause + " AccountingObjectId = " + Convert.ToString(cboAccountingObject.EditValue) + " AND ";
            }


            if (cboBudgetSource.Text != "")
            {
                whereClause = whereClause + " BudgetSourceCode = " + "'" + Convert.ToString(cboBudgetSource.EditValue) + "'" + " AND ";
            }

            if (cboBudgetSubItem.Text != "")
            {
                whereClause = whereClause + " BudgetItemCode = " + "'" + Convert.ToString(cboBudgetSubItem.EditValue) + "'" + " AND ";
            }

            if (cboProject.Text != "")
            {
                whereClause = whereClause + " ProjectId = " + Convert.ToString(cboProject.EditValue) + " AND ";
            }

            if (cboInventoryItem.Text != "")
            {
                whereClause = whereClause + " InventoryItemId = " + Convert.ToString(cboInventoryItem.EditValue) + " AND ";
            }

            //if (cboFixedAsset.Text != "")
            //{
            //    whereClause = whereClause + " FixedAssetId = " + Convert.ToString(cboFixedAsset.EditValue) + " AND ";
            //}

            if (cboVoucherType.Text != "")
            {
                whereClause = whereClause + " VoucherTypeId = " + Convert.ToString(cboVoucherType.EditValue) + " AND ";

            }

            if (chkBank.Checked)
            {
                if (cboBank.Text != "")
                {
                    whereClause = whereClause + " BankID = " + Convert.ToString(cboBank.EditValue) + " AND ";

                }

            }


            if (whereClause != "")
            {
                whereClause = whereClause + @" 1 = 1 ";
            }
            return whereClause;
        }
        private string GetSelectedField()
        {
            string selectedField = "";

            if (chkVendor.Checked)
            {
                selectedField = selectedField + " Vendor";
            }

            if (chkEmployee.Checked)
            {
                selectedField = selectedField + ',' + " Employee";
            }

            if (chkAccountingObject.Checked)
            {
                selectedField = selectedField + ',' + " AccountingObject";
            }

            if (chkBudgetSource.Checked)
            {
                selectedField = selectedField + ',' + " BudgetSource";
            }

            if (chkBudgetItem.Checked)
            {
                selectedField = selectedField + ',' + " BudgetItem";
            }

            if (chkProject.Checked)
            {
                selectedField = selectedField + ',' + " Project";
            }

            if (chkInventoryItem.Checked)
            {
                selectedField = selectedField + ',' + " InventoryItem";
            }

            if (chkFixedAsset.Checked)
            {
                selectedField = selectedField + ',' + " FixedAsset";
            }

            if (chkVoucherType.Checked)
            {
                selectedField = selectedField + ',' + " VoucherType";
            }

            if (chkBank.Checked)
            {
                selectedField = selectedField + ',' + " Bank";
            }

            return selectedField;
        }
        private string GetSelectedAllValueField()
        {
            string selectedAllValueField = "";

            if (chkVendor.Checked)
            {
                selectedAllValueField = selectedAllValueField + " Vendor";
            }

            if (chkEmployee.Checked)
            {
                selectedAllValueField = selectedAllValueField + ',' + " Employee";
            }

            if (chkAccountingObject.Checked)
            {
                selectedAllValueField = selectedAllValueField + ',' + " AccountingObject";
            }

            if (chkBudgetSource.Checked)
            {
                selectedAllValueField = selectedAllValueField + ',' + " BudgetSource";
            }

            if (chkBudgetItem.Checked)
            {
                selectedAllValueField = selectedAllValueField + ',' + " BudgetItem";
            }

            if (chkProject.Checked)
            {
                selectedAllValueField = selectedAllValueField + ',' + " Project";
            }

            if (chkInventoryItem.Checked)
            {
                selectedAllValueField = selectedAllValueField + ',' + " InventoryItem";
            }

            if (chkFixedAsset.Checked)
            {
                selectedAllValueField = selectedAllValueField + ',' + " FixedAsset";
            }

            if (chkVoucherType.Checked)
            {
                selectedAllValueField = selectedAllValueField + ',' + " VoucherType";
            }

            if (chkBank.Checked)
            {
                selectedAllValueField = selectedAllValueField + ',' + " Bank";
            }

            return selectedAllValueField;
        }

        #endregion

        #region Property Form

        public string WhereClause
        {
            get
            {
                var clause = GetWhereClause();
                if (clause == "")
                {
                    clause = " 1 = 1 ";
                }
                return clause;
            }
        }
        public string BudgetGroupCode
        {
            get
            {
                return cboBudgetItem.EditValue.ToString();
            }
        }
        public string FixedAssetCode
        {
            get
            {

                return cboFixedAsset.EditValue.ToString();
            }
        }
        public string DepartmentCode
        {
            get
            {
                return cboDepartment.EditValue.ToString();
            }
        }
        public string ObjectName { get; set; }
        public string SelectedField
        {
            get
            {
                var selectedField = GetSelectedField();
                return selectedField;
            }
        }
        public string SelectedAllValueField
        {
            get
            {
                var selectedAllValueField = GetSelectedAllValueField();
                return selectedAllValueField;
            }
        }
        public string FromDate
        {
            get
            {
                return dateTimeRangeV1.FromDate.ToShortDateString();
            }
        }
        public string CurrencyCode
        {
            get
            {
                return (cboCurrency.EditValue ?? "").ToString();
            }
        }
        public string AccountCode
        {
            get
            {
                if (grdLookUpAccount.Text == "")
                {
                    return " ";
                }
                return (grdLookUpAccount.EditValue ?? "").ToString();//.GetColumnValue("AccountCode").ToString();
            }
        }
        public string VendorId
        {
            get
            {
                if (cboVendor.Text == "")
                {
                    return " ";
                }
                return (cboVendor.EditValue ?? "").ToString();
            }
        }
        public string VendorName
        {
            get
            {
                if (cboVendor.Text == "")
                {
                    return " ";
                }
                return (cboVendor.GetSelectedDataRow() as VendorModel)?.VendorName ?? "";
            }
        }
        public string EmployeeName
        {
            get
            {
                if (cboEmployee.Text == "")
                {
                    return " ";
                }
                return (cboEmployee.GetSelectedDataRow() as EmployeeModel)?.EmployeeName ?? "";
            }
        }
        public string FullName
        {
            get
            {
                if (cboAccountingObject.Text == "")
                {
                    return " ";
                }
                return (cboAccountingObject.GetSelectedDataRow() as AccountingObjectModel)?.FullName ?? "";
            }
        }
        public string EmployeeId
        {
            get
            {
                if (cboEmployee.Text == "")
                {
                    return " ";
                }
                return (cboEmployee.EditValue ?? "").ToString();
            }
        }
        public string AccountingObjectId
        {
            get
            {
                if (cboAccountingObject.Text == "")
                {
                    return " ";
                }
                return (cboAccountingObject.EditValue ?? "").ToString();
            }
        }
        public string AccountName
        {
            get
            {
                if (grdLookUpAccount.Text == "")
                {
                    return " ";
                }
                return (grdLookUpAccount.GetSelectedDataRow() as AccountModel)?.AccountName ?? "";
            }
        }
        public string ToDate
        {
            get
            {
                return dateTimeRangeV1.ToDate.ToShortDateString();
            }
        }
        public bool IsTotalBandInNewPage
        {
            get { return chkMoveTotalInNewPage.Checked; }
            set { chkMoveTotalInNewPage.Checked = value; }
        }

        #endregion

        #region Combobox

        public IList<AccountModel> Accounts
        {
            set
            {
                if (value == null)
                    value = new List<AccountModel>();
                var gridColumnsCollection = new List<XtraColumn>
                {
                    new XtraColumn{ColumnName = "AccountCode",ColumnCaption = "Mã tài khoản",ColumnPosition = 1,ColumnVisible = true, ColumnWith = 25,Alignment = HorzAlignment.Center },
                    new XtraColumn { ColumnName = "AccountName",ColumnCaption = "Tên tài khoản",ColumnVisible = true,ColumnPosition = 2,ColumnWith = 75,Alignment = HorzAlignment.Center }
                };

                GridLookUpItem.HideVisibleColumn(value, gridColumnsCollection, grdLookUpAccount, grdLookUpAccountView, "AccountCode", "AccountCode");
                GridLookUpItem.HideVisibleColumn(value, gridColumnsCollection, grdLookUpCorrespondingAccount, grdLookUpCorrespondingAccountView, "AccountCode", "AccountCode");

                grdLookUpAccount.Enter += gridLookUpEdit_Enter;
                grdLookUpCorrespondingAccount.Enter += gridLookUpEdit_Enter;
            }
        }
        public IList<VendorModel> Vendors
        {
            set
            {
                if (value == null)
                    value = new List<VendorModel>();
                var gridColumnsCollection = new List<XtraColumn>
                {
                    new XtraColumn { ColumnName = "VendorCode", ColumnCaption = "Mã nhà cung cấp", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 25 },
                    new XtraColumn { ColumnName = "VendorName", ColumnCaption = "Tên nhà cung cấp", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 75},
                };

                GridLookUpItem.HideVisibleColumn(value, gridColumnsCollection, cboVendor, cboVendorView, "VendorCode", "VendorId");

                cboVendor.Enter += gridLookUpEdit_Enter;
            }
        }
        public IList<BudgetSourceModel> BudgetSources
        {
            set
            {
                if (value == null)
                    value = new List<BudgetSourceModel>();
                else
                    value = value.Where(x => x.IsParent == false).ToList();
                var gridColumnsCollection = new List<XtraColumn>
                {
                    new XtraColumn { ColumnName = "BudgetSourceCode", ColumnCaption = "Mã nguồn vốn", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 100, Alignment = HorzAlignment.Center },
                    new XtraColumn { ColumnName = "BudgetSourceName", ColumnCaption = "Tên nguồn vốn", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 400, Alignment = HorzAlignment.Center },
                };

                GridLookUpItem.HideVisibleColumn(value, gridColumnsCollection, cboBudgetSource, cboBudgetSourceView, "BudgetSourceCode", "BudgetSourceCode");
                cboBudgetSource.Enter += gridLookUpEdit_Enter;
            }
        }
        public IList<BudgetItemModel> BudgetItems
        {
            set
            {
                // nhóm mục
                var lstBudgetItems = value == null ? new List<BudgetItemModel>() : value.Where(x => x.BudgetItemType <= 2 && x.IsActive == true).ToList();

                var gridColumnsCollection = new List<XtraColumn>
                {
                    new XtraColumn { ColumnName = "BudgetItemCode", ColumnCaption = "Mã nhóm mục", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 100, Alignment=HorzAlignment.Center},
                    new XtraColumn { ColumnName = "BudgetItemName", ColumnCaption = "Tên nhóm mục", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 400, Alignment = HorzAlignment.Center},
                };

                GridLookUpItem.HideVisibleColumn(lstBudgetItems, gridColumnsCollection, cboBudgetItem, cboBudgetItemView, "BudgetItemCode", "BudgetItemCode");

                cboBudgetItem.Enter += gridLookUpEdit_Enter;

                // mục - tiểu mục
                var lstBudgetSubItems = value == null ? new List<BudgetItemModel>() : value.Where(x => x.BudgetItemType >= 3 && x.IsActive == true).ToList();
                gridColumnsCollection = new List<XtraColumn>
                {
                    new XtraColumn { ColumnName = "BudgetItemCode", ColumnCaption = "Mã MLNS", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 100, Alignment=HorzAlignment.Center},
                    new XtraColumn { ColumnName = "BudgetItemName", ColumnCaption = "Tên MLNS", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 400, Alignment = HorzAlignment.Center},
                };

                GridLookUpItem.HideVisibleColumn(lstBudgetSubItems, gridColumnsCollection, cboBudgetSubItem, cboBudgetSubItemView, "BudgetItemCode", "BudgetItemCode");

                cboBudgetSubItem.Enter += gridLookUpEdit_Enter;
            }
        }
        public IList<EmployeeModel> Employees
        {
            set
            {
                value = value == null ? new List<EmployeeModel>() : value.OrderBy(x => x.EmployeeCode).ToList();
                var gridColumnsCollection = new List<XtraColumn>
                {
                    new XtraColumn { ColumnName = "EmployeeCode", ColumnCaption = "Mã nhân viên", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 100 },
                    new XtraColumn { ColumnName = "EmployeeName", ColumnCaption = "Tên nhân viên", ColumnPosition = 2, ColumnVisible = true, ColumnWith =400 },
                };

                GridLookUpItem.HideVisibleColumn(value, gridColumnsCollection, cboEmployee, cboEmployeeView, "EmployeeCode", "EmployeeId");

                cboEmployee.Enter += gridLookUpEdit_Enter;
            }
        }
        public IList<CurrencyModel> Currencies
        {
            set
            {
                if (value == null)
                    value = new List<CurrencyModel>();
                var gridColumnsCollection = new List<XtraColumn>
                {
                    new XtraColumn { ColumnName = "CurrencyCode", ColumnCaption = "Mã tiền tệ", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 100 },
                    new XtraColumn { ColumnName = "CurrencyName", ColumnCaption = "Tên tiền tệ", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 400 },
                };

                GridLookUpItem.HideVisibleColumn(value, gridColumnsCollection, cboCurrency, cboCurrencyView, "CurrencyCode", "CurrencyCode");

                cboCurrency.Enter += gridLookUpEdit_Enter;
            }
        }
        public IList<CapitalAllocateModel> CapitalAllocates
        {
            set
            {
                //value = value == null ? new List<CapitalAllocateModel>() : value.ToList();
                //var gridColumnsCollection = new List<XtraColumn>
                //{
                //    new XtraColumn { ColumnName = "CapitalAllocateCode", ColumnCaption = "Mã phân bổ", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 70 },            
                //    new XtraColumn { ColumnName = "BudgetItemCode", ColumnCaption = "Khoản thu", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 70 },
                //    new XtraColumn { ColumnName = "BudgetSourceCode", ColumnCaption = "Quỹ", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 70 },
                //    new XtraColumn { ColumnName = "Description", ColumnCaption = "Diễn giải", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 280 },
                //    new XtraColumn { ColumnName = "FromDate", ColumnCaption = "Từ ngày", ColumnPosition = 5, ColumnVisible = true, ColumnWith = 70 },
                //    new XtraColumn { ColumnName = "ToDate", ColumnCaption = "Đến ngày", ColumnPosition = 6, ColumnVisible = true, ColumnWith = 70 },
                //};

                //GridLookUpItem.HideVisibleColumn(value, gridColumnsCollection, cboBudgetChapter, cboBudgetChapterView, "CapitalAllocateCode", "CapitalAllocateId", new GridLookUpItemOption()
                //{
                //    IsAutoPopupSize = true
                //});

                //cboBudgetChapter.Enter += gridLookUpEdit_Enter;
            }
        }
        public IList<ProjectModel> Projects
        {
            set
            {
                value = value == null ? new List<ProjectModel>() : value.OrderBy(x => x.ProjectCode).ToList();
                var gridColumnsCollection = new List<XtraColumn>
                {
                    new XtraColumn { ColumnName = "ProjectCode", ColumnCaption = "Mã dự án", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 100 },
                    new XtraColumn { ColumnName = "ProjectName", ColumnCaption = "Tên dự án", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 400 },
                };

                GridLookUpItem.HideVisibleColumn(value, gridColumnsCollection, cboProject, cboProjectView, "ProjectCode", "ProjectId");

                cboProject.Enter += gridLookUpEdit_Enter;
            }
        }
        public IList<InventoryItemModel> InventoryItems
        {
            set
            {
                value = value == null ? new List<InventoryItemModel>() : value.OrderBy(x => x.InventoryItemCode).ToList();
                var gridColumnsCollection = new List<XtraColumn>
                {
                    new XtraColumn { ColumnName = "InventoryItemCode", ColumnCaption = "Mã vật tư", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 25 },
                    new XtraColumn { ColumnName = "InventoryItemName", ColumnCaption = "Tên vật tư", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 75 },
                };

                GridLookUpItem.HideVisibleColumn(value, gridColumnsCollection, cboInventoryItem, cboInventoryItemView, "InventoryItemCode", "InventoryItemId");

                cboInventoryItem.Enter += gridLookUpEdit_Enter;
            }
        }
        public IList<FixedAssetModel> FixedAssets
        {
            set
            {
                value = value == null ? new List<FixedAssetModel>() : value.OrderBy(x => x.FixedAssetCode).ToList();
                var gridColumnsCollection = new List<XtraColumn>
                {
                    new XtraColumn { ColumnName = "FixedAssetCode", ColumnCaption = "Mã tài sản", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 25 },
                    new XtraColumn { ColumnName = "FixedAssetName", ColumnCaption = "Tên tài sản", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 75 },
                };

                GridLookUpItem.HideVisibleColumn(value, gridColumnsCollection, cboFixedAsset, cboFixedAssetView, "FixedAssetCode", "FixedAssetCode");

                cboFixedAsset.Enter += gridLookUpEdit_Enter;
            }
        }
        public IList<VoucherTypeModel> VoucherTypes
        {
            set
            {
                if (value == null)
                    value = new List<VoucherTypeModel>();
                value = value.Where(w => w.IsActive == true).ToList();
                var gridColumnsCollection = new List<XtraColumn>
                {
                    new XtraColumn { ColumnName = "VoucherTypeName", ColumnCaption = "Tên nghiệp vụ", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 100 },
                };

                GridLookUpItem.HideVisibleColumn(value, gridColumnsCollection, cboVoucherType, cboVoucherTypeView, "VoucherTypeName", "VoucherTypeId");

                cboVoucherType.Enter += gridLookUpEdit_Enter;
            }
        }
        public IList<AccountingObjectModel> AccountingObjects
        {
            set
            {
                if (value == null)
                    value = new List<AccountingObjectModel>();
                else
                    value = value.OrderBy(x => x.AccountingObjectCode).ToList();
                var gridColumnsCollection = new List<XtraColumn>
                {
                    new XtraColumn { ColumnName = "AccountingObjectCode", ColumnCaption = "Mã đối tượng", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 25 },
                    new XtraColumn { ColumnName = "FullName", ColumnCaption = "Tên đối tượng", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 75 },
                };

                GridLookUpItem.HideVisibleColumn(value, gridColumnsCollection, cboAccountingObject, cboAccountingObjectView, "AccountingObjectCode", "AccountingObjectId");

                cboAccountingObject.Enter += gridLookUpEdit_Enter;
            }
        }
        public IList<DepartmentModel> Departments
        {
            set
            {
                if (value == null)
                    value = new List<DepartmentModel>();
                else
                    value = value.OrderBy(x => x.DepartmentCode).ToList();
                var gridColumnsCollection = new List<XtraColumn>
                {
                    new XtraColumn { ColumnName = "DepartmentCode", ColumnCaption = "Mã phòng ban", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 25 },
                    new XtraColumn { ColumnName = "DepartmentName", ColumnCaption = "Tên phòng ban", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 75 },
                };

                GridLookUpItem.HideVisibleColumn(value, gridColumnsCollection, cboDepartment, cboDepartmentView, "DepartmentCode", "DepartmentCode");

                cboDepartment.Enter += gridLookUpEdit_Enter;
            }
        }
        public IList<BankModel> Banks
        {
            set
            {
                if (value == null)
                    value = new List<BankModel>();
                var gridColumnsCollection = new List<XtraColumn>
                {
                    new XtraColumn { ColumnName = "BankAccount", ColumnCaption = "Số TK", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 25 },
                    new XtraColumn { ColumnName = "BankName", ColumnCaption = "Số TK", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 75 },
                };

                GridLookUpItem.HideVisibleColumn(value, gridColumnsCollection, cboBank, cboBankView, "BankName", "BankId");

                cboBank.Enter += gridLookUpEdit_Enter;
            }
        }

        #endregion

        #region Events Checkbox 

        private void chkVendor_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVendor.Checked)
            {
                cboVendor.Enabled = true;
            }
            else
            {
                cboVendor.EditValue = null;
                cboVendor.Enabled = false;
            }
        }
        private void chkEmployee_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEmployee.Checked)
            {
                cboEmployee.Enabled = true;
            }
            else
            {
                cboEmployee.EditValue = null;
                cboEmployee.Enabled = false;
            }
        }
        private void chkAccountingObject_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAccountingObject.Checked)
            {
                cboAccountingObject.Enabled = true;
            }
            else
            {
                cboAccountingObject.EditValue = null;
                cboAccountingObject.Enabled = false;
            }
        }
        private void chkDepartment_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDepartment.Checked)
            {
                cboDepartment.Enabled = true;
            }
            else
            {
                cboDepartment.EditValue = null;
                cboDepartment.Enabled = false;
            }
        }
        private void chkBudgetSource_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBudgetSource.Checked)
            {
                cboBudgetSource.Enabled = true;
            }
            else
            {
                cboBudgetSource.EditValue = null;
                cboBudgetSource.Enabled = false;
            }
        }
        private void chkBudgetItemForNhom_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBudgetItemForNhom.Checked)
            {
                cboBudgetItem.Enabled = true;
            }
            else
            {
                cboBudgetItem.EditValue = null;
                cboBudgetItem.Enabled = false;
            }
        }
        private void chkBudgetItem_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBudgetItem.Checked)
            {
                cboBudgetSubItem.Enabled = true;
            }
            else
            {
                cboBudgetSubItem.EditValue = null;
                cboBudgetSubItem.Enabled = false;
            }
        }
        private void chkProject_CheckedChanged(object sender, EventArgs e)
        {
            if (chkProject.Checked)
            {
                cboProject.Enabled = true;
            }
            else
            {
                cboProject.EditValue = null;
                cboProject.Enabled = false;
            }
        }
        private void chkInventoryItem_CheckedChanged(object sender, EventArgs e)
        {
            if (chkInventoryItem.Checked)
            {
                cboInventoryItem.Enabled = true;
            }
            else
            {
                cboInventoryItem.EditValue = null;
                cboInventoryItem.Enabled = false;
            }
        }
        private void chkFixedAsset_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFixedAsset.Checked)
            {
                cboFixedAsset.Enabled = true;
            }
            else
            {
                cboFixedAsset.EditValue = null;
                cboFixedAsset.Enabled = false;
            }
        }
        private void chkVoucherType_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVoucherType.Checked)
            {
                cboVoucherType.Enabled = true;
            }
            else
            {
                cboVoucherType.EditValue = null;
                cboVoucherType.Enabled = false;
            }
        }
        private void chkBank_CheckedChanged(object sender, EventArgs e)
        {
            cboBank.Enabled = chkBank.Checked;
        }

        #endregion
    }
}
/***********************************************************************
 * <copyright file="FrmXtraOpeningAccountEntryDetail.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 24 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TSD.AccountingSoft.Session;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Model.BusinessObjects.Opening;
using TSD.AccountingSoft.Presenter.Dictionary.Account;
using TSD.AccountingSoft.Presenter.Dictionary.AccountingObject;
using TSD.AccountingSoft.Presenter.Dictionary.Bank;
using TSD.AccountingSoft.Presenter.Dictionary.BudgetCategory;
using TSD.AccountingSoft.Presenter.Dictionary.BudgetChapter;
using TSD.AccountingSoft.Presenter.Dictionary.BudgetItem;
using TSD.AccountingSoft.Presenter.Dictionary.BudgetSource;
using TSD.AccountingSoft.Presenter.Dictionary.Customer;
using TSD.AccountingSoft.Presenter.Dictionary.Employee;
using TSD.AccountingSoft.Presenter.Dictionary.MergerFund;
using TSD.AccountingSoft.Presenter.Dictionary.Vendor;
using TSD.AccountingSoft.Presenter.Opening;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.View.OpeningAccountEntry;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.Resources;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using TSD.AccountingSoft.Presenter.Dictionary.Project;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using TSD.AccountingSoft.WindowsForm.CommonClass;
using DevExpress.XtraGrid.Columns;

namespace TSD.AccountingSoft.WindowsForm.FormBusiness
{
    /// <summary>
    /// FrmXtraOpeningAccountEntryDetail
    /// </summary>
    public partial class FrmXtraOpeningAccountEntryDetail : FrmXtraBaseTreeDetail, IOpeningAccountEntryView, IAccountsView, IBudgetSourcesView, IBudgetItemsView,
        IBudgetChaptersView, IBudgetCategoriesView, IMergerFundsView, IEmployeesView, ICustomersView, IVendorsView, IAccountingObjectsView, IProjectsView, IBanksView
    {
        #region Presenter

        private readonly OpeningAccountEntryPresenter _openingAccountEntryPresenter;
        private readonly AccountsPresenter _accountsPresenter;
        private readonly BanksPresenter _banksPresenter;
        private readonly BudgetSourcesPresenter _budgetSourcesPresenter;
        private readonly BudgetItemsPresenter _budgetItemsPresenter;
        private readonly BudgetChaptersPresenter _budgetChaptersPresenter;
        private readonly BudgetCategoriesPresenter _budgetCategoriesPresenter;
        private readonly EmployeesPresenter _employeesPresenter;
        private readonly CustomersPresenter _customersPresenter;
        private readonly VendorsPresenter _vendorsPresenter;
        private readonly MergerFundsPresenter _mergerFundsPresenter;
        private readonly AccountingObjectsPresenter _accountingObjectsPresenter;
        private readonly ProjectsPresenter _projectsPresenter;
        private IList<AccountModel> _accounts;
        private AccountModel _account;
        #endregion

        #region Repository Controls

        private RepositoryItemGridLookUpEdit _gridLookUpEditBank;
        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetChapter;
        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetCategory;
        private RepositoryItemGridLookUpEdit _gridLookUpEditMergerFund;
        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSource;
        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetItem;
        private RepositoryItemGridLookUpEdit _gridLookUpEditEmployee;
        private RepositoryItemGridLookUpEdit _gridLookUpEditGroupBudgetItem;
        private RepositoryItemGridLookUpEdit _gridLookUpEditCustomer;
        private RepositoryItemGridLookUpEdit _gridLookUpEditAccountingObject;
        private RepositoryItemGridLookUpEdit _gridLookUpEditVendor;
        private RepositoryItemComboBox _cboCurrencyCode;
        private RepositoryItemCalcEdit _calcEditExchangeRate;
        //private RepositoryItemGridLookUpEdit _gridLookUpEditProject;

        #endregion

        #region Combobox Members

        public IList<BudgetSourceModel> BudgetSources
        {
            set
            {
                try
                {
                    if (value == null)
                        value = new List<BudgetSourceModel>();
                    _gridLookUpEditBudgetSource.KeyDown += repositoryItemGridLookUpEdit_KeyDown;

                    GridLookUpItem.BudgetSource(value, _gridLookUpEditBudgetSource, "BudgetSourceCode", "BudgetSourceCode");
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public IList<BudgetChapterModel> BudgetChapters
        {
            set
            {
                try
                {
                    if (value == null)
                        value = new List<BudgetChapterModel>();
                    _gridLookUpEditBudgetChapter.KeyDown += repositoryItemGridLookUpEdit_KeyDown;

                    GridLookUpItem.BudgetChapter(value, _gridLookUpEditBudgetChapter, "BudgetChapterCode", "BudgetChapterCode");
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public IList<BudgetCategoryModel> BudgetCategories
        {
            set
            {
                try
                {
                    if (value == null)
                        value = new List<BudgetCategoryModel>();
                    _gridLookUpEditBudgetCategory.KeyDown += repositoryItemGridLookUpEdit_KeyDown;

                    GridLookUpItem.BudgetCategory(value, _gridLookUpEditBudgetCategory, "BudgetCategoryCode", "BudgetCategoryCode");
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public IList<BudgetItemModel> BudgetItems
        {
            set
            {
                try
                {
                    if (value == null) 
                        value = new List<BudgetItemModel>();
                    var budgetItemGroups = value.Where(x => (x.BudgetItemType == 1 || x.BudgetItemType == 2) && x.IsActive).ToList();
                    var budgetItems = value.Where(x => (x.BudgetItemType == 4 || (x.BudgetItemType == 3 && x.IsShowOnVoucher == true)) && x.IsActive == true).ToList();

                    _gridLookUpEditBudgetItem.KeyDown += repositoryItemGridLookUpEdit_KeyDown;
                    _gridLookUpEditGroupBudgetItem.KeyDown += repositoryItemGridLookUpEdit_KeyDown;

                    GridLookUpItem.BudgetItem(budgetItems, _gridLookUpEditBudgetItem, "BudgetItemCode", "BudgetItemCode");
                    GridLookUpItem.BudgetItem(budgetItemGroups, _gridLookUpEditGroupBudgetItem, "BudgetItemCode", "BudgetItemCode");
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public IList<MergerFundModel> MergerFunds
        {
            set
            {
                try
                {
                    if (value == null)
                        value = new List<MergerFundModel>();

                    _gridLookUpEditMergerFund.KeyDown += repositoryItemGridLookUpEdit_KeyDown;

                    GridLookUpItem.MergerFund(value, _gridLookUpEditMergerFund, "MergerFundCode", "MergerFundId");
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public IList<EmployeeModel> Employees
        {
            set
            {
                try
                {
                    if (value == null)
                        value = new List<EmployeeModel>();

                    _gridLookUpEditEmployee.KeyDown += repositoryItemGridLookUpEdit_KeyDown;

                    GridLookUpItem.Employee(value, _gridLookUpEditEmployee, "EmployeeCode", "EmployeeId");
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public List<CustomerModel> Customers
        {
            set
            {
                try
                {
                    if (value == null)
                        value = new List<CustomerModel>();

                    _gridLookUpEditCustomer.KeyDown += repositoryItemGridLookUpEdit_KeyDown;

                    GridLookUpItem.Customer(value, _gridLookUpEditCustomer, "CustomerCode", "CustomerId");
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public IList<VendorModel> Vendors
        {
            set
            {
                try
                {
                    if (value == null)
                        value = new List<VendorModel>();

                    _gridLookUpEditVendor.KeyDown += repositoryItemGridLookUpEdit_KeyDown;

                    GridLookUpItem.Vendor(value, _gridLookUpEditVendor, "VendorCode", "VendorId");
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public IList<AccountingObjectModel> AccountingObjects
        {
            set
            {
                try
                {
                    if (value == null)
                        value = new List<AccountingObjectModel>();

                    _gridLookUpEditAccountingObject.KeyDown += repositoryItemGridLookUpEdit_KeyDown;

                    GridLookUpItem.AccountingObject(value, _gridLookUpEditAccountingObject, "AccountingObjectCode", "AccountingObjectId");
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public IList<AccountModel> Accounts
        {
            set { _accounts = value; }
        }

        public IList<ProjectModel> Projects
        {
            set
            {
                //try
                //{
                //    if (value == null)
                //        value = new List<ProjectModel>();

                //    _gridLookUpEditProject.KeyDown += repositoryItemGridLookUpEdit_KeyDown;

                //    GridLookUpItem.Project(value, _gridLookUpEditProject, "ProjectCode", "ProjectId");
                //}
                //catch (Exception ex)
                //{
                //    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
            }
        }

        public IList<BankModel> Banks
        {
            set
            {
                try
                {
                    if (value == null)
                        value = new List<BankModel>();
                    _gridLookUpEditBank.KeyDown += repositoryItemGridLookUpEdit_KeyDown;

                    GridLookUpItem.Bank(value, _gridLookUpEditBank, "BankAccount", "BankId");
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region OpeningAccountEntry Members

        public IList<OpeningAccountEntryDetailModel> OpeningAccountEntryDetails
        {
            set
            {
                bindingSourceDetail.DataSource = value.Count == 0 ? new List<OpeningAccountEntryDetailModel>() : value.OrderBy(o=>o.AccountCode).ToList();
                gridViewDetail.PopulateColumns(value);

                var gridColumnsCollection = new List<XtraColumn>
                {
                    new XtraColumn {ColumnName = "AccountCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AccountName", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AccountId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ParentId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "RefDetailId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "RefTypeId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "PostedDate", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AccountBeginningDebitAmountOC", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AccountBeginningCreditAmountOC", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AccountBeginningDebitAmountExchange", ColumnVisible = false},
                    new XtraColumn {ColumnName = "AccountBeginningCreditAmountExchange", ColumnVisible = false},
                    //  new XtraColumn {ColumnName = "BankId", ColumnVisible = false},
                    //new XtraColumn {ColumnName = "ProjectId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Account", ColumnVisible = false},
                    //new XtraColumn { ColumnName = "BankId", ColumnCaption = "Tài khoản Ngân hàng", ColumnPosition = 39, ColumnVisible = true, ColumnWith = 130, 
                    //       RepositoryControl = _gridLookUpEditBank},
                    _account.IsBudgetSource ? new XtraColumn { ColumnName = "BudgetSourceCode", ColumnCaption = "Nguồn vốn", ColumnPosition = 7, ColumnVisible = true, ColumnWith = 130, RepositoryControl = _gridLookUpEditBudgetSource } : new XtraColumn { ColumnName = "BudgetSourceCode", ColumnVisible = false},
                    _account.IsChapter ? new XtraColumn { ColumnName = "BudgetChapterCode", ColumnCaption = "Chương", ColumnPosition = 8, ColumnVisible = true, ColumnWith = 130, RepositoryControl = _gridLookUpEditBudgetChapter } : new XtraColumn { ColumnName = "BudgetChapterCode", ColumnVisible = false},
                    _account.IsBudgetCategory ? new XtraColumn { ColumnName = "BudgetCategoryCode", ColumnCaption = "Loại khoản", ColumnPosition = 9, ColumnVisible = true, ColumnWith = 130, RepositoryControl = _gridLookUpEditBudgetCategory } : new XtraColumn { ColumnName = "BudgetCategoryCode", ColumnVisible = false},
                    _account.IsBudgetGroup ? new XtraColumn { ColumnName = "BudgetGroupItemCode", ColumnCaption = "Nhóm", ColumnPosition = 10, ColumnVisible = true, ColumnWith = 130, RepositoryControl = _gridLookUpEditGroupBudgetItem } : new XtraColumn { ColumnName = "BudgetGroupItemCode", ColumnVisible = false},
                    _account.IsBudgetItem ? new XtraColumn { ColumnName = "BudgetItemCode", ColumnCaption = "Mục- Tiểu mục", ColumnPosition = 11, ColumnVisible = true, ColumnWith = 150, RepositoryControl = _gridLookUpEditBudgetItem } : new XtraColumn { ColumnName = "BudgetItemCode", ColumnVisible = false},
                    _account.IsCapitalAllocate ? new XtraColumn { ColumnName = "MergerFundId", ColumnCaption = "Quỹ sát nhập", ColumnPosition = 12, ColumnVisible = true, ColumnWith = 130, RepositoryControl = _gridLookUpEditMergerFund } : new XtraColumn { ColumnName = "MergerFundId", ColumnVisible = false},
                    //_account.IsProject ? new XtraColumn { ColumnName = "ProjectId", ColumnCaption = "Dự án", ColumnPosition = 13, ColumnVisible = true, ColumnWith = 130, RepositoryControl = _gridLookUpEditProject } : new XtraColumn { ColumnName = "ProjectId", ColumnVisible = false},
                };

                if (_account.IsCurrency) //tai khoan chi tiet theo tien te
                {
                    gridColumnsCollection.Add(new XtraColumn() { ColumnName = "CurrencyCode", ColumnCaption = "Loại tiền tệ", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 100, RepositoryControl = _cboCurrencyCode });
                    gridColumnsCollection.Add(new XtraColumn() { ColumnName = "ExchangeRate", ColumnCaption = "Tỷ giá", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 100, RepositoryControl = _calcEditExchangeRate });
                }
                else
                {
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "CurrencyCode", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "ExchangeRate", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "DebitAmountExchange", ColumnVisible = false });
                    gridColumnsCollection.Add(new XtraColumn { ColumnName = "CreditAmountExchange", ColumnVisible = false });
                }

                gridColumnsCollection.Add(_account.IsEmployee ? new XtraColumn() { ColumnName = "EmployeeId", ColumnCaption = "Nhân viên", ColumnPosition = 13, ColumnVisible = true, ColumnWith = 130, RepositoryControl = _gridLookUpEditEmployee } : new XtraColumn { ColumnName = "EmployeeId", ColumnVisible = false });
                gridColumnsCollection.Add(_account.IsCustomer ? new XtraColumn() { ColumnName = "CustomerId", ColumnCaption = "Khách hàng", ColumnPosition = 14, ColumnVisible = true, ColumnWith = 130, RepositoryControl = _gridLookUpEditCustomer } : new XtraColumn { ColumnName = "CustomerId", ColumnVisible = false });
                gridColumnsCollection.Add(_account.IsVendor ? new XtraColumn() { ColumnName = "VendorId", ColumnCaption = "Nhà cung cấp", ColumnPosition = 15, ColumnVisible = true, ColumnWith = 130, RepositoryControl = _gridLookUpEditVendor } : new XtraColumn { ColumnName = "VendorId", ColumnVisible = false });

                if (_account.IsAccountingObject) //tai khoan chi tiet theo doi tuong khac
                    gridColumnsCollection.Add(new XtraColumn() { ColumnName = "AccountingObjectId", ColumnCaption = "Đối tượng khác", ColumnPosition = 16, ColumnVisible = true, ColumnWith = 130, RepositoryControl = _gridLookUpEditAccountingObject });
                else
                    gridColumnsCollection.Add(new XtraColumn() { ColumnName = "AccountingObjectId", ColumnVisible = false });

                switch (_account.BalanceSide)
                {
                    case 0:
                        gridColumnsCollection.Add(new XtraColumn() { ColumnName = "DebitAmountOC", ColumnCaption = "Nợ đầu kỳ", ColumnPosition = 20, ColumnVisible = true, ColumnWith = 120, ColumnType = UnboundColumnType.Decimal });
                        gridColumnsCollection.Add(new XtraColumn() { ColumnName = "CreditAmountOC", ColumnVisible = false });
                        break;
                    case 1:
                        gridColumnsCollection.Add(new XtraColumn() { ColumnName = "DebitAmountOC", ColumnVisible = false });
                        gridColumnsCollection.Add(new XtraColumn() { ColumnName = "CreditAmountOC", ColumnCaption = "Có đầu kỳ", ColumnPosition = 22, ColumnVisible = true, ColumnWith = 120, ColumnType = UnboundColumnType.Decimal });
                        break;
                    default:
                        gridColumnsCollection.Add(new XtraColumn() { ColumnName = "DebitAmountOC", ColumnCaption = "Nợ đầu kỳ", ColumnPosition = 20, ColumnVisible = true, ColumnWith = 120, ColumnType = UnboundColumnType.Decimal });
                        gridColumnsCollection.Add(new XtraColumn() { ColumnName = "CreditAmountOC", ColumnCaption = "Có đầu kỳ", ColumnPosition = 22, ColumnVisible = true, ColumnWith = 120, ColumnType = UnboundColumnType.Decimal });
                        break;
                }

                if (_account.IsCurrency) //tai khoan chi tiet theo tien te
                {
                    switch (_account.BalanceSide)
                    {
                        case 0:
                            gridColumnsCollection.Add(new XtraColumn() { ColumnName = "DebitAmountExchange", ColumnCaption = "Nợ đầu kỳ quy đổi", ColumnPosition = 21, ColumnVisible = true, ColumnWith = 150, ColumnType = UnboundColumnType.Decimal });
                            gridColumnsCollection.Add(new XtraColumn() { ColumnName = "CreditAmountExchange", ColumnVisible = false });
                            break;
                        case 1:
                            gridColumnsCollection.Add(new XtraColumn() { ColumnName = "DebitAmountExchange", ColumnVisible = false });
                            gridColumnsCollection.Add(new XtraColumn() { ColumnName = "CreditAmountExchange", ColumnCaption = "Có đầu kỳ quy đổi", ColumnPosition = 23, ColumnVisible = true, ColumnWith = 150, ColumnType = UnboundColumnType.Decimal });
                            break;
                        case 2:
                            gridColumnsCollection.Add(new XtraColumn() { ColumnName = "DebitAmountExchange", ColumnCaption = "Nợ đầu kỳ quy đổi", ColumnPosition = 21, ColumnVisible = true, ColumnWith = 150, ColumnType = UnboundColumnType.Decimal });
                            gridColumnsCollection.Add(new XtraColumn() { ColumnName = "CreditAmountExchange", ColumnCaption = "Có đầu kỳ quy đổi", ColumnPosition = 23, ColumnVisible = true, ColumnWith = 150, ColumnType = UnboundColumnType.Decimal });
                            break;
                    }
                }

                if (_account.IsAllowinputcts)
                {
                    gridColumnsCollection.Add(new XtraColumn() { ColumnName = "AccountBeginningDebitAmountOC", ColumnCaption = "Lũy kế nợ", ColumnPosition = 24, ColumnVisible = true, ColumnWith = 150, ColumnType = UnboundColumnType.Decimal });
                    gridColumnsCollection.Add(new XtraColumn() { ColumnName = "AccountBeginningCreditAmountOC", ColumnCaption = "Lũy kế có", ColumnPosition = 25, ColumnVisible = true, ColumnWith = 150, ColumnType = UnboundColumnType.Decimal });
                    gridColumnsCollection.Add(new XtraColumn() { ColumnName = "AccountBeginningDebitAmountExchange", ColumnCaption = "Lũy kế nợ quy đổi", ColumnPosition = 26, ColumnVisible = true, ColumnWith = 150, ColumnType = UnboundColumnType.Decimal });
                    gridColumnsCollection.Add(new XtraColumn() { ColumnName = "AccountBeginningCreditAmountExchange", ColumnCaption = "Lũy kế có quy đổi", ColumnPosition = 27, ColumnVisible = true, ColumnWith = 150, ColumnType = UnboundColumnType.Decimal });
                }
                if (_account.AccountCode.Substring(0, 2) == "11")
                {
                    gridColumnsCollection.Add(new XtraColumn() { ColumnName = "BankId", ColumnCaption = "Tài khoản Ngân hàng", ColumnPosition = 39, ColumnVisible = true, ColumnWith = 130, RepositoryControl = _gridLookUpEditBank });
                }
                else
                {
                    gridColumnsCollection.Add(new XtraColumn() { ColumnName = "BankId", ColumnCaption = "Tài khoản Ngân hàng", ColumnPosition = 39, ColumnVisible = false, ColumnWith = 130, RepositoryControl = _gridLookUpEditBank });
                }


                foreach (GridColumn grdColumn in gridViewDetail.Columns)
                {
                    grdColumn.Visible = false;
                }

                foreach (var column in gridColumnsCollection)
                {
                    //gridViewDetail.Columns[column.ColumnName].OptionsColumn.AllowSort = DefaultBoolean.False;
                    if (column.ColumnVisible)
                    {
                        gridViewDetail.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        gridViewDetail.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                        gridViewDetail.Columns[column.ColumnName].Width = column.ColumnWith;
                        gridViewDetail.Columns[column.ColumnName].UnboundType = column.ColumnType;
                        gridViewDetail.Columns[column.ColumnName].ColumnEdit = column.RepositoryControl;
                    }
                    else
                        gridViewDetail.Columns[column.ColumnName].Visible = false;
                }
                SetNumericFormatControl(gridViewDetail, true);
            }
            get
            {
                var openingAccountEntryDetails = new List<OpeningAccountEntryDetailModel>();
                if (gridViewDetail.DataSource != null && gridViewDetail.RowCount > 0)
                {
                    for (var i = 0; i < gridViewDetail.RowCount; i++)
                    {
                        if (gridViewDetail.GetRow(i) != null)
                        {
                            openingAccountEntryDetails.Add(new OpeningAccountEntryDetailModel
                            {
                                RefTypeId = 700,
                                PostedDate = DateTime.Parse(GlobalVariable.SystemDate).AddDays(-1),
                                AccountCode = _account.AccountCode,
                                AccountBeginningDebitAmountOC = (decimal)gridViewDetail.GetRowCellValue(i, "AccountBeginningDebitAmountOC"),
                                AccountBeginningCreditAmountOC = (decimal)gridViewDetail.GetRowCellValue(i, "AccountBeginningCreditAmountOC"),
                                DebitAmountOC = (decimal)gridViewDetail.GetRowCellValue(i, "DebitAmountOC"),
                                CreditAmountOC = (decimal)gridViewDetail.GetRowCellValue(i, "CreditAmountOC"),
                                AccountBeginningDebitAmountExchange = (decimal)gridViewDetail.GetRowCellValue(i, "AccountBeginningDebitAmountExchange"),
                                DebitAmountExchange = (decimal)gridViewDetail.GetRowCellValue(i, "DebitAmountExchange"),
                                CreditAmountExchange = (decimal)gridViewDetail.GetRowCellValue(i, "CreditAmountExchange"),
                                CurrencyCode = (string)gridViewDetail.GetRowCellValue(i, "CurrencyCode"),
                                ExchangeRate = (float)gridViewDetail.GetRowCellValue(i, "ExchangeRate"),
                                BudgetSourceCode = (string)gridViewDetail.GetRowCellValue(i, "BudgetSourceCode"),
                                BudgetChapterCode = (string)gridViewDetail.GetRowCellValue(i, "BudgetChapterCode"),
                                BudgetCategoryCode = (string)gridViewDetail.GetRowCellValue(i, "BudgetCategoryCode"),
                                BudgetGroupItemCode = (string)gridViewDetail.GetRowCellValue(i, "BudgetGroupItemCode"),
                                BudgetItemCode = (string)gridViewDetail.GetRowCellValue(i, "BudgetItemCode"),
                                MergerFundId = gridViewDetail.GetRowCellValue(i, "MergerFundId") == null ? (int?)null : (int)gridViewDetail.GetRowCellValue(i, "MergerFundId"),
                                EmployeeId = gridViewDetail.GetRowCellValue(i, "EmployeeId") == null ? (int?)null : (int)gridViewDetail.GetRowCellValue(i, "EmployeeId"),
                                CustomerId = gridViewDetail.GetRowCellValue(i, "CustomerId") == null ? (int?)null : (int)gridViewDetail.GetRowCellValue(i, "CustomerId"),
                                VendorId = gridViewDetail.GetRowCellValue(i, "VendorId") == null ? (int?)null : (int)gridViewDetail.GetRowCellValue(i, "VendorId"),
                                AccountingObjectId = gridViewDetail.GetRowCellValue(i, "AccountingObjectId") == null ? (int?)null : (int)gridViewDetail.GetRowCellValue(i, "AccountingObjectId"),
                                //ProjectId = gridViewDetail.GetRowCellValue(i, "ProjectId") == null ? (int?)null : (int)gridViewDetail.GetRowCellValue(i, "ProjectId"),
                                BankId = gridViewDetail.GetRowCellValue(i, "BankId") == null ? (int?)null : (int)gridViewDetail.GetRowCellValue(i, "BankId")
                            });
                        }
                    }
                }
                return openingAccountEntryDetails.ToList();
            }
        }
        public long RefId { get; set; }
        public int RefTypeId { get; set; }
        public new DateTime PostedDate { get; set; }
        public string AccountCode { get; set; }
        public int AccountId { get; set; }
        public int ParentId { get; set; }
        public string AccountName { get; set; }
        public decimal TotalAccountBeginningDebitAmountOC { get; set; }
        public decimal TotalAccountBeginningCreditAmountOC { get; set; }
        public decimal TotalDebitAmountOC { get; set; }
        public decimal TotalCreditAmountOC { get; set; }
        public decimal TotalAccountBeginningDebitAmountExchange { get; set; }
        public decimal TotalAccountBeginningCreditAmountExchange { get; set; }
        public decimal TotalDebitAmountExchange { get; set; }
        public decimal TotalCreditAmountExchange { get; set; }

        #endregion

        #region Events

        public FrmXtraOpeningAccountEntryDetail()
        {
            InitializeComponent();
            _openingAccountEntryPresenter = new OpeningAccountEntryPresenter(this);
            _accountsPresenter = new AccountsPresenter(this);
            _budgetSourcesPresenter = new BudgetSourcesPresenter(this);
            _budgetItemsPresenter = new BudgetItemsPresenter(this);
            _budgetChaptersPresenter = new BudgetChaptersPresenter(this);
            _budgetCategoriesPresenter = new BudgetCategoriesPresenter(this);
            _mergerFundsPresenter = new MergerFundsPresenter(this);
            _employeesPresenter = new EmployeesPresenter(this);
            _customersPresenter = new CustomersPresenter(this);
            _vendorsPresenter = new VendorsPresenter(this);
            _accountingObjectsPresenter = new AccountingObjectsPresenter(this);
            _projectsPresenter = new ProjectsPresenter(this);
            _banksPresenter = new BanksPresenter(this);
        }

        private void gridViewDetail_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            try
            {
                var budgetSourceCodeCol = gridViewDetail.Columns["BudgetSourceCode"];
                var budgetChapterCodeCol = gridViewDetail.Columns["BudgetChapterCode"];
                var budgetCategoryCodeCol = gridViewDetail.Columns["BudgetCategoryCode"];
                var budgetGroupItemCodeCol = gridViewDetail.Columns["BudgetGroupItemCode"];
                var budgetItemCodeCol = gridViewDetail.Columns["BudgetItemCode"];
                var mergerFundIdCol = gridViewDetail.Columns["MergerFundId"];
                var employeeIdCol = gridViewDetail.Columns["EmployeeId"];
                var customerIdCol = gridViewDetail.Columns["CustomerId"];
                var vendorIdCol = gridViewDetail.Columns["VendorId"];
                var accountingObjectIdCol = gridViewDetail.Columns["AccountingObjectId"];
                //var projectIdCol = gridViewDetail.Columns["ProjectId"];

                var budgetSourceCode = (string)gridViewDetail.GetRowCellValue(e.RowHandle, budgetSourceCodeCol);
                var budgetChapterCode = (string)gridViewDetail.GetRowCellValue(e.RowHandle, budgetChapterCodeCol);
                var budgetCategoryCode = (string)gridViewDetail.GetRowCellValue(e.RowHandle, budgetCategoryCodeCol);
                var budgetGroupItemCode = (string)gridViewDetail.GetRowCellValue(e.RowHandle, budgetGroupItemCodeCol);
                var budgetItemCode = (string)gridViewDetail.GetRowCellValue(e.RowHandle, budgetItemCodeCol);
                var mergerFundId = (int?)gridViewDetail.GetRowCellValue(e.RowHandle, mergerFundIdCol);
                var employeeId = (int?)gridViewDetail.GetRowCellValue(e.RowHandle, employeeIdCol);
                var customerId = (int?)gridViewDetail.GetRowCellValue(e.RowHandle, customerIdCol);
                var vendorId = (int?)gridViewDetail.GetRowCellValue(e.RowHandle, vendorIdCol);
                var accountingObjectId = (int?)gridViewDetail.GetRowCellValue(e.RowHandle, accountingObjectIdCol);
                //var projectId = (int?)gridViewDetail.GetRowCellValue(e.RowHandle, projectIdCol);

                if (_account.IsBudgetSource)
                {
                    if (string.IsNullOrEmpty(budgetSourceCode))
                    {
                        e.Valid = false;
                        gridViewDetail.SetColumnError(budgetSourceCodeCol, ResourceHelper.GetResourceValueByName("ResOpeningAccountEntryDetailBudgetSourceCode"));
                    }
                }

                if (_account.IsChapter)
                {
                    if (string.IsNullOrEmpty(budgetChapterCode))
                    {
                        e.Valid = false;
                        gridViewDetail.SetColumnError(budgetChapterCodeCol, ResourceHelper.GetResourceValueByName("ResOpeningAccountEntryDetailBudgetChapterCode"));
                    }
                }

                if (_account.IsBudgetCategory)
                {
                    if (string.IsNullOrEmpty(budgetCategoryCode))
                    {
                        e.Valid = false;
                        gridViewDetail.SetColumnError(budgetCategoryCodeCol, ResourceHelper.GetResourceValueByName("ResOpeningAccountEntryDetailBudgetCategoryCode"));
                    }
                }

                if (_account.IsBudgetGroup)
                {
                    if (string.IsNullOrEmpty(budgetGroupItemCode))
                    {
                        e.Valid = false;
                        gridViewDetail.SetColumnError(budgetGroupItemCodeCol, ResourceHelper.GetResourceValueByName("ResOpeningAccountEntryDetailBudgetGroupItemCode"));
                    }
                }

                if (_account.IsBudgetItem)
                {
                    if (string.IsNullOrEmpty(budgetItemCode))
                    {
                        e.Valid = false;
                        gridViewDetail.SetColumnError(budgetItemCodeCol, ResourceHelper.GetResourceValueByName("ResOpeningAccountEntryDetailBudgetItemCode"));
                    }
                }

                if (_account.IsCapitalAllocate)
                {
                    if (mergerFundId == null)
                    {
                        e.Valid = false;
                        gridViewDetail.SetColumnError(mergerFundIdCol, ResourceHelper.GetResourceValueByName("ResOpeningAccountEntryDetailMergerFundId"));
                    }
                }

                if (_account.IsEmployee)
                {
                    if (employeeId == null)
                    {
                        e.Valid = false;
                        gridViewDetail.SetColumnError(employeeIdCol, ResourceHelper.GetResourceValueByName("ResOpeningAccountEntryDetailEmployeeId"));
                    }
                }

                if (_account.IsCustomer)
                {
                    if (customerId == null)
                    {
                        e.Valid = false;
                        gridViewDetail.SetColumnError(customerIdCol, ResourceHelper.GetResourceValueByName("ResOpeningAccountEntryDetailCustomerId"));
                    }
                }

                if (_account.IsVendor)
                {
                    if (vendorId == null)
                    {
                        e.Valid = false;
                        gridViewDetail.SetColumnError(vendorIdCol, ResourceHelper.GetResourceValueByName("ResOpeningAccountEntryDetailVendorId"));
                    }
                }

                if (_account.IsAccountingObject)
                {
                    if (accountingObjectId == null)
                    {
                        e.Valid = false;
                        gridViewDetail.SetColumnError(accountingObjectIdCol, ResourceHelper.GetResourceValueByName("ResOpeningAccountEntryDetailAccountingObjectId"));
                    }
                }

                //if (_account.IsProject)
                //{
                //    if (projectId == null)
                //    {
                //        e.Valid = false;
                //        gridViewDetail.SetColumnError(projectIdCol, ResourceHelper.GetResourceValueByName("ResOpeningAccountEntryDetailProjectId"));
                //    }
                //}
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(),
                    ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridViewDetail_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void gridViewDetail_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            var view = sender as GridView;
            if (view != null)
            {
                var hitInfo = view.CalcHitInfo(e.Point);
                if (hitInfo.InRow)
                {
                    view.FocusedRowHandle = hitInfo.RowHandle;
                    popupMenu1.ShowPopup(grdDetail.PointToScreen(e.Point));
                }
            }
        }

        private void barButtonDeleteRowItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridViewDetail.DeleteSelectedRows();
        }

        private void gridViewDetail_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                var currencyCodeCol = gridViewDetail.Columns["CurrencyCode"];
                var exchangeRateCol = gridViewDetail.Columns["ExchangeRate"];
                var debitAmountOCCol = gridViewDetail.Columns["DebitAmountOC"];
                var creditAmountOCCol = gridViewDetail.Columns["CreditAmountOC"];
                var debitAmountExchangeCol = gridViewDetail.Columns["DebitAmountExchange"];
                var creditAmountExchangeCol = gridViewDetail.Columns["CreditAmountExchange"];
                var accountBeginningDebitAmountOCCol = gridViewDetail.Columns["AccountBeginningDebitAmountOC"];
                var accountBeginningDebitAmountExchangeCol = gridViewDetail.Columns["AccountBeginningDebitAmountExchange"];
                var accountBeginningCreditAmountOCCol = gridViewDetail.Columns["AccountBeginningCreditAmountOC"];
                var accountBeginningCreditAmountExchangeCol = gridViewDetail.Columns["AccountBeginningCreditAmountExchange"];

                decimal accountBeginningDebitAmountOC = 0;
                decimal accountBeginningCreditAmountOC = 0;
                decimal debitAmountOC = 0;
                decimal creditAmountOC = 0;

                decimal exchangeRate;

                switch (e.Column.FieldName)
                {
                    case "CurrencyCode":
                        var currencyCode = gridViewDetail.GetRowCellValue(e.RowHandle, currencyCodeCol) == null ? null : gridViewDetail.GetRowCellValue(e.RowHandle, currencyCodeCol).ToString();
                        if (currencyCode == CurrencyAccounting)
                        {
                            gridViewDetail.SetRowCellValue(e.RowHandle, exchangeRateCol, "1");
                            gridViewDetail.Columns["ExchangeRate"].OptionsColumn.AllowEdit = false;
                        }
                        else
                        {
                            gridViewDetail.Columns["ExchangeRate"].OptionsColumn.AllowEdit = true;
                        }

                        break;

                    case "ExchangeRate":
                        exchangeRate = gridViewDetail.GetRowCellValue(e.RowHandle, exchangeRateCol) == null ? 1 : decimal.Parse(gridViewDetail.GetRowCellValue(e.RowHandle, exchangeRateCol).ToString());
                        accountBeginningDebitAmountOC = gridViewDetail.GetRowCellValue(e.RowHandle, accountBeginningDebitAmountOCCol) == null ? 0 : (decimal)gridViewDetail.GetRowCellValue(e.RowHandle, accountBeginningDebitAmountOCCol);
                        accountBeginningCreditAmountOC = gridViewDetail.GetRowCellValue(e.RowHandle, accountBeginningCreditAmountOCCol) == null ? 0 : (decimal)gridViewDetail.GetRowCellValue(e.RowHandle, accountBeginningCreditAmountOCCol);
                        debitAmountOC = gridViewDetail.GetRowCellValue(e.RowHandle, debitAmountOCCol) == null ? 0 : (decimal)gridViewDetail.GetRowCellValue(e.RowHandle, debitAmountOCCol);
                        creditAmountOC = gridViewDetail.GetRowCellValue(e.RowHandle, creditAmountOCCol) == null ? 0 : (decimal)gridViewDetail.GetRowCellValue(e.RowHandle, creditAmountOCCol);

                        gridViewDetail.SetRowCellValue(e.RowHandle, accountBeginningDebitAmountExchangeCol, accountBeginningDebitAmountOC / exchangeRate);
                        gridViewDetail.SetRowCellValue(e.RowHandle, accountBeginningCreditAmountOCCol, accountBeginningCreditAmountOC / exchangeRate);
                        gridViewDetail.SetRowCellValue(e.RowHandle, debitAmountExchangeCol, debitAmountOC / exchangeRate);
                        gridViewDetail.SetRowCellValue(e.RowHandle, creditAmountExchangeCol, creditAmountOC / exchangeRate);
                        break;

                    case "DebitAmountOC":
                        exchangeRate = gridViewDetail.GetRowCellValue(e.RowHandle, exchangeRateCol) == null ? 1 : decimal.Parse(gridViewDetail.GetRowCellValue(e.RowHandle, exchangeRateCol).ToString());
                        debitAmountOC = gridViewDetail.GetRowCellValue(e.RowHandle, debitAmountOCCol) == null ? 0 : (decimal)gridViewDetail.GetRowCellValue(e.RowHandle, debitAmountOCCol);
                        if (exchangeRate != 0 && debitAmountOC != 0)
                            gridViewDetail.SetRowCellValue(e.RowHandle, debitAmountExchangeCol, debitAmountOC / exchangeRate);
                        break;

                    case "CreditAmountOC":
                        exchangeRate = gridViewDetail.GetRowCellValue(e.RowHandle, exchangeRateCol) == null ? 1 : decimal.Parse(gridViewDetail.GetRowCellValue(e.RowHandle, exchangeRateCol).ToString());
                        creditAmountOC = gridViewDetail.GetRowCellValue(e.RowHandle, creditAmountOCCol) == null ? 0 : (decimal)gridViewDetail.GetRowCellValue(e.RowHandle, creditAmountOCCol);
                        if (exchangeRate != 0 && creditAmountOC != 0)
                            gridViewDetail.SetRowCellValue(e.RowHandle, creditAmountExchangeCol, creditAmountOC / exchangeRate);
                        break;

                    case "AccountBeginningDebitAmountOC":
                        exchangeRate = gridViewDetail.GetRowCellValue(e.RowHandle, exchangeRateCol) == null ? 1 : decimal.Parse(gridViewDetail.GetRowCellValue(e.RowHandle, exchangeRateCol).ToString());
                        accountBeginningDebitAmountOC = gridViewDetail.GetRowCellValue(e.RowHandle, accountBeginningDebitAmountOCCol) == null ? 0 : (decimal)gridViewDetail.GetRowCellValue(e.RowHandle, accountBeginningDebitAmountOCCol);
                        if (exchangeRate != 0 && accountBeginningDebitAmountOC != 0)
                            gridViewDetail.SetRowCellValue(e.RowHandle, accountBeginningDebitAmountExchangeCol, accountBeginningDebitAmountOC / exchangeRate);
                        break;

                    case "AccountBeginningCreditAmountOC":
                        exchangeRate = gridViewDetail.GetRowCellValue(e.RowHandle, exchangeRateCol) == null ? 1 : decimal.Parse(gridViewDetail.GetRowCellValue(e.RowHandle, exchangeRateCol).ToString());
                        accountBeginningCreditAmountOC = gridViewDetail.GetRowCellValue(e.RowHandle, accountBeginningCreditAmountOCCol) == null ? 0 : (decimal)gridViewDetail.GetRowCellValue(e.RowHandle, accountBeginningCreditAmountOCCol);
                        if (exchangeRate != 0 && accountBeginningCreditAmountOC != 0)
                            gridViewDetail.SetRowCellValue(e.RowHandle, accountBeginningCreditAmountExchangeCol, accountBeginningCreditAmountOC / exchangeRate);
                        break;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridViewDetail_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            try
            {
                if (e.Column.FieldName != "CurrencyCode") return;
                if (!_account.IsCurrency) return;
                var currencyCodeCol = gridViewDetail.Columns["CurrencyCode"];
                gridViewDetail.SetRowCellValue(e.RowHandle, currencyCodeCol, _account.CurrencyCode);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(),
                    ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridViewDetail_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            try
            {
                GridView gridView = sender as GridView;
                if (gridView != null)
                {
                    var currencyCode = gridViewDetail.GetRowCellValue(e.FocusedRowHandle, "CurrencyCode") == null ? "" : gridViewDetail.GetRowCellValue(e.FocusedRowHandle, "CurrencyCode").ToString();
                    if (currencyCode.Trim().ToUpper() == "USD")
                    {
                        gridViewDetail.SetRowCellValue(e.FocusedRowHandle, "ExchangeRate", 1);
                        gridViewDetail.Columns["ExchangeRate"].OptionsColumn.AllowEdit = false;
                    }
                    else
                    {
                        gridViewDetail.Columns["ExchangeRate"].OptionsColumn.AllowEdit = true;
                    }
                }
            }
            catch (Exception) { }
        }

        protected void repositoryItemGridLookUpEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                (grdDetail.FocusedView.ActiveEditor as GridLookUpEdit).ClosePopup();
                (grdDetail.FocusedView.ActiveEditor as BaseEdit).EditValue = null;
            }
            else if (e.KeyData == Keys.Tab)
            {
                (grdDetail.FocusedView.ActiveEditor as GridLookUpEdit).ClosePopup();
                var rps = grdDetail.FocusedView.ActiveEditor as BaseEdit;
                if (rps.Text == "")
                    (grdDetail.FocusedView.ActiveEditor as BaseEdit).EditValue = null;
            }
            else if (e.KeyData == Keys.Back)
            {
                (grdDetail.FocusedView.ActiveEditor as GridLookUpEdit).ClosePopup();
                var rps = grdDetail.FocusedView.ActiveEditor as BaseEdit;
                if (rps.Text == "")
                    (grdDetail.FocusedView.ActiveEditor as BaseEdit).EditValue = null;
            }
        }

        #endregion

        #region Function Overrides

        protected override void InitData()
        {
            _accountsPresenter.Display();
            _banksPresenter.DisplayActive();

            _account = (from accountModel in _accounts where accountModel.AccountId == int.Parse(KeyValue) select accountModel).FirstOrDefault();
            if (_account != null && _account.IsBudgetSource)
                _budgetSourcesPresenter.DisplayIsParent(false);
            if (_account != null && (_account != null && _account.IsBudgetItem || _account.IsBudgetGroup))
                _budgetItemsPresenter.DisplayActive();
            if (_account != null && _account.IsChapter)
                _budgetChaptersPresenter.DisplayActive();
            if (_account != null && _account.IsBudgetCategory)
                _budgetCategoriesPresenter.DisplayActive();
            if (_account != null && _account.IsCapitalAllocate)
                _mergerFundsPresenter.DisplayActive();
            if (_account != null && _account.IsEmployee)
                _employeesPresenter.DisplayActive();
            if (_account != null && _account.IsCustomer)
                _customersPresenter.DisplayActive(true);
            if (_account != null && _account.IsVendor)
                _vendorsPresenter.DisplayActive(true);
            if (_account != null && _account.IsAccountingObject)
                _accountingObjectsPresenter.DisplayActive(true);
            if (_account != null && _account.IsProject)
                _projectsPresenter.DisplayActive();
            if (_account != null && _account.IsCurrency)
            {
                if (_account.CurrencyCode == null)
                {
                    _cboCurrencyCode.Items.Add(CurrencyLocal);
                    if (CurrencyLocal != CurrencyAccounting)
                        _cboCurrencyCode.Items.Add(CurrencyAccounting);
                }
                else
                    _cboCurrencyCode.Items.Add(_account.CurrencyCode);
            }
            if (_account == null) return;
            _openingAccountEntryPresenter.Display(_account.AccountCode);
            Text = @"Nhập số dư ban đầu cho tài khoản " + _account.AccountCode;
        }

        protected override void InitControls()
        {
            gridViewDetail.OptionsView.ShowFooter = true;

            _gridLookUpEditBudgetSource = new RepositoryItemGridLookUpEdit();
            _gridLookUpEditGroupBudgetItem = new RepositoryItemGridLookUpEdit();
            _gridLookUpEditBudgetItem = new RepositoryItemGridLookUpEdit();
            _gridLookUpEditBudgetChapter = new RepositoryItemGridLookUpEdit();
            _gridLookUpEditBank = new RepositoryItemGridLookUpEdit();
            _gridLookUpEditBudgetCategory = new RepositoryItemGridLookUpEdit();
            _gridLookUpEditMergerFund = new RepositoryItemGridLookUpEdit();
            _gridLookUpEditEmployee = new RepositoryItemGridLookUpEdit();
            _gridLookUpEditCustomer = new RepositoryItemGridLookUpEdit();
            _gridLookUpEditVendor = new RepositoryItemGridLookUpEdit();
            _gridLookUpEditAccountingObject = new RepositoryItemGridLookUpEdit();
            //_gridLookUpEditProject = new RepositoryItemGridLookUpEdit();

            _cboCurrencyCode = new RepositoryItemComboBox();

            //RepositoryItemCalcEdit ExchangeRate
            _calcEditExchangeRate = new RepositoryItemCalcEdit();
            _calcEditExchangeRate.EditFormat.FormatType = FormatType.Numeric;
            _calcEditExchangeRate.EditMask = @"f" + ExchangeRateDecimalDigits;
            _calcEditExchangeRate.Mask.UseMaskAsDisplayFormat = true;
        }

        protected override bool ValidData()
        {
            return true;
        }

        protected override int SaveData()
        {
            if (AccountCode == null)
                AccountCode = _account.AccountCode;
            RefTypeId = 700;
            PostedDate = (DateTime.Parse(GlobalVariable.SystemDate)).AddDays(-1);
            gridViewDetail.CloseEditor();
            if (gridViewDetail.UpdateCurrentRow())
                return (int)_openingAccountEntryPresenter.Save();
            return 0;
        }

        #endregion
    }
}
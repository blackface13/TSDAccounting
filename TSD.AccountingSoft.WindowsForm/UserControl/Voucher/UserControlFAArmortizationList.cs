/***********************************************************************
 * <copyright file="UserControlFAArmortizationList_1.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 18 August 2014
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
using System.Threading;
using System.Windows.Forms;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Model.BusinessObjects.FixedAsset;
using TSD.AccountingSoft.Presenter.Dictionary.Account;
using TSD.AccountingSoft.Presenter.Dictionary.BudgetItem;
using TSD.AccountingSoft.Presenter.Dictionary.BudgetSource;
using TSD.AccountingSoft.Presenter.Dictionary.Department;
using TSD.AccountingSoft.Presenter.Dictionary.FixedAsset;
using TSD.AccountingSoft.Presenter.Dictionary.Project;
using TSD.AccountingSoft.Presenter.Dictionary.VoucherType;
using TSD.AccountingSoft.Presenter.FixedAsset.FixedAssetArmortization;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.View.FixedAsset;
using TSD.AccountingSoft.WindowsForm.BaseUserControls;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.FormBusiness;
using TSD.AccountingSoft.Session;
using TSD.AccountingSoft.WindowsForm.Resources;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace TSD.AccountingSoft.WindowsForm.UserControl.Voucher
{
    /// <summary>
    /// UserControlFAArmortizationList_1
    /// </summary>
    public partial class UserControlFAArmortizationList : BaseVoucherListDetail, IFixedAssetArmortizationsView, IFixedAssetsView, IAccountsView, IDepartmentsView,
        IVoucherTypesView, IBudgetSourcesView, IBudgetItemsView, IProjectsView
    {
        private readonly FixedAssetArmortizationsPresenter _fixedAssetArmortizationsPresenter;
        private IList<FixedAssetArmortizationModel> _fixedAssetArmortizations;
        private readonly FixedAssetsPresenter _fixedAssetsPresenter;
        private readonly AccountsPresenter _accountsPresenter;
        private readonly DepartmentsPresenter _departmentsPresenter;
        private readonly VoucherTypesPresenter _voucherTypesPresenter;
        private readonly BudgetSourcesPresenter _budgetSourcesPresenter;
        private readonly BudgetItemsPresenter _budgetItemsPresenter;
        private readonly ProjectsPresenter _projectsPresenter;
        protected GlobalVariable DBOptionHelper;

        #region Repository Controls

        private RepositoryItemGridLookUpEdit _gridLookUpEditFixedAsset;
        private GridView _gridLookUpEditFixedAssetView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditAccountNumber;
        private GridView _gridLookUpEditAccountNumberView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditCorrespondingAccountNumber;
        private GridView _gridLookUpEditCorrespondingAccountNumberView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditDepartment;
        private GridView _gridLookUpEditDepartmentView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditVoucherType;
        private GridView _gridLookUpEditVoucherTypeView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetSource;
        private GridView _gridLookUpEditBudgetSourceView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditBudgetItem;
        private GridView _gridLookUpEditBudgetItemView;

        private RepositoryItemGridLookUpEdit _gridLookUpEditProject;
        private GridView _gridLookUpEditProjectView;

        private RepositoryItemComboBox _cboCurrencyCode;
        private RepositoryItemCalcEdit _calcEditExchangeRate;

        #endregion

        #region Combobox Members

        /// <summary>
        /// Sets the fixed assets.
        /// </summary>
        /// <value>
        /// The fixed assets.
        /// </value>
        public IList<FixedAssetModel> FixedAssets
        {
            set
            {
                try
                {
                    _gridLookUpEditFixedAsset.DataSource = value;
                    _gridLookUpEditFixedAssetView.PopulateColumns(value);

                    var gridColumnsCollection = new List<XtraColumn>
                        {
                            new XtraColumn {ColumnName = "FixedAssetCode", ColumnCaption = "Mã tài sản", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 100,  Alignment = HorzAlignment.Near },
                            new XtraColumn {ColumnName = "FixedAssetName", ColumnCaption = "Tên tài sản", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 300, Alignment = HorzAlignment.Near },
                            new XtraColumn {ColumnName = "OrgPrice", ColumnCaption = "Nguyên giá", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 150, ColumnType = UnboundColumnType.Decimal, Alignment = HorzAlignment.Far },
                            new XtraColumn {ColumnName = "LifeTime", ColumnCaption = "Thời gian SD", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 150, ColumnType = UnboundColumnType.Integer, Alignment = HorzAlignment.Far, ToolTip = "Thời gian sử dụng" },
                            new XtraColumn {ColumnName = "FixedAssetId", ColumnVisible = false},
                            new XtraColumn {ColumnName = "UsedDate", ColumnVisible = false},
                            new XtraColumn {ColumnName = "State", ColumnVisible = false},
                            new XtraColumn {ColumnName = "FixedAssetId", ColumnVisible = false},
                            new XtraColumn {ColumnName = "FixedAssetForeignName", ColumnVisible = false},
                            new XtraColumn {ColumnName = "Description", ColumnVisible = false},
                            new XtraColumn {ColumnName = "ProductionYear", ColumnVisible = false},
                            new XtraColumn {ColumnName = "MadeIn", ColumnVisible = false},
                            new XtraColumn {ColumnName = "FixedAssetCategoryId", ColumnVisible = false},
                            new XtraColumn {ColumnName = "PurchasedDate", ColumnVisible = false},
                            new XtraColumn {ColumnName = "DepreciationDate", ColumnVisible = false},
                            new XtraColumn {ColumnName = "IncrementDate", ColumnVisible = false},
                            new XtraColumn {ColumnName = "DisposedDate", ColumnVisible = false},
                            new XtraColumn {ColumnName = "Unit", ColumnVisible = false},
                            new XtraColumn {ColumnName = "SerialNumber", ColumnVisible = false},
                            new XtraColumn {ColumnName = "Accessories", ColumnVisible = false},
                            new XtraColumn {ColumnName = "Quantity", ColumnVisible = false},
                            new XtraColumn {ColumnName = "UnitPrice", ColumnVisible = false},
                            new XtraColumn {ColumnName = "AccumDepreciationAmount", ColumnVisible = false},
                            new XtraColumn {ColumnName = "RemainingAmount", ColumnVisible = false},
                            new XtraColumn {ColumnName = "CurrencyCode", ColumnVisible = false},
                            new XtraColumn {ColumnName = "ExchangeRate", ColumnVisible = false},
                            new XtraColumn {ColumnName = "UnitPriceUSD", ColumnVisible = false},
                            new XtraColumn {ColumnName = "OrgPriceUSD", ColumnVisible = false},
                            new XtraColumn {ColumnName = "AccumDepreciationAmountUSD", ColumnVisible = false},
                            new XtraColumn {ColumnName = "RemainingAmountUSD", ColumnVisible = false},
                            new XtraColumn {ColumnName = "AnnualDepreciationAmount", ColumnVisible = false},
                            new XtraColumn {ColumnName = "AnnualDepreciationAmountUSD", ColumnVisible = false},
                            new XtraColumn {ColumnName = "DepreciationRate", ColumnVisible = false},
                            new XtraColumn {ColumnName = "OrgPriceAccountCode", ColumnVisible = false},
                            new XtraColumn {ColumnName = "DepreciationAccountCode", ColumnVisible = false},
                            new XtraColumn {ColumnName = "CapitalAccountCode", ColumnVisible = false},
                            new XtraColumn {ColumnName = "DepartmentId", ColumnVisible = false},
                            new XtraColumn {ColumnName = "EmployeeId", ColumnVisible = false},
                            new XtraColumn {ColumnName = "IsActive", ColumnVisible = false},
                            new XtraColumn { ColumnName = "RemainingOrgPrice", ColumnVisible = false },
                            new XtraColumn { ColumnName = "RemainingOrgPriceUSD", ColumnVisible = false },
                            new XtraColumn { ColumnName = "FixedAssetCurrencies", ColumnVisible = false },
                            new XtraColumn { ColumnName = "NumberOfFloor", ColumnVisible = false },
                            new XtraColumn { ColumnName = "AreaOfBuilding", ColumnVisible = false },
                            new XtraColumn { ColumnName = "AreaOfFloor", ColumnVisible = false },
                            new XtraColumn { ColumnName = "WorkingArea", ColumnVisible = false },
                            new XtraColumn { ColumnName = "AdministrationArea", ColumnVisible = false },
                            new XtraColumn { ColumnName = "HousingArea", ColumnVisible = false },
                            new XtraColumn { ColumnName = "VacancyArea", ColumnVisible = false },
                            new XtraColumn { ColumnName = "OccupiedArea", ColumnVisible = false },
                            new XtraColumn { ColumnName = "LeasingArea", ColumnVisible = false },
                            new XtraColumn { ColumnName = "GuestHouseArea", ColumnVisible = false },
                            new XtraColumn { ColumnName = "OtherArea", ColumnVisible = false },
                            new XtraColumn { ColumnName = "NumberOfSeat", ColumnVisible = false },
                            new XtraColumn { ColumnName = "ControlPlate", ColumnVisible = false },
                            new XtraColumn { ColumnName = "IsStateManagement", ColumnVisible = false },
                            new XtraColumn { ColumnName = "IsBussiness", ColumnVisible = false },
                            new XtraColumn { ColumnName = "Address", ColumnVisible = false }
                        };

                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditFixedAssetView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditFixedAssetView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            _gridLookUpEditFixedAssetView.Columns[column.ColumnName].Width = column.ColumnWith;
                            _gridLookUpEditFixedAssetView.Columns[column.ColumnName].ToolTip = column.ToolTip;
                            _gridLookUpEditFixedAssetView.Columns[column.ColumnName].AppearanceCell.TextOptions.HAlignment = column.Alignment;
                            _gridLookUpEditFixedAssetView.Columns[column.ColumnName].UnboundType = column.ColumnType;
                        }
                        else
                            _gridLookUpEditFixedAssetView.Columns[column.ColumnName].Visible = false;
                    }
                    _gridLookUpEditFixedAsset.DisplayMember = "FixedAssetCode";
                    _gridLookUpEditFixedAsset.ValueMember = "FixedAssetId";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Sets the accounts.
        /// </summary>
        /// <value>
        /// The accounts.
        /// </value>
        public IList<AccountModel> Accounts
        {
            set
            {
                try
                {
                    _gridLookUpEditAccountNumber.DataSource = value;
                    _gridLookUpEditAccountNumberView.PopulateColumns(value);

                    _gridLookUpEditCorrespondingAccountNumber.DataSource = value;
                    _gridLookUpEditCorrespondingAccountNumberView.PopulateColumns(value);

                    var gridColumnsCollection = new List<XtraColumn>
                        {
                            new XtraColumn {ColumnName = "AccountCode", ColumnCaption = "Mã tài khoản", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 150},
                            new XtraColumn {ColumnName = "AccountName", ColumnCaption = "Tên tài khoản", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 350},
                            new XtraColumn {ColumnName = "AccountId", ColumnVisible = false},
                            new XtraColumn {ColumnName = "ParentId", ColumnVisible = false},
                            new XtraColumn {ColumnName = "AccountCategoryId", ColumnVisible = false},
                            new XtraColumn {ColumnName = "Description", ColumnVisible = false},
                            new XtraColumn {ColumnName = "IsActive", ColumnVisible = false},
                            new XtraColumn {ColumnName = "ForeignName", ColumnVisible = false},
                            new XtraColumn {ColumnName = "Grade", ColumnVisible = false},
                            new XtraColumn {ColumnName = "IsDetail", ColumnVisible = false},
                            new XtraColumn {ColumnName = "BalanceSide", ColumnVisible = false},
                            new XtraColumn {ColumnName = "ConcomitantAccount", ColumnVisible = false},
                            new XtraColumn {ColumnName = "BankId", ColumnVisible = false},
                            new XtraColumn {ColumnName = "IsChapter", ColumnVisible = false},
                            new XtraColumn {ColumnName = "IsBudgetCategory", ColumnVisible = false},
                            new XtraColumn {ColumnName = "IsBudgetItem", ColumnVisible = false},
                            new XtraColumn {ColumnName = "IsBudgetGroup", ColumnVisible = false},
                            new XtraColumn {ColumnName = "IsBudgetSource", ColumnVisible = false},
                            new XtraColumn {ColumnName = "IsActivity", ColumnVisible = false},
                            new XtraColumn {ColumnName = "IsCurrency", ColumnVisible = false},
                            new XtraColumn {ColumnName = "IsCustomer", ColumnVisible = false},
                            new XtraColumn {ColumnName = "IsVendor", ColumnVisible = false},
                            new XtraColumn {ColumnName = "IsEmployee", ColumnVisible = false},
                            new XtraColumn {ColumnName = "IsAccountingObject", ColumnVisible = false},
                            new XtraColumn {ColumnName = "IsInventoryItem", ColumnVisible = false},
                            new XtraColumn {ColumnName = "IsFixedAsset", ColumnVisible = false},
                            new XtraColumn {ColumnName = "IsCapitalAllocate", ColumnVisible = false},
                            new XtraColumn {ColumnName = "IsSystem", ColumnVisible = false}
                        };

                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditAccountNumberView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditAccountNumberView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            _gridLookUpEditAccountNumberView.Columns[column.ColumnName].Width = column.ColumnWith;
                            _gridLookUpEditAccountNumberView.Columns[column.ColumnName].AppearanceCell.TextOptions.HAlignment = column.Alignment;

                            _gridLookUpEditCorrespondingAccountNumberView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditCorrespondingAccountNumberView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            _gridLookUpEditCorrespondingAccountNumberView.Columns[column.ColumnName].Width = column.ColumnWith;
                            _gridLookUpEditCorrespondingAccountNumberView.Columns[column.ColumnName].AppearanceCell.TextOptions.HAlignment = column.Alignment;
                        }
                        else
                        {
                            _gridLookUpEditAccountNumberView.Columns[column.ColumnName].Visible = false;
                            _gridLookUpEditCorrespondingAccountNumberView.Columns[column.ColumnName].Visible = false;
                        }
                    }
                    _gridLookUpEditAccountNumber.DisplayMember = "AccountCode";
                    _gridLookUpEditAccountNumber.ValueMember = "AccountCode";

                    _gridLookUpEditCorrespondingAccountNumber.DisplayMember = "AccountCode";
                    _gridLookUpEditCorrespondingAccountNumber.ValueMember = "AccountCode";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Sets the departments.
        /// </summary>
        /// <value>
        /// The departments.
        /// </value>
        public IList<DepartmentModel> Departments
        {
            set
            {
                try
                {
                    _gridLookUpEditDepartment.DataSource = value;
                    _gridLookUpEditDepartmentView.PopulateColumns(value);

                    var gridColumnsCollection = new List<XtraColumn>
                        {
                            new XtraColumn { ColumnName = "DepartmentCode", ColumnCaption = "Mã phòng ban", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 100 },
                            new XtraColumn { ColumnName = "DepartmentName", ColumnCaption = "Tên phòng ban", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 400 },
                            new XtraColumn { ColumnName = "DepartmentId", ColumnVisible = false },
                            new XtraColumn { ColumnName = "Description", ColumnVisible = false },
                            new XtraColumn { ColumnName = "IsActive", ColumnVisible = false }
                        };

                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditDepartmentView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditDepartmentView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            _gridLookUpEditDepartmentView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                            _gridLookUpEditDepartmentView.Columns[column.ColumnName].Visible = false;
                    }
                    _gridLookUpEditDepartment.DisplayMember = "DepartmentCode";
                    _gridLookUpEditDepartment.ValueMember = "DepartmentId";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Sets the voucher types.
        /// </summary>
        /// <value>
        /// The voucher types.
        /// </value>
        public IList<VoucherTypeModel> VoucherTypes
        {
            set
            {
                try
                {
                    _gridLookUpEditVoucherType.DataSource = value;
                    _gridLookUpEditVoucherTypeView.PopulateColumns(value);

                    var gridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn { ColumnName = "VoucherTypeName", ColumnCaption = "Nghiệp vụ", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 300 },
                        new XtraColumn { ColumnName = "VoucherTypeId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsActive", ColumnVisible = false }
                    };

                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditVoucherTypeView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditVoucherTypeView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            _gridLookUpEditVoucherTypeView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                            _gridLookUpEditVoucherTypeView.Columns[column.ColumnName].Visible = false;
                    }
                    _gridLookUpEditVoucherType.DisplayMember = "VoucherTypeName";
                    _gridLookUpEditVoucherType.ValueMember = "VoucherTypeId";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Sets the budget sources.
        /// </summary>
        /// <value>
        /// The budget sources.
        /// </value>
        public IList<BudgetSourceModel> BudgetSources
        {
            set
            {
                try
                {
                    _gridLookUpEditBudgetSource.DataSource = value;
                    _gridLookUpEditBudgetSourceView.PopulateColumns(value);

                    var gridColumnsCollection = new List<XtraColumn>
                        {
                            new XtraColumn {ColumnName = "BudgetSourceCode", ColumnCaption = "Mã nguồn vốn", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 100},
                            new XtraColumn {ColumnName = "BudgetSourceName", ColumnCaption = "Tên nguồn vốn", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 400},
                            new XtraColumn {ColumnName = "BudgetSourceId", ColumnVisible = false},
                            new XtraColumn {ColumnName = "ParentId", ColumnVisible = false},
                            new XtraColumn {ColumnName = "Description", ColumnVisible = false},
                            new XtraColumn {ColumnName = "Description", ColumnVisible = false},
                            new XtraColumn {ColumnName = "IsActive", ColumnVisible = false},
                            new XtraColumn {ColumnName = "IsSystem", ColumnVisible = false},
                            new XtraColumn {ColumnName = "ForeignName", ColumnVisible = false},
                            new XtraColumn {ColumnName = "IsParent", ColumnVisible = false},
                            new XtraColumn {ColumnName = "Grade", ColumnVisible = false},
                            new XtraColumn {ColumnName = "Type", ColumnVisible = false},
                            new XtraColumn {ColumnName = "IsSystem", ColumnVisible = false},
                            new XtraColumn {ColumnName = "Allocation", ColumnVisible = false},
                            new XtraColumn {ColumnName = "BudgetItemCode", ColumnVisible = false},
                            new XtraColumn {ColumnName = "IsFund", ColumnVisible = false},
                            new XtraColumn {ColumnName = "IsExpense", ColumnVisible = false},
                            new XtraColumn {ColumnName = "AccountCode", ColumnVisible = false}
                        };

                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditBudgetSourceView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditBudgetSourceView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            _gridLookUpEditBudgetSourceView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                            _gridLookUpEditBudgetSourceView.Columns[column.ColumnName].Visible = false;
                    }
                    _gridLookUpEditBudgetSource.DisplayMember = "BudgetSourceCode";
                    _gridLookUpEditBudgetSource.ValueMember = "BudgetSourceCode";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Sets the BudgetItems.
        /// </summary>
        /// <value>
        /// The BudgetItems.
        /// </value>
        public IList<BudgetItemModel> BudgetItems
        {
            set
            {
                try
                {
                    if (value == null) return;
                    var budgetItems = (from budgetItem in value where budgetItem.BudgetItemType >= 3 select budgetItem).ToList();
                    _gridLookUpEditBudgetItem.DataSource = budgetItems;
                    _gridLookUpEditBudgetItemView.PopulateColumns(budgetItems);

                    var gridColumnsCollection = new List<XtraColumn>
                        {
                            new XtraColumn {ColumnName = "BudgetItemCode", ColumnCaption = "Mã MLNS", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 100, ToolTip = "Mã mục lục ngân sách" },
                            new XtraColumn {ColumnName = "BudgetItemName", ColumnCaption = "Tên MLNS", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 400, ToolTip = "Tên mục lục ngân sách" },
                            new XtraColumn {ColumnName = "BudgetItemId", ColumnVisible = false},
                            new XtraColumn {ColumnName = "ParentId", ColumnVisible = false},
                            new XtraColumn {ColumnName = "IsParent", ColumnVisible = false},
                            new XtraColumn {ColumnName = "IsActive", ColumnVisible = false},
                            new XtraColumn {ColumnName = "BudgetGroupId", ColumnVisible = false},
                            new XtraColumn {ColumnName = "ForeignName", ColumnVisible = false},
                            new XtraColumn {ColumnName = "IsExpandItem", ColumnVisible = false},
                            new XtraColumn {ColumnName = "IsFixedItem", ColumnVisible = false},
                            new XtraColumn {ColumnName = "IsNoAllocate", ColumnVisible = false},
                            new XtraColumn {ColumnName = "IsOrganItem", ColumnVisible = false},
                            new XtraColumn {ColumnName = "BudgetItemType", ColumnVisible = false},
                            new XtraColumn {ColumnName = "IsReceipt", ColumnVisible = false},
                            new XtraColumn {ColumnName = "IsSystem", ColumnVisible = false},
                            new XtraColumn {ColumnName = "Grade", ColumnVisible = false},
                            new XtraColumn {ColumnName = "IsChoose", ColumnVisible = false},
                            new XtraColumn {ColumnName = "Rate", ColumnVisible = false}
                        };

                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditBudgetItemView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditBudgetItemView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            _gridLookUpEditBudgetItemView.Columns[column.ColumnName].Width = column.ColumnWith;
                            _gridLookUpEditBudgetItemView.Columns[column.ColumnName].ToolTip = column.ToolTip;
                        }
                        else
                            _gridLookUpEditBudgetItemView.Columns[column.ColumnName].Visible = false;
                    }
                    _gridLookUpEditBudgetItem.DisplayMember = "BudgetItemCode";
                    _gridLookUpEditBudgetItem.ValueMember = "BudgetItemCode";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Sets the projects.
        /// </summary>
        /// <value>
        /// The projects.
        /// </value>
        public IList<ProjectModel> Projects
        {
            set
            {
                try
                {
                    _gridLookUpEditProject.DataSource = value;
                    _gridLookUpEditProjectView.PopulateColumns(value);

                    var gridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn {ColumnName = "ProjectCode", ColumnCaption = "Mã dự án", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 150},
                        new XtraColumn {ColumnName = "ProjectName", ColumnCaption = "Tên dự án", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 450},
                        new XtraColumn {ColumnName = "ProjectId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ForeignName", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsParent", ColumnVisible = false},
                        new XtraColumn {ColumnName = "Grade", ColumnVisible = false},
                        new XtraColumn {ColumnName = "Description", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsActive", ColumnVisible = false}
                    };

                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditProjectView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditProjectView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            _gridLookUpEditProjectView.Columns[column.ColumnName].Width = column.ColumnWith;
                            _gridLookUpEditProjectView.Columns[column.ColumnName].ToolTip = column.ToolTip;
                        }
                        else
                            _gridLookUpEditProjectView.Columns[column.ColumnName].Visible = false;
                    }
                    _gridLookUpEditProject.DisplayMember = "ProjectCode";
                    _gridLookUpEditProject.ValueMember = "ProjectId";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region IFixedAssetArmortizationsView Members

        /// <summary>
        /// Sets the receipt estimates.
        /// </summary>
        /// <value>
        /// The receipt estimates.
        /// </value>
        public IList<FixedAssetArmortizationModel> FixedAssetArmortizations
        {
            set
            {
                //var fixedAsset = new List<FixedAssetArmortizationModel>();
                //fixedAsset = GlobalVariable.CurrencyType == 0 ? value.Where(x => x.CurrencyCode.Trim() == "USD").ToList() : value.Where(x => x.CurrencyCode.Trim() != "USD").ToList();
                //bindingSource.DataSource = fixedAsset;

                // Sửa theo nghiệp vụ của BA, Không lọc theo loại tiên.
                bindingSource.DataSource = value;
                gridView.PopulateColumns(value);

                _fixedAssetArmortizations = value;
                ColumnsCollection.Clear();
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefTypeId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CurrencyCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "PostedDate", ColumnCaption = "Ngày HT", ColumnVisible = true, ColumnPosition = 1, ColumnWith = 100, ToolTip = "Ngày hạch toán", ColumnType = UnboundColumnType.DateTime, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "FixedAssetArmortizationDetails", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefNo", ColumnCaption = "Số CT", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 70, ToolTip = "Số chứng từ" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefDate", ColumnCaption = "Ngày CT", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 100, ColumnType = UnboundColumnType.DateTime, Alignment = HorzAlignment.Center, ToolTip = "Ngày chứng từ" });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "JournalMemo", ColumnCaption = "Diễn giải", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 200 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalAmountOC", ColumnCaption = "Số tiền", ColumnPosition = 5, ColumnVisible = true, ColumnWith = 150, ColumnType = UnboundColumnType.Decimal });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalAmountExchange", ColumnCaption = "Số tiền quy đổi", ColumnPosition = 6, ColumnVisible = true, ColumnWith = 150, ColumnType = UnboundColumnType.Decimal });
            }
        }

        /// <summary>
        /// Gets or sets the fixed asset armortization details.
        /// </summary>
        /// <value>
        /// The fixed asset armortization details.
        /// </value>
        public IList<FixedAssetArmortizationDetailModel> FixedAssetArmortizationDetails
        {
            set
            {
                bindingSourceDetail.DataSource = value ?? new List<FixedAssetArmortizationDetailModel>();
                gridViewDetail.PopulateColumns(value);

                var columnsCollectionDetail = new List<XtraColumn>();

                columnsCollectionDetail.Add(new XtraColumn { ColumnName = "RefDetailId", ColumnVisible = false });
                columnsCollectionDetail.Add(new XtraColumn { ColumnName = "RefId", ColumnVisible = false });
                columnsCollectionDetail.Add(new XtraColumn { ColumnName = "BudgetChapterCode", ColumnVisible = false });
                columnsCollectionDetail.Add(new XtraColumn { ColumnName = "BudgetCategoryCode", ColumnVisible = false });
                columnsCollectionDetail.Add(new XtraColumn { ColumnName = "DetailBy", ColumnVisible = false });

                columnsCollectionDetail.Add(new XtraColumn { ColumnName = "FixedAssetId", ColumnCaption = "Mã TSCĐ", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 70, FixedColumn = FixedStyle.Left, ToolTip = "Mã số tài sản cố định", RepositoryControl = _gridLookUpEditFixedAsset });
                columnsCollectionDetail.Add(new XtraColumn { ColumnName = "AccountNumber", ColumnCaption = "TK Nợ", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 60, FixedColumn = FixedStyle.Left, ToolTip = "Tài khoản nợ", RepositoryControl = _gridLookUpEditAccountNumber });
                columnsCollectionDetail.Add(new XtraColumn { ColumnName = "CorrespondingAccountNumber", ColumnCaption = "TK Có", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 60, FixedColumn = FixedStyle.Left, ToolTip = "Tài khoản có", RepositoryControl = _gridLookUpEditCorrespondingAccountNumber });
                columnsCollectionDetail.Add(new XtraColumn { ColumnName = "Description", ColumnCaption = "Diễn giải", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 170, FixedColumn = FixedStyle.Left, IsSummaryText = true });

                columnsCollectionDetail.Add(new XtraColumn { ColumnName = "Quantity", ColumnCaption = "Số lượng", ColumnPosition = 5, ColumnVisible = true, ColumnWith = 60, FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Integer, IsSummnary = true });
                columnsCollectionDetail.Add(new XtraColumn { ColumnName = "AmountOC", ColumnCaption = "Số tiền", ColumnPosition = 6, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Decimal });
                columnsCollectionDetail.Add(new XtraColumn { ColumnName = "CurrencyCode", ColumnCaption = "Loại tiền", ColumnPosition = 7, ColumnVisible = true, ColumnWith = 70, FixedColumn = FixedStyle.None, RepositoryControl = _cboCurrencyCode });
                columnsCollectionDetail.Add(new XtraColumn { ColumnName = "ExchangeRate", ColumnCaption = "Tỷ giá", ColumnPosition = 8, ColumnVisible = true, ColumnWith = 70, FixedColumn = FixedStyle.None, RepositoryControl = _calcEditExchangeRate });
                columnsCollectionDetail.Add(new XtraColumn { ColumnName = "AmountExchange", ColumnCaption = "Quy đổi", ColumnPosition = 9, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.None, ColumnType = UnboundColumnType.Decimal, AllowEdit = false });

                columnsCollectionDetail.Add(new XtraColumn { ColumnName = "VoucherTypeId", ColumnCaption = "Nghiệp vụ", ColumnPosition = 10, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.None, RepositoryControl = _gridLookUpEditVoucherType });
                columnsCollectionDetail.Add(new XtraColumn { ColumnName = "DepartmentId", ColumnCaption = "Phòng ban", ColumnPosition = 11, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.None, RepositoryControl = _gridLookUpEditDepartment });
                columnsCollectionDetail.Add(new XtraColumn { ColumnName = "BudgetSourceCode", ColumnCaption = "Nguồn vốn", ColumnPosition = 12, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.None, RepositoryControl = _gridLookUpEditBudgetSource });
                columnsCollectionDetail.Add(new XtraColumn { ColumnName = "BudgetItemCode", ColumnCaption = "Mục/TM", ColumnPosition = 13, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.None, RepositoryControl = _gridLookUpEditBudgetItem });
                columnsCollectionDetail.Add(new XtraColumn { ColumnName = "ProjectId", ColumnCaption = "Dự án", ColumnPosition = 14, ColumnVisible = false, ColumnWith = 100, FixedColumn = FixedStyle.None, RepositoryControl = _gridLookUpEditProject });
                columnsCollectionDetail.Add(new XtraColumn { ColumnName = "AutoBusinessId", ColumnCaption = "", ColumnPosition = 14, ColumnVisible = false, ColumnWith = 100, FixedColumn = FixedStyle.None, RepositoryControl = _gridLookUpEditProject });

                foreach (var column in columnsCollectionDetail)
                {
                    if (column.ColumnVisible)
                    {
                        gridViewDetail.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        gridViewDetail.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                        gridViewDetail.Columns[column.ColumnName].Width = column.ColumnWith;
                        gridViewDetail.Columns[column.ColumnName].UnboundType = column.ColumnType;
                        gridViewDetail.Columns[column.ColumnName].Fixed = column.FixedColumn;
                        gridViewDetail.Columns[column.ColumnName].ToolTip = column.ToolTip;
                        gridViewDetail.Columns[column.ColumnName].ColumnEdit = column.RepositoryControl;
                        gridViewDetail.Columns[column.ColumnName].OptionsColumn.AllowEdit = true;
                        if (column.ColumnName == "AmountExchange")
                            gridViewDetail.Columns[column.ColumnName].OptionsColumn.AllowEdit = false;
                    }
                    else
                        gridViewDetail.Columns[column.ColumnName].Visible = false;
                }
                SetNumericFormatControl(gridViewDetail, true);
            }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="UserControlFAArmortizationList"/> class.
        /// </summary>
        public UserControlFAArmortizationList()
        {
            InitializeComponent();
            _fixedAssetArmortizationsPresenter = new FixedAssetArmortizationsPresenter(this);
            _fixedAssetsPresenter = new FixedAssetsPresenter(this);
            _accountsPresenter = new AccountsPresenter(this);
            _departmentsPresenter = new DepartmentsPresenter(this);
            _voucherTypesPresenter = new VoucherTypesPresenter(this);
            _budgetSourcesPresenter = new BudgetSourcesPresenter(this);
            _budgetItemsPresenter = new BudgetItemsPresenter(this);
            _projectsPresenter = new ProjectsPresenter(this);
        }

        /// <summary>
        /// Loads the data into grid.
        /// </summary>
        protected override void LoadDataIntoGrid()
        {
            DBOptionHelper = new GlobalVariable();
            LoadRepositoryControls();

            _fixedAssetsPresenter.Display();
            _accountsPresenter.DisplayActive();
            _departmentsPresenter.DisplayActive();
            _voucherTypesPresenter.DisplayActive();
            _budgetSourcesPresenter.DisplayActive();
            _budgetItemsPresenter.Display(3, true);
            //_projectsPresenter.DisplayActive();

            if (GlobalVariable.DisplayVourcherMode == 1)
                _fixedAssetArmortizationsPresenter.DisplayIncludeDetails();
            else
                _fixedAssetArmortizationsPresenter.DisplayIncludeDetails(DateTime.Parse(DBOptionHelper.PostedDate).ToShortDateString());
        }

        /// <summary>
        /// Loads the data into grid detail.
        /// </summary>
        protected override void LoadDataIntoGridDetail()
        {
            try
            {
                var fixedAssetArmortizationModel = _fixedAssetArmortizations.First(f => f.RefId == long.Parse(PrimaryKeyValue));
                FixedAssetArmortizationDetails = fixedAssetArmortizationModel.FixedAssetArmortizationDetails;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(),
                    ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Deletes the grid.
        /// </summary>
        protected override void DeleteGrid()
        {
            new FixedAssetArmortizationPresenter(null).Delete(int.Parse(PrimaryKeyValue));
        }

        /// <summary>
        /// Gets the form detail.
        /// </summary>
        /// <returns></returns>
        protected override FrmXtraBaseVoucherDetail GetFormDetail()
        {
            return new FrmXtraFormFAArmortizationDetail();
        }

        /// <summary>
        /// Loads the repository controls.
        /// </summary>
        private void LoadRepositoryControls()
        {
            //RepositoryItemGridLookUpEdit FixedAsset
            _gridLookUpEditFixedAssetView = new GridView();
            _gridLookUpEditFixedAssetView.OptionsView.ColumnAutoWidth = false;
            _gridLookUpEditFixedAsset = new RepositoryItemGridLookUpEdit
            {
                NullText = "",
                View = _gridLookUpEditFixedAssetView,
                TextEditStyle = TextEditStyles.Standard,
                PopupResizeMode = ResizeMode.FrameResize,
                PopupFormSize = new Size(700, 200),
                ShowFooter = false
            };
            _gridLookUpEditFixedAsset.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
            _gridLookUpEditFixedAsset.View.OptionsView.ShowIndicator = false;
            _gridLookUpEditFixedAsset.View.BestFitColumns();

            //RepositoryItemGridLookUpEdit AccountNumber
            _gridLookUpEditAccountNumberView = new GridView();
            _gridLookUpEditAccountNumberView.OptionsView.ColumnAutoWidth = false;
            _gridLookUpEditAccountNumber = new RepositoryItemGridLookUpEdit
            {
                NullText = "",
                View = _gridLookUpEditAccountNumberView,
                TextEditStyle = TextEditStyles.Standard,
                PopupResizeMode = ResizeMode.FrameResize,
                PopupFormSize = new Size(500, 200),
                ShowFooter = false
            };
            _gridLookUpEditAccountNumber.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
            _gridLookUpEditAccountNumber.View.OptionsView.ShowIndicator = false;
            _gridLookUpEditAccountNumber.View.BestFitColumns();

            //RepositoryItemGridLookUpEdit CorrespondingAccountNumber
            _gridLookUpEditCorrespondingAccountNumberView = new GridView();
            _gridLookUpEditCorrespondingAccountNumberView.OptionsView.ColumnAutoWidth = false;
            _gridLookUpEditCorrespondingAccountNumber = new RepositoryItemGridLookUpEdit
            {
                NullText = "",
                View = _gridLookUpEditCorrespondingAccountNumberView,
                TextEditStyle = TextEditStyles.Standard,
                PopupResizeMode = ResizeMode.FrameResize,
                PopupFormSize = new Size(500, 200),
                ShowFooter = false
            };
            _gridLookUpEditCorrespondingAccountNumber.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
            _gridLookUpEditCorrespondingAccountNumber.View.OptionsView.ShowIndicator = false;
            _gridLookUpEditCorrespondingAccountNumber.View.BestFitColumns();

            //RepositoryItemComboBox CorrespondingAccountNumber
            _cboCurrencyCode = new RepositoryItemComboBox();

            //RepositoryItemCalcEdit ExchangeRate
            _calcEditExchangeRate = new RepositoryItemCalcEdit();
            _calcEditExchangeRate.EditFormat.FormatType = FormatType.Numeric;
            _calcEditExchangeRate.EditMask = @"F" + DBOptionHelper.ExchangeRateDecimalDigits;

            //RepositoryItemGridLookUpEdit Department
            _gridLookUpEditDepartmentView = new GridView();
            _gridLookUpEditDepartmentView.OptionsView.ColumnAutoWidth = false;
            _gridLookUpEditDepartment = new RepositoryItemGridLookUpEdit
            {
                NullText = "",
                View = _gridLookUpEditDepartmentView,
                TextEditStyle = TextEditStyles.Standard,
                PopupResizeMode = ResizeMode.FrameResize,
                PopupFormSize = new Size(500, 200),
                ShowFooter = false
            };
            _gridLookUpEditDepartment.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
            _gridLookUpEditDepartment.View.OptionsView.ShowIndicator = false;
            _gridLookUpEditDepartment.View.BestFitColumns();

            //RepositoryItemGridLookUpEdit VoucherType
            _gridLookUpEditVoucherTypeView = new GridView();
            _gridLookUpEditVoucherTypeView.OptionsView.ColumnAutoWidth = false;
            _gridLookUpEditVoucherType = new RepositoryItemGridLookUpEdit
            {
                NullText = "",
                View = _gridLookUpEditVoucherTypeView,
                TextEditStyle = TextEditStyles.Standard,
                PopupResizeMode = ResizeMode.FrameResize,
                PopupFormSize = new Size(300, 200),
                ShowFooter = false
            };
            _gridLookUpEditVoucherType.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
            _gridLookUpEditVoucherType.View.OptionsView.ShowIndicator = false;
            _gridLookUpEditVoucherType.View.OptionsView.ShowHorizontalLines = DefaultBoolean.False;
            _gridLookUpEditVoucherType.View.OptionsView.ShowColumnHeaders = false;
            _gridLookUpEditVoucherType.View.BestFitColumns();

            //RepositoryItemGridLookUpEdit BudgetSource
            _gridLookUpEditBudgetSourceView = new GridView();
            _gridLookUpEditBudgetSourceView.OptionsView.ColumnAutoWidth = false;
            _gridLookUpEditBudgetSource = new RepositoryItemGridLookUpEdit
            {
                NullText = "",
                View = _gridLookUpEditBudgetSourceView,
                TextEditStyle = TextEditStyles.Standard,
                PopupResizeMode = ResizeMode.FrameResize,
                PopupFormSize = new Size(500, 200),
                ShowFooter = false
            };
            _gridLookUpEditBudgetSource.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
            _gridLookUpEditBudgetSource.View.OptionsView.ShowIndicator = false;
            _gridLookUpEditBudgetSource.View.BestFitColumns();

            //RepositoryItemGridLookUpEdit BudgetItem
            _gridLookUpEditBudgetItemView = new GridView();
            _gridLookUpEditBudgetItemView.OptionsView.ColumnAutoWidth = false;
            _gridLookUpEditBudgetItem = new RepositoryItemGridLookUpEdit
            {
                NullText = "",
                View = _gridLookUpEditBudgetItemView,
                TextEditStyle = TextEditStyles.Standard,
                PopupResizeMode = ResizeMode.FrameResize,
                PopupFormSize = new Size(500, 200),
                ShowFooter = false
            };
            _gridLookUpEditBudgetItem.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
            _gridLookUpEditBudgetItem.View.OptionsView.ShowIndicator = false;
            _gridLookUpEditBudgetItem.View.BestFitColumns();

            //RepositoryItemGridLookUpEdit Project
            _gridLookUpEditProjectView = new GridView();
            _gridLookUpEditProjectView.OptionsView.ColumnAutoWidth = false;
            _gridLookUpEditProject = new RepositoryItemGridLookUpEdit
            {
                NullText = "",
                View = _gridLookUpEditProjectView,
                TextEditStyle = TextEditStyles.Standard,
                PopupResizeMode = ResizeMode.FrameResize,
                PopupFormSize = new Size(500, 200),
                ShowFooter = false
            };
            _gridLookUpEditProject.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
            _gridLookUpEditProject.View.OptionsView.ShowIndicator = false;
            _gridLookUpEditProject.View.BestFitColumns();
        }

        /// <summary>
        /// Sets the numeric format control.
        /// </summary>
        /// <param name="gridView">The grid view.</param>
        /// <param name="isSummary">if set to <c>true</c> [is summary].</param>
        private void SetNumericFormatControl(GridView gridView, bool isSummary)
        {
            //Get format data from db to format grid control
            if (DesignMode) return;
            var repositoryCurrencyCalcEdit = new RepositoryItemCalcEdit { AllowMouseWheel = false };
            var repositoryNumberCalcEdit = new RepositoryItemCalcEdit { AllowMouseWheel = false };

            foreach (GridColumn oCol in gridView.Columns)
            {
                if (!oCol.Visible) continue;
                switch (oCol.UnboundType)
                {
                    case UnboundColumnType.Decimal:
                        repositoryCurrencyCalcEdit.Mask.MaskType = MaskType.Numeric;
                        repositoryCurrencyCalcEdit.Mask.EditMask = @"c" + DBOptionHelper.CurrencyDecimalDigits;
                        repositoryCurrencyCalcEdit.Mask.Culture = Thread.CurrentThread.CurrentCulture;
                        repositoryCurrencyCalcEdit.Mask.UseMaskAsDisplayFormat = true;
                        oCol.ColumnEdit = repositoryCurrencyCalcEdit;
                        if (isSummary)
                        {
                            oCol.SummaryItem.SummaryType = SummaryItemType.Sum;
                            oCol.SummaryItem.DisplayFormat = GlobalVariable.CurrencyDisplayString;
                            oCol.SummaryItem.Format = Thread.CurrentThread.CurrentCulture;
                        }
                        break;

                    case UnboundColumnType.Integer:
                        repositoryNumberCalcEdit.Mask.MaskType = MaskType.Numeric;
                        repositoryNumberCalcEdit.Mask.EditMask = @"n0";
                        repositoryNumberCalcEdit.Mask.UseMaskAsDisplayFormat = true;
                        repositoryNumberCalcEdit.Mask.Culture = Thread.CurrentThread.CurrentCulture;
                        oCol.ColumnEdit = repositoryNumberCalcEdit;

                        if (isSummary)
                        {
                            oCol.SummaryItem.SummaryType = SummaryItemType.Sum;
                            oCol.SummaryItem.DisplayFormat = GlobalVariable.NumericDisplayString;
                            oCol.SummaryItem.Format = Thread.CurrentThread.CurrentCulture;
                        }
                        break;

                    case UnboundColumnType.DateTime:
                        oCol.DisplayFormat.FormatString =
                            Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
                        oCol.DisplayFormat.Format = Thread.CurrentThread.CurrentCulture.DateTimeFormat;
                        break;
                }
            }
        }
    }
}

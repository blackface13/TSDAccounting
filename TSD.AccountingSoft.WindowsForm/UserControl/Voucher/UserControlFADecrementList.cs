/***********************************************************************
 * <copyright file="UserControlFADecrementList.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Thursday, April 11, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  07/03/2014       Author    Tudt           Description: Coding standard
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TSD.AccountingSoft.Session;
using TSD.AccountingSoft.WindowsForm.BaseUserControls;
using TSD.AccountingSoft.Model.BusinessObjects.FixedAsset;
using TSD.AccountingSoft.Presenter.Dictionary.FixedAsset;
using TSD.AccountingSoft.Presenter.FixedAsset.FixedAssetDecrement;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.View.FixedAsset;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.FormBusiness;
using TSD.AccountingSoft.WindowsForm.Resources;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using TSD.AccountingSoft.Presenter.Dictionary.AutoBusiness;
using TSD.AccountingSoft.Presenter.Dictionary.Project;
using TSD.AccountingSoft.Presenter.Dictionary.Department;
using TSD.AccountingSoft.Presenter.Dictionary.VoucherType;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.WindowsForm.CommonClass;
using System.Linq;

namespace TSD.AccountingSoft.WindowsForm.UserControl.Voucher
{
    /// <summary>
    /// class UserControlFADecrementList
    /// </summary>
    public partial class UserControlFADecrementList : BaseVoucherListUserControl, IFixedAssetDecrementsView, IFixedAssetsView, IAutoBusinessesView, 
        IProjectsView, IDepartmentsView, IVoucherTypesView
    {
        private readonly FixedAssetDecrementsPresenter _fixedAssetDecrementsPresenter;
        private readonly RepositoryItemGridLookUpEdit _gridLookUpEditFixedAsset;
        private readonly FixedAssetsPresenter _fixedAssetsPresenter;


        private readonly AutoBusinessesPresenter _autoBusinessPresenter;
        private readonly ProjectsPresenter _projectsPresenter;
        private readonly DepartmentsPresenter _departmentsPresenter;
        private readonly VoucherTypesPresenter _voucherTypesPresenter;

        private readonly RepositoryItemGridLookUpEdit _gridLookUpEditAutoBusiness;
        private readonly RepositoryItemGridLookUpEdit _gridLookUpEditProject;
        private readonly RepositoryItemGridLookUpEdit _gridLookUpEditDepartment;
        private readonly RepositoryItemGridLookUpEdit _gridLookUpEditVoucherType;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserControlFADecrementList"/> class.
        /// </summary>
        public UserControlFADecrementList()
        {
            InitializeComponent();
            _gridLookUpEditFixedAsset = new RepositoryItemGridLookUpEdit();
            _gridLookUpEditAutoBusiness = new RepositoryItemGridLookUpEdit();
            _gridLookUpEditProject = new RepositoryItemGridLookUpEdit();
            _gridLookUpEditDepartment = new RepositoryItemGridLookUpEdit();
            _gridLookUpEditVoucherType = new RepositoryItemGridLookUpEdit();

            _fixedAssetsPresenter = new FixedAssetsPresenter(this);
            _fixedAssetDecrementsPresenter = new FixedAssetDecrementsPresenter(this);
            _autoBusinessPresenter = new AutoBusinessesPresenter(this);
            _projectsPresenter = new ProjectsPresenter(this);
            _departmentsPresenter = new DepartmentsPresenter(this);
            _voucherTypesPresenter = new VoucherTypesPresenter(this);
        }

        public IList<Model.BusinessObjects.Dictionary.FixedAssetModel> FixedAssets
        {
            set
            {
                try

                {
                    var fixedAsset = new List<FixedAssetModel>();
                    fixedAsset = GlobalVariable.CurrencyType == 0 ? value.Where(x => x.CurrencyCode.Trim() == "USD").ToList() : value.Where(x => x.CurrencyCode.Trim() != "USD").ToList();
                    _gridLookUpEditFixedAsset.DataSource = fixedAsset;
                    _gridLookUpEditFixedAsset.View.PopulateColumns(fixedAsset);
               

                    var gridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn
                        {
                            ColumnName = "FixedAssetCode",
                            ColumnCaption = "Mã tài sản",
                            ColumnPosition = 1,
                            ColumnVisible = true,
                            ColumnWith = 100,
                            Alignment = HorzAlignment.Near
                        },
                        new XtraColumn
                        {
                            ColumnName = "FixedAssetName",
                            ColumnCaption = "Tên tài sản",
                            ColumnPosition = 2,
                            ColumnVisible = true,
                            ColumnWith = 250,
                            Alignment = HorzAlignment.Near
                        },
                        new XtraColumn
                        {
                            ColumnName = "OrgPrice",
                            ColumnCaption = "Nguyên giá",
                            ColumnPosition = 3,
                            ColumnVisible = true,
                            ColumnWith = 150,
                            ColumnType = UnboundColumnType.Decimal,
                            Alignment = HorzAlignment.Far
                        },
                        new XtraColumn
                        {
                            ColumnName = "LifeTime",
                            ColumnCaption = "Thời gian SD",
                            ColumnPosition = 4,
                            ColumnVisible = true,
                            ColumnWith = 100,
                            ColumnType = UnboundColumnType.Integer,
                            Alignment = HorzAlignment.Far,
                            ToolTip = "Thời gian sử dụng"
                        },
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
                        new XtraColumn {ColumnName = "RemainingOrgPrice", ColumnVisible = false},
                        new XtraColumn {ColumnName = "RemainingOrgPriceUSD", ColumnVisible = false},
                        new XtraColumn {ColumnName = "FixedAssetCurrencies", ColumnVisible = false},
                        new XtraColumn {ColumnName = "NumberOfFloor", ColumnVisible = false},
                        new XtraColumn {ColumnName = "AreaOfBuilding", ColumnVisible = false},
                        new XtraColumn {ColumnName = "AreaOfFloor", ColumnVisible = false},
                        new XtraColumn {ColumnName = "WorkingArea", ColumnVisible = false},
                        new XtraColumn {ColumnName = "AdministrationArea", ColumnVisible = false},
                        new XtraColumn {ColumnName = "HousingArea", ColumnVisible = false},
                        new XtraColumn {ColumnName = "VacancyArea", ColumnVisible = false},
                        new XtraColumn {ColumnName = "OccupiedArea", ColumnVisible = false},
                        new XtraColumn {ColumnName = "LeasingArea", ColumnVisible = false},
                        new XtraColumn {ColumnName = "GuestHouseArea", ColumnVisible = false},
                        new XtraColumn {ColumnName = "OtherArea", ColumnVisible = false},
                        new XtraColumn {ColumnName = "NumberOfSeat", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ControlPlate", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsStateManagement", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsBussiness", ColumnVisible = false},
                        new XtraColumn {ColumnName = "Address", ColumnVisible = false},
                        new XtraColumn {ColumnName = "BudgetSourceCode", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ManagementCar", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsEstimateEmployee", ColumnVisible = false},
                        new XtraColumn {ColumnName = "Brand", ColumnVisible = false}
                    };

                    foreach (XtraColumn column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditFixedAsset.View.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditFixedAsset.View.Columns[column.ColumnName].SortIndex = column.ColumnPosition;
                            _gridLookUpEditFixedAsset.View.Columns[column.ColumnName].Width = column.ColumnWith;
                            _gridLookUpEditFixedAsset.View.Columns[column.ColumnName].ToolTip = column.ToolTip;
                            _gridLookUpEditFixedAsset.View.Columns[column.ColumnName].AppearanceCell.TextOptions
                                .HAlignment = column.Alignment;
                            _gridLookUpEditFixedAsset.View.Columns[column.ColumnName].UnboundType = column.ColumnType;
                        }
                        else
                            _gridLookUpEditFixedAsset.View.Columns[column.ColumnName].Visible = false;
                    }
                    _gridLookUpEditFixedAsset.DisplayMember = "FixedAssetCode";
                    _gridLookUpEditFixedAsset.ValueMember = "FixedAssetId";
                    _gridLookUpEditFixedAsset.ShowFooter = false;
                    _gridLookUpEditFixedAsset.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditFixedAsset.PopupResizeMode = ResizeMode.FrameResize;
                    _gridLookUpEditFixedAsset.PopupFormSize = new Size(600, 250);
                    _gridLookUpEditFixedAsset.View.OptionsView.ShowIndicator = false;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Sets the fixed asset decrement.
        /// </summary>
        /// <value>
        /// The fixed asset decrement.
        /// </value>
        public IList<FixedAssetDecrementModel> FixedAssetDecrements {
            set
            {
                var fixedAsset = new List<FixedAssetDecrementModel>();
                fixedAsset = GlobalVariable.CurrencyType == 0 ? value.Where(x => x.CurrencyCode.Trim() == "USD").ToList() : value.Where(x => x.CurrencyCode.Trim() != "USD").ToList();
                bindingSource.DataSource = fixedAsset;
                gridView.PopulateColumns(fixedAsset);
                ColumnsCollection.Clear();
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefTypeId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CustomerId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "VendorId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "EmployeeId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ExchangeRate", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectType", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "FixedAssetDecrementDetails", ColumnVisible = false});
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DocumentInclude", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Trader", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BankId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "PostedDate", ColumnCaption = "Ngày HT", ToolTip = "Ngày hạch toán", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 70, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefNo", ColumnCaption = "Số CT", ToolTip = "Số chứng từ", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 70 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefDate", ColumnCaption = "Ngày CT", ToolTip = "Ngày chứng từ", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 70, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CurrencyCode", ColumnCaption = "Loại tiền tệ", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 100 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "JournalMemo", ColumnCaption = "Diễn giải", ColumnPosition = 5, ColumnVisible = true, ColumnWith = 200 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalAmountOC", ColumnCaption = "Tổng tiền", ColumnPosition = 6, ColumnVisible = true, ColumnWith = 150, ColumnType = UnboundColumnType.Decimal, Alignment = HorzAlignment.Far });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalAmountExchange", ColumnCaption = "Tổng tiền quy đổi", ColumnPosition = 7, ColumnVisible = true, ColumnWith = 150, ColumnType = UnboundColumnType.Decimal });

            }
        }

        public IList<FixedAssetDecrementDetailModel> FixedAssetDecrementDetails
        {
            set
            {
                bindingSourceDetail.DataSource = value;
                gridViewDetail.PopulateColumns(value);
                ColumnsCollection.Clear();

                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefDetailId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DetailBy", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AutoBusinessId", ColumnCaption = "ĐK Tự động", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 80, AllowEdit = true, ToolTip = "Định khoản tự động", Alignment = HorzAlignment.Center, RepositoryControl = _gridLookUpEditAutoBusiness });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "FixedAssetId", ColumnCaption = "Mã TSCĐ", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 70, AllowEdit = true, ToolTip = "Mã tài sản cố định", Alignment = HorzAlignment.Center, RepositoryControl = _gridLookUpEditFixedAsset });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountNumber", ColumnCaption = "TK Nợ", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 60, AllowEdit = true, ToolTip = "Tài khoản nợ", Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CorrespondingAccountNumber", ColumnCaption = "TK Có", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 60, ToolTip = "Tài khoản có", AllowEdit = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnCaption = "Diễn giải", ColumnPosition = 5, ColumnVisible = true, ColumnWith = 250, AllowEdit = true, IsSummaryText = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Quantity", ColumnCaption = "Số lượng", ColumnPosition = 6, ColumnVisible = true, ColumnWith = 60, ColumnType = UnboundColumnType.Integer, IsSummnary = false, AllowEdit = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "UnitPriceOC", ColumnCaption = "Đơn giá", ColumnPosition = 7, ColumnVisible = true, ColumnWith = 100, ColumnType = UnboundColumnType.Decimal, AllowEdit = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "UnitPriceExchange", ColumnCaption = "Đơn giá quy đổi", ColumnPosition = 8, ColumnVisible = true, ColumnWith = 100, ColumnType = UnboundColumnType.Decimal, AllowEdit = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AmountOC", ColumnCaption = "Thành tiền", ColumnPosition = 9, ColumnVisible = true, ColumnWith = 100, ColumnType = UnboundColumnType.Decimal, AllowEdit = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AmountExchange", ColumnCaption = "Thành tiền QĐ", ColumnPosition = 10, ColumnVisible = true, ColumnWith = 100, ColumnType = UnboundColumnType.Decimal, AllowEdit = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "VoucherTypeId", ColumnCaption = "Nghiệp vụ", ColumnPosition = 11, ColumnVisible = true, ColumnWith = 100, AllowEdit = true, RepositoryControl = _gridLookUpEditVoucherType });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceCode", ColumnCaption = "Nguồn vốn", ColumnPosition = 12, ColumnVisible = true, ColumnWith = 100, AllowEdit = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemCode", ColumnCaption = "Mục/TM", ColumnPosition = 13, ColumnVisible = true, ColumnWith = 100, ToolTip = "Mục/Tiểu mục", AllowEdit = true });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DepartmentId", ColumnCaption = "Phòng ban", ColumnVisible = true, ColumnPosition = 14, ColumnWith = 100, AllowEdit = true, RepositoryControl = _gridLookUpEditDepartment });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectId", ColumnCaption = "Dự án", ColumnVisible = false, ColumnPosition = 15, ColumnWith = 100, AllowEdit = true, RepositoryControl = _gridLookUpEditProject });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountingObjectId", ColumnCaption = "ĐT Khác", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetChapterCode", ColumnCaption = "Chương", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetCategoryCode", ColumnCaption = "Loại khoản", ColumnVisible = false });

                foreach (XtraColumn column in ColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        gridViewDetail.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        gridViewDetail.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                        gridViewDetail.Columns[column.ColumnName].Width = column.ColumnWith;
                        gridViewDetail.Columns[column.ColumnName].UnboundType = column.ColumnType;
                        gridViewDetail.Columns[column.ColumnName].ToolTip = column.ToolTip;
                        gridViewDetail.Columns[column.ColumnName].ColumnEdit = column.RepositoryControl;
                        gridViewDetail.Columns[column.ColumnName].BestFit();
                    }
                    else gridViewDetail.Columns[column.ColumnName].Visible = false;
                }
                SetNumericFormatControl(gridViewDetail, true);
            }
        }

        public IList<AutoBusinessModel> AutoBusinesses
        {
            set
            {
                GridLookUpItem.AutoBusiness(value, _gridLookUpEditAutoBusiness, "AutoBusinessCode", "AutoBusinessCode");
            }
        }
        public IList<ProjectModel> Projects
        {
            set
            {
                GridLookUpItem.Project(value, _gridLookUpEditProject, "ProjectCode", "ProjectId");
            }
        }
        public IList<DepartmentModel> Departments
        {
            set
            {
                GridLookUpItem.Department(value, _gridLookUpEditDepartment, "DepartmentCode", "DepartmentId");
            }
        }
        public IList<VoucherTypeModel> VoucherTypes
        {
            set
            {
                GridLookUpItem.Department(value, _gridLookUpEditVoucherType, "VoucherTypeName", "VoucherTypeId");
            }
        }

        /// <summary>
        /// Loads the data into grid.
        /// </summary>
        protected override void LoadDataIntoGrid()
        {
            if (GlobalVariable.DisplayVourcherMode == 1)
                _fixedAssetDecrementsPresenter.Display();
            else
            {
                _fixedAssetDecrementsPresenter.Display(PostedDate);
            }
        }

        /// <summary>
        /// Loads the data into grid detail.
        /// LinhMC add 30.9.2016
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        protected override void LoadDataIntoGridDetail(long refId)
        {
            _fixedAssetsPresenter.Display();
            _fixedAssetDecrementsPresenter.DisplayVoucherDetail(refId);

            _autoBusinessPresenter.DisplayActive();
            //_projectsPresenter.DisplayActive();
            _voucherTypesPresenter.DisplayActive();
            _departmentsPresenter.DisplayActive();
        }

        /// <summary>
        /// Deletes the grid.
        /// </summary>
        protected override void DeleteGrid()
        {
            new FixedAssetDecrementPresenter(null).Delete(int.Parse(PrimaryKeyValue));
        }

        /// <summary>
        /// Gets the form detail.
        /// </summary>
        /// <returns></returns>
        protected override FrmXtraBaseVoucherDetail GetFormDetail()
        {
            return new FrmXtraFormFADecrementDetail();
        }
    }
}

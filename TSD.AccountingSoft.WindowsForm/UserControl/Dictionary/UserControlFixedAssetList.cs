/***********************************************************************
 * <copyright file="UserControlFixedAssetList.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Friday, February 28, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Model.BusinessObjects.FixedAsset;
using TSD.AccountingSoft.Presenter.Dictionary.FixedAsset;
using TSD.AccountingSoft.Presenter.FixedAsset.FixedAssetLedger;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.View.FixedAsset;
using TSD.AccountingSoft.WindowsForm.BaseUserControls;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.FormDictionary;
using TSD.AccountingSoft.WindowsForm.Resources;
using TSD.Enum;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;

namespace TSD.AccountingSoft.WindowsForm.UserControl.Dictionary
{
    /// <summary>
    ///     User Control FixedAsset List
    /// </summary>
    public partial class UserControlFixedAssetList : BaseListUserControl, IFixedAssetsView, IFixedAssetLedgersView
    {
        private readonly FixedAssetLedgersPresenter _fixedAssetLedgersPresenter;

        /// <summary>
        ///     The _fixed assets presenter
        /// </summary>
        private readonly FixedAssetsPresenter _fixedAssetsPresenter;

        public int RefTypeVoucher { get; set; }
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="UserControlFixedAssetList" /> class.
        /// </summary>
        public UserControlFixedAssetList()
        {
            InitializeComponent();
            _fixedAssetsPresenter = new FixedAssetsPresenter(this);
            _fixedAssetLedgersPresenter = new FixedAssetLedgersPresenter(this);
            barButtonPrintFixedAssetItem.Visibility = BarItemVisibility.Always;
           
        }

        #region IFixedAssetsView Members

        /// <summary>
        ///     Sets the fixed assets.
        /// </summary>
        /// <value>
        ///     The fixed assets.
        /// </value>
        public IList<FixedAssetModel> FixedAssets
        {
            set
            {
                ListBindingSource.DataSource = value;
                gridView.PopulateColumns(value);
                IList fixedAssetStateList = typeof (FixedAssetState).ToList();
                var repositoryState = new RepositoryItemLookUpEdit
                {
                    DataSource = fixedAssetStateList,
                    DisplayMember = "Value",
                    ValueMember = "Key",
                    ShowHeader = false
                };
                repositoryState.PopulateColumns();
                repositoryState.Columns["Key"].Visible = false;

                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "FixedAssetCode",
                    ColumnCaption = "Mã tài sản",
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 100
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "FixedAssetName",
                    ColumnCaption = "Tên tài sản",
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 350
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "UsedDate",
                    ColumnCaption = "Ngày sử dụng",
                    ColumnPosition = 3,
                    ColumnVisible = true,
                    ColumnWith = 100,
                    ColumnType = UnboundColumnType.DateTime,
                    Alignment = HorzAlignment.Center
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "Quantity",
                    ColumnCaption = "Số lượng",
                    ColumnPosition = 4,
                    ColumnVisible = true,
                    ColumnWith = 60,
                    ColumnType = UnboundColumnType.Integer,
                    Alignment = HorzAlignment.Center
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "CurrencyCode",
                    ColumnCaption = "Tiền tệ",
                    ColumnPosition = 5,
                    ColumnVisible = true,
                    ColumnWith = 60,
                    Alignment = HorzAlignment.Center
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "OrgPrice",
                    ColumnCaption = "Nguyên giá",
                    ColumnPosition = 6,
                    ColumnVisible = true,
                    ColumnWith = 120,
                    ColumnType = UnboundColumnType.Decimal,
                    Alignment = HorzAlignment.Far
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "State",
                    ColumnCaption = "Tình trạng",
                    ColumnPosition = 7,
                    ColumnVisible = true,
                    ColumnWith = 120,
                    RepositoryControl = repositoryState
                });

                ColumnsCollection.Add(new XtraColumn {ColumnName = "FixedAssetId", ColumnVisible = false});
                ColumnsCollection.Add(new XtraColumn {ColumnName = "FixedAssetCurrencies", ColumnVisible = false});
                ColumnsCollection.Add(new XtraColumn {ColumnName = "FixedAssetForeignName", ColumnVisible = false});
                ColumnsCollection.Add(new XtraColumn {ColumnName = "Description", ColumnVisible = false});
                ColumnsCollection.Add(new XtraColumn {ColumnName = "ProductionYear", ColumnVisible = false});
                ColumnsCollection.Add(new XtraColumn {ColumnName = "MadeIn", ColumnVisible = false});
                ColumnsCollection.Add(new XtraColumn {ColumnName = "FixedAssetCategoryId", ColumnVisible = false});
                ColumnsCollection.Add(new XtraColumn {ColumnName = "PurchasedDate", ColumnVisible = false});
                ColumnsCollection.Add(new XtraColumn {ColumnName = "DepreciationDate", ColumnVisible = false});
                ColumnsCollection.Add(new XtraColumn {ColumnName = "IncrementDate", ColumnVisible = false});
                ColumnsCollection.Add(new XtraColumn {ColumnName = "DisposedDate", ColumnVisible = false});
                ColumnsCollection.Add(new XtraColumn {ColumnName = "Unit", ColumnVisible = false});
                ColumnsCollection.Add(new XtraColumn {ColumnName = "SerialNumber", ColumnVisible = false});
                ColumnsCollection.Add(new XtraColumn {ColumnName = "Accessories", ColumnVisible = false});
                ColumnsCollection.Add(new XtraColumn {ColumnName = "UnitPrice", ColumnVisible = false});
                ColumnsCollection.Add(new XtraColumn {ColumnName = "AccumDepreciationAmount", ColumnVisible = false});
                ColumnsCollection.Add(new XtraColumn {ColumnName = "RemainingAmount", ColumnVisible = false});
                ColumnsCollection.Add(new XtraColumn {ColumnName = "ExchangeRate", ColumnVisible = false});
                ColumnsCollection.Add(new XtraColumn {ColumnName = "UnitPriceUSD", ColumnVisible = false});
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "OrgPriceUSD",
                    ColumnCaption = "Nguyên giá",
                    ColumnVisible = false
                });
                ColumnsCollection.Add(new XtraColumn {ColumnName = "AccumDepreciationAmountUSD", ColumnVisible = false});
                ColumnsCollection.Add(new XtraColumn {ColumnName = "RemainingAmountUSD", ColumnVisible = false});
                ColumnsCollection.Add(new XtraColumn {ColumnName = "AnnualDepreciationAmount", ColumnVisible = false});
                ColumnsCollection.Add(new XtraColumn {ColumnName = "AnnualDepreciationAmountUSD", ColumnVisible = false});
                ColumnsCollection.Add(new XtraColumn {ColumnName = "LifeTime", ColumnVisible = false});
                ColumnsCollection.Add(new XtraColumn {ColumnName = "DepreciationRate", ColumnVisible = false});
                ColumnsCollection.Add(new XtraColumn {ColumnName = "OrgPriceAccountCode", ColumnVisible = false});
                ColumnsCollection.Add(new XtraColumn {ColumnName = "DepreciationAccountCode", ColumnVisible = false});
                ColumnsCollection.Add(new XtraColumn {ColumnName = "CapitalAccountCode", ColumnVisible = false});
                ColumnsCollection.Add(new XtraColumn {ColumnName = "DepartmentId", ColumnVisible = false});
                ColumnsCollection.Add(new XtraColumn {ColumnName = "EmployeeId", ColumnVisible = false});
                ColumnsCollection.Add(new XtraColumn {ColumnName = "IsActive", ColumnVisible = false});
                ColumnsCollection.Add(new XtraColumn {ColumnName = "RemainingOrgPrice", ColumnVisible = false});
                ColumnsCollection.Add(new XtraColumn {ColumnName = "RemainingOrgPriceUSD", ColumnVisible = false});
                ColumnsCollection.Add(new XtraColumn {ColumnName = "NumberOfFloor", ColumnVisible = false});
                ColumnsCollection.Add(new XtraColumn {ColumnName = "AreaOfBuilding", ColumnVisible = false});
                ColumnsCollection.Add(new XtraColumn {ColumnName = "AreaOfFloor", ColumnVisible = false});
                ColumnsCollection.Add(new XtraColumn {ColumnName = "WorkingArea", ColumnVisible = false});
                ColumnsCollection.Add(new XtraColumn {ColumnName = "AdministrationArea", ColumnVisible = false});
                ColumnsCollection.Add(new XtraColumn {ColumnName = "HousingArea", ColumnVisible = false});
                ColumnsCollection.Add(new XtraColumn {ColumnName = "VacancyArea", ColumnVisible = false});
                ColumnsCollection.Add(new XtraColumn {ColumnName = "OccupiedArea", ColumnVisible = false});
                ColumnsCollection.Add(new XtraColumn {ColumnName = "LeasingArea", ColumnVisible = false});
                ColumnsCollection.Add(new XtraColumn {ColumnName = "GuestHouseArea", ColumnVisible = false});
                ColumnsCollection.Add(new XtraColumn {ColumnName = "OtherArea", ColumnVisible = false});
                ColumnsCollection.Add(new XtraColumn {ColumnName = "NumberOfSeat", ColumnVisible = false});
                ColumnsCollection.Add(new XtraColumn {ColumnName = "ControlPlate", ColumnVisible = false});
                ColumnsCollection.Add(new XtraColumn {ColumnName = "IsStateManagement", ColumnVisible = false});
                ColumnsCollection.Add(new XtraColumn {ColumnName = "IsBussiness", ColumnVisible = false});
                ColumnsCollection.Add(new XtraColumn {ColumnName = "Address", ColumnVisible = false});
                ColumnsCollection.Add(new XtraColumn {ColumnName = "BudgetSourceCode", ColumnVisible = false});
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ManagementCar", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn {ColumnName = "Brand", ColumnVisible = false});
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsEstimateEmployee", ColumnVisible = false });
            }
        }

        #endregion

        /// <summary>
        /// Sets the fixed asset increment.
        /// </summary>
        /// <value>
        /// The fixed asset increment.
        /// </value>
        public IList<FixedAssetLedgerModel> FixedAssetLedgers
        {
            set
            {
                ColumnsCollection.Add(new XtraColumn {ColumnName = "RefId", ColumnVisible = false});
            }
        }

        /// <summary>
        ///     Loads the data into grid.
        /// </summary>
        protected override void LoadDataIntoGrid()
        {
            _fixedAssetsPresenter.Display();
            _fixedAssetsPresenter.SaveCompanyProfile();
            
        }

        /// <summary>
        ///     Deletes the grid.
        /// </summary>
        protected override void DeleteGrid()
        {
            IList<FixedAssetLedgerModel> fixedAssetLedgersPresenter =
                _fixedAssetLedgersPresenter.Display(int.Parse(PrimaryKeyValue));
            if (fixedAssetLedgersPresenter.Count != 0)
            {
                XtraMessageBox.Show(string.Format(ResourceHelper.GetResourceValueByName("ResDeleteFixedAsset")),
                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                new FixedAssetPresenter(null).DeleteOpeningFixedAssetEntry(int.Parse(PrimaryKeyValue));
                new FixedAssetPresenter(null).Delete(int.Parse(PrimaryKeyValue));
            }
        }

        /// <summary>
        ///     Gets the form detail.
        /// </summary>
        /// <returns></returns>
        protected override FrmXtraBaseCategoryDetail GetFormDetail()
        {
            return new FrmXtraFixedAssetDetail();
        }

        private void gridView_RowStyle(object sender, RowStyleEventArgs e)
        {
            var view = sender as GridView;
            if (e.RowHandle < 0) return;
            if (view == null) return;
            var state = (int)view.GetRowCellValue(e.RowHandle, view.Columns["State"]);
            var isActive = (bool)view.GetRowCellValue(e.RowHandle, view.Columns["IsActive"]);
            if (state == 3 || state == 4 || state == 5)
            {
                e.Appearance.ForeColor = Color.Navy;
            }
            if (isActive)
                e.Appearance.ForeColor = Color.Red;
        }

        /// <summary>
        ///     Handles the RowStyle event of the gridView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs" /> instance containing the event data.</param>
        
    }
}
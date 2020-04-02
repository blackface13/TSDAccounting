using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Presenter.Dictionary.Department;
using TSD.AccountingSoft.Presenter.Dictionary.FixedAsset;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.Report.BaseParameterForm;
using TSD.AccountingSoft.Report.CommonClass;
using TSD.AccountingSoft.Report.ReportClass;
using TSD.AccountingSoft.Session;
using DateTimeRangeBlockDev.Helper;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTreeList.Nodes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TSD.AccountingSoft.Report.ParameterReportForm
{
    public partial class FrmFixedAssetS24H : FrmXtraBaseParameter, IDepartmentsView, IFixedAssetCategoriesView, IFixedAssetsView
    {
        #region Properties

        public List<XtraColumn> ColumnsCollection = new List<XtraColumn>();

        public string FromDate
        {
            get
            {
                return dateTimeRangeV1.FromDate.ToShortDateString();
            }
            set
            {
                dateTimeRangeV1.FromDate = Convert.ToDateTime(value);
            }
        }
        public string ToDate
        {
            get
            {
                return dateTimeRangeV1.ToDate.ToShortDateString();
            }
            set
            {
                dateTimeRangeV1.ToDate = Convert.ToDateTime(value);
            }
        }
        public string PeriodName
        {
            get
            {
                if (dateTimeRangeV1.cboDateRange.Text.Equals("Tự chọn") || dateTimeRangeV1.cboDateRange.Text.Equals("Năm nay"))
                    return "";
                return dateTimeRangeV1.cboDateRange.Text;
            }
        }
        public DepartmentModel Department
        {
            get
            {
                return (cboDepartment.GetSelectedDataRow() as DepartmentModel) ?? new DepartmentModel();
            }
        }
        public List<FixedAssetCategoryModel> SelectedFixedAssetCategorys
        {
            get
            {
                if(string.IsNullOrEmpty(SelectedFixedAssetCategory))
                    return new List<FixedAssetCategoryModel>();

                var lstSelecteds = SelectedFixedAssetCategory.Split(',');
                var lstSelectedIds = new List<int>();
                foreach (var selectedValue in lstSelecteds)
                {
                    if (!selectedValue.Trim().Equals(""))
                    {
                        lstSelectedIds.Add(Convert.ToInt32(selectedValue));
                    }
                }
                return FixedAssetCategories.Where(w => lstSelectedIds.Contains(w.FixedAssetCategoryId))?.ToList() 
                    ?? new List<FixedAssetCategoryModel>();
            }
        }

        public bool IsSelectedAll { get; set; }
        public string SelectedFixedAssetCategory { get; set; }
        public string FixedAssetCategoryTitle { get; set; }

        public string FixedAssetIds
        {
            get
            {
                var lstViewFixedAssetIds = new List<string>();
                if (bindingSource.DataSource != null && gridViewFixedAsset.RowCount > 0)
                {
                    for (var i = 0; i < gridViewFixedAsset.RowCount; i++)
                    {
                        if (Selection.IsRowSelected(i))
                        {
                            var fixedAsset = (FixedAssetModel)gridViewFixedAsset.GetRow(i);
                            lstViewFixedAssetIds.Add(fixedAsset.FixedAssetId.ToString());
                        }
                    }
                }
                return string.Join(",", lstViewFixedAssetIds.ToArray());
            }
        }

        #endregion

        #region Variables

        private BindingSource bindingSource;
        private DepartmentsPresenter _departmentsPresenter;
        private FixedAssetCategoriesPresenter _fixedAssetCategoriesPresenter;
        private FixedAssetsPresenter _fixedAssetsPresenter;

        // combox fixed asset
        public bool StateCheck { get; set; } //Khi người dùng thao tác chọn trên Lưới IsActive = false, IsNotAcctive =false
        public int RowForcus { get; set; } // Dòng đang trỏ đến
        internal GridCheckMarksSelection Selection { get; private set; }

        // fixed asset category
        private readonly RepositoryItemLookUpEdit _lookUpFixedAssetCategoryEdit;

        #endregion

        #region Combobox

        public IList<DepartmentModel> Departments 
        { 
            set
            {
                if (value == null)
                    value = new List<DepartmentModel>();

                var columnsCollection = new List<XtraColumn>()
                {
                    new XtraColumn(){ColumnName = "DepartmentCode", ColumnCaption = "Mã phòng ban", ColumnVisible = true, ColumnWith = 25, ColumnPosition =1},
                    new XtraColumn(){ColumnName = "DepartmentName", ColumnCaption = "Tên phòng ban", ColumnVisible = true, ColumnWith = 75, ColumnPosition = 2}
                };
                GridLookUpItem.HideVisibleColumn(value, columnsCollection, cboDepartment, cboDepartmentView, "DepartmentCode", "DepartmentId");
            }
        }
        public IList<FixedAssetCategoryModel> FixedAssetCategories 
        {
            get { return treeListFixedAssetCategory.DataSource as List<FixedAssetCategoryModel>; }
            set
            {
                try
                {
                    if (DesignMode) return;
                    treeListFixedAssetCategory.DataSource = value ?? new List<FixedAssetCategoryModel>();


                    treeListFixedAssetCategory.BeginUpdate();
                    treeListFixedAssetCategory.PopulateColumns();

                    for (var i = 0; i < treeListFixedAssetCategory.Columns.Count; i++)
                    {
                        if (treeListFixedAssetCategory.Columns[i].FieldName != "FixedAssetCategoryName")
                        {
                            treeListFixedAssetCategory.Columns[i].Visible = false;
                        }
                    }
                    treeListFixedAssetCategory.Columns["FixedAssetCategoryName"].OptionsColumn.AllowEdit = false;
                    treeListFixedAssetCategory.Columns["FixedAssetCategoryName"].Caption = @"Tên loại TSCĐ";
                    treeListFixedAssetCategory.OptionsView.ShowHorzLines = false;
                    treeListFixedAssetCategory.OptionsView.ShowVertLines = false;
                    treeListFixedAssetCategory.ExpandAll();
                    treeListFixedAssetCategory.EndUpdate();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public IList<FixedAssetModel> FixedAssets 
        { 
            set
            {
                if (value == null)
                    value = new List<FixedAssetModel>();

                bindingSource.DataSource = value;
                gridViewFixedAsset.PopulateColumns(value);
                var columnsCollection = new List<XtraColumn>()
                {
                    new XtraColumn(){ColumnName = "FixedAssetCode", ColumnCaption = "Mã TSCĐ", ColumnVisible = true, ColumnWith = 25, ColumnPosition = 1},
                    new XtraColumn(){ColumnName = "FixedAssetName", ColumnCaption = "Tên TSCĐ", ColumnVisible = true, ColumnWith = 70, ColumnPosition = 2}
                };
                foreach (GridColumn gridColumn in gridViewFixedAsset.Columns)
                {
                    gridColumn.Visible = false;
                }
                foreach (var xtraColumn in columnsCollection)
                {
                    if (gridViewFixedAsset.Columns[xtraColumn.ColumnName] != null)
                    {
                        gridViewFixedAsset.Columns[xtraColumn.ColumnName].Visible = true;
                        gridViewFixedAsset.Columns[xtraColumn.ColumnName].Caption = xtraColumn.ColumnCaption;
                        gridViewFixedAsset.Columns[xtraColumn.ColumnName].VisibleIndex = xtraColumn.ColumnPosition;
                        gridViewFixedAsset.Columns[xtraColumn.ColumnName].Width = xtraColumn.ColumnWith;
                        gridViewFixedAsset.Columns[xtraColumn.ColumnName].OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
                    }
                }
            }
        }

        #endregion

        #region Events 

        public FrmFixedAssetS24H()
        {
            InitializeComponent();
            popupContainerEdit.Closed += popupContainerEdit_Closed;
            _lookUpFixedAssetCategoryEdit = new RepositoryItemLookUpEdit();

            dateTimeRangeV1.DateRangePeriodMode = DateRangeMode.Reduce;
            dateTimeRangeV1.InitSelectedIndex = GlobalVariable.DateRangeSelectedIndex;

            bindingSource = new BindingSource();
            _departmentsPresenter = new DepartmentsPresenter(this);
            _fixedAssetCategoriesPresenter = new FixedAssetCategoriesPresenter(this);
            _fixedAssetsPresenter = new FixedAssetsPresenter(this);

            gridFixedAsset.DataSource = bindingSource;
            gridViewFixedAsset.Click += gridViewFixedAsset_Click;
            //gridViewFixedAsset.RowClick += gridViewFixedAsset_RowClick;

           
        }

        private void FrmFixedAssetS24H_Load(object sender, EventArgs e)
        {
            _departmentsPresenter.Display();
            _fixedAssetCategoriesPresenter.DisplayComboCheck();
            _fixedAssetsPresenter.Display();

            Selection = new GridCheckMarksSelection(gridViewFixedAsset);
            Selection.CheckMarkColumn.VisibleIndex = 0;
            Selection.CheckMarkColumn.Width = 5;
            StateCheck = true;
            gridViewFixedAsset.OptionsSelection.EnableAppearanceFocusedRow = true;
            gridViewFixedAsset.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridViewFixedAsset.OptionsView.ShowAutoFilterRow = true;
        }

        private void gridViewFixedAsset_Click(object sender, EventArgs e)
        {
            if (gridViewFixedAsset.FocusedRowHandle > -1)
            {
                RowForcus = gridViewFixedAsset.FocusedRowHandle;
                StateCheck = false;
                bool flag = Selection.IsRowSelected(gridViewFixedAsset.FocusedRowHandle);
                //Selection.SelectRow(gridViewFixedAsset.FocusedRowHandle, !flag);
            }
            StateCheck = true;
        }

        private void gridViewFixedAsset_RowClick(object sender, RowClickEventArgs e)
        {
            if (gridViewFixedAsset.FocusedRowHandle > -1)
            {
                RowForcus = gridViewFixedAsset.FocusedRowHandle;
                StateCheck = false;
                bool flag = Selection.IsRowSelected(gridViewFixedAsset.FocusedRowHandle);
                Selection.SelectRow(gridViewFixedAsset.FocusedRowHandle, !flag);
            }
            StateCheck = true;
        }


        private void popupContainerEdit_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            SelectedFixedAssetCategory = "";
            SelectedFixedAssetCategory = IterateNode(treeListFixedAssetCategory.Nodes, "FixedAssetCategoryId");
            popupContainerEdit.EditValue = SelectedFixedAssetCategory;


            _lookUpFixedAssetCategoryEdit.DataSource = FixedAssetCategories;
            _lookUpFixedAssetCategoryEdit.DisplayMember = "FixedAssetCategoryName";
            _lookUpFixedAssetCategoryEdit.ValueMember = "FixedAssetCategoryCode";
        }

        #endregion

        #region Functions

        public string IterateNode(IEnumerable nodes, string columnId)
        {

            foreach (TreeListNode node in nodes)
            {

                if (node.Nodes.Count != 0)
                {
                    IterateNode(node.Nodes, columnId);
                }
                else
                {
                    if (node.Checked)
                    {
                        SelectedFixedAssetCategory = string.IsNullOrEmpty(SelectedFixedAssetCategory)
                            ? SelectedFixedAssetCategory + node.GetValue(columnId)
                            : SelectedFixedAssetCategory + "," + node.GetValue(columnId);
                    }
                }
            }

            return SelectedFixedAssetCategory;
        }

        #endregion

    }
}



using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Presenter.Dictionary.Department;
using TSD.AccountingSoft.Presenter.Dictionary.FixedAsset;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.Report.BaseParameterForm;
using TSD.AccountingSoft.Report.CommonClass;
using TSD.AccountingSoft.Session;
using DateTimeRangeBlockDev.Helper;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
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
    public partial class FrmXtraFixedAssetS26H : FrmXtraBaseParameter, IDepartmentsView, IFixedAssetCategoriesView
    {
        private readonly DepartmentsPresenter _departmentPresenter;
        private readonly FixedAssetCategoriesPresenter _fixedAssetCategoriesPresenter;

        public FrmXtraFixedAssetS26H()
        {
            InitializeComponent();

            this.Load += FrmXtraFixedAssetS26H_Load;
            this.cbbFixedAssetType.SelectedIndexChanged += cbbFixedAssetType_SelectedIndexChanged;

            _departmentPresenter = new DepartmentsPresenter(this);
            _fixedAssetCategoriesPresenter = new FixedAssetCategoriesPresenter(this);

            FixedAssetType = 0;
            dateTimeRangeV1.InitSelectedIndex = 7;
        }

        private void FrmXtraFixedAssetS26H_Load(object sender, EventArgs e)
        {
            _departmentPresenter.DisplayActive();
            _fixedAssetCategoriesPresenter.DisplayComboCheck();
        }

        public string DepartmentCode
        {
            get
            {
                var department = (DepartmentModel)gridLookUpDepartment.GetSelectedDataRow();
                return department == null ? null : department.DepartmentCode;
            }
            set
            {
                gridLookUpDepartment.EditValue = value;
            }
        }

        public string DepartmentName
        {
            get
            {
                var department = (DepartmentModel)gridLookUpDepartment.GetSelectedDataRow();
                return department == null ? null : department.DepartmentName;
            }
            set
            {
                gridLookUpDepartment.EditValue = value;
            }
        }

        public int FixedAssetType
        {
            get { return cbbFixedAssetType.SelectedIndex; }
            set { cbbFixedAssetType.SelectedIndex = value; }
        }

        public string FixedAssetTypeName
        {
            get { return cbbFixedAssetType.Text; }
        }

        public int FixedAssetCategoryId
        {
            get
            {
                var fixedAssetCategory = (FixedAssetCategoryModel)gridLookUpFixedAssetCategory.GetSelectedDataRow();
                return fixedAssetCategory == null ? 0 : fixedAssetCategory.FixedAssetCategoryId;
            }
            set
            {
                gridLookUpFixedAssetCategory.EditValue = value;
            }
        }

        public string FromDate
        {
            get
            {
                return dateTimeRangeV1.FromDate.ToShortDateString();
            }
        }

        public string ToDate
        {
            get
            {
                return dateTimeRangeV1.ToDate.ToShortDateString();
            }
        }

        public IList<DepartmentModel> Departments
        {
            set
            {
                var listColumn = new List<XtraColumn>()
                {
                    new XtraColumn { ColumnName = "DepartmentCode", ColumnCaption = "Mã phòng ban", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 25},
                    new XtraColumn { ColumnName = "DepartmentName", ColumnCaption = "Tên phòng ban", ColumnPosition = 2, ColumnVisible = true , ColumnWith = 75},
                };
                HideVisibleColumn(value, listColumn, gridLookUpDepartment, gridLookUpDepartmentView, "DepartmentName", "DepartmentCode");
            }
        }

        public IList<FixedAssetCategoryModel> FixedAssetCategories
        {
            set
            {
                var listColumn = new List<XtraColumn>()
                {
                    new XtraColumn { ColumnName = "FixedAssetCategoryCode", ColumnCaption = "Mã nhóm TSCĐ", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 25},
                    new XtraColumn { ColumnName = "FixedAssetCategoryName", ColumnCaption = "Tên nhóm TSCĐ", ColumnPosition = 2, ColumnVisible = true , ColumnWith = 75},
                };
                HideVisibleColumn(value, listColumn, gridLookUpFixedAssetCategory, gridLookUpFixedAssetCategoryView, "FixedAssetCategoryName", "FixedAssetCategoryCode");
            }
        }

        public static void HideVisibleColumn(object value, List<XtraColumn> listColumn, GridLookUpEdit gridLookUpEdit, GridView gridView, string displayMember, string valueMember)
        {
            gridLookUpEdit.Properties.View = gridView;
            gridLookUpEdit.Properties.View.Columns.Clear();
            gridLookUpEdit.Properties.DataSource = value;
            gridLookUpEdit.Properties.View.RefreshData();
            gridLookUpEdit.Properties.PopulateViewColumns();
            gridLookUpEdit.Properties.View.ActiveFilterString = string.Empty;
            gridLookUpEdit.Properties.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
            gridLookUpEdit.Properties.AllowNullInput = DefaultBoolean.True;
            gridLookUpEdit.Properties.DisplayMember = displayMember;
            gridLookUpEdit.Properties.ValueMember = valueMember;
            gridLookUpEdit.Properties.ShowFooter = false;
            gridLookUpEdit.Properties.ImmediatePopup = true;

            gridLookUpEdit.Properties.View.OptionsView.ShowGroupPanel = false;
            gridLookUpEdit.Properties.View.OptionsView.ShowIndicator = false;
            gridLookUpEdit.Properties.View.OptionsBehavior.EditorShowMode = EditorShowMode.Default;

            gridLookUpEdit.Properties.View.OptionsView.ShowAutoFilterRow = true;
            if (gridLookUpEdit.Properties.PopupFormSize.Width < gridLookUpEdit.Width)
            {
                gridLookUpEdit.Properties.PopupFormSize = new Size(gridLookUpEdit.Width, gridLookUpEdit.Properties.PopupFormSize.Height);
            }

            gridLookUpEdit.Properties.TextEditStyle = TextEditStyles.Standard;
            gridLookUpEdit.Properties.ImmediatePopup = true;
            gridLookUpEdit.Properties.PopupFormSize = new Size(520, 175);

            if (listColumn != null)
            {
                foreach (GridColumn gridColumn in gridLookUpEdit.Properties.View.Columns)
                {
                    XtraColumn xtraColumn = listColumn.Where(w => w.ColumnName == gridColumn.FieldName && w.ColumnVisible == true)?.FirstOrDefault() ?? null;
                    if (xtraColumn != null)
                    {
                        gridColumn.Visible = true;
                        gridColumn.Caption = xtraColumn.ColumnCaption;
                        gridColumn.SortIndex = xtraColumn.ColumnPosition;
                        gridColumn.Width = xtraColumn.ColumnWith;
                        gridColumn.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
                    }
                    else
                        gridColumn.Visible = false;
                }
            }
        }

        private void cbbFixedAssetType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FixedAssetType == 0)
                gridLookUpFixedAssetCategory.Enabled = true;
            else
                gridLookUpFixedAssetCategory.Enabled = false;
        }
    }
}

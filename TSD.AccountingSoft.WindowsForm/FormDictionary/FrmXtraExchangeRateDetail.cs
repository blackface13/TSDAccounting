/***********************************************************************
 * <copyright file="FrmXtraExchangeRateDetail.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Tuesday, August 18, 2015
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
using TSD.AccountingSoft.Presenter.Dictionary.BudgetSource;
using TSD.AccountingSoft.Presenter.Dictionary.ExchangeRate;
using TSD.AccountingSoft.Session;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.WindowsForm.CommonClass;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.Resources;
using TSD.Enum;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;


namespace TSD.AccountingSoft.WindowsForm.FormDictionary
{
    /// <summary>
    /// class FrmXtraExchangeRateDetail
    /// </summary>
    public partial class FrmXtraExchangeRateDetail : FrmXtraBaseCategoryDetail, IExchangeRateView, IBudgetSourcesView
    {
        internal GridCheckMarksSelection BudgetSourceSelection { get; private set; }

        private readonly ExchangeRatePresenter _exchangeRatePresenter;
        private readonly BudgetSourcesPresenter _budgetSourcesPresenter;
        private int _rowHander;

        //Bien nay dung luu gia tri cua BudgetSourceCode khi edit, nham detect xem nguoi dung co chon nguon khac không
        //neu co thi kiem tra trung voi chi tieu khac
        private string _budgetSourceInEditMode = "";

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmXtraExchangeRateDetail"/> class.
        /// </summary>
        public FrmXtraExchangeRateDetail()
        {
            InitializeComponent();
            _budgetSourcesPresenter = new BudgetSourcesPresenter(this);
            _exchangeRatePresenter = new ExchangeRatePresenter(this);

        }

        #region ExchangeRate members
        public int ExchangeRateId { get; set; }

        public string Description
        {
            get
            {
                return memoDescription.Text;
            }
            set
            {
                memoDescription.Text = value;
            }
        }

        public DateTime FromDate
        {
            get
            {
                return DateTime.Parse(dtFromDate.DateTime.ToShortDateString());
            }
            set
            {
                dtFromDate.DateTime = value;
            }
        }

        public DateTime ToDate
        {
            get
            {
                return DateTime.Parse(dtToDate.DateTime.ToShortDateString());
            }
            set
            {
                dtToDate.DateTime = value;
            }
        }

        /// <summary>
        /// Gets or sets the budget source code.
        /// </summary>
        ///public string BudgetSourceCode
        ///{
        ///    get
        ///    {
        ///        return grdLookUpBudgetSourceID.EditValue == null ? null : grdLookUpBudgetSourceID.GetColumnValue("BudgetSourceCode").ToString();
        ///    }
        ///    set
        ///    {
        ///        grdLookUpBudgetSourceID.EditValue = value;
        ///    }
        ///}
        /// <value>
        /// The budget source code.
        /// </value>
        public string BudgetSourceCode
        {
            get
            {
                if (BudgetSourceSelection.SelectedCount > 0)
                {
                    memoDescription.Enabled = BudgetSourceSelection.SelectedCount <= 1;
                    var selectedList = "";
                    for (int i = 0; i < gridViewBudgetSource.RowCount; i++)
                    {
                        if (BudgetSourceSelection.IsRowSelected(i))
                        {
                            selectedList = (string.IsNullOrEmpty(_budgetSourceInEditMode)
                                ? _budgetSourceInEditMode + ""
                                : _budgetSourceInEditMode + ",") +
                                           (string.IsNullOrEmpty(selectedList) ? selectedList + "" : selectedList + ",") +
                                           gridViewBudgetSource.GetRowCellValue(i, "BudgetSourceCode");
                        }
                    }
                    return selectedList;
                }
                return null;
            }
            set
            {
                _budgetSourceInEditMode = value;
                _rowHander = gridViewBudgetSource.LocateByValue("BudgetSourceCode", value);
            }
        }

        /// <summary>
        /// Gets or sets the exchange rate.
        /// </summary>
        /// <value>
        /// The exchange rate.
        /// </value>
        public decimal ExchangeRate
        {
            get
            {
                return (decimal)txtExchangeRate.EditValue;
            }
            set
            {
                txtExchangeRate.EditValue = value;
            }
        }

        public bool Inactive
        {
            get
            {
                return chkIsActive.Checked;
            }
            set
            {
                chkIsActive.EditValue = value;
            }
        }
        #endregion

        /// <summary>
        /// Initializes the data.
        /// </summary>
        protected override void InitData()
        {
            _budgetSourcesPresenter.DisplayActive();
            if (KeyValue != null) { _exchangeRatePresenter.Display(int.Parse(KeyValue)); }
        }

        /// <summary>
        /// Focuses the control.
        /// </summary>
        protected override void InitControls()
        {
            dtFromDate.DateTime = new DateTime(DateTime.Parse(GlobalVariable.StartedDate).Year, 1, 1);
            dtToDate.DateTime = new DateTime(DateTime.Parse(GlobalVariable.StartedDate).Year, 12, 31);
        }

        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns></returns>
        protected override bool ValidData()
        {
            if ((ActionMode == ActionModeEnum.Edit || BudgetSourceSelection.SelectedCount == 1) && string.IsNullOrEmpty(Description))
            {
                XtraMessageBox.Show(@"Diễn giải không được để trống",
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                memoDescription.Focus();
                return false;
            }

            if (BudgetSourceSelection.SelectedCount <= 0)//(string.IsNullOrEmpty(BudgetSourceCode))
            {
                XtraMessageBox.Show(@"Nguồn vốn không được để trống",
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                gridViewBudgetSource.Focus();
                return false;
            }

            if (ActionMode == ActionModeEnum.Edit && BudgetSourceSelection.SelectedCount > 1)
            {
                XtraMessageBox.Show(@"Thao tác sửa chứng từ chỉ cho phép chọn 1 nguồn vốn",
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                gridViewBudgetSource.Focus();
                return false;
            }

            if (decimal.Parse(txtExchangeRate.EditValue.ToString()) == 0)
            {
                XtraMessageBox.Show(@"Tỷ giá phải khác 0",
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtExchangeRate.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// Saves the data.
        /// </summary>
        /// <returns></returns>
        protected override int SaveData()
        {
            return _exchangeRatePresenter.Save();
        }

        /// <summary>
        /// Sets the budget sources.
        /// </summary>
        /// <value>
        /// The budget sources.
        /// </value>
        public IList<Model.BusinessObjects.Dictionary.BudgetSourceModel> BudgetSources
        {
            set
            {
                if (value == null) return;
                var list = value.Where(c => c.BudgetSourceCode == "13" || c.BudgetSourceCode == "12.1" || c.BudgetSourceCode == "12.2" || c.BudgetSourceCode == "15").ToList();
                grdlookUpBudgetSource.DataSource = list;

                var gridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn { ColumnName = "BudgetSourceId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "BudgetSourceCode", ColumnCaption = "Mã nguồn vốn", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 200, AllowEdit = false},
                        new XtraColumn { ColumnName = "BudgetSourceName", ColumnCaption = "Tên nguồn vốn", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 400 , AllowEdit = false},
                        new XtraColumn { ColumnName = "Description", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsActive", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false},
                        new XtraColumn { ColumnName = "ForeignName", ColumnVisible = false},
                        new XtraColumn { ColumnName = "IsParent", ColumnVisible = false},
                        new XtraColumn { ColumnName = "Grade", ColumnVisible = false},
                        new XtraColumn { ColumnName = "Type", ColumnVisible = false},
                        new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false},
                        new XtraColumn { ColumnName = "Allocation", ColumnVisible = false},
                        new XtraColumn { ColumnName = "BudgetItemCode", ColumnVisible = false},
                        new XtraColumn { ColumnName = "IsFund", ColumnVisible = false},
                        new XtraColumn { ColumnName = "IsExpense", ColumnVisible = false},
                        new XtraColumn { ColumnName = "AccountCode", ColumnVisible = false},
                        new XtraColumn { ColumnName = "ParentId", ColumnVisible = false},
                        new XtraColumn { ColumnName = "BudgetCode", ColumnVisible = false},
                        new XtraColumn {ColumnName = "AutonomyBudgetType", ColumnVisible = false}
                    };

                foreach (var column in gridColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        gridViewBudgetSource.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        gridViewBudgetSource.Columns[column.ColumnName].SortIndex = column.ColumnPosition;
                        gridViewBudgetSource.Columns[column.ColumnName].Width = column.ColumnWith;
                        gridViewBudgetSource.Columns[column.ColumnName].OptionsColumn.AllowEdit = column.AllowEdit;
                    }
                    else
                    {
                        gridViewBudgetSource.Columns[column.ColumnName].Visible = false;
                    }
                }
            }
        }

        /// <summary>
        /// Handles the Load event of the FrmXtraExchangeRateDetail control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FrmXtraExchangeRateDetail_Load(object sender, EventArgs e)
        {
            BudgetSourceSelection = new GridCheckMarksSelection(gridViewBudgetSource);
            if (ActionMode == ActionModeEnum.Edit && _rowHander >= 0)
            {
                BudgetSourceSelection.SelectRow(_rowHander, true);
            }

            BudgetSourceSelection.CheckMarkColumn.VisibleIndex = 0;
            BudgetSourceSelection.CheckMarkColumn.Width = 30;
        }

        /// <summary>
        /// Handles the CustomDrawColumnHeader event of the gridViewBudgetSource control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventArgs"/> instance containing the event data.</param>
        private void gridViewBudgetSource_CustomDrawColumnHeader(object sender, DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventArgs e)
        {
            var viewInfo = (GridViewInfo)gridViewBudgetSource.GetViewInfo();
            var rec = new Rectangle(e.Bounds.X + 2, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);

            if (e.Column == null) return;
            if (e.Column == viewInfo.FixedLeftColumn || e.Column == viewInfo.ColumnsInfo.LastColumnInfo.Column)
            {
                foreach (DevExpress.Utils.Drawing.DrawElementInfo info in e.Info.InnerElements)
                {
                    if (!info.Visible) continue;
                    DevExpress.Utils.Drawing.ObjectPainter.DrawObject(e.Cache, info.ElementPainter, info.ElementInfo);
                }

                e.Painter.DrawCaption(e.Info, e.Info.Caption, e.Appearance.Font, e.Appearance.GetForeBrush(e.Cache),
                    rec, e.Appearance.GetStringFormat());
                e.Graphics.DrawLine(Pens.DarkGray, e.Bounds.Left - 1, e.Bounds.Bottom - 1, e.Bounds.Right - 1,
                    e.Bounds.Bottom - 1);
                e.Handled = true;
            }
        }
    }
}
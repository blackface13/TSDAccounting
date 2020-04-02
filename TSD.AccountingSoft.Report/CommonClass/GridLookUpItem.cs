/***********************************************************************
 * <copyright file="GridLookUpItem.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Hoàng Bích Sơn
 * Email:    sonhb@buca.vn
 * Website:
 * Create Date: 27 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/


using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;

namespace TSD.AccountingSoft.Report.CommonClass 
{
    /// <summary>
    /// GridLookUpItem class
    /// </summary>
    internal sealed class GridLookUpItem
    {
        /// <summary>
        /// Gets or sets the data value.
        /// </summary>
        /// <value>
        /// The data value.
        /// </value>
        public object DataValue { get; set; }

        /// <summary>
        /// Gets or sets the data member.
        /// </summary>
        /// <value>
        /// The data member.
        /// </value>
        public object DataMember { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GridLookUpItem"/> class.
        /// </summary>
        /// <param name="dataValue">The data value.</param>
        /// <param name="dataMember">The data member.</param>
        public GridLookUpItem(string dataValue, string dataMember)
        {
            DataValue = dataValue;
            DataMember = dataMember;
        }

        public static void HideVisibleColumn(object value, List<XtraColumn> listColumn, GridLookUpEdit gridLookUpEdit, GridView gridView, string displayMember, string valueMember, GridLookUpItemOption option = null)
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

            gridLookUpEdit.Properties.View.OptionsView.ShowAutoFilterRow = option != null ? option.ShowAutoFilterRow : true;
            if (gridLookUpEdit.Properties.PopupFormSize.Width < gridLookUpEdit.Width)
            {
                gridLookUpEdit.Properties.PopupFormSize = new Size(gridLookUpEdit.Width, gridLookUpEdit.Properties.PopupFormSize.Height);
            }
            if (option != null && option.IsAutoPopupSize)
            {
                int height = 20;
                IList source = (IList)gridLookUpEdit.Properties.DataSource;
                GridViewInfo gridViewInfo = gridView.GetViewInfo() as GridViewInfo;
                if (gridViewInfo != null)
                    height = source.Count * gridViewInfo.ColumnRowHeight;
                gridLookUpEdit.Properties.PopupFormSize = new Size(515, height);
                gridLookUpEdit.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
                gridLookUpEdit.Properties.PopupFormMinSize = new Size(gridLookUpEdit.Size.Width, height);
            }
            else
            {
                gridLookUpEdit.Properties.TextEditStyle = TextEditStyles.Standard;
                gridLookUpEdit.Properties.ImmediatePopup = true;
                gridLookUpEdit.Properties.PopupFormSize = option != null && option.CustomSize != default(Size) ? option.CustomSize : new Size(520, 175);
            }

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

        public static void HideVisibleColumn(object value, List<XtraColumn> listColumn, RepositoryItemGridLookUpEdit resLookUpEdit, string displayMember, string valueMember, GridLookUpItemOption option = null)
        {
            resLookUpEdit.View.Columns.Clear();
            resLookUpEdit.DataSource = value;
            resLookUpEdit.View.RefreshData();
            GridView gridView = resLookUpEdit.View as GridView;
            resLookUpEdit.View.PopulateColumns(value);
            resLookUpEdit.AllowNullInput = DefaultBoolean.True;
            resLookUpEdit.TextEditStyle = TextEditStyles.Standard;
            resLookUpEdit.View.ActiveFilterString = string.Empty;
            resLookUpEdit.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
            resLookUpEdit.View.OptionsView.ShowGroupPanel = false;
            resLookUpEdit.View.OptionsView.ShowIndicator = false;
            resLookUpEdit.View.OptionsView.ShowAutoFilterRow = option != null ? option.ShowAutoFilterRow : true;
            resLookUpEdit.DisplayMember = displayMember;
            resLookUpEdit.ValueMember = valueMember;
            resLookUpEdit.ShowFooter = false;
            resLookUpEdit.NullText = "";

            if (listColumn != null)
                foreach (GridColumn gridColumn in resLookUpEdit.View.Columns)
                {
                    XtraColumn xtraColumn = listColumn.Where(w => w.ColumnName == gridColumn.FieldName && w.ColumnVisible == true)?.FirstOrDefault() ?? null;
                    if (xtraColumn != null)
                    {
                        gridColumn.Caption = xtraColumn.ColumnCaption;
                        gridColumn.Width = xtraColumn.ColumnWith;
                        gridColumn.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
                        gridColumn.UnboundType = xtraColumn.ColumnType;
                        switch (xtraColumn.ColumnType)
                        {
                            case DevExpress.Data.UnboundColumnType.Integer:
                                {
                                    var _rpsCalcNumber = new RepositoryItemCalcEdit { AllowMouseWheel = false };
                                    _rpsCalcNumber.Mask.MaskType = MaskType.Numeric;
                                    _rpsCalcNumber.Mask.EditMask = @"n0";
                                    _rpsCalcNumber.Mask.UseMaskAsDisplayFormat = true;
                                    _rpsCalcNumber.Mask.Culture = Thread.CurrentThread.CurrentCulture;
                                    gridColumn.ColumnEdit = _rpsCalcNumber;
                                }
                                break;
                        }
                    }
                    else
                        gridColumn.Visible = false;
                }

            if (option != null && option.IsAutoPopupSize)
                resLookUpEdit.BestFitMode = BestFitMode.BestFitResizePopup;
            else
                resLookUpEdit.PopupFormSize = option != null && option.CustomSize != default(Size) ? option.CustomSize : new Size(520, 175);
        }
    }

    internal class GridLookUpItemOption
    {
        internal GridLookUpItemOption()
        {
            IsAutoPopupSize = false;
            CustomSize = default(Size);
            ShowAutoFilterRow = true;
        }

        internal bool IsAutoPopupSize { get; set; }
        internal Size CustomSize { get; set; }
        internal bool ShowAutoFilterRow { get; set; }
    }
}

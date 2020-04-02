using TSD.AccountingSoft.Session;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid
{
    public static class XtraColumnCollectionHelper<T>
    {
        static DateTime _minValueSql = new DateTime(1753, 1, 1);
        static RepositoryItemCalcEdit repositoryCurrencyCalcEdit;
        static RepositoryItemCalcEdit repositoryNumberCalcEdit;
        static RepositoryItemDateEdit repositoryDateEdit;

        /// <summary>
        /// Visible and invisible column in grid view
        /// </summary>
        public static void ShowXtraColumnInGridView(List<XtraColumn> listXtraColumn, GridView gridView)
        {
            gridView.BeginUpdate();
            //gridView.OptionsView.ColumnAutoWidth = false;
            Type myType = typeof(T);
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());

            foreach (PropertyInfo prop in props)
            {
                if (gridView.Columns[prop.Name] == null)
                    continue;
                var column = listXtraColumn.FirstOrDefault(obj => obj.ColumnName.Equals(prop.Name));
                if (column != null)
                {

                    gridView.Columns[prop.Name].Visible = column.ColumnVisible;
                    if (column.ColumnVisible)
                    {
                        gridView.Columns[prop.Name].Caption = column.ColumnCaption;
                        gridView.Columns[column.ColumnName].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                        gridView.Columns[column.ColumnName].AppearanceCell.TextOptions.HAlignment = column.Alignment;
                        gridView.Columns[prop.Name].VisibleIndex = column.ColumnPosition;
                        gridView.Columns[prop.Name].Width = column.ColumnWith;
                        gridView.Columns[prop.Name].UnboundType = column.ColumnType;
                        gridView.Columns[column.ColumnName].Fixed = column.FixedColumn;
                        gridView.Columns[column.ColumnName].OptionsColumn.AllowEdit = column.AllowEdit;
                        gridView.Columns[column.ColumnName].ToolTip = column.ToolTip;
                        gridView.Columns[column.ColumnName].OptionsColumn.AllowSort = DefaultBoolean.False;
                        gridView.Columns[column.ColumnName].ColumnEdit = column.RepositoryControl;

                        if (column.IsSummnary)
                        {
                            gridView.OptionsView.ShowFooter = true;
                            gridView.Columns[column.ColumnName].SummaryItem.SummaryType = SummaryItemType.Sum;
                            gridView.Columns[column.ColumnName].SummaryItem.DisplayFormat = GlobalVariable.CurrencyDisplayString;
                            gridView.Columns[column.ColumnName].SummaryItem.Format = Thread.CurrentThread.CurrentCulture;
                        }

                        repositoryCurrencyCalcEdit = new RepositoryItemCalcEdit { AllowMouseWheel = false };
                        repositoryNumberCalcEdit = new RepositoryItemCalcEdit { AllowMouseWheel = false };
                        repositoryDateEdit = new RepositoryItemDateEdit() { AllowMouseWheel = false };

                        switch (column.ColumnType)
                        {
                            case UnboundColumnType.Integer:
                                repositoryNumberCalcEdit.Mask.MaskType = MaskType.Numeric;
                                repositoryNumberCalcEdit.Mask.EditMask = @"n0";
                                repositoryNumberCalcEdit.Mask.UseMaskAsDisplayFormat = true;
                                repositoryNumberCalcEdit.Mask.Culture = Thread.CurrentThread.CurrentCulture;
                                gridView.Columns[column.ColumnName].ColumnEdit = repositoryNumberCalcEdit;
                                break;

                            case UnboundColumnType.Decimal:
                                column.IsNumeric = true;
                                break;
                        }

                        if (column.IsDateTime)
                        {
                            RepositoryItemDateEdit responDateEdit = new RepositoryItemDateEdit();
                            responDateEdit.AllowNullInput = DefaultBoolean.True;
                            responDateEdit.NullDate = _minValueSql;
                            responDateEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
                            responDateEdit.EditMask = @"dd/MM/yyyy";
                            responDateEdit.Mask.UseMaskAsDisplayFormat = true;
                            gridView.Columns[column.ColumnName].ColumnEdit = responDateEdit;
                            gridView.Columns[column.ColumnName].AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                        }
                        GlobalVariable  global = new GlobalVariable();
                        if (column.IsNumeric)
                        {
                            repositoryCurrencyCalcEdit = new RepositoryItemCalcEdit();
                            repositoryCurrencyCalcEdit.Mask.MaskType = MaskType.Numeric;

                            if (column.ColumnName.ToLower().Contains("quantity"))
                            {
                                var _numberDecimalDigits = string.IsNullOrEmpty(global.NumberDecimalDigits) ? "0" : global.NumberDecimalDigits;
                                repositoryCurrencyCalcEdit.Mask.EditMask = @"n" + _numberDecimalDigits;
                                repositoryCurrencyCalcEdit.Precision = int.Parse(_numberDecimalDigits);
                            }
                            else if (column.ColumnName.ToLower().Contains("exchangerate"))
                            {
                                var _exchangeRateDecimalDigits = string.IsNullOrEmpty(global.ExchangeRateDecimalDigits) ? "0" : global.ExchangeRateDecimalDigits;
                                // repositoryCurrencyCalcEdit.Mask.EditMask = @"n" + _exchangeRateDecimalDigits;
                                repositoryCurrencyCalcEdit.Mask.EditMask =
                                    @"c" + Convert.ToString(global.CurrencyDecimalDigits);
                                repositoryCurrencyCalcEdit.Precision =int.Parse(global.CurrencyDecimalDigits);
                            }
                            else if (column.ColumnName.ToLower().Contains("unitprice") || column.ColumnName.ToLower().Contains("unitpriceoc"))
                            {
                                repositoryCurrencyCalcEdit.Mask.EditMask = @"c" + Convert.ToString(GlobalVariable.CurrencyUnitPriceDigits);
                                repositoryCurrencyCalcEdit.Precision = GlobalVariable.CurrencyUnitPriceDigits;
                            }
                            else if (column.ColumnName.ToLower().Contains("amount") || column.ColumnName.ToLower().Contains("amountoc"))
                            {
                                repositoryCurrencyCalcEdit.Mask.EditMask = @"c" + Convert.ToString(global.CurrencyDecimalDigits);
                                repositoryCurrencyCalcEdit.Precision = int.Parse(global.CurrencyDecimalDigits);
                                gridView.OptionsView.ShowFooter = true;
                                gridView.Columns[column.ColumnName].SummaryItem.SummaryType = SummaryItemType.Sum;
                                gridView.Columns[column.ColumnName].SummaryItem.DisplayFormat = GlobalVariable.CurrencyDisplayString;
                                gridView.Columns[column.ColumnName].SummaryItem.Format = Thread.CurrentThread.CurrentCulture;
                            }
                            else
                            {
                                repositoryCurrencyCalcEdit.Mask.EditMask = @"n" + Convert.ToString(global.CurrencyDecimalDigits);
                                repositoryCurrencyCalcEdit.Precision = int.Parse( global.CurrencyDecimalDigits);
                            }

                            repositoryCurrencyCalcEdit.Mask.Culture = Thread.CurrentThread.CurrentCulture;
                            repositoryCurrencyCalcEdit.Mask.UseMaskAsDisplayFormat = true;
                            gridView.Columns[column.ColumnName].ColumnEdit = repositoryCurrencyCalcEdit;
                        }
                    }
                }
                else
                {
                    gridView.Columns[prop.Name].Visible = false;
                }
            }

            if (gridView.OptionsView.ShowFooter)
            {
                gridView.VisibleColumns[0].SummaryItem.SummaryType = SummaryItemType.Count;
                gridView.VisibleColumns[0].SummaryItem.DisplayFormat = @"Số dòng = {0:n0}";
            }

            // TODO: set lại position: tạm thời như vậy đã (hơi nông dân)
            foreach (var column in listXtraColumn.Where(m => m.ColumnVisible))
            {
                if (gridView.Columns.ColumnByFieldName(column.ColumnName) != null)
                {
                    gridView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                }
            }

            gridView.EndUpdate();
        }

        /// <summary>
        /// Visible and invisible column in banded grid view
        /// </summary>
        /// <param name="listXtraColumn"></param>
        /// <param name="bandedGridView"></param>
        public static void ShowXtraColumnInBandedGridView(List<XtraColumn> listXtraColumn, DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bandedGridView)
        {
            Type myType = typeof(T);
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());

            foreach (PropertyInfo prop in props)
            {
                var column = listXtraColumn.FirstOrDefault(obj => obj.ColumnName.Equals(prop.Name));
                if (column != null)
                {
                    if (bandedGridView.Columns[column.ColumnName] != null)
                    {
                        bandedGridView.Columns[column.ColumnName].Visible = column.ColumnVisible;
                        if (column.ColumnVisible)
                        {
                            bandedGridView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            bandedGridView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            bandedGridView.Columns[column.ColumnName].Width = column.ColumnWith;
                            bandedGridView.Columns[column.ColumnName].UnboundType = column.ColumnType;
                            bandedGridView.Columns[column.ColumnName].Fixed = column.FixedColumn;
                            bandedGridView.Columns[column.ColumnName].OptionsColumn.AllowEdit = column.AllowEdit;
                            bandedGridView.Columns[column.ColumnName].ToolTip = column.ToolTip;
                            bandedGridView.Columns[column.ColumnName].OptionsColumn.AllowSort = DefaultBoolean.False;
                            bandedGridView.Columns[column.ColumnName].ColumnEdit = column.RepositoryControl;
                            if (column.IsSummaryText)
                            {
                                bandedGridView.Columns[column.ColumnName].SummaryItem.SummaryType = SummaryItemType.Custom;
                                bandedGridView.Columns[column.ColumnName].SummaryItem.DisplayFormat = Properties.Resources.SummaryText;
                            }
                        }
                    }
                }
                else
                {
                    bandedGridView.Columns[prop.Name].Visible = false;
                }
            }
        }

        /// <summary>
        /// Visible and invisible column in lookup edit
        /// </summary>
        /// <param name="listXtraColumn"></param>
        /// <param name="gridView"></param>
        public static void ShowXtraColumnInLookUpEdit(List<XtraColumn> listXtraColumn, LookUpEdit lookUpEdit)
        {
            Type myType = typeof(T);
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());

            int popUpWith = 0;

            foreach (PropertyInfo prop in props)
            {
                var column = listXtraColumn.FirstOrDefault(obj => obj.ColumnName.Equals(prop.Name));
                if (column != null)
                {
                    lookUpEdit.Properties.Columns[prop.Name].Visible = column.ColumnVisible;
                    if (column.ColumnVisible)
                    {
                        lookUpEdit.Properties.Columns[prop.Name].Caption = column.ColumnCaption;
                        //lookUpEdit.Properties.Columns[prop.Name].VisibleIndex = column.ColumnPosition;
                        lookUpEdit.Properties.Columns[prop.Name].Width = column.ColumnWith;
                        popUpWith += column.ColumnWith;
                    }
                }
                else
                {
                    lookUpEdit.Properties.Columns[prop.Name].Visible = false;
                }
            }

            lookUpEdit.Properties.PopupWidth = popUpWith;
        }

        public static GridView CreateGridViewReponsitory()
        {
            var view = new GridView();
            view.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
            view.OptionsView.ColumnAutoWidth = true;
            view.OptionsView.ShowIndicator = false;
            return view;
        }

        public static RepositoryItemGridLookUpEdit CreateGridLookUpEditReponsitory(GridView view, object dataSource, string displayMember, string valueMember, List<XtraColumn> listColumn = null)
        {
            view.VertScrollVisibility = ScrollVisibility.Always;
            var lookUp = new RepositoryItemGridLookUpEdit();
            lookUp.View = view;

            lookUp.NullText = string.Empty;
            lookUp.TextEditStyle = TextEditStyles.Standard;

            lookUp.PopupFormSize = new Size(368, 150);
            lookUp.ImmediatePopup = true;
            lookUp.AllowNullInput = DefaultBoolean.True;
            lookUp.DataSource = dataSource;
            lookUp.View.ActiveFilterString = string.Empty;
            lookUp.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;

            view.PopulateColumns(dataSource);
            lookUp.View.OptionsView.ShowAutoFilterRow = true;

            if (listColumn != null)
            {
                foreach (var column in listColumn.Where(x => x.ColumnVisible))
                {
                    if (lookUp.View.Columns[column.ColumnName] == null)
                        continue;
                    lookUp.View.Columns[column.ColumnName].Caption = column.ColumnCaption;
                    lookUp.View.Columns[column.ColumnName].Width = column.ColumnWith;
                    lookUp.View.Columns[column.ColumnName].OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
                }
            }
            lookUp.DisplayMember = displayMember;
            lookUp.ValueMember = valueMember;

            lookUp.ProcessNewValue += LookUp_ProcessNewValue;

            return lookUp;
        }

        public static GridLookUpEdit CreateGridLookUpEdit(GridView view, object dataSource, string displayMember, string valueMember, List<XtraColumn> listColumn = null)
        {
            view.VertScrollVisibility = ScrollVisibility.Always;
            var lookUp = new GridLookUpEdit();
            lookUp.Properties.View = view;

            lookUp.Properties.NullText = string.Empty;
            lookUp.Properties.TextEditStyle = TextEditStyles.Standard;
                  
            lookUp.Properties.PopupFormSize = new Size(368, 150);
            lookUp.Properties.ImmediatePopup = true;
            lookUp.Properties.AllowNullInput = DefaultBoolean.True;
            lookUp.Properties.DataSource = dataSource;
            lookUp.Properties.View.ActiveFilterString = string.Empty;
            lookUp.Properties.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;

            view.PopulateColumns(dataSource);
            lookUp.Properties.View.OptionsView.ShowAutoFilterRow = true;

            if (listColumn != null)
            {
                foreach (var column in listColumn.Where(x => x.ColumnVisible))
                {

                    lookUp.Properties.View.Columns[column.ColumnName].Caption = column.ColumnCaption;
                    lookUp.Properties.View.Columns[column.ColumnName].Width = column.ColumnWith;
                    lookUp.Properties.View.Columns[column.ColumnName].OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
                }
            }
            lookUp.Properties.DisplayMember = displayMember;
            lookUp.Properties.ValueMember = valueMember;

            lookUp.ProcessNewValue += LookUp_ProcessNewValue;

            return lookUp;
        }


        private static void LookUp_ProcessNewValue(object sender, ProcessNewValueEventArgs e)
        {
            GridLookUpEdit look = sender as GridLookUpEdit;
            if (look == null)
                return;

            if (string.IsNullOrEmpty(Convert.ToString(e.DisplayValue)))
            {
                look.EditValue = null;
            }
        }
    }
}

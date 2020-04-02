using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace TSD.AccountingSoft.WindowsForm.CommonClass
{
    public class GridCheckMarksSelection
    { 
        protected GridView view;
        protected ArrayList Selection;
        private GridColumn _column;
        private RepositoryItemCheckEdit _edit;

        public GridCheckMarksSelection()
        {
            Selection = new ArrayList();
        }

        public GridCheckMarksSelection(GridView view)
            : this()
        {
            View = view;
        }

        protected virtual void Attach(GridView gridView)
        {
            if (gridView == null) return;
            Selection.Clear();
            view = gridView;
            _edit = gridView.GridControl.RepositoryItems.Add("CheckEdit") as RepositoryItemCheckEdit;
            if (_edit != null) _edit.EditValueChanged += edit_EditValueChanged;

            _column = gridView.Columns.Add();
            _column.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            _column.VisibleIndex = int.MaxValue;
            _column.FieldName = "CheckMarkSelection";
            _column.Caption = "Mark";
            _column.OptionsColumn.ShowCaption = false;
            _column.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            _column.ColumnEdit = _edit;

            gridView.CustomDrawColumnHeader += View_CustomDrawColumnHeader;
            gridView.CustomDrawGroupRow += View_CustomDrawGroupRow;
            gridView.CustomUnboundColumnData += view_CustomUnboundColumnData;
            gridView.RowStyle += view_RowStyle;
            gridView.MouseDown += view_MouseDown; // clear selection
        }

        protected virtual void Detach()
        {
            if (view == null) return;
            if (_column != null)
                _column.Dispose();
            if (_edit != null)
            {
                view.GridControl.RepositoryItems.Remove(_edit);
                _edit.Dispose();
            }

            view.CustomDrawColumnHeader -= View_CustomDrawColumnHeader;
            view.CustomDrawGroupRow -= View_CustomDrawGroupRow;
            view.CustomUnboundColumnData -= view_CustomUnboundColumnData;
            view.RowStyle -= view_RowStyle;
            view.MouseDown -= view_MouseDown;

            view = null;
        }

        protected void DrawCheckBox(Graphics g, Rectangle r, bool Checked)
        {
            var info = _edit.CreateViewInfo() as CheckEditViewInfo;
            var painter = _edit.CreatePainter() as CheckEditPainter;
            if (info != null)
            {
                info.EditValue = Checked;
                info.Bounds = r;
                info.CalcViewInfo(g);
                var args = new ControlGraphicsInfoArgs(info, new DevExpress.Utils.Drawing.GraphicsCache(g), r);
                if (painter != null) painter.Draw(args);
                args.Cache.Dispose();
            }

        }

        private void view_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Clicks == 1 && e.Button == MouseButtons.Left)
            {
                Point pt = view.GridControl.PointToClient(Control.MousePosition);
                GridHitInfo info = view.CalcHitInfo(pt);
                if (info.InRow && info.Column != _column && view.IsDataRow(info.RowHandle))
                {
                    //LinhMC comment đoạn này.
                    //ClearSelection();
                    //SelectRow(info.RowHandle, true);
                }

                if (info.InColumn && info.Column == _column)
                {
                    if (SelectedCount == view.DataRowCount)
                        ClearSelection();
                    else
                        SelectAll();
                }

                if (info.InRow && view.IsGroupRow(info.RowHandle) && info.HitTest != GridHitTest.RowGroupButton)
                {
                    bool selected = IsGroupRowSelected(info.RowHandle);
                    SelectGroup(info.RowHandle, !selected);
                }
            }
        }

        private void View_CustomDrawColumnHeader(object sender, ColumnHeaderCustomDrawEventArgs e)
        {
            if (e.Column == _column)
            {
                e.Info.InnerElements.Clear();
                e.Painter.DrawObject(e.Info);
                DrawCheckBox(e.Graphics, e.Bounds, SelectedCount == view.DataRowCount);
                e.Handled = true;
            }
        }

        private void View_CustomDrawGroupRow(object sender, RowObjectCustomDrawEventArgs e)
        {
            var info = e.Info as GridGroupRowInfo;

            if (info != null) info.GroupText = "         " + info.GroupText.TrimStart();
            e.Info.Paint.FillRectangle(e.Graphics, e.Appearance.GetBackBrush(e.Cache), e.Bounds);
            e.Painter.DrawObject(e.Info);

            if (info != null)
            {
                Rectangle r = info.ButtonBounds;
                r.Offset(r.Width * 2, 0);
                DrawCheckBox(e.Graphics, r, IsGroupRowSelected(e.RowHandle));
            }
            e.Handled = true;
        }

        private void view_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (IsRowSelected(e.RowHandle))
            {
                e.Appearance.BackColor = SystemColors.Highlight;
                e.Appearance.ForeColor = SystemColors.HighlightText;
            }
        }

        public GridView View
        {
            get
            {
                return view;
            }
            set
            {
                if (view != value)
                {
                    Detach();
                    Attach(value);
                }
            }
        }

        public GridColumn CheckMarkColumn
        {
            get
            {
                return _column;
            }
        }

        public int SelectedCount
        {
            get
            {
                return Selection.Count;
            }
        }

        public object GetSelectedRow(int index)
        {
            return Selection[index];
        }

        public int GetSelectedIndex(object row)
        {
            return Selection.IndexOf(row);
        }

        public void ClearSelection()
        {
            Selection.Clear();
            Invalidate();
        }

        private void Invalidate()
        {
            view.CloseEditor();
            view.BeginUpdate();
            view.EndUpdate();
        }

        public void SelectAll()
        {
            Selection.Clear();
            var dataSource = view.DataSource as ICollection;
            if (dataSource != null && dataSource.Count == view.DataRowCount)
                Selection.AddRange(dataSource);  // fast
            else
                for (int i = 0; i < view.DataRowCount; i++)  // slow
                    Selection.Add(view.GetRow(i));
            Invalidate();
        }

        public void SelectGroup(int rowHandle, bool select)
        {
            if (IsGroupRowSelected(rowHandle) && select) return;
            for (int i = 0; i < view.GetChildRowCount(rowHandle); i++)
            {
                int childRowHandle = view.GetChildRowHandle(rowHandle, i);
                if (view.IsGroupRow(childRowHandle))
                    SelectGroup(childRowHandle, select);
                else
                    SelectRow(childRowHandle, select, false);
            }
            Invalidate();
        }

        public void SelectRow(int rowHandle, bool select)
        {
            SelectRow(rowHandle, select, true);
        }

        private void SelectRow(int rowHandle, bool select, bool invalidate)
        {
            if (IsRowSelected(rowHandle) == select) return;
            object row = view.GetRow(rowHandle);
            if (select)
                Selection.Add(row);
            else
                Selection.Remove(row);
            if (invalidate)
            {
                Invalidate();
            }

        }

        public bool IsGroupRowSelected(int rowHandle)
        {
            for (int i = 0; i < view.GetChildRowCount(rowHandle); i++)
            {
                int row = view.GetChildRowHandle(rowHandle, i);
                if (view.IsGroupRow(row))
                {
                    if (!IsGroupRowSelected(row)) return false;
                }
                else
                    if (!IsRowSelected(row)) return false;
            }
            return true;
        }

        public bool IsRowSelected(int rowHandle)
        {
            if (view.IsGroupRow(rowHandle))
                return IsGroupRowSelected(rowHandle);

            object row = view.GetRow(rowHandle);
            return GetSelectedIndex(row) != -1;
        }

        private void view_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            if (e.Column == CheckMarkColumn)
            {
                if (e.IsGetData)
                    e.Value = IsRowSelected(View.GetRowHandle(e.ListSourceRowIndex));
                else
                    SelectRow(View.GetRowHandle(e.ListSourceRowIndex), (bool)e.Value);
            }
        }

        private void edit_EditValueChanged(object sender, EventArgs e)
        {
            view.PostEditor();
        }
    }
}
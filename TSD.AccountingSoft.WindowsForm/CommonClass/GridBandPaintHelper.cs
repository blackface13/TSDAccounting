using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils.Drawing;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Drawing;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.BandedGrid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.Drawing;

namespace TSD.AccountingSoft.WindowsForm.CommonClass
{
    public class GridBandPaintHelper : GridPainter
    {
        /// <summary>
        /// The _ view
        /// </summary>
        private readonly BandedGridView _gridView;

        /// <summary>
        /// The _ bands
        /// </summary>
        private readonly GridBand[] _gridBands;

        /// <summary>
        /// Initializes a new instance of the <see cref="GridBandPaintHelper"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        /// <param name="bands">The bands.</param>
        public GridBandPaintHelper(BandedGridView view, GridBand[] bands)
            : base(view)
        {
            _gridView = view;
            _gridBands = bands;
            _gridView.GridControl.Paint += GridControl_Paint;
            _gridView.CustomDrawColumnHeader += _gridView_CustomDrawColumnHeader;
            _gridView.CustomDrawBandHeader += _gridView_CustomDrawBandHeader;
        }

        /// <summary>
        /// Handles the CustomDrawBandHeader event of the _gridView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="BandHeaderCustomDrawEventArgs"/> instance containing the event data.</param>
        void _gridView_CustomDrawBandHeader(object sender, BandHeaderCustomDrawEventArgs e)
        {
            if (_gridBands.Contains(e.Band))
                e.Handled = true;
        }

        /// <summary>
        /// Handles the CustomDrawColumnHeader event of the _gridView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ColumnHeaderCustomDrawEventArgs"/> instance containing the event data.</param>
        void _gridView_CustomDrawColumnHeader(object sender, ColumnHeaderCustomDrawEventArgs e)
        {
            if (((e.Column is BandedGridColumn)) && (_gridBands.Contains((e.Column as BandedGridColumn).OwnerBand)))
                e.Handled = true;
        }

        /// <summary>
        /// Handles the Paint event of the GridControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        void GridControl_Paint(object sender, PaintEventArgs e)
        {
            foreach (GridBand band in _gridBands)
                foreach (BandedGridColumn column in band.Columns)
                    DrawColumnHeader(new GraphicsCache(e.Graphics), column);
        }

        /// <summary>
        /// Draws the column header.
        /// </summary>
        /// <param name="cache">The cache.</param>
        /// <param name="column">The column.</param>
        public void DrawColumnHeader(GraphicsCache cache, GridColumn column)
        {
            var viewInfo = _gridView.GetViewInfo() as BandedGridViewInfo;

            if (viewInfo != null)
            {
                GridColumnInfoArgs colInfo = viewInfo.ColumnsInfo[column];
                var bandedGridColumn = column as BandedGridColumn;
                if (bandedGridColumn != null)
                {
                    GridBandInfoArgs bandInfo = getBandInfo(viewInfo.BandsInfo, bandedGridColumn.OwnerBand);
                    if (colInfo == null || bandInfo == null)
                        return;
                    colInfo.Cache = cache;

                    int top = bandInfo.Bounds.Top;
                    Rectangle rect = colInfo.Bounds;
                    int delta = rect.Top - top;
                    rect.Y = top;
                    rect.Height += delta;
                    colInfo.Bounds = rect;
                }
                colInfo.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                ElementsPainter.Column.CalcObjectBounds(colInfo);
                ElementsPainter.Column.DrawObject(colInfo);
            }
        }

        /// <summary>
        /// Gets the band information.
        /// </summary>
        /// <param name="bands">The bands.</param>
        /// <param name="band">The band.</param>
        /// <returns></returns>
        GridBandInfoArgs getBandInfo(GridBandInfoCollection bands, GridBand band)
        {
            GridBandInfoArgs info = bands[band];
            if (info != null)
                return info;
            foreach (GridBandInfoArgs bandInfo in bands)
            {
                if (bandInfo.Children != null)
                {
                    info = getBandInfo(bandInfo.Children, band);
                    if (info != null)
                        return info;
                }
            }
            return null;
        }
    }
}

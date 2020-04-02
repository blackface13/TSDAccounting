/***********************************************************************
 * <copyright file="UserControlStockList.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: Wednesday, March 12, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Presenter.Dictionary.Stock;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.WindowsForm.BaseUserControls;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.FormDictionary;
using DevExpress.Utils;


namespace TSD.AccountingSoft.WindowsForm.UserControl.Dictionary
{
    /// <summary>
    /// Class UserControlStockList.
    /// </summary>
    public partial class UserControlStockList : BaseListUserControl, IStocksView
    {
        /// <summary>
        /// The _stocks presenter
        /// </summary>
        private readonly StocksPresenter _stocksPresenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserControlStockList"/> class.
        /// </summary>
        public UserControlStockList()
        {
            InitializeComponent();
            _stocksPresenter = new StocksPresenter(this);
        }

        /// <summary>
        /// Sets the stocks.
        /// </summary>
        /// <value>The stocks.</value>
        public IList<StockModel> Stocks
        {
            set
            {
                ListBindingSource.DataSource = value;
                gridView.PopulateColumns(value);

                ColumnsCollection.Add(new XtraColumn { ColumnName = "StockId", ColumnVisible = false, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "StockCode", ColumnCaption = "Mã kho", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 70 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "StockName", ColumnCaption = "Tên kho", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 200 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnCaption = "Mô tả", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 100 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnCaption = "Hoạt động", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 100 });
            }
        }

        /// <summary>
        /// Loads the data into grid.
        /// </summary>
        protected override void LoadDataIntoGrid()
        {
            _stocksPresenter.Display();
        }

        /// <summary>
        /// Deletes the grid.
        /// </summary>
        protected override void DeleteGrid()
        {
            new StockPresenter(null).Delete(int.Parse(PrimaryKeyValue));
        }

        /// <summary>
        /// Gets the form detail.
        /// </summary>
        /// <returns></returns>
        protected override FrmXtraBaseCategoryDetail GetFormDetail()
        {
            return new FrmXtraStockDetail();
        }
    }
}

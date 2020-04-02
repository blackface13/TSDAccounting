/***********************************************************************
 * <copyright file="UserControlCurrencyList.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuanHM
 * Email:    Tuanhm@buca.vn
 * Website:
 * Create Date: Tuesday, March 11, 2014 
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Presenter.Dictionary.Currency; 
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.WindowsForm.BaseUserControls;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.FormDictionary;
using DevExpress.Utils;


namespace TSD.AccountingSoft.WindowsForm.UserControl.Dictionary
{
    /// <summary>
    /// Class UserControlCurrencyList.
    /// </summary>
    public partial class UserControlCurrencyList : BaseListUserControl, ICurrenciesView  
    {
        private readonly CurrenciesPresenter _currenciesPresenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserControlCurrencyList"/> class.
        /// </summary>
        public UserControlCurrencyList()
        {
            InitializeComponent();
            _currenciesPresenter = new CurrenciesPresenter(this); 
        }

        /// <summary>
        /// Loads the data into grid.
        /// </summary>
        protected override void LoadDataIntoGrid()
        {
            _currenciesPresenter.Display();
        }

        /// <summary>
        /// Deletes the grid.
        /// </summary>
        protected override void DeleteGrid()
        {
            new CurrencyPresenter(null).Delete(int.Parse(PrimaryKeyValue));
        }

        /// <summary>
        /// Sets the currencies.
        /// </summary>
        /// <value>The currencies.</value>
        public IList<CurrencyModel> Currencies
        {
            set
            {
                ListBindingSource.DataSource = value;
                gridView.PopulateColumns(value);
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CurrencyId", ColumnVisible = false, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CurrencyCode", ColumnCaption = "Mã tiền tệ", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 70 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnCaption = "Được sử dụng", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 50 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CurrencyName", ColumnCaption = "Tên tiền tệ", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 350 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Prefix", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Suffix", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsMain", ColumnVisible = false });
            }
        }

        /// <summary>
        /// Gets the form detail.
        /// </summary>
        /// <returns></returns>
        protected override FrmXtraBaseCategoryDetail GetFormDetail()
        {
            return new FrmXtraCurrencyDetail();
        }
    }
}

/***********************************************************************
 * <copyright file="UserControlExchangeRateList.cs" company="BUCA JSC">
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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Presenter.Dictionary.ExchangeRate;
using TSD.AccountingSoft.Session;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.WindowsForm.BaseUserControls;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.FormDictionary;


namespace TSD.AccountingSoft.WindowsForm.UserControl.Dictionary
{
    /// <summary>
    /// class UserControlExchangeRateList 
    /// </summary>
    public partial class UserControlExchangeRateList : BaseListUserControl, IExchangeRatesView
    {
        private readonly ExchangeRatesPresenter _exchangeRatesPresenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserControlExchangeRateList"/> class.
        /// </summary>
        public UserControlExchangeRateList()
        {
            InitializeComponent();
            _exchangeRatesPresenter = new ExchangeRatesPresenter(this);
        }

        #region IExchangeRatesView Members

        /// <summary>
        /// Sets the exchangeRates.
        /// </summary>
        /// <value>
        /// The exchangeRates.
        /// </value>
        public IList<ExchangeRateModel> ExchangeRateModels
        {
            set
            {
                if (value != null)
                {
                    var list = new List<ExchangeRateModel>();
                    if (GlobalVariable.DisplayVourcherMode == 1)
                    {
                        list = value.ToList();
                    }
                    else
                    {
                        list = value.Where(c => c.FromDate.Year == DateTime.Parse(GlobalVariable.StartedDate).Year).ToList();
                    }
                    grdList.DataSource = list;
                }
                else
                {
                    grdList.DataSource = new List<ExchangeRateModel>();
                }

                ColumnsCollection.Add(new XtraColumn { ColumnName = "ExchangeRateId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceCode", ColumnCaption = "Nguồn vốn", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 50 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnCaption = "Diễn giải", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 200 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "FromDate", ColumnCaption = "Từ ngày", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 90 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ToDate", ColumnCaption = "Đến ngày", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 90 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ExchangeRate", ColumnCaption = "Tỷ giá", ColumnPosition = 5, ColumnVisible = true, ColumnWith = 100 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Inactive", ColumnCaption = "Ngừng sử dụng", ColumnPosition = 6, ColumnVisible = true, ColumnWith = 100 });
            }
        }

        /// <summary>
        /// Loads the data into grid.
        /// </summary>
        protected override void LoadDataIntoGrid()
        {
            _exchangeRatesPresenter.Display();
        }

        /// <summary>
        /// Deletes the grid.
        /// </summary>
        protected override void DeleteGrid()
        {
            new ExchangeRatePresenter(null).Delete(int.Parse(PrimaryKeyValue));
        }

        #endregion

        /// <summary>
        /// Gets the form detail.
        /// </summary>
        /// <returns></returns>
        protected override FrmXtraBaseCategoryDetail GetFormDetail()
        {
            return new FrmXtraExchangeRateDetail();
        }
    }
}

/***********************************************************************
 * <copyright file="UserControlSalaryList.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuanHM
 * Email:    TuanHM@buca.vn
 * Website:
 * Create Date: Tuesday, July 9, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using TSD.AccountingSoft.Session;
using TSD.AccountingSoft.WindowsForm.Resources;
using TSD.AccountingSoft.Presenter.Salary;
using TSD.AccountingSoft.View.Salary;
using TSD.AccountingSoft.WindowsForm.BaseUserControls;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.FormBusiness;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraBars;
using System.Linq;
using TSD.AccountingSoft.Model.BusinessObjects.Salary;

namespace TSD.AccountingSoft.WindowsForm.UserControl.Voucher

{
    /// <summary>
    /// Class UserControlSalaryList.
    /// </summary>
    public partial class UserControlSalaryList : BaseListUserControl, ISalariesView
    {
        /// <summary>
        /// Gets or sets the key value.
        /// </summary>
        /// <value>The key value.</value>
        public string KeyValue { set; get; }
        /// <summary>
        /// The _salaries presenter
        /// </summary>
        private readonly SalariesPresenter _salariesPresenter;
        /// <summary>
        /// Initializes a new instance of the <see cref="UserControlSalaryList" /> class.
        /// </summary>
        public UserControlSalaryList()
        {
            InitializeComponent();
            _salariesPresenter = new SalariesPresenter(this);
            
        }

        /// <summary>
        /// Refreshes the toolbar.
        /// </summary>
        protected override void RefreshToolbar()
        {
            barButtonEditItem.Visibility = BarItemVisibility.Never;
            barButtonDeleteItem.Visibility = BarItemVisibility.Never;
            barButtonPrintItem.Enabled = gridView.RowCount > 0;
        }

        /// <summary>
        /// Loads the data into grid.
        /// </summary>
        protected override void LoadDataIntoGrid()
        {
            var frm = new FrmXtraSalary();
            // mainPanelControl.FeatureCaption.Text
            //foreach (Control c in Controls)
            //    if (c.Name == "FeatureCaption")
            //    {
            //        c.Text = @"SHP phí năm " + DateTime.Parse(new GlobalVariable().PostedDate).Year;
            //    }
           // frm.Text = @"SHP phí năm " + DateTime.Parse(new GlobalVariable().PostedDate).Year;


            barButtonEditItem.Enabled = false;
            barButtonDeleteItem.Enabled = false;
            frm.PostKeyValue += InstanceOnPostKeyValue;

            _salariesPresenter.Display();
        }

        /// <summary>
        /// Sets the row after update.
        /// </summary>
        protected new void SetRowAfterUpdate()
        {
            gridView.OptionsSelection.EnableAppearanceFocusedRow = true;
            gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            if (gridView.RowCount > 0)
                gridView.FocusedRowHandle = 1;
        }

        /// <summary>
        /// Gets the row value selected.
        /// </summary>
         protected new void GetRowValueSelected() 
        {
            
        }



         /// <summary>
         /// Instances the on post key value.
         /// </summary>
         /// <param name="sender">The sender.</param>
         /// <param name="keyValue">The key value.</param>
        private void InstanceOnPostKeyValue(object sender, string keyValue)
        {
            KeyValue = keyValue;
        }

        /// <summary>
        /// Adds the data.
        /// </summary>
        protected override void AddData() 
        {
          //  base.AddData();
            var frmXtraSalary = new FrmXtraSalary();// FrmXtraSalary.Instance; 
            frmXtraSalary.ShowDialog();
            LoadData();
        }

        /// <summary>
        /// Edits the data.
        /// </summary>
        protected override void EditData() 
        {
            var frmXtraSalary = new FrmXtraSalary();
            var employeeId = gridView.Columns["ExchangeRate"];  // RefDate
            var refDate = gridView.Columns["RefDate"];
            //var refNo = gridView.Columns["RefNo"];  
            if (employeeId != null)
            {
                frmXtraSalary.ExchangeRateForSend = gridView.GetRowCellValue(gridView.FocusedRowHandle, employeeId).ToString();
                frmXtraSalary.RefdateForSend = gridView.GetRowCellValue(gridView.FocusedRowHandle, refDate).ToString();
            }

            frmXtraSalary.ShowDialog();
            LoadData();
        }

        /// <summary>
        /// Deletes the grid.
        /// </summary>
        protected override void DeleteGrid() 
        {
         //   new SalariesPresenter(null).Delete(int.Parse(PrimaryKeyValue));
        }

        /// <summary>
        /// Sets the currencies.
        /// </summary>
        /// <value>The currencies.</value>
        public IList<Model.BusinessObjects.Salary.SalaryModel> Salaries 
        {
            set
            {
                //var salary = new List<SalaryModel>();
                //salary = GlobalVariable.CurrencyType == 0 ? value.Where(x => x.CurrencyCode.Trim() == "USD").ToList() : value.Where(x => x.CurrencyCode.Trim() != "USD").ToList();
                ListBindingSource.DataSource = value;
                gridView.PopulateColumns(value);
                ColumnsCollection.Add(new XtraColumn { ColumnName = "EmployeePayrollId", ColumnVisible = false, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalAmountOc", ColumnCaption = "Số tiền", ColumnPosition = 2,ColumnType =UnboundColumnType.Decimal, ColumnVisible = true, ColumnWith = 150 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "JournalMemo", ColumnCaption = "Tháng", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 60 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefTypeId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefNo", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefDate", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "PostedDate", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CurrencyCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Employees", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "EmployeeId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalAmountExchange", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ExchangeRate", ColumnVisible = false });

                foreach (var column in ColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        gridView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        gridView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                        gridView.Columns[column.ColumnName].ToolTip = column.ToolTip;
                    }
                    else gridView.Columns[column.ColumnName].Visible = false;
                    SetNumericFormatControl(gridView, true);// định dạng số
                }
            }
        }
    }
}

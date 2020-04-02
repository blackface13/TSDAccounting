using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using TSD.AccountingSoft.Session;
using TSD.AccountingSoft.Presenter.Dictionary.Stock;
using TSD.AccountingSoft.Presenter.Inventory.ReCalOutputInventory; 
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.View.Inventory;
using TSD.AccountingSoft.WindowsForm.CommonClass;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.Resources;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DateTimeRangeBlockDev.Helper;

namespace TSD.AccountingSoft.WindowsForm.FormBusiness
{
    public partial class FrmXtraReCalOutputInventory : XtraForm, IStocksView, IReCalItemTransactionView
    {
        private StocksPresenter _stocksPresenter;
        private GlobalVariable _dbOptionHelper;
        protected string CurrencyAccounting;
        protected string CurrencyLocal;
        private ReCalOutputInventoryPresenter _reCalOutputInventoryPresenter;

 
        /// <summary>
        /// Initializes a new instance of the <see cref="FrmXtraReCalOutputInventory"/> class.
        /// </summary>
        public FrmXtraReCalOutputInventory()
        {
            InitializeComponent();
            _dbOptionHelper = new GlobalVariable();
            _stocksPresenter = new StocksPresenter(this);          
            _reCalOutputInventoryPresenter = new ReCalOutputInventoryPresenter(this);

            dateTimeRangeV1.DateRangePeriodMode = DateRangeMode.MonthAndQuarter;
            dateTimeRangeV1.InitSelectedIndex = 0;
            dateTimeRangeV1.InitData(DateTime.Parse(new GlobalVariable().PostedDate));

        }

        /// <summary>
        /// Handles the Load event of the FrmXtraReCalOutputInventory control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FrmXtraReCalOutputInventory_Load(object sender, EventArgs e)
        {
            LoaDataCombo();
            progressBarControl1.Visible = false;




        }

        /// <summary>
        /// Loas the data combo.
        /// </summary> 
        private void LoaDataCombo()
        {
           _stocksPresenter.Display();
         //   _currenciesPresenter.DisplayIsMain();
           CurrencyAccounting = _dbOptionHelper.CurrencyAccounting;
           CurrencyLocal = _dbOptionHelper.CurrencyLocal;
            InitDefaultCurrencies();
        }

        //protected void InitDefaultCurrencies()
        //{
        //    cboCurrency.Properties.DataSource = new List<GridLookUpItem> { new GridLookUpItem(CurrencyAccounting, CurrencyAccounting), new GridLookUpItem(CurrencyAccountingUSD, CurrencyAccountingUSD) };
        //    grdCurrencyType.Properties.PopulateViewColumns();
        //    var currencyColumns = new List<XtraColumn>
        //                                  {
        //                                      new XtraColumn
        //                                          {
        //                                              ColumnName = "DataValue",
        //                                              ColumnVisible = false,
        //                                              Alignment = HorzAlignment.Center
        //                                          },                                              
        //                                      new XtraColumn
        //                                          {
        //                                              ColumnName = "DataMember",                                                      
        //                                              ColumnCaption = "Tên tiền tệ",
        //                                              ColumnVisible = true,
        //                                              ColumnPosition = 2,                                                      
        //                                              ColumnWith = 100
        //                                          }
        //                                  };

        //    foreach (var column in currencyColumns)
        //    {
        //        if (column.ColumnVisible)
        //        {
        //            grdCurrencyType.Properties.View.Columns[column.ColumnName].Caption = column.ColumnCaption;
        //            grdCurrencyType.Properties.View.Columns[column.ColumnName].AbsoluteIndex = column.ColumnPosition;
        //            grdCurrencyType.Properties.View.Columns[column.ColumnName].Width = column.ColumnWith;
        //        }
        //        else grdCurrencyType.Properties.View.Columns[column.ColumnName].Visible = false;
        //    }
        //    grdCurrencyType.Properties.View.OptionsView.ShowIndicator = false;
        //    grdCurrencyType.Properties.View.OptionsView.ShowColumnHeaders = false;
        //    grdCurrencyType.Properties.ValueMember = "DataValue";
        //    grdCurrencyType.Properties.DisplayMember = "DataMember";
        //}

        protected void InitDefaultCurrencies()
        {
            if (CurrencyAccounting == CurrencyLocal) 
            {
                cboCurrency.Properties.DataSource = new List<GridLookUpItem> { new GridLookUpItem(CurrencyAccounting, CurrencyAccounting) };
       
            }
            else
            {
                cboCurrency.Properties.DataSource = new List<GridLookUpItem> { new GridLookUpItem(CurrencyAccounting, CurrencyAccounting), new GridLookUpItem(CurrencyLocal, CurrencyLocal) };
            }
          
           // grdCurrencyType.Properties.PopulateViewColumns();
            var currencyColumns = new List<XtraColumn>
                                          {
                                              new XtraColumn
                                                  {
                                                      ColumnName = "DataValue",
                                                      ColumnVisible = false,
                                                      Alignment = HorzAlignment.Center
                                                  },                                              
                                              new XtraColumn
                                                  {
                                                      ColumnName = "DataMember",                                                      
                                                      ColumnCaption = "Tên tiền tệ",
                                                      ColumnVisible = true,
                                                      ColumnPosition = 2,                                                      
                                                      ColumnWith = 100
                                                  }
                                          };
            cboCurrency.Properties.DisplayMember = "DataMember";
            cboCurrency.Properties.ValueMember = "DataValue";



            //foreach (var column in currencyColumns)
            //{
            //    if (column.ColumnVisible)
            //    {
            //        grdCurrencyType.Properties.View.Columns[column.ColumnName].Caption = column.ColumnCaption;
            //        grdCurrencyType.Properties.View.Columns[column.ColumnName].AbsoluteIndex = column.ColumnPosition;
            //        grdCurrencyType.Properties.View.Columns[column.ColumnName].Width = column.ColumnWith;
            //    }
            //    else grdCurrencyType.Properties.View.Columns[column.ColumnName].Visible = false;
            //}
            //grdCurrencyType.Properties.View.OptionsView.ShowIndicator = false;
            //grdCurrencyType.Properties.View.OptionsView.ShowColumnHeaders = false;
            //grdCurrencyType.Properties.ValueMember = "DataValue";
            //grdCurrencyType.Properties.DisplayMember = "DataMember";
        }

        #region function

        #endregion

        #region Events

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (dateTimeRangeV1.FromDate.ToString() == "")
            {
                XtraMessageBox.Show("Bạn chưa chọn ngày tính giá", ResourceHelper.GetResourceValueByName("ResExceptionCaption"));
                return;
            }

            if (dateTimeRangeV1.ToDate.ToString() == "")
            {
                XtraMessageBox.Show("Bạn chưa chọn ngày tính giá", ResourceHelper.GetResourceValueByName("ResExceptionCaption"));
                return;
            }

            if (cboCurrency.Text == "")
            {
                XtraMessageBox.Show("Bạn chưa chọn loại tiền", ResourceHelper.GetResourceValueByName("ResExceptionCaption"));
                return;
            }

            if (cboStock.Text == "")
            {
                XtraMessageBox.Show("Bạn chưa chọn kho", ResourceHelper.GetResourceValueByName("ResExceptionCaption"));
                return;
            }


            bool flag = _reCalOutputInventoryPresenter.CheckReCalOutputInventory(); // Kiểm tra xem đã có dữ liệu xuất kho trong kỳ chưa?
                                                                                    // flag = _reCalOutputInventoryPresenter.CheckOutputInventory();
            bool checkOutputInventory = _reCalOutputInventoryPresenter.ChecklOutputInventory();


            if (checkOutputInventory == false)
            {
                XtraMessageBox.Show("Chưa có nghiệp vụ xuất kho trong kỳ tính giá này", ResourceHelper.GetResourceValueByName("ResExceptionCaption"));
                return;
            }

            if (flag == true)
            {
                var result = XtraMessageBox.Show("Kỳ này đã tính giá. Bạn có muốn tính giá lại hay không??", "Kỳ tính giá",
                                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    try
                    {
                        this.Size = new Size(314, 245);
                        int x = 0;
                        progressBarControl1.Visible = true;
                        progressBarControl1.Properties.Minimum = 1;
                        progressBarControl1.Properties.Maximum = 10;
                        progressBarControl1.EditValue = 1;
                        progressBarControl1.Properties.Step = 1;
                        for (x = 1; x <= 10; x++)
                        {
                            progressBarControl1.PerformStep();
                            // Wait 100 milliseconds.
                            Thread.Sleep(100);
                            if (x == 6)
                            {
                                _reCalOutputInventoryPresenter.Save();
                            }
                        }
                        XtraMessageBox.Show("Thành công", ResourceHelper.GetResourceValueByName("Thông báo"));
                        btnHuyBo.Text = @"Kết thúc";
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"));
                    }
                }
            }
            else
            {
                if (cboCurrency.Text == "")
                {
                    XtraMessageBox.Show("Bạn chưa chọn loại tiền", ResourceHelper.GetResourceValueByName("ResExceptionCaption"));
                    return;
                }

                if (cboStock.Text == "")
                {
                    XtraMessageBox.Show("Bạn chưa chọn kho", ResourceHelper.GetResourceValueByName("ResExceptionCaption"));
                    return;
                }

                try
                {
                    this.Size = new Size(314, 245);
                    int x = 0;
                    progressBarControl1.Visible = true;
                    progressBarControl1.Properties.Minimum = 1;
                    progressBarControl1.Properties.Maximum = 10;
                    progressBarControl1.EditValue = 1;
                    progressBarControl1.Properties.Step = 1;
                    for (x = 1; x <= 10; x++)
                    {
                        progressBarControl1.PerformStep();
                        Thread.Sleep(100);
                        if (x == 6)
                        {
                            _reCalOutputInventoryPresenter.Save();
                        }
                    }
                    XtraMessageBox.Show("Thành công", ResourceHelper.GetResourceValueByName("Thông báo"));
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"));
                }
            }

            var obj = _dbOptionHelper.CurrencyDecimalDigits;
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        public IList<Model.BusinessObjects.Dictionary.StockModel> Stocks
        {
            set
            {
                if (value == null) return;
                foreach(var stock in value)
                {
                    stock.StockName = stock.StockCode + " - " + stock.StockName;
                }
                cboStock.Properties.DataSource = value;
                var colColection = new List<XtraColumn>();
                colColection.Clear();

                colColection.Add(new XtraColumn { ColumnName = "StockCode", ColumnCaption = "Mã kho", ToolTip = "Mã kho", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 100, Alignment = HorzAlignment.Center });
                colColection.Add(new XtraColumn { ColumnName = "StockName", ColumnCaption = "Tên kho", ToolTip = "Tên kho", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 100, Alignment = HorzAlignment.Center });
                colColection.Add(new XtraColumn { ColumnName = "StockId", ColumnCaption = "", ColumnVisible = false });
                colColection.Add(new XtraColumn { ColumnName = "IsActive", ColumnCaption = "", ColumnVisible = false });
                colColection.Add(new XtraColumn { ColumnName = "Description", ColumnCaption = "", ColumnVisible = false });
                foreach (var column in colColection)
                {
                    if (column.ColumnVisible)
                    {
                        //cboStock.Columns[column.ColumnName].ToolTip = column.ToolTip;
                        //_rpsStockView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        //_rpsStockView.Columns[column.ColumnName].SortIndex = column.ColumnPosition;
                        //_rpsStockView.Columns[column.ColumnName].Width = column.ColumnWith;
                    }
                }
                cboStock.Properties.DisplayMember = "StockName";
                cboStock.Properties.ValueMember = "StockId";
            }
        }

     
        /// <summary>
        /// Gets or sets from date.
        /// </summary>
        /// <value>
        /// From date.
        /// </value>
        public string FromDate
        {
            get
            {
                return dateTimeRangeV1.FromDate.ToShortDateString();
            }
            set
            {
               // dateTimeRangeV1.InitData(DateTime.Parse(value));
            }
        }

        /// <summary>
        /// Gets or sets the reference currency Decimal Digit.
        /// </summary>
        /// <value>
        /// The reference currency Decimal Digit.
        /// </value>  
        /// 
        public int currencyDecimalDigits
        {
            get
            {
                return int.Parse(_dbOptionHelper.CurrencyDecimalDigits);
            }
            set
            {

            }
        }


        /// <summary>
        /// Gets or sets the reference date.
        /// </summary>
        /// <value>
        /// The reference date.
        /// </value>
        public string ToDate
        {
            get
            {
                return dateTimeRangeV1.ToDate.ToShortDateString();
             }
            set
            {
              //  dateTimeRangeV1.InitData( DateTime.Parse(value)); 
            }
        }

        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>
        /// The employee identifier.
        /// </value>
        public List<int> StockId
        {
            get
            {
                List<int> listKey = new List<int>(); 
               var  list = cboStock.Properties.GetItems().GetCheckedValues();//.GetItems.GetCheckedValues()            
                 foreach (var key in list)
                 {
                    listKey.Add(int.Parse(key.ToString()));
                 }
                return listKey;
            }
           
        }

        /// <summary>
        /// Gets or sets the trader.
        /// </summary>
        /// <value>
        /// The trader.
        /// </value>
        public string CurrencyCode
        {
            get
            {
               // var vendor = (CurrencyModel)grdCurrencyType.GetSelectedDataRow();
                var vendor = cboCurrency.Text;
                if (vendor != null)
                return vendor;
                return null;
            }
            set
            {
                if (value != null)
                    cboCurrency.EditValue = value;
            }
        }

        /// <summary>
        /// Handles the EditValueChanged event of the progressBarControl1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void progressBarControl1_EditValueChanged(object sender, EventArgs e)
        {
            int i = int.Parse(Math.Floor(double.Parse(this.progressBarControl1.EditValue.ToString())).ToString()) *10;
           lblProcess.Text= i.ToString() + @"% hoàn thành...";
        }



    }
}
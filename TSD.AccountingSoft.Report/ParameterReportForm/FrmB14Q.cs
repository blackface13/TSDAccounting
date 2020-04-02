/***********************************************************************
 * <copyright file="FrmB14Q.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuanHM 
 * Email:    TuanHM@buca.vn
 * Website:
 * Create Date: Friday, September 12, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using TSD.AccountingSoft.Report.BaseParameterForm;
using TSD.AccountingSoft.Report.CommonClass;
using TSD.AccountingSoft.Session;
using TSD.AccountingSoft.Presenter.Dictionary.Account;
using TSD.AccountingSoft.Presenter.Dictionary.Stock;
using TSD.AccountingSoft.View.Dictionary;
using DateTimeRangeBlockDev.Helper;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using System.Linq;

namespace TSD.AccountingSoft.Report.ParameterReportForm
{
    public partial class FrmB14Q : FrmXtraBaseParameter, IAccountsView, IStocksView
    {
        private readonly StocksPresenter _stocksPresenter;
        private readonly AccountsPresenter _accountsPresenter;
        private readonly GlobalVariable _dbOptionHelper;
        protected string CurrencyAccounting;
        protected string CurrencyAccountingUSD = "USD";
        public FrmB14Q()
        {
            InitializeComponent();
            _dbOptionHelper = new GlobalVariable();
            _stocksPresenter = new StocksPresenter(this);
            _accountsPresenter = new AccountsPresenter(this);
            dateTimeRangeV1.DateRangePeriodMode = DateRangeMode.Reduce;
            dateTimeRangeV1.InitSelectedIndex = GlobalVariable.DateRangeSelectedIndex;
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
        }

        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>
        /// The employee identifier.
        /// </value>
        public string ListStockId
        {
            get
            {
                string listKey = "";
                var list = cboStock.Properties.GetItems().GetCheckedValues();
                foreach (var key in list)
                {
                    listKey = listKey + "," + key;
                }
                listKey = listKey.Remove(0, 1);
                return listKey;
            }

        }

        public string StockName
        {
            get;
            set;

        }

        public string AccountName
        {
            get;
            set;
        }


        public bool IsTotalBandInNewPage
        {
            get
            {
                return chkMoveTotalInNewPage.Checked;
            }
        }

        public string AccountCode
        {
            get
            {
                if (grdLookUpAccount.Text == "")
                {
                    return " ";
                }
                return grdLookUpAccount.GetColumnValue("AccountCode").ToString();
            }
        }

        public IList<TSD.AccountingSoft.Model.BusinessObjects.Dictionary.AccountModel> Accounts
        {
            set
            {
                grdLookUpAccount.Properties.DataSource = value;

                grdLookUpAccount.Properties.PopulateColumns();

                var gridColumnsCollection = new List<XtraColumn>
                    {
                       new XtraColumn { ColumnName = "AccountId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "AccountCode", ColumnCaption = "Mã tài khoản", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 100 },
                        new XtraColumn { ColumnName = "AccountCategoryId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "AccountName", ColumnCaption = "Tên tài khoản", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 200 },
                        new XtraColumn { ColumnName = "Description", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsActive", ColumnVisible = false },
                        new XtraColumn { ColumnName = "ForeignName", ColumnVisible = false },
                        new XtraColumn { ColumnName = "Grade", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsDetail", ColumnVisible = false },
                        new XtraColumn { ColumnName = "BalanceSide", ColumnVisible = false }, //  Balanceside
                        new XtraColumn { ColumnName = "ConcomitantAccount", ColumnVisible = false },
                        new XtraColumn { ColumnName = "BankId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsChapter", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsBudgetCategory", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsBudgetItem", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsBudgetGroup", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsBudgetSource", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsActivity", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsCurrency", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsCustomer", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsVendor", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsEmployee", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsAccountingObject", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsInventoryItem", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsFixedAsset", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsCapitalAllocate", ColumnVisible = false },
                        new XtraColumn { ColumnName = "ParentId", ColumnVisible = false },
                        new XtraColumn {ColumnName = "IsCapitalAllocate", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsSystem", ColumnVisible = false},

                        new XtraColumn {ColumnName = "CurrencyCode", ColumnVisible = false},
                        new XtraColumn {ColumnName = "IsProject", ColumnVisible = false},
                      new XtraColumn {ColumnName = "IsAllowinputcts", ColumnVisible = false},
                    };

                foreach (var column in gridColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        grdLookUpAccount.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        grdLookUpAccount.Properties.SortColumnIndex = column.ColumnPosition;
                        grdLookUpAccount.Properties.Columns[column.ColumnName].Width = column.ColumnWith;

                    }
                    else
                    {
                        grdLookUpAccount.Properties.Columns[column.ColumnName].Visible = false;

                    }
                }
                grdLookUpAccount.Properties.PopupWidth = 300;
                grdLookUpAccount.Properties.BestFit();
                grdLookUpAccount.Properties.DisplayMember = "AccountCode";
                grdLookUpAccount.Properties.ValueMember = "AccountCode";



            }
        }

        private void FrmB14Q_Load(object sender, EventArgs e)
        {
            _stocksPresenter.Display();
            _accountsPresenter.DisplayInventoryItem();
            CurrencyAccounting = _dbOptionHelper.CurrencyAccounting;
        }


        public IList<TSD.AccountingSoft.Model.BusinessObjects.Dictionary.StockModel> Stocks
        {
            set
            {
                if (value == null) return;
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
                    }
                }
                cboStock.Properties.DisplayMember = "StockName";
                cboStock.Properties.ValueMember = "StockId";
            }
        }

        protected override bool ValidData()
        {
            if (dateTimeRangeV1.FromDate.ToString(CultureInfo.InvariantCulture) == "")
            {
                XtraMessageBox.Show("Bạn chưa chọn ngày tính giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (dateTimeRangeV1.ToDate.ToString(CultureInfo.InvariantCulture) == "")
            {
                XtraMessageBox.Show("Bạn chưa chọn ngày tính giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (cboStock.Text == "")
            {
                XtraMessageBox.Show("Bạn chưa chọn kho", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboStock.Focus();
                return false;
            }
            if (GlobalVariable.CurrencyViewReport == "" && GlobalVariable.AmountTypeViewReport == 2)
            {
                XtraMessageBox.Show("Bạn chưa chọn loại tiền", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            GlobalVariable.DateRangeSelectedIndex = dateTimeRangeV1.cboDateRange.SelectedIndex;


            if (grdLookUpAccount.Text == "")
            {
                XtraMessageBox.Show("Bạn chưa chọn tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                grdLookUpAccount.Focus();
                return false;
            }

            var lstAccount = (List<TSD.AccountingSoft.Model.BusinessObjects.Dictionary.AccountModel>)grdLookUpAccount.Properties.DataSource;
            lstAccount = lstAccount.Where(x => x.AccountCode == grdLookUpAccount.EditValue.ToString()).ToList();
            AccountName = lstAccount[0].AccountName;

            var lstStock = (List<TSD.AccountingSoft.Model.BusinessObjects.Dictionary.StockModel>)cboStock.Properties.DataSource;
            string[] stringSeparators = new string[] { "," };
            string[] arrStockId = cboStock.EditValue.ToString().Split(stringSeparators, StringSplitOptions.None);
            string stockName = "";
            foreach(var it in arrStockId)
            {
               var objStock = lstStock.Where(x => x.StockId == int.Parse(it)).FirstOrDefault();
                if (objStock!=null)
                {
                    stockName = stockName + objStock.StockCode + " - " + objStock.StockName + ", ";
                }

            }

            if (stockName.Length>0)
            {
                stockName =  stockName.Substring(0,stockName.Length - 2);
            }
            StockName = stockName;
            return true;
        }



        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
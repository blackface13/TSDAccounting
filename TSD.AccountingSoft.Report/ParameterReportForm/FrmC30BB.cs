/***********************************************************************
 * <copyright file="FrmC30BB.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: 14 June 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * 
 * ************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TSD.AccountingSoft.Report.BaseParameterForm;
using TSD.AccountingSoft.Report.CommonClass;
using TSD.AccountingSoft.Report.ReportClass;
using TSD.AccountingSoft.Session;
using TSD.AccountingSoft.Model;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Model.BusinessObjects.Report;
using TSD.AccountingSoft.Model.BusinessObjects.Report.Voucher;
using TSD.AccountingSoft.Presenter.Cash.ReceiptVoucher;
using TSD.AccountingSoft.Presenter.Report;
using TSD.AccountingSoft.View.Cash;
using TSD.AccountingSoft.View.Report;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using RSSHelper;

namespace TSD.AccountingSoft.Report.ParameterReportForm
{
    /// <summary>
    /// FrmC30BB
    /// </summary>
    public partial class FrmC30BB : FrmXtraBaseParameter, IC30BBView, IReportView
    {
        /// <summary>
        /// The _C30 bb presenter
        /// </summary>
        private readonly C30BBPresenter _c30BBPresenter;

       // private List<ReportListModel> _reportList;

        private  ReportListPresenter _reportListPresenter;


        /// <summary>
        /// Initializes a new instance of the <see cref="FrmC30BB"/> class.
        /// </summary>
        public FrmC30BB()
        {

            InitializeComponent();
            _reportListPresenter = new ReportListPresenter(this);
            _c30BBPresenter = new C30BBPresenter(this);
        }

        public IList<CurrencyModel> CurrencyModels { get; set; }

        public int BaseRefTypeId
        {
            set;
            get;
        }


        /// <summary>
        /// Gets or sets the C30 bb list.
        /// </summary>
        /// <value>
        /// The C30 bb list.
        /// </value>
        public List<C30BBModel> C30BBList
        {
            get
            {
                var voucherC30BB = new List<C30BBModel>();
                if (gridViewDetail.DataSource != null && gridViewDetail.RowCount > 0)
                {
                    for (var i = 0; i < gridViewDetail.RowCount; i++)
                    {
                        var rowVoucherDetailData = (C30BBModel)gridViewDetail.GetRow(i);
                        if (rowVoucherDetailData != null)
                        {
                            var item = new C30BBModel
                            {
                                RefId = rowVoucherDetailData.RefId,
                                RefNo = rowVoucherDetailData.RefNo,
                                PostedDate = rowVoucherDetailData.PostedDate,
                                RefDate = rowVoucherDetailData.RefDate,
                                JournalMemo = rowVoucherDetailData.JournalMemo,
                                TotalAmount = rowVoucherDetailData.TotalAmount,
                                TotalAmountExchange = rowVoucherDetailData.TotalAmountExchange,
                                Address = rowVoucherDetailData.Address,
                                AccountNumber = rowVoucherDetailData.AccountNumber,
                                CorrespondingAccountNumber = rowVoucherDetailData.CorrespondingAccountNumber,
                                DocumentInclude = rowVoucherDetailData.CorrespondingAccountNumber,
                                ExchangeRate = rowVoucherDetailData.ExchangeRate,
                                IsSelect = rowVoucherDetailData.IsSelect,
                                Trader = rowVoucherDetailData.Trader
                            };
                            voucherC30BB.Add(item);
                        }
                    }
                }
                return voucherC30BB.ToList();
            }
            set
            {
                
                grdDetail.DataSource = value;
                List<XtraColumn> columnsCollection = new List<XtraColumn>();
                gridViewDetail.PopulateColumns(value);
                columnsCollection.Add(new XtraColumn { ColumnName = "IsSelect", FixedColumn = FixedStyle.Left, ColumnCaption = "Chọn", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 30, Alignment = HorzAlignment.Center });
                columnsCollection.Add(new XtraColumn { ColumnName = "RefId", ColumnVisible = false, FixedColumn = FixedStyle.Left, Alignment = HorzAlignment.Center });
                columnsCollection.Add(new XtraColumn { ColumnName = "RefNo", ColumnCaption = "Số chứng từ", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 100, FixedColumn = FixedStyle.Left, AllowEdit = true, Alignment = HorzAlignment.Center});
                columnsCollection.Add(new XtraColumn { ColumnName = "PostedDate", ColumnCaption = "Ngày HT", FixedColumn = FixedStyle.Left, ColumnPosition = 3, ColumnVisible = true, ColumnWith = 50, ToolTip = "Ngày hach toán", Alignment = HorzAlignment.Center });
                columnsCollection.Add(new XtraColumn { ColumnName = "JournalMemo", ColumnCaption = "Diễn giải", FixedColumn = FixedStyle.Left, ColumnPosition = 4, ColumnVisible = true, ColumnWith = 200, Alignment = HorzAlignment.Center });
                columnsCollection.Add(new XtraColumn { ColumnName = "TotalAmount", ColumnCaption = "Số tiền", ColumnType = UnboundColumnType.Decimal, FixedColumn = FixedStyle.Left, ColumnPosition = 5, ColumnVisible = true, ColumnWith = 100, Alignment = HorzAlignment.Center });
                columnsCollection.Add(new XtraColumn { ColumnName = "TotalAmountExchange", ColumnCaption = "Số tiền quy đổi", ColumnType = UnboundColumnType.Decimal, FixedColumn = FixedStyle.None, ColumnPosition = 6, ColumnVisible = false, ColumnWith = 100, Alignment = HorzAlignment.Center });
                columnsCollection.Add(new XtraColumn { ColumnName = "Address", ColumnCaption = "Địa chỉ", FixedColumn = FixedStyle.None, ColumnVisible = false, ColumnWith = 100, ColumnPosition = 7, Alignment = HorzAlignment.Center });
                columnsCollection.Add(new XtraColumn { ColumnName = "AccountNumber", ColumnCaption = "TK nợ", FixedColumn = FixedStyle.None, ColumnPosition = 8, ColumnVisible = false, ColumnWith = 100, Alignment = HorzAlignment.Center });
                columnsCollection.Add(new XtraColumn { ColumnName = "CorrespondingAccountNumber", ColumnCaption = "TK có", ColumnPosition = 9, FixedColumn = FixedStyle.None, ColumnVisible = false, ColumnWith = 100, Alignment = HorzAlignment.Center });
                columnsCollection.Add(new XtraColumn { ColumnName = "DocumentInclude", FixedColumn = FixedStyle.None, ColumnCaption = "Chứng từ đi kèm", ColumnPosition = 10, ColumnVisible = false, ColumnWith = 150, Alignment = HorzAlignment.Center });
                columnsCollection.Add(new XtraColumn { ColumnName = "ExchangeRate", ColumnCaption = "Tỷ giá", ColumnVisible = false });
                columnsCollection.Add(new XtraColumn { ColumnName = "Trader", ColumnVisible = false });
                foreach (var column in columnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        gridViewDetail.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        gridViewDetail.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                        gridViewDetail.Columns[column.ColumnName].Width = column.ColumnWith;
                        gridViewDetail.Columns[column.ColumnName].Fixed = column.FixedColumn;
                        gridViewDetail.Columns[column.ColumnName].ToolTip = column.ToolTip; 
                    }
                    else gridViewDetail.Columns[column.ColumnName].Visible = false;
                }
            }
        }

        /// <summary>
        /// Handles the Load event of the FrmC30BB control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FrmC30BB_Load(object sender, EventArgs e)
        {
            string postedDate = new GlobalVariable().PostedDate;
            _c30BBPresenter.Display(Convert.ToDateTime(postedDate).Year, BaseRefTypeId);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            PrintPreviewReport(this, "C30BB", false);
        }

        public void PrintPreviewReport(XtraForm frmParent, string reportID, bool isPint)
        {
            try
            {
                List<ReportListModel> reportList = _reportListPresenter.GetAllReportList();
                ReportListModel _reportListModel = reportList.Find(item => item.ReportID == reportID);
                if (_reportListModel == null) return;
              //  var reportListSource = GetDataSource(frmParent, _reportListModel);
                List<C30BBModel>lstC30BB = new List<C30BBModel>();
                for (int i = 0; i < gridViewDetail.RowCount; i++)
                {
                     var rowData = (C30BBModel)gridViewDetail.GetRow(i);
                     lstC30BB.Add(rowData);
                }
                if (lstC30BB.Count <= 0)
                {
                    XtraMessageBox.Show("Dữ liệu lấy lên báo cáo Không có bản ghi nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var reportHelper = new ReportHelper();

               // reportHelper.DisplayReport(ref lstC30BB, _reportListModel, false, frmParent, false, false, DateTime.MinValue);
                //        DisplayReport(ref reportListSource, _reportListModel, false, frmParent, false, isPint, DateTime.MinValue);
                // DisplayReport(lstC30BB, _reportListModel, false, frmParent, false, isPint, DateTime.MinValue);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //public void DisplayReport(List<C30BBModel> dataSource, ReportListModel reportList, bool isVoucher, XtraForm frmForm, bool isShowDialog, bool isPrint, DateTime voucherDate)
        //{
        //    try
        //    {
        //        Cursor.Current = Cursors.WaitCursor;
        //        if (dataSource == null) return;
        //        var commonVariable = new GlobalVariable();
        //        var str = commonVariable.ReportPath + reportList.ReportFile;
        //        ReportHelper clss = new ReportHelper();
        //        var oRsTool = clss.ReportSharpTool;
        //        oRsTool.RssObject.VoucherDate = voucherDate;
        //        oRsTool.ListDataSource = dataSource;
        //        oRsTool.DataMember = reportList.TableName.Trim();
        //        oRsTool.LayoutReportPath = commonVariable.ReportPath;
        //        oRsTool.ReportFileName = str;
        //        oRsTool.IsPrint = isPrint;
        //        oRsTool.ReportTitle = reportList.ReportName;
        //        oRsTool.ProductName = commonVariable.ProducName;
        //        oRsTool.DisplayProductName = true;

        //       //var  _frmParentForm = frmForm;
        //        var model = new Model();
        //        CurrencyModels = model.GetCurrenciesActive();
        //        NumberToWord.Currencies = new List<Currency>();
        //        foreach (var currencyModel in CurrencyModels)
        //        {
        //            NumberToWord.Currencies.Add(new Currency
        //            {
        //                CurrencyId = currencyModel.CurrencyId,
        //                CurrencyCode = currencyModel.CurrencyCode,
        //                CurrencyName = currencyModel.CurrencyName,
        //                Prefix = currencyModel.Prefix,
        //                Suffix = currencyModel.Suffix
        //            });
        //        }

        //        oRsTool.RunReport(frmForm, isShowDialog);
        //    }
        //    catch (Exception ex)
        //    {
        //        XtraMessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        Cursor.Current = Cursors.Default;
        //    }
        //}

        public List<ReportListModel> ReportLists
        {
            set { gridtemp.DataSource = value; }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TSD.AccountingSoft.Model.BusinessObjects.Cash;
using TSD.AccountingSoft.Presenter.Cash.ReceiptVoucher;
using TSD.AccountingSoft.View.Cash;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using DevExpress.Data;

namespace TSD.AccountingSoft.WindowsForm.FormBusiness
{
    public partial class FrmXtraReceiptVoucherDetail : FrmXtraBaseVoucherDetail, IReceiptVoucherView
    {
        private readonly ReceiptVoucherPresenter _receiptVoucherPresenter;

        public FrmXtraReceiptVoucherDetail()
        {
            InitializeComponent();
            _receiptVoucherPresenter = new ReceiptVoucherPresenter(this);
        }

        #region ReceiptVoucher

        /// <summary>
        /// Gets or sets the account identifier.
        /// </summary>
        /// <value>
        /// The account identifier.
        /// </value>
        public int ReceiptVoucherID { get; set; }
        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        public string Code
        {
            get { return txtRefNo.Text; }
            set { txtRefNo.Text = value; }
        }
        /// <summary>
        /// Gets or sets the reference date.
        /// </summary>
        /// <value>
        /// The reference date.
        /// </value>
        public string RefDate
        {
            get { return dtRefDate.EditValue != null ? DateTime.Parse(dtRefDate.EditValue.ToString()).ToShortDateString() : DateTime.Now.ToShortDateString(); }
            set { dtRefDate.EditValue = value.Equals("01/01/0001") ? DateTime.Now.ToShortDateString() : value; }
        }
        /// <summary>
        /// Gets or sets the create by.
        /// </summary>
        /// <value>
        /// The create by.
        /// </value>
        public string CreateBy
        {
            get { return txtContactName.Text; }
            set { txtContactName.Text = value; }
        }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description
        {
            get { return txtDescription.Text; }
            set { txtDescription.Text = value; }
        }
        /// <summary>
        /// Gets or sets the total amount.
        /// </summary>
        /// <value>
        /// The total amount.
        /// </value>
        public decimal TotalAmount
        {
            get { return (decimal)gridViewDetail.Columns["Amount"].SummaryItem.SummaryValue; }
            set { }
        }
        /// <summary>
        /// Gets or sets the receipt voucher details.
        /// </summary>
        /// <value>
        /// The receipt voucher details.
        /// </value>
        public IList<ReceiptVoucherDetailModel> ReceiptVoucherDetails
        {
            get
            {
                var receiptVoucherDetails = new List<ReceiptVoucherDetailModel>();
                if (grdDetail.DataSource != null && gridViewDetail.RowCount > 0)
                {
                    for (var i = 0; i < gridViewDetail.RowCount; i++)
                    {
                        if (gridViewDetail.GetRow(i) != null)
                        {
                            receiptVoucherDetails.Add(new ReceiptVoucherDetailModel
                            {
                                ItemName = gridViewDetail.GetRowCellValue(i, "ItemName").ToString(),
                                Quantity = (int)gridViewDetail.GetRowCellValue(i, "Quantity"),
                                Amount = (decimal)gridViewDetail.GetRowCellValue(i, "Amount")
                            });
                        }
                    }
                }
                return receiptVoucherDetails.ToList();
            }
            set
            {
                bindingSourceDetail.DataSource = value ?? new List<ReceiptVoucherDetailModel>();
                gridViewDetail.PopulateColumns(value);

                ColumnsCollection.Add(new XtraColumn { ColumnName = "ReceiptVoucherDetailID", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ReceiptVoucherID", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ItemName", ColumnCaption = "Tên TS", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 100 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Quantity", ColumnCaption = "Số lượng", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 300, ColumnType = UnboundColumnType.Integer });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Amount", ColumnCaption = "Số tiền", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 200, IsSummnary = true, ColumnType = UnboundColumnType.Decimal });
            }
        }

        #endregion

        #region Override
        /// <summary>
        /// Adds the reference no.
        /// </summary>
        protected override void AddRefNo()
        {
            txtRefNo.Text = RefNo;
        }
        /// <summary>
        /// Focuses the control.
        /// </summary>
        protected override void InitControls()
        {
            cboObjectCategory.Focus();
        }
        /// <summary>
        /// Initializes the data.
        /// </summary>
        protected override void InitData()
        {
            var receiptVoucherID = ((ReceiptVoucherModel)MasterBindingSource.Current).ReceiptVoucherID;
            KeyValue = receiptVoucherID.ToString(CultureInfo.InvariantCulture);
            _receiptVoucherPresenter.Display(receiptVoucherID);
        }

        /// <summary>
        /// Saves the data.
        /// </summary>
        /// <returns></returns>
        protected override int SaveData()
        {
            return _receiptVoucherPresenter.Save();
        }

        #endregion

        private void gridViewDetail_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            var amountCol = gridViewDetail.Columns["Amount"];
            var amount = (decimal)gridViewDetail.GetRowCellValue(e.RowHandle, amountCol);
            if (amount < 0)
            {
                e.Valid = false;
                gridViewDetail.SetColumnError(amountCol, "Không được nhập giá < 0");
            }
        }
    }
}
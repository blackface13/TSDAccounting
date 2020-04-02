/***********************************************************************
 * <copyright file="FrmXtraFixedAssetC55aHD.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThoDD
 * Email:    ThoDD@buca.vn
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
using System.Linq;
using System.Windows.Forms;
using TSD.AccountingSoft.Report.BaseParameterForm;
using TSD.AccountingSoft.Report.CommonClass;
using TSD.AccountingSoft.Session;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Presenter.Dictionary.FixedAsset;
using TSD.AccountingSoft.View.Dictionary;
using DateTimeRangeBlockDev.Helper;
using DevExpress.Utils;
using DevExpress.XtraEditors;

namespace TSD.AccountingSoft.Report.ParameterReportForm
{
    public partial class FrmXtraFixedAssetC55aHD : FrmXtraBaseParameter, IFixedAssetCategoriesView
    {
        private readonly FixedAssetCategoriesPresenter _fixedAssetCategorysPresenter;
        protected string CurrencyAccounting;
        protected string CurrencyAccountingUSD = "USD";
        public FrmXtraFixedAssetC55aHD()
        {
            InitializeComponent();
            _fixedAssetCategorysPresenter = new FixedAssetCategoriesPresenter(this);
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
        /// Gets or sets a value indicating whether this instance is total band in new page.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is total band in new page; otherwise, <c>false</c>.
        /// </value>
        public bool IsTotalBandInNewPage
        {
            get { return chkMoveTotalInNewPage.Checked; }
            set { chkMoveTotalInNewPage.Checked = value; }
        }

        public string ListFixedAssetCategoryId
        {
            get
            {
                string listKey = "";
                var list = cboFixedAssetCategory.Properties.GetItems().GetCheckedValues();
                foreach (var key in list)
                {
                    listKey = listKey + "," + key;
                }
                listKey = listKey.Remove(0, 1);
                return listKey;
            }

        }


        public string FixedAssetCategoryName
        {
            get
            {
                return cboFixedAssetCategory.Text;
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

        public IList<FixedAssetCategoryModel> FixedAssetCategories
        {
            set
            {
                if (value == null) return;
                cboFixedAssetCategory.Properties.DataSource = value.Where(x => x.IsParent == false).ToList();
                var colColection = new List<XtraColumn>();
                colColection.Clear();

                colColection.Add(new XtraColumn { ColumnName = "FixedAssetCategoryCode", ColumnCaption = "Mã kho", ToolTip = "Mã kho", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 100, Alignment = HorzAlignment.Center });
                colColection.Add(new XtraColumn { ColumnName = "FixedAssetCategoryName", ColumnCaption = "Tên kho", ToolTip = "Tên kho", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 100, Alignment = HorzAlignment.Center });
                colColection.Add(new XtraColumn { ColumnName = "FixedAssetCategoryId", ColumnCaption = "", ColumnVisible = false });
                colColection.Add(new XtraColumn { ColumnName = "IsActive", ColumnCaption = "", ColumnVisible = false });
                colColection.Add(new XtraColumn { ColumnName = "Description", ColumnCaption = "", ColumnVisible = false });
                foreach (var column in colColection)
                {
                    if (column.ColumnVisible)
                    {
                    }
                }
                cboFixedAssetCategory.Properties.DisplayMember = "FixedAssetCategoryName";
                cboFixedAssetCategory.Properties.ValueMember = "FixedAssetCategoryId";
            }
        }

        private void FrmXtraFixedAssetC55aHD_Load(object sender, EventArgs e)
        {
            _fixedAssetCategorysPresenter.Display();
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
            if (cboFixedAssetCategory.Text == "")
            {
                XtraMessageBox.Show("Bạn chưa chọn loại tài sản cố định", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboFixedAssetCategory.Focus();
                return false;
            }
            GlobalVariable.DateRangeSelectedIndex = dateTimeRangeV1.cboDateRange.SelectedIndex;
            return true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

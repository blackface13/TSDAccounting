using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Presenter.Dictionary.FixedAsset;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.Session;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList.Nodes;

namespace TSD.AccountingSoft.Report.BaseParameterForm
{
    public partial class FrmXtraBaseComboTreeMultiFixedAssetCategoryParameter : XtraForm, IFixedAssetCategoriesView
    {
        private FixedAssetCategoriesPresenter _fixedAssetCategoriesPresenter;
        public string SelectedFixedAssetCategory { get; set; }

        public string FixedAssetCategoryTitle { get; set; }

        public bool IsTotalBandInNewPage
        {
            get { return chkMoveTotalInNewPage.Checked; }
            set { chkMoveTotalInNewPage.Checked = value; }
        }

        public FrmXtraBaseComboTreeMultiFixedAssetCategoryParameter()
        {
            InitializeComponent();

        }

        public IList<FixedAssetCategoryModel> FixedAssetCategories
        {

            get { return treeListFixedAssetCategory.DataSource as List<FixedAssetCategoryModel>; }
            set
            {
                try
                {
                    if (DesignMode) return;
                    treeListFixedAssetCategory.DataSource = value ?? new List<FixedAssetCategoryModel>();
                    treeListFixedAssetCategory.BeginUpdate();
                    treeListFixedAssetCategory.PopulateColumns();
                    for (var i = 0; i < treeListFixedAssetCategory.Columns.Count; i++)
                    {
                        if (treeListFixedAssetCategory.Columns[i].FieldName != "FixedAssetCategoryName")
                        {
                            treeListFixedAssetCategory.Columns[i].Visible = false;
                        }
                    }
                    treeListFixedAssetCategory.Columns["FixedAssetCategoryName"].OptionsColumn.AllowEdit = false;
                    treeListFixedAssetCategory.Columns["FixedAssetCategoryName"].Caption = @"Tên loại TSCĐ";
                    treeListFixedAssetCategory.OptionsView.ShowHorzLines = false;
                    treeListFixedAssetCategory.OptionsView.ShowVertLines = false;
                    treeListFixedAssetCategory.ExpandAll();
                    treeListFixedAssetCategory.EndUpdate();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Thông báo lỗi",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        /// <summary>
        /// Handles the Load event of the FrmXtraBaseMultiCompanyParameter control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FrmXtraBaseComboTreeMultiFixedAssetCategoryParameter_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                var commonVariable = new GlobalVariable();
                dateTimeRangeV1.InitData(DateTime.Parse(commonVariable.PostedDate));
                dateTimeRangeV1.SetComboIndex(7);
                InitData();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is select all.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is select all; otherwise, <c>false</c>.
        /// </value>
        public bool IsSelectedAll { get; set; }

        /// <summary>
        /// Gets or sets from date.
        /// </summary>
        /// <value>
        /// From date.
        /// </value>
        public DateTime FromDate
        {
            get
            {
                return dateTimeRangeV1.FromDate;
            }
        }

        /// <summary>
        /// Gets or sets the reference date.
        /// </summary>
        /// <value>
        /// The reference date.
        /// </value>
        public DateTime ToDate
        {
            get
            {
                return dateTimeRangeV1.ToDate;
            }
        }

        protected virtual void InitData()
        {
            if (DesignMode) return;
            _fixedAssetCategoriesPresenter = new FixedAssetCategoriesPresenter(this);

            _fixedAssetCategoriesPresenter.DisplayComboCheck();
        }

        public string IterateNode(IEnumerable nodes, string columnId)
        {

            foreach (TreeListNode node in nodes)
            {

                if (node.Nodes.Count != 0)
                {
                    IterateNode(node.Nodes, columnId);
                }
                else
                {
                    if (node.Checked)
                    {
                        SelectedFixedAssetCategory = string.IsNullOrEmpty(SelectedFixedAssetCategory)
                            ? SelectedFixedAssetCategory + node.GetValue(columnId)
                            : SelectedFixedAssetCategory + "," + node.GetValue(columnId);
                    }
                }
            }

            return SelectedFixedAssetCategory;
        }

        protected virtual bool ValidData()
        {
            if (string.IsNullOrEmpty(SelectedFixedAssetCategory))
            {
                MessageBox.Show("Bạn chưa chọn loại TSCĐ", "Thiếu tham số", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                DialogResult = DialogResult.None;
                return false;
            }
            DialogResult = DialogResult.OK;
            return true;
        }

        private void popupContainerEdit_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            SelectedFixedAssetCategory = "";
            SelectedFixedAssetCategory = IterateNode(treeListFixedAssetCategory.Nodes, "FixedAssetCategoryId");
            popupContainerEdit.EditValue = SelectedFixedAssetCategory;
            DoAfterPopupClosed();
        }


        protected virtual void DoAfterPopupClosed()
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!ValidData())
            {
                btnOk.DialogResult = DialogResult.None;
                return;
            }
            DialogResult = DialogResult.OK;

            if (SelectedFixedAssetCategory == null)
                SelectedFixedAssetCategory = "";

            if (SelectedFixedAssetCategory.Contains(","))
                FixedAssetCategoryTitle = "";

            Cursor.Current = Cursors.WaitCursor;
        }
    }
}

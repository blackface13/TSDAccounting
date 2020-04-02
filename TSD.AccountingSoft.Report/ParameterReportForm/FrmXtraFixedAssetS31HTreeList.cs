using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.Report.BaseParameterForm;
using TSD.AccountingSoft.Report.CommonClass;
using TSD.AccountingSoft.Report.ReportClass;
using TSD.AccountingSoft.Session;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;

namespace TSD.AccountingSoft.Report.ParameterReportForm
{
    public partial class FrmXtraFixedAssetS31HTreeList : FrmXtraBaseComboTreeMultiFixedAssetCategoryParameter, IFixedAssetCategoriesView
    {
        public List<XtraColumn> ColumnsCollection = new List<XtraColumn>();
        internal GridCheckMarksSelection Selection { get; private set; }
        private string _lisRefID;
        private string _year;
        public GlobalVariable CommonVariable { get; set; }

        
        private readonly RepositoryItemLookUpEdit _lookUpFixedAssetCategoryEdit;

        public FrmXtraFixedAssetS31HTreeList()
        {
            InitializeComponent();
            _lookUpFixedAssetCategoryEdit = new RepositoryItemLookUpEdit();
        }

        protected override void DoAfterPopupClosed()
        {
            _lookUpFixedAssetCategoryEdit.DataSource = FixedAssetCategories;
            _lookUpFixedAssetCategoryEdit.DisplayMember = "FixedAssetCategoryName";
            _lookUpFixedAssetCategoryEdit.ValueMember = "FixedAssetCategoryCode";

            //_voucherTemplate01Tt210SPresenter.DisplayForReport(FromDate, ToDate, SelectedFixedAssetCategory);
            //LoadGridLayout();
            //Selection = new GridCheckMarksSelection(gridVoucherView);
            //Selection.CheckMarkColumn.VisibleIndex = 0;
            //Selection.CheckMarkColumn.Width = 30;
            //Selection.SelectAll();
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
    }
}

using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Presenter.Dictionary.BudgetSource;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.Report.BaseParameterForm;
using TSD.AccountingSoft.Session;
using DateTimeRangeBlockDev.Helper;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TSD.AccountingSoft.Report.ParameterReportForm
{
    public partial class FrmLedgerAccountingS104H : FrmXtraBaseParameter, IBudgetSourcesView
    {
        private BudgetSourcesPresenter _budgetSourcesPresenter;
        BindingSource bindingSource;

        public DateTime FromDate { get { return dateTimeRangeV1.FromDate; } set { dateTimeRangeV1.FromDate = value; } }
        public DateTime ToDate { get { return dateTimeRangeV1.ToDate; } set { dateTimeRangeV1.ToDate = value; } }
        public DateTime? OpenDate
        {
            get
            {
                if (dtOpenDate.EditValue == null)
                    return null;
                return dtOpenDate.DateTime;
            }
            set
            {
                dtOpenDate.EditValue = value;
            }
        }
        public string SelectedBudgetSourceCodes
        {
            get
            {
                var lstDataSources = bindingSource.DataSource as List<BudgetSourceModel> ?? null;
                if (lstDataSources != null)
                {
                    var lstIds = SelectedBudgetSourceIds.Split(',').ToList();

                    var lstCodes = lstDataSources.Where(w => w.BudgetSourceId != 0 && lstIds.Contains(w.BudgetSourceId.ToString()))?.ToList() 
                        ?? new List<BudgetSourceModel>();

                    if (string.IsNullOrEmpty(ExpenseName))
                    {
                        ExpenseName = string.Join(",", lstCodes.Select(s => s.BudgetSourceName).ToArray());
                    }
                    return string.Join(",", lstCodes.Select(s=>"'" + s.BudgetSourceCode + "'").ToArray());
                }
                return null;
            }
        }
        public string SelectedBudgetSourceIds { get; set; }
        public string ExpenseName { get; set; }

        public IList<BudgetSourceModel> SelectedBudgetSources { get; set; }

        public IList<BudgetSourceModel> BudgetSources 
        { 
            set
            {
                var lstData = new List<BudgetSourceModel>();
                if (value == null)
                    value = new List<BudgetSourceModel>();
                else
                    value = value.Where(w => !w.IsParent).ToList();

                lstData.AddRange(new List<BudgetSourceModel>()
                {
                    new BudgetSourceModel() { BudgetSourceId = 9000, BudgetSourceName = "Nguồn NSNN"},
                    new BudgetSourceModel() { BudgetSourceId = 9001, BudgetSourceName = "Nguồn tự chủ", ParentId = 9000},
                    new BudgetSourceModel() { BudgetSourceId = 9002, BudgetSourceName = "Nguồn không tự chủ", ParentId = 9000}
                });

                foreach (var item in value)
                {
                    switch(item.BudgetSourceCode)
                    {
                        case "13":
                        case "15.1":
                            item.ParentId = 9001;
                            break;
                        case "12":
                        case "15.2":
                            item.ParentId = 9002;
                            break;
                        default:
                            item.ParentId = 9000;
                            break;
                    }
                    item.BudgetSourceName = item.BudgetSourceCode + " - " + item.BudgetSourceName;
                    lstData.Add(item);
                }

                bindingSource.DataSource = lstData;
                treeListBudgetSource.PopulateColumns();
                treeListBudgetSource.ExpandAll();

                foreach (TreeListColumn note in treeListBudgetSource.Columns)
                {
                    switch(note.FieldName)
                    {
                        case "BudgetSourceName":
                            note.Caption = "Nguồn vốn";
                            note.VisibleIndex = 2;
                            break;
                        //case "BudgetSourceCode":
                        //    note.Caption = "Mã nguồn vốn";
                        //    note.VisibleIndex = 1;
                        //    break;
                        default:
                            note.Visible = false;
                            break;
                    }
                }


            }
        }

        public FrmLedgerAccountingS104H()
        {
            InitializeComponent();

            _budgetSourcesPresenter = new BudgetSourcesPresenter(this);
            bindingSource = new BindingSource();
            treeListBudgetSource.DataSource = bindingSource;

            dateTimeRangeV1.DateRangePeriodMode = DateRangeMode.Reduce;
            dateTimeRangeV1.InitSelectedIndex = GlobalVariable.DateRangeSelectedIndex;
        }

        private void FrmLedgerAccountingS104H_Load(object sender, EventArgs e)
        {
            _budgetSourcesPresenter.Display();
        }

        protected override void btnOk_Click(object sender, System.EventArgs e)
        {
            if (!ValidData())
            {
                btnOk.DialogResult = DialogResult.None;
                return;
            }
            DialogResult = DialogResult.OK;
        }

        protected override bool ValidData()
        {
            ExpenseName = "";
            SelectedBudgetSourceIds = "";
            SelectedBudgetSourceIds = IterateNode(treeListBudgetSource.Nodes, "BudgetSourceId");

            return true;
        }

        public string IterateNode(IEnumerable nodes, string columnId)
        {
            foreach (TreeListNode node in nodes)
            {

                if (node.Nodes.Count != 0)
                {
                    if (node.Checked && string.IsNullOrEmpty(ExpenseName))
                    {
                        ExpenseName = string.IsNullOrEmpty(ExpenseName)
                            ? ExpenseName + node.GetValue("BudgetSourceName")
                            : ExpenseName + "," + node.GetValue("BudgetSourceName");
                    }

                    IterateNode(node.Nodes, columnId);
                }
                else
                {
                    if (node.Checked)
                    {
                        SelectedBudgetSourceIds = string.IsNullOrEmpty(SelectedBudgetSourceIds)
                            ? SelectedBudgetSourceIds + node.GetValue(columnId)
                            : SelectedBudgetSourceIds + "," + node.GetValue(columnId);
                    }
                }
            }

            //if (!string.IsNullOrEmpty(SelectedBudgetSourceCodes))
            //{
            //    var lstDataSources = bindingSource.DataSource as List<BudgetSourceModel> ?? new List<BudgetSourceModel>();
            //    var lstIds = SelectedBudgetSourceCodes.Split(',').ToList();
            //    var lstCodes = new List<string>();
            //    foreach (var id in lstIds)
            //    {
            //        int iid = 0;
            //        if (int.TryParse(id, out iid) && iid > 0)
            //        {
            //            var budgetSource = lstDataSources.Where(w => w.BudgetSourceId == iid)?.FirstOrDefault() ?? null;
            //            if (budgetSource != null)
            //                lstCodes.Add(budgetSource.BudgetSourceCode);
            //        }
            //    }
            //    SelectedBudgetSourceCodes = string.Join(",", lstCodes.ToArray());
            //}

            return SelectedBudgetSourceIds;
        }
    }
}

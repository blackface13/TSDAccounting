/***********************************************************************
 * <copyright file="SqlServerFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Thursday, February 28, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  07/03/2014       Author    Tudt           Description: Coding standard
 * 
 * ************************************************************************/

using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TSD.AccountingSoft.Session;
using TSD.Enum;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Presenter.Dictionary.BudgetItem;
using TSD.AccountingSoft.Presenter.Dictionary.PlanTemplateList;
using TSD.AccountingSoft.Presenter.Dictionary.PlanTemplateItem;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.Resources;
using DevExpress.Data;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using System;
using DevExpress.XtraGrid.Views.Grid;
using TSD.AccountingSoft.WindowsForm.CommonClass;
using DevExpress.XtraGrid.Views.Base;

namespace TSD.AccountingSoft.WindowsForm.FormDictionary
{
    /// <summary>
    /// Class FrmXtraPlanTemplateItem.
    /// LINHMC bo sung them class CustomBudgetItemModel
    /// </summary>
    public partial class FrmXtraPlanTemplateItem : FrmXtraBaseCategoryDetail, IPlanTemplateListView, IPlanTemplateListsView, IBudgetItemsView, IPlanTemplateItemsView
    {
        #region Variables

        private readonly PlanTemplateListPresenter _planTemplateListPresenter;
        private readonly PlanTemplateListsPresenter _planTemplateListsPresenter;
        private readonly PlanTemplateItemsPresenter _planTemplateItemsPresenter;
        private readonly BudgetItemsPresenter _budgetItemsPresenter;

        private RepositoryItemGridLookUpEdit RepositoryBudgetItemId { get; set; }
        private RepositoryItemTextEdit RepositoryBudgetItemName { get; set; }
        public int IdResult = -1;
        #endregion

        #region Combobox

        public IList<PlanTemplateListModel> PlanTemplateLists
        {
            set
            {
                var planYear = Convert.ToInt16(spnPlanYear.EditValue) - 1;
                var list = value.Where(c => c.PlanYear == planYear).ToList();
                GridLookUpItem.PlanTemplateList(list, grdPlanTemplateList, grdPlanTemplateListView, "PlanTemplateListName", "PlanTemplateListId");
            }
        }
        public IList<ObjectGeneral> PlanTypes
        {
            set
            {
                GridLookUpItem.ObjectGeneral(value, cboPlanType, cboPlanTypeView);
            }
        }

        #endregion

        #region GridLayout

        public IList<PlanTemplateItemModel> PlanTemplateItems
        {
            get
            {
                var planTemplateItems = new List<PlanTemplateItemModel>();
                if (grdPlanTemplateItem.DataSource != null && gridViewDetail.RowCount > 0)
                {
                    for (var i = 0; i < gridViewDetail.RowCount; i++)
                    {
                        if (gridViewDetail.GetRow(i) != null)
                        {
                            planTemplateItems.Add(new PlanTemplateItemModel
                            {
                                BudgetItemCode = (string)gridViewDetail.GetRowCellValue(i, "BudgetItemCode"),
                                NumberOrder = (string)gridViewDetail.GetRowCellValue(i, "NumberOrder"),
                                BudgetItemName = (string)gridViewDetail.GetRowCellValue(i, "BudgetItemName"),
                                IsInserted = (bool)gridViewDetail.GetRowCellValue(i, "IsInserted") //LinhMC add
                            });
                        }
                    }
                }
                return planTemplateItems.ToList();
            }
            set
            {
                BudgetItembindingSource.DataSource = value ?? new List<PlanTemplateItemModel>();
                gridViewDetail.PopulateColumns();
                if (PlanType == 0)
                {
                    var gridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn { ColumnName = "PlanTemplateItemId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "NumberOrder", ColumnCaption = "STT", ColumnPosition = 1, ColumnVisible = false, ColumnWith = 150},
                        new XtraColumn { ColumnName = "BudgetItemCode", ColumnCaption = "Mã MLNS", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 150, RepositoryControl = RepositoryBudgetItemId},
                        new XtraColumn { ColumnName = "BudgetItemName", ColumnCaption = "Tên MLNS", ColumnPosition = 3, ColumnVisible = true,ColumnWith = 450, RepositoryControl = RepositoryBudgetItemName},
                        new XtraColumn { ColumnName = "SixMonthBeginingAutonomyBudget", ColumnVisible = false },
                        new XtraColumn { ColumnName = "SixMonthBeginingNonAutonomyBudget", ColumnVisible = false },
                        new XtraColumn { ColumnName = "TotalAmountSixMonthBegining", ColumnVisible = false },
                        new XtraColumn { ColumnName = "PlanTemplateListId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "PreviousYearOfEstimateAmount", ColumnVisible = false },
                        new XtraColumn { ColumnName = "PreviousYearOfEstimateAmountUSD", ColumnVisible = false} ,
                        new XtraColumn { ColumnName = "PreviousYearOfAutonomyBudget", ColumnVisible = false },
                        new XtraColumn { ColumnName = "PreviousYearOfNonAutonomyBudget", ColumnVisible = false },
                        new XtraColumn { ColumnName = "TotalAmountThisYear", ColumnVisible = false},
                        new XtraColumn { ColumnName = "IsInserted", ColumnVisible = false},
                        new XtraColumn { ColumnName = "ItemCodeList",ColumnVisible = false },
                        new XtraColumn { ColumnName = "FontStyle",ColumnVisible = false }
                    };
                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            gridViewDetail.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            gridViewDetail.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            gridViewDetail.Columns[column.ColumnName].Width = column.ColumnWith;
                            gridViewDetail.Columns[column.ColumnName].ColumnEdit = column.RepositoryControl;
                            gridViewDetail.Columns[column.ColumnName].OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
                        }
                        else gridViewDetail.Columns[column.ColumnName].Visible = false;
                    }
                }
                else
                {
                    var gridColumnsCollection = new List<XtraColumn>
                {
                    new XtraColumn { ColumnName = "PlanTemplateItemId", ColumnVisible = false },
                    new XtraColumn { ColumnName = "NumberOrder", ColumnCaption = "STT", ColumnPosition = 1, ColumnVisible = false, ColumnWith = 30},
                    new XtraColumn { ColumnName = "BudgetItemCode", ColumnCaption = "Mã MLNS", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 150, RepositoryControl = RepositoryBudgetItemId},
                    new XtraColumn { ColumnName = "BudgetItemName", ColumnCaption = "Tên MLNS", ColumnPosition = 3, ColumnVisible = true,ColumnWith = 450, RepositoryControl = RepositoryBudgetItemName},
                    new XtraColumn { ColumnName = "SixMonthBeginingAutonomyBudget", ColumnVisible = false },
                    new XtraColumn { ColumnName = "SixMonthBeginingNonAutonomyBudget", ColumnVisible = false },
                    new XtraColumn { ColumnName = "TotalAmountSixMonthBegining", ColumnVisible = false },
                    new XtraColumn { ColumnName = "PlanTemplateListId", ColumnVisible = false },
                    new XtraColumn { ColumnName = "PreviousYearOfEstimateAmount", ColumnVisible = false },
                    new XtraColumn { ColumnName = "PreviousYearOfEstimateAmountUSD", ColumnVisible = false} ,
                    new XtraColumn { ColumnName = "PreviousYearOfAutonomyBudget", ColumnVisible = false },
                    new XtraColumn { ColumnName = "PreviousYearOfNonAutonomyBudget", ColumnVisible = false },
                    new XtraColumn { ColumnName = "TotalAmountThisYear", ColumnVisible = false},
                    new XtraColumn { ColumnName = "IsInserted", ColumnVisible = false},
                    new XtraColumn { ColumnName = "ItemCodeList",ColumnVisible = false },
                    new XtraColumn { ColumnName = "FontStyle",ColumnVisible = false }
                };
                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            gridViewDetail.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            gridViewDetail.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            gridViewDetail.Columns[column.ColumnName].Width = column.ColumnWith;
                            gridViewDetail.Columns[column.ColumnName].ColumnEdit = column.RepositoryControl;
                            gridViewDetail.Columns[column.ColumnName].OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
                        }
                        else gridViewDetail.Columns[column.ColumnName].Visible = false;
                    }
                }
                gridViewDetail.Columns["BudgetItemCode"].SortOrder = ColumnSortOrder.Ascending;
            }
        }
        public IList<BudgetItemModel> BudgetItems
        {
            set
            {
                if(PlanType == 0)
                    value = value.Where(w => w.BudgetItemCode == "3350" || w.BudgetItemCode == "3851" || w.BudgetItemCode == "4949").ToList();
                GridLookUpItem.BudgetItem(value ?? new List<BudgetItemModel>(), RepositoryBudgetItemId, "BudgetItemCode", "BudgetItemCode");
            }
        }

        #endregion

        #region Members

        public int PlanTemplateListId { get; set; }
        public string PlanTemplateListCode
        {
            get
            {
                return txtPlanTemplateItemCode.Text;
            }
            set
            {
                txtPlanTemplateItemCode.Text = value;
            }
        }
        public string PlanTemplateListName
        {
            get
            {
                return txtPlanTemplateItemName.Text;
            }
            set
            {
                txtPlanTemplateItemName.Text = value;
            }
        }
        public short PlanYear
        {
            get
            {
                return (short)spnPlanYear.Value;
            }
            set
            {
                spnPlanYear.Value = value;
            }
        }
        public short PlanType
        {
            get
            {
                return Convert.ToInt16(cboPlanType.EditValue);
            }
            set
            {
                cboPlanType.EditValue = value;
            }
        }
        public int? ParentId
        {
            get
            {
                if (grdPlanTemplateList.EditValue == null) return null;
                return (int?)grdPlanTemplateList.EditValue;//.GetColumnValue("PlanTemplateListId");
            }
            set
            {
                grdPlanTemplateList.EditValue = value;
            }
        }

        #endregion

        #region Override Functions

        protected override void InitData()
        {
            PlanTypes = new ObjectGeneral().GetPlanTypes();
            // get plan template lists
            if (PlanType == 0)
                _planTemplateListsPresenter.DisplayByReceipt();
            else
                _planTemplateListsPresenter.DisplayByPayment();

            // get budget item lists
            if (PlanType == 0)
                _budgetItemsPresenter.DisplayActive(); //.DisplayIsReceiptForEstimate();
            else
                _budgetItemsPresenter.DisplayIsPaymentForEstimate();

            // get plan template list by keyvalue
            if (KeyValue != null)
                _planTemplateListPresenter.Display(KeyValue);
            else
                PlanTemplateItems = new List<PlanTemplateItemModel>();

            //get init checked and plan template list name
            if (ParentId == null)
            {
                chkCheck.Checked = false;
                grdPlanTemplateList.Enabled = false;
            }
            else
                chkCheck.Checked = true;

            //LINHMC - 20/8/2015
            //Nếu mẫu chứng từ đã tồn tại, không cho bố con thằng nào sửa những cái không được sửa
            var isExisted = _planTemplateItemsPresenter.CheckConstraintData(PlanTemplateListId);
            txtPlanTemplateItemCode.Enabled = !isExisted;
            cboPlanType.Enabled = !isExisted;
            spnPlanYear.Enabled = !isExisted;
            grdPlanTemplateList.Enabled = !isExisted;
            gridViewDetail.OptionsBehavior.Editable = !isExisted;
            barButtonDeleteRowItem.Enabled = !isExisted;
            grdPlanTemplateList.Enabled = chkCheck.Checked;
            if (PlanType == 0)
            {
                chkCheck.Enabled = false;
                grdPlanTemplateList.Enabled = false;
            }
            else
                chkCheck.Enabled = !isExisted;
        }

        protected override void InitControls()
        {

            txtPlanTemplateItemCode.Focus();
            RepositoryBudgetItemId = new RepositoryItemGridLookUpEdit();
            RepositoryBudgetItemName = new RepositoryItemTextEdit();
            grdPlanTemplateItem.ForceInitialize();
            //RepositoryBudgetItemId.PopupWidth = 520;
            RepositoryBudgetItemId.NullText = ResourceHelper.GetResourceValueByName("ResRepositoryControlBudgetItemID");
            RepositoryBudgetItemId.EditValueChanged += RepositoryBudgetItemId_EditValueChanged;
            spnPlanYear.Value = DateTime.Parse(new GlobalVariable().PostedDate).Year + 1;
            if (ActionMode == ActionModeEnum.AddNew)
                txtPlanTemplateItemName.Text = cboPlanType.Text + @" năm " + spnPlanYear.Value;
        }

        protected override int SaveData()
        {
            IdResult = _planTemplateListPresenter.Save();
            return IdResult;
        }

        protected override bool ValidData()
        {
            if (string.IsNullOrEmpty(PlanTemplateListCode))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResPlanTemplateListCode"),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPlanTemplateItemCode.Focus();
                return false;
            }
            if (PlanTemplateListId == ParentId)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResPlanTemplateListParentID"),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                grdPlanTemplateList.Focus();
                return false;
            }
            if (PlanTemplateItems.Count <= 1) return true;
            var samePayItem = true;
            for (var i = 0; i < PlanTemplateItems.Count; i++)
            {
                for (var j = i + 1; j < PlanTemplateItems.Count; j++)
                {
                    if (PlanTemplateItems[i].BudgetItemCode != PlanTemplateItems[j].BudgetItemCode)
                        samePayItem = false;
                    else
                    {
                        samePayItem = true;
                        break;
                    }
                }
                if (!samePayItem) continue;
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResBudgetItemCodeSame"),
                                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        #endregion

        #region Events

        public FrmXtraPlanTemplateItem()
        {
            InitializeComponent();
            _planTemplateListPresenter = new PlanTemplateListPresenter(this);
            _budgetItemsPresenter = new BudgetItemsPresenter(this);
            _planTemplateListsPresenter = new PlanTemplateListsPresenter(this);
            _planTemplateItemsPresenter = new PlanTemplateItemsPresenter(this);

            this.gridViewDetail.FocusedRowChanged += gridViewDetail_FocusedRowChanged;
            this.gridViewDetail.FocusedColumnChanged += gridViewDetail_FocusedColumnChanged;
        }

        private void chkCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCheck.Checked) grdPlanTemplateList.Enabled = true;
            else
            {
                grdPlanTemplateList.Enabled = false;
                grdPlanTemplateList.EditValue = null;
            }
        }

        private void cboPlanType_EditValueChanged(object sender, EventArgs e)
        {
            if (cboPlanType.Text != "")
                txtPlanTemplateItemName.Text = cboPlanType.Text + @" năm " + spnPlanYear.Value;
            if (PlanType == 0)
            {
                _budgetItemsPresenter.DisplayActive();//.DisplayIsReceiptForEstimate();
                _planTemplateListsPresenter.DisplayByReceipt();
                PlanTemplateItems = new List<PlanTemplateItemModel>();
                chkCheck.Enabled = false;
                grdPlanTemplateList.Enabled = false;
            }
            else
            {
                _budgetItemsPresenter.DisplayIsPaymentForEstimate();
                _planTemplateListsPresenter.DisplayByPayment();
                PlanTemplateItems = new List<PlanTemplateItemModel>();
                chkCheck.Enabled = true;
            }
        }

        private void spnPlanYear_EditValueChanged(object sender, EventArgs e)
        {
            if (cboPlanType.Text != "")
                txtPlanTemplateItemName.Text = cboPlanType.Text + @" năm " + spnPlanYear.Value;
            if (PlanType == 0)
            {
                _budgetItemsPresenter.DisplayIsReceiptForEstimate();
                _planTemplateListsPresenter.DisplayByReceipt();
            }
            else
            {
                _budgetItemsPresenter.DisplayIsPaymentForEstimate();
                _planTemplateListsPresenter.DisplayByPayment();
            }
        }

        private void RepositoryBudgetItemId_EditValueChanged(object sender, EventArgs e)
        {
            var grlBudgetItem = (GridLookUpEdit)gridViewDetail.ActiveEditor;
            var selectBudgetItem = grlBudgetItem.EditValue == null ? null : RepositoryBudgetItemId.GetRowByKeyValue(grlBudgetItem.EditValue) as BudgetItemModel;
            if (selectBudgetItem != null) gridViewDetail.SetRowCellValue(gridViewDetail.FocusedRowHandle, gridViewDetail.Columns["BudgetItemName"], selectBudgetItem.BudgetItemName);
        }

        private void btnGetBudgetItemList_Click(object sender, EventArgs e)
        {
            var frm = new FrmXtraGetBudgetItemList
            {
                IsReceipt = PlanType,
                FirstPlanTemplateItem = PlanTemplateItems
            };
            frm.GetBudgetItemLists += GetFirstValue;
            frm.ShowDialog();
        }

        public void GetFirstValue(IList<CustomBudgetItemModel> budgetItemList)
        {
            BudgetItembindingSource.DataSource = budgetItemList;
        }

        private void gridViewDetail_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void grdPlanTemplateList_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdPlanTemplateList.SelectionLength == grdPlanTemplateList.Text.Length && (e.KeyData == Keys.Back || e.KeyData == Keys.Delete))
            {
                grdPlanTemplateList.EditValue = null;
                e.Handled = true;
            }
        }

        private void grdPlanTemplateList_Closed(object sender, ClosedEventArgs e)
        {
            if (!ReferenceEquals(grdPlanTemplateList.EditValue, "") && !ReferenceEquals(grdPlanTemplateList.EditValue, null))
            {
                var item = grdPlanTemplateList.EditValue.ToString();
                _planTemplateItemsPresenter.DisplayByPlanTemplateListId(int.Parse(item));
            }
            else
            {
                if (ActionMode == ActionModeEnum.AddNew)
                    PlanTemplateItems = new List<PlanTemplateItemModel>();
            }
        }

        private void gridViewDetail_FocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e)
        {
            try
            {
                if (gridViewDetail.FocusedColumn.RealColumnEdit is RepositoryItemGridLookUpEdit)
                {
                    gridViewDetail.ShowEditor();
                    GridLookUpEdit edit = gridViewDetail.ActiveEditor as GridLookUpEdit;
                    edit.ShowPopup();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void gridViewDetail_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            try
            {
                if (gridViewDetail.FocusedColumn.RealColumnEdit is RepositoryItemGridLookUpEdit)
                {
                    gridViewDetail.ShowEditor();
                    GridLookUpEdit edit = gridViewDetail.ActiveEditor as GridLookUpEdit;
                    edit.ShowPopup();
                }
            }
            catch (Exception ex)
            {

            }
        }

        #endregion

        #region Popup menu event

        private void gridViewDetail_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            var view = sender as GridView;
            if (view != null)
            {
                var hitInfo = view.CalcHitInfo(e.Point);
                if (hitInfo.InRow)
                {
                    view.FocusedRowHandle = hitInfo.RowHandle;
                    popupMenu1.ShowPopup(grdPlanTemplateItem.PointToScreen(e.Point));
                }
            }
        }

        protected virtual void DeleteRowItem()
        {
            gridViewDetail.DeleteSelectedRows();
        }

        private void barButtonDeleteRowItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            DeleteRowItem();
        }

        #endregion

    }
}
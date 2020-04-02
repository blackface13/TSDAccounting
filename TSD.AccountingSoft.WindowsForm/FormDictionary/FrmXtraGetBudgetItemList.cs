/***********************************************************************
 * <copyright file="SqlServerFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Thursday, February 26, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  07/03/2014       Author    Tudt           Description: Coding standard
 * 
 * ************************************************************************/


using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors.Repository;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.Presenter.Dictionary.BudgetItem;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;


namespace TSD.AccountingSoft.WindowsForm.FormDictionary
{
    /// <summary>
    /// Class FrmXtraGetBudgetItemList.
    /// </summary>
    public partial class FrmXtraGetBudgetItemList : FrmXtraBaseCategoryDetail, IBudgetItemsView
    {
        #region variables

        /// <summary>
        /// The _budget items presenter
        /// </summary>
        private readonly BudgetItemsPresenter _budgetItemsPresenter;

        /// <summary>
        /// The is receipt
        /// </summary>
        public int IsReceipt;

        /// <summary>
        /// The b
        /// </summary>
        public List<CustomBudgetItemModel> NewBudgetItemLists = new List<CustomBudgetItemModel>();

        /// <summary>
        /// The first plan template item
        /// </summary>
        public IList<PlanTemplateItemModel> FirstPlanTemplateItem;

        /// <summary>
        /// The firt budget item lists
        /// </summary>
        public IList<BudgetItemModel> FirstBudgetItemLists;

        /// <summary>
        /// Gets or sets the repository item check edit.
        /// </summary>
        /// <value>The repository item check edit.</value>
        private RepositoryItemCheckEdit RepositoryItemCheckEdit { get; set; }

        #endregion

        #region IBudgetItemView Member

        /// <summary>
        /// Sets the BudgetItems.
        /// </summary>
        /// <value>The BudgetItems.</value>
        public IList<BudgetItemModel> BudgetItems
        {
            get
            {
                var budgetItems = new List<BudgetItemModel>();
                if (treeList.DataSource != null && treeList.Nodes.Count > 0)
                {
                    for (var i = 0; i < treeList.VisibleNodesCount; i++)
                    {
                        if (treeList.Nodes[i] != null)
                        {
                            budgetItems.Add(new BudgetItemModel
                            {
                                BudgetItemId = (int)treeList.Nodes[i][treeList.Columns["BudgetItemId"]],
                                BudgetItemCode = (string)treeList.Nodes[i][treeList.Columns["BudgetItemCode"]],
                                BudgetItemName = (string)treeList.Nodes[i][treeList.Columns["BudgetItemName"]]
                            });
                        }
                    }
                }
                return budgetItems.ToList();
            }
            set
            {
                if (FirstPlanTemplateItem != null)
                {
                    foreach (var item in FirstPlanTemplateItem)
                    {
                        value.Remove(value.SingleOrDefault(x => x.BudgetItemCode == item.BudgetItemCode));
                    }
                }

                var budgetItemId = new List<BudgetItemModel>();

                if (value != null)
                {
                    if (IsReceipt == 1)
                    {
                        budgetItemId = (from budgetItem in value where !budgetItem.BudgetItemCode.StartsWith("91") select budgetItem).ToList();
                        bindingSourceList.DataSource = budgetItemId;
                    }
                    else
                    {
                        budgetItemId = value.Where(w => w.BudgetItemCode == "3350" || w.BudgetItemCode == "3851" || w.BudgetItemCode == "4949").ToList();
                        bindingSourceList.DataSource = budgetItemId;
                    }
                }
                else
                    bindingSourceList.DataSource = new List<BudgetItemModel>();

                treeList.BeginUpdate();
                treeList.PopulateColumns();
                if (IsReceipt == 0)
                {
                    var gridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn { ColumnName = "NumberOrder", ColumnCaption = "STT", ColumnPosition = 1, ColumnVisible = false, ColumnWith = 50},
                        new XtraColumn { ColumnName = "BudgetItemCode", ColumnCaption = "Mã MLNS", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 150},
                        new XtraColumn { ColumnName = "BudgetItemName", ColumnCaption = "Tên MLNS", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 450},
                        new XtraColumn { ColumnName = "ForeignName",ColumnCaption = "Tên nước ngoài", ColumnVisible = false },
                        new XtraColumn { ColumnName = "BudgetItemType", ColumnCaption = "Thuộc loại", ColumnVisible = false },
                        new XtraColumn { ColumnName = "BudgetGroupId", ColumnCaption = "Nhóm", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsReceipt", ColumnCaption = "Loại",ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsFixedItem", ColumnCaption = "Là mục khoán chi", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsExpandItem", ColumnCaption = "Là mục mở rộng không thuộc MLNS  do Bộ tài chính ban hành", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsNoAllocate", ColumnCaption = "Là chi phí không tính vào giá trị phân bổ", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsOrganItem", ColumnCaption = "Là mục thu phân phối cho quỹ cơ quan", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsSystem", ColumnCaption = "Là mục hệ thống", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsParent", ColumnCaption = "Là chi tiết", ColumnVisible = false },
                        new XtraColumn { ColumnName = "Grade", ColumnCaption = "Bậc", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsActive", ColumnCaption = "Được sử dụng", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsChoose",ColumnVisible = false },
                        new XtraColumn { ColumnName = "Rate",ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsShowOnVoucher", ColumnVisible = false }
                    };
                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            treeList.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            treeList.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            treeList.Columns[column.ColumnName].Width = column.ColumnWith;
                            treeList.Columns[column.ColumnName].ColumnEdit = column.RepositoryControl;
                        }
                        else
                        {
                            treeList.Columns[column.ColumnName].Visible = false;
                        }
                    }
                }
                else
                {
                    var gridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn { ColumnName = "BudgetItemCode", ColumnCaption = "Mã MLNS", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 150},
                        new XtraColumn { ColumnName = "BudgetItemName", ColumnCaption = "Tên MLNS", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 450},
                        new XtraColumn { ColumnName = "ForeignName",ColumnCaption = "Tên nước ngoài", ColumnVisible = false },
                        new XtraColumn { ColumnName = "BudgetItemType", ColumnCaption = "Thuộc loại", ColumnVisible = false },
                        new XtraColumn { ColumnName = "BudgetGroupId", ColumnCaption = "Nhóm", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsReceipt", ColumnCaption = "Loại",ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsFixedItem", ColumnCaption = "Là mục khoán chi", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsExpandItem", ColumnCaption = "Là mục mở rộng không thuộc MLNS  do Bộ tài chính ban hành", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsNoAllocate", ColumnCaption = "Là chi phí không tính vào giá trị phân bổ", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsOrganItem", ColumnCaption = "Là mục thu phân phối cho quỹ cơ quan", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsSystem", ColumnCaption = "Là mục hệ thống", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsParent", ColumnCaption = "Là chi tiết", ColumnVisible = false },
                        new XtraColumn { ColumnName = "Grade", ColumnCaption = "Bậc", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsActive", ColumnCaption = "Được sử dụng", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsChoose",ColumnVisible = false },
                        new XtraColumn { ColumnName = "Rate",ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsShowOnVoucher", ColumnVisible = false },
                        new XtraColumn { ColumnName = "NumberOrder", ColumnVisible = false }
                    };
                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            treeList.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            treeList.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            treeList.Columns[column.ColumnName].Width = column.ColumnWith;
                            treeList.Columns[column.ColumnName].ColumnEdit = column.RepositoryControl;
                        }
                        else
                        {
                            treeList.Columns[column.ColumnName].Visible = false;
                        }
                    }
                }

                treeList.ExpandAll();
                treeList.EndUpdate();
            }
        }

        #endregion

        #region Form event

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmXtraGetBudgetItemList"/> class.
        /// </summary>
        public FrmXtraGetBudgetItemList()
        {
            InitializeComponent();
            _budgetItemsPresenter = new BudgetItemsPresenter(this);
        }

        /// <summary>
        /// Initializes the data.
        /// </summary>
        protected override void InitData()
        {
            if (IsReceipt == 0)
            {
                _budgetItemsPresenter.DisplayActive(); //.DisplayIsReceiptForEstimate();
            }
            else { _budgetItemsPresenter.DisplayIsPaymentForEstimate(); }
        }

        /// <summary>
        /// Focuses the control.
        /// </summary>
        protected override void InitControls()
        {
            RepositoryItemCheckEdit = new RepositoryItemCheckEdit();
            treeList.ForceInitialize();
            treeList.ParentFieldName = "ParentId";
            treeList.KeyFieldName = "BudgetItemId";
        }

        #endregion

        #region Delegate event

        /// <summary>
        /// Delegate GetBudgetItemList
        /// </summary>
        /// <param name="budgetItemModels">The key value.</param>
        public delegate void GetBudgetItemList(IList<CustomBudgetItemModel> budgetItemModels);

        /// <summary>
        /// The key value
        /// </summary>
        public event GetBudgetItemList GetBudgetItemLists;

        #endregion

        #region Control event

        /// <summary>
        /// Handles the Click event of the btnOK control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (treeList.DataSource != null && treeList.Nodes.Count > 0)
            {
                for (var i = 0; i < treeList.VisibleNodesCount; i++)
                {
                    var node = treeList.GetNodeByVisibleIndex(i);
                    if (IsReceipt == 0)
                    {
                        if (node.CheckState == CheckState.Checked)
                        {
                            NewBudgetItemLists.Add(new CustomBudgetItemModel
                            {
                                BudgetItemId = (int)node[treeList.KeyFieldName],
                                BudgetItemCode = (string)node["BudgetItemCode"],
                                NumberOrder = (string)node["NumberOrder"],
                                BudgetItemName = (string)node["BudgetItemName"],
                                IsInserted = true
                            });
                        }
                    }
                    else
                    {
                        if (node.HasChildren == false && node.CheckState == CheckState.Checked)
                        {
                            NewBudgetItemLists.Add(new CustomBudgetItemModel
                            {
                                BudgetItemId = (int)node[treeList.KeyFieldName],
                                BudgetItemCode = (string)node["BudgetItemCode"],
                                NumberOrder = (string)node["NumberOrder"],
                                BudgetItemName = (string)node["BudgetItemName"],
                                IsInserted = true
                            });
                        }
                    }

                }
            }
            if (FirstPlanTemplateItem != null)
            {
                foreach (var items in FirstPlanTemplateItem)
                {
                    NewBudgetItemLists.Add(new CustomBudgetItemModel
                    {
                        BudgetItemCode = items.BudgetItemCode,
                        NumberOrder = items.NumberOrder,
                        BudgetItemName = items.BudgetItemName,
                    });
                }
            }
            GetBudgetItemLists(NewBudgetItemLists);
            Hide();
        }

        #endregion

        /// <summary>
        /// Handles the Click event of the btnSelectAll control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            if (treeList.DataSource != null && treeList.Nodes.Count > 0)
            {
                treeList.CheckAll();
            }
        }

        /// <summary>
        /// Handles the Click event of the btnUnSellectAll control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnUnSellectAll_Click(object sender, EventArgs e)
        {
            if (treeList.DataSource != null && treeList.Nodes.Count > 0)
            {
                treeList.UncheckAll();
            }
        }

        /// <summary>
        /// Handles the 1 event of the treeList_NodeCellStyle control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs"/> instance containing the event data.</param>
        private void treeList_NodeCellStyle_1(object sender, DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs e)
        {
            e.Appearance.Font = Convert.ToBoolean(e.Node["IsParent"]) ? new Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, FontStyle.Bold) : new Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, FontStyle.Regular);
        }

        /// <summary>
        /// Handles the 1 event of the treeList_CustomDrawNodeCell control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DevExpress.XtraTreeList.CustomDrawNodeCellEventArgs"/> instance containing the event data.</param>
        private void treeList_CustomDrawNodeCell_1(object sender, DevExpress.XtraTreeList.CustomDrawNodeCellEventArgs e)
        {
            if (!(e.CellValue is decimal)) return;
            if ((decimal)e.CellValue != 0) return;
            e.Appearance.FillRectangle(e.Cache, e.Bounds);
            e.Handled = true;
        }

    }

    //LINHMC ADD
    public class CustomBudgetItemModel
    {
        /// <summary>
        /// Gets or sets the budget item identifier.
        /// </summary>
        /// <value>The budget item identifier.</value>
        public int BudgetItemId { get; set; }

        /// <summary>
        /// Gets or sets the budget group identifier.
        /// </summary>
        /// <value>The budget group identifier.</value>
        public int? BudgetGroupId { get; set; }

        /// <summary>
        /// Gets or sets the budget item code.
        /// </summary>
        /// <value>The budget item code.</value>
        public string BudgetItemCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the budget item.
        /// </summary>
        /// <value>The name of the budget item.</value>
        public string BudgetItemName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is inserted.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is inserted; otherwise, <c>false</c>.
        /// </value>
        public bool IsInserted { get; set; }

        /// <summary>
        /// Gets or sets the number order.
        /// </summary>
        /// <value>
        /// The number order.
        /// </value>
        public string NumberOrder { get; set; }
    }
}

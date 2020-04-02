/***********************************************************************
 * <copyright file="UserControlCapitalAllocateList.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuanHM
 * Email:    Tuanhm@buca.vn
 * Website:
 * Create Date: Tuesday, March 11, 2014 
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using System.Linq;
using TSD.AccountingSoft.Presenter.Dictionary.CapitalAllocate;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.WindowsForm.BaseUserControls;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.FormDictionary;
using DevExpress.XtraEditors.Repository;


namespace TSD.AccountingSoft.WindowsForm.UserControl.Dictionary
{
    /// <summary>
    /// Class UserControlCapitalAllocateList.
    /// </summary>
    public partial class UserControlCapitalAllocateList : BaseListUserControl, ICapitalAllocatesView, IBudgetItemsView, IBudgetSourcesView 
    {
        private readonly CapitalAllocatesPresenter _capitalAllocatesPresenter;

        #region Repository Controls

        private RepositoryItemLookUpEdit RepositoryBudgetSourceId { get; set; }

        private RepositoryItemLookUpEdit RepositoryBudgetItemId { get; set; }
        #endregion

        /// <summary>
        /// Focuses the control.
        /// </summary>
        protected  void InitControls()
        {
            RepositoryBudgetSourceId = new RepositoryItemLookUpEdit {PopupWidth = 520, NullText = ""};
            RepositoryBudgetItemId = new RepositoryItemLookUpEdit {PopupWidth = 520, NullText = ""};
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserControlCapitalAllocateList"/> class.
        /// </summary>
        public UserControlCapitalAllocateList() 
        {
            InitializeComponent();
            InitControls();
            _capitalAllocatesPresenter = new CapitalAllocatesPresenter(this);
        }

        /// <summary>
        /// Loads the data into grid.
        /// </summary>
        protected override void LoadDataIntoGrid()
        {
            _capitalAllocatesPresenter.Display();
        }

        /// <summary>
        /// Deletes the grid.
        /// </summary>
        protected override void DeleteGrid()
        {
            new CapitalAllocatePresenter(null).Delete(int.Parse(PrimaryKeyValue));
        }

        /// <summary>
        /// Gets the form detail.
        /// </summary>
        /// <returns></returns>
        protected override FrmXtraBaseCategoryDetail GetFormDetail()
        {
            return new FrmXtraCapitalAllocateDetail();
        }

        /// <summary>
        /// Sets the capital allocates.
        /// </summary>
        /// <value>The capital allocates.</value>
        public IList<Model.BusinessObjects.Dictionary.CapitalAllocateModel> CapitalAllocates
        {
            set
            {
                ListBindingSource.DataSource = value;
                gridView.PopulateColumns(value);
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CapitalAllocateCode", ColumnCaption = "Mã phân bổ", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 100 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemCode", ColumnCaption = "Khoản thu", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 70 });//, RepositoryControl = RepositoryBudgetItemId 
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceCode", ColumnCaption = "Quỹ", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 70 });//, RepositoryControl = RepositoryBudgetSourceId 
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnCaption = "Diễn giải", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 250 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "FromDate", ColumnCaption = "Từ ngày", ColumnPosition = 5, ColumnVisible = true, ColumnWith = 65 });//, RepositoryControl = RepositoryBudgetItemId 
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ToDate", ColumnCaption = "Đến ngày", ColumnPosition = 6, ColumnVisible = true, ColumnWith = 65 });//, RepositoryControl = RepositoryBudgetSourceId 
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false, ColumnPosition = 7 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "WaitBudgetSourceCode", ColumnVisible = false, ColumnPosition = 8 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CapitalAccountCode", ColumnVisible = false, ColumnPosition = 9 });  //CapitalAllocateCode
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ExpenseAccountCode", ColumnVisible = false, ColumnPosition = 10 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RevenueAccountCode", ColumnVisible = false, ColumnPosition = 12 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DeterminedDate", ColumnVisible = false, ColumnPosition = 13 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AllocateType", ColumnVisible = false, ColumnPosition = 14 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AllocatePercent", ColumnVisible = false, ColumnPosition = 15 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ActivityId", ColumnVisible = false, ColumnPosition = 16 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CapitalAllocateId", ColumnVisible = false, ColumnPosition = 17 });
                gridView.BestFitColumns();
            }
        }

        /// <summary>
        /// Sets the budget sources.
        /// </summary>
        /// <value>The budget sources.</value>
        public IList<Model.BusinessObjects.Dictionary.BudgetSourceModel> BudgetSources
        {
            set
            {
                if (value == null) return;
                RepositoryBudgetSourceId.DataSource = value;
                RepositoryBudgetSourceId.PopulateColumns();
               
                var gridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn { ColumnName = "BudgetSourceId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "BudgetSourceCode", ColumnCaption = "Mã nguồn vốn", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 120 },
                        new XtraColumn { ColumnName = "BudgetSourceName", ColumnCaption = "Tên nguồn vốn", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 330 },
                        new XtraColumn { ColumnName = "Description", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsActive", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false},
                        new XtraColumn { ColumnName = "ForeignName", ColumnVisible = false},
                        new XtraColumn { ColumnName = "IsParent", ColumnVisible = false},
                        new XtraColumn { ColumnName = "Grade", ColumnVisible = false},
                        new XtraColumn { ColumnName = "Type", ColumnVisible = false},
                        new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false},
                        new XtraColumn { ColumnName = "Allocation", ColumnVisible = false},
                        new XtraColumn { ColumnName = "BudgetItemId", ColumnVisible = false},
                        new XtraColumn { ColumnName = "IsFund", ColumnVisible = false},
                        new XtraColumn { ColumnName = "IsExpense", ColumnVisible = false},
                        new XtraColumn { ColumnName = "AccountId", ColumnVisible = false},
                        new XtraColumn { ColumnName = "ParentId", ColumnVisible = false},
                    };
                foreach (var column in gridColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        RepositoryBudgetSourceId.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        RepositoryBudgetSourceId.SortColumnIndex = column.ColumnPosition;
                        RepositoryBudgetSourceId.Columns[column.ColumnName].Width = column.ColumnWith;                      
                    }
                    else
                    {
                        RepositoryBudgetSourceId.Columns[column.ColumnName].Visible = false;
                    
                    }
                }
                RepositoryBudgetSourceId.DisplayMember = "BudgetSourceCode";
                RepositoryBudgetSourceId.ValueMember = "BudgetSourceId";    
            }
        }

        /// <summary>
        /// Sets the BudgetItems.
        /// </summary>
        /// <value>The BudgetItems.</value>
        public IList<Model.BusinessObjects.Dictionary.BudgetItemModel> BudgetItems
        {
            set
            { 
                var budgetGroupId = value == null ? null : (from budgetItem in value where budgetItem.BudgetItemType == 1 || budgetItem.BudgetItemType == 2 select new { budgetItem.BudgetItemId, budgetItem.BudgetItemCode, budgetItem.BudgetItemName }).ToList();
                var budgetItemId = value == null ? null : (from budgetItem in value where budgetItem.BudgetItemType == 3 || budgetItem.BudgetItemType == 4 select new { budgetItem.BudgetItemId, budgetItem.BudgetItemCode, budgetItem.BudgetItemName }).ToList();

                RepositoryBudgetItemId.DataSource = budgetGroupId; 
                RepositoryBudgetItemId.PopulateColumns();
                var gridgridColumnsCollection = new List<XtraColumn> { 
                                                new XtraColumn { ColumnName = "BudgetItemId", ColumnVisible = false }, 
                                                new XtraColumn { ColumnName = "BudgetItemCode", ColumnCaption = "Mã nhóm/ tiểu nhóm", ColumnPosition = 1, ColumnVisible = true, ColumnWith =  120 }, 
                                                new XtraColumn { ColumnName = "BudgetItemName", ColumnCaption = "Tên nhóm/ tiểu nhóm", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 330 }
                                            };
                foreach (var column in gridgridColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        RepositoryBudgetItemId.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        RepositoryBudgetItemId.SortColumnIndex = column.ColumnPosition;
                        RepositoryBudgetItemId.Columns[column.ColumnName].Width = column.ColumnWith;
                    }
                    else { RepositoryBudgetItemId.Columns[column.ColumnName].Visible = false; }
                }
                RepositoryBudgetItemId.DisplayMember = "BudgetItemCode";
                RepositoryBudgetItemId.ValueMember = "BudgetItemId";

                RepositoryBudgetItemId.DataSource = budgetItemId; 
                RepositoryBudgetItemId.PopulateColumns();
                gridgridColumnsCollection = new List<XtraColumn> {  
                                                new XtraColumn { ColumnName = "BudgetItemId", ColumnVisible = false }, 
                                                new XtraColumn { ColumnName = "BudgetItemCode", ColumnCaption = "Mã mục/ tiểu mục", ColumnPosition = 1, ColumnVisible = true, ColumnWith =  120 }, 
                                                new XtraColumn { ColumnName = "BudgetItemName", ColumnCaption = "Tên mục/ tiểu mục", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 330 }
                                            };
                foreach (var column in gridgridColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        RepositoryBudgetItemId.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        RepositoryBudgetItemId.SortColumnIndex = column.ColumnPosition;
                        RepositoryBudgetItemId.Columns[column.ColumnName].Width = column.ColumnWith;
                    }
                    else { RepositoryBudgetItemId.Columns[column.ColumnName].Visible = false; }
                }
                RepositoryBudgetItemId.DisplayMember = "BudgetItemCode";
                RepositoryBudgetItemId.ValueMember = "BudgetItemId";
            }
        }
    }
}

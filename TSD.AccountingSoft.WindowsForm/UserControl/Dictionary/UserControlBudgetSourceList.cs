/***********************************************************************
 * <copyright file="UserControlBudgetSourceList.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   THODD
 * Email:    thodd@buca.vn
 * Website:
 * Create Date: 13 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Drawing;
using TSD.AccountingSoft.Presenter.Dictionary.BudgetSource;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.WindowsForm.BaseUserControls;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.FormDictionary;
using DevExpress.Utils;


namespace TSD.AccountingSoft.WindowsForm.UserControl.Dictionary
{
    /// <summary>
    /// Class UserControlBudgetSourceList.
    /// </summary>
    public partial class UserControlBudgetSourceList : BaseTreeListUserControl, IBudgetSourcesView
    {
        /// <summary>
        /// The _budgetSources presenter
        /// </summary>
        private readonly BudgetSourcesPresenter _budgetSourcesPresenter;
        /// <summary>
        /// Initializes a new instance of the <see cref="UserControlBudgetSourceList"/> class.
        /// </summary>
        public UserControlBudgetSourceList()
        {
            InitializeComponent();
            _budgetSourcesPresenter = new BudgetSourcesPresenter(this);

            // hide button
            VisibleButtonAddNew = false;
            VisibleButtonDelete = false;
        }

        protected override void RefreshToolbar()
        {
            base.RefreshToolbar();
        }

        #region IBudgetSourcesView Members

        /// <summary>
        /// Sets the budget sources.
        /// </summary>
        /// <value>The budget sources.</value>
        public IList<Model.BusinessObjects.Dictionary.BudgetSourceModel> BudgetSources
        {
            set
            {
                treeList.DataSource = value;
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceCode", ColumnCaption = "Mã nguồn vốn", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 100, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceName", ColumnCaption = "Tên nguồn vốn", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 400, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnCaption = "Diễn giải", ColumnPosition = 3, ColumnVisible = false, ColumnWith = 80, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnCaption = "Được sử dụng", ColumnVisible = true, ColumnPosition = 5, ColumnWith = 80, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ForeignName", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Type", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Allocation", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsFund", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsExpense", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AutonomyBudgetType", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetCode", ColumnVisible = false });
            }
        }

        /// <summary>
        /// Loads the data into tree.
        /// </summary>
        protected override void LoadDataIntoTree()
        {
            _budgetSourcesPresenter.Display();
        }

        /// <summary>
        /// Deletes the tree.
        /// </summary>
        protected override void DeleteTree()
        {
            new BudgetSourcePresenter(null).Delete(int.Parse(PrimaryKeyValue));
        }

        /// <summary>
        /// Gets the form detail.
        /// </summary>
        /// <returns></returns>
        protected override FrmXtraBaseTreeDetail GetFormDetail()
        {
            return new FrmXtraBudgetSourceDetail();
        }
        #endregion

        /// <summary>
        /// Handles the NodeCellStyle event of the treeList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs"/> instance containing the event data.</param>
        private void TreeListNodeCellStyle(object sender, DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs e)
        {
            e.Appearance.Font = Convert.ToBoolean(e.Node["IsParent"]) ? new Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, FontStyle.Bold) : new Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, FontStyle.Regular);
        }
    }
}

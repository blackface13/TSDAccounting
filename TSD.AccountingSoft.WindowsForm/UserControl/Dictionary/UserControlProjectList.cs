/***********************************************************************
 * <copyright file="UserControlProjectList.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 27 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Drawing;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.WindowsForm.BaseUserControls;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.Presenter.Dictionary.Project;
using TSD.AccountingSoft.WindowsForm.FormDictionary;


namespace TSD.AccountingSoft.WindowsForm.UserControl.Dictionary
{
    /// <summary>
    ///  class UserControlProjectList
    /// </summary>
    public partial class UserControlProjectList : BaseTreeListUserControl, IProjectsView
    {
        /// <summary>
        /// The _projects presenter
        /// </summary>
        private readonly ProjectsPresenter _projectsPresenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserControlProjectList"/> class.
        /// </summary>
        public UserControlProjectList()
        {
            InitializeComponent();
            _projectsPresenter = new ProjectsPresenter(this);
        }

        #region IProjectsView Members

        /// <summary>
        /// Sets the projects.
        /// </summary>
        /// <value>
        /// The projects.
        /// </value>
        public IList<Model.BusinessObjects.Dictionary.ProjectModel> Projects
        {
            set
            {
                treeList.DataSource = value;

                ColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectCode", ColumnCaption = "Mã dự án", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 100 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ProjectName", ColumnCaption = "Tên dự án", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 300 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ForeignName", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnCaption = "Diễn giải", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 100 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnCaption = "Được sử dụng", ColumnPosition = 4, ColumnVisible = true });
            }
        }

        /// <summary>
        /// Loads the data into grid.
        /// </summary>
        protected override void LoadDataIntoTree()
        {
            _projectsPresenter.Display();
        }

        /// <summary>
        /// Deletes the grid.
        /// </summary>
        protected override void DeleteTree()
        {
            new ProjectPresenter(null).Delete(int.Parse(PrimaryKeyValue));
        }

        #endregion

        /// <summary>
        /// Handles the NodeCellStyle event of the treeList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs"/> instance containing the event data.</param>
        private void treeList_NodeCellStyle(object sender, DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs e)
        {
            e.Appearance.Font = Convert.ToBoolean(e.Node["IsParent"]) ? new Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, FontStyle.Bold) : new Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, FontStyle.Regular);
        }

        /// <summary>
        /// Gets the form detail.
        /// </summary>
        /// <returns></returns>
        protected override FrmXtraBaseTreeDetail GetFormDetail()
        {
            return new FrmXtraProjectDetail();
        }
    }
}

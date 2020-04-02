/***********************************************************************
 * <copyright file="UserControlAccountCategoryList.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   BangNC
 * Email:    BangNC@buca.vn
 * Website:
 * Create Date: Friday, March 14, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Drawing;
using TSD.AccountingSoft.Presenter.Dictionary.AccountCategory;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.WindowsForm.BaseUserControls;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.FormDictionary;


namespace TSD.AccountingSoft.WindowsForm.UserControl.Dictionary
{
    /// <summary>
    /// Class UserControlAccountCategoryList.
    /// </summary>
    public partial class UserControlAccountCategoryList : BaseTreeListUserControl, IAccountCategoriesView
    {
        private readonly AccountCategoriesPresenter _accountCategoriesPresenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserControlAccountCategoryList"/> class.
        /// </summary>
        public UserControlAccountCategoryList()
        {
            InitializeComponent();
            _accountCategoriesPresenter = new AccountCategoriesPresenter(this);
        }

        #region IAccountCategoriesView Members

        /// <summary>
        /// Sets the account categories.
        /// </summary>
        /// <value>The account categories.</value>
        public IList<Model.BusinessObjects.Dictionary.AccountCategoryModel> AccountCategories
        {
            set
            {
                treeList.DataSource = value;
                ColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "AccountCategoryCode",
                        ColumnCaption = "Mã nhóm tài khoản",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 100
                    });
                ColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "AccountCategoryName",
                        ColumnCaption = "Tên nhóm tài khoản",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 300
                    });
                ColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "IsActive",
                        ColumnCaption = "Được sử dụng",
                        ColumnVisible = true,
                        ColumnPosition = 3
                    });
                ColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "ForeignName",
                        ColumnCaption = "Tên tiếng anh",
                        ColumnVisible = false,
                        ColumnPosition = 5
                    });
                 ColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "Grade",
                        ColumnCaption = "Bậc",
                        ColumnVisible = false,
                        ColumnPosition = 7
                    });
                ColumnsCollection.Add(new XtraColumn
                    {
                        ColumnName = "IsDetail",
                        ColumnCaption = "Chi tiết",
                        ColumnVisible = false,
                        ColumnPosition = 8
                    });
            }
        }

        /// <summary>
        /// Loads the data into tree.
        /// </summary>
        protected override void LoadDataIntoTree()
        {
            _accountCategoriesPresenter.Display();
        }

        /// <summary>
        /// Deletes the tree.
        /// </summary>
        protected override void DeleteTree()
        {
            new AccountCategoryPresenter(null).Delete(int.Parse(PrimaryKeyValue));
        }

        #endregion

        /// <summary>
        /// Handles the NodeCellStyle event of the treeList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs"/> instance containing the event data.</param>
        private void treeList_NodeCellStyle(object sender, DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs e)
        {
            e.Appearance.Font = Convert.ToBoolean(e.Node["IsDetail"])
                                    ? new Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, FontStyle.Regular)
                                    : new Font(e.Appearance.Font.FontFamily, e.Appearance.Font.Size, FontStyle.Bold);
        }

        /// <summary>
        /// Gets the form detail.
        /// </summary>
        /// <returns></returns>
        protected override FrmXtraBaseTreeDetail GetFormDetail()
        {
            return new FrmXtraAccountCategoryDetail();
        }
    }
}

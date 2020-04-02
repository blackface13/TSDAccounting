/***********************************************************************
 * <copyright file="UserControlMergerFundList.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   THODD
 * Email:    thodd@buca.vn
 * Website:
 * Create Date: Wednesday, February 26, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/
using System.Collections.Generic;
using TSD.AccountingSoft.Presenter.Dictionary.MergerFund;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.WindowsForm.BaseUserControls;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.FormDictionary;
using DevExpress.Utils;

namespace TSD.AccountingSoft.WindowsForm.UserControl.Dictionary
{
    /// <summary>
    /// Class UserControlMergerFundList.
    /// </summary>
    public partial class UserControlMergerFundList : BaseTreeListUserControl, IMergerFundsView
    {
        /// <summary>
        /// The _merger funds presenter
        /// </summary>
        private readonly MergerFundsPresenter _mergerFundsPresenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserControlMergerFundList"/> class.
        /// </summary>
        public UserControlMergerFundList()
        {
            InitializeComponent();
            _mergerFundsPresenter = new MergerFundsPresenter(this);
        }

        #region IMergerFundsView Members

        /// <summary>
        /// Sets the merger funds.
        /// </summary>
        /// <value>The merger funds.</value>
        public IList<Model.BusinessObjects.Dictionary.MergerFundModel> MergerFunds
        {
            set
            {
                treeList.DataSource = value;
                ColumnsCollection.Add(new XtraColumn { ColumnName = "MergerFundCode", ColumnCaption = "Mã quỹ sát nhập", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 100, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "MergerFundName", ColumnCaption = "Tên quỹ sát nhập", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 300, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnCaption = "Diễn giải", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 100, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnCaption = "Được sử dụng", ColumnPosition = 4, ColumnVisible = true, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ForeignName", ColumnVisible = false });
            }
        }

        /// <summary>
        /// Loads the data into tree.
        /// </summary>
        protected override void LoadDataIntoTree()
        {
            _mergerFundsPresenter.Display();
        }

        /// <summary>
        /// Deletes the tree.
        /// </summary>
        protected override void DeleteTree()
        {
            new MergerFundPresenter(null).Delete(int.Parse(PrimaryKeyValue));
        }
        #endregion

        /// <summary>
        /// Gets the form detail.
        /// </summary>
        /// <returns></returns>
        protected override FrmXtraBaseTreeDetail GetFormDetail()
        {
            return new FrmXtraMergerFundDetail();
        }
    }
}

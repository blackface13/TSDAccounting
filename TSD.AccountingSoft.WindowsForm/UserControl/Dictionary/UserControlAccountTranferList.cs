/***********************************************************************
 * <copyright file="UserControlAccountTranferList.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 07 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Presenter.Dictionary.AccountTranfer;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.WindowsForm.BaseUserControls;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.FormDictionary;
using DevExpress.Utils;


namespace TSD.AccountingSoft.WindowsForm.UserControl.Dictionary
{
    /// <summary>
    /// class UserControlAccountTranferList
    /// </summary>
    public partial class UserControlAccountTranferList : BaseListUserControl, IAccountTranfersView
    {
        private readonly AccountTranfersPresenter _accountTranfersPresenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserControlAccountTranferList"/> class.
        /// </summary>
        public UserControlAccountTranferList()
        {
            InitializeComponent();
            _accountTranfersPresenter = new AccountTranfersPresenter(this);
        }

        #region IAccountTranfersView Members

        /// <summary>
        /// Sets the account tranfers.
        /// </summary>
        /// <value>
        /// The account tranfers.
        /// </value>
        public IList<AccountTranferModel> AccountTranfers
        {
            set
            {
                ListBindingSource.DataSource = value;
                gridView.PopulateColumns(value);

                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountTranferCode", ColumnCaption = "Mã TK kết chuyển", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 70, Alignment = HorzAlignment.Default });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountSourceCode", ColumnCaption = "Từ Tài khoản", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 100, Alignment = HorzAlignment.Default });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountDestinationCode", ColumnCaption = "Đến tài khoản", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 100, Alignment = HorzAlignment.Default });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnCaption = "Mô tả", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 200, Alignment = HorzAlignment.Default });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "AccountTranferId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "SortOrder", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "SideOfTranfer", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Type", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
            }
        }

        /// <summary>
        /// Loads the data into grid.
        /// </summary>
        protected override void LoadDataIntoGrid()
        {
            _accountTranfersPresenter.Display();
        }

        /// <summary>
        /// Deletes the grid.
        /// </summary>
        protected override void DeleteGrid()
        {
            new AccountTranferPresenter(null).Delete(int.Parse(PrimaryKeyValue));
        }

        #endregion

        /// <summary>
        /// Gets the form detail.
        /// </summary>
        /// <returns></returns>
        protected override FrmXtraBaseCategoryDetail GetFormDetail()
        {
            return new FrmXtraAccountTranferDetail();
        }
    }
}

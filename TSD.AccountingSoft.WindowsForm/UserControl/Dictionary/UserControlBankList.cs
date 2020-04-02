/***********************************************************************
 * <copyright file="UserControlBankList.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 08 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using TSD.AccountingSoft.Presenter.Dictionary.Bank;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.WindowsForm.BaseUserControls;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.FormDictionary;
using TSD.AccountingSoft.WindowsForm.Resources;

namespace TSD.AccountingSoft.WindowsForm.UserControl.Dictionary
{
    /// <summary>
    /// class UserControlBankList 
    /// </summary>
    public partial class UserControlBankList : BaseListUserControl, IBanksView
    {
        private readonly BanksPresenter _banksPresenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserControlBankList"/> class.
        /// </summary>
        public UserControlBankList()
        {
            InitializeComponent();
            _banksPresenter = new BanksPresenter(this);
        }

        #region IBanksView Members

        /// <summary>
        /// Sets the banks.
        /// </summary>
        /// <value>
        /// The banks.
        /// </value>
        public IList<Model.BusinessObjects.Dictionary.BankModel> Banks
        {
            set
            {
                grdList.DataSource = value;

                ColumnsCollection.Add(new XtraColumn { ColumnName = "BankId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BankAccount", ColumnCaption = "Mã số TK ngân hàng", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 100 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BankName", ColumnCaption = "Tên ngân hàng", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 200 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BankAddress", ColumnCaption = "Địa chỉ", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 200 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnCaption = "Được sử dụng", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 100 });
            }
        }

        /// <summary>
        /// Loads the data into grid.
        /// </summary>
        protected override void LoadDataIntoGrid()
        {
            _banksPresenter.Display();
        }

        /// <summary>
        /// Deletes the grid.
        /// </summary>
        protected override void DeleteGrid()
        {
            new BankPresenter(null).Delete(int.Parse(PrimaryKeyValue));
        }

        #endregion

        /// <summary>
        /// Gets the form detail.
        /// </summary>
        /// <returns></returns>
        protected override FrmXtraBaseCategoryDetail GetFormDetail()
        {
            return new FrmXtraBankDetail() { FormCaption = ResourceHelper.GetResourceValueByName("ResBankCaption") };
        }
    }
}

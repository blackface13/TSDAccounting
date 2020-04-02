/***********************************************************************
 * <copyright file="UserControlRefTypeList.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Hoàng Bích Sơn
 * Email:    sonhb@buca.vn
 * Website:
 * Create Date: Wednesday, March 5, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Presenter.Dictionary.RefType;
using TSD.AccountingSoft.Presenter.Dictionary.VoucherList;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.WindowsForm.BaseUserControls;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.FormCategories.RefType;
using TSD.AccountingSoft.WindowsForm.FormDictionary;
using DevExpress.Utils;
using DevExpress.XtraBars;


namespace TSD.AccountingSoft.WindowsForm.UserControl.Dictionary
{

    /// <summary>
    /// UserControlRefTypeList class
    /// </summary>
    public partial class UserControlRefTypeList : BaseListUserControl,IRefTypesView
    {

        /// <summary>
        /// The _voucher lists presenter
        /// </summary>
        private readonly RefTypesPresenter _refTypesPresenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserControlRefTypeList"/> class.
        /// </summary>
        public UserControlRefTypeList()
        {
            InitializeComponent();
            _refTypesPresenter = new RefTypesPresenter(this);

            // hide button
            VisibleButtonAddNew = false;
            VisibleButtonDelete = false;
        }

        protected override void RefreshToolbar()
        {
            base.RefreshToolbar();
        }

        /// <summary>
        /// Sets the voucher lists.
        /// </summary>
        /// <value>
        /// The voucher lists.
        /// </value>
        public IList<RefTypeModel> RefTypes
        {
            set
            {
                grdList.DataSource = value;
                ListBindingSource.DataSource = value;
                gridView.PopulateColumns();

                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "RefTypeId",
                    ColumnVisible = false,
                    ColumnPosition = 1,
                    AllowEdit = false
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "RefTypeName",
                    ColumnCaption = "Loại chứng từ",
                    ColumnVisible = true,
                    ColumnPosition = 1,
                    ColumnWith = 200,
                    AllowEdit = false
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "DefaultDebitAccountCategoryId",
                    ColumnCaption = "Lọc TK nợ",
                    ColumnPosition = 2,
                    ColumnVisible = true,
                    ColumnWith = 80,
                    AllowEdit = false
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "DefaultDebitAccountId",
                    ColumnVisible = true,
                    ColumnPosition = 3,
                    ColumnWith = 80,
                    AllowEdit = false,
                    ColumnCaption = @"Tk nợ ngầm định"
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "DefaultCreditAccountCategoryId",
                    ColumnCaption = "Lọc Tk có",
                    ColumnVisible = true,
                    ColumnPosition = 4,
                    ColumnWith = 80,
                    AllowEdit = false
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "DefaultCreditAccountId",
                    ColumnCaption = "Tk có ngầm định",
                    ColumnPosition = 5,
                    ColumnVisible = true,
                    ColumnWith = 80,
                    AllowEdit = false
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "DefaultTaxAccountCategoryId",
                    ColumnVisible = true,
                    ColumnPosition = 6,
                    ColumnWith = 80,
                    AllowEdit = false,
                    ColumnCaption = @"Lọc Tk thuế"
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "DefaultTaxAccountId",
                    ColumnCaption = "Tk thuế ngầm định",
                    ColumnVisible = true,
                    ColumnPosition = 7,
                    ColumnWith = 80,
                    AllowEdit = false
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "FunctionId",
                    ColumnVisible = false,
                    ColumnPosition = 7,
                    ColumnWith = 80,
                    AllowEdit = false
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "RefTypeCategoryId",
                    ColumnVisible = false,
                    ColumnPosition = 7,
                    ColumnWith = 80,
                    AllowEdit = false
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "MasterTableName",
                    ColumnVisible = false,
                    ColumnPosition = 7,
                    ColumnWith = 80,
                    AllowEdit = false
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "DetailTableName",
                    ColumnVisible = false,
                    ColumnPosition = 7,
                    ColumnWith = 80,
                    AllowEdit = false
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "LayoutMaster",
                    ColumnVisible = false,
                    ColumnPosition = 7,
                    ColumnWith = 80,
                    AllowEdit = false
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "LayoutDetail",
                    ColumnVisible = false,
                    ColumnPosition = 7,
                    ColumnWith = 80,
                    AllowEdit = false
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "AllowDefaultSetting",
                    ColumnVisible = false,
                    ColumnPosition = 7,
                    ColumnWith = 80,
                    AllowEdit = false
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "Postable",
                    ColumnVisible = false,
                    ColumnPosition = 7,
                    ColumnWith = 80,
                    AllowEdit = false
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "Searchable",
                    ColumnVisible = false,
                    ColumnPosition = 7,
                    ColumnWith = 80,
                    AllowEdit = false
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "SortOrder",
                    ColumnVisible = false,
                    ColumnPosition = 7,
                    ColumnWith = 80,
                    AllowEdit = false
                });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "SubSystem",
                    ColumnVisible = false,
                    ColumnPosition = 7,
                    ColumnWith = 80,
                    AllowEdit = false
                });
            }
        }
        /// <summary>
        /// Loads the data into grid.
        /// </summary>
        protected override void LoadDataIntoGrid()
        {
            _refTypesPresenter.Display();
        }

        /// <summary>
        /// Deletes the grid.
        /// </summary>
        //protected override void DeleteGrid()
        //{
        //    new VoucherListPresenter(null).Delete(int.Parse(PrimaryKeyValue));
        //}

        /// <summary>
        /// Gets the form detail.
        /// </summary>
        /// <returns></returns>
        protected override FrmXtraBaseCategoryDetail GetFormDetail()
        {
            return new FrmRefTypeDetail();
        }
    }
}

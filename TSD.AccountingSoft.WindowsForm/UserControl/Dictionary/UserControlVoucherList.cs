/***********************************************************************
 * <copyright file="UserControlVoucherList.cs" company="BUCA JSC">
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
using TSD.AccountingSoft.Presenter.Dictionary.VoucherList;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.WindowsForm.BaseUserControls;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.FormDictionary;
using DevExpress.Utils;


namespace TSD.AccountingSoft.WindowsForm.UserControl.Dictionary
{

    /// <summary>
    /// UserControlVoucherList class
    /// </summary>
    public partial class UserControlVoucherList : BaseListUserControl,IVoucherListsView
    {

        /// <summary>
        /// The _voucher lists presenter
        /// </summary>
        private readonly VoucherListsPresenter _voucherListsPresenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserControlVoucherList"/> class.
        /// </summary>
        public UserControlVoucherList()
        {
            InitializeComponent();
            _voucherListsPresenter=new VoucherListsPresenter(this);
        }

        /// <summary>
        /// Sets the voucher lists.
        /// </summary>
        /// <value>
        /// The voucher lists.
        /// </value>
        public IList<VoucherListModel> VoucherLists
        {
            set
            {
                ListBindingSource.DataSource = value;
                gridView.PopulateColumns(value);

                ColumnsCollection.Add(new XtraColumn { ColumnName = "VoucherListId", ColumnVisible = false, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "VoucherListCode", ColumnCaption = "Số chứng từ ghi sổ", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 70, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "VoucherDate", ColumnCaption = "Ngày chứng từ ghi sổ", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 200 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "PostDate", ColumnCaption = "Ngày hạch toán", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 100 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnCaption = "Mô tả", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 100 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DocAttach", ColumnVisible = false});
            }
        }

        /// <summary>
        /// Loads the data into grid.
        /// </summary>
        protected override void LoadDataIntoGrid()
        {
            _voucherListsPresenter.Display();
        }

        /// <summary>
        /// Deletes the grid.
        /// </summary>
        protected override void DeleteGrid()
        {
            new VoucherListPresenter(null).Delete(int.Parse(PrimaryKeyValue));
        }

        /// <summary>
        /// Gets the form detail.
        /// </summary>
        /// <returns></returns>
        protected override FrmXtraBaseCategoryDetail GetFormDetail()
        {
            return new FrmXtraVoucherListDetail();
        }
    }
}

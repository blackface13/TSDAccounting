/***********************************************************************
 * <copyright file="UserControlCustomerList.cs" company="BUCA JSC">
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
using TSD.AccountingSoft.Presenter.Dictionary.Customer;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.WindowsForm.BaseUserControls;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.FormDictionary;
using DevExpress.Utils;


namespace TSD.AccountingSoft.WindowsForm.UserControl.Dictionary
{

    /// <summary>
    /// UserControlCustomerList class
    /// </summary>
    public partial class UserControlCustomerList : BaseListUserControl, ICustomersView
    {
        /// <summary>
        /// The _customers presenter
        /// </summary>
        private readonly CustomersPresenter _customersPresenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserControlCustomerList"/> class.
        /// </summary>
        public UserControlCustomerList()
        {
            InitializeComponent();
            _customersPresenter=new CustomersPresenter(this);

        }

        /// <summary>
        /// Sets the customers.
        /// </summary>
        /// <value>
        /// The customers.
        /// </value>
        public List<CustomerModel> Customers
        {
            set
            {
                ListBindingSource.DataSource = value;
                gridView.PopulateColumns(value);
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CustomerId", ColumnVisible = false, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CustomerCode", ColumnCaption = "Mã KH", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 70 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CustomerName", ColumnCaption = "Họ tên", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 200 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Address", ColumnCaption = "Địa chỉ", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 200 });                
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnCaption = "Ngừng theo dõi", ColumnPosition = 5, ColumnVisible = true, ColumnWith = 100 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ContactName", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Mobile", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ContactRegency", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Phone", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Fax", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Email", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TaxCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Website", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Province", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "City", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ZipCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Area", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Country", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BankNumber", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BankId", ColumnVisible = false });
            }
        }

        /// <summary>
        /// Loads the data into grid.
        /// </summary>
        protected override void LoadDataIntoGrid()
        {
            _customersPresenter.Display();
        }

        /// <summary>
        /// Deletes the grid.
        /// </summary>
        protected override void DeleteGrid()
        {
            new CustomerPresenter(null).Delete(int.Parse(PrimaryKeyValue));
        }

        /// <summary>
        /// Gets the form detail.
        /// </summary>
        /// <returns></returns>
        protected override FrmXtraBaseCategoryDetail GetFormDetail()
        {
            return new FrmXtraCustomerDetail();
        }
    }
}

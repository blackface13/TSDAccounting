/***********************************************************************
 * <copyright file="UserControlVendorList.cs" company="BUCA JSC">
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
using TSD.AccountingSoft.Presenter.Dictionary.Vendor;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.WindowsForm.BaseUserControls;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.FormDictionary;
using DevExpress.Utils;


namespace TSD.AccountingSoft.WindowsForm.UserControl.Dictionary
{
    /// <summary>
    /// UserControlVendorList class
    /// </summary>
    public partial class UserControlVendorList : BaseListUserControl, IVendorsView
    {
        /// <summary>
        /// The _vendors presenter
        /// </summary>
        private readonly VendorsPresenter _vendorsPresenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserControlVendorList"/> class.
        /// </summary>
        public UserControlVendorList()
        {
            InitializeComponent();
            _vendorsPresenter = new VendorsPresenter(this);
        }

        /// <summary>
        /// Sets the vendors.
        /// </summary>
        /// <value>
        /// The vendors.
        /// </value>
        public IList<VendorModel> Vendors
        {
            set
            {
                ListBindingSource.DataSource = value;
                gridView.PopulateColumns(value);

                ColumnsCollection.Add(new XtraColumn { ColumnName = "VendorId", ColumnVisible = false, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "VendorCode", ColumnCaption = "Mã nhà cung cấp", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 100 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "VendorName", ColumnCaption = "Họ tên", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 200});
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Address", ColumnCaption = "Địa chỉ", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 150 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnCaption = "Được theo dõi", ColumnPosition = 5, ColumnVisible = true, ColumnWith = 100 });
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
            _vendorsPresenter.Display();
        }

        /// <summary>
        /// Deletes the grid.
        /// </summary>
        protected override void DeleteGrid()
        {
            new VendorPresenter(null).Delete(int.Parse(PrimaryKeyValue));
        }

        /// <summary>
        /// Gets the form detail.
        /// </summary>
        /// <returns></returns>
        protected override FrmXtraBaseCategoryDetail GetFormDetail()
        {
            return new FrmXtraVendorDetail();
        }
    }
}

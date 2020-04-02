/***********************************************************************
 * <copyright file="UserControlAutoBusinessList.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 24 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Windows.Forms;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Presenter.Dictionary.AutoBusiness;
using TSD.AccountingSoft.Presenter.Dictionary.VoucherType;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.WindowsForm.BaseUserControls;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using System.Collections.Generic;
using TSD.AccountingSoft.WindowsForm.FormDictionary;
using TSD.AccountingSoft.WindowsForm.Resources;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using TSD.AccountingSoft.WindowsForm.CommonClass;
using TSD.AccountingSoft.Presenter.Dictionary.RefType;

namespace TSD.AccountingSoft.WindowsForm.UserControl.Dictionary
{
    /// <summary>
    /// class UserControlAutoBusinessList
    /// </summary>
    public partial class UserControlAutoBusinessList : BaseListUserControl, IAutoBusinessesView, IVoucherTypesView, IRefTypesView
    {
        private readonly AutoBusinessesPresenter _autoBusinessesPresenter;
        private RepositoryItemGridLookUpEdit _gridLookUpEditVoucherType;
        private RepositoryItemGridLookUpEdit _gridLookUpEditRefType;
        private GridView _gridLookUpEditVoucherTypeView;

        private readonly VoucherTypesPresenter _voucherTypesPresenter;
        private readonly RefTypesPresenter _refTypesPresenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserControlAutoBusinessList"/> class.
        /// </summary>
        public UserControlAutoBusinessList()
        {
            InitializeComponent();
            _autoBusinessesPresenter = new AutoBusinessesPresenter(this);
            _voucherTypesPresenter = new VoucherTypesPresenter(this);
            _refTypesPresenter = new RefTypesPresenter(this);

        }

        protected override void RefreshToolbar()
        {
            base.RefreshToolbar();

            //BarButtonVisible(false, true, false, true, true, true, true);
        }

        #region IAutoBusinesssView Members

        /// <summary>
        /// Sets the autoBusinesss.
        /// </summary>
        /// <value>
        /// The autoBusinesss.
        /// </value>
        public IList<AutoBusinessModel> AutoBusinesses
        {
            set
            {
                grdList.DataSource = value;

                ColumnsCollection.Add(new XtraColumn { ColumnName = "AutoBusinessId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceCode", ColumnCaption = "Nguồn vốn", ColumnPosition = 7, ColumnVisible = true, ColumnWith = 100 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemCode", ColumnCaption = "Mục - tiểu mục", ColumnPosition = 8, ColumnVisible = true, ColumnWith = 100 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSubItemCode", ColumnCaption = "Mục - tiểu mục", ColumnPosition = 8, ColumnVisible = false, ColumnWith = 100 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AutoBusinessCode", ColumnCaption = "Mã định khoản", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 100 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "AutoBusinessName", ColumnCaption = "Tên định khoản", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 300 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "RefTypeId", ColumnCaption = "Loại chứng từ", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 100, RepositoryControl = _gridLookUpEditRefType });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "VoucherTypeId", ColumnCaption = "Nghiệp vụ", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 150, RepositoryControl = _gridLookUpEditVoucherType });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DebitAccountNumber", ColumnCaption = "Tài khoản nợ", ColumnPosition = 5, ColumnVisible = true, ColumnWith = 150 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CreditAccountNumber", ColumnCaption = "Tài khoản có", ColumnPosition = 6, ColumnVisible = true, ColumnWith = 150 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CurrencyCode", ColumnCaption = "Loại tiền", ColumnPosition = 9, ColumnVisible = true, ColumnWith = 100 });
            }
        }

        /// <summary>
        /// Loads the data into grid.
        /// </summary>
        protected override void LoadDataIntoGrid()
        {
            _refTypesPresenter.Display();
            _voucherTypesPresenter.DisplayActive();
            _autoBusinessesPresenter.Display();
        }

        /// <summary>
        /// Deletes the grid.
        /// </summary>
        protected override void DeleteGrid()
        {
            new AutoBusinessPresenter(null).Delete(int.Parse(PrimaryKeyValue));
        }

        #endregion

        /// <summary>
        /// Sets the voucher types.
        /// </summary>
        /// <value>
        /// The voucher types.
        /// </value>
        public IList<VoucherTypeModel> VoucherTypes
        {
            set
            {
                try
                {
                    //RepositoryItemGridLookUpEdit VoucherType
                    _gridLookUpEditVoucherTypeView = new GridView();
                    _gridLookUpEditVoucherTypeView.OptionsView.ColumnAutoWidth = false;
                    _gridLookUpEditVoucherType = new RepositoryItemGridLookUpEdit
                    {
                        NullText = "",
                        View = _gridLookUpEditVoucherTypeView,
                        TextEditStyle = TextEditStyles.Standard,
                        ShowFooter = false
                    };
                    _gridLookUpEditVoucherType.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                    _gridLookUpEditVoucherType.View.OptionsView.ShowIndicator = false;
                    _gridLookUpEditVoucherType.View.OptionsView.ShowHorizontalLines = DefaultBoolean.False;
                    _gridLookUpEditVoucherType.View.OptionsView.ShowColumnHeaders = false;
                    _gridLookUpEditVoucherType.View.BestFitColumns();

                    _gridLookUpEditVoucherType.DataSource = value;
                    _gridLookUpEditVoucherTypeView.PopulateColumns(value);

                    var gridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn { ColumnName = "VoucherTypeName", ColumnCaption = "Nghiệp vụ", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 300 },
                        new XtraColumn { ColumnName = "VoucherTypeId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsActive", ColumnVisible = false }
                    };

                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditVoucherTypeView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditVoucherTypeView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            _gridLookUpEditVoucherTypeView.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                            _gridLookUpEditVoucherTypeView.Columns[column.ColumnName].Visible = false;
                    }
                    _gridLookUpEditVoucherType.DisplayMember = "VoucherTypeName";
                    _gridLookUpEditVoucherType.ValueMember = "VoucherTypeId";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public IList<RefTypeModel> RefTypes
        {
            set
            {
                if (_gridLookUpEditRefType == null)
                {
                    _gridLookUpEditRefType = new RepositoryItemGridLookUpEdit();
                }
                GridLookUpItem.RefType(value, _gridLookUpEditRefType, "RefTypeName", "RefTypeId");
            }
        }

        /// <summary>
        /// Gets the form detail.
        /// </summary>
        /// <returns></returns>
        protected override FrmXtraBaseCategoryDetail GetFormDetail()
        {
            return new FrmXtraAutoBusinessDetails() { FormCaption = ResourceHelper.GetResourceValueByName("ResAutoBusinessCaption") };
        }
    }
}

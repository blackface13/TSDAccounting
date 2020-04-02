/***********************************************************************
 * <copyright file="FrmXtraSearchVoucher.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuanHM
 * Email:    tuanhm@buca.vn, ThangNK 16/08/2014
 * Website:
 * Create Date: Saturday, June 1, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using TSD.AccountingSoft.Session;
using TSD.AccountingSoft.Model;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Model.BusinessObjects.Search;
using TSD.AccountingSoft.Presenter.Dictionary.Account;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.WindowsForm.CommonClass;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.Enum;
using TSD.AccountingSoft.WindowsForm.Resources;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;

namespace TSD.AccountingSoft.WindowsForm.FormBusiness
{
    /// <summary>
    /// Class FrmXtraSearchVoucher.
    /// </summary>
    public partial class FrmXtraSearchVoucher : XtraForm, IAccountsView
    {
        /// <summary>
        /// Gets the model.
        /// </summary>
        /// <value>The model.</value>
        protected static IModel Model { get; private set; }

        /// <summary>
        /// The currency accounting
        /// </summary>
        protected string CurrencyAccounting;

        /// <summary>
        /// The currency local
        /// </summary>
        protected string CurrencyLocal;

        /// <summary>
        /// The database option helper
        /// </summary>
        private readonly GlobalVariable _dbOptionHelper;

        /// <summary>
        /// The where clause
        /// </summary>
        protected string WhereClause = " ";

        /// <summary>
        /// The currency code
        /// </summary>
        protected string CurrencyCode = "";

        /// <summary>
        /// From date
        /// </summary>
        protected string FromDate = "";

        /// <summary>
        /// To date
        /// </summary>
        protected string ToDate = "";

        /// <summary>
        /// Fixed Asset Code
        /// </summary>
        protected string FixedAssetCode = "";

        /// <summary>
        /// Budget Group Code
        /// </summary>
        protected string BudgetGroupCode = "";


        /// <summary>
        /// Department Code
        /// </summary>
        protected string DepartmentCode = "";

        /// <summary>
        /// The _accounts
        /// </summary>
        private IList<AccountModel> _accounts;

        /// <summary>
        /// The _RPS accounting object
        /// </summary>
        private RepositoryItemGridLookUpEdit _rpsExpressionSearch;

        /// <summary>
        /// The _RPS accounting object view
        /// </summary>
        private GridView _rpsExpressionSearchView;

        /// <summary>
        /// The _accounts presenter
        /// </summary>
        private readonly AccountsPresenter _accountsPresenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmXtraSearchVoucher"/> class.
        /// </summary>
        public FrmXtraSearchVoucher()
        {
            InitializeComponent();
            _dbOptionHelper = new GlobalVariable();
            _accountsPresenter = new AccountsPresenter(this);
            Model = new Model.Model();
            CurrencyAccounting = _dbOptionHelper.CurrencyAccounting;
            CurrencyLocal = _dbOptionHelper.CurrencyLocal;

            //dtFromDate.EditValue = _dbOptionHelper.PostedDate;
            //dtToDate.EditValue = _dbOptionHelper.PostedDate;

            dtFromDate.EditValue = DateTime.ParseExact("01/01/" + (_dbOptionHelper.PostedDate == null ? DateTime.Now.Year.ToString() : _dbOptionHelper.PostedDate.Substring(6, 4)), "dd/MM/yyyy", null);
            dtToDate.EditValue = DateTime.ParseExact("31/12/" + (_dbOptionHelper.PostedDate == null ? DateTime.Now.Year.ToString() : _dbOptionHelper.PostedDate.Substring(6, 4)), "dd/MM/yyyy", null);
        }

        /// <summary>
        /// Initializes the grid main.
        /// </summary>
        protected void InitGridMain()
        {
            grdlookUpFieldSearch.DataSource = ObjectFieldSearchs();
            gridViewFieldSearch.PopulateColumns();
            var gridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn {ColumnName = "ObjectFieldSearchId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ObjectFieldSearchName", ColumnCaption = "Trường", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 120},
                    };

            foreach (var column in gridColumnsCollection)
            {
                if (column.ColumnVisible)
                {
                    gridViewFieldSearch.Columns[column.ColumnName].Caption = column.ColumnCaption;
                    gridViewFieldSearch.Columns[column.ColumnName].Width = column.ColumnWith;
                }
                else { gridViewFieldSearch.Columns[column.ColumnName].Visible = false; }
            }

        }

        /// <summary>
        /// Objects the categorys.
        /// </summary>
        /// <returns>IList&lt;ObjectFieldSearch&gt;.</returns>
        protected IList<ObjectFieldSearch> ObjectFieldSearchs()
        {
            IList<ObjectFieldSearch> listOc = new List<ObjectFieldSearch>();
            listOc.Add(new ObjectFieldSearch("RefNo", "Số chứng từ"));
            listOc.Add(new ObjectFieldSearch("FromDate", "Ngày chứng từ"));
            listOc.Add(new ObjectFieldSearch("RefTypeID", "Loại chứng từ"));
            listOc.Add(new ObjectFieldSearch("CurrencyCode", "Loại tiền"));
            listOc.Add(new ObjectFieldSearch("AccountNumber", "Tài khoản nợ"));
            listOc.Add(new ObjectFieldSearch("CorrespondingAccountNumber", "Tài khoản có"));
            listOc.Add(new ObjectFieldSearch("AmountExchange", "Quy đổi"));
            listOc.Add(new ObjectFieldSearch("AmountOC", "Số tiền"));
            listOc.Add(new ObjectFieldSearch("VoucherTypeID", "Nghiệp vụ"));
            listOc.Add(new ObjectFieldSearch("BudgetSourceCode", "Nguồn vốn"));
            listOc.Add(new ObjectFieldSearch("BudgetItemCode", "Mục/Tiểu mục"));
            //listOc.Add(new ObjectFieldSearch("BudgetItemId", "Nhóm mục")); //Nhóm mục ==> là BugetGroupCode
            //listOc.Add(new ObjectFieldSearch("ProjectID", "Dự án"));
            listOc.Add(new ObjectFieldSearch("VendorID", "Nhà cung cấp"));
            listOc.Add(new ObjectFieldSearch("EmployeeID", "Cán bộ"));
            listOc.Add(new ObjectFieldSearch("AccountingObjectID", "Đối tượng khác"));
            //listOc.Add(new ObjectFieldSearch("InventoryItemID", "Vật tư"));
            listOc.Add(new ObjectFieldSearch("FixedAssetCode", "Tài sản"));
            listOc.Add(new ObjectFieldSearch("DepartmentCode", "Phòng ban"));
            return listOc;
        }

        /// <summary>
        /// The _data for search
        /// </summary>
        List<ObjectExpressionSearch> _dataForSearch = new List<ObjectExpressionSearch>();

        /// <summary>
        /// Handles the Load event of the FrmXtraSearchVoucher control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FrmXtraSearchVoucher_Load(object sender, EventArgs e)
        {
            InitGridMain();
            _rpsExpressionSearch = new RepositoryItemGridLookUpEdit { NullText = "" };
            _rpsExpressionSearchView = new GridView();
            _rpsExpressionSearch.View = _rpsExpressionSearchView;
            _rpsExpressionSearch.TextEditStyle = TextEditStyles.Standard;
            _rpsExpressionSearch.ShowFooter = false;
            // gán data to 
            _rpsExpressionSearch.DataSource = new List<GridLookUpItem> { new GridLookUpItem("OR", "Hoặc"), new GridLookUpItem("AND", "Và") };
            _rpsExpressionSearch.PopulateViewColumns();
            _rpsExpressionSearch.View.OptionsView.ShowIndicator = false;
            _rpsExpressionSearch.View.OptionsView.ShowColumnHeaders = false;
            _rpsExpressionSearch.PopupFormWidth = 200;
            _rpsExpressionSearch.DisplayMember = "DataMember";
            _rpsExpressionSearch.ValueMember = "DataValue";

            grdlookUpExpressionSearch.DataSource = _dataForSearch;
            grdlookUpExpressionSearchView.Columns["ExpressionLogic"].ColumnEdit = _rpsExpressionSearch;
            grdlookUpExpressionSearchView.Columns["ExpressionLogic"].OptionsColumn.AllowEdit = true;

            txtRefNo.Visible = true;
            lblRefNo.Visible = true;
            txtRefNo.Location = new Point(250, 24);
            lblRefNo.Location = new Point(185, 26);
            grdObjectValue.Visible = false;
            lblValue.Visible = false;
            dtFromDate.Visible = false;
            dtToDate.Visible = false;
            lblFromDate.Visible = false;
            lblTodate.Visible = false;

            lblgreater.Visible = false;
            lbllesser.Visible = false;
            txtgreater.Visible = false;
            txtlesser.Visible = false;
            txtlesser.Properties.Mask.UseMaskAsDisplayFormat = true;


            FormatGridExpression();
            grdList.DataSource = new List<SearchModel>(); // Khởi tạo trên header trên grid
            if (grdList.DataSource != null)
            {
                FormatGrdList();
            }

        }

        /// <summary>
        /// Handles the Click event of the grdlookUpFieldSearch control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void grdlookUpFieldSearch_Click(object sender, EventArgs e)
        {
            if (gridViewFieldSearch.FocusedRowHandle > -1)
            {

                var objectFieldSearchIdCol = gridViewFieldSearch.Columns["ObjectFieldSearchId"];
                string objectFieldSearchId = gridViewFieldSearch.GetRowCellValue(gridViewFieldSearch.FocusedRowHandle, objectFieldSearchIdCol).ToString();

                switch (objectFieldSearchId)
                {
                    case "RefNo":

                        grdObjectValue.Visible = false;
                        dtFromDate.Visible = false;
                        dtToDate.Visible = false;
                        lblFromDate.Visible = false;
                        lblTodate.Visible = false;
                        lblValue.Visible = false;

                        lblRefNo.Visible = true;
                        txtRefNo.Visible = true;

                        lblgreater.Visible = false;
                        lbllesser.Visible = false;
                        txtgreater.Visible = false;
                        txtlesser.Visible = false;
                        lblTodate.Visible = false;
                        break;

                    case "FromDate":
                        grdObjectValue.Visible = false;
                        dtFromDate.Visible = true;
                        dtToDate.Visible = true;
                        lblFromDate.Visible = true;
                        lblTodate.Visible = true;
                        lblValue.Visible = false;

                        lblRefNo.Visible = false;
                        txtRefNo.Visible = false;

                        lblgreater.Visible = false;
                        lbllesser.Visible = false;
                        txtgreater.Visible = false;
                        txtlesser.Visible = false;
                        lblTodate.Visible = true;
                        break;
                    case "AmountOC":
                        grdObjectValue.Visible = false;
                        dtFromDate.Visible = false;
                        dtToDate.Visible = false;
                        lblFromDate.Visible = false;
                        lblTodate.Visible = true;
                        lblValue.Visible = false;
                        lblRefNo.Visible = false;
                        txtRefNo.Visible = false;
                        lblTodate.Visible = false;

                        lblgreater.Visible = true;
                        txtgreater.Visible = true;
                        lbllesser.Visible = true;
                        txtlesser.Visible = true;
                        txtgreater.EditValue = null;
                        txtlesser.EditValue = null;

                        lblgreater.Location = new Point(192, 28);
                        txtgreater.Location = new Point(224, 24);
                        lbllesser.Location = new Point(192, 60);
                        txtlesser.Location = new Point(224, 56);
                        break;
                    case "AmountExchange":
                        grdObjectValue.Visible = false;
                        dtFromDate.Visible = false;
                        dtToDate.Visible = false;
                        lblFromDate.Visible = false;
                        lblTodate.Visible = true;
                        lblValue.Visible = false;
                        lblRefNo.Visible = false;
                        txtRefNo.Visible = false;

                        lblgreater.Visible = true;
                        lbllesser.Visible = true;
                        txtgreater.Visible = true;
                        txtlesser.Visible = true;
                        lblTodate.Visible = false;
                        txtgreater.EditValue = null;
                        txtlesser.EditValue = null;

                        lblgreater.Location = new Point(192, 28);
                        txtgreater.Location = new Point(224, 24);
                        lbllesser.Location = new Point(192, 60);
                        txtlesser.Location = new Point(224, 56);

                        break;

                    default:
                        lblRefNo.Visible = false;
                        txtRefNo.Visible = false;
                        grdObjectValue.Visible = true;
                        dtFromDate.Visible = false;
                        dtToDate.Visible = false;
                        lblFromDate.Visible = false;
                        lblTodate.Visible = false;
                        lblValue.Visible = true;
                        lblTodate.Visible = false;

                        lblgreater.Visible = false;
                        lbllesser.Visible = false;
                        txtgreater.Visible = false;
                        txtlesser.Visible = false;

                        SetDataSourceCombobox(objectFieldSearchId);
                        break;
                }
            }
        }

        /// <summary>
        /// Sets the data source combobox.
        /// </summary>
        /// <param name="objectFieldSearchId">The object field search identifier.</param>
        private void SetDataSourceCombobox(string objectFieldSearchId)
        {
            grdObjectValue.Properties.PopupWidth = 500;
            if (objectFieldSearchId == "RefTypeID") //Loại CT
            {
                var list = Model.GetRefTypesSearch();
                foreach (var refTypeModel in list.ToList())
                {
                    if (refTypeModel.RefTypeId == 110 || refTypeModel.RefTypeId == 120)
                    {
                        list.Remove(refTypeModel);
                    }
                }
                grdObjectValue.Properties.DataSource = list;// Model.GetRefTypes();
                grdObjectValue.Properties.PopulateColumns();
                foreach (LookUpColumnInfo column in grdObjectValue.Properties.Columns)
                {
                    grdObjectValue.Properties.Columns[column.FieldName].Visible = false;
                }
                grdObjectValue.Properties.Columns["RefTypeName"].Visible = true;
                grdObjectValue.Properties.Columns["RefTypeName"].Caption = @"Loại chứng từ";
                grdObjectValue.Properties.ValueMember = "RefTypeId";
                grdObjectValue.Properties.DisplayMember = "RefTypeName";
            }
            if (objectFieldSearchId == "CurrencyCode") // Loại Tiền
            {
                InitDefaultCurrencies();
            }
            if (objectFieldSearchId == "CorrespondingAccountNumber") //TK có 
            {
                grdObjectValue.Properties.DataSource = Model.GetAccounts().Where(x => x.IsActive == true).OrderBy(x => x.AccountCode).ToList(); ;
                grdObjectValue.Properties.PopulateColumns();
                foreach (LookUpColumnInfo column in grdObjectValue.Properties.Columns)
                {
                    grdObjectValue.Properties.Columns[column.FieldName].Visible = false;
                }
                grdObjectValue.Properties.Columns["AccountName"].Visible = true;
                grdObjectValue.Properties.Columns["AccountCode"].Visible = true;
                grdObjectValue.Properties.Columns["AccountName"].Width = 400;
                grdObjectValue.Properties.Columns["AccountCode"].Width = 100;

                grdObjectValue.Properties.Columns["AccountName"].Caption = @"Tên tài khoản";
                grdObjectValue.Properties.Columns["AccountCode"].Caption = @"Mã tài khoản";
                grdObjectValue.Properties.ValueMember = "AccountCode";
                grdObjectValue.Properties.DisplayMember = "AccountCode";
            }
            if (objectFieldSearchId == "AccountNumber") //TK nợ
            {
                grdObjectValue.Properties.DataSource = Model.GetAccounts().Where(x => x.IsActive == true).OrderBy(x => x.AccountCode).ToList();
                grdObjectValue.Properties.PopulateColumns();
                foreach (LookUpColumnInfo column in grdObjectValue.Properties.Columns)
                {
                    grdObjectValue.Properties.Columns[column.FieldName].Visible = false;
                }
                grdObjectValue.Properties.Columns["AccountName"].Visible = true;
                grdObjectValue.Properties.Columns["AccountCode"].Visible = true;
                grdObjectValue.Properties.Columns["AccountName"].Width = 400;
                grdObjectValue.Properties.Columns["AccountCode"].Width = 100;
                grdObjectValue.Properties.Columns["AccountName"].Caption = @"Tên tài khoản";
                grdObjectValue.Properties.Columns["AccountCode"].Caption = @"Mã tài khoản";
                grdObjectValue.Properties.ValueMember = "AccountCode";
                grdObjectValue.Properties.DisplayMember = "AccountCode";
            }
            if (objectFieldSearchId == "VoucherTypeID") //Nghiệp vụ
            {
                grdObjectValue.Properties.DataSource = Model.GetVoucherTypes().Where(w => w.IsActive == true).ToList();
                grdObjectValue.Properties.PopulateColumns();
                foreach (LookUpColumnInfo column in grdObjectValue.Properties.Columns)
                {
                    grdObjectValue.Properties.Columns[column.FieldName].Visible = false;
                }
                grdObjectValue.Properties.Columns["VoucherTypeName"].Visible = true;
                grdObjectValue.Properties.ValueMember = "VoucherTypeId";
                grdObjectValue.Properties.Columns["VoucherTypeName"].Caption = @"Nghiệp vụ";
                grdObjectValue.Properties.Columns["VoucherTypeName"].Width = 500;
                grdObjectValue.Properties.DisplayMember = "VoucherTypeName";
            }
            if (objectFieldSearchId == "BudgetSourceCode") //Nguồn vốn
            {
                grdObjectValue.Properties.DataSource = Model.GetBudgetSources();
                grdObjectValue.Properties.PopulateColumns();
                foreach (LookUpColumnInfo column in grdObjectValue.Properties.Columns)
                {
                    grdObjectValue.Properties.Columns[column.FieldName].Visible = false;
                }
                grdObjectValue.Properties.Columns["BudgetSourceCode"].Visible = true;
                grdObjectValue.Properties.Columns["BudgetSourceName"].Visible = true;
                grdObjectValue.Properties.Columns["BudgetSourceCode"].Caption = @"Mã nguồn";
                grdObjectValue.Properties.Columns["BudgetSourceName"].Caption = @"Tên nguồn";
                grdObjectValue.Properties.Columns["BudgetSourceCode"].Width = 100;
                grdObjectValue.Properties.Columns["BudgetSourceName"].Width = 400;
                grdObjectValue.Properties.ValueMember = "BudgetSourceCode";
                grdObjectValue.Properties.DisplayMember = "BudgetSourceCode";
            }
            if (objectFieldSearchId == "BudgetChapterCode") //Chương
            {
                grdObjectValue.Properties.DataSource = Model.GetBudgetChapters();
                grdObjectValue.Properties.PopulateColumns();
                foreach (LookUpColumnInfo column in grdObjectValue.Properties.Columns)
                {
                    grdObjectValue.Properties.Columns[column.FieldName].Visible = false;
                }
                grdObjectValue.Properties.Columns["BudgetChapterCode"].Visible = true;
                grdObjectValue.Properties.Columns["BudgetChapterName"].Visible = true;
                grdObjectValue.Properties.Columns["BudgetChapterCode"].Caption = @"Mã chương";
                grdObjectValue.Properties.Columns["BudgetChapterName"].Caption = @"Tên chương";
                grdObjectValue.Properties.Columns["BudgetChapterCode"].Width = 50;
                grdObjectValue.Properties.ValueMember = "BudgetChapterCode";
                grdObjectValue.Properties.DisplayMember = "BudgetChapterCode";
            }
            if (objectFieldSearchId == "BudgetCategoryCode") //Loại khoản
            {
                grdObjectValue.Properties.DataSource = Model.GetBudgetCategories();
                grdObjectValue.Properties.PopulateColumns();
                foreach (LookUpColumnInfo column in grdObjectValue.Properties.Columns)
                {
                    grdObjectValue.Properties.Columns[column.FieldName].Visible = false;
                }
                grdObjectValue.Properties.Columns["BudgetCategoryCode"].Visible = true;
                grdObjectValue.Properties.Columns["BudgetCategoryName"].Visible = true;
                grdObjectValue.Properties.Columns["BudgetCategoryCode"].Caption = @"Mã loại khoản";
                grdObjectValue.Properties.Columns["BudgetCategoryName"].Caption = @"Tên loại khoản";
                grdObjectValue.Properties.Columns["BudgetCategoryName"].Width = 400;
                grdObjectValue.Properties.Columns["BudgetCategoryCode"].Width = 100;
                grdObjectValue.Properties.ValueMember = "BudgetCategoryCode";
                grdObjectValue.Properties.DisplayMember = "BudgetCategoryCode";
            }

            if (objectFieldSearchId == "BudgetItemCode") //Mục/ Tiểu mục
            {
                grdObjectValue.Properties.DataSource = Model.GetBudgetItems();
                grdObjectValue.Properties.PopulateColumns();
                foreach (LookUpColumnInfo column in grdObjectValue.Properties.Columns)
                {
                    grdObjectValue.Properties.Columns[column.FieldName].Visible = false;
                }
                grdObjectValue.Properties.Columns["BudgetItemCode"].Visible = true;
                grdObjectValue.Properties.Columns["BudgetItemName"].Visible = true;
                grdObjectValue.Properties.Columns["BudgetItemCode"].Caption = @"Mã mục";
                grdObjectValue.Properties.Columns["BudgetItemName"].Caption = @"Tên mục";
                grdObjectValue.Properties.Columns["BudgetItemCode"].Width = 100;
                grdObjectValue.Properties.Columns["BudgetItemName"].Width = 400;
                grdObjectValue.Properties.ValueMember = "BudgetItemCode";
                grdObjectValue.Properties.DisplayMember = "BudgetItemCode";
            }


            if (objectFieldSearchId == "BudgetItemId") //Nhóm mục
            {
                grdObjectValue.Properties.DataSource = Model.GetBudgetItems().Where(x => x.BudgetItemType <= 2).ToList();
                grdObjectValue.Properties.PopulateColumns();
                foreach (LookUpColumnInfo column in grdObjectValue.Properties.Columns)
                {
                    grdObjectValue.Properties.Columns[column.FieldName].Visible = false;
                }
                grdObjectValue.Properties.Columns["BudgetItemCode"].Visible = true;
                grdObjectValue.Properties.Columns["BudgetItemName"].Visible = true;
                grdObjectValue.Properties.Columns["BudgetItemCode"].Caption = @"Mã nhóm mục";
                grdObjectValue.Properties.Columns["BudgetItemName"].Caption = @"Tên tên nhóm mục";
                grdObjectValue.Properties.Columns["BudgetItemCode"].Width = 100;
                grdObjectValue.Properties.Columns["BudgetItemName"].Width = 400;
                grdObjectValue.Properties.ValueMember = "BudgetItemCode"; //BudgetGroupCode
                grdObjectValue.Properties.DisplayMember = "BudgetItemCode";
            }


            if (objectFieldSearchId == "DepartmentCode") //Nhóm mục
            {
                grdObjectValue.Properties.DataSource = Model.GetDepartments().Where(x => x.IsActive == true).ToList().OrderBy(x => x.DepartmentCode).ToList();
                grdObjectValue.Properties.PopulateColumns();
                foreach (LookUpColumnInfo column in grdObjectValue.Properties.Columns)
                {
                    grdObjectValue.Properties.Columns[column.FieldName].Visible = false;
                }
                grdObjectValue.Properties.Columns["DepartmentCode"].Visible = true;
                grdObjectValue.Properties.Columns["DepartmentName"].Visible = true;
                grdObjectValue.Properties.Columns["DepartmentCode"].Caption = @"Mã phòng ban";
                grdObjectValue.Properties.Columns["DepartmentName"].Caption = @"Tên phòng ban";
                grdObjectValue.Properties.Columns["DepartmentCode"].Width = 100;
                grdObjectValue.Properties.Columns["DepartmentName"].Width = 400;
                grdObjectValue.Properties.ValueMember = "DepartmentCode";
                grdObjectValue.Properties.DisplayMember = "DepartmentCode";
            }



            if (objectFieldSearchId == "InventoryItemID") //Vật tư
            {
                grdObjectValue.Properties.DataSource = Model.GetInventoryItems().OrderBy(x => x.InventoryItemCode).ToList();
                grdObjectValue.Properties.PopulateColumns();
                foreach (LookUpColumnInfo column in grdObjectValue.Properties.Columns)
                {
                    grdObjectValue.Properties.Columns[column.FieldName].Visible = false;
                }
                grdObjectValue.Properties.Columns["InventoryItemName"].Visible = true;
                grdObjectValue.Properties.Columns["InventoryItemCode"].Visible = true;

                grdObjectValue.Properties.Columns["InventoryItemName"].Width = 400;
                grdObjectValue.Properties.Columns["InventoryItemCode"].Width = 100;
                grdObjectValue.Properties.Columns["InventoryItemName"].Caption = @"Tên vật tư";
                grdObjectValue.Properties.Columns["InventoryItemCode"].Caption = @"Mã vật tư";
                grdObjectValue.Properties.ValueMember = "InventoryItemId";
                grdObjectValue.Properties.DisplayMember = "InventoryItemCode";
            }
            if (objectFieldSearchId == "FixedAssetCode") //Tài sản
            {
                grdObjectValue.Properties.DataSource = Model.GetAllFixedAssetsWithStoreProdure("uspGet_All_FixedAsset").OrderBy(x => x.FixedAssetCode).ToList();
                grdObjectValue.Properties.PopulateColumns();
                foreach (LookUpColumnInfo column in grdObjectValue.Properties.Columns)
                {
                    grdObjectValue.Properties.Columns[column.FieldName].Visible = false;
                }
                grdObjectValue.Properties.Columns["FixedAssetName"].Visible = true;
                grdObjectValue.Properties.Columns["FixedAssetCode"].Visible = true;
                grdObjectValue.Properties.Columns["FixedAssetName"].Caption = @"Tên tài sản";
                grdObjectValue.Properties.Columns["FixedAssetCode"].Caption = @"Mã tài sản";
                grdObjectValue.Properties.ValueMember = "FixedAssetCode";
                grdObjectValue.Properties.DisplayMember = "FixedAssetCode";
            }
            if (objectFieldSearchId == @"CustomerID") //Khách hàng
            {
                grdObjectValue.Properties.DataSource = Model.GetCustomers();
                grdObjectValue.Properties.PopulateColumns();
                foreach (LookUpColumnInfo column in grdObjectValue.Properties.Columns)
                {
                    grdObjectValue.Properties.Columns[column.FieldName].Visible = false;
                }
                grdObjectValue.Properties.Columns["CustomerCode"].Visible = true;
                grdObjectValue.Properties.Columns["CustomerName"].Visible = true;
                grdObjectValue.Properties.Columns["CustomerCode"].Caption = @"Mã KH";
                grdObjectValue.Properties.Columns["CustomerName"].Caption = @"Tên KH";
                grdObjectValue.Properties.Columns["CustomerCode"].Width = 100;
                grdObjectValue.Properties.Columns["CustomerName"].Width = 400;
                grdObjectValue.Properties.ValueMember = "CustomerId";
                grdObjectValue.Properties.DisplayMember = "CustomerCode";
            }
            if (objectFieldSearchId == @"VendorID") //Nhà cung cấp
            {
                grdObjectValue.Properties.DataSource = Model.GetVendors().OrderBy(x => x.VendorCode).ToList();
                grdObjectValue.Properties.PopulateColumns();
                foreach (LookUpColumnInfo column in grdObjectValue.Properties.Columns)
                {
                    grdObjectValue.Properties.Columns[column.FieldName].Visible = false;
                }
                grdObjectValue.Properties.Columns["VendorCode"].Visible = true;
                grdObjectValue.Properties.Columns["VendorName"].Visible = true;
                grdObjectValue.Properties.Columns["VendorCode"].Width = 100;
                grdObjectValue.Properties.Columns["VendorName"].Width = 400;
                grdObjectValue.Properties.Columns["VendorCode"].Caption = @"Mã NCC";
                grdObjectValue.Properties.Columns["VendorName"].Caption = @"Tên NCC";
                grdObjectValue.Properties.ValueMember = "VendorId";
                grdObjectValue.Properties.DisplayMember = "VendorCode";
            }

            if (objectFieldSearchId == @"ProjectID") //Nhà cung cấp
            {
                grdObjectValue.Properties.DataSource = Model.GetProjects().OrderBy(x => x.ProjectCode).ToList();
                grdObjectValue.Properties.PopulateColumns();
                foreach (LookUpColumnInfo column in grdObjectValue.Properties.Columns)
                {
                    grdObjectValue.Properties.Columns[column.FieldName].Visible = false;
                }
                grdObjectValue.Properties.Columns["ProjectCode"].Visible = true;
                grdObjectValue.Properties.Columns["ProjectName"].Visible = true;
                grdObjectValue.Properties.Columns["ProjectCode"].Width = 100;
                grdObjectValue.Properties.Columns["ProjectName"].Width = 400;
                grdObjectValue.Properties.Columns["ProjectCode"].Caption = @"Dự án";
                grdObjectValue.Properties.Columns["ProjectName"].Caption = @"Tên dự án";
                grdObjectValue.Properties.ValueMember = "ProjectId";
                grdObjectValue.Properties.DisplayMember = "ProjectCode";
            }

            if (objectFieldSearchId == @"EmployeeID") //Nhân viên
            {
                grdObjectValue.Properties.DataSource = Model.GetEmployees().OrderBy(x => x.EmployeeCode).ToList();
                grdObjectValue.Properties.PopulateColumns();
                foreach (LookUpColumnInfo column in grdObjectValue.Properties.Columns)
                {
                    grdObjectValue.Properties.Columns[column.FieldName].Visible = false;
                }
                grdObjectValue.Properties.Columns["EmployeeCode"].Visible = true;
                grdObjectValue.Properties.Columns["EmployeeName"].Visible = true;
                grdObjectValue.Properties.Columns["EmployeeName"].Caption = @"Tên NV";
                grdObjectValue.Properties.Columns["EmployeeCode"].Caption = @"Mã NV";
                grdObjectValue.Properties.Columns["EmployeeCode"].Width = 100;
                grdObjectValue.Properties.Columns["EmployeeName"].Width = 400;
                grdObjectValue.Properties.ValueMember = "EmployeeId";
                grdObjectValue.Properties.DisplayMember = "EmployeeCode";
            }
            if (objectFieldSearchId == "AccountingObjectID") //Đối tượng khác
            {
                grdObjectValue.Properties.DataSource = Model.GetAccountingObjects().OrderBy(x => x.AccountingObjectCode).ToList();
                grdObjectValue.Properties.PopulateColumns();
                foreach (LookUpColumnInfo column in grdObjectValue.Properties.Columns)
                {
                    grdObjectValue.Properties.Columns[column.FieldName].Visible = false;
                }
                grdObjectValue.Properties.Columns["FullName"].Visible = true;
                grdObjectValue.Properties.Columns["AccountingObjectCode"].Visible = true;
                grdObjectValue.Properties.Columns["AccountingObjectCode"].Width = 100;
                grdObjectValue.Properties.Columns["FullName"].Width = 400;
                grdObjectValue.Properties.Columns["FullName"].Caption = @"Tên đối tượng";
                grdObjectValue.Properties.Columns["AccountingObjectCode"].Caption = @"Mã đối tượng";
                grdObjectValue.Properties.ValueMember = "AccountingObjectId";
                grdObjectValue.Properties.DisplayMember = "AccountingObjectCode";
            }
            grdObjectValue.Properties.ShowFooter = false;
        }

        /// <summary>
        /// Initializes the default currencies.
        /// </summary>
        protected void InitDefaultCurrencies()
        {
            if (CurrencyLocal == CurrencyAccounting)
            {
                grdObjectValue.Properties.DataSource = new List<GridLookUpItem> { new GridLookUpItem(CurrencyAccounting, CurrencyAccounting) };
            }
            else
            {
                grdObjectValue.Properties.DataSource = new List<GridLookUpItem> { new GridLookUpItem(CurrencyAccounting, CurrencyAccounting), new GridLookUpItem(CurrencyLocal, CurrencyLocal) };
            }

            grdObjectValue.Properties.PopulateColumns();
            foreach (LookUpColumnInfo column in grdObjectValue.Properties.Columns)
            {
                grdObjectValue.Properties.Columns[column.FieldName].Visible = false;
            }
            var currencyColumns = new List<XtraColumn>
                                          {
                                              new XtraColumn
                                                  {
                                                      ColumnName = "DataValue",
                                                      ColumnVisible = false,
                                                       ColumnCaption = "Mã tiền tệ",
                                                      Alignment = HorzAlignment.Center
                                                  },
                                              new XtraColumn
                                                  {
                                                      ColumnName = "DataMember",
                                                      ColumnCaption = "Tên tiền tệ",
                                                      ColumnVisible = true,
                                                      ColumnPosition = 2,
                                                      ColumnWith = 500
                                                  }
                                          };

            foreach (var column in currencyColumns)
            {

                grdObjectValue.Properties.Columns[column.ColumnName].Visible = true;
                grdObjectValue.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                grdObjectValue.Properties.Columns[column.ColumnName].Width = column.ColumnWith;

            }
            grdObjectValue.Properties.ValueMember = "DataValue";
            grdObjectValue.Properties.DisplayMember = "DataMember";
        }

        /// <summary>
        /// Handles the Click event of the btnAdd control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string objectFieldSearchId = gridViewFieldSearch.GetFocusedRowCellValue("ObjectFieldSearchId").ToString();
            string objectFieldSearchName = gridViewFieldSearch.GetFocusedRowCellValue("ObjectFieldSearchName").ToString();

            string objectSearchValueId;
            string objectSearchValueName;
            if (txtRefNo.Visible)
            {
                objectSearchValueId = txtRefNo.Text;
                objectSearchValueName = "Số chứng từ";
                _dataForSearch.Add(new ObjectExpressionSearch(objectFieldSearchId, objectFieldSearchName,
                                                             objectSearchValueId, objectSearchValueName, "AND"));
            }

            else if (dtToDate.Visible)
            {
                objectSearchValueId = dtFromDate.EditValue.ToString();
                objectFieldSearchName = "Từ ngày";
                objectSearchValueName = dtFromDate.EditValue.ToString(); //.GetColumnValue(""); 
                _dataForSearch.Add(new ObjectExpressionSearch(objectFieldSearchId, objectFieldSearchName, objectSearchValueId, objectSearchValueName, "AND"));

                objectSearchValueId = dtToDate.EditValue.ToString();
                objectFieldSearchName = "Đến ngày";
                objectSearchValueName = dtToDate.EditValue.ToString(); //.GetColumnValue(""); 
                _dataForSearch.Add(new ObjectExpressionSearch(objectFieldSearchId, objectFieldSearchName, objectSearchValueId, objectSearchValueName, "AND"));
            }
            else if (txtgreater.Visible && objectFieldSearchId == "AmountOC")
            {
                /*Kiểm tra dữ liệu trước khi thêm vào Grid điều kiệns*/
                if (decimal.Parse(txtgreater.Text) > decimal.Parse(txtlesser.Text))
                {
                    XtraMessageBox.Show(@"Bạn nhập khoảng giới hạn tiền đang bị sai",
                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtgreater.Focus();
                    return;
                }

                objectSearchValueId = ">= " + Convert.ToDecimal(txtgreater.EditValue);
                objectFieldSearchName = "Số tiền ";
                objectSearchValueName = ">= " + txtgreater.Text;
                _dataForSearch.Add(new ObjectExpressionSearch(objectFieldSearchId, objectFieldSearchName, objectSearchValueId.Replace(',', '.'), objectSearchValueName, "AND"));

                objectSearchValueId = " <= " + Convert.ToDecimal(txtlesser.EditValue);
                objectFieldSearchName = "Số tiền";
                objectSearchValueName = " <= " + txtlesser.Text;
                _dataForSearch.Add(new ObjectExpressionSearch(objectFieldSearchId, objectFieldSearchName, objectSearchValueId.Replace(',', '.'), objectSearchValueName, "AND"));
            }
            else if (txtgreater.Visible && objectFieldSearchId == "AmountExchange")
            {
                /*Kiểm tra dữ liệu trước khi thêm vào Grid điều kiện*/
                if (decimal.Parse(txtgreater.Text) > decimal.Parse(txtlesser.Text))
                {
                    XtraMessageBox.Show(@"Bạn nhập khoảng giới hạn tiền đang bị sai",
                    ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtgreater.Focus();
                    return;
                }

                objectSearchValueId = ">= " + Convert.ToDecimal(txtgreater.EditValue);
                objectFieldSearchName = " Quy đổi";
                objectSearchValueName = ">= " + Convert.ToDecimal(txtgreater.Text);
                _dataForSearch.Add(new ObjectExpressionSearch(objectFieldSearchId, objectFieldSearchName, objectSearchValueId.Replace(',', '.'), objectSearchValueName, "AND"));

                objectSearchValueId = "<= " + Convert.ToDecimal(txtlesser.EditValue);
                objectFieldSearchName = "Quy đổi ";
                objectSearchValueName = "<= " + Convert.ToDecimal(txtlesser.Text);
                _dataForSearch.Add(new ObjectExpressionSearch(objectFieldSearchId, objectFieldSearchName, objectSearchValueId.Replace(',', '.'), objectSearchValueName, "AND"));
            }

            else
            {
                objectSearchValueId = grdObjectValue.EditValue.ToString();
                objectSearchValueName = grdObjectValue.Text; //.GetColumnValue(""); 
                _dataForSearch.Add(new ObjectExpressionSearch(objectFieldSearchId, objectFieldSearchName,
                                                                objectSearchValueId, objectSearchValueName, "AND"));
            }

            grdlookUpExpressionSearch.DataSource = _dataForSearch;
            grdlookUpExpressionSearchView.RefreshData();
            FormatGridExpression();
        }

        /// <summary>
        /// Formats the grid expression.
        /// </summary>
        private void FormatGridExpression()
        {

            var gridColumnsCollection = new List<XtraColumn> {
                                                new XtraColumn { ColumnName = "ObjectFieldSearchId", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "ObjectFieldSearchName", ColumnCaption = "Tên trường", ColumnPosition = 1, ColumnVisible = true, ColumnWith =  150 },
                                                new XtraColumn { ColumnName = "ExpressionLogic", ColumnCaption = "Chọn toán tử", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 120 },
                                                new XtraColumn { ColumnName = "ObjectSearchValueName", ColumnCaption = "Giá trị", ColumnPosition = 2, ColumnVisible = true, ColumnWith =  250 },
                                                new XtraColumn { ColumnName = "ObjectSearchValueId", ColumnVisible = false },
                                              //  new XtraColumn { ColumnName = "ParentId", ColumnVisible = false }
                                            };

            foreach (var column in gridColumnsCollection)
            {
                if (column.ColumnVisible)
                {
                    grdlookUpExpressionSearchView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                    //    grdlookUpExpressionSearchView.Columns[column.ColumnName].OptionsColumn. = column.ColumnPosition;
                    grdlookUpExpressionSearchView.Columns[column.ColumnName].Width = column.ColumnWith;
                }
                else { grdlookUpExpressionSearchView.Columns[column.ColumnName].Visible = false; }
            }
        }

        /// <summary>
        /// Handles the Click event of the btnShowRef control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnShowRef_Click(object sender, EventArgs e)
        {
            _dataForSearch = new List<ObjectExpressionSearch>();
            grdlookUpExpressionSearch.DataSource = _dataForSearch;
            grdlookUpExpressionSearchView.RefreshData();
            WhereClause = " ";
            CurrencyCode = "";
            FromDate = "";
            ToDate = "";
        }

        /// <summary>
        /// Handles the Click event of the btnSearch control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (grdlookUpExpressionSearch.DataSource != null && grdlookUpExpressionSearchView.RowCount > 0)
            {
                for (var i = 0; i < grdlookUpExpressionSearchView.RowCount; i++)
                {
                    var rowVoucherDetailData = (ObjectExpressionSearch)grdlookUpExpressionSearchView.GetRow(i);

                    #region ThangNK
                    IList<AccountModel> lstAccount = Model.GetAccounts();
                    switch (rowVoucherDetailData.ObjectFieldSearchId)
                    {
                        case "FromDate": // Ngày chứng từ
                            FromDate = dtFromDate.EditValue.ToString();
                            ToDate = dtToDate.EditValue.ToString();
                            break;
                        case "DepartmentCode": // Phòng ban
                            DepartmentCode = rowVoucherDetailData.ObjectSearchValueId;
                            break;
                        case "FixedAssetCode": // Phòng ban
                            FixedAssetCode = rowVoucherDetailData.ObjectSearchValueId;
                            break;
                        case "BudgetItemId"://Nhóm mục
                            //   currencyCode = rowVoucherDetailData.ObjectSearchValueId;
                            //WhereClause = WhereClause + "BudgetGroupID" + " = "
                            //+ "'" + rowVoucherDetailData.ObjectSearchValueId + "' " + rowVoucherDetailData.ExpressionLogic + "  ";
                            BudgetGroupCode = rowVoucherDetailData.ObjectSearchValueId;
                            break;
                        case "CurrencyCode":
                            //   currencyCode = rowVoucherDetailData.ObjectSearchValueId;
                            WhereClause = WhereClause + rowVoucherDetailData.ObjectFieldSearchId + " = "
                            + "'" + rowVoucherDetailData.ObjectSearchValueId + "' " + rowVoucherDetailData.ExpressionLogic + "  ";
                            break;
                        case "AccountNumber": //TK Nợ  --- Xác định tài khoản cha-con
                            lstAccount = lstAccount.Where(x => x.AccountCode == rowVoucherDetailData.ObjectSearchValueId && x.IsDetail)
                                          .ToList();
                            if (lstAccount.Count > 0) // Là TK ---Con
                            {
                                WhereClause = WhereClause + " " + rowVoucherDetailData.ObjectFieldSearchId + " = "
                                + "'" + rowVoucherDetailData.ObjectSearchValueId + "' " + rowVoucherDetailData.ExpressionLogic + "  ";
                            }
                            else
                            {
                                WhereClause = WhereClause + " LEFT(" + rowVoucherDetailData.ObjectFieldSearchId + "," + (rowVoucherDetailData.ObjectSearchValueId.Length) + ")" + " = "
                                + rowVoucherDetailData.ObjectSearchValueId + " " + rowVoucherDetailData.ExpressionLogic + "  ";
                            }

                            break;

                        case "CorrespondingAccountNumber"://TK Nợ xác định tài khoản cha-con có thể Rút ngăn hơn dùng như tìm chứng 
                            lstAccount = lstAccount.Where(x => x.AccountCode == rowVoucherDetailData.ObjectSearchValueId && x.IsDetail)
                                            .ToList();
                            if (lstAccount.Count > 0) // Là tk Con
                            {
                                WhereClause = WhereClause + " ((" + rowVoucherDetailData.ObjectFieldSearchId + " = "
                                + "'" + rowVoucherDetailData.ObjectSearchValueId + "') OR (JournalType = 2 AND AccountNumber =" + "'" + rowVoucherDetailData.ObjectSearchValueId + "' )) " + rowVoucherDetailData.ExpressionLogic + "  ";
                                //CorrespondingAccountNumber = 4411 AND 
                            }
                            else
                            {
                                WhereClause = WhereClause + " LEFT(" + rowVoucherDetailData.ObjectFieldSearchId + "," + (rowVoucherDetailData.ObjectSearchValueId.Length) + ")" + " = "
                                + rowVoucherDetailData.ObjectSearchValueId + " " + rowVoucherDetailData.ExpressionLogic + "  ";
                            }
                            break;
                        case "RefNo": //Tìm theo gần đúng
                            WhereClause = WhereClause + " LEFT(" + rowVoucherDetailData.ObjectFieldSearchId + "," + (rowVoucherDetailData.ObjectSearchValueId.Length) + ")" + " = "
                                + "'" + rowVoucherDetailData.ObjectSearchValueId + "' " + rowVoucherDetailData.ExpressionLogic + "  ";
                            break;
                        case "AmountOC":
                            WhereClause = " " + WhereClause + rowVoucherDetailData.ObjectFieldSearchId + rowVoucherDetailData.ObjectSearchValueId
                                + " " + rowVoucherDetailData.ExpressionLogic + "  ";
                            break;
                        case "AmountExChange":
                            WhereClause = " " + WhereClause + rowVoucherDetailData.ObjectFieldSearchId + rowVoucherDetailData.ObjectSearchValueId
                                + " " + rowVoucherDetailData.ExpressionLogic + "  ";
                            break;
                        case "RefTypeID":
                            if (int.Parse(rowVoucherDetailData.ObjectSearchValueId) == 700)
                            {

                                WhereClause = " " + WhereClause + "(RefTypeID = 700 OR RefTypeID = 701 OR RefTypeID = 702)" + " " + rowVoucherDetailData.ExpressionLogic + "  ";

                            }
                            else
                            {
                                WhereClause = " " + WhereClause + rowVoucherDetailData.ObjectFieldSearchId + " = "
                                + " " + rowVoucherDetailData.ObjectSearchValueId + " " + rowVoucherDetailData.ExpressionLogic + "  ";

                            }
                            break;
                        case "BudgetSourceCode":
                            WhereClause = WhereClause + " LEFT(" + rowVoucherDetailData.ObjectFieldSearchId + "," + (rowVoucherDetailData.ObjectSearchValueId.Length) + ")" + " = "
                                + rowVoucherDetailData.ObjectSearchValueId + " " + rowVoucherDetailData.ExpressionLogic + "  ";
                            break;
                        case "BudgetItemCode":
                            WhereClause = WhereClause + " LEFT(" + rowVoucherDetailData.ObjectFieldSearchId + "," + (rowVoucherDetailData.ObjectSearchValueId.Length) + ")" + " = "
                                + rowVoucherDetailData.ObjectSearchValueId + " " + rowVoucherDetailData.ExpressionLogic + "  ";
                            break;
                        case "AmountExchange":
                            WhereClause = " " + WhereClause + rowVoucherDetailData.ObjectFieldSearchId + " " + rowVoucherDetailData.ObjectSearchValueId + " " + rowVoucherDetailData.ExpressionLogic + "  ";
                            break;
                        default:
                            WhereClause = " " + WhereClause + rowVoucherDetailData.ObjectFieldSearchId + " = "
                            + " " + rowVoucherDetailData.ObjectSearchValueId + " " + rowVoucherDetailData.ExpressionLogic + "  ";
                            break;
                    }

                    #endregion
                }
                if (grdlookUpExpressionSearchView.RowCount == 0)
                {
                    WhereClause = " 1 = 1 ";
                }
            }

            SetDataForResult();
        }

        /// <summary>
        /// Sets the data for result.
        /// </summary>
        private void SetDataForResult()
        {
            var getSearch = Model.GetSearch(WhereClause, FromDate, ToDate, CurrencyCode, DepartmentCode, FixedAssetCode, BudgetGroupCode);
            grdList.DataSource = getSearch;
            if (getSearch != null && getSearch.Count > 0)
            {
                FormatGrdList();
            }
            else
                MessageBox.Show(ResourceHelper.GetResourceValueByName("ResNoticeNotRecords"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Information);

            WhereClause = "";
            CurrencyCode = "";
            FromDate = "";
            ToDate = "";
            DepartmentCode = "";
            FixedAssetCode = "";
            BudgetGroupCode = "";

        }

        /// <summary>
        /// Formats the GRD list.
        /// </summary>
        private void FormatGrdList()
        {
            var gridColumnsCollection = new List<XtraColumn>()
            {
                new XtraColumn { ColumnName = "RefId", ColumnVisible = false },
                new XtraColumn { ColumnName = "PostedDate", ColumnCaption = "Ngày ghi sổ", ColumnPosition = 1, ColumnVisible = true, ColumnWith =  90 },
                new XtraColumn { ColumnName = "RefNo", ColumnCaption = "Số CT", ColumnPosition = 2, ColumnVisible = true, ColumnWith =  90 },
                new XtraColumn { ColumnName = "RefDate", ColumnCaption = "Ngày CT", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 90 },
                new XtraColumn { ColumnName = "AccountNumber", ColumnCaption = "TK Nợ", ColumnPosition = 4, ColumnVisible = true, ColumnWith =  70 },
                new XtraColumn { ColumnName = "CorrespondingAccountNumber", ColumnCaption = "TK Có", ColumnPosition = 5, ColumnVisible = true, ColumnWith =  70 },
                new XtraColumn { ColumnName = "CurrencyCode", ColumnCaption = "Loại tiền", ColumnPosition = 6, ColumnVisible = true, ColumnWith =  70 },
                new XtraColumn { ColumnName = "ExchangeRate", ColumnCaption = "Tỷ giá", ColumnPosition = 7, ColumnVisible = true, ColumnWith =  70 },
                new XtraColumn { ColumnName = "JournalMemo", ColumnCaption = "Diễn giải", ColumnPosition = 8, ColumnVisible = true, ColumnWith =  180 },                                                new XtraColumn { ColumnName = "TotalAmount", ColumnCaption = "Số tiền",ColumnType =UnboundColumnType.Decimal, ColumnPosition = 8, ColumnVisible = true, ColumnWith =  120 },
                new XtraColumn { ColumnName = "AmountExchange", ColumnCaption = "Số tiền qui đổi",ColumnType = UnboundColumnType.Decimal, ColumnPosition = 9, ColumnVisible = true, ColumnWith =  120 },
                new XtraColumn { ColumnName = "BudgetSourceCode", ColumnCaption = "Nguồn vốn", ColumnPosition = 10, ColumnVisible = true, ColumnWith =  70 },
                new XtraColumn { ColumnName = "BudgetItemCode", ColumnCaption = "Mục/Tiểu mục", ColumnPosition = 11, ColumnVisible = true, ColumnWith =  90 },
                new XtraColumn { ColumnName = "BudgetGroupCode", ColumnCaption = "Nhóm mục", ColumnPosition = 12, ColumnVisible = true, ColumnWith =  90 },
                new XtraColumn { ColumnName = "VendorCode", ColumnCaption = "Nhà cung cấp", ColumnPosition = 13, ColumnVisible = true, ColumnWith = 90 },
                new XtraColumn { ColumnName = "EmployeeCode", ColumnCaption = "Nhân viên", ColumnPosition = 14, ColumnVisible = true, ColumnWith =  90 },
                new XtraColumn { ColumnName = "AccountingObjectCode", ColumnCaption = "Đối tượng khác", ColumnPosition = 15, ColumnVisible = true, ColumnWith =  90 },
                new XtraColumn { ColumnName = "ProjectCode", ColumnCaption = "Dự án", ColumnPosition = 16, ColumnVisible = true, ColumnWith =  90 },
                new XtraColumn { ColumnName = "InventoryItemCode", ColumnCaption = "Vật tư", ColumnPosition = 17, ColumnVisible = true, ColumnWith =  90 },
                new XtraColumn { ColumnName = "VoucherTypeName", ColumnCaption = "Nghiệp vụ", ColumnPosition = 18, ColumnVisible = true, ColumnWith =  90 },
                new XtraColumn { ColumnName = "RefTypeName", ColumnCaption = "Chứng từ", ColumnPosition = 19, ColumnVisible = true, ColumnWith =  90 },
                new XtraColumn { ColumnName = "DepartmentCode", ColumnCaption = "Phòng ban", ColumnPosition = 20, ColumnVisible = true, ColumnWith =  90 },
                new XtraColumn { ColumnName = "FixedAssetCode", ColumnCaption = "Tài sản", ColumnPosition = 21, ColumnVisible = true, ColumnWith =  90 },
                //Phần này phần ẩn
                new XtraColumn { ColumnName = "CustomerCode", ColumnCaption = "Khách hàng", ColumnPosition = 11, ColumnVisible = false, ColumnWith =  90 },
                new XtraColumn { ColumnName = "CustomerId", ColumnCaption = "Khách hàng", ColumnPosition = 11, ColumnVisible = false, ColumnWith =  90 },
                new XtraColumn { ColumnName = "VendorId", ColumnCaption = "Nhà cung cấp", ColumnPosition = 12, ColumnVisible = false, ColumnWith =  90 },
                new XtraColumn { ColumnName = "EmployeeId", ColumnCaption = "Nhân viên", ColumnPosition = 13, ColumnVisible = false, ColumnWith =  90 },
                new XtraColumn { ColumnName = "AccountingObjectId", ColumnCaption = "Đối tượng khác", ColumnPosition = 14, ColumnVisible = false, ColumnWith =  90 },
                new XtraColumn { ColumnName = "ProjectId", ColumnCaption = "Dự án", ColumnPosition = 14, ColumnVisible = false, ColumnWith =  90 },
                new XtraColumn { ColumnName = "VoucherTypeId", ColumnCaption = "Dự án", ColumnPosition = 14, ColumnVisible = false, ColumnWith =  90 },
                new XtraColumn { ColumnName = "InventoryItemId", ColumnCaption = "Dự án", ColumnPosition = 14, ColumnVisible = false, ColumnWith =  90 },
                new XtraColumn { ColumnName = "RefTypeId", ColumnVisible = false },
            };

            foreach (var column in gridColumnsCollection)
            {
                if (column.ColumnVisible)
                {
                    gridView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                    gridView.Columns[column.ColumnName].Width = column.ColumnWith;
                    gridView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                    gridView.Columns[column.ColumnName].UnboundType = column.ColumnType;
                }
                else { gridView.Columns[column.ColumnName].Visible = false; }
            }
            SetNumericFormatControl(gridView, true);

        }

        /// <summary>
        /// Sets the numeric format control.
        /// LINHMC add repositoryCurrencyCalcEdit.Precision = int.Parse(DBOptionHelper.UnitPriceDecimalDigits);
        /// quy định số chữ số thập phân đằng sau dấu phẩy khi dropdown RepositoryItemCalcEdit
        /// </summary>
        /// <param name="grdView">The GRD view.</param>
        /// <param name="isSummary">if set to <c>true</c> [is summary].</param>
        public void SetNumericFormatControl(GridView grdView, bool isSummary)
        {
            var repositoryCurrencyCalcEdit = new RepositoryItemCalcEdit { AllowMouseWheel = false };
            var repositoryNumberCalcEdit = new RepositoryItemCalcEdit { AllowMouseWheel = false };

            foreach (GridColumn oCol in grdView.Columns)
            {
                if (!oCol.Visible) continue;
                switch (oCol.UnboundType)
                {
                    case UnboundColumnType.Decimal:
                        repositoryCurrencyCalcEdit.Mask.MaskType = MaskType.Numeric;
                        repositoryCurrencyCalcEdit.Mask.EditMask = @"c" + _dbOptionHelper.CurrencyDecimalDigits;
                        repositoryCurrencyCalcEdit.Mask.Culture = Thread.CurrentThread.CurrentCulture;
                        repositoryCurrencyCalcEdit.Mask.UseMaskAsDisplayFormat = true;
                        repositoryCurrencyCalcEdit.Precision = int.Parse(_dbOptionHelper.CurrencyDecimalDigits);
                        oCol.ColumnEdit = repositoryCurrencyCalcEdit;
                        if (isSummary)
                        {
                            oCol.SummaryItem.SummaryType = SummaryItemType.Sum;
                            oCol.SummaryItem.DisplayFormat = GlobalVariable.CurrencyDisplayString;
                            oCol.SummaryItem.Format = Thread.CurrentThread.CurrentCulture;
                        }
                        break;

                    case UnboundColumnType.Integer:
                        repositoryNumberCalcEdit.Mask.MaskType = MaskType.Numeric;
                        repositoryNumberCalcEdit.Mask.EditMask = @"n0";
                        repositoryNumberCalcEdit.Mask.UseMaskAsDisplayFormat = true;
                        repositoryNumberCalcEdit.Mask.Culture = Thread.CurrentThread.CurrentCulture;
                        oCol.ColumnEdit = repositoryNumberCalcEdit;

                        if (isSummary)
                        {
                            oCol.SummaryItem.SummaryType = SummaryItemType.Sum;
                            oCol.SummaryItem.DisplayFormat = GlobalVariable.NumericDisplayString;
                            oCol.SummaryItem.Format = Thread.CurrentThread.CurrentCulture;
                        }
                        break;

                    case UnboundColumnType.DateTime:
                        oCol.DisplayFormat.FormatString =
                            Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
                        oCol.DisplayFormat.Format = Thread.CurrentThread.CurrentCulture.DateTimeFormat;
                        break;
                }
                if (oCol.FieldName == "JournalMemo")
                {
                    oCol.SummaryItem.SetSummary(SummaryItemType.Custom, "Tổng cộng");
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the grdList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void grdList_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Sets the accounts.
        /// </summary>
        /// <value>The accounts.</value>
        public IList<AccountModel> Accounts
        {
            set { _accounts = value; }
        }

        /// <summary>
        /// Handles the Click event of the btnExportToExcel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            gridView.OptionsPrint.AutoWidth = false;
            gridView.BestFitColumns();
            gridView.ExportToXls(@"Search.xls");
            Process.Start("Search.xls");
        }

        /// <summary>
        /// Handles the Click event of the btnPrint control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnPrint_Click(object sender, EventArgs e)
        {


            //// Open the Preview window.
            gridView.OptionsPrint.AutoWidth = false;
            gridView.BestFitColumns();

            // Create a PrintingSystem component. 
            var ps = new PrintingSystem();
            // Create a link that will print a control. 
            var link = new PrintableComponentLink(ps)
            {
                Component = grdList,
                Landscape = true,
                PaperKind = System.Drawing.Printing.PaperKind.A3
            };

            link.CreateReportHeaderArea += printableComponentLink_CreateReportHeaderArea;
            // Generate the report. 
            link.CreateDocument();
            // Show the report. 
            link.ShowPreview();
        }

        /// <summary>
        /// Handles the CreateReportHeaderArea event of the printableComponentLink control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="CreateAreaEventArgs"/> instance containing the event data.</param>
        private void printableComponentLink_CreateReportHeaderArea(object sender, CreateAreaEventArgs e)
        {
            const string reportHeader = "KẾT QUẢ TÌM KIẾM";
            e.Graph.StringFormat = new BrickStringFormat(StringAlignment.Center);
            e.Graph.Font = new Font("Tahoma", 14, FontStyle.Bold);
            var rec = new RectangleF(0, 0, e.Graph.ClientPageSize.Width, 50);
            e.Graph.DrawString(reportHeader, Color.Black, rec, DevExpress.XtraPrinting.BorderSide.None);
        }

        /// <summary>
        /// Handles the DoubleClick event of the grdList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void grdList_DoubleClick(object sender, EventArgs e)
        {
            _accountsPresenter.Display();
            if ((gridView.GetFocusedRowCellValue("RefTypeId") != null))
            {
                bool flag = true;
                int refTypeId = int.Parse(gridView.GetFocusedRowCellValue("RefTypeId").ToString());
                //Thử phiếu thu
                string objectFieldSearchId = gridView.GetFocusedRowCellValue("RefId").ToString();
                var frmDetail = new FrmXtraBaseVoucherDetail();
                switch (refTypeId)
                {
                    case 200:// phiếu thu
                        frmDetail = new FrmXtraVoucherReceiptDetail();
                        break;
                    case 400: //Nhập kho
                        frmDetail = new FrmXtraInputInventoryDetail();
                        break;
                    case 401: //Xuaats kho
                        frmDetail = new FrmXtraOutputInventoryDetail();
                        break;
                    case 110: //Dự toán thu
                        frmDetail = new FrmXtraReceiptEstimateDetail();
                        break;
                    case 120: //Dự toán chi
                        frmDetail = new FrmXtraPaymentEstimateDetail();
                        break;
                    case 201: //phiếu chi
                        frmDetail = new FrmXtraFormPaymentVoucherDetail();
                        break;
                    case 301: //Giấy báo nợ
                        frmDetail = new FrmXtraPaymentDepositDetail();
                        break;
                    case 300: //Giấy báo có
                        frmDetail = new FrmXtraReceiptDepositDetail();
                        break;
                    //case 402: //Chuyển kho
                    //    frmDetail = new FrmXtraOutputInventoryDetail();
                    //    break;
                    case 500: //Ghi tăng TSCĐ
                        frmDetail = new FrmXtraFormFAIncrementDetail();
                        break;
                    case 501: //Ghi giảm TSCĐ
                        frmDetail = new FrmXtraFormFADecrementDetail();
                        break;
                    case 502: //Khấu hao TSCĐ
                        frmDetail = new FrmXtraFormFAArmortizationDetail();
                        break;
                    //case 503: //Đánh giá lại TSCĐ
                    //    frmDetail = new FrmXtraOutputInventoryDetail();
                    //    break;

                    case 600: //CT lương
                        string accountNumber = gridView.GetFocusedRowCellValue("CorrespondingAccountNumber").ToString();
                        if (accountNumber.Contains("1112"))
                            frmDetail = new FrmXtraFormPaymentVoucherDetail();
                        else
                            frmDetail = new FrmXtraPaymentDepositDetail();
                        //frmDetail = new FrmXtraOutputInventoryDetail();
                        break;
                    case 700: //Số dư ban đầu TK 
                        flag = false;
                        //frmDetail = new FrmXtraOpeningAccountEntryDetail();
                        break;
                    case 701: //Số dư ban đầu VT 
                        flag = false;
                        // frmDetail = new FrmXtraOpeningInventoryEntryDetail();
                        break;
                    case 900: //Chứng từ chung
                        frmDetail = new FrmXtraGeneralVoucherDetail();
                        break;
                    case 901: //Chứng từ phân bổ
                        frmDetail = new FrmXtraGenvervoucherCapitalAllocateDetail();
                        // frmDetail.
                        break;

                    case 902: //Chứng kết chuyển
                        frmDetail = new FrmXtraAccountTranferVoucherDetail();
                        // frmDetail.
                        break;
                }

                //    var frmDetail = new FrmXtraPaymentDepositDetail();//đây là giấy báo nợ!!!
                if (flag)
                {
                    frmDetail.ActionMode = ActionModeVoucherEnum.None;
                    frmDetail.KeyValue = objectFieldSearchId;
                    frmDetail.MasterBindingSource = new BindingSource();
                    frmDetail.CurrentPosition = 1;
                    frmDetail.ShowDialog();
                }

                else
                {
                    //Số dư ban đầu
                    var frmDetail1 = new FrmXtraBaseTreeDetail();
                    if (refTypeId == 700)
                    {
                        frmDetail1 = new FrmXtraOpeningAccountEntryDetail();
                    }
                    if (refTypeId == 701)
                    {
                        frmDetail1 = new FrmXtraOpeningInventoryEntryDetail();
                    }
                    frmDetail1.KeyFieldName = "AccountId";
                    frmDetail1.ParentName = "ParentId";
                    frmDetail1.ActionMode = ActionModeEnum.None;
                    string accountCode = gridView.GetFocusedRowCellValue("AccountNumber").ToString();
                    if (accountCode == null || accountCode == "")
                        accountCode = gridView.GetFocusedRowCellValue("CorrespondingAccountNumber").ToString();

                    var account = (from accountModel in _accounts where accountModel.AccountCode == accountCode select accountModel).FirstOrDefault();
                    if (account != null)
                    {
                        frmDetail1.KeyValue = Convert.ToString(account.AccountId);
                    }

                    frmDetail1.ShowDialog();
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the simpleButton2 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnGoToVoucher_Click(object sender, EventArgs e)
        {

            _accountsPresenter.Display();
            if ((gridView.GetFocusedRowCellValue("RefTypeId") != null))
            {
                bool flag = true;
                int refTypeId = int.Parse(gridView.GetFocusedRowCellValue("RefTypeId").ToString());
                //Thử phiếu thu
                string objectFieldSearchId = gridView.GetFocusedRowCellValue("RefId").ToString();
                var frmDetail = new FrmXtraBaseVoucherDetail();
                switch (refTypeId)
                {
                    case 200:// phiếu thu
                        frmDetail = new FrmXtraVoucherReceiptDetail();
                        break;
                    case 400: //Nhập kho
                        frmDetail = new FrmXtraInputInventoryDetail();
                        break;
                    case 401: //Xuaats kho
                        frmDetail = new FrmXtraOutputInventoryDetail();
                        break;
                    case 110: //Dự toán thu
                        frmDetail = new FrmXtraReceiptEstimateDetail();
                        break;
                    case 120: //Dự toán chi
                        frmDetail = new FrmXtraPaymentEstimateDetail();
                        break;
                    case 201: //phiếu chi
                        frmDetail = new FrmXtraFormPaymentVoucherDetail();
                        break;
                    case 301: //Giấy báo nợ
                        frmDetail = new FrmXtraPaymentDepositDetail();
                        break;
                    case 300: //Giấy báo có
                        frmDetail = new FrmXtraReceiptDepositDetail();
                        break;
                    //case 402: //Chuyển kho
                    //    frmDetail = new FrmXtraOutputInventoryDetail();
                    //    break;
                    case 500: //Ghi tăng TSCĐ
                        frmDetail = new FrmXtraFormFAIncrementDetail();
                        break;
                    case 501: //Ghi giảm TSCĐ
                        frmDetail = new FrmXtraFormFADecrementDetail();
                        break;
                    case 502: //Khấu hao TSCĐ
                        frmDetail = new FrmXtraFormFAArmortizationDetail();
                        break;
                    //case 503: //Đánh giá lại TSCĐ
                    //    frmDetail = new FrmXtraOutputInventoryDetail();
                    //    break;

                    case 600: //CT lương

                        //frmDetail = new FrmXtraOutputInventoryDetail();
                        return;
                    case 700: //Số dư ban đầu TK 
                        flag = false;
                        // frmDetail = new FrmXtraOpeningAccountEntryDetail();
                        break;
                    case 701: //Số dư ban đầu VT 
                        flag = false;
                        // frmDetail = new FrmXtraOpeningAccountEntryDetail();
                        break;
                    case 900: //Chứng từ chung
                        frmDetail = new FrmXtraGeneralVoucherDetail();
                        break;
                    case 901: //Chứng từ phân bổ
                        frmDetail = new FrmXtraGenvervoucherCapitalAllocateDetail();
                        break;
                }

                //    var frmDetail = new FrmXtraPaymentDepositDetail();//đây là giấy báo nợ!!!
                if (flag)
                {
                    frmDetail.ActionMode = ActionModeVoucherEnum.None;
                    frmDetail.KeyValue = objectFieldSearchId;
                    frmDetail.MasterBindingSource = new BindingSource();
                    frmDetail.CurrentPosition = 1;
                    frmDetail.ShowDialog();
                }

                else
                {
                    //Số dư ban đầu
                    var frmDetail1 = new FrmXtraBaseTreeDetail();
                    if (refTypeId == 700)
                    {
                        frmDetail1 = new FrmXtraOpeningAccountEntryDetail();
                    }
                    if (refTypeId == 701)
                    {
                        frmDetail1 = new FrmXtraOpeningInventoryEntryDetail();
                    }
                    frmDetail1.KeyFieldName = "AccountId";
                    frmDetail1.ParentName = "ParentId";
                    frmDetail1.ActionMode = ActionModeEnum.None;

                    var account = (from accountModel in _accounts where accountModel.AccountCode == gridView.GetFocusedRowCellValue("AccountNumber").ToString() select accountModel).FirstOrDefault();
                    if (account != null) frmDetail1.KeyValue = Convert.ToString(account.AccountId);
                    frmDetail1.ShowDialog();
                }
            }
        }

        private void grdlookUpExpressionSearchView_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            var view = sender as GridView;
            if (view != null)
            {
                var hitInfo = view.CalcHitInfo(e.Point);
                if (hitInfo.InRow)
                {
                    view.FocusedRowHandle = hitInfo.RowHandle;
                    popupMenu1.ShowPopup(grdlookUpExpressionSearch.PointToScreen(e.Point));
                }
            }
        }

        /// <summary>
        /// Deletes the row item.
        /// </summary>
        protected virtual void DeleteRowItem()
        {
            grdlookUpExpressionSearchView.DeleteSelectedRows();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DeleteRowItem();
            //grdlookUpExpressionSearchView.DeleteRow(grdlookUpExpressionSearchView.se);
        }
    }



    /// <summary>
    /// ObjectCategory
    /// </summary>
    public class ObjectFieldSearch
    {
        /// <summary>
        /// Gets or sets the object category identifier.
        /// </summary>
        /// <value>The object category identifier.</value>
        public string ObjectFieldSearchId { get; set; }

        /// <summary>
        /// Gets or sets the name of the object category.
        /// </summary>
        /// <value>The name of the object category.</value>
        public string ObjectFieldSearchName { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectFieldSearch" /> class.
        /// </summary>
        /// <param name="objectFieldSearchId">The object field search identifier.</param>
        /// <param name="objectFieldSearchName">Name of the object field search.</param>
        public ObjectFieldSearch(string objectFieldSearchId, string objectFieldSearchName)
        {
            ObjectFieldSearchId = objectFieldSearchId;
            ObjectFieldSearchName = objectFieldSearchName;
        }
    }

    /// <summary>
    /// ObjectCategory
    /// </summary>
    public class ObjectExpressionSearch
    {
        /// <summary>
        /// Gets or sets the object category identifier.
        /// </summary>
        /// <value>The object category identifier.</value>
        public string ObjectFieldSearchId { get; set; }

        /// <summary>
        /// Gets or sets the object category identifier.
        /// </summary>
        /// <value>The object category identifier.</value>
        public string ObjectFieldSearchName { get; set; }

        /// <summary>
        /// Gets or sets the name of the object category.
        /// </summary>
        /// <value>The name of the object category.</value>
        public string ObjectSearchValueId { get; set; }

        /// <summary>
        /// Gets or sets the name of the object category.
        /// </summary>
        /// <value>The name of the object category.</value>
        public string ObjectSearchValueName { get; set; }

        /// <summary>
        /// Gets or sets the expression logic.
        /// </summary>
        /// <value>The expression logic.</value>
        public string ExpressionLogic { get; set; } //0: và 1: hoặc

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectExpressionSearch" /> class.
        /// </summary>
        /// <param name="objectFieldSearchId">The object field search identifier.</param>
        /// <param name="objectFieldSearchName">Name of the object field search.</param>
        /// <param name="objectSearchValueId">The object search value identifier.</param>
        /// <param name="objectSearchValueName">Name of the object search value.</param>
        /// <param name="expressionLogic">The expression logic.</param>
        public ObjectExpressionSearch(string objectFieldSearchId, string objectFieldSearchName, string objectSearchValueId, string objectSearchValueName, string expressionLogic)
        {
            ObjectFieldSearchId = objectFieldSearchId;
            ObjectFieldSearchName = objectFieldSearchName;
            ObjectSearchValueId = objectSearchValueId;
            ObjectSearchValueName = objectSearchValueName;
            ExpressionLogic = expressionLogic;
        }

    }
}
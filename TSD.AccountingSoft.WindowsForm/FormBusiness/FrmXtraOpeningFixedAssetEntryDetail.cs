using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TSD.AccountingSoft.Session;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Model.BusinessObjects.Opening;
using TSD.AccountingSoft.Presenter.Dictionary.Account;
using TSD.AccountingSoft.Presenter.Dictionary.FixedAsset;
using TSD.AccountingSoft.Presenter.OpeningFixedAsset;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.View.OpeningFixedAssetEntry;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace TSD.AccountingSoft.WindowsForm.FormBusiness
{
    public partial class FrmXtraOpeningFixedAssetEntryDetail : FrmXtraBaseTreeDetail, IOpeningFixedAssetEntriesView, IAccountsView, IFixedAssetsView
    {

        #region Presenter

        private readonly OpeningFixedAssetEntriesPresenter _openingFixedAssetEntriesPresenter;
        private readonly AccountsPresenter _accountsPresenter;
        private readonly OpeningFixedAssetEntryPresenter _openingFixedAssetEntryPresenter;
        private IList<AccountModel> _accounts;
        private AccountModel _account;
        private IList<OpeningFixedAssetEntryModel> _openingFixedAssetEntries;
        private OpeningFixedAssetEntryModel _openingFixedAssetEntryModel;
        private readonly FixedAssetsPresenter _fixedAssetsPresenter;

        #endregion

        #region Repository Controls

        /// <summary>
        /// The _cbo currency code
        /// </summary>
        private RepositoryItemComboBox _cboCurrencyCode;
        /// <summary>
        /// The _calc edit exchange rate
        /// </summary>
        private RepositoryItemCalcEdit _calcEditExchangeRate;
        /// <summary>
        /// The _RPS account number
        /// </summary>
        private RepositoryItemGridLookUpEdit _rpsFixedAsset;
        /// <summary>
        /// The _RPS account number view
        /// </summary>
        private GridView _rpsFixedAssetView;
        /// <summary>
        /// The _RPS corresponding account number
        /// </summary>
        private RepositoryItemGridLookUpEdit _rpsOpeningFixedAssetEntry;
        /// <summary>
        /// The _RPS corresponding account number view
        /// </summary>
        private GridView _rpsOpeningFixedAssetEntriesView;

        #endregion

        #region Function Overrides

        public FrmXtraOpeningFixedAssetEntryDetail()
        {
            InitializeComponent();
            _accountsPresenter = new AccountsPresenter(this);
            _openingFixedAssetEntriesPresenter = new OpeningFixedAssetEntriesPresenter(this);
            _fixedAssetsPresenter = new FixedAssetsPresenter(this);
            // _openingInventoryEntriesPresenter = new OpeningInventoryEntriesPresenter(this);
        }

        /// <summary>
        /// Initializes the data.
        /// </summary>
        protected override void InitData()
        {
            _accountsPresenter.Display();
            _account = (from accountModel in _accounts where accountModel.AccountId == int.Parse(KeyValue) select accountModel).FirstOrDefault();
            _cboCurrencyCode.Items.Add(CurrencyLocal);
            _cboCurrencyCode.Items.Add(CurrencyAccounting);
            _fixedAssetsPresenter.Display();
            //_openingFixedAssetEntriesPresenter.Display();
            //_openingFixedAssetEntryModel = (from openingFixedAssetEntryModel in _openingFixedAssetEntries where openingFixedAssetEntryModel.AccountId == int.Parse(KeyValue) select openingFixedAssetEntryModel).FirstOrDefault();
            // if (_account == null) return;
            // _openingInventoryEntryPresenter.Display(_account.AccountCode);

            _openingFixedAssetEntriesPresenter.Display(_account.AccountCode);
            Text = @"Thông tin số dư ban đầu cho tài khoản " + _account.AccountCode;


            //_inventoryItemsPresenter.Display(); //Display
            //_stocksPresenter.DisplayActive(true)

        }

        /// <summary>
        /// Focuses the control.
        /// </summary>
        protected override void InitControls()
        {

            _cboCurrencyCode = new RepositoryItemComboBox();

            gridViewDetail.OptionsView.ShowFooter = true;
            //RepositoryItemCalcEdit ExchangeRate
            _calcEditExchangeRate = new RepositoryItemCalcEdit();
            _calcEditExchangeRate.EditFormat.FormatType = FormatType.Numeric;
            _calcEditExchangeRate.EditMask = @"F" + ExchangeRateDecimalDigits;

            _rpsFixedAsset = new RepositoryItemGridLookUpEdit { NullText = "" };
            _rpsFixedAssetView = new GridView();
            _rpsFixedAsset.View = _rpsFixedAssetView;
            _rpsFixedAsset.TextEditStyle = TextEditStyles.Standard;
            _rpsFixedAsset.ShowFooter = false;

            _rpsOpeningFixedAssetEntry = new RepositoryItemGridLookUpEdit { NullText = "" };
            _rpsOpeningFixedAssetEntriesView = new GridView();
            _rpsOpeningFixedAssetEntry.View = _rpsOpeningFixedAssetEntriesView;
            _rpsOpeningFixedAssetEntry.TextEditStyle = TextEditStyles.Standard;
            _rpsOpeningFixedAssetEntry.ShowFooter = false;


            ////RepositoryItemGridLookUpEdit AccountingObject
            //_gridLookUpEditAccountingObjectView = new GridView();
            //_gridLookUpEditAccountingObjectView.OptionsView.ColumnAutoWidth = false;
            //_gridLookUpEditAccountingObject = new RepositoryItemGridLookUpEdit
            //{
            //    NullText = "",
            //    View = _gridLookUpEditAccountingObjectView,
            //    TextEditStyle = TextEditStyles.Standard,
            //    PopupResizeMode = ResizeMode.FrameResize,
            //    PopupFormSize = new Size(500, 200),
            //    ShowFooter = false
            //};
            //_gridLookUpEditAccountingObject.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
            //_gridLookUpEditAccountingObject.View.OptionsView.ShowIndicator = false;
            //_gridLookUpEditAccountingObject.View.BestFitColumns();
        }

        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns></returns>
        protected override bool ValidData()
        {
            return true;
        }

        /// <summary>
        /// Saves the data.
        /// </summary>
        /// <returns></returns>
        protected override int SaveData()
        {
            //if (AccountNumber == null)
            //    AccountNumber = _account.AccountCode;
            //if (RefTypeId == 0)
            //    RefTypeId = 700;
            if (PostedDate.Year.Equals(1))
                PostedDate = (DateTime.Parse(GlobalVariable.SystemDate)).AddDays(-1);
            gridViewDetail.CloseEditor();
            if (gridViewDetail.UpdateCurrentRow())
                return (int)_openingFixedAssetEntriesPresenter.Save();
            return 0;
        }

        #endregion

        public IList<OpeningFixedAssetEntryModel> OpeningFixedAssetEntries
        {
            get
            {
                var openingFixedAssetEntryDetails = new List<OpeningFixedAssetEntryModel>();
                if (gridViewDetail.DataSource != null && gridViewDetail.RowCount > 0)
                {
                    for (var i = 0; i < gridViewDetail.RowCount; i++)
                    {
                        if (gridViewDetail.GetRow(i) != null)
                        {
                            openingFixedAssetEntryDetails.Add(new OpeningFixedAssetEntryModel
                            {
                                RefTypeId = 702,
                                PostedDate = DateTime.Parse(GlobalVariable.SystemDate).AddDays(-1),
                                CurrencyCode = (string)gridViewDetail.GetRowCellValue(i, "CurrencyCode"),
                                ExchangeRate = (decimal)gridViewDetail.GetRowCellValue(i, "ExchangeRate"),

                                //FixedAssetId = View.FixedAssetId,
                                //DepartmentId = View.DepartmentId,
                                //LifeTime = View.LifeTime,
                                //IncrementDate = View.IncrementDate,
                                //Unit = View.Unit,
                                //UsedDate = View.UsedDate,
                                //OrgPriceAccount = View.OrgPriceAccount,
                                //OrgPriceDebitAmount = View.OrgPriceDebitAmount,
                                //OrgPriceDebitAmountUSD = View.OrgPriceDebitAmountUSD,
                                //DepreciationAccount = View.DepreciationAccount,
                                //DepreciationCreditAmount = View.DepreciationCreditAmount,
                                //DepreciationCreditAmountUSD = View.DepreciationCreditAmountUSD,
                                //CapitalAccount = View.CapitalAccount,
                                //CapitalCreditAmount = View.CapitalCreditAmount,
                                //CapitalCreditAmountUSD = View.CapitalCreditAmountUSD,
                                //RemainingAmount = View.RemainingAmount,
                                //RemainingAmountUSD = View.RemainingAmountUSD,
                                //BudgetChapterCode = View.BudgetChapterCode,
                                //Description = View.Description,
                                //Quantity = View.Quantity
                            });
                        }
                    }
                }
                return openingFixedAssetEntryDetails.ToList();
            }
            set
            {
                bindingSourceDetail.DataSource = value;
                gridViewDetail.PopulateColumns(value);

                var gridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn {ColumnName = "RefId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "RefTypeId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "PostedDate", ColumnVisible = false},
                        new XtraColumn {ColumnName = "AccountNumber", ColumnVisible = false},
                        new XtraColumn{ColumnName = "ExchangeRate",
                        ColumnCaption = "Tỷ giá",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 100,
                        RepositoryControl = _calcEditExchangeRate
                     },
                  
                        new XtraColumn {ColumnName = "AccountId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "RefNo", ColumnVisible = false},
                        new XtraColumn {ColumnName = "ParentId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "AccountName", ColumnVisible = false},

                        new XtraColumn{ ColumnName = "CurrencyCode",
                        ColumnCaption = "Loại tiền tệ",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 100,
                        RepositoryControl = _cboCurrencyCode},

                        new XtraColumn{ColumnName = "ExchangeRate",
                        ColumnCaption = "Tỷ giá",
                        ColumnPosition = 2,
                        ColumnVisible = true,
                        ColumnWith = 100,
                        RepositoryControl = _calcEditExchangeRate
                     },
                     new XtraColumn
                    {
                        ColumnName = "BudgetSourceCode",
                        ColumnCaption = "Nguồn vốn",
                        ColumnPosition = 3,
                        ColumnVisible = true,
                        ColumnWith = 130
                    },
                  
                     new XtraColumn
                    {
                        ColumnName = "FixedAssetId",
                        ColumnCaption = "TSCĐ",
                        ColumnPosition = 4,
                        ColumnVisible = true,
                        ColumnWith = 130,
                        RepositoryControl = _rpsFixedAsset
                    },
                    
                     new XtraColumn{ColumnName = "Quantity",
                        ColumnCaption = "Số lượng",
                        ColumnPosition =5,
                        ColumnVisible = true,
                        ColumnWith = 100,
                        ColumnType = UnboundColumnType.Decimal
                     },
                    new XtraColumn { ColumnName = "BudgetChapterCode", ColumnVisible = false },
                    new XtraColumn { ColumnName = "Description", ColumnVisible = false },
                    new XtraColumn { ColumnName = "CapitalAccount", ColumnVisible = false },
                new XtraColumn { ColumnName = "CapitalCreditAmount", ColumnVisible = false },
                new XtraColumn { ColumnName = "CapitalCreditAmountUSD", ColumnVisible = false },
                new XtraColumn { ColumnName = "DepreciationAccount", ColumnVisible = false },
                new XtraColumn { ColumnName = "OrgPriceAccount", ColumnVisible = false },
                new XtraColumn { ColumnName = "IncrementDate", ColumnVisible = false },
                new XtraColumn { ColumnName = "Unit", ColumnVisible = false },
                new XtraColumn { ColumnName = "UsedDate", ColumnVisible = false },
                new XtraColumn { ColumnName = "DepartmentId", ColumnVisible = false},
                new XtraColumn { ColumnName = "AmountExchange", ColumnVisible = false },
                new XtraColumn { ColumnName = "AmountOc", ColumnVisible = false },
                new XtraColumn { ColumnName = "LifeTime", ColumnVisible = false }
                    };

                switch (_account.AccountCode)
                {
                    case "211":
                        gridColumnsCollection.Add(new XtraColumn
                        {
                            ColumnName = "OrgPriceDebitAmountUSD",
                            ColumnCaption = "Nguyên giá QĐ",
                            ColumnPosition = 7,
                            ColumnVisible = true,
                            ColumnWith = 150,
                            ColumnType = UnboundColumnType.Decimal
                        });
                        gridColumnsCollection.Add(new XtraColumn
                        {
                            ColumnName = "OrgPriceDebitAmount",
                            ColumnCaption = "Nguyên giá",
                            ColumnPosition = 6,
                            ColumnVisible = true,
                            ColumnWith = 150,
                            ColumnType = UnboundColumnType.Decimal
                        });

                        gridColumnsCollection.Add(new XtraColumn
                        {
                            ColumnName = "DepreciationCreditAmountUSD",
                            ColumnCaption = "GT hao mòn quy đổi",
                            ColumnPosition = 8,
                            ColumnVisible = false,
                            ColumnWith = 150,
                            ColumnType = UnboundColumnType.Decimal
                        });
                        gridColumnsCollection.Add(new XtraColumn
                        {
                            ColumnName = "DepreciationCreditAmount",
                            ColumnCaption = "Giá trị hao mòn",
                            ColumnPosition = 9,
                            ColumnVisible = false,
                            ColumnWith = 150,
                            ColumnType = UnboundColumnType.Decimal
                        });

                        gridColumnsCollection.Add(new XtraColumn
                        {
                            ColumnName = "RemainingAmount",
                            ColumnCaption = "Giá trị còn lại",
                            ColumnPosition = 10,
                            ColumnVisible = false,
                            ColumnWith = 150,
                            ColumnType = UnboundColumnType.Decimal
                        });
                        gridColumnsCollection.Add(new XtraColumn
                        {
                            ColumnName = "RemainingAmountUSD",
                            ColumnCaption = "GT còn lại quy đổi",
                            ColumnPosition = 11,
                            ColumnVisible = false,
                            ColumnWith = 150,
                            ColumnType = UnboundColumnType.Decimal
                        });
                        break;
                    case "2141":
                         gridColumnsCollection.Add(new XtraColumn
                        {
                            ColumnName = "OrgPriceDebitAmountUSD",
                            ColumnCaption = "Nguyên giá QĐ",
                            ColumnPosition = 7,
                            ColumnVisible = false,
                            ColumnWith = 150,
                            ColumnType = UnboundColumnType.Decimal
                        });
                        gridColumnsCollection.Add(new XtraColumn
                        {
                            ColumnName = "OrgPriceDebitAmount",
                            ColumnCaption = "Nguyên giá",
                            ColumnPosition = 6,
                            ColumnVisible = false,
                            ColumnWith = 150,
                            ColumnType = UnboundColumnType.Decimal
                        });

                        gridColumnsCollection.Add(new XtraColumn
                        {
                            ColumnName = "DepreciationCreditAmountUSD",
                            ColumnCaption = "GT hao mòn quy đổi",
                            ColumnPosition = 9,
                            ColumnVisible = true,
                            ColumnWith = 150,
                            ColumnType = UnboundColumnType.Decimal
                        });
                        gridColumnsCollection.Add(new XtraColumn
                        {
                            ColumnName = "DepreciationCreditAmount",
                            ColumnCaption = "Giá trị hao mòn",
                            ColumnPosition = 8,
                            ColumnVisible = true,
                            ColumnWith = 150,
                            ColumnType = UnboundColumnType.Decimal
                        });

                        gridColumnsCollection.Add(new XtraColumn
                        {
                            ColumnName = "RemainingAmount",
                            ColumnCaption = "Giá trị còn lại",
                            ColumnPosition = 10,
                            ColumnVisible = false,
                            ColumnWith = 150,
                            ColumnType = UnboundColumnType.Decimal
                        });
                        gridColumnsCollection.Add(new XtraColumn
                        {
                            ColumnName = "RemainingAmountUSD",
                            ColumnCaption = "GT còn lại quy đổi",
                            ColumnPosition = 11,
                            ColumnVisible = false,
                            ColumnWith = 150,
                            ColumnType = UnboundColumnType.Decimal
                        });
                        break;
                    case "466":
                            gridColumnsCollection.Add(new XtraColumn
                        {
                            ColumnName = "OrgPriceDebitAmountUSD",
                            ColumnCaption = "Nguyên giá QĐ",
                            ColumnPosition = 7,
                            ColumnVisible = false,
                            ColumnWith = 150,
                            ColumnType = UnboundColumnType.Decimal
                        });
                        gridColumnsCollection.Add(new XtraColumn
                        {
                            ColumnName = "OrgPriceDebitAmount",
                            ColumnCaption = "Nguyên giá",
                            ColumnPosition = 6,
                            ColumnVisible = false,
                            ColumnWith = 150,
                            ColumnType = UnboundColumnType.Decimal
                        });

                        gridColumnsCollection.Add(new XtraColumn
                        {
                            ColumnName = "DepreciationCreditAmountUSD",
                            ColumnCaption = "GT hao mòn quy đổi",
                            ColumnPosition = 8,
                            ColumnVisible = false,
                            ColumnWith = 150,
                            ColumnType = UnboundColumnType.Decimal
                        });
                        gridColumnsCollection.Add(new XtraColumn
                        {
                            ColumnName = "DepreciationCreditAmount",
                            ColumnCaption = "Giá trị hao mòn",
                            ColumnPosition = 9,
                            ColumnVisible = false,
                            ColumnWith = 150,
                            ColumnType = UnboundColumnType.Decimal
                        });

                        gridColumnsCollection.Add(new XtraColumn
                        {
                            ColumnName = "RemainingAmount",
                            ColumnCaption = "Giá trị còn lại",
                            ColumnPosition = 10,
                            ColumnVisible = true,
                            ColumnWith = 150,
                            ColumnType = UnboundColumnType.Decimal
                        });
                        gridColumnsCollection.Add(new XtraColumn
                        {
                            ColumnName = "RemainingAmountUSD",
                            ColumnCaption = "GT còn lại quy đổi",
                            ColumnPosition = 11,
                            ColumnVisible = true,
                            ColumnWith = 150,
                            ColumnType = UnboundColumnType.Decimal
                        });
                        break;
                    default:
                        gridColumnsCollection.Add(new XtraColumn
                        {
                            ColumnName = "RemainingAmount",
                            ColumnCaption = "Giá trị còn lại",
                            ColumnPosition = 8,
                            ColumnVisible = true,
                            ColumnWith = 100,
                            ColumnType = UnboundColumnType.Decimal
                        });
                        gridColumnsCollection.Add(new XtraColumn
                        {
                            ColumnName = "RemainingAmountUSD",
                            ColumnCaption = "GT còn lại quy đổi",
                            ColumnPosition = 9,
                            ColumnVisible = true,
                            ColumnWith = 150,
                            ColumnType = UnboundColumnType.Decimal
                        });

                        gridColumnsCollection.Add(new XtraColumn
                        {
                            ColumnName = "OrgPriceDebitAmountUSD",
                            ColumnCaption = "Nguyên giá QĐ",
                            ColumnPosition = 6,
                            ColumnVisible = true,
                            ColumnWith = 100,
                            ColumnType = UnboundColumnType.Decimal
                        });
                        gridColumnsCollection.Add(new XtraColumn
                        {
                            ColumnName = "OrgPriceDebitAmount",
                            ColumnCaption = "Nguyên giá",
                            ColumnPosition = 4,
                            ColumnVisible = true,
                            ColumnWith = 100,
                            ColumnType = UnboundColumnType.Decimal
                        });

                        gridColumnsCollection.Add(new XtraColumn
                        {
                            ColumnName = "DepreciationCreditAmountUSD",
                            ColumnCaption = "GT hao mòn quy đổi",
                            ColumnPosition = 6,
                            ColumnVisible = true,
                            ColumnWith = 100,
                            ColumnType = UnboundColumnType.Decimal
                        });
                        gridColumnsCollection.Add(new XtraColumn
                        {
                            ColumnName = "DepreciationCreditAmount",
                            ColumnCaption = "Giá trị hao mòn",
                            ColumnPosition = 4,
                            ColumnVisible = true,
                            ColumnWith = 100,
                            ColumnType = UnboundColumnType.Decimal
                        });
                        break;
                }

                foreach (var column in gridColumnsCollection)
                {
                    //gridViewDetail.Columns[column.ColumnName].OptionsColumn.AllowSort = DefaultBoolean.False;
                    if (column.ColumnVisible)
                    {
                        gridViewDetail.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        gridViewDetail.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                        gridViewDetail.Columns[column.ColumnName].Width = column.ColumnWith;
                        gridViewDetail.Columns[column.ColumnName].UnboundType = column.ColumnType;
                        gridViewDetail.Columns[column.ColumnName].ColumnEdit = column.RepositoryControl;
                    }
                    else
                        gridViewDetail.Columns[column.ColumnName].Visible = false;
                }
                SetNumericFormatControl(gridViewDetail, true);
            }
        }

        public IList<AccountModel> Accounts
        {
            set { _accounts = value; }
        }


        public IList<FixedAssetModel> FixedAssets
        {
            set
            {
                var resultList = value.Where(x => x.IsActive == false).ToList();
                _rpsFixedAsset.DataSource = resultList;// value;
                _rpsFixedAsset.PopulateViewColumns();
                var colColection = new List<XtraColumn>();
                colColection.Clear();

                colColection.Add(new XtraColumn { ColumnName = "FixedAssetCode", ColumnCaption = "Mã tài sản", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 100 });
                //colColection.Add(new XtraColumn { ColumnName = "FixedAssetName", ColumnCaption = "Tên tài sản", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 350 });
                colColection.Add(new XtraColumn { ColumnName = "FixedAssetName", ColumnCaption = "Tên tài sản", ToolTip = "Tên tài sản", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 300, Alignment = HorzAlignment.Center });
                colColection.Add(new XtraColumn { ColumnName = "OrgPrice", ColumnCaption = "Nguyên giá", ColumnPosition = 3, ColumnVisible = false, ColumnWith = 100, ColumnType = UnboundColumnType.Decimal, Alignment = HorzAlignment.Far });
                colColection.Add(new XtraColumn { ColumnName = "UsedDate", ColumnCaption = "Ngày sử dụng", ColumnPosition = 4, ColumnVisible = false, ColumnWith = 100, ColumnType = UnboundColumnType.DateTime, Alignment = HorzAlignment.Center });
                colColection.Add(new XtraColumn { ColumnName = "State", ColumnCaption = "Tình trạng", ColumnPosition = 5, ColumnVisible = false, ColumnWith = 100 });

                colColection.Add(new XtraColumn { ColumnName = "FixedAssetId", ColumnVisible = false });
                colColection.Add(new XtraColumn { ColumnName = "FixedAssetCurrencies", ColumnVisible = false });
                colColection.Add(new XtraColumn { ColumnName = "FixedAssetForeignName", ColumnVisible = false });
                colColection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                colColection.Add(new XtraColumn { ColumnName = "ProductionYear", ColumnVisible = false });
                colColection.Add(new XtraColumn { ColumnName = "MadeIn", ColumnVisible = false });
                colColection.Add(new XtraColumn { ColumnName = "FixedAssetCategoryId", ColumnVisible = false });
                colColection.Add(new XtraColumn { ColumnName = "PurchasedDate", ColumnVisible = false });
                colColection.Add(new XtraColumn { ColumnName = "DepreciationDate", ColumnVisible = false });
                colColection.Add(new XtraColumn { ColumnName = "IncrementDate", ColumnVisible = false });
                colColection.Add(new XtraColumn { ColumnName = "DisposedDate", ColumnVisible = false });
                colColection.Add(new XtraColumn { ColumnName = "Unit", ColumnVisible = false });
                colColection.Add(new XtraColumn { ColumnName = "SerialNumber", ColumnVisible = false });
                colColection.Add(new XtraColumn { ColumnName = "Accessories", ColumnVisible = false });
                colColection.Add(new XtraColumn { ColumnName = "Accessories", ColumnVisible = false });
                colColection.Add(new XtraColumn { ColumnName = "Quantity", ColumnVisible = false });
                colColection.Add(new XtraColumn { ColumnName = "UnitPrice", ColumnVisible = false });
                colColection.Add(new XtraColumn { ColumnName = "AccumDepreciationAmount", ColumnVisible = false });
                colColection.Add(new XtraColumn { ColumnName = "RemainingAmount", ColumnVisible = false });
                colColection.Add(new XtraColumn { ColumnName = "CurrencyCode", ColumnVisible = false });
                colColection.Add(new XtraColumn { ColumnName = "ExchangeRate", ColumnVisible = false });
                colColection.Add(new XtraColumn { ColumnName = "UnitPriceUSD", ColumnVisible = false });
                colColection.Add(new XtraColumn { ColumnName = "OrgPriceUSD", ColumnPosition = 3, ColumnVisible = false, ColumnWith = 100, ColumnType = UnboundColumnType.Decimal, Alignment = HorzAlignment.Far });
                colColection.Add(new XtraColumn { ColumnName = "AccumDepreciationAmountUSD", ColumnVisible = false });
                colColection.Add(new XtraColumn { ColumnName = "RemainingAmountUSD", ColumnVisible = false });
                colColection.Add(new XtraColumn { ColumnName = "AnnualDepreciationAmount", ColumnVisible = false });
                colColection.Add(new XtraColumn { ColumnName = "AnnualDepreciationAmountUSD", ColumnVisible = false });
                colColection.Add(new XtraColumn { ColumnName = "LifeTime", ColumnVisible = false });
                colColection.Add(new XtraColumn { ColumnName = "DepreciationRate", ColumnVisible = false });
                colColection.Add(new XtraColumn { ColumnName = "OrgPriceAccountCode", ColumnVisible = false });
                colColection.Add(new XtraColumn { ColumnName = "DepreciationAccountCode", ColumnVisible = false });
                colColection.Add(new XtraColumn { ColumnName = "CapitalAccountCode", ColumnVisible = false });
                colColection.Add(new XtraColumn { ColumnName = "DepartmentId", ColumnVisible = false });
                colColection.Add(new XtraColumn { ColumnName = "EmployeeId", ColumnVisible = false });
                colColection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                colColection.Add(new XtraColumn { ColumnName = "RemainingOrgPrice", ColumnVisible = false });
                colColection.Add(new XtraColumn { ColumnName = "RemainingOrgPriceUSD", ColumnVisible = false });


                foreach (var column in colColection)
                {
                    if (column.ColumnVisible)
                    {
                        _rpsFixedAssetView.Columns[column.ColumnName].ToolTip = column.ToolTip;
                        _rpsFixedAssetView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        _rpsFixedAssetView.Columns[column.ColumnName].SortIndex = column.ColumnPosition;
                        _rpsFixedAssetView.Columns[column.ColumnName].Width = column.ColumnWith;


                    }
                    else _rpsFixedAssetView.Columns[column.ColumnName].Visible = false;
                }
                //_rpsFixedAsset.BestFitMode = BestFitMode.BestFitResizePopup;
                _rpsFixedAsset.PopupResizeMode = ResizeMode.FrameResize;
                _rpsFixedAsset.View.OptionsView.ShowIndicator = false;
                //    _rpsFixedAsset.View.ActiveFilterString = "[BudgetItemType] >=3";
                _rpsFixedAsset.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                _rpsFixedAsset.DisplayMember = "FixedAssetName";
                _rpsFixedAsset.ValueMember = "FixedAssetId";
                _rpsFixedAsset.PopupFormSize = new Size(400, 210);
            }
        }
    }
}

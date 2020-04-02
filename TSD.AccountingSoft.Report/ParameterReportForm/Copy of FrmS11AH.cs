using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TSD.AccountingSoft.Report.BaseParameterForm;
using TSD.AccountingSoft.Report.CommonClass;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Presenter.Dictionary.Account;
using TSD.AccountingSoft.Session;
using TSD.AccountingSoft.View.Dictionary;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System.Linq;

namespace TSD.AccountingSoft.Report.ParameterReportForm
{
    public partial class FrmS11AH : FrmXtraBaseParameter, IAccountsView
    {
        private GlobalVariable _dbOptionHelper;
        private readonly AccountsPresenter _accountsPresenter;
        private RepositoryItemGridLookUpEdit _rpsAccountNumber;
        private GridView _rpsAccountNumberView;
        public FrmS11AH()
        {
            InitializeComponent();
            _dbOptionHelper = new GlobalVariable();
            _accountsPresenter = new AccountsPresenter(this);
            dateTimeRangeV1.InitData(DateTime.Parse(new GlobalVariable().PostedDate));
            dateTimeRangeV1.SetComboIndex(7);

            #region BudgetItem
            _rpsAccountNumberView = new GridView();
            _rpsAccountNumberView.OptionsView.ColumnAutoWidth = false;
            _rpsAccountNumber = new RepositoryItemGridLookUpEdit
            {
                NullText = "",
                View = _rpsAccountNumberView,
                TextEditStyle = TextEditStyles.Standard,
                PopupResizeMode = ResizeMode.FrameResize,
                PopupFormSize = new Size(500, 200),
                ShowFooter = false
            };
            _rpsAccountNumber.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
            _rpsAccountNumber.View.BestFitColumns();
            _rpsAccountNumber.View.OptionsView.ShowIndicator = false;
            #endregion

          

        }

        public string AccountCode
        {
            get
            {
                return grdLookUpAccount.EditValue.ToString();
            }
        }

        public string CorrespondingAccountNumber
        {
            get
            {
                return grdLookUpCorrespondingAccount.EditValue.ToString();
            }
        }

        /// <summary>
        /// Gets or sets the currency code.
        /// </summary>
        /// <value>
        /// The currency code.
        /// </value>
        public string CurrencyCode
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the type of the amount.
        /// </summary>
        /// <value>
        /// The type of the amount.
        /// </value>
        public int AmountType
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets from date.
        /// </summary>
        /// <value>
        /// From date.
        /// </value>
        public string FromDate
        {
            get
            {
                return dateTimeRangeV1.FromDate.ToShortDateString();
            }
            set
            {
            }
        }

        /// <summary>
        /// Gets or sets the reference date.
        /// </summary>
        /// <value>
        /// The reference date.
        /// </value>
        public string ToDate
        {
            get
            {
                return dateTimeRangeV1.ToDate.ToShortDateString();
            }
            set
            {
            }
        }

        public IList<AccountModel> Accounts
        {
            set
            {
                grdLookUpAccount.Properties.DataSource = value;
                grdLookUpAccount.Properties.PopulateColumns();
                var gridColumnsCollection = new List<XtraColumn>
                    {
                       new XtraColumn { ColumnName = "AccountId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "AccountCode", ColumnCaption = "Mã tài khoản", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 100 },
                        new XtraColumn { ColumnName = "AccountCategoryId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "AccountName", ColumnCaption = "Tên tài khoản", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 300 },
                        new XtraColumn { ColumnName = "Description", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsActive", ColumnVisible = false },
                        new XtraColumn { ColumnName = "ForeignName", ColumnVisible = false },
                        new XtraColumn { ColumnName = "Grade", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsDetail", ColumnVisible = false },
                        new XtraColumn { ColumnName = "BalanceSide", ColumnVisible = false }, //  Balanceside
                        new XtraColumn { ColumnName = "ConcomitantAccount", ColumnVisible = false },
                        new XtraColumn { ColumnName = "BankId", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsChapter", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsBudgetCategory", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsBudgetItem", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsBudgetGroup", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsBudgetSource", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsActivity", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsCurrency", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsCustomer", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsVendor", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsEmployee", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsAccountingObject", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsInventoryItem", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsFixedAsset", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false },
                        new XtraColumn { ColumnName = "IsCapitalAllocate", ColumnVisible = false },
                        new XtraColumn { ColumnName = "ParentId", ColumnVisible = false }
                    };

                foreach (var column in gridColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        grdLookUpAccount.Properties.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        grdLookUpAccount.Properties.SortColumnIndex = column.ColumnPosition;
                        grdLookUpAccount.Properties.Columns[column.ColumnName].Width = column.ColumnWith;

                    }
                    else
                    {
                        grdLookUpAccount.Properties.Columns[column.ColumnName].Visible = false;

                    }
                }
                grdLookUpAccount.Properties.DisplayMember = "AccountCode";
                grdLookUpAccount.Properties.ValueMember = "AccountCode";
                grdLookUpAccount.Properties.ShowFooter = false;
                grdLookUpAccount.Properties.TextEditStyle = TextEditStyles.Standard;



                grdLookUpCorrespondingAccount.Properties.DataSource = value;
                grdLookUpCorrespondingAccountView.PopulateColumns(value);
                grdLookUpCorrespondingAccount.Properties.TextEditStyle = TextEditStyles.Standard;
                grdLookUpCorrespondingAccountView.Columns["AccountId"].Visible = false;
                grdLookUpCorrespondingAccountView.Columns["AccountCategoryId"].Visible = false;
                grdLookUpCorrespondingAccountView.Columns["Description"].Visible = false;
                grdLookUpCorrespondingAccountView.Columns["IsActive"].Visible = false;
                grdLookUpCorrespondingAccountView.Columns["ForeignName"].Visible = false;
                grdLookUpCorrespondingAccountView.Columns["Grade"].Visible = false;
                grdLookUpCorrespondingAccountView.Columns["IsDetail"].Visible = false;
                grdLookUpCorrespondingAccountView.Columns["BalanceSide"].Visible = false;
                grdLookUpCorrespondingAccountView.Columns["ConcomitantAccount"].Visible = false;
                grdLookUpCorrespondingAccountView.Columns["BankId"].Visible = false;
                grdLookUpCorrespondingAccountView.Columns["IsChapter"].Visible = false;
                grdLookUpCorrespondingAccountView.Columns["IsBudgetCategory"].Visible = false;
                grdLookUpCorrespondingAccountView.Columns["IsBudgetItem"].Visible = false;
                grdLookUpCorrespondingAccountView.Columns["IsBudgetGroup"].Visible = false;
                grdLookUpCorrespondingAccountView.Columns["IsBudgetSource"].Visible = false;
                grdLookUpCorrespondingAccountView.Columns["IsCurrency"].Visible = false;
                grdLookUpCorrespondingAccountView.Columns["IsCustomer"].Visible = false;
                grdLookUpCorrespondingAccountView.Columns["IsVendor"].Visible = false;
                grdLookUpCorrespondingAccountView.Columns["IsEmployee"].Visible = false;
                grdLookUpCorrespondingAccountView.Columns["IsAccountingObject"].Visible = false;
                grdLookUpCorrespondingAccountView.Columns["IsInventoryItem"].Visible = false;
                grdLookUpCorrespondingAccountView.Columns["IsFixedAsset"].Visible = false;
                grdLookUpCorrespondingAccountView.Columns["IsSystem"].Visible = false;
                grdLookUpCorrespondingAccountView.Columns["IsCapitalAllocate"].Visible = false;
                grdLookUpCorrespondingAccountView.Columns["ParentId"].Visible = false;
                grdLookUpCorrespondingAccountView.Columns["IsActivity"].Visible = false;
                grdLookUpCorrespondingAccountView.Columns["AccountCode"].Caption = "Mã tài khoản ";
                grdLookUpCorrespondingAccountView.Columns["AccountName"].Caption = "Tên tài khoản";
                grdLookUpCorrespondingAccount.Properties.DisplayMember = "AccountCode";
                grdLookUpCorrespondingAccount.Properties.ValueMember = "AccountCode";
                grdLookUpCorrespondingAccount.Properties.ShowFooter = false;
                grdLookUpCorrespondingAccount.Properties.TextEditStyle = TextEditStyles.Standard;

            }

        }


     private DataTable GetDataTable(IList<AccountModel> accounts)
    {
        DataTable table = new DataTable();
        table.Columns.Add("AccountCode", typeof(string));
        table.Columns.Add("Information", typeof(string));

        foreach (var itemaccount in accounts)
        {
            string st = itemaccount.AccountCode +  "          ";
            st =st.Substring(0,10) + itemaccount.AccountName;
            table.Rows.Add(itemaccount.AccountCode, st);
            
        }

        return table;
    }




        private void FrmS11H_Load(object sender, System.EventArgs e)
        {
            _accountsPresenter.Display();
            CurrencyCode = _dbOptionHelper.CurrencyAccounting;
        }

        private void sbok_Click(object sender, System.EventArgs e)
        {
            if (grdLookUpAccount.EditValue.ToString() == "")
            {
                XtraMessageBox.Show("Bạn chưa chọn tài khoản", "Lỗi");
                grdLookUpAccount.Focus();
                return;
            }
            DialogResult = DialogResult.OK;
            
        }

        private void sbcancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Presenter.Dictionary.Account;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.WindowsForm.CommonClass;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.Report.BaseParameterForm;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace TSD.AccountingSoft.WindowsForm.UserControl.Dictionary
{
    public partial class FrmAccountList : FrmXtraBaseParameter, IAccountsView
    {
        public bool StateCheck { get; set; } //Khi người dùng thao tác chọn trên Lưới IsActive = false, IsNotAcctive =false
        internal GridCheckMarksSelection Selection { get; private set; }
        private readonly AccountsPresenter _accountsPresenter;
        public int RowForcus { get; set; } // Dòng đang trỏ đến
        private string Condition = "";

        private TextEdit TxtTextEdit;
        public FrmAccountList()
        {
            InitializeComponent();
            _accountsPresenter = new AccountsPresenter(this);
        }

        public FrmAccountList(string condition, TextEdit txTextEdit)
        {
            InitializeComponent();
            _accountsPresenter = new AccountsPresenter(this);
            this.Condition = condition;
            this.TxtTextEdit = txTextEdit;
        }

        public IList<AccountModel> Accounts
        {
            set
            {
                grdlookUpAccount.DataSource = value.Where(x => x.IsActive).ToList();
                var columnsCollection = new List<XtraColumn>
                {
                    new XtraColumn {ColumnName = "AccountId", ColumnVisible = false},
                    new XtraColumn
                    {
                        ColumnName = "AccountCode",
                        ColumnCaption = "Mã TK",
                        ColumnPosition = 1,
                        ColumnVisible = true,
                        ColumnWith = 150
                    },
                    new XtraColumn
                    {
                        ColumnName = "AccountName",
                        ColumnVisible = true,
                        ColumnCaption = "Tên tài khoản",
                        ColumnPosition = 2,
                        ColumnWith = 253
                    },
                    new XtraColumn {ColumnName = "AccountCategoryId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Description", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsActive", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ForeignName", ColumnVisible = false},
                    new XtraColumn {ColumnName = "Grade", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsDetail", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BalanceSide", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ConcomitantAccount", ColumnVisible = false},
                    new XtraColumn {ColumnName = "BankId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsChapter", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsBudgetCategory", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsBudgetItem", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsBudgetGroup", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsBudgetSource", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsActivity", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsCurrency", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsCustomer", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsVendor", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsEmployee", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsProject", ColumnVisible = false},
                    new XtraColumn {ColumnName = "CurrencyCode", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsAllowinputcts", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsAccountingObject", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsInventoryItem", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsFixedAsset", ColumnVisible = false},
                    new XtraColumn {ColumnName = "ParentId", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsCapitalAllocate", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsBudgetSubItem", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsBank", ColumnVisible = false},
                    new XtraColumn {ColumnName = "IsSystem", ColumnVisible = false}
                };


                foreach (var column in columnsCollection)
                {
                    if (gridViewAccount.Columns[column.ColumnName] != null)
                        if (column.ColumnVisible)
                        {
                            gridViewAccount.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            gridViewAccount.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                            gridViewAccount.Columns[column.ColumnName].Width = column.ColumnWith;
                        }
                        else
                            gridViewAccount.Columns[column.ColumnName].Visible = false;
                }

                //gridViewAccount = XtraColumnCollectionHelper<AccountModel>.CreateGridViewReponsitory();
                //grdlookUpAccount = XtraColumnCollectionHelper<AccountModel>.CreateGridLookUpEditReponsitory((gridViewAccount), value, "AccountName", "AccountCode", columnsCollection);
                //XtraColumnCollectionHelper<AccountModel>.ShowXtraColumnInGridView(columnsCollection, gridViewAccount);


            }
        }

        private void FrmAccountList_Load(object sender, EventArgs e)
        {
            _accountsPresenter.Display();
            Selection = new GridCheckMarksSelection(gridViewAccount);
            Selection.CheckMarkColumn.VisibleIndex = 0;
            Selection.CheckMarkColumn.Width = 40;
            StateCheck = true;
            SetChecked();
            gridViewAccount.OptionsSelection.EnableAppearanceFocusedRow = true;
            gridViewAccount.OptionsSelection.EnableAppearanceFocusedCell = false;
        }

        private void gridViewAccount_Click(object sender, EventArgs e)
        {
            GridHitInfo hi = gridViewAccount.CalcHitInfo(((MouseEventArgs)e).Location);
            if (!hi.InColumn && hi.InRowCell)
                if (gridViewAccount.FocusedRowHandle > -1)
                {
                    RowForcus = gridViewAccount.FocusedRowHandle;
                    StateCheck = false;
                    bool flag = Selection.IsRowSelected(gridViewAccount.FocusedRowHandle);
                    Selection.SelectRow(gridViewAccount.FocusedRowHandle, !flag);
                }
        }

        private void SetChecked()
        {
            if (gridViewAccount.RowCount > 0)
            {
                for (int i = 0; i < gridViewAccount.RowCount; i++)
                {
                    var accountNumber = gridViewAccount.GetRowCellValue(i, "AccountCode");
                    Selection.SelectRow(i, (";" + Condition + ";").Contains(";" + accountNumber + ";"));
                }
            }
        }

        public string ClauseAccount { get; set; }

        private void btnOk_Click(object sender, EventArgs e)
        {
            TxtTextEdit.Text = GetWhereAccount();
        }

        public string GetWhereAccount()
        {
            string whereClause = "";

            if (gridViewAccount.DataSource != null && gridViewAccount.RowCount > 0)
            {
                for (var i = 0; i < gridViewAccount.RowCount; i++)
                {
                    if (Selection.IsRowSelected(i))
                    {
                        var row = (AccountModel)gridViewAccount.GetRow(i);
                        whereClause = whereClause + row.AccountCode + ";";
                    }
                }
            }
            if (whereClause != "")
            {
                whereClause = whereClause.Substring(0, whereClause.Length - 1);
            }
            return whereClause;
        }
    }
}

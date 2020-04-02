/***********************************************************************
 * <copyright file="FrmXtraInventoryItemDetail.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: Wednesday, March 12, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Presenter.Dictionary.Account;
using TSD.AccountingSoft.Presenter.Dictionary.Currency;
using TSD.AccountingSoft.Presenter.Dictionary.Department;
using TSD.AccountingSoft.Presenter.Dictionary.InventoryItem;
using TSD.AccountingSoft.Presenter.Dictionary.Stock;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.WindowsForm.CommonClass;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.Resources;
using DevExpress.CodeParser;
using DevExpress.Utils;
using DevExpress.XtraEditors;

namespace TSD.AccountingSoft.WindowsForm.FormDictionary
{
    /// <summary>
    ///     Class FrmXtraInventoryItemDetail.
    /// </summary>
    public partial class FrmXtraInventoryItemDetail : FrmXtraBaseCategoryDetail, ICurrenciesView, IInventoryItemView, IAccountsView, IDepartmentsView
    {
        private readonly AccountsPresenter _accountsPresenter;
        private readonly InventoryItemPresenter _inventoryItemPresenter;
        //private readonly StocksPresenter _stocksPresenter;
        private readonly CurrenciesPresenter _currenciesPresenter;
        private readonly DepartmentsPresenter _departmentsPresenter;

        #region Property

        public int InventoryItemId { get; set; }

        public string InventoryItemCode
        {
            get { return txtInventoryItemCode.Text; }
            set { txtInventoryItemCode.Text = value; }
        }

        public string InventoryItemName
        {
            get { return txtInventoryItemName.Text; }
            set { txtInventoryItemName.Text = value; }
        }

        public string AccountCode
        {
            get { return (cboAccountCode.EditValue ?? "").ToString(); }//.GetColumnValue("AccountCode"); }
            set { cboAccountCode.EditValue = value; }
        }

        public string Unit
        {
            get { return txtUnit.Text; }
            set { txtUnit.Text = value; }
        }

        public string CurrencyCode
        {
            get
            {
                {
                    var currentcy = (CurrencyModel)cboCurrencyCode.GetSelectedDataRow();
                    if (currentcy != null)
                        return currentcy.CurrencyCode;
                    else
                        return null;
                }
            }
            set { cboCurrencyCode.EditValue = value; }
        }

        public int CostMethod
        {
            get { return Convert.ToInt32(cboCostMethod.EditValue) == 0 ? 1 : Convert.ToInt32(cboCostMethod.EditValue); }
            set { cboCostMethod.EditValue = value - 1; }
        }

        public bool IsActive
        {
            get { return chkIsActive.Checked; }
            set { chkIsActive.Checked = value; }
        }

        public int StockId
        {
            get { return Convert.ToInt32(cboStockId.EditValue ?? 0); }
            set { cboStockId.EditValue = value; }
        }

        public string ExpenseAccountCode
        {
            get { return (string)cboExpenseAccountCode.EditValue; }
            set { cboExpenseAccountCode.EditValue = value; }
        }

        public int? InventoryItemType
        {
            get
            {
                var inventoryItemType = (ObjectGeneral)gridLookupInventoryItemType.GetSelectedDataRow();
                if (inventoryItemType == null)
                    return null;
                else
                    return inventoryItemType.ObjectGeneralId;
            }
            set { gridLookupInventoryItemType.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the department identifier.
        /// </summary>
        /// <value>
        /// The department identifier.
        /// </value>
        public int? DepartmentId
        {
            get { return grdLookUpEditDepartmentID.EditValue == null ? null : (int?)grdLookUpEditDepartmentID.EditValue; }
            set { grdLookUpEditDepartmentID.EditValue = value; }
        }
        #endregion

        #region Combobox

        public IList<AccountModel> Accounts
        {
            set
            {
                GridLookUpItem.Account(value.Where(w => w.AccountCode.StartsWith("152") || w.AccountCode.StartsWith("153")).ToList() ?? new List<AccountModel>(), cboAccountCode, cboAccountCodeView, "AccountCode", "AccountCode");
                GridLookUpItem.Account(value ?? new List<AccountModel>(), cboExpenseAccountCode, cboExpenseAccountCodeView, "AccountCode", "AccountCode");
            }
        }

        public IList<StockModel> Stocks
        {
            set
            {
                GridLookUpItem.Stock(value ?? new List<StockModel>(), cboStockId, cboStockIdView, "StockCode", "StockId");
            }
        }

        public IList<CurrencyModel> Currencies
        {
            set
            {
                GridLookUpItem.Currency(value == null ? new List<CurrencyModel>() : value.Where(w => w.IsActive == true).ToList(), cboCurrencyCode, cboCurrencyCodeView, "CurrencyCode", "CurrencyCode");
            }
        }

        public IList<ObjectGeneral> CostMethods
        {
            set
            {
                GridLookUpItem.ObjectGeneral(value, cboCostMethod, cboCostMethodView);
            }
        }

        public List<ObjectGeneral> InventoryItemTypes
        {
            get { return new ObjectGeneral().GetInventoryItemTypes(); }
            set { GridLookUpItem.ObjectGeneralInventoryItemType(value, gridLookupInventoryItemType, gridLookupInventoryItemTypeView, "ObjectGeneralName", "ObjectGeneralId"); }
        }

        public IList<DepartmentModel> Departments
        {
            set
            {
                GridLookUpItem.Department(value ?? new List<DepartmentModel>(), grdLookUpEditDepartmentID, grdLookUpEditDepartmentIDView, "DepartmentName", "DepartmentId");
            }
        }
        #endregion

        #region Overrides Function

        protected override void InitData()
        {
            CostMethods = new ObjectGeneral().GetCostMethods();
            this.InventoryItemTypes = this.InventoryItemTypes;
            _departmentsPresenter.DisplayActive();
            _currenciesPresenter.DisplayActive();
            _accountsPresenter.DisplayActive();
         
            if (KeyValue != null)
                _inventoryItemPresenter.Display(KeyValue);
            else txtInventoryItemCode.Text = GetAutoNumber();
        }

        protected override int SaveData()
        {
            return _inventoryItemPresenter.Save();
        }

        protected override void InitControls()
        {
            txtInventoryItemCode.Focus();
            if (cboCostMethod.EditValue == null) cboCostMethod.EditValue = 0; // chỉ nhận lại mặc định thôi
        }

        protected override bool ValidData()
        {
            if (string.IsNullOrEmpty(InventoryItemCode))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResInventoryItemCode"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtInventoryItemCode.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(InventoryItemName))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResInventoryItemName"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtInventoryItemName.Focus();
                return false;
            }

            if (DepartmentId == null)
            {
                XtraMessageBox.Show("Bạn chưa chọn phòng ban!", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtInventoryItemName.Focus();
                return false;
            }

            //if (StockId <= 0)
            //{
            //    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResStockId"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    cboStockId.Focus();
            //    return false;
            //}
            InventoryItemType = 1;
            if (InventoryItemType == null)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResInventoryItemType"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboStockId.Focus();
                return false;
            }

            //if (CostMethod <= 0)
            //{
            //    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResCostMethod"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txtUnit.Focus();
            //    return false;
            //}

            //if (string.IsNullOrEmpty(Unit))
            //{
            //    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResInventoryItemUnit"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txtUnit.Focus();
            //    return false;
            //}

            //if (string.IsNullOrEmpty(CurrencyCode))
            //{
            //    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResInventoryItemCurrency"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    cboCurrencyCode.Focus();
            //    return false;
            //}

            //if (string.IsNullOrEmpty(AccountCode))
            //{
            //    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResInventoryItemAccountCode"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    cboAccountCode.Focus();
            //    return false;
            //}
            return true;
        }

        #endregion

        #region Form Event

        public FrmXtraInventoryItemDetail()
        {
            InitializeComponent();
            _inventoryItemPresenter = new InventoryItemPresenter(this);
            _departmentsPresenter = new DepartmentsPresenter(this);
            _accountsPresenter = new AccountsPresenter(this);
          
            _currenciesPresenter = new CurrenciesPresenter(this);

            #region load Tiền tệ



            //var table = new DataTable();
            //table.Columns.Add("CurrencyCode", typeof (string));
            //table.Rows.Add(CurrencyAccounting);
            //if (CurrencyAccounting != CurrencyLocal)
            //{
            //    table.Rows.Add(CurrencyLocal);
            //}
            //cboCurrencyCode.Properties.DataSource = table;
            //cboCurrencyCode.Properties.ValueMember = "CurrencyCode";
            //cboCurrencyCode.Properties.DisplayMember = "CurrencyCode";
            //cboCurrencyCode.Properties.ShowHeader = false;
            //cboCurrencyCode.Properties.ShowFooter = false;

            #endregion
        }

        private void FrmXtraInventoryItemDetail_Load(object sender, EventArgs e)
        {
            #region load Tiền tệ

            //var table = new DataTable();
            //table.Columns.Add("CurrencyCode", typeof (string));
            //table.Rows.Add(CurrencyAccounting);
            //if (CurrencyAccounting != CurrencyLocal)
            //{
            //    table.Rows.Add(CurrencyLocal);
            //}
            //cboCurrencyCode.Properties.DataSource = table;
            //cboCurrencyCode.Properties.ValueMember = "CurrencyCode";
            //cboCurrencyCode.Properties.DisplayMember = "CurrencyCode";
            //cboCurrencyCode.Properties.ShowHeader = false;
            //cboCurrencyCode.Properties.ShowFooter = false;

            #endregion
        }

        private void cboStockId_EditValueChanged(object sender, EventArgs e)
        {
            cboExpenseAccountCode.EditValue = cboStockId.Text == @"KHO_APT" ? @"331871" : @"6612";
        }

        private void cboCurrencyCode_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)
            {
                using (var frmDetail = new FrmXtraCurrencyDetail())
                {
                    frmDetail.ActionMode = TSD.Enum.ActionModeEnum.AddNew;
                    if (frmDetail.ShowDialog() == DialogResult.OK)
                    {
                        _currenciesPresenter.DisplayActive();

                        var lstdetails = cboCurrencyCode.Properties.DataSource as List<CurrencyModel>;
                        if (lstdetails != null)
                        {
                            cboCurrencyCode.EditValue = lstdetails.OrderByDescending(o => o.CurrencyId).FirstOrDefault().CurrencyCode;
                        }
                    }
                }
            }
        }

        private void cboAccountCode_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)
            {
                using (var frmDetail = new FrmXtraAccountDetail())
                {
                    frmDetail.ActionMode = TSD.Enum.ActionModeEnum.AddNew;
                    if (frmDetail.ShowDialog() == DialogResult.OK)
                    {
                        _currenciesPresenter.DisplayActive();

                        var lstdetails = cboAccountCode.Properties.DataSource as List<AccountModel>;
                        if (lstdetails != null)
                        {
                            cboAccountCode.EditValue = lstdetails.OrderByDescending(o => o.AccountId).FirstOrDefault().AccountCode;
                        }
                    }
                }
            }
        }

        private void cboExpenseAccountCode_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)
            {
                using (var frmDetail = new FrmXtraAccountDetail())
                {
                    frmDetail.ActionMode = TSD.Enum.ActionModeEnum.AddNew;
                    if (frmDetail.ShowDialog() == DialogResult.OK)
                    {
                        _currenciesPresenter.DisplayActive();

                        var lstdetails = cboExpenseAccountCode.Properties.DataSource as List<AccountModel>;
                        if (lstdetails != null)
                        {
                            cboExpenseAccountCode.EditValue = lstdetails.OrderByDescending(o => o.AccountId).FirstOrDefault().AccountCode;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Tự push tài khoản khi chọn loại
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridLookupInventoryItemType_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                //Chọn Vật tư TK vật tư hiện 152, chọn CCDC TK vật tư hiện 153
                cboAccountCode.EditValue = gridLookupInventoryItemType.EditValue.Equals(0) ? 152 : gridLookupInventoryItemType.EditValue.Equals(1) ? 153 : -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion
        
    }
}
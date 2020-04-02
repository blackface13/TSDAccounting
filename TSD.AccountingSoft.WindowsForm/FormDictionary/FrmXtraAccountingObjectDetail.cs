/***********************************************************************
 * <copyright file="FrmXtraAccountingObjectDetail.cs" company="BUCA JSC">
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Presenter.Dictionary.AccountingObject;
using TSD.AccountingSoft.Presenter.Dictionary.AccountingObjectCategory;
using TSD.AccountingSoft.Presenter.Dictionary.Bank;
using TSD.AccountingSoft.Presenter.Dictionary.BudgetItem;
using TSD.AccountingSoft.Presenter.Dictionary.Customer;
using TSD.AccountingSoft.Presenter.Dictionary.Project;
using TSD.AccountingSoft.Presenter.Dictionary.Vendor;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.WindowsForm.CommonClass;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.Resources;
using TSD.Enum;
using DevExpress.XtraEditors;


namespace TSD.AccountingSoft.WindowsForm.FormDictionary
{
    internal partial class FrmXtraAccountingObjectDetail : FrmXtraBaseCategoryDetail, IAccountingObjectView, ICustomerView, IVendorView
    {
        private readonly AccountingObjectPresenter _accountingObjectPresenter;
        private readonly VendorPresenter _vendorPresenter;
        private readonly CustomerPresenter _customerPresenter;

        public int IdResult = -1;
        public FrmXtraAccountingObjectDetail()
        {
            InitializeComponent();
            _accountingObjectPresenter = new AccountingObjectPresenter(this);
            _vendorPresenter = new VendorPresenter(this);
            _customerPresenter = new CustomerPresenter(this);
        }

        #region Properties

        IList<ObjectGeneral> AccountingObjectCategories
        {
            set
            {
                GridLookUpItem.ObjectGeneral(value, gridAccountingObjectCategoryId, gridAccountingObjectCategoryIdView);
            }
        }

        #region AccountingObject
        public int AccountingObjectId { get; set; }
        public string AccountingObjectCode { get { return txtAcountingObjectCode.Text; } set { txtAcountingObjectCode.Text = value; } }
        public int? Type { get; set; }
        public string FullName { get { return txtAccountingObjectName.Text; } set { txtAccountingObjectName.Text = value; } }
        public string Address { get { return txtAddress.Text; } set { txtAddress.Text = value; } }
        public string TaxCode { get; set; }
        public string BankAcount { get { return txtBankAccount.Text; } set { txtBankAccount.Text = value; } }
        public string BankName { get { return txtBankName.Text; } set { txtBankName.Text = value; } }
        public int? BankId { get; set; }
        public string ContactName { get; set; }
        public string ContactAddress { get; set; }
        public string ContactIdNumber { get; set; }
        public DateTime? IssueDate { get { return null; } set { } }
        public string IssueAddress { get; set; }
        public bool IsActive { get { return cbIsActive.Checked; } set { cbIsActive.Checked = value; } }
        #endregion

        #region Customer
        public int CustomerId { get; set; }
        public string CustomerCode { get { return txtAcountingObjectCode.Text; } set { txtAcountingObjectCode.Text = value; } }
        public string CustomerName { get { return txtAccountingObjectName.Text; } set { txtAccountingObjectName.Text = value; } }
        public string ContactRegency { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Area { get; set; }
        public string Country { get; set; }
        public string BankNumber { get { return txtBankAccount.Text; } set { txtBankAccount.Text = value; } }
        #endregion

        #region Vendor
        public int VendorId { get; set; }
        public string VendorCode { get { return txtAcountingObjectCode.Text; } set { txtAcountingObjectCode.Text = value; } }
        public string VendorName { get { return txtAccountingObjectName.Text; } set { txtAccountingObjectName.Text = value; } }
        #endregion

        public int? AccountingObjectCategoryId
        {
            get
            {
                return (int?)gridAccountingObjectCategoryId.EditValue;
            }
            set
            {
                gridAccountingObjectCategoryId.EditValue = value;
            }
        }

        public bool IsEnableAccountingObjectCategory
        {
            set
            {
                gridAccountingObjectCategoryId.Enabled = value;
            }
        }

        #endregion

        #region Override functions

        protected override void InitControls()
        {
            groupboxMain.Text = ResourceHelper.GetResourceValueByName("ResCommonCaption");
            base.InitControls();
        }

        protected override void InitData()
        {
            AccountingObjectCategories = new ObjectGeneral().GetAccountingObjectCategories(true, false, true, true);
            if (KeyValue != null)
                switch(AccountingObjectCategoryId)
                {
                    case 0:
                        _vendorPresenter.Display(KeyValue);
                        break;
                    case 2: 
                        _accountingObjectPresenter.Display(Convert.ToInt32(KeyValue));
                        break;
                    case 3:
                        _customerPresenter.Display(KeyValue);
                        break;
                }
            else
            {
                //txtAcountingObjectCode.Text = GetAutoNumber();
            }
            BankId = null;
        }

        protected override bool ValidData()
        {
            if(ActionMode == ActionModeEnum.AddNew)
            {
                if (_accountingObjectPresenter.CodeIsExist(null, AccountingObjectCode))
                {
                    XtraMessageBox.Show("Mã đối tượng đã tồn tại", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAcountingObjectCode.Focus();
                    return false;
                }
            }

            if (ActionMode == ActionModeEnum.Edit && _accountingObjectPresenter.CodeIsExist(Convert.ToInt32(KeyValue), AccountingObjectCode))
            {
                XtraMessageBox.Show("Mã đối tượng đã tồn tại", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAcountingObjectCode.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtAcountingObjectCode.Text))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResAccountingCode"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAcountingObjectCode.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtAccountingObjectName.Text))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResAccountingName"),ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAccountingObjectName.Focus();
                return false;
            }
            if (gridAccountingObjectCategoryId.EditValue == null)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResAccountingType"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                gridAccountingObjectCategoryId.Focus();
                return false;
            }
            return true;
        }

        protected override int SaveData()
        {
            switch (AccountingObjectCategoryId)
            {
                case 0:
                    IdResult = _vendorPresenter.Save();
                    break;
                case 2:
                    IdResult = _accountingObjectPresenter.Save();
                    break;
                case 3:
                    IdResult = _customerPresenter.Save();
                    break;
                default:
                    IdResult = 0;
                    break;
            }
            return IdResult;
        }

        #endregion

        #region Events

        private void gridAccountingObjectCategoryId_EditValueChanged(object sender, EventArgs e)
        {
            switch (AccountingObjectCategoryId)
            {
                case 0:
                    TableCode = "Vendor";
                    txtAcountingObjectCode.Text = GetAutoNumber();
                    break;
                case 2:
                    TableCode = "AccountingObject";
                    txtAcountingObjectCode.Text = GetAutoNumber();
                    break;
                case 3:
                    TableCode = "Customer";
                    txtAcountingObjectCode.Text = GetAutoNumber();
                    break;
                default:
                    TableCode = "";
                    txtAcountingObjectCode.Text = GetAutoNumber();
                    break;
            }
        }

        #endregion
    }
}
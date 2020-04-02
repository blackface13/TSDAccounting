/***********************************************************************
 * <copyright file="FrmXtraCustomerDetail.cs" company="BUCA JSC">
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
using System.Linq;
using System.Windows.Forms;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Presenter.Dictionary.Bank;
using TSD.AccountingSoft.Presenter.Dictionary.Customer;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.WindowsForm.CommonClass;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.Resources;
using TSD.Enum;
using DevExpress.XtraEditors;


namespace TSD.AccountingSoft.WindowsForm.FormDictionary
{

    /// <summary>
    /// FrmXtraCustomerDetail class
    /// </summary>
    internal partial class FrmXtraCustomerDetail : FrmXtraBaseCategoryDetail, ICustomerView, IBanksView
    {

        /// <summary>
        /// The _customer presenter
        /// </summary>
        private readonly CustomerPresenter _customerPresenter;

        /// <summary>
        /// The _banks presenter
        /// </summary>
        private readonly BanksPresenter _banksPresenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmXtraCustomerDetail"/> class.
        /// </summary>
        public FrmXtraCustomerDetail()
        {
            InitializeComponent();
            _customerPresenter = new CustomerPresenter(this);
            _banksPresenter = new BanksPresenter(this);
        }

        #region Property

        /// <summary>
        /// Gets or sets the cus identifier.
        /// </summary>
        /// <value>
        /// The cus identifier.
        /// </value>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        public string CustomerCode
        {
            get { return txtCode.Text; }
            set { txtCode.Text = value; }
        }

        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        /// <value>
        /// The full name.
        /// </value>
        public string CustomerName
        {
            get { return txtFullName.Text; }
            set { txtFullName.Text = value; }
        }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        public string Address
        {
            get { return txtAddress.Text; }
            set { txtAddress.Text = value; }
        }

        /// <summary>
        /// Gets or sets the name of the contact.
        /// </summary>
        /// <value>
        /// The name of the contact.
        /// </value>
        public string ContactName
        {
            get { return txtContactName.Text; }
            set { txtContactName.Text = value; }
        }

        /// <summary>
        /// Gets or sets the contact regency.
        /// </summary>
        /// <value>
        /// The contact regency.
        /// </value>
        public string ContactRegency
        {
            get { return txtContactReg.Text; }
            set { txtContactReg.Text = value; }
        }

        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        /// <value>
        /// The phone.
        /// </value>
        public string Phone
        {
            get { return txtPhone.Text; }
            set { txtPhone.Text = value; }
        }

        /// <summary>
        /// Gets or sets the mobile.
        /// </summary>
        /// <value>
        /// The mobile.
        /// </value>
        public string Mobile
        {
            get { return txtMobile.Text; }
            set { txtMobile.Text = value; }
        }

        /// <summary>
        /// Gets or sets the fax.
        /// </summary>
        /// <value>
        /// The fax.
        /// </value>
        public string Fax
        {
            get { return txtFax.Text; }
            set { txtFax.Text = value; }
        }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email
        {
            get { return txtEmail.Text; }
            set { txtEmail.Text = value; }
        }

        /// <summary>
        /// Gets or sets the tax code.
        /// </summary>
        /// <value>
        /// The tax code.
        /// </value>
        public string TaxCode
        {
            get { return txtTaxCode.Text; }
            set { txtTaxCode.Text = value; }
        }

        /// <summary>
        /// Gets or sets the website.
        /// </summary>
        /// <value>
        /// The website.
        /// </value>
        public string Website
        {
            get { return txtWebsite.Text; }
            set { txtWebsite.Text = value; }
        }

        /// <summary>
        /// Gets or sets the province.
        /// </summary>
        /// <value>
        /// The province.
        /// </value>
        public string Province
        {
            get { return txtProvince.Text; }
            set { txtProvince.Text = value; }
        }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>
        /// The city.
        /// </value>
        public string City
        {
            get { return txtCity.Text; }
            set { txtCity.Text = value; }
        }

        /// <summary>
        /// Gets or sets the zip code.
        /// </summary>
        /// <value>
        /// The zip code.
        /// </value>
        public string ZipCode
        {
            get { return txtZipCode.Text; }
            set { txtZipCode.Text = value; }
        }

        /// <summary>
        /// Gets or sets the area.
        /// </summary>
        /// <value>
        /// The area.
        /// </value>
        public string Area
        {
            get { return txtArea.Text; }
            set { txtArea.Text = value; }
        }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        public string Country
        {
            get { return txtCountry.Text; }
            set { txtCountry.Text = value; }
        }

        /// <summary>
        /// Gets or sets the bank account.
        /// </summary>
        /// <value>
        /// The bank account.
        /// </value>
        public string BankNumber
        {
            get { return txtBankAccount.Text; }
            set { txtBankAccount.Text = value; }
        }

        /// <summary>
        /// Gets or sets the bank identifier.
        /// </summary>
        /// <value>
        /// The bank identifier.
        /// </value>
        public int? BankId
        {
            get
            {
                var bank = (BankModel)luBankId.GetSelectedDataRow();
                if (bank != null)
                {
                    return bank.BankId;
                }
                return null;
            }
            set
            {
                if (value > 0)
                    luBankId.EditValue = value;
            }
        }

        public string BankName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is active].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is active]; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive
        {
            get { return cbIsActive.Checked; }
            set { cbIsActive.Checked = value; }
        }

        #endregion

        /// <summary>
        /// Initializes the data.
        /// </summary>
        protected override void InitData()
        {
            if (KeyValue != null)
                _customerPresenter.Display(KeyValue);
            _banksPresenter.DisplayActive();
        }

        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns></returns>
        protected override bool ValidData()
        {
            if (string.IsNullOrEmpty(CustomerCode))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResCustomerCode"),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCode.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(CustomerName))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResCustomerName"),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFullName.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// Saves the data.
        /// </summary>
        /// <returns></returns>
        protected override int SaveData()
        {
            return _customerPresenter.Save();
        }

        /// <summary>
        /// Focuses the control.
        /// </summary>
        protected override void InitControls()
        {
            txtCode.Focus();
            groupboxMain.Text = ResourceHelper.GetResourceValueByName("ResCommonCaption");
            grbContactInfo.Text = ResourceHelper.GetResourceValueByName("ResContactCaption");
            base.InitControls();
        }

        /// <summary>
        /// Sets the banks.
        /// </summary>
        /// <value>
        /// The banks.
        /// </value>
        public IList<BankModel> Banks
        {
            set
            {
                GridLookUpItem.Bank(value, luBankId, luBankView, "BankName", "BankId");
            }
        }

        private void luBankId_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)
            {
                using (var frmBank = new FrmXtraBankDetail())
                {
                    frmBank.ActionMode = ActionModeEnum.AddNew;

                    if (frmBank.ShowDialog() == DialogResult.OK)
                    {
                        if (frmBank.DialogResult == DialogResult.OK)
                        {
                            _banksPresenter.DisplayActive();

                            var lstBank = (List<BankModel>)luBankId.Properties.DataSource;
                            if (lstBank != null && lstBank.Count > 0)
                                BankId = lstBank.Max(m => m.BankId);
                        }
                    }
                }
            }
        }
    }
}
/***********************************************************************
 * <copyright file="FrmXtraBankDetail.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 14 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Windows.Forms;
using TSD.AccountingSoft.Presenter.Dictionary.Bank;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.Resources;
using DevExpress.XtraEditors;


namespace TSD.AccountingSoft.WindowsForm.FormDictionary
{
    /// <summary>
    /// class FrmXtraBankDetail
    /// </summary>
    public partial class FrmXtraBankDetail : FrmXtraBaseCategoryDetail, IBankView
    {
        private readonly BankPresenter _bankPresenter;
        public int IdResult = -1;
        /// <summary>
        /// Initializes a new instance of the <see cref="FrmXtraBankDetail"/> class.
        /// </summary>
        public FrmXtraBankDetail()
        {
            InitializeComponent();
            _bankPresenter = new BankPresenter(this);
        }

        #region IBankView Members

        /// <summary>
        /// Gets or sets the bank identifier.
        /// </summary>
        /// <value>
        /// The bank identifier.
        /// </value>
        public int BankId { get; set; }

        /// <summary>
        /// Gets or sets the bank code.
        /// </summary>
        /// <value>
        /// The bank code.
        /// </value>
        public string BankAccount
        {
            get { return txtBankAccount.Text; }
            set { txtBankAccount.Text = value; }
        }

        /// <summary>
        /// Gets or sets the bank address.
        /// </summary>
        /// <value>
        /// The bank address.
        /// </value>
        public string BankAddress
        {
            get { return txtBankAddress.Text; }
            set { txtBankAddress.Text = value; }
        }

        /// <summary>
        /// Gets or sets the name of the bank.
        /// </summary>
        /// <value>
        /// The name of the bank.
        /// </value>
        public string BankName
        {
            get { return txtBankName.Text; }
            set { txtBankName.Text = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [is active].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is active]; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive
        {
            get { return chkIsActive.Checked; }
            set { chkIsActive.Checked = value; }
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description
        {
            get { return memoDescription.Text; }
            set { memoDescription.Text = value; }
        }

        #endregion

        /// <summary>
        /// Initializes the data.
        /// </summary>
        protected override void InitData()
        {
            if (KeyValue != null)
            {
                _bankPresenter.Display(KeyValue);
            }
            else
                BankAccount = GetAutoNumber();
        }

        /// <summary>
        /// Focuses the control.
        /// </summary>
        protected override void InitControls()
        {
        }

        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns></returns>
        protected override bool ValidData()
        {
            if (string.IsNullOrEmpty(BankAccount))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResBankCode"),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBankAccount.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(BankName))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResBankName"),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBankName.Focus();
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
            IdResult = _bankPresenter.Save();
            return IdResult;
        }
    }
}
/***********************************************************************
 * <copyright file="FrmXtraCurrencyDetail.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuanHM
 * Email:    Tuanhm@buca.vn
 * Website:
 * Create Date: Tuesday, March 11, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Windows.Forms;
using TSD.AccountingSoft.Presenter.Dictionary.Currency;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.Resources;
using DevExpress.XtraEditors;


namespace TSD.AccountingSoft.WindowsForm.FormDictionary
{
    /// <summary>
    /// Class FrmXtraCurrencyDetail.
    /// </summary>
    public partial class FrmXtraCurrencyDetail : FrmXtraBaseCategoryDetail, ICurrencyView
    {
        private readonly CurrencyPresenter _currencyPresenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmXtraCurrencyDetail"/> class.
        /// </summary>
        public FrmXtraCurrencyDetail()
        {
            InitializeComponent();
            _currencyPresenter = new CurrencyPresenter(this);
        }

        /// <summary>
        /// Initializes the data.
        /// </summary>
        protected override void InitData()
        {
            if (KeyValue != null)
                _currencyPresenter.Display(KeyValue);
            else
                chkIsActive.Checked = true;
        }

        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns></returns> 
        protected override bool ValidData()
        {
            if (string.IsNullOrEmpty(CurrencyCode))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResEmptyCurrencyCode"),
                              ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCurrencyCode.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(CurrencyName))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResEmptyCurrencyName"),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCurrencyName.Focus();
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
            return _currencyPresenter.Save();
        }

        /// <summary>
        /// Focuses the control.
        /// </summary>
        protected override void InitControls()
        {
            txtCurrencyCode.Focus();
        }

        /// <summary>
        /// Gets or sets the currency identifier.
        /// </summary>
        /// <value>The currency identifier.</value>
        public int CurrencyId { get; set; }

        /// <summary>
        /// Gets or sets the currency code.
        /// </summary>
        /// <value>The currency code.</value>
        public string CurrencyCode
        {
            get
            {
                return txtCurrencyCode.Text;
            }
            set
            {
                txtCurrencyCode.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the currency.
        /// </summary>
        /// <value>The name of the currency.</value>
        public string CurrencyName
        {
            get
            {
                return txtCurrencyName.Text;
            }
            set
            {
                txtCurrencyName.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets the prefix.
        /// </summary>
        /// <value>The prefix.</value>
        public string Prefix
        {
            get
            {
                return txtPrefix.Text;
            }
            set
            {
                txtPrefix.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets the suffix.
        /// </summary>
        /// <value>The suffix.</value>
        public string Suffix
        {
            get
            {
                return txtSuffix.Text;
            }
            set
            {
                txtSuffix.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is main.
        /// </summary>
        /// <value><c>true</c> if this instance is main; otherwise, <c>false</c>.</value>
        public bool IsMain
        {
            get
            {
                return chkMain.Checked;
            }
            set
            {
                chkMain.Checked = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        public bool IsActive
        {
            get
            {
                return chkIsActive.Checked;
            }
            set
            {
                chkIsActive.Checked = value;
            }
        }
    }
}
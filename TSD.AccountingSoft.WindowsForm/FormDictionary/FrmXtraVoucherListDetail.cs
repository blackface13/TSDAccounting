/***********************************************************************
 * <copyright file="FrmXtraVoucherListDetail.cs" company="BUCA JSC">
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
using System.Windows.Forms;
using TSD.AccountingSoft.Presenter.Dictionary.VoucherList;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.Resources;
using DevExpress.XtraEditors;


namespace TSD.AccountingSoft.WindowsForm.FormDictionary
{

    /// <summary>
    /// FrmXtraVoucherListDetail class
    /// </summary>
    internal partial class FrmXtraVoucherListDetail : FrmXtraBaseCategoryDetail, IVoucherListView
    {
        private readonly VoucherListPresenter _voucherListPresenter;

        public FrmXtraVoucherListDetail()
        {
            InitializeComponent();
            _voucherListPresenter = new VoucherListPresenter(this);
        }

        #region Property

        /// <summary>
        /// Gets or sets the voucher identifier.
        /// </summary>
        /// <value>
        /// The voucher identifier.
        /// </value>
        public int VoucherListId { get; set; }

        /// <summary>
        /// Gets or sets the voucher no.
        /// </summary>
        /// <value>
        /// The voucher no.
        /// </value>
        public string VoucherListCode
        {
            get { return txtVoucherNo.Text; }
            set { txtVoucherNo.Text = value; }
        }

        /// <summary>
        /// Gets or sets the voucher date.
        /// </summary>
        /// <value>
        /// The voucher date.
        /// </value>
        public DateTime VoucherDate
        {
            get { return dEVoucherDate.DateTime; }
            set { dEVoucherDate.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the post date.
        /// </summary>
        /// <value>
        /// The post date.
        /// </value>
        public DateTime PostDate
        {
            get { return dEPostDate.DateTime; }
            set { dEPostDate.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description
        {
            get { return moDescription.Text; }
            set { moDescription.Text = value; }
        }

        /// <summary>
        /// Gets or sets the document attach.
        /// </summary>
        /// <value>
        /// The document attach.
        /// </value>
        public string DocAttach
        {
            get { return txtDocAttach.Text; }
            set { txtDocAttach.Text = value; }
        }

        #endregion

        #region Overrides

        protected override void InitData()
        {
            if (KeyValue != null)
                _voucherListPresenter.Display(KeyValue);
        }

        protected override bool ValidData()
        {
            if (string.IsNullOrEmpty(VoucherListCode))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResVoucherNo"),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtVoucherNo.Focus();
                return false;
            }
            if (VoucherDate == new DateTime(1, 1, 0001))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResVoucherDate"),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (PostDate == new DateTime(1, 1, 0001))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResPostDate"),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (VoucherDate < PostDate)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResVoucherDateCompare"),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        protected override int SaveData()
        {
            return _voucherListPresenter.Save();
        }

        protected override void InitControls()
        {
            txtVoucherNo.Focus();
            groupboxMain.Text = ResourceHelper.GetResourceValueByName("ResCommonCaption");
            dEVoucherDate.DateTime = DateTime.Now;
            base.InitControls();
        }

        #endregion
    }
}
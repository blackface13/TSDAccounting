/***********************************************************************
 * <copyright file="FrmXtraStockDetail.cs" company="BUCA JSC">
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

using System.Windows.Forms;
using TSD.AccountingSoft.Presenter.Dictionary.Stock;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.Resources;
using DevExpress.XtraEditors;


namespace TSD.AccountingSoft.WindowsForm.FormDictionary
{
    public partial class FrmXtraStockDetail : FrmXtraBaseCategoryDetail, IStockView
    {
        private readonly StockPresenter _stockPresenter;

        #region Properties

        public int StockId {  get; set;}

        public string StockCode
        {
            get { return txtStockCode.Text; }
            set { txtStockCode.Text = value; }
        }

        public string StockName
        {
            get { return txtStockName.Text; }
            set { txtStockName.Text = value; }
        }

        public string Description
        {
            get { return txtDescription.Text; }
            set { txtDescription.Text = value; }
        }

        public bool IsActive
        {
            get { return chkActive.Checked; }
            set { chkActive.Checked = value; }
        }

        #endregion

        public FrmXtraStockDetail()
        {
            InitializeComponent();
            _stockPresenter = new StockPresenter(this);
        }

        #region Override Functions

        protected override void InitData()
        {
            if (KeyValue != null)
                _stockPresenter.Display(KeyValue);
            else txtStockCode.Text = GetAutoNumber();
        }

        protected override void InitControls()
        {
            txtStockCode.Focus();
        }

        protected override int SaveData()
        {
            return _stockPresenter.Save();
        }

        protected override bool ValidData()
        {
            if (string.IsNullOrEmpty(StockCode))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResStockCode"), ResourceHelper.GetResourceValueByName("ResStockCode"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtStockCode.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(StockName))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResStockName"), ResourceHelper.GetResourceValueByName("ResStockName"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtStockName.Focus();
                return false;
            }

            return true;
        }

        #endregion
    }
}

/***********************************************************************
 * <copyright file="FrmXtraPostedDate.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 27 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using System.Windows.Forms;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Presenter.Dictionary.DBOption;
using TSD.AccountingSoft.Session;
using TSD.AccountingSoft.View.Dictionary;
using System;
using TSD.AccountingSoft.WindowsForm.Resources;
using DevExpress.XtraEditors;


namespace TSD.AccountingSoft.WindowsForm.FormSystem
{
    /// <summary>
    /// FrmXtraPostedDate
    /// </summary>
    public partial class FrmXtraPostedDate : XtraForm, IDBOptionsView
    {
        private readonly DBOptionsPresenter _dbOptionsPresenter;
        private readonly GlobalVariable _globalVariable;

        private string _financialMonth;

        #region DBOption Members

        public IList<DBOptionModel> DBOptions
        {
            get
            {
                var dbOptions = new List<DBOptionModel> 
                {
                    new DBOptionModel { OptionId = "PostedDate", OptionValue = ((DateTime)dtPostedDate.EditValue).ToShortDateString(), ValueType = 2,
                        Description = "Ngày hạch toán", IsSystem = true },
                    new DBOptionModel { OptionId = "StartedDate", OptionValue = "01/" + _financialMonth + "/" + ((DateTime)dtPostedDate.EditValue).Year, ValueType = 2,
                        Description = "Ngày bắt đầu năm tài chính - 01/tháng của năm tài chính/năm posteddate", IsSystem = true },
                    new DBOptionModel { OptionId = "FinancialEndOfDate", OptionValue = "31/12/" + ((DateTime)dtPostedDate.EditValue).Year, 
                        ValueType = 2, Description = "Ngày cuối cùng của năm tài chính - 31/12/năm posteddate", IsSystem = true }
                };
                return dbOptions;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmXtraPostedDate"/> class.
        /// </summary>
        public FrmXtraPostedDate()
        {
            InitializeComponent();
            _dbOptionsPresenter = new DBOptionsPresenter(this);
            _globalVariable = new GlobalVariable();
        }

        /// <summary>
        /// Handles the Load event of the FrmXtraPostedDate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FrmXtraPostedDate_Load(object sender, EventArgs e)
        {
            dtPostedDate.EditValue = DateTime.Now;
            _financialMonth = _globalVariable.FinancialMonth;
            if (_financialMonth.Length == 1)
                _financialMonth = "0" + _financialMonth;
        }

        /// <summary>
        /// Handles the Click event of the btnExit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Handles the Click event of the btnSave control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (DateTime.Parse(dtPostedDate.Text).Year < DateTime.Parse(GlobalVariable.SystemDate).Year)
                    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResPostedDateLessSysemDate"), ResourceHelper.GetResourceValueByName("ResDetailContent"), 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    var message = _dbOptionsPresenter.Save();
                    if (message != null)
                        XtraMessageBox.Show(message, ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _globalVariable.PostedDate = dtPostedDate.EditValue.ToString();
                    GlobalVariable.StartedDate = dtPostedDate.EditValue.ToString();//LINHMC gan lai de luu lai gia tri thay doi ngay hach toan
                    //_dbOptionsPresenter.Display();
                    Close();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
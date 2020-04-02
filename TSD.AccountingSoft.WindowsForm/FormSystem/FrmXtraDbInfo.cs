/***********************************************************************
 * <copyright file="FrmXtraDbInfo.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 04 April 2014
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
using TSD.AccountingSoft.Presenter.Dictionary.DBOption;
using TSD.AccountingSoft.View.Dictionary;
using DevExpress.XtraEditors;


namespace TSD.AccountingSoft.WindowsForm.FormSystem
{
    /// <summary>
    /// FrmXtraDbInfo
    /// </summary>
    public partial class FrmXtraDbInfo : XtraForm, IDBOptionsView
    {
        /// <summary>
        /// The _DB options presenter
        /// </summary>
        private readonly DBOptionsPresenter _dbOptionsPresenter;

        /// <summary>
        /// Gets or sets the database options.
        /// </summary>
        /// <value>
        /// The database options.
        /// </value>
        public IList<DBOptionModel> DBOptions
        {
            get
            {
                var dbOptions = new List<DBOptionModel>();
                return dbOptions;
            }
            set
            {
                if (value == null) return;

                gridDbInfo.DataSource = value;
                gridDbInfoView.PopulateColumns();
                if (gridDbInfoView.RowCount > 0)
                {
                    gridDbInfoView.Columns["OptionId"].Visible = false;
                    gridDbInfoView.Columns["ValueType"].Visible = false;
                    gridDbInfoView.Columns["IsSystem"].Visible = false;
                    gridDbInfoView.Columns["Description"].VisibleIndex = 0;
                    gridDbInfoView.Columns["OptionValue"].VisibleIndex = 1;
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmXtraDbInfo" /> class.
        /// </summary>
        public FrmXtraDbInfo()
        {
            InitializeComponent();
            _dbOptionsPresenter = new DBOptionsPresenter(this);
        }

        /// <summary>
        /// Handles the Load event of the FrmXtraDbInfo control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        private void FrmXtraDbInfo_Load(object sender, System.EventArgs e)
        {
            _dbOptionsPresenter.Display();
        }

        /// <summary>
        /// Processes a command key.
        /// </summary>
        /// <param name="msg">A <see cref="T:System.Windows.Forms.Message" />, passed by reference, that represents the Win32 message to process.</param>
        /// <param name="keyData">One of the <see cref="T:System.Windows.Forms.Keys" /> values that represents the key to process.</param>
        /// <returns>
        /// true if the keystroke was processed and consumed by the control; otherwise, false to allow further processing.
        /// </returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter || keyData == Keys.Escape)
            {
                Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
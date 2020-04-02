/***********************************************************************
 * <copyright file="FrmCreateNewDatabase.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 02 June 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Presenter.Dictionary.Account;
using TSD.AccountingSoft.Presenter.Dictionary.Currency;
using TSD.AccountingSoft.Presenter.Dictionary.DBOption;
using TSD.AccountingSoft.Presenter.Dictionary.PayItem;
using TSD.AccountingSoft.Session;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.Resources;
using DevExpress.XtraEditors;
using System.Data;
using System.IO;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using TSD.AccountingSoft.WindowsForm.CommonClass;
using TSD.Option;
using DevExpress.Data;
using TSD.AccountingSoft.Presenter.Dictionary.AutoBusiness;

namespace TSD.AccountingSoft.WindowsForm.FormSystem
{
    /// <summary>
    /// FrmCreateNewDatabase
    /// </summary>
    public partial class FrmCreateNewDatabase : XtraForm, IDBOptionsView, ICurrencyView, IAccountView, IPayItemsView, IPayItemView, IAutoBusinessesView, IAutoBusinessView
    {
        private const string DatabasePath = @"Data";
        private const string DatabaseTemplatePath = @"DataTemplate\aBigTimeBCTBackup.bak";
        private int _typeOfCreateDatabase = 1;
        private const string XmlCompany = @"company.xml";
        private const string XmlCurrency = @"currency.xml";
        private readonly DBOptionsPresenter _dbOptionsPresenter;
        private readonly CurrencyPresenter _currencyPresenter;
        private ServerConnection _serverConnection;
        private Server _server;
        private readonly AccountPresenter _accountPresenter;
        private IList<PayItemModel> _payItems;
        private IList<AutoBusinessModel> _autoAutoBusiness;
        private readonly PayItemsPresenter _payItemsPresenter;
        private readonly PayItemPresenter _payItemPresenter;
        private readonly AutoBusinessPresenter _autoBusinessPresenter;
        private readonly AutoBusinessesPresenter _autoBusinessesPresenter;


        private readonly Crypto Crypto = new Crypto(Crypto.SymmProvEnum.Rijndael);
        private string CoefficientOfSalaryByArea = "";//Hệ số lương địa bàn

        #region PayItems

        /// <summary>
        /// Gets or sets the pay items.
        /// </summary>
        /// <value>
        /// The pay items.
        /// </value>
        public IList<PayItemModel> PayItems
        {
            set
            {
                _payItems = new List<PayItemModel>();
                _payItems = value;
            }
        }

        /// <summary>
        /// Gets or sets the pay item identifier.
        /// </summary>
        /// <value>
        /// The pay item identifier.
        /// </value>
        public int PayItemId { get; set; }
        /// <summary>
        /// Gets or sets the pay item code.
        /// </summary>
        /// <value>
        /// The pay item code.
        /// </value>
        public string PayItemCode { get; set; }
        /// <summary>
        /// Gets or sets the name of the pay item.
        /// </summary>
        /// <value>
        /// The name of the pay item.
        /// </value>
        public string PayItemName { get; set; }
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public int Type { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [is calculate ratio].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is calculate ratio]; otherwise, <c>false</c>.
        /// </value>
        public bool IsCalculateRatio { get; set; }
        /// <summary>
        /// Gets or sets the is social insurance.
        /// </summary>
        /// <value>
        /// The is social insurance.
        /// </value>
        public bool? IsSocialInsurance { get; set; }
        /// <summary>
        /// Gets or sets the is care insurance.
        /// </summary>
        /// <value>
        /// The is care insurance.
        /// </value>
        public bool? IsCareInsurance { get; set; }
        /// <summary>
        /// Gets or sets the is trade union fee.
        /// </summary>
        /// <value>
        /// The is trade union fee.
        /// </value>
        public bool? IsTradeUnionFee { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the debit account code.
        /// </summary>
        /// <value>
        /// The debit account code.
        /// </value>
        public string DebitAccountCode { get; set; }
        /// <summary>
        /// Gets or sets the credit account code.
        /// </summary>
        /// <value>
        /// The credit account code.
        /// </value>
        public string CreditAccountCode { get; set; }
        /// <summary>
        /// Gets or sets the budget chapter code.
        /// </summary>
        /// <value>
        /// The budget chapter code.
        /// </value>
        public string BudgetChapterCode { get; set; }

        /// <summary>
        /// Gets or sets the balanceside.
        /// </summary>
        /// <value>
        /// The balanceside.
        /// </value>
        public int BalanceSide { get; set; }

        /// <summary>
        /// Gets or sets the concomitant account.
        /// </summary>
        /// <value>
        /// The concomitant account.
        /// </value>
        public string ConcomitantAccount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is allowinputcts].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is allowinputcts]; otherwise, <c>false</c>.
        /// </value>
        public bool IsAllowinputcts { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is system.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is system; otherwise, <c>false</c>.
        /// </value>
        public bool IsSystem { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is project].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is project]; otherwise, <c>false</c>.
        /// </value>
        public bool IsProject { get; set; }

        /// <summary>
        /// Gets or sets the bank identifier.
        /// </summary>
        /// <value>
        /// The bank identifier.
        /// </value>
        public int? BankId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is chapter.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is chapter; otherwise, <c>false</c>.
        /// </value>
        public bool IsChapter { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is budget category.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is budget category; otherwise, <c>false</c>.
        /// </value>
        public bool IsBudgetCategory { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is budget item.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is budget item; otherwise, <c>false</c>.
        /// </value>
        public bool IsBudgetItem { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is budget group.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is budget group; otherwise, <c>false</c>.
        /// </value>
        public bool IsBudgetGroup { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is budget source.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is budget source; otherwise, <c>false</c>.
        /// </value>
        public bool IsBudgetSource { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is activity.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is activity; otherwise, <c>false</c>.
        /// </value>
        public bool IsActivity { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is currency.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is currency; otherwise, <c>false</c>.
        /// </value>
        public bool IsCurrency { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is customer.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is customer; otherwise, <c>false</c>.
        /// </value>
        public bool IsCustomer { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is vendor.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is vendor; otherwise, <c>false</c>.
        /// </value>
        public bool IsVendor { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is employee.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is employee; otherwise, <c>false</c>.
        /// </value>
        public bool IsEmployee { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is accounting object.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is accounting object; otherwise, <c>false</c>.
        /// </value>
        public bool IsAccountingObject { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is inventory item.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is inventory item; otherwise, <c>false</c>.
        /// </value>
        public bool IsInventoryItem { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is fixedasset.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is fixedasset; otherwise, <c>false</c>.
        /// </value>
        public bool IsFixedAsset { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is capital allocate.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is capital allocate; otherwise, <c>false</c>.
        /// </value>
        public bool IsCapitalAllocate { get; set; }

        public bool IsBank { get; set; }
        public bool IsBudgetSubItem { get; set; }

        #endregion

        #region DBOption

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
                var dbOptions = new List<DBOptionModel>
                {
                    new DBOptionModel { OptionId = "SystemDate", OptionValue = ((DateTime)dtStartDate.EditValue).ToShortDateString(), ValueType = 2,
                        Description = "Ngày bắt đầu hạch toán - chọn lúc setup", IsSystem = true },
                    new DBOptionModel { OptionId = "StartedDate", OptionValue = "01/" + cboFinancialMonth.SelectedIndex + 1 + "/" + DateTime.Now.Year, ValueType = 2,
                        Description = "Ngày bắt đầu năm tài chính - 01/tháng của năm tài chính/năm posteddate", IsSystem = true },
                    new DBOptionModel { OptionId = "FinancialEndOfDate", OptionValue = "31/12/" + ((DateTime)dtStartDate.EditValue).Year,
                        ValueType = 2, Description = "Ngày cuối cùng của năm tài chính - 31/12/năm posteddate", IsSystem = true },
                    new DBOptionModel { OptionId = "FinancialMonth", OptionValue = (cboFinancialMonth.SelectedIndex + 1).ToString(CultureInfo.InvariantCulture),
                        ValueType = 1, Description = "Tháng bắt đầu của năm tài chính - chọn lúc setup", IsSystem = true },
                    new DBOptionModel { OptionId = "PostedDate", OptionValue = ((DateTime)dtStartDate.EditValue).ToShortDateString(),
                        ValueType = 2, Description = "Ngày hạch toán", IsSystem = false },
                    new DBOptionModel { OptionId = "CurrencyAccounting", OptionValue = cboCurrencyAccounting.EditValue.ToString(),
                        ValueType = 0, Description = "Đồng tiền hạch toán", IsSystem = true },
                    new DBOptionModel { OptionId = "CurrencyLocal", OptionValue = cboCurrencyLocal.EditValue.ToString(),
                        ValueType = 0, Description = "Tiền địa phương", IsSystem = true },
                    new DBOptionModel { OptionId = "TransactionalCurrency", OptionValue = cboTransactionalCurrency.EditValue.ToString(),
                        ValueType = 0, Description = "Tiền ngoại tệ quy đổi", IsSystem = true },
                    new DBOptionModel { OptionId = "AccountingPeriodCurrency", OptionValue = (cboAccountingPeriodCurrency.SelectedIndex + 1).ToString(CultureInfo.InvariantCulture),
                        ValueType = 1, Description = "Kỳ hạch toán ngoại tệ (1- Ngày; 2- Tháng; 3- Quý; 4- Năm)", IsSystem = true },
                    new DBOptionModel { OptionId = "AccountingMethodCurrency", OptionValue = (cboAccountingMethodCurrency.SelectedIndex + 1).ToString(CultureInfo.InvariantCulture),
                        ValueType = 1, Description = "Phương pháp hạch toán tỷ giá (1- Thực tế; 2- Hạch toán)", IsSystem = true },
                    new DBOptionModel { OptionId = "CurrencyCodeOfSalary", OptionValue = cboCurrencyCodeOfSalary.EditValue.ToString(),
                        ValueType = 0, Description = "Đồng tiền trả lương", IsSystem = true },
                    new DBOptionModel { OptionId = "CompanyCode", OptionValue = lookUpEditCompany.EditValue.ToString(), ValueType = 0, Description = "Mã số đơn vị",
                        IsSystem = false },
                    new DBOptionModel { OptionId = "CompanyName", OptionValue = txtUnitName.Text, ValueType = 0, Description = "Tên đơn vị", IsSystem = false },
                    new DBOptionModel { OptionId = "CompanyAdrress", OptionValue = txtUnitAddress.Text, ValueType = 0, Description = "Địa chỉ đơn vị", IsSystem = false },
                    new DBOptionModel { OptionId = "CoefficientOfSalaryByArea", OptionValue = CoefficientOfSalaryByArea, ValueType = 1, Description = "Hệ số lương địa bàn", IsSystem = false }
                };
                return dbOptions;
            }
            set
            {
                var dbOptions = value;
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmCreateNewDatabase" /> class.
        /// </summary>
        public FrmCreateNewDatabase()
        {
            InitializeComponent();
            _dbOptionsPresenter = new DBOptionsPresenter(this);
            _currencyPresenter = new CurrencyPresenter(this);
            _accountPresenter = new AccountPresenter(this);
            _payItemsPresenter = new PayItemsPresenter(this);
            _payItemPresenter = new PayItemPresenter(this);
            _autoBusinessPresenter = new AutoBusinessPresenter(this);
            _autoBusinessesPresenter = new AutoBusinessesPresenter(this);
        }

        /// <summary>
        /// Handles the Click event of the btnExit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Handles the Click event of the btnPrevious control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            btnPrevious.Enabled = true;
            tabMain.SelectedTabPage = tabMain.TabPages[tabMain.SelectedTabPage.TabIndex - 1];
            btnNext.Enabled = true;
        }

        /// <summary>
        /// Handles the Click event of the btnNext control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        private void btnNext_Click(object sender, EventArgs e)
        {
            btnNext.Enabled = true;
            btnPrevious.Enabled = true;

            //valid data
            if (tabMain.SelectedTabPage.Name.Equals("tabSetupDatabase"))
            {
                if (_server.Databases.Cast<Database>().Any(database => txtDatabaseName.Text.Trim().Equals(database.Name)))
                {
                    txtDatabaseName.Focus();
                    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDatabaseExit"),
                                        ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else if (tabMain.SelectedTabPage.Name.Equals("tabInfoCompany"))
            {
                if (string.IsNullOrEmpty(lookUpEditCompany.EditValue.ToString()))
                {
                    lookUpEditCompany.Focus();
                    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResCompanyCode"),
                        ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            tabMain.SelectedTabPage = tabMain.TabPages[tabMain.SelectedTabPage.TabIndex + 1];
        }

        /// <summary>
        /// Handles the SelectedPageChanged event of the tabMain control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DevExpress.XtraTab.TabPageChangedEventArgs" /> instance containing the event data.</param>
        private void tabMain_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            btnFinish.Enabled = false;
            if (tabMain.SelectedTabPage.Name.Equals("tabFinishSetup"))
            {
                btnNext.Enabled = false;
                btnFinish.Enabled = true;
            }
            if (tabMain.SelectedTabPage.Name.Equals("tabTypeOfCreate"))
                btnPrevious.Enabled = false;
            if (tabMain.SelectedTabPage.Name.Equals("tabSetupDatabase"))
                txtDatabaseName.Focus();
            if (tabMain.SelectedTabPage.Name.Equals("tabInfoCompany"))
                lookUpEditCompany.Focus();
            if (tabMain.SelectedTabPage.Name.Equals("tabYearOfAccounting"))
                dtStartDate.Focus();
            if (tabMain.SelectedTabPage.Name.Equals("tabSetupCurrency"))
                cboCurrencyAccounting.Focus();
        }

        /// <summary>
        /// Handles the Load event of the FrmCreateNewDatabase control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void FrmCreateNewDatabase_Load(object sender, EventArgs e)
        {
            try
            {
                txtDatabaseName.EditValue = @"KTCQDD_" + DateTime.Now.Year;
                var dataPath = RegistryHelper.GetValueByRegistryKey("DatabasePath");
                btnDatabasePath.EditValue = string.IsNullOrEmpty(dataPath) ? "" : dataPath.Substring(0, dataPath.LastIndexOf("\\", StringComparison.Ordinal));
                memoDescription.EditValue = @"Cơ sở dữ liệu kế toán cho các cơ quan đại diện";
                dtStartDate.EditValue = DateTime.Parse("01/01/" + DateTime.Now.Year);
                LoadServerConnection();
                LoadCompany();
                LoadCurrency();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(),
                    ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the ButtonClick event of the btnSelectFile control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DevExpress.XtraEditors.Controls.ButtonPressedEventArgs" /> instance containing the event data.</param>
        private void btnSelectFile_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                var folderBrowserDialog = new FolderBrowserDialog
                {
                    SelectedPath = AppDomain.CurrentDomain.BaseDirectory + DatabasePath
                };
                if (folderBrowserDialog.ShowDialog() != DialogResult.OK) return;
                btnDatabasePath.Text = folderBrowserDialog.SelectedPath;
                System.Windows.Forms.Application.DoEvents();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(),
                    ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of the rndCreateNew control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void rndCreateNew_CheckedChanged(object sender, EventArgs e)
        {
            _typeOfCreateDatabase = rndCreateNew.Checked ? 1 : 2;
            grdDatabaseOld.Visible = _typeOfCreateDatabase != 1;
        }

        /// <summary>
        /// Handles the CheckedChanged event of the rndCreateByOldDatabase control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void rndCreateByOldDatabase_CheckedChanged(object sender, EventArgs e)
        {
            _typeOfCreateDatabase = rndCreateByOldDatabase.Checked ? 2 : 1;
            grdDatabaseOld.Visible = _typeOfCreateDatabase == 2;
        }

        /// <summary>
        /// Handles the ButtonClick event of the btnOldDatabasePath control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DevExpress.XtraEditors.Controls.ButtonPressedEventArgs"/> instance containing the event data.</param>
        private void btnOldDatabasePath_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                var openFileDialog = new OpenFileDialog
                {
                    Title = Properties.Resources.SelectDataFileCaption,
                    InitialDirectory = AppDomain.CurrentDomain.BaseDirectory,
                    RestoreDirectory = true
                };
                if (openFileDialog.ShowDialog() != DialogResult.OK) return;
                txtOldDatabaseName.EditValue = System.IO.Path.GetFileName(openFileDialog.FileName);
                btnOldDatabasePath.EditValue = System.IO.Path.GetDirectoryName(openFileDialog.FileName);
                System.Windows.Forms.Application.DoEvents();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(),
                    ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the EditValueChanged event of the lookUpEditCompany control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void lookUpEditCompany_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                cboCurrencyAccounting.EditValue = lookUpEditCompanyView.GetRowCellValue(lookUpEditCompanyView.FocusedRowHandle, "MainCurrencyCode");
                cboCurrencyLocal.EditValue = lookUpEditCompanyView.GetRowCellValue(lookUpEditCompanyView.FocusedRowHandle, "LocalCurrencyCode");
                cboCurrencyCodeOfSalary.EditValue = lookUpEditCompanyView.GetRowCellValue(lookUpEditCompanyView.FocusedRowHandle, "LocalCurrencyCode");
                cboTransactionalCurrency.EditValue = lookUpEditCompanyView.GetRowCellValue(lookUpEditCompanyView.FocusedRowHandle, "LocalCurrencyCode");
                txtUnitName.EditValue = lookUpEditCompanyView.GetRowCellValue(lookUpEditCompanyView.FocusedRowHandle, "CompanyName");
                CoefficientOfSalaryByArea = lookUpEditCompanyView.GetRowCellValue(lookUpEditCompanyView.FocusedRowHandle, "CoefficientOfSalaryByArea").ToString();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(),
                    ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of the chkTransactionalCurrency control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void chkTransactionalCurrency_CheckedChanged(object sender, EventArgs e)
        {
            cboTransactionalCurrency.Enabled = chkTransactionalCurrency.Checked;
        }

        /// <summary>
        /// Handles the Click event of the btnFinish control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                var restore = new Restore
                {
                    Action = RestoreActionType.Database,
                    Database = txtDatabaseName.Text.Trim(),
                    ReplaceDatabase = true,
                    ContinueAfterError = true
                };

                if (!System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory + DatabaseTemplatePath))
                {
                    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDatabaseTempNotExist"), ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var backupDeviceItem = new BackupDeviceItem(AppDomain.CurrentDomain.BaseDirectory + DatabaseTemplatePath, DeviceType.File);
                restore.Devices.Add(backupDeviceItem);
                var fileList = restore.ReadFileList(_server);

                restore.RelocateFiles.Add(new RelocateFile(fileList.Rows[0][0].ToString().Trim(), btnDatabasePath.Text + @"\" + txtDatabaseName.Text.Trim() + ".mdf"));
                restore.RelocateFiles.Add(new RelocateFile(fileList.Rows[1][0].ToString().Trim(), btnDatabasePath.Text + @"\" + txtDatabaseName.Text.Trim() + "_log.ldf"));

                restore.SqlRestore(_server);
                var database = _server.Databases[txtDatabaseName.Text.Trim()];
                if (database != null)
                    database.SetOnline();

                ////LinhMC change logicalName, ThangNK comment lại khi chuyển sang tư vấn nó ko lỗi
                //if (_server != null)
                //{
                //    var databaseName = txtDatabaseName.Text.Trim();
                //    string strCommand = "ALTER DATABASE " + databaseName + " MODIFY FILE (NAME = aBigTime, NEWNAME = " +
                //                        databaseName + "); ALTER DATABASE " + databaseName +
                //                        " MODIFY FILE (NAME = aBigTime_log, NEWNAME = " + databaseName + "_log);";

                //    _server.ConnectionContext.ExecuteNonQuery(strCommand);
                //}

                //update registry
                RegistryHelper.RemoveConnectionString();
                RegistryHelper.SetValueForRegistry("DatabaseName", txtDatabaseName.Text);
                RegistryHelper.SetValueForRegistry("DatabasePath", btnDatabasePath.Text + @"\");
                RegistryHelper.SaveConfigFile();

                //update options
                var message = _dbOptionsPresenter.Save();
                if (message != null)
                {
                    XtraMessageBox.Show(message, ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //update currency
                    _currencyPresenter.DisplayByCurrencyCode(cboCurrencyAccounting.EditValue == null ? null : cboCurrencyAccounting.EditValue.ToString());
                    if (CurrencyId != 0)
                    {
                        IsActive = true;
                        _currencyPresenter.Save();
                    }
                    _currencyPresenter.DisplayByCurrencyCode(cboCurrencyAccounting.EditValue == null ? null : cboCurrencyLocal.EditValue.ToString());
                    if (CurrencyId != 0)
                    {
                        IsActive = true;
                        _currencyPresenter.Save();
                    }
                    _currencyPresenter.DisplayByCurrencyCode(cboCurrencyAccounting.EditValue == null ? null : cboCurrencyCodeOfSalary.EditValue.ToString());
                    if (CurrencyId != 0)
                    {
                        IsActive = true;
                        _currencyPresenter.Save();
                    }
                    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResCreateDBSucces"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                //update account
                _accountPresenter.DisplayByAccountCode("11122");
                CurrencyCode = cboCurrencyLocal.EditValue.ToString().Trim();
                _accountPresenter.Save();

                _accountPresenter.DisplayByAccountCode("11222");
                CurrencyCode = cboCurrencyLocal.EditValue.ToString().Trim();
                _accountPresenter.Save();

                //update cac khoan luong
                LoadPayItem();
                if (cboCurrencyCodeOfSalary.EditValue.Equals("USD"))
                {
                    foreach (var payItem in _payItems)
                    {
                        _payItemPresenter.Display(payItem.PayItemId.ToString(CultureInfo.InvariantCulture));
                        CreditAccountCode = "11121";
                        _payItemPresenter.Save();
                    }
                }
                else
                {
                    foreach (var payItem in _payItems)
                    {
                        _payItemPresenter.Display(payItem.PayItemId.ToString(CultureInfo.InvariantCulture));
                        CreditAccountCode = "11122";
                        _payItemPresenter.Save();
                    }
                }

                LoadAutoBusiness();
                if (cboCurrencyLocal.EditValue != null && cboCurrencyAccounting.EditValue != null)
                {
                    var lstAutoBusinessByNotUSD = _autoAutoBusiness.Where(w => w.CurrencyCode != null && w.CurrencyCode != string .Empty && w.CurrencyCode != cboCurrencyAccounting.EditValue.ToString()).ToList();

                    foreach (var autoBusiness in lstAutoBusinessByNotUSD)
                    {
                        _autoBusinessPresenter.Display(autoBusiness.AutoBusinessId.ToString(CultureInfo.InvariantCulture));
                        CurrencyCode = cboCurrencyLocal.EditValue.ToString();
                        _autoBusinessPresenter.Save();
                    }
                }

                Cursor = Cursors.Default;
                System.Windows.Forms.Application.Restart();
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.ToString(),
                    ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Functions

        /// <summary>
        /// Loads the company.
        /// </summary>
        private void LoadCompany()
        {
            try
            {
                var dataSet = new DataSet();
                dataSet.ReadXml(AppDomain.CurrentDomain.BaseDirectory + XmlCompany);
                lookUpEditCompany.Properties.DataSource = dataSet.Tables[0];
                lookUpEditCompanyView.PopulateColumns(dataSet.Tables[0]);
                var gridColumnsCollection = new List<XtraColumn> {
                                                new XtraColumn { ColumnName = "CompanyCode", ColumnCaption = "Mã đơn vị", ColumnPosition = 1, ColumnWith =  150, ColumnVisible = true},
                                                new XtraColumn { ColumnName = "CompanyName", ColumnCaption = "Tên đơn vị", ColumnPosition = 2, ColumnWith =  300, ColumnVisible = true },
                                                new XtraColumn { ColumnName = "MainCurrencyCode", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "LocalCurrencyCode", ColumnVisible = false },
                                                new XtraColumn { ColumnName = "CoefficientOfSalaryByArea", ColumnVisible = false },
                                            };

                foreach (var column in gridColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        lookUpEditCompanyView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        lookUpEditCompanyView.Columns[column.ColumnName].SortIndex = column.ColumnPosition;
                        lookUpEditCompanyView.Columns[column.ColumnName].Width = column.ColumnWith;
                    }
                    else
                        lookUpEditCompanyView.Columns[column.ColumnName].Visible = false;
                }
                lookUpEditCompany.Properties.DisplayMember = "CompanyCode";
                lookUpEditCompany.Properties.ValueMember = "CompanyCode";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(),
                    ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Loads the currency.
        /// </summary>
        private void LoadCurrency()
        {
            try
            {
                var dataSet = new DataSet();
                dataSet.ReadXml(AppDomain.CurrentDomain.BaseDirectory + XmlCurrency);
                for (var i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    cboCurrencyAccounting.Properties.Items.Add(dataSet.Tables[0].Rows[i]["CurrencyCode"].ToString());
                    cboTransactionalCurrency.Properties.Items.Add(dataSet.Tables[0].Rows[i]["CurrencyCode"].ToString());
                    cboCurrencyLocal.Properties.Items.Add(dataSet.Tables[0].Rows[i]["CurrencyCode"].ToString());
                    cboCurrencyCodeOfSalary.Properties.Items.Add(dataSet.Tables[0].Rows[i]["CurrencyCode"].ToString());
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(),
                    ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Loads the pay item.
        /// </summary>
        private void LoadPayItem()
        {
            _payItemsPresenter.Display();
        }

        private void LoadAutoBusiness()
        {
            _autoBusinessesPresenter.DisplayActive();
        }

        /// <summary>
        /// Loads the server connection.
        /// </summary>
        private void LoadServerConnection()
        {
            //connection
            _serverConnection = new ServerConnection(RegistryHelper.GetValueByRegistryKey("InstanceName"))
            {
                LoginSecure = false,
                Login = RegistryHelper.GetValueByRegistryKey("UserName"),
                //Password = RegistryHelper.GetValueByRegistryKey("Password")
                Password = Crypto.Decrypting(RegistryHelper.GetValueByRegistryKey("Password"), "@bgt1me")
            };
            //create server
            _server = new Server(_serverConnection);
        }

        #endregion

        #region Currency

        /// <summary>
        /// Gets or sets the currency identifier.
        /// </summary>
        /// <value>
        /// The currency identifier.
        /// </value>
        public int CurrencyId { get; set; }

        /// <summary>
        /// Gets or sets the currency code.
        /// </summary>
        /// <value>
        /// The currency code.
        /// </value>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the currency.
        /// </summary>
        /// <value>
        /// The name of the currency.
        /// </value>
        public string CurrencyName { get; set; }

        /// <summary>
        /// Gets or sets the prefix.
        /// </summary>
        /// <value>
        /// The prefix.
        /// </value>
        public string Prefix { get; set; }

        /// <summary>
        /// Gets or sets the suffix.
        /// </summary>
        /// <value>
        /// The suffix.
        /// </value>
        public string Suffix { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is main.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is main; otherwise, <c>false</c>.
        /// </value>
        public bool IsMain { get; set; }

        public bool IsDefault { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }

        public string BudgetSourceCode { get; set; }
        public string BudgetCategoryCode { get; set; }
        public string BudgetGroupCode { get; set; }
        public string BudgetItemCode { get; set; }

        #endregion

        #region Account

        public int AccountId { get; set; }

        public int? AccountCategoryId { get; set; }

        public string AccountCode { get; set; }

        public string AccountName { get; set; }

        public string ForeignName { get; set; }

        public int? ParentId { get; set; }

        public int Grade { get; set; }

        public bool IsDetail { get; set; }

        #endregion

        #region AutoBusiness

        public IList<AutoBusinessModel> AutoBusinesses
        {
            set
            {
                _autoAutoBusiness = new List<AutoBusinessModel>();
                _autoAutoBusiness = value;
            }
        }

        public int AutoBusinessId { get; set; }

        public string AutoBusinessCode { get; set; }

        public string AutoBusinessName { get; set; }

        public int RefTypeId { get; set; }

        public int? VoucherTypeId { get; set; }

        public string DebitAccountNumber { get; set; }

        public string CreditAccountNumber { get; set; }

        #endregion

        private void btnHelp_Click(object sender, EventArgs e)
        {
            if (!File.Exists("BIGTIME.CHM"))
            {
                XtraMessageBox.Show("Không tìm thấy tệp trợ giúp!", "Lỗi thiếu file", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Help.ShowHelp(this, System.Windows.Forms.Application.StartupPath + @"\BIGTIME.CHM", HelpNavigator.TopicId, Convert.ToString(1090));
        }
    }
}
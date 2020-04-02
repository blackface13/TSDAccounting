/***********************************************************************
 * <copyright file="FrmLogin.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 30 May 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Diagnostics;
using System.Globalization;
using System.Linq;
using TSD.AccountingSoft.Presenter.Dictionary.AudittingLog;
using TSD.AccountingSoft.Session;
using TSD.AccountingSoft.Presenter.System.UserProfile;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.View.System;
using TSD.AccountingSoft.WindowsForm.Annotations;
using TSD.AccountingSoft.WindowsForm.Resources;
using DevExpress.XtraEditors;
using System;
using System.IO;
using System.Windows.Forms;
using TSD.AccountingSoft.WindowsForm.CommonClass;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using TSD.Option;


namespace TSD.AccountingSoft.WindowsForm.FormSystem
{
    /// <summary>
    /// FrmLogin
    /// </summary>
    public partial class FrmLogin : XtraForm, IUserProfileView, IAudittingLogView
    {
        [UsedImplicitly]
        private static GlobalVariable _dbOptionHelper;
        private readonly UserProfilePresenter _userProfilePresenter;
        /// <summary>
        /// The _auditting log presenter
        /// </summary>
        private readonly AudittingLogPresenter _audittingLogPresenter;

        public delegate void EventPostLoginState(object sender, bool keyValue);
        public event EventPostLoginState PostLoginState;
        private readonly Crypto Crypto = new Crypto(Crypto.SymmProvEnum.Rijndael);

        #region UserProfile Members

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public int UserProfileId { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public string UserProfileName
        {
            get { return txtUserProfileName.Text; }
            set { txtUserProfileName.Text = value; }
        }

        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        /// <value>
        /// The full name.
        /// </value>
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password
        {
            get { return string.IsNullOrEmpty(txtPassword.Text) ? null : txtPassword.Text; }
            set { txtPassword.Text = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [is active].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is active]; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the create date.
        /// </summary>
        /// <value>
        /// The create date.
        /// </value>
        public string CreateDate { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        #endregion

        #region Functions

        /// <summary>
        /// Loads the option.
        /// </summary>
        private static void LoadOption()
        {
            //load option
            _dbOptionHelper = new GlobalVariable();
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo(ResourceHelper.ResourceLanguage)
            {
                NumberFormat =
                {
                    CurrencySymbol = _dbOptionHelper.CurrencySymbol,
                    CurrencyDecimalSeparator = _dbOptionHelper.CurrencyDecimalSeparator,
                    CurrencyGroupSeparator = _dbOptionHelper.CurrencyGroupSeparator,
                    CurrencyDecimalDigits = int.Parse(_dbOptionHelper.CurrencyDecimalDigits),
                    NumberDecimalSeparator = _dbOptionHelper.CurrencyDecimalSeparator,
                    NumberGroupSeparator = _dbOptionHelper.CurrencyGroupSeparator
                }
            };
        }

        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns></returns>
        private bool ValidData()
        {
            var databaseName = RegistryHelper.GetValueByRegistryKey("DatabaseName");
            //connection
            var serverConnection = new ServerConnection(RegistryHelper.GetValueByRegistryKey("InstanceName"))
            {
                LoginSecure = false,
                Login = RegistryHelper.GetValueByRegistryKey("UserName"),
                Password =  Crypto.Decrypting(RegistryHelper.GetValueByRegistryKey("Password"), "@bgt1me")
            };
            //create server
            var server = new Server(serverConnection);
            if (!server.Databases.Cast<Database>().Any(d => databaseName.Equals(d.Name)))
            {
                XtraMessageBox.Show("Dữ liệu bạn đang mở " + databaseName + " có thể bị lỗi, hoặc đã bị xóa không đúng quy cách. Vui lòng kiểm tra lại, hoặc chọn mở một cơ sở dữ liệu khác!",
                                    ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            var filePath = server.Databases[databaseName].PrimaryFilePath + @"\" + databaseName + ".mdf";

            var ds =
                   server.Databases["Master"].ExecuteWithResults(
                       "SET QUOTED_IDENTIFIER OFF EXEC xp_fileexist '" +
                       filePath + "'");
            if (ds != null && Convert.ToInt32(ds.Tables[0].Rows[0][0]) == 0)
            {
                XtraMessageBox.Show(
                    "Tệp dữ liệu vật lý có đường dẫn [" + filePath + "] đã không tồn tại trên phân vùng ổ cứng. Vui lòng kiểm tra lại",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            // Check version 
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.ProductVersion;
            //string version2 = assembly.GetName().Version.ToString();

            _dbOptionHelper = new GlobalVariable();
            if (version != _dbOptionHelper.Version)
            {
                string[] versions = version.Split('.');
                string[] versionDBs = _dbOptionHelper.Version.Split('.');
                int versionWord2 = int.Parse(versions[1]);
                int versionDBWord2 = int.Parse(versionDBs[1]);
                int versionWord1 = int.Parse(versions[0]);
                int versionDBWord1 = int.Parse(versionDBs[0]);
                int versionWord3 = int.Parse(versions[2]);
                int versionDBWord3 = int.Parse(versionDBs[2]);
                int versionWord4 = 0;
                int versionDBWord4 = 0;
                if (versions.Count() > 3)
                    versionWord4 = int.Parse(versions[3]);
                if (versionDBs.Count() > 3)
                    versionDBWord4 = int.Parse(versionDBs[3]);

                if (versionWord1 > versionDBWord1)
                {
                    XtraMessageBox.Show("Bạn đang sử dụng phiên bản bộ cài " + version + " và phiên bản cơ sở dữ liệu " + _dbOptionHelper.Version + "! Phiên bản bộ cài đang lớn hơn phiên bản cơ sở dữ liệu!", ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (versionWord1 < versionDBWord1)
                {
                    XtraMessageBox.Show("Bạn đang sử dụng phiên bản bộ cài " + version + " và phiên bản cơ sở dữ liệu " + _dbOptionHelper.Version + "! Phiên bản bộ cài đang bé hơn phiên bản cơ sở dữ liệu!", ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (versionWord1 == versionDBWord1)
                {
                    if (versionWord2 > versionDBWord2)
                    {
                        XtraMessageBox.Show("Bạn đang sử dụng phiên bản bộ cài " + version + " và phiên bản cơ sở dữ liệu " + _dbOptionHelper.Version + "! Phiên bản bộ cài đang lớn hơn phiên bản cơ sở dữ liệu!", ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    if (versionWord2 < versionDBWord2)
                    {
                        XtraMessageBox.Show("Bạn đang sử dụng phiên bản bộ cài " + version + " và phiên bản cơ sở dữ liệu " + _dbOptionHelper.Version + "! Phiên bản bộ cài đang bé hơn phiên bản cơ sở dữ liệu!", ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    if (versionWord2 == versionDBWord2)
                    {
   
                        if (versionWord3 > versionDBWord3)
                        {
                            XtraMessageBox.Show("Bạn đang sử dụng phiên bản bộ cài " + version + " và phiên bản cơ sở dữ liệu " + _dbOptionHelper.Version + "! Phiên bản bộ cài đang lớn hơn phiên bản cơ sở dữ liệu!", ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }

                        if (versionWord3 < versionDBWord3)
                        {
                            XtraMessageBox.Show("Bạn đang sử dụng phiên bản bộ cài " + version + " và phiên bản cơ sở dữ liệu " + _dbOptionHelper.Version + "! Phiên bản bộ cài đang bé hơn phiên bản cơ sở dữ liệu!", ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }

                        if (versionWord3 == versionDBWord3)
                        {
                                    
                            if (versionWord4 > versionDBWord3)
                            {
                                XtraMessageBox.Show("Bạn đang sử dụng phiên bản bộ cài " + version + " và phiên bản cơ sở dữ liệu " + _dbOptionHelper.Version + "! Phiên bản bộ cài đang lớn hơn phiên bản cơ sở dữ liệu!", ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }

                            if (versionWord4 < versionDBWord4)
                            {
                                XtraMessageBox.Show("Bạn đang sử dụng phiên bản bộ cài " + version + " và phiên bản cơ sở dữ liệu " + _dbOptionHelper.Version + "! Phiên bản bộ cài đang bé hơn phiên bản cơ sở dữ liệu!", ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                        }
                    }
                }
                
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResVersion"), ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        #endregion

        #region Events

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmLogin"/> class.
        /// </summary>
        public FrmLogin()
        {
            InitializeComponent();
            _userProfilePresenter = new UserProfilePresenter(this);
            _audittingLogPresenter = new AudittingLogPresenter(this);
        }

        /// <summary>
        /// Handles the Load event of the FrmLogin control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            if (RegistryHelper.GetValueByRegistryKey("UserLogin") != null)
                txtUserProfileName.EditValue = RegistryHelper.GetValueByRegistryKey("UserLogin");
        }

        /// <summary>
        /// Handles the Click event of the btnExit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            if (PostLoginState != null)
                PostLoginState(this, false);
            Close();
        }

        /// <summary>
        /// Có một lỗi hay xảy ra là trường hợp tên dữ liệu được lưu trong registry không đúng, không tồn tại
        /// dẫn đến việc phát sinh lỗi, không mở được dữ liệu. Phải can thiệp khó khăn
        /// Giải pháp là kiểm tra tên dữ liệu có tồn tại không, trước khi thực hiện các lệnh khác.
        /// 
        /// Handles the Click event of the btnLogin control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {

                if (!ValidData())
                    return;
                //check valid user
                _userProfilePresenter.DisplayByUserProfileName(UserProfileName, Password);
                if (UserProfileId == 0)
                {
                    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResLoginFailded"), ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Focus();
                }

                if (PostLoginState != null)
                    PostLoginState(this, true);
                LoadOption();
                GlobalVariable.LoginName = UserProfileName;
                _audittingLogPresenter.Save();
                Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
            }
        }

        #endregion

        private void txtUserProfileName_EditValueChanged(object sender, EventArgs e)
        {

        }

        #region AuditingLog Member

        /// <summary>
        /// Gets or sets the event identifier.
        /// </summary>
        /// <value>
        /// The event identifier.
        /// </value>
        public int EventId { get; set; }

        /// <summary>
        /// Gets or sets the name of the login.
        /// </summary>
        /// <value>
        /// The name of the login.
        /// </value>
        public string LoginName
        {
            get { return GlobalVariable.LoginName; }
            set { }
        }

        /// <summary>
        /// Gets or sets the name of the computer.
        /// </summary>
        /// <value>
        /// The name of the computer.
        /// </value>
        public string ComputerName
        {
            get { return Environment.MachineName; }
            set { }
        }

        /// <summary>
        /// Gets or sets the event time.
        /// </summary>
        /// <value>
        /// The event time.
        /// </value>
        public DateTime EventTime
        {
            get { return DateTime.Now; }
            set { }
        }

        /// <summary>
        /// Gets or sets the name of the component.
        /// </summary>
        /// <value>
        /// The name of the component.
        /// </value>
        public string ComponentName
        {
            get { return "Đăng nhập"; }
            set { }
        }

        /// <summary>
        /// Gets or sets the event action.
        /// </summary>
        /// <value>
        /// The event action.
        /// </value>
        public int EventAction
        {
            get
            {
                return 7;
            }
            set { }
        }

        /// <summary>
        /// Gets or sets the reference.
        /// </summary>
        /// <value>
        /// The reference.
        /// </value>
        public string Reference
        {
            get
            {
                return "Đăng nhập";
            }
            set { }
        }

        /// <summary>
        /// Gets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public decimal Amount { get; set; }

        #endregion

        private void btnHelp_Click(object sender, EventArgs e)
        {
            if (!File.Exists("BIGTIME.CHM"))
            {
                XtraMessageBox.Show("Không tìm thấy tệp trợ giúp!", "Lỗi thiếu file", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Help.ShowHelp(this, System.Windows.Forms.Application.StartupPath + @"\BIGTIME.CHM", HelpNavigator.TopicId, Convert.ToString(1000));
        }
    }
}
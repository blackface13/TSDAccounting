using System;
using System.IO;
using System.Windows.Forms;
using TSD.AccountingSoft.Session;
using TSD.AccountingSoft.WindowsForm.CommonClass;
using TSD.AccountingSoft.WindowsForm.Resources;
using DevExpress.XtraEditors;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;


namespace TSD.AccountingSoft.WindowsForm.FormSystem
{
    /// <summary>
    /// FrmXtraRestoreData
    /// </summary>
    public partial class FrmXtraRestoreData : XtraForm
    {
        public FrmXtraRestoreData()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Handles the Click event of the btnOk control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                var restore = new Restore
                {
                    Action = RestoreActionType.Database,
                    Database = txtDatabaseName.Text.Trim(),
                    ReplaceDatabase = true,
                    ContinueAfterError = true,
                };

                var backupDeviceItem = new BackupDeviceItem(btnSelectFile.Text, DeviceType.File);
                restore.Devices.Add(backupDeviceItem);
                var fileList = restore.ReadFileList(GlobalVariable.Server);

                restore.RelocateFiles.Add(new RelocateFile(fileList.Rows[0][0].ToString().Trim(), txtDatabaseNewPath.Text + @"\" + txtDatabaseName.Text.Trim() + ".mdf"));
                restore.RelocateFiles.Add(new RelocateFile(fileList.Rows[1][0].ToString().Trim(), txtDatabaseNewPath.Text + @"\" + txtDatabaseName.Text.Trim() + "_log.ldf"));

                restore.SqlRestore(GlobalVariable.Server);
                var database = GlobalVariable.Server.Databases[txtDatabaseName.Text.Trim()];
                if (database != null)
                    database.SetOnline();

                Cursor = Cursors.Default;
                //XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResRestoreDbSucess"),
                //                        ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                //                        MessageBoxIcon.Information);
                if (XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResRestoreDbSucess") + "Bạn muốn sử dụng cơ sở dữ liệu này luôn không?",
                        ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information)
                    == DialogResult.Yes)
                {
                    try
                    {
                        RegistryHelper.SetValueForRegistry("DatabaseName", txtDatabaseName.Text.Trim());
                        RegistryHelper.SetValueForRegistry("DatabasePath", txtDatabaseNewPath.Text + @"\" + txtDatabaseName.Text.Trim() + ".mdf");
                        System.Windows.Forms.Application.Restart();
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.ToString(),
                            ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.ToString(),
                    ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Loads the server connection.
        /// </summary>
        private void LoadServerConnection()
        {
            if (GlobalVariable.ServerConnection == null)
            {
                GlobalVariable.ServerConnection = new ServerConnection(RegistryHelper.GetValueByRegistryKey("InstanceName"))
                {
                    LoginSecure = false,
                    Login = RegistryHelper.GetValueByRegistryKey("UserName"),
                    Password = RegistryHelper.GetValueByRegistryKey("Password")
                };
            }
            //create server
            GlobalVariable.Server = new Server(GlobalVariable.ServerConnection);
        }

        /// <summary>
        /// Handles the ButtonClick event of the btnSelectFile control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DevExpress.XtraEditors.Controls.ButtonPressedEventArgs"/> instance containing the event data.</param>
        private void btnSelectFile_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Title = Properties.Resources.SelectDataFileCaption,
                InitialDirectory = @"D:\",
                FileName = btnSelectFile.Text,
                RestoreDirectory = true,
                Filter = ResourceHelper.GetResourceValueByName("ResBackupFileFilter")
            };
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;
            btnSelectFile.Text = openFileDialog.FileName;
            System.Windows.Forms.Application.DoEvents();
        }

        /// <summary>
        /// Handles the ButtonClick event of the txtDatabaseNewPath control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DevExpress.XtraEditors.Controls.ButtonPressedEventArgs"/> instance containing the event data.</param>
        private void txtDatabaseNewPath_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                using (var folderBrowserDialog = new FolderBrowserDialog())
                {
                    var dialogResult = folderBrowserDialog.ShowDialog();
                    if (dialogResult == DialogResult.OK)
                    {
                        txtDatabaseNewPath.Text = folderBrowserDialog.SelectedPath;
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(),
                    ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the Load event of the FrmXtraRestoreData control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FrmXtraRestoreData_Load(object sender, EventArgs e)
        {
            LoadServerConnection();
        }

        /// <summary>
        /// Handles the Click event of the btnHelp control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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
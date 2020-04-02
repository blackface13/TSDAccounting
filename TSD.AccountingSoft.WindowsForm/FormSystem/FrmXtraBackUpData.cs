/***********************************************************************
 * <copyright file="FrmXtraBackUpData.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 24 June 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using TSD.AccountingSoft.Session;
using TSD.AccountingSoft.WindowsForm.CommonClass;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.Resources;
using DevExpress.XtraEditors;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using Ionic.Zip;
using TSD.Option;

namespace TSD.AccountingSoft.WindowsForm.FormSystem
{
    public partial class FrmXtraBackUpData : XtraForm
    {
        #region Events

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmXtraBackUpData"/> class.
        /// </summary>
        private readonly Crypto Crypto = new Crypto(Crypto.SymmProvEnum.Rijndael);
        public FrmXtraBackUpData()
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
                var valid = ValidData();
                if (!valid) return;
                var databaseNameForBackup = (string)gridView.GetRowCellValue(gridView.FocusedRowHandle, "DatabaseName");
                var databaseForBackup = GlobalVariable.Server.Databases[databaseNameForBackup];
                var backup = new Backup
                    {
                        //option for backup
                        Action = BackupActionType.Database,
                        BackupSetDescription = memoDescription.Text,
                        BackupSetName = databaseNameForBackup + " Backup",
                        Database = databaseForBackup.Name
                    };

                //create backupdevice
                var fileBackup = btnSelectFile.Text + @"\" + txtDatabaseName.Text + ".bak";

                if (File.Exists(fileBackup))
                {
                    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResFileBackupExits"),
                        ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDatabaseName.Focus();
                    return;
                }
                var backupDevice = new BackupDeviceItem(btnSelectFile.Text + @"\" + txtDatabaseName.Text + ".bak", DeviceType.File);

                backup.Devices.Add(backupDevice);
                backup.Incremental = false;

                backup.SqlBackup(GlobalVariable.Server);
                //Cách nén file này chỉ dùng trong trường hợp hệ quản trị dữ liệu và chương trình cùng nằm trên 1 máy
                if (chkIsCompressionBackupFile.Checked)
                {
                    using (var zip = new ZipFile())
                    {
                        zip.AddFile(fileBackup, "");
                        var zipFileName = btnSelectFile.Text + @"\" + txtDatabaseName.Text + ".zip";
                        zip.ParallelDeflateThreshold = -1;
                        zip.Save(zipFileName);
                        File.Delete(fileBackup);
                    }
                }

                SetRowSelected();

                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResBackupSucess"),
                   ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                RegistryHelper.SetValueForRegistry("IsCompressionBackupFile", chkIsCompressionBackupFile.Checked.ToString().ToLower());
                RegistryHelper.SetValueForRegistry("BackupPath", btnSelectFile.Text);
                Process.Start(btnSelectFile.Text);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(),
                    ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the Load event of the FrmXtraBackUpData control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void FrmXtraBackUpData_Load(object sender, EventArgs e)
        {
            try
            {
                InitControls();
                LoadServerConnection();
                LoadDatabase();
                LoadGridLayout();
                SetRowSelected();
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
        /// <param name="e">The <see cref="DevExpress.XtraEditors.Controls.ButtonPressedEventArgs"/> instance containing the event data.</param>
        private void btnSelectFile_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                using (var folderBrowserDialog = new FolderBrowserDialog())
                {
                    var dialogResult = folderBrowserDialog.ShowDialog();
                    if (dialogResult == DialogResult.OK)
                    {
                        btnSelectFile.Text = folderBrowserDialog.SelectedPath;
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(),
                    ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Functions

        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns></returns>
        private bool ValidData()
        {
            if (string.IsNullOrEmpty(btnSelectFile.Text))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResBackupFileCaption"),
                    ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnSelectFile.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtDatabaseName.Text))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResBackupDatabaseName"),
                    ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDatabaseName.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// Initializes the controls.
        /// </summary>
        private void InitControls()
        {
            grdMain.ForceInitialize();
            btnSelectFile.Focus();
            var backupPath = RegistryHelper.GetValueByRegistryKey("BackupPath");
            btnSelectFile.Text = backupPath;
            var isCompressionBackupFile = RegistryHelper.GetValueByRegistryKey("IsCompressionBackupFile");
            chkIsCompressionBackupFile.Checked = Convert.ToBoolean(isCompressionBackupFile);
        }

        /// <summary>
        /// Loads the grid layout.
        /// </summary>
        private void LoadGridLayout()
        {
            var columnsCollection = new List<XtraColumn>
                {
                    new XtraColumn
                        {
                            ColumnName = "DatabaseName",
                            ColumnCaption = "Tên cơ sở dữ liệu",
                            ColumnPosition = 1,
                            ColumnVisible = true,
                            ColumnWith = 150
                        },
                    new XtraColumn
                        {
                            ColumnName = "DatabasePath",
                            ColumnCaption = "Đường dẫn cơ sở dữ liệu",
                            ColumnPosition = 2,
                            ColumnVisible = true,
                            ColumnWith = 300
                        },
                    new XtraColumn {ColumnName = "Description", ColumnVisible = false}
                };

            foreach (var column in columnsCollection)
            {
                if (column.ColumnVisible)
                {

                    gridView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                    gridView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                    gridView.Columns[column.ColumnName].Width = column.ColumnWith;
                }
                else
                    gridView.Columns[column.ColumnName].Visible = false;
            }
        }

        /// <summary>
        /// Loads the database.
        /// </summary>
        private void LoadDatabase()
        {
            gridView.BeginUpdate();
            var serverName = RegistryHelper.GetValueByRegistryKey("InstanceName");
            var databaseOwner = RegistryHelper.GetValueByRegistryKey("UserName");
            var databaseOwnerPassword = Crypto.Decrypting(RegistryHelper.GetValueByRegistryKey("Password"), "@bgt1me");
            var list = CommonFunction.GetDatabaseNames(serverName, databaseOwner, databaseOwnerPassword);

            if (list.Count <= 0) return;
            grdMain.DataSource = list;
            gridView.EndUpdate();
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
                    Password = Crypto.Decrypting(RegistryHelper.GetValueByRegistryKey("Password"), "@bgt1me")
                };
            }
            //create server
            GlobalVariable.Server = new Server(GlobalVariable.ServerConnection);
        }

        /// <summary>
        /// Sets the row selected.
        /// </summary>
        private void SetRowSelected()
        {
            gridView.OptionsSelection.EnableAppearanceFocusedRow = true;
            gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            if (gridView.RowCount > 0)
                gridView.FocusedRowHandle = 0;
        }

        #endregion

        /// <summary>
        /// LinhMC: Lấy tên dữ liệu vào tên file backup
        /// Handles the FocusedRowChanged event of the gridView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs"/> instance containing the event data.</param>
        private void gridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var databaseName = gridView.GetFocusedRowCellValue("DatabaseName");
            var timeTemp = "_" + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year + "." + DateTime.Now.Hour + "H" + DateTime.Now.Minute;
            txtDatabaseName.Text = databaseName != null ? databaseName + timeTemp : "";
            memoDescription.Text = @"Sao lưu dữ liệu [" + databaseName + @"] ngày " + DateTime.Now.ToLongDateString();
        }
       
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
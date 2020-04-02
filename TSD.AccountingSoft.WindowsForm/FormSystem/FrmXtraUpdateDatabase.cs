/***********************************************************************
 * <copyright file="FrmXtraUpdateDatabase.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 22 July 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using TSD.AccountingSoft.Session;
using TSD.AccountingSoft.WindowsForm.CommonClass;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.Resources;
using DevExpress.XtraEditors;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using TSD.Option;

namespace TSD.AccountingSoft.WindowsForm.FormSystem
{
    /// <summary>
    /// FrmXtraUpdateDatabase
    /// </summary>
    public partial class FrmXtraUpdateDatabase : XtraForm
    {
        private readonly Crypto Crypto = new Crypto(Crypto.SymmProvEnum.Rijndael);

        #region Events

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmXtraUpdateDatabase"/> class.
        /// </summary>
        public FrmXtraUpdateDatabase()
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
        /// Handles the ButtonClick event of the btnSelectFile control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DevExpress.XtraEditors.Controls.ButtonPressedEventArgs"/> instance containing the event data.</param>
        private void btnSelectFile_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                var openFileDialog = new OpenFileDialog
                    {
                        Title = Properties.Resources.SelectDataFileCaption,
                        InitialDirectory = @"D:\",
                        Filter = @"Sql Script Files(*.sql)|*.sql|All Files(*.*)|*.*",
                        FileName = btnSelectFile.Text,
                        RestoreDirectory = true
                    };
                if (openFileDialog.ShowDialog() != DialogResult.OK)
                    return;
                btnSelectFile.Text = openFileDialog.FileName;
                System.Windows.Forms.Application.DoEvents();
                if (openFileDialog.FileName != null && !string.IsNullOrEmpty(openFileDialog.FileName.Trim()) &&
                    File.Exists(openFileDialog.FileName.Trim()))
                    ReadFromScriptFile(openFileDialog.FileName.Trim());
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(),
                                    ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// LinhMC add code set default database name
        /// Handles the Load event of the FrmXtraUpdateDatabase control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FrmXtraUpdateDatabase_Load(object sender, EventArgs e)
        {
            InitControls();
            LoadServerConnection();
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
                CommonFunction.BackupDatabase(splashScreenManager, "BeforeUpdateData", false);
                Cursor = Cursors.WaitCursor;
                splashScreenManager.ShowWaitForm();
                splashScreenManager.SetWaitFormCaption("Đang thực hiện cập nhật dữ liệu");
                splashScreenManager.SetWaitFormDescription("Vui lòng đợi ..");
                if (ValidData())
                {
                    string scriptContent;
                    var databaseNameForUpdate = (string)grdlookUpEditDatabase.EditValue;
                    var databaseForUpdate = GlobalVariable.Server.Databases[databaseNameForUpdate];
                    using (var streamReader = new StreamReader(btnSelectFile.Text.Trim()))
                    {
                        scriptContent = streamReader.ReadToEnd();
                    }
                    databaseForUpdate.ExecuteNonQuery(scriptContent);
                    splashScreenManager.CloseWaitForm();
                    var resultMessage =  XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResUpdateDatabaseSucces"),
                                        ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (resultMessage == DialogResult.OK)
                        System.Windows.Forms.Application.Restart();
                }
                
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                splashScreenManager.CloseWaitForm();
                XtraMessageBox.Show(ex.ToString(),
                                 ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the QueryPopUp event of the grdlookUpEditDatabase control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
        private void grdlookUpEditDatabase_QueryPopUp(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                LoadDatabase();
                LoadGridLayout(grdlookUpEditDatabase.Properties.DataSource);
                Cursor = Cursors.Default;
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
            if (btnSelectFile.Text == null || string.IsNullOrEmpty(btnSelectFile.Text.Trim()) || !File.Exists(btnSelectFile.Text.Trim()))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResFileScriptNotExit"),
                                    ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSelectFile.Focus();
                return false;
            }
            if (grdlookUpEditDatabase.EditValue == null || string.IsNullOrEmpty(grdlookUpEditDatabase.Text))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResNotChooseDatabase"),
                                    ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                grdlookUpEditDatabase.Focus();
                return false;
            }
            return true;
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
                    Password = Crypto.Decrypting(RegistryHelper.GetValueByRegistryKey("Password"), "@bgt1me")  //RegistryHelper.GetValueByRegistryKey("Password")
                };
            }
            //create server
            GlobalVariable.Server = new Server(GlobalVariable.ServerConnection);
        }

        /// <summary>
        /// Initializes the controls.
        /// </summary>
        private void InitControls()
        {
            memoJournalMemo.EditValue = null;
            btnSelectFile.Text = null;
            btnSelectFile.Focus();
            var databaseName = RegistryHelper.GetValueByRegistryKey("DatabaseName");
            if (!string.IsNullOrEmpty(databaseName))
                grdlookUpEditDatabase.EditValue = databaseName;
        }

        /// <summary>
        /// Loads the database.
        /// </summary>
        private void LoadDatabase()
        {
            var serverName = RegistryHelper.GetValueByRegistryKey("InstanceName");
            var databaseOwner = RegistryHelper.GetValueByRegistryKey("UserName");
            var databaseOwnerPassword = Crypto.Decrypting(RegistryHelper.GetValueByRegistryKey("Password"), "@bgt1me");
            var list = CommonFunction.GetDatabaseNames(serverName, databaseOwner, databaseOwnerPassword);

            if (list.Count <= 0) return;
            grdlookUpEditDatabase.Properties.DataSource = list;
        }

        /// <summary>
        /// Loads the grid layout.
        /// </summary>
        /// <param name="dataSource">The data source.</param>
        private void LoadGridLayout(object dataSource)
        {
            grdlookUpEditDatabaseView.PopulateColumns(dataSource);
            var gridColumnsCollection = new List<XtraColumn>
                        {
                            new XtraColumn {ColumnName = "DatabaseName", ColumnCaption = "Tên cơ sở dữ liệu", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 130},
                            new XtraColumn {ColumnName = "DatabasePath", ColumnCaption = "Đường dẫn cơ sở dữ liệu", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 370},
                            new XtraColumn {ColumnName = "Description",  ColumnVisible = false}
                        };
            foreach (var column in gridColumnsCollection)
            {
                if (column.ColumnVisible)
                {
                    grdlookUpEditDatabaseView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                    grdlookUpEditDatabaseView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                    grdlookUpEditDatabaseView.Columns[column.ColumnName].Width = column.ColumnWith;
                    grdlookUpEditDatabaseView.Columns[column.ColumnName].AppearanceCell.TextOptions.HAlignment = column.Alignment;
                }
                else
                    grdlookUpEditDatabaseView.Columns[column.ColumnName].Visible = false;
            }
            grdlookUpEditDatabase.Properties.DisplayMember = "DatabaseName";
            grdlookUpEditDatabase.Properties.ValueMember = "DatabaseName";
        }

        /// <summary>
        /// Reads from script file.
        /// </summary>
        /// <param name="scriptPath">The script path.</param>
        private void ReadFromScriptFile(string scriptPath)
        {
            using (var streamReader = new StreamReader(scriptPath))
            {
                memoJournalMemo.EditValue = streamReader.ReadToEnd();
            }
        }

        #endregion
    }
}
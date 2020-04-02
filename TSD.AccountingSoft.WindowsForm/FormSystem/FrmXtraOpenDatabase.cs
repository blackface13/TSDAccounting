/***********************************************************************
 * <copyright file="FrmXtraOpenDatabase.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 05 June 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
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
    public partial class FrmXtraOpenDatabase : XtraForm
    {
        #region Events
        private readonly Crypto Crypto = new Crypto(Crypto.SymmProvEnum.Rijndael);
        /// <summary>
        /// Initializes a new instance of the <see cref="FrmXtraOpenDatabase"/> class.
        /// </summary>
        public FrmXtraOpenDatabase()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the FrmXtraOpenDatabase control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FrmXtraOpenDatabase_Load(object sender, EventArgs e)
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
        /// Handles the Click event of the btnOk control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                RegistryHelper.SetValueForRegistry("DatabaseName", (string)gridView.GetRowCellValue(gridView.FocusedRowHandle, "DatabaseName"));
                RegistryHelper.SetValueForRegistry("DatabasePath", (string)gridView.GetRowCellValue(gridView.FocusedRowHandle, "DatabasePath"));
                System.Windows.Forms.Application.Restart();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(),
                    ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                Close();
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
        /// Loads the database.
        /// LinhMC sửa đoạn list database bỏ điều kiện where database.FileGroups[0].Files[0].Name == "aBigTime"
        /// Vì trong quá trình tạo dữ liệu đã đổi Logical Name từ aBigTime thành tên dữ liệu được tạo
        /// //var databaseModels = (from Database database in GlobalVariable.Server.Databases
        ///                      where (database.Name != "master" && database.Name != "model" && database.Name != "msdb" && database.Name != "tempdb" && !database.Name.StartsWith("ReportServer$"))
        ///                      select new DatabaseModel
        ///                     {
        ///                          DatabaseName = database.Name,
        ///                          DatabasePath = database.PrimaryFilePath
        ///                      }).ToList();
        ///grdMain.DataSource = databaseModels;
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
        /// Initializes the controls.
        /// </summary>
        private void InitControls()
        {
            grdMain.ForceInitialize();
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
        /// Handles the Click event of the btnDeleteData control.
        /// LinhMC add code check database in used
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnDeleteData_Click(object sender, EventArgs e)
        {
            try
            {
                var databaseName = (string) gridView.GetRowCellValue(gridView.FocusedRowHandle, "DatabaseName");
                //Check file vật lý còn trên máy không?
                var filePath = (string)gridView.GetRowCellValue(gridView.FocusedRowHandle, "DatabasePath");
                var ds =
                    GlobalVariable.Server.Databases["Master"].ExecuteWithResults(
                        "SET QUOTED_IDENTIFIER OFF EXEC xp_fileexist '" +
                        filePath + "'");
                if (ds != null && Convert.ToInt32(ds.Tables[0].Rows[0][0]) == 0)
                {
                    XtraMessageBox.Show(
                        "Tệp dữ liệu vật lý đã không tồn tại trên phân vùng ổ cứng. Vui lòng kiểm tra lại",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (!string.IsNullOrEmpty(databaseName) && GlobalVariable.Server.GetActiveDBConnectionCount(databaseName) > 0)
                {
                    if (XtraMessageBox.Show(
                        "Cơ sở dữ liệu này đang được sử dụng, bạn có muốn thực hiện thao tác xóa dữ liệu không?",
                        "Thông báo",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        
                        GlobalVariable.Server.KillDatabase(databaseName);
                        LoadDatabase();
                        XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDeleteDatabaseSucess"),
                                            ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                        
                    return;
                }
                var result = XtraMessageBox.Show("Bạn có muốn xóa cơ sở dữ liệu này không ?", ResourceHelper.GetResourceValueByName("ResDeleteCaption"),
                                                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result != DialogResult.OK) return;
                var databaseForDelete =
                    GlobalVariable.Server.Databases[(string)gridView.GetRowCellValue(gridView.FocusedRowHandle, "DatabaseName")];
                databaseForDelete.Drop();
                LoadDatabase();
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDeleteDatabaseSucess"),
                                    ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(),
                                  ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
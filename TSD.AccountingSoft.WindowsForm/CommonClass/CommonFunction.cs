/***********************************************************************
 * <copyright file="CommonFunction.cs" company="Linh Khang">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Author:   LinhMC
 * Email:    linhmc.vn@gmail.com
 * Website:
 * Create Date: Sunday, February 09, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.WindowsForm.CommonControl;
using TSD.AccountingSoft.Session;
using TSD.AccountingSoft.WindowsForm.Resources;
using TSD.Option;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using Ionic.Zip;
using Microsoft.SqlServer.Management.Smo;

namespace TSD.AccountingSoft.WindowsForm.CommonClass
{
    public class CommonFunction
    {

        public static XtraUserControl CommonUserControl = null;
        /// <summary>
        /// Using to add user control to panel
        /// </summary>
        /// <param name="oContainerPanel">Panel of Mainform contain UserControl </param>
        /// <param name="oXtraUserControl">UserControl to add Panel</param>
        /// <param name="oType">Type of UserControl</param>
        public static void AddCotrolToPanel(XtraPanel oContainerPanel, XtraUserControl oXtraUserControl, Type oType)
        {
            try
            {
                if (oContainerPanel.Controls.Count > 0)
                {
                    var no = false;
                    // ReSharper disable once UnusedVariable
                    foreach (var control in oContainerPanel.Controls.Cast<object>().Where(control => control.GetType() == oType))
                    {
                        no = true;
                    }
                    if (no == false)
                    {
                        oContainerPanel.Controls.Clear();
                        oContainerPanel.Controls.Add(oXtraUserControl);
                    }
                }
                else
                {
                    oContainerPanel.Controls.Add(oXtraUserControl);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), System.Windows.Forms.Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Run User Control
        /// </summary>
        /// <param name="userControl"></param>
        /// <param name="oContainerPanel"></param>
        public static void RunUserControl(XtraUserControl userControl, XtraPanel oContainerPanel)
        {
            if (CommonUserControl == null)
            {
                CommonUserControl = userControl;
                AddCotrolToPanel(oContainerPanel, CommonUserControl, typeof(XtraUserControl));
            }
            else
            {
                if (CommonUserControl.GetType() != userControl.GetType())
                {
                    CommonUserControl = userControl;
                    AddCotrolToPanel(oContainerPanel, CommonUserControl, typeof(XtraUserControl));
                }
            }
        }

        public static bool GetLicenseInfo()
        {
            if (File.Exists("License.lic"))
            {
                var oCrypto = new Crypto(Crypto.SymmProvEnum.Rijndael);
                var s = FileHelper.DecryptFile("License.lic");
                var info = new string[10];
                GlobalVariable.IsValidLicense = oCrypto.CheckLicense(s, true, ref info);
                if (GlobalVariable.IsValidLicense)
                {
                    GlobalVariable.CompanyInCharge = info[0].ToString(CultureInfo.InvariantCulture);
                    GlobalVariable.CompanyName = info[1].ToString(CultureInfo.InvariantCulture);
                    GlobalVariable.CompanyAddress = info[2].ToString(CultureInfo.InvariantCulture);
                    GlobalVariable.CompanyOwner = info[3].ToString(CultureInfo.InvariantCulture);
                    GlobalVariable.LicenseNumber = info[4].ToString(CultureInfo.InvariantCulture);
                    return true;
                }
                GlobalVariable.CompanyInCharge = "Phiên bản chưa đăng ký bản quyền";
                GlobalVariable.CompanyName = "Vui lòng liên hệ với tác giả";
                GlobalVariable.CompanyAddress = "Công ty cổ phần BuCA";
                return false;
            }
            GlobalVariable.CompanyInCharge = "Phiên bản chưa đăng ký bản quyền";
            GlobalVariable.CompanyName = "Vui lòng liên hệ với tác giả";
            GlobalVariable.CompanyAddress = "Công ty cổ phần BuCA";
            return false;
        }

        /// <summary>
        /// LinhMC thay đổi cách list dữ liệu
        /// Cách cũ bị lỗi thiếu bộ nhớ
        /// Gets the database names.
        /// </summary>
        /// <param name="serverName">Name of the server.</param>
        /// <param name="ownerName">Name of the owner.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public static List<DatabaseModel> GetDatabaseNames(string serverName, string ownerName, string password)
        {
            var databaseNames = new List<DatabaseModel>();
            string connString;
            if (GlobalVariable.Server != null)//AnhNT disable đoạn này để dịch ngược pass trước khi connect
                connString = GlobalVariable.Server.ConnectionContext.ConnectionString;
            else
                connString = "Data Source=" + serverName + "; User Id = " + ownerName + "; Password= " + password;

            if (string.IsNullOrEmpty(connString)) return databaseNames;
            using (var cn = new SqlConnection(connString))
            {
                cn.Open();

                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT SYSDATABASES.DBID,SYSDATABASES.Name, SYSDATABASES.CrDate, SYSDATABASES.FileName FROM SYSDATABASES " +
                                      "WHERE SYSDATABASES.Name NOT IN('master','tempdb','model','msdb') AND LEFT(SYSDATABASES.Name,13) <> 'ReportServer$'";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while ((reader.Read()))
                        {
                            databaseNames.Add(new DatabaseModel(reader["Name"].ToString(), reader["FileName"].ToString()));
                        }
                    }
                }
                cn.Close();
            }
            return databaseNames;
        }

        /// <summary>
        /// Backups the database.
        /// </summary>
        /// <returns></returns>
        public static bool BackupDatabase(SplashScreenManager splashScreenManager, string backupName, bool openBackupFolder)
        {
            try
            {
                var globalVariable = new GlobalVariable();
                if (splashScreenManager != null)
                {
                    splashScreenManager.ShowWaitForm();
                    splashScreenManager.SetWaitFormCaption("Đang sao lưu dữ liệu");
                    splashScreenManager.SetWaitFormDescription("Vui lòng đợi ..");
                }

                var databaseNameForBackup = RegistryHelper.GetValueByRegistryKey("DatabaseName");
                var databaseForBackup = GlobalVariable.Server.Databases[databaseNameForBackup];
                var backup = new Backup
                {
                    //option for backup
                    Action = BackupActionType.Database,
                    BackupSetDescription = "Sao lưu CSDL, ngày " + DateTime.Now,
                    BackupSetName = databaseNameForBackup + " Backup",
                    Database = databaseForBackup.Name
                };

                //create backupdevice
                var folderBackup = globalVariable.DailyBackupPath;
                var dateTimeString = "NG" + DateTime.Now.Day.ToString(CultureInfo.InvariantCulture) +
                                     "T" + DateTime.Now.Month.ToString(CultureInfo.InvariantCulture) +
                                     "N" + DateTime.Now.Year.ToString(CultureInfo.InvariantCulture) +
                                     "_" + DateTime.Now.Hour.ToString(CultureInfo.InvariantCulture) + "GI" +
                                     DateTime.Now.Minute.ToString(CultureInfo.InvariantCulture) + "P";

                var databaseName = databaseNameForBackup + "_" + (string.IsNullOrEmpty(backupName) ? "" : backupName) + "_" + dateTimeString + ".bak";

                //LINHMC kiem tra neu folder ko ton tai thi tao
                if (string.IsNullOrEmpty(folderBackup))
                {
                    DriveInfo[] allDrives = DriveInfo.GetDrives();
                    if (allDrives.Length > 1)
                    {
                        folderBackup = allDrives[1].Name + @"BACKUP_A_BIGTIME";
                    }
                    else
                    {
                        folderBackup = allDrives[0].Name + @"BACKUP_A_BIGTIME";
                    }
                     
                }
                if (!Directory.Exists(folderBackup))
                {
                    Directory.CreateDirectory(folderBackup);
                }

                var fileBackup = folderBackup + @"\" + databaseName;
                if (File.Exists(fileBackup))
                {
                    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResFileBackupExits"),
                        ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                var backupDevice = new BackupDeviceItem(fileBackup, DeviceType.File);

                backup.Devices.Add(backupDevice);
                backup.Incremental = false;

                backup.SqlBackup(GlobalVariable.Server);

                //Cách nén file này chỉ dùng trong trường hợp hệ quản trị dữ liệu và chương trình cùng nằm trên 1 máy
                using (var zip = new ZipFile())
                {
                    zip.AddFile(fileBackup, "");
                    var zipFileName = fileBackup.Replace(".bak", ".zip");
                    zip.ParallelDeflateThreshold = -1;
                    zip.Save(zipFileName);
                    File.Delete(fileBackup);
                }
                if (splashScreenManager != null)
                {
                    splashScreenManager.CloseWaitForm();
                }

                if (openBackupFolder)
                {
                    Process.Start(folderBackup);
                }
                return true;
            }
            catch (Exception ex)
            {
                if (splashScreenManager != null)
                {
                    splashScreenManager.CloseWaitForm();
                }
                XtraMessageBox.Show(ex.ToString(),
                    ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static string FirstCharToUpper(string input)
        {
            if (String.IsNullOrEmpty(input))
                throw new ArgumentException("ARGH!");
            return input.First().ToString(CultureInfo.InvariantCulture).ToUpper() + input.Substring(1);
        }
    }

    /// <summary>
    /// Accounting BalanceSide
    /// </summary>
    public class BalanceSide
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public BalanceSide(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}

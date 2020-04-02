/***********************************************************************
 * <copyright file="FrmXtraRegister.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Monday, June 16, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/
using System;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using TSD.AccountingSoft.Session;
using TSD.AccountingSoft.WindowsForm.Resources;
using DevExpress.XtraEditors;
using TSD.Option;

namespace TSD.AccountingSoft.WindowsForm.FormSystem
{
    /// <summary>
    /// Register License info
    /// </summary>
    public partial class FrmXtraRegister : XtraForm
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance is valid license.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is valid license; otherwise, <c>false</c>.
        /// </value>
        private bool IsValidLicense { get; set; }
        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        /// <value>
        /// The name of the file.
        /// </value>
        private string FileName { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmXtraRegister"/> class.
        /// </summary>
        public FrmXtraRegister()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the btnClose control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnClose_Click(object sender, EventArgs e)
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
                if (GlobalVariable.IsValidLicense && IsValidLicense)
                {
                    if (FileName == System.Windows.Forms.Application.StartupPath + @"\License.lic")
                    {
                        XtraMessageBox.Show("Thông tin bản quyền này đang được sử dụng trong chương trình!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    if (
                        XtraMessageBox.Show("Thông tin bản quyền đã tồn tại. Bạn có muốn ghi đè dữ liệu không?",
                            "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
                    FileHelper.CopyFileStream(FileName, System.Windows.Forms.Application.StartupPath + @"\License.lic");

                    XtraMessageBox.Show("Cập nhật thông tin bản quyền thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    GlobalVariable.CompanyName = lblCompanyName.Text;
                    GlobalVariable.CompanyAddress = lblCompanyAddress.Text;
                    GlobalVariable.CompanyInCharge = lblCompanyInCharge.Text;
                    GlobalVariable.CompanyOwner = lblCompanyOwner.Text;
                }
                else
                {
                    if (!IsValidLicense) return;
                    FileHelper.CopyFileStream(FileName, System.Windows.Forms.Application.StartupPath + @"\License.lic");
                    XtraMessageBox.Show("Cập nhật thông tin bản quyền thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        /// <summary>
        /// Handles the ButtonClick event of the btnBrowseFile control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DevExpress.XtraEditors.Controls.ButtonPressedEventArgs"/> instance containing the event data.</param>
        private void btnBrowseFile_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            using (var dlg= new OpenFileDialog())
            {
                dlg.Title = ResourceHelper.GetResourceValueByName("ResLicenseTitle");
                dlg.Filter = ResourceHelper.GetResourceValueByName("ResLicenseExtendFile");

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    btnBrowseFile.Text = dlg.FileName;
                    if (File.Exists(dlg.FileName))
                    {
                        FileName = dlg.FileName;
                        var s = FileHelper.DecryptFile(dlg.FileName);
                        if (string.IsNullOrEmpty(s))
                        {
                            btnBrowseFile.Focus();
                            return;
                        }
                        var info = new string[10];
                        var oCrypto = new Crypto(Crypto.SymmProvEnum.Rijndael);
                        IsValidLicense = oCrypto.CheckLicense(s, true, ref info);
                        if (IsValidLicense)
                        {
                            lblCompanyInCharge.Text = info[0].ToString(CultureInfo.InvariantCulture);
                            lblCompanyName.Text = info[1].ToString(CultureInfo.InvariantCulture);
                            lblCompanyAddress.Text = info[2].ToString(CultureInfo.InvariantCulture);
                            lblCompanyOwner.Text = info[3].ToString(CultureInfo.InvariantCulture);
                            lblLicenseNumber.Text = info[4].ToString(CultureInfo.InvariantCulture);
                            GlobalVariable.IsValidLicense=true;
                        }
                        else
                        {
                            XtraMessageBox.Show("Thông tin bản quyền không đúng, vui lòng kiểm tra lại!", "Cảnh báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }

            }
        }

        /// <summary>
        /// Handles the Load event of the FrmXtraRegister control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FrmXtraRegister_Load(object sender, EventArgs e)
        {
            lblCompanyName.Text = !GlobalVariable.IsValidLicense ? "Phiên bản chưa đăng ký bản quyền" : GlobalVariable.CompanyName;
            lblCompanyAddress.Text = !GlobalVariable.IsValidLicense ? "Phiên bản chưa đăng ký bản quyền" : GlobalVariable.CompanyAddress;
            lblCompanyInCharge.Text = !GlobalVariable.IsValidLicense ? "Phiên bản chưa đăng ký bản quyền" : GlobalVariable.CompanyInCharge;
            lblCompanyOwner.Text = !GlobalVariable.IsValidLicense ? "Phiên bản chưa đăng ký bản quyền" : GlobalVariable.CompanyOwner;
            lblLicenseNumber.Text = !GlobalVariable.IsValidLicense ? "Phiên bản chưa đăng ký bản quyền" : GlobalVariable.LicenseNumber;
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            if (!File.Exists("BIGTIME.CHM"))
            {
                XtraMessageBox.Show("Không tìm thấy tệp trợ giúp!", "Lỗi thiếu file", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Help.ShowHelp(this, System.Windows.Forms.Application.StartupPath + @"\BIGTIME.CHM", HelpNavigator.TopicId, Convert.ToString(1050));
        }
    }
}
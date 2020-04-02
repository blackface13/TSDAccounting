/***********************************************************************
 * <copyright file="FrmXtraChangePassword.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 28 July 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Windows.Forms;
using TSD.AccountingSoft.Presenter.System.UserProfile;
using TSD.AccountingSoft.WindowsForm.CommonClass;
using TSD.AccountingSoft.WindowsForm.Resources;
using DevExpress.XtraEditors;


namespace TSD.AccountingSoft.WindowsForm.FormSystem
{
    /// <summary>
    /// FrmXtraChangePassword
    /// </summary>
    public partial class FrmXtraChangePassword : XtraForm
    {
        /// <summary>
        /// Gets the name of the user profile.
        /// </summary>
        /// <value>
        /// The name of the user profile.
        /// </value>
        public string UserProfileName
        {
            get { return RegistryHelper.GetValueByRegistryKey("UserLogin"); }
        }

        /// <summary>
        /// Gets the old password.
        /// </summary>
        /// <value>
        /// The old password.
        /// </value>
        public string OldPassword
        {
            get { return string.IsNullOrEmpty(txtOldPassword.Text) ? null : txtOldPassword.Text; }
        }

        /// <summary>
        /// Gets the new password.
        /// </summary>
        /// <value>
        /// The new password.
        /// </value>
        public string NewPassword
        {
            get { return string.IsNullOrEmpty(txtPassword.Text) ? null : txtPassword.Text; }
        }

        private readonly UserProfilePresenter _userProfilePresenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmXtraChangePassword"/> class.
        /// </summary>
        public FrmXtraChangePassword()
        {
            InitializeComponent();
            _userProfilePresenter = new UserProfilePresenter(null);
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
                if (!ValidData()) return;
                var rowsAffected = _userProfilePresenter.ChangePassword(UserProfileName, OldPassword, NewPassword);
                if (rowsAffected > 0)
                {
                    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResChangePasswordSucces"),
                                        ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResChangePasswordNotSucces"),
                                        ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message,
                    ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns></returns>
        private bool ValidData()
        {
            if (!txtPassword.Text.Equals(txtRePassword.Text))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResPasswordNotSameRePassword"),
                      ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return false;
            }
            return true;
        }
    }
}
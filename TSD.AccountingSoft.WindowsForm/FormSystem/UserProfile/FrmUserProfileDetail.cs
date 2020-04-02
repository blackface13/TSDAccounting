/***********************************************************************
 * <copyright file="FrmUserProfileDetail.cs" company="BUCA JSC">
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

using System.Windows.Forms;
using TSD.AccountingSoft.Presenter.System.UserProfile;
using TSD.AccountingSoft.View.System;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.Resources;
using DevExpress.XtraEditors;


namespace TSD.AccountingSoft.WindowsForm.FormSystem.UserProfile
{
    /// <summary>
    /// 
    /// </summary>
    public partial class FrmUserProfileDetail : FrmXtraBaseCategoryDetail, IUserProfileView
    {
        #region Variables

        private readonly UserProfilePresenter _userProfilePresenter;

        #endregion

        #region UserProfile Member

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
        public string FullName
        {
            get { return txtFullName.Text; }
            set { txtFullName.Text = value; }
        }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password
        {
            get { return txtPassword.Text; }
            set { txtPassword.Text = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [is active].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is active]; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive
        {
            get { return chkIsActive.Checked; }
            set { chkIsActive.Checked = value; }
        }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email
        {
            get { return txtEmail.Text; }
            set { txtEmail.Text = value; }
        }

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
        public string Description
        {
            get { return memoDescription.Text; }
            set { memoDescription.Text = value; }
        }

        #endregion

        #region Function Overrides

        /// <summary>
        /// Initializes the data.
        /// </summary>
        protected override void InitData()
        {
            if (KeyValue != null)
            {
                _userProfilePresenter.Display(KeyValue);
                txtRePassword.Text = Password;
            }
        }

        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns></returns>
        protected override bool ValidData()
        {
            if (string.IsNullOrEmpty(UserProfileName))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResUserProfileName"),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserProfileName.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// Saves the data.
        /// </summary>
        /// <returns></returns>
        protected override int SaveData()
        {
            return _userProfilePresenter.Save();
        }

        #endregion

        #region Events

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmUserProfileDetail"/> class.
        /// </summary>
        public FrmUserProfileDetail()
        {
            InitializeComponent();
            _userProfilePresenter = new UserProfilePresenter(this);
        }

        #endregion
    }
}
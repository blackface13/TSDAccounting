/***********************************************************************
 * <copyright file="UserControlUserProfileList.cs" company="BUCA JSC">
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

using System.Collections.Generic;
using System.Windows.Forms;
using TSD.AccountingSoft.Model.BusinessObjects.System;
using TSD.AccountingSoft.Presenter.System.UserProfile;
using TSD.AccountingSoft.View.System;
using TSD.AccountingSoft.WindowsForm.BaseUserControls;
using TSD.AccountingSoft.WindowsForm.CommonClass;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.Resources;
using DevExpress.XtraEditors;


namespace TSD.AccountingSoft.WindowsForm.FormSystem.UserProfile
{
    public partial class UserControlUserProfileList : BaseListUserControl, IUserProfilesView
    {
        private readonly UserProfilesPresenter _userProfilesPresenter;

        #region IUserProfilesView Members

        /// <summary>
        /// Sets the userProfiles.
        /// </summary>
        /// <value>
        /// The userProfiles.
        /// </value>
        public IList<UserProfileModel> UserProfiles
        {
            set
            {
                ListBindingSource.DataSource = value;
                gridView.PopulateColumns(value);
                ColumnsCollection.Add(new XtraColumn { ColumnName = "UserProfileId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Password", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Email", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "UserProfileName", ColumnCaption = "Tên đăng nhập", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 200 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "FullName", ColumnCaption = "Tên người dùng", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 300 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CreateDate", ColumnCaption = "Ngày tạo", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 100, Alignment = DevExpress.Utils.HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnCaption = "Mô tả", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 300 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnCaption = "Được sử dụng", ColumnPosition = 5, ColumnVisible = true, ColumnWith = 100 });
            }
        }

        /// <summary>
        /// Loads the data into grid.
        /// </summary>
        protected override void LoadDataIntoGrid()
        {
            _userProfilesPresenter.Display();
        }

        /// <summary>
        /// Deletes the grid.
        /// </summary>
        protected override void DeleteGrid()
        {
            var rowHandle = gridView.FocusedRowHandle;
            var userName = gridView.GetRowCellValue(rowHandle, "UserProfileName") != null ? gridView.GetRowCellValue(rowHandle, "UserProfileName").ToString() : null;
            if (userName != null && userName.ToUpper() == RegistryHelper.GetValueByRegistryKey("UserLogin").ToUpper())
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResUserProfileSameUserName"),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            new UserProfilePresenter(null).Delete(int.Parse(PrimaryKeyValue));
        }

        #endregion

        #region Events

        /// <summary>
        /// Initializes a new instance of the <see cref="UserControlUserProfileList"/> class.
        /// </summary>
        public UserControlUserProfileList()
        {
            InitializeComponent();
            _userProfilesPresenter = new UserProfilesPresenter(this);
        }

        #endregion
    }
}

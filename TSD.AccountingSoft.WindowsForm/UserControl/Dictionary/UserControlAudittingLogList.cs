/***********************************************************************
 * <copyright file="UserControlAudittingLogList.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 12 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Presenter.Dictionary.AudittingLog;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.WindowsForm.BaseUserControls;
using System.Collections.Generic;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using DevExpress.Data;
using DevExpress.Utils;


namespace TSD.AccountingSoft.WindowsForm.UserControl.Dictionary
{
    /// <summary>
    /// class UserControlAudittingLogList 
    /// </summary>
    public partial class UserControlAudittingLogList : BaseListUserControl, IAudittingLogsView
    {
        private readonly AudittingLogsPresenter _audittingLogsPresenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserControlAudittingLogList"/> class.
        /// </summary>
        public UserControlAudittingLogList()
        {
            InitializeComponent();
            _audittingLogsPresenter = new AudittingLogsPresenter(this);
        }

        #region IAudittingLogsView Members

        /// <summary>
        /// Sets the audittingLogs.
        /// </summary>
        /// <value>
        /// The audittingLogs.
        /// </value>
        public IList<AudittingLogModel> AudittingLogs
        {
            set
            {
                grdList.DataSource = value;

                ColumnsCollection.Add(new XtraColumn { ColumnName = "EventId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "LoginName", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ComponentName", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "EventAction", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ComputerName", ColumnCaption = "Tên máy tính", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 150 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "EventTime", ColumnCaption = "Thời gian thực hiện", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 70, Alignment = HorzAlignment.Center, ColumnType = UnboundColumnType.DateTime});
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Reference", ColumnCaption = "Nội dung", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 400 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Amount", ColumnCaption = "Số tiền", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 70 });
            }
        }

        /// <summary>
        /// Loads the data into grid.
        /// </summary>
        protected override void LoadDataIntoGrid()
        {
            _audittingLogsPresenter.Display();
        }

        /// <summary>
        /// Deletes the grid.
        /// </summary>
        protected override void DeleteGrid()
        {
            new AudittingLogPresenter(null).Delete(int.Parse(PrimaryKeyValue));
        }

        #endregion

        /// <summary>
        /// Gets the form detail.
        /// </summary>
        /// <returns></returns>
        protected override FrmXtraBaseCategoryDetail GetFormDetail()
        {
            return null;
        }
    }
}

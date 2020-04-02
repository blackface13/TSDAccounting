using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TSD.AccountingSoft.WindowsForm.BaseUserControls;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Presenter.Dictionary.Activity;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.FormDictionary;
using TSD.AccountingSoft.WindowsForm.Resources;

namespace TSD.AccountingSoft.WindowsForm.UserControl.Dictionary
{
    public partial class UserControlActivityList : BaseListUserControl, IActivitysView
    {
        private readonly ActivitysPresenter _activitysPresenter;

        public UserControlActivityList()
        {
            InitializeComponent();
            _activitysPresenter = new ActivitysPresenter(this);
        }

        public IList<ActivityModel> Activitys
        {
            set
            {
                ListBindingSource.DataSource = value;
                gridView.PopulateColumns(value);
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ActivityCode", ColumnCaption = "Mã hoạt động sự nghiệp", ColumnVisible = true, ColumnWith = 30 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ActivityName", ColumnCaption = "Tên hoạt động sự nghiệp", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 150 });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "ActivityId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsParent", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ParentID", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });

                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnCaption = "Được sử dụng", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 20 });
            }
        }

        #region Form event

        protected override void LoadDataIntoGrid()
        {
            _activitysPresenter.Display();
        }

        protected override void DeleteGrid()
        {
            new ActivityPresenter(null).Delete(Convert.ToInt32(PrimaryKeyValue));
        }

        protected override FrmXtraBaseCategoryDetail GetFormDetail()
        {
            return new FrmXtraActivityDetail() { FormCaption = ResourceHelper.GetResourceValueByName("ResActivityCaption") };
        }

        #endregion
    }
}

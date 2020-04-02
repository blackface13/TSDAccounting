/***********************************************************************
 * <copyright file="UserControlBuildingList.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 10 June 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Presenter.Dictionary.Building;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.WindowsForm.BaseUserControls;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.FormDictionary;
using DevExpress.Utils;


namespace TSD.AccountingSoft.WindowsForm.UserControl.Dictionary
{
    /// <summary>
    /// UserControlBuildingList
    /// </summary>
    public partial class UserControlBuildingList : BaseListUserControl, IBuildingsView
    {
        private readonly BuildingsPresenter _buildingsPresenter;

        #region Building Members

        /// <summary>
        /// Sets the employee leasings.
        /// </summary>
        /// <value>
        /// The employee leasings.
        /// </value>
        public IList<BuildingModel> Buildings
        {
            set
            {
                ListBindingSource.DataSource = value;
                gridView.PopulateColumns(value);
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BuildingId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "OrderNumber", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Area", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "UnitPrice", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "BuildingCode",
                    ColumnCaption = "Mã",
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 150
                });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BuildingName", ColumnCaption = "Tên", ColumnPosition = 2, ColumnVisible = true, 
                    ColumnWith = 150 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "JobCandidate", ColumnCaption = "Chức vụ", ColumnPosition = 3, ColumnVisible = true, 
                    ColumnWith = 100 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Address", ColumnCaption = "Địa chỉ", ColumnPosition = 4, ColumnVisible = true, 
                    ColumnWith = 100 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "StartDate", ColumnCaption = "Ngày thuê", ColumnPosition = 5, ColumnVisible = true, 
                    ColumnWith = 100, Alignment = HorzAlignment.Center});
                ColumnsCollection.Add(new XtraColumn { ColumnName = "EndDate", ColumnCaption = "Ngày hết hợp đồng", ColumnPosition = 6, ColumnVisible = true, 
                    ColumnWith = 100, Alignment = HorzAlignment.Center});
            }
        }

        #endregion

        #region Function Overrides

        /// <summary>
        /// Loads the data into grid.
        /// </summary>
        protected override void LoadDataIntoGrid()
        {
            _buildingsPresenter.Display();
            _buildingsPresenter.SaveCompanyProfile();
        }

        /// <summary>
        /// Deletes the grid.
        /// </summary>
        protected override void DeleteGrid()
        {
            new BuildingPresenter(null).Delete(int.Parse(PrimaryKeyValue));
        }

        /// <summary>
        /// Gets the form detail.
        /// </summary>
        /// <returns></returns>
        protected override FrmXtraBaseCategoryDetail GetFormDetail()
        {
            return new FrmXtraBuildingDetail();
        }
        #endregion

        #region Events

        /// <summary>
        /// Initializes a new instance of the <see cref="UserControlBuildingList" /> class.
        /// </summary>
        public UserControlBuildingList()
        {
            InitializeComponent();
            _buildingsPresenter = new BuildingsPresenter(this);
        }

        #endregion
    }
}

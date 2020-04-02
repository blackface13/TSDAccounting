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
using TSD.AccountingSoft.Presenter.Dictionary.Mutual;
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
    public partial class UserControlMutualList : BaseListUserControl, IMutualsView
    {
        private readonly MutualsPresenter _mutualsPresenter;

        #region Mutual Members

        /// <summary>
        /// Sets the employee leasings.
        /// </summary>
        /// <value>
        /// The employee leasings.
        /// </value>
        public IList<MutualModel> Mutuals
        {
            set
            {
                ListBindingSource.DataSource = value;
                gridView.PopulateColumns(value);
                ColumnsCollection.Add(new XtraColumn { ColumnName = "MutualId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Area", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "TotalFloor", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "MutualCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "State", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "MutualCode",
                    ColumnCaption = "Mã nhà hỗ tương",
                    ColumnPosition = 1,
                    ColumnVisible = true,
                    ColumnWith = 100,
                    Alignment = HorzAlignment.Center
                });

                ColumnsCollection.Add(new XtraColumn 
                { ColumnName = "MutualName",
                    ColumnCaption = "Tên",
                    ColumnPosition = 2,
                    ColumnVisible = true, 
                    ColumnWith = 200 
                });
                ColumnsCollection.Add(new XtraColumn 
                { ColumnName = "JobCandidate",
                    ColumnCaption = "Chức vụ",
                    ColumnPosition = 3,
                    ColumnVisible = true, 
                    ColumnWith = 100 });
                ColumnsCollection.Add(new XtraColumn
                {
                    ColumnName = "UseDate",
                    ColumnCaption = "Ngày nhân bàn giao",
                    ColumnPosition = 4,
                    ColumnVisible = true,
                    ColumnWith = 100,
                    Alignment = HorzAlignment.Center
                });
                 ColumnsCollection.Add(new XtraColumn 
                 { 
                     ColumnName = "Address", 
                     ColumnCaption = "Địa chỉ",
                     ColumnPosition = 4, 
                     ColumnVisible = true, 
                    ColumnWith = 200 });

                 ColumnsCollection.Add(new XtraColumn
                 {
                     ColumnName = "IsActive",
                     ColumnCaption = "Được sử dụng",
                     ColumnPosition = 5,
                     ColumnVisible = true,
                     ColumnWith = 100
                 });

            }
        }

        #endregion

        #region Function Overrides

        /// <summary>
        /// Loads the data into grid.
        /// </summary>
        protected override void LoadDataIntoGrid()
        {
            _mutualsPresenter.Display();
           _mutualsPresenter.SaveCompanyProfile();
        }


        /// <summary>
        /// Deletes the grid.
        /// </summary>
        protected override void DeleteGrid()
        {
            new MutualPresenter(null).Delete(int.Parse(PrimaryKeyValue));
        }

        /// <summary>
        /// Gets the form detail.
        /// </summary>
        /// <returns></returns>
        protected override FrmXtraBaseCategoryDetail GetFormDetail()
        {
            return new FrmXtraMutualDetail();
        }
        #endregion

        #region Events

        /// <summary>
        /// Initializes a new instance of the <see cref="UserControlMutualList" /> class.
        /// </summary>
        public UserControlMutualList()
        {
            InitializeComponent();
            _mutualsPresenter = new MutualsPresenter(this);
        }

        #endregion
    }
}

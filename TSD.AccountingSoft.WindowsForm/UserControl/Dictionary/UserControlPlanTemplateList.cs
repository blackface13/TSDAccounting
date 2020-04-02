/***********************************************************************
 * <copyright file="SqlServerFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Thursday, February 28, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  07/03/2014       Author    Tudt           Description: Coding standard
 * 
 * ************************************************************************/

using System.Collections.Generic;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Presenter.Dictionary.PlanTemplateList;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.WindowsForm.BaseUserControls;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.FormDictionary;
using TSD.Enum;
using DevExpress.Utils;
using DevExpress.XtraEditors.Repository;


namespace TSD.AccountingSoft.WindowsForm.UserControl.Dictionary
{
    /// <summary>
    /// Class UserControlPlanTemplateList.
    /// </summary>
    public partial class UserControlPlanTemplateList : BaseListUserControl, IPlanTemplateListsView
    {
        /// <summary>
        /// The _plan template lists presenter
        /// </summary>
        private readonly PlanTemplateListsPresenter _planTemplateListsPresenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserControlPlanTemplateList"/> class.
        /// </summary>
        public UserControlPlanTemplateList()
        {
            InitializeComponent();
            _planTemplateListsPresenter = new PlanTemplateListsPresenter(this);
        }

        /// <summary>
        /// Sets the BudgetItems.
        /// </summary>
        /// <value>The BudgetItems.</value>
        public IList<PlanTemplateListModel> PlanTemplateLists
        {
            set
            {
                var planType = typeof(PlanType).ToList();
                var repositoryPlanType = new RepositoryItemLookUpEdit
                {
                    DataSource = planType,
                    DisplayMember = "Value",
                    ValueMember = "Key",
                    ShowHeader = false
                };
                repositoryPlanType.PopulateColumns();
                repositoryPlanType.Columns["Key"].Visible = false;
                ListBindingSource.DataSource = value;
                gridView.PopulateColumns(value);
                ColumnsCollection.Add(new XtraColumn { ColumnName = "PlanTemplateListId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "PlanTemplateListCode", ColumnCaption = "Mã mẫu dự toán", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 100 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "PlanTemplateListName", ColumnCaption = "Tên mẫu dự toán", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 350 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "PlanYear", ColumnCaption = "Năm dự toán", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 150, Alignment = HorzAlignment.Center });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "PlanType", ColumnCaption = "Loại dự toán", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 150, RepositoryControl = repositoryPlanType });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "ParentId", ColumnCaption = "Mẫu cha", ColumnPosition = 5, ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "PlanTemplateItems", ColumnCaption = "Chi tiết", ColumnPosition = 6, ColumnVisible = false });
            }
        }

        /// <summary>
        /// Loads the data into grid.
        /// </summary>
        protected override void LoadDataIntoGrid()
        {
            _planTemplateListsPresenter.Display();
        }

        /// <summary>
        /// Deletes the grid.
        /// </summary>
        protected override void DeleteGrid()
        {
            new PlanTemplateListPresenter(null).Delete(int.Parse(PrimaryKeyValue));
        }

        /// <summary>
        /// Gets the form detail.
        /// </summary>
        /// <returns></returns>
        protected override FrmXtraBaseCategoryDetail GetFormDetail()
        {
            return new FrmXtraPlanTemplateItem();
        }
    }
}

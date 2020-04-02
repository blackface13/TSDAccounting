/***********************************************************************
 * <copyright file="UserControlPayItemList.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 13 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using TSD.AccountingSoft.Presenter.Dictionary.PayItem;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.WindowsForm.BaseUserControls;
using TSD.AccountingSoft.WindowsForm.CommonClass;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.FormDictionary;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Repository;

namespace TSD.AccountingSoft.WindowsForm.UserControl.Dictionary
{
    /// <summary>
    /// Class UserControlPayItemList.
    /// </summary>
    public partial class UserControlPayItemList : BaseListUserControl, IPayItemsView
    {
        /// <summary>
        /// The _pay item presenter
        /// </summary>
        private readonly PayItemsPresenter _payItemPresenter;

        private RepositoryItemGridLookUpEdit RePaymentType = null;
        private RepositoryItemGridLookUpEdit ReCalculateRatio = null;

        public UserControlPayItemList()
        {
            InitializeComponent();
            _payItemPresenter = new PayItemsPresenter(this);
            RePaymentType = new RepositoryItemGridLookUpEdit();
            ReCalculateRatio = new RepositoryItemGridLookUpEdit();
            this.PaymentTypes = this.PaymentTypes;
            this.GetCalculateRatio = this.GetCalculateRatio;
            // hide button
            VisibleButtonAddNew = false;
            VisibleButtonDelete = false;
        }

        #region IPayItemsView Members

        public IList<Model.BusinessObjects.Dictionary.PayItemModel> PayItems
        {
            set
            {
                ListBindingSource.DataSource = value;
                gridView.PopulateColumns(value);
                ColumnsCollection.Add(new XtraColumn { ColumnName = "PayItemId", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "PayItemCode", ColumnCaption = "Mã khoản lương", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 70 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "PayItemName", ColumnCaption = "Tên khoản lương", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 350 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Type", ColumnCaption = "Loại khoản lương", ColumnPosition = 3, ColumnVisible = false, ColumnWith = 100, RepositoryControl = RePaymentType });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsCalculateRatio", ColumnCaption = "Tính theo hệ số", ColumnPosition = 4, ColumnVisible = false, ColumnWith = 100, RepositoryControl = ReCalculateRatio });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "Description", ColumnCaption = "Công thức", ColumnPosition = 5, ColumnVisible = true, ColumnWith = 150 });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsSocialInsurance", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsCareInsurance", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsTradeUnionFee", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "DebitAccountCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "CreditAccountCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetChapterCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsDefault", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetSourceCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetCategoryCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetGroupCode", ColumnVisible = false });
                ColumnsCollection.Add(new XtraColumn { ColumnName = "BudgetItemCode", ColumnVisible = false });
            }
            get { throw new System.NotImplementedException(); }
        }

        /// <summary>
        /// Loads the data into grid.
        /// </summary>
        protected override void LoadDataIntoGrid()
        {
            _payItemPresenter.Display();
        }

        /// <summary>
        /// Deletes the grid.
        /// </summary>
        protected override void DeleteGrid()
        {
            new PayItemPresenter(null).Delete(int.Parse(PrimaryKeyValue));
        }

        /// <summary>
        /// Gets the form detail.
        /// </summary>
        /// <returns></returns>
        protected override FrmXtraBaseCategoryDetail GetFormDetail()
        {
            return new FrmXtraPayItemDetail();
        }

        public List<ObjectGeneral> GetCalculateRatio
        {
            get { return new ObjectGeneral().GetCalculateRatios(); }
            set { GridLookUpItem.ObjectGeneral(value, ReCalculateRatio, "ObjectGeneralName", "ObjectGeneralId"); }
        }

        public List<ObjectGeneral> PaymentTypes
        {
            get { return new ObjectGeneral().GetPayItemTypes(); }
            set { GridLookUpItem.ObjectGeneral(value, RePaymentType, "ObjectGeneralName", "ObjectGeneralId"); }
        }

        #endregion
    }
}

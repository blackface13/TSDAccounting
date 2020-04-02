/***********************************************************************
 * <copyright file="GridLookUpItem.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Hoàng Bích Sơn
 * Email:    sonhb@buca.vn
 * Website:
 * Create Date: 27 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/


using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.Session;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace TSD.AccountingSoft.WindowsForm.CommonClass
{
    internal sealed class GridLookUpItem
    {
        public object DataValue { get; set; }
        public object DataMember { get; set; }

        public GridLookUpItem()
        {

        }
        public GridLookUpItem(string dataValue, string dataMember)
        {
            DataValue = dataValue;
            DataMember = dataMember;
        }

        #region GridLookUpEdit

        public static void Activity(object value, GridLookUpEdit gridLookUpEdit, GridView gridView, string displayMember, string valueMember)
        {
            var listColumn = new List<XtraColumn>()
            {
                new XtraColumn {ColumnName = "ActivityCode",ColumnCaption = "Mã HĐNS",ColumnPosition = 1,ColumnVisible = true,ColumnWith = 25},
                new XtraColumn {ColumnName = "ActivityName",ColumnCaption = "Tên HĐNS",ColumnVisible = true,ColumnPosition = 2,ColumnWith = 75}
            };
            HideVisibleColumn(value, listColumn, gridLookUpEdit, gridView, displayMember, valueMember);
        }

        public static void Account(object value, GridLookUpEdit gridLookUpEdit, GridView gridView, string displayMember, string valueMember)
        {
            var listColumn = new List<XtraColumn>()
            {
                new XtraColumn {ColumnName = "AccountCode",ColumnCaption = "Mã tài khoản", ColumnPosition = 1,ColumnVisible = true,ColumnWith = 25},
                new XtraColumn {ColumnName = "AccountName",ColumnCaption = "Tên tài khoản", ColumnVisible = true,ColumnPosition = 2,ColumnWith = 75}
            };
            HideVisibleColumn(value, listColumn, gridLookUpEdit, gridView, displayMember, valueMember);
        }

        public static void AccountingObject(object value, GridLookUpEdit gridLookUpEdit, GridView gridView, string displayMember, string valueMember)
        {
            var listColumn = new List<XtraColumn>()
            {
                new XtraColumn {ColumnName = "AccountingObjectCode",ColumnCaption = "Mã đối tượng", ColumnPosition = 1,ColumnVisible = true,ColumnWith = 125},
                new XtraColumn {ColumnName = "FullName",ColumnCaption = "Tên đối tượng ", ColumnVisible = true,ColumnPosition = 2,ColumnWith = 375}
            };
            HideVisibleColumn(value, listColumn, gridLookUpEdit, gridView, displayMember, valueMember);
        }

        public static void AccountCategory(object value, GridLookUpEdit gridLookUpEdit, GridView gridView, string displayMember, string valueMember)
        {
            var listColumn = new List<XtraColumn>()
            {
                new XtraColumn {ColumnName = "AccountCategoryCode",ColumnCaption = "Mã loại TK", ColumnPosition = 1,ColumnVisible = true,ColumnWith = 125},
                new XtraColumn {ColumnName = "AccountCategoryName",ColumnCaption = "Tên loại TK", ColumnVisible = true,ColumnPosition = 2,ColumnWith = 375}
            };
            HideVisibleColumn(value, listColumn, gridLookUpEdit, gridView, displayMember, valueMember);
        }

        public static void AccountingObjectCategory(object value, GridLookUpEdit gridLookUpEdit, GridView gridView, string displayMember, string valueMember)
        {
            var listColumn = new List<XtraColumn>()
            {
                new XtraColumn {ColumnName = "AccountingObjectCategoryCode", ColumnCaption = "Mã loại ĐT",ColumnPosition = 1,ColumnVisible = true,ColumnWith = 125},
                new XtraColumn {ColumnName = "AccountingObjectCategoryName", ColumnCaption = "Tên loại ĐT",ColumnVisible = true,ColumnPosition = 2,ColumnWith = 375}
            };
            HideVisibleColumn(value, listColumn, gridLookUpEdit, gridView, displayMember, valueMember, new GridLookUpItemOption() { IsAutoPopupSize = true, ShowAutoFilterRow = false });
        }

        public static void Bank(object value, GridLookUpEdit gridLookUpEdit, GridView gridView, string displayMember, string valueMember)
        {
            var listColumn = new List<XtraColumn>()
            {
                new XtraColumn { ColumnName = "BankAccount", ColumnCaption = "Số tài khoản", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 125 },
                new XtraColumn { ColumnName = "BankName", ColumnCaption = "Tên ngân hàng", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 375 }
            };
            HideVisibleColumn(value, listColumn, gridLookUpEdit, gridView, displayMember, valueMember);
        }

        public static void BudgetCategory(object value, GridLookUpEdit gridLookUpEdit, GridView gridView, string displayMember, string valueMember)
        {
            var listColumn = new List<XtraColumn>()
            {
                new XtraColumn { ColumnName = "BudgetCategoryCode", ColumnCaption = "Mã", ColumnPosition = 1, ColumnVisible = true,ColumnWith =125, Alignment = HorzAlignment.Center },
                new XtraColumn { ColumnName = "BudgetCategoryName", ColumnCaption = "Tên loại khoản", ColumnPosition = 2, ColumnWith = 350, ColumnVisible = true, Alignment = HorzAlignment.Center },
            };
            HideVisibleColumn(value, listColumn, gridLookUpEdit, gridView, displayMember, valueMember, new GridLookUpItemOption() { CustomSize = new Size(820, 300) });
        }

        public static void BudgetItem(object value, GridLookUpEdit gridLookUpEdit, GridView gridView, string displayMember, string valueMember)
        {
            var listColumn = new List<XtraColumn>()
            {
                new XtraColumn { ColumnName = "BudgetItemCode", ColumnCaption = "Mã MLNS", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 125},
                new XtraColumn { ColumnName = "BudgetItemName", ColumnCaption = "Tên MLNS", ColumnPosition = 2, ColumnVisible = true , ColumnWith = 375},
            };
            HideVisibleColumn(value, listColumn, gridLookUpEdit, gridView, displayMember, valueMember);
        }

        public static void BudgetSource(object value, GridLookUpEdit gridLookUpEdit, GridView gridView, string displayMember, string valueMember)
        {
            var listColumn = new List<XtraColumn>()
            {
                new XtraColumn { ColumnName = "BudgetSourceCode", ColumnCaption = "Mã nguồn vốn", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 125},
                new XtraColumn { ColumnName = "BudgetSourceName", ColumnCaption = "Tên nguồn vốn", ColumnPosition = 2, ColumnVisible = true , ColumnWith = 375},
            };
            HideVisibleColumn(value, listColumn, gridLookUpEdit, gridView, displayMember, valueMember);
        }

        public static void BudgetSourceCategory(object value, GridLookUpEdit gridLookUpEdit, GridView gridView, string displayMember, string valueMember)
        {
            var listColumn = new List<XtraColumn>()
            {
                new XtraColumn { ColumnName = "BudgetSourceCategoryCode", ColumnCaption = "Mã loại nguồn vốn", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 125},
                new XtraColumn { ColumnName = "BudgetSourceCategoryName", ColumnCaption = "Tên loại nguồn vốn", ColumnPosition = 2, ColumnVisible = true , ColumnWith = 375},
            };
            HideVisibleColumn(value, listColumn, gridLookUpEdit, gridView, displayMember, valueMember);
        }

        public static void Currency(object value, GridLookUpEdit gridLookUpEdit, GridView gridView, string displayMember, string valueMember)
        {
            var listColumn = new List<XtraColumn>()
            {
                new XtraColumn { ColumnName = "CurrencyCode", ColumnCaption = "Mã loại tiền tệ", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 125},
                new XtraColumn { ColumnName = "CurrencyName", ColumnCaption = "Tên loại tiền tệ", ColumnPosition = 2, ColumnVisible = true , ColumnWith = 375},
            };
            HideVisibleColumn(value, listColumn, gridLookUpEdit, gridView, displayMember, valueMember);
        }

        public static void Department(object value, GridLookUpEdit gridLookUpEdit, GridView gridView, string displayMember, string valueMember)
        {
            var listColumn = new List<XtraColumn>
            {
                new XtraColumn { ColumnName = "DepartmentCode", ColumnCaption = "Mã phòng ban", ColumnPosition = 1, ColumnVisible = true },
                new XtraColumn { ColumnName = "DepartmentName", ColumnCaption = "Tên phòng ban", ColumnPosition = 2, ColumnVisible = true },
            };
            HideVisibleColumn(value, listColumn, gridLookUpEdit, gridView, displayMember, valueMember);
        }

        public static void FixedAssetCategory(object value, GridLookUpEdit gridLookUpEdit, GridView gridView, string displayMember, string valueMember)
        {
            var listColumn = new List<XtraColumn>()
            {
                new XtraColumn { ColumnName = "FixedAssetCategoryCode", ColumnCaption = "Mã loại TS", ColumnPosition = 1, ColumnWith = 100, ColumnVisible = true },
                new XtraColumn { ColumnName = "FixedAssetCategoryName", ColumnCaption = "Tên loại TS", ColumnPosition = 2, ColumnWith = 375, ColumnVisible = true },
                new XtraColumn { ColumnName = "LifeTime", ColumnCaption = "Thời gian sử dụng", ColumnPosition = 3, ColumnWith = 125, ColumnVisible = true },
                new XtraColumn { ColumnName = "DepreciationRate", ColumnCaption = "Tỷ lệ hao mòn", ColumnPosition = 4, ColumnWith = 120, ColumnVisible = true }
            };
            HideVisibleColumn(value, listColumn, gridLookUpEdit, gridView, displayMember, valueMember, new GridLookUpItemOption() { CustomSize = new Size(820, 300) });
        }

        public static void MergerFund(object value, GridLookUpEdit gridLookUpEdit, GridView gridView, string displayMember, string valueMember)
        {
            var listColumn = new List<XtraColumn>()
            {
                new XtraColumn { ColumnName = "MergerFundCode", ColumnCaption = "Mã quỹ sát nhập", ColumnPosition = 1, ColumnVisible = true },
                new XtraColumn { ColumnName = "MergerFundName", ColumnCaption = "Tên quỹ sát nhập", ColumnPosition = 2, ColumnVisible = true }
            };
            HideVisibleColumn(value, listColumn, gridLookUpEdit, gridView, displayMember, valueMember);
        }

        public static void ObjectGeneral(object value, GridLookUpEdit gridLookUpEdit, GridView gridView)
        {
            var listColumn = new List<XtraColumn>()
            {
                new XtraColumn { ColumnName = "ObjectGeneralName", ColumnCaption = "", ColumnPosition = 1, ColumnVisible = true }
            };
            HideVisibleColumn(value, listColumn, gridLookUpEdit, gridView, "ObjectGeneralName", "ObjectGeneralId");
            // custom for ObjectGeneral 
            int height = 20;
            gridView.OptionsView.ShowAutoFilterRow = false;
            gridLookUpEdit.Properties.View.OptionsView.ShowColumnHeaders = false;
            gridLookUpEdit.Properties.PopupFormMinSize = new Size(gridLookUpEdit.Size.Width, height);
            gridLookUpEdit.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            IList source = (IList)gridLookUpEdit.Properties.DataSource;
            GridViewInfo gridViewInfo = gridView.GetViewInfo() as GridViewInfo;
            if (gridViewInfo != null)
                height = source.Count * gridViewInfo.ColumnRowHeight - source.Count;

            gridLookUpEdit.Properties.PopupFormSize = new Size(gridLookUpEdit.Size.Width, height);
        }

        public static void ObjectGeneral(object value, GridLookUpEdit gridLookUpEdit, GridView gridView, string displayMember, string valueMember)
        {
            var listColumn = new List<XtraColumn>()
            {
                new XtraColumn { ColumnName = displayMember, ColumnCaption = "", ColumnPosition = 1, ColumnVisible = true }
            };
            HideVisibleColumn(value, listColumn, gridLookUpEdit, gridView, displayMember, valueMember);
            // custom for ObjectGeneral 
            int height = 20;
            gridView.OptionsView.ShowAutoFilterRow = false;
            gridLookUpEdit.Properties.View.OptionsView.ShowColumnHeaders = false;
            gridLookUpEdit.Properties.PopupFormMinSize = new Size(gridLookUpEdit.Size.Width, height);
            gridLookUpEdit.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            IList source = (IList)gridLookUpEdit.Properties.DataSource;
            GridViewInfo gridViewInfo = gridView.GetViewInfo() as GridViewInfo;
            if (gridViewInfo != null)
                height = source.Count * gridViewInfo.ColumnRowHeight - source.Count;

            gridLookUpEdit.Properties.PopupFormSize = new Size(gridLookUpEdit.Size.Width, height);
        }

        public static void ObjectGeneralPayItem(object value, GridLookUpEdit gridLookUpEdit, GridView gridView, string displayMember, string valueMember)
        {
            var listColumn = new List<XtraColumn>()
            {
                new XtraColumn { ColumnName = "ObjectGeneralCode", ColumnCaption = "Mã khoản lương", ColumnPosition = 1, ColumnWith = 175, ColumnVisible = true },
                new XtraColumn { ColumnName = "ObjectGeneralName", ColumnCaption = "Tên khoản lương", ColumnPosition = 1, ColumnWith = 425, ColumnVisible = true }
            };
            HideVisibleColumn(value, listColumn, gridLookUpEdit, gridView, displayMember, valueMember);
        }

        public static void ObjectGeneralInventoryItemType(object value, GridLookUpEdit gridLookUpEdit, GridView gridView, string displayMember, string valueMember)
        {
            var listColumn = new List<XtraColumn>()
            {
                new XtraColumn { ColumnName = "ObjectGeneralName", ColumnCaption = "Loại", ColumnPosition = 1, ColumnWith = 425, ColumnVisible = true }
            };
            HideVisibleColumn(value, listColumn, gridLookUpEdit, gridView, displayMember, valueMember, new GridLookUpItemOption() { ShowAutoFilterRow = false });
        }

        public static void Project(object value, GridLookUpEdit gridLookUpEdit, GridView gridView, string displayMember, string valueMember)
        {
            var listColumn = new List<XtraColumn>()
            {
                new XtraColumn { ColumnName = "ProjectCode", ColumnCaption = "Mã dự án", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 125 },
                new XtraColumn { ColumnName = "ProjectName", ColumnCaption = "Tên dự án", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 375 },
            };
            HideVisibleColumn(value, listColumn, gridLookUpEdit, gridView, displayMember, valueMember);
        }

        public static void PlanTemplateList(object value, GridLookUpEdit gridLookUpEdit, GridView gridView, string displayMember, string valueMember)
        {
            var listColumn = new List<XtraColumn>()
            {
                new XtraColumn { ColumnName = "PlanTemplateListCode", ColumnCaption = "Mã mẫu dự toán", ColumnPosition = 1, ColumnVisible = true, ColumnWith =  125 },
                new XtraColumn { ColumnName = "PlanTemplateListName", ColumnCaption = "Tên mẫu dự toán", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 375 },
            };
            HideVisibleColumn(value, listColumn, gridLookUpEdit, gridView, displayMember, valueMember);
        }

        public static void Stock(object value, GridLookUpEdit gridLookUpEdit, GridView gridView, string displayMember, string valueMember)
        {
            var listColumn = new List<XtraColumn>()
            {
                new XtraColumn { ColumnName = "StockCode", ColumnCaption = "Mã kho", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 70 },
                new XtraColumn { ColumnName = "StockName", ColumnCaption = "Tên kho", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 200 }
            };
            HideVisibleColumn(value, listColumn, gridLookUpEdit, gridView, displayMember, valueMember);
        }

        public static void VoucherType(object value, GridLookUpEdit gridLookUpEdit, GridView gridView, string displayMember, string valueMember)
        {
            var listColumn = new List<XtraColumn>()
            {
                new XtraColumn { ColumnName = "VoucherTypeName", ColumnCaption = "Mã tài khoản", ColumnPosition = 1, ColumnVisible = true },
            };
            HideVisibleColumn(value, listColumn, gridLookUpEdit, gridView, displayMember, valueMember);
        }

        public static void RefType(object value, GridLookUpEdit gridLookUpEdit, GridView gridView, string displayMember, string valueMember)
        {
            var listColumn = new List<XtraColumn>()
            {
                new XtraColumn { ColumnName = "RefTypeName", ColumnCaption = "Loại chứng từ", ColumnPosition = 1, ColumnVisible = true },
            };
            HideVisibleColumn(value, listColumn, gridLookUpEdit, gridView, displayMember, valueMember);
        }

        public static void Employee(object value, GridLookUpEdit gridLookUpEdit, GridView gridView, string displayMember, string valueMember)
        {
            var listColumn = new List<XtraColumn>()
            {

                new XtraColumn { ColumnName = "EmployeeCode", ColumnCaption = "Mã cán bộ", ColumnPosition = 1, ColumnVisible = true, ColumnWith =  125 },
                new XtraColumn { ColumnName = "EmployeeName", ColumnCaption = "Tên cán bộ", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 375 }
            };
            HideVisibleColumn(value, listColumn, gridLookUpEdit, gridView, displayMember, valueMember);
        }

        public static void Vendor(object value, GridLookUpEdit gridLookUpEdit, GridView gridView, string displayMember, string valueMember)
        {
            var listColumn = new List<XtraColumn>()
            {

                new XtraColumn { ColumnName = "VendorCode", ColumnCaption = "Mã NCC", ColumnPosition = 1, ColumnVisible = true, ColumnWith =  125 },
                new XtraColumn { ColumnName = "VendorName", ColumnCaption = "Tên NCC", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 375 }
            };
            HideVisibleColumn(value, listColumn, gridLookUpEdit, gridView, displayMember, valueMember);
        }

        public static void Customer(object value, GridLookUpEdit gridLookUpEdit, GridView gridView, string displayMember, string valueMember)
        {
            var listColumn = new List<XtraColumn>()
            {

                new XtraColumn { ColumnName = "CustomerCode", ColumnCaption = "Mã khách hàng ", ColumnPosition = 1, ColumnVisible = true, ColumnWith =  125 },
                new XtraColumn { ColumnName = "CustomerName", ColumnCaption = "Tên khách hàng", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 375 }
            };
            HideVisibleColumn(value, listColumn, gridLookUpEdit, gridView, displayMember, valueMember);
        }

        #endregion

        #region RepositoryItemGridLookUpEdit

        public static void Account(object value, RepositoryItemGridLookUpEdit resLookUpEdit, string displayMember, string valueMember)
        {
            var listColumn = new List<XtraColumn>
            {
                new XtraColumn { ColumnName = "AccountCode", ColumnCaption = "Mã tài khoản", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 25},
                new XtraColumn { ColumnName = "AccountName", ColumnCaption = "Tên tài khoản", ColumnPosition = 2, ColumnVisible = true , ColumnWith = 75},
            };
            resLookUpEdit.BestFitMode = BestFitMode.None;
            HideVisbleColumn(value, listColumn, resLookUpEdit, displayMember, valueMember);
        }

        public static void AccountingObjectCategory(object value, RepositoryItemGridLookUpEdit resLookUpEdit, string displayMember, string valueMember)
        {
            var listColumn = new List<XtraColumn>
            {
                new XtraColumn { ColumnName = "AccountingObjectCategoryCode", ColumnCaption = "Mã lọai ĐT", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 125},
                new XtraColumn { ColumnName = "AccountingObjectCategoryName", ColumnCaption = "Tên Loại ĐT", ColumnPosition = 2, ColumnVisible = true , ColumnWith = 375},
            };
            HideVisbleColumn(value, listColumn, resLookUpEdit, displayMember, valueMember);
        }

        public static void AccountingObject(object value, RepositoryItemGridLookUpEdit resLookUpEdit, string displayMember, string valueMember)
        {
            var listColumn = new List<XtraColumn>()
            {
                new XtraColumn {ColumnName = "AccountingObjectCode",ColumnCaption = "Mã đối tượng", ColumnPosition = 1,ColumnVisible = true,ColumnWith = 125},
                new XtraColumn {ColumnName = "FullName",ColumnCaption = "Tên đối tượng ", ColumnVisible = true,ColumnPosition = 2,ColumnWith = 375}
            };
            HideVisbleColumn(value, listColumn, resLookUpEdit, displayMember, valueMember);
        }

        public static void AutoBusiness(object value, RepositoryItemGridLookUpEdit resLookUpEdit, string displayMember, string valueMember)
        {
            var listColumn = new List<XtraColumn>
            {
                new XtraColumn { ColumnName = "AutoBusinessCode", ColumnCaption = "Mã định khoản", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 125},
                new XtraColumn { ColumnName = "AutoBusinessName", ColumnCaption = "Tên định khoản", ColumnPosition = 2, ColumnVisible = true , ColumnWith = 375},
            };
            HideVisbleColumn(value, listColumn, resLookUpEdit, displayMember, valueMember, new GridLookUpItemOption() { IsAutoPopupSize = true });
        }

        public static void Bank(object value, RepositoryItemGridLookUpEdit resLookUpEdit, string displayMember, string valueMember)
        {
            var listColumn = new List<XtraColumn>()
            {
                new XtraColumn { ColumnName = "BankAccount", ColumnCaption = "Số tài khoản", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 125 },
                new XtraColumn { ColumnName = "BankName", ColumnCaption = "Tên ngân hàng", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 375 }
            };
            HideVisbleColumn(value, listColumn, resLookUpEdit, displayMember, valueMember);
        }

        public static void BudgetItem(object value, RepositoryItemGridLookUpEdit resLookUpEdit, string displayMember, string valueMember)
        {
            var listColumn = new List<XtraColumn>
            {
                new XtraColumn { ColumnName = "BudgetItemCode", ColumnCaption = "Mã MLNS", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 25},
                new XtraColumn { ColumnName = "BudgetItemName", ColumnCaption = "Tên MLNS", ColumnPosition = 2, ColumnVisible = true , ColumnWith = 75},
            };
            HideVisbleColumn(value, listColumn, resLookUpEdit, displayMember, valueMember);
        }

        public static void BudgetSource(object value, RepositoryItemGridLookUpEdit resLookUpEdit, string displayMember, string valueMember)
        {
            var listColumn = new List<XtraColumn>
            {
                new XtraColumn { ColumnName = "BudgetSourceCode", ColumnCaption = "Mã nguồn", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 25},
                new XtraColumn { ColumnName = "BudgetSourceName", ColumnCaption = "Tên nguồn", ColumnPosition = 2, ColumnVisible = true , ColumnWith = 75},
            };
            HideVisbleColumn(value, listColumn, resLookUpEdit, displayMember, valueMember);
        }

        public static void BudgetChapter(object value, RepositoryItemGridLookUpEdit resLookUpEdit, string displayMember, string valueMember)
        {
            var listColumn = new List<XtraColumn>
            {
                new XtraColumn { ColumnName = "BudgetChapterCode", ColumnCaption = "Mã chương", ColumnVisible = true, ColumnWith = 25, ColumnPosition = 1 },
                new XtraColumn { ColumnName = "BudgetChapterName", ColumnCaption = "Tên chương", ColumnVisible = true, ColumnWith = 75, ColumnPosition = 2 }
            };
            HideVisbleColumn(value, listColumn, resLookUpEdit, displayMember, valueMember);
        }

        public static void BudgetCategory(object value, RepositoryItemGridLookUpEdit resLookUpEdit, string displayMember, string valueMember)
        {
            var listColumn = new List<XtraColumn>
            {
                new XtraColumn { ColumnName = "BudgetCategoryCode", ColumnCaption = "Mã loại khoản", ColumnVisible = true, ColumnWith = 150, ColumnPosition = 1 },
                new XtraColumn { ColumnName = "BudgetCategoryName", ColumnCaption = "Tên loại khoản", ColumnVisible = true, ColumnWith = 450, ColumnPosition = 2 }
            };
            HideVisbleColumn(value, listColumn, resLookUpEdit, displayMember, valueMember);
        }

        public static void MergerFund(object value, RepositoryItemGridLookUpEdit resLookUpEdit, string displayMember, string valueMember)
        {
            var listColumn = new List<XtraColumn>
            {
                new XtraColumn {ColumnName = "MergerFundCode", ColumnCaption = "Mã quỹ", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 100, ToolTip = "Mã mục lục ngân sách" },
                new XtraColumn {ColumnName = "MergerFundName", ColumnCaption = "Tên quỹ", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 400, ToolTip = "Tên mục lục ngân sách" },
            };
            HideVisbleColumn(value, listColumn, resLookUpEdit, displayMember, valueMember);
        }


        public static void Customer(object value, RepositoryItemGridLookUpEdit resLookUpEdit, string displayMember, string valueMember)
        {
            var listColumn = new List<XtraColumn>()
            {
                new XtraColumn { ColumnName = "CustomerCode", ColumnCaption = "Mã khách hàng ", ColumnPosition = 1, ColumnVisible = true, ColumnWith =  25 },
                new XtraColumn { ColumnName = "CustomerName", ColumnCaption = "Tên khách hàng", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 75 }
            };
            HideVisbleColumn(value, listColumn, resLookUpEdit, displayMember, valueMember);
        }

        public static void Currency(object value, RepositoryItemGridLookUpEdit resLookUpEdit, string displayMember, string valueMember)
        {
            var listColumn = new List<XtraColumn>
            {
                new XtraColumn { ColumnName = "CurrencyCode", ColumnCaption = "Mã tiền tệ", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 25},
                new XtraColumn { ColumnName = "CurrencyName", ColumnCaption = "Tên tiền tệ", ColumnPosition = 2, ColumnVisible = true , ColumnWith = 75},
            };
            HideVisbleColumn(value, listColumn, resLookUpEdit, displayMember, valueMember);
        }

        public static void Currency(object value, RepositoryItemGridLookUpEdit resLookUpEdit)
        {
            var listColumn = new List<XtraColumn>
            {
                new XtraColumn { ColumnName = "CurrencyCode", ColumnCaption = "Mã tiền tệ", ColumnPosition = 1, ColumnVisible = false, ColumnWith = 25},
                new XtraColumn { ColumnName = "CurrencyName", ColumnCaption = "Tên tiền tệ", ColumnPosition = 2, ColumnVisible = true , ColumnWith = 75},
            };
            HideVisbleColumn(value, listColumn, resLookUpEdit, "CurrencyCode", "CurrencyName", new GridLookUpItemOption() { ShowAutoFilterRow = false });
        }

        public static void Department(object value, RepositoryItemGridLookUpEdit resLookUpEdit, string displayMember, string valueMember)
        {
            var listColumn = new List<XtraColumn>
            {
                new XtraColumn { ColumnName = "DepartmentCode", ColumnCaption = "Mã phòng ban", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 25},
                new XtraColumn { ColumnName = "DepartmentName", ColumnCaption = "Tên phòng ban", ColumnPosition = 2, ColumnVisible = true , ColumnWith = 75},
            };
            HideVisbleColumn(value, listColumn, resLookUpEdit, displayMember, valueMember);
        }

        public static void Employee(object value, RepositoryItemGridLookUpEdit resLookUpEdit, string displayMember, string valueMember)
        {
            var listColumn = new List<XtraColumn>()
            {
                new XtraColumn { ColumnName = "EmployeeCode", ColumnCaption = "Mã cán bộ", ColumnPosition = 1, ColumnVisible = true, ColumnWith =  25 },
                new XtraColumn { ColumnName = "EmployeeName", ColumnCaption = "Tên cán bộ", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 75 }
            };
            HideVisbleColumn(value, listColumn, resLookUpEdit, displayMember, valueMember);
        }

        public static void InventoryItem(object value, RepositoryItemGridLookUpEdit resLookUpEdit, string displayMember, string valueMember)
        {
            var listColumn = new List<XtraColumn>
            {
                new XtraColumn { ColumnName = "InventoryItemCode", ColumnCaption = "Mã vật tư", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 25},
                new XtraColumn { ColumnName = "InventoryItemName", ColumnCaption = "Tên vật tư", ColumnPosition = 2, ColumnVisible = true , ColumnWith = 75},
            };
            HideVisbleColumn(value, listColumn, resLookUpEdit, displayMember, valueMember);
        }

        public static void InventoryItemByStock(object value, RepositoryItemGridLookUpEdit resLookUpEdit, string displayMember, string valueMember)
        {
            var listColumn = new List<XtraColumn>
            {
                new XtraColumn { ColumnName = "InventoryItemCode", ColumnCaption = "Mã vật tư", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 20},
                new XtraColumn { ColumnName = "InventoryItemName", ColumnCaption = "Tên vật tư", ColumnPosition = 2, ColumnVisible = true , ColumnWith = 60},
                new XtraColumn { ColumnName = "CostMethod", ColumnCaption = "Tồn kho", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 20, ColumnType = DevExpress.Data.UnboundColumnType.Integer, DisplayFormat = "N0" }
            };
            HideVisbleColumn(value, listColumn, resLookUpEdit, displayMember, valueMember);
        }

        public static void FixedAsset(object value, RepositoryItemGridLookUpEdit resLookUpEdit, string displayMember, string valueMember)
        {
            var listColumn = new List<XtraColumn>()
            {
                new XtraColumn { ColumnName = "FixedAssetCode", ColumnCaption = "Mã CCDC", ColumnPosition = 1, ColumnWith = 25, ColumnVisible = true },
                new XtraColumn { ColumnName = "FixedAssetName", ColumnCaption = "Tên CCDC", ColumnPosition = 2, ColumnWith = 75, ColumnVisible = true },
            };
            HideVisbleColumn(value, listColumn, resLookUpEdit, displayMember, valueMember);
        }

        public static void ObjectGeneral(object value, RepositoryItemGridLookUpEdit resLookUpEdit, string displayMember, string valueMember)
        {
            var listColumn = new List<XtraColumn>()
            {
                new XtraColumn { ColumnName = "ObjectGeneralName", ColumnCaption = " ", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 200, Alignment = HorzAlignment.Near }
            };
            HideVisbleColumn(value, listColumn, resLookUpEdit, displayMember, valueMember);
        }

        public static void PayItem(object value, RepositoryItemGridLookUpEdit resLookUpEdit, string displayMember, string valueMember)
        {
            var listColumn = new List<XtraColumn>
            {
                new XtraColumn {ColumnName = "PayItemCode", ColumnCaption = "Mã khoản lương", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 20 },
                new XtraColumn {ColumnName = "PayItemName", ColumnCaption = "Tên khoản lương", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 55 },
                new XtraColumn {ColumnName = "Description", ColumnCaption = "Mô tả", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 25 },
            };
            HideVisbleColumn(value, listColumn, resLookUpEdit, displayMember, valueMember);
        }

        public static void Project(object value, RepositoryItemGridLookUpEdit resLookUpEdit, string displayMember, string valueMember)
        {
            var listColumn = new List<XtraColumn>
            {
                new XtraColumn { ColumnName = "ProjectCode", ColumnCaption = "Mã dự án", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 25},
                new XtraColumn { ColumnName = "ProjectName", ColumnCaption = "Tên dự án", ColumnPosition = 2, ColumnVisible = true , ColumnWith = 75},
            };
            HideVisbleColumn(value, listColumn, resLookUpEdit, displayMember, valueMember);
        }

        public static void VoucherType(object value, RepositoryItemGridLookUpEdit resLookUpEdit, string displayMember, string valueMember)
        {
            var listColumn = new List<XtraColumn>
            {
                //new XtraColumn { ColumnName = "VoucherTypeId", ColumnCaption = "Mã nghiệp vụ", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 25 },
                new XtraColumn { ColumnName = "VoucherTypeName", ColumnCaption = "Tên nghiệp vụ", ColumnPosition = 2, ColumnVisible = true , ColumnWith = 100 },
            };
            HideVisbleColumn(value, listColumn, resLookUpEdit, displayMember, valueMember, new GridLookUpItemOption()
            {
                IsAutoPopupSize = true,
                ShowAutoFilterRow = false
            });
            resLookUpEdit.View.OptionsView.ShowColumnHeaders = false;
        }

        public static void Vendor(object value, RepositoryItemGridLookUpEdit resLookUpEdit, string displayMember, string valueMember)
        {
            var listColumn = new List<XtraColumn>()
            {
                new XtraColumn { ColumnName = "VendorCode", ColumnCaption = "Mã NCC", ColumnPosition = 1, ColumnVisible = true, ColumnWith =  25 },
                new XtraColumn { ColumnName = "VendorName", ColumnCaption = "Tên NCC", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 75 }
            };
            HideVisbleColumn(value, listColumn, resLookUpEdit, displayMember, valueMember);
        }

        public static void RefType(object value, RepositoryItemGridLookUpEdit resLookUpEdit, string displayMember, string valueMember)
        {
            var listColumn = new List<XtraColumn>()
            {
                new XtraColumn { ColumnName = "RefTypeName", ColumnCaption = "Loại chứng từ", ColumnPosition = 1, ColumnVisible = true },
            };
            HideVisbleColumn(value, listColumn, resLookUpEdit, displayMember, valueMember);
        }

        public static void Stock(object value, RepositoryItemGridLookUpEdit resLookUpEdit, string displayMember, string valueMember)
        {
            var listColumn = new List<XtraColumn>
            {
                new XtraColumn { ColumnName = "StockCode", ColumnCaption = "Mã kho", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 25},
                new XtraColumn { ColumnName = "StockName", ColumnCaption = "Tên kho", ColumnPosition = 2, ColumnVisible = true , ColumnWith = 75},
            };
            HideVisbleColumn(value, listColumn, resLookUpEdit, displayMember, valueMember);
        }

        #endregion

        public static void HideVisibleColumn(object value, List<XtraColumn> listColumn, GridLookUpEdit gridLookUpEdit, GridView gridView, string displayMember, string valueMember, GridLookUpItemOption option = null)
        {
            gridLookUpEdit.Properties.View = gridView;
            gridLookUpEdit.Properties.View.Columns.Clear();
            gridLookUpEdit.Properties.DataSource = value;
            gridLookUpEdit.Properties.View.RefreshData();
            gridLookUpEdit.Properties.PopulateViewColumns();
            gridLookUpEdit.Properties.View.ActiveFilterString = string.Empty;
            gridLookUpEdit.Properties.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
            gridLookUpEdit.Properties.AllowNullInput = DefaultBoolean.True;
            gridLookUpEdit.Properties.DisplayMember = displayMember;
            gridLookUpEdit.Properties.ValueMember = valueMember;
            gridLookUpEdit.Properties.ShowFooter = false;
            gridLookUpEdit.Properties.ImmediatePopup = true;

            gridLookUpEdit.Properties.View.OptionsView.ShowGroupPanel = false;
            gridLookUpEdit.Properties.View.OptionsView.ShowIndicator = false;
            gridLookUpEdit.Properties.View.OptionsBehavior.EditorShowMode = EditorShowMode.Default;

            gridLookUpEdit.Properties.View.OptionsView.ShowAutoFilterRow = option != null ? option.ShowAutoFilterRow : true;
            if (gridLookUpEdit.Properties.PopupFormSize.Width < gridLookUpEdit.Width)
            {
                gridLookUpEdit.Properties.PopupFormSize = new Size(gridLookUpEdit.Width, gridLookUpEdit.Properties.PopupFormSize.Height);
            }
            if (option != null && option.IsAutoPopupSize)
            {
                int height = 20;
                IList source = (IList)gridLookUpEdit.Properties.DataSource;
                GridViewInfo gridViewInfo = gridView.GetViewInfo() as GridViewInfo;
                if (gridViewInfo != null)
                    height = source.Count * gridViewInfo.ColumnRowHeight;
                gridLookUpEdit.Properties.PopupFormSize = new Size(515, height);
                gridLookUpEdit.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
                gridLookUpEdit.Properties.PopupFormMinSize = new Size(gridLookUpEdit.Size.Width, height);
            }
            else
            {
                gridLookUpEdit.Properties.TextEditStyle = TextEditStyles.Standard;
                gridLookUpEdit.Properties.ImmediatePopup = true;
                gridLookUpEdit.Properties.PopupFormSize = option != null && option.CustomSize != default(Size) ? option.CustomSize : new Size(520, 175);
            }

            if (listColumn != null)
            {
                foreach (GridColumn gridColumn in gridLookUpEdit.Properties.View.Columns)
                {
                    XtraColumn xtraColumn = listColumn.Where(w => w.ColumnName == gridColumn.FieldName && w.ColumnVisible == true)?.FirstOrDefault() ?? null;
                    if (xtraColumn != null)
                    {
                        gridColumn.Visible = true;
                        gridColumn.Caption = xtraColumn.ColumnCaption;
                        gridColumn.SortIndex = xtraColumn.ColumnPosition;
                        gridColumn.Width = xtraColumn.ColumnWith;
                        gridColumn.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
                    }
                    else
                        gridColumn.Visible = false;
                }
            }
                
        }

        public static void HideVisbleColumn(object value, List<XtraColumn> listColumn, RepositoryItemGridLookUpEdit resLookUpEdit, string displayMember, string valueMember, GridLookUpItemOption option = null)
        {
            resLookUpEdit.View.Columns.Clear();
            resLookUpEdit.DataSource = value;
            resLookUpEdit.View.RefreshData();
            GridView gridView = resLookUpEdit.View as GridView;
            resLookUpEdit.View.PopulateColumns(value);
            resLookUpEdit.AllowNullInput = DefaultBoolean.True;
            resLookUpEdit.TextEditStyle = TextEditStyles.Standard;
            resLookUpEdit.View.ActiveFilterString = string.Empty;
            resLookUpEdit.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
            resLookUpEdit.View.OptionsView.ShowGroupPanel = false;
            resLookUpEdit.View.OptionsView.ShowIndicator = false;
            resLookUpEdit.View.OptionsView.ShowAutoFilterRow = option != null ? option.ShowAutoFilterRow : true;
            resLookUpEdit.DisplayMember = displayMember;
            resLookUpEdit.ValueMember = valueMember;
            resLookUpEdit.ShowFooter = false;
            resLookUpEdit.NullText = "";

            if (listColumn != null)
                foreach (GridColumn gridColumn in resLookUpEdit.View.Columns)
                {
                    XtraColumn xtraColumn = listColumn.Where(w => w.ColumnName == gridColumn.FieldName && w.ColumnVisible == true)?.FirstOrDefault() ?? null;
                    if (xtraColumn != null)
                    {
                        gridColumn.Caption = xtraColumn.ColumnCaption;
                        gridColumn.Width = xtraColumn.ColumnWith;
                        gridColumn.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
                        gridColumn.UnboundType = xtraColumn.ColumnType;
                        switch (xtraColumn.ColumnType)
                        {
                            case DevExpress.Data.UnboundColumnType.Integer:
                                {
                                    var _rpsCalcNumber = new RepositoryItemCalcEdit { AllowMouseWheel = false };
                                    _rpsCalcNumber.Mask.MaskType = MaskType.Numeric;
                                    _rpsCalcNumber.Mask.EditMask = @"n0";
                                    _rpsCalcNumber.Mask.UseMaskAsDisplayFormat = true;
                                    _rpsCalcNumber.Mask.Culture = Thread.CurrentThread.CurrentCulture;
                                    gridColumn.ColumnEdit = _rpsCalcNumber;
                                }
                                break;
                        }
                    }
                    else
                        gridColumn.Visible = false;
                }

            if (option != null && option.IsAutoPopupSize)
            {
                resLookUpEdit.BestFitMode = BestFitMode.BestFitResizePopup;
            }
            else
            {
                resLookUpEdit.PopupFormSize = option != null && option.CustomSize != default(Size) ? option.CustomSize : new Size(520, 175);
            }
        }
    }

    internal class GridLookUpItemOption
    {
        internal GridLookUpItemOption()
        {
            IsAutoPopupSize = false;
            CustomSize = default(Size);
            ShowAutoFilterRow = true;
        }

        internal bool IsAutoPopupSize { get; set; }
        internal Size CustomSize { get; set; }
        internal bool ShowAutoFilterRow { get; set; }
    }
}

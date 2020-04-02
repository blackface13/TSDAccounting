/***********************************************************************
 * <copyright file="SqlServerFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Thursday, February 26, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  07/03/2014       Author    Tudt           Description: Coding standard
 * 
 * ************************************************************************/

namespace TSD.AccountingSoft.View.Dictionary
{
    /// <summary>
    /// Interface IBudgetItemView
    /// </summary>
    public interface IBudgetItemView : IView
    {
        int BudgetItemId { get; set; }

        int? BudgetGroupId { get; set; }

        string BudgetItemCode { get; set; }

        string BudgetItemName { get; set; }

        string ForeignName { get; set; }

        int? ParentId { get; set; }

        bool IsParent { get; set; }

        bool IsFixedItem { get; set; }

        bool IsExpandItem { get; set; }

        bool IsNoAllocate { get; set; }
        
        bool IsOrganItem { get; set; }
        
        bool IsActive { get; set; }

        int BudgetItemType { get; set; }

        bool IsReceipt { get; set; }

        decimal Rate { get; set; }

        bool IsShowOnVoucher { get; set; }
    }
}
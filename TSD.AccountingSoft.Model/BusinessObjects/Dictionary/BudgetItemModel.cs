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

namespace TSD.AccountingSoft.Model.BusinessObjects.Dictionary
{
    /// <summary>
    /// Class BudgetItemModel.
    /// </summary>
    public class BudgetItemModel
    {
        public int BudgetItemId { get; set; }

        public int? BudgetGroupId { get; set; }

        public string BudgetItemCode { get; set; }

        public string BudgetItemName { get; set; }

        public string ForeignName { get; set; }

        public int? ParentId { get; set; }

        public int Grade { get; set; }

        public bool IsParent { get; set; }

        public bool IsFixedItem { get; set; }

        public bool IsExpandItem { get; set; }

        public bool IsNoAllocate { get; set; }

        public bool IsOrganItem { get; set; }

        public bool IsActive { get; set; }

        public bool IsSystem { get; set; }

        public int BudgetItemType { get; set; }

        public string BudgetItemTypeName { get; set; }

        public bool IsReceipt { get; set; }

        public bool IsChoose { get; set; }

        public decimal Rate { get; set; }

        public string NumberOrder { get; set; }

        public bool IsShowOnVoucher { get; set; }
    }
}

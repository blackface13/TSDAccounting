/***********************************************************************
 * <copyright file="ItemTransactionDetailModel.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   BangNC
 * Email:    BangNC@buca.vn
 * Website:
 * Create Date: 23 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using TSD.AccountingSoft.Model.BusinessObjects.BaseModel;

namespace TSD.AccountingSoft.Model.BusinessObjects.Inventory
{
    [Serializable]
    public class ItemTransactionDetailModel : BaseVoucherModel
    {
        public long RefDetailId { get; set; }
        public int InventoryItemId { get; set; }
        public string Description { get; set; }
        public string AccountNumber { get; set; }
        public string CorrespondingAccountNumber { get; set; }
        public int? VoucherTypeId { get; set; }
        public string BudgetSourceCode { get; set; }
        public string BudgetItemCode { get; set; }
        public int? AccountingObjectId { get; set; }
        public int? MergerFundId { get; set; }
        public int? ProjectId { get; set; }
        public long RefId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal AmountOc { get; set; }
        public decimal AmountExchange { get; set; }
        public int? AutoBusinessId { get; set; }
        public decimal PriceExchange { get; set; }
        public int FreeQuantity { get; set; }
        public int CancelQuantity { get; set; }
        public int TotalQuantity { get; set; }
        public int? DepartmentId { get; set; }
    } 
}

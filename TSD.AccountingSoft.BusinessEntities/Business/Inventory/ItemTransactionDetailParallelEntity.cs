﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.BusinessEntities.Business.Inventory
{
    public class ItemTransactionDetailParallelEntity : BusinessEntities
    {
        public long RefDetailId { get; set; }
        public long RefId { get; set; }
        public int RefTypeId { get; set; }
        public string Description { get; set; }
        public string AccountNumber { get; set; }
        public string CorrespondingAccountNumber { get; set; }
        public int TotalQuantity { get; set; }
        public decimal Price { get; set; }
        public decimal PriceExchange { get; set; }
        public decimal AmountOc { get; set; }
        public decimal AmountExchange { get; set; }
        public string BudgetSourceCode { get; set; }
        public string BudgetItemCode { get; set; }
        public int? VoucherTypeId { get; set; }
        public int? DepartmentId { get; set; }
        public int? ProjectId { get; set; }
        public int? FixedAssetId { get; set; }
        public int? InventoryItemId { get; set; }
        public int? MergerFundId { get; set; }
        public int? AccountingObjectId { get; set; }
        public int? EmployeeId { get; set; }
        public int? CustomerId { get; set; }
        public int? VendorId { get; set; }
        public int? AutoBusinessId { get; set; }
    }
}

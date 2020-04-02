using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.BusinessEntities.Business.Tool
{
    public class SUIncrementDecrementDetailEntity : BusinessEntities
    {
        public long RefDetailId { get; set; }
        public long RefId { get; set; }
        public string DebitAccount { get; set; }
        public string CreditAccount { get; set; }
        public string Description { get; set; }
        public int InventoryItemId { get; set; } 
        public int DepartmentId { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPriceOc { get; set; }
        public decimal UnitPriceExchange { get; set; }
        public decimal AmountOc { get; set; }
        public decimal AmountExchange { get; set; }
        public long? AccountingObjectId { get; set; }
        public long? CustomerId { get; set; }
        public long? VendorId { get; set; }
        public long? EmployeeId { get; set; }
        public int? SortOrder { get; set; }
        public long? BudgetSourceId { get; set; }

    }
}

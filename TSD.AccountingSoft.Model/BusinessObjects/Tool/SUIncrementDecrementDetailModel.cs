using TSD.AccountingSoft.Model.BusinessObjects.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.Model.BusinessObjects.Tool
{
    public class SUIncrementDecrementDetailModel : BaseVoucherModel
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
        public int? AccountingObjectId { get; set; }
        public int? CustomerId { get; set; }
        public int? VendorId { get; set; }
        public int? EmployeeId { get; set; }
        public int? SortOrder { get; set; }
        public int? BudgetSourceId { get; set; }
    }
}
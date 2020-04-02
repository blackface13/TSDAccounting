using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.Model.BusinessObjects.Report.FixedAsset
{
    public class FixedAssetS26HModel
    {
        public int OrderNumber { get; set; }
        public string FixedAssetCode { get; set; }
        public string FixedAssetName { get; set; }
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
        public string FixedAssetCategoryCode { get; set; }
        public string FixedAssetCategoryName { get; set; }
        public DateTime? PostDate { get; set; }
        public string RefNo { get; set; }
        public DateTime? RefDate { get; set; }
        public string Unit { get; set; }
        public string JournalMemo { get; set; }
        public decimal FixedAssetIncrement_Quantity { get; set; }
        public decimal FixedAssetIncrement_UnitPrice { get; set; }
        public decimal FixedAssetIncrement_Amount { get; set; }
        public decimal FixedAssetDecrement_Quantity { get; set; }
        public decimal FixedAssetDecrement_UnitPrice { get; set; }
        public decimal FixedAssetDecrement_Amount { get; set; }
    }
}

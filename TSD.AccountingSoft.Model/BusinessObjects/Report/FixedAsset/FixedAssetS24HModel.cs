using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.Model.BusinessObjects.Report.FixedAsset
{
    public class FixedAssetS24HModel
    {
		public int FixedAssetID { get; set; }
		public string FixedAssetCode { get; set; }
		public string FixedAssetName { get; set; }
		public int FixedAssetCategoryID { get; set; }
		public string FixedAssetCategoryCode { get; set; }
		public string FixedAssetCategoryName { get; set; }
		public string MadeIn { get; set; }
		public DateTime? UsedDate { get; set; }

		public long IncrementRefID { get; set; }
		public string IncrementRefNo { get; set; }
		public DateTime? IncrementRefDate { get; set; }
		public DateTime? IncrementPostedDate { get; set; }
		public decimal IncrementAmount { get; set; }

		public decimal DepreciationRate { get; set; }
		public decimal AnnualDepreciationAmount { get; set; }
		public decimal ArmortizationAmount { get; set; }
		public decimal ArmortizationAccumulateAmount { get; set; }

		public long DecrementRefID { get; set; }
		public string DecrementRefNo { get; set; }
		public DateTime? DecrementRefDate { get; set; }
		public DateTime? DecrementPostedDate { get; set; }
		public string DecrementDescription { get; set; }
		public decimal DecrementAmount { get; set; }

		public int SortOrder { get; set; }
	}
}

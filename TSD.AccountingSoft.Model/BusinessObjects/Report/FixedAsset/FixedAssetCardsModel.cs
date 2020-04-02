using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.Model.BusinessObjects.Report.FixedAsset
{
    public class FixedAssetCardsModel
    {
        public int FixedAssetId { get; set; }
        public string FixedAssetCode { get; set; }
        public string FixedAssetName { get; set; }
        public string MadeIn { get; set; }
        public int ProductionYear { get; set; }
        public string DepartmentName { get; set; }
        public DateTime UsedDate { get; set; }
        public DateTime? DateSuspension { get; set; }
        public string ReasonSuspension { get; set; }
        public decimal AreaOfFloor { get; set; }
        public string RefNoGG { get; set; }
        public DateTime? PostdateGG { get; set; }
        public string DescriptionGG { get; set; }
        public List<FixedAssetDetailCards01Model> FixedAssetDetailCards01 { get; set; }
        public List<FixedAssetDetailCards02Model> FixedAssetDetailCards02 { get; set; }
    }

    //public class FixedAssetMasterCardsModel
    //{
    //    public int FixedAssetId { get; set; }
    //    public string FixedAssetCode { get; set; }
    //    public string FixedAssetName { get; set; }
    //    public string MadeIn { get; set; }
    //    public int ProductionYear { get; set; }
    //    public string DepartmentName { get; set; }
    //    public DateTime UsedDate { get; set; }
    //    public DateTime? DateSuspension { get; set; }
    //    public string ReasonSuspension { get; set; }
    //    public int AreaOfFloor { get; set; }
    //}

    public class FixedAssetDetailCards01Model
    {
        public string RefNo { get; set; }
        public DateTime PostedDate { get; set; }
        public string Description { get; set; }
        public string CurrencyCode { get; set; }
        public decimal OrgPrice { get; set; }
        public DateTime DepreciationDate { get; set; }
        public decimal AnnualDepreciationAmount { get; set; }
        public decimal AccumDepreciationAmount { get; set; }
    }

    public class FixedAssetDetailCards02Model
    {
        public string FixedAssetAccessaryName { get; set; }
        public string Unit { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
    }
}

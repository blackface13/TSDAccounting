using System;

namespace TSD.AccountingSoft.BusinessEntities.Report.FixedAsset
{
    public class FixedAssetS31HEntity : BusinessEntities
    {
        /// <summary>
        /// Gets or sets the name of the fixed asset.
        /// </summary>
        /// <value>
        /// The name of the fixed asset.
        /// </value>
        public DateTime PostedDate { get; set; }

        /// <summary>
        /// Gets or sets the year of using.
        /// </summary>
        /// <value>
        /// The year of using.
        /// </value>
        public string RefNo { get; set; }

        /// <summary>
        /// Gets or sets the fixed asset code.
        /// </summary>
        /// <value>
        /// The fixed asset code.
        /// </value>
        public DateTime RefDate { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string FixedAssetName { get; set; }

        /// <summary>
        /// Gets or sets the serial number.
        /// </summary>
        /// <value>
        /// The serial number.
        /// </value>
        public string FixedAssetCode { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string DepartmentName { get; set; }

        /// <summary>
        /// Gets or sets the serial number.
        /// </summary>
        /// <value>
        /// The serial number.
        /// </value>
        public string EmployeeName { get; set; }

        /// <summary>
        /// Gets or sets the country production.
        /// </summary>
        /// <value>
        /// The country production.
        /// </value>
        public int YearOfUsing { get; set; }


        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>
        /// The quantity.
        /// </value>
        public float LifeTime { get; set; }

        /// <summary>
        /// Gets or sets the org price.
        /// </summary>
        /// <value>
        /// The org price.
        /// </value>
        public float AnnualDepreciationRate { get; set; }

        /// <summary>
        /// Gets or sets the org price usd.
        /// </summary>
        /// <value>
        /// The org price usd.
        /// </value>
        public decimal OrgPrice { get; set; }

        /// <summary>
        /// Gets or sets the org price currency usd.
        /// </summary>
        /// <value>
        /// The org price currency usd.
        /// </value>
        public decimal AnnualDepreciationAmount { get; set; }

        /// <summary>
        /// Gets or sets the org price currency usd.
        /// </summary>
        /// <value>
        /// The org price currency usd.
        /// </value>
        public decimal RemainingPriceBeforeDecrement { get; set; }
    }
}

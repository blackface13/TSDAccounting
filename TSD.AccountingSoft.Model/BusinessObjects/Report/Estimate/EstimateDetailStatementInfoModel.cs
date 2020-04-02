/***********************************************************************
 * <copyright file="EstimateDetailStatementModel.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TUDT
 * Email:     tudt@buca.vn
 * Website:
 * Create Date: 23 June 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/


namespace TSD.AccountingSoft.Model.BusinessObjects.Report.Estimate
{
    /// <summary>
    /// class EstimateDetailStatementInfoModel
    /// </summary>
    public class EstimateDetailStatementInfoModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int EstimateDetailStatementId { get; set; }

        /// <summary>
        /// Gets or sets the name of the budget item.
        /// </summary>
        /// <value>
        /// The name of the budget item.
        /// </value>
        public string GeneralDescription { get; set; }

        /// <summary>
        /// Gets or sets the previous year of total estimate amount.
        /// </summary>
        /// <value>
        /// The previous year of total estimate amount.
        /// </value>
        public string EmployeeLeasingDescription { get; set; }

        /// <summary>
        /// Gets or sets the year of estimate amount.
        /// </summary>
        /// <value>
        /// The year of estimate amount.
        /// </value>
        public string EmployeeContractDescription { get; set; }

        /// <summary>
        /// Gets or sets the next year of estimate amount.
        /// </summary>
        /// <value>
        /// The next year of estimate amount.
        /// </value>
        public string BuildingOfFixedAssetDescription { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string DescriptionForBuilding { get; set; }

        /// <summary>
        /// Gets or sets the car description.
        /// </summary>
        /// <value>
        /// The car description.
        /// </value>
        public string CarDescription { get; set; }

        /// <summary>
        /// Gets or sets the inventory description.
        /// </summary>
        /// <value>
        /// The inventory description.
        /// </value>
        public string InventoryDescription { get; set; }

        /// <summary>
        /// Gets or sets the part c.
        /// </summary>
        /// <value>
        /// The part c.
        /// </value>
        public string PartC { get; set; }

        public string PartC1 { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is active].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is active]; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }

        public bool Type { get; set; }
    }
}

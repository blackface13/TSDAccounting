/***********************************************************************
 * <copyright file="EstimateDetailStatementView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Thursday, June 23, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  07/03/2014       Author    Tudt           Description: Coding standard
 * 
 * ************************************************************************/


namespace TSD.AccountingSoft.View.Estimate
{
    /// <summary>
    /// EstimateDetailStatementView
    /// </summary>
   public interface IEstimateDetailStatementView
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        int EstimateDetailStatementId { get; set; }

        /// <summary>
        /// Gets or sets the name of the budget item.
        /// </summary>
        /// <value>
        /// The name of the budget item.
        /// </value>
        string GeneralDescription { get; set; }

        /// <summary>
        /// Gets or sets the previous year of total estimate amount.
        /// </summary>
        /// <value>
        /// The previous year of total estimate amount.
        /// </value>
        string EmployeeLeasingDescription { get; set; }

        /// <summary>
        /// Gets or sets the year of estimate amount.
        /// </summary>
        /// <value>
        /// The year of estimate amount.
        /// </value>
        string EmployeeContractDescription { get; set; }

        /// <summary>
        /// Gets or sets the next year of estimate amount.
        /// </summary>
        /// <value>
        /// The next year of estimate amount.
        /// </value>
        string BuildingOfFixedAssetDescription { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        string DescriptionForBuilding { get; set; }

        /// <summary>
        /// Gets or sets the car description.
        /// </summary>
        /// <value>
        /// The car description.
        /// </value>
        string CarDescription { get; set; }

        /// <summary>
        /// Gets or sets the inventory description.
        /// </summary>
        /// <value>
        /// The inventory description.
        /// </value>
        string InventoryDescription { get; set; }

        /// <summary>
        /// Gets or sets the part c.
        /// </summary>
        /// <value>
        /// The part c.
        /// </value>
        string PartC { get; set; }

        string PartC1 { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is active].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is active]; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; set; }

        bool Type { get; set; }
    }
}

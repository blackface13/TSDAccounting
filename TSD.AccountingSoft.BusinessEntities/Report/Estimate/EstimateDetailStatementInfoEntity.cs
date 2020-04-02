/***********************************************************************
 * <copyright file="GeneralReceiptEstimate.cs" company="BUCA JSC">
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

namespace TSD.AccountingSoft.BusinessEntities.Report.Estimate
{
    /// <summary>
    /// GeneralReceiptEstimate
    /// </summary>
    public class EstimateDetailStatementInfoEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EstimateDetailStatementInfoEntity"/> class.
        /// </summary>
        public EstimateDetailStatementInfoEntity()
        {
            
        }

        public EstimateDetailStatementInfoEntity(int estimateDetailStatementId, short yearOfEstimate, string generalDescription,
            string employeeLeasingDescription, string employeeContractDescription, string buildingOfFixedAssetDescription,
            string descriptionForBuilding, string carDescription, string partC,string partC1, bool isActive, string inventoryDescription,bool type)
            : this()
        {
            EstimateDetailStatementId = estimateDetailStatementId;
            YearOfEstimate = yearOfEstimate;
            GeneralDescription = generalDescription;
            EmployeeLeasingDescription = employeeLeasingDescription;
            EmployeeContractDescription = employeeContractDescription;
            BuildingOfFixedAssetDescription = buildingOfFixedAssetDescription;
            DescriptionForBuilding = descriptionForBuilding;
            CarDescription = carDescription;
            PartC = partC;
            PartC1 = partC1;
            InventoryDescription = inventoryDescription;
            IsActive = isActive;
            Type = type;
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int EstimateDetailStatementId { get; set; }

        /// <summary>
        /// Gets or sets the budget item code.
        /// </summary>
        /// <value>
        /// The budget item code.
        /// </value>
        public short YearOfEstimate { get; set; }

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

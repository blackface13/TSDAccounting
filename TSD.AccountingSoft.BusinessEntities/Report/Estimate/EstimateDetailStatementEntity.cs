/***********************************************************************
 * <copyright file="EstimateDetailStatement.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 11 June 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using TSD.AccountingSoft.BusinessEntities.Dictionary;


namespace TSD.AccountingSoft.BusinessEntities.Report.Estimate
{
    /// <summary>
    /// EstimateDetailStatement
    /// </summary>
    public class EstimateDetailStatementEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EstimateDetailStatementEntity"/> class.
        /// </summary>
        public EstimateDetailStatementEntity()
        {
            Employees = new List<EmployeeForEstimateEntity>();
            EmployeeOthers = new List<EmployeeLeasingEntity>();
            EmployeeLeasings = new List<EmployeeLeasingEntity>();
            FixedAssets = new List<FixedAssetForEstimateEntity>();
            Buildings = new List<BuildingEntity>();
            EstimateDetailStatementPartBs = new List<EstimateDetailStatementPartBEntity>();
            Mutuals = new List<MutualEntity>();
            FixedAssetCars = new List<FixedAssetEntity>();
        }

        /// <summary>
        /// Gets or sets the employees.
        /// </summary>
        /// <value>
        /// The employees.
        /// </value>
        public IList<EmployeeForEstimateEntity> Employees { get; set; }

        /// <summary>
        /// Gets or sets the employee others.
        /// </summary>
        /// <value>
        /// The employee others.
        /// </value>
        public IList<EmployeeLeasingEntity> EmployeeOthers { get; set; }

        /// <summary>
        /// Gets or sets the employee leasings.
        /// </summary>
        /// <value>
        /// The employee leasings.
        /// </value>
        public IList<EmployeeLeasingEntity> EmployeeLeasings { get; set; }

        /// <summary>
        /// Gets or sets the fixed assets.
        /// </summary>
        /// <value>
        /// The fixed assets.
        /// </value>
        public IList<FixedAssetForEstimateEntity> FixedAssets { get; set; }

        /// <summary>
        /// Gets or sets the buildings.
        /// </summary>
        /// <value>
        /// The buildings.
        /// </value>
        public IList<BuildingEntity> Buildings { get; set; }

        /// <summary>
        /// Gets or sets the estimate detail statement part bs.
        /// </summary>
        /// <value>
        /// The estimate detail statement part bs.
        /// </value>
        public IList<EstimateDetailStatementPartBEntity> EstimateDetailStatementPartBs { get; set; }

        public IList<EstimateDetailStatementFixedAssetEntity> EstimateDetailStatementFixedAssets { get; set; }

        public IList<MutualEntity> Mutuals { get; set; }

        public IList<FixedAssetEntity> FixedAssetCars { get; set; }




    }
}

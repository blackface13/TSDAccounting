/***********************************************************************
 * <copyright file="EstimateDetailStatementEntity.cs" company="BUCA JSC">
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
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;


namespace TSD.AccountingSoft.Model.BusinessObjects.Report.Estimate
{
    /// <summary>
    /// EstimateDetailStatementEntity
    /// </summary>
    public class EstimateDetailStatementModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EstimateDetailStatementModel"/> class.
        /// </summary>
        public EstimateDetailStatementModel()
        {
            Employees = new List<EmployeeForEstimateModel>();
            EmployeeOthers = new List<EmployeeLeasingModel>();
            EmployeeLeasings = new List<EmployeeLeasingModel>();
            FixedAssets = new List<FixedAssetForEstimateModel>();
            Buildings = new List<BuildingModel>();
            EstimateDetailStatementFixedAssets = new List<EstimateDetailStatementFixedAssetModel>();
            Mutuals = new List<MutualModel>();
            FixedAssetCars = new List<FixedAssetModel>();

            
        }

        /// <summary>
        /// Gets or sets the employees.
        /// </summary>
        /// <value>
        /// The employees.
        /// </value>
        public IList<EmployeeForEstimateModel> Employees { get; set; }

        /// <summary>
        /// Gets or sets the employee others.
        /// </summary>
        /// <value>
        /// The employee others.
        /// </value>
        public IList<EmployeeLeasingModel> EmployeeOthers { get; set; }

        /// <summary>
        /// Gets or sets the employee leasings.
        /// </summary>
        /// <value>
        /// The employee leasings.
        /// </value>
        public IList<EmployeeLeasingModel> EmployeeLeasings { get; set; }

        /// <summary>
        /// Gets or sets the fixed assets.
        /// </summary>
        /// <value>
        /// The fixed assets.
        /// </value>
        public IList<FixedAssetForEstimateModel> FixedAssets { get; set; }

        /// <summary>
        /// Gets or sets the buildings.
        /// </summary>
        /// <value>
        /// The buildings.
        /// </value>
        public IList<BuildingModel> Buildings { get; set; }

        /// <summary>
        /// Gets or sets the estimate detail statement part bs.
        /// </summary>
        /// <value>
        /// The estimate detail statement part bs.
        /// </value>
        public IList<EstimateDetailStatementPartBModel> EstimateDetailStatementPartBs { get; set; }

        public IList<EstimateDetailStatementFixedAssetModel> EstimateDetailStatementFixedAssets { get; set; }

        public IList<MutualModel> Mutuals { get; set; }

        public IList<FixedAssetModel> FixedAssetCars { get; set; }
    }
}
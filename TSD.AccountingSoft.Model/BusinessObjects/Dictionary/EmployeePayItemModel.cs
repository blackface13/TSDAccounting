/***********************************************************************
 * <copyright file="EmployeePayItemModel.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 07 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

namespace TSD.AccountingSoft.Model.BusinessObjects.Dictionary
{
    /// <summary>
    /// EmployeePayItemModel
    /// </summary>
    public class EmployeePayItemModel
    {
        /// <summary>
        /// Gets or sets the employee pay item identifier.
        /// </summary>
        /// <value>
        /// The employee pay item identifier.
        /// </value>
        public int EmployeePayItemId { get; set; }

        /// <summary>
        /// Gets or sets the pay item identifier.
        /// </summary>
        /// <value>
        /// The pay item identifier.
        /// </value>
        public int PayItemId { get; set; }

        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>
        /// The employee identifier.
        /// </value>
        public int EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets the salary ratio.
        /// </summary>
        /// <value>
        /// The salary ratio.
        /// </value>
        public float SalaryRatio { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public decimal Amount { get; set; }
    }
}

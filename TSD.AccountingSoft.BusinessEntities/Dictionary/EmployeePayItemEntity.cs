/***********************************************************************
 * <copyright file="EmployeePayItemEntity.cs" company="BUCA JSC">
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

namespace TSD.AccountingSoft.BusinessEntities.Dictionary
{
    /// <summary>
    /// EmployeePayItemEntity
    /// </summary>
    public class EmployeePayItemEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeePayItemEntity"/> class.
        /// </summary>
        public EmployeePayItemEntity() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeePayItemEntity"/> class.
        /// </summary>
        /// <param name="employeePayItemId">The employee pay item identifier.</param>
        /// <param name="payItemId">The pay item identifier.</param>
        /// <param name="employeeId">The employee identifier.</param>
        /// <param name="salaryRatio">The salary ratio.</param>
        /// <param name="amount">The amount.</param>
        /// <param name="amountExchange">The amountExchange.</param>
        public EmployeePayItemEntity(int employeePayItemId, int payItemId, int employeeId, float salaryRatio, decimal amount,decimal amountExchange)
            :this()
        {
            EmployeePayItemId = employeePayItemId;
            PayItemId = payItemId;
            EmployeeId = employeeId;
            SalaryRatio = salaryRatio;
            Amount = amount;
            AmountExchange = amountExchange;
        }

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

        public decimal AmountExchange { get; set; }

        
    }
}

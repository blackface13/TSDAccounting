using System.Collections.Generic;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;

namespace TSD.AccountingSoft.Model.BusinessObjects.Salary
{
    /// <summary>
    /// Class SalaryModel.
    /// </summary>
    public class SalaryModel
    {
        /// <summary>
        /// Gets or sets the employee payroll identifier.
        /// </summary>
        /// <value>The employee payroll identifier.</value>
        public long EmployeePayrollId { get; set; }
        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>The amount.</value>
        public decimal TotalAmountOc { get; set; } 
        /// <summary>
        /// Gets or sets the reference type identifier.
        /// </summary>
        /// <value>The reference type identifier.</value>
        public int RefTypeId { get; set; }
        /// <summary>
        /// Gets or sets the reference no.
        /// </summary>
        /// <value>The reference no.</value>
        public string RefNo { get; set; }
        /// <summary>
        /// Gets or sets the reference date.
        /// </summary>
        /// <value>The reference date.</value>
        public string RefDate { get; set; }
        /// <summary>
        /// Gets or sets the posted date.
        /// </summary>
        /// <value>The posted date.</value>
        public string PostedDate { get; set; }
        /// <summary>
        /// Gets or sets the currency code.
        /// </summary>
        /// <value>The currency code.</value>
        public string CurrencyCode { get; set; }
        /// <summary>
        /// Gets or sets the journal memo.
        /// </summary>
        /// <value>The journal memo.</value>
        public string JournalMemo { get; set; }
        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>The employee identifier.</value>
        public int EmployeeId { get; set; }
        /// <summary>
        /// Gets or sets the employee pay item identifier.
        /// </summary>
        /// <value>The employee pay item identifier.</value>
      //  public int EmployeePayItemId { get; set; }
        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>The amount.</value>
        public decimal TotalAmountExchange { get; set; }  
      
        /// <summary>
        /// Gets or sets the exchange rate.
        /// </summary>
        /// <value>The exchange rate.</value>
        public decimal ExchangeRate { get; set; }

         /// <summary>
         /// Sets the employees.
         /// </summary>
         /// <value>
         /// The employees.
         /// </value>
        // IList<EmployeeModel> Employees { get; } //get no set

         /// <summary>
         /// Sets the employees.
         /// </summary>
         /// <value>
         /// The employees.
         /// </value>
        public IList<EmployeeModel> Employees { get; set; } //get no set
    }
}

using System.Collections.Generic;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;

namespace TSD.AccountingSoft.View.Salary
{
   public interface ISalaryView
    {
        /// <summary>
        /// Gets or sets the employee payroll identifier.
        /// </summary>
        /// <value>The employee payroll identifier.</value>
         long EmployeePayrollId { get; set; }
        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>The amount.</value>
         decimal TotalAmountOc { get; }
         /// <summary>
         /// Gets or sets the amount.
         /// </summary>
         /// <value>The amount.</value>
         decimal TotalAmountExchange { get; }  
        /// <summary>
        /// Gets or sets the reference type identifier.
        /// </summary>
        /// <value>The reference type identifier.</value>
         int RefTypeId { get; set; }
        /// <summary>
        /// Gets or sets the reference no.
        /// </summary>
        /// <value>The reference no.</value>
         string RefNo { get; set; }
        /// <summary>
        /// Gets or sets the reference date.
        /// </summary>
        /// <value>The reference date.</value>
         string RefDate { get; set; }
        /// <summary>
        /// Gets or sets the posted date.
        /// </summary>
        /// <value>The posted date.</value>
         string PostedDate { get; set; }
        /// <summary>
        /// Gets or sets the currency code.
        /// </summary>
        /// <value>The currency code.</value>
         string CurrencyCodeSalary { get; set; } 
        /// <summary>
        /// Gets or sets the journal memo.
        /// </summary>
        /// <value>The journal memo.</value>
         string JournalMemo { get; set; }
        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>The employee identifier.</value>
         int EmployeeId { get; }
        /// <summary>
        /// Gets or sets the employee pay item identifier.
        /// </summary>
        /// <value>The employee pay item identifier.</value>
       //  int EmployeePayItemId { get; set; } 
        /// <summary>
        /// Gets or sets the department identifier.
        /// </summary>
        /// <value>The department identifier.</value>
    //    List<int> DepartmentId { get;  }
      
        /// <summary>
        /// Gets or sets the exchange rate.
        /// </summary>
        /// <value>The exchange rate.</value>
         decimal ExchangeRate { get; set; }

         /// <summary>
         /// Gets or sets the employee pay items.
         /// </summary>
         /// <value>
         /// The employee pay items.
         /// </value>
      // IList<EmployeePayItemModel> EmployeePayItems { get; set; }

         /// <summary>
         /// Sets the employees.
         /// </summary>
         /// <value>
         /// The employees.
         /// </value>
         IList<EmployeeModel> Employees { get; } //get no set
    }
}

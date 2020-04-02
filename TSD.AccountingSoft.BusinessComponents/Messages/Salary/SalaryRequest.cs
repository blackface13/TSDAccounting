using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Salary;

namespace TSD.AccountingSoft.BusinessComponents.Messages.Salary
{
    public class SalaryRequest : RequestBase
    {
        /// <summary>
        /// Gets or sets the Salary identifier.
        /// </summary>
        /// <value>
        /// The Salary identifier.
        /// </value>
        public int SalaryId { get; set; } 
        /// <summary>
        /// Gets or sets the Salary.
        /// </summary>
        /// <value>
        /// The Salary.
        /// </value>
        public SalaryEntity Salary { get; set; }

        public string CurrDate { get; set; }

        public string RefNo { get; set; }

        public string CurrencyCode { get; set; }
    }
}

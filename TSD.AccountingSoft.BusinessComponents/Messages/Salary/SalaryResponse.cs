using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Salary;

namespace TSD.AccountingSoft.BusinessComponents.Messages.Salary
{
    public class SalaryResponse : ResponseBase
    {
        /// <summary>
        /// Gets or sets the Salary identifier.
        /// </summary>
        /// <value>
        /// The Salary identifier.
        /// </value>
        public int SalaryId { get; set; }

        /// <summary>
        /// The Salary list
        /// </summary>
        public SalaryEntity Salary;

        /// <summary>
        /// The Salary lists
        /// </summary>
        public IList<SalaryEntity> Salaries; 
    }
}

/***********************************************************************
 * <copyright file="EmployeeRequest.cs" company="BUCA JSC">
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

using System;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Dictionary;


namespace TSD.AccountingSoft.BusinessComponents.Messages.Dictionary
{
    /// <summary>
    /// EmployeeRequest
    /// </summary>
    public class EmployeeRequest : RequestBase
    {
        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>
        /// The employee identifier.
        /// </value>
        public int EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets the department identifier.
        /// </summary>
        /// <value>
        /// The department identifier.
        /// </value>
        public int DepartmentId { get; set; }

        /// <summary>
        /// Gets or sets the list department identifier.
        /// </summary>
        /// <value>
        /// The list department identifier.
        /// </value>
        public DateTime RefdateSalary { get; set; }

        public string RefNo { get; set; } 

        /// <summary>
        /// Gets or sets the list department identifier.
        /// </summary>
        /// <value>
        /// The list department identifier.
        /// </value>
        public string ListDepartmentId { get; set; }

        public string MonthDate { get; set; }

        public int OptionType { get; set; }

        public int CalceType { get; set; }//1-Tròn tháng,2-Lẻ tháng,3-Cả hai

        public bool IsRetail { get; set; } // tham phục vụ lấy nhân viên tính lẻ lương

        public decimal ExchangeRate { get; set; }

        /// <summary>
        /// The employee
        /// </summary>
        public EmployeeEntity Employee;
    }
}

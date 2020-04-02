/***********************************************************************
 * <copyright file="EmployeeLeasingResponse.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 09 June 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Dictionary;
using System.Collections.Generic;


namespace TSD.AccountingSoft.BusinessComponents.Messages.Dictionary
{
    /// <summary>
    /// EmployeeLeasingResponse
    /// </summary>
    public class EmployeeLeasingResponse : ResponseBase
    {
        /// <summary>
        /// The employeeLeasings
        /// </summary>
        public IList<EmployeeLeasingEntity> EmployeeLeasings;

        /// <summary>
        /// The employeeLeasing
        /// </summary>
        public EmployeeLeasingEntity EmployeeLeasing;

        /// <summary>
        /// Gets or sets the employeeLeasing identifier.
        /// </summary>
        /// <value>
        /// The employeeLeasing identifier.
        /// </value>
        public int EmployeeLeasingId { get; set; }
    }
}

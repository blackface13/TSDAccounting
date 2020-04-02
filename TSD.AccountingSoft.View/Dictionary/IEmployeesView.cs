/***********************************************************************
 * <copyright file="IEmployeesView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 13 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;


namespace TSD.AccountingSoft.View.Dictionary
{
    /// <summary>
    /// IEmployeesView
    /// </summary>
    public interface IEmployeesView : IView
    {
        /// <summary>
        /// Sets the employees.
        /// </summary>
        /// <value>
        /// The employees.
        /// </value>
        IList<EmployeeModel> Employees { set; }
    }
}
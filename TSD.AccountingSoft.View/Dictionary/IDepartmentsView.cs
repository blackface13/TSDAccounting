/***********************************************************************
 * <copyright file="IDepartmentsView.cs" company="BUCA JSC">
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

using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using System.Collections.Generic;


namespace TSD.AccountingSoft.View.Dictionary
{
    /// <summary>
    /// IDepartmentsView
    /// </summary>
    public interface IDepartmentsView : IView
    {
        /// <summary>
        /// Sets the departments.
        /// </summary>
        /// <value>
        /// The departments.
        /// </value>
        IList<DepartmentModel> Departments { set; }
    }
}

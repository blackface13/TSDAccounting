/***********************************************************************
 * <copyright file="ICurrenciesView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuanHM
 * Email:    Tuanhm@buca.vn
 * Website:
 * Create Date: Friday, March 7, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using TSD.AccountingSoft.Model.BusinessObjects.Salary;


namespace TSD.AccountingSoft.View.Salary
{
    /// <summary>
    /// Interface ISalariesView
    /// </summary>
    public interface ISalariesView : IView  
    {
        /// <summary>
        /// Sets the Salaries.
        /// </summary>
        /// <value>The Salaries.</value>
        IList<SalaryModel> Salaries { set; }  
    }
}

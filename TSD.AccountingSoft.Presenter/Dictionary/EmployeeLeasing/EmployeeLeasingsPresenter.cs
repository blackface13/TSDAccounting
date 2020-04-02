/***********************************************************************
 * <copyright file="EmployeeLeasingsPresenter.cs" company="BUCA JSC">
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

using System.Collections.Generic;
using System.Linq;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.View.Dictionary;

namespace TSD.AccountingSoft.Presenter.Dictionary.EmployeeLeasing
{
    /// <summary>
    /// class EmployeeLeasingsPresenter
    /// </summary>
    public class EmployeeLeasingsPresenter : Presenter<IEmployeeLeasingsView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeLeasingsPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public EmployeeLeasingsPresenter(IEmployeeLeasingsView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            View.EmployeeLeasings = Model.GetEmployeeLeasings();
        }

        public List<EmployeeLeasingModel> GetEmployeeLeasings()
        {
            var employeeLeasings = Model.GetEmployeeLeasings().ToList();
            return employeeLeasings;
        }


        /// <summary>
        /// Displays the specified is leasing.
        /// </summary>
        /// <param name="isLeasing">if set to <c>true</c> [is leasing].</param>
        public void Display(bool isLeasing)
        {
            View.EmployeeLeasings = Model.GetEmployeeLeasings(isLeasing);
        }

        public List<EmployeeLeasingModel> GetEmployeeLeasings(bool isLeasing)
        {
            var employeeLeasings = Model.GetEmployeeLeasings(isLeasing).ToList();
            return employeeLeasings;
        }
        /// <summary>
        /// Displays the active.
        /// </summary>
        public void DisplayActive()
        {
            View.EmployeeLeasings = Model.GetEmployeeLeasingsActive();
        }
    }
}

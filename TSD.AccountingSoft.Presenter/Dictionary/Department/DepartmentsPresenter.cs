/***********************************************************************
 * <copyright file="DepartmentsPresenter.cs" company="BUCA JSC">
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

using TSD.AccountingSoft.View.Dictionary;


namespace TSD.AccountingSoft.Presenter.Dictionary.Department
{
    /// <summary>
    /// DepartmentsPresenter
    /// </summary>
    public class DepartmentsPresenter : Presenter<IDepartmentsView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DepartmentsPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public DepartmentsPresenter(IDepartmentsView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            View.Departments = Model.GetDepartments();
        }

        /// <summary>
        /// Displays the active.
        /// </summary>
        public void DisplayActive()
        {
            View.Departments = Model.GetDepartmentsActive();
        }
    }
}

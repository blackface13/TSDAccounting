/***********************************************************************
 * <copyright file="DepartmentPresenter.cs" company="BUCA JSC">
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
using TSD.AccountingSoft.View.Dictionary;


namespace TSD.AccountingSoft.Presenter.Dictionary.Department
{
    /// <summary>
    /// DepartmentPresenter
    /// </summary>
    public class DepartmentPresenter : Presenter<IDepartmentView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DepartmentPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public DepartmentPresenter(IDepartmentView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays the specified department identifier.
        /// </summary>
        /// <param name="departmentId">The department identifier.</param>
        public void Display(string departmentId)
        {
            if (departmentId == null) { View.DepartmentId = 0; return; }

            var department = Model.GetDepartment(int.Parse(departmentId));

            View.DepartmentId = department.DepartmentId;
            View.DepartmentCode = department.DepartmentCode;
            View.DepartmentName = department.DepartmentName;
            View.ParentId = department.ParentId;
            View.Description = department.Description;
            View.IsActive = department.IsActive;
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        public int Save()
        {
            var department = new DepartmentModel
            {
                DepartmentId = View.DepartmentId,
                DepartmentCode = View.DepartmentCode,
                DepartmentName = View.DepartmentName,
                ParentId  = View.ParentId,
                Description = View.Description,
                IsActive = View.IsActive
            };

            return View.DepartmentId == 0 ? Model.AddDepartment(department) : Model.UpdateDepartment(department);
        }

        /// <summary>
        /// Deletes the specified accont identifier.
        /// </summary>
        /// <param name="accontId">The accont identifier.</param>
        /// <returns></returns>
        public int Delete(int accontId)
        {
            return Model.DeleteDepartment(accontId);
        }
    }
}

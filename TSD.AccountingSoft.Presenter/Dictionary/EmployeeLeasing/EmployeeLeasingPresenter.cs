/***********************************************************************
 * <copyright file="EmployeeLeasingPresenter.cs" company="BUCA JSC">
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

using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.View.Dictionary;


namespace TSD.AccountingSoft.Presenter.Dictionary.EmployeeLeasing
{
    /// <summary>
    /// EmployeeLeasingPresenter
    /// </summary>
    public class EmployeeLeasingPresenter : Presenter<IEmployeeLeasingView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeLeasingPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public EmployeeLeasingPresenter(IEmployeeLeasingView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays the specified employeeLeasing identifier.
        /// </summary>
        /// <param name="employeeLeasingId">The employeeLeasing identifier.</param>
        public void Display(string employeeLeasingId)
        {
            if (employeeLeasingId == null)
            {
                View.EmployeeLeasingId = 0; 
                return;
            }

            var employeeLeasing = Model.GetEmployeeLeasing(int.Parse(employeeLeasingId));

            View.EmployeeLeasingId = employeeLeasing.EmployeeLeasingId;
            View.EmployeeLeasingCode = employeeLeasing.EmployeeLeasingCode;
            View.EmployeeLeasingName = employeeLeasing.EmployeeLeasingName;
            View.JobCandidate = employeeLeasing.JobCandidate;
            View.StartDate = employeeLeasing.StartDate;
            View.EndDate = employeeLeasing.EndDate;
            View.Description = employeeLeasing.Description;
            View.IsActive = employeeLeasing.IsActive;
            View.InsurancePrice = employeeLeasing.InsurancePrice;
            View.SalaryPrice = employeeLeasing.SalaryPrice;
            View.UniformPrice = employeeLeasing.UniformPrice;
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        public int Save()
        {
            var employeeLeasing = new EmployeeLeasingModel
            {
                EmployeeLeasingId = View.EmployeeLeasingId,
                EmployeeLeasingCode = View.EmployeeLeasingCode,
                EmployeeLeasingName = View.EmployeeLeasingName,
                JobCandidate = View.JobCandidate,
                StartDate = View.StartDate,
                EndDate = View.EndDate,
                Description = View.Description,
                IsActive = View.IsActive,
                IsLeasing = View.IsLeasing,
                InsurancePrice = View.InsurancePrice,
                SalaryPrice = View.SalaryPrice,
                UniformPrice = View.UniformPrice
            };

            return View.EmployeeLeasingId == 0 ? Model.AddEmployeeLeasing(employeeLeasing) : Model.UpdateEmployeeLeasing(employeeLeasing);
        }

        /// <summary>
        /// Deletes the specified accont identifier.
        /// </summary>
        /// <param name="accountId">The accont identifier.</param>
        /// <returns></returns>
        public int Delete(int accountId)
        {
            return Model.DeleteEmployeeLeasing(accountId);
        }
    }
}

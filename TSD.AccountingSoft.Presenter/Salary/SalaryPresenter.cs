using System;
using TSD.AccountingSoft.Model.BusinessObjects.Salary;
using TSD.AccountingSoft.View.Salary;

namespace TSD.AccountingSoft.Presenter.Salary
{
    public class SalaryPresenter : Presenter<ISalaryView> 
    {
           /// <summary>
        /// Initializes a new instance of the <see cref="SalaryPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public SalaryPresenter(ISalaryView view)
            : base(view)
        {
        }
        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        public string GetRefNoSalary( string currentDate,string currencyCode) 
        {
            return Model.GetRefNoSalary(currentDate, currencyCode);
        }

        public bool CheckEmployeeInDateDay(string currentDate)
        {
            string refNo = Model.GetRefNoInEmployeePayroll(currentDate);
            if (refNo != null && refNo != "")
                return true;
            return false;
        }

        public bool SararyExistRefNoInDay(string currentDate,string refNo)
        {
            string refNo1 = Model.SararyExistRefNoInDay(currentDate, refNo);
            if (refNo1 != null && refNo1 != "")
                return true;
            return false;
        }


        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        public int SavePostedSalary()
        {
            var model = new SalaryModel
            {
                EmployeePayrollId = View.EmployeePayrollId,
                RefTypeId = View.RefTypeId,
                RefNo = View.RefNo,
                RefDate = View.RefDate,
                TotalAmountOc = View.TotalAmountOc,
                PostedDate = View.PostedDate,
                CurrencyCode = View.CurrencyCodeSalary,
                JournalMemo = View.JournalMemo,
                EmployeeId = View.EmployeeId,
                ExchangeRate = View.ExchangeRate,
                TotalAmountExchange = View.TotalAmountExchange,
                Employees = View.Employees
            };
            return Model.SavePostedSalary(model);
        }

        public string GetPaymentDepositRefIdByefNo(string refNo)
        {
            var  depositModel=   Model.GetDeposit(refNo);
            if (depositModel != null) return (depositModel.RefId+"");
                return "0";
        }

        public string GetDepositForSalary(DateTime dataMonth)
        {
            var depositModel = Model.GetDepositForSalary(dataMonth);
            if (depositModel != null)
                return (depositModel.RefId+ "");
                return "0";
        }

        public string GetCashRefIdByefNo(string refNo)
        {
            var cash = Model.GetPaymentVoucher(refNo);
            if (cash != null) return (cash.RefId+"");
             return "0";
        }

        public string GetCashForSalary(DateTime dateMonth)
        {
            var cash = Model.GetCashForSalary(dateMonth);
            if (cash != null) return (cash.RefId + "");
                return "0";
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        public int SaveCalSalary() 
        {
        
                var salary = new SalaryModel
                    {
                        EmployeePayrollId = View.EmployeePayrollId,
                        RefTypeId = View.RefTypeId,
                        RefNo = View.RefNo,
                        RefDate = View.RefDate,
                        TotalAmountOc = View.TotalAmountOc,
                        PostedDate = View.PostedDate,
                        CurrencyCode = View.CurrencyCodeSalary,
                        JournalMemo = View.JournalMemo,
                        EmployeeId = View.EmployeeId,
                        ExchangeRate = View.ExchangeRate,
                        TotalAmountExchange = View.TotalAmountExchange,
                        Employees = View.Employees
                    };
                return Model.SaveCalSalary(salary);
            
        }

        public SalaryModel GetCalSalaryState(DateTime refDate, int employeeId)
        {
            var salary = new SalaryModel
            {
                EmployeePayrollId = View.EmployeePayrollId,
                RefTypeId = View.RefTypeId,
                RefNo = View.RefNo,
                RefDate = View.RefDate,
                TotalAmountOc = View.TotalAmountOc,
                PostedDate = View.PostedDate,
                CurrencyCode = View.CurrencyCodeSalary,
                JournalMemo = View.JournalMemo,
                EmployeeId = View.EmployeeId,
                ExchangeRate = View.ExchangeRate,
                TotalAmountExchange = View.TotalAmountExchange
            };
            return Model.GetCalSalaryState(salary);
        }

        /// <summary>
        /// Checks the state of the cal salary.
        /// </summary>
        /// <param name="refDate">The reference date.</param>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        public bool CheckCalSalaryState(DateTime refDate, int employeeId) 
        {
            var salary = new SalaryModel
            {
                EmployeePayrollId = View.EmployeePayrollId,
                RefTypeId = View.RefTypeId,
                RefNo = View.RefNo,
                RefDate = View.RefDate,
                TotalAmountOc = View.TotalAmountOc,
                PostedDate = View.PostedDate,
                CurrencyCode = View.CurrencyCodeSalary,
                JournalMemo = View.JournalMemo,
                EmployeeId = View.EmployeeId,
                ExchangeRate = View.ExchangeRate,
                TotalAmountExchange = View.TotalAmountExchange
            };
            return Model.CheckCalSalaryState(salary);
            
        }

        /// <summary>
        /// Checks the state of the cal salary.
        /// </summary>
        /// <param name="refDate">The reference date.</param>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        public bool CheckCalSalaryPostedState(DateTime refDate, int employeeId) 
        {


            var salary = new SalaryModel
            {
                EmployeePayrollId = View.EmployeePayrollId,
                RefTypeId = View.RefTypeId,
                RefNo = View.RefNo,
                RefDate = View.RefDate,
                TotalAmountOc = View.TotalAmountOc,
                PostedDate = View.PostedDate,
                CurrencyCode = View.CurrencyCodeSalary,
                JournalMemo = View.JournalMemo,
                EmployeeId = View.EmployeeId,
                ExchangeRate = View.ExchangeRate,
                TotalAmountExchange = View.TotalAmountExchange
            };
            return Model.CheckCalSalaryPostedState(salary);

        }


        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        public int DeleteCalSalary() 
        {
                                
            var salary = new SalaryModel
            {
                EmployeePayrollId = View.EmployeePayrollId,
                RefTypeId = View.RefTypeId,
                RefNo = View.RefNo,
                RefDate = View.RefDate,
                TotalAmountOc = View.TotalAmountOc,
                PostedDate = View.PostedDate,
                CurrencyCode = View.CurrencyCodeSalary,
                JournalMemo = View.JournalMemo,
                EmployeeId = View.EmployeeId,
                ExchangeRate = View.ExchangeRate,
                TotalAmountExchange = View.TotalAmountExchange,
                Employees = View.Employees
            };
            return Model.DeleteCalSalary(salary);
            
        }

   
    }
}

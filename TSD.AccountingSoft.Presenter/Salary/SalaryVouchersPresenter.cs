using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TSD.AccountingSoft.View;
using TSD.AccountingSoft.View.Salary;

namespace TSD.AccountingSoft.Presenter.Salary
{
  public  class SalaryVouchersPresenter:Presenter<ISalaryVouchersView> 
    {

      public SalaryVouchersPresenter(ISalaryVouchersView view) 
            : base(view)
        {
        }

        public void Display(string monthDate) //Lấy các chứng từ tính lương chưa ghi sổ
        {
            View.SalaryVouchers = Model.SalaryVoucherByMonthDate(monthDate);
        }

        public void DisplayPostedDate(string monthDate) //Lấy các chứng từ tính lương đã ghi sổ
        {
            View.SalaryVouchers = Model.SalaryVoucherByMonthDateIsPostedDate(monthDate);
        }


        public void Save(string monthDate,string refNo, int refTypeId)
        {
            var message = Model.SaveSalaryVoucher(monthDate, refNo, refTypeId);
        }

         // hủy tính lương
        public void CancelCalc(string monthDate, string refNo, int refTypeId)
        {
            var message = Model.CancelCalc(monthDate, refNo, refTypeId);
        }

         //Hủy Ghi sổ +tính lương
        public void SaveCancel(string monthDate, string refNo, int refTypeId)
        {
            var message = Model.CancelSalaryVoucher(monthDate, refNo, refTypeId);
        }

        public string  KeyCashFromSalary(string monthDate, string refNo, int refTypeId)
        {
            return Model.SalaryVoucherByCash(monthDate, refNo, refTypeId);
        }

        public string  KeyDepositFromSalary(string monthDate, string refNo, int refTypeId)
        {
            return Model.SalaryVoucherByDeposit(monthDate, refNo, refTypeId);
        }

        public long GetEmployeePayroll_VoucherID(string refNo, int refTypeId)
        {
            return Model.GetEmployeePayroll_VoucherID(refNo, refTypeId);
        }

        public void DisplayAllIsRetail(string monthDate,bool isRetail,int refTypeId) //Lấy tất cả chứng từ lương đã tính trong tháng
        {
            View.SalaryVouchers = Model.SalaryVoucherByMonthDateIsRetail(monthDate, isRetail, refTypeId);
        }


    }
}

using TSD.AccountingSoft.View.Salary;

namespace TSD.AccountingSoft.Presenter.Salary
{
    public class SalariesPresenter : Presenter<ISalariesView> 
    {
           /// <summary>
        /// Initializes a new instance of the <see cref="SalaryPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public SalariesPresenter(ISalariesView view) 
            : base(view)
        {
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            View.Salaries = Model.GetSalaryByMoth();
        }
      
    }
}

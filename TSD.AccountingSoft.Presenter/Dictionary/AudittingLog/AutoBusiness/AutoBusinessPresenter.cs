/***********************************************************************
 * <copyright file="AutoBusinessPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 24 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.View.Dictionary;


namespace TSD.AccountingSoft.Presenter.Dictionary.AutoBusiness
{
    /// <summary>
    /// AutoBusinessPresenter
    /// </summary>
    public class AutoBusinessPresenter : Presenter<IAutoBusinessView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AutoBusinessPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public AutoBusinessPresenter(IAutoBusinessView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays the specified autoBusiness identifier.
        /// </summary>
        /// <param name="autoBusinessId">The autoBusiness identifier.</param>
        public void Display(string autoBusinessId)
        {
            if (autoBusinessId == null) { View.AutoBusinessId = 0; return; }

            var autoBusiness = Model.GetAutoBusiness(int.Parse(autoBusinessId));

            View.AutoBusinessId = autoBusiness.AutoBusinessId;
            View.AutoBusinessCode = autoBusiness.AutoBusinessCode;
            View.AutoBusinessName = autoBusiness.AutoBusinessName;
            View.RefTypeId = autoBusiness.RefTypeId;
            View.VoucherTypeId = autoBusiness.VoucherTypeId;
            View.DebitAccountNumber = autoBusiness.DebitAccountNumber;
            View.CreditAccountNumber = autoBusiness.CreditAccountNumber;
            View.BudgetItemCode = autoBusiness.BudgetItemCode;
            View.BudgetSourceCode = autoBusiness.BudgetSourceCode;
            View.Description = autoBusiness.Description;
            View.CurrencyCode = autoBusiness.CurrencyCode;
            View.IsActive = autoBusiness.IsActive;
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        public int Save()
        {
            var autoBusiness = new AutoBusinessModel
            {
                AutoBusinessId = View.AutoBusinessId,
                AutoBusinessCode = View.AutoBusinessCode,
                AutoBusinessName = View.AutoBusinessName,
                RefTypeId = View.RefTypeId,
                VoucherTypeId = View.VoucherTypeId,
                DebitAccountNumber = View.DebitAccountNumber,
                CreditAccountNumber = View.CreditAccountNumber,
                BudgetItemCode = View.BudgetItemCode,
                BudgetSourceCode = View.BudgetSourceCode,
                Description = View.Description,
                CurrencyCode = View.CurrencyCode,
                IsActive = View.IsActive
            };

            return View.AutoBusinessId == 0 ? Model.AddAutoBusiness(autoBusiness) : Model.UpdateAutoBusiness(autoBusiness);
        }

        /// <summary>
        /// Deletes the specified autoBusiness identifier.
        /// </summary>
        /// <param name="autoBusinessId">The autoBusiness identifier.</param>
        /// <returns></returns>
        public int Delete(int autoBusinessId)
        {
            return Model.DeleteAutoBusiness(autoBusinessId);
        }
    }
}

/***********************************************************************
 * <copyright file="PayItemPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 14 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.View.Dictionary;


namespace TSD.AccountingSoft.Presenter.Dictionary.PayItem
{
    /// <summary>
    /// PayItemPresenter
    /// </summary>
    public class PayItemPresenter : Presenter<IPayItemView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PayItemPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public PayItemPresenter(IPayItemView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays the specified pay item identifier.
        /// </summary>
        /// <param name="payItemId">The pay item identifier.</param>
        public void Display(string payItemId)
        {
            if (payItemId == null) { View.PayItemId = 0; return; }

            var payItem = Model.GetPayItem(int.Parse(payItemId));

            View.PayItemId = payItem.PayItemId;
            View.PayItemCode = payItem.PayItemCode;
            View.PayItemName = payItem.PayItemName;
            View.Type = payItem.Type;
            View.IsCalculateRatio = payItem.IsCalculateRatio;
            View.IsSocialInsurance = payItem.IsSocialInsurance;
            View.IsCareInsurance = payItem.IsCareInsurance;
            View.IsTradeUnionFee = payItem.IsTradeUnionFee;
            View.Description = payItem.Description;
            View.DebitAccountCode = payItem.DebitAccountCode;
            View.CreditAccountCode = payItem.CreditAccountCode;
            View.BudgetChapterCode = payItem.BudgetChapterCode;
            View.IsDefault = payItem.IsDefault;
            View.IsActive = payItem.IsActive;
            View.BudgetSourceCode = payItem.BudgetSourceCode;
            View.BudgetCategoryCode = payItem.BudgetCategoryCode;
            View.BudgetGroupCode = payItem.BudgetGroupCode;
            View.BudgetItemCode = payItem.BudgetItemCode;
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        public int Save()
        {
            var payItem = new PayItemModel
            {
                PayItemId = View.PayItemId,
                PayItemCode = View.PayItemCode,
                PayItemName = View.PayItemName,
                Type = View.Type,
                IsCalculateRatio = View.IsCalculateRatio,
                IsSocialInsurance = View.IsSocialInsurance,
                IsCareInsurance = View.IsCareInsurance,
                IsTradeUnionFee = View.IsTradeUnionFee,
                Description = View.Description,
                DebitAccountCode = View.DebitAccountCode,
                CreditAccountCode = View.CreditAccountCode,
                BudgetChapterCode = View.BudgetChapterCode,
                IsDefault = View.IsDefault,
                IsActive = View.IsActive,
                BudgetSourceCode = View.BudgetSourceCode,
                BudgetCategoryCode = View.BudgetCategoryCode,
                BudgetGroupCode = View.BudgetGroupCode,
                BudgetItemCode = View.BudgetItemCode,
            };

            return View.PayItemId == 0 ? Model.AddPayItem(payItem) : Model.UpdatePayItem(payItem);
        }

        /// <summary>
        /// Deletes the specified pay item identifier.
        /// </summary>
        /// <param name="payItemId">The pay item identifier.</param>
        /// <returns></returns>
        public int Delete(int payItemId)
        {
            return Model.DeletePayItem(payItemId);
        }
    }
}

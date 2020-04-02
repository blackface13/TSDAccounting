using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.View.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.Presenter.Dictionary.AutoBusinessParallel
{
    public class AutoBusinessParallelPresenter : Presenter<IAutoBusinessParallelView>
    {
        public AutoBusinessParallelPresenter(IAutoBusinessParallelView view)
            : base(view)
        {
        }

        public void Display(int autoBusinessId)
        {
            if (autoBusinessId == 0)
            {
                return;
            }

            var autoBusinessParallel = Model.GetAutoBusinessParallel(autoBusinessId);
            View.AutoBusinessParallelId = autoBusinessParallel.AutoBusinessParallelId;
            View.AutoBusinessCode = autoBusinessParallel.AutoBusinessCode;
            View.AutoBusinessName = autoBusinessParallel.AutoBusinessName;
            View.Description = autoBusinessParallel.Description;
            View.IsActive = autoBusinessParallel.IsActive;
            View.DebitAccount = autoBusinessParallel.DebitAccount;
            View.CreditAccount = autoBusinessParallel.CreditAccount;
            View.BudgetSourceId = autoBusinessParallel.BudgetSourceId;
            View.BudgetItemId = autoBusinessParallel.BudgetItemId;
            View.BudgetSubItemId = autoBusinessParallel.BudgetSubItemId;
            View.VoucherTypeId = autoBusinessParallel.VoucherTypeId;
            View.DebitAccountParallel = autoBusinessParallel.DebitAccountParallel;
            View.CreditAccountParallel = autoBusinessParallel.CreditAccountParallel;
            View.BudgetSourceIdParallel = autoBusinessParallel.BudgetSourceIdParallel;
            View.BudgetItemIdParallel = autoBusinessParallel.BudgetItemIdParallel;
            View.BudgetSubItemIdParallel = autoBusinessParallel.BudgetSubItemIdParallel;
            View.VoucherTypeIdParallel = autoBusinessParallel.VoucherTypeIdParallel;
            View.SortOrder = autoBusinessParallel.SortOrder;
            View.IsNegative = autoBusinessParallel.IsNegative;
        }
        public int Save()
        {
            var autoBusiness = new AutoBusinessParallelModel();
            {
                autoBusiness.AutoBusinessParallelId = View.AutoBusinessParallelId;
                autoBusiness.AutoBusinessCode = View.AutoBusinessCode;
                autoBusiness.AutoBusinessName = View.AutoBusinessName;
                autoBusiness.Description = View.Description;
                autoBusiness.IsActive = View.IsActive;
                autoBusiness.DebitAccount = View.DebitAccount;
                autoBusiness.CreditAccount = View.CreditAccount;
                autoBusiness.BudgetSourceId = View.BudgetSourceId;
                autoBusiness.BudgetItemId = View.BudgetItemId;
                autoBusiness.BudgetSubItemId = View.BudgetSubItemId;
                autoBusiness.VoucherTypeId = View.VoucherTypeId;
                autoBusiness.DebitAccountParallel = View.DebitAccountParallel;
                autoBusiness.CreditAccountParallel = View.CreditAccountParallel;
                autoBusiness.BudgetSourceIdParallel = View.BudgetSourceIdParallel;
                autoBusiness.BudgetItemIdParallel = View.BudgetItemIdParallel;
                autoBusiness.BudgetSubItemIdParallel = View.BudgetSubItemIdParallel;
                autoBusiness.VoucherTypeIdParallel = View.VoucherTypeIdParallel;
                autoBusiness.SortOrder = View.SortOrder;
                autoBusiness.IsNegative = View.IsNegative;
            };

            return View.AutoBusinessParallelId == 0 ? Model.AddAutoBusinessParallel(autoBusiness) : Model.UpdateAutoBusinessParallel(autoBusiness);
        }
        public int Delete(int autoBusinessId)
        {
            return Model.DeleteAutoBusinessParallel(autoBusinessId);
        }
    }
}

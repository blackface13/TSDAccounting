using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.View.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.Presenter.Dictionary.AccountingObjectCategory
{
    public class AccountingObjectCategoriesPresenter : Presenter<IAccountingObjectCategoriesView>
    {
        public AccountingObjectCategoriesPresenter(IAccountingObjectCategoriesView view)
            : base(view)
        {
        }

        public void Display()
        {
            View.AccountingObjectCategories = Model.GetAccountingObjectCategories();
        }

        public void DisplayActive(bool isActive)
        {
            var lstAccountingObjectCategories = Model.GetAccountingObjectCategories() ?? new List<AccountingObjectCategoryModel>();
            View.AccountingObjectCategories = lstAccountingObjectCategories.Where(w => w.IsActive = isActive).ToList();
        }
    }
}

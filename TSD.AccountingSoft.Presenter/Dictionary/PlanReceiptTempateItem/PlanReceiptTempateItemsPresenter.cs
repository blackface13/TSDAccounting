using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TSD.AccountingSoft.View.Dictionary;

namespace TSD.AccountingSoft.Presenter.Dictionary.PlanReceiptTempateItem
{
    public class PlanReceiptTempateItemsPresenter : Presenter<IPlanReceiptTempateItemsView>
    {
       public PlanReceiptTempateItemsPresenter(IPlanReceiptTempateItemsView view)
            : base(view)
        {
        }

       public void PlanReceiptTempateItems()
       {
           View.PlanReceiptTempateItems = Model.GetBudgetItemsByReceipt();
       }

    }
}

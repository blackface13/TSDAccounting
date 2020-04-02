using TSD.AccountingSoft.View.Tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.Presenter.Tool
{
    public class SUIncrementDecrementsPresenter : Presenter<ISUIncrementDecrementsView>
    {
        public SUIncrementDecrementsPresenter(ISUIncrementDecrementsView view) : base(view)
        {
        }

        public void Display()
        {
            View.SUIncrementDecrementModels = Model.GetSUIncrementDecrements();
        }

        public void Display(int refTypeId, DateTime PostedDate)
        {
            //View.SUIncrementDecrementModels = Model.GetSUIncrementDecrements();
            View.SUIncrementDecrementModels = Model.GetSUIncrementDecrementsByRefTypeId(refTypeId);
        }

        public void Display(int refType)
        {
            View.SUIncrementDecrementModels = Model.GetSUIncrementDecrementsByRefTypeId(refType);
        }

        public void DisplayVoucherDetail(long refId)
        {
            View.SUIncrementDecrement = Model.GetSUIncrementDecrement(refId, true);
        }
    }
}

using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.View.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.Presenter.Dictionary.AutoBusinessParallel
{
    public class AutoBusinessParallelsPresenter : Presenter<IAutoBusinessParallelsView>
    {
        public AutoBusinessParallelsPresenter(IAutoBusinessParallelsView view)
            : base(view)
        {
        }

        public void Display()
        {
            View.AutoBusinessParallels = Model.GetAutoBusinessParallels();
        }

        public void DisplayActive()
        {
            View.AutoBusinessParallels = Model.GetAutoBusinessParallelsActive();
        }

        public IList<AutoBusinessParallelModel> GetAutoBusinessParallels()
        {
            return Model.GetAutoBusinessParallels();
        }

        
    }
}

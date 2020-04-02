using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;

namespace TSD.AccountingSoft.View.Dictionary
{
    public interface IAutoBusinessParallelsView : IView
    {
        IList<AutoBusinessParallelModel> AutoBusinessParallels { set; }
    }
}

using TSD.AccountingSoft.Model.BusinessObjects.Tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.View.Tool
{
    public interface ISUIncrementDecrementsView : IView
    {
        IList<SUIncrementDecrementModel> SUIncrementDecrementModels { set; }

        SUIncrementDecrementModel SUIncrementDecrement { set; }
    }
}

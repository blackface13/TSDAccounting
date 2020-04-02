using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.View.Dictionary
{
    public interface IActivitysView : IView
    {
        IList<ActivityModel> Activitys { set; }
    }
}

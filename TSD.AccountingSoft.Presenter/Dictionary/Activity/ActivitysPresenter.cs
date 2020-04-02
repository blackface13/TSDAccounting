using TSD.AccountingSoft.View.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.Presenter.Dictionary.Activity
{
    public class ActivitysPresenter : Presenter<IActivitysView>
    {
        public ActivitysPresenter(IActivitysView view)
            : base(view)
        {
        }

        public void Display()
        {
            View.Activitys = Model.GetActivitys();
        }

        /// <summary>
        /// Displays the active.
        /// </summary>
        public void DisplayActive(bool isActive)
        {
            View.Activitys = Model.GetActivitysActive(isActive);
        }
    }
}

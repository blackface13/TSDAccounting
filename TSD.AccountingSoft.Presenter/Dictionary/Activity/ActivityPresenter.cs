using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.View.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.Presenter.Dictionary.Activity
{
    public class ActivityPresenter : Presenter<IActivityView>
    {
        public ActivityPresenter(IActivityView view)
            : base(view)
        {
        }

        public void Display(int activityId)
        {
            var activity = Model.GetActivity(activityId) ?? new TSD.AccountingSoft.Model.BusinessObjects.Dictionary.ActivityModel();

            View.ActivityId = activity.ActivityId;
            View.ActivityCode = activity.ActivityCode;
            View.ActivityName = activity.ActivityName;
            View.ParentID = activity.ParentID;
            View.IsActive = activity.IsActive;
            View.IsSystem = activity.IsSystem;
            View.IsParent = activity.IsParent;
            View.Grade = activity.Grade;
        }

        public int Save()
        {
            var activity = new ActivityModel
            {
                ActivityId = View.ActivityId,
                ActivityCode = View.ActivityCode,
                ActivityName = View.ActivityName,
                ParentID = View.ParentID,
                IsActive = View.IsActive,
                Grade = View.Grade,
                IsParent = View.IsParent,
                IsSystem = View.IsSystem
            };

            return activity.ActivityId == 0 ? Model.AddActivity(activity) : Model.UpdateActivity(activity);
        }

        public int Delete(int activityId)
        {
            return Model.DeleteActivity(activityId);
        }
        public bool CodeIsExist(int activityId, string activityCode)
        {
            var activity = Model.GetActivitys().Where(x => x.ActivityId  != activityId && x.ActivityCode == activityCode).ToList();
            return activity.Any();
        }
    }
}

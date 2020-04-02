using TSD.AccountingSoft.BusinessEntities.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary
{
    public interface IActivityDao
    {
        ActivityEntity GetActivity(int activityId);
        List<ActivityEntity> GetActivitys();
        List<ActivityEntity> GetActivitysByActive(bool isActive);
        List<ActivityEntity> GetActivityByCode(string activityCode);
        int InsertActivity(ActivityEntity activity);
        string UpdateActivity(ActivityEntity activity);
        string DeleteActivity(ActivityEntity activity);

        string DeleteActivityConvert();
    }
}

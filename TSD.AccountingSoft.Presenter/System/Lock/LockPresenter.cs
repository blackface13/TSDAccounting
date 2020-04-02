
using System;
using TSD.AccountingSoft.Model.BusinessObjects.System;
using TSD.AccountingSoft.View.System;

namespace TSD.AccountingSoft.Presenter.System.Lock
{
   public class LockPresenter: Presenter<ILockView>
    {
       public LockPresenter(ILockView view)
            : base(view)
        {

        }
       public void Display()
       {
           var site = Model.GetLock();
           View.Content = site.Content;
           View.IsLock = site.IsLock;
           View.LockDate = site.LockDate;

       }

       public string Save()
       {
           var model = new LockModel
           {
                Content = View.Content,
                LockDate = View.LockDate,
                IsLock = View.IsLock
           };
           return Model.SaveLock(model);
       }

       public bool CheckLockDate (int refId,int refTypeId)
       {
           var obj= Model.CheckLock(refId, refTypeId);
           return obj.IsLock;
       }

       public bool CheckLockDate(int refId, int refTypeId,DateTime refDate)
       {
           var obj = Model.CheckLock(refId, refTypeId, refDate);
           return obj.IsLock;
       }

    }
}

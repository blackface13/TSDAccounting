/***********************************************************************
 * <copyright file="ISiteDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: 25 October 2016
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using TSD.AccountingSoft.BusinessEntities.System;
namespace TSD.AccountingSoft.DataAccess.IEntitiesDao.System
{
    /// <summary>
    /// ISiteDao
    /// </summary>
    public interface ILockDao
    {

        LockEntity GetLock();

        string ExcuteUnLock(LockEntity entity);

        LockEntity CheckLock(int refId, int refTypeId, DateTime refDate);

        LockEntity CheckLock(int refId, int refTypeId);
    }
}

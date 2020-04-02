/***********************************************************************
 * <copyright file="SiteFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 25 October 2016
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Linq;
using TSD.AccountingSoft.BusinessComponents.Messages.System;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.System;


namespace TSD.AccountingSoft.BusinessComponents.Facade.System
{
    /// <summary>
    /// class LockFacade
    /// </summary>
    public class LockFacade
    {
        private static readonly ILockDao LockDao = DataAccess.DataAccess.LockDao;


        public LockResponse GetLock(LockRequest request)
        {
            var response = new LockResponse();

            if (request.LoadOptions.Contains("Get"))
            {
                response.Lock = LockDao.GetLock();
            }
            if (request.LoadOptions.Contains("CheckPostedDate"))
            {
                response.Lock = LockDao.CheckLock(request.RefId, request.RefTypeId,request.RefDate);
            }

            if (request.LoadOptions.Contains("CheckRefID"))
            {
                response.Lock = LockDao.CheckLock(request.RefId, request.RefTypeId);
            }

            return response;
        }

        /// <summary>
        /// Sets the sites.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public LockResponse SetLock(LockRequest request)
        {
            var response = new LockResponse();

            if (request.LoadOptions.Contains("ExcuteLock"))
            {
                response.Message = LockDao.ExcuteUnLock(request.Lock);
            }

            return response;
        }
    }
}

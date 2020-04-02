/***********************************************************************
 * <copyright file="SiteRequest.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 24 october 2016
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.System;


namespace TSD.AccountingSoft.BusinessComponents.Messages.System
{
    /// <summary>
    /// class SiteRequest 
    /// </summary>
    public class LockRequest : RequestBase
    {
        public LockEntity Lock;

        public int RefId;

        public int RefTypeId;

        public DateTime RefDate;


    }
}

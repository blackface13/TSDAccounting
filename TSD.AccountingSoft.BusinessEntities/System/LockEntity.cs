/***********************************************************************
 * <copyright file="SiteEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 22 May 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using TSD.AccountingSoft.BusinessEntities.BusinessRules;


namespace TSD.AccountingSoft.BusinessEntities.System
{
    /// <summary>
    /// SiteEntity
    /// </summary>
    public class LockEntity : BusinessEntities
    {
        public LockEntity()
        {
        }


        public LockEntity(string content, DateTime lockDate, bool isLock)
            : this()
        {
            Content = content;
            LockDate = lockDate;
            IsLock = isLock;

        }

        public string Content { get; set; }

        public DateTime LockDate { get; set; }

        public bool IsLock { get; set; }

      
    }
}

/***********************************************************************
 * <copyright file="SiteModel.cs" company="BUCA JSC">
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
namespace TSD.AccountingSoft.Model.BusinessObjects.System
{
    /// <summary>
    /// class LockModel
    /// </summary>
    public class LockModel
    {
        public string Content { get; set; }

        public DateTime LockDate { get; set; }

        public bool IsLock { get; set; }

    }
}

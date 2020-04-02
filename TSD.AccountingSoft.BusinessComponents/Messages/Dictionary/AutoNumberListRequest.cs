/***********************************************************************
 * <copyright file="BuildingRequest.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: 10 June 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Dictionary;

namespace TSD.AccountingSoft.BusinessComponents.Messages.Dictionary
{
    public class AutoNumberListRequest : RequestBase
    {

        public string  TableCode { get; set; }

        public AutoNumberListEntity AutoNumberList;

        public IList<AutoNumberListEntity> AutoNumberLists;


    }
}

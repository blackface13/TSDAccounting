/***********************************************************************
 * <copyright file="IStockDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: Friday, March 14, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using TSD.AccountingSoft.BusinessEntities.Dictionary;

namespace TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary
{
    public interface IAutoNumberListDao
    {

        AutoNumberListEntity GetAutoNumberList(string tableCode);

        List<AutoNumberListEntity> GetAutoNumberLists();

        string UpdateAutoNumberList(AutoNumberListEntity autoNumberList);

        void UpdateIncreateAutoNumberListByValue(string tableCode);

    }
}

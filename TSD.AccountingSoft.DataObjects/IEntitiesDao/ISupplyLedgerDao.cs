/***********************************************************************
 * <copyright file="SUIncrementDecrementDetailEntity.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Tudt
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: November 20, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date    20/11/2017     Author       tudt        Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using TSD.AccountingSoft.BusinessEntities.Business;

namespace TSD.AccountingSoft.DataAccess.IEntitiesDao
{
    public interface ISupplyLedgerDao
    {
        SupplyLedgerEntity GetSupplyLedgerByRefId(long refId, int refTypeId);
        SupplyLedgerEntity GetSupplyLedgerByInventoryItemId(int inventoryItemId, int refTypeId);
        List<SupplyLedgerEntity> GetSupplyLedgerByInventoryItemId(int inventoryItemId);
        long InsertSupplyLedger(SupplyLedgerEntity supplyLedger);
        string DeleteSupplyLedgerByRefId(long refId, int refTypeId);
        string DeleteSupplyLedgerByRefId(long refId);
        string DeleteSupplyLedgerByOPN();
        string DeleteSupplyLedgerByInventoryItemId(int inventoryItemId, int refTypeId);
    }
}

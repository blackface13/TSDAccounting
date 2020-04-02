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

using System;
using System.Collections.Generic;
using System.Data;
using TSD.AccountingSoft.BusinessEntities.Business;
using TSD.AccountingSoft.DataAccess.IEntitiesDao;
using TSD.AccountingSoft.DataHelpers;

namespace TSD.AccountingSoft.DataAccess.SqlServer
{
    public class SqlServerSupplyLedgerDao : ISupplyLedgerDao
    {
        public SupplyLedgerEntity GetSupplyLedgerByRefId(long refId, int refTypeId)
        {
            throw new NotImplementedException();
        }

        public SupplyLedgerEntity GetSupplyLedgerByInventoryItemId(int inventoryItemId, int refTypeId)
        {
            throw new NotImplementedException();
        }

        public List<SupplyLedgerEntity> GetSupplyLedgerByInventoryItemId(int inventoryItemId)
        {
            throw new NotImplementedException();
        }

        public long InsertSupplyLedger(SupplyLedgerEntity supplyLedger)
        {
            const string sql = @"uspInsert_SupplyLedger";
            return Db.Insert(sql, true, Take(supplyLedger));
        }

        public string DeleteSupplyLedgerByRefId(long refId, int refTypeId)
        {
            const string procedures = @"uspDelete_SupplyLedger_ByRefIDAndRefType";

            object[] parms = { "@RefID", refId, "@RefType", refTypeId };
            return Db.Delete(procedures, true, parms);
        }
        public string DeleteSupplyLedgerByRefId(long refId)
        {
            const string procedures = @"uspDelete_SupplyLedger_ByRefID";

            object[] parms = { "@RefID", refId};
            return Db.Delete(procedures, true, parms);
        }

        public string DeleteSupplyLedgerByOPN()
        {
            const string procedures = @"uspDelete_SupplyLedger_ByOPN";

            object[] parms = {};
            return Db.Delete(procedures, true, parms);
        }

        
        public string DeleteSupplyLedgerByInventoryItemId(int inventoryItemId, int refTypeId)
        {
            throw new NotImplementedException();
        }

        private static readonly Func<IDataReader, SupplyLedgerEntity> Make = reader => new SupplyLedgerEntity
        {
            SupplyLedgerId = reader["SupplyLedgerID"].AsLong(),
            RefId = reader["RefID"].AsLong(),
            RefDetailId = reader["RefDetailID"].AsLong(),
            RefType = reader["RefType"].AsInt(),
            RefNo = reader["RefNo"].AsString(),
            RefDate = reader["RefDate"].AsDateTime(),
            PostedDate = reader["PostedDate"].AsDateTime(),
            Description = reader["Description"].AsString(),
            JournalMemo = reader["JournalMemo"].AsString(),
            InventoryItemId = reader["InventoryItemID"].AsInt(),
            DepartmentId = reader["DepartmentID"].AsInt(),
            CurrencyCode = reader["CurrencyCode"].AsString(),
            ExchangeRate = reader["ExchangeRate"].AsDecimal(),
            Unit = reader["Unit"].AsString(),
            Quantity = reader["Quantity"].AsDecimal(),
            UnitPriceOc = reader["UnitPriceOc"].AsDecimal(),
            UnitPriceExchange = reader["UnitPriceExchange"].AsDecimal(),
            AmountOc = reader["AmountOc"].AsDecimal(),
            AmountExchange = reader["AmountExchange"].AsDecimal()
        };

        private static object[] Take(SupplyLedgerEntity supplyLedgerEntity)
        {
            return new object[]  
            {
                "@SupplyLedgerID",supplyLedgerEntity.SupplyLedgerId,
                "@RefID",supplyLedgerEntity.RefId,
                "@RefDetailID",supplyLedgerEntity.RefDetailId,
                "@RefType",supplyLedgerEntity.RefType,
                "@RefNo",supplyLedgerEntity.RefNo,
                "@RefDate",supplyLedgerEntity.RefDate,
                "@PostedDate",supplyLedgerEntity.PostedDate,
                "@Description",supplyLedgerEntity.Description,
                "@JournalMemo",supplyLedgerEntity.JournalMemo,
                "@InventoryItemID",supplyLedgerEntity.InventoryItemId,
                "@DepartmentID",supplyLedgerEntity.DepartmentId,
                "@CurrencyCode",supplyLedgerEntity.CurrencyCode,
                "@ExchangeRate",supplyLedgerEntity.ExchangeRate,
                "@Unit",supplyLedgerEntity.Unit,
                "@Quantity",supplyLedgerEntity.Quantity,
                "@UnitPriceOc",supplyLedgerEntity.UnitPriceOc,
                "@UnitPriceExchange",supplyLedgerEntity.UnitPriceExchange,
                "@AmountOc",supplyLedgerEntity.AmountOc,
                "@AmountExchange",supplyLedgerEntity.AmountExchange,
            };
        }
    }
}

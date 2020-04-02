/***********************************************************************
 * <copyright file="SqlServerOpeningSupplyEntryDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   SonTV
 * Email:    SonTV@buca.vn
 * Website:
 * Create Date: Wednesday, January 3, 2018
 * Usage: 
 * 
 * RevisionHistory: 
 * DateWednesday, January 3, 2018Author SonTV  Description 
 * 
 * ************************************************************************/

using TSD.AccountingSoft.DataAccess.IEntitiesDao.Opening;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TSD.AccountingSoft.BusinessEntities.Business.Opening;
using System.Data;
using TSD.AccountingSoft.DataHelpers;

namespace TSD.AccountingSoft.DataAccess.SqlServer.Opening
{
    public class SqlServerOpeningSupplyEntryDao : DaoBase, IOpeningSupplyEntryDao
    {
        public OpeningSupplyEntryEntity GetOpeningSupplyEntrybyRefId(long refId)
        {
            const string procedures = @"uspGet_OpeningSupplyEntry_ByRefId";
            object[] parms = { "@RefId", refId };
            return Db.Read(procedures, true, Make, parms);
        }

        public List<OpeningSupplyEntryEntity> GetOpeningSupplyEntry()
        {
            const string procedures = @"uspGet_All_OpeningSupplyEntry";
            return Db.ReadList(procedures, true, Make<OpeningSupplyEntryEntity>);
        }

        public OpeningSupplyEntryEntity GetOpeningSupplyEntrybyRefNo(string refNo)
        {
            const string procedures = @"uspGet_OpeningSupplyEntry_ByRefNo";
            object[] parms = { "@RefNo", refNo };
            return Db.Read(procedures, true, Make, parms);
        }

        public List<OpeningSupplyEntryEntity> GetOpeningSupplyEntrysByRefTypeId(int refTypeId)
        {
            const string procedures = @"uspGet_OpeningSupplyEntry_ByRefType";
            object[] parms = { "@RefType", refTypeId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        public long InsertOpeningSupplyEntry(OpeningSupplyEntryEntity openingCommitment)
        {
            const string procedures = @"uspInsert_OpeningSupplyEntry";
            return Db.Insert(procedures, true, Take(openingCommitment));
        }

        public string UpdateOpeningSupplyEntry(OpeningSupplyEntryEntity openingCommitment)
        {
            const string procedures = @"uspUpdate_OpeningSupplyEntry";
            return Db.Update(procedures, true, Take(openingCommitment));
        }

        public string DeleteOpeningSupplyEntry(OpeningSupplyEntryEntity openingCommitment)
        {
            const string procedures = @"uspDelete_OpeningSupplyEntry";
            object[] parms = { "@RefId", openingCommitment.RefId };
            return Db.Delete(procedures, true, parms);
        }

        public string DeleteOpeningSupplyEntry(long refId)
        {
            const string procedures = @"uspDelete_OpeningSupplyEntry";
            object[] parms = { "@RefId", refId };
            return Db.Delete(procedures, true, parms);
        }

        public string DeleteOpeningSupplyEntries()
        {
            const string procedures = @"uspDelete_OpeningSupplyEntries";
            object[] parms = {};
            return Db.Delete(procedures, true, parms);
        }

        #region Make & Take

        private static object[] Take(OpeningSupplyEntryEntity openingSupplyEntryEntity)
        {
            return new object[]
            {
                "@RefID",openingSupplyEntryEntity.RefId,
                "@RefType",openingSupplyEntryEntity.RefType,
                "@PostedDate",openingSupplyEntryEntity.PostedDate,
                "@RefDate",openingSupplyEntryEntity.RefDate,
                "@CurrencyCode",openingSupplyEntryEntity.CurrencyCode,
                "@ExchangeRate",openingSupplyEntryEntity.ExchangeRate,
                "@AccountNumber",openingSupplyEntryEntity.AccountNumber,
                "@InventoryItemID",openingSupplyEntryEntity.InventoryItemId,
                "@DepartmentID",openingSupplyEntryEntity.DepartmentId,
                "@Quantity",openingSupplyEntryEntity.Quantity,
                "@UnitPriceOc",openingSupplyEntryEntity.UnitPriceOc,
                "@UnitPriceExchange",openingSupplyEntryEntity.UnitPriceExchange,
                "@AmountOc",openingSupplyEntryEntity.AmountOc,
                "@AmountExchange",openingSupplyEntryEntity.AmountExchange,
                "@SortOrder",openingSupplyEntryEntity.SortOrder
            };
        }

        private static readonly Func<IDataReader, OpeningSupplyEntryEntity> Make = reader => new OpeningSupplyEntryEntity
        {
            RefId = reader["RefID"].AsLong(),
            RefType = reader["RefType"].AsInt(),
            PostedDate = reader["PostedDate"].AsDateTime(),
            RefDate = reader["RefDate"].AsDateTime(),
            CurrencyCode = reader["CurrencyCode"].AsString(),
            ExchangeRate = reader["ExchangeRate"].AsDecimal(),
            AccountNumber = reader["AccountNumber"].AsString(),
            InventoryItemId = reader["InventoryItemID"].AsInt(),
            DepartmentId = reader["DepartmentID"].AsInt(),
            Quantity = reader["Quantity"].AsDecimal(),
            UnitPriceOc = reader["UnitPriceOc"].AsDecimal(),
            UnitPriceExchange = reader["UnitPriceExchange"].AsDecimal(),
            AmountOc = reader["AmountOc"].AsDecimal(),
            AmountExchange = reader["AmountExchange"].AsDecimal(),
            SortOrder = reader["SortOrder"].AsInt(),
        };

        #endregion
    }
}

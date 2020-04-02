/***********************************************************************
 * <copyright file="SqlServerGeneralDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: 18 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Data;
using System.Collections.Generic;
using TSD.AccountingSoft.BusinessEntities.Business.General;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.General;
using TSD.AccountingSoft.DataHelpers;


namespace TSD.AccountingSoft.DataAccess.SqlServer.General
{
    /// <summary>
    /// SqlServerGeneralDao
    /// </summary>
    public class SqlServerGeneralDao:IGeneralDao
    {
        public GeneralEntity GetGeneral(long refId)
        {
            const string procedures = @"uspGet_GeneralVoucher";
            object[] parms = { "@RefId", refId };
            return Db.Read(procedures, true, Make, parms);

        }

        public List<GeneralEntity> GetGeneralByIsCapitalAllocate()
        {
            const string procedures = @"uspGet_All_GeneralVoucher_ByIsCapitalAllocate";
            return Db.ReadList(procedures, true, Make);
        }

        public GeneralEntity GetGeneralByRefdateAndReftype(GeneralEntity objGeneralEntity)
        {
            const string procedures = @"uspGet_GeneralVoucher_ByRefNo";
            object[] parms = { "@RefNo", objGeneralEntity.RefNo };
            return Db.Read(procedures, true, Make, parms);

        }

        public List<GeneralEntity> GetGeneralByRefNo(string refNo)
        {
            const string procedures = @"uspGet_GeneralVoucher_ByRefNo";
            object[] parms = { "@RefNo", refNo };
            return Db.ReadList(procedures, true, Make,parms);
        }

        public List<GeneralEntity> GetGenerals()
        {
            const string procedures = @"uspGet_All_GeneralVoucher";
            return Db.ReadList(procedures, true, Make);
        }

        public GeneralEntity GetGeneralVoucher(int refType, long refForeignId)
        {
            const string procedures = @"uspGet_GeneralVoucher_ByForeignId";
            object[] parms = { 
                "@RefType", refType, 
                "@RefForeignId", refForeignId 
            };
            return Db.Read(procedures, true, Make, parms);
        }

        public int InsertGeneral(GeneralEntity general)
        {
            const string procedures = @"uspInsert_GeneralVoucher";
            return Db.Insert(procedures, true, Take(general));
        }

        public string UpdateGeneral(GeneralEntity general)
        {
            const string procedures = @"uspUpdate_GeneralVoucher";
            return Db.Update(procedures, true, Take(general));
        }

        public string DeleteGeneral(GeneralEntity general)
        {
            const string procedures = @"uspDelete_GeneralVoucher_ByRefID";
            object[] parms = { "@RefID", general.RefId };
            return Db.Delete(procedures, true, parms);
        }
        
        public List<GeneralEntity> GetGeneralByRefTypeId(int reftypeId)
        {
            const string procedures = @"uspGet_GeneralVoucher_ByReftypeID";
            object[] parms = { "@ReftypeID", reftypeId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        public string DeleteGeneralDetail(long refId)
        {
            const string procedures = @"uspDelete_GeneralDetailVoucher_ByRefID";
            object[] parms = { "@RefID", refId };
            return Db.Delete(procedures, true, parms);
        }

        #region Make and Take

        private static readonly Func<IDataReader, GeneralEntity> Make = reader => new GeneralEntity
        {
            RefId = reader["RefID"].AsLong(),
            RefTypeId = reader["RefTypeID"].AsInt(),
            RefNo = reader["RefNo"].AsString(),
            RefDate = reader["RefDate"].AsDateTime(),
            PostedDate = reader["PostedDate"].AsDateTime(),
            JournalMemo = reader["JournalMemo"].AsString(),
            TotalAmountOc = reader["TotalAmountOC"].AsDecimal(),
            TotalAmountExchange = reader["TotalAmountExchange"].AsDecimal(),
            DepositId = reader["DepositID"].AsLongForNull(),
            CashId = reader["CashID"].AsLongForNull()
        };

        private object[] Take(GeneralEntity take)
        {
            return new object[]
             {
                 "@RefID",take.RefId,
                 "@RefTypeID",take.RefTypeId,
                 "@RefNo",take.RefNo,
                 "@RefDate", take.RefDate,
                 "@PostedDate",take.PostedDate,
                 "@JournalMemo",take.JournalMemo ,
                 "@TotalAmountOC",take.TotalAmountOc ,
                 "@TotalAmountExchange",take.TotalAmountExchange ,
                 "@DepositID", take.DepositId,
                 "@CashID", take.CashId
             };
        }

        #endregion
    }
}

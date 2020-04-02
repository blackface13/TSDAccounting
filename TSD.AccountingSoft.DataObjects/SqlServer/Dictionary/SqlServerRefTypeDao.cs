/***********************************************************************
 * <copyright file="SqlServerRefTypeDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 25 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using TSD.AccountingSoft.BusinessEntities.Dictionary;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary;
using TSD.AccountingSoft.DataHelpers;

namespace TSD.AccountingSoft.DataAccess.SqlServer.Dictionary
{
    /// <summary>
    /// SqlServerRefTypeDao
    /// </summary>
    public class SqlServerRefTypeDao : IRefTypeDao
    {

        /// <summary>
        ///     Takes the specified department.
        /// </summary>
        /// <param name="refTypeEntity">The department.</param>
        /// <returns></returns>
        private static object[] Take(RefTypeEntity refTypeEntity)
        {
            return new object[]
            {
                "@RefTypeID", refTypeEntity.RefTypeId,
                "@DefaultCreditAccountCategoryID", refTypeEntity.DefaultCreditAccountCategoryId,
                "@DefaultCreditAccountID", refTypeEntity.DefaultCreditAccountId,
                "@DefaultDebitAccountCategoryID", refTypeEntity.DefaultDebitAccountCategoryId,
                "@DefaultDebitAccountID", refTypeEntity.DefaultDebitAccountId,
                "@DefaultTaxAccountCategoryID", refTypeEntity.DefaultTaxAccountCategoryId,
                "@DefaultTaxAccountID", refTypeEntity.DefaultTaxAccountId
            };
        }


        private static object[] TakeInsert(RefTypeEntity refTypeEntity)
        {
            return new object[]
            {
                "@RefTypeID" ,refTypeEntity.RefTypeId,
                "@RefTypeName" ,refTypeEntity.RefTypeName,
                "@FunctionID" , refTypeEntity.FunctionId,
                "@RefTypeCategoryID ", refTypeEntity.RefTypeCategoryId,
                "@MasterTableName ", refTypeEntity.MasterTableName,
                "@DetailTableName ", refTypeEntity.DetailTableName,
                "@LayoutMaster ", refTypeEntity.LayoutMaster,
                "@LayoutDetail ", refTypeEntity.LayoutDetail,
                "@DefaultDebitAccountCategoryID ", refTypeEntity.DefaultDebitAccountCategoryId,
                "@DefaultDebitAccountID ", refTypeEntity.DefaultDebitAccountId,
                "@DefaultCreditAccountCategoryID ", refTypeEntity.DefaultCreditAccountCategoryId,
                "@DefaultCreditAccountID ", refTypeEntity.DefaultCreditAccountId,
                "@DefaultTaxAccountCategoryID ", refTypeEntity.DefaultTaxAccountCategoryId,
                "@DefaultTaxAccountID ", refTypeEntity.DefaultTaxAccountId,
                "@AllowDefaultSetting ", refTypeEntity.AllowDefaultSetting,
                "@Postable ", refTypeEntity.Postable,
                "@Searchable ", refTypeEntity.Searchable,
                "@SortOrder ", refTypeEntity.SortOrder,
                "@SubSystem ", refTypeEntity.SubSystem,
            };
        }

        /// <summary>
        /// Gets the reference types.
        /// </summary>
        /// <returns></returns>
        public List<RefTypeEntity> GetRefTypes()
        {
            const string procedures = @"uspGet_All_RefType";
            return Db.ReadList(procedures, true, Make);
        }


        /// <summary>
        /// Gets the reference type Search.
        /// </summary>
        /// <returns></returns>
        public List<RefTypeEntity> GetRefTypeSearch()
        {
            const string procedures = @"uspGet_All_RefTypeSearch";
            return Db.ReadList(procedures, true, Make);
        }


        /// <summary>
        /// Gets the type of the reference.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <returns></returns>
        public RefTypeEntity GetRefType(int refTypeId)
        {
            const string sql = @"uspGet_RefType_ByID";

            object[] parms = { "@RefTypeID", refTypeId };
            return Db.Read(sql, true, Make, parms);
        }
        /// <summary>
        /// Updates the type of the reference.
        /// </summary>
        /// <param name="refTypeEntity">The reference type entity.</param>
        /// <returns></returns>
        public string UpdateRefType(RefTypeEntity refTypeEntity)
        {
            const string sql = @"uspUpdate_RefType";
            return Db.Update(sql, true, Take(refTypeEntity));
        }
        public string DeleteRefTypeConvert()
        {
            const string sql = @"usp_ConvertAccountDefault";
            object[] parms = { };
            return Db.Delete(sql, true, parms);
        }

        public string InsertReftype(RefTypeEntity refTypeEntity)
        {
            const string sql = @"uspInsert_RefType";
            return Db.Update(sql, true, TakeInsert(refTypeEntity));
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, RefTypeEntity> Make = reader =>
        {
            var refType = new RefTypeEntity();
            refType.RefTypeId = reader["RefTypeId"].AsInt();
            refType.RefTypeName = reader["RefTypeName"].AsString();
            refType.FunctionId = reader["FunctionId"].AsString();
            refType.RefTypeCategoryId = reader["RefTypeCategoryId"].AsInt();
            refType.MasterTableName = reader["MasterTableName"].AsString();
            refType.DetailTableName = reader["DetailTableName"].AsString();
            refType.LayoutMaster = reader["LayoutMaster"].AsBool();
            refType.LayoutDetail = reader["LayoutDetail"].AsBool();
            refType.DefaultDebitAccountCategoryId = reader["DefaultDebitAccountCategoryId"].AsString();
            refType.DefaultDebitAccountId = reader["DefaultDebitAccountId"].AsString();
            refType.DefaultCreditAccountCategoryId = reader["DefaultCreditAccountCategoryId"].AsString();
            refType.DefaultCreditAccountId = reader["DefaultCreditAccountId"].AsString();
            refType.DefaultTaxAccountCategoryId = reader["DefaultTaxAccountCategoryId"].AsString();
            refType.DefaultTaxAccountId = reader["DefaultTaxAccountId"].AsString();
            refType.AllowDefaultSetting = reader["AllowDefaultSetting"].AsBool();
            refType.Postable = reader["Postable"].AsBool();
            refType.Searchable = reader["Searchable"].AsBool();
            refType.SortOrder = reader["SortOrder"].AsInt();
            refType.SubSystem = reader["SubSystem"].AsString();
            return refType;
        };
    }
}

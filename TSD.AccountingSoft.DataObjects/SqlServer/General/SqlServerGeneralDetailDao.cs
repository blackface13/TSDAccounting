/***********************************************************************
 * <copyright file="SqlServerGeneralDetailDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: 11 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/
using System;
using System.Collections.Generic;
using System.Data;
using TSD.AccountingSoft.BusinessEntities.Business.General;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.General;
using TSD.AccountingSoft.DataHelpers;


namespace TSD.AccountingSoft.DataAccess.SqlServer.General
{
 public class SqlServerGeneralDetailDao:IGeneralDetailDao
    {
        /// <summary>
        /// Gets the general details by general.
        /// </summary>
        /// <param name="refId"></param>
        /// <returns></returns>
     public List<GeneralDetailEntity> GetGeneralDetailsByGeneral(long refId)
        
     {

            const string procedures = @"uspGet_GeneralDetailVoucher_ByRefID";
            object[] parms = { "@RefId", refId };
            return Db.ReadList(procedures, true, Make, parms);
        }

     /// <summary>
     /// Inserts the general detail.
     /// </summary>
     /// <param name="generalDetail">The general detail.</param>
     /// <returns></returns>
        public int InsertGeneralDetail(GeneralDetailEntity generalDetail)
        {
            const string procedures = @"uspInsert_GeneralDetailVoucher";
            return Db.Insert(procedures, true, Take(generalDetail));
        }

        /// <summary>
        /// Deletes the general details by general.
        /// </summary>
        /// <param name="generalDetail">The general detail.</param>
        /// <returns></returns>
        public string DeleteGeneralDetailsByGeneral(GeneralDetailEntity generalDetail)
        {
            const string procedures = @"uspDelete_GeneralDetailVoucher_ByRefID";
            object[] parms = { "@RefID", generalDetail.RefId };
            return Db.Delete(procedures, true, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, GeneralDetailEntity> Make = reader =>
           new GeneralDetailEntity
           {
               RefDetailId = reader["RefDetailID"].AsInt(),
               AccountNumber = reader["AccountNumber"].AsString(),
               CorrespondingAccountNumber = reader["CorrespondingAccountNumber"].AsString(),
               Description = reader["Description"].AsString(),
               AmountOc = reader["AmountOC"].AsDecimal(),
               AmountExchange = reader["AmountExchange"].AsDecimal(),
               VoucherTypeId = reader["VoucherTypeID"].AsInt(),
               BudgetSourceCode = reader["BudgetSourceCode"].AsString(),
               BudgetItemCode = reader["BudgetItemCode"].AsString(),
               AccountingObjectId = reader["AccountingObjectID"].AsInt(),
               RefId = reader["RefId"].AsInt(),
               VendorId = reader["VendorId"].AsInt(),
               ProjectId = reader["ProjectId"].AsInt(),
               CurrencyCode = reader["CurrencyCode"].AsString(),
               DepartmentId = reader["DepartmentId"].AsInt(),
               CustomerId = reader["CustomerId"].AsInt(),
               EmployeeId = reader["EmployeeId"].AsInt(),
               ExchangeRate = reader["ExchangeRate"].AsDecimal(),
               BankId = reader["BankID"].AsIntForNull(),
               InventoryItemId = reader["InventoryItemID"].AsIntForNull(),
               AutoBusiness = reader["AutoBusiness"].AsInt()
           };

        /// <summary>
        /// Takes the specified information.
        /// </summary>
        /// <param name="info">The information.</param>
        /// <returns></returns>
        private object[] Take(GeneralDetailEntity info)
        {
            return new object[]
             {
                "@RefDetailID",info.RefDetailId,
                "@AccountNumber",info.AccountNumber,
                "@CorrespondingAccountNumber",info.CorrespondingAccountNumber,
                "@Description",info.Description,
                "@AmountOC",info.AmountOc,
                "@AmountExchange",info.AmountExchange,
                "@VoucherTypeID",info.VoucherTypeId,
                "@BudgetSourceCode",info.BudgetSourceCode,
                "@BudgetItemCode",info.BudgetItemCode,
                "@AccountingObjectID",info.AccountingObjectId,
                "@RefID",info.RefId,
                "@VendorID",info.VendorId,
                "@ProjectID",info.ProjectId,
                "@CurrencyCode",info.CurrencyCode,
                "@DepartmentID",info.DepartmentId,
                "@CustomerID",info.CustomerId,
                "@EmployeeID",info.EmployeeId,
                "@ExchangeRate",info.ExchangeRate,
                "@BankID",info.BankId,
                "@InventoryItemID",info.InventoryItemId,
                "@AutoBusiness",info.AutoBusiness
             };
        }

        public List<GeneralParalellDetailEntity> GetGeneralParalellDetailsByGeneral(long refId)

        {

            const string procedures = @"uspGet_GeneralParalellDetailVoucher_ByRefID";
            object[] parms = { "@RefId", refId };
            return Db.ReadList(procedures, true, MakeParalell, parms);
        }

        /// <summary>
        /// Inserts the general detail.
        /// </summary>
        /// <param name="generalDetail">The general detail.</param>
        /// <returns></returns>
        public int InsertGeneralParalellDetail(GeneralParalellDetailEntity generalDetail)
        {
            const string procedures = @"uspInsert_GeneralParalellDetailVoucher";
            return Db.Insert(procedures, true, TakeParalell(generalDetail));
        }

        /// <summary>
        /// Deletes the general details by general.
        /// </summary>
        /// <param name="generalDetail">The general detail.</param>
        /// <returns></returns>
        public string DeleteGeneralParalellDetailsByGeneral(long refId)
        {
            const string procedures = @"uspDelete_GeneralParalellDetailVoucher_ByRefID";
            object[] parms = { "@RefID", refId };
            return Db.Delete(procedures, true, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, GeneralParalellDetailEntity> MakeParalell = reader =>
           new GeneralParalellDetailEntity
           {
               RefDetailId = reader["RefDetailID"].AsInt(),
               AccountNumber = reader["AccountNumber"].AsString(),
               CorrespondingAccountNumber = reader["CorrespondingAccountNumber"].AsString(),
               Description = reader["Description"].AsString(),
               AmountOc = reader["AmountOC"].AsDecimal(),
               AmountExchange = reader["AmountExchange"].AsDecimal(),
               VoucherTypeId = reader["VoucherTypeID"].AsInt(),
               BudgetSourceCode = reader["BudgetSourceCode"].AsString(),
               BudgetItemCode = reader["BudgetItemCode"].AsString(),
               AccountingObjectId = reader["AccountingObjectID"].AsInt(),
               RefId = reader["RefId"].AsInt(),
               VendorId = reader["VendorId"].AsInt(),
               ProjectId = reader["ProjectId"].AsInt(),
               CurrencyCode = reader["CurrencyCode"].AsString(),
               DepartmentId = reader["DepartmentId"].AsInt(),
               CustomerId = reader["CustomerId"].AsInt(),
               EmployeeId = reader["EmployeeId"].AsInt(),
               ExchangeRate = reader["ExchangeRate"].AsDecimal(),
               BankId = reader["BankID"].AsIntForNull(),
               InventoryItemId = reader["InventoryItemID"].AsIntForNull(),
           };

        /// <summary>
        /// Takes the specified information.
        /// </summary>
        /// <param name="info">The information.</param>
        /// <returns></returns>
        private object[] TakeParalell(GeneralParalellDetailEntity info)
        {
            return new object[]
             {
                "@RefDetailID",info.RefDetailId,
                "@AccountNumber",info.AccountNumber,
                "@CorrespondingAccountNumber",info.CorrespondingAccountNumber,
                "@Description",info.Description,
                "@AmountOC",info.AmountOc,
                "@AmountExchange",info.AmountExchange,
                "@VoucherTypeID",info.VoucherTypeId,
                "@BudgetSourceCode",info.BudgetSourceCode,
                "@BudgetItemCode",info.BudgetItemCode,
                "@AccountingObjectID",info.AccountingObjectId,
                "@RefID",info.RefId,
                "@VendorID",info.VendorId,
                "@ProjectID",info.ProjectId,
                "@CurrencyCode",info.CurrencyCode,
                "@DepartmentID",info.DepartmentId,
                "@CustomerID",info.CustomerId,
                "@EmployeeID",info.EmployeeId,
                "@ExchangeRate",info.ExchangeRate,
                "@BankID",info.BankId,
                "@InventoryItemID",info.InventoryItemId
             };
        }

    }
}

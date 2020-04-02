/***********************************************************************
 * <copyright file="SqlServerItemTransactionDetailDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   BangNC
 * Email:    BangNC@buca.vn
 * Website:
 * Create Date: 10 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using TSD.AccountingSoft.BusinessEntities.Business.Inventory;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Inventory;
using TSD.AccountingSoft.DataHelpers;

namespace TSD.AccountingSoft.DataAccess.SqlServer.Inventory
{
    /// <summary>
    /// SqlServerItemTransactionDetailDao
    /// </summary>
    public class SqlServerItemTransactionDetailDao : IItemTransactionDetailDao
    {
        /// <summary>
        /// Gets the item transaction details by item transaction.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>List&lt;ItemTransactionDetailEntity&gt;.</returns>
        public List<ItemTransactionDetailEntity> GetItemTransactionDetailsByItemTransaction(long refId)
        {
            const string procedures = @"uspGet_ItemTransactionDetail_ByMaster";
            object[] parms = { "@RefID", refId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        /// <summary>
        /// Inserts the item transaction detail.
        /// </summary>
        /// <param name="itemTransactionDetail">The item transaction detail.</param>
        /// <returns>System.Int32.</returns>
        public int InsertItemTransactionDetail(ItemTransactionDetailEntity itemTransactionDetail)
        {
            const string sql = @"uspInsert_ItemTransactionDetail";
            return Db.Insert(sql, true, Take(itemTransactionDetail));
        }

        /// <summary>
        /// Deletes the item transaction detail by item transaction identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns>System.String.</returns>
        public string DeleteItemTransactionDetailByItemTransactionId(long refId)
        {
            const string procedures = @"uspDelete_ItemTransactionDetail_ByMaster";

            object[] parms = { "@RefID", refId };
            return Db.Delete(procedures, true, parms);
        }

        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, ItemTransactionDetailEntity> Make = reader => new ItemTransactionDetailEntity
        {
            RefDetailId = reader["RefDetailID"].AsLong(),
            AccountNumber = reader["AccountNumber"].AsString(),
            CorrespondingAccountNumber = reader["CorrespondingAccountNumber"].AsString(),
            Description = reader["Description"].AsString(),
            AmountOc = reader["AmountOC"].AsDecimal(),
            AmountExchange = reader["AmountExchange"].AsDecimal(),
            VoucherTypeId = reader["VoucherTypeID"].AsIntForNull(),
            BudgetSourceCode = reader["BudgetSourceCode"].AsString(),
            BudgetItemCode = reader["BudgetItemCode"].AsString(),
            AccountingObjectId = reader["AccountingObjectID"].AsIntForNull(),
            MergerFundId = reader["MergerFundID"].AsIntForNull(),
            ProjectId = reader["ProjectID"].AsIntForNull(),
            RefId = reader["RefID"].AsLong(),
            Quantity = reader["Quantity"].AsInt(),
            Price = reader["Price"].AsDecimal(),
            PriceExchange = reader["PriceExchange"].AsDecimal(),
            InventoryItemId = reader["InventoryItemID"].AsInt(),
            ExchangeRate = reader["ExchangeRate"].AsDecimal(),
            FreeQuantity = reader["FreeQuantity"].AsInt(),
            TotalQuantity = reader["TotalQuantity"].AsInt(),
            CancelQuantity = reader["CancelQuantity"].AsInt(),
            DepartmentId = reader["DepartmentID"].AsIntForNull()
        };

        /// <summary>
        /// Takes the specified information.
        /// </summary>
        /// <param name="itemTransactionDetailEntity">The information.</param>
        /// <returns>System.Object[].</returns>
        private object[] Take(ItemTransactionDetailEntity itemTransactionDetailEntity)
        {
            return new object[]
             {
                 "@RefDetailID",itemTransactionDetailEntity.RefDetailId,
                 "@AccountNumber",itemTransactionDetailEntity.AccountNumber,
                 "@CorrespondingAccountNumber",itemTransactionDetailEntity.CorrespondingAccountNumber,
                 "@Description",itemTransactionDetailEntity.Description,
                 "@AmountOC",itemTransactionDetailEntity.AmountOc,
                 "@AmountExchange",itemTransactionDetailEntity.AmountExchange,
                 "@VoucherTypeID",itemTransactionDetailEntity.VoucherTypeId ,
                 "@BudgetSourceCode",itemTransactionDetailEntity.BudgetSourceCode,
                 "@BudgetItemCode",itemTransactionDetailEntity.BudgetItemCode,
                 "@AccountingObjectID",itemTransactionDetailEntity.AccountingObjectId,
                 "@MergerFundID",itemTransactionDetailEntity.MergerFundId,
                 "@ProjectID",itemTransactionDetailEntity.ProjectId,
                 "@RefID",itemTransactionDetailEntity.RefId,
                 "@InventoryItemID",itemTransactionDetailEntity.InventoryItemId,
                 "@Quantity",itemTransactionDetailEntity.Quantity,
                 "@Price",itemTransactionDetailEntity.Price,
                 "@PriceExchange",itemTransactionDetailEntity.PriceExchange,
                "@FreeQuantity",itemTransactionDetailEntity.FreeQuantity,
                "@TotalQuantity",itemTransactionDetailEntity.TotalQuantity,
                "@CancelQuantity",itemTransactionDetailEntity.CancelQuantity,
                "@DepartmentID", itemTransactionDetailEntity.DepartmentId
             };
        }

        /// <summary>
        /// Gets the item transaction details for cal output inventory.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="stockId">The stock identifier.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns>List&lt;ItemTransactionDetailEntity&gt;.</returns>
        public List<ItemTransactionDetailEntity> GetItemTransactionDetailsForCalOutputInventory(DateTime fromDate, DateTime toDate, List<int> stockId, string currencyCode)
        {
            string[] currencyCodeVal = currencyCode.Split(',');

            var list = new List<ItemTransactionDetailEntity>();
            foreach (var key in stockId)
            {
                foreach (var currencyCodeValDetail in currencyCodeVal)
                {
                var  currencyCodeValDetail1=  currencyCodeValDetail.Trim(' ');
                    const string procedures = @"uspGet_CalculatePrice_OutputInventory_ItemTransactionDetail";
                    object[] parms = { "@FromDate", fromDate, "@ToDate", toDate, "@PStockID", key, "@PCurrencyCode", currencyCodeValDetail1 };
                    var listobj = Db.ReadList(procedures, true, Make, parms);
                    foreach (var itemTransactionDetailEntity in listobj)
                    {
                        list.Add(itemTransactionDetailEntity);
                    }
                }
               
            }
            return list;
        }
    }
}

/***********************************************************************
 * <copyright file="SqlServerItemTransactionDao.cs" company="BUCA JSC">
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
using System.Globalization;
using System.Linq;
using TSD.AccountingSoft.BusinessEntities.Business.Inventory;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Inventory;
using TSD.AccountingSoft.DataHelpers;


namespace TSD.AccountingSoft.DataAccess.SqlServer.Inventory
{
    public class SqlServerItemTransactionDao : IItemTransactionDao
    {
        private static readonly IDBOptionDao DBOptionDao = TSD.AccountingSoft.DataAccess.DataAccess.DBOptionDao;

        public ItemTransactionEntity GetItemTransaction(long refId)
        {
            const string procedures = @"uspGet_ItemTransaction_ByID";
            object[] parms = { "@RefID", refId };
            return Db.Read(procedures, true, Make, parms);
        }

        public ItemTransactionEntity GetItemTransactionByRefdateAndReftype(ItemTransactionEntity itemTransaction)
        {
            throw new NotImplementedException();
        }

        public List<ItemTransactionEntity> GetItemTransactionsByRefTypeId(int refTypeId)
        {
            const string procedures = @"uspGet_ItemTransaction_ByRefType";

            object[] parms = { "@RefTypeID", refTypeId };
            return Db.ReadList(procedures, true, Make, parms);
        }

        public List<ItemTransactionEntity> GetItemTransactions()
        {
            const string procedures = @"uspGet_All_ItemTransaction";
            return Db.ReadList(procedures, true, Make);
        }

        public List<ItemTransactionEntity> GetItemTransactionsByDate(DateTime fromDate, DateTime toDate)
        {
            const string procedures = @"uspGet_ItemTransactionByDate";
            object[] parms = { "@FromDate", fromDate,
                             "@ToDate", toDate};
            return Db.ReadList(procedures, true, Make, parms);
        }

        public int InsertItemTransaction(ItemTransactionEntity itemTransaction)
        {
            const string sql = @"uspInsert_ItemTransaction";
            return Db.Insert(sql, true, Take(itemTransaction));
        }

        public string UpdateItemTransaction(ItemTransactionEntity itemTransaction)
        {
            const string sql = @"uspUpdate_ItemTransaction";
            return Db.Update(sql, true, Take(itemTransaction));
        }

        public string DeleteItemTransaction(ItemTransactionEntity itemTransaction)
        {
            const string sql = @"uspDelete_ItemTransaction"; 

            object[] parms = { "@RefID", itemTransaction.RefId };
            return Db.Delete(sql, true, parms);
        }

        public ItemTransactionEntity GetItemTransactionByRefNo(string refNo)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Lấy giá trị tồn kho
        /// </summary>
        public decimal GetQuantityOfInventory(int inventoryItemID, int stockId, DateTime postDate, long refID, string currencyCode)
        {
            const string sql = "uspGet_ItemTransaction_QuantityOfInventory";
            object[] parms = { "@CurrencyCode", currencyCode, "@InventoryItemID", inventoryItemID, "@StockID", stockId, "@PostDate", postDate, "@RefID", refID };
            return Db.GetScalar(sql, true, parms).AsDecimal();
        }

        private object[] TakeCalcualteOutwardPrice(DateTime fromDate, DateTime toDate, string inventoryItemId)
        {
            return new object[]
            {
                "@FromDate",fromDate,
                "@ToDate",toDate,
                "@InventoryItemID",inventoryItemId
            };
        }
        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, ItemTransactionEntity> Make = reader =>
           
           {
               var item = new ItemTransactionEntity();
               item.RefId = reader["RefID"].AsLong();
               item.RefTypeId = reader["RefTypeID"].AsInt();
               item.RefNo = reader["RefNo"].AsString();
               item.RefDate = reader["RefDate"].AsDateTime();
               item.PostedDate = reader["PostedDate"].AsDateTime();
               item.AccountingObjectId = reader["AccountingObjectID"].AsString().AsIntForNull();
               item.CustomerId = reader["CustomerID"].AsString().AsIntForNull();
               item.VendorId = reader["VendorID"].AsString().AsIntForNull();
               item.EmployeeId = reader["EmployeeID"].AsString().AsIntForNull();
               item.Trader = reader["Trader"].AsString();
               item.CurrencyCode = reader["CurrencyCode"].AsString();
               item.StockId = reader["StockID"].AsInt();
               item.TotalAmount = reader["TotalAmountOC"].AsDecimal();
               item.ExchangeRate = reader["ExchangeRate"].AsDecimal();
               item.TotalAmountExchange = reader["TotalAmountExchange"].AsDecimal();
               item.JournalMemo = reader["JournalMemo"].AsString();
               item.DocumentInclude = reader["DocumentInclude"].AsString();
               item.AccountingObjectType = reader["AccountingObjectType"].AsInt();
               item.TaxCode = reader["TaxCode"].AsString();
               item.IsCalculatePrice = reader["IsCalculatePrice"].AsBool();
               item.BankId = reader["BankId"].AsIntForNull();
               return item;
           };

        /// <summary>
        /// Takes the specified take.
        /// </summary>
        /// <param name="take">The take.</param>
        /// <returns></returns>
        private object[] Take(ItemTransactionEntity take)
        {
            return new object[]
             {
                 "@RefID",take.RefId,
                 "@RefTypeID",take.RefTypeId,
                 "@RefNo",take.RefNo,
                 "@RefDate",take.RefDate,
                 "@PostedDate",take.PostedDate,
                 "@AccountingObjectID",take.AccountingObjectId,
                 "@CustomerID",take.CustomerId,
                 "@VendorID",take.VendorId,
                 "@EmployeeID",take.EmployeeId,
                 "@Trader",take.Trader,
                 "@CurrencyCode",take.CurrencyCode,
                 "@StockID",take.StockId,
                 "@TotalAmountOC",take.TotalAmount,
                 "@ExchangeRate",take.ExchangeRate,
                 "@TotalAmountExchange",take.TotalAmountExchange,
                 "@JournalMemo",take.JournalMemo,
                 "@DocumentInclude",take.DocumentInclude,
                 "@AccountingObjectType",take.AccountingObjectType	,
                 "@TaxCode",take.TaxCode,
                 "@BankID",take.BankId,
		
             };
        }

        /// <summary>
        /// Gets the item transactions for cal output inventory.
        /// </summary>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <param name="stockId">The stock identifier.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns></returns>
        public List<ItemTransactionEntity> GetItemTransactionsForCalOutputInventory(DateTime fromDate, DateTime toDate, List<int> stockId, string currencyCode)
        {
            var sqlServerItemTransactionDetailDao = new SqlServerItemTransactionDetailDao();
            var listDetails = sqlServerItemTransactionDetailDao.GetItemTransactionDetailsForCalOutputInventory(fromDate, toDate, stockId, currencyCode);
            string listKey = "";// list.ToString();
            foreach (var key in stockId)
            {
                listKey = listKey + key.ToString(CultureInfo.InvariantCulture) + ",";
            }
            if (listKey.Length > 1)
            {
                listKey = listKey.Remove(listKey.Length - 1, 1);
            }
            const string procedures = @"uspGet_CalculatePrice_OutputInventory_ItemTransaction";
            object[] parms = { "@FromDate", fromDate, "@ToDate", toDate, "@PStockID", listKey, "@PCurrencyCode", currencyCode };
            List<ItemTransactionEntity> listItemTransactionEntity = Db.ReadList(procedures, true, Make, parms);

            decimal lastExchangeRate = 0;
            string currencyAcounting = "";
            if (listItemTransactionEntity.Count > 0)
            {
                currencyAcounting = DBOptionDao.GetDBOption("CurrencyAccounting")?.OptionValue ?? "";
                var lstItemTransactionIsLocalCurrencys = listItemTransactionEntity.Where(w => w.CurrencyCode != currencyAcounting).ToList();
                if (lstItemTransactionIsLocalCurrencys != null && lstItemTransactionIsLocalCurrencys.Count > 0)
                {
                    lastExchangeRate = lstItemTransactionIsLocalCurrencys.OrderByDescending(o => o.RefDate).FirstOrDefault().ExchangeRate;
                }
                else
                    lastExchangeRate = 1;
            }

            foreach (var itemTransactionEntity in listItemTransactionEntity)
            {
                itemTransactionEntity.ItemTransactionDetails = new List<ItemTransactionDetailEntity>();
                itemTransactionEntity.TotalAmount = 0;
                itemTransactionEntity.TotalAmountExchange = 0;
                foreach (ItemTransactionDetailEntity itemTransactionDetailEntity in listDetails)
                {
                    if (itemTransactionDetailEntity.RefId == itemTransactionEntity.RefId)
                    {
                        if (itemTransactionDetailEntity.VoucherTypeId == 0)
                        {
                            itemTransactionDetailEntity.VoucherTypeId = null;
                        }
                        if (itemTransactionDetailEntity.MergerFundId == 0)
                        {
                            itemTransactionDetailEntity.MergerFundId = null;
                        }
                        if (itemTransactionDetailEntity.ProjectId == 0)
                        {
                            itemTransactionDetailEntity.ProjectId = null;
                        }
                        if (itemTransactionDetailEntity.AccountingObjectId == 0)
                        {
                            itemTransactionDetailEntity.AccountingObjectId = null;
                        }
                        //tính lai AmountExchange do đã có ExchangeRate
                        if (itemTransactionEntity.CurrencyCode != currencyAcounting)
                            itemTransactionDetailEntity.AmountExchange = itemTransactionDetailEntity.AmountOc / lastExchangeRate; // itemTransactionEntity.ExchangeRate;
                        else
                            itemTransactionDetailEntity.AmountExchange = itemTransactionDetailEntity.AmountOc / itemTransactionEntity.ExchangeRate;
                        itemTransactionEntity.TotalAmount = itemTransactionEntity.TotalAmount + itemTransactionDetailEntity.AmountOc;
                        itemTransactionEntity.TotalAmountExchange = itemTransactionEntity.TotalAmountExchange + itemTransactionDetailEntity.AmountExchange;
                        itemTransactionEntity.ItemTransactionDetails.Add(itemTransactionDetailEntity);
                    }
                }

            }
            return listItemTransactionEntity;
        }

        public List<ItemTransactionEntity> GetOutputItemTransactionsByDate(DateTime fromDate, DateTime toDate)
        {
            const string procedures = @"uspGet_OutputItemTransactionByDate";
            object[] parms = { "@FromDate", fromDate,
                             "@ToDate", toDate};
            return Db.ReadList(procedures, true, Make, parms);
        }


        public List<ItemTransactionEntity> GetOutputItemTransactionsByArisePeriod(DateTime fromDate, DateTime toDate, List<int> stockId, string currencyCode)
        {
            const string procedures = @"uspGet_OutputItemTransactionByArisePeriod";
            string whereClause = "";
            for (int i = 0; i < stockId.Count; i++) //Kiểu gì ít nhât cũng phải có 1 loại kho
            {
                whereClause = whereClause + "StockID = " + stockId[i] + " OR ";
            }

            if (whereClause.Length>5)
            {
                whereClause = @"(" + whereClause.Substring(0,whereClause.Length - 3) + @") AND (";
            }

            List<string> lstCurrencyCode = new List<string>(currencyCode.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries));//Kiểu gì cũng có hơn 1 phần tử 
            foreach (string item in lstCurrencyCode)
            {
                whereClause = whereClause + "CurrencyCode ='" + item.Trim() + "' OR ";
            }
            whereClause = whereClause.Substring(0, whereClause.Length - 3) + ")";
            object[] parms = { "@FromDate", fromDate, "@ToDate", toDate, "@WhereClause", whereClause };

            return Db.ReadList(procedures, true, Make, parms);
        }
    }
}

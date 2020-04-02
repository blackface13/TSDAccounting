using System;
using System.Collections.Generic;
using System.Data;
using TSD.AccountingSoft.BusinessEntities.Business.Cash;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Cash;
using TSD.AccountingSoft.DataHelpers;

namespace TSD.AccountingSoft.DataAccess.SqlServer.Cash
{
    public class SqlServerReceiptVoucherDetailDao : IReceiptVoucherDetailDao
    {
        /// <summary>
        /// Gets the receipt voucher details by master.
        /// </summary>
        /// <param name="receiptVoucherID">The receipt voucher identifier.</param>
        /// <returns></returns>
        public List<ReceiptVoucherDetailEntity> GetReceiptVoucherDetailsByMaster(int receiptVoucherID)
        {
            string procedures = @"uspGet_ReceiptVoucherDetail_ByMaster";

            object[] parms = { "@ReceiptVoucherID", receiptVoucherID };
            return Db.ReadList(procedures, true, Make, parms);
        }
        /// <summary>
        /// Inserts the receipt voucher detail.
        /// </summary>
        /// <param name="receiptVoucherDetail">The receipt voucher detail.</param>
        /// <returns></returns>
        public int InsertReceiptVoucherDetail(ReceiptVoucherDetailEntity receiptVoucherDetail)
        {
            const string sql = @"uspInsert_ReceiptVoucherDetail";
            return Db.Insert(sql, true, Take(receiptVoucherDetail));
        }

        /// <summary>
        /// Deletes the receipt voucher detail by master.
        /// </summary>
        /// <param name="receiptVoucherID">The receipt voucher identifier.</param>
        /// <returns></returns>
        public string DeleteReceiptVoucherDetailByMaster(int receiptVoucherID)
        {
            string procedures = @"uspDelete_ReceiptVoucherDetail_ByMaster";

            object[] parms = { "@ReceiptVoucherID", receiptVoucherID };
            return Db.Delete(procedures, true, parms);
        }
        /// <summary>
        /// The make
        /// </summary>
        private static Func<IDataReader, ReceiptVoucherDetailEntity> Make = reader =>
            new ReceiptVoucherDetailEntity
            {
                ReceiptVoucherDetailID = reader["ReceiptVoucherDetailID"].AsInt(),
                ReceiptVoucherID = reader["ReceiptVoucherID"].AsInt(),
                ItemName = reader["ItemName"].AsString(),
                Quantity = reader["Quantity"].AsInt(),
                Amount = reader["Amount"].AsDecimal()
            };
        /// <summary>
        /// Takes the specified receipt voucher detail.
        /// </summary>
        /// <param name="receiptVoucherDetail">The receipt voucher detail.</param>
        /// <returns></returns>
        private object[] Take(ReceiptVoucherDetailEntity receiptVoucherDetail)
        {
            return new object[]  
            {
                "@ReceiptVoucherDetailID", receiptVoucherDetail.ReceiptVoucherDetailID,
                "@ReceiptVoucherID", receiptVoucherDetail.ReceiptVoucherID,
                "@ItemName", receiptVoucherDetail.ItemName,
                "@Quantity", receiptVoucherDetail.Quantity,
                "@Amount", receiptVoucherDetail.Amount
            };
        }
    }
}

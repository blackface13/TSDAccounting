using System;
using System.Collections.Generic;
using System.Data;
using TSD.AccountingSoft.BusinessEntities.Business.Cash;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Cash;
using TSD.AccountingSoft.DataHelpers;

namespace TSD.AccountingSoft.DataAccess.SqlServer.Cash
{
    public class SqlServerReceiptVoucherDao : IReceiptVoucherDao
    {
        /// <summary>
        /// Gets the receipt voucher.
        /// </summary>
        /// <param name="receiptVoucherID">The receipt voucher identifier.</param>
        /// <returns></returns>
        public ReceiptVoucherEntity GetReceiptVoucher(int receiptVoucherID)
        {
            const string procedures = @"uspGet_ReceiptVoucher_ByID";

            object[] parms = { "@ReceiptVoucherID", receiptVoucherID };
            return Db.Read(procedures, true, Make, parms);
        }
        /// <summary>
        /// Gets the receipt vouchers.
        /// </summary>
        /// <returns></returns>
        public List<ReceiptVoucherEntity> GetReceiptVouchers()
        {
            const string procedures = @"uspGet_All_ReceiptVoucher";
            return Db.ReadList(procedures, true, Make);
        }

        /// <summary>
        /// Inserts the receipt voucher.
        /// </summary>
        /// <param name="receiptVoucher">The receipt voucher.</param>
        /// <returns></returns>
        public int InsertReceiptVoucher(ReceiptVoucherEntity receiptVoucher)
        {
            const string sql = @"uspInsert_ReceiptVoucher";
            return Db.Insert(sql, true, Take(receiptVoucher));
        }
        /// <summary>
        /// Updates the receipt voucher.
        /// </summary>
        /// <param name="receiptVoucher">The receipt voucher.</param>
        /// <returns></returns>
        public string UpdateReceiptVoucher(ReceiptVoucherEntity receiptVoucher)
        {
            const string sql = @"uspUpdate_ReceiptVoucher";
            return Db.Update(sql, true, Take(receiptVoucher));
        }

        /// <summary>
        /// Deletes the receipt voucher.
        /// </summary>
        /// <param name="receiptVoucher">The receipt voucher.</param>
        /// <returns></returns>
        public string DeleteReceiptVoucher(ReceiptVoucherEntity receiptVoucher)
        {
            const string sql = @"uspDelete_ReceiptVoucher";

            object[] parms = { "@ReceiptVoucherID", receiptVoucher.ReceiptVoucherID };
            return Db.Delete(sql, true, parms);
        }
        /// <summary>
        /// The make
        /// </summary>
        private static readonly Func<IDataReader, ReceiptVoucherEntity> Make = reader =>
            new ReceiptVoucherEntity
            {
                ReceiptVoucherID = reader["ReceiptVoucherID"].AsInt(),
                Code = reader["Code"].AsString(),
                RefDate = reader["RefDate"].AsDateTime(),
                CreateBy = reader["CreateBy"].AsString(),
                Description = reader["Description"].AsString(),
                TotalAmount = reader["TotalAmount"].AsDecimal()
            };
        /// <summary>
        /// Takes the specified receipt voucher.
        /// </summary>
        /// <param name="receiptVoucher">The receipt voucher.</param>
        /// <returns></returns>
        private object[] Take(ReceiptVoucherEntity receiptVoucher)
        {
            return new object[]  
            {
                "@ReceiptVoucherID", receiptVoucher.ReceiptVoucherID,
                "@Code", receiptVoucher.Code,
                "@RefDate", receiptVoucher.RefDate,
                "@CreateBy", receiptVoucher.CreateBy,
                "@Description", receiptVoucher.Description,
                "@TotalAmount", receiptVoucher.TotalAmount
            };
        }
    }
}
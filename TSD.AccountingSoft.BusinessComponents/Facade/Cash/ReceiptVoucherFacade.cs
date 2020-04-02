using System;
using System.Linq;
using System.Transactions;
using TSD.AccountingSoft.BusinessComponents.Messages.Cash;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Business.Cash;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Cash;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary;

namespace TSD.AccountingSoft.BusinessComponents.Facade.Cash
{
    public class ReceiptVoucherFacade
    {
        private static readonly IReceiptVoucherDao ReceiptVoucherDao = DataAccess.DataAccess.ReceiptVoucherDao;
        private static readonly IReceiptVoucherDetailDao ReceiptVoucherDetailDao = DataAccess.DataAccess.ReceiptVoucherDetailDao;
        private static readonly IAutoNumberDao AutoNumberDao = DataAccess.DataAccess.AutoNumberDao;

        /// <summary>
        /// Gets the receipt vouchers.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public ReceiptVoucherResponse GetReceiptVouchers(ReceiptVoucherRequest request)
        {
            var response = new ReceiptVoucherResponse();

            if (request.LoadOptions.Contains("ReceiptVouchers")) response.ReceiptVouchers = ReceiptVoucherDao.GetReceiptVouchers();
            if (request.LoadOptions.Contains("ReceiptVoucher"))
            {
                var receiptVoucher = ReceiptVoucherDao.GetReceiptVoucher(request.ReceiptVoucherID);
                if (request.LoadOptions.Contains("IncludeDetail"))
                {
                    receiptVoucher = receiptVoucher ?? new ReceiptVoucherEntity();
                    receiptVoucher.ReceiptVoucherDetails = ReceiptVoucherDetailDao.GetReceiptVoucherDetailsByMaster(receiptVoucher.ReceiptVoucherID);
                }
                response.ReceiptVoucher = receiptVoucher;
            }

            return response;
        }
        /// <summary>
        /// Sets the receipt vouchers.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public ReceiptVoucherResponse SetReceiptVouchers(ReceiptVoucherRequest request)
        {
            var response = new ReceiptVoucherResponse();

            var receiptVoucherEntity = request.ReceiptVoucher;
            if (request.Action != PersistType.Delete)
            {
                if (!receiptVoucherEntity.Validate())
                {
                    foreach (string error in receiptVoucherEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
            }
            try
            {
                if (request.Action == PersistType.Insert)
                {
                    using (var scope = new TransactionScope())
                    {
                        receiptVoucherEntity.ReceiptVoucherID = ReceiptVoucherDao.InsertReceiptVoucher(receiptVoucherEntity);
                        foreach (var receiptVoucherDetail in receiptVoucherEntity.ReceiptVoucherDetails)
                        {
                            if (!receiptVoucherDetail.Validate())
                            {
                                foreach (string error in receiptVoucherDetail.ValidationErrors)
                                    response.Message += error + Environment.NewLine;
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }
                            receiptVoucherDetail.ReceiptVoucherID = receiptVoucherEntity.ReceiptVoucherID;
                            ReceiptVoucherDetailDao.InsertReceiptVoucherDetail(receiptVoucherDetail);
                        }
                        var autoNumber = AutoNumberDao.GetAutoNumberByRefType(200);
                        autoNumber.Value += 1;
                        response.Message = AutoNumberDao.UpdateAutoNumber(autoNumber);
                        if (response.Message != null)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return response;
                        }
                        scope.Complete();
                    }
                }
                else if (request.Action == PersistType.Update)
                {
                    using (var scope = new TransactionScope())
                    {
                        //delete detail
                        response.Message = ReceiptVoucherDetailDao.DeleteReceiptVoucherDetailByMaster(receiptVoucherEntity.ReceiptVoucherID);
                        if (response.Message != null)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return response;
                        }
                        response.Message = ReceiptVoucherDao.UpdateReceiptVoucher(receiptVoucherEntity);
                        if (response.Message != null)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return response;
                        }
                        foreach (var receiptVoucherDetail in receiptVoucherEntity.ReceiptVoucherDetails)
                        {
                            if (!receiptVoucherDetail.Validate())
                            {
                                foreach (string error in receiptVoucherDetail.ValidationErrors)
                                    response.Message += error + Environment.NewLine;
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }
                            receiptVoucherDetail.ReceiptVoucherID = receiptVoucherEntity.ReceiptVoucherID;
                            ReceiptVoucherDetailDao.InsertReceiptVoucherDetail(receiptVoucherDetail);
                        }
                        scope.Complete();
                    }
                }
                else
                {
                    var receiptVoucherEntityForDelete = ReceiptVoucherDao.GetReceiptVoucher(request.ReceiptVoucherID);
                    response.Message = ReceiptVoucherDao.DeleteReceiptVoucher(receiptVoucherEntityForDelete);
                }
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }

            response.ReceiptVoucherID = receiptVoucherEntity != null ? receiptVoucherEntity.ReceiptVoucherID : 0;
            response.Acknowledge = response.Message != null ? AcknowledgeType.Failure : AcknowledgeType.Success;
            return response;
        }
    }
}
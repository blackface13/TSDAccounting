/***********************************************************************
 * <copyright file="SqlServerFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Thursday, March 18, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  07/03/2014       Author    Tudt           Description: Coding standard
 * 
 * ************************************************************************/

using System;
using System.Linq;
using System.Transactions;
using TSD.AccountingSoft.BusinessComponents.Messages.Estimate;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Business.Estimate;
using TSD.AccountingSoft.BusinessEntities.Dictionary;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Estimate;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.General;

namespace TSD.AccountingSoft.BusinessComponents.Facade.Estimate
{
    /// <summary>
    /// Class EstimateFacade.
    /// </summary>
    public class EstimateFacade
    {
        private static readonly IEstimateDao EstimateDao = DataAccess.DataAccess.EstimateDao;
        private static readonly IEstimateDetailDao EstimateDetailDao = DataAccess.DataAccess.EstimateDetailDao;
        private static readonly IAutoNumberDao AutoNumberDao = DataAccess.DataAccess.AutoNumberDao;
        private static readonly IAudittingLogDao AudittingLogDao = DataAccess.DataAccess.AudittingLogDao;

        private static readonly IEstimateDetailStatementDao EstimateDetailStatementDao = DataAccess.DataAccess.EstimateDetailStatementDao;
        private static readonly IEstimateDetailStatementPartBDao EstimateDetailStatementPartBDao = DataAccess.DataAccess.EstimateDetailStatementPartBDao;
        private static readonly IEstimateDetailStatementFixedAssetDao EstimateDetailStatementFixedAssetDao = DataAccess.DataAccess.EstimateDetailStatementFixedAssetDao;
        private static readonly IEstimateExchangeRateDao EstimateExchangeRateDao = DataAccess.DataAccess.IEstimateExchangeRateDao;

        /// <summary>
        /// Gets the estimates.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>EstimateResponse.</returns>
        public EstimateResponse GetEstimates(EstimateRequest request)
        {
            var response = new EstimateResponse();
            if (request.LoadOptions.Contains("Estimates"))
            {
                if (request.LoadOptions.Contains("RefType"))
                    response.Estimates = EstimateDao.GetEstimatesByRefTypeId(request.RefType);
                else if (request.LoadOptions.Contains("RefDate"))
                    response.Estimates = EstimateDao.GetEstimatesByYearOfRefDate(request.RefType, (short)DateTime.Parse(request.RefDate).Year);
                else if (request.LoadOptions.Contains("CheckPaymentEstimate"))
                    response.Estimates = EstimateDao.GetEstimatesByYearOfPlaning(request.RefType, request.YearOfEstimate, request.BudgetSourceCategoryId);
                else if (request.LoadOptions.Contains("CheckReceiptEstimate"))
                    response.Estimates = EstimateDao.GetEstimatesByYearOfPlaning(request.RefType, request.YearOfEstimate);
                else if (request.LoadOptions.Contains("CheckPaymentEstimateNoBudget"))
                    response.Estimates = EstimateDao.GetEstimatesByYearOfPlaning(request.RefType, request.YearOfEstimate);
                else response.Estimates = EstimateDao.GetEstimates();
            }

            if (request.LoadOptions.Contains("Estimate"))
            {
                var estimate = EstimateDao.GetEstimate(request.RefId);
                if (request.LoadOptions.Contains("IncludeDetail"))
                {
                    estimate = estimate ?? new EstimateEntity();
                    estimate.EstimateDetails = EstimateDetailDao.GetEstimateDetailsByEstimateIncludeBudgetItemName(estimate.RefId);
                }
                if (request.LoadOptions.Contains("Option"))
                {
                    estimate = estimate ?? new EstimateEntity();
                    estimate.EstimateDetails = EstimateDetailDao.GetEstimateDetailsByEstimateOption(request.RefId, request.Option, request.BudgetSourceCategoryId, request.YearOfPlaning);
                }

                if (request.LoadOptions.Contains("PlanTemplateListId"))
                {
                    estimate = estimate ?? new EstimateEntity();

                    var estimateExchangeRate = EstimateExchangeRateDao.GetEstimateExchangeRate(request.YearOfPlaning);
                    if (estimateExchangeRate != null)
                    {
                        estimate.ExchangeRateLastYear = estimateExchangeRate.ExchangeRateLastYear;
                        estimate.ExchangeRateThisYear = estimateExchangeRate.ExchangeRateThisYear;
                    }

                    estimate.EstimateDetails = EstimateDetailDao.GetEstimateDetailsByEstimateOption((int)request.RefId);
                }

                response.Estimate = estimate;
            }
            return response;
        }

        /// <summary>
        /// Sets the estimates.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>EstimateResponse.</returns>
        public EstimateResponse SetEstimates(EstimateRequest request)
        {
            var response = new EstimateResponse();

            var estimateEntity = request.Estimate;
            //var auditingLog = new AudittingLogEntity { ComponentName = "DU TOAN NGAN SACH", EventAction = (int)request.Action };
            if (request.Action != PersistType.Delete)
            {
                if (!estimateEntity.Validate())
                {
                    foreach (string error in estimateEntity.ValidationErrors)
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
                        #region
                        //estimateEntity.TotalEstimateAmount = 0;
                        //estimateEntity.NextYearOfTotalEstimateAmount = 0;
                        ////calculate total estimate
                        //foreach (var estimateDetail in estimateEntity.EstimateDetails)
                        //{
                        //    if (estimateEntity.RefTypeId == 110)
                        //    {
                        //        //estimateEntity.TotalEstimateAmount += estimateDetail.YearOfEstimateAmount;
                        //        //estimateEntity.NextYearOfTotalEstimateAmount += estimateDetail.NextYearOfEstimateAmount;
                        //        var receiptVoucherDetailForTotal = (from r in estimateEntity.EstimateDetails where !r.BudgetItemCode.Contains("000100") && !r.BudgetItemCode.Contains("000101") && !r.BudgetItemCode.Contains("000107") && !r.BudgetItemCode.Contains("000115") && !r.BudgetItemCode.Contains("000120") select r).ToList();
                        //        estimateEntity.TotalEstimateAmount = receiptVoucherDetailForTotal.Select(c => c.YearOfEstimateAmount).Sum();
                        //        estimateEntity.NextYearOfTotalEstimateAmount = receiptVoucherDetailForTotal.Select(c => c.NextYearOfEstimateAmount).Sum();
                        //    }
                        //    else
                        //    {
                        //        estimateEntity.TotalEstimateAmount += estimateDetail.YearOfEstimateAmount;
                        //        estimateEntity.NextYearOfTotalEstimateAmount += estimateDetail.TotalAmountThisYear;
                        //    }
                        //}
                        //estimateEntity.RefId = EstimateDao.InsertEstimate(estimateEntity);
                        //foreach (var receiptVoucherDetail in estimateEntity.EstimateDetails)
                        //{
                        //    if (!receiptVoucherDetail.Validate())
                        //    {
                        //        foreach (string error in receiptVoucherDetail.ValidationErrors)
                        //            response.Message += error + Environment.NewLine;
                        //        response.Acknowledge = AcknowledgeType.Failure;
                        //        return response;
                        //    }
                        //    receiptVoucherDetail.RefId = estimateEntity.RefId;
                        //    var budgetItemCode = receiptVoucherDetail.BudgetItemCode;
                        //    if (budgetItemCode == "000100")
                        //    {
                        //        var receiptVoucherDetailPartI = (from r in estimateEntity.EstimateDetails where r.BudgetItemCode.Contains("000102") || r.BudgetItemCode.Contains("000103") || r.BudgetItemCode.Contains("000104") || r.BudgetItemCode.Contains("000105") || r.BudgetItemCode.Contains("000106") select r).ToList();
                        //        receiptVoucherDetail.TotalEstimateAmountUSD = receiptVoucherDetailPartI.Select(c => c.TotalEstimateAmountUSD).Sum();
                        //        receiptVoucherDetail.YearOfEstimateAmount = receiptVoucherDetailPartI.Select(c => c.YearOfEstimateAmount).Sum();
                        //        receiptVoucherDetail.NextYearOfEstimateAmount = receiptVoucherDetailPartI.Select(c => c.NextYearOfEstimateAmount).Sum();
                        //    }
                        //    if (budgetItemCode == "000101")
                        //    {
                        //        var receiptVoucherDetailPartI = (from r in estimateEntity.EstimateDetails where r.BudgetItemCode.Contains("000102") || r.BudgetItemCode.Contains("000103") || r.BudgetItemCode.Contains("000104") select r).ToList();
                        //        receiptVoucherDetail.TotalEstimateAmountUSD = receiptVoucherDetailPartI.Select(c => c.TotalEstimateAmountUSD).Sum();
                        //        receiptVoucherDetail.YearOfEstimateAmount = receiptVoucherDetailPartI.Select(c => c.YearOfEstimateAmount).Sum();
                        //        receiptVoucherDetail.NextYearOfEstimateAmount = receiptVoucherDetailPartI.Select(c => c.NextYearOfEstimateAmount).Sum();
                        //    }
                        //    if (budgetItemCode == "000107")
                        //    {
                        //        var receiptVoucherDetailPartI = (from r in estimateEntity.EstimateDetails where r.BudgetItemCode.Contains("000108") || r.BudgetItemCode.Contains("000109") || r.BudgetItemCode.Contains("000110") || r.BudgetItemCode.Contains("000111") || r.BudgetItemCode.Contains("000112") || r.BudgetItemCode.Contains("000113") || r.BudgetItemCode.Contains("000114") select r).ToList();
                        //        receiptVoucherDetail.TotalEstimateAmountUSD = receiptVoucherDetailPartI.Select(c => c.TotalEstimateAmountUSD).Sum();
                        //        receiptVoucherDetail.YearOfEstimateAmount = receiptVoucherDetailPartI.Select(c => c.YearOfEstimateAmount).Sum();
                        //        receiptVoucherDetail.NextYearOfEstimateAmount = receiptVoucherDetailPartI.Select(c => c.NextYearOfEstimateAmount).Sum();
                        //    }
                        //    if (budgetItemCode == "000115")
                        //    {
                        //        var receiptVoucherDetailPartI = (from r in estimateEntity.EstimateDetails where r.BudgetItemCode.Contains("000116") || r.BudgetItemCode.Contains("000117") || r.BudgetItemCode.Contains("000118") || r.BudgetItemCode.Contains("000119") select r).ToList();
                        //        receiptVoucherDetail.TotalEstimateAmountUSD = receiptVoucherDetailPartI.Select(c => c.TotalEstimateAmountUSD).Sum();
                        //        receiptVoucherDetail.YearOfEstimateAmount = receiptVoucherDetailPartI.Select(c => c.YearOfEstimateAmount).Sum();
                        //        receiptVoucherDetail.NextYearOfEstimateAmount = receiptVoucherDetailPartI.Select(c => c.NextYearOfEstimateAmount).Sum();
                        //    }
                        //    EstimateDetailDao.InsertEstimateDetail(receiptVoucherDetail);
                        //}
                        //var autoNumber = AutoNumberDao.GetAutoNumberByRefType(estimateEntity.RefTypeId);
                        //autoNumber.Value += 1;
                        //response.Message = AutoNumberDao.UpdateAutoNumber(autoNumber);
                        //if (response.Message != null)
                        //{
                        //    response.Acknowledge = AcknowledgeType.Failure;
                        //    scope.Dispose();
                        //    return response;
                        //}
                        ////insert log
                        ////auditingLog.Reference = "Thêm mới CT dự toán " + estimateEntity.RefNo;
                        ////auditingLog.Amount = estimateEntity.TotalEstimateAmount;
                        ////AudittingLogDao.InsertAudittingLog(auditingLog);
                        #endregion

                        if (estimateEntity != null)
                        {
                            estimateEntity.RefId = EstimateDao.InsertEstimate(estimateEntity);

                            if (estimateEntity.RefId == 0)
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                scope.Dispose();
                                return response;
                            }

                            if (estimateEntity.EstimateDetails != null && estimateEntity.EstimateDetails.Count > 0)
                            {
                                foreach (var item in estimateEntity.EstimateDetails)
                                {
                                    if (!item.Validate())
                                    {
                                        foreach (string error in item.ValidationErrors)
                                            response.Message += error + Environment.NewLine;
                                        response.Acknowledge = AcknowledgeType.Failure;
                                        return response;
                                    }
                                    item.RefId = estimateEntity.RefId;
                                    EstimateDetailDao.InsertEstimateDetail(item);
                                }
                            }
                        }

                        response.RefId = estimateEntity.RefId;

                        var autoNumber = AutoNumberDao.GetAutoNumberByRefType(estimateEntity.RefTypeId);
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
                        #region
                        //estimateEntity.TotalEstimateAmount = 0;
                        //estimateEntity.NextYearOfTotalEstimateAmount = 0;
                        //// estimateEntity. = 0;
                        //foreach (var estimateDetail in estimateEntity.EstimateDetails)
                        //{
                        //    //estimateEntity.TotalEstimateAmount += estimateDetail.YearOfEstimateAmount;
                        //    //estimateEntity.NextYearOfTotalEstimateAmount += estimateDetail.NextYearOfEstimateAmount;
                        //    if (estimateEntity.RefTypeId == 110)
                        //    {
                        //        if (estimateDetail.BudgetItemCode.Contains("000100"))
                        //        {
                        //            var receiptVoucherDetailPartI = (from r in estimateEntity.EstimateDetails where r.BudgetItemCode.Contains("000102") || r.BudgetItemCode.Contains("000103") || r.BudgetItemCode.Contains("000104") || r.BudgetItemCode.Contains("000105") || r.BudgetItemCode.Contains("000106") select r).ToList();
                        //            estimateDetail.TotalEstimateAmountUSD = receiptVoucherDetailPartI.Select(c => c.TotalEstimateAmountUSD).Sum();
                        //            estimateDetail.YearOfEstimateAmount = receiptVoucherDetailPartI.Select(c => c.YearOfEstimateAmount).Sum();
                        //            estimateDetail.NextYearOfEstimateAmount = receiptVoucherDetailPartI.Select(c => c.NextYearOfEstimateAmount).Sum();
                        //        }
                        //        if (estimateDetail.BudgetItemCode.Contains("000101"))
                        //        {
                        //            var receiptVoucherDetailPartI = (from r in estimateEntity.EstimateDetails where r.BudgetItemCode.Contains("000102") || r.BudgetItemCode.Contains("000103") || r.BudgetItemCode.Contains("000104") select r).ToList();
                        //            estimateDetail.TotalEstimateAmountUSD = receiptVoucherDetailPartI.Select(c => c.TotalEstimateAmountUSD).Sum();
                        //            estimateDetail.YearOfEstimateAmount = receiptVoucherDetailPartI.Select(c => c.YearOfEstimateAmount).Sum();
                        //            estimateDetail.NextYearOfEstimateAmount = receiptVoucherDetailPartI.Select(c => c.NextYearOfEstimateAmount).Sum();
                        //        }
                        //        if (estimateDetail.BudgetItemCode.Contains("000107"))
                        //        {
                        //            var receiptVoucherDetailPartI = (from r in estimateEntity.EstimateDetails where r.BudgetItemCode.Contains("000108") || r.BudgetItemCode.Contains("000109") || r.BudgetItemCode.Contains("000110") || r.BudgetItemCode.Contains("000111") || r.BudgetItemCode.Contains("000112") || r.BudgetItemCode.Contains("000113") || r.BudgetItemCode.Contains("000114") select r).ToList();
                        //            estimateDetail.TotalEstimateAmountUSD = receiptVoucherDetailPartI.Select(c => c.TotalEstimateAmountUSD).Sum();
                        //            estimateDetail.YearOfEstimateAmount = receiptVoucherDetailPartI.Select(c => c.YearOfEstimateAmount).Sum();
                        //            estimateDetail.NextYearOfEstimateAmount = receiptVoucherDetailPartI.Select(c => c.NextYearOfEstimateAmount).Sum();
                        //        }
                        //        if (estimateDetail.BudgetItemCode.Contains("000115"))
                        //        {
                        //            var receiptVoucherDetailPartI = (from r in estimateEntity.EstimateDetails where r.BudgetItemCode.Contains("000116") || r.BudgetItemCode.Contains("000117") || r.BudgetItemCode.Contains("000118") || r.BudgetItemCode.Contains("000119") select r).ToList();
                        //            estimateDetail.TotalEstimateAmountUSD = receiptVoucherDetailPartI.Select(c => c.TotalEstimateAmountUSD).Sum();
                        //            estimateDetail.YearOfEstimateAmount = receiptVoucherDetailPartI.Select(c => c.YearOfEstimateAmount).Sum();
                        //            estimateDetail.NextYearOfEstimateAmount = receiptVoucherDetailPartI.Select(c => c.NextYearOfEstimateAmount).Sum();
                        //        }
                        //        var receiptVoucherDetailForTotal = (from r in estimateEntity.EstimateDetails where r.BudgetItemCode.Contains("000100") || r.BudgetItemCode.Contains("000107") || r.BudgetItemCode.Contains("000115") select r).ToList();
                        //        estimateEntity.TotalEstimateAmount = receiptVoucherDetailForTotal.Select(c => c.YearOfEstimateAmount).Sum();
                        //        estimateEntity.NextYearOfTotalEstimateAmount = receiptVoucherDetailForTotal.Select(c => c.NextYearOfEstimateAmount).Sum();
                        //    }
                        //    else
                        //    {
                        //        estimateEntity.TotalEstimateAmount += estimateDetail.YearOfEstimateAmount;
                        //        estimateEntity.NextYearOfTotalEstimateAmount += estimateDetail.TotalAmountThisYear;
                        //    }
                        //}

                        //response.Message = EstimateDao.UpdateEstimate(estimateEntity);
                        //if (response.Message != null)
                        //{
                        //    response.Acknowledge = AcknowledgeType.Failure;
                        //    scope.Dispose();
                        //    return response;
                        //}

                        //foreach (var estimateDetail in estimateEntity.EstimateDetails)
                        //{
                        //    if (!estimateDetail.Validate())
                        //    {
                        //        foreach (string error in estimateDetail.ValidationErrors)
                        //            response.Message += error + Environment.NewLine;
                        //        response.Acknowledge = AcknowledgeType.Failure;
                        //        return response;
                        //    }
                        //    estimateDetail.RefId = estimateEntity.RefId;

                        //    if (estimateDetail.IsInserted)
                        //    {
                        //        EstimateDetailDao.InsertEstimateDetail(estimateDetail);
                        //    }
                        //    else
                        //    {
                        //        response.Message = EstimateDetailDao.UpdateEstimateDetail(estimateDetail);
                        //    }


                        //    if (response.Message != null)
                        //    {
                        //        response.Acknowledge = AcknowledgeType.Failure;
                        //        scope.Dispose();
                        //        return response;
                        //    }
                        //}
                        #endregion

                        response.Message = EstimateDao.UpdateEstimate(estimateEntity);
                        if (response.Message != null)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return response;
                        }

                        response.Message = EstimateDetailDao.DeleteEstimateDetailByRefId(estimateEntity.RefId);
                        if (response.Message != null)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return response;
                        }

                        foreach (var estimateDetail in estimateEntity.EstimateDetails)
                        {
                            if (!estimateDetail.Validate())
                            {
                                foreach (string error in estimateDetail.ValidationErrors)
                                    response.Message += error + Environment.NewLine;
                                response.Acknowledge = AcknowledgeType.Failure;
                                return response;
                            }

                            estimateDetail.RefId = estimateEntity.RefId;
                            EstimateDetailDao.InsertEstimateDetail(estimateDetail);
                        }

                        scope.Complete();
                    }
                }
                else
                {
                    using (var scope = new TransactionScope())
                    {
                        var estimaterEntityForDelete = EstimateDao.GetEstimate(request.RefId);
                        response.Message = EstimateDao.DeleteEstimate(estimaterEntityForDelete);
                        if (response.Message != null)
                        {
                            response.Acknowledge = AcknowledgeType.Failure;
                            scope.Dispose();
                            return response;
                        }

                        scope.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }

            response.RefId = estimateEntity != null ? estimateEntity.RefId : 0;
            response.Acknowledge = response.Message != null ? AcknowledgeType.Failure : AcknowledgeType.Success;
            return response;
        }

        /// <summary>
        /// Gets the estimate detail statements.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public EstimateDetailStatementResponse GetEstimateDetailStatements(EstimateDetailStatementRequest request)
        {
            var response = new EstimateDetailStatementResponse();
            if (request.LoadOptions.Contains("EstimateDetailStatements"))
            {
                response.EstimateDetailStatements = EstimateDetailStatementDao.GetEstimateDetailStatements();
            }

            if (request.LoadOptions.Contains("EstimateDetailStatement"))
            {
                var estimateDetailStatement = EstimateDetailStatementDao.GetEstimateDetailStatement(request.IsActive);
                response.EstimateDetailStatement = estimateDetailStatement;
            }

            if (request.LoadOptions.Contains("CompanyProfiles"))
            {
                var estimateDetailStatement = EstimateDetailStatementDao.GetCompanyProfileInfo(request.IsActive);
                response.EstimateDetailStatement = estimateDetailStatement;
            }
            return response;
        }

        /// <summary>
        /// Sets the estimate detail statements.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public EstimateDetailStatementResponse SetEstimateDetailStatements(EstimateDetailStatementRequest request)
        {
            var response = new EstimateDetailStatementResponse();

            var estimateDetailStatementEntity = request.EstimateDetailStatement;
            if (request.Action != PersistType.Delete)
            {
                if (!estimateDetailStatementEntity.Validate())
                {
                    foreach (string error in estimateDetailStatementEntity.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
            }
            try
            {
                if (request.Action == PersistType.Insert)
                {
                    estimateDetailStatementEntity.EstimateDetailStatementId = EstimateDetailStatementDao.InsertEstimateDetailStatement(estimateDetailStatementEntity);
                    response.Message = null;
                }
                else if (request.Action == PersistType.Update)
                    response.Message = EstimateDetailStatementDao.UpdateEstimateDetailStatement(estimateDetailStatementEntity);
                else
                {
                    var estimateDetailStatementForUpdate = EstimateDetailStatementDao.GetEstimateDetailStatement(request.IsActive);
                    response.Message = EstimateDetailStatementDao.DeleteEstimateDetailStatement(estimateDetailStatementForUpdate);
                }
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
            //response.EstimateDetailStatementId = estimateDetailStatementEntity != null ? estimateDetailStatementEntity.EstimateDetailStatementId : 0;
            //if (response.Message == null)
            //{
            //    response.Acknowledge = AcknowledgeType.Success;
            //    response.RowsAffected = 1;
            //}
            //else
            //{
            //    response.Acknowledge = AcknowledgeType.Failure;
            //    response.RowsAffected = 0;
            //}

            return response;
        }

        // Set Get tham số báo cáo 
        /// <summary>
        /// Gets the estimate detail statements.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public EstimateDetailStatementPartBResponse GetEstimateDetailStatementPartBs(EstimateDetailStatementPartBRequest request)
        {
            var response = new EstimateDetailStatementPartBResponse();
            if (request.LoadOptions.Contains("EstimateDetailStatementPartBs"))
            {
                response.EstimateDetailStatementPartBs = EstimateDetailStatementPartBDao.GetEstimateDetailStatementPartBs();
            }
            return response;
        }

        /// <summary>
        /// Sets the estimate detail statements.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public EstimateDetailStatementPartBResponse SetEstimateDetailStatementPartBs(EstimateDetailStatementPartBRequest request)
        {
            var response = new EstimateDetailStatementPartBResponse();

            var estimateDetailStatementPartBEntities = request.EstimateDetailStatementPartBs;
            try
            {
                if (request.Action == PersistType.Insert)
                {
                    foreach (var detailStatementPartBEntity in estimateDetailStatementPartBEntities)
                    {
                        detailStatementPartBEntity.EstimateDetailStatementPartBId = EstimateDetailStatementPartBDao.InsertEstimateDetailStatementPartB(detailStatementPartBEntity);
                        response.Message = null;
                    }
                }
                else if (request.Action == PersistType.Update)
                {
                    response.Message = EstimateDetailStatementPartBDao.DeleteEstimateDetailStatementPartB();
                    foreach (var detailStatementPartBEntity in estimateDetailStatementPartBEntities)
                    {
                        response.EstimateDetailStatementPartBId = EstimateDetailStatementPartBDao.InsertEstimateDetailStatementPartB(detailStatementPartBEntity);
                        response.Message = null;
                    }
                }
                else
                {
                    response.Message = EstimateDetailStatementPartBDao.DeleteEstimateDetailStatementPartB();
                }
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
            if (response.Message == null)
            {
                response.Acknowledge = AcknowledgeType.Success;
                response.RowsAffected = 1;
            }
            else
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.RowsAffected = 0;
            }

            return response;
        }

        // Get set tham số báo cáo dự toán chi tiết, bảng kê thiết bị mua sắm -- ThoDD thêm 
        /// <summary>
        /// Gets the estimate detail statements.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public EstimateDetailStatementFixedAssetResponse GetEstimateDetailStatementFixedAssets(EstimateDetailStatementFixedAssetRequest request)
        {
            var response = new EstimateDetailStatementFixedAssetResponse();
            if (request.LoadOptions.Contains("EstimateDetailStatementFixedAssets"))
            {
                response.EstimateDetailStatementFixedAssets = EstimateDetailStatementFixedAssetDao.GetEstimateDetailStatementFixedAssets();
            }
            return response;
        }

        /// <summary>
        /// Sets the estimate detail statements.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public EstimateDetailStatementFixedAssetResponse SetEstimateDetailStatementFixedAssets(EstimateDetailStatementFixedAssetRequest request)
        {
            var response = new EstimateDetailStatementFixedAssetResponse();

            var estimateDetailStatementPartBEntities = request.EstimateDetailStatementFixedAssets;
            try
            {
                if (request.Action == PersistType.Insert)
                {
                    foreach (var detailStatementPartBEntity in estimateDetailStatementPartBEntities)
                    {
                        detailStatementPartBEntity.EstimateDetailStatementFixedAssetId = EstimateDetailStatementFixedAssetDao.InsertEstimateDetailStatementFixedAsset(detailStatementPartBEntity);
                        response.Message = null;
                    }
                }
                else if (request.Action == PersistType.Update)
                {
                    response.Message = EstimateDetailStatementFixedAssetDao.DeleteEstimateDetailStatementFixedAsset();
                    foreach (var detailStatementPartBEntity in estimateDetailStatementPartBEntities)
                    {
                        response.EstimateDetailStatementFixedAssetId = EstimateDetailStatementFixedAssetDao.InsertEstimateDetailStatementFixedAsset(detailStatementPartBEntity);
                        response.Message = null;
                    }
                }
                else
                {
                    response.Message = EstimateDetailStatementFixedAssetDao.DeleteEstimateDetailStatementFixedAsset();
                }
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
            if (response.Message == null)
            {
                response.Acknowledge = AcknowledgeType.Success;
                response.RowsAffected = 1;
            }
            else
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.RowsAffected = 0;
            }

            return response;
        }
    }
}

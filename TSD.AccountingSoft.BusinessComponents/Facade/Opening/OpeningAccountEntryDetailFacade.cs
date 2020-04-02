/***********************************************************************
 * <copyright file="OpeningAccountEntryDetailFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 25 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Linq;
using System.Transactions;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessComponents.Messages.Opening;
using TSD.AccountingSoft.BusinessEntities.Business.Opening;
using TSD.AccountingSoft.BusinessEntities.Dictionary;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Opening;

namespace TSD.AccountingSoft.BusinessComponents.Facade.Opening
{
    /// <summary>
    /// OpeningAccountEntryDetailFacade
    /// </summary>
    public class OpeningAccountEntryDetailFacade
    {
        private static readonly IOpeningAccountEntryDetailDao OpeningAccountEntryDetailDao = DataAccess.DataAccess.OpeningAccountEntryDetailDao;
        private static readonly IOpeningAccountEntryDao OpeningAccountEntryDao = DataAccess.DataAccess.OpeningAccountEntryDao;
        private static readonly IAudittingLogDao AudittingLogDao = DataAccess.DataAccess.AudittingLogDao;
        private static readonly IAccountDao AccountDao = DataAccess.DataAccess.AccountDao;

        /// <summary>
        /// Gets the opening account entries.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public OpeningAccountEntryDetailResponse GetOpeningAccountEntryDetails(OpeningAccountEntryDetailRequest request)
        {
            var response = new OpeningAccountEntryDetailResponse();
            //if (request.LoadOptions.Contains("OpeningAccountEntryDetails"))
            //{
            //   // var openingAccountEntryDetails = OpeningAccountEntryDetailDao.GetOpeningAccountEntryDetailsByAccountCode(request.AccountCode);
            //    if (request.LoadOptions.Contains("IncludeAccountDetail"))
            //    {
            //        var account = AccountDao.GetAccountByAccountCode(request.AccountCode);
            //        foreach (var openingAccountEntryDetailEntity in openingAccountEntryDetails)
            //            openingAccountEntryDetailEntity.Account = account;
            //    }
            //    response.OpeningAccountEntryDetails = openingAccountEntryDetails;
            //}
            return response;
        }

        /// <summary>
        /// Sets the opening account entry details.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public OpeningAccountEntryDetailResponse SetOpeningAccountEntryDetails(OpeningAccountEntryDetailRequest request)
        {
            var response = new OpeningAccountEntryDetailResponse();

            var openingAccountEntryDetails = request.OpeningAccountEntryDetails;
            //var auditingLog = new AudittingLogEntity { ComponentName = "SO DU DAU KY TSCD", EventAction = (int)request.Action };
            try
            {
                if (request.Action == PersistType.Insert)
                {
                    if (openingAccountEntryDetails != null && openingAccountEntryDetails.Count > 0)
                    {
                        var openingAccountEntry = new OpeningAccountEntryEntity();
                        using (var scope = new TransactionScope())
                        {
                            //insert detail
                            foreach (var openingAccountEntryDetailEntity in openingAccountEntryDetails)
                            {
                                openingAccountEntry.AccountCode = openingAccountEntryDetailEntity.AccountCode;
                                openingAccountEntry.PostedDate = openingAccountEntryDetailEntity.PostedDate;
                                openingAccountEntry.RefTypeId = openingAccountEntryDetailEntity.RefTypeId;
                                openingAccountEntry.TotalAccountBeginningDebitAmountOC += openingAccountEntryDetailEntity.AccountBeginningDebitAmountOC;
                                openingAccountEntry.TotalAccountBeginningCreditAmountOC += openingAccountEntryDetailEntity.AccountBeginningCreditAmountOC;
                                openingAccountEntry.TotalDebitAmountOC += openingAccountEntryDetailEntity.DebitAmountOC;
                                openingAccountEntry.TotalCreditAmountOC += openingAccountEntryDetailEntity.CreditAmountOC;
                                openingAccountEntry.TotalAccountBeginningDebitAmountExchange += openingAccountEntryDetailEntity.AccountBeginningDebitAmountExchange;
                                openingAccountEntry.TotalAccountBeginningCreditAmountExchange += openingAccountEntryDetailEntity.AccountBeginningCreditAmountExchange;
                                openingAccountEntry.TotalDebitAmountExchange += openingAccountEntryDetailEntity.DebitAmountExchange;
                                openingAccountEntry.TotalCreditAmountExchange += openingAccountEntryDetailEntity.CreditAmountExchange;

                                openingAccountEntryDetailEntity.RefDetailId = OpeningAccountEntryDetailDao.InsertOpeningAccountEntryDetail(openingAccountEntryDetailEntity);
                                if (openingAccountEntryDetailEntity.RefDetailId == 0)
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    scope.Dispose();
                                    return response;
                                }
                            }

                            //insert master
                            openingAccountEntry.RefId = OpeningAccountEntryDao.InsertOpeningAccountEntry(openingAccountEntry);
                            if (openingAccountEntry.RefId == 0)
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                scope.Dispose();
                                return response;
                            }

                            //insert log
                            //auditingLog.Reference = "Thêm mới CT số dư đầu kỳ cho tài khoản ";
                            //auditingLog.Amount = 0;
                            //AudittingLogDao.InsertAudittingLog(auditingLog);

                            scope.Complete();
                        }
                    }
                }
                else if (request.Action == PersistType.Update)
                {
                    if (openingAccountEntryDetails != null && openingAccountEntryDetails.Count > 0)
                    {
                        using (var scope = new TransactionScope())
                        {
                            response.Message = OpeningAccountEntryDetailDao.DeleteOpeningAccountEntryDetailByAccountCode(openingAccountEntryDetails[0].AccountCode);
                            if (response.Message != null)
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                scope.Dispose();
                                return response;
                            }
                            foreach (var openingAccountEntryDetailEntity in openingAccountEntryDetails)
                                openingAccountEntryDetailEntity.RefDetailId = OpeningAccountEntryDetailDao.InsertOpeningAccountEntryDetail(openingAccountEntryDetailEntity);

                            //insert log
                            //auditingLog.Reference = "Cập nhật CT số dư đầu kỳ cho tài khoản";
                            //auditingLog.Amount = 0;
                            //AudittingLogDao.InsertAudittingLog(auditingLog);

                            scope.Complete();
                        }
                    }
                }
                else
                {
                    using (var scope = new TransactionScope())
                    {

                        //insert log
                        //auditingLog.Reference = "Xóa CT số dư đầu kỳ cho tài khoản ";
                        //auditingLog.Amount = 0;
                        //AudittingLogDao.InsertAudittingLog(auditingLog);

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

            response.RefId = 1;
            response.Acknowledge = response.Message != null ? AcknowledgeType.Failure : AcknowledgeType.Success;
            return response;
        }
    }
}

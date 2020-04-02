/***********************************************************************
 * <copyright file="ExchangeRateFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Tuesday, August 18, 2015
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Linq;
using System.Transactions;
using TSD.AccountingSoft.BusinessComponents.Messages.Dictionary;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary;


namespace TSD.AccountingSoft.BusinessComponents.Facade.Dictionary
{
    /// <summary>
    /// ExchangeRateFacade
    /// </summary>
    public class ExchangeRateFacade
    {
        private static readonly IExchangeRateDao ExchangeRateDao = DataAccess.DataAccess.ExchangeRateDao;

        /// <summary>
        /// Gets the exchangeRates.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public ExchangeRateResponse GetExchangeRates(ExchangeRateRequest request)
        {
            var response = new ExchangeRateResponse();

            if (request.LoadOptions.Contains("ExchangeRates"))
            {
                if (request.LoadOptions.Contains("IsActive")) 
                    response.ExchangeRates = ExchangeRateDao.GetExchangeRatesByActive(true);
                else if (request.LoadOptions.Contains("Date"))
                {
                    response.ExchangeRates = ExchangeRateDao.GetExchangeRatesByDate(request.FromDate, request.ToDate);
                }
                else
                {
                    response.ExchangeRates = ExchangeRateDao.GetExchangeRates();
                }
                   
            }
            if (request.LoadOptions.Contains("ExchangeRate"))
            {
                response.ExchangeRate = request.LoadOptions.Contains("ExchangeRateId")
                    ? ExchangeRateDao.GetExchangeRate(request.ExchangeRateId)
                    : ExchangeRateDao.GetExchangeRatesByDateAndBudgetSource(request.FromDate, request.ToDate,
                        request.BudgetSourceCode);
            }
                
            
            return response;
        }

        /// <summary>
        /// Sets the exchangeRates.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public ExchangeRateResponse SetExchangeRates(ExchangeRateRequest request)
        {
            var response = new ExchangeRateResponse();

            var exchangeRateEntity = request.ExchangeRate;
            if (request.Action != PersistType.Delete)
            {
                if (!exchangeRateEntity.Validate())
                {
                    foreach (var error in exchangeRateEntity.ValidationErrors)
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
                        //Split exchangeRateEntity.BudgetSourceCode ra mảng để xác định số lần insert
                        var budgetSources = exchangeRateEntity.BudgetSourceCode.Split(',');
                        foreach (string t in budgetSources)
                        {
                            var exchangeRates = ExchangeRateDao.GetExchangeRatesByDateAndBudgetSource(exchangeRateEntity.FromDate, exchangeRateEntity.ToDate, t);
                            if (exchangeRates != null)
                            {
                                response.Acknowledge = AcknowledgeType.Failure;
                                response.Message = @"Tỷ giá từ ngày " + exchangeRateEntity.FromDate.ToShortDateString() + @" đến ngày " + exchangeRateEntity.ToDate.ToShortDateString() + " của nguồn " + t + " đã tồn tại !";
                                return response;
                            }
                            exchangeRateEntity.BudgetSourceCode = t;
                            exchangeRateEntity.Description = "Tỷ giá nguồn " + t + " - Từ ngày " + exchangeRateEntity.FromDate.ToShortDateString() + " Đến ngày " + exchangeRateEntity.ToDate.ToShortDateString();
                            exchangeRateEntity.ExchangeRateId = ExchangeRateDao.InsertExchangeRate(exchangeRateEntity);
                        }
                        scope.Complete();
                        response.Message = null;
                    }
                    
                }
                else if (request.Action == PersistType.Update)
                {
                    //Kiem tra trung du lieu
                    //lay gia tri cua BudgetSourceCode, dung ham string de split, sau do kiem tra:
                    //1. Neu Count > 1 thi kiem tra phan tu 1 va 2 co giong nhau ko, neu giong nhau thi khong kiem tra gia tri trung, neu khac nhau thi qua buoc 3
                    //2. Kiem tra gia tri trung bang cach truyen vao phan tu thu 2 de kiem tra
                    using (var scope = new TransactionScope())
                    {
                        var budgetSources = exchangeRateEntity.BudgetSourceCode.Split(',');
                        if (budgetSources.Length == 2)
                        {
                            if (budgetSources[0] == budgetSources[1])
                            {
                                exchangeRateEntity.BudgetSourceCode = budgetSources[0];
                                response.Message = ExchangeRateDao.UpdateExchangeRate(exchangeRateEntity);
                            }
                            else
                            {
                                var exchangeRates =
                                    ExchangeRateDao.GetExchangeRatesByDateAndBudgetSource(exchangeRateEntity.FromDate,
                                        exchangeRateEntity.ToDate, budgetSources[1]);
                                if (exchangeRates != null)
                                {
                                    response.Acknowledge = AcknowledgeType.Failure;
                                    response.Message = @"Tỷ giá từ ngày " +
                                                       exchangeRateEntity.FromDate.ToShortDateString() + @" đến ngày " +
                                                       exchangeRateEntity.ToDate.ToShortDateString() + " của nguồn " +
                                                       budgetSources[1] + " đã tồn tại !";
                                    return response;
                                }
                                exchangeRateEntity.BudgetSourceCode = budgetSources[1];
                                response.Message = ExchangeRateDao.UpdateExchangeRate(exchangeRateEntity);
                            }
                        }
                        if (response.Message == null)
                        {
                            scope.Complete();
                        }
                    }
                }
                else
                {
                    var exchangeRateForUpdate = ExchangeRateDao.GetExchangeRate(request.ExchangeRateId);
                    response.Message = ExchangeRateDao.DeleteExchangeRate(exchangeRateForUpdate);
                }
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
            response.ExchangeRateId = exchangeRateEntity != null ? exchangeRateEntity.ExchangeRateId : 0;
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

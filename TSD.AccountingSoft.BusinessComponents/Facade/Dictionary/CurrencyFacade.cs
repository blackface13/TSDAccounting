/***********************************************************************
 * <copyright file="CurrencyFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuanHM
 * Email:    Tuanhm@buca.vn
 * Website:
 * Create Date: Friday, March 7, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Linq;
using TSD.AccountingSoft.BusinessComponents.Messages.Dictionary;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary;


namespace TSD.AccountingSoft.BusinessComponents.Facade.Dictionary
{
    /// <summary>
    /// Class CurrencyFacade.
    /// </summary>
    public class CurrencyFacade
    {
        /// <summary>
        /// The currency DAO
        /// </summary>
        private static readonly ICurrencyDao CurrencyDao = DataAccess.DataAccess.CurrencyDao;
        /// <summary>
        /// Gets the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>CurrencyResponse.</returns>
        public CurrencyResponse GetCurrencies(CurrencyRequest request)
        {
            var response = new CurrencyResponse();

            if (request.LoadOptions.Contains("Currencies"))
            {
                if (request.LoadOptions.Contains("IsActive"))
                {
                    response.Currencies = CurrencyDao.GetCurrenciesByActive();
                }
                else
                {
                    response.Currencies = request.LoadOptions.Contains("CurrenciesIsMain") ? CurrencyDao.GetCurrenciesByIsMain() : CurrencyDao.GetCurrencies();
                }
            }
            if (request.LoadOptions.Contains("Currency"))
            {
                response.Currency = request.LoadOptions.Contains("CurrencyCode") ? CurrencyDao.GetCurrenciesByCurrencyCode(request.CurrencyCode) : CurrencyDao.GetCurrency(request.CurrencyId);
            }

            return response;
        }

        /// <summary>
        /// Set the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>CurrencyResponse.</returns>
        public CurrencyResponse SetCurrencies(CurrencyRequest request)
        {
            var response = new CurrencyResponse();
            var mapper = request.Currency;
            if (request.Action != PersistType.Delete)
            {
                if (!mapper.Validate())
                {
                    foreach (string error in mapper.ValidationErrors)
                        response.Message += error + Environment.NewLine;
                    response.Acknowledge = AcknowledgeType.Failure;
                    return response;
                }
            }
            try
            {
                if (request.Action == PersistType.Insert)
                {
                    var currency = CurrencyDao.GetCurrenciesByCurrencyCode(mapper.CurrencyCode);
                    if (currency != null)
                    {
                        response.Acknowledge = AcknowledgeType.Failure;
                        response.Message = @"Mã tiền tệ " + mapper.CurrencyCode + @" đã tồn tại !";
                        return response;
                    }
                    mapper.CurrencyId = CurrencyDao.InsertCurrency(mapper);
                    response.Message = null;
                }
                else if (request.Action == PersistType.Update)
                    response.Message = CurrencyDao.UpdateCurrency(mapper);
                else
                {
                    var obj = CurrencyDao.GetCurrency(request.CurrencyId);
                    response.Message = CurrencyDao.DeleteCurrency(obj);
                }
            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
            response.CurrencyId = mapper != null ? mapper.CurrencyId : 0;
            response.Acknowledge = response.Message != null ? AcknowledgeType.Failure : AcknowledgeType.Success;
            return response;
        }
    }
}

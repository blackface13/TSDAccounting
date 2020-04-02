/***********************************************************************
 * <copyright file="CommonFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Friday, May 30, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Linq;
using TSD.AccountingSoft.BusinessComponents.Messages;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.DataAccess.IEntitiesDao;

namespace TSD.AccountingSoft.BusinessComponents.Facade
{
    /// <summary>
    /// Common Facade
    /// </summary>
    public class CommonFacade
    {
        /// <summary>
        /// The common DAO
        /// </summary>
        private static readonly ICommonDao CommonDao = DataAccess.DataAccess.CommonDao;

        /// <summary>
        /// Gets the identifier by code.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public CommonResponse GetIdByCode(CommonRequest request)
        {
            var response = new CommonResponse();
            if (request.LoadOptions.Contains("QueryString"))
            {
                response.Id = CommonDao.GetIdByCode(request.QueryString);
            }
            else
            {
                response.Id = CommonDao.GetIdByCode(request.TableName, request.IdFieldName, request.CodeFieldName,
                    request.CodeFieldValue);
            }

            return response;
        }

        /// <summary>
        /// Resets the automatic increment.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public CommonResponse ResetAutoIncrement(CommonRequest request)
        {
            var response = new CommonResponse
                           {
                               ResetIncrementSuccess = CommonDao.ResetAutoIncrement(request.TableName,
                                   request.StartIncrementNumber)
                           };
            return response;
        }

        /// <summary>
        /// Updates the amount exchange.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public CommonResponse UpdateAmountExchange(CommonRequest request)
        {
            var response = new CommonResponse
            {
                Message = CommonDao.UpdateAmountExchange(request.ExchangeRate, request.CurrencyDecimalDigits,
                    request.FromDate, request.ToDate)
            };

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

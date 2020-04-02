/***********************************************************************
 * <copyright file="CalculateClosingFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: Thursday, December 25, 2014
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
    /// CalculateClosingFacade
    /// </summary>
    public class CalculateClosingFacade
    {
        /// <summary>
        /// The calculate closing DAO
        /// </summary>
        private static readonly ICalculateClosingDao CalculateClosingDao = DataAccess.DataAccess.CalculateClosingDao;

        /// <summary>
        /// Gets the GetCalculate Closing.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public CaculateClosingResponse GetCalculateClosing(CalculateClosingRequest request)
        {
            var response = new CaculateClosingResponse();

            if (request.LoadOptions.Contains("CalculateClosing"))
            {
                response.CalculateClosing = CalculateClosingDao.GetCalculateClosing(request.PaymentAccountCode, request.WhereClause, request.CurrencyCode, request.ToDate, request.IsApproximate, request.RefId, request.RefTypeId);
            }
            return response;
        }


        public CaculateClosingResponse AmountExist(CalculateClosingRequest request)
        {
            var response = new CaculateClosingResponse();

            if (request.LoadOptions.Contains("AmountExist"))
            {
                response.CalculateClosing = CalculateClosingDao.AmountExist(request.PaymentAccountCode, request.CurrencyCode);
            }
            return response;
        }



    }
}

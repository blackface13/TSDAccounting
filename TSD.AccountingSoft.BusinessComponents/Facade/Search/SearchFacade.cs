/***********************************************************************
 * <copyright file="SearchFacade.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 24 March 2014
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
using TSD.AccountingSoft.BusinessComponents.Messages.Search;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Search;

namespace TSD.AccountingSoft.BusinessComponents.Facade.Search
{
    /// <summary>
    /// SearchFacade
    /// </summary>
    public class SearchFacade
    {
        private static readonly ISearchDao SearchDao = DataAccess.DataAccess.SearchDao;

        /// <summary>
        /// Gets the automatic businesses.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public SearchResponse GetSearchs(SearchRequest request) 
        {
            var response = new SearchResponse();
            response.Searchs = SearchDao.GetSearch(request.WhereClause, request.FromDate,request.ToDate,request.CurrencyCode,request.DepartmentCode,request.FixedAssetCode,request.BudgetGroupCode);
            return response;
        }

    }
}

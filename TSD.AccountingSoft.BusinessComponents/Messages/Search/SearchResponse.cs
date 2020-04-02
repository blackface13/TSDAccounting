using System.Collections.Generic;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Business.Inventory;
using TSD.AccountingSoft.BusinessEntities.Business.Search;

namespace TSD.AccountingSoft.BusinessComponents.Messages.Search
{
    public class SearchResponse : ResponseBase
    {
        /// <summary>
        /// The estimates
        /// </summary>
        public IList<SearchEntity> Searchs;  

        /// <summary>
        /// The estimate
        /// </summary>
        public SearchEntity Search; 

        /// <summary>
        /// The reference identifier
        /// </summary>
        public long RefId;
    }
}

/***********************************************************************
 * <copyright file="RequestBase.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 07 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

namespace TSD.AccountingSoft.BusinessComponents.Messages.MessageBase
{
    /// <summary>
    /// class RequestBase
    /// </summary>
    public class RequestBase
    {
        /// <summary>
        /// Load options indicated what types are to be returned in the request.
        /// </summary>
        public string[] LoadOptions;

        /// <summary>
        /// Crud action: Create, Read, Update, Delete
        /// </summary>
        public PersistType Action;

        /// <summary>
        /// The store produre
        /// </summary>
        public string StoreProdure;

        /// <summary>
        /// The is convert data
        /// </summary>
        public bool IsConvertData;
    }
}

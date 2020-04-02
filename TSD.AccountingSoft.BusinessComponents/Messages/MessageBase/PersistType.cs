/***********************************************************************
 * <copyright file="PersistType.cs" company="BUCA JSC">
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
    /// enum PersistType
    /// </summary>
    public enum PersistType
    {
        /// <summary>
        /// The insert
        /// </summary>
        Insert = 1,

        /// <summary>
        /// The update
        /// </summary>
        Update = 2,

        /// <summary>
        /// The delete
        /// </summary>
        Delete = 3,

        /// <summary>
        /// The scalar
        /// </summary>
        Scalar = 4
    }
}

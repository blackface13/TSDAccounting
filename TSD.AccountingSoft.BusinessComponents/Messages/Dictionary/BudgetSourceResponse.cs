/***********************************************************************
 * <copyright file="BudgetSourceResponse.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   THODD
 * Email:    thodd@buca.vn
 * Website:
 * Create Date: 07 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Dictionary;


namespace TSD.AccountingSoft.BusinessComponents.Messages.Dictionary
{

    /// <summary>
    /// Class BudgetSourceResponse.
    /// </summary>
    public class BudgetSourceResponse : ResponseBase
    {
        /// <summary>
        /// The budget sources
        /// </summary>
        public IList<BudgetSourceEntity> BudgetSources;

        /// <summary>
        /// The budget source
        /// </summary>
        public BudgetSourceEntity BudgetSource;

        /// <summary>
        /// The budget source identifier
        /// </summary>
        public int BudgetSourceId;
    }
}

/***********************************************************************
 * <copyright file="SqlServerFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Thursday, February 26, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  07/03/2014       Author    Tudt           Description: Coding standard
 * 
 * ************************************************************************/

using System.Collections.Generic;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Dictionary;


namespace TSD.AccountingSoft.BusinessComponents.Messages.Dictionary
{
    /// <summary>
    /// Class BudgetItemResponse.
    /// </summary>
    public class BudgetItemResponse : ResponseBase
    {
        /// <summary>
        /// The budget item
        /// </summary>
        public IList<BudgetItemEntity> BudgetItems;

        /// <summary>
        /// The budget item
        /// </summary>
        public BudgetItemEntity BudgetItem;

        /// <summary>
        /// The budget item identifier
        /// </summary>
        public int BudgetItemId;

        /// <summary>
        /// The budget item type
        /// </summary>
        public int BudgetItemType;
    }
}

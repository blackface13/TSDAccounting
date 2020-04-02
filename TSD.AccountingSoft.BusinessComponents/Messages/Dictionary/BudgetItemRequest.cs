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

using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Dictionary;


namespace TSD.AccountingSoft.BusinessComponents.Messages.Dictionary
{
    /// <summary>
    /// Class BudgetItemRequest.
    /// </summary>
    public class BudgetItemRequest : RequestBase
    {
        /// <summary>
        /// Gets or sets the budget item identifier.
        /// </summary>
        /// <value>The budget item identifier.</value>
        public int BudgetItemId { get; set; }

        /// <summary>
        /// The budget item
        /// </summary>
        public BudgetItemEntity BudgetItem;

        /// <summary>
        /// The budget item type
        /// </summary>
        /// <value>The type of the budget item.</value>
        public int BudgetItemType { get; set; }

        /// <summary>
        /// The budget item is receipt or not
        /// </summary>
        /// <value><c>true</c> if this instance is receipt; otherwise, <c>false</c>.</value>
        public bool IsReceipt { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is active].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is active]; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }
    }
}

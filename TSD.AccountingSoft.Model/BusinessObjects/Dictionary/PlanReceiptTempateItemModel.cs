/***********************************************************************
 * <copyright file="SqlServerFixedAssetDao.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuDT
 * Email:    tudt@buca.vn
 * Website:
 * Create Date: Tuesday, June 13, 2017
 * Usage: 
 * 
 * RevisionHistory: 
 * Date  13/06/2017       Author    Tudt           Description: Coding standard
 * 
 * ************************************************************************/

namespace TSD.AccountingSoft.Model.BusinessObjects.Dictionary
{
    /// <summary>
    /// PlanReceiptTempateItem
    /// </summary>
    public class PlanReceiptTempateItemModel
    {
        /// <summary>
        /// Gets or sets the plan receipt tempate item identifier.
        /// </summary>
        /// <value>
        /// The plan receipt tempate item identifier.
        /// </value>
        public int PlanReceiptTempateItemId { get; set; }

        /// <summary>
        /// Gets or sets the name of the item.
        /// </summary>
        /// <value>
        /// The name of the item.
        /// </value>
        public string ItemName { get; set; }

        /// <summary>
        /// Gets or sets the number order.
        /// </summary>
        /// <value>
        /// The number order.
        /// </value>
        public string NumberOrder { get; set; }

        /// <summary>
        /// Gets or sets the font style.
        /// </summary>
        /// <value>
        /// The font style.
        /// </value>
        public string FontStyle { get; set; }

        /// <summary>
        /// Gets or sets the budget item code list.
        /// </summary>
        /// <value>
        /// The budget item code list.
        /// </value>
        public string BudgetItemCodeList { get; set; }
    }
}

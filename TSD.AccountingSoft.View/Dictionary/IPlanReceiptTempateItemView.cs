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

namespace TSD.AccountingSoft.View.Dictionary
{
    /// <summary>
    /// IPlanReceiptTempateItemView
    /// </summary>
   public interface IPlanReceiptTempateItemView : IView
    {
        /// <summary>
        /// Gets or sets the plan receipt tempate item identifier.
        /// </summary>
        /// <value>
        /// The plan receipt tempate item identifier.
        /// </value>
       int PlanReceiptTempateItemId { get; set; }

       /// <summary>
       /// Gets or sets the name of the item.
       /// </summary>
       /// <value>
       /// The name of the item.
       /// </value>
       string ItemName { get; set; }

       /// <summary>
       /// Gets or sets the number order.
       /// </summary>
       /// <value>
       /// The number order.
       /// </value>
       string NumberOrder { get; set; }

       /// <summary>
       /// Gets or sets the budget item code list.
       /// </summary>
       /// <value>
       /// The budget item code list.
       /// </value>
       string BudgetItemCodeList { get; set; }

       /// <summary>
       /// Gets or sets the font style.
       /// </summary>
       /// <value>
       /// The font style.
       /// </value>
       string FontStyle { get; set; }
    }
}

using System.Collections.Generic;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;

namespace TSD.AccountingSoft.View.Dictionary
{
    /// <summary>
    /// IPlanReceiptTempateItemsView
    /// </summary>
    public interface IPlanReceiptTempateItemsView : IView
    {
        /// <summary>
        /// Sets the plan receipt tempate item.
        /// </summary>
        /// <value>
        /// The plan receipt tempate item.
        /// </value>
        IList<PlanReceiptTempateItemModel> PlanReceiptTempateItems { get; set; }
    }
}

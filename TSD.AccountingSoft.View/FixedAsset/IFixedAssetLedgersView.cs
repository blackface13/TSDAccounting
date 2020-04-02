using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TSD.AccountingSoft.Model.BusinessObjects.FixedAsset;

namespace TSD.AccountingSoft.View.FixedAsset
{
    /// <summary>
    /// interface IFixedAssetIncrementsView
    /// </summary>
    public interface IFixedAssetLedgersView : IView
    {
        /// <summary>
        /// Sets the fixed asset increment.
        /// </summary>
        /// <value>
        /// The fixed asset increment.
        /// </value>
        IList<FixedAssetLedgerModel> FixedAssetLedgers { set; }
    }
}

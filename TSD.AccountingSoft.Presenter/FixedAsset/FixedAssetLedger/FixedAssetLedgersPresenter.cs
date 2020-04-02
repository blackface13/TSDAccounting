using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TSD.AccountingSoft.Model.BusinessObjects.FixedAsset;
using TSD.AccountingSoft.View.FixedAsset;

namespace TSD.AccountingSoft.Presenter.FixedAsset.FixedAssetLedger
{
    /// <summary>
    /// class FixedAssetLedgersPresenter
    /// </summary>
    public class FixedAssetLedgersPresenter : Presenter<IFixedAssetLedgersView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FixedAssetLedgersPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public FixedAssetLedgersPresenter(IFixedAssetLedgersView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays the by year.
        /// </summary>
        public IList<FixedAssetLedgerModel>  Display(int fixedAssetId)
        {
            var fixedAssetLedgers = Model.GetFixedAssetLedgerByFixedAssets(fixedAssetId);
            return fixedAssetLedgers;
        }

 
    }
}

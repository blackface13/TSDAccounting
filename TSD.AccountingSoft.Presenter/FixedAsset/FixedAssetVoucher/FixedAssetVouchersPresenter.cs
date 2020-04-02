using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TSD.AccountingSoft.View.FixedAsset;

namespace TSD.AccountingSoft.Presenter.FixedAsset.FixedAssetVoucher
{
    /// <summary>
    /// class FixedAssetVouchersPresenter
    /// </summary>
    public class FixedAssetVouchersPresenter : Presenter<IFixedAssetVouchersView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FixedAssetVouchersPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public FixedAssetVouchersPresenter(IFixedAssetVouchersView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays the by year.
        /// </summary>
        public void Display(string fixedAssetId)
        {
            View.FixedAssetVouchers = Model.GetFixedAssetVoucherByFixedAssets(int.Parse(fixedAssetId));
        }
    }
}

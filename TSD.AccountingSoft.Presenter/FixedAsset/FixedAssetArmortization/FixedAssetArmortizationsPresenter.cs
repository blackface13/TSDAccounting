/***********************************************************************
 * <copyright file="FixedAssetArmortizationsPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 10 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using TSD.AccountingSoft.View.FixedAsset;


namespace TSD.AccountingSoft.Presenter.FixedAsset.FixedAssetArmortization
{
    /// <summary>
    /// class FixedAssetArmortizationsPresenter
    /// </summary>
   public class FixedAssetArmortizationsPresenter : Presenter<IFixedAssetArmortizationsView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FixedAssetArmortizationsPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public FixedAssetArmortizationsPresenter(IFixedAssetArmortizationsView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            View.FixedAssetArmortizations = Model.GetFixedAssetArmortizations();
        }

        /// <summary>
        /// Displays the include details.
        /// </summary>
        public void DisplayIncludeDetails()
        {
            View.FixedAssetArmortizations = Model.GetFixedAssetArmortizationsIncludeDetail();
        }

        /// <summary>
        /// Displays the include details.
        /// </summary>
        public void DisplayIncludeDetails(string refDate)
        {
            View.FixedAssetArmortizations = Model.GetFixedAssetArmortizationsIncludeDetail(refDate);
        }

        /// <summary>
        /// Displays the specified reference date.
        /// </summary>
        /// <param name="refDate">The reference date.</param>
        public void Display(string refDate)
        {
            View.FixedAssetArmortizations = Model.GetFixedAssetArmortizations(refDate);
        }
    }
}

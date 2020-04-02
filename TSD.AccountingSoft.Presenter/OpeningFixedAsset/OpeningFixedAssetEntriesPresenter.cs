/***********************************************************************
 * <copyright file="OpeningFixedAssetEntriesPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: 12 December 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Linq;
using TSD.AccountingSoft.View.OpeningFixedAssetEntry;

namespace TSD.AccountingSoft.Presenter.OpeningFixedAsset
{
    /// <summary>
    ///     OpeningAccountEntriesPresenter
    /// </summary>
    public class OpeningFixedAssetEntriesPresenter : Presenter<IOpeningFixedAssetEntriesView>
    {
        /// <summary>
        /// </summary>
        /// <param name="view">The view.</param>
        public OpeningFixedAssetEntriesPresenter(IOpeningFixedAssetEntriesView view)
            : base(view)
        {
        }

        /// <summary>
        ///     Displays this instance.
        /// </summary>
        public void Display(string accountCode)
        {
            View.OpeningFixedAssetEntries = Model.GetOpeningFixedAssetEntries(accountCode);
        }

        /// <summary>
        ///     Displays this instance.
        /// </summary>
        public void Display()
        {
            View.OpeningFixedAssetEntries = Model.GetOpeningFixedAssetEntries();
        }

        /// <summary>
        ///     Saves this instance.
        /// </summary>
        /// <returns></returns>
        public long Save()
        {
            var openingFixedAssetEntryModel = View.OpeningFixedAssetEntries;
            return Model.UpdateOpeningFixedAssetEntriesDetail(openingFixedAssetEntryModel.ToList());
        }
    }
}
/***********************************************************************
 * <copyright file="FixedAssetIncrementsPresenter.cs" company="BUCA JSC">
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

using System.Collections.Generic;
using TSD.AccountingSoft.Model.BusinessObjects.FixedAsset;
using TSD.AccountingSoft.View.FixedAsset;


namespace TSD.AccountingSoft.Presenter.FixedAsset.FixedAssetIncrement
{
    /// <summary>
    /// class FixedAssetIncrementsPresenter
    /// </summary>
    public class FixedAssetIncrementsPresenter : Presenter<IFixedAssetIncrementsView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FixedAssetIncrementsPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public FixedAssetIncrementsPresenter(IFixedAssetIncrementsView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display(long refTypeId)
        {
            View.FixedAssetIncrements = Model.GetFixedAssetIncrementsByRefTypeId(refTypeId);
        }

        /// <summary>
        /// Displays the by year.
        /// </summary>
        public void Display()
        {
            View.FixedAssetIncrements = Model.GetFixedAssetIncrements();
        }

        /// <summary>
        /// Displays the by year.
        /// </summary>
        /// <param name="refTypeId">The reference type identifier.</param>
        /// <param name="refDate">The post date.</param>
        public void Display(int refTypeId, string refDate)
        {
            View.FixedAssetIncrements = Model.GetFixedAssetIncrementsByYearOfPostDate(refTypeId, refDate);
        }

        /// <summary>
        /// Displays the specified fixed asset identifier.
        /// </summary>
        public IList<FixedAssetArmortizationDetailModel> DisplayFaArmortization(long refId)
        {
            var fixedAsset = Model.GetFArmortizationByFAIncrements(refId);
            return fixedAsset;
        }

        /// <summary>
        /// Displays the specified fixed asset identifier.
        /// </summary>
        public IList<FixedAssetDecrementDetailModel> DisplayFaInDecreamnet(long refId)
        {
            var fixedAsset = Model.GetFADecrementByFAIncrements(refId);
            return fixedAsset;
        }

        /// <summary>
        /// Displays the voucher detail.
        /// LinhMC add 30.9.2016
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        public void DisplayVoucherDetail(long refId)
        {
            var voucher = Model.GetFixedAssetIncrement(refId);
            if (voucher != null)
            {
                View.FixedAssetIncrementDetails = voucher.FixedAssetIncrementDetails;
            }
        }
    }
}

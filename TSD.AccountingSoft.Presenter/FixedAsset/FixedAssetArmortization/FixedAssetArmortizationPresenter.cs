/***********************************************************************
 * <copyright file="FixedAssetArmortizationPresenter.cs" company="BUCA JSC">
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
using System.Linq;
using TSD.AccountingSoft.Model.BusinessObjects.FixedAsset;
using TSD.AccountingSoft.View.FixedAsset;


namespace TSD.AccountingSoft.Presenter.FixedAsset.FixedAssetArmortization
{
    /// <summary>
    /// FixedAssetArmortizationPresenter
    /// </summary>
    public class FixedAssetArmortizationPresenter : Presenter<IFixedAssetArmortizationView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FixedAssetArmortizationPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public FixedAssetArmortizationPresenter(IFixedAssetArmortizationView view)
            : base(view)
        {
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        public long Save()
        {
            var fixedAssetArmortization = new FixedAssetArmortizationModel
            {
                RefId = View.RefId,
                RefNo = View.RefNo,
                PostedDate = View.PostedDate,
                RefDate = View.RefDate,
                RefTypeId = View.RefTypeId,
                JournalMemo = View.JournalMemo,
                CurrencyCode = View.CurrencyCode,
                FixedAssetArmortizationDetails = View.FixedAssetArmortizationDetails
            };
            return View.RefId == 0 ? Model.AddFixedAssetArmortization(fixedAssetArmortization) : Model.UpdateFixedAssetArmortization(fixedAssetArmortization);
        }

        /// <summary>
        /// Displays the specified reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        public void Display(long refId)
        {
            var fixedAssetArmortization = Model.GetFixedAssetArmortization(refId);

            View.RefId = fixedAssetArmortization.RefId;
            View.RefNo = fixedAssetArmortization.RefNo;
            View.PostedDate = fixedAssetArmortization.PostedDate;
            View.RefDate = fixedAssetArmortization.RefDate;
            View.RefTypeId = fixedAssetArmortization.RefTypeId;
            View.JournalMemo = fixedAssetArmortization.JournalMemo;
            View.FixedAssetArmortizationDetails = fixedAssetArmortization.FixedAssetArmortizationDetails;
        }

        /// <summary>
        /// Displays the specified reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="yearOfDepreciation">The year of depreciation.</param>
        public void Display(long refId, string currencyCode, int yearOfDepreciation)
        {
            var fixedAssetArmortization = Model.GetFixedAssetArmortization(refId, currencyCode, yearOfDepreciation);

            View.FixedAssetArmortizationDetails = fixedAssetArmortization.FixedAssetArmortizationDetails;
        }

        /// <summary>
        /// Displays the specified reference date.
        /// </summary>
        /// <param name="refDate">The reference date.</param>
        /// <returns></returns>
        public List<FixedAssetArmortizationModel> Display(string refDate)
        {
            var fixedAssetArmortizations = Model.GetFixedAssetArmortizations(refDate);

            return fixedAssetArmortizations.ToList();
        }

        /// <summary>
        /// Displays the specified reference date.
        /// </summary>
        /// <param name="refDate">The reference date.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns></returns>
        public List<FixedAssetArmortizationModel> Display(string refDate, string currencyCode)
        {
            var fixedAssetArmortizations = Model.GetFixedAssetArmortizations(refDate, currencyCode);

            return fixedAssetArmortizations.ToList();
        }

        /// <summary>
        /// Deletes the specified reference identifier.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        /// <returns></returns>
        public long Delete(long refId)
        {
            return Model.DeleteFixedAssetArmortization(refId);
        }
    }
}

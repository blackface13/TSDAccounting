/***********************************************************************
 * <copyright file="OpeningFixedAssetEntryPresenter.cs" company="BUCA JSC">
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

using System.Collections.Generic;
using TSD.AccountingSoft.Model.BusinessObjects.Opening;
using TSD.AccountingSoft.View.OpeningFixedAssetEntry;

namespace TSD.AccountingSoft.Presenter.OpeningFixedAsset
{
    /// <summary>
    /// class OpeningFixedAssetEntryPresenter
    /// </summary>
    public class OpeningFixedAssetEntryPresenter : Presenter<IOpeningFixedAssetEntryView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OpeningFixedAssetEntryPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public OpeningFixedAssetEntryPresenter(IOpeningFixedAssetEntryView view)
            : base(view)
        {
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns> 
        public long Save()
        {
            var openingFixedAssetEntryModel = new List<OpeningFixedAssetEntryModel>
            {
                new OpeningFixedAssetEntryModel
                {
                RefId = View.RefId,
                RefNo = View.RefNo,
                RefTypeId = View.RefTypeId,
                PostedDate = View.PostedDate,
                FixedAssetId = View.FixedAssetId,
                DepartmentId = View.DepartmentId,
                LifeTime = View.LifeTime,
                IncrementDate = View.IncrementDate,
                Unit = View.Unit,
                UsedDate = View.UsedDate,
                CurrencyCode = View.CurrencyCode,
                ExchangeRate = View.ExchangeRate,
                OrgPriceAccount = View.OrgPriceAccount,
                OrgPriceDebitAmount = View.OrgPriceDebitAmount,
                OrgPriceDebitAmountUSD = View.OrgPriceDebitAmountUSD,
                DepreciationAccount = View.DepreciationAccount,
                DepreciationCreditAmount = View.DepreciationCreditAmount,
                DepreciationCreditAmountUSD = View.DepreciationCreditAmountUSD,
                CapitalAccount = View.CapitalAccount,
                CapitalCreditAmount = View.CapitalCreditAmount,
                CapitalCreditAmountUSD = View.CapitalCreditAmountUSD,
                RemainingAmount = View.RemainingAmount,
                RemainingAmountUSD = View.RemainingAmountUSD,
                BudgetChapterCode = View.BudgetChapterCode,
                Description = View.Description,
                Quantity = View.Quantity,
                BudgetSourceCode = View.BudgetSourceCode
                }
            };
            return Model.UpdateOpeningFixedAssetEntriesDetail(openingFixedAssetEntryModel);
        }

        /// <summary>
        /// Displays the specified account code.
        /// </summary>
        /// <param name="accountCode">The account code.</param>
        public void Display(string accountCode)
        {
            var openingFixedAssetEntry = Model.GetOpeningFixedAssetEntries(accountCode);
            View.OpeningFixedAssetEntries = openingFixedAssetEntry;
        }
    }
}

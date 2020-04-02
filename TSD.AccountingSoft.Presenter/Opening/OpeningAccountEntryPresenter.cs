/***********************************************************************
 * <copyright file="OpeningAccountEntryPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 28 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using TSD.AccountingSoft.Model.BusinessObjects.Opening;
using TSD.AccountingSoft.View.OpeningAccountEntry;


namespace TSD.AccountingSoft.Presenter.Opening
{
    /// <summary>
    /// class OpeningAccountEntryPresenter
    /// </summary>
    public class OpeningAccountEntryPresenter : Presenter<IOpeningAccountEntryView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OpeningAccountEntryPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public OpeningAccountEntryPresenter(IOpeningAccountEntryView view)
            : base(view)
        {
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        public long Save()
        {
            var openingAccountEntryModel = new OpeningAccountEntryModel
            {
                RefId = View.RefId,
                RefTypeId = View.RefTypeId,
                PostedDate = View.PostedDate,
                AccountCode = View.AccountCode,
                OpeningAccountEntryDetails = View.OpeningAccountEntryDetails
            };
            return Model.UpdateOpeningAccountEntry(openingAccountEntryModel);
        }

        /// <summary>
        /// Displays the specified account code.
        /// </summary>
        /// <param name="accountCode">The account code.</param>
        public void Display(string accountCode)
        {
            var openingAccountEntry = Model.GetOpeningAccountEntry(accountCode);

            View.RefId = openingAccountEntry.RefId;
            View.RefTypeId = openingAccountEntry.RefTypeId;
            View.PostedDate = openingAccountEntry.PostedDate;
            View.AccountCode = openingAccountEntry.AccountCode;
            View.TotalAccountBeginningDebitAmountOC = openingAccountEntry.TotalAccountBeginningDebitAmountOC;
            View.TotalAccountBeginningCreditAmountOC = openingAccountEntry.TotalAccountBeginningCreditAmountOC;
            View.TotalDebitAmountOC = openingAccountEntry.TotalDebitAmountOC;
            View.TotalCreditAmountOC = openingAccountEntry.TotalCreditAmountOC;
            View.TotalAccountBeginningDebitAmountExchange = openingAccountEntry.TotalAccountBeginningDebitAmountExchange;
            View.TotalAccountBeginningCreditAmountExchange = openingAccountEntry.TotalAccountBeginningCreditAmountExchange;
            View.TotalDebitAmountExchange = openingAccountEntry.TotalDebitAmountExchange;
            View.TotalCreditAmountExchange = openingAccountEntry.TotalCreditAmountExchange;
            View.OpeningAccountEntryDetails = openingAccountEntry.OpeningAccountEntryDetails;
        }
    }
}

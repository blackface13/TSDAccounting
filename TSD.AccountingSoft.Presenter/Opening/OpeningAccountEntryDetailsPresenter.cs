/***********************************************************************
 * <copyright file="OpeningAccountEntryDetailsPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 25 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using TSD.AccountingSoft.View.OpeningAccountEntry;


namespace TSD.AccountingSoft.Presenter.Opening
{
    /// <summary>
    /// OpeningAccountEntryDetailsPresenter
    /// </summary>
    public class OpeningAccountEntryDetailsPresenter : Presenter<IOpeningAccountEntryDetailsView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OpeningAccountEntryDetailsPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public OpeningAccountEntryDetailsPresenter(IOpeningAccountEntryDetailsView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays the specified account code.
        /// </summary>
        /// <param name="accountCode">The account code.</param>
        public void Display(string accountCode)
        {
            View.OpeningAccountEntryDetails = Model.GetOpeningAccountEntryDetails(accountCode);
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        public int Save()
        {
            return (int)Model.AddOpeningAccountEntryDetails(View.OpeningAccountEntryDetails);
        }
    }
}
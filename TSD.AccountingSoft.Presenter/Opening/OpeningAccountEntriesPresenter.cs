/***********************************************************************
 * <copyright file="OpeningAccountEntriesPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 24 April 2014
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
    /// OpeningAccountEntriesPresenter
    /// </summary>
    public class OpeningAccountEntriesPresenter : Presenter<IOpeningAccountEntriesView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OpeningAccountEntriesPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public OpeningAccountEntriesPresenter(IOpeningAccountEntriesView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            View.OpeningAccountEntries = Model.GetOpeningAccountEntries();
        }
    }
}

/***********************************************************************
 * <copyright file="GeneralLedgerPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 13 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using TSD.AccountingSoft.View.Cash;


namespace TSD.AccountingSoft.Presenter.Cash.GeneralLedger
{
    /// <summary>
    /// class GeneralLedgerPresenter
    /// </summary>
    public class GeneralLedgerPresenter : Presenter<IGeneralLedgerView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GeneralLedgerPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public GeneralLedgerPresenter(IGeneralLedgerView view)
            : base(view)
        {
        }
    }
}

/***********************************************************************
 * <copyright file="VoucherTypesPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 24 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using TSD.AccountingSoft.View.Dictionary;


namespace TSD.AccountingSoft.Presenter.Dictionary.VoucherType
{
    /// <summary>
    /// class VoucherTypesPresenter
    /// </summary>
    public class VoucherTypesPresenter : Presenter<IVoucherTypesView>
    {
        /// <summary>
        /// VoucherTypets the presenter.
        /// </summary>
        /// <param name="view">The view.</param>
        public VoucherTypesPresenter(IVoucherTypesView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            View.VoucherTypes = Model.GetVoucherTypes();
        }

        /// <summary>
        /// Displays the active.
        /// </summary>
        public void DisplayActive()
        {
            View.VoucherTypes = Model.GetVoucherTypesActive();
        }
    }
}

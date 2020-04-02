/***********************************************************************
 * <copyright file="CapitalAllocatesPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   TuanHM
 * Email:    Tuanhm@buca.vn
 * Website:
 * Create Date: Friday, March 7, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using TSD.AccountingSoft.View.Dictionary;


namespace TSD.AccountingSoft.Presenter.Dictionary.CapitalAllocate  
{
    /// <summary>
    /// Class CapitalAllocatesPresenter.
    /// </summary>
    public class CapitalAllocatesPresenter : Presenter<ICapitalAllocatesView> 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CapitalAllocatesPresenter" /> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public CapitalAllocatesPresenter(ICapitalAllocatesView view)  
            : base(view)
        {
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            View.CapitalAllocates = Model.GetCapitalAllocates();
        }

        /// <summary>
        /// Displays the active.
        /// </summary>
        public void DisplayActive()
        {
            View.CapitalAllocates = Model.GetCapitalAllocatesActive();
        }
 
    }
}

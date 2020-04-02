/***********************************************************************
 * <copyright file="AccountingObjectsPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Hoàng Bích Sơn
 * Email:    sonhb@buca.vn
 * Website:
 * Create Date: Wednesday, March 12, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using TSD.AccountingSoft.View.Dictionary;


namespace TSD.AccountingSoft.Presenter.Dictionary.AccountingObject
{

    /// <summary>
    /// AccountingObjectsPresenter clas
    /// </summary>
    public class AccountingObjectsPresenter : Presenter<IAccountingObjectsView>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountingObjectsPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public AccountingObjectsPresenter(IAccountingObjectsView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        
        {
            View.AccountingObjects = Model.GetAccountingObjects();
        }

        /// <summary>
        /// Displays the active.
        /// </summary>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        public void DisplayActive(bool isActive)
        {
            View.AccountingObjects = Model.GetAccountingObjectsByActive(isActive);
        }

        public void DisplayForList()
        {
            View.AccountingObjects = Model.GetAccountingObjectsForList();
        }
    }
}

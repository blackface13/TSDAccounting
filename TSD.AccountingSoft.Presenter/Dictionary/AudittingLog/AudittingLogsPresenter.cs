/***********************************************************************
 * <copyright file="AudittingLogsPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 12 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using TSD.AccountingSoft.View.Dictionary;

namespace TSD.AccountingSoft.Presenter.Dictionary.AudittingLog
{
    /// <summary>
    /// AudittingLogsPresenter
    /// </summary>
    public class AudittingLogsPresenter : Presenter<IAudittingLogsView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AudittingLogsPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public AudittingLogsPresenter(IAudittingLogsView view)
            : base(view)
        {
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            View.AudittingLogs = Model.GetAudittingLogs();
        }
    }
}

/***********************************************************************
 * <copyright file="AudittingLogPresenter.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 04 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.View.Dictionary;

namespace TSD.AccountingSoft.Presenter.Dictionary.AudittingLog
{
    /// <summary>
    /// 
    /// </summary>
    public class AudittingLogPresenter : Presenter<IAudittingLogView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AudittingLogPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public AudittingLogPresenter(IAudittingLogView view)
            : base(view)
        {
        }

        /// <summary>
        /// Deletes the specified bank identifier.
        /// </summary>
        /// <param name="bankId">The bank identifier.</param>
        /// <returns></returns>
        public int Delete(int bankId)
        {
            return Model.DeleteAudittingLog(bankId);
        }

        public int Save()
        {
            var auditing = new AudittingLogModel
            {
               EventAction = View.EventAction,
               ComputerName = View.ComputerName,
               Amount = View.Amount,
               ComponentName = View.ComponentName,
               EventTime = View.EventTime,
               LoginName = View.LoginName,
               Reference = View.Reference,
               EventId = View.EventId
            };
            return Model.AddAuditingLog(auditing);
        }
    }
}

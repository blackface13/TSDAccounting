/***********************************************************************
 * <copyright file="DepositReport.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 19 May 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using TSD.AccountingSoft.Model;

namespace TSD.AccountingSoft.Report.ReportClass
{
    /// <summary>
    /// DepositReport
    /// </summary>
    public class DepositReport : BaseReport
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DepositReport"/> class.
        /// </summary>
        public DepositReport()
        {
            Model = new TSD.AccountingSoft.Model.Model();
        }
    }
}

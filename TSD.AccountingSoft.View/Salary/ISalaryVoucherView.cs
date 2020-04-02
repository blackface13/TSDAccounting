/***********************************************************************
 * <copyright file="ICurrenciesView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   Thangnk
 * Email:    Thangnk@buca.vn
 * Website:
 * Create Date: Friday, March 7, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

namespace TSD.AccountingSoft.View.Salary
{
   public interface ISalaryVoucherView
    {
       string RefTypeId { get; set; }
       string RefNo { get; set; }
       string PostedDate { get; set; }

    }
}

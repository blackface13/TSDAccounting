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

using System.Collections.Generic;
using TSD.AccountingSoft.Model.BusinessObjects.Salary;

namespace TSD.AccountingSoft.View.Salary
{
        public interface ISalaryVouchersView : IView
        {
            IList<SalaryVoucherModel> SalaryVouchers { set; }
        }
    }


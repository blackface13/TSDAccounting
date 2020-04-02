/***********************************************************************
 * <copyright file="IGeneralVouchersView.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangNK
 * Email:    thangnk@buca.vn
 * Website:
 * Create Date: 11 April 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Collections.Generic;
using TSD.AccountingSoft.Model.BusinessObjects.General;


namespace TSD.AccountingSoft.View.General
{
    /// <summary>
    /// interface IGeneralVouchersView
    /// </summary>
    public interface IGeneralVouchersView
    {
        IList<GeneralVocherModel> GeneralVouchers { set; }
        IList<GeneralDetailModel> GeneralVoucherDetails { set; }
    }
}

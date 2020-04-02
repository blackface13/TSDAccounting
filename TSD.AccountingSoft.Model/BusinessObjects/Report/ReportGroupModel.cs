/***********************************************************************
 * <copyright file="ReportGroupModel.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Thursday, March 13, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

namespace TSD.AccountingSoft.Model.BusinessObjects.Report
{
    public class ReportGroupModel
    {
        public int ReportGroupID { get; set; }
        public string ReportGroupName { get; set; }
        public string Description { get; set; }
        public bool IsVoucher { get; set; }
        public bool IsActive { get; set; }
    }
}

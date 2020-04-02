/***********************************************************************
 * <copyright file="ReportListModel.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Wednesday, March 05, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

namespace TSD.AccountingSoft.Model.BusinessObjects.Report
{
    public class ReportListModel
    {
        public string ReportID { get; set; }
        public string ReportName { get; set; }
        public string Description { get; set; }
        public int GroupID { get; set; }
        public string ReportFile { get; set; }
        public string OutputAssembly { get; set; }
        public string InputTypeName { get; set; }
        public string FunctionReportName { get; set; }
        public string ProcedureName { get; set; }
        public string TableName { get; set; }
        public int TrackType { get; set; }
        public string ProcedureNameByLot { get; set; }
        public string ProcedureNameVoucherList { get; set; }
        public bool Selected { get; set; }
        public bool Inactive { get; set; }
        public int RefRypeVoucherID { get; set; }
        public bool PrintVoucherDefault { get; set; }
        public int LicenceType { get; set; }
        public string ParamFormName { get; set; }
        public string SupplementInfoReportID { get; set; }
        public string SupplementInfoTableName { get; set; }
        public int SortOrder { get; set; }
    }
}

/***********************************************************************
 * <copyright file="ReportListEntity.cs" company="Linh Khang">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Author:   LinhMC
 * Email:    linhmc.vn@gmail.com
 * Website:
 * Create Date: Monday, February 24, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/
using TSD.AccountingSoft.BusinessEntities.BusinessRules;

namespace TSD.AccountingSoft.BusinessEntities.Report
{
    public class ReportListEntity : BusinessEntities
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReportListEntity"/> class.
        /// </summary>
        public ReportListEntity()
        {
            AddRule(new ValidateRequired("ReportID"));
            AddRule(new ValidateRequired("ReportName"));
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ReportListEntity"/> class.
        /// </summary>

        public ReportListEntity(string reportId, string reportName, string description, int groupId,
                                        string reportFile, string outputAssembly, string inputTypeName, string functionReportNamem, string procedureName,
            string tableName, int trackType, string procNameByLot, string procNameVoucherList, bool selected, bool inactive, bool printVoucherDefault,
            int licenceType, string paramFormName, string supplementInfoReportId, string supplementInfoTableName)
            : this()
        {
            ReportId = reportId;
            ReportName = reportName;
            Description = description;
            GroupId = groupId;
            ReportFile = reportFile;
            OutputAssembly = outputAssembly;
            InputTypeName = inputTypeName;
            FunctionReportName = functionReportNamem;
            ProcedureName = procedureName;
            TableName = tableName;
            TrackType = trackType;
            ProcedureNameByLot = procNameByLot;
            ProcedureNameVoucherList = procNameVoucherList;
            Selected = selected;
            Inactive = inactive;
            PrintVoucherDefault = printVoucherDefault;
            LicenceType = licenceType;
            ParamFormName = paramFormName;
            SupplementInfoReportId = supplementInfoReportId;
            SupplementInfoTableName = supplementInfoTableName;
        }

        /// <summary>
        /// Gets or sets the report identifier.
        /// </summary>
        /// <value>
        /// The report identifier.
        /// </value>
        public string ReportId { get; set; }
        /// <summary>
        /// Gets or sets the name of the report.
        /// </summary>
        /// <value>
        /// The name of the report.
        /// </value>
        public string ReportName { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the group identifier.
        /// </summary>
        /// <value>
        /// The group identifier.
        /// </value>
        public int GroupId { get; set; }
        /// <summary>
        /// Gets or sets the report file.
        /// </summary>
        /// <value>
        /// The report file.
        /// </value>
        public string ReportFile { get; set; }
        /// <summary>
        /// Gets or sets the output assembly.
        /// </summary>
        /// <value>
        /// The output assembly.
        /// </value>
        public string OutputAssembly { get; set; }
        /// <summary>
        /// Gets or sets the name of the input type.
        /// </summary>
        /// <value>
        /// The name of the input type.
        /// </value>
        public string InputTypeName { get; set; }
        /// <summary>
        /// Gets or sets the name of the function report.
        /// </summary>
        /// <value>
        /// The name of the function report.
        /// </value>
        public string FunctionReportName { get; set; }
        /// <summary>
        /// Gets or sets the name of the procedure.
        /// </summary>
        /// <value>
        /// The name of the procedure.
        /// </value>
        public string ProcedureName { get; set; }
        /// <summary>
        /// Gets or sets the name of the table.
        /// </summary>
        /// <value>
        /// The name of the table.
        /// </value>
        public string TableName { get; set; }
        /// <summary>
        /// Gets or sets the type of the track.
        /// </summary>
        /// <value>
        /// The type of the track.
        /// </value>
        public int TrackType { get; set; }
        /// <summary>
        /// Gets or sets the proc name by lot.
        /// </summary>
        /// <value>
        /// The proc name by lot.
        /// </value>
        public string ProcedureNameByLot { get; set; }
        /// <summary>
        /// Gets or sets the proc name voucher list.
        /// </summary>
        /// <value>
        /// The proc name voucher list.
        /// </value>
        public string ProcedureNameVoucherList { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [selected].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [selected]; otherwise, <c>false</c>.
        /// </value>
        public bool Selected { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [inactive].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [inactive]; otherwise, <c>false</c>.
        /// </value>
        public bool Inactive { get; set; }
        /// <summary>
        /// Gets or sets the reference rype voucher identifier.
        /// </summary>
        /// <value>
        /// The reference rype voucher identifier.
        /// </value>
        public int RefRypeVoucherID { get; set; }
        /// <summary>
        /// Gets or sets the print voucher default.
        /// </summary>
        /// <value>
        /// The print voucher default.
        /// </value>
        public bool PrintVoucherDefault { get; set; }
        /// <summary>
        /// Gets or sets the type of the licence.
        /// </summary>
        /// <value>
        /// The type of the licence.
        /// </value>
        public int LicenceType { get; set; }
        /// <summary>
        /// Gets or sets the name of the parameter form.
        /// </summary>
        /// <value>
        /// The name of the parameter form.
        /// </value>
        public string ParamFormName { get; set; }
        /// <summary>
        /// Gets or sets the supplement information report identifier.
        /// </summary>
        /// <value>
        /// The supplement information report identifier.
        /// </value>
        public string SupplementInfoReportId { get; set; }
        /// <summary>
        /// Gets or sets the name of the supplement information table.
        /// </summary>
        /// <value>
        /// The name of the supplement information table.
        /// </value>
        public string SupplementInfoTableName { get; set; }

        /// <summary>
        /// Gets or sets the SortOrder.
        /// </summary>
        /// <value>
        /// The name of the SortOrder.
        /// </value>
        public int SortOrder { get; set; }
    }
}

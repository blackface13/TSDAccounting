/***********************************************************************
 * <copyright file="ReportListRequest.cs" company="Linh Khang">
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

using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessEntities.Report;


namespace TSD.AccountingSoft.BusinessComponents.Messages.Report
{
    /// <summary>
    /// ReportListRequest
    /// </summary>
    public class ReportListRequest : RequestBase
    {
        /// <summary>
        /// Gets or sets the report list identifier.
        /// </summary>
        /// <value>
        /// The report list identifier.
        /// </value>
        public string ReportListId { get; set; }

        /// <summary>
        /// Gets or sets the report group identifier.
        /// </summary>
        /// <value>
        /// The report group identifier.
        /// </value>
        public int ReportGroupId { get; set; }

        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>
        /// The reference identifier.
        /// </value>
        public long RefId { get; set; }

        /// <summary>
        /// Gets or sets to date.
        /// </summary>
        /// <value>
        /// To date.
        /// </value>
        public string RefIdList { get; set; } 
        
        /// <summary>
        /// Gets or sets to date.
        /// </summary>
        /// <value>
        /// To date.
        /// </value>
        public string ToDate { get; set; }

        /// <summary>
        /// Gets or sets from date.
        /// </summary>
        /// <value>
        /// From date.
        /// </value>
        public string FromDate { get; set; }

        /// <summary>
        /// Gets or sets the report list.
        /// </summary>
        /// <value>
        /// The report list.
        /// </value>
        public string CurrencyCode { get; set; }
        
        /// <summary>
        /// Gets or sets the where clause.
        /// </summary>
        /// <value>
        /// The where clause.
        /// </value>
        public string WhereClause { get; set; } 
        
        /// <summary>
        /// Gets or sets the report list.
        /// </summary>
        /// <value>
        /// The report list.
        /// </value>
        public int AmounType { get; set; } 

        /// <summary>
        /// Gets or sets the account number.
        /// </summary>
        /// <value>
        /// The account number.
        /// </value>
        public string AccountNumber { get; set; }
        
        /// <summary>
        /// Gets or sets the corresponding account number.
        /// </summary>
        /// <value>
        /// The corresponding account number.
        /// </value>
        public string CorrespondingAccountNumber { get; set; }
        
        /// <summary>
        /// Gets or sets the list stock identifier.
        /// </summary>
        /// <value>
        /// The list stock identifier.
        /// </value>
        public string ListStockId { get; set; }

        /// <summary>
        /// Gets or sets the year of estimate.
        /// </summary>
        /// <value>
        /// The year of estimate.
        /// </value>
        public short YearOfEstimate { get; set; }

        /// <summary>
        /// Gets or sets the year of estimate.
        /// </summary>
        /// <value>
        /// The year of estimate.
        /// </value>
        public string FixedAssetParameter { get; set; }

        /// <summary>
        /// Gets or sets the year of estimate.
        /// </summary>
        /// <value>
        /// The year of estimate.
        /// </value>
        public string FaCategoryCode { get; set; }

        /// <summary>
        /// Gets or sets the year.
        /// </summary>
        /// <value>
        /// The year.
        /// </value>
        public int Year { get; set; }

        /// <summary>
        /// Gets or sets the reference type identifier.
        /// </summary>
        /// <value>
        /// The reference type identifier.
        /// </value>
        public int RefTypeId { get; set; }

        /// <summary>
        /// Gets or sets the reference type identifier.
        /// </summary>
        /// <value>
        /// The reference type identifier.
        /// </value>
        public string BudgetGroupCode { get; set; }

        /// <summary>
        /// Gets or sets the reference type identifier.
        /// </summary>
        /// <value>
        /// The reference type identifier.
        /// </value>
        public string FixedAssetCode { get; set; }

        public string StrFixedAssetId { get; set; }
        /// <summary>
        /// Gets or sets the reference type identifier.
        /// </summary>
        /// <value>
        /// The reference department code identifier.
        /// </value>
        public string DepartmentCode { get; set; }


        /// <summary>
        /// Gets or sets the report list.
        /// </summary>
        /// <value>
        /// The report list.
        /// </value>
        public ReportListEntity ReportList { get; set; }

        /// <summary>
        /// Gets or sets the currency decimal digits.
        /// </summary>
        /// <value>
        /// The currency decimal digits.
        /// </value>
        public int CurrencyDecimalDigits { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is company profile].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is company profile]; otherwise, <c>false</c>.
        /// </value>
        public  bool IsCompanyProfile { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is employee].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is employee]; otherwise, <c>false</c>.
        /// </value>
        public bool IsEmployee { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is bank].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is bank]; otherwise, <c>false</c>.
        /// </value>
        public bool IsBank { get; set; }

        /// <summary>
        /// Gets or sets the bank identifier.
        /// </summary>
        /// <value>
        /// The bank identifier.
        /// </value>
        public int? BankId { get; set; }

        /// <summary>
        /// Gets or sets the selected field.
        /// </summary>
        /// <value>
        /// The selected field.
        /// </value>
        public string SelectedField { get; set; }

        /// <summary>
        /// Gets or sets the selected all value field.
        /// </summary>
        /// <value>
        /// The selected all value field.
        /// </value>
        public string SelectedAllValueField { get; set; }

        public int Option { get; set; }
    }
}

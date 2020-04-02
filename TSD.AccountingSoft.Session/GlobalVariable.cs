/***********************************************************************
 * <copyright file="GlobalVariable.cs" company="BUCA JSC">
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

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Model.BusinessObjects.Report;
using TSD.AccountingSoft.Presenter.Dictionary.DBOption;
using TSD.AccountingSoft.View.Dictionary;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;

namespace TSD.AccountingSoft.Session
{
    /// <summary>
    /// GlobalVariable
    /// </summary>
    public class GlobalVariable : IDBOptionsView
    {

        /// <summary>
        /// Gets or sets the currency accounting.
        /// </summary>
        /// <value>
        /// The currency accounting.
        /// </value>
        public static string MainCurrencyId { get; set; }
        /// <summary>
        /// The _ property name
        /// </summary>
        private uint _PropertyName;
        /// <summary>
        /// The _DB options presenter
        /// </summary>
        private readonly DBOptionsPresenter _dbOptionsPresenter;
        public static int CurrencyType { get; set; }

        #region Options

        /// <summary>
        /// Gets or sets the financial month.
        /// </summary>
        /// <value>
        /// The financial month.
        /// </value>
        public string FinancialMonth { get; set; }

        /// <summary>
        /// Gets or sets the financial end of date.
        /// </summary>
        /// <value>
        /// The financial end of date.
        /// </value>
        public string FinancialEndOfDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is post to parent account].
        /// </summary>
        /// <value>
        /// <c>true</c> if [is post to parent account]; otherwise, <c>false</c>.
        /// </value>
        public static bool IsPostToParentAccount { get; set; }

        /// <summary>
        /// Gets or sets the base of salary.
        /// </summary>
        /// <value>
        /// The base of salary.
        /// </value>
        public decimal BaseOfSalary { get; set; }

        public decimal CoefficientOfSalaryByArea { get; set; }

        /// <summary>
        /// Gets or sets the currency code of salary.
        /// </summary>
        /// <value>
        /// The currency code of salary.
        /// </value>
        public string CurrencyCodeOfSalary { get; set; }

        /// <summary>
        /// Gets or sets the currency accounting.
        /// </summary>
        /// <value>
        /// The currency accounting.
        /// </value>
        public string CurrencyAccounting { get; set; }

        /// <summary>
        /// Gets or sets the currency accounting usd.
        /// </summary>
        /// <value>
        /// The currency accounting usd.
        /// </value>
        public string CurrencyLocal { get; set; }

        public string DateOfInventory { get; set; }

        public string HourOfInventory { get; set; }

        public string MinuteOfInventory { get; set; }

        public string JobOfInventory1 { get; set; }

        public string JobOfInventory2 { get; set; }

        public string JobOfInventory3 { get; set; }

        public string NameOfInventory1 { get; set; }

        public string NameOfInventory2 { get; set; }

        public string NameOfInventory3 { get; set; }

        /// <summary>
        /// Gets or sets the job title company director.
        /// </summary>
        /// <value>
        /// The job title company director.
        /// </value>
        public string JobTitleCompanyDirector { get; set; }

        /// <summary>
        /// Gets or sets the job title company director.
        /// </summary>
        /// <value>
        /// The job title company director.
        /// </value>
        public string JobTitleCompanyStoreKeeper { get; set; }

        /// <summary>
        /// Gets or sets the job title company accountant.
        /// </summary>
        /// <value>
        /// The job title company accountant.
        /// </value>
        public string JobTitleCompanyAccountant { get; set; }

        /// <summary>
        /// Gets or sets the job title company accountant.
        /// </summary>
        /// <value>
        /// The job title company accountant.
        /// </value>
        public string JobTitleCompanyReportPreparer { get; set; }

        /// <summary>
        /// Gets or sets the job title company cashier.
        /// </summary>
        /// <value>
        /// The job title company cashier.
        /// </value>
        public string JobTitleCompanyCashier { get; set; }

        /// <summary>
        /// Gets or sets the currency symbol.
        /// </summary>
        /// <value>
        /// The currency symbol.
        /// </value>
        public string CurrencySymbol { get; set; }

        /// <summary>
        /// Gets or sets the currency decimal separator.
        /// </summary>
        /// <value>
        /// The currency decimal separator.
        /// </value>
        public string CurrencyDecimalSeparator { get; set; }

        /// <summary>
        /// Gets or sets the currency group separator.
        /// </summary>
        /// <value>
        /// The currency group separator.
        /// </value>
        public string CurrencyGroupSeparator { get; set; }

        /// <summary>
        /// Gets or sets the currency decimal digits.
        /// </summary>
        /// <value>
        /// The currency decimal digits.
        /// </value>
        public string CurrencyDecimalDigits { get; set; }


        /// <summary>
        /// Gets or sets the number decimal digits.
        /// </summary>
        /// <value>
        /// The number decimal digits.
        /// </value>
        public string NumberDecimalDigits { get; set; }

        /// <summary>
        /// Gets or sets the number decimal digits.
        /// </summary>
        /// <value>
        /// The number decimal digits.
        /// </value>
        public string UnitPriceDecimalDigits { get; set; }

        /// <summary>
        /// Gets or sets the percent decimal digits.
        /// </summary>
        /// <value>
        /// The percent decimal digits.
        /// </value>
        public string PercentDecimalDigits { get; set; }

        /// <summary>
        /// Gets or sets the currency positive pattern.
        /// </summary>
        /// <value>
        /// The currency positive pattern.
        /// </value>
        public int CurrencyPositivePattern { get; set; }

        /// <summary>
        /// Gets or sets the exchange rate decimal digits.
        /// </summary>
        /// <value>
        /// The exchange rate decimal digits.
        /// </value>
        public string ExchangeRateDecimalDigits { get; set; }
        public static string ExchangeRateDecimalDigits2 { get; set; }

        /// <summary>
        /// Gets or sets the currency negative pattern.
        /// </summary>
        /// <value>
        /// The currency negative pattern.
        /// </value>
        public int CurrencyNegativePattern { get; set; }

        /// <summary>
        /// Gets or sets the current culture information.
        /// </summary>
        /// <value>
        /// The current culture information.
        /// </value>
        public CultureInfo CurrentCultureInfo { get; set; }

        /// <summary>
        /// Gets or sets the chapter font.
        /// </summary>
        /// <value>
        /// The chapter font.
        /// </value>
        public string ChapterFont { get; set; }

        /// <summary>
        /// Gets or sets the company address font.
        /// </summary>
        /// <value>
        /// The company address font.
        /// </value>
        public string CompanyAddressFont { get; set; }

        /// <summary>
        /// Gets or sets the company address.
        /// </summary>
        /// <value>
        /// The company address.
        /// </value>
        public static string CompanyAddress { get; set; }

        /// <summary>
        /// Gets or sets the company bank account no.
        /// </summary>
        /// <value>
        /// The company bank account no.
        /// </value>
        public string CompanyBankAccountNo { get; set; }

        /// <summary>
        /// Gets or sets the company bank adrress.
        /// </summary>
        /// <value>
        /// The company bank adrress.
        /// </value>
        public static string CompanyBankAdrress { get; set; }

        /// <summary>
        /// Gets or sets the name of the company bank.
        /// </summary>
        /// <value>
        /// The name of the company bank.
        /// </value>
        public string CompanyBankName { get; set; }

        /// <summary>
        /// Gets or sets the company cashier.
        /// </summary>
        /// <value>
        /// The company cashier.
        /// </value>
        public string CompanyCashier { get; set; }

        /// <summary>
        /// Gets or sets the company cashier title.
        /// </summary>
        /// <value>
        /// The company cashier title.
        /// </value>
        public string CompanyCashierTitle { get; set; }

        /// <summary>
        /// Gets or sets the company accountant.
        /// </summary>
        /// <value>
        /// The company accountant.
        /// </value>
        public string CompanyAccountant { get; set; }

        /// <summary>
        /// Gets or sets the company chief accountant title.
        /// </summary>
        /// <value>
        /// The company chief accountant title.
        /// </value>
        public string CompanyChiefAccountantTitle { get; set; }

        /// <summary>
        /// Gets or sets the company city.
        /// </summary>
        /// <value>
        /// The company city.
        /// </value>
        public string CompanyCity { get; set; }

        /// <summary>
        /// Gets or sets the company code.
        /// </summary>
        /// <value>
        /// The company code.
        /// </value>
        public static string CompanyCode { get; set; }

        /// <summary>
        /// Gets or sets the company code font.
        /// </summary>
        /// <value>
        /// The company code font.
        /// </value>
        public string CompanyCodeFont { get; set; }

        /// <summary>
        /// Gets or sets the company director.
        /// </summary>
        /// <value>
        /// The company director.
        /// </value>
        public string CompanyDirector { get; set; }

        /// <summary>
        /// Gets or sets the company director title.
        /// </summary>
        /// <value>
        /// The company director title.
        /// </value>
        public string CompanyDirectorTitle { get; set; }

        /// <summary>
        /// Gets or sets the company district.
        /// </summary>
        /// <value>
        /// The company district.
        /// </value>
        public string CompanyDistrict { get; set; }

        /// <summary>
        /// Gets or sets the company email.
        /// </summary>
        /// <value>
        /// The company email.
        /// </value>
        public string CompanyEmail { get; set; }

        /// <summary>
        /// Gets or sets the company fax.
        /// </summary>
        /// <value>
        /// The company fax.
        /// </value>
        public string CompanyFax { get; set; }

        /// <summary>
        /// Gets or sets the company in charge.
        /// </summary>
        /// <value>
        /// The company in charge.
        /// </value>
        public static string CompanyInCharge { get; set; }

        /// <summary>
        /// Gets or sets the company in charge font.
        /// </summary>
        /// <value>
        /// The company in charge font.
        /// </value>
        public string CompanyInChargeFont { get; set; }

        /// <summary>
        /// Gets or sets the name of the company.
        /// </summary>
        /// <value>
        /// The name of the company.
        /// </value>
        public static string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets the company owner.
        /// </summary>
        /// <value>
        /// The company owner.
        /// </value>
        public static string CompanyOwner { get; set; }

        /// <summary>
        /// Gets or sets the license number.
        /// </summary>
        /// <value>
        /// The license number.
        /// </value>
        public static string LicenseNumber { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is valid license.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is valid license; otherwise, <c>false</c>.
        /// </value>
        public static bool IsValidLicense { get; set; }

        /// <summary>
        /// Gets or sets the company name font.
        /// </summary>
        /// <value>
        /// The company name font.
        /// </value>
        public string CompanyNameFont { get; set; }

        /// <summary>
        /// Gets or sets the company phone.
        /// </summary>
        /// <value>
        /// The company phone.
        /// </value>
        public string CompanyPhone { get; set; }

        /// <summary>
        /// Gets or sets the company province.
        /// </summary>
        /// <value>
        /// The company province.
        /// </value>
        public string CompanyProvince { get; set; }

        /// <summary>
        /// Gets or sets the company report preparer.
        /// </summary>
        /// <value>
        /// The company report preparer.
        /// </value>
        public string CompanyReportPreparer { get; set; }


        /// <summary>
        /// Gets or sets the company report preparer title.
        /// </summary>
        /// <value>
        /// The company report preparer title.
        /// </value>
        public string CompanyReportPreparerTitle { get; set; }

        /// <summary>
        /// Gets or sets the company store keeper.
        /// </summary>
        /// <value>
        /// The company store keeper.
        /// </value>
        public string CompanyStoreKeeper { get; set; }

        /// <summary>
        /// Gets or sets the company store keeper title.
        /// </summary>
        /// <value>
        /// The company store keeper title.
        /// </value>
        public string CompanyStoreKeeperTitle { get; set; }

        /// <summary>
        /// Gets or sets the company tax code.
        /// </summary>
        /// <value>
        /// The company tax code.
        /// </value>
        public string CompanyTaxCode { get; set; }

        /// <summary>
        /// Gets or sets the company in charge sort order on report.
        /// </summary>
        /// <value>
        /// The company in charge sort order on report.
        /// </value>
        public int CompanyInChargeSortOrderOnReport { get; set; }

        /// <summary>
        /// Gets or sets the company adrress order on report.
        /// </summary>
        /// <value>
        /// The company adrress order on report.
        /// </value>
        public int CompanyAdrressOrderOnReport { get; set; }

        /// <summary>
        /// Gets or sets the company name sort order on report.
        /// </summary>
        /// <value>
        /// The company name sort order on report.
        /// </value>
        public int CompanyNameSortOrderOnReport { get; set; }

        /// <summary>
        /// Gets or sets the company code order on report.
        /// </summary>
        /// <value>
        /// The company code order on report.
        /// </value>
        public int CompanyCodeOrderOnReport { get; set; }

        /// <summary>
        /// Gets or sets the chapter order on report.
        /// </summary>
        /// <value>
        /// The chapter order on report.
        /// </value>
        public int ChapterOrderOnReport { get; set; }

        /// <summary>
        /// Gets or sets the currency unit price digits.
        /// </summary>
        /// <value>
        /// The currency unit price digits.
        /// </value>
        public static int CurrencyUnitPriceDigits { get; set; }

        /// <summary>
        /// Gets or sets the exchange rate digits.
        /// </summary>
        /// <value>
        /// The exchange rate digits.
        /// </value>
        public int ExchangeRateDigits { get; set; }

        /// <summary>
        /// Gets or sets the quantity digits.
        /// </summary>
        /// <value>
        /// The quantity digits.
        /// </value>
        public int QuantityDigits { get; set; }

        /// <summary>
        /// Gets or sets the general decimal separator.
        /// </summary>
        /// <value>
        /// The general decimal separator.
        /// </value>
        public string GeneralDecimalSeparator { get; set; }

        /// <summary>
        /// Gets or sets the general group separator.
        /// </summary>
        /// <value>
        /// The general group separator.
        /// </value>
        public string GeneralGroupSeparator { get; set; }

        /// <summary>
        /// Gets or sets the display vourcher mode.
        /// </summary>
        /// <value>
        /// The display vourcher mode.
        /// </value>
        public static int DisplayVourcherMode { get; set; }

        /// <summary>
        /// Gets or sets the posted date.
        /// </summary>
        /// <value>
        /// The posted date.
        /// </value>
        public string PostedDate { get; set; }

        /// <summary>
        /// Gets or sets the started date.
        /// </summary>
        /// <value>
        /// The started date.
        /// </value>
        public static string StartedDate { get; set; }

        /// <summary>
        /// Gets or sets the system date.
        /// </summary>
        /// <value>
        /// The system date.
        /// </value>
        public static string SystemDate { get; set; }

        /// <summary>
        /// Gets or sets from date.
        /// </summary>
        /// <value>
        /// From date.
        /// </value>
        public static DateTime FromDate { get; set; }

        /// <summary>
        /// Gets or sets to date.
        /// </summary>
        /// <value>
        /// To date.
        /// </value>
        public static DateTime ToDate { get; set; }

        /// <summary>
        /// Gets or sets the index of the date range selected.
        /// </summary>
        /// <value>
        /// The index of the date range selected.
        /// </value>
        public static int DateRangeSelectedIndex { get; set; }

        /// <summary>
        /// Gets or sets the name of the server.
        /// </summary>
        /// <value>
        /// The name of the server.
        /// </value>
        public static string ServerName { get; set; }

        /// <summary>
        /// Gets or sets the name of the database.
        /// </summary>
        /// <value>
        /// The name of the database.
        /// </value>
        public static string DatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the name of the login.
        /// </summary>
        /// <value>
        /// The name of the login.
        /// </value>
        public static string LoginName { get; set; }

        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        /// <value>
        /// The full name.
        /// </value>
        public static string FullName { get; set; }

        /// <summary>
        /// Gets or sets the connection string.
        /// </summary>
        /// <value>
        /// The connection string.
        /// </value>
        public static string ConnectionString { get; set; }

        /// <summary>
        /// The assembly path
        /// </summary>
        private static readonly string AssemblyPath = System.Reflection.Assembly.GetExecutingAssembly().Location.Substring(0, System.Reflection.Assembly.GetExecutingAssembly().Location.LastIndexOf(@"\", StringComparison.Ordinal));

        /// <summary>
        /// The path
        /// </summary>
        private static readonly string Path = AssemblyPath.Substring(0, AssemblyPath.LastIndexOf(@"\", StringComparison.Ordinal));

        /// <summary>
        /// The report path
        /// </summary>
        public string ReportPath = Path + @"\Report\";

        public string XMLPath = "";

        /// <summary>
        /// The combo path layout
        /// </summary>
        public static string DataPath = Path + @"\DATA\";

        /// <summary>
        /// The template path
        /// </summary>
        public string TemplatePath = "";

        /// <summary>
        /// The bin path
        /// </summary>
        public string BinPath = "";

        /// <summary>
        /// The type path
        /// </summary>
        public string TypePath = "";

        /// <summary>
        /// The produc name
        /// </summary>
        public string ProducName = "A-BIGTIME.NET 2014";

        /// <summary>
        /// The application name
        /// </summary>
        public static string ApplicationName = "A-BIGTIME.NET 2014";

        /// <summary>
        /// Gets or sets the report list.
        /// </summary>
        /// <value>
        /// The report list.
        /// </value>
        public ReportListModel ReportList { get; set; }

        /// <summary>
        /// Gets or sets the name of the store procedure.
        /// </summary>
        /// <value>
        /// The name of the store procedure.
        /// </value>
        public string StoreProcedureName { get; set; }

        /// <summary>
        /// Gets or sets the drill down parram.
        /// </summary>
        /// <value>
        /// The drill down parram.
        /// </value>
        public object[] DrillDownParram { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is drill down report.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is drill down report; otherwise, <c>false</c>.
        /// </value>
        public bool IsDrillDownReport { get; set; }

        /// <summary>
        /// The currency main
        /// </summary>
        public static string CurrencyMain = "USD";

        /// <summary>
        /// Gets or sets the currency view report.
        /// </summary>
        /// <value>
        /// The currency view report.
        /// </value>
        public static string CurrencyViewReport { get; set; }

        /// <summary>
        /// Gets or sets the amount type view report.
        /// </summary>
        /// <value>
        /// The amount type view report.
        /// </value>
        public static int AmountTypeViewReport { get; set; }

        /// <summary>
        /// The currency display string
        /// </summary>
        public static string CurrencyDisplayString = "{0:c}";

        /// <summary>
        /// The numeric display string
        /// </summary>
        public static string NumericDisplayString = "{0:n}";

        /// <summary>
        /// Gets or sets the type of the reference.
        /// </summary>
        /// <value>
        /// The type of the reference.
        /// </value>
        public int RefType { get; set; }

        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>
        /// The reference identifier.
        /// </value>
        public long RefId { get; set; }

        /// <summary>
        /// Gets or sets the reference identifier list.
        /// </summary>
        /// <value>
        /// The reference identifier list.
        /// </value>
        public string RefIdList { get; set; }

        /// <summary>
        /// Gets or sets the daily backup path.
        /// </summary>
        /// <value>
        /// The daily backup path.
        /// </value>
        public string DailyBackupPath { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is daily backup.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is daily backup; otherwise, <c>false</c>.
        /// </value>
        public bool IsDailyBackup { get; set; }

        /// <summary>
        /// Cho phép chi tiền gửi khi quỹ âm
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is deposite negavtive fund; otherwise, <c>false</c>.
        /// </value>
        public bool IsDepositeNegavtiveFund { get; set; }

        /// <summary>
        /// Cho phép xuất khi hết hàng
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is outward negative stock; otherwise, <c>false</c>.
        /// </value>

        public bool IsOutwardNegativeStock { get; set; }

        /// <summary>
        /// Cho phép chi tiền mặt theo nguồn âm
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is payment negative budget source; otherwise, <c>false</c>.
        /// </value>
        public bool IsPaymentNegativeBudgetSource { get; set; }

        /// <summary>
        /// Cho phép chi tiền mặt quĩ âm
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is payment negative fund; otherwise, <c>false</c>.
        /// </value>
        public bool IsPaymentNegativeFund { get; set; }


        public string Version { get; set; }

        public string VersionControl { get; set; }


        public string TitleConsulManager { get; set; }

        public string ConsulManager { get; set; }

        #endregion

        #region Server

        /// <summary>
        /// Gets or sets the server.
        /// </summary>
        /// <value>
        /// The server.
        /// </value>
        public static Server Server { get; set; }

        /// <summary>
        /// Gets or sets the server connection.
        /// </summary>
        /// <value>
        /// The server connection.
        /// </value>
        public static ServerConnection ServerConnection { get; set; }

        #endregion

        #region IDBOptionsView

        /// <summary>
        /// Gets or sets the database options.
        /// </summary>
        /// <value>
        /// The database options.
        /// </value>
        /// <exception cref="System.NotImplementedException"></exception>
        public IList<DBOptionModel> DBOptions
        {
            set
            {
                if (value == null) return;

                CompanyDirector = (from dbOption in value where dbOption.OptionId == "CompanyDirector" select dbOption.OptionValue).First();
                CompanyReportPreparer = (from dbOption in value where dbOption.OptionId == "CompanyReportPreparer" select dbOption.OptionValue).First();
                CompanyReportPreparer = (from dbOption in value where dbOption.OptionId == "CompanyReportPreparer" select dbOption.OptionValue).First();
                CompanyAccountant = (from dbOption in value where dbOption.OptionId == "CompanyAccountant" select dbOption.OptionValue).First();
                CompanyCashier = (from dbOption in value where dbOption.OptionId == "CompanyCashier" select dbOption.OptionValue).First();
                CompanyStoreKeeper = (from dbOption in value where dbOption.OptionId == "CompanyStoreKeeper" select dbOption.OptionValue).First();
                StartedDate = (from dbOption in value where dbOption.OptionId == "StartedDate" select dbOption.OptionValue).First();
                CompanyNameFont = (from dbOption in value where dbOption.OptionId == "CompanyNameFont" select dbOption.OptionValue).First();
                CompanyAddressFont = (from dbOption in value where dbOption.OptionId == "CompanyAddressFont" select dbOption.OptionValue).First();
                //ThoDD thêm thông tin kiểm kê
                JobOfInventory1 = (from dbOption in value where dbOption.OptionId == "JobOfInventory1" select dbOption.OptionValue).First();
                JobOfInventory2 = (from dbOption in value where dbOption.OptionId == "JobOfInventory2" select dbOption.OptionValue).First();
                JobOfInventory3 = (from dbOption in value where dbOption.OptionId == "JobOfInventory3" select dbOption.OptionValue).First();
                NameOfInventory1 = (from dbOption in value where dbOption.OptionId == "NameOfInventory1" select dbOption.OptionValue).First();
                NameOfInventory2 = (from dbOption in value where dbOption.OptionId == "NameOfInventory2" select dbOption.OptionValue).First();
                NameOfInventory3 = (from dbOption in value where dbOption.OptionId == "NameOfInventory3" select dbOption.OptionValue).First();
                DateOfInventory = (from dbOption in value where dbOption.OptionId == "DateOfInventory" select dbOption.OptionValue).First();
                HourOfInventory = (from dbOption in value where dbOption.OptionId == "HourOfInventory" select dbOption.OptionValue).First();
                MinuteOfInventory = (from dbOption in value where dbOption.OptionId == "MinuteOfInventory" select dbOption.OptionValue).First();
                //END
                JobTitleCompanyDirector = (from dbOption in value where dbOption.OptionId == "JobTitleCompanyDirector" select dbOption.OptionValue).First();
                JobTitleCompanyAccountant = (from dbOption in value where dbOption.OptionId == "JobTitleCompanyAccountant" select dbOption.OptionValue).First();
                JobTitleCompanyReportPreparer = (from dbOption in value where dbOption.OptionId == "JobTitleCompanyReportPreparer" select dbOption.OptionValue).First();
                JobTitleCompanyCashier = (from dbOption in value where dbOption.OptionId == "JobTitleCompanyCashier" select dbOption.OptionValue).First();
                JobTitleCompanyStoreKeeper = (from dbOption in value where dbOption.OptionId == "JobTitleCompanyStoreKeeper" select dbOption.OptionValue).First();
                CompanyCity = (from dbOption in value where dbOption.OptionId == "CompanyCity" select dbOption.OptionValue).First();
                CompanyProvince = (from dbOption in value where dbOption.OptionId == "CompanyProvince" select dbOption.OptionValue).First();
                CompanyCode = (from dbOption in value where dbOption.OptionId == "CompanyCode" select dbOption.OptionValue).First();


                //number format
                CurrencySymbol = (from dbOption in value where dbOption.OptionId == "CurrencySymbol" select dbOption.OptionValue).First();
                CurrencyDecimalSeparator = (from dbOption in value where dbOption.OptionId == "CurrencyDecimalSeparator" select dbOption.OptionValue).First();
                CurrencyGroupSeparator = (from dbOption in value where dbOption.OptionId == "CurrencyGroupSeparator" select dbOption.OptionValue).First();
                CurrencyDecimalDigits = (from dbOption in value where dbOption.OptionId == "CurrencyDecimalDigits" select dbOption.OptionValue).First();
                NumberDecimalDigits = (from dbOption in value where dbOption.OptionId == "NumberDecimalDigits" select dbOption.OptionValue).First();
                PercentDecimalDigits = (from dbOption in value where dbOption.OptionId == "PercentDecimalDigits" select dbOption.OptionValue).First();
                UnitPriceDecimalDigits = (from dbOption in value where dbOption.OptionId == "UnitPriceDecimalDigits" select dbOption.OptionValue).First();
                CurrencyNegativePattern = int.Parse((from dbOption in value where dbOption.OptionId == "NumberNegativePattern" select dbOption.OptionValue).First());

                DisplayVourcherMode = int.Parse((from dbOption in value where dbOption.OptionId == "DisplayVourcherMode" select dbOption.OptionValue).First());
                PostedDate = (from dbOption in value where dbOption.OptionId == "PostedDate" select dbOption.OptionValue).First();
                FinancialEndOfDate = (from dbOption in value where dbOption.OptionId == "FinancialEndOfDate" select dbOption.OptionValue).First();
                CurrencyCodeOfSalary = (from dbOption in value where dbOption.OptionId == "CurrencyCodeOfSalary" select dbOption.OptionValue).First();
                CurrencyAccounting = (from dbOption in value where dbOption.OptionId == "CurrencyAccounting" select dbOption.OptionValue).First();
                CurrencyLocal = (from dbOption in value where dbOption.OptionId == "CurrencyLocal" select dbOption.OptionValue).First();
                SystemDate = (from dbOption in value where dbOption.OptionId == "SystemDate" select dbOption.OptionValue).First();
                BaseOfSalary = decimal.Parse((from dbOption in value where dbOption.OptionId == "BaseOfSalary" select dbOption.OptionValue).First());
                CoefficientOfSalaryByArea = (from dbOption in value where dbOption.OptionId == "CoefficientOfSalaryByArea" select dbOption.OptionValue).Count() > 0 ? decimal.Parse((from dbOption in value where dbOption.OptionId == "CoefficientOfSalaryByArea" select dbOption.OptionValue).First()) : 1;
                IsPostToParentAccount = bool.Parse((from dbOption in value where dbOption.OptionId == "IsPostToParentAccount" select dbOption.OptionValue).First());
                ExchangeRateDecimalDigits = ExchangeRateDecimalDigits2 = (from dbOption in value where dbOption.OptionId == "ExchangeRateDecimalDigits" select dbOption.OptionValue).First();
                FinancialMonth = (from dbOption in value where dbOption.OptionId == "FinancialMonth" select dbOption.OptionValue).First();

                IsDailyBackup = bool.Parse((from dbOption in value where dbOption.OptionId == "IsDailyBackup" select dbOption.OptionValue).First());
                DailyBackupPath = (from dbOption in value where dbOption.OptionId == "DailyBackupPath" select dbOption.OptionValue).First();

                XMLPath = (from dbOption in value where dbOption.OptionId == "XMLPath" select dbOption.OptionValue).Count() > 0 ? (from dbOption in value where dbOption.OptionId == "XMLPath" select dbOption.OptionValue).First() : string.Empty;
                //ThangNK bổ sung=============================
                IsDepositeNegavtiveFund = bool.Parse((from dbOption in value where dbOption.OptionId == "IsDepositeNegavtiveFund" select dbOption.OptionValue).First());
                IsOutwardNegativeStock = bool.Parse((from dbOption in value where dbOption.OptionId == "IsOutwardNegativeStock" select dbOption.OptionValue).First());
                IsPaymentNegativeBudgetSource = bool.Parse((from dbOption in value where dbOption.OptionId == "IsPaymentNegativeBudgetSource" select dbOption.OptionValue).First());
                IsPaymentNegativeFund = bool.Parse((from dbOption in value where dbOption.OptionId == "IsPaymentNegativeFund" select dbOption.OptionValue).First());

                //ThoDD thêm để quản lý phiên bản sử dụng 
                Version = (from dbOption in value where dbOption.OptionId == "Version" select dbOption.OptionValue).First();
                VersionControl = (from dbOption in value where dbOption.OptionId == "VersionControl" select dbOption.OptionValue).First();
                TitleConsulManager = (from dbOption in value where dbOption.OptionId == "TitleConsulManager" select dbOption.OptionValue).FirstOrDefault();
                ConsulManager = (from dbOption in value where dbOption.OptionId == "ConsulManager" select dbOption.OptionValue).FirstOrDefault();

                //Đồng tiền hạch toán mặc định (AnhNT: thêm vào nhưng chưa sử dụng, hỏi lại nghiệp vụ)
                MainCurrencyId = (from dbOption in value where dbOption.OptionId == "MainCurrencyID" select dbOption.OptionValue).FirstOrDefault();
            }
            get { throw new NotImplementedException(); }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="GlobalVariable" /> class.
        /// </summary>
        public GlobalVariable()
        {
            _dbOptionsPresenter = new DBOptionsPresenter(this);
            _dbOptionsPresenter.Display();
        }
    }
}
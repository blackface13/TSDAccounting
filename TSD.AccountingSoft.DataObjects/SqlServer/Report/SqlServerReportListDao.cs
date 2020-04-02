/***********************************************************************
 * <copyright file="SqlServerReportListDao.cs" company="Linh Khang">
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TSD.AccountingSoft.BusinessEntities.Dictionary;
using TSD.AccountingSoft.BusinessEntities.Report;
using TSD.AccountingSoft.BusinessEntities.Report.Estimate;
using TSD.AccountingSoft.BusinessEntities.Report.Finacial;
using TSD.AccountingSoft.BusinessEntities.Report.FixedAsset;
using TSD.AccountingSoft.BusinessEntities.Report.Voucher;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Report;
using TSD.AccountingSoft.DataHelpers;


namespace TSD.AccountingSoft.DataAccess.SqlServer.Report
{
    /// <summary>
    /// SqlServer ReportList Dao
    /// </summary>
    public class SqlServerReportListDao : IReportListDao
    {
        #region Report List

        public List<ReportListEntity> GetReportLists()
        {
            const string procedures = @"uspGet_All_ReportList";
            return Db.ReadList(procedures, true, Make);
        }

        public string UpdateReportList(ReportListEntity reportListEntity)
        {

            object[] parms = { "@ReportID", reportListEntity.ReportId, "@PrintVoucherDefault", reportListEntity.PrintVoucherDefault };
            const string procedures = @"uspGet_All_ReportList";
            return Db.Update(procedures, true, parms);
        }

        public List<ReportListEntity> GetReportListsByReportGroup(int reportGroupId)
        {
            const string sql = @"uspGet_ReportList_ByReportGroupID";

            object[] parms = { "@ReportGroupID", reportGroupId };
            return Db.ReadList(sql, true, Make, parms);
        }

        public ReportListEntity GetReportListById(string reportListId)
        {
            const string sql = @"uspGet_ReportList_ByID";

            object[] parms = { "@ReportListID", reportListId };
            return Db.Read(sql, true, Make, parms);
        }

        public string UpdateReport(ReportListEntity reportListEntity)
        {
            const string procedures = @"uspUpdate_ReportList";
            return Db.Update(procedures, true, Take(reportListEntity));
        }

        #endregion

        #region 0 - Reports

        public IList<C22HEntity> GetReportC22H(string storeProdure, string refIdList)
        {
            IList<C22HEntity> list = new List<C22HEntity>();
            foreach (var refId in refIdList.Split(';'))
            {

                object[] parms = { "@RefID", refId };
                var obj = Db.Read(storeProdure, true, MakeC22HD, parms);
                if (obj != null)
                {
                    list.Add(obj);
                }

            }
            return list;// Db.ReadList(sql, true, MakeC22HD, parms);
        }

        public IList<A02LDTLEntity> Get02LdtlWithStoreProdure(string storeProdure, string fromDate, string toDate)
        {
            object[] parms =
                {
                    "@FromDate", DateTime.Parse( fromDate),
                    "@ToDate", DateTime.Parse( toDate)
                };
            return Db.ReadList(storeProdure, true, Make02Ldt, parms);
        }

        public IList<A02LDTLEntity> Get02LdtlRetailWithStoreProdure(string storeProdure, string fromDate, string toDate, string whereClause, bool isEmployee)
        {
            object[] parms =
                {
                    "@FromDate", fromDate,
                    "@ToDate", toDate,
                    "@WhereClause",whereClause,
                    "@IsEmployee",isEmployee
                };

            return Db.ReadList(storeProdure, true, Make02Ldt, parms);
        }

        /// <summary>
        /// Phiếu thu(Mẫu số 1)
        /// </summary>
        public IList<C30BBEntity> GetReportC30BBItem(int year, int refTypeId)
        {
            const string sql = @"uspReport_C30BBItem";
            object[] parms = { "@Year", year, "@RefTypeId", refTypeId };
            return Db.ReadList(sql, true, MakeC30BB, parms);
        }

        /// <summary>
        /// Phiếu thu(Mẫu số 1)
        /// </summary>
        public IList<C30BB501Entity> GetReportC30BB501(string storeProdure, string refIdList)
        {
            IList<C30BB501Entity> list = new List<C30BB501Entity>();
            foreach (var refId in refIdList.Split(';'))
            {
                object[] parms = { "@RefID", refId };
                var c30Bb501List = Db.Read(storeProdure, true, MakeReceiveVoucher, parms);
                if (c30Bb501List != null)
                {
                    list.Add(c30Bb501List);
                }

            }
            return list;
        }

        public IList<InventoryItemReportEntity> GetInventoryItems(string refIdList)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region 1 - Estimate Report

        /// <summary>
        /// Tổng hợp dự toán thu Ngân sách nhà nước
        /// </summary>
        public List<GeneralReceiptEstimateEntity> GetGeneralReceiptEstimates(short yearOfEsitamte)
        {
            const string sql = @"uspReport_GeneralReceiptEstimate";

            object[] parms = { "@YearOfEstimate", yearOfEsitamte };
            return Db.ReadList(sql, true, MakeGeneralReceiptEstimate, parms);
        }

        /// <summary>
        /// Tổng hợp dự toán chi Ngân sách nhà nước
        /// </summary>
        public List<GeneralPaymentEstimateEntity> GetGeneralPaymentEstimates(short yearOfEsitamte)
        {
            const string sql = @"uspReport_GeneralPaymentEstimate";

            object[] parms = { "@YearOfEstimate", yearOfEsitamte };
            return Db.ReadList(sql, true, MakeGeneralPaymentEstimate, parms);
        }

        /// <summary>
        /// Tổng hợp dự toán thu chi Ngân sách nhà nước
        /// </summary>
        public List<GeneralEstimateEntity> GetGeneralEstimates(short yearOfEsitamte)
        {
            const string sql = @"uspReport_GeneralEstimate";

            object[] parms = { "@YearOfEstimate", yearOfEsitamte };
            return Db.ReadList(sql, true, MakeGeneralEstimate, parms);
        }

        /// <summary>
        /// Dự toán chi tiết chi ngân sách nhà nước
        /// </summary>
        public List<GeneralPaymentDetailEstimateEntity> GetGeneralPaymentDetailEstimates(short yearOfEsitamte)
        {
            const string sql = @"uspReport_GeneralPaymentDetailEstimate";

            object[] parms = { "@YearOfEstimate", yearOfEsitamte };
            return Db.ReadList(sql, true, MakeGeneralPaymentDetailEstimate, parms);
        }

        public List<EmployeeForEstimateEntity> GetEmployeeForEstimateReport(bool IsCompanyProfile)
        {
            string sql;
            if (IsCompanyProfile)
            {
                sql = @"uspGet_EmployeeFor_EstimateReportByCompanyProfile";
            }
            else
            {
                sql = @"uspGet_EmployeeFor_EstimateReport";
            }


            return Db.ReadList(sql, true, MakeEmployee);
        }

        public List<FixedAssetForEstimateEntity> GetFixedAssetForEstimateReport()
        {
            const string sql = @"uspGet_FixedAsset_ForEstimateReport";
            return Db.ReadList(sql, true, MakeFixedAsset);
        }

        /// <summary>
        /// Tổng hợp báo cáo tình hình kinh phí
        /// </summary>
        public List<FundStuationEntity> GetFundStuations(short yearOfEstimate)
        {
            const string sql = @"uspReport_FundStuation";

            object[] parms = { "@YearOfEstimate", yearOfEstimate };
            return Db.ReadList(sql, true, MakeFundStuation, parms);
        }

        #endregion

        #region 2 - Financial Report

        /// <summary>
        /// Báo cáo tạm ứng
        /// </summary>
        public List<B03BNGEntity> GetReportB03BNGs(short amountType, string currencyCode, DateTime fromDate, DateTime toDate)
        {
            const string sql = @"uspReport_B03BNG";

            object[] parms = { "@AmountType", amountType, "@CurrencyCode", currencyCode, "@FromDate", fromDate, "@ToDate", toDate };
            return Db.ReadList(sql, true, MakeB03BNG, parms);
        }

        public List<F03BNGEntity> GetReportF03BNGs(string storeProcedureName, short amountType, string currencyCode, DateTime fromDate, DateTime toDate)
        {
            string sql = storeProcedureName;

            object[] parms = { "@AmountType", amountType, "@CurrencyCode", currencyCode, "@FromDate", fromDate, "@ToDate", toDate };
            return Db.ReadList(sql, true, MakeF03BNG, parms);
        }

        /// <summary>
        /// Báo cáo quyết toán nguồn kinh phí quỹ tạm giữ
        /// </summary>
        public List<F331BNGEntity> GetReportF331BNGs(string storeProcedureName, short amountType, string accountCode, string currencyCode, DateTime fromDate, DateTime toDate)
        {
            string sql = storeProcedureName;

            object[] parms = { "@AmountType", amountType, "@AccountCode", accountCode, "@CurrencyCode", currencyCode, "@FromDate", fromDate, "@ToDate", toDate };
            return Db.ReadList(sql, true, MakeF331BNG, parms);
        }

        /// <summary>
        /// Báo cáo thu, chi quỹ tạm giữ NSNN từ nguồn 70% số thu phí, lệ phí lãnh sự tại các CQĐD Việt Nam ở nước ngoài
        /// </summary>
        public List<B09BNGEntity> GetReportB09BNGs(string storeProcedureName, short amountType, string currencyCode, DateTime fromDate, DateTime toDate)
        {
            string sql = storeProcedureName;

            object[] parms = { "@AmountType", amountType, "@CurrencyCode", currencyCode, "@FromDate", fromDate, "@ToDate", toDate };
            return Db.ReadList(sql, true, MakeB09BNG, parms);
        }

        /// <summary>
        /// Báo cáo quyết toán kinh phí hoạt động
        /// </summary>
        public List<B01BCQTEntity> GetReportB01BCQTs(string storeProcedureName, short amountType, string currencyCode, DateTime fromDate, DateTime toDate)
        {
            string sql = storeProcedureName;

            object[] parms = { "@AmountType", amountType, "@CurrencyCode", currencyCode, "@FromDate", fromDate, "@ToDate", toDate };
            return Db.ReadList(sql, true, MakeFinacialB01BCQT, parms);
        }

        /// <summary>
        /// Báo cáo quyết toán nguồn kinh phí
        /// </summary>
        public List<ReportF03BCTEntity> GetReportF03BCTs(string storeProcedureName, short amountType, string currencyCode, DateTime fromDate, DateTime toDate, DateTime lastYear, DateTime periodDate, int option)
        {
            List<ReportF03BCTEntity> reports = new List<ReportF03BCTEntity>();
            ReportF03BCTEntity report = new ReportF03BCTEntity();

            object[] parms = {
                "@AmountType", amountType,
                "@CurrencyCode", currencyCode,
                "@FromDate", fromDate,
                "@ToDate", toDate,
                "@LastYear", lastYear,
                "@PeriodDate", periodDate,
                "@Option", 1
            };

            var reportF03BCTDetail = new List<ReportF03BCTDetailEntity>();

            reportF03BCTDetail.AddRange(Db.ReadList(storeProcedureName, true, MakeF03BCT, parms));

            parms[13] = 2;
            reportF03BCTDetail.AddRange(Db.ReadList(storeProcedureName, true, MakeF03BCT, parms));

            report.Table1 = reportF03BCTDetail;

            parms[13] = 3;
            report.Table2 = Db.ReadList(storeProcedureName, true, MakeF03BCT, parms);

            reports.Add(report);

            return reports;
        }

        /// <summary>
        /// Bảng cân đối tài khoản
        /// </summary>
        public IList<B01HEntity> GetB01HWithStoreProdure(string storeProdure, string fromDate, string toDate, string currencyCode, int amounType)
        {
            object[] parms =
                {
                    "@FromDate", DateTime.Parse( fromDate),
                    "@ToDate", DateTime.Parse( toDate),
                    "@CurrencyCode",  currencyCode,
                    "@AmounType",  amounType
                };
            return Db.ReadList(storeProdure, true, MakeB01H, parms);
        }

        public IList<ReportB01BCTCEntity> GetB01BCTC(string storeProdure, string fromDate, string toDate, string currencyCode, int amounType)
        {
            object[] parms =
                {
                    "@FromDate", DateTime.Parse( fromDate),
                    "@ToDate", DateTime.Parse( toDate),
                    "@CurrencyCode",  currencyCode,
                    "@AmounType",  amounType
                };
            return Db.ReadList(storeProdure, true, MakeB01BCTC, parms);

        }

        public IList<ReportB03bBCTCEntity> GetB03bBCTC(string storeProdure, string fromDate, string toDate, string currencyCode, int amounType)
        {
            object[] parms =
                {
                    "@FromDate", DateTime.Parse( fromDate),
                    "@ToDate", DateTime.Parse( toDate),
                    "@CurrencyCode",  currencyCode,
                    "@AmountType",  amounType
                };
            return Db.ReadList(storeProdure, true, MakeB03bBCTC, parms);
        }

        #endregion

        #region 3 - Cash Report

        public List<CashReportEntity> CashRepportListGeneal(string storeProcedure, string fromDate, string toDate, string accountNumber, string currencyCode, int amountType, bool isBank, int? bankId)
        {
            object[] parms = {
                "@FromDate", DateTime.Parse(fromDate),
                "@ToDate", DateTime.Parse(toDate),
                "@AccountCode", accountNumber,
                "@CurrencyCode", currencyCode,
                "@AmountType", amountType,
                "@IsBank", isBank,
                "@BankID", bankId
            };
            return Db.ReadList(storeProcedure, true, MakeS11AH, parms);
        }

        public List<CashReportEntity> CashRepportListDetail(string storeProcedure, string fromDate, string toDate, string accountNumber, string correspondingAccountNumber, string currencyCode, int amountType, bool isBank, int? bankId)
        {
            object[] parms = {
                "@FromDate", DateTime.Parse(fromDate),
                "@ToDate", DateTime.Parse(toDate),
                "@AccountCode", accountNumber,
                "@CorrespondingAccountNumber", correspondingAccountNumber,
                "@CurrencyCode", currencyCode,
                "@AmountType", amountType,
                "@IsBank", isBank,
                "@BankID", bankId
            };
            return Db.ReadList(storeProcedure, true, MakeS11AH, parms);
        }

        #endregion

        #region 5 - Report Ledger Accounting

        /// <summary>
        /// Sổ nhật ký chung
        /// </summary>
        public IList<S03AHEntity> GetS03AHWithStoreProdure(string storeProdure, string fromDate, string toDate, string currencyCode, int amounType)
        {
            object[] parms =
                {
                    "@FromDate", DateTime.Parse( fromDate),
                    "@ToDate", DateTime.Parse( toDate),
                    "@CurrencyCode",  currencyCode,
                    "@AmounType",  amounType
                };
            return Db.ReadList(storeProdure, true, MakeS03AH, parms);
        }

        /// <summary>
        /// Lấy dữ liệu chi tiết tài khoản
        /// </summary>
        public IList<S33HEntity> GetS33HWithStoreProdure(string storeProdure, string accountNumber, string fromDate, string toDate, string currencyCode, string budgetGroupCode, string fixedAssetCode, string departmentCode, int amounType, string whereClause, string selectedField, string selectedAllValueField)
        {
            try
            {
                object[] parms =
                {
                    "@pAccountNumber", accountNumber,
                    "@FromDate", DateTime.Parse( fromDate),
                    "@ToDate", DateTime.Parse( toDate),
                    "@CurrencyCode",  currencyCode,
                    "@AmounType",  amounType,
                    "@WhereClause",  whereClause,
                    "@BudgetGroupCode",budgetGroupCode,
                    "@FixedassetCode",fixedAssetCode,
                    "@DepartmentCode",departmentCode,
                    "@SelectedField",selectedField,
                    "@SelectedAllValueField",selectedAllValueField,
                };
                return Db.ReadList(storeProdure, true, MakeS33H, parms);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Báo cáo tạm ứng 
        /// </summary>
        public IList<AdvancePaymentEntity> GetAdvancePaymentHWithStoreProdure(string storeProdure, string fromDate, string toDate, string currencyCode, int amountType, int accountType)
        {
            object[] parms =
                {
                    "@FromDate", DateTime.Parse( fromDate),
                    "@ToDate", DateTime.Parse( toDate),
                    "@CurrencyCode", currencyCode,
                    "@AmountType", amountType,
                    "@AccountType", accountType,
                };
            return Db.ReadList(storeProdure, true, MakeAdvancePayment, parms);
        }

        /// <summary>
        /// Bảng cân đối số phát sinh
        /// </summary>
        public IList<S05HEntity> GetS05HWithStoreProdure(string storeProdure, string fromDate, string toDate, string currencyCode, int amounType)
        {
            object[] parms =
                {
                    "@FromDate", DateTime.Parse( fromDate),
                    "@ToDate", DateTime.Parse( toDate),
                    "@CurrencyCode",  currencyCode,
                    "@AmounType",  amounType
                };
            return Db.ReadList(storeProdure, true, MakeS05H, parms);
        }

        /// <summary>
        /// Sổ cái tài khoản
        /// </summary>
        public List<S03BHEntity> GetS03BHWithStoreProdure(string storeProcedure, string fromdate, string toDate, string accountNumber, string correspondingAccountNumber, string currencyCode, int amountType)
        {
            object[] parms = {
                "@FromDate", DateTime.Parse(fromdate),
                "@ToDate", DateTime.Parse(toDate),
                "@AccountCode", accountNumber,
                "@CorrespondingAccountNumber", correspondingAccountNumber,
                "@CurrencyCode", currencyCode,
                "@AmountType", amountType
            };
            return Db.ReadList(storeProcedure, true, MakeS03BH, parms);
        }

        #endregion

        #region 6 - Report Stock

        /// <summary>
        /// Báo cáo tồn kho
        /// </summary>
        public IList<B14QEntity> GetB14QWithStoreProdure(string storeProdure, string fromDate, string toDate, string currencyCode, string accountnumber, string stockIdList, int amounType)
        {
            object[] parms =
                {
                    "@FromDate", DateTime.Parse( fromDate),
                    "@ToDate", DateTime.Parse( toDate),
                    "@CurrencyCode",  currencyCode,
                    "@AccountNumber",  accountnumber,
                    "@PStockID",  stockIdList,
                    "@AmounType",  amounType
                };
            return Db.ReadList(storeProdure, true, MakeB14Q, parms);
        }

        #endregion

        #region 8 - Report FixedAsset

        /// <summary>
        /// Báo cáo tình hình tăng giảm TSCĐ
        /// </summary>
        public List<FixedAssetB03HEntity> GetFixedAssetB03H(string fromDate, string toDate, string currencyCode)
        {
            const string sql = @"uspReport_B03H";
            object[] parms = { "@FromDate", DateTime.Parse(fromDate), "@ToDate", DateTime.Parse(toDate), "@CurrencyCode", currencyCode };
            return Db.ReadList(sql, true, MakeFixedAssetB03H, parms);
        }

        public List<FixedAssetB03HEntity> GetFixedAssetB03HAmountType(string fromDate, string toDate, int currencyDecimalDigits)
        {
            const string sql = @"uspReport_B03H_AmountType";
            object[] parms = { "@FromDate", DateTime.Parse(fromDate), "@ToDate", DateTime.Parse(toDate), "@Roud", currencyDecimalDigits };
            return Db.ReadList(sql, true, MakeFixedAssetB03H, parms);
        }

        /// <summary>
        /// Báo báo Hủy, thanh lý tài sản cố định
        /// </summary>
        public List<FixedAssetB01Entity> GetFixedAssetB01(string fromDate, string toDate, string currencyCode)
        {
            const string sql = @"uspReport_B01";
            object[] parms = { "@FromDate", DateTime.Parse(fromDate), "@ToDate", DateTime.Parse(toDate), "@CurrencyCode", currencyCode };
            return Db.ReadList(sql, true, MakeFixedAssetB01, parms);
        }

        public List<FixedAssetB01Entity> GetFixedAssetB01AmountType(string fromDate, string toDate, int currencyDecimalDigits)
        {
            const string sql = @"uspReport_B01_AmountType";
            object[] parms = { "@FromDate", DateTime.Parse(fromDate), "@ToDate", DateTime.Parse(toDate), "@Roud", currencyDecimalDigits };
            return Db.ReadList(sql, true, MakeFixedAssetB01, parms);
        }

        /// <summary>
        /// Báo cáo hao mòn tài sản cố định
        /// </summary>
        public List<FixedAssetC55aHDEntity> GetFixedAssetC55aHD(string fromDate, string toDate, string faParameter, string faCategoryCode, string currencyCode)
        {
            const string sql = @"uspReport_C55a_HD";
            object[] parms = { "@FromDate", DateTime.Parse(fromDate), "@ToDate", DateTime.Parse(toDate), "@FixedAssetParameter", faParameter, "@FixedAssetCategoryID", faCategoryCode, "@CurrencyCode", currencyCode };

            return Db.ReadList(sql, true, MakeFixedAssetC55aHD, parms);
        }

        public List<FixedAssetC55aHDEntity> GetFixedAssetC55aHDAmountType(string fromDate, string toDate, string faParameter, string faCategoryCode, int currencyDecimalDigits)
        {
            const string sql = @"uspReport_C55a_HD_AmountType";
            object[] parms = { "@FromDate", DateTime.Parse(fromDate), "@ToDate", DateTime.Parse(toDate), "@FixedAssetParameter", faParameter, "@FixedAssetCategoryID", faCategoryCode, "@Roud", currencyDecimalDigits };
            return Db.ReadList(sql, true, MakeFixedAssetC55aHD, parms);
        }

        /// <summary>
        /// Biên bản kiểm kê tài sản cố định
        /// </summary>
        public List<FixedAssetFAInventoryEntity> GetFixedAssetFAInventory(string fromDate, string toDate, string currencyCode, int currencyDecimalDigits)
        {
            const string sql = @"uspReport_FAInventory";
            object[] parms = { "@FromDate", DateTime.Parse(fromDate), "@ToDate", DateTime.Parse(toDate), "@CurrencyCode", currencyCode, "@Roud", currencyDecimalDigits };
            return Db.ReadList(sql, true, MakeFixedAssetFAInventory, parms);
        }

        public List<FixedAssetFAInventoryEntity> GetFixedAssetFAInventoryAmountType(string fromDate, string toDate, int currencyDecimalDigits)
        {
            const string sql = @"uspReport_FAInventory_AmountType";
            object[] parms = { "@FromDate", DateTime.Parse(fromDate), "@ToDate", DateTime.Parse(toDate), "@Roud", currencyDecimalDigits };
            return Db.ReadList(sql, true, MakeFixedAssetFAInventory, parms);
        }

        /// <summary>
        /// Báo cáo kê khai trụ sở làm việc, nhà ở cơ sở hoạt động sự nghiệp
        /// </summary>
        public List<FixedAssetFAInventoryHouseEntity> GetFixedAssetFAInventoryHouse(string fromDate, string toDate, string currencyCode)
        {
            const string sql = @"uspReport_FAInventory_House";
            object[] parms = { "@FromDate", DateTime.Parse(fromDate), "@ToDate", DateTime.Parse(toDate), "@CurrencyCode", currencyCode };
            return Db.ReadList(sql, true, MakeFixedAssetFAInventoryHouse, parms);
        }

        public List<FixedAssetFAInventoryHouseEntity> GetFixedAssetFAInventoryHouseAmountType(string fromDate, string toDate, int currencyDecimalDigits)
        {
            const string sql = @"uspReport_FAInventory_House_AmountType";
            object[] parms = { "@FromDate", DateTime.Parse(fromDate), "@ToDate", DateTime.Parse(toDate), "@Roud", currencyDecimalDigits };
            return Db.ReadList(sql, true, MakeFixedAssetFAInventoryHouse, parms);
        }

        public List<FixedAssetFAInventoryHouseEntity> GetFixedAssetFAB01House(string fromDate, string toDate, int currencyDecimalDigits)
        {
            const string sql = @"uspReport_FAB01_House_AmountType";
            object[] parms = {
                "@FromDate", DateTime.Parse(fromDate),
                "@ToDate", DateTime.Parse(toDate),
                "@Roud", currencyDecimalDigits
            };
            return Db.ReadList(sql, true, MakeFixedAssetFAInventoryHouse, parms);
        }

        /// <summary>
        /// Báo cáo kê khai xe ô tô
        /// </summary>
        public List<FixedAssetFAInventoryCarEntity> GetFixedAssetFAInventoryCar(string fromDate, string toDate, string currencyCode)
        {
            const string sql = @"uspReport_FAInventory_Car";
            object[] parms = { "@FromDate", DateTime.Parse(fromDate), "@ToDate", DateTime.Parse(toDate), "@CurrencyCode", currencyCode };
            return Db.ReadList(sql, true, MakeFixedAssetFAInventoryCar, parms);
        }

        public List<FixedAssetFAInventoryCarEntity> GetFixedAssetFAInventoryCarAmountType(string fromDate, string toDate, int currencyDecimalDigits)
        {
            const string sql = @"uspReport_FAInventory_Car_AmountType";
            object[] parms = { "@FromDate", DateTime.Parse(fromDate), "@ToDate", DateTime.Parse(toDate), "@Roud", currencyDecimalDigits };
            return Db.ReadList(sql, true, MakeFixedAssetFAInventoryCar, parms);
        }

        public List<FixedAssetFAInventoryCarEntity> GetFixedAssetFAB01Car(string fromDate, string toDate, int currencyDecimalDigits)
        {
            const string sql = @"uspReport_FAB01_Car_AmountType";
            object[] parms = {
                "@FromDate", DateTime.Parse(fromDate),
                "@ToDate", DateTime.Parse(toDate),
                "@Roud", currencyDecimalDigits
            };
            return Db.ReadList(sql, true, MakeFixedAssetFAInventoryCar, parms);
        }

        /// <summary>
        /// Báo cáo tình hình tăng, giảm tài sản nhà nước
        /// </summary>
        public List<FixedAssetFAInventoryEntity> GetFixedAssetFAInventory3000(string fromDate, string toDate, string currencyCode)
        {
            const string sql = @"uspReport_FAInventory3000";
            object[] parms = { "@FromDate", DateTime.Parse(fromDate), "@ToDate", DateTime.Parse(toDate), "@CurrencyCode", currencyCode };
            return Db.ReadList(sql, true, MakeFixedAssetFAInventory, parms);
        }

        public List<FixedAssetFAInventoryEntity> GetFixedAssetFAInventoryAmountType3000(string fromDate, string toDate)
        {
            const string sql = @"uspReport_FAInventory_AmountType30000";
            object[] parms = { "@FromDate", DateTime.Parse(fromDate), "@ToDate", DateTime.Parse(toDate) };
            return Db.ReadList(sql, true, MakeFixedAssetFAInventory, parms);
        }

        /// <summary>
        /// Sổ tài sản cố định
        /// </summary>
        public List<FixedAssetS31HEntity> GetFixedAssetS31H(string fromDate, string toDate, string faParameter, string faCategoryCode, string currencyCode)
        {
            const string sql = @"uspReport_S31H";
            object[] parms = { "@FromDate", DateTime.Parse(fromDate), "@ToDate", DateTime.Parse(toDate), "@FixedAssetParameter", faParameter, "@FixedAssetCategoryCode", faCategoryCode, "@CurrencyCode", currencyCode };
            return Db.ReadList(sql, true, MakeFixedAssetS31H, parms);
        }

        /// <summary>
        /// Báo cáo tăng tài sản cố định
        /// </summary>
        public List<FixedAssetB02Entity> GetFixedAssetB02(string fromDate, string toDate, string currencyCode)
        {
            const string sql = @"uspReport_B02";
            object[] parms = { "@FromDate", DateTime.Parse(fromDate), "@ToDate", DateTime.Parse(toDate), "@CurrencyCode", currencyCode };
            return Db.ReadList(sql, true, MakeFixedAssetB02, parms);
        }

        public List<FixedAssetB02Entity> GetFixedAssetB02ByAmountType(string fromDate, string toDate, int currencyDecimalDigits)
        {
            const string sql = @"uspReport_B02_AmountType";
            object[] parms = { "@FromDate", DateTime.Parse(fromDate), "@ToDate", DateTime.Parse(toDate), "@Roud", currencyDecimalDigits };
            return Db.ReadList(sql, true, MakeFixedAssetB02, parms);
        }

        /// <summary>
        /// Báo cáo tình hình tăng, giảm tài sản nhà nước
        /// </summary>
        public List<FixedAssetB03H30KEntity> GetFixedAssetB03H30K(string fromDate, string toDate, int currencyDecimalDigits)
        {
            const string sql = @"uspReport_B03H_3000";
            object[] parms = { "@FromDate", DateTime.Parse(fromDate), "@ToDate", DateTime.Parse(toDate), "@Roud", currencyDecimalDigits };
            return Db.ReadList(sql, true, MakeFixedAssetB03H30K, parms);
        }

        /// <summary>
        /// Danh mục tài sản khác (trừ trụ sở làm việc và xe ô tô) đề nghị xử lý 
        /// </summary>
        public List<FixedAsset30KPart2Entity> GetFixedAsset30KPart2(string fromDate, string toDate, int currencyDecimalDigits)
        {
            const string sql = @"uspReport_FAInventory_30000Part2";
            object[] parms = { "@FromDate", DateTime.Parse(fromDate), "@ToDate", DateTime.Parse(toDate), "@Roud", currencyDecimalDigits };
            return Db.ReadList(sql, true, MakeFixedAsset30KPart2, parms);
        }

        /// <summary>
        /// Danh mục tài sản khác (trừ trụ sở làm việc và xe ô tô) đề nghị xử lý 
        /// </summary>
        public List<FixedAsset30KPart2Entity> GetFixedAssetFAB0130KPart2(string fromDate, string toDate, int currencyDecimalDigits)
        {
            const string sql = @"uspReport_FAB01_30000Part2";
            object[] parms = {
                "@FromDate", DateTime.Parse(fromDate),
                "@ToDate", DateTime.Parse(toDate),
                "@Roud", currencyDecimalDigits
            };
            return Db.ReadList(sql, true, MakeFixedAsset30KPart2, parms);
        }

        public IList<FixedAssetCardEntity> GetFixedAssetCard(string fixedAssetIdList, int currencyDecimalDigits)
        {
            IList<FixedAssetCardEntity> list = new List<FixedAssetCardEntity>();
            foreach (var fixedAssetId in fixedAssetIdList.Split(';'))
            {
                object[] parms = {
                    "@FixedAssetID", fixedAssetId,
                    "@Roud", currencyDecimalDigits
                };
                var fixedAssetCardList = Db.Read(@"uspReport_FixedAsset", true, MakeFixedAssetCard, parms);
                if (fixedAssetCardList != null)
                {
                    list.Add(fixedAssetCardList);
                }

            }
            return list;
        }

        public IList<FixedAssetCardsEntity> GetFixedAssetCards(string fixedAssetIdList, int currencyDecimalDigits)
        {
            IList<FixedAssetCardsEntity> fixedAssetCards = new List<FixedAssetCardsEntity>();

            foreach (var fixedAssetId in fixedAssetIdList.Split(';'))
            {
                FixedAssetCardsEntity fixedAssetCard = new FixedAssetCardsEntity();

                object[] parms = { "@FixedAssetID", fixedAssetId, "@Roud", currencyDecimalDigits, "@Option", 1 };

                fixedAssetCard = Db.Read(@"uspReport_FixedAssetCard", true, MakeFixedAssetMasterCard, parms);

                parms[5] = 2;
                fixedAssetCard.FixedAssetDetailCards01 = Db.ReadList(@"uspReport_FixedAssetCard", true, MakeFixedAssetDetailCards01, parms);
                if (fixedAssetCard.FixedAssetDetailCards01 == null || fixedAssetCard.FixedAssetDetailCards01.Count == 0)
                {
                    fixedAssetCard.FixedAssetDetailCards01 = new List<FixedAssetDetailCards01Entity>()
                    {
                        new FixedAssetDetailCards01Entity ()
                        {
                            RefNo = string.Empty
                        }
                    };
                }

                parms[5] = 3;
                fixedAssetCard.FixedAssetDetailCards02 = Db.ReadList(@"uspReport_FixedAssetCard", true, MakeFixedAssetDetailCards02, parms);
                if (fixedAssetCard.FixedAssetDetailCards02 == null || fixedAssetCard.FixedAssetDetailCards02.Count == 0)
                {
                    fixedAssetCard.FixedAssetDetailCards02 = new List<FixedAssetDetailCards02Entity>()
                    {
                        new FixedAssetDetailCards02Entity()
                        {
                            FixedAssetAccessaryName = string.Empty
                        }
                    };
                }

                fixedAssetCards.Add(fixedAssetCard);
            }
            return fixedAssetCards;
        }

        /// <summary>
        /// Sổ theo dõi TSCĐ và CCDC tại nơi sử dụng
        /// </summary>
        public IList<FixedAssetS26HEntity> GetFixedAssetS26H(string storedProcedure, DateTime fromDate, DateTime toDate, string currencyCode, int amountType, string departmentCode, int fixedAssetCategoryIds, int option)
        {
            object[] parms = {
                "@FromDate", fromDate,
                "@ToDate", toDate,
                "@CurrencyCode", currencyCode,
                "@AmountType", amountType,
                "@DepartmentCode", departmentCode,
                "@FixedAssetCategoryIds", fixedAssetCategoryIds,
                "@Option", option
            };
            return Db.ReadList(storedProcedure, true, MakeFixedAssetS26H, parms);
        }

        /// <summary>
        /// sổ tài sản cố định
        /// </summary>
        public IList<FixedAssetS24HEntity> GetFixedAssetS24H(string storedProcedure, string currencyCode, int amountType, string fromDate, string toDate, string departmentCode, string fixedAssetCategoryCode, string fixedAssetIds)
        {
            string paramDepartment = null;
            string paramFixedAssetCategory = null;
            string paramFixedAssetId = null;
            if (!string.IsNullOrEmpty(departmentCode))
                paramDepartment = departmentCode;
            if (!string.IsNullOrEmpty(fixedAssetCategoryCode))
                paramFixedAssetCategory = fixedAssetCategoryCode;
            if (!string.IsNullOrEmpty(fixedAssetIds))
                paramFixedAssetId = fixedAssetIds;

            object[] parms = {
                "@FromDate", Convert.ToDateTime(fromDate),
                "@ToDate", Convert.ToDateTime(toDate),
                "@CurrencyCode", currencyCode,
                "@AmountType", amountType,
                "@DepartmentCode", paramDepartment,
                "@FixedAssetCategoryCode", paramFixedAssetCategory,
                "@FixedAssetIDs", paramFixedAssetId
            };
            return Db.ReadList(storedProcedure, true, MakeFixedAssetS24H, parms);
        }

        public IList<ReportActivityB02Entity> GetReportActivityB02(string storeProcedureName, int amountType, string currencyCode, DateTime fromDate, DateTime toDate)
        {
            object[] parms = {
                "@FromDate", fromDate,
                "@ToDate", toDate,
                "@CurrencyCode", currencyCode,
                "@AmountType", amountType,
            };

            return Db.ReadList(storeProcedureName, true, MakeActivityB02, parms);
        }

        public IList<ReportB04BCTCEntity> GetReportB04BCTC(string storeProcedureName, int amountType, string currencyCode, DateTime fromDate, DateTime toDate)
        {
            var reportB04s = new List<ReportB04BCTCEntity>();
            var reportB04 = new ReportB04BCTCEntity();

            object[] parms = { "@DateFrom", fromDate, "@DateTo", toDate, "@CurrencyCode", currencyCode, "@AmountType", amountType, "@Option", 1 };
            reportB04.Table01 = Db.ReadList(storeProcedureName, true, MakeReportB04BCTCDetail01, parms);
            if (reportB04.Table01.Sum(s => s.BeginAmount) == 0 && reportB04.Table01.Sum(s => s.EndAmount) == 0)
            {
                reportB04.Table01 = new List<ReportB04BCTCDetail01Entity>();
            }

            parms[9] = 2;
            reportB04.Table02 = Db.ReadList(storeProcedureName, true, MakeReportB04BCTCDetail01, parms);
            if (reportB04.Table02.Sum(s => s.BeginAmount) == 0 && reportB04.Table02.Sum(s => s.EndAmount) == 0)
            {
                reportB04.Table02 = new List<ReportB04BCTCDetail01Entity>();
            }

            parms[9] = 3;
            reportB04.Table03 = Db.ReadList(storeProcedureName, true, MakeReportB04BCTCDetail01, parms);
            if (reportB04.Table03.Sum(s => s.BeginAmount) == 0 && reportB04.Table03.Sum(s => s.EndAmount) == 0)
            {
                reportB04.Table03 = new List<ReportB04BCTCDetail01Entity>();
            }

            parms[9] = 4;
            reportB04.Table04 = Db.ReadList(storeProcedureName, true, MakeReportB04BCTCDetail02, parms);
            if (reportB04.Table04.Sum(s => s.TangibleFixedAssets) == 0 && reportB04.Table04.Sum(s => s.IntangibleFixedAssets) == 0 && reportB04.Table04.Sum(s => s.TotalAmount) ==0)
            {
                reportB04.Table04 = new List<ReportB04BCTCDetail02Entity>();
            }

            parms[9] = 5;
            reportB04.Table05 = Db.ReadList(storeProcedureName, true, MakeReportB04BCTCDetail01, parms);
            if (reportB04.Table05.Sum(s => s.BeginAmount) == 0 && reportB04.Table05.Sum(s => s.EndAmount) == 0)
            {
                reportB04.Table05 = new List<ReportB04BCTCDetail01Entity>();
            }

            parms[9] = 6;
            reportB04.Table06 = Db.ReadList(storeProcedureName, true, MakeReportB04BCTCDetail01, parms);
            if (reportB04.Table06.Sum(s => s.BeginAmount) == 0 && reportB04.Table06.Sum(s => s.EndAmount) == 0)
            {
                reportB04.Table06 = new List<ReportB04BCTCDetail01Entity>();
            }

            parms[9] = 7;
            reportB04.Table07 = Db.ReadList(storeProcedureName, true, MakeReportB04BCTCDetail01, parms);
            if (reportB04.Table07.Sum(s => s.BeginAmount) == 0 && reportB04.Table07.Sum(s => s.EndAmount) == 0)
            {
                reportB04.Table07 = new List<ReportB04BCTCDetail01Entity>();
            }

            parms[9] = 8;
            reportB04.Table08 = Db.ReadList(storeProcedureName, true, MakeReportB04BCTCDetail01, parms);
            if (reportB04.Table08.Sum(s => s.BeginAmount) == 0 && reportB04.Table08.Sum(s => s.EndAmount) == 0)
            {
                reportB04.Table08 = new List<ReportB04BCTCDetail01Entity>();
            }

            parms[9] = 9;
            reportB04.Table09 = Db.ReadList(storeProcedureName, true, MakeReportB04BCTCDetail01, parms);
            if (reportB04.Table09.Sum(s => s.BeginAmount) == 0 && reportB04.Table09.Sum(s => s.EndAmount) == 0)
            {
                reportB04.Table09 = new List<ReportB04BCTCDetail01Entity>();
            }

            parms[9] = 10;
            reportB04.Table10 = Db.ReadList(storeProcedureName, true, MakeReportB04BCTCDetail01, parms);
            if (reportB04.Table10.Sum(s => s.BeginAmount) == 0 && reportB04.Table10.Sum(s => s.EndAmount) == 0)
            {
                reportB04.Table10 = new List<ReportB04BCTCDetail01Entity>();
            }

            parms[9] = 11;
            reportB04.Table11 = Db.ReadList(storeProcedureName, true, MakeReportB04BCTCDetail01, parms);
            if (reportB04.Table11.Sum(s => s.BeginAmount) == 0 && reportB04.Table11.Sum(s => s.EndAmount) == 0)
            {
                reportB04.Table11 = new List<ReportB04BCTCDetail01Entity>();
            }

            parms[9] = 12;
            reportB04.Table12 = Db.ReadList(storeProcedureName, true, MakeReportB04BCTCDetail01, parms);
            if (reportB04.Table12.Sum(s => s.BeginAmount) == 0 && reportB04.Table12.Sum(s => s.EndAmount) == 0)
            {
                reportB04.Table12 = new List<ReportB04BCTCDetail01Entity>();
            }

            parms[9] = 13;
            reportB04.Table13 = Db.ReadList(storeProcedureName, true, MakeReportB04BCTCDetail01, parms);
            if (reportB04.Table13.Sum(s => s.BeginAmount) == 0 && reportB04.Table13.Sum(s => s.EndAmount) == 0)
            {
                reportB04.Table13 = new List<ReportB04BCTCDetail01Entity>();
            }

            parms[9] = 14;
            reportB04.Table14 = Db.ReadList(storeProcedureName, true, MakeReportB04BCTCDetail01, parms);
            if (reportB04.Table14.Sum(s => s.BeginAmount) == 0 && reportB04.Table14.Sum(s => s.EndAmount) == 0)
            {
                reportB04.Table14 = new List<ReportB04BCTCDetail01Entity>();
            }

            parms[9] = 15;
            reportB04.Table15 = Db.ReadList(storeProcedureName, true, MakeReportB04BCTCDetail03, parms);
            if (reportB04.Table15.Sum(s => s.ExchangeRateDifference) == 0 && reportB04.Table15.Sum(s => s.AccumulatedSurplus) == 0)
            {
                reportB04.Table15 = new List<ReportB04BCTCDetail03Entity>();
            }

            parms[9] = 16;
            reportB04.Table16 = Db.ReadList(storeProcedureName, true, MakeReportB04BCTCDetail01, parms);
            if (reportB04.Table16.Sum(s => s.BeginAmount) == 0 && reportB04.Table16.Sum(s => s.EndAmount) == 0)
            {
                reportB04.Table16 = new List<ReportB04BCTCDetail01Entity>();
            }

            parms[9] = 17;
            reportB04.Table17 = Db.ReadList(storeProcedureName, true, MakeReportB04BCTCDetail01, parms);
            if (reportB04.Table17.Sum(s => s.BeginAmount) == 0 && reportB04.Table17.Sum(s => s.EndAmount) == 0)
            {
                reportB04.Table17 = new List<ReportB04BCTCDetail01Entity>();
            }

            parms[9] = 18;
            reportB04.Table18 = Db.ReadList(storeProcedureName, true, MakeReportB04BCTCDetail01, parms);
            if (reportB04.Table18.Sum(s => s.BeginAmount) == 0 && reportB04.Table18.Sum(s => s.EndAmount) == 0)
            {
                reportB04.Table18 = new List<ReportB04BCTCDetail01Entity>();
            }

            parms[9] = 19;
            reportB04.Table19 = Db.ReadList(storeProcedureName, true, MakeReportB04BCTCDetail01, parms);
            if (reportB04.Table19.Sum(s => s.BeginAmount) == 0 && reportB04.Table19.Sum(s => s.EndAmount) == 0)
            {
                reportB04.Table19 = new List<ReportB04BCTCDetail01Entity>();
            }

            parms[9] = 20;
            reportB04.Table20 = Db.ReadList(storeProcedureName, true, MakeReportB04BCTCDetail01, parms);
            if (reportB04.Table20.Sum(s => s.BeginAmount) == 0 && reportB04.Table20.Sum(s => s.EndAmount) == 0)
            {
                reportB04.Table20 = new List<ReportB04BCTCDetail01Entity>();
            }

            parms[9] = 21;
            reportB04.Table21 = Db.ReadList(storeProcedureName, true, MakeReportB04BCTCDetail01, parms);
            if (reportB04.Table21.Sum(s => s.BeginAmount) == 0 && reportB04.Table21.Sum(s => s.EndAmount) == 0)
            {
                reportB04.Table21 = new List<ReportB04BCTCDetail01Entity>();
            }

            parms[9] = 22;
            reportB04.Table22 = Db.ReadList(storeProcedureName, true, MakeReportB04BCTCDetail01, parms);
            if (reportB04.Table22.Sum(s => s.BeginAmount) == 0 && reportB04.Table22.Sum(s => s.EndAmount) == 0)
            {
                reportB04.Table22 = new List<ReportB04BCTCDetail01Entity>();
            }

            parms[9] = 23;
            reportB04.Table23 = Db.ReadList(storeProcedureName, true, MakeReportB04BCTCDetail01, parms);
            if (reportB04.Table23.Sum(s => s.BeginAmount) == 0 && reportB04.Table23.Sum(s => s.EndAmount) == 0)
            {
                reportB04.Table23 = new List<ReportB04BCTCDetail01Entity>();
            }

            reportB04.Table24 = new List<ReportB04BCTCDetail01Entity>()
            {
                new ReportB04BCTCDetail01Entity()
            };

            reportB04s.Add(reportB04);
            return reportB04s;
        }

        public IList<BusinessEntities.Report.LedgerAccounting.ReportS104HEntity> LedgerAccountingS104H(string storeProdure, string fromDate, string toDate, string budgetSourceCodes, string currencyCode, int amountType)
        {
            object[] parms = {
                "@FromDate", Convert.ToDateTime(fromDate),
                "@ToDate", Convert.ToDateTime(toDate),
                "@CurrencyCode", currencyCode,
                "@AmountType", amountType,
                "@BudgetSourceCodes", string.IsNullOrEmpty(budgetSourceCodes) ? null : budgetSourceCodes
            };
            return Db.ReadList(storeProdure, true, MakeLedgerAccountingS104H, parms);
        }

        #endregion

        #region 9 - Voucher

        /// <summary>
        /// Phiếu thu(Mẫu số 1)
        /// </summary>
        public IList<C30BBEntity> GetReportC30BB(int year, int refTypeId)
        {
            const string sql = @"uspReport_C30BB";
            object[] parms = {
                "@Year", year,
                "@RefTypeId", refTypeId
            };
            return Db.ReadList(sql, true, MakeC30BB, parms);
        }

        /// <summary>
        /// Phiếu nhập kho
        /// </summary>
        public IList<C11HEntity> GetReportC11H(string storeProdure, string refIdList)
        {
            string sql = storeProdure;
            IList<C11HEntity> list = new List<C11HEntity>();
            foreach (var refID in refIdList.Split(';'))
            {
                object[] parms = { "@RefID", refID };
                C11HEntity obj = Db.Read(sql, true, MakeC11HD, parms);

                object[] parmsDetails = { "@RefID", refID };
                IList<InventoryItemReportEntity> listDetail = Db.ReadList("uspGet_Report_C11HD_InventoryItemDetailList", true, MakeInventoryItemReport, parmsDetails);
                obj.InventoryItems = listDetail;
                list.Add(obj);
            }
            return list;
        }

        /// <summary>
        /// Chứng từ kế toán
        /// </summary>
        public IList<AccountingVoucherEntity> GetAccountingVoucher(string storeProdure, string refIdList, int reftypeId)
        {
            IList<AccountingVoucherEntity> list = new List<AccountingVoucherEntity>();
            int stt = 1;
            foreach (var refID in refIdList.Split(';'))
            {

                object[] parms = { "@RefID", refID, "@RefType", reftypeId };
                var listobj = Db.ReadList(storeProdure, true, MakeAccountingVoucher, parms);
                foreach (var accountingVoucherEntity in listobj)
                {
                    accountingVoucherEntity.OrderNumber = stt;
                    stt = stt + 1;
                    list.Add(accountingVoucherEntity);
                }

            }
            return list;
        }

        #endregion

        #region 12 - Settlement Report

        /// <summary>
        /// Báo cáo quyết toán kinh phí hoạt động Phần II
        /// </summary>
        public List<ReportB01CIIEntity> GetReportB01CIIs(string storeProcedureName, DateTime fromDate, DateTime toDate, int year)
        {
            object[] parms = {
                "@FromDate", fromDate,
                "@ToDate", toDate,
                "@Year", year
            };

            return Db.ReadList(storeProcedureName, true, MakeB01CII, parms);
        }

        /// <summary>
        /// Báo cáo quyết toán kinh phí hoạt động Phần II
        /// </summary>
        public List<ReportB01CII01Entity> GetReportB01CII01s(string storeProcedureName, DateTime fromDate, DateTime toDate, int year)
        {
            List<ReportB01CII01Entity> reportB01CIIs = new List<ReportB01CII01Entity>();
            ReportB01CII01Entity reportB01CII = new ReportB01CII01Entity();
            object[] parms = {
                "@FromDate", fromDate,
                "@ToDate", toDate,
                "@Year", year,
                "Option", 1
            };
            reportB01CII.ExchangeRate = Db.ReadList(storeProcedureName, true, MakeReportB01CII01ExchangeRate, parms);

            parms[7] = 2;
            reportB01CII.SourceAutonomy = Db.ReadList(storeProcedureName, true, MakeB01CII01, parms);

            parms[7] = 3;
            reportB01CII.UncontrolledSource = Db.ReadList(storeProcedureName, true, MakeB01CII01, parms);

            reportB01CIIs.Add(reportB01CII);

            return reportB01CIIs;
        }

        /// <summary>
        /// Báo cáo quyết toán kinh phí hoạt động phần I
        /// </summary>
        public List<ReportB01CIEntity> GetReportB01CIs(string storeProcedureName, DateTime fromDate, DateTime toDate)
        {
            object[] parms = {
                "@FromDate", fromDate,
                "@ToDate", toDate,
            };
            return Db.ReadList(storeProcedureName, true, MakeB01CI, parms);
        }

        /// <summary>
        /// Sổ theo dõi kinh phí NSNN cấp bằng lệnh chi tiền
        /// </summary>
        public List<ReportS104HEntity> GetReportS104Hs(string storeProcedureName, DateTime fromDate, DateTime toDate, string currencyCode, int amountType)
        {
            object[] parms = {
                "@FromDate", fromDate,
                "@ToDate", toDate,
                "@CurrencyCode", currencyCode,
                "@AmountType", amountType
            };
            return Db.ReadList(storeProcedureName, true, MakeS104H, parms);
        }

        #endregion

        #region Make Reports

        private static readonly Func<IDataReader, A02LDTLEntity> Make02Ldt = reader => new A02LDTLEntity
        {
            OrderNumber = reader["OrderNumber"].AsInt(),
            EmployeeName = reader["EmployeeName"].AsString(),
            JobCandidateName = reader["JobCandidateName"].AsString(),
            NumberSHP = reader["NumberSHP"].AsDecimal(),
            SHP = reader["SHP"].AsDecimal(),
            PCVS = reader["PCVS"].AsDecimal(),
            PCKiemNhiem = reader["PCKiemNhiem"].AsDecimal(),
            TroCapCT = reader["TroCapCT"].AsDecimal(),
            TongCong = reader["TongCong"].AsDecimal(),
            QuiDoi = reader["QuiDoi"].AsDecimal(),
            ExchangeRate = reader["ExchangeRate"].AsDecimal(),
            CurrencyCode = reader["CurrencyCode"].AsString(),
            CalcDate = reader["CalcDate"].AsDateTime(),
            BaseOfSalary = reader["BaseOfSalary"].AsDecimal(),
            WorkDay = reader["WorkDay"].AsInt(),
        };

        private static readonly Func<IDataReader, AccountingVoucherEntity> MakeAccountingVoucher = reader => new AccountingVoucherEntity
        {
            CurrencyCode = reader["CurrencyCode"].AsString(),
            PostedDate = reader["PostedDate"].AsDateTimeForNull(),
            RefDate = reader["RefDate"].AsDateTimeForNull(),
            RefNo = reader["RefNo"].AsString(),
            Description = reader["Description"].AsString(),
            AccountNumber = reader["AccountNumber"].AsString(),
            AmountOC = reader["AmountOC"].AsDecimal(),
            OrderNumber = reader["OrderNumber"].AsInt(),
            CorrespondingAccountNumber = reader["CorrespondingAccountNumber"].AsString(),
        };

        private static readonly Func<IDataReader, C22HEntity> MakeC22HD = reader => new C22HEntity
        {
            RefId = reader["RefID"].AsLong(),
            RefNo = reader["RefNo"].AsString(),
            RefDate = reader["RefDate"].AsDateTime(),
            PostedDate = reader["PostedDate"].AsDateTime(),
            AccountingObjectName = reader["AccountingObjectName"].AsString(),
            AccountingObjectAddress = reader["AccountingObjectAddress"].AsString(),
            JournalMemo = reader["JournalMemo"].AsString(),
            TotalAmount = reader["TotalAmount"].AsDecimal(),
            DocumentInclude = reader["DocumentInclude"].AsString(),
            CreditAccount = Db.RemoveDuplicateWords(reader["CreditAccount"].AsString()),
            DebitAccount = Db.RemoveDuplicateWords(reader["DebitAccount"].AsString()),
            CurrencyCode = reader["CurrencyCode"].AsString(),
            ExchangeRate = reader["ExchangeRate"].AsFloat(),
            TotalAmountExchange = reader["TotalAmountExchange"].AsDecimal(),
            Trader = reader["Trader"].AsString(),
        };

        private static readonly Func<IDataReader, C30BBEntity> MakeC30BB = reader => new C30BBEntity
        {
            RefNo = reader["RefNo"].AsString(),
            RefId = reader["RefID"].AsInt(),
            PostedDate = reader["PostedDate"].AsDateTime().ToShortDateString(),
            RefDate = reader["RefDate"].AsDateTime().ToShortDateString(),
            AccountNumber = reader["AccountNumber"].AsString() == "" ? "" : Db.RemoveDuplicateWords(reader["AccountNumber"].AsString()),
            Address = reader["Address"].AsString(),
            CorrespondingAccountNumber = reader["CorrespondingAccountNumber"].AsString() == "" ? "" : Db.RemoveDuplicateWords(reader["CorrespondingAccountNumber"].AsString()),
            DocumentInclude = reader["DocumentInclude"].AsString(),
            ExchangeRate = reader["ExchangeRate"].AsDecimal(),
            IsSelect = reader["IsSelect"].AsBool(),
            JournalMemo = reader["JournalMemo"].AsString(),
            TotalAmount = reader["TotalAmount"].AsDecimal(),
            TotalAmountExchange = reader["TotalAmountExchange"].AsDecimal(),
            Trader = reader["Trader"].AsString(),
            CurrencyCode = reader["CurrencyCode"].AsString(),
            ContactName = reader["ContactName"].ToString()
        };

        private static readonly Func<IDataReader, C30BB501Entity> MakeReceiveVoucher = reader => new C30BB501Entity
        {
            RefNo = reader["RefNo"].AsString(),
            RefId = reader["RefID"].AsLong(),
            PostedDate = reader["PostedDate"].AsDateTime().ToShortDateString(),
            Address = reader["AccountingObjectAddress"].AsString(),
            ExchangeRate = reader["ExchangeRate"].AsDecimal(),
            JournalMemo = reader["JournalMemo"].AsString(),
            TotalAmount = reader["TotalAmount"].AsDecimal(),
            TotalAmountExchange = reader["TotalAmountExchange"].AsDecimal(),
            CurrencyCode = reader["CurrencyCode"].AsString(),
            ContactName = reader["AccountingObjectName"].ToString(),
            Trader = reader["AccountingObjectName"].ToString(),
            AccountNumber = reader["AccountNumber"].ToString(),
            CorrespondingAccountNumber = reader["CorrespondingAccountNumber"].ToString()
        };

        private static readonly Func<IDataReader, C11HEntity> MakeC11HD = reader => new C11HEntity
        {
            RefId = reader["RefID"].AsLong(),
            RefNo = reader["RefNo"].AsString(),
            RefDate = reader["RefDate"].AsDateTime(),
            PostedDate = reader["PostedDate"].AsDateTime(),
            AccountingObjectName = reader["AccountingObjectName"].AsString(),
            AccountingObjectAddress = reader["AccountingObjectAddress"].AsString(),
            JournalMemo = reader["JournalMemo"].AsString(),
            TotalAmount = reader["TotalAmount"].AsDecimal(),
            CurrencyCode = reader["CurrencyCode"].AsString(),
            StockName = reader["StockName"].AsString(),
            Trader = reader["Trader"].AsString()
        };

        private static readonly Func<IDataReader, InventoryItemReportEntity> MakeInventoryItemReport = reader => new InventoryItemReportEntity
        {
            OrderNumber = reader["OrderNumber"].AsInt(),
            InventoryItemName = reader["InventoryItemName"].AsString(),
            Quantity = reader["Quantity"].AsInt(),
            Price = reader["Price"].AsDecimal(),
            AmountOc = reader["AmountOc"].AsDecimal(),
            Unit = reader["Unit"].AsString()

        };

        private static readonly Func<IDataReader, ReportActivityB02Entity> MakeActivityB02 = reader =>
        {
            var resoult = new ReportActivityB02Entity();
            resoult.OrderNumber = reader["OrderNumber"].AsString();
            resoult.ReportItemCode = reader["ReportItemCode"].AsString();
            resoult.ReportItemName = reader["ReportItemName"].AsString();
            resoult.ReportItemAlias = reader["ReportItemAlias"].AsString();
            resoult.ThisYear = reader["ThisYear"].AsDecimal();
            resoult.LastYear = reader["LastYear"].AsDecimal();
            resoult.IsBold = reader["IsBold"].AsBool();
            resoult.SortOrder = reader["SortOrder"].AsInt();
            return resoult;
        };

        #endregion

        #region Make Report Ledger Accounting

        private static readonly Func<IDataReader, S03AHEntity> MakeS03AH = reader => new S03AHEntity
        {
            PostedDate = reader["PostedDate"].AsDateTimeForNull(),
            RefDate = reader["RefDate"].AsDateTimeForNull(),
            RefNo = reader["RefNo"].AsString(),
            Description = reader["Description"].AsString(),
            AccountNumber = reader["AccountNumber"].AsString(),
            DebitAmount = reader["DebitAmount"].AsDecimal(),
            CreditAmount = reader["CreditAmount"].AsDecimal(),
            FontStyle = reader["FontStyle"].AsString(),
            RefId = reader["RefID"].AsInt(),
            RefTypeId = reader["RefTypeID"].AsInt()
        };

        private static readonly Func<IDataReader, S33HEntity> MakeS33H = reader => new S33HEntity
        {
            PostedDate = reader["PostedDate"].AsDateTimeForNull(),
            RefDate = reader["RefDate"].AsDateTimeForNull(),
            RefNo = reader["RefNo"].AsString(),
            Description = reader["Description"].AsString(),
            CorrespondingAccountNumber = reader["CorrespondingAccountNumber"].AsString(),
            CreditAmountBalance = reader["CreditAmountBalance"].AsDecimal(),
            DebitAmountBalance = reader["DebitAmountBalance"].AsDecimal(),
            JournalMemo = reader["JournalMemo"].AsString(),
            FontStyle = reader["FontStyle"].AsString(),
            CreditAmountOriginal = reader["CreditAmountOriginal"].AsDecimal(),
            DebitAmountOriginal = reader["DebitAmountOriginal"].AsDecimal(),
            RefId = reader["RefID"].AsInt(),
            RefTypeId = reader["RefTypeID"].AsInt(),
        };

        private static readonly Func<IDataReader, S05HEntity> MakeS05H = reader => new S05HEntity
        {
            AccountCode = reader["AccountNumber"].AsString(),
            AccountName = reader["AccountName"].AsString(),
            OpeningCredit = reader["OpeningCredit"].AsDecimal(),
            OpeningDebit = reader["OpeningDebit"].AsDecimal(),
            AdjustmentDebitBeginningYear = reader["AdjustmentDebitBeginningYear"].AsDecimal(),
            AdjustmentCreditBeginningYear = reader["AdjustmentCreditBeginningYear"].AsDecimal(),
            MovementCredit = reader["MovementCredit"].AsDecimal(),
            MovementDebit = reader["MovementDebit"].AsDecimal(),
            MovementAccumCredit = reader["MovementAccumCredit"].AsDecimal(),
            MovementAccumDebit = reader["MovementAccumDebit"].AsDecimal(),
            ClosingCredit = reader["ClosingCredit"].AsDecimal(),
            ClosingDebit = reader["ClosingDebit"].AsDecimal(),
            IsDetail = reader["IsDetail"].AsBool(),
            Grade = reader["Grade"].AsInt()
        };

        private static readonly Func<IDataReader, AdvancePaymentEntity> MakeAdvancePayment = reader => new AdvancePaymentEntity
        {
            Type = reader["Type"].AsInt(),
            EmployeeName = reader["EmployeeName"].AsString(),
            EmployeeCode = reader["EmployeeCode"].AsString(),
            EmployeeID = reader["EmployeeID"].AsString(),
            OpeningAmountOC = reader["OpeningAmountOC"].AsDecimal(),
            OpeningAmountExchange = reader["OpeningAmountExchange"].AsDecimal(),
            AdvanceAmountOC = reader["AdvanceAmountOC"].AsDecimal(),
            AdvanceAmountExchange = reader["AdvanceAmountExchange"].AsDecimal(),
            AdvancePaymentAmountOC = reader["AdvancePaymentAmountOC"].AsDecimal(),
            AdvancePaymentAmountExchange = reader["AdvancePaymentAmountExchange"].AsDecimal(),
            RemainingAmountOC = reader["RemainingAmountOC"].AsDecimal(),
            RemainingAmountExchange = reader["RemainingAmountExchange"].AsDecimal(),

        };

        private static readonly Func<IDataReader, S03BHEntity> MakeS03BH = reader => new S03BHEntity
        {
            RefNo = reader["RefNo"].AsString(),
            CorrespondingAccountNumber = reader["CorrespondingAccountNumber"].AsString(),
            PostedDate = reader["PostedDate"].AsDateTime().ToShortDateString(),
            Description = reader["Description"].AsString(),
            BudgetItemCode = reader["BudgetItemCode"].AsString(),
            AccountNumber = reader["BudgetItemCode"].AsString(),
            AccumulatedAccountNumbber = reader["AccumulatedAccountNumbber"].AsDecimal(),
            AccumulatedCorrAccountNumbber = reader["AccumulatedCorrAccountNumbber"].AsDecimal(),
            AmountAccountNumbber = reader["AmountAccountNumbber"].AsDecimal(),
            AmountCorrAccountNumbber = reader["AmountCorrAccountNumbber"].AsDecimal(),
            AmountOgrAccountNumbber = reader["AmountOgrAccountNumbber"].AsDecimal(),
            AmountOgrCorrAccountNumbber = reader["AmountOgrCorrAccountNumbber"].AsDecimal(),
            RefId = reader["RefID"].AsInt(),
            RefTypeId = reader["RefTypeID"].AsInt()
        };


        #endregion

        #region Make Report Stock

        private static readonly Func<IDataReader, B14QEntity> MakeB14Q = reader => new B14QEntity
        {
            InventoryItemCode = reader["InventoryItemCode"].AsString(),
            InventoryItemName = reader["InventoryItemName"].AsString(),
            Unit = reader["Unit"].AsString(),
            QuantityOpening = reader["QuantityOpening"].AsInt(),
            QuantityInwardStock = reader["QuantityInwardStock"].AsInt(),
            QuantityOutwardStock = reader["QuantityOutwardStock"].AsInt(),
            QuantityClosing = reader["QuantityClosing"].AsInt(),

            OrgPriceClosing = reader["OrgPriceClosing"].AsDecimal(),
            OrgPriceInwardStock = reader["OrgPriceInwardStock"].AsDecimal(),
            OrgPriceOpening = reader["OrgPriceOpening"].AsDecimal(),
            OrgPriceOutwardStock = reader["OrgPriceOutwardStock"].AsDecimal(),
            CancelQuantity = reader["CancelQuantity"].AsInt(),
            TotalQuantity = reader["TotalQuantity"].AsInt(),
            FreeQuantity = reader["FreeQuantity"].AsInt()
        };

        #endregion

        #region Make Financial Report

        private static readonly Func<IDataReader, ReportF03BCTDetailEntity> MakeF03BCT = reader =>
        {
            var reportF03BCT = new ReportF03BCTDetailEntity();
            reportF03BCT.OrderNumber = reader["OrderNumber"].AsIntForNull();
            reportF03BCT.BudgetItemCode = reader["BudgetItemCode"].AsString();
            reportF03BCT.BudgetItemType = reader["BudgetItemType"].AsIntForNull();
            reportF03BCT.Content = reader["Content"].AsString();
            reportF03BCT.FontStyle = reader["FontStyle"].AsString();
            reportF03BCT.ParentId = reader["ParentId"].AsIntForNull();
            reportF03BCT.Amount1 = reader["Amount1"].AsDecimal();
            reportF03BCT.Amount2 = reader["Amount2"].AsDecimal();
            reportF03BCT.Amount3 = reader["Amount3"].AsDecimal();
            reportF03BCT.Amount4 = reader["Amount4"].AsDecimal();
            reportF03BCT.Amount5 = reader["Amount5"].AsDecimal();
            reportF03BCT.Amount6 = reader["Amount6"].AsDecimal();
            reportF03BCT.Amount7 = reader["Amount7"].AsDecimal();
            reportF03BCT.Amount8 = reader["Amount8"].AsDecimal();
            reportF03BCT.Amount9 = reader["Amount9"].AsDecimal();
            reportF03BCT.Amount10 = reader["Amount10"].AsDecimal();
            return reportF03BCT;
        };

        private static readonly Func<IDataReader, B01HEntity> MakeB01H = reader => new B01HEntity
        {
            AccountCode = reader["AccountNumber"].AsString(),
            AccountName = reader["AccountName"].AsString(),
            OpeningCredit = reader["OpeningCredit"].AsDecimal(),
            OpeningDebit = reader["OpeningDebit"].AsDecimal(),
            MovementCredit = reader["MovementCredit"].AsDecimal(),
            MovementDebit = reader["MovementDebit"].AsDecimal(),
            MovementAccumCredit = reader["MovementAccumCredit"].AsDecimal(),

            MovementAccumDebit = reader["MovementAccumDebit"].AsDecimal(),
            ClosingCredit = reader["ClosingCredit"].AsDecimal(),
            ClosingDebit = reader["ClosingDebit"].AsDecimal(),
            IsDetail = reader["IsDetail"].AsBool(),
            Grade = reader["Grade"].AsInt()
        };

        private static readonly Func<IDataReader, ReportB01BCTCEntity> MakeB01BCTC = reader => new ReportB01BCTCEntity
        {
            Part = reader["Part"].AsInt(),
            Index = reader["ItemIndex"].AsString(),
            ItemCode = reader["ItemCode"].AsString(),
            ItemName = reader["ItemName"].AsString(),
            BeginAmount = reader["BeginAmount"].AsDecimal(),
            EndAmount = reader["EndAmount"].AsDecimal(),
            IsBold = reader["IsBold"].AsBool(),
            IsItalic = reader["IsItalic"].AsBool(),
            SortOrder = reader["SortOrder"].AsInt()
        };

        private static readonly Func<IDataReader, ReportB03bBCTCEntity> MakeB03bBCTC = reader => new ReportB03bBCTCEntity
        {
            Index = reader["ItemIndex"].AsString(),
            ItemCode = reader["ItemCode"].AsString(),
            ItemName = reader["ItemName"].AsString(),
            ThisYearAmount = reader["ThisYearAmount"].AsDecimal(),
            LastYearAmount = reader["LastYearAmount"].AsDecimal(),
            IsBold = reader["IsBold"].AsBool(),
            IsItalic = reader["IsItalic"].AsBool(),
            SortOrder = reader["SortOrder"].AsInt()
        };

        private static readonly Func<IDataReader, B01BCQTEntity> MakeFinacialB01BCQT = reader => new B01BCQTEntity
        {
            OrderNumber = reader["OrderNumber"].AsInt(),
            NumberCode = reader["NumberCode"].AsString(),
            TargetName = reader["TargetName"].AsString(),
            Code = reader["Code"].AsString(),
            Amount01 = reader["Amount01"].AsDecimal(),
            Amount02 = reader["Amount02"].AsDecimal(),
            Amount03 = reader["Amount03"].AsDecimal(),
            Amount04 = reader["Amount04"].AsDecimal(),
            Amount05 = reader["Amount05"].AsDecimal(),
            Amount06 = reader["Amount06"].AsDecimal(),
            Amount07 = reader["Amount07"].AsDecimal(),
            FontStyle = reader["FontStyle"].AsString(),
            Grade = reader["Grade"].AsInt()
        };

        private static readonly Func<IDataReader, B03BNGEntity> MakeB03BNG = reader => new B03BNGEntity
        {
            AccountingObjectCode = reader["AccountingObjectCode"].AsString(),
            AccountingObjectName = reader["AccountingObjectName"].AsString(),
            AccountingObjectGroup = reader["AccountingObjectGroup"].AsString(),
            OpeningAmount = reader["OpeningAmount"].AsDecimal(),
            ReceiveAdvance = reader["ReceiveAdvance"].AsDecimal(),
            AdvancePayment = reader["AdvancePayment"].AsDecimal(),
            ClosingAmount = reader["ClosingAmount"].AsDecimal(),
            Type = reader["Type"].AsShort()
        };

        private static readonly Func<IDataReader, F03BNGEntity> MakeF03BNG = reader => new F03BNGEntity
        {
            AccumulatedAutonomyBudgetAmount = reader["AccumulatedAutonomyBudgetAmount"].AsDecimal(),
            AccumulatedAutonomyOtherAmount = reader["AccumulatedAutonomyOtherAmount"].AsDecimal(),
            AccumulatedNonAutonomyBudgetAmount = reader["AccumulatedNonAutonomyBudgetAmount"].AsDecimal(),
            AccumulatedNonAutonomyOtherAmount = reader["AccumulatedNonAutonomyOtherAmount"].AsDecimal(),
            AccumulatedProjectBudgetAmount = reader["AccumulatedProjectBudgetAmount"].AsDecimal(),
            AccumulatedRegulateOtherAmount = reader["AccumulatedRegulateOtherAmount"].AsDecimal(),
            AccumulatedDiplomaticBudgetAmount = reader["AccumulatedDiplomaticBudgetAmount"].AsDecimal(),
            AccumulatedTotalAmount = reader["AccumulatedTotalAmount"].AsDecimal(),
            BudgetItemCode = reader["BudgetItemCode"].AsString(),
            BudgetItemId = reader["BudgetItemId"].AsString(),
            BudgetItemType = reader["BudgetItemType"].AsByte(),
            BudgetSubItemCode = reader["BudgetSubItemCode"].AsString(),
            Content = reader["Content"].AsString(),
            FontStyle = reader["FontStyle"].AsString(),
            Grade = reader["Grade"].AsInt(),
            ParentId = reader["ParentId"].AsString(),
            ThisMonthAutonomyBudgetAmount = reader["ThisMonthAutonomyBudgetAmount"].AsDecimal(),
            ThisMonthAutonomyOtherAmount = reader["ThisMonthAutonomyOtherAmount"].AsDecimal(),
            ThisMonthNonAutonomyBudgetAmount = reader["ThisMonthNonAutonomyBudgetAmount"].AsDecimal(),
            ThisMonthNonAutonomyOtherAmount = reader["ThisMonthNonAutonomyOtherAmount"].AsDecimal(),
            ThisMonthProjectBudgetAmount = reader["ThisMonthProjectBudgetAmount"].AsDecimal(),
            ThisMonthRegulateOtherAmount = reader["ThisMonthRegulateOtherAmount"].AsDecimal(),
            ThisMonthDiplomaticBudgetAmount = reader["ThisMonthDiplomaticBudgetAmount"].AsDecimal(),
            ThisMonthTotalAmount = reader["ThisMonthTotalAmount"].AsDecimal()
        };

        private static readonly Func<IDataReader, F331BNGEntity> MakeF331BNG = reader => new F331BNGEntity
        {
            AccumulatedAmount = reader["AccumulatedAmount"].AsDecimal(),
            BudgetItemCode = reader["BudgetItemCode"].AsString(),
            BudgetItemId = reader["BudgetItemId"].AsString(),
            BudgetItemType = reader["BudgetItemType"].AsByte(),
            BudgetSubItemCode = reader["BudgetSubItemCode"].AsString(),
            Content = reader["Content"].AsString(),
            FontStyle = reader["FontStyle"].AsString(),
            Grade = reader["Grade"].AsInt(),
            ParentId = reader["ParentId"].AsString(),
            ThisMonthAmount = reader["ThisMonthAmount"].AsDecimal(),
        };

        private static readonly Func<IDataReader, B09BNGEntity> MakeB09BNG = reader => new B09BNGEntity
        {
            AccumulatedAmount = reader["AccumulatedAmount"].AsDecimal(),
            ItemId = reader["ItemId"].AsString(),
            ItemName = reader["ItemName"].AsString(),
            FontStyle = reader["FontStyle"].AsString(),
            Grade = reader["Grade"].AsInt(),
            ParentId = reader["ParentId"].AsString(),
            Amount = reader["Amount"].AsDecimal(),
            QuarterB09 = reader["QuarterB09"].AsInt()
        };

        #endregion

        #region Make FixedAsset

        private static readonly Func<IDataReader, FixedAssetB03H30KEntity> MakeFixedAssetB03H30K = reader => new FixedAssetB03H30KEntity
        {
            FixedAssetId = 0,
            FixedAssetCategoryCode = "",
            FixedAssetName = reader["FixedAssetName"].AsString(),
            FixedAssetCode = reader["FixedAssetCode"].AsString(),
            FixedAssetType = reader["FixedAssetType"].AsString(),
            Grade = reader["Grade"].AsInt(),
            QuantityOpening = reader["QuantityOpening"].AsInt(),
            AreaOpening = reader["AreaOpening"].AsDecimal(),
            OrgPriceOpening = reader["OrgPriceOpening"].AsDecimal(),
            OrgPriceOpeningDifference = reader["OrgPriceOpeningDifference"].AsDecimal(),
            QuantityIncrement = reader["QuantityIncrement"].AsInt(),
            AreaIncrement = reader["AreaIncrement"].AsDecimal(),
            OrgPriceIncrement = reader["OrgPriceIncrement"].AsDecimal(),
            OrgPriceIncrementDifference = reader["OrgPriceIncrementDifference"].AsDecimal(),
            QuantityDecrement = reader["QuantityDecrement"].AsInt(),
            AreaDecrement = reader["AreaDecrement"].AsDecimal(),
            OrgPriceDecrement = reader["OrgPriceDecrement"].AsDecimal(),
            OrgPriceDecrementDifference = reader["OrgPriceDecrementDifference"].AsDecimal(),
            QuantityClosing = reader["QuantityClosing"].AsInt(),
            AreaClosing = reader["AreaClosing"].AsDecimal(),
            OrgPriceClosing = reader["OrgPriceClosing"].AsDecimal(),
            OrgPriceClosingDifference = reader["OrgPriceClosingDifference"].AsDecimal()
        };

        private static readonly Func<IDataReader, FixedAsset30KPart2Entity> MakeFixedAsset30KPart2 = reader => new FixedAsset30KPart2Entity
        {
            FixedAssetId = reader["FixedAssetID"].AsInt(),
            FixedAssetCategoryCode = reader["FixedAssetCategoryCode"].AsString(),
            FixedAssetName = reader["FixedAssetName"].AsString(),
            FixedAssetCode = reader["FixedAssetCode"].AsString(),
            ProductionYear = reader["ProductionYear"].AsInt(),
            CountryProduction = reader["CountryProduction"].AsString(),
            DateOfUsing = reader["DateOfUsing"].AsDateTime(),
            OrgPrice = reader["OrgPrice"].AsDecimal(),
            OrgPriceDifference = reader["OrgPriceDifference"].AsDecimal(),
            RemainingAmount = reader["RemainingAmount"].AsDecimal(),
            StateManagement = reader["StateManagement"].AsString(),
            Bussiness = reader["Bussiness"].AsString(),
            Description = reader["Description"].AsString()
        };

        private static readonly Func<IDataReader, FixedAssetCardEntity> MakeFixedAssetCard = reader => new FixedAssetCardEntity
        {
            FixedAssetId = reader["FixedAssetID"].AsInt(),
            OrderNumber = reader["OrderNumber"].AsString(),
            FixedAssetName = reader["FixedAssetName"].AsString(),
            FixedAssetCode = reader["FixedAssetCode"].AsString(),
            ProductionYear = reader["ProductionYear"].AsInt(),
            MadeIn = reader["MadeIn"].AsString(),
            UsedDate = reader["UsedDate"].AsDateTime(),
            PurchasedDate = reader["PurchasedDate"].AsDateTime(),
            OrgPrice = reader["OrgPrice"].AsDecimal(),
            OrgPriceUsd = reader["OrgPriceUSD"].AsDecimal(),
            TotalOrgPriceUsd = reader["TotalOrgPriceUSD"].AsDecimal(),
            DepartmentName = reader["DepartmentName"].AsString(),
            EmployeeName = reader["EmployeeName"].AsString()
        };

        private static readonly Func<IDataReader, FixedAssetS26HEntity> MakeFixedAssetS26H = reader =>
        {
            var fixedAssetS26H = new FixedAssetS26HEntity();
            fixedAssetS26H.OrderNumber = reader["OrderNumber"].AsInt();
            fixedAssetS26H.FixedAssetCode = reader["FixedAssetCode"].AsString();
            fixedAssetS26H.FixedAssetName = reader["FixedAssetName"].AsString();
            fixedAssetS26H.DepartmentCode = reader["DepartmentCode"].AsString();
            fixedAssetS26H.DepartmentName = reader["DepartmentName"].AsString();
            fixedAssetS26H.FixedAssetCategoryCode = reader["FixedAssetCategoryCode"].AsString();
            fixedAssetS26H.FixedAssetCategoryName = reader["FixedAssetCategoryName"].AsString();
            fixedAssetS26H.PostDate = reader["PostDate"].AsDateTimeForNull();
            fixedAssetS26H.RefNo = reader["RefNo"].AsString();
            fixedAssetS26H.RefDate = reader["RefDate"].AsDateTimeForNull();
            fixedAssetS26H.Unit = reader["Unit"].AsString();
            fixedAssetS26H.JournalMemo = reader["JournalMemo"].AsString();
            fixedAssetS26H.FixedAssetIncrement_Quantity = reader["FixedAssetIncrement_Quantity"].AsDecimal();
            fixedAssetS26H.FixedAssetIncrement_UnitPrice = reader["FixedAssetIncrement_UnitPrice"].AsDecimal();
            fixedAssetS26H.FixedAssetIncrement_Amount = reader["FixedAssetIncrement_Amount"].AsDecimal();
            fixedAssetS26H.FixedAssetDecrement_Quantity = reader["FixedAssetDecrement_Quantity"].AsDecimal();
            fixedAssetS26H.FixedAssetDecrement_UnitPrice = reader["FixedAssetDecrement_UnitPrice"].AsDecimal();
            fixedAssetS26H.FixedAssetDecrement_Amount = reader["FixedAssetDecrement_Amount"].AsDecimal();
            return fixedAssetS26H;
        };

        private static readonly Func<IDataReader, FixedAssetS24HEntity> MakeFixedAssetS24H = reader =>
        {
            var fixedAsset = new FixedAssetS24HEntity();
            fixedAsset.FixedAssetID = reader["FixedAssetID"].AsInt();
            fixedAsset.FixedAssetCode = reader["FixedAssetCode"].AsString();
            fixedAsset.FixedAssetName = reader["FixedAssetName"].AsString();
            fixedAsset.FixedAssetCategoryID = reader["FixedAssetCategoryID"].AsInt();
            fixedAsset.FixedAssetCategoryCode = reader["FixedAssetCategoryCode"].AsString();
            fixedAsset.FixedAssetCategoryName = reader["FixedAssetCategoryName"].AsString();
            fixedAsset.MadeIn = reader["MadeIn"].AsString();
            fixedAsset.UsedDate = reader["UsedDate"].AsDateTimeForNull();

            fixedAsset.IncrementRefID = reader["IncrementRefID"].AsLong();
            fixedAsset.IncrementRefNo = reader["IncrementRefNo"].AsString();
            fixedAsset.IncrementRefDate = reader["IncrementRefDate"].AsDateTimeForNull();
            fixedAsset.IncrementPostedDate = reader["IncrementPostedDate"].AsDateTimeForNull();
            fixedAsset.IncrementAmount = reader["IncrementAmount"].AsDecimal();

            fixedAsset.DepreciationRate = reader["DepreciationRate"].AsDecimal();
            fixedAsset.AnnualDepreciationAmount = reader["AnnualDepreciationAmount"].AsDecimal();
            fixedAsset.ArmortizationAmount = reader["ArmortizationAmount"].AsDecimal();
            fixedAsset.ArmortizationAccumulateAmount = reader["ArmortizationAccumulateAmount"].AsDecimal();

            fixedAsset.DecrementRefID = reader["DecrementRefID"].AsLong();
            fixedAsset.DecrementRefNo = reader["DecrementRefNo"].AsString();
            fixedAsset.DecrementRefDate = reader["DecrementRefDate"].AsDateTimeForNull();
            fixedAsset.DecrementPostedDate = reader["DecrementPostedDate"].AsDateTimeForNull();
            fixedAsset.DecrementDescription = reader["DecrementDescription"].AsString();
            fixedAsset.DecrementAmount = reader["DecrementAmount"].AsDecimal();

            fixedAsset.SortOrder = reader["SortOrder"].AsInt();
            return fixedAsset;
        };

        private static readonly Func<IDataReader, FixedAssetB03HEntity> MakeFixedAssetB03H = reader => new FixedAssetB03HEntity
        {
            FixedAssetCategoryId = reader["FixedAssetCategoryID"].AsInt(),
            FixedAssetCategoryCode = reader["OrderNumber"].AsString(),
            FixedAssetCategoryName = reader["FixedAssetCategoryName"].AsString(),
            ParentId = reader["ParentID"].AsInt(),
            Unit = reader["Unit"].AsString(),
            QuantityOpening = reader["QuantityOpening"].AsInt(),
            QuantityIncrement = reader["QuantityIncrement"].AsInt(),
            QuantityDecrement = reader["QuantityDecrement"].AsInt(),
            QuantityClosing = reader["QuantityClosing"].AsInt(),
            OrgPriceOpening = reader["OrgPriceOpening"].AsDecimal(),
            OrgPriceOpeningUSD = reader["OrgPriceOpeningUSD"].AsDecimal(),
            OrgPriceOpeningCurrencyUSD = reader["OrgPriceOpeningCurrencyUSD"].AsDecimal(),
            TotalOrgPriceOpeningUSD = reader["TotalOrgPriceOpeningUSD"].AsDecimal(),
            OrgPriceIncrement = reader["OrgPriceIncrement"].AsDecimal(),
            OrgPriceIncrementUSD = reader["OrgPriceIncrementUSD"].AsDecimal(),
            OrgPriceIncrementCurrencyUSD = reader["OrgPriceIncrementCurrencyUSD"].AsDecimal(),
            TotalOrgPriceIncrementUSD = reader["TotalOrgPriceIncrementUSD"].AsDecimal(),
            OrgPriceDecrement = reader["OrgPriceDecrement"].AsDecimal(),
            OrgPriceDecrementUSD = reader["OrgPriceDecrementUSD"].AsDecimal(),
            OrgPriceDecrementCurrencyUSD = reader["OrgPriceDecrementCurrencyUSD"].AsDecimal(),
            TotalOrgPriceDecrementUSD = reader["TotalOrgPriceDecrementUSD"].AsDecimal(),
            OrgPriceClosing = reader["OrgPriceClosing"].AsDecimal(),
            OrgPriceClosingUSD = reader["OrgPriceClosingUSD"].AsDecimal(),
            OrgPriceClosingCurrencyUSD = reader["OrgPriceClosingCurrencyUSD"].AsDecimal(),
            TotalOrgPriceClosingUSD = reader["TotalOrgPriceClosingUSD"].AsDecimal(),
            Grade = reader["Grade"].AsInt(),
            Sort = reader["OrderNumber"].AsString()
        };

        private static readonly Func<IDataReader, FixedAssetC55aHDEntity> MakeFixedAssetC55aHD = reader => new FixedAssetC55aHDEntity
        {
            OrderNumber = reader["OrderNumber"].AsInt(),
            FixedAssetId = reader["FixedAssetID"].AsInt(),
            FixedAssetName = reader["FixedAssetName"].AsString(),
            FixedAssetCategoryCode = reader["FixedAssetCategoryCode"].AsString(),
            FixedAssetCategoryName = reader["FixedAssetCategoryName"].AsString(),
            YearOfUsing = reader["YearOfUsing"].AsInt(),
            AddressUsing = reader["AddressUsing"].AsString(),
            Unit = reader["Unit"].AsString(),
            SerialNumber = reader["SerialNumber"].AsString(),
            QuantityOrgPrice = reader["QuantityOrgPrice"].AsInt(),
            OrgPrice = reader["OrgPrice"].AsDecimal(),
            OrgPriceUSD = reader["OrgPriceUSD"].AsDecimal(),
            OrgPriceCurrencyUSD = reader["OrgPriceCurrencyUSD"].AsDecimal(),
            TotalOrgPriceUSD = reader["TotalOrgPriceUSD"].AsDecimal(),
            AnnualDepreciationAmount = reader["AnnualDepreciationAmount"].AsDecimal(),
            RemainigAmount = reader["RemainigAmount"].AsDecimal(),
            LifeTime = reader["LifeTime"].AsInt(),
            AnnualDepreciationRate = reader["AnnualDepreciationRate"].AsDecimal(),
            QuantityDepreciation = reader["QuantityDepreciation"].AsInt(),
            DepreciationYearAmount = reader["DepreciationYearAmount"].AsDecimal(),
            DepreciationYearAmountUSD = reader["DepreciationYearAmountUSD"].AsDecimal(),
            DepreciationYearAmountCurrencyUSD = reader["DepreciationYearAmountCurrencyUSD"].AsDecimal(),
            TotalDepreciationYearAmountUSD = reader["TotalDepreciationYearAmountUSD"].AsDecimal()
        };

        private static readonly Func<IDataReader, FixedAssetFAInventoryEntity> MakeFixedAssetFAInventory = reader => new FixedAssetFAInventoryEntity
        {
            OrderNumber = 0,
            FixedAssetCategoryCode = reader["FixedAssetCategoryCode"].AsString(),
            FixedAssetId = reader["FixedAssetID"].AsInt(),
            FixedAssetCode = reader["FixedAssetCode"].AsString(),
            FixedAssetName = reader["FixedAssetName"].AsString(),
            ParentId = reader["ParentID"].AsInt(),
            YearOfUsing = reader["YearOfUsing"].AsInt(),
            Description = reader["Description"].AsString(),
            Unit = reader["Unit"].AsString(),
            DepreciationRate = reader["DepreciationRate"].AsDecimal(),
            SerialNumber = reader["SerialNumber"].AsString(),
            CountryProduction = reader["CountryProduction"].AsString(),
            Quantity = reader["Quantity"].AsInt(),
            OrgPrice = reader["OrgPrice"].AsDecimal(),
            OrgPriceUsd = reader["OrgPriceUSD"].AsDecimal(),
            OrgPriceCurrencyUsd = reader["OrgPriceCurrencyUSD"].AsDecimal(),
            TotalOrgPriceUsd = reader["TotalOrgPriceUSD"].AsDecimal(),

            QuantityInvetory = reader["QuantityInvetory"].AsInt(),
            OrgPriceInvetory = reader["OrgPriceInvetory"].AsDecimal(),
            OrgPriceCurrencyInvetoryUsd = reader["OrgPriceCurrencyInvetoryUSD"].AsDecimal(),
            OrgPriceInvetoryUsd = reader["OrgPriceInvetoryUSD"].AsDecimal(),
            TotalOrgPriceInvetoryUsd = reader["TotalOrgPriceInvetoryUSD"].AsDecimal(),

            QuantityDifference = reader["QuantityDifference"].AsInt(),
            OrgPriceDifference = reader["OrgPriceDifference"].AsDecimal(),
            OrgPriceCurrencyDifferenceUsd = reader["OrgPriceCurrencyDifferenceUSD"].AsDecimal(),
            OrgPriceDifferenceUsd = reader["OrgPriceDifferenceUSD"].AsDecimal(),
            TotalOrgPriceDifferenceUsd = reader["TotalOrgPriceDifferenceUSD"].AsDecimal(),

            Grade = reader["Grade"].AsInt(),
            Sort = reader["OrderNumber"].AsString(),
            IsParent = reader["IsParent"].AsBool()
        };

        private static readonly Func<IDataReader, FixedAssetFAInventoryHouseEntity> MakeFixedAssetFAInventoryHouse = reader => new FixedAssetFAInventoryHouseEntity
        {
            OrderNumber = 0,
            FixedAssetId = reader["FixedAssetID"].AsInt(),
            FixedAssetCode = reader["FixedAssetCode"].AsString(),
            FixedAssetName = reader["FixedAssetName"].AsString(),
            NumberOfFloor = reader["NumberOfFloor"].AsInt(),
            UsedDate = reader["UsedDate"].AsDateTime(),
            ProductionYear = reader["ProductionYear"].AsInt(),
            GradeHouse = reader["GradeHouse"].AsString(),
            AreaOfBuilding = reader["AreaOfBuilding"].AsDecimal(),
            WorkingArea = reader["WorkingArea"].AsDecimal(),
            AreaOfFloor = reader["AreaOfFloor"].AsDecimal(),
            GuestHouseArea = reader["GuestHouseArea"].AsDecimal(),
            HousingArea = reader["HousingArea"].AsDecimal(),
            OtherArea = reader["OtherArea"].AsDecimal(),
            RemainingAmount = reader["RemainingAmount"].AsDecimal(),
            OrgPrice = reader["OrgPrice"].AsDecimal(),
            OrgPriceUsd = reader["OrgPriceUSD"].AsDecimal(),
            OrgPriceCurrencyUsd = reader["OrgPriceCurrencyUSD"].AsDecimal(),
            OrgPriceDifference = reader["OrgPriceDifference"].AsDecimal(),
            OrgPriceCurrencyDifferenceUsd = reader["OrgPriceCurrencyDifferenceUSD"].AsDecimal(),
            OrgPriceDifferenceUsd = reader["OrgPriceDifferenceUSD"].AsDecimal(),
            Description = reader["Description"].AsString(),
        };

        private static readonly Func<IDataReader, FixedAssetFAInventoryCarEntity> MakeFixedAssetFAInventoryCar = reader => new FixedAssetFAInventoryCarEntity
        {
            OrderNumber = reader["OrderNumber"].AsInt(),
            FixedAssetId = reader["FixedAssetID"].AsInt(),
            FixedAssetCode = reader["FixedAssetCode"].AsString(),
            FixedAssetName = reader["FixedAssetName"].AsString(),
            CountryProduction = reader["CountryProduction"].AsString(),
            SerialNumber = reader["SerialNumber"].AsString(),
            Brand = reader["Brand"].AsString(),
            ControlPlate = reader["ControlPlate"].AsString(),
            NumberOfSeat = reader["NumberOfSeat"].AsInt(),
            ProductionYear = reader["ProductionYear"].AsInt(),
            UsedDate = reader["UsedDate"].AsDateTime(),
            OrgPrice = reader["OrgPrice"].AsDecimal(),
            OrgPriceUsd = reader["OrgPriceUSD"].AsDecimal(),
            OrgPriceCurrencyUsd = reader["OrgPriceCurrencyUSD"].AsDecimal(),
            OrgPriceDifference = reader["OrgPriceDifference"].AsDecimal(),
            OrgPriceDifferenceUsd = reader["OrgPriceDifferenceUSD"].AsDecimal(),
            OrgPriceCurrencyDifferenceUsd = reader["OrgPriceCurrencyDifferenceUSD"].AsDecimal(),
            RemainingAmount = reader["RemainingAmount"].AsDecimal(),
            Car1 = reader["Car1"].AsString(),
            Car2 = reader["Car2"].AsString(),
            Car = reader["Car"].AsString()
        };

        private static readonly Func<IDataReader, FixedAssetS31HEntity> MakeFixedAssetS31H = reader => new FixedAssetS31HEntity
        {
            PostedDate = reader["PostedDate"].AsDateTime(),
            RefNo = reader["RefNo"].AsString(),
            RefDate = reader["RefDate"].AsDateTime(),
            FixedAssetName = reader["FixedAssetName"].AsString(),
            FixedAssetCode = reader["FixedAssetCode"].AsString(),
            DepartmentName = reader["DepartmentName"].AsString(),
            EmployeeName = reader["EmployeeName"].AsString(),
            YearOfUsing = reader["YearOfUsing"].AsInt(),
            LifeTime = reader["LifeTime"].AsFloat(),
            AnnualDepreciationRate = reader["AnnualDepreciationRate"].AsFloat(),
            OrgPrice = reader["OrgPrice"].AsDecimal(),
            AnnualDepreciationAmount = reader["AnnualDepreciationAmount"].AsDecimal(),
            RemainingPriceBeforeDecrement = reader["RemainingPriceBeforeDecrement"].AsDecimal()
        };

        private static readonly Func<IDataReader, FixedAssetB02Entity> MakeFixedAssetB02 = reader => new FixedAssetB02Entity
        {
            OrderNumber = 0,
            FixedAssetCategoryCode = reader["FixedAssetCategoryCode"].AsString(),
            FixedAssetId = reader["FixedAssetID"].AsInt(),
            FixedAssetCode = reader["FixedAssetCode"].AsString(),
            FixedAssetName = reader["FixedAssetName"].AsString(),
            ParentId = reader["ParentID"].AsInt(),
            YearOfUsing = reader["YearOfUsing"].AsInt(),
            AddressUsing = reader["AddressUsing"].AsString(),
            DepreciationRate = reader["DepreciationRate"].AsDecimal(),
            Description = reader["Description"].AsString(),
            Unit = reader["Unit"].AsString(),
            SerialNumber = reader["SerialNumber"].AsString(),
            CountryProduction = reader["CountryProduction"].AsString(),
            Quantity = reader["Quantity"].AsInt(),
            OrgPrice = reader["OrgPrice"].AsDecimal(),
            OrgPriceUsd = reader["OrgPriceUSD"].AsDecimal(),
            OrgPriceCurrencyUsd = reader["OrgPriceCurrencyUSD"].AsDecimal(),
            TotalOrgPriceUsd = reader["TotalOrgPriceUSD"].AsDecimal(),
            Grade = reader["Grade"].AsInt(),
            Sort = reader["OrderNumber"].AsString()
        };

        private static readonly Func<IDataReader, FixedAssetB01Entity> MakeFixedAssetB01 = reader => new FixedAssetB01Entity
        {
            OrderNumber = 0,
            FixedAssetCategoryCode = reader["FixedAssetCategoryCode"].AsString(),
            FixedAssetId = reader["FixedAssetID"].AsInt(),
            FixedAssetCode = reader["FixedAssetCode"].AsString(),
            FixedAssetName = reader["FixedAssetName"].AsString(),
            //ParentId = reader["ParentID"].AsInt(),
            YearOfUsing = reader["YearOfUsing"].AsInt(),
            Description = reader["Description"].AsString(),
            DepreciationRate = reader["DepreciationRate"].AsDecimal(),
            AddressUsing = reader["AddressUsing"].AsString(),
            Unit = reader["Unit"].AsString(),
            SerialNumber = reader["SerialNumber"].AsString(),
            OrgPrice = reader["OrgPrice"].AsDecimal(),
            OrgPriceDecrementUSD = reader["OrgPriceDecrementUSD"].AsDecimal(),
            OrgPriceDecrementCurrencyUSD = reader["OrgPriceDecrementCurrencyUSD"].AsDecimal(),
            TotalOrgPriceDecrementUSD = reader["TotalOrgPriceDecrementUSD"].AsDecimal(),
            QuantityDecrement = reader["QuantityDecrement"].AsInt(),
            OrgPriceDecrement = reader["OrgPriceDecrement"].AsDecimal(),
            QuantityAnnualDepreciation = reader["QuantityAnnualDepreciation"].AsInt(),
            AnnualDepreciationAmountUSD = reader["AnnualDepreciationAmountUSD"].AsDecimal(),
            AnnualDepreciationAmountCurrencyUSD = reader["AnnualDepreciationAmountCurrencyUSD"].AsDecimal(),
            TotalAnnualDepreciationAmountUSD = reader["TotalAnnualDepreciationAmountUSD"].AsDecimal(),
            AnnualDepreciationAmount = reader["AnnualDepreciationAmount"].AsDecimal(),
            QuantityRemainingDecrement = reader["QuantityRemainingDecrement"].AsInt(),
            RemainingAmountDecrement = reader["RemainingAmountDecrement"].AsDecimal(),
            RemainingAmountDecrementUSD = reader["RemainingAmountDecrementUSD"].AsDecimal(),
            RemainingAmountDecrementCurrencyUSD = reader["RemainingAmountDecrementCurrencyUSD"].AsDecimal(),
            TotalRemainingAmountDecrementUSD = reader["TotalRemainingAmountDecrementUSD"].AsDecimal(),
            Grade = reader["Grade"].AsInt(),
            Sort = reader["OrderNumber"].AsString()
        };

        private static readonly Func<IDataReader, FixedAssetForEstimateEntity> MakeFixedAsset = reader => new FixedAssetForEstimateEntity
        {
            OrderNumber = reader["ID"].AsInt(),
            EmployeeName = reader["EmployeeName"].AsString(),
            JobCandidateName = reader["JobCandidateName"].AsString(),
            Description = reader["Description"].AsString(),
            Address = reader["Address"].AsString(),
            UsingOfArea = reader["UsingOfArea"].AsFloat()
        };

        private static readonly Func<IDataReader, FixedAssetCardsEntity> MakeFixedAssetMasterCard = reader => new FixedAssetCardsEntity
        {
            FixedAssetId = reader["FixedAssetId"].AsInt(),
            FixedAssetCode = reader["FixedAssetCode"].AsString(),
            FixedAssetName = reader["FixedAssetName"].AsString(),
            MadeIn = reader["MadeIn"].AsString(),
            ProductionYear = reader["ProductionYear"].AsInt(),
            DepartmentName = reader["DepartmentName"].AsString(),
            UsedDate = reader["UsedDate"].AsDateTime(),
            DateSuspension = reader["DateSuspension"].AsDateTimeForNull(),
            ReasonSuspension = reader["ReasonSuspension"].AsString(),
            AreaOfFloor = reader["AreaOfFloor"].AsDecimal(),
            RefNoGG = reader["RefNoGG"].AsString(),
            PostdateGG = reader["PostdateGG"].AsDateTimeForNull(),
            DescriptionGG = reader["DescriptionGG"].AsString(),
        };

        private static readonly Func<IDataReader, FixedAssetDetailCards01Entity> MakeFixedAssetDetailCards01 = reader => new FixedAssetDetailCards01Entity
        {
            RefNo = reader["RefNo"].AsString(),
            PostedDate = reader["PostedDate"].AsDateTime(),
            Description = reader["Description"].AsString(),
            CurrencyCode = reader["CurrencyCode"].AsString(),
            OrgPrice = reader["OrgPrice"].AsDecimal(),
            DepreciationDate = reader["DepreciationDate"].AsDateTime(),
            AnnualDepreciationAmount = reader["AnnualDepreciationAmount"].AsDecimal(),
            AccumDepreciationAmount = reader["AccumDepreciationAmount"].AsDecimal(),
        };

        private static readonly Func<IDataReader, FixedAssetDetailCards02Entity> MakeFixedAssetDetailCards02 = reader => new FixedAssetDetailCards02Entity
        {
            FixedAssetAccessaryName = reader["FixedAssetAccessaryName"].AsString(),
            Unit = reader["Unit"].AsString(),
            Quantity = reader["Quantity"].AsInt(),
            Amount = reader["Amount"].AsDecimal()
        };

        #endregion

        #region Make Estimate

        private static readonly Func<IDataReader, GeneralReceiptEstimateEntity> MakeGeneralReceiptEstimate = reader => new GeneralReceiptEstimateEntity
        {
            Id = reader["ID"].AsInt(),
            BudgetItemCode = reader["BudgetItemCode"].AsString(),
            BudgetItemName = reader["BudgetItemName"].AsString(),
            PreviousYearOfTotalEstimateAmount = reader["PreviousYearOfTotalEstimateAmount"].AsDecimal(),
            YearOfEstimateAmount = reader["YearOfEstimateAmount"].AsDecimal(),
            NextYearOfEstimateAmount = reader["NextYearOfEstimateAmount"].AsDecimal(),
            Description = reader["Description"].AsString(),
            ItemCodeList = reader["ItemCodeList"].AsString(),
            NumberOrder = reader["NumberOrder"].AsString(),
            FontStyle = reader["FontStyle"].AsString(),
            IsParent = reader["IsParent"].AsBool()
        };

        private static readonly Func<IDataReader, GeneralPaymentEstimateEntity> MakeGeneralPaymentEstimate = reader => new GeneralPaymentEstimateEntity
        {
            BudgetItemId = reader["BudgetItemID"].AsInt(),
            BudgetItemCode = reader["BudgetItemCode"].AsString(),
            BudgetItemName = reader["BudgetItemName"].AsString(),
            ParentId = reader["ParentID"].AsString().AsIntForNull(),
            Grade = reader["Grade"].AsShort(),
            TotalEstimateAmountUSD = reader["TotalEstimateAmountUSD"].AsDecimal(),
            YearOfEstimateAmount = reader["YearOfEstimateAmount"].AsDecimal(),
            NextYearOfEstimateAmount = reader["NextYearOfEstimateAmount"].AsDecimal(),
            AutonomyBudget = reader["AutonomyBudget"].AsDecimal(),
            NonAutonomyBudget = reader["NonAutonomyBudget"].AsDecimal(),
            TotalNextYearOfEstimateAmount = reader["TotalNextYearOfEstimateAmount"].AsDecimal(),
            Description = reader["Description"].AsString(),
            BudgetSourceCategoryName = reader["BudgetSourceCategoryName"].AsString()
        };

        private static readonly Func<IDataReader, GeneralEstimateEntity> MakeGeneralEstimate = reader => new GeneralEstimateEntity
        {
            BudgetItemName = reader["BudgetItemName"].AsString(),
            PreviousYearOfTotalEstimateAmount = reader["PreviousYearOfTotalEstimateAmount"].AsDecimal(),
            YearOfEstimateAmount = reader["YearOfEstimateAmount"].AsDecimal(),
            NextYearOfEstimateAmount = reader["NextYearOfEstimateAmount"].AsDecimal(),
            Description = reader["Description"].AsString()
        };

        private static readonly Func<IDataReader, GeneralPaymentDetailEstimateEntity> MakeGeneralPaymentDetailEstimate = reader => new GeneralPaymentDetailEstimateEntity
        {
            BudgetItemId = reader["BudgetItemID"].AsInt(),
            BudgetItemCode = reader["BudgetItemCode"].AsString(),
            BudgetItemName = reader["BudgetItemName"].AsString(),
            BudgetSubItemCode = reader["BudgetSubItemCode"].AsString(),
            ParentId = reader["ParentID"].AsString().AsIntForNull(),
            Grade = reader["Grade"].AsShort(),
            TotalEstimateAmountUSD = reader["TotalEstimateAmountUSD"].AsDecimal(),
            YearOfEstimateAmount = reader["YearOfEstimateAmount"].AsDecimal(),
            NextYearOfEstimateAmount = reader["NextYearOfEstimateAmount"].AsDecimal(),
            AutonomyBudget = reader["AutonomyBudget"].AsDecimal(),
            NonAutonomyBudget = reader["NonAutonomyBudget"].AsDecimal(),
            TotalNextYearOfEstimateAmount = reader["TotalNextYearOfEstimateAmount"].AsDecimal(),
            Description = reader["Description"].AsString(),
            BudgetSourceCategoryName = reader["BudgetSourceCategoryName"].AsString(),
        };

        private static readonly Func<IDataReader, FundStuationEntity> MakeFundStuation = reader => new FundStuationEntity
        {
            BudgetItemId = reader["BudgetItemID"].AsInt(),
            BudgetItemCode = reader["BudgetItemCode"].AsString(),
            BudgetItemName = reader["BudgetItemName"].AsString(),
            BudgetSubItemCode = reader["BudgetSubItemCode"].AsString(),
            ParentId = reader["ParentID"].AsInt(),
            Grade = reader["Grade"].AsShort(),
            Sort = reader["Sort"].AsString(),
            BudgetItemType = reader["BudgetItemType"].AsShort(),
            PreviousYearOfAutonomyBudget = reader["PreviousYearOfAutonomyBudget"].AsDecimal(),
            PreviousYearOfNonAutonomyBudget = reader["PreviousYearOfNonAutonomyBudget"].AsDecimal(),
            TotalEstimateAmountUSD = reader["TotalEstimateAmountUSD"].AsDecimal(),
            YearOfAutonomyBudget = reader["YearOfAutonomyBudget"].AsDecimal(),
            YearOfNonAutonomyBudget = reader["YearOfNonAutonomyBudget"].AsDecimal(),
            YearOfEstimateAmount = reader["YearOfEstimateAmount"].AsDecimal(),
            SixMonthBeginingAutonomyBudget = reader["SixMonthBeginingAutonomyBudget"].AsDecimal(),
            SixMonthBeginingNonAutonomyBudget = reader["SixMonthBeginingNonAutonomyBudget"].AsDecimal(),
            TotalAmountSixMonthBegining = reader["TotalAmountSixMonthBegining"].AsDecimal(),
            SixMonthEndingAutonomyBudget = reader["SixMonthEndingAutonomyBudget"].AsDecimal(),
            SixMonthEndingNonAutonomyBudget = reader["SixMonthEndingNonAutonomyBudget"].AsDecimal(),
            TotalAmountSixMonthEnding = reader["TotalAmountSixMonthEnding"].AsDecimal(),
            YearOfAmountAutonomyBudget = reader["YearOfAmountAutonomyBudget"].AsDecimal(),
            YearOfAmountNonAutonomyBudget = reader["YearOfAmountNonAutonomyBudget"].AsDecimal(),
            YearOfTotalAmount = reader["YearOfTotalAmount"].AsDecimal(),
            YearOfDifferenceAmountAutonomyBudget = reader["YearOfDifferenceAmountAutonomyBudget"].AsDecimal(),
            YearOfDifferenceAmountNonAutonomyBudget = reader["YearOfDifferenceAmountNonAutonomyBudget"].AsDecimal(),
            YearOfDifferenceTotalAmount = reader["YearOfDifferenceTotalAmount"].AsDecimal(),
            Description = reader["Description"].AsString(),
            BudgetSourceCategoryName = reader["BudgetSourceCategoryName"].AsString()
        };

        private static readonly Func<IDataReader, EmployeeForEstimateEntity> MakeEmployee = reader => new EmployeeForEstimateEntity
        {
            OrderNumber = reader["ID"].AsInt(),
            EmployeeName = reader["EmployeeName"].AsString(),
            JobCandidateName = reader["JobCandidateName"].AsString(),
            Description = reader["Description"].AsString(),
            SubsitenceFee = reader["SubsitenceFee"].AsFloat(),
            WomenAllowance = reader["WomenAllowance"].AsFloat(),
            PluralityAllowance = reader["PluralityAllowance"].AsFloat(),
            StartedDate = reader["StartedDate"].AsDateTime(),
            FinishedDate = reader["FinishedDate"].AsDateTime(),
        };



        #endregion

        #region Make ReportList

        private static readonly Func<IDataReader, ReportListEntity> Make = reader => new ReportListEntity
        {
            ReportId = reader["ReportID"].AsString(),
            ReportName = reader["ReportName"].AsString(),
            Description = reader["Description"].AsString(),
            GroupId = reader["GroupID"].AsInt(),
            ReportFile = reader["ReportFile"].AsString(),
            OutputAssembly = reader["OutputAssembly"].AsString(),
            InputTypeName = reader["InputTypeName"].AsString(),
            FunctionReportName = reader["FunctionReportName"].AsString(),
            ProcedureName = reader["ProcedureName"].AsString(),
            TableName = reader["TableName"].AsString(),
            TrackType = reader["TrackType"].AsInt(),
            ProcedureNameByLot = reader["ProcedureNameByLot"].AsString(),
            ProcedureNameVoucherList = reader["ProcedureNameVoucherList"].AsString(),
            Selected = reader["Selected"].AsBool(),
            Inactive = reader["Inactive"].AsBool(),
            RefRypeVoucherID = reader["RefRypeVoucherID"].AsInt(),
            PrintVoucherDefault = reader["PrintVoucherDefault"].AsBool(),
            LicenceType = reader["LicenceType"].AsInt(),
            ParamFormName = reader["ParamFormName"].AsString(),
            SupplementInfoReportId = reader["SupplementInfoReportID"].AsString(),
            SupplementInfoTableName = reader["SupplementInfoTableName"].AsString(),
            SortOrder = reader["SortOrder"].AsInt()
        };

        #endregion

        #region Make Cash Reprot

        private static readonly Func<IDataReader, CashReportEntity> MakeS11AH = reader => new CashReportEntity
        {
            RefNo = reader["RefNo"].AsString(),
            CorrespondingAccountNumber = reader["CorrespondingAccountNumber"].AsString(),
            PostedDate = reader["PostedDate"].AsDateTime().ToShortDateString(),
            Description = reader["Description"].AsString(),
            PayAmount = reader["PayAmount"].AsDecimal(),
            ReceiptAmount = reader["ReceiptAmount"].AsDecimal(),
            RestAmount = reader["RestAmount"].AsDecimal(),
            AccumulatedReceiptAmount = reader["AccumulatedReceiptAmount"].AsDecimal(),
            AccumulatedPayAmount = reader["AccumulatedPayAmount"].AsDecimal(),
            RefId = reader["RefID"].AsInt(),
            RefTypeId = reader["RefTypeID"].AsInt()
        };

        #endregion

        #region Make Settlement Report

        private static readonly Func<IDataReader, ReportB01CIEntity> MakeB01CI = reader =>
        {
            var result = new ReportB01CIEntity();
            result.OrderNumber = reader["OrderNumber"].AsInt();
            result.OrderCode = reader["OrderCode"].AsString();
            result.Content = reader["Content"].AsString();
            result.Col01 = reader["Col01"].AsDecimal();
            result.Col02 = reader["Col02"].AsDecimal();
            result.Col03 = reader["Col03"].AsDecimal();
            result.Col04 = reader["Col04"].AsDecimal();
            result.Col05 = reader["Col05"].AsDecimal();
            result.Col06 = reader["Col06"].AsDecimal();
            result.Col07 = reader["Col07"].AsDecimal();
            result.Col08 = reader["Col08"].AsDecimal();
            result.Col09 = reader["Col09"].AsDecimal();
            result.Col10 = reader["Col10"].AsDecimal();
            result.Col11 = reader["Col11"].AsDecimal();
            result.Col12 = reader["Col12"].AsDecimal();
            result.Col13 = reader["Col13"].AsDecimal();
            result.Col14 = reader["Col14"].AsDecimal();
            result.Col15 = reader["Col15"].AsDecimal();
            result.Col16 = reader["Col16"].AsDecimal();
            result.Col17 = reader["Col17"].AsDecimal();
            result.Col18 = reader["Col18"].AsDecimal();
            result.Col19 = reader["Col19"].AsDecimal();
            result.Col20 = reader["Col20"].AsDecimal();
            result.Col21 = reader["Col21"].AsDecimal();
            result.Col22 = reader["Col22"].AsDecimal();
            result.Col23 = reader["Col23"].AsDecimal();
            result.Col24 = reader["Col24"].AsDecimal();
            result.Col25 = reader["Col25"].AsDecimal();
            result.Col26 = reader["Col26"].AsDecimal();
            result.Col27 = reader["Col27"].AsDecimal();
            result.Col28 = reader["Col28"].AsDecimal();
            result.ExchangeRateLastYear = reader["ExchangeRateLastYear"].AsDecimal();
            result.ExchangeRateThisYear = reader["ExchangeRateThisYear"].AsDecimal();
            return result;
        };

        private static readonly Func<IDataReader, ReportB01CIIEntity> MakeB01CII = reader =>
        {
            var result = new ReportB01CIIEntity();
            result.SortOrder = reader["SortOrder"].AsInt();
            result.Grade = reader["Grade"].AsInt();
            result.FontStyle = reader["FontStyle"].AsString();
            result.BudgetItemCode = reader["BudgetItemCode"].AsString();
            result.BudgetItemName = reader["BudgetItemName"].AsString();
            // tổng cộng
            result.Column1 = reader["Column1"].AsDecimal();
            result.Column2 = reader["Column2"].AsDecimal();
            result.Column3 = reader["Column3"].AsDecimal();
            result.Column4 = reader["Column4"].AsDecimal();
            // tự chủ
            result.Column5 = reader["Column5"].AsDecimal();
            result.Column6 = reader["Column6"].AsDecimal();
            result.Column7 = reader["Column7"].AsDecimal();
            result.Column8 = reader["Column8"].AsDecimal();
            // nguồn 13
            result.Column9 = reader["Column9"].AsDecimal();
            result.Column10 = reader["Column10"].AsDecimal();
            result.Column11 = reader["Column11"].AsDecimal();
            result.Column12 = reader["Column12"].AsDecimal();
            // nguồn 15.1
            result.Column13 = reader["Column13"].AsDecimal();
            result.Column14 = reader["Column14"].AsDecimal();
            result.Column15 = reader["Column15"].AsDecimal();
            result.Column16 = reader["Column16"].AsDecimal();

            // không tự chủ
            result.Column17 = reader["Column17"].AsDecimal();
            result.Column18 = reader["Column18"].AsDecimal();
            result.Column19 = reader["Column19"].AsDecimal();
            result.Column20 = reader["Column20"].AsDecimal();
            // nguồn 12
            result.Column21 = reader["Column21"].AsDecimal();
            result.Column22 = reader["Column22"].AsDecimal();
            result.Column23 = reader["Column23"].AsDecimal();
            result.Column24 = reader["Column24"].AsDecimal();
            // nguồn 15.2
            result.Column25 = reader["Column25"].AsDecimal();
            result.Column26 = reader["Column26"].AsDecimal();
            result.Column27 = reader["Column27"].AsDecimal();
            result.Column28 = reader["Column28"].AsDecimal();
            // tỷ giá năm trước
            result.ExchangeRateLastYear = reader["ExchangeRateLastYear"].AsDecimal();
            // tỷ giá năm nay
            result.ExchangeRateThisYear = reader["ExchangeRateThisYear"].AsDecimal();
            return result;
        };

        private static readonly Func<IDataReader, ReportB01CII01ReportEntity> MakeB01CII01 = reader =>
        {
            var reportB01CII = new ReportB01CII01ReportEntity();
            reportB01CII.OrderNumber = reader["OrderNumber"].AsInt();
            reportB01CII.BudgetItemCode = reader["BudgetItemCode"].AsString();
            reportB01CII.BudgetItemName = reader["BudgetItemName"].AsString();
            reportB01CII.BudgetSubItemCode = reader["BudgetSubItemCode"].AsString();
            reportB01CII.BudgetSubItemName = reader["BudgetSubItemName"].AsString();
            reportB01CII.Grade = reader["Grade"].AsInt();
            reportB01CII.FontStyle = reader["FontStyle"].AsString();
            reportB01CII.Column1 = reader["Column1"].AsDecimal();
            reportB01CII.Column2 = reader["Column2"].AsDecimal();
            reportB01CII.Column3 = reader["Column3"].AsDecimal();
            reportB01CII.Column4 = reader["Column4"].AsDecimal();
            reportB01CII.Column5 = reader["Column5"].AsDecimal();
            reportB01CII.Column6 = reader["Column6"].AsDecimal();
            reportB01CII.Column7 = reader["Column7"].AsDecimal();
            reportB01CII.Column8 = reader["Column8"].AsDecimal();
            reportB01CII.Column9 = reader["Column9"].AsDecimal();
            reportB01CII.Column10 = reader["Column10"].AsDecimal();
            reportB01CII.Column11 = reader["Column11"].AsDecimal();
            reportB01CII.Column12 = reader["Column12"].AsDecimal();
            reportB01CII.Column13 = reader["Column13"].AsDecimal();
            return reportB01CII;
        };

        private static readonly Func<IDataReader, ReportB01CII01ExchangeRateEntity> MakeReportB01CII01ExchangeRate = reader =>
        {
            var reportB01CIIExchangeRate = new ReportB01CII01ExchangeRateEntity();
            reportB01CIIExchangeRate.ExchangeRateLastYear = reader["ExchangeRateLastYear"].AsDecimal();
            reportB01CIIExchangeRate.ExchangeRateThisYear = reader["ExchangeRateThisYear"].AsDecimal();
            return reportB01CIIExchangeRate;
        };

        private static readonly Func<IDataReader, ReportS104HEntity> MakeS104H = reader =>
        {
            var result = new ReportS104HEntity();
            result.RefNo = reader["RefNo"].AsString();
            result.RefDate = reader["RefDate"].AsDateTime();
            result.PostedDate = reader["PostedDate"].AsDateTime();
            result.Description = reader["Description"].AsString();

            result.Amount01 = reader["Amount01"].AsDecimal();
            result.Amount02 = reader["Amount02"].AsDecimal();
            result.Amount03 = reader["Amount03"].AsDecimal();
            result.Amount04 = reader["Amount04"].AsDecimal();
            result.Amount05 = reader["Amount05"].AsDecimal();
            result.Amount06 = reader["Amount06"].AsDecimal();
            result.Amount07 = reader["Amount07"].AsDecimal();
            return result;
        };

        #endregion

        #region Make ReportB04BCTC

        private static readonly Func<IDataReader, ReportB04BCTCDetail01Entity> MakeReportB04BCTCDetail01 = reader =>
        {
            var reportB04 = new ReportB04BCTCDetail01Entity();
            reportB04.Content = reader["Content"].AsString();
            reportB04.EndAmount = reader["EndYear"].AsDecimal();
            reportB04.BeginAmount = reader["BeginYear"].AsDecimal();
            return reportB04;
        };
        private static readonly Func<IDataReader, ReportB04BCTCDetail02Entity> MakeReportB04BCTCDetail02 = reader =>
        {
            var reportB04 = new ReportB04BCTCDetail02Entity();
            reportB04.Content = reader["Content"].AsString();
            reportB04.TotalAmount = reader["Total"].AsDecimal();
            reportB04.TangibleFixedAssets = reader["TangibleFixedAssets"].AsDecimal();
            reportB04.IntangibleFixedAssets = reader["IntangibleFixedAssets"].AsDecimal();
            return reportB04;
        };

        private static readonly Func<IDataReader, ReportB04BCTCDetail03Entity> MakeReportB04BCTCDetail03 = reader =>
        {
            var reportB04 = new ReportB04BCTCDetail03Entity();
            reportB04.Content = reader["Content"].AsString();
            reportB04.BusinessCapital = reader["BusinessCapital"].AsDecimal();
            reportB04.ExchangeRateDifference = reader["ExchangeRateDifference"].AsDecimal();
            reportB04.AccumulatedSurplus = reader["AccumulatedSurplus"].AsDecimal();
            reportB04.Funds = reader["Funds"].AsDecimal();
            reportB04.SourceWageReform = reader["SourceWageReform"].AsDecimal();
            reportB04.Other = reader["Other"].AsDecimal();
            reportB04.TotalAmount = reader["Total"].AsDecimal();
            return reportB04;
        };

        #endregion

        #region Make LedgerAccounting

        private static readonly Func<IDataReader, BusinessEntities.Report.LedgerAccounting.ReportS104HEntity> MakeLedgerAccountingS104H = reader =>
        {
            var result = new BusinessEntities.Report.LedgerAccounting.ReportS104HEntity();
            result.RefId = reader["RefID"].AsLong();
            result.RefNo = reader["RefNo"].AsString();
            result.RefDate = reader["RefDate"].AsDateTimeForNull()?.ToShortDateString() ?? null;
            result.Description = reader["Description"].AsString();
            result.RefTypeId = reader["RefTypeID"].AsInt();

            result.ExpenseAmount = reader["ExpenseAmount"].AsDecimal();
            result.UsedAmount = reader["UsedAmount"].AsDecimal();
            result.RepayAmount = reader["RepayAmount"].AsDecimal();
            result.UnusedAmount = reader["UnusedAmount"].AsDecimal();

            result.FontStyle = reader["FontStyle"].AsString();
            result.Grade = reader["Grade"].AsInt();
            result.SortOrder = reader["SortOrder"].AsInt();
            return result;
        };

        #endregion

        #region Take

        private object[] Take(ReportListEntity reportList)
        {
            return new object[]
             {
                 "@ReportID",reportList.ReportId,
                 "@PrintVoucherDefault",reportList.PrintVoucherDefault
             };
        }

        #endregion
    }
}
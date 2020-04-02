/***********************************************************************
 * <copyright file="ReportListFacade.cs" company="BUCA JSC">
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
using System.Linq;
using TSD.AccountingSoft.BusinessComponents.Messages.MessageBase;
using TSD.AccountingSoft.BusinessComponents.Messages.Report;
using TSD.AccountingSoft.BusinessEntities.Report.Estimate;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Dictionary;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Estimate;
using TSD.AccountingSoft.DataAccess.IEntitiesDao.Report;


namespace TSD.AccountingSoft.BusinessComponents.Facade.Report
{
    public class ReportListFacade
    {
        private static readonly IReportListDao ReportListDao = DataAccess.DataAccess.ReportListDao;
        private static readonly IEmployeeLeasingDao EmployeeLeasingDao = DataAccess.DataAccess.EmployeeLeasingDao;
        private static readonly IBuildingDao BuildingDao = DataAccess.DataAccess.BuildingDao;
        private static readonly IEstimateDetailStatementPartBDao EstimateDetailStatementPartBDao = DataAccess.DataAccess.EstimateDetailStatementPartBDao;
        private static readonly IEstimateDetailStatementFixedAssetDao EstimateDetailStatementFixedAssetDao = DataAccess.DataAccess.EstimateDetailStatementFixedAssetDao;
        private static readonly IMutualDao MutualDao = DataAccess.DataAccess.MutualDao;
        private static readonly IFixedAssetDao FixedAssetDao = DataAccess.DataAccess.FixedAssetDao;

        /// <summary>
        /// Gets the report lists.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public ReportListResponse GetReportLists(ReportListRequest request)
        {
            var response = new ReportListResponse();

            if (request.LoadOptions.Contains("ReportLists"))
                response.ReportLists = ReportListDao.GetReportLists();
            if (request.LoadOptions.Contains("ReportListsByReportGroup"))
                response.ReportLists = ReportListDao.GetReportListsByReportGroup(request.ReportGroupId);
            if (request.LoadOptions.Contains("ReportList"))
                response.ReportList = ReportListDao.GetReportListById(request.ReportListId);
            if (request.LoadOptions.Contains("Reports"))
            {
                if (request.LoadOptions.Contains("AccountingVoucher"))
                    response.AccountingVoucher = ReportListDao.GetAccountingVoucher(request.StoreProdure, request.RefIdList, request.RefTypeId).ToList();

                if (request.LoadOptions.Contains("C22H"))
                    response.C22H = ReportListDao.GetReportC22H(request.StoreProdure, request.RefIdList);
                if (request.LoadOptions.Contains("C11H"))
                    response.C11H = ReportListDao.GetReportC11H(request.StoreProdure, request.RefIdList).ToList();
                if (request.LoadOptions.Contains("A02LDTL"))
                    response.A02LDTL = ReportListDao.Get02LdtlWithStoreProdure(request.StoreProdure, request.FromDate, request.ToDate).ToList();
                if (request.LoadOptions.Contains("A02LDTLIsRetail"))
                    response.A02LDTL = ReportListDao.Get02LdtlRetailWithStoreProdure(request.StoreProdure, request.FromDate, request.ToDate, request.WhereClause, request.IsEmployee).ToList();
                if (request.LoadOptions.Contains("S03AH"))
                    response.S03AH = ReportListDao.GetS03AHWithStoreProdure(request.StoreProdure, request.FromDate, request.ToDate, request.CurrencyCode, request.AmounType).ToList();
                if (request.LoadOptions.Contains("B14Q"))
                    response.B14Q = ReportListDao.GetB14QWithStoreProdure(request.StoreProdure, request.FromDate, request.ToDate, request.CurrencyCode, request.AccountNumber, request.ListStockId, request.AmounType).ToList();
                if (request.LoadOptions.Contains("GeneralReceiptEstimate")) //Tổng hợp dự toán thu ngân sách nhà nước
                    response.GeneralReceiptEstimates = ReportListDao.GetGeneralReceiptEstimates(request.YearOfEstimate);
                if (request.LoadOptions.Contains("GeneralPaymentEstimate")) //Tổng hợp dự toán chi ngân sách nhà nước
                    response.GeneralPaymentEstimates = ReportListDao.GetGeneralPaymentEstimates(request.YearOfEstimate);
                if (request.LoadOptions.Contains("GeneralEstimate")) //Tổng hợp dự toán thu chi ngân sách nhà nước
                    response.GeneralEstimates = ReportListDao.GetGeneralEstimates(request.YearOfEstimate);
                if (request.LoadOptions.Contains("GeneralPaymentDetailEstimate")) //Tổng hợp dự toán thu chi ngân sách nhà nước
                    response.GeneralPaymentDetailEstimates = ReportListDao.GetGeneralPaymentDetailEstimates(request.YearOfEstimate);
                if (request.LoadOptions.Contains("FixedAssetB03H")) //Báo cáo tăng giảm tài sản cố định
                    response.FixedAssetB03H = ReportListDao.GetFixedAssetB03H(request.FromDate, request.ToDate, request.CurrencyCode);
                if (request.LoadOptions.Contains("FixedAssetC55aHD")) //Báo cáo hao mòn TSCĐ
                    response.FixedAssetC55aHD = ReportListDao.GetFixedAssetC55aHD(request.FromDate, request.ToDate, request.FixedAssetParameter, request.FaCategoryCode, request.CurrencyCode);
                if (request.LoadOptions.Contains("FixedAssetC55aHDAmountType")) //Báo cáo hao mòn TSCĐ quy đổi
                    response.FixedAssetC55aHD = ReportListDao.GetFixedAssetC55aHDAmountType(request.FromDate, request.ToDate, request.FixedAssetParameter, request.FaCategoryCode, request.CurrencyDecimalDigits);
                if (request.LoadOptions.Contains("FixedAssetFAInventory")) //Báo cáo kiểm kê TSCĐ
                    response.FixedAssetFAInventory = ReportListDao.GetFixedAssetFAInventory(request.FromDate, request.ToDate, request.CurrencyCode, request.CurrencyDecimalDigits);
                if (request.LoadOptions.Contains("FixedAssetFAInventoryAmountType")) //Báo cáo kiểm kê TSCĐ quy đổi
                    response.FixedAssetFAInventory = ReportListDao.GetFixedAssetFAInventoryAmountType(request.FromDate, request.ToDate, request.CurrencyDecimalDigits);
                if (request.LoadOptions.Contains("FixedAssetFAInventoryHouse")) //Báo cáo kê khai nhà cửa đất đai TSCĐ
                    response.FixedAssetFAInventoryHouse = ReportListDao.GetFixedAssetFAInventoryHouse(request.FromDate, request.ToDate, request.CurrencyCode);
                if (request.LoadOptions.Contains("FixedAssetFAInventoryHouseAmountType")) //Báo cáo kê khai nhà cửa theo type
                    response.FixedAssetFAInventoryHouse = ReportListDao.GetFixedAssetFAInventoryHouseAmountType(request.FromDate, request.ToDate, request.CurrencyDecimalDigits);
                if (request.LoadOptions.Contains("FixedAssetFAInventoryCar")) //Báo cáo kiểm kê TSCĐ
                    response.FixedAssetFAInventoryCar = ReportListDao.GetFixedAssetFAInventoryCar(request.FromDate, request.ToDate, request.CurrencyCode);
                if (request.LoadOptions.Contains("FixedAssetFAInventoryCarAmountType")) //Báo cáo kiểm kê TSCĐ quy đổi
                    response.FixedAssetFAInventoryCar = ReportListDao.GetFixedAssetFAInventoryCarAmountType(request.FromDate, request.ToDate, request.CurrencyDecimalDigits);
                if (request.LoadOptions.Contains("FixedAssetFAInventory3000")) //Báo cáo kiểm kê TSCĐ nguyên giá trên 3000
                    response.FixedAssetFAInventory = ReportListDao.GetFixedAssetFAInventory3000(request.FromDate, request.ToDate, request.CurrencyCode);
                if (request.LoadOptions.Contains("FixedAssetFAInventoryAmountType3000")) //Báo cáo kiểm kê TSCĐ quy đổi có nguyên giá trên 3000
                    response.FixedAssetFAInventory = ReportListDao.GetFixedAssetFAInventoryAmountType3000(request.FromDate, request.ToDate);
                if (request.LoadOptions.Contains("FixedAssetS31H")) //Báo cáo tăng giảm tài sản cố định
                    response.FixedAssetS31H = ReportListDao.GetFixedAssetS31H(request.FromDate, request.ToDate, request.FixedAssetParameter, request.FaCategoryCode, request.CurrencyCode);
                if (request.LoadOptions.Contains("FixedAssetB02")) //Báo cáo tăng giảm tài sản cố định
                    response.FixedAssetB02 = ReportListDao.GetFixedAssetB02(request.FromDate, request.ToDate, request.CurrencyCode);
                if (request.LoadOptions.Contains("FixedAssetB02AmountType")) //Báo cáo tăng giảm tài sản cố định
                    response.FixedAssetB02 = ReportListDao.GetFixedAssetB02ByAmountType(request.FromDate, request.ToDate, request.CurrencyDecimalDigits);
                if (request.LoadOptions.Contains("FixedAssetB01")) //Báo cáo tăng giảm tài sản cố định
                    response.FixedAssetB01 = ReportListDao.GetFixedAssetB01(request.FromDate, request.ToDate, request.CurrencyCode);
                if (request.LoadOptions.Contains("FixedAssetB01AmountType")) //Báo cáo giảm tài sản cố định
                    response.FixedAssetB01 = ReportListDao.GetFixedAssetB01AmountType(request.FromDate, request.ToDate, request.CurrencyDecimalDigits);
                if (request.LoadOptions.Contains("FixedAssetB03HAmountType")) //Báo cáo tăng giảm tài sản cố định
                    response.FixedAssetB03H = ReportListDao.GetFixedAssetB03HAmountType(request.FromDate, request.ToDate, request.CurrencyDecimalDigits);

                if (request.LoadOptions.Contains("FixedAssetB03H30K")) //Báo cáo tăng giảm tài sản nhà nước 
                    response.FixedAssetB03H30K = ReportListDao.GetFixedAssetB03H30K(request.FromDate, request.ToDate, request.CurrencyDecimalDigits);

                if (request.LoadOptions.Contains("FixedAsset30KPart2")) //Báo cáo kiểm kê tscđ trên 30k USD mẫu mới
                    response.FixedAsset30KPart2 = ReportListDao.GetFixedAsset30KPart2(request.FromDate, request.ToDate, request.CurrencyDecimalDigits);

                if (request.LoadOptions.Contains("FixedAssetFAB01Car")) //Báo cáo giảm ô tô 
                    response.FixedAssetFAInventoryCar = ReportListDao.GetFixedAssetFAB01Car(request.FromDate, request.ToDate, request.CurrencyDecimalDigits);

                if (request.LoadOptions.Contains("FixedAssetFAB01House")) //Báo cáo giảm nhà cửa trụ sở làm việc
                    response.FixedAssetFAInventoryHouse = ReportListDao.GetFixedAssetFAB01House(request.FromDate, request.ToDate, request.CurrencyDecimalDigits);

                if (request.LoadOptions.Contains("FixedAssetFAB0130KPart2")) // Báo cáo giảm tscđ có nguyên giá trên 30k
                    response.FixedAsset30KPart2 = ReportListDao.GetFixedAssetFAB0130KPart2(request.FromDate, request.ToDate, request.CurrencyDecimalDigits);

                //if (request.LoadOptions.Contains("FixedAssetCard")) // Báo cáo thẻ TSCĐ 
                //    response.FixedAssetCards = ReportListDao.GetFixedAssetCard(request.StrFixedAssetId, request.CurrencyDecimalDigits);

                if (request.LoadOptions.Contains("FixedAssetCards")) // Báo cáo thẻ TSCĐ 
                    response.FixedAssetCard = ReportListDao.GetFixedAssetCards(request.StrFixedAssetId, request.CurrencyDecimalDigits);

                if (request.LoadOptions.Contains("B01H")) //Báo cáo cân đối tài khoản
                    response.B01H = ReportListDao.GetB01HWithStoreProdure(request.StoreProdure, request.FromDate, request.ToDate, request.CurrencyCode, request.AmounType).ToList();
                if (request.LoadOptions.Contains("B01BCTC")) //Báo cáo tình hình tài chính
                    response.B01BCTC = ReportListDao.GetB01BCTC(request.StoreProdure, request.FromDate, request.ToDate, request.CurrencyCode, request.AmounType).ToList();
                if (request.LoadOptions.Contains("B03bBCTC")) //Báo cáo lưu chuyển tiền tệ
                    response.B03bBCTC = ReportListDao.GetB03bBCTC(request.StoreProdure, request.FromDate, request.ToDate, request.CurrencyCode, request.AmounType).ToList();
                if (request.LoadOptions.Contains("CashReportS11H")) //Báo cáo sổ chi tiền mặt/tiền gửi
                    response.CashReportList = ReportListDao.CashRepportListGeneal(request.StoreProdure, request.FromDate, request.ToDate, request.AccountNumber, request.CurrencyCode, request.AmounType, request.IsBank, request.BankId).ToList();
                if (request.LoadOptions.Contains("CashReportS11AH")) //Báo cáo sổ chi tiền mặt/tiền gửi
                    response.CashReportList = ReportListDao.CashRepportListDetail(request.StoreProdure, request.FromDate, request.ToDate, request.AccountNumber, request.CorrespondingAccountNumber, request.CurrencyCode, request.AmounType, request.IsBank, request.BankId).ToList();
                if (request.LoadOptions.Contains("CashReportS12H")) //Báo cáo sổ chi tiền mặt/tiền gửi
                    response.CashReportList = ReportListDao.CashRepportListGeneal(request.StoreProdure, request.FromDate, request.ToDate, request.AccountNumber, request.CurrencyCode, request.AmounType, request.IsBank, request.BankId).ToList();
                if (request.LoadOptions.Contains("CashReportS12AH")) //Báo cáo sổ chi tiền mặt/tiền gửi
                    response.CashReportList = ReportListDao.CashRepportListDetail(request.StoreProdure, request.FromDate, request.ToDate, request.AccountNumber, request.CorrespondingAccountNumber, request.CurrencyCode, request.AmounType, request.IsBank, request.BankId).ToList();
                if (request.LoadOptions.Contains("S03BH")) //Báo cáo sổ cái tài khoản
                    response.S03BHList = ReportListDao.GetS03BHWithStoreProdure(request.StoreProdure, request.FromDate, request.ToDate, request.AccountNumber, request.CorrespondingAccountNumber, request.CurrencyCode, request.AmounType).ToList();
                if (request.LoadOptions.Contains("C30BB")) //Báo cáo sổ chi tiền mặt/tiền gửi
                    response.C30BBList = ReportListDao.GetReportC30BB(request.Year, request.RefTypeId).ToList();
                if (request.LoadOptions.Contains("C30BBItem")) //Báo cáo sổ chi tiền mặt/tiền gửi
                    response.C30BBList = ReportListDao.GetReportC30BBItem(request.Year, request.RefTypeId).ToList();
                if (request.LoadOptions.Contains("C30BB501")) //Báo cáo sổ chi tiền mặt/tiền gửi
                    response.C30BB501List = ReportListDao.GetReportC30BB501(request.StoreProdure, request.RefIdList).ToList();
                //C30BBItem
                if (request.LoadOptions.Contains("S33H")) //Báo cáo sổ chi tiết tài khoản
                    response.S33H = ReportListDao.GetS33HWithStoreProdure(request.StoreProdure, request.AccountNumber, request.FromDate, request.ToDate, request.CurrencyCode, request.BudgetGroupCode, request.FixedAssetCode, request.DepartmentCode, request.AmounType, request.WhereClause, request.SelectedField, request.SelectedAllValueField).ToList();
                if (request.LoadOptions.Contains("S05H"))
                    response.S05H = ReportListDao.GetS05HWithStoreProdure(request.StoreProdure, request.FromDate, request.ToDate, request.CurrencyCode, request.AmounType).ToList();
                if (request.LoadOptions.Contains("AdvancePayment"))
                    response.AdvancePayment = ReportListDao.GetAdvancePaymentHWithStoreProdure(request.StoreProdure, request.FromDate, request.ToDate, request.CurrencyCode, request.AmounType, request.Year).ToList();//AnhNT: request.Year = accountType
                if (request.LoadOptions.Contains("B03BNG")) //Báo cáo tạm ứng
                    response.B03BNGs = ReportListDao.GetReportB03BNGs((short)request.AmounType, request.CurrencyCode, DateTime.Parse(request.FromDate), DateTime.Parse(request.ToDate)).ToList();
                if (request.LoadOptions.Contains("F03BNG")) //Báo cáo Quyết toán nguồn kinh phí TT146
                    response.F03BNGs = ReportListDao.GetReportF03BNGs(request.StoreProdure, (short)request.AmounType, request.CurrencyCode, DateTime.Parse(request.FromDate), DateTime.Parse(request.ToDate)).ToList();
                if (request.LoadOptions.Contains("F331BNG")) //Báo cáo Quyết toán nguồn kinh phí Quỹ tạm giữ
                    response.F331BNGs = ReportListDao.GetReportF331BNGs(request.StoreProdure, (short)request.AmounType, request.AccountNumber, request.CurrencyCode, DateTime.Parse(request.FromDate), DateTime.Parse(request.ToDate)).ToList();
                if (request.LoadOptions.Contains("B09BNG"))
                //Báo cáo thu, chi quỹ tạm giữ nsnn từ nguồn 70% số thu phí, lệ phí lãnh sự
                {
                    if (DateTime.Parse(request.ToDate).Month > 0 && DateTime.Parse(request.ToDate).Month <= 3)
                        response.B09BNGs = ReportListDao.GetReportB09BNGs(request.StoreProdure, (short)request.AmounType, request.CurrencyCode, DateTime.Parse(request.FromDate), DateTime.Parse(request.ToDate)).Where(x => x.QuarterB09 == 1).ToList();
                    if (DateTime.Parse(request.ToDate).Month > 3 && DateTime.Parse(request.ToDate).Month <= 6)
                        response.B09BNGs = ReportListDao.GetReportB09BNGs(request.StoreProdure, (short)request.AmounType, request.CurrencyCode, DateTime.Parse(request.FromDate), DateTime.Parse(request.ToDate)).Where(x => x.QuarterB09 == 2).ToList();
                    if (DateTime.Parse(request.ToDate).Month > 6 && DateTime.Parse(request.ToDate).Month <= 9)
                        response.B09BNGs = ReportListDao.GetReportB09BNGs(request.StoreProdure, (short)request.AmounType, request.CurrencyCode, DateTime.Parse(request.FromDate), DateTime.Parse(request.ToDate)).Where(x => x.QuarterB09 == 3).ToList();
                    if (DateTime.Parse(request.ToDate).Month > 9 && DateTime.Parse(request.ToDate).Month <= 12)
                        response.B09BNGs = ReportListDao.GetReportB09BNGs(request.StoreProdure, (short)request.AmounType, request.CurrencyCode, DateTime.Parse(request.FromDate), DateTime.Parse(request.ToDate)).Where(x => x.QuarterB09 == 4).ToList();
                }
                if (request.LoadOptions.Contains("FinacialB01BCQT"))
                    response.FinacialB01BCQTs = ReportListDao.GetReportB01BCQTs(request.StoreProdure, (short)request.AmounType, request.CurrencyCode, DateTime.Parse(request.FromDate), DateTime.Parse(request.ToDate));

                if (request.LoadOptions.Contains("EstimateDetailStatement")) //thuyết mih dự toán
                {

                    if (request.IsCompanyProfile)
                    {
                        response.EstimateDetailStatement = new EstimateDetailStatementEntity
                        {
                            Employees = ReportListDao.GetEmployeeForEstimateReport(true),
                            EmployeeOthers = EmployeeLeasingDao.GetEmployeeLeasingsForEstimateReport(false, true, true),
                            EmployeeLeasings = EmployeeLeasingDao.GetEmployeeLeasingsForEstimateReport(true, true, true),
                            FixedAssets = ReportListDao.GetFixedAssetForEstimateReport(),
                            Buildings = BuildingDao.GetBuildingsForEstimateReport(true),
                            EstimateDetailStatementPartBs = EstimateDetailStatementPartBDao.GetEstimateDetailStatementPartBs(),
                            Mutuals = MutualDao.GetMutualsForEstimate(true),
                            FixedAssetCars = FixedAssetDao.GetFixedAssetsByFixedAssetTMDT(request.YearOfEstimate)
                        };
                    }
                    else
                    {
                        response.EstimateDetailStatement = new EstimateDetailStatementEntity
                        {
                            Employees = ReportListDao.GetEmployeeForEstimateReport(false),
                            EmployeeOthers = EmployeeLeasingDao.GetEmployeeLeasingsForEstimateReport(false, true, false),
                            EmployeeLeasings = EmployeeLeasingDao.GetEmployeeLeasingsForEstimateReport(true, true, false),
                            FixedAssets = ReportListDao.GetFixedAssetForEstimateReport(),
                            Buildings = BuildingDao.GetBuildingsForEstimateReport(false),
                            EstimateDetailStatementFixedAssets = EstimateDetailStatementFixedAssetDao.GetEstimateDetailStatementFixedAssets(),
                            EstimateDetailStatementPartBs = EstimateDetailStatementPartBDao.GetEstimateDetailStatementPartBs(),
                            Mutuals = MutualDao.GetMutualsForEstimate(true),
                            FixedAssetCars = FixedAssetDao.GetFixedAssetsByFixedAssetTMDT(request.YearOfEstimate)
                        };
                    }
                }
                if (request.LoadOptions.Contains("FundStuation")) //báo cáo tổng hợp tình hình kinh phí
                    response.FundStuations = ReportListDao.GetFundStuations(request.YearOfEstimate);

                if (request.LoadOptions.Contains("F03BCT"))
                {
                    var lastYear = new DateTime(DateTime.Parse(request.FromDate).Year - 1, 12, 31);
                    var periodDate = new DateTime(DateTime.Parse(request.FromDate).Year, 01, 01);

                    response.ReportF03BCT = ReportListDao.GetReportF03BCTs(request.StoreProdure, (short)request.AmounType, request.CurrencyCode, DateTime.Parse(request.FromDate), DateTime.Parse(request.ToDate), lastYear, periodDate, 0);
                }

                if (request.LoadOptions.Contains("B01CII"))
                {
                    int year = DateTime.Parse(request.FromDate).Year;
                    response.ReportB01CII = ReportListDao.GetReportB01CIIs(request.StoreProdure, DateTime.Parse(request.FromDate), DateTime.Parse(request.ToDate), year);
                }

                if (request.LoadOptions.Contains("B01CII01"))
                {
                    int year = DateTime.Parse(request.FromDate).Year;
                    response.ReportB01CII01 = ReportListDao.GetReportB01CII01s(request.StoreProdure, DateTime.Parse(request.FromDate), DateTime.Parse(request.ToDate), year);
                }

                if (request.LoadOptions.Contains("B01CI"))
                {
                    response.ReportB01CI = ReportListDao.GetReportB01CIs(request.StoreProdure, DateTime.Parse(request.FromDate), DateTime.Parse(request.ToDate));
                }

                if(request.LoadOptions.Contains("S104H"))
                {
                    response.ReportS104H = ReportListDao.GetReportS104Hs(request.StoreProdure, DateTime.Parse(request.FromDate), DateTime.Parse(request.ToDate), request.CurrencyCode, request.AmounType);
                }

                if (request.LoadOptions.Contains("S26H"))
                {
                    response.FixedAssetS26H = ReportListDao.GetFixedAssetS26H(request.StoreProdure, DateTime.Parse(request.FromDate), DateTime.Parse(request.ToDate), request.CurrencyCode, request.AmounType, request.DepartmentCode, Convert.ToInt32(request.WhereClause), request.Option);
                }

                if (request.LoadOptions.Contains("S24H"))
                {
                    response.FixedAssetS24H = ReportListDao.GetFixedAssetS24H(request.StoreProdure, request.CurrencyCode, request.AmounType, request.FromDate, request.ToDate, request.DepartmentCode, request.FaCategoryCode, request.StrFixedAssetId);
                }

                if (request.LoadOptions.Contains("ReportActivityB02"))
                {
                    response.ReportActivityB02 = ReportListDao.GetReportActivityB02(request.StoreProdure, request.AmounType, request.CurrencyCode, DateTime.Parse(request.FromDate), DateTime.Parse(request.ToDate));
                }

                if(request.LoadOptions.Contains("B04BCTC"))
                {
                    response.B04BCTC = ReportListDao.GetReportB04BCTC(request.StoreProdure, request.AmounType, request.CurrencyCode, DateTime.Parse(request.FromDate), DateTime.Parse(request.ToDate));
                }

                if(request.LoadOptions.Contains("LedgerAccountingS104H"))
                {
                    response.LedgerAccountingS104H = ReportListDao.LedgerAccountingS104H(request.StoreProdure, request.FromDate, request.ToDate, request.WhereClause, request.CurrencyCode, request.AmounType);
                }
            }
            return response;
        }

        public ReportListResponse SetReportLists(ReportListRequest request)
        {
            var response = new ReportListResponse();
            try
            {

                if (request.Action == PersistType.Update)
                {
                    response.Message = ReportListDao.UpdateReport(request.ReportList);
                }
                return response;

            }
            catch (Exception ex)
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = ex.Message;
                return response;
            }
        }
    }

}
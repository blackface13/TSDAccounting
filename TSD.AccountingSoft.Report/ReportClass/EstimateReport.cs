/***********************************************************************
 * <copyright file="EstimateReport.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 19 May 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 10/9/2014    LinhMC               Sửa lại toàn bộ method check điều kiện nếu nạp lại dữ liệu thì ko show form param
 * ************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Report.ParameterReportForm;
using TSD.AccountingSoft.Session;
using TSD.AccountingSoft.Model;
using TSD.AccountingSoft.Model.BusinessObjects.Report.Estimate;
using DevExpress.XtraEditors;
using RSSHelper;

namespace TSD.AccountingSoft.Report.ReportClass
{
    
    /// <summary>
    /// EstimateReport
    /// </summary>
    /// 
    public class EstimateReport : BaseReport
    {
        private readonly GlobalVariable _globalVariable;
        private CompanyProfileModel _companyProfile;
        /// <summary>
        /// Initializes a new instance of the <see cref="EstimateReport"/> class.
        /// </summary>
        public EstimateReport()
        {
            Model = new TSD.AccountingSoft.Model.Model();
            _globalVariable = new GlobalVariable();
        }

        /// <summary>
        /// Gets the report general receipt estimate.
        /// </summary>
        /// <param name="frmParent">The FRM parent.</param>
        /// <param name="commonVariable">The common variable.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<GeneralReceiptEstimateModel> GetReportGeneralReceiptEstimate(XtraForm frmParent, GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            List<GeneralReceiptEstimateModel> generalReceiptEstimates = null;
            if (!oRsTool.IsRefresh)
            {
                using (var frmXtraGeneralReceiptEstimate = new FrmXtraGeneralReceiptEstimate())
                {
                    frmXtraGeneralReceiptEstimate.ReporDate = _globalVariable.PostedDate;
                    if (frmXtraGeneralReceiptEstimate.ShowDialog() == DialogResult.OK)
                    {
                        var yearOfEstimate = frmXtraGeneralReceiptEstimate.YearOfEstimate;
                        var currencyCode = frmXtraGeneralReceiptEstimate.CurrencyCode;
                        var reportDate = frmXtraGeneralReceiptEstimate.ReporDate;
                        if (!oRsTool.Parameters.ContainsKey("YearOfEstimate"))
                            oRsTool.Parameters.Add("YearOfEstimate", yearOfEstimate);
                        if (!oRsTool.Parameters.ContainsKey("CurrencyCodeUnit"))
                            oRsTool.Parameters.Add("CurrencyCodeUnit", currencyCode);
                        if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                            oRsTool.Parameters.Add("ReportDate", reportDate);
                        if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
                            oRsTool.Parameters.Add("CompanyProvince", _globalVariable.CompanyProvince);

                        generalReceiptEstimates =
                            Model.GetGeneralReceiptEstimate(yearOfEstimate) as List<GeneralReceiptEstimateModel>;
                    }

                }
            }
            else
            {
                var yearOfEstimate = short.Parse(oRsTool.Parameters["YearOfEstimate"].ToString());
                generalReceiptEstimates =
                            Model.GetGeneralReceiptEstimate(yearOfEstimate) as List<GeneralReceiptEstimateModel>;
            }

            return generalReceiptEstimates;
        }

        

        /// <summary>
        /// Gets the report general payment estimate.
        /// </summary>
        /// <param name="frmParent">The FRM parent.</param>
        /// <param name="commonVariable">The common variable.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<GeneralPaymentEstimateModel> GetReportGeneralPaymentEstimate(XtraForm frmParent, GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            List<GeneralPaymentEstimateModel> generalPaymentEstimates = null;
            if (!oRsTool.IsRefresh)
            {
                using (var frmXtraGeneralPaymentEstimate = new FrmXtraGeneralPaymentEstimate())
                {
                    frmXtraGeneralPaymentEstimate.ReporDate = _globalVariable.PostedDate;
                    if (frmXtraGeneralPaymentEstimate.ShowDialog() == DialogResult.OK)
                    {
                        var yearOfEstimate = frmXtraGeneralPaymentEstimate.YearOfEstimate;
                        var currencyCode = frmXtraGeneralPaymentEstimate.CurrencyCode;
                        var reportDate = frmXtraGeneralPaymentEstimate.ReporDate;

                        if (!oRsTool.Parameters.ContainsKey("YearOfEstimate"))
                            oRsTool.Parameters.Add("YearOfEstimate", yearOfEstimate);
                        if (!oRsTool.Parameters.ContainsKey("CurrencyCodeUnit"))
                            oRsTool.Parameters.Add("CurrencyCodeUnit", currencyCode);
                        if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                            oRsTool.Parameters.Add("ReportDate", reportDate);
                        if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
                            oRsTool.Parameters.Add("CompanyProvince", _globalVariable.CompanyProvince);

                        generalPaymentEstimates =
                            Model.GetGeneralPaymentEstimate(yearOfEstimate) as List<GeneralPaymentEstimateModel>;
                    }
                }
            }
            else
            {
                var yearOfEstimate = short.Parse(oRsTool.Parameters["YearOfEstimate"].ToString());
                generalPaymentEstimates =
                             Model.GetGeneralPaymentEstimate(yearOfEstimate) as List<GeneralPaymentEstimateModel>;
            }
            return generalPaymentEstimates;
        }

        /// <summary>
        /// Gets the report general estimate.
        /// </summary>
        /// <param name="frmParent">The FRM parent.</param>
        /// <param name="commonVariable">The common variable.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<GeneralEstimateModel> GetReportGeneralEstimate(XtraForm frmParent, GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            List<GeneralEstimateModel> generalEstimates = null;
            if (!oRsTool.IsRefresh)
            {
                using (var frmXtraGeneralEstimate = new FrmXtraGeneralEstimate())
                {
                    frmXtraGeneralEstimate.ReporDate = _globalVariable.PostedDate;
                    if (frmXtraGeneralEstimate.ShowDialog() == DialogResult.OK)
                    {
                        var yearOfEstimate = frmXtraGeneralEstimate.YearOfEstimate;
                        var currencyCode = frmXtraGeneralEstimate.CurrencyCode;
                        var reportDate = frmXtraGeneralEstimate.ReporDate;

                        if (!oRsTool.Parameters.ContainsKey("YearOfEstimate"))
                            oRsTool.Parameters.Add("YearOfEstimate", yearOfEstimate);
                        if (!oRsTool.Parameters.ContainsKey("CurrencyCodeUnit"))
                            oRsTool.Parameters.Add("CurrencyCodeUnit", currencyCode);
                        if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                            oRsTool.Parameters.Add("ReportDate", reportDate);
                        if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
                            oRsTool.Parameters.Add("CompanyProvince", _globalVariable.CompanyProvince);

                        generalEstimates = Model.GetGeneralEstimate(yearOfEstimate) as List<GeneralEstimateModel>;
                    }
                }
            }
            else
            {
                var yearOfEstimate = short.Parse(oRsTool.Parameters["YearOfEstimate"].ToString());
                generalEstimates = Model.GetGeneralEstimate(yearOfEstimate) as List<GeneralEstimateModel>;
            }
            return generalEstimates;
        }

        /// <summary>
        /// Gets the report general payment detail estimate.
        /// </summary>
        /// <param name="frmParent">The FRM parent.</param>
        /// <param name="commonVariable">The common variable.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<GeneralPaymentDetailEstimateModel> GetReportGeneralPaymentDetailEstimate(XtraForm frmParent, GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            List<GeneralPaymentDetailEstimateModel> generalPaymentDetailEstimates = null;
            if (!oRsTool.IsRefresh)
            {
                using (var frmXtraGeneralEstimate = new FrmXtraGeneralPaymentDetailEstimate())
                {
                    frmXtraGeneralEstimate.ReporDate = _globalVariable.PostedDate;
                    if (frmXtraGeneralEstimate.ShowDialog() == DialogResult.OK)
                    {
                        var yearOfEstimate = frmXtraGeneralEstimate.YearOfEstimate;
                        var currencyCode = frmXtraGeneralEstimate.CurrencyCode;
                        var reportDate = frmXtraGeneralEstimate.ReporDate;

                        if (!oRsTool.Parameters.ContainsKey("YearOfEstimate"))
                            oRsTool.Parameters.Add("YearOfEstimate", yearOfEstimate);
                        if (!oRsTool.Parameters.ContainsKey("CurrencyCodeUnit"))
                            oRsTool.Parameters.Add("CurrencyCodeUnit", currencyCode);
                        if (!oRsTool.Parameters.ContainsKey("ReportDate"))
                            oRsTool.Parameters.Add("ReportDate", reportDate);
                        if (!oRsTool.Parameters.ContainsKey("CompanyProvince"))
                            oRsTool.Parameters.Add("CompanyProvince", _globalVariable.CompanyProvince);
                        if (!oRsTool.Parameters.ContainsKey("BaseOfSalary"))
                            oRsTool.Parameters.Add("BaseOfSalary", _globalVariable.BaseOfSalary);

                        generalPaymentDetailEstimates =
                            Model.GetGeneralPaymentDetailEstimate(yearOfEstimate) as
                                List<GeneralPaymentDetailEstimateModel>;
                    }
                }
            }
            else
            {
                var yearOfEstimate = short.Parse(oRsTool.Parameters["YearOfEstimate"].ToString());
                generalPaymentDetailEstimates =
                            Model.GetGeneralPaymentDetailEstimate(yearOfEstimate) as
                                List<GeneralPaymentDetailEstimateModel>;
            }
            return generalPaymentDetailEstimates;
        }

        /// <summary>
        /// Gets the report estimate detail statement.
        /// </summary>
        /// <param name="frmParent">The FRM parent.</param>
        /// <param name="commonVariable">The common variable.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public List<EstimateDetailStatementModel> GetReportEstimateDetailStatement(XtraForm frmParent, GlobalVariable commonVariable,
            ReportSharpHelper oRsTool)
        {
            var estimateDetailStatementModel = new List<EstimateDetailStatementModel>();
            if (!oRsTool.IsRefresh)
            {
                using (var frmXtraEstimateDetailStatement = new FrmXtraEstimateDetailStatement())
                {
                    frmXtraEstimateDetailStatement.ReporDate = _globalVariable.PostedDate;
                    if (frmXtraEstimateDetailStatement.ShowDialog() == DialogResult.OK)
                    {
                        
                        var yearOfEstimate = frmXtraEstimateDetailStatement.YearOfEstimate;
                        var generalDescription = frmXtraEstimateDetailStatement.GeneralDescription;
                        var employeeLeasingDescription = frmXtraEstimateDetailStatement.EmployeeLeasingDescription;
                        var employeeContractDescription = frmXtraEstimateDetailStatement.EmployeeContractDescription;
                        var buildingOfFixedAssetDescription = frmXtraEstimateDetailStatement.BuildingOfFixedAssetDescription;
                        var descriptionForBuilding = frmXtraEstimateDetailStatement.DescriptionForBuilding;
                        var carDescription = frmXtraEstimateDetailStatement.CarDescription;
                        var inventoryDescription = frmXtraEstimateDetailStatement.InventoryDescription;
                        var partC = frmXtraEstimateDetailStatement.PartC;
                        var partC1 = frmXtraEstimateDetailStatement.PartC1;
                        var reportDate = frmXtraEstimateDetailStatement.ReporDate;

                        

                        oRsTool.Parameters.Add("YearOfEstimate", yearOfEstimate);
                        oRsTool.Parameters.Add("PartC", partC);
                        oRsTool.Parameters.Add("PartC1", partC1);
                        oRsTool.Parameters.Add("GeneralDescription", generalDescription);
                        oRsTool.Parameters.Add("EmployeeLeasingDescription", employeeLeasingDescription);
                        oRsTool.Parameters.Add("EmployeeContractDescription", employeeContractDescription);
                        oRsTool.Parameters.Add("BuildingOfFixedAssetDescription", buildingOfFixedAssetDescription);
                        oRsTool.Parameters.Add("DescriptionForBuilding", descriptionForBuilding);
                        oRsTool.Parameters.Add("CarDescription", carDescription);
                        oRsTool.Parameters.Add("InventoryDescription", inventoryDescription);
                        oRsTool.Parameters.Add("ReportDate", reportDate);
                        oRsTool.Parameters.Add("CompanyProvince", _globalVariable.CompanyProvince);

                        estimateDetailStatementModel.Add(Model.GetEstimateDetailStatement(yearOfEstimate, false));
                    }
                    else
                        estimateDetailStatementModel = null;
                }
            }
            else
            {
                var yearOfEstimate = short.Parse(oRsTool.Parameters["YearOfEstimate"].ToString());
                estimateDetailStatementModel.Add(Model.GetEstimateDetailStatement(yearOfEstimate, false));
            }
            return estimateDetailStatementModel;
        }

        /// <summary>
        /// Gets the report estimate detail statement.
        /// </summary>
        /// <param name="frmParent">The FRM parent.</param>
        /// <param name="commonVariable">The common variable.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public List<EstimateDetailStatementModel> GetReportCompanyProfiles(XtraForm frmParent, GlobalVariable commonVariable,
            ReportSharpHelper oRsTool)
        {
            var estimateDetailStatementModel = new List<EstimateDetailStatementModel>();
            if (!oRsTool.IsRefresh)
            {
                using (var frmXtraEstimateDetailStatement = new FrmXtraCompanyProfiles())
                {
                    frmXtraEstimateDetailStatement.ReporDate = _globalVariable.PostedDate;
                    if (frmXtraEstimateDetailStatement.ShowDialog() == DialogResult.OK)
                    {
                        _companyProfile = Model.GetCompanyProfile(1);
                        short yearOfEstimate = (short) DateTime.Parse(frmXtraEstimateDetailStatement.ToDate).Year;
                        int year1 = yearOfEstimate + 1;
                        
                        //var generalDescription = frmXtraEstimateDetailStatement.GeneralDescription;
                        //var employeeLeasingDescription = frmXtraEstimateDetailStatement.EmployeeLeasingDescription;
                        //var employeeContractDescription = frmXtraEstimateDetailStatement.EmployeeContractDescription;
                        //var buildingOfFixedAssetDescription =frmXtraEstimateDetailStatement.BuildingOfFixedAssetDescription;
                        //var descriptionForBuilding = frmXtraEstimateDetailStatement.DescriptionForBuilding;
                        //var carDescription = frmXtraEstimateDetailStatement.CarDescription;
                        //var inventoryDescription = frmXtraEstimateDetailStatement.InventoryDescription;
                        var partC = frmXtraEstimateDetailStatement.PartC;
                        var reportDate = frmXtraEstimateDetailStatement.ReporDate;

                        if (!oRsTool.Parameters.ContainsKey("FromDate"))
                            oRsTool.Parameters.Add("FromDate", frmXtraEstimateDetailStatement.FromDate);
                        if (!oRsTool.Parameters.ContainsKey("ToDate"))
                            oRsTool.Parameters.Add("ToDate", frmXtraEstimateDetailStatement.ToDate);

                        string NativeCategory = "";
                        string ManagementArea = "";
                        switch (_companyProfile.NativeCategory)
                        {
                            case 0:
                                NativeCategory = "Thuận lợi";
                                break;
                            case 1:
                                NativeCategory = "Khá";
                                break;
                            case 2:
                                NativeCategory = "Trung bình";
                                break;
                            case 3:
                                NativeCategory = "Khó khăn";
                                break;
                            case 4:
                                NativeCategory = "Đặc biệt khó khăn";
                                break;
                        }
                       
                        switch (_companyProfile.ManagementArea)
                        {
                            case 0:
                                ManagementArea = "Vụ Đông Bắc Á";
                                break;
                            case 1:
                                ManagementArea = "Vụ Đông Nam Á - Nam Á - Nam TBD";
                                break;
                            case 2:
                                ManagementArea = "Vụ Châu Âu";
                                break;
                            case 3:
                                ManagementArea = "Vụ Châu Mỹ";
                                break;
                            case 4:
                                ManagementArea = "Vụ Tây Á - Châu Phi";
                                break;
                            case 5:
                                ManagementArea = "Vụ ASEAN";
                                break;
                        }

                        var profileAmbassadorName = "1. Thủ trưởng CQĐD: " + _companyProfile.ProfileAmbassadorName;
                        var profileAccountantName = "Kế toán: " + _companyProfile.ProfileAccountantName;
                        var employeePayrollsTotal = "2. Tổng số biên chế: " + _companyProfile.EmployeePayrollsTotal;
                        var employeeNumberOfOfficers = "Trong đó số CBNV: " + _companyProfile.EmployeeNumberOfOfficers;
                        var employeeNumberOfWifeOrHusband = "Số PN/PQ: " + _companyProfile.EmployeeNumberOfWifeOrHusband;
                        var assetNumberOfCars = "3. Tổng số xe ô tô: " + _companyProfile.AssetNumberOfCars;
                        var nativeCategory = "4. Loại địa bàn: " + NativeCategory;
                        var managementArea = "Khu vực quản lý: " + ManagementArea;
                        var profileWorkingArea = "5. Kiêm nhiệm: " + _companyProfile.ProfileWorkingArea;
                        var profileMinimumSalary = "6. Sinh hoạt phí tối thiểu: "+_companyProfile.ProfileMinimumSalary.ToString("C" + _globalVariable.CurrencyDecimalDigits, CultureInfo.CurrentCulture);
                        var profileCurrencyCodeFinalization = "7. Loại tiền quyết toán: " + _companyProfile.ProfileCurrencyCodeFinalization;
                        var otherNote = " " + partC;
                        

                        oRsTool.Parameters.Add("YearOfEstimate", yearOfEstimate);
                        oRsTool.Parameters.Add("PartC", "");
                        oRsTool.Parameters.Add("PartC1", "");
                        oRsTool.Parameters.Add("GeneralDescription", "1. Danh sách CBNV:");
                        oRsTool.Parameters.Add("EmployeeLeasingDescription", "2. Danh sách cán bộ nhân viên (không bao gồm phu nhân, phu quân) của các cơ quan Việt Nam ở nước ngoài bên cạnh CQĐD được hưởng Trợ cấp ngành của Bộ Ngoại giao: Bộ phận Quân vụ, Khoa học công nghê, Bộ Công an, Phân xã Thông tấn xã Việt Nam, Cơ quan thường trú của Báo Nhân dân, Đài tiếng nói Việt Nam, Đài truyền hình Việt Nam, Trung tâm văn hoá Việt Nam ở nước ngoài:");
                        oRsTool.Parameters.Add("EmployeeContractDescription", " - Chi tiết công việc người địa phương hoặc lao động hợp đồng đang đảm nhiệm, mức lương đang hưởng/1 tháng (quy USD), thời điểm bắt đầu thuê, thời hạn của hợp đồng. Bảo hiểm và trang phục/1 năm (nếu có). \r\n - CQĐD có kiến nghị ra hạn hoặc thuê mới người địa phương trong năm " +yearOfEstimate +  " đề nghị kê chi tiết.");
                        oRsTool.Parameters.Add("BuildingOfFixedAssetDescription", "3.1 - Nhà sở hữu của ta, nhà hỗ tương : Báo cáo chi tiết diện tích, số phòng và mục đích sử dụng.");
                        oRsTool.Parameters.Add("DescriptionForBuilding", "3.2- Nhà thuê: Báo cáo chi tiết địa chỉ, diện tích, số phòng, giá tiền thuê (USD), thời hạn hợp đồng từng căn hộ (Ngày ký, ngày hết hạn hợp đồng). CQĐD kiến nghị gia hạn hoặc thuê đổi trong năm " + yearOfEstimate + " , " + year1 + "  nếu hết hạn hợp đồng thuê.");
                        oRsTool.Parameters.Add("CarDescription", "Bộ phận Ngoại giao: \r\n - 01 xe Cadillac, 4 chỗ, mua năm 2009, nguyên giá 53.308,00 USD (xe số 1) \r\n ...");
                        oRsTool.Parameters.Add("InventoryDescription", "");
                        oRsTool.Parameters.Add("ReportDate", reportDate);
                        oRsTool.Parameters.Add("CompanyProvince", _globalVariable.CompanyProvince);


                        oRsTool.Parameters.Add("ProfileAmbassadorName", profileAmbassadorName);
                        oRsTool.Parameters.Add("ProfileAccountantName", profileAccountantName);
                        oRsTool.Parameters.Add("EmployeePayrollsTotal", employeePayrollsTotal);
                        oRsTool.Parameters.Add("EmployeeNumberOfOfficers", employeeNumberOfOfficers);
                        oRsTool.Parameters.Add("EmployeeNumberOfWifeOrHusband", employeeNumberOfWifeOrHusband);
                        oRsTool.Parameters.Add("AssetNumberOfCars", assetNumberOfCars);
                        oRsTool.Parameters.Add("NativeCategory", nativeCategory);
                        oRsTool.Parameters.Add("ManagementArea",managementArea);
                        oRsTool.Parameters.Add("ProfileWorkingArea", profileWorkingArea);
                        oRsTool.Parameters.Add("ProfileMinimumSalary", profileMinimumSalary);
                        oRsTool.Parameters.Add("OtherNote", otherNote);
                        oRsTool.Parameters.Add("ProfileCurrencyCodeFinalization", profileCurrencyCodeFinalization);

                        estimateDetailStatementModel.Add(new EstimateDetailStatementModel
                        
                                    {
                                        Employees = Model.GetEstimateDetailStatement(yearOfEstimate,true).Employees.Where(
                                        x => x.FinishedDate >= DateTime.Parse(frmXtraEstimateDetailStatement.FromDate) || x.Description == ".").ToList(),
                                        Buildings = Model.GetEstimateDetailStatement(yearOfEstimate, true).Buildings.Where(
                                        x => x.EndDate >= DateTime.Parse(frmXtraEstimateDetailStatement.FromDate) || x.Description == ".").ToList(),
                                        EmployeeLeasings = Model.GetEstimateDetailStatement(yearOfEstimate, true).EmployeeLeasings.Where(
                                        x => x.EndDate >= DateTime.Parse(frmXtraEstimateDetailStatement.FromDate) || x.Description == ".").ToList(),
                                        EmployeeOthers = Model.GetEstimateDetailStatement(yearOfEstimate, true).EmployeeOthers.Where(
                                        x => x.EndDate >= DateTime.Parse(frmXtraEstimateDetailStatement.FromDate)).ToList(),
                                        EstimateDetailStatementPartBs = Model.GetEstimateDetailStatement(yearOfEstimate, true).EstimateDetailStatementPartBs,
                                        FixedAssetCars = Model.GetEstimateDetailStatement(yearOfEstimate, true).FixedAssetCars.Where(
                                        x => x.PurchasedDate <= DateTime.Parse(frmXtraEstimateDetailStatement.ToDate)).ToList(),
                                        FixedAssets = Model.GetEstimateDetailStatement(yearOfEstimate, true).FixedAssets.Where(
                                        x => x.PurchasedDate <= DateTime.Parse(frmXtraEstimateDetailStatement.ToDate)).ToList(),
                                        Mutuals = Model.GetEstimateDetailStatement(yearOfEstimate, true).Mutuals.Where(
                                        x => x.UseDate <= DateTime.Parse(frmXtraEstimateDetailStatement.ToDate)).ToList(),
                                    });
                        float countEmployee = 0;
                        float subsitenceFee = 0;
                        decimal insurancePrice = 0;
                        decimal salaryPrice = 0;
                        decimal uniformPrice = 0;
                        int oderNumber = 0;
                        foreach (var estimateDetailStatement in estimateDetailStatementModel)
                        {
                            foreach (var employee in estimateDetailStatement.Employees)
                            {
                                if (employee.StartedDate.Year > 1900 && employee.FinishedDate.Year > 1900)
                                {
                                    countEmployee = countEmployee + employee.WomenAllowance;
                                    subsitenceFee = subsitenceFee + employee.SubsitenceFee;
                                    oderNumber = oderNumber + 1;
                                    employee.OrderNumber = oderNumber;
                                }
                                    
                                else
                                {
                                    employee.WomenAllowance =  countEmployee;
                                    employee.SubsitenceFee = subsitenceFee;
                                }
                            }
                            oderNumber = 0;
                            foreach (var employee in estimateDetailStatement.EmployeeLeasings)
                            {
                                if (employee.StartDate.Year > 1900 && employee.EndDate.Year > 1900)
                                {
                                    insurancePrice = insurancePrice + employee.InsurancePrice;
                                    salaryPrice = salaryPrice + employee.SalaryPrice;
                                    uniformPrice = uniformPrice + employee.UniformPrice;
                                    
                                    oderNumber = oderNumber + 1;
                                    employee.OrderNumber = oderNumber;
                                }

                                else
                                {
                                    employee.InsurancePrice = insurancePrice;
                                    employee.SalaryPrice = salaryPrice;
                                    employee.UniformPrice = uniformPrice;
                                }
                            }
                            oderNumber = 0;
                            foreach (var employee in estimateDetailStatement.EmployeeOthers)
                            {
                                if (employee.StartDate.Year > 1900 && employee.EndDate.Year > 1900)
                                {
                                   
                                   
                                    oderNumber = oderNumber + 1;
                                    employee.OrderNumber = oderNumber;
                                }
                            }
                            oderNumber = 0;
                            foreach (var building in estimateDetailStatement.Buildings)
                            {
                                if (building.StartDate.Year > 1900 && building.EndDate.Year > 1900)
                                {
                                    
                                    oderNumber = oderNumber + 1;
                                    building.OrderNumber = oderNumber;
                                }
                            }

                            oderNumber = 0;
                            foreach (var fixedAsset in estimateDetailStatement.FixedAssets)
                            {
                                  
                                    oderNumber = oderNumber + 1;
                                    fixedAsset.OrderNumber = oderNumber;
                            }
                            oderNumber = 0;
                            foreach (var fixedAsset in estimateDetailStatement.FixedAssetCars)
                            {
                                
                                oderNumber = oderNumber + 1;
                                fixedAsset.FixedAssetId = oderNumber;
                            }
                        }
                        
                    }
                    else
                        estimateDetailStatementModel = null;
                }
                //var yearOfEstimate1 = short.Parse(oRsTool.Parameters["YearOfEstimate"].ToString());
                //estimateDetailStatementModel.Add(Model.GetEstimateDetailStatement(yearOfEstimate1, false));
            }
            else
            {
                var yearOfEstimate = short.Parse(oRsTool.Parameters["YearOfEstimate"].ToString());
                estimateDetailStatementModel.Add(Model.GetEstimateDetailStatement(yearOfEstimate, true));
            }

            
            return estimateDetailStatementModel;
        }

        /// <summary>
        /// Gets the report fund stuation.
        /// </summary>
        /// <param name="frmParent">The FRM parent.</param>
        /// <param name="commonVariable">The common variable.</param>
        /// <param name="oRsTool">The o rs tool.</param>
        /// <returns></returns>
        public IList<FundStuationModel> GetReportFundStuation(XtraForm frmParent, GlobalVariable commonVariable, ReportSharpHelper oRsTool)
        {
            List<FundStuationModel> fundStuations = null;
            if (!oRsTool.IsRefresh)
            {
                using (var frnXtraFundStuation = new FrnXtraFundStuation())
                {
                    frnXtraFundStuation.ReporDate = _globalVariable.PostedDate;
                    if (frnXtraFundStuation.ShowDialog() == DialogResult.OK)
                    {
                        var yearOfEstimate = frnXtraFundStuation.YearOfEstimate;
                        var currencyCode = frnXtraFundStuation.CurrencyCode;
                        var reportDate = frnXtraFundStuation.ReporDate;
                        string strApproval= frnXtraFundStuation.Approval;

                        oRsTool.Parameters.Add("YearOfEstimate", yearOfEstimate);
                        oRsTool.Parameters.Add("CurrencyCodeUnit", currencyCode);
                        oRsTool.Parameters.Add("ReportDate", reportDate);
                        oRsTool.Parameters.Add("ParaApproval", strApproval);

                        oRsTool.Parameters.Add("CompanyProvince", _globalVariable.CompanyProvince);
                        fundStuations = Model.GetFundStuations(yearOfEstimate) as List<FundStuationModel>;
                    }
                }
            }
            else
            {
                var yearOfEstimate = short.Parse(oRsTool.Parameters["YearOfEstimate"].ToString());
                fundStuations = Model.GetFundStuations(yearOfEstimate) as List<FundStuationModel>;
            }
            return fundStuations;
        }
    }
}

/***********************************************************************
 * <copyright file="FrmXtraFormDbOption.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 26 March 2014
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
using System.Threading;
using System.Windows.Forms;
using TSD.AccountingSoft.Presenter.Dictionary.AutoNumberList;
using TSD.AccountingSoft.Presenter.Dictionary.CompanyProfile;
using TSD.AccountingSoft.Session;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Presenter.Dictionary.AutoNumber;
using TSD.AccountingSoft.Presenter.Dictionary.DBOption;
using TSD.AccountingSoft.Presenter.Dictionary.RefType;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.Resources;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using TSD.AccountingSoft.View.Dictionary;


namespace TSD.AccountingSoft.WindowsForm.FormSystem
{
    /// <summary>
    /// FrmXtraFormDbOption
    /// </summary>
    public partial class FrmXtraFormDbOption : XtraForm, IDBOptionsView, IBudgetChaptersView, IBudgetCategoriesView, IAutoNumbersView, IRefTypesView, IAutoNumberListsView
    {
        #region Presenters

        private readonly DBOptionsPresenter _dbOptionsPresenter;
        private readonly AutoNumbersPresenter _autoNumbersPresenter;
        private readonly AutoNumberListsPresenter _autoNumberListsPresenter;
        private readonly RefTypesPresenter _refTypesPresenter;

        #endregion

        private RepositoryItemGridLookUpEdit _gridLookUpEditRefTypeId;
        private GridView _gridLookUpEditRefTypeIdView;


        #region View Members

        /// <summary>
        /// Gets or sets the database options.
        /// </summary>
        /// <value>
        /// The database options.
        /// </value>
        public IList<DBOptionModel> DBOptions
        {
            get
            {
                var dbOptions = new List<DBOptionModel>
                {
                    new DBOptionModel { OptionId = "CurrencyDecimalDigits", OptionValue = spinCurrencyDecimalDigits.EditValue.ToString(), ValueType = 1,
                        Description = "Số chữ số thập phân của số tiền", IsSystem = false },
                    new DBOptionModel { OptionId = "ExchangeRateDecimalDigits", OptionValue = spinExchangeRateDecimalDigits.EditValue.ToString(), ValueType = 1,
                        Description = "Số chữ số sau dấu phẩy của tỷ giá", IsSystem = false },
                    new DBOptionModel { OptionId = "NumberDecimalDigits", OptionValue = spinNumberDecimalDigits.EditValue.ToString(), ValueType = 1,
                        Description = "Số chữ số sau dấu phẩy của số lượng", IsSystem = false },
                    new DBOptionModel { OptionId = "PercentDecimalDigits", OptionValue = spinPercentDecimalDigits.EditValue.ToString(), ValueType = 1,
                        Description = "Số chữ số sau dấu phẩy của hệ số, tỉ lệ", IsSystem = false },
                    new DBOptionModel { OptionId = "CurrencyDecimalSeparator", OptionValue = txtCurrencyDecimalSeparator.EditValue.ToString(), ValueType = 0,
                        Description = "Kí tự phân cách hàng nghìn", IsSystem = false },
                    new DBOptionModel { OptionId = "CurrencyGroupSeparator", OptionValue = txtCurrencyGroupSeparator.EditValue.ToString(), ValueType = 0,
                        Description = "Kí tự phân cách phần thập phân", IsSystem = false },
                    new DBOptionModel { OptionId = "NumberNegativePattern", OptionValue = cboNumberNegativePattern.SelectedIndex.ToString(CultureInfo.InvariantCulture), ValueType = 0,
                        Description = "Định dạng số âm của số lượng 0 (n), 1 -n, 2 n-", IsSystem = false },
                    new DBOptionModel { OptionId = "CompanyAccountant", OptionValue = txtCompanyAccountant.Text, ValueType = 0,
                        Description = "Kế toán viên", IsSystem = false },
                    new DBOptionModel { OptionId = "CompanyCashier", OptionValue = txtCompanyCashier.Text, ValueType = 0,
                        Description = "Thủ quỹ", IsSystem = false },
                    new DBOptionModel { OptionId = "CompanyDirector", OptionValue = txtCompanyDirector.Text, ValueType = 0,
                        Description = "Thủ trưởng đơn vị", IsSystem = false },
                    new DBOptionModel { OptionId = "CompanyReportPreparer", OptionValue = txtCompanyReportPreparer.Text, ValueType = 0,
                        Description = "Người lập báo cáo", IsSystem = false },
                    new DBOptionModel { OptionId = "CompanyStoreKeeper", OptionValue = txtCompanyStoreKeeper.Text, ValueType = 0,
                        Description = "Thủ kho", IsSystem = false },
                    new DBOptionModel { OptionId = "CompanyAdrress", OptionValue = txtCompanyAdrress.Text, ValueType = 0,
                        Description = "Địa chỉ đơn vị", IsSystem = false },
                    new DBOptionModel { OptionId = "CompanyCode", OptionValue = txtCompanyCode.Text, ValueType = 0,
                        Description = "Mã số đơn vị", IsSystem = false },
                    new DBOptionModel { OptionId = "CompanyDistrict", OptionValue = txtCompanyDistrict.Text, ValueType = 0,
                        Description = "Quận/huyện mà đơn vị cư trú", IsSystem = false },
                    new DBOptionModel { OptionId = "CompanyName", OptionValue = txtCompanyName.Text, ValueType = 0,
                        Description = "Tên đơn vị", IsSystem = false },
                    new DBOptionModel { OptionId = "CompanyProvince", OptionValue = txtCompanyProvince.Text, ValueType = 0,
                        Description = "Tỉnh thành phố mà đơn vị cư trú", IsSystem = false },
                    new DBOptionModel { OptionId = "CompanyTel", OptionValue = txtCompanyTel.Text, ValueType = 0,
                        Description = "Số điện thoại đơn vị", IsSystem = false },
                    new DBOptionModel { OptionId = "CompanyFax", OptionValue = txtCompanyFax.Text, ValueType = 0,
                        Description = "Số fax", IsSystem = false },
                    new DBOptionModel { OptionId = "CompanyEmail", OptionValue = txtCompanyEmail.Text, ValueType = 0,
                        Description = "Địa chỉ email của đơn vị", IsSystem = false },
                    new DBOptionModel { OptionId = "CompanyWebsite", OptionValue = txtCompanyWebsite.Text, ValueType = 0,
                        Description = "Địa chỉ website của đơn vị", IsSystem = false },
                    new DBOptionModel { OptionId = "CompanyAddressFont", OptionValue = txtCompanyAddressFont.Text, ValueType = 0,
                        Description = "Config font chữ hiển thị địa chỉ đơn vị", IsSystem = false },
                    new DBOptionModel { OptionId = "CompanyCodeFont", OptionValue = txtCompanyCodeFont.Text, ValueType = 0,
                        Description = "Font chữ mã số đơn vị", IsSystem = false },
                    new DBOptionModel { OptionId = "CompanyNameFont", OptionValue = txtCompanyNameFont.Text, ValueType = 0,
                        Description = "Font chữ Tên đơn vị", IsSystem = false },
                    new DBOptionModel { OptionId = "IsPostToParentAccount", OptionValue = chkIsPostToParentAccount.EditValue.ToString(), ValueType = 3,
                        Description = "True- Cho phép định khoản vào tài khoản tổng hợp. False- Không cho phép định khoản vào tài khoản tổng hợp", IsSystem = false },
                    new DBOptionModel { OptionId = "IsValidVoucher", OptionValue = chkIsValidVoucher.EditValue.ToString(), ValueType = 3,
                        Description = "True- Cho phép kiểm tra hợp lệ khi lưu chứng từ. False- Không kiểm tra chứng từ khi lưu", IsSystem = false },
                    new DBOptionModel { OptionId = "IsPaymentNegativeFund", OptionValue = chkIsPaymentNegativeFund.EditValue.ToString(), ValueType = 3,
                        Description = "True- cho phép chi tiền khi quỹ âm. False- không cho phép chi tiền khi quỹ âm", IsSystem = false },
                    new DBOptionModel { OptionId = "IsDepositeNegavtiveFund", OptionValue = chkIsDepositeNegavtiveFund.EditValue.ToString(), ValueType = 3,
                        Description = "True- cho phép chi tiền gửi khi quỹ âm. False- không cho phép chi tiền gửi khi quỹ âm", IsSystem = false },
                    new DBOptionModel { OptionId = "IsPaymentNegativeBudgetSource", OptionValue = chkIsPaymentNegativeBudgetSource.EditValue.ToString(), ValueType = 3,
                        Description = "True- cho phép chi tiền khi nguồn âm. False- không cho phép chi tiền khi nguồn âm", IsSystem = false },
                    new DBOptionModel { OptionId = "IsOutwardNegativeStock", OptionValue = chkIsOutwardNegativeStock.EditValue.ToString(), ValueType = 3,
                        Description = "True- cho phép xuất kho khi hết hàng. False- không cho phép xuất kho khi hết hàng", IsSystem = false },
                    new DBOptionModel { OptionId = "MethodOfPostedDate", OptionValue = (cboMethodOfPostedDate.SelectedIndex + 1).ToString(CultureInfo.InvariantCulture),
                        ValueType = 1, Description = "Hình thức ghi sổ. 1- Nhật ký chung, 2- Chứng từ ghi sổ, 3- Nhật ký sổ cái", IsSystem = false },
                    new DBOptionModel { OptionId = "UnitPriceDecimalDigits", OptionValue = spinUnitPriceDecimalDigits.EditValue.ToString(), ValueType = 1,
                        Description = "Số chữ số sau dấu phẩy của đơn giá", IsSystem = false },
                    //new DBOptionModel { OptionId = "DefaultBudgetCategory", OptionValue = grdLookUpDefaultBudgetCategory.EditValue.ToString(), ValueType = 0,
                    //    Description = "Loại khoản ngầm định", IsSystem = false },
                    //new DBOptionModel { OptionId = "DefaultBudgetChapter", OptionValue = grdlookUpDefaultChapter.EditValue.ToString(), ValueType = 0,
                    //    Description = "Chương ngầm định", IsSystem = false },
                    new DBOptionModel { OptionId = "ConsulManager", OptionValue = txtConsulManager.Text, ValueType = 1,
                    Description = "Ngươi phụ trách lãnh sự", IsSystem = false },
                    new DBOptionModel { OptionId = "TitleConsulManager", OptionValue = txtTitleConsulManager.Text, ValueType = 1,
                    Description = "Chức danh phụ trách lãnh sự", IsSystem = false },

                    new DBOptionModel { OptionId = "JobTitleCompanyDirector", OptionValue = txtJobTitleCompanyDirector.Text, ValueType = 0,
                        Description = "Chức danh thủ trưởng đơn vị", IsSystem = false },
                    new DBOptionModel { OptionId = "JobTitleCompanyAccountant", OptionValue = txtJobTitleCompanyAccountant.Text, ValueType = 0,
                        Description = "Chức danh kế toán viên", IsSystem = false },
                    new DBOptionModel { OptionId = "JobTitleCompanyCashier", OptionValue = txtJobTitleCompanyCashier.Text, ValueType = 0,
                        Description = "Chức danh thủ quỹ", IsSystem = false },
                    new DBOptionModel { OptionId = "JobTitleCompanyStoreKeeper", OptionValue = txtJobTitleCompanyStoreKeeper.Text, ValueType = 0,
                        Description = "Chức danh thủ kho", IsSystem = false },
                    new DBOptionModel { OptionId = "JobTitleCompanyReportPreparer", OptionValue = txtJobTitleCompanyReportPreparer.Text, ValueType = 0,
                        Description = "Chức danh người lập báo cáo", IsSystem = false },
                    new DBOptionModel { OptionId = "TotalEmployees", OptionValue = spinTotalEmployees.EditValue.ToString(), ValueType = 1,
                        Description = "Tổng số biên chế", IsSystem = false },
                    new DBOptionModel { OptionId = "TotalNativeEmployees", OptionValue = spinTotalNativeEmployees.EditValue.ToString(), ValueType = 1,
                        Description = "Tổng số người bản địa", IsSystem = false },
                    new DBOptionModel { OptionId = "NameOfInventory1", OptionValue = txtNameOfInventory1.EditValue.ToString(), ValueType = 0,
                        Description = "Tên người kiểm kê 1", IsSystem = false },
                    new DBOptionModel { OptionId = "JobOfInventory1", OptionValue = txtJobOfInventory1.EditValue.ToString(), ValueType = 0,
                        Description = "Chức vụ người kiểm kê 1", IsSystem = false },
                    new DBOptionModel { OptionId = "NameOfInventory2", OptionValue = txtNameOfInventory2.EditValue.ToString(), ValueType = 0,
                        Description = "Tên người kiểm kê 2", IsSystem = false },
                    new DBOptionModel { OptionId = "JobOfInventory2", OptionValue = txtJobOfInventory2.EditValue.ToString(), ValueType = 0,
                        Description = "Chức vụ người kiểm kê 2", IsSystem = false },
                    new DBOptionModel { OptionId = "NameOfInventory3", OptionValue = txtNameOfInventory3.EditValue.ToString(), ValueType = 0,
                        Description = "Tên người kiểm kê 3", IsSystem = false },
                    new DBOptionModel { OptionId = "JobOfInventory3", OptionValue = txtJobOfInventory3.EditValue.ToString(), ValueType = 0,
                        Description = "Chức vụ người kiểm kê 3", IsSystem = false },
                    new DBOptionModel { OptionId = "HourOfInventory", OptionValue = txtHourOfInventory.Text, ValueType = 1,
                        Description = "Giờ kiểm kê", IsSystem = false },
                    new DBOptionModel { OptionId = "MinuteOfInventory", OptionValue = txtMinuteOfInventory.Text, ValueType = 1,
                        Description = "Phút kiểm kê", IsSystem = false },
                    new DBOptionModel { OptionId = "DateOfInventory", OptionValue = DateTime.Parse(dtDateOfInventory.Text).ToShortDateString(), ValueType = 1,
                        Description = "Ngày kiểm kê", IsSystem = false },
                    new DBOptionModel { OptionId = "MethodOfCostPrice", OptionValue = (cboMethodOfCostPrice.SelectedIndex + 1).ToString(CultureInfo.InvariantCulture),
                        ValueType = 0, Description = "Phương pháp tính giá tồn kho.1- Bình quân cuối kỳ. 2- Bình quân sau mỗi lần nhập. 3- Đích danh. 4- Nhập trước xuất trước. 5- Nhập sau xuất trước", IsSystem = false },
                    new DBOptionModel { OptionId = "BaseOfSalary", OptionValue = spinBaseOfSalary.EditValue.ToString(), ValueType = 1, Description = "SHP tối thiểu", IsSystem = false },
                    new DBOptionModel { OptionId = "DisplayVourcherMode", OptionValue = (cboDisplayVourcherMode.SelectedIndex).ToString(CultureInfo.InvariantCulture), ValueType = 1, Description = "Cách hiển thị danh sách chứng từ. 1- Hiển thị tất cả. 2- Hiển thị danh sách chứng từ theo năm hạch toán", IsSystem = false },
                    new DBOptionModel { OptionId = "IsDailyBackup", OptionValue = chkAutoDailyBackup.EditValue.ToString(), ValueType = 3, Description = "Cho phép tự động sao lưu hằng ngày", IsSystem = false },
                    new DBOptionModel { OptionId = "DailyBackupPath", OptionValue = (bool)chkAutoDailyBackup.EditValue ? btnBackupPath.Text : null, ValueType = 0, Description = "Đường dẫn sao lưu CSDL hằng ngày", IsSystem = false },
                    new DBOptionModel { OptionId = "XMLPath", OptionValue= btnXMLPath.Text, ValueType = 0, Description = "Đường dẫn lưu file XML", IsSystem = false },
                    new DBOptionModel { OptionId = "CoefficientOfSalaryByArea", OptionValue = spinCoefficientOfSalaryByArea.EditValue.ToString(), ValueType = 1, Description = "Hệ số lương địa bàn", IsSystem = false }
                };
                return dbOptions;
            }
            set
            {
                if (value == null) return;
                spinCurrencyDecimalDigits.EditValue = (from dbOption in value where dbOption.OptionId == "CurrencyDecimalDigits" select dbOption.OptionValue).First();
                spinUnitPriceDecimalDigits.EditValue = (from dbOption in value where dbOption.OptionId == "UnitPriceDecimalDigits" select dbOption.OptionValue).First();
                spinExchangeRateDecimalDigits.EditValue = (from dbOption in value where dbOption.OptionId == "ExchangeRateDecimalDigits" select dbOption.OptionValue).First();
                spinPercentDecimalDigits.EditValue = (from dbOption in value where dbOption.OptionId == "PercentDecimalDigits" select dbOption.OptionValue).First();
                txtCurrencyDecimalSeparator.Text = (from dbOption in value where dbOption.OptionId == "CurrencyDecimalSeparator" select dbOption.OptionValue).First();
                txtCurrencyGroupSeparator.Text = (from dbOption in value where dbOption.OptionId == "CurrencyGroupSeparator" select dbOption.OptionValue).First();
                cboNumberNegativePattern.SelectedIndex = int.Parse((from dbOption in value where dbOption.OptionId == "NumberNegativePattern" select dbOption.OptionValue).First());
                txtHourOfInventory.Text = (from dbOption in value where dbOption.OptionId == "HourOfInventory" select dbOption.OptionValue).First();
                txtMinuteOfInventory.Text = (from dbOption in value where dbOption.OptionId == "MinuteOfInventory" select dbOption.OptionValue).First();
                dtDateOfInventory.EditValue = (from dbOption in value where dbOption.OptionId == "DateOfInventory" select dbOption.OptionValue).First();
                cboMethodOfCostPrice.SelectedIndex = int.Parse((from dbOption in value where dbOption.OptionId == "MethodOfCostPrice" select dbOption.OptionValue).First()) - 1;
                cboDisplayVourcherMode.SelectedIndex = int.Parse((from dbOption in value where dbOption.OptionId == "DisplayVourcherMode" select dbOption.OptionValue).First());

                //general options
                chkIsPostToParentAccount.EditValue = bool.Parse((from dbOption in value where dbOption.OptionId == "IsPostToParentAccount" select dbOption.OptionValue).First());
                chkIsValidVoucher.EditValue = bool.Parse((from dbOption in value where dbOption.OptionId == "IsValidVoucher" select dbOption.OptionValue).First());
                chkIsPaymentNegativeFund.EditValue = bool.Parse((from dbOption in value where dbOption.OptionId == "IsPaymentNegativeFund" select dbOption.OptionValue).First());
                chkIsDepositeNegavtiveFund.EditValue = bool.Parse((from dbOption in value where dbOption.OptionId == "IsDepositeNegavtiveFund" select dbOption.OptionValue).First());
                chkIsPaymentNegativeBudgetSource.EditValue = bool.Parse((from dbOption in value where dbOption.OptionId == "IsPaymentNegativeBudgetSource" select dbOption.OptionValue).First());
                chkIsOutwardNegativeStock.EditValue = bool.Parse((from dbOption in value where dbOption.OptionId == "IsOutwardNegativeStock" select dbOption.OptionValue).First());
                //grdlookUpDefaultChapter.EditValue = (from dbOption in value where dbOption.OptionId == "DefaultBudgetChapter" select dbOption.OptionValue).First();
                //grdLookUpDefaultBudgetCategory.EditValue = (from dbOption in value where dbOption.OptionId == "DefaultBudgetCategory" select dbOption.OptionValue).First();
                cboMethodOfPostedDate.SelectedIndex = int.Parse((from dbOption in value where dbOption.OptionId == "MethodOfPostedDate" select dbOption.OptionValue).First()) - 1;
                spinBaseOfSalary.EditValue = decimal.Parse((from dbOption in value where dbOption.OptionId == "BaseOfSalary" select dbOption.OptionValue).First());
                spinCoefficientOfSalaryByArea.EditValue = (from dbOption in value where dbOption.OptionId == "CoefficientOfSalaryByArea" select dbOption.OptionValue).Count() > 0 ? decimal.Parse((from dbOption in value where dbOption.OptionId == "CoefficientOfSalaryByArea" select dbOption.OptionValue).First()) : 1;

                //report signature
                txtCompanyAccountant.EditValue = (from dbOption in value where dbOption.OptionId == "CompanyAccountant" select dbOption.OptionValue).First();
                txtCompanyCashier.EditValue = (from dbOption in value where dbOption.OptionId == "CompanyCashier" select dbOption.OptionValue).First();
                txtCompanyDirector.EditValue = (from dbOption in value where dbOption.OptionId == "CompanyDirector" select dbOption.OptionValue).First();
                txtCompanyReportPreparer.EditValue = (from dbOption in value where dbOption.OptionId == "CompanyReportPreparer" select dbOption.OptionValue).First();
                txtCompanyStoreKeeper.EditValue = (from dbOption in value where dbOption.OptionId == "CompanyStoreKeeper" select dbOption.OptionValue).First();

                //jobtitle
                txtJobTitleCompanyDirector.EditValue = (from dbOption in value where dbOption.OptionId == "JobTitleCompanyDirector" select dbOption.OptionValue).First();
                txtJobTitleCompanyAccountant.EditValue = (from dbOption in value where dbOption.OptionId == "JobTitleCompanyAccountant" select dbOption.OptionValue).First();
                txtJobTitleCompanyCashier.EditValue = (from dbOption in value where dbOption.OptionId == "JobTitleCompanyCashier" select dbOption.OptionValue).First();
                txtJobTitleCompanyStoreKeeper.EditValue = (from dbOption in value where dbOption.OptionId == "JobTitleCompanyStoreKeeper" select dbOption.OptionValue).First();
                txtJobTitleCompanyReportPreparer.EditValue = (from dbOption in value where dbOption.OptionId == "JobTitleCompanyReportPreparer" select dbOption.OptionValue).First();

                //phu trach lanh su
                txtConsulManager.EditValue = (from dbOption in value where dbOption.OptionId == "ConsulManager" select dbOption.OptionValue).First();
                txtTitleConsulManager.EditValue = (from dbOption in value where dbOption.OptionId == "TitleConsulManager" select dbOption.OptionValue).First();

                //company info
                txtCompanyAdrress.EditValue = (from dbOption in value where dbOption.OptionId == "CompanyAdrress" select dbOption.OptionValue).First();
                txtCompanyCode.EditValue = (from dbOption in value where dbOption.OptionId == "CompanyCode" select dbOption.OptionValue).First();
                txtCompanyDistrict.EditValue = (from dbOption in value where dbOption.OptionId == "CompanyDistrict" select dbOption.OptionValue).First();
                txtCompanyName.EditValue = (from dbOption in value where dbOption.OptionId == "CompanyName" select dbOption.OptionValue).First();
                txtCompanyProvince.EditValue = (from dbOption in value where dbOption.OptionId == "CompanyProvince" select dbOption.OptionValue).First();
                txtCompanyTel.EditValue = (from dbOption in value where dbOption.OptionId == "CompanyTel" select dbOption.OptionValue).First();
                txtCompanyFax.EditValue = (from dbOption in value where dbOption.OptionId == "CompanyFax" select dbOption.OptionValue).First();
                txtCompanyEmail.EditValue = (from dbOption in value where dbOption.OptionId == "CompanyEmail" select dbOption.OptionValue).First();
                txtCompanyWebsite.EditValue = (from dbOption in value where dbOption.OptionId == "CompanyWebsite" select dbOption.OptionValue).First();
                spinTotalEmployees.EditValue = (from dbOption in value where dbOption.OptionId == "TotalEmployees" select dbOption.OptionValue).First();
                spinTotalNativeEmployees.EditValue = (from dbOption in value where dbOption.OptionId == "TotalNativeEmployees" select dbOption.OptionValue).First();

                //company font
                txtCompanyAddressFont.EditValue = (from dbOption in value where dbOption.OptionId == "CompanyAddressFont" select dbOption.OptionValue).First();
                txtCompanyCodeFont.EditValue = (from dbOption in value where dbOption.OptionId == "CompanyCodeFont" select dbOption.OptionValue).First();
                txtCompanyNameFont.EditValue = (from dbOption in value where dbOption.OptionId == "CompanyNameFont" select dbOption.OptionValue).First();

                //ban kiem ke
                txtNameOfInventory1.EditValue = (from dbOption in value where dbOption.OptionId == "NameOfInventory1" select dbOption.OptionValue).First();
                txtJobOfInventory1.EditValue = (from dbOption in value where dbOption.OptionId == "JobOfInventory1" select dbOption.OptionValue).First();
                txtNameOfInventory2.EditValue = (from dbOption in value where dbOption.OptionId == "NameOfInventory2" select dbOption.OptionValue).First();
                txtJobOfInventory2.EditValue = (from dbOption in value where dbOption.OptionId == "JobOfInventory2" select dbOption.OptionValue).First();
                txtNameOfInventory3.EditValue = (from dbOption in value where dbOption.OptionId == "NameOfInventory3" select dbOption.OptionValue).First();
                txtJobOfInventory3.EditValue = (from dbOption in value where dbOption.OptionId == "JobOfInventory3" select dbOption.OptionValue).First();

                //auto backup
                chkAutoDailyBackup.EditValue = bool.Parse((from dbOption in value where dbOption.OptionId == "IsDailyBackup" select dbOption.OptionValue).First());
                btnBackupPath.EditValue = (from dbOption in value where dbOption.OptionId == "DailyBackupPath" select dbOption.OptionValue).First();
                btnXMLPath.EditValue = (from dbOption in value where dbOption.OptionId == "XMLPath" select dbOption.OptionValue).First();


                //set number format
                SetFormatNumber();
            }
        }

        /// <summary>
        /// Sets the budget chapters.
        /// </summary>
        /// <value>
        /// The budget chapters.
        /// </value>
        public IList<BudgetChapterModel> BudgetChapters
        {
            set
            {
                try
                {
                    grdlookUpDefaultChapter.Properties.DataSource = value;
                    grdlookUpDefaultChapterView.PopulateColumns(value);
                    var gridColumnsCollection = new List<XtraColumn>
                        {
                            new XtraColumn { ColumnName = "BudgetChapterId", ColumnVisible = false },
                            new XtraColumn { ColumnName = "BudgetChapterCode", ColumnCaption = "Mã chương", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 110 },
                            new XtraColumn { ColumnName = "BudgetChapterName", ColumnCaption = "Tên chương", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 200 },
                            new XtraColumn { ColumnName = "Description", ColumnVisible = false },
                            new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false },
                            new XtraColumn { ColumnName = "IsActive", ColumnVisible = false },
                            new XtraColumn { ColumnName = "ForeignName", ColumnVisible = false }
                        };
                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            grdlookUpDefaultChapterView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            grdlookUpDefaultChapterView.Columns[column.ColumnName].SortIndex = column.ColumnPosition;
                            grdlookUpDefaultChapterView.Columns[column.ColumnName].Width = column.ColumnWith;
                            grdlookUpDefaultChapterView.Columns[column.ColumnName].AppearanceCell.TextOptions.HAlignment = column.Alignment;
                        }
                        else
                            grdlookUpDefaultChapterView.Columns[column.ColumnName].Visible = false;
                    }
                    grdlookUpDefaultChapter.Properties.DisplayMember = "BudgetChapterCode";
                    grdlookUpDefaultChapter.Properties.ValueMember = "BudgetChapterCode";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Sets the budget categories.
        /// </summary>
        /// <value>
        /// The budget categories.
        /// </value>
        public IList<BudgetCategoryModel> BudgetCategories
        {
            set
            {
                try
                {
                    grdLookUpDefaultBudgetCategory.Properties.DataSource = value;
                    grdLookUpDefaultBudgetCategoryView.PopulateColumns(value);
                    var gridColumnsCollection = new List<XtraColumn>
                        {
                            new XtraColumn { ColumnName = "BudgetCategoryId", ColumnVisible = false },
                            new XtraColumn { ColumnName = "ParentId", ColumnVisible = false },
                            new XtraColumn { ColumnName = "BudgetCategoryCode", ColumnCaption = "Mã loại khoản", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 110 },
                            new XtraColumn { ColumnName = "BudgetCategoryName", ColumnCaption = "Tên loại khoản", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 200 },
                            new XtraColumn { ColumnName = "Description", ColumnVisible = false },
                            new XtraColumn { ColumnName = "IsParent", ColumnVisible = false },
                            new XtraColumn { ColumnName = "IsActive", ColumnVisible = false },
                            new XtraColumn { ColumnName = "ForeignName", ColumnVisible = false },
                            new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false },
                            new XtraColumn { ColumnName = "Grade", ColumnVisible = false }
                        };
                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            grdLookUpDefaultBudgetCategoryView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            grdLookUpDefaultBudgetCategoryView.Columns[column.ColumnName].SortIndex = column.ColumnPosition;
                            grdLookUpDefaultBudgetCategoryView.Columns[column.ColumnName].Width = column.ColumnWith;
                            grdLookUpDefaultBudgetCategoryView.Columns[column.ColumnName].AppearanceCell.TextOptions.HAlignment = column.Alignment;
                        }
                        else
                            grdLookUpDefaultBudgetCategoryView.Columns[column.ColumnName].Visible = false;
                    }
                    grdLookUpDefaultBudgetCategory.Properties.DisplayMember = "BudgetCategoryCode";
                    grdLookUpDefaultBudgetCategory.Properties.ValueMember = "BudgetCategoryCode";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Gets or sets the automatic numbers.
        /// </summary>
        /// <value>
        /// The automatic numbers.
        /// </value>
        public IList<AutoNumberModel> AutoNumbers
        {
            get
            {
                var autoNumbers = new List<AutoNumberModel>();
                if (grdDetail.DataSource != null && gridViewDetail.DataRowCount > 0)
                {
                    for (var i = 0; i < gridViewDetail.DataRowCount; i++)
                    {
                        if (gridViewDetail.GetRow(i) != null)
                        {
                            autoNumbers.Add(new AutoNumberModel
                            {
                                RefTypeId = (int)gridViewDetail.GetRowCellValue(i, "RefTypeId"),
                                Prefix = (string)gridViewDetail.GetRowCellValue(i, "Prefix"),
                                Suffix = (string)gridViewDetail.GetRowCellValue(i, "Suffix"),
                                Value = (int)gridViewDetail.GetRowCellValue(i, "Value"),
                                ValueLocalCurency = (int)gridViewDetail.GetRowCellValue(i, "ValueLocalCurency"),
                                LengthOfValue = (int)gridViewDetail.GetRowCellValue(i, "LengthOfValue"),
                            });
                        }
                    }
                }
                return autoNumbers.ToList();
            }
            set
            {
                bindingSourceDetail.DataSource = value;
                gridViewDetail.PopulateColumns(value);

                var gridColumnsCollection = new List<XtraColumn>
                {
                    new XtraColumn { ColumnName = "RefTypeId", ColumnCaption = "Loại CT", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 170,
                                                RepositoryControl = _gridLookUpEditRefTypeId, AllowEdit = false },
                    new XtraColumn { ColumnName = "Prefix", ColumnCaption = "Tiền tố", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 70, AllowEdit = true },
                    new XtraColumn { ColumnName = "Suffix", ColumnCaption = "Hậu tố", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 70, AllowEdit = true },
                    new XtraColumn { ColumnName = "LengthOfValue", ColumnCaption = "Độ dài GT", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 80, AllowEdit = true, ToolTip = "Độ dài giá trị"},
                    new XtraColumn { ColumnName = "Value", ColumnCaption = "GT USD", ColumnPosition = 5, ColumnVisible = true, ColumnWith = 80, AllowEdit = true, ToolTip = "Giá trị số tự động tăng theo tiền hạch toán" },
                    new XtraColumn { ColumnName = "ValueLocalCurency", ColumnCaption = "GT ĐP", ColumnPosition = 6, ColumnVisible = true, ColumnWith = 80, AllowEdit = true, ToolTip = "Giá trị số tự động tăng theo tiền địa phương" }
                };

                foreach (var column in gridColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        gridViewDetail.Columns[column.ColumnName].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                        gridViewDetail.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        gridViewDetail.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                        gridViewDetail.Columns[column.ColumnName].Width = column.ColumnWith;
                        gridViewDetail.Columns[column.ColumnName].ColumnEdit = column.RepositoryControl;
                        gridViewDetail.Columns[column.ColumnName].OptionsColumn.AllowEdit = column.AllowEdit;
                        gridViewDetail.Columns[column.ColumnName].ToolTip = column.ToolTip;
                    }
                    else
                        gridViewDetail.Columns[column.ColumnName].Visible = false;
                }
            }
        }

        /// <summary>
        /// Sets the reference types.
        /// </summary>
        /// <value>
        /// The reference types.
        /// </value>
        public IList<RefTypeModel> RefTypes
        {
            set
            {
                try
                {
                    _gridLookUpEditRefTypeId.DataSource = value;
                    _gridLookUpEditRefTypeIdView.PopulateColumns(value);

                    var gridColumnsCollection = new List<XtraColumn>
                    {
                        new XtraColumn {ColumnName = "RefTypeId", ColumnVisible = false },
                        new XtraColumn {ColumnName = "RefTypeName", ColumnCaption = "Loại chứng từ", ColumnPosition = 1 },
                        new XtraColumn {ColumnName = "FunctionId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "MasterTableName", ColumnVisible = false},
                        new XtraColumn {ColumnName = "DetailTableName", ColumnVisible = false},
                        new XtraColumn {ColumnName = "DefaultDebitAccountCategoryId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "DefaultDebitAccountId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "DefaultCreditAccountCategoryId", ColumnVisible = false},
                        new XtraColumn {ColumnName = "DefaultCreditAccountId", ColumnVisible = false},
                        //new XtraColumn {ColumnName = "DefaultObjectType", ColumnVisible = false},
                        //new XtraColumn {ColumnName = "IsDefaultSetting", ColumnVisible = false},
                        //new XtraColumn {ColumnName = "IsPostToGL", ColumnVisible = false}
                    };

                    foreach (var column in gridColumnsCollection)
                    {
                        if (column.ColumnVisible)
                        {
                            _gridLookUpEditRefTypeIdView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                            _gridLookUpEditRefTypeIdView.Columns[column.ColumnName].SortIndex = column.ColumnPosition;
                            _gridLookUpEditRefTypeIdView.Columns[column.ColumnName].Width = column.ColumnWith;
                            _gridLookUpEditRefTypeIdView.Columns[column.ColumnName].ToolTip = column.ToolTip;
                        }
                        else
                            _gridLookUpEditRefTypeIdView.Columns[column.ColumnName].Visible = false;
                    }
                    _gridLookUpEditRefTypeId.DisplayMember = "RefTypeName";
                    _gridLookUpEditRefTypeId.ValueMember = "RefTypeId";
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        #endregion

        #region Functions

        /// <summary>
        /// Sets the format number.
        /// </summary>
        private void SetFormatNumber()
        {
            var currencyDecimalDigits = int.Parse(spinCurrencyDecimalDigits.EditValue.ToString());
            var unitPriceDecimalDigits = int.Parse(spinUnitPriceDecimalDigits.EditValue.ToString());
            var exchangeRateDecimalDigits = int.Parse(spinExchangeRateDecimalDigits.EditValue.ToString());
            var percentDecimalDigits = int.Parse(spinPercentDecimalDigits.EditValue.ToString());
            var currencyDecimalSeparator = txtCurrencyDecimalSeparator.Text;
            var currencyGroupSeparator = txtCurrencyGroupSeparator.Text;
            var numberNegativePattern = cboNumberNegativePattern.SelectedIndex;

            var defaultValue = "1" + currencyDecimalSeparator + "234" + currencyDecimalSeparator + "456" + currencyDecimalSeparator + "789";
            //currencyDecimalDigits
            if (currencyDecimalDigits > 0)
            {
                lblCurrencyDecimalDigits.Text = defaultValue + currencyGroupSeparator;
                for (var i = 0; i < currencyDecimalDigits; i++)
                    lblCurrencyDecimalDigits.Text += @"0";
            }
            else
                lblCurrencyDecimalDigits.Text = defaultValue;

            //numberDecimalDigits
            if (unitPriceDecimalDigits > 0)
            {
                lblUnitPriceDecimalDigits.Text = defaultValue + currencyGroupSeparator;
                for (var i = 0; i < unitPriceDecimalDigits; i++)
                    lblUnitPriceDecimalDigits.Text += @"0";
            }
            else
                lblUnitPriceDecimalDigits.Text = defaultValue;

            //ExchangeRateDecimalDigits
            if (exchangeRateDecimalDigits > 0)
            {
                lblExchangeRateDecimalDigits.Text = defaultValue + currencyGroupSeparator;
                for (var i = 0; i < exchangeRateDecimalDigits; i++)
                    lblExchangeRateDecimalDigits.Text += @"0";
            }
            else
                lblExchangeRateDecimalDigits.Text = defaultValue;

            //percentDecimalDigits
            if (percentDecimalDigits > 0)
            {
                lblPercentDecimalDigits.Text = defaultValue + currencyGroupSeparator;
                for (var i = 0; i < percentDecimalDigits; i++)
                    lblPercentDecimalDigits.Text += @"0";
            }
            else
                lblPercentDecimalDigits.Text = defaultValue;

            //NumberNegativePattern
            switch (numberNegativePattern)
            {
                case 0:
                    lblNumberNegativePattern.Text = @"(" + defaultValue + @")";
                    break;
                case 1:
                    lblNumberNegativePattern.Text = @"-" + defaultValue;
                    break;
                case 2:
                    lblNumberNegativePattern.Text = defaultValue + @"-";
                    break;
            }

            spinBaseOfSalary.Properties.Mask.MaskType = MaskType.Numeric;
            spinBaseOfSalary.Properties.Mask.EditMask = @"c" + spinCurrencyDecimalDigits.EditValue;
            spinBaseOfSalary.Properties.Mask.Culture = Thread.CurrentThread.CurrentCulture;
            spinBaseOfSalary.Properties.Mask.UseMaskAsDisplayFormat = true;
        }

        #endregion

        #region Events

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmXtraFormDbOption" /> class.
        /// </summary>
        public FrmXtraFormDbOption()
        {

            InitializeComponent();
            _dbOptionsPresenter = new DBOptionsPresenter(this);
            _autoNumberListsPresenter = new AutoNumberListsPresenter(this);
            _autoNumbersPresenter = new AutoNumbersPresenter(this);
            _refTypesPresenter = new RefTypesPresenter(this);
        }

        /// <summary>
        /// Handles the Load event of the FrmXtraFormDbOption control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void FrmXtraFormDbOption_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                _gridLookUpEditRefTypeIdView = new GridView();
                _gridLookUpEditRefTypeIdView.OptionsView.ColumnAutoWidth = false;
                _gridLookUpEditRefTypeId = new RepositoryItemGridLookUpEdit
                {
                    NullText = "",
                    View = _gridLookUpEditRefTypeIdView,
                    TextEditStyle = TextEditStyles.Standard,
                    PopupResizeMode = ResizeMode.FrameResize,
                    //PopupFormSize = new Size(500, 200),
                    ShowFooter = false
                };
                _gridLookUpEditRefTypeId.View.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
                _gridLookUpEditRefTypeId.View.OptionsView.ShowIndicator = false;
                _gridLookUpEditRefTypeId.View.BestFitColumns();

                //_budgetChapterPresenter.DisplayActive();
                //_budgetCategoriesPresenter.DisplayActive();
                _refTypesPresenter.Display();
                _autoNumbersPresenter.Display();
                _dbOptionsPresenter.Display();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                XtraMessageBox.Show(ex.ToString(),
                    ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            _autoNumberListsPresenter.Display();

        }

        /// <summary>
        /// Handles the Click event of the btnExit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Handles the Click event of the btnShowDemo control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnShowDemo_Click(object sender, EventArgs e)
        {
            SetFormatNumber();
        }

        /// <summary>
        /// Handles the KeyPress event of the txtCurrencyDecimalSeparator control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyPressEventArgs" /> instance containing the event data.</param>
        private void txtCurrencyDecimalSeparator_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != Convert.ToChar(Keys.Back) && e.KeyChar != Convert.ToChar('.') && e.KeyChar != Convert.ToChar(','))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Handles the KeyPress event of the txtCurrencyGroupSeparator control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyPressEventArgs" /> instance containing the event data.</param>
        private void txtCurrencyGroupSeparator_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != Convert.ToChar(Keys.Back) && e.KeyChar != Convert.ToChar('.') && e.KeyChar != Convert.ToChar(','))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Handles the Click event of the btnSave control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var message = _dbOptionsPresenter.Save();
                foreach (var dbOptionModel in DBOptions)
                {
                    if (dbOptionModel.OptionId == "CompanyDirector")
                    {
                        _dbOptionsPresenter.SaveCompanyProfile();
                    }
                }
                if (message != null)
                    XtraMessageBox.Show(message, ResourceHelper.GetResourceValueByName("ResDetailContent"),
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {

                    _autoNumbersPresenter.Save();
                    XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResSaveDataSuccess"),
                                        ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    SetFormatNumber();
                }
                _autoNumberListsPresenter.Save();
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                var dbOptionHelper = new GlobalVariable();
                Thread.CurrentThread.CurrentCulture = new CultureInfo(ResourceHelper.ResourceLanguage)
                {
                    NumberFormat =
                    {
                        CurrencySymbol = dbOptionHelper.CurrencySymbol,
                        CurrencyDecimalSeparator = dbOptionHelper.CurrencyDecimalSeparator,
                        CurrencyGroupSeparator = dbOptionHelper.CurrencyGroupSeparator,
                        CurrencyDecimalDigits = int.Parse(dbOptionHelper.CurrencyDecimalDigits),

                        NumberDecimalSeparator = dbOptionHelper.CurrencyDecimalSeparator,
                        NumberGroupSeparator = dbOptionHelper.CurrencyGroupSeparator
                    }
                };
                Cursor.Current = Cursors.Default;
            }
        }

        /// <summary>
        /// Handles the Click event of the btnCompanyNameFont control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnCompanyNameFont_Click(object sender, EventArgs e)
        {
            var result = dlgCompanyNameFont.ShowDialog();
            if (result != DialogResult.OK) return;
            var font = dlgCompanyNameFont.Font;
            txtCompanyNameFont.Text = string.Format("{0};{1};{2}", font.Name, font.Style, font.Size);
        }

        /// <summary>
        /// Handles the Click event of the btnCompanyCodeFont control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnCompanyCodeFont_Click(object sender, EventArgs e)
        {
            var result = dlgCompanyCodeFont.ShowDialog();
            if (result != DialogResult.OK) return;
            var font = dlgCompanyCodeFont.Font;
            txtCompanyCodeFont.Text = string.Format("{0};{1};{2}", font.Name, font.Style, font.Size);
        }

        /// <summary>
        /// Handles the Click event of the btnCompanyAddressFont control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnCompanyAddressFont_Click(object sender, EventArgs e)
        {
            var result = dlgCompanyAddressFont.ShowDialog();
            if (result != DialogResult.OK) return;
            var font = dlgCompanyAddressFont.Font;
            txtCompanyAddressFont.Text = string.Format("{0};{1};{2}", font.Name, font.Style, font.Size);
        }

        /// <summary>
        /// Handles the CheckedChanged event of the chkAutoDailyBackup control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void chkAutoDailyBackup_CheckedChanged(object sender, EventArgs e)
        {
            btnBackupPath.Enabled = chkAutoDailyBackup.CheckState == CheckState.Checked;
        }

        /// <summary>
        /// Handles the ButtonClick event of the btnBackupPath control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ButtonPressedEventArgs"/> instance containing the event data.</param>
        private void btnBackupPath_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            try
            {
                using (var folderBrowserDialog = new FolderBrowserDialog())
                {
                    var dialogResult = folderBrowserDialog.ShowDialog();
                    if (dialogResult == DialogResult.OK)
                    {
                        btnBackupPath.Text = folderBrowserDialog.SelectedPath;
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(),
                    ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        public IList<AutoNumberListModel> AutoNumberLists
        {
            get
            {
                var autoNumberLists = new List<AutoNumberListModel>();
                if (gridList.DataSource != null && grdListView.DataRowCount > 0)
                {
                    for (var i = 0; i < grdListView.DataRowCount; i++)
                    {
                        if (grdListView.GetRow(i) != null)
                        {
                            autoNumberLists.Add(new AutoNumberListModel
                            {
                                TableCode = (string)grdListView.GetRowCellValue(i, "TableCode"),
                                TableName = (string)grdListView.GetRowCellValue(i, "TableName"),
                                Prefix = (string)grdListView.GetRowCellValue(i, "Prefix"),
                                Suffix = (string)grdListView.GetRowCellValue(i, "Suffix"),
                                Value = (int)grdListView.GetRowCellValue(i, "Value"),
                                LengthOfValue = (int)grdListView.GetRowCellValue(i, "LengthOfValue"),
                            });
                        }
                    }
                }
                return autoNumberLists.ToList();
            }
            set
            {
                gridList.DataSource = value;
                grdListView.PopulateColumns(value);

                var gridColumnsCollection = new List<XtraColumn>
                {
                     new XtraColumn { ColumnName = "TableCode", ColumnCaption = "Mã bảng", ColumnPosition = 1, ColumnVisible = false, ColumnWith = 170, AllowEdit = false },
                    new XtraColumn { ColumnName = "TableName", ColumnCaption = "Tên bảng", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 170, AllowEdit = false },
                    new XtraColumn { ColumnName = "Prefix", ColumnCaption = "Tiền tố", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 70, AllowEdit = true },
                    new XtraColumn { ColumnName = "Suffix", ColumnCaption = "Hậu tố", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 70, AllowEdit = true },
                    new XtraColumn { ColumnName = "LengthOfValue", ColumnCaption = "Độ dài giới hạn", ColumnPosition = 4, ColumnVisible = true, ColumnWith = 80, AllowEdit = true, ToolTip = "Độ dài giá trị"},
                    new XtraColumn { ColumnName = "Value", ColumnCaption = "Giá trị", ColumnPosition = 5, ColumnVisible = true, ColumnWith = 80, AllowEdit = true, ToolTip = "Giá trị số tự động tăng theo tiền hạch toán" },
                };

                foreach (var column in gridColumnsCollection)
                {
                    if (column.ColumnVisible)
                    {
                        grdListView.Columns[column.ColumnName].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                        grdListView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                        grdListView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                        grdListView.Columns[column.ColumnName].Width = column.ColumnWith;
                        grdListView.Columns[column.ColumnName].OptionsColumn.AllowEdit = column.AllowEdit;
                        grdListView.Columns[column.ColumnName].ToolTip = column.ToolTip;
                    }
                    else
                        grdListView.Columns[column.ColumnName].Visible = false;
                }
            }
        }

        private void btnXMLPath_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            try
            {
                using (var folderBrowserDialog = new FolderBrowserDialog())
                {
                    var dialogResult = folderBrowserDialog.ShowDialog();
                    if (dialogResult == DialogResult.OK)
                    {
                        btnXMLPath.Text = folderBrowserDialog.SelectedPath;
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(),
                    ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
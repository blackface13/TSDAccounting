using System.Windows.Forms;
using TSD.AccountingSoft.WindowsForm.CommonControl;
using TSD.AccountingSoft.WindowsForm.Resources;

namespace TSD.AccountingSoft.WindowsForm
{
    partial class MainRibbonForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainRibbonForm));
            this.ribbonMainMenu = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.imageRibbonCollection = new DevExpress.Utils.ImageCollection();
            this.barButtonOpenData = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonCloseData = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonPostedDate = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonDbInfo = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonUser = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonChangePassword = new DevExpress.XtraBars.BarButtonItem();
            this.barItemBackUpData = new DevExpress.XtraBars.BarButtonItem();
            this.barItemRestoreData = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticServerName = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticUserName = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticDateItem = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticTimeItem = new DevExpress.XtraBars.BarStaticItem();
            this.barButtonCreateNewDatabase = new DevExpress.XtraBars.BarButtonItem();
            this.barCompanyProfileItem = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonDbOption = new DevExpress.XtraBars.BarButtonItem();
            this.barUnlockBook = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonAudittingLog = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem20 = new DevExpress.XtraBars.BarButtonItem();
            this.barSalaryItem = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonFAIncrement = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonFADecrement = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonFAArmortization = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem25 = new DevExpress.XtraBars.BarButtonItem();
            this.barInputInventory = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonOutputInventory = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonUpdateAmountExchangeItem = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnCaptitalAllocateVoucher = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonGeneral = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonBudgetSource = new DevExpress.XtraBars.BarButtonItem();
            this.barCurrencyItem = new DevExpress.XtraBars.BarButtonItem();
            this.barCustomers = new DevExpress.XtraBars.BarButtonItem();
            this.barVendor = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonFixedAssetCategoryItem = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonFixedAssetItem = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonHelpItem = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonRegisterItem = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonAboutItem = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonAutoUpdateItem = new DevExpress.XtraBars.BarButtonItem();
            this.barAccountingObject = new DevExpress.XtraBars.BarButtonItem();
            this.barPlanTemplate = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonStock = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonInventoryItem = new DevExpress.XtraBars.BarButtonItem();
            this.barCapitalAllocateItem = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonBank = new DevExpress.XtraBars.BarButtonItem();
            this.barMergerFundItem = new DevExpress.XtraBars.BarButtonItem();
            this.barVoucherList = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonProject = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItem11 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem13 = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem2 = new DevExpress.XtraBars.BarSubItem();
            this.barButtonAccountCategory = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonAccountItem = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonAutoBusiness = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonAccountTranfer = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonAutoBusinessParallel = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonRefTypes = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem3 = new DevExpress.XtraBars.BarSubItem();
            this.barButtonBudgetChapter = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonBudgetCategory = new DevExpress.XtraBars.BarButtonItem();
            this.barBudgetItem = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonBudgetSourceCategory = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem4 = new DevExpress.XtraBars.BarSubItem();
            this.barButtonDepartment = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonEmployee = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonPayItem = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonGroup1 = new DevExpress.XtraBars.BarButtonGroup();
            this.barButtonItem14 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem15 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem16 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonTransferItem = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonOpeningAccountEntry = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem5 = new DevExpress.XtraBars.BarSubItem();
            this.barButtonReceiptEstimateItem = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonPaymentEstimateItem = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem6 = new DevExpress.XtraBars.BarSubItem();
            this.barButtonReceiptItem = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonPaymentItem = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem7 = new DevExpress.XtraBars.BarSubItem();
            this.barButtonReceiptDepositItem = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonPaymentDepositItem = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonSearch = new DevExpress.XtraBars.BarButtonItem();
            this.barConvertDataItem = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonEmployeeLeasingItem = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonEmployeeContractItem = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonBuildingItem = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonOpeningSupplyEntry = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonLoginItem = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.barButtonOpeningFixedAssetEntry = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticServerDatabaseName = new DevExpress.XtraBars.BarStaticItem();
            this.barButtonUpdateDatabase = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemMutual = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonExchangeRateItem = new DevExpress.XtraBars.BarButtonItem();
            this.barExportData = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonActivity = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonSUIncrement = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonSUDecrement = new DevExpress.XtraBars.BarButtonItem();
            this.imageRibbonLargeCollection = new DevExpress.Utils.ImageCollection();
            this.ribbonPageCategory1 = new DevExpress.XtraBars.Ribbon.RibbonPageCategory();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.pageCategory = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup8 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup7 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup9 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup12 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageStock = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup14 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup15 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.pageVoucher = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonEstimatePageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonCashPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonDepositPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonSalaryPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonFixedAssetPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonInventoryPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup16 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonGeneralPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup10 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup13 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.pageHelp = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup11 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.imageRibbon24Collection = new DevExpress.Utils.ImageCollection();
            this.navBarMainLeft = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarDesktopGroup = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarEstimateItem = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarCashItem = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarDepositItem = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarInventoryItem = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarFixedAssetItem = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarSalaryItem = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGeneralItem = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarReportItem = new DevExpress.XtraNavBar.NavBarItem();
            this.imageNavbarCollection = new DevExpress.Utils.ImageCollection();
            this.defaultLookAndFeel = new DevExpress.LookAndFeel.DefaultLookAndFeel();
            this.mainPanelControl = new TSD.AccountingSoft.WindowsForm.CommonControl.MainPanelControl();
            this.barButtonItem19 = new DevExpress.XtraBars.BarButtonItem();
            this.splashScreenManager = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::TSD.AccountingSoft.WindowsForm.FrmWaitForm), true, true);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonMainMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageRibbonCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageRibbonLargeCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageRibbon24Collection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarMainLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageNavbarCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainPanelControl)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonMainMenu
            // 
            this.ribbonMainMenu.ExpandCollapseItem.Id = 0;
            this.ribbonMainMenu.Images = this.imageRibbonCollection;
            this.ribbonMainMenu.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonMainMenu.ExpandCollapseItem,
            this.barButtonOpenData,
            this.barButtonCloseData,
            this.barButtonPostedDate,
            this.barButtonDbInfo,
            this.barButtonUser,
            this.barButtonChangePassword,
            this.barItemBackUpData,
            this.barItemRestoreData,
            this.barStaticServerName,
            this.barStaticUserName,
            this.barStaticDateItem,
            this.barStaticTimeItem,
            this.barButtonCreateNewDatabase,
            this.barCompanyProfileItem,
            this.barButtonDbOption,
            this.barUnlockBook,
            this.barButtonAudittingLog,
            this.barButtonItem20,
            this.barSalaryItem,
            this.barButtonFAIncrement,
            this.barButtonFADecrement,
            this.barButtonFAArmortization,
            this.barButtonItem25,
            this.barInputInventory,
            this.barButtonOutputInventory,
            this.barButtonUpdateAmountExchangeItem,
            this.barbtnCaptitalAllocateVoucher,
            this.barButtonGeneral,
            this.barButtonBudgetSource,
            this.barCurrencyItem,
            this.barCustomers,
            this.barVendor,
            this.barButtonFixedAssetCategoryItem,
            this.barButtonFixedAssetItem,
            this.barButtonHelpItem,
            this.barButtonRegisterItem,
            this.barButtonAboutItem,
            this.barButtonAutoUpdateItem,
            this.barAccountingObject,
            this.barPlanTemplate,
            this.barButtonStock,
            this.barButtonInventoryItem,
            this.barCapitalAllocateItem,
            this.barButtonBank,
            this.barMergerFundItem,
            this.barVoucherList,
            this.barButtonProject,
            this.barButtonItem3,
            this.barSubItem1,
            this.barButtonItem11,
            this.barButtonItem13,
            this.barSubItem2,
            this.barButtonAccountCategory,
            this.barButtonAccountItem,
            this.barButtonAutoBusiness,
            this.barButtonAccountTranfer,
            this.barSubItem3,
            this.barButtonBudgetChapter,
            this.barButtonBudgetCategory,
            this.barBudgetItem,
            this.barSubItem4,
            this.barButtonEmployee,
            this.barButtonDepartment,
            this.barButtonPayItem,
            this.barButtonGroup1,
            this.barButtonItem14,
            this.barButtonItem15,
            this.barButtonItem16,
            this.barButtonTransferItem,
            this.barButtonOpeningAccountEntry,
            this.barSubItem5,
            this.barButtonReceiptEstimateItem,
            this.barButtonPaymentEstimateItem,
            this.barSubItem6,
            this.barButtonReceiptItem,
            this.barButtonPaymentItem,
            this.barSubItem7,
            this.barButtonPaymentDepositItem,
            this.barButtonReceiptDepositItem,
            this.barButtonItem4,
            this.barButtonSearch,
            this.barConvertDataItem,
            this.barButtonEmployeeLeasingItem,
            this.barButtonEmployeeContractItem,
            this.barButtonBuildingItem,
            this.barButtonOpeningSupplyEntry,
            this.barButtonLoginItem,
            this.barStaticItem1,
            this.barButtonOpeningFixedAssetEntry,
            this.barButtonBudgetSourceCategory,
            this.barStaticServerDatabaseName,
            this.barButtonUpdateDatabase,
            this.barButtonItemMutual,
            this.barButtonExchangeRateItem,
            this.barExportData,
            this.barButtonAutoBusinessParallel,
            this.barButtonActivity,
            this.barButtonItem1,
            this.barButtonRefTypes,
            this.barButtonSUIncrement,
            this.barButtonSUDecrement});
            this.ribbonMainMenu.ItemsVertAlign = DevExpress.Utils.VertAlignment.Top;
            this.ribbonMainMenu.LargeImages = this.imageRibbonLargeCollection;
            this.ribbonMainMenu.Location = new System.Drawing.Point(0, 0);
            this.ribbonMainMenu.MaxItemId = 196;
            this.ribbonMainMenu.Name = "ribbonMainMenu";
            this.ribbonMainMenu.PageCategories.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageCategory[] {
            this.ribbonPageCategory1});
            this.ribbonMainMenu.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.pageCategory,
            this.pageVoucher,
            this.pageHelp});
            this.ribbonMainMenu.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbonMainMenu.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonMainMenu.ShowCategoryInCaption = false;
            this.ribbonMainMenu.ShowToolbarCustomizeItem = false;
            this.ribbonMainMenu.Size = new System.Drawing.Size(1372, 146);
            this.ribbonMainMenu.StatusBar = this.ribbonStatusBar;
            this.ribbonMainMenu.Toolbar.ShowCustomizeItem = false;
            this.ribbonMainMenu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ribbonMainMenu_ItemClick);
            // 
            // imageRibbonCollection
            // 
            this.imageRibbonCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageRibbonCollection.ImageStream")));
            this.imageRibbonCollection.Images.SetKeyName(0, "DOI-MAT-KHAU-NO.png");
            this.imageRibbonCollection.Images.SetKeyName(1, "HO-SO-CO-BAN-NO.png");
            this.imageRibbonCollection.Images.SetKeyName(2, "NGAY-HACH-TOAN-NO.png");
            this.imageRibbonCollection.Images.SetKeyName(3, "NGUOI-DUNG-NO.png");
            this.imageRibbonCollection.Images.SetKeyName(4, "NHAT-KY-TRUY-NHAP-NO.png");
            this.imageRibbonCollection.Images.SetKeyName(5, "THONG-TIN-NO.png");
            this.imageRibbonCollection.Images.SetKeyName(6, "BANG-LUONG.png");
            this.imageRibbonCollection.Images.SetKeyName(7, "DU-TOAN-CHI.png");
            this.imageRibbonCollection.Images.SetKeyName(8, "DU-TOAN-THU.png");
            this.imageRibbonCollection.Images.SetKeyName(9, "GHI-GIAM.png");
            this.imageRibbonCollection.Images.SetKeyName(10, "GHI-TANG.png");
            this.imageRibbonCollection.Images.SetKeyName(11, "GIAY-BAO-CO.png");
            this.imageRibbonCollection.Images.SetKeyName(12, "GIAY-BAO-NO.png");
            this.imageRibbonCollection.Images.SetKeyName(13, "KHAU-HAO.png");
            this.imageRibbonCollection.Images.SetKeyName(14, "TINH-LUONG.png");
            this.imageRibbonCollection.Images.SetKeyName(15, "PHIEU-CHI.png");
            this.imageRibbonCollection.Images.SetKeyName(16, "PHIEU-THU.png");
            this.imageRibbonCollection.Images.SetKeyName(17, "DINH-KHOAN-TU-DONG.png");
            this.imageRibbonCollection.Images.SetKeyName(18, "HE-THONG-TAI-KHOAN.png");
            this.imageRibbonCollection.Images.SetKeyName(19, "NHOM-TAI-KHOAN.png");
            this.imageRibbonCollection.Images.SetKeyName(20, "TAI-KHOAN-KET-CHUYEN.png");
            this.imageRibbonCollection.Images.SetKeyName(21, "CHUONG.png");
            this.imageRibbonCollection.Images.SetKeyName(22, "MUC-TIEU-MUC.png");
            this.imageRibbonCollection.Images.SetKeyName(23, "PHAN-BO-QUY.png");
            this.imageRibbonCollection.Images.SetKeyName(24, "TAI-KHOAN-NGAN-HANG.png");
            this.imageRibbonCollection.Images.SetKeyName(25, "TIEN-TE.png");
            this.imageRibbonCollection.Images.SetKeyName(26, "KHOAN-LUONG.png");
            this.imageRibbonCollection.Images.SetKeyName(27, "NHAN-VIEN.png");
            this.imageRibbonCollection.Images.SetKeyName(28, "PHONG-BAN.png");
            this.imageRibbonCollection.Images.SetKeyName(29, "DOI-TUONG-KHAC.png");
            this.imageRibbonCollection.Images.SetKeyName(30, "NHA-CUNG-CAP.png");
            this.imageRibbonCollection.Images.SetKeyName(31, "NHAN-VIEN-DI-THUE.png");
            this.imageRibbonCollection.Images.SetKeyName(32, "NHAN-VIEN-NGOAI-CQĐD.png");
            this.imageRibbonCollection.Images.SetKeyName(33, "NHA-THUE.png.png");
            // 
            // barButtonOpenData
            // 
            this.barButtonOpenData.AllowRightClickInMenu = false;
            this.barButtonOpenData.Caption = "Mở dữ liệu";
            this.barButtonOpenData.Id = 1;
            this.barButtonOpenData.LargeImageIndex = 10;
            this.barButtonOpenData.Name = "barButtonOpenData";
            // 
            // barButtonCloseData
            // 
            this.barButtonCloseData.AllowRightClickInMenu = false;
            this.barButtonCloseData.Caption = "Đóng dữ liệu";
            this.barButtonCloseData.Id = 2;
            this.barButtonCloseData.LargeImageIndex = 8;
            this.barButtonCloseData.Name = "barButtonCloseData";
            this.barButtonCloseData.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barButtonPostedDate
            // 
            this.barButtonPostedDate.AllowRightClickInMenu = false;
            this.barButtonPostedDate.Caption = "Ngày hạch toán";
            this.barButtonPostedDate.Id = 3;
            this.barButtonPostedDate.ImageIndex = 2;
            this.barButtonPostedDate.Name = "barButtonPostedDate";
            // 
            // barButtonDbInfo
            // 
            this.barButtonDbInfo.AllowRightClickInMenu = false;
            this.barButtonDbInfo.Caption = "Thông tin dữ liệu";
            this.barButtonDbInfo.Id = 4;
            this.barButtonDbInfo.ImageIndex = 5;
            this.barButtonDbInfo.Name = "barButtonDbInfo";
            // 
            // barButtonUser
            // 
            this.barButtonUser.AllowRightClickInMenu = false;
            this.barButtonUser.Caption = "Người dùng";
            this.barButtonUser.Id = 5;
            this.barButtonUser.ImageIndex = 3;
            this.barButtonUser.Name = "barButtonUser";
            this.barButtonUser.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barButtonChangePassword
            // 
            this.barButtonChangePassword.AllowRightClickInMenu = false;
            this.barButtonChangePassword.Caption = "Đổi mật khẩu";
            this.barButtonChangePassword.Id = 6;
            this.barButtonChangePassword.ImageIndex = 0;
            this.barButtonChangePassword.Name = "barButtonChangePassword";
            // 
            // barItemBackUpData
            // 
            this.barItemBackUpData.AllowRightClickInMenu = false;
            this.barItemBackUpData.Caption = "Sao lưu dữ liệu";
            this.barItemBackUpData.Id = 7;
            this.barItemBackUpData.LargeImageIndex = 12;
            this.barItemBackUpData.Name = "barItemBackUpData";
            // 
            // barItemRestoreData
            // 
            this.barItemRestoreData.AllowRightClickInMenu = false;
            this.barItemRestoreData.Caption = "Phục hồi dữ liệu";
            this.barItemRestoreData.Id = 8;
            this.barItemRestoreData.LargeImageIndex = 11;
            this.barItemRestoreData.Name = "barItemRestoreData";
            // 
            // barStaticServerName
            // 
            this.barStaticServerName.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            this.barStaticServerName.Caption = "<b>Máy chủ</b>: ";
            this.barStaticServerName.Id = 9;
            this.barStaticServerName.Name = "barStaticServerName";
            this.barStaticServerName.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barStaticUserName
            // 
            this.barStaticUserName.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            this.barStaticUserName.Caption = "<b>Người dùng</b>: ";
            this.barStaticUserName.Id = 10;
            this.barStaticUserName.Name = "barStaticUserName";
            this.barStaticUserName.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barStaticDateItem
            // 
            this.barStaticDateItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barStaticDateItem.Id = 12;
            this.barStaticDateItem.Name = "barStaticDateItem";
            this.barStaticDateItem.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barStaticTimeItem
            // 
            this.barStaticTimeItem.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barStaticTimeItem.Id = 13;
            this.barStaticTimeItem.Name = "barStaticTimeItem";
            this.barStaticTimeItem.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barButtonCreateNewDatabase
            // 
            this.barButtonCreateNewDatabase.AllowRightClickInMenu = false;
            this.barButtonCreateNewDatabase.Caption = "Tạo mới dữ liệu";
            this.barButtonCreateNewDatabase.Id = 14;
            this.barButtonCreateNewDatabase.LargeImageIndex = 13;
            this.barButtonCreateNewDatabase.Name = "barButtonCreateNewDatabase";
            // 
            // barCompanyProfileItem
            // 
            this.barCompanyProfileItem.AllowRightClickInMenu = false;
            this.barCompanyProfileItem.Caption = "Hồ sơ cơ bản";
            this.barCompanyProfileItem.Id = 15;
            this.barCompanyProfileItem.ImageIndex = 1;
            this.barCompanyProfileItem.Name = "barCompanyProfileItem";
            // 
            // barButtonDbOption
            // 
            this.barButtonDbOption.AllowRightClickInMenu = false;
            this.barButtonDbOption.Caption = "Tùy chọn";
            this.barButtonDbOption.Id = 16;
            this.barButtonDbOption.LargeImageIndex = 14;
            this.barButtonDbOption.Name = "barButtonDbOption";
            // 
            // barUnlockBook
            // 
            this.barUnlockBook.AllowRightClickInMenu = false;
            this.barUnlockBook.Caption = "Khóa sổ/Bỏ khóa sổ";
            this.barUnlockBook.Id = 17;
            this.barUnlockBook.LargeImageIndex = 9;
            this.barUnlockBook.Name = "barUnlockBook";
            // 
            // barButtonAudittingLog
            // 
            this.barButtonAudittingLog.AllowRightClickInMenu = false;
            this.barButtonAudittingLog.Caption = "Nhật ký truy cập";
            this.barButtonAudittingLog.Id = 18;
            this.barButtonAudittingLog.ImageIndex = 4;
            this.barButtonAudittingLog.Name = "barButtonAudittingLog";
            // 
            // barButtonItem20
            // 
            this.barButtonItem20.Caption = "Bảng lương";
            this.barButtonItem20.Id = 25;
            this.barButtonItem20.ImageIndex = 6;
            this.barButtonItem20.Name = "barButtonItem20";
            this.barButtonItem20.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barSalaryItem
            // 
            this.barSalaryItem.Caption = "Tính SHP";
            this.barSalaryItem.Id = 26;
            this.barSalaryItem.LargeImageIndex = 36;
            this.barSalaryItem.Name = "barSalaryItem";
            // 
            // barButtonFAIncrement
            // 
            this.barButtonFAIncrement.Caption = "Ghi tăng";
            this.barButtonFAIncrement.Id = 27;
            this.barButtonFAIncrement.ImageIndex = 10;
            this.barButtonFAIncrement.Name = "barButtonFAIncrement";
            // 
            // barButtonFADecrement
            // 
            this.barButtonFADecrement.Caption = "Ghi giảm";
            this.barButtonFADecrement.Id = 28;
            this.barButtonFADecrement.ImageIndex = 9;
            this.barButtonFADecrement.Name = "barButtonFADecrement";
            // 
            // barButtonFAArmortization
            // 
            this.barButtonFAArmortization.Caption = "Hao mòn";
            this.barButtonFAArmortization.Id = 29;
            this.barButtonFAArmortization.ImageIndex = 13;
            this.barButtonFAArmortization.Name = "barButtonFAArmortization";
            // 
            // barButtonItem25
            // 
            this.barButtonItem25.Caption = "Điều chỉnh";
            this.barButtonItem25.Id = 30;
            this.barButtonItem25.LargeImageIndex = 18;
            this.barButtonItem25.Name = "barButtonItem25";
            this.barButtonItem25.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barInputInventory
            // 
            this.barInputInventory.Caption = "Nhập kho";
            this.barInputInventory.Id = 31;
            this.barInputInventory.LargeImageIndex = 19;
            this.barInputInventory.Name = "barInputInventory";
            // 
            // barButtonOutputInventory
            // 
            this.barButtonOutputInventory.Caption = "Xuất kho";
            this.barButtonOutputInventory.Id = 32;
            this.barButtonOutputInventory.LargeImageIndex = 20;
            this.barButtonOutputInventory.Name = "barButtonOutputInventory";
            // 
            // barButtonUpdateAmountExchangeItem
            // 
            this.barButtonUpdateAmountExchangeItem.Caption = "Cập nhật tỷ giá";
            this.barButtonUpdateAmountExchangeItem.Id = 33;
            this.barButtonUpdateAmountExchangeItem.LargeImageIndex = 21;
            this.barButtonUpdateAmountExchangeItem.Name = "barButtonUpdateAmountExchangeItem";
            this.barButtonUpdateAmountExchangeItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barbtnCaptitalAllocateVoucher
            // 
            this.barbtnCaptitalAllocateVoucher.Caption = "Phân bổ quỹ";
            this.barbtnCaptitalAllocateVoucher.Id = 34;
            this.barbtnCaptitalAllocateVoucher.LargeImageIndex = 22;
            this.barbtnCaptitalAllocateVoucher.Name = "barbtnCaptitalAllocateVoucher";
            this.barbtnCaptitalAllocateVoucher.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barButtonGeneral
            // 
            this.barButtonGeneral.Caption = "Chứng từ chung";
            this.barButtonGeneral.Id = 35;
            this.barButtonGeneral.LargeImageIndex = 23;
            this.barButtonGeneral.Name = "barButtonGeneral";
            // 
            // barButtonBudgetSource
            // 
            this.barButtonBudgetSource.Caption = "Nguồn vốn";
            this.barButtonBudgetSource.Id = 45;
            this.barButtonBudgetSource.LargeImageIndex = 23;
            this.barButtonBudgetSource.Name = "barButtonBudgetSource";
            // 
            // barCurrencyItem
            // 
            this.barCurrencyItem.Caption = "Tiền tệ";
            this.barCurrencyItem.Id = 46;
            this.barCurrencyItem.ImageIndex = 25;
            this.barCurrencyItem.Name = "barCurrencyItem";
            // 
            // barCustomers
            // 
            this.barCustomers.Caption = "Khách hàng";
            this.barCustomers.Id = 47;
            this.barCustomers.Name = "barCustomers";
            this.barCustomers.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barVendor
            // 
            this.barVendor.Caption = "Nhà cung cấp";
            this.barVendor.Id = 50;
            this.barVendor.ImageIndex = 30;
            this.barVendor.Name = "barVendor";
            this.barVendor.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barButtonFixedAssetCategoryItem
            // 
            this.barButtonFixedAssetCategoryItem.Caption = "Nhóm Tài sản cố định";
            this.barButtonFixedAssetCategoryItem.Id = 53;
            this.barButtonFixedAssetCategoryItem.LargeImageIndex = 28;
            this.barButtonFixedAssetCategoryItem.Name = "barButtonFixedAssetCategoryItem";
            // 
            // barButtonFixedAssetItem
            // 
            this.barButtonFixedAssetItem.Caption = "Tài sản cố định";
            this.barButtonFixedAssetItem.Id = 54;
            this.barButtonFixedAssetItem.LargeImageIndex = 29;
            this.barButtonFixedAssetItem.Name = "barButtonFixedAssetItem";
            // 
            // barButtonHelpItem
            // 
            this.barButtonHelpItem.Caption = "Nội dung trợ giúp";
            this.barButtonHelpItem.Id = 55;
            this.barButtonHelpItem.LargeImageIndex = 4;
            this.barButtonHelpItem.Name = "barButtonHelpItem";
            // 
            // barButtonRegisterItem
            // 
            this.barButtonRegisterItem.Caption = "Đăng ký bản quyền";
            this.barButtonRegisterItem.Id = 56;
            this.barButtonRegisterItem.LargeImageIndex = 7;
            this.barButtonRegisterItem.Name = "barButtonRegisterItem";
            // 
            // barButtonAboutItem
            // 
            this.barButtonAboutItem.Caption = "Thông tin chương trình";
            this.barButtonAboutItem.Id = 57;
            this.barButtonAboutItem.LargeImageIndex = 5;
            this.barButtonAboutItem.Name = "barButtonAboutItem";
            // 
            // barButtonAutoUpdateItem
            // 
            this.barButtonAutoUpdateItem.Caption = "Cập nhật tự động";
            this.barButtonAutoUpdateItem.Id = 58;
            this.barButtonAutoUpdateItem.LargeImageIndex = 6;
            this.barButtonAutoUpdateItem.Name = "barButtonAutoUpdateItem";
            // 
            // barAccountingObject
            // 
            this.barAccountingObject.Caption = "Đối tượng";
            this.barAccountingObject.Id = 59;
            this.barAccountingObject.ImageIndex = 29;
            this.barAccountingObject.Name = "barAccountingObject";
            // 
            // barPlanTemplate
            // 
            this.barPlanTemplate.Caption = "Mẫu dự toán";
            this.barPlanTemplate.Id = 60;
            this.barPlanTemplate.LargeImageIndex = 26;
            this.barPlanTemplate.Name = "barPlanTemplate";
            // 
            // barButtonStock
            // 
            this.barButtonStock.Caption = "Kho";
            this.barButtonStock.Id = 63;
            this.barButtonStock.LargeImageIndex = 30;
            this.barButtonStock.Name = "barButtonStock";
            this.barButtonStock.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barButtonInventoryItem
            // 
            this.barButtonInventoryItem.Caption = "Công cụ dụng cụ";
            this.barButtonInventoryItem.Id = 64;
            this.barButtonInventoryItem.LargeImageIndex = 32;
            this.barButtonInventoryItem.Name = "barButtonInventoryItem";
            // 
            // barCapitalAllocateItem
            // 
            this.barCapitalAllocateItem.Caption = "Phân bổ quỹ";
            this.barCapitalAllocateItem.Id = 66;
            this.barCapitalAllocateItem.ImageIndex = 23;
            this.barCapitalAllocateItem.Name = "barCapitalAllocateItem";
            this.barCapitalAllocateItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barButtonBank
            // 
            this.barButtonBank.Caption = "Tài khoản ngân hàng";
            this.barButtonBank.Id = 68;
            this.barButtonBank.ImageIndex = 24;
            this.barButtonBank.Name = "barButtonBank";
            // 
            // barMergerFundItem
            // 
            this.barMergerFundItem.Caption = "Quỹ sát nhập";
            this.barMergerFundItem.Id = 69;
            this.barMergerFundItem.Name = "barMergerFundItem";
            this.barMergerFundItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barVoucherList
            // 
            this.barVoucherList.Caption = "Chứng từ ghi sổ";
            this.barVoucherList.Id = 71;
            this.barVoucherList.Name = "barVoucherList";
            this.barVoucherList.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barButtonProject
            // 
            this.barButtonProject.Caption = "Dự án";
            this.barButtonProject.Id = 78;
            this.barButtonProject.LargeImageIndex = 31;
            this.barButtonProject.Name = "barButtonProject";
            this.barButtonProject.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "barButtonItem3";
            this.barButtonItem3.Id = 88;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "barSubItem1";
            this.barSubItem1.Id = 90;
            this.barSubItem1.Name = "barSubItem1";
            // 
            // barButtonItem11
            // 
            this.barButtonItem11.Caption = "barButtonItem11";
            this.barButtonItem11.Id = 93;
            this.barButtonItem11.Name = "barButtonItem11";
            // 
            // barButtonItem13
            // 
            this.barButtonItem13.Caption = "barButtonItem13";
            this.barButtonItem13.Id = 96;
            this.barButtonItem13.Name = "barButtonItem13";
            // 
            // barSubItem2
            // 
            this.barSubItem2.Caption = "Tài khoản";
            this.barSubItem2.Id = 99;
            this.barSubItem2.LargeImageIndex = 24;
            this.barSubItem2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonAccountCategory),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonAccountItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonAutoBusiness, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonAccountTranfer),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonAutoBusinessParallel),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonRefTypes)});
            this.barSubItem2.Name = "barSubItem2";
            // 
            // barButtonAccountCategory
            // 
            this.barButtonAccountCategory.Caption = "Nhóm tài khoản";
            this.barButtonAccountCategory.Id = 100;
            this.barButtonAccountCategory.ImageIndex = 18;
            this.barButtonAccountCategory.Name = "barButtonAccountCategory";
            this.barButtonAccountCategory.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barButtonAccountItem
            // 
            this.barButtonAccountItem.Caption = "Hệ thống tài khoản";
            this.barButtonAccountItem.Id = 101;
            this.barButtonAccountItem.ImageIndex = 19;
            this.barButtonAccountItem.Name = "barButtonAccountItem";
            // 
            // barButtonAutoBusiness
            // 
            this.barButtonAutoBusiness.Caption = "Định khoản tự động";
            this.barButtonAutoBusiness.Id = 102;
            this.barButtonAutoBusiness.ImageIndex = 17;
            this.barButtonAutoBusiness.Name = "barButtonAutoBusiness";
            // 
            // barButtonAccountTranfer
            // 
            this.barButtonAccountTranfer.Caption = "Tài khoản kết chuyển";
            this.barButtonAccountTranfer.Id = 103;
            this.barButtonAccountTranfer.ImageIndex = 20;
            this.barButtonAccountTranfer.Name = "barButtonAccountTranfer";
            // 
            // barButtonAutoBusinessParallel
            // 
            this.barButtonAutoBusinessParallel.Caption = "Định khoản đồng thời";
            this.barButtonAutoBusinessParallel.Id = 187;
            this.barButtonAutoBusinessParallel.ImageIndex = 1;
            this.barButtonAutoBusinessParallel.Name = "barButtonAutoBusinessParallel";
            // 
            // barButtonRefTypes
            // 
            this.barButtonRefTypes.Caption = "Tài khoản ngầm định";
            this.barButtonRefTypes.Glyph = global::TSD.AccountingSoft.WindowsForm.Properties.Resources.icon_tai_khoan_ngam_dinh;
            this.barButtonRefTypes.Id = 191;
            this.barButtonRefTypes.Name = "barButtonRefTypes";
            // 
            // barSubItem3
            // 
            this.barSubItem3.Caption = "Mục lục ngân sách";
            this.barSubItem3.Id = 104;
            this.barSubItem3.LargeImageIndex = 25;
            this.barSubItem3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.None, false, this.barButtonBudgetChapter, false),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.None, false, this.barButtonBudgetCategory, false),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBudgetItem, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonBudgetSourceCategory)});
            this.barSubItem3.Name = "barSubItem3";
            // 
            // barButtonBudgetChapter
            // 
            this.barButtonBudgetChapter.Caption = "Chương";
            this.barButtonBudgetChapter.Id = 105;
            this.barButtonBudgetChapter.Name = "barButtonBudgetChapter";
            // 
            // barButtonBudgetCategory
            // 
            this.barButtonBudgetCategory.Caption = "Loại khoản";
            this.barButtonBudgetCategory.Id = 106;
            this.barButtonBudgetCategory.Name = "barButtonBudgetCategory";
            // 
            // barBudgetItem
            // 
            this.barBudgetItem.Caption = "Mục- tiểu mục";
            this.barBudgetItem.Id = 107;
            this.barBudgetItem.ImageIndex = 22;
            this.barBudgetItem.Name = "barBudgetItem";
            // 
            // barButtonBudgetSourceCategory
            // 
            this.barButtonBudgetSourceCategory.Caption = "Loại nguồn vốn";
            this.barButtonBudgetSourceCategory.Id = 175;
            this.barButtonBudgetSourceCategory.ImageIndex = 21;
            this.barButtonBudgetSourceCategory.Name = "barButtonBudgetSourceCategory";
            this.barButtonBudgetSourceCategory.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barSubItem4
            // 
            this.barSubItem4.Caption = "Nhân sự";
            this.barSubItem4.Id = 108;
            this.barSubItem4.LargeImageIndex = 27;
            this.barSubItem4.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonDepartment),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonEmployee, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonPayItem)});
            this.barSubItem4.Name = "barSubItem4";
            // 
            // barButtonDepartment
            // 
            this.barButtonDepartment.Caption = "Phòng ban";
            this.barButtonDepartment.Id = 110;
            this.barButtonDepartment.ImageIndex = 28;
            this.barButtonDepartment.Name = "barButtonDepartment";
            // 
            // barButtonEmployee
            // 
            this.barButtonEmployee.Caption = "Cán bộ";
            this.barButtonEmployee.Id = 109;
            this.barButtonEmployee.ImageIndex = 27;
            this.barButtonEmployee.Name = "barButtonEmployee";
            // 
            // barButtonPayItem
            // 
            this.barButtonPayItem.Caption = "Khoản lương";
            this.barButtonPayItem.Id = 111;
            this.barButtonPayItem.ImageIndex = 26;
            this.barButtonPayItem.Name = "barButtonPayItem";
            // 
            // barButtonGroup1
            // 
            this.barButtonGroup1.Caption = "barButtonGroup1";
            this.barButtonGroup1.Id = 112;
            this.barButtonGroup1.Name = "barButtonGroup1";
            // 
            // barButtonItem14
            // 
            this.barButtonItem14.Caption = "barButtonItem14";
            this.barButtonItem14.Id = 118;
            this.barButtonItem14.Name = "barButtonItem14";
            // 
            // barButtonItem15
            // 
            this.barButtonItem15.Caption = "barButtonItem15";
            this.barButtonItem15.Id = 119;
            this.barButtonItem15.Name = "barButtonItem15";
            // 
            // barButtonItem16
            // 
            this.barButtonItem16.Caption = "barButtonItem16";
            this.barButtonItem16.Id = 120;
            this.barButtonItem16.Name = "barButtonItem16";
            // 
            // barButtonTransferItem
            // 
            this.barButtonTransferItem.Caption = "Kết chuyển";
            this.barButtonTransferItem.Id = 123;
            this.barButtonTransferItem.LargeImageIndex = 34;
            this.barButtonTransferItem.Name = "barButtonTransferItem";
            // 
            // barButtonOpeningAccountEntry
            // 
            this.barButtonOpeningAccountEntry.Caption = "Số dư đầu kỳ tài khoản";
            this.barButtonOpeningAccountEntry.Glyph = global::TSD.AccountingSoft.WindowsForm.Properties.Resources.icon_so_du_dau_ki;
            this.barButtonOpeningAccountEntry.Id = 125;
            this.barButtonOpeningAccountEntry.Name = "barButtonOpeningAccountEntry";
            // 
            // barSubItem5
            // 
            this.barSubItem5.Caption = "Lập dự toán";
            this.barSubItem5.Id = 126;
            this.barSubItem5.LargeImageIndex = 15;
            this.barSubItem5.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonReceiptEstimateItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonPaymentEstimateItem)});
            this.barSubItem5.Name = "barSubItem5";
            // 
            // barButtonReceiptEstimateItem
            // 
            this.barButtonReceiptEstimateItem.Caption = "Dự toán thu";
            this.barButtonReceiptEstimateItem.Id = 127;
            this.barButtonReceiptEstimateItem.ImageIndex = 8;
            this.barButtonReceiptEstimateItem.Name = "barButtonReceiptEstimateItem";
            this.barButtonReceiptEstimateItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barButtonPaymentEstimateItem
            // 
            this.barButtonPaymentEstimateItem.Caption = "Dự toán chi";
            this.barButtonPaymentEstimateItem.Id = 128;
            this.barButtonPaymentEstimateItem.ImageIndex = 7;
            this.barButtonPaymentEstimateItem.Name = "barButtonPaymentEstimateItem";
            // 
            // barSubItem6
            // 
            this.barSubItem6.Caption = "Tiền mặt";
            this.barSubItem6.Id = 129;
            this.barSubItem6.LargeImageIndex = 16;
            this.barSubItem6.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonReceiptItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonPaymentItem)});
            this.barSubItem6.Name = "barSubItem6";
            // 
            // barButtonReceiptItem
            // 
            this.barButtonReceiptItem.Caption = "Phiếu thu";
            this.barButtonReceiptItem.Id = 131;
            this.barButtonReceiptItem.ImageIndex = 16;
            this.barButtonReceiptItem.Name = "barButtonReceiptItem";
            // 
            // barButtonPaymentItem
            // 
            this.barButtonPaymentItem.Caption = "Phiếu chi";
            this.barButtonPaymentItem.Id = 132;
            this.barButtonPaymentItem.ImageIndex = 15;
            this.barButtonPaymentItem.Name = "barButtonPaymentItem";
            // 
            // barSubItem7
            // 
            this.barSubItem7.Caption = "Tiền gửi";
            this.barSubItem7.Id = 133;
            this.barSubItem7.LargeImageIndex = 17;
            this.barSubItem7.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonReceiptDepositItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonPaymentDepositItem)});
            this.barSubItem7.Name = "barSubItem7";
            // 
            // barButtonReceiptDepositItem
            // 
            this.barButtonReceiptDepositItem.Caption = "Thu tiền gửi";
            this.barButtonReceiptDepositItem.Id = 135;
            this.barButtonReceiptDepositItem.ImageIndex = 12;
            this.barButtonReceiptDepositItem.Name = "barButtonReceiptDepositItem";
            // 
            // barButtonPaymentDepositItem
            // 
            this.barButtonPaymentDepositItem.Caption = "Chi tiền gửi";
            this.barButtonPaymentDepositItem.Id = 134;
            this.barButtonPaymentDepositItem.ImageIndex = 11;
            this.barButtonPaymentDepositItem.Name = "barButtonPaymentDepositItem";
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "barButtonItem4";
            this.barButtonItem4.Id = 136;
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // barButtonSearch
            // 
            this.barButtonSearch.Caption = "Tìm kiếm chứng từ";
            this.barButtonSearch.Id = 137;
            this.barButtonSearch.LargeImageIndex = 35;
            this.barButtonSearch.Name = "barButtonSearch";
            // 
            // barConvertDataItem
            // 
            this.barConvertDataItem.AllowRightClickInMenu = false;
            this.barConvertDataItem.Caption = "Chuyển đổi dữ liệu";
            this.barConvertDataItem.Id = 163;
            this.barConvertDataItem.LargeImageIndex = 33;
            this.barConvertDataItem.Name = "barConvertDataItem";
            // 
            // barButtonEmployeeLeasingItem
            // 
            this.barButtonEmployeeLeasingItem.Caption = "Nhân viên ngoài CQĐD";
            this.barButtonEmployeeLeasingItem.Id = 164;
            this.barButtonEmployeeLeasingItem.ImageIndex = 32;
            this.barButtonEmployeeLeasingItem.Name = "barButtonEmployeeLeasingItem";
            this.barButtonEmployeeLeasingItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barButtonEmployeeContractItem
            // 
            this.barButtonEmployeeContractItem.Caption = "Người lao động thuê";
            this.barButtonEmployeeContractItem.Id = 165;
            this.barButtonEmployeeContractItem.ImageIndex = 31;
            this.barButtonEmployeeContractItem.Name = "barButtonEmployeeContractItem";
            this.barButtonEmployeeContractItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barButtonBuildingItem
            // 
            this.barButtonBuildingItem.Caption = "Nhà thuê";
            this.barButtonBuildingItem.Id = 166;
            this.barButtonBuildingItem.ImageIndex = 33;
            this.barButtonBuildingItem.Name = "barButtonBuildingItem";
            this.barButtonBuildingItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barButtonOpeningSupplyEntry
            // 
            this.barButtonOpeningSupplyEntry.Caption = "Số dư đầu kỳ CCDC";
            this.barButtonOpeningSupplyEntry.Id = 168;
            this.barButtonOpeningSupplyEntry.LargeGlyph = global::TSD.AccountingSoft.WindowsForm.Properties.Resources.CHUNG_TU;
            this.barButtonOpeningSupplyEntry.Name = "barButtonOpeningSupplyEntry";
            // 
            // barButtonLoginItem
            // 
            this.barButtonLoginItem.Caption = "Đăng nhập";
            this.barButtonLoginItem.Id = 169;
            this.barButtonLoginItem.LargeImageIndex = 37;
            this.barButtonLoginItem.Name = "barButtonLoginItem";
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barStaticItem1.Id = 170;
            this.barStaticItem1.Name = "barStaticItem1";
            this.barStaticItem1.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barButtonOpeningFixedAssetEntry
            // 
            this.barButtonOpeningFixedAssetEntry.Caption = "Số dư đầu kỳ tài sản";
            this.barButtonOpeningFixedAssetEntry.Id = 172;
            this.barButtonOpeningFixedAssetEntry.Name = "barButtonOpeningFixedAssetEntry";
            this.barButtonOpeningFixedAssetEntry.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barStaticServerDatabaseName
            // 
            this.barStaticServerDatabaseName.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            this.barStaticServerDatabaseName.Caption = "<b>Tên dữ liệu</b>: ";
            this.barStaticServerDatabaseName.Id = 182;
            this.barStaticServerDatabaseName.Name = "barStaticServerDatabaseName";
            this.barStaticServerDatabaseName.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barButtonUpdateDatabase
            // 
            this.barButtonUpdateDatabase.Caption = "Cập nhật cơ sở dữ liệu";
            this.barButtonUpdateDatabase.Id = 183;
            this.barButtonUpdateDatabase.LargeImageIndex = 38;
            this.barButtonUpdateDatabase.Name = "barButtonUpdateDatabase";
            // 
            // barButtonItemMutual
            // 
            this.barButtonItemMutual.Caption = "Nhà hỗ tương";
            this.barButtonItemMutual.Id = 184;
            this.barButtonItemMutual.Name = "barButtonItemMutual";
            this.barButtonItemMutual.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barButtonExchangeRateItem
            // 
            this.barButtonExchangeRateItem.Caption = "Tỷ giá dự toán";
            this.barButtonExchangeRateItem.Id = 185;
            this.barButtonExchangeRateItem.ImageIndex = 26;
            this.barButtonExchangeRateItem.Name = "barButtonExchangeRateItem";
            this.barButtonExchangeRateItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barExportData
            // 
            this.barExportData.Caption = "Xuất khẩu dữ liệu";
            this.barExportData.Id = 186;
            this.barExportData.ImageIndex = 7;
            this.barExportData.LargeImageIndex = 10;
            this.barExportData.Name = "barExportData";
            // 
            // barButtonActivity
            // 
            this.barButtonActivity.Caption = "Hoạt động sự nghiệp";
            this.barButtonActivity.Glyph = global::TSD.AccountingSoft.WindowsForm.Properties.Resources.icon_hoat_dong_su_nghiep;
            this.barButtonActivity.Id = 189;
            this.barButtonActivity.Name = "barButtonActivity";
            this.barButtonActivity.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 190;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonSUIncrement
            // 
            this.barButtonSUIncrement.Caption = "Ghi tăng CCDC";
            this.barButtonSUIncrement.Id = 193;
            this.barButtonSUIncrement.LargeImageIndex = 32;
            this.barButtonSUIncrement.Name = "barButtonSUIncrement";
            // 
            // barButtonSUDecrement
            // 
            this.barButtonSUDecrement.Caption = "Ghi giảm CCDC";
            this.barButtonSUDecrement.Id = 194;
            this.barButtonSUDecrement.LargeImageIndex = 32;
            this.barButtonSUDecrement.Name = "barButtonSUDecrement";
            // 
            // imageRibbonLargeCollection
            // 
            this.imageRibbonLargeCollection.ImageSize = new System.Drawing.Size(32, 32);
            this.imageRibbonLargeCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageRibbonLargeCollection.ImageStream")));
            this.imageRibbonLargeCollection.Images.SetKeyName(0, "clock-user.png");
            this.imageRibbonLargeCollection.Images.SetKeyName(1, "report-user.png");
            this.imageRibbonLargeCollection.Images.SetKeyName(2, "legal_registered.png");
            this.imageRibbonLargeCollection.Images.SetKeyName(3, "application-steps.png");
            this.imageRibbonLargeCollection.Images.SetKeyName(4, "application-help.png");
            this.imageRibbonLargeCollection.Images.SetKeyName(5, "application-info.png");
            this.imageRibbonLargeCollection.Images.SetKeyName(6, "application-internet.png");
            this.imageRibbonLargeCollection.Images.SetKeyName(7, "application-key.png");
            this.imageRibbonLargeCollection.Images.SetKeyName(8, "DONG-NO.png");
            this.imageRibbonLargeCollection.Images.SetKeyName(9, "KHOA-SO-NO.png");
            this.imageRibbonLargeCollection.Images.SetKeyName(10, "MO-NO.png");
            this.imageRibbonLargeCollection.Images.SetKeyName(11, "PHUC-HOI-NO.png");
            this.imageRibbonLargeCollection.Images.SetKeyName(12, "SAO-LUU-NO.png");
            this.imageRibbonLargeCollection.Images.SetKeyName(13, "THEM-NO.png");
            this.imageRibbonLargeCollection.Images.SetKeyName(14, "TUY-CHON-NO.png");
            this.imageRibbonLargeCollection.Images.SetKeyName(15, "DU-TOAN.png");
            this.imageRibbonLargeCollection.Images.SetKeyName(16, "TIEN-MAT.png");
            this.imageRibbonLargeCollection.Images.SetKeyName(17, "TIEN-GUI.png");
            this.imageRibbonLargeCollection.Images.SetKeyName(18, "DIEU-CHINH.png");
            this.imageRibbonLargeCollection.Images.SetKeyName(19, "NHAP-KHO.png");
            this.imageRibbonLargeCollection.Images.SetKeyName(20, "XUAT-KHO.png");
            this.imageRibbonLargeCollection.Images.SetKeyName(21, "CAP-NHAT-TI-GIA.png");
            this.imageRibbonLargeCollection.Images.SetKeyName(22, "PHAN-BO-QUY.png");
            this.imageRibbonLargeCollection.Images.SetKeyName(23, "CHUNG-TU-CHUNG.png");
            this.imageRibbonLargeCollection.Images.SetKeyName(24, "TAI-KHOAN.png");
            this.imageRibbonLargeCollection.Images.SetKeyName(25, "MUC-LUC-NGAN-SACH.png");
            this.imageRibbonLargeCollection.Images.SetKeyName(26, "MAU-DU-TOAN.png");
            this.imageRibbonLargeCollection.Images.SetKeyName(27, "NHAN-SU.png");
            this.imageRibbonLargeCollection.Images.SetKeyName(28, "NHOM-TSCD.png");
            this.imageRibbonLargeCollection.Images.SetKeyName(29, "TAI-SAN-CO-DINH.png");
            this.imageRibbonLargeCollection.Images.SetKeyName(30, "KHO.png");
            this.imageRibbonLargeCollection.Images.SetKeyName(31, "DU-AN.png");
            this.imageRibbonLargeCollection.Images.SetKeyName(32, "VAT-TU-CCDC.png");
            this.imageRibbonLargeCollection.Images.SetKeyName(33, "CHUYEN-DOI-CSDL.png");
            this.imageRibbonLargeCollection.Images.SetKeyName(34, "KET-CHUYEN.png");
            this.imageRibbonLargeCollection.Images.SetKeyName(35, "TIM-KIEM-CHUNG-TU.png");
            this.imageRibbonLargeCollection.Images.SetKeyName(36, "TINH-LUONG.png");
            this.imageRibbonLargeCollection.Images.SetKeyName(37, "DANG-NHAP.png");
            this.imageRibbonLargeCollection.Images.SetKeyName(38, "UPDATE-DATABASE.png");
            // 
            // ribbonPageCategory1
            // 
            this.ribbonPageCategory1.Name = "ribbonPageCategory1";
            this.ribbonPageCategory1.Text = "ribbonPageCategory1";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup3});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Hệ thống";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonOpenData);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonCloseData);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonLoginItem);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonPostedDate);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonDbInfo);
            this.ribbonPageGroup2.ItemLinks.Add(this.barCompanyProfileItem);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonDbOption);
            this.ribbonPageGroup2.ItemLinks.Add(this.barUnlockBook);
            this.ribbonPageGroup2.ItemLinks.Add(this.barExportData);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonUser);
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonChangePassword);
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonAudittingLog);
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonCreateNewDatabase, true);
            this.ribbonPageGroup3.ItemLinks.Add(this.barItemBackUpData);
            this.ribbonPageGroup3.ItemLinks.Add(this.barItemRestoreData);
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonUpdateDatabase);
            this.ribbonPageGroup3.ItemLinks.Add(this.barConvertDataItem);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            // 
            // pageCategory
            // 
            this.pageCategory.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup5,
            this.ribbonPageGroup6,
            this.ribbonPageGroup8,
            this.ribbonPageGroup7,
            this.ribbonPageGroup9,
            this.ribbonPageGroup12,
            this.ribbonPageStock,
            this.ribbonPageGroup4,
            this.ribbonPageGroup14,
            this.ribbonPageGroup15});
            this.pageCategory.Name = "pageCategory";
            this.pageCategory.Text = "Danh mục";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.ItemLinks.Add(this.barSubItem2);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            // 
            // ribbonPageGroup6
            // 
            this.ribbonPageGroup6.AllowTextClipping = false;
            this.ribbonPageGroup6.ItemLinks.Add(this.barSubItem3);
            this.ribbonPageGroup6.ItemLinks.Add(this.barPlanTemplate);
            this.ribbonPageGroup6.Name = "ribbonPageGroup6";
            // 
            // ribbonPageGroup8
            // 
            this.ribbonPageGroup8.ItemLinks.Add(this.barButtonBudgetSource);
            this.ribbonPageGroup8.ItemLinks.Add(this.barCapitalAllocateItem);
            this.ribbonPageGroup8.ItemLinks.Add(this.barCurrencyItem);
            this.ribbonPageGroup8.ItemLinks.Add(this.barButtonBank);
            this.ribbonPageGroup8.ItemLinks.Add(this.barButtonExchangeRateItem, true);
            this.ribbonPageGroup8.Name = "ribbonPageGroup8";
            // 
            // ribbonPageGroup7
            // 
            this.ribbonPageGroup7.AllowTextClipping = false;
            this.ribbonPageGroup7.ItemLinks.Add(this.barSubItem4);
            this.ribbonPageGroup7.Name = "ribbonPageGroup7";
            // 
            // ribbonPageGroup9
            // 
            this.ribbonPageGroup9.ItemLinks.Add(this.barCustomers);
            this.ribbonPageGroup9.ItemLinks.Add(this.barVendor);
            this.ribbonPageGroup9.ItemLinks.Add(this.barAccountingObject);
            this.ribbonPageGroup9.Name = "ribbonPageGroup9";
            // 
            // ribbonPageGroup12
            // 
            this.ribbonPageGroup12.ItemLinks.Add(this.barButtonFixedAssetCategoryItem);
            this.ribbonPageGroup12.ItemLinks.Add(this.barButtonFixedAssetItem);
            this.ribbonPageGroup12.Name = "ribbonPageGroup12";
            this.ribbonPageGroup12.Text = "Tài sản";
            // 
            // ribbonPageStock
            // 
            this.ribbonPageStock.ItemLinks.Add(this.barButtonStock);
            this.ribbonPageStock.ItemLinks.Add(this.barButtonInventoryItem);
            this.ribbonPageStock.Name = "ribbonPageStock";
            this.ribbonPageStock.Text = "Kho";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.barButtonProject);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Visible = false;
            // 
            // ribbonPageGroup14
            // 
            this.ribbonPageGroup14.ItemLinks.Add(this.barButtonEmployeeLeasingItem);
            this.ribbonPageGroup14.ItemLinks.Add(this.barButtonEmployeeContractItem);
            this.ribbonPageGroup14.Name = "ribbonPageGroup14";
            this.ribbonPageGroup14.Text = "Thuyết minh dự toán";
            this.ribbonPageGroup14.Visible = false;
            // 
            // ribbonPageGroup15
            // 
            this.ribbonPageGroup15.ItemLinks.Add(this.barMergerFundItem);
            this.ribbonPageGroup15.ItemLinks.Add(this.barVoucherList);
            this.ribbonPageGroup15.ItemLinks.Add(this.barButtonItemMutual);
            this.ribbonPageGroup15.ItemLinks.Add(this.barButtonBuildingItem);
            this.ribbonPageGroup15.ItemLinks.Add(this.barButtonActivity);
            this.ribbonPageGroup15.Name = "ribbonPageGroup15";
            this.ribbonPageGroup15.Visible = false;
            // 
            // pageVoucher
            // 
            this.pageVoucher.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonEstimatePageGroup,
            this.ribbonCashPageGroup,
            this.ribbonDepositPageGroup,
            this.ribbonSalaryPageGroup,
            this.ribbonFixedAssetPageGroup,
            this.ribbonInventoryPageGroup,
            this.ribbonPageGroup16,
            this.ribbonGeneralPageGroup,
            this.ribbonPageGroup10,
            this.ribbonPageGroup13});
            this.pageVoucher.Name = "pageVoucher";
            this.pageVoucher.Text = "Chứng từ";
            // 
            // ribbonEstimatePageGroup
            // 
            this.ribbonEstimatePageGroup.AllowTextClipping = false;
            this.ribbonEstimatePageGroup.ItemLinks.Add(this.barSubItem5);
            this.ribbonEstimatePageGroup.Name = "ribbonEstimatePageGroup";
            this.ribbonEstimatePageGroup.Text = "Dự toán";
            // 
            // ribbonCashPageGroup
            // 
            this.ribbonCashPageGroup.AllowTextClipping = false;
            this.ribbonCashPageGroup.ItemLinks.Add(this.barSubItem6);
            this.ribbonCashPageGroup.Name = "ribbonCashPageGroup";
            this.ribbonCashPageGroup.Text = "Tiền mặt";
            // 
            // ribbonDepositPageGroup
            // 
            this.ribbonDepositPageGroup.AllowTextClipping = false;
            this.ribbonDepositPageGroup.ItemLinks.Add(this.barSubItem7);
            this.ribbonDepositPageGroup.Name = "ribbonDepositPageGroup";
            this.ribbonDepositPageGroup.Text = "Tiền gửi";
            // 
            // ribbonSalaryPageGroup
            // 
            this.ribbonSalaryPageGroup.AllowTextClipping = false;
            this.ribbonSalaryPageGroup.ItemLinks.Add(this.barButtonItem20);
            this.ribbonSalaryPageGroup.ItemLinks.Add(this.barSalaryItem);
            this.ribbonSalaryPageGroup.Name = "ribbonSalaryPageGroup";
            this.ribbonSalaryPageGroup.Text = "Tính lương";
            // 
            // ribbonFixedAssetPageGroup
            // 
            this.ribbonFixedAssetPageGroup.AllowTextClipping = false;
            this.ribbonFixedAssetPageGroup.ItemLinks.Add(this.barButtonFAIncrement);
            this.ribbonFixedAssetPageGroup.ItemLinks.Add(this.barButtonFADecrement);
            this.ribbonFixedAssetPageGroup.ItemLinks.Add(this.barButtonFAArmortization);
            this.ribbonFixedAssetPageGroup.ItemLinks.Add(this.barButtonItem25);
            this.ribbonFixedAssetPageGroup.Name = "ribbonFixedAssetPageGroup";
            this.ribbonFixedAssetPageGroup.Text = "Tài sản";
            // 
            // ribbonInventoryPageGroup
            // 
            this.ribbonInventoryPageGroup.AllowTextClipping = false;
            this.ribbonInventoryPageGroup.ItemLinks.Add(this.barInputInventory);
            this.ribbonInventoryPageGroup.ItemLinks.Add(this.barButtonOutputInventory);
            this.ribbonInventoryPageGroup.Name = "ribbonInventoryPageGroup";
            this.ribbonInventoryPageGroup.Text = "Vật tư";
            this.ribbonInventoryPageGroup.Visible = false;
            // 
            // ribbonPageGroup16
            // 
            this.ribbonPageGroup16.ItemLinks.Add(this.barButtonOpeningSupplyEntry);
            this.ribbonPageGroup16.ItemLinks.Add(this.barButtonSUIncrement);
            this.ribbonPageGroup16.ItemLinks.Add(this.barButtonSUDecrement);
            this.ribbonPageGroup16.Name = "ribbonPageGroup16";
            this.ribbonPageGroup16.Text = "CCDC";
            // 
            // ribbonGeneralPageGroup
            // 
            this.ribbonGeneralPageGroup.AllowTextClipping = false;
            this.ribbonGeneralPageGroup.ItemLinks.Add(this.barButtonUpdateAmountExchangeItem);
            this.ribbonGeneralPageGroup.ItemLinks.Add(this.barbtnCaptitalAllocateVoucher);
            this.ribbonGeneralPageGroup.ItemLinks.Add(this.barButtonGeneral, true);
            this.ribbonGeneralPageGroup.ItemLinks.Add(this.barButtonTransferItem);
            this.ribbonGeneralPageGroup.Name = "ribbonGeneralPageGroup";
            this.ribbonGeneralPageGroup.Text = "Tổng hợp";
            // 
            // ribbonPageGroup10
            // 
            this.ribbonPageGroup10.ItemLinks.Add(this.barButtonOpeningAccountEntry);
            this.ribbonPageGroup10.ItemLinks.Add(this.barButtonOpeningFixedAssetEntry);
            this.ribbonPageGroup10.Name = "ribbonPageGroup10";
            this.ribbonPageGroup10.Text = "Số dư đầu kỳ";
            // 
            // ribbonPageGroup13
            // 
            this.ribbonPageGroup13.ItemLinks.Add(this.barButtonSearch);
            this.ribbonPageGroup13.Name = "ribbonPageGroup13";
            // 
            // pageHelp
            // 
            this.pageHelp.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup11});
            this.pageHelp.Name = "pageHelp";
            this.pageHelp.Text = "Trợ giúp";
            // 
            // ribbonPageGroup11
            // 
            this.ribbonPageGroup11.ItemLinks.Add(this.barButtonHelpItem);
            this.ribbonPageGroup11.ItemLinks.Add(this.barButtonRegisterItem);
            this.ribbonPageGroup11.ItemLinks.Add(this.barButtonAboutItem);
            this.ribbonPageGroup11.ItemLinks.Add(this.barButtonAutoUpdateItem);
            this.ribbonPageGroup11.Name = "ribbonPageGroup11";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.barStaticServerName);
            this.ribbonStatusBar.ItemLinks.Add(this.barStaticItem1, true);
            this.ribbonStatusBar.ItemLinks.Add(this.barStaticDateItem, true);
            this.ribbonStatusBar.ItemLinks.Add(this.barStaticTimeItem, true);
            this.ribbonStatusBar.ItemLinks.Add(this.barStaticServerDatabaseName, true);
            this.ribbonStatusBar.ItemLinks.Add(this.barStaticUserName, true);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 602);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbonMainMenu;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1372, 27);
            // 
            // imageRibbon24Collection
            // 
            this.imageRibbon24Collection.ImageSize = new System.Drawing.Size(24, 24);
            this.imageRibbon24Collection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageRibbon24Collection.ImageStream")));
            this.imageRibbon24Collection.Images.SetKeyName(0, "report-user.png");
            // 
            // navBarMainLeft
            // 
            this.navBarMainLeft.ActiveGroup = this.navBarDesktopGroup;
            this.navBarMainLeft.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.navBarMainLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.navBarMainLeft.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarDesktopGroup});
            this.navBarMainLeft.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.navBarDepositItem,
            this.navBarCashItem,
            this.navBarEstimateItem,
            this.navBarInventoryItem,
            this.navBarFixedAssetItem,
            this.navBarSalaryItem,
            this.navBarGeneralItem,
            this.navBarReportItem});
            this.navBarMainLeft.LargeImages = this.imageNavbarCollection;
            this.navBarMainLeft.Location = new System.Drawing.Point(0, 146);
            this.navBarMainLeft.LookAndFeel.SkinName = "Office 2013";
            this.navBarMainLeft.Margin = new System.Windows.Forms.Padding(0);
            this.navBarMainLeft.Name = "navBarMainLeft";
            this.navBarMainLeft.OptionsNavPane.ExpandedWidth = 149;
            this.navBarMainLeft.OptionsNavPane.ShowExpandButton = false;
            this.navBarMainLeft.OptionsNavPane.ShowOverflowButton = false;
            this.navBarMainLeft.OptionsNavPane.ShowOverflowPanel = false;
            this.navBarMainLeft.OptionsNavPane.ShowSplitter = false;
            this.navBarMainLeft.Size = new System.Drawing.Size(149, 456);
            this.navBarMainLeft.TabIndex = 3;
            this.navBarMainLeft.View = new DevExpress.XtraNavBar.ViewInfo.StandardSkinNavigationPaneViewInfoRegistrator("Metropolis");
            this.navBarMainLeft.Visible = false;
            this.navBarMainLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.navBarMainLeft_MouseDown);
            // 
            // navBarDesktopGroup
            // 
            this.navBarDesktopGroup.Caption = "Bàn làm việc";
            this.navBarDesktopGroup.Expanded = true;
            this.navBarDesktopGroup.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsText;
            this.navBarDesktopGroup.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarEstimateItem),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarCashItem),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarDepositItem),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarInventoryItem),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarFixedAssetItem),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarSalaryItem),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarGeneralItem),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarReportItem)});
            this.navBarDesktopGroup.Name = "navBarDesktopGroup";
            this.navBarDesktopGroup.NavigationPaneVisible = false;
            this.navBarDesktopGroup.TopVisibleLinkIndex = 2;
            // 
            // navBarEstimateItem
            // 
            this.navBarEstimateItem.Caption = "Dự toán";
            this.navBarEstimateItem.LargeImageIndex = 10;
            this.navBarEstimateItem.Name = "navBarEstimateItem";
            // 
            // navBarCashItem
            // 
            this.navBarCashItem.AppearanceHotTracked.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.navBarCashItem.AppearanceHotTracked.Options.UseBackColor = true;
            this.navBarCashItem.AppearancePressed.BackColor = System.Drawing.Color.LightSteelBlue;
            this.navBarCashItem.AppearancePressed.Options.UseBackColor = true;
            this.navBarCashItem.Caption = "Tiền mặt";
            this.navBarCashItem.LargeImageIndex = 7;
            this.navBarCashItem.Name = "navBarCashItem";
            // 
            // navBarDepositItem
            // 
            this.navBarDepositItem.Caption = "Tiền gửi";
            this.navBarDepositItem.LargeImageIndex = 5;
            this.navBarDepositItem.Name = "navBarDepositItem";
            // 
            // navBarInventoryItem
            // 
            this.navBarInventoryItem.Caption = "Vật tư";
            this.navBarInventoryItem.LargeImageIndex = 9;
            this.navBarInventoryItem.Name = "navBarInventoryItem";
            // 
            // navBarFixedAssetItem
            // 
            this.navBarFixedAssetItem.Caption = "Tài sản";
            this.navBarFixedAssetItem.LargeImageIndex = 8;
            this.navBarFixedAssetItem.Name = "navBarFixedAssetItem";
            // 
            // navBarSalaryItem
            // 
            this.navBarSalaryItem.Caption = "Lương";
            this.navBarSalaryItem.LargeImageIndex = 6;
            this.navBarSalaryItem.Name = "navBarSalaryItem";
            // 
            // navBarGeneralItem
            // 
            this.navBarGeneralItem.Caption = "Tổng hợp";
            this.navBarGeneralItem.LargeImageIndex = 11;
            this.navBarGeneralItem.Name = "navBarGeneralItem";
            // 
            // navBarReportItem
            // 
            this.navBarReportItem.Caption = "Báo cáo";
            this.navBarReportItem.LargeImageIndex = 12;
            this.navBarReportItem.Name = "navBarReportItem";
            // 
            // imageNavbarCollection
            // 
            this.imageNavbarCollection.ImageSize = new System.Drawing.Size(32, 32);
            this.imageNavbarCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageNavbarCollection.ImageStream")));
            this.imageNavbarCollection.Images.SetKeyName(0, "1391847983_fingerprint_reader.png");
            this.imageNavbarCollection.Images.SetKeyName(1, "1391848080_money_bag.png");
            this.imageNavbarCollection.Images.SetKeyName(2, "1391848198_Money_Bag.png");
            this.imageNavbarCollection.Images.SetKeyName(3, "1391848404_Cash_register.png");
            this.imageNavbarCollection.Images.SetKeyName(4, "1391848501_money.png");
            this.imageNavbarCollection.Images.SetKeyName(5, "bank-banknote.png");
            this.imageNavbarCollection.Images.SetKeyName(6, "cashier-employee.png");
            this.imageNavbarCollection.Images.SetKeyName(7, "money.png");
            this.imageNavbarCollection.Images.SetKeyName(8, "transport.png");
            this.imageNavbarCollection.Images.SetKeyName(9, "archive.png");
            this.imageNavbarCollection.Images.SetKeyName(10, "calculator-banknote.png");
            this.imageNavbarCollection.Images.SetKeyName(11, "briefcase.png");
            this.imageNavbarCollection.Images.SetKeyName(12, "clipboard.png");
            // 
            // defaultLookAndFeel
            // 
            this.defaultLookAndFeel.LookAndFeel.SkinName = "Office 2013";
            // 
            // mainPanelControl
            // 
            this.mainPanelControl.Appearance.BorderColor = System.Drawing.Color.DimGray;
            this.mainPanelControl.Appearance.Options.UseBorderColor = true;
            this.mainPanelControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.mainPanelControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanelControl.Location = new System.Drawing.Point(149, 146);
            this.mainPanelControl.Name = "mainPanelControl";
            this.mainPanelControl.Size = new System.Drawing.Size(1223, 456);
            this.mainPanelControl.TabIndex = 4;
            this.mainPanelControl.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPanelControl_Paint);
            // 
            // barButtonItem19
            // 
            this.barButtonItem19.Caption = "Số dư đầu kỳ tài khoản";
            this.barButtonItem19.Id = 125;
            this.barButtonItem19.Name = "barButtonItem19";
            // 
            // MainRibbonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1372, 629);
            this.Controls.Add(this.mainPanelControl);
            this.Controls.Add(this.navBarMainLeft);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbonMainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainRibbonForm";
            this.Ribbon = this.ribbonMainMenu;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "PHẦN MỀM KẾ TOÁN A-BIGTIME .NET";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainRibbonForm_Closed);
            this.Load += new System.EventHandler(this.MainRibbonForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonMainMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageRibbonCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageRibbonLargeCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageRibbon24Collection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarMainLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageNavbarCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainPanelControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonMainMenu;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem barButtonOpenData;
        private DevExpress.XtraBars.BarButtonItem barButtonCloseData;
        private DevExpress.XtraBars.BarButtonItem barButtonPostedDate;
        private DevExpress.XtraBars.BarButtonItem barButtonDbInfo;
        private DevExpress.XtraBars.BarButtonItem barButtonUser;
        private DevExpress.XtraBars.BarButtonItem barButtonChangePassword;
        private DevExpress.XtraBars.BarButtonItem barItemBackUpData;
        private DevExpress.XtraBars.BarButtonItem barItemRestoreData;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPage pageCategory;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup7;
        private DevExpress.XtraBars.Ribbon.RibbonPage pageVoucher;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonEstimatePageGroup;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonCashPageGroup;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonDepositPageGroup;
        private DevExpress.XtraBars.Ribbon.RibbonPage pageHelp;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup11;
        private DevExpress.XtraNavBar.NavBarControl navBarMainLeft;
        private DevExpress.XtraNavBar.NavBarGroup navBarDesktopGroup;
        private DevExpress.XtraNavBar.NavBarItem navBarEstimateItem;
        private DevExpress.XtraNavBar.NavBarItem navBarCashItem;
        private DevExpress.XtraNavBar.NavBarItem navBarDepositItem;
        private DevExpress.XtraNavBar.NavBarItem navBarInventoryItem;
        private DevExpress.XtraNavBar.NavBarItem navBarFixedAssetItem;
        private DevExpress.XtraNavBar.NavBarItem navBarSalaryItem;
        private DevExpress.XtraNavBar.NavBarItem navBarGeneralItem;
        private DevExpress.XtraBars.BarStaticItem barStaticServerName;
        private DevExpress.XtraBars.BarStaticItem barStaticUserName;
        private DevExpress.XtraBars.BarStaticItem barStaticDateItem;
        private DevExpress.XtraBars.BarStaticItem barStaticTimeItem;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel;
        private DevExpress.Utils.ImageCollection imageNavbarCollection;
        private DevExpress.Utils.ImageCollection imageRibbonCollection;
        private DevExpress.XtraBars.BarButtonItem barButtonCreateNewDatabase;
        private DevExpress.XtraBars.BarButtonItem barCompanyProfileItem;
        private DevExpress.XtraBars.BarButtonItem barButtonDbOption;
        private DevExpress.XtraBars.BarButtonItem barUnlockBook;
        private DevExpress.XtraBars.BarButtonItem barButtonAudittingLog;
        private DevExpress.Utils.ImageCollection imageRibbon24Collection;
        private DevExpress.XtraBars.BarButtonItem barButtonItem20;
        private DevExpress.XtraBars.BarButtonItem barSalaryItem;
        private DevExpress.XtraBars.BarButtonItem barButtonFAIncrement;
        private DevExpress.XtraBars.BarButtonItem barButtonFADecrement;
        private DevExpress.XtraBars.BarButtonItem barButtonFAArmortization;
        private DevExpress.XtraBars.BarButtonItem barButtonItem25;
        private DevExpress.XtraBars.BarButtonItem barInputInventory;
        private DevExpress.XtraBars.BarButtonItem barButtonOutputInventory;
        private DevExpress.XtraBars.BarButtonItem barButtonUpdateAmountExchangeItem;
        private DevExpress.XtraBars.BarButtonItem barbtnCaptitalAllocateVoucher;
        private DevExpress.XtraBars.BarButtonItem barButtonGeneral;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonSalaryPageGroup;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonFixedAssetPageGroup;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonInventoryPageGroup;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonGeneralPageGroup;
        private DevExpress.XtraBars.BarButtonItem barButtonBudgetSource;
        private DevExpress.XtraBars.BarButtonItem barCurrencyItem;
        private DevExpress.XtraBars.BarButtonItem barCustomers;
        private DevExpress.XtraBars.BarButtonItem barVendor;
        private DevExpress.XtraBars.BarButtonItem barButtonFixedAssetCategoryItem;
        private DevExpress.XtraBars.BarButtonItem barButtonFixedAssetItem;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup8;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup9;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup12;
        private DevExpress.XtraBars.BarButtonItem barButtonHelpItem;
        private DevExpress.XtraBars.BarButtonItem barButtonRegisterItem;
        private DevExpress.XtraBars.BarButtonItem barButtonAboutItem;
        private DevExpress.XtraBars.BarButtonItem barButtonAutoUpdateItem;
        private DevExpress.XtraBars.BarButtonItem barAccountingObject;
        private DevExpress.XtraBars.BarButtonItem barPlanTemplate;
        private DevExpress.XtraBars.BarButtonItem barButtonStock;
        private DevExpress.XtraBars.BarButtonItem barButtonInventoryItem;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageStock;
        private DevExpress.XtraBars.BarButtonItem barCapitalAllocateItem;
        private DevExpress.XtraBars.BarButtonItem barButtonBank;
        private DevExpress.XtraBars.BarButtonItem barMergerFundItem;
        private DevExpress.XtraBars.BarButtonItem barVoucherList;
        private DevExpress.XtraNavBar.NavBarItem navBarReportItem;
        private DevExpress.XtraBars.BarButtonItem barButtonProject;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem11;
        private DevExpress.XtraBars.BarButtonItem barButtonItem13;
        private DevExpress.XtraBars.BarSubItem barSubItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonAccountCategory;
        private DevExpress.XtraBars.BarButtonItem barButtonAccountItem;
        private DevExpress.XtraBars.BarButtonItem barButtonAutoBusiness;
        private DevExpress.XtraBars.BarButtonItem barButtonAccountTranfer;
        private DevExpress.XtraBars.BarSubItem barSubItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonBudgetChapter;
        private DevExpress.XtraBars.BarButtonItem barButtonBudgetCategory;
        private DevExpress.XtraBars.BarButtonItem barBudgetItem;
        private DevExpress.XtraBars.BarSubItem barSubItem4;
        private DevExpress.XtraBars.BarButtonItem barButtonDepartment;
        private DevExpress.XtraBars.BarButtonItem barButtonEmployee;
        private DevExpress.XtraBars.BarButtonItem barButtonPayItem;
        private DevExpress.XtraBars.BarButtonGroup barButtonGroup1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem14;
        private DevExpress.XtraBars.BarButtonItem barButtonItem15;
        private DevExpress.XtraBars.BarButtonItem barButtonItem16;
        private DevExpress.XtraBars.Ribbon.RibbonPageCategory ribbonPageCategory1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.BarButtonItem barButtonTransferItem;
        public MainPanelControl mainPanelControl;
        private DevExpress.XtraBars.BarButtonItem barButtonOpeningAccountEntry;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup10;
        private DevExpress.XtraBars.BarSubItem barSubItem5;
        private DevExpress.XtraBars.BarButtonItem barButtonReceiptEstimateItem;
        private DevExpress.XtraBars.BarButtonItem barButtonPaymentEstimateItem;
        private DevExpress.XtraBars.BarSubItem barSubItem6;
        private DevExpress.XtraBars.BarButtonItem barButtonReceiptItem;
        private DevExpress.XtraBars.BarButtonItem barButtonPaymentItem;
        private DevExpress.XtraBars.BarSubItem barSubItem7;
        private DevExpress.XtraBars.BarButtonItem barButtonPaymentDepositItem;
        private DevExpress.XtraBars.BarButtonItem barButtonReceiptDepositItem;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarButtonItem barButtonSearch;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup13;
        private DevExpress.XtraBars.BarButtonItem barButtonItem19;
        private DevExpress.XtraBars.BarButtonItem barConvertDataItem;
        private DevExpress.XtraBars.BarButtonItem barButtonEmployeeLeasingItem;
        private DevExpress.XtraBars.BarButtonItem barButtonEmployeeContractItem;
        private DevExpress.XtraBars.BarButtonItem barButtonBuildingItem;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup14;
        private DevExpress.XtraBars.BarButtonItem barButtonOpeningSupplyEntry;
        private DevExpress.XtraBars.BarButtonItem barButtonLoginItem;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup15;
        private DevExpress.XtraBars.BarButtonItem barButtonOpeningFixedAssetEntry;
        private DevExpress.XtraBars.BarButtonItem barButtonBudgetSourceCategory;
        private DevExpress.Utils.ImageCollection imageRibbonLargeCollection;
        private DevExpress.XtraBars.BarStaticItem barStaticServerDatabaseName;
        private DevExpress.XtraBars.BarButtonItem barButtonUpdateDatabase;
        private DevExpress.XtraBars.BarButtonItem barButtonItemMutual;
        private DevExpress.XtraBars.BarButtonItem barButtonExchangeRateItem;
        private DevExpress.XtraBars.BarButtonItem barExportData;
        private DevExpress.XtraBars.BarButtonItem barButtonAutoBusinessParallel;
        private DevExpress.XtraBars.BarButtonItem barButtonActivity;
        private DevExpress.XtraBars.BarButtonItem barButtonRefTypes;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup16;
        private DevExpress.XtraBars.BarButtonItem barButtonSUIncrement;
        private DevExpress.XtraBars.BarButtonItem barButtonSUDecrement;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager;
    }
}
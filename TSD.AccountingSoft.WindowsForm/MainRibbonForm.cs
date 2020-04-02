/***********************************************************************
 * <copyright file="MainRibbonForm.cs" company="Linh Khang">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Author:   LinhMC
 * Email:    linhmc.vn@gmail.com
 * Website:
 * Create Date: Sunday, February 09, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using TSD.AccountingSoft.Presenter.Dictionary.AudittingLog;
using TSD.AccountingSoft.Report.MainReport;
using TSD.AccountingSoft.Report.ReportClass;
using TSD.AccountingSoft.Session;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.WindowsForm.CommonClass;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBusiness;
using TSD.AccountingSoft.WindowsForm.FormBusiness.OpeningAccount;
using TSD.AccountingSoft.WindowsForm.FormDictionary;
using TSD.AccountingSoft.WindowsForm.FormSystem;
using TSD.AccountingSoft.WindowsForm.FormSystem.UserProfile;
using TSD.AccountingSoft.WindowsForm.Resources;
using TSD.AccountingSoft.WindowsForm.UserControl.DiagramDesktop;
using TSD.AccountingSoft.WindowsForm.UserControl.Dictionary;
using TSD.AccountingSoft.WindowsForm.UserControl.Voucher;
using TSD.Enum;
using TSD.Option;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraNavBar;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using Timer = System.Windows.Forms.Timer;


namespace TSD.AccountingSoft.WindowsForm
{
    /// <summary>
    /// Main form application
    /// </summary>
    public partial class MainRibbonForm : DevExpress.XtraBars.Ribbon.RibbonForm, IAudittingLogView
    {
        private bool _loginState;
        //public static MainRibbonForm _frmMain;
        private GlobalVariable _globalVariable;
        private readonly Crypto Crypto = new Crypto(Crypto.SymmProvEnum.Rijndael);

        /// <summary>
        /// The _auditting log presenter
        /// </summary>
        private readonly AudittingLogPresenter _audittingLogPresenter;


        /// <summary>
        /// Initializes a new instance of the <see cref="MainRibbonForm"/> class.
        /// </summary>
        public MainRibbonForm()
        {
            InitializeComponent();
            CommonFunction.CommonUserControl = new XtraUserControl();
            _audittingLogPresenter = new AudittingLogPresenter(this);

        }

        /// <summary>
        /// Sets the state of the close data.
        /// </summary>
        /// <param name="flag">if set to <c>true</c> [flag].</param>
        void SetCloseDataState(bool flag)
        {
            if (flag)
            {
                navBarMainLeft.Visible = false;
                ribbonPageGroup2.Visible = false;
                barButtonChangePassword.Visibility = BarItemVisibility.Never;
                mainPanelControl.MainPanel.Controls.Clear();

            }
            else
            {
                navBarMainLeft.Visible = true;
                ribbonPageGroup2.Visible = true;
                barButtonChangePassword.Visibility = BarItemVisibility.Always;
            }
        }

        /// <summary>
        /// Handles the ItemClick event of the ribbonMainMenu control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ItemClickEventArgs"/> instance containing the event data.</param>
        private void ribbonMainMenu_ItemClick(object sender, ItemClickEventArgs e)
        {
            var validForInitGlobalVariable = false;
            try
            {
                Cursor.Current = Cursors.WaitCursor; //barButtonSearch
                switch (e.Item.Name)
                {
                    case "barCompanyProfileItem":
                        using (var frmXtraCompanyProfile = new FrmXtraCompanyProfileDetail())
                        {
                            frmXtraCompanyProfile.ShowDialog();
                        }
                        break;
                    case "barButtonChangePassword":
                        using (var frmXtraChangePassword = new FrmXtraChangePassword())
                        {
                            frmXtraChangePassword.ShowDialog();
                        }
                        break;
                    case "barButtonUpdateDatabase":
                        using (var frmXtraUpdateDatabase = new FrmXtraUpdateDatabase())
                        {
                            frmXtraUpdateDatabase.ShowDialog();
                        }
                        break;
                    case "barItemRestoreData":
                        using (var frmXtraRestoreData = new FrmXtraRestoreData())
                        {
                            frmXtraRestoreData.ShowDialog();
                        }
                        break;
                    case "barItemBackUpData":
                        using (var frmXtraBackUpData = new FrmXtraBackUpData())
                        {
                            frmXtraBackUpData.ShowDialog();
                        }
                        break;
                    case "barButtonHelpItem":
                        if (File.Exists("BIGTIME.CHM"))
                            Process.Start("BIGTIME.CHM");
                        break;
                    case "barButtonCloseData":
                        pageCategory.Visible = false;
                        pageVoucher.Visible = false;
                        barButtonLoginItem.Visibility = BarItemVisibility.Always;
                        barButtonCloseData.Visibility = BarItemVisibility.Never;
                        SetCloseDataState(true);
                        GlobalVariable.Server.ConnectionContext.SqlConnectionObject.Close();
                        break;
                    case "barButtonLoginItem":
                        pageCategory.Visible = false;
                        pageVoucher.Visible = false;
                        if (RegistryHelper.GetValueByRegistryKey("DatabaseName").Equals("master"))
                        {
                            using (var frmCreateNewDatabase = new FrmCreateNewDatabase())
                            {
                                if (frmCreateNewDatabase.ShowDialog() == DialogResult.OK)
                                {
                                    validForInitGlobalVariable = true;
                                }
                            }
                        }
                        else
                        {
                            using (var frmLogin = new FrmLogin())
                            {
                                frmLogin.PostLoginState += MainRibbonForm_GetLoginState;
                                if (frmLogin.ShowDialog() == DialogResult.OK)
                                {
                                    validForInitGlobalVariable = true;
                                }
                            }
                            if (!_loginState) return;
                            barButtonLoginItem.Visibility = BarItemVisibility.Never;
                            barButtonCloseData.Visibility = BarItemVisibility.Always;
                            pageCategory.Visible = true;
                            pageVoucher.Visible = true;
                            pageHelp.Visible = true;
                            SetCloseDataState(false);
                            if (new FrmXtraPostedDate().ShowDialog() == DialogResult.OK)
                            {
                                validForInitGlobalVariable = true;
                            }
                        }
                        break;
                    case "barButtonRegisterItem":
                        using (var frmRegister = new FrmXtraRegister())
                        {
                            frmRegister.ShowDialog();
                        }
                        break;
                    case "barButtonAboutItem":
                        using (var frmAbout = new XtraAboutForm())
                        {
                            frmAbout.ShowDialog();
                        }
                        break;

                    case "barButtonAutoUpdateItem":
                        string currentVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
                        if (new FileInfo(System.Windows.Forms.Application.StartupPath + @"\UpdateProgram.exe").Exists == false)
                        {
                            XtraMessageBox.Show("Không tìm thấy tệp cập nhật!", "Lỗi thiếu file", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }

                        var info = new ProcessStartInfo(System.Windows.Forms.Application.StartupPath + @"\UpdateProgram.exe", currentVersion);
                        Process.Start(info);
                        break;

                    case "barButtonOpeningSupplyEntry":
                        //if (CommonFunction.CommonUserControl != null &&
                        //    CommonFunction.CommonUserControl.GetType() != typeof(UserControlOpeningInventoryList))
                        //{
                        //    var userControl = new UserControlOpeningInventoryList { Dock = DockStyle.Fill, HelpTopicId = 3050 };
                        //    CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                        //}

                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(FrmOpeningSupplyEntries))
                        {
                            var userControl = new FrmOpeningSupplyEntries { Dock = DockStyle.Fill, HelpTopicId = 117 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text = ResourceHelper.GetResourceValueByName("ResOpeningSupplyEntryCaption");
                        }

                        break;
                    case "barButtonOpeningFixedAssetEntry":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(UserControlOpeningFixedAssetList))
                        {
                            var userControl = new UserControlOpeningFixedAssetList { Dock = DockStyle.Fill, HelpTopicId = 3060 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                        }
                        break;
                    case "barButtonCreateNewDatabase":
                        using (var frmCreateNewDatabase = new FrmCreateNewDatabase())
                        {
                            frmCreateNewDatabase.ShowDialog();
                        }
                        break;
                    case "barButtonOpenData":
                        var frmXtraOpenDatabase = new FrmXtraOpenDatabase();
                        if (frmXtraOpenDatabase.ShowDialog() == DialogResult.OK)
                            validForInitGlobalVariable = true;
                        break;
                    case "barButtonUser":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(UserControlUserProfileList))
                        {
                            var userControl = new UserControlUserProfileList { Dock = DockStyle.Fill, HelpTopicId = 1010 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResUserProfileCaption");
                        }
                        break;
                    case "barConvertDataItem":
                        using (var frmConvertFoxproData = new FrmXtraConvertFoxproData())
                        {
                            frmConvertFoxproData.ShowDialog();
                        }
                        break;
                    case "barButtonSearch":
                        var frmXtraSearchVoucher = new FrmXtraSearchVoucher();
                        frmXtraSearchVoucher.ShowDialog();
                        break;
                    case "barInputInventory":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(UserControlInputInventoryList))
                        {
                            var userControl = new UserControlInputInventoryList { Dock = DockStyle.Fill, HelpTopicId = 5010 };

                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResInputInventoryListCaption");
                        }
                        break;
                    case "barSalaryItem":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(UserControlSalaryList))
                        {
                            _globalVariable = new GlobalVariable();
                            var userControl = new UserControlSalaryList { Dock = DockStyle.Fill, HelpTopicId = 5070 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text = ResourceHelper.GetResourceValueByName("ResSalaryListCaption") + @" năm " +
                            DateTime.Parse(_globalVariable.PostedDate).Year;
                        }
                        break;
                    case "barCapitalAllocateItem":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(UserControlCapitalAllocateList))
                        {
                            var userControl = new UserControlCapitalAllocateList { Dock = DockStyle.Fill, HelpTopicId = 1010 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResCapitalAllocateCaption");
                        }
                        break;
                    case "barCurrencyItem":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(UserControlCurrencyList))
                        {
                            var userControl = new UserControlCurrencyList { Dock = DockStyle.Fill, HelpTopicId = 2030 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResCurrencyCaption");
                        }
                        break;
                    case "barButtonAccountItem":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(UserControlAccountList))
                        {
                            var userControl = new UserControlAccountList { Dock = DockStyle.Fill, HelpTopicId = 1010 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResAccountCaption");
                        }
                        break;
                    case "barButtonReceiptItem":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(UserControlVoucherReceiptList))
                        {
                            var userControl = new UserControlVoucherReceiptList { Dock = DockStyle.Fill, HelpTopicId = 4060 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResCashReceiptCaption");
                        }
                        break;
                    case "barButtonPlaymentItem":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(UserControlPaymentEstimateList))
                        {
                            var userControl = new UserControlPaymentEstimateList { Dock = DockStyle.Fill, HelpTopicId = 6080 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResCashReceiptCaption");
                        }

                        break;
                    case "barButtonDepartment":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(UserControlDepartmentList))
                        {
                            var userControl = new UserControlDepartmentList { Dock = DockStyle.Fill, HelpTopicId = 2040 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResDepartmentCaption");
                        }
                        break;
                    case "barButtonFixedAssetCategoryItem":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(UserControlFixedAssetCategoryTreeList))
                        {
                            var userControl = new UserControlFixedAssetCategoryTreeList { Dock = DockStyle.Fill, HelpTopicId = 1010 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResFixedAssetCategoryCaption");
                        }
                        break;
                    case "barButtonFixedAssetItem":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(UserControlFixedAssetList))
                        {
                            var userControl = new UserControlFixedAssetList { Dock = DockStyle.Fill, HelpTopicId = 1010 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResFixedAssetCaption");
                        }
                        break;
                    case "barBudgetItem":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(UserControlBudgetItemList))
                        {
                            var userControl = new UserControlBudgetItemList { Dock = DockStyle.Fill, HelpTopicId = 1010 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResBudgetItemCaption");
                        }
                        break;
                    case "barButtonPayItem":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(UserControlPayItemList))
                        {
                            var userControl = new UserControlPayItemList { Dock = DockStyle.Fill, HelpTopicId = 2060 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResPayItemCaption");
                        }
                        break;
                    case "barButtonAccountCategory":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(UserControlAccountCategoryList))
                        {
                            var userControl = new UserControlAccountCategoryList { Dock = DockStyle.Fill, HelpTopicId = 1010 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResAccountCategoryCaption");
                        }
                        break;
                    case "barCustomers":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(UserControlCustomerList))
                        {
                            var userControl = new UserControlCustomerList { Dock = DockStyle.Fill, HelpTopicId = 1010 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResCustomer");
                        }
                        break;
                    case "barVendor":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(UserControlVendorList))
                        {
                            var userControl = new UserControlVendorList { Dock = DockStyle.Fill, HelpTopicId = 2080 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResVendor");
                        }
                        break;
                    case "barAccountingObject":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(UserControlAccountingObjectList))
                        {
                            var userControl = new UserControlAccountingObjectList { Dock = DockStyle.Fill, HelpTopicId = 2070 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResAccountingObject");
                        }
                        break;
                    case "barVoucherList":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(UserControlVoucherList))
                        {
                            var userControl = new UserControlVoucherList { Dock = DockStyle.Fill, HelpTopicId = 1010 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResVoucherList");
                        }
                        break;
                    case "barButtonBudgetChapter":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(UserControlBudgetChapterList))
                        {
                            var userControl = new UserControlBudgetChapterList { Dock = DockStyle.Fill, HelpTopicId = 1010 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResBudgetChapterCaption");
                        }
                        break;
                    case "barButtonBudgetCategory":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(UserControlBudgetCategoryList))
                        {
                            var userControl = new UserControlBudgetCategoryList { Dock = DockStyle.Fill, HelpTopicId = 1010 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResBudgetCategoryCaption");
                        }
                        break;
                    case "barMergerFundItem":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(UserControlMergerFundList))
                        {
                            var userControl = new UserControlMergerFundList { Dock = DockStyle.Fill, HelpTopicId = 1010 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResMergerFundCaption");
                        }
                        break;
                    case "barButtonBudgetSource":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(UserControlBudgetSourceList))
                        {
                            var userControl = new UserControlBudgetSourceList { Dock = DockStyle.Fill, HelpTopicId = 1010 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResBudgetSourceCaption");
                        }
                        break;
                    case "barButtonEmployee":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(UserControlEmployeeList))
                        {
                            var userControl = new UserControlEmployeeList { Dock = DockStyle.Fill, HelpTopicId = 2050 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResEmployeeCaption");
                        }
                        break;
                    case "barPlanTemplate":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(UserControlPlanTemplateList))
                        {
                            var userControl = new UserControlPlanTemplateList { Dock = DockStyle.Fill, HelpTopicId = 1010 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResPlanTemplateCaption");
                        }
                        break;
                    case "barButtonStock":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(UserControlStockList))
                        {
                            var userControl = new UserControlStockList { Dock = DockStyle.Fill, HelpTopicId = 1010 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResStockCaption");
                        }
                        break;
                    case "barButtonBank":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(UserControlBankList))
                        {
                            var userControl = new UserControlBankList { Dock = DockStyle.Fill, HelpTopicId = 1010 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResBankCaption");
                        }
                        break;
                    case "barButtonPaymentItem":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(UserControlPaymentVoucherList))
                        {
                            var userControl = new UserControlPaymentVoucherList { Dock = DockStyle.Fill, HelpTopicId = 4070 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResPaymentVoucher");
                        }
                        break;
                    case "barButtonAccountTranfer":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(UserControlAccountTranferList))
                        {
                            var userControl = new UserControlAccountTranferList { Dock = DockStyle.Fill, HelpTopicId = 1010 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResAccountTranferCaption");
                        }
                        break;
                    case "barButtonActivity":
                        if (CommonFunction.CommonUserControl != null && CommonFunction.CommonUserControl.GetType() != typeof(UserControlActivityList))
                        {
                            var userControl = new UserControlActivityList { Dock = DockStyle.Fill, HelpTopicId = 1010 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text = ResourceHelper.GetResourceValueByName("ResActivityCaption");
                        }
                        break;
                    case "barButtonAutoBusinessParallel":
                        if (CommonFunction.CommonUserControl != null && CommonFunction.CommonUserControl.GetType() != typeof(UserControlAutoBusinessParallelList))
                        {
                            var userControl = new UserControlAutoBusinessParallelList { Dock = DockStyle.Fill, HelpTopicId = 1010 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text = ResourceHelper.GetResourceValueByName("ResAutoBusinessParallelCaption");
                        }
                        break;
                    case "barButtonRefTypes":
                        if (CommonFunction.CommonUserControl != null && CommonFunction.CommonUserControl.GetType() != typeof(UserControlRefTypeList))
                        {
                            var userControl = new UserControlRefTypeList { Dock = DockStyle.Fill, HelpTopicId = 1010 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text = ResourceHelper.GetResourceValueByName("ResRefTypesCaption");
                        }
                        break;
                    case "barButtonAudittingLog":
                        /* LINHMC
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(UserControlAudittingLogList))
                        {
                            var userControl = new UserControlAudittingLogList { Dock = DockStyle.Fill };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResAudittingLogCaption");
                        }*/
                        var frmAuditingLog = new FrmXtraAuditingLog();
                        frmAuditingLog.Show();
                        break;
                    case "barButtonReceiptEstimateItem":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(UserControlReceiptEstimateList))
                        {
                            var userControl = new UserControlReceiptEstimateList { Dock = DockStyle.Fill, HelpTopicId = 7000 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResReceiptEstimateCaption");
                        }
                        break;
                    case "barButtonPaymentEstimateItem":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(UserControlPaymentEstimateList))
                        {
                            var userControl = new UserControlPaymentEstimateList { Dock = DockStyle.Fill, HelpTopicId = 7000 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResPaymentEstimateCaption");
                        }
                        break;
                    case "barButtonPaymentDepositItem":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(UserControlPaymentDepositList))
                        {
                            var userControl = new UserControlPaymentDepositList { Dock = DockStyle.Fill, HelpTopicId = 5000 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResPaymentDepositCaption");
                        }
                        break;
                    case "barButtonReceiptDepositItem":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(UserControlReceiptDepositList))
                        {
                            var userControl = new UserControlReceiptDepositList { Dock = DockStyle.Fill, HelpTopicId = 4090 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResReceiptDepositCaption");
                        }
                        break;
                    case "barButtonAutoBusiness":
                        if (CommonFunction.CommonUserControl != null && CommonFunction.CommonUserControl.GetType() != typeof(UserControlAutoBusinessList))
                        {
                            var userControl = new UserControlAutoBusinessList { Dock = DockStyle.Fill, HelpTopicId = 1010 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text = ResourceHelper.GetResourceValueByName("ResAutoBusinessCaption");
                        }
                        break;
                    case "barButtonProject":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(UserControlProjectList))
                        {
                            var userControl = new UserControlProjectList { Dock = DockStyle.Fill, HelpTopicId = 3000 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text = ResourceHelper.GetResourceValueByName("ResProjectCaption");
                        }
                        break;
                    case "barButtonInventoryItem":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(UserControlInventoryItemList))
                        {
                            var userControl = new UserControlInventoryItemList { Dock = DockStyle.Fill, HelpTopicId = 2090 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResInventoryItemCaption");
                        }
                        break;
                    case "barButtonBudgetSourceCategory":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(UserControlBudgetSourceCategoryList))
                        {
                            var userControl = new UserControlBudgetSourceCategoryList { Dock = DockStyle.Fill, HelpTopicId = 1010 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResBudgetSourceCategory");
                        }
                        break;
                    case "barButtonFAIncrement":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(UserControlFAIncrementList))
                        {
                            var userControl = new UserControlFAIncrementList { Dock = DockStyle.Fill, HelpTopicId = 6000 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResFixedAssetIncrementCaption");
                        }
                        break;
                    case "barButtonFADecrement":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(UserControlFADecrementList))
                        {
                            var userControl = new UserControlFADecrementList { Dock = DockStyle.Fill, HelpTopicId = 6020 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResFixedAssetDecrementCaption");
                        }
                        break;
                    case "barButtonFAArmortization":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(UserControlFAArmortizationList))
                        {
                            var userControl = new UserControlFAArmortizationList { Dock = DockStyle.Fill, HelpTopicId = 6030 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResFixedAssetArmortizationCaption");
                        }
                        break;
                    case "barButtonGeneral":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(UserControlGeneralVoucherList))
                        {
                            var userControl = new UserControlGeneralVoucherList { Dock = DockStyle.Fill, HelpTopicId = 6050 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResGeneralVoucherCaption");
                        }
                        break;

                    case "barButtonOutputInventory":
                        if (CommonFunction.CommonUserControl != null && CommonFunction.CommonUserControl.GetType() != typeof(UserControlOutputInventoryList))
                        {
                            var userControl = new UserControlOutputInventoryList { Dock = DockStyle.Fill, HelpTopicId = 5020 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResOutputInventoryCaption");
                        }
                        break;

                    case "barbtnCaptitalAllocateVoucher":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(UserControlGeneralVoucherCapitalAllocateList))
                        {
                            var userControl = new UserControlGeneralVoucherCapitalAllocateList { Dock = DockStyle.Fill, HelpTopicId = 6040 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResGeneralVouchersCapitalAllocateCaption");
                        }
                        break;
                    case "barButtonBuildingItem":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(UserControlBuildingList))
                        {
                            var userControl = new UserControlBuildingList { Dock = DockStyle.Fill, HelpTopicId = 1010 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResBuildingCaption");
                        }
                        break;
                    case "barButtonSUIncrement":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(UserControlSUIncrementList))
                        {
                            var userControl = new UserControlSUIncrementList { Dock = DockStyle.Fill, HelpTopicId = 1010 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResSUIncrementCaption");
                        }
                        break;
                    case "barButtonSUDecrement":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(UserControlSUDecrementList))
                        {
                            var userControl = new UserControlSUDecrementList { Dock = DockStyle.Fill, HelpTopicId = 1010 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text = ResourceHelper.GetResourceValueByName("ResSUDecrementCaption");
                        }
                        break;

                    case "barButtonDbOption":
                        var frmXtraFormDbOption = new FrmXtraFormDbOption();
                        frmXtraFormDbOption.ShowDialog();
                        break;
                    case "barButtonPostedDate":
                        var frmXtraPostedDate = new FrmXtraPostedDate();
                        frmXtraPostedDate.ShowDialog();
                        break;
                    case "barButtonDbInfo":
                        var frmXtraDbInfo = new FrmXtraDbInfo();
                        frmXtraDbInfo.ShowDialog();
                        break;

                    case "barUnlockBook":
                        var frmUnlockBook = new FrmUnlockBook();
                        frmUnlockBook.ShowDialog();
                        break;
                    case "barExportData":
                        var frmExportData = new FrmXtraExportData();
                        frmExportData.ShowDialog();
                        break;
                    case "barButtonUpdateAmountExchangeItem":
                        var frmXtraUpdateAmountExchange = new FrmXtraUpdateAmountExchange();
                        frmXtraUpdateAmountExchange.ShowDialog();
                        break;

                    case "barButtonTransferItem":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() !=
                            typeof(UserControlAccountTranferVoucherList))
                        {
                            var userControl = new UserControlAccountTranferVoucherList { Dock = DockStyle.Fill, HelpTopicId = 6060 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                            ResourceHelper.GetResourceValueByName("ResTransferVoucherCaption");
                        }
                        break;
                    case "barButtonOpeningAccountEntry":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(UserControlOpeningAccountEntryList))
                        {
                            var userControl = new UserControlOpeningAccountEntryList { Dock = DockStyle.Fill, HelpTopicId = 3050 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResOpeningAccountEntry");
                        }
                        break;
                    case "barButtonEmployeeLeasingItem":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(UserControlEmployeeLeasingList))
                        {
                            var userControl = new UserControlEmployeeLeasingList { Dock = DockStyle.Fill, HelpTopicId = 3010 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResEmployeeLeasingCaption");
                        }
                        break;
                    case "barButtonEmployeeContractItem":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(UserControlEmployeeContractList))
                        {
                            var userControl = new UserControlEmployeeContractList { Dock = DockStyle.Fill, HelpTopicId = 3020 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text =
                                ResourceHelper.GetResourceValueByName("ResEmployeeContractCaption");
                        }
                        break;
                    case "barButtonItemMutual":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(UserControlMutualList))
                        {
                            var userControl = new UserControlMutualList { Dock = DockStyle.Fill, HelpTopicId = 3040 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text = @"Nhà hỗ tương";
                        }
                        break;
                    case "barButtonExchangeRateItem":
                        if (CommonFunction.CommonUserControl != null &&
                            CommonFunction.CommonUserControl.GetType() != typeof(UserControlExchangeRateList))
                        {
                            var userControl = new UserControlExchangeRateList { Dock = DockStyle.Fill, HelpTopicId = 1010 };
                            CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                            mainPanelControl.FeatureCaption.Text = @"Tỷ giá dự toán";
                        }
                        break;
                }
                if (validForInitGlobalVariable)
                    _globalVariable = new GlobalVariable();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(),
                    ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the MouseDown event of the navBarMainLeft control. 
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void navBarMainLeft_MouseDown(object sender, MouseEventArgs e)
        {
            var navBar = sender as NavBarControl;
            if (navBar == null)
                return;
            var hitInfo = navBar.CalcHitInfo(new Point(e.X, e.Y));
            if (!hitInfo.InLink)
                return;
            switch (hitInfo.Link.ItemName)
            {
                case "navBarEstimateItem":
                    if (CommonFunction.CommonUserControl != null &&
                        CommonFunction.CommonUserControl.GetType() != typeof(UserControlEstimateDesktop))
                    {
                        var userControl = new UserControlEstimateDesktop { Dock = DockStyle.Fill };
                        CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                        mainPanelControl.FeatureCaption.Text =
                            ResourceHelper.GetResourceValueByName("ResEstimateCaption");
                    }
                    break;
                case "navBarCashItem":
                    if (CommonFunction.CommonUserControl != null &&
                        CommonFunction.CommonUserControl.GetType() != typeof(UserControlCashDesktop))
                    {
                        var userControl = new UserControlCashDesktop { Dock = DockStyle.Fill };
                        CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                        mainPanelControl.FeatureCaption.Text =
                            ResourceHelper.GetResourceValueByName("ResCashCaption");
                    }
                    break;
                case "navBarDepositItem":
                    if (CommonFunction.CommonUserControl != null &&
                        CommonFunction.CommonUserControl.GetType() != typeof(UserControlDepositDesktop))
                    {
                        var userControl = new UserControlDepositDesktop { Dock = DockStyle.Fill };
                        CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                        mainPanelControl.FeatureCaption.Text =
                            ResourceHelper.GetResourceValueByName("ResDepositCaption");
                    }
                    break;
                case "navBarInventoryItem":
                    if (CommonFunction.CommonUserControl != null &&
                        CommonFunction.CommonUserControl.GetType() != typeof(UserControlInventoryDesktop))
                    {
                        var userControl = new UserControlInventoryDesktop { Dock = DockStyle.Fill };
                        CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                        mainPanelControl.FeatureCaption.Text =
                            ResourceHelper.GetResourceValueByName("ResInventoryCaption");
                    }
                    break;
                case "navBarFixedAssetItem":
                    if (CommonFunction.CommonUserControl != null &&
                        CommonFunction.CommonUserControl.GetType() != typeof(UserControlFixedAssetDesktop))
                    {
                        var userControl = new UserControlFixedAssetDesktop { Dock = DockStyle.Fill };
                        CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                        mainPanelControl.FeatureCaption.Text =
                            ResourceHelper.GetResourceValueByName("ResFixedAssetCaption");
                        userControl.GetRefFixedAsset += RefFixedAssetEvent;
                    }
                    break;
                case "navBarSalaryItem":
                    if (CommonFunction.CommonUserControl != null &&
                        CommonFunction.CommonUserControl.GetType() != typeof(UserControlSalaryDesktop))
                    {
                        var userControl = new UserControlSalaryDesktop { Dock = DockStyle.Fill };
                        CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                        mainPanelControl.FeatureCaption.Text =
                            ResourceHelper.GetResourceValueByName("ResSalaryCaption");
                    }
                    break;
                case "navBarGeneralItem":
                    if (CommonFunction.CommonUserControl != null &&
                        CommonFunction.CommonUserControl.GetType() != typeof(UserControlGeneralDesktop))
                    {
                        var userControl = new UserControlGeneralDesktop { Dock = DockStyle.Fill };
                        CommonFunction.RunUserControl(userControl, mainPanelControl.MainPanel);
                        mainPanelControl.FeatureCaption.Text =
                            ResourceHelper.GetResourceValueByName("ResGeneralCaption");
                    }
                    break;
                case "navBarReportItem":
                    using (var frmXtraReport = new FrmXtraReportList())
                    {
                        ReportTool.DrilldownVoucherEvent -= ReportTool_DrilldownVoucherEvent;
                        ReportTool.DrilldownVoucherEvent += ReportTool_DrilldownVoucherEvent;
                        frmXtraReport.ShowDialog();
                        break;
                    }
            }
        }

        /// <summary>
        /// References the fixed asset event.
        /// </summary>
        /// <param name="refTypeFixedAsset">The reference type fixed asset.</param>
        void RefFixedAssetEvent(int refTypeFixedAsset)
        {

            switch (refTypeFixedAsset)
            {
                case 50: // Danh muc TSCD

                    var userControlControlFixedAsset = new UserControlFixedAssetList { Dock = DockStyle.Fill };
                    CommonFunction.RunUserControl(userControlControlFixedAsset, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text =
                       ResourceHelper.GetResourceValueByName("ResFixedAssetCaption");
                    break;

                case 702: // Danh muc TSCD

                    var userControlOpenFixedAsset = new UserControlOpeningFixedAssetList { Dock = DockStyle.Fill };
                    CommonFunction.RunUserControl(userControlOpenFixedAsset, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text =
                       ResourceHelper.GetResourceValueByName("ResFixedAssetCaption");
                    break;
                case 500: // Danh muc TSCD

                    var userControlFAIncrement = new UserControlFAIncrementList { Dock = DockStyle.Fill };
                    CommonFunction.RunUserControl(userControlFAIncrement, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text =
                       ResourceHelper.GetResourceValueByName("ResFixedAssetCaption");
                    break;
                case 502: // Danh muc TSCD

                    var userControlFAArmortization = new UserControlFAArmortizationList { Dock = DockStyle.Fill };
                    CommonFunction.RunUserControl(userControlFAArmortization, mainPanelControl.MainPanel);
                    mainPanelControl.FeatureCaption.Text =
                       ResourceHelper.GetResourceValueByName("ResFixedAssetCaption");
                    break;

            }
        }

        /// <summary>
        /// Reports the tool_ drilldown voucher event.
        /// </summary>
        /// <param name="refType">Type of the reference.</param>
        /// <param name="refId">The reference identifier.</param>
        static void ReportTool_DrilldownVoucherEvent(string refType, string refId)
        {
            var refTypeId = int.Parse(refType);
            var frmDetail = new FrmXtraBaseVoucherDetail();
            switch (refTypeId)
            {
                case 200:// phiếu thu
                    frmDetail = new FrmXtraVoucherReceiptDetail();
                    break;
                case 400: //Nhập kho
                    frmDetail = new FrmXtraInputInventoryDetail();
                    break;
                case 401: //Xuaats kho
                    frmDetail = new FrmXtraOutputInventoryDetail();
                    break;
                case 110: //Dự toán thu
                    frmDetail = new FrmXtraReceiptEstimateDetail();
                    break;
                case 120: //Dự toán chi
                    frmDetail = new FrmXtraPaymentEstimateDetail();
                    break;
                case 201: //phiếu chi
                    frmDetail = new FrmXtraFormPaymentVoucherDetail();
                    break;
                case 301: //Giấy báo nợ
                    frmDetail = new FrmXtraPaymentDepositDetail();
                    break;
                case 300: //Giấy báo có
                    frmDetail = new FrmXtraReceiptDepositDetail();
                    break;
                //case 402: //Chuyển kho
                //    frmDetail = new FrmXtraOutputInventoryDetail();
                //    break;
                case 500: //Ghi tăng TSCĐ
                    frmDetail = new FrmXtraFormFAIncrementDetail();
                    break;
                case 501: //Ghi giảm TSCĐ
                    frmDetail = new FrmXtraFormFADecrementDetail();
                    break;
                case 502: //Khấu hao TSCĐ
                    frmDetail = new FrmXtraFormFAArmortizationDetail();
                    break;
                case 600: //CT lương
                    //frmDetail = new FrmXtraOutputInventoryDetail();
                    return;
                case 700: //Số dư ban đầu TK 
                case 701: //Số dư ban đầu VT 
                    break;
                case 900: //Chứng từ chung
                    frmDetail = new FrmXtraGeneralVoucherDetail();
                    break;
                case 901: //Chứng từ phân bổ
                    frmDetail = new FrmXtraGenvervoucherCapitalAllocateDetail();
                    break;
            }
            frmDetail.ActionMode = ActionModeVoucherEnum.None;
            frmDetail.RefID = long.Parse(refId);
            frmDetail.KeyValue = refId;
            frmDetail.BaseRefTypeId = (RefType)refTypeId;
            frmDetail.MasterBindingSource = new BindingSource();
            frmDetail.CurrentPosition = 1;
            frmDetail.ShowDialog();
        }

        /// <summary>
        /// Handles the Load event of the MainRibbonForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void MainRibbonForm_Load(object sender, EventArgs e)
        {
            Text += @" (R" + CommonClass.AssemblyInfomation.AssemblyVersion + @")";
            RefreshDateTime();
            SetCloseDataState(true);
            //hidden control
            pageCategory.Visible = false;
            pageVoucher.Visible = false;
            //pageHelp.Visible = false;
            if (RegistryHelper.GetValueByRegistryKey("DatabaseName").Equals("master"))
            {
                using (var frmCreateNewDatabase = new FrmCreateNewDatabase())
                {
                    if (frmCreateNewDatabase.ShowDialog() == DialogResult.OK) { }
                }
            }
            else
            {
                using (var frmLogin = new FrmLogin())
                {
                    frmLogin.PostLoginState += MainRibbonForm_GetLoginState;
                    if (frmLogin.ShowDialog() == DialogResult.OK) { }
                }
                if (!_loginState) return;
                _globalVariable = new GlobalVariable();
                barButtonLoginItem.Visibility = BarItemVisibility.Never;
                barButtonCloseData.Visibility = BarItemVisibility.Always;
                pageCategory.Visible = true;
                pageVoucher.Visible = true;
                pageHelp.Visible = true;
                SetCloseDataState(false);
                //load server connection
                //connection
                if (GlobalVariable.ServerConnection == null)
                {
                    GlobalVariable.ServerConnection = new ServerConnection(RegistryHelper.GetValueByRegistryKey("InstanceName"))
                    {
                        LoginSecure = false,
                        Login = RegistryHelper.GetValueByRegistryKey("UserName"),
                        Password = Crypto.Decrypting(RegistryHelper.GetValueByRegistryKey("Password"), "@bgt1me")
                    };
                }
                //create server
                if (GlobalVariable.Server == null)
                    GlobalVariable.Server = new Server(GlobalVariable.ServerConnection);
                using (var frmXtraPostedDate = new FrmXtraPostedDate())
                {
                    if (frmXtraPostedDate.ShowDialog() == DialogResult.OK) { }
                }
            }
            _globalVariable = new GlobalVariable();
            CommonFunction.GetLicenseInfo();
        }

        /// <summary>
        /// Mains the state of the ribbon form_ get login.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="data">if set to <c>true</c> [data].</param>
        public void MainRibbonForm_GetLoginState(object sender, bool data)
        {
            _loginState = data;
            if (!_loginState) return;
            barStaticServerName.Caption = ResourceHelper.GetResourceValueByName("ResInstanceNameCaption");
            barStaticUserName.Caption = ResourceHelper.GetResourceValueByName("ResUserNameCaption");
            barStaticServerName.Caption += RegistryHelper.GetValueByRegistryKey("InstanceName");
            barStaticUserName.Caption += RegistryHelper.GetValueByRegistryKey("UserLogin");
            barStaticServerDatabaseName.Caption += RegistryHelper.GetValueByRegistryKey("DatabaseName");
        }

        /// <summary>
        /// Refreshes the date time.
        /// </summary>
        private void RefreshDateTime()
        {
            var timer = new Timer { Enabled = true };
            timer.Tick += timer_Tick;
        }

        /// <summary>
        /// Handles the Tick event of the timer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void timer_Tick(object sender, EventArgs e)
        {
            barStaticDateItem.Caption = DateTime.Now.ToString("dd/MM/yyyy", Thread.CurrentThread.CurrentCulture);
            barStaticTimeItem.Caption = DateTime.Now.ToString("T");
        }

        /// <summary>
        /// Handles the Paint event of the mainPanelControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void mainPanelControl_Paint(object sender, PaintEventArgs e)
        {

        }

        /// <summary>
        /// Handles the FormClosing event of the MainRibbonForm control.
        /// LINHMC bỏ dialog hỏi sao lưu, không cần hỏi cứ sao lưu thôi
        /// var dialogResult = XtraMessageBox.Show("Bạn có muốn sao lưu trước khi thoát hệ thống !", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        ///if (dialogResult == DialogResult.No)
        ///    System.Windows.Forms.Application.Exit();
        ///else
        ///{
        ///sao luu CSDL
        ///CommonFunction.BackupDatabase(splashScreenManager, "", true);
        /// System.Windows.Forms.Application.Exit();
        ///}
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs"/> instance containing the event data.</param>
        private void MainRibbonForm_Closed(object sender, EventArgs e)
        {
            //  _audittingLogPresenter.Save(); thangnk comment
            if (RegistryHelper.GetValueByRegistryKey("DatabaseName").Equals("master"))
                System.Windows.Forms.Application.Exit();
            if (!_loginState)
            {
                System.Windows.Forms.Application.Exit();
            }
            else
            {
                _globalVariable = new GlobalVariable();
                if (!_globalVariable.IsDailyBackup)
                {
                    System.Windows.Forms.Application.Exit();
                }
                else
                {
                    //Sao lưu dữ liệu trước khi thoát
                    CommonFunction.BackupDatabase(splashScreenManager, "", true);//Đã fix, AnhNT tạm thời disable trong giai đoạn phát triển
                    System.Windows.Forms.Application.Exit();
                }
            }
        }

        #region AuditingLog Member

        /// <summary>
        /// Gets or sets the event identifier.
        /// </summary>
        /// <value>
        /// The event identifier.
        /// </value>
        public int EventId { get; set; }

        /// <summary>
        /// Gets or sets the name of the login.
        /// </summary>
        /// <value>
        /// The name of the login.
        /// </value>
        public string LoginName
        {
            get { return string.IsNullOrEmpty(GlobalVariable.LoginName) ? "UNKNOW" : GlobalVariable.LoginName; }
            set { }
        }

        /// <summary>
        /// Gets or sets the name of the computer.
        /// </summary>
        /// <value>
        /// The name of the computer.
        /// </value>
        public string ComputerName
        {
            get { return Environment.MachineName; }
            set { }
        }

        /// <summary>
        /// Gets or sets the event time.
        /// </summary>
        /// <value>
        /// The event time.
        /// </value>
        public DateTime EventTime
        {
            get { return DateTime.Now; }
            set { }
        }

        /// <summary>
        /// Gets or sets the name of the component.
        /// </summary>
        /// <value>
        /// The name of the component.
        /// </value>
        public string ComponentName
        {
            get { return "Đăng xuất"; }
            set { }
        }

        /// <summary>
        /// Gets or sets the event action.
        /// </summary>
        /// <value>
        /// The event action.
        /// </value>
        public int EventAction
        {
            get
            {
                return 8;
            }
            set { }
        }

        /// <summary>
        /// Gets or sets the reference.
        /// </summary>
        /// <value>
        /// The reference.
        /// </value>
        public string Reference
        {
            get
            {
                return "Đăng xuất";
            }
            set { }
        }

        /// <summary>
        /// Gets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public decimal Amount { get; set; }

        #endregion
    }
}
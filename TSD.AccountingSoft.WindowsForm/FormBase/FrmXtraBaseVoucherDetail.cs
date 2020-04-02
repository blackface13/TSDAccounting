/***********************************************************************
 * <copyright file="FrmXtraBaseVoucherDetail.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Thursday, February 13, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date: 23/09/2014  Author: ThangND  Description: Sửa lại chức năng xóa chứng từ
 * 27/8/2015: LINHMC   Đưa phần nhật ký vào form base ghi lại thao tác người dùng
 * ************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Model.BusinessObjects.Report;
using TSD.AccountingSoft.Presenter.Dictionary.AudittingLog;
using TSD.AccountingSoft.Presenter.Dictionary.AutoNumber;
using TSD.AccountingSoft.Presenter.Dictionary.CalculateClosing;
using TSD.AccountingSoft.Presenter.Dictionary.RefType;
using TSD.AccountingSoft.Presenter.Report;
using TSD.AccountingSoft.Presenter.System.Lock;
using TSD.AccountingSoft.Report.ReportClass;
using TSD.AccountingSoft.Session;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.View.Report;
using TSD.AccountingSoft.View.System;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.FormBusiness;
using TSD.AccountingSoft.WindowsForm.Resources;
using DevExpress.Data;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using TSD.Enum;
using TSD.AccountingSoft.Presenter.Dictionary.BudgetSource;
using DevExpress.Utils;
using TSD.AccountingSoft.Presenter.Dictionary.Account;
using TSD.AccountingSoft.Presenter.Dictionary.AccountingObject;
using TSD.AccountingSoft.Presenter.Dictionary.Project;
using TSD.AccountingSoft.Presenter.Dictionary.Customer;
using TSD.AccountingSoft.Presenter.Dictionary.AutoBusiness;
using TSD.AccountingSoft.Presenter.Dictionary.BudgetItem;
using TSD.AccountingSoft.Presenter.Dictionary.Currency;
using TSD.AccountingSoft.Presenter.Dictionary.MergerFund;
using TSD.AccountingSoft.Presenter.Dictionary.VoucherType;
using TSD.AccountingSoft.Presenter.Dictionary.Bank;
using TSD.AccountingSoft.WindowsForm.CommonClass;
using TSD.AccountingSoft.Presenter.Dictionary.Employee;
using TSD.AccountingSoft.Presenter.Dictionary.Vendor;
using TSD.AccountingSoft.WindowsForm.FormDictionary;
using TSD.AccountingSoft.Presenter.Dictionary.Department;
using TSD.AccountingSoft.Presenter.Dictionary.Stock;
using TSD.AccountingSoft.Presenter.Dictionary.InventoryItem;
using TSD.AccountingSoft.Presenter.Dictionary.FixedAsset;
using TSD.AccountingSoft.Model.BusinessObjects.Deposit;
using TSD.AccountingSoft.Model.BusinessObjects.Cash;
using TSD.AccountingSoft.Model.BusinessObjects.Inventory;
using TSD.AccountingSoft.Model.BusinessObjects.FixedAsset;
using TSD.AccountingSoft.Model.BusinessObjects.General;

namespace TSD.AccountingSoft.WindowsForm.FormBase
{
    /// <summary>
    /// FrmXtraBaseVoucherDetail
    /// </summary>
    public partial class FrmXtraBaseVoucherDetail : XtraForm, IAutoNumberView, IReportView, ICalculateClosingView, IAudittingLogView
        , IRefTypesView, ILockView, IBudgetSourcesView, IAccountsView, IAccountingObjectsView  ,
        IProjectsView
        ,ICustomersView, IDepartmentsView
        , IAutoBusinessesView, IBudgetItemsView, ICurrenciesView
        //, IMergerFundsView
        , IVoucherTypesView, IVendorsView, IEmployeesView, IBanksView
        //, IStocksView
        , IInventoryItemsView, IFixedAssetsView
    {
        #region LockDate

        public string Content { get; set; }

        public DateTime LockDate { get; set; }

        public bool IsLock { get; set; }

        #endregion

        #region AutoNumber properties

        /// <summary>
        /// Gets or sets the prefix.
        /// </summary>
        /// <value>
        /// The prefix.
        /// </value>
        public string Prefix { private get; set; }

        /// <summary>
        /// Gets or sets the suffix.
        /// </summary>
        /// <value>
        /// The suffix.
        /// </value>
        public string Suffix { private get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public int Value { private get; set; }

        /// <summary>
        /// Gets or sets the value local curency.
        /// </summary>
        /// <value>
        /// The value local curency.
        /// </value>
        public int ValueLocalCurency { get; set; }

        /// <summary>
        /// Gets or sets the leng of value.
        /// </summary>
        /// <value>
        /// The leng of value.
        /// </value>
        public int LengthOfValue { private get; set; }

        #endregion

        #region RefTypes Member

        /// <summary>
        /// Sets the reference types.
        /// </summary>
        /// <value>
        /// The reference types.
        /// </value>
        public IList<RefTypeModel> RefTypes { get; set; }

        #endregion

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
            get { return GlobalVariable.LoginName; }
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
            get
            {
                var formCaption = "";
                var firstOrDefault = RefTypes.FirstOrDefault(r => r.RefTypeId == (int)BaseRefTypeId);
                if (firstOrDefault != null)
                {
                    var refTypeName = firstOrDefault.RefTypeName;
                    formCaption = refTypeName;
                }
                return (string.IsNullOrEmpty(formCaption) ? "" : formCaption);
            }
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
                switch (ActionMode)
                {
                    case ActionModeVoucherEnum.AddNew:
                        return 1;
                    case ActionModeVoucherEnum.Edit:
                        return 2;
                    case ActionModeVoucherEnum.Delete:
                        return 3;
                    case ActionModeVoucherEnum.None:
                        return 4;
                    default:
                        return 5;//Nhân bản
                }
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
                switch (ActionMode)
                {
                    case ActionModeVoucherEnum.AddNew:
                        return "THÊM " + (string.IsNullOrEmpty(FormCaption) ? "" : FormCaption.ToUpper()) + " - ID " +
                               KeyValue + " - SỐ CT: " + (string.IsNullOrEmpty(txtRefNo.Text) ? "" : txtRefNo.Text);
                    case ActionModeVoucherEnum.Edit:
                        return "SỬA " + (string.IsNullOrEmpty(FormCaption) ? "" : FormCaption.ToUpper()) + " - ID " +
                               KeyValue + " - SỐ CT: " + (string.IsNullOrEmpty(txtRefNo.Text) ? "" : txtRefNo.Text);
                    case ActionModeVoucherEnum.Delete:
                        return "XÓA " + (string.IsNullOrEmpty(FormCaption) ? "" : FormCaption.ToUpper()) + " - ID " +
                               KeyValue + " - SỐ CT: " + (string.IsNullOrEmpty(txtRefNo.Text) ? "" : txtRefNo.Text);
                    case ActionModeVoucherEnum.None:
                        return "XEM " + (string.IsNullOrEmpty(FormCaption) ? "" : FormCaption.ToUpper()) + " - ID " +
                               KeyValue + " - SỐ CT: " + (string.IsNullOrEmpty(txtRefNo.Text) ? "" : txtRefNo.Text);
                    default:
                        return "NHÂN BẢN " + (string.IsNullOrEmpty(FormCaption) ? "" : FormCaption.ToUpper()) + " - ID " +
                               KeyValue + " - SỐ CT: " + (string.IsNullOrEmpty(txtRefNo.Text) ? "" : txtRefNo.Text);
                }
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

        #region Variables

        private readonly LockPresenter _lockPresenter;

        /// <summary>
        /// The _auditting log presenter
        /// </summary>
        private readonly AudittingLogPresenter _audittingLogPresenter;

        /// <summary>
        /// The _ref types presenter
        /// </summary>
        private readonly RefTypesPresenter _refTypesPresenter;

        /// <summary>
        /// The _report list presenter
        /// </summary>
        private ReportListPresenter _reportListPresenter;
        /// <summary>
        /// The _report list
        /// </summary>
        private List<ReportListModel> _reportList;
        /// <summary>
        /// The database option helper
        /// </summary>
        protected GlobalVariable DBOptionHelper;
        /// <summary>
        /// The _navigation state
        /// </summary>
        private EnumNavigationStatus _navigationState;
        /// <summary>
        /// The _type of model
        /// </summary>
        private Type _typeOfModel;

        /// <summary>
        /// The _calculate closing presenter
        /// </summary>
        private CalculateClosingPresenter _calculateClosingPresenter;

        protected AccountingObjectsPresenter _accountingObjectsPresenter;

        protected CustomersPresenter _customersPresenter;

        protected EmployeesPresenter _employeesPresenter;


        protected VendorsPresenter _vendorsPresenter;

        /// <summary>
        /// The master binding source
        /// </summary>
        public BindingSource MasterBindingSource;

        /// <summary>
        /// The _action mode
        /// </summary>
        private ActionModeVoucherEnum _actionMode;

        /// <summary>
        /// The currency accounting
        /// </summary>
        public string CurrencyAccounting;

        /// <summary>
        /// The currency local
        /// </summary>
        protected string CurrencyLocal;

        /// <summary>
        /// The system date
        /// </summary>
        protected DateTime SystemDate;

        /// <summary>
        /// The base posted date
        /// </summary>
        protected DateTime BasePostedDate;

        /// <summary>
        /// Gets or sets the currency current.
        /// </summary>
        /// <value>
        /// The currency current.
        /// </value>
        protected string CurrencyCurrent { get; set; }

        /// <summary>
        /// Gets or sets the exchange rate decimal digits.
        /// </summary>
        /// <value>
        /// The exchange rate decimal digits.
        /// </value>
        protected string ExchangeRateDecimalDigits { get; set; }

        /// <summary>
        /// Gets or sets the action mode.
        /// </summary>
        /// <value>
        /// The action mode.
        /// </value>
        public ActionModeVoucherEnum ActionMode
        {
            get { return _actionMode; }
            set
            {
                _actionMode = value;

                switch (_actionMode)
                {
                    case ActionModeVoucherEnum.None:
                        char[] charArr = (FormCaption ?? "").ToCharArray();
                        charArr[0] = Char.ToUpper(charArr[0]);
                        Text = new String(charArr);
                        //Text = FormCaption;
                        SetEnableToolbarControl(false);
                        break;
                    case ActionModeVoucherEnum.Edit:
                        Text = string.Format(ResourceHelper.GetResourceValueByName("ResEditText"), FormCaption);
                        SetEnableToolbarControl(true);
                        break;
                    case ActionModeVoucherEnum.AddNew:
                        Text = string.Format(ResourceHelper.GetResourceValueByName("ResAddNewText"), FormCaption);
                        SetEnableToolbarControl(true);
                        break;
                    case ActionModeVoucherEnum.DuplicateVoucher:
                        Text = string.Format(ResourceHelper.GetResourceValueByName("ResAddNewText"), FormCaption);
                        SetEnableToolbarControl(true);
                        break;
                }
            }
        }

        /// <summary>
        /// The key for send
        /// </summary>
        protected string _keyForSend;

        /// <summary>
        /// The _auto number presenter
        /// </summary>
        private readonly AutoNumberPresenter _autoNumberPresenter;

        /// <summary>
        /// The columns collection
        /// </summary>
        public List<XtraColumn> ColumnsCollection = new List<XtraColumn>();
        public List<XtraColumn> ColumnsCollectionParalell = new List<XtraColumn>();

        public IList<AutoBusinessModel> lstAutoBusinessBase { get; set; }

        /// <summary>
        /// Gets or sets the key value.
        /// </summary>
        /// <value>
        /// The key value.
        /// </value>
        public string KeyValue { get; set; }

        /// <summary>
        /// Gets the reference no.
        /// </summary>
        /// <value>
        /// The reference no.
        /// </value>
        public string BaseRefNo { get; set; }

        protected bool IsCopyRow = false;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the reference type identifier.
        /// </summary>
        /// <value>
        /// The reference type identifier.
        /// </value>
        [Category("BaseProperty")]
        public RefType BaseRefTypeId { get; set; }

        /// <summary>
        /// Gets or sets the form caption.
        /// </summary>
        /// <value>
        /// The form caption.
        /// </value>
        [Category("BaseProperty")]
        public string FormCaption { get; set; }

        /// <summary>
        /// Gets or sets the summary in column.
        /// </summary>
        /// <value>
        /// The summary in column.
        /// </value>
        [Category("BaseProperty")]
        public string SummaryInColumn { get; set; }

        /// <summary>
        /// Gets or sets the report identifier.
        /// </summary>
        /// <value>
        /// The report identifier.
        /// </value>
        [Category("BaseProperty")]
        public string ReportID { get; set; }

        /// <summary>
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>
        /// The reference identifier.
        /// </value>
        [Category("BaseProperty")]
        public long RefID { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is in visible popup menu grid].
        /// </summary>
        /// <value>
        /// <c>true</c> if [is in visible popup menu grid]; otherwise, <c>false</c>.
        /// </value>
        [Category("BaseProperty")]
        public bool IsInVisiblePopupMenuGrid { get; set; }

        /// <summary>
        /// Gets or sets the help topic identifier.
        /// </summary>
        /// <value>
        /// The help topic identifier.
        /// </value>
        [Category("BaseProperty")]
        public int HelpTopicId { get; set; }

        /// <summary>
        /// Gets or sets the model in grid detail.
        /// </summary>
        /// <value>
        /// The model in grid detail.
        /// </value>
        public string ModelInGridDetail { get; set; }

        /// <summary>
        /// Gets or sets the namespace of model.
        /// </summary>
        /// <value>
        /// The namespace of model.
        /// </value>
        public string NamespaceOfModel { get; set; }

        /// <summary>
        /// Gets or sets the account lists.
        /// LinhMC: thằng này được tạo ra nhằm mục đích, ở các form kế thừa sẽ gán giá trị của member Accounts vào AccountLists
        /// Dựa vào AccountLists sẽ lấy được AccountModel, từ AccountModel sẽ lấy các điều kiện ràng buộc chi tiết của tài khoản
        /// Từ các điều kiện này sẽ dùng để valid dữ liệu nhập ở phần GridDetail.
        /// </summary>
        /// <value>
        /// The account lists.
        /// </value>
        public IList<AccountModel> AccountLists { get; set; }

        public bool IsParentAccount
        {
            get { return GlobalVariable.IsPostToParentAccount; }
        }

        #endregion

        #region calulateClosing properties
        /// <summary>
        /// Gets or sets the Account Id.
        /// </summary>
        /// <value>
        /// The Account Id.
        /// </value>
        public int AccountId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Account Code.
        /// </summary>
        /// <value>
        /// The Account Code.
        /// </value>
        public string AccountCode
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Account Name.
        /// </summary>
        /// <value>
        /// The Account Name.
        /// </value>
        public string AccountName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Parent Id.
        /// </summary>
        /// <value>
        /// The Parent Id.
        /// </value>
        public int ParentId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Closing Amount.
        /// </summary>
        /// <value>
        /// The Closing Amount.
        /// </value>
        public decimal ClosingAmount
        {
            get;
            set;
        }

        #endregion

        #region Functions

        /// <summary>
        /// Lấy tổng số tối đa có thể chi có thể kết hợp nguồn
        /// </summary>
        /// <param name="paymentaccountCode">The paymentaccount code.</param>
        /// <param name="paymentBudgetSourceCode">The payment budget source code.</param>
        /// <param name="toDate">To date.</param>
        protected void GetCalculateAmountPayment(string paymentaccountCode, string paymentBudgetSourceCode, string toDate)
        {

            if (!DBOptionHelper.IsPaymentNegativeFund && !DBOptionHelper.IsDepositeNegavtiveFund && !DBOptionHelper.IsPaymentNegativeBudgetSource)
            {
                if (!string.IsNullOrEmpty(paymentBudgetSourceCode))
                {
                    _calculateClosingPresenter.Display(paymentaccountCode, "BudgetSourceCode = " + paymentBudgetSourceCode, CurrencyCurrent, toDate, GlobalVariable.IsPostToParentAccount, long.Parse(KeyValue ?? "0"), (int)BaseRefTypeId);
                }
                else
                {
                    _calculateClosingPresenter.Display(paymentaccountCode, " 1 = 1 ", CurrencyCurrent, toDate, GlobalVariable.IsPostToParentAccount, long.Parse(KeyValue ?? "0"), (int)BaseRefTypeId);
                }
            }
            else
            {
                ClosingAmount = decimal.MaxValue;
            }
        }

        /// <summary>
        /// Gets the calculate amount payment.
        /// </summary>
        /// <param name="cashaccountCode">The paymentaccount code.</param>
        /// <param name="toDate">To date.</param>
        protected void GetCalculateCashBalance(string cashaccountCode, string toDate)
        {
            if (!DBOptionHelper.IsPaymentNegativeFund)
            {
                _calculateClosingPresenter.Display(cashaccountCode, " 1 = 1 ", CurrencyCurrent, toDate, GlobalVariable.IsPostToParentAccount, long.Parse(KeyValue ?? "0"), (int)BaseRefTypeId);
            }
            else
            {
                ClosingAmount = 0;
            }
        }

        /// <summary>
        /// Gets the calculate deposit balance.
        /// </summary>
        /// <param name="cashaccountCode">The cashaccount code.</param>
        /// <param name="toDate">To date.</param>
        protected void GetCalculateDepositBalance(string cashaccountCode, string toDate)
        {

            if (!DBOptionHelper.IsDepositeNegavtiveFund)
            {
                _calculateClosingPresenter.Display(cashaccountCode, " 1 = 1 ", CurrencyCurrent, toDate, GlobalVariable.IsPostToParentAccount, long.Parse(KeyValue ?? "0"), (int)BaseRefTypeId);
            }
            else
            {
                ClosingAmount = 0;
            }
        }

        /// <summary>
        /// Gets the calculate capital balance.
        /// </summary>
        /// <param name="cashaccountCode">The cashaccount code.</param>
        /// <param name="budgetSourceCode">The budget source code.</param>
        /// <param name="toDate">To date.</param>
        protected void GetCalculateCapitalBalance(string cashaccountCode, string budgetSourceCode, string toDate)
        {
            if (!DBOptionHelper.IsPaymentNegativeBudgetSource)
            {
                _calculateClosingPresenter.Display(cashaccountCode, "BudgetSourceCode = " + budgetSourceCode, CurrencyCurrent, toDate, GlobalVariable.IsPostToParentAccount, long.Parse(KeyValue ?? "0"), (int)BaseRefTypeId);
            }
            else
            {
                ClosingAmount = 0;
            }
        }

        /// <summary>
        /// Initializes the layout.
        /// </summary>
        private void InitializeLayout()
        {
            if (!DesignMode)
            {
                DBOptionHelper = new GlobalVariable();
                CurrencyAccounting = DBOptionHelper.CurrencyAccounting;
                CurrencyLocal = DBOptionHelper.CurrencyLocal;
                ExchangeRateDecimalDigits = DBOptionHelper.ExchangeRateDecimalDigits;
                BasePostedDate = DateTime.Parse(DBOptionHelper.PostedDate);
                SystemDate = DateTime.Parse(GlobalVariable.SystemDate);
                if (bindingSourceDetail != null)
                    bindingSourceDetail.DataSource = null;
                gridViewDetail.OptionsView.ShowFooter = true;
                gridViewAccountingPararell.OptionsView.ShowFooter = true;
                InitControls();
            }
        }

        /// <summary>
        /// Closes the form.
        /// </summary>
        private void CloseForm()
        {
            if (PostKeyValue != null) PostKeyValue(this, _keyForSend);
        }

        /// <summary>
        /// Generateds the reference no.
        /// </summary>
        protected void GeneratedBaseRefNo()
        {
            //lay ra ma so voucher theo reftype
            BaseRefNo = "";
            if (!DesignMode)
            {
                if (ActionMode == ActionModeVoucherEnum.AddNew || ActionMode == ActionModeVoucherEnum.DuplicateVoucher)
                {
                    _autoNumberPresenter.DisplayByRefType((int)BaseRefTypeId);

                    if (!String.IsNullOrEmpty(Prefix))
                    {
                        BaseRefNo += Prefix;
                    }
                    //--------------------------------------------------------
                    //LinhMC: 29/11/2014
                    //Thêm hàm kiểm tra nếu chọn tiền hạch toán thì lấy giá trị Value, ngược lại lấy giá trị ValueLocalCurency
                    //Theo yêu cầu nhảy số tự động theo 2 loại tiền của Thẩm kế
                    //-------------------------------------------------------------//

                    // var currencyCode = gridViewMaster.GetRowCellValue(0, "CurrencyCode");
                    var currencyCode = cboCurrency.EditValue;

                    if (BaseRefTypeId == RefType.AccountTranferVourcher ||
                        BaseRefTypeId == RefType.CaptitalAllocateVoucher)
                    {
                        currencyCode = GetType().GetProperty("CurrencyCode").GetValue(this, null);
                    }
                    if (BaseRefTypeId == RefType.GeneralVoucher) currencyCode = GlobalVariable.CurrencyMain;
                    if (currencyCode != null)
                    {

                        if (currencyCode.ToString() == GlobalVariable.CurrencyMain)
                        {
                            if (Value >= 0)
                            {
                                for (var i = 0; i < (LengthOfValue - Value.ToString(CultureInfo.InvariantCulture).Length); i++)
                                    BaseRefNo += "0";
                                if (BaseRefTypeId == RefType.ReceiptEstimate || BaseRefTypeId == RefType.PaymentEstimate)
                                {
                                    BaseRefNo += Value;
                                }
                                else
                                {
                                    BaseRefNo += (Value) + "-" + currencyCode;
                                }
                            }
                        }
                        else
                        {
                            if (ValueLocalCurency >= 0)
                            {
                                for (var i = 0; i < (LengthOfValue - ValueLocalCurency.ToString(CultureInfo.InvariantCulture).Length); i++)
                                    BaseRefNo += "0";
                                if (BaseRefTypeId == RefType.ReceiptEstimate || BaseRefTypeId == RefType.PaymentEstimate)
                                {
                                    BaseRefNo += ValueLocalCurency;
                                }
                                else
                                {
                                    BaseRefNo += (ValueLocalCurency) + ((string)currencyCode == "" ? "" : "-" + currencyCode);
                                }
                            }
                        }
                    }

                    if (!String.IsNullOrEmpty(Suffix))
                        BaseRefNo += Suffix;
                    //ThangNK comment lại : Không loại bỏ chứng từ kèm theo tiền tệ==================
                    if (BaseRefTypeId == RefType.GeneralVoucher)
                        BaseRefNo = BaseRefNo.Remove(BaseRefNo.LastIndexOf('-'));
                    //-===============================================================================

                    // Sửa theo nghiệp vụ của BA, Bỏ loại số thự tự sau chứng từ
                    //if (BaseRefTypeId == RefType.FixedAssetArmortization)
                    //{
                    //    if (Value >= 0)
                    //    {
                    //        for (var i = 0; i < (LengthOfValue - Value.ToString(CultureInfo.InvariantCulture).Length); i++)
                    //            BaseRefNo += "0";
                    //        BaseRefNo += (Value);
                    //    }
                    //}
                    if (!String.IsNullOrEmpty(BaseRefNo)) txtRefNo.Text = BaseRefNo;
                }
            }
            cboObjectCode.Focus();
            this.ActiveControl = null;
        }

        /// <summary>
        /// Lấy số chứng từ tự động dành riêng cho chứng từ chung
        /// </summary>
        /// <param name="currencyCode">The currency code.</param>
        protected void GeneratedGetBaseRefNo(string currencyCode)
        {
            //lay ra ma so voucher theo reftype
            BaseRefNo = "";
            if (!DesignMode)
            {
                if (ActionMode == ActionModeVoucherEnum.AddNew || ActionMode == ActionModeVoucherEnum.DuplicateVoucher)
                {
                    _autoNumberPresenter.DisplayByRefType((int)BaseRefTypeId);

                    if (!String.IsNullOrEmpty(Prefix))
                    {
                        BaseRefNo += Prefix;
                    }

                    if (currencyCode != null)
                    {
                        if (currencyCode == GlobalVariable.CurrencyMain)
                        {
                            if (Value >= 0)
                            {
                                for (var i = 0;
                                    i < (LengthOfValue - Value.ToString(CultureInfo.InvariantCulture).Length);
                                    i++)
                                    BaseRefNo += "0";
                                BaseRefNo += (Value) + "-" + currencyCode;
                            }
                        }
                        else
                        {
                            if (ValueLocalCurency >= 0)
                            {
                                for (var i = 0;
                                    i <
                                    (LengthOfValue - ValueLocalCurency.ToString(CultureInfo.InvariantCulture).Length);
                                    i++)
                                    BaseRefNo += "0";
                                BaseRefNo += (ValueLocalCurency) +
                                             (currencyCode == "" ? "" : "-" + currencyCode);
                            }
                        }
                    }
                    if (!String.IsNullOrEmpty(BaseRefNo)) txtRefNo.Text = BaseRefNo;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="keyValue">The key value.</param>
        public delegate void EventPostKeyHandler(object sender, string keyValue);

        /// <summary>
        /// The key value
        /// </summary>
        public event EventPostKeyHandler PostKeyValue;

        /// <summary>
        /// Loads the grid detail layout.
        /// </summary>
        protected virtual void LoadGridDetailLayout()
        {
            if (ColumnsCollection == null) return;
            foreach (var column in ColumnsCollection)
            {
                if (column.ColumnVisible)
                {
                    gridViewDetail.Columns[column.ColumnName].Caption = column.ColumnCaption;
                    gridViewDetail.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                    gridViewDetail.Columns[column.ColumnName].Width = column.ColumnWith;
                    gridViewDetail.Columns[column.ColumnName].UnboundType = column.ColumnType; //dung de dinh dang so theo kieu du lieu
                    if (column.IsSummaryText)
                    {
                        gridViewDetail.Columns[column.ColumnName].SummaryItem.SummaryType = SummaryItemType.Custom;
                        gridViewDetail.Columns[column.ColumnName].SummaryItem.DisplayFormat = Properties.Resources.SummaryText;
                    }
                }
                else
                    gridViewDetail.Columns[column.ColumnName].Visible = false;
            }
        }

        protected virtual void LoadGridParalellDetailLayout()
        {
            if (ColumnsCollectionParalell == null) return;
            foreach (var column in ColumnsCollectionParalell)
            {
                if (column.ColumnVisible)
                {
                    gridViewAccountingPararell.Columns[column.ColumnName].Caption = column.ColumnCaption;
                    gridViewAccountingPararell.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                    gridViewAccountingPararell.Columns[column.ColumnName].Width = column.ColumnWith;
                    gridViewAccountingPararell.Columns[column.ColumnName].UnboundType = column.ColumnType;
                    gridViewAccountingPararell.Columns[column.ColumnName].OptionsColumn.AllowEdit = false;

                    //dung de dinh dang so theo kieu du lieu
                    if (column.IsSummaryText)
                    {
                        gridViewAccountingPararell.Columns[column.ColumnName].SummaryItem.SummaryType = SummaryItemType.Custom;
                        gridViewAccountingPararell.Columns[column.ColumnName].SummaryItem.DisplayFormat = Properties.Resources.SummaryText;
                    }
                }
                else
                    gridViewAccountingPararell.Columns[column.ColumnName].Visible = false;
            }
        }

        /// <summary>
        /// Sets the enable toolbar control.
        /// </summary>
        /// <param name="isEnable">if set to <c>true</c> [is enable].</param>
        protected void SetEnableToolbarControl(bool isEnable)
        {
            barButtonAddNewItem.Enabled = !isEnable;
            barButtonDeleteItem.Enabled = !isEnable;
            barButtonEditItem.Enabled = !isEnable;
            barButtonFirstItem.Enabled = !isEnable;
            barButtonPreviousItem.Enabled = !isEnable;
            barButtonNextItem.Enabled = !isEnable;
            barButtonLastItem.Enabled = !isEnable;
            barButtonPrintItem.Enabled = !isEnable;
            barButtonRefeshItem.Enabled = !isEnable;
            barButtonCancelItem.Enabled = isEnable;
            barButtonSaveItem.Enabled = isEnable;
            barButtonAddNewRowItem.Enabled = isEnable;
            barButtonDuplicateItem.Enabled = !isEnable;
            barButtonDeleteRowItem.Enabled = isEnable;
            barButtonCopyRow.Enabled = isEnable;

            //edit by thangnd; 20/03/2014
            EnableControlsInGroup(groupObject, isEnable);
            EnableControlsInGroup(groupVoucher, isEnable);

            SetEnableGroupBox(isEnable); // su dung cho cac form thua ke

            gridViewDetail.OptionsBehavior.Editable = isEnable;
            gridViewDetail.OptionsBehavior.ReadOnly = !isEnable;
            gridViewDetail.FocusRectStyle = DrawFocusRectStyle.None;
            gridViewDetail.OptionsSelection.EnableAppearanceFocusedCell = isEnable;
            gridViewDetail.OptionsView.NewItemRowPosition = !isEnable ? NewItemRowPosition.None : NewItemRowPosition.Bottom;

            gridViewAccountingPararell.OptionsBehavior.Editable = isEnable;
            gridViewAccountingPararell.OptionsBehavior.ReadOnly = !isEnable;
            gridViewAccountingPararell.FocusRectStyle = DrawFocusRectStyle.None;
            gridViewAccountingPararell.OptionsSelection.EnableAppearanceFocusedCell = isEnable;
            gridViewAccountingPararell.OptionsView.NewItemRowPosition = !isEnable ? NewItemRowPosition.None : NewItemRowPosition.Bottom;

            gridViewMaster.OptionsBehavior.Editable = isEnable;
            gridViewMaster.OptionsBehavior.ReadOnly = !isEnable;
        }

        /// <summary>
        /// Refreshes the toolbar.
        /// </summary>
        protected virtual void RefreshToolbar()
        {
            switch (ActionMode)
            {
                case ActionModeVoucherEnum.None:
                    SetEnableToolbarControl(false);
                    break;
                case ActionModeVoucherEnum.Edit:
                case ActionModeVoucherEnum.AddNew:
                    SetEnableToolbarControl(true);
                    break;
                case ActionModeVoucherEnum.DuplicateVoucher:
                    SetEnableToolbarControl(true);
                    break;
            }
        }

        /// <summary>
        /// Refreshes the navigation button.
        /// </summary>
        protected virtual void RefreshNavigationButton()
        {
            switch (_navigationState)
            {
                case EnumNavigationStatus.FirstPosition:
                    barButtonFirstItem.Enabled = false;
                    barButtonPreviousItem.Enabled = false;
                    barButtonNextItem.Enabled = true;
                    barButtonLastItem.Enabled = true;
                    break;
                case EnumNavigationStatus.LastPosition:
                    barButtonFirstItem.Enabled = true;
                    barButtonPreviousItem.Enabled = true;
                    barButtonNextItem.Enabled = false;
                    barButtonLastItem.Enabled = false;
                    break;
                case EnumNavigationStatus.InsidePosition:
                    barButtonFirstItem.Enabled = true;
                    barButtonPreviousItem.Enabled = true;
                    barButtonNextItem.Enabled = true;
                    barButtonLastItem.Enabled = true;
                    break;
                case EnumNavigationStatus.EmptyPostion:
                case EnumNavigationStatus.OnlyOneRow:
                    barButtonFirstItem.Enabled = false;
                    barButtonPreviousItem.Enabled = false;
                    barButtonNextItem.Enabled = false;
                    barButtonLastItem.Enabled = false;
                    break;
            }
        }

        /// <summary>
        /// Gets or sets the state of the navigation.
        /// </summary>
        /// <value>
        /// The state of the navigation.
        /// </value>
        private EnumNavigationStatus NavigationState
        {
            get
            {
                if (MasterBindingSource == null) return EnumNavigationStatus.EmptyPostion;
                var rowCount = BindingContext[MasterBindingSource, MasterBindingSource.DataMember].Count;
                switch (rowCount)
                {
                    case 0:
                        _navigationState = EnumNavigationStatus.EmptyPostion;
                        break;
                    case 1:
                        _navigationState = EnumNavigationStatus.OnlyOneRow;
                        break;
                    default:
                        var iCurrentPosition = BindingContext[MasterBindingSource, MasterBindingSource.DataMember].Position;
                        if (iCurrentPosition == 0)
                        {
                            _navigationState = EnumNavigationStatus.FirstPosition;
                        }
                        else if (iCurrentPosition == rowCount - 1)
                        {
                            _navigationState = EnumNavigationStatus.LastPosition;
                        }
                        else
                            _navigationState = EnumNavigationStatus.InsidePosition;
                        break;
                }

                return _navigationState;
            }
            set
            {
                _navigationState = value;
            }
        }

        /// <summary>
        /// The _navigation state before delete
        /// </summary>
        private EnumNavigationStatus _navigationStateBeforeDelete;

        /// <summary>
        /// Gets or sets the current position.
        /// </summary>
        /// <value>
        /// The current position.
        /// </value>
        public int CurrentPosition
        {
            get
            {
                if (DesignMode) return 0;
                return BindingContext[MasterBindingSource, MasterBindingSource.DataMember].Position;
            }
            set
            {
                if (DesignMode) return;
                if (ActionMode == ActionModeVoucherEnum.AddNew || ActionMode == ActionModeVoucherEnum.Edit || ActionMode == ActionModeVoucherEnum.DuplicateVoucher) return;
                BindingContext[MasterBindingSource, MasterBindingSource.DataMember].Position = value;
                switch (BindingContext[MasterBindingSource, MasterBindingSource.DataMember].Count)
                {
                    case 0:
                        NavigationState = EnumNavigationStatus.EmptyPostion;
                        break;
                    case 1:
                        NavigationState = EnumNavigationStatus.OnlyOneRow;
                        break;
                    default:
                        if (value == 0)
                        {
                            NavigationState = EnumNavigationStatus.FirstPosition;
                            break;
                        }
                        if (value == BindingContext[MasterBindingSource, MasterBindingSource.DataMember].Count - 1)
                        {
                            NavigationState = EnumNavigationStatus.LastPosition;
                            break;
                        }
                        NavigationState = EnumNavigationStatus.InsidePosition;
                        break;
                }
                RefreshNavigationButton();
            }
        }

        /// <summary>
        /// Moves the first voucher.
        /// </summary>
        protected virtual void MoveFirstVoucher()
        {
            try
            {
                if (BindingContext[MasterBindingSource, MasterBindingSource.DataMember].Count > 0)
                {
                    BindingContext[MasterBindingSource, MasterBindingSource.DataMember].Position = 0;
                    MasterBindingSource.Position =
                        BindingContext[MasterBindingSource, MasterBindingSource.DataMember].Position;
                    NavigationState = CurrentPosition <= 0
                                          ? EnumNavigationStatus.FirstPosition
                                          : EnumNavigationStatus.InsidePosition;
                    RefreshNavigationButton();
                    ShowData();
                }
                else
                {
                    NavigationState = EnumNavigationStatus.EmptyPostion;
                    RefreshToolbar();
                    RefreshNavigationButton();
                    ShowData();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Moves the previous voucher.
        /// </summary>
        protected virtual void MovePreviousVoucher()
        {
            try
            {
                if (BindingContext[MasterBindingSource, MasterBindingSource.DataMember].Count > 0)
                {
                    BindingContext[MasterBindingSource, MasterBindingSource.DataMember].Position -= 1;
                    MasterBindingSource.Position =
                        BindingContext[MasterBindingSource, MasterBindingSource.DataMember].Position;
                    NavigationState = CurrentPosition <= 0
                                          ? EnumNavigationStatus.FirstPosition
                                          : EnumNavigationStatus.InsidePosition;
                    RefreshNavigationButton();
                    ShowData();
                }
                else
                {
                    NavigationState = EnumNavigationStatus.EmptyPostion;
                    RefreshToolbar();
                    RefreshNavigationButton();
                    ShowData();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Moves the next voucher.
        /// </summary>
        protected virtual void MoveNextVoucher()
        {
            try
            {
                if (MasterBindingSource != null && BindingContext[MasterBindingSource, MasterBindingSource.DataMember].Count > 0)
                {
                    BindingContext[MasterBindingSource, MasterBindingSource.DataMember].Position += 1;
                    MasterBindingSource.Position =
                        BindingContext[MasterBindingSource, MasterBindingSource.DataMember].Position;
                    NavigationState = CurrentPosition >=
                                      BindingContext[MasterBindingSource, MasterBindingSource.DataMember].Count - 1
                                          ? EnumNavigationStatus.LastPosition
                                          : EnumNavigationStatus.InsidePosition;
                    RefreshNavigationButton();
                    ShowData();
                }
                else
                {
                    NavigationState = EnumNavigationStatus.EmptyPostion;
                    RefreshToolbar();
                    RefreshNavigationButton();
                    ShowData();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Moves the last voucher.
        /// </summary>
        protected virtual void MoveLastVoucher()
        {
            try
            {
                var iRowCount = BindingContext[MasterBindingSource, MasterBindingSource.DataMember].Count;
                if (iRowCount > 0)
                {
                    BindingContext[MasterBindingSource, MasterBindingSource.DataMember].Position = iRowCount - 1;
                    MasterBindingSource.Position =
                        BindingContext[MasterBindingSource, MasterBindingSource.DataMember].Position;
                    NavigationState = EnumNavigationStatus.LastPosition;
                    RefreshNavigationButton();
                    ShowData();
                }
                else
                {
                    NavigationState = EnumNavigationStatus.EmptyPostion;
                    RefreshToolbar();
                    RefreshNavigationButton();
                    ShowData();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Sets the numeric format control.
        /// LinhMC bo sung them dieu kien: 
        /// repositoryCurrencyCalcEdit.Precision = int.Parse(DBOptionHelper.ExchangeRateDecimalDigits)/ int.Parse(DBOptionHelper.CurrencyDecimalDigits);
        /// mục đích của thằng này là để làm tròn đúng số thập phân như định dạng khi người dùng nhấn công cụ tính toán
        /// </summary>
        /// <param name="gridView">The grid view.</param>
        /// <param name="isSummary">if set to <c>true</c> [is summary].</param>
        protected virtual void SetNumericFormatControl(GridView gridView, bool isSummary)
        {
            //Get format data from db to format grid control
            if (DesignMode) return;
            var repositoryCurrencyCalcEdit = new RepositoryItemCalcEdit { AllowMouseWheel = false };
            var repositoryNumberCalcEdit = new RepositoryItemCalcEdit { AllowMouseWheel = false };

            foreach (GridColumn oCol in gridView.Columns)
            {
                if (!oCol.Visible) continue;
                switch (oCol.UnboundType)
                {

                    case UnboundColumnType.Decimal:
                        repositoryCurrencyCalcEdit.Mask.MaskType = MaskType.Numeric;
                        if (oCol.Name == "ExchangeRate" || oCol.FieldName == "ExchangeRate")
                        {
                            repositoryCurrencyCalcEdit.Mask.EditMask = @"c" + DBOptionHelper.ExchangeRateDecimalDigits;
                            repositoryCurrencyCalcEdit.Precision = int.Parse(DBOptionHelper.ExchangeRateDecimalDigits);
                        }
                        else
                        {
                            repositoryCurrencyCalcEdit.Mask.EditMask = @"c" + DBOptionHelper.CurrencyDecimalDigits;
                            repositoryCurrencyCalcEdit.Precision = int.Parse(DBOptionHelper.CurrencyDecimalDigits);
                        }

                        repositoryCurrencyCalcEdit.Mask.Culture = Thread.CurrentThread.CurrentCulture;
                        repositoryCurrencyCalcEdit.Mask.UseMaskAsDisplayFormat = true;
                        oCol.ColumnEdit = repositoryCurrencyCalcEdit;
                        if (isSummary)
                        {
                            oCol.SummaryItem.SummaryType = SummaryItemType.Sum;
                            oCol.SummaryItem.DisplayFormat = GlobalVariable.CurrencyDisplayString;
                            oCol.SummaryItem.Format = Thread.CurrentThread.CurrentCulture;
                        }
                        break;

                    case UnboundColumnType.Integer:
                        repositoryNumberCalcEdit.Mask.MaskType = MaskType.Numeric;
                        repositoryNumberCalcEdit.Mask.EditMask = @"n0";
                        repositoryNumberCalcEdit.Mask.UseMaskAsDisplayFormat = true;
                        repositoryNumberCalcEdit.Mask.Culture = Thread.CurrentThread.CurrentCulture;
                        oCol.ColumnEdit = repositoryNumberCalcEdit;

                        if (isSummary)
                        {
                            oCol.SummaryItem.SummaryType = SummaryItemType.Sum;
                            oCol.SummaryItem.DisplayFormat = GlobalVariable.NumericDisplayString;
                            oCol.SummaryItem.Format = Thread.CurrentThread.CurrentCulture;
                        }
                        break;

                    case UnboundColumnType.DateTime:
                        oCol.DisplayFormat.FormatString =
                            Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
                        oCol.DisplayFormat.Format = Thread.CurrentThread.CurrentCulture.DateTimeFormat;
                        break;
                }
                if (oCol.FieldName == "Description")
                {
                    oCol.SummaryItem.SetSummary(SummaryItemType.Custom, "Tổng cộng");
                }
            }
        }

        /// <summary>
        /// Sets the numeric format grid band.
        /// </summary>
        /// <param name="bandedGridView">The banded grid view.</param>
        /// <param name="isSummary">if set to <c>true</c> [is summary].</param>
        protected virtual void SetNumericFormatGridBand(BandedGridView bandedGridView, bool isSummary)
        {
            //Get format data from db to format grid control
            if (DesignMode) return;
            var repositoryCurrencyCalcEdit = new RepositoryItemCalcEdit { AllowMouseWheel = false };
            var repositoryNumberCalcEdit = new RepositoryItemCalcEdit { AllowMouseWheel = false };

            foreach (var oCol in bandedGridView.Columns.Cast<GridColumn>().Where(oCol => oCol.Visible))
            {
                switch (oCol.UnboundType)
                {
                    case UnboundColumnType.Decimal:
                        repositoryCurrencyCalcEdit.Mask.MaskType = MaskType.Numeric;
                        repositoryCurrencyCalcEdit.Mask.EditMask = @"c" + DBOptionHelper.CurrencyDecimalDigits;
                        repositoryCurrencyCalcEdit.Mask.Culture = Thread.CurrentThread.CurrentCulture;
                        repositoryCurrencyCalcEdit.Mask.UseMaskAsDisplayFormat = true;
                        //LinhMC thêm 24/8/2015:
                        repositoryCurrencyCalcEdit.Precision = int.Parse(DBOptionHelper.CurrencyDecimalDigits);
                        oCol.ColumnEdit = repositoryCurrencyCalcEdit;
                        if (isSummary)
                        {
                            oCol.SummaryItem.SummaryType = SummaryItemType.Sum;
                            oCol.SummaryItem.DisplayFormat = GlobalVariable.CurrencyDisplayString;
                            oCol.SummaryItem.Format = Thread.CurrentThread.CurrentCulture;
                        }
                        break;

                    case UnboundColumnType.Integer:
                        repositoryNumberCalcEdit.Mask.MaskType = MaskType.Numeric;
                        repositoryNumberCalcEdit.Mask.EditMask = @"n0";
                        repositoryNumberCalcEdit.Mask.UseMaskAsDisplayFormat = true;
                        repositoryNumberCalcEdit.Mask.Culture = Thread.CurrentThread.CurrentCulture;
                        oCol.ColumnEdit = repositoryNumberCalcEdit;

                        if (isSummary)
                        {
                            oCol.SummaryItem.SummaryType = SummaryItemType.Sum;
                            oCol.SummaryItem.DisplayFormat = GlobalVariable.NumericDisplayString;
                            oCol.SummaryItem.Format = Thread.CurrentThread.CurrentCulture;
                        }
                        break;

                    case UnboundColumnType.DateTime:
                        oCol.DisplayFormat.FormatString =
                            Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
                        oCol.DisplayFormat.Format = Thread.CurrentThread.CurrentCulture.DateTimeFormat;
                        break;
                }
            }
        }

        /// <summary>
        /// Enables the controls in group.
        /// </summary>
        /// <param name="groupControl">The group control.</param>
        /// <param name="isEnable">if set to <c>true</c> [is enable].</param>
        protected void EnableControlsInGroup(GroupControl groupControl, bool isEnable)
        {
            foreach (var control in groupControl.Controls)
            {
                if (control.GetType() == typeof(ButtonEdit))
                {
                    ((ButtonEdit)control).Properties.ReadOnly = !isEnable;
                    for (int i = 0; i < ((ButtonEdit)control).Properties.Buttons.Count; i++)
                    {
                        ((ButtonEdit)control).Properties.Buttons[i].Enabled = isEnable;
                    }

                    ((ButtonEdit)control).Properties.AppearanceReadOnly.BackColor = Color.GhostWhite;
                }
                if (control.GetType() == typeof(TextEdit))
                {
                    ((TextEdit)control).Properties.ReadOnly = !isEnable;
                    ((TextEdit)control).Properties.AppearanceReadOnly.BackColor = Color.GhostWhite;
                }
                if (control.GetType() == typeof(DateEdit))
                {
                    ((DateEdit)control).Properties.Mask.Culture = Thread.CurrentThread.CurrentCulture;
                    ((DateEdit)control).Properties.Mask.UseMaskAsDisplayFormat = true;
                    ((DateEdit)control).Properties.ReadOnly = !isEnable;
                    ((DateEdit)control).Properties.AppearanceReadOnly.BackColor = Color.GhostWhite;
                    ((DateEdit)control).Properties.ShowDropDown = (!isEnable) ? ShowDropDown.Never : ShowDropDown.SingleClick;
                }
                if (control.GetType() == typeof(LookUpEdit))
                {
                    ((LookUpEdit)control).Properties.ReadOnly = !isEnable;
                    ((LookUpEdit)control).Properties.AppearanceReadOnly.BackColor = Color.GhostWhite;
                    ((LookUpEdit)control).Properties.ShowDropDown = (!isEnable) ? ShowDropDown.Never : ShowDropDown.SingleClick;
                }
                if (control.GetType() == typeof(ComboBoxEdit))
                {
                    ((ComboBoxEdit)control).Properties.ReadOnly = !isEnable;
                    ((ComboBoxEdit)control).Properties.AppearanceReadOnly.BackColor = Color.GhostWhite;
                    ((ComboBoxEdit)control).Properties.ShowDropDown = (!isEnable) ? ShowDropDown.Never : ShowDropDown.SingleClick;
                }
                if (control.GetType() == typeof(SimpleButton))
                {
                    ((SimpleButton)control).Enabled = isEnable;
                    ((SimpleButton)control).Appearance.BackColor = Color.GhostWhite;
                }
                if (control.GetType() == typeof(SpinEdit))
                {
                    ((SpinEdit)control).Properties.ReadOnly = !isEnable;
                    ((SpinEdit)control).Properties.AppearanceReadOnly.BackColor = Color.GhostWhite;
                }
                if (control.GetType() == typeof(MemoEdit))
                {
                    ((MemoEdit)control).Properties.ReadOnly = !isEnable;
                    ((MemoEdit)control).Properties.AppearanceReadOnly.BackColor = Color.GhostWhite;
                }
                if (control.GetType() == typeof(GridLookUpEdit))
                {
                    ((GridLookUpEdit)control).Properties.ReadOnly = !isEnable;
                    ((GridLookUpEdit)control).Properties.AppearanceReadOnly.BackColor = Color.GhostWhite;
                    ((GridLookUpEdit)control).Properties.ShowDropDown = (!isEnable) ? ShowDropDown.Never : ShowDropDown.SingleClick;
                }
                if (control.GetType() == typeof(CheckEdit))
                {
                    ((CheckEdit)control).Properties.Enabled = isEnable;
                    ((CheckEdit)control).Properties.AppearanceReadOnly.BackColor = Color.GhostWhite;
                }
                if (control.GetType() == typeof(CalcEdit))
                {
                    ((CalcEdit)control).Properties.Enabled = isEnable;
                    ((CalcEdit)control).Properties.AppearanceReadOnly.BackColor = Color.GhostWhite;
                }
            }
        }

        /// <summary>
        /// Deletes the row item.
        /// </summary>
        private void DeleteRowItem()
        {
            gridViewDetail.DeleteSelectedRows();
        }

        /// <summary>
        /// Deletes the item.
        /// LinhMC: 21/10/2015
        /// </summary>
        private void DeleteItem()
        {
            var deleteSuccess = false;
            try
            {

                ActionMode = ActionModeVoucherEnum.Delete;
                var result = XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResDeleteContent"),
                                                 ResourceHelper.GetResourceValueByName("ResDeleteCaption"),
                                                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    Delete();
                    deleteSuccess = true;//LinhMC: chạy đến đây là xóa thành công
                    SaveAuditingLog();//LINHMC ADD 27/8/2012
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"));
            }
            finally
            {
                if (deleteSuccess) //LinhMC chỉ khi nào xóa thành công mới nhảy dòng
                {
                    ActionMode = ActionModeVoucherEnum.None;
                    switch (NavigationState)
                    {
                        case EnumNavigationStatus.FirstPosition:
                            _navigationStateBeforeDelete = EnumNavigationStatus.FirstPosition;
                            MoveNextVoucher();
                            break;
                        case EnumNavigationStatus.LastPosition:
                            _navigationStateBeforeDelete = EnumNavigationStatus.LastPosition;
                            MovePreviousVoucher();
                            break;
                        case EnumNavigationStatus.InsidePosition:
                            if (_navigationStateBeforeDelete == EnumNavigationStatus.FirstPosition)
                                MoveNextVoucher();
                            else
                                MovePreviousVoucher();
                            break;
                        default:
                            MoveNextVoucher();
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Saves this instance.
        /// LinhMC: 21/10/2015
        /// </summary>
        private void Save()
        {
            try
            {
                if (ValidData())
                {
                    if (_lockPresenter.CheckLockDate(int.Parse(RefID.ToString()), (int)BaseRefTypeId, dtRefDate.DateTime))
                    {

                        XtraMessageBox.Show("Bạn không được phép nhập vào ngày đã khóa sổ.Bạn phải mở sổ để nhập ngày này!",
                        ResourceHelper.GetResourceValueByName("ResDetailContent"),
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;

                    }

                    gridViewMaster.CloseEditor();
                    gridViewDetail.CloseEditor();
                    if (gridViewMaster.UpdateCurrentRow() && gridViewDetail.UpdateCurrentRow())
                    {
                        var rowAffected = SaveData();
                        if (rowAffected > 0)
                        {
                            SaveAuditingLog();//LINHMC ADD 27/8/2012
                            _keyForSend = ActionMode == ActionModeVoucherEnum.AddNew || ActionMode == ActionModeVoucherEnum.DuplicateVoucher
                                              ? rowAffected.ToString(CultureInfo.InvariantCulture)
                                              : KeyValue;
                            if (ActionMode == ActionModeVoucherEnum.AddNew || ActionMode == ActionModeVoucherEnum.DuplicateVoucher)
                                KeyValue = _keyForSend;
                            CloseForm();
                            ActionMode = ActionModeVoucherEnum.None;
                            RefreshNavigationButton();
                            RefreshVoucher();
                        }
                        else
                            XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResSaveDataError"),
                                                ResourceHelper.GetResourceValueByName("ResDetailContent"),
                                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    //cboObjectCode.Enabled = false;
                    cboObjectCode.Properties.ReadOnly = true;
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                ReFreshControl();
            }
        }

        #endregion

        #region Functions overrides

        /// <summary>
        /// Shows the help.
        /// </summary>
        protected virtual void ShowHelp()
        {
            if (!File.Exists("BIGTIME.CHM"))
            {
                XtraMessageBox.Show("Không tìm thấy tệp trợ giúp!", "Lỗi thiếu file", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Help.ShowHelp(this, System.Windows.Forms.Application.StartupPath + @"\BIGTIME.CHM", HelpNavigator.TopicId, Convert.ToString(HelpTopicId));
        }

        /// <summary>
        /// Gets the account detail by.
        /// LinhMC
        /// </summary>
        /// <param name="accountNumber">The account number.</param>
        /// <returns></returns>
        protected virtual string GetAccountDetailBy(string accountNumber)
        {
            if (AccountLists != null && AccountLists.Count > 0)
            {
                var detailBy = "";
                var accountModel = AccountLists.FirstOrDefault(c => c.AccountCode == accountNumber);
                if (accountModel != null && accountModel.IsBudgetItem)
                    detailBy = "BudgetItemCode";
                if (accountModel != null && accountModel.IsBudgetSource)
                    detailBy = string.IsNullOrEmpty(detailBy) ? "BudgetSourceCode" : detailBy + ";BudgetSourceCode";
                if (accountModel != null && accountModel.IsAccountingObject)
                    detailBy = string.IsNullOrEmpty(detailBy) ? "AccountingObjectId" : detailBy + ";AccountingObjectId";
                if (accountModel != null && accountModel.IsCurrency)
                    detailBy = string.IsNullOrEmpty(detailBy) ? "CurrencyCode" : detailBy + ";CurrencyCode";
                if (accountModel != null && accountModel.IsCustomer)
                    detailBy = string.IsNullOrEmpty(detailBy) ? "CustomerId" : detailBy + ";CustomerId";
                if (accountModel != null && accountModel.IsEmployee)
                    detailBy = string.IsNullOrEmpty(detailBy) ? "EmployeeId" : detailBy + ";EmployeeId";
                if (accountModel != null && accountModel.IsVendor)
                    detailBy = string.IsNullOrEmpty(detailBy) ? "VendorId" : detailBy + ";VendorId";
                if (accountModel != null && accountModel.IsFixedAsset)
                    detailBy = string.IsNullOrEmpty(detailBy) ? "FixedAssetId" : detailBy + ";FixedAssetId";
                if (accountModel != null && accountModel.IsInventoryItem)
                    detailBy = string.IsNullOrEmpty(detailBy) ? "InventoryItemId" : detailBy + ";InventoryItemId";
                if (accountModel != null && accountModel.IsProject)
                    detailBy = string.IsNullOrEmpty(detailBy) ? "ProjectId" : detailBy + ";ProjectId";

                return detailBy;
            }
            return null;
        }

        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns></returns>
        protected virtual bool ValidData()
        {
            return true;
        }

        /// <summary>
        /// Saves the data.
        /// </summary>
        /// <returns></returns>
        protected virtual long SaveData()
        {
            return 0;
        }

        /// <summary>
        /// Saves the voucher.
        /// </summary>
        protected void SaveVoucher()
        {
            try
            {
                gridViewMaster.CloseEditor();
                gridViewDetail.CloseEditor();
                gridViewAccountingPararell.CloseEditor();
                if (gridViewMaster.UpdateCurrentRow() && gridViewDetail.UpdateCurrentRow() && gridViewAccountingPararell.UpdateCurrentRow())
                {
                    if (ValidData())
                    {
                        var rowAffected = SaveData();
                        if (rowAffected > 0)
                        {
                            _keyForSend = ActionMode == ActionModeVoucherEnum.AddNew || ActionMode == ActionModeVoucherEnum.DuplicateVoucher
                                              ? rowAffected.ToString(CultureInfo.InvariantCulture)
                                              : KeyValue;
                            if (ActionMode == ActionModeVoucherEnum.AddNew || ActionMode == ActionModeVoucherEnum.DuplicateVoucher)
                                KeyValue = _keyForSend;
                            CloseForm();
                            ActionMode = ActionModeVoucherEnum.None;
                            RefreshNavigationButton();

                        }
                        else
                            XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResSaveDataError"),
                                                ResourceHelper.GetResourceValueByName("ResDetailContent"),
                                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                ReFreshControl();
            }
        }

        /// <summary>
        /// Saves the auditing log.
        /// LINHMC add 27/8/2015
        /// </summary>
        /// <returns></returns>
        protected virtual int SaveAuditingLog()
        {
            return _audittingLogPresenter.Save();
        }

        /// <summary>
        /// Initializes the data.
        /// </summary>
        protected virtual void InitData()
        {
            LoadComboObjectCategory();
            InitDefaultCurrency();
            _budgetSourcesPresenter.DisplayActive();
            _accountsPresenter.DisplayActive();
            _accountingObjectsPresenter.DisplayActive(true);
            _projectsPresenter.DisplayActive();
            _customersPresenter.DisplayActive(true);
            _employeesPresenter.DisplayActive();
            _vendorsPresenter.DisplayActive(true);
            _autoBusinessesPresenter.DisplayActive();
            _budgetItemsPrensenter.DisplayActive();
            _currenciesPresenter.DisplayActive();
            //_mergersFundsPresenter.DisplayActive();
            _voucherTypesPresenter.DisplayActive();
            _banksPresenter.DisplayActive();
            _departmentsPresenter.DisplayActive();
            //_stocksPresenter.Display();
            _inventoryItemsPresenter.Display();
            _fixedAssetsPresenter.DisplayByActive(true);

            if (ActionMode == ActionModeVoucherEnum.AddNew)
            {
                AccountingObjectType = -1;
                //cboObjectCode.Enabled = false;
                cboObjectCode.Properties.ReadOnly = true;
                if (GlobalVariable.CurrencyType == 0)
                {
                    cboCurrency.EditValue = CurrencyAccounting;
                    cboExchangRate.EditValue = 1;
                    cboExchangRate.Enabled = false;
                }
                else
                {
                    cboCurrency.EditValue = CurrencyLocal;
                    cboExchangRate.EditValue = 1;
                    cboExchangRate.Enabled = true;
                }
            }
        }

        /// <summary>
        /// Show detail data.
        /// LinhMC thêm code update lại trường DetailBy trong trường hợp sửa không bắt được chi tiết
        /// </summary>
        protected virtual void ShowData()
        {
            InitData();
            InitRefInfo();

            LoadGridDetailLayout();
            if (gridAccountingParallel.Visible == true)
            {
                LoadGridParalellDetailLayout();
            }
            SetNumericFormatControl(gridViewDetail, true);
        }

        protected virtual void UpdateDetailBy()
        {
            var colAccountNumber = gridViewDetail.Columns["AccountNumber"];
            for (int i = 0; i < gridViewDetail.DataRowCount; i++)
            {
                //thangNK modify <14/01/2015>
                var accountNumber = (string)gridViewDetail.GetRowCellValue(i, colAccountNumber);
                string accountNumberDetailBy = "";
                if (accountNumber != null)
                {
                    accountNumberDetailBy = GetAccountDetailBy(accountNumber);
                }
                var correspondingAccountNumber = (string)gridViewDetail.GetRowCellValue(i, "CorrespondingAccountNumber");
                string correspondingAccountNumberDetailBy = "";
                if (correspondingAccountNumber != null)
                {
                    correspondingAccountNumberDetailBy = GetAccountDetailBy(correspondingAccountNumber);
                }


                accountNumberDetailBy = string.IsNullOrEmpty(accountNumberDetailBy)
                    ? correspondingAccountNumberDetailBy
                    : accountNumberDetailBy + ";" + correspondingAccountNumberDetailBy;
                if (accountNumberDetailBy != null)
                {
                    var detailByArray = accountNumberDetailBy.Split(';').Distinct().ToArray();
                    var detail = string.Join(";", detailByArray);
                    gridViewDetail.SetRowCellValue(i, "DetailBy", detail);
                }

            }
        }

        /// <summary>
        /// Focuses the control.
        /// </summary>
        protected virtual void InitControls()
        {
        }

        /// <summary>
        /// Adds the new voucher.
        /// </summary>
        protected virtual void AddNewVoucher()
        {
            try
            {
                ActionMode = ActionModeVoucherEnum.AddNew;
                MasterBindingSource.AddNew();
                MasterBindingSource.MoveLast();
                ShowData();
                GeneratedBaseRefNo();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Duplicates the voucher.
        /// </summary>
        protected virtual void DuplicateVoucher()
        {
            try
            {
                ActionMode = ActionModeVoucherEnum.DuplicateVoucher;
                cboExchangRate.Enabled = true;
                if ((cboCurrency.EditValue ?? "").ToString() == CurrencyAccounting)
                    cboExchangRate.Enabled = false;
                ShowData();
                GeneratedBaseRefNo();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Edits the voucher.
        /// </summary>
        protected virtual void EditVoucher()
        {
            ActionMode = ActionModeVoucherEnum.Edit;
            cboExchangRate.Enabled = true;
            if ((cboCurrency.EditValue ?? "").ToString() == CurrencyAccounting)
                cboExchangRate.Enabled = false;
        }

        /// <summary>
        /// Deletes the voucher.
        /// </summary>
        /// 
        public void Delete()
        {
            DeleteVoucher();


        }

        protected virtual void DeleteVoucher()
        {

        }

        /// <summary>
        /// Cancels the voucher.
        /// LinhMC: vì sắp xếp chứng từ theo thời gian mới nhất ở đầu danh sách,
        /// do đó sẽ phải sửa lại việc hiển thị chứng từ sẽ là chứng từ đầu tiên
        /// CurrentPosition =
        /// MasterBindingSource.Position =
        /// BindingContext[MasterBindingSource, MasterBindingSource.DataMember].Position;
        /// //MoveFirstVoucher();
        /// </summary>
        protected virtual void CancelVoucher()
        {
            try
            {
                ConfirmSaveDataChanged();
                ActionMode = ActionModeVoucherEnum.None;
                MasterBindingSource.CancelEdit();
                MasterBindingSource.ResumeBinding();
                bindingSourceDetail.CancelEdit();

                if (MasterBindingSource.Count <= 0)
                {
                    Close();
                    return;
                }
                CurrentPosition =
                    MasterBindingSource.Position =
                    BindingContext[MasterBindingSource, MasterBindingSource.DataMember].Position;
                ShowData();
                RefreshNavigationButton();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Prints the voucher.
        /// </summary>
        /// <param name="printType">Type of the print.</param>
        protected virtual void PrintVoucher(int printType)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var reportHelper = new ReportHelper();
                _reportList = _reportListPresenter.GetAllReportList();
                reportHelper.ReportLists = _reportList;
                if (printType == 0)
                {
                    reportHelper.CommonVariable = new GlobalVariable { RefId = long.Parse(KeyValue), RefType = (int)BaseRefTypeId };
                    var reportListModel = _reportList.Find(item => item.RefRypeVoucherID == (int)BaseRefTypeId && item.PrintVoucherDefault);
                    if (reportListModel != null)
                    {
                        reportHelper.PrintPreviewReport(null, reportListModel.ReportID, false);
                    }
                    else
                    {
                        XtraMessageBox.Show("Bạn chưa chọn mặc định chứng từ!", @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (printType == 1)
                {
                    reportHelper.CommonVariable = new GlobalVariable { RefId = long.Parse(KeyValue), RefType = (int)BaseRefTypeId };
                    var reportListModel = _reportList.Find(item => item.RefRypeVoucherID == (int)BaseRefTypeId && item.PrintVoucherDefault);
                    if (reportListModel != null)
                    {
                        reportHelper.PrintPreviewReport(null, reportListModel.ReportID, true);
                    }
                    else
                    {
                        XtraMessageBox.Show("Bạn chưa chọn mặc định chứng từ!", @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    using (var frmXtraPrintVoucherByLot = new FrmXtraPrintVoucherByLot())
                    {
                        frmXtraPrintVoucherByLot.RefType = BaseRefTypeId;
                        IList<ReportListModel> reportLists = _reportList.FindAll(item => item.RefRypeVoucherID == (int)BaseRefTypeId);
                        frmXtraPrintVoucherByLot.InitComboData(reportLists);
                        frmXtraPrintVoucherByLot.RefID = int.Parse(KeyValue);
                        if (frmXtraPrintVoucherByLot.ShowDialog() == DialogResult.OK)
                        {
                            var refIds = frmXtraPrintVoucherByLot.SelectedVoucher;
                            var reportVoucherID = frmXtraPrintVoucherByLot.ReportID;
                            reportHelper.CommonVariable = new GlobalVariable
                            {
                                RefIdList = refIds,
                                RefType = (int)BaseRefTypeId
                            };

                            if (reportVoucherID != null)
                            {
                                reportHelper.PrintPreviewReport(null, reportVoucherID, false);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        /// <summary>
        /// Refreshes the voucher.
        /// </summary>
        protected virtual void RefreshVoucher()
        {
            try
            {
                ShowData();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Adds the new row item.
        /// </summary>
        protected virtual void AddNewRowItem()
        {
            gridViewDetail.AddNewRow();
        }

        /// <summary>
        /// LinhMC create to copy selected rows
        /// iterate cells and compose a tab delimited string of cell values
        /// LinhMC modify 26/8/2015: thay result += view.GetRowCellDisplayText(row, view.VisibleColumns[j]);
        /// bằng: result += view.GetRowCellValue(row, view.VisibleColumns[j]);
        /// Nguyên nhân thay: dữ liệu được lấy chỉ là text được hiển thị mà không phải là giá trị
        /// nếu gặp trường hợp dữ liệu 1 cột EditValue là kiểu số, hiển thị là kiểu text sẽ phát sinh lỗi
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        private string GetSelectedValues(GridView view)
        {
            if (view.SelectedRowsCount == 0) return "";

            const string cellDelimiter = "\t";
            const string lineDelimiter = "\r\n";
            string result = "";

            for (int i = view.SelectedRowsCount - 1; i >= 0; i--)
            {
                int row = view.GetSelectedRows()[i];
                for (int j = 0; j < view.VisibleColumns.Count; j++)
                {
                    result += view.GetRowCellValue(row, view.VisibleColumns[j]);
                    if (j != view.VisibleColumns.Count - 1)
                        result += cellDelimiter;
                }
                if (i != 0)
                    result += lineDelimiter;
            }
            return result;
        }

        /// <summary>
        /// LinhMC
        /// Initializes the detail row.
        /// </summary>
        /// <param name="e">The <see cref="InitNewRowEventArgs" /> instance containing the event data.</param>
        /// <param name="view">The view.</param>
        protected virtual void InitDetailRow(InitNewRowEventArgs e, GridView view)
        {
            //var view = (GridView)sender;
            string masterAccountNumber;
            switch (BaseRefTypeId)
            {
                case RefType.PaymentCash:
                    masterAccountNumber = gridViewMaster.GetFocusedRowCellValue("AccountNumber") == null
                        ? "11121"
                        : gridViewMaster.GetFocusedRowCellValue("AccountNumber").ToString();
                    view.SetRowCellValue(e.RowHandle, "CorrespondingAccountNumber", masterAccountNumber);
                    break;
                case RefType.ReceiptCash:
                    masterAccountNumber = gridViewMaster.GetFocusedRowCellValue("AccountNumber") == null
                        ? "11121"
                        : gridViewMaster.GetFocusedRowCellValue("AccountNumber").ToString();
                    view.SetRowCellValue(e.RowHandle, "AccountNumber", masterAccountNumber);
                    break;
                case RefType.PaymentDeposite:
                    masterAccountNumber = gridViewMaster.GetFocusedRowCellValue("BankAccountCode") == null
                        ? "11221"
                        : gridViewMaster.GetFocusedRowCellValue("BankAccountCode").ToString();
                    view.SetRowCellValue(e.RowHandle, "CorrespondingAccountNumber", masterAccountNumber);
                    break;
                case RefType.ReceiptDeposite:
                    masterAccountNumber = gridViewMaster.GetFocusedRowCellValue("BankAccountCode") == null
                        ? "11221"
                        : gridViewMaster.GetFocusedRowCellValue("BankAccountCode").ToString();
                    view.SetRowCellValue(e.RowHandle, "AccountNumber", masterAccountNumber);
                    break;
            }

            var clipboardData = Clipboard.GetDataObject();
            if (clipboardData == null || !clipboardData.GetDataPresent(_typeOfModel)) return;
            var data = clipboardData.GetData(_typeOfModel);
            IList<PropertyInfo> propertyInfos = new List<PropertyInfo>(_typeOfModel.GetProperties());
            foreach (
                var gridColumn in gridViewDetail.Columns.Cast<GridColumn>().Where(gridColumn => gridColumn.Visible).OrderBy(x => x.VisibleIndex))
            {
                var property =
                    (from propertyInfo in propertyInfos
                     where propertyInfo.Name == gridColumn.FieldName
                     select propertyInfo).First();
                gridViewDetail.SetRowCellValue(e.RowHandle, gridColumn, property.GetValue(data, null));
            }
        }

        /// <summary>
        /// LinhMC
        /// Initializes the new row.
        /// </summary>
        protected void InitCopyNewRow(InitNewRowEventArgs e, GridView view)
        {
            IDataObject data = Clipboard.GetDataObject();

            string s = "";
            if (data != null && data.GetDataPresent(DataFormats.UnicodeText))
                s = data.GetData(DataFormats.UnicodeText).ToString();

            string[] dataRow = s.Split('\t');
            for (int j = 0; j < view.VisibleColumns.Count; j++)
            {
                Type type = view.VisibleColumns[j].ColumnType;

                if (type != typeof(string) && string.IsNullOrEmpty(dataRow[j]))
                    continue;
                view.SetRowCellValue(e.RowHandle, view.VisibleColumns[j], dataRow[j]);
            }

            view.FocusedRowHandle = e.RowHandle;
        }

        /// <summary>
        /// LinhMC
        /// Copies the and paste row item.
        /// </summary>
        /// <param name="view">The view.</param>
        protected virtual void CopyAndPasteRowItem(GridView view)
        {
            if (ActionMode != ActionModeVoucherEnum.None)
            {
                IsCopyRow = true;
                string selectedCellsText = GetSelectedValues(view);
                Clipboard.SetDataObject(selectedCellsText);

                if (!string.IsNullOrEmpty(selectedCellsText))
                {
                    view.AddNewRow();
                }
                IsCopyRow = false;
            }
        }

        /// <summary>
        /// LinhMC: don't use this method
        /// Copies the row item.
        /// </summary>
        protected virtual void CopyRowItem()
        {
            try
            {
                gridViewDetail.AddNewRow();
                for (int i = 0; i < gridViewDetail.RowCount - 1; i++)
                {
                    for (int ii = 0; ii < gridViewDetail.Columns.Count; ii++)
                    {
                        if (gridViewDetail.Columns[ii].UnboundType != UnboundColumnType.Decimal && gridViewDetail.Columns[ii].Visible)
                            gridViewDetail.SetRowCellValue(gridViewDetail.FocusedRowHandle, gridViewDetail.Columns[ii], gridViewDetail.GetDisplayTextByColumnValue(gridViewDetail.Columns[ii], gridViewDetail.GetRowCellValue(i, gridViewDetail.Columns[ii])));
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Initializes the reference information.
        /// </summary>
        protected virtual void InitRefInfo()
        {
            if (ActionMode != ActionModeVoucherEnum.AddNew) return;
            dtPostDate.EditValue = BasePostedDate;
            dtRefDate.EditValue = dtPostDate.EditValue;
        }

        /// <summary>
        /// Sets the enable group box.
        /// </summary>
        /// <param name="isEnable">if set to <c>true</c> [is enable].</param>
        protected virtual void SetEnableGroupBox(bool isEnable)
        {

        }

        /// <summary>
        /// Initializes the compare data.
        /// </summary>
        protected virtual void InitCompareData()
        {

        }

        /// <summary>
        /// Confirms the save data changed.
        /// </summary>
        private void ConfirmSaveDataChanged()
        {
            GridViewCloseEditor();
            if (ActionMode != ActionModeVoucherEnum.None && GetDataChanged())
            {
                if (
                    XtraMessageBox.Show("Dữ liệu đã thay đổi bạn có muốn lưu lại không?", "Thông báo",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Save();
                }
            }
        }

        /// <summary>
        /// Grids the view close editor.
        /// </summary>
        /// <returns></returns>
        protected virtual bool GridViewCloseEditor()
        {
            gridViewMaster.CloseEditor();
            gridViewDetail.CloseEditor();
            gridViewAccountingPararell.CloseEditor();
            return gridViewMaster.UpdateCurrentRow() && gridViewDetail.UpdateCurrentRow() && gridViewAccountingPararell.UpdateCurrentRow();
        }

        /// <summary>
        /// Gets the data changed.
        /// LinhMC: 21/10/2015
        /// </summary>
        /// <returns></returns>
        protected virtual bool GetDataChanged()
        {
            return false;
        }

        #endregion

        #region Repository

        public RepositoryItemGridLookUpEdit _rpsBudgetSource;
        public GridView _rpsBudgetSourceView;

        public RepositoryItemGridLookUpEdit _rpsAccountNumber;
        public GridView _rpsAccountNumberView;

        public RepositoryItemGridLookUpEdit _rpsCorrespondingAccountNumber;
        public GridView _rpsCorrespondingAccountNumberView;

        public RepositoryItemGridLookUpEdit _rpsMasterAccountNumber;
        public GridView _rpsMasterAccountNumberView;

        public RepositoryItemGridLookUpEdit _rpsAccountingObject;
        public GridView _rpsAccountingObjectView;

        public RepositoryItemGridLookUpEdit _rpsDepartment;
        public GridView _rpsdepartmentView;

        public RepositoryItemGridLookUpEdit _rpsProject;
        public GridView _rpsProjectView;

        public RepositoryItemGridLookUpEdit _rpsCustomer;
        public GridView _rpsCustomerView;

        public RepositoryItemGridLookUpEdit _rpsAutoBusiness;
        public GridView _rpsAutoBusinessView;

        public RepositoryItemGridLookUpEdit _rpsBudgetItem;
        public GridView _rpsBudgetItemView;

        public RepositoryItemGridLookUpEdit _rpsCurrency;
        public GridView _rpsCurrencyView;

        public RepositoryItemGridLookUpEdit _rpsMergerFund;
        public GridView _rpsMergerFundView;

        public RepositoryItemGridLookUpEdit _rpsVoucherTypeId;
        public GridView _rpsVoucherTypeIdView;

        public RepositoryItemGridLookUpEdit _rpsBank;
        public GridView _rpsBankView;

        public RepositoryItemGridLookUpEdit _rpsStock;
        public GridView _rpsStockView;

        public RepositoryItemGridLookUpEdit _rpsInventoryItem;
        public GridView _rpsInventoryItemView;

        public RepositoryItemGridLookUpEdit _rpsVendor;
        public RepositoryItemGridLookUpEdit _rpsEmployees;

        public RepositoryItemGridLookUpEdit _rpsBudgetSourceParalell;
        public GridView _rpsBudgetSourceParalellView;

        public RepositoryItemGridLookUpEdit _rpsAccountNumberParalell;
        public GridView _rpsAccountNumberParalellView;

        public RepositoryItemGridLookUpEdit _rpsCorrespondingAccountNumberParalell;
        public GridView _rpsCorrespondingAccountNumberParalellView;

        public RepositoryItemGridLookUpEdit _rpsMasterAccountNumberParalell;
        public GridView _rpsMasterAccountNumberParalellView;

        public RepositoryItemGridLookUpEdit _rpsAccountingObjectParalell;
        public GridView _rpsAccountingObjectParalellView;

        public RepositoryItemGridLookUpEdit _rpsDepartmentParalell;
        public GridView _rpsdepartmentParalellView;

        public RepositoryItemGridLookUpEdit _rpsProjectParalell;
        public GridView _rpsProjectParalellView;

        public RepositoryItemGridLookUpEdit _rpsCustomerParalell;
        public GridView _rpsCustomerParalellView;

        public RepositoryItemGridLookUpEdit _rpsAutoBusinessParalell;
        public GridView _rpsAutoBusinessParalellView;

        public RepositoryItemGridLookUpEdit _rpsBudgetItemParalell;
        public GridView _rpsBudgetItemParalellView;

        public RepositoryItemGridLookUpEdit _rpsCurrencyParalell;
        public GridView _rpsCurrencyParalellView;

        public RepositoryItemGridLookUpEdit _rpsMergerFundParalell;
        public GridView _rpsMergerFundParalellView;

        public RepositoryItemGridLookUpEdit _rpsVoucherTypeIdParalell;
        public GridView _rpsVoucherTypeIdParalellView;

        public RepositoryItemGridLookUpEdit _rpsBankParalell;
        public GridView _rpsBankParalellView;

        public RepositoryItemGridLookUpEdit _rpsStockParalell;
        public GridView _rpsStockParalellView;

        public RepositoryItemGridLookUpEdit _rpsInventoryItemParalell;
        public GridView _rpsInventoryItemParalellView;

        public RepositoryItemGridLookUpEdit _rpsVendorParalell;
        public RepositoryItemGridLookUpEdit _rpsEmployeesParalell;

        public RepositoryItemGridLookUpEdit _rpsFixedAssetParalell;

        #endregion

        #region Presenter

        protected readonly AccountsPresenter _accountsPresenter;
        protected readonly AutoBusinessesPresenter _autoBusinessesPresenter;
        protected readonly BudgetItemsPresenter _budgetItemsPrensenter;
        protected readonly BudgetSourcesPresenter _budgetSourcesPresenter;
        protected readonly BanksPresenter _banksPresenter;
        protected readonly CurrenciesPresenter _currenciesPresenter;
        protected readonly DepartmentsPresenter _departmentsPresenter;
        //protected readonly MergerFundsPresenter _mergersFundsPresenter;
        protected readonly ProjectsPresenter _projectsPresenter;
        protected readonly VoucherTypesPresenter _voucherTypesPresenter;
        protected readonly StocksPresenter _stocksPresenter;
        protected readonly InventoryItemsPresenter _inventoryItemsPresenter;
        protected readonly FixedAssetsPresenter _fixedAssetsPresenter;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmXtraBaseVoucherDetail" /> class.
        /// </summary>
        public FrmXtraBaseVoucherDetail()
        {
            InitializeComponent();
            _lockPresenter = new LockPresenter(this);
            _autoNumberPresenter = new AutoNumberPresenter(this);
            _calculateClosingPresenter = new CalculateClosingPresenter(this);
            _audittingLogPresenter = new AudittingLogPresenter(this);
            _refTypesPresenter = new RefTypesPresenter(this);
            _budgetSourcesPresenter = new BudgetSourcesPresenter(this);
            _accountsPresenter = new AccountsPresenter(this);
            _accountingObjectsPresenter = new AccountingObjectsPresenter(this);
            _projectsPresenter = new ProjectsPresenter(this);
            _banksPresenter = new BanksPresenter(this);
            _customersPresenter = new CustomersPresenter(this);
            _employeesPresenter = new EmployeesPresenter(this);
            _vendorsPresenter = new VendorsPresenter(this);
            _autoBusinessesPresenter = new AutoBusinessesPresenter(this);
            _budgetItemsPrensenter = new BudgetItemsPresenter(this);
            _currenciesPresenter = new CurrenciesPresenter(this);
          //  _mergersFundsPresenter = new MergerFundsPresenter(this);
            _voucherTypesPresenter = new VoucherTypesPresenter(this);
            _departmentsPresenter = new DepartmentsPresenter(this);
            //_stocksPresenter = new StocksPresenter(this);
            _inventoryItemsPresenter = new InventoryItemsPresenter(this);
            _fixedAssetsPresenter = new FixedAssetsPresenter(this);
            cboCurrency.Enabled = false;
        }

        /// <summary>
        /// Handles the Load event of the FrmXtraBaseVoucherDetail control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void FrmXtraBaseVoucherDetail_Load(object sender, EventArgs e)
        {
            try
            {
                if (DesignMode) return;
                InitializeLayout();
                _refTypesPresenter.Display();
                ShowData();
                GeneratedBaseRefNo();
                SetNumericFormatControl(gridViewDetail, true);
                _reportListPresenter = new ReportListPresenter(this);
                InitCompareData();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the ItemClick event of the barToolManager control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ItemClickEventArgs" /> instance containing the event data.</param>
        private void barToolManager_ItemClick(object sender, ItemClickEventArgs e)
        {
            switch (e.Item.Name)
            {
                case "barButtonFirstItem":
                    MoveFirstVoucher();
                    break;
                case "barButtonPreviousItem":
                    MovePreviousVoucher();
                    break;
                case "barButtonNextItem":
                    MoveNextVoucher();
                    break;
                case "barButtonLastItem":
                    MoveLastVoucher();
                    break;
                case "barButtonAddNewItem":
                    AddNewVoucher();
                    break;
                case "barButtonDuplicateItem":
                    DuplicateVoucher();
                    break;
                case "barButtonEditItem":
                    if (_lockPresenter.CheckLockDate(int.Parse(KeyValue), (int)BaseRefTypeId))
                    {
                        XtraMessageBox.Show("Chứng từ hiện tại bị khóa sổ. Bạn phải mở sổ để sửa chứng từ này!.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
                    EditVoucher();
                    //cboObjectCode.Enabled = true;
                    cboObjectCode.Properties.ReadOnly = false;
                    break;
                case "barButtonDeleteItem":
                    if (_lockPresenter.CheckLockDate(int.Parse(KeyValue), (int)BaseRefTypeId))
                    {
                        XtraMessageBox.Show("Chứng từ hiện tại đang bị khóa sổ. Bạn phải mở sổ để xóa chứng từ này!.", "Thông báo",
                                                     MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
                    DeleteItem();
                    break;
                case "barButtonSaveItem":
                    if (CheckExchangRate())
                        Save();
                    break;
                case "barButtonCancelItem":
                    CancelVoucher();
                    break;
                case "barButtonRefeshItem":
                    RefreshVoucher();
                    break;
                case "barPreviewVoucherItem":
                    PrintVoucher(0);
                    break;
                case "barButtonPrintVoucher":
                    PrintVoucher(1);
                    break;
                case "barButtonPrintVoucherByLot":
                    PrintVoucher(2);
                    break;
                case "barButtonHelpItem":
                    ShowHelp();
                    break;
                case "barButtonCloseItem":
                    Close();
                    break;
                case "barButtonDeleteRowItem":
                    DeleteRowItem();
                    break;
                case "barButtonAddNewRowItem":
                    AddNewRowItem();
                    break;
                case "barButtonCopyRow":
                    CopyAndPasteRowItem(gridViewDetail);
                    break;
            }
        }

        private bool CheckExchangRate()
        {
            try
            {
                if (BaseRefTypeId == RefType.FixedAssetArmortization
                    || BaseRefTypeId == RefType.GeneralVoucher 
                    || BaseRefTypeId == RefType.ReceiptEstimate 
                    || BaseRefTypeId == RefType.PaymentEstimate
                    || BaseRefTypeId == RefType.AccountTranferVourcher) 
                    return true;

                this.ActiveControl = null;
                string result1 = "0" + DBOptionHelper.CurrencyDecimalSeparator;
                string result2 = "1" + DBOptionHelper.CurrencyDecimalSeparator;
                var count = Convert.ToInt32(DBOptionHelper.ExchangeRateDecimalDigits);
                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        result1 += "0";
                        result2 += "0";
                    }
                }
                else
                {
                    result1 = "0";
                    result2 = "1";
                }
                var result = Convert.ToDecimal(cboExchangRate.EditValue);
                if (cboExchangRate.Enabled)
                {
                    if (result.Equals(Convert.ToDecimal(result1)))
                    {
                        XtraMessageBox.Show("Tỷ giá phải khác 0 và 1", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        return false;
                    }
                    else if ((cboCurrency.EditValue ?? "").ToString() != CurrencyAccounting && result.Equals(Convert.ToDecimal(result2)))
                    {
                        XtraMessageBox.Show("Tỷ giá phải khác 0 và 1", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        return false;
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                return true;
            }
        }

        /// <summary>
        /// Handles the InvalidRowException event of the gridViewDetail control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="InvalidRowExceptionEventArgs" /> instance containing the event data.</param>
        private void gridViewDetail_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        /// <summary>
        /// Handles the PopupMenuShowing event of the gridViewDetail control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PopupMenuShowingEventArgs" /> instance containing the event data.</param>
        private void gridViewDetail_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (IsInVisiblePopupMenuGrid) return;
            var view = sender as GridView;
            if (view != null)
            {
                var hitInfo = view.CalcHitInfo(e.Point);
                if (hitInfo.InRow)
                {
                    view.FocusedRowHandle = hitInfo.RowHandle;
                    popupGridDetailMenu.ShowPopup(grdDetail.PointToScreen(e.Point));
                }
            }
        }

        /// <summary>
        /// Handles the CustomDrawColumnHeader event of the gridViewDetail control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ColumnHeaderCustomDrawEventArgs" /> instance containing the event data.</param>
        private void gridViewDetail_CustomDrawColumnHeader(object sender, ColumnHeaderCustomDrawEventArgs e)
        {
            var viewInfo = (GridViewInfo)gridViewDetail.GetViewInfo();
            var rec = new Rectangle(e.Bounds.X + 2, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
            if (e.Column == null) return;
            if (e.Column == viewInfo.FixedLeftColumn || e.Column == viewInfo.ColumnsInfo.LastColumnInfo.Column)
            {
                foreach (DevExpress.Utils.Drawing.DrawElementInfo info in e.Info.InnerElements)
                {
                    if (!info.Visible) continue;
                    DevExpress.Utils.Drawing.ObjectPainter.DrawObject(e.Cache, info.ElementPainter, info.ElementInfo);
                }
                e.Painter.DrawCaption(e.Info, e.Info.Caption, e.Appearance.Font, e.Appearance.GetForeBrush(e.Cache), rec, e.Appearance.GetStringFormat());
                e.Graphics.DrawLine(Pens.DarkGray, e.Bounds.Left - 1, e.Bounds.Bottom - 1, e.Bounds.Right - 1, e.Bounds.Bottom - 1);
                e.Handled = true;
            }
        }

        /// <summary>
        /// Handles the CustomDrawColumnHeader event of the gridViewMaster control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ColumnHeaderCustomDrawEventArgs" /> instance containing the event data.</param>
        private void gridViewMaster_CustomDrawColumnHeader(object sender, ColumnHeaderCustomDrawEventArgs e)
        {
            var viewInfo = (GridViewInfo)gridViewMaster.GetViewInfo();
            var rec = new Rectangle(e.Bounds.X + 2, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);

            if (e.Column == null) return;
            if (e.Column == viewInfo.FixedLeftColumn || e.Column == viewInfo.ColumnsInfo.LastColumnInfo.Column)
            {
                foreach (DevExpress.Utils.Drawing.DrawElementInfo info in e.Info.InnerElements)
                {
                    if (!info.Visible) continue;
                    DevExpress.Utils.Drawing.ObjectPainter.DrawObject(e.Cache, info.ElementPainter, info.ElementInfo);
                }

                e.Painter.DrawCaption(e.Info, e.Info.Caption, e.Appearance.Font, e.Appearance.GetForeBrush(e.Cache),
                    rec, e.Appearance.GetStringFormat());
                e.Graphics.DrawLine(Pens.DarkGray, e.Bounds.Left - 1, e.Bounds.Bottom - 1, e.Bounds.Right - 1,
                    e.Bounds.Bottom - 1);
                e.Handled = true;
            }
        }

        #region IReportView Members

        /// <summary>
        /// Sets the report lists.
        /// </summary>
        /// <value>
        /// The report lists.
        /// </value>
        public List<ReportListModel> ReportLists
        {
            get
            {
                return _reportList;
            }
            set
            {
                _reportList = value;
            }
        }

        public virtual IList<BudgetSourceModel> BudgetSources
        {
            set
            {
                try
                {
                    if (value == null)
                        value = new List<BudgetSourceModel>();
                    else
                        value = value.Where(w => w.IsParent == false).ToList();

                    if (_rpsBudgetSource == null) _rpsBudgetSource = new RepositoryItemGridLookUpEdit();
                    _rpsBudgetSource.KeyDown += repositoryItemGridLookUpEdit_KeyDown;
                    GridLookUpItem.BudgetSource(value ?? new List<BudgetSourceModel>(), _rpsBudgetSource, "BudgetSourceCode", "BudgetSourceCode");

                    if (_rpsBudgetSourceParalell == null) _rpsBudgetSourceParalell = new RepositoryItemGridLookUpEdit();
                    _rpsBudgetSourceParalell.KeyDown += repositoryItemGridLookUpEdit_KeyDown;
                    GridLookUpItem.BudgetSource(value ?? new List<BudgetSourceModel>(), _rpsBudgetSourceParalell, "BudgetSourceCode", "BudgetSourceCode");
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public virtual IList<AccountModel> Accounts
        {
            set
            {
                if (value == null)
                    value = new List<AccountModel>();
                AccountLists = value;
                if (_rpsMasterAccountNumber == null)
                    _rpsMasterAccountNumber = new RepositoryItemGridLookUpEdit();
                _rpsMasterAccountNumber.KeyDown += repositoryItemGridLookUpEdit_KeyDown;
                if (_rpsAccountNumber == null)
                    _rpsAccountNumber = new RepositoryItemGridLookUpEdit();
                _rpsAccountNumber.KeyDown += repositoryItemGridLookUpEdit_KeyDown;
                if (_rpsCorrespondingAccountNumber == null)
                    _rpsCorrespondingAccountNumber = new RepositoryItemGridLookUpEdit();
                _rpsCorrespondingAccountNumber.KeyDown += repositoryItemGridLookUpEdit_KeyDown;

                if (_rpsMasterAccountNumberParalell == null)
                    _rpsMasterAccountNumberParalell = new RepositoryItemGridLookUpEdit();
                _rpsMasterAccountNumberParalell.KeyDown += repositoryItemGridLookUpEdit_KeyDown;
                if (_rpsAccountNumberParalell == null)
                    _rpsAccountNumberParalell = new RepositoryItemGridLookUpEdit();
                _rpsAccountNumber.KeyDown += repositoryItemGridLookUpEdit_KeyDown;

                GridLookUpItem.Account(value, _rpsAccountNumberParalell, "AccountCode", "AccountCode");
                if (_rpsCorrespondingAccountNumberParalell == null)
                    _rpsCorrespondingAccountNumberParalell = new RepositoryItemGridLookUpEdit();
                _rpsCorrespondingAccountNumberParalell.KeyDown += repositoryItemGridLookUpEdit_KeyDown;
                GridLookUpItem.Account(value, _rpsCorrespondingAccountNumberParalell, "AccountCode", "AccountCode");

                RefTypeModel refType = RefTypes.Where(w => w.RefTypeId == (int)BaseRefTypeId)?.FirstOrDefault() ?? null;
                if (refType != null)
                {
                    var lstAccounts = refType.DefaultDebitAccountCategoryId == null ? new List<string>() : refType.DefaultDebitAccountCategoryId.Split(new char[] { ';' }).ToList();
                    GridLookUpItem.Account(value.Where(w => lstAccounts.Contains(w.AccountCode)).ToList() ?? new List<AccountModel>(), _rpsAccountNumber, "AccountCode", "AccountCode");

                    lstAccounts = refType.DefaultCreditAccountCategoryId == null ? new List<string>() : refType.DefaultCreditAccountCategoryId.Split(new char[] { ';' }).ToList();
                    GridLookUpItem.Account(value.Where(w => lstAccounts.Contains(w.AccountCode)).ToList() ?? new List<AccountModel>(), _rpsCorrespondingAccountNumber, "AccountCode", "AccountCode");

                    if (!IsParentAccount)
                    {
                        GridLookUpItem.Account(value.Where(x => x.IsDetail).ToList(), _rpsMasterAccountNumber, "AccountCode", "AccountCode");
                    }
                    else
                    {
                        GridLookUpItem.Account(value.Where(x => x.AccountCode.IndexOf("111", StringComparison.Ordinal) == 0).ToList(), _rpsMasterAccountNumber, "AccountCode", "AccountCode");
                    }
                }
                else
                {
                    if (!IsParentAccount)
                    {
                        GridLookUpItem.Account(value.Where(x => x.AccountCode.IndexOf("111", StringComparison.Ordinal) == 0 && x.IsDetail).ToList(), _rpsAccountNumber, "AccountCode", "AccountCode");
                        GridLookUpItem.Account(value.Where(x => x.IsDetail).ToList(), _rpsMasterAccountNumber, "AccountCode", "AccountCode");
                        GridLookUpItem.Account(value.Where(x => x.AccountCode.IndexOf("111", StringComparison.Ordinal) == 0 && x.IsDetail).ToList(), _rpsAccountNumberParalell, "AccountCode", "AccountCode");
                        GridLookUpItem.Account(value.Where(x => x.IsDetail).ToList(), _rpsMasterAccountNumberParalell, "AccountCode", "AccountCode");
                    }
                    else
                    {
                        GridLookUpItem.Account(value, _rpsAccountNumber, "AccountCode", "AccountCode");
                        GridLookUpItem.Account(value.Where(x => x.AccountCode.IndexOf("111", StringComparison.Ordinal) == 0).ToList(), _rpsMasterAccountNumberParalell, "AccountCode", "AccountCode");
                    }
                    GridLookUpItem.Account(value, _rpsCorrespondingAccountNumberParalell, "AccountCode", "AccountCode");
                }
            }
        }

        public virtual IList<AccountingObjectModel> AccountingObjects
        {
            set
            {
                GridLookUpItem.AccountingObject(value ?? new List<AccountingObjectModel>(), cboObjectCode, grdLookupAccountingObject, "AccountingObjectCode", "AccountingObjectId");

                if (_rpsAccountingObject == null)
                    _rpsAccountingObject = new RepositoryItemGridLookUpEdit();
                GridLookUpItem.AccountingObject(value, _rpsAccountingObject, "AccountingObjectCode", "AccountingObjectId");

                if (_rpsAccountingObjectParalell == null)
                    _rpsAccountingObjectParalell = new RepositoryItemGridLookUpEdit();
                GridLookUpItem.AccountingObject(value, _rpsAccountingObjectParalell, "AccountingObjectCode", "AccountingObjectId");
            }
        }

        public virtual IList<ProjectModel> Projects
        {
            set
            {
                if (_rpsProject == null)
                    _rpsProject = new RepositoryItemGridLookUpEdit();
                _rpsProject.KeyDown += repositoryItemGridLookUpEdit_KeyDown;
                GridLookUpItem.Project(value, _rpsProject, "ProjectCode", "ProjectId");

                if (_rpsProjectParalell == null)
                    _rpsProjectParalell = new RepositoryItemGridLookUpEdit();
                _rpsProjectParalell.KeyDown += repositoryItemGridLookUpEdit_KeyDown;
                GridLookUpItem.Project(value, _rpsProjectParalell, "ProjectCode", "ProjectId");
            }
        }

        public virtual IList<AutoBusinessModel> AutoBusinesses
        {
            set
            {
                if (_rpsAutoBusiness == null)
                    _rpsAutoBusiness = new RepositoryItemGridLookUpEdit();
                var datasource = value.Where(x => x.RefTypeId == (int)BaseRefTypeId).ToList();

                if (BaseRefTypeId != RefType.GeneralVoucher && BaseRefTypeId != RefType.FixedAssetArmortization)// && ActionMode != ActionModeVoucherEnum.AddNew)
                {
                    var cboCurrencyCode = cboCurrency.EditValue == null ? "" : cboCurrency.EditValue.ToString();
                    datasource = cboCurrencyCode == CurrencyAccounting ? datasource.Where(w => w.CurrencyCode == CurrencyAccounting).ToList() : datasource.Where(w => w.CurrencyCode == CurrencyLocal).ToList();
                }

                lstAutoBusinessBase = value.Where(x => x.RefTypeId == (int)BaseRefTypeId).ToList();

                _rpsAutoBusiness.KeyDown += repositoryItemGridLookUpEdit_KeyDown;

                GridLookUpItem.AutoBusiness(datasource, _rpsAutoBusiness, "AutoBusinessCode", "AutoBusinessId");

                if (_rpsAutoBusinessParalell == null)
                    _rpsAutoBusinessParalell = new RepositoryItemGridLookUpEdit();
                _rpsAutoBusinessParalell.KeyDown += repositoryItemGridLookUpEdit_KeyDown;

                GridLookUpItem.AutoBusiness(datasource, _rpsAutoBusinessParalell, "AutoBusinessCode", "AutoBusinessId");
            }
        }

        public virtual IList<BudgetItemModel> BudgetItems
        {
            set
            {
                if (_rpsBudgetItem == null)
                    _rpsBudgetItem = new RepositoryItemGridLookUpEdit();

                _rpsBudgetItem.KeyDown += repositoryItemGridLookUpEdit_KeyDown;

                if (_rpsBudgetItemParalell == null)
                    _rpsBudgetItemParalell = new RepositoryItemGridLookUpEdit();

                _rpsBudgetItemParalell.KeyDown += repositoryItemGridLookUpEdit_KeyDown;

                var datasoure = value.Where(x => (x.BudgetItemType == 4 || (x.BudgetItemType == 3 && x.IsShowOnVoucher == true)) && x.IsActive == true).ToList();

                GridLookUpItem.BudgetItem(datasoure, _rpsBudgetItem, "BudgetItemCode", "BudgetItemCode");
                GridLookUpItem.BudgetItem(datasoure, _rpsBudgetItemParalell, "BudgetItemCode", "BudgetItemCode");
            }
        }

        public virtual IList<CurrencyModel> Currencies
        {
            set
            {
                if (_rpsCurrency == null)
                    _rpsCurrency = new RepositoryItemGridLookUpEdit();
                _rpsCurrencyView = new GridView();

                GridLookUpItem.Currency(value, _rpsCurrency, "CurrencyCode", "CurrencyCode");
            }
        }

        //public virtual IList<MergerFundModel> MergerFunds
        //{
        //    set
        //    {
        //        _rpsMergerFund = new RepositoryItemGridLookUpEdit();
        //        _rpsMergerFundView = new GridView();


        //        _rpsMergerFund.DataSource = value;

        //        _rpsMergerFundParalell = new RepositoryItemGridLookUpEdit();
        //        _rpsMergerFundParalellView = new GridView();


        //        _rpsMergerFundParalell.DataSource = value;

        //        var colColection = new List<XtraColumn>();
        //        colColection.Clear();

        //        colColection.Add(new XtraColumn
        //        {
        //            ColumnName = "MergerFundCode",
        //            ColumnCaption = "Mã quỹ sát nhập",
        //            ColumnPosition = 1,
        //            ColumnVisible = true,
        //            ColumnWith = 100,
        //            Alignment = HorzAlignment.Center
        //        });
        //        colColection.Add(new XtraColumn
        //        {
        //            ColumnName = "MergerFundName",
        //            ColumnCaption = "Tên quỹ sát nhập",
        //            ColumnPosition = 2,
        //            ColumnVisible = true,
        //            ColumnWith = 400,
        //            Alignment = HorzAlignment.Center
        //        });
        //        colColection.Add(new XtraColumn { ColumnName = "Description", ColumnVisible = false });
        //        colColection.Add(new XtraColumn { ColumnName = "IsActive", ColumnVisible = false });
        //        colColection.Add(new XtraColumn { ColumnName = "IsSystem", ColumnVisible = false });
        //        colColection.Add(new XtraColumn { ColumnName = "Grade", ColumnVisible = false });
        //        colColection.Add(new XtraColumn { ColumnName = "ForeignName", ColumnVisible = false });
        //        colColection.Add(new XtraColumn { ColumnName = "MergerFundId", ColumnVisible = false });
        //        colColection.Add(new XtraColumn { ColumnName = "ParentId", ColumnVisible = false });

        //        _rpsMergerFund.View.OptionsView.ShowIndicator = false;
        //        _rpsMergerFund.DisplayMember = "MergerFundCode";
        //        _rpsMergerFund.ValueMember = "MergerFundId";

        //        _rpsMergerFundView = XtraColumnCollectionHelper<MergerFundModel>.CreateGridViewReponsitory();
        //        _rpsMergerFund = XtraColumnCollectionHelper<MergerFundModel>.CreateGridLookUpEditReponsitory(_rpsMergerFundView, value, "MergerFundCode", "MergerFundId", colColection);
        //        XtraColumnCollectionHelper<MergerFundModel>.ShowXtraColumnInGridView(colColection, _rpsMergerFundView);

        //        _rpsMergerFundParalell.View.OptionsView.ShowIndicator = false;
        //        _rpsMergerFundParalell.DisplayMember = "MergerFundCode";
        //        _rpsMergerFundParalell.ValueMember = "MergerFundId";

        //        _rpsMergerFundParalellView = XtraColumnCollectionHelper<MergerFundModel>.CreateGridViewReponsitory();
        //        _rpsMergerFundParalell = XtraColumnCollectionHelper<MergerFundModel>.CreateGridLookUpEditReponsitory(_rpsMergerFundParalellView, value, "MergerFundCode", "MergerFundId", colColection);
        //        XtraColumnCollectionHelper<MergerFundModel>.ShowXtraColumnInGridView(colColection, _rpsMergerFundParalellView);
        //    }
        //}

        public virtual IList<VoucherTypeModel> VoucherTypes
        {
            set
            {
                if (_rpsVoucherTypeId == null)
                    _rpsVoucherTypeId = new RepositoryItemGridLookUpEdit();

                if (_rpsVoucherTypeIdView == null)
                    _rpsVoucherTypeIdView = new GridView();

                _rpsVoucherTypeId.KeyDown += repositoryItemGridLookUpEdit_KeyDown;
                _rpsVoucherTypeId.View = _rpsVoucherTypeIdView;

                GridLookUpItem.VoucherType(value, _rpsVoucherTypeId, "VoucherTypeName", "VoucherTypeId");

                if (_rpsVoucherTypeIdParalell == null)
                    _rpsVoucherTypeIdParalell = new RepositoryItemGridLookUpEdit();

                if (_rpsVoucherTypeIdParalellView == null)
                    _rpsVoucherTypeIdParalellView = new GridView();

                _rpsVoucherTypeIdParalell.KeyDown += repositoryItemGridLookUpEdit_KeyDown;

                GridLookUpItem.VoucherType(value, _rpsVoucherTypeIdParalell, "VoucherTypeName", "VoucherTypeId");
            }
        }

        public virtual IList<BankModel> Banks
        {
            set
            {
                GridLookUpItem.Bank(value, cboBank, cboBankView, "BankName", "BankId");

                if (_rpsBank == null) _rpsBank = new RepositoryItemGridLookUpEdit();
                _rpsBank.KeyDown += repositoryItemGridLookUpEdit_KeyDown;
                GridLookUpItem.Bank(value, _rpsBank, "BankAccount", "BankId");

                if (_rpsBankParalell == null) _rpsBankParalell = new RepositoryItemGridLookUpEdit();
                _rpsBankParalell.KeyDown += repositoryItemGridLookUpEdit_KeyDown;
                GridLookUpItem.Bank(value, _rpsBankParalell, "BankAccount", "BankId");
            }
        }


        #endregion

        /// <summary>
        /// Handles the EditValueChanged event of the dtPostDate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void dtPostDate_EditValueChanged(object sender, EventArgs e)
        {
            dtRefDate.EditValue = dtPostDate.EditValue;
        }

        /// <summary>
        /// Handles the InitNewRow event of the gridViewDetail control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="InitNewRowEventArgs" /> instance containing the event data.</param>
        private void gridViewDetail_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            try
            {
                var view = (GridView)sender;
                if (!IsCopyRow)
                {
                    InitDetailRow(e, view);
                }
                else
                {
                    InitCopyNewRow(e, view);
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"),
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Clipboard.Clear();
            }
        }

        /// <summary>
        /// Processes a command key.
        /// </summary>
        /// <param name="msg">A <see cref="T:System.Windows.Forms.Message" />, passed by reference, that represents the Win32 message to process.</param>
        /// <param name="keyData">One of the <see cref="T:System.Windows.Forms.Keys" /> values that represents the key to process.</param>
        /// <returns>
        /// true if the keystroke was processed and consumed by the control; otherwise, false to allow further processing.
        /// </returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// Res the fresh control.
        /// </summary>
        protected virtual void ReFreshControl()
        {

        }

        /// <summary>
        /// Handles the ButtonClick event of the txtDescription_Properties control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ButtonPressedEventArgs" /> instance containing the event data.</param>
        protected void txtDescription_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (gridViewDetail.RowCount > 0)
            {
                txtDescription.Text = "";
                for (int i = 0; i < gridViewDetail.RowCount; i++)
                {
                    var description = gridViewDetail.GetRowCellValue(i, "Description");
                    if (description != null)
                        txtDescription.Text = string.IsNullOrEmpty(txtDescription.Text) ? description.ToString() : txtDescription.Text + ", " + description;
                }
            }
        }

        /// <summary>
        /// Handles the CellValueChanged event of the gridViewMaster control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="CellValueChangedEventArgs"/> instance containing the event data.</param>
        private void gridViewMaster_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "CurrencyCode")
            {
                GeneratedBaseRefNo();
            }
        }

        /// <summary>
        /// LinhMC thêm ngày 31/12/2014 - The day end of year
        /// Để valid dữ liệu trong trường hợp người dùng đã lưu dữ liệu từ trước nhưng có thay đổi theo dõi chi tiết theo 1 yếu tố nào đó
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridViewDetail_RowCountChanged(object sender, EventArgs e)
        {
            UpdateDetailBy();
        }

        private void gridViewDetail_KeyDown(object sender, KeyEventArgs e)
        {
            var view = sender as GridView;
            if (view != null && (e.Control && (e.KeyCode == Keys.C || e.KeyCode == Keys.Enter) && ActionMode != ActionModeVoucherEnum.None))
            {
                CopyAndPasteRowItem(view);
                e.Handled = true;
            }


        }

        /// <summary>
        /// ThangNk 28/08/2015
        /// </summary>
        /// <param name="accountcode">Tài khoản tính dư tồn</param>
        /// <param name="currencyCode">The currency code.</param>
        public void ShowBarAmountExist(string accountcode, string currencyCode)
        {
            barAmountExist.Visibility = BarItemVisibility.Always;
            barAmountExist.Caption = @"Dư tồn:" + String.Format("{0:C}", _calculateClosingPresenter.AmountExist(accountcode, currencyCode));
        }

        /// <summary>
        /// Handles the FormClosing event of the FrmXtraBaseVoucherDetail control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs"/> instance containing the event data.</param>
        private void FrmXtraBaseVoucherDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConfirmSaveDataChanged();
        }

        protected virtual void AdjustControlSize(bool isGridParallel, bool isGrdMaster)
        {
            isGrdMaster = false;
            grdMaster.Visible = isGrdMaster;
            gridAccountingParallel.Visible = isGridParallel;
            groupVoucher.Height = groupObject.Height;
            groupObject.Location = new Point(6, 56);
            int formHeight = this.Height;
            int grVoucherHeight = groupVoucher.Height;
            int ygrVoucherHeight = groupVoucher.Location.Y;
            int yMaster = grVoucherHeight + ygrVoucherHeight + 7;
            int grMasterHeigh = 0;
            int ytabMain = 0;
            int grdLayoutHeight = 0;
            int tabMainHeight = 0;
            int tabMainWith = 0;
            int ypanel1 = 0;
            int panel1Height = 0;
            if (isGridParallel == true)
            {

                if (isGrdMaster == true)
                {
                    grMasterHeigh = grdMaster.Height;
                    grdMaster.Location = new Point(7, yMaster);
                    ytabMain = yMaster + grMasterHeigh + 7;
                    grdLayoutHeight = formHeight - yMaster - grMasterHeigh - 7;

                    tabMainHeight = ((grdLayoutHeight / 10) * 6);
                    tabMainWith = groupVoucher.Width + groupVoucher.Location.X - 4;
                    grdDetail.Size = new Size(tabMainWith, tabMainHeight - 70);
                    grdDetail.Location = new Point(7, ytabMain);

                    ypanel1 = ytabMain + tabMainHeight + 7 - 70;
                    panel1Height = grdLayoutHeight - tabMainHeight - 20;
                    gridAccountingParallel.Size = new Size(tabMainWith, panel1Height);
                    gridAccountingParallel.Location = new Point(7, ypanel1);
                }
                else
                {

                    ytabMain = yMaster + 7;
                    grdLayoutHeight = formHeight - yMaster - 7;

                    tabMainHeight = ((grdLayoutHeight / 10) * 6);
                    tabMainWith = groupVoucher.Width + groupVoucher.Location.X - 4;
                    grdDetail.Size = new Size(tabMainWith, tabMainHeight - 70);
                    grdDetail.Location = new Point(7, ytabMain);

                    ypanel1 = ytabMain + tabMainHeight + 7 - 70;
                    panel1Height = grdLayoutHeight - tabMainHeight - 10;
                    gridAccountingParallel.Size = new Size(tabMainWith, panel1Height);
                    gridAccountingParallel.Location = new Point(7, ypanel1);
                }
            }
            else
            {
                if (isGrdMaster == true)
                {
                    grMasterHeigh = grdMaster.Height;
                    grdMaster.Location = new Point(7, yMaster);
                    ytabMain = yMaster + grMasterHeigh + 7;
                    grdLayoutHeight = formHeight - yMaster - grMasterHeigh - 7;

                    tabMainHeight = grdLayoutHeight;
                    tabMainWith = groupVoucher.Width + groupVoucher.Location.X - 4;
                    grdDetail.Size = new Size(tabMainWith, tabMainHeight - 70);
                    grdDetail.Location = new Point(6, ytabMain);
                }
                else
                {
                    ytabMain = yMaster + 7;
                    grdLayoutHeight = formHeight - yMaster - 7;

                    tabMainHeight = grdLayoutHeight;
                    tabMainWith = groupVoucher.Width + groupVoucher.Location.X - 4;
                    grdDetail.Size = new Size(tabMainWith, tabMainHeight - 70);
                    grdDetail.Location = new Point(6, ytabMain);
                }
            }
        }

        public GridView InitGridLayout(List<XtraColumn> columnsCollection, GridView grdView)
        {
            foreach (GridColumn grdColumn in grdView.Columns)
            {
                grdColumn.Visible = false;
            }

            foreach (XtraColumn column in columnsCollection)
            {
                if (column.ColumnVisible)
                {
                    grdView.Columns[column.ColumnName].Visible = true;
                    grdView.Columns[column.ColumnName].UnboundType = column.ColumnType;
                    grdView.Columns[column.ColumnName].Caption = column.ColumnCaption;
                    grdView.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                    grdView.Columns[column.ColumnName].Width = column.ColumnWith;
                    grdView.Columns[column.ColumnName].Fixed = column.FixedColumn;
                    grdView.Columns[column.ColumnName].ToolTip = column.ToolTip;
                    grdView.Columns[column.ColumnName].ColumnEdit = column.RepositoryControl;
                    grdView.Columns[column.ColumnName].OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;

                }
                else
                {
                    grdView.Columns[column.ColumnName].Visible = false;
                }
            }

            return grdView;
        }


        #region Tiện ích loại đối tượng -đối tượng 

        public virtual IList<ObjectGeneral> AccountingObjectCategories
        {
            set
            {
                GridLookUpItem.ObjectGeneral(value, cboObjectCategory, cboObjectCategoryView);
            }
        }

        public virtual List<CustomerModel> Customers
        {
            set
            {
                GridLookUpItem.Customer(value ?? new List<CustomerModel>(), cboObjectCode, grdLookupAccountingObject, "CustomerCode", "CustomerId");

                if (_rpsCustomer == null)
                    _rpsCustomer = new RepositoryItemGridLookUpEdit();
                _rpsCustomer.KeyDown += repositoryItemGridLookUpEdit_KeyDown;
                GridLookUpItem.Customer(value, _rpsCustomer, "CustomerCode", "CustomerId");

                if (_rpsCustomerParalell == null)
                    _rpsCustomerParalell = new RepositoryItemGridLookUpEdit();
                _rpsCustomerParalell.KeyDown += repositoryItemGridLookUpEdit_KeyDown;
                GridLookUpItem.Customer(value, _rpsCustomerParalell, "CustomerCode", "CustomerId");
            }
        }

        public virtual IList<EmployeeModel> Employees
        {
            set
            {
                GridLookUpItem.Employee(value ?? new List<EmployeeModel>(), cboObjectCode, grdLookupAccountingObject, "EmployeeCode", "EmployeeId");

                if (_rpsEmployees == null)
                    _rpsEmployees = new RepositoryItemGridLookUpEdit();
                _rpsEmployees.KeyDown += repositoryItemGridLookUpEdit_KeyDown;
                GridLookUpItem.Employee(value, _rpsEmployees, "EmployeeCode", "EmployeeId");

                if (_rpsEmployeesParalell == null)
                    _rpsEmployeesParalell = new RepositoryItemGridLookUpEdit();
                _rpsEmployeesParalell.KeyDown += repositoryItemGridLookUpEdit_KeyDown;
                GridLookUpItem.Employee(value, _rpsEmployeesParalell, "EmployeeCode", "EmployeeId");
            }
        }

        public virtual IList<VendorModel> Vendors
        {
            set
            {
                GridLookUpItem.Vendor(value ?? new List<VendorModel>(), cboObjectCode, grdLookupAccountingObject, "VendorCode", "VendorId");

                if (_rpsVendor == null)
                    _rpsVendor = new RepositoryItemGridLookUpEdit();
                _rpsVendor.KeyDown += repositoryItemGridLookUpEdit_KeyDown;
                GridLookUpItem.Vendor(value, _rpsVendor, "VendorCode", "VendorId");

                if (_rpsVendorParalell == null)
                    _rpsVendorParalell = new RepositoryItemGridLookUpEdit();
                _rpsVendorParalell.KeyDown += repositoryItemGridLookUpEdit_KeyDown;
                GridLookUpItem.Vendor(value, _rpsVendorParalell, "VendorCode", "VendorId");
            }
        }

        public int? AccountingObjectType
        {
            get { return (int?)cboObjectCategory.EditValue; }
            set
            {
                if (value != null)
                    cboObjectCategory.EditValue = value;

                switch (value)
                {
                    case 0:
                        if (ActionMode == ActionModeVoucherEnum.None)
                            _vendorsPresenter.Display();
                        else
                            _vendorsPresenter.DisplayActive(true);
                        break;
                    case 1:
                        if (ActionMode == ActionModeVoucherEnum.None)
                            _employeesPresenter.Display();
                        else
                            _employeesPresenter.DisplayActive();
                        break;
                    case 2:
                        if (ActionMode == ActionModeVoucherEnum.None)
                            _accountingObjectsPresenter.Display();
                        else
                            _accountingObjectsPresenter.DisplayActive(true);
                        break;
                    case 3:
                        _customersPresenter.DisplayActive(true);
                        break;
                }
            }
        }

        public int? CustomerId
        {
            get
            {
                if (AccountingObjectType == 3)
                {
                    var customer = (CustomerModel)cboObjectCode.GetSelectedDataRow();
                    if (customer != null)
                        return customer.CustomerId;
                }
                return null;
            }
            set
            {
                if (AccountingObjectType == 3)
                {
                    cboObjectCode.EditValue = value;
                }
            }
        }

        public int? VendorId
        {
            get
            {
                if (AccountingObjectType == 0)
                {
                    var vendor = (VendorModel)cboObjectCode.GetSelectedDataRow();
                    if (vendor != null)
                        return vendor.VendorId;
                }
                return null;
            }
            set
            {
                if (AccountingObjectType == 0)
                {
                    cboObjectCode.EditValue = value;
                }
            }
        }

        public int? EmployeeId
        {
            get
            {
                if (AccountingObjectType == 1)
                {
                    var employee = (EmployeeModel)cboObjectCode.GetSelectedDataRow();
                    if (employee != null)
                        return employee.EmployeeId;
                }
                return null;
            }
            set
            {
                if (AccountingObjectType == 1)
                {
                    cboObjectCode.EditValue = value;
                }
            }
        }

        public int? AccountingObjectId
        {
            get
            {
                if (AccountingObjectType == 2)
                {
                    var accoutingObject = (AccountingObjectModel)cboObjectCode.GetSelectedDataRow();
                    if (accoutingObject != null)
                        return accoutingObject.AccountingObjectId;
                }
                return null;
            }
            set
            {
                if (AccountingObjectType == 2)
                {
                    cboObjectCode.EditValue = value;
                }
            }
        }

        public virtual IList<DepartmentModel> Departments
        {
            set
            {
                if (_rpsDepartment == null)
                    _rpsDepartment = new RepositoryItemGridLookUpEdit();
                _rpsDepartment.KeyDown += repositoryItemGridLookUpEdit_KeyDown;
                GridLookUpItem.Department(value ?? new List<DepartmentModel>(), _rpsDepartment, "DepartmentCode", "DepartmentId");

                if (_rpsDepartmentParalell == null)
                    _rpsDepartmentParalell = new RepositoryItemGridLookUpEdit();
                _rpsDepartmentParalell.KeyDown += repositoryItemGridLookUpEdit_KeyDown;
                GridLookUpItem.Department(value ?? new List<DepartmentModel>(), _rpsDepartmentParalell, "DepartmentCode", "DepartmentId");
            }
        }

        public virtual IList<StockModel> Stocks
        {
            set
            {
                if (_rpsStock == null) _rpsStock = new RepositoryItemGridLookUpEdit();
                _rpsStock.KeyDown += repositoryItemGridLookUpEdit_KeyDown;
                GridLookUpItem.Stock(value ?? new List<StockModel>(), _rpsStock, "StockCode", "StockId");
            }
        }

        public virtual IList<InventoryItemModel> InventoryItems
        {
            set
            {
                if (_rpsInventoryItem == null) _rpsInventoryItem = new RepositoryItemGridLookUpEdit();
                _rpsInventoryItem.KeyDown += repositoryItemGridLookUpEdit_KeyDown;
                GridLookUpItem.InventoryItem(value ?? new List<InventoryItemModel>(), _rpsInventoryItem, "InventoryItemCode", "InventoryItemId");

                if (_rpsInventoryItemParalell == null) _rpsInventoryItemParalell = new RepositoryItemGridLookUpEdit();
                _rpsInventoryItemParalell.KeyDown += repositoryItemGridLookUpEdit_KeyDown;
                GridLookUpItem.InventoryItem(value ?? new List<InventoryItemModel>(), _rpsInventoryItemParalell, "InventoryItemCode", "InventoryItemId");
            }
        }

        public IList<FixedAssetModel> FixedAssets
        {
            set
            {
                if (_rpsFixedAssetParalell == null) _rpsFixedAssetParalell = new RepositoryItemGridLookUpEdit();
                _rpsFixedAssetParalell.KeyDown += repositoryItemGridLookUpEdit_KeyDown;
                GridLookUpItem.FixedAsset(value ?? new List<FixedAssetModel>(), _rpsFixedAssetParalell, "FixedAssetCode", "InventoryItemId");
            }
        }

        public virtual void LoadComboObjectCode(int objectId)
        {
            switch (objectId)
            {
                case 0: //Nhà cung cấp
                    grdLookupAccountingObject.PopulateColumns();
                    _vendorsPresenter = new VendorsPresenter(this);
                    if (ActionMode == ActionModeVoucherEnum.None)
                        _vendorsPresenter.Display();
                    else
                        _vendorsPresenter.DisplayActive(true);

                    //cboObjectCode.Enabled = true;
                    cboObjectCode.Properties.ReadOnly = false;

                    if (VendorId != null) //Khắc phục lỗi nhập trước 26/062014
                    {
                        if (cboObjectCode.EditValue.ToString() != "" && cboObjectCode.EditValue.ToString() != null)
                        {
                            var lstVendor = (List<VendorModel>)cboObjectCode.Properties.DataSource;
                            try
                            {
                                VendorModel row = lstVendor.Where(x => x.VendorId == int.Parse(cboObjectCode.EditValue.ToString())).FirstOrDefault();
                                txtAddress.Text = row.Address;
                            }
                            catch (Exception) { }
                        }
                    }

                    break;
                case 1: //Nhân viên
                    grdLookupAccountingObject.PopulateColumns();
                    _employeesPresenter = new EmployeesPresenter(this);
                    if (ActionMode == ActionModeVoucherEnum.None)
                        _employeesPresenter.Display();
                    else
                        _employeesPresenter.DisplayActive();
                    // _employeesPresenter.DisplayActive(true);
                    //cboObjectCode.Enabled = true;
                    cboObjectCode.Properties.ReadOnly = false;

                    if (EmployeeId != null)//Khắc phục lỗi nhập trước 26/062014
                    {
                        if (cboObjectCode.EditValue.ToString() != "" &&
                        cboObjectCode.EditValue.ToString() != null)
                        {
                            var lstEmployee = (List<EmployeeModel>)cboObjectCode.Properties.DataSource;

                            try
                            {
                                EmployeeModel row = lstEmployee.FirstOrDefault(x => x.EmployeeId == int.Parse(cboObjectCode.EditValue.ToString()));
                                if (row != null) txtAddress.Text = row.Address;
                            }
                            catch (Exception ex) { }
                        }
                    }

                    break;
                case 2: // Đối tượng khác
                    grdLookupAccountingObject.PopulateColumns();
                    _accountingObjectsPresenter = new AccountingObjectsPresenter(this);

                    if (ActionMode == ActionModeVoucherEnum.None)
                        _accountingObjectsPresenter.Display();
                    else
                        _accountingObjectsPresenter.DisplayActive(true);

                    //_accountingObjectsPresenter.DisplayActive(true);
                    //cboObjectCode.Enabled = true;
                    cboObjectCode.Properties.ReadOnly = false;
                    if (AccountingObjectId != null) //Khắc phục lỗi nhập trước 26/062014
                    {
                        if (cboObjectCode.EditValue.ToString() != "")
                        {
                            var lstAccountingObject = (List<AccountingObjectModel>)cboObjectCode.Properties.DataSource;
                            try
                            {
                                AccountingObjectModel row = lstAccountingObject.FirstOrDefault(x => x.AccountingObjectId == int.Parse(cboObjectCode.EditValue.ToString()));
                                if (row != null) txtAddress.Text = row.Address;
                            }
                            catch (Exception ex) { }
                        }
                    }


                    break;
                case 3: //Khách hàng
                    grdLookupAccountingObject.PopulateColumns();
                    _customersPresenter = new CustomersPresenter(this);
                    _customersPresenter.DisplayActive(true);
                    //cboObjectCode.Enabled = true;
                    cboObjectCode.Properties.ReadOnly = false;
                    if (CustomerId != null) //Khắc phục lỗi nhập trước 26/062014
                    {
                        if (cboObjectCode.EditValue.ToString() != "")
                        {
                            var lstCustomers = (List<CustomerModel>)cboObjectCode.Properties.DataSource;
                            try
                            {
                                CustomerModel row = lstCustomers.FirstOrDefault(x => x.CustomerId == int.Parse(cboObjectCode.EditValue.ToString()));
                                if (row != null) txtAddress.Text = row.Address;
                            }
                            catch (Exception ex) { }
                        }
                    }
                    break;
                case -1:
                    //cboObjectCode.Enabled = false;
                    cboObjectCode.Properties.ReadOnly = true;
                    break;
            }
            grdLookupAccountingObject.OptionsView.ShowFooter = false;
            cboObjectCode.Properties.ShowFooter = false;
        }

        protected virtual void SetObjectInfo(string objectName = "", string trader = "", string address = "", string description = "", string taxCode = "")
        {
            cboObjectName.Text = objectName;
            if (ActionMode == ActionModeVoucherEnum.AddNew)
                txtContactName.Text = trader;
            txtAddress.Text = address;

        }

        #endregion

        protected virtual void cboObjectCategory_EditValueChanged(object sender, EventArgs e)
        {
            var objectId = (int)cboObjectCategory.EditValue;
            LoadComboObjectCode(objectId);
            SetObjectInfo(null, null, null, null);
            //cboObjectCode.Enabled = true;
            cboObjectCode.Properties.ReadOnly = false;
        }

        public void LoadComboObjectCategory()
        {
            AccountingObjectCategories = new ObjectGeneral().GetAccountingObjectCategories(true, true, true, true);
        }

        protected virtual void cboObjectCode_EditValueChanged(object sender, EventArgs e)
        {
            if (cboObjectCode.EditValue == null || cboObjectCode.EditValue.ToString() == "")
            {
                //cboObjectCode.Enabled = true;
                cboObjectCode.Properties.ReadOnly = false;
                return;
            }

            var objectId = (int)cboObjectCategory.EditValue;
            switch (objectId)
            {
                case 0:
                    {
                        var row = (VendorModel)cboObjectCode.GetSelectedDataRow();
                        SetObjectInfo(row.VendorName, row.ContactName, row.Address, row.TaxCode);
                        txtContactName.Text = "";
                        break;
                    }
                case 1:
                    {
                        var row = (EmployeeModel)cboObjectCode.GetSelectedDataRow();
                        SetObjectInfo(row.EmployeeName, null, row.Address, null);
                        txtContactName.Text = row.EmployeeName;

                        break;
                    }
                case 2:
                    {
                        var row = (AccountingObjectModel)cboObjectCode.GetSelectedDataRow();
                        SetObjectInfo(row.FullName, row.ContactName, row.Address, row.TaxCode);
                        txtContactName.Text = "";
                        break;
                    }
                case 3:
                    {
                        var row = (CustomerModel)cboObjectCode.GetSelectedDataRow();
                        SetObjectInfo(row.CustomerName, row.ContactName, row.Address, row.TaxCode);
                        txtContactName.Text = "";
                        break;
                    }
            }

        }


        public virtual void SetcboObjectCategory(int cboObjectCategoryId)
        {
            switch (cboObjectCategoryId)
            {
                case 0:
                    {
                        var row = (VendorModel)cboObjectCode.GetSelectedDataRow();
                        if (row == null) break;
                        SetObjectInfo(row.VendorName, row.ContactName, row.Address, row.TaxCode);
                        break;
                    }
                case 1:
                    {
                        var row = (EmployeeModel)cboObjectCode.GetSelectedDataRow();
                        if (row == null) break;
                        SetObjectInfo(row.EmployeeName, null, row.Address, null);


                        break;
                    }
                case 2:
                    {
                        var row = (AccountingObjectModel)cboObjectCode.GetSelectedDataRow();
                        if (row == null) break;
                        SetObjectInfo(row.FullName, row.ContactName, row.ContactAddress, row.TaxCode);
                        break;
                    }
                case 3:
                    {
                        var row = (CustomerModel)cboObjectCode.GetSelectedDataRow();
                        if (row == null) break;
                        SetObjectInfo(row.CustomerName, row.ContactName, row.Address, row.TaxCode);
                        break;
                    }
            }
        }

        private void cboObjectCode_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            //if (e.Button.Index.Equals(1))
            //{
            //    AddAccountingObject();
            //}
        }

        public virtual void AddAccountingObject()
        {

            switch (Convert.ToInt32(cboObjectCategory.EditValue))
            {
                case 0://Nhà cung cấp
                    var frm1 = new FrmXtraVendorDetail();
                    frm1.ShowDialog();
                    if (frm1.CloseBox)
                    {
                        if (frm1.IdResult != -1)
                        {
                            _vendorsPresenter.DisplayActive(true);
                            cboObjectCode.EditValue = frm1.IdResult;
                        }
                    }
                    break;
                case 1://Nhân viên
                    var frm2 = new FrmXtraEmployeeDetail();
                    frm2.ShowDialog();
                    if (frm2.CloseBox)
                    {
                        if (frm2.IdResult != -1)
                        {
                            _employeesPresenter.DisplayActive();
                            cboObjectCode.EditValue = frm2.IdResult;
                        }
                    }
                    break;
                case 2://Đối tượng
                    var frm3 = new FrmXtraAccountingObjectDetail();
                    frm3.ShowDialog();
                    if (frm3.CloseBox)
                    {
                        if (frm3.IdResult != -1)
                        {
                            _accountingObjectsPresenter.DisplayActive(true);
                            cboObjectCode.EditValue = frm3.IdResult;
                        }
                    }
                    break;
            }
        }

        private void cboBank_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Index.Equals(1))
            {
                var frm = new FrmXtraBankDetail();
                frm.ShowDialog();
                if (frm.CloseBox)
                {
                    if (frm.IdResult != -1)
                    {
                        _banksPresenter.DisplayActive();
                        cboBank.EditValue = frm.IdResult;
                    }
                }
            }
        }

        private void cboObjectCode_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (cboObjectCategory.EditValue != null && e.Button.Kind == ButtonPredefines.Plus)
            {
                switch (Convert.ToInt32(cboObjectCategory.EditValue))
                {
                    case 0: // nhà cung cấp
                        var frmVendorDetail = new FrmXtraAccountingObjectDetail() { ActionMode = ActionModeEnum.AddNew, IsEnableAccountingObjectCategory = false };
                        frmVendorDetail.AccountingObjectCategoryId = 0;
                        if (frmVendorDetail.ShowDialog() == DialogResult.OK)
                        {
                            _vendorsPresenter.DisplayActive(true);

                            var lstDetails = cboObjectCode.Properties.DataSource as List<VendorModel>;
                            if (lstDetails != null)
                                cboObjectCode.EditValue = lstDetails.OrderByDescending(o => o.VendorId).FirstOrDefault().VendorId;
                        }
                        break;
                    case 1: // nhân viên
                        var frmEmployeeDetail = new FrmXtraEmployeeDetail() { ActionMode = ActionModeEnum.AddNew };
                        if (frmEmployeeDetail.ShowDialog() == DialogResult.OK)
                        {
                            _employeesPresenter.DisplayActive();

                            var lstDetails = cboObjectCode.Properties.DataSource as List<EmployeeModel>;
                            if (lstDetails != null)
                                cboObjectCode.EditValue = lstDetails.OrderByDescending(o => o.EmployeeId).FirstOrDefault().EmployeeId;
                        }
                        break;
                    case 2: // đối tượng khác
                        var frmAccountingObjectDetail = new FrmXtraAccountingObjectDetail() { ActionMode = ActionModeEnum.AddNew, IsEnableAccountingObjectCategory = false };
                        frmAccountingObjectDetail.AccountingObjectCategoryId = 2;
                        if (frmAccountingObjectDetail.ShowDialog() == DialogResult.OK)
                        {
                            _accountingObjectsPresenter.DisplayActive(true);

                            var lstDetails = cboObjectCode.Properties.DataSource as List<AccountingObjectModel>;
                            if (lstDetails != null)
                                cboObjectCode.EditValue = lstDetails.OrderByDescending(o => o.AccountingObjectId).FirstOrDefault().AccountingObjectId;
                        }
                        break;
                    case 3: // khách hàng
                        var frmCustomerDetail = new FrmXtraAccountingObjectDetail() { ActionMode = ActionModeEnum.AddNew, IsEnableAccountingObjectCategory = false };
                        frmCustomerDetail.AccountingObjectCategoryId = 3;
                        if (frmCustomerDetail.ShowDialog() == DialogResult.OK)
                        {
                            _customersPresenter.DisplayActive(true);

                            var lstDetails = cboObjectCode.Properties.DataSource as List<CustomerModel>;
                            if (lstDetails != null)
                                cboObjectCode.EditValue = lstDetails.OrderByDescending(o => o.CustomerId).FirstOrDefault().CustomerId;
                        }
                        break;
                }
            }
        }

        protected void repositoryItemGridLookUpEdit_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Delete)
                {
                    (grdControlSelected.FocusedView.ActiveEditor as GridLookUpEdit).ClosePopup();
                    (grdControlSelected.FocusedView.ActiveEditor as BaseEdit).EditValue = null;
                }
                else if (e.KeyData == Keys.Tab)
                {
                    (grdControlSelected.FocusedView.ActiveEditor as GridLookUpEdit).ClosePopup();
                    var rps = grdControlSelected.FocusedView.ActiveEditor as BaseEdit;
                    if (rps.Text == "")
                        (grdControlSelected.FocusedView.ActiveEditor as BaseEdit).EditValue = null;
                }
                else if (e.KeyData == Keys.Back)
                {
                    (grdControlSelected.FocusedView.ActiveEditor as GridLookUpEdit).ClosePopup();
                    var rps = grdControlSelected.FocusedView.ActiveEditor as BaseEdit;
                    if (rps.Text == "")
                        (grdControlSelected.FocusedView.ActiveEditor as BaseEdit).EditValue = null;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void grdDetail_ProcessGridKey(object sender, KeyEventArgs e)
        {
            //if (gridViewDetail.FocusedColumn.RealColumnEdit is RepositoryItemGridLookUpEdit)
            //{
            //    if ((e.KeyData >= Keys.A && e.KeyData <= Keys.Z) || ((e.KeyData >= Keys.D0) && (e.KeyData <= Keys.D9)) || ((e.KeyData >= Keys.NumPad0) && (e.KeyData <= Keys.NumPad9)))
            //    {
            //        GridLookUpEdit edit = gridViewDetail.ActiveEditor as GridLookUpEdit;
            //        if (edit == null)
            //        {
            //            gridViewDetail.ShowEditor();
            //            edit = gridViewDetail.ActiveEditor as GridLookUpEdit;
            //        }
            //        edit.ShowPopup();
            //        e.Handled = true;
            //    }
            //}
        }

        /// <summary>
        /// Lưu grid view đang được chọn để sử dụng cho event repositoryItemGridLookUpEdit_KeyDown
        /// </summary>
        DevExpress.XtraGrid.GridControl grdControlSelected = new DevExpress.XtraGrid.GridControl();
        private void grdMaster_Enter(object sender, EventArgs e)
        {
            grdControlSelected = grdMaster;
        }

        private void grdDetail_Enter(object sender, EventArgs e)
        {
            grdControlSelected = grdDetail;
        }

        private void gridAccountingParallel_Enter(object sender, EventArgs e)
        {
            grdControlSelected = gridAccountingParallel;
        }

        private void gridViewDetail_FocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e)
        {
            try
            {
                if (gridViewDetail.FocusedColumn.RealColumnEdit is RepositoryItemGridLookUpEdit)
                {
                    gridViewDetail.ShowEditor();
                    //GridLookUpEdit edit = gridViewDetail.ActiveEditor as GridLookUpEdit;
                    //edit.ShowPopup();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void gridViewDetail_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            try
            {
                if (gridViewDetail.FocusedColumn.RealColumnEdit is RepositoryItemGridLookUpEdit)
                {
                    gridViewDetail.ShowEditor();
                    //GridLookUpEdit edit = gridViewDetail.ActiveEditor as GridLookUpEdit;
                    //edit.ShowPopup();
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected virtual void InitDefaultCurrency()
        {
            var value = new List<GridLookUpItem>();
            if (CurrencyAccounting != CurrencyLocal)

                value = new List<GridLookUpItem>
                {
                    new GridLookUpItem(CurrencyAccounting, CurrencyAccounting),
                    new GridLookUpItem(CurrencyLocal, CurrencyLocal)
                };

            else
                value = new List<GridLookUpItem>
                {
                    new GridLookUpItem(CurrencyAccounting, CurrencyAccounting)
                };

            var currencyColumns = new List<XtraColumn>
            {
                new XtraColumn
                {
                    ColumnName = "DataValue",
                    ColumnVisible = false,
                    Alignment = HorzAlignment.Center
                },
                new XtraColumn
                {
                    ColumnName = "DataMember",
                    ColumnCaption = "Tiền tệ",
                    ColumnVisible = true,
                    ColumnPosition = 2,
                    ColumnWith = 100
                }
            };
            //GridLookUpItem.HideVisibleColumn(value, currencyColumns, cboCurrency, grdCurrencyView, "DataMember", "DataValue");
            GridLookUpItem.ObjectGeneral(value, cboCurrency, grdCurrencyView, "DataMember", "DataValue");

            cboExchangRate.Properties.Mask.MaskType = MaskType.Numeric;
            cboExchangRate.Properties.Mask.EditMask = @"c" + DBOptionHelper.ExchangeRateDecimalDigits;
            cboExchangRate.Properties.Mask.UseMaskAsDisplayFormat = true;
        }

        protected virtual void cboCurrency_EditValueChanged(object sender, EventArgs e)
        {
            string result2 = "1" + DBOptionHelper.CurrencyDecimalSeparator;
            var count = Convert.ToInt32(DBOptionHelper.ExchangeRateDecimalDigits);
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    result2 += "0";
                }
            }
            else
            {
                result2 = "1";
            }

            GeneratedBaseRefNo();
            if ((cboCurrency.EditValue ?? "").ToString() == CurrencyAccounting)
            {
                cboExchangRate.EditValue = 1;
                cboExchangRate.Enabled = false;
            }

            else if (ActionMode == ActionModeVoucherEnum.None)
            {
                cboExchangRate.Enabled = false;
            }
            else
            {
                cboExchangRate.Enabled = true;
                cboExchangRate.Properties.Mask.MaskType = MaskType.Numeric;
                cboExchangRate.Properties.Mask.EditMask = @"c" + DBOptionHelper.ExchangeRateDecimalDigits;
                cboExchangRate.Properties.Mask.UseMaskAsDisplayFormat = true;
                if ((cboCurrency.EditValue ?? "").ToString().Equals(DBOptionHelper.CurrencyAccounting))
                {
                    cboExchangRate.EditValue = 1;
                    cboExchangRate.Text = result2;
                }
            }

            if (BaseRefTypeId != RefType.GeneralVoucher && BaseRefTypeId != RefType.FixedAssetArmortization)
            {
                var cboCurrencyCode = cboCurrency.EditValue == null ? "" : cboCurrency.EditValue.ToString();
                AutoBusinesses = cboCurrencyCode == CurrencyAccounting ? lstAutoBusinessBase.Where(w => w.CurrencyCode == CurrencyAccounting).ToList() : lstAutoBusinessBase.Where(w => w.CurrencyCode == CurrencyLocal).ToList();
            }
        }

        public virtual void gridViewDetail_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName.Equals("AmountOc"))
            {
                if (gridViewDetail.Columns.ColumnByFieldName("AmountOc") != null && gridViewDetail.Columns.ColumnByFieldName("AmountExchange") != null)
                {
                    var exchange = Convert.ToDecimal(cboExchangRate.EditValue ?? 1);
                    var amountOc = (decimal)gridViewDetail.GetRowCellValue(e.RowHandle, "AmountOc");
                    var amountEx = (decimal)gridViewDetail.GetRowCellValue(e.RowHandle, "AmountExchange");

                    if (exchange > 0)
                    {
                        if (amountEx * exchange != amountOc)
                        {
                            amountEx = Math.Round(amountOc / exchange, int.Parse(DBOptionHelper.CurrencyDecimalDigits));
                            int rowHandle = gridViewDetail.FocusedRowHandle;
                            gridViewDetail.SetRowCellValue(rowHandle, "AmountExchange", amountEx);
                        }
                    }
                }
            }
            if (e.Column.FieldName == "AutoBusinessId")
            {
                var rowHandle = gridViewDetail.FocusedRowHandle;
                if (gridViewDetail.GetRowCellValue(rowHandle, "AutoBusinessId") != null)
                {
                    var autoBusinessId = (int)gridViewDetail.GetRowCellValue(rowHandle, "AutoBusinessId");
                    var autoBusiness = (AutoBusinessModel)_rpsAutoBusiness.GetRowByKeyValue(autoBusinessId);
                    if (autoBusiness.RefTypeId == (int)BaseRefTypeId)
                    {
                        if (gridViewDetail.Columns["AccountNumber"] != null)
                            gridViewDetail.SetRowCellValue(rowHandle, "AccountNumber", autoBusiness.DebitAccountNumber);
                        if (gridViewDetail.Columns["CorrespondingAccountNumber"] != null)
                            gridViewDetail.SetRowCellValue(rowHandle, "CorrespondingAccountNumber", autoBusiness.CreditAccountNumber);
                        if (gridViewDetail.Columns["VoucherTypeId"] != null)
                            gridViewDetail.SetRowCellValue(rowHandle, "VoucherTypeId", autoBusiness.VoucherTypeId);
                        if (gridViewDetail.Columns["Description"] != null)
                            gridViewDetail.SetRowCellValue(rowHandle, "Description", autoBusiness.Description);
                        if (gridViewDetail.Columns["BudgetSourceCode"] != null)
                            gridViewDetail.SetRowCellValue(rowHandle, "BudgetSourceCode", autoBusiness.BudgetSourceCode);
                        if (gridViewDetail.Columns["BudgetItemCode"] != null)
                            gridViewDetail.SetRowCellValue(rowHandle, "BudgetItemCode", autoBusiness.BudgetItemCode);
                    }
                }
            }
            if (e.Column.FieldName == "Description")
            {
                if (gridViewDetail.Columns.ColumnByFieldName("Description") != null)
                {
                    txtDescription.Text = (gridViewDetail.GetRowCellValue(e.RowHandle, "Description") ?? txtDescription.Text).ToString();
                }
            }
        }

        protected virtual void cboExchangRate_EditValueChanged(object sender, EventArgs e)
        {
            if (gridViewDetail.Columns["AmountOc"] != null && gridViewDetail.Columns["AmountExchange"] != null)
                for (var i = 0; i < gridViewDetail.RowCount; i++)
                {
                    decimal amount = Convert.ToDecimal(gridViewDetail.GetRowCellValue(i, "AmountOc") ?? 0);
                    decimal exchange = Convert.ToDecimal(cboExchangRate.EditValue ?? 0);
                    if (exchange != 0)
                        gridViewDetail.SetRowCellValue(i, "AmountExchange", Math.Round(amount / exchange, int.Parse(DBOptionHelper.CurrencyDecimalDigits)));
                }
            if (gridViewDetail.Columns["AmountOC"] != null && gridViewDetail.Columns["AmountExchange"] != null)
                for (var i = 0; i < gridViewDetail.RowCount; i++)
                {
                    decimal amount = Convert.ToDecimal(gridViewDetail.GetRowCellValue(i, "AmountOC") ?? 0);
                    decimal exchange = Convert.ToDecimal(cboExchangRate.EditValue ?? 0);
                    if (exchange != 0)
                        gridViewDetail.SetRowCellValue(i, "AmountExchange", Math.Round(amount / exchange, int.Parse(DBOptionHelper.CurrencyDecimalDigits)));
                }
            if (gridViewDetail.Columns["UnitPriceOC"] != null && gridViewDetail.Columns["UnitPriceExchange"] != null)
                for (var i = 0; i < gridViewDetail.RowCount; i++)
                {
                    decimal amount = Convert.ToDecimal(gridViewDetail.GetRowCellValue(i, "UnitPriceOC") ?? 0);
                    decimal exchange = Convert.ToDecimal(cboExchangRate.EditValue ?? 0);
                    if (exchange != 0)
                        gridViewDetail.SetRowCellValue(i, "UnitPriceExchange", Math.Round(amount / exchange, int.Parse(DBOptionHelper.CurrencyDecimalDigits)));
                }
            if (gridViewDetail.Columns["Charge"] != null && gridViewDetail.Columns["ChargeExchange"] != null)
                for (var i = 0; i < gridViewDetail.RowCount; i++)
                {
                    decimal amount = Convert.ToDecimal(gridViewDetail.GetRowCellValue(i, "Charge") ?? 0);
                    decimal exchange = Convert.ToDecimal(cboExchangRate.EditValue ?? 0);
                    if (exchange != 0)
                        gridViewDetail.SetRowCellValue(i, "ChargeExchange", Math.Round(amount / exchange, int.Parse(DBOptionHelper.CurrencyDecimalDigits)));
                }
        }

        protected virtual void gridViewAccountingPararell_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName.Equals("AmountOc"))
            {
                if (gridViewAccountingPararell.Columns.ColumnByFieldName("AmountOc") != null && gridViewAccountingPararell.Columns.ColumnByFieldName("AmountExchange") != null)
                {
                    var exchange = Convert.ToDecimal(cboExchangRate.EditValue ?? 1);
                    var amountOc = (decimal)gridViewAccountingPararell.GetRowCellValue(e.RowHandle, "AmountOc");
                    var amountEx = (decimal)gridViewAccountingPararell.GetRowCellValue(e.RowHandle, "AmountExchange");

                    if (exchange > 0)
                    {
                        if (amountEx * exchange != amountOc)
                        {
                            amountEx = Math.Round(amountOc * exchange, int.Parse(DBOptionHelper.CurrencyDecimalDigits));
                            int rowHandle = gridViewAccountingPararell.FocusedRowHandle;
                            gridViewAccountingPararell.SetRowCellValue(rowHandle, "AmountExchange", amountEx);
                        }
                    }
                }
            }
            if (e.Column.FieldName == "AutoBusinessId")
            {
                var rowHandle = gridViewAccountingPararell.FocusedRowHandle;
                if (gridViewAccountingPararell.GetRowCellValue(rowHandle, "AutoBusinessId") != null)
                {
                    var autoBusinessId = (int)gridViewAccountingPararell.GetRowCellValue(rowHandle, "AutoBusinessId");
                    var autoBusiness = (AutoBusinessModel)_rpsAutoBusiness.GetRowByKeyValue(autoBusinessId);
                    if (autoBusiness.RefTypeId == (int)BaseRefTypeId)
                    {
                        if (gridViewAccountingPararell.Columns["AccountNumber"] != null)
                            gridViewAccountingPararell.SetRowCellValue(rowHandle, "AccountNumber", autoBusiness.DebitAccountNumber);
                        if (gridViewAccountingPararell.Columns["CorrespondingAccountNumber"] != null)
                            gridViewAccountingPararell.SetRowCellValue(rowHandle, "CorrespondingAccountNumber", autoBusiness.CreditAccountNumber);
                        if (gridViewAccountingPararell.Columns["VoucherTypeId"] != null)
                            gridViewAccountingPararell.SetRowCellValue(rowHandle, "VoucherTypeId", autoBusiness.VoucherTypeId);
                        if (gridViewAccountingPararell.Columns["Description"] != null)
                            gridViewAccountingPararell.SetRowCellValue(rowHandle, "Description", autoBusiness.Description);
                        if (gridViewAccountingPararell.Columns["BudgetSourceCode"] != null)
                            gridViewAccountingPararell.SetRowCellValue(rowHandle, "BudgetSourceCode", autoBusiness.BudgetSourceCode);
                        if (gridViewAccountingPararell.Columns["BudgetItemCode"] != null)
                            gridViewAccountingPararell.SetRowCellValue(rowHandle, "BudgetItemCode", autoBusiness.BudgetItemCode);
                    }
                }
            }
        }

        private void gridViewAccountingPararell_CustomDrawColumnHeader(object sender, ColumnHeaderCustomDrawEventArgs e)
        {
            var viewInfo = (GridViewInfo)gridViewAccountingPararell.GetViewInfo();
            var rec = new Rectangle(e.Bounds.X + 2, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
            if (e.Column == null) return;
            if (e.Column == viewInfo.FixedLeftColumn || e.Column == viewInfo.ColumnsInfo.LastColumnInfo.Column)
            {
                foreach (DevExpress.Utils.Drawing.DrawElementInfo info in e.Info.InnerElements)
                {
                    if (!info.Visible) continue;
                    DevExpress.Utils.Drawing.ObjectPainter.DrawObject(e.Cache, info.ElementPainter, info.ElementInfo);
                }
                e.Painter.DrawCaption(e.Info, e.Info.Caption, e.Appearance.Font, e.Appearance.GetForeBrush(e.Cache), rec, e.Appearance.GetStringFormat());
                e.Graphics.DrawLine(Pens.DarkGray, e.Bounds.Left - 1, e.Bounds.Bottom - 1, e.Bounds.Right - 1, e.Bounds.Bottom - 1);
                e.Handled = true;
            }
        }

        protected bool ValidAccountDetail(object voucherDetail, int i = 0)
        {
            string detailAcountNumberCode = "";
            string detailCorrespondingAccountNumberCode = "";
            var accountNumber = new AccountModel();
            if (voucherDetail.GetType() == typeof(DepositDetailModel))
            {
                var detail = voucherDetail as DepositDetailModel;
                accountNumber.IsAccountingObject = this.AccountingObjectId == null ? false : true;
                accountNumber.IsVendor = this.VendorId == null ? false : true;
                accountNumber.IsCustomer = this.CustomerId == null ? false : true;
                accountNumber.IsEmployee = this.EmployeeId == null ? false : true;
                accountNumber.IsProject = detail.ProjectId == null ? false : true;
                var budgetItem = _rpsBudgetItem.GetRowByKeyValue(detail.BudgetItemCode) as BudgetItemModel
                    ?? new BudgetItemModel();
                accountNumber.IsBudgetItem = !string.IsNullOrEmpty(detail.BudgetItemCode) && (budgetItem.BudgetItemType == 3 || budgetItem.BudgetItemType == 4) ? true : false;
                accountNumber.IsBudgetSource = string.IsNullOrEmpty(detail.BudgetSourceCode) ? false : true;
                accountNumber.IsBudgetGroup = false;
                detailAcountNumberCode = detail.AccountNumber;
                detailCorrespondingAccountNumberCode = detail.CorrespondingAccountNumber;
            }
            else if (voucherDetail.GetType() == typeof(CashDetailModel))
            {
                var detail = voucherDetail as CashDetailModel;
                accountNumber.IsAccountingObject = this.AccountingObjectId == null ? false : true;
                accountNumber.IsVendor = this.VendorId == null ? false : true;
                accountNumber.IsCustomer = this.CustomerId == null ? false : true;
                accountNumber.IsEmployee = this.EmployeeId == null ? false : true;
                accountNumber.IsProject = detail.ProjectId == null ? false : true;
                var budgetItem = _rpsBudgetItem.GetRowByKeyValue(detail.BudgetItemCode) as BudgetItemModel
                    ?? new BudgetItemModel();
                accountNumber.IsBudgetItem = !string.IsNullOrEmpty(detail.BudgetItemCode) && (budgetItem.BudgetItemType == 3 || budgetItem.BudgetItemType == 4) ? true : false;
                accountNumber.IsBudgetSource = string.IsNullOrEmpty(detail.BudgetSourceCode) ? false : true;
                accountNumber.IsBudgetGroup = false;
                detailAcountNumberCode = detail.AccountNumber;
                detailCorrespondingAccountNumberCode = detail.CorrespondingAccountNumber;
            }
            else if (voucherDetail.GetType() == typeof(ItemTransactionDetailModel))
            {
                var detail = voucherDetail as ItemTransactionDetailModel;
                accountNumber.IsAccountingObject = this.AccountingObjectId == null ? false : true;
                accountNumber.IsVendor = this.VendorId == null ? false : true;
                accountNumber.IsCustomer = this.CustomerId == null ? false : true;
                accountNumber.IsEmployee = this.EmployeeId == null ? false : true;
                accountNumber.IsProject = detail.ProjectId == null ? false : true;
                var budgetItem = _rpsBudgetItem.GetRowByKeyValue(detail.BudgetItemCode) as BudgetItemModel
                    ?? new BudgetItemModel();
                accountNumber.IsBudgetItem = !string.IsNullOrEmpty(detail.BudgetItemCode) && (budgetItem.BudgetItemType == 3 || budgetItem.BudgetItemType == 4) ? true : false;
                accountNumber.IsBudgetSource = string.IsNullOrEmpty(detail.BudgetSourceCode) ? false : true;
                accountNumber.IsBudgetGroup = false;
                accountNumber.IsInventoryItem = detail.InventoryItemId == 0 ? false : true;
                detailAcountNumberCode = detail.AccountNumber;
                detailCorrespondingAccountNumberCode = detail.CorrespondingAccountNumber;
            }
            else if (voucherDetail.GetType() == typeof(FixedAssetArmortizationDetailModel))
            {
                var detail = voucherDetail as FixedAssetArmortizationDetailModel;
                accountNumber.IsAccountingObject = this.AccountingObjectId == null ? false : true;
                accountNumber.IsVendor = this.VendorId == null ? false : true;
                accountNumber.IsCustomer = this.CustomerId == null ? false : true;
                accountNumber.IsEmployee = this.EmployeeId == null ? false : true;
                accountNumber.IsProject = detail.ProjectId == null ? false : true;
                var budgetItem = _rpsBudgetItem.GetRowByKeyValue(detail.BudgetItemCode) as BudgetItemModel
                    ?? new BudgetItemModel();
                accountNumber.IsBudgetItem = !string.IsNullOrEmpty(detail.BudgetItemCode) && (budgetItem.BudgetItemType == 3 || budgetItem.BudgetItemType == 4) ? true : false;
                accountNumber.IsBudgetSource = string.IsNullOrEmpty(detail.BudgetSourceCode) ? false : true;
                accountNumber.IsBudgetGroup = false;
                accountNumber.IsFixedAsset = detail.FixedAssetId == 0 ? false : true;
                detailAcountNumberCode = detail.AccountNumber;
                detailCorrespondingAccountNumberCode = detail.CorrespondingAccountNumber;
            }
            else if (voucherDetail.GetType() == typeof(FixedAssetIncrementDetailModel))
            {
                var detail = voucherDetail as FixedAssetIncrementDetailModel;
                accountNumber.IsAccountingObject = this.AccountingObjectId == null ? false : true;
                accountNumber.IsVendor = this.VendorId == null ? false : true;
                accountNumber.IsCustomer = this.CustomerId == null ? false : true;
                accountNumber.IsEmployee = this.EmployeeId == null ? false : true;
                accountNumber.IsProject = detail.ProjectId == null ? false : true;
                var budgetItem = _rpsBudgetItem.GetRowByKeyValue(detail.BudgetItemCode) as BudgetItemModel
                    ?? new BudgetItemModel();
                accountNumber.IsBudgetItem = !string.IsNullOrEmpty(detail.BudgetItemCode) && (budgetItem.BudgetItemType == 3 || budgetItem.BudgetItemType == 4) ? true : false;
                accountNumber.IsBudgetSource = string.IsNullOrEmpty(detail.BudgetSourceCode) ? false : true;
                accountNumber.IsBudgetGroup = false;
                accountNumber.IsFixedAsset = detail.FixedAssetId == 0 ? false : true;
                detailAcountNumberCode = detail.AccountNumber;
                detailCorrespondingAccountNumberCode = detail.CorrespondingAccountNumber;
            }
            else if (voucherDetail.GetType() == typeof(FixedAssetDecrementDetailModel))
            {
                var detail = voucherDetail as FixedAssetDecrementDetailModel;
                accountNumber.IsAccountingObject = this.AccountingObjectId == null ? false : true;
                accountNumber.IsVendor = this.VendorId == null ? false : true;
                accountNumber.IsCustomer = this.CustomerId == null ? false : true;
                accountNumber.IsEmployee = this.EmployeeId == null ? false : true;
                accountNumber.IsProject = detail.ProjectId == null ? false : true;
                var budgetItem = _rpsBudgetItem.GetRowByKeyValue(detail.BudgetItemCode) as BudgetItemModel
                    ?? new BudgetItemModel();
                accountNumber.IsBudgetItem = !string.IsNullOrEmpty(detail.BudgetItemCode) && (budgetItem.BudgetItemType == 3 || budgetItem.BudgetItemType == 4) ? true : false;
                accountNumber.IsBudgetSource = string.IsNullOrEmpty(detail.BudgetSourceCode) ? false : true;
                accountNumber.IsBudgetGroup = false;
                accountNumber.IsFixedAsset = detail.FixedAssetId == 0 ? false : true;
                detailAcountNumberCode = detail.AccountNumber;
                detailCorrespondingAccountNumberCode = detail.CorrespondingAccountNumber;
            }
            else if (voucherDetail.GetType() == typeof(GeneralDetailModel))
            {
                var detail = voucherDetail as GeneralDetailModel;
                accountNumber.IsAccountingObject = detail.AccountingObjectId == null ? false : true;
                accountNumber.IsVendor = detail.VendorId == null ? false : true;
                accountNumber.IsCustomer = detail.CustomerId == null ? false : true;
                accountNumber.IsEmployee = detail.EmployeeId == null ? false : true;
                accountNumber.IsProject = detail.ProjectId == null ? false : true;
                var budgetItem = _rpsBudgetItem.GetRowByKeyValue(detail.BudgetItemCode) as BudgetItemModel
                    ?? new BudgetItemModel();
                accountNumber.IsBudgetItem = !string.IsNullOrEmpty(detail.BudgetItemCode) && (budgetItem.BudgetItemType == 3 || budgetItem.BudgetItemType == 4) ? true : false;
                accountNumber.IsBudgetSource = string.IsNullOrEmpty(detail.BudgetSourceCode) ? false : true;
                accountNumber.IsBudgetGroup = false;
                detailAcountNumberCode = detail.AccountNumber;
                detailCorrespondingAccountNumberCode = detail.CorrespondingAccountNumber;
            }

            if (!string.IsNullOrEmpty(detailAcountNumberCode))
            {
                var detailAccountNumber = _accountsPresenter.GetAcount(detailAcountNumberCode);
                if (detailAccountNumber.IsBudgetSource && !accountNumber.IsBudgetSource)
                {
                    XtraMessageBox.Show("Bạn chưa chọn nguồn vốn theo tài khoản " + detailAcountNumberCode + " tại dòng: " + i.ToString(), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (detailAccountNumber.IsBudgetGroup && !accountNumber.IsBudgetGroup)
                {
                    XtraMessageBox.Show("Bạn chưa chọn nhóm theo tài khoản " + detailAcountNumberCode + " tại dòng: " + i.ToString(), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (detailAccountNumber.IsBudgetItem && !accountNumber.IsBudgetItem)
                {
                    XtraMessageBox.Show("Bạn chưa chọn mục - tiểu mục theo tài khoản " + detailAcountNumberCode + " tại dòng: " + i.ToString(), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (detailAccountNumber.IsProject && !accountNumber.IsProject)
                {
                    XtraMessageBox.Show("Bạn chưa chọn dự án theo tài khoản " + detailAcountNumberCode + " tại dòng: " + i.ToString(), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (detailAccountNumber.IsCurrency && !string.IsNullOrEmpty(detailAccountNumber.CurrencyCode) && detailAccountNumber.CurrencyCode != (cboCurrency.EditValue ?? "").ToString())
                {
                    XtraMessageBox.Show("Bạn chưa chọn loại tiền theo tài khoản " + detailAcountNumberCode + " tại dòng: " + i.ToString(), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (detailAccountNumber.IsFixedAsset && !accountNumber.IsFixedAsset)
                {
                    XtraMessageBox.Show("Bạn chưa chọn tài sản theo tài khoản " + detailAcountNumberCode + " tại dòng: " + i.ToString(), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (detailAccountNumber.IsInventoryItem && !accountNumber.IsInventoryItem)
                {
                    XtraMessageBox.Show("Bạn chưa chọn vật tư theo tài khoản " + detailAcountNumberCode + " tại dòng: " + i.ToString(), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (detailAccountNumber.IsEmployee && !accountNumber.IsEmployee)
                {
                    XtraMessageBox.Show("Bạn chưa chọn cán bộ theo tài khoản " + detailAcountNumberCode + " tại dòng: " + i.ToString(), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (detailAccountNumber.IsAccountingObject && !accountNumber.IsAccountingObject)
                {
                    XtraMessageBox.Show("Bạn chưa chọn đối đượng khác theo tài khoản " + detailAcountNumberCode + " tại dòng: " + i.ToString(), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (detailAccountNumber.IsVendor && !accountNumber.IsVendor)
                {
                    XtraMessageBox.Show("Bạn chưa chọn nhà cung cấp theo tài khoản " + detailAcountNumberCode + " tại dòng: " + i.ToString(), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (detailAccountNumber.IsCustomer && !accountNumber.IsCustomer)
                {
                    XtraMessageBox.Show("Bạn chưa chọn khác hàng theo tài khoản " + detailAcountNumberCode + " tại dòng: " + i.ToString(), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            if (!string.IsNullOrEmpty(detailCorrespondingAccountNumberCode))
            {
                var detailCorrespondingAccountNumber = _accountsPresenter.GetAcount(detailCorrespondingAccountNumberCode);
                if (detailCorrespondingAccountNumber.IsBudgetSource && !accountNumber.IsBudgetSource)
                {
                    XtraMessageBox.Show("Bạn chưa chọn nguồn vốn theo tài khoản " + detailCorrespondingAccountNumberCode + " tại dòng: " + i.ToString(), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (detailCorrespondingAccountNumber.IsBudgetGroup && !accountNumber.IsBudgetGroup)
                {
                    XtraMessageBox.Show("Bạn chưa chọn nhóm theo tài khoản " + detailCorrespondingAccountNumberCode + " tại dòng: " + i.ToString(), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (detailCorrespondingAccountNumber.IsBudgetItem && !accountNumber.IsBudgetItem)
                {
                    XtraMessageBox.Show("Bạn chưa chọn mục - tiểu mục theo tài khoản " + detailCorrespondingAccountNumberCode + " tại dòng: " + i.ToString(), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (detailCorrespondingAccountNumber.IsProject && !accountNumber.IsProject)
                {
                    XtraMessageBox.Show("Bạn chưa chọn dự án theo tài khoản " + detailCorrespondingAccountNumberCode + " tại dòng: " + i.ToString(), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (detailCorrespondingAccountNumber.IsCurrency && !string.IsNullOrEmpty(detailCorrespondingAccountNumber.CurrencyCode) && detailCorrespondingAccountNumber.CurrencyCode != (cboCurrency.EditValue ?? "").ToString())
                {
                    XtraMessageBox.Show("Bạn chưa chọn loại tiền theo tài khoản " + detailCorrespondingAccountNumberCode + " tại dòng: " + i.ToString(), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (detailCorrespondingAccountNumber.IsFixedAsset && !accountNumber.IsFixedAsset)
                {
                    XtraMessageBox.Show("Bạn chưa chọn tài sản theo tài khoản " + detailCorrespondingAccountNumberCode + " tại dòng: " + i.ToString(), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (detailCorrespondingAccountNumber.IsInventoryItem && !accountNumber.IsInventoryItem)
                {
                    XtraMessageBox.Show("Bạn chưa chọn vật tư theo tài khoản " + detailCorrespondingAccountNumberCode + " tại dòng: " + i.ToString(), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (detailCorrespondingAccountNumber.IsEmployee && !accountNumber.IsEmployee)
                {
                    XtraMessageBox.Show("Bạn chưa chọn cán bộ theo tài khoản " + detailCorrespondingAccountNumberCode + " tại dòng: " + i.ToString(), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (detailCorrespondingAccountNumber.IsAccountingObject && !accountNumber.IsAccountingObject)
                {
                    XtraMessageBox.Show("Bạn chưa chọn đối đượng khác theo tài khoản " + detailCorrespondingAccountNumberCode + " tại dòng: " + i.ToString(), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (detailCorrespondingAccountNumber.IsVendor && !accountNumber.IsVendor)
                {
                    XtraMessageBox.Show("Bạn chưa chọn nhà cung cấp theo tài khoản " + detailCorrespondingAccountNumberCode + " tại dòng: " + i.ToString(), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (detailCorrespondingAccountNumber.IsCustomer && !accountNumber.IsCustomer)
                {
                    XtraMessageBox.Show("Bạn chưa chọn khác hàng theo tài khoản " + detailCorrespondingAccountNumberCode + " tại dòng: " + i.ToString(), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }
    }
}
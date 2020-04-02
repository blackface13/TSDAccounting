/***********************************************************************
 * <copyright file="FrmXtraBaseTreeDetail.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Tuesday, February 11, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 27/8/2015: LINHMC   Đưa phần nhật ký vào form base ghi lại thao tác người dùng
 * ************************************************************************/

using System;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using TSD.AccountingSoft.Presenter.Dictionary.AudittingLog;
using TSD.AccountingSoft.Session;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.WindowsForm.CommonClass;
using TSD.AccountingSoft.WindowsForm.Resources;
using TSD.Enum;
using DevExpress.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;


namespace TSD.AccountingSoft.WindowsForm.FormBase
{
    public partial class FrmXtraBaseTreeDetail : XtraForm, IAudittingLogView
    {
        #region Variables

        /// <summary>
        /// The _auditting log presenter
        /// </summary>
        private readonly AudittingLogPresenter _audittingLogPresenter;

        /// <summary>
        /// Gets or sets the e action mode.
        /// </summary>
        /// <value>
        /// The e action mode.
        /// </value>
        public ActionModeEnum ActionMode;

        /// <summary>
        /// The key for send
        /// </summary>
        private string _keyForSend;

        /// <summary>
        /// The has children
        /// </summary>
        public new bool HasChildren;

        private GlobalVariable _dbOptionHelper;
        protected string CurrencyAccounting;
        protected string CurrencyLocal;
        protected string ExchangeRateDecimalDigits;
        protected DateTime PostedDate;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the form caption.
        /// </summary>
        /// <value>
        /// The form caption.
        /// </value>
        [Category("BaseProperty")]
        public string FormCaption { get; set; }
        /// <summary>
        /// Gets or sets the key value.
        /// </summary>
        /// <value>
        /// The key value.
        /// </value>
        [Category("BaseProperty")]
        public string KeyValue { get; set; }

        /// <summary>
        /// Gets or sets the name of the key field.
        /// </summary>
        /// <value>
        /// The name of the key field.
        /// </value>
        [Category("BaseProperty")]
        public string KeyFieldName { get; set; }

        /// <summary>
        /// Gets or sets the name of the parent.
        /// </summary>
        /// <value>
        /// The name of the parent.
        /// </value>
        [Category("BaseProperty")]
        public string ParentName { get; set; }

        /// <summary>
        /// Gets or sets the current row.
        /// </summary>
        /// <value>
        /// The current row.
        /// </value>
        [Category("BaseProperty")]
        public object CurrentNode { get; set; }

        /// <summary>
        /// Gets or sets the table code.
        /// </summary>
        /// <value>
        /// The table code.
        /// </value>
        [Category("BaseProperty")]
        public string TableCode { get; set; }

        /// <summary>
        /// Gets or sets the help topic identifier.
        /// </summary>
        /// <value>
        /// The help topic identifier.
        /// </value>
        [Category("BaseProperty")]
        public int HelpTopicId { get; set; }

        #endregion

        #region Functions

        /// <summary>
        /// Initializes the layout.
        /// </summary>
        private void InitializeLayout()
        {
            Text = ActionMode == ActionModeEnum.AddNew ? 
                string.Format(ResourceHelper.GetResourceValueByName("ResAddNewText"), FormCaption) : 
                string.Format(ResourceHelper.GetResourceValueByName("ResEditText"), FormCaption);
            _dbOptionHelper = new GlobalVariable();
            CurrencyAccounting = _dbOptionHelper.CurrencyAccounting;
            CurrencyLocal = _dbOptionHelper.CurrencyLocal;
            ExchangeRateDecimalDigits = _dbOptionHelper.ExchangeRateDecimalDigits;
            PostedDate = DateTime.Parse(_dbOptionHelper.PostedDate);
            InitControls();
        }

        /// <summary>
        /// Closes the form.
        /// </summary>
        private void CloseForm()
        {
            //using (new FrmBaseCategoryList())
            //{
                if (PostKeyValue != null) PostKeyValue(this, _keyForSend);
                Close();
            //}
        }

        /// <summary>
        /// Formats the control.
        /// </summary>
        protected void FormatControl(Control oContainer)
        {
            foreach (Control control in oContainer.Controls)
            {
                if (control.GetType() == typeof(DateEdit))
                {
              
                    ((DateEdit)control).Properties.Mask.Culture = Thread.CurrentThread.CurrentCulture;
                    ((DateEdit)control).Properties.Mask.UseMaskAsDisplayFormat = true;
                }
                if (control.GetType() == typeof(SpinEdit))
                {
                    if ((string)control.Tag == ControlValueType.Quantity.GetDescription())
                    {
                        ((SpinEdit)control).Properties.EditMask = "n" + _dbOptionHelper.NumberDecimalDigits;
                    }
                    if ((string)control.Tag == ControlValueType.Year.GetDescription())
                    {
                        ((SpinEdit)control).Properties.Mask.MaskType = MaskType.RegEx;
                        ((SpinEdit)control).Properties.EditMask = @"\d{0,4}";
                    }
                    if ((string)control.Tag == ControlValueType.ExchangeRate.GetDescription())
                    {
                        ((SpinEdit)control).Properties.EditMask = "c" + _dbOptionHelper.ExchangeRateDecimalDigits;
                    }
                    if ((string)control.Tag == ControlValueType.Percent.GetDescription())
                    {
                        ((SpinEdit)control).Properties.EditMask = "P" + _dbOptionHelper.PercentDecimalDigits;
                    }
                    if ((string)control.Tag == ControlValueType.Money.GetDescription())
                    {
                        ((SpinEdit)control).Properties.EditMask = "c" + _dbOptionHelper.CurrencyDecimalDigits;
                    }
                    ((SpinEdit)control).Properties.Mask.Culture = Thread.CurrentThread.CurrentCulture;
                    ((SpinEdit)control).Properties.Mask.UseMaskAsDisplayFormat = true;
                }
                if (control.GetType() == typeof(CalcEdit))
                {
                    if ((string)control.Tag == ControlValueType.Quantity.GetDescription())
                    {
                        ((CalcEdit)control).Properties.EditMask = "n" + _dbOptionHelper.NumberDecimalDigits;
                    }
                    else if ((string)control.Tag == ControlValueType.Year.GetDescription())
                    {
                        ((CalcEdit)control).Properties.Mask.MaskType = MaskType.RegEx;
                        ((CalcEdit)control).Properties.EditMask = @"\d{0,4}";
                    }
                    else if ((string)control.Tag == ControlValueType.ExchangeRate.GetDescription())
                    {
                        ((CalcEdit)control).Properties.EditMask = "c" + _dbOptionHelper.ExchangeRateDecimalDigits;
                        //LinhMC thêm 24/8/2015:
                        ((CalcEdit)control).Properties.Precision = int.Parse(_dbOptionHelper.ExchangeRateDecimalDigits);
                    }
                    else if ((string)control.Tag == ControlValueType.Percent.GetDescription())
                    {
                        ((CalcEdit)control).Properties.EditMask = "P" + _dbOptionHelper.PercentDecimalDigits;
                    }
                    else
                    {
                        ((CalcEdit)control).Properties.EditMask = "c" + _dbOptionHelper.CurrencyDecimalDigits;
                        //LinhMC thêm 24/8/2015:
                        ((CalcEdit)control).Properties.Precision = int.Parse(_dbOptionHelper.CurrencyDecimalDigits);
                    }
                    ((CalcEdit)control).Properties.Mask.Culture = Thread.CurrentThread.CurrentCulture;
                    ((CalcEdit)control).Properties.Mask.UseMaskAsDisplayFormat = true;
                }
                if (control.Controls.Count > 0)
                {
                    FormatControl(control);
                }
            }
        }

        /// <summary>
        /// Gets the automatic number.
        /// </summary>
        /// <returns></returns>
        protected string GetAutoNumber()
        {
            if (!string.IsNullOrEmpty(TableCode))
            {
                var objAutoNumberList = new Model.Model().GetAutoNumberList(TableCode);
                string str = @"00000000000000000000000000000";
                str = str.Substring(0, objAutoNumberList.LengthOfValue - objAutoNumberList.Value.ToString(CultureInfo.InvariantCulture).Length);
                return (objAutoNumberList.Prefix + str + objAutoNumberList.Value + objAutoNumberList.Suffix);
            }
            return "";
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
        protected virtual int SaveData()
        {
            return 0;
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
        }

        /// <summary>
        /// Focuses the control.
        /// </summary>
        protected virtual void InitControls()
        {
        }

        /// <summary>
        /// Automatics the reference no.
        /// </summary>
        protected virtual void AutoRefNo()
        {
        }

                /// <summary>
        /// Sets the numeric format control.
        /// </summary>
        /// <param name="gridView">The grid view.</param>
        /// <param name="isSummary">if set to <c>true</c> [is summary].</param>
        protected virtual void SetNumericFormatControl(GridView gridView, bool isSummary)
        {
            //Get format data from db to format grid control
            if (!DesignMode)
            {
                var repositoryCurrencyCalcEdit = new RepositoryItemCalcEdit();
                var repositoryNumberCalcEdit = new RepositoryItemCalcEdit();
                foreach (GridColumn oCol in gridView.Columns)
                {
                    if (!oCol.Visible) continue;
                    switch (oCol.UnboundType)
                    {
                        case UnboundColumnType.Decimal:
                            repositoryCurrencyCalcEdit.Mask.MaskType = MaskType.Numeric;
                            repositoryCurrencyCalcEdit.Mask.EditMask = @"c" +  _dbOptionHelper.CurrencyDecimalDigits;
                            repositoryCurrencyCalcEdit.Mask.Culture = Thread.CurrentThread.CurrentCulture;
                            repositoryCurrencyCalcEdit.Mask.UseMaskAsDisplayFormat = true;
                            //LinhMC thêm 24/8/2015:
                            repositoryCurrencyCalcEdit.Precision = int.Parse(_dbOptionHelper.CurrencyDecimalDigits);
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
                            oCol.SummaryItem.DisplayFormat = GlobalVariable.NumericDisplayString;
                            oCol.SummaryItem.Format = Thread.CurrentThread.CurrentCulture;
                            break;

                        case UnboundColumnType.DateTime:
                            oCol.DisplayFormat.FormatString =
                                Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
                            oCol.DisplayFormat.Format = Thread.CurrentThread.CurrentCulture.DateTimeFormat;
                            break;
                    }
                }
            }
        }


        #endregion

        #region Events

        public FrmXtraBaseTreeDetail()
        {
            InitializeComponent();
            _audittingLogPresenter = new AudittingLogPresenter(this);
        }

        /// <summary>
        /// Handles the Load event of the FrmXtraBaseTreeDetail control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FrmXtraBaseTreeDetail_Load(object sender, EventArgs e)
        {
            try
            {
                if (DesignMode) return;
                InitializeLayout();
                InitData();
                FormatControl(this);
                if (ActionMode == ActionModeEnum.AddNew) AutoRefNo();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the Click event of the btnSave control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidData())
                {
                    var rowAffected = SaveData();
                    if (rowAffected > 0)
                    {
                        SaveAuditingLog();//LINHMC ADD 27/8/2012
                        _keyForSend = ActionMode == ActionModeEnum.AddNew
                                          ? rowAffected.ToString(CultureInfo.InvariantCulture)
                                          : KeyValue;
                        this.DialogResult = DialogResult.OK;
                        CloseForm();
                    }
                    else
                        XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResSaveDataError"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the Click event of the btnExit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Handles the Click event of the btnHelp control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnHelp_Click(object sender, EventArgs e)
        {
            ShowHelp();
        }

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
            get { return (string.IsNullOrEmpty(FormCaption) ? "" : CommonFunction.FirstCharToUpper(FormCaption)); }
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
                    case ActionModeEnum.AddNew:
                        return 1;
                    case ActionModeEnum.Edit:
                        return 2;
                    case ActionModeEnum.Delete:
                        return 3;
                    default:
                        return 4;
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
                    case ActionModeEnum.AddNew:
                        return "THÊM " + (string.IsNullOrEmpty(FormCaption) ? "" : FormCaption.ToUpper()) + " - ID " + KeyValue;
                    case ActionModeEnum.Edit:
                        return "SỬA " + (string.IsNullOrEmpty(FormCaption) ? "" : FormCaption.ToUpper()) + " - ID " + KeyValue;
                    case ActionModeEnum.Delete:
                        return "XÓA " + (string.IsNullOrEmpty(FormCaption) ? "" : FormCaption.ToUpper()) + " - ID " + KeyValue;
                    default:
                        return "XEM " + (string.IsNullOrEmpty(FormCaption) ? "" : FormCaption.ToUpper()) + " - ID " + KeyValue;
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
    }
}
/***********************************************************************
 * <copyright file="FrmXtraFixedAssetFAInventoryHouse.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: 10 January 2015
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using TSD.AccountingSoft.Presenter.Report;
using TSD.AccountingSoft.Report.BaseParameterForm;
using TSD.AccountingSoft.Session;
using TSD.AccountingSoft.View.Report;
using DateTimeRangeBlockDev.Helper;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;

namespace TSD.AccountingSoft.Report.ParameterReportForm
{
    /// <summary>
    /// class FrmXtraFixedAssetFAInventoryHouse
    /// </summary>
    public partial class FrmXtraFixedAssetFAInventoryHouse : FrmXtraBaseParameter, IFixedAssetHousingReportView
    {
        private readonly GlobalVariable _dbOptionHelper;
        private readonly FixedAssetHousingReportPresenter _fixedAssetHousingReportPresenter;
        public bool CheckValidate = false;
        protected string CurrencyAccounting;
        protected string CurrencyAccountingUSD = "USD";
        private RepositoryItemCalcEdit _calcEditExchangeRate;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmXtraFixedAssetFAInventoryHouse"/> class.
        /// </summary>
        public FrmXtraFixedAssetFAInventoryHouse()
        {
            InitializeComponent();
            _calcEditExchangeRate = new RepositoryItemCalcEdit();
            _calcEditExchangeRate.ReadOnly = true;
            _fixedAssetHousingReportPresenter = new FixedAssetHousingReportPresenter(this);
            _dbOptionHelper = new GlobalVariable();
            dateTimeRangeV1.DateRangePeriodMode = DateRangeMode.Reduce;
            dateTimeRangeV1.InitSelectedIndex = GlobalVariable.DateRangeSelectedIndex;
            //
            spnTotalArea.Properties.Mask.MaskType = MaskType.Numeric;
            spnTotalArea.Properties.EditMask = @"c" + (new GlobalVariable()).CurrencyDecimalDigits;
            spnTotalArea.Properties.Mask.Culture = Thread.CurrentThread.CurrentCulture;
            spnTotalArea.Properties.Mask.UseMaskAsDisplayFormat = true;
            //
            spnGuestHouseArea.Properties.Mask.MaskType = MaskType.Numeric;
            spnGuestHouseArea.Properties.EditMask = @"c" + (new GlobalVariable()).CurrencyDecimalDigits;
            spnGuestHouseArea.Properties.Mask.Culture = Thread.CurrentThread.CurrentCulture;
            spnGuestHouseArea.Properties.Mask.UseMaskAsDisplayFormat = true;
            //
            spnVacancyArea.Properties.Mask.MaskType = MaskType.Numeric;
            spnVacancyArea.Properties.EditMask = @"c" + (new GlobalVariable()).CurrencyDecimalDigits;
            spnVacancyArea.Properties.Mask.Culture = Thread.CurrentThread.CurrentCulture;
            spnVacancyArea.Properties.Mask.UseMaskAsDisplayFormat = true;
            //
            spnHousingArea.Properties.Mask.MaskType = MaskType.Numeric;
            spnHousingArea.Properties.EditMask = @"c" + (new GlobalVariable()).CurrencyDecimalDigits;
            spnHousingArea.Properties.Mask.Culture = Thread.CurrentThread.CurrentCulture;
            spnHousingArea.Properties.Mask.UseMaskAsDisplayFormat = true;
            //
            spnWorkingArea.Properties.Mask.MaskType = MaskType.Numeric;
            spnWorkingArea.Properties.EditMask = @"c" + (new GlobalVariable()).CurrencyDecimalDigits;
            spnWorkingArea.Properties.Mask.Culture = Thread.CurrentThread.CurrentCulture;
            spnWorkingArea.Properties.Mask.UseMaskAsDisplayFormat = true;
            //
            spnOtherArea.Properties.Mask.MaskType = MaskType.Numeric;
            spnOtherArea.Properties.EditMask = @"c" + (new GlobalVariable()).CurrencyDecimalDigits;
            spnOtherArea.Properties.Mask.Culture = Thread.CurrentThread.CurrentCulture;
            spnOtherArea.Properties.Mask.UseMaskAsDisplayFormat = true;
            //
            spnAccountingValue.Properties.Mask.MaskType = MaskType.Numeric;
            spnAccountingValue.Properties.EditMask = @"c" + (new GlobalVariable()).CurrencyDecimalDigits;
            spnAccountingValue.Properties.Mask.Culture = Thread.CurrentThread.CurrentCulture;
            spnAccountingValue.Properties.Mask.UseMaskAsDisplayFormat = true;

        }

        /// <summary>
        /// Gets or sets from date.
        /// </summary>
        /// <value>
        /// From date.
        /// </value>
        public string FromDate
        {
            get { return dateTimeRangeV1.FromDate.ToShortDateString(); }
        }

        /// <summary>
        /// Gets or sets the reference date.
        /// </summary>
        /// <value>
        /// The reference date.
        /// </value>
        public string ToDate
        {
            get { return dateTimeRangeV1.ToDate.ToShortDateString(); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is total band in new page.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is total band in new page; otherwise, <c>false</c>.
        /// </value>
        public bool IsTotalBandInNewPage
        {
            get { return chkMoveTotalInNewPage.Checked; }
            set { chkMoveTotalInNewPage.Checked = value; }
        }

        /// <summary>
        /// Gets or sets the area of building.
        /// </summary>
        /// <value>
        /// The area of building.
        /// </value>
        public decimal AreaOfBuilding
        {
            get { return decimal.Parse(spnTotalArea.Text); }
            set { spnTotalArea.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the working area.
        /// </summary>
        /// <value>
        /// The working area.
        /// </value>
        public decimal WorkingArea
        {
            get { return decimal.Parse(spnWorkingArea.Text); }
            set { spnWorkingArea.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the housing area.
        /// </summary>
        /// <value>
        /// The housing area.
        /// </value>
        public decimal HousingArea
        {
            get { return decimal.Parse(spnHousingArea.Text); }
            set { spnHousingArea.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the guest house area.
        /// </summary>
        /// <value>
        /// The guest house area.
        /// </value>
        public decimal GuestHouseArea
        {
            get { return decimal.Parse(spnGuestHouseArea.Text); }
            set { spnGuestHouseArea.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the occupied area.
        /// </summary>
        /// <value>
        /// The occupied area.
        /// </value>
        public decimal OccupiedArea
        {
            get { return decimal.Parse(spnVacancyArea.Text); }
            set { spnVacancyArea.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the other area.
        /// </summary>
        /// <value>
        /// The other area.
        /// </value>
        public decimal OtherArea
        {
            get { return decimal.Parse(spnOtherArea.Text); }
            set { spnOtherArea.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the fixed asset housing report identifier.
        /// </summary>
        /// <value>
        /// The fixed asset housing report identifier.
        /// </value>
        public int FixedAssetHousingReportId { get; set; }

        /// <summary>
        /// Gets or sets the accounting value.
        /// </summary>
        /// <value>
        /// The accounting value.
        /// </value>
        public decimal AccountingValue
        {
            get { return decimal.Parse(spnAccountingValue.Text); }
            set { spnAccountingValue.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the attachments.
        /// </summary>
        /// <value>
        /// The attachments.
        /// </value>
        public string Attachments
        {
            get { return memoOther.Text; }
            set { memoOther.EditValue = value; }
        }

        /// <summary>
        /// Handles the Load event of the FrmXtraFixedAssetFAInventoryHouse control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FrmXtraFixedAssetFAInventoryHouse_Load(object sender, EventArgs e)
        {
            _fixedAssetHousingReportPresenter.Display(true);
            CurrencyAccounting = _dbOptionHelper.CurrencyAccounting;
        }

        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns></returns>
        protected override bool ValidData()
        {
            if (dateTimeRangeV1.FromDate.ToString(CultureInfo.InvariantCulture) == "")
            {
                XtraMessageBox.Show("Bạn chưa chọn ngày tính giá", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return false;
            }

            if (dateTimeRangeV1.ToDate.ToString(CultureInfo.InvariantCulture) == "")
            {
                XtraMessageBox.Show("Bạn chưa chọn ngày tính giá", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return false;
            }
            DialogResult = DialogResult.OK;
            GlobalVariable.DateRangeSelectedIndex = dateTimeRangeV1.cboDateRange.SelectedIndex;
            return true;
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
        /// Handles the Click event of the btnOk control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            _fixedAssetHousingReportPresenter.Save();
        }
    }
}
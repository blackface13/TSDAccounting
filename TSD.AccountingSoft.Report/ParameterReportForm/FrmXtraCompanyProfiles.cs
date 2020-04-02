using System;
using TSD.AccountingSoft.Presenter.Estimate.EstimateDetailStatement;
using TSD.AccountingSoft.Report.BaseParameterForm;
using TSD.AccountingSoft.Session;
using TSD.AccountingSoft.View.Estimate;
using DateTimeRangeBlockDev.Helper;
using DevExpress.XtraEditors.Repository;


namespace TSD.AccountingSoft.Report.ParameterReportForm
{
    public partial class FrmXtraCompanyProfiles : FrmXtraBaseParameter, IEstimateDetailStatementView
    {
        private readonly EstimateDetailStatementPresenter _estimateDetailStatementPresenter;
        private readonly GlobalVariable _dbOptionHelper;
        private readonly RepositoryItemCalcEdit _repositoryCurrencyCalcEdit;
        private readonly RepositoryItemCalcEdit _repositoryNumberCalcEdit;

        public FrmXtraCompanyProfiles()
        {
            InitializeComponent();
            dateTimeRangeV1.DateRangePeriodMode = DateRangeMode.Reduce;
            dateTimeRangeV1.InitSelectedIndex = GlobalVariable.DateRangeSelectedIndex;

            _estimateDetailStatementPresenter = new EstimateDetailStatementPresenter(this);
            _repositoryCurrencyCalcEdit = new RepositoryItemCalcEdit();
            _repositoryNumberCalcEdit = new RepositoryItemCalcEdit();
            _dbOptionHelper = new GlobalVariable();

        }

        #region Properties


        /// <summary>
        /// Gets or sets from date.
        /// </summary>
        /// <value>
        /// From date.
        /// </value>
        public string FromDate
        {
            get
            {
                return dateTimeRangeV1.FromDate.ToShortDateString();
            }
        }

        /// <summary>
        /// Gets or sets the reference date.
        /// </summary>
        /// <value>
        /// The reference date.
        /// </value>
        public string ToDate
        {
            get
            {
                return dateTimeRangeV1.ToDate.ToShortDateString();
            }
        }

        /// <summary>
        /// Gets or sets the repor date.
        /// </summary>
        /// <value>
        /// The repor date.
        /// </value>
        public string ReporDate
        {
            get { return ((DateTime)dtReportDate.EditValue).ToShortDateString(); }
            set { dtReportDate.EditValue = DateTime.Parse(value); }
        }



        #endregion

        public bool Type { get { return false; } set{}}

        public int EstimateDetailStatementId { get; set; }
        public string GeneralDescription
        {
            get { return "a"; }
            set { }
        }
        public string EmployeeLeasingDescription { get; set; }
        public string EmployeeContractDescription { get; set; }
        public string BuildingOfFixedAssetDescription { get; set; }
        public string DescriptionForBuilding { get; set; }
        public string CarDescription { get; set; }
        public string InventoryDescription { get; set; }
        public string PartC
        {
            get { return memoPartC.Text; }
            set { memoPartC.Text = value; }
        }

        public string PartC1 {get; set; }
        public bool IsActive { get; set; }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _estimateDetailStatementPresenter.Save();
        }

        private void FrmXtraCompanyProfiles_Load(object sender, EventArgs e)
        {
            _estimateDetailStatementPresenter.DisplayCompanyProfileInfo(true);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

using System.Windows.Forms;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.Presenter.Dictionary.BudgetSourceCategory;
using TSD.AccountingSoft.WindowsForm.Resources;
using DevExpress.XtraEditors;

namespace TSD.AccountingSoft.WindowsForm.FormDictionary
{
    /// <summary>
    /// 
    /// </summary>
    public partial class FrmXtraBudgetSourceCategoryDetail : FrmXtraBaseCategoryDetail,IBudgetSourceCategoryView
    {
        /// <summary>
        /// The _budget source category presenter
        /// </summary>
        private readonly BudgetSourceCategoryPresenter _budgetSourceCategoryPresenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmXtraBudgetSourceCategoryDetail"/> class.
        /// </summary>
        public FrmXtraBudgetSourceCategoryDetail()
        {
            InitializeComponent();
            _budgetSourceCategoryPresenter = new BudgetSourceCategoryPresenter(this);
        }

        /// <summary>
        /// Gets or sets the budget source category identifier.
        /// </summary>
        /// <value>
        /// The budget source category identifier.
        /// </value>
        public int BudgetSourceCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the budget source category code.
        /// </summary>
        /// <value>
        /// The budget source category code.
        /// </value>
        public string BudgetSourceCategoryCode
        {
            get { return txtBudgetSourceCategoryCode.Text; }
            set { txtBudgetSourceCategoryCode.Text = value; }
        }

        /// <summary>
        /// Gets or sets the name of the budget source category.
        /// </summary>
        /// <value>
        /// The name of the budget source category.
        /// </value>
        public string BudgetSourceCategoryName
        {
            get { return txtBudgetSourceCategoryName.Text; }
            set { txtBudgetSourceCategoryName.Text = value; }
        }

        public string ForeignName
        {
            get { return txtForeignName.Text; }
            set { txtForeignName.Text = value; }
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description
        {
            get { return memoDescription.Text; }
            set { memoDescription.Text = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [is active].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is active]; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive
        {
            get { return chkIsActive.Checked; }
            set { chkIsActive.Checked = value; }
        }

        public bool IsSummaryEstimateReport
        {
            get { return chkIsSummaryEstimateReport.Checked; }
            set { chkIsSummaryEstimateReport.Checked = value; }
        }

        /// <summary>
        /// Initializes the data.
        /// </summary>
        protected override void InitData()
        {
            if (KeyValue != null) { _budgetSourceCategoryPresenter.Display(KeyValue); }
        }

        /// <summary>
        /// Focuses the control.
        /// </summary>
        protected override void InitControls()
        {
        }

        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns></returns>
        protected override bool ValidData()
        {
            if (string.IsNullOrEmpty(BudgetSourceCategoryCode))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResProjectCode"),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBudgetSourceCategoryCode.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(BudgetSourceCategoryName))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResProjectName"),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBudgetSourceCategoryName.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// Saves the data.
        /// </summary>
        /// <returns></returns>
        protected override int SaveData()
        {
            return _budgetSourceCategoryPresenter.Save();
        }
    }
}

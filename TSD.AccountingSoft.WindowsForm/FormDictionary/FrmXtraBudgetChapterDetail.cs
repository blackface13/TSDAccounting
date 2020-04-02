/***********************************************************************
 * <copyright file="FrmXtraBudgetChapterDetail.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   THODD
 * Email:    thodd@buca.vn
 * Website:
 * Create Date: Tuesday, February 11, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.Windows.Forms;
using TSD.AccountingSoft.Presenter.Dictionary.BudgetChapter;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.Resources;
using DevExpress.XtraEditors;


namespace TSD.AccountingSoft.WindowsForm.FormDictionary
{
    public partial class FrmXtraBudgetChapterDetail : FrmXtraBaseCategoryDetail, IBudgetChapterView
    {
        private readonly BudgetChapterPresenter _budgetChapterPresenter;
        #region Properties

        /// <summary>
        /// Gets or sets the budget source property identifier.
        /// </summary>
        /// <value>
        /// The budget source property identifier.
        /// </value>
        public int BudgetChapterId { get; set; }
        /// <summary>
        /// Gets or sets the budget source property code.
        /// </summary>
        /// <value>
        /// The budget source property code.
        /// </value>
        public string BudgetChapterCode
        {
            get { return txtBudgetChapterCode.Text; }
            set { txtBudgetChapterCode.Text = value; }
        }
        /// <summary>
        /// Gets or sets the name of the budget source property.
        /// </summary>
        /// <value>
        /// The name of the budget source property.
        /// </value>
        public string BudgetChapterName
        {
            get { return txtBudgetChapterName.Text; }
            set { txtBudgetChapterName.Text = value; }
        }

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
        /// <summary>
        /// Gets or sets a value indicating whether [is system].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is system]; otherwise, <c>false</c>.
        /// </value>
        public bool IsSystem { get; set; }

        public string ForeignName { get; set; }

        #endregion

        public FrmXtraBudgetChapterDetail()
        {
            InitializeComponent();
            _budgetChapterPresenter = new BudgetChapterPresenter(this);
        }

        /// <summary>
        /// Initializes the data.
        /// </summary>
        protected override void InitData()
        {
            if (KeyValue != null)
                _budgetChapterPresenter.Display(KeyValue);
        }
        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns></returns>
        protected override bool ValidData()
        {
            if (string.IsNullOrEmpty(BudgetChapterCode))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResBudgetChapterCode"),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBudgetChapterCode.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(BudgetChapterName))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResBudgetChapterName"),
                                ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBudgetChapterCode.Focus();
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
            return _budgetChapterPresenter.Save();
        }
        /// <summary>
        /// Focuses the control.
        /// </summary>
        protected override void InitControls()
        {
            txtBudgetChapterCode.Focus();
        }

    }
}
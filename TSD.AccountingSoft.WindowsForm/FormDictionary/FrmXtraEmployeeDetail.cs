/***********************************************************************
 * <copyright file="FrmXtraEmployeeDetail.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   ThangND
 * Email:    thangnd@buca.vn
 * Website:
 * Create Date: 08 March 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Presenter.Dictionary.Department;
using TSD.AccountingSoft.Presenter.Dictionary.Employee;
using TSD.AccountingSoft.Presenter.Dictionary.PayItem;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.WindowsForm.CommonClass;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.FormBase.PropertyGrid;
using TSD.AccountingSoft.WindowsForm.Resources;
using TSD.AccountingSoft.Session;
using TSD.Enum;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;


namespace TSD.AccountingSoft.WindowsForm.FormDictionary
{
    /// <summary>
    /// class FrmXtraEmployeeDetail
    /// </summary>
    public partial class FrmXtraEmployeeDetail : FrmXtraBaseCategoryDetail, IEmployeeView, IDepartmentsView, IPayItemsView
    {
        private readonly DepartmentsPresenter _departmentsPresenter;
        private readonly EmployeePresenter _employeePresenter;
        private readonly PayItemsPresenter _payItemsPresenter;
        private readonly GlobalVariable _dbOptionHelper;
        private IList<PayItemModel> _payItems;
        private readonly GlobalVariable _globalVariable;
        public int IdResult = -1;
        private List<DepartmentModel> _department;

        #region Employee

        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>
        /// The employee identifier.
        /// </value>
        public int EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets the employee code.
        /// </summary>
        /// <value>
        /// The employee code.
        /// </value>
        public string EmployeeCode
        {
            get { return txtEmployeeCode.Text; }
            set { txtEmployeeCode.Text = value; }
        }


        public bool IsOffice
        {
            get { return chkIsOffice.Checked; }
            set { chkIsOffice.Checked = value; }
        }

        /// <summary>
        /// Gets or sets the name of the employee.
        /// </summary>
        /// <value>
        /// The name of the employee.
        /// </value>
        public string EmployeeName
        {
            get { return txtEmployeeName.Text; }
            set { txtEmployeeName.Text = value; }
        }

        /// <summary>
        /// Gets or sets the name of the job candidate.
        /// </summary>
        /// <value>
        /// The name of the job candidate.
        /// </value>
        public string JobCandidateName
        {
            get { return txtJobCandidateName.Text; }
            set { txtJobCandidateName.Text = value; }
        }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        /// <value>
        /// The sort order.
        /// </value>
        public int SortOrder
        {
            get { return (int)spinSortOrder.Value; }
            set { spinSortOrder.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the birth date.
        /// </summary>
        /// <value>
        /// The birth date.
        /// </value>
        public string BirthDate
        {
            get { return dateBirthDate.EditValue == null ? null : dateBirthDate.EditValue.ToString(); }
            set { dateBirthDate.EditValue = value == null ? (object)null : DateTime.Parse(value); }
        }

        /// <summary>
        /// Gets or sets the type of salary.
        /// </summary>
        /// <value>
        /// The type of salary.
        /// </value>
        public int TypeOfSalary
        {
            get { return cboTypeOfSalary.SelectedIndex; }
            set { cboTypeOfSalary.SelectedIndex = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [sex].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [sex]; otherwise, <c>false</c>.
        /// </value>
        public bool Sex
        {
            get { return (bool)rndSex.EditValue; }
            set { rndSex.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the level of salary.
        /// </summary>
        /// <value>
        /// The level of salary.
        /// </value>
        public string LevelOfSalary
        {
            get { return txtLevelOfSalary.Text; }
            set { txtLevelOfSalary.Text = value; }
        }

        /// <summary>
        /// Gets or sets the department identifier.
        /// </summary>
        /// <value>
        /// The department identifier.
        /// </value>
        public int? DepartmentId
        {
            get { return grdLookUpEditDepartmentID.EditValue == null ? null : (int?)grdLookUpEditDepartmentID.EditValue; }
            set { grdLookUpEditDepartmentID.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the currency code.
        /// </summary>
        /// <value>
        /// The currency code.
        /// </value>
        public string CurrencyCode
        {
            get { return cboCurrencyCode.EditValue.ToString(); }
            set { cboCurrencyCode.EditValue = value; }
        }

        /// <summary>
        /// Gets or sets the identity no.
        /// </summary>
        /// <value>
        /// The identity no.
        /// </value>
        public string IdentityNo
        {
            get { return txtIdentityNo.Text; }
            set { txtIdentityNo.Text = value; }
        }

        /// <summary>
        /// Gets or sets the issue date.
        /// </summary>
        /// <value>
        /// The issue date.
        /// </value>
        public string IssueDate
        {
            get { return dateIssueDate.EditValue == null ? null : dateIssueDate.EditValue.ToString(); }
            set { dateIssueDate.EditValue = value == null ? (object)null : DateTime.Parse(value); }
        }

        /// <summary>
        /// Gets or sets the issue by.
        /// </summary>
        /// <value>
        /// The issue by.
        /// </value>
        public string IssueBy
        {
            get { return txtIssueBy.Text; }
            set { txtIssueBy.Text = value; }
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
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        public string Address
        {
            get { return txtAddress.Text; }
            set { txtAddress.Text = value; }
        }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        /// <value>
        /// The phone number.
        /// </value>
        public string PhoneNumber
        {
            get { return txtPhoneNumber.Text; }
            set { txtPhoneNumber.Text = value; }
        }

        /// <summary>
        /// Gets or sets the retire date.
        /// </summary>
        /// <value>
        /// The retire date.
        /// </value>
        public string RetiredDate
        {
            get { return dateRetiredDate.EditValue == null ? null : dateRetiredDate.EditValue.ToString(); }
            set { dateRetiredDate.EditValue = value == null ? (object)null : DateTime.Parse(value); }
        }

        /// <summary>
        /// Gets or sets the starting date.
        /// </summary>
        /// <value>
        /// The starting date.
        /// </value>
        public string StartingDate
        {
            get { return dateStartingDate.EditValue == null ? null : dateStartingDate.EditValue.ToString(); }
            set { dateStartingDate.EditValue = value == null ? (object)null : DateTime.Parse(value); }
        }

        /// <summary>
        /// Gets or sets the employee pay items.
        /// </summary>
        /// <value>
        /// The employee pay items.
        /// </value>
        public IList<EmployeePayItemModel> EmployeePayItems
        {
            get
            {
                var employeePayItems = new List<EmployeePayItemModel>();
                if (grdDetail.DataSource != null && gridViewDetail.DataRowCount > 0)
                {
                    for (var i = 0; i < gridViewDetail.DataRowCount; i++)
                    {
                        if (gridViewDetail.GetRow(i) != null)
                        {
                            employeePayItems.Add(new EmployeePayItemModel
                            {
                                PayItemId = (int)gridViewDetail.GetRowCellValue(i, "PayItemId"),
                                SalaryRatio = gridViewDetail.GetRowCellValue(i, "SalaryRatio") == null ? 0 : (float)gridViewDetail.GetRowCellValue(i, "SalaryRatio"),
                                Amount = (decimal)gridViewDetail.GetRowCellValue(i, "Amount")
                            });
                        }
                    }
                }
                return employeePayItems.ToList();
            }
            set
            {
                if (ActionMode == ActionModeEnum.AddNew)
                {
                    foreach (var payItemModel in _payItems)
                    {
                        //Thêm khoản lương mặc định được set trong danh mục
                        if (payItemModel.IsDefault)
                        {
                            const float salaryRatio = (float)1.0;
                            value.Add(new EmployeePayItemModel { PayItemId = payItemModel.PayItemId, SalaryRatio = salaryRatio, Amount = _dbOptionHelper.BaseOfSalary * (decimal)salaryRatio * _dbOptionHelper.CoefficientOfSalaryByArea });//AnhNT: fix chưa nhân với hệ số lương
                        }
                    }
                }
                bindingSourceDetail.DataSource = value;
                gridViewDetail.PopulateColumns(value);
                GridDetailLayout(GridDetailColumnOption(TypeOfSalary));
            }
        }

        #endregion

        #region Combobox

        public IList<DepartmentModel> Departments
        {
            set
            {
                _department = value.ToList();
                GridLookUpItem.Department(value ?? new List<DepartmentModel>(), grdLookUpEditDepartmentID, grdLookUpEditDepartmentIDView, "DepartmentName", "DepartmentId");
            }
        }

        /// <summary>
        /// Sets the pay items.
        /// </summary>
        /// <value>
        /// The pay items.
        /// </value>
        public IList<PayItemModel> PayItems
        {
            set
            {
                if (value == null) return;
                _payItems = value;

                GridLookUpItem.PayItem(value, RepositoryPayItemId, "PayItemName", "PayItemId");

                //RepositoryPayItemId.DataSource = value;
                //RepositoryPayItemId.PopulateColumns();
                //var gridColumnsCollection = new List<XtraColumn>
                //    {
                //        new XtraColumn {ColumnName = "PayItemId", ColumnVisible = false},
                //        new XtraColumn {ColumnName = "PayItemCode", ColumnCaption = "Mã khoản lương", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 120 },
                //        new XtraColumn {ColumnName = "PayItemName", ColumnCaption = "Tên khoản lương", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 250 },
                //        new XtraColumn {ColumnName = "Description", ColumnCaption = "Mô tả", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 150 },
                //        new XtraColumn {ColumnName = "Type", ColumnVisible = false},
                //        new XtraColumn {ColumnName = "IsCalculateRatio", ColumnVisible = false},
                //        new XtraColumn {ColumnName = "IsSocialInsurance", ColumnVisible = false},
                //        new XtraColumn {ColumnName = "IsCareInsurance", ColumnVisible = false},
                //        new XtraColumn {ColumnName = "IsTradeUnionFee", ColumnVisible = false},
                //        new XtraColumn {ColumnName = "DebitAccountCode", ColumnVisible = false},
                //        new XtraColumn {ColumnName = "CreditAccountCode", ColumnVisible = false},
                //        new XtraColumn {ColumnName = "BudgetChapterCode", ColumnVisible = false},
                //        new XtraColumn {ColumnName = "IsDefault", ColumnVisible = false},
                //        new XtraColumn {ColumnName = "IsActive", ColumnVisible = false},
                //        new XtraColumn {ColumnName = "BudgetSourceCode", ColumnVisible = false},
                //        new XtraColumn {ColumnName = "BudgetCategoryCode", ColumnVisible = false},
                //        new XtraColumn {ColumnName = "BudgetGroupCode", ColumnVisible = false},
                //        new XtraColumn {ColumnName = "BudgetItemCode", ColumnVisible = false}
                //    };

                //foreach (var column in gridColumnsCollection)
                //{
                //    if (column.ColumnVisible)
                //    {
                //        RepositoryPayItemId.Columns[column.ColumnName].Caption = column.ColumnCaption;
                //        RepositoryPayItemId.SortColumnIndex = column.ColumnPosition;
                //        RepositoryPayItemId.Columns[column.ColumnName].Width = column.ColumnWith;
                //    }
                //    else { RepositoryPayItemId.Columns[column.ColumnName].Visible = false; }
                //}
                //RepositoryPayItemId.DisplayMember = "PayItemName";
                //RepositoryPayItemId.ValueMember = "PayItemId";
            }
        }

        #endregion

        #region Repository Controls

        private RepositoryItemCalcEdit RepositorySalaryRatio { get; set; }
        private RepositoryItemCalcEdit RepositoryAmount { get; set; }
        private RepositoryItemGridLookUpEdit RepositoryPayItemId { get; set; }

        #endregion

        #region PopupMenu

        private void gridViewDetail_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            var view = sender as GridView;
            if (view != null)
            {
                var hitInfo = view.CalcHitInfo(e.Point);
                if (hitInfo.InRow)
                {
                    view.FocusedRowHandle = hitInfo.RowHandle;
                    popupMenu1.ShowPopup(grdDetail.PointToScreen(e.Point));
                }
            }
        }

        protected virtual void DeleteRowItem()
        {
            gridViewDetail.DeleteSelectedRows();
        }

        private void barButtonDeleteRowItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DeleteRowItem();
        }

        #endregion

        #region Function Overrides

        private IEnumerable<XtraColumn> GridDetailColumnOption(int typeOfSalary)
        {
            var gridColumnsCollection = new List<XtraColumn>
                {
                    new XtraColumn { ColumnName = "EmployeePayItemId", ColumnVisible = false },
                    new XtraColumn { ColumnName = "PayItemId", ColumnCaption = "Mã khoản lương", ColumnPosition = 1, ColumnVisible = true, ColumnWith = 120, RepositoryControl = RepositoryPayItemId },
                    typeOfSalary == 0
                        ? new XtraColumn { ColumnName = "SalaryRatio", ColumnCaption = "Hệ số lương", ColumnPosition = 2, ColumnVisible = true, ColumnWith = 120, RepositoryControl = RepositorySalaryRatio }
                        : new XtraColumn {ColumnName = "SalaryRatio", ColumnVisible = false},
                    new XtraColumn { ColumnName = "Amount", ColumnCaption = "Số tiền", ColumnPosition = 3, ColumnVisible = true, ColumnWith = 120, RepositoryControl = RepositoryAmount },
                    new XtraColumn {ColumnName = "EmployeeId", ColumnVisible = false}
                };


            return gridColumnsCollection;
        }

        private void GridDetailLayout(IEnumerable<XtraColumn> gridColumnsCollection)
        {
            foreach (var column in gridColumnsCollection)
            {
                if (column.ColumnVisible)
                {
                    gridViewDetail.Columns[column.ColumnName].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                    gridViewDetail.Columns[column.ColumnName].Caption = column.ColumnCaption;
                    gridViewDetail.Columns[column.ColumnName].VisibleIndex = column.ColumnPosition;
                    gridViewDetail.Columns[column.ColumnName].Width = column.ColumnWith;
                    gridViewDetail.Columns[column.ColumnName].ColumnEdit = column.RepositoryControl;
                }
                else gridViewDetail.Columns[column.ColumnName].Visible = false;
            }
        }

        protected override void InitControls()
        {
            grdDetail.ForceInitialize();
            RepositorySalaryRatio = new RepositoryItemCalcEdit();
            RepositoryAmount = new RepositoryItemCalcEdit();
            RepositoryPayItemId = new RepositoryItemGridLookUpEdit();

            RepositorySalaryRatio.Mask.MaskType = MaskType.Numeric;
            RepositorySalaryRatio.Mask.EditMask = @"f" + _dbOptionHelper.ExchangeRateDecimalDigits;
            RepositorySalaryRatio.Mask.UseMaskAsDisplayFormat = true;

            RepositoryAmount.Mask.MaskType = MaskType.Numeric;
            RepositoryAmount.Mask.EditMask = @"c" + int.Parse(_dbOptionHelper.CurrencyDecimalDigits);
            RepositoryAmount.Mask.Culture = new CultureInfo("vi-VN")
            {
                NumberFormat =
                {
                    CurrencySymbol = _dbOptionHelper.CurrencySymbol,
                    CurrencyDecimalSeparator = _dbOptionHelper.CurrencyDecimalSeparator,
                    CurrencyGroupSeparator = _dbOptionHelper.CurrencyGroupSeparator,
                    CurrencyDecimalDigits = int.Parse(_dbOptionHelper.CurrencyDecimalDigits)
                }
            };
            RepositoryAmount.Mask.UseMaskAsDisplayFormat = true;

            RepositoryPayItemId.NullText = ResourceHelper.GetResourceValueByName("ResRepositoryControlPayItemID");
        }

        protected override void InitData()
        {
            _departmentsPresenter.DisplayActive();
            _payItemsPresenter.DisplayActive();
            // _payItemsPresenter.DisplayActiveEdit();

            cboCurrencyCode.Properties.Items.Add(_globalVariable.CurrencyLocal);
            if (_globalVariable.CurrencyLocal != _globalVariable.CurrencyAccounting)
                cboCurrencyCode.Properties.Items.Add(_globalVariable.CurrencyAccounting);
            if (KeyValue != null)
                // _employeePresenter.Display(KeyValue);
                _employeePresenter.DisplayEdit(KeyValue);
            else
            {
                EmployeePayItems = new List<EmployeePayItemModel>();
                cboCurrencyCode.Text = _globalVariable.CurrencyCodeOfSalary;
                EmployeeCode = GetAutoNumber();
            }
        }

        protected override bool ValidData()
        {
            if (string.IsNullOrEmpty(EmployeeCode))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResEmployeeCode"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmployeeCode.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(EmployeeName))
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResEmployeeName"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmployeeName.Focus();
                return false;
            }
            if (DepartmentId == null)
            {
                XtraMessageBox.Show(ResourceHelper.GetResourceValueByName("ResEmployeeDepartment"), ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                grdLookUpEditDepartmentID.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(StartingDate))
            {
                XtraMessageBox.Show(@"Ngày nhận công tác không được phép để trống", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateStartingDate.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(RetiredDate))
            {
                XtraMessageBox.Show(@"Ngày hết nhiệm kỳ không được phép để trống", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateRetiredDate.Focus();
                return false;
            }

            if (SortOrder == 0)
            {
                XtraMessageBox.Show(@"Số thứ tự phải lớn hơn 0", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                spinSortOrder.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(JobCandidateName))
            {
                XtraMessageBox.Show(@"Chức vụ không được phép để trống", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtJobCandidateName.Focus();
                return false;
            }

            if (EmployeePayItems != null && EmployeePayItems.Count > 0)
            {
                foreach (var item in EmployeePayItems)
                {
                    if (item.PayItemId == 0)
                    {
                        XtraMessageBox.Show(@"Khoản lương không dc đê trống", ResourceHelper.GetResourceValueByName("ResDetailContent"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        gridViewDetail.Focus();
                        return false;
                    }
                }
            }

            return true;
        }

        protected override int SaveData()
        {
            gridViewDetail.CloseEditor();
            IdResult = _employeePresenter.Save();
            return IdResult;
        }

        #endregion

        #region Events

        public FrmXtraEmployeeDetail()
        {
            InitializeComponent();
            _dbOptionHelper = new GlobalVariable();
            _departmentsPresenter = new DepartmentsPresenter(this);
            _employeePresenter = new EmployeePresenter(this);
            _payItemsPresenter = new PayItemsPresenter(this);
            _globalVariable = new GlobalVariable();
        }

        private void gridViewDetail_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                var amountCol = gridViewDetail.Columns["Amount"];
                var salaryRatioCol = gridViewDetail.Columns["SalaryRatio"];
                var payItemIdCol = gridViewDetail.Columns["PayItemId"];
                float _float = 0;
                var amount = (decimal)gridViewDetail.GetRowCellValue(e.RowHandle, amountCol);
                var salaryRatio = TypeOfSalary == 0 ? (float.TryParse(gridViewDetail.GetRowCellValue(e.RowHandle, salaryRatioCol).ToString(), out _float) ? (float)gridViewDetail.GetRowCellValue(e.RowHandle, salaryRatioCol) : 0):0;
                var payItemId = (int)gridViewDetail.GetRowCellValue(e.RowHandle, payItemIdCol);
                if (amount < 0)
                {
                    e.Valid = false;
                    gridViewDetail.SetColumnError(amountCol, ResourceHelper.GetResourceValueByName("ResEmployeePayItemAmount"));
                }
                if (TypeOfSalary == 0)
                {
                    if (salaryRatio < 0)
                    {
                        e.Valid = false;
                        gridViewDetail.SetColumnError(salaryRatioCol, ResourceHelper.GetResourceValueByName("ResEmployeePayItemSalaryRatio"));
                    }
                }
                else if (payItemId <= 0)
                {
                    e.Valid = false;
                    gridViewDetail.SetColumnError(payItemIdCol, ResourceHelper.GetResourceValueByName("ResEmployeePayItemPayItemID"));
                }
                else
                {
                    if (EmployeePayItems.Count <= 1) return;
                    var samePayItem = true;
                    for (var i = 0; i < EmployeePayItems.Count; i++)
                    {
                        for (var j = i + 1; j < EmployeePayItems.Count; j++)
                        {
                            if (EmployeePayItems[i].PayItemId != EmployeePayItems[j].PayItemId)
                                samePayItem = false;
                            else
                            {
                                samePayItem = true;
                                break;
                            }
                        }
                        if (!samePayItem) continue;
                        e.Valid = false;
                        gridViewDetail.SetColumnError(payItemIdCol, ResourceHelper.GetResourceValueByName("ResEmployeePayItemPayItemIDSame"));
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(),
                    ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridViewDetail_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void cboTypeOfSalary_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gridViewDetail.Columns.Count == 0) return;
            GridDetailLayout(GridDetailColumnOption(cboTypeOfSalary.SelectedIndex));
        }

        private void grdLookUpEditDepartmentID_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (grdLookUpEditDepartmentID.SelectionLength == grdLookUpEditDepartmentID.Text.Length && (e.KeyData == Keys.Back || e.KeyData == Keys.Delete))
                {
                    grdLookUpEditDepartmentID.EditValue = null;
                    e.Handled = true;
                }
                if (e.KeyData == Keys.Down)
                {
                    grdLookUpEditDepartmentID.EditValue = GetValueDepartment(true);
                }
                if (e.KeyData == Keys.Up)
                {
                    grdLookUpEditDepartmentID.EditValue = GetValueDepartment(false);
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Chọn phòng ban khi bấm up down
        /// </summary>
        /// <param name="isdown"></param>
        /// <returns></returns>
        private int GetValueDepartment(bool isdown)
        {
            if (_department != null)
            {
                if (_department.Count > 0)
                {
                    //Chưa chọn => trả về giá trị đầu tiên
                    if (grdLookUpEditDepartmentID.EditValue == null)
                        return _department[0].DepartmentId;

                    //Lấy giá trị đang chọn
                    var curent = _department.Find(x => x.DepartmentId == (int)grdLookUpEditDepartmentID.EditValue);

                    //Lấy index đang chọn
                    var index = _department.FindIndex(x => x.DepartmentId == curent.DepartmentId);

                    if (isdown)//Nhấn down
                    {
                        if (index >= _department.Count - 1)
                            return _department[index].DepartmentId;
                        else
                            return _department[index + 1].DepartmentId;
                    }
                    else//Nhấn up
                    {
                        if (index <= 0)
                            return _department[index].DepartmentId;
                        else
                            return _department[index - 1].DepartmentId;
                    }
                }
                return -1;
            }
            return -1;
        }

        private void gridViewDetail_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                var rowHandler = e.RowHandle;
                var amountCol = gridViewDetail.Columns["Amount"];
                var salaryRatioCol = gridViewDetail.Columns["SalaryRatio"];

                var beforeAmount = Convert.ToDecimal(gridViewDetail.GetRowCellValue(rowHandler, amountCol));
                var beforeSalaryRatio = Convert.ToDecimal(gridViewDetail.GetRowCellValue(rowHandler, salaryRatioCol));

                if (e.Column.Name == "colSalaryRatio")
                {
                    var amount = decimal.Parse(e.Value.ToString()) * _dbOptionHelper.BaseOfSalary * _dbOptionHelper.CoefficientOfSalaryByArea;
                    if (beforeAmount != amount)
                    {
                        gridViewDetail.SetRowCellValue(rowHandler, amountCol, amount);
                    }
                }
                if (e.Column.Name == "colAmount")
                {
                    var salaryRatio = decimal.Parse(e.Value.ToString()) / (_dbOptionHelper.BaseOfSalary * _dbOptionHelper.CoefficientOfSalaryByArea);
                    if (beforeSalaryRatio != salaryRatio)
                    {
                        gridViewDetail.SetRowCellValue(rowHandler, salaryRatioCol, salaryRatio);
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.ToString(),
                    ResourceHelper.GetResourceValueByName("ResExceptionCaption"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grdLookUpEditDepartmentID_EditValueChanged(object sender, EventArgs e)
        {
            txtAddress.Text = grdLookUpEditDepartmentID.Text;
        }

        private void grdLookUpEditDepartmentID_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Plus)
            {
                using (var frmDetail = new FrmXtraDepartmentDetail())
                {
                    frmDetail.ActionMode = ActionModeEnum.AddNew;
                    if (frmDetail.ShowDialog() == DialogResult.OK)
                    {
                        _departmentsPresenter.DisplayActive();

                        var lstDetails = grdLookUpEditDepartmentID.Properties.DataSource as List<DepartmentModel>;
                        if (lstDetails != null)
                        {
                            grdLookUpEditDepartmentID.EditValue = lstDetails.OrderByDescending(o => o.DepartmentId).FirstOrDefault().DepartmentId;
                        }
                    }
                }
            }
        }

        #endregion
    }
}
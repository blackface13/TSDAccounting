/***********************************************************************
 * <copyright file="FrmXtraConvertFoxproData.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Tuesday, May 27, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using TSD.AccountingSoft.Model;
using TSD.AccountingSoft.Model.BusinessObjects.Cash;
using TSD.AccountingSoft.Model.BusinessObjects.Deposit;
using TSD.AccountingSoft.Model.BusinessObjects.Dictionary;
using TSD.AccountingSoft.Model.BusinessObjects.FixedAsset;
using TSD.AccountingSoft.Model.BusinessObjects.General;
using TSD.AccountingSoft.Model.BusinessObjects.Inventory;
using TSD.AccountingSoft.WindowsForm.CommonClass;
using TSD.AccountingSoft.WindowsForm.Resources;
using DevExpress.XtraEditors;
using TSD.AccountingSoft.Model.BusinessObjects.Opening;
using TSD.AccountingSoft.View.Dictionary;
using TSD.AccountingSoft.Presenter.Dictionary.AutoNumber;

namespace TSD.AccountingSoft.WindowsForm.FormSystem
{
    /// <summary>
    /// Using for convert foxpro database to MSSQL
    /// </summary>
    public partial class FrmXtraConvertFoxproData : XtraForm, IAutoNumberView
    {
        protected static IModel Model;
        private readonly AutoNumberPresenter _autoNumberPresenter;
        private DataSet _convertData;

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

        #region Methods

        /// <summary>
        /// Gets the name of the table.
        /// </summary>
        private void GetTableName()
        {
            if (btnSelectFile.Text.Trim() == string.Empty) return;
            var filenames =
                Directory.GetFiles(
                    Path.GetFullPath(btnSelectFile.Text).Replace(Path.GetFileName(btnSelectFile.Text), ""), "*.DBF");
            foreach (var filename in filenames)
            {
                if (filename != null) lstTableName.Items.Add(Path.GetFileNameWithoutExtension(filename));
            }
        }

        /// <summary>
        /// Imports the specified table name.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        private void Import(string tableName)
        {
            if (btnSelectFile.Text.Trim() == string.Empty) return;
            try
            {
                var oleDbHelper = new OleDbHelper(btnSelectFile.Text);
                var dt = oleDbHelper.GetAllColumnDataTableDBF(tableName);
                gridDetailData.DataSource = null;
                gridDetailData.DataSource = dt.DefaultView;
                gridDetailDataView.PopulateColumns();
                gridDetailData.ForceInitialize();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <param name="queryString">Name of the table.</param>
        /// <returns></returns>
        private DataTable GetData(string queryString)
        {
            try
            {
                var oleDbHelper = new OleDbHelper(btnSelectFile.Text);
                var dt = oleDbHelper.GetDataTableDBF(queryString);
                return dt;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Initializes the identifier.
        /// </summary>
        /// <param name="dataTable">The data table.</param>
        private static void InitId(ref DataTable dataTable)
        {
            for (var i = 0; i < dataTable.Rows.Count; i++)
            {
                dataTable.Rows[i]["ID"] = i + 1;
            }
        }

        /// <summary>
        /// Initializes the parent.
        /// </summary>
        /// <param name="dataTable">The data table.</param>
        private static void InitParent(ref DataTable dataTable)
        {
            for (var i = 0; i < dataTable.Rows.Count; i++)
            {
                var code = dataTable.Rows[i][0].ToString();
                var id = dataTable.Rows[i]["ID"].ToString();
                for (var j = 0; j < dataTable.Rows.Count; j++)
                {
                    if (dataTable.Rows[j]["parentid"].ToString() == code)
                    {
                        dataTable.Rows[j]["PID"] = id;
                    }
                }
            }
        }

        /// <summary>
        /// Generateds the base reference no.
        /// </summary>
        /// <returns></returns>
        private string GeneratedBaseRefNo(int refTypeId)
        {
            //lay ra ma so voucher theo reftype
            var refNo = "";
            _autoNumberPresenter.DisplayByRefType(refTypeId);
            if (!String.IsNullOrEmpty(Prefix))
                refNo += Prefix;
            if (Value >= 0)
            {
                for (var i = 0; i < (LengthOfValue - Value.ToString(CultureInfo.InvariantCulture).Length); i++)
                    refNo += "0";
                refNo += (Value + 1);
            }
            if (!String.IsNullOrEmpty(Suffix))
                refNo += Suffix;
            return refNo;
        }

        /// <summary>
        /// Converts the font.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <param name="convertFields">The convert fields.</param>
        /// <returns></returns>
        private static void ConvertFontData(ref DataTable table, string convertFields)
        {
            var fields = convertFields.Split(';');
            if (fields.Length > 0 && fields[0] != "")
            {
                foreach (var field in fields)
                {
                    for (var i = 0; i < table.Rows.Count; i++)
                    {
                        table.Rows[i][field] = ConvertFont.TCVN3ToUnicode(table.Rows[i][field].ToString());
                    }
                }
            }
        }

        /// <summary>
        /// Updates the option.
        /// </summary>
        /// <returns></returns>
        private bool UpdateOption(object createdDate)
        {
            var dbOptionList = new List<DBOptionModel>();
            const string sql =
                "SELECT dbid, dbvalue, datatype FROM DbInfo WHERE dbid IN " +
                "('cOfficeDirec','cOfficeChief','cOfficeCashier','cOfficeBookKeeper','cOfficeStock','cDirector','cChiefOfAccountant','cCashier'," +
                "'cStockKeeper','cBookKeeper','cLocalCCY','cSalaryCCY','cCompanyID','dSystemDate','dStartDate','dBeginningDate','cInventoriedPosition1'," +
                "'cInventoriedPosition2','cInventoriedPosition3','cInventoriedName1','cInventoriedName2','cInventoriedName3','cTranslationalCCY')";
            var dtOption = GetData(sql);
            if (dtOption != null && dtOption.Rows.Count > 0)
            {
                dtOption.PrimaryKey = new[] { dtOption.Columns["dbid"] };
                ConvertFontData(ref dtOption, "dbvalue");
                var value = dtOption.Rows.Find("cOfficeDirec")["dbvalue"];
                DBOptionModel dbOptionModel;
                if (value != null)
                {
                    dbOptionModel = new DBOptionModel
                    {
                        OptionId = "JobTitleCompanyDirector",
                        OptionValue = value.ToString().TrimEnd(),
                        IsSystem = false,
                        Description = "Chức danh thủ trưởng đơn vị",
                        ValueType = 0
                    };
                    dbOptionList.Add(dbOptionModel);
                }
                value = dtOption.Rows.Find("cOfficeChief")["dbvalue"];
                if (value != null)
                {
                    dbOptionModel = new DBOptionModel
                    {
                        OptionId = "JobTitleCompanyAccountant",
                        OptionValue = value.ToString().TrimEnd(),
                        IsSystem = false,
                        Description = "Chức danh kế toán trưởng",
                        ValueType = 0
                    };
                    dbOptionList.Add(dbOptionModel);
                }
                value = dtOption.Rows.Find("cOfficeCashier")["dbvalue"];
                if (value != null)
                {
                    dbOptionModel = new DBOptionModel
                    {
                        OptionId = "JobTitleCompanyCashier",
                        OptionValue = value.ToString().TrimEnd(),
                        IsSystem = false,
                        Description = "Chức danh thủ quỹ",
                        ValueType = 0
                    };
                    dbOptionList.Add(dbOptionModel);
                }
                value = dtOption.Rows.Find("cOfficeBookKeeper")["dbvalue"];
                if (value != null)
                {
                    dbOptionModel = new DBOptionModel
                    {
                        OptionId = "JobTitleCompanyReportPreparer",
                        OptionValue = value.ToString().TrimEnd(),
                        IsSystem = false,
                        Description = "Chức danh lập báo cáo",
                        ValueType = 0
                    };
                    dbOptionList.Add(dbOptionModel);
                }
                value = dtOption.Rows.Find("cOfficeStock")["dbvalue"];
                if (value != null)
                {
                    dbOptionModel = new DBOptionModel
                    {
                        OptionId = "JobTitleCompanyStoreKeeper",
                        OptionValue = value.ToString().TrimEnd(),
                        IsSystem = false,
                        Description = "Chức danh thủ kho",
                        ValueType = 0
                    };
                    dbOptionList.Add(dbOptionModel);
                }
                value = dtOption.Rows.Find("cDirector")["dbvalue"];
                if (value != null)
                {
                    dbOptionModel = new DBOptionModel
                    {
                        OptionId = "CompanyDirector",
                        OptionValue = value.ToString().TrimEnd(),
                        IsSystem = false,
                        Description = "Thủ trưởng đơn vị",
                        ValueType = 0
                    };
                    dbOptionList.Add(dbOptionModel);
                }
                value = dtOption.Rows.Find("cChiefOfAccountant")["dbvalue"];
                if (value != null)
                {
                    dbOptionModel = new DBOptionModel
                    {
                        OptionId = "CompanyAccountant",
                        OptionValue = value.ToString().TrimEnd(),
                        IsSystem = false,
                        Description = "Kế toán trưởng",
                        ValueType = 0
                    };
                    dbOptionList.Add(dbOptionModel);
                }
                value = dtOption.Rows.Find("cCashier")["dbvalue"];
                if (value != null)
                {
                    dbOptionModel = new DBOptionModel
                    {
                        OptionId = "CompanyCashier",
                        OptionValue = value.ToString().TrimEnd(),
                        IsSystem = false,
                        Description = "Thủ quỹ",
                        ValueType = 0
                    };
                    dbOptionList.Add(dbOptionModel);
                }
                value = dtOption.Rows.Find("cStockKeeper")["dbvalue"];
                if (value != null)
                {
                    dbOptionModel = new DBOptionModel
                    {
                        OptionId = "CompanyStoreKeeper",
                        OptionValue = value.ToString().TrimEnd(),
                        IsSystem = false,
                        Description = "Thủ kho",
                        ValueType = 0,
                    };
                    dbOptionList.Add(dbOptionModel);
                }
                value = dtOption.Rows.Find("cBookKeeper")["dbvalue"];
                if (value != null)
                {
                    dbOptionModel = new DBOptionModel
                    {
                        OptionId = "CompanyReportPreparer",
                        OptionValue = value.ToString().TrimEnd(),
                        IsSystem = false,
                        Description = "Người ghi sổ",
                        ValueType = 0,
                    };
                    dbOptionList.Add(dbOptionModel);
                }
                value = dtOption.Rows.Find("cLocalCCY")["dbvalue"];
                if (value != null)
                {
                    dbOptionModel = new DBOptionModel
                    {
                        OptionId = "CurrencyLocal",
                        OptionValue = value.ToString().TrimEnd(),
                        IsSystem = false,
                        Description = "Tiền địa phương",
                        ValueType = 0,
                    };
                    dbOptionList.Add(dbOptionModel);
                }
                value = dtOption.Rows.Find("cSalaryCCY")["dbvalue"];
                if (value != null)
                {
                    dbOptionModel = new DBOptionModel
                    {
                        OptionId = "CurrencyCodeOfSalary",
                        OptionValue = value.ToString().TrimEnd(),
                        IsSystem = false,
                        Description = "Tiền trả lương",
                        ValueType = 0,
                    };
                    dbOptionList.Add(dbOptionModel);
                }
                value = dtOption.Rows.Find("cCompanyID")["dbvalue"];
                if (value != null)
                {
                    dbOptionModel = new DBOptionModel
                    {
                        OptionId = "CompanyCode",
                        OptionValue = value.ToString().TrimEnd(),
                        IsSystem = false,
                        Description = "Mã đơn vị",
                        ValueType = 0,
                    };
                    dbOptionList.Add(dbOptionModel);
                }
                value = dtOption.Rows.Find("dSystemDate")["dbvalue"];
                if (value != null)
                {
                    dbOptionModel = new DBOptionModel
                    {
                        OptionId = "PostedDate",
                        OptionValue = value.ToString().TrimEnd(),
                        IsSystem = false,
                        Description = "Ngày hạch toán",
                        ValueType = 2,
                    };
                    dbOptionList.Add(dbOptionModel);
                }
                value = createdDate ?? dtOption.Rows.Find("dStartDate")["dbvalue"];
                if (value != null)
                {
                    dbOptionModel = new DBOptionModel
                    {
                        OptionId = "SystemDate",
                        OptionValue = value.ToString().TrimEnd(),
                        IsSystem = false,
                        Description = "Ngày bắt đầu hạch toán",
                        ValueType = 2,
                    };
                    dbOptionList.Add(dbOptionModel);
                }
                value = dtOption.Rows.Find("dBeginningDate")["dbvalue"];
                if (value != null)
                {
                    dbOptionModel = new DBOptionModel
                    {
                        OptionId = "StartedDate",
                        OptionValue = value.ToString().TrimEnd(),
                        IsSystem = false,
                        Description = "Ngày đầu năm tài chính",
                        ValueType = 2,
                    };
                    dbOptionList.Add(dbOptionModel);
                }
                value = dtOption.Rows.Find("cInventoriedPosition1")["dbvalue"];
                if (value != null)
                {
                    dbOptionModel = new DBOptionModel
                    {
                        OptionId = "JobOfInventory1",
                        OptionValue = value.ToString().TrimEnd(),
                        IsSystem = false,
                        Description = "Chức vụ người kiểm kê 1",
                        ValueType = 0,
                    };
                    dbOptionList.Add(dbOptionModel);
                }
                value = dtOption.Rows.Find("cInventoriedPosition2")["dbvalue"];
                if (value != null)
                {
                    dbOptionModel = new DBOptionModel
                    {
                        OptionId = "JobOfInventory2",
                        OptionValue = value.ToString().TrimEnd(),
                        IsSystem = false,
                        Description = "Chức vụ người kiểm kê 2",
                        ValueType = 0,
                    };
                    dbOptionList.Add(dbOptionModel);
                }
                value = dtOption.Rows.Find("cInventoriedPosition3")["dbvalue"];
                if (value != null)
                {
                    dbOptionModel = new DBOptionModel
                    {
                        OptionId = "JobOfInventory3",
                        OptionValue = value.ToString().TrimEnd(),
                        IsSystem = false,
                        Description = "Chức vụ người kiểm kê 3",
                        ValueType = 0,
                    };
                    dbOptionList.Add(dbOptionModel);
                }
                value = dtOption.Rows.Find("cInventoriedName1")["dbvalue"];
                if (value != null)
                {
                    dbOptionModel = new DBOptionModel
                    {
                        OptionId = "NameOfInventory1",
                        OptionValue = value.ToString().TrimEnd(),
                        IsSystem = false,
                        Description = "Tên người kiểm kê 1",
                        ValueType = 0,
                    };
                    dbOptionList.Add(dbOptionModel);
                }
                value = dtOption.Rows.Find("cInventoriedName2")["dbvalue"];
                if (value != null)
                {
                    dbOptionModel = new DBOptionModel
                    {
                        OptionId = "NameOfInventory2",
                        OptionValue = value.ToString().TrimEnd(),
                        IsSystem = false,
                        Description = "Tên người kiểm kê 2",
                        ValueType = 0,
                    };
                    dbOptionList.Add(dbOptionModel);
                }
                value = dtOption.Rows.Find("cInventoriedName3")["dbvalue"];
                if (value != null)
                {
                    dbOptionModel = new DBOptionModel
                    {
                        OptionId = "NameOfInventory3",
                        OptionValue = value.ToString().TrimEnd(),
                        IsSystem = false,
                        Description = "Tên người kiểm kê 3",
                        ValueType = 0,
                    };
                    dbOptionList.Add(dbOptionModel);
                }
                value = dtOption.Rows.Find("cTranslationalCCY")["dbvalue"];
                if (value != null)
                {
                    dbOptionModel = new DBOptionModel
                    {
                        OptionId = "TransactionalCurrency",
                        OptionValue = value.ToString().TrimEnd(),
                        IsSystem = false,
                        Description = "Tiền ngoại tệ qui đổi",
                        ValueType = 0
                    };
                    dbOptionList.Add(dbOptionModel);
                }
            }

            var rel = Model.UpdateDBOption(dbOptionList);
            if (rel == null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Completes the convert.
        /// </summary>
        /// <returns></returns>
        private bool CompleteConvert()
        {
            string destinationTableName = "";
            try
            {
                progressBarControl.Properties.Step = 1;
                progressBarControl.Properties.PercentView = true;
                progressBarControl.Properties.Maximum = lstConvertTable.Items.Count;
                progressBarControl.Properties.Minimum = 0;
                Cursor.Current = Cursors.WaitCursor;
                if (_convertData == null) return false;
                if (_convertData.Tables[0].Rows.Count <= 0) return false;

                for (var i = 0; i < lstConvertTable.Items.Count; i++)
                {
                    if (i == 0)
                    {
                        //Cập nhật lại một số thông tin trong bảng DbOption
                        if (!UpdateOption(null))
                        {
                            XtraMessageBox.Show("Cập nhật thông tin dữ liệu bị lỗi!", "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            return false;
                        }
                    }

                    //0. Kiểm tra Option {0- Không tổng hợp, 1-Tổng hợp toàn bộ từ cũ vào mới}
                    //1. Lấy dữ liệu từ foxpro
                    //2. Chuyển đổi font chữ TCVN3 -> UNICODE
                    //3. Insert data vào MSSQL
                    var tableName = lstConvertTable.Items[i].ToString();
                    string queryString;
                    if (!string.IsNullOrEmpty(tableName))
                        queryString = "SELECT " + _convertData.Tables[0].Rows[i]["SourceField"] + " FROM " +
                                      tableName;
                    else
                        queryString = "SELECT " + _convertData.Tables[0].Rows[i]["SourceField"];

                    var whereClause = _convertData.Tables[0].Rows[i]["WhereClause"].ToString();
                    if (!string.IsNullOrEmpty(whereClause))
                        queryString = queryString + " WHERE " + whereClause;
                    var convertFields = _convertData.Tables[0].Rows[i]["SourceFieldConvertFont"].ToString();
                    var oldParent = int.Parse(_convertData.Tables[0].Rows[i]["OldParent"].ToString());
                    var newParent = int.Parse(_convertData.Tables[0].Rows[i]["NewParent"].ToString());
                    var oldActive = int.Parse(_convertData.Tables[0].Rows[i]["OldActive"].ToString());
                    var newActive = int.Parse(_convertData.Tables[0].Rows[i]["NewActive"].ToString());
                    var option = int.Parse(_convertData.Tables[0].Rows[i]["Option"].ToString());
                    if (option == 0) continue;

                    var dt = GetData(queryString);

                    if (dt == null || dt.Rows.Count <= 0) continue;
                    if (oldParent != newParent)
                    {
                        dt.Columns.Add("ID", typeof(int));
                        dt.Columns.Add("PID", typeof(int));
                        InitId(ref dt);
                        InitParent(ref dt);
                    }

                    ConvertFontData(ref dt, convertFields);
                    destinationTableName = _convertData.Tables[0].Rows[i]["DestinationTable"].ToString();
                    switch (destinationTableName)
                    {
                        #region Dictionaries

                        case "Department":
                            //Check data existed
                            if (Model.GetDepartments().Count > 0)
                            {
                                break;
                            }
                            Model.ResetAutoIncrement("Department", 0);
                            for (var j = 0; j < dt.Rows.Count; j++)
                            {
                                var department = new DepartmentModel
                                {
                                    DepartmentId = int.Parse(dt.Rows[j]["ID"].ToString()),
                                    DepartmentCode = dt.Rows[j]["departid"].ToString().Trim(),
                                    DepartmentName = dt.Rows[j]["departname"].ToString().TrimEnd(),
                                    ParentId =
                                        dt.Rows[j]["PID"].ToString().Trim() == "" ? null : (int?)dt.Rows[j]["PID"],
                                    Description = dt.Rows[j]["note"].ToString().Trim(),
                                    IsActive = dt.Rows[j]["inactive"] != null && (bool)dt.Rows[j]["inactive"],
                                };
                                if (oldActive != newActive)
                                {
                                    var o = dt.Rows[j]["inactive"];
                                    if (o != null)
                                        department.IsActive = !(bool)o;
                                }
                                Model.AddDepartment(department);
                            }

                            break;
                        case "Employee":
                            //Check data existed
                            if (Model.GetEmployees().Count > 0)
                            {
                                break;
                            }
                            for (var j = 0; j < dt.Rows.Count; j++)
                            {
                                string selectClaus = "SELECT * FROM EMPLOYEESETUP WHERE employeeid = '" +
                                                     dt.Rows[j]["employeeid"].ToString().Trim() + "'";
                                var dtEmployeePayItem = GetData(selectClaus);
                                var employeePayItems = new List<EmployeePayItemModel>();

                                var employee = new EmployeeModel
                                {
                                    EmployeeId =
                                        (oldParent != newParent) ? int.Parse(dt.Rows[j]["ID"].ToString()) : 0,
                                    EmployeeCode = dt.Rows[j]["employeeid"].ToString().Trim(),
                                    EmployeeName = dt.Rows[j]["employeename"].ToString().TrimEnd(),
                                    JobCandidateName =
                                        (dt.Rows[j]["position"] != null)
                                            ? dt.Rows[j]["position"].ToString().Trim()
                                            : "",
                                    SortOrder = int.Parse(dt.Rows[j]["orders"].ToString()),
                                    BirthDate = null,
                                    TypeOfSalary =
                                        (dt.Rows[j]["payrolltype"] != null)
                                            ? int.Parse(dt.Rows[j]["payrolltype"].ToString()) - 1
                                            : 0,
                                    Sex = (dt.Rows[j]["sex"] == null || dt.Rows[j]["sex"].ToString().Trim() != "2"),
                                    LevelOfSalary =
                                        (dt.Rows[j]["scale"] != null) ? dt.Rows[j]["scale"].ToString().Trim() : null,
                                    DepartmentId =
                                        Model.GetIdByCode("Department", "DepartmentID", "DepartmentCode",
                                            dt.Rows[j]["departid"].ToString().Trim()),
                                    CurrencyCode =
                                        (dt.Rows[j]["ccyid"] != null) ? dt.Rows[j]["ccyid"].ToString().Trim() : null,
                                    IdentityNo =
                                        (dt.Rows[j]["icn"] != null) ? dt.Rows[j]["icn"].ToString().TrimEnd() : null,
                                    IssueDate = null,
                                    IssueBy =
                                        (dt.Rows[j]["issueat"] != null)
                                            ? dt.Rows[j]["issueat"].ToString().TrimEnd()
                                            : null,
                                    IsActive =
                                        oldActive != newActive
                                            ? !(bool)dt.Rows[j]["inactive"]
                                            : (bool)dt.Rows[j]["inactive"],
                                    Description = "",
                                    Address =
                                        (dt.Rows[j]["address"] != null)
                                            ? dt.Rows[j]["address"].ToString().TrimEnd()
                                            : null,
                                    PhoneNumber =
                                        (dt.Rows[j]["tel"] != null) ? dt.Rows[j]["tel"].ToString().TrimEnd() : null,
                                    EmployeePayItems = employeePayItems
                                };
                                Model.AddEmployee(employee);

                                var employeeId = Model.GetIdByCode("Employee", "EmployeeID", "EmployeeCode",
                                    dt.Rows[j]["employeeid"].ToString().Trim());


                                for (var k = 0; k < dtEmployeePayItem.Rows.Count; k++)
                                {
                                    var value = Model.GetIdByCode("PayItem", "PayItemID", "PayItemCode",
                                        dtEmployeePayItem.Rows[k]["employeepayitemid"].ToString().Trim());
                                    employeePayItems.Add(new EmployeePayItemModel
                                    {
                                        EmployeeId = (int)employeeId,
                                        PayItemId = (int)value,
                                        Amount = (decimal)dtEmployeePayItem.Rows[k]["amount"],
                                        SalaryRatio = float.Parse(dtEmployeePayItem.Rows[k]["rate"].ToString())
                                    });
                                }

                                employee.EmployeeId = (int)employeeId;
                                employee.EmployeePayItems = employeePayItems;
                                Model.UpdateEmployee(employee);
                            }
                            break;
                        case "Vendor":
                            //Check data existed
                            if (Model.GetVendors().Count > 0)
                            {
                                break;
                            }
                            for (var j = 0; j < dt.Rows.Count; j++)
                            {
                                var vendor = new VendorModel
                                {
                                    VendorCode = dt.Rows[j]["vendorid"].ToString().Trim(),
                                    VendorName = dt.Rows[j]["vendorname"].ToString().TrimEnd(),
                                    Address =
                                        (dt.Rows[j]["vendoraddress"] != null)
                                            ? dt.Rows[j]["vendoraddress"].ToString().TrimEnd()
                                            : null,
                                    ContactName =
                                        (dt.Rows[j]["contactname"] != null)
                                            ? dt.Rows[j]["contactname"].ToString().TrimEnd()
                                            : null,
                                    ContactRegency =
                                        (dt.Rows[j]["contactaddress"] != null)
                                            ? dt.Rows[j]["contactaddress"].ToString().TrimEnd()
                                            : null,
                                    Phone =
                                        (dt.Rows[j]["tel"] != null) ? dt.Rows[j]["tel"].ToString().TrimEnd() : null,
                                    Mobile =
                                        (dt.Rows[j]["mobifone"] != null)
                                            ? dt.Rows[j]["mobifone"].ToString().TrimEnd()
                                            : null,
                                    Fax = dt.Rows[j]["fax"].ToString().TrimEnd(),
                                    Email = dt.Rows[j]["email"].ToString().TrimEnd(),
                                    TaxCode = dt.Rows[j]["vendortaxcode"].ToString().TrimEnd(),
                                    Website = dt.Rows[j]["website"].ToString().TrimEnd(),
                                    Province = dt.Rows[j]["state"].ToString().TrimEnd(),
                                    City = dt.Rows[j]["city"].ToString().TrimEnd(),
                                    ZipCode = dt.Rows[j]["zip"].ToString().TrimEnd(),
                                    Area = dt.Rows[j]["areaid"].ToString().TrimEnd(),
                                    Country = dt.Rows[j]["country"].ToString().TrimEnd(),
                                    BankNumber = dt.Rows[j]["bankaccount"].ToString().TrimEnd(),
                                    IsActive = dt.Rows[j]["inactive"] != null && (bool)dt.Rows[j]["inactive"],
                                };
                                if (oldActive != newActive) vendor.IsActive = !(bool)dt.Rows[j]["inactive"];
                                Model.InsertVendor(vendor);
                            }
                            break;

                        #region Append data

                        case "AccountingObject":
                            if (Model.GetAccountingObjects().Count > 14)
                            {
                                break;
                            }
                            for (var j = 0; j < dt.Rows.Count; j++)
                            {
                                var accountingObject = new AccountingObjectModel
                                {
                                    AccountingObjectCategoryId = dt.Rows[j]["objecttype"] == null ? 0 : int.Parse(dt.Rows[j]["objecttype"].ToString()),
                                    AccountingObjectCode = dt.Rows[j]["objectid"].ToString().Trim(),
                                    FullName = dt.Rows[j]["objectname"] == null ? "" : dt.Rows[j]["objectname"].ToString().TrimEnd(),
                                    Address = dt.Rows[j]["objectaddress"] == null ? "" : dt.Rows[j]["objectaddress"].ToString().TrimEnd(),
                                    TaxCode = dt.Rows[j]["objecttaxcode"] == null ? "" : dt.Rows[j]["objecttaxcode"].ToString().TrimEnd(),
                                    BankAcount = dt.Rows[j]["bankaccount"] == null ? "" : dt.Rows[j]["bankaccount"].ToString().TrimEnd(),
                                    ContactName = dt.Rows[j]["contactname"] == null ? "" : dt.Rows[j]["contactname"].ToString().TrimEnd(),
                                    ContactAddress = dt.Rows[j]["contactaddress"] == null ? "" : dt.Rows[j]["contactaddress"].ToString().TrimEnd(),
                                    ContactIdNumber = dt.Rows[j]["contacticn"] == null ? "" : dt.Rows[j]["contacticn"].ToString().TrimEnd(),
                                    IssueDate = null,
                                    IssueAddress = dt.Rows[j]["contactissueat"] == null ? "" : dt.Rows[j]["contactissueat"].ToString().TrimEnd(),
                                    IsActive = dt.Rows[j]["inactive"] != null && (bool)dt.Rows[j]["inactive"],
                                };
                                if (oldActive != newActive)
                                    accountingObject.IsActive = !(bool)dt.Rows[j]["inactive"];
                                Model.InsertAccountingObject(accountingObject);
                            }
                            break;
                        case "Stock":
                            if (Model.GetStocks().Count > 3)
                            {
                                break;
                            }
                            for (var j = 0; j < dt.Rows.Count; j++)
                            {
                                var stock = new StockModel
                                {
                                    StockCode = dt.Rows[j]["stockid"].ToString().Trim(),
                                    StockName = dt.Rows[j]["stockname"].ToString().TrimEnd(),
                                    Description = dt.Rows[j]["note"].ToString().TrimEnd(),
                                    IsActive = dt.Rows[j]["inactive"] != null && (bool)dt.Rows[j]["inactive"],
                                };
                                if (oldActive != newActive) stock.IsActive = !(bool)dt.Rows[j]["inactive"];
                                Model.InsertStock(stock);
                            }
                            break;
                        case "InventoryItem":
                            if (Model.GetInventoryItems().Count > 25)
                            {
                                break;
                            }
                            for (var j = 0; j < dt.Rows.Count; j++)
                            {
                                var inventoryItem = new InventoryItemModel
                                {
                                    InventoryItemCode = dt.Rows[j]["itemid"].ToString().Trim(),
                                    InventoryItemName = dt.Rows[j]["itemname"].ToString().TrimEnd(),
                                    AccountCode = dt.Rows[j]["inventoryaccount"].ToString().TrimEnd(),
                                    Unit = dt.Rows[j]["unit"].ToString().TrimEnd(),
                                    CurrencyCode = dt.Rows[j]["ccyid"].ToString().Trim(),
                                    CostMethod = int.Parse(dt.Rows[j]["costmethod"].ToString().TrimEnd()),
                                    IsActive = dt.Rows[j]["inactive"] != null && (bool)dt.Rows[j]["inactive"],
                                };
                                if (oldActive != newActive) inventoryItem.IsActive = !(bool)dt.Rows[j]["inactive"];
                                Model.InsertInventoryItem(inventoryItem);
                            }
                            break;

                        #endregion

                        case "FixedAsset":
                            if (Model.GetAllFixedAssetsWithStoreProdure("uspGet_All_FixedAsset").Count > 0)
                            {
                                break;
                            }
                            for (var j = 0; j < dt.Rows.Count; j++)
                            {
                                var fixedAssetCurrency = new FixedAssetCurrencyModel
                                {
                                    CurrencyCode = dt.Rows[j]["ccyid"].ToString().Trim(),
                                    AccumDepreciationAmount = decimal.Parse(dt.Rows[j]["accdep"].ToString().Trim()),
                                    AccumDepreciationAmountUSD =
                                        decimal.Parse(dt.Rows[j]["accdepusd"].ToString().Trim()),
                                    AnnualDepreciationAmount =
                                        decimal.Parse(dt.Rows[j]["yearlydep"].ToString().Trim()),
                                    AnnualDepreciationAmountUSD =
                                        decimal.Parse(dt.Rows[j]["yearlydepusd"].ToString().Trim()),
                                    Description =
                                        (dt.Rows[j]["description"] != null)
                                            ? dt.Rows[j]["description"].ToString().Trim()
                                            : "",
                                    ExchangeRate = float.Parse(dt.Rows[j]["exchangerate"].ToString().Trim()),
                                    FixedAssetId = 0,
                                    OrgPrice = decimal.Parse(dt.Rows[j]["orgcost"].ToString()),
                                    OrgPriceUSD = decimal.Parse(dt.Rows[j]["orgcostusd"].ToString().Trim()),
                                    RemainingAmount = decimal.Parse(dt.Rows[j]["opnvalue"].ToString().Trim()),
                                    RemainingAmountUSD = decimal.Parse(dt.Rows[j]["opnvalueusd"].ToString().Trim()),
                                    UnitPrice = decimal.Parse(dt.Rows[j]["unitprice"].ToString().Trim()),
                                    UnitPriceUSD = decimal.Parse(dt.Rows[j]["unitpriceusd"].ToString().Trim())
                                };

                                var fid = (dt.Rows[j]["fixedassetcategoryid"] != null)
                                    ? Model.GetIdByCode("FixedAssetCategory", "FixedAssetCategoryID",
                                        "FixedAssetCategoryCode",
                                        dt.Rows[j]["fixedassetcategoryid"].ToString().Trim())
                                    : null;
                                var did = (dt.Rows[j]["departid"] != null)
                                    ? Model.GetIdByCode("Department", "DepartmentID", "DepartmentCode",
                                        dt.Rows[j]["departid"].ToString().Trim())
                                    : null;

                                var fixedAsset = new FixedAssetModel
                                {
                                    FixedAssetCode = dt.Rows[j]["fixedassetid"].ToString().Trim(),
                                    FixedAssetName = dt.Rows[j]["fixedassetname"].ToString().TrimEnd(),
                                    FixedAssetForeignName = "",
                                    FixedAssetCategoryId = (int)fid,
                                    State =
                                        (dt.Rows[j]["status"] != null)
                                            ? int.Parse(dt.Rows[j]["status"].ToString().Trim()) - 1
                                            : 0,
                                    Description =
                                        (dt.Rows[j]["description"] != null)
                                            ? dt.Rows[j]["description"].ToString().TrimEnd()
                                            : "",
                                    ProductionYear =
                                        (dt.Rows[j]["productionyear"] != null)
                                            ? int.Parse(dt.Rows[j]["productionyear"].ToString().Trim())
                                            : 0,
                                    MadeIn =
                                        (dt.Rows[j]["madein"] != null)
                                            ? dt.Rows[j]["madein"].ToString().TrimEnd()
                                            : "",
                                    PurchasedDate = DateTime.Parse(dt.Rows[j]["purchaseddate"].ToString().Trim()),
                                    UsedDate = DateTime.Parse(dt.Rows[j]["useddate"].ToString().Trim()),
                                    DepreciationDate = DateTime.Parse(dt.Rows[j]["startdate"].ToString().Trim()),
                                    IncrementDate = DateTime.Parse(dt.Rows[j]["useddate"].ToString().Trim()),
                                    DisposedDate =
                                        DateTime.Parse(dt.Rows[j]["useddate"].ToString().Trim())
                                            .AddYears((int)decimal.Parse(dt.Rows[j]["lifetime"].ToString())),
                                    Unit = (dt.Rows[j]["unit"] != null) ? dt.Rows[j]["unit"].ToString().Trim() : "",
                                    SerialNumber =
                                        (dt.Rows[j]["serialnumber"] != null)
                                            ? dt.Rows[j]["serialnumber"].ToString().Trim()
                                            : "",
                                    Accessories =
                                        (dt.Rows[j]["accessories"] != null)
                                            ? dt.Rows[j]["accessories"].ToString().Trim()
                                            : "",
                                    Quantity = (int)decimal.Parse(dt.Rows[j]["quantity"].ToString().Trim()),
                                    UnitPrice = decimal.Parse(dt.Rows[j]["unitprice"].ToString().Trim()),
                                    OrgPrice = decimal.Parse(dt.Rows[j]["orgcost"].ToString()),
                                    AccumDepreciationAmount = decimal.Parse(dt.Rows[j]["accdep"].ToString().Trim()),
                                    RemainingAmount = decimal.Parse(dt.Rows[j]["opnvalue"].ToString().Trim()),
                                    CurrencyCode = dt.Rows[j]["ccyid"].ToString().Trim(),
                                    ExchangeRate = decimal.Parse(dt.Rows[j]["exchangerate"].ToString().Trim()),
                                    UnitPriceUSD = decimal.Parse(dt.Rows[j]["unitpriceusd"].ToString().Trim()),
                                    OrgPriceUSD = decimal.Parse(dt.Rows[j]["orgcostusd"].ToString().Trim()),
                                    AccumDepreciationAmountUSD =
                                        decimal.Parse(dt.Rows[j]["accdepusd"].ToString().Trim()),
                                    RemainingAmountUSD = decimal.Parse(dt.Rows[j]["opnvalueusd"].ToString().Trim()),
                                    AnnualDepreciationAmountUSD =
                                        decimal.Parse(dt.Rows[j]["yearlydepusd"].ToString().Trim()),
                                    AnnualDepreciationAmount =
                                        decimal.Parse(dt.Rows[j]["yearlydep"].ToString().Trim()),
                                    LifeTime = decimal.Parse(dt.Rows[j]["lifetime"].ToString().Trim()),
                                    DepreciationRate = decimal.Parse(dt.Rows[j]["deprate"].ToString().Trim()),
                                    OrgPriceAccountCode = dt.Rows[j]["assetaccount"].ToString().Trim(),
                                    DepreciationAccountCode = dt.Rows[j]["depaccount"].ToString().Trim(),
                                    CapitalAccountCode = dt.Rows[j]["capitalaccount"].ToString().Trim(),
                                    DepartmentId = (int)did,
                                    IsActive = dt.Rows[j]["inactive"] != null && (bool)dt.Rows[j]["inactive"],

                                };
                                if (dt.Rows[j]["employeeid"] == null)
                                    fixedAsset.EmployeeId = null;
                                else
                                {
                                    fixedAsset.EmployeeId =
                                        string.IsNullOrEmpty(dt.Rows[j]["employeeid"].ToString().Trim())
                                            ? null
                                            : Model.GetIdByCode("Employee", "EmployeeID", "EmployeeCode",
                                                dt.Rows[j]["employeeid"].ToString().Trim());
                                }
                                fixedAsset.FixedAssetCurrencies.Add(fixedAssetCurrency);
                                if (oldActive != newActive) fixedAsset.IsActive = !(bool)dt.Rows[j]["inactive"];
                                Model.AddFixedAsset(fixedAsset);
                            }
                            break;

                        #endregion

                        #region OpeningAccountEntry

                        case "OpeningAccountEntry":
                            for (var j = 0; j < dt.Rows.Count; j++)
                            {
                                var selectClaus = "SELECT * FROM JOURENTRYDETAIL WHERE Account == '" +
                                                  dt.Rows[j]["Account"].ToString().Trim() + "' AND reftype ='999' ";
                                var dtOpeningAccountVoucher = GetData(selectClaus);
                                ConvertFontData(ref dtOpeningAccountVoucher, "description");
                                var openingAccountEntryDetailVouchers = new List<OpeningAccountEntryDetailModel>();

                                var voucher = new OpeningAccountEntryModel
                                {
                                    RefTypeId = 700,
                                    PostedDate = DateTime.Parse(dt.Rows[j]["postdate"].ToString().Trim()),
                                    AccountCode = dt.Rows[j]["account"].ToString().Trim(),
                                    OpeningAccountEntryDetails = openingAccountEntryDetailVouchers
                                };

                                for (var k = 0; k < dtOpeningAccountVoucher.Rows.Count; k++)
                                {
                                    openingAccountEntryDetailVouchers.Add(new OpeningAccountEntryDetailModel
                                    {
                                        AccountingObjectId = dtOpeningAccountVoucher.Rows[k]["objectid"] == null ? null :
                                                    Model.GetIdByCode("AccountingObject",
                                                        "AccountingObjectID", "AccountingObjectCode",
                                                        dtOpeningAccountVoucher.Rows[k]["objectid"].ToString().Trim()),
                                        BudgetItemCode = dtOpeningAccountVoucher.Rows[k]["budgetitemid"] == null ? null : dtOpeningAccountVoucher.Rows[k]["budgetitemid"].ToString().Trim(),
                                        BudgetSourceCode = dtOpeningAccountVoucher.Rows[k]["capitalid"] == null ? null : dtOpeningAccountVoucher.Rows[k]["capitalid"].ToString().Trim(),
                                        BudgetGroupItemCode = null,
                                        MergerFundId = null,
                                        ProjectId = null,
                                        BudgetChapterCode = null,
                                        BudgetCategoryCode = null,
                                        BankId = null,
                                        AccountCode = dtOpeningAccountVoucher.Rows[k]["account"].ToString().Trim(),
                                        AccountBeginningDebitAmountOC = 0,
                                        AccountBeginningDebitAmountExchange = 0,
                                        AccountBeginningCreditAmountOC = 0,
                                        AccountBeginningCreditAmountExchange = 0,
                                        CreditAmountOC =
                                            decimal.Parse(
                                                dtOpeningAccountVoucher.Rows[k]["fccreditamount"].ToString().Trim()),
                                        DebitAmountOC =
                                            decimal.Parse(
                                                dtOpeningAccountVoucher.Rows[k]["fcdebitamount"].ToString().Trim()),
                                        CreditAmountExchange =
                                            decimal.Parse(
                                                dtOpeningAccountVoucher.Rows[k]["creditamount"].ToString().Trim()),
                                        DebitAmountExchange =
                                            decimal.Parse(
                                                dtOpeningAccountVoucher.Rows[k]["debitamount"].ToString().Trim()),
                                        CurrencyCode = dtOpeningAccountVoucher.Rows[k]["ccyid"].ToString().Trim(),
                                        CustomerId = null,
                                        EmployeeId = dtOpeningAccountVoucher.Rows[k]["EmployeeId"] == null ? null :
                                            Model.GetIdByCode("Employee", "EmployeeID", "EmployeeCode",
                                                dtOpeningAccountVoucher.Rows[k]["EmployeeId"].ToString().Trim()),
                                        ExchangeRate =
                                            float.Parse(
                                                dtOpeningAccountVoucher.Rows[k]["ExchangeRate"].ToString().Trim()),
                                        PostedDate =
                                            DateTime.Parse(
                                                dtOpeningAccountVoucher.Rows[k]["postdate"].ToString().Trim()),
                                        RefTypeId = 700,
                                        VendorId = dtOpeningAccountVoucher.Rows[k]["vendorid"] == null ? null :
                                            Model.GetIdByCode("Vendor", "VendorID", "VendorCode",
                                                dtOpeningAccountVoucher.Rows[k]["vendorid"].ToString().Trim())
                                    });
                                }

                                voucher.OpeningAccountEntryDetails = openingAccountEntryDetailVouchers;
                                Model.UpdateOpeningAccountEntry(voucher);
                            }
                            break;

                        #endregion

                        #region OpeningFixedAssetEntry

                        case "OpeningFixedAssetEntry":
                            for (var j = 0; j < dt.Rows.Count; j++)
                            {
                                //Danh mục tài sản đã được tổng hợp, do đó để tăng tốc độ, sẽ lấy luôn ở danh mục tài sản đã được convert
                                var fixedAssetModel =
                                    Model.GetFixedAssetsByCode(dt.Rows[j]["FixedAssetId"].ToString().Trim());

                                var voucher = new List<OpeningFixedAssetEntryModel>
                                    {
                                        new OpeningFixedAssetEntryModel
                                        {
                                            RefTypeId = 702,
                                            RefNo = GeneratedBaseRefNo(702),
                                            PostedDate = DateTime.Parse(dt.Rows[j]["postdate"].ToString().Trim()),
                                            FixedAssetId = fixedAssetModel.FixedAssetId,
                                            DepartmentId = fixedAssetModel.DepartmentId,
                                            LifeTime = (int) fixedAssetModel.LifeTime,
                                            IncrementDate = fixedAssetModel.IncrementDate,
                                            Unit = fixedAssetModel.Unit,
                                            UsedDate = fixedAssetModel.UsedDate,
                                            CurrencyCode = fixedAssetModel.CurrencyCode,
                                            ExchangeRate = fixedAssetModel.ExchangeRate,
                                            OrgPriceAccount = fixedAssetModel.OrgPriceAccountCode,
                                            DepreciationAccount = fixedAssetModel.DepreciationAccountCode,
                                            CapitalAccount = fixedAssetModel.CapitalAccountCode,

                                            OrgPriceDebitAmount =
                                                fixedAssetModel.FixedAssetCurrencies != null
                                                    ? fixedAssetModel.FixedAssetCurrencies[0].OrgPrice
                                                    : 0,
                                            OrgPriceDebitAmountUSD =
                                                fixedAssetModel.FixedAssetCurrencies != null
                                                    ? fixedAssetModel.FixedAssetCurrencies[0].OrgPriceUSD
                                                    : 0,
                                            DepreciationCreditAmount =
                                                fixedAssetModel.FixedAssetCurrencies != null
                                                    ? fixedAssetModel.FixedAssetCurrencies[0].AccumDepreciationAmount
                                                    : 0,
                                            DepreciationCreditAmountUSD =
                                                fixedAssetModel.FixedAssetCurrencies != null
                                                    ? fixedAssetModel.FixedAssetCurrencies[0].AccumDepreciationAmountUSD
                                                    : 0,
                                            CapitalCreditAmount =
                                                fixedAssetModel.FixedAssetCurrencies != null
                                                    ? fixedAssetModel.FixedAssetCurrencies[0].RemainingAmount
                                                    : 0,
                                            CapitalCreditAmountUSD =
                                                fixedAssetModel.FixedAssetCurrencies != null
                                                    ? fixedAssetModel.FixedAssetCurrencies[0].RemainingAmountUSD
                                                    : 0,
                                            RemainingAmount =
                                                fixedAssetModel.FixedAssetCurrencies != null
                                                    ? fixedAssetModel.FixedAssetCurrencies[0].RemainingAmount
                                                    : 0,
                                            RemainingAmountUSD =
                                                fixedAssetModel.FixedAssetCurrencies != null
                                                    ? fixedAssetModel.FixedAssetCurrencies[0].RemainingAmountUSD
                                                    : 0,
                                            BudgetChapterCode = null,
                                            Description = "Số dư đầu kỳ tài sản " + fixedAssetModel.FixedAssetName,
                                            Quantity = fixedAssetModel.Quantity
                                        }
                                    };


                                Model.InsertOpeningFixedAssetEntries(voucher);
                            }
                            break;

                        #endregion

                        #region OpeningInventoryEntry

                        case "OpeningInventoryEntry":
                            var openingInventoryEntryModels = new List<OpeningInventoryEntryModel>();
                            for (var j = 0; j < dt.Rows.Count; j++)
                            {
                                var quantity = Convert.ToInt16(dt.Rows[j]["quantity"]);
                                var openingInventoryEntryModel = new OpeningInventoryEntryModel
                                {
                                    RefTypeId = 701,
                                    RefNo = GeneratedBaseRefNo(701),
                                    PostedDate = DateTime.Parse(dt.Rows[j]["postdate"].ToString().Trim()),
                                    AccountNumber = dt.Rows[j]["account"].ToString().Trim(),
                                    AmountExchange = decimal.Parse(dt.Rows[j]["amount"].ToString().Trim()),
                                    ExchangeRate = decimal.Parse(dt.Rows[j]["ExchangeRate"].ToString().Trim()),
                                    AmountOc = decimal.Parse(dt.Rows[j]["fcamount"].ToString().Trim()),
                                    CurrencyCode = dt.Rows[j]["ccyid"].ToString().Trim(),
                                    Quantity = quantity,
                                    InventoryItemId = (int)
                                        Model.GetIdByCode("InventoryItem", "InventoryItemID",
                                            "InventoryItemCode",
                                            dt.Rows[j]["itemid"].ToString().Trim()),
                                    StockId = (int)Model.GetIdByCode("Stock", "StockID", "StockCode",
                                        dt.Rows[j]["stockid"].ToString().Trim()),
                                    UnitPriceExchange = decimal.Parse(dt.Rows[j]["unitprice"].ToString().Trim()),
                                    UnitPriceOc = decimal.Parse(dt.Rows[j]["fcunitprice"].ToString().Trim())
                                };
                                openingInventoryEntryModels.Add(openingInventoryEntryModel);
                            }
                            if (openingInventoryEntryModels.Count > 0)
                                Model.UpdateOpeningInventoryEntry(openingInventoryEntryModels);
                            break;

                        #endregion

                        #region Vouchers

                        #region CashReceipt

                        case "CashReceipt":
                            if (Model.GetReceiptVoucherByRefTypeId(200).Count > 0)
                            {
                                break;
                            }
                            for (var j = 0; j < dt.Rows.Count; j++)
                            {
                                var selectClaus = "SELECT * FROM JOURENTRYDETAIL WHERE refid = '" +
                                                  dt.Rows[j]["refid"].ToString().Trim() + "' AND reftype ='200' ";
                                var dtReceiptVoucher = GetData(selectClaus);
                                ConvertFontData(ref dtReceiptVoucher, "description");
                                var receiptVouchers = new List<ReceiptVoucherDetailModel>();

                                var voucher = new ReceiptVoucherModel
                                {
                                    AccountingObjectType = int.Parse(dt.Rows[j]["objecttype"].ToString().Trim()),
                                    RefTypeId = 200,
                                    RefNo = dt.Rows[j]["refno"].ToString().Trim(),
                                    RefDate = DateTime.Parse(dt.Rows[j]["refdate"].ToString().Trim()),
                                    PostedDate = DateTime.Parse(dt.Rows[j]["postdate"].ToString().Trim()),

                                    Trader = dt.Rows[j]["contactname"] == null ? "" : dt.Rows[j]["contactname"].ToString().Trim(),
                                    CurrencyCode = dt.Rows[j]["ccyid"].ToString().Trim(),
                                    AccountNumber = dt.Rows[j]["cashaccount"].ToString().Trim(),
                                    TotalAmount = decimal.Parse(dt.Rows[j]["fctotalamount"].ToString().Trim()),
                                    ExchangeRate = decimal.Parse(dt.Rows[j]["exchangerate"].ToString().Trim()),
                                    TotalAmountExchange = decimal.Parse(dt.Rows[j]["totalamount"].ToString().Trim()),
                                    JournalMemo = dt.Rows[j]["comment"] == null ? "" : dt.Rows[j]["comment"].ToString().TrimEnd(),
                                    DocumentInclude = dt.Rows[j]["docattach"] == null ? "" : dt.Rows[j]["docattach"].ToString().Trim(),
                                    ReceiptVoucherDetails = receiptVouchers
                                };
                                if (dt.Rows[j]["objecttype"] != null)
                                {
                                    if (int.Parse(dt.Rows[j]["objecttype"].ToString().Trim()) == 1) // Khách hàng
                                    {
                                        voucher.AccountingObjectType = 3;
                                        voucher.AccountingObjectId = null;
                                        voucher.CustomerId = null;
                                        voucher.VendorId = null;
                                        voucher.EmployeeId = null;
                                    }
                                    else if (int.Parse(dt.Rows[j]["objecttype"].ToString().Trim()) == 2)// Nha cung cap
                                    {
                                        voucher.AccountingObjectType = 0;
                                        voucher.AccountingObjectId = null;
                                        voucher.CustomerId = null;
                                        if (dt.Rows[j]["objectid"] != null)
                                        {
                                            if (dt.Rows[j]["objectid"].ToString().Trim() != "")
                                            {
                                                voucher.VendorId = Model.GetIdByCode("Vendor", "VendorID",
                                                    "VendorCode",
                                                    dt.Rows[j]["objectid"].ToString().Trim());
                                            }
                                            else voucher.VendorId = null;
                                        }
                                        else voucher.VendorId = null;
                                        voucher.EmployeeId = null;
                                    }
                                    else if (int.Parse(dt.Rows[j]["objecttype"].ToString().Trim()) == 3)// Nhan vien
                                    {
                                        voucher.AccountingObjectType = 1;
                                        voucher.AccountingObjectId = null;
                                        voucher.CustomerId = null;
                                        voucher.VendorId = null;
                                        if (dt.Rows[j]["objectid"] != null)
                                        {
                                            if (dt.Rows[j]["objectid"].ToString().Trim() != "")
                                            {
                                                voucher.EmployeeId = Model.GetIdByCode("Employee",
                                                    "EmployeeID",
                                                    "EmployeeCode",
                                                    dt.Rows[j]["objectid"].ToString().Trim());
                                            }
                                            else voucher.EmployeeId = null;
                                        }
                                        else voucher.EmployeeId = null;

                                    }
                                    else // đối tượng khác
                                    {
                                        if (dt.Rows[j]["objectid"] != null)
                                        {
                                            if (dt.Rows[j]["objectid"].ToString().Trim() != "")
                                            {
                                                voucher.AccountingObjectId =
                                                    Model.GetIdByCode("AccountingObject",
                                                        "AccountingObjectID", "AccountingObjectCode",
                                                        dt.Rows[j]["objectid"].ToString().Trim());
                                            }
                                            else voucher.AccountingObjectId = null;
                                        }
                                        else voucher.AccountingObjectId = null;
                                        voucher.AccountingObjectType = 2;
                                        voucher.CustomerId = null;
                                        voucher.VendorId = null;
                                        voucher.EmployeeId = null;
                                    }
                                }
                                for (var k = 0; k < dtReceiptVoucher.Rows.Count; k++)
                                {
                                    var receiptDetail = new ReceiptVoucherDetailModel
                                    {
                                        AccountingObjectId = dtReceiptVoucher.Rows[k]["objectid"] == null ? null :
                                                    Model.GetIdByCode("AccountingObject",
                                                        "AccountingObjectID", "AccountingObjectCode",
                                                        dtReceiptVoucher.Rows[k]["objectid"].ToString().Trim()),
                                        AccountNumber = dtReceiptVoucher.Rows[k]["debitaccount"].ToString().Trim(),
                                        CorrespondingAccountNumber =
                                            dtReceiptVoucher.Rows[k]["creditaccount"].ToString().Trim(),
                                        AmountExchange =
                                            decimal.Parse(dtReceiptVoucher.Rows[k]["amount"].ToString().Trim()),
                                        AmountOc =
                                            decimal.Parse(dtReceiptVoucher.Rows[k]["fcamount"].ToString().Trim()),
                                        AutoBusinessId = null,
                                        BudgetItemCode = dtReceiptVoucher.Rows[k]["budgetitemid"] == null ? null : dtReceiptVoucher.Rows[k]["budgetitemid"].ToString().Trim(),
                                        BudgetSourceCode = dtReceiptVoucher.Rows[k]["capitalid"] == null ? null : dtReceiptVoucher.Rows[k]["capitalid"].ToString().Trim(),
                                        Description = dtReceiptVoucher.Rows[k]["description"] == null ? "" : dtReceiptVoucher.Rows[k]["description"].ToString().TrimEnd(),
                                        MergerFundId = null,
                                        ProjectId = null,
                                    };
                                    if (dtReceiptVoucher.Rows[k]["vouchertype"] != null)
                                    {
                                        if (int.Parse(dtReceiptVoucher.Rows[k]["vouchertype"].ToString()) != 0)
                                            receiptDetail.VoucherTypeId =
                                                int.Parse(dtReceiptVoucher.Rows[k]["vouchertype"].ToString());
                                        else
                                            receiptDetail.VoucherTypeId = null;
                                    }
                                    else receiptDetail.VoucherTypeId = null;
                                    receiptVouchers.Add(receiptDetail);
                                }

                                voucher.ReceiptVoucherDetails = receiptVouchers;
                                Model.IsConvertData = true;
                                Model.AddReceiptVoucher(voucher,false);
                            }
                            break;

                        #endregion

                        #region CashExpense

                        case "CashExpense":
                            if (Model.GetReceiptVoucherByRefTypeId(201).Count > 0)
                            {
                                break;
                            }
                            for (var j = 0; j < dt.Rows.Count; j++)
                            {
                                var selectClaus = "SELECT * FROM JOURENTRYDETAIL WHERE refid = '" +
                                                  dt.Rows[j]["refid"].ToString().Trim() + "' AND reftype ='201' ";
                                var dtExpenseVoucher = GetData(selectClaus);
                                ConvertFontData(ref dtExpenseVoucher, "description");
                                var cashDetailVouchers = new List<CashDetailModel>();

                                var voucher = new CashModel
                                {
                                    AccountingObjectType = int.Parse(dt.Rows[j]["objecttype"].ToString().Trim()),
                                    RefTypeId = 201,
                                    RefNo = dt.Rows[j]["refno"].ToString().Trim(),
                                    RefDate = dt.Rows[j]["refdate"].ToString().Trim(),
                                    PostedDate = dt.Rows[j]["postdate"].ToString().Trim(),

                                    Trader = dt.Rows[j]["contactname"] == null ? "" : dt.Rows[j]["contactname"].ToString().Trim(),
                                    CurrencyCode = dt.Rows[j]["ccyid"].ToString().Trim(),
                                    AccountNumber = dt.Rows[j]["cashaccount"].ToString().Trim(),
                                    TotalAmount = decimal.Parse(dt.Rows[j]["fctotalamount"].ToString().Trim()),
                                    ExchangeRate = decimal.Parse(dt.Rows[j]["exchangerate"].ToString().Trim()),
                                    TotalAmountExchange = decimal.Parse(dt.Rows[j]["totalamount"].ToString().Trim()),
                                    JournalMemo = dt.Rows[j]["comment"] == null ? "" : dt.Rows[j]["comment"].ToString().TrimEnd(),
                                    DocumentInclude = dt.Rows[j]["docattach"] == null ? "" : dt.Rows[j]["docattach"].ToString().Trim(),
                                    CashDetails = cashDetailVouchers
                                };
                                if (dt.Rows[j]["objecttype"] != null)
                                {
                                    if (int.Parse(dt.Rows[j]["objecttype"].ToString().Trim()) == 1) // Khách hàng
                                    {
                                        voucher.AccountingObjectType = 3;
                                        voucher.AccountingObjectId = null;
                                        voucher.CustomerId = null;
                                        voucher.VendorId = null;
                                        voucher.EmployeeId = null;
                                    }
                                    else if (int.Parse(dt.Rows[j]["objecttype"].ToString().Trim()) == 2)
                                    // Nha cung cap
                                    {
                                        voucher.AccountingObjectType = 0;
                                        voucher.AccountingObjectId = null;
                                        voucher.CustomerId = null;
                                        if (dt.Rows[j]["objectid"] != null)
                                        {
                                            if (dt.Rows[j]["objectid"].ToString().Trim() != "")
                                            {
                                                voucher.VendorId = Model.GetIdByCode("Vendor", "VendorID",
                                                    "VendorCode",
                                                    dt.Rows[j]["objectid"].ToString().Trim());
                                            }
                                            else voucher.VendorId = null;
                                        }
                                        else voucher.VendorId = null;
                                        voucher.EmployeeId = null;
                                    }
                                    else if (int.Parse(dt.Rows[j]["objecttype"].ToString().Trim()) == 3)
                                    // Nhan vien
                                    {
                                        voucher.AccountingObjectType = 1;
                                        voucher.AccountingObjectId = null;
                                        voucher.CustomerId = null;
                                        voucher.VendorId = null;
                                        if (dt.Rows[j]["objectid"] != null)
                                        {
                                            if (dt.Rows[j]["objectid"].ToString().Trim() != "")
                                            {
                                                voucher.EmployeeId = Model.GetIdByCode("Employee",
                                                    "EmployeeID",
                                                    "EmployeeCode",
                                                    dt.Rows[j]["objectid"].ToString().Trim());
                                            }
                                            else voucher.EmployeeId = null;
                                        }
                                        else voucher.EmployeeId = null;

                                    }
                                    else // đối tượng khác
                                    {
                                        if (dt.Rows[j]["objectid"] != null)
                                        {
                                            if (dt.Rows[j]["objectid"].ToString().Trim() != "")
                                            {
                                                voucher.AccountingObjectId =
                                                    Model.GetIdByCode("AccountingObject",
                                                        "AccountingObjectID", "AccountingObjectCode",
                                                        dt.Rows[j]["objectid"].ToString().Trim());
                                            }
                                            else voucher.AccountingObjectId = null;
                                        }
                                        else voucher.AccountingObjectId = null;
                                        voucher.AccountingObjectType = 2;
                                        voucher.CustomerId = null;
                                        voucher.VendorId = null;
                                        voucher.EmployeeId = null;
                                    }
                                }
                                for (var k = 0; k < dtExpenseVoucher.Rows.Count; k++)
                                {
                                    var cashDetail = new CashDetailModel
                                    {
                                        AccountingObjectId = dtExpenseVoucher.Rows[k]["objectid"] == null ? null :
                                                    Model.GetIdByCode("AccountingObject",
                                                        "AccountingObjectID", "AccountingObjectCode",
                                                        dtExpenseVoucher.Rows[k]["objectid"].ToString().Trim()),
                                        AccountNumber = dtExpenseVoucher.Rows[k]["debitaccount"].ToString().Trim(),
                                        CorrespondingAccountNumber =
                                            dtExpenseVoucher.Rows[k]["creditaccount"].ToString().Trim(),
                                        AmountExchange =
                                            decimal.Parse(dtExpenseVoucher.Rows[k]["amount"].ToString().Trim()),
                                        AmountOc =
                                            decimal.Parse(dtExpenseVoucher.Rows[k]["fcamount"].ToString().Trim()),
                                        AutoBusinessId = null,
                                        BudgetItemCode = dtExpenseVoucher.Rows[k]["budgetitemid"] == null ? null : dtExpenseVoucher.Rows[k]["budgetitemid"].ToString().Trim(),
                                        BudgetSourceCode = dtExpenseVoucher.Rows[k]["capitalid"] == null ? null : dtExpenseVoucher.Rows[k]["capitalid"].ToString().Trim(),
                                        Description = dtExpenseVoucher.Rows[k]["description"] == null ? "" : dtExpenseVoucher.Rows[k]["description"].ToString().TrimEnd(),
                                        MergerFundId = null,
                                        ProjectId = null,
                                    };
                                    if (dtExpenseVoucher.Rows[k]["vouchertype"] != null)
                                    {
                                        if (int.Parse(dtExpenseVoucher.Rows[k]["vouchertype"].ToString()) != 0)
                                            cashDetail.VoucherTypeId =
                                                int.Parse(dtExpenseVoucher.Rows[k]["vouchertype"].ToString());
                                        else
                                            cashDetail.VoucherTypeId = null;
                                    }
                                    else cashDetail.VoucherTypeId = null;
                                    cashDetailVouchers.Add(cashDetail);
                                }

                                voucher.CashDetails = cashDetailVouchers;
                                Model.IsConvertData = true;
                                Model.AddPaymentVoucher(voucher);
                            }
                            break;

                        #endregion

                        #region DepositReceipt

                        case "DepositReceipt":
                            if (Model.GetDepositsByRefTypeId(300).Count > 0)
                            {
                                break;
                            }
                            for (var j = 0; j < dt.Rows.Count; j++)
                            {
                                var selectClaus = "SELECT * FROM JOURENTRYDETAIL WHERE refid = '" +
                                                  dt.Rows[j]["refid"].ToString().Trim() + "' AND reftype ='300' ";
                                var dtDepositReceiptVoucher = GetData(selectClaus);
                                ConvertFontData(ref dtDepositReceiptVoucher, "description");
                                var depositDetailVouchers = new List<DepositDetailModel>();

                                var voucher = new DepositModel
                                {
                                    AccountingObjectType = int.Parse(dt.Rows[j]["objecttype"].ToString().Trim()),
                                    RefTypeId = 300,
                                    RefNo = dt.Rows[j]["refno"].ToString().Trim(),
                                    RefDate = dt.Rows[j]["refdate"].ToString().Trim() == "" ? (DateTime?)null : Convert.ToDateTime(dt.Rows[j]["refdate"].ToString().Trim()),
                                    PostedDate = dt.Rows[j]["postdate"].ToString().Trim() == "" ? (DateTime?)null : Convert.ToDateTime(dt.Rows[j]["postdate"].ToString().Trim()),

                                    Trader = dt.Rows[j]["contactname"] == null ? "" : dt.Rows[j]["contactname"].ToString().Trim(),
                                    CurrencyCode = dt.Rows[j]["ccyid"].ToString().Trim(),
                                    BankAccountCode = dt.Rows[j]["bankaccount"].ToString().Trim(),
                                    TotalAmountOc = decimal.Parse(dt.Rows[j]["fctotalamount"].ToString().Trim()),
                                    ExchangeRate = decimal.Parse(dt.Rows[j]["exchangerate"].ToString().Trim()),
                                    TotalAmountExchange = decimal.Parse(dt.Rows[j]["totalamount"].ToString().Trim()),
                                    JournalMemo = dt.Rows[j]["comment"] == null ? "" : dt.Rows[j]["comment"].ToString().TrimEnd(),
                                };
                                if (dt.Rows[j]["objecttype"] != null)
                                {
                                    if (int.Parse(dt.Rows[j]["objecttype"].ToString().Trim()) == 1) // Khách hàng
                                    {
                                        voucher.AccountingObjectType = 3;
                                        voucher.AccountingObjectId = null;
                                        voucher.CustomerId = null;
                                        voucher.VendorId = null;
                                        voucher.EmployeeId = null;
                                    }
                                    else if (int.Parse(dt.Rows[j]["objecttype"].ToString().Trim()) == 2)
                                    // Nha cung cap
                                    {
                                        voucher.AccountingObjectType = 0;
                                        voucher.AccountingObjectId = null;
                                        voucher.CustomerId = null;
                                        if (dt.Rows[j]["objectid"] != null)
                                        {
                                            if (dt.Rows[j]["objectid"].ToString().Trim() != "")
                                            {
                                                voucher.VendorId = Model.GetIdByCode("Vendor", "VendorID",
                                                    "VendorCode",
                                                    dt.Rows[j]["objectid"].ToString().Trim());
                                            }
                                            else voucher.VendorId = null;
                                        }
                                        else voucher.VendorId = null;
                                        voucher.EmployeeId = null;
                                    }
                                    else if (int.Parse(dt.Rows[j]["objecttype"].ToString().Trim()) == 3)
                                    // Nhan vien
                                    {
                                        voucher.AccountingObjectType = 1;
                                        voucher.AccountingObjectId = null;
                                        voucher.CustomerId = null;
                                        voucher.VendorId = null;
                                        if (dt.Rows[j]["objectid"] != null)
                                        {
                                            if (dt.Rows[j]["objectid"].ToString().Trim() != "")
                                            {
                                                voucher.EmployeeId = Model.GetIdByCode("Employee",
                                                    "EmployeeID",
                                                    "EmployeeCode",
                                                    dt.Rows[j]["objectid"].ToString().Trim());
                                            }
                                            else voucher.EmployeeId = null;
                                        }
                                        else voucher.EmployeeId = null;

                                    }
                                    else // đối tượng khác
                                    {
                                        if (dt.Rows[j]["objectid"] != null)
                                        {
                                            if (dt.Rows[j]["objectid"].ToString().Trim() != "")
                                            {
                                                voucher.AccountingObjectId =
                                                    Model.GetIdByCode("AccountingObject",
                                                        "AccountingObjectID", "AccountingObjectCode",
                                                        dt.Rows[j]["objectid"].ToString().Trim());
                                            }
                                            else voucher.AccountingObjectId = null;
                                        }
                                        else voucher.AccountingObjectId = null;
                                        voucher.AccountingObjectType = 2;
                                        voucher.CustomerId = null;
                                        voucher.VendorId = null;
                                        voucher.EmployeeId = null;
                                    }
                                }
                                for (var k = 0; k < dtDepositReceiptVoucher.Rows.Count; k++)
                                {
                                    var depositDetail = new DepositDetailModel
                                    {
                                        AccountingObjectId = dtDepositReceiptVoucher.Rows[k]["objectid"] == null ? null :
                                                    Model.GetIdByCode("AccountingObject",
                                                        "AccountingObjectID", "AccountingObjectCode",
                                                        dtDepositReceiptVoucher.Rows[k]["objectid"].ToString().Trim()),
                                        AccountNumber = dtDepositReceiptVoucher.Rows[k]["debitaccount"].ToString().Trim(),
                                        CorrespondingAccountNumber =
                                            dtDepositReceiptVoucher.Rows[k]["creditaccount"].ToString().Trim(),
                                        AmountExchange =
                                            decimal.Parse(dtDepositReceiptVoucher.Rows[k]["amount"].ToString().Trim()),
                                        AmountOc =
                                            decimal.Parse(dtDepositReceiptVoucher.Rows[k]["fcamount"].ToString().Trim()),
                                        AutoBusinessId = null,
                                        BudgetItemCode = dtDepositReceiptVoucher.Rows[k]["budgetitemid"] == null ? null : dtDepositReceiptVoucher.Rows[k]["budgetitemid"].ToString().Trim(),
                                        BudgetSourceCode = dtDepositReceiptVoucher.Rows[k]["capitalid"] == null ? null : dtDepositReceiptVoucher.Rows[k]["capitalid"].ToString().Trim(),
                                        Description = dtDepositReceiptVoucher.Rows[k]["description"] == null ? "" : dtDepositReceiptVoucher.Rows[k]["description"].ToString().TrimEnd(),
                                        MergerFundId = null,
                                        ProjectId = null,
                                        DepartmentId = null,
                                    };
                                    if (dtDepositReceiptVoucher.Rows[k]["vouchertype"] != null)
                                    {
                                        if (int.Parse(dtDepositReceiptVoucher.Rows[k]["vouchertype"].ToString()) != 0)
                                            depositDetail.VoucherTypeId =
                                                int.Parse(dtDepositReceiptVoucher.Rows[k]["vouchertype"].ToString());
                                        else
                                            depositDetail.VoucherTypeId = null;
                                    }
                                    else depositDetail.VoucherTypeId = null;
                                    depositDetailVouchers.Add(depositDetail);
                                }

                                voucher.DepositDetails = depositDetailVouchers;
                                Model.IsConvertData = true;
                                Model.AddDeposit(voucher);
                            }
                            break;

                        #endregion

                        #region DepositExpense

                        case "DepositExpense":
                            if (Model.GetDepositsByRefTypeId(301).Count > 0)
                            {
                                break;
                            }
                            for (var j = 0; j < dt.Rows.Count; j++)
                            {
                                var selectClaus = "SELECT * FROM JOURENTRYDETAIL WHERE refid = '" +
                                                  dt.Rows[j]["refid"].ToString().Trim() + "' AND reftype ='301' ";
                                var dtExpenseVoucher = GetData(selectClaus);
                                ConvertFontData(ref dtExpenseVoucher, "description");
                                var depositDetailVouchers = new List<DepositDetailModel>();

                                var voucher = new DepositModel
                                {
                                    AccountingObjectType = int.Parse(dt.Rows[j]["objecttype"].ToString().Trim()),
                                    RefTypeId = 301,
                                    RefNo = dt.Rows[j]["refno"].ToString().Trim(),
                                    RefDate = dt.Rows[j]["refdate"].ToString().Trim() == "" ? (DateTime?)null : Convert.ToDateTime(dt.Rows[j]["refdate"].ToString().Trim()),
                                    PostedDate = dt.Rows[j]["postdate"].ToString().Trim() == "" ? (DateTime?)null : Convert.ToDateTime(dt.Rows[j]["postdate"].ToString().Trim()),

                                    Trader = dt.Rows[j]["contactname"] == null ? "" : dt.Rows[j]["contactname"].ToString().Trim(),
                                    CurrencyCode = dt.Rows[j]["ccyid"].ToString().Trim(),
                                    BankAccountCode = dt.Rows[j]["bankaccount"].ToString().Trim(),
                                    TotalAmountOc = decimal.Parse(dt.Rows[j]["fctotalamount"].ToString().Trim()),
                                    ExchangeRate = decimal.Parse(dt.Rows[j]["exchangerate"].ToString().Trim()),
                                    TotalAmountExchange = decimal.Parse(dt.Rows[j]["totalamount"].ToString().Trim()),
                                    JournalMemo = dt.Rows[j]["comment"] == null ? "" : dt.Rows[j]["comment"].ToString().TrimEnd(),
                                };

                                #region AccountingObject Master
                                if (dt.Rows[j]["objecttype"] != null)
                                {
                                    if (int.Parse(dt.Rows[j]["objecttype"].ToString().Trim()) == 1) // Khách hàng
                                    {
                                        voucher.AccountingObjectType = 3;
                                        voucher.AccountingObjectId = null;
                                        voucher.CustomerId = null;
                                        voucher.VendorId = null;
                                        voucher.EmployeeId = null;
                                    }
                                    else if (int.Parse(dt.Rows[j]["objecttype"].ToString().Trim()) == 2)
                                    // Nha cung cap
                                    {
                                        voucher.AccountingObjectType = 0;
                                        voucher.AccountingObjectId = null;
                                        voucher.CustomerId = null;
                                        if (dt.Rows[j]["objectid"] != null)
                                        {
                                            if (dt.Rows[j]["objectid"].ToString().Trim() != "")
                                            {
                                                voucher.VendorId = Model.GetIdByCode("Vendor", "VendorID",
                                                    "VendorCode",
                                                    dt.Rows[j]["objectid"].ToString().Trim());
                                            }
                                            else voucher.VendorId = null;
                                        }
                                        else voucher.VendorId = null;
                                        voucher.EmployeeId = null;
                                    }
                                    else if (int.Parse(dt.Rows[j]["objecttype"].ToString().Trim()) == 3)
                                    // Nhan vien
                                    {
                                        voucher.AccountingObjectType = 1;
                                        voucher.AccountingObjectId = null;
                                        voucher.CustomerId = null;
                                        voucher.VendorId = null;
                                        if (dt.Rows[j]["objectid"] != null)
                                        {
                                            if (dt.Rows[j]["objectid"].ToString().Trim() != "")
                                            {
                                                voucher.EmployeeId = Model.GetIdByCode("Employee",
                                                    "EmployeeID",
                                                    "EmployeeCode",
                                                    dt.Rows[j]["objectid"].ToString().Trim());
                                            }
                                            else voucher.EmployeeId = null;
                                        }
                                        else voucher.EmployeeId = null;

                                    }
                                    else // đối tượng khác
                                    {
                                        if (dt.Rows[j]["objectid"] != null)
                                        {
                                            if (dt.Rows[j]["objectid"].ToString().Trim() != "")
                                            {
                                                voucher.AccountingObjectId =
                                                    Model.GetIdByCode("AccountingObject",
                                                        "AccountingObjectID", "AccountingObjectCode",
                                                        dt.Rows[j]["objectid"].ToString().Trim());
                                            }
                                            else voucher.AccountingObjectId = null;
                                        }
                                        else voucher.AccountingObjectId = null;
                                        voucher.AccountingObjectType = 2;
                                        voucher.CustomerId = null;
                                        voucher.VendorId = null;
                                        voucher.EmployeeId = null;
                                    }
                                }
                                #endregion

                                for (var k = 0; k < dtExpenseVoucher.Rows.Count; k++)
                                {
                                    var depositDetail = new DepositDetailModel
                                    {
                                        AccountingObjectId = dtExpenseVoucher.Rows[k]["objectid"] == null ? null :
                                                    Model.GetIdByCode("AccountingObject",
                                                        "AccountingObjectID", "AccountingObjectCode",
                                                        dtExpenseVoucher.Rows[k]["objectid"].ToString().Trim()),
                                        AccountNumber = dtExpenseVoucher.Rows[k]["debitaccount"].ToString().Trim(),
                                        CorrespondingAccountNumber =
                                            dtExpenseVoucher.Rows[k]["creditaccount"].ToString().Trim(),
                                        AmountExchange =
                                            decimal.Parse(dtExpenseVoucher.Rows[k]["amount"].ToString().Trim()),
                                        AmountOc =
                                            decimal.Parse(dtExpenseVoucher.Rows[k]["fcamount"].ToString().Trim()),
                                        AutoBusinessId = null,
                                        BudgetItemCode = dtExpenseVoucher.Rows[k]["budgetitemid"] == null ? null : dtExpenseVoucher.Rows[k]["budgetitemid"].ToString().Trim(),
                                        BudgetSourceCode = dtExpenseVoucher.Rows[k]["capitalid"] == null ? null : dtExpenseVoucher.Rows[k]["capitalid"].ToString().Trim(),
                                        Description = dtExpenseVoucher.Rows[k]["description"] == null ? "" : dtExpenseVoucher.Rows[k]["description"].ToString().TrimEnd(),
                                        MergerFundId = null,
                                        ProjectId = null,
                                        DepartmentId = null,
                                    };
                                    if (dtExpenseVoucher.Rows[k]["vouchertype"] != null)
                                    {
                                        if (int.Parse(dtExpenseVoucher.Rows[k]["vouchertype"].ToString()) != 0)
                                            depositDetail.VoucherTypeId =
                                                int.Parse(dtExpenseVoucher.Rows[k]["vouchertype"].ToString());
                                        else
                                            depositDetail.VoucherTypeId = null;
                                    }
                                    else depositDetail.VoucherTypeId = null;
                                    depositDetailVouchers.Add(depositDetail);
                                }

                                voucher.DepositDetails = depositDetailVouchers;
                                Model.AddDeposit(voucher);
                            }
                            break;

                        #endregion

                        #region InputInventory

                        case "InputInventory":
                            if (Model.GetItemTransactionVoucherByRefTypeId(400).Count > 0)
                            {
                                break;
                            }
                            for (var j = 0; j < dt.Rows.Count; j++)
                            {
                                var selectClaus = "SELECT * FROM JOURENTRYDETAIL WHERE refid = '" +
                                                  dt.Rows[j]["refid"].ToString().Trim() + "' AND reftype ='400' ";
                                var dtInputInventoryVoucher = GetData(selectClaus);
                                ConvertFontData(ref dtInputInventoryVoucher, "description");
                                var itemTransactionDetailVouchers = new List<ItemTransactionDetailModel>();

                                var voucher = new ItemTransactionModel
                                {
                                    AccountingObjectType = int.Parse(dt.Rows[j]["objecttype"].ToString().Trim()),
                                    RefTypeId = 400,
                                    RefNo = dt.Rows[j]["refno"].ToString().Trim(),
                                    RefDate = DateTime.Parse(dt.Rows[j]["refdate"].ToString().Trim()),
                                    PostedDate = DateTime.Parse(dt.Rows[j]["postdate"].ToString().Trim()),
                                    Trader = dt.Rows[j]["contactname"] == null ? "" : dt.Rows[j]["contactname"].ToString().Trim(),
                                    CurrencyCode = dt.Rows[j]["ccyid"].ToString().Trim(),
                                    TotalAmount = decimal.Parse(dt.Rows[j]["fctotalamount"].ToString().Trim()),
                                    ExchangeRate = decimal.Parse(dt.Rows[j]["exchangerate"].ToString().Trim()),
                                    TotalAmountExchange = decimal.Parse(dt.Rows[j]["totalamount"].ToString().Trim()),
                                    JournalMemo = dt.Rows[j]["comment"] == null ? "" : dt.Rows[j]["comment"].ToString().TrimEnd(),
                                    ItemTransactionDetails = itemTransactionDetailVouchers,
                                    DocumentInclude = "",
                                    IsCalculatePrice = true,
                                    TaxCode = null
                                };
                                if (dt.Rows[j]["StockId"] != null)
                                {
                                    if (dt.Rows[j]["StockId"].ToString().Trim() != "")
                                    {
                                        voucher.StockId = (int)Model.GetIdByCode("Stock", "StockID", "StockCode",
                                            dt.Rows[j]["StockId"].ToString().Trim());
                                    }
                                }
                                if (dt.Rows[j]["objecttype"] != null)
                                {
                                    if (int.Parse(dt.Rows[j]["objecttype"].ToString().Trim()) == 1) // Khách hàng
                                    {
                                        voucher.AccountingObjectType = 3;
                                        voucher.AccountingObjectId = null;
                                        voucher.CustomerId = null;
                                        voucher.VendorId = null;
                                        voucher.EmployeeId = null;
                                    }
                                    else if (int.Parse(dt.Rows[j]["objecttype"].ToString().Trim()) == 2)
                                    // Nha cung cap
                                    {
                                        voucher.AccountingObjectType = 0;
                                        voucher.AccountingObjectId = null;
                                        voucher.CustomerId = null;
                                        if (dt.Rows[j]["objectid"] != null)
                                        {
                                            if (dt.Rows[j]["objectid"].ToString().Trim() != "")
                                            {
                                                voucher.VendorId = Model.GetIdByCode("Vendor", "VendorID",
                                                    "VendorCode",
                                                    dt.Rows[j]["objectid"].ToString().Trim());
                                            }
                                            else voucher.VendorId = null;
                                        }
                                        else voucher.VendorId = null;
                                        voucher.EmployeeId = null;
                                    }
                                    else if (int.Parse(dt.Rows[j]["objecttype"].ToString().Trim()) == 3)
                                    // Nhan vien
                                    {
                                        voucher.AccountingObjectType = 1;
                                        voucher.AccountingObjectId = null;
                                        voucher.CustomerId = null;
                                        voucher.VendorId = null;
                                        if (dt.Rows[j]["objectid"] != null)
                                        {
                                            if (dt.Rows[j]["objectid"].ToString().Trim() != "")
                                            {
                                                voucher.EmployeeId = Model.GetIdByCode("Employee",
                                                    "EmployeeID",
                                                    "EmployeeCode",
                                                    dt.Rows[j]["objectid"].ToString().Trim());
                                            }
                                            else voucher.EmployeeId = null;
                                        }
                                        else voucher.EmployeeId = null;

                                    }
                                    else // đối tượng khác
                                    {
                                        if (dt.Rows[j]["objectid"] != null)
                                        {
                                            if (dt.Rows[j]["objectid"].ToString().Trim() != "")
                                            {
                                                voucher.AccountingObjectId =
                                                    Model.GetIdByCode("AccountingObject",
                                                        "AccountingObjectID", "AccountingObjectCode",
                                                        dt.Rows[j]["objectid"].ToString().Trim());
                                            }
                                            else voucher.AccountingObjectId = null;
                                        }
                                        else voucher.AccountingObjectId = null;
                                        voucher.AccountingObjectType = 2;
                                        voucher.CustomerId = null;
                                        voucher.VendorId = null;
                                        voucher.EmployeeId = null;
                                    }
                                }
                                for (var k = 0; k < dtInputInventoryVoucher.Rows.Count; k++)
                                {
                                    var itemTransactionDetail = new ItemTransactionDetailModel
                                    {
                                        AccountingObjectId = dtInputInventoryVoucher.Rows[k]["objectid"] == null ? null :
                                                    Model.GetIdByCode("AccountingObject",
                                                        "AccountingObjectID", "AccountingObjectCode",
                                                        dtInputInventoryVoucher.Rows[k]["objectid"].ToString().Trim()),
                                        AccountNumber =
                                            dtInputInventoryVoucher.Rows[k]["debitaccount"].ToString().Trim(),
                                        CorrespondingAccountNumber =
                                            dtInputInventoryVoucher.Rows[k]["creditaccount"].ToString().Trim(),
                                        AmountExchange =
                                            decimal.Parse(
                                                dtInputInventoryVoucher.Rows[k]["amount"].ToString().Trim()),
                                        AmountOc =
                                            decimal.Parse(
                                                dtInputInventoryVoucher.Rows[k]["fcamount"].ToString().Trim()),
                                        AutoBusinessId = null,
                                        BudgetItemCode = dtInputInventoryVoucher.Rows[k]["budgetitemid"] == null ? null :
                                            dtInputInventoryVoucher.Rows[k]["budgetitemid"].ToString().Trim(),
                                        BudgetSourceCode = dtInputInventoryVoucher.Rows[k]["capitalid"] == null ? null :
                                            dtInputInventoryVoucher.Rows[k]["capitalid"].ToString().Trim(),
                                        Description = dtInputInventoryVoucher.Rows[k]["description"] == null ? "" :
                                            dtInputInventoryVoucher.Rows[k]["description"].ToString().TrimEnd(),
                                        MergerFundId = null,
                                        ProjectId = null,
                                        InventoryItemId =
                                            (int)
                                                Model.GetIdByCode("InventoryItem", "InventoryItemID",
                                                    "InventoryItemCode",
                                                    dtInputInventoryVoucher.Rows[k]["itemid"].ToString().Trim()),
                                        Price =
                                            decimal.Parse(
                                                dtInputInventoryVoucher.Rows[k]["fcunitprice"].ToString().Trim()),
                                        PriceExchange =
                                            decimal.Parse(
                                                dtInputInventoryVoucher.Rows[k]["unitprice"].ToString().Trim()),
                                        Quantity =
                                            (dtInputInventoryVoucher.Rows[k]["quantity"] != null)
                                                ? (int)
                                                    decimal.Parse(
                                                        dtInputInventoryVoucher.Rows[k]["quantity"].ToString())
                                                : 0
                                    };
                                    if (dtInputInventoryVoucher.Rows[k]["vouchertype"] != null)
                                    {
                                        if (int.Parse(dtInputInventoryVoucher.Rows[k]["vouchertype"].ToString()) != 0)
                                            itemTransactionDetail.VoucherTypeId =
                                                int.Parse(dtInputInventoryVoucher.Rows[k]["vouchertype"].ToString());
                                        else
                                            itemTransactionDetail.VoucherTypeId = null;
                                    }
                                    else itemTransactionDetail.VoucherTypeId = null;
                                    itemTransactionDetailVouchers.Add(itemTransactionDetail);
                                }

                                voucher.ItemTransactionDetails = itemTransactionDetailVouchers;
                                Model.AddItemTransactionVoucher(voucher, false);
                            }
                            break;

                        #endregion

                        #region OutputInventory

                        case "OutputInventory":
                            if (Model.GetItemTransactionVoucherByRefTypeId(401).Count > 0)
                            {
                                break;
                            }
                            for (var j = 0; j < dt.Rows.Count; j++)
                            {
                                var selectClaus = "SELECT * FROM JOURENTRYDETAIL WHERE refid = '" +
                                                  dt.Rows[j]["refid"].ToString().Trim() + "' AND reftype ='401' ";
                                var dtOutputInventoryVoucher = GetData(selectClaus);
                                ConvertFontData(ref dtOutputInventoryVoucher, "description");
                                var itemTransactionDetailVouchers = new List<ItemTransactionDetailModel>();

                                var voucher = new ItemTransactionModel
                                {
                                    AccountingObjectType = int.Parse(dt.Rows[j]["objecttype"].ToString().Trim()),
                                    RefTypeId = 401,
                                    RefNo = dt.Rows[j]["refno"].ToString().Trim(),
                                    RefDate = DateTime.Parse(dt.Rows[j]["refdate"].ToString().Trim()),
                                    PostedDate = DateTime.Parse(dt.Rows[j]["postdate"].ToString().Trim()),
                                    Trader = dt.Rows[j]["contactname"] == null ? "" : dt.Rows[j]["contactname"].ToString().Trim(),
                                    CurrencyCode = dt.Rows[j]["ccyid"].ToString().Trim(),
                                    TotalAmount = decimal.Parse(dt.Rows[j]["fctotalamount"].ToString().Trim()),
                                    ExchangeRate = decimal.Parse(dt.Rows[j]["exchangerate"].ToString().Trim()),
                                    TotalAmountExchange = decimal.Parse(dt.Rows[j]["totalamount"].ToString().Trim()),
                                    JournalMemo = dt.Rows[j]["comment"] == null ? "" : dt.Rows[j]["comment"].ToString().TrimEnd(),
                                    ItemTransactionDetails = itemTransactionDetailVouchers,
                                    DocumentInclude = "",
                                    IsCalculatePrice = true,
                                    TaxCode = null
                                };
                                if (dt.Rows[j]["StockId"] != null)
                                {
                                    if (dt.Rows[j]["StockId"].ToString().Trim() != "")
                                    {
                                        voucher.StockId = (int)Model.GetIdByCode("Stock", "StockID", "StockCode",
                                            dt.Rows[j]["StockId"].ToString().Trim());
                                    }
                                }
                                if (dt.Rows[j]["objecttype"] != null)
                                {
                                    if (int.Parse(dt.Rows[j]["objecttype"].ToString().Trim()) == 1) // Khách hàng
                                    {
                                        voucher.AccountingObjectType = 3;
                                        voucher.AccountingObjectId = null;
                                        voucher.CustomerId = null;
                                        voucher.VendorId = null;
                                        voucher.EmployeeId = null;
                                    }
                                    else if (int.Parse(dt.Rows[j]["objecttype"].ToString().Trim()) == 2)
                                    // Nha cung cap
                                    {
                                        voucher.AccountingObjectType = 0;
                                        voucher.AccountingObjectId = null;
                                        voucher.CustomerId = null;
                                        if (dt.Rows[j]["objectid"] != null)
                                        {
                                            if (dt.Rows[j]["objectid"].ToString().Trim() != "")
                                            {
                                                voucher.VendorId = Model.GetIdByCode("Vendor", "VendorID",
                                                    "VendorCode",
                                                    dt.Rows[j]["objectid"].ToString().Trim());
                                            }
                                            else voucher.VendorId = null;
                                        }
                                        else voucher.VendorId = null;
                                        voucher.EmployeeId = null;
                                    }
                                    else if (int.Parse(dt.Rows[j]["objecttype"].ToString().Trim()) == 3)
                                    // Nhan vien
                                    {
                                        voucher.AccountingObjectType = 1;
                                        voucher.AccountingObjectId = null;
                                        voucher.CustomerId = null;
                                        voucher.VendorId = null;
                                        if (dt.Rows[j]["objectid"] != null)
                                        {
                                            if (dt.Rows[j]["objectid"].ToString().Trim() != "")
                                            {
                                                voucher.EmployeeId = Model.GetIdByCode("Employee",
                                                    "EmployeeID",
                                                    "EmployeeCode",
                                                    dt.Rows[j]["objectid"].ToString().Trim());
                                            }
                                            else voucher.EmployeeId = null;
                                        }
                                        else voucher.EmployeeId = null;

                                    }
                                    else // đối tượng khác
                                    {
                                        if (dt.Rows[j]["objectid"] != null)
                                        {
                                            if (dt.Rows[j]["objectid"].ToString().Trim() != "")
                                            {
                                                voucher.AccountingObjectId =
                                                    Model.GetIdByCode("AccountingObject",
                                                        "AccountingObjectID", "AccountingObjectCode",
                                                        dt.Rows[j]["objectid"].ToString().Trim());
                                            }
                                            else voucher.AccountingObjectId = null;
                                        }
                                        else voucher.AccountingObjectId = null;
                                        voucher.AccountingObjectType = 2;
                                        voucher.CustomerId = null;
                                        voucher.VendorId = null;
                                        voucher.EmployeeId = null;
                                    }
                                }
                                for (var k = 0; k < dtOutputInventoryVoucher.Rows.Count; k++)
                                {
                                    var itemTransactionDetail = new ItemTransactionDetailModel
                                    {
                                        AccountingObjectId = dtOutputInventoryVoucher.Rows[k]["objectid"] == null ? null :
                                                    Model.GetIdByCode("AccountingObject",
                                                        "AccountingObjectID", "AccountingObjectCode",
                                                        dtOutputInventoryVoucher.Rows[k]["objectid"].ToString().Trim()),
                                        AccountNumber =
                                            dtOutputInventoryVoucher.Rows[k]["debitaccount"].ToString().Trim(),
                                        CorrespondingAccountNumber =
                                            dtOutputInventoryVoucher.Rows[k]["creditaccount"].ToString().Trim(),
                                        AmountExchange =
                                            decimal.Parse(
                                                dtOutputInventoryVoucher.Rows[k]["amount"].ToString().Trim()),
                                        AmountOc =
                                            decimal.Parse(
                                                dtOutputInventoryVoucher.Rows[k]["fcamount"].ToString().Trim()),
                                        AutoBusinessId = null,
                                        BudgetItemCode = dtOutputInventoryVoucher.Rows[k]["budgetitemid"] == null ? null :
                                            dtOutputInventoryVoucher.Rows[k]["budgetitemid"].ToString().Trim(),
                                        BudgetSourceCode = dtOutputInventoryVoucher.Rows[k]["capitalid"] == null ? null :
                                            dtOutputInventoryVoucher.Rows[k]["capitalid"].ToString().Trim(),
                                        Description = dtOutputInventoryVoucher.Rows[k]["description"] == null ? "" :
                                            dtOutputInventoryVoucher.Rows[k]["description"].ToString().TrimEnd(),
                                        MergerFundId = null,
                                        ProjectId = null,
                                        InventoryItemId =
                                            (int)
                                                Model.GetIdByCode("InventoryItem", "InventoryItemID",
                                                    "InventoryItemCode",
                                                    dtOutputInventoryVoucher.Rows[k]["itemid"].ToString().Trim()),
                                        Price =
                                            decimal.Parse(
                                                dtOutputInventoryVoucher.Rows[k]["fcunitprice"].ToString().Trim()),
                                        PriceExchange =
                                            decimal.Parse(
                                                dtOutputInventoryVoucher.Rows[k]["unitprice"].ToString().Trim()),
                                        Quantity =
                                            (dtOutputInventoryVoucher.Rows[k]["quantity"] != null)
                                                ? (int)
                                                    decimal.Parse(
                                                        dtOutputInventoryVoucher.Rows[k]["quantity"].ToString())
                                                : 0
                                    };
                                    if (dtOutputInventoryVoucher.Rows[k]["vouchertype"] != null)
                                    {
                                        if (int.Parse(dtOutputInventoryVoucher.Rows[k]["vouchertype"].ToString()) != 0)
                                            itemTransactionDetail.VoucherTypeId =
                                                int.Parse(dtOutputInventoryVoucher.Rows[k]["vouchertype"].ToString());
                                        else
                                            itemTransactionDetail.VoucherTypeId = null;
                                    }
                                    else itemTransactionDetail.VoucherTypeId = null;
                                    itemTransactionDetailVouchers.Add(itemTransactionDetail);
                                }

                                voucher.ItemTransactionDetails = itemTransactionDetailVouchers;
                                Model.AddItemTransactionVoucher(voucher, false);
                            }
                            break;

                        #endregion

                        #region FixedAssetIncrease

                        case "FixedAssetIncrease":
                            if (Model.GetFixedAssetIncrements().Count > 0)
                            {
                                break;
                            }
                            for (var j = 0; j < dt.Rows.Count; j++)
                            {
                                var selectClaus = "SELECT * FROM JOURENTRYDETAIL WHERE refid = '" +
                                                  dt.Rows[j]["refid"].ToString().Trim() + "' AND reftype ='500' ";
                                var dtFixedAssetIncrementDetailVoucher = GetData(selectClaus);
                                ConvertFontData(ref dtFixedAssetIncrementDetailVoucher, "description");
                                var fixedAssetIncrementDetailVouchers = new List<FixedAssetIncrementDetailModel>();

                                var voucher = new FixedAssetIncrementModel
                                {
                                    AccountingObjectType = int.Parse(dt.Rows[j]["objecttype"].ToString().Trim()),
                                    RefTypeId = 500,
                                    RefNo = dt.Rows[j]["refno"].ToString().Trim(),
                                    RefDate = dt.Rows[j]["refdate"].ToString().Trim(),
                                    PostedDate = dt.Rows[j]["postdate"].ToString().Trim(),
                                    CurrencyCode = dt.Rows[j]["ccyid"].ToString().Trim(),
                                    TotalAmountOC = decimal.Parse(dt.Rows[j]["fctotalamount"].ToString().Trim()),
                                    ExchangeRate = decimal.Parse(dt.Rows[j]["exchangerate"].ToString().Trim()),
                                    TotalAmountExchange = decimal.Parse(dt.Rows[j]["totalamount"].ToString().Trim()),
                                    JournalMemo = dt.Rows[j]["comment"] == null ? "" : dt.Rows[j]["comment"].ToString().TrimEnd(),
                                    FixedAssetIncrementDetails = fixedAssetIncrementDetailVouchers,
                                };
                                if (dt.Rows[j]["objecttype"] != null)
                                {
                                    if (int.Parse(dt.Rows[j]["objecttype"].ToString().Trim()) == 1) // Khách hàng
                                    {
                                        voucher.AccountingObjectType = 3;
                                        voucher.AccountingObjectId = null;
                                        voucher.CustomerId = null;
                                        voucher.VendorId = null;
                                        voucher.EmployeeId = null;
                                    }
                                    else if (int.Parse(dt.Rows[j]["objecttype"].ToString().Trim()) == 2)
                                    // Nha cung cap
                                    {
                                        voucher.AccountingObjectType = 0;
                                        voucher.AccountingObjectId = null;
                                        voucher.CustomerId = null;
                                        if (dt.Rows[j]["objectid"] != null)
                                        {
                                            if (dt.Rows[j]["objectid"].ToString().Trim() != "")
                                            {
                                                voucher.VendorId = Model.GetIdByCode("Vendor", "VendorID",
                                                    "VendorCode",
                                                    dt.Rows[j]["objectid"].ToString().Trim());
                                            }
                                            else voucher.VendorId = null;
                                        }
                                        else voucher.VendorId = null;
                                        voucher.EmployeeId = null;
                                    }
                                    else if (int.Parse(dt.Rows[j]["objecttype"].ToString().Trim()) == 3)
                                    // Nhan vien
                                    {
                                        voucher.AccountingObjectType = 1;
                                        voucher.AccountingObjectId = null;
                                        voucher.CustomerId = null;
                                        voucher.VendorId = null;
                                        if (dt.Rows[j]["objectid"] != null)
                                        {
                                            if (dt.Rows[j]["objectid"].ToString().Trim() != "")
                                            {
                                                voucher.EmployeeId = Model.GetIdByCode("Employee",
                                                    "EmployeeID",
                                                    "EmployeeCode",
                                                    dt.Rows[j]["objectid"].ToString().Trim());
                                            }
                                            else voucher.EmployeeId = null;
                                        }
                                        else voucher.EmployeeId = null;

                                    }
                                    else // đối tượng khác
                                    {
                                        if (dt.Rows[j]["objectid"] != null)
                                        {
                                            if (dt.Rows[j]["objectid"].ToString().Trim() != "")
                                            {
                                                voucher.AccountingObjectId =
                                                    Model.GetIdByCode("AccountingObject",
                                                        "AccountingObjectID", "AccountingObjectCode",
                                                        dt.Rows[j]["objectid"].ToString().Trim());
                                            }
                                            else voucher.AccountingObjectId = null;
                                        }
                                        else voucher.AccountingObjectId = null;
                                        voucher.AccountingObjectType = 2;
                                        voucher.CustomerId = null;
                                        voucher.VendorId = null;
                                        voucher.EmployeeId = null;
                                    }
                                }
                                for (var k = 0; k < dtFixedAssetIncrementDetailVoucher.Rows.Count; k++)
                                {
                                    var fixedAssetId = Model.GetIdByCode("FixedAsset", "FixedAssetID", "FixedAssetCode",
                                        dtFixedAssetIncrementDetailVoucher.Rows[k]["fixedassetid"].ToString().Trim());
                                    fixedAssetIncrementDetailVouchers.Add(new FixedAssetIncrementDetailModel
                                    {
                                        AccountingObjectId = dtFixedAssetIncrementDetailVoucher.Rows[k]["objectid"] == null ? null :
                                                    Model.GetIdByCode("AccountingObject",
                                                        "AccountingObjectID", "AccountingObjectCode",
                                                        dtFixedAssetIncrementDetailVoucher.Rows[k]["objectid"].ToString().Trim()),
                                        AccountNumber =
                                            dtFixedAssetIncrementDetailVoucher.Rows[k]["debitaccount"].ToString()
                                                .Trim(),
                                        CorrespondingAccountNumber =
                                            dtFixedAssetIncrementDetailVoucher.Rows[k]["creditaccount"].ToString()
                                                .Trim(),
                                        AmountExchange =
                                            decimal.Parse(
                                                dtFixedAssetIncrementDetailVoucher.Rows[k]["amount"].ToString()
                                                    .Trim()),
                                        AmountOC =
                                            decimal.Parse(
                                                dtFixedAssetIncrementDetailVoucher.Rows[k]["fcamount"].ToString()
                                                    .Trim()),
                                        AutoBusinessId = null,
                                        BudgetItemCode = dtFixedAssetIncrementDetailVoucher.Rows[k]["budgetitemid"] == null ? null :
                                            dtFixedAssetIncrementDetailVoucher.Rows[k]["budgetitemid"].ToString()
                                                .Trim(),
                                        BudgetSourceCode = dtFixedAssetIncrementDetailVoucher.Rows[k]["capitalid"] == null ? null :
                                            dtFixedAssetIncrementDetailVoucher.Rows[k]["capitalid"].ToString()
                                                .Trim(),
                                        Description = dtFixedAssetIncrementDetailVoucher.Rows[k]["description"] == null ? "" :
                                            dtFixedAssetIncrementDetailVoucher.Rows[k]["description"].ToString()
                                                .TrimEnd(),
                                        VoucherTypeId = null,
                                        ProjectId = null,
                                        FixedAssetId = fixedAssetId == null ? 0 : fixedAssetId,
                                        UnitPriceOC =
                                            decimal.Parse(
                                                dtFixedAssetIncrementDetailVoucher.Rows[k]["fcunitprice"].ToString()
                                                    .Trim()),
                                        UnitPriceExchange =
                                            decimal.Parse(
                                                dtFixedAssetIncrementDetailVoucher.Rows[k]["unitprice"].ToString()
                                                    .Trim()),
                                        Quantity =
                                            (dtFixedAssetIncrementDetailVoucher.Rows[k]["quantity"] != null)
                                                ? (int)
                                                    decimal.Parse(
                                                        dtFixedAssetIncrementDetailVoucher.Rows[k]["quantity"]
                                                            .ToString())
                                                : 0,
                                        DepartmentId =
                                            Model.GetIdByCode("Department", "DepartmentID", "DepartmentCode",
                                                dtFixedAssetIncrementDetailVoucher.Rows[k]["departid"].ToString()
                                                    .Trim()),
                                    });
                                }

                                voucher.FixedAssetIncrementDetails = fixedAssetIncrementDetailVouchers;
                                Model.AddFixedAssetIncrement(voucher, false);
                            }
                            break;

                        #endregion

                        #region FixedAssetDecrease

                        case "FixedAssetDecrease":
                            if (Model.GetFixedAssetDecrements().Count > 0)
                            {
                                break;
                            }
                            for (var j = 0; j < dt.Rows.Count; j++)
                            {
                                var selectClaus = "SELECT * FROM JOURENTRYDETAIL WHERE refid = '" +
                                                  dt.Rows[j]["refid"].ToString().Trim() + "' AND reftype ='501' ";
                                var dtFixedAssetDecrementDetailVoucher = GetData(selectClaus);
                                ConvertFontData(ref dtFixedAssetDecrementDetailVoucher, "description");
                                var fixedAssetDecrementDetailVouchers = new List<FixedAssetDecrementDetailModel>();

                                var voucher = new FixedAssetDecrementModel
                                {
                                    AccountingObjectType = int.Parse(dt.Rows[j]["objecttype"].ToString().Trim()),
                                    RefTypeId = 501,
                                    RefNo = dt.Rows[j]["refno"].ToString().Trim(),
                                    RefDate = dt.Rows[j]["refdate"].ToString().Trim(),
                                    PostedDate = dt.Rows[j]["postdate"].ToString().Trim(),
                                    CurrencyCode = dt.Rows[j]["ccyid"].ToString().Trim(),
                                    TotalAmountOC = decimal.Parse(dt.Rows[j]["fctotalamount"].ToString().Trim()),
                                    ExchangeRate = decimal.Parse(dt.Rows[j]["exchangerate"].ToString().Trim()),
                                    TotalAmountExchange = decimal.Parse(dt.Rows[j]["totalamount"].ToString().Trim()),
                                    JournalMemo = dt.Rows[j]["comment"] == null ? "" : dt.Rows[j]["comment"].ToString().Trim(),
                                    FixedAssetDecrementDetails = fixedAssetDecrementDetailVouchers,
                                };
                                if (dt.Rows[j]["objecttype"] != null)
                                {
                                    if (int.Parse(dt.Rows[j]["objecttype"].ToString().Trim()) == 1) // Khách hàng
                                    {
                                        voucher.AccountingObjectType = 3;
                                        voucher.AccountingObjectId = null;
                                        voucher.CustomerId = null;
                                        voucher.VendorId = null;
                                        voucher.EmployeeId = null;
                                    }
                                    else if (int.Parse(dt.Rows[j]["objecttype"].ToString().Trim()) == 2)
                                    // Nha cung cap
                                    {
                                        voucher.AccountingObjectType = 0;
                                        voucher.AccountingObjectId = null;
                                        voucher.CustomerId = null;
                                        if (dt.Rows[j]["objectid"] != null)
                                        {
                                            if (dt.Rows[j]["objectid"].ToString().Trim() != "")
                                            {
                                                voucher.VendorId = Model.GetIdByCode("Vendor", "VendorID",
                                                    "VendorCode",
                                                    dt.Rows[j]["objectid"].ToString().Trim());
                                            }
                                            else voucher.VendorId = null;
                                        }
                                        else voucher.VendorId = null;
                                        voucher.EmployeeId = null;
                                    }
                                    else if (int.Parse(dt.Rows[j]["objecttype"].ToString().Trim()) == 3)
                                    // Nhan vien
                                    {
                                        voucher.AccountingObjectType = 1;
                                        voucher.AccountingObjectId = null;
                                        voucher.CustomerId = null;
                                        voucher.VendorId = null;
                                        if (dt.Rows[j]["objectid"] != null)
                                        {
                                            if (dt.Rows[j]["objectid"].ToString().Trim() != "")
                                            {
                                                voucher.EmployeeId = Model.GetIdByCode("Employee",
                                                    "EmployeeID",
                                                    "EmployeeCode",
                                                    dt.Rows[j]["objectid"].ToString().Trim());
                                            }
                                            else voucher.EmployeeId = null;
                                        }
                                        else voucher.EmployeeId = null;

                                    }
                                    else // đối tượng khác
                                    {
                                        if (dt.Rows[j]["objectid"] != null)
                                        {
                                            if (dt.Rows[j]["objectid"].ToString().Trim() != "")
                                            {
                                                voucher.AccountingObjectId =
                                                    Model.GetIdByCode("AccountingObject",
                                                        "AccountingObjectID", "AccountingObjectCode",
                                                        dt.Rows[j]["objectid"].ToString().Trim());
                                            }
                                            else voucher.AccountingObjectId = null;
                                        }
                                        else voucher.AccountingObjectId = null;
                                        voucher.AccountingObjectType = 2;
                                        voucher.CustomerId = null;
                                        voucher.VendorId = null;
                                        voucher.EmployeeId = null;
                                    }
                                }
                                for (var k = 0; k < dtFixedAssetDecrementDetailVoucher.Rows.Count; k++)
                                {
                                    var fixedAssetId = Model.GetIdByCode("FixedAsset", "FixedAssetID", "FixedAssetCode",
                                        dtFixedAssetDecrementDetailVoucher.Rows[k]["fixedassetid"].ToString().Trim());
                                    var description = dtFixedAssetDecrementDetailVoucher.Rows[k]["description"] == null
                                        ? ""
                                        : dtFixedAssetDecrementDetailVoucher.Rows[k]["description"].ToString();

                                    while (description.Contains("  "))
                                    {
                                        description = description.Replace("  ", " ");
                                    }

                                    fixedAssetDecrementDetailVouchers.Add(new FixedAssetDecrementDetailModel
                                    {
                                        AccountingObjectId = dtFixedAssetDecrementDetailVoucher.Rows[k]["objectid"] == null ? null :
                                                   Model.GetIdByCode("AccountingObject",
                                                       "AccountingObjectID", "AccountingObjectCode",
                                                       dtFixedAssetDecrementDetailVoucher.Rows[k]["objectid"].ToString().Trim()),
                                        AccountNumber =
                                            dtFixedAssetDecrementDetailVoucher.Rows[k]["debitaccount"].ToString()
                                                .Trim(),
                                        CorrespondingAccountNumber =
                                            dtFixedAssetDecrementDetailVoucher.Rows[k]["creditaccount"].ToString()
                                                .Trim(),
                                        AmountExchange =
                                            decimal.Parse(
                                                dtFixedAssetDecrementDetailVoucher.Rows[k]["amount"].ToString()
                                                    .Trim()),
                                        AmountOC =
                                            decimal.Parse(
                                                dtFixedAssetDecrementDetailVoucher.Rows[k]["fcamount"].ToString()
                                                    .Trim()),
                                        AutoBusinessId = null,
                                        BudgetItemCode = dtFixedAssetDecrementDetailVoucher.Rows[k]["budgetitemid"] == null ? null :
                                            dtFixedAssetDecrementDetailVoucher.Rows[k]["budgetitemid"].ToString()
                                                .Trim(),
                                        BudgetSourceCode = dtFixedAssetDecrementDetailVoucher.Rows[k]["capitalid"] == null ? null :
                                            dtFixedAssetDecrementDetailVoucher.Rows[k]["capitalid"].ToString()
                                                .Trim(),
                                        Description = description,
                                        VoucherTypeId = null,
                                        ProjectId = null,
                                        FixedAssetId = fixedAssetId == null ? 0 : (int)fixedAssetId,
                                        UnitPriceOC =
                                            decimal.Parse(
                                                dtFixedAssetDecrementDetailVoucher.Rows[k]["fcunitprice"].ToString()
                                                    .Trim()),
                                        UnitPriceExchange =
                                            decimal.Parse(
                                                dtFixedAssetDecrementDetailVoucher.Rows[k]["unitprice"].ToString()
                                                    .Trim()),
                                        Quantity =
                                            (dtFixedAssetDecrementDetailVoucher.Rows[k]["quantity"] != null)
                                                ? (int)
                                                    decimal.Parse(
                                                        dtFixedAssetDecrementDetailVoucher.Rows[k]["quantity"]
                                                            .ToString())
                                                : 0,
                                        DepartmentId =
                                            Model.GetIdByCode("Department", "DepartmentID", "DepartmentCode",
                                                dtFixedAssetDecrementDetailVoucher.Rows[k]["departid"].ToString()
                                                    .Trim()),
                                    });
                                }

                                voucher.FixedAssetDecrementDetails = fixedAssetDecrementDetailVouchers;
                                Model.AddFixedAssetDecrement(voucher, false);
                            }
                            break;

                        #endregion

                        #region FixedAssetArmortization

                        case "FixedAssetArmortization":
                            if (Model.GetFixedAssetArmortizations().Count > 0)
                            {
                                break;
                            }
                            for (var j = 0; j < dt.Rows.Count; j++)
                            {
                                var selectClaus = "SELECT * FROM JOURENTRYDETAIL WHERE refid = '" +
                                                  dt.Rows[j]["refid"].ToString().Trim() + "' AND reftype ='502' ";
                                var dtFixedAssetArmortizationDetailVoucher = GetData(selectClaus);
                                ConvertFontData(ref dtFixedAssetArmortizationDetailVoucher, "description");
                                var fixedAssetArmortizationDetailVouchers =
                                    new List<FixedAssetArmortizationDetailModel>();

                                var voucher = new FixedAssetArmortizationModel
                                {
                                    RefTypeId = 502,
                                    RefNo = dt.Rows[j]["refno"].ToString().Trim(),
                                    RefDate = dt.Rows[j]["refdate"].ToString().Trim(),
                                    PostedDate = dt.Rows[j]["postdate"].ToString().Trim(),
                                    TotalAmountOC = decimal.Parse(dt.Rows[j]["fctotalamount"].ToString().Trim()),
                                    TotalAmountExchange = decimal.Parse(dt.Rows[j]["totalamount"].ToString().Trim()),
                                    JournalMemo = dt.Rows[j]["comment"] == null ? "" : dt.Rows[j]["comment"].ToString().TrimEnd(),
                                    FixedAssetArmortizationDetails = fixedAssetArmortizationDetailVouchers,
                                };

                                for (var k = 0; k < dtFixedAssetArmortizationDetailVoucher.Rows.Count; k++)
                                {
                                    fixedAssetArmortizationDetailVouchers.Add(new FixedAssetArmortizationDetailModel
                                    {
                                        AccountNumber =
                                            dtFixedAssetArmortizationDetailVoucher.Rows[k]["debitaccount"].ToString()
                                                .Trim(),
                                        CorrespondingAccountNumber =
                                            dtFixedAssetArmortizationDetailVoucher.Rows[k]["creditaccount"].ToString
                                                ()
                                                .Trim(),
                                        AmountExchange =
                                            decimal.Parse(
                                                dtFixedAssetArmortizationDetailVoucher.Rows[k]["amount"].ToString()
                                                    .Trim()),
                                        AmountOC =
                                            decimal.Parse(
                                                dtFixedAssetArmortizationDetailVoucher.Rows[k]["fcamount"].ToString()
                                                    .Trim()),
                                        BudgetItemCode = dtFixedAssetArmortizationDetailVoucher.Rows[k]["budgetitemid"] == null ? null :
                                            dtFixedAssetArmortizationDetailVoucher.Rows[k]["budgetitemid"].ToString()
                                                .Trim(),
                                        BudgetSourceCode = dtFixedAssetArmortizationDetailVoucher.Rows[k]["capitalid"] == null ? null :
                                            dtFixedAssetArmortizationDetailVoucher.Rows[k]["capitalid"].ToString()
                                                .Trim(),
                                        Description = dtFixedAssetArmortizationDetailVoucher.Rows[k]["description"] == null ? "" :
                                            dtFixedAssetArmortizationDetailVoucher.Rows[k]["description"].ToString()
                                                .TrimEnd(),
                                        VoucherTypeId = null,
                                        ProjectId = null,
                                        FixedAssetId =
                                            (int)
                                                Model.GetIdByCode("FixedAsset", "FixedAssetID", "FixedAssetCode",
                                                    dtFixedAssetArmortizationDetailVoucher.Rows[k]["fixedassetid"]
                                                        .ToString().Trim()),
                                        Quantity =
                                            (dtFixedAssetArmortizationDetailVoucher.Rows[k]["quantity"] != null)
                                                ? (int)
                                                    decimal.Parse(
                                                        dtFixedAssetArmortizationDetailVoucher.Rows[k]["quantity"]
                                                            .ToString())
                                                : 0,
                                        DepartmentId =
                                            Model.GetIdByCode("Department", "DepartmentID", "DepartmentCode",
                                                dtFixedAssetArmortizationDetailVoucher.Rows[k]["departid"].ToString()
                                                    .Trim()),
                                        CurrencyCode =
                                            dtFixedAssetArmortizationDetailVoucher.Rows[k]["ccyid"].ToString()
                                                .Trim(),
                                        ExchangeRate =
                                            double.Parse(
                                                dtFixedAssetArmortizationDetailVoucher.Rows[k]["exchangerate"]
                                                    .ToString()
                                                    .Trim())
                                    });
                                }

                                voucher.FixedAssetArmortizationDetails = fixedAssetArmortizationDetailVouchers;
                                Model.AddFixedAssetArmortization(voucher);
                            }
                            break;

                        #endregion

                        #region GeneralVoucher

                        case "GeneralVoucher":
                            if (Model.GetGenverVoucherByRefTypeId(900).Count > 0)
                            {
                                break;
                            }
                            for (var j = 0; j < dt.Rows.Count; j++)
                            {
                                var selectClaus = "SELECT * FROM JOURENTRYDETAIL WHERE refid = '" +
                                                  dt.Rows[j]["refid"].ToString().Trim() + "' AND reftype ='900' ";
                                var dtGeneralDetailVoucher = GetData(selectClaus);
                                ConvertFontData(ref dtGeneralDetailVoucher, "description");
                                var generalDetailVouchers = new List<GeneralDetailModel>();

                                var voucher = new GeneralVocherModel
                                {
                                    RefTypeId = 900,
                                    RefNo = dt.Rows[j]["refno"].ToString().Trim(),
                                    RefDate = DateTime.Parse(dt.Rows[j]["refdate"].ToString().Trim()),
                                    PostedDate = DateTime.Parse(dt.Rows[j]["postdate"].ToString().Trim()),
                                    TotalAmountOc = decimal.Parse(dt.Rows[j]["fctotalamount"].ToString().Trim()),
                                    TotalAmountExchange = decimal.Parse(dt.Rows[j]["totalamount"].ToString().Trim()),
                                    JournalMemo = dt.Rows[j]["comment"] == null ? "" : dt.Rows[j]["comment"].ToString().TrimEnd(),
                                    GeneralVoucherDetails = generalDetailVouchers,
                                };

                                for (var k = 0; k < dtGeneralDetailVoucher.Rows.Count; k++)
                                {
                                    var general = new GeneralDetailModel
                                    {
                                        AccountNumber =
                                            dtGeneralDetailVoucher.Rows[k]["debitaccount"].ToString().Trim(),
                                        CorrespondingAccountNumber =
                                            dtGeneralDetailVoucher.Rows[k]["creditaccount"].ToString().Trim(),
                                        AmountExchange =
                                            decimal.Parse(dtGeneralDetailVoucher.Rows[k]["amount"].ToString().Trim()),
                                        AmountOc =
                                            decimal.Parse(
                                                dtGeneralDetailVoucher.Rows[k]["fcamount"].ToString().Trim()),
                                        BudgetItemCode = dtGeneralDetailVoucher.Rows[k]["budgetitemid"] == null ? null :
                                            dtGeneralDetailVoucher.Rows[k]["budgetitemid"].ToString().Trim(),
                                        BudgetSourceCode = dtGeneralDetailVoucher.Rows[k]["capitalid"] == null ? null :
                                            dtGeneralDetailVoucher.Rows[k]["capitalid"].ToString().Trim(),
                                        Description = dtGeneralDetailVoucher.Rows[k]["description"] == null ? "" :
                                            dtGeneralDetailVoucher.Rows[k]["description"].ToString().TrimEnd(),
                                        AccountingObjectId = dtGeneralDetailVoucher.Rows[k]["objectid"] == null ? null :
                                                Model.GetIdByCode("AccountingObject",
                                                    "AccountingObjectID", "AccountingObjectCode",
                                                    dtGeneralDetailVoucher.Rows[k]["objectid"].ToString().Trim()),
                                    };
                                    if (dtGeneralDetailVoucher.Rows[k]["vouchertype"] != null)
                                    {
                                        if (int.Parse(dtGeneralDetailVoucher.Rows[k]["vouchertype"].ToString()) != 0)
                                            general.VoucherTypeId =
                                                int.Parse(dtGeneralDetailVoucher.Rows[k]["vouchertype"].ToString());
                                        else
                                            general.VoucherTypeId = null;
                                    }
                                    else general.VoucherTypeId = null;

                                    general.ProjectId = null;
                                    general.DepartmentId = Model.GetIdByCode("Department", "DepartmentID",
                                        "DepartmentCode",
                                        dtGeneralDetailVoucher.Rows[k]["departid"].ToString().Trim());
                                    general.CurrencyCode = dtGeneralDetailVoucher.Rows[k]["ccyid"].ToString().Trim();
                                    general.ExchangeRate =
                                        decimal.Parse(
                                            dtGeneralDetailVoucher.Rows[k]["exchangerate"].ToString().Trim());
                                    general.EmployeeId = Model.GetIdByCode("Employee", "EmployeeId", "EmployeeCode",
                                        dtGeneralDetailVoucher.Rows[k]["employeeid"].ToString().Trim());
                                    general.CustomerId = null;
                                    general.InventoryItemId = null;
                                    general.VendorId = Model.GetIdByCode("Vendor", "VendorId", "VendorCode",
                                        dtGeneralDetailVoucher.Rows[k]["vendorid"].ToString().Trim());

                                    generalDetailVouchers.Add(general);
                                }

                                voucher.GeneralVoucherDetails = generalDetailVouchers;
                                Model.IsConvertData = true;
                                Model.AddGeneralVoucher(voucher);
                            }
                            break;

                            #endregion

                            #endregion
                    }
                    progressBarControl.PerformStep();
                    progressBarControl.Update();
                }
                progressBarControl.Position = progressBarControl.Properties.Maximum;
                progressBarControl.Update();
                XtraMessageBox.Show("Chuyển đổi dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                btnCancel.Text = ResourceHelper.GetResourceValueByName("Fisnish");
                return true;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                XtraMessageBox.Show(ex.Message + " " + destinationTableName);
                return false;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        /// <summary>
        /// Converts the balance.
        /// </summary>
        /// <param name="balanceDate">The balance date.</param>
        /// <returns></returns>
        private bool ConvertBalance(DateTime balanceDate)
        {
            //1.Chuyển đổi dữ liệu danh mục
            //2.Chuyển đổi số dư
            //Lấy tài khoản trong danh mục tài khoản
            //Kiểm tra tài khoản theo dõi chi tiết theo yếu tố nào
            //Nếu chi tiết là true, thì cộng vào điều kiện select, group
            //3.Lấy số phát sinh nếu có tính từ thời điểm balanceDate + 1

            //////////////////////////////////////////////////////////////////////
            //a. Lấy số dư tài khoản thường

            string destinationTableName = "";
            try
            {
                progressBarControl.Properties.Step = 1;
                progressBarControl.Properties.PercentView = true;
                progressBarControl.Properties.Maximum = lstConvertTable.Items.Count;
                progressBarControl.Properties.Minimum = 0;
                Cursor.Current = Cursors.WaitCursor;
                if (_convertData == null) return false;
                if (_convertData.Tables[0].Rows.Count <= 0) return false;

                for (var i = 0; i < lstConvertTable.Items.Count; i++)
                {
                    if (i == 0)
                    {
                        //Cập nhật lại một số thông tin trong bảng DbOption
                        if (!UpdateOption(balanceDate.ToShortDateString()))
                        {
                            XtraMessageBox.Show("Cập nhật thông tin dữ liệu bị lỗi!", "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            return false;
                        }
                    }

                    //0. Kiểm tra Option {0- Không tổng hợp, 1-Tổng hợp toàn bộ từ cũ vào mới}
                    //1. Lấy dữ liệu từ foxpro
                    //2. Chuyển đổi font chữ TCVN3 -> UNICODE
                    //3. Insert data vào MSSQL
                    var tableName = lstConvertTable.Items[i].ToString();
                    string queryString;
                    if (!string.IsNullOrEmpty(tableName))
                        queryString = "SELECT " + _convertData.Tables[0].Rows[i]["SourceField"] + " FROM " +
                                      tableName;
                    else
                        queryString = "SELECT " + _convertData.Tables[0].Rows[i]["SourceField"];

                    var whereClause = _convertData.Tables[0].Rows[i]["WhereClause"].ToString();
                    var tableDataType = Convert.ToInt16(_convertData.Tables[0].Rows[i]["TableDataType"]);
                    if (tableDataType == 2)
                    {
                        whereClause = whereClause + " AND postdate >= CTOD('" + balanceDate.Month + "/" + balanceDate.Day + "/" + balanceDate.Year + "')";
                    }

                    if (!string.IsNullOrEmpty(whereClause))
                        queryString = queryString + " WHERE " + whereClause;

                    var convertFields = _convertData.Tables[0].Rows[i]["SourceFieldConvertFont"].ToString();
                    var oldParent = int.Parse(_convertData.Tables[0].Rows[i]["OldParent"].ToString());
                    var newParent = int.Parse(_convertData.Tables[0].Rows[i]["NewParent"].ToString());
                    var oldActive = int.Parse(_convertData.Tables[0].Rows[i]["OldActive"].ToString());
                    var newActive = int.Parse(_convertData.Tables[0].Rows[i]["NewActive"].ToString());
                    var option = int.Parse(_convertData.Tables[0].Rows[i]["Option"].ToString());
                    if (option == 0) continue;

                    var dt = GetData(queryString);
                    if (tableDataType != 3)
                        if (dt == null || dt.Rows.Count <= 0) continue;
                    if (oldParent != newParent)
                    {
                        dt.Columns.Add("ID", typeof(int));
                        dt.Columns.Add("PID", typeof(int));
                        InitId(ref dt);
                        InitParent(ref dt);
                    }

                    ConvertFontData(ref dt, convertFields);
                    destinationTableName = _convertData.Tables[0].Rows[i]["DestinationTable"].ToString();
                    switch (destinationTableName)
                    {
                        #region Dictionaries

                        #region Department
                        case "Department":
                            //Check data existed
                            if (Model.GetDepartments().Count > 0)
                            {
                                break;
                            }
                            Model.ResetAutoIncrement("Department", 0);
                            for (var j = 0; j < dt.Rows.Count; j++)
                            {
                                var department = new DepartmentModel
                                {
                                    DepartmentId = int.Parse(dt.Rows[j]["ID"].ToString()),
                                    DepartmentCode = dt.Rows[j]["departid"].ToString().Trim(),
                                    DepartmentName = dt.Rows[j]["departname"].ToString().TrimEnd(),
                                    ParentId =
                                        dt.Rows[j]["PID"].ToString().Trim() == "" ? null : (int?)dt.Rows[j]["PID"],
                                    Description = dt.Rows[j]["note"].ToString().Trim(),
                                    IsActive = dt.Rows[j]["inactive"] != null && (bool)dt.Rows[j]["inactive"],
                                };
                                if (oldActive != newActive)
                                {
                                    var o = dt.Rows[j]["inactive"];
                                    if (o != null)
                                        department.IsActive = !(bool)o;
                                }
                                Model.AddDepartment(department);
                            }

                            break;
                        #endregion

                        #region Employee
                        case "Employee":
                            //Check data existed
                            if (Model.GetEmployees().Count > 0)
                            {
                                break;
                            }
                            for (var j = 0; j < dt.Rows.Count; j++)
                            {
                                string selectClaus = "SELECT * FROM EMPLOYEESETUP WHERE employeeid = '" +
                                                     dt.Rows[j]["employeeid"].ToString().Trim() + "'";
                                var dtEmployeePayItem = GetData(selectClaus);
                                var employeePayItems = new List<EmployeePayItemModel>();

                                var employee = new EmployeeModel
                                {
                                    EmployeeId =
                                        (oldParent != newParent) ? int.Parse(dt.Rows[j]["ID"].ToString()) : 0,
                                    EmployeeCode = dt.Rows[j]["employeeid"].ToString().Trim(),
                                    EmployeeName = dt.Rows[j]["employeename"].ToString().TrimEnd(),
                                    JobCandidateName = Convert.ToString(dt.Rows[j]["position"]),
                                    SortOrder = Convert.ToInt16(dt.Rows[j]["orders"]),
                                    BirthDate = null,
                                    TypeOfSalary = (dt.Rows[j]["payrolltype"] != null)
                                            ? int.Parse(dt.Rows[j]["payrolltype"].ToString()) - 1
                                            : 0,
                                    Sex = (dt.Rows[j]["sex"] == null || dt.Rows[j]["sex"].ToString().Trim() != "2"),
                                    LevelOfSalary = dt.Rows[j]["scale"] != null ? dt.Rows[j]["scale"].ToString().Trim() : "",
                                    DepartmentId =
                                        Model.GetIdByCode("Department", "DepartmentID", "DepartmentCode",
                                            dt.Rows[j]["departid"].ToString().Trim()),
                                    CurrencyCode = string.IsNullOrEmpty(Convert.ToString(dt.Rows[j]["ccyid"]).Trim()) ? "USD" : Convert.ToString(dt.Rows[j]["ccyid"]),
                                    IdentityNo = Convert.ToString(dt.Rows[j]["icn"]),
                                    IssueDate = null,
                                    IssueBy = Convert.ToString(dt.Rows[j]["issueat"]),
                                    IsActive =
                                        oldActive != newActive
                                            ? !Convert.ToBoolean(dt.Rows[j]["inactive"])
                                            : Convert.ToBoolean(dt.Rows[j]["inactive"]),
                                    Description = "",
                                    Address = Convert.ToString(dt.Rows[j]["address"]),
                                    PhoneNumber = Convert.ToString(dt.Rows[j]["tel"]),
                                    EmployeePayItems = employeePayItems
                                };
                                Model.AddEmployee(employee);

                                var employeeId = Model.GetIdByCode("Employee", "EmployeeID", "EmployeeCode",
                                    dt.Rows[j]["employeeid"].ToString().Trim());


                                for (var k = 0; k < dtEmployeePayItem.Rows.Count; k++)
                                {
                                    var value = Model.GetIdByCode("PayItem", "PayItemID", "PayItemCode",
                                        dtEmployeePayItem.Rows[k]["employeepayitemid"].ToString().Trim());
                                    employeePayItems.Add(new EmployeePayItemModel
                                    {
                                        EmployeeId = Convert.ToInt16(employeeId),
                                        PayItemId = Convert.ToInt16(value),
                                        Amount = Convert.ToDecimal(dtEmployeePayItem.Rows[k]["amount"]),
                                        SalaryRatio = Convert.ToSingle(dtEmployeePayItem.Rows[k]["rate"])
                                    });
                                }

                                employee.EmployeeId = (int)employeeId;
                                employee.EmployeePayItems = employeePayItems;
                                Model.UpdateEmployee(employee);
                            }
                            break;
                        #endregion

                        #region Vendor
                        case "Vendor":
                            //Check data existed
                            if (Model.GetVendors().Count > 0)
                            {
                                break;
                            }
                            for (var j = 0; j < dt.Rows.Count; j++)
                            {
                                var vendor = new VendorModel
                                {
                                    VendorCode = dt.Rows[j]["vendorid"].ToString().Trim(),
                                    VendorName = dt.Rows[j]["vendorname"].ToString().TrimEnd(),
                                    Address = Convert.ToString(dt.Rows[j]["vendoraddress"]),
                                    ContactName = Convert.ToString(dt.Rows[j]["contactname"]),
                                    ContactRegency = Convert.ToString(dt.Rows[j]["contactaddress"]),
                                    Phone = Convert.ToString(dt.Rows[j]["tel"]),
                                    Mobile = Convert.ToString(dt.Rows[j]["mobifone"]),
                                    Fax = Convert.ToString(dt.Rows[j]["fax"]),
                                    Email = Convert.ToString(dt.Rows[j]["email"]),
                                    TaxCode = Convert.ToString(dt.Rows[j]["vendortaxcode"]),
                                    Website = Convert.ToString(dt.Rows[j]["website"]),
                                    Province = Convert.ToString(dt.Rows[j]["state"]),
                                    City = Convert.ToString(dt.Rows[j]["city"]),
                                    ZipCode = Convert.ToString(dt.Rows[j]["zip"]),
                                    Area = Convert.ToString(dt.Rows[j]["areaid"]),
                                    Country = Convert.ToString(dt.Rows[j]["country"]),
                                    BankNumber = Convert.ToString(dt.Rows[j]["bankaccount"]),
                                    IsActive = Convert.ToBoolean(dt.Rows[j]["inactive"])
                                };
                                if (oldActive != newActive)
                                    vendor.IsActive = !Convert.ToBoolean(dt.Rows[j]["inactive"]);
                                Model.InsertVendor(vendor);
                            }
                            break;
                        #endregion

                        #region Append data

                        case "AccountingObject":
                            if (Model.GetAccountingObjects().Count > 14)
                            {
                                break;
                            }
                            for (var j = 0; j < dt.Rows.Count; j++)
                            {
                                var accountingObject = new AccountingObjectModel
                                {
                                    AccountingObjectCategoryId = Convert.ToInt16(dt.Rows[j]["objecttype"]),
                                    AccountingObjectCode = Convert.ToString(dt.Rows[j]["objectid"]).Trim(),
                                    FullName = Convert.ToString(dt.Rows[j]["objectname"]),
                                    Address = Convert.ToString(dt.Rows[j]["objectaddress"]),
                                    TaxCode = Convert.ToString(dt.Rows[j]["objecttaxcode"]),
                                    BankAcount = Convert.ToString(dt.Rows[j]["bankaccount"]),
                                    ContactName = Convert.ToString(dt.Rows[j]["contactname"]),
                                    ContactAddress = Convert.ToString(dt.Rows[j]["contactaddress"]),
                                    ContactIdNumber = Convert.ToString(dt.Rows[j]["contacticn"]),
                                    IssueDate = null,
                                    IssueAddress = Convert.ToString(dt.Rows[j]["contactissueat"]),
                                    IsActive = Convert.ToBoolean(dt.Rows[j]["inactive"])
                                };
                                if (oldActive != newActive)
                                    accountingObject.IsActive = !Convert.ToBoolean(dt.Rows[j]["inactive"]);
                                Model.InsertAccountingObject(accountingObject);
                            }
                            break;
                        case "Stock":
                            if (Model.GetStocks().Count > 3)
                            {
                                break;
                            }
                            for (var j = 0; j < dt.Rows.Count; j++)
                            {
                                var stock = new StockModel
                                {
                                    StockCode = dt.Rows[j]["stockid"].ToString().Trim(),
                                    StockName = Convert.ToString(dt.Rows[j]["stockname"]),
                                    Description = Convert.ToString(dt.Rows[j]["note"]),
                                    IsActive = Convert.ToBoolean(dt.Rows[j]["inactive"])
                                };
                                if (oldActive != newActive) stock.IsActive = !Convert.ToBoolean(dt.Rows[j]["inactive"]);
                                Model.InsertStock(stock);
                            }
                            break;
                        case "InventoryItem":
                            if (Model.GetInventoryItems().Count > 25)
                            {
                                break;
                            }
                            for (var j = 0; j < dt.Rows.Count; j++)
                            {
                                var inventoryItem = new InventoryItemModel
                                {
                                    InventoryItemCode = dt.Rows[j]["itemid"].ToString().Trim(),
                                    InventoryItemName = Convert.ToString(dt.Rows[j]["itemname"]),
                                    AccountCode = Convert.ToString(dt.Rows[j]["inventoryaccount"]),
                                    Unit = Convert.ToString(dt.Rows[j]["unit"]),
                                    CurrencyCode = dt.Rows[j]["ccyid"].ToString().Trim(),
                                    CostMethod = Convert.ToInt16(dt.Rows[j]["costmethod"]),
                                    IsActive = Convert.ToBoolean(dt.Rows[j]["inactive"])
                                };
                                //Lay thông tin mã kho
                                var sqlStock =
                                    "SELECT DIST ItemID, j.stockid FROM JourentryDetail jd INNER JOIN Jourentry j ON jd.RefID = j.RefId WHERE itemid = '" +
                                    inventoryItem.InventoryItemCode + "'";
                                var dtStock = GetData(sqlStock);
                                if (dtStock != null && dtStock.Rows.Count > 0)
                                {
                                    var stockId = Model.GetIdByCode("Stock", "StockID", "StockCode",
                                        Convert.ToString(dtStock.Rows[0]["StockId"]));
                                    inventoryItem.StockId = stockId != null ? (int)stockId : 4;
                                }
                                else
                                {
                                    inventoryItem.StockId = 4; //tranh loi rang buoc ko insert duoc du lieu
                                }
                                if (oldActive != newActive) inventoryItem.IsActive = !Convert.ToBoolean(dt.Rows[j]["inactive"]);
                                Model.InsertInventoryItem(inventoryItem);
                            }
                            break;

                        #endregion

                        #region FixedAsset

                        case "FixedAsset":
                            ///////////////////////////////////////////////////////////////////////|
                            /*
                            |Riêng thằng cu này lấy số dư đến ngày: do đó cộng dồn các tài khoản 
                            |211, 214, 466 ập lại vào các chỉ tiêu:
                            */
                            //////////////////////////////////////////////////////////////////////|
                            if (Model.GetAllFixedAssetsWithStoreProdure("uspGet_All_FixedAsset").Count > 0)
                            {
                                break;
                            }
                            for (var j = 0; j < dt.Rows.Count; j++)
                            {
                                var fixedAssetCode = dt.Rows[j]["fixedassetid"].ToString().Trim();
                                var currencyCode = dt.Rows[j]["ccyid"] == null ? "" : dt.Rows[j]["ccyid"].ToString().Trim();
                                if (string.IsNullOrEmpty(currencyCode.Trim()))
                                {
                                    if (XtraMessageBox.Show(
                                        "Tài sản có mã: " + fixedAssetCode +
                                        " chưa chọn tiền tệ. Tài sản này không tổng hợp được. Bạn có muốn tiếp tục tổng hợp không?",
                                        "Thông báo",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        continue;
                                    }
                                    return false;
                                }
                                var orgAcountCode = dt.Rows[j]["assetaccount"].ToString().Trim();
                                var depreciationAccountCode = dt.Rows[j]["depaccount"].ToString().Trim();
                                var capitalAccountCode = dt.Rows[j]["capitalaccount"].ToString().Trim();

                                //Lay nguyen gia: 211
                                var dtOrgAmount = GetFixedAssetAmount(fixedAssetCode, orgAcountCode, currencyCode);
                                decimal orgAmountOC = 0;
                                decimal orgAmountExchange = 0;
                                if (dtOrgAmount != null && dtOrgAmount.Rows.Count > 0)
                                {
                                    for (int k = 0; k < dtOrgAmount.Rows.Count; k++)
                                    {
                                        orgAmountOC = orgAmountOC + Convert.ToDecimal(dtOrgAmount.Rows[k]["FCAmount"]);
                                        orgAmountExchange = orgAmountExchange + Convert.ToDecimal(dtOrgAmount.Rows[k]["Amount"]);
                                    }
                                }

                                //Lay gia tri hao mon: 214
                                var dtAccumDepreciation = GetFixedAssetAmount(fixedAssetCode, depreciationAccountCode, currencyCode);
                                decimal amountOC = 0;
                                decimal amountExchange = 0;
                                if (dtAccumDepreciation != null && dtAccumDepreciation.Rows.Count > 0)
                                {
                                    for (int k = 0; k < dtAccumDepreciation.Rows.Count; k++)
                                    {
                                        amountOC = amountOC + Convert.ToDecimal(dtAccumDepreciation.Rows[k]["FCAmount"]) * (-1);
                                        amountExchange = amountExchange + Convert.ToDecimal(dtAccumDepreciation.Rows[k]["Amount"]) * (-1);
                                    }
                                }

                                //Lấy giá trị còn lại: 466
                                var dtRemaining = GetFixedAssetAmount(fixedAssetCode, capitalAccountCode, currencyCode);
                                decimal amountRemainingOC = 0;
                                decimal amountRemainingExchange = 0;
                                if (dtRemaining != null && dtRemaining.Rows.Count > 0)
                                {
                                    for (int k = 0; k < dtRemaining.Rows.Count; k++)
                                    {
                                        amountRemainingOC = amountRemainingOC + Convert.ToDecimal(dtRemaining.Rows[k]["FCAmount"]) * (-1);
                                        amountRemainingExchange = amountRemainingExchange + Convert.ToDecimal(dtRemaining.Rows[k]["Amount"]) * (-1);
                                    }
                                }

                                //Kiem tra thang nao da thanh ly, ma co gia tri con lai = 0 thi cho Out, ngày ghi giảm khác năm bắt đầu lấy số phát sinh
                                var state = Convert.ToInt16(dt.Rows[j]["status"]);

                                if (state == 4 && amountRemainingOC == 0 && !CheckFixedAssetDecreaseExisted(fixedAssetCode)) continue;

                                var fixedAssetCurrency = new FixedAssetCurrencyModel
                                {
                                    CurrencyCode = currencyCode,
                                    AnnualDepreciationAmount = Convert.ToDecimal(dt.Rows[j]["yearlydep"]),
                                    AnnualDepreciationAmountUSD = Convert.ToDecimal(dt.Rows[j]["yearlydepusd"]),
                                    Description = dt.Rows[j]["description"] == DBNull.Value ? "" : Convert.ToString(dt.Rows[j]["description"]),
                                    ExchangeRate = dt.Rows[j]["exchangerate"] == DBNull.Value ? 1 : Convert.ToSingle(dt.Rows[j]["exchangerate"]),
                                    FixedAssetId = 0,
                                    UnitPrice = Convert.ToDecimal(dt.Rows[j]["unitprice"]),
                                    UnitPriceUSD = Convert.ToDecimal(dt.Rows[j]["unitpriceusd"])
                                };

                                var usedDate = Convert.ToDateTime(dt.Rows[j]["useddate"]);
                                if (usedDate < balanceDate.Date)
                                {
                                    fixedAssetCurrency.OrgPrice = orgAmountOC;
                                    fixedAssetCurrency.OrgPriceUSD = orgAmountExchange;
                                    fixedAssetCurrency.AccumDepreciationAmount = amountOC;
                                    fixedAssetCurrency.AccumDepreciationAmountUSD = amountExchange;
                                    fixedAssetCurrency.RemainingAmount = amountRemainingOC;
                                    fixedAssetCurrency.RemainingAmountUSD = amountRemainingExchange;
                                }
                                else
                                {
                                    fixedAssetCurrency.OrgPrice = Convert.ToDecimal(dt.Rows[j]["orgcost"]);
                                    fixedAssetCurrency.OrgPriceUSD = Convert.ToDecimal(dt.Rows[j]["orgcostusd"]);
                                    fixedAssetCurrency.AccumDepreciationAmount = Convert.ToDecimal(dt.Rows[j]["accdep"]);
                                    fixedAssetCurrency.AccumDepreciationAmountUSD = Convert.ToDecimal(dt.Rows[j]["accdepusd"]);
                                    fixedAssetCurrency.RemainingAmount = Convert.ToDecimal(dt.Rows[j]["opnvalue"]);
                                    fixedAssetCurrency.RemainingAmountUSD = Convert.ToDecimal(dt.Rows[j]["opnvalueusd"]);
                                }


                                var fid = (dt.Rows[j]["fixedassetcategoryid"] != null)
                                    ? Model.GetIdByCode("FixedAssetCategory", "FixedAssetCategoryID",
                                        "FixedAssetCategoryCode",
                                        dt.Rows[j]["fixedassetcategoryid"].ToString().Trim())
                                    : null;

                                if (fid == null)
                                {
                                    if (XtraMessageBox.Show(
                                        "Tài sản có mã: " + fixedAssetCode +
                                        " sai mã loại tài sản. Tài sản này không tổng hợp được. Bạn có muốn tiếp tục tổng hợp không?",
                                        "Thông báo",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        continue;
                                    }
                                    return false;
                                }

                                var did = (dt.Rows[j]["departid"] != null)
                                    ? Model.GetIdByCode("Department", "DepartmentID", "DepartmentCode",
                                        dt.Rows[j]["departid"].ToString().Trim())
                                    : null;

                                if (did == null)
                                {
                                    if (XtraMessageBox.Show(
                                        "Tài sản có mã: " + fixedAssetCode +
                                        " sai mã phòng ban. Tài sản này không tổng hợp được. Bạn có muốn tiếp tục tổng hợp không?",
                                        "Thông báo",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        continue;
                                    }
                                    return false;
                                }

                                var fixedAsset = new FixedAssetModel
                                {
                                    FixedAssetCode = dt.Rows[j]["fixedassetid"].ToString().Trim(),
                                    FixedAssetName = dt.Rows[j]["fixedassetname"].ToString().TrimEnd(),
                                    FixedAssetForeignName = "",
                                    FixedAssetCategoryId = (int)fid,
                                    State = Convert.ToInt16(dt.Rows[j]["status"]) - 1,
                                    Description = dt.Rows[j]["description"] == DBNull.Value ? "" : Convert.ToString(dt.Rows[j]["description"]),
                                    ProductionYear = dt.Rows[j]["productionyear"] == DBNull.Value ? 0 : Convert.ToInt16(dt.Rows[j]["productionyear"]),
                                    MadeIn = dt.Rows[j]["madein"] == DBNull.Value ? "" : Convert.ToString(dt.Rows[j]["madein"]),
                                    PurchasedDate = Convert.ToDateTime(dt.Rows[j]["purchaseddate"]),
                                    UsedDate = Convert.ToDateTime(dt.Rows[j]["useddate"]),
                                    DepreciationDate = Convert.ToDateTime(dt.Rows[j]["startdate"]),
                                    IncrementDate = Convert.ToDateTime(dt.Rows[j]["useddate"]),
                                    DisposedDate = Convert.ToDateTime(dt.Rows[j]["useddate"]).AddYears(Convert.ToInt16(dt.Rows[j]["lifetime"])),
                                    Unit = dt.Rows[j]["unit"] == DBNull.Value ? "" : Convert.ToString(dt.Rows[j]["unit"]),
                                    SerialNumber = dt.Rows[j]["serialnumber"] == DBNull.Value ? "" : Convert.ToString(dt.Rows[j]["serialnumber"]),
                                    Accessories = dt.Rows[j]["accessories"] == DBNull.Value ? "" : Convert.ToString(dt.Rows[j]["accessories"]),
                                    Quantity = Convert.ToInt16(dt.Rows[j]["quantity"]),
                                    UnitPrice = Convert.ToDecimal(dt.Rows[j]["unitprice"]),
                                    OrgPrice = Convert.ToDecimal(dt.Rows[j]["orgcost"]),
                                    CurrencyCode = Convert.ToString(dt.Rows[j]["ccyid"]),
                                    ExchangeRate = Convert.ToDecimal(dt.Rows[j]["exchangerate"]),
                                    UnitPriceUSD = Convert.ToDecimal(dt.Rows[j]["unitpriceusd"]),
                                    OrgPriceUSD = Convert.ToDecimal(dt.Rows[j]["orgcostusd"]),
                                    AnnualDepreciationAmountUSD = Convert.ToDecimal(dt.Rows[j]["yearlydepusd"]),
                                    AnnualDepreciationAmount = Convert.ToDecimal(dt.Rows[j]["yearlydep"]),
                                    LifeTime = Convert.ToDecimal(dt.Rows[j]["lifetime"]),
                                    DepreciationRate = Convert.ToDecimal(dt.Rows[j]["deprate"]),
                                    OrgPriceAccountCode = Convert.ToString(dt.Rows[j]["assetaccount"]),
                                    DepreciationAccountCode = Convert.ToString(dt.Rows[j]["depaccount"]),
                                    CapitalAccountCode = Convert.ToString(dt.Rows[j]["capitalaccount"]),
                                    DepartmentId = (int)did,
                                    IsActive = dt.Rows[j]["inactive"] == DBNull.Value || Convert.ToBoolean(dt.Rows[j]["inactive"]),
                                };
                                if (usedDate < balanceDate.Date)
                                {
                                    fixedAsset.OrgPrice = orgAmountOC;
                                    fixedAsset.OrgPriceUSD = orgAmountExchange;
                                    fixedAsset.AccumDepreciationAmount = amountOC;
                                    fixedAsset.AccumDepreciationAmountUSD = amountExchange;
                                    fixedAsset.RemainingAmount = amountRemainingOC;
                                    fixedAsset.RemainingAmountUSD = amountRemainingExchange;
                                }
                                else
                                {
                                    fixedAsset.OrgPrice = Convert.ToDecimal(dt.Rows[j]["orgcost"]);
                                    fixedAsset.OrgPriceUSD = Convert.ToDecimal(dt.Rows[j]["orgcostusd"]);
                                    fixedAsset.AccumDepreciationAmount = Convert.ToDecimal(dt.Rows[j]["accdep"]);
                                    fixedAsset.AccumDepreciationAmountUSD = Convert.ToDecimal(dt.Rows[j]["accdepusd"]);
                                    fixedAsset.RemainingAmount = Convert.ToDecimal(dt.Rows[j]["opnvalue"]);
                                    fixedAsset.RemainingAmountUSD = Convert.ToDecimal(dt.Rows[j]["opnvalueusd"]);
                                }

                                if (dt.Rows[j]["employeeid"] == null)
                                    fixedAsset.EmployeeId = null;
                                else
                                {
                                    fixedAsset.EmployeeId =
                                        dt.Rows[j]["employeeid"] == DBNull.Value
                                            ? null
                                            : Model.GetIdByCode("Employee", "EmployeeID", "EmployeeCode",
                                                dt.Rows[j]["employeeid"].ToString().Trim());
                                }
                                fixedAsset.FixedAssetCurrencies.Add(fixedAssetCurrency);
                                if (oldActive != newActive) fixedAsset.IsActive = !(bool)dt.Rows[j]["inactive"];
                                Model.AddFixedAsset(fixedAsset);
                            }
                            break;
                        #endregion

                        #endregion

                        #region OpeningAccountEntry

                        case "OpeningAccountEntry":
                            const string selectBanlacesClaus =
                                "SELECT * FROM Account WHERE  NOT INLIST(AccountID,'4612','6612') AND NOT INLIST(LEFT(AccountID,3),'211','213','214','466','152','153') AND Detail = .T.";

                            var dtAccount = GetData(selectBanlacesClaus);
                            if (dtAccount != null && dtAccount.Rows.Count > 0)
                            {
                                for (var m = 0; m < dtAccount.Rows.Count; m++)
                                {
                                    var selectCommand = "SELECT Account ";
                                    var groupCommand = "Account ";

                                    int banlanceSide = Convert.ToInt16(dtAccount.Rows[m]["balanceside"]);
                                    var whereCommand = " Account == '" + dtAccount.Rows[m]["AccountID"].ToString().Trim() + "' ";

                                    #region Join string
                                    if (bool.Parse(dtAccount.Rows[m]["isCcy"].ToString()))
                                    {
                                        selectCommand = selectCommand + ", CcyID";
                                        groupCommand = groupCommand + ", CcyID";
                                    }
                                    if (bool.Parse(dtAccount.Rows[m]["iscapital"].ToString()))
                                    {
                                        selectCommand = selectCommand + ", CapitalID";
                                        groupCommand = groupCommand + ", CapitalID";
                                    }
                                    if (bool.Parse(dtAccount.Rows[m]["isActivity"].ToString()))
                                    {
                                        selectCommand = selectCommand + ", ActivityID";
                                        groupCommand = groupCommand + ", ActivityID";
                                    }
                                    if (bool.Parse(dtAccount.Rows[m]["isProject"].ToString()))
                                    {
                                        selectCommand = selectCommand + ", ProjectID";
                                        groupCommand = groupCommand + ", ProjectID";
                                    }
                                    if (bool.Parse(dtAccount.Rows[m]["isContract"].ToString()))
                                    {
                                        selectCommand = selectCommand + ", ContractID";
                                        groupCommand = groupCommand + ", ContractID";
                                    }
                                    if (bool.Parse(dtAccount.Rows[m]["isDepart"].ToString()))
                                    {
                                        selectCommand = selectCommand + ", DepartID";
                                        groupCommand = groupCommand + ", DepartID";
                                    }
                                    if (bool.Parse(dtAccount.Rows[m]["isJob"].ToString()))
                                    {
                                        selectCommand = selectCommand + ", JobID";
                                        groupCommand = groupCommand + ", JobID";
                                    }
                                    if (bool.Parse(dtAccount.Rows[m]["isCustomer"].ToString()))
                                    {
                                        selectCommand = selectCommand + ", CustomerID";
                                        groupCommand = groupCommand + ", CustomerID";
                                    }
                                    if (bool.Parse(dtAccount.Rows[m]["isVendor"].ToString()))
                                    {
                                        selectCommand = selectCommand + ", VendorID";
                                        groupCommand = groupCommand + ", VendorID";
                                    }
                                    if (bool.Parse(dtAccount.Rows[m]["isEmployee"].ToString()))
                                    {
                                        selectCommand = selectCommand + ", EmployeeID";
                                        groupCommand = groupCommand + ", EmployeeID";
                                    }
                                    if (bool.Parse(dtAccount.Rows[m]["isObject"].ToString()))
                                    {
                                        selectCommand = selectCommand + ", ObjectID";
                                        groupCommand = groupCommand + ", ObjectID";
                                    }
                                    if (bool.Parse(dtAccount.Rows[m]["isItem"].ToString()))
                                    {
                                        selectCommand = selectCommand + ", ItemID";
                                        groupCommand = groupCommand + ", ItemID";
                                    }
                                    if (bool.Parse(dtAccount.Rows[m]["isFixedAsset"].ToString()))
                                    {
                                        selectCommand = selectCommand + ", FixedAssetID";
                                        groupCommand = groupCommand + ", FixedAssetID";
                                    }
                                    if (bool.Parse(dtAccount.Rows[m]["isTaxItem"].ToString()))
                                    {
                                        selectCommand = selectCommand + ", TaxitemID";
                                        groupCommand = groupCommand + ", TaxitemID";
                                    }
                                    #endregion

                                    var sqlCommand = selectCommand +
                                                     ", SUM(amount) AS amount, SUM(FCamount) AS FCAmount ";
                                    sqlCommand = sqlCommand + " FROM JourentryAccount WHERE " + whereCommand;
                                    sqlCommand = sqlCommand + " AND postdate < CTOD('" + balanceDate.Month + "/" + balanceDate.Day + "/" + balanceDate.Year + "')";
                                    sqlCommand = sqlCommand + " GROUP BY " + groupCommand + " ORDER BY " + groupCommand;

                                    var dtOppeningAccount = GetData(sqlCommand);
                                    if (dtOppeningAccount != null && dtOppeningAccount.Rows.Count > 0)
                                    {
                                        var openingAccountEntryDetailVouchers = new List<OpeningAccountEntryDetailModel>();

                                        var voucher = new OpeningAccountEntryModel
                                        {
                                            RefTypeId = 700,
                                            PostedDate = balanceDate.AddDays(-1),
                                            AccountCode = dtAccount.Rows[m]["AccountID"].ToString().Trim(),
                                            OpeningAccountEntryDetails = openingAccountEntryDetailVouchers
                                        };

                                        for (var k = 0; k < dtOppeningAccount.Rows.Count; k++)
                                        {
                                            //Kiem tra thang nao tien NT = 0 thi cho out
                                            var amountOC = Convert.ToDecimal(dtOppeningAccount.Rows[k]["fcamount"]);
                                            var amountExchange = Convert.ToDecimal(dtOppeningAccount.Rows[k]["amount"]);
                                            if (amountOC == 0) continue;

                                            var openingAccountEntryDetailVoucher = new OpeningAccountEntryDetailModel
                                            {
                                                BudgetGroupItemCode = null,
                                                MergerFundId = null,
                                                ProjectId = null,
                                                BudgetChapterCode = null,
                                                BudgetCategoryCode = null,
                                                BankId = null,
                                                CustomerId = null,
                                                AccountCode = dtOppeningAccount.Rows[k]["account"].ToString().Trim(),
                                                AccountBeginningDebitAmountOC = 0,
                                                AccountBeginningDebitAmountExchange = 0,
                                                AccountBeginningCreditAmountOC = 0,
                                                AccountBeginningCreditAmountExchange = 0,
                                                ExchangeRate = 1,
                                                PostedDate = balanceDate.AddDays(-1),
                                                RefTypeId = 700,
                                            };

                                            //if(amountOC == 0 && amountExchange == 0) continue;
                                            switch (banlanceSide)
                                            {
                                                case 1: //Du No
                                                    openingAccountEntryDetailVoucher.CreditAmountOC = 0;
                                                    openingAccountEntryDetailVoucher.CreditAmountExchange = 0;
                                                    openingAccountEntryDetailVoucher.DebitAmountOC = amountOC;
                                                    openingAccountEntryDetailVoucher.DebitAmountExchange = amountExchange;
                                                    break;
                                                case 2: //Du Co
                                                    openingAccountEntryDetailVoucher.CreditAmountOC = (-1) * amountOC;
                                                    openingAccountEntryDetailVoucher.CreditAmountExchange = (-1) * amountExchange;
                                                    openingAccountEntryDetailVoucher.DebitAmountOC = 0;
                                                    openingAccountEntryDetailVoucher.DebitAmountExchange = 0;
                                                    break;
                                                case 3: //luong tinh
                                                    if (amountOC > 0)
                                                    {
                                                        openingAccountEntryDetailVoucher.CreditAmountOC = 0;
                                                        openingAccountEntryDetailVoucher.CreditAmountExchange = 0;
                                                        openingAccountEntryDetailVoucher.DebitAmountOC = amountOC;
                                                        openingAccountEntryDetailVoucher.DebitAmountExchange = amountExchange;
                                                    }
                                                    else
                                                    {
                                                        openingAccountEntryDetailVoucher.CreditAmountOC = (-1) * amountOC;
                                                        openingAccountEntryDetailVoucher.CreditAmountExchange = (-1) * amountExchange;
                                                        openingAccountEntryDetailVoucher.DebitAmountOC = 0;
                                                        openingAccountEntryDetailVoucher.DebitAmountExchange = 0;
                                                    }
                                                    break;
                                            }

                                            if (sqlCommand.Contains("CcyID"))
                                                openingAccountEntryDetailVoucher.CurrencyCode =
                                                    dtOppeningAccount.Rows[k]["ccyid"].ToString().Trim();

                                            if (sqlCommand.Contains("ObjectID"))
                                                openingAccountEntryDetailVoucher.AccountingObjectId =
                                                    Convert.ToString(dtOppeningAccount.Rows[k]["objectid"]) == null
                                                        ? null
                                                        : Model.GetIdByCode("AccountingObject", "AccountingObjectID",
                                                            "AccountingObjectCode",
                                                            dtOppeningAccount.Rows[k]["objectid"].ToString().Trim());

                                            if (sqlCommand.Contains("CapitalID"))
                                                openingAccountEntryDetailVoucher.BudgetSourceCode =
                                                    Convert.ToString(dtOppeningAccount.Rows[k]["capitalid"]) == null
                                                        ? null
                                                        : dtOppeningAccount.Rows[k]["capitalid"].ToString().Trim();

                                            if (sqlCommand.Contains("EmployeeID"))
                                                openingAccountEntryDetailVoucher.EmployeeId =
                                                    Convert.ToString(dtOppeningAccount.Rows[k]["EmployeeId"]) == null
                                                    ? null
                                                    : Model.GetIdByCode("Employee", "EmployeeID", "EmployeeCode",
                                                        dtOppeningAccount.Rows[k]["EmployeeId"].ToString().Trim());
                                            if (sqlCommand.Contains("VendorID"))
                                                openingAccountEntryDetailVoucher.VendorId = dtOppeningAccount.Rows[k]["vendorid"] == null
                                                    ? null
                                                    : Model.GetIdByCode("Vendor", "VendorID", "VendorCode",
                                                        dtOppeningAccount.Rows[k]["vendorid"].ToString().Trim());

                                            openingAccountEntryDetailVouchers.Add(openingAccountEntryDetailVoucher);
                                        }

                                        voucher.OpeningAccountEntryDetails = openingAccountEntryDetailVouchers;
                                        Model.UpdateOpeningAccountEntry(voucher);
                                    }
                                }
                            }
                            //Tài khoản Nguồn
                            var sqlQuery461 = "SELECT SUM(Amount) AS Amount, SUM(FCAmount) AS FCAmount, CapitalID, CcyID " +
                                          "FROM JourentryAccount GROUP BY CapitalID, CcyID WHERE INLIST(Account,'4612','6612') AND " +
                                          " postdate < CTOD('" + balanceDate.Month + "/" + balanceDate.Day + "/" + balanceDate.Year + "')";
                            var dt461 = GetData(sqlQuery461);
                            if (dt461 != null && dt461.Rows.Count > 0)
                            {
                                var openingAccountEntryDetailVouchers = new List<OpeningAccountEntryDetailModel>();

                                var voucher = new OpeningAccountEntryModel
                                {
                                    RefTypeId = 700,
                                    PostedDate = balanceDate.AddDays(-1),
                                    AccountCode = "4612",
                                    OpeningAccountEntryDetails = openingAccountEntryDetailVouchers
                                };

                                for (var k = 0; k < dt461.Rows.Count; k++)
                                {
                                    var openingAccountEntryDetailVoucher = new OpeningAccountEntryDetailModel
                                    {
                                        BudgetGroupItemCode = null,
                                        MergerFundId = null,
                                        ProjectId = null,
                                        BudgetChapterCode = null,
                                        BudgetCategoryCode = null,
                                        BankId = null,
                                        CustomerId = null,
                                        AccountCode = "4612",
                                        AccountBeginningDebitAmountOC = 0,
                                        AccountBeginningDebitAmountExchange = 0,
                                        AccountBeginningCreditAmountOC = 0,
                                        AccountBeginningCreditAmountExchange = 0,
                                        ExchangeRate = 1,
                                        PostedDate = balanceDate.AddDays(-1),
                                        RefTypeId = 700,
                                    };
                                    var amountOC = Convert.ToDecimal(dt461.Rows[k]["fcamount"]);
                                    var amountExchange = Convert.ToDecimal(dt461.Rows[k]["amount"]);
                                    if (amountOC == 0 && amountExchange == 0) continue;

                                    openingAccountEntryDetailVoucher.CreditAmountOC = (-1) * amountOC;
                                    openingAccountEntryDetailVoucher.CreditAmountExchange = (-1) * amountExchange;
                                    openingAccountEntryDetailVoucher.DebitAmountOC = 0;
                                    openingAccountEntryDetailVoucher.DebitAmountExchange = 0;
                                    openingAccountEntryDetailVoucher.CurrencyCode = Convert.ToString(dt461.Rows[k]["ccyid"]);
                                    openingAccountEntryDetailVoucher.BudgetSourceCode = Convert.ToString(dt461.Rows[k]["capitalid"]) == null ? null
                                                : dt461.Rows[k]["capitalid"].ToString().Trim();

                                    openingAccountEntryDetailVouchers.Add(openingAccountEntryDetailVoucher);
                                }

                                voucher.OpeningAccountEntryDetails = openingAccountEntryDetailVouchers;
                                Model.UpdateOpeningAccountEntry(voucher);
                            }
                            break;

                        #endregion

                        #region OpeningFixedAssetEntry

                        case "OpeningFixedAssetEntry":
                            var sqlQuery =
                                "SELECT DIST FixedAssetId FROM FixedAsset ORDER BY FixedAssetID WHERE useddate < CTOD('" +
                                balanceDate.Month + "/" + balanceDate.Day + "/" + balanceDate.Year + "')";
                            var dtFixedAsset = GetData(sqlQuery);
                            if (dtFixedAsset != null && dtFixedAsset.Rows.Count > 0)
                            {
                                for (var j = 0; j < dtFixedAsset.Rows.Count; j++)
                                {
                                    //Danh mục tài sản đã được tổng hợp, do đó để tăng tốc độ, sẽ lấy luôn ở danh mục tài sản đã được convert
                                    var fixedAssetModel =
                                        Model.GetFixedAssetsByCode(dtFixedAsset.Rows[j]["FixedAssetId"].ToString().Trim());

                                    if (fixedAssetModel == null) continue;

                                    var voucher = new List<OpeningFixedAssetEntryModel>
                                    {
                                        new OpeningFixedAssetEntryModel
                                        {
                                            RefTypeId = 702,
                                            RefNo = GeneratedBaseRefNo(702),
                                            PostedDate = balanceDate.Date.AddDays(-1),
                                            FixedAssetId = fixedAssetModel.FixedAssetId,
                                            DepartmentId = fixedAssetModel.DepartmentId,
                                            LifeTime = (int) fixedAssetModel.LifeTime,
                                            IncrementDate = fixedAssetModel.IncrementDate,
                                            Unit = fixedAssetModel.Unit,
                                            UsedDate = fixedAssetModel.UsedDate,
                                            CurrencyCode = fixedAssetModel.CurrencyCode,
                                            ExchangeRate = fixedAssetModel.ExchangeRate,
                                            OrgPriceAccount = fixedAssetModel.OrgPriceAccountCode,
                                            DepreciationAccount = fixedAssetModel.DepreciationAccountCode,
                                            CapitalAccount = fixedAssetModel.CapitalAccountCode,

                                            OrgPriceDebitAmount =
                                                fixedAssetModel.FixedAssetCurrencies != null
                                                    ? fixedAssetModel.FixedAssetCurrencies[0].OrgPrice
                                                    : 0,
                                            OrgPriceDebitAmountUSD =
                                                fixedAssetModel.FixedAssetCurrencies != null
                                                    ? fixedAssetModel.FixedAssetCurrencies[0].OrgPriceUSD
                                                    : 0,
                                            DepreciationCreditAmount =
                                                fixedAssetModel.FixedAssetCurrencies != null
                                                    ? fixedAssetModel.FixedAssetCurrencies[0].AccumDepreciationAmount
                                                    : 0,
                                            DepreciationCreditAmountUSD =
                                                fixedAssetModel.FixedAssetCurrencies != null
                                                    ? fixedAssetModel.FixedAssetCurrencies[0].AccumDepreciationAmountUSD
                                                    : 0,
                                            CapitalCreditAmount =
                                                fixedAssetModel.FixedAssetCurrencies != null
                                                    ? fixedAssetModel.FixedAssetCurrencies[0].RemainingAmount
                                                    : 0,
                                            CapitalCreditAmountUSD =
                                                fixedAssetModel.FixedAssetCurrencies != null
                                                    ? fixedAssetModel.FixedAssetCurrencies[0].RemainingAmountUSD
                                                    : 0,
                                            RemainingAmount =
                                                fixedAssetModel.FixedAssetCurrencies != null
                                                    ? fixedAssetModel.FixedAssetCurrencies[0].RemainingAmount
                                                    : 0,
                                            RemainingAmountUSD =
                                                fixedAssetModel.FixedAssetCurrencies != null
                                                    ? fixedAssetModel.FixedAssetCurrencies[0].RemainingAmountUSD
                                                    : 0,
                                            BudgetChapterCode = null,
                                            Description = "Số dư đầu kỳ tài sản " + fixedAssetModel.FixedAssetName,
                                            Quantity = fixedAssetModel.Quantity,
                                            BudgetSourceCode = null
                                        }
                                    };
                                    Model.InsertOpeningFixedAssetEntries(voucher);
                                }
                            }
                            break;

                        #endregion

                        #region OpeningInventoryEntry

                        case "OpeningInventoryEntry":
                            var sqlQuery152 = "SELECT SUM(fcunitprice) AS fcUnitPrice, SUM(unitprice) AS UnitPrice, SUM(Quantity) AS Quantity, SUM(Amount) AS Amount, SUM(FCAmount) AS FCAmount, ItemId, Account, CcyID " +
                                                 "FROM JourentryAccount  WHERE INLIST(Account,'152','153') " +
                                                 "AND postdate < CTOD('" + balanceDate.Month + "/" + balanceDate.Day + "/" + balanceDate.Year + "') " +
                                                 "GROUP BY ItemId, Account, CcyID";
                            var dt152 = GetData(sqlQuery152);
                            if (dt152 != null && dt152.Rows.Count > 0)
                            {
                                var openingInventoryEntryModels = new List<OpeningInventoryEntryModel>();
                                for (var j = 0; j < dt152.Rows.Count; j++)
                                {
                                    var quantity = Convert.ToInt32(dt152.Rows[j]["quantity"]);
                                    var inventoryItemId =
                                        (int)Model.GetIdByCode("InventoryItem", "InventoryItemID", "InventoryItemCode",
                                            dt152.Rows[j]["itemid"].ToString().Trim());
                                    var stockid = Model.GetInventoryItem(inventoryItemId).StockId;
                                    var openingInventoryEntryModel = new OpeningInventoryEntryModel
                                    {
                                        RefTypeId = 701,
                                        RefNo = GeneratedBaseRefNo(701),
                                        PostedDate = balanceDate.Date.AddDays(-1),
                                        AccountNumber = dt152.Rows[j]["account"].ToString().Trim(),
                                        AmountExchange = Convert.ToDecimal(dt152.Rows[j]["amount"]),
                                        ExchangeRate = 1,
                                        AmountOc = Convert.ToDecimal(dt152.Rows[j]["fcamount"]),
                                        CurrencyCode = dt152.Rows[j]["ccyid"].ToString().Trim(),
                                        Quantity = quantity,
                                        InventoryItemId = inventoryItemId,
                                        StockId = stockid,
                                        UnitPriceExchange = Convert.ToDecimal(dt152.Rows[j]["unitprice"]),
                                        UnitPriceOc = Convert.ToDecimal(dt152.Rows[j]["fcunitprice"])
                                    };
                                    openingInventoryEntryModels.Add(openingInventoryEntryModel);
                                }
                                if (openingInventoryEntryModels.Count > 0)
                                    Model.UpdateOpeningInventoryEntry(openingInventoryEntryModels);
                            }
                            break;

                        #endregion

                        #region Vouchers

                        #region CashReceipt

                        case "CashReceipt":
                            if (Model.GetReceiptVoucherByRefTypeId(200).Count > 0)
                            {
                                break;
                            }
                            for (var j = 0; j < dt.Rows.Count; j++)
                            {
                                var selectClaus = "SELECT * FROM JOURENTRYDETAIL WHERE refid = '" +
                                                  dt.Rows[j]["refid"].ToString().Trim() + "' AND reftype ='200' ";
                                var dtReceiptVoucher = GetData(selectClaus);
                                ConvertFontData(ref dtReceiptVoucher, "description");
                                var receiptVouchers = new List<ReceiptVoucherDetailModel>();

                                var voucher = new ReceiptVoucherModel
                                {
                                    AccountingObjectType = Convert.ToInt16(dt.Rows[j]["objecttype"]),
                                    RefTypeId = 200,
                                    RefNo = dt.Rows[j]["refno"].ToString().Trim(),
                                    RefDate = Convert.ToDateTime(dt.Rows[j]["refdate"]),
                                    PostedDate = Convert.ToDateTime(dt.Rows[j]["postdate"]),

                                    Trader = Convert.ToString(dt.Rows[j]["contactname"]),
                                    CurrencyCode = dt.Rows[j]["ccyid"].ToString().Trim(),
                                    AccountNumber = dt.Rows[j]["cashaccount"].ToString().Trim(),
                                    TotalAmount = Convert.ToDecimal(dt.Rows[j]["fctotalamount"]),
                                    ExchangeRate = Convert.ToDecimal(dt.Rows[j]["exchangerate"]),
                                    TotalAmountExchange = Convert.ToDecimal(dt.Rows[j]["totalamount"]),
                                    JournalMemo = Convert.ToString(dt.Rows[j]["comment"]),
                                    DocumentInclude = Convert.ToString(dt.Rows[j]["docattach"]),
                                    ReceiptVoucherDetails = receiptVouchers
                                };
                                if (dt.Rows[j]["objecttype"] != null)
                                {
                                    if (int.Parse(dt.Rows[j]["objecttype"].ToString().Trim()) == 1) // Khách hàng
                                    {
                                        voucher.AccountingObjectType = 3;
                                        voucher.AccountingObjectId = null;
                                        voucher.CustomerId = null;
                                        voucher.VendorId = null;
                                        voucher.EmployeeId = null;
                                    }
                                    else if (int.Parse(dt.Rows[j]["objecttype"].ToString().Trim()) == 2)// Nha cung cap
                                    {
                                        voucher.AccountingObjectType = 0;
                                        voucher.AccountingObjectId = null;
                                        voucher.CustomerId = null;
                                        if (dt.Rows[j]["objectid"] != null)
                                        {
                                            if (dt.Rows[j]["objectid"].ToString().Trim() != "")
                                            {
                                                voucher.VendorId = Model.GetIdByCode("Vendor", "VendorID",
                                                    "VendorCode",
                                                    dt.Rows[j]["objectid"].ToString().Trim());
                                            }
                                            else voucher.VendorId = null;
                                        }
                                        else voucher.VendorId = null;
                                        voucher.EmployeeId = null;
                                    }
                                    else if (int.Parse(dt.Rows[j]["objecttype"].ToString().Trim()) == 3)// Nhan vien
                                    {
                                        voucher.AccountingObjectType = 1;
                                        voucher.AccountingObjectId = null;
                                        voucher.CustomerId = null;
                                        voucher.VendorId = null;
                                        if (dt.Rows[j]["objectid"] != null)
                                        {
                                            if (dt.Rows[j]["objectid"].ToString().Trim() != "")
                                            {
                                                voucher.EmployeeId = Model.GetIdByCode("Employee",
                                                    "EmployeeID",
                                                    "EmployeeCode",
                                                    dt.Rows[j]["objectid"].ToString().Trim());
                                            }
                                            else voucher.EmployeeId = null;
                                        }
                                        else voucher.EmployeeId = null;

                                    }
                                    else // đối tượng khác
                                    {
                                        if (dt.Rows[j]["objectid"] != null)
                                        {
                                            if (dt.Rows[j]["objectid"].ToString().Trim() != "")
                                            {
                                                voucher.AccountingObjectId =
                                                    Model.GetIdByCode("AccountingObject",
                                                        "AccountingObjectID", "AccountingObjectCode",
                                                        dt.Rows[j]["objectid"].ToString().Trim());
                                            }
                                            else voucher.AccountingObjectId = null;
                                        }
                                        else voucher.AccountingObjectId = null;
                                        voucher.AccountingObjectType = 2;
                                        voucher.CustomerId = null;
                                        voucher.VendorId = null;
                                        voucher.EmployeeId = null;
                                    }
                                }
                                for (var k = 0; k < dtReceiptVoucher.Rows.Count; k++)
                                {
                                    var receiptDetail = new ReceiptVoucherDetailModel
                                    {
                                        AccountingObjectId = dtReceiptVoucher.Rows[k]["objectid"] == null ? null :
                                                    Model.GetIdByCode("AccountingObject",
                                                        "AccountingObjectID", "AccountingObjectCode",
                                                        dtReceiptVoucher.Rows[k]["objectid"].ToString().Trim()),
                                        AccountNumber = dtReceiptVoucher.Rows[k]["debitaccount"].ToString().Trim(),
                                        CorrespondingAccountNumber =
                                            dtReceiptVoucher.Rows[k]["creditaccount"].ToString().Trim(),
                                        AmountExchange = Convert.ToDecimal(dtReceiptVoucher.Rows[k]["amount"]),
                                        AmountOc = Convert.ToDecimal(dtReceiptVoucher.Rows[k]["fcamount"]),
                                        AutoBusinessId = null,
                                        BudgetItemCode = string.IsNullOrEmpty(Convert.ToString(dtReceiptVoucher.Rows[k]["budgetitemid"]).Trim()) ? null : Convert.ToString(dtReceiptVoucher.Rows[k]["budgetitemid"]),
                                        BudgetSourceCode = string.IsNullOrEmpty(Convert.ToString(dtReceiptVoucher.Rows[k]["capitalid"]).Trim()) ? null : Convert.ToString(dtReceiptVoucher.Rows[k]["capitalid"]),
                                        Description = Convert.ToString(dtReceiptVoucher.Rows[k]["description"]),
                                        MergerFundId = null,
                                        ProjectId = null,
                                    };
                                    if (dtReceiptVoucher.Rows[k]["vouchertype"] != null)
                                    {
                                        if (dtReceiptVoucher.Rows[k]["vouchertype"] != null)
                                            receiptDetail.VoucherTypeId =
                                                int.Parse(dtReceiptVoucher.Rows[k]["vouchertype"].ToString());
                                        else
                                            receiptDetail.VoucherTypeId = null;
                                    }
                                    else receiptDetail.VoucherTypeId = null;
                                    receiptVouchers.Add(receiptDetail);
                                }

                                voucher.ReceiptVoucherDetails = receiptVouchers;
                                Model.IsConvertData = true;
                                Model.AddReceiptVoucher(voucher,false);
                            }
                            break;

                        #endregion

                        #region CashExpense

                        case "CashExpense":
                            if (Model.GetReceiptVoucherByRefTypeId(201).Count > 0)
                            {
                                break;
                            }
                            for (var j = 0; j < dt.Rows.Count; j++)
                            {
                                var selectClaus = "SELECT * FROM JOURENTRYDETAIL WHERE refid = '" +
                                                  dt.Rows[j]["refid"].ToString().Trim() + "' AND reftype ='201' ";
                                var dtExpenseVoucher = GetData(selectClaus);
                                ConvertFontData(ref dtExpenseVoucher, "description");
                                var cashDetailVouchers = new List<CashDetailModel>();

                                var voucher = new CashModel
                                {
                                    AccountingObjectType = Convert.ToInt16(dt.Rows[j]["objecttype"]),
                                    RefTypeId = 201,
                                    RefNo = dt.Rows[j]["refno"].ToString().Trim(),
                                    RefDate = dt.Rows[j]["refdate"].ToString().Trim(),
                                    PostedDate = dt.Rows[j]["postdate"].ToString().Trim(),

                                    Trader = Convert.ToString(dt.Rows[j]["contactname"]),
                                    CurrencyCode = Convert.ToString(dt.Rows[j]["ccyid"]),
                                    AccountNumber = dt.Rows[j]["cashaccount"].ToString().Trim(),
                                    TotalAmount = Convert.ToDecimal(dt.Rows[j]["fctotalamount"]),
                                    ExchangeRate = Convert.ToDecimal(dt.Rows[j]["exchangerate"]),
                                    TotalAmountExchange = Convert.ToDecimal(dt.Rows[j]["totalamount"]),
                                    JournalMemo = Convert.ToString(dt.Rows[j]["comment"]),
                                    DocumentInclude = Convert.ToString(dt.Rows[j]["docattach"]),
                                    CashDetails = cashDetailVouchers
                                };
                                if (dt.Rows[j]["objecttype"] != null)
                                {
                                    if (int.Parse(dt.Rows[j]["objecttype"].ToString().Trim()) == 1) // Khách hàng
                                    {
                                        voucher.AccountingObjectType = 3;
                                        voucher.AccountingObjectId = null;
                                        voucher.CustomerId = null;
                                        voucher.VendorId = null;
                                        voucher.EmployeeId = null;
                                    }
                                    else if (int.Parse(dt.Rows[j]["objecttype"].ToString().Trim()) == 2)
                                    // Nha cung cap
                                    {
                                        voucher.AccountingObjectType = 0;
                                        voucher.AccountingObjectId = null;
                                        voucher.CustomerId = null;
                                        if (dt.Rows[j]["objectid"] != null)
                                        {
                                            if (dt.Rows[j]["objectid"].ToString().Trim() != "")
                                            {
                                                voucher.VendorId = Model.GetIdByCode("Vendor", "VendorID",
                                                    "VendorCode",
                                                    dt.Rows[j]["objectid"].ToString().Trim());
                                            }
                                            else voucher.VendorId = null;
                                        }
                                        else voucher.VendorId = null;
                                        voucher.EmployeeId = null;
                                    }
                                    else if (int.Parse(dt.Rows[j]["objecttype"].ToString().Trim()) == 3)
                                    // Nhan vien
                                    {
                                        voucher.AccountingObjectType = 1;
                                        voucher.AccountingObjectId = null;
                                        voucher.CustomerId = null;
                                        voucher.VendorId = null;
                                        if (dt.Rows[j]["objectid"] != null)
                                        {
                                            if (dt.Rows[j]["objectid"].ToString().Trim() != "")
                                            {
                                                voucher.EmployeeId = Model.GetIdByCode("Employee",
                                                    "EmployeeID",
                                                    "EmployeeCode",
                                                    dt.Rows[j]["objectid"].ToString().Trim());
                                            }
                                            else voucher.EmployeeId = null;
                                        }
                                        else voucher.EmployeeId = null;

                                    }
                                    else // đối tượng khác
                                    {
                                        if (dt.Rows[j]["objectid"] != null)
                                        {
                                            if (dt.Rows[j]["objectid"].ToString().Trim() != "")
                                            {
                                                voucher.AccountingObjectId =
                                                    Model.GetIdByCode("AccountingObject",
                                                        "AccountingObjectID", "AccountingObjectCode",
                                                        dt.Rows[j]["objectid"].ToString().Trim());
                                            }
                                            else voucher.AccountingObjectId = null;
                                        }
                                        else voucher.AccountingObjectId = null;
                                        voucher.AccountingObjectType = 2;
                                        voucher.CustomerId = null;
                                        voucher.VendorId = null;
                                        voucher.EmployeeId = null;
                                    }
                                }
                                for (var k = 0; k < dtExpenseVoucher.Rows.Count; k++)
                                {
                                    var cashDetail = new CashDetailModel
                                    {
                                        AccountingObjectId = dtExpenseVoucher.Rows[k]["objectid"] == null ? null :
                                                    Model.GetIdByCode("AccountingObject",
                                                        "AccountingObjectID", "AccountingObjectCode",
                                                        dtExpenseVoucher.Rows[k]["objectid"].ToString().Trim()),
                                        AccountNumber = dtExpenseVoucher.Rows[k]["debitaccount"].ToString().Trim(),
                                        CorrespondingAccountNumber =
                                            dtExpenseVoucher.Rows[k]["creditaccount"].ToString().Trim(),
                                        AmountExchange = Convert.ToDecimal(dtExpenseVoucher.Rows[k]["amount"]),
                                        AmountOc = Convert.ToDecimal(dtExpenseVoucher.Rows[k]["fcamount"]),
                                        AutoBusinessId = null,
                                        BudgetItemCode = string.IsNullOrEmpty(Convert.ToString(dtExpenseVoucher.Rows[k]["budgetitemid"]).Trim()) ? null : Convert.ToString(dtExpenseVoucher.Rows[k]["budgetitemid"]),
                                        BudgetSourceCode = string.IsNullOrEmpty(Convert.ToString(dtExpenseVoucher.Rows[k]["capitalid"]).Trim()) ? null : Convert.ToString(dtExpenseVoucher.Rows[k]["capitalid"]),
                                        Description = Convert.ToString(dtExpenseVoucher.Rows[k]["description"]),
                                        MergerFundId = null,
                                        ProjectId = null,
                                    };
                                    if (Convert.ToString(dtExpenseVoucher.Rows[k]["vouchertype"]) != null)
                                    {
                                        if (int.Parse(dtExpenseVoucher.Rows[k]["vouchertype"].ToString()) != 0)
                                            cashDetail.VoucherTypeId =
                                                int.Parse(dtExpenseVoucher.Rows[k]["vouchertype"].ToString());
                                        else
                                            cashDetail.VoucherTypeId = null;
                                    }
                                    else cashDetail.VoucherTypeId = null;
                                    cashDetailVouchers.Add(cashDetail);
                                }

                                voucher.CashDetails = cashDetailVouchers;
                                Model.IsConvertData = true;
                                Model.AddPaymentVoucher(voucher);
                            }
                            break;

                        #endregion

                        #region DepositReceipt

                        case "DepositReceipt":
                            if (Model.GetDepositsByRefTypeId(300).Count > 0)
                            {
                                break;
                            }
                            for (var j = 0; j < dt.Rows.Count; j++)
                            {
                                var selectClaus = "SELECT * FROM JOURENTRYDETAIL WHERE refid = '" +
                                                  dt.Rows[j]["refid"].ToString().Trim() + "' AND reftype ='300' ";
                                var dtDepositReceiptVoucher = GetData(selectClaus);
                                ConvertFontData(ref dtDepositReceiptVoucher, "description");
                                var depositDetailVouchers = new List<DepositDetailModel>();

                                var voucher = new DepositModel
                                {
                                    AccountingObjectType = Convert.ToInt16(dt.Rows[j]["objecttype"]),
                                    RefTypeId = 300,
                                    RefNo = dt.Rows[j]["refno"].ToString().Trim(),
                                    RefDate = dt.Rows[j]["refdate"].ToString().Trim() == "" ? (DateTime?)null : Convert.ToDateTime(dt.Rows[j]["refdate"].ToString().Trim()),
                                    PostedDate = dt.Rows[j]["postdate"].ToString().Trim() == "" ? (DateTime?)null : Convert.ToDateTime(dt.Rows[j]["postdate"].ToString().Trim()),

                                    Trader = dt.Rows[j]["contactname"] == null ? "" : dt.Rows[j]["contactname"].ToString().Trim(),
                                    CurrencyCode = dt.Rows[j]["ccyid"].ToString().Trim(),
                                    BankAccountCode = Convert.ToString(dt.Rows[j]["bankaccount"]),
                                    TotalAmountOc = Convert.ToDecimal(dt.Rows[j]["fctotalamount"]),
                                    ExchangeRate = Convert.ToDecimal(dt.Rows[j]["exchangerate"]),
                                    TotalAmountExchange = Convert.ToDecimal(dt.Rows[j]["totalamount"]),
                                    JournalMemo = Convert.ToString(dt.Rows[j]["comment"]),
                                };
                                if (dt.Rows[j]["objecttype"] != null)
                                {
                                    if (int.Parse(dt.Rows[j]["objecttype"].ToString().Trim()) == 1) // Khách hàng
                                    {
                                        voucher.AccountingObjectType = 3;
                                        voucher.AccountingObjectId = null;
                                        voucher.CustomerId = null;
                                        voucher.VendorId = null;
                                        voucher.EmployeeId = null;
                                    }
                                    else if (int.Parse(dt.Rows[j]["objecttype"].ToString().Trim()) == 2)
                                    // Nha cung cap
                                    {
                                        voucher.AccountingObjectType = 0;
                                        voucher.AccountingObjectId = null;
                                        voucher.CustomerId = null;
                                        if (dt.Rows[j]["objectid"] != null)
                                        {
                                            if (dt.Rows[j]["objectid"].ToString().Trim() != "")
                                            {
                                                voucher.VendorId = Model.GetIdByCode("Vendor", "VendorID",
                                                    "VendorCode",
                                                    dt.Rows[j]["objectid"].ToString().Trim());
                                            }
                                            else voucher.VendorId = null;
                                        }
                                        else voucher.VendorId = null;
                                        voucher.EmployeeId = null;
                                    }
                                    else if (int.Parse(dt.Rows[j]["objecttype"].ToString().Trim()) == 3)
                                    // Nhan vien
                                    {
                                        voucher.AccountingObjectType = 1;
                                        voucher.AccountingObjectId = null;
                                        voucher.CustomerId = null;
                                        voucher.VendorId = null;
                                        if (dt.Rows[j]["objectid"] != null)
                                        {
                                            if (dt.Rows[j]["objectid"].ToString().Trim() != "")
                                            {
                                                voucher.EmployeeId = Model.GetIdByCode("Employee",
                                                    "EmployeeID",
                                                    "EmployeeCode",
                                                    dt.Rows[j]["objectid"].ToString().Trim());
                                            }
                                            else voucher.EmployeeId = null;
                                        }
                                        else voucher.EmployeeId = null;

                                    }
                                    else // đối tượng khác
                                    {
                                        if (dt.Rows[j]["objectid"] != null)
                                        {
                                            if (dt.Rows[j]["objectid"].ToString().Trim() != "")
                                            {
                                                voucher.AccountingObjectId =
                                                    Model.GetIdByCode("AccountingObject",
                                                        "AccountingObjectID", "AccountingObjectCode",
                                                        dt.Rows[j]["objectid"].ToString().Trim());
                                            }
                                            else voucher.AccountingObjectId = null;
                                        }
                                        else voucher.AccountingObjectId = null;
                                        voucher.AccountingObjectType = 2;
                                        voucher.CustomerId = null;
                                        voucher.VendorId = null;
                                        voucher.EmployeeId = null;
                                    }
                                }
                                for (var k = 0; k < dtDepositReceiptVoucher.Rows.Count; k++)
                                {
                                    var depositDetail = new DepositDetailModel
                                    {
                                        AccountingObjectId = dtDepositReceiptVoucher.Rows[k]["objectid"] == null ? null :
                                                    Model.GetIdByCode("AccountingObject",
                                                        "AccountingObjectID", "AccountingObjectCode",
                                                        dtDepositReceiptVoucher.Rows[k]["objectid"].ToString().Trim()),
                                        AccountNumber = dtDepositReceiptVoucher.Rows[k]["debitaccount"].ToString().Trim(),
                                        CorrespondingAccountNumber =
                                            dtDepositReceiptVoucher.Rows[k]["creditaccount"].ToString().Trim(),
                                        AmountExchange = Convert.ToDecimal(dtDepositReceiptVoucher.Rows[k]["amount"]),
                                        AmountOc = Convert.ToDecimal(dtDepositReceiptVoucher.Rows[k]["fcamount"]),
                                        AutoBusinessId = null,
                                        BudgetItemCode = string.IsNullOrEmpty(Convert.ToString(dtDepositReceiptVoucher.Rows[k]["budgetitemid"]).Trim()) ? null : Convert.ToString(dtDepositReceiptVoucher.Rows[k]["budgetitemid"]),
                                        BudgetSourceCode = string.IsNullOrEmpty(Convert.ToString(dtDepositReceiptVoucher.Rows[k]["capitalid"]).Trim()) ? null : Convert.ToString(dtDepositReceiptVoucher.Rows[k]["capitalid"]),
                                        Description = Convert.ToString(dtDepositReceiptVoucher.Rows[k]["description"]),
                                        MergerFundId = null,
                                        ProjectId = null,
                                        DepartmentId = null,
                                    };
                                    if (Convert.ToString(dtDepositReceiptVoucher.Rows[k]["vouchertype"]) != null)
                                    {
                                        if (int.Parse(dtDepositReceiptVoucher.Rows[k]["vouchertype"].ToString()) != 0)
                                            depositDetail.VoucherTypeId =
                                                int.Parse(dtDepositReceiptVoucher.Rows[k]["vouchertype"].ToString());
                                        else
                                            depositDetail.VoucherTypeId = null;
                                    }
                                    else depositDetail.VoucherTypeId = null;
                                    depositDetailVouchers.Add(depositDetail);
                                }

                                voucher.DepositDetails = depositDetailVouchers;
                                Model.IsConvertData = true;
                                Model.AddDeposit(voucher);
                            }
                            break;

                        #endregion

                        #region DepositExpense

                        case "DepositExpense":
                            if (Model.GetDepositsByRefTypeId(301).Count > 0)
                            {
                                break;
                            }
                            for (var j = 0; j < dt.Rows.Count; j++)
                            {
                                var selectClaus = "SELECT * FROM JOURENTRYDETAIL WHERE refid = '" +
                                                  dt.Rows[j]["refid"].ToString().Trim() + "' AND reftype ='301' ";
                                var dtExpenseVoucher = GetData(selectClaus);
                                ConvertFontData(ref dtExpenseVoucher, "description");
                                var depositDetailVouchers = new List<DepositDetailModel>();

                                var voucher = new DepositModel
                                {
                                    AccountingObjectType = Convert.ToInt16(dt.Rows[j]["objecttype"]),
                                    RefTypeId = 301,
                                    RefNo = dt.Rows[j]["refno"].ToString().Trim(),
                                    RefDate = dt.Rows[j]["refdate"].ToString().Trim() == "" ? (DateTime?)null : Convert.ToDateTime(dt.Rows[j]["refdate"].ToString().Trim()),
                                    PostedDate = dt.Rows[j]["postdate"].ToString().Trim() == "" ? (DateTime?)null : Convert.ToDateTime(dt.Rows[j]["postdate"].ToString().Trim()),

                                    Trader = Convert.ToString(dt.Rows[j]["contactname"]),
                                    CurrencyCode = dt.Rows[j]["ccyid"].ToString().Trim(),
                                    BankAccountCode = dt.Rows[j]["bankaccount"].ToString().Trim(),
                                    TotalAmountOc = Convert.ToDecimal(dt.Rows[j]["fctotalamount"]),
                                    ExchangeRate = Convert.ToDecimal(dt.Rows[j]["exchangerate"]),
                                    TotalAmountExchange = Convert.ToDecimal(dt.Rows[j]["totalamount"]),
                                    JournalMemo = Convert.ToString(dt.Rows[j]["comment"]),
                                };

                                #region AccountingObject Master
                                if (dt.Rows[j]["objecttype"] != null)
                                {
                                    if (int.Parse(dt.Rows[j]["objecttype"].ToString().Trim()) == 1) // Khách hàng
                                    {
                                        voucher.AccountingObjectType = 3;
                                        voucher.AccountingObjectId = null;
                                        voucher.CustomerId = null;
                                        voucher.VendorId = null;
                                        voucher.EmployeeId = null;
                                    }
                                    else if (int.Parse(dt.Rows[j]["objecttype"].ToString().Trim()) == 2)
                                    // Nha cung cap
                                    {
                                        voucher.AccountingObjectType = 0;
                                        voucher.AccountingObjectId = null;
                                        voucher.CustomerId = null;
                                        if (dt.Rows[j]["objectid"] != null)
                                        {
                                            if (dt.Rows[j]["objectid"].ToString().Trim() != "")
                                            {
                                                voucher.VendorId = Model.GetIdByCode("Vendor", "VendorID",
                                                    "VendorCode",
                                                    dt.Rows[j]["objectid"].ToString().Trim());
                                            }
                                            else voucher.VendorId = null;
                                        }
                                        else voucher.VendorId = null;
                                        voucher.EmployeeId = null;
                                    }
                                    else if (int.Parse(dt.Rows[j]["objecttype"].ToString().Trim()) == 3)
                                    // Nhan vien
                                    {
                                        voucher.AccountingObjectType = 1;
                                        voucher.AccountingObjectId = null;
                                        voucher.CustomerId = null;
                                        voucher.VendorId = null;
                                        if (dt.Rows[j]["objectid"] != null)
                                        {
                                            if (dt.Rows[j]["objectid"].ToString().Trim() != "")
                                            {
                                                voucher.EmployeeId = Model.GetIdByCode("Employee",
                                                    "EmployeeID",
                                                    "EmployeeCode",
                                                    dt.Rows[j]["objectid"].ToString().Trim());
                                            }
                                            else voucher.EmployeeId = null;
                                        }
                                        else voucher.EmployeeId = null;

                                    }
                                    else // đối tượng khác
                                    {
                                        if (dt.Rows[j]["objectid"] != null)
                                        {
                                            if (dt.Rows[j]["objectid"].ToString().Trim() != "")
                                            {
                                                voucher.AccountingObjectId =
                                                    Model.GetIdByCode("AccountingObject",
                                                        "AccountingObjectID", "AccountingObjectCode",
                                                        dt.Rows[j]["objectid"].ToString().Trim());
                                            }
                                            else voucher.AccountingObjectId = null;
                                        }
                                        else voucher.AccountingObjectId = null;
                                        voucher.AccountingObjectType = 2;
                                        voucher.CustomerId = null;
                                        voucher.VendorId = null;
                                        voucher.EmployeeId = null;
                                    }
                                }
                                #endregion

                                for (var k = 0; k < dtExpenseVoucher.Rows.Count; k++)
                                {
                                    var depositDetail = new DepositDetailModel
                                    {
                                        AccountingObjectId = dtExpenseVoucher.Rows[k]["objectid"] == null ? null :
                                                    Model.GetIdByCode("AccountingObject",
                                                        "AccountingObjectID", "AccountingObjectCode",
                                                        dtExpenseVoucher.Rows[k]["objectid"].ToString().Trim()),
                                        AccountNumber = dtExpenseVoucher.Rows[k]["debitaccount"].ToString().Trim(),
                                        CorrespondingAccountNumber =
                                            dtExpenseVoucher.Rows[k]["creditaccount"].ToString().Trim(),
                                        AmountExchange = Convert.ToDecimal(dtExpenseVoucher.Rows[k]["amount"]),
                                        AmountOc = Convert.ToDecimal(dtExpenseVoucher.Rows[k]["fcamount"]),
                                        AutoBusinessId = null,
                                        BudgetItemCode = string.IsNullOrEmpty(Convert.ToString(dtExpenseVoucher.Rows[k]["budgetitemid"]).Trim()) ? null : Convert.ToString(dtExpenseVoucher.Rows[k]["budgetitemid"]),
                                        BudgetSourceCode = string.IsNullOrEmpty(Convert.ToString(dtExpenseVoucher.Rows[k]["capitalid"]).Trim()) ? null : Convert.ToString(dtExpenseVoucher.Rows[k]["capitalid"]),
                                        Description = Convert.ToString(dtExpenseVoucher.Rows[k]["description"]),
                                        MergerFundId = null,
                                        ProjectId = null,
                                        DepartmentId = null,
                                    };
                                    if (dtExpenseVoucher.Rows[k]["vouchertype"] != null)
                                    {
                                        if (int.Parse(dtExpenseVoucher.Rows[k]["vouchertype"].ToString()) != 0)
                                            depositDetail.VoucherTypeId =
                                                int.Parse(dtExpenseVoucher.Rows[k]["vouchertype"].ToString());
                                        else
                                            depositDetail.VoucherTypeId = null;
                                    }
                                    else depositDetail.VoucherTypeId = null;
                                    depositDetailVouchers.Add(depositDetail);
                                }

                                voucher.DepositDetails = depositDetailVouchers;
                                Model.AddDeposit(voucher);
                            }
                            break;

                        #endregion

                        #region InputInventory

                        case "InputInventory":
                            if (Model.GetItemTransactionVoucherByRefTypeId(400).Count > 0)
                            {
                                break;
                            }
                            for (var j = 0; j < dt.Rows.Count; j++)
                            {
                                var selectClaus = "SELECT * FROM JOURENTRYDETAIL WHERE refid = '" +
                                                  dt.Rows[j]["refid"].ToString().Trim() + "' AND reftype ='400' ";
                                var dtInputInventoryVoucher = GetData(selectClaus);
                                ConvertFontData(ref dtInputInventoryVoucher, "description");
                                var itemTransactionDetailVouchers = new List<ItemTransactionDetailModel>();

                                var voucher = new ItemTransactionModel
                                {
                                    AccountingObjectType = int.Parse(dt.Rows[j]["objecttype"].ToString().Trim()),
                                    RefTypeId = 400,
                                    RefNo = dt.Rows[j]["refno"].ToString().Trim(),
                                    RefDate = DateTime.Parse(dt.Rows[j]["refdate"].ToString().Trim()),
                                    PostedDate = DateTime.Parse(dt.Rows[j]["postdate"].ToString().Trim()),
                                    Trader = dt.Rows[j]["contactname"] == null ? "" : dt.Rows[j]["contactname"].ToString().Trim(),
                                    CurrencyCode = dt.Rows[j]["ccyid"].ToString().Trim(),
                                    TotalAmount = decimal.Parse(dt.Rows[j]["fctotalamount"].ToString().Trim()),
                                    ExchangeRate = decimal.Parse(dt.Rows[j]["exchangerate"].ToString().Trim()),
                                    TotalAmountExchange = decimal.Parse(dt.Rows[j]["totalamount"].ToString().Trim()),
                                    JournalMemo = dt.Rows[j]["comment"] == null ? "" : dt.Rows[j]["comment"].ToString().TrimEnd(),
                                    ItemTransactionDetails = itemTransactionDetailVouchers,
                                    DocumentInclude = "",
                                    IsCalculatePrice = true,
                                    TaxCode = null
                                };
                                if (dt.Rows[j]["StockId"] != null)
                                {
                                    if (dt.Rows[j]["StockId"].ToString().Trim() != "")
                                    {
                                        voucher.StockId = (int)Model.GetIdByCode("Stock", "StockID", "StockCode",
                                            dt.Rows[j]["StockId"].ToString().Trim());
                                    }
                                }
                                if (dt.Rows[j]["objecttype"] != null)
                                {
                                    if (int.Parse(dt.Rows[j]["objecttype"].ToString().Trim()) == 1) // Khách hàng
                                    {
                                        voucher.AccountingObjectType = 3;
                                        voucher.AccountingObjectId = null;
                                        voucher.CustomerId = null;
                                        voucher.VendorId = null;
                                        voucher.EmployeeId = null;
                                    }
                                    else if (int.Parse(dt.Rows[j]["objecttype"].ToString().Trim()) == 2)
                                    // Nha cung cap
                                    {
                                        voucher.AccountingObjectType = 0;
                                        voucher.AccountingObjectId = null;
                                        voucher.CustomerId = null;
                                        if (dt.Rows[j]["objectid"] != null)
                                        {
                                            if (dt.Rows[j]["objectid"].ToString().Trim() != "")
                                            {
                                                voucher.VendorId = Model.GetIdByCode("Vendor", "VendorID",
                                                    "VendorCode",
                                                    dt.Rows[j]["objectid"].ToString().Trim());
                                            }
                                            else voucher.VendorId = null;
                                        }
                                        else voucher.VendorId = null;
                                        voucher.EmployeeId = null;
                                    }
                                    else if (int.Parse(dt.Rows[j]["objecttype"].ToString().Trim()) == 3)
                                    // Nhan vien
                                    {
                                        voucher.AccountingObjectType = 1;
                                        voucher.AccountingObjectId = null;
                                        voucher.CustomerId = null;
                                        voucher.VendorId = null;
                                        if (dt.Rows[j]["objectid"] != null)
                                        {
                                            if (dt.Rows[j]["objectid"].ToString().Trim() != "")
                                            {
                                                voucher.EmployeeId = Model.GetIdByCode("Employee",
                                                    "EmployeeID",
                                                    "EmployeeCode",
                                                    dt.Rows[j]["objectid"].ToString().Trim());
                                            }
                                            else voucher.EmployeeId = null;
                                        }
                                        else voucher.EmployeeId = null;

                                    }
                                    else // đối tượng khác
                                    {
                                        if (dt.Rows[j]["objectid"] != null)
                                        {
                                            if (dt.Rows[j]["objectid"].ToString().Trim() != "")
                                            {
                                                voucher.AccountingObjectId =
                                                    Model.GetIdByCode("AccountingObject",
                                                        "AccountingObjectID", "AccountingObjectCode",
                                                        dt.Rows[j]["objectid"].ToString().Trim());
                                            }
                                            else voucher.AccountingObjectId = null;
                                        }
                                        else voucher.AccountingObjectId = null;
                                        voucher.AccountingObjectType = 2;
                                        voucher.CustomerId = null;
                                        voucher.VendorId = null;
                                        voucher.EmployeeId = null;
                                    }
                                }
                                for (var k = 0; k < dtInputInventoryVoucher.Rows.Count; k++)
                                {
                                    var itemTransactionDetail = new ItemTransactionDetailModel
                                    {
                                        AccountingObjectId = dtInputInventoryVoucher.Rows[k]["objectid"] == null ? null :
                                                    Model.GetIdByCode("AccountingObject",
                                                        "AccountingObjectID", "AccountingObjectCode",
                                                        dtInputInventoryVoucher.Rows[k]["objectid"].ToString().Trim()),
                                        AccountNumber =
                                            dtInputInventoryVoucher.Rows[k]["debitaccount"].ToString().Trim(),
                                        CorrespondingAccountNumber =
                                            dtInputInventoryVoucher.Rows[k]["creditaccount"].ToString().Trim(),
                                        AmountExchange =
                                            decimal.Parse(
                                                dtInputInventoryVoucher.Rows[k]["amount"].ToString().Trim()),
                                        AmountOc =
                                            decimal.Parse(
                                                dtInputInventoryVoucher.Rows[k]["fcamount"].ToString().Trim()),
                                        AutoBusinessId = null,
                                        BudgetItemCode = dtInputInventoryVoucher.Rows[k]["budgetitemid"] == null ? null :
                                            dtInputInventoryVoucher.Rows[k]["budgetitemid"].ToString().Trim(),
                                        BudgetSourceCode = dtInputInventoryVoucher.Rows[k]["capitalid"] == null ? null :
                                            dtInputInventoryVoucher.Rows[k]["capitalid"].ToString().Trim(),
                                        Description = dtInputInventoryVoucher.Rows[k]["description"] == null ? "" :
                                            dtInputInventoryVoucher.Rows[k]["description"].ToString().TrimEnd(),
                                        MergerFundId = null,
                                        ProjectId = null,
                                        InventoryItemId =
                                            (int)
                                                Model.GetIdByCode("InventoryItem", "InventoryItemID",
                                                    "InventoryItemCode",
                                                    dtInputInventoryVoucher.Rows[k]["itemid"].ToString().Trim()),
                                        Price =
                                            decimal.Parse(
                                                dtInputInventoryVoucher.Rows[k]["fcunitprice"].ToString().Trim()),
                                        PriceExchange =
                                            decimal.Parse(
                                                dtInputInventoryVoucher.Rows[k]["unitprice"].ToString().Trim()),
                                        Quantity =
                                            (dtInputInventoryVoucher.Rows[k]["quantity"] != null)
                                                ? (int)
                                                    decimal.Parse(
                                                        dtInputInventoryVoucher.Rows[k]["quantity"].ToString())
                                                : 0
                                    };
                                    if (dtInputInventoryVoucher.Rows[k]["vouchertype"] != null)
                                    {
                                        if (int.Parse(dtInputInventoryVoucher.Rows[k]["vouchertype"].ToString()) != 0)
                                            itemTransactionDetail.VoucherTypeId =
                                                int.Parse(dtInputInventoryVoucher.Rows[k]["vouchertype"].ToString());
                                        else
                                            itemTransactionDetail.VoucherTypeId = null;
                                    }
                                    else itemTransactionDetail.VoucherTypeId = null;
                                    itemTransactionDetailVouchers.Add(itemTransactionDetail);
                                }

                                voucher.ItemTransactionDetails = itemTransactionDetailVouchers;
                                Model.AddItemTransactionVoucher(voucher, false);
                            }
                            break;

                        #endregion

                        #region OutputInventory

                        case "OutputInventory":
                            if (Model.GetItemTransactionVoucherByRefTypeId(401).Count > 0)
                            {
                                break;
                            }
                            for (var j = 0; j < dt.Rows.Count; j++)
                            {
                                var selectClaus = "SELECT * FROM JOURENTRYDETAIL WHERE refid = '" +
                                                  dt.Rows[j]["refid"].ToString().Trim() + "' AND reftype ='401' ";
                                var dtOutputInventoryVoucher = GetData(selectClaus);
                                ConvertFontData(ref dtOutputInventoryVoucher, "description");
                                var itemTransactionDetailVouchers = new List<ItemTransactionDetailModel>();

                                var voucher = new ItemTransactionModel
                                {
                                    AccountingObjectType = int.Parse(dt.Rows[j]["objecttype"].ToString().Trim()),
                                    RefTypeId = 401,
                                    RefNo = dt.Rows[j]["refno"].ToString().Trim(),
                                    RefDate = DateTime.Parse(dt.Rows[j]["refdate"].ToString().Trim()),
                                    PostedDate = DateTime.Parse(dt.Rows[j]["postdate"].ToString().Trim()),
                                    Trader = dt.Rows[j]["contactname"] == null ? "" : dt.Rows[j]["contactname"].ToString().Trim(),
                                    CurrencyCode = dt.Rows[j]["ccyid"].ToString().Trim(),
                                    TotalAmount = decimal.Parse(dt.Rows[j]["fctotalamount"].ToString().Trim()),
                                    ExchangeRate = decimal.Parse(dt.Rows[j]["exchangerate"].ToString().Trim()),
                                    TotalAmountExchange = decimal.Parse(dt.Rows[j]["totalamount"].ToString().Trim()),
                                    JournalMemo = dt.Rows[j]["comment"] == null ? "" : dt.Rows[j]["comment"].ToString().TrimEnd(),
                                    ItemTransactionDetails = itemTransactionDetailVouchers,
                                    DocumentInclude = "",
                                    IsCalculatePrice = true,
                                    TaxCode = null
                                };
                                if (dt.Rows[j]["StockId"] != null)
                                {
                                    if (dt.Rows[j]["StockId"].ToString().Trim() != "")
                                    {
                                        voucher.StockId = (int)Model.GetIdByCode("Stock", "StockID", "StockCode",
                                            dt.Rows[j]["StockId"].ToString().Trim());
                                    }
                                }
                                if (dt.Rows[j]["objecttype"] != null)
                                {
                                    if (int.Parse(dt.Rows[j]["objecttype"].ToString().Trim()) == 1) // Khách hàng
                                    {
                                        voucher.AccountingObjectType = 3;
                                        voucher.AccountingObjectId = null;
                                        voucher.CustomerId = null;
                                        voucher.VendorId = null;
                                        voucher.EmployeeId = null;
                                    }
                                    else if (int.Parse(dt.Rows[j]["objecttype"].ToString().Trim()) == 2)
                                    // Nha cung cap
                                    {
                                        voucher.AccountingObjectType = 0;
                                        voucher.AccountingObjectId = null;
                                        voucher.CustomerId = null;
                                        if (dt.Rows[j]["objectid"] != null)
                                        {
                                            if (dt.Rows[j]["objectid"].ToString().Trim() != "")
                                            {
                                                voucher.VendorId = Model.GetIdByCode("Vendor", "VendorID",
                                                    "VendorCode",
                                                    dt.Rows[j]["objectid"].ToString().Trim());
                                            }
                                            else voucher.VendorId = null;
                                        }
                                        else voucher.VendorId = null;
                                        voucher.EmployeeId = null;
                                    }
                                    else if (int.Parse(dt.Rows[j]["objecttype"].ToString().Trim()) == 3)
                                    // Nhan vien
                                    {
                                        voucher.AccountingObjectType = 1;
                                        voucher.AccountingObjectId = null;
                                        voucher.CustomerId = null;
                                        voucher.VendorId = null;
                                        if (dt.Rows[j]["objectid"] != null)
                                        {
                                            if (dt.Rows[j]["objectid"].ToString().Trim() != "")
                                            {
                                                voucher.EmployeeId = Model.GetIdByCode("Employee",
                                                    "EmployeeID",
                                                    "EmployeeCode",
                                                    dt.Rows[j]["objectid"].ToString().Trim());
                                            }
                                            else voucher.EmployeeId = null;
                                        }
                                        else voucher.EmployeeId = null;

                                    }
                                    else // đối tượng khác
                                    {
                                        if (dt.Rows[j]["objectid"] != null)
                                        {
                                            if (dt.Rows[j]["objectid"].ToString().Trim() != "")
                                            {
                                                voucher.AccountingObjectId =
                                                    Model.GetIdByCode("AccountingObject",
                                                        "AccountingObjectID", "AccountingObjectCode",
                                                        dt.Rows[j]["objectid"].ToString().Trim());
                                            }
                                            else voucher.AccountingObjectId = null;
                                        }
                                        else voucher.AccountingObjectId = null;
                                        voucher.AccountingObjectType = 2;
                                        voucher.CustomerId = null;
                                        voucher.VendorId = null;
                                        voucher.EmployeeId = null;
                                    }
                                }
                                for (var k = 0; k < dtOutputInventoryVoucher.Rows.Count; k++)
                                {
                                    var itemTransactionDetail = new ItemTransactionDetailModel
                                    {
                                        AccountingObjectId = dtOutputInventoryVoucher.Rows[k]["objectid"] == null ? null :
                                                    Model.GetIdByCode("AccountingObject",
                                                        "AccountingObjectID", "AccountingObjectCode",
                                                        dtOutputInventoryVoucher.Rows[k]["objectid"].ToString().Trim()),
                                        AccountNumber =
                                            dtOutputInventoryVoucher.Rows[k]["debitaccount"].ToString().Trim(),
                                        CorrespondingAccountNumber =
                                            dtOutputInventoryVoucher.Rows[k]["creditaccount"].ToString().Trim(),
                                        AmountExchange =
                                            decimal.Parse(
                                                dtOutputInventoryVoucher.Rows[k]["amount"].ToString().Trim()),
                                        AmountOc =
                                            decimal.Parse(
                                                dtOutputInventoryVoucher.Rows[k]["fcamount"].ToString().Trim()),
                                        AutoBusinessId = null,
                                        BudgetItemCode = dtOutputInventoryVoucher.Rows[k]["budgetitemid"] == null ? null :
                                            dtOutputInventoryVoucher.Rows[k]["budgetitemid"].ToString().Trim(),
                                        BudgetSourceCode = dtOutputInventoryVoucher.Rows[k]["capitalid"] == null ? null :
                                            dtOutputInventoryVoucher.Rows[k]["capitalid"].ToString().Trim(),
                                        Description = dtOutputInventoryVoucher.Rows[k]["description"] == null ? "" :
                                            dtOutputInventoryVoucher.Rows[k]["description"].ToString().TrimEnd(),
                                        MergerFundId = null,
                                        ProjectId = null,
                                        InventoryItemId =
                                            (int)
                                                Model.GetIdByCode("InventoryItem", "InventoryItemID",
                                                    "InventoryItemCode",
                                                    dtOutputInventoryVoucher.Rows[k]["itemid"].ToString().Trim()),
                                        Price =
                                            decimal.Parse(
                                                dtOutputInventoryVoucher.Rows[k]["fcunitprice"].ToString().Trim()),
                                        PriceExchange =
                                            decimal.Parse(
                                                dtOutputInventoryVoucher.Rows[k]["unitprice"].ToString().Trim()),
                                        Quantity =
                                            (dtOutputInventoryVoucher.Rows[k]["quantity"] != null)
                                                ? (int)
                                                    decimal.Parse(
                                                        dtOutputInventoryVoucher.Rows[k]["quantity"].ToString())
                                                : 0
                                    };
                                    if (dtOutputInventoryVoucher.Rows[k]["vouchertype"] != null)
                                    {
                                        if (int.Parse(dtOutputInventoryVoucher.Rows[k]["vouchertype"].ToString()) != 0)
                                            itemTransactionDetail.VoucherTypeId =
                                                int.Parse(dtOutputInventoryVoucher.Rows[k]["vouchertype"].ToString());
                                        else
                                            itemTransactionDetail.VoucherTypeId = null;
                                    }
                                    else itemTransactionDetail.VoucherTypeId = null;
                                    itemTransactionDetailVouchers.Add(itemTransactionDetail);
                                }

                                voucher.ItemTransactionDetails = itemTransactionDetailVouchers;
                                Model.AddItemTransactionVoucher(voucher, false);
                            }
                            break;

                        #endregion

                        #region FixedAssetIncrease

                        case "FixedAssetIncrease":
                            if (Model.GetFixedAssetIncrements().Count > 0)
                            {
                                break;
                            }
                            for (var j = 0; j < dt.Rows.Count; j++)
                            {
                                var selectClaus = "SELECT * FROM JOURENTRYDETAIL WHERE refid = '" +
                                                  dt.Rows[j]["refid"].ToString().Trim() + "' AND reftype ='500' ";
                                var dtFixedAssetIncrementDetailVoucher = GetData(selectClaus);
                                ConvertFontData(ref dtFixedAssetIncrementDetailVoucher, "description");
                                var fixedAssetIncrementDetailVouchers = new List<FixedAssetIncrementDetailModel>();

                                var voucher = new FixedAssetIncrementModel
                                {
                                    AccountingObjectType = int.Parse(dt.Rows[j]["objecttype"].ToString().Trim()),
                                    RefTypeId = 500,
                                    RefNo = dt.Rows[j]["refno"].ToString().Trim(),
                                    RefDate = dt.Rows[j]["refdate"].ToString().Trim(),
                                    PostedDate = dt.Rows[j]["postdate"].ToString().Trim(),
                                    CurrencyCode = dt.Rows[j]["ccyid"].ToString().Trim(),
                                    TotalAmountOC = decimal.Parse(dt.Rows[j]["fctotalamount"].ToString().Trim()),
                                    ExchangeRate = decimal.Parse(dt.Rows[j]["exchangerate"].ToString().Trim()),
                                    TotalAmountExchange = decimal.Parse(dt.Rows[j]["totalamount"].ToString().Trim()),
                                    JournalMemo = dt.Rows[j]["comment"] == null ? "" : dt.Rows[j]["comment"].ToString().TrimEnd(),
                                    FixedAssetIncrementDetails = fixedAssetIncrementDetailVouchers,
                                };
                                if (dt.Rows[j]["objecttype"] != null)
                                {
                                    if (int.Parse(dt.Rows[j]["objecttype"].ToString().Trim()) == 1) // Khách hàng
                                    {
                                        voucher.AccountingObjectType = 3;
                                        voucher.AccountingObjectId = null;
                                        voucher.CustomerId = null;
                                        voucher.VendorId = null;
                                        voucher.EmployeeId = null;
                                    }
                                    else if (int.Parse(dt.Rows[j]["objecttype"].ToString().Trim()) == 2)
                                    // Nha cung cap
                                    {
                                        voucher.AccountingObjectType = 0;
                                        voucher.AccountingObjectId = null;
                                        voucher.CustomerId = null;
                                        if (dt.Rows[j]["objectid"] != null)
                                        {
                                            if (dt.Rows[j]["objectid"].ToString().Trim() != "")
                                            {
                                                voucher.VendorId = Model.GetIdByCode("Vendor", "VendorID",
                                                    "VendorCode",
                                                    dt.Rows[j]["objectid"].ToString().Trim());
                                            }
                                            else voucher.VendorId = null;
                                        }
                                        else voucher.VendorId = null;
                                        voucher.EmployeeId = null;
                                    }
                                    else if (int.Parse(dt.Rows[j]["objecttype"].ToString().Trim()) == 3)
                                    // Nhan vien
                                    {
                                        voucher.AccountingObjectType = 1;
                                        voucher.AccountingObjectId = null;
                                        voucher.CustomerId = null;
                                        voucher.VendorId = null;
                                        if (dt.Rows[j]["objectid"] != null)
                                        {
                                            if (dt.Rows[j]["objectid"].ToString().Trim() != "")
                                            {
                                                voucher.EmployeeId = Model.GetIdByCode("Employee",
                                                    "EmployeeID",
                                                    "EmployeeCode",
                                                    dt.Rows[j]["objectid"].ToString().Trim());
                                            }
                                            else voucher.EmployeeId = null;
                                        }
                                        else voucher.EmployeeId = null;

                                    }
                                    else // đối tượng khác
                                    {
                                        if (dt.Rows[j]["objectid"] != null)
                                        {
                                            if (dt.Rows[j]["objectid"].ToString().Trim() != "")
                                            {
                                                voucher.AccountingObjectId =
                                                    Model.GetIdByCode("AccountingObject",
                                                        "AccountingObjectID", "AccountingObjectCode",
                                                        dt.Rows[j]["objectid"].ToString().Trim());
                                            }
                                            else voucher.AccountingObjectId = null;
                                        }
                                        else voucher.AccountingObjectId = null;
                                        voucher.AccountingObjectType = 2;
                                        voucher.CustomerId = null;
                                        voucher.VendorId = null;
                                        voucher.EmployeeId = null;
                                    }
                                }

                                for (var k = 0; k < dtFixedAssetIncrementDetailVoucher.Rows.Count; k++)
                                {
                                    var fixedAssetId = Model.GetIdByCode("FixedAsset", "FixedAssetID", "FixedAssetCode",
                                        dtFixedAssetIncrementDetailVoucher.Rows[k]["fixedassetid"].ToString().Trim());
                                    fixedAssetIncrementDetailVouchers.Add(new FixedAssetIncrementDetailModel
                                    {
                                        AccountingObjectId = dtFixedAssetIncrementDetailVoucher.Rows[k]["objectid"] == null ? null :
                                                    Model.GetIdByCode("AccountingObject",
                                                        "AccountingObjectID", "AccountingObjectCode",
                                                        dtFixedAssetIncrementDetailVoucher.Rows[k]["objectid"].ToString().Trim()),
                                        AccountNumber =
                                            dtFixedAssetIncrementDetailVoucher.Rows[k]["debitaccount"].ToString()
                                                .Trim(),
                                        CorrespondingAccountNumber =
                                            dtFixedAssetIncrementDetailVoucher.Rows[k]["creditaccount"].ToString()
                                                .Trim(),
                                        AmountExchange =
                                            decimal.Parse(
                                                dtFixedAssetIncrementDetailVoucher.Rows[k]["amount"].ToString()
                                                    .Trim()),
                                        AmountOC =
                                            decimal.Parse(
                                                dtFixedAssetIncrementDetailVoucher.Rows[k]["fcamount"].ToString()
                                                    .Trim()),
                                        AutoBusinessId = null,
                                        BudgetItemCode = dtFixedAssetIncrementDetailVoucher.Rows[k]["budgetitemid"] == null ? null :
                                            dtFixedAssetIncrementDetailVoucher.Rows[k]["budgetitemid"].ToString()
                                                .Trim(),
                                        BudgetSourceCode = dtFixedAssetIncrementDetailVoucher.Rows[k]["capitalid"] == null ? null :
                                            dtFixedAssetIncrementDetailVoucher.Rows[k]["capitalid"].ToString()
                                                .Trim(),
                                        Description = dtFixedAssetIncrementDetailVoucher.Rows[k]["description"] == null ? "" :
                                            dtFixedAssetIncrementDetailVoucher.Rows[k]["description"].ToString()
                                                .TrimEnd(),
                                        VoucherTypeId = null,
                                        ProjectId = null,
                                        FixedAssetId = fixedAssetId,
                                        UnitPriceOC =
                                            decimal.Parse(
                                                dtFixedAssetIncrementDetailVoucher.Rows[k]["fcunitprice"].ToString()
                                                    .Trim()),
                                        UnitPriceExchange =
                                            decimal.Parse(
                                                dtFixedAssetIncrementDetailVoucher.Rows[k]["unitprice"].ToString()
                                                    .Trim()),
                                        Quantity =
                                            (dtFixedAssetIncrementDetailVoucher.Rows[k]["quantity"] != null)
                                                ? (int)
                                                    decimal.Parse(
                                                        dtFixedAssetIncrementDetailVoucher.Rows[k]["quantity"]
                                                            .ToString())
                                                : 0,
                                        DepartmentId =
                                            Model.GetIdByCode("Department", "DepartmentID", "DepartmentCode",
                                                dtFixedAssetIncrementDetailVoucher.Rows[k]["departid"].ToString()
                                                    .Trim()),
                                    });
                                }

                                voucher.FixedAssetIncrementDetails = fixedAssetIncrementDetailVouchers;
                                Model.AddFixedAssetIncrement(voucher, false);
                            }
                            break;

                        #endregion

                        #region FixedAssetDecrease

                        case "FixedAssetDecrease":
                            if (Model.GetFixedAssetDecrements().Count > 0)
                            {
                                break;
                            }
                            for (var j = 0; j < dt.Rows.Count; j++)
                            {
                                var selectClaus = "SELECT * FROM JOURENTRYDETAIL WHERE refid = '" +
                                                  dt.Rows[j]["refid"].ToString().Trim() + "' AND reftype ='501' ";
                                var dtFixedAssetDecrementDetailVoucher = GetData(selectClaus);
                                ConvertFontData(ref dtFixedAssetDecrementDetailVoucher, "description");
                                var fixedAssetDecrementDetailVouchers = new List<FixedAssetDecrementDetailModel>();

                                var voucher = new FixedAssetDecrementModel
                                {
                                    AccountingObjectType = int.Parse(dt.Rows[j]["objecttype"].ToString().Trim()),
                                    RefTypeId = 501,
                                    RefNo = dt.Rows[j]["refno"].ToString().Trim(),
                                    RefDate = dt.Rows[j]["refdate"].ToString().Trim(),
                                    PostedDate = dt.Rows[j]["postdate"].ToString().Trim(),
                                    CurrencyCode = dt.Rows[j]["ccyid"].ToString().Trim(),
                                    TotalAmountOC = decimal.Parse(dt.Rows[j]["fctotalamount"].ToString().Trim()),
                                    ExchangeRate = decimal.Parse(dt.Rows[j]["exchangerate"].ToString().Trim()),
                                    TotalAmountExchange = decimal.Parse(dt.Rows[j]["totalamount"].ToString().Trim()),
                                    JournalMemo = dt.Rows[j]["comment"] == null ? "" : dt.Rows[j]["comment"].ToString().Trim(),
                                    FixedAssetDecrementDetails = fixedAssetDecrementDetailVouchers,
                                };
                                if (dt.Rows[j]["objecttype"] != null)
                                {
                                    if (int.Parse(dt.Rows[j]["objecttype"].ToString().Trim()) == 1) // Khách hàng
                                    {
                                        voucher.AccountingObjectType = 3;
                                        voucher.AccountingObjectId = null;
                                        voucher.CustomerId = null;
                                        voucher.VendorId = null;
                                        voucher.EmployeeId = null;
                                    }
                                    else if (int.Parse(dt.Rows[j]["objecttype"].ToString().Trim()) == 2)
                                    // Nha cung cap
                                    {
                                        voucher.AccountingObjectType = 0;
                                        voucher.AccountingObjectId = null;
                                        voucher.CustomerId = null;
                                        if (dt.Rows[j]["objectid"] != null)
                                        {
                                            if (dt.Rows[j]["objectid"].ToString().Trim() != "")
                                            {
                                                voucher.VendorId = Model.GetIdByCode("Vendor", "VendorID",
                                                    "VendorCode",
                                                    dt.Rows[j]["objectid"].ToString().Trim());
                                            }
                                            else voucher.VendorId = null;
                                        }
                                        else voucher.VendorId = null;
                                        voucher.EmployeeId = null;
                                    }
                                    else if (int.Parse(dt.Rows[j]["objecttype"].ToString().Trim()) == 3)
                                    // Nhan vien
                                    {
                                        voucher.AccountingObjectType = 1;
                                        voucher.AccountingObjectId = null;
                                        voucher.CustomerId = null;
                                        voucher.VendorId = null;
                                        if (dt.Rows[j]["objectid"] != null)
                                        {
                                            if (dt.Rows[j]["objectid"].ToString().Trim() != "")
                                            {
                                                voucher.EmployeeId = Model.GetIdByCode("Employee",
                                                    "EmployeeID",
                                                    "EmployeeCode",
                                                    dt.Rows[j]["objectid"].ToString().Trim());
                                            }
                                            else voucher.EmployeeId = null;
                                        }
                                        else voucher.EmployeeId = null;

                                    }
                                    else // đối tượng khác
                                    {
                                        if (dt.Rows[j]["objectid"] != null)
                                        {
                                            if (dt.Rows[j]["objectid"].ToString().Trim() != "")
                                            {
                                                voucher.AccountingObjectId =
                                                    Model.GetIdByCode("AccountingObject",
                                                        "AccountingObjectID", "AccountingObjectCode",
                                                        dt.Rows[j]["objectid"].ToString().Trim());
                                            }
                                            else voucher.AccountingObjectId = null;
                                        }
                                        else voucher.AccountingObjectId = null;
                                        voucher.AccountingObjectType = 2;
                                        voucher.CustomerId = null;
                                        voucher.VendorId = null;
                                        voucher.EmployeeId = null;
                                    }
                                }
                                for (var k = 0; k < dtFixedAssetDecrementDetailVoucher.Rows.Count; k++)
                                {
                                    var fixedAssetId = Model.GetIdByCode("FixedAsset", "FixedAssetID", "FixedAssetCode",
                                        dtFixedAssetDecrementDetailVoucher.Rows[k]["fixedassetid"].ToString().Trim());
                                    var description = dtFixedAssetDecrementDetailVoucher.Rows[k]["description"] == null
                                        ? ""
                                        : dtFixedAssetDecrementDetailVoucher.Rows[k]["description"].ToString();

                                    while (description.Contains("  "))
                                    {
                                        description = description.Replace("  ", " ");
                                    }

                                    fixedAssetDecrementDetailVouchers.Add(new FixedAssetDecrementDetailModel
                                    {
                                        AccountingObjectId = dtFixedAssetDecrementDetailVoucher.Rows[k]["objectid"] == null ? null :
                                                   Model.GetIdByCode("AccountingObject",
                                                       "AccountingObjectID", "AccountingObjectCode",
                                                       dtFixedAssetDecrementDetailVoucher.Rows[k]["objectid"].ToString().Trim()),
                                        AccountNumber =
                                            dtFixedAssetDecrementDetailVoucher.Rows[k]["debitaccount"].ToString()
                                                .Trim(),
                                        CorrespondingAccountNumber =
                                            dtFixedAssetDecrementDetailVoucher.Rows[k]["creditaccount"].ToString()
                                                .Trim(),
                                        AmountExchange =
                                            decimal.Parse(
                                                dtFixedAssetDecrementDetailVoucher.Rows[k]["amount"].ToString()
                                                    .Trim()),
                                        AmountOC =
                                            decimal.Parse(
                                                dtFixedAssetDecrementDetailVoucher.Rows[k]["fcamount"].ToString()
                                                    .Trim()),
                                        AutoBusinessId = null,
                                        BudgetItemCode = dtFixedAssetDecrementDetailVoucher.Rows[k]["budgetitemid"] == null ? null :
                                            dtFixedAssetDecrementDetailVoucher.Rows[k]["budgetitemid"].ToString()
                                                .Trim(),
                                        BudgetSourceCode = dtFixedAssetDecrementDetailVoucher.Rows[k]["capitalid"] == null ? null :
                                            dtFixedAssetDecrementDetailVoucher.Rows[k]["capitalid"].ToString()
                                                .Trim(),
                                        Description = description,
                                        VoucherTypeId = null,
                                        ProjectId = null,
                                        FixedAssetId = fixedAssetId == null ? 0 : (int)fixedAssetId,
                                        UnitPriceOC =
                                            decimal.Parse(
                                                dtFixedAssetDecrementDetailVoucher.Rows[k]["fcunitprice"].ToString()
                                                    .Trim()),
                                        UnitPriceExchange =
                                            decimal.Parse(
                                                dtFixedAssetDecrementDetailVoucher.Rows[k]["unitprice"].ToString()
                                                    .Trim()),
                                        Quantity =
                                            (dtFixedAssetDecrementDetailVoucher.Rows[k]["quantity"] != null)
                                                ? (int)
                                                    decimal.Parse(
                                                        dtFixedAssetDecrementDetailVoucher.Rows[k]["quantity"]
                                                            .ToString())
                                                : 0,
                                        DepartmentId =
                                            Model.GetIdByCode("Department", "DepartmentID", "DepartmentCode",
                                                dtFixedAssetDecrementDetailVoucher.Rows[k]["departid"].ToString()
                                                    .Trim()),
                                    });
                                }

                                voucher.FixedAssetDecrementDetails = fixedAssetDecrementDetailVouchers;
                                Model.AddFixedAssetDecrement(voucher, false);
                            }
                            break;

                        #endregion

                        #region FixedAssetArmortization

                        case "FixedAssetArmortization":
                            if (Model.GetFixedAssetArmortizations().Count > 0)
                            {
                                break;
                            }
                            for (var j = 0; j < dt.Rows.Count; j++)
                            {
                                var selectClaus = "SELECT * FROM JOURENTRYDETAIL WHERE refid = '" +
                                                  dt.Rows[j]["refid"].ToString().Trim() + "' AND reftype ='502' ";
                                var dtFixedAssetArmortizationDetailVoucher = GetData(selectClaus);
                                ConvertFontData(ref dtFixedAssetArmortizationDetailVoucher, "description");
                                var fixedAssetArmortizationDetailVouchers =
                                    new List<FixedAssetArmortizationDetailModel>();

                                var voucher = new FixedAssetArmortizationModel
                                {
                                    RefTypeId = 502,
                                    RefNo = dt.Rows[j]["refno"].ToString().Trim(),
                                    RefDate = dt.Rows[j]["refdate"].ToString().Trim(),
                                    PostedDate = dt.Rows[j]["postdate"].ToString().Trim(),
                                    TotalAmountOC = decimal.Parse(dt.Rows[j]["fctotalamount"].ToString().Trim()),
                                    TotalAmountExchange = decimal.Parse(dt.Rows[j]["totalamount"].ToString().Trim()),
                                    JournalMemo = dt.Rows[j]["comment"] == null ? "" : dt.Rows[j]["comment"].ToString().TrimEnd(),
                                    FixedAssetArmortizationDetails = fixedAssetArmortizationDetailVouchers,
                                };

                                for (var k = 0; k < dtFixedAssetArmortizationDetailVoucher.Rows.Count; k++)
                                {
                                    fixedAssetArmortizationDetailVouchers.Add(new FixedAssetArmortizationDetailModel
                                    {
                                        AccountNumber =
                                            dtFixedAssetArmortizationDetailVoucher.Rows[k]["debitaccount"].ToString()
                                                .Trim(),
                                        CorrespondingAccountNumber =
                                            dtFixedAssetArmortizationDetailVoucher.Rows[k]["creditaccount"].ToString
                                                ()
                                                .Trim(),
                                        AmountExchange =
                                            decimal.Parse(
                                                dtFixedAssetArmortizationDetailVoucher.Rows[k]["amount"].ToString()
                                                    .Trim()),
                                        AmountOC =
                                            decimal.Parse(
                                                dtFixedAssetArmortizationDetailVoucher.Rows[k]["fcamount"].ToString()
                                                    .Trim()),
                                        BudgetItemCode = dtFixedAssetArmortizationDetailVoucher.Rows[k]["budgetitemid"] == null ? null :
                                            dtFixedAssetArmortizationDetailVoucher.Rows[k]["budgetitemid"].ToString()
                                                .Trim(),
                                        BudgetSourceCode = dtFixedAssetArmortizationDetailVoucher.Rows[k]["capitalid"] == null ? null :
                                            dtFixedAssetArmortizationDetailVoucher.Rows[k]["capitalid"].ToString()
                                                .Trim(),
                                        Description = dtFixedAssetArmortizationDetailVoucher.Rows[k]["description"] == null ? "" :
                                            dtFixedAssetArmortizationDetailVoucher.Rows[k]["description"].ToString()
                                                .TrimEnd(),
                                        VoucherTypeId = null,
                                        ProjectId = null,
                                        FixedAssetId =
                                            (int)
                                                Model.GetIdByCode("FixedAsset", "FixedAssetID", "FixedAssetCode",
                                                    dtFixedAssetArmortizationDetailVoucher.Rows[k]["fixedassetid"]
                                                        .ToString().Trim()),
                                        Quantity =
                                            (dtFixedAssetArmortizationDetailVoucher.Rows[k]["quantity"] != null)
                                                ? (int)
                                                    decimal.Parse(
                                                        dtFixedAssetArmortizationDetailVoucher.Rows[k]["quantity"]
                                                            .ToString())
                                                : 0,
                                        DepartmentId =
                                            Model.GetIdByCode("Department", "DepartmentID", "DepartmentCode",
                                                dtFixedAssetArmortizationDetailVoucher.Rows[k]["departid"].ToString()
                                                    .Trim()),
                                        CurrencyCode =
                                            dtFixedAssetArmortizationDetailVoucher.Rows[k]["ccyid"].ToString()
                                                .Trim(),
                                        ExchangeRate =
                                            double.Parse(
                                                dtFixedAssetArmortizationDetailVoucher.Rows[k]["exchangerate"]
                                                    .ToString()
                                                    .Trim())
                                    });
                                }

                                voucher.FixedAssetArmortizationDetails = fixedAssetArmortizationDetailVouchers;
                                Model.AddFixedAssetArmortization(voucher);
                            }
                            break;

                        #endregion

                        #region GeneralVoucher

                        case "GeneralVoucher":
                            if (Model.GetGenverVoucherByRefTypeId(900).Count > 0)
                            {
                                break;
                            }
                            for (var j = 0; j < dt.Rows.Count; j++)
                            {
                                var selectClaus = "SELECT * FROM JOURENTRYDETAIL WHERE refid = '" +
                                                  dt.Rows[j]["refid"].ToString().Trim() + "' AND reftype ='900' ";
                                var dtGeneralDetailVoucher = GetData(selectClaus);
                                ConvertFontData(ref dtGeneralDetailVoucher, "description");
                                var generalDetailVouchers = new List<GeneralDetailModel>();

                                var voucher = new GeneralVocherModel
                                {
                                    RefTypeId = 900,
                                    RefNo = dt.Rows[j]["refno"].ToString().Trim(),
                                    RefDate = DateTime.Parse(dt.Rows[j]["refdate"].ToString().Trim()),
                                    PostedDate = DateTime.Parse(dt.Rows[j]["postdate"].ToString().Trim()),
                                    TotalAmountOc = decimal.Parse(dt.Rows[j]["fctotalamount"].ToString().Trim()),
                                    TotalAmountExchange = decimal.Parse(dt.Rows[j]["totalamount"].ToString().Trim()),
                                    JournalMemo = dt.Rows[j]["comment"] == null ? "" : dt.Rows[j]["comment"].ToString().TrimEnd(),
                                    GeneralVoucherDetails = generalDetailVouchers,
                                };

                                for (var k = 0; k < dtGeneralDetailVoucher.Rows.Count; k++)
                                {
                                    var general = new GeneralDetailModel
                                    {
                                        AccountNumber =
                                            dtGeneralDetailVoucher.Rows[k]["debitaccount"].ToString().Trim(),
                                        CorrespondingAccountNumber =
                                            dtGeneralDetailVoucher.Rows[k]["creditaccount"].ToString().Trim(),
                                        AmountExchange =
                                            decimal.Parse(dtGeneralDetailVoucher.Rows[k]["amount"].ToString().Trim()),
                                        AmountOc =
                                            decimal.Parse(
                                                dtGeneralDetailVoucher.Rows[k]["fcamount"].ToString().Trim()),
                                        BudgetItemCode = dtGeneralDetailVoucher.Rows[k]["budgetitemid"] == null ? null :
                                            dtGeneralDetailVoucher.Rows[k]["budgetitemid"].ToString().Trim(),
                                        BudgetSourceCode = dtGeneralDetailVoucher.Rows[k]["capitalid"] == null ? null :
                                            dtGeneralDetailVoucher.Rows[k]["capitalid"].ToString().Trim(),
                                        Description = dtGeneralDetailVoucher.Rows[k]["description"] == null ? "" :
                                            dtGeneralDetailVoucher.Rows[k]["description"].ToString().TrimEnd(),
                                        AccountingObjectId = dtGeneralDetailVoucher.Rows[k]["objectid"] == null ? null :
                                                Model.GetIdByCode("AccountingObject",
                                                    "AccountingObjectID", "AccountingObjectCode",
                                                    dtGeneralDetailVoucher.Rows[k]["objectid"].ToString().Trim()),
                                    };
                                    if (dtGeneralDetailVoucher.Rows[k]["vouchertype"] != null)
                                    {
                                        if (int.Parse(dtGeneralDetailVoucher.Rows[k]["vouchertype"].ToString()) != 0)
                                            general.VoucherTypeId =
                                                int.Parse(dtGeneralDetailVoucher.Rows[k]["vouchertype"].ToString());
                                        else
                                            general.VoucherTypeId = null;
                                    }
                                    else general.VoucherTypeId = null;

                                    general.ProjectId = null;
                                    general.DepartmentId = Model.GetIdByCode("Department", "DepartmentID",
                                        "DepartmentCode",
                                        dtGeneralDetailVoucher.Rows[k]["departid"].ToString().Trim());
                                    general.CurrencyCode = dtGeneralDetailVoucher.Rows[k]["ccyid"].ToString().Trim();
                                    general.ExchangeRate =
                                        decimal.Parse(
                                            dtGeneralDetailVoucher.Rows[k]["exchangerate"].ToString().Trim());
                                    general.EmployeeId = Model.GetIdByCode("Employee", "EmployeeId", "EmployeeCode",
                                        dtGeneralDetailVoucher.Rows[k]["employeeid"].ToString().Trim());
                                    general.CustomerId = null;
                                    general.InventoryItemId = null;
                                    general.VendorId = Model.GetIdByCode("Vendor", "VendorId", "VendorCode",
                                        dtGeneralDetailVoucher.Rows[k]["vendorid"].ToString().Trim());

                                    generalDetailVouchers.Add(general);
                                }

                                voucher.GeneralVoucherDetails = generalDetailVouchers;
                                Model.IsConvertData = true;
                                Model.AddGeneralVoucher(voucher);
                            }
                            break;

                            #endregion

                            #endregion
                    }
                    progressBarControl.PerformStep();
                    progressBarControl.Update();
                }
                progressBarControl.Position = progressBarControl.Properties.Maximum;
                progressBarControl.Update();
                XtraMessageBox.Show("Chuyển đổi dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                OleDbHelper.OleDbConn.Close();
                btnCancel.Text = ResourceHelper.GetResourceValueByName("Fisnish");
                btnCancel.Focus();
                return true;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                XtraMessageBox.Show(ex.Message + ex.InnerException + ex.StackTrace + " " + destinationTableName);
                return false;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        /// <summary>
        /// Gets the fixed asset amount.
        /// </summary>
        /// <param name="fixedAssetCode">The fixed asset code.</param>
        /// <param name="accountCode">The account code.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns></returns>
        private DataTable GetFixedAssetAmount(string fixedAssetCode, string accountCode, string currencyCode)
        {
            var balanceDate = dtBalanceDate.DateTime.Date;
            var queryString =
                "SELECT SUM(amount) as Amount, SUM(fcamount) as FCAmount FROM JourentryAccount WHERE FixedAssetId = '" +
                fixedAssetCode + "' AND LEFT(ALLTRIM(Account),LEN('" + accountCode + "')) = '" + accountCode + "' AND PostDate < CTOD('" + balanceDate.Month + "/" + balanceDate.Day + "/" + balanceDate.Year + "') " +
                "AND CcyID ='" + currencyCode + "'";
            return GetData(queryString);
        }

        /// <summary>
        /// Checks the fixed asset decrease.
        /// </summary>
        /// <param name="fixedAssetCode">The fixed asset code.</param>
        /// <returns></returns>
        private bool CheckFixedAssetDecreaseExisted(string fixedAssetCode)
        {
            var balanceDate = dtBalanceDate.DateTime.Date;
            var queryString =
                "SELECT FixedAssetId FROM JourentryAccount WHERE FixedAssetId = '" +
                fixedAssetCode + "' AND RefType = '501' AND PostDate >= CTOD('" + balanceDate.Month + "/" + balanceDate.Day + "/" +
                balanceDate.Year + "') ";

            var dt = GetData(queryString);
            if (dt != null && dt.Rows.Count > 0) return true;
            return false;
        }

        #endregion

        #region Events

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmXtraConvertFoxproData"/> class.
        /// </summary>
        public FrmXtraConvertFoxproData()
        {
            InitializeComponent();
            _autoNumberPresenter = new AutoNumberPresenter(this);
            dtBalanceDate.DateTime = new DateTime(2014, 1, 1);
        }

        /// <summary>
        /// Handles the ButtonClick event of the btnSelectFile control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DevExpress.XtraEditors.Controls.ButtonPressedEventArgs"/> instance containing the event data.</param>
        private void btnSelectFile_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fdlg = new OpenFileDialog
            {
                Title = Properties.Resources.SelectDataFileCaption,
                InitialDirectory = @"D:\",
                FileName = btnSelectFile.Text,
                Filter = Properties.Resources.FileFilter,
                FilterIndex = 1,
                RestoreDirectory = true
            };
            if (fdlg.ShowDialog() != DialogResult.OK) return;
            btnSelectFile.Text = fdlg.FileName;
            GetTableName();
            Import(lstTableName.Items[0].ToString());
            System.Windows.Forms.Application.DoEvents();
        }

        /// <summary>
        /// Handles the Click event of the btnConvert control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(btnSelectFile.Text.Trim()))
            {
                XtraMessageBox.Show("Vui lòng chọn đường dẫn dữ liệu nguồn để chuyển đổi!", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                btnSelectFile.Focus();
                return;
            }
            if (radioConvertOption.EditValue == null)
            {
                XtraMessageBox.Show("Vui lòng chọn một loại hình chuyển đổi dữ liệu!", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                radioConvertOption.Focus();
                return;
            }
            if (int.Parse(radioConvertOption.EditValue.ToString()) == 1)
            {
                if (!CompleteConvert())
                    XtraMessageBox.Show("Chuyển đổi dữ liệu thất bại!", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
            else
            {
                if (!ConvertBalance(dtBalanceDate.DateTime.Date))
                    XtraMessageBox.Show("Chuyển đổi dữ liệu thất bại!", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnCancel_Click(object sender, EventArgs e)
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

        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the lstTableConvert control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void lstTableConvert_SelectedIndexChanged(object sender, EventArgs e)
        {
            Import(lstTableName.SelectedValue.ToString());
        }

        /// <summary>
        /// Handles the Load event of the FrmXtraConvertFoxproData control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FrmXtraConvertFoxproData_Load(object sender, EventArgs e)
        {
            var path = System.Windows.Forms.Application.StartupPath;
            var convertFile = path + @"\convertdata.xml";
            if (File.Exists(@convertFile))
            {
                _convertData = new DataSet("Convert");
                _convertData.ReadXml(convertFile);
                if (_convertData.Tables[0].Rows.Count <= 0) return;
                for (var i = 0; i < _convertData.Tables[0].Rows.Count; i++)
                    lstConvertTable.Items.Add(_convertData.Tables[0].Rows[i]["SourceTable"]);
                Model = new Model.Model();
            }
            else
            {
                XtraMessageBox.Show("Tệp chuyển đổi dữ liệu [convertdata.xml] không tồn tại. Vui lòng kiểm tra lại!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the radioConvertOption control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void radioConvertOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtBalanceDate.Enabled = radioConvertOption.EditValue.ToString() != "1";
        }

        #endregion


    }
}
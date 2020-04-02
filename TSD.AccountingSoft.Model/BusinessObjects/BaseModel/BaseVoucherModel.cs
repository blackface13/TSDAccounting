/***********************************************************************
 * <copyright file="BaseVoucherModel.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Wednesday, October 8, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.ComponentModel;

namespace TSD.AccountingSoft.Model.BusinessObjects.BaseModel
{
    public class BaseVoucherModel : IDataErrorInfo
    {
        /// <summary>
        /// Gets or sets the detail by.
        /// </summary>
        /// <value>
        /// The detail by.
        /// </value>
        [Browsable(true)]
        public string DetailBy { get; set; }

        /// <summary>
        /// Gets an error message indicating what is wrong with this object.
        /// </summary>
        [Browsable(false)]
        public string Error
        {
            get { return GetError(); }
        }

        /// <summary>
        /// Gets the error message for the property with the given name.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <returns></returns>
        public string this[string columnName]
        {
            get { return GetError(columnName); }
        }

        /// <summary>
        /// Gets the error.
        /// </summary>
        /// <param name="columnName">Name of the column.</param>
        /// <returns></returns>
        string GetError(string columnName = null)
        {
            switch (columnName)
            {
                case "CurrencyCode":
                    if (DetailBy != null && DetailBy.Contains(columnName))
                        return GetPropValue(this, columnName) == null ? "Loại tiền không được để trống!" : null;
                    return null;
                case "AccountNumber":
                    if (DetailBy != null && DetailBy.Contains(columnName))
                        return GetPropValue(this, columnName) == null ? "Tài khoản không được để trống!" : null;
                    return null;
                case "CorrespondingAccountNumber":
                    if (DetailBy != null && DetailBy.Contains(columnName))
                        return GetPropValue(this, columnName) == null ? "Tài khoản đối ứng không được để trống!" : null;
                    return null;
                case "BudgetItemCode":
                    if (DetailBy != null && DetailBy.Contains(columnName))
                    {
                        var accountCode = GetPropValue(this, "CorrespondingAccountNumber");
                        var budgetItemValue = GetPropValue(this, columnName);
                        if (accountCode != null && accountCode.ToString().StartsWith("6612") && budgetItemValue != null && !(budgetItemValue.ToString().StartsWith("6") || budgetItemValue.ToString().StartsWith("7") || budgetItemValue.ToString().StartsWith("9")))
                        {
                            return "Mục tiểu mục yêu cầu cho bút toán này là loại Mục tiểu mục chi!";
                        }
                        return GetPropValue(this, columnName) == null ? "Mã mục lục ngân sách không được để trống!" : null;
                    }
                    return null;
                case "BudgetSourceCode":
                    if (DetailBy != null && DetailBy.Contains(columnName))
                        return GetPropValue(this, columnName) == null ? "Mã nguồn vốn không được để trống!" : null;
                    return null;
                case "VoucherTypeId":
                    if (DetailBy != null && DetailBy.Contains(columnName))
                        return GetPropValue(this, columnName) == null ? "Nghiệp vụ không được để trống!" : null;
                    return null;
                case "ProjectId":
                    if (DetailBy != null && DetailBy.Contains(columnName))
                        if (GetPropValue(this, columnName) == null)
                        {
                            return "Mã dự án không được để trống!";
                        }
                        else
                        {
                            if ((int)GetPropValue(this, columnName) == 0)
                            {
                                return "Mã dự án không được để trống!";
                            }
                            return null;
                        }

                    return null;
                case "DepartmentId":
                    if (DetailBy != null && DetailBy.Contains(columnName))
                        return GetPropValue(this, columnName) == null ? "Mã phòng ban không được để trống!" : null;
                    return null;
                case "FixedAssetId":
                    if (DetailBy != null && DetailBy.Contains(columnName))
                        return GetPropValue(this, columnName) == null ? "Mã tài sản không được để trống!" : null;
                    return null;
                case "InventoryItemId":
                    if (DetailBy != null && DetailBy.Contains(columnName))
                        return GetPropValue(this, columnName) == null ? "Mã vật tư không được để trống!" : null;
                    return null;
                case "AccountingObjectId":
                    if (DetailBy != null && DetailBy.Contains(columnName))
                        return GetPropValue(this, columnName) == null ? "Đối tượng khác không được để trống!" : null;
                    return null;
                case "CustomerId":
                    if (DetailBy != null && DetailBy.Contains(columnName))
                        return GetPropValue(this, columnName) == null ? "Mã khách hàng không được để trống!" : null;
                    return null;
                case "VendorId":
                    if (DetailBy != null && DetailBy.Contains(columnName))
                        return GetPropValue(this, columnName) == null ? "Mã nhà cung cấp không được để trống!" : null;
                    return null;
                case "EmployeeId":
                    if (DetailBy != null && DetailBy.Contains(columnName))
                        return GetPropValue(this, columnName) == null ? "Mã nhân viên không được để trống!" : null;
                    return null;
                case "Quantity":
                    if (DetailBy != null && DetailBy.Contains(columnName))
                    {
                        var quantity = GetPropValue(this, columnName);
                        return quantity == null || (int)quantity == 0 ? "Số lượng phải khác 0!" : null;
                    }
                    return null;
                case "ExchangeRate":
                    if (DetailBy != null && DetailBy.Contains(columnName))
                    {
                        var exchangeRate = GetPropValue(this, columnName);
                        return exchangeRate == null || Convert.ToDecimal(exchangeRate) == 0
                            ? "Tỷ giá phải khác 0!"
                            : null;
                    }
                    return null;
            }
            return null;
        }

        /// <summary>
        /// Gets the property value.
        /// </summary>
        /// <param name="src">The source.</param>
        /// <param name="propName">Name of the property.</param>
        /// <returns></returns>
        public static object GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }
    }
}

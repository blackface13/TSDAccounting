/***********************************************************************
 * <copyright file="CommonEnum.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Monday, March 03, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;

namespace TSD.Enum
{
    public static class EnumHelper
    {
        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">value</exception>
        public static string GetDescription(this System.Enum value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            var description = value.ToString();
            var fieldInfo = value.GetType().GetField(description);
            var attributes =
                (EnumDescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(EnumDescriptionAttribute), false);
            if (attributes.Length > 0)
            {
                description = attributes[0].Description;
            }
            return description;
        }

        /// <summary>
        /// To the list.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">type</exception>
        public static IList ToList(this Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }
            var list = new ArrayList();
            var enumValues = System.Enum.GetValues(type);
            var i = -1;
            foreach (var value in enumValues)
            {
                i += 1;
                list.Add(new KeyValuePair<int, string>(i, GetDescription((System.Enum)value)));
            }
            return list;
        }
    }

    /// <summary>
    /// Enum Description Attribute
    /// </summary>
    public sealed class EnumDescriptionAttribute : Attribute
    {
        private readonly string _description;

        public string Description
        {
            get { return _description; }
        }

        public EnumDescriptionAttribute(string description)
        {
            _description = description;
        }
    }

    public enum CommonEnum
    {

    }

    public enum EnumNavigationStatus
    {
        FirstPosition = 0,
        LastPosition = 1,
        InsidePosition = 2,
        EmptyPostion = 3,
        OnlyOneRow = 4
    }

    /// <summary>
    /// Enum of  state of fixed asset
    /// </summary>
    public enum FixedAssetState
    {
        [EnumDescription("Mua chưa dùng")]
        NotUse,
        [EnumDescription("Đang dùng")]
        Using,
        [EnumDescription("Đang dùng - Dừng tính khấu hao")]
        UsingNotDepreciation,
        [EnumDescription("Đã thanh lý")]
        Disposed,
        [EnumDescription("Đã chuyển nhượng")]
        Transferred,
        [EnumDescription("Ghi giảm theo số lượng")]
        DisposedByQuantity
    }

    public enum AccountKind
    {
        [EnumDescription("Dư Nợ")]
        DebitAccount,
        [EnumDescription("Dư Có")]
        CreditAccount,
        [EnumDescription("Lưỡng tính")]
        Other,
    }

    public enum PlanType
    {
        [EnumDescription("Dự toán thu")]
        Receipt,
        [EnumDescription("Dự toán chi")]
        Payment,
    }

    public enum ControlValueType
    {
        [EnumDescription("Money")]
        Money,
        [EnumDescription("Quantity")]
        Quantity,
        [EnumDescription("Rate")]
        Rate,
        [EnumDescription("ExchangeRate")]
        ExchangeRate,
        [EnumDescription("Year")]
        Year,
        [EnumDescription("Percent")]
        Percent
    }
}

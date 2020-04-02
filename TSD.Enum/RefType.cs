/***********************************************************************
 * <copyright file="RefType.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Thursday, June 19, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System.ComponentModel;

namespace TSD.Enum
{
    public enum RefType : int
    {
        /// <summary>
        /// The receipt estimate
        /// </summary>
        ReceiptEstimate = 110,
        /// <summary>
        /// The payment estimate
        /// </summary>
        PaymentEstimate = 120,
        /// <summary>
        /// The receipt cash
        /// </summary>
        [EnumDescription("Phiếu thu")]
        ReceiptCash = 200,
        /// <summary>
        /// The payment cash
        /// </summary>
        [EnumDescription("Phiếu chi")]
        PaymentCash = 201,
        /// <summary>
        /// The receipt deposite
        /// </summary>
        [EnumDescription("Thu tiền gửi")]
        ReceiptDeposite = 300,
        /// <summary>
        /// The payment deposite
        /// </summary>
        [EnumDescription("Chi tiền gửi")]
        PaymentDeposite = 301,
        /// <summary>
        /// The inward stock
        /// </summary>
        [EnumDescription("Nhập kho")]
        InwardStock = 400,
        /// <summary>
        /// The outward stock
        /// </summary>
        [EnumDescription("Xuất kho")]
        OutwardStock = 401,
        /// <summary>
        /// The su increment
        /// </summary>
        [EnumDescription("Ghi tăng công cụ dụng cụ")]
        SUIncrement = 405,
        /// <summary>
        /// The su decrement
        /// </summary>
        [EnumDescription("Ghi giảm công cụ dụng cụ")]
        SUDecrement = 406,
        /// <summary>
        /// The fixed asset increment
        /// </summary>
        FixedAssetIncrement = 500,
        /// <summary>
        /// The fixed asset decrement
        /// </summary>
        FixedAssetDecrement = 501,
        /// <summary>
        /// The fixed asset armortization
        /// </summary>
        FixedAssetArmortization = 502,
        /// <summary>
        /// The opening account entry
        /// </summary>
        OpeningAccountEntry = 700,
        /// <summary>
        /// The general voucher
        /// </summary>
        GeneralVoucher = 900,
        /// <summary>
        /// The captital allocate voucher
        /// </summary>
        CaptitalAllocateVoucher = 901,

        /// <summary>
        /// The account tranfer voucher
        /// </summary>
        AccountTranferVourcher = 902,

        /// <summary>
        /// The salary
        /// </summary>
        Salary = 600,

        FixedAssetDictionary = 1000,

        [EnumDescription("Số dư Công cụ dụng cụ")]
        OpeningSupplyEntry = 602,
    }
}

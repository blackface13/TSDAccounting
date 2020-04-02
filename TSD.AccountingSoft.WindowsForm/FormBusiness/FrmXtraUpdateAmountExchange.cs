/***********************************************************************
 * <copyright file="FrmXtraUpdateAmountExchange.cs" company="BUCA JSC">
 * -->    Copyright (C) statement. All right reserved
 * </copyright>
 * 
 * Created:   LinhMC
 * Email:    linhmc@buca.vn
 * Website:
 * Create Date: Thursday, September 18, 2014
 * Usage: 
 * 
 * RevisionHistory: 
 * Date         Author               Description 
 * 
 * ************************************************************************/

using System;
using System.Windows.Forms;
using TSD.AccountingSoft.Session;
using TSD.AccountingSoft.WindowsForm.FormBase;
using DevExpress.XtraEditors;

namespace TSD.AccountingSoft.WindowsForm.FormBusiness
{
    /// <summary>
    /// Calculate and update amount exchange
    /// </summary>
    public partial class FrmXtraUpdateAmountExchange : FrmXtraBaseCategoryDetail
    {
        /// <summary>
        /// The _global variable
        /// </summary>
        readonly GlobalVariable _globalVariable = new GlobalVariable();
        /// <summary>
        /// Initializes a new instance of the <see cref="FrmXtraUpdateAmountExchange"/> class.
        /// </summary>
        public FrmXtraUpdateAmountExchange()
        {
            InitializeComponent();
            dateTimeRangeV.InitData(DateTime.Parse(_globalVariable.PostedDate));
            dateTimeRangeV.SetComboIndex(7);

        }

        /// <summary>
        /// Valids the data.
        /// </summary>
        /// <returns></returns>
        protected override bool ValidData()
        {
            if (txtExchangeRate.Value == 0)
            {
                XtraMessageBox.Show("Tỷ giá quy đổi phải khác 0. Vui lòng nhập lại giá trị khác!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            if (
                XtraMessageBox.Show(
                    "Việc cập nhật tỷ giá sẽ thay đổi toàn bộ số liệu ở cột tiền Quy đổi, bạn có muốn thực hiện thao tác này không?",
                    "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                var model = new Model.Model();
                int result = model.UpdateAmountExchange(txtExchangeRate.Value, short.Parse(_globalVariable.CurrencyDecimalDigits), dateTimeRangeV.FromDate, dateTimeRangeV.ToDate);
                if (result == 1)
                {
                    XtraMessageBox.Show("Cập nhật tỷ giá cột tiền quy đổi thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return 1;
                }
                return 0;
            }
            return 1;
        }

    }
}
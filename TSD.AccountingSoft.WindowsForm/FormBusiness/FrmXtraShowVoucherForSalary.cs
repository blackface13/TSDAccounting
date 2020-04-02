using System;
using System.Windows.Forms;
using TSD.AccountingSoft.WindowsForm.FormBase;
using TSD.AccountingSoft.WindowsForm.Resources;
using TSD.Enum;
using DevExpress.XtraEditors;

namespace TSD.AccountingSoft.WindowsForm.FormBusiness
{
    public partial class FrmXtraShowVoucherForSalary : DevExpress.XtraEditors.XtraForm
    {
        public string KeyCash { get; set; }
        public string KeyDeposit { get; set; } 
        public FrmXtraShowVoucherForSalary()
        {
            InitializeComponent();
        }

        private void FrmXtraShowVoucherForSalary_Load(object sender, EventArgs e)
        {

        }

        private void btnGiayBaoNo_Click(object sender, EventArgs e)
        {
              try
            {
            var frmDetail = new FrmXtraPaymentDepositDetail();
            frmDetail.ActionMode = ActionModeVoucherEnum.None;
            frmDetail.KeyValue = KeyDeposit;
            frmDetail.MasterBindingSource = new BindingSource();
            frmDetail.CurrentPosition = 1;
            frmDetail.ShowDialog();
            }
              catch (Exception)
              {

                  XtraMessageBox.Show("Chứng từ đã bị xóa!", ResourceHelper.GetResourceValueByName("ResExceptionCaption"));
              }
        }

        private void btnPhieuChi_Click(object sender, EventArgs e)
        {
            try
            {
            var frmDetail = new FrmXtraFormPaymentVoucherDetail();
            frmDetail.ActionMode = ActionModeVoucherEnum.None;
            frmDetail.KeyValue = KeyCash;
            frmDetail.MasterBindingSource = new BindingSource();
            frmDetail.CurrentPosition = 1;
            frmDetail.ShowDialog();
             }
          catch (Exception)
            {

                XtraMessageBox.Show("Chứng từ đã bị xóa!", ResourceHelper.GetResourceValueByName("ResExceptionCaption"));
            }
    }
    }
}